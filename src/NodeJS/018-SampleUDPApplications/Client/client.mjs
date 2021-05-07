import dgram from 'dgram'

const port = parseInt(process.argv[2])
const host = process.argv[3]
const client = dgram.createSocket("udp4")

function sendMessage(message)
{
    client.send(message, port, host, err => {
        if (err)
            console.log(err.message)
    })
}

setInterval(() => sendMessage("OK\r\n"), 700)

