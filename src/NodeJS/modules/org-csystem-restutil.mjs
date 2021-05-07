import fs from "fs"

function sendJSONWithStatusCode(code, res, obj)
{
    res.writeHead(code, {'Content-Type': 'application/json'})
    res.end(`${JSON.stringify(obj)}\r\n`)
}

function sendJSONSuccess(res, obj)
{
    sendJSONWithStatusCode(200, res, obj)
}

function sendJSON404(res, obj)
{
    sendJSONWithStatusCode(404, res, obj)
}

function sendJSON500(res, msg)
{
    sendJSONWithStatusCode(500, res, obj)
}

//...

function receiveJSON(json)
{
    return JSON.parse(json)
}

export {sendJSONWithStatusCode, sendJSONSuccess, sendJSON404, sendJSON500}