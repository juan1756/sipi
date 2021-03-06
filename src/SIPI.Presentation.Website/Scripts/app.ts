﻿declare var moment: any;

class App {

    private _dateFormat: string;

    constructor(dateFormat: string) {
        this._dateFormat = dateFormat;
        this.tables = new Tables(dateFormat);
        this.initDatePickers();
    }

    public tables: Tables;

    private initDatePickers() {
        (<any>$('input[data-apply=datepicker]')).datepicker({
            language: "es",
            endDate: new Date(),
            todayHighlight: true,
            weekStart: 0
        });

        (<any>$).validator.methods.date = function (value, element) {
            return this.optional(element) || moment(value, "DD/MM/YYYY") !== null;
        };
    }

    public go(url: string) {
        window.location.href = url;
    }

    public goBack() {
        window.history.back();
    }
}

class Tables {

    private _dateFormat: string;
    constructor(dateFormat: string) {
        this._dateFormat = dateFormat;
    }

    public dateFormat(value, row, index) {
        if (value != null)
            return moment
                .utc(value)
                .tz("America/Argentina/Buenos_Aires")
                .format('DD/MM/YYYY');

        return "";
    }

    public estadoFormatter(value, row, index) {
        return "<div class='btn btn-" +
            (value == "Nuevo"
                ? "danger"
                : value == "Listo"
                    ? "info"
                    : "success") + "-outline btn-static'>" + value + "</div>";
    }

    public estadoSiguienteFormatter(value, row, index) {
        if (!value)
            return;

        if (row.puedeCambiarEstado)
            return "<button type='button' name='numero' value='" + row.numero + "' class='cambiarEstado btn btn-" + (value == "Listo" ? "info" : "success") + "'>" + value + "</button>";

        return "<div class='btn btn-" + (value == "Listo" ? "info" : "success") + "-outline btn-static'>" + value + "</div>";
    }

    public temasFormatter(value, row, index) {
        return value.join(" / ");
    }
}

declare var app: App;