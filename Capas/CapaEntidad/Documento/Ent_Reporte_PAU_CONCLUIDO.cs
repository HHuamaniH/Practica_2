using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Reporte_PAU_CONCLUIDO
    {
        [Description("BusDireccion")]
        public String BusDireccion { get; set; }
        [Description("BusDireccion2")]
        public String BusDireccion2 { get; set; }
        [Description("BusModalidad")]
        public String BusModalidad { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusRegion")]
        public String BusRegion { get; set; }
        [Description("BusAnio")]
        public String BusAnio { get; set; }
        [Description("BusFechaFin")]
        public String BusFechaFin { get; set; }
        [Description("BusInstancia")]
        public String BusInstancia { get; set; }
        [Description("COD_ITIPO")]
        public string COD_ITIPO { get; set; }
        [Description("ANIO")]
        public String ANIO { get; set; }
        [Description("SUPERVISION")]
        public Int32 SUPERVISION { get; set; }
        [Description("ARCHIVO_PRELIMINAR")]
        public Int32 ARCHIVO_PRELIMINAR { get; set; }
        [Description("ARCHIVO_PRELIMINAR_SIN")]
        public Int32 ARCHIVO_PRELIMINAR_SIN { get; set; }
        [Description("INICIO PAU")]
        public Int32 INI_PAU { get; set; }
        [Description("SUPER_TERMINADO_PAU")]
        public Int32 SUPER_TERMINADO_PAU { get; set; }
        [Description("CANTIDAD")]
        public Int32 CANTIDAD { get; set; }
        [Description("AVANCE")]
        public Decimal AVANCE { get; set; }
        [Description("TERMINO PAU")]
        public Int32 TERMINO_PAU { get; set; }
        [Description("CASOS")]
        public Int32 CASOS { get; set; }
        [Description("AVANCE1")]
        public Decimal AVANCE1 { get; set; }
        [Description("AVANCE_CASOS")]
        public Decimal AVANCE_CASOS { get; set; }
        [Description("SANCIONADO_PAU")]
        public Int32 SANCIONADO_PAU { get; set; }
        [Description("MED_CORREC_PAU")]
        public Int32 MED_CORREC_PAU { get; set; }
        [Description("AMONEST_PAU")]
        public Int32 AMONEST_PAU { get; set; }
        [Description("CADUCADO_PAU")]
        public Int32 CADUCADO_PAU { get; set; }
        [Description("CADUCADO_PAU_TH")]
        public Int32 CADUCADO_PAU_TH { get; set; }
        [Description("CADUCADO_PAU_TH_PRV")]
        public Int32 CADUCADO_PAU_TH_PRV { get; set; }
        [Description("ARCHIVO_PAU")]
        public Int32 ARCHIVO_PAU { get; set; }
        [Description("MEDCAU_PAU")]
        public Int32 MEDCAU_PAU { get; set; }

        [Description("SANCIONADO_PAU_1RA")]
        public Int32 SANCIONADO_PAU_1RA { get; set; }
        [Description("SANCIONADO_PAU_2DA")]
        public Int32 SANCIONADO_PAU_2DA { get; set; }
        [Description("UIT_TER_PAU")]
        public Int32 UIT_TER_PAU { get; set; }

        public decimal MONTO_MULTA { get; set; }
        public decimal MONTO_MULTA_FINAL { get; set; }
        public decimal MONTO_MULTA_FIRME { get; set; }

        public Ent_Reporte_PAU_CONCLUIDO()
        {
            SUPERVISION = -1;
            ARCHIVO_PRELIMINAR = -1;
            ARCHIVO_PRELIMINAR_SIN = -1;
            INI_PAU = -1;
            SUPER_TERMINADO_PAU = -1;
            CANTIDAD = -1;
            AVANCE = -1;
            TERMINO_PAU = -1;
            CASOS = -1;
            AVANCE1 = -1;
            AVANCE_CASOS = -1;
            SANCIONADO_PAU = -1;
            MED_CORREC_PAU = -1;
            AMONEST_PAU = -1;
            CADUCADO_PAU = -1;
            CADUCADO_PAU_TH = -1;
            CADUCADO_PAU_TH_PRV = -1;
            ARCHIVO_PAU = -1;
            MEDCAU_PAU = -1;
            SANCIONADO_PAU_1RA = -1;
            SANCIONADO_PAU_2DA = -1;
            UIT_TER_PAU = -1;
            MONTO_MULTA = -1;
            MONTO_MULTA_FINAL = -1;
            MONTO_MULTA_FIRME = -1;
        }

    }
}
