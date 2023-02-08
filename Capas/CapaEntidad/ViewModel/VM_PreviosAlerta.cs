using System.Collections.Generic;
using CEntidad = CapaEntidad.DOC.Ent_PREVIOS_ALERTA;

namespace CapaEntidad.ViewModel
{
    public class VM_PreviosAlerta
    {
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string TipoFormulario { get; set; }
        public string RegEstado { get; set; }
        public string Tipo { get; set; }

        public List<CEntidad> ListDESTINATARIO { get; set; }

        public List<CEntidad> ListRUTA { get; set; }
        public List<CEntidad> ListDESTINATARIO_RUTA { get; set; }
        public List<CEntidad> ListSUPUESTO { get; set; }
        public List<CEntidad> ListEliTABLA { get; set; }        
        public List<CEntidad> ListDESTINATARIOCC { get; set; }
        public List<CEntidad> ListCOADMINISTRADOR { get; set; }
        public List<CEntidad> ListPERFILCOADMINISTRADOR { get; set; }
        public List<CEntidad> ListENTIDAD { get; set; }


        public IEnumerable<VM_Cbo> ddlRutaCodUbiDepartamento { get; set; }

        public IEnumerable<VM_Cbo> ddlDestinatarioRutaRuta { get; set; }
        public string ddlDestinatarioRutaRutaId { get; set; }        
    }

}
