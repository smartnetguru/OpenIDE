var observers = [];

var events = {
    subscribe: function(event, callback) {
        this.observers.push({ Event: event, Callback: callback });
    },
    unsubsribe: function (event, callback) {
        this.observers.splice(this.observers.indexOf({ Event: event, Callback: callback }), 1);
    },
    fire: function (name, arg) {
        this.observers.forEach(function(value, index, obj) {
            if (value.Event == name) {
                value.Callback(arg);
            }
        });
    }
};