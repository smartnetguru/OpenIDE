module System {
	export class Enum {
		constructor() {
			var obj = {};

			for (var i = 0; i < arguments.length; i++) {
				obj[arguments[i]] = i;
			}

			Object.freeze(obj);

			return obj;
		}
		static contains(sym : Symbol) {
			return this[sym.name] === sym;
		}
		static parse(src : string) {
			if (typeof src == "string") {
				var splitted = src.split(",").map(function (item) { return item.trim() });

				return Enum.apply({}, splitted);
			}
		}
		static toString(obj) {
			var result = "";
			for (var i in obj) {
				result += i + ", ";
			}

			result = result.substring(0, result.length - 2);

			return result;
		}
	}
}