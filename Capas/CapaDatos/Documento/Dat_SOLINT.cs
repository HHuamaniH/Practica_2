using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_SOLINT;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_SOLINT
    {
        private SQL oGDataSQL = new SQL();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostrarSOLINT_Buscar(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_INFORME = dr["COD_INFORME"].ToString();
                                oCampos.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                oCampos.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
                                oCampos.NUMERO = dr["NUMERO"].ToString();
                                oCampos.D_LINEA = dr["D_LINEA"].ToString();
                                oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                lsCEntidad.Add(oCampos);
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
        /// <returns></returns>
        public CEntidad RegMostCombo(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalle;
                        CEntidad oCamposDet;
                        //Tipo Documento                  
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_TIPO_DOCUMENTO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION_DOCUMENTO");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_TIPO_DOCUMENTO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION_DOCUMENTO = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListTipoDocumento = lsDetDetalle;
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
        public String RegGrabaSolicitudInterna(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;
            String OUTPUTPARAM01 = "";
            String OUTPUTPARAM02 = "";
            CEntidad oCamposDet;

            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spSOLINTGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
                    //     OUTPUTPARAM02 = (String)cmd.Parameters["@OUTPUTPARAM02"].Value;
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
                        throw new Exception("El Número Solicitud de Información Interna  ya existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número Solicitud de Información Interna existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar esta solicitud de información interna");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_SOLINT = OUTPUTPARAM01;
                }
                //  Eliminando Detalle               
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_SOLINT = OUTPUTPARAM01;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                        oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                        oCamposDet.COD_RESODIREC_INI_PAU = loDatos.COD_RESODIREC_INI_PAU;
                        oGDataSQL.ManExecute(cn, tr, "DOC.spSOLINTEliminarDetalle", oCamposDet);
                    }
                }
                //Grabando Detalle Inicio PAU 

                if (oCEntidad.TIPO == "IN")
                {
                    if (oCEntidad.ListInformes != null)
                    {
                        foreach (var loDatos in oCEntidad.ListInformes)
                        {
                            if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                                oCamposDet.COD_SOLINT = OUTPUTPARAM01;
                                oCamposDet.RegEstado = 1;
                                oGDataSQL.ManExecute(cn, tr, "DOC.spSOLINT_DET_INFORME_Grabar", oCamposDet);
                            }
                        }
                    }
                }
                else if (oCEntidad.TIPO == "TH")
                {

                    if (oCEntidad.ListInformes != null)
                    {
                        foreach (var loDatos in oCEntidad.ListInformes)
                        {
                            if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                            {
                                oCamposDet = new CEntidad();

                                oCamposDet.COD_THABILITANTE = loDatos.CODIGO;
                                oCamposDet.COD_SOLINT = OUTPUTPARAM01;
                                oCamposDet.RegEstado = 1;
                                oGDataSQL.ManExecute(cn, tr, "DOC.spSOLINT_DET_THABILITANTE_Grabar", oCamposDet);
                            }
                        }
                    }
                }
                else if (oCEntidad.TIPO == "EX")
                {

                    if (oCEntidad.ListInformes != null)
                    {
                        foreach (var loDatos in oCEntidad.ListInformes)
                        {
                            if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                            {
                                oCamposDet = new CEntidad();

                                oCamposDet.COD_RESODIREC_INI_PAU = loDatos.COD_RESODIREC_INI_PAU;
                                oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                                oCamposDet.COD_SOLINT = OUTPUTPARAM01;
                                oCamposDet.RegEstado = 1;
                                oGDataSQL.ManExecute(cn, tr, "DOC.spSOLINT_DET_EXP_Grabar", oCamposDet);
                            }
                        }
                    }
                }
                tr.Commit();
                return OUTPUTPARAM01 + '|' + OUTPUTPARAM02;
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
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostrarListaSolIntItem(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spSOLINTMostrarItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListInformes = new List<CEntidad>();

                        CEntidad ocampoEnt2;

                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_SOLINT = dr.GetString(dr.GetOrdinal("COD_SOLINT"));
                            lsCEntidad.TIPO_FISCALIZA = dr.GetString(dr.GetOrdinal("TIPO_FISCALIZA"));
                            lsCEntidad.NUMERO_SOLINT = dr.GetString(dr.GetOrdinal("NUMERO_SOLINT"));
                            lsCEntidad.COD_TIPO_DOCUMENTO = dr.GetString(dr.GetOrdinal("COD_TIPO_DOCUMENTO"));
                            lsCEntidad.COD_PSOLICITA = dr.GetString(dr.GetOrdinal("COD_PSOLICITA"));
                            lsCEntidad.PSOLICITA = dr.GetString(dr.GetOrdinal("PSOLICITA"));
                            lsCEntidad.TIPO = dr.GetString(dr.GetOrdinal("TIPO"));
                            lsCEntidad.FECHA_EMISION = dr.GetString(dr.GetOrdinal("FECHA_EMISION"));
                            lsCEntidad.COD_PDIRIGE = dr.GetString(dr.GetOrdinal("COD_PDIRIGE"));
                            lsCEntidad.PDIRIGE = dr.GetString(dr.GetOrdinal("PDIRIGE"));
                            lsCEntidad.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));

                        }
                        //Estado (Calidad)
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            lsCEntidad.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            lsCEntidad.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            lsCEntidad.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));
                        }
                        else
                        {
                            lsCEntidad.COD_ESTADO_DOC = "";
                            lsCEntidad.OBSERVACIONES_CONTROL = "";
                            lsCEntidad.OBSERV_SUBSANAR = false;
                            lsCEntidad.USUARIO_CONTROL = "";
                        }


                        dr.NextResult();
                        if (lsCEntidad.TIPO == "IN")
                        {
                            if (dr.HasRows)
                            {
                                int pt0 = dr.GetOrdinal("COD_INFORME");
                                int pt1 = dr.GetOrdinal("NUMERO");
                                int pt2 = dr.GetOrdinal("D_LINEA");
                                int pt3 = dr.GetOrdinal("NUM_THABILITANTE");
                                int pt4 = dr.GetOrdinal("TITULAR");
                                int pt5 = dr.GetOrdinal("COD_RESODIREC");
                                int pt6 = dr.GetOrdinal("COD_RESODIREC_INI_PAU");
                                while (dr.Read())
                                {
                                    ocampoEnt2 = new CEntidad();
                                    ocampoEnt2.COD_INFORME = dr.GetString(pt0);
                                    ocampoEnt2.NUMERO = dr.GetString(pt1);
                                    ocampoEnt2.D_LINEA = dr.GetString(pt2);
                                    ocampoEnt2.NUM_THABILITANTE = dr.GetString(pt3);
                                    ocampoEnt2.TITULAR = dr.GetString(pt4);
                                    ocampoEnt2.COD_RESODIREC = dr.GetString(pt5);
                                    ocampoEnt2.COD_RESODIREC_INI_PAU = dr.GetString(pt6);
                                    ocampoEnt2.RegEstado = 0;
                                    lsCEntidad.ListInformes.Add(ocampoEnt2);
                                }
                            }
                        }
                        dr.NextResult();
                        if (lsCEntidad.TIPO == "TH")
                        {
                            if (dr.HasRows)
                            {
                                int pt0 = dr.GetOrdinal("CODIGO");
                                int pt1 = dr.GetOrdinal("NUMERO");
                                int p7 = dr.GetOrdinal("D_LINEA");
                                int p8 = dr.GetOrdinal("NUM_THABILITANTE");
                                int p9 = dr.GetOrdinal("TITULAR");
                                while (dr.Read())
                                {
                                    ocampoEnt2 = new CEntidad();
                                    ocampoEnt2.CODIGO = dr.GetString(pt0);
                                    ocampoEnt2.NUMERO = dr.GetString(pt1);
                                    ocampoEnt2.D_LINEA = dr.GetString(p7);
                                    ocampoEnt2.NUM_THABILITANTE = dr.GetString(p8);
                                    ocampoEnt2.TITULAR = dr.GetString(p9);
                                    ocampoEnt2.RegEstado = 0;
                                    lsCEntidad.ListInformes.Add(ocampoEnt2);
                                }
                            }
                        }
                        dr.NextResult();
                        if (lsCEntidad.TIPO == "EX")
                        {

                            if (dr.HasRows)
                            {
                                int pt0 = dr.GetOrdinal("COD_RESODIREC");
                                int pt1 = dr.GetOrdinal("NUMERO");
                                int pt2 = dr.GetOrdinal("COD_RESODIREC_INI_PAU");
                                int pt3 = dr.GetOrdinal("D_LINEA");
                                int pt4 = dr.GetOrdinal("NUM_THABILITANTE");
                                int pt5 = dr.GetOrdinal("TITULAR");
                                int pt6 = dr.GetOrdinal("COD_INFORME");
                                while (dr.Read())
                                {
                                    ocampoEnt2 = new CEntidad();
                                    ocampoEnt2.COD_RESODIREC = dr.GetString(pt0);
                                    ocampoEnt2.NUMERO = dr.GetString(pt1);
                                    ocampoEnt2.COD_RESODIREC_INI_PAU = dr.GetString(pt2);
                                    ocampoEnt2.D_LINEA = dr.GetString(pt4);
                                    ocampoEnt2.NUM_THABILITANTE = dr.GetString(pt4);
                                    ocampoEnt2.TITULAR = dr.GetString(pt5);
                                    ocampoEnt2.COD_INFORME = dr.GetString(pt6);
                                    ocampoEnt2.RegEstado = 0;
                                    lsCEntidad.ListInformes.Add(ocampoEnt2);
                                }
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
    }
}
