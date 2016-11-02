<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MyProject02.xzdd927.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>网站后台管理登录</title>
<link href="/css/font.css" rel="stylesheet" type="text/css" />
<%--<style type="text/css">
body{ background-color:#F7F3F7}
.login_all{ background-image:url(/images/login_all_bj.gif); height:444px;}
.login{ background-image:url(/images/login_bj.jpg); height:444px; width:847px; margin:0 auto}
</style>--%>

<script src="/js/jquery-1.8.0.min.js" type="text/javascript"></script>
<script src="/js/layer/layer.js" type="text/javascript"></script>
<link href="/css/manage/login.css" rel="stylesheet" type="text/css" />
<script src="/js/jquerym.js" type="text/javascript"></script>

<script type="text/javascript">
    function getId(id) {
        return document.getElementById(id);
    }

    function NameFocus() {
        var txt = getId("txtLoginName").value;
        if (getId("txtLoginName").value == "登录名") {
            getId("txtLoginName").value = "";
        }
    }

    function NameBlur() {
        var txt = getId("txtLoginName").value;
        if (getId("txtLoginName").value == "") {
            getId("txtLoginName").value = "登录名";
        }
    }

    function PwdFocus() {
        var txt = getId("txtPassword").value;
        if (getId("txtPassword").value == "++++++") {
            getId("txtPassword").value = "";
        }
    }

    function PwdBlur() {
        var txt = getId("txtPassword").value;
        if (getId("txtPassword").value == "") {
            getId("txtPassword").value = "++++++";
        }
    }

    function CodeFocus() {
        var txt = getId("txt_checkCode").value;
        if (getId("txt_checkCode").value == "验证码") {
            getId("txt_checkCode").value = "";
        }
    }

    function CodeBlur() {
        var txt = getId("txt_checkCode").value;
        if (getId("txt_checkCode").value == "") {
            getId("txt_checkCode").value = "验证码";
        }
    }

//更换验证码功能
function getVerCode(img_id) {
    var verify = document.getElementById(img_id);
    verify.setAttribute('src', '/rndcode.ashx?' + Math.random());
}

function Valid() {
    var isOk = true;
    var username = document.getElementById("txtLoginName").value.replace(/(^\s*)|(\s*$)/g, "");
    var pwd = document.getElementById("txtPassword").value.replace(/(^\s*)|(\s*$)/g, "");
    var checkCode = document.getElementById("txt_checkCode").value.replace(/(^\s*)|(\s*$)/g, "");

    if (username == "" || username == "登录名") {
        //alert("请输入登录名");
        layer.alert('请输入登录名');
        isOk = false;
    }
    else if (pwd == "" || pwd == "++++++") {
        //alert("请输入密码");
        layer.alert('请输入密码');
        isOk = false;
    }
    else if (checkCode == "" || checkCode == "验证码") {
        //alert("请输入验证码");
        layer.alert('请输入验证码');
        isOk = false;
    }
    return isOk;
}

</script>

</head>
<body onload="document.getElementById('txtPassword').value='++++++'" style="background: url(/images/banner_login.jpg)repeat;">
    <form id="form1" runat="server">
	  <div class="login">
	<h2>&nbsp;</h2>
	<div class="login-top">
		<h1>好宝宝后台管理</h1>
	
			<input id="txtLoginName" runat="server" type="text" value="" placeholder="登录名" onfocus="NameFocus()" onblur="NameBlur()" />
			<input id="txtPassword" runat="server" type="password" value="" placeholder="密码" onfocus="PwdFocus()" onblur="PwdBlur()"/>
            <input id="txt_checkCode" runat="server" type="text" name="vercode" class="pass-text-input" value="" placeholder="验证码" onfocus="CodeFocus()" onblur="CodeBlur()" autocomplete="off"> 
	
	    <div class="forgot">
	    	<span class="code_img"><img src="/rndcode.ashx" id="Img1" alt="验证码" align="absmiddle" border="0"/></span> 
            <a href="javascript:getVerCode('Img1')">换一张</a>
	    	<asp:Button ID="btnLogin" runat="server" Text="登录" onclick="btnLogin_Click" OnClientClick="return Valid();" />
	    </div>
	</div>
	<div class="login-bottom">
		<h3>New User &nbsp;<a href="#">Register</a>&nbsp Here</h3>
	</div>
</div>	
<div class="copyright">
	<p><a target="_blank" href="http://www.up927.com/">好宝宝儿童早教网</a></p>
</div>
	  
    </form>
</body>
</html>
