const blackListCount = 3

export class IpInfo {
    constructor(ip)
    {
        this._ip = ip
        this._date = new Date()
        this._count = 1
        this._isInBlackList = false
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
        return this._isInBlackList
    }

    get count()
    {
        return this._count;
    }

    set count(value)
    {
        this._count = value;
        this._isInBlackList = this._count >= blackListCount;
    }
}