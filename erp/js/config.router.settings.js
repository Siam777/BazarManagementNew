'use strict';

/**
 * Config for the router
 */


angular.module('app')
   .run(
    ['$rootScope', '$state', '$stateParams',
      function ($rootScope, $state, $stateParams) {
          $rootScope.$state = $state;
          $rootScope.$stateParams = $stateParams;
      }
    ]
  )
  .config(
    ['$stateProvider', '$urlRouterProvider', '$locationProvider',
      function ($stateProvider, $urlRouterProvider, $locationProvider) {

          
              // Institute Settings
               
          //$urlRouterProvider
          //    .otherwise('/app/dashboard');
          //$stateProvider.state('app.institutesettings', {
          //        abstract: true,
          //        url: '/institutesettings',
          //        templateUrl: 'tpl/settings/Institute/Institute.html',
          //        // use resolve to load other dependences
          //        resolve: {
          //            deps: [
          //                'uiLoad',
          //                function(uiLoad) {
          //                    return uiLoad.load(['js/app/settings/settings.js']);
          //                }
          //            ]
          //        }
          //    })
              

      }
    ]
  );