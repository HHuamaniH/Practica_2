using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

//using Oracle.ManagedDataAccess.Client;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using CDatos = CapaDatos.GENE.Dat_UBIGEO;
using CEntidad = CapaEntidad.GENE.Ent_UBIGEO;
namespace CapaLogica.GENE
{
    public class Log_UBIGEO
    {
        private CDatos oCDatos = new CDatos();
        public CEntidad RegMostrarUbigeo(string sCriterio)
        {
            CEntidad oCampos = new CEntidad();
            oCampos.BusFormulario = "UBIGEO";
            oCampos.BusCriterio = sCriterio;

            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarUbigeo(cn, oCampos);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string RegMostrarUbigeoV3()
        {
            CEntidad oCampos = new CEntidad();
            oCampos.BusFormulario = "UBIGEO";
            oCampos.BusCriterio = "TODOS";
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarUbigeoV3(cn, oCampos);
                } 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<CEntidad> FilUbigeoProvincia(CEntidad Ubigeo, String Cod_Departamento)
        {
            List<CEntidad> ListUbigeo = new List<CEntidad>(Ubigeo.ListProvincia);
            return (from p in ListUbigeo where p.COD_UBIDEPARTAMENTO == Cod_Departamento select p).ToList<CEntidad>();
        }
        public List<CEntidad> FilUbigeoDistrito(CEntidad Ubigeo, String Cod_Departamento, String Cod_Provincia)
        {
            List<CEntidad> ListUbigeo = new List<CEntidad>(Ubigeo.ListDistrito);
            return (from p in ListUbigeo where p.COD_UBIDEPARTAMENTO == Cod_Departamento && p.COD_UBIPROVINCIA == Cod_Provincia select p).ToList<CEntidad>();
        }
    }
}
