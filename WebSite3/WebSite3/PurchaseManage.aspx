 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="PurchaseManage.aspx.cs" Inherits="PurchaseManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>海之星超市-进货管理</title>
    <link rel="stylesheet" type="text/css" href="StyleSheetSupermarket.css" />
    <style type="text/css">
        #st_date {
            width: 150px;
        }
        #ed_date {
            width: 150px;
        }
        #purchase_date {
            width: 361px;
            background-color:darksalmon;
        }
        input.date {background-color:darksalmon;}
                    
    </style>
</head>
<body>
    <h1>海之星超市-进货管理</h1>
    <p id="AdminInf" class="salesPersonInf" runat="server"></p>
    <p>
        <a href="InventoryManage.aspx">去查询库存</a>&nbsp;&nbsp;
        <a href="show.aspx">返回管理员功能目录</a>
    </p>
    <form id="form1" runat="server" method="post" action="#">
        <div>
            
            <table>
                <caption>添加进货信息</caption>
                <tr>
                    <th>货物编号:</th>
                    <td>
                        <asp:TextBox ID="TextBox_Pid" runat="server" ReadOnly="true" Width="365px" BackColor="DarkSalmon" BorderColor="DarkSalmon"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>货物名称:</th>
                    <td>
                        <asp:TextBox ID="TextBox_Pname" runat="server" ReadOnly="true" Width="365px" BackColor="DarkSalmon" BorderColor="DarkSalmon"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>出售单价:</th>
                    <td>
                        <asp:TextBox ID="TextBox_SellUnitPrice" runat="server" ReadOnly="true" Width="365px" BackColor="DarkSalmon" BorderColor="DarkSalmon"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>计量单位:</th>
                    <td>
                        <asp:TextBox ID="TextBox_Unit" runat="server" ReadOnly="true" Width="365px" BackColor="DarkSalmon" BorderColor="DarkSalmon"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>进货数量:</th>
                    <td>
                        <asp:TextBox ID="TextBox_PurchaseCnt" runat="server" Width="365px" BackColor="DarkSalmon" BorderColor="DarkSalmon"></asp:TextBox>
                         
                    </td>
                </tr>
                <tr>
                    <th>进货价格:</th>
                    <td>
                        <asp:TextBox ID="TextBox_PurchasePrice" runat="server" Width="360px" BackColor="DarkSalmon" BorderColor="DarkSalmon"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <th>总进价:￥</th>
                    <td>
                        <asp:TextBox ID="TextBox_TotalPrice" runat="server" Width="361px" BackColor="DarkSalmon" BorderColor="DarkSalmon"></asp:TextBox>
                    </td>
                </tr>
                <tr>  
                    <th>进货日期:</th>
                    
                    <td><input type="date" id="purchase_date" name="purchase_date" runat="server" /></td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:RegularExpressionValidator ID="PurchaseCntValidator" ControlToValidate="TextBox_PurchaseCnt"
                            Display="Static" runat="server" ErrorMessage="进货数量必须为正整数！" ForeColor="Blue" Font-Size="Small" 
                            ValidationExpression="^[1-9]\d*$"></asp:RegularExpressionValidator>

                        <asp:RegularExpressionValidator ID="PriceValidator" ControlToValidate="TextBox_PurchasePrice"
                            Display="Static" runat="server" ErrorMessage="进价必须为正数！" ForeColor="Blue" Font-Size="Small" 
                            ValidationExpression="^(?:[1-9]\d*|0)?(?:\.\d+)?$"></asp:RegularExpressionValidator>

                        <asp:RegularExpressionValidator ID="TotalPriceValidator" ControlToValidate="TextBox_TotalPrice"
                            Display="Static" runat="server" ErrorMessage="总进价必须为正数！" ForeColor="Blue" Font-Size="Small" 
                            ValidationExpression="^(?:[1-9]\d*|0)?(?:\.\d+)?$"></asp:RegularExpressionValidator>
                     </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button_CalPrice" runat="server" Text="计算总价" OnClick="Button_CalPrice_Click" />
                        <asp:Button ID="Button_Submit" runat="server" Text="提交" OnClick="Button_Submit_Click" />
                        <asp:Button ID="Button_Reset" runat="server" Text="重置" OnClick="Button_Reset_Click" />
                    </td>
                </tr>
             </table>
            <p id="InsertResult" class="showMessage" runat="server" ></p>
        </div>
        <br/><br />
        <div style="background-color:cornflowerblue; width: 930px; margin-left: 247px;">
            进货信息查询:<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            &nbsp;&nbsp;开始时间<input type="date" id="st_date" name="st_date" runat="server"/>
            &nbsp;&nbsp;结束时间<input type="date" id="ed_date" name="ed_date" runat="server" />
            <asp:Button ID="Button_Query" runat="server" Text="查询进货信息" OnClick="Button_Query_Click" /><br />
            <p id="showDate" name="showDate" class="showMessage" runat="server" ></p>
            
        </div>
    </form>
</body>
</html>
