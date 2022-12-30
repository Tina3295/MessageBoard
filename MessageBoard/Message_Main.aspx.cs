using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MessageBoard
{
    public partial class Message_Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
                //從config找到資料庫位置
                string config = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MessageBoardConnectionString"].ConnectionString;
                //與資料庫做連結的大門
                SqlConnection connection = new SqlConnection(config);
                //SQL語法，使用參數
                SqlCommand command = new SqlCommand($"SELECT MessageID, Topic, Author, Text, InitDate FROM Message where(MessageID =@MessageID)", connection);

                command.Parameters.Add("@MessageID", SqlDbType.NVarChar); //設定參數資料型態
                command.Parameters["@MessageID"].Value = Request["ID"]; //賦予參數值

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Message_Topic.Text = reader["Topic"].ToString();
                    Message_Author.Text = reader["Author"].ToString();
                    Message_InitDate.Text = reader["InitDate"].ToString();
                    Message_Text.Text = reader["Text"].ToString();
                }
                connection.Close();


                Show();

            }
        }

        protected void Reply_Click(object sender, EventArgs e)
        {
            Response.Redirect("Message_Reply.aspx?id=" + Request.QueryString["ID"]);
        }

        private void Show()
        {
            //從config找到資料庫位置
            string config = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["MessageBoardConnectionString"].ConnectionString;
            //與資料庫做連結的大門
            SqlConnection connection = new SqlConnection(config);
            //SQL語法，使用參數
            SqlCommand command = new SqlCommand($"SELECT * FROM Response where(MessageID =@MessageID)", connection);

            command.Parameters.Add("@MessageID", SqlDbType.NVarChar); //設定參數資料型態
            command.Parameters["@MessageID"].Value = Request["ID"]; //賦予參數值

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            GridView1.DataSource = reader; //(拿資料)
                                           //控制器綁定 (真的把資料放進去)
            GridView1.DataBind();
            connection.Close();




        }

        protected void Homepage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Message_Index.aspx");
        }
    }
}