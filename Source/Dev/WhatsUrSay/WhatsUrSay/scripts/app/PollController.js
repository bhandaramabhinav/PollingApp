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
    PollController.$inject = ['$scope', '$http', '$location', '$mdDialog', '$localStorage','$sessionStorage', '$window'];

    function PollController($scope, $http, $location, $mdDialog, $localStorage, $sessionStorage, $window) {
        $scope.title = 'Poll';
        $scope.pollTitle = "";
        $scope.description = "";
        $scope.question = "";
        $scope.pollType = "";
        $scope.groupNames = "";

        $scope.userId = "1";
        $scope.$watch(function () { return $sessionStorage.userLoginInfo }, function (newVal, oldVal) {
            if (oldVal !== newVal) {
                $scope.userInfo = $sessionStorage.userLoginInfo;
                $scope.userId = $scope.userInfo;
            }
        })

        activate();

        function activate() {
            $scope.userId = $scope.userInfo.userId;
        }

        $scope.options = [{ description: "" }, { description: "" }];

        $scope.AddOption = function (option) {
            if (option == undefined) {
                $scope.options.push({});
            }
        }

        $scope.groups = [];

        $scope.AddGroup = function (group) {
            if (group == undefined) {
                $scope.groups.push({});
            }
        }

        $scope.RemoveOption = function (option) {
            $scope.options.pop();
        }

        $scope.RemoveGroup = function (group) {
            $scope.groups.pop();
        }

        //Purpose: To proces the create poll request of clients of our application.
        //Input: $event to prevent the default JS behaviour of the link button.
        //Output: An alert showing the 'create poll' status .

        //Hardcoded the following data entries: pollType, category, createdby
        $scope.CreatePoll = function ($event) {
            var alert_text = "";
            $event.preventDefault();
            for (var p in $scope.pollsFromDb) {
                if ($scope.pollsFromDb[p].heading == $scope.pollTitle) {
                    $mdDialog.show(
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Poll Name already exists. Please enter a new name')
                      .textContent(alert_text)
                      .ariaLabel('alert')
                      .ok('Ok')
                  );
                    return;
                }
            }
            if ($scope.pollType == "public") {
                $scope.pollType = 1;
            } else if ($scope.pollType == "private") {
                $scope.pollType = 2;
            }
            var activity = { heading: $scope.pollTitle, description: $scope.description, type: $scope.pollType, category: 1, createdby: $scope.userId, Questions: [{ description: $scope.question }], Answers: $scope.options, Groups: $scope.select };
            $scope.CreatePollStatus = $http.post('api/ActivityGroupDetails/PostPoll', activity).then(function success(response) {
                //alert(response);
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
                $location.path('/home');
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
        $scope.pollOptionCounts = [];

        $scope.ViewPoll = function () {
            $scope.ViewStatus = $http.get('api/ActivityDTO/GetPoll/' + $scope.pollId).then(function success(response) {
                //alert(response);
                $scope.data = response.data;
                $scope.pollTitle = response.data[0].heading;
                $scope.pollDescription = response.data[0].description;
                $scope.pollQuestionId = response.data[0].questionId;
                $scope.pollQuestion = response.data[0].question;
                $scope.pollOptions = response.data[0].options;
            }, function error(response) {
                alert(response);
                $location.path('/error');
            });
        };

        $scope.result = "";

        $scope.ParticipatePoll = function (result) {
            //alert("In participatePoll function");
            var pollAnswerDetails = { userId: $scope.userId, activityId: $scope.pollId, questionId: $scope.pollQuestionId, answerDesc: $scope.result };

            $scope.ParticipatePollStatus = $http.post('api/PollAnswerDetails/PostPollAnswer', pollAnswerDetails).then(function success(response) {
                
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
        
        $scope.PollResults = function () {
            $scope.ViewPoll();
            $http.get('api/UserAnswer/GetUsersParticipated?activityId=' + $scope.pollId).then(function success(response) {
                $scope.usersParticipated = response.data;
            }, function error(response) {
                alert(response);
                $location.path('/error');
            });
            $scope.answers = [];
            $scope.counts = [];
            $http.get('api/Answer/GetAnswersForCount/' + $scope.pollId).then(function success(response) {
                $scope.ansLength = response.data.length;
                for(var i=0;i<response.data.length;i++){
                    $scope.answers.push(response.data[i].description);
                    $scope.counts.push(response.data[i].count);
                }
                $scope.answersResult = response.data;
            }, function error(response) {
                alert(response);
                $location.path('/error');
            });
        }

        $scope.LoadDataNecessary = function () {
            $http.get('api/Groups/GetGroups')
            .then(function success(response) {
                $scope.groupDetails = response.data;
            }
            , function error(response) {
                $location.path('/error');
            });

            $http.get('api/Poll/GetAllPolls')
            .then(function success(response) {
                $scope.pollsFromDb = response.data;
            }
            , function error(response) {
                $location.path('/error');
            });
        }
    }
}());

