"use strict";
var _bPerGen = {};
_bPerGen.url = urlLocalSigo + "General/Controles/buscarPersonaGeneral?";
_bPerGen.fnAsignarDatos = function (obj) { /*se implementa en cada llamada*/ }

_bPerGen.fnBuscarPersona = function () {
    var valGrupo, valCriterio, valBuscar, valCodPTipo, valTipoPersona;

    valGrupo = _bPerGen.frm.find("#hdfBusGrupo").val();
    valCriterio = _bPerGen.frm.find("#cboCriterio").val();
    valBuscar = _bPerGen.frm.find("#txtValor").val().trim();

    valTipoPersona = _bPerGen.frm.find("#hdfTipoPersona").val();
    valCodPTipo = _bPerGen.frm.find("#hdfCodPTipo").val();
    var url = _bPerGen.url + "asBusGrupo=" + valGrupo + "&asBusCriterio=" + valCriterio
        + "&asBusValor=" + valBuscar + "&asCodPTipo=" + valCodPTipo + "&asTipoPersona=" + valTipoPersona;

    if (valBuscar == "") {
        utilSigo.toastWarning("Aviso", "Ingrese el dato de la persona a buscar");
        return false;
    }
    if (valBuscar.length < 3) {
        utilSigo.toastWarning("Aviso", "El dato de la persona a buscar debe ser mayor a dos caracteres");
        return false;
    }

    _bPerGen.dtBuscarPerona.ajax.url(url).load(function (data) {
        if (data.success == false) {
            utilSigo.toastError("Error", "Sucedió un error al realizar la consulta, por favor comuníquese con el administrador");
            //console.log(data.er);
        }
    });
}

_bPerGen.fnInitEventos = function () {
    _bPerGen.frm.find("#btnBuscarPersona").click(function () {
        _bPerGen.fnBuscarPersona();
    });
    _bPerGen.frm.submit(function (e) {
        _bPerGen.fnBuscarPersona();
        e.preventDefault();
    });
    _bPerGen.frm.find("#btnNuevaPersona").click(function () {
        _bPerGen.fnAddEditPersona(null);
    });
    _bPerGen.frm.find("#cboCriterio").change(function () {
        _bPerGen.frm.find("#txtValor").focus();
    });
}

_bPerGen.fnInitDataTable_Detail = function () {
    /*var columns_label = ["Apellidos y Nombres (razón social)", "Tipo Documento", "Documento", "Ficha Registral", "Tipo Persona", "Tipo SIGOsfc"];
    var columns_data = ["PERSONA", "DIDENTIDAD", "N_DOCUMENTO", "FICHA_REGISTRAL", "TIPO_PERSONA_TEXT", "PTIPO"];
    var options = {
        page_length: initSigo.pageLengthBuscar, row_select: true, row_edit: true, row_fnEdit: "_bPerGen.fnEditar(this)", row_fnSelect: "_bPerGen.fnAsignarDatos(this)", row_index: true
    };
    _bPerGen.dtBuscarPerona = utilDt.fnLoadDataTable_Detail(_bPerGen.frm.find("#tbBuscarPerona"), columns_label, columns_data, options);*/

    var columns_label = ["N°", "Apellidos y Nombres (razón social)", "Tipo Documento", "Documento", "Ficha Registral", "Tipo Persona", "Cargo Persona", "", ""];
    var columns_data = [
        {
            "name": "ROW_INDE", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row, meta) {
                return parseInt(meta.row) + 1 + meta.settings._iDisplayStart;
            }
        },
        { "data": "PERSONA", "autoWidth": true },
        { "data": "DIDENTIDAD", "autoWidth": true },
        { "data": "N_DOCUMENTO", "autoWidth": true },
        { "data": "FICHA_REGISTRAL", "autoWidth": true },
        { "data": "TIPO_PERSONA_TEXT", "autoWidth": true },
        { "data": "TIPO_CARGO", "autoWidth": true },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                return '<div><i class="fa fa-lg fa-plus-square-o" style="color:blue;cursor:pointer;" title="Agregar Cargo" onclick="_bPerGen.fnAddEditPersona(this)"></i>';
            }
        },
        {
            "data": "", "width": "2%", "orderable": false, "searchable": false, "mRender": function (data, type, row) {
                return '<div><i class="fa fa-lg fa-check" style="cursor: pointer;color:forestgreen;" title="Seleccionar" onclick="_bPerGen.fnAsignarDatos(this)"></i>';
            }
        }
    ];

    //**Cabecera**----
    var theadTable = "<tr>";
    for (var i = 0; i < columns_label.length; i++) {
        theadTable += '<th>' + columns_label[i] + '</th>';
    }
    theadTable += "</tr>";
    $("#tbBuscarPerona").find("thead").append(theadTable);

    var optDt = { iLength: initSigo.pageLengthBuscar, aSort: [] };

    _bPerGen.dtBuscarPerona = _bPerGen.frm.find("#tbBuscarPerona").DataTable({
        processing: true,
        ServerSide: false,
        bFilter: false,
        bLengthChange: false,
        ordering: false,
        paging: true,
        bInfo: false,
        aaSorting: optDt.aSort,
        pageLength: optDt.iLength,
        oLanguage: initSigo.oLanguage,
        drawCallback: initSigo.showPagination,
        columns: columns_data
    });
}

