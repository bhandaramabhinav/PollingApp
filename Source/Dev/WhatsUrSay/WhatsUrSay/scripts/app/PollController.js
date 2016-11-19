/*
Component :                             An AngularJS controller that invokes the methods defined in 'PollController.cs' to serve the client's requests in creating and getting the poll details.
Author:                                 Sreedevi Koppula
Use of the component in system design:  Serves the 'create' and 'get' poll requests of the clients 
Written and revised:                    11/17/2016
Reason for component existence:         Used for creating a poll and getting the details of required poll
*/
(function () {
    'use strict';
    //Reigstering the Controller with the Angular JS module defined for our application.
    angular
        .module('app')
        .controller('PollController', PollController);
    //Injecting the Angular JS Scope and required modules to be used for model binding between the view and the controller, making http requests etc.
    PollController.$inject = ['$scope', '$http', '$location', '$mdDialog'];

    function PollController($scope, $http, $location, $mdDialog) {
        $scope.title = 'Poll';
        $scope.pollTitle = "";
        $scope.description = "";
        $scope.question = "";
        $scope.pollType = "";
        $scope.groupNames = "";
        
        activate();

        function activate() {

        }

        $scope.options = [];

        $scope.AddOption = function (option) {
            if (option == undefined)
            {
                $scope.options.push({});
            } else {
                var opt = { description: option.description };
                $scope.options.push(opt);
            } 
        }

        //Purpose: To proces the create poll request of clients of our application.
        //Input: $event to prevent the default JS behaviour of the link button.
        //Output: An alert showing the 'create poll' status .
        $scope.CreatePoll = function ($event) {
            $event.preventDefault();
            var activity = { heading: $scope.pollTitle, description: $scope.description, type: $scope.pollType, category: 'poll', group_ids: $scope.groupNames, createdby: 1, Questions: [{ description: $scope.question }], Answers : $scope.options};
            $scope.LoginStatus = $http.post('api/Poll/PostPoll', activity).then(function success(response) {
                alert(response);
                var alert_text = "";
                if (response.data) {
                    alert_text = "Poll is created Successfully";
                } else {
                    alert_text = "Poll creation failed";
                }
                $mdDialog.show(
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Poll Creation')
                      .textContent(alert_text)
                      .ariaLabel('alert')
                      .ok('Ok')
                  );
            }, function error(response) {
                alert(response);
                $location.path('/error');
            });
        };
    }
})();
