import terminal from "../modules/org-csystem-terminal.js"
import {LocalDateEmitter} from "./localdatetimeemitter.mjs"

function main()
{
    let localDateEmitter = new LocalDateEmitter();

    localDateEmitter.start()
    localDateEmitter.on("now", now => terminal.writeLine(`Now1:${now}`))
    localDateEmitter.on("now", now => terminal.writeLine(`Now2:${now}`))
}

main()
