using System;
using System.Collections.Generic;

namespace CapaEntidad.ViewModel.General
{
    public class VM_Perfil_Menu
    {
        public string codPerfil { get; set; }
        public string nPerfil { get; set; }
        public List<VM_Cbo> cboModulo { get; set; }
        public List<VM_Cbo> cboGrupo { get; set; }
        public List<Dictionary<string, string>> lstMenus { get; set; }
    }
    public class VM_Menu_Rol
    {
        public Int32? NCODROL { get; set; }
        public String VDESCRIPCION { get; set; }
        public String VALIAS { get; set; }
        public String PERFIL { get; set; }
    }
    public class VM_Menu_List
    {
        public String COD_SMODULOS { get; set; }
        public String MODULO { get; set; }
        public String COD_SMGRUPO { get; set; }
        public String GRUPO { get; set; }
        public Int32 COD_SECUENCIAL_PADRE { get; set; }
        public String MENU_PADRE { get; set; }
        public Int32 COD_SECUENCIAL_HIJO { get; set; }
        public String MENU_HIJO { get; set; }
        public Int32 MODULO_N_ORDEN { get; set; }
        public Int32 GRUPO_N_ORDEN { get; set; }
        public Int32 COD_SECUENCIAL { get; set; }
        public Int32 estado { get; set; }
        public Int32? CODPERFILESROLMENU { get; set; }
        public Int32? NCODROL { get; set; }
        public String VDESCRIPCION { get; set; }
        public String VALIAS { get; set; }




    }
    public class VM_Perfil_Menu_List
    {
        public string codPerfil { get; set; }
        public string op { get; set; }
        public string p1 { get; set; }
        public string p2 { get; set; }
        //Datos menú accesos (opciones)        
        public List<VM_Menu_List> listMenus { get; set; }
        public List<VM_Menu_List> listMenusAsig { get; set; }
    }
    public class VM_Usuario_Menu_List
    {
        public string codUsuario { get; set; }
        public string op { get; set; }
        public string p1 { get; set; }
        public string p2 { get; set; }
        //Datos menú accesos (opciones)        
        public List<VM_Menu_List> listMenus { get; set; }
        public List<VM_Menu_List> listMenusAsig { get; set; }
    }
    public class VM_Usuario_Perfil_List
    {
        public string codUsuario { get; set; }
        public string op { get; set; }
        public string p1 { get; set; }
        public string p2 { get; set; }
        public List<VM_Perfil> listPerfil { get; set; }
        public List<VM_Perfil> listPerfilAsig { get; set; }
    }
}
