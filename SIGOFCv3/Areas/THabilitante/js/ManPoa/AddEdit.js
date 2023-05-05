
"use strict";

var ManPOA = {};
(function () {

    $(document).ajaxStart(function () {
        $('.screen').show();
        //utilSigo.blockUIGeneral();
    }).ajaxStop(function () {
        //utilSigo.unblockUIGeneral();
        $('.screen').hide();
    });

    this.frmPOARegistro;
    this.controller = urlLocalSigo + "THabilitante/ManPOA";
    this.DGeneral = {};
    this.uploadFile = {};
    this.ItemRAPoa = {};
    this.ItemBExt = {};
    this.ItemBExtMaderable = {};
    this.ItemBExtNoMaderable = {};
    this.ItemBExtISitu = {};
    this.ItemRAPoaInSitu = {};
    this.ItemCMaderable = {};
    this.ItemCNoMaderable = {};
    this.Itemkardex = {};
    this.ListEliTABLA = [];
    //Datatables
    this.dtItemAOcular;
    this.dtItemIOcular;
    this.dtItemTRAprobacion;
    this.dtItemVertice;
    this.dtBExtPOA;
    this.listBExtPOA = [];
    //05/05/2021
    this.ListParcela = [];
    this.listPOADetRegente = [];
    this.listPOAEMGeneral = [];
    this.listPOAEMAdicional = [];
    //03/05/2023
    this.dtDetRegente;

    this.indexBExtPOA = 0;
    this.ListEliTABLA = [];
    this.init = function () {
        this.frmPOARegistro = $("#frmPOARegistro");
        this.dtItemAOcular = this.frmPOARegistro.find("#grItemAOcular").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bInfo: false,
            bLengthChange: false,
            scrollCollapse: true,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            ajax: {
                url: ManPOA.controller + "/GetAllListAOCULAR",
                type: "GET",
                datatype: "json"
            },
            columns:
                [
                    {
                        autoWidth: true, bSortable: false, visible: true,
                        mRender: function (data, type, row) {
                            return '<i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Editar" onclick="ManPOA.fnEditarPersona(this, ManPOA.dtItemAOcular, ' + "'IOCULAR'" + ');"></i>';

                        }
                    },
                    {
                        autoWidth: true, bSortable: false,
                        mRender: function (data, type, row) {
                            return '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManPOA.eliminarAOcular(this);"></i>';
                        }
                    },
                    { data: "NRO", autoWidth: true },
                    { data: "PERSONA", autoWidth: true },
                    { data: "N_DOCUMENTO", autoWidth: true },
                    //{ data: "CARGO", autoWidth: true },
                    { data: "TIPO_CARGO", autoWidth: true },
                    { data: "COD_PTIPO", visible: false },
                    { data: "RegEstado", visible: false }
                ]

        });
        this.dtDetRegente = this.frmPOARegistro.find("#grItemAOcular").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bInfo: false,
            bLengthChange: false,
            scrollCollapse: true,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            ajax: {
                url: ManPOA.controller + "/GetAllListDetRegente",
                type: "GET",
                datatype: "json"
            },
            columns:
                [
                    {
                        autoWidth: true, bSortable: false,
                        mRender: function (data, type, row) {
                            return '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick=""></i>';
                        }
                    },
                    {
                        autoWidth: true, bSortable: false,
                        mRender: function (data, type, row) {
                            return '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Adjuntar contrato" onclick=""></i>';
                        }
                    },
                    {
                        autoWidth: true, bSortable: false,
                        mRender: function (data, type, row) {
                            return '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Descargar contrato" onclick=""></i>';
                        }
                    },
                    { data: "NRO", autoWidth: true },
                    { data: "PERSONA", autoWidth: true },
                    { data: "N_DOCUMENTO", autoWidth: true },
                    { data: "TIPO_CARGO", autoWidth: true },

                ]

        });
        this.dtItemIOcular = this.frmPOARegistro.find("#grvItemIOcular").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bInfo: false,
            bLengthChange: false,
            scrollCollapse: true,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            ajax: {
                url: ManPOA.controller + "/GetAllListTIOCULAR",
                type: "GET",
                datatype: "json"
            },
            columns:
                [
                    {
                        autoWidth: true, bSortable: false, visible: true,
                        mRender: function (data, type, row) {
                            return '<i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Editar" onclick="ManPOA.fnEditarPersona(this, ManPOA.dtItemIOcular,' + "'ITIOCULAR'" + ');"></i>';

                        }
                    },
                    {
                        autoWidth: true, bSortable: false,
                        mRender: function (data, type, row) {
                            return '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManPOA.eliminarIOcular(this);"></i>';

                        }
                    },
                    { data: "NRO", autoWidth: true },
                    { data: "PERSONA", autoWidth: true },
                    { data: "N_DOCUMENTO", autoWidth: true },
                    //{ data: "CARGO", autoWidth: true },
                    { data: "TIPO_CARGO", autoWidth: true },
                    { data: "COD_PTIPO", visible: false },
                    { data: "COD_PERSONA", visible: false },
                    { data: "RegEstado", visible: false }
                ]

        });
        this.dtItemTRAprobacion = this.frmPOARegistro.find("#grvItemTRAprobacion").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bInfo: false,
            bLengthChange: false,
            scrollCollapse: true,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            ajax: {
                url: ManPOA.controller + "/GetAllListTRAPROBACION",
                type: "GET",
                datatype: "json"
            },
            columns:
                [
                    {
                        autoWidth: true, bSortable: false, visible: true,
                        mRender: function (data, type, row) {
                            return '<i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Editar" onclick="ManPOA.fnEditarPersona(this, ManPOA.dtItemTRAprobacion,' + "'ITRAPROBACION'" + ');"></i>';

                        }
                    },
                    {
                        autoWidth: true, bSortable: false,
                        mRender: function (data, type, row) {
                            return '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManPOA.eliminarTRAprobacion(this);"></i>';

                        }
                    },
                    { data: "NRO", autoWidth: true },
                    { data: "PERSONA", autoWidth: true },
                    { data: "N_DOCUMENTO", autoWidth: true },
                    //{ data: "CARGO", autoWidth: true },
                    { data: "TIPO_CARGO", autoWidth: true },
                    { data: "COD_PTIPO", visible: false },
                    { data: "RegEstado", visible: false }

                ]

        });
        this.dtItemVertice = this.frmPOARegistro.find("#grvItemVertice").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bInfo: false,
            bLengthChange: false,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            ajax: {
                url: ManPOA.controller + "/GetAllVertices",
                type: "GET",
                datatype: "json"
            },
            columns:
                [{
                    bSortable: false, data: "VERTICE",
                    mRender: function (data, type, row) {
                        return '<input type="hidden" class="hdCodSecuencial" value="' + row.COD_SECUENCIAL + '" /><input type="hidden" class="hdEstadoItemGen" value="' + row.RegEstado + '" /><input type="hidden" class="hdDdlItemZona_UTM" value="' + row.ZONA + '" /><i class="fa mx-2 fa-lg fa-pencil-square-o" title="Editar" style="cursor:pointer;" onclick="ManPOA.DGeneral.editVertice(this);"></i>';

                    }
                },
                {
                    bSortable: false, data: "VERTICE",
                    mRender: function (data, type, row) {
                        return '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManPOA.DGeneral.eliminarVerticeTabla(this);"></i>';

                    }
                },
                {
                    bSortable: false, data: "COD_SECUENCIAL"
                },
                { data: "VERTICE" },
                { data: "ZONA" },
                { data: "COORDENADA_ESTE" },
                { data: "COORDENADA_NORTE" },
                { data: "PCA" },
                { data: "OBSERVACION" }

                ]

        });
        this.dtBExtPOA = this.frmPOARegistro.find("#grvBExtPOA").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bInfo: false,
            bLengthChange: false,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns:
                [
                    {
                        bSortable: false,
                        mRender: function (data, type, row) {
                            return '<i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Editar" onclick="ManPOA.fnEditarBExtPOA(this);"></i>'
                                ;

                        }
                    },
                    {
                        bSortable: false,
                        mRender: function (data, type, row) {
                            return '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManPOA.eliminarBExtPOA(this);"></i>';

                        }
                    },
                    { data: "NRO", bSortable: false },
                    {
                        data: "BEXTRACCION_FEMISION", bSortable: false,
                        mRender: function (data, type, row) {
                            return "<u onclick='ManPOA.selecExtrac(this)' style='cursor:pointer'>" + data + "</u>";

                        }

                    },
                    { data: "COD_SECUENCIAL", visible: false }
                ],
            fnRowCallback: function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
                if (iDisplayIndex == 0 && ManPOA.indexBExtPOA == 0) {
                    $(nRow).css('background-color', '#81F79F');
                    ManPOA.frmPOARegistro.find("#hdfSelectBExtPOA_Index").val(iDisplayIndex);
                }
            }

        });
        this.dtRegente_Implementa = this.frmPOARegistro.find("#grvRegente_implementa").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bInfo: false,
            bLengthChange: false,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns:
                [
                    {
                        name: "NRO", bSortable: false, mRender: function (data, type, row, meta) {
                            return parseInt(meta.row) + 1;
                        }
                    },
                    { data: "PERSONA" },
                    { data: "N_DOCUMENTO" },
                    { data: "OTORGAMIENTO" },
                    { data: "RESAPROBACION" },
                    { data: "COD_CATEGORIA" },
                    { data: "CIP" },
                    { data: "ESTADO_REGENTE" }
                ]
        });
        this.dtErrorMaterial_DGeneral = this.frmPOARegistro.find("#grvErrorMaterial_DGeneral").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bInfo: false,
            bLengthChange: false,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns:
                [
                    {
                        name: "NRO", bSortable: false, mRender: function (data, type, row, meta) {
                            return parseInt(meta.row) + 1;
                        }
                    },
                    { data: "DA_FECRESOLUCION" },
                    { data: "NV_RESOLUCION" },
                    { data: "NV_NOMCAMPO" },
                    { data: "NV_VALANTERIOR" },
                    { data: "NV_VALACTUAL" },
                    { data: "NV_OBSERVACION" }
                ]
        });
        this.dtErrorMaterial_DAdicional = this.frmPOARegistro.find("#grvErrorMaterial_DAdicional").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bInfo: false,
            bLengthChange: false,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns:
                [
                    {
                        name: "NRO", bSortable: false, mRender: function (data, type, row, meta) {
                            return parseInt(meta.row) + 1;
                        }
                    },
                    { data: "DA_FECRESOLUCION" },
                    { data: "NV_RESOLUCION" },
                    { data: "NV_NOMCAMPO" },
                    { data: "NV_VALANTERIOR" },
                    { data: "NV_VALACTUAL" },
                    { data: "NV_OBSERVACION" }
                ]
        });

        CKEDITOR.replace('txtControlCalidadObservaciones', {
            toolbar: initSigo.configuracionCKEDITOR
        });

        var valor = $("#ddlItemIndicadorId option:selected").text();
        if (valor === "Control de Calidad con Observaciones")
            this.frmPOARegistro.find("#divCalidad").show("slow");
        else
            this.frmPOARegistro.find("#divCalidad").hide("slow");


        this.frmPOARegistro
            .find("#txtItemInicio_Vigencia,#txtItemFin_Vigencia,#txtItemActa_Iocular_Fe,#txtItemAresolucion_Fecha,#txtItemItecnico_Raprobacion_Fecha,#txtItemFEmisionBExtracion,#txtItemItecnico_Iocular_Fecha,#txtFechaAcervo")
            .datepicker(initSigo.formatDatePicker);
        this.visibleSinInsOcu();
        $.fn.select2.defaults.set("theme", "bootstrap4");
        ManPOA.ItemRAPoa.frmResolAprob = $("#frmResolAprob");
        ManPOA.DGeneral.frmVertice = $("#frmVertice");
        ManPOA.ItemBExtNoMaderable.frmBExtNoMaderable = $("#frmBExtNoMaderable");
        ManPOA.modNoMaderable();
        ManPOA.seteaBExtPermisos();

        jQuery.validator.addMethod("invalidFrm", function (value, element) {
            switch ($(element).attr('id')) {
                case 'ddlItemIndicadorId':
                    return (value == '0000000') ? false : true;
                    break;
                case 'ddlODRegistroId':
                    return (value == '0000000') ? false : true;
                    break;

            }
        });
        this.frmPOARegistro.validate({
            //    focusInvalid: true,
            ignore: ".ignore",
            rules: {
                ddlItemIndicadorId: { invalidFrm: true },
                ddlODRegistroId: { invalidFrm: true }

            },
            messages: {
                ddlItemIndicadorId: { invalidFrm: "Debe seleccionar la situación actual de su registro" },
                ddlODRegistroId: { invalidFrm: "Debe seleccionar la O.D. desde donde se registra la información" }
            },
            errorPlacement: function (error, element) {
                var lElement = $(element);
                lElement.addClass('border-danger');
                lElement.attr('data-toggle', 'tooltip');
                lElement.attr('data-placement', 'top');
                lElement.attr('data-original-title', error.text());
                $('[data-toggle="tooltip"]').tooltip();
            },
            success: function (label, element) {
                var lElement = $(element);
                lElement.removeClass('border-danger');
                lElement.removeAttr('data-toggle');
                lElement.removeAttr('data-placement');
                lElement.removeAttr('data-original-title');
            },
            invalidHandler: function (e, validator) {

                if (validator.errorList.length) {
                    $('a[href="#' + jQuery(validator.errorList[0].element).closest(".tab-pane").attr('id') + '"]').trigger('click');
                }
            },

            submitHandler: function (form) {
                if (ManPOA.validaSave()) {
                    utilSigo.dialogConfirm('', 'Desea continuar con la operación?', function (r) {
                        if (r) {
                            ManPOA.save();
                        }
                    });
                }
            }
        });

        $("#btnSavePoa").click(function () {
            if (!ManPOA.validacionGeneral()) {
                return ManPOA.frmPOARegistro.valid();
            }
            ManPOA.frmPOARegistro.submit();
        });
        $("#chkConcluido,#chkProceso,#chkPendiente").click(function () {
            var id = $(this).attr("id");
            //console.log(id);
            if (id == "chkConcluido") {
                $("#chkProceso,#chkPendiente").prop('checked', false);

            }
            if (id == "chkProceso") {
                $("#chkConcluido,#chkPendiente").prop("checked", false);
            }
            if (id == "chkPendiente") {
                $("#chkConcluido,#chkProceso").prop("checked", false);
            }
        });

        ManPOA.ItemRAPoa.frmResolAprob.find("#ddlTipoMaderables_RAprob").change(function () {
            if (this.value != "-") {
                if (this.value == "CARBON" || this.value == "NO MADERABLES") {
                    ManPOA.ItemRAPoa.frmResolAprob.find("#ddlRAPoaUM").val("KG");
                }
                else if (this.value == "MADERABLES") ManPOA.ItemRAPoa.frmResolAprob.find("#ddlRAPoaUM").val("M3");

                ManPOA.ItemRAPoa.frmResolAprob.find("#ddlRAPoaUM").attr("disabled", true);
            }
            else {
                ManPOA.ItemRAPoa.frmResolAprob.find("#ddlRAPoaUM").val("-");
                ManPOA.ItemRAPoa.frmResolAprob.find("#ddlRAPoaUM").attr("disabled", false);
            }
        });

        //MEJORA INTEGRACION SIADO
        if (true) {

        }
    };
    this.validacionGeneral = function () {
        var ids = ["ddlItemIndicadorId", "ddlODRegistroId"];
        var idtab = "";
        var valRetorno = true;
        var idControlError = "";
        $.each(ids, function (i, o) {
            if ($("#" + o).val() == "" || $("#" + o).val() == "0000000") {
                idControlError = $("#" + o);
                idtab = $("#" + o).parents(".tab-pane").attr("id");
                valRetorno = false;
                return false;
            }
        });
        //console.log(idtab);
        if (idtab != "") {
            $('a[href="#' + idtab + '"]').tab('show');
            idControlError.focus();
        }
        return valRetorno;
    }
    this.openZafraModal = function () {
        window.open('https://sisfor.osinfor.gob.pe/visor/sisforv4/geoPOA/' + this.frmPOARegistro.find("#hdfItemCod_THabilitante").val() + '|' + this.frmPOARegistro.find("#txtItemNumPOA").val(), '_blank');
    }
    this.selecExtrac = function (obj) {
        var $tr = $(obj).closest('tr');
        this.indexBExtPOA = ManPOA.dtBExtPOA.row($tr).index();

        $("#grvBExtPOA >tbody >tr").each(function () {
            $(this).css('background-color', 'white');
        });
        $tr.css('background-color', '#81F79F');


        var row = this.dtBExtPOA.row($tr).data();

        ManPOA.ItemBExt.dtItemBExt.clear().draw();
        ManPOA.ItemBExtMaderable.dtItemBExtMaderable.clear().draw();
        ManPOA.ItemBExtNoMaderable.dtItemBExtNoMaderable.clear().draw();
        ManPOA.ItemBExtISitu.dtItemBExtISitu.clear().draw();

        if (typeof ManPOA.listBExtPOA[this.indexBExtPOA] != "undefined") {
            ManPOA.ItemBExt.dtItemBExt.rows.add(ManPOA.listBExtPOA[this.indexBExtPOA].listMadeBEXTRACCION).draw();
            ManPOA.ItemBExtMaderable.dtItemBExtMaderable.rows.add(ManPOA.listBExtPOA[this.indexBExtPOA].listMadeBEXTRACCION).draw();
            ManPOA.ItemBExtNoMaderable.dtItemBExtNoMaderable.rows.add(ManPOA.listBExtPOA[this.indexBExtPOA].ListNoMadeBEXTRACCION).draw();
            ManPOA.ItemBExtISitu.dtItemBExtISitu.rows.add(ManPOA.listBExtPOA[this.indexBExtPOA].ListISituBEXTRACCION).draw();
        }
        utilSigo.toastSuccess("Exito", "Se selecciono con exito la fecha de emision");
    };

    this.tieneNumPOA = function () {
        if (ManPOA.frmPOARegistro.find("#chkNPNumPOA").is(":checked")) {

            ManPOA.frmPOARegistro.find("#txtItemNumPOA").prop("disabled", true);
            if (ManPOA.frmPOARegistro.find("#chkPOAPO").is(":checked")) {
                ManPOA.frmPOARegistro.find("#txtNombrePOA").val("PO No Consigna");
            }
            else {
                ManPOA.frmPOARegistro.find("#txtNombrePOA").val("POA No Consigna");
            }
        }
        else {
            ManPOA.frmPOARegistro.find("#txtItemNumPOA").prop("disabled", false);
            if (ManPOA.frmPOARegistro.find("#chkPOAPO").is(":checked")) {
                ManPOA.frmPOARegistro.find("#txtNombrePOA").val("PO " + ManPOA.frmPOARegistro.find("#txtItemNumPOA").val());
            }
            else {
                ManPOA.frmPOARegistro.find("#txtNombrePOA").val("POA " + ManPOA.frmPOARegistro.find("#txtItemNumPOA").val());
            }
        }
    }
    this.NumPOAAprobada = function () {
        if (ManPOA.frmPOARegistro.find("#chkPOAPO").is(":checked")) {
            if (ManPOA.frmPOARegistro.find("#chkNPNumPOA").is(":checked")) {
                ManPOA.frmPOARegistro.find("#txtNombrePOA").val("PO No Consigna");
            }
            else {
                ManPOA.frmPOARegistro.find("#txtNombrePOA").val("PO " + ManPOA.frmPOARegistro.find("#txtItemNumPOA").val());
            }
        }
        else {
            if (ManPOA.frmPOARegistro.find("#chkNPNumPOA").is(":checked")) {
                ManPOA.frmPOARegistro.find("#txtNombrePOA").val("POA No Consigna");
            }
            else {
                ManPOA.frmPOARegistro.find("#txtNombrePOA").val("POA " + ManPOA.frmPOARegistro.find("#txtItemNumPOA").val());
            }
        }
    }

    this.visibleSinInsOcu = function () {
        if (ManPOA.frmPOARegistro.find("#chckSinInspOcu").is(":checked")) {
            ManPOA.frmPOARegistro.find("#divInspeccionOc").hide("slow");
        }
        else {
            ManPOA.frmPOARegistro.find("#divInspeccionOc").show("slow");
        }

    }

    this.fnBuscarPersona = function (_dom, _tipoPersonaSIGOsfc) {
        var url = urlLocalSigo + "General/Controles/_BuscarPersonaGeneral";
        var option = { url: url, type: 'GET', datos: { asBusGrupo: "PERSONA", asCodPTipo: _tipoPersonaSIGOsfc, asTipoPersona: "N" }, divId: "mdlBuscarPersona" };
        utilSigo.fnOpenModal(option, function () {
            _bPerGen.fnAsignarDatos = function (obj) {
                if (obj != null && obj != "") {
                    var data = _bPerGen.dtBuscarPerona.row($(obj).parents('tr')).data();
                    switch (_dom) {
                        case "REGENTE":
                            ManPOA.fnSetPersonaCompleto(_dom, data["COD_PERSONA"], data["COD_PTIPO"], data["TIPO_CARGO"]);
                            ManPOA.frmPOARegistro.find("#txtCodUbigeo").val(data["COD_UBIGEO"]);
                            ManPOA.frmPOARegistro.find("#txtUbigeo").val(data["UBIGEO"]);
                            ManPOA.frmPOARegistro.find("#txtDirecion").val(data["DIRECCION"]);
                            break;
                        case "REGENTEIMPLEMENTA":
                            if (!utilDt.existValorSearch(ManPOA.dtDetRegente, "COD_PERSONA", data["COD_PERSONA"])) {
                                if (data["COD_PTIPO"] != null && data["COD_PTIPO"].trim() != "" &&
                                    _tipoPersonaSIGOsfc != "TODOS" && _tipoPersonaSIGOsfc != "") {
                                    let tipoCargo = _tipoPersonaSIGOsfc.split(',');
                                    let band = 0;

                                    for (let i = 0; i < tipoCargo.length; i++) {
                                        if (tipoCargo[i] == data["COD_PTIPO"]) {
                                            band = 1;
                                            break;
                                        }
                                    }

                                    if (band == 0) {
                                        utilSigo.toastWarning("Aviso", "El cargo asignado no corresponde a lo requerido en la lista");
                                    }
                                    else {
                                        ManPOA.fnSetPersonaCompleto(_dom, data["COD_PERSONA"], data["COD_PTIPO"], data["TIPO_CARGO"]);
                                    }
                                }
                                else {
                                    ManPOA.fnSetPersonaCompleto(_dom, data["COD_PERSONA"], data["COD_PTIPO"], data["TIPO_CARGO"]);
                                }
                            } else { utilSigo.toastWarning("Aviso", "El técnico del acta de inspección ocular ya se encuentra registrado"); }
                            break;
                        case "FAPROBACION":
                            ManPOA.fnSetPersonaCompleto(_dom, data["COD_PERSONA"], data["COD_PTIPO"], data["TIPO_CARGO"]); break;
                        case "IOCULAR":
                            if (!utilDt.existValorSearch(ManPOA.dtItemAOcular, "COD_PERSONA", data["COD_PERSONA"])) {
                                if (data["COD_PTIPO"] != null && data["COD_PTIPO"].trim() != "" &&
                                    _tipoPersonaSIGOsfc != "TODOS" && _tipoPersonaSIGOsfc != "") {
                                    let tipoCargo = _tipoPersonaSIGOsfc.split(',');
                                    let band = 0;

                                    for (let i = 0; i < tipoCargo.length; i++) {
                                        if (tipoCargo[i] == data["COD_PTIPO"]) {
                                            band = 1;
                                            break;
                                        }
                                    }

                                    if (band == 0) {
                                        utilSigo.toastWarning("Aviso", "El cargo asignado no corresponde a lo requerido en la lista");
                                    }
                                    else {
                                        ManPOA.fnSetPersonaCompleto(_dom, data["COD_PERSONA"], data["COD_PTIPO"], data["TIPO_CARGO"]);
                                    }
                                }
                                else {
                                    ManPOA.fnSetPersonaCompleto(_dom, data["COD_PERSONA"], data["COD_PTIPO"], data["TIPO_CARGO"]);
                                }
                            } else { utilSigo.toastWarning("Aviso", "El técnico del acta de inspección ocular ya se encuentra registrado"); }
                            break;
                        case "ITIOCULAR":
                            if (!utilDt.existValorSearch(ManPOA.dtItemIOcular, "COD_PERSONA", data["COD_PERSONA"])) {
                                if (data["COD_PTIPO"] != null && data["COD_PTIPO"].trim() != "" &&
                                    _tipoPersonaSIGOsfc != "TODOS" && _tipoPersonaSIGOsfc != "") {
                                    let tipoCargo = _tipoPersonaSIGOsfc.split(',');
                                    let band = 0;

                                    for (let i = 0; i < tipoCargo.length; i++) {
                                        if (tipoCargo[i] == data["COD_PTIPO"]) {
                                            band = 1;
                                            break;
                                        }
                                    }

                                    if (band == 0) {
                                        utilSigo.toastWarning("Aviso", "El cargo asignado no corresponde a lo requerido en la lista");
                                    }
                                    else {
                                        ManPOA.fnSetPersonaCompleto(_dom, data["COD_PERSONA"], data["COD_PTIPO"], data["TIPO_CARGO"]);
                                    }
                                }
                                else {
                                    ManPOA.fnSetPersonaCompleto(_dom, data["COD_PERSONA"], data["COD_PTIPO"], data["TIPO_CARGO"]);
                                }
                            } else { utilSigo.toastWarning("Aviso", "El técnico de la inspección ocular ya se encuentra registrado"); }
                            break;
                        case "ITRAPROBACION":
                            if (!utilDt.existValorSearch(ManPOA.dtItemTRAprobacion, "COD_PERSONA", data["COD_PERSONA"])) {
                                if (data["COD_PTIPO"] != null && data["COD_PTIPO"].trim() != "" &&
                                    _tipoPersonaSIGOsfc != "TODOS" && _tipoPersonaSIGOsfc != "") {
                                    let tipoCargo = _tipoPersonaSIGOsfc.split(',');
                                    let band = 0;

                                    for (let i = 0; i < tipoCargo.length; i++) {
                                        if (tipoCargo[i] == data["COD_PTIPO"]) {
                                            band = 1;
                                            break;
                                        }
                                    }

                                    if (band == 0) {
                                        utilSigo.toastWarning("Aviso", "El cargo asignado no corresponde a lo requerido en la lista");
                                    }
                                    else {
                                        ManPOA.fnSetPersonaCompleto(_dom, data["COD_PERSONA"], data["COD_PTIPO"], data["TIPO_CARGO"]);
                                    }
                                }
                                else {
                                    ManPOA.fnSetPersonaCompleto(_dom, data["COD_PERSONA"], data["COD_PTIPO"], data["TIPO_CARGO"]);
                                }
                            } else { utilSigo.toastWarning("Aviso", "El técnico que recomienda la aprobación ya se encuentra registrado"); }
                            break;
                        case "EVACERVO":
                            ManPOA.frmPOARegistro.find("#hdEspAcervo").val(data["COD_PERSONA"]);
                            ManPOA.frmPOARegistro.find("#lbEspecialistaAcervo").val(data["PERSONA"]);
                            break;
                    }
                    utilSigo.fnCloseModal("mdlBuscarPersona");
                }
            }
            _bPerGen.fnInit();
        });
    }
    this.fnSetPersonaCompleto = function (_dom, codPersona, codPTipo, tipoCargo) {
        $.ajax({
            url: urlLocalSigo + "General/Controles/GetPersona",
            type: 'POST',
            data: { asCodPersona: codPersona },
            dataType: 'json',
            //beforeSend: utilSigo.beforeSendAjax,
            //complete: utilSigo.completeAjax,
            error: utilSigo.errorAjax,
            success: function (data) {
                if (data.success) {
                    switch (_dom) {
                        case "REGENTE":
                            ManPOA.frmPOARegistro.find("#hdfItemConsultorCodigo").val(data.data["COD_PERSONA"]);
                            ManPOA.frmPOARegistro.find("#lblItemConsultorNombre").val(data.data["APELLIDOS_NOMBRES"]);
                            ManPOA.frmPOARegistro.find("#lblItemConsultorDNI").val(data.data["N_DOCUMENTO"]);
                            ManPOA.frmPOARegistro.find("#txtItemNRConsultor").val(data.data["NUM_REGISTRO_FFS"]);
                            ManPOA.frmPOARegistro.find("#lblItemConsultorNRProfesional").val(data.data["NUM_REGISTRO_PROFESIONAL"]);
                            break;
                        case "REGENTEIMPLEMENTA":
                            var dt = null;
                            dt: ManPOA.dtDetRegente;
                            break;
                        case "IOCULAR":
                        case "ITIOCULAR":
                        case "ITRAPROBACION":
                            var dt = null;
                            switch (_dom) {
                                case "IOCULAR": dt = ManPOA.dtItemAOcular; break;
                                case "ITIOCULAR": dt = ManPOA.dtItemIOcular; break;
                                case "ITRAPROBACION": dt = ManPOA.dtItemTRAprobacion; break;
                                default: return false;
                            }
                            var codSecC = parseInt(dt.$("tr").length) + 1;
                            var item = { NRO: codSecC, /*CARGO: data.data["CARGO"],*/ COD_PERSONA: data.data["COD_PERSONA"], N_DOCUMENTO: data.data["N_DOCUMENTO"], PERSONA: data.data["APELLIDOS_NOMBRES"], COD_PTIPO: codPTipo, TIPO_CARGO: tipoCargo, RegEstado: "1" };
                            dt.row.add(item).draw(); dt.page('last').draw('page');
                            break;
                        case "FAPROBACION":
                            ManPOA.frmPOARegistro.find("#hdfItemARFuncionarioCodigo").val(data.data["COD_PERSONA"]);
                            ManPOA.frmPOARegistro.find("#lblItemARFuncionario").val(data.data["APELLIDOS_NOMBRES"]);
                            ManPOA.frmPOARegistro.find("#lblItemARFuncionarioODatos").val(data.data["N_DOCUMENTO"] + " - " + data.data["CARGO"]);
                            break;
                    }
                } else {
                    utilSigo.toastError("Error", "No se pudo consultar los datos de la persona");
                    //console.log(data.msj);
                    return false;
                }
            }
        });
    }

    //Editar persona desde un datatable del formulario
    this.fnEditarPersona = function (e, dt, _dom) {
        //ManPOA.dtItemAOcular
        //grItemAOcular

        let row = dt.row($(e).parents('tr'));
        let data_row = row.data();
        let codPTipo = "TODOS";

        if (_dom == "ITIOCULAR") {
            codPTipo = "0000005";
        }
        else if (_dom == "ITRAPROBACION") {
            codPTipo = "0000021";
        }

        //console.log(data_row);

        /*let params = {
            type: 'post',
            url: initSigo.urlControllerGeneral + 'GetPersona',
            datos: JSON.stringify({ asCodPersona: data_row.COD_PERSONA })
        };
        
        utilSigo.fnAjax(params, function (res) {
            let option = {
                url: initSigo.urlControllerGeneral + "/_Persona", divId: "modalAddEditPersona", datos: {}
            };

            utilSigo.fnOpenModal(option, function () {
                let data = res.data;
                _bPerAddEdit.fnInit(data.COD_TPERSONA, (data.ListTipoCargo[0] || {}).COD_PTIPO);
                _bPerAddEdit.cargarDatosEdit(data);
                _bPerAddEdit.fnAsignarDatos = function (_, datos) {
                    ////console.log(datos);
                    data_row.N_DOCUMENTO = datos.txtItemPN_DINumero;
                    data_row.PERSONA = datos.txtItemPN_APaterno + ' ' + datos.txtItemPN_AMaterno + ' ' + datos.txtItemPN_Nombres;
                    data_row.CARGO = datos.txtICargo;
                    row.data(data_row).draw();
                }
            });
        });*/

        let params = {
            url: initSigo.urlControllerGeneral + "/_ActualizaCargoPersona",
            divId: "modalAddEditPersona",
            datos: {
                asFormulario: "POA",
                asCodPersona: data_row.COD_PERSONA
            }
        };

        utilSigo.fnOpenModal(params, function () {
            _ActualizaCargoPersona.fnAsignarDatos = function (datos) {
                data_row.COD_PTIPO = datos.ddlITipoCargoId;
                data_row.TIPO_CARGO = datos.txtITipoCargo;

                if (data_row.RegEstado == 0) data_row.RegEstado = 2;

                row.data(data_row).draw();
            };
            _ActualizaCargoPersona.fnInit(codPTipo, data_row.COD_PTIPO);
        });
    }

    this.eliminarAOcular = function (obj) {

        utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?",
            function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');
                    var row = ManPOA.dtItemAOcular.row($tr).data();
                    if (row.RegEstado == 0 || row.RegEstado == 2) {
                        ManPOA.ListEliTABLA.push({
                            EliTABLA: "POA_DET_AIOCULAR",
                            EliVALOR01: row.COD_PERSONA,
                            EliVALOR02: 0
                        });
                    }

                    ManPOA.dtItemAOcular.row($tr).remove().draw();
                    utilSigo.enumTB(ManPOA.dtItemAOcular, 2);

                }
            });
    }
    this.eliminarBExtPOA = function (obj) {

        utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?",
            function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');
                    var row = ManPOA.dtBExtPOA.row($tr).data();
                    if (row.RegEstado == 0 || row.RegEstado == 2) {
                        ManPOA.ListEliTABLA.push({
                            EliTABLA: "POA_INSITU_DET_BEXTRACCION",
                            COD_THABILITANTE: ManPOA.frmPOARegistro.find("#hdfItemCod_THabilitante").val(),
                            NUM_POA: ManPOA.frmPOARegistro.find("#hdfItemCod_THabilitante").val(),
                            EliVALOR02: row.COD_SECUENCIAL
                        });
                    }
                    ManPOA.listBExtPOA.splice((row.NRO - 1), 1);

                    if (ManPOA.indexBExtPOA == (row.NRO - 1)) {
                        ManPOA.ItemBExt.dtItemBExt.clear().draw();
                        ManPOA.ItemBExtMaderable.dtItemBExtMaderable.clear().draw();
                        ManPOA.ItemBExtNoMaderable.dtItemBExtNoMaderable.clear().draw();
                        ManPOA.ItemBExtISitu.dtItemBExtISitu.clear().draw();

                        //ManPOA.ItemBExtMaderable.dtItemBExtMaderable = ManPOA.listBExtPOA[0].listMadeBEXTRACCION;
                        //ManPOA.ItemBExtNoMaderable.dtItemBExtNoMaderable = ManPOA.listBExtPOA[0].ListNoMadeBEXTRACCION;
                        //ManPOA.ItemBExtISitu.dtItemBExtISitu = ManPOA.listBExtPOA[0].ListISituBEXTRACCION;
                        ManPOA.indexBExtPOA = 0;

                    }

                    for (var i = 0; i < ManPOA.listBExtPOA.length; i++) {
                        ManPOA.listBExtPOA[i].NRO = i + 1;
                    }


                    ManPOA.dtBExtPOA.row($tr).remove().draw();
                    utilSigo.enumTB(ManPOA.dtBExtPOA, 2);

                    if (ManPOA.dtBExtPOA.data().count() === 0) {
                        ManPOA.frmPOARegistro.find("#hdfSelectBExtPOA_Index").val("");
                        ManPOA.indexBExtPOA = '';
                    }
                }
            });
    };
    this.eliminarTRAprobacion = function (obj) {

        utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?",
            function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');
                    var row = ManPOA.dtItemTRAprobacion.row($tr).data();
                    if (row.RegEstado == 0 || row.RegEstado == 2) {
                        ManPOA.ListEliTABLA.push({
                            EliTABLA: "POA_DET_TRAPROBACION",
                            EliVALOR01: row.COD_PERSONA,
                            EliVALOR02: 0
                        });
                    }
                    ManPOA.dtItemTRAprobacion.row($tr).remove().draw();
                    utilSigo.enumTB(ManPOA.dtItemTRAprobacion, 2);

                }
            });
    }
    this.eliminarIOcular = function (obj) {

        utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?",
            function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');
                    var row = ManPOA.dtItemIOcular.row($tr).data();
                    if (row.RegEstado == 0 || row.RegEstado == 2) {
                        ManPOA.ListEliTABLA.push({
                            EliTABLA: "POA_DET_TIOCULAR",
                            EliVALOR01: row.COD_PERSONA,
                            EliVALOR02: 0
                        });
                    }
                    ManPOA.dtItemIOcular.row($tr).remove().draw(false);
                    utilSigo.enumTB(ManPOA.dtItemIOcular, 2);

                }
            });
    };

    this.fnValidarItemBExtPOAGrabar = function () {
        var txtItemFEmisionBExtracion = ManPOA.frmPOARegistro.find("#txtItemFEmisionBExtracion").val().trim();

        if (txtItemFEmisionBExtracion === "") {
            utilSigo.toastWarning("Error", "Seleccione la fecha de emisión del balance de extracción");
            return false;
        }

        if (ManPOA.frmPOARegistro.find("#hdfItemBExtPOA_RegEstado").val() === "1") {
            let $rows = ManPOA.dtBExtPOA.$("tr");
            let codSecC = $rows.length + 1;
            ManPOA.listBExtPOA.push({
                NRO: codSecC,
                BEXTRACCION_FEMISION: txtItemFEmisionBExtracion,
                listMadeBEXTRACCION: [],
                ListNoMadeBEXTRACCION: [],
                ListISituBEXTRACCION: [],
                COD_SECUENCIAL: 0,
                RegEstado: 1
            });
            ManPOA.dtBExtPOA.clear().draw();
            ManPOA.dtBExtPOA.rows.add(ManPOA.listBExtPOA).draw();
            ManPOA.dtBExtPOA.page('last').draw('page');
            utilSigo.toastSuccess("Exito", "Se Adiciono correctamente");
        } else {
            var indice = ManPOA.frmPOARegistro.find("#hdfItemBExtPOA_Index").val();
            //console.log(ManPOA.indexBExtPOA);
            if (ManPOA.listBExtPOA[ManPOA.indexBExtPOA] === undefined) {
                ManPOA.listBExtPOA.push({
                    NRO: 1,
                    BEXTRACCION_FEMISION: txtItemFEmisionBExtracion,
                    listMadeBEXTRACCION: [],
                    ListNoMadeBEXTRACCION: [],
                    ListISituBEXTRACCION: [],
                    COD_SECUENCIAL: 0,
                    RegEstado: 1
                });
                ManPOA.dtBExtPOA.rows.add(ManPOA.listBExtPOA);
            }
            ManPOA.listBExtPOA[ManPOA.indexBExtPOA].BEXTRACCION_FEMISION = txtItemFEmisionBExtracion;
            ManPOA.listBExtPOA[ManPOA.indexBExtPOA].RegEstado = 2;

            ManPOA.dtBExtPOA.cell(indice, 3).data(txtItemFEmisionBExtracion).draw();

            ManPOA.frmPOARegistro.find("#hdfItemBExtPOA_RegEstado").val("1");
            ManPOA.frmPOARegistro.find("#btnItemBExtPOAGrabar").text('Agregar');
            utilSigo.toastSuccess("Exito", "Se modifico correctamente");
        }
    };

    this.fnLimpiarItemBExtPOA = function () {
        ManPOA.frmPOARegistro.find("#txtItemFEmisionBExtracion").val("");
        ManPOA.frmPOARegistro.find("#hdfItemBExtPOA_Index").val("");
        ManPOA.frmPOARegistro.find("#hdfItemBExtPOA_RegEstado").val("1");
        ManPOA.frmPOARegistro.find("#btnItemBExtPOAGrabar").text('Agregar');
    };

    this.fnEditarBExtPOA = function (obj) {

        var $tr = $(obj).closest('tr');
        var index = ManPOA.dtBExtPOA.row($tr).index();
        var data = ManPOA.dtBExtPOA.row($tr).data();
        ManPOA.frmPOARegistro.find("#btnItemBExtPOAGrabar").text('Modificar');
        ManPOA.indexBExtPOA = index;
        ManPOA.frmPOARegistro.find("#txtItemFEmisionBExtracion").val(data.BEXTRACCION_FEMISION);
        ManPOA.frmPOARegistro.find("#hdfItemBExtPOA_Index").val(index);
        ManPOA.frmPOARegistro.find("#hdfItemBExtPOA_RegEstado").val("0");
    };
    this.Seleccionar = function (combo) {


        var valor = combo.options[combo.selectedIndex].text;

        if (valor == "Control de Calidad con Observaciones")
            this.frmPOARegistro.find("#divCalidad").show("slow");
        else
            this.frmPOARegistro.find("#divCalidad").hide("slow");

    };

    this.modNoMaderable = function () {
        this.seteaNoMadPermisos();
        this.ocultarCarrizo(false);
        this.plantaMedicinal(false);
        var hdfItemCod_MTipo = this.frmPOARegistro.find("#hdfItemCod_MTipo").val();

        if (hdfItemCod_MTipo == "0000020") {
            ManPOA.frmPOARegistro.find("#pnlNoMaderableItemCenso").toggle(false);
            this.ocultarCarrizo(true);
            ManPOA.ItemRAPoa.frmResolAprob.find("#trVolumenAuto").toggle(false);
            ManPOA.ItemRAPoa.frmResolAprob.find("#trNumArboles").toggle(false);
            ManPOA.ItemRAPoa.frmResolAprob.find("#trRAPoaUM").toggle(false);
            ManPOA.ItemBExtNoMaderable.frmBExtNoMaderable.find("#trkgAutorizadoBalance").toggle(false);
            ManPOA.ItemBExtNoMaderable.frmBExtNoMaderable.find("#trKgMovilizadoBalance").toggle(false);
            this.plantaMedicinal(false);
        }
        if (hdfItemCod_MTipo == "0000021") {
            ManPOA.frmPOARegistro.find("#pnlNoMaderableItemCenso").toggle(false);
            this.ocultarCarrizo(false);
            ManPOA.ItemRAPoa.frmResolAprob.find("#trVolumenAuto").toggle(false);
            ManPOA.ItemRAPoa.frmResolAprob.find("#trNumArboles").toggle(false);
            ManPOA.ItemRAPoa.frmResolAprob.find("#trRAPoaUM").toggle(false);
            ManPOA.ItemBExtNoMaderable.frmBExtNoMaderable.find("#trkgAutorizadoBalance").toggle(false);
            ManPOA.ItemBExtNoMaderable.frmBExtNoMaderable.find("#trKgMovilizadoBalance").toggle(false);
            this.plantaMedicinal(true);
        }
    }

    this.seteaBExtPermisos = function () {
        var hdfItemEstadoOrigen = ManPOA.frmPOARegistro.find("#hdfItemEstadoOrigen").val();
        var hdfItemIndicador = ManPOA.frmPOARegistro.find("#hdfItemIndicador").val();
        var hdfItemCod_MTipo = ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val();

        if (
            (hdfItemEstadoOrigen == "PN" && hdfItemIndicador == "M") ||
            (hdfItemEstadoOrigen == "R") ||
            (hdfItemEstadoOrigen == "MS") ||
            (hdfItemEstadoOrigen == "PC")
        ) {
            ManPOA.frmPOARegistro.find("#txtgrvItemBExt").html("Balance de Extracción o Kardex del POA (Maderable)");
            ManPOA.frmPOARegistro.find("#hplMaderableItemBExtDownload").show();
            ManPOA.frmPOARegistro.find("#btnDownloadBExtMadNoMad").attr("title", "Descargar balance de Extracción Maderable registrado");

            ManPOA.ItemBExt.columns = [
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExt.cellEdit },
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExt.cellDel },
                { data: "NRO", visible: true },
                { data: "ESPECIES", visible: true },
                { data: "ESPECIES_SERFOR", visible: true },
                { data: "DMC", visible: true },
                { data: "TOTAL_ARBOLES", visible: true },
                { data: "VOLUMEN_AUTORIZADO", visible: true },
                { data: "VOLUMEN_MOVILIZADO", visible: true },
                { data: "AUTORIZADO", visible: false },
                { data: "EXTRAIDO", visible: false },
                { data: "FECHA1", visible: false },
                { data: "GUIA_TRANSPORTE", visible: false },
                { data: "FECHA2", visible: false },
                { data: "RECIBO", visible: false },
                { data: "SALDO", visible: true },
                { data: "CANTIDAD", visible: false },
                { data: "UNIDAD_MEDIDA", visible: true },
                { data: "OBSERVACION", visible: true },
                { data: "TIPOMADERABLE", visible: true },
                { data: "COD_ESPECIES", visible: false },
                { data: "COD_ESPECIES_SERFOR", visible: false },
                { data: "RegEstado", visible: false },
                { data: "index", visible: false },
                { data: "COD_SECUENCIAL", visible: false }
            ];
        }
        else if (
            (hdfItemEstadoOrigen == "PN" && hdfItemIndicador == "NM") ||
            (hdfItemEstadoOrigen == "PCN")
        ) {
            ManPOA.frmPOARegistro.find("#txtgrvItemBExt").html("Balance de Extracción o Kardex del POA (No Maderable)");
            ManPOA.frmPOARegistro.find("#totalMaderable").hide();
            ManPOA.frmPOARegistro.find("#btnDownloadBExtMadNoMad").attr("title", "Descargar balance de Extracción No Maderable registrado");

            if (hdfItemCod_MTipo == "0000021") {
                ManPOA.frmPOARegistro.find("#btnExcelBExtPMed").show();

                ManPOA.ItemBExt.columns = [
                    { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExt.cellEdit },
                    { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExt.cellDel },
                    { data: "NRO", visible: true },
                    { data: "ESPECIES", visible: true },
                    { data: "ESPECIES_SERFOR", visible: true },
                    { data: "DMC", visible: false },
                    { data: "TOTAL_ARBOLES", visible: false },
                    { data: "VOLUMEN_AUTORIZADO", visible: false },
                    { data: "VOLUMEN_MOVILIZADO", visible: false },
                    { data: "AUTORIZADO", visible: true },
                    { data: "EXTRAIDO", visible: true },
                    { data: "FECHA1", visible: false },
                    { data: "GUIA_TRANSPORTE", visible: false },
                    { data: "FECHA2", visible: false },
                    { data: "RECIBO", visible: false },
                    { data: "SALDO", visible: true },
                    { data: "CANTIDAD", visible: false },
                    { data: "UNIDAD_MEDIDA", visible: true },
                    { data: "OBSERVACION", visible: true },
                    { data: "TIPOMADERABLE", visible: false },
                    { data: "COD_ESPECIES", visible: false },
                    { data: "COD_ESPECIES_SERFOR", visible: false },
                    { data: "RegEstado", visible: false },
                    { data: "index", visible: false },
                    { data: "COD_SECUENCIAL", visible: false }
                ];
            }
            else if (hdfItemCod_MTipo == "0000020") {
                ManPOA.frmPOARegistro.find("#btnExcelBExtCarr").show();

                ManPOA.ItemBExt.columns = [
                    { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExt.cellEdit },
                    { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExt.cellDel },
                    { data: "NRO", visible: true },
                    { data: "ESPECIES", visible: true },
                    { data: "ESPECIES_SERFOR", visible: true },
                    { data: "DMC", visible: false },
                    { data: "TOTAL_ARBOLES", visible: false },
                    { data: "VOLUMEN_AUTORIZADO", visible: false },
                    { data: "VOLUMEN_MOVILIZADO", visible: false },
                    { data: "AUTORIZADO", visible: false },
                    { data: "EXTRAIDO", visible: false },
                    { data: "FECHA1", visible: true },
                    { data: "GUIA_TRANSPORTE", visible: true },
                    { data: "FECHA2", visible: true },
                    { data: "RECIBO", visible: true },
                    { data: "SALDO", visible: true },
                    { data: "CANTIDAD", visible: true },
                    { data: "UNIDAD_MEDIDA", visible: false },
                    { data: "OBSERVACION", visible: true },
                    { data: "TIPOMADERABLE", visible: false },
                    { data: "COD_ESPECIES", visible: false },
                    { data: "COD_ESPECIES_SERFOR", visible: false },
                    { data: "RegEstado", visible: false },
                    { data: "index", visible: false },
                    { data: "COD_SECUENCIAL", visible: false }
                ];
            }
            else {
                ManPOA.frmPOARegistro.find("#btnExcelBExtNormal").show();

                ManPOA.ItemBExt.columns = [
                    { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExt.cellEdit },
                    { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExt.cellDel },
                    { data: "NRO", visible: true },
                    { data: "ESPECIES", visible: true },
                    { data: "ESPECIES_SERFOR", visible: true },
                    { data: "DMC", visible: false },
                    { data: "TOTAL_ARBOLES", visible: false },
                    { data: "VOLUMEN_AUTORIZADO", visible: true },
                    { data: "VOLUMEN_MOVILIZADO", visible: true },
                    { data: "AUTORIZADO", visible: false },
                    { data: "EXTRAIDO", visible: false },
                    { data: "FECHA1", visible: false },
                    { data: "GUIA_TRANSPORTE", visible: false },
                    { data: "FECHA2", visible: false },
                    { data: "RECIBO", visible: false },
                    { data: "SALDO", visible: true },
                    { data: "CANTIDAD", visible: false },
                    { data: "UNIDAD_MEDIDA", visible: true },
                    { data: "OBSERVACION", visible: true },
                    { data: "TIPOMADERABLE", visible: false },
                    { data: "COD_ESPECIES", visible: false },
                    { data: "COD_ESPECIES_SERFOR", visible: false },
                    { data: "RegEstado", visible: false },
                    { data: "index", visible: false },
                    { data: "COD_SECUENCIAL", visible: false },
                ];
            }
        }
        else {
            ManPOA.frmPOARegistro.find("#txtgrvItemBExt").html("Balance de Extracción o Kardex del POA (Maderable y No Maderable)");
            ManPOA.frmPOARegistro.find("#btnDownloadBExtMadNoMad").attr("title", "Descargar balance de Extracción Maderable y No Maderable registrado");

            if (hdfItemCod_MTipo == "0000021") {
                ManPOA.frmPOARegistro.find("#btnExcelPMedBExtMadNoMad").show();

                ManPOA.ItemBExt.columns = [
                    { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExt.cellEdit },
                    { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExt.cellDel },
                    { data: "NRO", visible: true },
                    { data: "ESPECIES", visible: true },
                    { data: "ESPECIES_SERFOR", visible: true },
                    { data: "DMC", visible: true },
                    { data: "TOTAL_ARBOLES", visible: true },
                    { data: "VOLUMEN_AUTORIZADO", visible: true },
                    { data: "VOLUMEN_MOVILIZADO", visible: true },
                    { data: "AUTORIZADO", visible: true },
                    { data: "EXTRAIDO", visible: true },
                    { data: "FECHA1", visible: false },
                    { data: "GUIA_TRANSPORTE", visible: false },
                    { data: "FECHA2", visible: false },
                    { data: "RECIBO", visible: false },
                    { data: "SALDO", visible: true },
                    { data: "CANTIDAD", visible: false },
                    { data: "UNIDAD_MEDIDA", visible: true },
                    { data: "OBSERVACION", visible: true },
                    { data: "TIPOMADERABLE", visible: true },
                    { data: "COD_ESPECIES", visible: false },
                    { data: "COD_ESPECIES_SERFOR", visible: false },
                    { data: "RegEstado", visible: false },
                    { data: "index", visible: false },
                    { data: "COD_SECUENCIAL", visible: false }
                ];
            }
            else if (hdfItemCod_MTipo == "0000020") {
                ManPOA.frmPOARegistro.find("#btnExcelCarrBExtMadNoMad").show();

                ManPOA.ItemBExt.columns = [
                    { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExt.cellEdit },
                    { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExt.cellDel },
                    { data: "NRO", visible: true },
                    { data: "ESPECIES", visible: true },
                    { data: "ESPECIES_SERFOR", visible: true },
                    { data: "DMC", visible: true },
                    { data: "TOTAL_ARBOLES", visible: true },
                    { data: "VOLUMEN_AUTORIZADO", visible: true },
                    { data: "VOLUMEN_MOVILIZADO", visible: true },
                    { data: "AUTORIZADO", visible: false },
                    { data: "EXTRAIDO", visible: false },
                    { data: "FECHA1", visible: true },
                    { data: "GUIA_TRANSPORTE", visible: true },
                    { data: "FECHA2", visible: true },
                    { data: "RECIBO", visible: true },
                    { data: "SALDO", visible: true },
                    { data: "CANTIDAD", visible: true },
                    { data: "UNIDAD_MEDIDA", visible: true },
                    { data: "OBSERVACION", visible: true },
                    { data: "TIPOMADERABLE", visible: true },
                    { data: "COD_ESPECIES", visible: false },
                    { data: "COD_ESPECIES_SERFOR", visible: false },
                    { data: "RegEstado", visible: false },
                    { data: "index", visible: false },
                    { data: "COD_SECUENCIAL", visible: false }
                ];
            }
            else {
                ManPOA.frmPOARegistro.find("#btnExcelBExtMadNoMad").show();

                ManPOA.ItemBExt.columns = [
                    { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExt.cellEdit },
                    { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExt.cellDel },
                    { data: "NRO", visible: true },
                    { data: "ESPECIES", visible: true },
                    { data: "ESPECIES_SERFOR", visible: true },
                    { data: "DMC", visible: true },
                    { data: "TOTAL_ARBOLES", visible: true },
                    { data: "VOLUMEN_AUTORIZADO", visible: true },
                    { data: "VOLUMEN_MOVILIZADO", visible: true },
                    { data: "AUTORIZADO", visible: false },
                    { data: "EXTRAIDO", visible: false },
                    { data: "FECHA1", visible: false },
                    { data: "GUIA_TRANSPORTE", visible: false },
                    { data: "FECHA2", visible: false },
                    { data: "RECIBO", visible: false },
                    { data: "SALDO", visible: true },
                    { data: "CANTIDAD", visible: false },
                    { data: "UNIDAD_MEDIDA", visible: true },
                    { data: "OBSERVACION", visible: true },
                    { data: "TIPOMADERABLE", visible: true },
                    { data: "COD_ESPECIES", visible: false },
                    { data: "COD_ESPECIES_SERFOR", visible: false },
                    { data: "RegEstado", visible: false },
                    { data: "index", visible: false },
                    { data: "COD_SECUENCIAL", visible: false }
                ];
            }
        }
    }
    this.seteaNoMadPermisos = function () {
        var codMTipo = ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val();
        if (codMTipo == "0000021") {

            ManPOA.frmPOARegistro.find("#btnExcelRANormal,#btnExcelRAPCarr").hide();
            ManPOA.frmPOARegistro.find("#btnExcelRAPMed").show();

            /*ManPOA.frmPOARegistro.find("#btnExcelRANormal,#btnExcelBExtNormal").hide();
            ManPOA.frmPOARegistro.find("#btnExcelRAPMed,#btnExcelBExtPMed").show();
            ManPOA.frmPOARegistro.find("#btnExcelRAPCarr,#btnExcelBExtCarr").hide();*/

            ManPOA.ItemRAPoa.columns = [
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemRAPoa.cellEdit },
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemRAPoa.cellDel },
                { data: "NRO", visible: true },
                { data: "ESPECIES", visible: true },
                { data: "ESPECIES_SERFOR", visible: true },
                { data: "NUM_ARBOLES", visible: false },
                { data: "VOLUMEN_KILOGRAMOS", visible: false },
                { data: "SuperficieHa", visible: false },
                { data: "CANTIDAD", visible: false },
                { data: "ABUNDANCIA", visible: true },
                { data: "NUMINDIVIDUOS", visible: true },
                { data: "PESO", visible: true },
                { data: "RENDIMIENTO", visible: true },
                { data: "UNIDAD_MEDIDA", visible: true },
                { data: "TIPOMADERABLE", visible: true },
                { data: "PCA", visible: true },
                { data: "OBSERVACION", visible: true },
                { data: "COD_ESPECIES", visible: false },
                { data: "COD_ESPECIES_SERFOR", visible: false },
                { data: "RegEstado", visible: false },
                { data: "COD_SECUENCIAL", visible: false }
            ];
            ManPOA.ItemBExtNoMaderable.columns = [
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExtNoMaderable.cellEdit },
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExtNoMaderable.cellDel },
                { data: "NRO", visible: true },
                { data: "ESPECIES", visible: true },
                { data: "ESPECIES_SERFOR", visible: true },
                { data: "KILOGRAMO_AUTORIZADO", visible: false },
                { data: "KILOGRAMO_MOVILIZADO", visible: false },
                { data: "AUTORIZADO", visible: true },
                { data: "EXTRAIDO", visible: true },
                { data: "FECHA1", visible: false },
                { data: "GUIA_TRANSPORTE", visible: false },
                { data: "FECHA2", visible: false },
                { data: "RECIBO", visible: false },
                { data: "SALDO", visible: true },
                { data: "CANTIDAD", visible: false },
                { data: "UNIDAD_MEDIDA", visible: true },
                { data: "OBSERVACION", visible: true },
                { data: "COD_ESPECIES", visible: false },
                { data: "COD_ESPECIES_SERFOR", visible: false },
                { data: "RegEstado", visible: false },
                { data: "COD_SECUENCIAL", visible: false },
                { data: "index", visible: false }
            ];

        }
        else if (codMTipo == "0000020") {

            ManPOA.frmPOARegistro.find("#btnExcelRAPMed,#btnExcelRANormal").hide();
            ManPOA.frmPOARegistro.find("#btnExcelRAPCarr").show();

            /*ManPOA.frmPOARegistro.find("#btnExcelRAPMed,#btnExcelRANormal").hide();
            ManPOA.frmPOARegistro.find("#btnExcelBExtPMed,#btnExcelBExtNormal").hide();
            ManPOA.frmPOARegistro.find("#btnExcelRAPCarr,#btnExcelBExtCarr").show();*/


            ManPOA.ItemBExtNoMaderable.columns = [
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExtNoMaderable.cellEdit },
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExtNoMaderable.cellDel },
                { data: "NRO", visible: true },
                { data: "ESPECIES", visible: true },
                { data: "ESPECIES_SERFOR", visible: true },
                { data: "KILOGRAMO_AUTORIZADO", visible: false },
                { data: "KILOGRAMO_MOVILIZADO", visible: false },
                { data: "AUTORIZADO", visible: false },
                { data: "EXTRAIDO", visible: false },
                { data: "FECHA1", visible: true },
                { data: "GUIA_TRANSPORTE", visible: true },
                { data: "FECHA2", visible: true },
                { data: "RECIBO", visible: true },
                { data: "SALDO", visible: true },
                { data: "CANTIDAD", visible: true },
                { data: "UNIDAD_MEDIDA", visible: false },
                { data: "OBSERVACION", visible: true },
                { data: "COD_ESPECIES", visible: false },
                { data: "COD_ESPECIES_SERFOR", visible: false },
                { data: "RegEstado", visible: false },
                { data: "COD_SECUENCIAL", visible: false },
                { data: "index", visible: false }

            ];

            ManPOA.ItemRAPoa.columns = [
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemRAPoa.cellEdit },
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemRAPoa.cellDel },
                { data: "NRO", visible: true },
                { data: "ESPECIES", visible: true },
                { data: "ESPECIES_SERFOR", visible: true },
                { data: "NUM_ARBOLES", visible: false },
                { data: "VOLUMEN_KILOGRAMOS", visible: false },
                { data: "SuperficieHa", visible: true },
                { data: "CANTIDAD", visible: true },
                { data: "ABUNDANCIA", visible: false },
                { data: "NUMINDIVIDUOS", visible: false },
                { data: "PESO", visible: false },
                { data: "RENDIMIENTO", visible: false },
                { data: "UNIDAD_MEDIDA", visible: false },
                { data: "TIPOMADERABLE", visible: true },
                { data: "PCA", visible: true },
                { data: "OBSERVACION", visible: true },
                { data: "COD_ESPECIES", visible: false },
                { data: "COD_ESPECIES_SERFOR", visible: false },
                { data: "RegEstado", visible: false },
                { data: "COD_SECUENCIAL", visible: false }
            ];

        }
        else {

            ManPOA.frmPOARegistro.find("#btnExcelRAPMed,#btnExcelRAPCarr").hide();
            ManPOA.frmPOARegistro.find("#btnExcelRANormal").show();

            /*ManPOA.frmPOARegistro.find("#btnExcelRANormal,#btnExcelBExtNormal").show();
            ManPOA.frmPOARegistro.find("#btnExcelRAPMed,#btnExcelBExtPMed").hide();
            ManPOA.frmPOARegistro.find("#btnExcelRAPCarr,#btnExcelBExtCarr").hide();*/

            ManPOA.ItemBExtNoMaderable.columns = [
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExtNoMaderable.cellEdit },
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExtNoMaderable.cellDel },
                { data: "NRO", visible: true },
                { data: "ESPECIES", visible: true },
                { data: "ESPECIES_SERFOR", visible: true },
                { data: "KILOGRAMO_AUTORIZADO", visible: true },
                { data: "KILOGRAMO_MOVILIZADO", visible: true },
                { data: "AUTORIZADO", visible: false },
                { data: "EXTRAIDO", visible: false },
                { data: "FECHA1", visible: false },
                { data: "GUIA_TRANSPORTE", visible: false },
                { data: "FECHA2", visible: false },
                { data: "RECIBO", visible: false },
                { data: "SALDO", visible: true },
                { data: "CANTIDAD", visible: false },
                { data: "UNIDAD_MEDIDA", visible: true },
                { data: "OBSERVACION", visible: true },
                { data: "COD_ESPECIES", visible: false },
                { data: "COD_ESPECIES_SERFOR", visible: false },
                { data: "RegEstado", visible: false },
                { data: "COD_SECUENCIAL", visible: false },
                { data: "index", visible: false }

            ];

            ManPOA.ItemRAPoa.columns = [
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemRAPoa.cellEdit },
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemRAPoa.cellDel },
                { data: "NRO", visible: true },
                { data: "ESPECIES", visible: true },
                { data: "ESPECIES_SERFOR", visible: true },
                { data: "NUM_ARBOLES", visible: true },
                { data: "VOLUMEN_KILOGRAMOS", visible: true },
                { data: "SuperficieHa", visible: false },
                { data: "CANTIDAD", visible: false },
                { data: "ABUNDANCIA", visible: false },
                { data: "NUMINDIVIDUOS", visible: false },
                { data: "PESO", visible: false },
                { data: "RENDIMIENTO", visible: false },
                { data: "UNIDAD_MEDIDA", visible: true },
                { data: "TIPOMADERABLE", visible: true },
                { data: "PCA", visible: true },
                { data: "OBSERVACION", visible: true },
                { data: "COD_ESPECIES", visible: false },
                { data: "COD_ESPECIES_SERFOR", visible: false },
                { data: "RegEstado", visible: false },
                { data: "COD_SECUENCIAL", visible: false }

            ];

        }
    }

    this.plantaMedicinal = function (medicinal) {

        ManPOA.ItemRAPoa.frmResolAprob.find("#trAbundanciaMed").toggle(medicinal);
        ManPOA.ItemRAPoa.frmResolAprob.find("#trNIndividuosMed").toggle(medicinal);
        ManPOA.ItemRAPoa.frmResolAprob.find("#trPesoMed").toggle(medicinal);
        ManPOA.ItemRAPoa.frmResolAprob.find("#trRendimientoMed").toggle(medicinal);
        ManPOA.ItemRAPoa.frmResolAprob.find("#trUnMed").toggle(medicinal);


        ManPOA.ItemBExtNoMaderable.frmBExtNoMaderable.find("#trExtraidoBalance").toggle(medicinal);
        ManPOA.ItemBExtNoMaderable.frmBExtNoMaderable.find("#trAutorizadoBalance").toggle(medicinal);
        //ManPOA.ItemBExtNoMaderable.frmBExtNoMaderable.find("#trUnidadMedidaBalance").toggle(medicinal);
        ManPOA.ItemBExtNoMaderable.frmBExtNoMaderable.find("#txtItemBExtUnidadMedida").attr("disabled", true);
    }

    this.ocultarCarrizo = function (carrizo) {

        //para el modal de agregar carrizos
        ManPOA.ItemRAPoa.frmResolAprob.find("#trSuperficieHa").toggle(carrizo);
        ManPOA.ItemRAPoa.frmResolAprob.find("#trCandidad").toggle(carrizo);

        ManPOA.ItemBExtNoMaderable.frmBExtNoMaderable.find("#trCarrizoFecha").toggle(carrizo);
        ManPOA.ItemBExtNoMaderable.frmBExtNoMaderable.find("#trCarrizoGTF").toggle(carrizo);
        ManPOA.ItemBExtNoMaderable.frmBExtNoMaderable.find("#trCarrizoFecha2").toggle(carrizo);
        ManPOA.ItemBExtNoMaderable.frmBExtNoMaderable.find("#trCarrizoRecibo").toggle(carrizo);
        ManPOA.ItemBExtNoMaderable.frmBExtNoMaderable.find("#trCarrizoCantidad").toggle(carrizo);

    }

    this.validaSave = function () {

        if (this.frmPOARegistro.find("#ddlItemIndicador").val() == '0000000') {
            utilSigo.toastError("Error", "Debe seleccionar la situación actual de su registro");
            return false;
        }
        if (this.frmPOARegistro.find("#ddlODRegistro").val() == '0000000') {
            utilSigo.toastError("Error", "Debe seleccionar la O.D. desde donde se registra la información");
            return false;
        }
        var EstadoOrigen = this.frmPOARegistro.find("#hdfItemEstadoOrigen").val();

        if (EstadoOrigen == "PN" || EstadoOrigen == "FI") {
            var txtItemNumPOA = this.frmPOARegistro.find("#txtItemNumPOA").val();
            if ((txtItemNumPOA == "0" || txtItemNumPOA == "") &&
                !this.frmPOARegistro.find("#chkNPNumPOA").is(":checked")
            ) {
                utilSigo.toastError("Error", "Ingrese Número de POA");
                this.frmPOARegistro.find("#txtItemNumPOA").focus();
                return false;
            }
        }
        else if (EstadoOrigen == "PC") {
            var txtItemNumPComplementario = this.frmPOARegistro.find("#txtItemNumPComplementario").val();
            if (txtItemNumPComplementario == "0" || txtItemNumPComplementario == "") {
                utilSigo.toastError("Error", "Ingrese Número de POA Complementario");
                this.frmPOARegistro.find("#txtItemNumPComplementario").focus();
                return false;
            }
        }
        return true;
    }
    this.getListAOCULAR = function () {
        var list = [];
        this.dtItemAOcular.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            if (row.RegEstado == 1 || row.RegEstado == 2) {
                list.push({
                    PERSONA: row.PERSONA,
                    N_DOCUMENTO: row.N_DOCUMENTO,
                    //CARGO: row.CARGO,
                    COD_PTIPO: row.COD_PTIPO,
                    COD_PERSONA: row.COD_PERSONA,
                    RegEstado: row.RegEstado
                });
            }

        });
        return list;
    }
    this.getListTIOCULAR = function () {
        var ListTIOCULAR = [];
        this.dtItemIOcular.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            if (row.RegEstado == 1 || row.RegEstado == 2) {
                ListTIOCULAR.push({
                    PERSONA: row.PERSONA,
                    N_DOCUMENTO: row.N_DOCUMENTO,
                    //CARGO: row.CARGO,
                    COD_PTIPO: row.COD_PTIPO,
                    COD_PERSONA: row.COD_PERSONA,
                    RegEstado: row.RegEstado
                });
            }
        });
        return ListTIOCULAR;
    }
    this.getListTRAPROBACION = function () {
        var ListTRAPROBACION = [];
        this.dtItemTRAprobacion.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            if (row.RegEstado == 1 || row.RegEstado == 2) {
                ListTRAPROBACION.push({
                    PERSONA: row.PERSONA,
                    N_DOCUMENTO: row.N_DOCUMENTO,
                    //CARGO: row.CARGO,
                    COD_PTIPO: row.COD_PTIPO,
                    COD_PERSONA: row.COD_PERSONA,
                    RegEstado: row.RegEstado
                });
            }
        });
        return ListTRAPROBACION;
    }
    this.getListRAprueba = function () {
        var list = [];
        this.ItemRAPoa.dtItemRAPoa.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();

            if (row.RegEstado == 1 || row.RegEstado == 2) {
                list.push({
                    ESPECIES: row.ESPECIES,
                    ESPECIES_SERFOR: row.ESPECIES_SERFOR,
                    NUM_ARBOLES: row.NUM_ARBOLES,
                    VOLUMEN_KILOGRAMOS: row.VOLUMEN_KILOGRAMOS,
                    SuperficieHa: row.SuperficieHa,
                    CANTIDAD: row.CANTIDAD,
                    ABUNDANCIA: row.ABUNDANCIA,
                    NUMINDIVIDUOS: row.NUMINDIVIDUOS,
                    PESO: row.PESO,
                    RENDIMIENTO: row.RENDIMIENTO,
                    UNIDAD_MEDIDA: row.UNIDAD_MEDIDA,
                    TIPOMADERABLE: row.TIPOMADERABLE,
                    OBSERVACION: row.OBSERVACION,
                    COD_ESPECIES: row.COD_ESPECIES,
                    COD_ESPECIES_SERFOR: row.COD_ESPECIES_SERFOR,
                    COD_SECUENCIAL: row.COD_SECUENCIAL,
                    PCA: row.PCA,
                    RegEstado: row.RegEstado
                });
            }
        });
        return list;
    }
    this.getListRApruebaISitu = function () {
        var list = [];
        ManPOA.ItemRAPoaInSitu.dtItemRAPoaInSitu.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            if (row.RegEstado == 1 || row.RegEstado == 2) {
                list.push({
                    ESPECIES: row.ESPECIES,
                    ESPECIES_SERFOR: row.ESPECIES_SERFOR,
                    PERIODO: row.PERIODO,
                    CUOTA_SACA: row.CUOTA_SACA,
                    METODO_CAZA: row.METODO_CAZA,
                    SISTEMA_MARCAJE: row.SISTEMA_MARCAJE,
                    DENSIDAD: row.DENSIDAD,
                    OBSERVACION: row.OBSERVACION,
                    COD_ESPECIES: row.COD_ESPECIES,
                    COD_ESPECIES_SERFOR: row.COD_ESPECIES_SERFOR,
                    COD_SECUENCIAL: row.COD_SECUENCIAL,
                    RegEstado: row.RegEstado
                });
            }
        });
        return list;
    }

    this.getListVERTICE = function () {

        var list = [];
        var $tbItemVerticeMod = $('#grvItemVertice').dataTable();
        var $rows = $tbItemVerticeMod.$("tr");

        var countFilas = $rows.length;
        if (countFilas > 0) {
            $.each($rows, function (i, o) {

                var estadoItemReg = $(o).find(".hdEstadoItemGen").val();
                var codSecuencial = $(o).find(".hdCodSecuencial").val();
                var columnasFila = $(o).find('td');
                if (estadoItemReg == 1 || estadoItemReg == 2) {
                    list.push({
                        VERTICE: columnasFila.eq(3).text(),
                        ZONA: columnasFila.eq(4).text(),
                        COORDENADA_ESTE: columnasFila.eq(5).text(),
                        COORDENADA_NORTE: columnasFila.eq(6).text(),
                        OBSERVACION: columnasFila.eq(8).text(),
                        COD_SECUENCIAL: codSecuencial,
                        PCA: columnasFila.eq(7).text(),
                        RegEstado: estadoItemReg
                    });
                }
            });
        }

        return list;
    }
    this.getListMadeCENSO = function () {
        var list = [];
        ManPOA.ItemCMaderable.dtItemCMaderable.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            if (row.RegEstado == 1 || row.RegEstado == 2) {
                list.push({
                    ESPECIES: row.ESPECIES,
                    ESPECIES_ARESOLUCION: row.ESPECIES_ARESOLUCION,
                    BLOQUE: row.BLOQUE,
                    FAJA: row.FAJA,
                    CODIGO: row.CODIGO,
                    VOLUMEN: row.VOLUMEN,
                    DAP: row.DAP,
                    AC: row.AC,
                    DMC: row.DMC,
                    ZONA: row.ZONA,
                    COORDENADA_ESTE: row.COORDENADA_ESTE,
                    COORDENADA_NORTE: row.COORDENADA_NORTE,
                    CONDICION: row.CONDICION,
                    ESTADO: row.ESTADO,
                    PCA: row.PCA,
                    OBSERVACION: row.OBSERVACION,
                    COD_ESPECIES: row.COD_ESPECIES,
                    COD_ESPECIES_ARESOLUCION: row.COD_ESPECIES_ARESOLUCION,
                    COD_ECONDICION: row.COD_ECONDICION,
                    COD_EESTADO: row.COD_EESTADO,
                    RegEstado: row.RegEstado,
                    COD_SECUENCIAL: row.COD_SECUENCIAL
                });
            }
        });
        return list;
    }
    this.getListNoMadeCENSO = function () {
        var list = [];
        ManPOA.ItemCNoMaderable.dtItemCNoMaderable.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            if (row.RegEstado == 1 || row.RegEstado == 2) {
                list.push({
                    ESPECIES: row.ESPECIES,
                    ESPECIES_ARESOLUCION: row.ESPECIES_ARESOLUCION,
                    NUM_ESTRADA: row.NUM_ESTRADA,
                    CODIGO: row.CODIGO,
                    DIAMETRO: row.DIAMETRO,
                    ALTURA: row.ALTURA,
                    PRODUCCION_LATAS: row.PRODUCCION_LATAS,
                    ZONA: row.ZONA,
                    COORDENADA_ESTE: row.COORDENADA_ESTE,
                    COORDENADA_NORTE: row.COORDENADA_NORTE,
                    CONDICION: row.CONDICION,
                    OBSERVACION: row.OBSERVACION,
                    COD_ESPECIES: row.COD_ESPECIES,
                    COD_ESPECIES_ARESOLUCION: row.COD_ESPECIES_ARESOLUCION,
                    COD_ECONDICION: row.COD_ECONDICION,
                    RegEstado: row.RegEstado,
                    COD_SECUENCIAL: row.COD_SECUENCIAL
                });
            }
        });
        return list;
    }
    this.getListBExtPOA = function () {
        var list = [];
        for (var i = 0; i < ManPOA.listBExtPOA.length; i++) {

            list.push({
                BEXTRACCION_FEMISION: ManPOA.listBExtPOA[i].BEXTRACCION_FEMISION,
                COD_SECUENCIAL: ManPOA.listBExtPOA[i].COD_SECUENCIAL,
                RegEstado: ManPOA.listBExtPOA[i].RegEstado,
                ListMadeBEXTRACCION: [],
                ListNoMadeBEXTRACCION: [],
                ListISituBEXTRACCION: []
            });
            if (ManPOA.listBExtPOA[i].listMadeBEXTRACCION != null) {
                for (var j = 0; j < ManPOA.listBExtPOA[i].listMadeBEXTRACCION.length; j++) {
                    if (ManPOA.listBExtPOA[i].listMadeBEXTRACCION[j].RegEstado == 1 ||
                        ManPOA.listBExtPOA[i].listMadeBEXTRACCION[j].RegEstado == 2
                    ) {

                        list[i].ListMadeBEXTRACCION.push(ManPOA.listBExtPOA[i].listMadeBEXTRACCION[j]);
                    }
                }
            }
            if (ManPOA.listBExtPOA[i].ListNoMadeBEXTRACCION != null) {
                for (var j = 0; j < ManPOA.listBExtPOA[i].ListNoMadeBEXTRACCION.length; j++) {
                    if (ManPOA.listBExtPOA[i].ListNoMadeBEXTRACCION[j].RegEstado == 1 ||
                        ManPOA.listBExtPOA[i].ListNoMadeBEXTRACCION[j].RegEstado == 2
                    ) {
                        list[i].ListNoMadeBEXTRACCION.push(ManPOA.listBExtPOA[i].ListNoMadeBEXTRACCION[j]);
                    }
                }
            }
            if (ManPOA.listBExtPOA[i].ListISituBEXTRACCION != null) {
                for (var j = 0; j < ManPOA.listBExtPOA[i].ListISituBEXTRACCION.length; j++) {
                    if (ManPOA.listBExtPOA[i].ListISituBEXTRACCION[j].RegEstado == 1 ||
                        ManPOA.listBExtPOA[i].ListISituBEXTRACCION[j].RegEstado == 2
                    ) {
                        list[i].ListISituBEXTRACCION.push(ManPOA.listBExtPOA[i].ListISituBEXTRACCION[j]);
                    }
                }
            }

        }

        return list;
    }
    this.getListKARDEX = function () {
        var list = [];
        ManPOA.Itemkardex.dtItemkardex.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
            if (row.RegEstado == 1 || row.RegEstado == 2) {
                list.push({
                    ESPECIES: row.ESPECIES,
                    FECHA_EMISIONKARDEX: row.FECHA_EMISIONKARDEX,
                    GUIA_TRANSPORTE: row.GUIA_TRANSPORTE,
                    PRODUCTO: row.PRODUCTO,
                    DESCRIPCION_KARDEX: row.DESCRIPCION_KARDEX,
                    CANTIDAD: row.CANTIDAD,
                    KILOGRAMOS_KARDEX: row.KILOGRAMOS_KARDEX,
                    M3: row.M3,
                    ACUMULADO: row.ACUMULADO,
                    SALDO_KARDEX: row.SALDO_KARDEX,
                    OBSERVACION_KARDEX: row.OBSERVACION_KARDEX,
                    COD_ESPECIES: row.COD_ESPECIES,
                    COD_KARDEX_PRODUCTO: row.COD_KARDEX_PRODUCTO,
                    COD_KARDEX_DESCRIPCION: row.COD_KARDEX_DESCRIPCION,
                    COD_SECUENCIAL: row.COD_SECUENCIAL,
                    RegEstado: row.RegEstado
                });
            }
        });
        return list;
    }


    this.setListIdsSelectCheck = function (lista, listaIds) {
        var chkTema;
        var selectTema = "";
        for (var i = 1; i <= ManPOA.frmPOARegistro.find("[id*=" + lista + "]").length; i++) {

            if (i % 2 == 0) {
                chkTema = ManPOA.frmPOARegistro.find("[id*=" + lista + "]")[i - 1].checked;
                if (chkTema) {
                    selectTema += selectTema == "" ? "" : ",";
                    selectTema += ManPOA.frmPOARegistro.find("[id*=" + lista + "]")[i - 2].value;
                }
            }
        }
        //console.log(selectTema);
        ManPOA.frmPOARegistro.find("#" + listaIds).val(selectTema);
    }

    this.fnAddErrorMaterial = function (tipo) {
        var url = urlLocalSigo + "THabilitante/ManPOA/_ErrorMaterial";
        var option = { url: url, type: 'POST', datos: {}, divId: "modalAddErrorMaterial" };

        utilSigo.fnOpenModal(option, function () {
            _ErrorMaterial.fnCloseModal = function () {
                $("#modalAddErrorMaterial").modal('hide');
            };

            _ErrorMaterial.fnSaveForm = function (data) {
                if (data != null) {
                    var dt;
                    switch (tipo) {
                        case 'DG':
                            dt = ManPOA.dtErrorMaterial_DGeneral;
                            break;
                        case 'DA':
                            dt = ManPOA.dtErrorMaterial_DAdicional;
                            break;
                    }

                    dt.order([1, 'desc']).draw();
                    dt.rows.add([data]).draw();
                    dt.page('last').draw('page');
                    $("#modalAddErrorMaterial").modal('hide');
                } else {
                    utilSigo.toastSuccess("Error", "No se pudieron guardar los datos");
                }
            };

            _ErrorMaterial.fnInit(tipo);
        });
    }
    this.fnAddRegenteImplementa = function (tipo) {
        var url = urlLocalSigo + "THabilitante/ManPOA/_DetRegente";
        var option = { url: url, type: 'POST', datos: {}, divId: "modalAddDetRegente" };

        utilSigo.fnOpenModal(option, function () {
            _DetRegente.fnCloseModal = function () {
                $("#modalAddDetRegente").modal('hide');
            };

            _DetRegente.fnSaveForm = function (data) {
                if (data != null) {
                    var dt;
                    switch (tipo) {
                        case 'DG':
                            dt = ManPOA.drRegente_Implementa;
                            break;
                    }

                    dt.order([1, 'desc']).draw();
                    dt.rows.add([data]).draw();
                    dt.page('last').draw('page');
                    $("#modalAddDetRegente").modal('hide');
                } else {
                    utilSigo.toastSuccess("Error", "No se pudieron guardar los datos");
                }
            };

            _DetRegente.fnInit(tipo);
        });
    }
    this.fnGetListRegenteimplementa = function (tipo) {
        var dt, list = [], rows, countFilas, data;

        switch (tipo) {
            case 'DG':
                dt = ManPOA.dtRegente_Implementa;
                break;
        }

        rows = dt.$("tr");
        countFilas = rows.length;
        if (countFilas > 0) {
            $.each(rows, function (i, o) {
                data = dt.row($(o)).data();
                list.push(utilSigo.fnConvertArrayToObject(data));
            });
        }

        return list;
    }
    this.fnGetListErrorMaterial = function (tipo) {
        var dt, list = [], rows, countFilas, data;

        switch (tipo) {
            case 'DG':
                dt = ManPOA.dtErrorMaterial_DGeneral;
                break;
            case 'DA':
                dt = ManPOA.dtErrorMaterial_DAdicional;
                break;
        }

        rows = dt.$("tr");
        countFilas = rows.length;
        if (countFilas > 0) {
            $.each(rows, function (i, o) {
                data = dt.row($(o)).data();
                list.push(utilSigo.fnConvertArrayToObject(data));
            });
        }

        return list;
    }

    this.save = function () {

        this.setListIdsSelectCheck("lstChkDETitulo", "lstChkDETituloId");
        this.setListIdsSelectCheck("lstDEResoluciones", "lstDEResolucionesId");
        this.setListIdsSelectCheck("lstDEDocumentoGestion", "lstDEDocumentoGestionId");
        this.setListIdsSelectCheck("lstDEObligaciones", "lstDEObligacionesId");
        this.setListIdsSelectCheck("lstDEEjecucion", "lstDEEjecucionId");
        this.setListIdsSelectCheck("lstDEOtros", "lstDEOtrosId");


        var datosPOA = ManPOA.frmPOARegistro.serializeObject();
        //datos de ListTIOCULAR  
        if (ManPOA.dtItemIOcular != undefined) {
            datosPOA.ListTIOCULAR = ManPOA.getListTIOCULAR();
        }
        //datos de ListTRAPROBACION
        if (ManPOA.dtItemTRAprobacion != undefined) {
            datosPOA.ListTRAPROBACION = ManPOA.getListTRAPROBACION();
        }
        //datos de ListRAprueba
        if (ManPOA.ItemRAPoa.dtItemRAPoa != undefined) {
            datosPOA.ListRAprueba = ManPOA.getListRAprueba();
        }
        //datos de ListRApruebaISitu
        if (ManPOA.ItemRAPoaInSitu.dtItemRAPoaInSitu != undefined) {
            datosPOA.ListRApruebaISitu = ManPOA.getListRApruebaISitu();
        }

        //datos de ListAOCULAR
        if (ManPOA.dtItemAOcular != undefined) {
            datosPOA.ListAOCULAR = ManPOA.getListAOCULAR();
        }
        //datos de ListVERTICE
        if (ManPOA.dtItemVertice != undefined) {

            datosPOA.ListVERTICE = ManPOA.getListVERTICE();
        }
        //datos de ListMadeCENSO
        if (ManPOA.ItemCMaderable.dtItemCMaderable != undefined) {
            //comentado por error de los mas de 6mil registros
            datosPOA.ListMadeCENSO = ManPOA.getListMadeCENSO();
        }
        //datos de ListNoMadeCENSO
        if (ManPOA.ItemCNoMaderable.dtItemCNoMaderable != undefined) {
            datosPOA.ListNoMadeCENSO = ManPOA.getListNoMadeCENSO();
        }
        if (ManPOA.listBExtPOA != undefined) {
            datosPOA.ListBExtPOA = ManPOA.getListBExtPOA();
        }
        //Datos Regente que implementa
        if (ManPOA.dtRegente_Implementa != undefined) {
            datosPOA.ListPOARegenteImplementa = ManPOA.fnGetListRegenteimplementa('DG');
        }
            //datos Error Material

            if (ManPOA.dtErrorMaterial_DGeneral != undefined) {
                datosPOA.ListPOAErrorMaterialG = ManPOA.fnGetListErrorMaterial('DG');
            }
            if (ManPOA.dtErrorMaterial_DAdicional != undefined) {
                datosPOA.ListPOAErrorMaterialA = ManPOA.fnGetListErrorMaterial('DA');
            }

            if (ManPOA.Itemkardex.dtItemkardex != undefined) {
                datosPOA.ListKARDEX = ManPOA.getListKARDEX();
            }

            if (ManPOA.ListEliTABLA != undefined) {
                datosPOA.ListEliTABLA = ManPOA.ListEliTABLA;
            }
            if (ManPOA.frmPOARegistro.find("#ddlItemIndicadorId").val() == "0000007") {
                datosPOA.txtControlCalidadObservaciones = CKEDITOR.instances["txtControlCalidadObservaciones"].getData();
            }

            var check = $("#chckSinInspOcu");
            var state = check.is(":checked");
            datosPOA.chckSinInspOcu = state;

            check = $("#chkItemCuentaFinZafra");
            state = check.is(":checked");
            datosPOA.chkItemCuentaFinZafra = state;

            check = $("#chkItemObsSubsanada");
            state = check.is(":checked");
            datosPOA.chkItemObsSubsanada = state;

            check = $("#chkNPNumPOA");
            state = check.is(":checked");
            datosPOA.chkNPNumPOA = state;

            check = $("#chkPOAPO");
            state = check.is(":checked");
            datosPOA.chkPOAPO = state;

            check = $("#chkIncluyeCD");
            state = check.is(":checked");
            datosPOA.chkIncluyeCD = state;

            check = $("#chkConcluido");
            state = check.is(":checked");
            datosPOA.chkConcluido = state;

            check = $("#chkProceso");
            state = check.is(":checked");
            datosPOA.chkProceso = state;

            check = $("#chkPendiente");
            state = check.is(":checked");
            datosPOA.chkPendiente = state;

            datosPOA.ListParcela = _frmParcela.fnGetList();
            datosPOA.ListEliTABLAParcela = _frmParcela.tbEliTABLA;

            datosPOA.txtDirecion = $("#txtDirecion").val();


            //Mejora SIADO CENSO
            debugger
            if (ManPOA.getParameterByName('siado') == '1') {
                datosPOA.appClient = ManPOA.getParameterByName('appClientGAER');
                datosPOA.appData = ManPOA.getParameterByName('appDataGAER');
            }

            //enviando datos al servidor
            $.ajax({
                url: ManPOA.controller + "/RegistrarPOA",
                type: 'POST',
                data: JSON.stringify(datosPOA),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                //beforeSend: utilSigo.beforeSendAjax,
                //complete: utilSigo.completeAjax,
                error: utilSigo.errorAjax,
                success: function (data) {
                    if (data.success) {
                        if (ManPOA.frmPOARegistro.find("#opRegresar").val() == 0 && ManPOA.getParameterByName('siado') != '1') {
                            ManPOA.regresar(data.msj, '');
                        } else {
                            ManPOA.regresar('', data.appServer);
                        }
                    }
                    else {
                        if (ManPOA.frmPOARegistro.find("#opRegresar").val() == 0 && ManPOA.getParameterByName('siado') != '1') {
                            utilSigo.toastWarning("Aviso", data.msj);
                        } else {
                            ManPOA.regresar('', data.appServer);
                        }
                    }
                }

            });
        }
        this.regresar = function (msj, appServer) {
            debugger
            if (ManPOA.frmPOARegistro.find("#opRegresar").val() === '0' && ManPOA.getParameterByName('siado') != '1') {
                let tipoFormulario = $("#TipoFormulario").val();
                let numrpta = 0;
                if (tipoFormulario === "POA") numrpta = 1;
                else if (tipoFormulario === "PMFI") numrpta = 3;
                else numrpta = 2;
                let url = ManPOA.controller + "/Index?lstManMenu=" + numrpta + "&_alertaIncial=" + msj;
                window.location = url;
            } else {

                var appClient = ManPOA.getParameterByName('siado') != '1' ? ManPOA.frmPOARegistro.find("#appClient").val() : ManPOA.getParameterByName('appClientGAER');
                var appData = ManPOA.getParameterByName('siado') != '1' ? ManPOA.frmPOARegistro.find("#appData").val() : ManPOA.getParameterByName('appDataGAER');
                let url = urlLocalSigo + "THabilitante/ManVentanillaAntecedentesExpedientes/Index?appClient=" + appClient + "&appData=" + appData + "&appServer=" + appServer;
                window.location = url;
            }
        }
        this.getParameterByName = function (name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }
    }).apply(ManPOA);
