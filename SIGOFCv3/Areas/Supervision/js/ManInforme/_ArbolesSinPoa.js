"use strict";
var _POASupervisado = {};
//Variables Golbales
_POASupervisado.DataCondicionArea = [];
_POASupervisado.tbEliTABLA = [];
_POASupervisado.scrollTopAnterior = 0;

$(document).ready(function () {
    _POASupervisado.frm = $("#frmManInf_POASupervisado");

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

_POASupervisado.fnSubmitForm = function () {
    var datosPoa = _POASupervisado.frm.serializeObject();
    datosPoa.tbEliTABLA = _POASupervisado.tbEliTABLA;
    datosPoa.tbEvalArbolAdicional = _renderEvalArbolAdicional.fnGetList();
    datosPoa.tbEvalArbolNoAutorizado = _renderEvalArbolNoAutorizado.fnGetList();
    datosPoa.tbEliTABLA = datosPoa.tbEliTABLA.concat(_renderEvalArbolAdicional.fnGetListEliTABLA());
    datosPoa.tbEliTABLA = datosPoa.tbEliTABLA.concat(_renderEvalArbolNoAutorizado.fnGetListEliTABLA());
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