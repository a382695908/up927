<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baidu.aspx.cs" Inherits="MyProject02.tools.baidu" %>
<!doctype html>
<html>
<head runat="server">
<title>百度关键词排名查询工具_在线免费查询_无需注册_好宝宝</title>
<meta name="description" content="百度关键词排名查询工具，在线免费查询百度前760名关键词排名情况，无需注册，无延迟，查询的是当前的排名，自主研发，如有好的建议可与好宝宝联系，我们将升级工具功能。" />
<link href="/css/css2.css" rel="stylesheet" type="text/css"/>
<script src="/js/jquerym.js" type="text/javascript"></script>
<style type="text/css">
body{font-family:微软雅黑;}
.paiming{height:25px; background-color:#ecf5fb; padding-top:5px; padding-left:5px; margin-top:10px;}
#div_result a{ color:#4e90d4; text-decoration:underline;}
#div_result a:hover{ color:#CD3333; text-decoration::underline;}
</style>
</head>
<body>


<!--头部-->
<!--#include virtual="/userControl/head_utf8.html"-->
<form id="form1" runat="server">

<div style="width:960px;margin:0 auto; margin-top:20px; background:#fff; padding-top:10px; padding-left:10px; height:auto; padding-bottom:10px; min-height:400px;">
<div style="border:#ccc 1px solid; background-color:#fff;  line-height:30px; padding-left:10px; margin-bottom:10px; width:98%;">百度关键词排名查询工具，在线免费查询百度前760名关键词排名情况，无需注册，无延迟，查询的是当前的排名，自主研发，如有好的建议可与好宝宝联系，我们将升级工具功能。</div>
<div>
    <table style="margin:10px 0;"  border="0"  cellpadding="0" cellspacing="0">
    <tr>
    <td style="width:70px; height:40px;">关键词：</td>
    <td><input type="text" name="textfield" id="txt_keyword" style="width:150px; height:20px;border:1px #ccc solid;padding:7px 0 0 3px;" runat="server" value=""/></td>
    <td style="width:30px;"></td>
    <td style="width:80px; height:40px;">输入网址：</td>
    <td><input type="text" name="textfield2" id="txt_url" style="width:200px; height:20px; border:1px #ccc solid;padding:7px 0 0 3px;"  runat="server" value="http://www.up927.com/"/></td>
    <td style="width:20px;"></td>
    <td>
        <asp:ImageButton ID="imgBtnSubmit" 
                ImageUrl="/images/center_chaxun01.gif" runat="server"  OnClientClick="return Valid();"
                onclick="imgBtnSubmit_Click" />
    </td>
    </tr>
    </table>
</div>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">

<ContentTemplate>
<div id="div_result" style="display:none;">
    <%=this.result %>
    <%=this.resultMore%>

<div align="center">
    <asp:LinkButton ID="linkBtnSubmit" runat="server" onclick="linkBtnSubmit_Click" OnClientClick="return ValidMore();" Font-Size="Large">更多</asp:LinkButton>
</div>

</div>

<div id="div_loading" align="center" style="display:none; margin-top:10px;">
<img src="/images/loading.gif" width="50px;" height="50px;"/>
<br />
&nbsp;查询中，请稍后
</div>

</ContentTemplate>

<Triggers>
    <asp:AsyncPostBackTrigger ControlID="imgBtnSubmit" EventName="Click" />
</Triggers>

</asp:UpdatePanel>

<%--<div id="div_result" style="display:none;">
    <%=this.result %>
</div>

<div id="div_loading" >
查询中，请稍后......
<img src="/images/loading.gif"/>
</div>--%>


</div>

<script type="text/javascript">
    function Valid() {
        var keyword = document.getElementById("txt_keyword").value.replace(/(^\s*)|(\s*$)/g, "");
        var url = document.getElementById("txt_url").value.replace(/(^\s*)|(\s*$)/g, "");

        if (keyword == "" || url == "") {
            alert("请输入关键词和网址");
            return false;
        }
        else {
            document.getElementById("div_loading").style.display = "";
            document.getElementById("div_result").style.display = "none";
            return true;
        }
    }

    function ValidMore() {
        var keyword = document.getElementById("txt_keyword").value.replace(/(^\s*)|(\s*$)/g, "");
        var url = document.getElementById("txt_url").value.replace(/(^\s*)|(\s*$)/g, "");

        if (keyword == "" || url == "") {
            alert("请输入关键词和网址");
            return false;
        }
        else {
            document.getElementById("div_loading").style.display = "";
            document.getElementById("linkBtnSubmit").style.display = "none";
            return true;
        }
    }

</script>

<div style="clear:both;"></div>
<!--#include file="/userControl/foot_utf8.html"-->

</form>
</body>
</html>
