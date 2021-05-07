/*
    Sınıf Çalışması: Toplam üç kez ip sorgulaması yapan ip yi kara listeye alan ve sorgulama yaptırtmayan
    uygulamayı yazınız. Kara listedeki ip ler yine tablo biçiminde "blistips" yrl bilgisi ile elde edilebilecektir.
    Tüm ip ler kaç kez sorgulandıkları ve kara listede olup olmadıkları bilgileri de dahil olmak üzere
    "ips" url bilgisi ile tablo biçiminde elde edilebiliecekti
    Örnek tablo:

    <table>
        <tr>
            <th>IP Adresi</th>
            <th>Sorgulama zamanı</th>
            <th>Sorgulama Sayısı</th>
            <th>Kara listede mi?</th>
        </tr>
        <tr>
            <td>192.168.2.200</td>
            <td>...</td>
            <td>7</td>
            <td>Evet</td>
        </tr>
        <tr>
            <td>192.168.2.300</td>
            <td>...</td>
            <td>2</td>
            <td>Hayır</td>
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

