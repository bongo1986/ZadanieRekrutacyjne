(function () {
    var devcontracts = function (appModel, modalService, httpdevcontracts) {
        
        function calculateSalary(newDevContract)
        {
            var salary = 0;
            var baseSalary = 0;

            //All numbers should be difined as constants
            switch(newDevContract.ContractType){
                case appModel.ContractType.developer:
                    if (newDevContract.ExperienceYears >= 1 && newDevContract.ExperienceYears < 3)
                    {
                        baseSalary = 2500;
                    }
                    else if (newDevContract.ExperienceYears >= 3 && newDevContract.ExperienceYears <= 5)
                    {
                        baseSalary = 5000;
                    }
                    else if (newDevContract.ExperienceYears > 5 )
                    {
                        baseSalary = 5500;
                    }
                    break;
                case appModel.ContractType.tester:
                    if (newDevContract.ExperienceYears >= 1 && newDevContract.ExperienceYears < 2)
                    {
                        baseSalary = 2000;
                    }
                    else if (newDevContract.ExperienceYears >= 2 && newDevContract.ExperienceYears <= 4)
                    {
                        baseSalary = 2700;
                    }
                    else if (newDevContract.ExperienceYears > 4 )
                    {
                        baseSalary = 3200;
                    }
                    break;
                default:
                    break;
            }
            switch (newDevContract.ContractType)
            {
                case appModel.ContractType.developer:
                    salary = baseSalary + newDevContract.ExperienceYears * 125;
                    break;
                case appModel.ContractType.tester:
                    salary = baseSalary + newDevContract.ExperienceYears * 100 + baseSalary / 4;
                    break;
                default:
                    break;
            }
            return salary;
        }

        function getPage(tableState) {
            if (!appModel.tableState) {
                appModel.tableState = tableState;
            }

            var pagination = tableState.pagination;

            var itemsPerPage = 10;
            var pageNr = (pagination.start || 0) / 10;

            appModel.filter.pageNr = pageNr;
            appModel.blockingPromises.mainWindow = httpdevcontracts.getPage(appModel.filter).then(function (result) {
                appModel.tableRows = result.data.DevContractsPage
                tableState.pagination.totalItemCount = result.data.TotalNumberOfItems;
                tableState.pagination.numberOfPages = Math.floor((result.data.TotalNumberOfItems + itemsPerPage - 1) / itemsPerPage);

            });

        }

        function resetGrid() {
            appModel.tableState.pagination.start = 0;
            getPage(appModel.tableState);
        }
        function addNewContract() {
            modalService.showModal({
                templateUrl: "/Scripts/App/devcontracts/addContract.template.html"
            }, {
                closeButtonText: 'Close',
                actionButtonText: 'Add',
                headerText: 'Add new contract',
                showCancelButton: true,
                newDevContract: appModel.newDevContract,
                contratTypeEnum: appModel.ContractType
            }, function () {
                appModel.blockingPromises.mainWindow = httpdevcontracts.addNewContract(appModel.newDevContract).then(function () {
                    modalService.showModal({}, {
                        closeButtonText: 'Close',
                        actionButtonText: 'Ok',
                        headerText: 'Success',
                        bodyText: 'New contract added',
                        showCancelButton: false,
                    }, function () {
                        resetGrid();
                    });
                    appModel.newDevContract = {
                        ContractType: appModel.ContractType.developer
                    };
                });
            });
        }
        

        var service = {
            calculateSalary: calculateSalary,
            addNewContract: addNewContract,
            getPage: getPage,
            resetGrid: resetGrid
        }
        return service;
    };
    devcontracts.$inject = ['appModel', 'modalService', 'httpdevcontracts'];
    angular.module("devcontracts").factory("devcontractsSrv", devcontracts);
})();