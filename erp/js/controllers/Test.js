'use strict'
app.controller('testCtrl', ['$scope', 'Upload', '$timeout', 'FileUploadService','ImageService', function ($scope, Upload, $timeout, FileUploadService,ImageService) {
    $scope.UploadFiles = function (files) {
        console.log("test");
        $scope.SelectedFiles = files;
        if ($scope.SelectedFiles && $scope.SelectedFiles.length) {
            Upload.upload({
                url: '/Image/Upload',
                data: {
                    files:$scope.SelectedFiles
                }
            }).then(function (response) {
                $timeout(function () {
                    $scope.result = response.data;
                })
            }, function (response) {
                if (response.status > 0) {
                    var errormsg = response.status + ':' + response.data;
                }
            }, function (d) {
                var element = angular.element(document.querySelector('#divprogress'));
                $scope.Progress = Math.min(100, parseInt(100.0 * d.loaded / d.total));
                element.html('<div style="width:' + $scope.Progress + '%">' + $scope.Progress + '%</div>');
            }
            )
        }
    }
    console.log(apiUrlPrefix);
    console.log()
    $scope.Message = "";
    $scope.FileInvalidMessage = "";
    $scope.SelectedFileForUpload = null;
    $scope.FileDescription = "";
    $scope.IsFormSubmitted = false;
    $scope.IsFileValid = false;
    $scope.IsFormValid = false;
 
    //Form Validation
    $scope.$watch("f1.$valid", function (isValid) {
        $scope.IsFormValid = isValid;
    });
 
 
    // THIS IS REQUIRED AS File Control is not supported 2 way binding features of Angular
    // ------------------------------------------------------------------------------------
    //File Validation
    $scope.ChechFileValid = function (file) {
        var isValid = false;
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
        $scope.SelectedFileForUpload = file[0];
    }
    //----------------------------------------------------------------------------------------
 
    //Save File
    $scope.SaveFile = function () {
        $scope.IsFormSubmitted = true;
        $scope.Message = "";
        $scope.ChechFileValid($scope.SelectedFileForUpload);
        if ($scope.IsFormValid && $scope.IsFileValid) {
            FileUploadService.UploadFile($scope.SelectedFileForUpload, $scope.FileDescription).then(function (d) {
                alert(d.Message);
                ClearForm();
            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.Message = "All the fields are required.";
        }
    };
    //Clear form 
    function ClearForm() {
        $scope.FileDescription = "";
        //as 2 way binding not support for File input Type so we have to clear in this way
        //you can select based on your requirement
        angular.forEach(angular.element("input[type='file']"), function (inputElem) {
            angular.element(inputElem).val(null);
        });

        $scope.f1.$setPristine();
        $scope.IsFormSubmitted = false;
    }
    $scope.GetImage=function(){
        ImageService.GetImage(function (result) {
            console.log(result);
            console.log(Object.values(result));
            $scope.Image = (Object.values(result)).splice(0, Object.values(result).length-2).toString().replace(/,/g,"");
            console.log($scope.Image);
        })

        
    }
}]
);
