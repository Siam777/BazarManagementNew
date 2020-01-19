app.factory('UserInfoService', ['$resource', function ($resource) {
    return $resource(apiUrlPrefix + 'api/UserInfo', {}, {
        'SearchUserInfo': { method: 'GET', isArray: true, url: apiUrlPrefix + "api/UserInfo/UserInfoSearch" },
        'GetActivatedUsers': { method: 'GET', isArray: true, url: apiUrlPrefix + "api/UserInfo/GetActivatedUsers" },
        'update': { method: 'PUT', url: apiUrlPrefix + "api/UserInfo/UpdateUserInfo" },
        'Save': { method: 'POST', url: apiUrlPrefix + "api/UserInfo/SaveUserInfo" },
        'GetUserInfoById': { method: 'GET', params: { UserId: 0 }, url: apiUrlPrefix + "api/UserInfo/UserInfoById" },
        'SaveMonthlyActivatedUser': { method: 'POST', url: apiUrlPrefix + "api/UserInfo/SaveMonthlyActivatedUser" },
        'GetMonthlyActivatedUsers': { method: 'GET', isArray: true, params: { MonthId: 'id', Year: 0 }, url: apiUrlPrefix + "api/UserInfo/GetMonthlyActivatedUser" },
       // 'getsingle': { method: 'GET', params: { id: 'teacherattendanceId' }, url: apiUrlPrefix + "api/teacherattendance/getsingle" }
    });
}]);
