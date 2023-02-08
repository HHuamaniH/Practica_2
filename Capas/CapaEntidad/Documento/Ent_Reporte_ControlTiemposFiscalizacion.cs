using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Reporte_ControlTiemposFiscalizacion
    {
        //Filtros
        [Description("TIPO_REPORTE")]
        public String TIPO_REPORTE { get; set; }
        [Description("COD_DLINEA")]
        public String COD_DLINEA { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("COLOR")]
        public String COLOR { get; set; }
        [Description("REPORTE")]
        public String REPORTE { get; set; }

        //Resultado reporte resumen
        [Description("COD_TPROCESO")]
        public String COD_TPROCESO { get; set; }
        [Description("TIPO_PROCESO")]
        public String TIPO_PROCESO { get; set; }
        [Description("VERDE")]
        public Int32 VERDE { get; set; }
        [Description("AMARILLO")]
        public Int32 AMARILLO { get; set; }
        [Description("ROJO")]
        public Int32 ROJO { get; set; }
        [Description("TOTAL")]
        public Int32 TOTAL { get; set; }

        //Resultado reporte detallado
        [Description("COD_REGISTRO")]
        public String COD_REGISTRO { get; set; }
        [Description("NUM_DOCUMENTO")]
        public String NUM_DOCUMENTO { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("FECHA_INICIO")]
        public String FECHA_INICIO { get; set; }
        [Description("FECHA_NOTIFICA")]
        public String FECHA_NOTIFICA { get; set; }
        [Description("DIFFDIA")]
        public Int32 DIFFDIA { get; set; }
        [Description("NOMBRE_RESPONSABLE")]
        public String NOMBRE_RESPONSABLE { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("NUM_RESOLUCION")]
        public String NUM_RESOLUCION { get; set; }

        [Description("ORDEN")]
        public Int32 ORDEN { get; set; }

        public Ent_Reporte_ControlTiemposFiscalizacion()
        {
            VERDE = -1;
            AMARILLO = -1;
            ROJO = -1;
            DIFFDIA = -1;
            TOTAL = -1;
            ORDEN = -1;
        }
    }
}
