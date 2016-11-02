<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MyProject01.wap.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>52飞越网</title>
<link rel="icon" href="/wap/images/favicon.ico" type="image/x-icon" />
<link rel="shortcut icon" href="/wap/images/favicon.ico" type="image/x-icon" />
<link rel="stylesheet" href="/wap/css/styles.css" type="text/css">
<script type="text/javascript" src="/wap/js/jquery.min.js"></script>
</head>
<body>
<div class="wrap bc">
  
    <ul class="nav title mt10">
	  <li><a href="/wap/list.aspx?a_t=7">创业励志</a></li>
	  <li><a href="/wap/list.aspx?a_t=13">创业案例</a></li>
	  <li><a href="/wap/list.aspx?a_t=15">职场人生</a></li>
	  <li><a href="/wap/list.aspx?a_t=8">生活点滴</a></li>
      <li><a href="/wap/list.aspx?a_t=5" class="last">开心幽默</a></li>
	</ul>
	<div class="logo oh tc mt10">
	   <img src="/wap/images/logo.jpg" />
	</div>
	
	<div class="title1 mt10 pr">
	  <h2>首页头条<a href="/wap/list.aspx" class="more pa">更多<img src="/wap/images/more.png" /></a></h2>
	</div>
	<div class="list">
	  <ul>
	    <li>
	        <asp:Repeater ID="repList1" runat="server" >
                <ItemTemplate>
                        <a href="/wap<%#(Eval("html"))%>"><%#GetPartContent(Eval("title").ToString(), 20)%></a></br>
                    </ItemTemplate>
            </asp:Repeater>
	    </li>
	  </ul>
	</div>

	<div class="title1 mt10 pr">
	  <h2>创业励志<a href="/wap/list.aspx?a_t=7" class="more pa">更多<img src="/wap/images/more.png" /></a></h2>
	</div>
	<div class="list">
	  <ul>
	    <li>
	        <asp:Repeater ID="repList2" runat="server" >
                <ItemTemplate>
                        <a href="/wap<%#(Eval("html"))%>"><%#GetPartContent(Eval("title").ToString(), 20)%></a></br>
                    </ItemTemplate>
            </asp:Repeater>
	    </li>
	  </ul>
	</div>
	
	<div class="title1 mt10 pr">
	  <h2>创业案例<a href="/wap/list.aspx?a_t=13" class="more pa">更多<img src="/wap/images/more.png" /></a></h2>
	</div>
	<div class="list">
	  <ul>
	    <li>
	        <asp:Repeater ID="repList3" runat="server" >
                <ItemTemplate>
                        <a href="/wap<%#(Eval("html"))%>"><%#GetPartContent(Eval("title").ToString(), 20)%></a></br>
                    </ItemTemplate>
            </asp:Repeater>
	    </li>
	  </ul>
	</div>
	
	<div class="title1 mt10 pr">
	  <h2>职场人生<a href="/wap/list.aspx?a_t=15" class="more pa">更多<img src="/wap/images/more.png" /></a></h2>
	</div>
	<div class="list">
	  <ul>
	    <li>
	        <asp:Repeater ID="repList4" runat="server" >
                <ItemTemplate>
                        <a href="/wap<%#(Eval("html"))%>"><%#GetPartContent(Eval("title").ToString(), 20)%></a></br>
                    </ItemTemplate>
            </asp:Repeater>
	    </li>
	  </ul>
	</div>
	
	<div class="title1 mt10 pr">
	  <h2>生活点滴<a href="/wap/list.aspx?a_t=8" class="more pa">更多<img src="/wap/images/more.png" /></a></h2>
	</div>
	<div class="list">
	  <ul>
	    <li>
	        <asp:Repeater ID="repList5" runat="server" >
                <ItemTemplate>
                        <a href="/wap<%#(Eval("html"))%>"><%#GetPartContent(Eval("title").ToString(), 20)%></a></br>
                    </ItemTemplate>
            </asp:Repeater>
	    </li>
	  </ul>
	</div>
	
	<div class="title1 mt10 pr">
	  <h2>开心幽默<a href="/wap/list.aspx?a_t=5" class="more pa">更多<img src="/wap/images/more.png" /></a></h2>
	</div>
	<div class="list">
	  <ul>
	    <li>
	        <asp:Repeater ID="repList6" runat="server" >
                <ItemTemplate>
                        <a href="/wap<%#(Eval("html"))%>"><%#GetPartContent(Eval("title").ToString(), 20)%></a></br>
                    </ItemTemplate>
            </asp:Repeater>
	    </li>
	  </ul>
	</div>
	
	<div class="links mt10 oh cb">
	  <ul class="tc">
	    <li><a href="/wap/list.aspx?a_t=16"><div style="width:196px;">营销技巧</div></a></li>
	    <li><a href="/wap/list.aspx?a_t=6"><div style="width:196px;" >人生感悟</div></a></li>
	    <li><a href="/wap/list.aspx?a_t=10"><div style="width:196px;" >热点名人</div></a></li>
	    <li><a href="/wap/list.aspx?a_t=9"><div style="width:196px;" >励志语录</div></a></li>
		
		
		
		<li><a href="/wap/list.aspx?a_t=14"><div style="width:196px;" >青岛创业</div></a></li>
		<li><a href="/wap/list.aspx?a_t=13"><div style="width:196px;" >创业案例</div></a></li>
	  </ul>
	</div>
	
	<div class="footer mt10 tc">
      <p class="phone">站长QQ：1056625972&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;邮箱：1056625972@qq.com</p>
      <p class="copyright">Copyright &copy; 2015.Company name All rights reserved.</p>
      <p class="support">鲁ICP备15001975号</p>
    </div>
  </div> 
  <script type="text/javascript" src="/wap/js/script.js"></script>
</body>
</html>
