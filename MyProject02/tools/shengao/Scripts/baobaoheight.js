$(document).ready(function() {
    var message = 0;
    var parentHeight = {};
    var parentHZ = { mother: "妈妈", father: "爸爸" };
    //验证数字有效
    function check(obj) {
        if (!obj.value) return { suc: 0, info: "亲，" + parentHZ[obj.name] + "的身高不能为空哦~" };
        re = /^[\d\.]+$/
        if (!re.test(obj.value)) {
            obj.value = "";
            return { suc: 0, info: "亲，" + parentHZ[obj.name] + "的身高请输入数字哦~" };
        }
        return { suc: 1, info: "正确" };
    }
    //计算胎儿值
    function calculateBabyHeight(fatherHeight, motherHeight, sex) {
        if (sex === "male") {

            return (parseFloat(fatherHeight) + parseFloat(motherHeight)) * 1.08 / 2;
        }
        if (sex === "female") {
            return (parseFloat(fatherHeight) * 0.923 + parseFloat(motherHeight)) / 2;
        }
    }
    //获取获取双亲高度
    function getParentHeight(evn) {
        $this = evn;
        message = check($this);
        if ($this.name == "father")
            parentHeight.father = $this.value;
        if ($this.name == "mother")
            parentHeight.mother = $this.value;
    }
    // 展示baby身高
    function showBHeight(BHeight) {
        //alert(BHeight);
        $('#babyHeight').empty();
        $('#babyHeight').html('您的宝宝可能的身高：<span>' + BHeight + '</span>厘米（cm）');
    }

    $('#calculateBabyHeight').click(function() {

        $('.inputN').each(function() {
            getParentHeight(this);
            if (!message.suc) {
                 layer.alert(message.info);
//                $("#div_content_alert").html(message.info);
//                $('#myModal_alert').modal('show');
                return false; //只跳出each
            }
        });
        if (!message.suc)
            return false;
        //var sex = ""; //$("input:[name=sex]:radio:checked").val();
        var sex = $('input:radio[name="sex"]:checked').val();
//        if ($("#rdo_male").checked==true) {
//            sex = $("#rdo_male").val();
//        }
//        else {
//            sex = $("#rdo_female").val();
//        } 
        if (sex == undefined) {
            layer.alert('亲，请选择宝宝性别哦~');
//            $("#div_content_alert").html("亲，请选择宝宝性别哦~");
//            $('#myModal_alert').modal('show');
            return false;
        }
        if (parentHeight.father <= 50 || parentHeight.father >= 300) {
            layer.alert('哎呀，爸爸的身高不在有效范围内呢~');
//            $("#div_content_alert").html("哎呀，爸爸的身高不在有效范围内呢~");
//            $('#myModal_alert').modal('show');
            return false;
        }
        if (parentHeight.mother <= 50 || parentHeight.mother >= 300) {
            layer.alert('哎呀，妈妈的身高不在有效范围内呢~');
//            $("#div_content_alert").html("哎呀，妈妈的身高不在有效范围内呢~");
//            $('#myModal_alert').modal('show');
            return false;
        }
        var BHeight = calculateBabyHeight(parentHeight.father, parentHeight.mother, sex);
        showBHeight(BHeight.toFixed(1));
    });
});