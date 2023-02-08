using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Paspeq_Detalle_V3
    {
        [Description("COD_PASPEQ_PLAN_TRABAJO")]
        public int COD_PASPEQ_PLAN_TRABAJO { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public Int32? NUM_POA { get; set; }
        [Description("COD_PMANEJO")]
        public String COD_PMANEJO { get; set; }
        [Description("TABLA_PLAN_MANEJO")]
        public String TABLA_PLAN_MANEJO { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("FASE_ADICION")]
        public String FASE_ADICION { get; set; }
        [Description("OUTPUTPARAM01")]
        public int OUTPUTPARAM01 { get; set; }
    }
}
