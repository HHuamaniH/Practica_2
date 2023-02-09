var ManPersonas_AddEdit = {};

ManPersonas_AddEdit.tbEliTABLA = [];
//para iniciar los eventos
ManPersonas_AddEdit.iniciarEventos = function () {
    ManPersonas_AddEdit.fnVistaTipoPersona(ManPersonas_AddEdit.frm.find("#tipoPersona").val());
    ManPersonas_AddEdit.fnVistaTipoCargo();
};

//vuelve a la vista principal del listado
ManPersonas_AddEdit.regresar = function (appServer) {
    var url = "";
    url = urlLocalSigo + "General/ManPersonas/Index" + (tipo == 'A' ?'?lstManMenu=1':'');
    window.location = url;
};

ManPersonas_AddEdit.fnSaveForm = function () {
    let codigoPersona = ManPersonas_AddEdit.frm.find("#codigoPersona").val();
    let RegEstadoPersona = ManPersonas_AddEdit.frm.find("#RegEstadoPersona").val();
    let tipoPersona = ManPersonas_AddEdit.frm.find("#tipoPersona").val();
    let ddlItemPN_DITipoId = ManPersonas_AddEdit.frm.find("#ddlItemPN_DITipoId").val();
    let txtItemPN_DINumero = ManPersonas_AddEdit.frm.find("#txtItemPN_DINumero").val();
    let txtItemPN_APaterno = ManPersonas_AddEdit.frm.find("#txtItemPN_APaterno").val();
    let txtItemPN_AMaterno = ManPersonas_AddEdit.frm.find("#txtItemPN_AMaterno").val();
    let txtItemPN_Nombres = ManPersonas_AddEdit.frm.find("#txtItemPN_Nombres").val();
    let ddlISexoId = ManPersonas_AddEdit.frm.find("#ddlISexoId").val();
    let txtIRazonSocial = ManPersonas_AddEdit.frm.find("#txtIRazonSocial").val();
    let hdfITipoCargo = ManPersonas_AddEdit.frm.find("#hdfITipoCargo").val();
    let txtINumRegFfs = ManPersonas_AddEdit.frm.find("#txtINumRegFfs").val();
    let txtINumRegProf = ManPersonas_AddEdit.frm.find("#txtINumRegProf").val();
    let txtICargo = ManPersonas_AddEdit.frm.find("#txtICargo").val();
    let txtINumColegiatura = ManPersonas_AddEdit.frm.find("#txtINumColegiatura").val();
    let ddlINivelAcademicoId = ManPersonas_AddEdit.frm.find("#ddlINivelAcademicoId").val();
    let ddlIEspecialidadId = ManPersonas_AddEdit.frm.find("#ddlIEspecialidadId").val();
    let codigoPersonaAlerta = ManPersonas_AddEdit.frm.find("#codigoPersonaAlerta").val();
    
    let rb_internet = $('input[name="rb_internet"]:checked').val();
    let model = {
        codigoPersona, RegEstadoPersona, tipoPersona, ddlItemPN_DITipoId, txtItemPN_DINumero, txtItemPN_APaterno, txtItemPN_AMaterno,
        txtItemPN_Nombres, ddlISexoId, txtIRazonSocial, hdfITipoCargo, txtINumRegFfs, txtINumRegProf,
        txtICargo, txtINumColegiatura, ddlINivelAcademicoId, ddlIEspecialidadId, codigoPersonaAlerta, rb_internet
    };

    let tbElimDomicilio = [], tbElimTelefono = [], tbElimCorreo = [];
    if (tipo == "A") {
        let msj = '';
        if (_renderListDomicilio.fnGetListDomicilio().length==0) {
            msj = '<br/> - Al menos una Dirección Real';
        }
        if (ManPersonas_AddEdit.frm.find("#hdfITipoCargo").val()=='') {
            msj += '<br/> - Tipo Cargo';
        }
        if (msj != '') {
            utilSigo.toastWarning("Aviso", "Debe registrar los campos:" + msj); return;
        }
    }
    
    model.tbDomicilio = _renderListDomicilio.fnGetListDomicilio();
    model.tbTelefono = _renderListTelefono.fnGetListTelefono();
    model.tbCorreo = _renderListCorreo.fnGetListCorreo();
    tbElimDomicilio = _renderListDomicilio.fnGetListElimDomicilio();
    tbElimTelefono = _renderListTelefono.fnGetListElimTelefono();
    tbElimCorreo = _renderListCorreo.fnGetListElimCorreo();

    if (tbElimDomicilio.length > 0) {
        for (let obj of tbElimDomicilio) {
            ManPersonas_AddEdit.tbEliTABLA.push(obj);
        }
    }
    if (tbElimTelefono.length > 0) {
        for (let obj of tbElimTelefono) {
            ManPersonas_AddEdit.tbEliTABLA.push(obj);
        }
    }
    if (tbElimCorreo.length > 0) {
        for (let obj of tbElimCorreo) {
            ManPersonas_AddEdit.tbEliTABLA.push(obj);
        }
    }

    model.tbEliTABLA = ManPersonas_AddEdit.tbEliTABLA;

    utilSigo.dialogConfirm("", "Está seguro registrar los datos?", function (r) {
        if (r) {
            let url = urlLocalSigo + "General/ManPersonas/Grabar";
            let option = { url: url, datos: JSON.stringify(model), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    window.location = `${urlLocalSigo}/General/ManPersonas/Index` + (tipo == 'A' ? '?lstManMenu=1' : '') ;
                    utilSigo.toastSuccess("Éxito", "Datos actualizados correctamente");
                }
                else {
                    
                    utilSigo.toastWarning("Aviso", data);
                }
            });
        }
    });
};

