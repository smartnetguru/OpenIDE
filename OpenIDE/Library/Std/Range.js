define("Range", [], function () {
    var Range = (function () {
        function Range(min, max) {
            this.min = min;
            this.max = max;
            this.__iterator__ = function () {
                return new RangeEnumerator(this.min, this.max);
            };
        }
        Range.prototype.isInRange = function (src) {
            return src > this.min && src < this.max;
        };
        return Range;
    })();
    var RangeEnumerator = (function () {
        function RangeEnumerator(min, max) {
            this.min = min;
            this.max = max;
            this.source = [];
            this.current = this.source[this.index];
            for (var num = min; num < max; num++) {
                this.source.push(num);
            }
        }
        RangeEnumerator.prototype.moveNext = function () {
            this.index++;
            return this.index < this.source.length;
        };
        RangeEnumerator.prototype.reset = function () {
            this.index = -1;
        };
        return RangeEnumerator;
    })();

    return Range;
});