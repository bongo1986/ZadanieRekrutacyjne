(function () {
    var httpdevcontracts = function ($http, appModel) {

      

        var service = {
            addNewContract: function (newDevContract) {
               return  $http({
                    method: 'PUT',
                    url: '/api/devcontract',
                    data: newDevContract
                })
            },
            getPage: function (filter) {
                var p = angular.copy(filter);
                if (p.ContractType == appModel.ContractType.all) {
                    p.ContractType = null;
                }

                return $http({
                    method: 'GET',
                    url: '/api/devcontract',
                    params: p
                });
            }
        }
        return service;
    };
    httpdevcontracts.$inject = ['$http', 'appModel'];
    angular.module("devcontracts").factory("httpdevcontracts", httpdevcontracts);
})();