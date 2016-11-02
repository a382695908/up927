
var regApp = angular.module("regApp", []);

regApp.service("validEmailExistService", function($http) {
    var isOk = true;
    this.SelectEmailExist = function(email) {

        $http({
            url: '/ajax/ajax_m.aspx?get=5&email=' + email+"&_t=" + Math.random(),
            method: 'POST',
            //data: { g: '1', checkcode: '1', name: '2', pwd: '3' },
            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' }
        }).success(function(response) {
            if (response.status == 200) {
                //alert(response.status);
                isOk = true;
                //return true;
            }
            else {
                //alert(response.status);
                isOk = false;
                //return false;
            }
        })
        alert(isOk);
        return isOk;
    }
})



regApp.controller("regCtrl", function($scope, $http, validEmailExistService) {
    $scope.email = "";
    $scope.username = "";
    $scope.pwd = "";
    $scope.pwd1 = "";
    $scope.sex = "2";
    $scope.baby = "2";
    $scope.baby_date = getNowFormatDate(); //宝宝生日/预产期

//    $scope.SelectEmailExist = function() {
//        var isOk = true;
//        $http({
//            url: '/ajax/ajax_m.aspx?get=5&email=' + $scope.email,
//            method: 'POST',
//            //data: { g: '1', checkcode: '1', name: '2', pwd: '3' },
//            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' }
//        }).success(function(response) {
//            if (response.status == 200) {
//                //alert(response.status);
//                return true;
//            }
//            else {
//                //alert(response.status);
//                return false;
//            }
//            //alert(response.status);
//        }).error(function() {
//            alert("注册失败，请重试");
//        });
//        //alert(isOk);
//        return isOk;
//    }

    $scope.reg = function() {
        if ($scope.email == "") {
            $("#div_content_alert").html("亲，输入您的注册邮箱，可以用来登录，还能找回密码哦~");
            $('#myModal_alert').modal('show');
        }
        else if (!validEmail($scope.email)) {
            $("#div_content_alert").html("亲，您的注册邮箱格式有误哦~");
            $('#myModal_alert').modal('show');
        }
        else if (!validEmailExistService.SelectEmailExist($scope.email)) {
            $("#div_content_alert").html("亲，您的邮箱已被注册过了~");
            $('#myModal_alert').modal('show');
        }
        else if ($scope.username == "") {
            $("#div_content_alert").html("亲，输入您的昵称，可以用来登录哦~");
            $('#myModal_alert').modal('show');
        }
        else if ($scope.pwd == "") {
            $("#div_content_alert").html("亲，输入您的登录密码~");
            $('#myModal_alert').modal('show');
        }
        else if ($scope.pwd != $scope.pwd1) {
            $("#div_content_alert").html("亲，确认密码不一致哦~");
            $('#myModal_alert').modal('show');
        }
        else if ($scope.sex == "0") {
            $("#div_content_alert").html("亲，记得告诉我们您的性别哦~");
            $('#myModal_alert').modal('show');
        }
        else {
            if ($scope.baby == "2") {// 1、已有宝宝   2、正在孕期
                $scope.baby_date = $("#pre_year  option:selected").text() + "-" + $("#pre_month  option:selected").text() + "-" + $("#pre_day  option:selected").text();
            }
            else if ($scope.baby == "1") {// 1、已有宝宝   2、正在孕期
                $scope.baby_date = $("#birth_year  option:selected").text() + "-" + $("#birth_month  option:selected").text() + "-" + $("#birth_day  option:selected").text();
            }

            $http({
                url: '/ajax/ajax_m.aspx?get=3&email=' + $scope.email + "&username=" + $scope.username + "&pwd=" + $scope.pwd + "&sex=" + $scope.sex + "&baby=" + $scope.baby + "&baby_date=" + $scope.baby_date,
                method: 'POST',
                //data: { g: '1', checkcode: '1', name: '2', pwd: '3' },
                headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' }
            }).success(function(response) {
                if (response.status == "200") {
                    layer.alert("注册成功");
                    //window.location.href = "/index.aspx";
                }
                else {
                    layer.alert("注册失败，请重试");
                }
            }).error(function() {
                layer.alert("注册失败，请重试");
            });
        }
    }
})

function SelectEmailExist(email) {

}


function getId(id) {
    return document.getElementById(id);
}

//更换验证码功能
function getVerCode(img_id) {
    var verify = document.getElementById(img_id);
    verify.setAttribute('src', '/rndcode.ashx?' + Math.random());
}

