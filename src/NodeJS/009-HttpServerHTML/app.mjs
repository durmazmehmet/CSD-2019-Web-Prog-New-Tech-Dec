import http from 'http'
import {urls} from "./urls.mjs"

function serverCallback(req, res, urls)
{
    let index = urls.findIndex(u => u.url === req.url)

    if (index !== -1)
        urls[index].callback(req, res)
    else
        notFoundNUrlCallback(req, res)
}

function notFoundNUrlCallback(req, res)
{
    res.writeHead(404, {'Content-Type': 'text/plain'})
    res.end("Not found\r\n")
}

function main()
{
    let server = http.createServer((req, res) => serverCallback(req, res, urls))
    let port = 50500

    console.log(`server is listening on port ${port}`)
    server.listen(port)
}

main()

