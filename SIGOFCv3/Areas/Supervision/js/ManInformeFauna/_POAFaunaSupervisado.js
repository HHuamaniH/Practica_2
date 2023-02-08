"use strict";
var _POAFaunaSupervisado = {};
//Variables Golbales
_POAFaunaSupervisado.tbEliTABLA = [];
_POAFaunaSupervisado.DataCoordenada = [];
_POAFaunaSupervisado.DataInfraesImpl = [];
_POAFaunaSupervisado.DataZonificacion = [];
_POAFaunaSupervisado.DataAprovSostenible = [];

_POAFaunaSupervisado.fnLoadData = function (obj, _tipo) {
    switch (_tipo) {
        case "DataCoordenada": _POAFaunaSupervisado.DataCoordenada = JSON.parse(obj); break;
        case "DataInfraesImpl": _POAFaunaSupervisado.DataInfraesImpl = JSON.parse(obj); break;
        case "DataZonificacion": _POAFaunaSupervisado.DataZonificacion = JSON.parse(obj); break;
        case "DataAprovSostenible": _POAFaunaSupervisado.DataAprovSostenible = JSON.parse(obj); break;
    }
}

_POAFaunaSupervisado.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {}, data_extend = [];

    //Cargar Coordenadas UTM
    columns_label = ["Vértice", "Zona UTM", "Zona UTM Campo", "Coordenada Este", "Coordenada Este Campo","Coordenada Norte","Coordenada Norte Campo"];
    columns_data = ["VERTICE", "ZONA", "ZONA_CAMPO", "COORDENADA_ESTE", "COORDENADA_ESTE_CAMPO", "COORDENADA_NORTE", "COORDENADA_NORTE_CAMPO"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "_POAFaunaSupervisado.fnAddEditFauna(this,'COORDENADA_UTM')"
        , row_delete: true, row_fnDelete: "_POAFaunaSupervisado.fnDeleteFauna('COORDENADA_UTM',this)", row_index: true, page_sort: true
    };
    _POAFaunaSupervisado.dtCoordenadaUtm = utilDt.fnLoadDataTable_Detail(_POAFaunaSupervisado.frm.find("#tbCoordenadaUtm"), columns_label, columns_data, options);
    _POAFaunaSupervisado.dtCoordenadaUtm.rows.add(_POAFaunaSupervisado.DataCoordenada).draw();
    //Cargar Infraestructura Implementada
    columns_label = ["Descripción", "Área", "Uso", "Estado Conservación", "Objetivo"];
    columns_data = ["DESCRIPCION", "AREA", "USO", "ESTADO_CONSERVACION", "OBJETIVO"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "_POAFaunaSupervisado.fnAddEditFauna(this,'INFRAESTRUCTURA')"
        , row_delete: true, row_fnDelete: "_POAFaunaSupervisado.fnDeleteFauna('INFRAESTRUCTURA',this)", row_index: true, page_sort: true
    };
    _POAFaunaSupervisado.dtInfraestructuraImp = utilDt.fnLoadDataTable_Detail(_POAFaunaSupervisado.frm.find("#tbInfraestructuraImp"), columns_label, columns_data, options);
    _POAFaunaSupervisado.dtInfraestructuraImp.rows.add(_POAFaunaSupervisado.DataInfraesImpl).draw();
    //Cargar Zonificación de las Especies a Manejar
    columns_label = ["Nombre Zona", "Característica", "Zona UTM", "Coordenada Este", "Coordenada Norte","Tipo Señalización","Tipo Delimitación"];
    columns_data = ["NOMBRE_ZONA", "CARACTERISTICA", "ZONA", "COORDENADA_ESTE", "COORDENADA_NORTE", "TIPO_SENALIZACION", "TIPO_DELIMITACION"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "_POAFaunaSupervisado.fnAddEditFauna(this,'ZONIFICACION')"
        , row_delete: true, row_fnDelete: "_POAFaunaSupervisado.fnDeleteFauna('ZONIFICACION',this)", row_index: true, page_sort: true
    };
    _POAFaunaSupervisado.dtZonificacion = utilDt.fnLoadDataTable_Detail(_POAFaunaSupervisado.frm.find("#tbZonificacion"), columns_label, columns_data, options);
    _POAFaunaSupervisado.dtZonificacion.rows.add(_POAFaunaSupervisado.DataZonificacion).draw();
    //Cargar Aprovechamiento Sostenible
    columns_label = ["Especie", "Periodo", "Cuota Saca", "Personal Encargado", "Método de Caza o Captura", "Sistema de Marcaje o Identificación", "Partes o Derivados a Aprovechar"];
    columns_data = ["DESC_ESPECIES", "PERIODO", "CUOTA_SACA", "PERSONAL", "METODO_CAZA", "SISTEMA_MARCAJE", "APROVECHAR"];
    options = {
        page_length: 10, row_edit: true, row_fnEdit: "_POAFaunaSupervisado.fnAddEditFauna(this,'APROVECHAMIENTO')"
        , row_delete: true, row_fnDelete: "_POAFaunaSupervisado.fnDeleteFauna('APROVECHAMIENTO',this)", row_index: true, page_sort: true
    };
    _POAFaunaSupervisado.dtAprovSostenible = utilDt.fnLoadDataTable_Detail(_POAFaunaSupervisado.frm.find("#tbAprovSostenible"), columns_label, columns_data, options);
    _POAFaunaSupervisado.dtAprovSostenible.rows.add(_POAFaunaSupervisado.DataAprovSostenible).draw();
}

