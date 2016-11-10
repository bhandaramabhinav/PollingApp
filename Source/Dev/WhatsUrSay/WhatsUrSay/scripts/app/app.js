(function () {
    'use strict';    
    var app = angular.module('app', ['ngRoute', 'ngMaterial']);
    app.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/login', {
            templateUrl: 'features/Login/Login.html',
        }).when('/join', {
            templateUrl:'features/Login/Register.html'
        })
        .otherwise({
            templateUrl:'features/Home/Home.html'
        })

    }]);

})();