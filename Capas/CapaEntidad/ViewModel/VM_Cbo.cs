using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_Cbo
    {
        public bool Selected { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public string Tipo { get; set; }
        public string Group { get; set; }
    }
    public class VM_Cbo_Propiedad
    {
        public string SelectedValue { get; set; }
        public bool Enabled { get; set; }
        public List<VM_Cbo> VM_Cbo { get; set; }
    }

    public class VM_Chk
    {
        public bool Checked { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public string Group { get; set; }

        public VM_Chk()
        {
            Checked = false;
        }
    }
    public class VM_Cbo_General
    {
        public List<VM_Cbo> ListMComboEspecieFauna { get; set; }
        public List<VM_Cbo> ListMComboMotivo { get; set; }
        public List<VM_Cbo> ListMComboDocumento { get; set; }
    }
}
