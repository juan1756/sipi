declare var Waypoint: any;

module views.pedidos {
    export class crear {
        private _tamanoInsumo: number;
        private _infinite: any;
        private $frmMedios: JQuery;
        private $btnOrder: JQuery;
        private $frmFilters_SelectAll: JQuery;

        constructor(tamanoInsumo: number) {
            this._tamanoInsumo = tamanoInsumo;
            this._infinite = new Waypoint.Infinite({
                context: $('.main-wrapper')[0],
                element: $('.infinite-container')[0],
                onAfterPageLoad: $items => {
                    this.setMediosCheck($items);
                }
            });

            this.$frmMedios = $('#frmMedios');
            this.$btnOrder = $('#btnOrder');
            this.$btnOrder.click(e => this.onBtnOrderClick(e));

            this.$frmFilters_SelectAll = $('#frmFilters #SelectAll');   
            this.$frmFilters_SelectAll.change(e => this.onFrmFiltersSelectAllChange(e));

            $('.infinite-container').on('change', '[name=Medios]', e => this.onMediosChange(e));
        }

        private onBtnOrderClick(e: JQueryEventObject) {
            this.$frmMedios.find('[name=SelectAll]').val($('#frmFilters #SelectAll').prop('checked'));
            this.$frmMedios.submit();
        }

        private onFrmFiltersSelectAllChange(e: JQueryEventObject) {
            this.setMediosCheck($('.infinite-item'));
        }

        private setMediosCheck($items : JQuery) {
            $items.find('[name=Medios]').prop('checked', this.$frmFilters_SelectAll.prop('checked'));
        }

        private onMediosChange(e: JQueryEventObject) {
            var $medios = $('[name=Medios]');
            this.$frmFilters_SelectAll.prop('checked', $medios.length == $medios.filter(':checked').length);
        }
    }
}