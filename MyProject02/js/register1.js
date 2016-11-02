var regApp=angular.module('regApp',[]);
regApp.factory('regService',function ($http) {
	return {
		getUsernameExist:function(username) {
			return $http(
				{
					method:'GET',
					url:'/ajax/ajax_m.aspx?get=4&username='+escape(username)
					//url:'http://127.0.0.1:1337/'
				});
	},
	getEmailExist:function(email) {
			return $http(
				{
					method:'GET',
					url:'/ajax/ajax_m.aspx?get=5&email='+escape(email)
					//url:'http://127.0.0.1:1337/'
				});
	}
}
})


regApp.service('regSer',function($http){
	var me=this;
	//me.reg_date={};
	me.reg=function(email,username,pwd){
		$http.get('/ajax/ajax_m.aspx?get=3&username='+escape(username)+'&email='+escape(email)+'&pwd='+pwd)
		.then(function(){
			alert('注册成功');
		},
		function(){
			alert('注册失败');
		})
	}
})

regApp.controller('regCtrl',function ($scope,regService,regSer) {
	$scope.username='';
	$scope.pwd='';
	$scope.usertype='1';
	$scope.email='';
	$scope.mobile='';
	$scope.sex='0';//性别：0、未知/保密   1、男   2、女
	$scope.baby='';//宝宝状态：0、未知   1、已有宝宝   2、正在孕期   3、准备要宝宝
	$scope.baby_date='';//宝宝生日/预产期

	$scope.usernameV=true;

	$scope.User=regSer;
	/*$scope.getUsernameExist=function(){
		regService.getUsernameExist($scope.username)
		.success(function(data,status){
			alert(data);
			if(data.status=='200'){
				//未注册
				$("#div_content_alert").html("该用户名未被注册");
            	$('#myModal_alert').modal('show');
			}
			else{
				//已注册
				$("#div_content_alert").html("该用户名已被注册");
            	$('#myModal_alert').modal('show');
			}
			//alert('success');
		})
	}*/ 
})

regApp.directive('regbtnsubmit',function(){
	return{
		restrict:'AE',
		link:function(scope,element,attr){
			element.bind('click',function(){
				
				scope.getUsernameExist();
			});
		}
	}
})

//指令：验证邮箱
regApp.directive('validemail',function(regService){
	var o={
		restrice:'AE',
		scope:{
			emailText:'=validEmail'
		},
		require:'ngModel',
		link:function(scope,element,attr,ngModel){
			ngModel.$validators.validEmail=function(email){
				if(email !=''){
					return /^(\w)+(\.\w+)*@(\w)+((\.\w{2,3}){1,3})$/.test(email);//验证邮箱
				}
				else{
					return true;
				}
			};
			scope.$watch('emailText',function(){
				//ngModel.$validators();
			});

			//ngModel.$setValidity('valide', false);//默认为false
			element.bind('blur',function(){
				if(ngModel.$validators.validEmail){//alert(ngModel.$validators.validEmail());
					regService.getEmailExist(ngModel.$viewValue)
					.success(function(data){//alert(data.status);
						if(data.status=='200'){
							//未注册
							ngModel.$setValidity('valide', true);
							//return viewValue;
						}
						else{
							//已注册
							ngModel.$setValidity('valide', false);
							//return viewValue;
						}
					})
				}
			})

		}
	};

	return o;
})

//指令：验证用户名是否已注册
regApp.directive('validusername',function(regService){
	return{
		restrict:'AE',
		require:'ngModel',
		/*scope:{
			usernameText:'@validUsername'
		},*/
		link:function(scope,element,attr,ngModel){
			//ngModel.$setValidity('validn', false);//默认为false
			element.bind('blur',function(){
				if(ngModel.$viewValue.length>=4&&ngModel.$viewValue.length<=32)
				{
					regService.getUsernameExist(ngModel.$viewValue)
					.success(function(data){
						//alert(data.status);
						if(data.status=='200'){
							//未注册
							ngModel.$setValidity('validn', true);
							//return viewValue;
						}
						else{
							//已注册
							ngModel.$setValidity('validn', false);
							//return viewValue;
						}
						//alert('success');
					})
				}
			});
		}
	}
})

/*regApp.directive('validusername',function($scope,$http){
	var o={
		restrict:'AE',
		scope:{
			usernameText:'=validUsername'
		},
		require:'ngModel',
		link:function(scope,element,attr,con){
			con.$validators.validUsername=function(v){
				if(v.length>=4 && v.length<=32)
				{
					var isOk=true;
					$http(
					{
						method:'GET',
						url:'/ajax/ajax_m.aspx?get=4&username='+escape(v)
					}).success(function(data){
						if(data.status=='200'){
							//isOk= true;
							//return true;
							//$scope.usernameV=false;
							ngModelController.$setValidity('unique', false);
						}
						else{
							//isOk= false;
							//$scope.usernameV=true;
							ngModelController.$setValidity('unique', true);
						}
					}).error(function(){
						//isOk= false;
						ngModelController.$setValidity('unique', false);
					})

					
					//return isOk;
				}
				else{
					return true;
				}
			}

			scope.$watch('usernameText',function(){
				con.$validators();
			})
		}
	};
	return o;
})*/


