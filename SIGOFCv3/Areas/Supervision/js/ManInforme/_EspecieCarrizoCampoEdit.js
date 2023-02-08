"use strict";
var _EspecieCarrizoCampoEdit = {};

_EspecieCarrizoCampoEdit.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_EspecieCarrizoCampoEdit.fnLoadDatos = function (data) {
    var regEstado = "1";
    if (data != null && data != "") {
        if (data.data[0]["COD_MUESTRA_SUPERVISION"] != "") {
            regEstado = "0";
        }   
        _EspecieCarrizoCampoEdit.frm.find("#hdfRegEstado").val(regEstado);
        _EspecieCarrizoCampoEdit.frm.find("#hdfCodTHabilitante").val(data.data[0]["COD_THABILITANTE"]);
        _EspecieCarrizoCampoEdit.frm.find("#hdfCodMuestra").val(data.data[0]["COD_MUESTRA_SUPERVISION"]);
        _EspecieCarrizoCampoEdit.frm.find("#txtTotalMuestra").val(data.data[0]["TOTAL_UNIDAD_MUEST"]);
        _EspecieCarrizoCampoEdit.frm.find("#txtTotalMuestraAprov").val(data.data[0]["TOTAL_UNIDADES_APROV"]);
        //_EspecieCarrizoCampoEdit.frm.find("#txtUnidadMedida").val(data.data[0]["UNIDAD_MEDIDA"]);
        //_EspecieCarrizoCampoEdit.frm.find("#txtNumIndividuo").val(data.data[0]["NUM_INDIVIDUOS"]);
        _EspecieCarrizoCampoEdit.frm.find("#ddlZonaId").select2("val", [data.data[0]["ZONA"] == "" ? "0000000" : data.data[0]["ZONA"]]);
        _EspecieCarrizoCampoEdit.frm.find("#txtCEste").val(data.data[0]["COORDENADA_ESTE"]);
        _EspecieCarrizoCampoEdit.frm.find("#txtCNorte").val(data.data[0]["COORDENADA_NORTE"]);
        _EspecieCarrizoCampoEdit.frm.find("#ddlProductoId").select2("val", [data.data[0]["PRODUCTO_EXTRAER"] == "" ? "0000000" : data.data[0]["PRODUCTO_EXTRAER"]]);
        _EspecieCarrizoCampoEdit.frm.find("#txtObservacion").val(data.data[0]["OBSERVACION"]);
        _renderComboEspecie.fnInit("FORESTAL", data.data[0]["COD_ESPECIES"], data.data[0]["ESPECIES"]);
    } else {
        _EspecieCarrizoCampoEdit.frm.find("#hdfRegEstado").val("1");
        _renderComboEspecie.fnInit("FORESTAL", "", "");
    }
}

_EspecieCarrizoCampoEdit.fnSetDatos = function () {
    var data = [];
    var regEstado = _EspecieCarrizoCampoEdit.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_INFORME"] = _EspecieCarrizoCampoEdit.frm.find("#hdfCodInforme").val();
    data["NUM_POA"] = _EspecieCarrizoCampoEdit.frm.find("#hdfNumPoa").val();
    data["COD_MUESTRA_SUPERVISION"] = _EspecieCarrizoCampoEdit.frm.find("#hdfCodMuestra").val();
    data["COD_THABILITANTE"] = _EspecieCarrizoCampoEdit.frm.find("#hdfCodTHabilitante").val();
    data["COD_ESPECIES"] = _renderComboEspecie.fnGetCodEspecie();
    data["ESPECIES"] = _renderComboEspecie.fnGetEspecie();
    data["TOTAL_UNIDAD_MUEST"]=_EspecieCarrizoCampoEdit.frm.find("#txtTotalMuestra").val();
    data["TOTAL_UNIDADES_APROV"]=_EspecieCarrizoCampoEdit.frm.find("#txtTotalMuestraAprov").val();
    //data["UNIDAD_MEDIDA"]=_EspecieCarrizoCampoEdit.frm.find("#txtUnidadMedida").val();
    //data["NUM_INDIVIDUOS"]=_EspecieCarrizoCampoEdit.frm.find("#txtNumIndividuo").val();
    data["ZONA"] = _EspecieCarrizoCampoEdit.frm.find("#ddlZonaId").val();
    data["COORDENADA_ESTE"] = _EspecieCarrizoCampoEdit.frm.find("#txtCEste").val();
    data["COORDENADA_NORTE"] = _EspecieCarrizoCampoEdit.frm.find("#txtCNorte").val();
    data["PRODUCTO_EXTRAER"] = _EspecieCarrizoCampoEdit.frm.find("#ddlProductoId").val();
    data["OBSERVACION"] = _EspecieCarrizoCampoEdit.frm.find("#txtObservacion").val();
    return data;
}