_POAFaunaSupervisado.fnAddEditFauna = function (obj, _tipo) {
    var url = urlLocalSigo, dt = null, _funcModal = {};

    switch (_tipo) {
        case "COORDENADA_UTM":
            url += "Supervision/ManInformeConservacion/_CoordenadaUTM";
            dt = _POAFaunaSupervisado.dtCoordenadaUtm;
            break;
        case "INFRAESTRUCTURA":
            url += "Supervision/ManInformeFauna/_InfraestructuraImpl";
            dt = _POAFaunaSupervisado.dtInfraestructuraImp;
            break;
        case "ZONIFICACION":
            url += "Supervision/ManInformeFauna/_Zonificacion";
            dt = _POAFaunaSupervisado.dtZonificacion;
            break;
        case "APROVECHAMIENTO":
            url += "Supervision/ManInformeFauna/_AprovSostenible";
            dt = _POAFaunaSupervisado.dtAprovSostenible;
            break;
    }

    var option = { url: url, type: 'POST', datos: {}, divId: "mdlManInformeFauna" };
    utilSigo.fnOpenModal(option, function () {
        switch (_tipo) {
            case "COORDENADA_UTM": _funcModal = _CoordenadaUTM; break;
            case "INFRAESTRUCTURA": _funcModal = _InfraestructuraImpl; break;
            case "ZONIFICACION": _funcModal = _Zonificacion; break;
            case "APROVECHAMIENTO": _funcModal = _AprovSostenible; break;
        }

        _funcModal.fnSaveForm = function (data) {
            if (data != null) {
                if (obj == null || obj == "") {//Nuevo Registro
                    dt.rows.add([data]).draw();
                    dt.page('last').draw('page');
                    utilSigo.toastSuccess("Exito", "Datos guardados correctamente");
                } else {//Modificar
                    var row = dt.row($(obj).parents('tr')).data();
                    row = data;
                    dt.row($(obj).parents('tr')).data(row).draw(false);
                    utilSigo.toastSuccess("Exito", "Datos actualizados correctamente");
                }
                $("#mdlManInformeFauna").modal('hide');
            } else {
                utilSigo.toastError("Error", "No se pudieron guardar los datos");
            }
        }

        if (obj != null && obj != "") {
            var data = dt.row($(obj).parents('tr')).data();
            _funcModal.fnInit(utilSigo.fnConvertArrayToObject(data));
        } else { _funcModal.fnInit(""); }
    });
}
_POAFaunaSupervisado.fnGetListFauna = function (_tipo) {
    var dt, list = [], data;
    switch (_tipo) {
        case "COORDENADA_UTM": dt = _POAFaunaSupervisado.dtCoordenadaUtm; break;
        case "INFRAESTRUCTURA": dt = _POAFaunaSupervisado.dtInfraestructuraImp; break;
        case "ZONIFICACION": dt = _POAFaunaSupervisado.dtZonificacion; break;
        case "APROVECHAMIENTO": dt = _POAFaunaSupervisado.dtAprovSostenible; break;
    }

    if (dt.$("tr").length > 0) {
        $.each(dt.$("tr"), function (i, o) {
            data = dt.row($(o)).data();
            if (data["RegEstado"] == "1" || data["RegEstado"] == "2") {
                list.push(utilSigo.fnConvertArrayToObject(data));
            }
        });
    }
    return list;
}
_POAFaunaSupervisado.fnDeleteFauna = function (_tipo, obj, objData) {
    var dt, data;
    switch (_tipo) {
        case "COORDENADA_UTM": dt = _POAFaunaSupervisado.dtCoordenadaUtm; break;
        case "INFRAESTRUCTURA": dt = _POAFaunaSupervisado.dtInfraestructuraImp; break;
        case "ZONIFICACION": dt = _POAFaunaSupervisado.dtZonificacion; break;
        case "APROVECHAMIENTO": dt = _POAFaunaSupervisado.dtAprovSostenible; break;
    }

    data = typeof objData !== 'undefined' ? objData : dt.row($(obj).parents('tr')).data();

    if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {
        switch (_tipo) {
            case "COORDENADA_UTM":
                _POAFaunaSupervisado.tbEliTABLA.push({
                    EliTABLA: "ISUPERVISION_DET_COORDENADAUTM",
                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                });
                break;
            case "INFRAESTRUCTURA":
                _POAFaunaSupervisado.tbEliTABLA.push({
                    EliTABLA: "ListISUPERVISION_INFRAESTRUCTURA",
                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                });
                break;
            case "ZONIFICACION":
                _POAFaunaSupervisado.tbEliTABLA.push({
                    EliTABLA: "ListISUPERVISION_DET_ZONIFICACION",
                    COD_SECUENCIAL: data["COD_SECUENCIAL"]
                });
                break;
            case "APROVECHAMIENTO":
                _POAFaunaSupervisado.tbEliTABLA.push({
                    EliTABLA: "ISUPERVISION_DET_FAUNA_APROV",
                    COD_ESPECIES: data["COD_ESPECIES"]
                });
                break;
        }
    }
    if (typeof objData === 'undefined') {
        dt.row($(obj).parents('tr')).remove().draw(false);
    }
}
_POAFaunaSupervisado.fnDeleteAllFauna = function (_tipo) {
    var dt, data;
    switch (_tipo) {
        case "COORDENADA_UTM": dt = _POAFaunaSupervisado.dtCoordenadaUtm; break;
        case "INFRAESTRUCTURA": dt = _POAFaunaSupervisado.dtInfraestructuraImp; break;
        case "ZONIFICACION": dt = _POAFaunaSupervisado.dtZonificacion; break;
        case "APROVECHAMIENTO": dt = _POAFaunaSupervisado.dtAprovSostenible; break;
    }
    if (dt.$("tr").length > 0) {
        utilSigo.dialogConfirm("", "Está seguro de Eliminar Todos los Registros?", function (r) {
            if (r) {
                $.each(dt.$("tr"), function (i, o) {
                    data = dt.row($(o)).data();
                    _POAFaunaSupervisado.fnDeleteFauna(_tipo, "", data);
                });
                dt.clear().draw();
            }
        });
    } else {
        utilSigo.toastWarning("Aviso", "No se encontraron registros a eliminar");
    }
}

