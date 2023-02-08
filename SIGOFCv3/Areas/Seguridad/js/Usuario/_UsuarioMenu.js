"use strict";
var _MenuUsuario = {
    fnAsignar: (indice) => {
        var menuAdd = [];
        if (indice < 0) {
            utilSigo.dialogConfirm('', 'Desea asignar todas las opciones al usuario?', function (r) {
                if (r) {
                    menuAdd = _MenuUsuario.lstMenus;
                    _MenuUsuario.fnSave(menuAdd, "A");
                }
            });
        }
        else {
            menuAdd.push(_MenuUsuario.lstMenus[indice]);
            _MenuUsuario.fnSave(menuAdd, "A");
        }
    },
    fnQuitar: (indice) => {
        var menuEli = [];
        if (indice < 0) {
            utilSigo.dialogConfirm('', 'Desea quitar todas las opciones al usuario?', function (r) {
                if (r) {
                    menuEli = _MenuUsuario.lstMenusAsig;
                    _MenuUsuario.fnSave(menuEli, "E");
                }
            });
        }
        else {
            menuEli.push(_MenuUsuario.lstMenusAsig[indice]);
            _MenuUsuario.fnSave(menuEli, "E");
        }
    },
    fnSave: (dataEnviar, op) => {
        var url = urlLocalSigo + "Seguridad/Usuario/SaveUsuarioMenu";
        var codUsuario = _MenuUsuario.fm.find("#codUsuario").val();
        var model = { codUsuario: codUsuario, listMenusAsig: dataEnviar, op: op };
        var option = { url: url, datos: JSON.stringify(model), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                _MenuUsuario.GetListMenusUsuario({ codUsuario: codUsuario });
                utilSigo.toastSuccess("Éxito", data.msj);
            }
            else {
                utilSigo.toastWarning("Aviso", initSigo.MessageError);
                console.log(data.msjError);
            }
        });
    },
    fnBuildTable: (data, tbName, opRow) => {
        var table = $('#' + tbName);
        var tabla = table.children('tbody');
        tabla.children('tr').remove();
        var rows = '';
        var numero = 0;
        var campoAgrupadorModuloA = "";
        var campoAgrupadorGrupoA = "";
        $.each(data, (i, r) => {
            if (r.MODULO != campoAgrupadorModuloA) {
                rows += '<tr>';
                rows += '<td colspan="6" style="color: blue;font-weight: bold;">' + `${r.MODULO}` + '</td>';
                rows += '</tr>';
                campoAgrupadorModuloA = r.MODULO;
                rows += '<tr>';
                rows += '<td colspan="6" style="color: red; font-weight: bold;">' + `${r.GRUPO}` + '</td>';
                rows += '</tr>';
                campoAgrupadorGrupoA = r.GRUPO;

            }
            else if (r.GRUPO != campoAgrupadorGrupoA) {
                rows += '<tr>';
                rows += '<td colspan="6" style="color: red; font-weight: bold;">' + `${r.GRUPO}` + '</td>';

                rows += '</tr>';
                campoAgrupadorGrupoA = r.GRUPO;
            }
            rows += '<tr>';
            if (opRow == 1)
                rows += '<td><i class="cellDel fa fa-lg fa-window-close" title="Asignar Menu" onclick="_MenuUsuario.fnQuitar(' + `${numero}` + ')"></i></td>';
            rows += '<td>' + `${++numero}` + '</td>';
            rows += '<td>' + `${r.MENU_PADRE}` + '</td>';
            rows += '<td>' + `${r.MENU_HIJO}` + '</td>';

            if (opRow == 0)
                rows += '<td><i class="cellCheck fa fa-lg fa-check" title="Quitar Menu" onclick="_MenuUsuario.fnAsignar(' + `${numero - 1}` + ')"></i></td>';
            else {
                rows += '<td>' + `${r.VALIAS || ' '}` + '</td>';
                rows += "<td><i class='cellCheck fa fa-lg fa-edit' title='Rol' onclick='_MenuUsuario.rol(" + JSON.stringify(r).toString() + ")'></i></td>";
            }

            rows += '</tr>';
            //if (r.MODULO != campoAgrupadorModuloA) {
            //    rows += '<tr>';
            //    rows += '<td colspan="4" style="color: blue;font-weight: bold;">' + `${r.MODULO}` + '</td>';
            //    rows += '</tr>';
            //    campoAgrupadorModuloA = r.MODULO;
            //    rows += '<tr>';
            //    rows += '<td colspan="4" style="color: red; font-weight: bold;">' + `${r.GRUPO}` + '</td>';
            //    rows += '</tr>';
            //    campoAgrupadorGrupoA = r.GRUPO;
            //}
            //else if (r.GRUPO != campoAgrupadorGrupoA) {
            //    rows += '<tr>';
            //    rows += '<td colspan="4" style="color: red; font-weight: bold;">' + `${r.GRUPO}` + '</td>';
            //    rows += '</tr>';
            //    campoAgrupadorGrupoA = r.GRUPO;
            //}
            //rows += '<tr>';
            //if (opRow == 1)
            //    rows += '<td><i class="cellDel fa fa-lg fa-window-close" title="Asignar Menu" onclick="_MenuUsuario.fnQuitar(' + `${numero}` + ')"></i></td>';
            //rows += '<td>' + `${++numero}` + '</td>';
            //rows += '<td>' + `${r.MENU_PADRE}` + '</td>';
            //rows += '<td>' + `${r.MENU_HIJO}` + '</td>';
            //if (opRow == 0)
            //    rows += '<td><i class="cellCheck fa fa-lg fa-check" title="Quitar Menu" onclick="_MenuUsuario.fnAsignar(' + `${numero - 1}` + ')"></i></td>';
            //rows += '</tr>';

        });
        tabla.append(rows);
    },
    GetListMenusUsuario: (dataEnviar) => {
        var url = urlLocalSigo + "Seguridad/Usuario/GetListMenusUsuario";       
        dataEnviar.p1 = _MenuUsuario.fm.find("#cboModulo").val();
        dataEnviar.p2 = _MenuUsuario.fm.find("#cboGrupo").val();
        var option = { url: url, datos: JSON.stringify(dataEnviar), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                //no asignados
                _MenuUsuario.lstMenus = data.data.listMenus;
                _MenuUsuario.fnBuildTable(_MenuUsuario.lstMenus, "tbListMenus", 0);
                //asignados
                _MenuUsuario.lstMenusAsig = data.data.listMenusAsig;
                // console.log(_MenuUsuario.lstMenusAsig);
                _MenuUsuario.fnBuildTable(_MenuUsuario.lstMenusAsig, "tbListMenusAsignados", 1);
            }
            else {
                utilSigo.toastWarning("Aviso", initSigo.MessageError);
                console.log(data.msjError);
            }
        });
    },
    fnEvent: () => {
        $("#btnRegresarusuario").click(function () {
            ManUsuario.fnShowHide(0);
        });
        _MenuUsuario.fm.find("#cboModulo").change(function () {
            _MenuUsuario.GetListMenusUsuario({ codUsuario: _MenuUsuario.fm.find("#codUsuario").val() });
        });
        _MenuUsuario.fm.find("#cboGrupo").change(function () {
            _MenuUsuario.GetListMenusUsuario({ codUsuario: _MenuUsuario.fm.find("#codUsuario").val() });
        });
    },
    fnInit: () => {
        $.fn.select2.defaults.set("theme", "bootstrap4");
        _MenuUsuario.fm = $("#frmUsuarioMenu");
        _MenuUsuario.fm.find("#cboModulo").select2();
        _MenuUsuario.fm.find("#cboGrupo").select2();
        _MenuUsuario.fnEvent();       
        //iniciando tablas                
        _MenuUsuario.GetListMenusUsuario({ codUsuario: _MenuUsuario.fm.find("#codUsuario").val() });
    },
    rol: (o) => {

        let e = $("#frmUsuarioMenu").serializeObject();
        //debugger
        console.log(o);
        var option = {
            url: urlLocalSigo + "Seguridad/Usuario/_MenuRol",
            divId: "manRolModal",
            type: "POST",
            datos: { ob: o, cod: e.codPerfil }
        };
        utilSigo.fnOpenModal(option);
    }
};
$(function () {
    _MenuUsuario.fnInit();
});