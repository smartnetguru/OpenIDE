var System;
(function (System) {
    "use strict";
    var Types;
    (function (Types) {
        // Calling an instance of this class allows for a local/private 'sealed' copy.
        Types.Boolean = typeof true;
        Types.Number = typeof 0;
        Types.String = typeof "";
        Types.Object = typeof {};
        Types.Null = typeof null;
        Types.Undefined = typeof undefined;
        Types.Function = typeof isBoolean;
        function isBoolean(type) {
            return typeof type === Types.Boolean;
        }
        Types.isBoolean = isBoolean;
        function isNumber(type) {
            return typeof type === Types.Number;
        }
        Types.isNumber = isNumber;
        function isString(type) {
            return typeof type === Types.String;
        }
        Types.isString = isString;
        function isFunction(type) {
            return typeof type === Types.Function;
        }
        Types.isFunction = isFunction;
    })(Types = System.Types || (System.Types = {}));
    // Sealed class/module.
    Object.freeze(System.Types);
})(System || (System = {}));
