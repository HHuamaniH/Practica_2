using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DOC
{
    public class Ent_Constancia
    {
        /* [Description("NV_CONSTANCIA")]
         public string NV_CONSTANCIA { get; set; }
         [Description("COD_INFORME")]
         public string COD_INFORME { get; set; }
         [Description("COD_THABILITANTE")]
         public string COD_THABILITANTE { get; set; }
         [Description("COD_TITULAR")]
         public string COD_TITULAR { get; set; }
         [Description("NUMERO")]
         public string NUMERO { get; set; }
         [Description("NUMERO_INFORME")]
         public string NUMERO_INFORME { get; set; }
         [Description("NUMERO_TH")]
         public string NUMERO_TH { get; set; }
         [Description("APELLIDOS_NOMBRES")]
         public string APELLIDOS_NOMBRES { get; set; }
         [Description("FECHA_SUPERVISION_INICIO")]
         public string FECHA_SUPERVISION_INICIO { get; set; }
         [Description("FECHA_SUPERVISION_FIN")]
         public string FECHA_SUPERVISION_FIN { get; set; }
         [Description("FECHA_INFORME")]
         public string FECHA_INFORME { get; set; }
         [Description("TIPO_PLAN")]
         public string NUM_POA { get; set; }*/

        [Description("CODIGO")]
        public string CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public string DESCRIPCION { get; set; }
        [Description("BusFormulario")]
        public string BusFormulario { get; set; }
        [Description("BusCriterio")]
        public string BusCriterio { get; set; }
        [Description("BusValor")]
        public string BusValor { get; set; }
    }
}
