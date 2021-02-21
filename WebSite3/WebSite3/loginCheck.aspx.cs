using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class loginCheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = Request.Form["username"];
        string pwd = Request.Form["userpassword"];
        try { 
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
            command.CommandText = "select * from  SysAdmins where AdminName='" +username+ "' and LoginPwd='"+pwd+"'";
            var reader = command.ExecuteReader();
            string LoginId = "";
            bool AdminStatus = true;
            string RoleId = "";

            //Response.Write("alert(reader)");
            if (!reader.HasRows)
            {
                Response.Write("用户名或密码错误！<a href=\"login.aspx\">返回重试</a>");
            }
            else
            {
                while (reader.Read())
                {
                    LoginId = reader.GetInt32(0).ToString();
                    AdminStatus = reader.GetBoolean(3);
                    RoleId = reader.GetInt32(4).ToString().Trim();
                    //Response.Write("LoginId" + LoginId + " 状态:"+AdminStatus.ToString()+" RoleId:"+RoleId);
                    
                }
                if(!AdminStatus)
                {
                    Response.Write("管理员"+username+"暂未启用。请联系经理授权或者使用其它管理员账号登录"+"<a href=\"login.aspx\">返回登录</a>");
                }
                Session["AdminName"] = username;
                Session["AdminId"] = LoginId;
                Session["AdminStatus"] = AdminStatus;
                Session["AdminRoleId"] = RoleId;
                if(AdminStatus)
                {
                    Response.Redirect("show.aspx");
                }
                    
            }
            conn.Close();
            reader.Close();
        }
        catch(Exception es)
        {
            Response.Write("除了一些错误，信息如下：\n"+es.Message);
        }
       
       
    }
}