import {loginHtml, registerHtml, successHtml} from "./readhtmls.mjs";
import http from "http"
import querystring from "querystring"
import {sendHtmlSuccess} from "../modules/org-csystem-httputil.mjs"
import {getMongoClient} from "../modules/org-csystem-mongoutil.mjs"
import {Userinfo} from "./userinfo.mjs"

const mongoHost = "192.168.1.167"
const mongoPort = 30000
const dbName = "companydb"
const collectionName = "users"

process.on("uncaughtException", err => console.log(err.message))

function loginCallback(req, res)
{
    //TODO:
    let message = ""

    req.once("data", chunk => {
        let rawData = chunk.toString()

        console.log(`Raw Data:${rawData}`)

        let loginInfo = querystring.parse(rawData)

        console.log(`Name:${loginInfo.name}, Email:${loginInfo.email}`)

        message += `<h1>${loginInfo.name}</h1>`
        message += `<h1>${loginInfo.email}</h1>`
    })

    req.once("end", () => sendHtmlSuccess(res, message))
}

function registerCallback(req, res)
{
    let message = ""

    req.once("data", chunk => {
        let rawData = chunk.toString()

        console.log(`Raw Data:${rawData}`)

        let loginInfo = querystring.parse(rawData)

        let userInfo = new Userinfo(loginInfo.name, loginInfo.email)
        getMongoClient(mongoHost, mongoPort).connect((err, client) => {
            if (err)
                throw err

            let users = client.db(dbName).collection(collectionName)

            users.insertOne(userInfo, err => {
                if (err)
                    throw err
            })
        })

        console.log(`Name:${loginInfo.name}, Email:${loginInfo.email}`)

        message += `<h1>${loginInfo.name}</h1>`
        message += `<h1>${loginInfo.email}</h1>`
    })

    req.once("end", () => sendHtmlSuccess(res, message))
}

function doGet(req, res)
{
    switch (req.url) {
        case "/login":
            sendHtmlSuccess(res, loginHtml)
            break;
        case "/register":
            sendHtmlSuccess(res, registerHtml)
            break;
    }
}

function doPost(req, res)
{
    switch (req.url) {
        case "/login":
            loginCallback(req, res)
            break;
        case "/register":
            registerCallback(req, res)
            break;
    }
}

function main()
{
    let server = http.createServer((req, res) => {
        if (req.method === "GET")
            doGet(req, res)
        else
            doPost(req, res)
    })

    server.listen(50500)

}

main()