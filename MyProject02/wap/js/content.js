
var host = window.location.host;
if (host.indexOf(".up927.com") < 0) {
    window.location.href = "http://www.up927.com/" + location.pathname + location.search; //window.location.pathname + document.search;
}

var this_url=window.location.href;
if(this_url.indexOf(".html")>=0)
{
    this_url=this_url.replace(".html",".shtml");
    window.location.href=this_url;
}
