import net from 'net'
import dgram from 'dgram'

process.on("uncaughtException", ex => console.log(ex.message))

let tcpPort = parseInt(process.argv[2])

if (isNaN(tcpPort))
    tcpPort = 60600

let udpPort = parseInt(process.argv[3])

if (isNaN(udpPort))
    udpPort = tcpPort + 1

function reportSocketCallback(msg, ri)
{
    let msgStr = msg.toString().trim()

    process.stdout.write(`Message:${msgStr} from ${ri.address}\n`)
}

function createPanicServerCallback(socket)
{
    socket.on("data", data => panicServerCallback(data, socket))
}

function panicServerCallback(data, socket)
{
    const message = data.toString().trim()

    process.stdout.write(`Message:${message}\n`)
    process.stdout.write(`There is a problem for client\n`)
    socket.end(`Do not panic!!!`)
}

const panicServer = net.createServer(createPanicServerCallback)
const dgramReportSocket = dgram.createSocket("udp4")

dgramReportSocket.on("message", reportSocketCallback)
dgramReportSocket.on("listening", () => process.stdout.write(`Report server listening on port:${udpPort}\n`))
process.stdout.write(`Panic server listening on port:${tcpPort}\n`)

dgramReportSocket.bind(udpPort)
panicServer.listen(tcpPort)











