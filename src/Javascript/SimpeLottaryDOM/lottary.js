var NumericLotto = function () {
    var randomInt = function (min, max) { //[min, max)        
        return parseInt(Math.random() * (max - min)) + min;
    }
    this.getColumn = function () {        
        var column = Array(6);

        var flag;

        var status = Array(50);

        for (var i = 1; i < status.length; ++i)
            status[i] = false;

        for (var i = 0; i < 6; ++i) {
            for(;;) {
                var val = randomInt(1, 50);

                if (!status[val]) {
                    status[val] = true;
                    break;
                }
            }
        }

        var index = 0;

        for (var i = 1; i < status.length; ++i)
            if (status[i])
                column[index++] = i;

        return column;
    }

    this.getColumns = function (n) {        
        var result = new Array(n);

        for (var i = 0; i < n; ++i)
            result[i] = this.getColumn();

        return result;
    }

}

