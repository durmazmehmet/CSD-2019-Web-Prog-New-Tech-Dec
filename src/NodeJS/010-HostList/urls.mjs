import {UrlInfo} from "./urlinfo.mjs"
import {getLocalAddressHtml, getAllIps} from "./html.mjs"
import {sendHtmlTextWithStatusCode, sendHtmlSuccess} from "../modules/httputil.mjs"
import {IpInfo} from "./IpInfo.mjs";

let ipsInfo = []


function ipsUrlCallback(req, res)
{
    let htmlData = getAllIps(ipsInfo)

    sendHtmlSuccess(res, htmlData)
}

function myipUrlCallback(req, res)
{
    let localAddress = req.connection.remoteAddress.substring(req.connection.remoteAddress.lastIndexOf(":") + 1)
    let ipInfo = new IpInfo(localAddress)

    ipsInfo.push(ipInfo)
    sendHtmlSuccess(res, getLocalAddressHtml(localAddress))
}

export let urls = [
    new UrlInfo("/myip", myipUrlCallback),
    new UrlInfo("/ips", ipsUrlCallback),
]

