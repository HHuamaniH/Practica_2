using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Persona
    {
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }

        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }

        //Datos Persona
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("APELLIDOS_NOMBRES")]
        public String APELLIDOS_NOMBRES { get; set; }
        [Description("TIPO_DOCUMENTO")]
        public String TIPO_DOCUMENTO { get; set; }
        [Description("N_DOCUMENTO")]
        public String N_DOCUMENTO { get; set; }
        //PERSONAS NATURALES CON RUC
        [Description("N_RUC")]
        public String N_RUC { get; set; }
        [Description("TIPO_PERSONA")]
        public String TIPO_PERSONA { get; set; }
        [Description("COD_TPERSONA")]
        public String COD_TPERSONA { get; set; }
        [Description("COD_DIDENTIDAD")]
        public String COD_DIDENTIDAD { get; set; }
        [Description("APE_PATERNO")]
        public String APE_PATERNO { get; set; }
        [Description("APE_MATERNO")]
        public String APE_MATERNO { get; set; }
        [Description("NOMBRES")]
        public String NOMBRES { get; set; }
        [Description("RAZON_SOCIAL")]
        public String RAZON_SOCIAL { get; set; }
        [Description("COD_SEXO")]
        public String COD_SEXO { get; set; }
        //Datos domicilio
        [Description("COD_UBIGEO")]
        public String COD_UBIGEO { get; set; }
        [Description("UBIGEO")]
        public String UBIGEO { get; set; }
        [Description("DIRECCION")]
        public String DIRECCION { get; set; }
        [Description("DATOS_REFERENCIALES")]
        public String DATOS_REFERENCIALES { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        //Datos telefono
        [Description("COD_TTELEFONO")]
        public String COD_TTELEFONO { get; set; }
        [Description("TIPO_TELEFONO")]
        public String TIPO_TELEFONO { get; set; }
        [Description("NUMERO")]
        public String NUMERO { get; set; }
        [Description("ANEXO")]
        public String ANEXO { get; set; }
        //Datos correo
        [Description("COD_TCORREO")]
        public String COD_TCORREO { get; set; }
        [Description("TIPO_CORREO")]
        public String TIPO_CORREO { get; set; }
        [Description("CORREO")]
        public String CORREO { get; set; }
        [Description("NOTIFICAR")]
        public Object NOTIFICAR { get; set; }
        [Description("TXT_NOTIFICAR")]
        public String TXT_NOTIFICAR { get; set; }
        //Datos tipo cargo
        [Description("COD_PTIPO")]
        public String COD_PTIPO { get; set; }
        //Datos profesional
        [Description("NUM_REGISTRO_FFS")]
        public String NUM_REGISTRO_FFS { get; set; }
        [Description("CARGO")]
        public String CARGO { get; set; }
        [Description("COD_DPESPECIALIDAD")]
        public String COD_DPESPECIALIDAD { get; set; }
        [Description("COD_NACADEMICO")]
        public String COD_NACADEMICO { get; set; }
        [Description("COLEGIATURA_NUM")]
        public String COLEGIATURA_NUM { get; set; }
        [Description("NUM_REGISTRO_PROFESIONAL")]
        public String NUM_REGISTRO_PROFESIONAL { get; set; }
        [Description("NINTERNET")]
        public int NINTERNET { get; set; }
        [Description("NACTIVO")]
        public int NACTIVO { get; set; }
        [Description("NACTIVO_NOM")]
        public string NACTIVO_NOM { get; set; }

        //Listado
        [Category("LIST"), Description("ListCTipoPersona")]
        public List<Ent_Persona> ListCTipoPersona { get; set; }
        [Category("LIST"), Description("ListCTipoDocIdentidad")]
        public List<Ent_Persona> ListCTipoDocIdentidad { get; set; }
        [Category("LIST"), Description("ListCSexo")]
        public List<Ent_Persona> ListCSexo { get; set; }
        [Category("LIST"), Description("ListCTipoTelefono")]
        public List<Ent_Persona> ListCTipoTelefono { get; set; }
        [Category("LIST"), Description("ListCTipoCorreo")]
        public List<Ent_Persona> ListCTipoCorreo { get; set; }
        [Category("LIST"), Description("ListCTipoCargo")]
        public List<Ent_Persona> ListCTipoCargo { get; set; }
        [Category("LIST"), Description("ListCNivelAcademico")]
        public List<Ent_Persona> ListCNivelAcademico { get; set; }
        [Category("LIST"), Description("ListCEspecialidad")]
        public List<Ent_Persona> ListCEspecialidad { get; set; }

        [Category("LIST"), Description("ListDomicilio")]
        public List<Ent_Persona> ListDomicilio { get; set; }
        [Category("LIST"), Description("ListTelefono")]
        public List<Ent_Persona> ListTelefono { get; set; }
        [Category("LIST"), Description("ListCorreo")]
        public List<Ent_Persona> ListCorreo { get; set; }
        [Category("LIST"), Description("ListTipoCargo")]
        public List<Ent_Persona> ListTipoCargo { get; set; }

        //Eliminar registro
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public Int32 EliVALOR02 { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_Persona> ListEliTABLA { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        public Ent_Persona()
        {
            RegEstado = -1;
            EliVALOR02 = -1;
            COD_SECUENCIAL = -1;
            NINTERNET = -1;
            NACTIVO = -1;
        }
    }
}
