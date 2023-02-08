"use strict";
var controlesUbigeo = {};
controlesUbigeo.departamentos = [];
controlesUbigeo.provincias = [];
controlesUbigeo.distritos = [];
controlesUbigeo.cargarDepartamentos = function (data) {
    var cadenaDatos = data.split('¬');
    var depaData = cadenaDatos[0].split(',');
    var provData = cadenaDatos[1].split(',');
    var distData = cadenaDatos[2].split(',');
    for (var i = 0; i < depaData.length; i++) {
        var particionDepa = depaData[i].split('|');
        controlesUbigeo.departamentos.push({ COD_UBIDEPARTAMENTO: particionDepa[0], DEPARTAMENTO: particionDepa[1] });
    }
    for (var i = 0; i < provData.length; i++) {
        var particionProv = provData[i].split('|');
        controlesUbigeo.provincias.push({ COD_UBIDEPARTAMENTO: particionProv[0], COD_UBIPROVINCIA: particionProv[1], PROVINCIA: particionProv[2] });
    }
    for (var i = 0; i < distData.length; i++) {
        var particionDist = distData[i].split('|');
        controlesUbigeo.distritos.push({ COD_UBIGEO: particionDist[0], COD_UBIPROVINCIA: particionDist[1], DISTRITO: particionDist[2] });
    }
    //cargando departamentos
    utilSigo.fillComboSelect2Ubigeo(controlesUbigeo.frmUbigeo.find("#cboDepartamento"), controlesUbigeo.departamentos, 0);
}
controlesUbigeo.iniciarSelect2 = function () {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    controlesUbigeo.frmUbigeo.find("#cboDepartamento").select2();
    controlesUbigeo.frmUbigeo.find("#cboProvincia").select2();
    controlesUbigeo.frmUbigeo.find("#cboDistrito").select2();
}
controlesUbigeo.iniciarEventos = function () {
    controlesUbigeo.frmUbigeo.find("#cboDepartamento").change(function () {
        var depaSelectId = $(this).val();
        utilSigo.fillComboSelect2Ubigeo(controlesUbigeo.frmUbigeo.find("#cboProvincia"), controlesUbigeo.provincias, 1, depaSelectId);
        var provSelectId = controlesUbigeo.frmUbigeo.find("#cboProvincia").val();
        utilSigo.fillComboSelect2Ubigeo(controlesUbigeo.frmUbigeo.find("#cboDistrito"), controlesUbigeo.distritos, 2, provSelectId);

    });
    controlesUbigeo.frmUbigeo.find("#cboProvincia").change(function () {
        var provSelectId = $(this).val();
        utilSigo.fillComboSelect2Ubigeo(controlesUbigeo.frmUbigeo.find("#cboDistrito"), controlesUbigeo.distritos, 2, provSelectId);
    });
    controlesUbigeo.frmUbigeo.find("#cboDistrito").change(function () {
        var distSelectId = $(this).val();
        var provSelect = controlesUbigeo.frmUbigeo.find("#cboProvincia").val();      
        if (distSelectId != '-' && provSelect!='-')
        {           
            var formOrigen = controlesUbigeo.frmUbigeo.find("#ubHdFormularioOrigen").val();
            var controlOrigen = controlesUbigeo.frmUbigeo.find("#ubHdControlOrigen").val();
            var ubigeoText = controlesUbigeo.frmUbigeo.find("#cboDepartamento").select2('data')[0].text + " - " + controlesUbigeo.frmUbigeo.find("#cboProvincia").select2('data')[0].text + " - " + $(this).select2('data')[0].text;
            console.log(formOrigen);
            if (formOrigen == "frmPersonaControles")
            {
                controles_Persona.frmPersonaControles.find("#" + controlOrigen).val(ubigeoText);
                controles_Persona.frmPersonaControles.find("#hd" + controlOrigen).val(distSelectId);
                controles_Persona.validarUbigeo();
                controlesUbigeo.closeUbigeoModal();

            }
            if(formOrigen=="frmTHabilitanteRegistro")
            {
                ManTHabilitante.frmTHabilitanteRegistro.find("#" + controlOrigen).val(ubigeoText);
                ManTHabilitante.frmTHabilitanteRegistro.find("#hd" + controlOrigen).val(distSelectId);
                controlesUbigeo.closeUbigeoModal();


                utilSigo.loadAjaxCombo(initSigo.urlControllerGeneral + "/getDependenciasxUbigeo", $("#ddlDependenciaId"), { ubigeo: distSelectId }, null, false, null);

            }
        }        
    });   
}
controlesUbigeo.closeUbigeoModal = function () {
    $('#personaUbigeoModal').modal('hide');
    $('#personaUbigeoModal').html('');
    //$('#personaUbigeoModal').modal('dispose');
}
 
$(document).ready(function () {    
    controlesUbigeo.frmUbigeo = $("#frmUbigeo");
    controlesUbigeo.urlTraerUbigeo = controlesUbigeo.frmUbigeo.find("#hdUrl").val();
    controlesUbigeo.iniciarSelect2();
    controlesUbigeo.iniciarEventos();
    //traendo los datos de ubigeo
    $.ajax({
        url: controlesUbigeo.urlTraerUbigeo,
        type: 'GET',
        data: {},
        dataType: 'text',
        success: function (data) {
            utilSigo.unblockUIGeneral();           
            controlesUbigeo.cargarDepartamentos(data);            
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un Error Inesperado al cargar datos de ubigeo, Comuniquese con el Administrador");
            console.log(jqXHR.responseText);
        }
    });
});

