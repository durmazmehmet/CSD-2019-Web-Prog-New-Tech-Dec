import net from 'net'

const port = Number(process.argv[2])
const host = process.argv[3]

function connectionCallback()
{
    process.stdin.pipe(socket)
    socket.pipe(process.stdout)
    process.stdin.resume()
}

let socket = net.connect(port, host, () => process.stdout.write("Client connected"))

socket.on("connect", connectionCallback)