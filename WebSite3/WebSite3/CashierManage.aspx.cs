using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class CashierManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string htmlstr = "管理员ID:" + Session["AdminId"] + " 管理员姓名:" + Session["AdminName"] + " 等级:" + (((string)Session["AdminRoleId"] == "2") ? "普通管理员" : "业务经理") + "&nbsp;<a href=\"Logout.aspx?identity=Admin\">注销</a>";
        AdminInf.InnerHtml = htmlstr;
    }

    protected void Button_Reset_Click(object sender, EventArgs e)
    {
        TextBox_CashierName.Text = "";
        TextBox_Pwd.Text = "";
        TextBox_Pwdd.Text = "";
        showRegisterMsg.InnerHtml = "";
    }

    protected void Button_Submit_Click(object sender, EventArgs e)
    {
        string SPName = TextBox_CashierName.Text;
        string LoginPwd = TextBox_Pwd.Text;
        string pwd2 = TextBox_Pwdd.Text;
        if(SPName==""||LoginPwd=="")
        {
            showRegisterMsg.InnerHtml = "姓名或密码都不能为空！";
            return;
        }
        if(LoginPwd.Length<6)
        {
            showRegisterMsg.InnerHtml = "密码长度不能小于6！";
            return;
        }
        if(LoginPwd!=pwd2)
        {
            showRegisterMsg.InnerHtml = "密码和确认密码不一致！";
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
            string str_insert = "insert into SalesPerson(SPName,LoginPwd) values('{0}','{1}');";
            str_insert = string.Format(str_insert, SPName, LoginPwd);
            command.CommandText = str_insert;
            int f = command.ExecuteNonQuery();
            if (f != 0)
            {
                showRegisterMsg.InnerHtml = "收银员[" + SPName + "],密码[" + LoginPwd + "]添加成功！";
            }
            else
            {
                showRegisterMsg.InnerHtml = "收银员[" + SPName + "],密码[" + LoginPwd + "]添加失败！";
            }
            conn.Close();
        }
        catch (Exception es)
        {
            showRegisterMsg.InnerHtml = "收银员[" + SPName + "],密码[" + LoginPwd + "]添加过程中出错了。错误信息如下:\n"+es.Message;
        }
    }

    protected void Button_Clear_Click(object sender, EventArgs e)
    {
        showCashier.InnerHtml = "";
    }

    protected void Button_Query_Click(object sender, EventArgs e)
    {
        string HTML = "<table><caption>收银员信息表</caption><tr><th>序号</th><th>收银员编号</th><th>收银员姓名</th><th>登录密码</th><th>操作</th></tr>";
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
            command.CommandText = "select * from SalesPerson";
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                int cntt = 0;
                while (reader.Read())
                {
                    ++cntt;
                    string SalesPersonId = reader.GetInt32(0).ToString();
                    string SPName = reader["SPName"].ToString();
                    string LoginPwd = reader["LoginPwd"].ToString();
                    string LinkStrDelete = "<a href=\"CashierDelete.aspx?SalesPersonId=" + SalesPersonId + "&SPName=" + SPName + "\">去删除</a>";
                    string LinkStrModify = "<a href=\"CashierModify.aspx?SalesPersonId=" + SalesPersonId + "&SPName=" + SPName + "&LoginPwd="+ LoginPwd + "\">去修改</a>";
                    HTML += "<tr><td>" + cntt.ToString() + "</td><td>" + SalesPersonId + "</td><td>" + SPName + "</td><td>" + LoginPwd + "</td><td>" +
                        LinkStrDelete + "&nbsp;&nbsp;" + LinkStrModify + "</td></tr>";
                }
            }
            reader.Close();
            conn.Close();
        }
        catch (Exception es)
        {
            Response.Write("出错了！错误信息如下：\n" + es.Message);
        }
        HTML += "</table>";
        showCashier.InnerHtml = HTML;
    }
}