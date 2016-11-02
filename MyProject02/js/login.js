
(
	function () {
		var loginApp=angular.module('loginApp',[]);

		loginApp.service('loginService',
			function ($http) {
				var me=this;
				me.login_data={};

				//将参数传递的方式改成form
				var postCfg = {
				    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
				    transformRequest: function (data) {
				        return $.param(data);
				    }
				};
				me.login=function () {
					$http.post('/ajax/ajax_m.aspx?get=6',me.login_data,postCfg)
					.then(function (r) {
						if(r.data.result==1){
							//alert('登录成功');
							//me.validLogin=1;
							parent.location.reload(); //刷新本页
						}
						else if(r.data.result==2){
							me.validLogin=2;//用户名或密码错误
						}
						else if(r.data.result==3){
							me.validLogin=3;//该用户已被锁定
						}
						else if(r.data.result==4){
							me.validLogin=4;//该用户不存在
						}

					},function (e) {
						console.log(e);
					})
				}
		})

		loginApp.controller('loginCtrl',
			function ($scope,loginService) {
				$scope.User=loginService;
		})
	}
)()
