using System;
using System.ComponentModel;

namespace CapaEntidad.Documento
{
    public class Ent_Focalizacion_PlanTrabajo
    {
        [Description("COD_PLAN_TRABAJO_SUPERVISION")]
        public string COD_PLAN_TRABAJO_SUPERVISION { get; set; }
        [Description("COD_OD")]
        public string COD_OD { get; set; }
        [Description("PERIODO")]
        public string PERIODO { get; set; }
        [Description("MES_FOCALIZACION")]
        public Int16 MES_FOCALIZACION { get; set; }
        [Description("COD_JEFE")]
        public string COD_JEFE { get; set; }
        [Description("COD_UCUENTA_CREACION")]
        public string COD_UCUENTA_CREACION { get; set; }
        [Description("COD_ESTADO_DOC")]
        public string COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public string OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public bool OBSERV_SUBSANAR { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public string OUTPUTPARAM01 { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM02")]
        public string OUTPUTPARAM02 { get; set; }
        public Ent_Focalizacion_PlanTrabajo()
        {
            this.COD_JEFE = null;
            this.OBSERV_SUBSANAR = false;
            //this.PERIODO = -1;
            this.MES_FOCALIZACION = -1;
            this.OUTPUTPARAM01 = "";
            this.OUTPUTPARAM02 = "";
        }
    }
    public class Ent_Focalizacion_PlanTrabajo_Detalle
    {
        [Description("COD_PLAN_TRABAJO_SUPERVISION_DETALLE")]
        public long COD_PLAN_TRABAJO_SUPERVISION_DETALLE { get; set; }
        [Description("COD_PLAN_TRABAJO_SUPERVISION")]
        public string COD_PLAN_TRABAJO_SUPERVISION { get; set; }
        [Description("COD_PLAN")]
        public string COD_PLAN { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("TIPO_SUPERVISION")]
        public Int32 TIPO_SUPERVISION { get; set; }
        [Description("OPORTUNIDAD_SUPERVISION")]
        public Int32? OPORTUNIDAD_SUPERVISION { get; set; }
        [Description("COD_UCUENTA_CREACION")]
        public string COD_UCUENTA_CREACION { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public string OUTPUTPARAM01 { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM02")]
        public string OUTPUTPARAM02 { get; set; }
        public Ent_Focalizacion_PlanTrabajo_Detalle()
        {
            this.OUTPUTPARAM01 = "";
            this.OUTPUTPARAM02 = "";
            this.COD_PLAN_TRABAJO_SUPERVISION_DETALLE = -1;
            this.TIPO_SUPERVISION = -1;
            this.COD_SECUENCIAL = -1;
            this.OPORTUNIDAD_SUPERVISION = -1;

        }
    }
}
