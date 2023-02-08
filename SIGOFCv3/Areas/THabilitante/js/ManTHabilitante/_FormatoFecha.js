var primerslap = false;
var segundoslap = false;

formateafecha = function (fecha) {
    var long = fecha.length;
    var dia;
    var mes;
    var anio;
    if ((long >= 2) && (primerslap == false)) {
        dia = fecha.substr(0, 2);
        if (($.isNumeric(dia) == true) && (dia <= 31) && (dia != "00")) {
            fecha = fecha.substr(0, 2) + "/" + fecha.substr(3, 7);
            primerslap = true;
        }
        else { fecha = ""; primerslap = false; }
    }
    else {
        dia = fecha.substr(0, 1);
        if ($.isNumeric(dia) == false) { fecha = ""; }
        if ((long <= 2) && (primerslap = true)) { fecha = fecha.substr(0, 1); primerslap = false; }
    }
    if ((long >= 5) && (segundoslap == false)) {
        mes = fecha.substr(3, 2);
        if (($.isNumeric(mes) == true) && (mes <= 12) && (mes != "00")) {
            fecha = fecha.substr(0, 5) + "/" + fecha.substr(6, 4); segundoslap = true;
        }
        else { fecha = fecha.substr(0, 3);; segundoslap = false; }
    }
    else { if ((long <= 5) && (segundoslap = true)) { fecha = fecha.substr(0, 4); segundoslap = false; } }
    if (long >= 7) {
        anio = fecha.substr(6, 4);
        if ($.isNumeric(anio) == false) { fecha = fecha.substr(0, 6); }
        else { if (long == 10) { if ((anio == 0) || (anio < 1900) || (anio > 2100)) { fecha = fecha.substr(0, 6); } } }
    }
    if (long >= 10) {
        fecha = fecha.substr(0, 10);
        dia = fecha.substr(0, 2);
        mes = fecha.substr(3, 2);
        anio = fecha.substr(6, 4);
        // Año no viciesto y es febrero y el dia es mayor a 28 
        if ((anio % 4 != 0) && (mes == 02) && (dia > 28)) { fecha = fecha.substr(0, 2) + "/"; }
    }
    return (fecha);
}

chkEsMenor = function (fechaIni, fechaFin) {
    fechaIniAux = new Date();
    fechaFinAux = new Date();

    if ((!chkFechaOk(fechaIni)) || (!chkFechaOk(fechaFin))) {
        return false;
    }
    else {
        fechaIniAux.setMonth(getMes(fechaIni) - 1);
        fechaIniAux.setDate(getDia(fechaIni));
        fechaIniAux.setYear(getYear(fechaIni));

        fechaFinAux.setMonth(getMes(fechaFin) - 1);
        fechaFinAux.setDate(getDia(fechaFin));
        fechaFinAux.setYear(getYear(fechaFin));

        if (!chkRangoFechasMenor(fechaIniAux, fechaFinAux)) {
            return false;
        }
    }
    return true;
}

chkFechaOk = function (str) {
    var Dia;
    var Mes;
    var Year;

    Year = getYear(str);
    Mes = parseInt(getMes(str), 10);
    Dia = getDia(str);
    Year = chkFormatoYear(Year);

    if ((Mes == 1) || (Mes == 3) || (Mes == 5) || (Mes == 7) || (Mes == 8) || (Mes == 10) || (Mes == 12)) {
        if (Dia <= 0 || Dia > 31) { return false; }
    }
    else if ((Mes == 4) || (Mes == 6) || (Mes == 9) || (Mes == 11)) {
        if (Dia <= 0 || Dia > 30) { return false; }
    }
    else if (Mes == 2) {
        if ((Year % 4 == 0) && (Year % 100 != 0) || (Year % 400 == 0)) {
            if (Dia <= 0 || Dia > 29) { return false; }
        }
        else {
            if (Dia <= 0 || Dia > 28) { return false; }
        }
    }
    else { return false; }

    return true;
}

chkRangoFechasMenor = function (fechaIni, fechaFin) {
    if ((fechaFin - fechaIni) > 0)
        return true;
    else
        return false;
}

chkFormatoYear = function (str) {
    var Year;
    if (str.length == 2) {
        Year = parseInt(str, 10);
        if (Year >= 0 && Year < 49) {
            Year = Year + 2000;
        }
        else {
            Year = Year + 1900;
        }
    }
    else {
        Year = parseInt(str, 10);
    }

    return Year;
}

getDia = function (str) {
    var dia = "";
    var posIni = 0;
    var posFin = 0;

    posFin = str.indexOf("/");
    dia = str.substring(posIni, posFin);

    return (dia);
}

getMes = function (str) {
    var mes = "";
    var posIni = 0;
    var posFin = 0;

    posFin = str.indexOf("/");
    posIni = posFin;
    posFin = str.lastIndexOf("/");
    mes = str.substring(posIni + 1, posFin);

    return (mes);
}

getYear = function (str) {
    var year = "";
    var posIni = 0;

    posIni = str.lastIndexOf("/");
    year = str.substring(posIni + 1, str.length + 1);

    return (year);
}