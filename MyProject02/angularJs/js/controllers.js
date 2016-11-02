var myCtrls=angular.module('myCtrls',[]);

myCtrls.controller('helloCtrl',function($scope){
	$scope.helloName='World';
});

myCtrls.controller('myListCtrl',function($scope,$routeParams){
	$scope.userList=[
		{name:'风格风格',age:19},
		{name:'dfdf巅峰',age:20},
		{name:'风格风对方答复格',age:90}
	];
	$scope.params=$routeParams;
	$scope.helloName='呵呵！';
})