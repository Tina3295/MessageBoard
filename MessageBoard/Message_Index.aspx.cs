using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MessageBoard
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            show();
        }

        private void show()
        {
            //1.連線資料庫
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["MessageBoardConnectionString"].ConnectionString);

            //2.sql語法
            string sql = "SELECT * ,(SELECT COUNT(*) FROM Response where MessageID = Message.MessageID)as 回應 FROM Message";

            //3.創建command物件
            SqlCommand command = new SqlCommand(sql, connection);

            //4.資料庫連線開啟
            connection.Open();

            //5.執行sql (連線的作法-需自行關閉)
            SqlDataReader reader = command.ExecuteReader();
            //DataReader速度快只能逐筆單向有上往下而且不能計算，適合用來抓單筆資料
            //控制器資料來源
            GridView1.DataSource = reader; //(拿資料)
                                           //控制器綁定 (真的把資料放進去)
            GridView1.DataBind();

            //6.資料庫關閉
            connection.Close();
        }

        protected void WantToAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Message_Add.aspx");
        }
    }
}