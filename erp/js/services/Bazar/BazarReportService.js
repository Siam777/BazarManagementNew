app.factory('BazarReportService', ['$resource', function ($resource) {
    return $resource(apiUrlPrefix + 'api/BazarReport', {}, {
        'Process': { method: 'GET', params: { MonthId: 'id', Year: 'year' }, url: apiUrlPrefix + "api/BazarReport/Process" },
        'GetReport': { method: 'GET', params: { Year: 'year', MonthId: 'id', BazarReportId: 'id' }, isArray: true, url: apiUrlPrefix + "api/BazarReport/GetReport" },
        'GetMealInfo': { method: 'Get', params: { MonthId: 'id', Year: 'year' }, isArray: true, url: apiUrlPrefix + "api/BazarReport/GetMealInfo" }
    });
}]);
