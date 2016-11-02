<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="barcode.aspx.cs" Inherits="MyProject02.tools.barcode" %>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>二维码生成器_好宝宝早教网</title>
<link href="/css/css2.css" rel="stylesheet" type="text/css"/>
<script src="/js/jquerym.js" type="text/javascript"></script>
</head>
<body>
<!--百度统计代码-->
<script>
    var _hmt = _hmt || [];
    (function() {
        var hm = document.createElement("script");
        hm.src = "//hm.baidu.com/hm.js?138a328660e33c71bad7bfcceaa1e08f";
        var s = document.getElementsByTagName("script")[0];
        s.parentNode.insertBefore(hm, s);
    })();
</script>
<!--百度提交代码-->
<script>
    (function() {
        var bp = document.createElement('script');
        bp.src = '//push.zhanzhang.baidu.com/push.js';
        var s = document.getElementsByTagName("script")[0];
        s.parentNode.insertBefore(bp, s);
    })();
</script>

<!--头部-->
<!--#include virtual="/userControl/head_utf8.html"-->
<form id="form1" runat="server">

<div style="width:960px;margin:0 auto; margin-top:20px; background:#fff; padding-top:10px; padding-left:10px; height:auto; padding-bottom:10px; min-height:400px;">
<div style="border:#ccc 1px solid; background-color:#fff;  line-height:30px; padding-left:10px; margin-left:12px; margin-bottom:10px; width:50%;">二维码生成器</div>
<div style="float:left;">
    <table style="margin:10px 12px;"  border="0"  cellpadding="0" cellspacing="0">
    <tr>
        <td style="">
            <textarea id="textContent" style="font-size:18px; color:#666; padding-top:3px; border:#ccc 1px solid;" cols="43" rows="8" runat="server" value="请输入文字内容，支持普通文本和网址" onfocus="SetContentFocus()" onblur="SetContentBlur()"></textarea>
        </td>
    </tr>
    <tr style=" line-height:40px;">
        <td>
            图像大小：
            <asp:DropDownList ID="ddlSize" runat="server" Width="100">
                <asp:ListItem Value="1" Text="1"></asp:ListItem>
                <asp:ListItem Value="2" Text="2"></asp:ListItem>
                <asp:ListItem Value="3" Text="3" Selected="True"></asp:ListItem>
                <asp:ListItem Value="4" Text="4"></asp:ListItem>
                <asp:ListItem Value="5" Text="5"></asp:ListItem>
                <asp:ListItem Value="6" Text="6"></asp:ListItem>
                <%--<asp:ListItem Value="7" Text="7"></asp:ListItem>
                <asp:ListItem Value="8" Text="8"></asp:ListItem>--%>
            </asp:DropDownList>
        </td>
    </tr>
    <tr style=" line-height:40px;">
        <td>
            <asp:ImageButton ID="imgBtnSubmit" 
                ImageUrl="/images/code1.jpg" runat="server"  OnClientClick="return Valid();"
                onclick="imgBtnSubmit_Click" />
        </td>
    </tr>
    </table>
</div>
<div style="float:left; margin-left:20px; margin-top:10px;" align="center">
    <img id="imgCode" runat="server" style="border:#ccc 1px solid; padding:3px;" visible="false"/>
</div>
<div style="clear:both;"></div>
</div>

<div style="clear:both;"></div>
<!--#include file="/userControl/foot_utf8.html"-->

</form>

<script type="text/javascript">

function SetContentFocus()
{
    var content=document.getElementById("textContent").value.replace(/(^\s*)|(\s*$)/g, "");
    if(content=="请输入文字内容，支持普通文本和网址")
    {
        document.getElementById("textContent").value="";
    }
}
function SetContentBlur()
{
    var content=document.getElementById("textContent").value.replace(/(^\s*)|(\s*$)/g, "");
    if(content=="")
    {
        document.getElementById("textContent").value="请输入文字内容，支持普通文本和网址";
    }
}

function Valid()
{
    var isOk=true;
    
    var content=document.getElementById("textContent").value.replace(/(^\s*)|(\s*$)/g, "");
    if(content=="请输入文字内容，支持普通文本和网址"||content=="")
    {
        alert("请输入二维码内容");
        isOk= false;
    }
    
    return isOk;
}
</script>
</body>
</html>
