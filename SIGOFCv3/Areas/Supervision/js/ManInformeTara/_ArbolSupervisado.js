"use strict";
var _ArbolSupervisado = {};

_ArbolSupervisado.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_ArbolSupervisado.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _ArbolSupervisado.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _ArbolSupervisado.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _ArbolSupervisado.frm.find("#txtArea").val(data["PREDIO_AREA"]);
        _ArbolSupervisado.frm.find("#txtCodArbol").val(data["CODIGO_ARBOL"]);
        _ArbolSupervisado.frm.find("#ddlPresenciaVainaId").select2("val", [data["VAINAS_COD_PRESENCIA"]]);
        _ArbolSupervisado.frm.find("#ddlPresenciaFlorId").select2("val", [data["PRES_FLORES"] == true ? "SI" : "NO"]);
        _ArbolSupervisado.frm.find("#txtPresenciaPlaga").val(data["PRES_PLAGA_ENFERMEDA"]);
        _ArbolSupervisado.frm.find("#txtPresenciaPlanta").val(data["PRES_PLANTA_PARASITARIA"]);
        _ArbolSupervisado.frm.find("#txtAltura").val(data["ALTURA_TOTAL"]);
        _ArbolSupervisado.frm.find("#ddlZonaId").select2("val", [data["ZONA"] == '' ? "0000000" : data["ZONA"]]);
        _ArbolSupervisado.frm.find("#txtCEste").val(data["COORDENADA_ESTE"]);
        _ArbolSupervisado.frm.find("#txtCNorte").val(data["COORDENADA_NORTE"]);
        _ArbolSupervisado.frm.find("#txtObservacion").val(data["OBSERVACION"]);
    } else {
        _ArbolSupervisado.frm.find("#hdfRegEstado").val("1");
        _ArbolSupervisado.frm.find("#hdfCodSecuencial").val("0");
    }
}

_ArbolSupervisado.fnSetDatos = function () {
    var data = [];
    var regEstado = _ArbolSupervisado.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _ArbolSupervisado.frm.find("#hdfCodSecuencial").val();
    data["PREDIO_AREA"] = _ArbolSupervisado.frm.find("#txtArea").val();
    data["CODIGO_ARBOL"] = _ArbolSupervisado.frm.find("#txtCodArbol").val();
    data["VAINAS_COD_PRESENCIA"] = _ArbolSupervisado.frm.find("#ddlPresenciaVainaId").val();
    data["DESCRIPCION"] = _ArbolSupervisado.frm.find("#ddlPresenciaVainaId").val() == "0" ? "" : _ArbolSupervisado.frm.find("#ddlPresenciaVainaId").select2("data")[0].text;
    data["PRES_FLORES"] = _ArbolSupervisado.frm.find("#ddlPresenciaFlorId").val() == "SI" ? true : false;
    data["PRES_FLORES_TEXT"] = _ArbolSupervisado.frm.find("#ddlPresenciaFlorId").val() == "SI" ? "SI" : "NO";
    data["PRES_PLAGA_ENFERMEDA"] = _ArbolSupervisado.frm.find("#txtPresenciaPlaga").val();
    data["PRES_PLANTA_PARASITARIA"] = _ArbolSupervisado.frm.find("#txtPresenciaPlanta").val();
    data["ALTURA_TOTAL"] = _ArbolSupervisado.frm.find("#txtAltura").val();
    data["ZONA"] = _ArbolSupervisado.frm.find("#ddlZonaId").val() == "0000000" ? "" : _ArbolSupervisado.frm.find("#ddlZonaId").val();
    data["COORDENADA_ESTE"] = _ArbolSupervisado.frm.find("#txtCEste").val();
    data["COORDENADA_NORTE"] = _ArbolSupervisado.frm.find("#txtCNorte").val();
    data["OBSERVACION"] = _ArbolSupervisado.frm.find("#txtObservacion").val();
    return data;
}

_ArbolSupervisado.fnSubmitForm = function () {
    _ArbolSupervisado.frm.submit();
}

_ArbolSupervisado.fnInit = function (data) {
    _ArbolSupervisado.frm = $("#frmArbolSupervisado");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _ArbolSupervisado.frm.find("#ddlPresenciaVainaId").select2({ minimumResultsForSearch: -1 });
    _ArbolSupervisado.frm.find("#ddlPresenciaFlorId").select2({ minimumResultsForSearch: -1 });
    _ArbolSupervisado.frm.find("#ddlZonaId").select2({ minimumResultsForSearch: -1 });

    _ArbolSupervisado.fnLoadDatos(data);

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmArbol", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlPresenciaVainaId':
            case 'ddlPresenciaFlorId':
                return (value == '0000000' || value == '0') ? false : true;
                break
        }
    });
    _ArbolSupervisado.frm.validate(utilSigo.fnValidate({
        rules: {
            txtArea: { required: true },
            txtCodArbol: { required: true },
            ddlPresenciaVainaId: { invalidFrmArbol: true },
            ddlPresenciaFlorId: { invalidFrmArbol: true },
            txtAltura: { required: true },
            txtCEste: { required: true },
            txtCNorte: { required: true }
        },
        messages: {
            txtArea: { required: "Ingrese el predio/área" },
            txtCodArbol: { required: "Ingrese el código del árbol" },
            ddlPresenciaVainaId: { invalidFrmArbol: "Seleccione una opción" },
            ddlPresenciaFlorId: { invalidFrmArbol: "Seleccione una opción" },
            txtAltura: { required: "Ingrese la altura total" },
            txtCEste: { required: "Ingrese la coordenada este" },
            txtCNorte: { required: "Ingrese la coordenada norte" }
        },
        fnSubmit: function (form) {
            _ArbolSupervisado.fnSaveForm(_ArbolSupervisado.fnSetDatos());
        }
    }));

    //Validación de controles que usan Select2
    _ArbolSupervisado.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}