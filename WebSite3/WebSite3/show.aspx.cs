using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class show : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if((string)Session["AdminRoleId"]=="1")
        {
            string MangmangHtml = "<a href=\"AdminManage.aspx\" >权限管理</a>";
            id_ManageManage.InnerHtml = MangmangHtml;
        }
        string htmlstr = "管理员ID:" + Session["AdminId"] + " 管理员姓名:" + Session["AdminName"] + " 等级:" + (((string)Session["AdminRoleId"] == "2") ? "普通管理员" : "业务经理")+"&nbsp;<a href=\"Logout.aspx?identity=Admin\">注销</a>";
        AdminInf.InnerHtml = htmlstr;
        string visNumInf = "本网站当前有<b>" + Application["OnLine"].ToString() + "</b>位在线访问者&nbsp;&nbsp;" ;
        visNumInf += "累计访问量为：" + Application["TotalCount"].ToString();
        visiter.InnerHtml = visNumInf;
    }
}