using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class CashierModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string htmlstr = "管理员ID:" + Session["AdminId"] + " 管理员姓名:" + Session["AdminName"] + " 等级:" + (((string)Session["AdminRoleId"] == "2") ? "普通管理员" : "业务经理") + "&nbsp;<a href=\"Logout.aspx?identity=Admin\">注销</a>";
            AdminInf.InnerHtml = htmlstr;
            TextBox_CashierID.Text = Request.QueryString["SalesPersonId"];
            TextBox_CashierName.Text = Request.QueryString["SPName"];
            TextBox_Pwd.Text = Request.QueryString["LoginPwd"];
        }   
    }

    protected void Button_Reset_Click(object sender, EventArgs e)
    {
        showResult.InnerHtml = "";
        TextBox_Pwd.Text = Request.QueryString["LoginPwd"];
    }

    protected void Button_Delete_Click(object sender, EventArgs e)
    {
        string PrePwd = Request.QueryString["LoginPwd"];
        string Pwd = TextBox_Pwd.Text;
        if(Pwd==PrePwd)
        {
            showResult.InnerHtml = "密码没有改变，不需要更新！";
            return;
        }
        if(Pwd=="")
        {
            showResult.InnerHtml = "请输入密码！";
            return;
        }
        if(Pwd.Length<6)
        {
            showResult.InnerHtml = "密码不能少于6位！";
            return;
        }
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
            string str_insert = "update SalesPerson set LoginPwd='"+Pwd+"' where SalesPersonId='" + Request.QueryString["SalesPersonId"].ToString() + "';";
            command.CommandText = str_insert;
            int f = command.ExecuteNonQuery();
            if (f != 0)
            {
                showResult.InnerHtml = "编号为:" + Request.QueryString["SalesPersonId"] + "姓名为:" + Request.QueryString["SPName"] + "的收银员改密码成功！";
                TextBox_CashierID.Text = "";
                TextBox_CashierName.Text = "";
            }
            else
            {
                showResult.InnerHtml = "编号为:" + Request.QueryString["SalesPersonId"] + "姓名为:" + Request.QueryString["SPName"] + "的收银员改密码失败！";

            }
            conn.Close();
        }
        catch (Exception es)
        {
            showResult.InnerHtml = "编号为:" + Request.QueryString["SalesPersonId"] + "姓名为:" + Request.QueryString["SPName"] + "的收银员改密码过程中出错了!信息如下:\n" + es.Message;

        }

    }
}