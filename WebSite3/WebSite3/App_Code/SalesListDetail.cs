using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// SalesListDetail 的摘要说明
/// </summary>
public class SalesListDetail
{
    public string ProductId //商品Id
    { get; set; }
    public string ProductName //商品名称
    { get; set; }
    public decimal UnitPrice //商品单价
    { get; set; }
    public decimal Discount //商品折扣，数据库中设置为整数
    { get; set; }
    public int Quantity //商品数量
    { get; set; }
    public decimal SubTotalMoney //金额小计
    { get; set; }
    public SalesListDetail() //构造函数
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public SalesListDetail(string pid,string pName,decimal unitp,decimal discnt,int cnt,bool isMember)
    {
        this.ProductId = pid;
        this.ProductName = pName;
        this.UnitPrice = unitp;
        this.Discount = discnt;
        this.Quantity = cnt;
        this.SubTotalMoney = this.UnitPrice * this.Quantity * discnt / 10;
        if(isMember==true)
        {
            this.SubTotalMoney = this.SubTotalMoney*0.95m;
        }
    }
}