/*
    Sınıf Çalışması: myip url bilgisi ile alınan ip adreslerini bir diziye kaydeden ve ips bilgisi ile sorgulanan
    ip leri bir tablo ile html gönderen programı yazınız. Kayıtlar sorgulama zamanı ile birlikte tutulacaktır.
    Örnek tablo:

    <table>
        <tr>
            <th>IP Adresi</th>
            <th>Sorgulama zamanı</th>
        </tr>
        <tr>
            <td>192.168.2.200</td>
            <td>...</td>
        </tr>
        <tr>
            <td>192.168.2.300</td>
            <td>...</td>
        </tr>
        ...
    </table>
*/

import http from 'http'
import {urls} from "./urls.mjs"
import {sendHtmlTextWithStatusCode} from "../modules/httputil.mjs"

function serverCallback(req, res, urls)
{
    let index = urls.findIndex(u => u.url === req.url)

    if (index !== -1)
        urls[index].callback(req, res)
    else
        notFoundNUrlCallback(req, res)
}

function notFoundNUrlCallback(req, res)
{
    sendHtmlTextWithStatusCode(404, res, "Not found")
}

function main()
{
    let server = http.createServer((req, res) => serverCallback(req, res, urls))
    let port = 50500

    console.log(`server is listening on port ${port}`)
    server.listen(port)
}

main()

