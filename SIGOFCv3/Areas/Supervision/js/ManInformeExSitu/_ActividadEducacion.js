"use strict";
var _ActividadEducacion = {};

_ActividadEducacion.fnSaveForm = function (data, data_eli) { /*implementado desde donde se instancia*/ }
_ActividadEducacion.tbEliTABLA = [];

_ActividadEducacion.fnLoadDatos = function (data) {
    if (data != null && data != "") {
        _ActividadEducacion.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _ActividadEducacion.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _ActividadEducacion.frm.find("#ddlActividadId").select2("val", [data["COD_TDESCRIPTIVA"]]);
        _ActividadEducacion.frm.find("#txtFechaEvento").val(data["FECHA_EVENTO"]);
        _ActividadEducacion.frm.find("#txtObservacion").val(data["OBSERVACION"]);
        _ActividadEducacion.dtItemActEducacion_PObjetivo.rows.add(data["ListISupervision_exsitu_recinto_equipo"]).draw();
    } else {
        _ActividadEducacion.frm.find("#hdfRegEstado").val("1");
        _ActividadEducacion.frm.find("#hdfCodSecuencial").val("0");
    }
}

_ActividadEducacion.fnSetDatos = function () {
    var data = [];
    var regEstado = _ActividadEducacion.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_SECUENCIAL"] = _ActividadEducacion.frm.find("#hdfCodSecuencial").val();
    data["COD_TDESCRIPTIVA"] = _ActividadEducacion.frm.find("#ddlActividadId").val();
    data["DESCRIPCION"] = _ActividadEducacion.frm.find("#ddlActividadId").val() == "0000000" ? "" : _ActividadEducacion.frm.find("#ddlActividadId").select2("data")[0].text;
    data["FECHA_EVENTO"] = _ActividadEducacion.frm.find("#txtFechaEvento").val();
    data["OBSERVACION"] = _ActividadEducacion.frm.find("#txtObservacion").val();
    data["ListISupervision_exsitu_recinto_equipo"] = _ActividadEducacion.fnGetList();
    return data;
}

_ActividadEducacion.fnAddDetalle = function () {
    var data = {};

    if (!utilDt.existValorSearch(_ActividadEducacion.dtItemActEducacion_PObjetivo, "POBJETIVO_COD_TDESCRIPTIVA", _ActividadEducacion.frm.find("#ddlPublicoObjetivoId").val())) {
        data.POBJETIVO_COD_TDESCRIPTIVA = _ActividadEducacion.frm.find("#ddlPublicoObjetivoId").val();
        data.DESCRIPCION = _ActividadEducacion.frm.find("#ddlPublicoObjetivoId").select2("data")[0].text;
        data.RegEstado = 1;
        _ActividadEducacion.dtItemActEducacion_PObjetivo.rows.add([data]).draw();
    } else {
        utilSigo.toastWarning("Aviso", "El registro ya existe");
    }
}
_ActividadEducacion.fnDeleteDetalle = function (obj) {
    var data = _ActividadEducacion.dtItemActEducacion_PObjetivo.row($(obj).parents('tr')).data();
    if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {
        _ActividadEducacion.tbEliTABLA.push({
            EliTABLA: "CAUTI_PEAMBI_POBJETIVO",
            COD_ESPECIES: _ActividadEducacion.frm.find("#ddlActividadId").val(),
            COD_SECUENCIAL: _ActividadEducacion.frm.find("#hdfCodSecuencial").val(),
            CODIGO: data["POBJETIVO_COD_TDESCRIPTIVA"]
        });
    }
    _ActividadEducacion.dtItemActEducacion_PObjetivo.row($(obj).parents('tr')).remove().draw(false);
}

_ActividadEducacion.fnGetList = function () {
    var list = [], data;

    if (_ActividadEducacion.dtItemActEducacion_PObjetivo.$("tr").length > 0) {
        $.each(_ActividadEducacion.dtItemActEducacion_PObjetivo.$("tr"), function (i, o) {
            data = _ActividadEducacion.dtItemActEducacion_PObjetivo.row($(o)).data();
            if (data["RegEstado"]=="1") {
                list.push(utilSigo.fnConvertArrayToObject(data));
            }
        });
    }
    return list;
}

_ActividadEducacion.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {};

    columns_label = ["Descripción"];
    columns_data = ["DESCRIPCION"];
    options = {
        page_length: 5, row_delete: true, row_fnDelete: "_ActividadEducacion.fnDeleteDetalle(this)", row_index: true, page_sort: true
    };
    _ActividadEducacion.dtItemActEducacion_PObjetivo = utilDt.fnLoadDataTable_Detail(_ActividadEducacion.frm.find("#tbItemActEducacion_PObjetivo"), columns_label, columns_data, options);
}

_ActividadEducacion.fnSubmitForm = function () {
    _ActividadEducacion.frm.submit();
}

_ActividadEducacion.fnInit = function (data) {
    _ActividadEducacion.frm = $("#frmItemActEducacion");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _ActividadEducacion.frm.find("#ddlActividadId").select2({ minimumResultsForSearch: -1 });
    _ActividadEducacion.frm.find("#ddlPublicoObjetivoId").select2({ minimumResultsForSearch: -1 });
    utilSigo.fnFormatDate(_ActividadEducacion.frm.find("#txtFechaEvento"));

    _ActividadEducacion.fnInitDataTable_Detail();
    _ActividadEducacion.fnLoadDatos(data);

    _ActividadEducacion.frm.find("#ddlPublicoObjetivoId").change(function () {
        if ($(this).val() != "0000000") {
            _ActividadEducacion.fnAddDetalle();
            _ActividadEducacion.frm.find("#ddlPublicoObjetivoId").select2('val', ["0000000"]);
        }
    });

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    jQuery.validator.addMethod("invalidFrmEduc", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlActividadId':
                return (value == '0000000') ? false : true;
                break
        }
    });

    _ActividadEducacion.frm.validate(utilSigo.fnValidate({
        rules: {
            ddlActividadId: { invalidFrmEduc: true }
        },
        messages: {
            ddlActividadId: { invalidFrmEduc: "Seleccione el tema" }
        },
        fnSubmit: function (form) {
            _ActividadEducacion.fnSaveForm(_ActividadEducacion.fnSetDatos(), _ActividadEducacion.tbEliTABLA);
        }
    }));
    //Validación de controles que usan Select2
    _ActividadEducacion.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}