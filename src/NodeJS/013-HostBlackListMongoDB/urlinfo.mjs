class UrlInfo {
    constructor(url, callback)
    {
        this._url = url;
        this._callback = callback;
    }

    get url()
    {
        return this._url;
    }

    set url(value)
    {
        this._url = value;
    }

    get callback()
    {
        return this._callback;
    }

    set callback(value)
    {
        this._callback = value;
    }
}


export {UrlInfo}