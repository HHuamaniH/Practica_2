var _InventarioFauna = {};
_InventarioFauna.itemSelect = [];

_InventarioFauna.fnExistData = function (valEspecie) {
    var indice = -1;
    for (var i = 0; i < _InventarioFauna.itemSelect.length; i++) {
        if (_InventarioFauna.itemSelect[i].COD_ESPECIES.trim() == valEspecie.trim()) {
            return i;
        }
    }
    return indice;
}
_InventarioFauna.fnAdd = function (obj) {
    var tr = $(obj).closest("tr");
    var check = tr.find(".chkItem");
    //verificando si existe item
    var dataRow = _InventarioFauna.dt.row(tr).data();
    var item = { COD_ESPECIES: dataRow.Value, ESPECIES: dataRow.Text, COD_SECUENCIAL: 0, RegEstado: "1" };
    var indexVeri = _InventarioFauna.fnExistData(item.COD_ESPECIES);
    if (check.is(":checked")) {
        //adicionar
        if (indexVeri == -1)
            _InventarioFauna.itemSelect.push(item);
        //check.attr("checked", "checked");
    } else {
        //si existe quitar
        if (indexVeri != -1)
            _InventarioFauna.itemSelect.splice(indexVeri, 1);
        //check.removeAttr("checked");
    }
}
_InventarioFauna.fnSelectAll = function (obj) {
    var tr = $(obj).closest("tr");
    var check = tr.find("#chkAll");
    var table = _InventarioFauna.dt;//$('#grvItemIFauna').DataTable();
    var trsCurrent = table.rows({ page: 'current' }).nodes();
    if (check.is(":checked")) {
        $.each(trsCurrent, function (i, o) {
            $(o).find(".chkItem").prop("checked", true);
            //add
            var dataRow = _InventarioFauna.dt.row(o).data();
            var item = { COD_ESPECIES: dataRow.Value, ESPECIES: dataRow.Text, COD_SECUENCIAL: 0, RegEstado: "1" };
            var indexVeri = _InventarioFauna.fnExistData(item.COD_ESPECIES);
            if (indexVeri == -1)
                _InventarioFauna.itemSelect.push(item);
        });
    } else {
        $.each(trsCurrent, function (i, o) {
            $(o).find(".chkItem").prop("checked", false);
            //delete
            var dataRow = _InventarioFauna.dt.row(o).data();
            var item = { COD_ESPECIES: dataRow.Value, ESPECIES: dataRow.Text, COD_SECUENCIAL: 0, RegEstado: "1" };
            var indexVeri = _InventarioFauna.fnExistData(item.COD_ESPECIES);
            if (indexVeri != -1)
                _InventarioFauna.itemSelect.splice(indexVeri, 1);
        });

    }
}
_InventarioFauna.fnAsigna = function () {
    //var ss = table.rows({ page: 'current' }).data(); //(get data)              
    if (_InventarioFauna.itemSelect.length > 0) {
        var contadorItemAdd = 0;
        for (var i = 0; i < _InventarioFauna.itemSelect.length; i++) {
            if (AddEditPM.fnGetRowId(AddEditPM.dtItemISituInvFauna, "COD_ESPECIES", _InventarioFauna.itemSelect[i].COD_ESPECIES) == -1) {
                AddEditPM.dtItemISituInvFauna.row.add(_InventarioFauna.itemSelect[i]).draw();
                contadorItemAdd++;
            }
        }
        utilSigo.toastSuccess("Aviso", `(${contadorItemAdd}) Registro Insertado`);
        _InventarioFauna.itemSelect = [];
        _InventarioFauna.fnShowData(false);

    } else {
        utilSigo.toastWarning("Aviso", "Seleccione items a agregar");
    }
}
_InventarioFauna.fnConfigTable = function () {
    var cabecera = "<tr>";
    var columns = ['<input type="checkbox" onclick="_InventarioFauna.fnSelectAll(this)" id="chkAll" />', "N°", "Especie"];
    for (var i = 0; i < columns.length; i++) {
        cabecera += '<th>' + columns[i] + '</th>';
    }
    cabecera += "</tr>";
    _InventarioFauna.tb.find("thead").append(cabecera);
    _InventarioFauna.dt = _InventarioFauna.tb.DataTable({
        "bServerSide": false,
        "bAutoWidth": false,
        "bProcessing": true,
        "bJQueryUI": false,
        "bRetrieve": true,
        "bFilter": true,
        "aaSorting": [],
        "bPaginate": true,
        "bInfo": true,
        "bLengthChange": false,
        "pageLength": 20,
        "pageLength": initSigo.pageLength,
        "oLanguage": initSigo.oLanguage,
        "drawCallback": initSigo.showPagination,
        "columns":
            [
                {
                    "autoWidth": true, "bSortable": false, "sClass": "tdIcoconCenter", "data": "Value", "mRender": function (data, type, row) {

                        var cell = '<input type="checkbox" class="chkItem" onclick="_InventarioFauna.fnAdd(this);" />';
                        return cell;
                    }
                },
                {
                    "autoWidth": true, "bSortable": false, "sClass": "tdIcoconCenter", "name": "IND",
                    "mRender": utilDt.countRowDT
                },

                { "data": "Text", "autoWidth": true }

            ]
    });
}
_InventarioFauna.fnShowData = function (reloadBD) {
    _InventarioFauna.dt.clear().draw();
    if (reloadBD) sessionStorage.removeItem("ListEspecieFauna");
    if (JSON.parse(sessionStorage.getItem('ListEspecieFauna')) != null) {
        _InventarioFauna.dt.rows.add(JSON.parse(sessionStorage.getItem('ListEspecieFauna'))).draw();
    } else {
        var url = urlLocalSigo + "THabilitante/ManPlanManejo/ListEspecieFE";
        var option = { url: url };
        utilSigo.fnAjax(option, function (data) {
            if (data.success) {
                _InventarioFauna.dt.rows.add(data.data).draw();
                //almacenando en sessionStorage
                if (window.sessionStorage) {
                    sessionStorage.setItem('ListEspecieFauna', JSON.stringify(data.data));
                }
            } // Obtiene la información almacenada desde sessionStorage           
            else {
                utilSigo.toastWarning("Aviso", initSigo.MessageError);
                console.log(data.msjError);
            }
        });
    }
}
_InventarioFauna.fnInitEventos = function () {
    $('#grvItemIFauna').on('page.dt', function () {
        var check = _InventarioFauna.contenedor.find("#chkAll");
        check.prop("checked", false);
    });
    _InventarioFauna.contenedor.find("#btnGuardar").click(function () {
        _InventarioFauna.fnAsigna();
    });
    _InventarioFauna.contenedor.find("#btnReload").click(function () {
        _InventarioFauna.fnShowData(true);
    });
}
_InventarioFauna.fnInit = function () {
    _InventarioFauna.contenedor = $("#contenedorIfauna");
    _InventarioFauna.tb = _InventarioFauna.contenedor.find("#grvItemIFauna");
    _InventarioFauna.fnConfigTable();
    _InventarioFauna.fnShowData(false);
    _InventarioFauna.fnInitEventos();

}