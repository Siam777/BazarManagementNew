//app.factory('ImageService', function ($http, $q) {
//    var fac = {};
//    fac.GetImage = function () {              
//        var defer = $q.defer();
//        return $http.get("/Image/GetImageById", {
//            //withCredentials: true,
//            //headers: { 'Content-type': undefined },
//            //transformRequest: angular.Identity
//        }).then(function (response) {
//            return response.data
//        })
//       // return defer.promise;
//    }
//    return fac;
//});
app.factory('ImageService', ['$resource', function ($resource) {
    return $resource(apiUrlPrefix + 'Image', {}, {
        'GetImage': { method: 'GET', url: apiUrlPrefix + "Image/GetImageById" }
    });
}]);
