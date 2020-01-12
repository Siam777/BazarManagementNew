'use strict'
app.controller('UserDetailsCtrl', ['$scope', 'UserInfoService', '$stateParams', function ($scope, UserInfoService, $stateParams) {
    console.log($stateParams.Id);
    $scope.GetUser = function () {
        UserInfoService.GetUserInfoById({ UserId: parseInt($stateParams.Id) }, function (result) {
            console.log(result);
            $scope.User = result;
        });
    };
    console.log(apiUrlPrefix);
    if ($stateParams.Id != null) {
        console.log($stateParams.Id);
        $scope.GetUser();
    }

}]
);