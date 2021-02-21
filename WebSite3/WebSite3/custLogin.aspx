<%@ Page Language="C#" AutoEventWireup="true" CodeFile="custLogin.aspx.cs" Inherits="custLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市-会员登录</title>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
    <script type="text/javascript" src="JavaScriptCheck.js"></script>
</head>
<body>
    <h2>海之星超市</h2>
    
    <form id="form1" runat="server" action="custLoginCheck.aspx">
        <div class="login2">
            <p>会员登录</p>
            <p>
                会员姓名：<input type="text" name="custLoginName" /> <br/>
                会员电话: <input type="text" name="custLoginPhoneNum" id="custLoginPhoneNum" value="ddd-dddd-dddd"onblur="chkPhoneNum()" /><br />
                <input type="submit" value="登录" />
                <input type="reset" value="取消" />
            </p>
        </div>
    </form>
    <br/>
    <a href="index.aspx">返回超市主页</a>
</body>
</html>
