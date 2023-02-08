using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Plan_T_Detalle_Especie
    {
        [Description("COD_PLAN_TRABAJO_SUPERVISION_DETALLE")]
        public long COD_PLAN_TRABAJO_SUPERVISION_DETALLE { get; set; }
        [Description("COD_ESPECIES")]
        public string COD_ESPECIES { get; set; }
        [Description("N_APROVECHABLES")]
        public Int32 N_APROVECHABLES { get; set; }
        [Description("N_SEMILLEROS")]
        public Int32 N_SEMILLEROS { get; set; }
        [Description("N_TOTAL_INDIVIDUOS")]
        public Int32 N_TOTAL_INDIVIDUOS { get; set; }
        [Description("V_AUTORIZADO")]
        public decimal V_AUTORIZADO { get; set; }
        [Description("V_MOVILIZADO")]
        public decimal V_MOVILIZADO { get; set; }
        [Description("PUNTAJE_FINAL")]
        public Int32 PUNTAJE_FINAL { get; set; }
        [Description("PUNTAJE_FINAL_PORCENTAJE")]
        public decimal PUNTAJE_FINAL_PORCENTAJE { get; set; }
        [Description("COD_UCUENTA_CREACION")]
        public string COD_UCUENTA_CREACION { get; set; }
        [Description("CAL_ABUNDANCIA")]
        public decimal CAL_ABUNDANCIA { get; set; }
        [Description("PUNTAJE_ABUNDANCIA")]
        public int PUNTAJE_ABUNDANCIA { get; set; }
        [Description("CAL_V_APROBADO")]
        public decimal CAL_V_APROBADO { get; set; }
        [Description("PUNTAJE_V_APROBADO")]
        public int PUNTAJE_V_APROBADO { get; set; }
        [Description("CAL_V_MOVILIZADO")]
        public decimal CAL_V_MOVILIZADO { get; set; }
        [Description("PUNTAJE_V_MOVILIZADO")]
        public int PUNTAJE_V_MOVILIZADO { get; set; }
        [Description("CAL_CAT_ESPECIE_AMENAZADA")]
        public string CAL_CAT_ESPECIE_AMENAZADA { get; set; }
        [Description("PUNTAJE_CAT_ESPECIE_AMENAZADA")]
        public Int32 PUNTAJE_CAT_ESPECIE_AMENAZADA { get; set; }
        [Description("CAL_CAT_ESPECIE_MADERABLE")]
        public string CAL_CAT_ESPECIE_MADERABLE { get; set; }
        [Description("PUNTAJE_CAT_ESPECIE_MADERABLE")]
        public Int32 PUNTAJE_CAT_ESPECIE_MADERABLE { get; set; }
        [Description("AGRADO_CITE")]
        public string AGRADO_CITE { get; set; }
        [Description("TIENE_AGRADO_CITE")]
        public bool TIENE_AGRADO_CITE { get; set; }
        [Description("TIPOPMANEJO")]
        public string TIPOPMANEJO { get; set; }

        [Description("PCA")] 
        public string PCA { get; set; }
        public Ent_Plan_T_Detalle_Especie()
        {
           // this.CAL_CAT_ESPECIE_AMENAZADA = -1;
            this.PUNTAJE_CAT_ESPECIE_AMENAZADA = -1;
           // this.CAL_CAT_ESPECIE_MADERABLE = -1;
            this.PUNTAJE_CAT_ESPECIE_MADERABLE = -1;
        }
    }
}
