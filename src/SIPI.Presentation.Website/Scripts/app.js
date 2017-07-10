var app = (function () {

    var tables = (function () {
        var dateFormat = function (value, row, index) {
            return moment(value).format('DD/MM/YYYY');
        }

        return {
            dateFormat: dateFormat
        };
    })();

    function initDatepickers() {
        $('input[data-apply=datepicker]').datepicker({
            language: "es"
        });
    }

    (function constructor() {
        $(document).ready(function(){
            $.validator.methods.date = function (value, element) {
                return this.optional(element) || moment(value, "DD/MM/YYYY") !== null;
            };
            initDatepickers();
        });
    })();

    return {
        tables: tables
    };
})();