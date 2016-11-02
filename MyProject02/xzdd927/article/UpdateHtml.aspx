<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateHtml.aspx.cs" Inherits="MyProject02.xzdd927.article.UpdateHtml" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>批量生成页面</title>
</head>
<body>
<form id="form1" runat="server">
<div>
    <asp:Button ID="btnUpdateHtml" runat="server" Text="重新生成静态页" OnClientClick="return confirm('确定生成全部文章静态页？')"
        onclick="btnUpdateHtml_Click"/>
    
    </br></br>
        <asp:Button ID="btnUpdateHtml_Index" runat="server" Text="重新生成首页" 
        onclick="btnUpdateHtml_Index_Click" />
        
        &nbsp;&nbsp;
        <a href="http://www.up927.com/" target="_blank">查看首页</a>
        
    </br></br>
    <asp:Button ID="btnUpdateWapHtml" runat="server" Text="重新生成wap静态页" OnClientClick="return confirm('确定生成全部wap文章静态页？')"
        onclick="btnUpdateWapHtml_Click"/>
        
    </br></br>
    <asp:Button ID="btnUpdateSide" runat="server" Text="重新生成右侧"
        onclick="btnUpdateSide_Click"/>
        
         </br></br>
    <asp:Button ID="btnUpdate404" runat="server" Text="重新生成404"
        onclick="btnUpdate404_Click"/>
        
        </br></br>
        <asp:Button ID="btnSitemap" runat="server" Text="生成sitemap"
        onclick="btnSitemap_Click"/>
</div>
</form>
</body>
</html>
