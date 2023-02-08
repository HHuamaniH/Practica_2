"use strict";


class MainAlert {
    constructor(nameObject) {
        this.frm;
        this.dt;
        this.nameObject = nameObject;
        this.urlController = urlLocalSigo + "Supervision/Alerta/AddEdit";
    }
    init() {
        this.frm = $("#frmAlerta");
        this.dt = this.frm.find("#grvAlerta").DataTable({
            bProcessing: true,
            bRetrieve: true,
            dom: 'Bfrtip',
            bLengthChange: false,
            scrollCollapse: true,
            aaSorting: [],
            pageLength: initSigo.pageLength,
            oLanguage: initSigo.oLanguage,
            drawCallback: initSigo.showPagination,
            buttons: [ ]
            ,columns: [
                { bSortable: false, mRender: this.cellEdit.bind(this), width: '2%' },
                { bSortable: false, mRender: this.cellDel.bind(this), width: '2%' },
                { data: "NUMERO", width: '2%' },
                { data: "FECHA_SALIDA", width: '10%' },
                { data: "FECHA_LLEGADA", width: '30%' },
                { data: "OD", width: '10%' },
                { data: "CARTA_NOTIFICACION", width: '10%' },
                { data: "NUM_THABILITANTE", width: '10%' },
                { data: "SUPERVISOR", width: '10%' },
                { data: "SUPERVISADO", width: '10%' },
                { data: "TIPO_INFORME", width: '10%' },
                { data: "ENVIAR_ALERTA_TEXT", width: '10%' },

                //{ mRender: this.cellActive, width: '2%' }
                /*,
                { data: "ACTIVO", visible: false }
                  { data: "COD_PERSONA", visible: false }
                */
            ]
        });
    }

    cellDel(data, type, row) {
        return '<i class="cellDel fa fa-lg fa-window-close" title="Eliminar" onclick="' + this.nameObject + '.delete(this);"></i>';
    }
    cellEdit(data, type, row) {
        return '<i class="cellEdit fa fa-lg fa-pencil-square-o" title="Editar" onclick="' + this.nameObject + '.editar(this);"></i>';
    }
    editar(obj) {
        var data = this.dt.row($(obj).closest('tr')).data();
        var codigoDato = data.CODIGO;
        
        var codigoComplementario = data.COD_THABILITANTE + "|" + data.COD_SECUENCIAL;
        //alert(codigoDato);
        window.location = this.urlController + '?codigoDato=' + codigoDato +'&codigoComplementario='+codigoComplementario;
    }


}