using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class AdminManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string htmlstr = "管理员ID:" + Session["AdminId"] + " 管理员姓名:" + Session["AdminName"] + " 等级:" + (((string)Session["AdminRoleId"] == "2") ? "普通管理员" : "业务经理") + "&nbsp;<a href=\"Logout.aspx?identity=Admin\">注销</a>";
        AdminInf.InnerHtml = htmlstr;
    }

    protected void Button_Reset_Click(object sender, EventArgs e)
    {
        TextBox_AdminName.Text = "";
        TextBox_AdminPwd.Text = "";
        showInsert.InnerHtml = "";
    }

    protected void Button_Add_Click(object sender, EventArgs e)
    {
        string AdminName = TextBox_AdminName.Text;
        string LoginPwd = TextBox_AdminPwd.Text;
        if(AdminName==""||LoginPwd=="")
        {
            showInsert.InnerHtml = "管理员姓名和密码都不能为空！";
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
            string str_insert = "insert into SysAdmins(LoginPwd,AdminName,AdminStatus,RoleId) values('{0}','{1}',1,2);";
            str_insert = string.Format(str_insert, LoginPwd, AdminName);
            command.CommandText = str_insert;
            int f = command.ExecuteNonQuery();
            if (f != 0)
            {
                showInsert.InnerHtml = "普通管理员[" + AdminName + "],密码[" + LoginPwd + "]添加成功！";
                TextBox_AdminName.Text = "";
                TextBox_AdminPwd.Text = "";
            }
            else
            {
                showInsert.InnerHtml = "普通管理员[" + AdminName + "],密码[" + LoginPwd + "]添加失败！";
            }
            conn.Close();
        }
        catch (Exception es)
        {
            showInsert.InnerHtml = "普通管理员[" + AdminName + "],密码[" + LoginPwd  + "]添加过程中出错了。错误信息如下:\n" + es.Message;
        }
    }

    protected void Button_ShowAllAdmin_Click(object sender, EventArgs e)
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
            command.CommandText = "select * from SysAdmins where RoleId=2";
            string HTML = "<table><caption>" + "普通管理员表" + "</caption><tr><th>管理员编号</th><th>管理员姓名</th><th>管理员密码</th><th>管理员状态</th><th>操作</th></tr>";
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string LoginId = reader.GetInt32(0).ToString();
                    string AdminName = reader["AdminName"].ToString();
                    string LoginPwd = reader["LoginPwd"].ToString();
                    bool st = reader.GetBoolean(3);
                    int stt = st ? 1 : 0;
                    string AdminStatus = st ? "启用" : "禁用";
                    string LinkStr = "<a href=\"AdminModify.aspx?LoginId=" + LoginId + "&AdminName=" + AdminName + "&LoginPwd=" + LoginPwd + "&AdminStatus=" + stt.ToString() + "\">去修改<a>";
                    HTML += "<tr><td>" + LoginId + "</td><td>" + AdminName + "</td><td>" + LoginPwd + "</td><td>" + AdminStatus +"</td><td>"+ LinkStr+ "</td></tr>";
                }
            }
            HTML += "</table>";
            showQuery.InnerHtml = HTML;
            reader.Close();
            conn.Close();
        }
        catch (Exception es)
        {
            showQuery.InnerHtml = "出错了！错误信息如下：\n" + es.Message;
        }
    }

    protected void Button_Clear_Click(object sender, EventArgs e)
    {
        showQuery.InnerHtml = "";
    }
}