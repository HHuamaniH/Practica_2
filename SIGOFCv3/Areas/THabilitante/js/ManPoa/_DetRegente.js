"use strict";
var _DetRegente = {};

_DetRegente.fnCloseModal = function () { /*implementado desde donde se instancia*/ }
_DetRegente.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_DetRegente.fnSetDatos = function (tipo) {
    var data = {};
    data.NV_TIPO = tipo;
    data.DA_FECRESOLUCION = _DetRegente.frm.find("#txtFechaResolucion").val();
    data.NV_RESOLUCION = _DetRegente.frm.find("#txtResolucion").val();
    data.NV_NOMCAMPO = _DetRegente.frm.find("#txtNombreCampo").val();
    data.NV_VALANTERIOR = _DetRegente.frm.find("#txtValorAnterior").val();
    data.NV_VALACTUAL = _DetRegente.frm.find("#txtValorActual").val();
    data.NV_OBSERVACION = _DetRegente.frm.find("#txtObservacion").val();

    return data;
}

_DetRegente.fnSubmitForm = function () {
    _DetRegente.frm.submit();
}

_DetRegente.fnInit = function (tipo) {
    _DetRegente.frm = $("#frmAddDetRegente");

    _DetRegente.frm.find("#txtFechaResolucion").datepicker({ format: "dd/mm/yyyy", autoclose: true, language: 'es' });
    _DetRegente.frm.find("#txtFechaResolucion").keyup(function () {
        return formateafecha(this.value);
    });

    //=====-----Para el registro de datos del formulario-----=====
    //Validación personalizada
    _DetRegente.frm.validate(utilSigo.fnValidate({
        rules: {
            txtFechaResolucion: { required: true },
            txtResolucion: { required: true },
            txtNombreCampo: { required: true },
            txtValorAnterior: { required: true },
            txtValorActual: { required: true }
        },
        messages: {
            txtFechaResolucion: { required: "Ingrese Fecha de Resolución" },
            txtResolucion: { required: "Ingrese Resolución" },
            txtNombreCampo: { required: "Ingrese Nombre de Campo" },
            txtValorAnterior: { required: "Ingrese Valor Anterior" },
            txtValorActual: { required: "Ingrese Valor Actual" }
        },
        fnSubmit: function (form) {
            _DetRegente.fnSaveForm(_DetRegente.fnSetDatos(tipo));
        }
    }));
}
_DetRegente.fnBuscarPersona = function () {
    var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
    var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: "TODOS", asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
    utilSigo.fnOpenModal(option, function () {
        _bPerGen.fnAsignarDatos = function (obj) {
            if (obj != null && obj != "") {
                var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                _DetRegente.fnSetPersonaCompleto(data["COD_PERSONA"]);
                utilSigo.fnCloseModal("mdlBuscarPersona");
            }
        }
        _bPerGen.fnInit();
    });
}
_DetRegente.fnSetPersonaCompleto = function (codPersona) {
    $.ajax({
        url: urlLocalSigo + "General/Controles/GetPersona",
        type: 'POST',
        data: { asCodPersona: codPersona },
        dataType: 'json',
        beforeSend: utilSigo.beforeSendAjax,
        complete: utilSigo.completeAjax,
        error: utilSigo.errorAjax,
        success: function (data) {
            if (data.success) {
                _DetRegente.frm.find("#hdfItemPart_Participante").val(data.data["COD_PERSONA"]);
                _DetRegente.frm.find("#lblItemPart_Participante").val(data.data["APELLIDOS_NOMBRES"]);
                _DetRegente.frm.find("#hdfItemPart_Documento").val(data.data["N_DOCUMENTO"]);
                _DetRegente.frm.find("#hdfItemPart_Genero").val(data.data["COD_SEXO"]);
                if (data.data["ListCorreo"].length > 0) {
                    _DetRegente.frm.find("#txtItemPart_Correo").val(data.data["ListCorreo"][0]["CORREO"]);
                }
            } else {
                utilSigo.toastError("Error", "No se pudo consultar los datos de la persona");
                console.log(data.msj);
                return false;
            }
        }
    });
}