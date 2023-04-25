using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_GENEPERSONA
    {
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("BusGrupo")]
        public String BusGrupo { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("COD_PERSONALTECPROF")]
        public String COD_PERSONALTECPROF { get; set; }
        [Description("COD_RELPELCENTROCRIA")]
        public String COD_RELPELCENTROCRIA { get; set; }
        [Description("TIPO")]
        public String TIPO { get; set; }
        [Description("OTRO")]
        public String OTRO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("PERSONA")]
        public String PERSONA { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("COD_UBIGEO")]
        public String COD_UBIGEO { get; set; }
        [Description("UBIGEO")]
        public String UBIGEO { get; set; }
        //
        [Description("COD_DIDENTIDAD")]
        public String COD_DIDENTIDAD { get; set; }
        [Description("DIDENTIDAD")]
        public String DIDENTIDAD { get; set; }
        [Description("SEXO")]
        public String SEXO { get; set; }
        [Description("APE_PATERNO")]
        public String APE_PATERNO { get; set; }
        [Description("APE_MATERNO")]
        public String APE_MATERNO { get; set; }
        [Description("NOMBRES")]
        public String NOMBRES { get; set; }
        [Description("DOCUMENTO")]
        public String DOCUMENTO { get; set; }
        [Description("N_DOCUMENTO")]
        public String N_DOCUMENTO { get; set; }
        [Description("TIPO_PERSONA")]
        public String TIPO_PERSONA { get; set; }
        [Description("TIPO_PERSONA_TEXT")]
        public String TIPO_PERSONA_TEXT { get; set; }
        [Description("N_RUC")]
        public String N_RUC { get; set; }
        [Description("COD_PTIPO")]
        public String COD_PTIPO { get; set; }
        [Description("PTIPO")]
        public String PTIPO { get; set; }
        [Description("FICHA_REGISTRAL")]
        public String FICHA_REGISTRAL { get; set; }
        [Description("DIRECCION")]
        public String DIRECCION { get; set; }
        [Description("CORREO")]
        public String CORREO { get; set; }
        [Description("TIPO_CORREO")]
        public String TIPO_CORREO { get; set; }
        [Description("TELEFONO")]
        public String TELEFONO { get; set; }
        [Description("TIPO_TELEFONO")]
        public String TIPO_TELEFONO { get; set; }
        [Description("CARGO")]
        public String CARGO { get; set; }
        [Description("COLEGIATURA_NUM")]
        public String COLEGIATURA_NUM { get; set; }
        [Description("COD_DPESPECIALIDAD")]
        public String COD_DPESPECIALIDAD { get; set; }
        [Description("DESC_DPESPECIALIDAD")]
        public String DESC_DPESPECIALIDAD { get; set; }
        [Description("COD_NACADEMICO")]
        public String COD_NACADEMICO { get; set; }
        [Description("DESC_NACADEMICO")]
        public String DESC_NACADEMICO { get; set; }
        [Description("NUM_REGISTRO_FFS")]
        public String NUM_REGISTRO_FFS { get; set; }
        [Description("NUM_REGISTRO_PROFESIONAL")]
        public String NUM_REGISTRO_PROFESIONAL { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Description("FLAG_FIRMA")]
        public Int32 FLAG_FIRMA { get; set; }
        [Description("ESTADO_FIRMA")]
        public String ESTADO_FIRMA { get; set; }
        [Description("OUTPUTPARAM01")]
        public String OUTPUTPARAM01 { get; set; }

        [Category("LIST"), Description("ListMComboDIdentidad")]
        public List<Ent_GENEPERSONA> ListMComboDIdentidad { get; set; }
        [Category("LIST"), Description("ListCTipoPersona")]
        public List<Ent_GENEPERSONA> ListCTipoPersona { get; set; }
        public Ent_GENEPERSONA()
        {
            RegEstado = -1;
            this.FLAG_FIRMA = -1;
        }
    }
}
