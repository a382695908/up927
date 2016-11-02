var myApp=angular.module('myApp',['ngRoute','myCtrls']);

myApp.config(function($routeProvider){
	$routeProvider.when('/hello1',{
		templateUrl:'/angularJs/temp/hello.html',
		//template:'<div>aaa</div>',
		controller:'helloCtrl'
	}).when('/list/:name/:id/:desc',{
		templateUrl:'/angularJs/temp/list.html',
		controller:'myListCtrl'
	}).otherwise({
		redirectTo:'/hello1'
	})
});