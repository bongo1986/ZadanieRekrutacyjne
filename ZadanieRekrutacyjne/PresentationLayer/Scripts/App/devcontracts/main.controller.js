(function () {
    var MainController = function (appModel, devcontracts) {
        var vm = this
        vm.appModel = appModel;
        vm.addNewDevConterct = function () {
            devcontracts.addNewContract();
        };
        vm.filterGrid = function (tableState) {
            devcontracts.resetGrid();
        }
        vm.devcontracts = devcontracts;
    }
    MainController.$inject = ['appModel', 'devcontractsSrv'];
    angular.module("devcontracts").controller("MainController", MainController);
})();