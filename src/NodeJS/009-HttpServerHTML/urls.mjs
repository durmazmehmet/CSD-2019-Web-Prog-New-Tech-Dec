import {UrlInfo} from "./urlinfo.mjs"
import random from "../modules/org-csystem-random.js"
import {helloTR, helloEN, getLocalAddressHtml, getRandomNumberHtml} from "./html.mjs"

function rootUrlCallback(req, res)
{
    res.writeHead(200, {'Content-Type': 'text/html'})
    res.end("Main url\r\n")
}

function helloTRUrlCallback(req, res)
{
    res.writeHead(200, {'Content-Type': 'text/html'})
    res.end(helloTR)
}

function helloENUrlCallback(req, res)
{
    res.writeHead(200, {'Content-Type': 'text/html'})
    res.end(helloEN)
}

function randomUrlCallback(req, res)
{
    let val = random.nextInt(1, 100)

    res.writeHead(200, {'Content-Type': 'text/html'})

   res.end(getRandomNumberHtml(val))
}

function myipUrlCallback(req, res)
{
    res.writeHead(200, {'Content-Type': 'text/html'})

    let localAddress = req.connection.remoteAddress.substring(req.connection.remoteAddress.lastIndexOf(":") + 1)

    res.end(getLocalAddressHtml(localAddress))
}

export let urls = [
    new UrlInfo("/", rootUrlCallback),
    new UrlInfo("/hello-tr", helloTRUrlCallback),
    new UrlInfo("/hello-en", helloENUrlCallback),
    new UrlInfo("/random", randomUrlCallback),
    new UrlInfo("/myip", myipUrlCallback),
]

