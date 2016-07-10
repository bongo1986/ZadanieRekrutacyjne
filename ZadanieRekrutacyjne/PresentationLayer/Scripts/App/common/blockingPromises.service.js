(function () {
    var blockingPromises = function () {
        var service = {
            mainWindow: null,
        }
        return service;
    };
    blockingPromises.$inject = [];
    angular.module("common").factory("blockingPromises", blockingPromises);
})();