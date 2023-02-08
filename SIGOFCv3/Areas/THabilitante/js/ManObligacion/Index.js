"use strict";
var indexPM = {};
indexPM.contenedor = "contenedorPlanManejo";
const urlApiMibosque = 'https://wstest.osinfor.gob.pe:7000/ApiMiBosque/api/';
const enlaceTipoObligacion = urlApiMibosque+'Tipo/?vaNumGrupoTipo=1&vaNumObligacion=0&pageSize=11'
const enlaceEstado = urlApiMibosque +'Tipo/?vaNumGrupoTipo=5&vaNumObligacion=0'
indexPM.editarPM = function (obj) {
    var tr = $(obj).closest("tr");
    var tds = tr.find("td");
    var codTH = "";
    var hdCodObligacion = tr.find(".hdCodObligacion").val();
    var hdCodTipoObligacion = tr.find(".hdCodTipoObligacion").val();
    var param = "_tipoObligacion=" + hdCodTipoObligacion + "&_idObligacion=" + hdCodObligacion;
    var url = urlLocalSigo + "THabilitante/ManObligacion/OblicacionMiBosque?" + param;
    window.location.href = url;
}
indexPM.deletePM = function (obj) {
    var tr = $(obj).closest("tr");
    var hdCodPM = tr.find(".hdCodPM").val();
    utilSigo.dialogConfirm('', 'Esta seguro de eliminar el item seleccionado?', function (r) {
        if (r) {
            var url = urlLocalSigo + "THabilitante/ManPlanManejo/DeletetPM";
            var dataEnviar = { codPM: hdCodPM };
            var option = { datos: dataEnviar, url: url };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    utilSigo.toastSuccess("Aviso", data.msj);

                    //alert();
                    //$("#txtValor").val(' ');
                    url = urlLocalSigo + "THabilitante/ManPlanManejo/Index";
                    setTimeout(() => { window.location.href = url; }, 2000);
                    //indexPM.buscarPlanManejo(true);
                }
                else {
                    utilSigo.toastWarning("Aviso", initSigo.MessageError);
                    console.log(data.msjError);
                }
            });
        }
    });
}
indexPM.editExSitu = function (obj) {
    var tr = $(obj).closest("tr");
    var tds = tr.find("td");
    var hdCodPM = tr.find(".hdCodPM").val();
    var modTH = tds.eq(7).text().trim();
    var numTH = tds.eq(8).text().trim();
    var tituTH = tds.eq(5).text().trim();
    var indi = tr.find(".hdIndi").val();
    var hdCodMT = tr.find(".hdCodMT").val();
    var param = "codPM=" + hdCodPM + "&codTH=" + codTH + "&modTH=" + modTH + "&numTH=" + numTH + "&tituTH=" + tituTH + "&indi=" + indi + "&cod_mtipo=" + hdCodMT;
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/EditExSitu?" + param;
    window.location.href = url;
}
indexPM.fnNewPM = function () {
    var urlTH = urlLocalSigo + "General/Controles/_THabilitante";
    var option = { url: urlTH, type: 'GET', datos: { hdfFormulario: "PLAN_MANEJO" }, divId: "contenedorTHBuscarModal" };
    utilSigo.fnOpenModal(option, function () {
        vpTHabilitante.fnAsignarDatos = function (obj) {
            var tr = $(obj).closest("tr");
            var tds = tr.find("td");
            var hdCodPM = "";
            var codTH = tr.find(".hdCodigo").val();
            var modTH = tds.eq(2).text().trim();
            var numTH = tds.eq(3).text().trim();
            var tituTH = tds.eq(4).text().trim();
            var indi = tr.find(".hdInd").val();
            var hdCodMT = tr.find(".hdCod_mt").val();
            var param = "codPM=" + hdCodPM + "&codTH=" + codTH + "&modTH=" + modTH + "&numTH=" + numTH + "&tituTH=" + tituTH + "&indi=" + indi + "&cod_mtipo=" + hdCodMT;
            var url = urlLocalSigo + "THabilitante/ManPlanManejo/AddEditPM?" + param;
            window.location.href = url;
        }
        vpTHabilitante.fnInit();
    });
}
indexPM.fnIniciarEventos = function () {
    var contenedo = $("#contenedorPlanManejo_Control");
    contenedo.find("#btnCreateNew").click(function () {
        indexPM.fnNewPM();
    });
}

