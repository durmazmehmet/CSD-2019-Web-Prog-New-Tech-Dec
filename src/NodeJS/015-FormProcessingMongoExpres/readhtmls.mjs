import fs from "fs"

let loginHtml = ""
let registerHtml = ""
let successHtml = ""
let failHtml = ""
let saveHtml = ""
let pageNotFoundHtml = ""
let userFoundHtml = ""
let userNotFoundHtml = ""

fs.readFile("./html/login.html", (err, data) => {
    if (err)
        throw err

    loginHtml += data
})

fs.readFile("./html/register.html", (err, data) => {
    if (err)
        throw err

    registerHtml += data
})

fs.readFile("./html/success.html", (err, data) => {
    if (err)
        throw err

    successHtml += data
})

fs.readFile("./html/fail.html", (err, data) => {
    if (err)
        throw err

    failHtml += data
})


fs.readFile("./html/save.html", (err, data) => {
    if (err)
        throw err

    saveHtml += data
})

fs.readFile("./html/pagenotfound.html", (err, data) => {
    if (err)
        throw err

    pageNotFoundHtml += data
})

fs.readFile("./html/userfound.html", (err, data) => {
    if (err)
        throw err

    userFoundHtml += data
})

fs.readFile("./html/usernotfound.html", (err, data) => {
    if (err)
        throw err

    userNotFoundHtml += data
})

export {loginHtml, registerHtml, successHtml, failHtml, saveHtml, pageNotFoundHtml, userFoundHtml, userNotFoundHtml}




