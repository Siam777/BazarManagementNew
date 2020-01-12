app.factory('FileUploadService', function ($http, $q) {
    var fac = {};
    fac.UploadFile = function (file,UserId) {
        var formData = new FormData();
        formData.append("file", file);
        formData.append("UserId", UserId);
        var defer = $q.defer();
        $http.post("/Image/SaveFiles", formData, {
            withCredentials: true,
            headers: { 'Content-type': undefined },
            transformRequest: angular.Identity
        })
        .success(function (d) {
            defer.resolve(d);
        })
        .error(function () {
            defer.reject("File Upload Failed");
        });
        return defer.promise;
    }    
    return fac;
});