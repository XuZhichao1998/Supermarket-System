using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class InventoryManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string htmlstr = "管理员ID:" + Session["AdminId"] + " 管理员姓名:" + Session["AdminName"] + " 等级:" + (((string)Session["AdminRoleId"] == "2") ? "普通管理员" : "业务经理") + "&nbsp;<a href=\"Logout.aspx?identity=Admin\">注销</a>";
        AdminInf.InnerHtml = htmlstr;


    }

    protected void Button_ShowAll_Click(object sender, EventArgs e)
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
            HTML = "<table><tr><th>序号</th><th>商品编号</th><th>商品名称</th><th>库存总量</th><th>最小库存量</th><th>最大库存量</th><th>库存状态</th><th>操作</th></tr>";
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "select tb1.ProductId,ProductName,TotalCount,MinCount,MaxCount,UnitPrice,Discount,Unit from ProductInventory as tb1,Products as tb2 where tb1.ProductId=tb2.ProductId;";
            var reader = command.ExecuteReader();
            int cntt = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cntt += 1;
                    string ProductId = reader["ProductId"].ToString();
                    string ProductName = reader["ProductName"].ToString();
                    int TotalCount = reader.GetInt32(2);
                    int MinCount = reader.GetInt32(3);
                    int MaxCount = reader.GetInt32(4);
                    string UnitPrice = reader.GetDecimal(5).ToString();
                    string Discount = reader.GetInt32(6).ToString();
                    string Unit = reader["Unit"].ToString();
                    string Status = "";
                    if(TotalCount<MinCount)
                    {
                        Status = "过少";
                    }
                    else if(TotalCount>MaxCount)
                    {
                        Status = "过多";
                    }
                    else
                    {
                        Status = "正常";
                    }
                    string Linkstr = "<a href=\"ProductModify.aspx?ProductId=" + ProductId + "&ProductName=" + ProductName + "&UnitPrice="
                        + UnitPrice + "&Discount=" + Discount +"&Unit="+Unit+ "\">修改价格</a>";
                    string Linkstr2 = "<a href=\"PurchaseManage.aspx?ProductId=" + ProductId + "&ProductName=" + ProductName+"&UnitPrice="+UnitPrice +"&Unit="+Unit+ "\">去进货</a>";
                    HTML += "<tr><td>" + cntt.ToString() + "</td><td>" + ProductId + "</td><td>" + ProductName + "</td><td>" + TotalCount.ToString() + "</td><td>" +
                        MinCount.ToString() + "</td><td>" + MaxCount.ToString() + "</td><td>" + Status + "</td><td>" + Linkstr+"&nbsp;&nbsp;"+Linkstr2 + "</td></tr>";
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
        showInventory.InnerHtml = HTML;
    }
}