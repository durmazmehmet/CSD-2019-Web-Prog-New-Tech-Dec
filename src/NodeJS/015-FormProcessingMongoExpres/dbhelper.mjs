import {collectionName, dbName, mongoHost, mongoPort} from "./global.mjs";
import {sendHtml500, sendHtmlSuccess} from "../modules/org-csystem-httputil.mjs"
import {successHtml, userFoundHtml, userNotFoundHtml} from "./readhtmls.mjs";
import {getMongoClient} from "../modules/org-csystem-mongoutil.mjs"

function registerDBProc(err, client, userInfo, res)
{
    if (err)
        throw err

    let users = client.db(dbName).collection(collectionName)

    users.find(userInfo).toArray((err, docs) => {
        if (err)
            throw  err

        if (!docs.length) {
            users.insert(userInfo)
            sendHtmlSuccess(res, successHtml)
        }
        else
            sendHtml500(res, userFoundHtml)
    })
}

function loginDBProc(err, client, userInfo, res)
{
    if (err)
        throw err

    let users = client.db(dbName).collection(collectionName)

    users.find(userInfo).toArray((err, docs) => {
        if (err)
            throw  err

        if (docs.length)
            sendHtmlSuccess(res, successHtml)
        else
            sendHtml500(res, userNotFoundHtml)
    })
}

function saveUserInfo(userInfo, res)
{
    getMongoClient(mongoHost, mongoPort).connect((err, client) => registerDBProc(err, client, userInfo, res))
}

function loginUserInfo(userInfo, res)
{
    getMongoClient(mongoHost, mongoPort).connect((err, client) => loginDBProc(err, client, userInfo, res))
}

export {saveUserInfo, loginUserInfo}
