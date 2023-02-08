using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
   public class VM_ReporteInformacion
    {
        public IEnumerable<VM_Chk> lstChkAnio { get; set; }
        public string lstChkAnioId { get; set; }
        public IEnumerable<VM_Chk> lstChkOd { get; set; }
        public string lstChkOdId { get; set; }
        public IEnumerable<VM_Chk> lstChkModalidad { get; set; }
        public string lstChkModalidadId { get; set; }
        public IEnumerable<VM_Chk> lstChkRegion { get; set; }
        public string lstChkRegionId { get; set; }
        public IEnumerable<VM_Chk> lstChkSubDireccion { get; set; }
        public string lstChkSubDireccionId { get; set; }
    }
}
