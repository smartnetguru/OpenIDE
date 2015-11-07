define("Enum", [], function () {
    var Enum = (function () {
        function Enum() {
            var obj = {};
            for (var i = 0; i < arguments.length; i++) {
                obj[arguments[i]] = i;
            }
            Object.freeze(obj);
            return obj;
        }
        Enum.contains = function (sym) {
            return this[sym.name] === sym;
        };
        Enum.parse = function (src) {
            if (typeof src == "string") {
                var splitted = src.split(",").map(function (item) { return item.trim(); });
                return Enum.apply({}, splitted);
            }
        };
        Enum.toString = function (obj) {
            var result = "";
            for (var i in obj) {
                result += i + ", ";
            }
            result = result.substring(0, result.length - 2);
            return result;
        };
        return Enum;
    })();

    return Enum;
});