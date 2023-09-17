using CapaEntidad.DOC;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using CEntidad = CapaEntidad.DOC.Ent_CertificadoPlanta;
using CEspEstablecidas= CapaEntidad.DOC.Ent_EspeciesEstablecidas;
using CEliTabla= CapaEntidad.DOC.Ent_EliTabla;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_CertificadoPlanta
    {
        private SQL oGDataSQL = new SQL();        
        private DBOracle dBOracle = new DBOracle();

        public CEntidad RegMostCombo(OracleConnection cn, CEntidad oCEntidad)

        {
            CEntidad oCampos = null;
            try
            {                
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalle;
                        CEntidad oCamposDet;
                        //
                        //Modalidad
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //PARTE_DIARIO_DETALLE
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
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

        public String RegGrabarV3(OracleConnection cn, CEntidad oCEntidad, OracleTransaction tr)
        {

            String OUTPUTPARAM01 = "";

            List<CEntidad> listaFiltro = new List<CEntidad>();
            CEspEstablecidas oCampoEE = new CEspEstablecidas();
            CEliTabla oCampoEli = new CEliTabla();
            try
            {
                // tr = cn.BeginTransaction();
                string sp_Sigo = "doc_osinfor_erp_migracion.spCERTIFICADOPLANTAGrabar";
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, sp_Sigo, oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    //OUTPUTPARAM02 = (String)cmd.Parameters["@OUTPUTPARAM02"].Value;
                    if (OUTPUTPARAM01 == "99")
                    {
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                    if (OUTPUTPARAM01 == "0")
                    {
                        throw new Exception("El Número del Incripción ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        throw new Exception("El Número del Incripción Existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        throw new Exception("No Tiene Permisos para Modificar este CERTIFICACION PLANTA");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_CERTIFPLANTA = OUTPUTPARAM01;
                }
                #region ListEliTABLA
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCampoEli = new CEliTabla();
                        oCampoEli.COD_CERTIFPLANTA = OUTPUTPARAM01;
                        oCampoEli.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        oCampoEli.RegEstado = 0;                        
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.CERTIFPLANTA_ESPECIES_ESTABLECIDAS_eliminar", oCampoEli);
                    }
                }
                #endregion
                #region ListEspeciesEstablecidas                
                if (oCEntidad.ListEspeciesEstablecidas != null)
                {                    
                    foreach (var loDatos in oCEntidad.ListEspeciesEstablecidas)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {   
                            oCampoEE = new CEspEstablecidas();
                            oCampoEE.COD_CERTIFPLANTA = OUTPUTPARAM01;
                            oCampoEE.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCampoEE.DESC_ESPECIES = loDatos.DESC_ESPECIES;
                            oCampoEE.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCampoEE.SIS_PLANTA = loDatos.SIS_PLANTA;
                            oCampoEE.UNI_MEDIDA = loDatos.UNI_MEDIDA;
                            oCampoEE.CANTIDAD = loDatos.CANTIDAD;
                            oCampoEE.FINES = loDatos.FINES;
                            oCampoEE.OBSERVACION = loDatos.OBSERVACION;
                            oCampoEE.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            oCampoEE.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.CERTIFPLANTA_ESPECIES_ESTABLECIDAS_grabar", oCampoEE);
                        }
                    }
                }
                #endregion

                return OUTPUTPARAM01;// + '|' + OUTPUTPARAM02;
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
                CEspEstablecidas objEspEstablecidas;

                oCampos.COD_CERTIFPLANTA = oCEntidad.COD_CERTIFPLANTA;
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.spCERTIFPLANTAMostItems", oCampos))
                {
                    if (dr != null)
                    {
                        //CEntidad oCamposDet;
                        #region Datos
                        if (dr.HasRows)
                        {
                            dr.Read();
                            oCampos.COD_CERTIFPLANTA = dr.GetString(dr.GetOrdinal("COD_CERTIFPLANTA"));
                            oCampos.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                            oCampos.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                            oCampos.MODALIDAD = dr.GetString(dr.GetOrdinal("MODALIDAD"));                            
                            oCampos.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                            oCampos.UBIGEO = dr.GetString(dr.GetOrdinal("UBIGEO"));
                            oCampos.NUMERO_INSCRIPCION = dr.GetString(dr.GetOrdinal("NUMERO_INSCRIPCION"));
                            oCampos.FECHA_INSCRIPCION = dr.GetString(dr.GetOrdinal("FECHA_INSCRIPCION"));
                            oCampos.AREATOTAL = dr.GetDecimal(dr.GetOrdinal("AREATOTAL"));
                            oCampos.FECHA_ESTABLECIMIENTO = dr.GetString(dr.GetOrdinal("FECHA_ESTABLECIMIENTO"));
                            oCampos.OBSERVACIONES = dr.GetString(dr.GetOrdinal("OBSERVACIONES"));
                            oCampos.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            oCampos.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            oCampos.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));

                        }
                        #endregion
                        #region ListEspeciesEstablecidas
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                objEspEstablecidas = new CEspEstablecidas();
                                objEspEstablecidas.COD_CERTIFPLANTA = dr["COD_CERTIFPLANTA"].ToString();
                                objEspEstablecidas.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                objEspEstablecidas.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                objEspEstablecidas.DESC_ESPECIES = dr["DESC_ESPECIES"].ToString();
                                objEspEstablecidas.SIS_PLANTA = dr["SIS_PLANTA"].ToString();
                                objEspEstablecidas.UNI_MEDIDA = dr["UNI_MEDIDA"].ToString();
                                objEspEstablecidas.CANTIDAD = Decimal.Parse(dr["CANTIDAD"].ToString());
                                objEspEstablecidas.FINES = dr["FINES"].ToString();
                                objEspEstablecidas.OBSERVACION = dr["OBSERVACION"].ToString();
                                objEspEstablecidas.RegEstado = 0;
                                oCampos.ListEspeciesEstablecidas.Add(objEspEstablecidas);
                            }
                        }
                        #endregion
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
