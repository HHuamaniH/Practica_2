using System.Collections.Generic;

namespace CapaEntidad.ViewModel.General
{
    public class VM_ValidacionFormatos
    {//Condición Maderable
        public List<VM_Cbo> ListCondicionMad { get; set; }
        //Condición No Maderable
        public List<VM_Cbo> ListCondicionNoMad { get; set; }
        //Estado Campo Maderable
        public List<VM_Cbo> ListEstadoMad { get; set; }
        //Estado Campo No Maderable
        public List<VM_Cbo> ListEstadoNoMad { get; set; }
        //Instituciones Capacitaciones
        public List<VM_Cbo> ListInstitucionesCapac { get; set; }
    }
}
