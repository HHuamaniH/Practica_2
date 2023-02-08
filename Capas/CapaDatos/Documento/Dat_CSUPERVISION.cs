using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CEntidad = CapaEntidad.DOC.Ent_CSUPERVISION;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_CSUPERVISION
    {
        private SQL oGDataSQL = new SQL();

        public List<CEntidad> RegMostTHPoaPm_x_Numero(SqlConnection cn, CEntidad oCEntidad)
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
                            int p1 = dr.GetOrdinal("COD_PMANEJO");
                            int p2 = dr.GetOrdinal("COD_THABILITANTE");
                            int p3 = dr.GetOrdinal("NUM_POA");
                            int p4 = dr.GetOrdinal("NUM_THABILITANTE");
                            int p5 = dr.GetOrdinal("NUMERO");
                            int p6 = dr.GetOrdinal("D_LINEA");
                            int p7 = dr.GetOrdinal("TITULAR");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();

                                oCampos.COD_PMANEJO = dr.GetString(p1);
                                oCampos.COD_THABILITANTE = dr.GetString(p2);
                                oCampos.NUM_POA = dr.GetInt32(p3);
                                oCampos.NUM_THABILITANTE = dr.GetString(p4);
                                oCampos.NUMERO = dr.GetString(p5);
                                oCampos.D_LINEA = dr.GetString(p6);
                                oCampos.TITULAR = dr.GetString(p7);

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
        /// <param name="oCEntidad"></param>
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
                        //Documento Identidad
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
                        oCampos.ListMComboOD = lsDetDetalle;

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
                        oCampos.ListMComboTipoActividad = lsDetDetalle;
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
        public String RegGrabar(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spCSUPERVISION_Grabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
                    switch (OUTPUTPARAM01)
                    {
                        case "99":
                            tr.Rollback();
                            tr = null;
                            throw new Exception("Ud. no tiene permiso para realizar esta acción");
                        case "0":
                            tr.Rollback();
                            tr = null;
                            throw new Exception("El Cronograma de Supervisión ya existe");
                        case "1":
                            tr.Rollback();
                            tr = null;
                            throw new Exception("El cronograma de Supervisión ya existe en otro registro");
                        default:
                            break;
                    }
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_CSUPERVISION = OUTPUTPARAM01;
                }
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var itemEli in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CSUPERVISION = oCEntidad.COD_CSUPERVISION;
                        oCamposDet.COD_THABILITANTE = itemEli.COD_THABILITANTE;
                        oCamposDet.EliTABLA = itemEli.EliTABLA;
                        oCamposDet.EliVALOR01 = itemEli.EliVALOR01;
                        oCamposDet.EliVALOR02 = itemEli.EliVALOR02;
                        oGDataSQL.ManExecute(cn, tr, "DOC.spCSUPERVISIONEliminarDetalle", oCamposDet);
                    }
                }
                //Grabar Título Habilitante
                if (oCEntidad.ListCSupervisionTH != null)
                {
                    foreach (var itemTH in oCEntidad.ListCSupervisionTH)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CSUPERVISION = oCEntidad.COD_CSUPERVISION;
                        oCamposDet.COD_THABILITANTE = itemTH.COD_THABILITANTE;
                        oCamposDet.COD_DLINEA = itemTH.COD_DLINEA;
                        oCamposDet.NUM_DIA_SUPERV = itemTH.NUM_DIA_SUPERV;
                        oCamposDet.TRANSPORTE = itemTH.TRANSPORTE;
                        oCamposDet.OBSERVACION = itemTH.OBSERVACION;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.RegEstado = itemTH.RegEstado;
                        oGDataSQL.ManExecute(cn, tr, "DOC.spCSUPERVISION_TH_Grabar", oCamposDet);

                        //Grabar Supervisor
                        foreach (var itemSuperv in itemTH.ListCSupervTHSupervisor)
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CSUPERVISION = oCEntidad.COD_CSUPERVISION;
                            oCamposDet.COD_THABILITANTE = itemTH.COD_THABILITANTE;
                            oCamposDet.COD_PERSONA = itemSuperv.COD_PERSONA;
                            oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            oCamposDet.RegEstado = itemSuperv.RegEstado;
                            oGDataSQL.ManExecute(cn, tr, "DOC.spCSUPERVISION_TH_SUPERVISOR_Grabar", oCamposDet);
                        }
                        //Grabar Dia
                        foreach (var itemDia in itemTH.ListCSupervTHDiaAct)
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_CSUPERVISION = oCEntidad.COD_CSUPERVISION;
                            oCamposDet.COD_THABILITANTE = itemTH.COD_THABILITANTE;
                            oCamposDet.DIA = itemDia.DIA;
                            oCamposDet.MAE_TIP_ACTIVIDAD = itemDia.MAE_TIP_ACTIVIDAD;
                            oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            oCamposDet.RegEstado = itemDia.RegEstado;
                            oGDataSQL.ManExecute(cn, tr, "DOC.spCSUPERVISION_TH_DIA_Grabar", oCamposDet);
                        }
                    }
                }
                //Grabar POA || PM
                if (oCEntidad.ListTHPoaPm != null)
                {
                    foreach (var itemPoaPm in oCEntidad.ListTHPoaPm)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_CSUPERVISION = oCEntidad.COD_CSUPERVISION;
                        oCamposDet.COD_THABILITANTE = itemPoaPm.COD_THABILITANTE;
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.RegEstado = itemPoaPm.RegEstado;

                        if (itemPoaPm.COD_PMANEJO != "")
                        {
                            oCamposDet.COD_PMANEJO = itemPoaPm.COD_PMANEJO;
                            oGDataSQL.ManExecute(cn, tr, "DOC.spCSUPERVISION_TH_PM_Grabar", oCamposDet);
                        }
                        else
                        {
                            oCamposDet.NUM_POA = itemPoaPm.NUM_POA;
                            oGDataSQL.ManExecute(cn, tr, "DOC.spCSUPERVISION_TH_POA_Grabar", oCamposDet);
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
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostrarListaItem(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            CEntidad oCamposDet;
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spCSUPERVISIONMostrarItem", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListCSupervisionTH = new List<CEntidad>();
                        oCampos.ListTHPoaPm = new List<CEntidad>();
                        oCampos.ListEliTABLA = new List<CEntidad>();

                        if (dr.HasRows)
                        {
                            //Cabecera Cronograma de Supervisión
                            dr.Read();
                            oCampos.COD_CSUPERVISION = dr.GetString(dr.GetOrdinal("COD_CSUPERVISION"));
                            oCampos.ANIO = dr.GetInt32(dr.GetOrdinal("ANIO"));
                            oCampos.MES = dr.GetString(dr.GetOrdinal("MES"));
                            oCampos.RegEstado = 0;

                            //Detalle Título Habilitante
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                int pt1 = dr.GetOrdinal("COD_CSUPERVISION");
                                int pt2 = dr.GetOrdinal("COD_THABILITANTE");
                                int pt3 = dr.GetOrdinal("COD_DLINEA");
                                int pt4 = dr.GetOrdinal("NUM_DIA_SUPERV");
                                int pt5 = dr.GetOrdinal("TRANSPORTE");
                                int pt6 = dr.GetOrdinal("OBSERVACION");
                                int pt7 = dr.GetOrdinal("NUM_THABILITANTE");
                                while (dr.Read())
                                {
                                    oCamposDet = new CEntidad();
                                    oCamposDet.COD_CSUPERVISION = dr.GetString(pt1);
                                    oCamposDet.COD_THABILITANTE = dr.GetString(pt2);
                                    oCamposDet.COD_DLINEA = dr.GetString(pt3);
                                    oCamposDet.NUM_DIA_SUPERV = dr.GetInt32(pt4);
                                    oCamposDet.TRANSPORTE = dr.GetString(pt5);
                                    oCamposDet.OBSERVACION = dr.GetString(pt6);
                                    oCamposDet.NUM_THABILITANTE = dr.GetString(pt7);
                                    oCamposDet.RegEstado = 0;
                                    oCamposDet.ListCSupervTHDiaAct = new List<CEntidad>();
                                    oCamposDet.ListCSupervTHSupervisor = new List<CEntidad>();
                                    oCampos.ListCSupervisionTH.Add(oCamposDet);
                                }
                            }
                            //TH Día
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                int pt1 = dr.GetOrdinal("COD_CSUPERVISION");
                                int pt2 = dr.GetOrdinal("COD_THABILITANTE");
                                int pt3 = dr.GetOrdinal("DIA");
                                int pt4 = dr.GetOrdinal("MAE_TIP_ACTIVIDAD");
                                while (dr.Read())
                                {
                                    oCamposDet = new CEntidad();
                                    oCamposDet.COD_CSUPERVISION = dr.GetString(pt1);
                                    oCamposDet.COD_THABILITANTE = dr.GetString(pt2);
                                    oCamposDet.DIA = dr.GetInt32(pt3);
                                    oCamposDet.MAE_TIP_ACTIVIDAD = dr.GetString(pt4);
                                    oCamposDet.RegEstado = 0;
                                    oCampos.ListCSupervisionTH.Where(th => th.COD_THABILITANTE == oCamposDet.COD_THABILITANTE).FirstOrDefault().ListCSupervTHDiaAct.Add(oCamposDet);
                                }
                            }
                            //TH Supervisor
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                int pt1 = dr.GetOrdinal("COD_CSUPERVISION");
                                int pt2 = dr.GetOrdinal("COD_THABILITANTE");
                                int pt3 = dr.GetOrdinal("COD_PERSONA");
                                int pt4 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                                while (dr.Read())
                                {
                                    oCamposDet = new CEntidad();
                                    oCamposDet.COD_CSUPERVISION = dr.GetString(pt1);
                                    oCamposDet.COD_THABILITANTE = dr.GetString(pt2);
                                    oCamposDet.COD_PERSONA = dr.GetString(pt3);
                                    oCamposDet.APELLIDOS_NOMBRES = dr.GetString(pt4);
                                    oCamposDet.RegEstado = 0;
                                    oCampos.ListCSupervisionTH.Where(th => th.COD_THABILITANTE == oCamposDet.COD_THABILITANTE).FirstOrDefault().ListCSupervTHSupervisor.Add(oCamposDet);
                                }
                            }
                            //TH POA|PM
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                int pt1 = dr.GetOrdinal("COD_CSUPERVISION");
                                int pt2 = dr.GetOrdinal("COD_THABILITANTE");
                                int pt3 = dr.GetOrdinal("COD_PMANEJO");
                                int pt4 = dr.GetOrdinal("NUM_POA");
                                int pt5 = dr.GetOrdinal("NUM_THABILITANTE");
                                int pt6 = dr.GetOrdinal("TITULAR");
                                while (dr.Read())
                                {
                                    oCamposDet = new CEntidad();
                                    oCamposDet.COD_CSUPERVISION = dr.GetString(pt1);
                                    oCamposDet.COD_THABILITANTE = dr.GetString(pt2);
                                    oCamposDet.COD_PMANEJO = dr.GetString(pt3);
                                    oCamposDet.NUM_POA = dr.GetInt32(pt4);
                                    oCamposDet.NUM_THABILITANTE = dr.GetString(pt5);
                                    oCamposDet.TITULAR = dr.GetString(pt6);
                                    oCamposDet.RegEstado = 0;
                                    oCampos.ListTHPoaPm.Add(oCamposDet);
                                }
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
    }
}
