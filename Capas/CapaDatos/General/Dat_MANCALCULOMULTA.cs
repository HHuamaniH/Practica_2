using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using CapaEntidad.ViewModel;
using System.Collections.Generic;
using CEntidad = CapaEntidad.GENE.Ent_MANCALCULOMULTA;
using CEntCalculoMulta = CapaEntidad.GENE.Ent_CALCULOMULTA;
using SQL = GeneralSQL.Data.SQL;
using CapaEntidad.GENE;

namespace CapaDatos.GENE
{
    public class Dat_MANCALCULOMULTA
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();

        public Int32 RegGrabarFactorAA(OracleConnection cn, CEntidad oCEntidad)
        {
            try
            {
                Int32 RegNum = dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spHER_FACTORAA_Registrar", oCEntidad);
                /* if (RegNum == -1)
                 {
                     throw new Exception("No se logró realizar la operación");
                 }*/
                return RegNum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 RegGrabarRegenEsp(OracleConnection cn, CEntidad oCEntidad)
        {
            try
            {
                Int32 RegNum = dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPHER_REGENESP_REGISTRAR", oCEntidad);
                /* if (RegNum == -1)
                 {
                     throw new Exception("No se logró realizar la operación");
                 }*/
                return RegNum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 RegGrabarCostoAdm(OracleConnection cn, CEntidad oCEntidad)
        {
            try
            {
                Int32 RegNum = dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPHER_COSTOADM_REGISTRAR", oCEntidad);
                /* if (RegNum == -1)
                 {
                     throw new Exception("No se logró realizar la operación");
                 }*/
                return RegNum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int32 RegGrabarBenEcoInf(OracleConnection cn, CEntidad oCEntidad)
        {
            try
            {
                Int32 RegNum = dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPHER_BENECOINF_REGISTRAR", oCEntidad);
                /* if (RegNum == -1)
                 {
                     throw new Exception("No se logró realizar la operación");
                 }*/
                return RegNum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int32 RegGrabarIndPreCon(OracleConnection cn, CEntidad oCEntidad)
        {
            try
            {
                Int32 RegNum = dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPHER_INDPRECON_REGISTRAR", oCEntidad);
                /* if (RegNum == -1)
                 {
                     throw new Exception("No se logró realizar la operación");
                 }*/
                return RegNum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int32 RegGrabarInfProDet(OracleConnection cn, CEntidad oCEntidad)
        {
            try
            {
                Int32 RegNum = dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPHER_INFPRODET_REGISTRAR", oCEntidad);
                /* if (RegNum == -1)
                 {
                     throw new Exception("No se logró realizar la operación");
                 }*/
                return RegNum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int32 RegGrabarVENMaderable(OracleConnection cn, CEntidad oCEntidad)
        {
            try
            {
                Int32 RegNum = dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPHER_VENMADERA_REGISTRAR", oCEntidad);
                /* if (RegNum == -1)
                 {
                     throw new Exception("No se logró realizar la operación");
                 }*/
                return RegNum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String RegGrabarCatEspMad(OracleConnection cn, CEntidad oCEntidad)
        {

            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            try
            {
                tr = cn.BeginTransaction();

                //using (OracleConnection cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPHER_CATESPMAD_REGISTRAR", oCEntidad))
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPHER_CATESPMAD_REGISTRAR", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
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
        public String RegGrabarValComFau(OracleConnection cn, CEntidad oCEntidad)
        {

            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            try
            {
                tr = cn.BeginTransaction();

                //using (OracleConnection cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPHER_CATESPMAD_REGISTRAR", oCEntidad))
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPHER_VALCOMFAU_REGISTRAR", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
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
        public String RegGrabarClaEspAme(OracleConnection cn, CEntidad oCEntidad)
        {

            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            try
            {
                tr = cn.BeginTransaction();

                //using (OracleConnection cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPHER_CATESPMAD_REGISTRAR", oCEntidad))
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPHER_CLAESPAME_REGISTRAR", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
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

        public List<VM_Cbo> RegMostComboIndividual_v3(OracleConnection cn, CEntidad oCEntidad)
        {
            List<VM_Cbo> lstCampos = new List<VM_Cbo>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.CALMUL_COMBO_LISTAR", oCEntidad))
                {
                    if (dr != null)
                    {
                        VM_Cbo oCampos;

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new VM_Cbo();
                                oCampos.Value = dr["CODIGO"].ToString();
                                oCampos.Text = dr["DESCRIPCION"].ToString();
                                lstCampos.Add(oCampos);
                            }
                        }
                    }
                }
                return lstCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String RegInsertar(OracleConnection cn, CEntCalculoMulta oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            String OUTPUTPARAM02 = "";
            string CodCalculoMulta = "";
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "doc_osinfor_erp_migracion.SPHER_CALCULOMULTA_REGISTRAR", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
                    if (OUTPUTPARAM02 != " ")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ocurrió un error al registrar el cálculo de multa.");
                    }
                    if (oCEntidad.CodCalculoMulta != "0")
                    {
                        CodCalculoMulta = oCEntidad.CodCalculoMulta;
                        CEntCalculoMulta eliminarCalculo = new CEntCalculoMulta();
                        eliminarCalculo.CodCalculoMulta = oCEntidad.CodCalculoMulta;
                        dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.SPHER_DETESPCALCULOMULTA_DELETE", eliminarCalculo);
                    }                    
                    #region DetalleCalculoMulta
                    if (oCEntidad.DetalleCalculoMulta != null)
                    {
                        foreach (var loDetalle in oCEntidad.DetalleCalculoMulta)
                        {
                            loDetalle.CodCalculoMulta = OUTPUTPARAM01;
                            loDetalle.RegEstado = 1;
                            loDetalle.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.SPHER_DETALLECALCULOMULTA_REGISTRAR", loDetalle);
                            foreach (var especie in loDetalle.especies)
                            {
                                especie.CodCalculoMulta = OUTPUTPARAM01;
                                especie.RegEstado = 1;
                                especie.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                                dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.SPHER_ESPECIECM_REGISTRAR", especie);
                            }

                        }
                    }
                    tr.Commit();
                    #endregion
                }
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

        public CEntCalculoMulta GetCalculoMulta(OracleConnection cn, string codCalculoMulta)
        {
            CEntCalculoMulta ocampoEnt = new CEntCalculoMulta();
            Ent_DETALLECALCULOMULTA ocampodetalleEnt;
            Ent_ESPECIECM ocampodetalleespecieEnt;

            ocampoEnt.CodCalculoMulta= codCalculoMulta;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spHER_CalculoMulta_Obtn", ocampoEnt))
                {
                    if (dr != null)
                    {                       
                        ocampoEnt.DetalleCalculoMulta = new List<Ent_DETALLECALCULOMULTA>();

                        if (dr.HasRows)
                        {
                            dr.Read();
                            ocampoEnt.CodCalculoMulta = dr.GetValueString("CODCALCULOMULTA");
                            ocampoEnt.Expediente = dr.GetValueString("EXPEDIENTE");
                            ocampoEnt.Administrado = dr.GetValueString("ADMINISTRADO");
                            ocampoEnt.NroDocumento = dr.GetValueString("NRODOCUMENTO");
                            ocampoEnt.TituloHabilitante = dr.GetValueString("TITULOHABILITANTE");
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampodetalleEnt = new Ent_DETALLECALCULOMULTA();
                                ocampodetalleEnt.literal = dr.GetValueString("LITERAL");
                                ocampodetalleEnt.SumatoriaK = decimal.Parse(dr.GetValueString("SUMATORIAK"));
                                ocampodetalleEnt.SumatoriaB = decimal.Parse(dr.GetValueString("SUMATORIAB"));
                                ocampodetalleEnt.SumatoriaCE = decimal.Parse(dr.GetValueString("SUMATORIACE"));
                                ocampodetalleEnt.SumatoriaPD = decimal.Parse(dr.GetValueString("SUMATORIAPD"));
                                ocampodetalleEnt.SumatoriaVEN = decimal.Parse(dr.GetValueString("SUMATORIAVEN"));
                                ocampodetalleEnt.SumatoriaF = decimal.Parse(dr.GetValueString("SUMATORIAF"));
                                ocampodetalleEnt.SubTotal = decimal.Parse(dr.GetValueString("SUBTOTAL"));
                                ocampodetalleEnt.Total = decimal.Parse(dr.GetValueString("TOTAL"));
                                
                                ocampoEnt.DetalleCalculoMulta.Add(ocampodetalleEnt);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampodetalleespecieEnt = new Ent_ESPECIECM();
                                ocampodetalleespecieEnt.literal = dr.GetValueString("LITERAL");
                                ocampodetalleespecieEnt.cod_especie = dr.GetValueString("COD_ESPECIE");
                                ocampodetalleespecieEnt.especie = dr.GetValueString("ESPECIE");
                                ocampodetalleespecieEnt.margen = decimal.Parse(dr.GetValueString("MARGEN"));
                                ocampodetalleespecieEnt.volumen = decimal.Parse(dr.GetValueString("VOLUMEN"));
                                ocampodetalleespecieEnt.ipc = decimal.Parse(dr.GetValueString("IPC"));
                                ocampodetalleespecieEnt.fechaipc = decimal.Parse(dr.GetValueString("FECHAIPC"));
                                ocampodetalleespecieEnt.beneficio = decimal.Parse(dr.GetValueString("BENEFICIO"));
                                ocampodetalleespecieEnt.ven = decimal.Parse(dr.GetValueString("VEN"));
                                ocampodetalleespecieEnt.gravedad = decimal.Parse(dr.GetValueString("GRAVEDAD"));
                                ocampodetalleespecieEnt.afectacion = decimal.Parse(dr.GetValueString("AFECTACION"));
                                ocampodetalleespecieEnt.regeneracion = decimal.Parse(dr.GetValueString("REGENERACION"));
                                ocampodetalleespecieEnt.vengar = decimal.Parse(dr.GetValueString("VENGAR"));
                                for (int i = 0; i < ocampoEnt.DetalleCalculoMulta.Count; i++)
                                {
                                    if (ocampoEnt.DetalleCalculoMulta[i].literal == ocampodetalleespecieEnt.literal)
                                    {
                                        if (ocampoEnt.DetalleCalculoMulta[i].especies is null) ocampoEnt.DetalleCalculoMulta[i].especies = new List<Ent_ESPECIECM>();
                                        
                                        ocampoEnt.DetalleCalculoMulta[i].especies.Add(ocampodetalleespecieEnt);
                                    }
                                }
                            }                                
                        }   
                    }
                }
                return ocampoEnt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
