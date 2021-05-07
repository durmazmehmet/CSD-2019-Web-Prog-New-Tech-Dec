/*
    Sınıf Çalışması: Saniyede bir çalışan bir interval içerisinde rasgele sayılar üretilsin.
    [1, 10] aralığında rasgele belirlenmiş sayı kadar asal sayı geldiğinde interval’ı durduran programı yazınız.
*/

const terminal = require("../modules/org-csystem-terminal.js")
const random = require("../modules/org-csystem-random.js")
const numberUtil = require("../modules/org-csystem-numberUtil.js")

let interval = null
let count = 0
let n = 0

function randomGeneratorCallback()
{
    terminal.writeLine("Generating number...")
    let val = random.nextInt(1, 100)

    if (numberUtil.isPrime(val)) {
        terminal.writeLine(`value:${val}`)
        ++count
    }

    if (count === n)
        clearInterval(interval)
}

function main()
{
    n = random.nextInt(1, 11)
    terminal.writeLine(`n=${n}`)
    interval = setInterval(randomGeneratorCallback, 1000)
}

main()