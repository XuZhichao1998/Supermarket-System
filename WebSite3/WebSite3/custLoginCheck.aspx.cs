using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class custLoginCheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string MemberName = Request.Form["custLoginName"];
        string PhoneNumber = Request.Form["custLoginPhoneNum"];
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
            command.CommandText = "select * from  SMMembers where MemberName='" + MemberName + "' and PhoneNumber='" + PhoneNumber + "'";
            var reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                Response.Write("用户名或密码错误！<a href=\"custLogin.aspx\">返回重试</a>");
            }
            else
            {
                Session["curMemberName"] = MemberName;
                Session["curPhoneNumber"] = PhoneNumber;
                string MemberId = "";
                string MemberAddress = "";
                string strOpenTime = "";
                DateTime OpenTime = DateTime.Now;
                string Points = "";
                while (reader.Read())
                {
                    MemberId = reader.GetInt32(0).ToString().Trim();
                    MemberAddress = reader["MemberAddress"].ToString().Trim();
                    OpenTime = reader.GetDateTime(5);
                    strOpenTime = OpenTime.ToString("D");
                    Points = reader.GetInt32(2).ToString();
                }
                DateTime LastTime = OpenTime.AddYears(1);
                Session["curLastTime"] = LastTime.ToString("D");
                Session["curMemberId"] = MemberId;
                Session["curMemberAddress"] = MemberAddress;
                Session["curOpenTime"] = strOpenTime;
                Session["curPoints"] = Points;
                Response.Redirect("showCustInf.aspx");
            }
            reader.Close();
            conn.Close();
        }
        catch (Exception es)
        {
            Response.Write("除了一些错误，信息如下：\n" + es.Message);
        }

    }
}