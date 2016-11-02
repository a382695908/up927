<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_list.aspx.cs" Inherits="MyProject02.xzdd927.admin.admin_list" %>
<%@ Register src="/userControl/PagerControl.ascx" tagname="PagerControl" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>文章列表页</title>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

<script src="/js/calendar/WebCalendar.js" type="text/javascript"></script>
<link href="/css/calendar/WebCalendar.css" rel="stylesheet" type="text/css" />
<link href="/css/bianji_ht.css/bianji_ht.css" rel="stylesheet" type="text/css" />
<link href="/css/bianji_ht.css/bianji_top.css" rel="stylesheet" type="text/css" />
<link href="/css/bianji_ht.css/shenfen.css" rel="stylesheet" type="text/css" />
<link href="/css/fye.css" rel="stylesheet" type="text/css" />

<script src="/js/manage_common.js" type="text/javascript"></script>
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

</script>
</head>
<body>
<form id="form1" runat="server">
<div style=" width:960px; margin:0 auto;">
</br>
<a href="/xzdd927/admin/update_admin.aspx">添加人员</a>

<div id="divInfoList" runat="server" class="bj_r_03">
<asp:Repeater ID="repList" runat="server" OnItemCommand="repList_ItemCommand">
<HeaderTemplate>
<table border="0" cellspacing="0">
  <tr>
    <td class="bj_bd_bg" style="width:60px; height:30px;">
        ID    </td>
    <td class="bj_bd_bg" style="width:150px;">
        登录名    </td>
    <td class="bj_bd_bg" style="width:150px;">
        密码 </td>
    <td class="bj_bd_bg" style="width:200px;">
        备注   </td>
    <td class="bj_bd_bg" style="width:70px;">
        操作    </td>
  </tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
    <td style="height:50px;"><div align="center">
        <%#(Eval("id"))%>
    </div></td>
    <td style="width:150px;"><div align="center"><a href="/xzdd927/admin/update_admin.aspx?admin_id=<%#(Eval("id"))%>" title="<%#(Eval("name"))%>"><%#GetPartContent(Eval("name").ToString(), 20)%></a></div></td>
    <td style="width:150px;" align="center"><div align="center" title="<%#GetPwd(Eval("pwd").ToString())%>">&nbsp;<%#GetPwd(Eval("pwd").ToString())%>&nbsp;</div></td>
    <td style="width:200px;"><div align="center" title="<%#(Eval("remark"))%>">&nbsp;<%#GetPartContent(Eval("remark").ToString(), 20)%>&nbsp;</div></td>
    <td style="width:70px;">
        <div align="center"> 
            <a href='/xzdd927/admin/update_admin.aspx?admin_id=<%#(Eval("id"))%>'>修改</a> 
            <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%#Eval("id")%>'  OnClientClick="javascript:return confirm('确定要删除吗?');" >删除</asp:LinkButton>
        </div>
    </td>
  </tr>
</ItemTemplate>
<AlternatingItemTemplate>
<tr style="background:#EFF2F7;">
    <td style="height:50px;"><div align="center">
        <%#(Eval("id"))%>
    </div></td>
    <td style="width:150px;"><div align="center"><a href="/xzdd927/admin/update_admin.aspx?admin_id=<%#(Eval("id"))%>" title="<%#(Eval("name"))%>"><%#GetPartContent(Eval("name").ToString(), 20)%></a></div></td>
    <td style="width:150px;" align="center"><div align="center" title="<%#GetPwd(Eval("pwd").ToString())%>">&nbsp;<%#GetPwd(Eval("pwd").ToString())%>&nbsp;</div></td>
    <td style="width:200px;"><div align="center" title="<%#(Eval("remark"))%>">&nbsp;<%#GetPartContent(Eval("remark").ToString(), 20)%>&nbsp;</div></td>
    <td style="width:70px;">
        <div align="center"> 
            <a href='/xzdd927/admin/update_admin.aspx?admin_id=<%#(Eval("id"))%>'>修改</a> 
            <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%#Eval("id")%>'  OnClientClick="javascript:return confirm('确定要删除吗?');" >删除</asp:LinkButton>
        </div>
    </td>
  </tr>
</AlternatingItemTemplate>
<FooterTemplate>
    </table>
</FooterTemplate>
</asp:Repeater>

<div id="divFenye" runat="server" class="ye">
    <div class="imos_pagebox" style=" margin-top:3px; text-align:center;"  align="center">
        
        <uc1:PagerControl ID="pager" ShowGo="true" runat="server" />
        
    </div><!--fye end-->
 </div>
 </div>

</div>
</form>
</body>
</html>
