using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class PurchaseManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            TextBox_Pid.Text = Request.QueryString["ProductId"];
            TextBox_Pname.Text = Request.QueryString["ProductName"];
            TextBox_SellUnitPrice.Text = Request.QueryString["UnitPrice"];
            TextBox_Unit.Text = Request.QueryString["Unit"];
            DateTime dateTime = DateTime.Now;
            string strDate = dateTime.ToString("yyyy-MM-dd");
            purchase_date.Value = strDate;
            st_date.Value = strDate;
            ed_date.Value = strDate;

            string htmlstr = "管理员ID:" + Session["AdminId"] + " 管理员姓名:" + Session["AdminName"] + " 等级:" + (((string)Session["AdminRoleId"] == "2") ? "普通管理员" : "业务经理") + "&nbsp;<a href=\"Logout.aspx?identity=Admin\">注销</a>";
            AdminInf.InnerHtml = htmlstr;
        }

      
        if (!IsPostBack)
        {
            DropDownList1.Items.Add(new ListItem("当日"));
            DropDownList1.Items.Add(new ListItem("一周内"));
            DropDownList1.Items.Add(new ListItem("一月内"));
            DropDownList1.Items.Add(new ListItem("一年内"));
            DropDownList1.Items.Add(new ListItem("自定义范围"));
        }
    }

    protected void Button_CalPrice_Click(object sender, EventArgs e)
    {
        try
        {
            string UnitPrice = TextBox_PurchasePrice.Text;
            string Cnt = TextBox_PurchaseCnt.Text;
            if (UnitPrice == "" || Cnt == "") return; //有空的，不用计算
            decimal tot = Convert.ToDecimal(UnitPrice) * Convert.ToInt32(Cnt);
            TextBox_TotalPrice.Text = tot.ToString();
        }
        catch(Exception es)
        {

        }
    }

    protected void Button_Reset_Click(object sender, EventArgs e)
    {
        TextBox_PurchaseCnt.Text = "";
        TextBox_PurchasePrice.Text = "";
        TextBox_TotalPrice.Text = "";
        DateTime dateTime = DateTime.Now;
        string strDate = dateTime.ToString("yyyy-MM-dd");
        purchase_date.Value = strDate;
        InsertResult.InnerHtml = "";
    }

    protected void Button_Submit_Click(object sender, EventArgs e)
    {
        string ProductId = ""; //货物ID
        string PurchasePrice = ""; //进货单价
        string PurchaseCnt = ""; //进货数量
        string PurchaseTotPrice = ""; //进货总价
        string PurchaseDate = ""; //进货日期
        ProductId = TextBox_Pid.Text;
        PurchasePrice = TextBox_PurchasePrice.Text;
        PurchaseCnt = TextBox_PurchaseCnt.Text;
        PurchaseTotPrice = TextBox_TotalPrice.Text;
        PurchaseDate = purchase_date.Value;
        if(PurchaseDate=="")
        {
            PurchaseDate = DateTime.Now.ToString("yyyy-MM-dd");
        }
        if(PurchaseCnt==""|| PurchasePrice==""|| PurchaseTotPrice=="")
        {
            InsertResult.InnerHtml = "进货信息不完整！";
            return;
        }
        try
        {
            int Cnt = Convert.ToInt32(PurchaseCnt);
            if(Cnt<=0)
            {
                InsertResult.InnerHtml = "进货数量必须为正整数！";
                return;
            }
            Decimal Price = Convert.ToDecimal(PurchasePrice);
            if(Price<=0)
            {
                InsertResult.InnerHtml = "进价必须为正数！";
                return;
            }
            Decimal TotP = Convert.ToDecimal(PurchaseTotPrice);
            if(TotP<=0)
            {
                InsertResult.InnerHtml = "总进价必须为正数！";
                return;
            }
        }
        catch(Exception es)
        {
            InsertResult.InnerHtml = "输入的进价或数量格式不正确！";
            return;
        }
        string MessageStr = "ID:" + ProductId+" "+Request.QueryString["ProductName"] + " 进价:" + PurchasePrice + " 数量:" + PurchaseCnt + " 总价:￥" + PurchaseTotPrice + " 日期:" + PurchaseDate;

        string str_insert = "";
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
            str_insert = "insert into Purchase(ProductId,PurchasePrice,PurchaseCnt,PurchaseTotPrice,PurchaseDate) values('{0}',{1},{2},{3},'{4}');";
            str_insert = string.Format(str_insert, ProductId, PurchasePrice, PurchaseCnt, PurchaseTotPrice, PurchaseDate);
            command.CommandText = str_insert;
            int f = command.ExecuteNonQuery();
            if (f != 0)
            {
                InsertResult.InnerHtml = MessageStr+" 进货单插入成功！";
                TextBox_PurchaseCnt.Text = "";
                TextBox_PurchasePrice.Text = "";
                TextBox_TotalPrice.Text = "";
                DateTime dateTime = DateTime.Now;
                string strDate = dateTime.ToString("yyyy-MM-dd");
                purchase_date.Value = strDate;
            }
            else
            {
                InsertResult.InnerHtml = MessageStr + " 进货单插入失败！";
            }
            conn.Close();
        }
        catch (Exception es)
        {
            InsertResult.InnerHtml = MessageStr + "插入过程中出错了！错误信息如下:\n" + es.Message;
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = DropDownList1.SelectedIndex;
        if(index==0)
        {
            st_date.Value = DateTime.Now.ToString("yyyy-MM-dd");
            ed_date.Value = DateTime.Now.ToString("yyyy-MM-dd");
        }
        else if(index==1)
        {
            st_date.Value = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
            ed_date.Value = DateTime.Now.ToString("yyyy-MM-dd");
        }
        else if(index==2)
        {
            st_date.Value = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            ed_date.Value = DateTime.Now.ToString("yyyy-MM-dd");
        }
        else if(index==3)
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
        decimal totMoney = 0;
        try
        {
            dateSt = Convert.ToDateTime(str_Stdate);
            dateEd = Convert.ToDateTime(str_Eddate);
        }
        catch(Exception es)
        {
            showDate.InnerHtml = "有异常。信息如下\n"+es.Message;
            return;
        }
        dateEd = dateEd.AddDays(1);
        str_Stdate = dateSt.ToString("yyyy-MM-dd");
        str_Eddate = dateEd.ToString("yyyy-MM-dd");
        string HTML = "<table><caption>【" + str_Stdate + "至" + str_TMP + "】期间的进货单</caption>";
        HTML += "<tr><th>序号</th><th>进货流水号</th><th>货物编号</th><th>货物名称</th><th>进货单价￥</th><th>进货数量</th><th>计量单位</th>";
        HTML += "<th>进货总金额￥</th><th>进货日期</th></tr>";
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
            string sqlStr = "select PurchaseId,tb1.ProductId,ProductName,PurchasePrice,PurchaseCnt,Unit,PurchaseTotPrice,PurchaseDate from Purchase as tb1 left join Products as tb2 on tb1.ProductId=tb2.ProductId where PurchaseDate between '{0}' and '{1}';";
            sqlStr = string.Format(sqlStr, str_Stdate, str_Eddate);
            command.CommandText = sqlStr;
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                int cntt = 0;
                while (reader.Read())
                {
                    ++cntt;
                    string PurchaseId = reader.GetInt32(0).ToString();
                    string ProductId = reader["ProductId"].ToString();
                    string ProductName = reader["ProductName"].ToString();
                    string PurchasePrice = reader.GetDecimal(3).ToString();
                    string PurchaseCnt = reader.GetInt32(4).ToString();
                    string Unit = reader["PurchaseCnt"].ToString();
                    decimal money = reader.GetDecimal(6);
                    totMoney += money;
                    string PurchaseTotPrice =money.ToString();
                    string PurchaseDate = reader.GetDateTime(7).ToString("yyyy-MM-dd");
                    HTML += "<tr><td>" + cntt.ToString() + "</td><td>" + PurchaseId + "</td><td>" + ProductId + "</td><td>" + ProductName + "</td><td>" +PurchasePrice 
                        + "</td><td>" + PurchaseCnt + "</td><td>" + Unit + "</td><td>" + PurchaseTotPrice + "</td><td>" + PurchaseDate + "</td></tr>";

                }
            }
            HTML += "</table>";
            HTML += "这段时间内进货支出的总金额为:￥" + totMoney.ToString();
            showDate.InnerHtml = HTML;
            reader.Close();
            conn.Close();
        }
        catch (Exception es)
        {
            showDate.InnerHtml = "出错了！错误信息如下：\n" + es.Message;
        }
    }
}