<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index_left.aspx.cs" Inherits="MyProject02.xzdd927.index_left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>无标题页</title>
<link rel="stylesheet" href="/css/bianji_ht.css/jquery.treeview.css" />
<link rel="stylesheet" href="/css/bianji_ht.css/screen.css" />
<script src="/js/jquerym.js" type="text/javascript"></script>
<script src="/js/jquery.treeview.js" type="text/javascript"></script>

<script type="text/javascript">
$(document).ready(function() {
$("#navigation").treeview({
persist: "location",
collapsed: true,
unique: true
});
})
</script>
</head>
<body>
<input id="hidRightSearch" type="hidden" runat="server"/>
<input id="hidManageRighptSearch" type="hidden" runat="server"/>
<ul id="navigation">

<li><span>管理员</span>
<ul>
<li><a href="/xzdd927/admin/admin_list.aspx" target="mainFrame">编辑列表</a></li>
</ul>
</li>

<li><span>文章管理</span>
<%--<ul>--%>
<li><a href="/xzdd927/article/add_article.aspx" target="mainFrame">添加文章</a></li>
<li><a href="/xzdd927/article/article_list.aspx" target="mainFrame">文章列表</a></li>
<li><a href="/xzdd927/article/image_list.aspx" target="mainFrame">图片列表</a></li>
<li><a href="/xzdd927/article/article_tag.aspx" target="mainFrame">文章标签管理</a></li>
<li><a href="/xzdd927/article/article_type.aspx" target="mainFrame">文章分类管理</a></li>
<li><a href="/xzdd927/article/UpdateHtml.aspx" target="mainFrame">重新生成静态页</a></li>
<%--</ul>--%>
</li>

<li><span>友情链接</span>
<ul>
<li><a href="/xzdd927/friendlink/list.aspx" target="mainFrame">友链列表</a></li>
<li><a href="/xzdd927/friendlink/order.aspx" target="mainFrame">友链排序</a></li>
</ul>
</li>

<li><span>系统管理</span>
<ul>
<li><a href="/xzdd927/system/upload.aspx" target="mainFrame">上传文件</a></li>
</ul>
</li>

</ul>
</body>
</html>
