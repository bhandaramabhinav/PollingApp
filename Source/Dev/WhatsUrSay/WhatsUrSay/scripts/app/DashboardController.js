/*
Component :                             An AngularJS controller that invokes the methods defined in 'DashboardController.cs' to serve the client login requests  and the Login Page.
Author:                                 Abhinav Bhandaram
Use of the component in system design:  Serves the dashboard requests for the clients
Written and revised:                    11/5/2016
Reason for component existence:         To serve Dashboard page and client side functions related to Dashboard.html view.
*/
(function () {
    'use strict';
    //Reigstering the Controller with the Angular JS module defined for our application.
    angular
        .module('app')
        .controller('DashboardController', DashboardController);
    //Injecting the Angular JS Scope and required modules to be used for model binding between the view and the controller, making http requests etc.
    DashboardController.$inject = ['$scope', '$http', '$location', '$mdDialog', '$localStorage', '$sessionStorage', '$window'];

    function DashboardController($scope, $http, $location, $mdDialog, $localStorage, $sessionStorage, $window,$filter) {
        $scope.title = 'Dashboard';
        activate();
        function activate() {
            if ($sessionStorage.userLoginInfo) {
                $scope.userInfo = $sessionStorage.userLoginInfo;
                var userInfo={userId:$scope.userInfo.userId,role:$scope.role};
                $scope.LoginStatus = $http.post('api/Dashboard/GetDashboard', userInfo).then(function success(response) {
                    $scope.dashBoardDetails = response.data;
                    $scope.publicPolls = $scope.dashBoardDetails.publicActivities.filter((item) =>item.category == 1);
                    $scope.publicSurveys = $scope.dashBoardDetails.publicActivities.filter((item) =>item.category == 2);
                    $scope.createdPolls = $scope.dashBoardDetails.createdActitvities;
                    $scope.privatePolls = $scope.dashBoardDetails.privateActivities.filter((item) =>item.category == 2);

                }, function error(response) {
                    $location.path('/error');
                });

            
            }
            else {
                $location.path('/login');
            }

        }
        $scope.$watch(function () { return $sessionStorage.userLoginInfo }, function (newVal, oldVal) {
            if (oldVal !== newVal) {
                $scope.userInfo = $sessionStorage.userLoginInfo;
            }
        })
        //Purpose: To proces the login requests of clients into our application.
        //Input: $event to prevent the default JS behaviour of the link button.
        //Output: An alert showing the login status of the user.


    }
})();
