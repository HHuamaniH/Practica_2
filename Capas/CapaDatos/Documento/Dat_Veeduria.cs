using CapaEntidad.DOC;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEntidad = CapaEntidad.DOC.Ent_Veeduria;

namespace CapaDatos.DOC
{
    public class Dat_Veeduria
    {
        private DBOracle dBOracle = new DBOracle();

        public CEntidad ListarTipo(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRVMaeTipo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        oCampos.ListTipo = new List<CEntidad>();
                        CEntidad oCamposDet;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.NV_TIPO = dr.GetString(dr.GetOrdinal("NV_TIPO"));
                                oCamposDet.NV_DESCRIPCION = dr.GetString(dr.GetOrdinal("NV_DESCRIPCION"));
                                oCamposDet.NV_CATALOGO = dr.GetString(dr.GetOrdinal("NV_CATALOGO"));
                                oCampos.ListTipo.Add(oCamposDet);
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

        public List<Dictionary<string, string>> ListarEquipo(OracleConnection cn, CEntidad oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRVDetEquipo_Integrante_Organizacion_Listar", oCEntidad))
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

        public CEntidad MostrarEquipo(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRVDetEquipo_Integrante_Organizacion_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.NV_EQUIPO_INTEGRANTE_ORGANIZACION = dr.GetString(dr.GetOrdinal("NV_EQUIPO_INTEGRANTE_ORGANIZACION"));
                            oCampos.NV_COMUNIDAD = dr.GetString(dr.GetOrdinal("NV_COMUNIDAD"));
                            oCampos.UBIGEO = dr.GetString(dr.GetOrdinal("UBIGEO"));
                            oCampos.TIPO = dr.GetString(dr.GetOrdinal("TIPO"));
                            oCampos.NV_ORGINTERNA = dr.GetString(dr.GetOrdinal("NV_ORGINTERNA"));
                            oCampos.NV_LUGAR = dr.GetString(dr.GetOrdinal("NV_LUGAR"));
                            oCampos.NV_ORGREGIONAL = dr.GetString(dr.GetOrdinal("NV_ORGREGIONAL"));
                            oCampos.TIPO_DOCUMENTO = dr.GetString(dr.GetOrdinal("TIPO_DOCUMENTO"));
                            oCampos.NV_NUMERO = dr.GetString(dr.GetOrdinal("NV_NUMERO"));
                            oCampos.INTEGRANTE = dr.GetString(dr.GetOrdinal("INTEGRANTE"));
                            oCampos.FE_INICIO = dr.GetString(dr.GetOrdinal("FE_INICIO"));
                            oCampos.FE_TERMINO = dr.GetString(dr.GetOrdinal("FE_TERMINO"));
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

        public CEntidad MostrarOrganizacion(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRvMaeOrganizacion_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.NV_ORGANIZACION = dr.GetString(dr.GetOrdinal("NV_ORGANIZACION"));
                            oCampos.NV_TIPO = dr.GetString(dr.GetOrdinal("NV_TIPO"));
                            oCampos.NV_DESCRIPCION = dr.GetString(dr.GetOrdinal("NV_DESCRIPCION"));
                            oCampos.NV_UBIGEO = dr.GetString(dr.GetOrdinal("NV_UBIGEO"));
                            oCampos.NV_LUGAR = dr.GetString(dr.GetOrdinal("NV_LUGAR"));
                            oCampos.NV_ORGREGIONAL = dr.GetString(dr.GetOrdinal("NV_ORGREGIONAL"));
                            oCampos.FE_CREACION = dr.GetDateTime(dr.GetOrdinal("FE_CREACION")).ToString("dd/MM/yyyy");
                            oCampos.NU_ESTADO = dr.GetInt32(dr.GetOrdinal("NU_ESTADO"));
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

        public CEntidad MostrarIntegrante(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRvMaeIntegrante_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.NV_INTEGRANTE = dr.GetString(dr.GetOrdinal("NV_INTEGRANTE"));
                            oCampos.COD_PERSONA = (!dr.IsDBNull(dr.GetOrdinal("COD_PERSONA"))) ? dr.GetString(dr.GetOrdinal("COD_PERSONA")) : null;
                            oCampos.NV_COD_DIDENTIDAD = dr.GetString(dr.GetOrdinal("NV_COD_DIDENTIDAD"));
                            oCampos.NV_NUMERO = dr.GetString(dr.GetOrdinal("NV_NUMERO"));
                            oCampos.NV_APE_PATERNO = dr.GetString(dr.GetOrdinal("NV_APE_PATERNO"));
                            oCampos.NV_APE_MATERNO = dr.GetString(dr.GetOrdinal("NV_APE_MATERNO"));
                            oCampos.NV_NOMBRES = dr.GetString(dr.GetOrdinal("NV_NOMBRES"));
                            oCampos.FE_CREACION = dr.GetDateTime(dr.GetOrdinal("FE_CREACION")).ToString("dd/MM/yyyy");
                            oCampos.NU_ESTADO = dr.GetInt32(dr.GetOrdinal("NU_ESTADO"));
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

        public CEntidad MostrarUsuario(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRvUsuario_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.APELLIDOS_NOMBRES = dr.GetString(dr.GetOrdinal("APELLIDOS_NOMBRES"));
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

        public String CambiarEstado(OracleConnection cn, CEntidad oCEntidad)
        {
            String OUTPUTPARAM = "";
            OracleTransaction tr = null;
            try
            {
                tr = cn.BeginTransaction();
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spRvMaeEquipo_Activa", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM = (String)cmd.Parameters["OUTPUTPARAM"].Value;

                    if (OUTPUTPARAM.Trim() == "")
                    {
                        throw new Exception("Error al procesar en DB.");
                    }
                }
                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                tr.Dispose();
                tr = null;
                throw ex;
            }
            return OUTPUTPARAM;
        }

        public List<Dictionary<string, string>> ListarRptHallazgo(OracleConnection cn, CEntidad oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRVMaeReporteHallazgo_Listar", oCEntidad))
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

        public CEntidad MostrarHallazgo(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRVMaeReporteHallazgo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("NV_REPORTEHALLAZGO");
                            int pt2 = dr.GetOrdinal("NV_EQUIPO");
                            int pt3 = dr.GetOrdinal("NV_INTEGRANTE");
                            int pt4 = dr.GetOrdinal("NV_TIPO");
                            int pt5 = dr.GetOrdinal("FE_EMISION");
                            int pt6 = dr.GetOrdinal("NV_SECTOR");
                            int pt7 = dr.GetOrdinal("NU_COORDENADA_ESTE");
                            int pt8 = dr.GetOrdinal("NU_COORDENADA_NORTE");
                            int pt9 = dr.GetOrdinal("NV_ZONA");
                            int pt10 = dr.GetOrdinal("NV_VIA");
                            int pt11 = dr.GetOrdinal("NV_VEHICULO");
                            int pt12 = dr.GetOrdinal("NV_FRECUENCIA");
                            int pt13 = dr.GetOrdinal("NV_ACTIVIDAD");
                            int pt14 = dr.GetOrdinal("NU_SUPERFICIE");
                            int pt15 = dr.GetOrdinal("NV_HECHO");
                            int pt16 = dr.GetOrdinal("NV_RESPONSABLE");
                            int pt17 = dr.GetOrdinal("NV_NOMBRE_EMPRESA");
                            int pt18 = dr.GetOrdinal("NV_NOMBRE_EMPRESA_VALIDADO");
                            int pt19 = dr.GetOrdinal("NV_THABILITANTE");
                            int pt20 = dr.GetOrdinal("NV_THABILITANTE_VALIDADO");
                            int pt21 = dr.GetOrdinal("COD_THABILITANTE");
                            int pt22 = dr.GetOrdinal("NV_TITULAR");
                            int pt23 = dr.GetOrdinal("NV_TITULAR_VALIDADO");
                            int pt24 = dr.GetOrdinal("COD_TITULAR");
                            int pt25 = dr.GetOrdinal("NV_OBSERVACION");
                            int pt26 = dr.GetOrdinal("NV_OBSERVACION_VALIDADO");
                            int pt27 = dr.GetOrdinal("NV_SINCRONIZA");
                            int pt28 = dr.GetOrdinal("NV_INTEGRANTE_SINCRONIZA");
                            int pt29 = dr.GetOrdinal("FE_CREACION");
                            int pt30 = dr.GetOrdinal("FE_MODIFICAR");
                            int pt31 = dr.GetOrdinal("COD_UCUENTA_PROCESA");
                            int pt32 = dr.GetOrdinal("FE_PROCESA");
                            int pt33 = dr.GetOrdinal("NU_ESTADO");
                            int pt34 = dr.GetOrdinal("NV_ORGANIZACION");

                            dr.Read();
                            oCampos.NV_REPORTEHALLAZGO = dr.GetString(pt1);
                            oCampos.NV_EQUIPO = dr.GetString(pt2);
                            oCampos.NV_INTEGRANTE = dr.GetString(pt3);
                            oCampos.NV_TIPO = dr.GetString(pt4);
                            oCampos.FE_EMISION = dr.GetDateTime(pt5).ToString("dd/MM/yyyy");
                            oCampos.NV_SECTOR = dr.GetString(pt6);
                            oCampos.NU_COORDENADA_ESTE = (!dr.IsDBNull(pt7)) ? dr.GetInt32(pt7) : 0;
                            oCampos.NU_COORDENADA_NORTE = (!dr.IsDBNull(pt8)) ? dr.GetInt32(pt8) : 0;
                            oCampos.NV_ZONA = (!dr.IsDBNull(pt9)) ? dr.GetString(pt9) : null;
                            oCampos.NV_VIA = (!dr.IsDBNull(pt10)) ? dr.GetString(pt10) : null;
                            oCampos.NV_VEHICULO = (!dr.IsDBNull(pt11)) ? dr.GetString(pt11) : null;
                            oCampos.NV_FRECUENCIA = (!dr.IsDBNull(pt12)) ? dr.GetString(pt12) : null;
                            oCampos.NV_ACTIVIDAD = (!dr.IsDBNull(pt13)) ? dr.GetString(pt13) : null;
                            oCampos.NU_SUPERFICIE = (!dr.IsDBNull(pt14)) ? dr.GetDecimal(pt14) : 0;
                            oCampos.NV_HECHO = (!dr.IsDBNull(pt15)) ? dr.GetString(pt15) : null;
                            oCampos.NV_RESPONSABLE = (!dr.IsDBNull(pt16)) ? dr.GetString(pt16) : null;
                            oCampos.NV_NOMBRE_EMPRESA = (!dr.IsDBNull(pt17)) ? dr.GetString(pt17) : null;
                            oCampos.NV_NOMBRE_EMPRESA_VALIDADO = (!dr.IsDBNull(pt18)) ? dr.GetString(pt18) : null;
                            oCampos.NV_THABILITANTE = (!dr.IsDBNull(pt19)) ? dr.GetString(pt19) : null;
                            oCampos.NV_THABILITANTE_VALIDADO = (!dr.IsDBNull(pt20)) ? dr.GetString(pt20) : null;
                            oCampos.COD_THABILITANTE = (!dr.IsDBNull(pt21)) ? dr.GetString(pt21) : null;
                            oCampos.NV_TITULAR = (!dr.IsDBNull(pt22)) ? dr.GetString(pt22) : null;
                            oCampos.NV_TITULAR_VALIDADO = (!dr.IsDBNull(pt23)) ? dr.GetString(pt23) : null;
                            oCampos.COD_TITULAR = (!dr.IsDBNull(pt24)) ? dr.GetString(pt24) : null;
                            oCampos.NV_OBSERVACION = (!dr.IsDBNull(pt25)) ? dr.GetString(pt25) : null;
                            oCampos.NV_OBSERVACION_VALIDADO = (!dr.IsDBNull(pt26)) ? dr.GetString(pt26) : null;
                            //Auditoría
                            oCampos.NV_SINCRONIZA = dr.GetString(pt27);
                            oCampos.NV_INTEGRANTE_SINCRONIZA = (!dr.IsDBNull(pt28)) ? dr.GetString(pt28) : null;
                            oCampos.FE_CREACION = dr.GetDateTime(pt29).ToString("dd/MM/yyyy");
                            oCampos.FE_MODIFICAR = (!dr.IsDBNull(pt30)) ? dr.GetDateTime(pt30).ToString("dd/MM/yyyy") : null;
                            oCampos.COD_UCUENTA_PROCESA = (!dr.IsDBNull(pt31)) ? dr.GetString(pt31) : null;
                            oCampos.FE_PROCESA = (!dr.IsDBNull(pt32)) ? dr.GetDateTime(pt32).ToString("dd/MM/yyyy") : null;
                            oCampos.NU_ESTADO = dr.GetInt32(pt33);
                            oCampos.NV_ORGANIZACION = dr.GetString(pt34);
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

        public CEntidad ListarDetHallazgo(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRvDetReporteHallazgo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        oCampos.ListDetHallazgo = new List<CEntidad>();
                        CEntidad oCamposDet;

                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("NV_DETREPORTEHALLAZGO");
                            int pt2 = dr.GetOrdinal("NV_REPORTEHALLAZGO");
                            int pt3 = dr.GetOrdinal("NU_COORDENADA_ESTE");
                            int pt4 = dr.GetOrdinal("NU_COORDENADA_NORTE");
                            int pt5 = dr.GetOrdinal("NV_ZONA");
                            int pt6 = dr.GetOrdinal("NV_TIPO");
                            int pt7 = dr.GetOrdinal("NV_ESPECIES");
                            int pt8 = dr.GetOrdinal("NV_ESPECIES_VALIDADO");
                            int pt9 = dr.GetOrdinal("COD_ESPECIES");
                            int pt10 = dr.GetOrdinal("NU_DIAMAYOR_ESPESOR");
                            int pt11 = dr.GetOrdinal("NU_DIAMENOR_ANCHO");
                            int pt12 = dr.GetOrdinal("NU_LONGITUD");
                            int pt13 = dr.GetOrdinal("NU_VOLUMEN");
                            int pt14 = dr.GetOrdinal("NV_OBSERVACION");
                            int pt15 = dr.GetOrdinal("NV_OBSERVACION_VALIDADO");
                            int pt16 = dr.GetOrdinal("USUARIO_VALIDA");
                            int pt17 = dr.GetOrdinal("NU_ESTADO");
                            int pt18 = dr.GetOrdinal("ESTADO");
                            int pt19 = dr.GetOrdinal("NV_DESCRIPCION");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.NV_DETREPORTEHALLAZGO = dr.GetString(pt1);
                                oCamposDet.NV_REPORTEHALLAZGO = dr.GetString(pt2);
                                oCamposDet.NU_COORDENADA_ESTE = dr.GetInt32(pt3);
                                oCamposDet.NU_COORDENADA_NORTE = dr.GetInt32(pt4);
                                oCamposDet.NV_ZONA = dr.GetString(pt5);
                                oCamposDet.NV_TIPO = (!dr.IsDBNull(pt6)) ? dr.GetString(pt6) : null;
                                oCamposDet.NV_ESPECIES = dr.GetString(pt7);
                                oCamposDet.NV_ESPECIES_VALIDADO = (!dr.IsDBNull(pt8)) ? dr.GetString(pt8) : null;
                                oCamposDet.COD_ESPECIES = (!dr.IsDBNull(pt9)) ? dr.GetString(pt9) : null;
                                oCamposDet.NU_DIAMAYOR_ESPESOR = dr.GetDecimal(pt10);
                                oCamposDet.NU_DIAMENOR_ANCHO = dr.GetDecimal(pt11);
                                oCamposDet.NU_LONGITUD = dr.GetDecimal(pt12);
                                oCamposDet.NU_VOLUMEN = dr.GetDecimal(pt13);
                                oCamposDet.NV_OBSERVACION = (!dr.IsDBNull(pt14)) ? dr.GetString(pt14) : null;
                                oCamposDet.NV_OBSERVACION_VALIDADO = (!dr.IsDBNull(pt15)) ? dr.GetString(pt15) : null;
                                oCamposDet.USUARIO_VALIDA = (!dr.IsDBNull(pt16)) ? dr.GetString(pt16) : null;
                                oCamposDet.NU_ESTADO = dr.GetInt32(pt17);
                                oCamposDet.ESTADO = dr.GetString(pt18);
                                oCamposDet.NV_DESCRIPCION = (!dr.IsDBNull(pt19)) ? dr.GetString(pt19) : null;
                                oCamposDet.RegEstado = 0;

                                oCampos.ListDetHallazgo.Add(oCamposDet);
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

        public CEntidad ListarTHabilitante(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRvMaeReporteHallazgo_TH_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        oCampos.ListTHabilitante = new List<CEntidad>();
                        CEntidad oCamposDet;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();

                                switch (oCEntidad.BUS_CRITERIO)
                                {
                                    case "LISTA":
                                        oCamposDet.NV_TH = dr.GetString(dr.GetOrdinal("NV_TH"));
                                        oCamposDet.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                                        oCamposDet.COD_SECUENCIA = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIA"));
                                        oCamposDet.FECHA_REGISTRO = dr.GetString(dr.GetOrdinal("FECHA_REGISTRO"));
                                        oCamposDet.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                        oCamposDet.THABILITANTE = dr.GetString(dr.GetOrdinal("THABILITANTE"));
                                        oCamposDet.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                        oCamposDet.RLEGAL = dr.GetString(dr.GetOrdinal("RLEGAL"));
                                        oCamposDet.REGION = dr.GetString(dr.GetOrdinal("REGION"));
                                        oCamposDet.RegEstado = 0;
                                        break;
                                    case "TITULO_HABILITANTE":
                                    case "TITULAR":
                                        oCamposDet.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                                        oCamposDet.COD_TITULAR = (!dr.IsDBNull(dr.GetOrdinal("COD_TITULAR"))) ? dr.GetString(dr.GetOrdinal("COD_TITULAR")) : null;
                                        oCamposDet.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));
                                        oCamposDet.THABILITANTE = dr.GetString(dr.GetOrdinal("THABILITANTE"));
                                        oCamposDet.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                                        oCamposDet.RLEGAL = dr.GetString(dr.GetOrdinal("RLEGAL"));
                                        oCamposDet.REGION = dr.GetString(dr.GetOrdinal("REGION"));
                                        break;
                                }

                                oCampos.ListTHabilitante.Add(oCamposDet);
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

        public CEntidad ListarArchivo(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRvMaeArchivo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        oCampos.ListArchivo = new List<CEntidad>();
                        CEntidad oCamposDet;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.NV_NOMBRE = dr.GetString(dr.GetOrdinal("NV_NOMBRE"));
                                oCamposDet.RUTA = dr.GetString(dr.GetOrdinal("RUTA"));
                                oCampos.ListArchivo.Add(oCamposDet);
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

        public String Inicia_ProcesarHallazgo(OracleConnection cn, CEntidad oCEntidad)
        {
            String OUTPUTPARAM = "";
            OracleTransaction tr = null;
            try
            {
                tr = cn.BeginTransaction();
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spRvMaeReporteHallazgo_PROCESA", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM = (String)cmd.Parameters["OUTPUTPARAM"].Value;

                    if (OUTPUTPARAM.Trim() == "")
                    {
                        throw new Exception("Error al procesar en DB.");
                    }
                }
                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                tr.Dispose();
                tr = null;
                throw ex;
            }
            return OUTPUTPARAM;
        }

        public String GrabarHallazgo(OracleConnection cn, CEntidad oCEntidad)
        {
            String OUTPUTPARAM = "", OUTPUTPARAM01;
            OracleTransaction tr = null;
            CEntidad oCamposDet;
            try
            {
                tr = cn.BeginTransaction();
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spRvMaeReporteHallazgo_Grabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM = (String)cmd.Parameters["OUTPUTPARAM"].Value;

                    if (OUTPUTPARAM.Trim() == "")
                    {
                        throw new Exception("Error al procesar en DB.");
                    }
                }

                if (oCEntidad.ListDetHallazgo != null)
                {
                    foreach (var loDatos in oCEntidad.ListDetHallazgo)
                    {
                        OUTPUTPARAM01 = "";
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.NV_DETREPORTEHALLAZGO = loDatos.NV_DETREPORTEHALLAZGO;
                        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                        oCamposDet.NV_OBSERVACION_VALIDADO = loDatos.NV_OBSERVACION_VALIDADO;
                        oCamposDet.NU_ESTADO = loDatos.NU_ESTADO;
                        oCamposDet.RegEstado = loDatos.RegEstado;

                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spRvDetReporteHallazgo_valida", oCamposDet))
                        {
                            cmd.ExecuteNonQuery();
                            OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM"].Value;

                            if (OUTPUTPARAM01.Split('|')[0] == "0")
                            {
                                OUTPUTPARAM = "";
                                throw new Exception("Error al procesar en DB.");
                            }
                        }
                    }
                }

                if (oCEntidad.ListTHabilitante != null)
                {
                    foreach (var loDatos in oCEntidad.ListTHabilitante)
                    {
                        OUTPUTPARAM01 = "";
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.NV_REPORTEHALLAZGO = loDatos.NV_REPORTEHALLAZGO;
                        oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                        oCamposDet.NU_ESTADO = loDatos.NU_ESTADO;
                        oCamposDet.RegEstado = loDatos.RegEstado;

                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spRvMaeReporteHallazgo_TH_Grabar", oCamposDet))
                        {
                            cmd.ExecuteNonQuery();
                            OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM"].Value;

                            if (OUTPUTPARAM01.Trim() == "")
                            {
                                OUTPUTPARAM = "";
                                throw new Exception("Error al procesar en DB.");
                            }
                        }
                    }
                }

                if (oCEntidad.ListElimTHabilitante != null)
                {
                    foreach (var loDatos in oCEntidad.ListElimTHabilitante)
                    {
                        OUTPUTPARAM01 = "";
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        oCamposDet.NV_TH = loDatos.NV_TH;
                        oCamposDet.NV_REPORTEHALLAZGO = loDatos.NV_REPORTEHALLAZGO;
                        oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                        oCamposDet.NU_ESTADO = loDatos.NU_ESTADO;
                        oCamposDet.RegEstado = loDatos.RegEstado;

                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spRvMaeReporteHallazgo_TH_Grabar", oCamposDet))
                        {
                            cmd.ExecuteNonQuery();
                            OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM"].Value;

                            if (OUTPUTPARAM01.Trim() == "")
                            {
                                OUTPUTPARAM = "";
                                throw new Exception("Error al procesar en DB.");
                            }
                        }
                    }
                }

                if (oCEntidad.NU_ESTADO == 3)
                {
                    oCamposDet = new CEntidad();
                    oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                    oCamposDet.NV_REPORTEHALLAZGO = oCEntidad.NV_REPORTEHALLAZGO;
                    oCamposDet.NU_ESTADO = oCEntidad.NU_ESTADO;
                    oCamposDet.RegEstado = oCEntidad.RegEstado;

                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spRvMaeReporteHallazgo_PROCESA", oCamposDet))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM = (String)cmd.Parameters["OUTPUTPARAM"].Value;

                        if (OUTPUTPARAM.Trim() == "")
                        {
                            throw new Exception("Error al procesar en DB.");
                        }
                    }
                }

                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                tr.Dispose();
                tr = null;

                if (OUTPUTPARAM.Substring(0, 1) == "1")
                {
                    OUTPUTPARAM = "";
                }
                throw ex;
            }
            return OUTPUTPARAM;
        }

        public CEntidad ListarEnviado(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRvDetReporteHallazgoEnvio_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        oCampos.ListEnviado = new List<CEntidad>();
                        CEntidad oCamposDet;

                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("NV_ENVIO");
                            int pt2 = dr.GetOrdinal("NV_REPORTEHALLAZGO");
                            int pt3 = dr.GetOrdinal("NV_PARA");
                            int pt4 = dr.GetOrdinal("NV_CC");
                            int pt5 = dr.GetOrdinal("NV_CUERPO");
                            int pt6 = dr.GetOrdinal("COD_UCUENTA");
                            int pt7 = dr.GetOrdinal("FE_CREACION");
                            int pt8 = dr.GetOrdinal("NU_ESTADO");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.NV_ENVIO = dr.GetString(pt1);
                                oCamposDet.NV_REPORTEHALLAZGO = dr.GetString(pt2);
                                oCamposDet.NV_PARA = dr.GetString(pt3);
                                oCamposDet.NV_CC = dr.GetString(pt4);
                                //oCamposDet.NV_CUERPO = dr.GetString(pt5);
                                oCamposDet.COD_UCUENTA = dr.GetString(pt6);
                                oCamposDet.FE_CREACION = dr.GetDateTime(pt7).ToString("dd/MM/yyyy");
                                oCamposDet.NU_ESTADO = dr.GetInt32(pt8);

                                oCampos.ListEnviado.Add(oCamposDet);
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

        public CEntidad ListarCorreo(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRvCorreos_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        oCampos.ListCorreo = new List<CEntidad>();
                        CEntidad oCamposDet;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CORREO = dr.GetString(dr.GetOrdinal("CORREO"));
                                oCamposDet.OFICINA = dr.GetString(dr.GetOrdinal("OFICINA"));
                                oCampos.ListCorreo.Add(oCamposDet);
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

        public String GrabarEnviado(OracleConnection cn, CEntidad oCEntidad)
        {
            String OUTPUTPARAM = "";
            OracleTransaction tr = null;

            try
            {
                tr = cn.BeginTransaction();
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spRvDetReporteHallazgoEnvio_Grabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM = (String)cmd.Parameters["OUTPUTPARAM"].Value;

                    if (OUTPUTPARAM.Trim() == "")
                    {
                        throw new Exception("Error al procesar en DB.");
                    }
                }
                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                tr.Dispose();
                tr = null;
                throw ex;
            }
            return OUTPUTPARAM;
        }
    }
}