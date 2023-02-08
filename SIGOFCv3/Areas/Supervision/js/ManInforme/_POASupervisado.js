"use strict";
var _POASupervisado = {};
//Variables Golbales
_POASupervisado.DataCondicionArea = [];
_POASupervisado.tbEliTABLA = [];
_POASupervisado.scrollTopAnterior = 0;

_POASupervisado.fnShowVerticeArea = function () {
    _POASupervisado.frm.find("#dvVerticeArea").hide();
    if (_POASupervisado.frm.find('input[name="hdfLinderamientoArea"]:checked').val() != "NA") {
        _POASupervisado.frm.find("#dvVerticeArea").show();
    }
}
_POASupervisado.fnShowHuayrona = function () {
    _POASupervisado.frm.find("#dvListHuayrona").hide();
    if (_POASupervisado.frm.find('input[name="hdfPresenciaHuayrona"]:checked').val() == "S") {
        _POASupervisado.frm.find("#dvListHuayrona").show();
    }
}
_POASupervisado.fnShowOpcionPoa = function () {
    _POASupervisado.frm.find("#dvOpcionPoaResultado").hide();
    _POASupervisado.frm.find("#dvOpcionPoaAnalisis").hide();
    _POASupervisado.frm.find("#dvOpcionPoaDatosProcesados").hide();

    if ($('input[name="mnuOpcionPoa"]:checked').val() == "RESULTADO") {
        _POASupervisado.frm.find("#dvOpcionPoaResultado").show();
    } else if ($('input[name="mnuOpcionPoa"]:checked').val() == "ANALISIS") {
        _POASupervisado.frm.find("#dvOpcionPoaAnalisis").show();
    }
    else {
        _POASupervisado.frm.find("#dvOpcionPoaDatosProcesados").show();
    }
    var scrollTopActual = _POASupervisado.scrollTopAnterior;
    _POASupervisado.scrollTopAnterior = $("#dvManInf_POASupervisado").scrollTop();
    $("#dvManInf_POASupervisado").scrollTop(scrollTopActual);
}
_POASupervisado.fnShowInformeEjecucionForestal = function () {
    _POASupervisado.frm.find(".dvInformeEjecucionForestal").hide();
    if (_POASupervisado.frm.find("#ddlInformeEjecutaPlanId").val() == "SI") {
        _POASupervisado.frm.find(".dvInformeEjecucionForestal").show();
    }
}
_POASupervisado.fnShowAntesAprovechaRecomienda = function () {
    _POASupervisado.frm.find(".dvAntesAprovRecomienda").hide();
    if (_POASupervisado.frm.find("#ddlOportunidadAprovId").val() == "0000019") {
        _POASupervisado.frm.find(".dvAntesAprovRecomienda").show();
    }
}

_POASupervisado.fnBuscarPersona = function (_dom, _tipoPersonaSIGOsfc) {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: _tipoPersonaSIGOsfc, asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                switch (_dom) {
                    case "TITULAR":
                        _POASupervisado.frm.find("#hdfCodTitularEjecuta").val(data["COD_PERSONA"]);
                        _POASupervisado.frm.find("#txtTitularEjecuta").val(data["PERSONA"]);
                        
                        break;
                    case "REGENTE":
                        _POASupervisado.frm.find("#hdfCodRegenteImplementa").val(data["COD_PERSONA"]);
                        _POASupervisado.frm.find("#txtRegenteImplementa").val(data["PERSONA"]);
                        _POASupervisado.frm.find("#txtCodUbigeo").val(data["COD_UBIGEO"]);
                        _POASupervisado.frm.find("#txtUbigeo").val(data["UBIGEO"]);
                        _POASupervisado.frm.find("#txtDirecion").val(data["DIRECCION"]);
                        break;
                    case "TERCERO":
                        _POASupervisado.frm.find("#hdfCodTerceroSolidario").val(data["COD_PERSONA"]);
                        _POASupervisado.frm.find("#txtTerceroSolidario").val(data["PERSONA"]);
                        break;
                }
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        }
        _bPerGen.fnInit();
    });
}

