using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.General
{
    public class Ent_Perfil
    {
        [Description("COD_SPERFIL")]
        public String COD_SPERFIL { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("IDSUBCLASIFICACION")]
        public String IDSUBCLASIFICACION { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("ACTIVO")]
        public int ACTIVO { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public string OUTPUTPARAM01 { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM02")]
        public string OUTPUTPARAM02 { get; set; }
    }
    public class Ent_Perfil_Menu
    {
        [Description("COD_SMODULOS")]
        public String COD_SMODULOS { get; set; }
        [Description("COD_SMGRUPO")]
        public String COD_SMGRUPO { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32? COD_SECUENCIAL { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("COD_SPERFIL")]
        public String COD_SPERFIL { get; set; }
        [Description("RegEstado")]
        public int? RegEstado { get; set; }
        public List<Ent_Perfil_Menu> lstMenuNoAsignado { get; set; }

    }
    public class Ent_Usuario_Perfil
    {
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("COD_UCUENTA_CREACION")]
        public String COD_UCUENTA_CREACION { get; set; }
        [Description("COD_SPERFIL")]
        public String COD_SPERFIL { get; set; }
        [Description("RegEstado")]
        public int? RegEstado { get; set; }

    }
    public class Ent_Usuario_Menu
    {
        [Description("COD_SMODULOS")]
        public String COD_SMODULOS { get; set; }
        [Description("COD_SMGRUPO")]
        public String COD_SMGRUPO { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32? COD_SECUENCIAL { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("COD_UCUENTA_CREACION")]
        public String COD_UCUENTA_CREACION { get; set; }
        [Description("RegEstado")]
        public int? RegEstado { get; set; }
        public List<Ent_Usuario_Menu> lstMenuNoAsignado { get; set; }
        [Description("NCODROL")]
        public Int32 NCODROL { get; set; }
        public Ent_Usuario_Menu()
        {
            NCODROL = -1;
        }

    }
}
