"use strict";
var _PreguntaEncuesta = {};

_PreguntaEncuesta.fnCloseModal = function () { /*implementado desde donde se instancia*/ }
_PreguntaEncuesta.fnSaveForm = function (data) { /*implementado desde donde se instancia*/ }

_PreguntaEncuesta.fnLoadDatosPregunta = function (data) {
    if (data != null && data != "") {
        _PreguntaEncuesta.frm.find("#hdfItemPregEnc_CodPregunta").val(data["COD_PREGUNTA"]);
        _PreguntaEncuesta.frm.find("#txtItemPregEnc_Pregunta").val(data["DES_PREGUNTA"]);
        _PreguntaEncuesta.frm.find("#txtItemPregEnc_NBueno").val(data["N_CHECK_BUENO"]);
        _PreguntaEncuesta.frm.find("#txtItemPregEnc_NRegular").val(data["N_CHECK_REGULAR"]);
        _PreguntaEncuesta.frm.find("#txtItemPregEnc_NMalo").val(data["N_CHECK_MALO"]);
        _PreguntaEncuesta.frm.find("#txtItemPregEnc_NNo").val(data["N_NO_CHECK"]);
        _PreguntaEncuesta.frm.find("#hdfItemPregEnc_PBueno").val(data["P_CHECK_BUENO"]);
        _PreguntaEncuesta.frm.find("#hdfItemPregEnc_PRegular").val(data["P_CHECK_REGULAR"]);
        _PreguntaEncuesta.frm.find("#hdfItemPregEnc_PMalo").val(data["P_CHECK_MALO"]);
        _PreguntaEncuesta.frm.find("#hdfItemPregEnc_PNo").val(data["P_NO_CHECK"]);
        _PreguntaEncuesta.frm.find("#hdfItemPregEnc_Participante").val(data["N_PARTICIPANTES"]);
    }
}

_PreguntaEncuesta.fnSetDatosPregunta = function () {
    var data = [];
    data["COD_PREGUNTA"] = _PreguntaEncuesta.frm.find("#hdfItemPregEnc_CodPregunta").val();
    data["DES_PREGUNTA"]=_PreguntaEncuesta.frm.find("#txtItemPregEnc_Pregunta").val();
    data["N_CHECK_BUENO"]=_PreguntaEncuesta.frm.find("#txtItemPregEnc_NBueno").val();
    data["N_CHECK_REGULAR"]=_PreguntaEncuesta.frm.find("#txtItemPregEnc_NRegular").val();
    data["N_CHECK_MALO"]=_PreguntaEncuesta.frm.find("#txtItemPregEnc_NMalo").val();
    data["N_NO_CHECK"] = _PreguntaEncuesta.frm.find("#txtItemPregEnc_NNo").val();

    var pBueno, pRegular, pMalo, pNo, nParticipantes;
    nParticipantes = parseInt(data["N_CHECK_BUENO"]) + parseInt(data["N_CHECK_REGULAR"]) + parseInt(data["N_CHECK_MALO"]) + parseInt(data["N_NO_CHECK"]);
    nParticipantes=nParticipantes==0?1:nParticipantes;
    pBueno = (parseInt(data["N_CHECK_BUENO"]) * 100) / nParticipantes;
    pRegular = (parseInt(data["N_CHECK_REGULAR"]) * 100) / nParticipantes;
    pMalo = (parseInt(data["N_CHECK_MALO"]) * 100) / nParticipantes;
    pNo = (parseInt(data["N_NO_CHECK"]) * 100) / nParticipantes;

    data["P_CHECK_BUENO"] = pBueno.toFixed(2);
    data["P_CHECK_REGULAR"] = pRegular.toFixed(2);
    data["P_CHECK_MALO"] = pMalo.toFixed(2);
    data["P_NO_CHECK"] = pNo.toFixed(2);
    data["N_PARTICIPANTES"] = ""+nParticipantes;

    return data;
}

_PreguntaEncuesta.fnSubmitForm = function () {
    _PreguntaEncuesta.frm.submit();
}

//_tipoEncuesta: [ENCUESTA,EVALINICIAL,EVALFINAL]
_PreguntaEncuesta.fnInit = function (_tipoEncuesta, data) {
    _PreguntaEncuesta.frm = $("#frmItemPregEnc");
    switch (_tipoEncuesta) {
        case "ENCUESTA":
            $("#lblItemPregEnc_Titulo").text("Datos de la Pregunta - Encuesta");
            break;
        case "EVALINICIAL":
            $("#lblItemPregEnc_Titulo").text("Datos de la Pregunta - Evaluación Inicial");
            break;
        case "EVALFINAL":
            $("#lblItemPregEnc_Titulo").text("Datos de la Pregunta - Evaluación Final");
            break;
    }

    _PreguntaEncuesta.fnLoadDatosPregunta(data);

    //=====-----Para el registro de datos del formulario-----=====
    _PreguntaEncuesta.frm.validate(utilSigo.fnValidate({
        rules: {
            txtItemPregEnc_Pregunta: { required: true },
            txtItemPregEnc_NBueno: { required: true },
            txtItemPregEnc_NRegular: { required: true },
            txtItemPregEnc_NMalo: { required: true },
            txtItemPregEnc_NNo: { required: true }
        },
        messages: {
            txtItemPregEnc_Pregunta: { required: "Ingrese la pregunta" },
            txtItemPregEnc_NBueno: { required: "Ingrese el número de participantes que marcaron Bueno" },
            txtItemPregEnc_NRegular: { required: "Ingrese el número de participantes que marcaron Regular" },
            txtItemPregEnc_NMalo: { required: "Ingrese el número de participantes que marcaron Malo" },
            txtItemPregEnc_NNo: { required: "Ingrese el número de participantes que no marcaron" }
        },
        fnSubmit: function (form) {
            _PreguntaEncuesta.fnSaveForm(_PreguntaEncuesta.fnSetDatosPregunta());
        }
    }));
    //Validación de controles que usan Select2
    _PreguntaEncuesta.frm.find("select.select2-hidden-accessible").on("change", function (e) {
        $(this).valid();
    });
}