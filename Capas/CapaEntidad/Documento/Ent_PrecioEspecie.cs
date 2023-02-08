using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_PrecioEspecie
    {
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        [Description("COD_LISTA_PRECIO_ESPECIE")]
        public String COD_LISTA_PRECIO_ESPECIE { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("NOMBRE_LISTA_PRECIOS")]
        public String NOMBRE_LISTA_PRECIOS { get; set; }
        [Description("COD_OD")]
        public String COD_OD { get; set; }
        [Description("OD_DESCRIPCION")]
        public String OD_DESCRIPCION { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("USUARIO")]
        public String USUARIO { get; set; }
        [Category("FECHA"), Description("FECHA_SONDEO")]
        public Object FECHA_SONDEO { get; set; }
        [Description("CANT_ESPECIES")]
        public Int32 CANT_ESPECIES { get; set; }
        [Description("COD_ENCIENTIFICO")]
        public String COD_ENCIENTIFICO { get; set; }
        [Description("NOM_ENCIENTIFICO")]
        public String NOM_ENCIENTIFICO { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("NOMBRE_COMUN")]
        public String NOMBRE_COMUN { get; set; }
        [Description("PRECIO")]
        public Decimal PRECIO { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }

        [Description("OUTPUTPARAM01")]
        public String OUTPUTPARAM01 { get; set; }
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }

        [Category("LIST"), Description("ListadoPrecioEspecies")]
        public List<Ent_PrecioEspecie> ListadoPrecioEspecies { get; set; }
        [Category("LIST"), Description("ListEspecies")]
        public List<Ent_PrecioEspecie> ListEspecies { get; set; }
        [Category("LIST"), Description("ListOD")]
        public List<Ent_PrecioEspecie> ListOD { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_PrecioEspecie> ListEliTABLA { get; set; }


        public Ent_PrecioEspecie()
        {
            RegEstado = -1;
            CANT_ESPECIES = -1;
            COD_SECUENCIAL = -1;
            PRECIO = -1;
        }

    }
}
