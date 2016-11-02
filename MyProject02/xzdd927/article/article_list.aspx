<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="article_list.aspx.cs" Inherits="MyProject02.xzdd927.article.article_list" %>
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

<%--<script src="/js/manage_common.js" type="text/javascript"></script>--%>
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

function SelectArticle()
{
    var article_id=document.getElementById("txt_article_id").value.replace(/\s/ig,'');
    var title=document.getElementById("txt_title").value;
    var articleType=document.getElementById("ddl_articleType").value;
    var right_type=document.getElementById("ddl_right_type").value;
    
    var update_date_min=document.getElementById("txt_update_date_min").value;
    var update_date_max=document.getElementById("txt_update_date_max").value;
    
    var tag=document.getElementById("txt_tag").value;
    var html=document.getElementById("txt_html").value;

    var search_keyword = document.getElementById("txt_search_keyword").value;
    
    var hd1="";
    if(document.getElementById("chkIsHuandeng1").checked)
    {
        hd1="1";
    }
    var where="?a_t="+articleType;  
    
    
    if(article_id!="")
    {
        where+="&a_id="+article_id;
    }
    if(title!="")
    {
        where+="&title="+escape(title);
    }
    if (search_keyword != "") {
        where += "&search_keyword=" + escape(search_keyword);
    }
    if(update_date_min!="")
    {
        where+="&dateMin="+update_date_min;
    }
    if(update_date_max!="")
    {
        where+="&dateMax="+update_date_max;
    }

    if(tag!="")
    {
        where+="&tag="+escape(tag);
    }
    if(html!="")
    {
        where+="&html="+html;
    }
    if(hd1=="1")
    {
        where+="&hd1=1";
    }
    if(right_type!="0")
    {
        where+="&r_t="+right_type;
    }



    window.location.href = "/xzdd927/article/article_list.aspx" + where;
}

function OpenImg(src)
{
    window.open(src.replace("100_100_",""),"n");
}


function ShowUrl(url,url_wap) {
    window.open(url);
    window.open(url_wap);
}

</script>

</head>
<body>
<form id="form1" runat="server">
<div style=" width:960px; margin:0 auto;">
  <br />
  <div style="border:1px solid #ccc; padding:10px;">
  <table  height="116" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td>
        <table>
            <tr>
                <td   height="30" align="left">&nbsp;&nbsp;文章ID：      
                    <input type="text" name="textfield" id="txt_article_id" runat="server"/>
                </td>
            </tr>
        </table>
    </td>
    <td>
        <table>
            <tr>
                <td width="238" align="left">文章标题：
                    <input type="text" name="textfield2" id="txt_title" runat="server"/>
                </td>
            </tr>
        </table>
    </td>
    
    <td>
        <table>
            <tr>
                <td width="238" align="left">标签：
                    <input type="text" name="textfield2" id="txt_tag" runat="server"/>
                </td>
            </tr>
        </table>
    </td>
    
    
    
    <td width="224" align="left">文章类别：
      <asp:DropDownList ID="ddl_articleType" CssClass="bj_xiala_02" Width="120"  runat="server" DataTextField="type_name" DataValueField="id"></asp:DropDownList>
    </td>
    </tr>
  <tr>
      <td colspan="4">
        <table>
            <tr>
                <td height="30" align="left">发布时间：
                  <input  name="" type="text" style="color:#666;cursor: pointer;" value="" size="7" onclick="__Calendar__.show(this, {})" readonly="readonly" id="txt_update_date_min" runat="server" onkeypress=" if(event.keyCode==13) return false;"/>
                  -
                  <input  name="" type="text" style="color:#666;cursor: pointer;" value="" size="7" onclick="__Calendar__.show(this, {})" readonly="readonly" id="txt_update_date_max" runat="server" onkeypress=" if(event.keyCode==13) return false;"/>
                </td>
                
                <td>
                    &nbsp;&nbsp;页面名称：<input type="text" name="textfield2" id="txt_html" runat="server"/>
                </td>
                
                <td>
                    &nbsp;&nbsp;右侧类别：
                    <asp:DropDownList ID="ddl_right_type" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="0" Selected="True">无</asp:ListItem>
                        <asp:ListItem Value="1">热门文章</asp:ListItem>
                        <asp:ListItem Value="2">精品文章</asp:ListItem>
                        <asp:ListItem Value="3">推荐文章</asp:ListItem>
                    </asp:DropDownList>
                </td>
                
                <td>
                    &nbsp;&nbsp;首页幻灯：<asp:CheckBox ID="chkIsHuandeng1" runat="server" />
                </td>
            </tr>
        </table>
      </td>
      
      <td>
        <table>
            <tr>
                <td width="238" align="left">搜索关键词：
                    <input type="text" name="textfield2" id="txt_search_keyword" runat="server"/>
                </td>
            </tr>
        </table>
    </td>
    <%--<td align="center">&nbsp;</td>--%>
    </tr>
  <%--<tr>
    
    <td align="right">&nbsp;</td>
    
    <td align="center"></td>
  </tr>--%>
  <tr>
    <td height="40" align="right">&nbsp;</td>
    <td align="center">
        <a href="javascript:void(0)" onclick="SelectArticle()"><img src="/images/bianji_ht_images/bj_sousuo_tu01.gif"/></a>
    </td>
    <td align="left">
        <a href="/xzdd927/article/article_list.aspx"><img src="/images/bianji_ht_images/bj_congzhi_tu01.gif"/></a>
    </td>
    <td align="center">&nbsp;</td>
  </tr>
