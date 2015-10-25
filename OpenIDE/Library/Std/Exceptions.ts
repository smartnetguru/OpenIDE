module System {
    export class TypeNotSupportedError implements Error {
        constructor(public name?: string, public message?: string) {
        }
    }
    export class ArgumentError implements Error {
        constructor(public name?: string, public message?: string) {
        }
    }
    export class NotImplementedError implements Error {
        constructor(public name?: string, public message?: string) {
        }
    }
    export class ArgumentOutOfRangeError implements Error {
        constructor(public name?: string, public message?: string) {
        }
    }
    export class InvalidOperationError implements Error {
        constructor(public name?: string, public message?: string) {
        }
    }
}