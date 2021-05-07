exports.getDigitsCount = function (val)
{
    return val ? parseInt(Math.log10(Math.abs(val))) + 1 :  1
}

exports.isNumber = function (str) {
    let dotCount = 0
    let index

    index = str.indexOf("-")
    
    if (index != 0 && index != -1)
        return false

    index = -1
    while ((index = str.indexOf(".", index + 1)) != -1)
        ++dotCount

    if (dotCount > 1)
        return false

    for (let i = 0; i < str.length; ++i) {
        let ch = str.charAt(i)

        if (ch == "-")
            continue

        if (ch == ".")
            continue

        if (ch < "0" || ch > "9")
            return false
    }

    return true
}


exports.getReverse = function (val)
{
    let reverse = 0

    while (val != 0) {
        reverse = reverse * 10 + val % 10
        val = parseInt(val / 10)
    }

    return reverse
}


exports.isEven = function (val) {
    return val % 2 == 0
}

exports.isOdd = function (val) {
    return !isEven(val)
}

exports.isPrime = function (val) {
    if (val <= 1)
        return false

    if (val % 2 == 0)
        return val == 2

    if (val % 3 == 0)
        return val == 3

    if (val % 5 == 0)
        return val == 5

    if (val % 7 == 0)
        return val == 7

    for (let i = 11; i * i <= val; i += 2)
        if (val % i == 0)
            return false

    return true
}
