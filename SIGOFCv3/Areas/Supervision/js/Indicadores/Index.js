
var Indicador = {};

Indicador.fnInit = function () {
    var _idTab = Indicador.frm.find("#idTab").val();

    if (_idTab == 0) $("#hrefnavMAPRO").trigger("click");
    else if (_idTab == 1) $("#hrefnavPOI").trigger("click");
    else if (_idTab == 2) $("#hrefnavPEI").trigger("click");

    Indicador.frm.find("#hrefnavMAPRO").click(function () {
        Indicador.frm.find("#idTab").val(0);
    });
    Indicador.frm.find("#hrefnavPOI").click(function () {
        Indicador.frm.find("#idTab").val(1);
    });
    Indicador.frm.find("#hrefnavPEI").click(function () {
        Indicador.frm.find("#idTab").val(2);
    });
};

$(document).ready(function () {
    Indicador.frm = $("#frmIndicador");
    Indicador.fnInit();
});