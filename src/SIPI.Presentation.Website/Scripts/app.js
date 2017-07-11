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

    // TODO: ver si queda Mustache o se va.s
    function initMustache() {
        //$.Mustache.addFromDom();
    }

    (function constructor() {
        $(document).ready(function(){
            $.validator.methods.date = function (value, element) {
                return this.optional(element) || moment(value, "DD/MM/YYYY") !== null;
            };
            initMustache();
            initDatepickers();
        });
    })();

    return {
        tables: tables
    };
})();