declare var Waypoint: any;

module views.pedidos {
    export class crear {
        private _tamanoInsumo: number;
        private _infinite: any;
        private $frmMedios: JQuery;
        private $btnOrder: JQuery;

        constructor(tamanoInsumo: number) {
            this._tamanoInsumo = tamanoInsumo;
            this._infinite = new Waypoint.Infinite({
                context: $('.main-wrapper')[0],
                element: $('.infinite-container')[0]
            });

            this.$frmMedios = $('#frmMedios');
            this.$btnOrder = $('#btnOrder');
            this.$btnOrder.click(e => this.onBtnOrderClick(e));
        }

        private onBtnOrderClick(e: JQueryEventObject) {
            this.$frmMedios.find('[name=SelectAll]').val($('#frmFilters #SelectAll').prop('checked'));
            this.$frmMedios.submit();
        }


    }
}