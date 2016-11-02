//////////////////////////////////////////////////////////////////////////
//弹出层js类
//弹出成功失败提示
//跳转
//弹出层并新建窗口
//////////////////////////////////////////////////////////////////////////
function getId(id) {
    return document.getElementById("ctl00_ContentPlaceHolder1_" + id);
}
//预调整当前要弹出层的位置
function preShow(rtcontent){
     jQuery(".gl_shuaxin_02 > p").text(rtcontent);
     var obj = getCenterPoint("#completelayer");
     jQuery("#completelayer").css("top",obj.top)
                        .css("left",obj.left);                           
}

//弹出删除提示层
function showDelLayer(delMethod,class_id,_content){
    jQuery(".cancalbtn").click(function(){
        jQuery("#delete1,#overlayer").css("display","none");        
    });	 //设置取消按钮动作
    jQuery("#delbtn").unbind("click");
    jQuery("#delbtn").click(function(){
        if(typeof class_id != "undefined"){
            delMethod(class_id);      
        }else{
            delMethod();
        }
        jQuery("#delete1,#overlayer").css("display","none");     
    });//设置删除按钮动作
    if(typeof _content != "undefined"){
        jQuery("#deleteMessage").html(_content);
    }//设置删除提示语    
    var obj = getCenterPoint("#delete1");
     jQuery("#delete1").css({
        top:obj.top,
        left:obj.left,
        display:"block",
        position:"absolute",
        zIndex:999
     }); //弹出删除按钮     
     var pageSize = ___getPageSize();
     if(0==jQuery("#overlayer").length)
     {
         jQuery("<div></div>",{
            "id":"overlayer",        
            css:{   
                opacity: 0.3,
                filter:"Alpha(Opacity=30)"/*{opacityOverlay}*/,    
                zIndex:100,
                width: jQuery(document).width(),
                height: jQuery(document).height(),
                left: 0,
                top:0, 
                position:"absolute"                      
            }
        }).css("background-color", "#aaaaaa").appendTo(jQuery("body")).show();
     }else{
        jQuery("#overlayer").show();
     }
     
          
    
}
//显示正确错误结果不跳转
function showResult(rtcontent,result) {
    preShow(rtcontent);
    if(result){
        jQuery("#completelayer > .gl_shuaxin_01 > img").attr("src","/images/gl_shuaxin_01_tu02.gif");       
    }else{
        jQuery("#completelayer > .gl_shuaxin_01 > img").attr("src","/images/gl_shuaxin_01_tu01.gif");
    }
    jQuery("#completelayer").fadeIn("slow",function() {   
        setTimeout(function() {   
            jQuery("#completelayer").fadeOut("slow");   
        }, 1000);   
    }); 
    //window.setTimeout(function(){location.href='index.aspx?type=2'},1600);
}
//recontent 
function showResultAndOpen(rtcontent,rdurl) {
    //preShow(rtcontent);
   // jQuery("#completelayer > .gl_shuaxin_01 > img").attr("src","/images/gl_shuaxin_01_tu02.gif"); 
   // jQuery("#completelayer").fadeIn("slow",function() {   
   //     setTimeout(function() {   
   //         jQuery("#completelayer").fadeOut("slow");   
            window.open(rdurl);
  //      }, 1000);   
  //  }); 
}
//错误跳转
function showWrongAndRedirect(rtcontent,rdurl) {
    preShow(rtcontent);
    jQuery("#completelayer > .gl_shuaxin_01 > img").attr("src","/images/gl_shuaxin_01_tu01.gif");   
    jQuery("#completelayer").fadeIn("slow",function() {   
        setTimeout(function() {   
            jQuery("#completelayer").fadeOut("slow");   
            window.location.href=rdurl;
        }, 1000);   
    }); 
}
//正确跳转
function showResultAndRedirect(rtcontent,rdurl) {
    preShow(rtcontent);
    jQuery("#completelayer > .gl_shuaxin_01 > img").attr("src","/images/gl_shuaxin_01_tu02.gif");   
    jQuery("#completelayer").fadeIn("slow",function() {   
        setTimeout(function() {   
            jQuery("#completelayer").fadeOut("slow");   
            window.location.href=rdurl;
        }, 1000);   
    }); 
}

//显示正在保存loading
function showLoading() {
    jQuery(".gl_right").showLoading();
}
function hideLoading(){
    jQuery(".gl_right").hideLoading();
}


