'use strict';
angular.module('corsApp')
.factory('corsCallSvc', ['$http', function ($http) {
    return {
        getItems: function () {
            //This call will automatically acquire the access token via the ADAL.js endpoints initialization
           return $http.get('https://corsenabled3.azurewebsites.net/api/values');
        }
    };
}]);