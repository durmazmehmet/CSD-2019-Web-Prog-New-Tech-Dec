import http from 'http'
import terminal from '../modules/org-csystem-terminal.js'


function rootUrlCallback(req, res)
{
    res.writeHead(200, {'Content-Type': 'text/plain'})
    res.end("Main url\r\n")
}

function helloTRUrlCallback(req, res)
{
    res.writeHead(200, {'Content-Type': 'text/plain'})
    res.end("Merhaba\r\n")
}

function helloENUrlCallback(req, res)
{
    res.writeHead(200, {'Content-Type': 'text/plain'})
    res.end("Hello\r\n")
}

function notFoundNUrlCallback(req, res)
{
    res.writeHead(404, {'Content-Type': 'text/plain'})
    res.end("Not found\r\n")
}



function serverCallback(req, res)
{
    terminal.writeLine(`url:${req.url}`)
    switch (req.url) {
        case "/":
            rootUrlCallback(req, res)
            break
        case "/hello-tr":
            helloTRUrlCallback(req, res)
            break
        case "/hello-en":
            helloENUrlCallback(req, res)
            break
        default:
            notFoundNUrlCallback(req, res)
    }
}


function main()
{
    let server = http.createServer(serverCallback)
    let port = 50500

    console.log(`server is listening on port ${port}`)
    server.listen(port)
}

main()

