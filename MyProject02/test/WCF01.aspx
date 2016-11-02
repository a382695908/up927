<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WCF01.aspx.cs" Inherits="MyProject02.test.WCF01" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
<div>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <asp:Button ID="btnSubmit" runat="server" Text="测试WCF" 
        onclick="btnSubmit_Click" />
    <br />
    <%=this.show %>
</div>
</form>
</body>
</html>
