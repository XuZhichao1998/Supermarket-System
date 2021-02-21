<%@ Page Language="C#" AutoEventWireup="true" CodeFile="show.aspx.cs" Inherits="show" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
    <title>管理员页面</title>
</head>
<body>
    <h1>管理员功能目录</h1>
    <p id="AdminInf" class="salesPersonInf" runat="server"></p>
    <p id="visiter" runat ="server"></p>
    <div style="background-color:lightpink; width: 498px; margin-left: 510px;">
        <p>
            <a href="InventoryManage.aspx" >库存-进货管理</a>
        </p>
        <p>
            <a href="ProductManage.aspx">商品管理</a>
        </p>
        <p>
            <a href="ReturnOrderManage.aspx" >退货管理</a>
        </p>
        <p>
            <a href="MemberManage.aspx">会员管理</a>
        </p>
        <p>
            <a href="CashierManage.aspx" >员工管理</a>
        </p>
        <p>
            <a href="SaleManage.aspx">销售管理</a>
        </p>
        <p id="id_ManageManage" runat="server"></p>
    </div>
    
    <form id="form1" runat="server">
       
    </form>
</body>
</html>
