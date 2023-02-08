using System.ComponentModel;

namespace CapaEntidad.GENE
{
    public class Ent_AUDITORIA
    {
        [Description("ipServer")]
        public string ipServer { get; set; }
        [Description("ipCliente")]
        public string ipCliente { get; set; }
        [Description("hostName")]
        public string hostName { get; set; }
        [Description("codCuentaUsuario")]
        public string codCuentaUsuario { get; set; }
        [Description("app")]
        public string app { get; set; }
    }
}
