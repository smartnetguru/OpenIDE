///<reference path=".\Iterator.ts" />

module System.Collections {
    export class List<T> {
        private _items: Array<T>;

        constructor(arr? : Array<T>) {
            if (arr) {
                this._items = arr;
            }
            else {
                this._items = new Array<T>();
            }
        }
        clear() : void {
            this._items = new Array<T>();
        }
        add(item: T) {
            this._items.push(item);
        }
        getIterator(): System.Iterator<T> {
            return new System.Iterator<T>(this._items);
        }
    }
}