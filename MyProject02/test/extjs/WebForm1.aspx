<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MyProject02.test.extjs.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title></title>

<%--<script src="/test/js/extjs/vswd-ext_2.2.js" type="text/javascript"></script>--%>
///<reference path="/test/js/extjs/vswd-ext_2.2.js"/>
///<reference path="/test/js/extjs/adapter/ext/ext-base.js"/>
///<reference path="/test/js/extjs/ext-all-debug.js"/>
<link rel="stylesheet" type="text/css" href="/test/js/extjs/resources/css/ext-all.css" />
<!--

 注意：ext-base.js必须放在ext-all.js前面

-->
<script type="text/javascript" src="/test/js/extjs/adapter/ext/ext-base.js"></script>
<script type="text/javascript" src="/test/js/extjs/ext-all.js"></script>

</head>
<body>
<form id="form1" runat="server">
<div>
    <script>

//弹出一个提示框

Ext.onReady(function()

{

Ext.MessageBox.alert("hello","Hello,easyjf open source");




});

//显示一个窗口

Ext.onReady(function() {

    var win = new Ext.Window({ title: "hello", width: 300, height: 200, html: '<h1>Hello,easyjf open source</h1>' });

    win.show();

});

</script>

</div>
</form>
</body>
</html>
