import {UrlInfo} from "./urlinfo.mjs"
import {getLocalAddressHtml, getAllIps, getBlackListIpsTable} from "./html.mjs"
import {sendHtmlTextWithStatusCode, sendHtmlSuccess} from "../modules/httputil.mjs"
import {IpInfo} from "./IpInfo.mjs";



let ipsInfo = []


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

    let i = ipsInfo.findIndex(info => ipInfo.ip === info.ip)

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
}

export let urls = [
    new UrlInfo("/myip", myipUrlCallback),
    new UrlInfo("/ips", ipsUrlCallback),
    new UrlInfo("/blistips", blistIpsUrlCallback)
]

