/*
    Sınıf Çalışması: Saniyede bir çalışan bir interval içerisinde rasgele sayılar üretilsin.
    [1, 10] aralığında rasgele belirlenmiş sayı kadar asal sayı geldiğinde interval’ı durduran programı yazınız.
*/
import {writeLine} from "./terminal.mjs"
import {nextInt, nextBoolean} from "./random.mjs";

function main()
{
    for (let i = 0; i < 10; ++i)
        writeLine(nextInt(10, 20))

    writeLine("////////////////////////////////")

    for (let i = 0; i < 10; ++i)
        writeLine(nextBoolean())
}

main()