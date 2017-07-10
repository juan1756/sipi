var app = (function () {

    var tables = (function () {
        var dateFormat = function (value, row, index) {
            return moment(value).format('DD/MM/YYYY');
        }

        return {
            dateFormat: dateFormat
        };
    })();

    return {
        tables: tables
    };
})();