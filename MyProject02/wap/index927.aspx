<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index927.aspx.cs" Inherits="MyProject02.wap.index927" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width,minimum-scale=1.0, maximum-scale=1.0"/>
<title>好宝宝</title>
<link href="/wap/html5/main.css" rel="stylesheet" type="text/css" />
<script src="/wap/js/common.js" type="text/javascript"></script>
</head>
<body>
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


<div class="top_div">
<h2><a href="#" name="gototop"></a></h2>
<h1>好宝宝</h1>
<br class="clearfloat" />
</div>

<div class="div_title">
<h2><a href="/wap/list.aspx?a_t=2">母婴知识</a></h2>
</div>
<ul class="ul_list">
<asp:Repeater ID="repList2" runat="server" >
    <ItemTemplate>
            <li><a href="/wap<%#(Eval("html"))%>"><%#GetPartContent(Eval("title").ToString(), 18)%></a></li>
        </ItemTemplate>
</asp:Repeater>
</ul>
<div class="div_title">
<h2><a href="/wap/list.aspx?a_t=3">儿童教育</a></h2>
</div>
<ul class="ul_list">
<asp:Repeater ID="repList3" runat="server" >
    <ItemTemplate>
            <li><a href="/wap<%#(Eval("html"))%>"><%#GetPartContent(Eval("title").ToString(), 18)%></a></li>
        </ItemTemplate>
</asp:Repeater>
</ul>
<div class="div_title">
<h2><a href="/wap/list.aspx?a_t=4">育儿知识</a></h2>
</div>
<ul class="ul_list">
<asp:Repeater ID="repList4" runat="server" >
    <ItemTemplate>
            <li><a href="/wap<%#(Eval("html"))%>"><%#GetPartContent(Eval("title").ToString(), 18)%></a></li>
        </ItemTemplate>
</asp:Repeater>
</ul>
<div class="div_title">
<h2><a href="/wap/list.aspx?a_t=5">生活常识</a></h2>
</div>
<ul class="ul_list">
<asp:Repeater ID="repList5" runat="server" >
    <ItemTemplate>
            <li><a href="/wap<%#(Eval("html"))%>"><%#GetPartContent(Eval("title").ToString(), 18)%></a></li>
        </ItemTemplate>
</asp:Repeater>
</ul>
<div class="div_title">
<h2><a href="/wap/list.aspx?a_t=6">轻松一刻</a></h2>
</div>
<ul class="ul_list">
<asp:Repeater ID="repList6" runat="server" >
    <ItemTemplate>
            <li><a href="/wap<%#(Eval("html"))%>"><%#GetPartContent(Eval("title").ToString(), 18)%></a></li>
        </ItemTemplate>
</asp:Repeater>
</ul>
<div class="div_title">
<h2><a href="/wap/list.aspx?a_t=7">谈天说地</a></h2>
</div>
<ul class="ul_list">
<asp:Repeater ID="repList7" runat="server" >
    <ItemTemplate>
            <li><a href="/wap<%#(Eval("html"))%>"><%#GetPartContent(Eval("title").ToString(), 18)%></a></li>
        </ItemTemplate>
</asp:Repeater>
</ul>
<div class="ad_foot">
</div>
<div class="foot_div">
<div class="foot_flower">
    <a href="#gototop">回顶部</a>
</div>
<div class="counter">
</div>
<div class="footer mt10 tc">
  <p class="phone">欢迎访问  &nbsp;<a href="/wap/index.html"><b style="color:#000;">好宝宝</b></a></p>
  <p class="phone">www.up927.com</p>
  <p class="phone">站长QQ：1056625972</p>
  <p class="phone">邮箱：1056625972@qq.com</p>
  <p class="phone">鲁ICP备15001975号</p>
</div>

</div>
</body>
</html>
