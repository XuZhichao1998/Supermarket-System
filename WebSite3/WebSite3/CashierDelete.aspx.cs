using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class CashierDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string htmlstr = "管理员ID:" + Session["AdminId"] + " 管理员姓名:" + Session["AdminName"] + " 等级:" + (((string)Session["AdminRoleId"] == "2") ? "普通管理员" : "业务经理") + "&nbsp;<a href=\"Logout.aspx?identity=Admin\">注销</a>";
            AdminInf.InnerHtml = htmlstr;
            TextBox_CashierID.Text = Request.QueryString["SalesPersonId"];
            TextBox_CashierName.Text = Request.QueryString["SPName"];
        }
    }

    protected void Button_Delete_Click(object sender, EventArgs e)
    {
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
            string str_insert = "delete from SalesPerson where SalesPersonId='" + Request.QueryString["SalesPersonId"].ToString() + "';";
            command.CommandText = str_insert;
            int f = command.ExecuteNonQuery();
            if (f != 0)
            {
                showResult.InnerHtml = "编号为:" + Request.QueryString["SalesPersonId"] + "姓名为:" + Request.QueryString["SPName"] + "的收银员删除成功！";
                TextBox_CashierID.Text = "";
                TextBox_CashierName.Text = "";
            }
            else
            {
                showResult.InnerHtml = "编号为:" + Request.QueryString["SalesPersonId"] + "姓名为:" + Request.QueryString["SPName"] + "的收银员删除失败！";

            }
            conn.Close();
        }
        catch (Exception es)
        {
            showResult.InnerHtml = "编号为:" + Request.QueryString["SalesPersonId"] + "姓名为:" + Request.QueryString["SPName"] + "的收银员删除过程中出错了!信息如下:\n"+es.Message;

        }
    }
}