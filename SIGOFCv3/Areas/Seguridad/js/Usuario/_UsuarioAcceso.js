"use strict";
var _UsuarioAcceso = {
    
    fnQuitar: (indice) => {
        var accesoEli = [];
        if (indice < 0) {
            utilSigo.dialogConfirm('', 'Desea quitar todos los registros de accesos al usuario?', function (r) {
                if (r) {
                    accesoEli = _UsuarioAcceso.listAccesoAsig;
                    _UsuarioAcceso.fnSave(accesoEli, "E");
                }
            });
        }
        else {
            accesoEli.push(_UsuarioAcceso.listAccesoAsig[indice]);
            _UsuarioAcceso.fnSave(accesoEli, "E");
        }
    },    
    fnSave: (dataEnviar, op) => {
        var url = urlLocalSigo + "Seguridad/Usuario/DeleteUsuarioAcceso";
        var codUsuario = _UsuarioAcceso.fm.find("#hdCodUsuario").val();
        var model = { codUsuario: codUsuario, listAccesoAsig: dataEnviar, op: op };
        var option = { url: url, datos: JSON.stringify(model), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {                
                _UsuarioAcceso.GetListUsuarioAcceso({ codUsuario: codUsuario });
                utilSigo.toastSuccess("Éxito", data.msj);
            }
            else {
                utilSigo.toastWarning("Aviso", data.msj);
                console.log(data.msjError);
            }
        });
    },
    fnEditar: (indice) => {   
        if (indice == -1) {
            var option = {
                url: urlLocalSigo + "Seguridad/Usuario/_UsuarioAccesoControl",
                divId: "manAccesoModal",
                datos: { idUser: $("#hdCodUsuario").val() }
            };
        }
        else if (indice != null) {
            var itemRow = _UsuarioAcceso.listAccesoAsig[indice];
            var option = {
                url: urlLocalSigo + "Seguridad/Usuario/_UsuarioAccesoControl",
                divId: "manAccesoModal",
                datos: { idUser: $("#hdCodUsuario").val(), id: itemRow.id_acceso }
            };
        }
            
            utilSigo.fnOpenModal(option);
        //}



//    ManUsuarioAccesoControl_AddEdit.frm = $("#frmManUsuarioAccesoControl_AddEdit");
    //if (!utilSigo.fnGetValChk(ManUsuarioAccesoControl_AddEdit.frm.find("#activo"))) ManUsuarioAccesoControl_AddEdit.frm.find("#lblCheckActtivo").text("Inactivo");
    //var id = ManUsuario_AddEdit.frm.find("#id").val().trim();
    //if (id != "") {
    //    ManUsuario_AddEdit.frm.find("#divMod").show();
    //    ManUsuario_AddEdit.frm.find("#divP1").hide();
    //    ManUsuario_AddEdit.frm.find("#divP2").hide();
    //    ManUsuario_AddEdit.frm.find("#divRem").hide();
    //}
    //ManUsuario_AddEdit.frm.find("#activo").click(function () {
    //    if ($(this).is(":checked")) {
    //        ManUsuario_AddEdit.frm.find("#lblCheckActivo").text("Activo");
    //    }
    //    else {
    //        ManUsuario_AddEdit.frm.find("#lblCheckActivo").text("Inactivo");
    //    }
    //});
    //ManUsuario_AddEdit.frm.find("#modPassword").click(function () {
    //    ManUsuario_AddEdit.frm.find("#password").val('');
    //    ManUsuario_AddEdit.frm.find("#passwordR").val('');
    //    ManUsuario_AddEdit.frm.find("#remPassword").prop("checked", false)
    //    if ($(this).is(":checked")) {
    //        ManUsuario_AddEdit.frm.find("#divP1").show();
    //        ManUsuario_AddEdit.frm.find("#divP2").show();
    //        ManUsuario_AddEdit.frm.find("#divRem").show();
    //    }
    //    else {
    //        ManUsuario_AddEdit.frm.find("#divP1").hide();
    //        ManUsuario_AddEdit.frm.find("#divP2").hide();
    //        ManUsuario_AddEdit.frm.find("#divRem").hide();
    //    }
    //});
},
    fnBuildTable: (data, tbName, opRow) => {
        
        var table = $('#' + tbName);
        var tabla = table.children('tbody');
        tabla.children('tr').remove();
        var rows = '';
        var numero = 0;
        $.each(data, (i, r) => {
            rows += '<tr>';
            if (opRow == 1)
                rows += '<td><i class="cellDel fa fa-lg fa-window-close" title="Quitar la autorización del usuario" onclick="_UsuarioAcceso.fnQuitar(' + `${numero}` + ')"></i></td>';
            rows += '<td><i class="cellEdit fa fa-lg fa-pencil-square-o" title="Editar la autorización del usuario" onclick="_UsuarioAcceso.fnEditar(' + `${numero}` + ')"></i></td>';
            rows += '<td>' + `${++numero}` + '</td>';
            rows += '<td>' + `${r.accesoNoCaduca ? `SI` : `NO`}` + '</td>';
            rows += '<td>' + `${r.fecha_solicitud }` + '</td>';
            rows += '<td>' + `${r.fecha_registro}` + '</td>';
            rows += '<td>' + `${r.fecha_desde}` + '</td>';
            rows += '<td>' + `${r.fecha_hasta}` + '</td>';
            //if (opRow == 0)
            //    rows += '<td><i class="cellCheck fa fa-lg fa-check" title="Quitar Acceso" onclick="_UsuarioPerfil.fnAsignar(' + `${numero - 1}` + ')"></i></td>';
            rows += '</tr>';

        });
        tabla.append(rows);
    },
    GetListUsuarioAcceso: (dataEnviar) => {
        var url = urlLocalSigo + "Seguridad/Usuario/GetListUsuarioAcceso";
        //dataEnviar.p1 = _UsuarioAcceso.fm.find("#txtValor").val().trim();
        var option = { url: url, datos: JSON.stringify(dataEnviar), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                //no asignados
                //_UsuarioAcceso.listAcceso = data.data.listAcceso;
                //_UsuarioAcceso.fnBuildTable(_UsuarioAcceso.listAcceso, "tbListAcceso", 0);
                //asignados
                
                _UsuarioAcceso.listAccesoAsig = data.data.listAccesoAsig;
                // console.log(_UsuarioPerfil.lstMenusAsig);
                _UsuarioAcceso.fnBuildTable(_UsuarioAcceso.listAccesoAsig, "tbListAccesoAsig", 1);
            }
            else {
                utilSigo.toastWarning("Aviso", data.msj);
                console.log(data.msjError);
            }
        });
    },
    fnEvent: () => {
        $("#btnRegresarusuario").click(function () {
            ManUsuario.fnShowHide(0);
        });
        //_UsuarioAcceso.fm.find("#btnBuscarPerfil").click(function () {
        //    _UsuarioPerfil.GetListUsuarioPerfil({ codUsuario: _UsuarioPerfil.fm.find("#hdCodUsuario").val() });
        //});
        _UsuarioAcceso.fm.submit(function (e) {
            _UsuarioAcceso.GetListUsuarioAcceso({ codUsuario: _UsuarioAcceso.fm.find("#hdCodUsuario").val() });
            e.preventDefault();
        });
    },
    fnInit: () => {
        $.fn.select2.defaults.set("theme", "bootstrap4");
        _UsuarioAcceso.fm = $("#frmUsuarioAcceso");
        _UsuarioAcceso.fnEvent();
        //iniciando tablas                
        _UsuarioAcceso.GetListUsuarioAcceso({ codUsuario: _UsuarioAcceso.fm.find("#hdCodUsuario").val() });
        _UsuarioAcceso.tbListAccesoAsig = $("#tbListAccesoAsig")
    }
};
//_UsuarioAcceso.fnShowHide = function (opcion) {
//    if (opcion == 1) {
//        $("#manAccesoModal").slideDown();
//    }
//    else {

//        $("#manAccesoModal").slideUp();    }
//}
$(function () {
    _UsuarioAcceso.fnInit();
});