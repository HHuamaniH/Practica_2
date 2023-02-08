using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_ISUSPENSION;
using CEntPersona = CapaEntidad.DOC.Ent_GENEPERSONA;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_ISUSPENSION
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostrarListaItem(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_SUSPENSIONMostrarItem", oCEntidad))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListInformeDetSupervisor = new List<CEntPersona>();
                        lsCEntidad.ListEliTABLA = new List<CEntidad>();
                        //CEntPresupSuper ocampodet;
                        //CEntidad ocampoEnt;
                        CEntPersona ocampoPersona;
                        if (dr.HasRows)
                        {
                            dr.Read();
                            //lsCEntidad.COD_ITIPO = dr.GetString(dr.GetOrdinal("COD_ITIPO"));
                            lsCEntidad.COD_CNOTIFICACION = dr.GetString(dr.GetOrdinal("COD_CNOTIFICACION"));
                            lsCEntidad.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                            lsCEntidad.COD_IMOTIVO = dr.GetString(dr.GetOrdinal("COD_IMOTIVO"));
                            lsCEntidad.FECHA_EMISION_DIRECCION = dr.GetString(dr.GetOrdinal("FECHA_EMISION_DIRECCION"));
                            lsCEntidad.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                            lsCEntidad.CNOTIFICACION = dr.GetString(dr.GetOrdinal("CNOTIFICACION"));
                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            lsCEntidad.COD_REQUE = dr.GetInt32(Int32.Parse(dr.GetOrdinal("COD_REQ").ToString()));

                            lsCEntidad.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            lsCEntidad.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            lsCEntidad.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));

                            lsCEntidad.PUBLICAR = dr.GetBoolean(dr.GetOrdinal("PUBLICAR"));
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            lsCEntidad.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));

                            lsCEntidad.FECHA_ACTA = dr.GetString(dr.GetOrdinal("FECHA_ACTA"));
                        }
                        //Lista de Supervisor
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_SUPERVISOR");
                            int pt1 = dr.GetOrdinal("APE_PATERNO");
                            int pt2 = dr.GetOrdinal("APE_MATERNO");
                            int pt3 = dr.GetOrdinal("NOMBRE_SUPERVISOR");
                            int pt4 = dr.GetOrdinal("NOMBRE_SUPERVISOR");
                            int pt5 = dr.GetOrdinal("N_DOCUMENTO");
                            int pt6 = dr.GetOrdinal("COD_DIDENTIDAD");
                            int pt7 = dr.GetOrdinal("COD_NACADEMICO");
                            int pt8 = dr.GetOrdinal("COD_DPESPECIALIDAD");
                            int pt9 = dr.GetOrdinal("COLEGIATURA_NUM");
                            int pt10 = dr.GetOrdinal("CARGO");
                            while (dr.Read())
                            {
                                ocampoPersona = new CEntPersona();
                                ocampoPersona.COD_PERSONA = dr.GetString(pt0);
                                ocampoPersona.APE_PATERNO = dr.GetString(pt1);
                                ocampoPersona.APE_MATERNO = dr.GetString(pt2);
                                ocampoPersona.NOMBRES = dr.GetString(pt3);
                                ocampoPersona.PERSONA = dr.GetString(pt4);
                                ocampoPersona.N_DOCUMENTO = dr.GetString(pt5);
                                ocampoPersona.COD_DIDENTIDAD = dr.GetString(pt6);
                                ocampoPersona.COD_NACADEMICO = dr.GetString(pt7);
                                ocampoPersona.COD_DPESPECIALIDAD = dr.GetString(pt8);
                                ocampoPersona.COLEGIATURA_NUM = dr.GetString(pt9);
                                ocampoPersona.CARGO = dr.GetString(pt10);
                                ocampoPersona.COD_PTIPO = "0000007";
                                ocampoPersona.RegEstado = 0;
                                lsCEntidad.ListInformeDetSupervisor.Add(ocampoPersona);
                            }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String RegInsertar(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad ocampoSuper;
            CEntPersona ocampoPersona;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_SUSPENSION_Grabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "100")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El registro se encuentra con Control de Calidad Conforme, No se puede modificar el registro");
                    }
                    else if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                    if (OUTPUTPARAM01 == "0")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de Informe ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Informe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número del Informe de Suspensión Existe en otro Registro");
                    }
                }
                //
                //Eliminando Detalle Informe
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        ocampoSuper = new CEntidad();
                        ocampoSuper.COD_INFORME = OUTPUTPARAM01;
                        ocampoSuper.EliTABLA = loDatos.EliTABLA;
                        ocampoSuper.COD_PERSONA = loDatos.COD_PERSONA;
                        ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_Eliminar", ocampoSuper);
                    }
                }
                //
                if (oCEntidad.ListInformeDetSupervisor != null)
                {
                    foreach (var loDatos in oCEntidad.ListInformeDetSupervisor)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoPersona = new CEntPersona();
                            ocampoPersona.COD_PERSONA = loDatos.COD_PERSONA;
                            ocampoPersona.CODIGO = OUTPUTPARAM01;
                            ocampoPersona.COD_DIDENTIDAD = loDatos.COD_DIDENTIDAD;
                            ocampoPersona.APE_PATERNO = loDatos.APE_PATERNO;
                            ocampoPersona.APE_MATERNO = loDatos.APE_MATERNO;
                            ocampoPersona.NOMBRES = loDatos.NOMBRES;
                            ocampoPersona.N_DOCUMENTO = loDatos.N_DOCUMENTO;
                            ocampoPersona.N_RUC = loDatos.N_RUC;
                            ocampoPersona.COD_PTIPO = loDatos.COD_PTIPO;
                            ocampoPersona.COLEGIATURA_NUM = loDatos.COLEGIATURA_NUM;
                            ocampoPersona.COD_DPESPECIALIDAD = loDatos.COD_DPESPECIALIDAD;
                            ocampoPersona.COD_NACADEMICO = loDatos.COD_NACADEMICO;
                            ocampoPersona.CARGO = loDatos.CARGO;
                            ocampoPersona.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_DET_SUPERVISOR_GrabarV3", ocampoPersona);
                        }
                    }
                }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <returns></returns>
        public CEntidad RegMostCombo(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalle;
                        CEntidad oCamposDet;
                        //Estado Situacional
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListIndicador = lsDetDetalle;
                        //Documento Identidad
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboDIdentidad = lsDetDetalle;
                        //Supervision Motivo
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListISupervision_Motivo = lsDetDetalle;
                        //Persona Especialidad
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListPersEspecialidad = lsDetDetalle;
                        //Nivel Academico
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListNivelAcademico = lsDetDetalle;
                        //Oficinas Desconcentradas
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListODs = lsDetDetalle;
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Dictionary<string, string>> RegistroUsuarios(OracleConnection cn, CEntidad oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.CR_FISCA_GENERAL_LISTAR", oCEntidad))
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

                return lstResult;
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
        //public List<CEntidad> RegMostrar_Requerimiento(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spzRequerimientos", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("COD_REQUE");
        //                    int p3 = dr.GetOrdinal("COD_THABILITANTE");
        //                    int p4 = dr.GetOrdinal("NUM_THABILITANTE");
        //                    int p5 = dr.GetOrdinal("DES_THANILITANTE");
        //                    int p6 = dr.GetOrdinal("NUM_POA");
        //                    int p7 = dr.GetOrdinal("MODALIDAD_TIPO");

        //                    CEntidad oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.COD_REQUE = dr.GetInt32(p1);
        //                        oCampos.COD_THABILITANTE = dr.GetString(p3);
        //                        oCampos.NUM_THABILITANTE = dr.GetString(p4);
        //                        oCampos.DESCRIPCION = dr.GetString(p5);
        //                        oCampos.NUM_POA = Int32.Parse(dr.GetString(p6));
        //                        oCampos.MODALIDAD_TIPO = dr.GetString(p7);
        //                        lsCEntidad.Add(oCampos);
        //                    }
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
    }
}
