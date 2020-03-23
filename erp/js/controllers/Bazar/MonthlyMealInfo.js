'use strict'
app.controller('MonthlyMealCtrl', ['$scope', 'BazarReportService', 'MealManagementService', 'toaster','UserInfoService', '$location', '$filter', '$timeout', '$http', function ($scope, BazarReportService,MealManagementService, toaster,UserInfoService, $location, $filter, $timeout, $http) {
    $scope.Bazar = {};
    $scope.IsInstallation = false;
    $scope.IsBazar = false;
    $scope.IsInfoFound = true;
    $scope.CreateButtonHide = true;
    $scope.IsCreateTableShow = true;
    $scope.IsEditTableShow = true;
    $scope.EditButtonHide = true;
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
    $scope.YearList = [];
    for (var i = 2019; i < 2030; i++) {
        $scope.YearList.push(i);
    }
    var currentTime = new Date();
    var year = currentTime.getFullYear();
    var month = currentTime.getMonth() + 1;
    $scope.Bazar.Year = year;
    $scope.Bazar.MonthId = month;


    /////Searching if there are any monthly info available or not
    $scope.GetMealInfo = function () {
        $scope.isLoading = true;
        var month = $filter('filter')($scope.Months, { Key: $scope.Bazar.MonthId }, true);
       // console.log(month);
        $scope.MonthName = month[0].Value;
       /// console.log($scope.MonthName);
        BazarReportService.GetMealInfo({ MonthId: $scope.Bazar.MonthId, Year: $scope.Bazar.Year }, function (data) {
            console.log(data);
            $scope.getAllDates();
            $scope.EditButtonHide = true;
            $scope.CreateButtonHide = true;
            $scope.IsInfoFound = false;
            $scope.IsEditTableShow = true;
            $scope.IsCreateTableShow = true;
            $scope.mealInfoDetails = data;
            ///Only push objects which has mealinfo greater than length 1 to check new creation of meal for month
            $scope.PrecisedMealInfo = [];
            for (var i = 0; i < $scope.mealInfoDetails.length; i++) {
                if ($scope.mealInfoDetails[i].MealInfo != null) {
                    $scope.mealInfoDetails[i].MealInfo = JSON.parse($scope.mealInfoDetails[i].MealInfo);
                    var count = 0;
                    for (var k = 0; k < $scope.mealInfoDetails[i].MealInfo.length; k++) {
                        $scope.mealInfoDetails[i].MealInfo[k].Id = parseInt($scope.mealInfoDetails[i].MealInfo[k].Id);
                        $scope.mealInfoDetails[i].MealInfo[k].UserId = $scope.mealInfoDetails[i].UserId;
                        $scope.mealInfoDetails[i].MealInfo[k].GuestMeal = parseInt($scope.mealInfoDetails[i].MealInfo[k].GuestMeal);
                        if ($scope.mealInfoDetails[i].MealInfo[k].IsDay == "1") {
                            $scope.mealInfoDetails[i].MealInfo[k].IsDay = true;

                            count++;
                        }
                        else {
                            $scope.mealInfoDetails[i].MealInfo[k].IsDay = false;
                        }
                        if ($scope.mealInfoDetails[i].MealInfo[k].IsNight == "1") {
                            $scope.mealInfoDetails[i].MealInfo[k].IsNight = true;
                            count++;
                        }
                        else {
                            $scope.mealInfoDetails[i].MealInfo[k].IsNight = false;
                        }
                    }
                    $scope.mealInfoDetails[i].TotalMonthlyMeal = count;
                    $scope.PrecisedMealInfo.push($scope.mealInfoDetails[i]);
                }
               
               
            }
           // console.log($scope.mealInfoDetails);
        //    console.log($scope.PrecisedMealInfo);
            if ($scope.PrecisedMealInfo.length== 0) {
                $scope.CreateButtonHide = false;
            }
            else {
                $scope.EditButtonHide = false;
            }
            $scope.Date = [];
            if ($scope.PrecisedMealInfo.length > 1) {
                for (var j = 0; j < $scope.PrecisedMealInfo[0].MealInfo.length; j++) {
                    var dateConversion = new Date($scope.mealInfoDetails[0].MealInfo[j].Date);
                    $scope.Date.push(dateConversion);
                }
              //  console.log($scope.Date);
            }
            $scope.isLoading = false;
        })
    }



    //////Dates of a Month
    $scope.getAllDates = function () {
        var month = $scope.Bazar.MonthId - 1;
        var date = new Date($scope.Bazar.Year, month, 1);
        var days = [];
        var StaticDays = [];
        
        while (date.getMonth() === month) {
            var obj = { date: $filter('date')(new Date(date), "yyyy-MM-dd") };
            days.push(obj);
            StaticDays.push(new Date(date));
            date.setDate(date.getDate() + 1);
        }
     //   console.log(days);
        $scope.DaysofMonth = days;
        $scope.Dates = StaticDays;
        $scope.range(StaticDays.length);
    }
    //////Data getting ready for save in database
    $scope.Create = function () {
        $scope.isLoading = true;
        $scope.CreateButtonHide = true;
        $scope.EditButtonHide = true;
        $scope.IsEditTableShow = true;
    //    $scope.EditButtonHide = true;
      //  $scope.CreateButtonHide = true;
        $scope.IsInfoFound = true;
       // $scope.CreateButtonHide = true;
        UserInfoService.GetMonthlyActivatedUsers({ MonthId: $scope.Bazar.MonthId, Year: $scope.Bazar.Year }, function (result) {
          //  console.log(result);
            $scope.IsCreateTableShow = false;
            $scope.UserList = result;
            var ActivateUserList = $filter('filter')($scope.UserList, { IsActive: true }, true);
            $scope.dataForMealManagement = [];
            var UserListLength = ActivateUserList.length;
               $scope.getAllDates();
                for (var i = 0; i < UserListLength; i++) {
                    var mealObj = {};
                    var mealArray=[];
                    console.log($scope.DaysofMonth.length);
                    for (var j = 0; j < $scope.DaysofMonth.length; j++) {
                        mealObj = {
                            Name: ActivateUserList[i].Name,
                            UserId: ActivateUserList[i].UserId,
                            Date: $scope.DaysofMonth[j].date,
                            MonthId: $scope.Bazar.MonthId,
                            Year:$scope.Bazar.Year
                        }
                        //console.log(mealObj);
                        mealArray.push(mealObj);

                    }
                    var obj = {
                        Name: ActivateUserList[i].Name,
                        UserId: ActivateUserList[i].UserId,
                        MealInfo: mealArray
                        // Date: $scope.GetMeal.Date
                    }
                    $scope.dataForMealManagement.push(obj);
                    console.log($scope.dataForMealManagement);
                }

            $scope.isLoading = false;
           
           // console.log($scope.UserList);
        });
    }
    $scope.range = function (n) {
        $scope.ArrayRange = [];
        for (i = 0; i < n; i++) {
            $scope.ArrayRange.push(i);
        }
    };



    ///////Save Monthly Meal data into database
    $scope.SaveMonthlyInfo = function () {
       // console.log($scope.dataForMealManagement);
        $scope.IsCreateTableShow = true;
        var AllDataArray=[]
      //  $scope.isLoading = true;
        console.log($scope.dataForMealManagement);
        var Data = angular.copy($scope.dataForMealManagement);
        for (var i = 0; i < Data.length; i++) {
            for (var j = 0; j < Data[i].MealInfo.length; j++) {
                AllDataArray.push(Data[i].MealInfo[j]);
            }
        }
       // console.log(AllDataArray);
        MealManagementService.Save(AllDataArray, function (result) {
           // console.log(result);
            toaster.pop("success", "Successfully Saved");
           
            $scope.dataForMealManagement = [];
            $scope.GetMealInfo();
         //   $scope.Search();
            $scope.isLoading = false;
        })
    }



    $scope.Edit = function () {
        $scope.IsEditTableShow = false;
        $scope.IsCreateTableShow = true;
        $scope.EditButtonHide = true;
        $scope.CreateButtonHide = true;
        $scope.IsInfoFound = true;
        $scope.getAllDates();
        $scope.EditMonthlyData = angular.copy($scope.PrecisedMealInfo);
        UserInfoService.GetMonthlyActivatedUsers({ MonthId: $scope.Bazar.MonthId, Year: $scope.Bazar.Year }, function (result) {
           // console.log(result);
            $scope.UserList = result;
            var ActivateUserList = $filter('filter')($scope.UserList, { IsActive: true }, true);
            for (var i = 0; i < ActivateUserList.length; i++) {
                var NewUserCheck = $filter('filter')($scope.EditMonthlyData, { UserId: ActivateUserList[i].UserId }, true);
                if (NewUserCheck.length == 0) {
                    var NewObj = {};
                    var newMealObj = {};
                    var newMealArray = [];
                    console.log($scope.DaysofMonth.length);
                    for (var j = 0; j < $scope.DaysofMonth.length; j++) {
                        newMealObj = {
                            Name: ActivateUserList[i].Name,
                            UserId: ActivateUserList[i].UserId,
                            Date: $scope.DaysofMonth[j].date,
                            MonthId: $scope.Bazar.MonthId,
                            Year: $scope.Bazar.Year
                        }
                        //console.log(mealObj);
                        newMealArray.push(newMealObj);

                    }
                    var NewObj = {
                        Name: ActivateUserList[i].Name,
                        UserId: ActivateUserList[i].UserId,
                        MealInfo: newMealArray
                        // Date: $scope.GetMeal.Date
                    }
                    $scope.EditMonthlyData.push(NewObj);
                }
                
            }
            console.log($scope.EditMonthlyData);
        })
        
    }

    ////update data
    $scope.Update = function () {
        var AllDataArrayforUpdate = []
          $scope.isLoading = true;
        console.log($scope.EditMonthlyData);
        var Data = angular.copy($scope.EditMonthlyData);
        for (var i = 0; i < Data.length; i++) {
            for (var j = 0; j < Data[i].MealInfo.length; j++) {
                AllDataArrayforUpdate.push(Data[i].MealInfo[j]);
            }
        }
        console.log(AllDataArrayforUpdate);
        MealManagementService.Save(AllDataArrayforUpdate, function (result) {
            console.log(result);
            toaster.pop("success", "Successfully Updated");
            $scope.IsEditTableShow = true;
            $scope.EditMonthlyData = [];
            $scope.GetMealInfo();
            //   $scope.Search();
            $scope.isLoading = false;
        })
    }
    $scope.Prints = function () {
        print();
    }
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