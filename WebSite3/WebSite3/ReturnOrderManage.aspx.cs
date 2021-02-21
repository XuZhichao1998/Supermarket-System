using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class ReturnOrderManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            //显示管理员信息
            string htmlstr = "管理员ID:" + Session["AdminId"] + " 管理员姓名:" + Session["AdminName"] + " 等级:" + (((string)Session["AdminRoleId"] == "2") ? "普通管理员" : "业务经理") + "&nbsp;<a href=\"Logout.aspx?identity=Admin\">注销</a>";
            AdminInf.InnerHtml = htmlstr;

            string NowDate = DateTime.Now.Date.AddDays(1).ToShortDateString();
            string PreDate = DateTime.Now.Date.AddDays(-7).ToShortDateString();


            //查询7天内的所有订单号，加入到下拉框中
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
                command.CommandText = "select SerialNum from SalesList where SaleDate between '" + PreDate + "' and '" + NowDate + "';";
                var reader = command.ExecuteReader();
               // List<Products> productsList = new List<Products>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string serialNum = reader["SerialNum"].ToString();
                        DropDownList_SerialNum.Items.Add(serialNum);
                    }
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception es)
            {
                Response.Write("出错了！错误信息如下：\n" + es.Message);
            }

            DropDownList_Option.Items.Add("当天");
            DropDownList_Option.Items.Add("一周内");
            DropDownList_Option.Items.Add("一个月内");
            DropDownList_Option.Items.Add("一年内");
            DropDownList_Option.Items.Add("自定义");
           
            string strDate = DateTime.Now.ToString("yyyy-MM-dd");
            st_date.Value = strDate;
            ed_date.Value = strDate;


        }
       
    }

    protected void Button_Query_Click(object sender, EventArgs e)
    {
        string strSerialNum = DropDownList_SerialNum.Text;
        string HTML = "";
        //查询该订单相关的流水明细
        try
        {
            HTML = "<table><tr><th>流水明细号</th><th>流水号</th><th>商品编号</th><th>商品名称</th><th>单价</th><th>折扣</th><th>数量</th><th>小计</th><th>操作</th></tr>";
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
            command.CommandText = "select * from SalesListDetail where SerialNum = '"+ strSerialNum+"';";
            var reader = command.ExecuteReader();
            // List<Products> productsList = new List<Products>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string Id = reader.GetInt32(0).ToString();
                    string serialNum = reader["SerialNum"].ToString();
                    string ProductId = reader["ProductId"].ToString();
                    string ProductName = reader["ProductName"].ToString();
                    string UnitPrice = reader.GetDecimal(4).ToString();
                    string Discount = reader.GetInt32(5).ToString();
                    string Quantity = reader.GetInt32(6).ToString();
                    string SubTotalMoney = reader.GetDecimal(7).ToString();
                    string strLink = "<a href=\"ReturnOrderWork.aspx?ProductId="+ProductId+"&SerialNum="+ serialNum + "&rcnt="+
                        Quantity+"&rMoney="+SubTotalMoney+"\" >去退款</a>";
                    HTML += "<tr><td>" + Id + "</td><td>" + serialNum + "</td><td>" + ProductId + "</td><td>" + ProductName
                        + "</td><td>" + UnitPrice + "</td><td>" + Discount + "</td><td>" + Quantity + "</td><td>" + SubTotalMoney
                        +"</td><td>"+ strLink + "</td></tr>";
                        
                }
            }
            HTML += "</table>";
            reader.Close();
            conn.Close();
        }
        catch (Exception es)
        {
            Response.Write("出错了！错误信息如下：\n" + es.Message);
        }
        queryResultId.InnerHtml = HTML;
    }

    protected void Button_showReturnOrderSevenDays_Click(object sender, EventArgs e)
    {
        string HTMLstr = "";
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
            command.CommandText = "select * from ReturnProduct";
            var reader = command.ExecuteReader();
            HTMLstr = "<table><caption>7天内的退货信息表</caption>\n<tr><th>退货流水号</th><th>销售流水号</th><th>货物编号</th><th>退货数量</th><th>退货金额￥</th><th>退货日期</th></tr>";
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string Rid = reader["ReturnProductId"].ToString();
                    string SNum = reader["SerialNum"].ToString();
                    string Pid = reader["ProductId"].ToString();
                    string Rcnt = reader.GetInt32(3).ToString();
                    string RMondy = reader.GetDecimal(4).ToString();
                    string RDate = reader.GetDateTime(5).ToString("d");
                    HTMLstr += "<tr><td>"+Rid+"</td><td>"+SNum+"</td><td>"+Pid+"</td><td>"+Rcnt+"</td><td>"+RMondy+"</td><td>"+RDate+"</td></tr>";
                }
            }
            HTMLstr += "</table>";
            reader.Close();
            conn.Close();
        }
        catch (Exception es)
        {
            Response.Write("出错了！错误信息如下：\n" + es.Message);
        }
        showReturnOrderSevenDays.InnerHtml = HTMLstr;
    }

    protected void Button_ClearShowReturnOrderSeven_Click(object sender, EventArgs e)
    {
        showReturnOrderSevenDays.InnerHtml = "";
        DropDownList_Option.SelectedIndex = 0;
        string strDate = DateTime.Now.ToString("yyyy-MM-dd");
        st_date.Value = strDate;
        ed_date.Value = strDate;
    }

    protected void Button_BacktoShow_Click(object sender, EventArgs e)
    {
        Response.Redirect("show.aspx");
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

    protected void Button_Submit_Click(object sender, EventArgs e)
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
        catch (Exception es)
        {
            showReturnOrderSevenDays.InnerHtml = "有异常。信息如下\n" + es.Message;
            return;
        }
        dateEd = dateEd.AddDays(1);
        str_Stdate = dateSt.ToString("yyyy-MM-dd");
        str_Eddate = dateEd.ToString("yyyy-MM-dd");
        string HTMLstr = "";
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
            command.CommandText = "select * from ReturnProduct where rDate between '"+str_Stdate+"' and '"+str_Eddate+"';";
            var reader = command.ExecuteReader();
            HTMLstr = "<table><caption>【"+str_Stdate+"至"+str_TMP+"】的退货表</caption>\n<tr><th>退货流水号</th><th>销售流水号</th><th>货物编号</th><th>退货数量</th><th>退货金额￥</th><th>退货日期</th></tr>";
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string Rid = reader["ReturnProductId"].ToString();
                    string SNum = reader["SerialNum"].ToString();
                    string Pid = reader["ProductId"].ToString();
                    string Rcnt = reader.GetInt32(3).ToString();
                    decimal money = reader.GetDecimal(4);
                    totMoney += money;
                    string RMondy = money.ToString();
                    string RDate = reader.GetDateTime(5).ToString("d");
                    HTMLstr += "<tr><td>" + Rid + "</td><td>" + SNum + "</td><td>" + Pid + "</td><td>" + Rcnt + "</td><td>" + RMondy + "</td><td>" + RDate + "</td></tr>";
                }
            }
            HTMLstr += "</table>";
            HTMLstr += "在此期间的退货总金额为:￥" + totMoney.ToString();
            reader.Close();
            conn.Close();
        }
        catch (Exception es)
        {
            Response.Write("出错了！错误信息如下：\n" + es.Message);
        }
        showReturnOrderSevenDays.InnerHtml = HTMLstr;
    }
}