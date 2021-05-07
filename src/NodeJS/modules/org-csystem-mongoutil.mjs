import mongodb from 'mongodb'

const MongoClient = mongodb.MongoClient
const mongodbOptions = { useNewUrlParser: true, useUnifiedTopology: true }

function getMongoClientByUrl(url)
{
    return new MongoClient(url, mongodbOptions)
}

function getMongoClient(host, port)
{
    const url = `mongodb://${host}:${port}`

    return getMongoClientByUrl(url)
}

export {getMongoClient, getMongoClientByUrl}