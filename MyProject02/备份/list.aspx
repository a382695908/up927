<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="MyProject02.list" EnableViewState="false" %>
<%@ Register src="/userControl/PagerControl.ascx" tagname="PagerControl" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<link rel="shortcut icon" href="/favicon.ico" />
<link rel="bookmark" href="/favicon.ico" type="image/x-icon"　/>
<title><%=this.html_title %></title>
<meta name="keywords" content='<%=this.keywords%>' />
<meta name="description" content='<%=this.description%>' />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link href="/css/css.css" rel="stylesheet" type="text/css" />
<link href="/css/fye.css" rel="stylesheet" type="text/css" />
<script src="/js/common.js" type="text/javascript"></script>
<%--百度统计代码--%>
<script>
var _hmt = _hmt || [];
(function() {
  var hm = document.createElement("script");
  hm.src = "//hm.baidu.com/hm.js?138a328660e33c71bad7bfcceaa1e08f";
  var s = document.getElementsByTagName("script")[0]; 
  s.parentNode.insertBefore(hm, s);
})();
</script>

</head>
<body>
<form id="form1" runat="server">
<!--#include virtual="/userControl/head_top.html"-->
<!--#include virtual="/userControl/inner_head_utf8.html"-->

<div style="width:960px;">
<div class="newslist">
<div id="div_tishi" runat="server" style="height:38px; line-height:38px; padding-top:3px; font-family:微软雅黑; font-size:21px;border-bottom:1px dashed  #3d85c6;" align="center" visible="true">
    【<%=this.tishi%>】相关文章
</div>
<asp:Repeater ID="repList1" runat="server" >
<ItemTemplate>
<dl>
   <dt>
    <h1><span class="span_type" ><a href='/list.aspx?at=<%#(Eval("type"))%>' target="_blank"><%#(Eval("type_name"))%></a></span><a href="<%#(Eval("html"))%>" target="_blank" title='<%#(Eval("title"))%>'><%#GetPartContent(Eval("title").ToString(), 25)%></a></h1>
    <h3>发布：好宝宝&nbsp;&nbsp;&nbsp;&nbsp;发布时间：<%# Convert.ToDateTime(Eval("update_date")).ToString("yyyy年M月d日")%>&nbsp;&nbsp;&nbsp;&nbsp;<%#GetTag(Eval("tag").ToString(), Eval("tag_id").ToString())%></h3>
   </dt>
   <dd class="preview" style="float:left; margin-left:20px;">
   <a href="<%#(Eval("html"))%>" target="_blank" title='<%#(Eval("title"))%>' style=' display:<%#GetImgShow(Eval("pic").ToString())%>'><img src="/Article_File/af/100_100_<%#GetPic(Eval("pic").ToString())%>" style="float:left;" alt="<%#(Eval("title"))%>_<%#(Eval("type_name"))%>_好宝宝网"/></a>
   <%#GetDaoyu(Eval("daoyu").ToString(), Eval("content").ToString(),130)%>
   <a href="<%#(Eval("html"))%>" target="_blank" title='<%#(Eval("title"))%>'>阅读全文>></a>
   </dd>
   <dd class="info"></dd>
</dl>

</ItemTemplate>
</asp:Repeater>

<div id="divFenye" runat="server" class="ye">
<div class="imos_pagebox" style=" margin-top:3px; text-align:center;"  align="center">
<uc1:PagerControl ID="pager" ShowGo="true" runat="server" />
</div>
</div>

</div>

<%--<div id="div_search">
<div id="s"> 
    <input type="text" id="txt_search" value="输入文章标题" class="swap_value" style="color:#575757;" onfocus="SetSearch(this)" onblur="SetSearch(this)" runat="server" /> 
</div>
<div id="go"> 
    <div class="btnSearch">搜索</div>
</div>
</div>
<div id="side">
 <div class="m">
   <h3>联系我们</h3>
     <div style="float:left;"><img src="/images/100_100_1.jpg" class="headimg" /></div>
     <div style="float:left;">
     <ul>
     <li style="font-size:14px; list-style-image:none; margin-left:0px;color:#6e6e6e;">QQ：1056625972</li>
     <li style="font-size:12px; list-style-image:none; margin-left:0px;color:#6e6e6e;">1056625972@qq.com</li>
     </ul>
     </div>
     <div style="clear:both; height:5px;"></div>
 </div>
 
 <div class="m">
   <h3>栏目分类</h3>
   <div id="div_type_right">
    <ul>
        <asp:Repeater ID="repList2" runat="server" >
            <ItemTemplate>
                <li><a href='/list.aspx?at=<%#(Eval("id"))%>'><%#(Eval("type_name"))%></a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    </div>
    <div style="clear:both; height:5px;"></div>
 </div>

<div class="m">
<h3>热门文章</h3>
    <ul>
         <asp:Repeater ID="repList3" runat="server" >
            <ItemTemplate>
                <li><a href="<%#(Eval("html"))%>" target="_blank" title='<%#(Eval("title"))%>'><%#GetPartContent(Eval("title").ToString(), 15)%></a></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
 </div>
<div class="m">
   <h3>最新留言</h3>
    <ul>
        <li>·<a href='Show.aspx?id=13' title='IP和子网掩码，再不会，我砍你！'>IP和子网掩码，再不会，我砍你！</a></li>
        
        <li>·<a href='Show.aspx?id=2' title='F8加密工具+登录界面替换工具绿色的哦'>F8加密工具+登录界面替换工具绿色的哦</a></li>
        
        <li>·<a href='Show.aspx?id=4' title='SuperCache（超级缓存）汉化破解版'>SuperCache（超级缓存）汉化破解</a></li>
        
        <li>·<a href='Show.aspx?id=27' title='C#大图中找小图的一个类'>C#大图中找小图的一个类</a></li>
        
        <li>·<a href='Show.aspx?id=6' title='"突然的自我"更换鼠标右键背景'>"突然的自我"更换鼠标右键背景</a></li>
        
        <li>·<a href='Show.aspx?id=9' title='千个常用DOS命令全面收藏'>千个常用DOS命令全面收藏</a></li>
    </ul>
 </div>
</div>--%>

<!--#include file="/userControl/Side.html"-->

</div>

<div style="clear:both;"></div>

<!--#include file="/userControl/news_foot_utf8.html"-->

</form>
</body>
</html>
