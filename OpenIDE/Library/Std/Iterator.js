$.define("Iterator", [], function () {
    var Iterator = (function () {
        function Iterator(items) {
            this.index = 0;
            this.items = items;
        }
        Iterator.prototype.first = function () {
            this.reset();
            return this.next();
        };
        Iterator.prototype.next = function () {
            if (!this.hasNext()) {
                return;
            }
            return this.items[this.index++];
        };
        Iterator.prototype.hasNext = function () {
            return this.index <= this.items.length;
        };
        Iterator.prototype.reset = function () {
            this.index = 0;
        };
        Iterator.prototype.each = function (callback) {
            for (var item = this.first() ; this.hasNext() ; item = this.next()) {
                callback(item);
            }
        };
        return Iterator;
    })();

    return Iterator;
});