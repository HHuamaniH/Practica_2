using System.ComponentModel;

namespace CapaEntidad.ViewModel
{
    public class VM_PAU_DIGITAL_ALERTA
    {
        [Description("TITULO")]
        public string TITULO { get; set; }
        [Description("DESTINATARIOS")]
        public string DESTINATARIOS { get; set; }
        [Description("CC_DESTINATARIOS")]
        public string CC_DESTINATARIOS { get; set; }
        [Description("COD_INFORME")]
        public string COD_INFORME { get; set; }
        [Description("MENSAJE_ENVIO_ALERTA")]
        public string MENSAJE_ENVIO_ALERTA { get; set; }
        [Description("URL_LOCAL")]
        public string URL_LOCAL { get; set; }
    }
}
