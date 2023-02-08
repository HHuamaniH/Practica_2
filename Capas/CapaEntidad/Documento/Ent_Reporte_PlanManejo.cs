using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Reporte_PlanManejo
    {
        [Description("TIPO_REPORTE")]
        public String TIPO_REPORTE { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        //RESUMEN
        [Description("LOCADOR")]
        public String LOCADOR { get; set; }
        [Description("NUM_PMANEJO")]
        public Int32 NUM_PMANEJO { get; set; }
        [Description("NUM_PMANEJO_INEX")]
        public Int32 NUM_PMANEJO_INEX { get; set; }
        [Description("NUM_ARBOL_SUPERV")]
        public Int32 NUM_ARBOL_SUPERV { get; set; }
        [Description("NUM_ARBOL_INEX")]
        public Int32 NUM_ARBOL_INEX { get; set; }
        [Description("PORC_ARBOL_INEX")]
        public Decimal PORC_ARBOL_INEX { get; set; }
        //DETALLE
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("DEPARTAMENTO")]
        public String DEPARTAMENTO { get; set; }
        [Description("ANIO_SUPERV")]
        public String ANIO_SUPERV { get; set; }
        [Description("NUM_INFORME")]
        public String NUM_INFORME { get; set; }
        [Description("TIPO_INFORME")]
        public String TIPO_INFORME { get; set; }
        [Description("POA")]
        public String POA { get; set; }
        [Description("RES_APRUEBA_POA")]
        public String RES_APRUEBA_POA { get; set; }
        [Description("VOL_APROBADO")]
        public Decimal VOL_APROBADO { get; set; }
        [Description("NUM_ARBOL_APROBADO")]
        public Decimal NUM_ARBOL_APROBADO { get; set; }
        [Description("RD_INICIO_PAU")]
        public String RD_INICIO_PAU { get; set; }
        [Description("RD_TERMINO_PAU")]
        public String RD_TERMINO_PAU { get; set; }
        [Description("ESTADO_PAU")]
        public String ESTADO_PAU { get; set; }

        public Ent_Reporte_PlanManejo()
        {
            NUM_PMANEJO = -1;
            NUM_PMANEJO_INEX = -1;
            NUM_ARBOL_INEX = -1;
            NUM_ARBOL_SUPERV = -1;
            PORC_ARBOL_INEX = -1;
            VOL_APROBADO = -1;
            NUM_ARBOL_APROBADO = -1;
        }
    }
}
