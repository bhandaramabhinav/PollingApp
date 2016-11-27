/*
Component :                             An AngularJS controller that invokes the methods defined in 'SurveyController.cs' to serve the client's requests in creating and getting the survey details.
Author:                                 Rajashekar Goud Korakoppula
Use of the component in system design:  Serves the 'create' and 'get' Survey requests of the clients 
Written and revised:                    11/22/2016
Reason for component existence:         Used for creating a survey and getting the details of required survey
*/

(function () {
    'use strict';
    //Reigstering the Controller with the Angular JS module defined for our application.
    angular
        .module('app')
        .controller('ParticipateSurveyController', ParticipateSurveyController);
    //Injecting the Angular JS Scope and required modules to be used for model binding between the view and the controller, making http requests etc.
    ParticipateSurveyController.$inject = ['$scope', '$http', '$location', '$mdDialog'];

    function ParticipateSurveyController($scope, $http, $location, $mdDialog) {
        $scope.activityId = 25;
        $scope.title = 'Survey';
        $scope.surveyTitle = "";
        $scope.description = "";
        $scope.questions = [];

        $scope.selectedAnswerModel = [];

        $scope.SurveyResults=function()
        {
            $scope.FillSurvey();
            $http.get('api/UserAnswer/GetUsersParticipated?activityId='+$scope.activityId).then(function success(response) {
                $scope.usersParticipated = response.data;
            },function error(response) {
                alert(response);
            $location.path('/error');
        });

        }

        $scope.FillSurvey=function()
        {
            $http.get('api/Survey/GetSurvey/?activityId=25').then(function success(response) {
                var data = response.data;
                $scope.title = data.heading;
                $scope.description = data.description;
                for(var i=0;i<data.Questions.length;i++)
                {
                    
                    $scope.questions.push(data.Questions[i]);

                }
            }, function error(response) {
                alert(response);
                $location.path('/error');
            });
        }



        $scope.SubmitSurvey = function ($event) {
            $event.preventDefault();
            for (var i = 0; i < $scope.selectedAnswerModel.length; i++)
            {
                $scope.selectedAnswerModel[i].count = $scope.selectedAnswerModel[i].count + 1;
            }
            var UserAnswersList = { Answers: $scope.selectedAnswerModel, UserId: "2" };
            $scope.LoginStatus = $http.post('api/Answer/PostSurveyAnswers/', UserAnswersList).then(function success(response) {
                console.log("success");
                //alert(response);
                var alert_text = "";
                if (response.status == 200) {
                    alert_text = "Survey submitted Successfully";
                } else {
                    alert_text = "Survey submission failed";
                }
                $mdDialog.show(
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Survey Submission')
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
    }
}())