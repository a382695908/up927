<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index_top.aspx.cs" Inherits="MyProject02.xzdd927.index_top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <script type="text/javascript">
function logout(){
	if (confirm("您确定要退出控制面板吗？"))
	    top.location = "/xzdd927/login.html";
	return false;
}
    </script>

    <script type="text/javascript">
function showsubmenu(sid) {
	var whichEl = eval("submenu" + sid);
	var menuTitle = eval("menuTitle" + sid);
	if (whichEl.style.display == "none"){
		eval("submenu" + sid + ".style.display=\"\";");
	}else{
		eval("submenu" + sid + ".style.display=\"none\";");
	}
}
    </script>

    <meta http-equiv="Content-Type" content="text/html;charset=gb2312" />

    <script type="text/javascript">
function showsubmenu(sid) {
	var whichEl = eval("submenu" + sid);
	var menuTitle = eval("menuTitle" + sid);
	if (whichEl.style.display == "none"){
		eval("submenu" + sid + ".style.display=\"\";");
	}else{
		eval("submenu" + sid + ".style.display=\"none\";");
	}
}
    </script>
<script>function clockon(contentDate){    
var now = new Date();    
var year = now.getYear();    
var month = now.getMonth();    
var date = now.getDate();    
var day = now.getDay();    
var hour = now.getHours();    
var minu = now.getMinutes();    
var sec = now.getSeconds();    
var week;     month = month+1;    
if(month<10)month="0"+month;    
if(date<10)date="0"+date;    
if(hour<10)hour="0"+hour;    
if(minu<10)minu="0"+minu;    
if(sec<10)sec="0"+sec;    
var arr_week = new Array(" 星期日 "," 星期一 "," 星期二 "," 星期三 "," 星期四 "," 星期五 "," 星期六 ");     
week = arr_week[day];    
var time = "";     
time = year+"/"+month+"/"+date+"/  "+week+"  "+hour+"："+minu+"："+sec;    
if(document.all)    
{         contentDate.innerHTML="["+time+"]"    
}    
var timer = setTimeout("clockon(contentDate)",200);            
}
</script>
</head>
<form id="form1" runat="server">
<base target="main" />
<link href="/images/skin.css" rel="stylesheet" type="text/css"/>
<body leftmargin="0" topmargin="0"  scroll="no"> <%--onLoad="clockon(contentDate)"--%>
    <table width="100%" height="30" border="0" cellpadding="0" cellspacing="0" class="admin_topbg">
        <tr>
            <td width="31%" height="64">
                <img src="/images/logo.gif" width="262" height="64">
            </td>
            <td width="39%" valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="64%" height="38" class="admin_txt" style=" text-align:center;" >
                        <div>
                           <div id="contentDate" style="float:left;"></div>
                            <div  style="">欢迎登陆</div>
                        </div>                  
                        </td>
                        <td width="22%" >
                            <a href="#" target="_self" onclick="logout();">
                                <img src="/images/out.gif" alt="安全退出" width="46" height="20" border="0"></a>
                            <%--<asp:ImageButton ID="imgBtn_LogOut" runat="server" ImageUrl="/images/out.gif" 
                                onclick="imgBtn_LogOut_Click"/>--%>
                        </td>
                        <td width="4%">
                      
                        </td>
                    </tr>
                    <tr>
                        <td height="19" colspan="3">
                    
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</form>
