using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSQL
{
    public class DBOracle
    {
        public OracleDataReader SelDrdDefault(OracleConnection con, OracleTransaction trx, String SProcedure, Object objCEntidad)
        {
            using (OracleCommand cmd = new OracleCommand(SProcedure, con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 2000;
                    cmd.Transaction = trx;
                    if (objCEntidad != null)
                    {
                        CrearParametros(cmd, objCEntidad);
                    }
                    OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
                    return dr;
                    //En esta clase no se debe usar Using ya que necesitamos que el SqlDataReader este abierto para el
                    //Receptor que viene hacer la clase que lo invoca
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public OracleDataReader SelDrdDefaultPart(OracleConnection con, OracleTransaction trx, String SProcedure, String CodCapacitacion)
        {
            using (OracleCommand cmd = new OracleCommand(SProcedure, con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 2000;
                    cmd.Transaction = trx;
                    //cmd.Parameters.AddWithValue("COD_CAPACITACION", CodCapacitacion);
                    cmd.Parameters.Add("COD_CAPACITACION", CodCapacitacion);


                    OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
                    return dr;
                    //En esta clase no se debe usar Using ya que necesitamos que el SqlDataReader este abierto para el
                    //Receptor que viene hacer la clase que lo invoca
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public OracleDataReader SelDrdRow(OracleConnection con, OracleTransaction trx, String SProcedure, Object objCEntidad)
        {
            using (OracleCommand cmd = new OracleCommand(SProcedure, con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 2000;
                    cmd.Transaction = trx;
                    if (objCEntidad != null)
                    {
                        CrearParametros(cmd, objCEntidad);
                    }
                    OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    return dr;
                    //En esta clase no se debe usar Using ya que necesitamos que el SqlDataReader este abierto para el
                    //Receptor que viene hacer la clase que lo invoca
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public OracleDataReader SelDrdDefault(OracleConnection con, String SProcedure, params object[] paramsValue)
        {
            using (OracleCommand cmd = new OracleCommand(SProcedure, con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 2000;
                    if (paramsValue != null)
                    {
                        CrearParametros(cmd, paramsValue);
                    }
                    OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
                    return dr;
                    //En esta clase no se debe usar Using ya que necesitamos que el SqlDataReader este abierto para el
                    //Receptor que viene hacer la clase que lo invoca
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public OracleDataReader SelDrdDefaultTR(OracleConnection con, OracleTransaction trx,String SProcedure, params object[] paramsValue)
        {
            using (OracleCommand cmd = new OracleCommand(SProcedure, con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 2000;
                    cmd.Transaction = trx;
                    if (paramsValue != null)
                    {
                        CrearParametros(cmd, paramsValue);
                    }
                    OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
                    return dr;
                    //En esta clase no se debe usar Using ya que necesitamos que el SqlDataReader este abierto para el
                    //Receptor que viene hacer la clase que lo invoca
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public OracleDataReader SelDrdResult(OracleConnection con, OracleTransaction trx, String SProcedure, Object objCEntidad)
        {
            using (OracleCommand cmd = new OracleCommand(SProcedure, con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 2000;
                    cmd.Transaction = trx;
                    if (objCEntidad != null)
                    {
                        CrearParametros(cmd, objCEntidad);
                    }
                    OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    return dr;
                    //En esta clase no se debe usar Using ya que necesitamos que el SqlDataReader este abierto para el
                    //Receptor que viene hacer la clase que lo invoca
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public Object SelScalarVal(OracleConnection con, OracleTransaction trx, String SProcedure, Object objCEntidad)
        {
            using (OracleCommand cmd = new OracleCommand(SProcedure, con))
            {
                try
                {
                    Object Val;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 2000;
                    cmd.Transaction = trx;
                    if (objCEntidad != null)
                    {
                        CrearParametros(cmd, objCEntidad);
                    }
                    Val = cmd.ExecuteScalar();
                    return (Val);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public Int32 ManExecute(OracleConnection con, OracleTransaction trx, String SProcedure, Object objCEntidad)
        {
            using (OracleCommand cmd = new OracleCommand(SProcedure, con))
            {
                Int32 NumReg;
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 1000;
                    cmd.Transaction = trx;
                    CrearParametros(cmd, objCEntidad);
                    NumReg = cmd.ExecuteNonQuery();
                    if (NumReg <= 0)
                    {
                        return (-1);
                        //throw new Exception("No se logró realizar la operación");
                    }

                    return NumReg;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public Int32 ManExecute(OracleConnection con, OracleTransaction trx, String SProcedure, params object[] parametros)
        {
            using (OracleCommand cmd = new OracleCommand(SProcedure, con))
            {
                Int32 NumReg;
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = trx;
                    CrearParametros(cmd, parametros);
                    NumReg = cmd.ExecuteNonQuery();
                    if (NumReg <= 0)
                    {
                        return (-1);
                        //throw new Exception("No se logró realizar la operación");
                    }
                    return NumReg;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        /// <summary>
        /// Para agregar los parametros uno por uno
        /// </summary>
        /// <param name="con"></param>
        /// <param name="trx"></param>
        /// <param name="SProcedure"></param>
        /// <returns></returns>
        public OracleCommand ManExecuteOutputV1(OracleConnection con, OracleTransaction trx, String SProcedure)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1000;
                cmd.CommandText = SProcedure;
                cmd.Transaction = trx;
                //CrearParametros(cmd, objCEntidad);
                return cmd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public OracleCommand ManExecuteOutputOracle(OracleConnection con, OracleTransaction trx, String SProcedure, Object objCEntidad)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 1000;
                cmd.CommandText = SProcedure;
                cmd.Transaction = trx;
                CrearParametros(cmd, objCEntidad);
                return cmd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public OracleCommand ManExecuteOutput(OracleConnection con, OracleTransaction trx, String SProcedure, Object objCEntidad)
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 10;
                cmd.CommandText = SProcedure;
                cmd.Transaction = trx;
                CrearParametros(cmd, objCEntidad);
                return cmd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CrearParametros(OracleCommand cmd, params object[] parametros)
        {
            OracleCommandBuilder.DeriveParameters(cmd);
            int _ind = 0;
            foreach(OracleParameter p in cmd.Parameters)
            {
                if (p.OracleDbType == OracleDbType.RefCursor)
                {
                    p.Direction = ParameterDirection.Output;
                }
                else
                {
                    p.Value = parametros[_ind];
                    _ind++;
                }
            }
        }

        public void CrearParametrosOutput(OracleCommand cmd, params object[] parametros)
        {
            OracleCommandBuilder.DeriveParameters(cmd);
            for (int i = 0; i < parametros.Length; i++)
            {
                cmd.Parameters[i + 1].Direction = ParameterDirection.Output;
                cmd.Parameters[i + 1].Value = parametros[i];

            }
        }
        private void CrearParametros(OracleCommand cmd, Object objCEntidad)
        {
            OracleCommandBuilder.DeriveParameters(cmd);
            PropertyInfo[] Propiedad = objCEntidad.GetType().GetProperties();
            Object Valor = null;
            Boolean AccesoValido = false;
            String AttributesDescri = "";
            String AttributesCatego = "";
            for (Int32 vFor = 0; vFor < Propiedad.Length; vFor++)
            {
                Valor = Propiedad[vFor].GetValue(objCEntidad, null);
                AccesoValido = false;
                if (Valor != null)
                {
                    if (Valor.GetType().ToString().IndexOf("System.Collections.Generic.List") == -1)
                    {
                        switch (Valor.GetType().ToString())
                        {

                            case "System.Numeric":
                                AccesoValido = (Decimal)Valor != -1;
                                break;
                            case "System.Int16":
                                AccesoValido = (Int16)Valor != -1;
                                break;
                            case "System.Int32":
                                AccesoValido = (Int32)Valor != -1;
                                break;
                            case "System.Int64":
                                AccesoValido = (Int64)Valor != -1;
                                break;
                            case "System.Decimal":
                                AccesoValido = (Decimal)Valor != -1;
                                break;
                            case "System.Double":
                                AccesoValido = (Double)Valor != -1;
                                break;
                            default:
                                AccesoValido = true;
                                break;
                        }
                    }
                }
                if (AccesoValido == true)
                {
                    AttributesCatego = "";
                    AttributesDescri = "";
                    //
                    //Obteniendo Atributos
                    //DescriptionAttribute da = (DescriptionAttribute)(Propiedad[vFor].GetCustomAttributes(false)[0]);
                    DescriptionAttribute[] da = (DescriptionAttribute[])Propiedad[vFor].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (da.Length > 0)
                    {
                        AttributesDescri = da[0].Description.ToString();
                    }
                    CategoryAttribute[] ca = (CategoryAttribute[])Propiedad[vFor].GetCustomAttributes(typeof(CategoryAttribute), false);
                    if (ca.Length > 0)
                    {
                        AttributesCatego = ca[0].Category.ToString().ToUpper();
                    }
                    //
                    //Asignando Parametros Store Procedure
                    if (AttributesCatego == "OUTPUT") //Categoria OUTPUT y Parametro de Salida
                    {
                        cmd.Parameters[AttributesDescri].Direction = ParameterDirection.Output;
                    }
                    else if ((AttributesCatego == "FECHA" || AttributesCatego == "FK") && Valor.ToString() == "") //Categoria FECHA y Valor vacio
                    {
                        cmd.Parameters[AttributesDescri].Value = DBNull.Value;
                    }
                    else if (!AttributesDescri.Equals("pagesize") && !AttributesDescri.Equals("sort"))
                    {
                        cmd.Parameters[AttributesDescri].Value = Valor;
                    }
                }
            }
        }

        public T ValidateNullDB<T>(object _obj)
        {
            return (_obj == null || _obj == DBNull.Value) ? default(T) : (T)_obj;
        }
    }
}
