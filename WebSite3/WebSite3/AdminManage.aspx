<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminManage.aspx.cs" Inherits="AdminManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市-管理员权限管理</title>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
</head>
<body>
    <h1>海之星超市-管理员权限管理</h1>
    <p id="AdminInf" class="salesPersonInf" runat="server"></p>
    <a href="show.aspx">返回管理员功能目录界面</a><br /><br />
    <form id="form1" runat="server">
        <div style="background-color:indianred; width: 530px; margin:0 auto;">
                添加普通管理员:<br />
            <label>管理员姓名:</label><asp:TextBox ID="TextBox_AdminName" runat="server"></asp:TextBox><br />

            <label>管理员密码:</label><asp:TextBox ID="TextBox_AdminPwd" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button_Add" runat="server" Text="添加" OnClick="Button_Add_Click" />&nbsp;&nbsp;
            <asp:Button ID="Button_Reset" runat="server" Text="清空" OnClick="Button_Reset_Click" />
            <p id="showInsert" name="showInsert" class="showMessage" runat="server" style="margin:0 auto;" ></p>
        </div>
            
        <br /><br />
        <div>
            <asp:Button ID="Button_ShowAllAdmin" runat="server" Text="查询所有普通管理员" OnClick="Button_ShowAllAdmin_Click" />
            <asp:Button ID="Button_Clear" runat="server" Text="清除" OnClick="Button_Clear_Click" />
            <p id="showQuery" name="showQuery" class="showMessage" runat="server"></p>
        </div>

    </form>
</body>
</html>
