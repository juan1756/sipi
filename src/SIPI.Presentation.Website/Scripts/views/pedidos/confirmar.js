var views;
(function (views) {
    var pedidos;
    (function (pedidos) {
        var confirmar = (function () {
            function confirmar() {
                var _this = this;
                $('.card-footer button').click(function (e) { return _this.onBtnCardDeleteClick(e); });
                $('#btnConfirmAddress').click(function (e) { return _this.onBtnConfirmAddressClick(e); });
            }
            confirmar.prototype.onBtnCardDeleteClick = function (e) {
                var $button = $(e.target);
                $button.closest('.col-xl-3').remove();
                if (!$('.col-xl-3').length) {
                    $('#container').append('NO HAY MAS ELEMENTOS');
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
            return confirmar;
        }());
        pedidos.confirmar = confirmar;
    })(pedidos = views.pedidos || (views.pedidos = {}));
})(views || (views = {}));
//# sourceMappingURL=confirmar.js.map