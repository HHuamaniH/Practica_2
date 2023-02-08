using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Reporte_EstadoCuenta
    {   //Titulo Habilitante
        [Description("PERSONA_TITULAR")]
        public String PERSONA_TITULAR { get; set; }
        [Description("NUMERO")]
        public String NUMERO { get; set; }
        [Description("TIPO")]
        public String TIPO { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("PERSONA_RLEGAL")]
        public String PERSONA_RLEGAL { get; set; }
        [Description("DIRECCION")]
        public String DIRECCION { get; set; }
        [Description("AREA_OTORGADA")]
        public Decimal AREA_OTORGADA { get; set; }
        [Description("UBICACION")]
        public String UBICACION { get; set; }

        //Antecedentes Informes de Supervision
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }

        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }

        [Description("FECHA_EMISION")]
        public String FECHA_EMISION { get; set; }

        [Description("NUMERO_INFORME")]
        public String NUMERO_INFORME { get; set; }
        [Description("ZAFRA")]
        public String ZAFRA { get; set; }
        [Description("NUMERO POA")]
        public Int32 NUM_POA { get; set; }
        [Description("AREA")]
        public Decimal AREA { get; set; }
        [Description("VOLUMEN AUTORIZADO")]
        public Decimal VOLUMEN_AUTORIZADO { get; set; }
        [Description("VOLUMEN MOVILIZADO")]
        public Decimal VOLUMEN_MOVILIZADO { get; set; }
        [Description("VOLUMEN SUPERVISADO")]
        public Decimal VOLUMEN_SUPERVISADO { get; set; }

        //INICIO PAU
        [Description("CODIGO RESOLUCION INICIO")]
        public String COD_RINICIO { get; set; }
        [Description("EXPEDIENTE ADMINISTRATIVO")]
        public String EXPEDIENTE_ADMINISTRATIVO { get; set; }
        [Description("NUMERO RESOLUCION INICIO")]
        public String RINICIO { get; set; }
        [Description("MEDIDA CAUTELAR")]
        public String MEDIDA_CAUTELAR { get; set; }
        [Description("INFRACCION")]
        public String INFRACCION { get; set; }
        [Description("VOLUMEN INJUSTIFICADO")]
        public Decimal VOLUMEN_INJUSTIFICADO { get; set; }

        //FINALIZA PAU
        [Description("CODIGO RESOLUCION TERMINO")]
        public String COD_RTERMINO { get; set; }
        [Description("NUMERO RESOLUCION TERMINO")]
        public String RTERMINO { get; set; }
        [Description("SITUACION")]
        public String SITUACION { get; set; }
        [Description("MULTA MONTO")]
        public Decimal MULTA { get; set; }

        //Variables de Busqueda
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }

        [Category("LIST"), Description("ListAntecedentesSupervision")]
        public List<Ent_Reporte_EstadoCuenta> ListAntecedentesSupervision { get; set; }

        [Category("LIST"), Description("ListInicioPau")]
        public List<Ent_Reporte_EstadoCuenta> ListInicioPau { get; set; }

        [Category("LIST"), Description("ListFinalizacionPau")]
        public List<Ent_Reporte_EstadoCuenta> ListFinalizacionPau { get; set; }

        [Category("LIST"), Description("ListDocumentosEmitidos")]
        public List<Ent_Reporte_EstadoCuenta> ListDocumentosEmitidos { get; set; }

        public Ent_Reporte_EstadoCuenta()
        {
            NUM_POA = -1;
            AREA = -1;
            MULTA = -1;
            VOLUMEN_AUTORIZADO = -1;
            VOLUMEN_INJUSTIFICADO = -1;
            VOLUMEN_MOVILIZADO = -1;
            VOLUMEN_SUPERVISADO = -1;
            AREA_OTORGADA = -1;

        }
    }
}