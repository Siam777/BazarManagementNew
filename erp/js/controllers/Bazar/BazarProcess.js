'use strict'
app.controller('BazarProcessCtrl', ['$scope', 'BazarReportService', 'toaster', '$location', '$filter', '$timeout', '$http', function ($scope, BazarReportService, toaster, $location, $filter, $timeout, $http) {
    $scope.Bazar = {};
    $scope.BtnDisable = false;
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

    $scope.Process = function () {
        $scope.isLoading = true;
        $scope.BtnDisable = true;
        BazarReportService.Process({ MonthId :$scope.Bazar.MonthId,Year:$scope.Bazar.Year}, function (result) {
            console.log(result);
            console.log(Object.values(result));
            var message = (Object.values(result)).splice(0, Object.values(result).length - 2).toString().replace(/,/g, "");
            toaster.pop("success", message);
            $scope.isLoading = false;
            $scope.BtnDisable = false;
        })
    }
    
}]
);