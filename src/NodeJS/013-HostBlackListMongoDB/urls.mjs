import {UrlInfo} from "./urlinfo.mjs"
import {getLocalAddressHtml, getAllIps, getBlackListIpsTable} from "./html.mjs"
import {sendHtmlTextWithStatusCode, sendHtmlSuccess} from "../modules/org-csystem-httputil.mjs"
import {IpInfo} from "./IpInfo.mjs";
import {getMongoClient} from "../modules/org-csystem-mongoutil.mjs"

const host = "192.168.1.167"
const port = 30000

function saveBlackList(ipInfo)
{
    getMongoClient(host, port).connect((err, client) => {
        if (err)
            throw err

        let ips = client.db("clientsdb").collection("ips")

        ips.insert(ipInfo, err => {if (err) throw err})
    })
}


function findByInfo(info)
{
    //TODO:
}

function blistIpsUrlCallback(req, res)
{
    let htmlData = getBlackListIpsTable(ipsInfo)

    sendHtmlSuccess(res, htmlData)
}


function ipsUrlCallback(req, res)
{
    let htmlData = getAllIps(ipsInfo)

    sendHtmlSuccess(res, htmlData)
}

function myipUrlCallback(req, res)
{
    let localAddress = req.connection.remoteAddress.substring(req.connection.remoteAddress.lastIndexOf(":") + 1)
    let ipInfo = new IpInfo(localAddress)

    //let i = ipsInfo.findIndex(info => ipInfo.ip === info.ip)

    ipInfo.count = 4
    saveBlackList(ipInfo)

    sendHtmlTextWithStatusCode(500, res, "You are in black list")

    /*
    if (i !== -1) {
        let info = ipsInfo[i]

        if (info.isInBlackList)
            sendHtmlTextWithStatusCode(500, res, "You are in black list")
        else
            sendHtmlSuccess(res, getLocalAddressHtml(localAddress))

        info.count = info.count + 1
    }
    else {
        ipsInfo.push(ipInfo)
        sendHtmlSuccess(res, getLocalAddressHtml(localAddress))
    }

     */
}

export let urls = [
    new UrlInfo("/myip", myipUrlCallback),
    new UrlInfo("/ips", ipsUrlCallback),
    new UrlInfo("/blistips", blistIpsUrlCallback)
]

