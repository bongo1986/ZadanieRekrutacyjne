(function () {
    var clientValidation = function () {
        var service = {
            runifFormValid: function (fun, args, form) {
                if (form.$valid) {
                    if (args) {
                        fun.apply(this, args);
                    }
                    else {
                        fun();
                    }
                }
                form.posted = true;
            },
        }
        return service;
    };
    clientValidation.$inject = [];
    angular.module("common").factory("clientValidationService", clientValidation);
})();