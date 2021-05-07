import net from 'net'
import dgram from 'dgram'
import internalIp from 'internal-ip'

let informationDgramSocket = dgram.createSocket('udp4')
let informationServer = net.createServer(socket => {
    socket.on("data", data => {
        let message = data.toString().trim()

        //...

        process.stdout.write(message)
    })
})

let tcpPort = 50500
let udpPort = 5060

process.on("uncaughtException", err => console.log(err.message))

function send(msg)
{
    informationDgramSocket.send(msg, udpPort, "192.168.1.255", err => {
        if (err)
            throw err
    })
}
process.stdout.write("TCP Server is listening\n")
informationServer.listen(tcpPort)
setInterval(() => send(`${internalIp.v4.sync()}:${tcpPort}\r\n`), 3000)


