(function () {
    var appModel = function (bPromisses) {

        var ContractType = {
            developer: 0,
            tester: 1,
            all: -1
        };
        /*
         public string Name { get; set; }
        public ContractType? ContractType { get; set; }
        public int? ExperienceYears { get; set; }
        public decimal? Salary { get; set; }
        public bool OnlyProgrammersWith5YearsExperience { get; set; }
        public bool SalaryOver500 { get; set; }
        public int PageNr { get; set; }
        */
        var filter = {
            Name: null,
            ContractType: ContractType.all,
            ExperienceYears: null,
            Salary: null,
            OnlyProgrammersWith5YearsExperience: false,
            SalaryOver500: false,
            pageNr: 0
        };

        var service = {
            blockingPromises: bPromisses,
            filter: filter,
            newDevContract: {
                ContractType: ContractType.developer
            },
            tableRows: [],
            tableState: null,
            ContractType: ContractType
        }
        return service;
    };
    appModel.$inject = ['blockingPromises'];
    angular.module("devcontracts").factory("appModel", appModel);
})();