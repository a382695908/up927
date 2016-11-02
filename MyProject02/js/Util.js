/*JS版的Server.UrlEncode编码函数*/ 
String.prototype.UrlEncode = function() 
{ 
var str = this; 
str = str.replace(/./g,function(sHex) 
{ 
window.EnCodeStr = ""; 
window.sHex = sHex; 
window.execScript('window.EnCodeStr=Hex(Asc(window.sHex))',"vbscript"); 
return window.EnCodeStr.replace(/../g,"%$&"); 
}); 
return str; 
} 

/*去除字符串两边空格*/
String.prototype.trim = function()    
{    
return this.replace(/(^\s*)|(\s*$)/g, "");    
} 

/*多浏览器兼容支持用法：<script src="/script/Util.js" type="text/javascript"></script><a href="javascript:void(0)" onclick="addBookmark(document.title,location.href)" title="收藏本页">加入收藏</a>*/
function addBookmark(title,url) 
{  
if (window.sidebar) 
{   
   window.sidebar.addPanel(title, url,"");   
}else if(document.all)
      {  
        window.external.AddFavorite(url,title);  
      }else if( window.opera && window.print ) 
      {  
        return true;
    }
    else if (window.chrome) {
        alert('点确定后请按ctrl+D来添加书签(Command+D for macs)');
    }
  
}  
/*设置当前页为首页用法：<script src="/script/Util.js" type="text/javascript"></script><a href="javascript:void(0)" onclick="SetHome(this,window.location)" target="_top">设为首页</a>*/
function setHomepage() {
    if (document.all) {
        document.body.style.behavior = 'url(#default#homepage)';
        document.body.setHomePage("http://www.52feiyue.com/");
    }
    else if (window.sidebar) {
        if (window.netscape) {
            try {
                netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
            }
            catch (e) {
                alert("该操作被浏览器拒绝，如果想启用该功能，请在地址栏内输入 about:config,然后将项 signed.applets.codebase_principal_support 值该为true");
            }
        }
        var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
        prefs.setCharPref('browser.startup.homepage', 'http://www.52feiyue.com/');
    }
} 

/*在客户端获取COOKIEcookies:Cookie集合名c_name:Cookie名*/
function getCookie(cookies,c_name)
{
if (document.cookie.length>0)
{
c_start=document.cookie.indexOf(cookies + "=")
if (c_start!=-1)
{ 
c_start=c_start + cookies.length+1 
c_end=document.cookie.indexOf(";",c_start)
if (c_end==-1) c_end=document.cookie.length
var v=document.cookie.substring(c_start,c_end)
    if(c_name!="")
    {
        s_start=v.indexOf(c_name+"=");
        if (s_start!=-1)
        {
        s_start=s_start+c_name.length+1
        s_end=v.indexOf("&",s_start);
            if(s_end==-1) s_end=v.length;
            v=v.substring(s_start,s_end);
        }
    }
 return unescape(v);
} 
}
return ""
}


var refresh = false;
var msloginw = "";
var xmlHttp;
var username;
function setfrm() {
//var str="<form id='loginForm' method='post' name='loginForm' action='http://www.imosi.com/company_login.aspx?ReturnUrl="+location.href+"'>
var str="<form id='loginForm' method='post' name='loginForm' action='http://www.imosi.com/company_login.aspx' target='_blank'><input type='hidden' name='username' id='username' /><input type='hidden' name='password' id='password' /></form>";

var doc=document.getElementById("loginFrame").contentDocument==undefined?document.frames["loginFrame"].document:document.getElementById("loginFrame").contentDocument
if(doc.body)
{
doc.body.innerHTML=str;
}
else
{
var bd=document.createElement("body");
bd.innerHTML=str;
doc.appendChild(bd)
}
doc.getElementById("username").value = document.getElementById("u").value == "用户名" ? "" : document.getElementById("u").value;
doc.getElementById("password").value = document.getElementById("p").value;
doc.forms[0].submit();
if (refresh) 
    window.setTimeout("window.location.reload();", 5000);
else
    window.setTimeout("validLogin('" + msloginw + "');", 5000);
}



