using GeneralSQL;
using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using CEntidad = CapaEntidad.DOC.Ent_PREVIOS_ALERTA;

using SQL = GeneralSQL.Data.SQL;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
/// <summary>
/// </summary>
namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_PREVIOS_ALERTA
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        public CEntidad RegMostrarListaItems(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPREV_ALERMostItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListDESTINATARIO = new List<CEntidad>();
                        oCampos.ListEliTABLA = new List<CEntidad>();
                        oCampos.ListRUTA = new List<CEntidad>();
                        oCampos.ListDESTINATARIO_RUTA = new List<CEntidad>();
                        oCampos.ListSUPUESTO = new List<CEntidad>();                   
                        oCampos.ListDESTINATARIOCC = new List<CEntidad>();
                        oCampos.ListCOADMINISTRADOR = new List<CEntidad>();
                        oCampos.ListPERFILCOADMINISTRADOR = new List<CEntidad>();
                        oCampos.ListENTIDAD = new List<CEntidad>();
                        

                        CEntidad oCamposDet;

                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_DESTINATARIO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            int pt3 = dr.GetOrdinal("CORREO");
                            int pt4 = dr.GetOrdinal("OFICINA");
                            int pt5 = dr.GetOrdinal("ACTIVO");
                            int pt6 = dr.GetOrdinal("DOCUMENTO");
                            int pt7 = dr.GetOrdinal("FECHA_DOCUMENTO");
                            int pt8 = dr.GetOrdinal("CARGO");
                            int pt9 = dr.GetOrdinal("COD_PERSONA");
                            int pt10 = dr.GetOrdinal("OBSERVACION");
                            int pt11 = dr.GetOrdinal("TIPO_FUNCIONARIO");
                            int pt12 = dr.GetOrdinal("SUPUESTOS_DESTINATARIO");
                            int pt13 = dr.GetOrdinal("COD_ENTIDAD");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_DESTINATARIO = dr.GetInt32(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oCamposDet.CORREO = dr.GetString(pt3);
                                oCamposDet.OFICINA = dr.GetString(pt4);
                                oCamposDet.ACTIVO = dr.GetBoolean(pt5) ? 1 : 0;
                                oCamposDet.DOCUMENTO = dr.GetString(pt6);
                                oCamposDet.FECHA_DOCUMENTO = Convert.ToDateTime(dr["FECHA_DOCUMENTO"]).ToShortDateString(); //dr.GetString(pt7).ToString(); DateTime.ParseExact("02/18/2021", "dd/MM/yyyy", provider); //
                                oCamposDet.CARGO = dr.GetString(pt8);
                                oCamposDet.COD_PERSONA = dr.GetString(pt9);
                                oCamposDet.OBSERVACION = dr.GetString(pt10);
                                oCamposDet.TIPO_FUNCIONARIO = dr.GetInt32(pt11);
                                oCamposDet.SUPUESTOS_DESTINATARIO = dr.GetString(pt12);
                                oCamposDet.COD_ENTIDAD = dr.GetString(pt13);
                                oCampos.ListDESTINATARIO.Add(oCamposDet);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_RUTA");
                            int pt2 = dr.GetOrdinal("DEPARTAMENTO");
                            int pt3 = dr.GetOrdinal("ACTIVO");
                            int pt4 = dr.GetOrdinal("TRAMO");
                            int pt5 = dr.GetOrdinal("ORIGEN_DESTINO");
                            int pt6 = dr.GetOrdinal("COD_UBIDEPARTAMENTO");


                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_RUTA = dr.GetInt32(pt1);
                                oCamposDet.DEPARTAMENTO = dr.GetString(pt2);
                                oCamposDet.ACTIVO = dr.GetBoolean(pt3) ? 1 : 0;
                                oCamposDet.TRAMO = dr.GetString(pt4);
                                oCamposDet.ORIGEN_DESTINO = dr.GetString(pt5);
                                oCamposDet.COD_UBIDEPARTAMENTO = dr.GetString(pt6);

                                oCampos.ListRUTA.Add(oCamposDet);

                            }
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {


                            int pt1 = dr.GetOrdinal("COD_RUTA");
                            int pt2 = dr.GetOrdinal("DEPARTAMENTO");
                            int pt3 = dr.GetOrdinal("ORIGEN_DESTINO");
                            int pt4 = dr.GetOrdinal("TRAMO");
                            int pt5 = dr.GetOrdinal("DESCRIPCION");


                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_RUTA = dr.GetInt32(pt1);
                                oCamposDet.DEPARTAMENTO = dr.GetString(pt2);
                                oCamposDet.ORIGEN_DESTINO = dr.GetString(pt3);
                                oCamposDet.TRAMO = dr.GetString(pt4);
                                oCamposDet.DESCRIPCION = dr.IsDBNull(pt5) ? "" : dr.GetString(pt5);


                                oCampos.ListDESTINATARIO_RUTA.Add(oCamposDet);

                            }
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {


                            int pt1 = dr.GetOrdinal("COD_SUPUESTO");
                            int pt2 = dr.GetOrdinal("ABREV_SUPUESTO");
                            int pt3 = dr.GetOrdinal("DES_SUPUESTO");
                            int pt4 = dr.GetOrdinal("ACTIVO");
                            int pt5 = dr.GetOrdinal("ACTIVO_DESC");
                            int pt6 = dr.GetOrdinal("NOMBRE_ARCHIVO");
                            int pt7 = dr.GetOrdinal("NOMBRE_ARCHIVO_REAL");


                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_SUPUESTO = dr.GetInt32(pt1);
                                oCamposDet.ABREV_SUPUESTO = dr.GetString(pt2);
                                oCamposDet.DES_SUPUESTO = dr.GetString(pt3);
                                oCamposDet.ACTIVO = dr.GetInt32(pt4);
                                oCamposDet.ACTIVO_DESC = dr.GetString(pt5);
                                oCamposDet.NOMBRE_ARCHIVO = dr.GetString(pt6);
                                oCamposDet.NOMBRE_ARCHIVO_REAL = dr.GetString(pt7);

                                oCampos.ListSUPUESTO.Add(oCamposDet);

                            }
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_DESTINATARIO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            int pt3 = dr.GetOrdinal("CORREO");
                            int pt4 = dr.GetOrdinal("OFICINA");
                            int pt5 = dr.GetOrdinal("ACTIVO");
                            int pt6 = dr.GetOrdinal("DOCUMENTO");
                            int pt7 = dr.GetOrdinal("FECHA_DOCUMENTO");
                            int pt8 = dr.GetOrdinal("CARGO");
                            int pt9 = dr.GetOrdinal("COD_PERSONA");
                            int pt10 = dr.GetOrdinal("OBSERVACION");
                            int pt11 = dr.GetOrdinal("TIPO_FUNCIONARIO");                           

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_DESTINATARIO = dr.GetInt32(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oCamposDet.CORREO = dr.GetString(pt3);
                                oCamposDet.OFICINA = dr.GetString(pt4);
                                oCamposDet.ACTIVO = dr.GetBoolean(pt5) ? 1 : 0;
                                oCamposDet.DOCUMENTO = dr.GetString(pt6);
                                oCamposDet.FECHA_DOCUMENTO = Convert.ToDateTime(dr["FECHA_DOCUMENTO"]).ToShortDateString(); 
                                oCamposDet.CARGO = dr.GetString(pt8);
                                oCamposDet.COD_PERSONA = dr.GetString(pt9);
                                oCamposDet.OBSERVACION = dr.GetString(pt10);
                                oCamposDet.TIPO_FUNCIONARIO = dr.GetInt32(pt11);                               
                                oCampos.ListDESTINATARIOCC.Add(oCamposDet);
                            }
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_UCUENTA");
                            int pt2 = dr.GetOrdinal("FECHA_CREACION");
                            int pt3 = dr.GetOrdinal("DESCRIPCION");
                            int pt4 = dr.GetOrdinal("USUARIO");
                            int pt5 = dr.GetOrdinal("ACTIVO_DESC");
                            int pt6 = dr.GetOrdinal("CARGO");
                            int pt7 = dr.GetOrdinal("CORREO");
                            int pt8 = dr.GetOrdinal("ACTIVO");
                            int pt9 = dr.GetOrdinal("DOCUMENTO");
                            int pt10 = dr.GetOrdinal("FECHA_DOCUMENTO");
                            int pt11 = dr.GetOrdinal("OFICINA");
                            int pt12 = dr.GetOrdinal("OBSERVACION");
                            int pt13 = dr.GetOrdinal("COD_PERSONA");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_UCUENTA = dr.GetString(pt1);
                                oCamposDet.FECHA_REGISTRO = Convert.ToDateTime(dr["FECHA_CREACION"]).ToShortDateString();
                                oCamposDet.DESCRIPCION = dr.GetString(pt3);
                                oCamposDet.USUARIO = dr.GetString(pt4);
                                oCamposDet.ACTIVO_DESC = dr.GetString(pt5);
                                oCamposDet.CARGO = dr.GetString(pt6);
                                oCamposDet.CORREO = dr.GetString(pt7);
                                oCamposDet.ACTIVO = dr.GetInt32(pt8);
                                oCamposDet.DOCUMENTO = dr.GetString(pt9);
                                oCamposDet.FECHA_DOCUMENTO = Convert.ToDateTime(dr["FECHA_DOCUMENTO"]).ToShortDateString();
                                oCamposDet.OFICINA = dr.GetString(pt11);
                                oCamposDet.OBSERVACION = dr.GetString(pt12);
                                oCamposDet.COD_PERSONA = dr.GetString(pt13);
                                oCampos.ListCOADMINISTRADOR.Add(oCamposDet);
                                
                            }
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("ACTIVO");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COADMIN = dr.GetInt32(pt1);
                                oCampos.ListPERFILCOADMINISTRADOR.Add(oCamposDet);
                            }
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_PERSONA");
                            int pt2 = dr.GetOrdinal("RAZON_SOCIAL");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_ENTIDAD = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oCampos.ListENTIDAD.Add(oCamposDet);
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

        public CEntidad MostrarListaDestinatarioRuta(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPREV_ALERDestinatarioRuta", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListDESTINATARIO = new List<CEntidad>();
                        //    oCampos.ListDESTINATARIOSELECT = new List<CEntidad>();
                        oCampos.ListEliTABLA = new List<CEntidad>();
                        oCampos.ListRUTA = new List<CEntidad>();
                        oCampos.ListDESTINATARIO_RUTA = new List<CEntidad>();

                        CEntidad oCamposDet;



                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_DESTINATARIO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            int pt3 = dr.GetOrdinal("CORREO");
                            int pt4 = dr.GetOrdinal("OFICINA");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_DESTINATARIO = dr.GetInt32(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oCamposDet.CORREO = dr.GetString(pt3);
                                oCamposDet.OFICINA = dr.GetString(pt4);
                                oCampos.ListDESTINATARIO.Add(oCamposDet);

                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_RUTA");
                            int pt2 = dr.GetOrdinal("DEPARTAMENTO");
                            int pt3 = dr.GetOrdinal("TRAMO");



                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_RUTA = dr.GetInt32(pt1);
                                oCamposDet.DEPARTAMENTO = dr.GetString(pt2);
                                oCamposDet.TRAMO = dr.GetString(pt3);


                                oCampos.ListRUTA.Add(oCamposDet);

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

        public CEntidad MostrarListaDestinatarioRutaXCodRuta(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPREV_ALERDestinatarioRutaxCodRuta", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListDESTINATARIO = new List<CEntidad>();
                        oCampos.ListEliTABLA = new List<CEntidad>();
                        oCampos.ListRUTA = new List<CEntidad>();
                        oCampos.ListDESTINATARIO_RUTA = new List<CEntidad>();

                        CEntidad oCamposDet;

                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_RUTA");
                            int pt2 = dr.GetOrdinal("COD_DESTINATARIO");
                            int pt3 = dr.GetOrdinal("COD_DESTINATARIO_RUTA");
                            int pt4 = dr.GetOrdinal("DESCRIPCION");
                            int pt5 = dr.GetOrdinal("CORREO");
                            int pt6 = dr.GetOrdinal("OFICINA");




                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_RUTA = dr.GetInt32(pt1);
                                oCamposDet.COD_DESTINATARIO = dr.GetInt32(pt2);
                                oCamposDet.COD_DESTINATARIO_RUTA = dr.GetInt32(pt3);
                                oCamposDet.DESCRIPCION = dr.GetString(pt4);
                                oCamposDet.CORREO = dr.GetString(pt5);
                                oCamposDet.OFICINA = dr.GetString(pt6);



                                oCampos.ListDESTINATARIO_RUTA.Add(oCamposDet);

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

        public String RegGrabarDestinatario(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            String OUTPUTPARAM02 = "";

            try
            {
                tr = cn.BeginTransaction();

                if (oCEntidad.ListDESTINATARIO != null)
                {
                    foreach (var loDatos in oCEntidad.ListDESTINATARIO)
                    {
                        loDatos.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        loDatos.RegEstado = oCEntidad.RegEstado;
                        loDatos.OUTPUTPARAM01 = "";
                        loDatos.OUTPUTPARAM02 = "";
                        loDatos.FECHA_DOCUMENTO = (loDatos.FECHA_DOCUMENTO==null|| loDatos.FECHA_DOCUMENTO.ToString()=="")? (DateTime?)null : Convert.ToDateTime(loDatos.FECHA_DOCUMENTO);
                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPrevAlertSaveDestinatario", loDatos))
                        {
                            cmd.ExecuteNonQuery();
                            OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                            OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;

                        }
                    }

                }
                tr.Commit();
                return OUTPUTPARAM02 + '|' + OUTPUTPARAM01;
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

        public String RegGrabarCOAdministrador(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            String OUTPUTPARAM02 = "";

            try
            {
                tr = cn.BeginTransaction();

                if (oCEntidad.ListCOADMINISTRADOR != null)
                {
                    foreach (var loDatos in oCEntidad.ListCOADMINISTRADOR)
                    {
                        loDatos.COD_UCUENTA = loDatos.COD_UCUENTA == null ? "": loDatos.COD_UCUENTA;
                        loDatos.COD_UCUENTA_CREACION = oCEntidad.COD_UCUENTA_CREACION;                       
                        loDatos.RegEstado = oCEntidad.RegEstado;
                        loDatos.OUTPUTPARAM01 = "";
                        loDatos.OUTPUTPARAM02 = "";
                        loDatos.FECHA_DOCUMENTO = (loDatos.FECHA_DOCUMENTO == null || loDatos.FECHA_DOCUMENTO.ToString() == "") ? (DateTime?)null : Convert.ToDateTime(loDatos.FECHA_DOCUMENTO);
                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "GENE_OSINFOR_ERP_MIGRACION.spMPA_COAdmin_Registrar", loDatos))
                        {
                            cmd.ExecuteNonQuery();
                            OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                            OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;

                        }
                    }

                }
                tr.Commit();
                return OUTPUTPARAM02;
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

        public String RegGrabarDestinatarioRuta(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            String OUTPUTPARAM02 = "";

            try
            {
                tr = cn.BeginTransaction();

                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        loDatos.COD_UCUENTA = oCEntidad.COD_UCUENTA;


                        loDatos.OUTPUTPARAM01 = " ";
                        loDatos.OUTPUTPARAM02 = " ";

                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPrevAlertDelDestinatarioRuta", loDatos))
                        {
                            cmd.ExecuteNonQuery();
                            OUTPUTPARAM01 = Convert.ToString(cmd.Parameters["OUTPUTPARAM01"].Value);
                            OUTPUTPARAM02 = Convert.ToString(cmd.Parameters["OUTPUTPARAM02"].Value);

                        }
                    }

                }

                if (oCEntidad.ListDESTINATARIO_RUTA != null)
                {
                    foreach (var loDatos in oCEntidad.ListDESTINATARIO_RUTA)
                    {
                        loDatos.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        loDatos.RegEstado = oCEntidad.RegEstado;


                        loDatos.OUTPUTPARAM01 = "";
                        loDatos.OUTPUTPARAM02 = "";
                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPrevAlertSaveDestinatarioRuta", loDatos))
                        {
                            cmd.ExecuteNonQuery();
                            OUTPUTPARAM01 =Convert.ToString(cmd.Parameters["OUTPUTPARAM01"].Value);
                            OUTPUTPARAM02 =Convert.ToString(cmd.Parameters["OUTPUTPARAM02"].Value);

                        }
                    }

                }
                tr.Commit();
                return OUTPUTPARAM02 + '|' + OUTPUTPARAM01;
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

        public String RegGrabarRuta(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            String OUTPUTPARAM02 = "";

            try
            {
                tr = cn.BeginTransaction();

                if (oCEntidad.ListRUTA != null)
                {
                    foreach (var loDatos in oCEntidad.ListRUTA)
                    {
                        loDatos.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        loDatos.RegEstado = oCEntidad.RegEstado;
                        loDatos.OUTPUTPARAM01 = "";
                        loDatos.OUTPUTPARAM02 = "";
                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPrevAlertSaveRuta", loDatos))
                        {
                            cmd.ExecuteNonQuery();
                            OUTPUTPARAM01 = Convert.ToString(cmd.Parameters["OUTPUTPARAM01"].Value);
                            OUTPUTPARAM02 = Convert.ToString(cmd.Parameters["OUTPUTPARAM02"].Value);

                        }
                    }

                }
                tr.Commit();
                return OUTPUTPARAM02 + '|' + OUTPUTPARAM01;
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

        public CEntidad RegMostComboRuta(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                               
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.USP_COMBO_LISTAR_SUPERVISION", oCEntidad.BusFormulario,oCEntidad.BusCriterio,null))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalle;
                        CEntidad oCamposDet;
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_UBIDEPARTAMENTO = dr["COD_UBIDEPARTAMENTO"].ToString();
                                oCamposDet.DEPARTAMENTO = dr["DEPARTAMENTO"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListDEPARTAMENTO = lsDetDetalle;

                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String RegGrabarSupuesto(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            String OUTPUTPARAM02 = "";

            try
            {
                tr = cn.BeginTransaction();

                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        loDatos.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        loDatos.OUTPUTPARAM01 = " ";
                        loDatos.OUTPUTPARAM02 = " ";

                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPrevAlertDelSupuesto", loDatos))
                        {
                            cmd.ExecuteNonQuery();
                            OUTPUTPARAM01 = Convert.ToString(cmd.Parameters["OUTPUTPARAM01"].Value);
                            OUTPUTPARAM02 = Convert.ToString(cmd.Parameters["OUTPUTPARAM02"].Value);

                        }
                    }

                }

                if (oCEntidad.ListSUPUESTO != null)
                {
                    foreach (var loDatos in oCEntidad.ListSUPUESTO)
                    {
                        loDatos.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        loDatos.RegEstado = oCEntidad.RegEstado;
                        loDatos.OUTPUTPARAM01 = "";
                        loDatos.OUTPUTPARAM02 = "";

                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPrevAlertSaveSupuesto", loDatos))
                        {
                            cmd.ExecuteNonQuery();
                            OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                            OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                        }
                    }
                }

                tr.Commit();
                return OUTPUTPARAM02 + '|' + OUTPUTPARAM01;
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

        public CEntidad MostrarListaDestinatarioCC(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spMPA_DestinatarioCC_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos.ListDESTINATARIO = new List<CEntidad>();
                        oCampos.ListDESTINATARIOCC = new List<CEntidad>();

                        CEntidad oCamposDet;

                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_DESTINATARIO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            int pt3 = dr.GetOrdinal("CORREO");
                            int pt4 = dr.GetOrdinal("OFICINA");
                            int pt5 = dr.GetOrdinal("ACTIVO");
                            int pt6 = dr.GetOrdinal("DOCUMENTO");
                            int pt7 = dr.GetOrdinal("FECHA_DOCUMENTO");
                            int pt8 = dr.GetOrdinal("CARGO");
                            int pt9 = dr.GetOrdinal("COD_PERSONA");
                            int pt10 = dr.GetOrdinal("OBSERVACION");
                            int pt11 = dr.GetOrdinal("TIPO_FUNCIONARIO");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_DESTINATARIO = dr.GetInt32(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oCamposDet.CORREO = dr.GetString(pt3);
                                oCamposDet.OFICINA = dr.GetString(pt4);
                                oCamposDet.ACTIVO = dr.GetBoolean(pt5) ? 1 : 0;
                                oCamposDet.DOCUMENTO = dr.GetString(pt6);
                                oCamposDet.FECHA_DOCUMENTO = Convert.ToDateTime(dr["FECHA_DOCUMENTO"]).ToShortDateString(); //dr.GetString(pt7).ToString(); DateTime.ParseExact("02/18/2021", "dd/MM/yyyy", provider); //
                                oCamposDet.CARGO = dr.GetString(pt8);
                                oCamposDet.COD_PERSONA = dr.GetString(pt9);
                                oCamposDet.OBSERVACION = dr.GetString(pt10);
                                oCamposDet.TIPO_FUNCIONARIO = dr.GetInt32(pt11);
                                oCampos.ListDESTINATARIO.Add(oCamposDet);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("COD_DESTINATARIO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            int pt3 = dr.GetOrdinal("CORREO");
                            int pt4 = dr.GetOrdinal("OFICINA");
                            int pt5 = dr.GetOrdinal("ACTIVO");
                            int pt6 = dr.GetOrdinal("DOCUMENTO");
                            int pt7 = dr.GetOrdinal("FECHA_DOCUMENTO");
                            int pt8 = dr.GetOrdinal("CARGO");
                            int pt9 = dr.GetOrdinal("COD_PERSONA");
                            int pt10 = dr.GetOrdinal("OBSERVACION");
                            int pt11 = dr.GetOrdinal("TIPO_FUNCIONARIO");
                            int pt12 = dr.GetOrdinal("TIPO_CC");

                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.COD_DESTINATARIO = dr.GetInt32(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                oCamposDet.CORREO = dr.GetString(pt3);
                                oCamposDet.OFICINA = dr.GetString(pt4);
                                oCamposDet.ACTIVO = dr.GetBoolean(pt5) ? 1 : 0;
                                oCamposDet.DOCUMENTO = dr.GetString(pt6);
                                oCamposDet.FECHA_DOCUMENTO = Convert.ToDateTime(dr["FECHA_DOCUMENTO"]).ToShortDateString(); //dr.GetString(pt7).ToString(); DateTime.ParseExact("02/18/2021", "dd/MM/yyyy", provider); //
                                oCamposDet.CARGO = dr.GetString(pt8);
                                oCamposDet.COD_PERSONA = dr.GetString(pt9);
                                oCamposDet.OBSERVACION = dr.GetString(pt10);
                                oCamposDet.TIPO_FUNCIONARIO = dr.GetInt32(pt11);
                                oCamposDet.TIPO_CC = dr.GetInt32(pt12);
                                oCampos.ListDESTINATARIOCC.Add(oCamposDet);
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

        public String RegGrabarDestinatarioCC(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            String OUTPUTPARAM02 = "";

            try
            {
                tr = cn.BeginTransaction();

                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        loDatos.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        loDatos.TIPO_CC = 0;
                        loDatos.FECHA_DOCUMENTO = (loDatos.FECHA_DOCUMENTO == null || loDatos.FECHA_DOCUMENTO.ToString() == "") ? (DateTime?)null : Convert.ToDateTime(loDatos.FECHA_DOCUMENTO);
                        loDatos.OUTPUTPARAM01 = " ";
                        loDatos.OUTPUTPARAM02 = " ";

                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spMPA_DestinatarioCC_Registrar", loDatos))
                        {
                            cmd.ExecuteNonQuery();
                            OUTPUTPARAM01 = Convert.ToString(cmd.Parameters["OUTPUTPARAM01"].Value);
                            OUTPUTPARAM02 = Convert.ToString(cmd.Parameters["OUTPUTPARAM02"].Value);
                        }
                    }

                }

                if (oCEntidad.ListDESTINATARIOCC != null)
                {
                    foreach (var loDatos in oCEntidad.ListDESTINATARIOCC)
                    {
                        loDatos.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        loDatos.TIPO_CC = 1;
                        loDatos.FECHA_DOCUMENTO = (loDatos.FECHA_DOCUMENTO == null || loDatos.FECHA_DOCUMENTO.ToString() == "") ? (DateTime?)null : Convert.ToDateTime(loDatos.FECHA_DOCUMENTO);
                        loDatos.OUTPUTPARAM01 = " ";
                        loDatos.OUTPUTPARAM02 = " ";
                        using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spMPA_DestinatarioCC_Registrar", loDatos))
                        {
                            cmd.ExecuteNonQuery();
                            OUTPUTPARAM01 = Convert.ToString(cmd.Parameters["OUTPUTPARAM01"].Value);
                            OUTPUTPARAM02 = Convert.ToString(cmd.Parameters["OUTPUTPARAM02"].Value);
                        }
                    }
                }
                tr.Commit();
                return OUTPUTPARAM02 + '|' + OUTPUTPARAM01;
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
    }
}
