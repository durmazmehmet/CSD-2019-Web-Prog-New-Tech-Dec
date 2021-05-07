import {loginHtml, saveHtml, failHtml, successHtml, registerHtml, pageNotFoundHtml} from "./readhtmls.mjs";
import {sendHtmlSuccess, sendHtml404} from "../modules/org-csystem-httputil.mjs"
import {serverPort} from "./global.mjs";
import express from "express"
import bodyParser from "body-parser"
import {UserInfo} from "./UserInfo.mjs";
import {loginUserInfo, saveUserInfo} from "./dbhelper.mjs";

const app = express()

function areDefined()
{
    for (let arg of arguments)
        if (arg === undefined)
            return false
    return true
}

function loginProc(req, res)
{
    let str = "";
    let username = req.body.name
    let email = req.body.email

    console.log("login:")
    console.log(`username:${username}`)
    console.log(`email:${email}`)

    if (!areDefined(username, email)) {
        sendHtml404(res, "Invalid access")
        return;
    }

    loginUserInfo(new UserInfo(username, email), res)
}

function registerProc(req, res)
{
    let str = "";
    let username = req.body.name
    let email = req.body.email

    console.log("register:")
    console.log(`username:${username}`)
    console.log(`email:${email}`)

    if (!areDefined(username, email)) {
        sendHtml404(res, "Invalid access")
        return;
    }

    saveUserInfo(new UserInfo(username, email), res)
}

function saveProc(req, res)
{
    //TODO:
}



function initServer()
{
    console.log("server is listening")
    app.get("/", (req, res) => sendHtmlSuccess(res, loginHtml))
    app.get("/login", (req, res) => sendHtmlSuccess(res, loginHtml))
    app.get("/register", (req, res) => sendHtmlSuccess(res, registerHtml))
    app.get("/save", (req, res) => sendHtmlSuccess(res, saveHtml))
    app.use(bodyParser.urlencoded({extended:false}))
    app.post("/login", (req, res) => loginProc(req,res))
    app.post("/register", (req, res) => registerProc(req,res))
    app.post("/save", (req, res) => saveProc(req,res))
    app.use((req, res) => sendHtml404(res, pageNotFoundHtml))
    app.listen(serverPort)
}

export {initServer}