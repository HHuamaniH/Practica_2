var ManInforme_Enfermedad = {};
/*Variables globales*/
ManInforme_Enfermedad.DataEnfermedad = [];

ManInforme_Enfermedad.fnLoadData = function (obj, tipo) {
    switch (tipo) {
        case "DataEnfermedad": ManInforme_Enfermedad.DataEnfermedad = JSON.parse(obj) || []; break;
    }
}

ManInforme_Enfermedad.fnLoadEnfermedad = function () {
    var dataCencria = ManInforme_Enfermedad.DataEnfermedad.filter(m => m.GRUPO == "CENCRIA");
    ManInforme_Enfermedad.fnLoadCabEnfermedad(dataCencria, 'tbodyCencria');

    var dataCencriaVacCab = ManInforme_Enfermedad.DataEnfermedad.filter(m => m.GRUPO == "CENCRIAVACCAB");
    ManInforme_Enfermedad.fnLoadCabEnfermedad(dataCencriaVacCab, 'tbodyCencriaVacCab');
    var dataCencriaVac = ManInforme_Enfermedad.DataEnfermedad.filter(m => m.GRUPO == "CENCRIAVAC");
    ManInforme_Enfermedad.fnLoadDetEnfermedad(dataCencriaVac, 'tbodyCencriaVac');

    var dataPerCencriaCab = ManInforme_Enfermedad.DataEnfermedad.filter(m => m.GRUPO == "PERCENCRIACAB");
    ManInforme_Enfermedad.fnLoadCabEnfermedad(dataPerCencriaCab, 'tbodyPerCencriaCab');
    var dataPerCencria = ManInforme_Enfermedad.DataEnfermedad.filter(m => m.GRUPO == "PERCENCRIA");
    ManInforme_Enfermedad.fnLoadDetEnfermedad(dataPerCencria, 'tbodyPerCencria');

    var dataSenasa = ManInforme_Enfermedad.DataEnfermedad.filter(m => m.GRUPO == "SENASA");
    ManInforme_Enfermedad.fnLoadCabEnfermedad(dataSenasa, 'tbodySenasa');
    var dataSenasaCom = ManInforme_Enfermedad.DataEnfermedad.filter(m => m.GRUPO == "SENASACOM");
    ManInforme_Enfermedad.fnLoadDetEnfermedad(dataSenasaCom, 'tbodySenasaCom');
    var dataSenasaBov = ManInforme_Enfermedad.DataEnfermedad.filter(m => m.GRUPO == "SENASABOV");
    ManInforme_Enfermedad.fnLoadDetEnfermedad(dataSenasaBov, 'tbodySenasaBov');
    var dataSenasaSui = ManInforme_Enfermedad.DataEnfermedad.filter(m => m.GRUPO == "SENASASUI");
    ManInforme_Enfermedad.fnLoadDetEnfermedad(dataSenasaSui, 'tbodySenasaSui');
    var dataSenasaAve = ManInforme_Enfermedad.DataEnfermedad.filter(m => m.GRUPO == "SENASAAVE");
    ManInforme_Enfermedad.fnLoadDetEnfermedad(dataSenasaAve, 'tbodySenasaAve');
    var dataSenasaEqu = ManInforme_Enfermedad.DataEnfermedad.filter(m => m.GRUPO == "SENASAEQU");
    ManInforme_Enfermedad.fnLoadDetEnfermedad(dataSenasaEqu, 'tbodySenasaEqu');
    var dataSenasaCap = ManInforme_Enfermedad.DataEnfermedad.filter(m => m.GRUPO == "SENASACAP");
    ManInforme_Enfermedad.fnLoadDetEnfermedad(dataSenasaCap, 'tbodySenasaCap');

    var dataAccataCab = ManInforme_Enfermedad.DataEnfermedad.filter(m => m.GRUPO == "ACCATACAB");
    ManInforme_Enfermedad.fnLoadCabEnfermedad(dataAccataCab, 'tbodyAccataCab');
    var dataAccata = ManInforme_Enfermedad.DataEnfermedad.filter(m => m.GRUPO == "ACCATA");
    ManInforme_Enfermedad.fnLoadDetEnfermedad(dataAccata, 'tbodyAccata');
}

