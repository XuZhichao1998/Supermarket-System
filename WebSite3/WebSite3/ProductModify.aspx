<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductModify.aspx.cs" Inherits="ProductModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市-商品修改</title>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
</head>
<body>
    <h1>海之星超市-商品修改</h1>
    <p id="AdminInf" class="salesPersonInf" runat="server"></p>
    <form id="form1" runat="server">
        <div>
            商品编号:<asp:TextBox ID="TextBox_Pid" runat="server" ReadOnly="true"></asp:TextBox><span style="font-size:0.7em;">不可修改</span><br />
            商品名称:<asp:TextBox ID="TextBox_Pname" runat="server" ReadOnly="true"></asp:TextBox><span style="font-size:0.7em;">不可修改</span><br />
            计量单位:<asp:TextBox ID="TextBox_Unit" runat="server" ReadOnly="true"></asp:TextBox><span style="font-size:0.7em;">不可修改</span><br />
            商品单价:<asp:TextBox ID="TextBox_UnitPrice" runat="server"></asp:TextBox><span style="font-size:0.7em;">可以修改</span><br />
            商品折扣:<asp:DropDownList ID="DropDownList_Discount" runat="server" Width="188px"></asp:DropDownList><span style="font-size:0.7em;">可以修改</span><br />
            <asp:RegularExpressionValidator ID="PriceValidator" ControlToValidate="TextBox_UnitPrice" Display="Static"
                runat="server" ErrorMessage="输入的价格必须为数字！" ValidationExpression="(?!0\d)\d*(\.\d+)?$" ForeColor="Red" Font-Size="Small" ></asp:RegularExpressionValidator>           
            <br />
            <asp:Button ID="Button_Submit" runat="server" Text="确认修改" OnClick="Button_Submit_Click" />
            <asp:Button ID="Button_Reset" runat="server" Text="还原" OnClick="Button_Reset_Click" />
            <asp:Button ID="Button_Back" runat="server" Text="返回商品管理" OnClick="Button_Back_Click" Width="129px" />
        </div>
        <p id="InsertResult" class="showMessage" runat="server"></p>
        <p>
            <a href="InventoryManage.aspx">去查询库存</a>
        </p>
    </form>
</body>
</html>
