
/// <reference path="../../../angular.js" />
/// <reference path="../../../angular-mocks.js" />
/// <reference path="../../../jquery-3.0.0.js" />

/// <reference path="../../common/common.module.js" />
/// <reference path="../../common/clientValidation.service.js" />
/// <reference path="../../common/clientValidation.directive.js" />

describe("client validation directive", function () {


    function clickElement(elem) {
        var event = document.createEvent("MouseEvent");
        event.initMouseEvent("click", true, true);
        elem.dispatchEvent(event);
    }
    function setText(elem, text) {
        $(elem).val(text);
        var evt = document.createEvent("HTMLEvents");
        evt.initEvent("change", true, true);
        elem.dispatchEvent(evt);
    }


    beforeEach(module('common'));

    beforeEach(angular.mock.inject(function ($rootScope, $compile) {
        mockScope = $rootScope.$new();
        compileService = $compile;
    }));

    describe("when created", function () {
        it("declares a function 'runifFormValid' on the current scope", function () {
            mockScope.save = jasmine.createSpy();
            var html = '<div><form name="addEditCategory" dd-client-validation><input class="tb"  ng-model="Name"  name="Name" type="text" ng-required="true" > <button type="button" class="btn btn-default" ng-click="runifFormValid(save)">Zapisz</button></form></div>';
            var compileFn = compileService(html);
            var elem = compileFn(mockScope);
            mockScope.$digest();
            expect(mockScope.runifFormValid).toBeDefined();
        });
    });
    describe("when used", function () {
        it("doesn't run the callback when form not valid", function () {
            mockScope.save = jasmine.createSpy();
            var html = '<div><form name="addEditCategory" dd-client-validation><input class="tb"  ng-model="Name"  name="Name" type="text" ng-required="true" > <button type="button" class="btn btn-default" ng-click="runifFormValid(save)">Zapisz</button></form></div>';
            var compileFn = compileService(html);
            var elem = compileFn(mockScope);
            mockScope.$digest();
            expect(mockScope.save).not.toHaveBeenCalled();
        });
        it("runs the callback when the form is valid", function () {
            mockScope.save = jasmine.createSpy();
            mockScope.Name = "";
            var html = '<div><form name="addEditCategory" dd-client-validation><input class="tb"  ng-model="Name"  name="Name" type="text" ng-required="true" > <button type="button" class="btn btn-default" ng-click="runifFormValid(save)">Zapisz</button></form></div>';
            var compileFn = compileService(html);
            var elem = compileFn(mockScope);
            mockScope.$digest();
            var tb = $(elem).find('.tb')[0];
            setText(tb, "testTxt");
            clickElement($(elem).find('.btn')[0]);
            expect(mockScope.save).toHaveBeenCalled();
        });
    });


});