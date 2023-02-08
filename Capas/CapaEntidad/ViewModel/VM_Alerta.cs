using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEntidad = CapaEntidad.DOC.Ent_ALERTA;

namespace CapaEntidad.ViewModel
{
    public class VM_Alerta
    {
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string TipoFormulario { get; set; }
        public string RegEstado { get; set; }
        public string Tipo { get; set; }

        public CEntidad entidad { get; set; }
        public List<CEntidad> ListALERTA { get; set; }
        public List<CEntidad> ListVertices { get; set; }
        public List<CEntidad> ListBEXT { get; set; }
        public IEnumerable<VM_Cbo> ListOD { get; set; }

        public List<CEntidad> ListDepartamentos { get; set; }
        public List<CEntidad> ListSupuestos { get; set; }
        public List<CEntidad> ListDocRecibido { get; set; }
        public List<CEntidad> ListRptaEnlace { get; set; }        
        public string codigoDato { get; set; }
        public string codigoComplementario { get; set; }
        public int ListIndex { get; set; }
        public string ARCHIVO_OFICIO_TEXT { get; set; }
        public string ARCHIVO_OFICIO { get; set; }
        public string ESTADO_ARCHIVO_OFICIO { get; set; }
    }
}
