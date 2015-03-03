'use strict';
angular.module('corsApp', ['ngRoute','AdalAngular'])
.config(['$routeProvider', '$httpProvider', 'adalAuthenticationServiceProvider', function ($routeProvider, $httpProvider, adalProvider) {

    $routeProvider.when("/Home", {
        controller: "homeCtrl",
        templateUrl: "/App/Views/Home.html",
    }).when("/CorsCall", {
        controller: "corsCallCtrl",
        templateUrl: "/App/Views/CorsCall.html",
        requireADLogin: true,
    }).when("/UserData", {
        controller: "userDataCtrl",
        templateUrl: "/App/Views/UserData.html",
    }).otherwise({ redirectTo: "/Home" });

    //TODO: The endpoints setting ensures ADAL.js will automatically acquire the access tokens transparently during requests.
    var endpoints = {
        "https://corsenabled3.azurewebsites.net/": "670eef84-900f-475c-beab-53e0b1e6c333"
    };

    //TODO: Replace these by your tenant and client ID after having created the Azure AD applications
    adalProvider.init(
        {
            tenant: 'ted1.onmicrosoft.com',
            clientId: '69a9f159-0771-4d0e-a1c9-25a343b5cd0c',
            endpoints:endpoints
        },
        $httpProvider
        );
  
   
}]);
