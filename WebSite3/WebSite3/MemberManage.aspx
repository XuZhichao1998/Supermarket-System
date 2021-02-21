<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberManage.aspx.cs" Inherits="MemberManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市-会员管理</title>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
</head>
<body>
    <h1>海之星超市-会员管理</h1>
    <p id="AdminInf" class="salesPersonInf" runat="server"></p>
    <a href="show.aspx">返回管理员功能目录界面</a><br /><br />
    <form id="form1" runat="server">
        <div style="background-color:bisque; width: 991px; margin-left: 265px;">
            添加会员:<br />
            会员姓名:<asp:TextBox ID="TextBox_MemberName" runat="server"></asp:TextBox><br />
            会员电话:<asp:TextBox ID="TextBox_MemberPhoneNumber" runat="server"></asp:TextBox><br />
            会员住址:<asp:TextBox ID="TextBox_MemberAddress" runat="server"></asp:TextBox><br />
            <asp:RegularExpressionValidator runat="server" ID="PhoneNumberValidator" ControlToValidate="TextBox_MemberPhoneNumber" 
               Display="Static" ErrorMessage="电话号码必须存在并且格式为ddd-dddd-dddd" ValidationExpression="^1[3|4|5|7|8][0-9]-\d{4}-\d{4}$" ForeColor="Red" Font-Size="Small"  >
            </asp:RegularExpressionValidator><br />
            <asp:Button ID="Button_Add" runat="server" Text="添加" OnClick="Button_Add_Click" />&nbsp;&nbsp;
            <asp:Button ID="Button2_Reset" runat="server" Text="取消" OnClick="Button2_Reset_Click" /><br />
            <p id="AddResult" name="AddResult" runat="server" class="showMessage"></p>
         </div>
        <br /><br />
        <div style="background-color:bisque; width: 1004px; margin-left: 258px;">
            <asp:Button ID="Button_QueryAllMember" runat="server" Text="显示会员" OnClick="Button_QueryAllMember_Click" />
            <asp:Button ID="Button_Clear" runat="server" Text="清除" OnClick="Button_Clear_Click" /><br />
            <p id="showAllMmeber" runat="server" name="showAllMember" class="showMessage" ></p>
        </div>
    </form>
</body>
</html>
