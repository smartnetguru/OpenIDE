function $(callback) {
    if (callback instanceof Function) {
        plugin.AddEventListener("OnReady", callback);
    }
    else if (callback instanceof String) {
        return property(callback);
    }
}

$["on"] = function (event, callback) {
    if (event && callback) {
        plugin.AddEventListener(event, callback);
    }
}

$["each"] = function (array, callback) {
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