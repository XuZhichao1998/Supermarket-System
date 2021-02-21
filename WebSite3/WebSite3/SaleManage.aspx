<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SaleManage.aspx.cs" Inherits="SaleManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市-销售管理</title>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
</head>
<body>
    <h1>海之星超市-销售管理</h1>
    <p id="AdminInf" class="salesPersonInf" runat="server"></p>
    <a href="show.aspx">点击返回管理员功能目录页面</a>><br /><br />

    <form id="form1" runat="server">
        <div>
            销售流水查询:
            <asp:DropDownList ID="DropDownList_Option" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_Option_SelectedIndexChanged" ></asp:DropDownList>
            开始时间:<input type="date" runat="server" id="st_date" name="st_date" />
            结束时间:<input type="date" runat="server" id="ed_date" name="ed_date" />
            <asp:Button ID="Button_Query" runat="server" Text="查询" OnClick="Button_Query_Click" />
            <asp:Button ID="Button_Reset" runat="server" Text="重置" OnClick="Button_Reset_Click" /><br />
            <p runat="server" id="showResult" name="showResult" class="showMessage"> </p>
        </div>
    </form>
</body>
</html>
