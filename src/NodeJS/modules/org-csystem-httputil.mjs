import fs from "fs"

function sendHtmlTextWithStatusCode(code, res, msg)
{
    res.writeHead(code, {'Content-Type': 'text/html'})
    res.end(`${msg}\r\n`)
}

function sendPlainTextWithStatusCode(code, res, msg)
{
    res.writeHead(code, {'Content-Type': 'text/plain'})
    res.end(`${msg}\r\n`)
}

function sendHtmlSuccess(res, msg)
{
    sendHtmlTextWithStatusCode(200, res, msg)
}

function sendHtml404(res, msg)
{
    sendHtmlTextWithStatusCode(404, res, msg)
}

function sendHtml500(res, msg)
{
    sendHtmlTextWithStatusCode(500, res, msg)
}

function sendPlainSuccess(res, msg)
{
    sendHtmlTextWithStatusCode(200, res, msg)
}

export {sendHtmlTextWithStatusCode, sendPlainTextWithStatusCode, sendHtmlSuccess, sendHtml404, sendHtml500, sendPlainSuccess}