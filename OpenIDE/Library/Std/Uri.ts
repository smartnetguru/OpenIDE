var System = System || {};

System.Uri = new System.Class({
    construct: function(src) {
        function parseUri(str, obj) {
            var o = parseUri.options,
                m = o.parser[o.strictMode ? "strict" : "loose"].exec(str),
                uri = obj,
                i = 14;

            while (i--) uri[o.key[i]] = m[i] || "";

            uri[o.q.name] = {};
            uri[o.key[12]].replace(o.q.parser, function ($0, $1, $2) {
                if ($1) uri[o.q.name][$1] = $2;
            });

            return uri;
        };

        parseUri.options = {
            strictMode: false,
            key: ["source", "scheme", "authority", "userInfo", "user", "password", "host", "port", "relative", "path", "directory", "file", "query", "anchor"],
            q: {
                name: "queryKey",
                parser: /(?:^|&)([^&=]*)=?([^&]*)/g
            },
            parser: {
                strict: /^(?:([^:\/?#]+):)?(?:\/\/((?:(([^:@]*)(?::([^:@]*))?)?@)?([^:\/?#]*)(?::(\d*))?))?((((?:[^?#\/]*\/)*)([^?#]*))(?:\?([^#]*))?(?:#(.*))?)/,
                loose: /^(?:(?![^:@]+:[^:@\/]*@)([^:\/?#.]+):)?(?:\/\/)?((?:(([^:@]*)(?::([^:@]*))?)?@)?([^:\/?#]*)(?::(\d*))?)(((\/(?:[^?#](?![^?#\/]*\.[^?#\/.]+(?:[?#]|$)))*\/?)?([^?#\/]*))(?:\?([^#]*))?(?:#(.*))?)/
            }
        };

        parseUri(src, this);
    },
    props: {
        source: undefined,
        scheme: undefined,
        authority: undefined,
        userInfo: undefined,
        user: undefined,
        pass: undefined,
        host: undefined,
        port: undefined,
        relative: undefined,
        path: undefined,
        directory: undefined,
        file: undefined,
        query: undefined,
        fragment: undefined
    },
    methods: {
        toString: function() {
            var result = this.scheme + "://";
            if (this.userInfo) {
                result += this.user + ":" + this.pass;
            }
            if (this.host) result += this.host;
            if (this.port) result += ":" + this.port;
            if (this.directory) result += this.directory + "/";
            if (this.file) result += this.file;
            if (this.query) result += "?" + this.query;

            return result;
        }
    }
});
