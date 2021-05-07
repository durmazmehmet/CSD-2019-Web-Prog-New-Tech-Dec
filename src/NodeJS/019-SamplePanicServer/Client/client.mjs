import dgram from 'dgram'
import net from 'net'

const tcpPort = parseInt(process.argv[2])
const udpPort = parseInt(process.argv[3])
const host = process.argv[4]
const client = dgram.createSocket("udp4")

function sendReportMessage(message)
{
    client.send(message, udpPort, host, err => {
        if (err)
            console.log(err.message)
    })
}

function sendPanicMessage(msg)
{
    const socket = net.connect(tcpPort, host,() => process.stdout.write("connected to panic server\n"))
    socket.on("connect", () => socket.write(`${msg}\r\n`))
    socket.on("data", data => process.stdout.write(`Message:${data.toString().trim()}\n`))
}

let interval = setInterval(() => sendReportMessage("OK\r\n"), 1000)
setTimeout(() => {
    sendPanicMessage("Panic!!!!!!!!")
    clearInterval(interval)
}, 10000)

