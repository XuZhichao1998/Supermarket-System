using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class MemberModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
            DropDownList_status.Items.Add(new ListItem("冻结"));
            DropDownList_status.Items.Add(new ListItem("正常"));
            DropDownList_status.Items.Add(new ListItem("过期失效"));
            string Status = Request.QueryString["MemberStatus"];
            int index = 0;
            if (Status == "-1") index = 2;
            else index = Convert.ToInt32(Status);
            DropDownList_status.SelectedIndex = index;
        }
    }

    protected void Button_Reset_Click(object sender, EventArgs e)
    {
        string MemberId = TextBox_id.Text;
        if(MemberId=="") //ID为空表示已经修改过了，不能再次修改。
        {
            return;
        }
        TextBox_point.Text = Request.QueryString["Points"];
        string Status = Request.QueryString["MemberStatus"];
        int index = 0;
        if (Status == "-1") index = 2;
        else index = Convert.ToInt32(Status);
        DropDownList_status.SelectedIndex = index;
        TextBox_address.Text = Request.QueryString["MemberAddress"];

    }

    protected void Button_Submit_Click(object sender, EventArgs e)
    {
        string Points = TextBox_point.Text;
        string MemberAddress = TextBox_address.Text;
        string MemberStatus = DropDownList_status.SelectedIndex.ToString();
        string MemberId = TextBox_id.Text;
        if (MemberId == "") //说明已经修改成功了，不能再改了
        {
            return;
        }
        if(MemberStatus=="2")
        {
            MemberStatus = "-1";
        }
        if(Points=="")
        {
            showResult.InnerHtml = "积分不能为空！";
            return;
        }
        if(MemberAddress=="")
        {
            showResult.InnerHtml = "地址不能为空！";
            return;
        }
        if(Points==Request.QueryString["Points"] && MemberAddress==Request.QueryString["MemberAddress"] && MemberStatus== Request.QueryString["MemberStatus"])
        {
            showResult.InnerHtml = "会员地址，积分，状态都没有改变，不需要更新！";
            return;
        }
        int PointInt = 0;
        try
        {
            PointInt = Convert.ToInt32(Points);
            if(PointInt<0)
            {
                showResult.InnerHtml = "积分必须为非负整数！";
                return;
            }
        }
        catch(Exception es)
        {
            showResult.InnerHtml = "输入的积分不是合法的数字！(" + es.Message;
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
            string str_update = "update SMMembers set Points=100,MemberAddress='{0}',MemberStatus={1} where MemberId={2};";
            str_update = string.Format(str_update, MemberAddress, MemberStatus, MemberId);
            command.CommandText = str_update;
            int f = command.ExecuteNonQuery();
            if (f != 0)
            {
                showResult.InnerHtml = "会员号为[" + MemberId + "],姓名为[" + Request.QueryString["MemberName"] + "]的会员账号信息修改成功！"+
                    "现在的积分为"+TextBox_point.Text+"分，地址为:"+TextBox_address.Text+",状态为:"+DropDownList_status.Text+"。\n"+"请点击链接返回会员管理页面";
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
                showResult.InnerHtml = "会员号为[" + MemberId + "],姓名为[" + Request.QueryString["MemberName"] + "]的会员信息修改失败！";
            }
            conn.Close();
        }
        catch (Exception es)
        {
            showResult.InnerHtml = "会员号为[" + MemberId + "],姓名为[" + Request.QueryString["MemberName"] + "]的会员账号信息修改过程中出现了一点儿错误，错误信息如下：\n" + es.Message;
        }
    }
}