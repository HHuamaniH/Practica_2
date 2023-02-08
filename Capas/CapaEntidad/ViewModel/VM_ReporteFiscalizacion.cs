using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_ReporteFiscalizacion
    {
        public string lblTituloCabecera { get; set; }
        public string hdfTipoReporte { get; set; }
        public string hdfTipoArchivados { get; set; }
        public IEnumerable<VM_Chk> lstChkModalidad { get; set; }
        public IEnumerable<VM_Chk> lstChkRegion { get; set; }
        public string lstChkModalidadId { get; set; }
        public string lstChkRegionId { get; set; }
        public string txtanio { get; set; }

        public VM_ReporteFiscalizacion()
        {
            lstChkModalidadId = "";
            lstChkRegionId = "";
        }
    }
}
