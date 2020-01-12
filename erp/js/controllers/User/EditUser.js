'use strict'
app.controller('EditUserCtrl', ['$scope', '$filter', 'UserInfoService', 'FileUploadService', '$stateParams', '$location', function ($scope, $filter, UserInfoService, FileUploadService, $stateParams, $location) {
    $scope.User = {};
    $scope.SetFullName = function () {
       console.log('test');
       $scope.User.Name= ($scope.User.FirstName?$scope.User.FirstName + ' ':'') + ($scope.User.MiddleName?$scope.User.MiddleName + ' ':'') + ($scope.User.LastName?$scope.User.LastName:'');
    }
    console.log($stateParams.Id);
    $scope.GetUser = function () {
        UserInfoService.GetUserInfoById({ UserId: parseInt($stateParams.Id) }, function (result) {
            console.log(result);
            $scope.User = result;
        });
    };
    if ($stateParams.Id != null) {
        console.log($stateParams.Id);
        $scope.GetUser();
    }
    
    $scope.SaveUser = function (user) {
        if (user.DOB != null) {
            user.DOB = $filter('date')(user.DOB, "yyyy-MM-dd");
        }
        console.log(user);
        UserInfoService.update(user, function (result) {
            console.log(result);
            $location.path("/app/user/UserDetails").search({ Id: $stateParams.Id });
           // $scope.GetUser();
        }), function (error) {
           
        }
    }
    $scope.Message = "";
    $scope.FileInvalidMessage = "";
    $scope.SelectedFileForUpload = null;
    $scope.FileDescription = "";
    $scope.IsFormSubmitted = false;
    $scope.IsFileValid = false;
    $scope.IsFormValid = false;

    //Form Validation
    $scope.$watch("f1.$valid", function (isValid) {
        console.log("file");
        $scope.IsFormValid = isValid;
    });   
    $scope.ChechFileValid = function (file) {
        var isValid = false;
        console.log("file");
        if ($scope.SelectedFileForUpload != null) {
            if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/gif') && file.size <= (512 * 1024)) {
                $scope.FileInvalidMessage = "";
                isValid = true;
            }
            else {
                $scope.FileInvalidMessage = "Selected file is Invalid. (only file type png, jpeg and gif and 512 kb size allowed)";
            }
        }
        else {
            $scope.FileInvalidMessage = "Image required!";
        }
        $scope.IsFileValid = isValid;
    };

    //File Select event 
    $scope.selectFileforUpload = function (file) {
        console.log("file");
        $scope.SelectedFileForUpload = file[0];
    }
    //----------------------------------------------------------------------------------------

    //Save File
    $scope.SaveFile = function () {
        $scope.IsFormSubmitted = true;
        $scope.Message = "";
        $scope.ChechFileValid($scope.SelectedFileForUpload);
        if ($scope.SelectedFileForUpload) {
            FileUploadService.UploadFile($scope.SelectedFileForUpload,parseInt($stateParams.Id)).then(function (d) {
                alert(d.Message);
                $scope.GetUser();
                //ClearForm();
            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.Message = "All the fields are required.";
        }
    };
    //Clear form 
    //function ClearForm() {
    //    $scope.FileDescription = "";
    //    console.log("file");
    //    //as 2 way binding not support for File input Type so we have to clear in this way
    //    //you can select based on your requirement
    //    angular.forEach(angular.element("input[type='file']"), function (inputElem) {
    //        angular.element(inputElem).val(null);
    //    });

    //    $scope.f1.$setPristine();
    //    $scope.IsFormSubmitted = false;
    //}
    //$scope.GetImage = function () {
    //    ImageService.GetImage(function (result) {
    //        console.log(result);
    //        console.log(Object.values(result));
    //        $scope.Image = (Object.values(result)).splice(0, Object.values(result).length - 2).toString().replace(/,/g, "");
    //        console.log($scope.Image);
    //    })


    //}
}]
);