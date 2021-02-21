using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;

public partial class cashierWork : System.Web.UI.Page
{
    static Hashtable htProidToItem = new Hashtable();
    static Hashtable htProidToCnt = new Hashtable();
    static List<SalesListDetail> saleslist = new List<SalesListDetail>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            TextBox_Cur_TotMoney.Text = "0";
        }
        //-------------------显示收银员姓名和ID
        string curSalesPersonId = Session["curSalesPersonId"].ToString().Trim();
        string curSPName = Session["curSPName"].ToString().Trim();
        string HTML = "收银员ID:" + curSalesPersonId + "&nbsp;收银员姓名:" + curSPName+"&nbsp;<a href=\"Logout.aspx?identity=Cashier\">注销</a>";
        SPInf.InnerHtml = HTML;
        //if (!IsPostBack)
        // {
        //--------------------------------------
        if (!IsPostBack)
        {
            for (int i = 1; i <= 10; ++i)
                DropDownList_num.Items.Add(new ListItem(i.ToString()));
            DropDownList_MemId.Items.Add(new ListItem("非会员"));
        }
        //--------------------------------------

        if(!IsPostBack)
        {
            //-----注销过期的会员------------------------------------------------------------
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
                command.CommandText = "delete from SMMembers where DATEDIFF(day,OpenTime,getDate())>365;";
                int f = command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception es)
            {
                Response.Write("出现了一点儿错误，错误信息如下：\n" + es.Message);
            }
            //--------------------------------------
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
                    command.CommandText = "select * from view_product_storage";
                    var reader = command.ExecuteReader();
                    List<Products> productsList = new List<Products>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Products pro = new Products();
                            pro.ProductId = reader["商品编号"].ToString().Trim();
                            pro.ProductName = reader["名称"].ToString().Trim();
                            pro.UnitPrice = reader.GetDecimal(2);
                            pro.Unit = reader["计量单位"].ToString().Trim();
                            pro.TotalCount = reader.GetInt32(4);
                            pro.Discount = reader.GetInt32(5);
                            productsList.Add(pro);
                            if(!htProidToItem.Contains(pro.ProductId))
                                htProidToItem.Add(pro.ProductId, pro);
                        }
                    }
                    reader.Close();
                    if(!IsPostBack) { 
                        foreach (Products pro in productsList)
                        {
                            DropDownList_ProductId.Items.Add(new ListItem(pro.ProductId));
                        }
                    }
                command.CommandText = "select MemberId from SMMembers where MemberStatus=1;";
                    var reader2 = command.ExecuteReader();
                if (!IsPostBack)
                {
                    if (reader2.HasRows)
                    {
                        while (reader2.Read())
                        {
                            string memberId = reader2.GetInt32(0).ToString().Trim();
                            DropDownList_MemId.Items.Add(new ListItem(memberId));
                        }
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
   // }

    protected void id_startCash_Click(object sender, EventArgs e)
    {
        //Response.Write("开始收银！");
        DropDownList_ProductId.SelectedIndex = 0;
        DropDownList_MemId.SelectedIndex = 0;
        ListBox1.Items.Clear();
        htProidToCnt.Clear();
        saleslist.Clear();
        TextBox_Cur_TotMoney.Text = "0";
        showSolve.InnerHtml = "";
    }

    protected void Button_AddPro_Click1(object sender, EventArgs e) //添加商品
    {
        string pId = DropDownList_ProductId.Text; //商品id
        int proCnt = Convert.ToInt32(DropDownList_num.Text); //商品数量
        Products pro = new Products();
        pro = (Products)htProidToItem[pId];
        string pName = pro.ProductName;
        string pUnit = pro.Unit;
        string pUnitP = pro.UnitPrice.ToString();
        string pCnt = proCnt.ToString();
        if (!htProidToCnt.Contains(pId))
        {
            htProidToCnt.Add(pId, proCnt);
        }
        else
        {
            int preCnt = (int)htProidToCnt[pId];
            htProidToCnt.Remove(pId);
            htProidToCnt.Add(pId, preCnt + proCnt);
        }
  
        bool isMember = (DropDownList_MemId.SelectedIndex != 0);
        saleslist.Add(new SalesListDetail(pro.ProductId,pro.ProductName,pro.UnitPrice,pro.Discount,proCnt,isMember));
        //Response.Write("ListBox长度：" + ListBox1.Items.Count.ToString() + " salelist长度：" + saleslist.Count.ToString());
        decimal subtotmoney = pro.UnitPrice * pro.Discount/10m * proCnt;
        if (isMember) subtotmoney *= 0.95m;
        //Response.Write("subtotmony=" + subtotmoney.ToString() + " 单价:" + pro.UnitPrice.ToString() + " 折扣:" + pro.Discount.ToString() + " 个数:" + proCnt.ToString());
        decimal curTot = Convert.ToDecimal(TextBox_Cur_TotMoney.Text) + subtotmoney;
        TextBox_Cur_TotMoney.Text = curTot.ToString();
        string strProductInf = pId + "  " + pName + "  " + DropDownList_num.Text
           + pUnit + "  ￥" + pUnitP + "/" + pUnit+" "+pro.Discount+"折  ￥"+ subtotmoney.ToString();
        ListBox1.Items.Add(strProductInf);
        DropDownList_num.SelectedIndex = 0;
    }

    protected void DropDownList_ProductId_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList_num.SelectedIndex = 0;
    }

    protected void Button_DelItem_Click(object sender, EventArgs e) //删除一个选项
    {
        int[] arr = ListBox1.GetSelectedIndices();
        int len = arr.Length;
        for(int i=0;i<len;++i)
        {
            string strdel = ListBox1.Items[arr[i]].Text;
            ListBox1.Items.Remove(strdel);
            Response.Write(arr[i].ToString()+" "+strdel);
            SalesListDetail sld = new SalesListDetail();
            sld = saleslist[arr[i]];
            decimal curTot = Convert.ToDecimal(TextBox_Cur_TotMoney.Text) - sld.SubTotalMoney;
            TextBox_Cur_TotMoney.Text = curTot.ToString();
            saleslist.Remove(sld);
            string pid = sld.ProductId;
            if(htProidToCnt.Contains(pid))
            {
                int preCnt = (int)htProidToCnt[pid];
                htProidToCnt.Remove(pid);
                if(preCnt>sld.Quantity)
                {
                    htProidToCnt.Add(pid, preCnt - sld.Quantity);
                }       
            }
        }
    }


    protected void Button_Pay_Click(object sender, EventArgs e) //结算按钮
    {
        string inner = "";
       /* foreach(var tmp in htProidToCnt.Keys)
        {
            inner += tmp.ToString() + ":" + htProidToCnt[tmp].ToString() + "<br/>";
        }
        showSolve.InnerHtml = inner;
        */
        saleslist.Clear();
        foreach(var pid in htProidToCnt.Keys)
        {
            int cnt = (int)htProidToCnt[pid]; //个数
            Products pro = new Products();
            pro = (Products)htProidToItem[pid];
            bool isMember = (DropDownList_MemId.SelectedIndex != 0);
            saleslist.Add(new SalesListDetail(pro.ProductId,pro.ProductName,pro.UnitPrice,pro.Discount,cnt,isMember));
        }
        string memberId = "000000000";
        if (DropDownList_MemId.SelectedIndex != 0) memberId = DropDownList_MemId.Text.Trim();
        //订单流水号：日期+时间+收银员id+会员id
        string SerialNum = DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss") +"_" +Session["curSalesPersonId"].ToString().Trim() + "_" + memberId;
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
            string sqlstr = "insert into SalesList(SerialNum,TotalMoney,RealReceive,ReturnMoney,SalesPersonId,SaleDate) values('{0}','{1}','{2}','{3}',{4},default);";
            sqlstr = string.Format(sqlstr, SerialNum, TextBox_Cur_TotMoney.Text, TextBox_Cur_TotMoney.Text, "0.00", Session["curSalesPersonId"].ToString().Trim());
            command.CommandText = sqlstr;
            string innerStr = "交易成功！<br/>交易流水号为:" + SerialNum + "<br/>小票如下:<br/>";
            innerStr += "<table>\n<tr><th>编号</th><th>商品</th><th>单价</th><th>折扣</th><th>个数</th><th>小计</th></tr>";
            int cntt = 0;
            int f = command.ExecuteNonQuery();
            if (f <= 0)
            {
                Response.Write("订单插入失败！");
            }
            else //插入流水明细
            {
                string sql = "insert into SalesListDetail(SerialNum, ProductId, ProductName, UnitPrice, Discount, Quantity, SubTotalMoney) values('{0}','{1}','{2}',{3},{4},{5},'{6}');";
                foreach (var dt in saleslist)
                {
                    string pid = dt.ProductId, pname = dt.ProductName, up = dt.UnitPrice.ToString(), disc = dt.Discount.ToString(), cnt = dt.Quantity.ToString(), tot = dt.SubTotalMoney.ToString();
                    string sqlStr = string.Format(sql, SerialNum, pid, pname, up, disc, cnt, tot);
                    command.CommandText = sqlStr;
                    int g = command.ExecuteNonQuery();
                    if (g <= 0)
                    {
                        Response.Write("插入小票明细失败");
                    }
                    cntt++;
                    innerStr += "<tr><td>" + cntt.ToString() + "</td><td>"+pname+"</td><td>" + up + "</td><td>" + disc + "</td><td>" + cnt + "</td><td>" + tot + "</td></tr>";
                }
                if (DropDownList_MemId.SelectedIndex != 0)
                {
                    int add = (int)(Convert.ToDecimal(TextBox_Cur_TotMoney.Text) / 20);
                    string sql2 = "update SMMembers set Points=Points+" + add.ToString() + " where MemberId=" + DropDownList_MemId.Text;
                    command.CommandText = sql2;
                    int h = command.ExecuteNonQuery();
                    if (h <= 0)
                    {
                        Response.Write("会员更新更新积分失败！");
                    }
                    command.ExecuteNonQuery();
                }
            }
            conn.Close();
            innerStr += "</table>\n";
            innerStr += "总计:￥" + TextBox_Cur_TotMoney.Text;
            showSolve.InnerHtml = innerStr;

        }
        catch (Exception es)
        {
            Response.Write("出现了一点儿错误，错误信息如下：\n" + es.Message);
        }
        
        DropDownList_MemId.SelectedIndex = 0;
        ListBox1.Items.Clear();
        htProidToCnt.Clear();
        saleslist.Clear();
        TextBox_Cur_TotMoney.Text = "0";
    }
}