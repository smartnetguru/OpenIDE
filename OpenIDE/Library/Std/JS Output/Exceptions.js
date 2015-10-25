var System;
(function (System) {
    var TypeNotSupportedError = (function () {
        function TypeNotSupportedError(name, message) {
            this.name = name;
            this.message = message;
        }
        return TypeNotSupportedError;
    })();
    System.TypeNotSupportedError = TypeNotSupportedError;
    var ArgumentError = (function () {
        function ArgumentError(name, message) {
            this.name = name;
            this.message = message;
        }
        return ArgumentError;
    })();
    System.ArgumentError = ArgumentError;
    var NotImplementedError = (function () {
        function NotImplementedError(name, message) {
            this.name = name;
            this.message = message;
        }
        return NotImplementedError;
    })();
    System.NotImplementedError = NotImplementedError;
    var ArgumentOutOfRangeError = (function () {
        function ArgumentOutOfRangeError(name, message) {
            this.name = name;
            this.message = message;
        }
        return ArgumentOutOfRangeError;
    })();
    System.ArgumentOutOfRangeError = ArgumentOutOfRangeError;
    var InvalidOperationError = (function () {
        function InvalidOperationError(name, message) {
            this.name = name;
            this.message = message;
        }
        return InvalidOperationError;
    })();
    System.InvalidOperationError = InvalidOperationError;
})(System || (System = {}));
