
var commomValid = {
    //对电子邮件的验证
    email: function() {
        var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
        if (!myreg.test(txt)) {
            return false;
        }
        else {
            return true;
        }
    },
    //对手机号的验证
    mobile: function() {
        var myreg = /^0?1[3|4|5|7|8][0-9]\d{8}$/;
        if (!myreg.test(txt)) {
            return false;
        }
        else {
            return true;
        }
    }
}