//RaPOA
(function () {
    this.dtItemRAPoa;
    this.columns;
    this.frmResolAprob;
    this.tr;
    this.init = function () {
        var hdfItemCod_MTipo = ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val();
        var hdfItemIndicador = ManPOA.frmPOARegistro.find("#hdfItemIndicador").val();


        this.dtItemRAPoa = ManPOA.frmPOARegistro.find("#grvItemRAPoa").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bInfo: false,
            bLengthChange: false,
            scrollCollapse: true,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            ajax: {
                url: ManPOA.controller + "/GetAllListRAprueba",
                type: "GET",
                datatype: "json"
            },
            columns: ManPOA.ItemRAPoa.columns
        });


        // Total over all pages
        var columnas;

        if (hdfItemCod_MTipo == "0000021") {
            columnas = [9, 10, 11, 12, 13];
        }
        else if (hdfItemCod_MTipo == "0000020") {
            columnas = [7, 8];
        }
        else {
            columnas = [5, 6];
        }
        if (hdfItemCod_MTipo != "0000021" && hdfItemCod_MTipo != "0000020") {
            //$(this.dtItemRAPoa.column(6).header()).text((hdfItemIndicador == "M" ? "Volumen (m³)" : "Kilogramos"));
            //$(this.dtItemRAPoa.column(6).header()).text((hdfItemIndicador == "M" ? "Cantidad" : "Kilogramos"));
            //if (hdfItemIndicador == "M") $(this.dtItemRAPoa.column(13).header()).text("UM");
            $(this.dtItemRAPoa.column(13).header()).text("UM");
        }

        this.frmResolAprob
            .find('#ddlItemRAPoaEspeciesId').select2();
        this.frmResolAprob
            .find('#ddlItemRAPoaEspecies_SerforId').select2();

        ManPOA.frmPOARegistro.find("#totalPOAMaderable").hide();
        ManPOA.frmPOARegistro.find("#totalPOACarbon").hide();
        ManPOA.frmPOARegistro.find("#totalPOANoMaderable").hide();

        this.dtItemRAPoa.on("draw", function () {//Llama a la función cuando los datos de la tabla se terminan de dibujar
            ManPOA.ItemRAPoa.CalculaPOA(hdfItemCod_MTipo);
        });
    }
    this.CalculaPOA = function (codmtipo) {
        //Tipo de Aprovechamiento: Maderable
        ManPOA.frmPOARegistro.find("#colPOAM5").text("Total (MADERABLES)");
        ManPOA.frmPOARegistro.find("#colPOAM6").text(0);
        ManPOA.frmPOARegistro.find("#colPOAM7").text(0);
        ManPOA.frmPOARegistro.find("#colPOAM8").text(0);
        ManPOA.frmPOARegistro.find("#colPOAM9").text(0);
        ManPOA.frmPOARegistro.find("#colPOAM10").text(0);
        ManPOA.frmPOARegistro.find("#colPOAM11").text(0);
        ManPOA.frmPOARegistro.find("#colPOAM12").text(0);
        ManPOA.frmPOARegistro.find("#colPOAM13").text(0);
        //Tipo de Aprovechamiento: Carbón
        ManPOA.frmPOARegistro.find("#colPOAC5").text("Total (CARBON)");
        ManPOA.frmPOARegistro.find("#colPOAC6").text(0);
        ManPOA.frmPOARegistro.find("#colPOAC7").text(0);
        ManPOA.frmPOARegistro.find("#colPOAC8").text(0);
        ManPOA.frmPOARegistro.find("#colPOAC9").text(0);
        ManPOA.frmPOARegistro.find("#colPOAC10").text(0);
        ManPOA.frmPOARegistro.find("#colPOAC11").text(0);
        ManPOA.frmPOARegistro.find("#colPOAC12").text(0);
        ManPOA.frmPOARegistro.find("#colPOAC13").text(0);
        //Tipo de Aprovechamiento: No Maderable
        ManPOA.frmPOARegistro.find("#colPOANoM5").text("Total (NO MADERABLES)");
        ManPOA.frmPOARegistro.find("#colPOANoM6").text(0);
        ManPOA.frmPOARegistro.find("#colPOANoM7").text(0);
        ManPOA.frmPOARegistro.find("#colPOANoM8").text(0);
        ManPOA.frmPOARegistro.find("#colPOANoM9").text(0);
        ManPOA.frmPOARegistro.find("#colPOANoM10").text(0);
        ManPOA.frmPOARegistro.find("#colPOANoM11").text(0);
        ManPOA.frmPOARegistro.find("#colPOANoM12").text(0);
        ManPOA.frmPOARegistro.find("#colPOANoM13").text(0);

        var cM6 = 0, cM7 = 0, cM8 = 0, cM9 = 0, cM10 = 0, cM11 = 0, cM12 = 0, cM13 = 0;
        var cC6 = 0, cC7 = 0, cC8 = 0, cC9 = 0, cC10 = 0, cC11 = 0, cC12 = 0, cC13 = 0;
        var cNoM6 = 0, cNoM7 = 0, cNoM8 = 0, cNoM9 = 0, cNoM10 = 0, cNoM11 = 0, cNoM12 = 0, cNoM13 = 0;
        var contM = 0, contC = 0, contNoM = 0;

        var $tbdtItemRAPoa = this.dtItemRAPoa.$("tr");

        if ($tbdtItemRAPoa.length > 0) {
            var $tr, row;
            $.each($tbdtItemRAPoa, function (i, o) {
                $tr = $(o).closest('tr');
                row = ManPOA.ItemRAPoa.dtItemRAPoa.row($tr).data();

                if (codmtipo == "0000021") {
                    switch (row.TIPOMADERABLE) {
                        case "MADERABLES":
                            cM10 += parseFloat((row.ABUNDANCIA == "") ? 0 : row.ABUNDANCIA); cM11 += parseFloat((row.NUMINDIVIDUOS == "") ? 0 : row.NUMINDIVIDUOS);
                            cM12 += parseFloat((row.PESO == "") ? 0 : row.PESO); cM13 += parseFloat((row.RENDIMIENTO == "") ? 0 : row.RENDIMIENTO);
                            contM++;
                            break;

                        case "CARBON":
                            cC10 += parseFloat((row.ABUNDANCIA == "") ? 0 : row.ABUNDANCIA); cC11 += parseFloat((row.NUMINDIVIDUOS == "") ? 0 : row.NUMINDIVIDUOS);
                            cC12 += parseFloat((row.PESO == "") ? 0 : row.PESO); cC13 += parseFloat((row.RENDIMIENTO == "") ? 0 : row.RENDIMIENTO);
                            contC++;
                            break;

                        case "NO MADERABLES":
                            cNoM10 += parseFloat((row.ABUNDANCIA == "") ? 0 : row.ABUNDANCIA); cNoM11 += parseFloat((row.NUMINDIVIDUOS == "") ? 0 : row.NUMINDIVIDUOS);
                            cNoM12 += parseFloat((row.PESO == "") ? 0 : row.PESO); cNoM13 += parseFloat((row.RENDIMIENTO == "") ? 0 : row.RENDIMIENTO);
                            contNoM++;
                            break;
                    }
                }
                else if (codmtipo == "0000020") {
                    switch (row.TIPOMADERABLE) {
                        case "MADERABLES":
                            cM8 += parseFloat((row.SuperficieHa == "") ? 0 : row.SuperficieHa); cM9 += parseInt((row.CANTIDAD == "") ? 0 : row.CANTIDAD);
                            contM++;
                            break;

                        case "CARBON":
                            cC8 += parseFloat((row.SuperficieHa == "") ? 0 : row.SuperficieHa); cC9 += parseInt((row.CANTIDAD == "") ? 0 : row.CANTIDAD);
                            contC++;
                            break;

                        case "NO MADERABLES":
                            cNoM8 += parseFloat((row.SuperficieHa == "") ? 0 : row.SuperficieHa); cNoM9 += parseInt((row.CANTIDAD == "") ? 0 : row.CANTIDAD);
                            contNoM++;
                            break;
                    }
                }
                else {
                    switch (row.TIPOMADERABLE) {
                        case "MADERABLES":
                            cM6 += parseInt((row.NUM_ARBOLES == "") ? 0 : row.NUM_ARBOLES); cM7 += parseFloat((row.VOLUMEN_KILOGRAMOS == "") ? 0 : row.VOLUMEN_KILOGRAMOS);
                            contM++;
                            break;

                        case "CARBON":
                            cC6 += parseInt((row.NUM_ARBOLES == "") ? 0 : row.NUM_ARBOLES); cC7 += parseFloat((row.VOLUMEN_KILOGRAMOS == "") ? 0 : row.VOLUMEN_KILOGRAMOS);
                            contC++;
                            break;

                        case "NO MADERABLES":
                            cNoM6 += parseInt((row.NUM_ARBOLES == "") ? 0 : row.NUM_ARBOLES); cNoM7 += parseFloat((row.VOLUMEN_KILOGRAMOS == "") ? 0 : row.VOLUMEN_KILOGRAMOS);
                            contNoM++;
                            break;
                    }
                }
            });

            if (contM > 0) {
                ManPOA.frmPOARegistro.find("#totalPOAMaderable").show();
                ManPOA.frmPOARegistro.find("#colPOAM6").text(cM6);
                ManPOA.frmPOARegistro.find("#colPOAM7").text(this.intlRound(cM7, 3));
                ManPOA.frmPOARegistro.find("#colPOAM8").text(this.intlRound(cM8, 3));
                ManPOA.frmPOARegistro.find("#colPOAM9").text(cM9);
                ManPOA.frmPOARegistro.find("#colPOAM10").text(this.intlRound(cM10, 3));
                ManPOA.frmPOARegistro.find("#colPOAM11").text(this.intlRound(cM11, 3));
                ManPOA.frmPOARegistro.find("#colPOAM12").text(this.intlRound(cM12, 3));
                ManPOA.frmPOARegistro.find("#colPOAM13").text(this.intlRound(cM13, 3));
            }
            else ManPOA.frmPOARegistro.find("#totalPOAMaderable").hide();
            if (contC > 0) {
                ManPOA.frmPOARegistro.find("#totalPOACarbon").show();
                ManPOA.frmPOARegistro.find("#colPOAC6").text(cC6);
                ManPOA.frmPOARegistro.find("#colPOAC7").text(this.intlRound(cC7, 3));
                ManPOA.frmPOARegistro.find("#colPOAC8").text(this.intlRound(cC8, 3));
                ManPOA.frmPOARegistro.find("#colPOAC9").text(cC9);
                ManPOA.frmPOARegistro.find("#colPOAC10").text(this.intlRound(cC10, 3));
                ManPOA.frmPOARegistro.find("#colPOAC11").text(this.intlRound(cC11, 3));
                ManPOA.frmPOARegistro.find("#colPOAC12").text(this.intlRound(cC12, 3));
                ManPOA.frmPOARegistro.find("#colPOAC13").text(this.intlRound(cC13, 3));
            }
            else ManPOA.frmPOARegistro.find("#totalPOACarbon").hide();
            if (contNoM > 0) {
                ManPOA.frmPOARegistro.find("#totalPOANoMaderable").show();
                ManPOA.frmPOARegistro.find("#colPOANoM6").text(cNoM6);
                ManPOA.frmPOARegistro.find("#colPOANoM7").text(this.intlRound(cNoM7, 3));
                ManPOA.frmPOARegistro.find("#colPOANoM8").text(this.intlRound(cNoM8, 3));
                ManPOA.frmPOARegistro.find("#colPOANoM9").text(cNoM9);
                ManPOA.frmPOARegistro.find("#colPOANoM10").text(this.intlRound(cNoM10, 3));
                ManPOA.frmPOARegistro.find("#colPOANoM11").text(this.intlRound(cNoM11, 3));
                ManPOA.frmPOARegistro.find("#colPOANoM12").text(this.intlRound(cNoM12, 3));
                ManPOA.frmPOARegistro.find("#colPOANoM13").text(this.intlRound(cNoM13, 3));
            }
            else ManPOA.frmPOARegistro.find("#totalPOANoMaderable").hide();
        }
        else {
            ManPOA.frmPOARegistro.find("#totalPOAMaderable").hide();
            ManPOA.frmPOARegistro.find("#totalPOACarbon").hide();
            ManPOA.frmPOARegistro.find("#totalPOANoMaderable").hide();
        }

        /*ManPOA.ItemRAPoa.dtItemRAPoa.rows().every(function (rowIdx, tableLoop, rowLoop) {
            var row = this.data();
        });*/
    }
    this.intlRound = function (numero, decimales, usarComa = false) {
        var opciones = {
            maximumFractionDigits: decimales,
            useGrouping: false
        };
        usarComa = usarComa ? "es" : "en";
        return new Intl.NumberFormat(usarComa, opciones).format(numero);
    }
    this.cellEdit = function (data, type, row) {
        return '<i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Editar" onclick="ManPOA.ItemRAPoa.ItemRAPoaVentana(0,this);"></i>';

    }
    this.cellDel = function (data, type, row) {
        return '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManPOA.ItemRAPoa.eliminar(this);"></i>';
    }
    this.ddListarPC = function () {
        var pcList = [];
        $('#txtParcelaEspecie').find('option').remove().end();
        var parcela = _frmParcela.fnGetList();
        var countFilas = parcela.length;
        if (countFilas > 0) {
            $.each(parcela, function (i, o) {
                //alert(parcela[i].PCA);
                //pcList.push(utilSigo.fnConvertArrayToObject(parcela[i].PCA));
                $('#txtParcelaEspecie').append($('<option>', {
                    value: parcela[i].PCA,
                    text: parcela[i].PCA
                }));
            });
        }
    }



    this.ItemRAPoaVentana = function (RegEstado, obj) {
        this.ddListarPC();
        var PDivTitulo = '';
        var ListIndex = 0;

        if (RegEstado == 1)
            PDivTitulo = 'Nuevo Registro';
        else {
            if (RegEstado == 0) {
                PDivTitulo = 'Modificando Registro';
                var $tr = $(obj).closest('tr');
                this.tr = $tr;

                var data = this.dtItemRAPoa.row($tr).data();
                var hdfItemCod_MTipo = ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val();

                this.frmResolAprob.find("#ddlItemRAPoaEspeciesId").val(data.COD_ESPECIES).trigger("change");
                this.frmResolAprob.find("#ddlItemRAPoaEspecies_SerforId").val(data.COD_ESPECIES_SERFOR).trigger("change");
                this.frmResolAprob.find("#ddlTipoMaderables_RAprob").val(data.TIPOMADERABLE);
                this.frmResolAprob.find("#txtItemRAPoaObservacion").val(data.OBSERVACION);
                this.frmResolAprob.find("#txtParcelaEspecie").val(data.PCA);


                if (hdfItemCod_MTipo == "0000020") {
                    this.frmResolAprob.find("#txtSuperficieHa").val(data.SuperficieHa);
                    this.frmResolAprob.find("#txtCantidad1").val(data.CANTIDAD);
                }
                else if (hdfItemCod_MTipo == "0000021") {

                    this.frmResolAprob.find("#txtAbundanciaMed").val(data.ABUNDANCIA);
                    this.frmResolAprob.find("#txtNumIndividuosMed").val(data.NUMINDIVIDUOS);
                    this.frmResolAprob.find("#txtPesoMed").val(data.PESO);
                    this.frmResolAprob.find("#txtRendimiento").val(data.RENDIMIENTO);
                    this.frmResolAprob.find("#ddlUnMed").val(data.UNIDAD_MEDIDA.toUpperCase());
                }
                else {
                    this.frmResolAprob.find("#txtItemRAPoaNum_Arboles").val(data.NUM_ARBOLES);
                    this.frmResolAprob.find("#txtItemRAPoaVolumen_Kilogramos").val(data.VOLUMEN_KILOGRAMOS);
                    this.frmResolAprob.find("#ddlRAPoaUM").val(data.UNIDAD_MEDIDA);

                    if (data.UNIDAD_MEDIDA != "-")
                        this.frmResolAprob.find("#ddlRAPoaUM").attr("disabled", true);
                }
            }
        }

        $("#spTituloItemRAPoa").html(PDivTitulo);

        this.frmResolAprob.find("#hdfItemRAPoa_RegEstado").val(RegEstado);
        this.frmResolAprob.find("#hdfItemRAPoa_ListIndex").val(ListIndex);
        utilSigo.modalDraggable($("#PDivItemRAPoa"), '.modal-header');
        $("#PDivItemRAPoa").modal({ keyboard: true, backdrop: 'static' });
    }
    this.ItemRAPoaVentanaLimpiar = function () {

        this.frmResolAprob.find("#ddlItemRAPoaEspeciesId").val('-').trigger("change");
        this.frmResolAprob.find("#ddlItemRAPoaEspecies_SerforId").val('-').trigger("change");
        this.frmResolAprob.find("#txtItemRAPoaNum_Arboles").val('');
        this.frmResolAprob.find("#txtItemRAPoaVolumen_Kilogramos").val('');
        this.frmResolAprob.find("#txtSuperficieHa").val('');
        this.frmResolAprob.find("#txtCantidad1").val('');
        this.frmResolAprob.find("#txtItemRAPoaObservacion").val('');
        this.frmResolAprob.find("#ddlUnMed").val('-');
        this.frmResolAprob.find("#ddlTipoMaderables_RAprob").val('-');

        this.frmResolAprob.find("#txtAbundanciaMed").val('');
        this.frmResolAprob.find("#txtNumIndividuosMed").val('');
        this.frmResolAprob.find("#txtPesoMed").val('');
        this.frmResolAprob.find("#txtRendimiento").val('');
        this.frmResolAprob.find("#txtItemRAPoaObservacion").val('');
        this.frmResolAprob.find("#ddlRAPoaUM").val('-');
        this.frmResolAprob.find("#ddlRAPoaUM").attr("disabled", false);

        switch (ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val()) {
            case "0000008":
            case "0000018":
                //$("#ltrItemRAPoaVolumen_Kilogramos").text('Kilogramos autorizado');
                $("#ltrItemRAPoaVolumen_Kilogramos").text('Cantidad Autorizada');
                break;
            case "0000009":
            case "0000022":
                //$("#ltrItemRAPoaVolumen_Kilogramos").text('Litros autorizado');
                $("#ltrItemRAPoaVolumen_Kilogramos").text('Cantidad Autorizada');
                break;
            case "0000020":
            case "0000021":
                //$("#ltrItemRAPoaVolumen_Kilogramos").text('Unidades autorizado');
                $("#ltrItemRAPoaVolumen_Kilogramos").text('Cantidad Autorizada');
                break;
            default:
                //$("#ltrItemRAPoaVolumen_Kilogramos").text('Volumen autorizado');
                $("#ltrItemRAPoaVolumen_Kilogramos").text('Cantidad Autorizada');
                break;
        }
    }

    this.closeModal = function () {
        this.ItemRAPoaVentanaLimpiar();
        //limpiando estilos si lo tienen
        $(':input', this.frmResolAprob)
            .removeClass('border-danger')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title');

        $('#PDivItemRAPoa').modal('hide');
    }
    this.ItemRAPoGrabar = function () {
        var hdfItemCod_MTipo = ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val();

        //if (this.frmResolAprob.find("#hdfItemRAPoa_RegEstado").val() == '1') {
        if (this.frmResolAprob.find("#ddlItemRAPoaEspeciesId").val() == "-") {
            utilSigo.toastError("Error", "Seleccione Especie");
            return false;
        }

        if (hdfItemCod_MTipo == "0000020") {
            if (this.frmResolAprob.find("#txtSuperficieHa").val() == null ||
                this.frmResolAprob.find("#txtSuperficieHa").val().trim().length == 0) {
                utilSigo.toastError("Error", "Ingrese Superficie(Ha.)");
                return false;
            }
            if (this.frmResolAprob.find("#txtCantidad1").val() == null ||
                this.frmResolAprob.find("#txtCantidad1").val().trim().length == 0) {
                utilSigo.toastError("Error", "Ingrese Cantidad");
                return false;
            }
            if (this.frmResolAprob.find("#ddlTipoMaderables_RAprob").val() == "-") {
                utilSigo.toastError("Error", "Seleccione Tipo");
                return false;
            }
        }
        else if (hdfItemCod_MTipo == "0000021") {
            if (this.frmResolAprob.find("#txtAbundanciaMed").val() == null ||
                this.frmResolAprob.find("#txtAbundanciaMed").val().trim().length == 0) {
                utilSigo.toastError("Error", "Ingrese Abundancia");
                return false;
            }
            if (this.frmResolAprob.find("#txtNumIndividuosMed").val() == null ||
                this.frmResolAprob.find("#txtNumIndividuosMed").val().trim().length == 0) {
                utilSigo.toastError("Error", "Ingrese N° Individuos aprovechar/hectáreas");
                return false;
            }
            if (this.frmResolAprob.find("#txtPesoMed").val() == null ||
                this.frmResolAprob.find("#txtPesoMed").val().trim().length == 0) {
                utilSigo.toastError("Error", "Ingrese Peso Seco kg/lt");
                return false;
            }
            if (this.frmResolAprob.find("#txtRendimiento").val() == null ||
                this.frmResolAprob.find("#txtRendimiento").val().trim().length == 0) {
                utilSigo.toastError("Error", "Ingrese Rendimiento kg/ha ó lt/ha");
                return false;
            }
            if (this.frmResolAprob.find("#ddlUnMed").val() == "-") {
                utilSigo.toastError("Error", "Ingrese Unidad de Medida");
                return false;
            }
            if (this.frmResolAprob.find("#ddlTipoMaderables_RAprob").val() == "-") {
                utilSigo.toastError("Error", "Seleccione Tipo");
                return false;
            }
        }
        else {
            if (this.frmResolAprob.find("#txtItemRAPoaNum_Arboles").val() == null ||
                this.frmResolAprob.find("#txtItemRAPoaNum_Arboles").val().trim().length == 0) {
                utilSigo.toastError("Error", "Ingrese N° árboles");
                return false;
            }
            if (this.frmResolAprob.find("#ddlTipoMaderables_RAprob").val() == "-") {
                utilSigo.toastError("Error", "Seleccione Tipo");
                return false;
            }
            if (this.frmResolAprob.find("#txtItemRAPoaVolumen_Kilogramos").val() == null ||
                this.frmResolAprob.find("#txtItemRAPoaVolumen_Kilogramos").val().trim().length == 0) {
                utilSigo.toastError("Error", "Ingrese Cantidad Autorizada");
                return false;
            }
            if (this.frmResolAprob.find("#ddlRAPoaUM").val() == "-") {
                utilSigo.toastError("Error", "Ingrese Unidad de Medida");
                return false;
            }
        }
        //}


        if (this.frmResolAprob.find("#txtParcelaEspecie").val() == null) {
            utilSigo.toastError("Error", "Seleccione parcela");
            return false;
        }
        return true;
    }
    this.btnItemRAPoa_Grabar_Click = function () {
        if (this.ItemRAPoGrabar()) {
            var hdfItemRAPoa_RegEstado = this.frmResolAprob.find("#hdfItemRAPoa_RegEstado").val();
            var hdfItemCod_MTipo = ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val();
            if (hdfItemRAPoa_RegEstado == "1") {

                var codSecC = this.dtItemRAPoa.$("tr").length + 1;

                var fila = {
                    NRO: codSecC,
                    ESPECIES: "",
                    ESPECIES_SERFOR: "",
                    NUM_ARBOLES: "",
                    VOLUMEN_KILOGRAMOS: "",
                    SuperficieHa: "",
                    CANTIDAD: "",
                    ABUNDANCIA: "",
                    NUMINDIVIDUOS: "",
                    PESO: "",
                    RENDIMIENTO: "",
                    UNIDAD_MEDIDA: "",
                    TIPOMADERABLE: this.frmResolAprob.find("#ddlTipoMaderables_RAprob").val(),
                    OBSERVACION: "",
                    COD_ESPECIES: this.frmResolAprob.find("#ddlItemRAPoaEspeciesId").val(),
                    COD_ESPECIES_SERFOR: "",
                    RegEstado: "",
                    PCA: "",
                    COD_SECUENCIAL: 0
                };

                if (hdfItemCod_MTipo == "0000020") {
                    fila.SuperficieHa = this.frmResolAprob.find("#ddlTipoMaderables_RAprob").val();
                    fila.CANTIDAD = this.frmResolAprob.find("#txtCantidad1").val().trim();
                }
                else if (hdfItemCod_MTipo == "0000021") {
                    fila.ABUNDANCIA = this.frmResolAprob.find("#txtAbundanciaMed").val().trim();
                    fila.NUMINDIVIDUOS = this.frmResolAprob.find("#txtNumIndividuosMed").val().trim();
                    fila.PESO = this.frmResolAprob.find("#txtPesoMed").val().trim();
                    fila.RENDIMIENTO = this.frmResolAprob.find("#txtRendimiento").val().trim();
                    fila.UNIDAD_MEDIDA = this.frmResolAprob.find("#ddlUnMed").val();
                }
                else {
                    fila.NUM_ARBOLES = this.frmResolAprob.find("#txtItemRAPoaNum_Arboles").val().trim();
                    fila.VOLUMEN_KILOGRAMOS = this.frmResolAprob.find("#txtItemRAPoaVolumen_Kilogramos").val().trim();
                    fila.UNIDAD_MEDIDA = this.frmResolAprob.find("#ddlRAPoaUM").val();
                }
                fila.PCA = this.frmResolAprob.find("#txtParcelaEspecie").val();
                fila.OBSERVACION = this.frmResolAprob.find("#txtItemRAPoaObservacion").val().trim();
                fila.ESPECIES = this.frmResolAprob.find("#ddlItemRAPoaEspeciesId").select2('data')[0].text;
                var especie = this.frmResolAprob.find("#ddlItemRAPoaEspecies_SerforId").val();
                if (especie.trim() != "") {
                    fila.COD_ESPECIES_SERFOR = this.frmResolAprob.find("#ddlItemRAPoaEspecies_SerforId").val();
                    fila.ESPECIES_SERFOR = fila.COD_ESPECIES_SERFOR == "-" ? "" : fila.COD_ESPECIES_SERFOR == "0002226" ? "" : this.frmResolAprob.find("#ddlItemRAPoaEspecies_SerforId").select2('data')[0].text;
                }
                fila.RegEstado = 1;

                this.dtItemRAPoa.row.add(fila).draw();
                this.dtItemRAPoa.page('last').draw('page');

            }
            else {
                //var indice = this.frmResolAprob.find("#hdfItemRAPoa_ListIndex").val();                            
                var row = this.dtItemRAPoa.row(this.tr).data();

                if (hdfItemCod_MTipo == "0000020") {
                    var txtSuperficieHa = this.frmResolAprob.find("#txtSuperficieHa").val().trim();
                    var txtCantidad1 = this.frmResolAprob.find("#txtCantidad1").val().trim();

                    row.SuperficieHa = txtSuperficieHa;
                    row.CANTIDAD = txtCantidad1;

                }
                else if (hdfItemCod_MTipo.Value == "0000021") {
                    var txtAbundanciaMed = this.frmResolAprob.find("#txtAbundanciaMed").val().trim();
                    var txtNumIndividuosMed = this.frmResolAprob.find("#txtNumIndividuosMed").val().trim();
                    var txtPesoMed = this.frmResolAprob.find("#txtPesoMed").val().trim();
                    var txtRendimiento = this.frmResolAprob.find("#txtRendimiento").val().trim();
                    var ddlUnMed = this.frmResolAprob.find("#ddlUnMed").val().trim();

                    row.ABUNDANCIA = txtAbundanciaMed;
                    row.NUMINDIVIDUOS = txtNumIndividuosMed;
                    row.PESO = txtPesoMed;
                    row.RENDIMIENTO = txtRendimiento;
                    row.UNIDAD_MEDIDA = ddlUnMed;

                }
                else {
                    var txtItemRAPoaNum_Arboles = this.frmResolAprob.find("#txtItemRAPoaNum_Arboles").val().trim();
                    var txtItemRAPoaVolumen_Kilogramos = this.frmResolAprob.find("#txtItemRAPoaVolumen_Kilogramos").val().trim();
                    var ddlRAPoaUM = this.frmResolAprob.find("#ddlRAPoaUM").val();
                    row.NUM_ARBOLES = txtItemRAPoaNum_Arboles;
                    row.VOLUMEN_KILOGRAMOS = txtItemRAPoaVolumen_Kilogramos;
                    row.UNIDAD_MEDIDA = ddlRAPoaUM;
                }
                //alert(this.frmResolAprob.find("#ddlItemRAPoaEspecies_SerforId").val());
                row.COD_ESPECIES = this.frmResolAprob.find("#ddlItemRAPoaEspeciesId").val();
                row.TIPOMADERABLE = this.frmResolAprob.find("#ddlTipoMaderables_RAprob").val();
                row.ESPECIES = this.frmResolAprob.find("#ddlItemRAPoaEspeciesId").select2('data')[0].text;
                row.COD_ESPECIES_SERFOR = this.frmResolAprob.find("#ddlItemRAPoaEspecies_SerforId").val();

                if (row.COD_ESPECIES_SERFOR != null) {
                    row.ESPECIES_SERFOR = row.COD_ESPECIES_SERFOR == "-" ? "" : row.COD_ESPECIES_SERFOR == "0002226" ? "" : this.frmResolAprob.find("#ddlItemRAPoaEspecies_SerforId").select2('data')[0].text;
                }
                row.OBSERVACION = this.frmResolAprob.find("#txtItemRAPoaObservacion").val().trim();
                row.PCA = this.frmResolAprob.find("#txtParcelaEspecie").val();

                if (row.RegEstado == 0) {
                    row.RegEstado = 2;
                }
                this.dtItemRAPoa.row(this.tr).data(row).draw();
                utilSigo.toastSuccess("Exito", "Se modifico con exito");
                this.closeModal();
            }
            ManPOA.ItemRAPoa.CalculaPOA(hdfItemCod_MTipo);
        }
    }
    this.eliminarTablaAll = function () {
        var $trsEliminar = this.dtItemRAPoa.$("tr");
        if ($trsEliminar.length > 0) {
            utilSigo.dialogConfirm("", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {
                    var hdfItemCod_MTipo = ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val();

                    ManPOA.ItemRAPoa.dtItemRAPoa.rows().every(function (rowIdx, tableLoop, rowLoop) {
                        var row = this.data();
                        if (row.RegEstado == 0 || row.RegEstado == 2) {
                            ManPOA.ListEliTABLA.push({
                                EliTABLA: "POA_DET_MADE_NOMADE_EAAPROVECHAR",
                                EliVALOR01: row.COD_ESPECIES,
                                EliVALOR02: row.COD_SECUENCIAL
                            });
                        }
                    });
                    ManPOA.ItemRAPoa.dtItemRAPoa.clear().draw();
                    ManPOA.ItemRAPoa.CalculaPOA(hdfItemCod_MTipo);
                }
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }
    this.eliminar = function (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?",
            function (r) {
                if (r) {
                    var hdfItemCod_MTipo = ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val();
                    var $tr = $(obj).closest('tr');
                    var row = ManPOA.ItemRAPoa.dtItemRAPoa.row($tr).data();
                    if (row.RegEstado == 0 || row.RegEstado == 2) {
                        ManPOA.ListEliTABLA.push({
                            EliTABLA: "POA_DET_MADE_NOMADE_EAAPROVECHAR",
                            EliVALOR01: row.COD_ESPECIES,
                            EliVALOR02: row.COD_SECUENCIAL
                        });
                    }
                    ManPOA.ItemRAPoa.dtItemRAPoa.row($tr).remove().draw();
                    utilSigo.enumTB(ManPOA.ItemRAPoa.dtItemRAPoa, 2);
                    ManPOA.ItemRAPoa.CalculaPOA(hdfItemCod_MTipo);
                }
            });
    }

    this.addRowsDtExcel = function (data) {
        var hdfItemCod_MTipo = ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val();
        var $rows = ManPOA.ItemRAPoa.dtItemRAPoa.$("tr");
        var codSecC = $rows.length + 1;
        var band = 0;
        var parcela = _frmParcela.fnGetList();
        var countFilas = parcela.length;

        console.log(codSecC);
        for (var i = 0; i < data.length; i++) {

            var fila = {
                NRO: codSecC,
                ESPECIES: data[i].ESPECIES,
                ESPECIES_SERFOR: data[i].ESPECIES_SERFOR,
                NUM_ARBOLES: data[i].NUM_ARBOLES,
                VOLUMEN_KILOGRAMOS: data[i].VOLUMEN_KILOGRAMOS,
                SuperficieHa: data[i].SuperficieHa,
                CANTIDAD: data[i].CANTIDAD,
                ABUNDANCIA: data[i].ABUNDANCIA,
                NUMINDIVIDUOS: data[i].NUMINDIVIDUOS,
                PESO: data[i].PESO,
                RENDIMIENTO: data[i].RENDIMIENTO,
                UNIDAD_MEDIDA: data[i].UNIDAD_MEDIDA,
                TIPOMADERABLE: data[i].TIPOMADERABLE,
                OBSERVACION: data[i].OBSERVACION,
                PCA: data[i].PCA,
                COD_ESPECIES: data[i].COD_ESPECIES,
                COD_ESPECIES_SERFOR: data[i].COD_ESPECIES_SERFOR,
                RegEstado: data[i].RegEstado,
                COD_SECUENCIAL: 0
            };
            codSecC++;
            band = 0;
            if (countFilas > 0) {
                for (var j = 0; j < parcela.length; j++) {
                    if (data[i].PCA == parcela[j].PCA) {
                        band = 1;
                    }
                }
            }
            if (band == 1) {
                ManPOA.ItemRAPoa.dtItemRAPoa.row.add(fila).draw();
            }
            else {
                utilSigo.toastWarning("Error", "La parcela " + data[i].PCA + "  no coinciden con lo registrado");
            }
        }
        ManPOA.ItemRAPoa.dtItemRAPoa.page('last').draw('page');
        ManPOA.ItemRAPoa.CalculaPOA(hdfItemCod_MTipo);
    }

    this.exportarExcel = function (codTHabilitante, numPoa) {

        $.ajax({
            url: ManPOA.controller + "/ExportarExcel",
            type: 'POST',
            data: {
                COD_THABILITANTE: codTHabilitante,
                NumPoa: numPoa,
                hdfItemCod_MTipo: ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val(),
                tipoGrilla: "RAPoa",
                estado_origen: ManPOA.frmPOARegistro.find("#hdfItemEstadoOrigen").val()

            },
            dataType: 'json',
            success: function (data) {

                //utilSigo.unblockUIGeneral();
                if (data.success) {
                    window.location.href = ManPOA.controller + "/Download?file=" + data.values[0];
                }
                else utilSigo.toastWarning("Error", data.msj);
            },
            //beforeSend: function () {
            //    utilSigo.blockUIGeneral();
            //},
            error: function (jqXHR, error, errorThrown) {
                //  utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                //console.log(jqXHR.responseText);
            }
        });

    }


}).apply(ManPOA.ItemRAPoa);
//RAPoaInSitu
(function () {
    this.dtItemRAPoaInSitu;
    this.columns;
    this.frmRAPoaInSitu;
    this.tr;
    this.divModal;
    this.init = function () {
        //var hdfItemCod_MTipo = ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val();
        //var hdfItemIndicador = ManPOA.frmPOARegistro.find("#hdfItemIndicador").val();
        this.divModal = $("#PDivItemRAPoaInSitu");
        this.frmRAPoaInSitu = $("#frmRAPoaInSitu");

        this.dtItemRAPoaInSitu = ManPOA.frmPOARegistro.find("#grvItemRAPoaInSitu").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bInfo: false,
            bLengthChange: false,
            scrollCollapse: true,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            ajax: {
                url: ManPOA.controller + "/GetAllRAPoaInSitu",
                type: "GET",
                datatype: "json"
            },
            columns: [
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemRAPoaInSitu.cellEdit },
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemRAPoaInSitu.cellDel },
                { data: "NRO" },
                { data: "ESPECIES" },
                { data: "ESPECIES_SERFOR" },
                { data: "PERIODO" },
                { data: "CUOTA_SACA" },
                { data: "METODO_CAZA" },
                { data: "SISTEMA_MARCAJE" },
                { data: "DENSIDAD" },
                { data: "OBSERVACION" },
                { data: "COD_ESPECIES", visible: false },
                { data: "COD_ESPECIES_SERFOR", visible: false },
                { data: "RegEstado", visible: false },
                { data: "COD_SECUENCIAL", visible: false }

            ]

        });



        this.frmRAPoaInSitu
            .find('#ddlItemRAPoaInSituEspecies').select2();
        this.frmRAPoaInSitu
            .find('#ddlItemRAPoaInSituEspecies_Serfor').select2();



    }
    this.cellEdit = function (data, type, row) {
        return '<i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Editar" onclick="ManPOA.ItemRAPoaInSitu.showModal(0,this);"></i>';

    }
    this.cellDel = function (data, type, row) {
        return '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManPOA.ItemRAPoaInSitu.eliminar(this);"></i>';
    }
    this.showModal = function (RegEstado, obj) {

        var PDivTitulo = '';

        if (RegEstado == 1) {
            PDivTitulo = "Nuevo Registro - Resolución de Aprobación";
        } else {
            if (RegEstado == 0) {
                PDivTitulo = "Modificando Registro - Resolución de Aprobación";

                this.tr = $(obj).closest('tr');
                var row = this.dtItemRAPoaInSitu.row(this.tr).data();

                this.frmRAPoaInSitu.find("#ddlItemRAPoaInSituEspecies").val(row.COD_ESPECIES).trigger("change");
                this.frmRAPoaInSitu.find("#ddlItemRAPoaInSituEspecies_Serfor").val(row.COD_ESPECIES_SERFOR).trigger("change");

                this.frmRAPoaInSitu.find("#txtItemRAPoaInSituPeriodo").val(row.PERIODO);
                this.frmRAPoaInSitu.find("#txtItemRAPoaInSituCuota_Saca").val(row.CUOTA_SACA);
                this.frmRAPoaInSitu.find("#txtItemRAPoaInSituMetodo_Caza").val(row.METODO_CAZA);
                this.frmRAPoaInSitu.find("#txtItemRAPoaInSituSistema_Marcaje").val(row.SISTEMA_MARCAJE);
                this.frmRAPoaInSitu.find("#txtItemRAPoaInSituDensidad").val(row.DENSIDAD);
                this.frmRAPoaInSitu.find("#txtItemRAPoaInSituObservacion").val(row.OBSERVACION);

            }
        }

        this.divModal.find(".spTitulo").html(PDivTitulo);
        this.frmRAPoaInSitu.find("#hdfItemRAPoaInSitu_RegEstado").val(RegEstado);
        utilSigo.modalDraggable(this.divModal, '.modal-header');
        this.divModal.modal({ keyboard: true, backdrop: 'static' });

    }


    this.cleanModal = function () {

        this.frmRAPoaInSitu.find("#txtItemRAPoaInSituPeriodo").val('');
        this.frmRAPoaInSitu.find("#txtItemRAPoaInSituCuota_Saca").val('');
        this.frmRAPoaInSitu.find("#txtItemRAPoaInSituMetodo_Caza").val('');
        this.frmRAPoaInSitu.find("#txtItemRAPoaInSituSistema_Marcaje").val('');
        this.frmRAPoaInSitu.find("#txtItemRAPoaInSituDensidad").val('');
        this.frmRAPoaInSitu.find("#txtItemRAPoaInSituObservacion").val('');
        this.frmRAPoaInSitu.find("#ddlItemRAPoaInSituEspecies").val('-').trigger("change");
        this.frmRAPoaInSitu.find("#ddlItemRAPoaInSituEspecies_Serfor").val('-').trigger("change");
    }

    this.closeModal = function () {
        this.cleanModal();
        //limpiando estilos si lo tienen
        $(':input', this.frmRAPoaInSitu)
            .removeClass('border-danger')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title');

        this.divModal.modal('hide');
    }
    this.validaSaveModal = function () {

        if (this.frmRAPoaInSitu.find("#hdfItemRAPoaInSitu_RegEstado").val() == '1') {
            if (utilSigo.ValidaCombo("ddlItemRAPoaInSituEspecies", "Seleccione Especie") == false) return false;
        }
        if (utilSigo.ValidaTexto("txtItemRAPoaInSituPeriodo", "Ingrese Periodo") == false) return false;
        if (utilSigo.ValidaTexto("txtItemRAPoaInSituCuota_Saca", "Ingrese Cuota de Saca") == false) return false;
        if (utilSigo.ValidaTexto("txtItemRAPoaInSituMetodo_Caza", "Ingrese Método de caza o captura") == false) return false;
        if (utilSigo.ValidaTexto("txtItemRAPoaInSituSistema_Marcaje", "Ingrese Sistema de Marcaje o Identificación") == false) return false;
        if (utilSigo.ValidaTexto("txtItemRAPoaInSituDensidad", "Ingrese Densidad según POA") == false) return false;
        return true;
    }
    this.saveModal = function () {

        if (this.validaSaveModal()) {

            var estado = this.frmRAPoaInSitu.find("#hdfItemRAPoaInSitu_RegEstado").val();

            if (estado == "1") {
                //Nuevo
                var codSecC = this.dtItemRAPoaInSitu.$("tr").length + 1;

                var fila = {
                    NRO: codSecC,
                    PERIODO: this.frmRAPoaInSitu.find("#txtItemRAPoaInSituPeriodo").val().trim(),
                    CUOTA_SACA: this.frmRAPoaInSitu.find("#txtItemRAPoaInSituCuota_Saca").val().trim(),
                    METODO_CAZA: this.frmRAPoaInSitu.find("#txtItemRAPoaInSituMetodo_Caza").val().trim(),
                    SISTEMA_MARCAJE: this.frmRAPoaInSitu.find("#txtItemRAPoaInSituSistema_Marcaje").val().trim(),
                    DENSIDAD: this.frmRAPoaInSitu.find("#txtItemRAPoaInSituDensidad").val().trim(),
                    OBSERVACION: this.frmRAPoaInSitu.find("#txtItemRAPoaInSituObservacion").val().trim(),
                    ESPECIES: this.frmRAPoaInSitu.find("#ddlItemRAPoaInSituEspecies").select2('data')[0].text,
                    ESPECIES_SERFOR: (this.frmRAPoaInSitu.find("#ddlItemRAPoaInSituEspecies_Serfor").val() == "-" ? "" : this.frmRAPoaInSitu.find("#ddlItemRAPoaInSituEspecies_Serfor").select2('data')[0].text),
                    COD_ESPECIES: this.frmRAPoaInSitu.find("#ddlItemRAPoaInSituEspecies").val(),
                    COD_ESPECIES_SERFOR: this.frmRAPoaInSitu.find("#ddlItemRAPoaInSituEspecies_Serfor").val(),
                    RegEstado: 1,
                    COD_SECUENCIAL: ""
                };

                this.dtItemRAPoaInSitu.rows.add([fila]).draw();
                this.dtItemRAPoaInSitu.page('last').draw('page');

            }
            else {

                var row = this.dtItemRAPoaInSitu.row(this.tr).data();
                row.PERIODO = this.frmRAPoaInSitu.find("#txtItemRAPoaInSituPeriodo").val().trim();
                row.CUOTA_SACA = this.frmRAPoaInSitu.find("#txtItemRAPoaInSituCuota_Saca").val().trim();
                row.METODO_CAZA = this.frmRAPoaInSitu.find("#txtItemRAPoaInSituMetodo_Caza").val().trim();
                row.SISTEMA_MARCAJE = this.frmRAPoaInSitu.find("#txtItemRAPoaInSituSistema_Marcaje").val().trim();
                row.DENSIDAD = this.frmRAPoaInSitu.find("#txtItemRAPoaInSituDensidad").val().trim();
                row.COD_ESPECIES_SERFOR = this.frmRAPoaInSitu.find("#ddlItemRAPoaInSituEspecies_Serfor").val();
                row.ESPECIES_SERFOR = row.COD_ESPECIES_SERFOR == "-" ? "" : this.frmRAPoaInSitu.find("#ddlItemRAPoaInSituEspecies_Serfor").select2('data')[0].text;
                row.OBSERVACION = this.frmRAPoaInSitu.find("#txtItemRAPoaInSituObservacion").val().trim();


                if (row.RegEstado == 0)
                    row.RegEstado = 2;

                this.dtItemRAPoaInSitu.row(this.tr).data(row).draw(false);

                utilSigo.toastSuccess("Exito", "Se modifico con exito");
                this.closeModal();
            }
        }
    }

    this.eliminar = function (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?",
            function (r) {
                if (r) {

                    var $tr = $(obj).closest('tr');
                    var row = ManPOA.ItemRAPoaInSitu.dtItemRAPoaInSitu.row($tr).data();
                    if (row.RegEstado == 0 || row.RegEstado == 2) {
                        ManPOA.ListEliTABLA.push({
                            EliTABLA: "POA_INSITU_DET_EAAPROVECHAR",
                            EliVALOR01: row.COD_ESPECIES,
                            EliVALOR02: row.COD_SECUENCIAL
                        });
                    }

                    ManPOA.ItemRAPoaInSitu.dtItemRAPoaInSitu.row($tr).remove().draw(false);
                    utilSigo.enumTB(ManPOA.ItemRAPoaInSitu.dtItemRAPoaInSitu, 2);

                }
            });
    }
    this.eliminarTablaAll = function () {

        var $trsEliminar = this.dtItemRAPoaInSitu.$("tr");
        if ($trsEliminar.length > 0) {
            utilSigo.dialogConfirm("", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {

                    ManPOA.ItemRAPoaInSitu.dtItemRAPoaInSitu.rows().every(function (rowIdx, tableLoop, rowLoop) {
                        var row = this.data();
                        if (row.RegEstado == 0 || row.RegEstado == 2) {
                            ManPOA.ListEliTABLA.push({
                                EliTABLA: "POA_INSITU_DET_EAAPROVECHAR",
                                EliVALOR01: row.COD_ESPECIES,
                                EliVALOR02: row.COD_SECUENCIAL
                            });
                        }
                    });
                    ManPOA.ItemRAPoaInSitu.dtItemRAPoaInSitu.clear().draw();
                }
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }
    this.addRowsDtExcel = function (data) {
        var $rows = this.dtItemRAPoaInSitu.$("tr");
        var codSecC = $rows.length + 1;
        var list = [];
        for (var i = 0; i < data.length; i++) {

            list.push({
                NRO: codSecC,
                ESPECIES: data[i].ESPECIES,
                ESPECIES_SERFOR: data[i].ESPECIES_SERFOR,
                PERIODO: data[i].PERIODO,
                CUOTA_SACA: data[i].CUOTA_SACA,
                SISTEMA_MARCAJE: data[i].SISTEMA_MARCAJE,
                DENSIDAD: data[i].DENSIDAD,
                OBSERVACION: data[i].OBSERVACION,
                COD_ESPECIES: data[i].COD_ESPECIES,
                COD_ESPECIES_SERFOR: data[i].COD_ESPECIES_SERFOR,
                RegEstado: data[i].RegEstado,
                METODO_CAZA: data[i].METODO_CAZA,
                //COD_ESPECIES: data[i].COD_ESPECIES,
                //COD_ESPECIES_SERFOR: data[i].COD_ESPECIES_SERFOR,
                COD_SECUENCIAL: ""
            });
            codSecC++;
        }
        this.dtItemRAPoaInSitu.rows.add(list).draw();
        this.dtItemRAPoaInSitu.page('last').draw('page');
    };
}).apply(ManPOA.ItemRAPoaInSitu);

