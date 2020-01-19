'use strict'
app.controller('UserListCtrl', ['$scope', 'UserInfoService', function ($scope, UserInfoService) {
    $scope.GetAll = function () {
        $scope.isLoading = true;
        UserInfoService.SearchUserInfo(function (result) {
            $scope.UserList = result;
            console.log($scope.UserList);
            $scope.isLoading = false;
        });
    }
    $scope.GetAll();
}]
);
app.directive('tooltip', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            element.hover(function () {
                // on mouseenter
                element.tooltip('show');
            }, function () {
                // on mouseleave
                element.tooltip('hide');
            });
        }
    };
});