ManPersonas_AddEdit.fnSubmitForm = function () {
    if (ManPersonas_AddEdit.frm.find("#txtItemPN_DINumero").val().trim() == '') {
        utilSigo.toastWarning("Aviso", "Ingrese el número de documento"); return false;
    }

    if (ManPersonas_AddEdit.frm.find("#tipoPersona").val() == "N") {        
        if (ManPersonas_AddEdit.frm.find("#txtItemPN_APaterno").val().trim() == '') {
            utilSigo.toastWarning("Aviso", "Ingrese el apellido paterno"); return false;
        }
        if (ManPersonas_AddEdit.frm.find("#txtItemPN_AMaterno").val() == '') {
            utilSigo.toastWarning("Aviso", "Ingrese el apellido materno"); return false;
        }
        if (ManPersonas_AddEdit.frm.find("#txtItemPN_Nombres").val() == '') {
            utilSigo.toastWarning("Aviso", "Ingrese el nombre de la persona"); return false;
        }
        if (ManPersonas_AddEdit.frm.find("#ddlISexoId").val() == '00') {
            utilSigo.toastWarning("Aviso", "Debe seleccionar el sexo de la persona");
            ManPersonas_AddEdit.frm.find("#ddlISexoId").focus();
            return false;
        }
    }
    else if (ManPersonas_AddEdit.frm.find("#tipoPersona").val() == "J") {
        if (ManPersonas_AddEdit.frm.find("#txtIRazonSocial").val() == '') {
            utilSigo.toastWarning("Aviso", "Ingrese la razón social"); return false;
        }
    }

    let codTipoDocIde = ManPersonas_AddEdit.frm.find("#ddlItemPN_DITipoId").val();
    let lenNumDocIde = ManPersonas_AddEdit.frm.find("#txtItemPN_DINumero").val();

    if (codTipoDocIde == "0000001") {
        if (lenNumDocIde.trim().length != 8) {
            utilSigo.toastWarning("Aviso", "Número documento de identidad inválido. El DNI requiere de 8 dígitos");
            ManPersonas_AddEdit.frm.find("#txtItemPN_DINumero").focus();
            return false;
        }
    }
    if (codTipoDocIde == "0000006") {
        if (lenNumDocIde.trim().length != 11) {
            utilSigo.toastWarning("Aviso", "Número documento de identidad inválido. El RUC requiere de 11 dígitos");
            ManPersonas_AddEdit.frm.find("#txtItemPN_DINumero").focus();
            return false;
        }
    }

    let codTipCar = "";

    ManPersonas_AddEdit.frm.find("#ddlITipoCargoId option").each(function (index, item) {
        if ($(item).prop("selected") == true) {
            codTipCar += "," + $(item).val();
        }
    });
    ManPersonas_AddEdit.frm.find("#hdfITipoCargo").val(codTipCar);

    ManPersonas_AddEdit.fnSaveForm();
};

