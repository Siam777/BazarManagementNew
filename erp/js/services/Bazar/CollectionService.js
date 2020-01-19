app.factory('CollectionService', ['$resource', function ($resource) {
    return $resource(apiUrlPrefix + 'api/CollectionForBazarAndInstallation', {}, {
        'GetAll': { method: 'GET', isArray: true, params: { Year: 'year', MonthId: 'id', BazarTypeId: 'id' }, url: apiUrlPrefix + "api/CollectionForBazarAndInstallation/GetCollectionList" },
        'update': { method: 'PUT', url: apiUrlPrefix + "api/CollectionForBazarAndInstallation/update" },
        'Save': { method: 'POST', url: apiUrlPrefix + "api/CollectionForBazarAndInstallation/Save" },
        'GetNew': { method: 'GET', url: apiUrlPrefix + "api/CollectionForBazarAndInstallation/GetNew" },
        'Delete': { method: 'DELETE', params: { Id: 'id' }, url: apiUrlPrefix + "api/CollectionForBazarAndInstallation/Delete" },
        'GetUserInfo': { method: 'GET', params: { text: " " }, isArray: true, url: apiUrlPrefix + "api/GetUserInfo" }

    });
}]);
