import terminal from "../modules/org-csystem-terminal.js"
import EventEmitter from "events"

export class LocalDateEmitter extends EventEmitter {
    start()
    {
        setInterval(() => {
            let now = new Date()

            terminal.writeLine(`${now.getDate()}.${now.getMonth() + 1}.${now.getFullYear()} ${now.getHours()}:${now.getMinutes()}:${now.getSeconds()}`)
            this.emit("now", now)
        }, 1000)
    }
}