_POASupervisado.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {}, data_extend = [];

    columns_label = ["Área"];
    columns_data = ["DESC_AREA"];
    data_extend = [
        {
            "data": "EXISTE_CONDICION", "title": "", "width": "3%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                var checked = (data == true) ? "checked" : "";
                return '<div class="custom-control custom-checkbox"><input type="checkbox" class="custom-control-input" id="chkExisteCond_' + meta.row + '" ' + checked + '><label class="custom-control-label" for="chkExisteCond_' + meta.row + '"></label></div>';
            }
        },
        {
            "data": "PORCENTAJE_AREA", "title": "Porcentaje", "width": "10%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return '<input class="form-control form-control-sm" type="number" placeholder="%" value="' + data + '" style="width:100%;">';
            }
        },
        {
            "data": "ARBOL_INEX", "title": "N° de árboles no ubicados", "width": "10%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return '<input class="form-control form-control-sm" type="number" value="' + data + '" style="width:100%;">';
            }
        },
        {
            "data": "OBSERVACION_INEX", "title": "Observaciones", "width": "70%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return '<input class="form-control form-control-sm" type="text" row="2" value="' + data + '" style="width:100%;">';
            }
        }
    ];
    options = { page_length: 10, row_index: true, data_extend: data_extend, page_autowidth: false };
    _POASupervisado.dtCondicionArea = utilDt.fnLoadDataTable_Detail($("#tbCondicionArea"), columns_label, columns_data, options);
}

_POASupervisado.fnLoadDataCondicionArea = function (obj) {
    _POASupervisado.DataCondicionArea = obj;
}

_POASupervisado.fnGetListCondicionArea = function () {
    var list = [], rows, countFilas, data, dataHtml;

    rows = _POASupervisado.dtCondicionArea.$("tr");
    countFilas = rows.length;
    if (countFilas > 0) {
        $.each(rows, function (i, o) {
            data = _POASupervisado.dtCondicionArea.row($(o)).data();
            dataHtml = $(o)[0];
            data["EXISTE_CONDICION"] = $($($(dataHtml).find("td")[2]).find("input")[0]).is(":checked");
            data["PORCENTAJE_AREA"] = $($($(dataHtml).find("td")[3]).find("input")[0]).val();
            data["ARBOL_INEX"] = $($($(dataHtml).find("td")[4]).find("input")[0]).val();
            data["OBSERVACION_INEX"] = $($($(dataHtml).find("td")[5]).find("input")[0]).val();
            list.push(utilSigo.fnConvertArrayToObject(data));
        });
    }
    return list;
}

_POASupervisado.fnSubmitForm = function () {
    _POASupervisado.frm.submit();
}

_POASupervisado.fnSaveForm = function () {
    var datosPoa = _POASupervisado.frm.serializeObject();
    datosPoa.hdfCodInforme = _POASupervisado.frm.find("#hdfCodInforme").val(); //Se tiene varios objetos hdfCodInforme en el DOM
    datosPoa.hdfNumPoa = _POASupervisado.frm.find("#hdfNumPoa").val(); //Se tiene varios objetos hdfNumPoa en el DOM
    datosPoa.chkRecReformulaPlan = utilSigo.fnGetValChk(_POASupervisado.frm.find("#chkRecReformulaPlan"));

    datosPoa.tbEliTABLA = _POASupervisado.tbEliTABLA;
    datosPoa.tbCondicionArea = _POASupervisado.fnGetListCondicionArea();
    datosPoa.tbVerticeArea = _renderVerticeArea.fnGetList();

    datosPoa.tbEliTABLA = datosPoa.tbEliTABLA.concat(_renderVerticeArea.fnGetListEliTABLA());
    datosPoa.tbEvalArbolAdicional = _renderEvalArbolAdicional.fnGetList();
    datosPoa.tbEliTABLA = datosPoa.tbEliTABLA.concat(_renderEvalArbolAdicional.fnGetListEliTABLA());
    datosPoa.tbEvalArbolNoAutorizado = _renderEvalArbolNoAutorizado.fnGetList();
    datosPoa.tbEliTABLA = datosPoa.tbEliTABLA.concat(_renderEvalArbolNoAutorizado.fnGetListEliTABLA());
    datosPoa.tbHuayrona = _renderHuayrona.fnGetList();
    datosPoa.tbEliTABLA = datosPoa.tbEliTABLA.concat(_renderHuayrona.fnGetListEliTABLA());
    datosPoa.tbActividadSilvicultural = _renderActividadSilvicultural.fnGetList();
    datosPoa.tbEliTABLA = datosPoa.tbEliTABLA.concat(_renderActividadSilvicultural.fnGetListEliTABLA());
    datosPoa.tbCambioUso = _renderCambioUso.fnGetList();
    datosPoa.tbEliTABLA = datosPoa.tbEliTABLA.concat(_renderCambioUso.fnGetListEliTABLA());
    datosPoa.tbEvalOtro = _renderEvalOtro.fnGetList();
    datosPoa.tbEliTABLA = datosPoa.tbEliTABLA.concat(_renderEvalOtro.fnGetListEliTABLA());
    datosPoa.tbVolumenAnalizado = _renderVolumenAnalizado.fnGetList();
    datosPoa.tbEliTABLA = datosPoa.tbEliTABLA.concat(_renderVolumenAnalizado.fnGetListEliTABLA());
    datosPoa.txtCodUbigeo = $("#txtCodUbigeo").val();
    datosPoa.txtDirecion = $("#txtDirecion").val();
    var option = { url: _POASupervisado.frm[0].action, datos: JSON.stringify(datosPoa), type: 'POST' };
    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            utilSigo.toastSuccess("Éxito", data.msj);
            $("#mdlManInforme_POASupervisado").modal('hide');
        }
        else {
            utilSigo.toastWarning("Aviso", data.msj);
        }
    });
};

