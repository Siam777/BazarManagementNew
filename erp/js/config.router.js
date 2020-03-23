'use strict';
var apiUrlPrefix = 'http://localhost:9271/';
angular.module('app').run(
    ['$rootScope', '$state', '$stateParams', '$templateCache',
        function ($rootScope, $state, $stateParams, $templateCache) {
            //$rootScope.$on('$viewContentLoaded', function () {
            //    $templateCache.removeAll();
            //});
            $rootScope.$state = $state;
            $rootScope.$stateParams = $stateParams;
        }
    ]
).constant('ngAuthSettings', {
    apiServiceBaseUri: apiUrlPrefix,
    clientId: 'ngAuthApp'
}).config(
    ['$stateProvider', '$urlRouterProvider', '$locationProvider',
        function ($stateProvider, $urlRouterProvider, $locationProvider) {

            $urlRouterProvider
                .otherwise('/app/dashboard');
            $stateProvider
                .state('app', {
                    abstract: true,
                    url: '/app',
                    templateUrl: urlPrefix + 'Home/Dashboard'
                })
                .state('app.dashboard', {
                    url: '/dashboard',
                    templateUrl: urlPrefix + 'html/app_dashboard_v1.html',
                    resolve: {
                        deps: ['$ocLazyLoad',
                          function ($ocLazyLoad) {
                              return $ocLazyLoad.load(['toaster']).then(
                            function () {
                                return $ocLazyLoad.load([urlPrefix + 'js/controllers/Dashboard.js',
                                              urlPrefix + 'js/services/DashboardService.js',
                                              urlPrefix + 'js/services/UserInfo/UserInfoService.js'
                                ]);
                            }
                             );
                          }]
                    }
                })
                 .state('app.Test', {
                     url: '/test',
                     templateUrl: urlPrefix + 'html/Test.html',
                     resolve: {
                         deps: ['$ocLazyLoad',
                           function ($ocLazyLoad) {
                               return $ocLazyLoad.load(['toaster']).then(
                             function () {
                                 return $ocLazyLoad.load([urlPrefix + 'js/controllers/Test.js',
                                                          urlPrefix + 'js/services/FileUploaderService.js',
                                                          urlPrefix + 'js/services/ImageService.js'
                                 ]);
                             }
                              );
                           }]
                     }
                 })                            
             
             .state('app.CreateUser', {
                 url: '/user/CreateUser',
                 templateUrl: urlPrefix + 'html/User/CreateUser.html',
                 resolve: {
                     deps: ['$ocLazyLoad',
                       function ($ocLazyLoad) {
                           return $ocLazyLoad.load(['toaster']).then(
                         function () {
                             return $ocLazyLoad.load([urlPrefix + 'js/controllers/User/CreateUser.js',                                           
                                           urlPrefix + 'js/services/UserInfo/UserInfoService.js'
                             ]);
                         }
                          );
                       }]
                 }
             })
            .state('app.EditUser', {
                url: '/user/EditUser?Id',
                templateUrl: urlPrefix + 'html/User/EditUser.html',
                resolve: {
                    deps: ['$ocLazyLoad',
                      function ($ocLazyLoad) {
                          return $ocLazyLoad.load(['toaster']).then(
                        function () {
                            return $ocLazyLoad.load([urlPrefix + 'js/controllers/User/EditUser.js',
                                          urlPrefix + 'js/services/UserInfo/UserInfoService.js',
                                          urlPrefix + 'js/services/FileUploaderService.js'
                            ]);
                        }
                         );
                      }]
                }
            })
            .state('app.UserDetails', {
                url: '/user/UserDetails?Id',
                templateUrl: urlPrefix + 'html/User/UserDetails.html',
                resolve: {
                    deps: ['$ocLazyLoad',
                      function ($ocLazyLoad) {
                          return $ocLazyLoad.load(['toaster']).then(
                        function () {
                            return $ocLazyLoad.load([urlPrefix + 'js/controllers/User/UserDetails.js',
                                          urlPrefix + 'js/services/UserInfo/UserInfoService.js'
                                          
                            ]);
                        }
                         );
                      }]
                }
            })
            .state('app.UserList', {
                url: '/user/UserList',
                templateUrl: urlPrefix + 'html/User/UserList.html',
                resolve: {
                    deps: ['$ocLazyLoad',
                      function ($ocLazyLoad) {
                          return $ocLazyLoad.load(['toaster']).then(
                        function () {
                            return $ocLazyLoad.load([urlPrefix + 'js/controllers/User/UserList.js',
                                          urlPrefix + 'js/services/UserInfo/UserInfoService.js',
                                          urlPrefix + 'js/services/FileUploaderService.js'
                            ]);
                        }
                         );
                      }]
                }
            })
            .state('app.MonthlyActivatedUser', {
                url: '/user/MonthlyActivatedUser',
                templateUrl: urlPrefix + 'html/User/MonthlyActivatedUser.html',
                resolve: {
                    deps: ['$ocLazyLoad',
                      function ($ocLazyLoad) {
                          return $ocLazyLoad.load(['toaster']).then(
                        function () {
                            return $ocLazyLoad.load([urlPrefix + 'js/controllers/User/MonthlyActivatedUser.js',
                                          urlPrefix + 'js/services/UserInfo/UserInfoService.js',                                         
                            ]);
                        }
                         );
                      }]
                }
            })
            .state('app.BazarExpense', {
                url: '/Bazar/BazarExpense',
                templateUrl: urlPrefix + 'html/BazarExpense/BazarExpense.html',
                resolve: {
                    deps: ['$ocLazyLoad',
                      function ($ocLazyLoad) {
                          return $ocLazyLoad.load(['toaster']).then(
                        function () {
                            return $ocLazyLoad.load([urlPrefix + 'js/controllers/Bazar/BazarExpense.js',
                                          urlPrefix + 'js/services/Bazar/BazarService.js',
                            ]);
                        }
                         );
                      }]
                }
            })
            .state('app.BazarCollection', {
                url: '/Bazar/Collection',
                templateUrl: urlPrefix + 'html/BazarExpense/BazarCollection.html',
                resolve: {
                    deps: ['$ocLazyLoad',
                      function ($ocLazyLoad) {
                          return $ocLazyLoad.load(['toaster']).then(
                        function () {
                            return $ocLazyLoad.load([urlPrefix + 'js/controllers/Bazar/BazarCollection.js',
                                          urlPrefix + 'js/services/Bazar/CollectionService.js',
                            ]);
                        }
                         );
                      }]
                }
            })
            .state('app.MealManagement', {
                url: '/Bazar/MealManagement',
                templateUrl: urlPrefix + 'html/BazarExpense/MealManagement.html',
                resolve: {
                    deps: ['$ocLazyLoad',
                      function ($ocLazyLoad) {
                          return $ocLazyLoad.load(['toaster']).then(
                        function () {
                            return $ocLazyLoad.load([urlPrefix + 'js/controllers/Bazar/MealManagement.js',
                                          urlPrefix + 'js/services/Bazar/MealManagementService.js',
                                          urlPrefix + 'js/services/UserInfo/UserInfoService.js'
                            ]);
                        }
                         );
                      }]
                }
            })
            .state('app.BazarProcess', {
                url: '/Bazar/BazarProcess',
                templateUrl: urlPrefix + 'html/BazarExpense/BazarProcess.html',
                resolve: {
                    deps: ['$ocLazyLoad',
                      function ($ocLazyLoad) {
                          return $ocLazyLoad.load(['toaster']).then(
                        function () {
                            return $ocLazyLoad.load([urlPrefix + 'js/controllers/Bazar/BazarProcess.js',
                                          urlPrefix + 'js/services/Bazar/BazarReportService.js'                                         
                            ]);
                        }
                         );
                      }]
                }
            })
            .state('app.BazarReports', {
                url: '/Bazar/BazarReports',
                templateUrl: urlPrefix + 'html/BazarExpense/BazarReport.html',
                resolve: {
                    deps: ['$ocLazyLoad',
                      function ($ocLazyLoad) {
                          return $ocLazyLoad.load(['toaster']).then(
                        function () {
                            return $ocLazyLoad.load([urlPrefix + 'js/controllers/Bazar/BazarReport.js',
                                          urlPrefix + 'js/services/Bazar/BazarReportService.js'
                            ]);
                        }
                         );
                      }]
                }
            })
            .state('app.MonthlyMealInfo', {
                url: '/Bazar/MonthlyMealInfo',
                templateUrl: urlPrefix + 'html/BazarExpense/MonthlyMealInfo.html',
                resolve: {
                    deps: ['$ocLazyLoad',
                      function ($ocLazyLoad) {
                          return $ocLazyLoad.load(['toaster']).then(
                        function () {
                            return $ocLazyLoad.load([urlPrefix + 'js/controllers/Bazar/MonthlyMealInfo.js',
                                          urlPrefix + 'js/services/Bazar/BazarReportService.js',
                                          urlPrefix + 'js/services/Bazar/MealManagementService.js',
                                          urlPrefix + 'js/services/UserInfo/UserInfoService.js'

                            ]);
                        }
                         );
                      }]
                }
            })
        }
    ]
  );


