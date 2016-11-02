<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test02.aspx.cs" Inherits="MyProject02.test.test02" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>Lambda</title>

</head>
<body>
<form id="form1" runat="server">

<script src="http://apps.bdimg.com/libs/angular.js/1.4.6/angular.min.js"></script>


<div ng-app="myApp" ng-controller="myCtrl"> 

<p>欢迎信息{{aaname}}:</p>

<h1>{{myWelcome||"aaa"}}</h1>
<br/>
<h1>{{thisTime}}</h1>
<br/>
<h1>{{num}}</h1>
<br/>
<ul>
    <li ng-repeat="j in myJson">
        名字是：{{j.name}}   年龄是：{{j.age}}
    </li>
</ul>
</div>

<p> $http 服务向服务器请求信息，返回的值放入变量 "myWelcome" 中。</p>

<script>
    var app = angular.module("myApp", []);
    app.service("myService", function() {
        this.getAdd = function(x) {
            return x + 1;
        }
    });
    app.controller('myCtrl', function($http, $scope, $timeout, $interval, myService) {
        $scope.aaname = "aa";

        $http.get("/ajax/ajax_m.aspx?get=1").then(function(response) {
            $scope.myWelcome = response.data;
        })

        $http.get("/ajax/ajax_m.aspx?get=2")
    .success(function(response) { $scope.myJson = response.man; });

        $timeout(function() {
            $scope.myWelcome = "你好";
        }, 2000)
        $interval(function() {
            $scope.thisTime = new Date().toLocaleTimeString();
        }, 1000)
        $scope.num = myService.getAdd(6);
    })
</script>

--------------------------------------------------------------------------------------------------------------

<div id="div_app2" ng-app="myApp2" >
    <input type="text" ng-model="txtSearch"/>

    <ul ng-controller="PhoneListCtrl">
        <li ng-repeat="p in phone|filter:txtSearch">
            名字：{{p.name}} 编号：{{p.num}}
        </li>
    </ul>
    
    <ul ng-controller="StudentListCtrl">
        <li ng-repeat="s in student">
            {{s.name}}{{s.age}}
        </li>
    </ul>
    
</div>
<script>
    var app2 = angular.module("myApp2", []);

//    function PhoneListCtrl($scope) {
//        $scope.phone = [{"name":"aaa","num":"111"}, {"name":"bbb","num":"222"}, {"name":"ccc","num":"333"}]
//    }

    app2.controller('PhoneListCtrl', function($scope) {
        $scope.phone = [{ "name": "aaa", "num": "111" }, { "name": "bbb", "num": "222" }, { "name": "ccc", "num": "333"}]
    })

    app2.controller("StudentListCtrl", function($scope) {
        $scope.student = [{ "name": "ddd", "age": "15" }, { "name": "eee", "age": "16" }, { "name": "fff", "age": "17"}];
    })

    //启动第二个ng-app，必须放在最后
    angular.bootstrap(document.getElementById("div_app2"), ['myApp2']);
    
</script>

<script>
//    for (var i = 0; i < 3; i++) {
//        setTimeout(function() {
//            alert(i);
//        }, 0);
//        alert(i);
//    }
</script>

<script>

    function People(name) {
        this.name = name;
        //对象方法
        this.Introduce = function() {
            alert("My name is " + this.name);
        }
    }
    //类方法
    People.Run = function() {
        alert("I can run");
    }
    //原型方法
    People.prototype.IntroduceChinese = function() {
        alert("我的名字是" + this.name);
    }



    //测试

    var p1 = new People("Windking");
    People.age = 19;
    //alert(p1.age);

    var cup = "123abc";
    //alert(typeof(cup));
//    p1.Introduce();

//    People.Run();

//    //p1.IntroduceChinese();
//    People.Introduce();
</script>



</form>
</body>
</html>
