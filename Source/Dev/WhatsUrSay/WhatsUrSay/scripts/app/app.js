/*
Component :                             An AngularJS module definition that is used to define the angular js application used in the application and the different routes
                                        identified in the application.
Author:                                 Abhinav Bhandaram
Use of the component in system design:  Angular JS application definition and routes defined in the application.
Written and revised:                    11/5/2016
Reason for component existence:         Angular JS application definition..
*/
(function () {
    'use strict';
    //Defining the agularjs application 'app' and the required dependencies for the application.
    var app = angular.module('app', ['ngRoute', 'ngMaterial']);
    //Defining the routes identified in the application.
    app.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/login', {
            templateUrl: 'features/Login/Login.html',
            controller:'LoginController'
        }).when('/join', {
            templateUrl:'features/Login/Register.html'
        }).when('/error', {
            templateUrl:'features/Error/Error.html',
        }).when('/createPoll', {
            templateUrl: 'features/Poll/CreatePoll.html',
        }).when('/createGroup', {
            templateUrl: 'features/Group/CreateGroup.html',
        }).otherwise({
            templateUrl: 'features/Home/Home.html',
            controller:'HomeController'
        })

    }]);

})();