_EspecieCarrizoCampoEdit.fnCustomValidateForm = function () {
    if (_renderComboEspecie.fnGetCodEspecie() == null) {
        utilSigo.toastWarning("Aviso", "Seleccione la especie a registrar"); return false;
    }
    return true;
}

_EspecieCarrizoCampoEdit.fnSubmitForm = function () {
    _EspecieCarrizoCampoEdit.frm.submit();
}

_EspecieCarrizoCampoEdit.fnInit = function (data) {
    _EspecieCarrizoCampoEdit.frm = $("#frmItemCarrizoCampoEdit");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EspecieCarrizoCampoEdit.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });
    _EspecieCarrizoCampoEdit.frm.find("#ddlProductoId").select2({ minimumResultsForSearch: -1 });

    _EspecieCarrizoCampoEdit.fnLoadDatos(data);

    _EspecieCarrizoCampoEdit.frm.find(".dvDatosCarrizo").hide();
    _EspecieCarrizoCampoEdit.frm.find(".dvDatosPlantaMedicinal").hide();
    if (_EspecieCarrizoCampoEdit.frm.find("#hdfCodMTipo").val()=="0000020") {
        _EspecieCarrizoCampoEdit.frm.find(".dvDatosCarrizo").show();
    } else {
        _EspecieCarrizoCampoEdit.frm.find(".dvDatosPlantaMedicinal").show();
    }

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmCarrizo", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlProductoId':
            case 'ddlZonaId':
                return (value == '0000000') ? false : true;
                break
        }
    });

    if (_EspecieCarrizoCampoEdit.frm.find("#hdfCodMTipo").val() == "0000020") {
        _EspecieCarrizoCampoEdit.frm.validate(utilSigo.fnValidate({
            rules: {
                txtTotalMuestra: { required: true },
                txtTotalMuestraAprov: { required: true },
                ddlZonaId: { invalidFrmCarrizo: true },
                txtCEste: { required: true, minlenfrmCEste: true  },
                txtCNorte: { required: true, minlenfrmCNorte: true  },
                ddlProductoId: { invalidFrmCarrizo: true }
            },
            messages: {
                txtTotalMuestra: { required: "Ingrese el total unidades por muestra" },
                txtTotalMuestraAprov: { required: "Ingrese el total unidades aprovechables por muestra" },
                ddlZonaId: { invalidFrmCarrizo: "Seleccione la zona UTM" },
                txtCEste: { required: "Ingrese la coordenada este", minlenfrmCEste: "Ingrese una coordenada de 6 digitos" },
                txtCNorte: { required: "Ingrese la coordenada norte", minlenfrmCNorte: "Ingrese una coordenada de 7 digitos" },
                ddlProductoId: { invalidFrmCarrizo: "Ingrese producto a extraer" }
            },
            fnSubmit: function (form) {
                if (_EspecieCarrizoCampoEdit.fnCustomValidateForm()) {
                    var oEspecie = utilSigo.fnConvertArrayToObject(_EspecieCarrizoCampoEdit.fnSetDatos());
                    var url = urlLocalSigo + "Supervision/ManInforme/GrabarEspecieCarrizoCampo";
                    var option = { url: url, datos: JSON.stringify(oEspecie), type: 'POST' };
                    utilSigo.fnAjax(option, function (data) {
                        if (data.success) {
                            oEspecie["RegEstado"] = 0;
                            _EspecieCarrizoCampoEdit.fnSaveForm(oEspecie);
                            utilSigo.toastSuccess("Aviso", "Datos guardados correctamente");
                            Limpiar();
                        }
                        else {
                            utilSigo.toastWarning("Aviso", data.msj);
                        }
                    });
                }
            }
        }));
    } else {
        _EspecieCarrizoCampoEdit.frm.validate(utilSigo.fnValidate({
            rules: {
                //txtUnidadMedida: { required: true },
                txtNumIndividuo: { required: true },
                ddlZonaId: { invalidFrmCarrizo: true },
                txtCEste: { required: true },
                txtCNorte: { required: true },
                ddlProductoId: { invalidFrmCarrizo: true }
            },
            messages: {
                //txtUnidadMedida: { required: "Ingrese la unidad de medida" },
                txtNumIndividuo: { required: "Ingrese el número de individuos" },
                ddlZonaId: { invalidFrmCarrizo: "Seleccione la zona UTM" },
                txtCEste: { required: "Ingrese la coordenada este" },
                txtCNorte: { required: "Ingrese la coordenada norte" },
                ddlProductoId: { invalidFrmCarrizo: "Seleccione el producto a extraer" }
            },
            fnSubmit: function (form) {
                if (_EspecieCarrizoCampoEdit.fnCustomValidateForm()) {
                    var oEspecie = utilSigo.fnConvertArrayToObject(_EspecieCarrizoCampoEdit.fnSetDatos());
                    var url = urlLocalSigo + "Supervision/ManInforme/GrabarEspecieCarrizoCampo";
                    var option = { url: url, datos: JSON.stringify(oEspecie), type: 'POST' };
                    utilSigo.fnAjax(option, function (data) {
                        if (data.success) {
                            oEspecie["RegEstado"] = 0;
                            _EspecieCarrizoCampoEdit.fnSaveForm(oEspecie);
                        }
                        else {
                            utilSigo.toastWarning("Aviso", data.msj);
                        }
                    });
                }
            }
        }));
    }

    
    //Validación de controles que usan Select2
    _EspecieCarrizoCampoEdit.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}

