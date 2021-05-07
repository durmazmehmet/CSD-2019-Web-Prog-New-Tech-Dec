let helloTR =
    `<html>
        <head>
            <title>C ve Sistem Programcıları Derneği</title> 
        </head>
        <body>
            <h1>Merhaba</h1>
            <a href="http://www.csystem.org">CSD</a>
        </body>
    </html>
`

let helloEN =
    `<html>
        <head>
            <title>C and System Programmers Association</title> 
        </head>
        <body>
            <h1>Hello</h1>
            <a href="http://www.csystem.org">CSD</a>
        </body>
    </html>
`

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

function getRandomNumberHtml(value)
{
    return `<html>
        <head>
            <title>C and System Programmers Association</title> 
        </head>
        <body>
            <h3>Your number: ${value}</h3>
            <a href="http://www.csystem.org">CSD</a>
        </body>
    </html>
   `
}

export {helloTR, helloEN, getLocalAddressHtml, getRandomNumberHtml}