</table>
</div>

<div class="rmclear"></div>
  
 <div id="divInfoList" runat="server" class="bj_r_03">
共查询出<asp:Label ID="labInfoCount" runat="server" Text="0"></asp:Label>条信息
<asp:Repeater ID="repList" runat="server" OnItemCommand="repList_ItemCommand">
<HeaderTemplate>
<table border="0" cellspacing="0">
  <tr>
    <td class="bj_bd_bg" style="width:60px; height:30px;">
        ID    </td>
    <td class="bj_bd_bg" style="width:200px;">
        标题    </td>
    <td class="bj_bd_bg" style="width:100px;">
        页面名称    </td>
    <td class="bj_bd_bg" style="width:200px;">
        标签 </td>
    <td class="bj_bd_bg" style="width:200px;">
        搜索关键词   </td>
    <td class="bj_bd_bg" style="width:100px;">
        文章类别   </td>
    <td class="bj_bd_bg" style="width:100px;">
        右侧类别   </td>
    <td class="bj_bd_bg" style="width:110px;">
        发布日期   </td>
    <td class="bj_bd_bg" style="width:50px;">
        幻灯   </td>
    <td class="bj_bd_bg" style="width:50px;">
        图片   </td>
    <td class="bj_bd_bg" style="width:90px;">
        操作    </td>
  </tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
    <td style="height:50px;"><div align="center">
        <%#(Eval("articleId"))%>
    </div></td>
    <td style="width:200px;"><div align="center"><a href="<%#(Eval("html"))%>" title="<%#(Eval("title"))%>" target="_blank" ><%#GetPartContent(Eval("title").ToString(), 20)%></a></div></td>
    <td style="width:100px;" align="center"><div align="center" title="<%#(Eval("html"))%>"><a href="javascript:void(0)" title="<%#(Eval("title"))%>" onclick="ShowUrl('/wap<%#(Eval("html"))%>','<%#(Eval("html"))%>')" >&nbsp;<%#(Eval("html"))%>&nbsp;</a></div></td>
    <td style="width:200px;" align="center"><div align="center" title="<%#(Eval("tag"))%>">&nbsp;<a href="/list.aspx?tag=<%#(Eval("tag_id").ToString().Replace(",",""))%>" target="_blank" ><%#GetPartContent(Eval("tag").ToString(), 26)%></a>&nbsp;</div></td>
    <td style="width:200px;"><div align="center" title="<%#(Eval("search_keyword"))%>">&nbsp;<a href="/list.aspx?title=<%#System.Web.HttpUtility.UrlEncode(Eval("search_keyword").ToString())%>" target="_blank" ><%#GetPartContent(Eval("search_keyword").ToString(), 20)%></a>&nbsp;</div></td>
    <td style="width:100px;"><div align="center"><a href="/list.aspx?at=<%#(Eval("type"))%>" target="_blank" ><%#(Eval("type_name"))%></a></div></td>
    <td style="width:100px;"><div align="center"><%#GetRightType(Convert.ToInt32(Eval("right_type")))%></div></td>
    <td style="width:110px;"><div align="center"><%#Convert.ToDateTime(Eval("update_date")).ToString("yyyy-MM-dd HH:mm:ss")%></div></td>
    <td style="width:50px;"><div align="center"> &nbsp;<%#(Eval("huandeng1").ToString()=="1"?"是":"")%>&nbsp; </div></td>
    <td style="width:50px;"><div align="center"> &nbsp;<%#GetImg(Eval("pic").ToString())%>&nbsp; </div></td>
    <td style="width:90px;">
        <div align="center"> 
            <a href='/xzdd927/article/add_article.aspx?a_id=<%#(Eval("articleId"))%>'>修改</a> 
            <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%#Eval("articleId")%>'  OnClientClick="javascript:return confirm('确定要删除吗?');" >删除</asp:LinkButton>
            <span style="display:none;"><asp:LinkButton ID="btnTS_baidu" runat="server" CommandName="ts_baidu" CommandArgument='<%#Eval("articleId")+"|"+Eval("html")%>' >推送</asp:LinkButton></span>
        </div>
    </td>
  </tr>
