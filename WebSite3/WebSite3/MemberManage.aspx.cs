using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions; //C#正则表达式
using System.Data.SqlClient; //SQL Server数据库

public partial class MemberManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string htmlstr = "管理员ID:" + Session["AdminId"] + " 管理员姓名:" + Session["AdminName"] + " 等级:" + (((string)Session["AdminRoleId"] == "2") ? "普通管理员" : "业务经理") + "&nbsp;<a href=\"Logout.aspx?identity=Admin\">注销</a>";
            AdminInf.InnerHtml = htmlstr;
        }
    }

    protected void Button2_Reset_Click(object sender, EventArgs e)
    {
        TextBox_MemberAddress.Text = "";
        TextBox_MemberName.Text = "";
        TextBox_MemberPhoneNumber.Text = "";
        AddResult.InnerHtml = "";
    }

    protected void Button_Add_Click(object sender, EventArgs e)
    {
        string MemberName = TextBox_MemberName.Text;
        string PhoneNumber = TextBox_MemberPhoneNumber.Text;
        string MemberAddress = TextBox_MemberAddress.Text;
        if(MemberName=="")
        {
            AddResult.InnerHtml = "会员姓名不能为空！";
            return;
        }
        if(PhoneNumber=="")
        {
            AddResult.InnerHtml = "会员手机号码不能为空！";
            return;
        }
        if(MemberAddress=="")
        {
            AddResult.InnerHtml = "会员住址不能为空！";
            return;
        }
        if(!Regex.IsMatch(PhoneNumber, @"^1[3|4|5|7|8][0-9]-\d{4}-\d{4}$"))
        {
            AddResult.InnerHtml = "手机号格式不正确或不合法";
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
            command.CommandText = "select * from  SMMembers where PhoneNumber='" + PhoneNumber + "'";
            var reader = command.ExecuteReader();
            if (!reader.HasRows) //说明这个手机号没有被人注册过，可以注册
            {
                reader.Close();
                //insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus) values('郭靖',default,'173-6299-2401','襄阳',default,default);
                string str_insert = "insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus) values('{0}',default,'{1}','{2}',default,default);";
                str_insert = string.Format(str_insert, MemberName, PhoneNumber, MemberAddress);
                command.CommandText = str_insert;
                int f = command.ExecuteNonQuery();
                if (f != 0)
                {
                    AddResult.InnerHtml = "会员[" + MemberName + "]电话:[" + PhoneNumber + "]添加成功！";
                    TextBox_MemberAddress.Text = "";
                    TextBox_MemberName.Text = "";
                    TextBox_MemberPhoneNumber.Text = "";
                }
                else
                {
                    AddResult.InnerHtml = "会员[" + MemberName + "]电话:[" + PhoneNumber + "]未成功添加！";
                }
                //Response.Write("用户名或密码错误！<a href=\"login.aspx\">返回重试</a>");
            }
            else
            {
                AddResult.InnerHtml = "手机号" + PhoneNumber + "已经被注册过了,可以使用其它手机号码注册添加会员"; 
            }
            conn.Close();
        }
        catch (Exception es)
        {
            AddResult.InnerHtml = "出现了一点儿错误，错误信息如下：\n" + es.Message;
        }
    }

    protected void Button_QueryAllMember_Click(object sender, EventArgs e)
    {
        string HTML = "<table><caption>超市会员信息表</caption><tr><th>序号</th><th>会员编号</th><th>会员姓名</th><th>积分</th><th>手机号码</th><th>住址</th><th>注册日期</th><th>失效日期</th><th>是否失效</th><th>会员状态</th><th>操作</th></tr>";
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
            command.CommandText = "select * from SMMembers;";
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                int cntt = 0;
                while (reader.Read())
                {
                    ++cntt;
                    string MemberId = reader.GetInt32(0).ToString();
                    string MemberName = reader["MemberName"].ToString();
                    string Points = reader.GetInt32(2).ToString();
                    string PhoneNumber = reader["PhoneNumber"].ToString();
                    string MemberAddress = reader["MemberAddress"].ToString();
                    DateTime opDate = new DateTime();
                    DateTime edDate = new DateTime();
                    opDate = reader.GetDateTime(5);
                    edDate = opDate.AddDays(365);
                    string OpenTime = opDate.ToString("yyyy-MM-dd");
                    string EndTime = edDate.ToString("yyyy-MM-dd");
                    string MemberStatus = reader.GetInt32(6).ToString();
                    string State = "";
                    if(MemberStatus=="1")
                    {
                        State = "正常";
                    }
                    else if(MemberStatus=="0")
                    {
                        State = "冻结中";
                    }
                    else if(MemberStatus == "-1")
                    {
                        State = "已过期";
                    }
                    string Overdue = "未过期";
                    if(DateTime.Now > edDate)
                    {
                        Overdue = "已过期";
                    }

                    string LinkStrDelete = "<a href=\"MemberDelete.aspx?MemberId=" + MemberId + "&MemberName=" + MemberName + "&Points="+ Points+ "&OpenTime="+ 
                        OpenTime+ "&EndTime=" + EndTime+ "&MemberAddress="+ MemberAddress+ "&PhoneNumber="+ PhoneNumber + "&MemberStatus="+ MemberStatus+"&Overdue="+Overdue+ "\">去删除</a>";
                    string LinkStrModify = "<a href=\"MemberModify.aspx?MemberId=" + MemberId + "&MemberName=" + MemberName + "&Points=" + Points + "&OpenTime=" + 
                        OpenTime+ "&EndTime=" + EndTime + "&MemberAddress=" + MemberAddress + "&PhoneNumber=" + PhoneNumber + "&MemberStatus=" + MemberStatus + "&Overdue=" + Overdue + "\">去修改</a>";
                    HTML += "<tr><td>" + cntt.ToString() + "</td><td>" + MemberId + "</td><td>" + MemberName + "</td><td>" + Points + "</td><td>" + PhoneNumber+
                        "</td><td>"+ MemberAddress+"</td><td>"+ OpenTime+"</td><td>"+ EndTime+"</td><td>"+Overdue+"</td><td>"+ State+"</td><td>"+
                        LinkStrDelete + "&nbsp;&nbsp;" + LinkStrModify + "</td></tr>";
                }
            }
            HTML += "</table>";
            showAllMmeber.InnerHtml = HTML;
            reader.Close();
            conn.Close();
        }
        catch (Exception es)
        {
            showAllMmeber.InnerHtml = "出错了！错误信息如下：\n" + es.Message;
        }
        
    }

    protected void Button_Clear_Click(object sender, EventArgs e)
    {
        showAllMmeber.InnerHtml = "";
    }
}