<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_article.aspx.cs" Inherits="MyProject02.xzdd927.article.add_article" EnableEventValidation="false" ValidateRequest="false"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>添加文章</title>
<script src="/js/jquery-1.8.0.min.js" type="text/javascript"></script>
<script src="/js/layer/layer.js" type="text/javascript"></script>
<link href="/css/manage/font.css" rel="stylesheet" type="text/css">
<%--<script src="/js/jquerym.js" type="text/javascript"></script>--%>
<script src="/js/common.js" type="text/javascript"></script>
<script type="text/javascript" src="/js/swfobject.js"></script>
<!--编辑器-->
<%--<link href="/umeditor/themes/default/css/umeditor.css" type="text/css" rel="stylesheet">
<script type="text/javascript" src="/umeditor/third-party/jquery.min.js"></script>
<script type="text/javascript" charset="utf-8" src="/umeditor/umeditor.config.js"></script>
<script type="text/javascript" charset="utf-8" src="/umeditor/umeditor.min.js"></script>
<script type="text/javascript" src="/umeditor/lang/zh-cn/zh-cn.js"></script>--%>



<script src="/umeditor/ueditor.config.js" type="text/javascript"></script>
<script src="/umeditor/ueditor.all.min.js" type="text/javascript"></script>
<script src="/umeditor/lang/zh-cn/zh-cn.js" type="text/javascript"></script>

<style type="text/css">
body{font-size: 12px;}
</style>
<script type="text/javascript">

var LastCount =0;
function CountStrByte(Message,Total){ //字节统计
var ByteCount = 0;
var StrValue  = Message.value;
var StrLength = Message.value.length;
var MaxValue  = Total;
if(LastCount != StrLength) { // 在此判断，减少循环次数
for (i=0;i<StrLength;i++){
ByteCount  = (StrValue.charCodeAt(i)<=256) ? ByteCount + 1 : ByteCount + 2;
if (ByteCount>MaxValue) {
Message.value = StrValue.substring(0,i);
alert("标题最多不能超过 " +MaxValue+ " 个字节！\n注意：一个汉字为两字节。");
ByteCount = MaxValue;
break;
}}}}


function Valid() {
    var title=document.getElementById("txt_title").value.replace(/\s/ig,'');
    var type=document.getElementById("ddl_articleType").value;
    //var content=document.getElementById("content2").value.replace(/\s/ig,'');
    var declare_mark=document.getElementById("ddl_declare_mark").value;
    //var keyword=document.getElementById("txt_keyword").value.replace(/\s/ig,'');
    //var daoyu=document.getElementById("txt_daoyu").value.replace(/\s/ig,'');

    var hidDes = UE.getEditor('myEditor').getContent();
    document.getElementById("hidDes").value = hidDes;

    if(title=="")
    {
        alert("请输入标题！");
        return false;
    }
    else if (hidDes == "")
    {
        alert("请输入内容！");
        return false;
    }
    else
    {
        return true;
    }
}

function OpenImg(src)
{
    window.open(src.replace("100_100_",""),"n");
}

function SetTag(tag)
{
    document.getElementById("txt_tag").value+=tag+" ";
}

function SearchTag()
{
    var tag=document.getElementById("txtTagSearch").value.replace(/\s/ig,'');
    if(tag!="")
    {
        var result;
        result= $.ajax({
        url: "/ajax/ajax_m.aspx?get=1&tag="+escape(tag)+"&_t="+Math.random(),
        async: false
        }).responseText;
        
        if(result!="")
        {
            document.getElementById("div_tags").innerHTML=result;
        }
    }
}

</script>
<script type="text/javascript">
function CopyImg(pic)
{
    var picUrl="http://"+window.location.host+"<%=this.Article_File %>"+pic;
    copyToClipboard(picUrl);
}
</script>
</head>
<body onload="showFlash()">
<form id="form1" runat="server">
<input id="hidTagId" type="hidden" value="" runat="server" />
<input id="hidDes" type="hidden" value="" runat="server" /><!--内容描述-->
<input id="hid_artPic" type="hidden" value="" runat="server" />
<div>

<table align="center" width="980">
<tr style="display:none;">
<td>
    <table>
        <tr>
            <td>首页幻灯：</td>
            <td>
                <asp:CheckBox ID="chkHuandeng1" runat="server" />
            </td>
        </tr>
    </table>
</td>
</tr>
<tr>
<td>
    <table>
        <tr>
            <td>文章标题：</td>
            <td>
<asp:TextBox ID="txt_title" runat="server" Width="220px"></asp:TextBox>
<%--<span class="black12_ce">最多输入18个汉字</span>--%> </td>
        </tr>
    </table>
