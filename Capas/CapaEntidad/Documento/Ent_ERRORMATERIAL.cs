using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DOC
{
    public class Ent_ERRORMATERIAL
    {
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("COD_PMANEJO")]
        public String COD_PMANEJO { get; set; }
        [Description("NV_TIPO")]
        public String NV_TIPO { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("DA_FECRESOLUCION")]
        public String DA_FECRESOLUCION { get; set; }
        [Description("NV_RESOLUCION")]
        public String NV_RESOLUCION { get; set; }
        [Description("NV_NOMCAMPO")]
        public String NV_NOMCAMPO { get; set; }
        [Description("NV_VALANTERIOR")]
        public String NV_VALANTERIOR { get; set; }
        [Description("NV_VALACTUAL")]
        public String NV_VALACTUAL { get; set; }
        [Description("NV_OBSERVACION")]
        public String NV_OBSERVACION { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }

        public Ent_ERRORMATERIAL()
        {
            COD_SECUENCIAL = -1;
            NUM_POA = -1;
        }
    }
}