ManPersonas_AddEdit.fnVistaTipoPersona = function (dto) {
    if (dto == "N") {
        $("#dvDatosPNatural").show();
        $("#dvDatosPJuridica").hide();       
        //ManPersonas_AddEdit.frm.find("#ddlItemPN_DITipoId").val("0000001");
        ManPersonas_AddEdit.frm.find("#txtIRazonSocial").val("");
    }
    else if (dto == "J") {
        $("#dvDatosPNatural").hide();
        $("#dvDatosPJuridica").show();
        /*if (ManPersonas_AddEdit.frm.find("#ddlItemPN_DITipoId").val() == "0000001")
            ManPersonas_AddEdit.frm.find("#ddlItemPN_DITipoId").val("0000006");*/
        ManPersonas_AddEdit.frm.find("#txtItemPN_APaterno").val("");
        ManPersonas_AddEdit.frm.find("#txtItemPN_AMaterno").val("");
        ManPersonas_AddEdit.frm.find("#txtItemPN_Nombres").val("");
    }  
};

ManPersonas_AddEdit.fnVistaTipoCargo = function () {
    $("#dvINumRegFfs").hide();
    $("#dvINumRegProf").hide();
    $("#dvICargo").hide();
    $("#dvINumColegiatura").hide();
    $("#dvINivelAcademico").hide();
    $("#dvIEspecialidad").hide();

    if (ManPersonas_AddEdit.frm.find("#ddlITipoCargoId").val() != undefined) {
        let sTiposCargos = "";
        ManPersonas_AddEdit.frm.find("#ddlITipoCargoId option").each(function (index, item) {
            if ($(item).prop("selected") == true) {
                switch ($(item).val()) {
                    case '0000003':
                        $("#dvINumRegFfs").show();
                        $("#dvINumRegProf").show();
                        $("#dvICargo").show();
                        break;
                    case '0000004':
                    case '0000005':
                    case '0000006':
                        $("#dvICargo").show();
                        break;
                    case '0000007':
                        $("#dvINumColegiatura").show();
                        $("#dvINivelAcademico").show();
                        $("#dvIEspecialidad").show();
                        break;
                }
            }
            else {
                switch ($(item).val()) {
                    case '0000003':
                        ManPersonas_AddEdit.frm.find("#txtINumRegFfs").val("");
                        ManPersonas_AddEdit.frm.find("#txtINumRegProf").val("");
                        sTiposCargos += "a";
                        break;
                    case '0000004':
                        sTiposCargos += "b";
                        break;
                    case '0000005':
                        sTiposCargos += "c";
                        break;
                    case '0000006':
                        sTiposCargos += "d";
                        break;
                    case '0000007':
                        ManPersonas_AddEdit.frm.find("#txtINumColegiatura").val("");
                        ManPersonas_AddEdit.frm.find("#ddlINivelAcademicoId").val("0000000");
                        ManPersonas_AddEdit.frm.find("#ddlIEspecialidadId").val("0000000");
                        break;
                }
            }
        });

        if (sTiposCargos == "abcd") {
            ManPersonas_AddEdit.frm.find("#txtICargo").val("");
        }
    }
};

ManPersonas_AddEdit.fnLoadSumoSelect = function () {
    let sTiposCargos = ManPersonas_AddEdit.frm.find("#hdfITipoCargo").val();

    if (sTiposCargos != undefined) {
        let tipoCargos = sTiposCargos.split(',');
        let car = [];

        for (let i = 1; i < tipoCargos.length; i++) {
            car.push(tipoCargos[i]);
        }
        ManPersonas_AddEdit.frm.find("#ddlITipoCargoId").val(car);
    } else {
        ManPersonas_AddEdit.frm.find("#ddlITipoCargoId").val("");
    }

    ManPersonas_AddEdit.frm.find("#ddlITipoCargoId").SumoSelect({
        csvDispCount: 10, placeholder: "Tipo Cargo", search: true,
        searchText: "Buscar...", noMatch: 'No se encontraron resultados para "{0}"'
    });
}

