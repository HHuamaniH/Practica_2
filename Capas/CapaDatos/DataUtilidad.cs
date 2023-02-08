using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public static class DataUtilidad
    {
        /// <summary>
        /// Obtiene el valor string del datareader
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetValueString(this OracleDataReader dr, string name)
        {
            
            int indexColumn = dr.GetOrdinal(name);
            return GetValueString(dr, indexColumn);
        }
        public static Int32 GetValueInt32(this OracleDataReader dr, string name)
        {

            int indexColumn = dr.GetOrdinal(name);
            return GetValueInt32(dr, indexColumn);
        }
        public static Boolean GetValueBoolean(this OracleDataReader dr, string name)
        {

            int indexColumn = dr.GetOrdinal(name);
            return GetValueBoolean(dr, indexColumn);
        }
        public static Boolean GetValueBoolean(this OracleDataReader dr, int indexColumn)
        {
            Boolean valor = false;
            if (indexColumn >= 0)
            {
                var isNull = dr.IsDBNull(indexColumn);
                if (isNull) return false;
                else
                {
                    valor = dr.GetBoolean(indexColumn);
                }
            }
            else
            {
                throw new Exception("Columna no existe");
            }
            return valor;
        }
        /// <summary>
        /// Obtiene el valor string del datareader
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="indexColumn"></param>
        /// <returns></returns>
        public static string GetValueString(this OracleDataReader dr, int  indexColumn)
        {
            string valor = String.Empty;
            if (indexColumn >= 0)
            {
                var isNull = dr.IsDBNull(indexColumn);
                if (isNull) return String.Empty;
                else
                {
                    valor = dr[indexColumn].ToString();
                }
            }
            else
            {
                throw new Exception("Columna no existe");
            }
            return valor;
        }
        public static  Int32 GetValueInt32(this OracleDataReader dr, int indexColumn)
        {
            Int32 valor = 0;
            if (indexColumn >= 0)
            {
                var isNull = dr.IsDBNull(indexColumn);
                if (isNull) return 0;
                else
                {
                    valor = Int32.Parse(dr[indexColumn].ToString());
                }
            }
            else
            {
                throw new Exception("Columna no existe");
            }
            return valor;
        }
    }
}
