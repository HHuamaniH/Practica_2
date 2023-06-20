"use strict";
var _AvistamientoFauna = {};

_AvistamientoFauna.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_AvistamientoFauna.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _AvistamientoFauna.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _AvistamientoFauna.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _AvistamientoFauna.frm.find("#txtNombreComun").val(data["NOMBRE_COMUN"]);
        _AvistamientoFauna.frm.find("#txtNumIndividuo").val(data["NUM_INDIVIDUOS"]);
        _AvistamientoFauna.frm.find("#ddlTipoAvistRegistroId").select2("val", [data["COD_TIPO_REGISTRO"]]);
        _AvistamientoFauna.frm.find("#ddlTipoAvistEstratoId").select2("val", [data["COD_ESTRATO"]]);
        _AvistamientoFauna.frm.find("#txtFecha").val(data["FECHA_AVISTAMIENTO"]);
        _AvistamientoFauna.frm.find("#txtHora").val(data["HORA_AVISTAMIENTO"]);
        _AvistamientoFauna.frm.find("#ddlZonaId").select2("val", [data["ZONA"]]);
        _AvistamientoFauna.frm.find("#txtCoordEste").val(data["COORDENADA_ESTE"]);
        _AvistamientoFauna.frm.find("#txtCoordNorte").val(data["COORDENADA_NORTE"]);
        _AvistamientoFauna.frm.find("#txtAltitud").val(data["ALTITUD"]);
        _AvistamientoFauna.frm.find("#txtDescripcion").val(data["DESCRIPCION"]);
        _renderComboEspecie.fnInit("FAUNA", data["COD_ESPECIES"], data["DESC_ESPECIES"]);
    } else {
        _AvistamientoFauna.frm.find("#hdfRegEstado").val("1");
        _AvistamientoFauna.frm.find("#hdfCodSecuencial").val("0");
        _renderComboEspecie.fnInit("FAUNA", "", "");
    }
}

_AvistamientoFauna.fnSetDatos = function () {
    var data = [];
    var regEstado = _AvistamientoFauna.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _AvistamientoFauna.frm.find("#hdfCodSecuencial").val();
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["DESC_ESPECIES"] = _renderComboEspecie.fnGetEspecie();
    data["NOMBRE_COMUN"] = _AvistamientoFauna.frm.find("#txtNombreComun").val();
    data["NUM_INDIVIDUOS"] = _AvistamientoFauna.frm.find("#txtNumIndividuo").val();
    data["COD_TIPO_REGISTRO"] = _AvistamientoFauna.frm.find("#ddlTipoAvistRegistroId").val();
    data["DESC_TIPO_REGISTRO"] = data["COD_TIPO_REGISTRO"] == "0000000" ? "" : _AvistamientoFauna.frm.find("#ddlTipoAvistRegistroId").select2("data")[0].text;
    data["COD_ESTRATO"] = _AvistamientoFauna.frm.find("#ddlTipoAvistEstratoId").val();
    data["DESC_ESTRATO"] = data["COD_ESTRATO"] == "0000000" ? "" : _AvistamientoFauna.frm.find("#ddlTipoAvistEstratoId").select2("data")[0].text;
    data["FECHA_AVISTAMIENTO"] = _AvistamientoFauna.frm.find("#txtFecha").val();
    data["HORA_AVISTAMIENTO"] = _AvistamientoFauna.frm.find("#txtHora").val();
    data["ZONA"] = _AvistamientoFauna.frm.find("#ddlZonaId").val();
    data["COORDENADA_ESTE"] = _AvistamientoFauna.frm.find("#txtCoordEste").val();
    data["COORDENADA_NORTE"] = _AvistamientoFauna.frm.find("#txtCoordNorte").val();
    data["ALTITUD"] = _AvistamientoFauna.frm.find("#txtAltitud").val();
    data["DESCRIPCION"] = _AvistamientoFauna.frm.find("#txtDescripcion").val();
    return data;
}

_AvistamientoFauna.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_AvistamientoFauna.fnSubmitForm = function () {
    const fechaActual = new Date();

    let fecha = ($("#txtFecha").val()).split('/');

    if (fecha.length == 3) {
        let fechaStr = fecha[2] + "-" + fecha[1] + "-" + fecha[0]
        const fechaIngresada = new Date(fechaStr);
        if (fechaActual > fechaIngresada) {
            _AvistamientoFauna.frm.submit();
        } else {
            utilSigo.toastWarning("Aviso", "La Fecha seleccionada no debe ser mayor a la actual."); return false;
        }
    } else {
        utilSigo.toastWarning("Aviso", "La Fecha seleccionada no es válido."); return false;
    }


}

_AvistamientoFauna.fnInit = function (data) {
    _AvistamientoFauna.frm = $("#frmItemAvistamientoFauna");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _AvistamientoFauna.frm.find("#ddlTipoAvistRegistroId").select2({ minimumResultsForSearch: -1 });
    _AvistamientoFauna.frm.find("#ddlTipoAvistEstratoId").select2({ minimumResultsForSearch: -1 });
    _AvistamientoFauna.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });
    utilSigo.fnFormatDate(_AvistamientoFauna.frm.find("#txtFecha"));

    _AvistamientoFauna.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmFauna", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlRenderComboEspecieId':
            case 'ddlZonaId':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _AvistamientoFauna.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlRenderComboEspecieId: { invalidFrmFauna: true },
            txtNumIndividuo: { required: true },
            txtFecha: { required: true },
            txtHora: { required: true },
            ddlZonaId: { invalidFrmFauna: true },
            txtCoordEste: { required: true },
            txtCoordNorte: { required: true },
            txtAltitud: { required: true }
        },
        messages: {
            ddlRenderComboEspecieId: { invalidFrmFauna: "Seleccione la especie" },
            txtNumIndividuo: { required: "Ingrese el número de individuos" },
            txtFecha: { required: "Ingrese la fecha de avistamiento" },
            txtHora: { required: "Ingrese la hora de avistamiento" },
            ddlZonaId: { invalidFrmFauna: "Seleccione la zona UTM" },
            txtCoordEste: { required: "Ingrese la coordenada este" },
            txtCoordNorte: { required: "Ingrese la coordenada norte" },
            txtAltitud: { required: "Ingrese la altitud" }
        },
        fnSubmit: function (form) {
            if (_AvistamientoFauna.fnCustomValidateForm()) {
                _AvistamientoFauna.fnSaveForm(_AvistamientoFauna.fnSetDatos());
            }
        }
    }));
    //Validación de controles que usan Select2
    _AvistamientoFauna.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}