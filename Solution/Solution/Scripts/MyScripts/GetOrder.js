var OrderApp = angular.module('OrderApp', [])

OrderApp.controller('OrderController', function ($scope,OrderService) {
    getOrders();
    function getOrders() {
        OrderService.getOrder()
            .success(function (order) {
                //alert("success");            
                $scope.orders = order;
              
            })
            .error(function (error) {
                $scope.status = 'Unable to load customer data: ' + error.message;
                //alert($scope.status);
            });
    }

});
OrderApp.factory('OrderService', ['$http', function ($http) {
    var OrderService = {};
    OrderService.getOrder = function () {
        return $http({
            metod:'GET',
            url: '/Order/GetOrders'
        });
    };
    return OrderService;

}]);



OrderApp.filter("mydate", function () {  
    return function (x) {
        return new Date(parseInt(x.substr(6)));
    };
});