app.controller('BazarExpenseDetails', ['$scope', 'BazarService', '$stateParams','$filter', function ($scope, BazarService, $stateParams,$filter) {
    console.log($stateParams.id);
    $scope.Expense = {};
    $scope.Months = [
      { "Key": 1, "Value": "January" },
      { "Key": 2, "Value": "February" },
      { "Key": 3, "Value": "March" },
      { "Key": 4, "Value": "April" },
      { "Key": 5, "Value": "May" },
      { "Key": 6, "Value": "June" },
      { "Key": 7, "Value": "July" },
      { "Key": 8, "Value": "August" },
      { "Key": 9, "Value": "September" },
      { "Key": 10, "Value": "October" },
      { "Key": 11, "Value": "November" },
      { "Key": 12, "Value": "December" }
    ];
    var onInit = function () {
        BazarService.GetExpenseById({ Id: $stateParams.id }, function (data) {
            console.log(data);
            data.ImageUrl = JSON.parse(data.ImageUrl);
            $scope.Expense = data;
           // $scope.Expense.ImageUrl = JSON.parse($scope.Expense.ImageUrl);
            var monthfilter = $filter('filter')($scope.Months, { Key: data.MonthId }, true);
            $scope.Expense.MonthName = monthfilter[0].Value;
            
        })
    }
    onInit();

    $scope.OpenModal = function(index)
    {
        $scope.imageIndex = index;
        $scope.UrlImage = $scope.Expense.ImageUrl[index];
        angular.element("#attach_image").modal("show");
    }
}]);
app.directive('tooltip', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            element.hover(function () {
                // on mouseenter
                element.tooltip('show');
            }, function () {
                // on mouseleave
                element.tooltip('hide');
            });
        }
    };
});