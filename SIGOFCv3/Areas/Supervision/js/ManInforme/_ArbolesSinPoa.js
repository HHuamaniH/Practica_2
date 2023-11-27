"use strict";
var _POASupervisado = {};
//Variables Golbales
_POASupervisado.DataCondicionArea = [];
_POASupervisado.tbEliTABLA = [];
_POASupervisado.scrollTopAnterior = 0;

$(document).ready(function () {
    _POASupervisado.frm = $("#frmManInf_POASupervisado");

    _POASupervisado.fnInitRbtn();




    //_POASupervisado.fnInitDataTable_Detail();
    //_POASupervisado.dtCondicionArea.rows.add(JSON.parse(_POASupervisado.DataCondicionArea)).draw();

    //_POASupervisado.fnInit();

    //$('[data-toggle="tooltip"]').tooltip();

    ////=====-----Para el registro de datos del formulario-----=====
    //_POASupervisado.frm.validate(utilSigo.fnValidate({
    //    rules: {
    //    },
    //    messages: {
    //    },
    //    fnSubmit: function (form) {
    //        _POASupervisado.fnSaveForm();
    //    }
    //}));
});

_POASupervisado.fnInitRbtn = function () {
    let hdPartMenoresCUSAF = $("#hdPartMenoresCUSAF").val();
    switch (hdPartMenoresCUSAF) {
        case "1":
            $("#rbtnPartMenoresSiCUSAF").prop("checked", true);
            break;
        case "2":
            $("#rbtnPartMenoresNoCUSAF").prop("checked", true);
            break;
    }

    let hdAsistenciaTecnicaCUSAF = $("#hdAsistenciaTecnicaCUSAF").val();
    switch (hdAsistenciaTecnicaCUSAF) {
        case "1":
            $("#rbtnAsistenciaTecnicaSiCUSAF").prop("checked", true);
            break;
        case "2":
            $("#rbtnAsistenciaTecnicaNoCUSAF").prop("checked", true);
            break;
    }

    let hdFrecuenciaCUSAF = $("#hdFrecuenciaCUSAF").val();
    switch (hdFrecuenciaCUSAF) {
        case 1:
            $("#rbtnCada3MesesCUSAF").prop("checked", true);
            break;
        case "2":
            $("#rbtnCada6MesesCUSAF").prop("checked", true);
            break;
        case "3":
            $("#rbtnUnaVezAnioCUSAF").prop("checked", true);
            break;
        case "4":
            $("#rbtnMayorUnAnioCUSAF").prop("checked", true);
            break;
    }
};

