using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class ReturnOrderWork : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string htmlstr = "管理员ID:" + Session["AdminId"] + " 管理员姓名:" + Session["AdminName"] + " 等级:" + (((string)Session["AdminRoleId"] == "2") ? "普通管理员" : "业务经理") + "&nbsp;<a href=\"Logout.aspx?identity=Admin\">注销</a>";
            AdminInf.InnerHtml = htmlstr;

            string SerialNum = Request.QueryString["SerialNum"];
            string ProductId = Request.QueryString["ProductId"];
            string rcnt = Request.QueryString["rcnt"];
            string rMoney = Request.QueryString["rMoney"];
            //Response.Write("流水号[" + SerialNum + "]商品编号[" + ProductId + "]数量[" + rcnt + "]总价[" + rMoney + "]");
            TextBox_SerialNum.Text = SerialNum;
            TextBox_Pid.Text = ProductId;
            int rCntInt = Convert.ToInt32(rcnt);
            for(int i=rCntInt;i>=1;--i)
            {
                DropDownList_rcnt.Items.Add(i.ToString());
            }
            DropDownList_rcnt.SelectedIndex = 0;
            TextBox_rMoney.Text = rMoney;
            
        }
    }

    protected void DropDownList_rcnt_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selCnt = Convert.ToInt32(DropDownList_rcnt.Text);
        int rCntInt = Convert.ToInt32(Request.QueryString["rcnt"]);
        decimal rMoney = Convert.ToDecimal(Request.QueryString["rMoney"]);
        decimal curMoney = rMoney * (1.0m*selCnt) / (1.0m*rCntInt);
        //Response.Write("总价为:" + rMoney.ToString() + " 现价为:" + curMoney.ToString() + " " + rCntInt.ToString() + "个退了" + selCnt + "个");
        TextBox_rMoney.Text = curMoney.ToString();
    }

    protected void Button_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReturnOrderManage.aspx");
    }

    protected void Button_Submit_Click(object sender, EventArgs e)
    {
        string _SerialNum = TextBox_SerialNum.Text;
        string _ProductId = TextBox_Pid.Text;
        string _rCnt = DropDownList_rcnt.Text;
        string _rMoney = TextBox_rMoney.Text;
        //Response.Write("流水号:" + _SerialNum + " pid:" + _ProductId + " 退货数量:" + _rCnt + " 退货金额:" + _rMoney);
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
            string str_insert = "insert into ReturnProduct(SerialNum,ProductId,rcnt,rMoney,rDate) values('{0}','{1}',{2},{3},default);";
            //Response.Write(str_insert);
            str_insert = string.Format(str_insert, _SerialNum, _ProductId, _rCnt, _rMoney);
            
            command.CommandText = str_insert;
            int f = command.ExecuteNonQuery();
            if (f != 0)
            {
                string say = "商品" + _ProductId + ",数量" + _rCnt + ",金额￥" + _rMoney +
                    "退货成功！";
                showResult.InnerHtml = say;
               // Response.Write(say);
                DropDownList_rcnt.Items.Clear();
                TextBox_Pid.Text = "";
                TextBox_rMoney.Text = "";
                //Response.Write("<a href=\"custLogin.aspx\">去登录</a><br/>");
                //show一下会员信息

            }
            else
            {
                showResult.InnerHtml = "退货失败！";
               // Response.Write("<script>alert('退货失败！')</script>");
            }
            //Response.Write("用户名或密码错误！<a href=\"login.aspx\">返回重试</a>");
            
            conn.Close();
        }
        catch (Exception es)
        {
            showResult.InnerHtml = "出现了一点儿错误，错误信息如下：\n" + es.Message;
        }
    }
}