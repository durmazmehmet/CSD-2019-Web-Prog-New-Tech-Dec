const blackListCount = 3

export class IpInfo {
    constructor(ip)
    {
        this._ip = ip
        this._date = new Date()
        this._count = 1
    }

    get date()
    {
        return this._date;
    }

    get ip()
    {
        return this._ip;
    }

    get isInBlackList()
    {
        return this._count >= blackListCount
    }

    get count()
    {
        return this._count;
    }

    set count(value)
    {
        this._count = value;
    }
}