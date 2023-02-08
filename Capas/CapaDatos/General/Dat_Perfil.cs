using CapaEntidad.General;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using GeneralSQL.Data;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using GeneralSQL;
using System.Data;

namespace CapaDatos.General
{
    public class Dat_Perfil
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        public List<Dictionary<string, string>> GetListClasificacionPerfil(OracleConnection cn, int? id=null)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            try
            {
                using (OracleCommand cm = new OracleCommand("GENE_OSINFOR_ERP_MIGRACION.SPPERFIL_CLASIFICACION_LISTAR", cn))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.Add("NCODPADRE",id);
                   
                    using (OracleDataReader dr = cm.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Dictionary<string, string> sFila;
                                string sColumn = "";
                                while (dr.Read())
                                {
                                    sFila = new Dictionary<string, string>();
                                    for (int i = 0; i < dr.FieldCount; i++)
                                    {
                                        sColumn = dr.GetName(i);
                                        sFila.Add(sColumn, dr[sColumn].ToString());
                                    }
                                    lstResult.Add(sFila);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e) { throw (e); };
            return lstResult;
        }
        public VM_Menu_List _saveMenuRol(OracleConnection cn, VM_Perfil_Menu_List ent)
        {
            String OUTPUTPARAM01 = "";
            OracleTransaction tr = null;
            try
            {
                
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cm = new OracleCommand("GENE_OSINFOR_ERP_MIGRACION.SPPERFIL_ROLMENU_GRABAR", cn))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.Add("NCODROL", ent.listMenus[0].CODPERFILESROLMENU);
                    cm.Parameters.Add("NCODMENU", ent.listMenus[0].COD_SECUENCIAL);
                    cm.Parameters.Add("VCODPERFIL", ent.codPerfil);

                    //cm.ExecuteNonQuery();
                    //OUTPUTPARAM01 = (String)cm.Parameters["OUTPUTPARAM01"].Value;
                    //if (OUTPUTPARAM01 != "EXITO")
                    //{
                    //    throw new Exception(OUTPUTPARAM01);
                    //}
                    using (OracleDataReader dr = cm.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    OUTPUTPARAM01 = dr["OUTPUTPARAM01"].ToString();
                                }
                            }
                        }
                    }
                    if (OUTPUTPARAM01 != "EXITO")
                    {
                        throw new Exception(OUTPUTPARAM01);
                    }

                }
                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                tr.Dispose();
                tr = null;
                throw ex;
            }
            return ent.listMenus[0];
        }
        public bool SavePerfil(Ent_Perfil ent)
        {
            String OUTPUTPARAM02 = "";
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //Grabando Cabecera
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.uspSistema_Perfil_GrabarV3", ent))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                        if (OUTPUTPARAM02 != "EXITO")
                        {
                            throw new Exception(OUTPUTPARAM02);
                        }
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    tr.Dispose();
                    tr = null;
                    throw ex;
                }
            }
            return true;
        }
        public bool SavePerfilMenu(Ent_Perfil_Menu ent)
        {

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                OracleTransaction tr = null;
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    //Grabando asignacion
                    foreach (var item in ent.lstMenuNoAsignado)
                    {
                        dBOracle.ManExecute(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.uspPerfil_MENU_GrabarV3", item);
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    tr.Dispose();
                    tr = null;
                    throw ex;
                }
            }
            return true;
        }
        public List<Dictionary<string, string>> GetAllPerfil(Ent_BUSQUEDA_V3 ent)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "GENE_OSINFOR_ERP_MIGRACION.uspSistema_Seguridad_ListarV3", ent))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Dictionary<string, string> sFila;
                                string sColumn = "";
                                while (dr.Read())
                                {
                                    sFila = new Dictionary<string, string>();
                                    for (int i = 0; i < dr.FieldCount; i++)
                                    {
                                        sColumn = dr.GetName(i);
                                        sFila.Add(sColumn, dr[sColumn].ToString());
                                    }
                                    lstResult.Add(sFila);
                                }
                            }
                        }
                    }
                }
                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VM_Perfil GetIdPerfil(Ent_BUSQUEDA_V3 ent)
        {
            VM_Perfil vm = new VM_Perfil();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "GENE_OSINFOR_ERP_MIGRACION.uspSistema_Seguridad_ListarV3", ent))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm.id = dr["COD_SPERFIL"].ToString();
                                    vm.descr = dr["DESCRIPCION"].ToString();
                                    vm.descrClasificacion= dr["CLASIFICACION"].ToString();
                                    vm.idClasificacion =int.Parse( dr["IDCLASIFICACION"].ToString());
                                    vm.descrSubClasificacion = dr["SUBCLASIFICACION"].ToString();
                                    vm.idSubClasificacion = int.Parse(dr["IDSUBCLASIFICACION"].ToString());
                                    vm.act = Convert.ToBoolean(dr["ACTIVO"]);
                                    vm.estado = 0;
                                }
                            }
                        }
                    }
                }
                return vm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VM_Perfil_Menu GetIdPerfilMenu(Ent_BUSQUEDA_V3 ent)
        {
            VM_Perfil_Menu vm = new VM_Perfil_Menu();
            vm.cboModulo = new List<VM_Cbo>();
            vm.cboGrupo = new List<VM_Cbo>();
            VM_Cbo cbo;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "GENE_OSINFOR_ERP_MIGRACION.uspSistema_Seguridad_ListarV3", ent))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm.codPerfil = dr["COD_SPERFIL"].ToString();
                                    vm.nPerfil = dr["DESCRIPCION"].ToString();
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            { //modulos
                                while (dr.Read())
                                {
                                    cbo = new VM_Cbo();
                                    cbo.Text = dr["DESCRIPCION"].ToString();
                                    cbo.Value = dr["CODIGO"].ToString();
                                    vm.cboModulo.Add(cbo);
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            { //grupos
                                while (dr.Read())
                                {
                                    cbo = new VM_Cbo();
                                    cbo.Text = dr["DESCRIPCION"].ToString();
                                    cbo.Value = dr["CODIGO"].ToString();
                                    vm.cboGrupo.Add(cbo);
                                }
                            }

                        }
                    }
                }
                return vm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// oBTIENE TODOS LOS MENUS. CONFIGURABLE PARA LISTAR TODOS LOS MENUS NO SIGNADOS Y ASIGNADOS 
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public List<VM_Menu_List> GetAlltMenus(Ent_BUSQUEDA_V3 ent)
        {
            List<VM_Menu_List> listMenus = new List<VM_Menu_List>();
            VM_Menu_List oCamposDet;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "GENE_OSINFOR_ERP_MIGRACION.uspSistema_Seguridad_ListarV3", ent))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCamposDet = new VM_Menu_List();
                                    oCamposDet.COD_SMODULOS = dr.GetString(dr.GetOrdinal("COD_SMODULOS"));
                                    oCamposDet.MODULO = dr.GetString(dr.GetOrdinal("MODULO"));
                                    oCamposDet.COD_SMGRUPO = dr.GetString(dr.GetOrdinal("COD_SMGRUPO"));
                                    oCamposDet.GRUPO = dr.GetString(dr.GetOrdinal("GRUPO"));
                                    oCamposDet.COD_SECUENCIAL_PADRE = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL_PADRE"));
                                    oCamposDet.MENU_PADRE = dr.GetString(dr.GetOrdinal("MENU_PADRE"));
                                    oCamposDet.COD_SECUENCIAL_HIJO = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL_HIJO"));
                                    oCamposDet.MENU_HIJO = dr.GetString(dr.GetOrdinal("MENU_HIJO"));
                                    oCamposDet.MODULO_N_ORDEN = dr.GetInt32(dr.GetOrdinal("MODULO_N_ORDEN"));
                                    oCamposDet.GRUPO_N_ORDEN = dr.GetInt32(dr.GetOrdinal("GRUPO_N_ORDEN"));
                                   if( ent.BusCriterio== "GET_ALL_MENUS_ASIGNADO_PERFIL" || ent.BusCriterio == "GET_ALL_MENUS_USUARIO")
                                    {
                                        oCamposDet.CODPERFILESROLMENU = dr.GetInt32(dr.GetOrdinal("PK_PERFILESMAEROLMENU"));
                                        oCamposDet.NCODROL = dr.GetInt32(dr.GetOrdinal("NCODROL"));
                                        oCamposDet.VDESCRIPCION = dr.GetString(dr.GetOrdinal("VDESCRIPCION"));
                                        oCamposDet.VALIAS = dr.GetString(dr.GetOrdinal("VALIAS"));
                                    }
                                    
                                    if (ent.BusCriterio == "GET_ALL_MENUS") oCamposDet.estado = 1;
                                    else oCamposDet.estado = 0;
                                    listMenus.Add(oCamposDet);
                                }
                            }
                        }
                    }
                }
                return listMenus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
