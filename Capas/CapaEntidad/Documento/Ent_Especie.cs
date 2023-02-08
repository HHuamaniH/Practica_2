using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Especie
    {
        [Description("COD_PASPEQ_PLAN_TRABAJO_ESPECIES")]
        public Int32 COD_PASPEQ_PLAN_TRABAJO_ESPECIES { get; set; }
        [Description("APROVECHABLES_SUPERVISAR")]
        public Int32 APROVECHABLES_SUPERVISAR { get; set; }
        [Description("SEMILLEROS_SUPERVISAR")]
        public Int32 SEMILLEROS_SUPERVISAR { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("COD_PASPEQ_DETALLE_MENSUAL")]
        public Int32 COD_PASPEQ_DETALLE_MENSUAL { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Category("OUTPUT"), Description("RESULTADO")]
        public Object RESULTADO { get; set; }
    }
}
