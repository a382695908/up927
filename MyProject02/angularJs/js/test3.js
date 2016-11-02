var myApp=angular.module('myApp',[]);

myApp.factory('getInfoService',function($http){
    return{
        getUserList:function(searchName){
            return $http({
                method:'GET',
                url:'/xzdd927/ajax/ajax_m.aspx?g=1&checkcode=&name=&pwd='
            });
        }
    }
})

myApp.controller('myCtrl',function($scope,$http,getInfoService){
    $scope.user={
        name:'老王',
        age:89
    };
    $scope.search=function(){
        getInfoService.getUserList($scope.user.name)
        .success(function(data,status){
            $scope.list=data;
        })
        /*$http({
                method:'GET',
                url:'js/json03.js'
            }).success(function(data,header,config,status){
                //$scope.list=data;
                alert(data);
            });*/
        /*$http.get("/xzdd927/ajax/ajax_m.aspx?g=1&checkcode=&name=&pwd=")
        .success(function(data) {
            $scope.list=data;
        });*/
    };
})

myApp.directive('mysearch',function(){
    return{
        restrict:'AE',
        //template:'<div>查询了</div>',
        //replace:true
        link:function(scope,element,attr){
            element.bind('click',function(){
                scope.search();
            });
        }
    }
})

