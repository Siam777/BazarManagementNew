'use strict'
app.controller('BazarCollectionCtrl', ['$scope', 'CollectionService', 'toaster', '$location', '$filter','$timeout','$http', function ($scope, CollectionService, toaster, $location, $filter,$timeout,$http) {
    $scope.IsCreate = true;
    $scope.IsEdit = true;
    $scope.IsSearch = false;
    $scope.Bazar = {};
    $scope.BazarCollection = {};
    $scope.IsTable = true;
    $scope.IsCreatebtn = false;
    $scope.itemsPerPage = 20;
    $scope.IsCreateBtn = false;
    $scope.IsEditBtn = false;
    $scope.GetNew = function () {
        CollectionService.GetNew(function (result) {
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
    $scope.selectedUserforBazar = function (selected) {
        if (selected!=null && selected.originalObject != undefined) {
            console.log(selected.originalObject);
            $scope.Bazar.UserId = selected.originalObject.Id;
           // $scope.NewAttendanceReports.UserInfoId = selected.originalObject.UserInforId
        }
        else {
            $scope.Bazar.UserId = 0;
        }
    }
    $scope.selectedUser = function (selected) {
        if (selected != null && selected.originalObject != undefined) {
            console.log(selected.originalObject);
            $scope.BazarCollection.UserId = selected.originalObject.Id;
            // $scope.NewAttendanceReports.UserInfoId = selected.originalObject.UserInforId
        }
        else {
            $scope.BazarCollection.UserId = 0;
        }
    }
    $scope.globalSearch = function (userInputString, timeoutPromise) {
        console.log(userInputString);
        //var result = $timeout(function () { return CollectionService.GetUserInfo({ text: userInputString }), 3000 });
      //  var result = CollectionService.GetUserInfo({ text: userInputString });
        //console.log(result);        
        return $http({ url: apiUrlPrefix + "api/GetUserInfo?text=" + userInputString, method: 'GET' }).then(function (result) {
                return result;
            });
        
        //return result;
    }
    $scope.Create = function () {
        $scope.IsTable = true;
        $scope.BazarCollection.Year = year;
        $scope.BazarCollection.MonthId = month;
        $scope.BazarCollection.BazarTypeId = 1;
        $scope.IsSearch = true;
        $scope.IsCreate = false;
        $scope.IsCreateBtn = true;
        //$scope.IsEditBtn = false;
    }
    $scope.Cancel = function () {
        $scope.BazarCollection = {};
        $scope.EditBazarCollection = {};
        $scope.IsSearch = false;
        $scope.IsCreate = true;
        $scope.IsEdit = true;
        $scope.IsTable = false;
        //$scope.IsCreatebtn = false;
        $scope.IsCreateBtn = false;
        $scope.IsEditBtn = false;
    }
    $scope.Edit = function (item) {
        $scope.IsTable = true;
        $scope.IsCreateBtn = true;
        $scope.EditBazarCollection = item;
        $scope.IsSearch = true;
        $scope.IsCreate = true;
        $scope.IsEdit = false;
    }
    $scope.GetAll = function () {
        if ($scope.Bazar.UserId == null) {
            $scope.Bazar.UserId = 0;
        }
        CollectionService.GetAll({
            Year: $scope.Bazar.Year,
            MonthId: $scope.Bazar.MonthId,
            BazarTypeId: $scope.Bazar.BazarTypeId,
            UserId: $scope.Bazar.UserId
        }, function (result) {
            $scope.BazarList = result;
            $scope.BazarList.sort(function (a, b) {
                var DateA = new Date(a.CollectionDate);
                var DateB = new Date(b.CollectionDate);
                return DateB - DateA;
            });
            var ListLength = $scope.BazarList.length;
            var TotalCollection = 0;
            for (var i = 0; i < ListLength; i++) {
                TotalCollection += $scope.BazarList[i].Collection;
            }
            $scope.TotalCollection = TotalCollection;
           // $scope.BazarList.sort(function (a, b) { return a.Date.getTime() - b.Date.getTime() });
            console.log(result);
            $scope.currentPage = 0;
            $scope.BazarItem = $scope.BazarList;
            // now group by pages
            $scope.groupToPages();
            $scope.IsTable = false;
            $scope.IsCreateBtn = false;
         //   $scope.IsEditBtn = false;
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
        if ($scope.BazarCollection.CollectionDate != null) {
            $scope.BazarCollection.CollectionDate = $filter('date')($scope.BazarCollection.CollectionDate, "yyyy-MM-dd");
        }
        var SaveData = angular.copy($scope.BazarCollection);
        console.log(SaveData);
        CollectionService.Save(SaveData, function (result) {
            $scope.IsSearch = false;
            $scope.IsCreate = true;
            $scope.IsEdit = true;
            $scope.BazarCollection = {};
            toaster.pop("success", "Succcessfully Saved");
            $scope.$broadcast('angucomplete-alt:clearInput');
            $scope.GetAll();
            $scope.isLoading = false;
        }), function (error) {

        }               
    }
    $scope.Update = function () {
        $scope.isLoading = true;
        if ($scope.EditBazarCollection.CollectionDate != null) {
            $scope.EditBazarCollection.CollectionDate = $filter('date')($scope.EditBazarCollection.CollectionDate, "yyyy-MM-dd");
        }
        var UpdateData = angular.copy($scope.EditBazarCollection);
        console.log(UpdateData);
        CollectionService.update(UpdateData, function (result) {
            $scope.IsSearch = false;
            $scope.IsCreate = true;
            $scope.IsEdit = true;
            $scope.IsCreatebtn = false;
            $scope.EditBazarCollection = {};
            toaster.pop("success", "Succcessfully Updated");
            $scope.GetAll();
            $scope.isLoading = false;
        }), function (error) {

        }
    }
    $scope.OpenDeleteModal = function (itemForDelete) {
        $scope.ItemForDelete = itemForDelete;
        angular.element("#BazarCollectionModal").modal("show");
    }
    $scope.Delete = function () {
        var Id = $scope.ItemForDelete.Id;
        console.log(Id);
        $scope.isLoading = true;
        CollectionService.Delete({ Id: Id }, function (result) {
            toaster.pop("success", "Succcessfully Deleted");
            angular.element("#BazarCollectionModal").modal("hide");
            $scope.GetAll();
            $scope.isLoading = false;            
        })
    }
}]
);