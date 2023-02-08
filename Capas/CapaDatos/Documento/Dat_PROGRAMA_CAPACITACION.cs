using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client; //using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_PROGRAMA_CAPACITACION;
using GeneralSQL; //using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_PROGRAMA_CAPACITACION
    {
        private DBOracle dBOracle = new DBOracle(); //private SQL dBOracle = new SQL();

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
                        CEntidad oCamposDet;
                        //Oficina Desconcentrada
                        oCampos.ListMComboOD = new List<CEntidad>();
                        oCampos.ListMComboConveniosAFF = new List<CEntidad>();
                        oCampos.ListMComboConveniosOI = new List<CEntidad>();
                        oCampos.ListMComboConveniosOIA = new List<CEntidad>();
                        oCampos.ListMComboConvenios = new List<CEntidad>();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCampos.ListMComboOD.Add(oCamposDet);
                            }
                        }
                        // 2 Tipos de Capacitaciones
                        dr.NextResult();
                        oCampos.ListMComboTipoCapacitacion = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCampos.ListMComboTipoCapacitacion.Add(oCamposDet);
                            }
                        }
                        //3 Entidad Financia el taller
                        dr.NextResult();
                        oCampos.ListMComboEntidadFinancia = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCampos.ListMComboEntidadFinancia.Add(oCamposDet);
                            }
                        }
                        //4 --Marco Convenio - a.	Autoridades forestales de fiscalización
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCampos.ListMComboConveniosAFF.Add(oCamposDet);
                            }
                        }
                        //5 --Marco Convenio - b.	Organizaciones indígenas
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCampos.ListMComboConveniosOI.Add(oCamposDet);
                            }
                        }
                        //6 --Marco Convenio - c.	Organizaciones de investigación o afines
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCampos.ListMComboConveniosOIA.Add(oCamposDet);
                            }
                        }
                        //7 --Marco Convenio SIGOsfc v3
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCamposDet.GRUPO = dr.GetString(dr.GetOrdinal("GRUPO"));
                                oCampos.ListMComboConvenios.Add(oCamposDet);
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

        public CEntidad RegMostrarListaItems(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPROGRAMA_CAPACITACIONMostItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        oCampos.ListCapacitacionConvenios = new List<CEntidad>();

                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                oCampos.COD_PCAPACITACION = dr.GetString(dr.GetOrdinal("COD_PCAPACITACION"));
                                oCampos.NOMBRE = dr.GetString(dr.GetOrdinal("NOMBRE"));
                                oCampos.COD_CAPATIPO = dr.GetString(dr.GetOrdinal("COD_CAPATIPO"));
                                oCampos.COD_OD = dr.GetString(dr.GetOrdinal("COD_OD"));
                                oCampos.COD_UBIGEO = dr.GetString(dr.GetOrdinal("COD_UBIGEO"));
                                oCampos.UBIGEO_DESCRIPCION = dr.GetString(dr.GetOrdinal("UBIGEO_DESCRIPCION"));
                                oCampos.LUGAR = dr.GetString(dr.GetOrdinal("LUGAR"));
                                oCampos.FECHA_INICIO = dr.GetString(dr.GetOrdinal("FECHA_INICIO"));
                                oCampos.DIRIGIDO = dr.GetString(dr.GetOrdinal("DIRIGIDO"));
                                oCampos.MAE_ENT_FINANCIA = dr.GetString(dr.GetOrdinal("MAE_ENT_FINANCIA"));
                                oCampos.FUENTE_COOPERANTE = dr.GetString(dr.GetOrdinal("FUENTE_COOPERANTE"));
                                oCampos.SUMA_POI = dr.GetBoolean(dr.GetOrdinal("SUMA_POI"));
                                oCampos.MARCO_CONVENIO = dr.GetBoolean(dr.GetOrdinal("MARCO_CONVENIO"));
                            }
                        }

                        //CAPACITACION_CONVENIOS
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_MARCO_CONVENIO = dr.GetString(dr.GetOrdinal("COD_MARCO_CONVENIO"));
                                oCamposDet.MAE_GRUPO_CONVENIO = dr.GetString(dr.GetOrdinal("MAE_GRUPO_CONVENIO"));
                                oCampos.ListCapacitacionConvenios.Add(oCamposDet);
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

        public String RegGrabar(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";

            try
            {
                CEntidad oCamposDet;


                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPROGRAMA_CAPACITACIONGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                    if (OUTPUTPARAM01 == "0")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Nombre de la Capacitación ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Este Control de Calidad no puede modificarse");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Registro");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Nombre de la Capacitación ya Existe");
                    }
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_PCAPACITACION = OUTPUTPARAM01;
                }

                if (oCEntidad.ListCapacitacionConvenios != null)
                {
                    foreach (var loDatos in oCEntidad.ListCapacitacionConvenios)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_PCAPACITACION = oCEntidad.COD_PCAPACITACION;
                        oCamposDet.COD_MARCO_CONVENIO = loDatos.COD_MARCO_CONVENIO;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPCAPACITACION_MCONVENIO_Grabar", oCamposDet);
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

        #region REPORTE PROGRAMACIÓN CAPACITACIONES
        public List<CEntidad> RegMostrarProgramacionCapacitacionesResumen(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lstCEntidad;
            CEntidad oCampos;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteProgramacionCapacitaciones", oCEntidad))
                {
                    lstCEntidad = new List<CEntidad>();
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_OD = dr["COD_OD"].ToString();
                                oCampos.OD = dr["OD"].ToString();
                                oCampos.TP0000001 = Int32.Parse(dr["TP0000001"].ToString());
                                oCampos.TE0000001 = Int32.Parse(dr["TE0000001"].ToString());
                                oCampos.TP0000002 = Int32.Parse(dr["TP0000002"].ToString());
                                oCampos.TE0000002 = Int32.Parse(dr["TE0000002"].ToString());
                                oCampos.TP0000003 = Int32.Parse(dr["TP0000003"].ToString());
                                oCampos.TE0000003 = Int32.Parse(dr["TE0000003"].ToString());
                                oCampos.TP0000004 = Int32.Parse(dr["TP0000004"].ToString());
                                oCampos.TE0000004 = Int32.Parse(dr["TE0000004"].ToString());
                                oCampos.TPTOTAL = Int32.Parse(dr["TPTOTAL"].ToString());
                                oCampos.TETOTAL = Int32.Parse(dr["TETOTAL"].ToString());
                                lstCEntidad.Add(oCampos);
                            }
                        }
                    }
                }
                return lstCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> RegMostrarProgramacionCapacitacionesDetalle(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lstCEntidad;
            CEntidad oCampos;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteProgramacionCapacitaciones", oCEntidad))
                {
                    lstCEntidad = new List<CEntidad>();
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_PCAPACITACION = dr["COD_PCAPACITACION"].ToString();
                                oCampos.NOMBRE = dr["NOMBRE"].ToString();
                                oCampos.OD = dr["OD"].ToString();
                                oCampos.TIPO_TALLER = dr["TIPO_TALLER"].ToString();
                                oCampos.NOMBRE_MES = dr["NOMBRE_MES"].ToString();
                                oCampos.FECHA_INICIO = dr["FECHA_INICIO"].ToString();
                                oCampos.DEPARTAMENTO = dr["DEPARTAMENTO"].ToString();
                                oCampos.EJECUTADO = dr["EJECUTADO"].ToString();
                                oCampos.N_PARTICIPANTES = Int32.Parse(dr["N_PARTICIPANTES"].ToString());
                                lstCEntidad.Add(oCampos);
                            }
                        }
                    }
                }
                return lstCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region SIGOsfc v3
        public List<Dictionary<string, string>> ReportesProgramaCapacitacion(OracleConnection cn, CEntidad oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spReporteProgramaCapacitacion", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            Dictionary<string, string> sFila;
                            switch (oCEntidad.TIPO_REPORTE)
                            {
                                #region Programación de Capacitaciones registradas
                                case "REGISTRO_USUARIO":
                                    while (dr.Read())
                                    {
                                        sFila = new Dictionary<string, string>();
                                        sFila.Add("COD_CAPACITACION", dr["COD_CAPACITACION"].ToString());
                                        sFila.Add("NOMBRE", dr["NOMBRE"].ToString());
                                        sFila.Add("TIPO", dr["TIPO"].ToString());
                                        sFila.Add("ANIO", dr["ANIO"].ToString());
                                        sFila.Add("FECHA_INICIO", dr["FECHA_INICIO"].ToString());
                                        sFila.Add("SUMA_POI", dr["SUMA_POI"].ToString());
                                        sFila.Add("ENTIDAD_FINANCIA", dr["ENTIDAD_FINANCIA"].ToString());
                                        sFila.Add("OD", dr["OD"].ToString());
                                        sFila.Add("DEPARTAMENTO", dr["DEPARTAMENTO"].ToString());
                                        sFila.Add("PROVINCIA", dr["PROVINCIA"].ToString());
                                        sFila.Add("DISTRITO", dr["DISTRITO"].ToString());
                                        sFila.Add("LUGAR", dr["LUGAR"].ToString());
                                        sFila.Add("MARCO_COVENIO", dr["MARCO_COVENIO"].ToString());
                                        sFila.Add("INSTITUCION_CONVENIO", dr["INSTITUCION_CONVENIO"].ToString());
                                        sFila.Add("USUARIO_REGISTRO", dr["USUARIO_REGISTRO"].ToString());
                                        sFila.Add("FECHA_REGISTRO", dr["FECHA_REGISTRO"].ToString());
                                        lstResult.Add(sFila);
                                    }
                                    break;
                                    #endregion
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
        #endregion
    }
}
