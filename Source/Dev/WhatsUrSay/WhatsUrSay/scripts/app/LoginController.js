/*
Component :                             An AngularJS controller that invokes the methods defined in 'LoginController.cs' to serve the client login requests  and the Login Page.
Author:                                 Abhinav Bhandaram
Use of the component in system design:  Serves the Login requests of the clients 
Written and revised:                    11/5/2016
Reason for component existence:         To serve Login page and client side functions related to Login.html view.
*/
(function () {
    'use strict';
    //Reigstering the Controller with the Angular JS module defined for our application.
    angular
        .module('app')
        .controller('LoginController', LoginController);
    //Injecting the Angular JS Scope and required modules to be used for model binding between the view and the controller, making http requests etc.
    LoginController.$inject = ['$scope', '$http','$location','$mdDialog'];

    function LoginController($scope, $http,$location,$mdDialog) {
        $scope.title = 'Login';
        $scope.userRoles = [{ id: 0, name: "Basic User" }, { id: 1, name: "Group Leader" }, { id: 3, name: "Admin" }];
        $scope.userName = "";
        $scope.password = "";
        $scope.LoginStatus = false;
        activate();

        function activate() {

        }
        //Purpose: To proces the login requests of clients into our application.
        //Input: $event to prevent the default JS behaviour of the link button.
        //Output: An alert showing the login status of the user.
        $scope.Login = function ($event) {
            $event.preventDefault();
            var userInfo = { uName: $scope.userName, uPassword: $scope.password }
            $scope.LoginStatus = $http.post('api/Login/Login', userInfo).then(function success(response) {
                var alert_text = "";
                if (response.data) {
                    alert_text = "Login Successfull.";
                } else {
                    alert_text = "Please enter valid username and password.";
                }
                $mdDialog.show(                    
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Login')
                      .textContent(alert_text)
                      .ariaLabel('alert')
                      .ok('Ok')
                      
                  );

            }, function error(response) {
                $location.path('/Error');
            });

        }

    }
})();
