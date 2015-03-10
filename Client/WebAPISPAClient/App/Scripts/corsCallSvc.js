'use strict';
angular.module('corsApp')
.factory('corsCallSvc', ['$http', function ($http) {
    return {
        getItems: function () {
            //This call will automatically acquire the access token via the ADAL.js endpoints initialization
           return $http.get('https://corsenabled3.azurewebsites.net/api/values');
        },

        postItems: function () {
            return $http({
                method: 'POST',
                url: 'https://corsenabled3.azurewebsites.net/api/values',
                data: '{test:"test",id:"id"}',
                headers: { 'Content-Type': 'application/json' }
            });



        },
        putItems: function () {
            return $http({
                method: 'PUT',
                url: 'https://corsenabled3.azurewebsites.net/api/values/1',
                data: '{test:"test",id:"id"}',
                headers: { 'Content-Type': 'application/json' }
            });
        }



    };
}]);