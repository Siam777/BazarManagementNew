'use strict'
app.controller('BazarExpenseCtrl', ['$scope', 'BazarService','toaster', '$location', '$filter', function ($scope, BazarService,toaster, $location, $filter) {
    $scope.IsCreate = true;
    $scope.IsEdit = true;
    $scope.IsSearch = false;
    $scope.Bazar = {};
    $scope.BazarExpense = {};
    $scope.IsTable = true;
    $scope.IsCreatebtn = false;
    $scope.itemsPerPage = 20;
    $scope.GetNew = function () {
        BazarService.GetNew(function (result) {
            $scope.BazarTypeList = result.BazarTypeList;
            $scope.Bazar.Year = currentTime.getFullYear();
            $scope.Bazar.MonthId = currentTime.getMonth() + 1;
            $scope.Bazar.BazarTypeId = $scope.BazarTypeList[0].Key;
            $scope.GetAll();
        })
    };
    $scope.GetNew();
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
    //$scope.Bazar.Year = currentTime.getFullYear();
    //$scope.Bazar.MonthId = month;
    $scope.Create = function () {
        $scope.IsTable = true;
        $scope.BazarExpense.Year = year;
        $scope.BazarExpense.MonthId = month;
        $scope.IsSearch = true;
        $scope.IsCreate = false;
        $scope.IsCreatebtn = true;
    }
    $scope.Cancel = function () {        
        $scope.IsSearch = false;
        $scope.IsCreate = true;
        $scope.IsEdit = true;
        $scope.IsTable = false;
        $scope.IsCreatebtn = false;
        $scope.BazarExpense = {};
        $scope.EditBazarExpense = {};
    }
    $scope.Edit = function (item) {
        $scope.IsTable = true;
        $scope.IsCreatebtn = true;
        $scope.EditBazarExpense = item;
        $scope.IsSearch = true;
        $scope.IsCreate = true;
        $scope.IsEdit = false;
    }
    $scope.GetAll = function () {
        BazarService.GetAll({
            Year: $scope.Bazar.Year,
            MonthId: $scope.Bazar.MonthId,
            BazarTypeId: $scope.Bazar.BazarTypeId
        }, function (result) {
            $scope.BazarList = result;
            var ListLength = $scope.BazarList.length;
            
                $scope.IsCreatebtn = false;
           
            var TotalCost = 0;
            for (var i = 0; i < ListLength; i++) {
                TotalCost += $scope.BazarList[i].Expense;
            }
            $scope.TotalCost = TotalCost;
            $scope.BazarList.sort(function (a, b) { 
                var DateA = new Date(a.Date);
                var DateB = new Date(b.Date);
                return DateB - DateA;
            });
            console.log(result);
            $scope.currentPage = 0;
            $scope.BazarItem = $scope.BazarList;
            // now group by pages
            $scope.groupToPages();
            $scope.IsTable = false;
            }
        )
    }
    $scope.groupToPages = function () {
        $scope.pagedItems = [];
        if ($scope.BazarItem) {
            for (var i = 0; i < $scope.BazarItem.length; i++) {
                if (i % $scope.itemsPerPage === 0) {
                    $scope.pagedItems[Math.floor(i / $scope.itemsPerPage)] = [$scope.BazarItem[i]];
                } else {
                    $scope.pagedItems[Math.floor(i / $scope.itemsPerPage)].push($scope.BazarItem[i]);
                }
            }
        }
    };
    $scope.prevPage = function () {
        if ($scope.currentPage > 0) {
            $scope.currentPage--;
        }
    };

    $scope.nextPage = function () {
        if ($scope.currentPage < $scope.pagedItems.length - 1) {
            $scope.currentPage++;
        }
    };
    $scope.getTemplate = function (item) {

        //if (item.StudentId === $scope.selected.StudentId) return "display";
        //else

            return 'display';
    };

    $scope.setPage = function () {
        $scope.currentPage = this.n;
    };
    $scope.range = function (start, end) {
        var ret = [];
        if (!end) {
            end = start;
            start = 0;
        }
        for (var i = start; i < end; i++) {
            ret.push(i);
        }
        return ret;
    };
    $scope.Save = function () {
        $scope.isLoading = true;
        if ($scope.BazarExpense.Date != null) {
            $scope.BazarExpense.Date = $filter('date')($scope.BazarExpense.Date,"yyyy-MM-dd");
        }
        var SaveData = angular.copy($scope.BazarExpense);
        console.log(SaveData);
        BazarService.Save(SaveData, function (result) {
            $scope.IsSearch = false;
            $scope.IsCreate = true;
            $scope.IsEdit = true;
            $scope.BazarExpense = {};
            toaster.pop("success", "Succcessfully Saved");
            $scope.GetAll();
            $scope.isLoading = false;
        }), function (error) {

        }               
    }
    $scope.Update = function () {
        $scope.isLoading = true;
        if ($scope.EditBazarExpense.Date != null) {
            $scope.EditBazarExpense.Date = $filter('date')($scope.EditBazarExpense.Date, "yyyy-MM-dd");
        }
        var UpdateData = angular.copy($scope.EditBazarExpense);
        console.log(UpdateData);
        BazarService.update(UpdateData, function (result) {
            $scope.IsSearch = false;
            $scope.IsCreate = true;
            $scope.IsEdit = true;
            $scope.IsCreatebtn = false;
            $scope.EditBazarExpense = {};
            toaster.pop("success", "Succcessfully Updated");
            $scope.GetAll();
            $scope.isLoading = false;
        }), function (error) {

        }
    }
    $scope.OpenDeleteModal = function (itemForDelete) {
        $scope.ItemForDelete = itemForDelete;
        angular.element("#BazarExpenseModal").modal("show");
    }
    $scope.Delete = function () {
        var Id = $scope.ItemForDelete.Id;
        console.log(Id);
        $scope.isLoading = true;
        BazarService.Delete({ Id: Id }, function (result) {
            toaster.pop("success", "Succcessfully Deleted");
            angular.element("#BazarExpenseModal").modal("hide");
            $scope.GetAll();
            $scope.isLoading = false;           
        })
    }
}]
);