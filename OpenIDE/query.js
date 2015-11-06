define("$", ["Event"], function (event) {
    function $(callback) {
        if (callback instanceof Function) {
            plugin.AddEventListener("OnReady", callback);
        }
        else if (callback instanceof String) {
            return property(callback);
        }
        else {
            //ToDo: return new event
            return new event();
        }
    }

    $["on"] = function (event, callback) {
        if (event && callback) {
            plugin.AddEventListener(event, callback);
        }
    }

    $["forEach"] = function (array, callback) {
        if (callback instanceof Function) {
            for (var i = 0; i < array.length; i++) {
                callback(array[i]);
            }
        }
        else {
            return;
        }
    }

    $["extend"] = function (defaults, options) {
        var extended = {};
        var prop;
        for (prop in defaults) {
            if (Object.prototype.hasOwnProperty.call(defaults, prop)) {
                extended[prop] = defaults[prop];
            }
        }
        for (prop in options) {
            if (Object.prototype.hasOwnProperty.call(options, prop)) {
                extended[prop] = options[prop];
            }
        }
        return extended;
    }

    return $;
});