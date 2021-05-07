import net from 'net'
import nutil from "../../modules/org-csystem-numberUtil.js"
import {commands, CommandInfo} from "./CommandInfo.mjs";

let endLine = "\r\n"

process.on("uncaughtException", err => console.log(err.message))

function parseCommand(msg, socket)
{
    let errMsg = 'F@'
    let successMsg = 'S@'
    let result = 0

    try {
        let cmdInfo = msg.split(" ")

        if (cmdInfo.length !== 3) {
            socket.write(`${errMsg}Wrong number of arguments${endLine}`)
            return
        }

        let index = commands.findIndex(c => cmdInfo[0] === c.cmd)

        if (index === -1) {
            socket.write(`${errMsg}Invalid Command${endLine}`)
            return
        }

        if (!nutil.isNumber(cmdInfo[1]) || !nutil.isNumber(cmdInfo[2])) {
            socket.write(`${errMsg}Invalid arguments${endLine}`)
            return
        }

        let a = parseFloat(cmdInfo[1])
        let b = parseFloat(cmdInfo[2])

        result = commands[index].callback(a, b)

        socket.write(`${successMsg}${result}${endLine}`)
    }
    catch (err) {
        socket.write(errMsg)
    }
}

let server = net.createServer(socket => {
    socket.on("data", data => {
        let msg = data.toString().trim()

        console.log(`Message:${msg}`)

        if (msg !== "quit")
            parseCommand(msg, socket)
        else
            socket.destroy()
    })
})
process.stdout.write(`Operation Server is listening${endLine}`)
server.listen(5056)
