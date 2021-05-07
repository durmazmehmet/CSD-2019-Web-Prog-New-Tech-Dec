import net from 'net'

process.on("uncaughtException", err => console.log(err.message))

let port = Number(process.argv[2])

if (isNaN(port))
    port = 60600

const server = net.createServer(socket => {
    socket.on("data", data => {
        let message = data.toString().trim()

        process.stdout.write(`data:${data}`)

        socket.write(`${message.toUpperCase()}\r\n`)
        socket.destroy()
    })

    socket.on("close", () => console.log("Client disconnected"))
})

server.listen(port)

process.stdout.write(`Server is waiting for a client on port:${port}`)
