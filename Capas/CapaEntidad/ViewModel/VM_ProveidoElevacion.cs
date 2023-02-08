using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_ProveidoElevacion
    {
        public string hdcodigo { get; set; }
        public Int32 RegEstado { get; set; }
        public string lblItemTitulo { get; set; }
        public string txtidDireccionLinea { get; set; }
        public string hdfFuncionarioCodigo { get; set; }
        public string txtFuncionario { get; set; }
        public string hsfProfesionalCodigo { get; set; }
        public string txtProfesional { get; set; }
        public string txtFechaDerivacion { get; set; }
        public string txtObservacion { get; set; }
        public string txtIdOD { get; set; }
        public string txtIdDerivadoPara { get; set; }
        public string txtDerivadopara { get; set; }
        public string txtIdOficina { get; set; }

        public List<Ent_PROVEIDO> ListInformes { get; set; }
        public VM_ControlCalidad_2 vmControlCalidad { get; set; }

        public List<Ent_PROVEIDO> ListDirecionLinea { get; set; }
        public List<Ent_PROVEIDO> ListDerivadopara { get; set; }
        public List<Ent_PROVEIDO> ListODs { get; set; }
        public List<Ent_SBusqueda> sBusqueda { get; set; }
        public List<Ent_PROVEIDO> listEliTabla { get; set; }

        

    }
}
