using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class custRegisterCheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string MemberName = Request.Form["MemberName"];
        string PhoneNumber = Request.Form["PhoneNumber"];
        string MemberAddress = Request.Form["MemberAddress"];
        //Response.Write("<p>" + MemberName + "</p>");
        
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
            command.CommandText = "select * from  SMMembers where PhoneNumber='" + PhoneNumber+"'";
            var reader = command.ExecuteReader();
            if (!reader.HasRows) //说明这个手机号没有被人注册过，可以注册
            {
                reader.Close();
                //insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus) values('郭靖',default,'173-6299-2401','襄阳',default,default);
                string str_insert = "insert into SMMembers(MemberName,Points,PhoneNumber,MemberAddress,OpenTime,MemberStatus) values('{0}',default,'{1}','{2}',default,default);";
                str_insert = string.Format(str_insert, MemberName, PhoneNumber, MemberAddress);
                command.CommandText = str_insert;
                int f = command.ExecuteNonQuery();
                if(f!=0)
                {
                    string say = "恭喜您，" + MemberName + "成为海之星超市的会员！";
                    Response.Write("<script>alert('会员注册成功！')</script>");
                    Response.Write(say);
                    Response.Write("<a href=\"custLogin.aspx\">去登录</a><br/>");
                    //show一下会员信息

                }
                else
                {
                    Response.Write("<script>alert('注册失败！')</script>");
                }
                //Response.Write("用户名或密码错误！<a href=\"login.aspx\">返回重试</a>");
            }
            else
            {
                string msgg = "<p>手机号"+PhoneNumber + "已经被注册过了</p>";
                Response.Write(msgg);
                Response.Write("<a href=\"custRegister.aspx\">用其它手机号码重新注册</a><br/><a href=\"custLogin.aspx\">去登录</a><br/>");
                
            }
            conn.Close();
        }
        catch (Exception es)
        {
            Response.Write("出现了一点儿错误，错误信息如下：\n"+es.Message);
        }
        
    }
}