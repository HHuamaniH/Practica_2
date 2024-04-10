using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DOC
{
    public class Ent_TITULAR_RLEGAL
    {
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("COD_TITULAR")]
        public String COD_TITULAR { get; set; }
        [Description("COD_RLEGAL")]
        public String COD_RLEGAL { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("DOCUMENTO")]
        public String DOCUMENTO { get; set; }
        [Description("APELLIDOS_NOMBRES")]
        public String APELLIDOS_NOMBRES { get; set; }
        [Description("FECHA_REGISTRO")]
        public String FECHA_REGISTRO { get; set; }

        public Ent_TITULAR_RLEGAL()
        {            
        }
    }
}