/*_bPerGen.fnEditar = function (obj) {
    var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
    ////console.log(data);

    let params = {
        type: 'post',
        url: initSigo.urlControllerGeneral + 'GetPersona',
        datos: JSON.stringify({ asCodPersona: data.COD_PERSONA })
    };

    utilSigo.fnAjax(params, function (res) {
        var option = {
            url: initSigo.urlControllerGeneral + "/_Persona", divId: "modalAddEditPersona", datos: {}
        };
        utilSigo.fnOpenModal(option, function () {			
            let data = res.data;			
            _bPerAddEdit.fnInit(data.COD_TPERSONA, (data.ListTipoCargo[0] || {}).COD_PTIPO);
            _bPerAddEdit.cargarDatosEdit(data);
        });
    });
};*/

_bPerGen.fnAddEditPersona = function (obj) {
    var row = null, codPersona = "";
    var valTipoPersona = _bPerGen.frm.find("#hdfTipoPersona").val();

    if (obj != null) {
        row = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
        codPersona = row.COD_PERSONA;

        if (row.TIPO_PERSONA_TEXT == "Natural") {
            valTipoPersona = "N";
        }
        else if (row.TIPO_PERSONA_TEXT == "Jurídica") {
            valTipoPersona = "J";
        }
    }

    var option = {
        url: initSigo.urlControllerGeneral + "/_Persona",
        divId: "modalAddEditPersona",
        datos: {
            asFormulario: _bPerGen.frm.find("#hdfFormulario").val(),
            asCodMod: _bPerGen.frm.find("#hdfCodMod").val(),
            asCodPersona: codPersona,
            opc: 1
        }
    };
    utilSigo.fnOpenModal(option, function () {
        _bPerAddEdit.fnAsignarDatos = function (regEstado) {
            if (regEstado == 1) {
                var valor;
                if (_bPerAddEdit.tipoPersona == "N")
                    valor = _bPerAddEdit.frm.find("#txtItemPN_APaterno").val().trim() + " " + _bPerAddEdit.frm.find("#txtItemPN_AMaterno").val().trim() + " " + _bPerAddEdit.frm.find("#txtItemPN_Nombres").val().trim();
                if (_bPerAddEdit.tipoPersona == "J")
                    valor = _bPerAddEdit.frm.find("#txtItemPJ_RSocial").val().trim();

                _bPerGen.frm.find("#txtValor").val(valor);
            }

            _bPerGen.fnBuscarPersona();
        };
        _bPerAddEdit.fnInit(valTipoPersona, _bPerGen.frm.find("#hdfCodPTipo").val());
    });
}

_bPerGen.fnInit = function () {
    $('[data-toggle="tooltip"]').tooltip();
    _bPerGen.frm = $("#frmBuscarPersona");

    _bPerGen.frm.find("#cboCriterio").select2({ minimumResultsForSearch: -1 });
    $('.modal').on('shown.bs.modal', function () {
        _bPerGen.frm.find("#txtValor").focus();
    });

    _bPerGen.fnInitDataTable_Detail();
    _bPerGen.fnInitEventos();
    /*let valCodPTipo;
    switch (_bPerGen.frm.find("#hdfCodPTipo").val()) {
        case "TITULAR":
            valCodPTipo = "0000001"; break;
        case "RLEGAL":
            valCodPTipo = "0000002"; break;
        case "REGENTE":
            valCodPTipo = "0000020"; break;
        default:
            valCodPTipo = _bPerGen.frm.find("#hdfCodPTipo").val(); break;
    }
    _bPerGen.frm.find("#hdfCodPTipo").val(valCodPTipo);*/
    var titBuscarPersona = "";
    switch (_bPerGen.frm.find("#hdfTipoPersona").val()) {
        case "N": titBuscarPersona = "Buscar Persona Natural"; break;
        case "J": titBuscarPersona = "Buscar Persona Jurídica"; break;
        default: titBuscarPersona = "Buscar Persona (natural o jurídica)";
    }
    $("#lblTituloBuscarPersona").text(titBuscarPersona);
}