//function getPageSize() {
//    var xScroll, yScroll;
//    if (window.innerHeight && window.scrollMaxY) {
//        xScroll = window.innerWidth + window.scrollMaxX;
//        yScroll = window.innerHeight + window.scrollMaxY;
//    } else {
//        if (document.body.scrollHeight > document.body.offsetHeight) { // all but Explorer Mac    
//            xScroll = document.body.scrollWidth;
//            yScroll = document.body.scrollHeight;
//        } else { // Explorer Mac...would also work in Explorer 6 Strict, Mozilla and Safari    
//            xScroll = document.body.offsetWidth;
//            yScroll = document.body.offsetHeight;
//        }
//    }
//    var windowWidth, windowHeight;
    
//设置弹出层显示在屏幕中央位置
function SetLayerCenter(layerId) {
    //设置蒙层的大小
    jQuery("#bgDiv").css("width", window.screen.width)//jQuery(document.body).outerWidth()
     .css("height", jQuery(document).height());

    jQuery("#bgDiv").css("height", jQuery(document).height());

    var obj = getCenterPoint("#" + layerId);
    jQuery("#" + layerId).css("top", obj.top)
                    .css("left", obj.left);
}
//容器位置居中校正
function CheckCenter(name)
{
  if (window.screen.width >= 1024) {
       var left = (1200-850)/2
       jQuery("#" + name).css("left", left);
    } 
}
//获取该层的垂直水平居中位置
function getCenterPoint(layerid){
    var obj = new Object();
    var scrollOffset = getScrollOffset();
    var pageSize = ___getPageSize();
    obj.top = (pageSize[3]  -jQuery(layerid).outerHeight())/2 +scrollOffset.scrollTop;
    obj.left = (pageSize[2] -jQuery(layerid).outerWidth())/2 + scrollOffset.scrollLeft ;
    return obj;
}
//分浏览器获取当前页面的滚动条位置
function getScrollOffset(){
    var obj = new Object();    
    obj.scrollTop = Math.max(document.body.scrollTop,document.documentElement.scrollTop);
    obj.scrollLeft = Math.max(document.body.scrollLeft,document.documentElement.scrollLeft);
    return obj;
}
//获取当前页面的页面高度/宽度/当前窗口的可见高度/宽度
//网上copy的
function ___getPageSize() {
	var xScroll, yScroll;
	if (window.innerHeight && window.scrollMaxY) {	
		xScroll = window.innerWidth + window.scrollMaxX;
		yScroll = window.innerHeight + window.scrollMaxY;
	} else if (document.body.scrollHeight > document.body.offsetHeight){ // all but Explorer Mac
		xScroll = document.body.scrollWidth;
		yScroll = document.body.scrollHeight;
	} else { // Explorer Mac...would also work in Explorer 6 Strict, Mozilla and Safari
		xScroll = document.body.offsetWidth;
		yScroll = document.body.offsetHeight;
	}
	var windowWidth, windowHeight;
	if (self.innerHeight) {	// all except Explorer
		if(document.documentElement.clientWidth){
			windowWidth = document.documentElement.clientWidth; 
		} else {
			windowWidth = self.innerWidth;
		}
		windowHeight = self.innerHeight;
	} else if (document.documentElement && document.documentElement.clientHeight) { // Explorer 6 Strict Mode
		windowWidth = document.documentElement.clientWidth;
		windowHeight = document.documentElement.clientHeight;
	} else if (document.body) { // other Explorers
		windowWidth = document.body.clientWidth;
		windowHeight = document.body.clientHeight;
	}	
	// for small pages with total height less then height of the viewport
	if(yScroll < windowHeight){
		pageHeight = windowHeight;
	} else { 
		pageHeight = yScroll;
	}
	// for small pages with total width less then width of the viewport
	if(xScroll < windowWidth){	
		pageWidth = xScroll;		
	} else {
		pageWidth = windowWidth;
	}
	arrayPageSize = new Array(pageWidth,pageHeight,windowWidth,windowHeight);
	return arrayPageSize;
};


//$(function() {
//    $('#menu_1 li').hover(function() {
//        $(this).children('ul').stop(true, true).show();
//    }, function() {
//        $(this).children('ul').stop(true, true).hide();
//    });

//    $('#menu_1 li').hover(function() {
//        $(this).children('div').stop(true, true).show();
//    }, function() {
//        $(this).children('div').stop(true, true).hide();
//    });
//});
