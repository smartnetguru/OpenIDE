define("Exceptions", [], function () {
    var TypeNotSupportedError = (function () {
        function TypeNotSupportedError(name, message) {
            this.name = name;
            this.message = message;
        }
        return TypeNotSupportedError;
    })();
    var ArgumentError = (function () {
        function ArgumentError(name, message) {
            this.name = name;
            this.message = message;
        }
        return ArgumentError;
    })();
    var NotImplementedError = (function () {
        function NotImplementedError(name, message) {
            this.name = name;
            this.message = message;
        }
        return NotImplementedError;
    })();
    var ArgumentOutOfRangeError = (function () {
        function ArgumentOutOfRangeError(name, message) {
            this.name = name;
            this.message = message;
        }
        return ArgumentOutOfRangeError;
    })();
    var InvalidOperationError = (function () {
        function InvalidOperationError(name, message) {
            this.name = name;
            this.message = message;
        }
        return InvalidOperationError;
    })();

    return {
        TypeNotSupportedError: TypeNotSupportedError,
        ArgumentError: ArgumentError,
        NotImplementedError: NotImplementedError,
        ArgumentOutOfRangeError: ArgumentOutOfRangeError,
        InvalidOperationError: InvalidOperationError
    };
});