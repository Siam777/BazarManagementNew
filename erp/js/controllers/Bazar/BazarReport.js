'use strict'
app.controller('BazarReportCtrl', ['$scope', 'BazarReportService', 'toaster', '$location', '$filter', '$timeout', '$http', function ($scope, BazarReportService, toaster, $location, $filter, $timeout, $http) {
    $scope.Bazar = {};
    $scope.IsInstallation = false;
    $scope.IsBazar = false;
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
    $scope.GetReport = function () {
        $scope.BazarList = []
        console.log($scope.BazarReportId);       
        $scope.isLoading = true;
        BazarReportService.GetReport({ Year: $scope.Bazar.Year, MonthId: $scope.Bazar.MonthId, BazarReportId: $scope.Bazar.BazarReportId }, function (result) {
            console.log(result);
            $scope.BazarList = result;
            if ($scope.BazarList.length > 0) {
                if ($scope.Bazar.BazarReportId == 1) {
                    $scope.ReportName = "Bazar Report";
                    $scope.SetReport = "Bazar";
                    $scope.TotalBazarCost = $scope.BazarList[0].TotalBazarCost;
                    $scope.Month = $scope.BazarList[0].Month;
                    console.log($scope.TotalBazarCost);
                    console.log($scope.Month);
                    $scope.IsBazar = true;
                    $scope.IsInstallation = false;

                } else {
                    $scope.ReportName = "Installation Report";
                    $scope.SetReport = "Installation";
                    $scope.TotalBazarCost = $scope.BazarList[0].TotalInstallationCost;
                    console.log($scope.TotalBazarCost);
                    $scope.Month = $scope.BazarList[0].Month;
                    console.log($scope.Month);
                    $scope.IsInstallation = true;
                    $scope.IsBazar = false;
                }                
            }
            $scope.isLoading = false;
        })
    }
    $scope.Prints = function () {
        print();
    }
}]
);