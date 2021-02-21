<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberDelete.aspx.cs" Inherits="MemberDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市-会员删除界面</title>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
</head>
<body>
    <h1>海之星超市-会员删除界面</h1>
    <p id="AdminInf" class="salesPersonInf" runat="server"></p>
     <a href="MemberManage.aspx">返回会员管理界面</a><br /><br />
    <form id="form1" runat="server">
        <div>
            会员编号:<asp:TextBox ID="TextBox_id" runat="server" ReadOnly="true" ></asp:TextBox> <br />
            会员姓名:<asp:TextBox ID="TextBox_name" runat="server" ReadOnly="true" ></asp:TextBox> <br />
            会员电话:<asp:TextBox ID="TextBox_phone" runat="server" ReadOnly="true"></asp:TextBox> <br />
            会员住址:<asp:TextBox ID="TextBox_address" runat="server" ReadOnly="true"></asp:TextBox> <br />
            会员积分:<asp:TextBox ID="TextBox_point" runat="server" ReadOnly="true"></asp:TextBox> <br />
            注册日期:<asp:TextBox ID="TextBox_opentime" runat="server" ReadOnly="true"></asp:TextBox> <br />
            失效日期:<asp:TextBox ID="TextBox_edtime" runat="server" ReadOnly="true"></asp:TextBox> <br />
            是否过期:<asp:TextBox ID="TextBox_overdue" runat="server" ReadOnly="true" ></asp:TextBox> <br />
            <asp:Button ID="Button_Submit" runat="server" Text="确认删除" OnClick="Button_Submit_Click" />
            <p id="showResult" runat="server" name="showResult" class="showMessage"></p>
        </div>
    </form>
</body>
</html>
