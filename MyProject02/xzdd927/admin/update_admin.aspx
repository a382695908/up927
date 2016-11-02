<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update_admin.aspx.cs" Inherits="MyProject02.xzdd927.admin.update_admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>无标题页</title>
<script language="javascript" type="text/javascript">
function ValidInfo()
{
    var name=document.getElementById("txt_name").value.replace(/\s/ig,'');
    var pwd=document.getElementById("txt_pwd").value.replace(/\s/ig,'');

    if(name=="")
    {
        alert("请输入登录名");
        return false;
    }
    else if(pwd=="")
    {
        alert("请输入密码");
        return false;
    }
    else
    {
        return true;
    }
}
</script>
</head>
<body>
<form id="form1" runat="server">
<div>

<table>
    <tr>
        <td>登录名：</td>
        <td><input id="txt_name" type="text" runat="server" /></td>
    </tr>
    <tr>
        <td>密码：</td>
        <td>
            <input id="txt_pwd" type="text" runat="server" />
        </td>
    </tr>
  
    <tr>
        <td>备注：</td>
        <td>
            <input id="txt_remark" type="text" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btn_Update" runat="server" Text="保存"  OnClientClick="return ValidInfo();"
                onclick="btn_Update_Click" />
        </td>
    </tr>
</table>

</div>
</form>
</body>
</html>
