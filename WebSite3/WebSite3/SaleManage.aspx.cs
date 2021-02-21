using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class SaleManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string htmlstr = "管理员ID:" + Session["AdminId"] + " 管理员姓名:" + Session["AdminName"] + " 等级:" + (((string)Session["AdminRoleId"] == "2") ? "普通管理员" : "业务经理") + "&nbsp;<a href=\"Logout.aspx?identity=Admin\">注销</a>";
            AdminInf.InnerHtml = htmlstr;

            DropDownList_Option.Items.Add("当天");
            DropDownList_Option.Items.Add("一周内");
            DropDownList_Option.Items.Add("一个月内");
            DropDownList_Option.Items.Add("自定义");
            string strDate = DateTime.Now.ToString("yyyy-MM-dd");
            st_date.Value = strDate;
            ed_date.Value = strDate;
        }
    }

    protected void Button_Reset_Click(object sender, EventArgs e)
    {
        DropDownList_Option.SelectedIndex = 0;
        string strDate = DateTime.Now.ToString("yyyy-MM-dd");
        st_date.Value = strDate;
        ed_date.Value = strDate;
        showResult.InnerHtml = "";
    }

    protected void DropDownList_Option_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = DropDownList_Option.SelectedIndex;
        if (index == 0)
        {
            st_date.Value = DateTime.Now.ToString("yyyy-MM-dd");
            ed_date.Value = DateTime.Now.ToString("yyyy-MM-dd");
        }
        else if (index == 1)
        {
            st_date.Value = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            ed_date.Value = DateTime.Now.ToString("yyyy-MM-dd");
        }
        else if (index == 2)
        {
            st_date.Value = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            ed_date.Value = DateTime.Now.ToString("yyyy-MM-dd");
        }
        else if (index == 3)
        {
            st_date.Value = DateTime.Now.AddDays(-365).ToString("yyyy-MM-dd");
            ed_date.Value = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }

    protected void Button_Query_Click(object sender, EventArgs e)
    {
        string str_Stdate = st_date.Value;
        string str_Eddate = ed_date.Value;
        string str_TMP = str_Eddate;
        DateTime dateSt = new DateTime();
        DateTime dateEd = new DateTime();
        dateSt = DateTime.Now;
        dateEd = DateTime.Now;
        try
        {
            dateSt = Convert.ToDateTime(str_Stdate);
            dateEd = Convert.ToDateTime(str_Eddate);
        }
        catch (Exception es)
        {
            showResult.InnerHtml = "有异常。信息如下\n" + es.Message;
            return;
        }
        dateEd = dateEd.AddDays(1);
        str_Stdate = dateSt.ToString("yyyy-MM-dd");
        str_Eddate = dateEd.ToString("yyyy-MM-dd");
        string HTML = "<table><caption>【" + str_Stdate + "至" + str_TMP + "】期间的销售流水表</caption>";
        HTML += "<tr><th>序号</th><th>销售流水号</th><th>销售总金额￥</th><th>收银员编号</th><th>销售时间</th></tr>";
        Decimal totMoney = 0;
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
            string sqlStr = "select * from SalesList where SaleDate between '{0}' and '{1}';";
            sqlStr = string.Format(sqlStr, str_Stdate, str_Eddate);
            command.CommandText = sqlStr;
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                int cntt = 0;
                while (reader.Read())
                {
                    ++cntt;
                    string SerialNum = reader["SerialNum"].ToString();
                    decimal money = reader.GetDecimal(1);
                    totMoney += money;
                    string TotalMoney = money.ToString();
                    string SalesPersonId = reader.GetInt32(4).ToString();
                    string SaleDate = reader.GetDateTime(5).ToString();
                    HTML += "<tr><td>" + cntt.ToString() + "</td><td>" + SerialNum + "</td><td>" + TotalMoney + "</td><td>" + SalesPersonId + "</td><td>" + SaleDate + "</td></tr>";
                }
            }
            HTML += "</table>";
            HTML += "销售总金额为:￥" + totMoney.ToString();
            showResult.InnerHtml = HTML;
            reader.Close();
            conn.Close();
        }
        catch (Exception es)
        {
            showResult.InnerHtml = "出错了！错误信息如下：\n" + es.Message;
        }
    }
}