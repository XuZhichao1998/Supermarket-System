using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class ProductManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string htmlstr = "管理员ID:" + Session["AdminId"] + " 管理员姓名:" + Session["AdminName"] + " 等级:" + (((string)Session["AdminRoleId"] == "2") ? "普通管理员" : "业务经理") + "&nbsp;<a href=\"Logout.aspx?identity=Admin\">注销</a>";
            AdminInf.InnerHtml = htmlstr;
            //为折扣下拉框添加折扣选项
            for (int i=10;i>=1;--i)
            {
                DropDownList_Discount.Items.Add(i.ToString());
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
                command.CommandText = "select Unit from ProductUnit;";
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DropDownList_Unit.Items.Add(reader["Unit"].ToString());
                    }
                }
                reader.Close();
                command.CommandText = "select CategoryName from ProductCategory;";
                var reader2 = command.ExecuteReader();
                if(reader2.HasRows)
                {
                    while(reader2.Read())
                    {
                        DropDownList_PCategory.Items.Add(reader2["CategoryName"].ToString());
                    }
                }
                reader2.Close();
                conn.Close();
            }
            catch (Exception es)
            {
                Response.Write("出错了！错误信息如下：\n" + es.Message);
            }
        }
    }

    protected void AddProduct_Click(object sender, EventArgs e)
    {
        string ProductId = TextBox_Pid.Text;
        string ProductName = TextBox_Pname.Text;
        string UnitPrice = TextBox_UnitPrice.Text;
        if (ProductId == "" || ProductName == "" || UnitPrice == "")
        { //输入为空则不执行
            return;
        }
        string Unit = DropDownList_Unit.Text;
        string Discount = DropDownList_Discount.Text;
        string CategoryId = (DropDownList_PCategory.SelectedIndex + 1).ToString();
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
            string str_insert = "insert into Products(ProductId,ProductName,UnitPrice,Unit,Discount,categoryId) values('{0}','{1}',{2},'{3}',{4},{5});";
            str_insert = string.Format(str_insert, ProductId, ProductName, UnitPrice,Unit,Discount,CategoryId);
            command.CommandText = str_insert;
            int f = command.ExecuteNonQuery();
            if (f != 0)
            {
                showInsertResult.InnerHtml = "商品[" + ProductName + "]编号为[" + ProductId + "]插入成功！";
            }
            else
            {
                showInsertResult.InnerHtml = "商品[" + ProductName + "]编号为[" + ProductId + "]插入失败！";
            }
            conn.Close();
        }
        catch (Exception es)
        {
            showInsertResult.InnerHtml = "商品[" + ProductName + "]编号为[" + ProductId + "]插入过程中出错了！错误信息如下:\n"+es.Message;
        }
    }

    protected void Button_Reset_Click(object sender, EventArgs e)
    {
        TextBox_Pid.Text = "";
        TextBox_Pname.Text = "";
        TextBox_UnitPrice.Text = "";
        DropDownList_Discount.SelectedIndex = 0;
        DropDownList_PCategory.SelectedIndex = 0;
        DropDownList_PCategory.SelectedIndex = 0;
        showInsertResult.InnerHtml = "";
    }

    protected void Button_QueryClear_Click(object sender, EventArgs e)
    {
        showAllProduct.InnerHtml = "";
    }

    protected void Button_QueryAllProduct_Click(object sender, EventArgs e)
    {
        string HTML = "";
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
            command.CommandText = "select * from Products";
            var reader = command.ExecuteReader();
            int cntt = 0;
            HTML = "<table><tr><th>序号</th><th>商品编号</th><th>商品名称</th><th>商品单价</th><th>计量单位</th><th>折扣</th><th>操作</th></tr>";
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string ProductId = reader["ProductId"].ToString();
                    string ProductName = reader["ProductName"].ToString();
                    string UnitPrice = reader.GetDecimal(2).ToString();
                    string Unit = reader["Unit"].ToString();
                    string Discount = reader.GetInt32(4).ToString();
                    string CategoryId = reader.GetInt32(5).ToString();
                    cntt += 1;
                    string Linkstr = "<a href=\"ProductModify.aspx?ProductId="+ProductId+ "&ProductName="+ProductName+ "&UnitPrice="
                        +UnitPrice+ "&Discount="+Discount+ "\">修改</a>";
                    HTML += "<tr><td>" + cntt.ToString() + "</td><td>" + ProductId + "</td><td>" + ProductName + "</td><td>"+UnitPrice+
                        "</td><td>"+Unit+"</td><td>"+Discount+"</td><td>"+Linkstr+"</td></tr>";
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



        showAllProduct.InnerHtml = HTML;
    }
}