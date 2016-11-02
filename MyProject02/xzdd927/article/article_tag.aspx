<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="article_tag.aspx.cs" Inherits="MyProject02.xzdd927.article.article_tag" %>
<%@ Register src="/userControl/PagerControl.ascx" tagname="PagerControl" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>文章标签列表页</title>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<script src="/js/jquery-1.8.0.min.js" type="text/javascript"></script>
<script src="/js/layer/layer.js" type="text/javascript"></script>
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

//防止页面按回车键时自动回传
document.onkeypress=function(){
if(event.keyCode==13)return false;
}

//记录一个要修改的意见及其ID 
function UpdateOneType(id)
{
    var hidUpdateName=document.getElementById("hidUpdateName");
    var hidUpdateId=document.getElementById("hidUpdateId");
    var hidUpdateTagKeyword = document.getElementById("hidUpdateTagKeyword");
    
    hidUpdateName.value=document.getElementById("txtTypeName_"+id).value;
    hidUpdateId.value = id;
    hidUpdateTagKeyword.value = document.getElementById("txtTypeKeyword_" + id).value;

    //alert(hidUpdateName.value + " " + hidUpdateId.value + " " + hidUpdateTagKeyword.value);
}

//添加时验证是否有输入分类名称
function ValidAddType()
{
    if(document.getElementById("txtAddTag").value.replace(/(^\s*)|(\s*$)/g, "")!="")
    {
        return true;
    }
    else
    {
        return false;
    }
}

function ShowTagInfo(tag_id) {
    layer.open({
        type: 2,
        title: '',
        shadeClose: false,
        closeBtn: true,
        shade: 0.8,
        //offset: '30px',
        scrollbar: false,
        fix: true,
        area: ['1000px', '600px'],
        content: '/xzdd927/article/article_tag_info.aspx?t_id=' + tag_id//iframe的url
    });
}

</script>
</head>
<body>
<form id="form1" runat="server">
<input id="hidUpdateName" type="hidden" runat="server" /><!--要修改的分类 多个用|区分-->
<input id="hidUpdateId" type="hidden" runat="server" /><!--要修改的分类ID 多个用|区分-->
<input id="hidUpdateTagKeyword" type="hidden" runat="server" /><!--要修改的分类 多个用|区分-->

<div class="bj_main">

<div class="bj_right" style="margin-left:6px;">
 <div class="bj_r_02">
  <div class="bj_r_02_05" >
  <table border="0" cellspacing="0">
  <tr>
    <td style="width:110px;"><div align="right">增加标签：</div></td>
    <td style="width:200px;"><input id="txtAddTag" runat="server" class="bj_text_07" style="width:180px;" maxlength="100" name="" type="text" /></td>
    <td style="width:200px;"><input id="txtAddTagKeyword" runat="server" class="bj_text_07" style="width:180px;" maxlength="100" name="" type="text" /></td>
    <td style="padding-top:3px;">
        <asp:ImageButton ID="imgBtn" runat="server" OnClientClick="return ValidAddType();"
            ImageUrl="/images/bianji_ht_images/gl_add_tu01.gif" onclick="imgBtn_Click"/>
    </td>

  </tr>
</table>

  
  </div> <!--bj_r_02_05 end-->

  <div class="rmclear"></div>
 </div><!--bj_r_02 end-->
 <div class="rmclear"></div>
 <div class="bj_r_06">
  <div id="divReason" class="bj_r_06_01">
  
<asp:Repeater ID="repList" runat="server" OnItemCommand="repList_ItemCommand">
    <HeaderTemplate>
        <table border="0" cellspacing="0">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td style="width:50px; height:40px;"><input id="txtOrder_<%#Eval("id")%>" runat="server" name="input" type="text"  class="bj_text_09" value="<%#Eval("id")%>" /></td>
            <td style="width:200px;"><input id="txtTypeName_<%#Eval("id")%>" runat="server" type="text" class="bj_text_08" style="width:180px;" maxlength="100" value='<%#Eval("tag_name")%>' /></td>
            <td style="width:200px;"><input id="txtTypeKeyword_<%#Eval("id")%>" runat="server" class="bj_text_07" style="width:180px;" maxlength="100" name="" type="text"  value='<%#Eval("tag_keyword")%>'/></td>
            <td style="width:50px;"><%#Eval("article_num")%></td>
            <%--<td style="width:200px;"><input id="txtTypeKeyword_<%#Eval("id")%>" runat="server" type="text" class="bj_text_08" style="width:180px;" maxlength="100" value='<%#Eval("type_keyword")%>' /></td>--%>
            <td ><a href="javascript:void(0)" onclick="ShowTagInfo(<%#Eval("id")%>)">修改信息</a>&nbsp;&nbsp;</td>
            <td style="width:66px; padding-top:4px;">
                <asp:ImageButton ID="imgBtnUpdate" runat="server" CommandName="Update" ImageUrl="/images/bianji_ht_images/bj_tijiao_tu02.gif" CommandArgument='<%#Eval("id")%>' OnClientClick='<%# "UpdateOneType("+Eval("id")+")" %>'/><%--OnClientClick='javascript:UpdateOneReason(<%#Eval("reason_id")%>)'--%>
            </td>
            <td style="padding-top:4px;">
                <asp:ImageButton ID="imgBtnDelete" runat="server" CommandName="Delete" ImageUrl="/images/bianji_ht_images/bj_shanchu_tu01.gif" CommandArgument='<%#Eval("id")%>' OnClientClick="javascript:return confirm('确定要删除吗?');"/>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>

  </div><!--bj_r_06_01 end-->
  <div class="rmclear"></div>
  
<div id="divFenye" runat="server" class="ye">
    <div class="imos_pagebox" style=" margin-top:3px; text-align:center;"  align="center">
        <uc1:PagerControl ID="pager" ShowGo="true" runat="server" />
    </div><!--fye end-->
 </div>
  
  <%--<div class="bj_r_06_02">
      <asp:ImageButton ID="imgBtnUpdateAll" runat="server" 
          ImageUrl="/images/bianji_ht_images/bj_tijiao_tu03.gif" OnClientClick="UpdateAllReason()"
          onclick="imgBtnUpdateAll_Click"/>

  </div>--%><!--bj_r_06_02 end-->
 </div><!--bj_r_06 end-->
 <div class="rmclear"></div>
 
 <!--bj_r_04 end-->
<div class="rmclear"></div>
 


</div><!--bj_right end-->

</div><!--bj_main end-->
</form>
</body>
</html>
