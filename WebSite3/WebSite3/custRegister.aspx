<%@ Page Language="C#" AutoEventWireup="true" CodeFile="custRegister.aspx.cs" Inherits="custRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市-会员注册</title>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
</head>
<body style="text-align:left; width: 1531px;">
    <h1 style="margin:0 auto;text-align:center;">海之星超市-会员注册</h1>
    <a href="index.aspx">返回超市主页</a>
    <form id="form1" runat="server" action="custRegisterCheck.aspx">
        <div style="background-color:antiquewhite;">
            <p>
                <label>姓名：</label>
                    <asp:TextBox ID="MemberName" runat="server"></asp:TextBox><br/>
                <label>电话：</label>
                <asp:TextBox ID="PhoneNumber" runat="server" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="phoneValidator" ControlToValidate="PhoneNumber" 
                    Display="Static" runat="server" ErrorMessage="电话号码的格式必须为：ddd-dddd-dddd" 
                    ValidationExpression="\d{3}-\d{4}-\d{4}"></asp:RegularExpressionValidator><br />
                <label>住址：</label>
                <asp:TextBox ID="MemberAddress" runat="server"></asp:TextBox><br />
                <asp:Button runat="server" Text="注册" />
            </p>
            <p>你已经是会员了？<a href="custLogin.aspx">去登录</a></p>
        </div>
        <p id="ErrorMsg"></p>
    </form>
</body>
</html>
