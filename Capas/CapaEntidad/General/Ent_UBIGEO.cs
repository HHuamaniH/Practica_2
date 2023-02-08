using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace CapaEntidad.GENE
{
    public class Ent_UBIGEO
    {
        #region "Entidades y Propiedades"
        [Description("COD_UBIDEPARTAMENTO")]
        public String COD_UBIDEPARTAMENTO { get; set; }
        [Description("COD_UBIPROVINCIA")]
        public String COD_UBIPROVINCIA { get; set; }
        [Description("COD_UBIGEO")]
        public String COD_UBIGEO { get; set; }
        [Description("DEPARTAMENTO")]
        public String DEPARTAMENTO { get; set; }
        [Description("PROVINCIA")]
        public String PROVINCIA { get; set; }
        [Description("DISTRITO")]
        public String DISTRITO { get; set; }
        [Description("VALOR_PDETERMINADO")]
        public Object VALOR_PDETERMINADO { get; set; }
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Category("LIST"), Description("ListDepartamento")]
        public List<Ent_UBIGEO> ListDepartamento { get; set; }
        [Category("LIST"), Description("ListProvincia")]
        public List<Ent_UBIGEO> ListProvincia { get; set; }
        [Category("LIST"), Description("ListDistrito")]
        public List<Ent_UBIGEO> ListDistrito { get; set; }
        #endregion

    }
}