function Valid() {
    //alert(1);
    var isOk = true;
    var email = document.getElementById("txt_email").value.replace(/(^\s*)|(\s*$)/g, "");
    var username = document.getElementById("txt_username").value.replace(/(^\s*)|(\s*$)/g, "");
    var pwd = document.getElementById("txt_pwd").value.replace(/(^\s*)|(\s*$)/g, "");
    var pwd1 = document.getElementById("txt_pwd1").value.replace(/(^\s*)|(\s*$)/g, "");
    var sex = $('input:radio[name="rdo_sex"]:checked').val();

    //var new_pwd1 = document.getElementById("txt_new1").value.replace(/(^\s*)|(\s*$)/g, "");

    if (email == "") {
        //layer.alert("请输入原始密码");
        $("#div_content_alert").html("亲，输入您的注册邮箱，可以用来登录，还能找回密码哦~");
        $('#myModal_alert').modal('show');
        isOk = false;
    }
    else if (!validEmail(email))
    {
        $("#div_content_alert").html("亲，您的注册邮箱格式有误哦~");
        $('#myModal_alert').modal('show');
        isOk = false;
    }
    else if (username == "") {
        //layer.alert("请输入新密码");
        $("#div_content_alert").html("亲，输入您的昵称，可以用来登录哦~");
        $('#myModal_alert').modal('show');
        isOk = false;
    }
    else if (pwd == "") {
        //layer.alert("请输入确认密码");
        isOk = false;
        $("#div_content_alert").html("亲，输入您的登录密码~");
        $('#myModal_alert').modal('show');
    }
    else if (pwd != pwd1) {
        //layer.alert("确认密码不一致");
        $("#div_content_alert").html("亲，确认密码不一致哦~");
        $('#myModal_alert').modal('show');
        isOk = false;
    }
    else if (sex == null) {
        //layer.alert("请输入确认密码");
        isOk = false;
        $("#div_content_alert").html("亲，记得告诉我们您的性别哦~");
        $('#myModal_alert').modal('show');
    }
    return isOk;
}




//$(function() {
//    $("#txt_email").popover({ trigger: 'hover', placement: 'right', content: "输入您的注册邮箱" });
//    $("#txt_username").popover({ trigger: 'hover', placement: 'right', content: "输入您的昵称" });
//    $("#txt_pwd").popover({ trigger: 'hover', placement: 'right', content: "输入您的登录密码" });
//    $("#txt_pwd1").popover({ trigger: 'hover', placement: 'right', content: "再次输入您的登录密码" });
//});

function SetBaby(rdo) {
    var baby = 0;
    if (rdo.checked) {
        baby = rdo.value;
    }
    if (baby == 1) {
        $("#divYucanqi").hide();
        $("#divBirth").show();
    }
    else if (baby == 2) {
        $("#divYucanqi").show();
        $("#divBirth").hide();
    }
    else {
        $("#divYucanqi").hide();
        $("#divBirth").hide();
    }
}



