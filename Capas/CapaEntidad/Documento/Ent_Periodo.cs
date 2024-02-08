using System.ComponentModel;

namespace CapaEntidad.Documento
{
    public class Ent_Periodo
    {
        public Ent_Periodo()
        {
            IDPERIODO = string.Empty;
        }

        [Description("IDPERIODO")]
        public string IDPERIODO { get; set; }

        [Description("MOTIVO")]
        public string MOTIVO { get; set; }

        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }

        [Description("ACTIVO")]
        public int ACTIVO { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public string OUTPUTPARAM01 { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM02")]
        public string OUTPUTPARAM02 { get; set; }
    }
}
