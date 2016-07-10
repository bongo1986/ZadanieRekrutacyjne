(function () {
    var clientValidation = function (clientValidationService) {
        return {
            restrict: 'A',
            link: function (scope, element, attr) {
                scope.runifFormValid = function (fun, args) {
                    clientValidationService.runifFormValid(fun, angular.isArray(args) ? args : [args], scope[attr.name])
                }
            }
        };
    }
    clientValidation.$inject = ["clientValidationService"];
    angular.module("common").directive("ddClientValidation", clientValidation);
})();