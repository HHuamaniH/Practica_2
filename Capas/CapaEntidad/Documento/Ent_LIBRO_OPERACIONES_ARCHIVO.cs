using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_LIBRO_OPERACIONES_ARCHIVO
    {
        [Description("LIBRO_OPERACIONES_ARCHIVO_ID")]
        public long LIBRO_OPERACIONES_ARCHIVO_ID { get; set; }
        [Description("LIBRO_OPERACIONES_TH_ID")]
        public long LIBRO_OPERACIONES_TH_ID { get; set; }
        [Description("NOMBRE_ARCH")]
        public string NOMBRE_ARCH { get; set; }
        [Description("NOMBRE_GENERADO")]
        public string NOMBRE_GENERADO { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("OUTPUTPARAM02")]
        public string OUTPUTPARAM02 { get; set; }
        public Ent_LIBRO_OPERACIONES_ARCHIVO()
        {
            LIBRO_OPERACIONES_ARCHIVO_ID = -1;
        }
    }
}
