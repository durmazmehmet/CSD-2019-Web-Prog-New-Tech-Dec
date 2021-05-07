import random from "../modules/org-csystem-random.js"
import numberUtil from "../modules/org-csystem-numberUtil.js"
import EventEmitter from "events"

import terminal from "../modules/org-csystem-terminal.js"

export class RandomNumberEmitter extends EventEmitter {
    constructor(min, max, interval)
    {
        super()
        this._min = min;
        this._max = max
        this._interval = interval
    }

    start()
    {
        setInterval(() => {
            let val = random.nextInt(this._min, this._max)

            terminal.writeLine(`RandomNumberEmitter:val=${val}`)
            this.emit("value", val)

            if (numberUtil.isPrime(val))
                this.emit("prime", val)
            else if (val % 2 === 0)
                this.emit("even", val)
            else
                this.emit("odd", val)
        }, this._interval)
    }
}