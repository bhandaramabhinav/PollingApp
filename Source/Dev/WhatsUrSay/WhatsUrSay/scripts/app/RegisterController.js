(function () {
    'use strict';

    angular
        .module('app')
        .controller('LoginController', LoginController);
    LoginController.$inject = ['$scope', '$http', '$location', '$mdDialog'];

    function LoginController($scope, $http, $location, $mdDialog) {
        $scope.title = 'Register';
        $scope.userRoles = [{ id: "U", name: "Basic User" }, { id: "GL", name: "Group Leader" }, { id: "A", name: "Admin" }];
        $scope.user = {

        };
        activate();

        function activate() {

        }
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
