using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace CapaEntidad.GENE
{
    public class Ent_ESPECIES
    {
        [Description("COD_ENCIENTIFICO")]
        public String COD_ENCIENTIFICO { get; set; }

        [Description("MODALIDAD_TIPO")]
        public String MODALIDAD_TIPO { get; set; }

        [Description("NOMBRE_CIENTIFICO")]
        public String NOMBRE_CIENTIFICO { get; set; }
        [Description("NOMBRE_CIENTIFICON")]
        public String NOMBRE_CIENTIFICON { get; set; }

        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }

        [Description("NOMBRE_COMUN")]
        public String NOMBRE_COMUN { get; set; }
        [Description("NOMBRE_COMUNN")]
        public String NOMBRE_COMUNN { get; set; }
        [Description("COD_ESPECIESN")]
        public String COD_ESPECIESN { get; set; }

        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }

        [Description("COD_MTIPO")]
        public String COD_MTIPO { get; set; }

        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }

        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }

        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }

        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        [Description("COD_REINO")]
        public String COD_REINO { get; set; }
        [Description("NOMBRE_REINO")]
        public String NOMBRE_REINO { get; set; }

        [Description("COD_FILO")]
        public String COD_FILO { get; set; }
        [Description("NOMBRE_FILO")]
        public String NOMBRE_FILO { get; set; }

        [Description("COD_CLASE")]
        public String COD_CLASE { get; set; }
        [Description("NOMBRE_CLASE")]
        public String NOMBRE_CLASE { get; set; }

        [Description("COD_ORDEN")]
        public String COD_ORDEN { get; set; }
        [Description("NOMBRE_ORDEN")]
        public String NOMBRE_ORDEN { get; set; }

        [Description("COD_FAMILIA")]
        public String COD_FAMILIA { get; set; }
        [Description("NOMBRE_FAMILIA")]
        public String NOMBRE_FAMILIA { get; set; }

        [Description("COD_GENERO")]
        public String COD_GENERO { get; set; }
        [Description("NOMBRE_GENERO")]
        public String NOMBRE_GENERO { get; set; }

        [Description("TIPO")]
        public String TIPO { get; set; }
        [Description("TIPO_REGISTRO")]
        public String TIPO_REGISTRO { get; set; }
        [Description("FUENTE")]
        public String FUENTE { get; set; }

        [Description("COD_AGRADO_CITE")]
        public String COD_AGRADO_CITE { get; set; }
        [Description("COD_AGRADO_CITEN")]
        public String COD_AGRADO_CITEN { get; set; }
        [Description("DES_AGRADO_CITE")]
        public String DES_AGRADO_CITE { get; set; }
        [Description("COD_AGRADO_DS")]
        public String COD_AGRADO_DS { get; set; }
        [Description("COD_AGRADO_DSN")]
        public String COD_AGRADO_DSN { get; set; }
        [Description("DES_AGRADO_DS")]
        public String DES_AGRADO_DS { get; set; }
        [Description("COD_IMPORTANCIA")]
        public String COD_IMPORTANCIA { get; set; }
        [Description("DES_IMPORTANCIA")]
        public String DES_IMPORTANCIA { get; set; }




        [Category("FECHA"), Description("FECHA_CREACION")]
        public Object FECHA_CREACION { get; set; }
        [Category("FECHA"), Description("FECHA_MODIFICAR")]
        public Object FECHA_MODIFICAR { get; set; }

        [Category("LIST"), Description("ListComboReino")]
        public List<Ent_ESPECIES> ListComboReino { get; set; }
        [Category("LIST"), Description("ListComboFilo")]
        public List<Ent_ESPECIES> ListComboFilo { get; set; }
        [Category("LIST"), Description("ListComboClase")]
        public List<Ent_ESPECIES> ListComboClase { get; set; }
        [Category("LIST"), Description("ListComboOrden")]
        public List<Ent_ESPECIES> ListComboOrden { get; set; }
        [Category("LIST"), Description("ListComboFamilia")]
        public List<Ent_ESPECIES> ListComboFamilia { get; set; }
        [Category("LIST"), Description("ListComboGenero")]
        public List<Ent_ESPECIES> ListComboGenero { get; set; }
        [Category("LIST"), Description("ListGAmenaza")]
        public List<Ent_ESPECIES> ListGAmenaza { get; set; }
        [Category("LIST"), Description("ListEspeciesComun")]
        public List<Ent_ESPECIES> ListEspeciesComun { get; set; }
        [Category("LIST"), Description("ListNCientifico")]
        public List<Ent_ESPECIES> ListNCientifico { get; set; }
        [Category("LIST"), Description("ListNComun")]
        public List<Ent_ESPECIES> ListNComun { get; set; }

        public Ent_ESPECIES()
        {
            RegEstado = -1;
        }
    }
}
