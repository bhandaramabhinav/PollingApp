(function () {
    'use strict';
    //Reigstering the Controller with the Angular JS module defined for our application.
    angular
        .module('app')
        .controller('GroupController', GroupController);
    //Injecting the Angular JS Scope and required modules to be used for model binding between the view and the controller, making http requests etc.
    GroupController.$inject = ['$scope', '$http', '$location', '$mdDialog'];

    function GroupController($scope, $http, $location, $mdDialog) {
        $scope.title = 'Group';
        $scope.groupTitle = "";

        activate();

        function activate() {

        }

        $scope.members = [];

        $scope.AddMember = function (member) {
           // alert("inside AddMember function");
            if (member == undefined) {
                $scope.members.push({});
            }
        }


        //Purpose: To proces the create poll request of clients of our application.
        //Input: $event to prevent the default JS behaviour of the link button.
        //Output: An alert showing the 'create poll' status .

        //Hardcoded the following data entries: pollType, category, createdby
        $scope.CreateGroup = function ($event) {
            $event.preventDefault();
            var Group = { name: $scope.groupTitle, createdby: 1 };
            var groupDetails = { group: Group, UserList:$scope.members};
            $scope.CreateGroupStatus = $http.post('api/Groups/PostGroup', groupDetails).then(function success(response) {
                alert(response);
                var alert_text = "";
                if (response.data) {
                    alert_text = "Group is created Successfully";
                } else {
                    alert_text = "Group creation failed";
                }
                $mdDialog.show(
                    $mdDialog.alert()
                      .parent(angular.element(document.querySelector('#popupContainer')))
                      .clickOutsideToClose(true)
                      .title('Group Creation')
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
