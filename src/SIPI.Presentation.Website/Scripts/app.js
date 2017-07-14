var app = (function () {

    var tables = (function () {
        var dateFormat = function (value, row, index) {
            return moment(value).format('DD/MM/YYYY');
        }

        function estadoFormatter(value, row, index) {
            return "<div class='btn btn-" +
                (value == "Nuevo"
                    ? "danger"
                    : value == "Listo"
                        ? "info"
                        : "success") + "-outline btn-static'>" + value + "</div>";
        }

        function estadoSiguienteFormatter(value, row, index) {
            if (!value)
                return;

            if (row.puedeCambiarEstado)
                return "<button type='submit' name='numero' value='" + row.numero + "' class='btn btn-" + (value == "Listo" ? "info" : "success") + "'>" + value + "</button>";

            return "<div class='btn btn-" + (value == "Listo" ? "info" : "success") + "-outline btn-static'>" + value + "</div>";
        }

        function temasFormatter(value, row, index) {
            return value.join(" / ");
        }

        return {
            dateFormat: dateFormat,
            estadoFormatter: estadoFormatter,
            estadoSiguienteFormatter: estadoSiguienteFormatter,
            temasFormatter: temasFormatter
        };
    })();



    function initDatepickers() {
        $('input[data-apply=datepicker]').datepicker({
            language: "es",
            endDate: new Date(),
            todayHighlight: true,
            weekStart: 0
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