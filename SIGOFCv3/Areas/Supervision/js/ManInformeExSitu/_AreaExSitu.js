"use strict";
var _AreaExSitu = {};

_AreaExSitu.fnSaveForm = function (data, data_eli) { /*implementado desde donde se instancia*/ }
_AreaExSitu.tbEliTABLA = [];

_AreaExSitu.fnLoadDatos = function (asCodArea,data) {
    if (data != null && data != "") {
        _AreaExSitu.frm.find("#hdfRegEstado").val(data["RegEstado"]);
        _AreaExSitu.frm.find("#hdfCodArea").val(data["COD_AREA"]);
        _AreaExSitu.frm.find("#hdfCodSecuencial").val(data["COD_SECUENCIAL"]);
        _AreaExSitu.frm.find("#txtNumero").val(data["NUMERO"]);
        _AreaExSitu.frm.find("#txtLargo").val(data["LARGO"]);
        _AreaExSitu.frm.find("#txtAncho").val(data["ANCHO"]);
        _AreaExSitu.frm.find("#txtAltura").val(data["ALTURA"]);
        _AreaExSitu.frm.find("#txtArea").val(data["AREA"]);
        _AreaExSitu.frm.find("#txtCoordenadaEste").val(data["COORDENADA_ESTE"]);
        _AreaExSitu.frm.find("#txtCoordenadaNorte").val(data["COORDENADA_NORTE"]);

        if (data["ListISupervision_exsitu_recinto_equipo"] != null) {
            _AreaExSitu.dtItemAreaExSitu_Material.rows.add(data["ListISupervision_exsitu_recinto_equipo"].filter(m => m.TIPO == "IM")).draw();
            _AreaExSitu.dtItemAreaExSitu_Cartel.rows.add(data["ListISupervision_exsitu_recinto_equipo"].filter(m => m.TIPO == "IC")).draw();
            _AreaExSitu.dtItemAreaExSitu_Equipo.rows.add(data["ListISupervision_exsitu_recinto_equipo"].filter(m => m.TIPO == "IE")).draw();
        }       
    } else {
        _AreaExSitu.frm.find("#hdfRegEstado").val("1");
        _AreaExSitu.frm.find("#hdfCodArea").val(asCodArea);
        _AreaExSitu.frm.find("#hdfCodSecuencial").val("0");
    }

    _AreaExSitu.frm.find("#ddlMaterialId").select2('val', ["0000000"]);
    _AreaExSitu.frm.find("#ddlCartelId").select2('val', ["0000000"]);
    _AreaExSitu.frm.find("#ddlEquipoId").select2('val', ["0000000"]);
}

_AreaExSitu.fnSetDatos = function () {
    var data = [];
    var regEstado = _AreaExSitu.frm.find("#hdfRegEstado").val();
    data["RegEstado"] = regEstado == "0" ? "2" : regEstado;
    data["COD_AREA"] = _AreaExSitu.frm.find("#hdfCodArea").val();
    data["COD_SECUENCIAL"] = _AreaExSitu.frm.find("#hdfCodSecuencial").val();
    data["NUMERO"] = _AreaExSitu.frm.find("#txtNumero").val();
    data["LARGO"] = _AreaExSitu.frm.find("#txtLargo").val();
    data["ANCHO"] = _AreaExSitu.frm.find("#txtAncho").val();
    data["ALTURA"] = _AreaExSitu.frm.find("#txtAltura").val();
    data["AREA"] = _AreaExSitu.frm.find("#txtArea").val();
    data["COORDENADA_ESTE"] = _AreaExSitu.frm.find("#txtCoordenadaEste").val();
    data["COORDENADA_NORTE"] = _AreaExSitu.frm.find("#txtCoordenadaNorte").val();

    var detalle = _AreaExSitu.fnGetList("IM");
    detalle=detalle.concat(_AreaExSitu.fnGetList("IC"));
    detalle=detalle.concat(_AreaExSitu.fnGetList("IE"));
    data["ListISupervision_exsitu_recinto_equipo"] = detalle;
    return data;
}

_AreaExSitu.fnAddDetalle = function (asTipo) {
    var dt,combo, data = {};
    switch (asTipo) {
        case "IM":
            dt = _AreaExSitu.dtItemAreaExSitu_Material;
            combo = _AreaExSitu.frm.find("#ddlMaterialId");
            break;
        case "IC":
            dt = _AreaExSitu.dtItemAreaExSitu_Cartel;
            combo = _AreaExSitu.frm.find("#ddlCartelId");
            break;
        case "IE":
            dt = _AreaExSitu.dtItemAreaExSitu_Equipo;
            combo = _AreaExSitu.frm.find("#ddlEquipoId");
            break;
    }

    if (!utilDt.existValorSearch(dt, "COD_TDESCRIPTIVA", combo.val())) {
        data.COD_TDESCRIPTIVA = combo.val();
        data.DESCRIPCION = combo.select2("data")[0].text;
        data.TIPO = asTipo; data.RegEstado = 1; data.COD_SECUENCIAL = 0;
        data.COD_AREA = _AreaExSitu.frm.find("#hdfCodArea").val();
        dt.rows.add([data]).draw();
    } else {
        utilSigo.toastWarning("Aviso", "El registro ya existe");
    }
}

_AreaExSitu.fnDeleteDetalle = function (asTipo, obj) {
    var dt, data = {};

    switch (asTipo) {
        case "IM": dt = _AreaExSitu.dtItemAreaExSitu_Material; break;
        case "IC": dt = _AreaExSitu.dtItemAreaExSitu_Cartel; break;
        case "IE": dt = _AreaExSitu.dtItemAreaExSitu_Equipo; break;
    }

    data = dt.row($(obj).parents('tr')).data();
    if (data["RegEstado"] == "0" || data["RegEstado"] == "2") {
        _AreaExSitu.tbEliTABLA.push({
            EliTABLA: "AREA_RECINTO_DET_EQUIPO",
            COD_PERSONA: data["COD_AREA"],
            COD_SECUENCIAL: data["COD_SECUENCIAL"],
            COD_ESPECIES: data["COD_TDESCRIPTIVA"]
        });
    }
    dt.row($(obj).parents('tr')).remove().draw(false);
}

