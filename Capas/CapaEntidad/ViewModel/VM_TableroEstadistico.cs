using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_TableroEstadistico
    {
        public string RESOLUCIONES { get; set; }
        public string ALLANAMIENTO { get; set; }
        public string PORC_ALLANAMIENTO { get; set; }
        public string SUBSANACION { get; set; }
        public string PORC_SUBSANACION { get; set; }
        public string DECOMISO { get; set; }
        public string PORC_DECOMISO { get; set; }
        public string PLAN_CIERRE { get; set; }
        public string PORC_PLAN_CIERRE { get; set; }
        public string DISP_FAUNA { get; set; }
        public string PORC_DISP_FAUNA { get; set; }
        public string MEDIDA_CORRECTIVA { get; set; }
        public string PORC_MEDIDA_CORRECTIVA { get; set; }
        public string ARCHIVO { get; set; }
        public string PORC_ARCHIVO { get; set; }
        public string MEDIDA_CAUT { get; set; }
        public string PORC_MEDIDA_CAUT { get; set; }
        public string PORC_MED_CAUT_GTF { get; set; }
        public string MED_CAUT_GTF { get; set; }
        public string PORC_LIST_TROZA { get; set; }
        public string LIST_TROZA { get; set; }
        public string PM { get; set; }
        public string PORC_POA { get; set; }
        public string POA { get; set; }
        public string PORC_PM { get; set; }
        public List<Ent_RESODIREC_REPORTEMEDIDAD> detalle01 { get; set; }
    }
}
