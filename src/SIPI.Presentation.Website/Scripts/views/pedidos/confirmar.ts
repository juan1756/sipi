module views.pedidos {
    export class confirmar {
        constructor() {
            $('.card-footer button').click(e => this.onBtnCardDeleteClick(e));
            $('#btnConfirmAddress').click(e => this.onBtnConfirmAddressClick(e));
        }

        private onBtnCardDeleteClick(e: JQueryEventObject) {
            var $button = $(e.target);
            $button.closest('.col-xl-3').remove();

            if (!$('.col-xl-3').length) {
                $('#container').append('NO HAY MAS ELEMENTOS');
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
    }
}
