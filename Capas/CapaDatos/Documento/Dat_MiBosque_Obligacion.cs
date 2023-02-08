using CapaEntidad.ViewModel;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using CEntidad = CapaEntidad.DOC.Ent_MiBosque_Obligacion;

namespace CapaDatos.DOC
{
    public class Dat_MiBosque_Obligacion
    {
        private DBOracle dBOracle = new DBOracle();

        public List<CEntidad> RegMostrarLista(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lstObligaciones = new List<CEntidad>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.MIBOSQUE_BUSCAR_OBLIGACION", oCEntidad))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            CEntidad obligacion = new CEntidad();
                            obligacion.COD_MIBOSQUE_OBLIGACION = dr.GetInt64(dr.GetOrdinal("COD_MIBOSQUE_OBLIGACION"));
                            obligacion.COD_OBLIGACION = dr.GetInt64(dr.GetOrdinal("COD_OBLIGACION"));
                            obligacion.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                            obligacion.COD_PMANEJO = dr.GetString(dr.GetOrdinal("COD_PMANEJO"));
                            obligacion.DESC_TIPO = dr.GetString(dr.GetOrdinal("DESC_TIPO"));
                            obligacion.FECHA_PRESENTACION = dr.GetValue(dr.GetOrdinal("FECHA_PRESENTACION"));
                            obligacion.ESTADO = dr.GetString(dr.GetOrdinal("ESTADO"));
                            obligacion.DESC_DETALLE = dr.GetString(dr.GetOrdinal("DESC_DETALLE"));

                            lstObligaciones.Add(obligacion);
                        }
                    }
                }

                return lstObligaciones;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public Object RegActualizar(OracleConnection cn, VM_MiBosqueObligacion vm_MiBosqueObligacion, OracleTransaction tr)
        {
            Object output;

            try
            {
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.MIBOSQUE_ACTUALIZAR_OBLIGACION", vm_MiBosqueObligacion))
                {
                    cmd.ExecuteNonQuery();
                    output = cmd.Parameters["OUTPUTPARAM"].Value;
                    tr.Commit();
                }    

                return output;
            } catch (Exception ex)
            {
                if (tr != null)
                {
                    tr.Rollback();
                    tr.Dispose();
                }

                throw ex;
            }
        }
    }
}
