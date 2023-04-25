using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Usuario
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
        [Description("COD_UCUENTA_CREACION")]
        public String COD_UCUENTA_CREACION { get; set; }

        //Datos usuario
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("COD_UGRUPO")]
        public String COD_UGRUPO { get; set; }
        [Description("USUARIO_LOGIN")]
        public String USUARIO_LOGIN { get; set; }
        [Description("TIPO_PERSONAL")]
        public String TIPO_PERSONAL { get; set; }
        [Description("CARGO")]
        public String CARGO { get; set; }
        [Description("LUGAR_TRABAJO")]
        public String LUGAR_TRABAJO { get; set; }
        [Description("OFICINA")]
        public String OFICINA { get; set; }
        [Description("INSTITUCION")]
        public String INSTITUCION { get; set; }

        [Description("USUARIO_CONTRASENA")]
        public String USUARIO_CONTRASENA { get; set; }
        [Description("CONTRASENA_CAMBIAR")]
        public String CONTRASENA_CAMBIAR { get; set; }
        [Description("APELLIDOS_NOMBRES")]
        public String APELLIDOS_NOMBRES { get; set; }
        [Description("ESTADO_ACTIVO")]
        public Object ESTADO_ACTIVO { get; set; }

        [Description("esPublico")]
        public Object esPublico { get; set; }
        [Description("NOTIFICADO")]
        public Object NOTIFICADO { get; set; }

        //Datos menú accesos (opciones)
        [Description("COD_SMODULOS")]
        public String COD_SMODULOS { get; set; }
        [Description("MODULO")]
        public String MODULO { get; set; }
        [Description("COD_SMGRUPO")]
        public String COD_SMGRUPO { get; set; }
        [Description("GRUPO")]
        public String GRUPO { get; set; }
        [Description("COD_SECUENCIAL_PADRE")]
        public Int32 COD_SECUENCIAL_PADRE { get; set; }
        [Description("MENU_PADRE")]
        public String MENU_PADRE { get; set; }
        [Description("COD_SECUENCIAL_HIJO")]
        public Int32 COD_SECUENCIAL_HIJO { get; set; }
        [Description("MENU_HIJO")]
        public String MENU_HIJO { get; set; }
        [Description("MODULO_N_ORDEN")]
        public Int32 MODULO_N_ORDEN { get; set; }
        [Description("GRUPO_N_ORDEN")]
        public Int32 GRUPO_N_ORDEN { get; set; }
        [Description("ROL_MODIFICAR")]
        public Object ROL_MODIFICAR { get; set; }
        [Description("ROL_ELIMINAR")]
        public Object ROL_ELIMINAR { get; set; }
        [Description("ROL_NUEVO")]
        public Object ROL_NUEVO { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }

        //Agregar Control de Accesos
        [Description("ACCESO_NOCADUCA")]
        public Object ACCESO_NOCADUCA { get; set; }
        [Category("FECHA"), Description("FECHA_SOLICITUD")]
        public Object FECHA_SOLICITUD { get; set; }

        [Category("FECHA"), Description("FECHA_DESDE")]
        public Object FECHA_DESDE { get; set; }

        [Category("FECHA"), Description("FECHA_HASTA")]
        public Object FECHA_HASTA { get; set; }

        //Eliminar registro
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public Int32 EliVALOR02 { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_Usuario> ListEliTABLA { get; set; }

        //Listado
        [Category("LIST"), Description("ListCGrupo")]
        public List<Ent_Usuario> ListCGrupo { get; set; }
        [Category("LIST"), Description("ListMenuNoAsignado")]
        public List<Ent_Usuario> ListMenuNoAsignado { get; set; }
        [Category("LIST"), Description("ListMenuAsignado")]
        public List<Ent_Usuario> ListMenuAsignado { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM02")]
        public Object OUTPUTPARAM02 { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        [Description("NCODROL")]
        public Int32 NCODROL { get; set; }

        public Ent_Usuario()
        {
            EliVALOR02 = -1;
            RegEstado = -1;
            COD_SECUENCIAL_HIJO = -1;
            COD_SECUENCIAL_PADRE = -1;
            MODULO_N_ORDEN = -1;
            GRUPO_N_ORDEN = -1;
            COD_SECUENCIAL = -1;
            NCODROL = -1;
        }
    }
}
