<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReturnOrderWork.aspx.cs" Inherits="ReturnOrderWork" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市-退货处理页面</title>
     <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
</head>
<body>
    <h1>海之星超市-退货处理页面</h1>
    <p id="AdminInf" class="salesPersonInf" runat="server"></p>
    <a href="ReturnOrderManage.aspx">点击返回退货管理页面</a><br /><br />
    <form id="form1" runat="server">
        <div runat="server">
            交易流水:<asp:TextBox ID="TextBox_SerialNum" runat="server" ReadOnly="true" Width="240px"></asp:TextBox><br/>
            商品编号:<asp:TextBox ID="TextBox_Pid" runat="server" ReadOnly="true" Width="240px"></asp:TextBox><br />
            退货数量:<asp:DropDownList ID="DropDownList_rcnt" runat="server" OnSelectedIndexChanged="DropDownList_rcnt_SelectedIndexChanged" style="margin-left: 0px" Width="240px" Autopostback="true"></asp:DropDownList> <br />
            退货金额:<asp:TextBox ID="TextBox_rMoney" runat="server" Width="240px"></asp:TextBox><br />
            <asp:Button ID="Button_Submit" runat="server" Text="确认退货" OnClick="Button_Submit_Click" />
            <asp:Button ID="Button_Back" runat="server" Text="返回退货管理页面" OnClick="Button_Back_Click" />
            <p runat="server" id="showResult" name="showResult" class="showMessage"> </p>
        </div>
    </form>
</body>
</html>