ManPersonas_AddEdit.buscarPersonaNJ = function (option) {
    var buspCriterio = "", buspValor = "";

    buspValor = ManPersonas_AddEdit.frm.find("#txtIRazonSocial").val();
    if (option != 'NOMBRES') {
        buspValor = ManPersonas_AddEdit.frm.find("#txtItemPN_DINumero").val();
        if (ManPersonas_AddEdit.frm.find("#tipoPersona").val() == "N") {
            switch (ManPersonas_AddEdit.frm.find("#ddlItemPN_DITipoId").val()) {
                case "0000001":
                    buspCriterio = "DNI";
                    if (buspValor.trim() == "" || buspValor == null) {
                        utilSigo.toastWarning("Aviso", "Ingrese el número de DNI a buscar");
                        return false;
                    }
                    if (buspValor.trim().length < 8) {
                        utilSigo.toastWarning("Aviso", "Ingrese los 8 caracteres del DNI a buscar");
                        return false;
                    }
                    break;
                case "0000006":
                    buspCriterio = "RUC";
                    if (buspValor.trim() == "" || buspValor == null) {
                        utilSigo.toastWarning("Aviso", "Ingrese el número de RUC a buscar");
                        return false;
                    }
                    if (buspValor.trim().length < 11) {
                        utilSigo.toastWarning("Aviso", "Ingrese los 11 caracteres del RUC a buscar");
                        return false;
                    }
                    break;
                /*default:
                    utilSigo.toastWarning("Aviso", "La consulta para el tipo de documento no se encuentra disponible");*/
            }
        }
        else if (ManPersonas_AddEdit.frm.find("#tipoPersona").val() == "J") {
            buspCriterio = "RUC";
            if (buspValor.trim() == "" || buspValor == null) {
                utilSigo.toastWarning("Aviso", "Ingrese el número de RUC a buscar");
                return false;
            }
            if (buspValor.trim().length < 11) {
                utilSigo.toastWarning("Aviso", "Ingrese los 11 caracteres del RUC a buscar");
                return false;
            }
        }
    }
    
    $.ajax({
        url: urlLocalSigo + "General/Controles/buscarPersonaGeneral",
        type: 'GET',
        data: { asBusCriterio: option, asBusValor: buspValor.trim(), asCodPTipo: 'TODOS', asBusGrupo: 'PERSONA' },
        dataType: 'json',
        beforeSend: utilSigo.beforeSendAjax,
        complete: utilSigo.completeAjax,
        error: utilSigo.errorAjax,
        success: function (d) {
            //console.log('data persona', d);
            let msj = '';
            if (d.data.length > 0) {

                if (d.data.length > 1) {
                    msj = '<b>Existen ' + d.data.length + ' registros</b>.'
                    utilSigo.toastError("Notificar a soporte", msj);
                    //ManPersonas_AddEdit.frmN.find("#lblItemPN_RazonSocial").text("Razón Social: " + d.data[0].PERSONA);
                   
                }

                if (d.data[0].TIPO_PERSONA_TEXT == "Jurídica") {
                    ManPersonas_AddEdit.frm.find("#ddlItemPN_DITipoId").val("0000006");
                    ManPersonas_AddEdit.frm.find("#txtIRazonSocial").val(d.data[0].PERSONA);


                } else {
                    

                    ManPersonas_AddEdit.frm.find("#txtItemPN_APaterno").val(d.data[0].APE_PATERNO);
                    ManPersonas_AddEdit.frm.find("#txtItemPN_AMaterno").val(d.data[0].APE_MATERNO);
                    ManPersonas_AddEdit.frm.find("#txtItemPN_Nombres").val(d.data[0].NOMBRES);
                   
                }

                utilSigo.toastWarning("Aviso", '¡Persona ' + d.data[0].TIPO_PERSONA_TEXT + ' con Número <b>' + buspValor.trim() + '</b> ya se encuentra registrado...!');
                setTimeout(() => {
                    location.href = urlLocalSigo + "General/ManPersonas/AddEdit?asCodPersona=" + d.data[0].COD_PERSONA + "&tipo=" + tipo;
                }, 2700);
                
            }
            else {
                $.ajax({
                    url: urlLocalSigo + "General/Controles/buscarPersonaNJ_OSINFOR_PIDE",
                    type: 'POST',
                    data: { asBusCriterio: buspCriterio.trim(), asBusValor: buspValor.trim() },
                    dataType: 'json',
                    beforeSend: utilSigo.beforeSendAjax,
                    complete: utilSigo.completeAjax,
                    error: utilSigo.errorAjax,
                    success: function (data) {
                        var tipo_doc = ManPersonas_AddEdit.frm.find("#ddlItemPN_DITipoId").val();
                        ManPersonas_AddEdit.limpiarFormulario();
                        if (data.success)
                            ManPersonas_AddEdit.cargarDatosBusqueda(data.values, tipo_doc);
                        else utilSigo.toastWarning("Aviso", data.msj);
                    }
                });

            }


        }
    });
    
};

