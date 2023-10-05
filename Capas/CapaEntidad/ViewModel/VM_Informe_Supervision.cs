using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_Informe_Supervision
    {
        public VM_Informe_Supervision()
        {
            this.DOCUMENTOS = new List<VM_Informe_Supervision_Documentos>();
        }

        public string COD_INFORME { get; set; }
        public string TITULAR_SUPERVISADO { get; set; }
        public string TIPO_INFORME { get; set; }
        public string COD_MTIPO { get; set; }
        public string MODALIDAD_TIPO { get; set; }
        public string DOCUMENTO_TITULAR { get; set; }
        public string REPRESENTANTE_LEGAL { get; set; }
        public string RUC_TITULAR { get; set; }
        public string NUM_INFORME { get; set; }
        public DateTime? INF_FECHA { get; set; }
        public string ASUNTO { get; set; }
        public string COD_THABILITANTE { get; set; }
        public string NUM_THABILITANTE { get; set; }
        public string THABILITANTE_SECTOR { get; set; }
        public string UBIGEO_THABILITANTE { get; set; }
        public List<VM_Informe_Supervision_Documentos> DOCUMENTOS { get; set; }
    }

    public class VM_Informe_Supervision_Documentos
    {
        public string COD_INFORME { get; set; }
        public string DETINV_CODDOC { get; set; }
        public string DETINV_DESCRIPCION { get; set; }
        public string ORIGEN { get; set; }
    }
}
