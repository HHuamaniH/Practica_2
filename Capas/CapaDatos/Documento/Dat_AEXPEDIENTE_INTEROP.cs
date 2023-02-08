using System;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_AEXPEDIENTE_INTEROP;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_AEXPEDIENTE_INTEROP
    {
        private SQL oGDataSQL = new SQL();

        public CEntidad VerificarEstadoAExpedienteInterop(SqlConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampo = new CEntidad();

            try
            {
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spVerificarEstadoAExpedienteInterop", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            if (dr.Read())
                            {
                                oCampo.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                                oCampo.COD_AEXPEDIENTE_INTEROP = dr.GetString(dr.GetOrdinal("COD_AEXPEDIENTE_INTEROP"));
                                oCampo.ESTADO_AEXPEDIENTE = dr.GetString(dr.GetOrdinal("ESTADO_AEXPEDIENTE"));
                                oCampo.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                oCampo.OBSERVACION_TRANSFERIR = dr.GetString(dr.GetOrdinal("OBSERVACION_TRANSFERIR"));
                            }
                        }
                    }
                }

                return oCampo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String RegGrabar(SqlConnection cn, CEntidad oCEntidad)
        {
            SqlTransaction tr = null;
            String OUTPUTPARAM01 = "";
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spAEXPEDIENTE_INTEROPGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
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

        public String RegGrabarV3(SqlConnection cn, CEntidad oCEntidad, SqlTransaction tr)
        {
            String OUTPUTPARAM01 = "";
            try
            {
                //Grabando Cabecera
                using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.spAEXPEDIENTE_INTEROPGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "99")
                    {
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }

                }

                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
