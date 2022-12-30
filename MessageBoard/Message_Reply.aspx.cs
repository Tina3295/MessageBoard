using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MessageBoard
{
    public partial class Message_Reply : System.Web.UI.Page
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
                SqlCommand command = new SqlCommand($"SELECT MessageID, Topic FROM Message where(MessageID =@MessageID)", connection);

                command.Parameters.Add("@MessageID", SqlDbType.Int); //設定參數資料型態
                command.Parameters["@MessageID"].Value = Convert.ToInt32(Request.QueryString["ID"]); //賦予參數值

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ReplyTopic.Text = "RE:"+reader["Topic"].ToString();
                    
                }
                connection.Close();
            }
        }

        protected void Reply_Click(object sender, EventArgs e)
        {
			//1.連線資料庫
			SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["MessageBoardConnectionString"].ConnectionString);

			//2.sql語法，VALUES先使用@參數來取代直接給值，以防SQL Injection 程式碼
			string sql = "INSERT INTO Response(Respondent,ResponseContent,MessageID) VALUES(@Respondent,@ResponseContent,@MessageID)";

			//3.創建command物件
			SqlCommand command = new SqlCommand(sql, connection);

			//4.參數化，Parameters:為了防止SQL Injection 程式碼攻擊，所以寫入SQL時，要使用參數「@參數名稱」來代替直接給的值，而給予參數的資料型態要使用Add
			command.Parameters.AddWithValue("@Respondent", Respondent.Text);
			command.Parameters.AddWithValue("@ResponseContent", ResponseContent.Text);
			command.Parameters.AddWithValue("@MessageID", Convert.ToInt32(Request.QueryString["ID"]));

			//5.資料庫連線開啟
			connection.Open();

			//6.執行sql (新增刪除修改)
			command.ExecuteNonQuery(); //無回傳值

			//7.資料庫關閉
			connection.Close();

			//跳轉至回應的留言內容區(用ID來抓取)
			Response.Redirect("Message_Main.aspx?id=" + Request.QueryString["ID"]);
		}
    }
}