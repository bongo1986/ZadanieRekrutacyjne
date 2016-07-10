/// <reference path="../../../angular.js" />
/// <reference path="../../../angular-mocks.js" />
/// <reference path="../../../jquery-3.0.0.js" />
/// <reference path="../../../prototypeModifications.js" />

/// <reference path="../../common/common.module.js" />
/// <reference path="../../common/blockingPromises.service.js" />


describe("blocking promises service", function () {
    var service;
    beforeEach(module('common'));
    beforeEach(inject(function (blockingPromises) {
        service = blockingPromises;
    }));
    describe("when created", function () {
        it("exposes public methods and properties", function () {
            expect(service.mainWindow).toBeDefined();
        });
    });
});