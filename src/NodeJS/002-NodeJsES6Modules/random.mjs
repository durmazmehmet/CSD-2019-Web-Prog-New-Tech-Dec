function nextInt(min, max)
{
    return parseInt(Math.floor(Math.random() * (max - min) + min))
}

function nextBoolean()
{
    return nextInt(0, 2) === 1
}

function nextDouble(min, max)
{
    return Math.floor(Math.random() * (max - min) + min)
}

export {nextInt, nextBoolean, nextDouble}
