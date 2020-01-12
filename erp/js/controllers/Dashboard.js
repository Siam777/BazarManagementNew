'use strict';
/* Controllers */
// Notice controller
app.controller('DashBoardCtrl', ['$scope', '$state', '$http', 'DashBoardService','UserInfoService', 'modalService', '$filter', 'toaster',
    function ($scope, $state, $http, DashBoardService,UserInfoService, modalService, $filter, toaster) {       
        $scope.init = function () {
            UserInfoService.SearchUserInfo(function (result) {
                console.log(result);
            })
        }
        $scope.init();
    }]);

