var _EnviarCorreo = {};
_EnviarCorreo.codhallazgo;
_EnviarCorreo.DataDestino = [];
_EnviarCorreo.DataDestinoCC = [];
_EnviarCorreo.cadDestino;
_EnviarCorreo.cadDestinoCC;

_EnviarCorreo.fnRefreshTable = function () { /*Implementar en donde se instancia*/ };

_EnviarCorreo.MostrarCorreo = function (opc) {
    if (opc == 1) {
        $("#dvDestino").show();
        $("#dvAddDestino").hide();
    }
    else {
        $("#dvDestinoCC").show();
        $("#dvAddDestinoCC").hide();
    }
};

_EnviarCorreo.SendEmail = function () {
    for (i = 0; i < _EnviarCorreo.DataDestino.length; i++) {
        if (!_EnviarCorreo.ValidarEmail(_EnviarCorreo.DataDestino[i])) {
            utilSigo.toastWarning("Aviso", "El formato de uno o varios correos ingresados son incorrectos");
            _EnviarCorreo.frm.find("#txtdestino").focus();
            return false;
        }
    }

    for (i = 0; i < _EnviarCorreo.DataDestinoCC.length; i++) {
        if (!_EnviarCorreo.ValidarEmail(_EnviarCorreo.DataDestinoCC[i])) {
            utilSigo.toastWarning("Aviso", "El formato de uno o varios correos ingresados son incorrectos");
            _EnviarCorreo.frm.find("#txtdestinoCC").focus();
            return false;
        }
    }


    let txtdestino = "";
    for (i = 0; i < _EnviarCorreo.DataDestino.length; i++) {
        txtdestino += _EnviarCorreo.DataDestino[i] + ";";
    }

    let txtdestinoCC = "";
    for (i = 0; i < _EnviarCorreo.DataDestinoCC.length; i++) {
        txtdestinoCC += _EnviarCorreo.DataDestinoCC[i] + ";";
    }

    let txtasunto = _EnviarCorreo.frm.find("#txtasunto").val();
    let txtmensaje_envio = CKEDITOR.instances.txtmensaje_envio.getData();

    let model = { hdfCodHallazgo: _EnviarCorreo.codhallazgo, txtdestino, txtdestinoCC, txtasunto, txtmensaje_envio };

    let url = urlLocalSigo + "Supervision/ReporteVigilancia/EnviarMensaje";
    let option = { url: url, datos: JSON.stringify(model), type: 'POST' };

    utilSigo.fnAjax(option, function (data) {
        if (data.success) {
            _EnviarCorreo.fnRefreshTable();
        }
        else {
            utilSigo.toastWarning("Aviso", "Sucedio un error, Comuníquese con el Administrador");
            console.log(data.msj);
        }
    });
};

_EnviarCorreo.ValidarCampos = function () {
    var lista1 = lista2 = [];
    var index1 = index2 = 0;

    if (_EnviarCorreo.frm.find("#txtdestino").val() == null ||
        _EnviarCorreo.frm.find("#txtdestino").val().length == 0 ||
        /^\s+$/.test(_EnviarCorreo.frm.find("#txtdestino").val())) {
        utilSigo.toastWarning("Aviso", "Ingrese correos");
        _EnviarCorreo.frm.find("#txtdestino").focus();
        return false;
    }
    else {
        lista1 = _EnviarCorreo.frm.find("#txtdestino").val().split(";");
        for (let i = 0; i < lista1.length; i++) {
            if (lista1[i].trim().length > 0) {
                _EnviarCorreo.DataDestino[index1] = lista1[i].trim();
                index1++;
            }
        }

        if (_EnviarCorreo.frm.find("#txtdestinoCC").val() != null &&
            _EnviarCorreo.frm.find("#txtdestinoCC").val().trim().length > 0) {
            lista2 = _EnviarCorreo.frm.find("#txtdestinoCC").val().split(";");
            for (let i = 0; i < lista2.length; i++) {
                if (lista2[i].trim().length > 0) {
                    _EnviarCorreo.DataDestinoCC[index2] = lista2[i].trim();
                    index2++;
                }
            }
        }

        _EnviarCorreo.SendEmail();
    }
};

