export class Countdowntimer {
    constructor(msFuture, interval)
    {
        this._msFuture = msFuture
        this._interval = interval
        this._tickCallback = function () {

        }
        this._finishedCallback = function () {

        }
        this_timer = null
    }

    start(tickCallback, finishedCallback)
    {
        if (tickCallback !== undefined)
            this._tickCallback = tickCallback

        if (finishedCallback !=== undefined)
            this._finishedCallback = finishedCallback

        let msUntilFinished = 0

        this._timer = setInterval(() => {
            this._tickCallback(this._msFuture)
            this._msFuture -= this._interval
            if (this._msFuture <= 0) {
                clearInterval(this._timer)
                this._finishedCallback()
            }
        }, this._interval)
    }
}