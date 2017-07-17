var views;
(function (views) {
    var pedidos;
    (function (pedidos) {
        var crear = (function () {
            function crear(tamanoInsumo, precioInsumo) {
                var _this = this;
                this.tamanoInsumo = tamanoInsumo;
                this.precioInsumo = precioInsumo;
                this._infinite = new Waypoint.Infinite({
                    context: $('.main-wrapper')[0],
                    element: $('.infinite-container')[0],
                    onAfterPageLoad: function ($items) {
                        _this.setMediosCheck($items);
                        if (_this.$frmFilters_SelectAll.prop('checked'))
                            _this.calcularInsumos();
                    }
                });
                this.$cantidadInsumos = $('#CantidadInsumos');
                this.$costoParcial = $('#CostoParcial');
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
                this.calcularInsumos();
                //if (this.$frmFilters_SelectAll.prop('checked'))
            };
            crear.prototype.setMediosCheck = function ($items) {
                $items.find('[name=Medios]').prop('checked', this.$frmFilters_SelectAll.prop('checked'));
            };
            crear.prototype.onMediosChange = function (e) {
                var $medios = $('[name=Medios]');
                this.$frmFilters_SelectAll.prop('checked', $medios.length == $medios.filter(':checked').length);
                this.calcularInsumos();
            };
            crear.prototype.calcularInsumos = function () {
                var tamanoTotal = 0;
                $('[name=Medios]').filter(':checked').each(function (i, e) {
                    var $e = $(e);
                    tamanoTotal += $e.data('tamano');
                });
                if (!tamanoTotal) {
                    this.$cantidadInsumos.html('0');
                    this.$costoParcial.html('$0');
                    return;
                }
                var insumosActuales = Math.floor(tamanoTotal / this.tamanoInsumo);
                if (tamanoTotal % this.tamanoInsumo > 0)
                    insumosActuales++;
                this.$cantidadInsumos.html(insumosActuales.toString());
                this.$costoParcial.html('$' + (insumosActuales * this.precioInsumo));
            };
            return crear;
        }());
        pedidos.crear = crear;
    })(pedidos = views.pedidos || (views.pedidos = {}));
})(views || (views = {}));
