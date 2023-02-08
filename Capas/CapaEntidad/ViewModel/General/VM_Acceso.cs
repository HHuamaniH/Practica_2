using System.Collections.Generic;

namespace CapaEntidad.ViewModel.General
{
    public class VM_Acceso
    {
        public string codUsuario { get; set; }
        public int id_acceso { get; set; }
        public int estado { get; set; }
        public string fecha_registro { get; set; }
        public string fecha_solicitud { get; set; }
        public string fecha_desde { get; set; }
        public string fecha_hasta { get; set; }
        public bool accesoNoCaduca { get; set; }
        public string titulo { get; set; }
        public string op { get; set; }
        public List<VM_Acceso> listAccesoAsig { get; set; }
    }
}