_POAFaunaSupervisado.fnSubmitForm = function () {
    _POAFaunaSupervisado.frm.submit();
}

_POAFaunaSupervisado.fnSaveForm = function () {
    var datosPoa = _POAFaunaSupervisado.frm.serializeObject();

    datosPoa.tbEliTABLA = _POAFaunaSupervisado.tbEliTABLA;
    datosPoa.tbAvistamientoFauna = _renderAvistamientoFauna.fnGetList();
    datosPoa.tbEliTABLA = datosPoa.tbEliTABLA.concat(_renderAvistamientoFauna.fnGetListEliTABLA());
    datosPoa.tbCoordenadaUTM = _POAFaunaSupervisado.fnGetListFauna("COORDENADA_UTM");
    datosPoa.tbInfraestructuraImpl = _POAFaunaSupervisado.fnGetListFauna("INFRAESTRUCTURA");
    datosPoa.tbZonificacion = _POAFaunaSupervisado.fnGetListFauna("ZONIFICACION");
    datosPoa.tbAprovSostenible = _POAFaunaSupervisado.fnGetListFauna("APROVECHAMIENTO");

    var option = { url: _POAFaunaSupervisado.frm[0].action, datos: JSON.stringify(datosPoa), type: 'POST' };
    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            utilSigo.toastSuccess("Éxito", data.msj);
            $("#mdlManInforme_POASupervisado").modal('hide');
        }
        else {
            utilSigo.toastWarning("Aviso", data.msj);
        }
    });
}

$(document).ready(function () {
    _POAFaunaSupervisado.frm = $("#frmManInfFauna_POASupervisado");

    _POAFaunaSupervisado.fnInitDataTable_Detail();

    $('[data-toggle="tooltip"]').tooltip();

    //=====-----Para el registro de datos del formulario-----=====
    _POAFaunaSupervisado.frm.validate(utilSigo.fnValidate({
        rules: {
        },
        messages: {
        },
        fnSubmit: function (form) {
            _POAFaunaSupervisado.fnSaveForm();
        }
    }));
});