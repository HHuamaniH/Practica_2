"use strict";
var controles_Persona = {};
controles_Persona.IsNumber = function (evt) {
    var nav4 = window.Event ? true : false;
    // Backspace = 8, Enter = 13, ’0′ = 48, ’9′ = 57, ‘.’ = 46
    var key = nav4 ? evt.which : evt.keyCode;
    return (key <= 13 || (key >= 48 && key <= 57));
}
controles_Persona.cargarUbigeoModal = function (control) {
    $.ajax({
        url: urlLocalSigo + "THabilitante/Controles/_Ubigeo",
        type: 'POST',
        data: { formOrigen: "frmPersonaControles", controlOrigen: control },
        dataType: 'html',
        // contentType: 'application/json; charset=utf-8',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            $("#personaUbigeoModal").html(data);
            utilSigo.modalDraggable($("#personaUbigeoModal"), '.modal-header');
            $("#personaUbigeoModal").modal({ keyboard: true, backdrop: 'static' });
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un Error Inesperado, Comuniquese con el Administrador");
            console.log(jqXHR.responseText);
        }
    });
}

controles_Persona.closePersonaModal = function () {
    var valOrigenFormulario = controles_Persona.frmPersonaControles.find("#formOrigen").val();   
    switch (valOrigenFormulario) {
        case "frmTHabilitanteRegistro":  $('#manTHabilitanteModalPersonaNJ').modal('hide');
                                         $('#manTHabilitanteModalPersonaNJ').html('');          
                                        break;
        case "frmBuscarFuncionario":
            $('#funcionarioAgregarModal').modal('hide');
            $('#funcionarioAgregarModal').html(''); 
            break;
        case "frmBuscarPersonaPOA":
            $('#funcionarioAgregarModal').modal('hide');
            $('#funcionarioAgregarModal').html('');
            break;
    }     
}
controles_Persona.limpiarFormulario = function () {
    utilSigo.FormReset(controles_Persona.frmPersonaControles, ["codigoPersona", "hdCOD_UBIGEO"]);
    controles_Persona.frmPersonaControles.find("#ddlItemPN_DITipoId").val('0000000');
    controles_Persona.frmPersonaControles.find("#hdfUbigeo").val('');
}
controles_Persona.asignarDatosOrigen = function (data) {
    var formOrigen = controles_Persona.frmPersonaControles.find("#formOrigen").val();
    var controlOrigen = controles_Persona.frmPersonaControles.find("#controlOrigen").val();
    var valTipoPersona = controles_Persona.frmPersonaControles.find("#tipo").val();
    if (formOrigen == "frmTHabilitanteRegistro") {
        ManTHabilitante.frmTHabilitanteRegistro.find("#" + controlOrigen).val(data[1]);
        ManTHabilitante.frmTHabilitanteRegistro.find("#hd" + controlOrigen).val(data[0]);
        ManTHabilitante.frmTHabilitanteRegistro.find("#hdtipo" + controlOrigen).val(valTipoPersona);
        controles_Persona.closePersonaModal();
    }
    if (formOrigen == "frmBuscarPersonaPOA") {
      
        var PersonaCodigo =data[0];
        var PersonaNombres = controles_Persona.frmPersonaControles.find("#txtItemPN_APaterno").val() +" "+
            controles_Persona.frmPersonaControles.find("#txtItemPN_AMaterno").val() + " " +
            controles_Persona.frmPersonaControles.find("#txtItemPN_Nombres").val() 
            ;
        var PersonaDNI = controles_Persona.frmPersonaControles.find("#txtItemPN_DINumero").val();
        var PersonaCargo = controles_Persona.frmPersonaControles.find("#txtItemBNuevo_Cargo").val();
        var NRConsultor = "";
        var NRProfesional = "";


        var tipoFormulario = controles_Persona.frmPersonaControles.find("#tVentana").val();
        
        switch (tipoFormulario) {

            case "C":

                ManPOA.frmPOARegistro.find("#hdfItemConsultorCodigo").val(PersonaCodigo);
                ManPOA.frmPOARegistro.find("#lblItemConsultorNombre").val(PersonaNombres);
                ManPOA.frmPOARegistro.find("#lblItemConsultorDNI").val(PersonaDNI);
                ManPOA.frmPOARegistro.find("#txtItemNRConsultor").val(NRConsultor);
                ManPOA.frmPOARegistro.find("#lblItemConsultorNRProfesional").val(NRProfesional);
                utilSigo.toastSuccess("Exito", "Se selecciono correctamente");
                break;
            case "AO":
            case "AOC":

                if (!utilSigo.existValorSearchDataTable(ManPOA.dtItemAOcular, "N_DOCUMENTO", PersonaDNI)) {

                    var $rows = ManPOA.dtItemAOcular.$("tr");
                    var countFilas = $rows.length;
                    var codSecC = parseInt(countFilas) + 1;
                    var filaC = {
                        NRO: codSecC,
                        PERSONA: PersonaNombres,
                        N_DOCUMENTO: PersonaDNI,
                        CARGO: PersonaCargo,
                        COD_PERSONA: PersonaCodigo,
                        RegEstado: 1
                    };
                    ManPOA.dtItemAOcular.row.add(filaC).draw();
                    ManPOA.dtItemAOcular.page('last').draw('page');
                    utilSigo.toastSuccess("Exito", "Se Adiciono correctamente");
                } else {

                    utilSigo.toastWarning("Error", "El Técnico para el Acta de Inspección Ocular ya Existe");
                }

                break;
            case "TO":
            case "TOC":

                if (!utilSigo.existValorSearchDataTable(ManPOA.dtItemIOcular, "N_DOCUMENTO", PersonaDNI)) {

                    var $rows = ManPOA.dtItemIOcular.$("tr");
                    var codSecC = $rows.length + 1;
                    var filaC = {
                        NRO: codSecC,
                        PERSONA: PersonaNombres,
                        N_DOCUMENTO: PersonaDNI,
                        CARGO: PersonaCargo,
                        COD_PERSONA: PersonaCodigo,
                        RegEstado: 1
                    };
                    ManPOA.dtItemIOcular.row.add(filaC).draw();
                    ManPOA.dtItemIOcular.page('last').draw('page');
                    utilSigo.toastSuccess("Exito", "Se Adiciono correctamente");
                } else {

                    utilSigo.toastWarning("Error", "El Técnico de Inspección Ocular ya Existe");
                }

                break;

            case "RA":
            case "APO":

                if (!utilSigo.existValorSearchDataTable(ManPOA.dtItemTRAprobacion, "N_DOCUMENTO", PersonaDNI)) {

                    var $rows = ManPOA.dtItemTRAprobacion.$("tr");
                    var codSecC = $rows.length + 1;
                    var filaC = {
                        NRO: codSecC,
                        PERSONA: PersonaNombres,
                        N_DOCUMENTO: PersonaDNI,
                        CARGO: PersonaCargo,
                        COD_PERSONA: PersonaCodigo,
                        RegEstado: 1
                    };
                    ManPOA.dtItemTRAprobacion.row.add(filaC).draw();
                    ManPOA.dtItemTRAprobacion.page('last').draw('page');
                    utilSigo.toastSuccess("Exito", "Se Adiciono correctamente");
                } else {

                    utilSigo.toastWarning("Error", "El Técnico que Recomienda la Aprobación ya Existe");
                }
                break;
            case "FA":
                ManPOA.frmPOARegistro.find("#hdfItemARFuncionarioCodigo").val(PersonaCodigo);
                ManPOA.frmPOARegistro.find("#lblItemARFuncionario").val(PersonaNombres);
                ManPOA.frmPOARegistro.find("#lblItemARFuncionarioODatos").val(PersonaDNI + " - " + PersonaCargo);
                utilSigo.toastSuccess("Exito", "Se selecciono correctamente");
                break;



            default: break;

        }



        controles_Persona.closePersonaModal();
    }
}
controles_Persona.cargarDatosBusqueda = function (data) {
    var cargTipoPersona = controles_Persona.frmPersonaControles.find("#tipo").val();
    if (cargTipoPersona == 'N') {
        controles_Persona.frmPersonaControles.find("#codigoPersona").val(data[0]);
        controles_Persona.frmPersonaControles.find("#ddlItemPN_DITipoId").val(data[1]);
        controles_Persona.frmPersonaControles.find("#txtItemPN_APaterno").val(data[2]);
        controles_Persona.frmPersonaControles.find("#txtItemPN_AMaterno").val(data[3]);
        controles_Persona.frmPersonaControles.find("#txtItemPN_Nombres").val(data[4]);
        controles_Persona.frmPersonaControles.find("#txtItemPN_DINumero").val(data[5]);
        controles_Persona.frmPersonaControles.find("#txtItemPN_DIRUC").val(data[6]);
        controles_Persona.frmPersonaControles.find("#hdCOD_UBIGEO").val(data[7]);
        controles_Persona.frmPersonaControles.find("#COD_UBIGEO").val(data[8]);
        controles_Persona.frmPersonaControles.find("#hdfUbigeo").val(data[8]);
        controles_Persona.frmPersonaControles.find("#txtItemPN_DLDireccion").val(data[9]);
    } else {
        controles_Persona.frmPersonaControles.find("#txtItemPJ_RSocial").val(data[0]);
        controles_Persona.frmPersonaControles.find("#txtItemPJ_RUC").val(data[1]);
        controles_Persona.frmPersonaControles.find("#hdCOD_UBIGEO").val(data[2]);
        controles_Persona.frmPersonaControles.find("#COD_UBIGEO").val(data[3]);
        controles_Persona.frmPersonaControles.find("#hdfUbigeo").val(data[3]);
        controles_Persona.frmPersonaControles.find("#txtItemPN_DLDireccion").val(data[4]);
    }
}
controles_Persona.buscarPersonaNJ = function () {
    var busTipoPersona = controles_Persona.frmPersonaControles.find("#tipo").val();
    var buspCriterio = "";
    var buspValor = "";
    if (busTipoPersona == "N") {
        buspCriterio = "DNI";
        buspValor = controles_Persona.frmPersonaControles.find("#txtItemPN_DINumero").val();
        if (buspValor.trim() == "" || buspValor == null) {
            utilSigo.toastWarning("Aviso", "Ingrese el Número de documento de identidad antes de buscar");
            return false;
        }
        if (buspValor.trim().length < 5) {
            utilSigo.toastWarning("Aviso", "Ingrese mayor a 4 caracteres a buscar");
            return false;
        }
    }
    else if (busTipoPersona == "J") {
        buspCriterio = "RUC";
        buspValor = controles_Persona.frmPersonaControles.find("#txtItemPJ_RUC").val();
        if (buspValor.trim() == "" || buspValor == null) {
            utilSigo.toastWarning("Aviso", "Ingrese el RUC antes de buscar");
            return false;
        }
        if (buspValor.trim().length < 5) {
            utilSigo.toastWarning("Aviso", "Ingrese mayor a 4 caracteres a buscar");
            return false;
        }

    }
    $.ajax({
        url: urlLocalSigo + "THabilitante/Controles/buscarPersonaNJ",
        type: 'POST',
        data: { busCriterio: buspCriterio.trim(), busValor: buspValor.trim() },
        dataType: 'json',
        success: function (data) {
            bootbox.hideAll();
            utilSigo.unblockUIGeneral();
            controles_Persona.limpiarFormulario();
            if (data.success)
                controles_Persona.cargarDatosBusqueda(data.values);
            else utilSigo.toastWarning("Aviso", data.msj);
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un error al buscar datos, Comuniquese con el Administrador");
            console.log(jqXHR.responseText);
        }
    });
}

