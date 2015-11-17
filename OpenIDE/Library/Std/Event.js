$.define("Event", function () {
    function Event() {
        this._list = [];
    }

    // this method will handle adding observers to the internal list
    Event.prototype.observe = function (obj) {
        console.log('added new observer');
        this._list.push(obj);
    };

    Event.prototype.unobserve = function (obj) {
        for (var i = 0, len = this._list.length; i < len; i++) {
            if (this._list[i] === obj) {
                this._list.splice(i, 1);
                console.log('removed existing observer');
                return true;
            }
        }
        return false;
    };

    Event.prototype.notify = function () {
        var args = Array.prototype.slice.call(arguments, 0);
        for (var i = 0, len = this._list.length; i < len; i++) {
            this._list[i].update.apply(null, args);
        }
    };

    return Event;
});