// <reference path=".\Iterator.ts" />

module System.Collections {
    export class Dictionary<TKey, TValue> {
        private _items : Array<KeyValuePair<TKey, TValue>>;

        constructor(data?: Array<KeyValuePair<TKey, TValue>>) {
            if (data) {
                this._items = data;
            }
            else {
                this._items = new Array<KeyValuePair<TKey, TValue>>();
            }
        }

        get count() {return this._items.length;}

        clear(): void {
            this._items = new Array<KeyValuePair<TKey, TValue>>();
        }
        add(key: TKey, value: TValue) {
            this._items.push(new KeyValuePair<TKey, TValue>(key, value));
        }
        removeAt(index: number) {
            this._items.splice(index, 1);
        }
        getValue(key: TKey) : TValue{
            for (var i = 0; i < this._items.length; i++) {
                if (this._items[i].key == key) return this._items[i].value;
            }

            return undefined;
        }
        containsKey(key : TKey) {
            for (var i = 0; i < this._items.length; i++) {
                if (this._items[i].key == key) return true;
            }

            return false;
        }
        __iterator__: System.Iterator {
            return new System.Iterator(this._items);
        }
    }

    export class KeyValuePair<TKey, TValue> {
        key: TKey;
        value: TValue;

        constructor(key : TKey, value : TValue) {
            this.key = key;
            this.value = value;
        }
    }
}