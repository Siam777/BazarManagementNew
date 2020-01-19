'use strict'
app.controller('MealManagementCtrl', ['$scope','MealManagementService', 'UserInfoService', '$filter','toaster', function ($scope,MealManagementService, UserInfoService, $filter,toaster) {
    $scope.MonthlyActivatedUser = {};
    $scope.GetMeal = {};
    $scope.IsTableShow = false;
    $scope.IsCreateDisable = false;
    $scope.IsCreateTable = false;
    $scope.IsEditTable = false;
    $scope.IsCreateBtn = false;
    $scope.IsEditBtn = false;
   // $scope.Date = "";
    $scope.Months = [
      { "Key": 1, "Value": "January" },
      { "Key": 2, "Value": "February"},
      { "Key": 3, "Value": "March" },
      { "Key": 4, "Value": "April" },
      { "Key": 5, "Value": "May" },
      { "Key": 6, "Value": "June" },
      { "Key": 7, "Value": "July" },
      { "Key": 8, "Value": "August" },
      { "Key": 9, "Value": "September" },
      { "Key": 10, "Value": "October" },
      { "Key": 11, "Value": "November" },
      { "Key": 12, "Value": "December" }
    ];
    $scope.DateFixedforSearch = function () {
        console.log($scope.GetMeal);
        $scope.GetDate = angular.copy($scope.GetMeal.Date);
        $scope.Year = new Date($scope.GetDate).getFullYear();
        $scope.MonthId = new Date($scope.GetDate).getMonth() + 1;
        console.log($scope.Year, $scope.MonthId);
        if ($scope.GetMeal.Date != null) {
            $scope.GetMeal.Date = $filter('date')($scope.GetMeal.Date, "yyyy-MM-dd");
        }
        $scope.Search();
    }
    $scope.Search = function () {
        $scope.isLoading = true;
        console.log($scope.GetMeal.Date);
        $scope.DateForShow = new Date($scope.GetMeal.Date);
        $scope.Day = moment($scope.DateForShow).format('dddd');
        MealManagementService.GetAll({ Date: $scope.GetMeal.Date }, function (result) {
            $scope.MealManagementList = result;
            console.log($scope.MealManagementList);
            if ($scope.MealManagementList.length > 0) {
                $scope.IsTableShow = true;
            }
            $scope.isLoading = false;
            $scope.IsCreateTable = false;
            $scope.IsEditTable = false;
            $scope.IsEditDisable = false;
            $scope.IsCreateBtn = false;
            $scope.IsEditBtn = false;
        });
    }
    $scope.Create = function () {
        $scope.isLoading = true;
        $scope.IsCreateBtn = true;
      //  $scope.IsEditBtn = false;
        console.log($scope.GetDate);
        //var Year = $scope.GetDate.getFullYear();
        //var MonthId = $scope.GetDate.getMonth() + 1;
        console.log($scope.MonthId, $scope.Year);

        UserInfoService.GetMonthlyActivatedUsers({ MonthId: $scope.MonthId, Year: $scope.Year }, function (result) {
            $scope.UserList = result;            
            var ActivateUserList = $filter('filter')($scope.UserList, {IsActive:true},true);
            $scope.dataForMealManagement = [];
            var UserListLength = ActivateUserList.length;
            for (var i = 0; i < UserListLength; i++) {
                var obj = {
                    Name: ActivateUserList[i].Name,
                    UserId: ActivateUserList[i].UserId,
                    Date: $scope.GetMeal.Date
                }
                $scope.dataForMealManagement.push(obj);
                console.log($scope.dataForMealManagement);
            }
            $scope.isLoading = false;
            $scope.IsCreateDisable = true;
            $scope.IsTableShow = false;
            $scope.IsCreateTable = true;
            $scope.IsEditTable = false;
            console.log($scope.UserList);
        });
    }
    $scope.Edit = function () {
        $scope.isLoading = true;
       // $scope.IsCreateBtn = false;
        $scope.IsEditBtn = true;
        $scope.EditUserList = angular.copy($scope.MealManagementList);
        console.log($scope.GetDate);
        console.log($scope.GetMeal.Date);
        var NewDate = $filter('date')($scope.GetMeal.Date, "yyyy-MM-dd");
        console.log($scope.MonthId, $scope.Year);
        //var Year = $scope.GetDate.getFullYear();
        //var MonthId = $scope.GetDate.getMonth() + 1;
        UserInfoService.GetMonthlyActivatedUsers({ MonthId: $scope.MonthId, Year: $scope.Year }, function (result) {
            var GetUserList = result;
            var ActivateUserListforEdit = $filter('filter')(GetUserList, { IsActive: true }, true);
            for (var i = 0; i < ActivateUserListforEdit.length; i++) {
                var filter = $filter('filter')($scope.EditUserList, { UserId: ActivateUserListforEdit[i].UserId }, true);
                if (filter.length == 0) {
                    var object = {
                        Name: GetUserList[i].Name,
                        UserId: GetUserList[i].UserId,
                        Date: NewDate
                    }
                    $scope.EditUserList.push(object);
                }
            }
            $scope.isLoading = false;
            $scope.IsEditDisable = true;
            $scope.IsTableShow = false;
            $scope.IsCreateTable = false;
            $scope.IsEditTable = true;
        });
        console.log($scope.EditUserList);
       // $scope.MonthlyActivatedUserList = [];           
                          
    }
    $scope.Save = function () {
        $scope.isLoading = true;
        console.log($scope.dataForMealManagement);
        var Data = angular.copy($scope.dataForMealManagement);
        MealManagementService.Save(Data, function (result) {
            console.log(result);
            toaster.pop("success", "Successfully Saved");
            $scope.dataForMealManagement = [];
            $scope.Search();
            $scope.isLoading = false;
        })
    }
    $scope.Update = function () {
        $scope.isLoading = true;
        console.log($scope.EditUserList);
        var Data = angular.copy($scope.EditUserList);
        MealManagementService.Save(Data, function (result) {
            console.log(result);
            $scope.EditUserList = [];
            toaster.pop("success", "Successfully Updated");
            $scope.Search();
            $scope.isLoading = false;
        })
    }
}]
);