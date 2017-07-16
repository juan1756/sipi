declare var Waypoint: any;

module views.pedidos {
    export class crear {
        private tamanoInsumo: number;
        private precioInsumo: number;
        private insumosAnteriores: number;

        private _infinite: any;
        private $frmMedios: JQuery;
        private $btnOrder: JQuery;
        private $frmFilters_SelectAll: JQuery;

        private $cantidadInsumos: JQuery;
        private $costoParcial: JQuery;

        constructor(tamanoInsumo: number, precioInsumo: number) {
            this.tamanoInsumo = tamanoInsumo;
            this.precioInsumo = precioInsumo;
            this.insumosAnteriores = 0;

            this._infinite = new Waypoint.Infinite({
                context: $('.main-wrapper')[0],
                element: $('.infinite-container')[0],
                onAfterPageLoad: $items => {
                    this.setMediosCheck($items);

                    if (this.$frmFilters_SelectAll.prop('checked'))
                        this.calcularInsumos();
                }
            });

            this.$cantidadInsumos = $('#CantidadInsumos');
            this.$costoParcial = $('#CostoParcial');

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
            this.calcularInsumos();
            //if (this.$frmFilters_SelectAll.prop('checked'))
        }

        private setMediosCheck($items : JQuery) {
            $items.find('[name=Medios]').prop('checked', this.$frmFilters_SelectAll.prop('checked'));
        }

        private onMediosChange(e: JQueryEventObject) {
            var $medios = $('[name=Medios]');
            this.$frmFilters_SelectAll.prop('checked', $medios.length == $medios.filter(':checked').length);

            this.calcularInsumos();
        }

        private calcularInsumos() {
            var tamanoTotal = 0;
            $('[name=Medios]').filter(':checked').each((i, e) => {
                var $e = $(e);
                tamanoTotal += $e.data('tamano');
            });

            var insumosActuales = Math.floor(tamanoTotal / this.tamanoInsumo);

            if (insumosActuales != this.insumosAnteriores) {
                this.$cantidadInsumos.html(insumosActuales.toString());
                this.$costoParcial.html('$' + (insumosActuales * this.precioInsumo));
                this.insumosAnteriores = insumosActuales;
            }
        }
    }
}