using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Paspeq
    {
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }

        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        //Datos Paspeq
        [Description("NUM_PASPEQ")]
        public Int32 NUM_PASPEQ { get; set; }
        [Description("PERIODO")]
        public String PERIODO { get; set; }
        [Category("FECHA"), Description("FECHA_CREACION")]
        public Object FECHA_CREACION { get; set; }
        [Description("SELECCION")]
        public String SELECCION { get; set; }
        [Description("FASE_ESTADO")]
        public String FASE_ESTADO { get; set; }

        public Ent_Paspeq()
        {
            RegEstado = -1;
            NUM_PASPEQ = -1;
        }
    }
}
