using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Ruta
    {
        #region "Entidades y Propiedades"
        [Description("COD_RUTA")]
        public Int32 COD_RUTA { get; set; }
        [Description("COD_UBIDEPARTAMENTO")]
        public String COD_UBIDEPARTAMENTO { get; set; }
        [Description("TRAMO")]
        public String TRAMO { get; set; }
        [Description("RUTA")]
        public Int32 RUTA { get; set; }
        [Description("ORIGEN_DESTINO")]
        public String ORIGEN_DESTINO { get; set; }
        [Description("ESTADO")]
        public String ESTADO { get; set; }

        [Description("FECHA_CREACION")]
        public DateTime FECHA_CREACION { get; set; }
        [Description("FECHA_MODIFICAR")]
        public DateTime FECHA_MODIFICAR { get; set; }
        [Description("COD_UCUENTA_CREACION")]
        public String COD_UCUENTA_CREACION { get; set; }
        [Description("COD_UCUENTA_MODIFICAR")]
        public String COD_UCUENTA_MODIFICAR { get; set; }
        #endregion
    }
}
