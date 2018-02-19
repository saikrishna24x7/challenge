var app = angular.module('myApp', ['ngRoute']);
app.controller('formCtrl', function($scope, $http){
    $scope.search = function(){
        $scope.city = null;
        $scope.country = null;
        console.log($scope.str);
        var params = {
            City : $scope.str
        }
     $http.post('http://127.0.0.1:8080/api/weather', params)
            .then(function(response) {
                console.log(response.data);
                $scope.weather = response.data;
                $scope.city = response.data.City;
                $scope.country = response.data.Country;
                $scope.temperature = response.data.Temperature;
                $scope.maximum = response.data.TemperatureMax;
                $scope.minimum = response.data.TemperatureMax;
                $scope.main = response.data.WeatherMain;
        });
    }

    $scope.random = function(){
        $http.post('http://127.0.0.1:8080/api/random/weather')
            .then(function(response) {
                console.log(response.data);
                $scope.weather = response.data;
                $scope.city = response.data.City;
                $scope.country = response.data.Country;
                $scope.temperature = response.data.Temperature;
                $scope.maximum = response.data.TemperatureMax;
                $scope.minimum = response.data.TemperatureMax;
                $scope.main = response.data.WeatherMain;
        });
    }
});