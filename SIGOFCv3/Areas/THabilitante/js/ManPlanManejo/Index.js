"use strict";
var indexPM = {};
indexPM.contenedor = "contenedorPlanManejo";
indexPM.editarPM = function (obj) {
    var tr = $(obj).closest("tr");
    var tds = tr.find("td");
    var codTH = "";
    var hdCodPM = tr.find(".hdCodPM").val();
    var modTH = tds.eq(7).text().trim();
    var numTH = tds.eq(8).text().trim();
    var tituTH = tds.eq(5).text().trim();
    var indi = tr.find(".hdIndi").val();
    var hdCodMT = tr.find(".hdCodMT").val();
    var param = "codPM=" + hdCodPM + "&codTH=" + codTH + "&modTH=" + modTH + "&numTH=" + numTH + "&tituTH=" + tituTH + "&indi=" + indi + "&cod_mtipo=" + hdCodMT;
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/AddEditPM?" + param;
    window.location.href = url;    
}
indexPM.deletePM = function (obj) {
    var tr = $(obj).closest("tr");   
    var hdCodPM = tr.find(".hdCodPM").val();
    utilSigo.dialogConfirm('', 'Esta seguro de eliminar el item seleccionado?', function (r) {
        if (r) {
            var url = urlLocalSigo + "THabilitante/ManPlanManejo/DeletetPM";
            var dataEnviar = { codPM: hdCodPM};
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
    var hdCodMT=tr.find(".hdCodMT").val();   
    var param = "codPM=" + hdCodPM + "&codTH=" + codTH + "&modTH=" + modTH + "&numTH=" + numTH + "&tituTH=" + tituTH + "&indi=" + indi + "&cod_mtipo=" + hdCodMT;         
    var url = urlLocalSigo + "THabilitante/ManPlanManejo/EditExSitu?"+param;
    window.location.href = url;    
}
indexPM.fnNewPM = function () {    
    var urlTH=urlLocalSigo + "General/Controles/_THabilitante";
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
    indexPM.frm.find("#btnManGrillaNuevo").click(function () {

    });
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
    indexPM.frm.find("#txtValor").keypress(function (e) {
        var code = e.which;
        if (code == 13) {
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
            return false;
        }
        
    });
}
$(document).ready(function () {   
    if ($("#hdMsj").val().trim() != "") utilSigo.toastSuccess("Aviso", $("#hdMsj").val());
    indexPM.fnIniciarEventos();
    indexPM.frmAddEdit = $("#frmAddEditPM");
    indexPM.frmEditExSitu = $("#frmEditExSitu");
    _manGrilla.columns_label = [
        "","","", "N°", "Fecha", "Titular", "Nro Resolución", "Modalidad", "N° T. Habilitante"
    ];
    _manGrilla.url = urlLocalSigo + "THabilitante/ManPlanManejo/GetAllPlanManejo";
    _manGrilla.paramInit = { busFormulario: "PLAN_MANEJO", busCriterio: "TODOS", busValor: "" };
    _manGrilla.createTrs = function (data) {
        var trsAdd = [];        
        for (var i = 0; i < data.length; i++) {
            var fExt = "";
            if (data[i].INDICADOR == "ES")
                fExt = '<i class="fa fa-lg fa-outdent" title="ExSitu Otros" style="cursor:pointer;" onclick="indexPM.editExSitu(this);"></i>';
                       
            var tr = [fExt,
                '<i class="fa fa-lg fa-pencil-square-o" title="Modificar Registro" style="cursor:pointer;" onclick="indexPM.editarPM(this);"></i>' +
                '<input type="hidden" class="hdCodMT" value="' + data[i].COD_MTIPO + '" />' +
                '<input type="hidden" class="hdCodPM" value="' + data[i].COD_PMANEJO + '" />' +
                '<input type="hidden" class="hdIndi" value="' + data[i].INDICADOR + '" />',
                '<i class="fa fa-lg fa-times" title="Eliminar" style="cursor:pointer;color:red;" onclick="indexPM.deletePM(this);"></i>',
                (i + 1), data[i].FECHA_PRESENTACION, data[i].PERSONA_TITULAR, data[i].ARESOLUCION_NUM, data[i].MODALIDAD, data[i].NUM_THABILITANTE];
            trsAdd.push(tr);
        }
        return trsAdd;
     }
    _manGrilla.isPaging = false;
    _manGrilla.fnLoadViewGeneral(indexPM.contenedor);

    //reporte 
    _manGrilla.fnExportar = function () {
        let url = urlLocalSigo + "THabilitante/ManPlanManejo/DownloadPlanManejo";
        var xhr = new XMLHttpRequest();
        xhr.onload = function () {
            if (xhr.readyState === 4 && xhr.status === 200) {
                window.location.href = url;
            }
            else if (xhr.status === 404) {
                utilSigo.toastWarning("Aviso", "Sucedio un error, No existe la direccion de descarga");
            }
            else if (xhr.status === 0) {
                utilSigo.toastWarning("Aviso", "Sucedio un error, No existe el archivo");
            }
            else {
                utilSigo.toastWarning("Aviso", "Sucedio un error al descargar el archivo, Comuníquese con el Administrador");
            }
        };
        xhr.open('head', url);
        xhr.send(null);    
    };
});