</td>
<td>
    <table>
        <tr>
            <td>文章标题1：</td>
            <td>
<asp:TextBox ID="txt_title1" runat="server" Width="220px"></asp:TextBox>
<%--<span class="black12_ce">最多输入18个汉字</span>--%> </td>
        </tr>
    </table>
</td>
</tr>
<tr style="display:none;">
<td>
    <table>
        <tr>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;发布：</td>
            <td>
<asp:TextBox ID="txt_source" runat="server" Width="220px"></asp:TextBox>
<%--<span class="black12_ce">最多输入18个汉字</span>--%> </td>
        </tr>
    </table>
</td>
</tr>
<tr>
<td>
    <table>
        <tr>
            <td>文章类别：</td>
            <td>
            <asp:DropDownList ID="ddl_articleType" CssClass="bj_xiala_02" Width="120"  runat="server" DataTextField="type_name" DataValueField="id"></asp:DropDownList>
            </td>
        </tr>
    </table>
</td>

</tr>
<tr>
<td colspan="2">
<table>
<tr>
<td>新闻内容：</td>
<td>
 <%--<input id="content2" type="hidden" name="content2" runat="server" />
<iframe ID="xxx" src="/manage/ewebeditor/ewebeditor.htm?id=content2&style=coolblue" frameborder="0" scrolling="no" width="610" HEIGHT="350"></iframe>--%>

<asp:TextBox ID="content2" runat="server" Height="50px" Width="400px" TextMode="MultiLine" Visible="false"></asp:TextBox>

<script type="text/plain" id="myEditor" style="width:700px;height:300px;"></script>
<script type="text/javascript">
var ue = UE.getEditor('myEditor');
ue.ready(function() {
//设置编辑器的内容
ue.setContent(document.getElementById("hidDes").value, false);
////获取html内容，返回: <p>hello</p>
// var html = ue.getContent();
////获取纯文本内容，返回: hello
//var txt = ue.getContentTxt();
});
</script>


</td>
</tr>
<tr>
<td>声明：</td>
<td>
    <asp:RadioButtonList ID="ddl_declare_mark" runat="server" RepeatDirection="Horizontal">
  <asp:ListItem Value="1" Selected="True">转载声明</asp:ListItem>
     <asp:ListItem Value="2">原创声明</asp:ListItem>
      <asp:ListItem Value="3">免责声明</asp:ListItem>
      <asp:ListItem Value="0">无声明</asp:ListItem>
    </asp:RadioButtonList>
</td>
</tr>
<tr>
<td>右侧类别：</td>
<td>
    <asp:DropDownList ID="ddl_right_type" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="0" Selected="True">无</asp:ListItem>
        <asp:ListItem Value="1">热门文章</asp:ListItem>
        <asp:ListItem Value="2">精品文章</asp:ListItem>
        <asp:ListItem Value="3">推荐文章</asp:ListItem>
    </asp:DropDownList>
</td>
</tr>
</table>
</td>
</tr>

<tr>
<td colspan="2">
<table>
<tr>
<td>标签：</td>
<td><asp:TextBox ID="txt_tag" runat="server" Width="300px"></asp:TextBox>以空格分隔</td>
</tr>
<tr>
<td></td>
<td>
    <div id='div_SelectTag' style="width:300px; height:auto;">
    <div style="margin:10px auto auto 10px;height:30px;">
        <input id="txtTagSearch" type="text" style="height:20px; padding-top:3px; border:1px solid #b5b5b5;" />&nbsp;&nbsp;<input id="btnTagSearch" type="button" onclick="SearchTag()" value="搜索" />
    </div>
    <div id="div_tags" style="margin:10px auto auto 10px; line-height:30px; padding-left:0px; height:auto;" align="left">
        
        <div style="clear:both; height:5px;"></div>
    </div>
    </div>
</td>
</tr>
<tr style="display:none;">
<td>关键字：</td>
<td><asp:TextBox ID="txt_keyword" runat="server" Width="300px"></asp:TextBox>以空格分隔</td>
</tr>
<tr>
<td>搜索用关键词：</td>
<td><asp:TextBox ID="txt_search_keyword" runat="server" Width="300px"></asp:TextBox>以空格分隔</td>
</tr>


<tr>
<td>导语：</td><td><asp:TextBox ID="txt_daoyu" runat="server" Height="50px" Width="400px" TextMode="MultiLine"></asp:TextBox>
</td>
</tr>
<tr>
    <td>文章图片：</td>
    <td id="td_artImgUpload" runat="server">
        <asp:FileUpload ID="fu_image" runat="server" Width="300px" style=" display:none;" />
        <a href="javascript:void(0)" onclick="ShowXiuxiu()">上传图片</a>
    </td>
    <td id="td_artImg" runat="server" style="display:none;">
        <img id="img_artImg" src="" runat="server" onclick="OpenImg(this.src)" style="cursor:pointer; width:100px; height:80px; border:#ccc 1px solid;"/>
        <br/><br/>
        <asp:Button ID="btn_delImg" runat="server" Text="删除图片" OnClick="btn_delImg_Click" OnClientClick="return confirm('确定要删除该图片？');"/>
    </td>
