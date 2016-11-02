<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="MyProject02.xzdd927.friendlink.order" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
<div>
    <table >
<tr><td class="style2">链接：</td><td class="style1">
            <asp:ListBox ID="ListBox1" runat="server" Height="339px" Width="235px">
            </asp:ListBox>
</td>
<td>
<asp:Button ID="Button_First" runat="server" Text="最前位置" 
        onclick="Button_First_Click" style="height: 26px" /><br/>
<asp:Button ID="Button_Before" runat="server" Text="上移一位" onclick="Button_Before_Click" /><br/>
<asp:Button ID="Button_Next" runat="server" Text="下移一位" onclick="Button_Next_Click" /><br/>
<asp:Button ID="Button_End" runat="server" Text="最后位置" onclick="Button_End_Click" /><br/><br/>
<asp:Button ID="Button1" runat="server" Text="保 存" onclick="Button1_Click" />
</td></tr>
<%--<tr><td class="style2">&nbsp;</td><td class="style1">
            
          
            </td></tr>--%>


</table>
</div>
</form>
</body>
</html>
