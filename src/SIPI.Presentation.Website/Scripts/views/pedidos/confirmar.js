var views;
(function (views) {
    var pedidos;
    (function (pedidos) {
        var confirmar = (function () {
            function confirmar(tamanoInsumo, precioInsumo) {
                var _this = this;
                this.tamanoInsumo = tamanoInsumo;
                this.precioInsumo = precioInsumo;
                this.$cantidadInsumos = $('#CantidadInsumos');
                this.$costoTotal = $('#CostoTotal');
                this.$cantidadCopias = $('[name=CantidadCopias]');
                $('.card-footer button').click(function (e) { return _this.onBtnCardDeleteClick(e); });
                $('#btnConfirmAddress').click(function (e) { return _this.onBtnConfirmAddressClick(e); });
                $('[name=CantidadCopias]').change(function (e) { return _this.onCantidadCopiasChange(e); });
            }
            confirmar.prototype.onBtnCardDeleteClick = function (e) {
                var $button = $(e.target);
                $button.closest('.col-xl-3').remove();
                this.calcularInsumos();
                if (!$('.col-xl-3').length) {
                    //$('#container').append('No hay mas medios');
                    $('#btnConfirm').prop('disabled', true);
                }
            };
            confirmar.prototype.onBtnConfirmAddressClick = function (e) {
                var $frmAddress = $('#frmAddress');
                if ($('#frmAddress').valid() == false)
                    return;
                var $frmMedios = $('#frmMedios');
                var $modal = $('#modal-media');
                $frmMedios.find('[name=ProvinciaId]').val($modal.find('[name=ProvinciaId]').val());
                $frmMedios.find('[name=LocalidadId]').val($modal.find('[name=LocalidadId]').val());
                $frmMedios.find('[name=Calle]').val($modal.find('[name=Calle]').val());
                $frmMedios.find('[name=Altura]').val($modal.find('[name=Altura]').val());
                $frmMedios.find('[name=Piso]').val($modal.find('[name=Piso]').val());
                $frmMedios.submit();
            };
            confirmar.prototype.onCantidadCopiasChange = function (e) {
                this.calcularInsumos();
            };
            confirmar.prototype.calcularInsumos = function () {
                var tamanoTotal = 0;
                $('[data-tamano]').each(function (i, e) {
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
                this.$cantidadInsumos.html(insumosPorCantidadCopias.toString());
                this.$costoTotal.html('$' + (insumosPorCantidadCopias * this.precioInsumo));
            };
            return confirmar;
        }());
        pedidos.confirmar = confirmar;
    })(pedidos = views.pedidos || (views.pedidos = {}));
})(views || (views = {}));
//# sourceMappingURL=confirmar.js.map