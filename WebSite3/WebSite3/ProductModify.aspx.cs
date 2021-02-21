using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class ProductModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string htmlstr = "管理员ID:" + Session["AdminId"] + " 管理员姓名:" + Session["AdminName"] + " 等级:" + (((string)Session["AdminRoleId"] == "2") ? "普通管理员" : "业务经理") + "&nbsp;<a href=\"Logout.aspx?identity=Admin\">注销</a>";
            AdminInf.InnerHtml = htmlstr;
            for (int i=10;i>=1;--i)
            {
                DropDownList_Discount.Items.Add(i.ToString());
            }
            string ProductId = Request.QueryString["ProductId"];
            string ProductName = Request.QueryString["ProductName"];
            string UnitPrice = Request.QueryString["UnitPrice"];
            int Discount = 10-Convert.ToInt32(Request.QueryString["Discount"]);
            if(Discount<0)
            {
                Discount = 0;
            }
            if(Discount>9)
            {
                Discount = 9;
            }
            TextBox_Pid.Text = ProductId;
            TextBox_Pname.Text = ProductName;
            TextBox_UnitPrice.Text = UnitPrice;
            TextBox_Unit.Text = Request.QueryString["Unit"];
            DropDownList_Discount.SelectedIndex = Discount;
        }
    }

    protected void Button_Reset_Click(object sender, EventArgs e)
    {
        TextBox_UnitPrice.Text = Request.QueryString["UnitPrice"];
        int Discount = 10-Convert.ToInt32(Request.QueryString["Discount"]);
        if(Discount<0)
        {
            Discount = 0;
        }
        if(Discount>9)
        {
            Discount = 9;
        }
        DropDownList_Discount.SelectedIndex = Discount;
        InsertResult.InnerHtml = "";
    }

    protected void Button_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProductManage.aspx");
    }

    protected void Button_Submit_Click(object sender, EventArgs e)
    {
        string ProductId = TextBox_Pid.Text;
        string Discount = DropDownList_Discount.Text;
        string UnitPrice = TextBox_UnitPrice.Text;
        string ProductName = Request.QueryString["ProductName"];
        if (UnitPrice== Request.QueryString["UnitPrice"] && Discount== Request.QueryString["Discount"])
        {
            InsertResult.InnerHtml = "商品"+Request.QueryString["ProductName"]+"的价格和折扣都没有改变，不需要更新！";
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
            string str_insert = "update Products set UnitPrice={0},Discount={1} where ProductId='{2}';";
            str_insert = string.Format(str_insert, UnitPrice, Discount,ProductId);
            command.CommandText = str_insert;
            int f = command.ExecuteNonQuery();
            if (f != 0)
            {
                InsertResult.InnerHtml = "商品" + ProductName + "Id为["+ProductId+"]信息修改成功！单价为:￥" + UnitPrice + ",折扣为" + Discount + "折。请点击按钮返回商品管理";
                TextBox_Pid.Text = "";
                TextBox_Pname.Text = "";
            }
            else
            {
                InsertResult.InnerHtml = "没有商品被修改";
            }
            conn.Close();
        }
        catch (Exception es)
        {
            InsertResult.InnerHtml = "出现了错误，错误信息如下：\n" + es.Message;
        }
    }
}