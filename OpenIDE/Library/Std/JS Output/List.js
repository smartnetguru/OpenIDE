///<reference path=".\Iterator.ts" />
var System;
(function (System) {
    var Collections;
    (function (Collections) {
        var List = (function () {
            function List(arr) {
                if (arr) {
                    this._items = arr;
                }
                else {
                    this._items = new Array();
                }
            }
            List.prototype.clear = function () {
                this._items = new Array();
            };
            List.prototype.add = function (item) {
                this._items.push(item);
            };
            List.prototype.getIterator = function () {
                return new System.Iterator(this._items);
            };
            return List;
        })();
        Collections.List = List;
    })(Collections = System.Collections || (System.Collections = {}));
})(System || (System = {}));