</ItemTemplate>
<AlternatingItemTemplate>
<tr style="background:#EFF2F7;">
    <td style="height:50px;"><div align="center">
        <%#(Eval("articleId"))%>
    </div></td>
    <td style="width:200px;"><div align="center"><a href="<%#(Eval("html"))%>" title="<%#(Eval("title"))%>" target="_blank" ><%#GetPartContent(Eval("title").ToString(), 20)%></a></div></td>
    <td style="width:100px;" align="center"><div align="center" title="<%#(Eval("html"))%>"><a href="javascript:void(0)" title="<%#(Eval("title"))%>" onclick="ShowUrl('/wap<%#(Eval("html"))%>','<%#(Eval("html"))%>')" >&nbsp;<%#(Eval("html"))%>&nbsp;</a></div></td>
    <td style="width:200px;" align="center"><div align="center" title="<%#(Eval("tag"))%>">&nbsp;<a href="/list.aspx?tag=<%#(Eval("tag_id").ToString().Replace(",",""))%>" target="_blank" ><%#GetPartContent(Eval("tag").ToString(), 26)%></a>&nbsp;</div></td>
    <td style="width:200px;"><div align="center" title="<%#(Eval("search_keyword"))%>">&nbsp;<a href="/list.aspx?title=<%#System.Web.HttpUtility.UrlEncode(Eval("search_keyword").ToString())%>" target="_blank" ><%#GetPartContent(Eval("search_keyword").ToString(), 20)%></a>&nbsp;</div></td>
    <td style="width:100px;"><div align="center"><a href="/list.aspx?at=<%#(Eval("type"))%>" target="_blank" ><%#(Eval("type_name"))%></a></div></td>
    <td style="width:100px;"><div align="center"><%#GetRightType(Convert.ToInt32(Eval("right_type")))%></div></td>
    <td style="width:110px;"><div align="center"><%#Convert.ToDateTime(Eval("update_date")).ToString("yyyy-MM-dd HH:mm:ss")%></div></td>
    <td style="width:50px;"><div align="center"> &nbsp;<%#(Eval("huandeng1").ToString()=="1"?"是":"")%>&nbsp; </div></td>
    <td style="width:50px;"><div align="center"> &nbsp;<%#GetImg(Eval("pic").ToString())%>&nbsp; </div></td>
    <td style="width:90px;">
        <div align="center"> 
            <a href='/xzdd927/article/add_article.aspx?a_id=<%#(Eval("articleId"))%>'>修改</a> 
            <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%#Eval("articleId")%>'  OnClientClick="javascript:return confirm('确定要删除吗?');" >删除</asp:LinkButton>
            <span style="display:none;"><asp:LinkButton ID="btnTS_baidu" runat="server" CommandName="ts_baidu" CommandArgument='<%#Eval("articleId")+"|"+Eval("html")%>' >推送</asp:LinkButton></span>
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

<div class="bgLayer" id="bgDiv" style="display: none;"><!--蒙层-->
<iframe  class="bgLayer" style="position:absolute;border:0px; top:0px; left:0px; width:100%; height:100%; z-index:1;filter:mask(); "></iframe>
</div> 

<div id="divRepayInfo" class='xiangdan_box' style='width:1000px; margin-top:20px;display:none;'>
</div>
</form>
</body>
</html>