/*日期部分*/
/*[/static/bui/mtn/date/dateSelector.js]*/
/**
* Date Selector
* -------------
* Date Selector组的select元素的mouseenter事件触发实例化。
* 将实例化后的对象存储在.data-selector元素上
* 备注：
* 绑定在mouseenter是为了当用户触发其他可能的操作（click，focus）之前将数据准备好
*/
(function(global, $) {
    "use strict";

    var document = global.document;

    function DateSelector(selector, options) {
        var $element = $(selector);

        this.$element = $element;
        this.options = $.extend({}, $.fn.dateSelector.defaults, options);

        this.$year = $element.find("select[data-toggle=date-selector-year]");
        this.$month = $element.find("select[data-toggle=date-selector-month]");
        this.$date = $element.find("select[data-toggle=date-selector-date]");

        this.refresh();

        if (this.$year.length && this.$date.length) {
            //this.$year.on("change.dateSelector", $.proxy(this.date, this));
            this.$year.bind("change.dateSelector", $.proxy(this.date, this));
        }

        if (this.$month.length && this.$date.length) {
            //this.$month.on("change.dateSelector", $.proxy(this.date, this));
            this.$month.bind("change.dateSelector", $.proxy(this.date, this));
        }

    }

    DateSelector.prototype = {
        constructor: DateSelector,

        /*
        * 刷新年选择框
        */
        refreshYear: function(year) {
            var years = [],
                start = this.options.start || year - this.options.delta,
                end = this.options.end || +year + this.options.delta,
                i;

            for (i = end; i >= start; i -= 1) {
                if (i === +year) {
                    years.push("<option selected>" + i + "</option>");
                } else {
                    years.push("<option>" + i + "</option>");
                }
            }

            this.$year.html(years.join(""));
            //this.setYear(year);
        },

        /*
        * 设置年，并
        */
        setYear: function(year) {
            var that = this;
            if (this.$year.length) {
                that.$year.val(year);
                /*
                setTimeout(function () {
                that.$year.val(year);
                }, 0);
                */
            } else if (this.$month.length) {
                this.$month.data("year", year).trigger("change.dateSelector");
            }
        },

        getYear: function() {
            return parseInt(this.$year.val() || this.$month.data("year"), 10);
        },

        /*
        * 刷新月选择框
        */
        refreshMonth: function(month) {
            var months = [],
                start = 1,
                end = 12,
                i;

            for (i = start; i <= end; i += 1) {
                if (i === +month) {
                    months.push("<option selected>" + i + "</option>");
                } else {
                    months.push("<option>" + i + "</option>");
                }
            }

            this.$month.html(months.join(""));
            //this.setMonth(month);
        },

        setMonth: function(month) {
            var that = this;
            that.$month.val(month);
            /*
            setTimeout(function () {
            that.$month.val(month);
            }, 0);
            */
        },

        getMonth: function() {
            return parseInt(this.$month.val(), 10);
        },

        /*
        * 刷新日选择框
        */
        refreshDate: function(date) {
            var dates = [],
                start = 1,
                end,
                i;

            switch (+this.getMonth()) {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    end = 31;
                    break;

                case 2:
                    end = this.isLeapYear() ? 29 : 28;
                    break;

                default:
                    end = 30;
                    break;
            }

            for (i = start; i <= end; i += 1) {
                if (i === +date) {
                    dates.push("<option selected>" + i + "</option>");
                } else {
                    dates.push("<option>" + i + "</option>");
                }
            }
            this.$date.html(dates.join(""));
            //this.setDate(date);
        },

        setDate: function(date) {
            var that = this;
            that.$date.val(date);
            /*
            setTimeout(function () {
            that.$date.val(date);
            }, 0);
            */
        },

        getDate: function() {
            return parseInt(this.$date.val(), 10);
        },

        refresh: function() {
            var start,
                end;
            if (this.$year.length) {
                start = this.$year.data("start");
                if (start) {
                    start = parseInt(start, 10);
                    //start = Math.min(start, this.getYear());
                    this.options.start = start;
                }

                end = this.$year.data("end");
                if (end) {
                    end = parseInt(end, 10);
                    //end = Math.max(end, this.getYear());
                    this.options.end = end;
                }
            }

            if (!this.$year.length && !this.$month.data("year")) {
                this.$month.data("year", new Date().getFullYear());
            }

            this.refreshYear(this.getYear());
            this.refreshMonth(this.getMonth());
            this.refreshDate(this.getDate());
        },

        // data: yyyy/M/dd
        set: function(date) {
            var parts = date.split("/");

            this.setYear(parts[0]);
            this.setMonth(parts[1]);
            if (parts[2]) {
                this.setDate(parts[2]);
            }
        },

        isLeapYear: function() {
            var year = this.getYear();
            return year % 4 === 0 && (year % 100 !== 0 || year % 400 === 0);
        },

        get: function() {
            return this.getYear() + '/' + this.getMonth() + '/' + this.getDate();
        },

        date: function() {
            this.refreshDate(this.getDate());
        }
    };

    $.fn.dateSelector = function(option, date) {
        return this.each(function() {
            var $this = $(this),
                $target = $this.closest(".date-selector, [data-toggle=date-selector]"),
                data = $target.data("dateSelector"),
                options;

            if (!data) {
                if ($.isPlainObject(option)) {
                    options = option;
                }
                data = new DateSelector($target, options);
                $target.data("dateSelector", data);
            }

            if (typeof option === "string") {
                data[option](date);
            }
        });
    };

    $.fn.dateSelector.Constructor = DateSelector;

    $.fn.dateSelector.defaults = {
        delta: 6
    };

    //$(document).on("mouseenter.dateSelector.data-api", "select[data-toggle^=date-selector]", function (e) {
    $(document).delegate("select[data-toggle^=date-selector]",
            "mouseenter.dateSelector.data-api", function(e) {

                var $this = $(this),
            $target = $this.closest(".date-selector, [data-toggle=date-selector]");
                if (!$target.data("dateSelector")) {
                    $target.dateSelector();
                }
            });
} (this, this.jQuery));
/*[/static/bui/mtn/topic.js]*/
(function(global, $, document, undefined) {
    'use strict';

    var topics = $({}),
        slice = [].slice;

    function wrapper(fn) {
        return function() {
            fn.apply(this, slice.call(arguments, 1));
        };
    }

    $.subscribe = function(topic, callback) {
        topics.bind(topic, wrapper(callback));
        //topics.bind.apply(topics, arguments);
    };

    $.unsubscribe = function() {
        topics.unbind.apply(topics, arguments);
    };

    $.publish = function() {
        topics.trigger.apply(topics, arguments);
        //topics.trigger(arguments[0], slice.call(arguments, 1));
    };

    $.fn.subscribe = function(topic, callback) {
        this.bind(topic, wrapper(callback));
    };

    $.fn.unsubscribe = function() {
        this.unbind.apply(this, arguments);
    };

    $.fn.publish = function() {
        this.trigger.apply(this, arguments);
    };
} (this, jQuery, document));
/*[/static/bui/mtn/validate.js]*/
/**
* 基于表单元素的检查器
*/
(function(global, $, document, undefined) {
    'use strict';

    function Validate(element, options) {
        this.$element = $(element);
        this.options = $.extend({}, this.$element.data(), options);
        if (this.options.type) {
            this.options[this.options.type] = this.options.type;
        }
    }

    Validate.prototype = {
        constructor: Validate,

        checkValidity: function(skipAjax) {
            var options = this.options,
                defaults = $.fn.validate.defaults,
                that = this,
                value = that.$element.val(),
                type,
                i,
                len,
                xhr,
                data;

            for (i = 0, len = defaults.pattern.length; i < len; i += 1) {
                type = defaults.pattern[i];

                if (options.hasOwnProperty(type)) {
                    if (!defaults.regexp[type].test(value, options[type])) {

                        return options[type + 'Message'] ||
                            options.message ||
                            defaults.message[type];
                    }
                }
            }

            if (options.hasOwnProperty('pattern')) {
                if (typeof options.pattern === 'string') {
                    options.pattern = new RegExp(options.pattern);
                }

                if (!options.pattern.test(value)) {

                    return options[type + 'Message'] ||
                        options.message ||
                        defaults.message[type];
                }
            }

            // 当需要ajax验证时，需要根据validate和validated事件自己确定是否验证成功
            // 如果返回值不存在status属性，则需要覆盖.data('ajax-result')
            if (options.hasOwnProperty('ajax')) {
                if (skipAjax) {
                    return that.$element.data('ajax-result') || true;
                } else {
                    xhr = that.$element.data('xhr');
                    if (xhr) {
                        xhr.abort();
                    }

                    data = {};
                    data[that.$element.attr('name')] = that.$element.val();

                    that.$element.data('ajax-result', false);
                    that.$element.publish('validate.ajax');
                    xhr = $.getJSON(options.ajax, data).done(function(response) {
                        if (data.status === 'success') {
                            that.$element.data('ajax-result', true);
                        }
                        that.$element.publish('validated.ajax', response);
                    });
                    that.$element.data('xhr', xhr);
                    //return false;
                }
            }

            return true;
        }
    };

    $.fn.validate = function(option) {
        return this.each(function() {
            var $this = $(this),
                data,
                options;

            if (!$this.is('input[data-toggle=validate],textarea[data-toggle=validate]') ||
                    $this.data('toggle') !== 'validate') {
                return;
            }

            data = $this.data('validate');
            options = $.isPlainObject(option) && option;

            if (!data) {
                data = new Validate(this, options);
                $this.data('validate', data);
            }

            if (typeof option === 'string') {
                data[option]();
            }
        });
    };

    $.fn.validate.defaults = {
        pattern: ['required', 'phone', 'email', 'number', 'minSize', 'maxSize'],
        regexp: {
            required: /^[\s\S]+$/,
            phone: /^1\d{10}$/,
            email: /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/,
            number: /^-?\d+$/,
            minSize: {
                test: function(value, min) {
                    value = value || '';
                    if (min === undefined) {
                        min = Number.MIN_VALUE;
                    } else {
                        min = Number(min);
                    }

                    return value.length >= min;
                }
            },
            maxSize: {
                test: function(value, max) {
                    value = value || '';

                    if (max === undefined) {
                        max = Number.MAX_VALUE;
                    } else {
                        max = Number(max);
                    }

                    return value.length <= max;
                }
            }
        },

        message: {
            required: '必填',
            phone: '电话号码格式不对',
            email: '电子邮箱格式不对',
            number: '应填数字'
        }
    };

    $(document).delegate('input[data-toggle=validate],textarea[data-toggle=validate]',
            'focus', function() {

                var $this = $(this);

                if ($this.data('validate')) {
                    return;
                }

                $this.validate();
            });
} (this, jQuery, document));