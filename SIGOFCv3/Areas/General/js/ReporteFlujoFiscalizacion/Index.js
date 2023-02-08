
var _reporte = {};

_reporte.fnInit = function () {
    var _idTab = _reporte.frm.find("#idTab").val();

    if (_idTab == 0) $("#hrenavDFFFS").trigger("click");
    else if (_idTab == 1) $("#hrefnavSubdireccion").trigger("click"); 
    else if (_idTab == 2) $("#hrefnavMAPRO").trigger("click"); 
    else if (_idTab == 3) $("#hrefnavPEI").trigger("click"); 
};

$(document).ready(function () {
    _reporte.frm = $("#frmRptFlujoFiscalizacion");
    _reporte.fnInit();
});