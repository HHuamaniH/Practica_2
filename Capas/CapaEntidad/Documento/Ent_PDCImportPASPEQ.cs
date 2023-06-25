using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DOC
{
    public class Ent_PDCImportPASPEQ
    {
        [Description("ID_REGISTRO")]
        public Int32 ID_REGISTRO { get; set; }

        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }

        [Description("TITULO")]
        public String TITULO { get; set; }

        [Description("ENFOQUE")]
        public String ENFOQUE { get; set; }

        [Description("MES")]
        public Int32 MES { get; set; }

        [Description("MES_FOCALIZACION")]
        public String MES_FOCALIZACION { get; set; }

        [Description("ANIO")]
        public Int32 ANIO { get; set; }

        [Description("ESTADO")]
        public Int32 ESTADO { get; set; }

        [Description("v_ROW_INDEX")]
        public Int32 v_ROW_INDEX { get; set; }
    }
}