ManPersonas_AddEdit.limpiarFormulario = function () {
    ManPersonas_AddEdit.frm.find("#txtItemPN_APaterno").val("");
    ManPersonas_AddEdit.frm.find("#txtItemPN_AMaterno").val("");
    ManPersonas_AddEdit.frm.find("#txtItemPN_Nombres").val("");
    ManPersonas_AddEdit.frm.find("#txtIRazonSocial").val("");
};

ManPersonas_AddEdit.cargarDatosBusqueda = function (data, tipo_documento) {
    if (ManPersonas_AddEdit.frm.find("#tipoPersona").val() == 'N') {
        var paterno = "", materno = "", nombres = "", num_dni = "", num_ruc = "", direccion = "", ubigeo = "", cod_ubigeo = "", raz_soc;

        switch (tipo_documento) {
            case "0000001":
                paterno = data[2]; materno = data[3]; nombres = data[4]; num_dni = data[5];
                num_ruc = data[6]; direccion = data[9]; ubigeo = data[8]; cod_ubigeo = data[7];
                break;
            case "0000006":
                var razonSocial = data[0].split(' ');
                raz_soc = data[0];
                paterno = razonSocial.length > 0 ? razonSocial[0] : "";
                materno = razonSocial.length > 1 ? razonSocial[1] : "";
                nombres = razonSocial.length > 2 ? razonSocial[2] : "";
                nombres += razonSocial.length > 3 ? " " + razonSocial[3] : "";
                nombres += razonSocial.length > 4 ? " " + razonSocial[4] : "";
                nombres += razonSocial.length > 5 ? " " + razonSocial[5] : "";
                nombres += razonSocial.length > 6 ? " " + razonSocial[6] : "";
                num_dni = data[1]; num_ruc = data[1];
                direccion = data[4]; ubigeo = data[3]; cod_ubigeo = data[2];
                break;
        }

        ManPersonas_AddEdit.frm.find("#ddlItemPN_DITipoId").val(tipo_documento);
        ManPersonas_AddEdit.frm.find("#txtItemPN_APaterno").val(paterno);
        ManPersonas_AddEdit.frm.find("#txtItemPN_AMaterno").val(materno);
        ManPersonas_AddEdit.frm.find("#txtItemPN_Nombres").val(nombres);
    } else {
        ManPersonas_AddEdit.frm.find("#ddlItemPN_DITipoId").val("0000006");
        ManPersonas_AddEdit.frm.find("#txtIRazonSocial").val(data[0]);
    }
};

$(document).ready(function () {
    ManPersonas_AddEdit.frm = $("#frmPersonaRegistro");
    ManPersonas_AddEdit.fnLoadSumoSelect();
    ManPersonas_AddEdit.iniciarEventos();

    ManPersonas_AddEdit.frm.find("#tipoPersona").change(function () {
        ManPersonas_AddEdit.fnVistaTipoPersona(ManPersonas_AddEdit.frm.find(this).val());
    });

    ManPersonas_AddEdit.frm.find("#ddlITipoCargoId").change(function () {
        ManPersonas_AddEdit.fnVistaTipoCargo();
    });   

    ManPersonas_AddEdit.frm.find("#divBuscarPN").click(function () {
        ManPersonas_AddEdit.buscarPersonaNJ('DOCUMENTO');
    });
    ManPersonas_AddEdit.frm.find("#divBuscarNombre").click(function () {
        ManPersonas_AddEdit.buscarPersonaNJ('NOMBRES');
    });
});
