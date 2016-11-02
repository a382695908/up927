<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="MyProject01.wap.list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title><%=this.html_title%></title>
<link rel="icon" href="/wap/images/favicon.ico" type="image/x-icon" />
<link rel="shortcut icon" href="/wap/images/favicon.ico" type="image/x-icon" />
<link rel="stylesheet" href="/wap/css/styles.css" type="text/css">
<script type="text/javascript" src="/wap/js/jquery.min.js"></script>
</head>
<body>
<div class="wrap bc">
    <div class="title tc pr top">
	  <a href="/wap/index.html"><span class="back-btn"></span></a><%=this.articleTypeName%>
	</div>
	<div class="list">
	  <ul>
	    <%=this.listStr%>
	    <%--<li>
	        <a href="content.html">9个理财方案，让你40岁之前多赚百万</a></br>
	        <a href="content.html">10招帮你进行口碑营销，快速建立品牌</a></br>
	        <a href="content.html">9个理财方案，让你40岁之前多赚百万</a></br>
	        <a href="content.html">9个理财方案，让你40岁之前多赚百万</a></br>
	        <a href="content.html">10招帮你进行口碑营销，快速建立品牌</a></br>
	    </li>
	    <li>
	        <a href="content.html">9个理财方案，让你40岁之前多赚百万</a></br>
	        <a href="content.html">10招帮你进行口碑营销，快速建立品牌</a></br>
	        <a href="content.html">9个理财方案，让你40岁之前多赚百万</a></br>
	        <a href="content.html">9个理财方案，让你40岁之前多赚百万</a></br>
	        <a href="content.html">10招帮你进行口碑营销，快速建立品牌</a></br>
	    </li>--%>
	  </ul>
	</div>

	<div class="footer mt10 tc">
      <p class="phone">站长QQ：1056625972&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;邮箱：1056625972@qq.com</p>
      <p class="copyright">Copyright &copy; 2015.Company name All rights reserved.</p>
      <p class="support">鲁ICP备15001975号</p>
    </div>
  </div> 
  <script type="text/javascript" src="js/script.js"></script>
</body>
</html>
