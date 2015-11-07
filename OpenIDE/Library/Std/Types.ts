define("Types", [], function() {
"use strict";
var Types = (function () {
    function Types() {
    }
    return Types;
})();
// Calling an instance of this class allows for a local/private 'sealed' copy.
var Boolean = typeof true;
var Number = typeof 0;
var String = typeof "";
var Object = typeof {};
var Null = typeof null;
var Undefined = typeof undefined;
var Function = typeof isBoolean;
function isBoolean(type) {
    return typeof type === Types.Boolean;
}
function isNumber(type) {
    return typeof type === Types.Number;
}
function isString(type) {
    return typeof type === Types.String;
}
function isFunction(type) {
    return typeof type === Types.Function;
}
// Sealed class/module.
Object.freeze(Types);

    return Types
});