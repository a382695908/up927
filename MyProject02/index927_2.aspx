<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index927_2.aspx.cs" Inherits="MyProject02.index927_2" EnableViewState="false" %>
<!doctype html>
<html>
<head runat="server">
<link rel="shortcut icon" href="/favicon.ico" />
<link rel="bookmark" href="/favicon.ico" type="image/x-icon"　/>
<meta charset="utf-8">
<title>青岛早教|儿童早教|育儿知识|好宝宝早教网</title>
<meta name="description" content=好宝宝网提供<%=this.title%>等分类文章。 />
<meta name="keywords" content="青岛早教,青岛母婴用品,儿童早教,儿童教育,教育资讯" />
<link rel="stylesheet" type="text/css" href="/css/css2.css?v=8">
<link rel="stylesheet" type="text/css" href="http://www.up927.com/css/jquery.slideBox.css">
</head>
<body>
<input id="hid_type" type="hidden" value="0" />
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
<!--#include file="/userControl/head_top.html"-->
<!--#include file="/userControl/head_utf8.html"-->

<!--内容部分-->
<div class="container">
	<div class="container_per">
    	<div class="top_tools shadow_left">
        	<div class="top_tools_title"><h3>育儿工具导航</h3></div>
            <div class="top_tools_nav">
                <a href="http://www.up927.com/tools/yuchanqi/" target="_blank">预产期计算器</a>
                <a href="http://www.up927.com/tools/shengao/" target="_blank">孩子身高预测</a>
                <a href="http://www.up927.com/tools/yuejing/" target="_blank">月经周期计算器</a>
                <a href="http://www.up927.com/tools/yuejing/" target="_blank">排卵期计算器</a>
            	<a href="http://www.up927.com/tools/xingzuo.shtml" target="_blank">宝宝12星座运势</a>
                <a href="http://www.up927.com/tools/shengxiao.shtml" target="_blank">宝宝12生肖运势</a>
            </div>
        </div>
        <div class="per_banner">
            <div id="demo1" class="slideBox">
              <ul class="items">
              <li><a href="http://www.up927.com/zhuanti/renshenwen" title="帮助孕妈认识可怕的妊娠纹" target="_blank"><img src="http://www.up927.com/Article_File/hd1/art_hd1_001.jpg" width="600" height="250" alt="如何预防妊娠纹_好宝宝早教网"></a></li>
              <li><a href="http://www.up927.com/art/1181761.shtml" title="青岛早教机构史上最全推荐！" target="_blank"><img src="http://www.up927.com/Article_File/hd1/art_hd1_003.jpg" width="600" height="250" alt="青岛早教机构史上最全推荐_好宝宝早教网"></a></li>
                <li><a href="http://www.up927.com/zhuanti/yanshi/" title="小儿厌食怎么办？" target="_blank"><img src="http://www.up927.com/Article_File/hd1/art_hd1_002.jpg" width="600" height="250" alt="小儿厌食怎么办_好宝宝早教网"></a></li>
                
                <asp:Repeater ID="repList_hd" runat="server" >
                <ItemTemplate>
                    <li><a href="http://www.up927.com<%#(Eval("html"))%>" title="<%#GetPartContent(Eval("title").ToString(), 21)%>" target="_blank"><img src="http://www.up927.com/Article_File/hd1/<%#(Eval("huandeng1_pic"))%>" alt='<%#(Eval("title"))%>_好宝宝早教网' width="600" height="250"></a></li>
                </ItemTemplate>
                </asp:Repeater>
              </ul>
            </div>
        </div>
        <div class="slide_about shadow_right" style=" position:relative;">
            <a href="http://www.up927.com/tools/shengao/" target="_blank"><img src="/images/shengao.jpg" alt="孩子身高预测"/></a>
            <div class="title_bar">
                <div class="title_bar_a"><a href="http://www.up927.com/tools/shengao/" target="_blank">测测你的孩子能长多高？</a></div>
            </div>
        </div>
        <div class="slide_about shadow_right" runat="server" visible="false">
        	<div class="slide_title">
            	妈咪日记 <span style=" font-weight:bold; color:#CCC;">/NEW</span>
            	<a href="http://www.up927.com/list.aspx?tag=8" target="_blank">更多></a>
                <div style="clear:both;"></div>
            </div>
            
            <asp:Repeater ID="repList11" runat="server" >
                <ItemTemplate>
                    <div class="slide_img_art">
            	        <a href="http://www.up927.com<%#(Eval("html"))%>" target="_blank">
            	        <img src="http://www.up927.com/Article_File/af/<%#Eval("pic")%>" width="78px" height="60px" style="float:left;" alt="<%#Eval("title")%>_好宝宝早教网">
                        <div class="slide_img_art_title">
                	        <span><%#GetPartContent(Eval("title").ToString(), 14)%></span>
                            <p><%#GetDaoyu(Eval("daoyu").ToString(), Eval("content").ToString(),30)%></p>
                        </div> 
                        <div style="clear:both;"></div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div style="clear:both;"></div>
    </div>
    
    <div class="container_per">
    	<div class="per_type shadow_left">
        	<div class="per_type_name">
            	<h2>儿童早教</h2>
            	<a href="http://www.up927.com/list.aspx?at=3" target="_blank" class="more">更多></a>
                <div style="clear:both;"></div>
            </div>
            <asp:Repeater ID="repList01a" runat="server" >
                <ItemTemplate>
                    <div class="per_type_img_art">
            	        <a href="http://www.up927.com<%#(Eval("html"))%>" target="_blank">
            	        <img src="http://www.up927.com/Article_File/af/<%#Eval("pic")%>" width="130px" height="100" style="float:left;" alt="<%#Eval("title")%>_好宝宝早教网">
                        <div class="per_type_img_art_title">
                	        <span class="per_title"><%#GetPartContent(Eval("title").ToString(), 14)%></span>
                            <p><%#GetDaoyu(Eval("daoyu").ToString(), Eval("content").ToString(),40)%></p>
                            <span class="per_a">阅读详情</span>
                        </div> 
                        <div style="clear:both;"></div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
           	<ul>
           	    <asp:Repeater ID="repList01b" runat="server" >
                    <ItemTemplate>
                        <li><a href="http://www.up927.com<%#(Eval("html"))%>" target="_blank"><%#GetPartContent(Eval("title").ToString(), 23)%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="per_type shadow_left" style="margin-left:6px;">
        	<div class="per_type_name">
            	<h2>母婴知识</h2>
            	<a href="http://www.up927.com/list.aspx?at=2" target="_blank">更多></a>
                <div style="clear:both;"></div>
            </div>
            <asp:Repeater ID="repList02a" runat="server" >
                <ItemTemplate>
                    <div class="per_type_img_art">
            	        <a href="http://www.up927.com<%#(Eval("html"))%>" target="_blank">
            	        <img src="http://www.up927.com/Article_File/af/<%#Eval("pic")%>" width="130px" height="100" style="float:left;" alt="<%#Eval("title")%>_好宝宝早教网">
                        <div class="per_type_img_art_title">
                	        <span class="per_title"><%#GetPartContent(Eval("title").ToString(), 30)%></span>
                            <p><%#GetDaoyu(Eval("daoyu").ToString(), Eval("content").ToString(),40)%></p>
                            <span class="per_a">阅读详情</span>
                        </div> 
                        <div style="clear:both;"></div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
           	<ul>
           	     <asp:Repeater ID="repList02b" runat="server" >
                    <ItemTemplate>
                        <li><a href="http://www.up927.com<%#(Eval("html"))%>" target="_blank"><%#GetPartContent(Eval("title").ToString(), 23)%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="slide_tuijian shadow_right">
        	<div class="per_type_name">
            	<h2>推荐阅读</h2>
                <div style="clear:both;"></div>
            </div>
            <asp:Repeater ID="repList12" runat="server" >
                <ItemTemplate>
                    <div class="slide_img_art_tuijian">
            	        <img src="http://www.up927.com/Article_File/af/<%#Eval("pic")%>" width="91px" height="70px" style="float:left;" alt="<%#Eval("title")%>_好宝宝早教网">
                        <div class="slide_img_art_tuijian_title">
                	        <a href="http://www.up927.com<%#(Eval("html"))%>" target="_blank" title="<%#Eval("title")%>"><%#GetPartContent(Eval("title1").ToString(), 11)%></a>
                            <p><%#GetDaoyu(Eval("daoyu").ToString(), Eval("content").ToString(),40)%></p>
                        </div> 
                        <div style="clear:both;"></div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
    </div>
    
    <div style="clear:both;"></div>
    </div>
    
    <!--专题部分-->
    <div class="zhuanti shadow_right">
    	<div class="per_type_name" style="border:none;">
            <h2 style="color:#8B8386;">热门专题</h2>
            <div style="clear:both;"></div>
        </div>
            
    	<div class="what" style="float:left">
    	<div class="div_cont" onClick="showUrl('http://www.up927.com/zhuanti/renshenwen/')">
            <figure>
             <div style="overflow:hidden;">
                <img src="http://www.up927.com/zhuanti/renshenwen/images/art01.jpg" width="240" height="184" alt="如何消除妊娠纹"/>
             </div>
            
             <div class="mask">
                <h2>帮助孕妈认识可怕的妊娠纹</h2>
                <p>对于爱美的辣妈们来说，生宝宝最怕的也许不是出生时的疼痛，而是难看又瘙痒的妊辰纹！</p>
                <a href="http://www.up927.com/zhuanti/renshenwen/" target="_blank">查看详情</a>
            </div>
            </figure>
        </div>
        </div>
        <div class="what" style="float:left">
            <div class="div_cont" onClick="showUrl('http://www.up927.com/zhuanti/yanshi/')">
                <figure>
                 <div style="overflow:hidden;">
                    <img src="http://www.up927.com/zhuanti/images/yanshi01.jpg" width="240" height="184" alt="小儿厌食怎么办"/>
                 </div>
                
                 <div class="mask">
                    <h2>小儿厌食怎么办？</h2>
                    <p>在日常生活中，有些孩子对吃饭没有兴趣，即使丰盛的美食摆在面前也不感兴趣，这种情况就是厌食。...</p>
                    <a href="http://www.up927.com/zhuanti/yanshi/" target="_blank">查看详情</a>
                </div>
                </figure>
            </div>
        </div>
        <div class="what" style="float:left">
            <div class="div_cont" onClick="showUrl('http://www.up927.com/zhuanti/shuohua/')">
                <figure>
                 <div style="overflow:hidden;">
                    <img src="http://www.up927.com/zhuanti/images/shuohua_002.jpg" width="240" height="184" alt="如何教宝宝学说话"/>
                 </div>
                
                 <div class="mask">
                    <h2>如何教宝宝学说话</h2>
                    <p>如果你的宝宝咿呀作语，模仿各种声音，其实他就是在回应你，表示他明白你的意思，说话之日指日可待了。...</p>
                    <a href="http://www.up927.com/zhuanti/shuohua/" target="_blank">查看详情</a>
                </div>
                </figure>
            </div>
        </div>
        <div class="what" style="float:left">
    	<div class="div_cont" onClick="showUrl('http://www.up927.com/zhuanti/yufangzhen/')">
            <figure>
             <div style="overflow:hidden;">
                <img src="http://www.up927.com/zhuanti/images/yufangzhen_002.jpg" width="240" height="184" alt="儿童预防接种证办理流程"/>
             </div>
            
             <div class="mask">
                <h2>儿童预防接种证办理流程</h2>
                <p>预防接种证是儿童预防接种的记录凭证，每个儿童都应当按照国家规定建证并接受预防接种...</p>
                <a href="http://www.up927.com/zhuanti/yufangzhen/" target="_blank">查看详情</a>
            </div>
            </figure>
        </div>
        </div>
        <div style="clear:both;"></div>
    </div>
    
    <div class="container_per">
    	<div class="per_type shadow_left">
        	<div class="per_type_name">
            	<h2>育儿知识</h2>
            	<a href="http://www.up927.com/list.aspx?at=4" target="_blank">更多></a>
                <div style="clear:both;"></div>
            </div>
			<asp:Repeater ID="repList03a" runat="server" >
                <ItemTemplate>
                    <div class="per_type_img_art">
            	        <a href="http://www.up927.com<%#(Eval("html"))%>" target="_blank">
            	        <img src="http://www.up927.com/Article_File/af/<%#Eval("pic")%>" width="130px" height="100" style="float:left;" alt="<%#Eval("title")%>_好宝宝早教网">
                        <div class="per_type_img_art_title">
                	        <span class="per_title"><%#GetPartContent(Eval("title").ToString(), 14)%></span>
                            <p><%#GetDaoyu(Eval("daoyu").ToString(), Eval("content").ToString(),40)%></p>
                            <span class="per_a">阅读详情</span>
                        </div> 
                        <div style="clear:both;"></div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
           	<ul>
           	     <asp:Repeater ID="repList03b" runat="server" >
                    <ItemTemplate>
                        <li><a href="http://www.up927.com<%#(Eval("html"))%>" target="_blank"><%#GetPartContent(Eval("title").ToString(), 23)%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="per_type shadow_left" style="margin-left:6px;">
        	<div class="per_type_name">
            	<h2>生活常识</h2>
            	<a href="http://www.up927.com/list.aspx?at=5" target="_blank">更多></a>
                <div style="clear:both;"></div>
            </div>
			<asp:Repeater ID="repList04a" runat="server" >
                <ItemTemplate>
                    <div class="per_type_img_art">
            	        <a href="http://www.up927.com<%#(Eval("html"))%>" target="_blank">
            	        <img src="http://www.up927.com/Article_File/af/<%#Eval("pic")%>" width="130px" height="100" style="float:left;" alt="<%#Eval("title")%>_好宝宝早教网">
                        <div class="per_type_img_art_title">
                	        <span class="per_title"><%#GetPartContent(Eval("title").ToString(), 14)%></span>
                            <p><%#GetDaoyu(Eval("daoyu").ToString(), Eval("content").ToString(),40)%></p>
                            <span class="per_a">阅读详情</span>
                        </div> 
                        <div style="clear:both;"></div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
           	<ul>
           	     <asp:Repeater ID="repList04b" runat="server" >
                    <ItemTemplate>
                        <li><a href="http://www.up927.com<%#(Eval("html"))%>" target="_blank"><%#GetPartContent(Eval("title").ToString(), 23)%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="slide_tuijian shadow_right">
        	<div class="per_type_name">
            	<h2>儿童教育百科</h2>
            	<a href="http://www.up927.com/tagList.aspx" target="_blank" >更多></a>
                <div style="clear:both;"></div>
            </div>
            <div class="tag">
            	<ul>
            	    <li><a href="http://www.up927.com/list.aspx?tag=7" target="_blank">励志教育</a></li>
                    <li><a href="http://www.up927.com/list.aspx?tag=10" target="_blank">宝宝饮食</a></li>
                    <li><a href="http://www.up927.com/list.aspx?tag=20" target="_blank">儿童十万个为什么</a></li>
                    <li><a href="http://www.up927.com/list.aspx?tag=17" target="_blank">教育心得</a></li>
                    <li><a href="http://www.up927.com/list.aspx?tag=18" target="_blank">益智玩具</a></li>
                    <li><a href="http://www.up927.com/list.aspx?tag=11" target="_blank">孕妇胎教音乐</a></li>
                    <li><a href="http://www.up927.com/list.aspx?tag=4" target="_blank">儿童用品</a></li>
                    <li><a href="http://www.up927.com/list.aspx?tag=21" target="_blank">新生儿护理知识</a></li>
                    <li><a href="http://www.up927.com/list.aspx?tag=22" target="_blank">儿童歌曲</a></li>
                </ul>
            </div>
        	<div class="per_type_name" style="margin-top:5px;">
            	<h2>热门好贴</h2>
                <div style="clear:both;"></div>
            </div>
            <div class="slide_tuijian_art">
                <ul style="margin-top:10px;">
                     <asp:Repeater ID="repList13" runat="server" >
                        <ItemTemplate>
                            <li><a href="http://www.up927.com<%#(Eval("html"))%>" target="_blank" title="<%#(Eval("title"))%>"><%#GetPartContent(Eval("title").ToString(), 18)%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
    </div>
    
</div>
</div>
<div style="clear:both;"></div>

<div class="friend shadow_right">
<div class="per_type_name">
	<h2>友情链接</h2>
    <div style="clear:both;"></div>
</div>
<ul>
     <asp:Repeater ID="repFriend" runat="server" >
        <ItemTemplate>
            <li><a href="<%#(Eval("link"))%>" target="_blank"><%#(Eval("link_name"))%></a></li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
</div>

<!--#include file="/userControl/foot_utf8.html"-->
<script src="http://www.up927.com/js/jquery.slideBox.min.js"></script>
<script>
    function showUrl(url) {
        window.open(url);
    }

    $(function($) {
        $('#demo1').slideBox({
            direction: 'left', //left,top#方向
            duration: 0.5, //滚动持续时间，单位：秒
            easing: 'linear', //swing,linear//滚动特效
            delay: 5, //滚动延迟时间，单位：秒
            startIndex: 1, //初始焦点顺序
            hideBottomBar: false, //隐藏底栏
            hideClickBar: false, //不自动隐藏点选按
            clickBarRadius: 10
        });
    });
</script>
</body>
</html>
