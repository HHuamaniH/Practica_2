using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace CapaEntidad.GENE
{
    public class Ent_USUARIO_CUENTA
    {
        #region "Entidades y Propiedades"				
        [Description("NIVEL_CUENTA")]
        public Int32 NIVEL_CUENTA { get; set; }
        //Usuario Cuenta
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("COD_SPERFILS")]
        public String COD_SPERFILS { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("COD_UGRUPO")]
        public String COD_UGRUPO { get; set; }
        [Description("COD_SPERFIL")]
        public String COD_SPERFIL { get; set; }

        [Required]
        [Description("USUARIO_LOGIN")]
        [Display(Name = "USUARIO")]
        public String USUARIO_LOGIN { get; set; }

        [Required]
        [Description("USUARIO_CONTRASENA")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Password")]
        public String USUARIO_CONTRASENA { get; set; }



        [Description("ESTADO_ACTIVO")]
        public Object ESTADO_ACTIVO { get; set; }
        [Description("ESTADO_CONTRASENA_CAMBIAR")]
        public Object ESTADO_CONTRASENA_CAMBIAR { get; set; }
        [Description("PERSONA")]
        public String PERSONA { get; set; }
        [Description("UGRUPO")]
        public String UGRUPO { get; set; }
        //Usuario Cuenta Menú
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("COD_SECUENCIAL_PADRE")]
        public Int32 COD_SECUENCIAL_PADRE { get; set; }
        [Description("COD_SECUENCIAL_HIJO")]
        public Int32 COD_SECUENCIAL_HIJO { get; set; }
        [Description("ROL_NUEVO")]
        public Object ROL_NUEVO { get; set; }
        [Description("ROL_MODIFICAR")]
        public Object ROL_MODIFICAR { get; set; }
        [Description("ROL_ELIMINAR")]
        public Object ROL_ELIMINAR { get; set; }
        //Sistema Modulo
        [Description("COD_SMODULOS")]
        public String COD_SMODULOS { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        //Sistema Modulo Menú
        [Description("COD_SMGRUPO")]
        public String COD_SMGRUPO { get; set; }
        //
        [Description("MODULO")]
        public String MODULO { get; set; }
        [Description("GRUPO")]
        public String GRUPO { get; set; }
        [Description("MENU")]
        public String MENU { get; set; }
        [Description("MENU_PADRE")]
        public String MENU_PADRE { get; set; }
        [Description("MENU_HIJO")]
        public String MENU_HIJO { get; set; }
        [Description("CONTRASENA_CAMBIAR")]
        public String CONTRASENA_CAMBIAR { get; set; }
        //
        [Description("MENU_URL")]
        public String MENU_URL { get; set; }
        [Description("MENU_URL_PADRE")]
        public String MENU_URL_PADRE { get; set; }
        [Description("MENU_URL_HIJO")]
        public String MENU_URL_HIJO { get; set; }
        [Description("MENU_URL_HIJO_MVC")]
        public String MENU_URL_HIJO_MVC { get; set; }
        [Description("MENU_URL_PADRE_MVC")]
        public String MENU_URL_PADRE_MVC { get; set; }
        [Description("USU_TSECCION_CODIGO")]
        public String USU_TSECCION_CODIGO { get; set; }
        [Description("USU_TSECCION_DESCRIPCION")]
        public String USU_TSECCION_DESCRIPCION { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("ANO")]
        public Int32 ANO { get; set; }
        [Description("EVALUACION")]
        public String EVALUACION { get; set; }
        [Description("COD_EVALUACION")]
        public String COD_EVALUACION { get; set; }
        [Description("COD_DEVALUACION")]
        public String COD_DEVALUACION { get; set; }
        [Description("COD_CURSO_GRUPO")]
        public String COD_CURSO_GRUPO { get; set; }
        [Description("COD_OPCIONES")]
        public String COD_OPCIONES { get; set; }
        [Description("COD_PERFIL")]
        public String COD_PERFIL { get; set; }
        [Description("NCODROL")]
        public Int32 NCODROL { get; set; }
        [Description("VDESCRIPCIONROL")]
        public String VDESCRIPCIONROL { get; set; }
        [Description("VALIASROL")]
        public String VALIASROL { get; set; }
        //
        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM02")]
        public Object OUTPUTPARAM02 { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        //Lista Objetos
        [Category("LIST"), Description("ListUCDMMENU")]
        public List<Ent_USUARIO_CUENTA> ListUCDMMENU { get; set; }
        [Category("LIST"), Description("ListMENUMODULO")]
        public List<Ent_USUARIO_CUENTA> ListMENUMODULO { get; set; }
        [Category("LIST"), Description("ListMENUGRUPO")]
        public List<Ent_USUARIO_CUENTA> ListMENUGRUPO { get; set; }
        [Category("LIST"), Description("ListMENUPADRE")]
        public List<Ent_USUARIO_CUENTA> ListMENUPADRE { get; set; }
        [Category("LIST"), Description("ListMENUMENU")]
        public List<Ent_USUARIO_CUENTA> ListMENUMENU { get; set; }
        #endregion

        #region "Constructor"
        public Ent_USUARIO_CUENTA()
        {
            COD_SECUENCIAL_PADRE = -1;
            COD_SECUENCIAL_HIJO = -1;
            COD_SECUENCIAL = -1;
            NIVEL_CUENTA = -1;
            ANO = -1;
            RegEstado = -1;
            NCODROL = -1;
        }
        #endregion
    }
}

