using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Products 的摘要说明
/// </summary>
public class Products
{
    public Products()
    {
        
    }
    public string ProductId   //商品编号
    { get; set; }
    public string ProductName //商品名称
    { get; set; }
    public decimal UnitPrice //商品单价
    { get; set; }
    public string Unit //计量单位
    { get; set; }
    public int Discount //折扣
    { get; set; }
    public int CategoryId //商品分类编号
    { get; set; }
    public int TotalCount //库存量
    { get; set; }
    public int MinCount //最小库存
    { get; set; }
    public int MaxCount //最大库存
    { get; set; }
}