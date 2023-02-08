using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DOC
{
    public class Ent_THABILITANTE_POI
    {
        [Description("NV_CODIGO")]
        public String NV_CODIGO { get; set; }
        [Description("NV_TIPO")]
        public String NV_TIPO { get; set; }
        [Description("NU_ANIO")]
        public Int32 NU_ANIO { get; set; }
        [Description("NU_TRIMESTRE")]
        public Int32 NU_TRIMESTRE { get; set; }
        [Description("NU_VALOR_AUDITORIA")]
        public Int32 NU_VALOR_AUDITORIA { get; set; }
        [Description("NU_VALOR_SUPERVISION")]
        public Int32 NU_VALOR_SUPERVISION { get; set; }
        [Description("NU_VALOR_MEDIDA")]
        public Int32 NU_VALOR_MEDIDA { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("ESTADO")]
        public Int32 ESTADO { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        public Ent_THABILITANTE_POI()
        {
            NU_ANIO = -1;
            NU_TRIMESTRE = -1;
            NU_VALOR_AUDITORIA = -1;
            NU_VALOR_SUPERVISION = -1;
            NU_VALOR_MEDIDA = -1;
            ESTADO = -1;
            RegEstado = -1;
        }
    }
}
