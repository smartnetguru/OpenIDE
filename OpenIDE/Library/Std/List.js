define("List", [], function () {
    var List = (function () {
        var items = [];

        function List(arr) {
            if (arr) {
                _items = arr;
            }
            else {
                _items = new Array();
            }
        }
        List.prototype.clear = function () {
            _items = new Array();
        };
        List.prototype.add = function (item) {
            _items.push(item);
        };
        List.prototype.get = function (index) {
            return _items[index];
        };


        return List;
    })();

    return List;
});