function validLogin(width) {
    msloginw = width;
    username = getCookie("UserInfo", "company_name");
    if (username != null && username != "") {
        if (username.length > 20)
            username = username.substring(0, 17) + "...";
        if (msloginw != "") {
            document.getElementById("MS_Login").style.width = "290px";
            document.getElementById("MS_Login").style.position = "relative";
        }
        xmlHttp = GetXmlHttpObject();
        xmlHttp.onreadystatechange = stateChanged;
        xmlHttp.open("GET", "/ajax/ajax_messCount.ashx?_t="+Math.random(), true);
        xmlHttp.send(null);
    }
}





//-------------------------------------------
function setHomepage()
{
    if (document.all){
    document.body.style.behavior='url(#default#homepage)';
    document.body.setHomePage("http://www.52feiyue.com/");
    }
    else if (window.sidebar)
    {
    if(window.netscape)
    {
       try{ 
           netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect"); 
           } 
       catch (e) { 
           alert( "该操作被浏览器拒绝，如果想启用该功能，请在地址栏内输入 about:config,然后将项 signed.applets.codebase_principal_support 值该为true" );
       }
    }
    var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components. interfaces.nsIPrefBranch);
    prefs.setCharPref('browser.startup.homepage','http://www.imosi.com/');
    }
}

//转换字号
function showFS(size){
	if(size==14){
	    //alert("小");
		document.getElementById("contentText").className = "zxnews_fontbox zx_14col_000";
		document.getElementById("small").style.display = "";
		document.getElementById("big").style.display = "none";
	}
	if(size==16){
	    //alert("大");
		document.getElementById("contentText").className = "zxnews_fontbox zx_16col_000";
		document.getElementById("small").style.display = "none";
		document.getElementById("big").style.display = "";
	}
}

function Search()
 {
    var title=document.getElementById("txt_title").value;
    
    if(title.replace(/\s/ig,'')!=""&&title.replace(/\s/ig,'')!="请输入文章标题关键字")
    {
        window.location.href="/list.aspx?title="+escape(title);
    }
 }
 
 function xiaoshi()
{
var c = $("#txt_title").val().replace(/\s/ig,'');
if(c=="请输入文章标题关键字")
{$("#txt_title").val("");$("#txt_title").css("color","000000");}
if(c=="")
{$("#txt_title").val("请输入文章标题关键字");$("#txt_title").css("color","#B1B1B1");} }


//--------------------回到顶部弹出层------------------------------------------------------------

function goTopEx() { 
var obj = document.getElementById("div_QQ_float"); 
function getScrollTop() { 
return document.documentElement.scrollTop + document.body.scrollTop; 
} 
function setScrollTop(value) { 
if (document.documentElement.scrollTop) { 
document.documentElement.scrollTop = value; 
} else { 
document.body.scrollTop = value; 
} 
} 
window.onscroll = function() { 
getScrollTop() > 0 ? obj.style.display = "": obj.style.display = "none"; 
} 
obj.onclick = function() { 
var goTop = setInterval(scrollMove, 10); 
function scrollMove() { 
setScrollTop(getScrollTop() / 2.1); 
if (getScrollTop() < 1) clearInterval(goTop); 
} 
}
}

//获取当前的日期时间 格式“yyyy-MM-dd HH:MM:SS”
function getNowFormatDate() {
    var date = new Date();
    var seperator1 = "-";
    var seperator2 = ":";
    var month = date.getMonth() + 1;
    var strDate = date.getDate();
    if (month >= 1 && month <= 9) {
        month = "0" + month;
    }
    if (strDate >= 0 && strDate <= 9) {
        strDate = "0" + strDate;
    }
    var currentdate = date.getFullYear() + seperator1 + month + seperator1 + strDate
            + " " + date.getHours() + seperator2 + date.getMinutes()
            + seperator2 + date.getSeconds();
    return currentdate;
}