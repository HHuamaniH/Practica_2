"use strict";
var _AproSostenible = {};

_AproSostenible.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_AproSostenible.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _AproSostenible.frm.find("#hdfRegEstadoApSos").val(data["RegEstado"]);
        _AproSostenible.frm.find("#hdfCodSecuencialApSos").val(data["COD_SECUENCIAL"]);
        _AproSostenible.frm.find("#txtPeriodo").val(data["PERIODO"]);
        _AproSostenible.frm.find("#txtPersonal").val(data["PERSONAL"]);
        _AproSostenible.frm.find("#txtMetodo").val(data["METODO"]);
        _AproSostenible.frm.find("#txtSistema").val(data["SISTEMA"]);
        _AproSostenible.frm.find("#txtPartes").val(data["PARTES"]);
        _renderComboEspecie.fnInit("FAUNA", data["COD_ESPECIES"], data["DESC_ESPECIES"]);
    } else {
        _AproSostenible.frm.find("#hdfRegEstadoApSos").val("1");
        _AproSostenible.frm.find("#hdfCodSecuencialApSos").val("0");
        _renderComboEspecie.fnInit("FAUNA", "", "");
    }
}

_AproSostenible.fnSetDatos = function () {
    var data = [];
    var regEstado = _AproSostenible.frm.find("#hdfRegEstadoApSos").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _AproSostenible.frm.find("#hdfCodSecuencialApSos").val();
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["ESPECIE"] = _renderComboEspecie.fnGetEspecie();
    data["PERIODO"] = _AproSostenible.frm.find("#txtPeriodo").val();
    data["PERSONAL"] = _AproSostenible.frm.find("#txtPersonal").val();
    data["METODO"] = _AproSostenible.frm.find("#txtMetodo").val();
    data["SISTEMA"] = _AproSostenible.frm.find("#txtSistema").val();
    data["PARTES"] = _AproSostenible.frm.find("#txtPartes").val();
    return data;
}

_AproSostenible.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_AproSostenible.fnSubmitForm = function () {
    _AproSostenible.frm.submit();
}

_AproSostenible.fnInit = function (data) {
    _AproSostenible.frm = $("#frmItemAprovSostenible");

    $.fn.select2.defaults.set("theme", "bootstrap4");

    _AproSostenible.fnLoadDatos(data);

    //_AproSostenible.fnEvents();

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada

    _AproSostenible.frm.validate(utilSigo.fnValidate({
        rules: {
            txtZona: { required: true },
            txtCaracteristicas: { required: true },
            txtCoordEste: { required: true },
            txtCoordNorte: { required: true },
            txtTipoSenial: { required: true }
        },
        messages: {
            txtZona: { required: "Ingrese la Zona" },
            txtCaracteristicas: { required: "Ingrese carácteristica" },
            txtCoordEste: { required: "Ingrese la coordenada este" },
            txtCoordNorte: { required: "Ingrese la coordenada norte" },
            txtTipoSenial: { required: "Ingrese tipo de señalización" }
        },
        fnSubmit: function (form) {
            _AproSostenible.fnSaveForm(_AproSostenible.fnSetDatos());
        }
    }));
    //Validación de controles que usan Select2
    _AproSostenible.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}


