$.define("Tuple", ["Class"], function (Class) {
    return new Class({
        construct: function (/* values */) {
            var args = Array.prototype.slice.call(arguments, 0);
            this._store = new Array(args.length);
            this.pack.apply(this, args);
        },
        methods: {
            pack: function (/* values */) {
                var store = this._store;
                var i = store.length;

                while (i--) {
                    store[i] = arguments[i];
                }

                return this;
            },
            unpack: function (callback) {
                return callback.apply(this, this._store);
            },
            toString: function () {
                return ['(', this._store.join(', '), ')'].join('');
            },
            valueOf: function () {
                var store = this._store;
                var storeLength = store.length;
                var total = store[0];
                var i;

                for (i = 1; i < storeLength; i += 1) {
                    total += store[i];
                }

                return total;
            }
        }
    });
});