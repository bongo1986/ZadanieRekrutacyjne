/// <reference path="../../../angular.js" />
/// <reference path="../../../angular-mocks.js" />
/// <reference path="../../../jquery-3.0.0.js" />
/// <reference path="../../../prototypeModifications.js" />

/// <reference path="../../common/common.module.js" />
/// <reference path="../../devcontracts/devContracts.module.js" />
/// <reference path="../../devcontracts/devContracts.service.js" />


describe("devContracts  service", function () {
    var service;
    beforeEach(module('devcontracts'));
    var ContractType = {
        developer: 0,
        tester: 1
    }

    var appModel = {
        newDevContract: {},
        ContractType: ContractType
    }

    beforeEach(module(function ($provide) {
        $provide.value('appModel', appModel);
        $provide.value('modalService', {});
        $provide.value('httpdevcontracts', {});
    }));
    beforeEach(inject(function (devcontractsSrv) {
        service = devcontractsSrv;
    }));

 
    describe("when created", function () {
        it("exposes public methods and properties", function () {
            expect(service.calculateSalary).toBeDefined();
            expect(service.addNewContract).toBeDefined();
            expect(service.getPage).toBeDefined();
            expect(service.resetGrid).toBeDefined();
        });
    });
    describe("when used", function () {
        it("developer experience between 1 and 3 years salary calculated correctly", function () {
            //Arrange
            var contract = {
                ContractType : ContractType.developer,
                ExperienceYears : 1,
            }
            var contract2 = {
                ContractType: ContractType.developer,
                ExperienceYears: 2,
            }
            //Act
            var salary1 = service.calculateSalary(contract);
            var salary2 = service.calculateSalary(contract2);
            //Assert
            expect(salary1).toEqual(2500 + (1 * 125));
            expect(salary2).toEqual(2500 + (2 * 125));
        });

        it("developer experience between 3 and 5 years salary calculated correctly", function () {
            var contract = {
                ContractType: ContractType.developer,
                ExperienceYears: 3,
            }
            var contract2 = {
                ContractType: ContractType.developer,
                ExperienceYears: 5,
            }

            var salary1 = service.calculateSalary(contract);
            var salary2 = service.calculateSalary(contract2);
            expect(salary1).toEqual(5000 + (3 * 125));
            expect(salary2).toEqual(5000 + (5 * 125));
        });
        it("developer experience  over 5 years salary calculated correctly", function () {
            var contract = {
                ContractType: ContractType.developer,
                ExperienceYears: 6,
            }
            var contract2 = {
                ContractType: ContractType.developer,
                ExperienceYears: 8,
            }

            var salary1 = service.calculateSalary(contract);
            var salary2 = service.calculateSalary(contract2);
            expect(salary1).toEqual(5500 + (6 * 125));
            expect(salary2).toEqual(5500 + (8 * 125));
        });

        it("tester experience equals 1 year salary calculated correctly", function () {
            var contract = {
                ContractType: ContractType.tester,
                ExperienceYears: 1,
            }
          

            var salary1 = service.calculateSalary(contract);
           
            expect(salary1).toEqual(2000 + (1 * 100 + (2000/4)));
        });
        it("tester experience between 2 and 4 years salary calculated correctly", function () {
            var contract = {
                ContractType: ContractType.tester,
                ExperienceYears: 2,
            }
            var contract2 = {
                ContractType: ContractType.tester,
                ExperienceYears: 4,
            }

            var salary1 = service.calculateSalary(contract);
            var salary2 = service.calculateSalary(contract2);
            expect(salary1).toEqual(2700 + (2 * 100 + (2700 / 4)));
            expect(salary2).toEqual(2700 + (4 * 100 + (2700 / 4)));
        });

        it("tester experience  over 4 years salary calculated correctly", function () {
            var contract = {
                ContractType: ContractType.tester,
                ExperienceYears: 5,
            }
            var contract2 = {
                ContractType: ContractType.tester,
                ExperienceYears: 10,
            }

            var salary1 = service.calculateSalary(contract);
            var salary2 = service.calculateSalary(contract2);
            expect(salary1).toEqual(3200 + (5 * 100 + (3200 / 4)));
            expect(salary2).toEqual(3200 + (10 * 100 + (3200 / 4)));
        });
    });
});