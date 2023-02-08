"use strict";
var _DocumentoGestionCons = {};

_DocumentoGestionCons.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_DocumentoGestionCons.fnLoadDatos = function (asCodPrograma, data) {
    if (data != null && data != "") {
        _DocumentoGestionCons.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _DocumentoGestionCons.frm.find("#hdfCodPrograma").val(data["COD_PROGRAMA"]);
        _DocumentoGestionCons.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _DocumentoGestionCons.frm.find("#txtDocumento").val(data["ACTIVIDAD_REALIZADA"]);
        _DocumentoGestionCons.frm.find("#txtFechaElabora").val(data["FECHA_REALIZADA"]);
        _DocumentoGestionCons.frm.find("#txtObjetivo").val(data["OBJETIVO"]);
        _DocumentoGestionCons.frm.find("#txtObservacion").val(data["OBSERVACION"]);
    } else {
        _DocumentoGestionCons.frm.find("#hdfRegEstado").val("1");
        _DocumentoGestionCons.frm.find("#hdfCodPrograma").val(asCodPrograma);
        _DocumentoGestionCons.frm.find("#hdfCodSecuencial").val("0");
    }
}

_DocumentoGestionCons.fnSetDatos = function () {
    var data = [];
    var regEstado = _DocumentoGestionCons.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_PROGRAMA"] = _DocumentoGestionCons.frm.find("#hdfCodPrograma").val();
    data["COD_SECUENCIAL"] = _DocumentoGestionCons.frm.find("#hdfCodSecuencial").val();
    data["ACTIVIDAD_REALIZADA"] = _DocumentoGestionCons.frm.find("#txtDocumento").val();
    data["FECHA_REALIZADA"] = _DocumentoGestionCons.frm.find("#txtFechaElabora").val();
    data["OBJETIVO"] = _DocumentoGestionCons.frm.find("#txtObjetivo").val();
    data["OBSERVACION"] = _DocumentoGestionCons.frm.find("#txtObservacion").val();
    return data;
}

_DocumentoGestionCons.fnSubmitForm = function () {
    _DocumentoGestionCons.frm.submit();
}

_DocumentoGestionCons.fnInit = function (data, asCodPrograma) {
    _DocumentoGestionCons.frm = $("#frmItemDocumentoGestionCons");

    utilSigo.fnFormatDate(_DocumentoGestionCons.frm.find("#txtFechaElabora"));

    _DocumentoGestionCons.fnLoadDatos(asCodPrograma, data);

    //=====-----Para el registro de datos del formulario-----=====
    _DocumentoGestionCons.frm.validate(utilSigo.fnValidate({
        rules: {
            txtDocumento: { required: true },
            txtFechaElabora: { required: true }
        },
        messages: {
            txtDocumento: { required: "Ingrese el documento elaborado o acuerdo" },
            txtFechaElabora: { required: "Ingrese la fecha de elaboración" }
        },
        fnSubmit: function (form) {
            _DocumentoGestionCons.fnSaveForm(_DocumentoGestionCons.fnSetDatos());
        }
    }));

    //Validación de controles que usan Select2
    _DocumentoGestionCons.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}