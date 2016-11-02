<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="image_list.aspx.cs" Inherits="MyProject02.xzdd927.article.image_list" %>
<%@ Register src="/userControl/PagerControl.ascx" tagname="PagerControl" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title></title>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

<script src="/js/calendar/WebCalendar.js" type="text/javascript"></script>
<link href="/css/calendar/WebCalendar.css" rel="stylesheet" type="text/css" />
<link href="/css/bianji_ht.css/bianji_ht.css" rel="stylesheet" type="text/css" />
<link href="/css/bianji_ht.css/bianji_top.css" rel="stylesheet" type="text/css" />
<link href="/css/bianji_ht.css/shenfen.css" rel="stylesheet" type="text/css" />
<link href="/css/fye.css" rel="stylesheet" type="text/css" />

<%--<script src="/js/manage_common.js" type="text/javascript"></script>--%>
<script src="/js/jquerym.js" type="text/javascript"></script>
<style type="text/css">
<!--
body { margin:0; font-size:12px; color:#666;}
/*td{ padding-left:10px;}*/
table{ margin-top:10px;}.f12b_333{ color:#333; font-size:12px; font-weight:bold;}.f12_red{ font-size:12px; color:#FF0000;}
p{ padding:0; margin:0; line-height:24px;}
.b_box002{background:#ffffe3;border:1px solid #ffcc99; width:220px;line-height:24px; padding:10px; }
.b_box002 td{ padding-right:5px; border-right:1px solid #ffffe3;}
.coles01{background:url(/images/bianji_ht_images/ui_items.png) no-repeat -23px -43px;height:6px;width:6px; float:right;cursor:pointer;}
-->
.bgLayer{background:#444;filter: alpha(opacity=15);	left:0px;width:100%;position: absolute;	top: 0px;moz-opacity: 0.6;opacity: 0.6;}
#divRepayInfo{position: absolute;}
</style>

<script type="text/javascript">
function SelectArticle()
{
    var update_date_min=document.getElementById("txt_update_date_min").value;
    var update_date_max=document.getElementById("txt_update_date_max").value;
    var html = document.getElementById("txt_html").value;

    var where = "?a=1";
    if (html != "") {
        where += "&html=" + html;
    }
    if(update_date_min!="")
    {
        where+="&dateMin="+update_date_min;
    }
    if(update_date_max!="")
    {
        where+="&dateMax="+update_date_max;
    }

    window.location.href = "/xzdd927/article/image_list.aspx" + where;
}

function OpenImg(src) {
    window.open(src.replace("100_100_", ""), "n");
}

</script>
</head>
<body>
<form id="form1" runat="server">
<div>
    <table>
        <tr>
            <td height="30" align="left">
                页面名称：<input type="text" name="textfield2" id="txt_html" runat="server"/>
            </td>
            <td >&nbsp;&nbsp;发布时间：
              <input  name="" type="text" style="color:#666;cursor: pointer;" value="" size="7" onclick="__Calendar__.show(this, {})" readonly="readonly" id="txt_update_date_min" runat="server" onkeypress=" if(event.keyCode==13) return false;"/>
              -
              <input  name="" type="text" style="color:#666;cursor: pointer;" value="" size="7" onclick="__Calendar__.show(this, {})" readonly="readonly" id="txt_update_date_max" runat="server" onkeypress=" if(event.keyCode==13) return false;"/>
            </td>
            <td align="center">
                <a href="javascript:void(0)" onclick="SelectArticle()"><img src="/images/bianji_ht_images/bj_sousuo_tu01.gif"/></a>
            </td>
            <td align="left">
                &nbsp;<a href="/xzdd927/article/image_list.aspx"><img src="/images/bianji_ht_images/bj_congzhi_tu01.gif"/></a>
            </td>
        </tr>
    </table>
</div>
<div style=" clear:both;"></div>
<div align="center" width="980" style=" margin-bottom:100px;">
共查询出<asp:Label ID="labInfoCount" runat="server" Text="0"></asp:Label>条信息
<br />
    <asp:Repeater ID="repList_Img" runat="server">
        <ItemTemplate>
            <table align="center" cellspacing="0" cellpadding="0" style="float:left;border-collapse:collapse;"  cellspacing="0" cellpadding="0"  border="1" bordercolor="#a0c6e5" >
              <tr>
                <td align="center" valign="middle" style="border: solid 1px #0100; margin-left:10px;">
                    <img src='/Article_File/af/<%#Eval("pic")%>' style="cursor:pointer;" onclick="OpenImg(this.src)" complete="complete" height="100" width="100" alt='<%#Eval("title")%>' title="<%#Eval("title")%>" />
                </td>
              </tr>
            </table>
        </ItemTemplate>
     </asp:Repeater>
</div>
<br />
<div style=" clear:both;"></div>
<div id="divFenye" runat="server" class="ye">
    <div class="imos_pagebox" style=" margin-top:3px; text-align:center;"  align="center">
        
        <uc1:PagerControl ID="pager" ShowGo="true" runat="server" />
        
    </div><!--fye end-->
</div>
 
</form>
</body>
</html>
