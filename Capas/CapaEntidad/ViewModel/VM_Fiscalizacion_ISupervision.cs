using CapaEntidad.DOC;
using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_Fiscalizacion_ISupervision
    {
        public string COD_INFORME { get; set; }
        public string FECHA_SUPERVISION_INICIO { get; set; }
        public string FECHA_SUPERVISION_FIN { get; set; }

        public List<Ent_INFORME_VOL_ANALIZADO> VOL_ANALIZADO { get; set; }
    }
}
