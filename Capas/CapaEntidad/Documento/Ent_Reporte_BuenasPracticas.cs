using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Reporte_BuenasPracticas
    {
        [Description("BusAnio")]
        public string BusAnio { get; set; }
        [Description("BusModalidad")]
        public string BusModalidad { get; set; }
        [Description("BusCriterio")]
        public string BusCriterio { get; set; }
        [Description("BusRegion")]
        public string BusRegion { get; set; }
        [Description("BOSQUES SECOS")]
        public Int32 BOSQUES_SECOS { get; set; }
        [Description("PREDIO_PRIVADO")]
        public Int32 PREDIO_PRIVADO { get; set; }
        [Description("CCNN")]
        public Int32 CCNN { get; set; }
        [Description("CONCESIONES_MADERABLES")]
        public Int32 CONCESIONES_MADERABLES { get; set; }
        [Description("CONCESIONES_NOMADERABLE")]
        public Int32 CONCESIONES_NOMADERABLES { get; set; }
        [Description("TOTAL")]
        public Int32 TOTAL { get; set; }
        [Description("TITULAR")]
        public string TITULAR { get; set; }
        [Description("THABILITANTE")]
        public string THABILITANTE { get; set; }
        [Description("ISUPERVISION")]
        public string ISUPERVISION { get; set; }
        [Description("ILEGAL")]
        public string ILEGAL { get; set; }
        [Description("TOTAL_AUT_PER")]
        public Int32 TOTAL_AUT_PER { get; set; }
        [Description("TOTAL_CONC")]
        public Int32 TOTAL_CONC { get; set; }
        [Category("LIST"), Description("ListGeneral")]
        public List<Ent_Reporte_BuenasPracticas> ListGeneral { get; set; }

        [Category("LIST"), Description("ListRanking")]
        public List<Ent_Reporte_BuenasPracticas> ListRanking { get; set; }

        #region "Constructor";
        public Ent_Reporte_BuenasPracticas()
        {
            TOTAL_AUT_PER = -1;
            TOTAL_CONC = -1;
            TOTAL = -1;
            BOSQUES_SECOS = -1;
            CCNN = -1;
            PREDIO_PRIVADO = -1;
            CONCESIONES_MADERABLES = -1;
            CONCESIONES_NOMADERABLES = -1;
        }
        #endregion
    }
}
