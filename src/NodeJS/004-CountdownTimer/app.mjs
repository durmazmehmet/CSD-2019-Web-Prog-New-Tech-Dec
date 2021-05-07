/*
    Sınıf Çalışması: Aşağıda açıklanan geri sayım işlemi yapan sınıfı ayrı içerisinde yazıp test ediniz
    Açıklamalar:
        - Sınıf milisaniye cinsinden toplam zamanı ve yine milisaniye cinsinden periyot bilgisini alacaktır
        - Sınıf toplam zaman boyunca her periyotta onTick isimli bir fonksiyon çağrısı yapacaktır.
        - tickCallback fonksiyonu dışarıdan alınacaktır ve her periyotta kalan zaman ile çağrılacaktır
        - Geri sayım işlemi sonunda finishedCallback isimli bir fonksiyon çağrılacaktır. Yine bu fonksiyon da
        dışarıdan alınacaktır.
        - Sınıfı kullanan bu fonksiyonları vermeze boş olarak çağrılacaktır
*/

import {Countdowntimer} from "../modules/org-csystem-countdowntimer.mjs";
import terminal from "../modules/org-csystem-terminal.js"

function main()
{
    let countdownTimer = new Countdowntimer(10000, 1000)

    countdownTimer.start(ms => terminal.writeLine(ms / 1000), () => terminal.writeLine("Finished"))
    terminal.writeLine("main bitti")
}

main()

