<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CashierModify.aspx.cs" Inherits="CashierModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市-收银员信息更改页面</title>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
</head>
<body>
    <h1>海之星超市-收银员信息更改页面</h1>
    <p id="AdminInf" class="salesPersonInf" runat="server"></p>
    <a href="CashierManage.aspx">点击返回收银员管理页面</a>><br /><br />
    <form id="form1" runat="server">
        <div>
             收银员编号:<asp:TextBox ID="TextBox_CashierID" runat="server" ReadOnly="true"></asp:TextBox><br />
            收银员姓名:<asp:TextBox ID="TextBox_CashierName" runat="server" ReadOnly="true"></asp:TextBox><br />
            收银员密码:<asp:TextBox ID="TextBox_Pwd" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button_Submit" runat="server" Text="确认修改" OnClick="Button_Delete_Click" />
            <asp:Button ID="Button_Reset" runat="server" Text="还原" OnClick="Button_Reset_Click" /><br />
            <p runat="server" id="showResult" name="showResult" class="showMessage"> </p>
        </div>
    </form>
</body>
</html>
