<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReturnOrderManage.aspx.cs" Inherits="ReturnOrderManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市-退货管理</title>
     <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
    <style type="text/css">
        #orderId {
            width: 300px;
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <h1>海之星超市-退货管理</h1>
    <p id="AdminInf" class="salesPersonInf" runat="server"></p>
    <a href="show.aspx">点击返回管理员功能目录</a><br /><br />
    <form id="form1" runat="server">
        <div>
            <label>订单号:</label><asp:DropDownList ID="DropDownList_SerialNum" runat="server"></asp:DropDownList>
            <asp:Button ID="Button_Query" runat="server" Text="查询" OnClick="Button_Query_Click" />
            <span style="color:cyan; font-size:0.7em; font-family:SimHei;">只能退一周以内的商品</span>
        </div>
        <p id="queryResultId" runat="server"></p>
        <div style="background-color:cornflowerblue; width: 1392px;">
            退货订单查询:
            <asp:DropDownList ID="DropDownList_Option" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_Option_SelectedIndexChanged"></asp:DropDownList>
            &nbsp;&nbsp;开始时间<input type="date" id="st_date" name="st_date" runat="server"/>
            &nbsp;&nbsp;结束时间<input type="date" id="ed_date" name="ed_date" runat="server" />
             <asp:Button ID="Button_ClearShowReturnOrderSeven" runat="server" Text="清除" OnClick="Button_ClearShowReturnOrderSeven_Click" Width="42px" BackColor="#FFCCCC" />
            <asp:Button ID="Button_Submit" runat="server" Text="查询" OnClick="Button_Submit_Click" />
            <p id="showReturnOrderSevenDays" runat="server"></p>
        </div>
    </form>
</body>
</html>
