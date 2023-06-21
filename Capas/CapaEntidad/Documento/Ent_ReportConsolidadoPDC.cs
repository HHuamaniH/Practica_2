using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DOC
{
    public class Ent_ReportConsolidadoPDC
    {
        [Description("COD_MODALIDAD")]
        public String COD_MODALIDAD { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("ATALAYA")]
        public Decimal ATALAYA { get; set; }
        [Description("CHICLAYO")]
        public Decimal CHICLAYO { get; set; }
        [Description("IQUITOS")]
        public Decimal IQUITOS { get; set; }
        [Description("LA_MERCED")]
        public Decimal LA_MERCED { get; set; }
        [Description("PUCALLPA")]
        public Decimal PUCALLPA { get; set; }
        [Description("PUERTO_MALDONADO")]
        public Decimal PUERTO_MALDONADO { get; set; }
        [Description("TARAPOTO")]
        public Decimal TARAPOTO { get; set; }
        [Description("SEDE_CENTRAL")]
        public Decimal SEDE_CENTRAL { get; set; }
        [Description("TOTAL")]
        public Decimal TOTAL { get; set; }

        public Ent_ReportConsolidadoPDC()
        {
            ATALAYA = -1;
            CHICLAYO = -1;
            IQUITOS = -1;
            LA_MERCED = -1;
            PUCALLPA = -1;
            PUERTO_MALDONADO = -1;
            TARAPOTO = -1;
            SEDE_CENTRAL = -1;
            TOTAL = -1;
        }

    }
}
