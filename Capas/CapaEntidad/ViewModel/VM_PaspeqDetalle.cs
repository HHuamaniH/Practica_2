using System;
using System.ComponentModel;

namespace CapaEntidad.ViewModel
{
    public class VM_PaspeqDetalle
    {
        [Description("NUM_PASPEQ")]
        public int num_paspeq { get; set; }
        [Description("PERIODO")]
        public string periodo { get; set; }
        public string thabilitante { get; set; }
        public string ubicacion { get; set; }
        public string oficina { get; set; }
        public string plan_manejo { get; set; }
        public string resolucion_aprobacion { get; set; }


        [Category("OUTPUT"), Description("RESULTADO")]
        public Object resultado { get; set; }

        [Description("COD_THABILITANTE")]
        public string cod_thabilitante { get; set; }
        [Description("NUM_POA")]
        public int num_poa { get; set; }
        [Description("COD_PMANEJO")]
        public string cod_pmanejo { get; set; }
        [Description("TABLA_PLAN_MANEJO")]
        public string tabla_plan_manejo { get; set; }
        [Description("COD_PASPEQ_PLAN_T")]
        public int cod_paspeq_plan_t { get; set; }
        [Description("TIPO_SUPERVISION")]
        public int tipo_supervision { get; set; }
        [Description("OPORTUNIDAD_SUPERVISION")]
        public int oportunidad_supervision { get; set; }

        public VM_PaspeqDetalle()
        {
            cod_paspeq_plan_t = -1;
            tipo_supervision = -1;
            oportunidad_supervision = -1;
        }
    }
}
