using CapaEntidad.ViewModel;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using CDatos = CapaDatos.DOC.Dat_MiBosque_Obligacion;
using CEntidad = CapaEntidad.DOC.Ent_MiBosque_Obligacion;

namespace CapaLogica.DOC
{
    public class Log_MiBosque_Obligacion
    {
        private CDatos oCDatos = new CDatos();
        private DBOracle dBOracle = new DBOracle();

        public List<CEntidad> RegMostrarLista(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarLista(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Object RegActualizar(VM_MiBosqueObligacion vm_MiBosqueObligacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    OracleTransaction tr = cn.BeginTransaction();
                    return oCDatos.RegActualizar(cn, vm_MiBosqueObligacion, tr);
                }
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        } 

    }
}
