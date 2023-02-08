using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace CapaEntidad.GENE
{
    public class Ent_DEPENDENCIA_UBIGEO
    {
        #region "Entidades y Propiedades"
        [Description("COD_UBIGEO")]
        public String COD_UBIGEO { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }

        [Category("LIST"), Description("ListDependencia")]
        public List<Ent_DEPENDENCIA_UBIGEO> ListDependencia { get; set; }
        #endregion

    }
}