</tr>

<%--<tr id="tr_artImg" runat="server" visible="false">
    <td>
        <img id="img_artImg" src="" runat="server" onclick="OpenImg(this.src)" style="cursor:pointer; width:100px; height:80px;"/>
        <br/><br/>
        <asp:Button ID="btn_delImg" runat="server" Text="删除图片" OnClick="btn_delImg_Click" OnClientClick="return confirm('确定要删除该图片？');"/>
    </td>
</tr>--%>
<tr><td>幻灯图片：</td><td title="933*320"><asp:FileUpload ID="fu_image_huandeng1" runat="server" Width="300px"  /></td></tr>
<tr id="tr_artImg_huandeng1" runat="server" visible="false">
    <td>
        <img id="img_artImg_huandeng1" src="" runat="server" onclick="OpenImg(this.src)" style="cursor:pointer;" width="100" height="100"/>
        <br/><br/>
        <asp:Button ID="btn_delImg_huandeng1" runat="server" Text="删除图片" OnClick="btn_delImg_huandeng1_Click" OnClientClick="return confirm('确定要删除该图片？');"/>
    </td>
</tr>
</table>
</td>
</tr>

<tr>
<td>
    <table>
        <tr>
            <td>&nbsp;</td>
            <td>
                <br/>
                <asp:Button ID="btn_add" runat="server" Text="发 布" OnClick="btn_add_Click" OnClientClick="return Valid();" Width="100"/>
            </td>
        </tr>
    </table>
</td>
</tr>
</table>

<br/>
<br/>
<div>
    <table align="center" width="980">
    <tr>
        <td>多张图片：</td>
        <td>
    <asp:FileUpload ID="fu_image1" runat="server" Width="300px" />
    <asp:Button ID="btnUpdateImg" runat="server" Text="上 传" OnClick="btnUpdateImg_Click" Width="100"/>
    

                <%--<button id="btnUpload" type="button" onclick="ShowAlbumId()">确认并添加图片</button>--%>
                <div id="divFlash" style="margin:50px auto;" >
	            </div>
                <script type="text/javascript">
                    function showFlash() {
                        var params = {
                        serverUrl: "/xzdd927/article/saveImage.aspx?a_id=<%=this.articleId_img %>",
                            jsFunction: "flashReturn",
//                            imageWidth: 600,
//                            imageHeight: 600,
                            //imageQuality: 60, //图片质量：60%
                            uploadText: "上传多张图片",
                            cancelText: "取消上传",
                            filter: "*.jpg;*.png;*.jpeg",
                            maxFileSize: 10000000 //单个文件最大1M
                        }
                        swfobject.embedSWF("/js/mFileUpload.swf", "divFlash", "300", "30", "10.0.0", "expressInstall.swf", params);
                    }


                    function flashReturn(type, str) {
                        if (type == "upload_complete") {
                            window.location.reload(); //刷新本页
                        }
                        //window.location.reload(); //刷新本页
                    }


                    function setPara() {
                        var swf = document.getElementById('divFlash');
                        if (!swf.isBusy()) {
                            swf.setPara('labelFormat', '{%}');
                        }
                    }
	                </script>
    
     </td>
     </tr>
     </table>
</div>

<div align="center" width="980" style=" margin-bottom:100px;">
            <asp:Repeater ID="repList_Img" runat="server" OnItemCommand="repList_Img_ItemCommand">
                <ItemTemplate>
                    <table align="center" cellspacing="0" cellpadding="0" style="float:left;border-collapse:collapse;"  cellspacing="0" cellpadding="0"  border="1" bordercolor="#a0c6e5" >
                      <tr>
                        <td align="center" valign="middle" style="border: solid 1px #0100; margin-left:10px;">
                            <img src='/Article_File/af/<%#Eval("pic")%>' style="cursor:pointer;" onclick="OpenImg(this.src)" complete="complete" height="100" width="100" />
                        </td>
                      </tr>
                      <tr>
                        <td>
                            &nbsp;<%# Container.ItemIndex + 1%> 
                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%#Eval("id")+"|"+Eval("pic")%>'  OnClientClick="javascript:return confirm('确定要删除吗?');" >删除</asp:LinkButton>
                            <a href="javascript:void(0);" onclick='CopyImg("<%#Eval("pic")%>")'>地址</a>
                            <%--<asp:Button ID="btnDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("id")+"|"+Eval("pic")%>'  OnClientClick="javascript:return confirm('确定要删除吗?');"/>--%>
                        </td>
                      </tr>
                    </table>
                </ItemTemplate>
             </asp:Repeater>
