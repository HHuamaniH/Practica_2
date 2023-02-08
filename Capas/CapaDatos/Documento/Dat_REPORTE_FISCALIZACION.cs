using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_REPORTE_FISCALIZACION;
using CEntPAU = CapaEntidad.DOC.Ent_Reporte_PAU_CONCLUIDO;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
//using SQL = GeneralSQL.Data.SQL;
namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_REPORTE_FISCALIZACION
    {
        //private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> MostrarInfraccion_PAU(CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_InfraccionesFrecuentes", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                int p1 = dr.GetOrdinal("DESCRIPCION");
                                int p2 = dr.GetOrdinal("INICIO_PAU");
                                int p3 = dr.GetOrdinal("TERMINO_PAU");


                                CEntidad oCampos;
                                while (dr.Read())
                                {
                                    oCampos = new CEntidad();
                                    oCampos.DESCRIPCION = dr.GetString(p1);
                                    oCampos.TOTAL_PRIMERO = dr.GetInt32(p2);
                                    oCampos.TOTAL_SEGUNDO = dr.GetInt32(p3);
                                    lsCEntidad.Add(oCampos);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad DatMedidasCautelares(CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_MedidasCautelares", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalles;
                        CEntidad oCamposDet;

                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCamposDet = new CEntidad();
                                oCamposDet.DEPARTAMENTO = dr["DEPARTAMENTO"].ToString();
                                oCamposDet.MEDCAU_PAU = Int32.Parse(dr["MEDCAU_PAU"].ToString());
                                oCamposDet.MEDPRECAU_PAU = Int32.Parse(dr["MEDPRECAU_PAU"].ToString());
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListGeneral = lsDetDetalles;
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
        public List<CEntidad> DatDetMedidasCautelares(CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_MedidasCautelaresDetalle", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                CEntidad oCampos;
                                while (dr.Read())
                                {
                                    oCampos = new CEntidad();
                                    oCampos.THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                    oCampos.DEPARTAMENTO = dr["DEPARTAMENTO"].ToString();
                                    oCampos.TITULAR = dr["TITULAR"].ToString();
                                    oCampos.TITULAR_SANCIONADO = dr["TITULAR_SANCIONADO"].ToString();
                                    oCampos.RDMEDIDAS = dr["RDMEDIDAS"].ToString();
                                    oCampos.RDMEDIDAS_PUBLICAR = dr["RDMEDIDAS_PUBLICAR"].ToString();
                                    oCampos.RDRECONSIDERA = dr["RDRECONSIDERA"].ToString();
                                    oCampos.RDRECONSIDERA_PUBLICAR = dr["RDRECONSIDERA_PUBLICAR"].ToString();
                                    oCampos.RTFFS = dr["RTFFS"].ToString();
                                    oCampos.RTFFS_PUBLICAR = dr["RTFFS_PUBLICAR"].ToString();
                                    oCampos.REC_APELACION = dr["REC_APELACION"].ToString();
                                    oCampos.FECHA_EMISION = dr["FECHA_RDMEDIDAS"].ToString();
                                    oCampos.COD_DOC_SIADO = dr["COD_DOC_SIADO"].ToString();
                                    lsCEntidad.Add(oCampos);
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

        //profesional
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegProfesionalSelecionado(CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_BuscaPersona", oCEntidad))
                    {
                        if (dr != null)
                        {
                            oCampos = new CEntidad();
                            if (dr.HasRows)
                            {
                                int pt1 = dr.GetOrdinal("COD_PERSONA");
                                int pt2 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                                int pt3 = dr.GetOrdinal("N_DOCUMENTO");


                                while (dr.Read())
                                {
                                    //PARTE_DIARIO_DETALLE
                                    oCampos = new CEntidad();
                                    oCampos.COD_PROFESIONAL = dr.GetString(pt1);
                                    oCampos.APELLIDOS_NOMBRES = dr.GetString(pt2);
                                    oCampos.DESCRIPCION = dr.GetString(pt3);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> DatResolucionesEmitidas(CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ResolucionesEmitidas", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                int p1 = dr.GetOrdinal("ANIO");
                                int p2 = dr.GetOrdinal("INICIO_PAU");
                                int p3 = dr.GetOrdinal("TERMINO_PAU");
                                int p4 = dr.GetOrdinal("RECONSIDERACION");
                                int p5 = dr.GetOrdinal("OTROS");
                                int p6 = dr.GetOrdinal("TOTAL");
                                int p7 = dr.GetOrdinal("PROMEDIO");

                                CEntidad oCampos;
                                while (dr.Read())
                                {
                                    oCampos = new CEntidad();
                                    oCampos.ANIO = dr.GetString(p1);
                                    oCampos.INI_PAU = dr.GetInt32(p2);
                                    oCampos.TERMINO_PAU = dr.GetInt32(p3);
                                    oCampos.RECONSIDERACION = dr.GetInt32(p4);
                                    oCampos.OTROS = dr.GetInt32(p5);
                                    oCampos.TOTAL = dr.GetInt32(p6);
                                    oCampos.TOTAL_PRIMERO = dr.GetInt32(p7);
                                    lsCEntidad.Add(oCampos);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> DatFaltaInformeLegal(CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_InformeSupervisionOpinionLegal", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                int p1 = dr.GetOrdinal("NUMERO");
                                int p2 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                                int p3 = dr.GetOrdinal("INFORME");
                                int p4 = dr.GetOrdinal("descripcion");
                                int p5 = dr.GetOrdinal("FECHA_SUPERVISION_INICIO");

                                CEntidad oCampos;
                                while (dr.Read())
                                {
                                    oCampos = new CEntidad();
                                    oCampos.THABILITANTE = dr.GetString(p1);
                                    oCampos.APELLIDOS_NOMBRES = dr.GetString(p2);
                                    oCampos.CODIGO = dr.GetString(p3);
                                    oCampos.MODALIDAD = dr.GetString(p4);
                                    oCampos.FECHA_EMISION = dr.GetString(p5);
                                    lsCEntidad.Add(oCampos);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> DatInformexEspecialista(CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_InformesLegalesxEspecialista", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                if (oCEntidad.BusCriterio == "1")
                                {
                                    int p0 = dr.GetOrdinal("COD_PERSONA");
                                    int p1 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                                    int p2 = dr.GetOrdinal("IL_EVA_INF_SUP");
                                    int p3 = dr.GetOrdinal("IL_ETAPA_INSTRU");
                                    int p4 = dr.GetOrdinal("IL_CONFORMIDAD");
                                    int p5 = dr.GetOrdinal("IL_EVA_REC_RECONS");
                                    int p6 = dr.GetOrdinal("IL_OTROS");
                                    int p7 = dr.GetOrdinal("TOTAL");
                                    int p8 = dr.GetOrdinal("IL_FINAL");

                                    CEntidad oCampos;
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr.GetString(p0);
                                        oCampos.APELLIDOS_NOMBRES = dr.GetString(p1);
                                        oCampos.IL_EVA_INF_SUP = dr.GetInt32(p2);
                                        oCampos.IL_ETAPA_INSTRU = dr.GetInt32(p3);
                                        oCampos.IL_CONFORMIDAD = dr.GetInt32(p4);
                                        oCampos.IL_EVA_REC_RECONS = dr.GetInt32(p5);
                                        oCampos.IL_OTROS = dr.GetInt32(p6);
                                        oCampos.IL_FINAL = dr.GetInt32(p8);
                                        oCampos.TOTAL = dr.GetInt32(p7);
                                        lsCEntidad.Add(oCampos);
                                    }
                                }
                                else if (oCEntidad.BusCriterio == "2")
                                {
                                    int p1 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                                    int p2 = dr.GetOrdinal("CANT_CMADE");
                                    int p3 = dr.GetOrdinal("CANT_NM");
                                    int p4 = dr.GetOrdinal("CANT_FYR");
                                    int p5 = dr.GetOrdinal("CANT_ECO");
                                    int p6 = dr.GetOrdinal("CANT_CONS");
                                    int p7 = dr.GetOrdinal("CANT_CFAUNA");
                                    int p8 = dr.GetOrdinal("CANT_PFAUNA");
                                    int p9 = dr.GetOrdinal("CANT_TARA");
                                    int p10 = dr.GetOrdinal("CANT_BS");
                                    int p11 = dr.GetOrdinal("CANT_BL");
                                    int p12 = dr.GetOrdinal("CANT_PP");
                                    int p13 = dr.GetOrdinal("CANT_CCCC_CCNN");
                                    int p14 = dr.GetOrdinal("CANT_PNM");
                                    int p15 = dr.GetOrdinal("TOTAL");

                                    CEntidad oCampos;
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.APELLIDOS_NOMBRES = dr.GetString(p1);
                                        oCampos.CANT_CMADE = dr.GetInt32(p2);
                                        oCampos.CANT_NM = dr.GetInt32(p3);
                                        oCampos.CANT_FYR = dr.GetInt32(p4);
                                        oCampos.CANT_ECO = dr.GetInt32(p5);
                                        oCampos.CANT_CONS = dr.GetInt32(p6);
                                        oCampos.CANT_CFAUNA = dr.GetInt32(p7);
                                        oCampos.CANT_PFAUNA = dr.GetInt32(p8);
                                        oCampos.CANT_TARA = dr.GetInt32(p9);
                                        oCampos.CANT_BS = dr.GetInt32(p10);
                                        oCampos.CANT_BL = dr.GetInt32(p11);
                                        oCampos.CANT_PP = dr.GetInt32(p12);
                                        oCampos.CANT_CCCC_CCNN = dr.GetInt32(p13);
                                        oCampos.CANT_PNM = dr.GetInt32(p14);
                                        oCampos.TOTAL = dr.GetInt32(p15);
                                        oCampos.Tipo_Informe = dr.GetString(dr.GetOrdinal("TIPO"));
                                        lsCEntidad.Add(oCampos);
                                    }
                                }
                                else if (oCEntidad.BusCriterio == "3")
                                {
                                    if (dr != null)
                                    {
                                        if (dr.HasRows)
                                        {
                                            int p1 = dr.GetOrdinal("NUMERO");
                                            int p2 = dr.GetOrdinal("FECHA_EMISION");
                                            int p4 = dr.GetOrdinal("TITULAR");
                                            int p5 = dr.GetOrdinal("NUM_THABILITANTE");
                                            int p6 = dr.GetOrdinal("RECOMENDACION");
                                            int p7 = dr.GetOrdinal("MODALIDAD");
                                            int p8 = dr.GetOrdinal("TIPO");
                                            CEntidad oCampos;
                                            while (dr.Read())
                                            {
                                                oCampos = new CEntidad();
                                                oCampos.Numero_Inform = dr.GetString(p1);
                                                oCampos.FECHA_EMISION = dr.GetString(p2);
                                                oCampos.TITULAR = dr.GetString(p4);
                                                oCampos.THABILITANTE = dr.GetString(p5);
                                                oCampos.Recomendaciones = dr.GetString(p6);
                                                oCampos.MODALIDAD = dr.GetString(p7);
                                                oCampos.Tipo_Informe = dr.GetString(p8);
                                                oCampos.APELLIDOS_NOMBRES = dr.GetString(dr.GetOrdinal("APELLIDOS_NOMBRES"));
                                                lsCEntidad.Add(oCampos);
                                            }
                                        }
                                    }
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
        //infrome legal a por linea y año
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> DatInformeTecnicoLegalLinea(CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_InformeLegaLinea", oCEntidad))
                    {
                        if (dr != null)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.FECHA = dr["FECHA_REGISTRO"].ToString();
                                oCampos.N_DOCUMENTO = dr["NRO_INFORME"].ToString();
                                oCampos.TIPO_DOCUMENTO = dr["TIPO_INFORME"].ToString();
                                oCampos.Numero_Inform = dr["NUMERO"].ToString();
                                oCampos.FECHA_EMISION = dr["Fecha_Emision"].ToString();
                                oCampos.TITULAR = dr["Titular"].ToString();
                                oCampos.THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                oCampos.Recomendaciones = dr["RECOMENDACION"].ToString();
                                oCampos.Tipo_Informe = dr["Tipo"].ToString();
                                oCampos.APELLIDOS_NOMBRES = dr["profesionalNombre"].ToString();
                                oCampos.FIC_SIADO = dr["FIC_SIADO"].ToString();
                                oCampos.DESCRIPCION = dr["ESTADO"].ToString();
                                oCampos.OD = dr["OD"].ToString();
                                oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCampos.DEPARTAMENTO = dr["DEPARTAMENTO"].ToString();
                                oCampos.PROVINCIA = dr["PROVINCIA"].ToString();
                                oCampos.DISTRITO = dr["DISTRITO"].ToString();
                                lsCEntidad.Add(oCampos);
                            }

                            //}
                            //termina aqui el codigo insertado
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
        ///busqueda de informes de fiscalizacion a detalle
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> DatInformeTecnicoEspecialistaDetalle(CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_InformeSupervicionDetalleInformeTecnico", oCEntidad))
                    {
                        if (dr != null)
                        {
                            //modificando para mostrar detalle de informe
                            //   if (oCEntidad.BusCriterio == "3")
                            // {
                            int p1 = dr.GetOrdinal("NUMERO_INFORME");
                            int p2 = dr.GetOrdinal("FECHA_EMISION");
                            int p3 = dr.GetOrdinal("TITULAR");
                            int p4 = dr.GetOrdinal("NUM_THABILITANTE");
                            int p5 = dr.GetOrdinal("COD_PERSONA");
                            int p6 = dr.GetOrdinal("TIPO");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.Numero_Inform = dr.GetString(p1);
                                oCampos.FECHA_EMISION = dr.GetString(p2);
                                oCampos.TITULAR = dr.GetString(p3);
                                oCampos.THABILITANTE = dr.GetString(p4);
                                oCampos.COD_PROFESIONAL = dr.GetString(p5);
                                oCampos.Tipo_Informe = dr.GetString(p6);
                                oCampos.APELLIDOS_NOMBRES = dr.GetString(dr.GetOrdinal("APELLIDOS_NOMBRES"));
                                lsCEntidad.Add(oCampos);
                            }

                            //}
                            //termina aqui el codigo insertado
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
        public List<CEntidad> DatInformeTecnicoEspecialistaLinea(CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_InformeTecnicoLinea", oCEntidad))
                    {
                        if (dr != null)
                        {
                            //modificando para mostrar detalle de informe
                            //   if (oCEntidad.BusCriterio == "3")
                            // {
                            int p1 = dr.GetOrdinal("Numero_Informe");
                            int p2 = dr.GetOrdinal("Fecha_Emision");
                            int p3 = dr.GetOrdinal("Titular");
                            int p4 = dr.GetOrdinal("NUM_THABILITANTE");
                            int p6 = dr.GetOrdinal("Tipo");
                            int p7 = dr.GetOrdinal("Supervisor");
                            int p8 = dr.GetOrdinal("FIC_SIADO");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.Numero_Inform = dr.GetString(p1);
                                oCampos.FECHA_EMISION = dr.GetString(p2);
                                oCampos.TITULAR = dr.GetString(p3);
                                oCampos.THABILITANTE = dr.GetString(p4);
                                oCampos.Tipo_Informe = dr.GetString(p6);
                                oCampos.APELLIDOS_NOMBRES = dr.GetString(p7);
                                oCampos.FIC_SIADO = dr.GetString(p8);
                                lsCEntidad.Add(oCampos);
                            }

                            //}
                            //termina aqui el codigo insertado
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
        public List<CEntidad> DatInformeTecnicoxEspecialista(CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_InformeTecnicoxEspecialista", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                if (oCEntidad.BusCriterio == "1")
                                {
                                    int p0 = dr.GetOrdinal("COD_PERSONA");
                                    int p1 = dr.GetOrdinal("apellidos_nombres");
                                    int p2 = dr.GetOrdinal("Evaluacion_de_Descargo");
                                    int p3 = dr.GetOrdinal("Informe_de_Aclaración");
                                    int p4 = dr.GetOrdinal("Informe_Complementario");
                                    int p5 = dr.GetOrdinal("Otros");
                                    int p6 = dr.GetOrdinal("Total");
                                    int p7 = dr.GetOrdinal("Informe_Multa");

                                    CEntidad oCampos;
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr.GetString(p0);
                                        oCampos.APELLIDOS_NOMBRES = dr.GetString(p1);
                                        oCampos.IL_EVA_INF_SUP = dr.GetInt32(p2);
                                        oCampos.IL_ETAPA_INSTRU = dr.GetInt32(p3);
                                        oCampos.IL_CONFORMIDAD = dr.GetInt32(p4);
                                        oCampos.OTROS = dr.GetInt32(p5);
                                        oCampos.TOTAL = dr.GetInt32(p6);
                                        oCampos.TOTAL_PRIMERO = dr.GetInt32(p7);
                                        lsCEntidad.Add(oCampos);
                                    }
                                }
                                else
                                {
                                    if (oCEntidad.BusCriterio == "2")
                                    {
                                        int p1 = dr.GetOrdinal("apellidos_nombres");
                                        int p2 = dr.GetOrdinal("Maderable");
                                        int p3 = dr.GetOrdinal("No_Maderable");
                                        int p4 = dr.GetOrdinal("Forestacion_Reforestacion");
                                        int p5 = dr.GetOrdinal("Ecoturismo");
                                        int p6 = dr.GetOrdinal("Conservacion");
                                        int p7 = dr.GetOrdinal("Fauna_Silvestre_CON");
                                        int p8 = dr.GetOrdinal("Fauna_Silvestre_PER");
                                        int p9 = dr.GetOrdinal("Tara");
                                        int p10 = dr.GetOrdinal("Bosques_Secos");
                                        int p11 = dr.GetOrdinal("bosques_locales");
                                        int p12 = dr.GetOrdinal("Predio_Privado");
                                        int p13 = dr.GetOrdinal("Comunidad_Campesina_nativa");
                                        int p14 = dr.GetOrdinal("Total");

                                        CEntidad oCampos;
                                        while (dr.Read())
                                        {
                                            oCampos = new CEntidad();
                                            oCampos.APELLIDOS_NOMBRES = dr.GetString(p1);
                                            oCampos.CANT_CMADE = dr.GetInt32(p2);
                                            oCampos.CANT_NM = dr.GetInt32(p3);
                                            oCampos.CANT_FYR = dr.GetInt32(p4);
                                            oCampos.CANT_ECO = dr.GetInt32(p5);
                                            oCampos.CANT_CONS = dr.GetInt32(p6);
                                            oCampos.CANT_CFAUNA = dr.GetInt32(p7);
                                            oCampos.CANT_PFAUNA = dr.GetInt32(p8);
                                            oCampos.CANT_TARA = dr.GetInt32(p9);
                                            oCampos.CANT_BS = dr.GetInt32(p10);
                                            oCampos.CANT_BL = dr.GetInt32(p11);
                                            oCampos.CANT_PP = dr.GetInt32(p12);
                                            oCampos.CANT_CCCC_CCNN = dr.GetInt32(p13);
                                            oCampos.TOTAL = dr.GetInt32(p14);
                                            oCampos.Tipo_Informe = dr.GetString(dr.GetOrdinal("TIPO"));
                                            lsCEntidad.Add(oCampos);
                                        }
                                    }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> DatRecursoImpugatorio(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_RecursosImpugnatoriosnw", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            if (oCEntidad.BusCriterio == "N")
                            {
                                int p1 = dr.GetOrdinal("ANIO");
                                int p2 = dr.GetOrdinal("RECURSO_RECONSIDERACION");
                                int p7 = dr.GetOrdinal("APELACION");
                                int p8 = dr.GetOrdinal("TOTAL");

                                CEntidad oCampos;
                                while (dr.Read())
                                {
                                    oCampos = new CEntidad();
                                    oCampos.ANIO = dr.GetString(p1);
                                    oCampos.RECONSIDERACION = dr.GetInt32(p2);
                                    oCampos.TOTAL_PRIMERO = dr.GetInt32(p7);
                                    oCampos.TOTAL = dr.GetInt32(p8);
                                    lsCEntidad.Add(oCampos);
                                }
                            }
                            else
                            {
                                int p1 = dr.GetOrdinal("TITULAR");
                                int p2 = dr.GetOrdinal("NUM_THABILITANTE");
                                int p6 = dr.GetOrdinal("NUMERO_EXPEDIENTE");
                                int p3 = dr.GetOrdinal("NUMERO_RESOLUCION");
                                int p4 = dr.GetOrdinal("FECHA");
                                int p5 = dr.GetOrdinal("NUMERO_INFTIT");

                                CEntidad oCampos;
                                while (dr.Read())
                                {
                                    oCampos = new CEntidad();
                                    oCampos.APELLIDOS_NOMBRES = dr.GetString(p1);
                                    oCampos.THABILITANTE = dr.GetString(p2);
                                    oCampos.NUMERO_EXPEDIENTE = dr.GetString(p6);
                                    oCampos.INICIO_PAU = dr.GetString(p3); //TOMO COMO VARIABLE INICIO PAU PERO RECOJO EL RD DE TERMINO
                                    oCampos.FECHA_EMISION = dr.GetString(p4);
                                    oCampos.DESCRIPCION = dr.GetString(p5);
                                    lsCEntidad.Add(oCampos);
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
        #region "Estado Informe Supervisión"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidad> DatEstadoInforme(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_EstadoInformeSupervision", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    int pt1 = dr.GetOrdinal("INFORME");
        //                    int pt2 = dr.GetOrdinal("MODALIDAD");
        //                    int pt3 = dr.GetOrdinal("TITULAR");
        //                    int pt4 = dr.GetOrdinal("THABILITANTE");
        //                    int pt5 = dr.GetOrdinal("DEPARTAMENTO");
        //                    int pt6 = dr.GetOrdinal("INFORME_LEGAL");
        //                    int pt7 = dr.GetOrdinal("RECOMIENDA");
        //                    int pt8 = dr.GetOrdinal("RD_INICIO");
        //                    int pt9 = dr.GetOrdinal("RD_AMPLICACION");
        //                    int pt10 = dr.GetOrdinal("EXPEDIENTE");
        //                    int pt11 = dr.GetOrdinal("FECHA_NOTIFICA_TITULAR");
        //                    int pt12 = dr.GetOrdinal("FECHA_PRESENTACION");
        //                    int pt13 = dr.GetOrdinal("INFORME_TECNICO");
        //                    int pt14 = dr.GetOrdinal("ILEGAL_TERMINO");
        //                    int pt15 = dr.GetOrdinal("INF_DETERMINACION_MULTA");
        //                    int pt16 = dr.GetOrdinal("RD_TERMINO");
        //                    int pt17 = dr.GetOrdinal("DETERMINACION_RD");
        //                    int pt18 = dr.GetOrdinal("FECHA_NOTIFICACION_TERMINO");
        //                    int pt19 = dr.GetOrdinal("FECHA_RECURSO_RECONSIDERACION");
        //                    int pt20 = dr.GetOrdinal("FECHA_APELACION");
        //                    int pt21 = dr.GetOrdinal("INF_LEGAL_EVALUCION_RC");
        //                    int pt22 = dr.GetOrdinal("RD_RECURSO_RECONSIDERACION");

        //                    CEntidad oCampos;
        //                    while (dr.Read())
        //                    {
        //                        //PARTE_DIARIO_DETALLE
        //                        oCampos = new CEntidad();
        //                        oCampos.INFORME_SUPERVISION = dr.GetString(pt1);
        //                        oCampos.MODALIDAD = dr.GetString(pt2);
        //                        oCampos.TITULAR = dr.GetString(pt3);
        //                        oCampos.THABILITANTE = dr.GetString(pt4);
        //                        oCampos.REGION = dr.GetString(pt5);
        //                        oCampos.INFOR_LEGAL_EVALUCION_IS = dr.GetString(pt6);
        //                        oCampos.DETERMINACION_IL = dr.GetString(pt7);
        //                        oCampos.RD_INICIO = dr.GetString(pt8);
        //                        oCampos.RD_AMPLIACION = dr.GetString(pt9);
        //                        oCampos.EXPED_ADMN = dr.GetString(pt10);
        //                        oCampos.FEC_NOTIF_RD_INICIO = dr.GetString(pt11);
        //                        oCampos.FEC_DESCARGO = dr.GetString(pt12); ;
        //                        oCampos.INFORME_TECNICO = dr.GetString(pt13);
        //                        oCampos.ILEGAL_TERMINO = dr.GetString(pt14);
        //                        oCampos.ILEGAL_DETER = dr.GetString(pt15);
        //                        oCampos.RD_TERMINO = dr.GetString(pt16);
        //                        oCampos.RD_TERMINO_DETER = dr.GetString(pt17);
        //                        oCampos.FEC_NOTIF_RD_TERMINO = dr.GetString(pt18);
        //                        oCampos.FEC_RECONSIRECACION = dr.GetString(pt19);
        //                        oCampos.FEC_APELACION = dr.GetString(pt20);
        //                        oCampos.ILEGAL_RECONSIDERA = dr.GetString(pt21);
        //                        oCampos.RD_RECONSIDERA = dr.GetString(pt22);

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
        #endregion
        #region "Archivos"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> DatArchivos(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_Archivados", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;

                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.ANIO = dr.GetString(dr.GetOrdinal("ANIO_INFORME"));
                                oCampos.NARCHIVO_INFORME = dr.GetInt32(dr.GetOrdinal("NARCHIVO_INFORME"));
                                oCampos.NARCHIVO_PRIMERA = dr.GetInt32(dr.GetOrdinal("NARCHIVO_PRIMERA"));
                                oCampos.NARCHIVO_SEGUNDA = dr.GetInt32(dr.GetOrdinal("NARCHIVO_SEGUNDA"));
                                oCampos.TOTAL = dr.GetInt32(dr.GetOrdinal("TOTAL"));

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
        public List<CEntidad> DatArchivosDetalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_Archivados", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;

                            switch (oCEntidad.TIPO_ARCHIVADO)
                            {
                                case "NARCHIVO_INFORME":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.Numero_Inform = dr.GetString(dr.GetOrdinal("NUM_INFORME"));
                                        oCampos.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                        oCampos.THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                        oCampos.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                        oCampos.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                        oCampos.PROVINCIA = dr.GetString(dr.GetOrdinal("PROVINCIA"));
                                        oCampos.DISTRITO = dr.GetString(dr.GetOrdinal("DISTRITO"));
                                        oCampos.MOTIVO = dr.GetString(dr.GetOrdinal("MOTIVO"));
                                        oCampos.Tipo_Informe = dr.GetString(dr.GetOrdinal("TIPO_INFORME"));
                                        oCampos.ANIO = dr.GetString(dr.GetOrdinal("ANIO_INFORME"));
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                case "NARCHIVO_PRIMERA":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.NUMERO_RD = dr.GetString(dr.GetOrdinal("NUM_RESOLUCION"));
                                        oCampos.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                        oCampos.THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                        oCampos.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                        oCampos.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                        oCampos.PROVINCIA = dr.GetString(dr.GetOrdinal("PROVINCIA"));
                                        oCampos.DISTRITO = dr.GetString(dr.GetOrdinal("DISTRITO"));
                                        oCampos.NUMERO_EXPEDIENTE = dr.GetString(dr.GetOrdinal("NUM_EXPEDIENTE"));
                                        oCampos.MOTIVO = dr.GetString(dr.GetOrdinal("MOTIVO"));
                                        oCampos.ANIO = dr.GetString(dr.GetOrdinal("ANIO_INFORME"));
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                case "NARCHIVO_SEGUNDA":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.RTFFS = dr.GetString(dr.GetOrdinal("NUM_RTFFS"));
                                        oCampos.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                        oCampos.THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                        oCampos.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                        oCampos.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                        oCampos.PROVINCIA = dr.GetString(dr.GetOrdinal("PROVINCIA"));
                                        oCampos.DISTRITO = dr.GetString(dr.GetOrdinal("DISTRITO"));
                                        oCampos.NUMERO_EXPEDIENTE = dr.GetString(dr.GetOrdinal("NUM_EXPEDIENTE"));
                                        oCampos.NUMERO_RD = dr.GetString(dr.GetOrdinal("NUM_RESOLUCION"));
                                        oCampos.MOTIVO = dr.GetString(dr.GetOrdinal("MOTIVO"));
                                        oCampos.ANIO = dr.GetString(dr.GetOrdinal("ANIO_INFORME"));
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                default:
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                        oCampos.THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                        oCampos.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                        oCampos.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                        oCampos.PROVINCIA = dr.GetString(dr.GetOrdinal("PROVINCIA"));
                                        oCampos.DISTRITO = dr.GetString(dr.GetOrdinal("DISTRITO"));
                                        oCampos.MOTIVO = dr.GetString(dr.GetOrdinal("MOTIVO"));
                                        oCampos.ANIO = dr.GetString(dr.GetOrdinal("ANIO_INFORME"));
                                        oCampos.TIPO_ARCHIVADO = dr.GetString(dr.GetOrdinal("TIPO_ARCHIVADO"));
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
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
        #endregion
        #region Notificaciones
        public List<CEntidad> DatReporteNotificaciones(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_Notificaciones", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;

                            switch (oCEntidad.TIPO_REPORTE)
                            {
                                case "REPORTE_NOTIFICACIONES":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                        oCampos.FECHA_CREACION = dr.GetDateTime(dr.GetOrdinal("FECHA_CREACION")).ToString();
                                        oCampos.TIPO_DOCUMENTO = dr.GetString(dr.GetOrdinal("TIPO_DOCUMENTO"));
                                        oCampos.N_DOC = dr.GetString(dr.GetOrdinal("N_DOC"));
                                        oCampos.DESTINATARIO = dr.GetString(dr.GetOrdinal("DESTINATARIO"));
                                        oCampos.DIRECCION = dr.GetString(dr.GetOrdinal("DIRECCION"));
                                        oCampos.FECHA_ADMINISTRADO = dr.GetString(dr.GetOrdinal("FECHA_ADMINISTRADO"));
                                        oCampos.FECHA_PRIMERA_VISITA = dr["FECHA_PRIMERA_VISITA"] is DBNull ? string.Empty : dr["FECHA_PRIMERA_VISITA"].ToString();//dr.GetString(dr.GetOrdinal("FECHA_PRIMERA_VISITA"));
                                        oCampos.FECHA_SEGUNDA_VISITA = dr["FECHA_SEGUNDA_VISITA"] is DBNull ? string.Empty : dr["FECHA_SEGUNDA_VISITA"].ToString();//dr.GetString(dr.GetOrdinal("FECHA_SEGUNDA_VISITA"));
                                        oCampos.PERSONA_NOT = dr.GetString(dr.GetOrdinal("PERSONA_NOT"));
                                        oCampos.VINCULO = dr.GetString(dr.GetOrdinal("VINCULO"));
                                        oCampos.DIRECCION_NOT = dr.GetString(dr.GetOrdinal("DIRECCION_NOT"));
                                        oCampos.VARIACION_DOMICILIO = dr.GetString(dr.GetOrdinal("VARIACION_DOMICILIO"));
                                        oCampos.OD_RESPONSABLE = dr.GetString(dr.GetOrdinal("OD_RESPONSABLE"));
                                        oCampos.ESTADO = dr.GetString(dr.GetOrdinal("ESTADO"));
                                        oCampos.OBSERVACIONES = dr.GetString(dr.GetOrdinal("OBSERVACIONES"));                                        
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;                                
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
        #endregion

        //Caducidad

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad Dat_Caducidad(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_Caducidad", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        oCampos.ListGeneral = new List<CEntidad>();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                oCamposDet.CADUCADOS = dr.GetInt32(dr.GetOrdinal("CADUCADOS"));
                                oCampos.ListGeneral.Add(oCamposDet);
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
        public List<CEntidad> Dat_CaducidadDetalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> olCampos = new List<CEntidad>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_CaducidadDetalle", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.TH_NUMERO = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                                oCamposDet.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                oCamposDet.DEPARTAMENTO = dr.GetString(dr.GetOrdinal("DEPARTAMENTO"));
                                oCamposDet.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                oCamposDet.TITULAR_SANCIONADO = dr.GetString(dr.GetOrdinal("TITULAR_SANCIONADO"));
                                oCamposDet.RDCADUCA = dr.GetString(dr.GetOrdinal("RDCADUCA"));
                                oCamposDet.FECHA_EMISION = dr.GetString(dr.GetOrdinal("FECHA_RDCADUCA"));
                                oCamposDet.RDCADUCA_PUBLICAR = dr.GetString(dr.GetOrdinal("RDCADUCA_PUBLICAR"));
                                oCamposDet.RDRECONSIDERA = dr.GetString(dr.GetOrdinal("RDRECONSIDERA"));
                                oCamposDet.RDRECONSIDERA_PUBLICAR = dr.GetString(dr.GetOrdinal("RDRECONSIDERA_PUBLICAR"));
                                oCamposDet.RTFFS = dr.GetString(dr.GetOrdinal("RTFFS"));
                                oCamposDet.RTFFS_PUBLICAR = dr.GetString(dr.GetOrdinal("RTFFS_PUBLICAR"));
                                //oCamposDet.REC_APELACION = dr.GetString(dr.GetOrdinal("REC_APELACION"));
                                oCamposDet.PROVEIDO = dr.GetString(dr.GetOrdinal("PROVEIDO"));
                                oCamposDet.PROVEIDO_FECHA = dr.GetString(dr.GetOrdinal("PROVEIDO_FECHA"));

                                oCamposDet.CADUCIDAD = dr.GetString(dr.GetOrdinal("CADUCIDAD"));
                                olCampos.Add(oCamposDet);
                            }
                        }
                    }
                }
                return olCampos;
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
        public List<CEntPAU> Dat_Expedientes_NumeroPAU_concluidos(OracleConnection cn, CEntPAU oCEntidad)
        {
            try
            {
                String procedConsulta = "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_SupervisionesDetalle2";
                return Devuelve_Listas_PAU_Concluidos(cn, oCEntidad, procedConsulta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntPAU> Dat_Expedientes_NumeroPAU_concluidos_resumen(OracleConnection cn, CEntPAU oCEntidad)
        {
            try
            {
                String procedConsulta = "DOC_OSINFOR_ERP_MIGRACION.spReportePAUConcluidoResumen";
                return Devuelve_Listas_PAU_Concluidos(cn, oCEntidad, procedConsulta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<CEntPAU> Devuelve_Listas_PAU_Concluidos(OracleConnection cn, CEntPAU oCEntidad, String procedimiento)
        {

            List<CEntPAU> lsCEntidad = new List<CEntPAU>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, procedimiento, oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntPAU oCampos;
                            if (oCEntidad.BusCriterio == "RESUMEN")
                            {
                                while (dr.Read())
                                {
                                    oCampos = new CEntPAU();
                                    oCampos.ANIO = dr["ANIO"].ToString();
                                    oCampos.SUPERVISION = Int32.Parse(dr["SUPERVISION"].ToString());
                                    oCampos.ARCHIVO_PRELIMINAR = Int32.Parse(dr["ARCHIVO_PRELIMINAR"].ToString());
                                    oCampos.INI_PAU = Int32.Parse(dr["INICIOPAU"].ToString());
                                    oCampos.SUPER_TERMINADO_PAU = Int32.Parse(dr["SUPER_TERMINADO_PAU"].ToString());
                                    oCampos.CANTIDAD = Int32.Parse(dr["PROCESOS"].ToString());
                                    oCampos.AVANCE = Decimal.Parse(dr["PORCENTAJE"].ToString());
                                    oCampos.TERMINO_PAU = Int32.Parse(dr["PAU_CONCLUIDOS"].ToString());
                                    oCampos.CASOS = Int32.Parse(dr["CASOS"].ToString());
                                    oCampos.AVANCE1 = dr.IsDBNull(8) ? 0 : dr.GetDecimal(8); //Decimal.Parse(dr["PORCENTAJE_PAU_FIN"]);
                                    oCampos.AVANCE_CASOS = Math.Round(((oCampos.SUPERVISION) == 0 ? 0 : ((Decimal)(oCampos.CASOS) / (Decimal)(oCampos.SUPERVISION))),4);
                                    lsCEntidad.Add(oCampos);
                                }
                            }
                            else if (oCEntidad.BusCriterio == "DETALLADO")
                            {
                                while (dr.Read())
                                {
                                    oCampos = new CEntPAU();
                                    oCampos.ANIO = dr["ANIO"].ToString();
                                    oCampos.SUPERVISION = Int32.Parse(dr["SUPERVISION"].ToString());
                                    oCampos.ARCHIVO_PRELIMINAR = Int32.Parse(dr["ARCHIVO_PRELIMINAR"].ToString());
                                    oCampos.INI_PAU = Int32.Parse(dr["INICIOPAU"].ToString());
                                    oCampos.CANTIDAD = Int32.Parse(dr["PROCESOS"].ToString());
                                    oCampos.AVANCE = Decimal.Parse(dr["PORCENTAJE"].ToString());
                                    oCampos.TERMINO_PAU = Int32.Parse(dr["PAU_CONCLUIDOS"].ToString());
                                    oCampos.SANCIONADO_PAU = Int32.Parse(dr["SANCIONADO_PAU"].ToString());
                                    oCampos.MED_CORREC_PAU = Int32.Parse(dr["MED_CORREC_PAU"].ToString());
                                    oCampos.AMONEST_PAU = Int32.Parse(dr["AMONEST_PAU"].ToString());
                                    oCampos.CADUCADO_PAU = Int32.Parse(dr["CADUCADO_PAU"].ToString());
                                    oCampos.CADUCADO_PAU_TH = Int32.Parse(dr["CADUCADO_PAU_TH"].ToString());
                                    oCampos.CADUCADO_PAU_TH_PRV = Int32.Parse(dr["CADUCADO_PAU_TH_PRV"].ToString());
                                    oCampos.ARCHIVO_PAU = Int32.Parse(dr["ARCHIVO_PAU"].ToString());
                                    oCampos.AVANCE1 = Decimal.Parse(dr["PORCENTAJE_PAU_FIN"].ToString());
                                    oCampos.ARCHIVO_PRELIMINAR_SIN = Int32.Parse(dr["ARCHIVO_PRELIMINAR_SIN"].ToString());
                                    oCampos.SUPER_TERMINADO_PAU = Int32.Parse(dr["SUPER_TERMINADO_PAU"].ToString());
                                    oCampos.MEDCAU_PAU = Int32.Parse(dr["MEDCAU_PAU"].ToString());
                                    oCampos.CASOS = Int32.Parse(dr["CASOS"].ToString());
                                    oCampos.AVANCE_CASOS = Math.Round(((oCampos.SUPERVISION) == 0 ? 0 : ((Decimal)(oCampos.CASOS) / (Decimal)(oCampos.SUPERVISION))), 4);
                                    oCampos.SANCIONADO_PAU_1RA = Int32.Parse(dr["SANCIONADO_PAU_1RA"].ToString());
                                    oCampos.SANCIONADO_PAU_2DA = Int32.Parse(dr["SANCIONADO_PAU_2DA"].ToString());
                                    //oCampos.UIT_TER_PAU = Int32.Parse(dr["UIT_TER_PAU"].ToString());

                                    try
                                    {
                                        oCampos.MONTO_MULTA = Decimal.Parse(dr["MONTO_MULTA"].ToString());
                                        oCampos.MONTO_MULTA_FINAL = Decimal.Parse(dr["MONTO_MULTA_FINAL"].ToString());
                                        oCampos.MONTO_MULTA_FIRME = Decimal.Parse(dr["MONTO_MULTA_FIRME"].ToString());
                                    }
                                    catch (Exception)
                                    {
                                        oCampos.MONTO_MULTA = 0;
                                        oCampos.MONTO_MULTA_FINAL = 0;
                                        oCampos.MONTO_MULTA_FIRME = 0;
                                    }

                                    lsCEntidad.Add(oCampos);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCamposEntrada"></param>
        /// <returns></returns>
        public CEntidad Dat_Expedientes_Administrativos(OracleConnection cn, CEntidad oCamposEntrada)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ExpedientesEvaluadosExecute", oCamposEntrada))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalles;
                        CEntidad oCamposDet;
                        //Tipor de Modalidad
                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("ANIO");
                            int pt2 = dr.GetOrdinal("EXPEDIENTE");
                            int pt3 = dr.GetOrdinal("EMITIRLEGAL");
                            int pt4 = dr.GetOrdinal("EMITIRIMPOSICION");
                            int pt5 = dr.GetOrdinal("PAU_CONCLUIDOS");
                            int pt6 = dr.GetOrdinal("AVANCE");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.ANIO = dr.GetString(pt1);
                                oCamposDet.EXPEDIENTE = dr.GetInt32(pt2);
                                oCamposDet.EMITIRLEGAL = dr.GetInt32(pt3);
                                oCamposDet.EMITIRIMPOSICION = dr.GetInt32(pt4);
                                oCamposDet.PAU_CONCLUIDOS = dr.GetInt32(pt5);
                                oCamposDet.AVANCE = dr.GetDecimal(pt6);
                                lsDetDetalles.Add(oCamposDet);
                            }
                        }
                        oCampos.ListExpedientesEvaluados = lsDetDetalles;

                        dr.NextResult();
                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pts1 = dr.GetOrdinal("ANIO");
                            int pts2 = dr.GetOrdinal("SUPERVISIONES");
                            int pts3 = dr.GetOrdinal("2010");
                            int pts4 = dr.GetOrdinal("2011");
                            int pts5 = dr.GetOrdinal("2012");
                            int pts6 = dr.GetOrdinal("2013");
                            int pts7 = dr.GetOrdinal("2014");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.ANIO = dr.GetString(pts1);
                                oCamposDet.SUPERVISION = dr.GetInt32(pts2);
                                oCamposDet.DOSMILDIEZ = dr.GetDouble(pts3);
                                oCamposDet.DOSMILONCE = dr.GetDouble(pts4);
                                oCamposDet.DOSMILDOCE = dr.GetDouble(pts5);
                                oCamposDet.DOSMILTRECE = dr.GetDouble(pts6);
                                oCamposDet.DOSMILCATORCE = dr.GetDouble(pts7);
                                lsDetDetalles.Add(oCamposDet);
                            }
                            oCampos.ListExpedientesEvaluadosHistorial = lsDetDetalles;
                        }

                        dr.NextResult();
                        lsDetDetalles = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt3 = dr.GetOrdinal("ENERO");
                            int pt4 = dr.GetOrdinal("FEBRERO");
                            int pt5 = dr.GetOrdinal("MARZO");
                            int pt6 = dr.GetOrdinal("ABRIL");
                            int pt7 = dr.GetOrdinal("MAYO");
                            int pt8 = dr.GetOrdinal("JUNIO");
                            int pt9 = dr.GetOrdinal("JULIO");
                            int pt10 = dr.GetOrdinal("AGOSTO");
                            int pt11 = dr.GetOrdinal("SETIEMBRE");
                            int pt12 = dr.GetOrdinal("OCTUBRE");
                            int pt13 = dr.GetOrdinal("NOVIEMBRE");
                            int pt14 = dr.GetOrdinal("DICIEMBRE");
                            int valor = 0;
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.ANIO = oCampos.ListExpedientesEvaluadosHistorial[valor].ANIO;
                                oCamposDet.SUPERVISION = oCampos.ListExpedientesEvaluadosHistorial[valor].SUPERVISION;
                                oCamposDet.ENERO = dr.GetDouble(pt3) + oCampos.ListExpedientesEvaluadosHistorial[valor].DOSMILTRECE;
                                oCamposDet.FEBRERO = dr.GetDouble(pt4) == 0 ? dr.GetDouble(pt4) : dr.GetDouble(pt4) + oCamposDet.ENERO;
                                oCamposDet.MARZO = dr.GetDouble(pt5) == 0 ? dr.GetDouble(pt5) : dr.GetDouble(pt5) + dr.GetDouble(pt4) + oCamposDet.ENERO;
                                oCamposDet.ABRIL = dr.GetDouble(pt6) == 0 ? dr.GetDouble(pt6) : dr.GetDouble(pt6) + dr.GetDouble(pt5) + dr.GetDouble(pt4) + oCamposDet.ENERO;
                                oCamposDet.MAYO = dr.GetDouble(pt7) == 0 ? dr.GetDouble(pt7) : dr.GetDouble(pt7) + dr.GetDouble(pt6) + dr.GetDouble(pt5) + dr.GetDouble(pt4) + oCamposDet.ENERO;
                                oCamposDet.JUNIO = dr.GetDouble(pt8) == 0 ? dr.GetDouble(pt8) : dr.GetDouble(pt8) + dr.GetDouble(pt7) + dr.GetDouble(pt6) + dr.GetDouble(pt5) + dr.GetDouble(pt4) + oCamposDet.ENERO;
                                oCamposDet.JULIO = dr.GetDouble(pt9) == 0 ? dr.GetDouble(pt9) : dr.GetDouble(pt8) + dr.GetDouble(pt7) + dr.GetDouble(pt6) + dr.GetDouble(pt5) + dr.GetDouble(pt4) + oCamposDet.ENERO;
                                oCamposDet.AGOSTO = dr.GetDouble(pt10) == 0 ? dr.GetDouble(pt10) : dr.GetDouble(pt10) + dr.GetDouble(pt9) + dr.GetDouble(pt8) + dr.GetDouble(pt7) + dr.GetDouble(pt6) + dr.GetDouble(pt5) + dr.GetDouble(pt4) + oCamposDet.ENERO;
                                oCamposDet.SETIEMBRE = dr.GetDouble(pt11) == 0 ? dr.GetDouble(pt11) : dr.GetDouble(pt11) + dr.GetDouble(pt10) + dr.GetDouble(pt9) + dr.GetDouble(pt8) + dr.GetDouble(pt7) + dr.GetDouble(pt6) + dr.GetDouble(pt5) + dr.GetDouble(pt4) + oCamposDet.ENERO;
                                oCamposDet.OCTUBRE = dr.GetDouble(pt12) == 0 ? dr.GetDouble(pt12) : dr.GetDouble(pt12) + dr.GetDouble(pt11) + dr.GetDouble(pt10) + dr.GetDouble(pt9) + dr.GetDouble(pt8) + dr.GetDouble(pt7) + dr.GetDouble(pt6) + dr.GetDouble(pt5) + dr.GetDouble(pt4) + oCamposDet.ENERO;
                                oCamposDet.NOVIEMBRE = dr.GetDouble(pt13) == 0 ? dr.GetDouble(pt13) : dr.GetDouble(pt13) + dr.GetDouble(pt12) + dr.GetDouble(pt11) + dr.GetDouble(pt10) + dr.GetDouble(pt9) + dr.GetDouble(pt8) + dr.GetDouble(pt7) + dr.GetDouble(pt6) + dr.GetDouble(pt5) + dr.GetDouble(pt4) + oCamposDet.ENERO;
                                oCamposDet.DICIEMBRE = dr.GetDouble(pt14) == 0 ? dr.GetDouble(pt14) : dr.GetDouble(pt14) + dr.GetDouble(pt13) + dr.GetDouble(pt12) + dr.GetDouble(pt11) + dr.GetDouble(pt10) + dr.GetDouble(pt9) + dr.GetDouble(pt8) + dr.GetDouble(pt7) + dr.GetDouble(pt6) + dr.GetDouble(pt5) + dr.GetDouble(pt4) + oCamposDet.ENERO;
                                lsDetDetalles.Add(oCamposDet);
                                valor = valor + 1;
                            }
                            oCampos.ListExpedientesEvaluadosAñoActual = lsDetDetalles;
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
        public List<CEntidad> DatResolucionesEmitidasRRE(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ResolucionesEmitidas", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("ANIO");
                            int p2 = dr.GetOrdinal("INICIO_PAU");
                            int p3 = dr.GetOrdinal("TERMINO_PAU");
                            int p4 = dr.GetOrdinal("RECONSIDERACION");
                            int p5 = dr.GetOrdinal("ARCHIVO");
                            int p6 = dr.GetOrdinal("AMPLIACION_PAU");
                            int p7 = dr.GetOrdinal("RECTIFICACION");
                            int p8 = dr.GetOrdinal("MEDIDAS_CAUTELARES");
                            int p9 = dr.GetOrdinal("OTROS");
                            int p10 = dr.GetOrdinal("TOTAL");
                            int p11 = dr.GetOrdinal("PROMEDIO");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.BusAnio = dr.GetString(p1);
                                oCampos.INI_PAU = dr.GetInt32(p2);
                                oCampos.TERMINO_PAU = dr.GetInt32(p3);
                                oCampos.RECONSIDERACION = dr.GetInt32(p4);
                                oCampos.CANTIDAD = dr.GetInt32(p5);//archivo
                                oCampos.CATEGORIA = dr.GetInt32(p6);//ampliacion pau
                                oCampos.RECTIFICACION = dr.GetInt32(p7);//rectificacion
                                oCampos.MED_CAU = dr.GetInt32(p8);//medidas cautelares
                                oCampos.OTROS = dr.GetInt32(p9);
                                oCampos.TOTAL = dr.GetInt32(p10);
                                oCampos.PROMEDIO = dr.GetInt32(p11);
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
        public List<CEntidad> DatDetEmisionResolucionRRE2(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_ResolucionesEmitidasDetalle01", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.FECHA = dr["FECHA_REGISTRO"].ToString();
                                oCampos.THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
                                oCampos.DEPARTAMENTO = dr["DEPARTAMENTO"].ToString();
                                oCampos.PROVINCIA = dr["PROVINCIA"].ToString();
                                oCampos.DISTRITO = dr["DISTRITO"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.TIPO_RD = dr["DESCRIPCION"].ToString();
                                oCampos.NUMERO_RD = dr["NUMERO_RESOLUCION"].ToString();
                                oCampos.FECHA_EMISION = dr["FECHA_EMISION"].ToString();
                                oCampos.PERSONA_NOTIFICADA = dr["PERSONA_NOTIFICADA"].ToString();
                                oCampos.NOTIFICACION_OCI = dr["NOTIFICACION_OCI"].ToString();
                                oCampos.NUMERO_INFORME_SUPERV = dr["informe_supervision"].ToString();
                                oCampos.DESCRIPCION = dr["ESTADO"].ToString();
                                oCampos.NUMERO_EXPEDIENTE = dr["NUMERO_EXPEDIENTE"].ToString();
                                oCampos.GRAVEDAD = dr["GRAVEDAD"].ToString();
                                oCampos.FIC_SIADO = dr["FIC_SIADO"].ToString();

                                oCampos.INFORMACION_FALSA_INEX = dr["INFORMACION_FALSA_INEX"].ToString();
                                oCampos.INFORMACION_FALSA_DIF = dr["INFORMACION_FALSA_DIF"].ToString();
                                oCampos.INFORMACION_FALSA_DAS = dr["INFORMACION_FALSA_DAS"].ToString();
                                oCampos.INFORMACION_FALSA_T = dr["INFORMACION_FALSA_T"].ToString();
                                oCampos.DESCRIPCION_INFORMACION_FALSA = dr["DESCRIPCION_INFORMACION_FALSA"].ToString();
                                oCampos.ATFFS = dr["ATFFS"].ToString();
                                oCampos.DETALLE_ATFFS = dr["DETALLE_ATFFS"].ToString();
                                oCampos.OCI = dr["OCI"].ToString();
                                oCampos.DETALLE_OCI = dr["DETALLE_OCI"].ToString();
                                oCampos.DGFFS = dr["DGFFS"].ToString();
                                oCampos.DETALLE_DGFFS = dr["DETALLE_DGFFS"].ToString();
                                oCampos.PROGRAMA_REGIONAL = dr["PROGRAMA_REGIONAL"].ToString();
                                oCampos.DETALLE_PROREG = dr["DETALLE_PROREG"].ToString();
                                oCampos.MINISTERIO_PUBLICO = dr["MINISTERIO_PUBLICO"].ToString();
                                oCampos.DETALLE_MINPUB = dr["DETALLE_MINPUB"].ToString();
                                oCampos.COLEGIO_INGENIEROS = dr["COLEGIO_INGENIEROS"].ToString();
                                oCampos.DETALLE_COLING = dr["DETALLE_COLING"].ToString();
                                oCampos.OEFA = dr["OEFA"].ToString();
                                oCampos.DETALLE_OEFA = dr["DETALLE_OEFA"].ToString();
                                oCampos.SUNAT = dr["SUNAT"].ToString();
                                oCampos.DETALLE_SUNAT = dr["DETALLE_SUNAT"].ToString();
                                oCampos.SERFOR = dr["SERFOR"].ToString();
                                oCampos.DETALLE_SERFOR = dr["DETALLE_SERFOR"].ToString();
                                oCampos.NOTROS = dr["OTROS"].ToString();
                                oCampos.DETALLE_OTROS = dr["DETALLE_OTROS"].ToString();
                                oCampos.OD = dr["OD"].ToString();
                                oCampos.MONTO_MULTA_TEXT = dr["MONTO_MULTA_TEXT"].ToString();
                                oCampos.MONTO_MULTA_FINAL_TEXT = dr["MONTO_MULTA_FINAL_TEXT"].ToString();
                                oCampos.ESTADO_PAU = dr["ESTADO_PAU"].ToString();
                                oCampos.ANIO = dr["ESTADO_PAU"].ToString();
                                oCampos.FECHA_PROVEIDO = dr["FECHA_PROVEIDO"].ToString();

                                try
                                {
                                    //Solo se agrego esta columna para la relación de resoluciones de término
                                    oCampos.ANIO_INFORME_TEXT = dr["ANIO_INFORME_TEXT"].ToString();
                                }
                                catch (Exception)
                                {
                                    oCampos.ANIO_INFORME_TEXT = "";
                                }

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
        public List<CEntidad> Dat_InicioPauVsDescargo(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_PauIniciadosVsDescargos", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("ANIO");
                            int p2 = dr.GetOrdinal("INICIO_PAU");
                            int p3 = dr.GetOrdinal("DESCARGO");


                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.ANIO = dr.GetString(p1);
                                oCampos.RDINICIO = dr.GetString(p2); //OBTENGO CANTIDAD DE INICIO PAU
                                oCampos.DESCARGO = dr.GetInt32(p3);
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
        public List<CEntidad> Dat_DetDescargo(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_PauIniciadosVsDescargoDet", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("TITULAR");
                            int p2 = dr.GetOrdinal("NUMERO");
                            int p3 = dr.GetOrdinal("NUMERO_RESOLUCION");
                            int p4 = dr.GetOrdinal("FECHA");
                            int p5 = dr.GetOrdinal("LUGAR");
                            int p6 = dr.GetOrdinal("COD_INFTIT");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.TITULAR = dr.GetString(p1);
                                oCampos.THABILITANTE = dr.GetString(p2);
                                oCampos.RDINICIO = dr.GetString(p3);
                                oCampos.FECHA = dr.GetString(p4);
                                oCampos.LUGAR = dr.GetString(p5);
                                oCampos.COD_INFTIT = dr.GetString(p6);
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
        /// METODO QUE TRAE LA RELACIÓN DE DOCUMENTOS PRESENTADOS POR EL TITULAR 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> Dat_RelDocTitular(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.new_REPORTE_Fiscalizacion_Doc_Titut", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("INFTIT");
                            int p2 = dr.GetOrdinal("TITULAR");
                            int p3 = dr.GetOrdinal("NUMERO");
                            int p9 = dr.GetOrdinal("NUMERO_INFTIT");
                            int p4 = dr.GetOrdinal("TIPO_DOCUMENTO");
                            int p5 = dr.GetOrdinal("OD");
                            int p6 = dr.GetOrdinal("FECHA_PRESENTACION");
                            int p7 = dr.GetOrdinal("DIRECCION");
                            int p8 = dr.GetOrdinal("FIC_SIADO");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_TITULAR = dr.GetString(p1);
                                oCampos.APELLIDOS_NOMBRES = dr.GetString(p2);
                                oCampos.TH_NUMERO = dr.GetString(p3);
                                oCampos.TIPO_DOCUMENTO = dr.GetString(p4);
                                oCampos.OD = dr.GetString(p5);
                                oCampos.FECHA_PRESENTACION = dr.GetString(p6);
                                oCampos.DIRECCION = dr.GetString(p7);
                                oCampos.FIC_SIADO = dr.GetString(p8);
                                oCampos.NUMERO_INFTIT = dr.GetString(p9);
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
        public CEntidad RegMostrarFechaObserv(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_BD_OBSERVATORIO_MIGRACION.new_REPORTE_ObservatorioFecha", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.PARAMETRO = dr["PARAMETRO"].ToString();
                                oCampos.FECHA = dr["VALOR"].ToString();
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
        public List<CEntidad> Dat_InfSupSinLegal(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCR_Informes_Pendientes", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("MODALIDAD");
                            int p2 = dr.GetOrdinal("DEPARTAMENTO");
                            int p3 = dr.GetOrdinal("TITULO");
                            int p9 = dr.GetOrdinal("TITULAR");
                            int p4 = dr.GetOrdinal("N_INFORME");
                            int p5 = dr.GetOrdinal("MES_SUPERV");
                            int p6 = dr.GetOrdinal("INICIO_VIG_POA");
                            int p7 = dr.GetOrdinal("PORC_INEXISTENCIA");
                            int p8 = dr.GetOrdinal("OBS_INEX");
                            int p10 = dr.GetOrdinal("TOTAL_VOLINJ");
                            int p11 = dr.GetOrdinal("DIAS_TRANSCURRIDOS");
                            int p12 = dr.GetOrdinal("FUNCIONARIO_CARGO");
                            int p13 = dr.GetOrdinal("FECHA_DERV");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.MODALIDAD = dr.GetString(p1);
                                oCampos.DEPARTAMENTO = dr.GetString(p2);
                                oCampos.TITULO = dr.GetString(p3);
                                oCampos.TITULAR = dr.GetString(p9);
                                oCampos.Numero_Inform = dr.GetString(p4);
                                oCampos.MES = dr.GetString(p5);
                                oCampos.FECHA = dr.GetString(p6);
                                oCampos.PORC_INEX = dr.GetString(p7);
                                oCampos.OBSERV_INEX = dr.GetString(p8);
                                oCampos.TOTAL_INJUS = dr.GetString(p10);
                                oCampos.DIAS_TRANSC = dr.GetInt32(p11);
                                oCampos.FUNCIONARIO_CARGO = dr.GetString(p12);
                                oCampos.FECHA_DERV = dr.GetString(p13);
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
        /// metodo que devuelve la lista de documentos presentados por el titular
        /// 29/08/2017
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> datListDocumentTH(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCR_ReporteDocumentosTH", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p0 = dr.GetOrdinal("ANIO");
                            int p1 = dr.GetOrdinal("DESC_RD_INI");
                            int p2 = dr.GetOrdinal("ALLANAMIENTO");
                            int p3 = dr.GetOrdinal("DESC_INF_FINAL");
                            int p4 = dr.GetOrdinal("RECONSIDERACION");
                            int p5 = dr.GetOrdinal("APELACIONES");
                            int p6 = dr.GetOrdinal("IMPLEMENTACIONES");
                            int p7 = dr.GetOrdinal("OTROS");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.ANIO = dr.GetInt32(p0).ToString();
                                oCampos.DESC_RD_INI = dr.GetInt32(p1);
                                oCampos.ALLANAMIENTO = dr.GetInt32(p2);
                                oCampos.DESC_INF_FINAL = dr.GetInt32(p3);
                                oCampos.RECONSIDERACION = dr.GetInt32(p4);
                                oCampos.APELACIONES = dr.GetInt32(p5);
                                oCampos.IMPLEMENTACIONES = dr.GetInt32(p6);
                                oCampos.OTROS = dr.GetInt32(p7);
                                oCampos.TOTAL = dr.GetInt32(p1) + dr.GetInt32(p2) + dr.GetInt32(p3) + dr.GetInt32(p4) + dr.GetInt32(p5) + dr.GetInt32(p6);
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

        public List<CEntidad> datListNotificaciones(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCR_ReporteNotificaciones", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p0 = dr.GetOrdinal("ROWNUM");
                            int p1 = dr.GetOrdinal("FECHA_REGISTRO");
                            int p2 = dr.GetOrdinal("TIPO_DOCUMENTO");
                            int p3 = dr.GetOrdinal("N_DOC");
                            int p4 = dr.GetOrdinal("DESTINATARIO");
                            int p5 = dr.GetOrdinal("DIRECCION");
                            int p6 = dr.GetOrdinal("FECHA_ADMINISTRADO");
                            int p7 = dr.GetOrdinal("FECHA_PRIMERA_VISITA");
                            int p8 = dr.GetOrdinal("FECHA_SEGUNDA_VISITA");
                            int p9 = dr.GetOrdinal("PERSONA_NOT");
                            int p10 = dr.GetOrdinal("VINCULO");
                            int p11 = dr.GetOrdinal("DIRECCION_NOT");
                            int p12 = dr.GetOrdinal("VARIACION_DOMICILIO");
                            int p13 = dr.GetOrdinal("OD_RESPONSABLE");
                            int p14 = dr.GetOrdinal("ESTADO");
                            int p15 = dr.GetOrdinal("OBSERVACIONES");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.ITEM = dr.GetInt32(p0);
                                oCampos.FECHA_CREACION = dr.GetDateTime(p1).ToString();
                                oCampos.TIPO_DOCUMENTO = dr.GetString(p2);
                                oCampos.N_DOC = dr.GetString(p3);
                                oCampos.DESTINATARIO = dr.GetString(p4);
                                oCampos.DIRECCION = dr.GetString(p5);
                                oCampos.FECHA_ADMINISTRADO = dr.GetString(p6);
                                oCampos.FECHA_PRIMERA_VISITA = dr["FECHA_PRIMERA_VISITA"] is DBNull ? string.Empty : dr["FECHA_PRIMERA_VISITA"].ToString();
                                oCampos.FECHA_SEGUNDA_VISITA = dr["FECHA_SEGUNDA_VISITA"] is DBNull ? string.Empty : dr["FECHA_SEGUNDA_VISITA"].ToString();
                                oCampos.PERSONA_NOT = dr.GetString(p9);
                                oCampos.VINCULO = dr.GetString(p10);
                                oCampos.DIRECCION_NOT = dr.GetString(p11);
                                oCampos.VARIACION_DOMICILIO = dr.GetString(p12);
                                oCampos.OD_RESPONSABLE = dr.GetString(p13);
                                oCampos.ESTADO = dr.GetString(p14);
                                oCampos.OBSERVACIONES = dr.GetString(p15);
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
        /// metodo ue obtiene la lista de detalles de los documentos presentados por el titular
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> datListDocumentTHDetalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCR_ReporteDocumentosTH", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p0 = dr.GetOrdinal("COD_INFTIT");
                            int p1 = dr.GetOrdinal("NUMERO_INFTIT");
                            int p2 = dr.GetOrdinal("TIPO");
                            int p3 = dr.GetOrdinal("FECHA_PRESENTACION");
                            int p4 = dr.GetOrdinal("ANIO");
                            int p5 = dr.GetOrdinal("TITULO");
                            int p6 = dr.GetOrdinal("MODALIDAD");
                            int p7 = dr.GetOrdinal("TITULAR");
                            int p8 = dr.GetOrdinal("DEPARTAMENTO");
                            int p9 = dr.GetOrdinal("OD_NOMBRE");
                            int p10 = dr.GetOrdinal("DOCUMENTO");
                            int p11 = dr.GetOrdinal("NUMERO_EXPEDIENTE");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_INFTIT = dr.GetString(p0);
                                oCampos.NUMERO_INFTIT = dr.GetString(p1);
                                oCampos.TIPO_DOCUMENTO = dr.GetString(p2);
                                oCampos.FECHA_PRESENTACION = dr.GetString(p3);
                                oCampos.ANIO = dr.GetInt32(p4).ToString();
                                oCampos.TITULO = dr.GetString(p5);
                                oCampos.MODALIDAD = dr.GetString(p6);
                                oCampos.TITULAR = dr.GetString(p7);
                                oCampos.DEPARTAMENTO = dr.GetString(p8);
                                oCampos.OD = dr.GetString(p9);
                                oCampos.N_DOCUMENTO = dr.GetString(p10);
                                oCampos.EXPED_ADMN = dr.GetString(p11);
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
        /// metodo que devuelve el resumen de los recursos impugnatorios 07/09/2017
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> datListImpugnatorio(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRRImpugnatorioPendiente", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p0 = dr.GetOrdinal("ANIO");
                            int p1 = dr.GetOrdinal("Impugnatorios");
                            int p2 = dr.GetOrdinal("Resueltos");
                            int p3 = dr.GetOrdinal("Pendientes");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.ANIO = dr.GetInt32(p0).ToString();
                                oCampos.Impugnatorios = dr.GetInt32(p1);
                                oCampos.Resueltos = dr.GetInt32(p2);
                                oCampos.Pendientes = dr.GetInt32(p3);
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
        /// metodo que devuelve la lista de detalle de los recursos impugnatorios 07/09/2017
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> datListImpugnatorioDetalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRRImpugnatorioPendiente", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p0 = dr.GetOrdinal("COD_INFTIT");
                            int p1 = dr.GetOrdinal("NUM_INFTIT");
                            int p2 = dr.GetOrdinal("FECHA_PRESENTACION");
                            int p3 = dr.GetOrdinal("ANIO");
                            int p4 = dr.GetOrdinal("TITULAR");
                            int p5 = dr.GetOrdinal("TITULO");
                            int p6 = dr.GetOrdinal("MODALIDAD");
                            int p7 = dr.GetOrdinal("NUM_EXPEDIENTE");
                            int p8 = dr.GetOrdinal("RD_TERMINO");
                            int p9 = dr.GetOrdinal("DIAS");
                            int p10 = dr.GetOrdinal("TIPO");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_INFTIT = dr.GetString(p0);
                                oCampos.NUMERO_INFTIT = dr.GetString(p1);
                                oCampos.FECHA = dr.GetString(p2);
                                oCampos.ANIO = dr.GetInt32(p3).ToString();
                                oCampos.TITULAR = dr.GetString(p4);
                                oCampos.TITULO = dr.GetString(p5);
                                oCampos.MODALIDAD = dr.GetString(p6);
                                oCampos.NUMERO_EXPEDIENTE = dr.GetString(p7);
                                oCampos.NUMERO_RD = dr.GetString(p8);
                                oCampos.DIAS_TRANSC = dr.GetInt32(p9);
                                oCampos.TIPO_DOCUMENTO = dr.GetString(p10);

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
        /// metodo para el reporte seguimiento de los documentos producidos por la direccion de linea - informes de supervisión
        /// 11/10/2017 Carlos Rios
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> datReporteSeguimientoSupervision(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCRReporte_Seguimiento_Supervision", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("MES");
                            int p2 = dr.GetOrdinal("MES_NOMBRE");
                            int p3 = dr.GetOrdinal("PROGAMADO");
                            int p4 = dr.GetOrdinal("SUPERVISADO");
                            int p5 = dr.GetOrdinal("SUPERVISADO_CA");
                            int p6 = dr.GetOrdinal("SUPERVISADO_DOC");
                            int p7 = dr.GetOrdinal("REMITIDOS");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.MES_ = dr.GetInt32(p1);
                                oCampos.MES_NOMBRE = dr.GetString(p2);
                                oCampos.PROGRAMADO = dr.GetInt32(p3);
                                oCampos.SUPERVISADO = dr.GetInt32(p4);
                                oCampos.SUPERVISADO_CA = dr.GetInt32(p5);
                                oCampos.SUPERVISADO_DOC = dr.GetInt32(p6);
                                oCampos.REMITIDOS = dr.GetInt32(p7);
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
        /// detalle del reporte seguimiento de los documentos producidos por la direccion de linea - informes de supervisión
        /// 11/10/2017 Carlos Rios
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> dat_ReporteSeguimientoDetalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCRReporte_Seguimiento", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("MES");
                            int p2 = dr.GetOrdinal("MES_NOMBRE");
                            int p3 = dr.GetOrdinal("COD_THABILITANTE");
                            int p4 = dr.GetOrdinal("TITULAR");
                            int p5 = dr.GetOrdinal("TITULO");
                            int p6 = dr.GetOrdinal("TIPO");
                            int p7 = dr.GetOrdinal("SUPERVISOR");
                            int p8 = dr.GetOrdinal("FECHA_INICIO");
                            int p9 = dr.GetOrdinal("FECHA_FIN");
                            int p10 = dr.GetOrdinal("FECHA_ENTREGA");
                            int p11 = dr.GetOrdinal("FECHA_SIGO");
                            int p12 = dr.GetOrdinal("CONTROL_CALIDAD");
                            int p13 = dr.GetOrdinal("FECHA_CCA");
                            int p14 = dr.GetOrdinal("DIGITALIZADO");
                            int p15 = dr.GetOrdinal("FECHA_DERIVACION");
                            int p16 = dr.GetOrdinal("NUMERO");
                            int p17 = dr.GetOrdinal("ESTADO_DOC");
                            int p18 = dr.GetOrdinal("COD_DOCSIADO");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.MES_ = dr.GetInt32(p1);
                                oCampos.MES_NOMBRE = dr.GetString(p2);
                                oCampos.COD_THABILITANTE = dr.GetString(p3);
                                oCampos.TITULAR = dr.GetString(p4);
                                oCampos.TITULO = dr.GetString(p5);
                                oCampos.TIPO_DOCUMENTO = dr.GetString(p6);
                                oCampos.SUPERVISOR = dr.GetString(p7);
                                oCampos.FECHA_INICIO = dr.GetString(p8);
                                oCampos.FECHA_FIN = dr.GetString(p9);
                                oCampos.FECHA_ENTREGA = dr.GetString(p10);
                                oCampos.FECHA = dr.GetString(p11);
                                oCampos.CONTROL_CALIDAD = dr.GetString(p12);
                                oCampos.FECHA_CCA = dr.GetString(p13);
                                oCampos.DIGITALIZADO = dr.GetString(p14);
                                oCampos.FECHA_DERIVACION = dr.GetString(p15);
                                oCampos.Numero_Inform = dr.GetString(p16);
                                oCampos.ESTADO_PAU = dr.GetString(p17);
                                oCampos.CODIGO = dr.GetString(p18);
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
        /// metodo de suspension detalle
        /// 17/10/2017
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> dat_ReporteSegSuspensionDetalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCRReporte_Seguimiento", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("MES");
                            int p2 = dr.GetOrdinal("MES_NOMBRE");
                            int p3 = dr.GetOrdinal("COD_THABILITANTE");
                            int p4 = dr.GetOrdinal("TITULAR");
                            int p5 = dr.GetOrdinal("TITULO");
                            int p6 = dr.GetOrdinal("TIPO");
                            int p7 = dr.GetOrdinal("SUPERVISOR");
                            int p8 = dr.GetOrdinal("NUM_INFORME");
                            int p9 = dr.GetOrdinal("FECHA_ACTA");
                            int p10 = dr.GetOrdinal("FECHA_ENTREGA");
                            int p11 = dr.GetOrdinal("FECHA_SIGO");
                            int p12 = dr.GetOrdinal("CONTROL_CALIDAD");
                            int p13 = dr.GetOrdinal("FECHA_CCA");
                            int p14 = dr.GetOrdinal("DIGITALIZADO");
                            int p15 = dr.GetOrdinal("FECHA_DERIVACION");
                            int p16 = dr.GetOrdinal("ESTADO_DOC");
                            int p17 = dr.GetOrdinal("COD_DOCSIADO");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.MES_ = dr.GetInt32(p1);
                                oCampos.MES_NOMBRE = dr.GetString(p2);
                                oCampos.COD_THABILITANTE = dr.GetString(p3);
                                oCampos.TITULAR = dr.GetString(p4);
                                oCampos.TITULO = dr.GetString(p5);
                                oCampos.TIPO_DOCUMENTO = dr.GetString(p6);
                                oCampos.SUPERVISOR = dr.GetString(p7);
                                oCampos.Numero_Inform = dr.GetString(p8);
                                oCampos.FECHA_FIN = dr.GetString(p9);
                                oCampos.FECHA_ENTREGA = dr.GetString(p10);
                                oCampos.FECHA = dr.GetString(p11);
                                oCampos.CONTROL_CALIDAD = dr.GetString(p12);
                                oCampos.FECHA_CCA = dr.GetString(p13);
                                oCampos.DIGITALIZADO = dr.GetString(p14);
                                oCampos.FECHA_DERIVACION = dr.GetString(p15);
                                oCampos.ESTADO_PAU = dr.GetString(p16);
                                oCampos.CODIGO = dr.GetString(p17);
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
        /// METODO DETALLE DEL REPORTE SEGUIMIENTO DEL INFORME QUINQUENAL
        /// 20/10/2017 CR
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> datReporteSegQuinquenalDetalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCRReporte_Seguimiento", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("MES");
                            int p2 = dr.GetOrdinal("MES_NOMBRE");
                            int p3 = dr.GetOrdinal("COD_THABILITANTE");
                            int p4 = dr.GetOrdinal("TITULAR");
                            int p5 = dr.GetOrdinal("TITULO");
                            int p7 = dr.GetOrdinal("EQUIPO");
                            int p8 = dr.GetOrdinal("FECHA_INICIO");
                            int p9 = dr.GetOrdinal("NUMERO");
                            int p10 = dr.GetOrdinal("FECHA");
                            int p11 = dr.GetOrdinal("CONTROL_CALIDAD");
                            int p12 = dr.GetOrdinal("FECHA_CCA");
                            int p13 = dr.GetOrdinal("DIGITALIZADO");
                            int p14 = dr.GetOrdinal("FECHA_DERIVACION");
                            int p15 = dr.GetOrdinal("ESTADO_DOC");
                            int p16 = dr.GetOrdinal("COD_DOCSIADO");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.MES_ = dr.GetInt32(p1);
                                oCampos.MES_NOMBRE = dr.GetString(p2);
                                oCampos.COD_THABILITANTE = dr.GetString(p3);
                                oCampos.TITULAR = dr.GetString(p4);
                                oCampos.TITULO = dr.GetString(p5);
                                oCampos.SUPERVISOR = dr.GetString(p7);
                                oCampos.FECHA_INICIO = dr.GetString(p8);
                                oCampos.Numero_Inform = dr.GetString(p9);
                                oCampos.FECHA = dr.GetString(p10);
                                oCampos.CONTROL_CALIDAD = dr.GetString(p11);
                                oCampos.FECHA_CCA = dr.GetString(p12);
                                oCampos.DIGITALIZADO = dr.GetString(p13);
                                oCampos.FECHA_DERIVACION = dr.GetString(p14);
                                oCampos.ESTADO_PAU = dr.GetString(p15);
                                oCampos.CODIGO = dr.GetString(p16);
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
        /// metodo para el reporte de seguimiento
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> datReporteSeguimiento(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCRReporte_Seguimiento", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("MES");
                            int p2 = dr.GetOrdinal("MES_NOMBRE");
                            int p3 = dr.GetOrdinal("PROGRAMADO");
                            int p4 = dr.GetOrdinal("EJECUTADO");
                            int p5 = dr.GetOrdinal("CONTROL_CALIDAD");
                            int p6 = dr.GetOrdinal("DIGITALIZADO");
                            int p7 = dr.GetOrdinal("REMITIDOS");

                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.MES_ = dr.GetInt32(p1);
                                oCampos.MES_NOMBRE = dr.GetString(p2);
                                oCampos.PROGRAMADO = dr.GetInt32(p3);
                                oCampos.SUPERVISADO = dr.GetInt32(p4);
                                oCampos.SUPERVISADO_CA = dr.GetInt32(p5);
                                oCampos.SUPERVISADO_DOC = dr.GetInt32(p6);
                                oCampos.REMITIDOS = dr.GetInt32(p7);
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

        public List<CEntidad> dat_ReporteSeguimiento_Detalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCRReporte_Seguimiento", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("MES");
                            int p2 = dr.GetOrdinal("MES_NOMBRE");
                            int p3 = dr.GetOrdinal("NOMBRE");
                            int p4 = dr.GetOrdinal("TIPO");
                            int p5 = dr.GetOrdinal("FECHA");
                            int p6 = dr.GetOrdinal("FECHA_SIGO");
                            int p7 = dr.GetOrdinal("TITULO");
                            int p8 = dr.GetOrdinal("TITULAR");
                            int p9 = dr.GetOrdinal("CONTROL_CALIDAD");
                            int p10 = dr.GetOrdinal("FECHA_CCA");
                            int p11 = dr.GetOrdinal("DIGITALIZADO");
                            int p12 = dr.GetOrdinal("FECHA_DERIVACION");
                            int p13 = dr.GetOrdinal("NUMERO");
                            int p14 = dr.GetOrdinal("ESTADO_DOC");
                            int p15 = dr.GetOrdinal("COD_DOCSIADO");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.MES_ = dr.GetInt32(p1);
                                oCampos.MES_NOMBRE = dr.GetString(p2);
                                oCampos.NUMERO_RD = dr.GetString(p3);
                                oCampos.TIPO_RD = dr.GetString(p4);
                                oCampos.FECHA_EMISION = dr.GetString(p5);
                                oCampos.FECHA = dr.GetString(p6);
                                oCampos.TITULO = dr.GetString(p7);
                                oCampos.TITULAR = dr.GetString(p8);
                                oCampos.CONTROL_CALIDAD = dr.GetString(p9);
                                oCampos.FECHA_CCA = dr.GetString(p10);
                                oCampos.DIGITALIZADO = dr.GetString(p11);
                                oCampos.FECHA_DERIVACION = dr.GetString(p12);
                                oCampos.Numero_Inform = dr.GetString(p13);
                                oCampos.ESTADO_PAU = dr.GetString(p14);
                                oCampos.CODIGO = dr.GetString(p15);
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

        public List<CEntidad> dat_ReporteListInfQuinquenal(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spCRReporte_Seguimiento", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("ANIO_INICIO");
                            int p2 = dr.GetOrdinal("DEPARTAMENTO");
                            int p3 = dr.GetOrdinal("PROVINCIA");
                            int p4 = dr.GetOrdinal("DISTRITO");
                            int p5 = dr.GetOrdinal("TITULO");
                            int p6 = dr.GetOrdinal("TITULAR");
                            int p7 = dr.GetOrdinal("MODALIDAD");
                            int p8 = dr.GetOrdinal("RD_AUDIT_QUINQUENAL");
                            int p9 = dr.GetOrdinal("FECHA_EMISION_RD_QUINQUENAL");
                            int p10 = dr.GetOrdinal("NOTIFICACION");
                            int p11 = dr.GetOrdinal("EQUIPO");
                            int p12 = dr.GetOrdinal("NUM_INF_EVALUACION_DOC");
                            int p13 = dr.GetOrdinal("FECHA_EMISION_ED");
                            int p14 = dr.GetOrdinal("NUM_INF_EVALUACION_CAMPO");
                            int p15 = dr.GetOrdinal("FECHA_EMISION_EC");
                            int p16 = dr.GetOrdinal("NUM_INF_QUINQUENAL");
                            int p17 = dr.GetOrdinal("FECHA_ENTREGA_INF_QUINQ");
                            int p18 = dr.GetOrdinal("INF_QUINQUENAL_CONCLUCION");
                            int p19 = dr.GetOrdinal("AMPLIAR_CONTRATO");
                            int p20 = dr.GetOrdinal("FECHA_DERIVACION");


                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.ANIO = dr.GetInt32(p1).ToString();
                                oCampos.DEPARTAMENTO = dr.GetString(p2);
                                oCampos.PROVINCIA = dr.GetString(p3);
                                oCampos.DISTRITO = dr.GetString(p4);
                                oCampos.TITULO = dr.GetString(p5);
                                oCampos.TITULAR = dr.GetString(p6);
                                oCampos.MODALIDAD = dr.GetString(p7);
                                oCampos.RD_AUDIT_QUINQUENAL = dr.GetString(p8);
                                oCampos.FECHA_EMISION_RD_QUINQUENAL = dr.GetString(p9);
                                oCampos.NOTIFICACION = dr.GetString(p10);
                                oCampos.EQUIPO = dr.GetString(p11);
                                oCampos.NUM_INF_EVALUACION_DOC = dr.GetString(p12);
                                oCampos.FECHA_EMISION_ED = dr.GetString(p13);
                                oCampos.NUM_INF_EVALUACION_CAMPO = dr.GetString(p14);
                                oCampos.FECHA_EMISION_EC = dr.GetString(p15);
                                oCampos.NUM_INF_QUINQUENAL = dr.GetString(p16);
                                oCampos.FECHA_ENTREGA_INF_QUINQ = dr.GetString(p17);
                                oCampos.INF_QUINQUENAL_CONCLUCION = dr.GetString(p18);
                                oCampos.AMPLIAR_CONTRATO = dr.GetString(p19);
                                oCampos.FECHA_DERIVACION = dr.GetString(p20);

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
    }
}