_POASupervisado.fnSubmitForm = function () {
    var datosPoa = _POASupervisado.frm.serializeObject();
    
    datosPoa.tbEliTABLA = _POASupervisado.tbEliTABLA;
    datosPoa.tbEliTABLA = _POASupervisado.tbEliTABLA;
    datosPoa.tbEvalArbolAdicional = _renderEvalArbolAdicional.fnGetList();
    datosPoa.tbEvalArbolNoAutorizado = _renderEvalArbolNoAutorizado.fnGetList();
    datosPoa.tbEliTABLA = datosPoa.tbEliTABLA.concat(_renderEvalArbolAdicional.fnGetListEliTABLA());
    datosPoa.tbEliTABLA = datosPoa.tbEliTABLA.concat(_renderEvalArbolNoAutorizado.fnGetListEliTABLA());
    if ($("#hdfCodMTipo").val() == "0000030") {
        datosPoa.tbEspecieForEst = _renderEspecieForEst.fnGetList();
        datosPoa.tbEliTABLA = datosPoa.tbEliTABLA.concat(_renderEspecieForEst.fnGetListEliTABLA());
        datosPoa.tbActividadProductiva = _renderActividadProd.fnGetList();
        datosPoa.tbEliTABLA = datosPoa.tbEliTABLA.concat(_renderActividadProd.fnGetListEliTABLA());
        datosPoa.tbCoberturaBosNat = _renderCoberturaBosNat.fnGetList();
        datosPoa.tbEliTABLA = datosPoa.tbEliTABLA.concat(_renderCoberturaBosNat.fnGetListEliTABLA());
        datosPoa.tbDivisionPredio = _renderDivisionPredio.fnGetList();

        // Inicio REQ-359
        datosPoa.rbtnPartMenoresCUSAF = $('input[name="rbtnPartMenoresCUSAF"]:checked').val() != undefined ? $('input[name="rbtnPartMenoresCUSAF"]:checked').val() : null;
        datosPoa.rbtnAsistenciaTecnicaCUSAF = $('input[name="rbtnAsistenciaTecnicaCUSAF"]:checked').val() != undefined ? $('input[name="rbtnAsistenciaTecnicaCUSAF"]:checked').val() : null;
        datosPoa.rbtnFrecuenciaCUSAF = $('input[name="rbtnFrecuenciaCUSAF"]:checked').val() != undefined ? $('input[name="rbtnFrecuenciaCUSAF"]:checked').val() : null;
        datosPoa.chkControlMalezas = $('input[id="chkControlMalezas"]:checked').val() == undefined ? false : true;
        datosPoa.chkRenovacionCultivo = $('input[id="chkRenovacionCultivo"]:checked').val() == undefined ? false : true;
        datosPoa.chkRotacionCultivoAnual = $('input[id="chkRotacionCultivoAnual"]:checked').val() == undefined ? false : true;
        datosPoa.chkPodasCultivo = $('input[id="chkPodasCultivo"]:checked').val() == undefined ? false : true;
        datosPoa.chkManejoSombra = $('input[id="chkManejoSombra"]:checked').val() == undefined ? false : true;
        datosPoa.chkCultivoCobertura = $('input[id="chkCultivoCobertura"]:checked').val() == undefined ? false : true;
        datosPoa.chkFertilizacion = $('input[id="chkFertilizacion"]:checked').val() == undefined ? false : true;
        datosPoa.chkArbolesForestales = $('input[id="chkArbolesForestales"]:checked').val() == undefined ? false : true;
        datosPoa.chkCurvasBolillo = $('input[id="chkCurvasBolillo"]:checked').val() == undefined ? false : true;
        datosPoa.chkControlPlagas = $('input[id="chkControlPlagas"]:checked').val() == undefined ? false : true;
        datosPoa.chkQuema = $('input[id="chkQuema"]:checked').val() == undefined ? false : true;
        datosPoa.chkAgroforesteria = $('input[id="chkAgroforesteria"]:checked').val() == undefined ? false : true;
        datosPoa.chkPracticaOrganica = $('input[id="chkPracticaOrganica"]:checked').val() == undefined ? false : true;
        datosPoa.chkProyecto = $('input[id="chkProyecto"]:checked').val() == undefined ? false : true;
        datosPoa.chkCooperativa = $('input[id="chkCooperativa"]:checked').val() == undefined ? false : true;
        datosPoa.chkInstitucion = $('input[id="chkInstitucion"]:checked').val() == undefined ? false : true;
        datosPoa.chkAutofinanciado = $('input[id="chkAutofinanciado"]:checked').val() == undefined ? false : true;
        datosPoa.chkPropioFA = $('input[id="chkPropioFA"]:checked').val() == undefined ? false : true;
        datosPoa.chkInstitucionFA = $('input[id="chkInstitucionFA"]:checked').val() == undefined ? false : true;
        datosPoa.chkProgramaFA = $('input[id="chkProgramaFA"]:checked').val() == undefined ? false : true;
        datosPoa.chkProyectoFA = $('input[id="chkProyectoFA"]:checked').val() == undefined ? false : true;
        datosPoa.chkCooperativaFA = $('input[id="chkCooperativaFA"]:checked').val() == undefined ? false : true;
        datosPoa.chkOtrosTercerosFA = $('input[id="chkOtrosTercerosFA"]:checked').val() == undefined ? false : true;
        datosPoa.chkCooperativaAsoc = $('input[id="chkCooperativaAsoc"]:checked').val() == undefined ? false : true;
        datosPoa.chkAsociacionAsoc = $('input[id="chkAsociacionAsoc"]:checked').val() == undefined ? false : true;
        datosPoa.chkOtrosAsoc = $('input[id="chkOtrosAsoc"]:checked').val() == undefined ? false : true;
        datosPoa.chkNingunoAsoc = $('input[id="chkNingunoAsoc"]:checked').val() == undefined ? false : true;
    // Fin REQ-359
    }
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