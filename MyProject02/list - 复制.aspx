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
<!--百度提交代码-->
<script>
(function(){
    var bp = document.createElement('script');
    bp.src = '//push.zhanzhang.baidu.com/push.js';
    var s = document.getElementsByTagName("script")[0];
    s.parentNode.insertBefore(bp, s);
})();
</script>
<style type="text/css" />
#div_tishi h2{font-family:微软雅黑; font-size:21px;font-weight:normal;}
.hh1 h1{color:#87CEEB;font:700 18px/30px Verdana,Arial}
</style>
</head>
<body>
<form id="form1" runat="server">
<!--#include virtual="/userControl/head_top.html"-->
<div class="hh1" align="center">
    <h1>青岛早教|青岛母婴用品|母婴知识|儿童早教|儿童教育|好宝宝网</h1>
</div>
<!--#include virtual="/userControl/inner_head_utf8.html"-->

<div style="width:960px;">
<div class="newslist">

<div id="div_nav" runat="server" visible="false" style=" margin:5px auto auto 20px;font-family:微软雅黑; font-size:18px;">
    <a href="http://www.up927.com/">好宝宝</a> > <%=this.tishi%>
</div>

<div id="div_tishi" runat="server" style="height:38px; line-height:38px;  padding-top:3px; font-family:微软雅黑; font-size:21px;border-bottom:1px dashed  #3d85c6;" align="center" visible="true">
    <h2>【<%=this.tishi%>】相关文章</h2>
</div>

<div id="div_news" runat="server" visible="false">
<asp:Repeater ID="repList1" runat="server" OnItemDataBound="repList1_ItemDataBound">
<ItemTemplate>
<dl>
   <dt class="shadow">
    <h4 class="type_name" style="float:left;"><a href='/list.aspx?at=<%#(Eval("type"))%>' target="_blank"><%#(Eval("type_name"))%></a></h4> 
    <h3 style="float:left;"> <a href="<%#(Eval("html"))%>" target="_blank" title='<%#(Eval("title"))%>'><%#GetPartContent(Eval("title").ToString(), 25)%></a></h3>
    <div style=" clear:both;"></div>
    <h5>发布：好宝宝&nbsp;&nbsp;&nbsp;&nbsp;发布时间：<%# Convert.ToDateTime(Eval("update_date")).ToString("yyyy年M月d日")%>&nbsp;&nbsp;&nbsp;&nbsp;<%#GetTag(Eval("tag").ToString(),Eval("tag_id").ToString())%></h5>
   </dt>
   <dd class="preview" style="float:left; margin-left:20px;">
   <asp:HyperLink ID="hl_artImg" runat="server" NavigateUrl='http://www.up927.com<%#(Eval("html"))%>' Target="_blank">
        <img src="http://www.up927.com/Article_File/af/<%#GetPic(Eval("pic").ToString())%>" style="float:left;" alt="<%#(Eval("title"))%>_<%#(Eval("type_name"))%>_好宝宝网" />
    </asp:HyperLink>
   <%--<a class="blogs" href="<%#(Eval("html"))%>" target="_blank" title='<%#(Eval("title"))%>' style=' display:<%#GetImgShow(Eval("pic").ToString())%>'>
        <img src="/Article_File/af/100_100_<%#GetPic(Eval("pic").ToString())%>" style="float:left;" alt="<%#(Eval("title"))%>_<%#(Eval("type_name"))%>_好宝宝网" />
   </a>--%>
   <p><%#GetDaoyu(Eval("daoyu").ToString(), Eval("content").ToString(),100)%></p>
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


<div id="div_nonews1" runat="server" visible="false" class="newslist" style="margin-top:20px;">
    <div class="main">
    <span style="display:block; height:40px; font-size:18px;font-family:微软雅黑; color:#ff8a00; text-align:center;">哎哟～木有找到您搜索的文章呢！</span>
    <span style="display:block; height:40px; font-size:18px;font-family:微软雅黑; color:#ff8a00; text-align:center;">先玩玩这个游戏！再看看好宝宝的其他 <a href="http://www.up927.com/">精彩文章</a>！然后重新打开页面吧！</span>
    <span style="display:block; height:30px; font-size:18px;font-family:微软雅黑; color:#36648B; text-align:center;">游戏玩法：将猫困在一个深色原点围成的圈子里面就算成功了~</span>
    <div align="center">
        <embed allowScriptAccess="never" allowNetworking="internal" autostart="0"   ALIGN="l" SRC="/js/swf/up927_zhuamao.swf" WIDTH="600" HEIGHT="400" TYPE="application/x-shockwave-flash" FLASHVARS="width=600&amp;height=400" SCALE="noborder" QUALITY="high" WMODE="transparent" STYLE="font-family: Arial, sans-serif;"></EMBED>
    </div>
    </div>
</div>

<style type="text/css">
.ul_artlist h3{ font-size:16px;font-family:微软雅黑;}
.ul_artlist li{ line-height:24px;text-align:center;}
</style>

<div id="div_nonews2" runat="server" visible="false" class="newslist" style="margin-top:20px;">
    <span style="display:block; height:40px; font-size:22px; font-weight:bold; color:#ff8a00; text-align:center;">游戏有点难？先看看下面这些文章，回头再挑战！</span>
    <ul class="ul_artlist">
        <asp:Repeater ID="repList2" runat="server"  >
            <ItemTemplate>
                <li><h3><a href="<%#(Eval("html"))%>" target="_blank" title='<%#(Eval("title"))%>'><%#(Eval("title"))%></a></h3></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>


</div>

<%--<style type="text/css">

.main {border-radius:5px; width:900px; margin:70px auto;}
.ok_buttom { font-size:16px; color:#fff; text-decoration:none; padding:5px 30px; background:#d58200;}
.ok_buttom:hover {background:#f0681e;}
.main a{font-size:22px; color:#ff8a00; text-decoration:underline;line-height:24px; letter-spacing:1px;}
.main a:hover{  color:#CD2626;   text-decoration:underline;}

.main1 {border-radius:5px; width:900px; }
.ul_artlist{ margin-left:200px;}
.ul_artlist li{height:30px; font-size:20px; color:#36648B; }
.ul_artlist a{font-size:18px; color:#36648B; text-decoration:underline;line-height:24px; letter-spacing:1px;}
.ul_artlist a:hover{  color:#CD2626;   text-decoration:underline;}

/*网站底部*/
.div_foot{ font-family:"微软雅黑";font-size:14px; margin-top:10px; margin-bottom:5px; padding-top:5px; border-top:1px dashed #ccc;}
.div_foot ul li{ line-height:19px; color:#575757; list-style:none;}
.div_foot ul li a{color:#575757;text-decoration:none;}
.div_foot ul li a:hover{color:#BA2636;text-decoration: underline;}
</style>--%>


<!--#include file="/userControl/Side.html"-->

</div>

<div style="clear:both;"></div>

<!--#include file="/userControl/news_foot_utf8.html"-->

</form>
</body>
</html>
