using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_PlanTrabajo
    {
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }

        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        //Datos Plan Trabajo
        [Description("COD_PASPEQ_PLAN_TRABAJO")]
        public Int32 COD_PASPEQ_PLAN_TRABAJO { get; set; }
        [Description("NUM_PASPEQ")]
        public Int32 NUM_PASPEQ { get; set; }
        [Description("PERIODO")]
        public String PERIODO { get; set; }
        [Category("FECHA"), Description("FECHA_CREACION")]
        public Object FECHA_CREACION { get; set; }
        [Description("APROBADO")]
        public String APROBADO { get; set; }
        [Description("MES_FOCALIZACION")]
        public String MES_FOCALIZACION { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("COD_OD")]
        public String COD_OD { get; set; }

        public Ent_PlanTrabajo()
        {
            RegEstado = -1;
            NUM_PASPEQ = -1;
            COD_PASPEQ_PLAN_TRABAJO = -1;
        }
    }
}
