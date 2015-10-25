var System = System || {};

System.Type = {
    String: typeof "f",
    Number: typeof 123,
    Undefined: typeof undefined,
    getType: function (obj) {
        return typeof obj;
    }
}