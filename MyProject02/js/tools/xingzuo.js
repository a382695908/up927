

// 根据生日的月份和日期，计算星座。  http://blog.csdn.net/cuixiping/
function getAstro(m,d){    
    return "魔羯水瓶双鱼白羊金牛双子巨蟹狮子处女天秤天蝎射手魔羯".substr(m*2-(d<"102223444433".charAt(m-1)- -19)*2,2);
}

function Set12(id)
{
    var o=document.getElementById(id).style.display;
    if( o=="none" || o=="")
    {
        $("#"+id+"_12").attr("class","xingzuo_12");
    }
}

function GetXingzuo()
{
    var birth=document.getElementById("txt_date").value;
    var arrayBirth=birth.split('-');
    var month=arrayBirth[1];
    var day=arrayBirth[2];
    
    var xingzuo=getAstro(month,day);
    //document.getElementById("span_rmb").innerHTML=xingzuo;
    
    ShowXingzuo(xingzuo);
}

function ShowXingzuo(xingzuo)
{
    $("#div_mojie_12").attr("class","xingzuo_12");
    $("#div_shuiping_12").attr("class","xingzuo_12");
    $("#div_shuangyu_12").attr("class","xingzuo_12");
    $("#div_baiyang_12").attr("class","xingzuo_12");
    $("#div_jinniu_12").attr("class","xingzuo_12");
    $("#div_shuangzi_12").attr("class","xingzuo_12");
    
    $("#div_juxie_12").attr("class","xingzuo_12");
    $("#div_shizi_12").attr("class","xingzuo_12");
    $("#div_chunv_12").attr("class","xingzuo_12");
    $("#div_tianping_12").attr("class","xingzuo_12");
    $("#div_tianxie_12").attr("class","xingzuo_12");
    $("#div_sheshou_12").attr("class","xingzuo_12");
    
    if(xingzuo=="魔羯")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_mojie").style.display="block";
        
        $("#div_mojie_12").attr("class","xingzuo_12_1");
//        $("#div_mojie_12").mouseover(function(){
//        $(this).attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="水瓶")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_shuiping").style.display="block";
        $("#div_shuiping_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="双鱼")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_shuangyu").style.display="block";
        $("#div_shuangyu_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="白羊")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_baiyang").style.display="block";
        $("#div_baiyang_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="金牛")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_jinniu").style.display="block";
        $("#div_jinniu_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="双子")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_shuangzi").style.display="block";
        $("#div_shuangzi_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="巨蟹")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_juxie").style.display="block";
        $("#div_juxie_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="狮子")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_shizi").style.display="block";
        $("#div_shizi_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="处女")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_chunv").style.display="block";
        $("#div_chunv_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="天秤")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_tianping").style.display="block";
        $("#div_tianping_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="天蝎")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_tianxie").style.display="block";
        $("#div_tianxie_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="射手")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_sheshou").style.display="block";
        $("#div_sheshou_12").attr("class","xingzuo_12_1");
    }
}