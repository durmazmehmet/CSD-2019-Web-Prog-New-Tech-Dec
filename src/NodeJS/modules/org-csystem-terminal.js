exports.writeLine = function (msg) {
    console.log(msg)
}

module.exports.writeError = function (msg) {
    exports.writeLine(msg)
}