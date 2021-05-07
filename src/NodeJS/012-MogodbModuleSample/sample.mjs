import {SensorInfo} from "./sensorinfo.mjs";
import random from "../modules/org-csystem-random.js"
import {getMongoClient} from "../modules/org-csystem-mongoutil.mjs"

process.on("uncaughtException", err => console.log(err.message))

function getRandomSensor()
{
    const name = "test"
    const host = "192.167.2.123"
    const port = random.nextInt(1024, 65536)
    const data = random.nextDouble(-32.54, 40.678)

    return new SensorInfo(name, host, port, data)
}

setInterval(() => {
    getMongoClient("192.168.1.167", 30000).connect((err, client) => {
        if (err)
            throw err

        //Bağlantı sağlandı
        let db = client.db("sensorsdb")
        let sensors = db.collection("sensors")

        sensors.insertOne(getRandomSensor(), (err, res) => {if (err) throw err})
       // client.close();
    })
}, 10)

setInterval(() => {
    getMongoClient("192.168.1.167", 30000).connect((err, client) => {
        if (err)
            throw err

        //Bağlantı sağlandı
        let db = client.db("sensorsdb")
        let sensors = db.collection("sensors")

        sensors.find({data: {$gt:10}}).toArray((err, result) =>  {
            result.forEach(s => console.log(s))
        })
    })
}, 5000)


