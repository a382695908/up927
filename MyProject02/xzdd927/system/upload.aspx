<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="MyProject02.xzdd927.system.upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
<div>
文件路径：<asp:TextBox ID="txt_path" runat="server" Width="220px"></asp:TextBox>
<br/><br/>
<asp:FileUpload ID="fu1" runat="server" Width="300px" />
<br/><br/>
<asp:Button ID="btn_upload" runat="server" Text="上 传" OnClick="btn_upload_Click" Width="100"/>
</div>
</form>
</body>
</html>
