import {initServer} from "./initserver.mjs"

process.on("uncaughtException", ex => console.log(ex.message))

initServer()

