"use strict";
var vpTHabilitante = {};
vpTHabilitante.url = urlLocalSigo + "THabilitante/ManPlanManejo/buscarTHabilitante?";
vpTHabilitante.columns_label = ["","N°", "Modalidad", "Número", "Titular (Apellidos y Nombres)"];
vpTHabilitante.fnAsignarDatos = function (obj) {

}
 
vpTHabilitante.columns = [
    {
        "autoWidth": true, "bSortable": false, "data": "num",
        "mRender": function (data, type, row) {
            var cell = '<input type="hidden" class="hdInd" value="' + row.ind + '" /><input type="hidden" class="hdCodigo" value="' + row.cod + '" /><input type="hidden" class="hdCod_mt" value="' + row.cod_mt + '" /><i class="fa fa-lg fa-check" style="cursor: pointer;color:forestgreen;" onclick="vpTHabilitante.fnAsignarDatos(this);"></i>';
            return cell;
        }
    },
    { "data": "num", "autoWidth": true },
    { "data": "mod", "autoWidth": true },    
    { "data": "nt", "autoWidth": true },
    { "data": "pt", "autoWidth": true }
    
   
];  
vpTHabilitante.fnChangeParamInit = function (obj) {
    vpTHabilitante.url = obj.url;
    vpTHabilitante.columns_label = obj.columns_label;
    vpTHabilitante.columns = obj.columns;
}
vpTHabilitante.fnCrearTabla = function () {
    vpTHabilitante.tbHabilitante = vpTHabilitante.frm.find("#tbHabilitanteBusqueda");     
    var trTH = "<tr>";
    for (var i = 0; i < vpTHabilitante.columns_label.length; i++) {
        trTH += "<th>" + vpTHabilitante.columns_label[i] + "</th>";
    }
    trTH += "</tr>";
    vpTHabilitante.tbHabilitante.find("thead").append(trTH);
    vpTHabilitante.dtTituloHabilitante = vpTHabilitante.tbHabilitante.DataTable({
        "bServerSide": false,
        "deferLoading": 0,
        "bAutoWidth": false,
        "bProcessing": true,
        "bJQueryUI": false,        
        "bFilter": false,
        "aaSorting": [],
        "bPaginate": true,
        "bInfo": false,
        "bLengthChange": false,
        "scrollY": "50vh",
        "scrollCollapse": true,
        "pageLength": initSigo.pageLengthBuscar,
        "oLanguage": initSigo.oLanguage,  
        "columns": vpTHabilitante.columns
    });
}
vpTHabilitante.fnBusqueda = function () {
    var valorBuscar = encodeURIComponent(vpTHabilitante.frm.find("#txtValor").val().trim());
    if (valorBuscar == "") {
        utilSigo.toastWarning("Aviso", "Ingrese Valor a Buscar");
        return false;
    }
    if (valorBuscar.length < 3) {
        utilSigo.toastWarning("Aviso", "Ingrese mayor a dos caracteres");
        return false;
    }
    var valTipo = vpTHabilitante.frm.find("#hdfTipoFormulario").val();
    var valCriterio = vpTHabilitante.frm.find("#cboCriterio").val();
    var vadenaEnviar = valTipo + "¬" + valCriterio + "¬" + valorBuscar;    
    var urlB = vpTHabilitante.url + "vb=" + vadenaEnviar;     
    vpTHabilitante.dtTituloHabilitante.ajax.url(urlB).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", initSigo.MessageError);
            console.log(data.e);
        }
    });
}

vpTHabilitante.initEventos = function () {
    vpTHabilitante.frm.find("#btnTHBuscar").click(function () {   
        vpTHabilitante.fnBusqueda();
    });
  
    vpTHabilitante.frm.submit(function (e) {
        vpTHabilitante.fnBusqueda();
        e.preventDefault();
    });
}

vpTHabilitante.fnInit = function () {
 
    vpTHabilitante.frm = $("#frmThBusqueda");
    vpTHabilitante.fnCrearTabla();
  
    vpTHabilitante.initEventos();

}

//------------------------



/*Modal Mejorado, anterior revisar para unificar*/
vpTHabilitante.fnBusqueda_v2 = function () {
    var valorFormulario = vpTHabilitante.frm.find("#hdfTipoFormulario").val();
    var valorCriterio = vpTHabilitante.frm.find("#cboCriterio").val();
    var valorBuscar = encodeURIComponent(vpTHabilitante.frm.find("#txtValor").val().trim());
    var url = urlLocalSigo + "General/Controles/buscarTH?vb=" + valorFormulario + "¬" + valorCriterio + "¬" + valorBuscar;

    if (valorBuscar == "") {
        utilSigo.toastWarning("Aviso", "Ingrese el valor a buscar");
        return false;
    }
    if (valorBuscar.length < 3) {
        utilSigo.toastWarning("Aviso", "El valor ingresado debe ser mayor a dos caracteres");
        return false;
    }

    vpTHabilitante.dtTituloHabilitante.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", initSigo.MessageError);
            console.log(data.e);
        }
    });
}

vpTHabilitante.fnInitEventos_v2 = function () {
    vpTHabilitante.frm.find("#btnTHBuscar").click(function () {
        vpTHabilitante.fnBusqueda_v2();
    });
    vpTHabilitante.frm.submit(function (e) {
        vpTHabilitante.fnBusqueda_v2();
        e.preventDefault();
    });
}
vpTHabilitante.columns_label_v2 = ["Título Habilitante", "Titular", "Modalidad"];
vpTHabilitante.columns_data_v2 = ["NUMERO", "PARAMETRO02", "PARAMETRO01"];
vpTHabilitante.fnInitDataTable_Detail = function () {
 
    var options = {
        page_length: initSigo.pageLengthBuscar, row_select: true, row_fnSelect: "vpTHabilitante.fnAsignarDatos(this)"
        , row_index: true
    };
    vpTHabilitante.dtTituloHabilitante = utilDt.fnLoadDataTable_Detail(vpTHabilitante.frm.find("#tbHabilitanteBusqueda"), vpTHabilitante.columns_label_v2, vpTHabilitante.columns_data_v2, options);
}

vpTHabilitante.fnInit_v2 = function () {
    vpTHabilitante.frm = $("#frmThBusqueda");

    vpTHabilitante.frm.find("#cboCriterio").select2({ minimumResultsForSearch: -1 });
    $('.modal').on('shown.bs.modal', function () {
        vpTHabilitante.frm.find("#txtValor").focus();
    });

    vpTHabilitante.fnInitDataTable_Detail();
    vpTHabilitante.fnInitEventos_v2();
}

