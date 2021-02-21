<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductManage.aspx.cs" Inherits="ProductManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市-商品管理</title>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
</head>
<body style="text-align:center;margin:0 auto;">
    <h1>海之星超市-商品管理</h1>
    <p id="AdminInf" class="salesPersonInf" runat="server"></p>
    <a href="show.aspx">返回管理员功能目录</a><br /><br />
    <form id="form1" runat="server"> 
        
        <div>
            增加新的商品:<br/>
            商品编号:<asp:TextBox ID="TextBox_Pid" runat="server" Width="180px"></asp:TextBox><br />
            商品名称:<asp:TextBox ID="TextBox_Pname" runat="server" Width="180px"></asp:TextBox><br />
            商品单价:<asp:TextBox ID="TextBox_UnitPrice" runat="server" Width="180px"></asp:TextBox>
                       <br />
            商品折扣:<asp:DropDownList ID="DropDownList_Discount" runat="server" style="margin-left: 0px" Width="187px"></asp:DropDownList>
            
            <br />
            计量单位:<asp:DropDownList ID="DropDownList_Unit" runat="server" Width="188px"></asp:DropDownList><br />
            商品类别:<asp:DropDownList ID="DropDownList_PCategory" runat="server" Width="188px"></asp:DropDownList><br/>
             <asp:RegularExpressionValidator ID="PriceValidator" ControlToValidate="TextBox_UnitPrice" Display="Static"
                runat="server" ErrorMessage="输入的价格必须为数字！" ValidationExpression="(?!0\d)\d*(\.\d+)?$" ForeColor="Red" Font-Size="Small" ></asp:RegularExpressionValidator>           
            <br />
            <asp:Button ID="AddProduct" runat="server" Text="添加商品" OnClick="AddProduct_Click" />
            <asp:Button ID="Button_Reset" runat="server" Text="清空重置" OnClick="Button_Reset_Click" Width="89px" /><br />
            <p id="showInsertResult" name="showInsertResult" runat="server" class="showMessage"></p>
        </div>
        <div>
            <asp:Button ID="Button_QueryAllProduct" runat="server" Text="查询所有商品" OnClick="Button_QueryAllProduct_Click" />
            <asp:Button ID="Button_QueryClear" runat="server" Text="清除查询结果" OnClick="Button_QueryClear_Click" />
            <p id="showAllProduct" runat="server"></p>
        </div>
    </form>
</body>
</html>