ManInforme_Enfermedad.fnLoadCabEnfermedad = function (obj, tbody) {
    var htmlBody = '<tr>';
    var check = obj[0].DESCRIPCION.split('|');
    if (check.length == 2) {
        htmlBody = htmlBody + '<td style="width:10% !important;border-top: 0px !important;">';
        htmlBody = htmlBody + '     <div class="custom-control custom-radio">';
        htmlBody = htmlBody + '         <input type="radio" class="custom-control-input" id="rbtn_' + obj[0].GRUPO + '_' + obj[0].COD_ENFERMEDAD + '_SI" name="chk_' + obj[0].GRUPO + '" ' + ManInforme_Enfermedad.fnActiveCheck(obj[0].OBSERVACION) + '>';
        htmlBody = htmlBody + '         <label class="custom-control-label" for="rbtn_' + obj[0].GRUPO + '_' + obj[0].COD_ENFERMEDAD + '_SI">' + check[0] + '</label>';
        htmlBody = htmlBody + '     </div>';
        htmlBody = htmlBody + '</td>';
        htmlBody = htmlBody + '<td style="width:10% !important;border-top: 0px !important;">';
        htmlBody = htmlBody + '     <div class="custom-control custom-radio">';
        htmlBody = htmlBody + '         <input type="radio" class="custom-control-input" id="rbtn_' + obj[0].GRUPO + '_' + obj[0].COD_ENFERMEDAD + '_NO" name="chk_' + obj[0].GRUPO + '"' + ManInforme_Enfermedad.fnNoActiveCheck(obj[0].OBSERVACION) + '>';
        htmlBody = htmlBody + '         <label class="custom-control-label" for="rbtn_' + obj[0].GRUPO + '_' + obj[0].COD_ENFERMEDAD + '_NO">' + check[1] + '</label>';
        htmlBody = htmlBody + '     </div>';
        htmlBody = htmlBody + '</td>';

        htmlBody = htmlBody + '<td style="width:80% !important;border-top: 0px !important;">';
        htmlBody = htmlBody + '     <div class="form-group">';
        htmlBody = htmlBody + '         <label for="text_' + obj[1].GRUPO + '_' + obj[1].COD_ENFERMEDAD + '" class="text-small">' + obj[1].DESCRIPCION + '</label>';
        htmlBody = htmlBody + '         <input id="text_' + obj[1].GRUPO + '_' + obj[1].COD_ENFERMEDAD + '" class="form-control form-control-sm" name="text_' + obj[1].GRUPO + '_' + obj[1].COD_ENFERMEDAD + '" value="' + obj[1].OBSERVACION + '"/>';
        htmlBody = htmlBody + '     </div>';
        htmlBody = htmlBody + '</td>';

    } else utilSigo.toastWarning("Aviso", "No se registró Radio Button.");
    htmlBody = htmlBody + '</tr>';
    $('#' + tbody).html(htmlBody);
}

ManInforme_Enfermedad.fnActiveCheck = function (observation) {
    return observation == "SI" ? "checked" : "";
}
ManInforme_Enfermedad.fnNoActiveCheck = function (observation) {
    return observation == "NO" ? "checked" : "";
}
ManInforme_Enfermedad.fnActiveSelect = function (observation) {
    return observation == "Si" ? "selected" : "";
}
ManInforme_Enfermedad.fnNoActiveSelect = function (observation) {
    return observation == "No" ? "selected" : "";
}

