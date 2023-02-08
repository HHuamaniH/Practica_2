using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_IndicadorFiltro
    {
        public int idTab { get; set; }

        //Variables de menú MAPRO
        public IEnumerable<VM_Cbo> ddlIndicadorMAPRO { get; set; }
        public string ddlIndicadorMAPROId { get; set; }
        public IEnumerable<VM_Cbo> ddlAnioMAPRO { get; set; }
        public string ddlAnioMAPROId { get; set; }
        public string tipo { get; set; }
        public int numero { get; set; }

        //Variables de menú POI
        public IEnumerable<VM_Cbo> ddlIndicadorPOI { get; set; }
        public string ddlIndicadorPOIId { get; set; }
        public IEnumerable<VM_Cbo> ddlAnioPOI { get; set; }
        public string ddlAnioPOIId { get; set; }
        public IEnumerable<VM_Cbo> ddlMesPOI { get; set; }
        public string ddlMesPOIId { get; set; }

        //Variables de menú PEI
        public IEnumerable<VM_Cbo> ddlIndicadorPEI { get; set; }
        public string ddlIndicadorPEIId { get; set; }
        public IEnumerable<VM_Cbo> ddlAnioPEI { get; set; }
        public string ddlAnioPEIId { get; set; }

        public VM_IndicadorFiltro()
        {
            idTab = 0;
        }
    }
}
