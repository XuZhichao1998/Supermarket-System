<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberModify.aspx.cs" Inherits="MemberModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市-会员信息修改界面</title>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
</head>
<body>
    <h1>海之星超市-会员信息修改界面</h1>
    <p id="AdminInf" class="salesPersonInf" runat="server"></p>
     <a href="MemberManage.aspx">返回会员管理界面</a><br /><br />
    <form id="form1" runat="server">
        <div>
            会员编号:<asp:TextBox ID="TextBox_id" runat="server" ReadOnly="true" ></asp:TextBox><span style="font-size:0.6em;color:darkred;font-family:SimHei;">不可修改</span> <br />
            会员姓名:<asp:TextBox ID="TextBox_name" runat="server" ReadOnly="true"></asp:TextBox><span style="font-size:0.6em;color:darkred;font-family:SimHei;">不可修改</span>  <br />
            会员电话:<asp:TextBox ID="TextBox_phone" runat="server" ReadOnly="true"></asp:TextBox><span style="font-size:0.6em;color:darkred;font-family:SimHei;">不可修改</span>  <br />
            注册日期:<asp:TextBox ID="TextBox_opentime" runat="server" ReadOnly="true"></asp:TextBox><span style="font-size:0.6em;color:darkred;font-family:SimHei;">不可修改</span>  <br />
            失效日期:<asp:TextBox ID="TextBox_edtime" runat="server" ReadOnly="true"></asp:TextBox><span style="font-size:0.6em;color:darkred;font-family:SimHei;">不可修改</span> <br />
            是否过期:<asp:TextBox ID="TextBox_overdue" runat="server" ReadOnly="true"></asp:TextBox><span style="font-size:0.6em;color:darkred;font-family:SimHei;">不可修改</span>  <br />
            会员住址:<asp:TextBox ID="TextBox_address" runat="server"></asp:TextBox><span style="font-size:0.6em;color:blue;font-family:SimHei;">可以修改</span> <br />
            会员积分:<asp:TextBox ID="TextBox_point" runat="server" ></asp:TextBox><span style="font-size:0.6em;color:blue;font-family:SimHei;">可以修改</span> <br />
            会员状态:<asp:DropDownList ID="DropDownList_status" runat="server" style="margin-left: 0px" Width="163px"></asp:DropDownList><span style="font-size:0.6em;color:blue;font-family:SimHei;">可以修改</span> <br />
            <asp:Button ID="Button_Submit" runat="server" Text="确认修改" OnClick="Button_Submit_Click" />
            <asp:Button ID="Button_Reset" runat="server" Text="还原" OnClick="Button_Reset_Click" />
             <p id="showResult" runat="server" name="showResult" class="showMessage"></p>
        </div>
    </form>
</body>
</html>
