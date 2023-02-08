using System;
using System.ComponentModel;

namespace CapaEntidad.ViewModel
{
    public class VM_MiBosqueObligacion
    {
        [Description("V_COD_MIBOSQUE_OBLIGACION")]
        public Int64 V_COD_MIBOSQUE_OBLIGACION { get; set; }

        [Description("V_ESTADO")]
        public String V_ESTADO { get; set; }

        [Description("V_OBSERVACION")]
        public String V_OBSERVACION { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM")]
        public Object OUTPUTPARAM { get; set; }

        public VM_MiBosqueObligacion()
        {
            V_COD_MIBOSQUE_OBLIGACION = -1;
        }
    }
}
