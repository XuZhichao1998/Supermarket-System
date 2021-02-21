<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CashierDelete.aspx.cs" Inherits="CashierDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市-收银员删除页面</title>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
</head>
<body>
    <h1>海之星超市-收银员删除页面</h1>
    <p id="AdminInf" class="salesPersonInf" runat="server"></p>
    <form id="form1" runat="server">
        <a href="CashierManage.aspx">点击返回收银员管理页面</a>><br /><br />
        <div>
            收银员编号:<asp:TextBox ID="TextBox_CashierID" runat="server" ReadOnly="true"></asp:TextBox><br />
            收银员姓名:<asp:TextBox ID="TextBox_CashierName" runat="server" ReadOnly="true"></asp:TextBox><br />
            <asp:Button ID="Button_Delete" runat="server" Text="确认删除" OnClick="Button_Delete_Click" />

            <p runat="server" id="showResult" name="showResult" class="showMessage"> </p>
        </div>
    </form>
</body>
</html>
