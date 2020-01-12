'use strict'
app.controller('UserListCtrl', ['$scope', 'UserInfoService', function ($scope, UserInfoService) {
    $scope.GetAll = function () {
        UserInfoService.SearchUserInfo(function (result) {
            $scope.UserList = result;
            console.log($scope.UserList);
        });
    }
    $scope.GetAll();
}]
);