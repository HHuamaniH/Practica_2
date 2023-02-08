using Npgsql;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace GeneralSQL.Data
{
    public class SQL
    {
        public DataSet SelDataset(SqlConnection con, SqlTransaction trx, String SProcedure, Object objCEntidad)
        {
            using (SqlDataAdapter da = new SqlDataAdapter(SProcedure, con))
            {
                try
                {
                    using (DataSet ds = new DataSet())
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.CommandTimeout = 2000;
                        da.SelectCommand.Transaction = trx;
                        if (objCEntidad != null)
                        {
                            CrearParametros(da.SelectCommand, objCEntidad);
                        }
                        da.Fill(ds, SProcedure);
                        return ds;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public SqlDataReader SelDrdDefault(SqlConnection con, SqlTransaction trx, String SProcedure, Object objCEntidad)
        {
            using (SqlCommand cmd = new SqlCommand(SProcedure, con))
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
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
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
        public SqlDataReader SelDrdDefaultInf(SqlConnection con, SqlTransaction trx, String SProcedure, String codInforme)
        {
            using (SqlCommand cmd = new SqlCommand(SProcedure, con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 2000;
                    cmd.Transaction = trx;
                    cmd.Parameters.AddWithValue("@COD_INFORME", codInforme);

                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
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
        public SqlDataReader SelDrdDefaultPoa(SqlConnection con, SqlTransaction trx, String SProcedure, String codThabilitante, Int32 numPoa)
        {
            using (SqlCommand cmd = new SqlCommand(SProcedure, con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 2000;
                    cmd.Transaction = trx;
                    cmd.Parameters.AddWithValue("@COD_THABILITANTE", codThabilitante);
                    cmd.Parameters.AddWithValue("@NUM_POA", numPoa);

                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
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
        public SqlDataReader SelDrdRow(SqlConnection con, SqlTransaction trx, String SProcedure, Object objCEntidad)
        {
            using (SqlCommand cmd = new SqlCommand(SProcedure, con))
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
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
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
        public SqlDataReader SelDrdDefault(SqlConnection con, String SProcedure, params object[] paramsValue)
        {
            using (SqlCommand cmd = new SqlCommand(SProcedure, con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 2000;
                    if (paramsValue != null)
                    {
                        CrearParametros(cmd, paramsValue);
                    }
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
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
        public SqlDataReader SelDrdResult(SqlConnection con, SqlTransaction trx, String SProcedure, Object objCEntidad)
        {
            using (SqlCommand cmd = new SqlCommand(SProcedure, con))
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
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
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
        public Object SelScalarVal(SqlConnection con, SqlTransaction trx, String SProcedure, Object objCEntidad)
        {
            using (SqlCommand cmd = new SqlCommand(SProcedure, con))
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
        public Int32 ManExecute(SqlConnection con, SqlTransaction trx, String SProcedure, Object objCEntidad)
        {
            using (SqlCommand cmd = new SqlCommand(SProcedure, con))
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
        public Int32 ManExecute(SqlConnection con, SqlTransaction trx, String SProcedure, params object[] parametros)
        {
            using (SqlCommand cmd = new SqlCommand(SProcedure, con))
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
        public SqlCommand ManExecuteOutputV1(SqlConnection con, SqlTransaction trx, String SProcedure)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
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
        public SqlCommand ManExecuteOutput(SqlConnection con, SqlTransaction trx, String SProcedure, Object objCEntidad)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
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
        private void CrearParametros(SqlCommand cmd, params object[] parametros)
        {
            SqlCommandBuilder.DeriveParameters(cmd);
            for (int i = 0; i < parametros.Length; i++)
            {
                if (parametros[i] == null)
                    cmd.Parameters[i + 1].Value = DBNull.Value;
                else cmd.Parameters[i + 1].Value = parametros[i];

            }
        }

        public void CrearParametrosOutput(SqlCommand cmd, params object[] parametros)
        {
            SqlCommandBuilder.DeriveParameters(cmd);
            for (int i = 0; i < parametros.Length; i++)
            {
                cmd.Parameters[i + 1].Direction = ParameterDirection.Output;
                cmd.Parameters[i + 1].Value = parametros[i];

            }
        }

        private void CrearParametros(SqlCommand cmd, Object objCEntidad)
        {
            SqlCommandBuilder.DeriveParameters(cmd);
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
                        cmd.Parameters["@" + AttributesDescri].Direction = ParameterDirection.Output;
                    }
                    else if ((AttributesCatego == "FECHA" || AttributesCatego == "FK") && Valor.ToString() == "") //Categoria FECHA y Valor vacio
                    {
                        cmd.Parameters["@" + AttributesDescri].Value = DBNull.Value;
                    }
                    else //Parametro de Entrada
                    {
                        cmd.Parameters["@" + AttributesDescri].Value = Valor;
                    }
                }
            }
        }
       
        public T ValidateNullDB<T>(object _obj)
        {
            return (_obj == null || _obj == DBNull.Value) ? default(T) : (T)_obj;
        }
        //private void CrearParametros(SqlCommand cmd, Object objCEntidad, String OutputCodigo)
        //{
        //    SqlCommandBuilder.DeriveParameters(cmd);
        //    PropertyInfo[] Propiedad = objCEntidad.GetType().GetProperties();
        //    Object Valor = null;
        //    Boolean AccesoValido = false;
        //    String AttributesDescri = "";
        //    String AttributesCatego = "";
        //    string n;
        //    for (Int32 vFor = 0; vFor < Propiedad.Length; vFor++)
        //    {
        //        Valor = Propiedad[vFor].GetValue(objCEntidad, null);
        //        AccesoValido = false;
        //        if (Valor != null)
        //        {
        //            if (Valor.GetType().ToString().IndexOf("System.Collections.Generic.List") == -1)
        //            {
        //                switch (Valor.GetType().ToString())
        //                {
        //                    case "System.Numeric":
        //                        AccesoValido = (Decimal)Valor != -1;
        //                        break;
        //                    case "System.Int16":
        //                        AccesoValido = (Int16)Valor != -1;
        //                        break;
        //                    case "System.Int32":
        //                        AccesoValido = (Int32)Valor != -1;
        //                        break;
        //                    case "System.Decimal":
        //                        AccesoValido = (Decimal)Valor != -1;
        //                        break;
        //                    case "System.Double":
        //                        AccesoValido = (Double)Valor != -1;
        //                        break;
        //                    default:
        //                        AccesoValido = true;
        //                        break;
        //                }
        //            }
        //        }
        //        if (AccesoValido == true)
        //        {
        //            AttributesCatego = "";
        //            AttributesDescri = "";
        //            //
        //            //Obteniendo Atributos
        //            //DescriptionAttribute da = (DescriptionAttribute)(Propiedad[vFor].GetCustomAttributes(false)[0]);
        //            DescriptionAttribute[] da = (DescriptionAttribute[])Propiedad[vFor].GetCustomAttributes(typeof(DescriptionAttribute), false);
        //            if (da.Length > 0)
        //            {
        //                AttributesDescri = da[0].Description.ToString();
        //            }
        //            CategoryAttribute[] ca = (CategoryAttribute[])Propiedad[vFor].GetCustomAttributes(typeof(CategoryAttribute), false);
        //            if (ca.Length > 0)
        //            {
        //                AttributesCatego = ca[0].Category.ToString().ToUpper();
        //            }
        //            //
        //            //Asignando Parametros Store Procedure
        //            //Asignando Parametros de Salida
        //            if (OutputCodigo != "" && AttributesDescri == OutputCodigo)
        //            {
        //                cmd.Parameters["@" + AttributesDescri].Direction = ParameterDirection.Output;
        //            }
        //            else
        //            {
        //                //Asignando Parametros de Entrada
        //                if (AttributesCatego == "OUTPUT")
        //                {
        //                    cmd.Parameters["@" + AttributesDescri].Direction = ParameterDirection.Output;
        //                }
        //                else if (AttributesCatego == "FECHA" && Valor.ToString() == "")
        //                {
        //                    cmd.Parameters["@" + AttributesDescri].Value = DBNull.Value;
        //                }
        //                else
        //                {
        //                    cmd.Parameters["@" + AttributesDescri].Value = Valor;
        //                }
        //            }
        //        }
        //    }
        //}


        //public Object ManExecuteOutput(SqlConnection con, SqlTransaction trx, String SProcedure, Object objCEntidad, String OutputCodigo)
        //{
        //    using (SqlCommand cmd = new SqlCommand(SProcedure, con))
        //    {
        //        Int32 NumReg;
        //        String ValorResultado = "";
        //        try
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Transaction = trx;
        //            CrearParametros(cmd, objCEntidad, OutputCodigo);
        //            NumReg = cmd.ExecuteNonQuery();
        //            if (NumReg <= 0)
        //            {
        //                return ("");
        //                //throw new Exception("No se logró realizar la operación");
        //            }
        //            ValorResultado =(String)cmd.Parameters["@" + OutputCodigo].Value;
        //            return ValorResultado;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}


































        //private void CrearParametros(SqlCommand cmd, Object objCEntidad,String OutputCodigo)
        //{
        //    SqlCommandBuilder.DeriveParameters(cmd);
        //    PropertyInfo[] Propiedad = objCEntidad.GetType().GetProperties();
        //    Object Valor = null;
        //    Boolean AccesoValido = false;
        //    Object[] attrs = null;
        //    String AttributesCatego = "";
        //    for (Int32 vFor = 0; vFor < Propiedad.Length; vFor++)
        //    {
        //        Valor = Propiedad[vFor].GetValue(objCEntidad, null);
        //        AccesoValido = false;
        //        if (Valor != null)
        //        {
        //            switch (Valor.GetType().ToString())
        //            {
        //                case "System.Numeric":
        //                    AccesoValido = (Decimal)Valor != -1;
        //                    break;
        //                case "System.Int16":
        //                    AccesoValido = (Int16)Valor != -1;
        //                    break;
        //                case "System.Int32":
        //                    AccesoValido = (Int32)Valor != -1;
        //                    break;  
        //                case "System.Decimal":
        //                    AccesoValido = (Decimal)Valor != -1;
        //                    break;
        //                case "System.Double":
        //                    AccesoValido =(Double)Valor != -1;
        //                    break;
        //                default:
        //                    AccesoValido = true;
        //                    break;
        //            }
        //        }
        //        if (AccesoValido == true)
        //        {
        //            AttributesCatego = "";
        //            //
        //            DescriptionAttribute da = (DescriptionAttribute)(Propiedad[vFor].GetCustomAttributes(false)[0]);
        //            Object jaime=da.GetType().Attributes;
        //            //Capturando Atributo DefaultValueAttribute****************************************
        //            attrs = Propiedad[vFor].GetCustomAttributes(typeof(CategoryAttribute), false);
        //            if (attrs.Length > 0)
        //            {
        //                CategoryAttribute CategAtri = (CategoryAttribute)attrs[0];
        //                AttributesCatego = CategAtri.Category.ToString();
        //            }
        //            //*********************************************************************************
        //            //
        //            if (OutputCodigo != "" && da.Description == OutputCodigo)
        //            {
        //                cmd.Parameters["@" + da.Description].Direction = ParameterDirection.Output;
        //            }
        //            else
        //            {
        //                if (AttributesCatego == "FECHA" && Valor.ToString() == "")
        //                {
        //                    cmd.Parameters["@" + da.Description].Value = DBNull.Value;
        //                }
        //                else
        //                {
        //                    cmd.Parameters["@" + da.Description].Value = Valor;
        //                }

        //            }
        //        }
        //    }
        //}

    }
    public class PGSQL
    {
        public DataSet PGSelDataset(NpgsqlConnection con, NpgsqlTransaction trx, String SProcedure, Object objCEntidad)
        {
            using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(SProcedure, con))
            {
                try
                {
                    using (DataSet ds = new DataSet())
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.CommandTimeout = 2000;
                        da.SelectCommand.Transaction = trx;
                        if (objCEntidad != null)
                        {
                            PGCrearParametros(da.SelectCommand, objCEntidad);
                        }
                        da.Fill(ds, SProcedure);
                        return ds;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public NpgsqlDataReader PGSelDrdDefault(NpgsqlConnection con, NpgsqlTransaction trx, String SProcedure, Object objCEntidad)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand(SProcedure, con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 2000;
                    cmd.Transaction = trx;
                    if (objCEntidad != null)
                    {
                        PGCrearParametros(cmd, objCEntidad);
                    }
                    NpgsqlDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
                    return dr;
                    //En esta clase no se debe usar Using ya que necesitamos que el NpgsqlDataReader este abierto para el
                    //Receptor que viene hacer la clase que lo invoca
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public NpgsqlDataReader PGSelDrdRow(NpgsqlConnection con, NpgsqlTransaction trx, String SProcedure, Object objCEntidad)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand(SProcedure, con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 2000;
                    cmd.Transaction = trx;
                    if (objCEntidad != null)
                    {
                        PGCrearParametros(cmd, objCEntidad);
                    }
                    NpgsqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    return dr;
                    //En esta clase no se debe usar Using ya que necesitamos que el NpgsqlDataReader este abierto para el
                    //Receptor que viene hacer la clase que lo invoca
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public NpgsqlDataReader PGSelDrdResult(NpgsqlConnection con, NpgsqlTransaction trx, String SProcedure, Object objCEntidad)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand(SProcedure, con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 2000;
                    cmd.Transaction = trx;
                    if (objCEntidad != null)
                    {
                        PGCrearParametros(cmd, objCEntidad);
                    }
                    NpgsqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    return dr;
                    //En esta clase no se debe usar Using ya que necesitamos que el NpgsqlDataReader este abierto para el
                    //Receptor que viene hacer la clase que lo invoca
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public Object PGSelScalarVal(NpgsqlConnection con, NpgsqlTransaction trx, String SProcedure, Object objCEntidad)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand(SProcedure, con))
            {
                try
                {
                    Object Val;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 2000;
                    cmd.Transaction = trx;
                    if (objCEntidad != null)
                    {
                        PGCrearParametros(cmd, objCEntidad);
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
        public Int32 PGManExecute(NpgsqlConnection con, NpgsqlTransaction trx, String SProcedure, Object objCEntidad)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand(SProcedure, con))
            {
                Int32 NumReg;
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = trx;
                    PGCrearParametros(cmd, objCEntidad);
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
        public NpgsqlCommand PGManExecuteOutput(NpgsqlConnection con, NpgsqlTransaction trx, String SProcedure, Object objCEntidad)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = SProcedure;
                cmd.Transaction = trx;
                PGCrearParametros(cmd, objCEntidad);
                return cmd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void PGCrearParametros(NpgsqlCommand cmd, Object objCEntidad)
        {
            NpgsqlCommandBuilder.DeriveParameters(cmd);
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
                        cmd.Parameters["@" + AttributesDescri].Direction = ParameterDirection.Output;
                    }
                    else if ((AttributesCatego == "FECHA" || AttributesCatego == "FK") && Valor.ToString() == "") //Categoria FECHA y Valor vacio
                    {
                        cmd.Parameters["@" + AttributesDescri].Value = DBNull.Value;
                    }
                    else //Parametro de Entrada
                    {
                        cmd.Parameters["@" + AttributesDescri].Value = Valor;
                    }
                }
            }
        }

    }
}
