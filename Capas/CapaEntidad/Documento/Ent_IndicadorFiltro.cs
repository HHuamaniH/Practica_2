using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DOC
{
    public class Ent_IndicadorFiltro
    {
        [Description("COD_INDICADOR")]
        public string COD_INDICADOR { get; set; }
        [Description("CODIGO")]
        public string CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public string DESCRIPCION { get; set; }
        [Description("META")]
        public string META { get; set; }
        [Description("NV_CODIGO")]
        public string NV_CODIGO { get; set; }
        [Description("ANIO")]
        public Int32 ANIO { get; set; }
        [Description("NUMERO")]
        public Int32 NUMERO { get; set; }
        [Description("TIPO")]
        public string TIPO { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }

        //TGS: 12/09/2021
        [Description("NV_INDICADOR")]
        public string NV_INDICADOR { get; set; }
        [Description("NU_META")]
        public Decimal NU_META { get; set; }
        [Description("NU_ANIO")]
        public Int32 NU_ANIO { get; set; }
        [Description("NV_PERIODO")]
        public string NV_PERIODO { get; set; }

        [Category("LIST"), Description("ListIndicador")]
        public List<Ent_IndicadorFiltro> ListIndicador { get; set; }
        [Category("LIST"), Description("ListAnio")]
        public List<Ent_IndicadorFiltro> ListAnio { get; set; }

        public Ent_IndicadorFiltro()
        {
            ANIO = -1;
            NUMERO = -1;
            NU_META = -1;
            NU_ANIO = -1;
        }
    }
}
