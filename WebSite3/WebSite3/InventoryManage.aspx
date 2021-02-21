<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InventoryManage.aspx.cs" Inherits="InventoryManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市-库存管理</title>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
</head>
<body>
    <h1>海之星超市-库存管理</h1>
    <p id="AdminInf" class="salesPersonInf" runat="server"></p>
    <a href="show.aspx">点击返回管理员功能目录页面</a><br /><br />
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button_ShowAll" runat="server" Text="查询全部商品的库存" Width="160px" OnClick="Button_ShowAll_Click" />
            <p id="showInventory" runat="server"></p>
        </div>
    </form>
</body>
</html>
