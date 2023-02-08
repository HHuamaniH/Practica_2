"use strict";
var _Ubigeo = {};
_Ubigeo.departamentos = [];
_Ubigeo.provincias = [];
_Ubigeo.distritos = [];
_Ubigeo.fnSelectUbigeo = function (_ubigeoText, _ubigeoId) {
    //se implementa en cada llamada
}

_Ubigeo.cargarDepartamentos = function (data) {
    var cadenaDatos = data.split('¬');
    var depaData = cadenaDatos[0].split(',');
    var provData = cadenaDatos[1].split(',');
    var distData = cadenaDatos[2].split(',');
    for (var i = 0; i < depaData.length; i++) {
        var particionDepa = depaData[i].split('|');
        _Ubigeo.departamentos.push({ COD_UBIDEPARTAMENTO: particionDepa[0], DEPARTAMENTO: particionDepa[1] });
    }
    for (var i = 0; i < provData.length; i++) {
        var particionProv = provData[i].split('|');
        _Ubigeo.provincias.push({ COD_UBIDEPARTAMENTO: particionProv[0], COD_UBIPROVINCIA: particionProv[1], PROVINCIA: particionProv[2] });
    }
    for (var i = 0; i < distData.length; i++) {
        var particionDist = distData[i].split('|');
        _Ubigeo.distritos.push({ COD_UBIGEO: particionDist[0], COD_UBIPROVINCIA: particionDist[1], DISTRITO: particionDist[2] });
    }
    //cargando departamentos
    utilSigo.fillComboSelect2Ubigeo(_Ubigeo.frmUbigeo.find("#cboDepartamento"), _Ubigeo.departamentos, 0);
}
_Ubigeo.iniciarSelect2 = function () {
    $.fn.select2.defaults.set("theme", "bootstrap4");
    _Ubigeo.frmUbigeo.find("#cboDepartamento").select2();
    _Ubigeo.frmUbigeo.find("#cboProvincia").select2();
    _Ubigeo.frmUbigeo.find("#cboDistrito").select2();
}
_Ubigeo.iniciarEventos = function () {
    _Ubigeo.frmUbigeo.find("#cboDepartamento").change(function () {
        var depaSelectId = $(this).val();
        utilSigo.fillComboSelect2Ubigeo(_Ubigeo.frmUbigeo.find("#cboProvincia"), _Ubigeo.provincias, 1, depaSelectId);
        var provSelectId = _Ubigeo.frmUbigeo.find("#cboProvincia").val();
        utilSigo.fillComboSelect2Ubigeo(_Ubigeo.frmUbigeo.find("#cboDistrito"), _Ubigeo.distritos, 2, provSelectId);

    });
    _Ubigeo.frmUbigeo.find("#cboProvincia").change(function () {
        var provSelectId = $(this).val();
        utilSigo.fillComboSelect2Ubigeo(_Ubigeo.frmUbigeo.find("#cboDistrito"), _Ubigeo.distritos, 2, provSelectId);
    });
    _Ubigeo.frmUbigeo.find("#cboDistrito").change(function () {
        var distSelectId = $(this).val();
        var provSelect = _Ubigeo.frmUbigeo.find("#cboProvincia").val();
        if (distSelectId != '-' && provSelect != '-') {
            var ubigeoText = _Ubigeo.frmUbigeo.find("#cboDepartamento").select2('data')[0].text + " - " + _Ubigeo.frmUbigeo.find("#cboProvincia").select2('data')[0].text + " - " + $(this).select2('data')[0].text;
            _Ubigeo.fnSelectUbigeo(ubigeoText, distSelectId);
        }
    });
}
_Ubigeo.fnSelectDistrito = function (_ubigeoId) {
    if (_ubigeoId.length == 6) {
        var cod_dep = _ubigeoId.substring(0, 2);
        var cod_pro = _ubigeoId.substring(0, 4);

        utilSigo.fillComboSelect2Ubigeo(_Ubigeo.frmUbigeo.find("#cboProvincia"), _Ubigeo.provincias, 1, cod_dep);
        utilSigo.fillComboSelect2Ubigeo(_Ubigeo.frmUbigeo.find("#cboDistrito"), _Ubigeo.distritos, 2, cod_pro);
        _Ubigeo.frmUbigeo.find("#cboDepartamento").val(cod_dep);
        _Ubigeo.frmUbigeo.find("#cboProvincia").val(cod_pro);
        _Ubigeo.frmUbigeo.find("#cboDistrito").val(_ubigeoId);
    }
}

_Ubigeo.fnLoadData = function (_ubigeoId) {
    $.ajax({
        url: urlLocalSigo + "General/Controles/GetListUbigeoTodo",
        type: 'GET',
        data: {},
        dataType: 'text',
        success: function (data) {
            utilSigo.unblockUIGeneral();
            _Ubigeo.cargarDepartamentos(data);

            _Ubigeo.fnSelectDistrito(_ubigeoId);
        },
        beforeSend: function () {
            utilSigo.blockUIGeneral();
        },
        error: function (jqXHR, error, errorThrown) {
            utilSigo.unblockUIGeneral();
            utilSigo.toastError("Error", "Sucedio un Error Inesperado al cargar datos de ubigeo, Comuniquese con el Administrador");
            console.log(jqXHR.responseText);
        }
    });
}

_Ubigeo.fnLoadModalView = function (_ubigeoId) {
    _Ubigeo.frmUbigeo = $("#frmUbigeo");
    _Ubigeo.iniciarSelect2();
    _Ubigeo.iniciarEventos();
    _Ubigeo.fnLoadData(_ubigeoId);
}