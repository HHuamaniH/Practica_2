using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using CapaEntidad.ViewModel;
using System.Linq;
using CDatos = CapaDatos.GENE.Dat_MANCALCULOMULTA;
using CEntidad = CapaEntidad.GENE.Ent_MANCALCULOMULTA;
using CCMEntidad = CapaEntidad.GENE.Ent_CALCULOMULTA;
using System.Data.SqlClient;

namespace CapaLogica.GENE
{
    public class Log_MANCALCULOMULTA
    {
        private CDatos oCDatos = new CDatos();

        public Int32 RegGrabarFactorAA(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarFactorAA(cn, oCEntidad);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int32 RegGrabarRegenEsp(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarRegenEsp(cn, oCEntidad);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int32 RegGrabarCostoAdm(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarCostoAdm(cn, oCEntidad);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int32 RegGrabarBenEcoInf(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarBenEcoInf(cn, oCEntidad);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int32 RegGrabarIndPreCon(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarIndPreCon(cn, oCEntidad);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int32 RegGrabarInfProDet(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarInfProDet(cn, oCEntidad);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Int32 RegGrabarVENMaderable(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarVENMaderable(cn, oCEntidad);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String RegGrabarCatEspMad(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarCatEspMad(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String RegGrabarValComFau(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarValComFau(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String RegGrabarClaEspAme(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarClaEspAme(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<VM_Cbo> RegMostComboIndividual_v3(string asBusCriterio, string asBusValor)
        {
            List<VM_Cbo> lstResult = new List<VM_Cbo>();

            try
            {
                CEntidad entBus = new CEntidad();                
                entBus.BusFormulario = "COMBO_INDIVIDUAL";
                entBus.BusCriterio = asBusCriterio;
                entBus.BusValor = asBusValor;
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    lstResult = oCDatos.RegMostComboIndividual_v3(cn, entBus).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstResult;
        }

        public String RegGrabarCalculoMulta(CCMEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegInsertar(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CapaEntidad.GENE.Ent_CALCULOMULTA GetCalculoMulta(string codCalculoMulta)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.GetCalculoMulta(cn, codCalculoMulta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
