<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="MyProject02.template._04" %>
<!doctype html>
<html>
<head runat="server">
<meta charset="utf-8">
<title>哎哟～ 出现404错误页面了～您访问的页面不在地球上_好宝宝早教网</title>
<meta name="description" content=好宝宝网提供<%=this.title%>等分类文章。 />
<meta name="keywords" content="青岛早教,青岛母婴用品,儿童早教,儿童教育" />
<link rel="stylesheet" type="text/css" href="/css/css2.css">
<link rel="stylesheet" type="text/css" href="/css/jquery.slideBox.css">
<script src="/js/jquery-1.8.0.min.js"></script>
<script src="/js/common.js" type="text/javascript"></script>
 <style type="text/css">
.main a{ color:#46a4b0;font-size:18px;}
.main a:hover{color:#ff6699; text-decoration:underline;}
.ul_artlist h3{ font-size:16px;font-family:微软雅黑; font-weight:100;}
.ul_artlist li{ line-height:25px;text-align:center;}
.ul_artlist a{color:#46a4b0;font-size:18px;}
.ul_artlist a:hover{color:#ff6699; text-decoration:underline;}
</style>
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

<!--内容部分-->
<div class="container">
	<!--左侧-->
	<div class="content_left shadow_right">
        
        <div class="content_art" style="padding-top:5px; padding-bottom:19px;">
            <div class="main">
            <span style="display:block; height:40px; font-size:18px; color:#ff8a00; text-align:center;">哎哟～网页打开错啦！</span>
            <span style="display:block; height:40px; font-size:18px; color:#ff8a00; text-align:center;">先玩玩这个游戏！再看看好宝宝早教网的其他 <a href="http://www.up927.com/">精彩文章</a>！然后重新打开页面吧！</span>
            <span style="display:block; height:30px; font-size:18px; color:#36648B; text-align:center;">游戏玩法：将猫困在一个深色原点围成的圈子里面就算成功了~</span>
            <div align="center">
                <embed allowScriptAccess="never" allowNetworking="internal" autostart="0"   ALIGN="l" SRC="/js/swf/up927_zhuamao.swf" WIDTH="600" HEIGHT="400" TYPE="application/x-shockwave-flash" FLASHVARS="width=600&amp;height=400" SCALE="noborder" QUALITY="high" WMODE="transparent" STYLE="font-family: Arial, sans-serif;"></EMBED>
            </div>
            </div>

            <div class="main1">
            <span style="display:block; height:40px; font-size:22px; color:#ff8a00; text-align:center;">游戏有点难？先看看下面这些文章，回头再挑战！</span>
            <ul class="ul_artlist">
                <asp:Repeater ID="repList" runat="server" >
                    <ItemTemplate>
                        <li><a href="http://www.up927.com/<%#(Eval("html"))%>" target="_blank" title='<%#(Eval("title"))%>'><%#Eval("title").ToString()%></a></li>
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
