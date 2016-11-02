<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="MyProject02.list" EnableViewState="false" %>
<%@ Register src="/userControl/PagerControl.ascx" tagname="PagerControl" tagprefix="uc1" %>
<!doctype html>
<html>
<head runat="server">
<meta charset="utf-8">
<title><%=this.html_title %></title>
<meta name="keywords" content=<%=this.keywords%> />
<meta name="description" content=<%=this.description%> />
<link rel="stylesheet" type="text/css" href="/css/css2.css?v=8">
<link href="/css/fye.css" rel="stylesheet" type="text/css" />
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
<input id="hid_type" type="hidden" value="" runat="server" />
<!--#include file="/userControl/head_top.html"-->
<!--#include file="/userControl/head_utf8.html"-->
<!--内容部分-->
<div class="container">
	<!--左侧-->
	<div class="content_left shadow_right">
    	<div class="content_nav">
        	<span>好宝宝早教网</span><span>></span><span><%=this.tishi %></span>
            <div class="content_nav_border"></div>
        </div>
        
        <div class="content_art" style="padding-top:5px; padding-bottom:15px;">
        <div id="div_miaoshu" runat="server" visible="false" style=" margin-left:20px; margin-bottom:20px;">
            <div style=" float:left; margin-top:5px;">
                <img src="http://www.up927.com/Article_File/tf/<%=this.miaoshu_pic %>" width="240" height="185" alt="<%=this.miaoshu_title%>_好宝宝早教网"/>
            </div>
            <div class="list_miaoshu">
                <h2><%=this.miaoshu_title%></h2>
                <%=this.miaoshu %>
            </div>
            <div style=" clear:both;"></div>
        </div>
        
            <asp:Repeater ID="repList1" runat="server">
                <ItemTemplate>
                    <div class="list_art">
            	        <h3><a href="http://www.up927.com<%#(Eval("html"))%>" target="_blank"><%#GetPartContent(Eval("title").ToString(), 25)%></a></h3>
                        <span>发布：毛豆妈咪</span>
                        <span>分类：<a href='http://www.up927.com/list.aspx?at=<%#(Eval("type"))%>' target="_blank"><%#(Eval("type_name"))%></a></span> 
                        <span><%#GetTag(Eval("tag_name").ToString(), Eval("tag_id").ToString())%></span>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div style=" height:12px;"></div>
            <div id="divFenye" runat="server" class="ye">
            <div class="imos_pagebox" style=" margin-top:3px; text-align:center;"  align="center">
            <uc1:PagerControl ID="pager" ShowGo="true" runat="server" />
            </div>
            </div>
            
            
            <div id="div_nonews1" runat="server" visible="false" class="newslist">
            <div class="main">
            <span style="display:block; height:40px; font-size:18px;font-family:微软雅黑; color:#ff8a00; text-align:center;">哎哟～木有找到您搜索的文章呢！</span>
            <span style="display:block; height:40px; font-size:18px;font-family:微软雅黑; color:#ff8a00; text-align:center;">先玩玩这个游戏！再看看好宝宝早教网的其他 <a href="http://www.up927.com/">精彩文章</a>！然后重新打开页面吧！</span>
            <span style="display:block; height:30px; font-size:18px;font-family:微软雅黑; color:#36648B; text-align:center;">游戏玩法：将猫困在一个深色原点围成的圈子里面就算成功了~</span>
            <div align="center">
            <embed allowScriptAccess="never" allowNetworking="internal" autostart="0"   ALIGN="l" SRC="/js/swf/up927_zhuamao.swf" WIDTH="600" HEIGHT="400" TYPE="application/x-shockwave-flash" FLASHVARS="width=600&amp;height=400" SCALE="noborder" QUALITY="high" WMODE="transparent" STYLE="font-family: Arial, sans-serif;"></EMBED>
            </div>
            </div>
            </div>

            <style type="text/css">
            .main a{ color:#46a4b0;font-size:18px;}
            .main a:hover{color:#ff6699; text-decoration:underline;}
            .ul_artlist h3{ font-size:16px;font-family:微软雅黑; font-weight:100;}
            .ul_artlist li{ line-height:25px;text-align:center;}
            .ul_artlist a{color:#46a4b0;font-size:18px;}
            .ul_artlist a:hover{color:#ff6699; text-decoration:underline;}
            </style>

            <div id="div_nonews2" runat="server" visible="false" class="newslist">
            <span style="display:block; height:40px; font-size:22px; font-weight:bold; color:#ff8a00; text-align:center;">游戏有点难？先看看下面这些文章，回头再挑战！</span>
            <ul class="ul_artlist">
            <asp:Repeater ID="repList2" runat="server"  >
            <ItemTemplate>
                <li><h3><a href="http://www.up927.com/<%#(Eval("html"))%>" target="_blank" title='<%#(Eval("title"))%>'><%#(Eval("title"))%></a></h3></li>
            </ItemTemplate>
            </asp:Repeater>
            </ul>
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