_EnviarCorreo.ValidarEmail = function (valor) {
    var resp = true;
    var re = /^([\da-z_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/;

    if (!re.exec(valor)) {
        resp = false;
    }

    return resp;
};

_EnviarCorreo.fnCargaMensaje = function () {
    /*var cad = "<style type=\"text/css\">" +
        "*{ font-size: 18px;}" +
        ".divMarco{ width: 920px; }" +
        "h1{ text-align: center; color: red; font-size: 34px; }" +
        "div > div{ width: 862px; min-height: 150px; border-radius: 25px; padding: 25px; border: 4px solid black; }" +
        "</style>\n" +
        "<div class=\"divMarco\">\t\t\n" +
        "<img src=\"http://www.osinfor.gob.pe/wp-content/uploads/2016/09/top-alerta-06.png\" />\n" +
        "<p>Ubicación: MADRE DE DIOS – TAMBOPATA – LAS PIEDRAS y Sector: RÍO PIEDRAS</br>\n" +
        "Título Habilitante: <strong>17-TAM/C-OPB-A-026-05</strong></br>\n" +
        "Titular: <strong>AREQUE KEA ALI</strong></br>\n" +
        "<strong>Coordenadas del título habilitante:</strong> ZONA UTM: 19S, ESTE: 457000, NORTE: 8662500</p>\n"+
        "<p>Descripción:</p>\n" +
        "<div><p> </p></div>\n" +
        "<p>Otros hechos relevantes:</p>\n" +
        "<div><p> </p></div>\n" +
        "<p> Se adjunta Acta de Supervisión OSINFOR, Balance de Extracción y Oficio de Comunicación en pdf:</p>\n" +
        "</div>";*/

    //_EnviarCorreo.frm.find("#txtmensaje_envio").val(cad);
    _EnviarCorreo.frm.find("#txtmensaje_envio").val("Texto de prueba");
};

_EnviarCorreo.fnInitEventos = function () {
    _EnviarCorreo.fnCargaMensaje();

    _EnviarCorreo.frm.find("#ddlDestinoId").change(function () {
        if (this.value != "-") {
            _EnviarCorreo.cadDestino = _EnviarCorreo.frm.find("#txtdestino").val();
            //_EnviarCorreo.cadDestino += $(this).find('option:selected').text() + "; ";
            _EnviarCorreo.cadDestino += this.value + "; ";
            _EnviarCorreo.frm.find("#txtdestino").val(_EnviarCorreo.cadDestino);
            $("#dvDestino").hide();
            $(this).val("-").trigger("change");
            $("#dvAddDestino").show();
        }
    });

    _EnviarCorreo.frm.find("#ddlDestinoCCId").change(function () {
        if (this.value != "-") {
            _EnviarCorreo.cadDestinoCC = _EnviarCorreo.frm.find("#txtdestinoCC").val();
            //_EnviarCorreo.cadDestinoCC += $(this).find('option:selected').text() + "; ";
            _EnviarCorreo.cadDestinoCC += this.value + "; ";
            _EnviarCorreo.frm.find("#txtdestinoCC").val(_EnviarCorreo.cadDestinoCC);
            $("#dvDestinoCC").hide();
            $(this).val("-").trigger("change");
            $("#dvAddDestinoCC").show();
        }
    });
};

_EnviarCorreo.fnInit = function (idhallazgo) {
    _EnviarCorreo.frm = $("#frmEnviarRptHallazgo");

    $.fn.select2.defaults.set("theme", "bootstrap4");
    _EnviarCorreo.frm.find("#ddlDestinoId").select2();
    _EnviarCorreo.frm.find("#ddlDestinoCCId").select2();

    var editor = CKEDITOR.instances['txtmensaje_envio'];
    if (editor) { editor.destroy(true); }
    CKEDITOR.replace('txtmensaje_envio', {
        toolbar: initSigo.configuracionCKEDITOR,
        height: 250
    });

    _EnviarCorreo.codhallazgo = idhallazgo;

    _EnviarCorreo.fnInitEventos();

    _EnviarCorreo.frm.find("#txtasunto").val("prueba osinfor");
};