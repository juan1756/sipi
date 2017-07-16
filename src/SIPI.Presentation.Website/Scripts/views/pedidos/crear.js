var views;
(function (views) {
    var pedidos;
    (function (pedidos) {
        var crear = (function () {
            function crear(tamanoInsumo) {
                var _this = this;
                this._tamanoInsumo = tamanoInsumo;
                this._infinite = new Waypoint.Infinite({
                    context: $('.main-wrapper')[0],
                    element: $('.infinite-container')[0],
                    onAfterPageLoad: function ($items) {
                        _this.setMediosCheck($items);
                    }
                });
                this.$frmMedios = $('#frmMedios');
                this.$btnOrder = $('#btnOrder');
                this.$btnOrder.click(function (e) { return _this.onBtnOrderClick(e); });
                this.$frmFilters_SelectAll = $('#frmFilters #SelectAll');
                this.$frmFilters_SelectAll.change(function (e) { return _this.onFrmFiltersSelectAllChange(e); });
                $('.infinite-container').on('change', '[name=Medios]', function (e) { return _this.onMediosChange(e); });
            }
            crear.prototype.onBtnOrderClick = function (e) {
                this.$frmMedios.find('[name=SelectAll]').val($('#frmFilters #SelectAll').prop('checked'));
                this.$frmMedios.submit();
            };
            crear.prototype.onFrmFiltersSelectAllChange = function (e) {
                this.setMediosCheck($('.infinite-item'));
            };
            crear.prototype.setMediosCheck = function ($items) {
                $items.find('[name=Medios]').prop('checked', this.$frmFilters_SelectAll.prop('checked'));
            };
            crear.prototype.onMediosChange = function (e) {
                var $medios = $('[name=Medios]');
                this.$frmFilters_SelectAll.prop('checked', $medios.length == $medios.filter(':checked').length);
            };
            return crear;
        }());
        pedidos.crear = crear;
    })(pedidos = views.pedidos || (views.pedidos = {}));
})(views || (views = {}));
