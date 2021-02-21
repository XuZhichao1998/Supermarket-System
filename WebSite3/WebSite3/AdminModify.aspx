<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminModify.aspx.cs" Inherits="AdminModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市-管理员信息修改界面</title>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
</head>
<body>
    <h1>海之星超市-管理员信息修改界面</h1>
     <p id="AdminInf" class="salesPersonInf" runat="server"></p>
     <a href="AdminManage.aspx">返回权限管理界面</a><br /><br />
    <form id="form1" runat="server">
        <div>
            <label>管理员编号:</label><asp:TextBox ID="TextBox_AdminId" runat="server" ReadOnly="true"></asp:TextBox><br />
            <label>管理员姓名:</label><asp:TextBox ID="TextBox_AdminName" runat="server" ReadOnly="true"></asp:TextBox><br />
            <label>管理员密码:</label><asp:TextBox ID="TextBox_AdminPwd" runat="server"></asp:TextBox><br />
            <label>管理员状态:</label><asp:DropDownList ID="DropDownList_Status" runat="server" Width="158px"></asp:DropDownList><br />
            <asp:Button ID="Button_Submit" runat="server" Text="确认修改" OnClick="Button_Submit_Click" />
            <asp:Button ID="Button_Reset" runat="server" Text="重置" OnClick="Button_Reset_Click" />
            <p id="showResult" name="showResult" class="showMessage" runat="server"></p>
        </div>
    </form>
</body>
</html>