ManInforme_Enfermedad.fnLoadDetEnfermedad = function (obj, tbody) {
    var columnas = 5;
    var htmlBody = '<tr>';
    var listChek = obj.filter(m => m.TIPO == "CHECK");
    for (var i = 0; i < listChek.length; i++) {
        htmlBody = htmlBody + '<td style="width:16% !important;border-top: 0px !important;">';
        htmlBody = htmlBody + '     <div class="custom-control custom-checkbox my-1 mr-sm-2">';
        htmlBody = htmlBody + '         <input type="checkbox" class="custom-control-input" id="check_' + listChek[i].GRUPO + '_' + listChek[i].COD_ENFERMEDAD + '" ' + ManInforme_Enfermedad.fnActiveCheck(listChek[i].OBSERVACION) + '/>';
        htmlBody = htmlBody + '         <label for="check_' + listChek[i].GRUPO + '_' + listChek[i].COD_ENFERMEDAD + '" class="custom-control-label" style="margin-top:6px;">' + listChek[i].DESCRIPCION + '</label>';
        htmlBody = htmlBody + '     </div>';
        htmlBody = htmlBody + '</td>';
        if ((i % columnas == 0 || i == listChek.length - 1) && i != 0) {
            htmlBody = htmlBody + '</tr>';
            if (i < listChek.length - 1)
                htmlBody = htmlBody + '<tr>';
            columnas += 6;
        }
    }
    htmlBody = htmlBody + '</tr>';

    htmlBody = htmlBody + '<tr>';
    var list = obj.filter(m => m.TIPO != "CHECK");
    columnas = 2;

    for (var i = 0; i < list.length; i++) {
        if (list[i].TIPO == "TEXT") {
            htmlBody = htmlBody + '<td style="width:32% !important;border-top: 0px !important;" colspan="2">';
            htmlBody = htmlBody + '     <div class="form-group">';
            htmlBody = htmlBody + '         <label for="text_' + list[i].GRUPO + '_' + list[i].COD_ENFERMEDAD + '" class="text-small">' + list[i].DESCRIPCION + '</label>';
            htmlBody = htmlBody + '         <input id="text_' + list[i].GRUPO + '_' + list[i].COD_ENFERMEDAD + '" class="form-control form-control-sm" name="text_' + list[i].GRUPO + '_' + list[i].COD_ENFERMEDAD + '" value="' + list[i].OBSERVACION + '"/>';
            htmlBody = htmlBody + '     </div>';
            htmlBody = htmlBody + '</td>';
        } else if (list[i].TIPO == "SELECT") {
            htmlBody = htmlBody + '<td style="width:32% !important;border-top: 0px !important;" colspan="2">';
            htmlBody = htmlBody + '     <div class="form-group">';
            htmlBody = htmlBody + '         <label for="select_' + list[i].GRUPO + '_' + list[i].COD_ENFERMEDAD + '" class="text-small">' + list[i].DESCRIPCION + '</label>';
            htmlBody = htmlBody + '         <select class="form-control form-control-sm" id="select_' + list[i].GRUPO + '_' + list[i].COD_ENFERMEDAD + '" name="select_' + list[i].GRUPO + '_' + list[i].COD_ENFERMEDAD + '">';
            htmlBody = htmlBody + '             <option value="Si" ' + ManInforme_Enfermedad.fnActiveSelect(list[i].OBSERVACION) + '>Si</option>';
            htmlBody = htmlBody + '             <option value="No" ' + ManInforme_Enfermedad.fnNoActiveSelect(list[i].OBSERVACION) + '>No</option>';
            htmlBody = htmlBody + '         </select>';
            htmlBody = htmlBody + '     </div>';
            htmlBody = htmlBody + '</td>';
        }
        if ((i % columnas == 0 || i == listChek.length - 1) && i != 0) {
            htmlBody = htmlBody + '</tr>';
            if (i < listChek.length - 1)
                htmlBody = htmlBody + '<tr>';
            columnas += 3;
        }
    }
    htmlBody = htmlBody + '</tr>';

    $('#' + tbody).html(htmlBody);
}

ManInforme_Enfermedad.fnGetEnfermedad = function () {
    for (var i = 0; i < ManInforme_Enfermedad.DataEnfermedad.length; i++) {
        var obj = ManInforme_Enfermedad.DataEnfermedad[i];
        switch (obj.TIPO) {
            case "RADIO":
                if (document.getElementById("rbtn_" + obj.GRUPO + "_" + obj.COD_ENFERMEDAD + "_SI") != null) {
                    if (document.getElementById("rbtn_" + obj.GRUPO + "_" + obj.COD_ENFERMEDAD + "_SI").checked)
                        ManInforme_Enfermedad.DataEnfermedad[i].OBSERVACION = "SI";
                    else if (document.getElementById("rbtn_" + obj.GRUPO + "_" + obj.COD_ENFERMEDAD + "_NO").checked)
                        ManInforme_Enfermedad.DataEnfermedad[i].OBSERVACION = "NO";
                }
                break;
            case "CHECK":
                if (document.getElementById("check_" + obj.GRUPO + "_" + obj.COD_ENFERMEDAD) != null) {
                    if (document.getElementById("check_" + obj.GRUPO + "_" + obj.COD_ENFERMEDAD).checked)
                        ManInforme_Enfermedad.DataEnfermedad[i].OBSERVACION = "SI";
                }
                break;
            case "TEXT":
                if (document.getElementById("text_" + obj.GRUPO + "_" + obj.COD_ENFERMEDAD) != null)
                    ManInforme_Enfermedad.DataEnfermedad[i].OBSERVACION = document.getElementById("text_" + obj.GRUPO + "_" + obj.COD_ENFERMEDAD).value;
                break;
            case "SELECT":
                if (document.getElementById("select_" + obj.GRUPO + "_" + obj.COD_ENFERMEDAD) != null)
                    ManInforme_Enfermedad.DataEnfermedad[i].OBSERVACION = document.getElementById("select_" + obj.GRUPO + "_" + obj.COD_ENFERMEDAD).value;
                break;
        }
    }
    return ManInforme_Enfermedad.DataEnfermedad;
}


$(document).ready(function () {
    ManInforme_Enfermedad.fnLoadEnfermedad();
});