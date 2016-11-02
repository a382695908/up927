var myApp=angular.module('myApp',[]);


myApp.controller('drinkCtrl',function($scope){
    $scope.dName='啤酒123';
    $scope.greeting=function(name){
        alert('Hello '+name);
    }
})

myApp.directive('drink',function(){
    return{
        restrict:'AE',
        scope:{
            myflavor:'@flavor'
        },
        template:'<div>{{myflavor}}</div>'
        /*link:function(scope,element,attr){
            scope.myflavor=attr.flavor;
        }*/
    }
})

myApp.directive('drink2',function(){
    return{
        restrict:'AE',
        scope:{
            myflavor2:'=flavor'
        },
        template:'<input type="text" ng-model="myflavor2"/>'
    }
})

myApp.directive('drink3',function(){
    return{
        restrict:'AE',
        scope:{
            greet:'&dgreet'
        },
        template:'<div><input type="text" ng-model="username"></input><button ng-click="greet({name:username})">确定</button></div>'
    }
})

myApp.directive('ddd',function(){
    return{
        restrict:'AE',
        //transclude:true,
        //replace:true,
        scope:{dName:'@ddd'},
        template:'<span>{{dName}}</span>'
    }
})


myApp.controller('myFormCtrl',function($scope){
    $scope.username='长途旅程';
    $scope.password='';
    $scope.login=function(){
        alert('登录成功！');
    }
})