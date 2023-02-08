using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Destinatario
    {
        #region "Entidades y Propiedades"
        [Description("COD_DESTINATARIO")]
        public Int32 COD_DESTINATARIO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("CORREO")]
        public String CORREO { get; set; }
        [Description("ESTADO")]
        public Int32 ESTADO { get; set; }
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
