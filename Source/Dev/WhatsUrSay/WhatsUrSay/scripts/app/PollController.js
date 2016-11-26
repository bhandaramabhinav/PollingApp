﻿/*
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

        $scope.userId = "1";

        activate();

        function activate() {

        }

        $scope.options = [];

        $scope.AddOption = function (option) {
            if (option == undefined)
            {
                $scope.options.push({});
            }
        }

        $scope.groups = [];

        $scope.AddGroup = function (group) {
            if (group == undefined) {
                $scope.groups.push({});
            } 
        }


        //Purpose: To proces the create poll request of clients of our application.
        //Input: $event to prevent the default JS behaviour of the link button.
        //Output: An alert showing the 'create poll' status .

        //Hardcoded the following data entries: pollType, category, createdby
        $scope.CreatePoll = function ($event) {
            $event.preventDefault();
            if ($scope.pollType == "public") {
                $scope.pollType = 1;
            } else if ($scope.pollType == "private") {
                $scope.pollType = 2;
            }
            var activity = { heading: $scope.pollTitle, description: $scope.description, type: $scope.pollType, category: 1, createdby: 1, Questions: [{ description: $scope.question }], Answers : $scope.options, Groups:$scope.groups};
            $scope.CreatePollStatus = $http.post('api/ActivityGroupDetails/PostPoll', activity).then(function success(response) {
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

        $scope.pollId = '10';
            
        $scope.pollTitle = "";
        $scope.pollDescription = "";
        $scope.pollQuestionId = "";
        $scope.pollQuestion = "";
        $scope.pollOptions = [];
       
        $scope.ViewPoll = function ($event) {
            $event.preventDefault();
            alert("View Poll");
            
            $scope.ViewStatus = $http.get('api/ActivityDTO/GetPoll/' + $scope.pollId).then(function success(response) {
                //alert(response);
                $scope.data = response.data;
                $scope.pollTitle = response.data[0].heading;
                $scope.pollDescription = response.data[0].description;
                $scope.pollQuestionId = response.data[0].questionId;
                $scope.pollQuestion = response.data[0].question;
                $scope.pollOptions = response.data[0].options;

               // window.location.href = '#/participatePoll';

                /*alert("<<<")
                alert(response.data.options);
                alert(">>>")
                //$scope.pollOptions = [0, 1, 2, 3];

                $scope.pollOptions = response.data[0].options;

                //alert($scope.pollDescription);
                //window.location.href = '#/participatePoll';
                //$window.location.href = '/participatePoll';
                //window.location = "#/ParticipateInPoll.html";
                //window.location = "#/participatePoll";
               // $location.path('/participatePoll');
                //window.location.href = '#/participatePoll';
               // $location.url('/participatePoll');
                // $scope.option1 = response.data[0].options[0];
                /*var alert_text = "";
                if (response.data) {
                    alert_text = "Participate in Poll";
                } else {
                    alert_text = "Poll participation failed";
                }
                $mdDialog.show(
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Poll participation')
                      .textContent(alert_text)
                      .ariaLabel('alert')
                      .ok('Ok')
                  );*/
            }, function error(response) {
                alert(response);
                $location.path('/error');
            });         
        };
        
        $scope.result = "";

        $scope.ParticipatePoll = function (result) {
            alert("In participatePoll function");
            alert($scope.pollId);
            alert($scope.result);
            var pollAnswerDetails = { userId: $scope.userId, activityId: $scope.pollId, questionId: $scope.pollQuestionId, answerDesc: $scope.result };

            $scope.ParticipatePollStatus = $http.post('api/PollAnswerDetails/PostPollAnswer', pollAnswerDetails).then(function success(response) {
                alert(response);
                var alert_text = "";
                if (response.data) {
                    alert_text = "Poll Answer is posted Successfully";
                } else {
                    alert_text = "Poll Answer post failed";
                }
                $mdDialog.show(
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Poll Answer')
                      .textContent(alert_text)
                      .ariaLabel('alert')
                      .ok('Ok')
                  );
            }, function error(response) {
                alert(response);
                $location.path('/error');
            });
        }
      /*  $scope.ParticipatePoll = function ($scope) {
            //var activity = { heading: $scope.pollTitle, description: $scope.description, type: $scope.pollType, category: 1, createdby: 1, Questions: [{ description: $scope.question }], Answers: $scope.options, Groups: $scope.groups };
            $scope.LoginStatus = $http.get('api/Poll/GetPoll/10').then(function success(response) {
                //alert(response);
                $scope.data = response.data;
                $scope.pollTitle = response.data[0].heading;
                $scope.pollDescription = response.data[0].description;
                $scope.pollQuestion = response.data[0].question;
                /*alert("<<<")
                alert(response.data.options);
                alert(">>>")
                //$scope.pollOptions = [0, 1, 2, 3];

                $scope.pollOptions = response.data[0].options;
                // $scope.option1 = response.data[0].options[0];
                var alert_text = "";
                if (response.data) {
                    alert_text = "Participate in Poll";
                } else {
                    alert_text = "Poll participation failed";
                }
                $mdDialog.show(
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Poll participation')
                      .textContent(alert_text)
                      .ariaLabel('alert')
                      .ok('Ok')
                  );
            }, function error(response) {
                alert(response);
                $location.path('/error');
            });
        };*/
    }
})();
