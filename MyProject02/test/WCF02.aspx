<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WCF02.aspx.cs" Inherits="MyProject02.test.WCF02" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
<div>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btnUpdate" runat="server" Text="上传" onclick="btnUpdate_Click" />
</div>
</form>
</body>
</html>
