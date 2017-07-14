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
                    element: $('.infinite-container')[0]
                });
                this.$frmMedios = $('#frmMedios');
                this.$btnOrder = $('#btnOrder');
                this.$btnOrder.click(function (e) { return _this.onBtnOrderClick(e); });
            }
            crear.prototype.onBtnOrderClick = function (e) {
                this.$frmMedios.find('[name=SelectAll]').val($('#frmFilters #SelectAll').prop('checked'));
                this.$frmMedios.submit();
            };
            return crear;
        }());
        pedidos.crear = crear;
    })(pedidos = views.pedidos || (views.pedidos = {}));
})(views || (views = {}));
//# sourceMappingURL=crear.js.map