using CapaEntidad.GENE;
using System;
using System.Data.SqlClient;
using SQL = GeneralSQL.Data.SQL;
namespace CapaDatos.GENE
{
    public class Dat_LOG_CARGA_ARCHIVOS
    {
        private SQL oGDataSQL = new SQL();
        public void regTranLog(Ent_LOG_CARGA_ARCHIVOS CENT)
        {
            using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
            {
                SqlTransaction tr = null;
                try
                {

                    cn.Open();
                    tr = cn.BeginTransaction();
                    //Grabando Cabecera
                    using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.usp_LogErroresGrabarV3", CENT))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    //
                    tr.Commit();
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
}