function Limpiar() {
    var sel = document.getElementById("ddlRenderComboEspecieId");
    sel.remove(sel.selectedIndex);

    _EspecieCarrizoCampoEdit.frm = $("#frmItemCarrizoCampoEdit");
    var regEstado = "1"; // Nuevo

    _EspecieCarrizoCampoEdit.frm.find("#hdfRegEstado").val(regEstado);
    _EspecieCarrizoCampoEdit.frm.find("#hdfCodSecuencial").val("0");
    _EspecieCarrizoCampoEdit.frm.find("#hdfCodEspecie").val("");    
    _EspecieCarrizoCampoEdit.frm.find("#txtTotalMuestra").val("");
    _EspecieCarrizoCampoEdit.frm.find("#txtTotalMuestraAprov").val("");
    //_EspecieCarrizoCampoEdit.frm.find("#txtUnidadMedida").val("");
    //_EspecieCarrizoCampoEdit.frm.find("#txtNumIndividuo").val("");
    _EspecieCarrizoCampoEdit.frm.find("#ddlZonaId").val("0000000");
    $('#ddlZonaId').select2().trigger('change');
    _EspecieCarrizoCampoEdit.frm.find("#txtCEste").val("");
    _EspecieCarrizoCampoEdit.frm.find("#txtCNorte").val("");    
    _EspecieCarrizoCampoEdit.frm.find("#ddlProductoId").val("0000000");
    $('#ddlProductoId').select2().trigger('change');
    _EspecieCarrizoCampoEdit.frm.find("#txtObservacion").val("");
    _renderComboEspecie.fnInit("FORESTAL", '', '');

}

jQuery.validator.addMethod("minlenfrmCEste", function (value, element) {
    switch ($(element).attr('id')) {
        case 'txtCEste':
            return (value.trim().length < 6 || value.trim().length > 6) ? false : true;
            break;
    }
});
jQuery.validator.addMethod("minlenfrmCNorte", function (value, element) {
    switch ($(element).attr('id')) {
        case 'txtCNorte':
            return (value.trim().length < 7 || value.trim().length > 7) ? false : true;
            break;
    }
});