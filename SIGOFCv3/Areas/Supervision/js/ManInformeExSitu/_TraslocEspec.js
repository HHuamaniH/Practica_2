"use strict";
var _TraslocEspec = {};

_TraslocEspec.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_TraslocEspec.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _TraslocEspec.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _TraslocEspec.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _TraslocEspec.frm.find("#txtIndividuosTE").val(data["NUM_INDIVIDUOS"]);
        _TraslocEspec.frm.find("#txtAnioTE").val(data["ANIO"]);
        _TraslocEspec.frm.find("#txtZonaLiberacionTE").val(data["ZONA_LIBERACION"]);
        _TraslocEspec.frm.find("#txtRegistroSegTE").val(data["REGISTRO_SEG"]);
        _renderComboEspecie.fnInit("FAUNA", data["COD_ESPECIES"], data["DESCRIPCION"]);
    } else {
        _TraslocEspec.frm.find("#hdfRegEstado").val("1");
        _TraslocEspec.frm.find("#hdfCodSecuencial").val("0");
        _renderComboEspecie.fnInit("FAUNA", "", "");
    }
}

_TraslocEspec.fnSetDatos = function () {
    var data = [];
    var regEstado = _TraslocEspec.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _TraslocEspec.frm.find("#hdfCodSecuencial").val();
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["DESCRIPCION"] = _renderComboEspecie.fnGetEspecie();
    data["NUM_INDIVIDUOS"] = _TraslocEspec.frm.find("#txtIndividuosTE").val();
    data["ANIO"] = _TraslocEspec.frm.find("#txtAnioTE").val();
    data["ZONA_LIBERACION"] = _TraslocEspec.frm.find("#txtZonaLiberacionTE").val();
    data["REGISTRO_SEG"] = _TraslocEspec.frm.find("#txtRegistroSegTE").val();
    return data;
}

_TraslocEspec.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_TraslocEspec.fnSubmitForm = function () {
    _TraslocEspec.frm.submit();
}

_TraslocEspec.fnInit = function (data) {
    _TraslocEspec.frm = $("#frmItemTraslocEspec");

    _TraslocEspec.fnLoadDatos(data);

    _TraslocEspec.frm.validate(utilSigo.fnValidate({
        rules: {
           // txtIndivCapturado: { required: true }
        },
        messages: {
          //  txtIndivCapturado: { required: "Ingrese el número de individuos capturados" }
        },
        fnSubmit: function (form) {
            if (_TraslocEspec.fnCustomValidateForm()) {
                _TraslocEspec.fnSaveForm(_TraslocEspec.fnSetDatos());
            }
        }
    }));
    //Validación de controles que usan Select2
    _TraslocEspec.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}

function checkNum(e) {
    var tecla = (document.all) ? e.keyCode : e.which;

    if (tecla == 8 || tecla == 32) {
        return true;
    }

    var patron = /[0-9]/;
    var tecla_final = String.fromCharCode(tecla);
    return patron.test(tecla_final);
}