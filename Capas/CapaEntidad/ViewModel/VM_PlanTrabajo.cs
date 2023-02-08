using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_PlanTrabajo
    {
        public int cod_paspeq_plan_trabajo { get; set; }
        public string periodo { get; set; }
        public int num_paspeq { get; set; }
        public string fecha_creacion { get; set; }
        public string aprobado { get; set; }
        public string mes_focalizacion { get; set; }
        public string mes { get; set; }
        public string cod_od { get; set; }
        public string oficina { get; set; }
        public List<VM_Cbo> cboMesFocalizacion { get; set; }
    }
}
