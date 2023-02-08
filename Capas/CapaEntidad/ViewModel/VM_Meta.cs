using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_Meta
    {
        public string hdfCodMeta { get; set; }
        public string lblTitulo { get; set; }
        public IEnumerable<VM_Cbo> ddlTipoIndicador { get; set; }
        public string ddlTipoIndicadorId { get; set; }
        public IEnumerable<VM_Cbo> ddlIndicador { get; set; }
        public string ddlIndicadorId { get; set; }
        public IEnumerable<VM_Cbo> ddlAnio { get; set; }
        public string ddlAnioId { get; set; }
        public IEnumerable<VM_Cbo> ddlPeriodo { get; set; }
        public string ddlPeriodoId { get; set; }
        public string txtValorMeta { get; set; }
        public int hdfEstado { get; set; }
        public int RegEstado { get; set; }
    }
}
