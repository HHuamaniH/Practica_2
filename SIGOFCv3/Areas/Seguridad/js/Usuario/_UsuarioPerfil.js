"use strict";
var _UsuarioPerfil = {
    fnAsignar: (indice) => {
        var perfilAdd = [];
        if (indice < 0) {
            utilSigo.dialogConfirm('', 'Desea asignar todos los perfiles al usuario?', function (r) {
                if (r) {
                    perfilAdd = _UsuarioPerfil.listPerfil;
                    _UsuarioPerfil.fnSave(perfilAdd, "A");
                }
            });
        }
        else {
            perfilAdd.push(_UsuarioPerfil.listPerfil[indice]); 

            _UsuarioPerfil.fnSave(perfilAdd, "A");
        }
    },
    fnQuitar: (indice) => {
        var perfilEli = [];
        if (indice < 0) {
            utilSigo.dialogConfirm('', 'Desea quitar todos los perfiles al usuario?', function (r) {
                if (r) {
                    perfilEli = _UsuarioPerfil.listPerfilAsig;
                    _UsuarioPerfil.fnSave(perfilEli, "E");
                }
            });
        }
        else {
            perfilEli.push(_UsuarioPerfil.listPerfilAsig[indice]);
            _UsuarioPerfil.fnSave(perfilEli, "E");
        }
    },
    fnSave: (dataEnviar, op) => {
        var url = urlLocalSigo + "Seguridad/Usuario/SaveUsuarioPerfil";
        var codUsuario = _UsuarioPerfil.fm.find("#hdCodUsuario").val();
        var model = { codUsuario: codUsuario, listPerfilAsig: dataEnviar, op: op };
        var option = { url: url, datos: JSON.stringify(model), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                _UsuarioPerfil.fm.find("#txtValor").val('');
                _UsuarioPerfil.GetListUsuarioPerfil({ codUsuario: codUsuario });                
                utilSigo.toastSuccess("Éxito", data.msj);
            }
            else {
                utilSigo.toastWarning("Aviso", data.msj);
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
        $.each(data, (i, r) => {            
            rows += '<tr>';
            if (opRow == 1)
                rows += '<td><i class="cellDel fa fa-lg fa-window-close" title="Asignar Menu" onclick="_UsuarioPerfil.fnQuitar(' + `${numero}` + ')"></i></td>';
            rows += '<td>' + `${++numero}` + '</td>';
            rows += '<td><b>' + `${r.descr}` + '</b></br><span class="text-capitalize">' + `${r.descrClasificacion}` +'-'+ `${r.descrSubClasificacion}` +'</span></td>';
            
            if (opRow == 0)
                rows += '<td><i class="cellCheck fa fa-lg fa-check" title="Quitar Menu" onclick="_UsuarioPerfil.fnAsignar(' + `${numero - 1}` + ')"></i></td>';
            rows += '</tr>';

        });
        tabla.append(rows);
    },
    GetListUsuarioPerfil: (dataEnviar) => {
        var url = urlLocalSigo + "Seguridad/Usuario/GetListUsuarioPerfil";
        let sc = $('#cboSubClasificacion').val();
        dataEnviar.p1 = _UsuarioPerfil.fm.find("#txtValor").val().trim();
        
        dataEnviar.p2 = sc != 0? sc:null;
        var option = { url: url, datos: JSON.stringify(dataEnviar), type: 'POST' };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                //no asignados
                _UsuarioPerfil.listPerfil = data.data.listPerfil;
                _UsuarioPerfil.fnBuildTable(_UsuarioPerfil.listPerfil, "tbListPerfil", 0);
                //asignados
                _UsuarioPerfil.listPerfilAsig = data.data.listPerfilAsig;
                // console.log(_UsuarioPerfil.lstMenusAsig);
                _UsuarioPerfil.fnBuildTable(_UsuarioPerfil.listPerfilAsig, "tbListPerfilAsig", 1);
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
        _UsuarioPerfil.fm.find("#btnBuscarPerfil").click(function () {
            _UsuarioPerfil.GetListUsuarioPerfil({ codUsuario: _UsuarioPerfil.fm.find("#hdCodUsuario").val()});
        });  
        _UsuarioPerfil.fm.submit(function (e) {
            _UsuarioPerfil.GetListUsuarioPerfil({ codUsuario: _UsuarioPerfil.fm.find("#hdCodUsuario").val()});
            e.preventDefault();
        });
        $("#cboClasificacion").on('change', function () {
            //console.log($(this).val());
            if ($(this).val() !=0)
                _UsuarioPerfil.resultSelect('cboSubClasificacion', $(this).val());
            else 
                $('#cboSubClasificacion').children('option:not(:first)').remove();
        });
    },
    fnInit: () => {
        _UsuarioPerfil.resultSelect('cboClasificacion');
        $.fn.select2.defaults.set("theme", "bootstrap4");
        _UsuarioPerfil.fm = $("#frmUsuarioPerfil");        
        _UsuarioPerfil.fnEvent();
        //iniciando tablas                
        _UsuarioPerfil.GetListUsuarioPerfil({ codUsuario: _UsuarioPerfil.fm.find("#hdCodUsuario").val() });
    },
   resultSelect : function (e, o) {
        $.ajax({
            method: "GET",
            url: urlLocalSigo + "Seguridad/Perfil/GetListClasificacionPerfil?id=" + o || null,
            dataType: "json",
            success: function (d) {
                console.log('result', d)
                //debugger
                $('#' + e).children('option:not(:first)').remove();
                let s = document.getElementById(e);

                let r = d.data;
                for (var i = 0; i < r.length; i++) {
                    var option = document.createElement("option");
                    option.text = r[i].VDESCRIPCION;
                    option.value = r[i].PK_PERFILESMAECLASIFICACION;
                    s.add(option);
                }

            }
        });
    }
};
$(function () {
    _UsuarioPerfil.fnInit();
});