</div>

<div style="margin-bottom:50px;">&nbsp;&nbsp;</div>
</br>
</br>
</div>


<div class="bgLayer" id="bgDiv" style="display: none;">
<iframe  class="bgLayer" style="position:absolute;border:0px; top:0px; left:0px; width:100%; height:100%; z-index:1;filter:mask(); "></iframe>
</div> 

<style type="text/css">
.bgLayer
{
	background: #444;
	filter: alpha(opacity=15);
	left: 0px;
	width: 100%;
	position: absolute;
	top: 0px;
	moz-opacity: 0.6;
	opacity: 0.6;
}
#div_SelectTag 
{
	
	border:#ccc 1px solid;
	background:#FFFFF0;
}
#div_tags li{ float:left; list-style-type:none; margin-left:10px; }
#div_tags li a{font-size:14px;}
</style>

<%--美图秀秀弹出层--%>
<script src="/js/xiuxiu/xiuxiu.js" type="text/javascript"></script>
<div id="div_xiuxiu" style="background:#fff;display: none; height:550px; ">
<%--<div style="float:right; margin-top:20px; margin-right:10px;">
    <img src="/images/guanbi.png" style="cursor:pointer;" onclick="HideXiuxiu()" width="15" height="15">
</div>--%>
<div style="clear:both;"></div>

<div id="altContent">
	<h1>上传图片</h1>
</div>
</div>
<script>

    function HideXiuxiu() {
        //document.getElementById("img_pic").setAttribute('src', 'http://localhost:58270/userFile/newspic/201601281502153d9c963c7e794c22bb3fa09af84c1b49.jpg');
        //document.getElementById("img_aa").src = "" + Date() ;
        //$('#img_aa').attr('src', 'http://localhost:58270/userFile/newspic/201601281502153d9c963c7e794c22bb3fa09af84c1b49.jpg');
        layer.closeAll();
    }

    function ShowXiuxiu() {
        SetXiuxiu();

        layer.open({
            type: 1,
            title: false,
            closeBtn: true,
            area: ['900px', '500px'],
            skin: 'layui-layer-nobg', //没有背景色
            shadeClose: false,
            scrollbar: false,
            content: $('#div_xiuxiu')
        });
        
    }

    //    window.onload = function() {
    //        //xiuxiu.setLaunchVars("customMenu", []);
    //        
    //    }

    function SetXiuxiu() {

        var vi = document.getElementById("hid_artPic").value;
        xiuxiu.setLaunchVars("cameraEnabled", 0); //禁用摄像头
        
        xiuxiu.setLaunchVars("cropPresets", "416:320"); //设置裁剪比例
        /*第1个参数是加载编辑器div容器，第2个参数是编辑器类型，第3个参数是div容器宽，第4个参数是div容器高*/
        xiuxiu.embedSWF("altContent", 5, "850", "500", "upxiuxiu");
        xiuxiu.onBeforeUpload = function(data, id) {
            var size = data.size;
            if (size > 10 * 1024 * 1024) {
                alert("图片不能超过5M");
                return false;
            }
            return true;
        }
        //修改为您自己的图片上传接口
        xiuxiu.setUploadURL("http://www.up927.com/xzdd927/article/saveXiuxiu.aspx?get=1"); // http://www.up927.com post.ashx http://localhost:42899  http://localhost:63689/center/pop/saveXiuxiu.aspx?get=1 http://localhost:63689/center/pop/saveXiuxiu.aspx?get=2&s=170_240
        xiuxiu.setUploadType(2);
        xiuxiu.setUploadDataFieldName("upload_file"); //upload_file
        xiuxiu.onInit = function() {
            //xiuxiu.loadPhoto("http://open.web.meitu.com/sources/images/1.jpg");
            document.getElementById("div_xiuxiu").click();
        }
        xiuxiu.onUploadResponse = function(data) {
            var aa = data.split('&&&&&');
            //alert("上传完成！" + aa[0] + "+" + aa[1]); //可以开启调试
            document.getElementById("hid_artPic").value = aa[1]; //记录上传的图片名称
            document.getElementById("img_artImg").src = aa[0] + aa[1];
            document.getElementById("td_artImg").style.display = "";
            document.getElementById("td_artImgUpload").style.display = "none";
            HideXiuxiu();
        }
    }

</script>

</form>
</body>
</html>
