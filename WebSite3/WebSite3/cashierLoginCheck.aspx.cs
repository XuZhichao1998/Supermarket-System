using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class cashierLoginCheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string SPName = Request.Form["cashierName"];
        string LoginPwd = Request.Form["cashierPassword"];
        string SalesPersonId = "";
        try
        {
            //第一步，新建连接对象
            SqlConnection conn = new SqlConnection();
            //第二步，给连接对象指定参数（连接字符串）
            conn.ConnectionString = "Data Source=localhost;Initial Catalog=supermarketDB;Integrated Security=True";
            //第三步，开始建立连接
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }          
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "select * from  SalesPerson where SPName='" + SPName + "' and LoginPwd='" + LoginPwd + "'";
            var reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                Response.Write("用户名或密码错误！<a href=\"cashierLogin.aspx\">返回重试</a>");
            }
            else
            {
                while(reader.Read())
                {
                    SalesPersonId = reader.GetInt32(0).ToString();
                }
                Session["curSalesPersonId"] = SalesPersonId;
                Session["curSPName"] = SPName;
                Session["curSPLoginPwd"] = LoginPwd;
                Response.Redirect("cashierWork.aspx");
            }
            reader.Close();
            conn.Close();
           
        }
        catch (Exception es)
        {
            Response.Write("除了一些错误，信息如下：\n" + es.Message);
        }
    }
}