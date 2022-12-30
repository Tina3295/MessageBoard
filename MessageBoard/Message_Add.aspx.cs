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
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Confirm_Click(object sender, EventArgs e)
        {
			//1.連線資料庫
			SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["MessageBoardConnectionString"].ConnectionString);

			//2.sql語法，VALUES先使用@參數來取代直接給值，以防SQL Injection 程式碼
			string sql = "INSERT INTO Message(Topic,Author,Text) VALUES(@Topic,@Author,@Text)";

			//3.創建command物件
			SqlCommand command = new SqlCommand(sql, connection);

			//4.參數化，Parameters:為了防止SQL Injection 程式碼攻擊，所以寫入SQL時，要使用參數「@參數名稱」來代替直接給的值，而給予參數的資料型態要使用Add
			command.Parameters.AddWithValue("@Topic", Topic.Text);
			command.Parameters.AddWithValue("@Author", Author.Text);
			command.Parameters.AddWithValue("@Text", Text.Text);

			//5.資料庫連線開啟
			connection.Open();

			//6.執行sql (新增刪除修改)
			command.ExecuteNonQuery(); //無回傳值

			//7.資料庫關閉
			connection.Close();

			Response.Redirect("Message_Index.aspx");
		}
    }
}