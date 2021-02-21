<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CashierManage.aspx.cs" Inherits="CashierManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市-收银员管理</title>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
</head>
<body>
    <h1>海之星超市-收银员管理</h1>
    <p id="AdminInf" class="salesPersonInf" runat="server"></p>
        <a href="show.aspx">点击返回管理员功能目录页面</a>><br /><br />
    <form id="form1" runat="server">
        <div>
            <p>添加收银员</p>
            <label>登录姓名:</label><asp:TextBox ID="TextBox_CashierName" runat="server"></asp:TextBox><br />
            <label>登录密码:</label><asp:TextBox ID="TextBox_Pwd" runat="server"></asp:TextBox><br />
            <label>确认密码:</label><asp:TextBox ID="TextBox_Pwdd" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button_Submit" runat="server" Text="添加" OnClick="Button_Submit_Click" />&nbsp;&nbsp;
            <asp:Button ID="Button_Reset" runat="server" Text="重置" OnClick="Button_Reset_Click" />
            <p runat="server" id="showRegisterMsg" name="showRegisterMsg" class="showMessage"> </p>
        </div>
        <div>
            <asp:Button ID="Button_Query" runat="server" Text="查看所有收银员" OnClick="Button_Query_Click" />
            <asp:Button ID="Button_Clear" runat="server" Text="清空" OnClick="Button_Clear_Click" /><br />
            <p runat="server" id="showCashier" name="showCashier"></p>
        </div>
    </form>
</body>
</html>
