let types = ["", "Club", "Heart", "Diamond", "Spade"]
let values = ["", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace"]


function randomInt(min, max)
{
    return parseInt(Math.random() * (max - min) + min)
}

function getCardFilename()
{
    let type = randomInt(1, 5)
    let value = randomInt(1, 14)
    let path = "cards/"
    return `${path}${types[type]}_${values[value]}.bmp`
}

function randomCard()
{
    document.getElementById("card").src = getCardFilename()
}

function randomCards() //TODO: Aynı kartlar çıkabilir. Faklı olacak şekilde ayarlayınız
{
    let cardsImgs = document.getElementsByName("cards")

    for (let i = 0; i < cardsImgs.length; ++i)
        cardsImgs[i].src = getCardFilename()
}

function randomCardInterval()
{
    let count = 0
    let cardInterval = setInterval(function () {
        document.getElementById("randomcard").src = getCardFilename()
        ++count
        if (count == 20) {
            count = 0
            clearInterval(cardInterval)
        }
    }, 100);
}