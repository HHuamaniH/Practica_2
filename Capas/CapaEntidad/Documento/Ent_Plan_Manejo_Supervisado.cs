using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Plan_Manejo_Supervisado
    {
        [Description("COD_OD")]
        public String COD_OD { get; set; }
        [Description("PERIODO")]
        public String PERIODO { get; set; }
        public String NOMBRE_POA { get; set; }
        public String NUM_THABILITANTE { get; set; }
        public String MODALIDAD { get; set; }

    }
}
