class CommandInfo {
    constructor(cmd, callback)
    {
        this.cmd = cmd
        this.callback = callback
    }
}

let commands = [
    new CommandInfo("ADD", (a, b) => a + b),
    new CommandInfo("SUB", (a, b) => a - b),
    new CommandInfo("MUL", (a, b) => a * b),
    new CommandInfo("DIV", (a, b) => a / b)
]

export {CommandInfo, commands}