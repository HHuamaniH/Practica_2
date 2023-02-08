using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_TH_Comportamiento;
using CEntidadCal = CapaEntidad.DOC.Ent_TH_Calificacion;
using CEntidadTHabilitante = CapaEntidad.DOC.Ent_THabilitanteC;
using CEntidadTHCalififacionAnual = CapaEntidad.DOC.Ent_TH_CalificacionAnual;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;

namespace CapaDatos.DOC
{
    public class Dat_THComportamiento
    {
        private DBOracle dBOracle = new DBOracle();

        public CEntidad RegMostrarTHComportamiento(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_BD_OBSERVATORIO_MIGRACION.spCTH_Comportamiento_Obtn", oCEntidad))
                {
                    if (dr != null)
                    {   //LISTA ROJA
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.NU_ENTIDAD = Int32.Parse(dr["NU_ENTIDAD"].ToString());
                                oCampos.DA_FECHA_REGISTRO = dr["DA_FECHA_REGISTRO"].ToString().Substring(0,10);
                                oCampos.NV_COD_TITULO_HABILITANTE = dr["NV_COD_TITULO_HABILITANTE"].ToString();
                                oCampos.NV_TITULO_HABILITANTE = dr["NV_TITULO_HABILITANTE"].ToString();
                                oCampos.NV_TITULAR = dr["NV_TITULAR"].ToString();
                                oCampos.NV_REPLEGAL = dr["NV_REPLEGAL"].ToString();
                                oCampos.NV_DOCUMENTO = dr["NV_DOCUMENTO"].ToString();
                                oCampos.NV_MODALIDAD_TIPO = dr["NV_MODALIDAD_TIPO"].ToString();
                                oCampos.NV_REGION = dr["NV_REGION"].ToString();
                                oCampos.NV_PROVINCIA = dr["NV_PROVINCIA"].ToString();
                                oCampos.NV_DISTRITO = dr["NV_DISTRITO"].ToString();
                                oCampos.NV_REGION = oCampos.NV_REGION + " - " + oCampos.NV_PROVINCIA + " - " + oCampos.NV_DISTRITO;
                                oCampos.NV_AREA = dr["NV_AREA"].ToString();
                                oCampos.DA_FECHA_VIGENCIA = dr["DA_FECHA_VIGENCIA"].ToString();
                                oCampos.NU_CALIFICACION = dr["NU_CALIFICACION"].ToString();
                                oCampos.NU_CADUCO = dr["NU_CADUCO"].ToString();

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

        public List<CEntidadCal> RegMostrarTHCalificacion(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidadCal oCampos = new CEntidadCal();
            List<CEntidadCal> lsCEntidad = new List<CEntidadCal>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_BD_OBSERVATORIO_MIGRACION.spCTH_Calificacion_Listar", oCEntidad))
                {
                    if (dr != null)
                    {   //LISTA ROJA
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidadCal();
                                oCampos.NU_ANIO = Int32.Parse(dr["NU_ANIO"].ToString());
                                oCampos.NU_PUNTAJE = Int32.Parse(dr["NU_PUNTAJE"].ToString());
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

        public List<CEntidadTHabilitante> RegMostrarTHabilitantes(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidadTHabilitante oCampos = new CEntidadTHabilitante();
            List<CEntidadTHabilitante> lsCEntidad = new List<CEntidadTHabilitante>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "HERR_BD_OBSERVATORIO_MIGRACION.spCP_DetTitular_Listar", oCEntidad))
                {
                    if (dr != null)
                    {   //LISTA ROJA
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidadTHabilitante();
                                oCampos.COD_TITULAR_ADENDA = dr["COD_TITULAR_ADENDA"].ToString();
                                oCampos.NV_ENTIDAD = dr["NV_ENTIDAD"].ToString();
                                oCampos.NV_NUMERO = dr["NV_NUMERO"].ToString();
                                oCampos.ADENDA_FECHA_INICIO = dr["ADENDA_FECHA_INICIO"].ToString();
                                oCampos.ADENDA_FECHA_TERMINO = dr["ADENDA_FECHA_TERMINO"].ToString();
                                
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
        
        public List<CEntidadTHCalififacionAnual> RegMostrarTHCalificacionAnual(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidadTHCalififacionAnual oCampos = new CEntidadTHCalififacionAnual();
            List<CEntidadTHCalififacionAnual> lsCEntidad = new List<CEntidadTHCalififacionAnual>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_BD_OBSERVATORIO_MIGRACION.spCTH_CalififacionAnual_listar", oCEntidad))
                {
                    if (dr != null)
                    {   //LISTA ROJA
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidadTHCalififacionAnual();
                                oCampos.NV_ANIO = dr["NV_ANIO"].ToString();
                                oCampos.NCRITERIO1 = dr["NCRITERIO1"].ToString();
                                oCampos.NCRITERIO2 = dr["NCRITERIO2"].ToString();
                                oCampos.NCRITERIO3 = dr["NCRITERIO3"].ToString();
                                oCampos.NCRITERIO4 = dr["NCRITERIO4"].ToString();
                                oCampos.NCRITERIO5 = dr["NCRITERIO5"].ToString();
                                oCampos.NCRITERIO6 = dr["NCRITERIO6"].ToString();
                                oCampos.NCRITERIO7 = dr["NCRITERIO7"].ToString();
                                oCampos.NCRITERIO8 = dr["NCRITERIO8"].ToString();
                                oCampos.NCRITERIO9 = dr["NCRITERIO9"].ToString();
                                oCampos.NCRITERIO10 = dr["NCRITERIO10"].ToString();
                                
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

        public List<CEntidad> RegMostrarListTHComportamiento(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            List<CEntidad> listCampos = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_bd_observatorio_migracion.spCTH_Comportamiento_Listar", oCEntidad))
                {
                    if (dr != null)
                    {   //LISTA ROJA
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.NU_ENTIDAD = Int32.Parse(dr["NU_ENTIDAD"].ToString());
                                oCampos.DA_FECHA_REGISTRO = dr["DA_FECHA_REGISTRO"].ToString();
                                oCampos.NV_COD_TITULO_HABILITANTE = dr["NV_COD_TITULO_HABILITANTE"].ToString();
                                oCampos.NV_TITULO_HABILITANTE = dr["NV_TITULO_HABILITANTE"].ToString();
                                oCampos.NV_TITULAR = dr["NV_TITULAR"].ToString();
                                oCampos.NV_REPLEGAL = dr["NV_REPLEGAL"].ToString();
                                oCampos.NV_DOCUMENTO = dr["NV_DOCUMENTO"].ToString();
                                oCampos.NV_MODALIDAD_TIPO = dr["NV_MODALIDAD_TIPO"].ToString();
                                oCampos.NV_REGION = dr["NV_REGION"].ToString();
                                oCampos.NV_PROVINCIA = dr["NV_PROVINCIA"].ToString();
                                oCampos.NV_DISTRITO = dr["NV_DISTRITO"].ToString();                               
                                oCampos.NV_AREA = dr["NV_AREA"].ToString();
                                oCampos.DA_FECHA_VIGENCIA = dr["DA_FECHA_VIGENCIA"].ToString();
                                oCampos.NU_CALIFICACION = dr["NU_CALIFICACION"].ToString();
                                listCampos.Add(oCampos);
                            }
                        }
                    }
                }
                return listCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
