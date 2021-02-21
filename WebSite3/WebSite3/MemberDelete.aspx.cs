using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class MemberDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string htmlstr = "管理员ID:" + Session["AdminId"] + " 管理员姓名:" + Session["AdminName"] + " 等级:" + (((string)Session["AdminRoleId"] == "2") ? "普通管理员" : "业务经理") + "&nbsp;<a href=\"Logout.aspx?identity=Admin\">注销</a>";
            AdminInf.InnerHtml = htmlstr;
            TextBox_id.Text = Request.QueryString["MemberId"];
            TextBox_name.Text = Request.QueryString["MemberName"];
            TextBox_point.Text = Request.QueryString["Points"];
            TextBox_phone.Text = Request.QueryString["PhoneNumber"];
            TextBox_address.Text = Request.QueryString["MemberAddress"];
            TextBox_opentime.Text = Request.QueryString["Opentime"];
            TextBox_edtime.Text = Request.QueryString["Endtime"];
            TextBox_overdue.Text = Request.QueryString["Overdue"];
        }
    }

    protected void Button_Submit_Click(object sender, EventArgs e)
    {
        string MemberId = TextBox_id.Text;
        if(MemberId=="")
        {
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
            string str_delete = "delete from SMMembers where MemberId="+MemberId+";";
            command.CommandText = str_delete;
            int f = command.ExecuteNonQuery();
            if (f != 0)
            {
                showResult.InnerHtml = "会员号为[" + MemberId + "],姓名为[" + Request.QueryString["MemberName"] + "]的会员账号删除成功！请点击链接返回会员管理页面";
                TextBox_id.Text = "";
                TextBox_name.Text = "";
                TextBox_point.Text = "";
                TextBox_phone.Text = "";
                TextBox_address.Text = "";
                TextBox_opentime.Text = "";
                TextBox_edtime.Text = "";
                TextBox_overdue.Text = "";
            }
            else
            {
                showResult.InnerHtml = "会员号为[" + MemberId + "],姓名为[" + Request.QueryString["MemberName"] + "]的会员账号删除失败！";
            }
            conn.Close();
        }
        catch (Exception es)
        {
            showResult.InnerHtml = "会员号为[" + MemberId + "],姓名为[" + Request.QueryString["MemberName"] + "]的会员账号删除过程中出现了一点儿错误，错误信息如下：\n" + es.Message;
        }

    }
}