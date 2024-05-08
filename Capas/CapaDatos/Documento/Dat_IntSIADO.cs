using CapaEntidad.DOC;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntIntSIADO = CapaEntidad.DOC.Ent_IntSIADO;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    /// <summary>
    /// 24/08/2018  EPB: Se comentan los procedimientos de incersión y borrado porque esas tareas se realizan directamente desde el SIADO
    /// </summary>
    public class Dat_IntSIADO
    {
        private SQL oGDataSQL = new SQL();

        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// Devuelve los archivos en el SIADO relacionados segun el subtipo de titulo documental (SIADO_TIT_DOCUMENTAL)
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntIntSIADO RegMostrarListaSIADO(OracleConnection cn, CEntIntSIADO oCEntidad)
        {
            CEntIntSIADO oCampos = new CEntIntSIADO();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "IntSIADO.spMostrarListaFicheros", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListFiles = new List<CEntIntSIADO>();
                        oCampos.ListEliFiles = new List<CEntIntSIADO>();
                        CEntIntSIADO oCamposDet;
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("DETINV_CODDOC");
                            int pt2 = dr.GetOrdinal("DETINV_DESCRIPCION");
                            int pt8 = dr.GetOrdinal("ORIGEN");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntIntSIADO();
                                oCamposDet.DETINV_CODDOC = dr.GetString(pt1);
                                oCamposDet.DETINV_DESCRIPCION = dr.GetString(pt2);
                                oCamposDet.ORIGEN = dr.GetString(pt8);
                                oCampos.ListFiles.Add(oCamposDet);
                            }
                        }
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntIntSIADO> listarExpedientesSIADO(OracleConnection cn, CEntIntSIADO oCEntidad)
        {
            CEntIntSIADO oCampos = new CEntIntSIADO();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListExpedientes = new List<CEntIntSIADO>();
                        CEntIntSIADO oCamposDet;
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntIntSIADO();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oCampos.ListExpedientes.Add(oCamposDet);
                            }
                        }
                    }
                }
                return oCampos.ListExpedientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Registra los ficheros cargados para el SIADO, se considera solo una transferencia por TITULO HABILITANTE
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public String RegistrarFicheroSIADO(OracleConnection cn, CEntIntSIADO oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    String OUTPUTPARAM01 = "";
        //    String OUTPUTPARAM02 = "";
        //    String OUTPUTPARAM03 = "";
        //    String OUTPUTPARAM04 = "";
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "IntSIADO.spRegistrarFichero", oCEntidad))
        //            {
        //                cmd.ExecuteNonQuery();
        //                OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
        //                OUTPUTPARAM02 = (String)cmd.Parameters["@OUTPUTPARAM02"].Value;
        //                OUTPUTPARAM03 = (String)cmd.Parameters["@OUTPUTPARAM03"].Value;
        //                OUTPUTPARAM04 = (String)cmd.Parameters["@OUTPUTPARAM04"].Value;
        //            }   
        //        tr.Commit();
        //        return OUTPUTPARAM01 + '|' + OUTPUTPARAM02 + '|' + OUTPUTPARAM03 + '|' + OUTPUTPARAM04;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public String ReplicarFicheroSIGO(OracleConnection cn, CEntIntSIADO oCEntidad)
        //{
        //    SqlTransaction tr = null;
        //    String OUTPUTPARAM01 = "";
        //    String OUTPUTPARAM02 = "";
        //    String OUTPUTPARAM03 = "";
        //    String OUTPUTPARAM04 = "";
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "IntSIADO.spRegistrarFichero", oCEntidad))
        //        {
        //            cmd.ExecuteNonQuery();
        //            OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
        //            OUTPUTPARAM02 = (String)cmd.Parameters["@OUTPUTPARAM02"].Value;
        //            OUTPUTPARAM03 = (String)cmd.Parameters["@OUTPUTPARAM03"].Value;
        //            OUTPUTPARAM04 = (String)cmd.Parameters["@OUTPUTPARAM04"].Value;
        //        }
        //        tr.Commit();
        //        return OUTPUTPARAM01 + '|' + OUTPUTPARAM02 + '|' + OUTPUTPARAM03 + '|' + OUTPUTPARAM04;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// elimina el registro de los ficheros del SIADO, pero no cambia la numeracion consecutiva (se mantenine quedando un vacio por el fichero eliminado)
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public Int32 EliminarFicheroSIADO(OracleConnection cn, CEntIntSIADO oCEntidad)
        //{            try
        //    {
        //        Int32 RegNum = oGDataSQL.ManExecute(cn, null, "IntSIADO.spEliminarFichero", oCEntidad);
        //        if (RegNum == -1)
        //        {
        //            throw new Exception("No se logró realizar la operación");
        //        }
        //        return RegNum;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }           
        //}
        /// <summary>
        /// Actualiza el estado del campo flag_digital de 0 a 1, esto para asegurar que el fichero se cargo despues de registrarlo en la base de datos y confirmar esa carga.
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public Int32 ActualizarSubidaFicheroSIADO(OracleConnection cn, CEntIntSIADO oCEntidad)
        //{
        //    try
        //    {
        //        Int32 RegNum = oGDataSQL.ManExecute(cn, null, "IntSIADO.spActualizarCarga", oCEntidad);
        //        if (RegNum == -1)
        //        {
        //            throw new Exception("No se logró realizar la operación");
        //        }
        //        return RegNum;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #region "Sigo V3"
        public List<Ent_IntSIADO_V3> RegMostrarListaSIADO_V3(OracleConnection cn, CEntIntSIADO oCEntidad)
        {
            List<Ent_IntSIADO_V3> oCampos = new List<Ent_IntSIADO_V3>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "IntSIADO_OSINFOR_ERP_MIGRACION.spMostrarListaFicheros", oCEntidad))
                {
                    if (dr != null)
                    {
                        Ent_IntSIADO_V3 oCamposDet;
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("DETINV_CODDOC");
                            int pt2 = dr.GetOrdinal("DETINV_DESCRIPCION");
                            int pt8 = dr.GetOrdinal("ORIGEN");
                            while (dr.Read())
                            {
                                oCamposDet = new Ent_IntSIADO_V3();
                                oCamposDet.DETINV_CODDOC = dr.GetString(pt1);
                                oCamposDet.DETINV_DESCRIPCION = dr.GetString(pt2);
                                oCamposDet.ORIGEN = dr.GetString(pt8);
                                oCampos.Add(oCamposDet);
                            }
                        }
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ent_IntSIADO_V3> RegMostrarListarDocSIADO_V3(OracleConnection cn, CEntIntSIADO oCEntidad)
        {
            List<Ent_IntSIADO_V3> oCampos = new List<Ent_IntSIADO_V3>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "IntSIADO_OSINFOR_ERP_MIGRACION.spMostrarListaDocumentosSiado", oCEntidad))
                {
                    if (dr != null)
                    {
                        Ent_IntSIADO_V3 oCamposDet;
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("SUBTIPO");
                            int pt2 = dr.GetOrdinal("DETALLESUBTIPO");
                            int pt3 = dr.GetOrdinal("NUMERO");
                            int pt4 = dr.GetOrdinal("FECHA_DOCUMENTO");
                            int pt5 = dr.GetOrdinal("ORIGEN");
                            int pt6 = dr.GetOrdinal("CODDOC");
                            int pt7 = dr.GetOrdinal("DESCRIPCION");
                            int pt8 = dr.GetOrdinal("NUMEROTRAMITESITD");
                            while (dr.Read())
                            {
                                oCamposDet = new Ent_IntSIADO_V3();
                                oCamposDet.SUBTIPO = dr.GetString(pt1);
                                oCamposDet.DETALLESUBTIPO = dr.GetString(pt2);
                                oCamposDet.NUMERO = dr.GetString(pt3);
                                oCamposDet.FECHA_DOCUMENTO = dr.GetString(pt4);
                                oCamposDet.ORIGEN = dr.GetString(pt5);
                                oCamposDet.DETINV_CODDOC = dr.GetString(pt6);
                                oCamposDet.DETINV_DESCRIPCION = dr.GetString(pt7);
                                oCamposDet.NUMEROTRAMITESITD = dr.GetString(pt8);
                                oCampos.Add(oCamposDet);
                            }
                        }
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }

}
