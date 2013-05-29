'use strict';

angular.module('WSSR.controllers', []).
  controller('StartController', ['$scope', '$rootScope', '$resource', '$location', function ($scope, $rootScope, $resource, $location) {

      var svnUpdateResource = $resource('/Svn/Update');

      $scope.status = false;

      $scope.begin = function () {

          var scriptsResource = $resource('/Scripts/Index');

          scriptsResource.query(function (response) {
              $rootScope.scriptGroups = response;
              $location.path('/Runner');
          });

      };

      $scope.updateAndBegin = function () {

          $scope.status = 'updating';

          svnUpdateResource.get(function () { $scope.begin(); });

      };

  }]).
  controller('RunnerController', ['$scope', '$resource', '$location', '$q', function ($scope, $resource, $location, $q) {

      if (!$scope.scriptGroups) {
          $location.path('/');
          return;
      }

      var runScriptResource = $resource('Runner/Run/:id', { id: '@id' }, { update: { method: 'PUT' } });
      
      $scope.selectGroup = function (scripts) {
          angular.forEach(scripts, function (script) {
              script.enabled = true;
              $scope.clearResultStatus(script);
          });
      };
      $scope.deselectGroup = function (scripts) {
          angular.forEach(scripts, function (script) {
              script.enabled = false;
          });
      };

      $scope.selectAll = function (scriptGroups) {
          angular.forEach(scriptGroups, function (scriptGroup) {
              $scope.selectGroup(scriptGroup.Scripts);
          });
      };

      $scope.deselectAll = function (scriptGroups) {
          angular.forEach(scriptGroups, function (scriptGroup) {
              $scope.deselectGroup(scriptGroup.Scripts);
          });
      };

      $scope.run = function (script) {

          var deferred = $q.defer();

          script.inProgress = true;
          runScriptResource.update(script, function () {
              script.inProgress = false;
              script.enabled = false;
              script.resultStatus = 'success';
              deferred.resolve();
          });

          return deferred.promise;
      };

      $scope.runAllSelected = function (scriptGroups) {

          var promises = [];

          $scope.inProgress = true;
          angular.forEach(scriptGroups, function (scriptGroup) {
              var enabledScripts = scriptGroup.Scripts.filter(function (script) { return script.enabled; });
              angular.forEach(
                  enabledScripts,
                  function (script) {
                      var promise = $scope.run(script);
                      promises.push(promise);
                  });
          });

          $q.all(promises).then(function () { $scope.inProgress = false; });
      };

      $scope.clearResultStatus = function (script) { script.resultStatus = false; };

  }]);

angular.module('WSSR', ['ngResource', 'WSSR.controllers']).
  config(['$routeProvider', function ($routeProvider) {
      $routeProvider.when('/', { templateUrl: 'Start', controller: 'StartController' });
      $routeProvider.when('/Runner', { templateUrl: 'Runner', controller: 'RunnerController' });
      $routeProvider.otherwise({ redirectTo: '/' });
  }]);