indexPM.buscarPlanManejo = function (init) {
    var valCriterio = "";
    if (init)
        valCriterio = "TODOS";
    else valCriterio = indexPM.frm.find("#cboOpciones").val();
    var valBuscar = indexPM.frm.find("#txtValor").val().trim();
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/GetAllPlanManejo?busCriterio=" + valCriterio + "&busValor=" + valBuscar;
    indexPM.dtPM.ajax.url(url).load(function (data) {
        if (data.s == false) {
            utilSigo.toastError("Error", "Sucedio un Error al cargar registros en la tabla, Comuniquese con el Administrador");
            console.log(data.e);
        }
    });
}
indexPM.iniciarEventos = function () {
    //indexPM.frm.find("#btnManGrillaNuevo").click(function () {

    //});
    indexPM.frm.find("#btnManGrillaReload").click(function () {
        indexPM.frm.find("#txtValor").val('');
        indexPM.frm.find("#txtValor").focus();
        indexPM.buscarPlanManejo(true);
    });
    indexPM.frm.find("#btnManGrillaBuscar").click(function () {
        var valBuscar = indexPM.frm.find("#txtValor").val().trim();
        if (valBuscar == "") {
            indexPM.frm.find("#txtValor").focus();
            utilSigo.toastWarning("Aviso", "Ingrese Valor a Buscar");
            return false;
        }
        else {
            var cantCarateres = valBuscar.length;
            if (cantCarateres < 3) {
                indexPM.frm.find("#txtValor").focus();
                utilSigo.toastWarning("Aviso", "Longitud del criterio de busqueda debe ser mayor a dos caracteres");
                return false;
            }
            indexPM.buscarPlanManejo();
        }

    });
    //indexPM.frm.find("#txtValor").keypress(function (e) {
    //    var code = e.which;
    //    if (code == 13) {
    //        var valBuscar = indexPM.frm.find("#txtValor").val().trim();
    //        if (valBuscar == "") {
    //            indexPM.frm.find("#txtValor").focus();
    //            utilSigo.toastWarning("Aviso", "Ingrese Valor a Buscar");
    //            return false;
    //        }
    //        else {
    //            var cantCarateres = valBuscar.length;
    //            if (cantCarateres < 3) {
    //                indexPM.frm.find("#txtValor").focus();
    //                utilSigo.toastWarning("Aviso", "Longitud del criterio de busqueda debe ser mayor a dos caracteres");
    //                return false;
    //            }
    //            indexPM.buscarPlanManejo();
    //        }
    //        return false;
    //    }

    //});
}
function comboGeneral(nombreCombo, urlDest) {
    var combo;
   
    combo = $("#" + nombreCombo);
    combo.html('');
    let datos = getListaCombo(urlDest);
   
    datos.then(json => {
        let datosLista = json["result"];
        $.each(datosLista, function (i, item) {
            combo.append('<option value="' + item.vaNumTipo + '">' + item.vaTipoDescripcion + '</option>');
        });
        
    });

}
 async function getListaCombo( urlDest) {
    /*var params = 'https://wstest.osinfor.gob.pe:7000/ApiMiBosque/api/Tipo/?vaNumGrupoTipo=1&vaNumObligacion=0&pageSize=11';*/
     let response = await fetch(urlDest);
    let data = await response.json()
    return data;
}
function busquedaObligaciones() {
    var tipoObligacionOpcion = $("#cboOpciones").val();
    var estadoOpcion = $("#cboOpciones2").val();
    var rutaPage = '?pageSize=50&vaEstado=';
    var obligacionRuta="";
    switch (tipoObligacionOpcion) {
        case 1:
            obligacionRuta = 'InformeEjecucion' + rutaPage + estadoOpcion;
            break;
        case 2:
            obligacionRuta = 'RegenteForestal' + rutaPage + estadoOpcion;
            break;
        case 3:
            obligacionRuta = 'LibroOperaciones' + rutaPage + estadoOpcion;
            break;
        case 4:
            obligacionRuta = 'CustodioForestal' + rutaPage + estadoOpcion;
            break;
        case 5:
            obligacionRuta = 'ContratoTerceros' + rutaPage + estadoOpcion;
        case 6:
            obligacionRuta = 'RegistroHitoLindero' + rutaPage + estadoOpcion;
            break;
        case 7:
            obligacionRuta = 'RegistroFielCumplimiento' + rutaPage + estadoOpcion;
        case 8:
            obligacionRuta = 'FrutosProductosSubProductos' + rutaPage + estadoOpcion;
        case 9:
            obligacionRuta = 'RegistroMarcadoTrozas' + rutaPage + estadoOpcion;
            break;
        case 10:
            obligacionRuta = 'RegistroMedidaCorrectiva' + rutaPage + estadoOpcion;
            break;
        case 11:
            obligacionRuta = 'RegistroPlanAdministrativo' + rutaPage + estadoOpcion;
            break;
    }
}
function getTextoEstado(numEstado) {
    var textEstado = numEstado;
    if (numEstado == "1") {
        textEstado = "Guardado";
    }
    if (numEstado == "2") {
        textEstado = "Enviado";
    }
    if (numEstado == "3") {
        textEstado = "Aprobado";
    }
    if (numEstado == "4") {
        textEstado = "Observado";
    }
    return textEstado;
}
function getTextoTipoObligación(numTipoObligacion) {
    var tipoObligacionOpcion = "";

    switch (numTipoObligacion) {
        case 1:
            tipoObligacionOpcion = 'Informe de ejecución';
            break;
        case 2:
            tipoObligacionOpcion = 'Regente forestal';
            break;
        case 3:
            tipoObligacionOpcion = 'Libro de operaciones';
            break;
        case 4:
            tipoObligacionOpcion = 'Custodio forestal';
            break;
        case 5:
            tipoObligacionOpcion = 'Contrato con terceros' ;
        case 6:
            tipoObligacionOpcion = 'Linderos, hitos u otros';
            break;
        case 7:
            tipoObligacionOpcion = 'Garantía de fiel cumplimiento';
        case 8:
            tipoObligacionOpcion = 'Movilización de frutos';
        case 9:
            tipoObligacionOpcion = 'Marcado de trozas y tocones';
            break;
        case 10:
            tipoObligacionOpcion = 'Medidas correctivas';
            break;
        case 11:
            tipoObligacionOpcion = 'Actos administrativos';
            break;
        default:
            tipoObligacionOpcion = numTipoObligacion;
    }
    return tipoObligacionOpcion
}
$(document).ready(function () {
 
    //comboGeneral("cboOpciones", enlaceTipoObligacion);
    //comboGeneral("cboOpciones2", enlaceEstado);
    
    if ($("#hdMsj").val().trim() != "") utilSigo.toastSuccess("Aviso", $("#hdMsj").val());
    indexPM.fnIniciarEventos();
    indexPM.frmAddEdit = $("#frmAddEditPM");
    indexPM.frmEditExSitu = $("#frmEditExSitu");
    _manGrilla.columns_label = [
        "", "N°", "Título Habilitante", "Plan de manejo", "Tipo de obligación", "Nombre de obligación","Fecha pres.","Estado"
    ];
    _manGrilla.url = urlLocalSigo + "THabilitante/ManObligacion/GetAllObligacion";
    _manGrilla.paramInit = { obligacion: "0", estado: "2" };
    _manGrilla.createTrs = function (data) {
        var trsAdd = [];
        for (var i = 0; i < data.result.length; i++) {      
            var tr = [
                '<i class="fa fa-lg fa-pencil-square-o" title="Modificar Registro" style="cursor:pointer;" onclick="indexPM.editarPM(this);"></i>' +
                '<input type="hidden" class="hdCodObligacion" value="' + data.result[i].inIdObligacion + '" />' +
                '<input type="hidden" class="hdCodTipoObligacion" value="' + data.result[i].inTipoObligacion + '" />',
                (i + 1), data.result[i].inIdTituloHabilitante, data.result[i].inIdPlanManejo, getTextoTipoObligación(data.result[i].inTipoObligacion), data.result[i].vaNombreObligacion, data.result[i].faFechaPresentacion
                , getTextoEstado(data.result[i].vaEstado)];
            trsAdd.push(tr);
        }
        return trsAdd;
    }
    _manGrilla.isPaging = false;
    _manGrilla.fnLoadViewGeneral(indexPM.contenedor);

    //reporte 
    //_manGrilla.fnExportar = function () {
    //    let url = urlLocalSigo + "THabilitante/ManPlanManejo/DownloadPlanManejo";
    //    var xhr = new XMLHttpRequest();
    //    xhr.onload = function () {
    //        if (xhr.readyState === 4 && xhr.status === 200) {
    //            window.location.href = url;
    //        }
    //        else if (xhr.status === 404) {
    //            utilSigo.toastWarning("Aviso", "Sucedio un error, No existe la direccion de descarga");
    //        }
    //        else if (xhr.status === 0) {
    //            utilSigo.toastWarning("Aviso", "Sucedio un error, No existe el archivo");
    //        }
    //        else {
    //            utilSigo.toastWarning("Aviso", "Sucedio un error al descargar el archivo, Comuníquese con el Administrador");
    //        }
    //    };
    //    xhr.open('head', url);
    //    xhr.send(null);
    //};
});

