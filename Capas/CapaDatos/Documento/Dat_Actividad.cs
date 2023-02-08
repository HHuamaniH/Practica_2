using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_Actividad;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_Actividad
    {
        private SQL oGDataSQL = new SQL();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegListarPrioridad(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spAListarPrioridar", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("CODIGO");
                            int p2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad
                                {
                                    CODIGO = dr.GetString(p1),
                                    DESCRIPCION = dr.GetString(p2)
                                };
                                lsCEntidad.Add(oCamposDet);
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
        public List<CEntidad> RegListarOficina(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spListarOficinas", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_OFICINA");
                            int p2 = dr.GetOrdinal("NOMBRE_OFICINA");
                            int p3 = dr.GetOrdinal("ABREV_OFICINA");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_OFICINA = dr.GetInt32(p1).ToString();
                                oCamposDet.NOMBRE_OFICINA = dr.GetString(p2);
                                oCamposDet.ABREV_OFICINA = dr.GetString(p3);
                                lsCEntidad.Add(oCamposDet);
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
        public List<CEntidad> RegListarEstado(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spActividadListarEstado", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("CODIGO");
                            int p2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad
                                {
                                    CODIGO = dr.GetString(p1),
                                    DESCRIPCION = dr.GetString(p2)
                                };
                                lsCEntidad.Add(oCamposDet);
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

        //lista que devuelve personas
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegBuscarPersonas(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spBuscaPersonas", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_PERSONA");
                            int p2 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int p3 = dr.GetOrdinal("DOCUMENTO");
                            int p4 = dr.GetOrdinal("RUC");
                            int p5 = dr.GetOrdinal("DIRECCION");
                            int p6 = dr.GetOrdinal("NUMEROTELEFONICO");
                            int p7 = dr.GetOrdinal("CODUBIGEO");
                            int p8 = dr.GetOrdinal("UBIGEONAME");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_PERSONA = dr.GetString(p1);
                                oCamposDet.APELLIDOS_NOMBRES = dr.GetString(p2);
                                oCamposDet.DNI = dr.GetString(p3);
                                oCamposDet.DIRECCION = dr.GetString(p5);
                                oCamposDet.TELEFONO = dr.GetString(p6);
                                lsCEntidad.Add(oCamposDet);
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
        //public CEntidad RegPopupBuscarPersonas(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    CEntidad oCampos = new CEntidad();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spReporteProduccionXDigitadoresUsuarios", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("COD_PERSONA");
        //                    int p2 = dr.GetOrdinal("APELLIDOS_NOMBRES");
        //                    int p3 = dr.GetOrdinal("N_DOCUMENTO");

        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.COD_PERSONA = dr.GetString(p1);
        //                        oCampos.APELLIDOS_NOMBRES = dr.GetString(p2);
        //                        oCampos.DNI = dr.GetString(p3);
        //                    }

        //                }
        //            }
        //        }
        //        return oCampos;
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
        public String RegGrabar(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "ACT.spRActividadGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_ACTIVIDAD = OUTPUTPARAM01;
                }

                if (oCEntidad.ListPersonas != null)
                {
                    foreach (var loDatos in oCEntidad.ListPersonas)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_ACTIVIDAD = oCEntidad.COD_ACTIVIDAD;
                        oCamposDet.COD_ACTV_RESP = loDatos.COD_ACTV_RESP;
                        oCamposDet.COD_PERSONA = loDatos.COD_PERSONA;
                        // oCamposDet.RegEstado = loDatos.RegEstado;
                        oCamposDet.AVANCE_EDIT = loDatos.AVANCE_EDIT;
                        if (loDatos.COD_ACTV_RESP == "")
                        {
                            oCamposDet.RegEstado = 1; //NUEVO
                        }
                        else
                        {
                            oCamposDet.RegEstado = 2; //EDITAMOS
                        }
                        oGDataSQL.ManExecute(cn, tr, "ACT.spRActividadResponGrabar", oCamposDet);
                    }
                }
                //Eliminando Productos
                if (oCEntidad.ListPersonasElim != null)
                {
                    foreach (var loDatos in oCEntidad.ListPersonasElim)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_ACTV_RESP = loDatos.COD_ACTV_RESP;
                        oGDataSQL.ManExecute(cn, tr, "ACT.spRActividadEliminar", oCamposDet);
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
        public CEntidad RegMostrarActv(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "ACT.spRActvMostrarItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListPersonas = new List<CEntidad>();
                        CEntidad oCamposDet;

                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.COD_ACTIVIDAD = dr.GetString(dr.GetOrdinal("COD_ACTIVIDAD"));
                            oCampos.NOMBRE = dr.GetString(dr.GetOrdinal("NOMBRE"));
                            oCampos.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                            oCampos.ENTREGABLE = dr.GetString(dr.GetOrdinal("ENTREGABLE"));
                            oCampos.FECHA_INICIO = dr.GetString(dr.GetOrdinal("FECHA_INICIO"));
                            oCampos.FECHA_FIN = dr.GetString(dr.GetOrdinal("FECHA_FIN"));
                            oCampos.FECHA_REUNION = dr.GetString(dr.GetOrdinal("FECHA_REUNION"));
                            oCampos.TIEMPO_ESTIMADO = dr.GetInt32(dr.GetOrdinal("TIEMPO_ESTIMADO"));
                            oCampos.COD_PRIORIDAD = dr.GetString(dr.GetOrdinal("COD_PRIORIDAD"));
                            oCampos.COD_JEFE = dr.GetString(dr.GetOrdinal("COD_JEFE"));
                            oCampos.N_OFICINA = dr.GetString(dr.GetOrdinal("ID_OFICINA"));
                            oCampos.REFERENCIA = dr.GetString(dr.GetOrdinal("REFERENCIA"));
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_ACTV_RESP");
                            int pt2 = dr.GetOrdinal("COD_PERSONA");
                            int pt3 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int pt4 = dr.GetOrdinal("N_DOCUMENTO");
                            int pt5 = dr.GetOrdinal("TELEFONO");
                            int pt6 = dr.GetOrdinal("AVANCE_EDIT");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ACTV_RESP = dr.GetString(pt1);
                                oCamposDet.COD_PERSONA = dr.GetString(pt2);
                                oCamposDet.APELLIDOS_NOMBRES = dr.GetString(pt3);
                                oCamposDet.DNI = dr.GetString(pt4);
                                oCamposDet.TELEFONO = dr.GetString(pt5);
                                oCamposDet.RegEstado = 0;
                                oCamposDet.AVANCE_EDIT = dr.GetBoolean(pt6);
                                oCampos.ListPersonas.Add(oCamposDet);
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

        // para mostrar actividades por usuarios
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegListActv(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spRActividadListar", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_ACTIVIDAD");
                            int p2 = dr.GetOrdinal("NOMBRE");
                            int p3 = dr.GetOrdinal("DESCRIPCION");
                            int p12 = dr.GetOrdinal("ENTREGABLE");
                            int p4 = dr.GetOrdinal("PRIORIDAD");
                            int p5 = dr.GetOrdinal("FECHA_INICIO");
                            int p6 = dr.GetOrdinal("FECHA_FIN");
                            int p7 = dr.GetOrdinal("Tiempo_Restante");
                            int p11 = dr.GetOrdinal("Tiempo_Vencimiento");
                            int p8 = dr.GetOrdinal("ESTADO");
                            int p10 = dr.GetOrdinal("OBS");
                            int p9 = dr.GetOrdinal("AVANCE");
                            int p13 = dr.GetOrdinal("REFERENCIA");
                            int p14 = dr.GetOrdinal("AVANCE_EDIT");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ACTIVIDAD = dr.GetString(p1);
                                oCamposDet.NOMBRE = dr.GetString(p2);
                                oCamposDet.DESCRIPCION = dr.GetString(p3);
                                oCamposDet.ENTREGABLE = dr.GetString(p12);
                                oCamposDet.PRIORIDAD = dr.GetString(p4);
                                oCamposDet.FECHA_INICIO = dr.GetString(p5);
                                oCamposDet.FECHA_FIN = dr.GetString(p6);
                                oCamposDet.Tiempo_Restante = dr.GetInt32(p7);
                                oCamposDet.Tiempo_Vencimiento = dr.GetInt32(p11);
                                oCamposDet.ESTADO = dr.GetString(p8);
                                oCamposDet.AVANCE = dr.GetDecimal(p9);
                                oCamposDet.OBSERV = dr.GetString(p10);
                                oCamposDet.REFERENCIA = dr.GetString(p13);
                                oCamposDet.AVANCE_EDIT = dr.GetBoolean(p14);
                                if (oCamposDet.ESTADO == "No Iniciado")
                                {
                                    oCamposDet.AVANCE_SUB = false;
                                }
                                else
                                {
                                    oCamposDet.AVANCE_SUB = true;
                                }
                                lsCEntidad.Add(oCamposDet);
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
        public String RegGrabarAvance(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;
            String OUTPUTPARAM01 = "";
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "ACT.spActividadGrabarAvance", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_ACTIVIDAD = OUTPUTPARAM01;
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
        public List<CEntidad> RegListarActiv_Estado(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spRActvListActividadEstado", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_ACTIVIDAD");
                            int p2 = dr.GetOrdinal("AVANCE");
                            int p3 = dr.GetOrdinal("FECHA");
                            int p4 = dr.GetOrdinal("ESTADO");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ACTIVIDAD = dr.GetString(p1);
                                oCamposDet.AVANCE = dr.GetDecimal(p2);
                                oCamposDet.FECHA_FIN = dr.GetString(p3);
                                oCamposDet.ESTADO = dr.GetString(p4);

                                lsCEntidad.Add(oCamposDet);
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
        public List<CEntidad> RegListarActiv_EstadoDesc(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spRActvListActividadEstadoDesc", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p0 = dr.GetOrdinal("mes");
                            int p1 = dr.GetOrdinal("NMes");
                            int p2 = dr.GetOrdinal("Inicio");
                            int p3 = dr.GetOrdinal("Proceso");
                            int p4 = dr.GetOrdinal("Termino");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.NMes = dr.GetString(p1);
                                oCamposDet.cInicio = dr.GetInt32(p2);
                                oCamposDet.cProceso = dr.GetInt32(p3);
                                oCamposDet.cTermino = dr.GetInt32(p4);

                                lsCEntidad.Add(oCamposDet);
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
        public List<CEntidad> RegListarActivTotalXAnio(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spReporteXAnos", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("Anio");
                            int p2 = dr.GetOrdinal("Inicio");
                            int p3 = dr.GetOrdinal("Proceso");
                            int p4 = dr.GetOrdinal("Termino");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.Anio = dr.GetInt32(p1);
                                oCamposDet.cInicio = dr.GetInt32(p2);
                                oCamposDet.cProceso = dr.GetInt32(p3);
                                oCamposDet.cTermino = dr.GetInt32(p4);

                                lsCEntidad.Add(oCamposDet);
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
        public List<CEntidad> RegListarActivTotalXTrimestre(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spReporteXTrimestre", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("Anio");
                            int p5 = dr.GetOrdinal("Trimestre");
                            int p2 = dr.GetOrdinal("Inicio");
                            int p3 = dr.GetOrdinal("Proceso");
                            int p4 = dr.GetOrdinal("Termino");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.Anio = dr.GetInt32(p1);
                                oCamposDet.Trimestre = dr.GetInt32(p5).ToString() + " - " + dr.GetInt32(p1).ToString();
                                oCamposDet.cInicio = dr.GetInt32(p2);
                                oCamposDet.cProceso = dr.GetInt32(p3);
                                oCamposDet.cTermino = dr.GetInt32(p4);

                                lsCEntidad.Add(oCamposDet);
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
        public List<CEntidad> RegListarActivTotalXOficinas(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spReporteXOficinas", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_OFICINA");
                            int p5 = dr.GetOrdinal("NOM_OFICINA");
                            int p6 = dr.GetOrdinal("ABREV");
                            int p2 = dr.GetOrdinal("Inicio");
                            int p3 = dr.GetOrdinal("Proceso");
                            int p4 = dr.GetOrdinal("Termino");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_OFICINA = dr.GetInt32(p1).ToString();
                                oCamposDet.NOMBRE_OFICINA = dr.GetString(p5).ToString();
                                oCamposDet.cInicio = dr.GetInt32(p2);
                                oCamposDet.cProceso = dr.GetInt32(p3);
                                oCamposDet.cTermino = dr.GetInt32(p4);
                                oCamposDet.ABREV_OFICINA = dr.GetString(p6);
                                lsCEntidad.Add(oCamposDet);
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
        public List<CEntidad> RLisBusqAvan(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spGeneral_Reporte", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidad oCampos;
                            switch (oCEntidad.BusCriterio)
                            {
                                case "ANIO":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.Anio = dr.GetInt32(dr.GetOrdinal("Anio"));
                                        oCampos.cInicio = dr.GetInt32(dr.GetOrdinal("Inicio"));
                                        oCampos.cProceso = dr.GetInt32(dr.GetOrdinal("Proceso"));
                                        oCampos.cTermino = dr.GetInt32(dr.GetOrdinal("Termino"));
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                case "TRIMESTRE":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.Anio = dr.GetInt32(dr.GetOrdinal("Anio"));
                                        oCampos.Trimestre = dr.GetInt32(dr.GetOrdinal("Trimestre")).ToString() + "-" + dr.GetInt32(dr.GetOrdinal("Anio")).ToString();
                                        oCampos.cInicio = dr.GetInt32(dr.GetOrdinal("Inicio"));
                                        oCampos.cProceso = dr.GetInt32(dr.GetOrdinal("Proceso"));
                                        oCampos.cTermino = dr.GetInt32(dr.GetOrdinal("Termino"));
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                case "OFICINAS":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.COD_OFICINA = dr.GetInt32(dr.GetOrdinal("COD_OFICINA")).ToString();
                                        oCampos.NOMBRE_OFICINA = dr.GetString(dr.GetOrdinal("NOM_OFICINA")).ToString();
                                        oCampos.ABREV_OFICINA = dr.GetString(dr.GetOrdinal("ABREV")).ToString();
                                        oCampos.cInicio = dr.GetInt32(dr.GetOrdinal("Inicio"));
                                        oCampos.cProceso = dr.GetInt32(dr.GetOrdinal("Proceso"));
                                        oCampos.cTermino = dr.GetInt32(dr.GetOrdinal("Termino"));
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                case "OFICINASOCI":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.COD_OFICINA = dr.GetInt32(dr.GetOrdinal("COD_OFICINA")).ToString();
                                        oCampos.NOMBRE_OFICINA = dr.GetString(dr.GetOrdinal("NOM_OFICINA")).ToString();
                                        oCampos.ABREV_OFICINA = dr.GetString(dr.GetOrdinal("ABREV")).ToString();
                                        oCampos.cInicio = dr.GetInt32(dr.GetOrdinal("Inicio"));
                                        oCampos.cProceso = dr.GetInt32(dr.GetOrdinal("Proceso"));
                                        oCampos.cTermino = dr.GetInt32(dr.GetOrdinal("Termino"));
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;
                                case "USUARIOS":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.COD_PERSONA = dr.GetString(dr.GetOrdinal("COD_PERSONA")).ToString();
                                        oCampos.NOMBRE = dr.GetString(dr.GetOrdinal("nombre")).ToString();
                                        oCampos.cInicio = dr.GetInt32(dr.GetOrdinal("Inicio"));
                                        oCampos.cProceso = dr.GetInt32(dr.GetOrdinal("Proceso"));
                                        oCampos.cTermino = dr.GetInt32(dr.GetOrdinal("Termino"));
                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;

                                case "ACTIVIDADES":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.COD_ACTIVIDAD = dr.GetString(dr.GetOrdinal("COD_ACTIVIDAD")).ToString();
                                        oCampos.NOMBRE = dr.GetString(dr.GetOrdinal("NOMBRE")).ToString();
                                        oCampos.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION")).ToString();
                                        oCampos.PRIORIDAD = dr.GetString(dr.GetOrdinal("PRIORIDAD")).ToString();
                                        oCampos.FECHA_INICIO = dr.GetString(dr.GetOrdinal("FECHA_INICIO")).ToString();
                                        oCampos.FECHA_FIN = dr.GetString(dr.GetOrdinal("FECHA_FIN")).ToString();
                                        oCampos.Tiempo_Restante = dr.GetInt32(dr.GetOrdinal("Tiempo_Restante"));
                                        oCampos.Tiempo_Vencimiento = dr.GetInt32(dr.GetOrdinal("Tiempo_Vencimiento"));
                                        oCampos.ESTADO = dr.GetString(dr.GetOrdinal("ESTADO")).ToString();
                                        oCampos.AVANCE = dr.GetDecimal(dr.GetOrdinal("AVANCE"));
                                        oCampos.NOMBRE_OFICINA = dr.GetString(dr.GetOrdinal("OFICINA")).ToString();


                                        lsCEntidad.Add(oCampos);
                                    }
                                    break;

                                case "TODOS":
                                    while (dr.Read())
                                    {
                                        oCampos = new CEntidad();
                                        oCampos.COD_ACTIVIDAD = dr.GetString(dr.GetOrdinal("COD_ACTIVIDAD")).ToString();
                                        oCampos.NOMBRE = dr.GetString(dr.GetOrdinal("NOMBRE")).ToString();
                                        oCampos.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION")).ToString();
                                        oCampos.PRIORIDAD = dr.GetString(dr.GetOrdinal("PRIORIDAD")).ToString();
                                        oCampos.FECHA_INICIO = dr.GetString(dr.GetOrdinal("FECHA_INICIO")).ToString();
                                        oCampos.FECHA_FIN = dr.GetString(dr.GetOrdinal("FECHA_FIN")).ToString();
                                        oCampos.Tiempo_Restante = dr.GetInt32(dr.GetOrdinal("Tiempo_Restante"));
                                        oCampos.Tiempo_Vencimiento = dr.GetInt32(dr.GetOrdinal("Tiempo_Vencimiento"));
                                        oCampos.ESTADO = dr.GetString(dr.GetOrdinal("ESTADO")).ToString();
                                        oCampos.AVANCE = dr.GetDecimal(dr.GetOrdinal("AVANCE"));
                                        oCampos.NOMBRE_OFICINA = dr.GetString(dr.GetOrdinal("OFICINA")).ToString();


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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String RegGrabarOCI(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "ACT.spRActividadGrabarOCI", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_ACTIVIDAD = OUTPUTPARAM01;
                }

                if (oCEntidad.ListPersonas != null)
                {
                    foreach (var loDatos in oCEntidad.ListPersonas)
                    {
                        if (loDatos.RegEstado == 1) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_ACTIVIDAD = oCEntidad.COD_ACTIVIDAD;
                            oCamposDet.COD_ACTV_RESP = loDatos.COD_ACTV_RESP;
                            oCamposDet.COD_PERSONA = loDatos.COD_PERSONA;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            oCamposDet.AVANCE_EDIT = loDatos.AVANCE_EDIT;
                            oGDataSQL.ManExecute(cn, tr, "ACT.spRActividadResponGrabar", oCamposDet);
                        }
                    }
                }
                //Eliminando Productos
                if (oCEntidad.ListPersonasElim != null)
                {
                    foreach (var loDatos in oCEntidad.ListPersonasElim)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_ACTV_RESP = loDatos.COD_ACTV_RESP;
                        oGDataSQL.ManExecute(cn, tr, "ACT.spRActividadEliminar", oCamposDet);
                    }
                }

                if (oCEntidad.ListOficinas != null)
                {
                    foreach (var loDatos in oCEntidad.ListOficinas)
                    {
                        if (loDatos.RegEstado == 1) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_ACTIVIDAD = oCEntidad.COD_ACTIVIDAD;
                            oCamposDet.COD_ACTIVIDAD_OFICINA = loDatos.COD_ACTIVIDAD_OFICINA;
                            oCamposDet.COD_OFICINA = loDatos.COD_OFICINA;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            oGDataSQL.ManExecute(cn, tr, "ACT.spRActividadOficGrabar", oCamposDet);
                        }
                    }
                }
                //Eliminando Productos
                if (oCEntidad.ListOficinasElim != null)
                {
                    foreach (var loDatos in oCEntidad.ListOficinasElim)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_ACTIVIDAD_OFICINA = loDatos.COD_ACTIVIDAD_OFICINA;
                        oGDataSQL.ManExecute(cn, tr, "ACT.spRActividadOFicinaEliminar", oCamposDet);
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

        public String RegGrabarOFI(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;
            String OUTPUTPARAM01 = "";
            String OUTPUTPARAM02 = "";

            CEntidad oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "ACT.spRActividadGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_ACTIVIDAD = OUTPUTPARAM01;
                }

                if (oCEntidad.ListPersonas != null)
                {
                    foreach (var loDatos in oCEntidad.ListPersonas)
                    {

                        oCamposDet = new CEntidad();
                        oCamposDet.COD_ACTIVIDAD = oCEntidad.COD_ACTIVIDAD;
                        oCamposDet.COD_ACTV_RESP = loDatos.COD_ACTV_RESP;
                        oCamposDet.COD_PERSONA = loDatos.COD_PERSONA;
                        oCamposDet.AVANCE_EDIT = loDatos.AVANCE_EDIT;
                        if (loDatos.COD_ACTV_RESP == "")
                        {
                            oCamposDet.RegEstado = 1; //NUEVO
                        }
                        else
                        {
                            oCamposDet.RegEstado = 2; //EDITAMOS
                        }
                        oGDataSQL.ManExecute(cn, tr, "ACT.spRActividadResponGrabar", oCamposDet);

                    }
                }
                //Eliminando Productos
                if (oCEntidad.ListPersonasElim != null)
                {
                    foreach (var loDatos in oCEntidad.ListPersonasElim)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_ACTV_RESP = loDatos.COD_ACTV_RESP;
                        oGDataSQL.ManExecute(cn, tr, "ACT.spRActividadEliminar", oCamposDet);
                    }
                }

                if (oCEntidad.ListOficinas != null)
                {
                    foreach (var loDatos in oCEntidad.ListOficinas)
                    {
                        if (loDatos.RegEstado == 1) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            oCamposDet.COD_ACTIVIDAD = oCEntidad.COD_ACTIVIDAD;
                            oCamposDet.COD_ACTIVIDAD_OFICINA = loDatos.COD_ACTIVIDAD_OFICINA;
                            oCamposDet.COD_OFICINA = loDatos.COD_OFICINA;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            oGDataSQL.ManExecute(cn, tr, "ACT.spRActividadOficGrabar", oCamposDet);
                        }
                    }
                }
                //Eliminando Productos
                if (oCEntidad.ListOficinasElim != null)
                {
                    foreach (var loDatos in oCEntidad.ListOficinasElim)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_ACTIVIDAD_OFICINA = loDatos.COD_ACTIVIDAD_OFICINA;
                        oGDataSQL.ManExecute(cn, tr, "ACT.spRActividadOFicinaEliminar", oCamposDet);
                    }
                }

                if (oCEntidad.ListSubActividades != null)
                {
                    foreach (var loDatos in oCEntidad.ListSubActividades)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_ACTIVIDAD = OUTPUTPARAM01;
                        oCamposDet.COD_SUBACTIVIDAD = loDatos.COD_SUBACTIVIDAD;
                        oCamposDet.NOMBRE = loDatos.NOMBRE;
                        oCamposDet.DESCRIPCION = loDatos.DESCRIPCION;
                        oCamposDet.FECHA_INICIO = loDatos.FECHA_INICIO;
                        oCamposDet.FECHA_FIN = loDatos.FECHA_FIN;
                        oCamposDet.COD_OFICINA = loDatos.COD_OFICINA;
                        oCamposDet.OUTPUTPARAM02 = "";
                        if (loDatos.COD_SUBACTIVIDAD == null)
                        {
                            oCamposDet.RegEstado = 0;
                        }
                        else
                        {
                            oCamposDet.RegEstado = 1;
                        }
                        SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "ACT.spRActividadSubGrabar", oCamposDet);
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM02 = (String)cmd.Parameters["@OUTPUTPARAM02"].Value;
                        if (loDatos.ListPersonaSA.Count > 0)
                        {
                            foreach (var loDatosTemp in loDatos.ListPersonaSA)
                            {
                                if (loDatosTemp.COD_ACT_COLAB == null)
                                {
                                    oCamposDet = new CEntidad();
                                    oCamposDet.COD_SUBACTIVIDAD = OUTPUTPARAM02;
                                    oCamposDet.COD_PERSONA = loDatosTemp.COD_PERSONA;
                                    oCamposDet.RegEstado = 1; //grabar
                                    oGDataSQL.ManExecute(cn, tr, "ACT.spRActividadColaborador", oCamposDet);
                                }
                            }

                        }
                        if (loDatos.ListPersonaSAElim.Count > 0)
                        {
                            foreach (var loDatosTemp in loDatos.ListPersonaSAElim)
                            {
                                if (loDatosTemp.COD_ACT_COLAB != null)
                                {
                                    oCamposDet = new CEntidad();
                                    oCamposDet.COD_ACT_COLAB = loDatosTemp.COD_ACT_COLAB;
                                    oCamposDet.COD_PERSONA = loDatosTemp.COD_PERSONA;
                                    oCamposDet.RegEstado = 2; //eliminar
                                    oGDataSQL.ManExecute(cn, tr, "ACT.spRActividadColaborador", oCamposDet);
                                }
                            }
                        }
                    }
                }
                if (oCEntidad.ListSubActividadesElim != null)
                {
                    foreach (var loDatos in oCEntidad.ListSubActividadesElim)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_SUBACTIVIDAD = loDatos.COD_SUBACTIVIDAD;
                        oCamposDet.COD_ACTIVIDAD = OUTPUTPARAM01;
                        oCamposDet.RegEstado = 3;//Eliminar
                        oCamposDet.OUTPUTPARAM02 = "";
                        oGDataSQL.ManExecute(cn, tr, "ACT.spRActividadSubGrabar", oCamposDet);
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
        public CEntidad RegMostrarActvOCI(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "ACT.spRActvMostrarItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListPersonas = new List<CEntidad>();
                        oCampos.ListOficinas = new List<CEntidad>();
                        CEntidad oCamposDet;

                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.COD_ACTIVIDAD = dr.GetString(dr.GetOrdinal("COD_ACTIVIDAD"));
                            oCampos.NOMBRE = dr.GetString(dr.GetOrdinal("NOMBRE"));
                            oCampos.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                            oCampos.FECHA_INICIO = dr.GetString(dr.GetOrdinal("FECHA_INICIO"));
                            oCampos.FECHA_FIN = dr.GetString(dr.GetOrdinal("FECHA_FIN"));
                            oCampos.ENTREGABLE = dr.GetString(dr.GetOrdinal("ENTREGABLE"));
                            oCampos.TIEMPO_ESTIMADO = dr.GetInt32(dr.GetOrdinal("TIEMPO_ESTIMADO"));
                            oCampos.PRIORIZACION = dr.GetString(dr.GetOrdinal("PRIORIZACION"));
                            oCampos.COD_JEFE = dr.GetString(dr.GetOrdinal("COD_JEFE"));
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_ACTV_RESP");
                            int pt2 = dr.GetOrdinal("COD_PERSONA");
                            int pt3 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int pt4 = dr.GetOrdinal("N_DOCUMENTO");
                            int pt5 = dr.GetOrdinal("TELEFONO");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ACTV_RESP = dr.GetString(pt1);
                                oCamposDet.COD_PERSONA = dr.GetString(pt2);
                                oCamposDet.APELLIDOS_NOMBRES = dr.GetString(pt3);
                                oCamposDet.DNI = dr.GetString(pt4);
                                oCamposDet.TELEFONO = dr.GetString(pt5);
                                oCamposDet.RegEstado = 0;
                                oCampos.ListPersonas.Add(oCamposDet);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_ACTIVIDAD_OFICINA");
                            int pt2 = dr.GetOrdinal("COD_OFICINA2");
                            int pt3 = dr.GetOrdinal("cNomOficina");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ACTIVIDAD_OFICINA = dr.GetString(pt1);
                                oCamposDet.COD_OFICINA = dr.GetString(pt2);
                                oCamposDet.N_OFICINA = dr.GetString(pt3);
                                oCamposDet.RegEstado = 0;
                                oCampos.ListOficinas.Add(oCamposDet);
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
        public String RegACTEliminar(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            String OUTPUTPARAM01 = "";
            try
            {
                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, null, "ACT.EliminarTare", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;

                }
                return OUTPUTPARAM01;
                // SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "ACT.EliminarTare", oCEntidad);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> RegListarActivAvanceDetalle(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spActivDetalle", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_ACTIVIDAD");
                            int p2 = dr.GetOrdinal("NOMBRE");
                            int p3 = dr.GetOrdinal("AVANCE");
                            int p4 = dr.GetOrdinal("OBSERV");
                            int p5 = dr.GetOrdinal("DESCRIPCION");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ACTIVIDAD = dr.GetString(p1);
                                oCamposDet.NOMBRE = dr.GetString(p2);
                                oCamposDet.AVANCE = dr.GetDecimal(p3);
                                oCamposDet.OBSERV = dr.GetString(p4);
                                oCamposDet.ESTADO = dr.GetString(p5);
                                lsCEntidad.Add(oCamposDet);
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

        //LISTA DE REFERENCIAS
        public List<CEntidad> RegListarReferencia(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spGeneral_Reporte", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("CODIGO");
                            int p2 = dr.GetOrdinal("DESCRIPCION");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(p1);
                                oCamposDet.DESCRIPCION = dr.GetString(p2);
                                lsCEntidad.Add(oCamposDet);
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

        //Lista de actividad por referencias
        public List<CEntidad> RegListActvXReferencia(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spRActividadReferenciaListar", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_ACTIVIDAD");
                            int p2 = dr.GetOrdinal("NOMBRE");
                            int p3 = dr.GetOrdinal("DESCRIPCION");
                            int p12 = dr.GetOrdinal("ENTREGABLE");
                            int p4 = dr.GetOrdinal("PRIORIDAD");
                            int p5 = dr.GetOrdinal("FECHA_INICIO");
                            int p6 = dr.GetOrdinal("FECHA_FIN");
                            int p7 = dr.GetOrdinal("Tiempo_Restante");
                            int p11 = dr.GetOrdinal("Tiempo_Vencimiento");
                            int p8 = dr.GetOrdinal("ESTADO");
                            int p10 = dr.GetOrdinal("OBS");
                            int p9 = dr.GetOrdinal("AVANCE");
                            int p13 = dr.GetOrdinal("OFICINA");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ACTIVIDAD = dr.GetString(p1);
                                oCamposDet.NOMBRE = dr.GetString(p2);
                                oCamposDet.DESCRIPCION = dr.GetString(p3);
                                oCamposDet.ENTREGABLE = dr.GetString(p12);
                                oCamposDet.PRIORIDAD = dr.GetString(p4);
                                oCamposDet.FECHA_INICIO = dr.GetString(p5);
                                oCamposDet.FECHA_FIN = dr.GetString(p6);
                                oCamposDet.Tiempo_Restante = dr.GetInt32(p7);
                                oCamposDet.Tiempo_Vencimiento = dr.GetInt32(p11);
                                oCamposDet.ESTADO = dr.GetString(p8);
                                oCamposDet.AVANCE = dr.GetDecimal(p9);
                                oCamposDet.OBSERV = dr.GetString(p10);
                                oCamposDet.NOMBRE_OFICINA = dr.GetString(p13);
                                lsCEntidad.Add(oCamposDet);
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
        /// 25/09/2017 cambios nueva plataforma
        /// metodo para listar actividades 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> dat_ListActividades(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spGeneral_Reporte", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_ACTIVIDAD");
                            int p2 = dr.GetOrdinal("NOMBRE");
                            int p3 = dr.GetOrdinal("DESCRIPCION");
                            int p4 = dr.GetOrdinal("ENTREGABLE");
                            int p5 = dr.GetOrdinal("PRIORIDAD");
                            int p6 = dr.GetOrdinal("FECHA_INICIO");
                            int p7 = dr.GetOrdinal("FECHA_FIN");
                            int p8 = dr.GetOrdinal("Tiempo_Restante");
                            int p9 = dr.GetOrdinal("Tiempo_Vencimiento");
                            int p10 = dr.GetOrdinal("ESTADO");
                            int p11 = dr.GetOrdinal("AVANCE");
                            int p12 = dr.GetOrdinal("OFICINA");
                            int p13 = dr.GetOrdinal("REFERENCIA");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ACTIVIDAD = dr.GetString(p1);
                                oCamposDet.NOMBRE = dr.GetString(p2);
                                oCamposDet.DESCRIPCION = dr.GetString(p3);
                                oCamposDet.ENTREGABLE = dr.GetString(p4);
                                oCamposDet.PRIORIDAD = dr.GetString(p5);
                                oCamposDet.FECHA_INICIO = dr.GetString(p6);
                                oCamposDet.FECHA_FIN = dr.GetString(p7);
                                oCamposDet.Tiempo_Restante = dr.GetInt32(p8);
                                oCamposDet.Tiempo_Vencimiento = dr.GetInt32(p9);
                                oCamposDet.ESTADO = dr.GetString(p10);
                                oCamposDet.AVANCE = dr.GetDecimal(p11);
                                oCamposDet.ABREV_OFICINA = dr.GetString(p12);
                                oCamposDet.REFERENCIA = dr.GetString(p13);
                                lsCEntidad.Add(oCamposDet);
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

        public CEntidad RegMostrarActvOFI(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "ACT.spRActvMostrarItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListPersonas = new List<CEntidad>();
                        oCampos.ListOficinas = new List<CEntidad>();
                        oCampos.ListSubActividades = new List<CEntidad>();
                        oCampos.ListPersonaSA = new List<CEntidad>();
                        CEntidad oCamposDet;

                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.COD_ACTIVIDAD = dr.GetString(dr.GetOrdinal("COD_ACTIVIDAD"));
                            oCampos.NOMBRE = dr.GetString(dr.GetOrdinal("NOMBRE"));
                            oCampos.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                            oCampos.FECHA_INICIO = dr.GetString(dr.GetOrdinal("FECHA_INICIO"));
                            oCampos.FECHA_FIN = dr.GetString(dr.GetOrdinal("FECHA_FIN"));
                            oCampos.ENTREGABLE = dr.GetString(dr.GetOrdinal("ENTREGABLE"));
                            oCampos.TIEMPO_ESTIMADO = dr.GetInt32(dr.GetOrdinal("TIEMPO_ESTIMADO"));
                            oCampos.PRIORIZACION = dr.GetString(dr.GetOrdinal("PRIORIZACION"));
                            oCampos.COD_JEFE = dr.GetString(dr.GetOrdinal("COD_JEFE"));
                            //oCampos.TIPO = dr.GetString(dr.GetOrdinal("TIPO"));
                            //oCampos.TIPO_SUB = dr.GetString(dr.GetOrdinal("TIPO_SUB"));
                            //oCampos.FECHA_PRESENTACION = dr.GetString(dr.GetOrdinal("FECHA_PRESENTACION"));
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_ACTV_RESP");
                            int pt2 = dr.GetOrdinal("COD_PERSONA");
                            int pt3 = dr.GetOrdinal("APELLIDOS_NOMBRES");
                            int pt4 = dr.GetOrdinal("N_DOCUMENTO");
                            int pt5 = dr.GetOrdinal("TELEFONO");
                            int pt6 = dr.GetOrdinal("AVANCE");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ACTV_RESP = dr.GetString(pt1);
                                oCamposDet.COD_PERSONA = dr.GetString(pt2);
                                oCamposDet.APELLIDOS_NOMBRES = dr.GetString(pt3);
                                oCamposDet.DNI = dr.GetString(pt4);
                                oCamposDet.TELEFONO = dr.GetString(pt5);
                                oCamposDet.AVANCE_EDIT = dr.GetBoolean(pt6);
                                oCamposDet.RegEstado = 0;
                                oCampos.ListPersonas.Add(oCamposDet);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_ACTIVIDAD_OFICINA");
                            int pt2 = dr.GetOrdinal("COD_OFICINA2");
                            int pt3 = dr.GetOrdinal("cNomOficina");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ACTIVIDAD_OFICINA = dr.GetString(pt1);
                                oCamposDet.COD_OFICINA = dr.GetString(pt2);
                                oCamposDet.N_OFICINA = dr.GetString(pt3);
                                oCamposDet.RegEstado = 0;
                                oCampos.ListOficinas.Add(oCamposDet);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_ACTIVIDAD");
                            int pt1 = dr.GetOrdinal("COD_SUBACTIVIDAD");
                            int pt2 = dr.GetOrdinal("NOMBRE");
                            int pt3 = dr.GetOrdinal("FECHA_INICIO");
                            int pt4 = dr.GetOrdinal("FECHA_FIN");
                            int pt5 = dr.GetOrdinal("COD_OFICINA");
                            int pt6 = dr.GetOrdinal("NOM_OFICINA");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.ListPersonaSA = new List<CEntidad>();
                                oCamposDet.ListPersonaSAElim = new List<CEntidad>();
                                oCamposDet.COD_ACTIVIDAD_OFICINA = dr.GetString(pt0);
                                oCamposDet.COD_SUBACTIVIDAD = dr.GetString(pt1);
                                oCamposDet.NOMBRE = dr.GetString(pt2);
                                oCamposDet.FECHA_INICIO = dr.GetString(pt3);
                                oCamposDet.FECHA_FIN = dr.GetString(pt4);
                                oCamposDet.COD_OFICINA = dr.GetString(pt5);
                                oCamposDet.NOMBRE_OFICINA = dr.GetString(pt6);

                                CEntidad oCamposDetTemp = new CEntidad();
                                oCamposDetTemp.COD_ACTIVIDAD = oCamposDet.COD_SUBACTIVIDAD;
                                oCamposDetTemp.BusFormulario = "SUB";
                                SqlDataReader dr0 = oGDataSQL.SelDrdDefault(cn, null, "ACT.spRActvMostrarItems", oCamposDetTemp);
                                if (dr0 != null)
                                {
                                    if (dr.HasRows)
                                    {
                                        int p0 = dr0.GetOrdinal("COD_ACT_COLAB");
                                        int p1 = dr0.GetOrdinal("COD_PERSONA");
                                        int p2 = dr0.GetOrdinal("APELLIDOS_NOMBRES");
                                        int p3 = dr0.GetOrdinal("N_DOCUMENTO");
                                        int p4 = dr0.GetOrdinal("TELEFONO");
                                        while (dr0.Read())
                                        {
                                            oCamposDetTemp = new CEntidad();
                                            oCamposDetTemp.COD_ACT_COLAB = dr0.GetString(p0);
                                            oCamposDetTemp.COD_PERSONA = dr0.GetString(p1);
                                            oCamposDetTemp.APELLIDOS_NOMBRES = dr0.GetString(p2);
                                            oCamposDetTemp.DNI = dr0.GetString(p3);
                                            oCamposDetTemp.TELEFONO = dr0.GetString(p4);
                                            oCamposDetTemp.RegEstado = 1;
                                            oCamposDet.ListPersonaSA.Add(oCamposDetTemp);
                                        }
                                    }
                                }
                                //{ }
                                oCampos.ListSubActividades.Add(oCamposDet);
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
        /// metodo pa listar las subactividades 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegListSubActv(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spRActividadSubListar", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p0 = dr.GetOrdinal("COD_ACTIVIDAD");
                            int p1 = dr.GetOrdinal("COD_SUBACTIVIDAD");
                            int p2 = dr.GetOrdinal("NOMBRE");
                            int p3 = dr.GetOrdinal("DESCRIPCION");
                            int p4 = dr.GetOrdinal("FECHA_INICIO");
                            int p5 = dr.GetOrdinal("FECHA_FIN");
                            int p6 = dr.GetOrdinal("Tiempo_Restante");
                            int p7 = dr.GetOrdinal("Tiempo_Vencimiento");
                            int p8 = dr.GetOrdinal("ESTADO");
                            int p9 = dr.GetOrdinal("OBS");
                            int p10 = dr.GetOrdinal("AVANCE");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ACTIVIDAD = dr.GetString(p0);
                                oCamposDet.COD_SUBACTIVIDAD = dr.GetString(p1);
                                oCamposDet.NOMBRE = dr.GetString(p2);
                                oCamposDet.DESCRIPCION = dr.GetString(p3);
                                oCamposDet.FECHA_INICIO = dr.GetString(p4);
                                oCamposDet.FECHA_FIN = dr.GetString(p5);
                                oCamposDet.Tiempo_Restante = dr.GetInt32(p6);
                                oCamposDet.Tiempo_Vencimiento = dr.GetInt32(p7);
                                oCamposDet.ESTADO = dr.GetString(p8);
                                oCamposDet.AVANCE = dr.GetDecimal(p10);
                                oCamposDet.OBSERV = dr.GetString(p9);
                                lsCEntidad.Add(oCamposDet);
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

        public List<CEntidad> RegListSubActvRep(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spRActividadSubListarReporte", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p0 = dr.GetOrdinal("COD_ACTIVIDAD");
                            int p1 = dr.GetOrdinal("COD_SUBACTIVIDAD");
                            int p2 = dr.GetOrdinal("NOMBRE");
                            int p3 = dr.GetOrdinal("DESCRIPCION");
                            int p4 = dr.GetOrdinal("FECHA_INICIO");
                            int p5 = dr.GetOrdinal("FECHA_FIN");
                            int p6 = dr.GetOrdinal("Tiempo_Restante");
                            int p7 = dr.GetOrdinal("Tiempo_Vencimiento");
                            int p8 = dr.GetOrdinal("ESTADO");
                            int p9 = dr.GetOrdinal("OBS");
                            int p10 = dr.GetOrdinal("AVANCE");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ACTIVIDAD = dr.GetString(p0);
                                oCamposDet.COD_SUBACTIVIDAD = dr.GetString(p1);
                                oCamposDet.NOMBRE = dr.GetString(p2);
                                oCamposDet.DESCRIPCION = dr.GetString(p3);
                                oCamposDet.FECHA_INICIO = dr.GetString(p4);
                                oCamposDet.FECHA_FIN = dr.GetString(p5);
                                oCamposDet.Tiempo_Restante = dr.GetInt32(p6);
                                oCamposDet.Tiempo_Vencimiento = dr.GetInt32(p7);
                                oCamposDet.ESTADO = dr.GetString(p8);
                                oCamposDet.AVANCE = dr.GetDecimal(p10);
                                oCamposDet.OBSERV = dr.GetString(p9);
                                lsCEntidad.Add(oCamposDet);
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

        public List<CEntidad> RegListarActiv_EstadoSUB(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spRActvListActividadEstadoSUB", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_SUBACTIVIDAD");
                            int p2 = dr.GetOrdinal("AVANCE");
                            int p3 = dr.GetOrdinal("FECHA");
                            int p4 = dr.GetOrdinal("ESTADO");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_SUBACTIVIDAD = dr.GetString(p1);
                                oCamposDet.AVANCE = dr.GetDecimal(p2);
                                oCamposDet.FECHA_FIN = dr.GetString(p3);
                                oCamposDet.ESTADO = dr.GetString(p4);

                                lsCEntidad.Add(oCamposDet);
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

        public List<CEntidad> RegListarActiv_EstadoDescSUB(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spRActvListActividadEstadoDescSUB", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p0 = dr.GetOrdinal("mes");
                            int p1 = dr.GetOrdinal("NMes");
                            int p2 = dr.GetOrdinal("Inicio");
                            int p3 = dr.GetOrdinal("Proceso");
                            int p4 = dr.GetOrdinal("Termino");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.NMes = dr.GetString(p1);
                                oCamposDet.cInicio = dr.GetInt32(p2);
                                oCamposDet.cProceso = dr.GetInt32(p3);
                                oCamposDet.cTermino = dr.GetInt32(p4);

                                lsCEntidad.Add(oCamposDet);
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

        public List<CEntidad> RegListarActivAvanceDetalleSUB(SqlConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "ACT.spActivDetalleSUB", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_SUBACTIVIDAD");
                            int p2 = dr.GetOrdinal("NOMBRE");
                            int p3 = dr.GetOrdinal("AVANCE");
                            int p4 = dr.GetOrdinal("OBSERV");
                            int p5 = dr.GetOrdinal("DESCRIPCION");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ACTIVIDAD = dr.GetString(p1);
                                oCamposDet.NOMBRE = dr.GetString(p2);
                                oCamposDet.AVANCE = dr.GetDecimal(p3);
                                oCamposDet.OBSERV = dr.GetString(p4);
                                oCamposDet.ESTADO = dr.GetString(p5);
                                lsCEntidad.Add(oCamposDet);
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
