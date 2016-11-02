<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Side_2.aspx.cs" Inherits="MyProject02.template.Side_2" %>

<div class="right_side">
<div class="slide_tuijian shadow_right" style="margin-top:10px;" >
<div class="per_type_name" style=" padding-top:7px; padding-bottom:5px;">
<h2>推荐阅读</h2>
<div style="clear:both;"></div>
</div>
<asp:Repeater ID="repList12" runat="server" >
    <ItemTemplate>
        <div class="slide_img_art_tuijian">
	        <a href="http://www.up927.com<%#(Eval("html"))%>" target="_blank" title="<%#Eval("title")%>"><img src="http://www.up927.com/Article_File/af/<%#Eval("pic")%>" width="91px" height="70px" style="float:left;" alt="<%#Eval("title")%>_好宝宝早教网"></a>
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

<div class="slide_tuijian shadow_right" style="margin-top:15px; height:auto; padding-bottom:10px;">
<div class="per_type_name">
<h2>儿童教育百科</h2>
<a href="http://www.up927.com/tagList.aspx" target="_blank" >更多></a>
<div style="clear:both;"></div>
</div>
<div class="tag">
<ul>
<li><a href="http://www.up927.com/list.aspx?tag=7" target="_blank">励志教育</a></li>
<li><a href="http://www.up927.com/list.aspx?tag=10" target="_blank">宝宝饮食</a></li>
<li><a href="http://www.up927.com/list.aspx?tag=22" target="_blank">儿童歌曲</a></li>
<li><a href="http://www.up927.com/list.aspx?tag=20" target="_blank">儿童十万个为什么</a></li>
<li><a href="http://www.up927.com/list.aspx?tag=17" target="_blank">教育心得</a></li>
<li><a href="http://www.up927.com/list.aspx?tag=18" target="_blank">益智玩具</a></li>
<li><a href="http://www.up927.com/list.aspx?tag=4" target="_blank">儿童用品</a></li>
<li><a href="http://www.up927.com/list.aspx?tag=11" target="_blank">孕妇胎教音乐</a></li>
<li><a href="http://www.up927.com/tools/xingzuo.shtml" target="_blank">12星座运势</a></li>
<li><a href="http://www.up927.com/tools/shengxiao.shtml" target="_blank">12生肖运势</a></li>
<li><a href="http://www.up927.com/tools/yuchanqi/" target="_blank">预产期计算器</a></li>
<li><a href="http://www.up927.com/tools/yuejing/" target="_blank">月经排卵期计算器</a></li>
</ul>
</div>
</div>
<div class="slide_tuijian shadow_right" style="margin-top:15px; height:auto; padding-bottom:5px;">
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

<div style="clear:both;"></div>
</div>

