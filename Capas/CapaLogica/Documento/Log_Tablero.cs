using Oracle.ManagedDataAccess.Client;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using CDatos = CapaDatos.DOC.Dat_Tablero;
using CEntidadP = CapaEntidad.DOC.Ent_Tablero_Parametros;
using CEntidadR = CapaEntidad.DOC.Ent_Tablero_Resultados;

namespace CapaLogica.DOC
{
    public class Log_Tablero
    {
        private CDatos oCDatos = new CDatos();

        public CEntidadR RegMostIndDFFFS(CEntidadP oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostIndDFFFS(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
