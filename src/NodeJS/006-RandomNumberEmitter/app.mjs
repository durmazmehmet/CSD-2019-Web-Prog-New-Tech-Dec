import {RandomNumberEmitter} from "./randomnumberemitter.mjs"
import terminal from "../modules/org-csystem-terminal.js"

function main()
{
    let randomNumberEmitter = new RandomNumberEmitter(1, 100, 1000)

    randomNumberEmitter.start()
    randomNumberEmitter.on("prime", n => terminal.writeLine(`prime listener:p=${n}`))
    randomNumberEmitter.on("even", n => terminal.writeLine(`even listener:p=${n}`))
    randomNumberEmitter.on("odd", n => terminal.writeLine(`odd listener:p=${n}`))
    terminal.writeLine("main sonu")
}

main()