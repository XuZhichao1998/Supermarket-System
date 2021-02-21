<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市管理员登录</title>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
</head>
<body>
    <h2>海之星超市</h2>
    <form id="form1" runat="server" action="loginCheck.aspx" method="post">
        <div class="login">
        <p>管理员登录:</p>
        姓名:<input type="text" name="username" /><br />
        密码:<input type="password" name="userpassword" /><br />
        <input type="submit" value="登录" />
        <input type="reset" value="取消" />
        </div>
    </form>
    <br />
    <a href="index.aspx">返回超市主页</a>
</body>
</html>
