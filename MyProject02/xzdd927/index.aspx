<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MyProject02.xzdd927.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <title>后台管理系统</title>
</head>
<frameset rows="68,*" cols="*" frameborder="no" border="0" framespacing="0">
  <frame src="/xzdd927/index_top.aspx" name="topFrame" scrolling="Yes" noresize="noresize" id="topFrame" title="topFrame" />
  <frameset cols="160,*" rows="*" frameborder="no" border="0" framespacing="0">
    <frame src="/xzdd927/index_left.aspx" name="leftFrame" id="leftFrame" title="leftFrame" />
    <frame src="/xzdd927/article/article_list.aspx" name="mainFrame" id="mainFrame" title="mainFrame" />
  </frameset>
</frameset>
</html>
