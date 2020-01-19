'use strict';
app.controller('DashBoardCtrl', ['$scope', '$state', '$http', 'DashBoardService','UserInfoService', 'modalService', '$filter', 'toaster',
    function ($scope, $state, $http, DashBoardService,UserInfoService, modalService, $filter, toaster) {       
        $scope.init = function () {
            UserInfoService.SearchUserInfo(function (result) {
                console.log(result);
            })
        }
        $scope.init();

            //$scope.GetDate = function() {
            //    var a = new Date();
            //    var b = moment(a).format('MMMM Do YYYY, h:mm:ss a');                
            //    document.getElementById('ct').innerHTML = moment(new Date()).format('MMMM Do YYYY, h:mm:ss a');
            //    display_c();
            //}
            //var display_c=function() {
            //    var refresh = 1000; // Refresh rate in milli seconds
            //    var mytime = setTimeout($scope.GetDate(), refresh)
            //}

            //$scope.GetDate();
    }]);

