<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cashierLogin.aspx.cs" Inherits="cashierLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市-收银员登录</title>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
    <script type="text/javascript" src="JavaScriptCashCheck.js"></script>
</head>
<body>
    <h2>海之星超市</h2>
    <form id="form1" runat="server" method="post" action="cashierLoginCheck.aspx">
        <div class="login">
            <p>收银员登录:</p>
            <label>
            姓名:<input type="text" name="cashierName" id="cashierName" /><br /></label>
            <label>
            密码:<input type="password" name="cashierPassword" id="cashierPassword" /><br /></label>
            <input type="submit" value="登录" />
         <input type="reset" value="取消" />
        </div>
    </form>
    <br />
    <a href="index.aspx">返回超市主页</a>
</body>
</html>
