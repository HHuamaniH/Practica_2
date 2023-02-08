using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_ReporteSeguimientoRegistro
    {
        public string lblTituloCabecera { get; set; }
        public string hdfTipoReporte { get; set; }
        public IEnumerable<VM_Chk> lstChkAnio { get; set; }
        public string lstChkAnioId { get; set; }
        public string lstChkMesId { get; set; }

        public VM_ReporteSeguimientoRegistro()
        {
            lstChkAnioId = "";
            lstChkMesId = "";
        }
    }
}
