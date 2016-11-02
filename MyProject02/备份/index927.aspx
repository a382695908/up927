<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index927.aspx.cs" Inherits="MyProject02.index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<link rel="shortcut icon" href="/favicon.ico" />
<link rel="bookmark" href="/favicon.ico" type="image/x-icon"　/>
<title>青岛早教|青岛母婴用品|母婴知识|儿童早教|儿童教育|好宝宝网</title>
<meta name="description" content="好宝宝网提供<%=this.title%>等分类文章。" />
<meta name="keywords" content="青岛早教,青岛母婴用品,母婴知识,儿童早教,儿童教育" />
<link href="/css/css.css" rel="stylesheet" type="text/css"/>
<script src="/js/common.js" type="text/javascript"></script>
<script src="/js/jquerym.js" type="text/javascript"></script>
<script type="text/javascript" src="/js/koala.min.1.5.js"></script>
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

<%--<style type="text/css">
.blogs figure { float: left;  overflow: hidden; }
.blogs figure img {  margin: auto; -moz-transition: all 0.5s; -webkit-transition: all 0.5s; -o-transition: all 0.5s; transition: all 0.5s; }
.blogs figure:hover img { -moz-transform: scale(1.1); -webkit-transform: scale(1.1); -o-transform: scale(1.1); -ms-transform: scale(1.1); }
</style> box-shadow: 0 0 3px #000; --%>

<style type="text/css">

</style>

</head>
<body>
<!--#include virtual="/userControl/head_top.html"-->
<!--#include virtual="/userControl/inner_head_utf8.html"-->
<div style="width:960px;">
<div style="height:220px;" align="center">
<%--幻灯片开始--%>
<div id="fsD1" class="focus">  
<div id="D1pic1" class="fPic" >
<asp:Repeater ID="repList_hd" runat="server" >
<ItemTemplate>
    <div class="fcon" style="display:none;">
    <a target="_blank" href='<%#(Eval("html"))%>'><img src='/Article_File/hd1/<%#(Eval("huandeng1_pic"))%>' alt='<%#(Eval("title"))%>_好宝宝网' style="opacity: 1; border:none; width:933px; height:320px;"></a>
    <span class="shadow"><a target="_blank" href='<%#(Eval("html"))%>' title='<%#(Eval("title"))%>'><%#GetPartContent(Eval("title").ToString(), 23)%></a></span>
    </div>
</ItemTemplate>
</asp:Repeater>
</div>
<div class="fbg" style="float:right;width:300px;">  
<div class="D1fBt" id="D1fBt"style="right:0px; " right="0px;">  
<a href="javascript:void(0)" hidefocus="true" target="_self" class=""><i>1</i></a>  
<a href="javascript:void(0)" hidefocus="true" target="_self" class=""><i>2</i></a>  
<a href="javascript:void(0)" hidefocus="true" target="_self" class=""><i>3</i></a>  
<a href="javascript:void(0)" hidefocus="true" target="_self" class=""><i>4</i></a>  
<%--<a href="javascript:void(0)" hidefocus="true" target="_self" class=""><i>5</i></a>  --%>
</div>  
</div>  
<span class="prev" ></span>   
<span class="next" ></span>    
</div> 
<%--幻灯片结束--%>
</div>
<div class="newslist">
<asp:Repeater ID="repList1" runat="server"  >
<ItemTemplate>
<dl >
   <dt class="shadow">
    <h1><span class="span_type" ><a href='/list.aspx?at=<%#(Eval("type"))%>' target="_blank"><%#(Eval("type_name"))%></a></span><a href="<%#(Eval("html"))%>" target="_blank" title='<%#(Eval("title"))%>'><%#GetPartContent(Eval("title").ToString(), 25)%></a></h1>
    <h3>发布：好宝宝&nbsp;&nbsp;&nbsp;&nbsp;发布时间：<%# Convert.ToDateTime(Eval("update_date")).ToString("yyyy年M月d日")%>&nbsp;&nbsp;&nbsp;&nbsp;<%#GetTag(Eval("tag").ToString(),Eval("tag_id").ToString())%></h3>
   </dt>
   <dd class="preview" style="float:left; margin-left:20px;">
   <a class="blogs" href="<%#(Eval("html"))%>" target="_blank" title='<%#(Eval("title"))%>' style=' display:<%#GetImgShow(Eval("pic").ToString())%>'>
        <figure><img src="/Article_File/af/100_100_<%#GetPic(Eval("pic").ToString())%>" style="float:left;" alt="<%#(Eval("title"))%>_<%#(Eval("type_name"))%>_好宝宝网" /></figure>
   </a>
   <%#GetDaoyu(Eval("daoyu").ToString(), Eval("content").ToString(),100)%>
   <a href="<%#(Eval("html"))%>" target="_blank" title='<%#(Eval("title"))%>'>阅读全文>></a>
   </dd>
   <dd class="info"></dd>
</dl>
</ItemTemplate>
</asp:Repeater>
<a id="a_gengduo" href="/list.aspx" target="_blank">
    <div class="gengduo" align="center" onmouseover="this.className='gengduo1';" onmouseout="this.className='gengduo';" ><%--onmouseover="this.className='gengduo1';" onmouseout="this.className='gengduo';"--%>
        更  多
    </div>   
</a>
</div>
<!--#include file="/userControl/Side.html"-->
</div>
<div style="clear:both;"></div>
<div style="margin:0px auto; width:970px; padding-top:10px; *padding-top:0px!important; " class="xiangmu_linkbox">
<div class="link_bg"><span class="blue14_003366_blod" style="color:#575757;">友情链接</span></div>
</div>
<div>
<div class="link_box">
<div style="clear:both;"></div>
<div class="link_fontbox">
<%--<a target="_blank" href="http://www.up927.com">母婴知识</a> | <a target="_blank" href="http://www.up927.com">儿童早教</a> | <a target="_blank" href="http://www.52feiyue.com">青岛创业</a> | <a target="_blank" href="http://www.imosi.com/">现代服务业</a> | <a target="_blank" href="http://www.52feiyue.com/list.aspx?a_t=13">创业案例</a> | <a target="_blank" href="http://www.chinadmoz.org/">CDMOZ</a>--%>
<%=this.friendLink%>
</div>
</div>
<img src="/images/xiangmu_bottom_link.jpg" />
</div>
<!--#include file="/userControl/news_foot_utf8.html"-->
<script language="javascript" type="text/javascript">
Qfast.add('widgets', { path: "/js/terminator2.2.min.js", type: "js", requires: ['fx'] });  
	Qfast(false, 'widgets', function () {
		K.tabs({
			id: 'fsD1',   //焦点图包裹id  
			conId: "D1pic1",  //** 大图域包裹id  
			tabId:"D1fBt",  
			tabTn:"a",
			conCn: '.fcon', //** 大图域配置class       
			auto: 1,   //自动播放 1或0
			effect: 'fade',   //效果配置
			eType: 'click', //** 鼠标事件
			pageBt:true,//是否有按钮切换页码
			bns: ['.prev', '.next'],//** 前后按钮配置class                          
			interval: 4000  //** 停顿时间  
		}) 
	})  
</script>
</body>
</html>
