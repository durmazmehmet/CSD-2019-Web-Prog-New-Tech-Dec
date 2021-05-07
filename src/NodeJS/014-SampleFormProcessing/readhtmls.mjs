import fs from "fs"

let loginHtml = ""
let registerHtml = ""
let successHtml = ""

fs.readFile("html/login.html", (err, data) => {
    if (err)
        throw err

    loginHtml += data
})

fs.readFile("html/register.html", (err, data) => {
    if (err)
        throw err

    registerHtml += data
})

fs.readFile("html/success.html", (err, data) => {
    if (err)
        throw err

    successHtml += data
})

export {loginHtml, registerHtml, successHtml}