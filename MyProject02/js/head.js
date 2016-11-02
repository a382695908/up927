(function() {
    //判断是否手机端并跳转
    var userAgentInfo = navigator.userAgent;
    var Agents = ["Android", "iPhone",
            "SymbianOS", "Windows Phone",
            "iPad", "iPod"];
    var flag = true;
    for (var v = 0; v < Agents.length; v++) {
        if (userAgentInfo.indexOf(Agents[v]) > 0) {
            flag = false;
            break;
        }
    }
    if (flag == false) {
        var url = window.location.href;
        if (url == "http://www.up927.com/") {
            window.location.href = "http://www.up927.com/wap/index.html";
        }
        else {
            url = url.replace("up927.com/", "up927.com/wap/").replace(".html", ".shtml");
            window.location.href = url;
        }
    }

    //判断来路防止被镜像
    var host = window.location.host;
    if (host.indexOf(".up927.com") < 0 && host.indexOf("localhost") < 0) {
        window.location.href = "http://www.up927.com/" + location.pathname + location.search; //window.location.pathname + document.search;
    }

    //根据标题、标签搜索文章
    var div_button_search = document.getElementById('div_button_search');
    eventUtil.addHandler(div_button_search, 'click', function() {
        var txt = document.getElementById("txt_search").value.replace(/(^\s*)|(\s*$)/g, "")
        if (txt != "") {
            where = "?title=" + escape(txt);
            window.open("/list.aspx" + where);
        }
    });
    //按回车搜索
    var txt_search = document.getElementById('txt_search');
    eventUtil.addHandler(txt_search, 'keypress', function() {
        if (event.keyCode == 13) {
            var txt = document.getElementById("txt_search").value.replace(/(^\s*)|(\s*$)/g, "")
            if (txt != "") {
                where = "?title=" + escape(txt);
                window.open("/list.aspx" + where);
            }
        }
    });

    //设置导航选中样式
    if (document.getElementById("hid_type")) {
        var type = document.getElementById("hid_type").value; //alert("nav_a_" + type);
        if (type != "") {
            if (document.getElementById("nav_a_" + type)) {
                document.getElementById("nav_a_" + type).className = "current";
            }
        }
    }
})()

//------------------------回到顶部弹出层------------------------------------------------------

$(document).ready(function(e) {
    $("#rightButton").css("right", "0px");

    var button_toggle = true;
    $(".right_ico").on("mouseover", function() {
        var tip_top;
        var show = $(this).attr('show');
        var hide = $(this).attr('hide');
        tip_top = show == 'tel' ? 65 : -10;
        button_toggle = false;
        if (show == "tel") {
            $("#right_tip").attr("class", "right_tip1");
        }
        else {
            $("#right_tip").attr("class", "right_tip");
        }
        $("#right_tip").css("top", tip_top).show().find(".flag_" + show).show("");
        $(".flag_" + hide).hide("");

    }).on("mouseout", function() {
        button_toggle = true;
        hideRightTip();
    });

    $("#right_tip").on("mouseover", function() {
        button_toggle = false;
        $(this).show();
    }).on("mouseout", function() {
        button_toggle = true;
        hideRightTip();
    });

    function hideRightTip() {
        setTimeout(function() {
            if (button_toggle) $("#right_tip").hide();
        }, 50);
    }

    $("#backToTop").on("click", function() {
        var _this = $(this);
        $('html,body').animate({ scrollTop: 0 }, 100, function() {
            _this.hide();
        });
    });

    $(window).scroll(function() {
        var htmlTop = $(document).scrollTop();
        if (htmlTop > 0) {
            $("#backToTop").fadeIn();
        } else {
            $("#backToTop").fadeOut();
        }
    });
});

//------------------------回到顶部弹出层 结束------------------------------------------------------