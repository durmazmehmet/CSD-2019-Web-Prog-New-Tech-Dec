import dgram from 'dgram'

process.on("uncaughtException", ex => console.log(ex.message))
let port = parseInt(process.argv[2])

if (isNaN(port))
    port = 60600

const server = dgram.createSocket("udp4")

server.on("message", (msg, ri) => {
    process.stdout.write(`Address:${ri.address}\n`)
    let msgStr = msg.toString()

    process.stdout.write(`Length:${msgStr.length}, Message:${msgStr}\n`)
})

server.on("listening", () => process.stdout.write(`UDP listening on port:${port}`))
server.bind(port)





