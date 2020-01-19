'use strict'
app.controller('CreateUserCtrl', ['$scope', 'UserInfoService', '$location', '$filter','toaster', function ($scope, UserInfoService, $location, $filter,toaster) {
    $scope.User = {};
    $scope.SetFullName = function () {
      // console.log('test');
       $scope.User.Name= ($scope.User.FirstName?$scope.User.FirstName + ' ':'') + ($scope.User.MiddleName?$scope.User.MiddleName + ' ':'') + ($scope.User.LastName?$scope.User.LastName:'');
    }
    $scope.SaveUser = function (user) {
        $scope.isLoading = true;
        toaster.pop("success", "Successfully Created");
        console.log(user);
        if (user.DOB != null) {
            user.DOB = $filter('date')(user.DOB, "yyyy-MM-dd");
        }
        console.log(user);
        UserInfoService.Save(user, function (result) {
            console.log(result);
            toaster.pop("success", "Successfully Updated");
            $scope.isLoading = false;
            //var path = "'/app/user/EditUser?Id=' + result.Id";
            //console.log(path);
            $location.path("/app/user/EditUser").search({Id:result.Id});
        }), function (error) {
           
        }
    }
}]
);