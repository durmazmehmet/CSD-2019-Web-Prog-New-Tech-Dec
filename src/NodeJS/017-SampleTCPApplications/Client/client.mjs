import net from 'net'

const port = Number(process.argv[2])
const host = process.argv[3]

process.stdout.write("Bir yazı giriniz:")

function doWorkForText(message)
{
    let socket = net.connect(port, host, () => {})

    socket.on("connect", () => socket.write(`${message}\r\n`))
    socket.on("data", data => {
        let message = data.toString()

        process.stdout.write(`(${message.trim()})`)
    })
}

process.stdin.on("readable", () => {
    for (;;) {
        let data = process.stdin.read()

        if (data == null)
            break;

        let str = data.toString().trim()

        doWorkForText(str)

        if (str === "quit")
            break

        process.stdout.write("Bir yazı giriniz:")
    }
})