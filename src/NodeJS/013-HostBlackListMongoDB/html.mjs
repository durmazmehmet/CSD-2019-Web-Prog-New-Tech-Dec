function getLocalAddressHtml(localAddress)
{
    return `<html>
        <head>
            <title>C and System Programmers Association</title> 
        </head>
        <body>
            <h1>Your Local Ip Address: ${localAddress}</h1>
            <a href="http://www.csystem.org">CSD</a>
        </body>
    </html>
   `
}

function getIpsTable(ips)
{
    let ipsTable = ` <table border = "1">
        <tr>
            <th>IP Adresi</th>
            <th>Sorgulama zamanı</th>
            <th>Sorgulama Sayısı</th>
            <th>Kara listede mi?</th>
        </tr>
    `
    function ipsTableCallback(ipInfo)
    {
        ipsTable += "<tr>"
        ipsTable += `<td>${ipInfo.ip}</td>`
        ipsTable += `<td>${ipInfo.date}</td>`
        ipsTable += `<td>${ipInfo.count}</td>`
        ipsTable += `<td>${ipInfo.isInBlackList ? "Evet" : "Hayır"}</td>`
        ipsTable += "</tr>"
    }

    ips.forEach(ipsTableCallback)

    ipsTable += "</table>"

    return ipsTable
}


function getBlackListIpsTable(ips)
{
    let ipsTable = ` <table border = "1">
        <tr>
            <th>IP Adresi</th>
            <th>Sorgulama zamanı</th>
            <th>Sorgulama Sayısı</th>            
        </tr>
    `
    function ipsTableCallback(ipInfo)
    {
        ipsTable += "<tr>"
        ipsTable += `<td>${ipInfo.ip}</td>`
        ipsTable += `<td>${ipInfo.date}</td>`
        ipsTable += `<td>${ipInfo.count}</td>`
        ipsTable += "</tr>"
    }

    ips.filter(info => info.isInBlackList).forEach(ipsTableCallback)

    ipsTable += "</table>"

    return ipsTable
}


function getAllIps(ips)
{
    let ipsInfomation = ips.length > 0 ? getIpsTable(ips) : "<h4>No ip found</h4>"

    return `<html>
        <head>
            <title>C and System Programmers Association</title> 
        </head>
        <body>
            ${ipsInfomation}
        </body>
    </html>
   `
}

export {getAllIps, getLocalAddressHtml, getBlackListIpsTable}