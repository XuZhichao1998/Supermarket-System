<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cashierWork.aspx.cs" Inherits="cashierWork" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市-收银系统</title>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
    <script type="text/javascript" src="JavaScriptCashierWork.js"></script>
</head>
<body>
    <h2>海之星超市-收银系统</h2>
    <form id="form1" runat="server">
        <p id="SPInf" class="salesPersonInf" runat="server"></p>
        <div>
            <asp:Button ID="id_startCash" runat="server" Text="开始收银" BackColor="#99FF66" OnClick="id_startCash_Click"  /><br />
            顾客会员号: <asp:DropDownList ID="DropDownList_MemId" runat="server"></asp:DropDownList>

            <p>
                商品id: <asp:DropDownList ID="DropDownList_ProductId" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_ProductId_SelectedIndexChanged"></asp:DropDownList>
                &nbsp;&nbsp;
                数量: 
                <asp:DropDownList ID="DropDownList_num" runat="server" AutoPostBack="true" Width="40px"> </asp:DropDownList>
                &nbsp;&nbsp;
                <asp:Button ID="Button_AddPro" runat="server" Text="添加" OnClick="Button_AddPro_Click1" /> 
            </p>
            <p>
                <asp:ListBox ID="ListBox1" runat="server" Width="496px" Height="200px"></asp:ListBox>

            </p>
        </div>
        <asp:Button ID="Button_DelItem" runat="server" OnClick="Button_DelItem_Click" Text="删除选中项" Width="89px" />
        &nbsp;&nbsp;
        <asp:Button ID="Button_Pay" runat="server"  Text="结算" OnClick="Button_Pay_Click" Width="70px" />
        &nbsp;&nbsp;累计￥<asp:TextBox ID="TextBox_Cur_TotMoney" runat="server"></asp:TextBox>
        <p id="showSolve" class="showList" runat="server"></p>
    </form>
</body>
</html>
