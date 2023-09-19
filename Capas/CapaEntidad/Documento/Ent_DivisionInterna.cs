using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DOC
{
    public class Ent_DIVISIONINTERNA
    {
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("TIPOAREA")]
        public Int32 TIPOAREA { get; set; }
        [Description("SUBTIPOAREA")]
        public Int32 SUBTIPOAREA { get; set; }
        [Description("SUBTIPOAREADESC")]
        public String SUBTIPOAREADESC { get; set; }
        [Description("AREA")]
        public Decimal AREA { get; set; }
        [Description("DESCRIPCIONAREA")]
        public String DESCRIPCIONAREA { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        public Ent_DIVISIONINTERNA()
        {
            COD_SECUENCIAL = -1;
            TIPOAREA = -1;
            SUBTIPOAREA = -1;
            AREA = -1;
        }
    }
}
