var App = (function () {
    function App(dateFormat) {
        this._dateFormat = dateFormat;
        this.tables = new Tables(dateFormat);
        this.initDatePickers();
    }
    App.prototype.initDatePickers = function () {
        $('input[data-apply=datepicker]').datepicker({
            language: "es",
            endDate: new Date(),
            todayHighlight: true,
            weekStart: 0
        });
        $.validator.methods.date = function (value, element) {
            return this.optional(element) || moment(value, "DD/MM/YYYY") !== null;
        };
    };
    App.prototype.go = function (url) {
        window.location.href = url;
    };
    App.prototype.goBack = function () {
        window.history.back();
    };
    return App;
}());
var Tables = (function () {
    function Tables(dateFormat) {
        this._dateFormat = dateFormat;
    }
    Tables.prototype.dateFormat = function (value, row, index) {
        return moment(value).format('DD/MM/YYYY');
    };
    Tables.prototype.estadoFormatter = function (value, row, index) {
        return "<div class='btn btn-" +
            (value == "Nuevo"
                ? "danger"
                : value == "Listo"
                    ? "info"
                    : "success") + "-outline btn-static'>" + value + "</div>";
    };
    Tables.prototype.estadoSiguienteFormatter = function (value, row, index) {
        if (!value)
            return;
        if (row.puedeCambiarEstado)
            return "<button type='button' name='numero' value='" + row.numero + "' class='cambiarEstado btn btn-" + (value == "Listo" ? "info" : "success") + "'>" + value + "</button>";
        return "<div class='btn btn-" + (value == "Listo" ? "info" : "success") + "-outline btn-static'>" + value + "</div>";
    };
    Tables.prototype.temasFormatter = function (value, row, index) {
        return value.join(" / ");
    };
    return Tables;
}());
