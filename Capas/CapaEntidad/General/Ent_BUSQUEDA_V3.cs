using System;
using System.ComponentModel;

namespace CapaEntidad.General
{
    public class Ent_BUSQUEDA_V3
    {
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("param01")]
        public String param01 { get; set; }
        [Description("param02")]
        public String param02 { get; set; }
        [Description("param03")]
        public int? param03 { get; set; }
        //paametros para paginaciones
        [Description("currentpage")]
        public Int32? currentpage { get; set; }
        [Description("pagesize")]
        public Int32? pagesize { get; set; }
        [Description("sort")]
        public String sort { get; set; }

        [Description("v_pagesize")]
        public Int32? v_pagesize { get; set; }
    }
}
