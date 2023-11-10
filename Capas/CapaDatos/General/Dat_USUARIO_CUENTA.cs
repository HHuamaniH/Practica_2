
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CEntidad = CapaEntidad.GENE.Ent_USUARIO_CUENTA;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.GENE
{
    public class Dat_USUARIO_CUENTA
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        //public List<CEntidad> RegLoginValidando(SqlConnection cn, CEntidad oCEntidad, string version)
        //{
        //    string procedimiento = "";
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    try
        //    {
        //        CEntidad oCamposLU = new CEntidad();
        //        oCamposLU.USUARIO_LOGIN = oCEntidad.USUARIO_LOGIN;
        //        oCamposLU.USUARIO_CONTRASENA = oCEntidad.USUARIO_CONTRASENA;
        //        oCamposLU.COD_SMODULOS = oCEntidad.COD_SMODULOS;
        //        oCamposLU.OUTPUTPARAM01 = oCEntidad.OUTPUTPARAM01;
        //        oCamposLU.OUTPUTPARAM02 = oCEntidad.OUTPUTPARAM02;
        //        //Grabando Cabecera
        //        using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, null, "GENE.spUSUARIO_CUENTALoginVerifica", oCamposLU))
        //        {
        //            cmd.ExecuteNonQuery();
        //            Int32 OUTPUTPARAM01 = (Int32)cmd.Parameters["@OUTPUTPARAM01"].Value;
        //            String COD_UCUENTA = (String)cmd.Parameters["@OUTPUTPARAM02"].Value;
        //            if (OUTPUTPARAM01 == 1)
        //            {
        //                throw new Exception("1|Usuario o contraseña erroneo");
        //            }
        //            else if (OUTPUTPARAM01 == 2)
        //            {
        //                throw new Exception("2|Cuenta de Usuario Inactivo");
        //            }
        //            else if (OUTPUTPARAM01 == 4)
        //            {
        //                throw new Exception("2|(0) Modulos Asignados");
        //            }
        //            //CEntidad oCamposLU = new CEntidad();
        //            oCamposLU = new CEntidad();
        //            oCamposLU.COD_UCUENTA = COD_UCUENTA;
        //            oCamposLU.COD_SMODULOS = oCEntidad.COD_SMODULOS;
        //            if (version == "v2")
        //            { procedimiento = "GENE.spUSUARIO_CUENTALoginMostrar"; }
        //            else if (version == "v3")
        //            { procedimiento = "GENE.spUSUARIO_CUENTALoginMostrar_v3"; }
        //            using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, procedimiento, oCamposLU))
        //            {
        //                if (dr != null)
        //                {
        //                    CEntidad oCampos = new CEntidad();
        //                    //Datos de la Cuenta de Usuario
        //                    if (dr.HasRows)
        //                    {
        //                        dr.Read();
        //                        oCampos.COD_UCUENTA = dr.GetString(dr.GetOrdinal("COD_UCUENTA"));
        //                        oCampos.COD_PERSONA = dr.GetString(dr.GetOrdinal("COD_PERSONA"));
        //                        oCampos.COD_UGRUPO = dr.GetString(dr.GetOrdinal("COD_UGRUPO"));
        //                        oCampos.PERSONA = dr.GetString(dr.GetOrdinal("PERSONA"));
        //                        oCampos.UGRUPO = dr.GetString(dr.GetOrdinal("UGRUPO"));
        //                        oCampos.ESTADO_CONTRASENA_CAMBIAR = dr.GetBoolean(dr.GetOrdinal("ESTADO_CONTRASENA_CAMBIAR"));
        //                        oCampos.USUARIO_LOGIN = dr.GetString(dr.GetOrdinal("USUARIO_LOGIN"));
        //                    }
        //                    dr.NextResult();
        //                    List<CEntidad> lsDetMenu = new List<CEntidad>();
        //                    List<CEntidad> lsItemsGru = new List<CEntidad>();
        //                    List<CEntidad> lsItemsMenPadre = new List<CEntidad>();
        //                    List<CEntidad> lsItemsMenHijo = new List<CEntidad>();
        //                    //Manus de Acceso
        //                    if (dr.HasRows)
        //                    {
        //                        int p1 = dr.GetOrdinal("COD_SMODULOS");
        //                        int p2 = dr.GetOrdinal("COD_SMGRUPO");
        //                        int p3 = dr.GetOrdinal("MODULO");
        //                        int p4 = dr.GetOrdinal("GRUPO");
        //                        int p5 = dr.GetOrdinal("MENU_PADRE");
        //                        int p6 = dr.GetOrdinal("MENU_URL_PADRE");
        //                        int p7 = dr.GetOrdinal("MENU_HIJO");
        //                        int p8 = dr.GetOrdinal("COD_SECUENCIAL_PADRE");
        //                        int p9 = dr.GetOrdinal("COD_SECUENCIAL_HIJO");
        //                        int p10 = dr.GetOrdinal("MENU_URL_HIJO");
        //                        CEntidad oCEntidadDet;
        //                        String COD_SMODULOS = "";
        //                        String COD_SMGRUPO = "";
        //                        String COD_MENUPADRE = "";
        //                        while (dr.Read())
        //                        {
        //                            //Cargando Modulos al Listado General DetMenu
        //                            if (COD_SMODULOS != dr.GetString(p1))
        //                            {
        //                                oCEntidadDet = new CEntidad();
        //                                oCEntidadDet.COD_SMODULOS = dr.GetString(p1);
        //                                oCEntidadDet.MODULO = dr.GetString(p3);
        //                                lsDetMenu.Add(oCEntidadDet);
        //                                COD_SMODULOS = dr.GetString(p1);
        //                            }
        //                            //Cargando Grupos
        //                            string ss = String.Format("{0}{1}", dr.GetString(p1), dr.GetString(p2));

        //                            if (COD_SMGRUPO != String.Format("{0}{1}", dr.GetString(p1), dr.GetString(p2)))
        //                            {
        //                                oCEntidadDet = new CEntidad();
        //                                oCEntidadDet.COD_SMODULOS = dr.GetString(p1);
        //                                oCEntidadDet.COD_SMGRUPO = dr.GetString(p2);
        //                                oCEntidadDet.GRUPO = dr.GetString(p4);
        //                                lsItemsGru.Add(oCEntidadDet);
        //                                COD_SMGRUPO = String.Format("{0}{1}", dr.GetString(p1), dr.GetString(p2));
        //                            }
        //                            //Cargando Menu Padres
        //                            if (COD_MENUPADRE != String.Format("{0}{1}{2}", dr.GetString(p1), dr.GetString(p2), dr.GetInt32(p8).ToString()))
        //                            {
        //                                oCEntidadDet = new CEntidad();
        //                                oCEntidadDet.COD_SMODULOS = dr.GetString(p1);
        //                                oCEntidadDet.COD_SMGRUPO = dr.GetString(p2);
        //                                oCEntidadDet.COD_SECUENCIAL_PADRE = dr.GetInt32(p8);
        //                                oCEntidadDet.MENU_PADRE = dr.GetString(p5);

        //                                lsItemsMenPadre.Add(oCEntidadDet);
        //                                COD_MENUPADRE = String.Format("{0}{1}{2}", dr.GetString(p1), dr.GetString(p2), dr.GetInt32(p8).ToString());
        //                            }
        //                            oCEntidadDet = new CEntidad();
        //                            oCEntidadDet.COD_SMODULOS = dr.GetString(p1);
        //                            oCEntidadDet.COD_SMGRUPO = dr.GetString(p2);
        //                            oCEntidadDet.COD_SECUENCIAL_PADRE = dr.GetInt32(p8);
        //                            oCEntidadDet.COD_SECUENCIAL_HIJO = dr.GetInt32(p9);
        //                            oCEntidadDet.MODULO = dr.GetString(p3);
        //                            oCEntidadDet.GRUPO = dr.GetString(p4);
        //                            oCEntidadDet.MENU_PADRE = dr.GetString(p5);
        //                            oCEntidadDet.MENU_HIJO = dr.GetString(p7);
        //                            oCEntidadDet.MENU_URL_PADRE = dr.GetString(p6);
        //                            oCEntidadDet.MENU_URL_HIJO = dr.GetString(p10);
        //                            if (version == "v3")
        //                            {
        //                                oCEntidadDet.MENU_URL_HIJO_MVC = dr.GetString(dr.GetOrdinal("MENU_URL_HIJO_MVC"));
        //                                oCEntidadDet.MENU_URL_PADRE_MVC = dr.GetString(dr.GetOrdinal("MENU_URL_PADRE_MVC"));
        //                            }
        //                            lsItemsMenHijo.Add(oCEntidadDet);
        //                        }
        //                        foreach (var lsRegMod in lsDetMenu)
        //                        {
        //                            //lsDetMenu[IndexMod].ListMENUGRUPO = lsItemsGru.Where(person => person.COD_SMODULOS == lsRegMod.COD_SMODULOS).ToList<CEntidad>();
        //                            lsRegMod.ListMENUGRUPO = (from p in lsItemsGru where p.COD_SMODULOS == lsRegMod.COD_SMODULOS select p).ToList<CEntidad>();
        //                            //
        //                            foreach (var lsRegGrupo in lsRegMod.ListMENUGRUPO)
        //                            {
        //                                lsRegGrupo.ListMENUPADRE = (from p in lsItemsMenPadre where p.COD_SMODULOS == lsRegGrupo.COD_SMODULOS && p.COD_SMGRUPO == lsRegGrupo.COD_SMGRUPO select p).ToList<CEntidad>();

        //                                foreach (var lsRegMenuPadre in lsRegGrupo.ListMENUPADRE)
        //                                {
        //                                    lsRegMenuPadre.ListMENUMENU = (from p in lsItemsMenHijo where p.COD_SMODULOS == lsRegMenuPadre.COD_SMODULOS && p.COD_SMGRUPO == lsRegMenuPadre.COD_SMGRUPO && p.COD_SECUENCIAL_PADRE == lsRegMenuPadre.COD_SECUENCIAL_PADRE select p).ToList<CEntidad>();


        //                                }


        //                            }
        //                        }
        //                        oCampos.ListUCDMMENU = lsDetMenu;
        //                    }
        //                    lsCEntidad.Add(oCampos);
        //                }
        //            }
        //        }
        //        return lsCEntidad;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// Metodo para modificar la contraseña para usuarios de la base de datos del SITd desde el SIGO (para usuarios de base de datos principal)
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String RegUpdatePasswordSITD(OracleConnection cn, CEntidad oCEntidad)
        {
            //SqlTransaction tr = null;
            String OUTPUTPARAM01 = "";
            try
            {
                //tr = cn.BeginTransaction();
                //Grabando Cabecera
                //using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spUSUARIO_MANTENIMIENTO", oCEntidad))
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spUSUARIO_MANTENIMIENTO", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    //if (OUTPUTPARAM01 == "0")
                    //{
                    //    //tr.Rollback();
                    //    //tr = null;
                    //    throw new Exception("¡La contraseña ingresada es incorrecta!");
                    //}
                    //else if (OUTPUTPARAM01 == "1")
                    //{
                    //    //tr.Commit();
                    //}
                }
                //                
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                //if (tr != null)
                //{
                //    tr.Rollback();
                //}
                throw ex;
            }
        }
        //public String RegInstanciaSIGO(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    String OUTPUTPARAM01 = "";
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        //Grabando Cabecera
        //        using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "HERR.spINSTANCIASIGO", oCEntidad))
        //        {
        //            cmd.ExecuteNonQuery();
        //            OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
        //            if (OUTPUTPARAM01 == "0")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("No se encuentra en una instancia válida del SIGO");
        //            }
        //        }
        //        //
        //        tr.Commit();
        //        return OUTPUTPARAM01;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (tr != null)
        //        {
        //            tr.Rollback();
        //        }
        //        throw ex;
        //    }
        //}
        public String devuelvetipoAutenticacion(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "HERR_OSINFOR_ERP_MIGRACION.spAUTENTICACIONSIGO", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "0")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El tipo de autenticación configurado no es válido");
                    }
                }
                //
                tr.Commit();
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                }
                throw ex;
            }
        }

        //public String devuelvetipoAutenticacion(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    String OUTPUTPARAM01 = "";
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        //Grabando Cabecera
        //        using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "HERR.spAUTENTICACIONSIGO", oCEntidad))
        //        {
        //            cmd.ExecuteNonQuery();
        //            OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
        //            if (OUTPUTPARAM01 == "0")
        //            {
        //                tr.Rollback();
        //                tr = null;
        //                throw new Exception("El tipo de autenticación configurado no es válido");
        //            }
        //        }
        //        //
        //        tr.Commit();
        //        return OUTPUTPARAM01;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (tr != null)
        //        {
        //            tr.Rollback();
        //        }
        //        throw ex;
        //    }
        //}

        // LOGIN INTEGRADO
        //public List<CEntidad> RegLoginValidandoiNTEGRADO(SqlConnection cn, CEntidad oCEntidad, string version)
        //{
        //    string procedimiento = "";
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    try
        //    {

        //        CEntidad oCamposLU = new CEntidad();
        //        oCamposLU.USUARIO_LOGIN = oCEntidad.USUARIO_LOGIN;
        //        oCamposLU.COD_SMODULOS = oCEntidad.COD_SMODULOS;
        //        if (version == "v2")
        //        { procedimiento = "GENE.spUSUARIO_CUENTALoginMostrarIntegrado"; }
        //        else if (version == "v3")
        //        { procedimiento = "GENE.spUSUARIO_CUENTALoginMostrarIntegrado_v3"; }

        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, procedimiento, oCamposLU))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCampos = new CEntidad();
        //                //Datos de la Cuenta de Usuario
        //                if (dr.HasRows)
        //                {
        //                    dr.Read();
        //                    oCampos.COD_UCUENTA = dr.GetString(dr.GetOrdinal("COD_UCUENTA"));
        //                    oCampos.COD_PERSONA = dr.GetString(dr.GetOrdinal("COD_PERSONA"));
        //                    oCampos.COD_UGRUPO = dr.GetString(dr.GetOrdinal("COD_UGRUPO"));
        //                    oCampos.PERSONA = dr.GetString(dr.GetOrdinal("PERSONA"));
        //                    oCampos.UGRUPO = dr.GetString(dr.GetOrdinal("UGRUPO"));
        //                    oCampos.ESTADO_CONTRASENA_CAMBIAR = dr.GetBoolean(dr.GetOrdinal("ESTADO_CONTRASENA_CAMBIAR"));
        //                    oCampos.USUARIO_LOGIN = dr.GetString(dr.GetOrdinal("USUARIO_LOGIN"));
        //                }
        //                dr.NextResult();
        //                List<CEntidad> lsDetMenu = new List<CEntidad>();
        //                List<CEntidad> lsItemsGru = new List<CEntidad>();
        //                List<CEntidad> lsItemsMenPadre = new List<CEntidad>();
        //                List<CEntidad> lsItemsMenHijo = new List<CEntidad>();
        //                //Manus de Acceso
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("COD_SMODULOS");
        //                    int p2 = dr.GetOrdinal("COD_SMGRUPO");
        //                    int p3 = dr.GetOrdinal("MODULO");
        //                    int p4 = dr.GetOrdinal("GRUPO");
        //                    int p5 = dr.GetOrdinal("MENU_PADRE");
        //                    int p6 = dr.GetOrdinal("MENU_URL_PADRE");
        //                    int p7 = dr.GetOrdinal("MENU_HIJO");
        //                    int p8 = dr.GetOrdinal("COD_SECUENCIAL_PADRE");
        //                    int p9 = dr.GetOrdinal("COD_SECUENCIAL_HIJO");
        //                    int p10 = dr.GetOrdinal("MENU_URL_HIJO");
        //                    CEntidad oCEntidadDet;
        //                    String COD_SMODULOS = "";
        //                    String COD_SMGRUPO = "";
        //                    String COD_MENUPADRE = "";
        //                    while (dr.Read())
        //                    {
        //                        //Cargando Modulos al Listado General DetMenu
        //                        if (COD_SMODULOS != dr.GetString(p1))
        //                        {
        //                            oCEntidadDet = new CEntidad();
        //                            oCEntidadDet.COD_SMODULOS = dr.GetString(p1);
        //                            oCEntidadDet.MODULO = dr.GetString(p3);
        //                            lsDetMenu.Add(oCEntidadDet);
        //                            COD_SMODULOS = dr.GetString(p1);
        //                        }
        //                        //Cargando Grupos
        //                        if (COD_SMGRUPO != String.Format("{0}{1}", dr.GetString(p1), dr.GetString(p2)))
        //                        {
        //                            oCEntidadDet = new CEntidad();
        //                            oCEntidadDet.COD_SMODULOS = dr.GetString(p1);
        //                            oCEntidadDet.COD_SMGRUPO = dr.GetString(p2);
        //                            oCEntidadDet.GRUPO = dr.GetString(p4);
        //                            lsItemsGru.Add(oCEntidadDet);
        //                            COD_SMGRUPO = String.Format("{0}{1}", dr.GetString(p1), dr.GetString(p2));
        //                        }
        //                        //Cargando Menu Padres
        //                        if (COD_MENUPADRE != String.Format("{0}{1}{2}", dr.GetString(p1), dr.GetString(p2), dr.GetInt32(p8).ToString()))
        //                        {
        //                            oCEntidadDet = new CEntidad();
        //                            oCEntidadDet.COD_SMODULOS = dr.GetString(p1);
        //                            oCEntidadDet.COD_SMGRUPO = dr.GetString(p2);
        //                            oCEntidadDet.COD_SECUENCIAL_PADRE = dr.GetInt32(p8);
        //                            oCEntidadDet.MENU_PADRE = dr.GetString(p5);

        //                            lsItemsMenPadre.Add(oCEntidadDet);
        //                            COD_MENUPADRE = String.Format("{0}{1}{2}", dr.GetString(p1), dr.GetString(p2), dr.GetInt32(p8).ToString());
        //                        }
        //                        oCEntidadDet = new CEntidad();
        //                        oCEntidadDet.COD_SMODULOS = dr.GetString(p1);
        //                        oCEntidadDet.COD_SMGRUPO = dr.GetString(p2);
        //                        oCEntidadDet.COD_SECUENCIAL_PADRE = dr.GetInt32(p8);
        //                        oCEntidadDet.COD_SECUENCIAL_HIJO = dr.GetInt32(p9);
        //                        oCEntidadDet.MODULO = dr.GetString(p3);
        //                        oCEntidadDet.GRUPO = dr.GetString(p4);
        //                        oCEntidadDet.MENU_PADRE = dr.GetString(p5);
        //                        oCEntidadDet.MENU_HIJO = dr.GetString(p7);
        //                        oCEntidadDet.MENU_URL_PADRE = dr.GetString(p6);
        //                        oCEntidadDet.MENU_URL_HIJO = dr.GetString(p10);
        //                        if (version == "v3")
        //                        {
        //                            oCEntidadDet.MENU_URL_HIJO_MVC = dr.GetString(dr.GetOrdinal("MENU_URL_HIJO_MVC"));
        //                            oCEntidadDet.MENU_URL_PADRE_MVC = dr.GetString(dr.GetOrdinal("MENU_URL_PADRE_MVC"));
        //                        }
        //                        lsItemsMenHijo.Add(oCEntidadDet);
        //                    }
        //                    foreach (var lsRegMod in lsDetMenu)
        //                    {
        //                        //lsDetMenu[IndexMod].ListMENUGRUPO = lsItemsGru.Where(person => person.COD_SMODULOS == lsRegMod.COD_SMODULOS).ToList<CEntidad>();
        //                        lsRegMod.ListMENUGRUPO = (from p in lsItemsGru where p.COD_SMODULOS == lsRegMod.COD_SMODULOS select p).ToList<CEntidad>();
        //                        //
        //                        foreach (var lsRegGrupo in lsRegMod.ListMENUGRUPO)
        //                        {
        //                            lsRegGrupo.ListMENUPADRE = (from p in lsItemsMenPadre where p.COD_SMODULOS == lsRegGrupo.COD_SMODULOS && p.COD_SMGRUPO == lsRegGrupo.COD_SMGRUPO select p).ToList<CEntidad>();

        //                            foreach (var lsRegMenuPadre in lsRegGrupo.ListMENUPADRE)
        //                            {
        //                                lsRegMenuPadre.ListMENUMENU = (from p in lsItemsMenHijo where p.COD_SMODULOS == lsRegMenuPadre.COD_SMODULOS && p.COD_SMGRUPO == lsRegMenuPadre.COD_SMGRUPO && p.COD_SECUENCIAL_PADRE == lsRegMenuPadre.COD_SECUENCIAL_PADRE select p).ToList<CEntidad>();


        //                            }


        //                        }
        //                    }
        //                    oCampos.ListUCDMMENU = lsDetMenu;
        //                }
        //                lsCEntidad.Add(oCampos);
        //            }
        //        }
        //        return lsCEntidad;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //Obtiene los accesos por perfil y accesos por usuarios de una cuenta
        public List<CEntidad> RegLoginValidandoV3(OracleConnection cn, CEntidad oCEntidad, string version)
        {
            string procedimiento = "";
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                CEntidad oCamposLU = new CEntidad();
                oCamposLU.USUARIO_LOGIN = oCEntidad.USUARIO_LOGIN;
                oCamposLU.USUARIO_CONTRASENA = oCEntidad.USUARIO_CONTRASENA;
                oCamposLU.COD_SMODULOS = oCEntidad.COD_SMODULOS;
                oCamposLU.OUTPUTPARAM01 = oCEntidad.OUTPUTPARAM01;
                oCamposLU.OUTPUTPARAM02 = oCEntidad.OUTPUTPARAM02;
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, null, "GENE_OSINFOR_ERP_MIGRACION.spUSUARIO_CUENTALoginVerifica", oCamposLU))
                {
                    cmd.ExecuteNonQuery();
                    Int32 OUTPUTPARAM01 = Convert.ToInt32(cmd.Parameters["OUTPUTPARAM01"].Value);
                    String COD_UCUENTA = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                    if (OUTPUTPARAM01 == 1)
                    {
                        throw new Exception("1|Usuario o contraseña erroneo");
                    }
                    else if (OUTPUTPARAM01 == 2)
                    {
                        throw new Exception("2|Cuenta de Usuario Inactivo");
                    }
                    else if (OUTPUTPARAM01 == 4)
                    {
                        throw new Exception("2|(0) Modulos Asignados");
                    }
                    else if (OUTPUTPARAM01 == 5)
                    {
                        throw new Exception("5| La cuenta ha caducado, no es posible ingresar al sistema.");
                    }
                    //CEntidad oCamposLU = new CEntidad();
                    oCamposLU = new CEntidad();
                    oCamposLU.COD_UCUENTA = COD_UCUENTA;
                    oCamposLU.COD_SMODULOS = oCEntidad.COD_SMODULOS;
                    if (version == "v2")
                    { procedimiento = "GENE_OSINFOR_ERP_MIGRACION.uspUsuario_Cuenta_Menus_v2"; }
                    else if (version == "v3")
                    { procedimiento = "GENE_OSINFOR_ERP_MIGRACION.USPUSUARIO_CUENTA_MENUS_V4"; }
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, procedimiento, oCamposLU))
                    {
                        if (dr != null)
                        {
                            CEntidad oCampos = new CEntidad();
                            //Datos de la Cuenta de Usuario
                            if (dr.HasRows)
                            {
                                dr.Read();
                                oCampos.COD_UCUENTA = dr.GetValueString(dr.GetOrdinal("COD_UCUENTA"));
                                oCampos.COD_PERSONA = dr.GetValueString(dr.GetOrdinal("COD_PERSONA"));
                                oCampos.COD_UGRUPO = dr.GetValueString(dr.GetOrdinal("COD_UGRUPO"));
                                oCampos.PERSONA = dr.GetValueString(dr.GetOrdinal("PERSONA"));
                                oCampos.UGRUPO = dr.GetValueString(dr.GetOrdinal("UGRUPO"));
                                oCampos.ESTADO_CONTRASENA_CAMBIAR = dr.GetBoolean(dr.GetOrdinal("ESTADO_CONTRASENA_CAMBIAR"));
                                oCampos.USUARIO_LOGIN = dr.GetValueString(dr.GetOrdinal("USUARIO_LOGIN"));
                                oCampos.COD_SPERFILS = dr.GetValueString(dr.GetOrdinal("COD_SPERFILS"));
                            }
                            dr.NextResult();
                            List<CEntidad> lsDetMenu = new List<CEntidad>();
                            List<CEntidad> lsItemsGru = new List<CEntidad>();
                            List<CEntidad> lsItemsMenPadre = new List<CEntidad>();
                            List<CEntidad> lsItemsMenHijo = new List<CEntidad>();
                            //Manus de Acceso
                            if (dr.HasRows)
                            {
                                int p1 = dr.GetOrdinal("COD_SMODULOS");
                                int p2 = dr.GetOrdinal("COD_SMGRUPO");
                                int p3 = dr.GetOrdinal("MODULO");
                                int p4 = dr.GetOrdinal("GRUPO");
                                int p5 = dr.GetOrdinal("MENU_PADRE");
                                int p6 = dr.GetOrdinal("MENU_URL_PADRE");
                                int p7 = dr.GetOrdinal("MENU_HIJO");
                                int p8 = dr.GetOrdinal("COD_SECUENCIAL_PADRE");
                                int p9 = dr.GetOrdinal("COD_SECUENCIAL_HIJO");
                                int p10 = dr.GetOrdinal("MENU_URL_HIJO");
                                int p11 = dr.GetOrdinal("NCODROL");
                                int p12 = dr.GetOrdinal("VDESCRIPCION");
                                int p13 = dr.GetOrdinal("VALIAS");
                                CEntidad oCEntidadDet;
                                String COD_SMODULOS = "";
                                String COD_SMGRUPO = "";
                                String COD_MENUPADRE = "";
                                while (dr.Read())
                                {
                                    //Cargando Modulos al Listado General DetMenu
                                    if (COD_SMODULOS != dr.GetValueString(p1))
                                    {
                                        oCEntidadDet = new CEntidad();
                                        oCEntidadDet.COD_SMODULOS = dr.GetValueString(p1).Trim();
                                        oCEntidadDet.MODULO = dr.GetValueString(p3).Trim();
                                        lsDetMenu.Add(oCEntidadDet);
                                        COD_SMODULOS = dr.GetValueString(p1).Trim();
                                    }
                                    //Cargando Grupos
                                    string ss = String.Format("{0}{1}", dr.GetValueString(p1).Trim(), dr.GetValueString(p2).Trim());

                                    if (COD_SMGRUPO != String.Format("{0}{1}", dr.GetValueString(p1).Trim(), dr.GetValueString(p2).Trim()))
                                    {
                                        oCEntidadDet = new CEntidad();
                                        oCEntidadDet.COD_SMODULOS = dr.GetValueString(p1).Trim();
                                        oCEntidadDet.COD_SMGRUPO = dr.GetValueString(p2).Trim();
                                        oCEntidadDet.GRUPO = dr.GetValueString(p4).Trim();
                                        lsItemsGru.Add(oCEntidadDet);
                                        COD_SMGRUPO = String.Format("{0}{1}", dr.GetValueString(p1).Trim(), dr.GetValueString(p2).Trim());
                                    }
                                    //Cargando Menu Padres
                                    if (COD_MENUPADRE != String.Format("{0}{1}{2}", dr.GetValueString(p1).Trim(), dr.GetValueString(p2).Trim(), dr.GetInt32(p8).ToString().Trim()))
                                    {
                                        oCEntidadDet = new CEntidad();
                                        oCEntidadDet.COD_SMODULOS = dr.GetValueString(p1).Trim();
                                        oCEntidadDet.COD_SMGRUPO = dr.GetValueString(p2).Trim();
                                        oCEntidadDet.COD_SECUENCIAL_PADRE = dr.GetInt32(p8);
                                        oCEntidadDet.MENU_PADRE = dr.GetValueString(p5).Trim();

                                        lsItemsMenPadre.Add(oCEntidadDet);
                                        COD_MENUPADRE = String.Format("{0}{1}{2}", dr.GetValueString(p1).Trim(), dr.GetValueString(p2).Trim(), dr.GetInt32(p8).ToString().Trim());
                                    }
                                    oCEntidadDet = new CEntidad();
                                    oCEntidadDet.COD_SMODULOS = dr.GetValueString(p1).Trim();
                                    oCEntidadDet.COD_SMGRUPO = dr.GetValueString(p2).Trim();
                                    oCEntidadDet.COD_SECUENCIAL_PADRE = dr.GetInt32(p8);
                                    oCEntidadDet.COD_SECUENCIAL_HIJO = dr.GetInt32(p9);
                                    oCEntidadDet.MODULO = dr.GetValueString(p3).Trim();
                                    oCEntidadDet.GRUPO = dr.GetValueString(p4).Trim();
                                    oCEntidadDet.MENU_PADRE = dr.GetValueString(p5).Trim();
                                    oCEntidadDet.MENU_HIJO = dr.GetValueString(p7).Trim();
                                    oCEntidadDet.MENU_URL_PADRE = dr.GetValueString(p6).Trim();
                                    oCEntidadDet.MENU_URL_HIJO = dr.GetValueString(p10).Trim();
                                    oCEntidadDet.NCODROL = dr.GetInt32(p11);
                                    oCEntidadDet.VALIASROL = dr.GetValueString(p13).Trim();
                                    oCEntidadDet.VDESCRIPCIONROL = dr.GetValueString(p12).Trim();
                                    if (version == "v3")
                                    {
                                        oCEntidadDet.MENU_URL_HIJO_MVC = dr.GetValueString(dr.GetOrdinal("MENU_URL_HIJO_MVC")).Trim();
                                        oCEntidadDet.MENU_URL_PADRE_MVC = dr.GetValueString(dr.GetOrdinal("MENU_URL_PADRE_MVC")).Trim();
                                    }
                                    lsItemsMenHijo.Add(oCEntidadDet);
                                }
                                foreach (var lsRegMod in lsDetMenu)
                                {
                                    //lsDetMenu[IndexMod].ListMENUGRUPO = lsItemsGru.Where(person => person.COD_SMODULOS == lsRegMod.COD_SMODULOS).ToList<CEntidad>();
                                    lsRegMod.ListMENUGRUPO = (from p in lsItemsGru where p.COD_SMODULOS == lsRegMod.COD_SMODULOS select p).ToList<CEntidad>();
                                    //
                                    foreach (var lsRegGrupo in lsRegMod.ListMENUGRUPO)
                                    {
                                        lsRegGrupo.ListMENUPADRE = (from p in lsItemsMenPadre where p.COD_SMODULOS == lsRegGrupo.COD_SMODULOS && p.COD_SMGRUPO == lsRegGrupo.COD_SMGRUPO select p).ToList<CEntidad>();

                                        foreach (var lsRegMenuPadre in lsRegGrupo.ListMENUPADRE)
                                        {
                                            lsRegMenuPadre.ListMENUMENU = (from p in lsItemsMenHijo where p.COD_SMODULOS == lsRegMenuPadre.COD_SMODULOS && p.COD_SMGRUPO == lsRegMenuPadre.COD_SMGRUPO && p.COD_SECUENCIAL_PADRE == lsRegMenuPadre.COD_SECUENCIAL_PADRE select p).ToList<CEntidad>();


                                        }


                                    }
                                }
                                oCampos.ListUCDMMENU = lsDetMenu;
                            }
                            lsCEntidad.Add(oCampos);
                        }
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LISTANDO LOS MENUS PERFIL
        public List<CEntidad> RegLoginValidandoIntegradoV3(OracleConnection cn, CEntidad oCEntidad, string version)
        {
            string procedimiento = "";
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {

                CEntidad oCamposLU = new CEntidad();
                oCamposLU.USUARIO_LOGIN = oCEntidad.USUARIO_LOGIN;
                oCamposLU.COD_SMODULOS = oCEntidad.COD_SMODULOS;
                oCamposLU.COD_SPERFIL = oCEntidad.COD_SPERFIL;
                if (version == "v2")
                { procedimiento = "GENE_OSINFOR_ERP_MIGRACION.spUSUARIO_CUENTALoginMostrarIntegrado"; }
                else if (version == "v3")
                { procedimiento = "GENE_OSINFOR_ERP_MIGRACION.uspUsuario_Cuenta_Menus_v4"; }

                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, procedimiento, oCamposLU))
                {
                    if (dr != null)
                    {
                        CEntidad oCampos = new CEntidad();
                        //Datos de la Cuenta de Usuario
                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.COD_UCUENTA = dr.GetString(dr.GetOrdinal("COD_UCUENTA"));
                            oCampos.COD_PERSONA = dr.GetString(dr.GetOrdinal("COD_PERSONA"));
                            oCampos.COD_UGRUPO = dr.GetString(dr.GetOrdinal("COD_UGRUPO"));
                            oCampos.PERSONA = dr.GetString(dr.GetOrdinal("PERSONA"));
                            oCampos.UGRUPO = dr.GetString(dr.GetOrdinal("UGRUPO"));
                            oCampos.ESTADO_CONTRASENA_CAMBIAR = dr.GetBoolean(dr.GetOrdinal("ESTADO_CONTRASENA_CAMBIAR"));
                            oCampos.USUARIO_LOGIN = dr.GetString(dr.GetOrdinal("USUARIO_LOGIN"));
                            oCampos.COD_SPERFILS = dr.GetString(dr.GetOrdinal("COD_SPERFILS"));
                        }
                        dr.NextResult();
                        List<CEntidad> lsDetMenu = new List<CEntidad>();
                        List<CEntidad> lsItemsGru = new List<CEntidad>();
                        List<CEntidad> lsItemsMenPadre = new List<CEntidad>();
                        List<CEntidad> lsItemsMenHijo = new List<CEntidad>();
                        //Manus de Acceso
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_SMODULOS");
                            int p2 = dr.GetOrdinal("COD_SMGRUPO");
                            int p3 = dr.GetOrdinal("MODULO");
                            int p4 = dr.GetOrdinal("GRUPO");
                            int p5 = dr.GetOrdinal("MENU_PADRE");
                            int p6 = dr.GetOrdinal("MENU_URL_PADRE");
                            int p7 = dr.GetOrdinal("MENU_HIJO");
                            int p8 = dr.GetOrdinal("COD_SECUENCIAL_PADRE");
                            int p9 = dr.GetOrdinal("COD_SECUENCIAL_HIJO");
                            int p10 = dr.GetOrdinal("MENU_URL_HIJO");
                            int p11 = dr.GetOrdinal("NCODROL");
                            int p12 = dr.GetOrdinal("VDESCRIPCION");
                            int p13 = dr.GetOrdinal("VALIAS");
                            CEntidad oCEntidadDet;
                            String COD_SMODULOS = "";
                            String COD_SMGRUPO = "";
                            String COD_MENUPADRE = "";
                            while (dr.Read())
                            {
                                //Cargando Modulos al Listado General DetMenu
                                if (COD_SMODULOS != dr.GetValueString(p1))
                                {
                                    oCEntidadDet = new CEntidad();
                                    oCEntidadDet.COD_SMODULOS = dr.GetValueString(p1).Trim();
                                    oCEntidadDet.MODULO = dr.GetValueString(p3).Trim();
                                    lsDetMenu.Add(oCEntidadDet);
                                    COD_SMODULOS = dr.GetValueString(p1).Trim();
                                }
                                //Cargando Grupos
                                string ss = String.Format("{0}{1}", dr.GetValueString(p1).Trim(), dr.GetValueString(p2).Trim());

                                if (COD_SMGRUPO != String.Format("{0}{1}", dr.GetValueString(p1).Trim(), dr.GetValueString(p2).Trim()))
                                {
                                    oCEntidadDet = new CEntidad();
                                    oCEntidadDet.COD_SMODULOS = dr.GetValueString(p1).Trim();
                                    oCEntidadDet.COD_SMGRUPO = dr.GetValueString(p2).Trim();
                                    oCEntidadDet.GRUPO = dr.GetValueString(p4).Trim();
                                    lsItemsGru.Add(oCEntidadDet);
                                    COD_SMGRUPO = String.Format("{0}{1}", dr.GetValueString(p1).Trim(), dr.GetValueString(p2).Trim());
                                }
                                //Cargando Menu Padres
                                if (COD_MENUPADRE != String.Format("{0}{1}{2}", dr.GetValueString(p1).Trim(), dr.GetValueString(p2).Trim(), dr.GetInt32(p8).ToString().Trim()))
                                {
                                    oCEntidadDet = new CEntidad();
                                    oCEntidadDet.COD_SMODULOS = dr.GetValueString(p1).Trim();
                                    oCEntidadDet.COD_SMGRUPO = dr.GetValueString(p2).Trim();
                                    oCEntidadDet.COD_SECUENCIAL_PADRE = dr.GetInt32(p8);
                                    oCEntidadDet.MENU_PADRE = dr.GetValueString(p5).Trim();
                                    lsItemsMenPadre.Add(oCEntidadDet);
                                    COD_MENUPADRE = String.Format("{0}{1}{2}", dr.GetValueString(p1).Trim(), dr.GetValueString(p2).Trim(), dr.GetInt32(p8).ToString().Trim());
                                }
                                oCEntidadDet = new CEntidad();
                                oCEntidadDet.COD_SMODULOS = dr.GetValueString(p1).Trim();
                                oCEntidadDet.COD_SMGRUPO = dr.GetValueString(p2).Trim();
                                oCEntidadDet.COD_SECUENCIAL_PADRE = dr.GetInt32(p8);
                                oCEntidadDet.COD_SECUENCIAL_HIJO = dr.GetInt32(p9);
                                oCEntidadDet.MODULO = dr.GetValueString(p3).Trim();
                                oCEntidadDet.GRUPO = dr.GetValueString(p4).Trim();
                                oCEntidadDet.MENU_PADRE = dr.GetValueString(p5).Trim();
                                oCEntidadDet.MENU_HIJO = dr.GetValueString(p7).Trim();
                                oCEntidadDet.MENU_URL_PADRE = dr.GetValueString(p6).Trim();
                                oCEntidadDet.MENU_URL_HIJO = dr.GetValueString(p10).Trim();
                                oCEntidadDet.NCODROL = dr.GetInt32(p11);
                                oCEntidadDet.VALIASROL = dr.GetValueString(p13).Trim();
                                oCEntidadDet.VDESCRIPCIONROL = dr.GetValueString(p12).Trim();
                                if (version == "v3")
                                {
                                    oCEntidadDet.MENU_URL_HIJO_MVC = dr.GetValueString(dr.GetOrdinal("MENU_URL_HIJO_MVC")).Trim();
                                    oCEntidadDet.MENU_URL_PADRE_MVC = dr.GetValueString(dr.GetOrdinal("MENU_URL_PADRE_MVC")).Trim();
                                }
                                lsItemsMenHijo.Add(oCEntidadDet);
                            }
                            foreach (var lsRegMod in lsDetMenu)
                            {
                                //lsDetMenu[IndexMod].ListMENUGRUPO = lsItemsGru.Where(person => person.COD_SMODULOS == lsRegMod.COD_SMODULOS).ToList<CEntidad>();
                                lsRegMod.ListMENUGRUPO = (from p in lsItemsGru where p.COD_SMODULOS == lsRegMod.COD_SMODULOS select p).ToList<CEntidad>();
                                //
                                foreach (var lsRegGrupo in lsRegMod.ListMENUGRUPO)
                                {
                                    lsRegGrupo.ListMENUPADRE = (from p in lsItemsMenPadre where p.COD_SMODULOS == lsRegGrupo.COD_SMODULOS && p.COD_SMGRUPO == lsRegGrupo.COD_SMGRUPO select p).ToList<CEntidad>();

                                    foreach (var lsRegMenuPadre in lsRegGrupo.ListMENUPADRE)
                                    {
                                        lsRegMenuPadre.ListMENUMENU = (from p in lsItemsMenHijo where p.COD_SMODULOS == lsRegMenuPadre.COD_SMODULOS && p.COD_SMGRUPO == lsRegMenuPadre.COD_SMGRUPO && p.COD_SECUENCIAL_PADRE == lsRegMenuPadre.COD_SECUENCIAL_PADRE select p).ToList<CEntidad>();


                                    }


                                }
                            }
                            oCampos.ListUCDMMENU = lsDetMenu;
                        }
                        ////Manus de Acceso
                        //if (dr.HasRows)
                        //{
                        //    int p1 = dr.GetOrdinal("COD_SMODULOS");
                        //    int p2 = dr.GetOrdinal("COD_SMGRUPO");
                        //    int p3 = dr.GetOrdinal("MODULO");
                        //    int p4 = dr.GetOrdinal("GRUPO");
                        //    int p5 = dr.GetOrdinal("MENU_PADRE");
                        //    int p6 = dr.GetOrdinal("MENU_URL_PADRE");
                        //    int p7 = dr.GetOrdinal("MENU_HIJO");
                        //    int p8 = dr.GetOrdinal("COD_SECUENCIAL_PADRE");
                        //    int p9 = dr.GetOrdinal("COD_SECUENCIAL_HIJO");
                        //    int p10 = dr.GetOrdinal("MENU_URL_HIJO");
                        //    CEntidad oCEntidadDet;
                        //    String COD_SMODULOS = "";
                        //    String COD_SMGRUPO = "";
                        //    String COD_MENUPADRE = "";
                        //    while (dr.Read())
                        //    {
                        //        //Cargando Modulos al Listado General DetMenu
                        //        if (COD_SMODULOS != dr.GetString(p1).Trim())
                        //        {
                        //            oCEntidadDet = new CEntidad();
                        //            oCEntidadDet.COD_SMODULOS = dr.GetString(p1);
                        //            oCEntidadDet.MODULO = dr.GetString(p3);
                        //            lsDetMenu.Add(oCEntidadDet);
                        //            COD_SMODULOS = dr.GetString(p1);
                        //        }
                        //        //Cargando Grupos
                        //        if (COD_SMGRUPO != String.Format("{0}{1}", dr.GetString(p1).Trim(), dr.GetString(p2).Trim()))
                        //        {
                        //            oCEntidadDet = new CEntidad();
                        //            oCEntidadDet.COD_SMODULOS = dr.GetString(p1).Trim();
                        //            oCEntidadDet.COD_SMGRUPO = dr.GetString(p2).Trim();
                        //            oCEntidadDet.GRUPO = dr.GetString(p4).Trim();
                        //            lsItemsGru.Add(oCEntidadDet);
                        //            COD_SMGRUPO = String.Format("{0}{1}", dr.GetString(p1).Trim(), dr.GetString(p2).Trim());
                        //        }
                        //        //Cargando Menu Padres
                        //        if (COD_MENUPADRE != String.Format("{0}{1}{2}", dr.GetString(p1).Trim(), dr.GetString(p2).Trim(), dr.GetInt32(p8).ToString().Trim()))
                        //        {
                        //            oCEntidadDet = new CEntidad();
                        //            oCEntidadDet.COD_SMODULOS = dr.GetString(p1).Trim();
                        //            oCEntidadDet.COD_SMGRUPO = dr.GetString(p2).Trim();
                        //            oCEntidadDet.COD_SECUENCIAL_PADRE = dr.GetInt32(p8);
                        //            oCEntidadDet.MENU_PADRE = dr.GetString(p5).Trim();

                        //            lsItemsMenPadre.Add(oCEntidadDet);
                        //            COD_MENUPADRE = String.Format("{0}{1}{2}", dr.GetString(p1).Trim(), dr.GetString(p2).Trim(), dr.GetInt32(p8).ToString().Trim());
                        //        }
                        //        oCEntidadDet = new CEntidad();
                        //        oCEntidadDet.COD_SMODULOS = dr.GetString(p1).Trim();
                        //        oCEntidadDet.COD_SMGRUPO = dr.GetString(p2).Trim();
                        //        oCEntidadDet.COD_SECUENCIAL_PADRE = dr.GetInt32(p8);
                        //        oCEntidadDet.COD_SECUENCIAL_HIJO = dr.GetInt32(p9);
                        //        oCEntidadDet.MODULO = dr.GetString(p3).Trim();
                        //        oCEntidadDet.GRUPO = dr.GetString(p4).Trim();
                        //        oCEntidadDet.MENU_PADRE = dr.GetString(p5).Trim();
                        //        oCEntidadDet.MENU_HIJO = dr.GetString(p7).Trim();
                        //        oCEntidadDet.MENU_URL_PADRE = dr.GetString(p6).Trim();
                        //        oCEntidadDet.MENU_URL_HIJO = dr.GetString(p10).Trim();
                        //        if (version == "v3")
                        //        {
                        //            oCEntidadDet.MENU_URL_HIJO_MVC = dr.GetString(dr.GetOrdinal("MENU_URL_HIJO_MVC")).Trim();
                        //            oCEntidadDet.MENU_URL_PADRE_MVC = dr.GetString(dr.GetOrdinal("MENU_URL_PADRE_MVC")).Trim();
                        //        }
                        //        lsItemsMenHijo.Add(oCEntidadDet);
                        //    }
                        //    foreach (var lsRegMod in lsDetMenu)
                        //    {
                        //        //lsDetMenu[IndexMod].ListMENUGRUPO = lsItemsGru.Where(person => person.COD_SMODULOS == lsRegMod.COD_SMODULOS).ToList<CEntidad>();
                        //        lsRegMod.ListMENUGRUPO = (from p in lsItemsGru where p.COD_SMODULOS == lsRegMod.COD_SMODULOS select p).ToList<CEntidad>();
                        //        //
                        //        foreach (var lsRegGrupo in lsRegMod.ListMENUGRUPO)
                        //        {
                        //            lsRegGrupo.ListMENUPADRE = (from p in lsItemsMenPadre where p.COD_SMODULOS == lsRegGrupo.COD_SMODULOS && p.COD_SMGRUPO == lsRegGrupo.COD_SMGRUPO select p).ToList<CEntidad>();

                        //            foreach (var lsRegMenuPadre in lsRegGrupo.ListMENUPADRE)
                        //            {
                        //                lsRegMenuPadre.ListMENUMENU = (from p in lsItemsMenHijo where p.COD_SMODULOS == lsRegMenuPadre.COD_SMODULOS && p.COD_SMGRUPO == lsRegMenuPadre.COD_SMGRUPO && p.COD_SECUENCIAL_PADRE == lsRegMenuPadre.COD_SECUENCIAL_PADRE select p).ToList<CEntidad>();


                        //            }


                        //        }
                        //    }
                        //    oCampos.ListUCDMMENU = lsDetMenu;
                        //}
                        lsCEntidad.Add(oCampos);
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Auditoría
        public string RegAuditoriaUsuario(OracleConnection cn, CapaEntidad.GENE.Ent_AUDITORIA aoCEntidad)
        {
            OracleTransaction tr = null;

            try
            {
                tr = cn.BeginTransaction();
                if (aoCEntidad != null)
                {
                    CapaEntidad.GENE.Ent_AUDITORIA paramsAudit = new CapaEntidad.GENE.Ent_AUDITORIA()
                    {
                        codCuentaUsuario = aoCEntidad.codCuentaUsuario,
                        app = aoCEntidad.app,
                        ipCliente = aoCEntidad.ipCliente
                    };
                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spAUDITORIAGrabar", paramsAudit);
                }
                tr.Commit();
                return "Ok";
            }
            catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                }
                throw ex;
            }
        }


    }
}
