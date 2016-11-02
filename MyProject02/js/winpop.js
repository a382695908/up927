
//winpop
(function(w) {
    function Winpop() {
        this.core_version = '0.1.1';
        this.get = function(name) {
            return this.config[name];
        }
        this.set = function(name, value) {
            if (value != null)
                this.config[name] = value;
        }
    }

    Winpop.prototype = {
        init: function(config) {
            this.config = {
                type: 1, //弹出层类别：1、div（默认） 2、iframe
                closeBtn: true, //关闭按钮：默认为有
                closeBtnType: 1, //关闭按钮样式：默认为1
                shade: true, //遮罩蒙层：默认为有
                shadeClose: true //点击遮罩或空白处关闭：默认为有
            };

            this.set('type', config.type);
            this.set('closeBtn', config.closeBtn);
            this.set('closeBtnType', config.closeBtnType);
            this.set('shade', config.shade);
            this.set('shadeClose', config.shadeClose);

            switch(config.type){
                case 1://显示div弹出层
                    this.set('floatObjId', config.content);
                    _showDiv(this);
                    break;
                case 2: //显示iframe弹出层
                    this.set('url', config.content);
                    this.set('width', config.width);
                    this.set('height', config.height);
                    _showIframe(this);
                    break;
            }
        },
        close: function() {//关闭弹出层
            removeHandler(document,'click',_close);//移除点击空白关闭弹出层事件

            var floatType = this.get('type');
            if (floatType == 1) {
                var floatObj = document.getElementById(this.get('floatObjId'));
                var closeBtn = document.getElementById('winpop_closeBtn');
                if (closeBtn) {
                    floatObj.removeChild(closeBtn); //清除关闭按钮
                }
                floatObj.style.display = 'none';
            }
            else if (floatType == 2) {
                var iframeFloat = document.getElementById('winpop_iframeFloat');
                var closeBtn = document.getElementById('winpop_closeBtn');
                if (closeBtn) {
                    iframeFloat.removeChild(closeBtn); //清除关闭按钮
                }
                if (iframeFloat) {
                    document.body.removeChild(document.getElementById('winpop_iframeFloat')); //隐藏iframe弹出层
                }
            }

            var pop_mask = document.getElementById('winpop_pop_mask');
            if (pop_mask) {
                document.body.removeChild(document.getElementById('winpop_pop_mask'));
            }
        }
    }

    //添加关闭按钮
    var _getCloseBtn = function(that) {
        var _this = that;
        var closeBtn = document.createElement('div');
        closeBtn.setAttribute('id', 'winpop_closeBtn');
        var closeBtnType = _this.get('closeBtnType');
        switch (closeBtnType) { //关闭按钮样式
            case 1:
                closeBtn.style.backgroundImage = 'url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABwAAAAcCAYAAAByDd+UAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAJwSURBVEhLvZbLSiNBFIb7DVyKiIgb17oQRRAXgor6CIIIeQKXMksfxYUbFbMZRh0Yb6ODMgEddCVmoWkRLzFekukxfay/+lRbqSqTVob+4CyqzuVPV59TaS8JYRhmhM0Ly5MB9tiX4fDPIQq0CpsT9sC1G4JYzmnlMskQCRPCrrnOh0EuanC5+ojAL5wXc5/LUW5qitba2ynreTWGPfgQY4JaXNaNKfZ0dkY7g4OWyHuGWOTovCuKI+AYib+8TF+bmpyF6xlykKuD2iwTITbQIPE7Q4Kr2EdMF0VtaLCcFJxjnzySzzyZaaihHy80WE4Kxq3vemcns7PStzsyYvn+zMxQUCzSRne35UMtBTSUWIb3ZKeZSRCrBoH0lwsF2u7vj32/JyepWi5L3/3hIW319dXkwvTuhRYE53kt29tMMAlub2lvdJRy09MUVqu8G3GxsGDlo6YCWhCMryvXnO0OD1PF9zkiQj5VGPIqonhwQOsdHVY+aiqgVfMIZrCy7YEBCm5uOMqmdHTkFFOmk0gQ9nNoiF4eHznyjed8nr41NztzlOkkFsQ7cwmWz89ps6fHmaNMJ5Gg7MZKhaNs/pVK8thduTCdhk2DOVNjoXg6PaW/V1e8ikBj7Y2NWflW06BVee0cC/x6nYfjY/nOfnR1yRHRucxmrXzXWNQdfNwgGGpwt79Pa21tsQ+XAC4D4K+s0GpLS00uzBp8vm3qXm1bvb1UWFyk752dlu/X+Dj5S0vOTnVebUAsUr+80/17AmIjvT9ghXCk94mhMEUBOg3t7ZpT7MGnd6OioZgCRyAsnc9EhUhI70PYRBT4T5/6nvcKYG1hElXAZggAAAAASUVORK5CYII=)';
                break;
            case 2:
                closeBtn.style.backgroundImage = 'url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABwAAAAcCAYAAAByDd+UAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAJeSURBVEhLvZbPq2lRFMf9B4bSTTIxZiBSMlCI9ycoKX+Bod7w/il3YIL4NyhFmYmBKD2Sp0ix3vqes/e529n74t33Op9astevr3PO2tvxvcLtdquzfbAtyAV8IlYX6d+DG7yxvbP9Fr2fglxR8ybavAYX/GD7Jfr8NahFD9HuMZz4U9Q5jEYjqlarFA6HiVPuDD7EkOMGvTjna9xi8/mcstmsJvKVIRc1Kl+K4haIHItut0t+v9/Y+JGhBrUq6M2xT9iBAXGeGQrY/U+miqI3NNhvw4t3EbNuyXeuzG3ood5eaLDfhhfO6JueWbPZtGKFQkGLNRoN2u/3FI/HtRh6SaDBPkusLnzWpMlkaRC7XC5WfLVaUTqddmKVSoVOp5MVG4/HlEql7mph6vRCC4IfYm2Nt7vAzW63o2KxSLVaja7Xq/DatFotrR49JdCCoHNcmfZZPp+n9XotMmxwVVwnVjbD4ZAikYhWj54SaN1dgjtZWiaToe12K7J0JpOJUUyaykuCsFwuR8fjUWR+slgsKBAIGGukqbwsiGdmElwul5RIJIw10lReEsQ0ns9nkaVzOBys226qhak8HRrsM7ktJLPZjDabjVjZYLBKpZJWrw0NfzzcFvj1KtPp1HpmsVjM2iIq/X5fqzdti4cbHycINjUYDAYUCoWcGA4BHAag1+tRMBi8q4VpGx/wl4dHWzKZpHa7TdFoVIuVy2XqdDrGSTUebYAXnh/e3v49AXZ49wcs4YB3rxgStyjApGG8TfsUPsTUaZQ8FZPgFrB585oo4QLvXoTdcIP/9Krv8/0BDUSOirKWU6wAAAAASUVORK5CYII=)';
                break;
            default:
                closeBtn.style.backgroundImage = 'url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABwAAAAcCAYAAAByDd+UAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAJwSURBVEhLvZbLSiNBFIb7DVyKiIgb17oQRRAXgor6CIIIeQKXMksfxYUbFbMZRh0Yb6ODMgEddCVmoWkRLzFekukxfay/+lRbqSqTVob+4CyqzuVPV59TaS8JYRhmhM0Ly5MB9tiX4fDPIQq0CpsT9sC1G4JYzmnlMskQCRPCrrnOh0EuanC5+ojAL5wXc5/LUW5qitba2ynreTWGPfgQY4JaXNaNKfZ0dkY7g4OWyHuGWOTovCuKI+AYib+8TF+bmpyF6xlykKuD2iwTITbQIPE7Q4Kr2EdMF0VtaLCcFJxjnzySzzyZaaihHy80WE4Kxq3vemcns7PStzsyYvn+zMxQUCzSRne35UMtBTSUWIb3ZKeZSRCrBoH0lwsF2u7vj32/JyepWi5L3/3hIW319dXkwvTuhRYE53kt29tMMAlub2lvdJRy09MUVqu8G3GxsGDlo6YCWhCMryvXnO0OD1PF9zkiQj5VGPIqonhwQOsdHVY+aiqgVfMIZrCy7YEBCm5uOMqmdHTkFFOmk0gQ9nNoiF4eHznyjed8nr41NztzlOkkFsQ7cwmWz89ps6fHmaNMJ5Gg7MZKhaNs/pVK8thduTCdhk2DOVNjoXg6PaW/V1e8ikBj7Y2NWflW06BVee0cC/x6nYfjY/nOfnR1yRHRucxmrXzXWNQdfNwgGGpwt79Pa21tsQ+XAC4D4K+s0GpLS00uzBp8vm3qXm1bvb1UWFyk752dlu/X+Dj5S0vOTnVebUAsUr+80/17AmIjvT9ghXCk94mhMEUBOg3t7ZpT7MGnd6OioZgCRyAsnc9EhUhI70PYRBT4T5/6nvcKYG1hElXAZggAAAAASUVORK5CYII=)';
                break;
        }

        closeBtn.style.position = "absolute";
        closeBtn.style.right = '-5px';
        closeBtn.style.top = '-12px';
        closeBtn.style.width = '28px';
        closeBtn.style.height = '28px';
        closeBtn.style.cursor = 'pointer';
        closeBtn.style.display = 'block';

        //绑定关闭事件
        closeBtn.onclick = function() {
            _this.close();
        }
        return closeBtn;
    }

    //设置蒙层
    var _setPopMask = function() {
        var maskWidth = document.body.scrollWidth;
        var maskHeight = document.body.scrollHeight;
        var layStr = '<div id="winpop_pop_mask"  style="position: absolute;top:0;left:0;background: #ccc;width:'+maskWidth+'px;height: '+maskHeight+'px;opacity:0.3;z-index:99;"></div>';
        document.body.insertAdjacentHTML("beforeEnd", layStr);
    }

    //显示div弹出层
    var _showDiv = function(that) {
        var _this = that;

        var floatObjId = _this.get('floatObjId');
        var floatObj = document.getElementById(floatObjId); //获取弹出层
        floatObj.style.display = 'block'; //先将弹出层设置display:block，否则取不到高度、宽度
        floatObj.style.position = "fixed";
        floatObj.style.zIndex = 100;
        floatObj.style.left = '50%';
        floatObj.style.top = '50%';
        floatObj.style.marginTop = '-' + floatObj.offsetHeight / 2 + 'px';
        floatObj.style.marginLeft = '-' + floatObj.offsetWidth / 2 + 'px';

        //添加关闭按钮
        if (_this.get('closeBtn')) {
            var closeBtn = _getCloseBtn(_this);
            floatObj.appendChild(closeBtn);
        }

        //设置蒙层
        if (_this.get('shade')) {
            _setPopMask();
        }

        //点击遮罩关闭弹出层
        if (_this.get('shadeClose')) {
            addHandler(document, 'click', _close);
        }

        event = event ? event : window.event;
        //阻止冒泡
        stopPropagation(event);

        //弹出层阻止冒泡
        addHandler(floatObj, 'click', function(e) {
            if (e.stopPropation) {
                e.stopPropation();
            }
            else {
                e.cancelBubble = true;
            }
        });
    }

    //显示iframe弹出层
    var _showIframe = function(that) {
        var _this = that;
        var url = _this.get('url');
        var width = _this.get('width');
        var height = _this.get('height');

        var winWidth = document.documentElement.clientWidth || document.body.clientWidth;
        var winHeight = document.documentElement.clientHeight || document.boda.clientHeight;

        var iframeStr = '<div id="winpop_iframeFloat" style="top:0px;left:0px;z-index:100;position:fixed;"><iframe src="' + url + '" scrolling="no" marginheight="0" marginwidth="0" frameborder="0" allowTransparency="true" style="width:' + width + 'px; height: ' + height + 'px;"/></div>';
        document.body.insertAdjacentHTML("beforeEnd", iframeStr);

        var iframeFloat = document.getElementById('winpop_iframeFloat');
        iframeFloat.style.display = 'block';

        iframeFloat.style.position = "fixed";
        iframeFloat.style.zIndex = 100;
        iframeFloat.style.left = '50%';
        iframeFloat.style.top = '50%';
        iframeFloat.style.marginTop = '-' + height / 2 + 'px';
        iframeFloat.style.marginLeft = '-' + width / 2 + 'px';

        //添加关闭按钮
        if (_this.get('closeBtn')) {
            var closeBtn = _getCloseBtn(_this);
            iframeFloat.appendChild(closeBtn);
        }

        //设置蒙层
        if (_this.get('shade')) {
            _setPopMask();
        }

        //点击遮罩关闭弹出层
        if (_this.get('shadeClose')) {
            addHandler(document, 'click', _close);
        }

        event = event ? event : window.event;
        //阻止冒泡
        stopPropagation(event);

        //弹出层阻止冒泡
        addHandler(iframeFloat, 'click', function(e) {
            if (e.stopPropation) {
                e.stopPropation();
            }
            else {
                e.cancelBubble = true;
            }
        });
    }

    //调用关闭弹出层方法
    var _close=function (){
        winpop.close();
    }

    //绑定事件
    function addHandler(element,type,handler) {
        if(element.addEventListener){
            element.addEventListener(type,handler,false);
        }
        else if(element.attachEvent){
            element.attachEvent('on'+type,handler);
        }
        else{
            element['on'+_type]=handler;
        }
    }

    //移除事件
    function removeHandler(element,type,handler) {
        if(element.removeEventListener){
            element.removeEventListener(type,handler,false);
        }
        else if(element.detachEvent){
            element.detachEvent('on'+type,handler);
        }
        else{
            element['on'+type]=null;
        }
    }

    //阻止冒泡
    function stopPropagation(event) {
        if(event.stopPropagation){
            event.stopPropagation();
        }
        else{
            event.cancelBubble=true;
        }
    }

    window.winpop = new Winpop();
})(window)

