"use strict";
var _NotaExamen = {};

_NotaExamen.fnCloseModal = function () { /*implementado desde donde se instancia*/ }
_NotaExamen.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_NotaExamen.fnBuscarPersona = function () {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                _NotaExamen.frm.find("#hdfItemNotaExamen_Participante").val(data["COD_PERSONA"]);
                _NotaExamen.frm.find("#lblItemNotaExamen_Participante").val(data["PERSONA"]);
                _NotaExamen.frm.find("#hdfItemNotaExamen_Documento").val(data["N_DOCUMENTO"]);
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        }
        _bPerGen.fnInit();
    });
}

_NotaExamen.fnLoadDatosNota = function (data) {
    if (data != null && data != "") {
        _NotaExamen.frm.find("#lblItemNotaExamen_Participante").val(data["APELLIDOS_NOMBRES"]);
        _NotaExamen.frm.find("#hdfItemNotaExamen_Participante").val(data["COD_PERSONA"]);
        _NotaExamen.frm.find("#hdfItemNotaExamen_Documento").val(data["N_DOCUMENTO"]);
        _NotaExamen.frm.find("#txtItemNotaExamen_NInicio").val(data["NOTA_EXA_INICIO"]);
        _NotaExamen.frm.find("#txtItemNotaExamen_NFin").val(data["NOTA_EXA_FIN"]);
        _NotaExamen.frm.find("#hdfItemNotaExamen_Institucion").val(data["NOM_INSTITUCION"]);
    } else {
        _NotaExamen.frm.find("#hdfItemNotaExamen_Participante").val("");
    }
}

_NotaExamen.fnSetDatosNota = function () {
    var data = [];
    data["APELLIDOS_NOMBRES"] = _NotaExamen.frm.find("#lblItemNotaExamen_Participante").val();
    data["COD_PERSONA"] = _NotaExamen.frm.find("#hdfItemNotaExamen_Participante").val();
    data["N_DOCUMENTO"] = _NotaExamen.frm.find("#hdfItemNotaExamen_Documento").val();
    data["NOTA_EXA_INICIO"] = _NotaExamen.frm.find("#txtItemNotaExamen_NInicio").val();
    data["NOTA_EXA_FIN"] = _NotaExamen.frm.find("#txtItemNotaExamen_NFin").val();
    data["NOM_INSTITUCION"] = _NotaExamen.frm.find("#hdfItemNotaExamen_Institucion").val();
    return data;
}

_NotaExamen.fnCustomValidateForm = function () {
    if (!utilSigo.fnValidateForm_HideControl(_NotaExamen.frm, _NotaExamen.frm.find("#hdfItemNotaExamen_Participante"), _NotaExamen.frm.find("#iconPersona"), false)) return false;
    return true;
}

_NotaExamen.fnEvents = function () {

}

_NotaExamen.fnSubmitForm = function () {
    _NotaExamen.frm.submit();
}

_NotaExamen.fnInit = function (data) {
    _NotaExamen.frm = $("#frmItemNotaExamen");
    _NotaExamen.fnLoadDatosNota(data);

    _NotaExamen.fnEvents();

    //=====-----Para el registro de datos del formulario-----=====
    _NotaExamen.frm.validate(utilSigo.fnValidate({
        rules: {
            txtItemNotaExamen_NInicio: { required: true },
            txtItemNotaExamen_NFin: { required: true }
        },
        messages: {
            txtItemNotaExamen_NInicio: { required: "Ingrese la nota del examen de inicio" },
            txtItemNotaExamen_NFin: { required: "Ingrese la nota del examen final" }
        },
        fnSubmit: function (form) {
            if (_NotaExamen.fnCustomValidateForm()) {
                _NotaExamen.fnSaveForm(_NotaExamen.fnSetDatosNota());
            }
        }
    }));
    //Validación de controles que usan Select2
    _NotaExamen.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}