_AreaExSitu.fnGetList = function (asTipo) {
    var dt, list = [], data;

    switch (asTipo) {
        case "IM": dt = _AreaExSitu.dtItemAreaExSitu_Material; break;
        case "IC": dt = _AreaExSitu.dtItemAreaExSitu_Cartel; break;
        case "IE": dt = _AreaExSitu.dtItemAreaExSitu_Equipo; break;
    }

    if (dt.$("tr").length > 0) {
        $.each(dt.$("tr"), function (i, o) {
            data = dt.row($(o)).data();
            list.push(utilSigo.fnConvertArrayToObject(data));
        });
    }
    return list;
}

_AreaExSitu.fnInitDataTable_Detail = function () {
    var columns_label = [], columns_data = [], options = {};

    columns_label = ["Descripción"];
    columns_data = ["DESCRIPCION"];
    options = {
        page_length: 5, row_delete: true, row_fnDelete: "_AreaExSitu.fnDeleteDetalle('IM',this)", row_index: true, page_sort: true
    };
    _AreaExSitu.dtItemAreaExSitu_Material = utilDt.fnLoadDataTable_Detail(_AreaExSitu.frm.find("#tbItemAreaExSitu_Material"), columns_label, columns_data, options);
    options = {
        page_length: 5, row_delete: true, row_fnDelete: "_AreaExSitu.fnDeleteDetalle('IC',this)", row_index: true, page_sort: true
    };
    _AreaExSitu.dtItemAreaExSitu_Cartel = utilDt.fnLoadDataTable_Detail(_AreaExSitu.frm.find("#tbItemAreaExSitu_Cartel"), columns_label, columns_data, options);
    options = {
        page_length: 5, row_delete: true, row_fnDelete: "_AreaExSitu.fnDeleteDetalle('IE',this)", row_index: true, page_sort: true
    };
    _AreaExSitu.dtItemAreaExSitu_Equipo = utilDt.fnLoadDataTable_Detail(_AreaExSitu.frm.find("#tbItemAreaExSitu_Equipo"), columns_label, columns_data, options);
}

_AreaExSitu.fnSubmitForm = function () {
    _AreaExSitu.frm.submit();
}

_AreaExSitu.fnInit = function (asCodArea,data) {
    _AreaExSitu.frm = $("#frmItemAreaExSitu");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _AreaExSitu.frm.find("#ddlMaterialId").select2();
    _AreaExSitu.frm.find("#ddlCartelId").select2({ minimumResultsForSearch: -1 });
    _AreaExSitu.frm.find("#ddlEquipoId").select2();

    _AreaExSitu.fnInitDataTable_Detail();
    _AreaExSitu.fnLoadDatos(asCodArea, data);

    _AreaExSitu.frm.find("#dvNumero").hide();
    switch (asCodArea) {
        case "0000001":
            $("#lblAreaExSitu_Titulo").text("Área de Exhibición");
            _AreaExSitu.frm.find("#dvNumero").show();
            break;
        case "0000002":
            $("#lblAreaExSitu_Titulo").text("Área de Crianza / Reproducción");
            _AreaExSitu.frm.find("#dvNumero").show();
            break;
        case "0000003":
            $("#lblAreaExSitu_Titulo").text("Área de Preparación de Alimentos");
            break;
        case "0000004":
            $("#lblAreaExSitu_Titulo").text("Área de Almacén de Alimentos");
            break;
        case "0000005":
            $("#lblAreaExSitu_Titulo").text("Área de Tópico");
            break;
        case "0000006":
            $("#lblAreaExSitu_Titulo").text("Área de Cuarentena");
            _AreaExSitu.frm.find("#dvNumero").show();
            break;
    }

    _AreaExSitu.frm.find("#ddlMaterialId").change(function () {
        if ($(this).val() != "0000000") {
            _AreaExSitu.fnAddDetalle("IM");
            _AreaExSitu.frm.find("#ddlMaterialId").select2('val', ["0000000"]);
        }
    });
    _AreaExSitu.frm.find("#ddlCartelId").change(function () {
        if ($(this).val() != "0000000") {
            _AreaExSitu.fnAddDetalle("IC");
            _AreaExSitu.frm.find("#ddlCartelId").select2('val', ["0000000"]);
        }
    });
    _AreaExSitu.frm.find("#ddlEquipoId").change(function () {
        if ($(this).val() != "0000000") {
            _AreaExSitu.fnAddDetalle("IE");
            _AreaExSitu.frm.find("#ddlEquipoId").select2('val', ["0000000"]);
        }
    });

    //=====-----Para el registro de datos del formulario-----=====
    _AreaExSitu.frm.validate(utilSigo.fnValidate({
        rules: {
            txtLargo: { required: true },
            txtAncho: { required: true },
            txtAltura: { required: true },
            txtArea: { required: true }
        },
        messages: {
            txtLargo: { required: "Ingrese el largo" },
            txtAncho: { required: "Ingrese el ancho" },
            txtAltura: { required: "Ingrese la altura" },
            txtArea: { required: "Ingrese el área" }
        },
        fnSubmit: function (form) {
            _AreaExSitu.fnSaveForm(_AreaExSitu.fnSetDatos(), _AreaExSitu.tbEliTABLA);
        }
    }));
    //Validación de controles que usan Select2
    _AreaExSitu.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}