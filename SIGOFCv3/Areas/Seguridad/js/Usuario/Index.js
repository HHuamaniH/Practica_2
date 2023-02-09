"use strict";
var ManUsuario = {};

ManUsuario.fnLoadManGrillaPaging = function () {
    var url = initSigo.urlControllerGeneral + "_ManGrillaPaging";
    var data = ManUsuario.frm.serializeObject();
    var option = { url: url, datos: JSON.stringify(data), type: 'POST', dataType: 'html' };

    var columns_label = [], columns_data = [], options = {};
    columns_label = ["Fecha de registro", "Usuario", "Nombres ", "Estado"];
    columns_data = ["fCreacion", "usuario", "descripcion", "estado"];
    var data_extend = [
        {
            "data": "codigo", "title": "Perfil", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return '<i class="fa fa-lg fa-address-card-o" style="cursor: pointer;color:dodgerblue;" title="Usuario por perfil" onclick="ManUsuario.fnLoadOpcion(this,2);"></i>';
            }
        },
        //{
        //    "data": "codigo", "title": "Menus", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
        //        return '<i class="fa fa-lg fa-tasks" style="cursor: pointer;color:dodgerblue;" title="Usuario por Menus" onclick="ManUsuario.fnLoadOpcion(this,1);"></i>';
        //    }
        //},
        {
            "data": "codigo", "title": "Control Accesos", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return '<i class="fa fa-lg fa-key" style="cursor: pointer;color:dodgerblue;" title="Usuario por Control de Accesos" onclick="ManUsuario.fnLoadOpcion(this,3);"></i>';
            }
        }
    ];
    options = {
        page_paging: true, page_length: 20, row_delete: true, row_fnDelete: "", row_index: true, row_edit: true,
        row_fnEdit: "_ManGrillaPaging.fnCreate(this)", data_extend: data_extend
    };

    utilSigo.fnAjax(option, function (data) {
        ManUsuario.frm.find("#dvManUsuarioContenedor").html(data);
        _ManGrillaPaging.fnInit(columns_label, columns_data, options);
       
        //Eliminar los elementos DOM tipoFormulario y titleMenu para solucionar error "non-unique"
        ManUsuario.frm.find("#tipoFormulario").remove();
        ManUsuario.frm.find("#titleMenu").remove();

        _ManGrillaPaging.fnCreate = function (obj) {
            _ManGrillaPaging.fnReadConfigManGrillaPaging();
            var codUser = "";
            if (obj != null && obj!="") {
                var itemRow = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
                codUser = itemRow.codigo;
            }

            var url = urlLocalSigo + "Seguridad/Usuario/_Usuario";
            var option = { url: url, type: 'POST', datos: { id: codUser }, divId: "mdlManUsuario_Global" };
            utilSigo.fnOpenModal(option, function () {});
        }

    });
}
ManUsuario.fnLoadOpcion = function (obj,op) {
    var itemRow = _ManGrillaPaging.dtManGrillaPaging.row($(obj).parents('tr')).data();
    if (op == 1) { ManUsuario.fnLoadUsuarioMenu(itemRow.codigo); }
    else if (op == 2) { ManUsuario.fnLoadUsuarioPerfil(itemRow.codigo, itemRow.descripcion); }
    else if (op == 3) { ManUsuario.fnLoadUsuarioAccesos(itemRow.codigo, itemRow.descripcion); }
} 
ManUsuario.fnLoadUsuarioPerfil = function (codUsuario,usuario) {
    var url = urlLocalSigo + "Seguridad/Usuario/_UsuarioPerfil";
    var option = { url: url, datos: { idUser: codUsuario, desc: usuario }, dataType: 'html' };
    utilSigo.fnAjax(option, function (data) {
        $("#divManUsuarioMenu").html(data);
        ManUsuario.fnShowHide(1);
    });
}
ManUsuario.fnLoadUsuarioMenu = function (codUsuario) {
    var url = urlLocalSigo + "Seguridad/Usuario/_UsuarioMenu";
    var option = { url: url, datos: { idUser: codUsuario }, dataType: 'html' };
    utilSigo.fnAjax(option, function (data) {
        $("#divManUsuarioMenu").html(data);
        ManUsuario.fnShowHide(1);
    });
}
ManUsuario.fnLoadUsuarioAccesos = function (codUsuario, usuario) {
    var url = urlLocalSigo + "Seguridad/Usuario/_UsuarioAcceso";
    var option = { url: url, datos: { idUser: codUsuario, desc: usuario }, dataType: 'html' };
    utilSigo.fnAjax(option, function (data) {
        $("#divManUsuarioMenu").html(data);
        ManUsuario.fnShowHide(1);
    });
}
ManUsuario.fnShowHide = function (opcion) {
    if (opcion == 1) {
        $("#divManUsuarioMenu").slideDown();
        $("#divManUsuario").slideUp();
    }   
    else {
        $("#divManUsuario").slideDown();
        $("#divManUsuarioMenu").slideUp();
    }
}
$(document).ready(function () {
    ManUsuario.frm = $("#frmManUsuario");
    ManUsuario.fnLoadManGrillaPaging();
});