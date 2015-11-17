$.define("Dictionary", function () {
    var Dictionary = (function () {
        function Dictionary(data) {
            if (data) {
                this._items = data;
            }
            else {
                this._items = new Array();
            }
        }
        Object.defineProperty(Dictionary.prototype, "count", {
            get: function () { return this._items.length; },
            enumerable: true,
            configurable: true
        });
        Dictionary.prototype.clear = function () {
            this._items = new Array();
        };
        Dictionary.prototype.add = function (key, value) {
            this._items.push(new KeyValuePair(key, value));
        };
        Dictionary.prototype.removeAt = function (index) {
            this._items.splice(index, 1);
        };
        Dictionary.prototype.getValue = function (key) {
            for (var i = 0; i < this._items.length; i++) {
                if (this._items[i].key == key)
                    return this._items[i].value;
            }
            return undefined;
        };
        Dictionary.prototype.containsKey = function (key) {
            for (var i = 0; i < this._items.length; i++) {
                if (this._items[i].key == key)
                    return true;
            }
            return false;
        };
        return Dictionary;
    })();

    return Dictionary;
});