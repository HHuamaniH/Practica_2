"use strict";
var _RegistroFlora = {};

_RegistroFlora.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_RegistroFlora.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _RegistroFlora.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _RegistroFlora.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _RegistroFlora.frm.find("#txtDap").val(data["DAP"]);
        _RegistroFlora.frm.find("#txtAltura").val(data["ALTURA_TOTAL"]);
        _RegistroFlora.frm.find("#txtEstado").val(data["ESTADO_ESPECIE"]);
        _RegistroFlora.frm.find("#ddlZonaId").select2("val", [data["ZONA"]]);
        _RegistroFlora.frm.find("#txtCoordEste").val(data["COORDENADA_ESTE"]);
        _RegistroFlora.frm.find("#txtCoordNorte").val(data["COORDENADA_NORTE"]);
        _RegistroFlora.frm.find("#txtObservacion").val(data["OBSERVACION"]);
        _renderComboEspecie.fnInit("FORESTAL", data["COD_ESPECIES"], data["ESPECIES"]);
    } else {
        _RegistroFlora.frm.find("#hdfRegEstado").val("1");
        _RegistroFlora.frm.find("#hdfCodSecuencial").val("0");
        _renderComboEspecie.fnInit("FORESTAL", "", "");
    }
}

_RegistroFlora.fnSetDatos = function () {
    var data = [];
    var regEstado = _RegistroFlora.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _RegistroFlora.frm.find("#hdfCodSecuencial").val();
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["ESPECIES"] = _renderComboEspecie.fnGetEspecie();
    data["DAP"] = _RegistroFlora.frm.find("#txtDap").val();
    data["ALTURA_TOTAL"] = _RegistroFlora.frm.find("#txtAltura").val();
    data["ESTADO_ESPECIE"] = _RegistroFlora.frm.find("#txtEstado").val();
    data["ZONA"] = _RegistroFlora.frm.find("#ddlZonaId").val();
    data["COORDENADA_ESTE"] = _RegistroFlora.frm.find("#txtCoordEste").val();
    data["COORDENADA_NORTE"] = _RegistroFlora.frm.find("#txtCoordNorte").val();
    data["OBSERVACION"] = _RegistroFlora.frm.find("#txtObservacion").val();
    return data;
}

_RegistroFlora.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_RegistroFlora.fnSubmitForm = function () {
    _RegistroFlora.frm.submit();
}

_RegistroFlora.fnInit = function (data) {
    _RegistroFlora.frm = $("#frmItemRegFlora");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _RegistroFlora.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });

    _RegistroFlora.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmFlora", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlRenderComboEspecieId':
            case 'ddlZonaId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _RegistroFlora.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlRenderComboEspecieId: { invalidFrmFlora: true },
            txtDap: { required: true },
            txtAltura: { required: true },
            ddlZonaId: { invalidFrmFlora: true },
            txtCoordEste: { required: true },
            txtCoordNorte: { required: true }
        },
        messages: {
            ddlRenderComboEspecieId: { invalidFrmFlora: "Seleccione la especie" },
            txtDap: { required: "Ingrese el DAP" },
            txtAltura: { required: "Ingrese la altura" },
            ddlZonaId: { invalidFrmFlora: "Seleccione la zona UTM" },
            txtCoordEste: { required: "Ingrese la coordenada este" },
            txtCoordNorte: { required: "Ingrese la coordenada norte" }
        },
        fnSubmit: function (form) {
            if (_RegistroFlora.fnCustomValidateForm()) {
                _RegistroFlora.fnSaveForm(_RegistroFlora.fnSetDatos());
            }
        }
    }));
    //Validación de controles que usan Select2
    _RegistroFlora.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}