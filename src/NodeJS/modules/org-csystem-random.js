exports.nextInt = function (min, max) {
    return parseInt(Math.floor(Math.random() * (max - min) + min))
}

exports.nextBoolean = function () {
    return exports.nextInt(0, 2) === 1
}

exports.nextDouble = function (min, max) {
    return Math.floor(Math.random() * (max - min) + min)
}

