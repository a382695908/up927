var myApp=angular.module('myApp',[]);


//指令
myApp.directive('hello',function(){
	return {
		restrict:'E',
		template:'<div>你好！</div>',
		replace:true
	}
})

/*myApp.directive('mike',function(){
	return {
		restrict:'A',
		templateUrl: 'aaa.html',
		replace:true
	}
})*/

myApp.run(function($templateCache) {
    $templateCache.put('a1','<div>dfdfsdaasdf<div ng-transclude></div></div>');
})
myApp.directive('kk', function($templateCache) {
    return {
    restrict: 'A',
        transclude:true,
        template: $templateCache.get('a1'),
        replace: false
    }
})


myApp.controller('ctrl1', function($scope) {
    $scope.showMessage1 = function() {
        alert('数据1');
    };
})
myApp.controller('ctrl2', function($scope) {
    $scope.showMessage2 = function() {
        alert('数据2');
    }
})

myApp.directive('load', function() {
    return {
        restrict: 'AE',
        scope:{},
        template:'<loadA howtoLoad="showMessage1()"><div>{{name}}</div><input type="text" ng-model="name" /></loadA>',//
        replace:true
        /*link: function(scope, element, attr) {
            element.bind('mouseover', function() {
            //scope.showMessage1();
                scope.$apply(attr.howtoload);
            });
        }*/
    }
})


myApp.directive('superman', function() {
    return {
        restrict: 'AE',
        scope: {},
        controller: function($scope) {
            $scope.abilities = [];
            this.addStreng = function() {
                $scope.abilities.push('力量');
            };
            this.addSpeed = function() {
                $scope.abilities.push('敏捷');
            };
            this.addLight = function() {
                $scope.abilities.push('发光');
            };
        },
        link: function(scope, element, attr) {
            element.bind('mouseover', function() {
                alert(scope.abilities);
            });
        }
    }
})

myApp.directive('streng', function() {
    return {
        require: 'superman',
        link: function(scope, element, attr, superman) {
            superman.addStreng();
        }
    }
})

myApp.directive('speed', function() {
    return {
        require: 'superman',
        link: function(scope, element, attr, superman) {
            superman.addSpeed();
        }
    }
})

myApp.directive('light', function() {
    return {
        require: 'superman',
        link: function(scope, element, attr, superman) {
            superman.addLight();
        }
    }
})

myApp.controller('scopeCtrl',function($scope){
    $scope.myName='我爱编程';
})