using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_THComportamiento
    {
        public Ent_TH_Comportamiento THComportamiento { get; set; }
        public List<Ent_TH_Calificacion> ListTHCalificacion { get; set; }
        public List<Ent_THabilitanteC> ListTHabilitante { get; set; }
        public List<Ent_TH_CalificacionAnual> ListTHCalificacionAnual { get; set; }

    }
}
