(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['$scope']; 

    function HomeController($scope) {
        $scope.title = 'HomeController';
        $scope.userRoles = [{ id: 0, name: "Basic User" }, { id: 1, name: "Group Leader" }];
        $scope.userName = "";
        $scope.password = "";

        activate();

        function activate() {
            //alert("hey"); 
        }
        $scope.Login = function () {

        }
    }
})();
