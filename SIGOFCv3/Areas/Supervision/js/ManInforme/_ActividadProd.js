"use strict";
var _ActividadProd = {};

_ActividadProd.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_ActividadProd.fnAgregarEspecie = function () {
    let codEspecie = _renderComboEspecie.fnGetCodEspecie();
    let descEspecie = _renderComboEspecie.fnGetEspecie();
    if (codEspecie == "" || codEspecie == null || codEspecie === "undefined") {
        utilSigo.toastWarning("Aviso", "Para agregar especie debe seleccionar una especie."); return false;
    } else {
        if ($("#hdfCodEspeciesActProd").val().includes(codEspecie)) {
            utilSigo.toastWarning("Aviso", "La especie ya fue agregado."); return false;
        } else {
            if ($("#hdfCodEspeciesActProd").val() == "" || $("#hdfCodEspeciesActProd").val() == " ") {
                $("#hdfCodEspeciesActProd").val(codEspecie);
                $("#txtEspecieActProd").val(descEspecie);
            } else {
                $("#hdfCodEspeciesActProd").val($("#hdfCodEspeciesActProd").val() + "," + codEspecie);
                $("#txtEspecieActProd").val($("#txtEspecieActProd").val() + ", " + descEspecie);
            }
            $('#ddlRenderComboEspecieId').val("").trigger("change");
        }        
    }
}
_ActividadProd.fnClearEspecie = function (data) {
    $("#txtEspecieActProd").val("");
    $("#hdfCodEspeciesActProd").val("");
}

_ActividadProd.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _ActividadProd.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _ActividadProd.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _ActividadProd.frm.find("#txtActividadActProd").val(data["ACTIVIDAD"]);
        _ActividadProd.frm.find("#txtAreaActProd").val(data["AREA"]);
        //Especie
        _ActividadProd.frm.find("#hdfCodEspeciesActProd").val(data["COD_ESPECIES"]);
        _ActividadProd.frm.find("#txtEspecieActProd").val(data["DESC_ESPECIES"]);

        _ActividadProd.frm.find("#txtEdadActProd").val(data["EDAD"]);
        _ActividadProd.frm.find("#txtRendimientoActProd").val(data["RENDIMIENTO"]);
        _ActividadProd.frm.find("#txtCoordEsteActProd").val(data["COORDENADA_ESTE"]);
        _ActividadProd.frm.find("#txtCoordNorteActProd").val(data["COORDENADA_NORTE"]);
        _ActividadProd.frm.find("#txtAltitudActProd").val(data["ALTITUD"]);
        _ActividadProd.frm.find("#ddlDestinoActProdId").val(data["DESTINO_PRODUCCION"]);
        _ActividadProd.frm.find("#ddlEstadoCulActProdId").val(data["ESTADO_CULTIVO"]);

        _renderComboEspecie.fnInit("FORESTAL", "", "");
    } else {
        _ActividadProd.frm.find("#hdfRegEstado").val("1");
        _ActividadProd.frm.find("#hdfCodSecuencial").val("0");
        _renderComboEspecie.fnInit("FORESTAL", "", "");
    }
}

_ActividadProd.fnSetDatos = function () {
    var data = [];
    var regEstado = _ActividadProd.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _ActividadProd.frm.find("#hdfCodSecuencial").val();
    data["ACTIVIDAD"] = _ActividadProd.frm.find("#txtActividadActProd").val();
    data["AREA"] = _ActividadProd.frm.find("#txtAreaActProd").val();
    //Especie
    data["COD_ESPECIES"] = _ActividadProd.frm.find("#hdfCodEspeciesActProd").val();
    data["DESC_ESPECIES"] = _ActividadProd.frm.find("#txtEspecieActProd").val();

    data["EDAD"] = _ActividadProd.frm.find("#txtEdadActProd").val();
    data["RENDIMIENTO"] = _ActividadProd.frm.find("#txtRendimientoActProd").val();
    data["COORDENADA_ESTE"] = _ActividadProd.frm.find("#txtCoordEsteActProd").val();
    data["COORDENADA_NORTE"] = _ActividadProd.frm.find("#txtCoordNorteActProd").val();
    data["ALTITUD"] = _ActividadProd.frm.find("#txtAltitudActProd").val();
    data["DESTINO_PRODUCCION"] = _ActividadProd.frm.find("#ddlDestinoActProdId").val();
    data["ESTADO_CULTIVO"] = _ActividadProd.frm.find("#ddlEstadoCulActProdId").val();
    return data;
}

_ActividadProd.fnCustomValidateForm = function () {
    debugger;
    if ($("#hdfCodEspeciesActProd").val() == "" || $("#hdfCodEspeciesActProd").val() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione al menos una especie a registrar"); return false;
    }

    return true;
}

_ActividadProd.fnSubmitForm = function () {
    //const fechaActual = new Date();

    //let fecha = ($("#txtFecha").val()).split('/');

    //if (fecha.length == 3) {
    //    let fechaStr = fecha[2] + "-" + fecha[1] + "-" + fecha[0]
    //    const fechaIngresada = new Date(fechaStr);
    //    if (fechaActual > fechaIngresada) {
    //        _ActividadProd.frm.submit();
    //    } else {
    //        utilSigo.toastWarning("Aviso", "La Fecha seleccionada no debe ser mayor a la actual."); return false;
    //    }
    //} else {
    //    utilSigo.toastWarning("Aviso", "La Fecha seleccionada no es válido."); return false;
    //}
    _ActividadProd.frm.submit();

}

_ActividadProd.fnInit = function (data) {
    _ActividadProd.frm = $("#frmItemActividadProd");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    //_ActividadProd.frm.find("#ddlTipoAvistRegistroId").select2({ minimumResultsForSearch: -1 });
    //_ActividadProd.frm.find("#ddlTipoAvistEstratoId").select2({ minimumResultsForSearch: -1 });
    //_ActividadProd.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });
    //utilSigo.fnFormatDate(_ActividadProd.frm.find("#txtFecha"));

    _ActividadProd.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmActividadProd", function (value, element) {
        switch ($(element).attr('id')) {
            case 'hdfCodEspeciesActProd':
                return (value == '0000000') ? false : true;
                break
        }
    });
    _ActividadProd.frm.validate(utilSigo.fnValidate({
        rules: {
            //hdfCodEspeciesActProd: { required: true },
            txtActividadActProd: { required: true },
            txtAreaActProd: { required: true },
            txtEdadActProd: { required: true },
            txtRendimientoActProd: { required: true },
            txtCoordEsteActProd: { required: true },
            txtCoordNorteActProd: { required: true }
        },
        messages: {
            //hdfCodEspeciesActProd: { required: "Ingrese al menos una Especie" },
            txtActividadActProd: { required: "Ingrese la Actividad Productiva" },
            txtAreaActProd: { required: "Ingrese el área de Actividad Productiva" },
            txtEdadActProd: { required: "Ingrese la edad de Actividad Productiva" },
            txtRendimientoActProd: { required: "Ingrese el rendimiento de Actividad Productiva" },
            txtCoordEsteActProd: { required: "Ingrese la coordinada Norte de Actividad Productiva" },
            txtCoordNorteActProd: { required: "Ingrese la coordinada Norte de Actividad Productiva" },
        },
        fnSubmit: function (form) {
            if (_ActividadProd.fnCustomValidateForm()) {
                _ActividadProd.fnSaveForm(_ActividadProd.fnSetDatos());
            }
        }
    }));
    //Validación de controles que usan Select2
    _ActividadProd.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}