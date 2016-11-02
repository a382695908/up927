<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="article_tag_info.aspx.cs" Inherits="MyProject02.xzdd927.article.article_tag_info" validateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>修改标签信息</title>
<script src="/js/jquery-1.8.0.min.js" type="text/javascript"></script>
<script src="/js/layer/layer.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<input id="hid_artPic" type="hidden" value="" runat="server" />
<div>

<%=this.tag_name%> (<%=this.article_num%>)
<br/>
<%=this.tag_keyword%>
<br/>
<br/>

描述<asp:TextBox ID="txt_tag_miaoshu" runat="server" Height="300px" Width="300px" TextMode="MultiLine"></asp:TextBox>
<br/>

<table>
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
</table>

<asp:Button ID="btn_add" runat="server" Text="保 存" OnClick="btn_add_Click" OnClientClick="return Valid();" Width="100"/>

<%--美图秀秀弹出层--%>
<script src="/js/xiuxiu/xiuxiu.js" type="text/javascript"></script>
<div id="div_xiuxiu" style="background:#fff;display: none; height:550px; ">
<div style="clear:both;"></div>
<div id="altContent">
	<h1>上传图片</h1>
</div>
</div>
<script>

    //关闭(刷新)
    function Hide() {
        parent.location.reload(); //刷新本页
    }
    
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
        xiuxiu.setUploadURL("http://www.up927.com/xzdd927/article/saveXiuxiu.aspx?get=2"); // http://www.up927.com post.ashx http://localhost:42899  http://localhost:63689/center/pop/saveXiuxiu.aspx?get=1 http://localhost:63689/center/pop/saveXiuxiu.aspx?get=2&s=170_240
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


</div>
</form>
</body>
</html>
