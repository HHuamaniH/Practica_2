using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_REPORTEGERENCIAL
    {
        #region "Entidades y Propiedades"

        [Description("COD_MTIPO")]
        public String COD_MTIPO { get; set; }
        [Description("ANIO")]
        public String ANIO { get; set; }
        [Description("APELLIDOS_NOMBRES")]
        public String APELLIDOS_NOMBRES { get; set; }
        [Description("DEPARTAMENTO")]
        public String DEPARTAMENTO { get; set; }
        [Description("PROVINCIA")]
        public String PROVINCIA { get; set; }
        [Description("DISTRITO")]
        public String DISTRITO { get; set; }
        [Description("NUMERO_ISUPERVISION")]
        public String NUMERO_ISUPERVISION { get; set; }
        [Description("AREA_OTORGADA")]
        public decimal AREA_OTORGADA { get; set; }
        [Description("NUMERO_TH_HABILITANTE")]
        public String NUMERO_TH_HABILITANTE { get; set; }
        [Description("NUMERO_LEGAL")]
        public String NUMERO_LEGAL { get; set; }
        [Description("NUMERO_EXPEDIENTE")]
        public String NUMERO_EXPEDIENTE { get; set; }
        [Description("TIPO")]
        public int TIPO { get; set; }
        [Description("ESPECIE")]
        public String ESPECIE { get; set; }
        [Description("VOLUMEN")]
        public decimal VOLUMEN { get; set; }
        [Description("NUMERO_RESOLUCION")]
        public String NUMERO_RESOLUCION { get; set; }

        #endregion

        #region "Constructor"
        public Ent_REPORTEGERENCIAL()
        {
            AREA_OTORGADA = -1;
            TIPO = -1;
            VOLUMEN = -1;

        }
        #endregion
    }
}
