import {UrlInfo} from "./urlinfo.mjs";
import random from "../modules/org-csystem-random.js"

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

function randomUrlCallback(req, res)
{
    let val = random.nextInt(1, 100)

    res.writeHead(200, {'Content-Type': 'text/plain'})

    res.end(`${val}\r\n`)
}

function myipUrlCallback(req, res)
{
    let val = random.nextInt(1, 100)

    res.writeHead(200, {'Content-Type': 'text/plain'})

    let localAddress = req.connection.remoteAddress.substring(req.connection.remoteAddress.lastIndexOf(":") + 1)

    res.end(`Your local address:${localAddress}\r\n`)
}

export let urls = [
    new UrlInfo("/", rootUrlCallback),
    new UrlInfo("/hello-tr", helloTRUrlCallback),
    new UrlInfo("/hello-en", helloENUrlCallback),
    new UrlInfo("/random", randomUrlCallback),
    new UrlInfo("/myip", myipUrlCallback),
]

