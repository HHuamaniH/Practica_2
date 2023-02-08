"use strict";
var indexPM = {};
indexPM.contenedor = "contenedorPlanManejo";
var strDatosObligacion = new Object();
const urlApiMibosque = 'https://wstest.osinfor.gob.pe:7000/ApiMiBosque/api/';
const enlaceTipoObligacion = urlApiMibosque + 'Tipo/?vaNumGrupoTipo=1&vaNumObligacion=0&pageSize=11'
const enlaceEstado = urlApiMibosque + 'Tipo/?vaNumGrupoTipo=5&vaNumObligacion=0'
function cargarDatos(_contenedor) {
    if ($("#" + _contenedor).length == 0) {
        //utilSigo.unblockUIGeneral();
        utilSigo.toastError("Error", initSigo.MessageError);
        console.log("El contenedor de la vista consultada no existe.");
        return false;
    }
    var url = $("#" + _contenedor).data('request_url');
    var formulario = $("#" + _contenedor).data('request_formulario');
    var tituloFormulario = $("#" + _contenedor).data('request_titulo');
    var obligacion = $("#hdIdObligacion").val();
    var tipoObligacion = $("#hdTipoObligacion").val();
    var datos = {
        tipoFormulario: formulario,
        titleMenu: tituloFormulario,
        idObligacion: obligacion,
        idTipoObligacion: tipoObligacion
    };
    $.ajax({
        url: url,
        type: 'POST',
        data: datos,
        dataType: 'html',
        success: function (vista) {
            utilSigo.unblockUIGeneral();
            $("#" + _contenedor).html(vista);
            $('[data-toggle="tooltip"]').tooltip();
            getObligacion();
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", initSigo.MessageError);
            console.log(jqXHR.responseText);
        },
        statusCode: {
            203: () => { utilSigo.unblockUIGeneral(); utilSigo.toastInfo("Aviso", "El usuario perdio la sesión. Vuelva ingresar al sistema"); }
        }
    });
}
async function getDatosApi(urlDest) {
    /*var params = 'https://wstest.osinfor.gob.pe:7000/ApiMiBosque/api/Tipo/?vaNumGrupoTipo=1&vaNumObligacion=0&pageSize=11';*/
    let response = await fetch(urlDest);
    let data = await response.json()
    return data;
}
function getObligacion() {
    var tipoObligacion = $("#hdTipoObligacion").val();
    var obligacionId = $("#hdIdObligacion").val();
    var obligacionRuta = "";
    switch (tipoObligacion) {
        case "1":
            obligacionRuta = 'InformeEjecucion/' + obligacionId;
            break;
        case "2":
            obligacionRuta = 'RegenteForestal/' + obligacionId;
            break;
        case "3":
            obligacionRuta = 'LibroOperaciones/' + obligacionId;
            break;
        case "4":
            obligacionRuta = 'CustodioForestal/' + obligacionId;
            break;
        case "5":
            obligacionRuta = 'ContratoTerceros/' + obligacionId;
        case "6":
            obligacionRuta = 'RegistroHitoLindero/' + obligacionId;
            break;
        case "7":
            obligacionRuta = 'RegistroFielCumplimiento/' + obligacionId;
            break;
        case "8":
            obligacionRuta = 'FrutosProductosSubProductos/' + obligacionId;
            break;
        case "9":
            obligacionRuta = 'RegistroMarcadoTrozas/' + obligacionId;
            break;
        case "10":
            obligacionRuta = 'RegistroMedidaCorrectiva/' + obligacionId;
            break;
        case "11":
            obligacionRuta = 'RegistroPlanAdministrativo/' + obligacionId;
            break;
    }
    let datosObligacion = getDatosApi(urlApiMibosque + obligacionRuta);
 
    datosObligacion.then(json => {
        strDatosObligacion = json;
        var stri = strDatosObligacion.vaComentario;
        $("#observaciones").val(stri);

    });
}
function Regresar() {
    window.location.href = ("../ManObligacion/Index");
}
$(document).ready(function () {
    cargarDatos(indexPM.contenedor);

});