"use strict";
var _MenuPerfil = {    
    fnAsignar: (indice) => {          
        var menuAdd = [];
        if (indice < 0) {
            utilSigo.dialogConfirm('', 'Desea asignar todos los menus al perfil?', function (r) {
                if (r) {
                    menuAdd = _MenuPerfil.lstMenus;
                    _MenuPerfil.fnSave(menuAdd, "A");    
                }
            });           
        }
        else {
            menuAdd.push(_MenuPerfil.lstMenus[indice]);
            _MenuPerfil.fnSave(menuAdd, "A");      
        } 
    },
    fnQuitar: (indice) => {       
        var menuEli = [];
        if (indice < 0) {
            utilSigo.dialogConfirm('', 'Desea quitar todos los menus al perfil?', function (r) {
                if (r) {
                    menuEli = _MenuPerfil.lstMenusAsig;
                    _MenuPerfil.fnSave(menuEli, "E");
                }
            });           
        }
        else {
            menuEli.push(_MenuPerfil.lstMenusAsig[indice]);
            _MenuPerfil.fnSave(menuEli, "E");
        } 
    },
    fnSave: (dataEnviar,op) => {
        var url = urlLocalSigo + "Seguridad/Perfil/SavePerfilMenu";
        var codPerfil = _MenuPerfil.fm.find("#codPerfil").val();  
        var model = { codPerfil: codPerfil, listMenusAsig: dataEnviar,op:op };     
        var option = { url: url, datos: JSON.stringify(model), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                _MenuPerfil.fnGetAllMenuAsignado({ codPerfil: codPerfil});
                utilSigo.toastSuccess("Éxito", data.msj);
            }
            else {
                utilSigo.toastWarning("Aviso", data.msj);
                console.log(data.msjError);
            }
        });
    },
    fnBuildTable: (data,tbName,opRow) => {
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
                rows += '<td><i class="cellDel fa fa-lg fa-window-close" title="Asignar Menu" onclick="_MenuPerfil.fnQuitar(' + `${numero}` +')"></i></td>';
            rows += '<td>' + `${++numero}` + '</td>';
            rows += '<td>' + `${r.MENU_PADRE}` + '</td>';
            rows += '<td>' + `${r.MENU_HIJO}` + '</td>';
           
            if (opRow == 0)
                rows += '<td><i class="cellCheck fa fa-lg fa-check" title="Quitar Menu" onclick="_MenuPerfil.fnAsignar(' + `${numero - 1}` + ')"></i></td>';
            else {
                rows += '<td>' + `${r.VALIAS||' '}` + '</td>';
                rows += "<td><i class='cellCheck fa fa-lg fa-edit' title='Rol' onclick='_MenuPerfil.rol(" + JSON.stringify(r).toString() + ")'></i></td>";
            }
                
            rows += '</tr>';

        });
        tabla.append(rows);
    },   
    fnGetAllMenuAsignado: (dataEnviar) => {
        var url = urlLocalSigo + "Seguridad/Perfil/GetListMenusAsignados";  
        var codPerfil = _MenuPerfil.fm.find("#codPerfil").val();
        dataEnviar.p1 = _MenuPerfil.fm.find("#cboModulo").val();
        dataEnviar.p2 = _MenuPerfil.fm.find("#cboGrupo").val();
        var option = { url: url, datos: JSON.stringify(dataEnviar), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                //no asignados
                _MenuPerfil.lstMenus = data.data.listMenus;
                _MenuPerfil.fnBuildTable(_MenuPerfil.lstMenus, "tbListMenus", 0);   
                //asignados
                _MenuPerfil.lstMenusAsig = data.data.listMenusAsig;  
               // console.log(_MenuPerfil.lstMenusAsig);
                _MenuPerfil.fnBuildTable(_MenuPerfil.lstMenusAsig, "tbListMenusAsignados", 1);               
            }
            else {
                utilSigo.toastWarning("Aviso", data.msj);
                console.log(data.msjError);
            }
        });
    },    
    fnEvent: () => {
        $("#btnRegresarPerfil").click(function () {
            ManPerfil.fnShowHide(0);
        });        
        _MenuPerfil.fm.find("#cboModulo").change(function () {
            _MenuPerfil.fnGetAllMenuAsignado({ codPerfil: _MenuPerfil.fm.find("#codPerfil").val() });
        });
        _MenuPerfil.fm.find("#cboGrupo").change(function () {
            _MenuPerfil.fnGetAllMenuAsignado({ codPerfil: _MenuPerfil.fm.find("#codPerfil").val() });
        });      
        
    },
    fnInit: () => {
                 $.fn.select2.defaults.set("theme", "bootstrap4");
                _MenuPerfil.fm = $("#frmoPerfilMenu");
                _MenuPerfil.fm.find("#cboModulo").select2();
                _MenuPerfil.fm.find("#cboGrupo").select2();
                _MenuPerfil.fnEvent();
                //iniciando tablas                
                _MenuPerfil.fnGetAllMenuAsignado({ codPerfil: _MenuPerfil.fm.find("#codPerfil").val() });
    },
    rol: (o) => {
        
        let e = $("#frmoPerfilMenu").serializeObject();
        //debugger
        console.log(o);
        var option = {
            url: urlLocalSigo + "Seguridad/Perfil/_MenuRol",
            divId: "manRolModal",
            type: "POST",
            datos: { ob: o, cod: e.codPerfil }
        };
        utilSigo.fnOpenModal(option);
    }
};
$(function () {
    _MenuPerfil.fnInit();
});