//Objeto Vertice
(function () {
    this.frmVertice;
    this.init = function () {

        jQuery.validator.addMethod("invalidVertices", function (value, element) {
            switch ($(element).attr('id')) {
                case 'ddlItemZona_UTM':
                    return (value == '0000000') ? false : true;
                    break;
            }
        });


        this.frmVertice.validate({
            focusInvalid: true,
            rules: {
                txtItemVert_Vertice: { required: true },
                ddlItemZona_UTM: { invalidVertices: true },
                txtItemVert_CEste: { required: true },
                txtItemVert_CNorte: { required: true }
            },
            messages: {
                txtItemVert_Vertice: { required: "Ingrese Vertice" },
                ddlItemZona_UTM: { invalidVertices: "Campo Requerido" },
                txtItemVert_CEste: { required: "Ingrese Coordenada" },
                txtItemVert_CNorte: { required: "Ingrese Coordenada" }
            },
            errorPlacement: function (error, element) {// render error placement for each input type
                var lElement = $(element);
                lElement.addClass('border-danger');
                lElement.attr('data-toggle', 'tooltip');
                lElement.attr('data-placement', 'top');
                lElement.attr('data-original-title', error.text());
                $('[data-toggle="tooltip"]').tooltip();

            },
            success: function (label, element) {
                var lElement = $(element);
                lElement.removeClass('border-danger');
                lElement.removeAttr('data-toggle');
                lElement.removeAttr('data-placement');
                lElement.removeAttr('data-original-title');
            },
            submitHandler: function (form) {
                var opcionOrigern = ManPOA.DGeneral.frmVertice.find("#hdOrigen").val();
                if (opcionOrigern === "tbVertice")
                    ManPOA.DGeneral.agregarVertice();
                //ManTHabilitante.adend.agregarVerticeMod();
            }
        });

        this.frmVertice.find("#btnRegistrarVertice").click(function () {

            ManPOA.DGeneral.frmVertice.submit();
        });

    };
    this.mostrarModal = function (origen) {
        this.ddListarPCVertice();
        this.frmVertice.find("#hdfItemVert_RegEstado").val(1);
        this.frmVertice.find("#hdOrigen").val(origen);

        //implementar lo de cod secuencial
        utilSigo.modalDraggable($("#PDivItemVertice"), '.modal-header');
        $("#PDivItemVertice").modal({ keyboard: true, backdrop: 'static' });

    }
    this.closeModalVert = function () {
        this.limpiarControles();

        //limpiando estilos si lo tienen
        $(':input', this.frmVertice)
            .removeClass('border-danger')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title');
        $('#PDivItemVertice').modal('hide');
    }

    this.ddListarPCVertice = function () {
        var pcList = [];
        $('#txtParcelaVertice').find('option').remove().end();
        var parcela = _frmParcela.fnGetList();
        var countFilas = parcela.length;
        if (countFilas > 0) {
            $.each(parcela, function (i, o) {
                //alert(parcela[i].PCA);
                //pcList.push(utilSigo.fnConvertArrayToObject(parcela[i].PCA));
                $('#txtParcelaVertice').append($('<option>', {
                    value: parcela[i].PCA,
                    text: parcela[i].PCA
                }));
            });
        }
    }

    this.limpiarControles = function () {
        this.frmVertice.find("#txtItemVert_Vertice").val('');
        this.frmVertice.find("#ddlItemZona_UTM").val('0000000');
        this.frmVertice.find("#txtItemVert_CEste").val('');
        this.frmVertice.find("#txtItemVert_CNorte").val('');
        this.frmVertice.find("#txtItemVert_Observacion").val('');
        this.frmVertice.find("#txtParcelaVertice").val('');

        this.frmVertice.find("#hdfItemVert_RegEstado").val(1);
        this.frmVertice.find("#hdCodSecuencialAdendaMod").val(0);
        this.frmVertice.find("#hdOrigen").val('tbVertice');
        this.frmVertice.find("#btnRegistrarVertice").text('Aceptar');
    }
    this.filaEditarVertice = "";
    this.agregarVertice = function () {

        var valItemVert_Vertice = this.frmVertice.find("#txtItemVert_Vertice").val().trim();
        var valItemZona_UTM = this.frmVertice.find("#ddlItemZona_UTM").val();
        var textItemZona_UTM = this.frmVertice.find("#ddlItemZona_UTM option:selected").text().trim();
        var valItemVert_CEste = this.frmVertice.find("#txtItemVert_CEste").val().trim();
        var valItemVert_CNorte = this.frmVertice.find("#txtItemVert_CNorte").val().trim();
        var valItemVert_Observacion = this.frmVertice.find("#txtItemVert_Observacion").val().trim().toUpperCase();
        var valEstadoOpcion = this.frmVertice.find("#hdfItemVert_RegEstado").val();
        var valpca = this.frmVertice.find("#txtParcelaVertice").val();
        var estadoItemReg = 1;
        if (parseInt(valEstadoOpcion) === 1) { //agregar registro tabla  
            var $rows = ManPOA.dtItemVertice.$("tr");
            var codSecC = $rows.length + 1;
            var fila = {
                "VERTICE": valItemVert_Vertice,
                "ZONA": textItemZona_UTM,
                "COORDENADA_ESTE": valItemVert_CEste,
                "COORDENADA_NORTE": valItemVert_CNorte,
                "PCA": valpca,
                "OBSERVACION": valItemVert_Observacion,
                "COD_SECUENCIAL": codSecC,
                "RegEstado": estadoItemReg

            };
            ManPOA.dtItemVertice.row.add(fila).draw();
            ManPOA.dtItemVertice.page('last').draw('page');


        }
        else {//modificar registro tabla y verificar data origen bd

            if (this.filaEditarVertice != "") {
                var estadoRegisItemSelec = this.filaEditarVertice.find(".hdEstadoItemGen").val();
                if (parseInt(estadoRegisItemSelec) == 0) estadoItemReg = 2;
                //modificando
                this.filaEditarVertice.find(".hdEstadoItemGen").val(estadoItemReg);
                this.filaEditarVertice.find(".hdDdlItemZona_UTM").val(valItemZona_UTM);
                var columnasFila = this.filaEditarVertice.find('td');
                columnasFila.eq(3).html(valItemVert_Vertice);
                columnasFila.eq(4).html(textItemZona_UTM);
                columnasFila.eq(5).html(valItemVert_CEste);
                columnasFila.eq(6).html(valItemVert_CNorte);
                columnasFila.eq(7).html(valpca);
                columnasFila.eq(8).html(valItemVert_Observacion);
                this.limpiarControles();
                this.filaEditarVertice = ""; //limpiando fila temporal
                $('#PDivItemVertice').modal('hide');
            }
            else {
                utilSigo.toastWarning("Aviso", "No hay datos a modificar");
            }
        }
    }
    this.eliminarVerticeTablaAll = function () {

        var $trsEliminar = ManPOA.dtItemVertice.$("tr");
        if ($trsEliminar.length > 0) {
            utilSigo.dialogConfirm("", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {
                    $.each($trsEliminar, function (i, o) {
                        var estadoItemBD = $(o).find(".hdEstadoItemGen").val();
                        if (parseInt(estadoItemBD) == 0 || parseInt(estadoItemBD) == 2) {
                            var $columna = $(o).find('td');
                            ManPOA.ListEliTABLA.push({
                                EliTABLA: "POA_DET_VERTICE",
                                EliVALOR01: $columna.eq(3).text().trim(),
                                EliVALOR02: $(o).find(".hdCodSecuencial").val().trim(),
                                EliVALOR03: ""
                            });
                        }
                    });


                    ManPOA.dtItemVertice.clear().draw();
                }
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }

    this.agregarVerticeExcel = function (data) {
        var $rows = ManPOA.dtItemVertice.$("tr");
        var codSecC = $rows.length + 1;
        /*se agrega para la validacion*/
        var band = 0;
        var parcela = _frmParcela.fnGetList();
        var countFilas = parcela.length;


        for (var i = 0; i < data.length; i++) {

            var fila = {
                "VERTICE": data[i].VERTICE,
                "ZONA": data[i].ZONA,
                "COORDENADA_ESTE": data[i].COORDENADA_ESTE,
                "COORDENADA_NORTE": data[i].COORDENADA_NORTE,
                "OBSERVACION": data[i].OBSERVACION,
                "COD_SECUENCIAL": codSecC,
                "PCA": data[i].PCA,
                "RegEstado": 1
            }
            band = 0;
            if (countFilas > 0) {
                for (var j = 0; j < parcela.length; j++) {
                    if (data[i].PCA == parcela[j].PCA) {
                        band = 1;
                    }
                }
            }
            if (band == 1) {
                ManPOA.dtItemVertice.row.add(fila).draw();
            }
            else {
                utilSigo.toastWarning("Error", "La parcela " + data[i].PCA + " no esta registrado");
            }
            codSecC++;
        }
        ManPOA.dtItemVertice.page('last').draw('page');

    }

    this.descargarPlantilla = function () {
        window.location.href = urlLocalSigo + "THabilitante/ManPOA/Download";
    }
    this.exportarVerticeExcel = function (codTHabilitante, numPoa) {


        $.ajax({
            url: ManPOA.controller + "/ExportarExcelVertices",
            type: 'POST',
            data: {
                COD_THABILITANTE: codTHabilitante,
                NumPoa: numPoa
            },
            dataType: 'json',
            success: function (data) {
                //  utilSigo.unblockUIGeneral();
                if (data.success) {
                    window.location.href = ManPOA.controller + "/DownloadVertices?file=" + data.values[0];
                }
                else utilSigo.toastWarning("Error", data.msj);
            },
            //beforeSend: function () {
            //    utilSigo.blockUIGeneral();
            //},
            error: function (jqXHR, error, errorThrown) {
                // utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                //console.log(jqXHR.responseText);
            }
        });

    }
    this.eliminarVerticeTabla = function (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?", function (r) {
            if (r) {
                var $trEliminar = $(obj).closest('tr');
                var estadoRegisItemSelec = $trEliminar.find(".hdEstadoItemGen").val();
                if (parseInt(estadoRegisItemSelec) == 0 || parseInt(estadoRegisItemSelec) == 2) {//guardando filas que vinieron de la bd en un temporal
                    var columnasFila = $trEliminar.find('td');
                    ManPOA.ListEliTABLA.push({
                        EliTABLA: "POA_DET_VERTICE",
                        EliVALOR01: columnasFila.eq(3).text().trim(),
                        EliVALOR02: $trEliminar.find(".hdCodSecuencial").val().trim(),
                        EliVALOR03: ""
                    });
                }
                //eliminando
                ManPOA.dtItemVertice.row($trEliminar).remove().draw();
                utilSigo.enumTB(ManPOA.dtItemVertice, 2);
            }
        });
    };
    this.editVertice = function (obj) {
        this.ddListarPCVertice();
        this.frmVertice.find("#btnRegistrarVertice").text('Modificar');
        this.filaEditarVertice = $(obj).closest('tr');
        var filaEdit = this.filaEditarVertice;
        //asignando valor a modificar
        var columnasEdit = filaEdit.find('td');
        //console.log(columnasEdit);
        this.frmVertice.find("#txtItemVert_Vertice").val(columnasEdit.eq(3).text().trim());
        this.frmVertice.find("#ddlItemZona_UTM").val(filaEdit.find(".hdDdlItemZona_UTM").val());
        this.frmVertice.find("#txtItemVert_CEste").val(columnasEdit.eq(5).text().trim());
        this.frmVertice.find("#txtItemVert_CNorte").val(columnasEdit.eq(6).text().trim());
        this.frmVertice.find("#txtItemVert_Observacion").val(columnasEdit.eq(8).text().trim());
        this.frmVertice.find("#txtParcelaVertice").val(columnasEdit.eq(7).text().trim());

        this.frmVertice.find("#hdfItemVert_RegEstado").val(0);
        this.frmVertice.find("#hdOrigen").val('tbVertice');
        // mostrando modal
        utilSigo.modalDraggable($("#PDivItemVertice"), '.modal-header');
        $("#PDivItemVertice").modal({ keyboard: true, backdrop: 'static' });
    };


}).apply(ManPOA.DGeneral);
//objeto fileupload
(function () {

    this.fileSelectHandler = function (e, control, url, TVentana) {

        if (e.dataTransfer != undefined &&
            e.dataTransfer.files != undefined) {

            this.resetFileSelect(control, url, TVentana);
        }
        // fetch FileList object
        var files = e.target.files || e.dataTransfer.files;

        if (files != undefined && files.length > 0) {
            this.uploadFileToServer(files[0], control, url, TVentana);
        }
    }
    this.resetFileSelect = function (control, url, TVentana) {
        if (TVentana == "BExt_MadeNoMade" || TVentana == "RAPROBMADE") {
            $("#" + control).replaceWith('<input type="file" id="' + control + '" name="' + control + '" class="form-control" style="display:none;"  onchange="ManPOA.ItemBExt.ItemExcelImportarVentana(event,this,\'' + TVentana + '\')"  onclick="return ManPOA.ItemBExt.ValidacionItemExcelImportarVentana(event,this,\'' + TVentana + '\')" />');
        }
        else {
            $("#" + control).replaceWith('<input type="file" id="' + control + '" name="' + control + '" class="form-control" style="display:none;"  onchange="ManPOA.ItemBExtMaderable.ItemExcelImportarVentana(event,this,\'' + TVentana + '\')"  onclick="return ManPOA.ItemBExtMaderable.ValidacionItemExcelImportarVentana(event,this,\'' + TVentana + '\')" />');
        }
    }

    this.uploadFileToServer = function (file, control, url, TVentana) {
        var formdata = new FormData();
        formdata.append(file.name, file);
        formdata.append("TVentana", TVentana);
        formdata.append("hdfItemEstadoOrigen", ManPOA.frmPOARegistro.find("#hdfItemEstadoOrigen").val());
        formdata.append("hdfItemIndicador", ManPOA.frmPOARegistro.find("#hdfItemIndicador").val());
        formdata.append("hdfItemCod_MTipo", ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val());

        $.ajax({
            url: url,
            type: 'POST',
            data: formdata,
            contentType: false,
            dataType: 'json',
            processData: false,
            success: function (data) {
                ManPOA.uploadFile.resetFileSelect(control, url, TVentana);
                //  utilSigo.unblockUIGeneral();
                if (data.success) {
                    //cargando data
                    if (data.data.length > 0) {
                        if (TVentana == 'VERTICE')
                            ManPOA.DGeneral.agregarVerticeExcel(data.data);
                        if (TVentana == "RAPROBMADE")
                            ManPOA.ItemRAPoa.addRowsDtExcel(data.data);
                        if (TVentana == "BEMADE")
                            ManPOA.ItemBExtMaderable.addRowsDtExcel(data.data);
                        if (TVentana == "BENOMADE")
                            ManPOA.ItemBExtNoMaderable.addRowsDtExcel(data.data);
                        if (TVentana == "BEINSITU")
                            ManPOA.ItemBExtISitu.addRowsDtExcel(data.data);
                        if (TVentana == "RAPROBINSITU")
                            ManPOA.ItemRAPoaInSitu.addRowsDtExcel(data.data);
                        if (TVentana == "CMADE")
                            ManPOA.ItemCMaderable.addRowsDtExcel(data.data);
                        if (TVentana == "CNOMADE")
                            ManPOA.ItemCNoMaderable.addRowsDtExcel(data.data);
                        if (TVentana == "BExt_MadeNoMade")
                            ManPOA.ItemBExt.addRowsDtExcel(data.data);

                        //utilSigo.toastSuccess("Aviso", "Se Subio Correctamente la Informacion");
                    }
                    else {
                        utilSigo.toastWarning("Aviso", "No hay registros en la plantilla");
                    }
                }
                else utilSigo.toastWarning("Aviso", data.msj);
            },
            beforeSend: function () {
                ManPOA.uploadFile.resetFileSelect(control, url, TVentana);
                //  utilSigo.blockUIGeneral();
            },
            error: function (jqXHR, error, errorThrown) {
                //  utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                //console.log(jqXHR.responseText);
            }
        });
    }


}).apply(ManPOA.uploadFile);

