<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delegate01.aspx.cs" Inherits="MyProject02.test.Delegate01" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>委托、异步调用</title>
</head>
<body>
<form id="form1" runat="server">
<div>
    关键词：<input type="text" name="textfield" id="txt_keyword" style="width:150px; height:20px;border:1px #ccc solid;padding:7px 0 0 3px;" runat="server" value="贝贝贷"/>
    <br/>
    输入网址：<input type="text" name="textfield2" id="txt_url" style="width:200px; height:20px; border:1px #ccc solid;padding:7px 0 0 3px;"  runat="server" value="http://www.beibeidai.com/"/>
    <br/>
    <asp:Button ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" />
    <br/><br/>
    <div onclick="alert(<%=this.result %>)">显示</div>
    <%=this.result %>
</div>
</form>
</body>
</html>
