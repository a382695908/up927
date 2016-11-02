/* (c) 2012 JYC.LA Inc. 0326*/
function $(id) {
    return document.getElementById(id)
}
//var health = $("health");
function healthtime() {
    date = new Date();
    var countyear = date.getFullYear();
    var countmonth = date.getMonth();
    var countday = date.getDate();
    document.getElementById("txt_month").value = countmonth + 1;
    document.getElementById("txt_year").value = countyear;
    document.getElementById("txt_day").value = countday;
    Datejudgment()
}
function Datejudgment() {
    var health = $("health");
    var hongse = new Date();
    if (document.getElementById("txt_year").value == "" || document.getElementById("txt_month").value == "" || document.getElementById("txt_day").value == "") {
        layer.alert("请填写完整年月日~");
        return false
    }
    if (document.getElementById("txt_year").value > 2050 || document.getElementById("txt_year").value < 1990) {
        layer.alert("请填写正确年份~");
        document.getElementById("txt_year").focus();
        return false
    }
    if (document.getElementById("txt_year").value > hongse.getFullYear()) {
        layer.alert("输入的的年份可能过大，请重新输入~");
        document.getElementById("txt_year").focus();
        return false
    }
    if (document.getElementById("txt_year").value < hongse.getFullYear() - 1) {
        layer.alert("输入的的年份可能过小，请重新输入~");
        document.getElementById("txt_year").focus();
        return false
    }
    if (document.getElementById("txt_month").value > 12 || document.getElementById("txt_month").value < 1) {
        layer.alert("请填写正确月份~");
        document.getElementById("txt_month").focus();
        return false
    }
    if (document.getElementById("txt_day").value > 31 || document.getElementById("txt_day").value < 1) {
        layer.alert("请填写正确日子~");
        document.getElementById("txt_day").focus();
        return false
    }
    if (!isDate(document.getElementById("txt_year").value, document.getElementById("txt_month").value, document.getElementById("txt_day").value)) {
        layer.alert("年月日组合有错,请重新填写~");
        return false
    }
    var yue = document.getElementById("txt_mweek").value;
    var true_number = 280;
    var zise = new Date(document.getElementById("txt_year").value + "/" + document.getElementById("txt_month").value + "/" + document.getElementById("txt_day").value);
    if (yue < 28 && yue > 19) {
        true_number = 280 - (28 - yue);
        var miaoshu = 280 * 1000 * 3600 * 24 - (28 - yue) * 1000 * 3600 * 24
    } else {
        if (yue > 28 && yue < 41) {
            true_number = 280 + (yue - 28);
            var miaoshu = 280 * 1000 * 3600 * 24 + (yue - 28) * 1000 * 3600 * 24
        } else {
            if (yue == 28) {
                true_number = 280;
                var miaoshu = 280 * 1000 * 3600 * 24
            } else {
            layer.alert("哎呀，您输入的月经周期与实际不符，请重新输入~");
                document.getElementById("txt_mweek").focus()
            }
        }
    }
    var lse = new Date();
    if ((lse.getTime() - zise.getTime()) > miaoshu) {
        layer.alert("哎呀，您输入的日期可能过早，请重新输入~");
        document.getElementById("txt_year").focus();
        return false
    }
    if ((lse.getTime() - zise.getTime()) < 0) {
        layer.alert("哎呀，您输入的时间还没有到来，请重新输入~");
        document.getElementById("txt_year").focus();
        return false
    }
    function isDate(year, month, day) {
        month = month - 1;
        var tempDate = new Date(year, month, day);
        if ((year2k(tempDate.getFullYear()) == year) && (month == tempDate.getMonth()) && (day == tempDate.getDate())) {
            return true
        } else {
            return false
        }
    }
    function year2k(d) {
        return (d < 1000) ? d + 1900 : d
    }
    var stime = new Date();
    stime.setFullYear(document.getElementById("txt_year").value, document.getElementById("txt_month").value - 1, document.getElementById("txt_day").value);
    if (document.getElementById("txt_mweek").value != "") {
        var temptime = stime.getTime();
        stime.setTime((stime.getTime() + true_number * 24 * 3600 * 1000));
        yuchan = stime.getFullYear() + "/" + (stime.getMonth() + 1) + "/" + stime.getDate();
        document.getElementById("txt_ycq_year").value = stime.getFullYear();
        document.getElementById("txt_ycq_month").value = stime.getMonth() + 1;
        document.getElementById("txt_ycq_day").value = stime.getDate();
        var nowt = new Date();
        var t = nowt.getTime();
        if (yue == 20) {
            var hong = t + (1000 * 60 * 60 * 24) * 8
        }
        if (yue == 21) {
            var hong = t + (1000 * 60 * 60 * 24) * 7
        }
        if (yue == 22) {
            var hong = t + (1000 * 60 * 60 * 24) * 6
        }
        if (yue == 23) {
            var hong = t + (1000 * 60 * 60 * 24) * 5
        }
        if (yue == 24) {
            var hong = t + (1000 * 60 * 60 * 24) * 4
        }
        if (yue == 25) {
            var hong = t + (1000 * 60 * 60 * 24) * 3
        }
        if (yue == 26) {
            var hong = t + (1000 * 60 * 60 * 24) * 2
        }
        if (yue == 27) {
            var hong = t + (1000 * 60 * 60 * 24)
        }
        if (yue == 28) {
            var hong = t
        }
        if (yue == 29) {
            var hong = t - (1000 * 60 * 60 * 24)
        }
        if (yue == 30) {
            var hong = t - (1000 * 60 * 60 * 24) * 2
        }
        if (yue == 31) {
            var hong = t - (1000 * 60 * 60 * 24) * 3
        }
        if (yue == 32) {
            var hong = t - (1000 * 60 * 60 * 24) * 4
        }
        if (yue == 33) {
            var hong = t - (1000 * 60 * 60 * 24) * 5
        }
        if (yue == 34) {
            var hong = t - (1000 * 60 * 60 * 24) * 6
        }
        if (yue == 35) {
            var hong = t - (1000 * 60 * 60 * 24) * 7
        }
        if (yue == 36) {
            var hong = t - (1000 * 60 * 60 * 24) * 8
        }
        if (yue == 37) {
            var hong = t - (1000 * 60 * 60 * 24) * 9
        }
        if (yue == 38) {
            var hong = t - (1000 * 60 * 60 * 24) * 10
        }
        if (yue == 39) {
            var hong = t - (1000 * 60 * 60 * 24) * 11
        }
        if (yue == 40) {
            var hong = t - (1000 * 60 * 60 * 24) * 12
        }
        var chatime = hong - temptime;
        var chaweek = Math.floor((chatime) / (1000 * 60 * 60 * 24 * 7));
        var chaweek_1 = Math.floor((chatime) / (1000 * 60 * 60 * 24));
        document.health.yuchan2.value = chaweek + 1;

        var online = new Date(yuchan);
        var now = new Date();
        var leave = online.getTime() - now.getTime();
        var day = Math.floor(leave / (1000 * 60 * 60 * 24)) + 1;
        document.health.countDown.value = day;
        var abc = ((280 - day) % 7) + 1;
        if (abc < 0) {
            abc = 0
        }
        document.health.ji.value = abc;
        if (chaweek < 0 || document.health.ji.value == 0) {
            layer.alert("哎呀，您现在还没有怀孕呢，请重新选择~");
//            $("content_font").innerHTML = "暂时没有内容！";
//            $("content_img").innerHTML = "暂时没有图片！";
//            $("content_ts").innerHTML = "暂时没有内容！";
//            $("content_menu1").innerHTML = "胎儿发育";
//            $("content_menu2").innerHTML = "身体变化";
//            $("content_menu3").innerHTML = "孕期营养"
        } else {
            chaweek = chaweek;
//            $("content_menu1").innerHTML = "<a onclick='menu1()'>胎儿发育</a>";
//            $("content_menu2").innerHTML = "<a onclick='menu2()'>身体变化</a>";
//            $("content_menu3").innerHTML = "<a onclick='menu3()'>孕期营养</a>"
        }
        if (chaweek_1 + 1 > true_number) {
            layer.alert("您的预产期已经过啦~")
        }
        return false
    }
}
