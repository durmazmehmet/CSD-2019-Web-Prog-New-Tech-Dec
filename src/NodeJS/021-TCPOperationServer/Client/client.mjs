import net from "net"

let host = process.argv[2]
let port = parseInt(process.argv[3])

process.on("uncaughtException", err => console.log(err.message))

let socket = net.connect(port, host, () => {
    socket.on("data", data => {
        let msg = data.toString().trim()
        let msgInfo = msg.split("@")

        if (msgInfo[0] === 'S')
            process.stdout.write(`Sonuç:${msgInfo[1]}`)
        else
            process.stdout.write(`Hata Mesajı:${msgInfo[1]}`)
    })
})

socket.on("connect", () => {
    process.stdin.on("readable", () => {
        while (1) {
            process.stdout.write("Komutu Giriniz:")
            let command = process.stdin.read()

            if (command == null)
                return

            socket.write(`${command}\r\n`)

            if (command.toString().trim() === "quit") {
                socket.destroy()
                break
            }
        }
    })
})

