app.factory('MealManagementService', ['$resource', function ($resource) {
    return $resource(apiUrlPrefix + 'api/MealManagement', {}, {
        'GetAll': { method: 'GET', isArray: true, params: { Date: 'date' }, url: apiUrlPrefix + "api/MealManagement/GetAllByDate" },        
        'Save': { method: 'POST', url: apiUrlPrefix + "api/MealManagement/save" },
    });
}]);
