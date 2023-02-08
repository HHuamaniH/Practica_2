using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Reporte_ProduccionItinerarioSupervision
    {
        /*FILTROS DE BÚSQUEDA*/
        [Description("COD_TIPO")]
        public String COD_TIPO { get; set; }
        [Description("COD_DLINEA")]
        public String COD_DLINEA { get; set; }
        [Description("COD_OD")]
        public String COD_OD { get; set; }
        [Description("ANIO")]
        public Int32 ANIO { get; set; }
        [Description("MES")]
        public Int32 MES { get; set; }
        [Description("INFO_GEO")]
        public Int32 INFO_GEO { get; set; }

        //DATOS REPORTE
        [Description("OD")]
        public String OD { get; set; }
        [Description("TOTAL")]
        public Int32 TOTAL { get; set; }
        // Reporte de la salida a campo del personal supervisor: PERMISOS
        //Cabecera
        [Description("PFAUNA")]
        public Int32 PFAUNA { get; set; }
        [Description("CFAUNA")]
        public Int32 CFAUNA { get; set; }
        [Description("PNM")]
        public Int32 PNM { get; set; }
        [Description("NM")]
        public Int32 NM { get; set; }
        [Description("CC_CC_NN")]
        public Int32 CC_CC_NN { get; set; }

        [Description("M0000005")]
        public Int32 M0000005 { get; set; }
        [Description("M0000006")]
        public Int32 M0000006 { get; set; }
        [Description("M0000007")]
        public Int32 M0000007 { get; set; }
        [Description("M0000010")]
        public Int32 M0000010 { get; set; }
        [Description("M0000011")]
        public Int32 M0000011 { get; set; }
        [Description("M0000012")]
        public Int32 M0000012 { get; set; }
        [Description("M0000014")]
        public Int32 M0000014 { get; set; }
        [Description("M0000017")]
        public Int32 M0000017 { get; set; }
        //Detalle
        [Description("NUM_CNOTIFICACION")]
        public String NUM_CNOTIFICACION { get; set; }
        [Description("SUPERVISOR")]
        public String SUPERVISOR { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("ABREVIADO_SUBPER")]
        public String ABREVIADO_SUBPER { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("POAS")]
        public String POAS { get; set; }
        [Description("DEPARTAMENTO")]
        public String DEPARTAMENTO { get; set; }
        [Description("PROVINCIA")]
        public String PROVINCIA { get; set; }
        [Description("DISTRITO")]
        public String DISTRITO { get; set; }
        [Description("FECHA_SALIDA")]
        public String FECHA_SALIDA { get; set; }
        [Description("FECHA_LLEGADA")]
        public String FECHA_LLEGADA { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("SUPERVISADO_TEXT")]
        public String SUPERVISADO_TEXT { get; set; }
        [Description("TIPO_INFORME")]
        public String TIPO_INFORME { get; set; }
        [Description("ALERTA")]
        public String ALERTA { get; set; }
        [Description("NUM_INFORME")]
        public String NUM_INFORME { get; set; }
        [Description("NOMBRE_ARCH")]
        public String NOMBRE_ARCH { get; set; }
        [Description("RUTA_ARCH")]
        public String RUTA_ARCH { get; set; }
        [Description("EXTENSION_ARCH")]
        public String EXTENSION_ARCH { get; set; }

        [Category("LIST"), Description("ListResumenReporte")]
        public List<Ent_Reporte_ProduccionItinerarioSupervision> ListResumenReporte { get; set; }
        [Category("LIST"), Description("ListDetalleReporte")]
        public List<Ent_Reporte_ProduccionItinerarioSupervision> ListDetalleReporte { get; set; }

        public Ent_Reporte_ProduccionItinerarioSupervision()
        {
            ANIO = -1; MES = -1; TOTAL = -1; PFAUNA = -1;
            CFAUNA = -1; PNM = -1; NM = -1; CC_CC_NN = -1;

            M0000005 = -1; M0000006 = -1; M0000007 = -1; M0000010 = -1;
            M0000011 = -1; M0000012 = -1; M0000014 = -1; M0000017 = -1;
        }
    }
}
