using System.Collections.Generic;

namespace CapaEntidad.ViewModel.General
{
    public class VM_Usuario_Menu
    {
        public string codUsuario { get; set; }
        public string nUsuario { get; set; }
        public List<VM_Cbo> cboModulo { get; set; }
        public List<VM_Cbo> cboGrupo { get; set; }

    }
}