_POASupervisado.fnListarParcelaCorta = function () {
    _ReporteAnalisisMaderable.dtAnalisis.clear().draw();
    _ReporteAnalisisMaderable.fnSetTotal();
    _ReporteConsolidado.dtConsolidado.clear().draw();
    _ReporteConsolidado.fnSetTotal();
    _ReporteConsolidadoNN.dtConsolidado.clear().draw();
    _ReporteConsolidadoNN.fnSetTotal();
    _ReporteMaderable.dtMaderable.clear().draw();

    _POASupervisado.fnGetListPC();
}

_POASupervisado.fnGetListPC = function () {
    var hdfCodInforme = _POASupervisado.frm.find("#hdfCodInforme").val();
    var hdfNumPoa = _POASupervisado.frm.find("#hdfNumPoa").val();
    var lstChkParcelaCortaId = $('input[name="mnuOpcionPC"]:checked').val();
    var params = { hdfCodInforme, hdfNumPoa, lstChkParcelaCortaId };

    var url = urlLocalSigo + "Supervision/ManInforme/_POAGetParcelaCorta";
    var option = { url: url, datos: JSON.stringify(params), type: 'POST' };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            var obj = data.result;
            
            if (obj != null) {
                setTimeout(function () {
                    _ReporteAnalisisMaderable.dtAnalisis.rows.add(obj.tbAnalisis).draw();
                    _ReporteAnalisisMaderable.fnSetTotal();
                    _ReporteConsolidado.dtConsolidado.rows.add(obj.tbConsolidado).draw();
                    _ReporteConsolidado.fnSetTotal();
                    _ReporteConsolidadoNN.dtConsolidado.rows.add(obj.tbConsolidadoNN).draw();
                    _ReporteConsolidadoNN.fnSetTotal();
                    _ReporteMaderable.dtMaderable.rows.add(obj.tbMaderable).draw();
                }, 1)
            }
        }
        else {
            utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
            console.log(data.msj);
        }
    });
}

