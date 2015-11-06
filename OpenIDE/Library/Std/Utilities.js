define("Utils", function () {
    function print_r(obj, t) {
        // define tab spacing
        var tab = t || '';

        // check if it's array
        var isArr = Object.prototype.toString.call(obj) === '[object Array]';

        // use {} for object, [] for array
        var str = isArr ? ('Array\n' + tab + '[\n') : ('Object\n' + tab + '{\n');

        // walk through it's properties
        for (var prop in obj) {
            if (obj.hasOwnProperty(prop)) {
                var val1 = obj[prop];
                var val2 = '';
                var type = Object.prototype.toString.call(val1);
                switch (type) {

                    // recursive if object/array
                    case '[object Array]':
                    case '[object Object]':
                        val2 = System.Utilities.print_r(val1, (tab + '\t'));
                        break;

                    case '[object String]':
                        val2 = '\'' + val1 + '\'';
                        break;

                    default:
                        val2 = val1;
                }
                str += tab + '\t' + prop + ' => ' + val2 + ',\n';
            }
        }

        // remove extra comma for last property
        str = str.substring(0, str.length - 2) + '\n' + tab;

        return isArr ? (str + ']') : (str + '}');
    }

    function namespace(name, separator, container) {
        var ns = name.split(separator || '.'),
            o = container || window,
            i,
            len;
        for (i = 0, len = ns.length; i < len; i++) {
            o = o[ns[i]] = o[ns[i]] || {};
        }
        return o;
    }

    return {
        "print_r": print_r,
        "namespace": namespace
    };
});