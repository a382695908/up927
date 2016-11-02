<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tagList.aspx.cs" Inherits="MyProject02.tagList" EnableViewState="false"%>
<%@ Register src="/userControl/PagerControl.ascx" tagname="PagerControl" tagprefix="uc1" %>
<!doctype html>
<html>
<head runat="server">
<meta charset="utf-8">
<title>儿童教育百科_好宝宝早教网</title>
<meta name="description" content=好宝宝网提供<%=this.title%>等分类文章。 />
<meta name="keywords" content="青岛早教,青岛母婴用品,儿童早教,儿童教育" />
<link rel="stylesheet" type="text/css" href="/css/css2.css">
<link href="/css/fye.css" rel="stylesheet" type="text/css" />
<script src="/js/jquery-1.8.0.min.js"></script>
<script src="/js/common.js" type="text/javascript"></script>
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
<!--#include file="/userControl/head_utf8.html"-->
<div class="container">
	<!--左侧-->
	<div class="content_left shadow_right">
    	<div class="content_nav">
        	<a href="http://www.up927.com/">好宝宝早教网</a><span>></span><span>儿童教育百科</span>
            <div class="content_nav_border"></div>
        </div>
        
        <div class="content_art" style="padding-top:5px; padding-bottom:15px;">
            <div class="tag_list">
            <ul>
            <asp:Repeater ID="repList" runat="server">
                <ItemTemplate>
                    <li><a href="http://www.up927.com/list.aspx?tag=<%#(Eval("id"))%>" target="_blank"><%#(Eval("tag_name"))%>（<%#(Eval("article_num"))%>）</a></li>
                </ItemTemplate>
            </asp:Repeater>
            <li><a href="http://www.up927.com/tools/shengxiao.shtml" target="_blank">12生肖运势</a></li>
            <li><a href="http://www.up927.com/tools/yuchanqi/" target="_blank">预产期计算器</a></li>
            <li><a href="http://www.up927.com/tools/yuejing/" target="_blank">月经周期计算器</a></li>
            </ul>
            </div>
            <div style=" height:12px;"></div>
            <div id="divFenye" runat="server" class="ye">
            <div class="imos_pagebox" style=" margin-top:3px; text-align:center;"  align="center">
            <uc1:PagerControl ID="pager" ShowGo="true" runat="server" />
            </div>
            </div> 
        </div>

        
        
        
    </div>
    
        <!--右侧-->
        <!--#include file="/userControl/Side_2.html"-->
        <div style="clear:both;"></div>
        
    
</div>

<div style="clear:both;"></div>
<!--#include file="/userControl/foot_utf8.html"-->
</body>
</html>
