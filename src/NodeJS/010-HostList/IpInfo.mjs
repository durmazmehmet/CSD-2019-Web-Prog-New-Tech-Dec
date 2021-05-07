export class IpInfo {
    constructor(ip)
    {
        this._ip = ip
        this._date = new Date()
    }

    get date()
    {
        return this._date;
    }

    get ip()
    {
        return this._ip;
    }
}