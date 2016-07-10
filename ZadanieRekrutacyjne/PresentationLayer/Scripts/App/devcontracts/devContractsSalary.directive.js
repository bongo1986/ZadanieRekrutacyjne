(function () {
    var ddDevContractsSalary = function (appModel, devcontractsSrv) {
        return {
            scope:{
                currentForm: "="
            },
            restrict: 'A',
            link: function (scope, element, attr) {
                scope.newDevContract = appModel.newDevContract;
                scope.$watch('newDevContract.ContractType', function (newValue, oldValue) {
                    if (angular.isDefined(newValue)  && scope.currentForm.$valid) {
                        var salary = devcontractsSrv.calculateSalary(appModel.newDevContract);
                        element.text(salary);
                    }
                });
                scope.$watch('newDevContract.ExperienceYears', function (newValue, oldValue) {
                    if (angular.isDefined(newValue)  && scope.currentForm.$valid) {
                        var salary = devcontractsSrv.calculateSalary(appModel.newDevContract);
                        element.text(salary);
                    }
                });
            }
        };
    }
    ddDevContractsSalary.$inject = ["appModel", "devcontractsSrv"];
    angular.module("devcontracts").directive("ddDevContractsSalary", ddDevContractsSalary);
})();