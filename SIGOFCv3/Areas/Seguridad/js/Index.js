"use strict";
var ManPerfil = {};
ManPerfil.addNewPersona = true;
ManPerfil.url = urlLocalSigo + "Seguridad/Perfil/GetListPerfil?"; 
ManPerfil.fnBuscarPerfil= function () {

    var valorBuscar = ManPerfil.frm.find("#txtValor").val().trim();
    var valCriterio = ManPerfil.frm.find("#cboCriterio").val();  
    var clasificacion = ManPerfil.frm.find("#cboSubClasificacion").val();
    if (ManPerfil.frm.find("#cboSubClasificacion").val() ==0) var valCriterio = "TODOS"; 
    else var valCriterio = "NOMBRE"; 
    var url = ManPerfil.url + "criterio=" + valCriterio + "&valor=" + valorBuscar + "&idclasificacion=" + clasificacion;   
    
    ManPerfil.dtPerfil.ajax.url(url).load(function (data) {
        //debugger
        if (data.success == false) {
            utilSigo.toastError("Error", "Sucedio un Error al listar los perfiles, Comuniquese con el Administrador");
            console.log(data.msjError);
        }
    });
    
}
ManPerfil.fnInitEventos = function () {
    ManPerfil.frm.find("#btnBuscar").click(function () {
        ManPerfil.fnBuscarPerfil();
    });
    ManPerfil.frm.submit(function (e) {
        ManPerfil.fnBuscarPerfil();
        e.preventDefault();
    });
    ManPerfil.frm.find("#btnNuevo").click(function () {
        ManPerfil.fnAddEditPersona(null);
    }); 
    ManPerfil.frm.find("#cboClasificacion").on('change', function () {
       // console.log($(this).val());
        if ($(this).val() != 0)
            ManPerfil.resultSelect('cboSubClasificacion', $(this).val());
        else
            $('#cboSubClasificacion').children('option:not(:first)').remove();
       // ManPerfil.resultSelect('cboSubClasificacion', $(this).val());
    });
    
}
ManPerfil.fnInitDataTable_Detail = function () {
    var columns_label = ["CLASIFICACIÓN","SUB CLASIFICACIÓN","Descripción", "Estado", "Usuario Modificación","F. Creación","F. Modificación"];
    var columns_data = ["CLASIFICACION","SUBCLASIFICACION","descr", "act", "ulogin", "freacion", "fmodificacion"];
    var data_extend = [
        {
            "data": "M", "title": "M", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return '<i class="fa fa-lg fa-newspaper-o" style="cursor: pointer;color:dodgerblue;" title="Enlazar Menus" onclick="ManPerfil.fnPerfilMenu(this)"></i>';
            }
        }         
    ];
    var options = {
        page_length: 20,
        row_delete: true, row_fnDelete: "ManPerfil.fnAddDelete(this)",
        row_edit: true, row_fnEdit:"ManPerfil.fnAddEditPersona(this)"
        , row_index: true, data_extend: data_extend };    
    ManPerfil.dtPerfil = utilDt.fnLoadDataTable_Detail($("#tbListPerfil"), columns_label, columns_data, options);
    ManPerfil.fnBuscarPerfil();   
}
ManPerfil.fnAddDelete = function (obj) {
    var itemRow = ManPerfil.dtPerfil.row($(obj).parents('tr')).data();
    utilSigo.dialogConfirm('', 'Esta seguro de eliminar el perfil: ' + itemRow.descr+'?', function (r) {
        if (r) {           
            var url = urlLocalSigo + "Seguridad/Perfil/DeletePerfil";
            var option = { url: url, datos:JSON.stringify({ id: itemRow.id }), type: 'POST' };
            utilSigo.fnAjax(option, function (data) {
                if (data.success) {
                    utilSigo.toastSuccess("Aviso", data.msj);
                    ManPerfil.fnBuscarPerfil();
                }
                else {
                    utilSigo.toastWarning("Aviso", initSigo.MessageError);
                    console.log(data.msj);
                }
            });
        }
    });   
}
ManPerfil.fnAddEditPersona = function (obj) {
    
    var codPerfil = "";
    if (obj != null) {         
        var itemRow = ManPerfil.dtPerfil.row($(obj).parents('tr')).data();
        codPerfil = itemRow.id;
    }
    var option = {
        url: urlLocalSigo + "Seguridad/Perfil/_AddEdit",
        divId: "manPerfilModal",
        datos: { cod: codPerfil }
        };
        utilSigo.fnOpenModal(option);
}
ManPerfil.fnPerfilMenu = function (obj) {
    //console.log('Perfil', obj);
    var itemRow = ManPerfil.dtPerfil.row($(obj).parents('tr')).data();    
    ManPerfil.fnLoadPErfilMenu(itemRow.id);
}
ManPerfil.fnInit = function () {
    ManPerfil.resultSelect('cboClasificacion');
    $('[data-toggle="tooltip"]').tooltip();   
    ManPerfil.frm = $("#frmListadoPerfil");
    ManPerfil.frm.find("#txtValor").focus();
    ManPerfil.fnInitEventos();
    ManPerfil.fnInitDataTable_Detail();   
}
ManPerfil.fnLoadPErfilMenu=function(codPerfil){
    var url = urlLocalSigo + "Seguridad/Perfil/_MenuPerfil";
    var option = { url: url, datos: { cod: codPerfil }, dataType:'html' };
    utilSigo.fnAjax(option, function (data) {
        $("#divPerfilMenu").html(data);
        ManPerfil.fnShowHide(1);
    });
}
ManPerfil.fnShowHide=function(opcion){
    if (opcion == 1) {
        $("#divPerfilMenu").slideDown();
        $("#divPerfil").slideUp();
    }
    else{
        $("#divPerfil").slideDown();
        $("#divPerfilMenu").slideUp();
    }
}
ManPerfil.resultSelect = function (e,o) {
    $.ajax({
        method: "GET",
        url: urlLocalSigo + "Seguridad/Perfil/GetListClasificacionPerfil?id=" + o||null,
        dataType: "json",
        success: function (d) {
            console.log('result', d)
            //debugger
            $('#'+e).children('option:not(:first)').remove();
            let s = document.getElementById(e);
            
            let r = d.data;
            for (var i = 0; i < r.length; i++) {
                var option = document.createElement("option");
                option.text = r[i].VDESCRIPCION;
                option.value = r[i].PK_PERFILESMAECLASIFICACION;
                s.add(option);
            }
           
            //$("#cboClasificacion").select2({
            //    data: data
            //})
        }
    });
}
$(document).ready(function () {
    ManPerfil.fnInit();
});