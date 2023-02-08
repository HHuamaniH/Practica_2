using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DOC
{
    public class Ent_Meta
    {
        [Description("NV_CODIGO")]
        public String NV_CODIGO { get; set; }
        [Description("NU_TIPO")]
        public Int32 NU_TIPO { get; set; }
        [Description("NV_INDICADOR")]
        public String NV_INDICADOR { get; set; }
        [Description("NU_ANIO")]
        public Int32 NU_ANIO { get; set; }
        [Description("NV_PERIODO")]
        public String NV_PERIODO { get; set; }
        [Description("NU_NUMERO")]
        public Int32 NU_NUMERO { get; set; }
        [Description("NU_META")]
        public Decimal NU_META { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        public Ent_Meta()
        {
            NU_TIPO = -1;
            NU_ANIO = -1;
            NU_META = -1;
            NU_NUMERO = -1;
            RegEstado = -1;
        }
    }
}
