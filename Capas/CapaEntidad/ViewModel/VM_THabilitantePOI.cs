using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_THabilitantePOI
    {
        public string hdfCodTHPOI { get; set; }
        public string lblTitulo { get; set; }
        public IEnumerable<VM_Cbo> ddlAnio { get; set; }
        public string ddlAnioId { get; set; }
        public IEnumerable<VM_Cbo> ddlTrimestre { get; set; }
        public string ddlTrimestreId { get; set; }
        public string txtValorAuditoria { get; set; }
        public string txtValorSupervision { get; set; }
        public string txtValorMedida { get; set; }
        public int hdfEstado { get; set; }
        public int RegEstado { get; set; }
    }
}
