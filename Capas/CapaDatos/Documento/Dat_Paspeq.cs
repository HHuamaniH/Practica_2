using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_Paspeq;
using CEntidad2 = CapaEntidad.DOC.Ent_Paspeq_Detalle;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_Paspeq
    {
        private SQL oGDataSQL = new SQL();

        //public bool CreatePaspeq(CEntidad ent)
        //{
        //    using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //    {
        //        SqlTransaction tr = null;
        //        try
        //        {
        //            cn.Open();
        //            tr = cn.BeginTransaction();
        //            //Grabando Cabecera
        //            oGDataSQL.ManExecute(cn, tr, "DOC.spPASPEQ_Generar", ent);
        //            tr.Commit();
        //        }
        //        catch (Exception ex)
        //        {
        //            tr.Rollback();
        //            tr.Dispose();
        //            tr = null;
        //            throw ex;
        //        }
        //    }
        //    return true;
        //}
        //public List<VM_PaspeqDetalle> ListaPaspeq(SqlConnection cn, CEntidad ent)
        //{
        //    List<VM_PaspeqDetalle> respuesta = new List<VM_PaspeqDetalle>();
        //    VM_PaspeqDetalle oCampos;

        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spPASPEQ_Detalle", ent))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new VM_PaspeqDetalle();
        //                        oCampos.thabilitante = dr.GetString(dr.GetOrdinal("TITULO"));
        //                        oCampos.ubicacion = dr.GetString(dr.GetOrdinal("UBICACION"));
        //                        oCampos.oficina = dr.GetString(dr.GetOrdinal("OFICINA"));
        //                        oCampos.plan_manejo = dr.GetString(dr.GetOrdinal("PLAN_MANEJO"));
        //                        oCampos.resolucion_aprobacion = dr.GetString(dr.GetOrdinal("RESOLUCION_APROBACION"));
        //                        oCampos.resultado = dr.GetInt32(dr.GetOrdinal("RESULTADO"));
        //                        respuesta.Add(oCampos);
        //                    }
        //                }
        //            }
        //        }
        //        return respuesta;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public bool SeleccionarPaspeq(CEntidad ent)
        //{
        //    using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //    {
        //        SqlTransaction tr = null;
        //        try
        //        {
        //            cn.Open();
        //            tr = cn.BeginTransaction();
        //            //Grabando Cabecera
        //            oGDataSQL.ManExecute(cn, tr, "DOC.spPASPEQ_Seleccionar", ent);
        //            tr.Commit();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            tr.Rollback();
        //            tr.Dispose();
        //            tr = null;
        //            return false;
        //            throw ex;
        //        }
        //    }
        //}
        //public bool EliminarPaspeq(CEntidad ent)
        //{
        //    using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //    {
        //        SqlTransaction tr = null;
        //        try
        //        {
        //            cn.Open();
        //            tr = cn.BeginTransaction();
        //            //Grabando Cabecera
        //            oGDataSQL.ManExecute(cn, tr, "DOC.spPASPEQ_Eliminar", ent);
        //            tr.Commit();
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            tr.Rollback();
        //            tr.Dispose();
        //            tr = null;
        //            return false;
        //            throw ex;
        //        }
        //    }
        //}
        //public List<VM_PaspeqDetalle> AjustarPaspeq(SqlConnection cn, List<VM_PaspeqDetalle> listaPaspeq, Ent_Paspeq idPaspeq)
        //{
        //    SqlTransaction tr = null;
        //    List<VM_PaspeqDetalle> respuesta = new List<VM_PaspeqDetalle>();
        //    List<VM_PaspeqDetalle> errores = new List<VM_PaspeqDetalle>();
        //    VM_PaspeqDetalle oCampos, oParametros;
        //    Int32 RESULTADO = 0;
        //    try
        //    {
        //        tr = cn.BeginTransaction();
        //        oGDataSQL.ManExecute(cn, tr, "DOC.spPASPEQ_Detalle_Desactivar", idPaspeq);

        //        foreach (var oDatos in listaPaspeq)
        //        {
        //            oParametros = new VM_PaspeqDetalle();
        //            oParametros.cod_pmanejo = oDatos.cod_pmanejo;
        //            oParametros.cod_thabilitante = oDatos.cod_thabilitante;
        //            oParametros.num_poa = oDatos.num_poa;
        //            oParametros.tabla_plan_manejo = oDatos.tabla_plan_manejo;
        //            oParametros.num_paspeq = oDatos.num_paspeq;
        //            oParametros.periodo = oDatos.periodo;
        //            oParametros.resultado = 1;
        //            using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spPASPEQ_Detalle_Ajuste", oParametros))
        //            {
        //                cmd.ExecuteNonQuery();
        //                RESULTADO = (Int32)cmd.Parameters["@RESULTADO"].Value;
        //                if (RESULTADO == 0)
        //                {
        //                    oDatos.resultado = RESULTADO;
        //                    errores.Add(oDatos);
        //                }
        //            }
        //        }
        //        tr.Commit();

        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spPASPEQ_Detalle", idPaspeq))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new VM_PaspeqDetalle();
        //                        oCampos.thabilitante = dr.GetString(dr.GetOrdinal("TITULO"));
        //                        oCampos.ubicacion = dr.GetString(dr.GetOrdinal("UBICACION"));
        //                        oCampos.oficina = dr.GetString(dr.GetOrdinal("OFICINA"));
        //                        oCampos.plan_manejo = dr.GetString(dr.GetOrdinal("PLAN_MANEJO"));
        //                        oCampos.resolucion_aprobacion = dr.GetString(dr.GetOrdinal("RESOLUCION_APROBACION"));
        //                        oCampos.resultado = "1";
        //                        respuesta.Add(oCampos);
        //                    }
        //                }
        //            }
        //        }

        //        respuesta.AddRange(errores);
        //        return respuesta;
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
        //public List<CEntidad2> DatosReportePaspeq(SqlConnection cn, CEntidad ent)
        //{
        //    List<CEntidad2> respuesta = new List<CEntidad2>();
        //    CEntidad2 oCampos;

        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spPASPEQ_Reporte", ent))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad2();
        //                        oCampos.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
        //                        oCampos.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
        //                        oCampos.COD_PMANEJO = dr.GetString(dr.GetOrdinal("COD_PMANEJO"));
        //                        oCampos.TABLA_ORIGEN = dr.GetString(dr.GetOrdinal("TABLA_ORIGEN"));
        //                        oCampos.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
        //                        oCampos.TITULAR_ACTUAL = dr.GetString(dr.GetOrdinal("TITULAR_ACTUAL"));
        //                        oCampos.R_LEGAL = dr.GetString(dr.GetOrdinal("R_LEGAL"));
        //                        oCampos.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
        //                        oCampos.PROVINCIA = dr.GetString(dr.GetOrdinal("PROVINCIA"));
        //                        oCampos.DISTRITO = dr.GetString(dr.GetOrdinal("DISTRITO"));
        //                        oCampos.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
        //                        oCampos.CADUCADO = dr.GetString(dr.GetOrdinal("CADUCADO"));
        //                        oCampos.MED_CAU = dr.GetString(dr.GetOrdinal("MED_CAU"));
        //                        oCampos.MED_PRECAU = dr.GetString(dr.GetOrdinal("MED_PRECAU"));
        //                        oCampos.SUPERVISIONES_TH_EFECTUADAS = dr.GetString(dr.GetOrdinal("SUPERVISIONES_TH_EFECTUADAS"));
        //                        oCampos.OD_AMBITO = dr.GetString(dr.GetOrdinal("OD_AMBITO"));
        //                        oCampos.NOMBRE_POA = dr.GetString(dr.GetOrdinal("NOMBRE_POA"));
        //                        oCampos.RESOLUCION_POA = dr.GetString(dr.GetOrdinal("RESOLUCION_POA"));
        //                        oCampos.FECHA_APROB = dr.GetString(dr.GetOrdinal("FECHA_APROB"));
        //                        oCampos.FUENTE = dr.GetString(dr.GetOrdinal("FUENTE"));
        //                        oCampos.NUM_DREFERENCIA = dr.GetString(dr.GetOrdinal("NUM_DREFERENCIA"));
        //                        oCampos.FECHA_RECEPCION = dr.GetString(dr.GetOrdinal("FECHA_RECEPCION"));
        //                        oCampos.ESTADO_CALIDAD = dr.GetString(dr.GetOrdinal("ESTADO_CALIDAD"));
        //                        oCampos.NUM_CENSO_MADERABLE = dr.GetDecimal(dr.GetOrdinal("NUM_CENSO_MADERABLE"));
        //                        oCampos.NUM_CENSO_NOMADERABLE = dr.GetDecimal(dr.GetOrdinal("NUM_CENSO_NOMADERABLE"));
        //                        oCampos.NUM_ESPECIE_APROBADO = dr.GetDecimal(dr.GetOrdinal("NUM_ESPECIE_APROBADO"));
        //                        oCampos.NUM_ESPECIE_BEXTRACCION = dr.GetDecimal(dr.GetOrdinal("NUM_ESPECIE_BEXTRACCION"));
        //                        oCampos.AREA_TH = dr.GetDecimal(dr.GetOrdinal("AREA_TH"));
        //                        oCampos.AREA_POA = dr.GetDecimal(dr.GetOrdinal("AREA_POA"));
        //                        oCampos.FECHA_INICIO_TH = dr.GetString(dr.GetOrdinal("FECHA_INICIO_TH"));
        //                        oCampos.FECHA_FIN_TH = dr.GetString(dr.GetOrdinal("FECHA_FIN_TH"));
        //                        oCampos.FECHA_INICIO_POA = dr.GetString(dr.GetOrdinal("FECHA_INICIO_POA"));
        //                        oCampos.FECHA_FIN_POA = dr.GetString(dr.GetOrdinal("FECHA_FIN_POA"));
        //                        oCampos.CONSULTOR = dr.GetString(dr.GetOrdinal("CONSULTOR"));
        //                        oCampos.SUPERVISIONES_POA_REALIZADAS = dr.GetString(dr.GetOrdinal("SUPERVISIONES_POA_REALIZADAS"));
        //                        oCampos.ZONA_UTM = dr.GetString(dr.GetOrdinal("ZONA_UTM"));
        //                        oCampos.COORD_ESTE = dr.GetString(dr.GetOrdinal("COORD_ESTE"));
        //                        oCampos.COORD_NORTE = dr.GetString(dr.GetOrdinal("COORD_NORTE"));
        //                        oCampos.ESPECIE_AMENAZADA = dr.GetString(dr.GetOrdinal("ESPECIE_AMENAZADA"));
        //                        oCampos.REQ_ENTIDAD = dr.GetString(dr.GetOrdinal("REQ_ENTIDAD"));
        //                        oCampos.DENUNCIA = dr.GetString(dr.GetOrdinal("DENUNCIA"));
        //                        oCampos.ESTADO_SUPERVISION_RESOLUCION = dr.GetString(dr.GetOrdinal("ESTADO_SUPERVISION_RESOLUCION"));
        //                        oCampos.ESTADO_SUPERVISION_PLAN = dr.GetString(dr.GetOrdinal("ESTADO_SUPERVISION_PLAN"));
        //                        oCampos.SUPERVISION_ANTES_EXTRACCION = dr.GetString(dr.GetOrdinal("SUPERVISION_ANTES_EXTRACCION"));
        //                        oCampos.CANT_C1 = dr.GetDecimal(dr.GetOrdinal("CANT_C1"));
        //                        oCampos.FRECUENCIA_SUPERVISION_TH = dr.GetDecimal(dr.GetOrdinal("FRECUENCIA_SUPERVISION_TH"));
        //                        oCampos.RIESGO_FRECUENCIA = dr.GetDecimal(dr.GetOrdinal("RIESGO_FRECUENCIA"));
        //                        oCampos.RESULTADO_FRECUENCIA = dr.GetDecimal(dr.GetOrdinal("RESULTADO_FRECUENCIA"));
        //                        oCampos.CANT_C2 = dr.GetDecimal(dr.GetOrdinal("CANT_C2"));
        //                        oCampos.INCIDENCIA_INFRAC_TH = dr.GetDecimal(dr.GetOrdinal("INCIDENCIA_INFRAC_TH"));
        //                        oCampos.RIESGO_INCIDENCIA = dr.GetDecimal(dr.GetOrdinal("RIESGO_INCIDENCIA"));
        //                        oCampos.RESULTADO_INCIDENCIA = dr.GetDecimal(dr.GetOrdinal("RESULTADO_INCIDENCIA"));
        //                        oCampos.CANT_C3 = dr.GetString(dr.GetOrdinal("CANT_C3"));
        //                        oCampos.INDICE_NOAUTH = dr.GetDecimal(dr.GetOrdinal("INDICE_NOAUTH"));
        //                        oCampos.RIESGO_NOAUTH = dr.GetDecimal(dr.GetOrdinal("RIESGO_NOAUTH"));
        //                        oCampos.RESULTADO_NOAUTH = dr.GetDecimal(dr.GetOrdinal("RESULTADO_NOAUTH"));
        //                        oCampos.CANT_C4 = dr.GetString(dr.GetOrdinal("CANT_C4"));
        //                        oCampos.INDICE_INFRAC = dr.GetDecimal(dr.GetOrdinal("INDICE_INFRAC"));
        //                        oCampos.RIESGO_INFRAC = dr.GetDecimal(dr.GetOrdinal("RIESGO_INFRAC"));
        //                        oCampos.RESULTADO_INFRAC = dr.GetDecimal(dr.GetOrdinal("RESULTADO_INFRAC"));
        //                        oCampos.TOTAL = dr.GetDecimal(dr.GetOrdinal("TOTAL"));
        //                        respuesta.Add(oCampos);
        //                    }
        //                }
        //            }
        //        }
        //        return respuesta;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