_POASupervisado.fnInit = function () {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    _POASupervisado.frm.find("#ddlIndicioAprovechaId").select2({ minimumResultsForSearch: -1 });
    _POASupervisado.frm.find("#ddlCumpleVialId").select2({ minimumResultsForSearch: -1 });
    _POASupervisado.frm.find("#ddlPlanConcuerdaPgmfId").select2({ minimumResultsForSearch: -1 });
    _POASupervisado.frm.find("#ddlPlanApruebaNormaId").select2({ minimumResultsForSearch: -1 });
    _POASupervisado.frm.find("#ddlInformeEjecutaPlanId").select2({ minimumResultsForSearch: -1 });
    _POASupervisado.frm.find("#ddlTipoInformeEjecutaId").select2({ minimumResultsForSearch: -1 });
    _POASupervisado.frm.find("#ddlCumpleLineamientoId").select2({ minimumResultsForSearch: -1 });
    _POASupervisado.frm.find("#ddlCumplePagoAprovId").select2({ minimumResultsForSearch: -1 });
    _POASupervisado.frm.find("#ddlImpactoDanioId").select2({ minimumResultsForSearch: -1 });
    _POASupervisado.frm.find("#ddlOportunidadAprovId").select2({ minimumResultsForSearch: -1 });
    utilSigo.fnFormatDate(_POASupervisado.frm.find("#txtFecPresentaPlan"));
    utilSigo.fnFormatDate(_POASupervisado.frm.find("#txtFecApruebaPlan"));
    utilSigo.fnFormatDate(_POASupervisado.frm.find("#txtFecEntregaAcervo"));
    utilSigo.fnFormatDate(_POASupervisado.frm.find("#txtFecPresentaAutoridad"));
    utilSigo.fnFormatDate(_POASupervisado.frm.find("#txtFecCumplimientoOsinfor"));

    var cod_mtipo = _POASupervisado.frm.find("#hdfCodMTipo").val();
    var cod_mtipo_concesiones = "0000007,0000008,0000009,0000010,0000011,0000012,0000013,0000017,0000018";
    var cod_mtipo_sobreplan = "0000006,0000007,0000008,0000009,0000010,0000011,0000012,0000013,0000014,0000015,0000016,0000017,0000018";

    //Mostrar las opciones de registro de datos del POA (Resultados o Análisis)
    _POASupervisado.fnShowOpcionPoa();
    //Mostrar algunas secciones solo para Concesiones Forestales o CCNNN
    _POASupervisado.frm.find("#dvDelimitacionArea").hide();
    _POASupervisado.frm.find("#dvPagoAprovechamiento").hide();
    if (cod_mtipo_concesiones.includes(cod_mtipo)) {
        _POASupervisado.frm.find("#dvDelimitacionArea").show();
        _POASupervisado.frm.find("#dvPagoAprovechamiento").show();
    } else if (cod_mtipo == "0000015") {
        _POASupervisado.frm.find("#dvDelimitacionArea").show();
    }
    //Mostrar tabla vértices del área
    _POASupervisado.fnShowVerticeArea();
    _POASupervisado.frm.find('input[name="hdfLinderamientoArea"]').click(function () {
        _POASupervisado.fnShowVerticeArea();
    });
    //Mostrar tabla huayronas
    _POASupervisado.fnShowHuayrona();
    _POASupervisado.frm.find('input[name="hdfPresenciaHuayrona"]').click(function () {
        _POASupervisado.fnShowHuayrona();
    });
    //Mostrar controles relacionados a huayronas
    _POASupervisado.frm.find(".dvHuayrona").hide();
    if (cod_mtipo=="0000006")//Bosques secos
    {
        _POASupervisado.frm.find(".dvHuayrona").show();
    }
    //Mostrar datos informe ejecución forestal
    _POASupervisado.fnShowInformeEjecucionForestal();
    _POASupervisado.frm.find("#ddlInformeEjecutaPlanId").change(function () {
        _POASupervisado.fnShowInformeEjecucionForestal();
    });
    //Mostrar recomendación oportunidad antes del arovechamiento
    _POASupervisado.fnShowAntesAprovechaRecomienda();
    _POASupervisado.frm.find("#ddlOportunidadAprovId").change(function () {
        _POASupervisado.fnShowAntesAprovechaRecomienda();
    });
    //Mostra datos sobre el plan
    _POASupervisado.frm.find("#dvSobrePlan").hide();
    _POASupervisado.frm.find("#dvTitularEjecuta").hide();
    if (cod_mtipo_sobreplan.includes(cod_mtipo)) {
        _POASupervisado.frm.find("#dvSobrePlan").show();
        var cod_mtipo_titularejecuta = "0000007,0000008,0000009,0000010,0000011,0000012,0000013";
        if (cod_mtipo_titularejecuta.includes(cod_mtipo)) {
            _POASupervisado.frm.find("#dvTitularEjecuta").show();
        }
    }
    //Mostrar lista de indicadores de parcela de corta
    _POASupervisado.fnGetListPC();
}

$(document).ready(function () {
    _POASupervisado.frm = $("#frmManInf_POASupervisado");

    _POASupervisado.fnInitDataTable_Detail();
    _POASupervisado.dtCondicionArea.rows.add(JSON.parse(_POASupervisado.DataCondicionArea)).draw();

    _POASupervisado.fnInit();

    $('[data-toggle="tooltip"]').tooltip();

    //=====-----Para el registro de datos del formulario-----=====
    _POASupervisado.frm.validate(utilSigo.fnValidate({
        rules: {
        },
        messages: {
        },
        fnSubmit: function (form) {
            _POASupervisado.fnSaveForm();
        }
    }));
});