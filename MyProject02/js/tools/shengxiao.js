
function Set12(id)
{
    var o=document.getElementById(id).style.display;
    if( o=="none" || o=="")
    {
        $("#"+id+"_12").attr("class","xingzuo_12");
    }
}

function ShowXingzuo(xingzuo)
{
    $("#div_shu_12").attr("class","xingzuo_12");
    $("#div_niu_12").attr("class","xingzuo_12");
    $("#div_hu_12").attr("class","xingzuo_12");
    $("#div_tu_12").attr("class","xingzuo_12");
    $("#div_long_12").attr("class","xingzuo_12");
    $("#div_she_12").attr("class","xingzuo_12");
    
    $("#div_ma_12").attr("class","xingzuo_12");
    $("#div_yang_12").attr("class","xingzuo_12");
    $("#div_hou_12").attr("class","xingzuo_12");
    $("#div_ji_12").attr("class","xingzuo_12");
    $("#div_gou_12").attr("class","xingzuo_12");
    $("#div_zhu_12").attr("class","xingzuo_12");
    
    if(xingzuo=="鼠")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_shu").style.display="block";
        
        $("#div_shu_12").attr("class","xingzuo_12_1");
//        $("#div_mojie_12").mouseover(function(){
//        $(this).attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="牛")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_niu").style.display="block";
        $("#div_niu_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="虎")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_hu").style.display="block";
        $("#div_hu_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="兔")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_tu").style.display="block";
        $("#div_tu_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="龙")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_long").style.display="block";
        $("#div_long_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="蛇")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_she").style.display="block";
        $("#div_she_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="马")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_ma").style.display="block";
        $("#div_ma_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="羊")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_yang").style.display="block";
        $("#div_yang_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="猴")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_hou").style.display="block";
        $("#div_hou_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="鸡")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_ji").style.display="block";
        $("#div_ji_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="狗")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_gou").style.display="block";
        $("#div_gou_12").attr("class","xingzuo_12_1");
    }
    else if(xingzuo=="猪")
    {
        $("div[class='xingzuo_desc']").css("display","none"); 
        document.getElementById("div_zhu").style.display="block";
        $("#div_zhu_12").attr("class","xingzuo_12_1");
    }
}