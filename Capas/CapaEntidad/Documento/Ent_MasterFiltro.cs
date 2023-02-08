using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_MasterFiltro
    {
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }

        [Category("LIST"), Description("ListAnios")]
        public List<Ent_MasterFiltro> ListAnios { get; set; }
        [Category("LIST"), Description("ListModalidad")]
        public List<Ent_MasterFiltro> ListModalidad { get; set; }
        [Category("LIST"), Description("ListRegion")]
        public List<Ent_MasterFiltro> ListRegion { get; set; }
        [Category("LIST"), Description("ListArticulos")]
        public List<Ent_MasterFiltro> ListArticulos { get; set; }
        [Category("LIST"), Description("ListDLinea")]
        public List<Ent_MasterFiltro> ListDLinea { get; set; }
        [Category("LIST"), Description("ListDLinea2")]
        public List<Ent_MasterFiltro> ListDLinea2 { get; set; }
        [Category("LIST"), Description("ListEspecies")]
        public List<Ent_MasterFiltro> ListEspecies { get; set; }
        [Category("LIST"), Description("ListOD")]
        public List<Ent_MasterFiltro> ListOD { get; set; }
        [Category("LIST"), Description("ListProfesional")]
        public List<Ent_MasterFiltro> ListProfesional { get; set; }
        [Category("LIST"), Description("ListInstancia")]
        public List<Ent_MasterFiltro> ListInstancia { get; set; }

        public Ent_MasterFiltro()
        {

        }
    }
}
