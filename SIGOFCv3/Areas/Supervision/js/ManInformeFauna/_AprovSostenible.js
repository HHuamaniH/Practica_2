"use strict";
var _AprovSostenible = {};

_AprovSostenible.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_AprovSostenible.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _AprovSostenible.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _AprovSostenible.frm.find("#txtPeriodo").val(data["PERIODO"]);
        _AprovSostenible.frm.find("#txtCuotaSaca").val(data["CUOTA_SACA"]);
        _AprovSostenible.frm.find("#txtPersonal").val(data["PERSONAL"]);
        _AprovSostenible.frm.find("#txtMetodoCaza").val(data["METODO_CAZA"]);
        _AprovSostenible.frm.find("#txtSistemaMarcaje").val(data["SISTEMA_MARCAJE"]);
        _AprovSostenible.frm.find("#txtParteAprov").val(data["APROVECHAR"]);
        _renderComboEspecie.fnInit("FAUNA", data["COD_ESPECIES"], data["DESC_ESPECIES"]);
    } else {
        _AprovSostenible.frm.find("#hdfRegEstado").val("1");
        _renderComboEspecie.fnInit("FAUNA", "", "");
    }
}

_AprovSostenible.fnSetDatos = function () {
    var data = [];
    var regEstado = _AprovSostenible.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["DESC_ESPECIES"] = _renderComboEspecie.fnGetEspecie();
    data["PERIODO"] = _AprovSostenible.frm.find("#txtPeriodo").val();
    data["CUOTA_SACA"] = _AprovSostenible.frm.find("#txtCuotaSaca").val();
    data["PERSONAL"] = _AprovSostenible.frm.find("#txtPersonal").val();
    data["METODO_CAZA"] = _AprovSostenible.frm.find("#txtMetodoCaza").val();
    data["SISTEMA_MARCAJE"] = _AprovSostenible.frm.find("#txtSistemaMarcaje").val();
    data["APROVECHAR"] = _AprovSostenible.frm.find("#txtParteAprov").val();
    return data;
}

_AprovSostenible.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_AprovSostenible.fnSubmitForm = function () {
    _AprovSostenible.frm.submit();
}

_AprovSostenible.fnInit = function (data) {
    _AprovSostenible.frm = $("#frmItemAprovSostenible");

    _AprovSostenible.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    _AprovSostenible.frm.validate(utilSigo.fnValidate({
        rules: {
            txtPeriodo: { required: true },
            txtCuotaSaca: { required: true },
            txtPersonal: { required: true },
            txtMetodoCaza: { required: true },
            txtSistemaMarcaje: { required: true },
            txtParteAprov: { required: true }
        },
        messages: {
            txtPeriodo: { required: "Ingrese el periodo" },
            txtCuotaSaca: { required: "Ingrese la cuota de saca" },
            txtPersonal: { required: "Ingrese el personal encargado" },
            txtMetodoCaza: { required: "Ingrese el método de caza o captura" },
            txtSistemaMarcaje: { required: "Ingrese el sistema de marcaje o identificación" },
            txtParteAprov: { required: "Ingrese las partes o derivados a aprovechar" }
        },
        fnSubmit: function (form) {
            if (_AprovSostenible.fnCustomValidateForm()) {
                _AprovSostenible.fnSaveForm(_AprovSostenible.fnSetDatos());
            }
        }
    }));
    //Validación de controles que usan Select2
    _AprovSostenible.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}