controles_Persona.validarUbigeo = function () {

    if (controles_Persona.frmPersonaControles.find("#formOrigen").val() == "frmBuscarPersonaPOA")
        return true;

    var valCOD_PTIPO = controles_Persona.frmPersonaControles.find("#COD_PTIPO").val();

    if (valCOD_PTIPO == "0000006") return true;

    var valorUbigeo = controles_Persona.frmPersonaControles.find("#hdCOD_UBIGEO").val();

    var iconUbigeo = controles_Persona.frmPersonaControles.find("#iconUbigeo");

    if (valorUbigeo.trim() == '') {
        iconUbigeo.removeAttr('style');
        return false;
    }
    else {
        iconUbigeo.attr('style', 'display:none;');
    }
    return true;

}
controles_Persona.registrarPersona = function () {
    $.ajax({
        url: controles_Persona.frmPersonaControles.attr('action'),
        type: 'POST',
        data: controles_Persona.frmPersonaControles.serialize(),
        dataType: 'json',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            if (data.success) {
                var valCod_Tipo = controles_Persona.frmPersonaControles.find("#COD_PTIPO").val();
                var valOrigenFormulario = controles_Persona.frmPersonaControles.find("#formOrigen").val();
                if (valOrigenFormulario == "frmBuscarPersonaPOA") {

                    controles_Persona.asignarDatosOrigen(data.values);
                    controles_Persona.limpiarFormulario();
                    controles_Persona.closePersonaModal();

                }else
                if (valCod_Tipo == "0000006") {
                    //asignando valores para encontrar funcionario registrado
                    vpFuncionaro.frmBuscarFuncionario.find("#cboCriterio").val("PERSONA");
                    vpFuncionaro.frmBuscarFuncionario.find("#txtValor").val(data.values[1]);
                    controles_Persona.closePersonaModal();
                    vpFuncionaro.buscarFuncionario();
                }
                else {
                    controles_Persona.asignarDatosOrigen(data.values);
                    controles_Persona.limpiarFormulario();
                    controles_Persona.closePersonaModal();
                }
                
            }
            else utilSigo.toastWarning("Aviso", data.msj);
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un error, Comuniquese con el Administrador");
            console.log(jqXHR.responseText);
        }
    });
}
$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
    controles_Persona.frmPersonaControles = $("#frmPersonaControles");
    console.log("d");
    $('#manFuncionarioModal').on('hidden.bs.modal', function (e) {
        if (e.target.id == "funcionarioAgregarModal") {
            $('#manFuncionarioModal').attr("style", "display: block;");
        }       
    })
    // Creamos una validacion personalizada
    jQuery.validator.addMethod("defaultInvalid", function (value, element) {
        switch ($(element).attr('id')) {
            case 'ddlItemPN_DITipoId':
                return (value == '0000000') ? false : true;
                break;
            case 'txtItemPN_DIRUC':
                var valTventana = controles_Persona.frmPersonaControles.find("#tVentana").val();
                if (valTventana == 'TI')
                    return (value.trim() == "") ? false : true;
                else return true;
                break;

        }
    });
    controles_Persona.frmPersonaControles.validate({
        focusInvalid: true,
        //ignore: '', hiden predeterminado
        rules: {
            txtItemPN_APaterno: { required: true },
            txtItemPN_AMaterno: { required: true },
            txtItemPN_Nombres: { required: true },
            ddlItemPN_DITipoId: { required: true, defaultInvalid: true },
            txtItemPN_DINumero: { required: true },
            txtItemPN_DIRUC: { defaultInvalid: true },
            txtItemPJ_RUC: { required: true },
            txtItemPJ_RSocial: { required: true },
            txtItemPN_DLDireccion: { required: true }
        },
        messages: {
            txtItemPN_APaterno: { required: "Ingrese apellido" },
            txtItemPN_AMaterno: { required: "Ingrese apellido" },
            txtItemPN_Nombres: { required: "Ingrese nombres" },
            ddlItemPN_DITipoId: { required: "Seleccione", defaultInvalid: "Seleccione tipo documento" },
            txtItemPN_DINumero: { required: "Ingrese dni" },
            txtItemPN_DIRUC: { defaultInvalid: "Ingrese ruc" },
            txtItemPJ_RUC: { required: "Ingrese ruc" },
            txtItemPJ_RSocial: { required: "Ingrese" },
            txtItemPN_DLDireccion: { required: "Ingrese direccion" }
        },
        invalidHandler: function (event, validator) {//display error alert on form submit   

        },
        errorPlacement: function (error, element) {// render error placement for each input type
            var loginElement = $(element);
            loginElement.addClass('border-danger');
            loginElement.attr('data-toggle', 'tooltip');
            loginElement.attr('data-placement', 'top');
            loginElement.attr('data-original-title', error.text());
            $('[data-toggle="tooltip"]').tooltip();

        },
        highlight: function (element) {

        },
        unhighlight: function (element) { // revert the change done by hightlight

        },
        success: function (label, element) {
            var loginElement = $(element);
            loginElement.removeClass('border-danger');
            loginElement.removeAttr('data-toggle', 'tooltip');
            loginElement.removeAttr('data-placement', 'top');
        },
        submitHandler: function (form) {
            if (controles_Persona.validarUbigeo()) {
                utilSigo.dialogConfirm("Confirmacion", "Desea continuar con la operacion?", function (r) {
                    if (r) {
                        controles_Persona.registrarPersona();
                    }
                });
            }                  
        }
    });
    //eventos y configuracion
    var valTipoPersona = controles_Persona.frmPersonaControles.find("#tipo").val();
     
    switch (valTipoPersona) {
        case "N":
                    controles_Persona.frmPersonaControles.find("#btnBuscarPersonaNatural").click(function () {
                        controles_Persona.buscarPersonaNJ();
                    });
                    break;
        case "J":
                    controles_Persona.frmPersonaControles.find("#btnBuscarPersonaJuridica").click(function () {
                    controles_Persona.buscarPersonaNJ();
                    });
                    break;
        default: controles_Persona.frmPersonaControles.find("#btnBuscarPersonaNatural").removeClass();
                    controles_Persona.frmPersonaControles.find("#btnBuscarPersonaNatural").parent().removeClass();
    }
    
    $("#btnClosePersona").click(function () {      
        controles_Persona.closePersonaModal();
    });
    controles_Persona.frmPersonaControles.find("#btnRegistrarPersona").click(function () {
        controles_Persona.frmPersonaControles.submit();
    });
    controles_Persona.frmPersonaControles.find("#btnUbigeoPersona").click(function () {        
        controles_Persona.cargarUbigeoModal('COD_UBIGEO');
    });
    controles_Persona.frmPersonaControles.find("#ddlItemPN_DITipoId").change(function () {
        var valSelect = $(this).val();
        switch (valSelect) {
            case '0000000': controles_Persona.frmPersonaControles.find("#txtItemPN_DINumero").attr("maxlength", 8); break;
            case '0000001': controles_Persona.frmPersonaControles.find("#txtItemPN_DINumero").attr("maxlength", 8); break;
            case '0000002': controles_Persona.frmPersonaControles.find("#txtItemPN_DINumero").attr("maxlength", 12); break;
            case '0000006': controles_Persona.frmPersonaControles.find("#txtItemPN_DINumero").attr("maxlength", 11); break;
        }
    });
});