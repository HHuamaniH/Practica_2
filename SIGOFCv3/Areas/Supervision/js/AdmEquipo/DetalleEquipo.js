var DetalleEquipo = {};
DetalleEquipo.DataIntegrante = [];

DetalleEquipo.fnLoadData = function (obj) {
    DetalleEquipo.DataIntegrante = obj;
};

DetalleEquipo.regresar = function () {
    var url = urlLocalSigo + "Supervision/AdmEquipo/Index";
    window.location = url;
};

$(document).ready(function () {
    DetalleEquipo.frm = $("#frmDetalleEquipo");
});