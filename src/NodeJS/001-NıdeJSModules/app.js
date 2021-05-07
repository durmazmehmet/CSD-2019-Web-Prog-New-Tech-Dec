const random = require("../modules/org-csystem-random.js")
const terminal = require("../modules/org-csystem-terminal.js")

function main()
{
    for (let i = 0; i < 10; ++i)
        terminal.writeLine(random.nextInt(10, 20))

    terminal.writeLine("////////////////////////////////")

    for (let i = 0; i < 10; ++i)
        terminal.writeLine(random.nextBoolean())
}

main()