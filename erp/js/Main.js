'use strict';

/* Controllers */

angular.module('app')
  .controller('AppCtrl', ['$scope', '$window', '$rootScope',
    function ($scope, $window, $rootScope) {
        // add 'ie' classes to html
        var isIE = !!navigator.userAgent.match(/MSIE/i);
        isIE && angular.element($window.document.body).addClass('ie');       
        //live        
        $scope.Name = "Siam Riaz";
        $scope.Check = "Check";
        // config       

    }]);



