module System {
	export class Range {
		constructor(public min: number, public max: number) {

		}
		getEnumerator() {
			return new RangeEnumerator(this.min, this.max);
		}
		isInRange(src: number) {
			return src > this.min && src < this.max;
		}
	}
	export class RangeEnumerator {
		
		index: number;
		source: Array<any>;
		current: any;

		constructor(public min: number, public max: number) {
			this.source = [];
			this.current = this.source[this.index];
			
			for(var num = min; num < max; num++) {
				this.source.push(num);
			}
		}
		
		moveNext(): boolean {
			this.index++;
			return this.index < this.source.length;
		}
		
		reset(): void {
			this.index = -1;
		}
	}
}