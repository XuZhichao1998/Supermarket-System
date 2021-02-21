using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class AdminModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string htmlstr = "管理员ID:" + Session["AdminId"] + " 管理员姓名:" + Session["AdminName"] + " 等级:" + (((string)Session["AdminRoleId"] == "2") ? "普通管理员" : "业务经理") + "&nbsp;<a href=\"Logout.aspx?identity=Admin\">注销</a>";
            AdminInf.InnerHtml = htmlstr;
            TextBox_AdminId.Text = Request.QueryString["LoginId"];
            TextBox_AdminName.Text = Request.QueryString["AdminName"];
            TextBox_AdminPwd.Text = Request.QueryString["LoginPwd"];
            DropDownList_Status.Items.Add("禁用");
            DropDownList_Status.Items.Add("启用");
            DropDownList_Status.SelectedIndex = Convert.ToInt32(Request.QueryString["AdminStatus"]);
        }
    }

    protected void Button_Reset_Click(object sender, EventArgs e)
    {
        showResult.InnerHtml = "";
        TextBox_AdminPwd.Text = Request.QueryString["LoginPwd"];
        DropDownList_Status.SelectedIndex = Convert.ToInt32(Request.QueryString["AdminStatus"]);
    }

    protected void Button_Submit_Click(object sender, EventArgs e)
    {
        string AdminName = Request.QueryString["AdminName"];
        string LoginId = Request.QueryString["LoginId"];
        string PrePwd = Request.QueryString["LoginPwd"];
        string PreSt = Request.QueryString["AdminStatus"];
        string Pwd = TextBox_AdminPwd.Text;
        string State = DropDownList_Status.SelectedIndex.ToString();
        if(PrePwd==Pwd && PreSt==State)
        {
            showResult.InnerHtml = "密码和状态都没有更改，不需要更新！";
            return;
        }
        if(Pwd=="")
        {
            showResult.InnerHtml = "密码不能为空！";
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
            string str_update = "update SysAdmins set LoginPwd='" + Pwd + "',AdminStatus="+State+ " where LoginId=" + LoginId + ";";
            command.CommandText = str_update;
            int f = command.ExecuteNonQuery();
            if (f != 0)
            {
                showResult.InnerHtml = "编号为:" + LoginId + "姓名为:" + AdminName + "的管理员信息更改成功！"+"现在密码为:["+Pwd+"],状态为:"+((State=="1")?"启用":"禁用");
                TextBox_AdminId.Text = "";
                TextBox_AdminName.Text = "";
            }
            else
            {
                showResult.InnerHtml = "编号为:" + LoginId + "姓名为:" + AdminName + "的管理员信息更改失败！";

            }
            conn.Close();
        }
        catch (Exception es)
        {
            showResult.InnerHtml = "编号为:" + LoginId + "姓名为:" + AdminName + "的管理员信息更改过程中出错了！信息如下:\n" + es.Message;
        }
    }
}