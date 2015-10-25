module System {
	export class Iterator<T> {
		private index: number;
		private items: Array<T>;
		
		constructor(items : Array<T>) {
			this.index = 0;
			this.items = items;
		}
		
		first() : T {
			this.reset();
			return this.next();
		}
		next() : T {
			if (!this.hasNext()) { return; }

			return this.items[this.index++];
		}
		hasNext() {
			return this.index <= this.items.length;
		}
		reset() {
			this.index = 0;
		}
		each(callback : Function) {
			for(var item = this.first(); this.hasNext(); item = this.next()) {
				callback(item);
			}
		}
	}
}