//BExt
(function () {
    this.dtItemBExt;
    this.columns;
    this.frmBExt;
    this.divModal;
    this.tr;
    this.band;

    this.init = function () {

        this.frmBExt = $("#frmBExt");
        this.divModal = $("#PDivItemBExt");
        var hdfItemEstadoOrigen = ManPOA.frmPOARegistro.find("#hdfItemEstadoOrigen").val();
        var hdfItemIndicador = ManPOA.frmPOARegistro.find("#hdfItemIndicador").val();
        var hdfItemCod_MTipo = ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val();
        this.band = 0;

        this.dtItemBExt = ManPOA.frmPOARegistro.find("#grvItemBExt").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bInfo: false,
            bLengthChange: false,
            scrollCollapse: true,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns: ManPOA.ItemBExt.columns
        });

        this.frmBExt.find('#ddlItemBExtEspecies').select2();
        this.frmBExt.find('#ddlItemBExtEspecies_Serfor').select2();

        if (
            (hdfItemEstadoOrigen == "PN" && hdfItemIndicador == "NM") ||
            (hdfItemEstadoOrigen == "PCN")
        ) {
            if (hdfItemCod_MTipo != "0000021" && hdfItemCod_MTipo != "0000020") {
                $(this.dtItemBExt.column(17).header()).text("UM");
            }
        }
        else $(this.dtItemBExt.column(17).header()).text("UM");

        this.frmBExt.find("#ddlTipo_BExt").change(function () {
            ManPOA.ItemBExt.FiltrarTipoAprovechamiento(this.value);
        });
    }
    this.CalculaTotal = function () {
        //Tipo de Aprovechamiento: Maderable
        ManPOA.frmPOARegistro.find("#colM5").text("Total (MADERABLES)");
        ManPOA.frmPOARegistro.find("#colM6").text(0);
        ManPOA.frmPOARegistro.find("#colM7").text(0);
        ManPOA.frmPOARegistro.find("#colM8").text(0);
        ManPOA.frmPOARegistro.find("#colM9").text(0);
        ManPOA.frmPOARegistro.find("#colM10").text(0);
        ManPOA.frmPOARegistro.find("#colM11").text(0);
        ManPOA.frmPOARegistro.find("#colM16").text(0);
        ManPOA.frmPOARegistro.find("#colM17").text(0);
        //Tipo de Aprovechamiento: Carbón
        ManPOA.frmPOARegistro.find("#colC5").text("Total (CARBON)");
        ManPOA.frmPOARegistro.find("#colC6").text(0);
        ManPOA.frmPOARegistro.find("#colC7").text(0);
        ManPOA.frmPOARegistro.find("#colC8").text(0);
        ManPOA.frmPOARegistro.find("#colC9").text(0);
        ManPOA.frmPOARegistro.find("#colC10").text(0);
        ManPOA.frmPOARegistro.find("#colC11").text(0);
        ManPOA.frmPOARegistro.find("#colC16").text(0);
        ManPOA.frmPOARegistro.find("#colC17").text(0);
        //Tipo de Aprovechamiento: No Maderable
        ManPOA.frmPOARegistro.find("#colNoM5").text("Total (NO MADERABLES)");
        ManPOA.frmPOARegistro.find("#colNoM6").text(0);
        ManPOA.frmPOARegistro.find("#colNoM7").text(0);
        ManPOA.frmPOARegistro.find("#colNoM8").text(0);
        ManPOA.frmPOARegistro.find("#colNoM9").text(0);
        ManPOA.frmPOARegistro.find("#colNoM10").text(0);
        ManPOA.frmPOARegistro.find("#colNoM11").text(0);
        ManPOA.frmPOARegistro.find("#colNoM16").text(0);
        ManPOA.frmPOARegistro.find("#colNoM17").text(0);

        var cM6 = 0, cM7 = 0, cM8 = 0, cM9 = 0, cM10 = 0, cM11 = 0, cM16 = 0, cM17 = 0;
        var cC6 = 0, cC7 = 0, cC8 = 0, cC9 = 0, cC10 = 0, cC11 = 0, cC16 = 0, cC17 = 0;
        var cNoM6 = 0, cNoM7 = 0, cNoM8 = 0, cNoM9 = 0, cNoM10 = 0, cNoM11 = 0, cNoM16 = 0, cNoM17 = 0;
        var contM = 0, contC = 0, contNoM = 0;

        var $tbdtItemBExt = this.dtItemBExt.$("tr");

        if ($tbdtItemBExt.length > 0) {
            var $tr, row;
            $.each($tbdtItemBExt, function (i, o) {
                $tr = $(o).closest('tr');
                row = ManPOA.ItemBExt.dtItemBExt.row($tr).data();

                switch (row.TIPOMADERABLE) {
                    case "MADERABLES":
                        cM6 += parseInt(row.DMC); cM7 += parseInt(row.TOTAL_ARBOLES); cM8 += parseFloat(row.VOLUMEN_AUTORIZADO);
                        cM9 += parseFloat(row.VOLUMEN_MOVILIZADO);
                        cM10 += parseFloat((row.AUTORIZADO == "") ? 0 : row.AUTORIZADO);
                        cM11 += parseFloat((row.EXTRAIDO == "") ? 0 : row.EXTRAIDO);
                        cM16 += parseFloat(row.SALDO);
                        cM17 += parseInt((row.CANTIDAD == "") ? 0 : row.CANTIDAD);
                        contM++;
                        break;

                    case "CARBON":
                        cC6 += parseInt(row.DMC); cC7 += parseInt(row.TOTAL_ARBOLES); cC8 += parseFloat(row.VOLUMEN_AUTORIZADO);
                        cC9 += parseFloat(row.VOLUMEN_MOVILIZADO);
                        cC10 += parseFloat((row.AUTORIZADO == "") ? 0 : row.AUTORIZADO);
                        cC11 += parseFloat((row.EXTRAIDO == "") ? 0 : row.EXTRAIDO);
                        cC16 += parseFloat(row.SALDO);
                        cC17 += parseInt((row.CANTIDAD == "") ? 0 : row.CANTIDAD);
                        contC++;
                        break;

                    case "NO MADERABLES":
                        cNoM6 += parseInt((row.DMC == "") ? 0 : row.DMC); cNoM7 += parseInt((row.TOTAL_ARBOLES == "") ? 0 : row.TOTAL_ARBOLES); cNoM8 += parseFloat((row.VOLUMEN_AUTORIZADO == "") ? 0 : row.VOLUMEN_AUTORIZADO);
                        cNoM9 += parseFloat((row.VOLUMEN_MOVILIZADO == "") ? 0 : row.VOLUMEN_MOVILIZADO); cNoM10 += parseFloat((row.AUTORIZADO == "") ? 0 : row.AUTORIZADO);
                        cNoM11 += parseFloat((row.EXTRAIDO == "") ? 0 : row.EXTRAIDO); cNoM16 += parseFloat((row.SALDO == "") ? 0 : row.SALDO); cNoM17 += parseInt((row.CANTIDAD == "") ? 0 : row.CANTIDAD);
                        contNoM++;
                        break;
                }
            });

            if (contM > 0) {
                ManPOA.frmPOARegistro.find("#totalMaderable").show();
                ManPOA.frmPOARegistro.find("#colM6").text(cM6);
                ManPOA.frmPOARegistro.find("#colM7").text(cM7);
                ManPOA.frmPOARegistro.find("#colM8").text(this.intlRound(cM8, 3));
                ManPOA.frmPOARegistro.find("#colM9").text(this.intlRound(cM9, 3));
                ManPOA.frmPOARegistro.find("#colM10").text(this.intlRound(cM10, 3));
                ManPOA.frmPOARegistro.find("#colM11").text(this.intlRound(cM11, 3));
                ManPOA.frmPOARegistro.find("#colM16").text(this.intlRound(cM16, 3));
                ManPOA.frmPOARegistro.find("#colM17").text(cM17);
            }
            else ManPOA.frmPOARegistro.find("#totalMaderable").hide();
            if (contC > 0) {
                ManPOA.frmPOARegistro.find("#totalCarbon").show();
                ManPOA.frmPOARegistro.find("#colC6").text(cC6);
                ManPOA.frmPOARegistro.find("#colC7").text(cC7);
                ManPOA.frmPOARegistro.find("#colC8").text(this.intlRound(cC8, 3));
                ManPOA.frmPOARegistro.find("#colC9").text(this.intlRound(cC9, 3));
                ManPOA.frmPOARegistro.find("#colC10").text(this.intlRound(cC10, 3));
                ManPOA.frmPOARegistro.find("#colC11").text(this.intlRound(cC11, 3));
                ManPOA.frmPOARegistro.find("#colC16").text(this.intlRound(cC16, 3));
                ManPOA.frmPOARegistro.find("#colC17").text(cC17);
            }
            else ManPOA.frmPOARegistro.find("#totalCarbon").hide();
            if (contNoM > 0) {
                ManPOA.frmPOARegistro.find("#totalNoMaderable").show();
                ManPOA.frmPOARegistro.find("#colNoM6").text(cNoM6);
                ManPOA.frmPOARegistro.find("#colNoM7").text(cNoM7);
                ManPOA.frmPOARegistro.find("#colNoM8").text(this.intlRound(cNoM8, 3));
                ManPOA.frmPOARegistro.find("#colNoM9").text(this.intlRound(cNoM9, 3));
                ManPOA.frmPOARegistro.find("#colNoM10").text(this.intlRound(cNoM10, 3));
                ManPOA.frmPOARegistro.find("#colNoM11").text(this.intlRound(cNoM11, 3));
                ManPOA.frmPOARegistro.find("#colNoM16").text(this.intlRound(cNoM16, 3));
                ManPOA.frmPOARegistro.find("#colNoM17").text(cNoM17);
            }
            else ManPOA.frmPOARegistro.find("#totalNoMaderable").hide();
        }
        else {
            ManPOA.frmPOARegistro.find("#totalMaderable").hide();
            ManPOA.frmPOARegistro.find("#totalCarbon").hide();
            ManPOA.frmPOARegistro.find("#totalNoMaderable").hide();
        }
    }
    this.intlRound = function (numero, decimales, usarComa = false) {
        var opciones = {
            maximumFractionDigits: decimales,
            useGrouping: false
        };
        usarComa = usarComa ? "es" : "en";
        return new Intl.NumberFormat(usarComa, opciones).format(numero);
    }
    this.ItemExcelImportarVentana = function (e, objeto, TVentana) {
        var idFile = $(objeto).attr("id");
        var ruta = ManPOA.controller + "/ImportarDataExcel";
        ManPOA.uploadFile.fileSelectHandler(e, idFile, ruta, TVentana);
    }
    this.ValidacionItemExcelImportarVentana = function (e, objeto, TVentana) {
        if (TVentana == 'BExt_MadeNoMade' || TVentana == 'BEINSITU') {
            if (ManPOA.frmPOARegistro.find("#hdfSelectBExtPOA_Index").val() == '') {
                utilSigo.toastError("Error", "Seleccione la fecha de emisión del balance al que pertenece el registro");
                return false;
            }
        }
        return true;
    }

    this.cellEdit = function (data, type, row) {
        return '<i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Editar" onclick="ManPOA.ItemBExt.showModal(0,this);"></i>';

    }
    this.cellDel = function (data, type, row) {
        return '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManPOA.ItemBExt.eliminar(this);"></i>';
    }
    this.FiltrarTipoAprovechamiento = function (value) {

        if (this.band == 1) {
            var hdfItemCod_MTipo = ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val();

            if (value == "MADERABLES" || value == "CARBON") {
                this.frmBExt.find("#trDMC").toggle(true);
                this.frmBExt.find("#trTotalArboles").toggle(true);
                this.frmBExt.find("#trkgAutorizadoBalance").toggle(true);
                this.frmBExt.find("#trKgMovilizadoBalance").toggle(true);
                this.frmBExt.find("#trAutorizadoBalance").toggle(false);
                this.frmBExt.find("#trExtraidoBalance").toggle(false);
                this.frmBExt.find("#trCarrizoFecha").toggle(false);
                this.frmBExt.find("#trCarrizoGTF").toggle(false);
                this.frmBExt.find("#trCarrizoFecha2").toggle(false);
                this.frmBExt.find("#trCarrizoRecibo").toggle(false);
                this.frmBExt.find("#trCarrizoCantidad").toggle(false);
                this.frmBExt.find("#trBExtSaldo").toggle(true);
                this.frmBExt.find("#trBExtUnidadMedida").toggle(true);
                this.frmBExt.find("#trBExtObservacion").toggle(true);

                if (value == "MADERABLES") this.frmBExt.find("#ddlUnidadMedida_BExt").val("M3");
                else this.frmBExt.find("#ddlUnidadMedida_BExt").val("KG");

                this.frmBExt.find("#ddlUnidadMedida_BExt").attr("disabled", true);
            }
            else if (value == "NO MADERABLES") {
                this.frmBExt.find("#trDMC").toggle(false);
                this.frmBExt.find("#trTotalArboles").toggle(false);
                this.frmBExt.find("#trBExtSaldo").toggle(true);
                this.frmBExt.find("#trBExtObservacion").toggle(true);

                if (hdfItemCod_MTipo == "0000021") {
                    this.frmBExt.find("#trkgAutorizadoBalance").toggle(false);
                    this.frmBExt.find("#trKgMovilizadoBalance").toggle(false);
                    this.frmBExt.find("#trAutorizadoBalance").toggle(true);
                    this.frmBExt.find("#trExtraidoBalance").toggle(true);
                    this.frmBExt.find("#trCarrizoFecha").toggle(false);
                    this.frmBExt.find("#trCarrizoGTF").toggle(false);
                    this.frmBExt.find("#trCarrizoFecha2").toggle(false);
                    this.frmBExt.find("#trCarrizoRecibo").toggle(false);
                    this.frmBExt.find("#trCarrizoCantidad").toggle(false);
                    this.frmBExt.find("#trBExtUnidadMedida").toggle(true);

                    this.frmBExt.find("#ddlUnidadMedida_BExt").val("KG");
                    this.frmBExt.find("#ddlUnidadMedida_BExt").attr("disabled", true);
                }
                else if (hdfItemCod_MTipo == "0000020") {
                    this.frmBExt.find("#trkgAutorizadoBalance").toggle(false);
                    this.frmBExt.find("#trKgMovilizadoBalance").toggle(false);
                    this.frmBExt.find("#trAutorizadoBalance").toggle(false);
                    this.frmBExt.find("#trExtraidoBalance").toggle(false);
                    this.frmBExt.find("#trCarrizoFecha").toggle(true);
                    this.frmBExt.find("#trCarrizoGTF").toggle(true);
                    this.frmBExt.find("#trCarrizoFecha2").toggle(true);
                    this.frmBExt.find("#trCarrizoRecibo").toggle(true);
                    this.frmBExt.find("#trCarrizoCantidad").toggle(true);
                    this.frmBExt.find("#trBExtUnidadMedida").toggle(false);

                    this.frmBExt.find("#ddlUnidadMedida_BExt").val("-");
                }
                else {
                    this.frmBExt.find("#trkgAutorizadoBalance").toggle(true);
                    this.frmBExt.find("#trKgMovilizadoBalance").toggle(true);
                    this.frmBExt.find("#trAutorizadoBalance").toggle(false);
                    this.frmBExt.find("#trExtraidoBalance").toggle(false);
                    this.frmBExt.find("#trCarrizoFecha").toggle(false);
                    this.frmBExt.find("#trCarrizoGTF").toggle(false);
                    this.frmBExt.find("#trCarrizoFecha2").toggle(false);
                    this.frmBExt.find("#trCarrizoRecibo").toggle(false);
                    this.frmBExt.find("#trCarrizoCantidad").toggle(false);
                    this.frmBExt.find("#trBExtUnidadMedida").toggle(true);

                    this.frmBExt.find("#ddlUnidadMedida_BExt").val("KG");
                    this.frmBExt.find("#ddlUnidadMedida_BExt").attr("disabled", true);
                }
            }
            else {
                this.frmBExt.find("#trDMC").toggle(false);
                this.frmBExt.find("#trTotalArboles").toggle(false);
                this.frmBExt.find("#trkgAutorizadoBalance").toggle(false);
                this.frmBExt.find("#trKgMovilizadoBalance").toggle(false);
                this.frmBExt.find("#trAutorizadoBalance").toggle(false);
                this.frmBExt.find("#trExtraidoBalance").toggle(false);
                this.frmBExt.find("#trCarrizoFecha").toggle(false);
                this.frmBExt.find("#trCarrizoGTF").toggle(false);
                this.frmBExt.find("#trCarrizoFecha2").toggle(false);
                this.frmBExt.find("#trCarrizoRecibo").toggle(false);
                this.frmBExt.find("#trCarrizoCantidad").toggle(false);
                this.frmBExt.find("#trBExtSaldo").toggle(false);
                this.frmBExt.find("#trBExtUnidadMedida").toggle(false);
                this.frmBExt.find("#trBExtObservacion").toggle(false);

                this.frmBExt.find("#ddlUnidadMedida_BExt").val("-");
            }

            this.frmBExt.find("#txtItemBExtDmc").val('');
            this.frmBExt.find("#txtItemBExtTotal_Arboles").val('');
            this.frmBExt.find("#txtItemBExtVolumen_Autorizado").val('');
            this.frmBExt.find("#txtItemBExtVolumen_Movilizado").val('');
            this.frmBExt.find("#txtItemBExtAutorizado").val('');
            this.frmBExt.find("#txtItemBExtExtraido").val('');
            this.frmBExt.find("#txtFechaKardexCarrizo").val('');
            this.frmBExt.find("#txtGTFKarcexCarrizo").val('');
            this.frmBExt.find("#txtFechaKardexCarrizo2").val('');
            this.frmBExt.find("#txtReciboKardexCarrizo").val('');
            this.frmBExt.find("#txtCantidadKardexCarrizo").val('');
            this.frmBExt.find("#txtItemBExtSaldo").val('');
            this.frmBExt.find("#txtItemBExtObservacion").val('');
        }
        else {
            var hdfItemEstadoOrigen = ManPOA.frmPOARegistro.find("#hdfItemEstadoOrigen").val();
            var hdfItemIndicador = ManPOA.frmPOARegistro.find("#hdfItemIndicador").val();

            if (
                (hdfItemEstadoOrigen == "PN" && hdfItemIndicador == "M") ||
                (hdfItemEstadoOrigen == "R") ||
                (hdfItemEstadoOrigen == "MS") ||
                (hdfItemEstadoOrigen == "PC")
            ) {
                if (value == "MADERABLES") {
                    this.frmBExt.find("#ddlUnidadMedida_BExt").val("M3");
                    this.frmBExt.find("#ddlUnidadMedida_BExt").attr("disabled", true);
                }
                else if (value == "CARBON") {
                    this.frmBExt.find("#ddlUnidadMedida_BExt").val("KG");
                    this.frmBExt.find("#ddlUnidadMedida_BExt").attr("disabled", true);
                }
                else {
                    this.frmBExt.find("#ddlUnidadMedida_BExt").val("-");
                    this.frmBExt.find("#ddlUnidadMedida_BExt").attr("disabled", false);
                }
            }
        }
    }

    this.showModal = function (RegEstado, obj) {
        if (ManPOA.frmPOARegistro.find("#hdfSelectBExtPOA_Index").val() != '') {
            var PDivTitulo = '';
            var hdfItemEstadoOrigen = ManPOA.frmPOARegistro.find("#hdfItemEstadoOrigen").val();
            var hdfItemIndicador = ManPOA.frmPOARegistro.find("#hdfItemIndicador").val();
            var hdfItemCod_MTipo = ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val();

            if (
                (hdfItemEstadoOrigen == "PN" && hdfItemIndicador == "M") ||
                (hdfItemEstadoOrigen == "R") ||
                (hdfItemEstadoOrigen == "MS") ||
                (hdfItemEstadoOrigen == "PC")
            ) {
                if (RegEstado == 1) {
                    PDivTitulo = 'Nuevo Registro';
                }
                else if (RegEstado == 0) {
                    PDivTitulo = 'Modificando Registro';
                }
                this.frmBExt.find("#trAutorizadoBalance").toggle(false);
                this.frmBExt.find("#trExtraidoBalance").toggle(false);
                this.frmBExt.find("#trCarrizoFecha").toggle(false);
                this.frmBExt.find("#trCarrizoGTF").toggle(false);
                this.frmBExt.find("#trCarrizoFecha2").toggle(false);
                this.frmBExt.find("#trCarrizoRecibo").toggle(false);
                this.frmBExt.find("#trCarrizoCantidad").toggle(false);
                this.frmBExt.find("#optNoMaderable").toggle(false);
            }
            else if (
                (hdfItemEstadoOrigen == "PN" && hdfItemIndicador == "NM") ||
                (hdfItemEstadoOrigen == "PCN")
            ) {
                if (hdfItemCod_MTipo == "0000021") {
                    if (RegEstado == 1) {
                        PDivTitulo = 'Nuevo Registro - Productos Forestales No Maderables Plantas Medicinales';
                        this.frmBExt.find("#ddlUnidadMedida_BExt").val("KG");
                    }
                    else if (RegEstado == 0) {
                        PDivTitulo = 'Modificando Registro - Productos Forestales No Maderables Plantas Medicinales';
                    }
                    this.frmBExt.find("#ddlUnidadMedida_BExt").attr("disabled", true);
                    this.frmBExt.find("#trkgAutorizadoBalance").toggle(false);
                    this.frmBExt.find("#trKgMovilizadoBalance").toggle(false);
                    this.frmBExt.find("#trCarrizoFecha").toggle(false);
                    this.frmBExt.find("#trCarrizoGTF").toggle(false);
                    this.frmBExt.find("#trCarrizoFecha2").toggle(false);
                    this.frmBExt.find("#trCarrizoRecibo").toggle(false);
                    this.frmBExt.find("#trCarrizoCantidad").toggle(false);
                }
                else if (hdfItemCod_MTipo == "0000020") {
                    if (RegEstado == 1) {
                        PDivTitulo = 'Nuevo Registro - Productos Forestales No Maderables Carrizo';
                        this.frmBExt.find("#ddlUnidadMedida_BExt").val("-");
                    }
                    else if (RegEstado == 0) {
                        PDivTitulo = 'Modificando Registro - Productos Forestales No Maderables Carrizo';
                    }
                    this.frmBExt.find("#trkgAutorizadoBalance").toggle(false);
                    this.frmBExt.find("#trKgMovilizadoBalance").toggle(false);
                    this.frmBExt.find("#trAutorizadoBalance").toggle(false);
                    this.frmBExt.find("#trExtraidoBalance").toggle(false);
                    this.frmBExt.find("#trBExtUnidadMedida").toggle(false);
                }
                else {
                    if (RegEstado == 1) {
                        PDivTitulo = 'Nuevo Registro - No Maderable';
                        this.frmBExt.find("#ddlUnidadMedida_BExt").val("KG");
                    }
                    else if (RegEstado == 0) {
                        PDivTitulo = 'Modificando Registro - No Maderable';
                    }
                    this.frmBExt.find("#ddlUnidadMedida_BExt").attr("disabled", true);
                    this.frmBExt.find("#trAutorizadoBalance").toggle(false);
                    this.frmBExt.find("#trExtraidoBalance").toggle(false);
                    this.frmBExt.find("#trCarrizoFecha").toggle(false);
                    this.frmBExt.find("#trCarrizoGTF").toggle(false);
                    this.frmBExt.find("#trCarrizoFecha2").toggle(false);
                    this.frmBExt.find("#trCarrizoRecibo").toggle(false);
                    this.frmBExt.find("#trCarrizoCantidad").toggle(false);
                }

                this.frmBExt.find("#trDMC").toggle(false);
                this.frmBExt.find("#trTotalArboles").toggle(false);
                this.frmBExt.find("#ddlTipo_BExt").val("NO MADERABLES");
                this.frmBExt.find("#trTipoBalance").toggle(false);
            }
            else {
                if (RegEstado == 1) {
                    PDivTitulo = 'Nuevo Registro';
                    this.frmBExt.find("#ddlTipo_BExt").attr("disabled", false);
                }
                else if (RegEstado == 0) {
                    PDivTitulo = 'Modificando Registro';
                    this.frmBExt.find("#ddlTipo_BExt").attr("disabled", true);
                }

                this.frmBExt.find("#trEspecieSERFOR").after(this.frmBExt.find("#trTipoBalance"));
                this.frmBExt.find("#trDMC").toggle(false);
                this.frmBExt.find("#trTotalArboles").toggle(false);
                this.frmBExt.find("#trkgAutorizadoBalance").toggle(false);
                this.frmBExt.find("#trKgMovilizadoBalance").toggle(false);
                this.frmBExt.find("#trAutorizadoBalance").toggle(false);
                this.frmBExt.find("#trExtraidoBalance").toggle(false);
                this.frmBExt.find("#trCarrizoFecha").toggle(false);
                this.frmBExt.find("#trCarrizoGTF").toggle(false);
                this.frmBExt.find("#trCarrizoFecha2").toggle(false);
                this.frmBExt.find("#trCarrizoRecibo").toggle(false);
                this.frmBExt.find("#trCarrizoCantidad").toggle(false);
                this.frmBExt.find("#trBExtSaldo").toggle(false);
                this.frmBExt.find("#trBExtUnidadMedida").toggle(false);
                this.frmBExt.find("#trBExtObservacion").toggle(false);
                this.band = 1;
            }

            if (RegEstado == 0) {
                var $tr = $(obj).closest('tr');
                this.tr = $tr;

                var row = this.dtItemBExt.row($tr).data();
                this.frmBExt.find("#ddlItemBExtEspecies").val(row.COD_ESPECIES).trigger("change");
                this.frmBExt.find("#ddlItemBExtEspecies_Serfor").val(row.COD_ESPECIES_SERFOR).trigger("change");
                this.frmBExt.find("#ddlTipo_BExt").val(row.TIPOMADERABLE).trigger("change");

                this.frmBExt.find("#txtItemBExtDmc").val(row.DMC);
                this.frmBExt.find("#txtItemBExtTotal_Arboles").val(row.TOTAL_ARBOLES);
                this.frmBExt.find("#txtItemBExtVolumen_Autorizado").val(row.VOLUMEN_AUTORIZADO);
                this.frmBExt.find("#txtItemBExtVolumen_Movilizado").val(row.VOLUMEN_MOVILIZADO);
                this.frmBExt.find("#txtItemBExtAutorizado").val(row.AUTORIZADO);
                this.frmBExt.find("#txtItemBExtExtraido").val(row.EXTRAIDO);
                this.frmBExt.find("#txtFechaKardexCarrizo").val(row.FECHA1);
                this.frmBExt.find("#txtGTFKarcexCarrizo").val(row.GUIA_TRANSPORTE);
                this.frmBExt.find("#txtFechaKardexCarrizo2").val(row.FECHA2);
                this.frmBExt.find("#txtReciboKardexCarrizo").val(row.RECIBO);
                this.frmBExt.find("#txtCantidadKardexCarrizo").val(row.CANTIDAD);
                this.frmBExt.find("#txtItemBExtSaldo").val(row.SALDO);
                this.frmBExt.find("#ddlUnidadMedida_BExt").val(row.UNIDAD_MEDIDA);
                this.frmBExt.find("#txtItemBExtObservacion").val(row.OBSERVACION);
            }

            this.divModal.find(".spTitulo").html(PDivTitulo);
            this.frmBExt.find("#hdfItemBExt_RegEstado").val(RegEstado);

            utilSigo.modalDraggable(this.divModal, '.modal-header');
            this.divModal.modal({ keyboard: true, backdrop: 'static' });
        } else {
            utilSigo.toastError("Error", "Seleccione la fecha de emisión del balance al que pertenece el registro");
        }
    }
    this.cleanModal = function () {
        this.frmBExt.find("#txtItemBExtDmc").val('');//Maderable
        this.frmBExt.find("#txtItemBExtTotal_Arboles").val('');//Maderable
        this.frmBExt.find("#txtItemBExtVolumen_Autorizado").val('');
        this.frmBExt.find("#txtItemBExtVolumen_Movilizado").val('');
        this.frmBExt.find("#txtItemBExtAutorizado").val('');//No Maderable
        this.frmBExt.find("#txtItemBExtExtraido").val('');//No Maderable
        this.frmBExt.find("#txtFechaKardexCarrizo").val('');//No Maderable
        this.frmBExt.find("#txtGTFKarcexCarrizo").val('');//No Maderable
        this.frmBExt.find("#txtFechaKardexCarrizo2").val('');//No Maderable
        this.frmBExt.find("#txtReciboKardexCarrizo").val('');//No Maderable
        this.frmBExt.find("#txtCantidadKardexCarrizo").val('');//No Maderable
        this.frmBExt.find("#txtItemBExtSaldo").val('');
        this.frmBExt.find("#ddlTipo_BExt").val('-').trigger("change");//Maderable
        this.frmBExt.find("#ddlUnidadMedida_BExt").val('-');
        this.frmBExt.find("#txtItemBExtObservacion").val('');
        this.frmBExt.find("#ddlItemBExtEspecies").val('-').trigger("change");
        this.frmBExt.find("#ddlItemBExtEspecies_Serfor").val('-').trigger("change");
    }
    this.closeModal = function () {
        this.cleanModal();
        //limpiando estilos si lo tienen
        $(':input', this.frmBExt)
            .removeClass('border-danger')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title');

        $("#ddlItemBExtEspecies,#ddlItemBExtEspecies_Serfor").val("-").trigger("change");
        this.divModal.modal('hide');
    }
    this.validaSaveModal = function () {
        var hdfItemEstadoOrigen = ManPOA.frmPOARegistro.find("#hdfItemEstadoOrigen").val();
        var hdfItemIndicador = ManPOA.frmPOARegistro.find("#hdfItemIndicador").val();

        if (
            (hdfItemEstadoOrigen == "PN" && hdfItemIndicador == "M") ||
            (hdfItemEstadoOrigen == "R") ||
            (hdfItemEstadoOrigen == "MS") ||
            (hdfItemEstadoOrigen == "PC")
        ) {
            //if (this.frmBExt.find("#hdfItemBExt_RegEstado").val() == '1') {
            if (utilSigo.ValidaCombo("ddlItemBExtEspecies", "Seleccione Especie") == false) return false;
            //}
            if (utilSigo.ValidaTexto("txtItemBExtDmc", "Ingrese DMC") == false) return false;
            if (utilSigo.ValidaTexto("txtItemBExtTotal_Arboles", "Ingrese Total Arboles") == false) return false;
            if (utilSigo.ValidaTexto("txtItemBExtVolumen_Autorizado", "Ingrese Cantidad Autorizada") == false) return false;
            if (utilSigo.ValidaTexto("txtItemBExtVolumen_Movilizado", "Ingrese Cantidad Movilizado") == false) return false;
            if (utilSigo.ValidaTexto("txtItemBExtSaldo", "Ingrese Saldo") == false) return false;
            if (utilSigo.ValidaCombo("ddlTipo_BExt", "Seleccione el Tipo de Aprovechamiento") == false) return false;
        }
        else if (
            (hdfItemEstadoOrigen == "PN" && hdfItemIndicador == "NM") ||
            (hdfItemEstadoOrigen == "PCN")
        ) {
            //if (this.frmBExt.find("#hdfItemBExt_RegEstado").val() == '1') {
            if (utilSigo.ValidaCombo("ddlItemBExtEspecies", "Seleccione Especie") == false) return false;
            //}
        }
        else {
            //if (this.frmBExt.find("#hdfItemBExt_RegEstado").val() == '1') {
            if (utilSigo.ValidaCombo("ddlItemBExtEspecies", "Seleccione Especie") == false) return false;
            //}
            if (utilSigo.ValidaCombo("ddlTipo_BExt", "Seleccione el Tipo de Aprovechamiento") == false) return false;
            else {
                if (this.frmBExt.find("#ddlTipo_BExt").val() == "MADERABLES" || this.frmBExt.find("#ddlTipo_BExt").val() == "CARBON") {
                    if (utilSigo.ValidaTexto("txtItemBExtDmc", "Ingrese DMC") == false) return false;
                    if (utilSigo.ValidaTexto("txtItemBExtTotal_Arboles", "Ingrese Total Arboles") == false) return false;
                    if (utilSigo.ValidaTexto("txtItemBExtVolumen_Autorizado", "Ingrese Cantidad Autorizada") == false) return false;
                    if (utilSigo.ValidaTexto("txtItemBExtVolumen_Movilizado", "Ingrese Cantidad Movilizado") == false) return false;
                    if (utilSigo.ValidaTexto("txtItemBExtSaldo", "Ingrese Saldo") == false) return false;
                }
            }
        }

        return true;
    }
    this.saveModal = function () {
        if (this.validaSaveModal()) {
            var estado = this.frmBExt.find("#hdfItemBExt_RegEstado").val();

            if (estado == "1") {
                //Nuevo
                var codSecC = this.dtItemBExt.$("tr").length + 1;
                var hdfItemCod_MTipo = ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val();

                var fila = {
                    NRO: codSecC,
                    ESPECIES: this.frmBExt.find("#ddlItemBExtEspecies").select2('data')[0].text,
                    ESPECIES_SERFOR: this.frmBExt.find("#ddlItemBExtEspecies_Serfor").val() == "-" ? "" : this.frmBExt.find("#ddlItemBExtEspecies_Serfor").select2('data')[0].text,
                    DMC: this.frmBExt.find("#txtItemBExtDmc").val().trim(),
                    TOTAL_ARBOLES: this.frmBExt.find("#txtItemBExtTotal_Arboles").val().trim(),
                    VOLUMEN_AUTORIZADO: this.frmBExt.find("#txtItemBExtVolumen_Autorizado").val().trim(),
                    VOLUMEN_MOVILIZADO: this.frmBExt.find("#txtItemBExtVolumen_Movilizado").val().trim(),
                    AUTORIZADO: this.frmBExt.find("#txtItemBExtAutorizado").val().trim(),
                    EXTRAIDO: this.frmBExt.find("#txtItemBExtExtraido").val().trim(),
                    FECHA1: this.frmBExt.find("#txtFechaKardexCarrizo").val().trim(),
                    GUIA_TRANSPORTE: this.frmBExt.find("#txtGTFKarcexCarrizo").val().trim(),
                    FECHA2: this.frmBExt.find("#txtFechaKardexCarrizo2").val().trim(),
                    RECIBO: this.frmBExt.find("#txtReciboKardexCarrizo").val().trim(),
                    SALDO: this.frmBExt.find("#txtItemBExtSaldo").val().trim(),
                    CANTIDAD: this.frmBExt.find("#txtCantidadKardexCarrizo").val().trim(),
                    UNIDAD_MEDIDA: this.frmBExt.find("#ddlUnidadMedida_BExt").val().trim(),
                    OBSERVACION: this.frmBExt.find("#txtItemBExtObservacion").val().trim(),
                    TIPOMADERABLE: this.frmBExt.find("#ddlTipo_BExt").val().trim(),
                    COD_ESPECIES: this.frmBExt.find("#ddlItemBExtEspecies").val(),
                    COD_ESPECIES_SERFOR: this.frmBExt.find("#ddlItemBExtEspecies_Serfor").val(),
                    RegEstado: 1,
                    index: (codSecC - 1),
                    COD_SECUENCIAL: 0
                };

                if (ManPOA.indexBExtPOA === "") {
                    ManPOA.indexBExtPOA = "0";
                }

                ManPOA.listBExtPOA[ManPOA.indexBExtPOA].listMadeBEXTRACCION.push(fila);
                this.dtItemBExt.rows.add([fila]).draw();
                this.dtItemBExt.page('last').draw('page');
                utilSigo.toastSuccess("Exito", "Se añadió con exito");
                this.closeModal();
            }
            else {
                var row = this.dtItemBExt.row(this.tr).data();

                row.ESPECIES = this.frmBExt.find("#ddlItemBExtEspecies").select2('data')[0].text;
                row.ESPECIES_SERFOR = this.frmBExt.find("#ddlItemBExtEspecies_Serfor").val() == "-" ? "" : this.frmBExt.find("#ddlItemBExtEspecies_Serfor").select2('data')[0].text;
                row.DMC = this.frmBExt.find("#txtItemBExtDmc").val().trim();
                row.TOTAL_ARBOLES = this.frmBExt.find("#txtItemBExtTotal_Arboles").val().trim();
                row.VOLUMEN_AUTORIZADO = this.frmBExt.find("#txtItemBExtVolumen_Autorizado").val().trim();
                row.VOLUMEN_MOVILIZADO = this.frmBExt.find("#txtItemBExtVolumen_Movilizado").val().trim();
                row.AUTORIZADO = this.frmBExt.find("#txtItemBExtAutorizado").val().trim();
                row.EXTRAIDO = this.frmBExt.find("#txtItemBExtExtraido").val().trim();
                row.FECHA1 = this.frmBExt.find("#txtFechaKardexCarrizo").val().trim();
                row.GUIA_TRANSPORTE = this.frmBExt.find("#txtGTFKarcexCarrizo").val().trim();
                row.FECHA2 = this.frmBExt.find("#txtFechaKardexCarrizo2").val().trim();
                row.RECIBO = this.frmBExt.find("#txtReciboKardexCarrizo").val().trim();
                row.SALDO = this.frmBExt.find("#txtItemBExtSaldo").val().trim();
                row.CANTIDAD = this.frmBExt.find("#txtCantidadKardexCarrizo").val().trim();
                row.UNIDAD_MEDIDA = this.frmBExt.find("#ddlUnidadMedida_BExt").val().trim();
                row.OBSERVACION = this.frmBExt.find("#txtItemBExtObservacion").val().trim();
                row.TIPOMADERABLE = this.frmBExt.find("#ddlTipo_BExt").val().trim();
                row.COD_ESPECIES = this.frmBExt.find("#ddlItemBExtEspecies").val();
                row.COD_ESPECIES_SERFOR = this.frmBExt.find("#ddlItemBExtEspecies_Serfor").val();

                if (row.RegEstado == 0)
                    row.RegEstado = 2;

                ManPOA.listBExtPOA[ManPOA.indexBExtPOA].listMadeBEXTRACCION[row.index] = row;
                this.dtItemBExt.row(this.tr).data(row).draw(false);
                utilSigo.toastSuccess("Exito", "Se modificó con exito");
                this.closeModal();
            }
            ManPOA.ItemBExt.CalculaTotal();
        }
    }
    this.eliminar = function (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?",
            function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');
                    var row = ManPOA.ItemBExt.dtItemBExt.row($tr).data();

                    if (row.RegEstado == 0 || row.RegEstado == 2) {
                        ManPOA.ListEliTABLA.push({
                            EliTABLA: "POA_DET_MADERABLE_BEXTRACCION",
                            EliVALOR01: ManPOA.listBExtPOA[ManPOA.indexBExtPOA].COD_SECUENCIAL,
                            EliVALOR02: row.COD_SECUENCIAL
                        });
                    }

                    ManPOA.listBExtPOA[ManPOA.indexBExtPOA].listMadeBEXTRACCION.splice(row.index, 1);
                    for (var i = 0; i < ManPOA.listBExtPOA[ManPOA.indexBExtPOA].listMadeBEXTRACCION.length; i++) {
                        ManPOA.listBExtPOA[ManPOA.indexBExtPOA].listMadeBEXTRACCION[i].index = i;
                        ManPOA.listBExtPOA[ManPOA.indexBExtPOA].listMadeBEXTRACCION[i].NRO = (i + 1);
                    }

                    ManPOA.ItemBExt.dtItemBExt.row($tr).remove().draw(false);
                    utilSigo.enumTB(ManPOA.ItemBExt.dtItemBExt, 2);
                    ManPOA.ItemBExt.CalculaTotal();
                }
            });
    }
    this.eliminarTablaAll = function () {
        var $trsEliminar = this.dtItemBExt.$("tr");
        if ($trsEliminar.length > 0) {
            utilSigo.dialogConfirm("", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {
                    var $tr, row;
                    $.each($trsEliminar, function (i, o) {
                        $tr = $(o).closest('tr');
                        row = ManPOA.ItemBExt.dtItemBExt.row($tr).data();

                        if (row.RegEstado == 0 || row.RegEstado == 2) {
                            ManPOA.ListEliTABLA.push({
                                EliTABLA: "POA_DET_MADERABLE_BEXTRACCION",
                                EliVALOR01: ManPOA.listBExtPOA[ManPOA.indexBExtPOA].COD_SECUENCIAL,
                                EliVALOR02: row.COD_SECUENCIAL
                            });
                        }
                    });

                    ManPOA.listBExtPOA[ManPOA.indexBExtPOA].listMadeBEXTRACCION = [];
                    ManPOA.ItemBExt.dtItemBExt.clear().draw();
                    ManPOA.ItemBExt.CalculaTotal();
                }
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }

    this.addRowsDtExcel = function (data) {
        var $rows = this.dtItemBExt.$("tr");
        var codSecC = $rows.length + 1;
        var list = [];
        for (var i = 0; i < data.length; i++) {

            list.push({
                NRO: codSecC,
                ESPECIES: data[i].ESPECIES,
                ESPECIES_SERFOR: data[i].ESPECIES_SERFOR,
                DMC: data[i].DMC,
                TOTAL_ARBOLES: data[i].TOTAL_ARBOLES,
                VOLUMEN_AUTORIZADO: data[i].VOLUMEN_AUTORIZADO,
                VOLUMEN_MOVILIZADO: data[i].VOLUMEN_MOVILIZADO,
                AUTORIZADO: data[i].AUTORIZADO,
                EXTRAIDO: data[i].EXTRAIDO,
                FECHA1: data[i].FECHA1,
                GUIA_TRANSPORTE: data[i].GUIA_TRANSPORTE,
                FECHA2: data[i].FECHA2,
                RECIBO: data[i].RECIBO,
                SALDO: data[i].SALDO,
                CANTIDAD: data[i].CANTIDAD,
                UNIDAD_MEDIDA: data[i].UNIDAD_MEDIDA,
                OBSERVACION: data[i].OBSERVACION,
                TIPOMADERABLE: data[i].TIPOMADERABLE,
                COD_ESPECIES: data[i].COD_ESPECIES,
                COD_ESPECIES_SERFOR: data[i].COD_ESPECIES_SERFOR,
                RegEstado: data[i].RegEstado,
                index: (codSecC - 1),
                COD_SECUENCIAL: 0
            });
            codSecC++;
        }

        Array.prototype.push.apply(ManPOA.listBExtPOA[ManPOA.indexBExtPOA].listMadeBEXTRACCION, list);
        this.dtItemBExt.rows.add(list).draw();
        this.dtItemBExt.page('last').draw('page');
        ManPOA.ItemBExt.CalculaTotal();
    }

    this.exportarExcel = function (codTHabilitante, numPoa, TVentana) {
        $.ajax({
            url: ManPOA.controller + "/ExportarExcel",
            type: 'POST',
            data: {
                COD_THABILITANTE: codTHabilitante,
                NumPoa: numPoa,
                hdfItemCod_MTipo: ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val(),
                TVentana: TVentana,
                estado_origen: ManPOA.frmPOARegistro.find("#hdfItemEstadoOrigen").val(),
                indicador: ManPOA.frmPOARegistro.find("#hdfItemIndicador").val()
            },
            dataType: 'json',
            success: function (data) {
                if (data.success) {
                    window.location.href = ManPOA.controller + "/Download?file=" + data.values[0];
                }
                else utilSigo.toastWarning("Error", data.msj);
            },
            error: function (jqXHR, error, errorThrown) {
                utilSigo.toastError("Error", initSigo.MessageError);
                console.log(jqXHR.responseText);
            }
        });
    }
}).apply(ManPOA.ItemBExt);
//BExtMaderable
(function () {
    this.dtItemBExtMaderable;
    this.frmBExtMaderable;
    this.divModal;
    this.tr;
    this.dtItemCMaderable;
    this.init = function () {

        this.frmBExtMaderable = $("#frmBExtMaderable");
        this.divModal = $("#PDivItemBExtMaderable");


        this.dtItemBExtMaderable = ManPOA.frmPOARegistro.find("#grvItemBExtMaderable").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bInfo: false,
            bLengthChange: false,
            scrollCollapse: true,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            footerCallback: function (row, data, start, end, display) {
                var api = this.api(), data;
                var columnas = [5, 6, 7, 8];
                for (var j in columnas) {
                    var total = api.column(columnas[j]).data().reduce(function (a, b) {
                        return utilSigo.intVal(a) + utilSigo.intVal(b);
                    }, 0);

                    $(api.column(columnas[j]).footer()).html(Math.round(total * 1000) / 1000);
                }
                $(api.column(3).footer()).html("Total");
            },
            columns: [
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExtMaderable.cellEdit },
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExtMaderable.cellDel },
                { data: "NRO" },
                { data: "ESPECIES" },
                { data: "ESPECIES_SERFOR" },
                { data: "DMC" },
                { data: "TOTAL_ARBOLES" },
                { data: "VOLUMEN_AUTORIZADO" },
                { data: "VOLUMEN_MOVILIZADO" },
                { data: "SALDO" },
                { data: "UNIDAD_MEDIDA" },
                { data: "PCA" },
                { data: "OBSERVACION" },
                { data: "TIPOMADERABLE" },
                { data: "COD_ESPECIES", visible: false },
                { data: "COD_ESPECIES_SERFOR", visible: false },
                { data: "RegEstado", visible: false },
                { data: "index", visible: false },
                { data: "COD_SECUENCIAL", visible: false }

            ]

        });
        this.frmBExtMaderable.find('#ddlItemBExtMaderableEspecies').select2();
        this.frmBExtMaderable.find('#ddlItemBExtMaderableEspecies_Serfor').select2();

    }
    this.ItemExcelImportarVentana = function (e, objeto, TVentana) {

        var idFile = $(objeto).attr("id");
        var ruta = ManPOA.controller + "/ImportarDataExcel";
        ManPOA.uploadFile.fileSelectHandler(e, idFile, ruta, TVentana);
        var input = this.frmBExtMaderable.find("fileselect");
        input.val("");

    }
    this.ValidacionItemExcelImportarVentana = function (e, objeto, TVentana) {

        if (TVentana == 'BEMADE' || TVentana == 'BENOMADE' || TVentana == 'BEINSITU') {
            if (ManPOA.frmPOARegistro.find("#hdfSelectBExtPOA_Index").val() == '') {
                utilSigo.toastError("Error", "Seleccione la fecha de emisión del balance al que pertenece el registro");
                return false;
            }
        }
        return true;


    }

    this.cellEdit = function (data, type, row) {
        return '<i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Editar" onclick="ManPOA.ItemBExtMaderable.showModal(0,this);"></i>';

    }
    this.cellDel = function (data, type, row) {
        return '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManPOA.ItemBExtMaderable.eliminar(this);"></i>';
    }

    this.ddListarPCBx = function () {
        var pcList = [];
        $('#txtParcelaBalance').find('option').remove().end();
        var parcela = _frmParcela.fnGetList();
        var countFilas = parcela.length;
        if (countFilas > 0) {
            $.each(parcela, function (i, o) {
                //alert(parcela[i].PCA);
                //pcList.push(utilSigo.fnConvertArrayToObject(parcela[i].PCA));
                $('#txtParcelaBalance').append($('<option>', {
                    value: parcela[i].PCA,
                    text: parcela[i].PCA
                }));
            });
        }
    }

    this.showModal = function (RegEstado, obj) {
        this.ddListarPCBx();
        if (ManPOA.frmPOARegistro.find("#hdfSelectBExtPOA_Index").val() != '') {

            var PDivTitulo = '';
            this.frmBExtMaderable.find("#txtItemBExtMaderableUM").attr("disabled", true);

            if (RegEstado == 1) {
                PDivTitulo = 'Nuevo Registro';
                this.frmBExtMaderable.find("#txtItemBExtMaderableUM").val("M3");
            }
            else {
                if (RegEstado == 0) {
                    PDivTitulo = 'Modificando Registro';
                    var $tr = $(obj).closest('tr');
                    this.tr = $tr;

                    var row = this.dtItemBExtMaderable.row($tr).data();
                    this.frmBExtMaderable.find("#ddlItemBExtMaderableEspecies").val(row.COD_ESPECIES).trigger("change");
                    this.frmBExtMaderable.find("#ddlItemBExtMaderableEspecies_Serfor").val(row.COD_ESPECIES_SERFOR).trigger("change");
                    this.frmBExtMaderable.find("#txtItemBExtMaderableDmc").val(row.DMC);
                    this.frmBExtMaderable.find("#txtItemBExtMaderableTotal_Arboles").val(row.TOTAL_ARBOLES);
                    this.frmBExtMaderable.find("#txtItemBExtMaderableVolumen_Autorizado").val(row.VOLUMEN_AUTORIZADO);
                    this.frmBExtMaderable.find("#txtItemBExtMaderableVolumen_Movilizado").val(row.VOLUMEN_MOVILIZADO);
                    this.frmBExtMaderable.find("#txtItemBExtMaderableSaldo").val(row.SALDO);
                    this.frmBExtMaderable.find("#txtItemBExtMaderableObservacion").val(row.OBSERVACION);
                    this.frmBExtMaderable.find("#ddlTipoMaderables_BExt").val(row.TIPOMADERABLE);
                    this.frmBExtMaderable.find("#txtParcelaBalance").val(row.PCA);

                    this.frmBExtMaderable.find("#txtItemBExtMaderableUM").val(row.UNIDAD_MEDIDA);

                }
            }
            this.divModal.find(".spTitulo").html(PDivTitulo);
            this.frmBExtMaderable.find("#hdfItemBExtMaderable_RegEstado").val(RegEstado);

            utilSigo.modalDraggable(this.divModal, '.modal-header');
            this.divModal.modal({ keyboard: true, backdrop: 'static' });
        } else {
            utilSigo.toastError("Error", "Seleccione la fecha de emisión del balance al que pertenece el registro");
        }
    }
    this.cleanModal = function () {

        this.frmBExtMaderable.find("#txtItemBExtMaderableDmc").val('');
        this.frmBExtMaderable.find("#txtItemBExtMaderableTotal_Arboles").val('');
        this.frmBExtMaderable.find("#txtItemBExtMaderableVolumen_Autorizado").val('');
        this.frmBExtMaderable.find("#txtItemBExtMaderableVolumen_Movilizado").val('');
        this.frmBExtMaderable.find("#txtItemBExtMaderableSaldo").val('');
        this.frmBExtMaderable.find("#txtItemBExtMaderableObservacion").val('');
        this.frmBExtMaderable.find("#ddlTipoMaderables_BExt").val('-');
        this.frmBExtMaderable.find("#ddlItemBExtMaderableEspecies").val('-').trigger("change");
        this.frmBExtMaderable.find("#ddlItemBExtMaderableEspecies_Serfor").val('-').trigger("change");
        this.frmBExtMaderable.find("#txtParcelaBalance").val('');
    }
    this.closeModal = function () {
        this.cleanModal();
        //limpiando estilos si lo tienen
        $(':input', this.frmBExtMaderable)
            .removeClass('border-danger')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title');

        ddlItemBExtMaderableEspecies
        $("#ddlItemBExtMaderableEspecies,#ddlItemBExtMaderableEspecies_Serfor").val("-").trigger("change");
        this.divModal.modal('hide');
    }
    this.validaSaveModal = function () {

        if (this.frmBExtMaderable.find("#hdfItemBExtMaderable_RegEstado").val() == '1') {
            if (utilSigo.ValidaCombo("ddlItemBExtMaderableEspecies", "Seleccione Especie") == false) return false;
        }
        if (utilSigo.ValidaTexto("txtItemBExtMaderableDmc", "Ingrese DMC") == false) return false;
        if (utilSigo.ValidaTexto("txtItemBExtMaderableTotal_Arboles", "Ingrese Total Arboles") == false) return false;
        if (utilSigo.ValidaTexto("txtItemBExtMaderableVolumen_Autorizado", "Ingrese Volumen Autorizado") == false) return false;
        if (utilSigo.ValidaTexto("txtItemBExtMaderableVolumen_Movilizado", "Ingrese Volumen Movilizado") == false) return false;
        if (utilSigo.ValidaTexto("txtItemBExtMaderableSaldo", "Ingrese Saldo") == false) return false;
        if (utilSigo.ValidaCombo("ddlTipoMaderables_BExt", "Seleccione el Tipo de Aprovechamiento") == false) return false;

        return true;
    }
    this.saveModal = function () {

        if (this.validaSaveModal()) {

            var estado = this.frmBExtMaderable.find("#hdfItemBExtMaderable_RegEstado").val();

            if (estado == "1") {
                //Nuevo
                var codSecC = this.dtItemBExtMaderable.$("tr").length + 1;

                var fila = {
                    NRO: codSecC,
                    ESPECIES: this.frmBExtMaderable.find("#ddlItemBExtMaderableEspecies").select2('data')[0].text,
                    ESPECIES_SERFOR: this.frmBExtMaderable.find("#ddlItemBExtMaderableEspecies_Serfor").val() == "-" ? "" : this.frmBExtMaderable.find("#ddlItemBExtMaderableEspecies_Serfor").select2('data')[0].text,
                    DMC: this.frmBExtMaderable.find("#txtItemBExtMaderableDmc").val().trim(),
                    TOTAL_ARBOLES: this.frmBExtMaderable.find("#txtItemBExtMaderableTotal_Arboles").val().trim(),
                    VOLUMEN_AUTORIZADO: this.frmBExtMaderable.find("#txtItemBExtMaderableVolumen_Autorizado").val().trim(),
                    VOLUMEN_MOVILIZADO: this.frmBExtMaderable.find("#txtItemBExtMaderableVolumen_Movilizado").val().trim(),
                    SALDO: this.frmBExtMaderable.find("#txtItemBExtMaderableSaldo").val().trim(),
                    PCA: this.frmBExtMaderable.find("#txtParcelaBalance").val(),
                    OBSERVACION: this.frmBExtMaderable.find("#txtItemBExtMaderableObservacion").val().trim(),
                    TIPOMADERABLE: this.frmBExtMaderable.find("#ddlTipoMaderables_BExt").val().trim(),
                    COD_ESPECIES: this.frmBExtMaderable.find("#ddlItemBExtMaderableEspecies").val(),
                    COD_ESPECIES_SERFOR: this.frmBExtMaderable.find("#ddlItemBExtMaderableEspecies_Serfor").val(),
                    RegEstado: 1,
                    COD_SECUENCIAL: 0,
                    index: (codSecC - 1),
                    UNIDAD_MEDIDA: this.frmBExtMaderable.find("#txtItemBExtMaderableUM").val()
                };

                if (ManPOA.indexBExtPOA === "") {
                    ManPOA.indexBExtPOA = "0";
                }

                ManPOA.listBExtPOA[ManPOA.indexBExtPOA].listMadeBEXTRACCION.push(fila);
                ManPOA.ItemBExtMaderable.dtItemBExtMaderable.clear();
                ManPOA.ItemBExtMaderable.dtItemBExtMaderable.rows.add(ManPOA.listBExtPOA[ManPOA.indexBExtPOA].listMadeBEXTRACCION).draw();
                this.dtItemBExtMaderable.page('last').draw('page');

            }
            else {

                var row = this.dtItemBExtMaderable.row(this.tr).data();

                row.DMC = this.frmBExtMaderable.find("#txtItemBExtMaderableDmc").val().trim();
                row.TOTAL_ARBOLES = this.frmBExtMaderable.find("#txtItemBExtMaderableTotal_Arboles").val().trim();
                row.COD_ESPECIES = this.frmBExtMaderable.find("#ddlItemBExtMaderableEspecies").val();
                row.ESPECIES = this.frmBExtMaderable.find("#ddlItemBExtMaderableEspecies").select2('data')[0].text;
                row.VOLUMEN_AUTORIZADO = this.frmBExtMaderable.find("#txtItemBExtMaderableVolumen_Autorizado").val().trim();
                row.VOLUMEN_MOVILIZADO = this.frmBExtMaderable.find("#txtItemBExtMaderableVolumen_Movilizado").val().trim();
                row.SALDO = this.frmBExtMaderable.find("#txtItemBExtMaderableSaldo").val().trim();
                row.OBSERVACION = this.frmBExtMaderable.find("#txtItemBExtMaderableObservacion").val().trim();
                row.TIPOMADERABLE = this.frmBExtMaderable.find("#ddlTipoMaderables_BExt").val();
                row.COD_ESPECIES_SERFOR = this.frmBExtMaderable.find("#ddlItemBExtMaderableEspecies_Serfor").val();
                row.ESPECIES_SERFOR = this.frmBExtMaderable.find("#ddlItemBExtMaderableEspecies_Serfor").val() == "-" ? "" : this.frmBExtMaderable.find("#ddlItemBExtMaderableEspecies_Serfor").select2('data')[0].text;
                row.UNIDAD_MEDIDA = this.frmBExtMaderable.find("#txtItemBExtMaderableUM").val();

                //row.COD_ESPECIES_SERFOR = this.frmBExtMaderable.find("#ddlItemBExtMaderableEspecies_Serfor").val();
                //row.ESPECIES_SERFOR = this.frmBExtMaderable.find("#ddlItemBExtMaderableEspecies_Serfor").val() == "-" ? "" : this.frmBExtMaderable.find("#ddlItemBExtMaderableEspecies_Serfor").select2('data')[0].text;
                row.PCA = this.frmBExtMaderable.find("#txtParcelaBalance").val();
                if (row.RegEstado == 0)
                    row.RegEstado = 2;


                ManPOA.listBExtPOA[ManPOA.indexBExtPOA].listMadeBEXTRACCION[row.index] = row;
                ManPOA.ItemBExtMaderable.dtItemBExtMaderable.clear();
                ManPOA.ItemBExtMaderable.dtItemBExtMaderable.rows.add(ManPOA.listBExtPOA[ManPOA.indexBExtPOA].listMadeBEXTRACCION).draw();
                utilSigo.toastSuccess("Exito", "Se modifico con exito");
                this.closeModal();
            }
        }
    }
    this.eliminar = function (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?",
            function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');
                    var row = ManPOA.ItemBExtMaderable.dtItemBExtMaderable.row($tr).data();

                    if (row.RegEstado == 0 || row.RegEstado == 2) {
                        ManPOA.ListEliTABLA.push({
                            EliTABLA: "POA_DET_MADERABLE_BEXTRACCION",
                            EliVALOR01: ManPOA.listBExtPOA[ManPOA.indexBExtPOA].COD_SECUENCIAL,
                            EliVALOR02: row.COD_SECUENCIAL
                        });
                    }

                    ManPOA.listBExtPOA[ManPOA.indexBExtPOA].listMadeBEXTRACCION.splice(row.index, 1);
                    for (var i = 0; i < ManPOA.listBExtPOA[ManPOA.indexBExtPOA].listMadeBEXTRACCION.length; i++) {
                        ManPOA.listBExtPOA[ManPOA.indexBExtPOA].listMadeBEXTRACCION[i].index = i;
                        ManPOA.listBExtPOA[ManPOA.indexBExtPOA].listMadeBEXTRACCION[i].NRO = (i + 1);
                    }


                    ManPOA.ItemBExtMaderable.dtItemBExtMaderable.row($tr).remove().draw(false);
                    utilSigo.enumTB(ManPOA.ItemBExtMaderable.dtItemBExtMaderable, 2);

                }
            });
    }
    this.eliminarTablaAll = function () {

        var $trsEliminar = this.dtItemBExtMaderable.$("tr");
        if ($trsEliminar.length > 0) {
            utilSigo.dialogConfirm("", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {

                    for (var row in ManPOA.listBExtPOA[ManPOA.indexBExtPOA].listMadeBEXTRACCION) {

                        if (row.RegEstado == 0 || row.RegEstado == 2) {
                            ManPOA.ListEliTABLA.push({
                                EliTABLA: "POA_DET_MADERABLE_BEXTRACCION",
                                EliVALOR01: ManPOA.listBExtPOA[ManPOA.indexBExtPOA].COD_SECUENCIAL,
                                EliVALOR02: row.COD_SECUENCIAL
                            });
                        }
                    }
                    ManPOA.listBExtPOA[ManPOA.indexBExtPOA].listMadeBEXTRACCION = [];
                    ManPOA.ItemBExtMaderable.dtItemBExtMaderable.clear().draw();
                }
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }

    this.addRowsDtExcel = function (data) {
        var $rows = this.dtItemBExtMaderable.$("tr");
        var codSecC = $rows.length + 1;
        var list = [];
        /**para validar parcelas */
        var parcela = _frmParcela.fnGetList();
        var countFilas = parcela.length;
        var band = 0;
        for (var i = 0; i < data.length; i++) {

            list.push({
                NRO: codSecC,
                ESPECIES: data[i].ESPECIES,
                ESPECIES_SERFOR: data[i].ESPECIES_SERFOR,
                DMC: data[i].DMC,
                TOTAL_ARBOLES: data[i].TOTAL_ARBOLES,
                VOLUMEN_AUTORIZADO: data[i].VOLUMEN_AUTORIZADO,
                VOLUMEN_MOVILIZADO: data[i].VOLUMEN_MOVILIZADO,
                SALDO: data[i].SALDO,
                PCA: data[i].PCA,
                OBSERVACION: data[i].OBSERVACION,
                TIPOMADERABLE: data[i].TIPOMADERABLE,
                RegEstado: data[i].RegEstado,
                COD_ESPECIES: data[i].COD_ESPECIES,
                COD_ESPECIES_SERFOR: data[i].COD_ESPECIES_SERFOR,
                COD_SECUENCIAL: 0,
                index: (codSecC - 1)
            });
            codSecC++;
            if (countFilas > 0) {
                for (var j = 0; j < parcela.length; j++) {
                    if (data[i].PCA == parcela[j].PCA) {
                        band = band + 1;
                    }
                }
            }

        }
        Array.prototype.push.apply(ManPOA.listBExtPOA[ManPOA.indexBExtPOA].listMadeBEXTRACCION, list);
        if (data.length == band) {
            this.dtItemBExtMaderable.rows.add(list).draw();
        }
        else {
            utilSigo.toastWarning("Error", "Las parcelas en la plantilla no coinciden con lo registrado");
        }
        this.dtItemBExtMaderable.page('last').draw('page');

    }

    this.exportarExcel = function (codTHabilitante, numPoa, TVentana) {

        $.ajax({
            url: ManPOA.controller + "/ExportarExcel",
            type: 'POST',
            data: {
                COD_THABILITANTE: codTHabilitante,
                NumPoa: numPoa,
                hdfItemCod_MTipo: ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val(),
                TVentana: TVentana,
                estado_origen: ManPOA.frmPOARegistro.find("#hdfItemEstadoOrigen").val()
            },
            dataType: 'json',
            success: function (data) {
                // utilSigo.unblockUIGeneral();               
                if (data.success) {
                    window.location.href = ManPOA.controller + "/Download?file=" + data.values[0];
                }
                else utilSigo.toastWarning("Error", data.msj);
            },
            //beforeSend: function () {
            //    utilSigo.blockUIGeneral();
            //},
            error: function (jqXHR, error, errorThrown) {
                //  utilSigo.unblockUIGeneral();
                utilSigo.toastError("Error", initSigo.MessageError);
                //console.log(jqXHR.responseText);
            }
        });

    }


}).apply(ManPOA.ItemBExtMaderable);
//ItemBExtNoMaderable
(function () {
    this.dtItemBExtNoMaderable;
    this.columns;
    this.frmBExtNoMaderable;
    this.divModal;
    this.tr;

    this.init = function () {

        this.divModal = $("#PDivItemBExtNoMaderable");
        var hdfItemCod_MTipo = ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val();
        this.dtItemBExtNoMaderable = ManPOA.frmPOARegistro.find("#grvItemBExtNoMaderable").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bInfo: false,
            bLengthChange: false,
            scrollCollapse: true,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            footerCallback: function (row, data, start, end, display) {
                var api = this.api(), data;
                var columnas;

                if (hdfItemCod_MTipo == "0000021") {
                    columnas = [7, 8, 13];
                }
                else if (hdfItemCod_MTipo == "0000020") {
                    columnas = [13, 14];
                }
                else {
                    columnas = [5, 6, 13];
                }


                for (var j in columnas) {
                    var total = api
                        .column(columnas[j])
                        .data()
                        .reduce(function (a, b) {
                            return utilSigo.intVal(a) + utilSigo.intVal(b);
                        }, 0);

                    $(api.column(columnas[j]).footer()).html(Math.round(total * 1000) / 1000);
                }
                $(api.column(4).footer()).html("Total");
            },
            columns: ManPOA.ItemBExtNoMaderable.columns

        });

        this.frmBExtNoMaderable.find('#ddlItemBExtNoMaderableEspecies').select2();
        this.frmBExtNoMaderable.find('#ddlItemBExtNoMaderableEspecies_Serfor').select2();

        if (hdfItemCod_MTipo != "0000021" && hdfItemCod_MTipo != "0000020") {
            $(this.dtItemBExtNoMaderable.column(15).header()).text("UM");
        }
    }
    this.cellEdit = function (data, type, row) {
        return '<i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Editar" onclick="ManPOA.ItemBExtNoMaderable.showModal(0,this);"></i>';

    }
    this.cellDel = function (data, type, row) {
        return '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManPOA.ItemBExtNoMaderable.eliminar(this);"></i>';
    }
    this.eliminar = function (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?",
            function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');
                    var row = ManPOA.ItemBExtNoMaderable.dtItemBExtNoMaderable.row($tr).data();

                    if (row.RegEstado == 0 || row.RegEstado == 2) {
                        ManPOA.ListEliTABLA.push({
                            EliTABLA: "POA_DET_NOMADERABLE_BEXTRACCION",
                            EliVALOR01: ManPOA.listBExtPOA[ManPOA.indexBExtPOA].COD_SECUENCIAL,
                            EliVALOR02: row.COD_SECUENCIAL
                        });
                    }

                    ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListNoMadeBEXTRACCION.splice(row.index, 1);

                    for (var i = 0; i < ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListNoMadeBEXTRACCION.length; i++) {
                        ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListNoMadeBEXTRACCION[i].index = i;
                        ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListNoMadeBEXTRACCION[i].NRO = (i + 1);
                    }

                    ManPOA.ItemBExtNoMaderable.dtItemBExtNoMaderable.row($tr).remove().draw(false);
                    utilSigo.enumTB(ManPOA.ItemBExtNoMaderable.dtItemBExtNoMaderable, 2);

                }
            });
    }
    this.eliminarTablaAll = function () {

        var $trsEliminar = this.dtItemBExtNoMaderable.$("tr");
        if ($trsEliminar.length > 0) {
            utilSigo.dialogConfirm("", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {


                    for (var row in ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListNoMadeBEXTRACCION) {

                        if (row.RegEstado == 0 || row.RegEstado == 2) {
                            ManPOA.ListEliTABLA.push({
                                EliTABLA: "POA_DET_NOMADERABLE_BEXTRACCION",
                                EliVALOR01: ManPOA.listBExtPOA[ManPOA.indexBExtPOA].COD_SECUENCIAL,
                                EliVALOR02: row.COD_SECUENCIAL
                            });
                        }
                    }

                    ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListNoMadeBEXTRACCION = [];
                    ManPOA.ItemBExtNoMaderable.dtItemBExtNoMaderable.clear().draw();
                }
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }

    this.showModal = function (RegEstado, obj) {
        if (ManPOA.frmPOARegistro.find("#hdfSelectBExtPOA_Index").val() != '') {

            var PDivTitulo = '';
            var hdfItemCod_MTipo = ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val();

            if (hdfItemCod_MTipo == "0000020") {
                if (RegEstado == 1) {
                    PDivTitulo = 'Nuevo Registro - Productos Forestales No Maderables Carrizo';
                }
                else if (RegEstado == 0) {
                    PDivTitulo = 'Modificando Registro - Productos Forestales No Maderables Carrizo';
                }
            }
            else if (hdfItemCod_MTipo == "0000021") {
                if (RegEstado == 1) {
                    PDivTitulo = 'Nuevo Registro - Productos Forestales No Maderables Plantas Medicinales';
                }
                else if (RegEstado == 0) {
                    PDivTitulo = 'Modificando Registro - Productos Forestales No Maderables Plantas Medicinales';
                }
            }
            else {
                if (RegEstado == 1) {
                    PDivTitulo = 'Nuevo Registro - No Maderable';
                    this.frmBExtNoMaderable.find("#txtItemBExtUnidadMedida").val("KG");
                }
                else if (RegEstado == 0) {
                    PDivTitulo = 'Modificando Registro - No Maderable';
                }
            }
            if (RegEstado == 0) {
                //Nuevo registro
                var $tr = $(obj).closest('tr');
                this.tr = $tr;

                var row = this.dtItemBExtNoMaderable.row($tr).data();

                this.frmBExtNoMaderable.find("#ddlItemBExtNoMaderableEspecies").val(row.COD_ESPECIES).trigger("change");
                this.frmBExtNoMaderable.find("#ddlItemBExtNoMaderableEspecies_Serfor").val(row.COD_ESPECIES_SERFOR).trigger("change");


                if (hdfItemCod_MTipo.Value == "0000021") {
                    this.frmBExtNoMaderable.find("#txtItemBExtAutorizado").val(row.AUTORIZADO);
                    this.frmBExtNoMaderable.find("#txtItemBExtExtraido").val(row.EXTRAIDO);
                    this.frmBExtNoMaderable.find("#txtItemBExtUnidadMedida").val(row.UNIDAD_MEDIDA);
                }
                else if (hdfItemCod_MTipo.Value == "0000020") {
                    this.frmBExtNoMaderable.find("#txtFechaKardexCarrizo").val(row.FECHA1);
                    this.frmBExtNoMaderable.find("#txtGTFKarcexCarrizo").val(row.GUIA_TRANSPORTE);
                    this.frmBExtNoMaderable.find("#txtFechaKardexCarrizo2").val(row.FECHA2);
                    this.frmBExtNoMaderable.find("#txtReciboKardexCarrizo").val(row.RECIBO);
                    this.frmBExtNoMaderable.find("#txtCantidadKardexCarrizo").val(row.CANTIDAD);


                }
                else {
                    this.frmBExtNoMaderable.find("#txtItemBExtNoMaderableKilogramo_Autorizado").val(row.KILOGRAMO_AUTORIZADO);
                    this.frmBExtNoMaderable.find("#txtItemBExtNoMaderableKilogramo_Movilizado").val(row.KILOGRAMO_MOVILIZADO);
                    this.frmBExtNoMaderable.find("#txtItemBExtUnidadMedida").val(row.UNIDAD_MEDIDA);
                }


                this.frmBExtNoMaderable.find("#txtItemBExtNoMaderableSaldo").val(row.SALDO);
                this.frmBExtNoMaderable.find("#txtItemBExtNoMaderableObservacion").val(row.OBSERVACION);

            }

            this.divModal.find(".spTitulo").html(PDivTitulo);
            this.frmBExtNoMaderable.find("#hdfItemBExtNoMaderable_RegEstado").val(RegEstado);

            utilSigo.modalDraggable(this.divModal, '.modal-header');
            this.divModal.modal({ keyboard: true, backdrop: 'static' });
        } else {
            utilSigo.toastError("Error", "Seleccione la fecha de emisión del balance al que pertenece el registro");
        }
    }
    this.cleanModal = function () {

        this.frmBExtNoMaderable.find("#txtItemBExtNoMaderableKilogramo_Autorizado").val('');
        this.frmBExtNoMaderable.find("#txtItemBExtNoMaderableKilogramo_Movilizado").val('');
        this.frmBExtNoMaderable.find("#txtItemBExtNoMaderableSaldo").val('');
        this.frmBExtNoMaderable.find("#txtItemBExtNoMaderableObservacion").val('');
        this.frmBExtNoMaderable.find("#txtItemBExtAutorizado").val('');
        this.frmBExtNoMaderable.find("#txtItemBExtExtraido").val('');
        this.frmBExtNoMaderable.find("#txtItemBExtUnidadMedida").val('');

        this.frmBExtNoMaderable.find("#ddlItemBExtMaderableEspecies").val('-').trigger("change");
        this.frmBExtNoMaderable.find("#ddlItemBExtMaderableEspecies_Serfor").val('-').trigger("change");
        this.frmBExtMaderable.find("#txtParcelaBalance").val('');
    }
    this.closeModal = function () {
        this.cleanModal();
        $(':input', this.frmBExtNoMaderable)
            .removeClass('border-danger')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title');


        $("#ddlItemBExtNoMaderableEspecies,#ddlItemBExtNoMaderableEspecies_Serfor").val("-").trigger("change");
        this.divModal.modal('hide');
    }
    this.validaSaveModal = function () {

        if (this.frmBExtNoMaderable.find("#hdfItemBExtNoMaderable_RegEstado").val() == '1') {
            if (utilSigo.ValidaCombo("ddlItemBExtNoMaderableEspecies", "Seleccione Especie") == false) return false;
        }

        return true;
    }
    this.saveModal = function () {

        if (this.validaSaveModal()) {

            var estado = $("#hdfItemBExtNoMaderable_RegEstado").val();

            if (estado === "1") {
                //Nuevo
                var codSecC = this.dtItemBExtNoMaderable.$("tr").length + 1;
                var hdfItemCod_MTipo = ManPOA.frmPOARegistro.find("#hdfItemCod_MTipo").val();


                var fila = {
                    NRO: codSecC,
                    ESPECIES: this.frmBExtNoMaderable.find("#ddlItemBExtNoMaderableEspecies").select2('data')[0].text,
                    ESPECIES_SERFOR: this.frmBExtNoMaderable.find("#ddlItemBExtNoMaderableEspecies_Serfor").val() == "-" ? "" : this.frmBExtNoMaderable.find("#ddlItemBExtNoMaderableEspecies_Serfor").select2('data')[0].text,
                    KILOGRAMO_AUTORIZADO: "",
                    KILOGRAMO_MOVILIZADO: "",
                    AUTORIZADO: "",
                    EXTRAIDO: "",
                    FECHA1: "",
                    GUIA_TRANSPORTE: "",
                    FECHA2: "",
                    RECIBO: "",
                    SALDO: this.frmBExtNoMaderable.find("#txtItemBExtNoMaderableSaldo").val().trim(),
                    CANTIDAD: "",
                    UNIDAD_MEDIDA: (codSecC - 1),
                    OBSERVACION: this.frmBExtNoMaderable.find("#txtItemBExtNoMaderableObservacion").val().trim(),
                    COD_ESPECIES: this.frmBExtNoMaderable.find("#ddlItemBExtNoMaderableEspecies").val(),
                    COD_ESPECIES_SERFOR: this.frmBExtNoMaderable.find("#ddlItemBExtNoMaderableEspecies_Serfor").val(),
                    RegEstado: 1,
                    index: (codSecC - 1),
                    COD_SECUENCIAL: 0
                };
                if (hdfItemCod_MTipo == "0000021") {
                    fila.AUTORIZADO = this.frmBExtNoMaderable.find("#txtItemBExtAutorizado").val().trim();
                    fila.EXTRAIDO = this.frmBExtNoMaderable.find("#txtItemBExtExtraido").val().trim();
                    fila.UNIDAD_MEDIDA = this.frmBExtNoMaderable.find("#txtItemBExtUnidadMedida").val().trim();
                }
                else if (hdfItemCod_MTipo == "0000020") {
                    fila.FECHA1 = this.frmBExtNoMaderable.find("#txtFechaKardexCarrizo").val().trim();
                    fila.GUIA_TRANSPORTE = this.frmBExtNoMaderable.find("#txtGTFKarcexCarrizo").val().trim();
                    fila.FECHA2 = this.frmBExtNoMaderable.find("#txtFechaKardexCarrizo2").val().trim();
                    fila.RECIBO = this.frmBExtNoMaderable.find("#txtReciboKardexCarrizo").val().trim();
                    fila.CANTIDAD = this.frmBExtNoMaderable.find("#txtCantidadKardexCarrizo").val().trim();
                }
                else {
                    fila.KILOGRAMO_AUTORIZADO = this.frmBExtNoMaderable.find("#txtItemBExtNoMaderableKilogramo_Autorizado").val().trim();
                    fila.KILOGRAMO_MOVILIZADO = this.frmBExtNoMaderable.find("#txtItemBExtNoMaderableKilogramo_Movilizado").val().trim();
                    fila.UNIDAD_MEDIDA = this.frmBExtNoMaderable.find("#txtItemBExtUnidadMedida").val();
                }
                if (ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListNoMadeBEXTRACCION === undefined) {
                    ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListNoMadeBEXTRACCION = [];
                }
                ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListNoMadeBEXTRACCION.push(fila);
                this.dtItemBExtNoMaderable.rows.add([fila]).draw();
                this.dtItemBExtNoMaderable.page('last').draw('page');

            }
            else {

                var row = this.dtItemBExtNoMaderable.row(this.tr).data();

                if (hdfItemCod_MTipo == "0000021") {

                    row.AUTORIZADO = this.frmBExtNoMaderable.find("#txtItemBExtAutorizado").val().trim();
                    row.EXTRAIDO = this.frmBExtNoMaderable.find("#txtItemBExtExtraido").val().trim();
                    row.UNIDAD_MEDIDA = this.frmBExtNoMaderable.find("#txtItemBExtUnidadMedida").val().trim();

                }
                else if (hdfItemCod_MTipo == "0000020") {

                    row.FECHA1 = this.frmBExtNoMaderable.find("#txtFechaKardexCarrizo").val().trim();
                    row.GUIA_TRANSPORTE = this.frmBExtNoMaderable.find("#txtGTFKarcexCarrizo").val().trim();
                    row.FECHA2 = this.frmBExtNoMaderable.find("#txtFechaKardexCarrizo2").val().trim();
                    row.RECIBO = this.frmBExtNoMaderable.find("#txtReciboKardexCarrizo").val().trim();
                    row.CANTIDAD = this.frmBExtNoMaderable.find("#txtCantidadKardexCarrizo").val().trim();

                }
                else {
                    row.KILOGRAMO_AUTORIZADO = this.frmBExtNoMaderable.find("#txtItemBExtNoMaderableKilogramo_Autorizado").val().trim();
                    row.KILOGRAMO_MOVILIZADO = this.frmBExtNoMaderable.find("#txtItemBExtNoMaderableKilogramo_Movilizado").val().trim();
                    row.UNIDAD_MEDIDA = this.frmBExtNoMaderable.find("#txtItemBExtUnidadMedida").val();
                }
                row.COD_ESPECIES = this.frmBExtNoMaderable.find("#ddlItemBExtNoMaderableEspecies").val().trim();
                row.ESPECIES = this.frmBExtNoMaderable.find("#ddlItemBExtNoMaderableEspecies").select2('data')[0].text;
                row.SALDO = this.frmBExtNoMaderable.find("#txtItemBExtNoMaderableSaldo").val().trim();
                row.OBSERVACION = this.frmBExtNoMaderable.find("#txtItemBExtNoMaderableObservacion").val().trim();
                row.COD_ESPECIES_SERFOR = this.frmBExtNoMaderable.find("#ddlItemBExtNoMaderableEspecies_Serfor").val().trim();
                row.ESPECIES_SERFOR = this.frmBExtNoMaderable.find("#ddlItemBExtNoMaderableEspecies_Serfor").val().trim() == "-" ? "" : this.frmBExtNoMaderable.find("#ddlItemBExtNoMaderableEspecies_Serfor").select2('data')[0].text;

                if (row.RegEstado == 0)
                    row.RegEstado = 2;


                ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListNoMadeBEXTRACCION[row.index] = row;
                this.dtItemBExtNoMaderable.row(this.tr).data(row).draw(false);


                utilSigo.toastSuccess("Exito", "Se modifico con exito");
                this.closeModal();
            }
        }
    };

    //Cuando se importa del excel
    this.addRowsDtExcel = function (data) {
        var $rows = this.dtItemBExtNoMaderable.$("tr");
        var codSecC = $rows.length + 1;
        var list = [];

        for (var i = 0; i < data.length; i++) {

            list.push({
                NRO: codSecC,
                ESPECIES: data[i].ESPECIES,
                ESPECIES_SERFOR: data[i].ESPECIES_SERFOR,
                KILOGRAMO_AUTORIZADO: data[i].KILOGRAMO_AUTORIZADO,
                KILOGRAMO_MOVILIZADO: data[i].KILOGRAMO_MOVILIZADO,
                AUTORIZADO: data[i].AUTORIZADO,
                EXTRAIDO: data[i].EXTRAIDO,
                FECHA1: data[i].FECHA1,
                GUIA_TRANSPORTE: data[i].GUIA_TRANSPORTE,
                FECHA2: data[i].FECHA2,
                RECIBO: data[i].RECIBO,
                SALDO: data[i].SALDO,
                CANTIDAD: data[i].CANTIDAD,
                UNIDAD_MEDIDA: data[i].UNIDAD_MEDIDA,
                OBSERVACION: data[i].OBSERVACION,
                COD_ESPECIES: data[i].COD_ESPECIES,
                COD_ESPECIES_SERFOR: data[i].COD_ESPECIES_SERFOR,
                RegEstado: data[i].RegEstado,
                index: (codSecC - 1),
                COD_SECUENCIAL: 0
            });
            codSecC++;

        }

        Array.prototype.push.apply(ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListNoMadeBEXTRACCION, list);
        this.dtItemBExtNoMaderable.rows.add(list).draw();
        this.dtItemBExtNoMaderable.page('last').draw('page');

    }
}).apply(ManPOA.ItemBExtNoMaderable);
//ItemBExtISitu
(function () {
    this.dtItemBExtISitu;
    this.frmBExtISitu;
    this.divModal;
    this.tr;

    this.init = function () {

        this.divModal = $("#PDivItemBExtISitu");
        this.frmBExtISitu = $("#frmBExtISitu");
        this.dtItemBExtISitu = ManPOA.frmPOARegistro.find("#grvItemBExtISitu").DataTable({
            bServerSide: false,
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: false,
            aaSorting: [],
            bPaginate: true,
            bInfo: false,
            bLengthChange: false,
            scrollCollapse: true,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns: [
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExtISitu.cellEdit },
                { autoWidth: true, bSortable: false, mRender: ManPOA.ItemBExtISitu.cellDel },
                { data: "NRO" },
                { data: "ESPECIES" },
                { data: "ESPECIES_SERFOR" },
                { data: "CANTIDAD_AUTORIZADO" },
                { data: "CANTIDAD_MOVILIZADO" },
                { data: "SALDO" },
                { data: "OBSERVACION" },
                { data: "COD_ESPECIES", visible: false },
                { data: "COD_ESPECIES_SERFOR", visible: false },
                { data: "RegEstado", visible: false },
                { data: "COD_SECUENCIAL", visible: false },
                { data: "index", visible: false }
            ]

        });

        this.frmBExtISitu.find('#ddlItemBExtISituEspecies').select2();
        this.frmBExtISitu.find('#ddlItemBExtISituEspecies_Serfor').select2();

    }
    this.cellEdit = function (data, type, row) {
        return '<i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Editar" onclick="ManPOA.ItemBExtISitu.showModal(0,this);"></i>';

    }
    this.cellDel = function (data, type, row) {
        return '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManPOA.ItemBExtISitu.eliminar(this);"></i>';
    }


    this.showModal = function (RegEstado, obj) {

        if (ManPOA.frmPOARegistro.find("#hdfSelectBExtPOA_Index").val() != '') {

            var PDivTitulo = '';
            if (RegEstado == 1) {
                PDivTitulo = "Nuevo Registro";
            } else
                if (RegEstado == 0) {
                    PDivTitulo = "Modificando Registro";

                    var $tr = $(obj).closest('tr');
                    this.tr = $tr;

                    var row = this.dtItemBExtISitu.row($tr).data();

                    this.frmBExtISitu.find("#ddlItemBExtISituEspecies").val(row.COD_ESPECIES).trigger("change");
                    this.frmBExtISitu.find("#ddlItemBExtISituEspecies_Serfor").val(row.COD_ESPECIES_SERFOR).trigger("change");
                    this.frmBExtISitu.find("#txtItemBExtISituCantidad_Autorizado").val(row.CANTIDAD_AUTORIZADO);
                    this.frmBExtISitu.find("#txtItemBExtISituCantidad_Movilizado").val(row.CANTIDAD_MOVILIZADO);
                    this.frmBExtISitu.find("#txtItemBExtISituSaldo").val(row.SALDO);
                    this.frmBExtISitu.find("#txtItemBExtISituObservacion").val(row.OBSERVACION);

                    this.frmBExtISitu.find("#ddlItemBExtISituEspecies").attr("disabled", true);


                }

            this.divModal.find(".spTitulo").html(PDivTitulo);
            this.frmBExtISitu.find("#hdfItemBExtISitu_RegEstado").val(RegEstado);

            utilSigo.modalDraggable(this.divModal, '.modal-header');
            this.divModal.modal({ keyboard: true, backdrop: 'static' });
        } else {
            utilSigo.toastError("Error", "Seleccione la fecha de emisión del balance al que pertenece el registro");
        }
    }

    this.eliminar = function (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?",
            function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');
                    var row = ManPOA.ItemBExtISitu.dtItemBExtISitu.row($tr).data();
                    if (row.RegEstado == 0 || row.RegEstado == 2) {
                        ManPOA.ListEliTABLA.push({
                            EliTABLA: "POA_INSITU_DET_BEXTRACCION",
                            EliVALOR01: ManPOA.listBExtPOA[ManPOA.indexBExtPOA].COD_SECUENCIAL,
                            EliVALOR02: row.COD_SECUENCIAL
                        });
                    }
                    ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListISituBEXTRACCION.splice(row.index, 1);
                    for (var i = 0; i < ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListISituBEXTRACCION.length; i++) {
                        ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListISituBEXTRACCION[i].index = i;
                        ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListISituBEXTRACCION[i].NRO = (i + 1);
                    }
                    ManPOA.ItemBExtISitu.dtItemBExtISitu.row($tr).remove().draw(false);
                    utilSigo.enumTB(ManPOA.ItemBExtISitu.dtItemBExtISitu, 2);

                }
            });
    }
    this.eliminarTablaAll = function () {

        var $trsEliminar = this.dtItemBExtISitu.$("tr");
        if ($trsEliminar.length > 0) {
            utilSigo.dialogConfirm("", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {
                    for (var row in ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListISituBEXTRACCION) {

                        if (row.RegEstado == 0 || row.RegEstado == 2) {
                            ManPOA.ListEliTABLA.push({
                                EliTABLA: "POA_INSITU_DET_BEXTRACCION",
                                EliVALOR01: ManPOA.listBExtPOA[ManPOA.indexBExtPOA].COD_SECUENCIAL,
                                EliVALOR02: row.COD_SECUENCIAL
                            });
                        }
                    }

                    ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListISituBEXTRACCION = [];
                    ManPOA.ItemBExtISitu.dtItemBExtISitu.clear().draw();
                }
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }
    this.cleanModal = function () {

        this.frmBExtISitu.find("#txtItemBExtISituCantidad_Autorizado").val('');
        this.frmBExtISitu.find("#txtItemBExtISituCantidad_Movilizado").val('');
        this.frmBExtISitu.find("#txtItemBExtISituSaldo").val('');
        this.frmBExtISitu.find("#txtItemBExtISituObservacion").val('');
        this.frmBExtISitu.find("#ddlItemBExtISituEspecies_Serfor").val('-').trigger("change");
        this.frmBExtISitu.find('#ddlItemBExtISituEspecies').prop('disabled', false).trigger("chosen:updated");


    }
    this.closeModal = function () {
        this.cleanModal();
        $(':input', this.frmBExtISitu)
            .removeClass('border-danger')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title');

        this.divModal.modal('hide');
    }
    this.validaSaveModal = function () {

        if (this.frmBExtISitu.find("#hdfItemBExtISitu_RegEstado").val() == '1') {
            if (utilSigo.ValidaCombo("ddlItemBExtISituEspecies", "Seleccione Especie") == false) return false;
        }
        if (utilSigo.ValidaTexto("txtItemBExtISituCantidad_Autorizado", "Ingrese Cantidad Autorizado") == false) return false;
        if (utilSigo.ValidaTexto("txtItemBExtISituCantidad_Movilizado", "Ingrese Cantidad Movilizado") == false) return false;
        if (utilSigo.ValidaTexto("txtItemBExtISituSaldo", "Ingrese Saldo") == false) return false;

        return true;
    }
    this.saveModal = function () {

        if (this.validaSaveModal()) {

            var estado = this.frmBExtISitu.find("#hdfItemBExtISitu_RegEstado").val();

            if (estado == "1") {
                //Nuevo
                var codSecC = this.dtItemBExtISitu.$("tr").length + 1;
                var fila = {
                    NRO: codSecC,
                    ESPECIES: this.frmBExtISitu.find("#ddlItemBExtISituEspecies").select2('data')[0].text,
                    ESPECIES_SERFOR: (this.frmBExtISitu.find("#ddlItemBExtISituEspecies_Serfor").val() == "-" ? "" : this.frmBExtISitu.find("#ddlItemBExtISituEspecies_Serfor").select2('data')[0].text),
                    CANTIDAD_AUTORIZADO: this.frmBExtISitu.find("#txtItemBExtISituCantidad_Autorizado").val().trim(),
                    CANTIDAD_MOVILIZADO: this.frmBExtISitu.find("#txtItemBExtISituCantidad_Movilizado").val().trim(),
                    SALDO: this.frmBExtISitu.find("#txtItemBExtISituSaldo").val().trim(),
                    OBSERVACION: this.frmBExtISitu.find("#txtItemBExtISituObservacion").val().trim(),
                    COD_ESPECIES: this.frmBExtISitu.find("#ddlItemBExtISituEspecies").val(),
                    COD_ESPECIES_SERFOR: this.frmBExtISitu.find("#ddlItemBExtISituEspecies_Serfor").val(),
                    RegEstado: 1,
                    index: (codSecC - 1),
                    COD_SECUENCIAL: 0
                };



                ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListISituBEXTRACCION.push(fila);
                this.dtItemBExtISitu.rows.add([fila]).draw();
                this.dtItemBExtISitu.page('last').draw('page');

            }
            else {

                var row = this.dtItemBExtISitu.row(this.tr).data();
                row.CANTIDAD_AUTORIZADO = this.frmBExtISitu.find("#txtItemBExtISituCantidad_Autorizado").val().trim();
                row.CANTIDAD_MOVILIZADO = this.frmBExtISitu.find("#txtItemBExtISituCantidad_Movilizado").val().trim();
                row.SALDO = this.frmBExtISitu.find("#txtItemBExtISituSaldo").val().trim();
                row.OBSERVACION = this.frmBExtISitu.find("#txtItemBExtISituObservacion").val().trim();
                row.COD_ESPECIES_SERFOR = this.frmBExtISitu.find("#ddlItemBExtISituEspecies_Serfor").val();
                row.ESPECIES_SERFOR = row.COD_ESPECIES_SERFOR == "-" ? "" : this.frmBExtISitu.find("#ddlItemBExtISituEspecies_Serfor").select2('data')[0].text;

                if (row.RegEstado == 0)
                    row.RegEstado = 2;


                ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListISituBEXTRACCION[row.index] = row;
                this.dtItemBExtISitu.row(this.tr).data(row).draw(false);


                utilSigo.toastSuccess("Exito", "Se modifico con exito");
                this.closeModal();
            }
        }
    }

    ////Cuando se importa del excel
    this.addRowsDtExcel = function (data) {
        var $rows = this.dtItemBExtISitu.$("tr");
        var codSecC = $rows.length + 1;
        var list = [];

        for (var i = 0; i < data.length; i++) {

            list.push({
                NRO: codSecC,
                ESPECIES: data[i].ESPECIES,
                ESPECIES_SERFOR: data[i].ESPECIES_SERFOR,
                CANTIDAD_AUTORIZADO: data[i].CANTIDAD_AUTORIZADO,
                CANTIDAD_MOVILIZADO: data[i].CANTIDAD_MOVILIZADO,
                SALDO: data[i].SALDO,
                OBSERVACION: data[i].OBSERVACION,
                COD_ESPECIES: data[i].COD_ESPECIES,
                COD_ESPECIES_SERFOR: data[i].COD_ESPECIES_SERFOR,
                RegEstado: data[i].RegEstado,
                index: (codSecC - 1),
                COD_SECUENCIAL: 0
            });
            codSecC++;

        }

        Array.prototype.push.apply(ManPOA.listBExtPOA[ManPOA.indexBExtPOA].ListISituBEXTRACCION, list);
        this.dtItemBExtISitu.rows.add(list).draw();
        this.dtItemBExtISitu.page('last').draw('page');

    }
}).apply(ManPOA.ItemBExtISitu);
//ItemCMaderable
(function () {
    this.dtItemCMaderable;
    this.frmCMaderable;
    this.divModal;
    this.tr;

    this.init = function () {
        this.divModal = $("#PDivItemCMaderable");
        this.frmCMaderable = $("#frmCMaderable");
        this.dtItemCMaderable = ManPOA.frmPOARegistro.find("#grvItemCMaderable").DataTable({
            bServerSide: false,
            ajax: { url: ManPOA.controller + "/GetAllCensoMaderable", "type": "GET", "datatype": "json" },
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: true,
            aaSorting: [],
            bPaginate: true,
            bInfo: false,
            bLengthChange: false,
            scrollCollapse: true,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns: [
                { bSortable: false, mRender: ManPOA.ItemCMaderable.cellEdit },
                { bSortable: false, mRender: ManPOA.ItemCMaderable.cellDel },
                { data: "NRO" },
                { data: "ESPECIES" },
                { data: "ESPECIES_ARESOLUCION" },
                { data: "BLOQUE" },
                { data: "FAJA" },
                { data: "CODIGO" },
                { data: "VOLUMEN" },
                { data: "DAP" },
                { data: "AC" },
                { data: "DMC" },
                { data: "ZONA" },
                { data: "COORDENADA_ESTE" },
                { data: "COORDENADA_NORTE" },
                { data: "CONDICION" },
                { data: "ESTADO" },
                { data: "PCA" },
                { data: "OBSERVACION" },
                { data: "COD_ESPECIES", visible: false },
                { data: "COD_ESPECIES_ARESOLUCION", visible: false },
                { data: "COD_ECONDICION", visible: false },
                { data: "COD_EESTADO", visible: false },
                { data: "COD_SECUENCIAL", visible: false },
                { data: "RegEstado", visible: false }
            ]
        });

        ManPOA.frmPOARegistro.find('#txtSearchCensoPOA').on('keyup', function () {
            ManPOA.ItemCMaderable.buscarDataTable();
        });
        ManPOA.frmPOARegistro.find('#ddlSearchCensoPOA').on('change', function () {
            ManPOA.ItemCMaderable.buscarDataTable();
        });
        this.frmCMaderable.find('#ddlItemCMaderableEspecies').select2();
        this.frmCMaderable.find('#ddlItemCMaderableEspecies_AResolucion').select2();

    }
    this.buscarDataTable = function () {

        //   var valorBuscar = objeto.value.trim();
        var valorBuscar = ManPOA.frmPOARegistro.find("#txtSearchCensoPOA").val();
        var cboOpcionFilter = ManPOA.frmPOARegistro.find("#ddlSearchCensoPOA").val();
        var tb = ManPOA.ItemCMaderable.dtItemCMaderable;

        tb.search('').columns().search('').draw();
        switch (cboOpcionFilter) {
            case "ESPECIES": tb.column(3).search(valorBuscar).draw(); break;
            case "COORDENADA_NORTE": tb.column(14).search(valorBuscar).draw(); break;
            case "COORDENADA_ESTE": tb.column(13).search(valorBuscar).draw(); break;
            case "BLOQUE": ; tb.column(5).search(valorBuscar).draw(); break;
            case "FAJA": tb.column(6).search(valorBuscar).draw(); break;
            case "CODIGO": tb.column(7).search(valorBuscar).draw(); break;
        }

    }
    this.cellEdit = function (data, type, row) {
        return '<i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Editar" onclick="ManPOA.ItemCMaderable.showModal(0,this);"></i>';

    }
    this.cellDel = function (data, type, row) {
        return '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManPOA.ItemCMaderable.eliminar(this);"></i>';
    }

    this.ddListarPCCenso = function () {
        var pcList = [];
        $('#txtParcelaCenso').find('option').remove().end();
        var parcela = _frmParcela.fnGetList();
        var countFilas = parcela.length;
        if (countFilas > 0) {
            $.each(parcela, function (i, o) {
                //alert(parcela[i].PCA);
                //pcList.push(utilSigo.fnConvertArrayToObject(parcela[i].PCA));
                $('#txtParcelaCenso').append($('<option>', {
                    value: parcela[i].PCA,
                    text: parcela[i].PCA
                }));
            });
        }
    }

    this.showModal = function (RegEstado, obj) {
        this.ddListarPCCenso();

        var PDivTitulo = '';
        if (RegEstado == 1) {
            PDivTitulo = "Nuevo Registro - Censo Maderable";
        } else
            if (RegEstado == 0) {
                PDivTitulo = "Modificando Registro - Censo Maderable";

                this.tr = $(obj).closest('tr');
                var row = this.dtItemCMaderable.row(this.tr).data();

                this.frmCMaderable.find("#ddlItemCMaderableEspecies").val(row.COD_ESPECIES).trigger("change");
                this.frmCMaderable.find("#ddlItemCMaderableEspecies_AResolucion").val(row.COD_ESPECIES_ARESOLUCION).trigger("change");
                this.frmCMaderable.find("#txtParcelaCenso").val(row.PCA);
                this.frmCMaderable.find("#txtItemCMaderableBloque").val(row.BLOQUE);
                this.frmCMaderable.find("#txtItemCMaderableFaja").val(row.FAJA);
                this.frmCMaderable.find("#txtItemCMaderableCodigo").val(row.CODIGO);
                this.frmCMaderable.find("#txtItemCMaderableVolumen").val(row.VOLUMEN);
                this.frmCMaderable.find("#txtItemCMaderableDap").val(row.DAP);
                this.frmCMaderable.find("#txtItemCMaderableAc").val(row.AC);
                this.frmCMaderable.find("#txtItemCMaderableDmc").val(row.DMC);
                this.frmCMaderable.find("#ddlItemCMaderableCod_Econdicion").val(row.COD_ECONDICION);
                this.frmCMaderable.find("#ddlItemCMaderableCod_Eestado").val(row.COD_EESTADO);
                this.frmCMaderable.find("#ddlItemCMaderableZona_UTM").val(row.ZONA == "" ? "0000000" : row.ZONA);
                this.frmCMaderable.find("#txtItemCMaderableCoordenada_Este").val(row.COORDENADA_ESTE);
                this.frmCMaderable.find("#txtItemCMaderableCoordenada_Norte").val(row.COORDENADA_NORTE);
                this.frmCMaderable.find("#txtItemCMaderableObservacion").val(row.OBSERVACION);

            }
        this.frmCMaderable.find("#hdfItemCMaderable_RegEstado").val(RegEstado);
        this.divModal.find(".spTitulo").html(PDivTitulo);
        utilSigo.modalDraggable(this.divModal, '.modal-header');
        this.divModal.modal({ keyboard: true, backdrop: 'static' });

    }

    this.eliminar = function (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?",
            function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');
                    var row = ManPOA.ItemCMaderable.dtItemCMaderable.row($tr).data();
                    if (row.RegEstado == 0 || row.RegEstado == 2) {
                        ManPOA.ListEliTABLA.push({
                            EliTABLA: "POA_DET_MADERABLE_CENSO",
                            EliVALOR01: row.COD_ESPECIES,
                            EliVALOR02: row.COD_SECUENCIAL
                        });
                    }

                    ManPOA.ItemCMaderable.dtItemCMaderable.row($tr).remove().draw(false);
                    utilSigo.enumTB(ManPOA.ItemCMaderable.dtItemCMaderable, 2);

                }
            });
    }
    this.eliminarTablaAll = function () {

        var $trsEliminar = this.dtItemCMaderable.$("tr");
        if ($trsEliminar.length > 0) {
            utilSigo.dialogConfirm("", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {
                    ManPOA.ItemCMaderable.dtItemCMaderable.rows().every(function (rowIdx, tableLoop, rowLoop) {
                        var row = this.data();
                        if (row.RegEstado == 0 || row.RegEstado == 2) {
                            ManPOA.ListEliTABLA.push({
                                EliTABLA: "POA_DET_MADERABLE_CENSO",
                                EliVALOR01: row.COD_ESPECIES,
                                EliVALOR02: row.COD_SECUENCIAL
                            });
                        }
                    });


                    ManPOA.frmPOARegistro.find("#hdELIM_TOTAL_CENSO").val(true);


                    ManPOA.ItemCMaderable.dtItemCMaderable.clear().draw();
                }
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }
    this.cleanModal = function () {


        this.frmCMaderable.find("#txtParcelaCenso").val('');
        this.frmCMaderable.find("#txtItemCMaderableBloque").val('');
        this.frmCMaderable.find("#txtItemCMaderableFaja").val('');
        this.frmCMaderable.find("#txtItemCMaderableCodigo").val('');
        this.frmCMaderable.find("#txtItemCMaderableVolumen").val('');
        this.frmCMaderable.find("#txtItemCMaderableDap").val('');
        this.frmCMaderable.find("#txtItemCMaderableAc").val('');
        this.frmCMaderable.find("#txtItemCMaderableDmc").val('');
        this.frmCMaderable.find("#ddlItemCMaderableCod_Econdicion").val('-');
        this.frmCMaderable.find("#ddlItemCMaderableCod_Eestado").val('-');
        this.frmCMaderable.find("#txtItemCMaderableCoordenada_Este").val('');
        this.frmCMaderable.find("#txtItemCMaderableCoordenada_Norte").val('');
        this.frmCMaderable.find("#txtItemCMaderableObservacion").val('');
        this.frmCMaderable.find("#ddlItemCMaderableEspecies_AResolucion").val('0002226').trigger("change");



    }
    this.closeModal = function () {
        this.cleanModal();
        $(':input', this.frmCMaderable)
            .removeClass('border-danger')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title');

        this.divModal.modal('hide');
    }
    this.validaSaveModal = function () {

        if (this.frmCMaderable.find("#hdfItemCMaderable_RegEstado").val() == '1') {
            if (utilSigo.ValidaCombo("ddlItemCMaderableEspecies", "Seleccione Especie") == false) return false;
        }

        if (utilSigo.ValidaTexto("txtItemCMaderableCodigo", "Ingrese Código") == false) return false;
        if (utilSigo.ValidaTexto("txtItemCMaderableVolumen", "Ingrese Volumen") == false) return false;
        if (utilSigo.ValidaTexto("txtItemCMaderableDap", "Ingrese DAP") == false) return false;
        if (utilSigo.ValidaTexto("txtItemCMaderableAc", "Ingrese AC") == false) return false;
        if (utilSigo.ValidaTexto("txtItemCMaderableDmc", "Ingrese DMC") == false) return false;
        if (utilSigo.ValidaCombo("ddlItemCMaderableCod_Econdicion", "Seleccione Condición") == false) return false;
        if (utilSigo.ValidaCombo("ddlItemCMaderableCod_Eestado", "Seleccione Estado") == false) return false;
        if (utilSigo.ValidaTexto("txtItemCMaderableCoordenada_Este", "Ingrese Coordenada Este") == false) return false;
        if (utilSigo.ValidaTexto("txtItemCMaderableCoordenada_Norte", "Ingrese Coordenada Norte") == false) return false;

        return true;


    }
    this.saveModal = function () {

        if (this.validaSaveModal()) {

            var estado = this.frmCMaderable.find("#hdfItemCMaderable_RegEstado").val();

            var band = 0;
            var parcela = _frmParcela.fnGetList();
            var countFilas = parcela.length;

            if (estado == "1") {
                //Nuevo
                var codSecC = this.dtItemCMaderable.$("tr").length + 1;

                var fila = {
                    NRO: codSecC,
                    ESPECIES: this.frmCMaderable.find("#ddlItemCMaderableEspecies").select2('data')[0].text,
                    ESPECIES_ARESOLUCION: (this.frmCMaderable.find("#ddlItemCMaderableEspecies_AResolucion").val() == "-" ? "" : this.frmCMaderable.find("#ddlItemCMaderableEspecies_AResolucion").select2('data')[0].text),

                    BLOQUE: this.frmCMaderable.find("#txtItemCMaderableBloque").val().trim(),
                    FAJA: this.frmCMaderable.find("#txtItemCMaderableFaja").val().trim(),
                    CODIGO: this.frmCMaderable.find("#txtItemCMaderableCodigo").val().trim(),
                    VOLUMEN: this.frmCMaderable.find("#txtItemCMaderableVolumen").val().trim(),
                    DAP: this.frmCMaderable.find("#txtItemCMaderableDap").val().trim(),
                    AC: this.frmCMaderable.find("#txtItemCMaderableAc").val().trim(),
                    DMC: this.frmCMaderable.find("#txtItemCMaderableDmc").val().trim(),
                    ZONA: this.frmCMaderable.find("#ddlItemCMaderableZona_UTM").val(),
                    COORDENADA_ESTE: this.frmCMaderable.find("#txtItemCMaderableCoordenada_Este").val().trim(),
                    COORDENADA_NORTE: this.frmCMaderable.find("#txtItemCMaderableCoordenada_Norte").val().trim(),
                    CONDICION: this.frmCMaderable.find("#ddlItemCMaderableCod_Econdicion option:selected").text(),
                    ESTADO: this.frmCMaderable.find("#ddlItemCMaderableCod_Eestado option:selected").text(),
                    PCA: this.frmCMaderable.find("#txtParcelaCenso").val(),
                    OBSERVACION: this.frmCMaderable.find("#txtItemCMaderableObservacion").val().trim(),
                    COD_ESPECIES: this.frmCMaderable.find("#ddlItemCMaderableEspecies").val().trim(),
                    COD_ESPECIES_ARESOLUCION: this.frmCMaderable.find("#ddlItemCMaderableEspecies_AResolucion").val(),
                    COD_ECONDICION: this.frmCMaderable.find("#ddlItemCMaderableCod_Econdicion").val(),
                    COD_EESTADO: this.frmCMaderable.find("#ddlItemCMaderableCod_Eestado").val(),
                    RegEstado: 1,
                    COD_SECUENCIAL: 0
                };

                if (countFilas > 0) {
                    for (var j = 0; j < parcela.length; j++) {
                        if (this.frmCMaderable.find("#txtParcelaCenso").val() == parcela[j].PCA) {
                            band = 1;
                        }
                    }
                }
                if (band == 1) {
                    this.dtItemCMaderable.rows.add([fila]).draw();
                    this.dtItemCMaderable.page('last').draw('page');
                    utilSigo.toastSuccess("Exito", "Se adiciono con exito");
                }


            }
            else {

                var row = this.dtItemCMaderable.row(this.tr).data();

                if (countFilas > 0) {
                    for (var j = 0; j < parcela.length; j++) {
                        if (this.frmCMaderable.find("#txtParcelaCenso").val() == parcela[j].PCA) {
                            band = 1;
                        }
                    }
                }
                if (band == 1) {
                    row.COD_ESPECIES = this.frmCMaderable.find("#ddlItemCMaderableEspecies").val();
                    row.ESPECIES = this.frmCMaderable.find("#ddlItemCMaderableEspecies").select2('data')[0].text;
                    row.COD_ESPECIES_ARESOLUCION = this.frmCMaderable.find("#ddlItemCMaderableEspecies_AResolucion").val();
                    row.ESPECIES_ARESOLUCION = row.COD_ESPECIES_ARESOLUCION == "-" ? "" : this.frmCMaderable.find("#ddlItemCMaderableEspecies_AResolucion").select2('data')[0].text;

                    row.BLOQUE = this.frmCMaderable.find("#txtItemCMaderableBloque").val().trim();
                    row.FAJA = this.frmCMaderable.find("#txtItemCMaderableFaja").val().trim();
                    row.CODIGO = this.frmCMaderable.find("#txtItemCMaderableCodigo").val().trim();
                    row.VOLUMEN = this.frmCMaderable.find("#txtItemCMaderableVolumen").val().trim();
                    row.DAP = this.frmCMaderable.find("#txtItemCMaderableDap").val().trim();
                    row.AC = this.frmCMaderable.find("#txtItemCMaderableAc").val().trim();
                    row.DMC = this.frmCMaderable.find("#txtItemCMaderableDmc").val().trim();
                    row.COD_ECONDICION = this.frmCMaderable.find("#ddlItemCMaderableCod_Econdicion").val();
                    row.COD_EESTADO = this.frmCMaderable.find("#ddlItemCMaderableCod_Eestado").val();
                    row.ZONA = this.frmCMaderable.find("#ddlItemCMaderableZona_UTM").val();
                    row.COORDENADA_ESTE = this.frmCMaderable.find("#txtItemCMaderableCoordenada_Este").val().trim();
                    row.COORDENADA_NORTE = this.frmCMaderable.find("#txtItemCMaderableCoordenada_Norte").val().trim();
                    row.PCA = this.frmCMaderable.find("#txtParcelaCenso").val().trim();
                    row.OBSERVACION = this.frmCMaderable.find("#txtItemCMaderableObservacion").val().trim();
                    row.CONDICION = this.frmCMaderable.find("#ddlItemCMaderableCod_Econdicion option:selected").text();
                    row.ESTADO = this.frmCMaderable.find("#ddlItemCMaderableCod_Eestado option:selected").text();


                    if (row.RegEstado == 0)
                        row.RegEstado = 2;


                    this.dtItemCMaderable.row(this.tr).data(row).draw(false);
                    utilSigo.toastSuccess("Exito", "Se modifico con exito");
                    this.closeModal();
                }
            }
            if (band == 0) {
                utilSigo.toastWarning("Error", "Registre primero parcelas");
                this.closeModal();
            }
        }
    }

    ////Cuando se importa del excel
    this.addRowsDtExcel = function (data) {
        var $rows = this.dtItemCMaderable.$("tr");
        var codSecC = $rows.length + 1;
        var list = [];
        /*se agrega para la validacion de parcelas*/
        var band = 0;
        var parcela = _frmParcela.fnGetList();
        var countFilas = parcela.length;

        band = 0;
        for (var i = 0; i < data.length; i++) {

            list.push({
                NRO: codSecC,
                ESPECIES: data[i].ESPECIES,
                ESPECIES_ARESOLUCION: data[i].ESPECIES_ARESOLUCION,
                BLOQUE: data[i].BLOQUE,
                FAJA: data[i].FAJA,
                CODIGO: data[i].CODIGO,
                VOLUMEN: data[i].VOLUMEN,
                DAP: data[i].DAP,
                AC: data[i].AC,
                DMC: data[i].DMC,
                ZONA: data[i].ZONA,
                COORDENADA_ESTE: data[i].COORDENADA_ESTE,
                COORDENADA_NORTE: data[i].COORDENADA_NORTE,
                CONDICION: data[i].CONDICION,
                ESTADO: data[i].ESTADO,
                PCA: data[i].PCA,
                OBSERVACION: data[i].OBSERVACION,
                COD_ESPECIES: "",
                COD_ESPECIES_ARESOLUCION: "",
                COD_ECONDICION: "",
                COD_EESTADO: "",
                RegEstado: 1,
                COD_SECUENCIAL: 0
            });
            codSecC++;

            if (countFilas > 0) {
                for (var j = 0; j < parcela.length; j++) {
                    if (data[i].PCA == parcela[j].PCA) {
                        band = band + 1;
                    }
                }
            }

        }

        if (data.length == band) {
            this.dtItemCMaderable.rows.add(list).draw();
        }
        else {
            utilSigo.toastWarning("Error", "Las parcelas en la plantilla no coinciden con lo registrado");
        }
        this.dtItemCMaderable.page('last').draw('page');

    }
    this.tabsActiveCenso = function () {


        $("#navDatosTab").hide();
        $("#navDatosAdicTab").hide();
        $("#navCensoNoMaderableTab").hide();
        $("#divTitle").hide();
        $("#navDatosAcervoTab").hide();

        $("#navCensoMaderableTab").show();
        $('.nav-tabs a[href="#navCensoMaderable"]').tab('show');


    }
    this.tabsInactiveCenso = function () {
        $("#divTitle").show();
        $("#navDatosTab").show();
        $("#navDatosAdicTab").show();
        $("#navDatosAcervoTab").show();

        $("#navCensoNoMaderableTab").hide();
        $("#navCensoMaderableTab").hide();
        ManPOA.frmPOARegistro.find("#lbtMaderableItemCensoSelec").html("Ir Censo Maderable ( " + ManPOA.ItemCMaderable.dtItemCMaderable.data().count() + " )");
        $('.nav-tabs a[href="#navDatosAdic"]').tab('show');
    }

    this.exportarExcel = function (TVentana) {
        //alert("aquicito" + ManPOA.frmPOARegistro.find("#txtItemNumPOA").val());
        if (this.dtItemCMaderable.rows().count() > 0) {
            var datos = {};
            datos.hdfItemCod_THabilitante = ManPOA.frmPOARegistro.find("#hdfItemCod_THabilitante").val();
            datos.txtItemNumPOA = ManPOA.frmPOARegistro.find("#txtItemNumPOA").val();
            //datos.ListMadeCENSO = this.dtItemCMaderable.rows().data().toArray();
            datos.TVentana = TVentana;
            $.ajax({
                url: ManPOA.controller + "/ExportExcel",
                type: 'POST',
                data: JSON.stringify(datos),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                //beforeSend: utilSigo.beforeSendAjax,
                //complete: utilSigo.completeAjax,
                error: utilSigo.errorAjax,
                success: function (data) {
                    if (data.success) {
                        window.location.href = ManPOA.controller + "/Download?file=" + data.values[0];
                    }
                    else utilSigo.toastWarning("Error", data.msj);
                }
            });
        } else {
            utilSigo.toastWarning("Error", "No tiene datos para exportar");
        }

    }

}).apply(ManPOA.ItemCMaderable);
//ItemCNoMaderable
(function () {
    this.dtItemCNoMaderable;
    this.frmCNoMaderable;
    this.divModal;
    this.tr;
    this.init = function () {

        this.divModal = $("#PDivItemCNoMaderable");
        this.frmCNoMaderable = $("#frmCNoMaderable");
        this.dtItemCNoMaderable = ManPOA.frmPOARegistro.find("#grvItemCNoMaderable").DataTable({
            bServerSide: false,
            ajax: { url: ManPOA.controller + "/GetAllCensoNoMaderable", "type": "GET", "datatype": "json" },
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: true,
            aaSorting: [],
            bPaginate: true,
            bInfo: false,
            bLengthChange: false,
            scrollCollapse: true,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns: [
                { bSortable: false, mRender: ManPOA.ItemCNoMaderable.cellEdit },
                { bSortable: false, mRender: ManPOA.ItemCNoMaderable.cellDel },
                { data: "NRO" },
                { data: "ESPECIES" },
                { data: "ESPECIES_ARESOLUCION" },
                { data: "NUM_ESTRADA" },
                { data: "CODIGO" },
                { data: "DIAMETRO" },
                { data: "ALTURA" },
                { data: "PRODUCCION_LATAS" },
                { data: "ZONA" },
                { data: "COORDENADA_ESTE" },
                { data: "COORDENADA_NORTE" },
                { data: "CONDICION" },
                { data: "OBSERVACION" },
                { data: "COD_ESPECIES", visible: false },
                { data: "COD_ESPECIES_ARESOLUCION", visible: false },
                { data: "COD_ECONDICION", visible: false },
                { data: "COD_SECUENCIAL", visible: false },
                { data: "RegEstado", visible: false }

            ]
        });


        this.frmCNoMaderable.find('#ddlItemCNoMaderableEspecies').select2();
        this.frmCNoMaderable.find('#ddlItemCNoMaderableEspecies_AResolucion').select2();

    }

    this.cellEdit = function (data, type, row) {
        return '<i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Editar" onclick="ManPOA.ItemCNoMaderable.showModal(0,this);"></i>';

    }
    this.cellDel = function (data, type, row) {
        return '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManPOA.ItemCNoMaderable.eliminar(this);"></i>';
    }


    this.showModal = function (RegEstado, obj) {


        var PDivTitulo = '';
        if (RegEstado == 1) {
            PDivTitulo = "Nuevo Registro - Censo No Maderable";
        } else
            if (RegEstado == 0) {
                PDivTitulo = "Modificando Registro - Censo No Maderableo";

                this.tr = $(obj).closest('tr');
                var row = this.dtItemCNoMaderable.row(this.tr).data();

                this.frmCNoMaderable.find("#ddlItemCNoMaderableEspecies").val(row.COD_ESPECIES).trigger("change");
                this.frmCNoMaderable.find("#ddlItemCNoMaderableEspecies_AResolucion").val(row.COD_ESPECIES_ARESOLUCION).trigger("change");
                this.frmCNoMaderable.find("#txtItemCNoMaderableNum_Estrada").val(row.NUM_ESTRADA);
                this.frmCNoMaderable.find("#txtItemCNoMaderableCodigo").val(row.CODIGO);
                this.frmCNoMaderable.find("#txtItemCNoMaderableDiametro").val(row.DIAMETRO);
                this.frmCNoMaderable.find("#txtItemCNoMaderableAltura").val(row.ALTURA);
                this.frmCNoMaderable.find("#txtItemCNoMaderableProduccion_Latas").val(row.PRODUCCION_LATAS);
                this.frmCNoMaderable.find("#ddlItemCNoMaderableCod_Econdicion").val(row.COD_ECONDICION);
                this.frmCNoMaderable.find("#ddlItemCNoMaderableZona_UTM").val(row.ZONA == "" ? "0000000" : row.ZONA);
                this.frmCNoMaderable.find("#txtItemCNoMaderableCoordenada_Este").val(row.COORDENADA_ESTE);
                this.frmCNoMaderable.find("#txtItemCNoMaderableCoordenada_Norte").val(row.COORDENADA_NORTE);
                this.frmCNoMaderable.find("#txtItemCNoMaderableObservacion").val(row.OBSERVACION);
                this.frmCNoMaderable.find("#ddlItemCNoMaderableEspecies").attr("disabled", true);

                if (row.RegEstado == 1) {
                    this.frmCNoMaderable.find("#ddlItemCNoMaderableEspecies").toggle(true);
                }



            }
        this.frmCNoMaderable.find("#hdfItemCNoMaderable_RegEstado").val(RegEstado);
        this.divModal.find(".spTitulo").html(PDivTitulo);
        utilSigo.modalDraggable(this.divModal, '.modal-header');
        this.divModal.modal({ keyboard: true, backdrop: 'static' });

    }

    this.eliminar = function (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?",
            function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');
                    var row = ManPOA.ItemCNoMaderable.dtItemCNoMaderable.row($tr).data();
                    if (row.RegEstado == 0 || row.RegEstado == 2) {
                        ManPOA.ListEliTABLA.push({
                            EliTABLA: "POA_DET_NOMADERABLE_CENSO",
                            EliVALOR01: row.COD_ESPECIES,
                            EliVALOR02: row.COD_SECUENCIAL
                        });
                    }
                    ManPOA.ItemCNoMaderable.dtItemCNoMaderable.row($tr).remove().draw(false);
                    utilSigo.enumTB(ManPOA.ItemCNoMaderable.dtItemCNoMaderable, 2);

                }
            });
    }
    this.eliminarTablaAll = function () {

        var $trsEliminar = this.dtItemCNoMaderable.$("tr");
        if ($trsEliminar.length > 0) {
            utilSigo.dialogConfirm("", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {

                    ManPOA.ItemCNoMaderable.dtItemCNoMaderable.rows().every(function (rowIdx, tableLoop, rowLoop) {
                        var row = this.data();
                        if (row.RegEstado == 0 || row.RegEstado == 2) {
                            ManPOA.ListEliTABLA.push({
                                EliTABLA: "POA_DET_NOMADERABLE_CENSO",
                                EliVALOR01: row.COD_ESPECIES,
                                EliVALOR02: row.COD_SECUENCIAL
                            });
                        }
                    });
                    ManPOA.ItemCNoMaderable.dtItemCNoMaderable.clear().draw();
                }
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }
    this.cleanModal = function () {

        this.frmCNoMaderable.find("#txtItemCNoMaderableNum_Estrada").val('');
        this.frmCNoMaderable.find("#txtItemCNoMaderableCodigo").val('');
        this.frmCNoMaderable.find("#txtItemCNoMaderableDiametro").val('');
        this.frmCNoMaderable.find("#txtItemCNoMaderableAltura").val('');
        this.frmCNoMaderable.find("#txtItemCNoMaderableProduccion_Latas").val('');
        this.frmCNoMaderable.find("#ddlItemCNoMaderableCod_Econdicion").val('-');
        this.frmCNoMaderable.find("#txtItemCNoMaderableCoordenada_Este").val('');
        this.frmCNoMaderable.find("#txtItemCNoMaderableCoordenada_Norte").val('');
        this.frmCNoMaderable.find("#txtItemCNoMaderableObservacion").val('');
        this.frmCNoMaderable.find("#ddlItemCNoMaderableEspecies_AResolucion").val('0002226').trigger("change");





    }
    this.closeModal = function () {
        this.cleanModal();
        $(':input', this.frmCNoMaderable)
            .removeClass('border-danger')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title');

        this.divModal.modal('hide');
    }
    this.validaSaveModal = function () {

        if (this.frmCNoMaderable.find("#hdfItemCNoMaderable_RegEstado").val() == '1') {
            if (utilSigo.ValidaCombo("ddlItemCNoMaderableEspecies", "Seleccione Especie") == false) return false;
        }
        if (utilSigo.ValidaTexto("txtItemCNoMaderableNum_Estrada", "Ingrese Número Estrada") == false) return false;
        if (utilSigo.ValidaTexto("txtItemCNoMaderableCodigo", "Ingrese Código") == false) return false;
        if (utilSigo.ValidaTexto("txtItemCNoMaderableDiametro", "Ingrese Diámetro") == false) return false;
        if (utilSigo.ValidaTexto("txtItemCNoMaderableAltura", "Ingrese Altura") == false) return false;
        if (utilSigo.ValidaTexto("txtItemCNoMaderableProduccion_Latas", "Ingrese Producción Latas") == false) return false;
        if (utilSigo.ValidaCombo("ddlItemCNoMaderableCod_Econdicion", "Seleccione Condición") == false) return false;
        if (utilSigo.ValidaTexto("txtItemCNoMaderableCoordenada_Este", "Ingrese Coordenada Este") == false) return false;
        if (utilSigo.ValidaTexto("txtItemCNoMaderableCoordenada_Norte", "Ingrese Coordenada Norte") == false) return false;
        return true;

    }
    this.saveModal = function () {

        if (this.validaSaveModal()) {

            var estado = this.frmCNoMaderable.find("#hdfItemCNoMaderable_RegEstado").val();

            if (estado == "1") {
                //Nuevo
                var codSecC = this.dtItemCNoMaderable.$("tr").length + 1;

                var fila = {
                    NRO: codSecC,
                    ESPECIES: this.frmCNoMaderable.find("#ddlItemCNoMaderableEspecies").select2('data')[0].text,
                    ESPECIES_ARESOLUCION: (this.frmCNoMaderable.find("#ddlItemCNoMaderableEspecies_AResolucion").val() == "-" ? "" : this.frmCNoMaderable.find("#ddlItemCNoMaderableEspecies_AResolucion").select2('data')[0].text),
                    NUM_ESTRADA: this.frmCNoMaderable.find("#txtItemCNoMaderableNum_Estrada").val().trim(),
                    CODIGO: this.frmCNoMaderable.find("#txtItemCNoMaderableCodigo").val().trim(),
                    DIAMETRO: this.frmCNoMaderable.find("#txtItemCNoMaderableDiametro").val().trim(),
                    ALTURA: this.frmCNoMaderable.find("#txtItemCNoMaderableAltura").val().trim(),
                    PRODUCCION_LATAS: this.frmCNoMaderable.find("#txtItemCNoMaderableProduccion_Latas").val().trim(),
                    ZONA: this.frmCNoMaderable.find("#ddlItemCNoMaderableZona_UTM").val(),
                    COORDENADA_ESTE: this.frmCNoMaderable.find("#txtItemCNoMaderableCoordenada_Este").val().trim(),
                    COORDENADA_NORTE: this.frmCNoMaderable.find("#txtItemCNoMaderableCoordenada_Norte").val().trim(),
                    CONDICION: this.frmCNoMaderable.find("#ddlItemCNoMaderableCod_Econdicion option:selected").text(),
                    OBSERVACION: this.frmCNoMaderable.find("#txtItemCNoMaderableObservacion").val().trim(),
                    COD_ESPECIES: this.frmCNoMaderable.find("#ddlItemCNoMaderableEspecies").val(),
                    COD_ESPECIES_ARESOLUCION: this.frmCNoMaderable.find("#ddlItemCNoMaderableEspecies_AResolucion").val(),
                    COD_ECONDICION: this.frmCNoMaderable.find("#ddlItemCNoMaderableCod_Econdicion").val(),
                    RegEstado: 1,
                    COD_SECUENCIAL: 0
                };
                this.dtItemCNoMaderable.rows.add([fila]).draw();
                this.dtItemCNoMaderable.page('last').draw('page');
                utilSigo.toastSuccess("Exito", "Se adiciono con exito");
            }
            else {

                var row = this.dtItemCNoMaderable.row(this.tr).data();
                if (row.RegEstado == 1) {
                    row.COD_ESPECIES = this.frmCNoMaderable.find("#ddlItemCNoMaderableEspecies").val();
                    row.ESPECIES = this.frmCNoMaderable.find("#ddlItemCNoMaderableEspecies").select2('data')[0].text;
                }
                row.NUM_ESTRADA = this.frmCNoMaderable.find("#txtItemCNoMaderableNum_Estrada").val().trim();
                row.CODIGO = this.frmCNoMaderable.find("#txtItemCNoMaderableCodigo").val().trim();
                row.DIAMETRO = this.frmCNoMaderable.find("#txtItemCNoMaderableDiametro").val().trim();
                row.ALTURA = this.frmCNoMaderable.find("#txtItemCNoMaderableAltura").val().trim();
                row.PRODUCCION_LATAS = this.frmCNoMaderable.find("#txtItemCNoMaderableProduccion_Latas").val().trim();
                row.COD_ECONDICION = this.frmCNoMaderable.find("#ddlItemCNoMaderableCod_Econdicion").val();
                row.ZONA = this.frmCNoMaderable.find("#ddlItemCNoMaderableZona_UTM").val();
                row.COORDENADA_ESTE = this.frmCNoMaderable.find("#txtItemCNoMaderableCoordenada_Este").val().trim();
                row.COORDENADA_NORTE = this.frmCNoMaderable.find("#txtItemCNoMaderableCoordenada_Norte").val().trim();
                row.CONDICION = this.frmCNoMaderable.find("#ddlItemCNoMaderableCod_Econdicion option:selected").text();
                row.COD_ESPECIES_ARESOLUCION = this.frmCNoMaderable.find("#ddlItemCNoMaderableEspecies_AResolucion").val();
                row.ESPECIES_ARESOLUCION = row.COD_ESPECIES_ARESOLUCION == "-" ? "" : this.frmCNoMaderable.find("#ddlItemCNoMaderableEspecies_AResolucion").select2('data')[0].text;
                row.OBSERVACION = this.frmCNoMaderable.find("#txtItemCNoMaderableObservacion").val().trim();


                if (row.RegEstado == 0)
                    row.RegEstado = 2;


                this.dtItemCNoMaderable.row(this.tr).data(row).draw(false);
                utilSigo.toastSuccess("Exito", "Se modifico con exito");
                this.closeModal();
            }
        }
    }

    ////Cuando se importa del excel
    this.addRowsDtExcel = function (data) {
        var $rows = this.dtItemCNoMaderable.$("tr");
        var codSecC = $rows.length + 1;
        var list = [];

        for (var i = 0; i < data.length; i++) {

            list.push({
                NRO: codSecC,
                ESPECIES: data[i].ESPECIES,
                ESPECIES_ARESOLUCION: data[i].ESPECIES_ARESOLUCION,
                NUM_ESTRADA: data[i].NUM_ESTRADA,
                CODIGO: data[i].CODIGO,
                DIAMETRO: data[i].DIAMETRO,
                ALTURA: data[i].ALTURA,
                PRODUCCION_LATAS: data[i].PRODUCCION_LATAS,
                ZONA: data[i].ZONA,
                COORDENADA_ESTE: data[i].COORDENADA_ESTE,
                COORDENADA_NORTE: data[i].COORDENADA_NORTE,
                CONDICION: data[i].CONDICION,
                OBSERVACION: data[i].OBSERVACION,
                COD_ESPECIES: "",
                COD_ESPECIES_ARESOLUCION: "",
                COD_ECONDICION: "",
                RegEstado: data[i].RegEstado,
                COD_SECUENCIAL: 0
            });
            codSecC++;

        }


        this.dtItemCNoMaderable.rows.add(list).draw();
        this.dtItemCNoMaderable.page('last').draw('page');

    }
    this.tabsActiveCenso = function () {


        $("#navDatosTab").hide();
        $("#navDatosAdicTab").hide();
        $("#navDatosAcervoTab").hide();
        $("#divTitle").hide();
        $("#navCensoNoMaderableTab").show();
        $('.nav-tabs a[href="#navCensoNoMaderable"]').tab('show');


    }
    this.tabsInactiveCenso = function () {
        $("#divTitle").show();
        $("#navDatosTab").show();
        $("#navDatosAdicTab").show();
        $("#navDatosAcervoTab").show();
        $("#navCensoNoMaderableTab").hide();


        ManPOA.frmPOARegistro.find("#lbtNoMaderableItemCensoSelec").html("Ir Censo No Maderable ( " + ManPOA.ItemCNoMaderable.dtItemCNoMaderable.data().count() + " )");
        $('.nav-tabs a[href="#navDatosAdic"]').tab('show');


    }

    this.exportarExcel = function (TVentana) {
        if (this.dtItemCNoMaderable.rows().count() > 0) {
            var datos = {};
            datos.ListNoMadeCENSO = this.dtItemCNoMaderable.rows().data().toArray();;
            datos.TVentana = TVentana;
            $.ajax({
                url: ManPOA.controller + "/ExportExcel",
                type: 'POST',
                data: JSON.stringify(datos),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                //beforeSend: utilSigo.beforeSendAjax,
                //complete: utilSigo.completeAjax,
                error: utilSigo.errorAjax,
                success: function (data) {
                    if (data.success) {
                        window.location.href = ManPOA.controller + "/Download?file=" + data.values[0];
                    }
                    else utilSigo.toastWarning("Error", data.msj);
                }
            });
        } else {
            utilSigo.toastWarning("Error", "No tiene datos para exportar");
        }

    }

}).apply(ManPOA.ItemCNoMaderable);
//Itemkardex
(function () {
    this.dtItemkardex;
    this.frmkardex;
    this.divModal;
    this.tr;

    this.init = function () {

        this.divModal = $("#PDivkardex");
        this.frmkardex = $("#frmkardex");
        this.dtItemkardex = ManPOA.frmPOARegistro.find("#grvItemkardex").DataTable({
            bServerSide: false,
            ajax: { url: ManPOA.controller + "/GetAllkardex", "type": "GET", "datatype": "json" },
            bProcessing: true,
            bJQueryUI: false,
            bRetrieve: true,
            bFilter: true,
            aaSorting: [],
            bPaginate: true,
            bInfo: false,
            bLengthChange: false,
            scrollCollapse: true,
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            columns: [
                { bSortable: false, mRender: ManPOA.Itemkardex.cellEdit },
                { bSortable: false, mRender: ManPOA.Itemkardex.cellDel },
                { data: "NRO" },
                { data: "ESPECIES" },
                { data: "FECHA_EMISIONKARDEX" },
                { data: "GUIA_TRANSPORTE" },
                { data: "PRODUCTO" },
                { data: "DESCRIPCION_KARDEX" },
                { data: "CANTIDAD" },
                { data: "KILOGRAMOS_KARDEX" },
                { data: "M3" },
                { data: "ACUMULADO" },
                { data: "SALDO_KARDEX" },
                { data: "OBSERVACION_KARDEX" },
                { data: "COD_ESPECIES", visible: false },
                { data: "COD_KARDEX_PRODUCTO", visible: false },
                { data: "COD_KARDEX_DESCRIPCION", visible: false },
                { data: "COD_SECUENCIAL", visible: false },
                { data: "RegEstado", visible: false }

            ]
        });



        this.frmkardex.find('#ddlItemkeardexEspecies').select2();
        this.frmkardex.find("#txtItemkardexfemision").datepicker(initSigo.formatDatePicker);
    }

    this.cellEdit = function (data, type, row) {
        return '<i class="fa fa-lg fa-pencil-square-o" style="color:blue;cursor:pointer;" title="Editar" onclick="ManPOA.Itemkardex.showModal(0,this);"></i>';

    }
    this.cellDel = function (data, type, row) {
        return '<i class="fa fa-lg fa-window-close" style="color:red;cursor:pointer;" title="Eliminar" onclick="ManPOA.Itemkardex.eliminar(this);"></i>';
    }


    this.showModal = function (RegEstado, obj) {


        var PDivTitulo = '';
        if (RegEstado == 1) {
            PDivTitulo = "Nuevo Registro";
        } else
            if (RegEstado == 0) {
                PDivTitulo = "Modificando Registro";

                this.tr = $(obj).closest('tr');
                var row = this.dtItemkardex.row(this.tr).data();

                this.frmkardex.find("#ddlItemkeardexEspecies").val(row.COD_ESPECIES).trigger("change");
                this.frmkardex.find("#txtItemkardexfemision").val(row.FECHA_EMISIONKARDEX);
                this.frmkardex.find("#txtItemkardexguia").val(row.GUIA_TRANSPORTE);
                this.frmkardex.find("#ddlItemkeardexProducto").val(row.COD_KARDEX_PRODUCTO);
                this.frmkardex.find("#ddlItemkeardexDescripcion").val(row.COD_KARDEX_DESCRIPCION);
                this.frmkardex.find("#txtItemkardexcantidad").val(row.CANTIDAD);
                this.frmkardex.find("#txtItemkardexkilogramos").val(row.KILOGRAMOS_KARDEX);
                this.frmkardex.find("#txtItemkardexmt").val(row.M3);
                this.frmkardex.find("#txtItemkardexacumulado").val(row.ACUMULADO);
                this.frmkardex.find("#txtItemkardexsaldo").val(row.SALDO_KARDEX);
                this.frmkardex.find("#txtItemkardexobs").val(row.OBSERVACION_KARDEX);
                this.frmkardex.find("#ddlItemkeardexEspecies").attr("disabled", true);





            }
        this.frmkardex.find("#hdfItemkardex_RegEstado").val(RegEstado);
        this.divModal.find(".spTitulo").html(PDivTitulo);
        utilSigo.modalDraggable(this.divModal, '.modal-header');
        this.divModal.modal({ keyboard: true, backdrop: 'static' });

    }

    this.eliminar = function (obj) {
        utilSigo.dialogConfirm("Confirmacion", "¿ Está seguro de Eliminar el Registro Seleccionado ?",
            function (r) {
                if (r) {
                    var $tr = $(obj).closest('tr');
                    var row = ManPOA.Itemkardex.dtItemkardex.row($tr).data();
                    if (row.RegEstado == 0 || row.RegEstado == 2) {
                        ManPOA.ListEliTABLA.push({
                            EliTABLA: "POA_DET_KARDEX",
                            EliVALOR01: row.COD_ESPECIES,
                            EliVALOR02: row.COD_SECUENCIAL
                        });
                    }
                    ManPOA.Itemkardex.dtItemkardex.row($tr).remove().draw(false);
                    utilSigo.enumTB(ManPOA.Itemkardex.dtItemkardex, 2);

                }
            });
    }
    this.eliminarTablaAll = function () {

        var $trsEliminar = this.dtItemkardex.$("tr");
        if ($trsEliminar.length > 0) {
            utilSigo.dialogConfirm("", "Está seguro de Eliminar Todo los Registros?", function (r) {
                if (r) {

                    ManPOA.Itemkardex.dtItemkardex.rows().every(function (rowIdx, tableLoop, rowLoop) {
                        var row = this.data();
                        if (row.RegEstado == 0 || row.RegEstado == 2) {
                            ManPOA.ListEliTABLA.push({
                                EliTABLA: "POA_DET_KARDEX",
                                EliVALOR01: row.COD_ESPECIES,
                                EliVALOR02: row.COD_SECUENCIAL
                            });
                        }
                    });
                    ManPOA.Itemkardex.dtItemkardex.clear().draw();
                }
            });
        }
        else {
            utilSigo.toastWarning("Aviso", "No hay Registros a Eliminar");
        }
    }
    this.cleanModal = function () {

        this.frmkardex.find("#txtItemkardexacumulado").val('');
        this.frmkardex.find("#txtItemkardexcantidad").val('');
        this.frmkardex.find("#txtItemkardexfemision").val('');
        this.frmkardex.find("#txtItemkardexguia").val('');
        this.frmkardex.find("#txtItemkardexkilogramos").val('');
        this.frmkardex.find("#txtItemkardexmt").val('');
        this.frmkardex.find("#txtItemkardexobs").val('');
        this.frmkardex.find("#txtItemkardexsaldo").val('');
        this.frmkardex.find("#ddlItemkeardexEspecies").attr("disabled", false);

    }
    this.closeModal = function () {
        this.cleanModal();
        $(':input', this.frmkardex)
            .removeClass('border-danger')
            .removeAttr('data-toggle')
            .removeAttr('data-placement')
            .removeAttr('data-original-title');

        this.divModal.modal('hide');
    }
    this.validaSaveModal = function () {


        if (this.frmkardex.find("#hdfItemkardex_RegEstado").val() == '1') {
            if (utilSigo.ValidaCombo("ddlItemkeardexEspecies", "Seleccione Especie") == false) return false;
        }
        if (utilSigo.ValidaTexto("txtItemkardexfemision", "Ingrese Fecha de Emisión") == false) return false;
        if (utilSigo.ValidaTexto("txtItemkardexguia", "Ingrese Guia de Transporte") == false) return false;
        if (utilSigo.ValidaTexto("txtItemkardexcantidad", "Ingrese Cantidad") == false) return false;
        return true;

    }
    this.saveModal = function () {

        if (this.validaSaveModal()) {

            var estado = this.frmkardex.find("#hdfItemkardex_RegEstado").val();

            if (estado == "1") {
                //Nuevo
                var codSecC = this.dtItemkardex.$("tr").length + 1;


                var fila = {
                    NRO: codSecC,
                    ESPECIES: this.frmkardex.find("#ddlItemkeardexEspecies").select2('data')[0].text,
                    FECHA_EMISIONKARDEX: this.frmkardex.find("#txtItemkardexfemision").val().trim(),
                    GUIA_TRANSPORTE: this.frmkardex.find("#txtItemkardexguia").val().trim(),
                    COD_KARDEX_PRODUCTO: this.frmkardex.find("#ddlItemkeardexProducto").val(),
                    PRODUCTO: this.frmkardex.find("#ddlItemkeardexProducto").val(),
                    COD_KARDEX_DESCRIPCION: this.frmkardex.find("#ddlItemkeardexDescripcion").val(),
                    DESCRIPCION_KARDEX: this.frmkardex.find("#ddlItemkeardexDescripcion option:selected").text(),
                    CANTIDAD: this.frmkardex.find("#txtItemkardexcantidad").val().trim(),
                    KILOGRAMOS_KARDEX: this.frmkardex.find("#txtItemkardexkilogramos").val().trim(),
                    M3: this.frmkardex.find("#txtItemkardexmt").text().trim(),
                    ACUMULADO: this.frmkardex.find("#txtItemkardexacumulado").val().trim(),
                    SALDO_KARDEX: this.frmkardex.find("#txtItemkardexsaldo").val().trim(),
                    OBSERVACION_KARDEX: this.frmkardex.find("#txtItemkardexobs").val().trim(),
                    COD_ESPECIES: this.frmkardex.find("#ddlItemkeardexEspecies").val(),
                    RegEstado: 1,
                    COD_SECUENCIAL: 0
                };

                this.dtItemkardex.rows.add([fila]).draw();
                this.dtItemkardex.page('last').draw('page');
                utilSigo.toastSuccess("Exito", "Se adiciono con exito");
            }
            else {

                var row = this.dtItemkardex.row(this.tr).data();


                row.FECHA_EMISIONKARDEX = this.frmkardex.find("#txtItemkardexfemision").val().trim();
                row.GUIA_TRANSPORTE = this.frmkardex.find("#txtItemkardexguia").val().trim();
                row.COD_KARDEX_PRODUCTO = this.frmkardex.find("#ddlItemkeardexProducto").val().trim();
                row.COD_KARDEX_DESCRIPCION = this.frmkardex.find("#ddlItemkeardexDescripcion").val().trim();
                row.CANTIDAD = this.frmkardex.find("#txtItemkardexcantidad").val().trim();
                row.KILOGRAMOS_KARDEX = this.frmkardex.find("#txtItemkardexkilogramos").val().trim();
                row.M3 = this.frmkardex.find("#txtItemkardexmt").val().trim();
                row.ACUMULADO = this.frmkardex.find("#txtItemkardexacumulado").val().trim();
                row.SALDO_KARDEX = this.frmkardex.find("#txtItemkardexsaldo").val().trim();
                row.OBSERVACION_KARDEX = this.frmkardex.find("#txtItemkardexobs").val().trim();

                if (row.RegEstado == 0)
                    row.RegEstado = 2;


                this.dtItemkardex.row(this.tr).data(row).draw(false);
                utilSigo.toastSuccess("Exito", "Se modifico con exito");
                this.closeModal();
            }
        }
    }


}).apply(ManPOA.Itemkardex);