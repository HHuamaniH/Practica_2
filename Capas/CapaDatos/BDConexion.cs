using System;
using System.Configuration;
namespace CapaDatos
{
    public class BDConexion
    {
        public static string Conexion_Cadena_SIGO()
        {
            String strCnx = ConfigurationManager.ConnectionStrings["ConOracle"].ConnectionString;
            //String strCnx = ConfigurationManager.ConnectionStrings["ConexionSql"].ConnectionString;
            return strCnx;
        }
        public static string Conexion_Cadena_OBSERVATORIO()
        {
            String strCnx = ConfigurationManager.ConnectionStrings["ConexionObservatorio"].ConnectionString;
            return strCnx;
        }
        //public static string Conexion_Cadena()
        //{
        //    String strCnx = ConfigurationManager.ConnectionStrings["ConexionSql"].ConnectionString;
        //    return strCnx;
        //}
        public static string Conexion_Cadena_SITD()
        {
            String strCnx = ConfigurationManager.ConnectionStrings["ConexionSITDSql"].ConnectionString;
            return strCnx;
        }
        public static string Conexion_Cadena_SIADO()
        {
            String strCnx = ConfigurationManager.ConnectionStrings["ConexionSIADOSql"].ConnectionString;
            return strCnx;
        }
        public static string Conexion_Cadena_SISFOR()
        {
            String strCnx = ConfigurationManager.ConnectionStrings["ConexionSISFORPGSql"].ConnectionString;
            return strCnx;
        }
        public static string Conexion_Cadena_SITDAL()
        {
            String strCnx = ConfigurationManager.ConnectionStrings["ConexionSITDSqlALegal"].ConnectionString;
            return strCnx;
        }
        public static string Conexion_Cadena_SITDT()
        {
            String strCnx = ConfigurationManager.ConnectionStrings["ConexionSITDSqlTesoreria"].ConnectionString;
            return strCnx;
        }
    }
}
