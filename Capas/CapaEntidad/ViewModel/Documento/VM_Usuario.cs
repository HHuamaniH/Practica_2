using System;
using System.Collections.Generic;

namespace CapaEntidad.ViewModel.DOC
{
    public class VM_Usuario
    {
        public string titulo { get; set; }
        public string id { get; set; }
        public string codPersona { get; set; }
        public string desPersona { get; set; }
        //[Required(ErrorMessage = "El campo {0} es obligatorio")]
        //[MaxLength(10, ErrorMessage = "El tamaño máximo de {0} es de {1} caracteres")]
        //[MinLength(4)]
        public string usuario { get; set; }
        public bool modPassword { get; set; }
        //[Required(ErrorMessage = "El campo {0} es obligatorio")]
        //[MaxLength(6, ErrorMessage = "El tamaño máximo de {0} es de {1} caracteres")]
        //[MinLength(4)]
        public string password { get; set; }
        //[Required(ErrorMessage = "El campo {0} es obligatorio")]
        //[MaxLength(6, ErrorMessage = "El tamaño máximo de {0} es de {1} caracteres")]
        //[MinLength(4)]
        public string passwordR { get; set; }
        public string passwordN { get; set; }
        public bool remPassword { get; set; }
        public bool activo { get; set; }

        public bool esPublico { get; set; }
        public Int32 estado { get; set; }
        public string cargo { get; set; }
        public string oficina { get; set; }
        public string institucion { get; set; }
        public string ddlTipoPersonalId { get; set; }
        public string ddlLugarTrabajoId { get; set; }

        public IEnumerable<VM_Cbo> ddlTipoPersonal { get; set; }
        public IEnumerable<VM_Cbo> ddlLugarTrabajo { get; set; }
    }
}
