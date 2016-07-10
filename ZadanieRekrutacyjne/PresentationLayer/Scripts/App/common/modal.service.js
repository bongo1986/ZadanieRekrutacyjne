(function () {
    var modalService = function ($uibModal) {
        var modalDefaults = {
            backdrop: true,
            keyboard: true,
            modalFade: true,
            templateUrl: "/Scripts/App/common/modal.template.html"
        };
        var modalOptions = {
            closeButtonText: 'Close',
            actionButtonText: 'OK',
            headerText: 'Proceed?',
            showCancelButton: true,
            bodyText: 'Perform this action?'
        };
        var service = {
            showModal : function (customModalDefaults, customModalOptions, okCallback, closeCallback) {
                if (!customModalDefaults) customModalDefaults = {};
                customModalDefaults.backdrop = 'static';
                return this.show(customModalDefaults, customModalOptions, okCallback, closeCallback);
            },
            show: function (customModalDefaults, customModalOptions, okCallback, closeCallback) {
                //Create temp objects to work with since we're in a singleton service
                var tempModalDefaults = {};
                var tempModalOptions = {};

                //Map angular-ui modal custom defaults to modal defaults defined in service
                angular.extend(tempModalDefaults, modalDefaults, customModalDefaults);

                //Map modal.html $scope custom properties to defaults defined in service
                angular.extend(tempModalOptions, modalOptions, customModalOptions);

                if (!tempModalDefaults.controller) {
                    tempModalDefaults.controller = ['$scope', '$uibModalInstance', function ($scope, $uibModalInstance) {
                        $scope.modalOptions = tempModalOptions;
                        $scope.modalOptions.ok = function (result) {
                            $uibModalInstance.close(result);
                            if (okCallback) {
                                okCallback();
                            }
                        };
                        $scope.modalOptions.close = function (result) {
                            $uibModalInstance.dismiss('cancel');
                            if (closeCallback) {
                                closeCallback();
                            }
                        };
                    }];
                }
                var result = $uibModal.open(tempModalDefaults).result;
                return result;
            }
        }
        return service;
    };
    modalService.$inject = ['$uibModal'];
    angular.module("common").factory("modalService", modalService);
})();