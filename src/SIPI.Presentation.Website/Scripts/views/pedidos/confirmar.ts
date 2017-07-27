module views.pedidos {
    export class confirmar {
        private tamanoInsumo: number;
        private precioInsumo: number;

        private $cantidadInsumos: JQuery;
        private $costoTotal: JQuery;
        private $cantidadCopias: JQuery;

        constructor(tamanoInsumo: number, precioInsumo: number) {
            this.tamanoInsumo = tamanoInsumo;
            this.precioInsumo = precioInsumo;

            this.$cantidadInsumos = $('#CantidadInsumos');
            this.$costoTotal = $('#CostoTotal');
            this.$cantidadCopias = $('[name=CantidadCopias]');

            $('.card-footer button').click(e => this.onBtnCardDeleteClick(e));
            $('#btnConfirmAddress').click(e => this.onBtnConfirmAddressClick(e));
            $('[name=CantidadCopias]').change(e => this.onCantidadCopiasChange(e));
        }

        private onBtnCardDeleteClick(e: JQueryEventObject) {
            var $button = $(e.target);
            $button.closest('.col-xl-3').remove();
            this.calcularInsumos(true);

            if (!$('.col-xl-3').length) {
                $('#container').replaceWith('<table class="table fixed-table-pagination table-striped table-bordered table-hover"><tbody><tr class="no-records-found"><td align="center">Se eliminaron todos los medios del pedido</td></tr></tbody></table>');
                $('#btnConfirm').prop('disabled', true);
            }
        }

        private onBtnConfirmAddressClick(e: JQueryEventObject) {
            var $frmAddress = $('#frmAddress');
            if ((<any>$('#frmAddress')).valid() == false)
                return;

            var $frmMedios = $('#frmMedios');
            var $modal = $('#modal-media');

            $frmMedios.find('[name=ProvinciaId]').val($modal.find('[name=ProvinciaId]').val());
            $frmMedios.find('[name=LocalidadId]').val($modal.find('[name=LocalidadId]').val());
            $frmMedios.find('[name=Calle]').val($modal.find('[name=Calle]').val());
            $frmMedios.find('[name=Altura]').val($modal.find('[name=Altura]').val());
            $frmMedios.find('[name=Piso]').val($modal.find('[name=Piso]').val());
            $frmMedios.submit();
        }

        private onCantidadCopiasChange(e: JQueryEventObject) {
            this.calcularInsumos(false);
        }

        private calcularInsumos(deleted: boolean) {
            var tamanoTotal = 0;
            $('[data-tamano]').each((i, e) => {
                tamanoTotal += $(e).data('tamano');
            });

            if (!tamanoTotal) {
                this.$cantidadInsumos.html('0');
                this.$costoTotal.html('$0');
                return;
            }

            var insumos = Math.floor(tamanoTotal / this.tamanoInsumo);
            if (tamanoTotal % this.tamanoInsumo > 0)
                insumos++;

            var insumosPorCantidadCopias = this.$cantidadCopias.val() * insumos;
            var cantidadAnterior = parseInt(this.$cantidadInsumos.html());
            this.$cantidadInsumos.html(insumosPorCantidadCopias.toString());
            this.$costoTotal.html('$' + (insumosPorCantidadCopias * this.precioInsumo));

            if (deleted) {
                if (cantidadAnterior != insumosPorCantidadCopias) {
                    toastr.clear();
                    toastr.warning(
                        'Medio Audiovisual eliminado del pedido.<br />El pedido ahora tiene: ' + insumosPorCantidadCopias + ' unidades',
                        'Información');
                } else {
                    toastr.clear();
                    toastr.warning(
                        'Medio Audiovisual eliminado del pedido',
                        'Información');
                }
            }
            else {
                toastr.clear();
                toastr.warning(
                    'El pedido ahora tiene: ' + insumosPorCantidadCopias + ' unidades',
                    'Información');
            }
        }
    }
}
