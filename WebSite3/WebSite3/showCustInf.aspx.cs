using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class showCustInf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
                Session["curLastTime"] = OpenTime.ToString("D");
                Session["curMemberId"] = MemberId;
                Session["curMemberAddress"] = MemberAddress;
                Session["curOpenTime"] = strOpenTime;
         */
        string HTML = "<table border=\"1px\">\n<tr><th>会员姓名：</th><td>" + Session["curMemberName"] + "</td></tr>\n";
        HTML += "<tr><th>会员卡号：</th><td>"+ Session["curMemberId"]+ "</td></tr>\n";
        HTML += "<tr><th>联系电话：</th><td>" + Session["curPhoneNumber"] + "</td></tr>\n";
        HTML += "<tr><th>家庭住址：</th><td>" + Session["curMemberAddress"] + "</td></tr>\n";
        HTML += "<tr><th>开卡日期：</th><td>" + Session["curOpenTime"] + "</td></tr>\n";
        HTML += "<tr><th>失效日期：</th><td>" + Session["curLastTime"] + "</td></tr>\n";
        HTML += "<tr><th>购物积分：</th><td>" + Session["curPoints"] + "</td></tr>\n</table>\n";
        inf.InnerHtml = HTML;
    }
}