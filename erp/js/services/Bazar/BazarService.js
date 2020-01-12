app.factory('BazarService', ['$resource', function ($resource) {
    return $resource(apiUrlPrefix + 'api/BazarExpense', {}, {
        'GetAll': { method: 'GET', isArray: true,params:{Year:'year',MonthId:'id',BazarTypeId:'id'}, url: apiUrlPrefix + "api/BazarExpense/GetBazarExpenseList" },
        'update': { method: 'PUT', url: apiUrlPrefix + "api/BazarExpernse/update" },
        'Save': { method: 'POST', url: apiUrlPrefix + "api/BazarExpernse/Save" },
        'GetNew': { method: 'GET', url: apiUrlPrefix + "api/BazarExpense/GetNew" },
        'Delete': { method: 'DELETE',params:{Id:'id'}, url: apiUrlPrefix + "api/BazarExpense/Delete" }
    });
}]);
