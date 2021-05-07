import net from 'net'
import dgram from 'dgram'

let informationDgramSocket = dgram.createSocket("udp4")
let serverHost = ""
let serverPort = 1024

process.on("uncaughtException", err => console.log(err.message))

informationDgramSocket.on('message', (msg, ri) => {
    let info = msg.toString().trim()

    info = info.split(':')

    serverHost = info[0];
    serverPort = parseInt(info[1])

    process.stdout.write(`Host:${serverHost}\n`)
    process.stdout.write(`Port:${serverPort}\n`)
    sendMessage("Merhaba\n")
})

function sendMessage(msg)
{
    let socket = net.connect(serverPort, serverHost, () =>{ })

    socket.on('connect', () => {
        socket.end(`${msg}\r\n`)
        socket.destroy()
    })
}


informationDgramSocket.bind(5060)