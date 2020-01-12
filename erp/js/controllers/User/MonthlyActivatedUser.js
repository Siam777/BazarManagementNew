﻿'use strict'
app.controller('MonthlyActivatedUserCtrl', ['$scope', 'UserInfoService','$filter', function ($scope, UserInfoService,$filter) {

    $scope.MonthlyActivatedUser = {};
    $scope.IsTableShow = false;
    $scope.IsCreateDisable = false;
    $scope.IsCreateTable = false;
    $scope.IsEditTable = false;
    $scope.Months = [
      { "Key": 1, "Value": "January" },
      { "Key": 2, "Value": "February" },
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
    var currentTime = new Date();
    var year = currentTime.getFullYear();
    var month = currentTime.getMonth() + 1;
    $scope.MonthlyActivatedUser.MonthId = month;
    $scope.MonthlyActivatedUser.Year = year;
    console.log(year, month);
    $scope.Search = function () {
        UserInfoService.GetMonthlyActivatedUsers({ MonthId: $scope.MonthlyActivatedUser.MonthId, Year: $scope.MonthlyActivatedUser.Year }, function (result) {
            $scope.MonthlyActivatedUserList = result;
            if ($scope.MonthlyActivatedUserList.length > 0) {
                $scope.IsTableShow = true;
            }
            $scope.IsCreateTable = false;
            $scope.IsEditTable = false;
            $scope.IsEditDisable = false;
        });
    }
    $scope.Create = function () {
        UserInfoService.SearchUserInfo(function (result) {
            $scope.UserList = result;
            $scope.dataForMonthlyActivatedUser = [];
            var UserListLength = $scope.UserList.length;
            for (var i = 0; i < UserListLength; i++) {
                var obj = {
                    Name: $scope.UserList[i].Name,
                    UserId: $scope.UserList[i].Id,
                    MonthId: $scope.MonthlyActivatedUser.MonthId,
                    Year:$scope.MonthlyActivatedUser.Year
                }
                $scope.dataForMonthlyActivatedUser.push(obj);
                console.log($scope.dataForMonthlyActivatedUser);
            }
            $scope.IsCreateDisable = true;
            $scope.IsTableShow = false;
            $scope.IsCreateTable = true;
            $scope.IsEditTable = false;
            console.log($scope.UserList);
        });
    }
    $scope.Edit = function () {
        $scope.EditUserList = angular.copy($scope.MonthlyActivatedUserList);
        UserInfoService.SearchUserInfo(function (result) {
            var GetUserList = result;
            for (var i = 0; i < GetUserList.length; i++) {
                var filter = $filter('filter')($scope.EditUserList, { UserId: GetUserList[i].Id }, true);
                if (filter.length == 0) {
                    var object = {
                        Name: GetUserList[i].Name,
                        UserId: GetUserList[i].Id,
                        MonthId: $scope.MonthlyActivatedUser.MonthId,
                        Year: $scope.MonthlyActivatedUser.Year
                    }
                    $scope.EditUserList.push(object);
                }
            }
            $scope.IsEditDisable = true;
            $scope.IsTableShow = false;
            $scope.IsCreateTable = false;
            $scope.IsEditTable = true;
        });
        console.log($scope.EditUserList);
       // $scope.MonthlyActivatedUserList = [];           
                          
    }
    $scope.Save = function () {
        console.log($scope.dataForMonthlyActivatedUser);
        var Data = angular.copy($scope.dataForMonthlyActivatedUser);
        UserInfoService.SaveMonthlyActivatedUser(Data, function (result) {
            console.log(result);
            $scope.dataForMonthlyActivatedUser = [];
            $scope.Search();
        })
    }
    $scope.Update = function () {
        console.log($scope.EditUserList);
        var Data = angular.copy($scope.EditUserList);
        UserInfoService.SaveMonthlyActivatedUser(Data, function (result) {
            console.log(result);
            $scope.EditUserList = [];
            $scope.Search();
        })
    }
}]
);