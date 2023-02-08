using CapaEntidad.DOC;
//using GeneralSQL.Data;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;

namespace CapaDatos.DOC
{
    public class Dat_PLANIFICACION
    {
        //private SQL oGDataSQL;
        private DBOracle dBOracle = new DBOracle();
        //private SqlTransaction transaction;
        private OracleTransaction transaction;

        public Dat_PLANIFICACION()
        {
            //oGDataSQL = new SQL();
            dBOracle = new DBOracle();
            transaction = null;
        }

        #region "PLAN"
        public Ent_PLAN ObtenerPlan(Ent_PLAN oCEntidad)
        {
            Ent_PLAN entPlan = new Ent_PLAN();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_Obtener", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    entPlan.COD_PLAN = dr.GetString(dr.GetOrdinal("COD_PLAN"));
                                    entPlan.ANIO = dr.GetInt32(dr.GetOrdinal("ANIO"));
                                    entPlan.FECHA_CORTE = dr.GetString(dr.GetOrdinal("FECHA_CORTE"));
                                    entPlan.HORA_CORTE = dr.GetString(dr.GetOrdinal("HORA_CORTE"));
                                    entPlan.NUMERO_RESOLUCION = dr.GetString(dr.GetOrdinal("NUMERO_RESOLUCION"));
                                    entPlan.FECHA_EMISION = dr.GetString(dr.GetOrdinal("FECHA_EMISION"));
                                    entPlan.COD_FUNCIONARIO = dr.GetString(dr.GetOrdinal("COD_FUNCIONARIO"));
                                    entPlan.FUNCIONARIO = dr.GetString(dr.GetOrdinal("FUNCIONARIO"));
                                    entPlan.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                    entPlan.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                                    entPlan.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                                    entPlan.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                                    entPlan.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));
                                    entPlan.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                                }
                            }
                        }
                    }
                }

                return entPlan;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GrabarPlan(Ent_PLAN oCEntidad)
        {
            oCEntidad.OUTPUTPARAM = "";

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_Grabar", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        string output = (string)cmd.Parameters["OUTPUTPARAM"].Value;

                        switch (output)
                        {
                            case "0": throw new Exception("Usted no esta autorizado para realizar esta acción");
                            case "1": throw new Exception("El registro no puede ser modificado ya que cuenta con la conformidad");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }
        #endregion

        #region "PLAN_COLABORADOR"
        public void GrabarPlanColaborador(Ent_PLAN_COLABORADOR oCEntidad)
        {
            oCEntidad.OUTPUTPARAM = "";

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_COLABORADOR_Grabar", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        string output = (string)cmd.Parameters["OUTPUTPARAM"].Value;

                        switch (output)
                        {
                            case "1": throw new Exception("El registro no puede ser modificado ya que cuenta con la conformidad");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }

        public List<Ent_PLAN_COLABORADOR> ListarPlanColaborador(Ent_PLAN_COLABORADOR oCEntidad)
        {
            List<Ent_PLAN_COLABORADOR> olResult = new List<Ent_PLAN_COLABORADOR>();

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_COLABORADOR_Listar", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Ent_PLAN_COLABORADOR oCampos;
                                while (dr.Read())
                                {
                                    oCampos = new Ent_PLAN_COLABORADOR();
                                    oCampos.COD_PLAN = dr["COD_PLAN"].ToString();
                                    oCampos.COD_COLABORADOR = dr["COD_COLABORADOR"].ToString();
                                    oCampos.COLABORADOR = dr["COLABORADOR"].ToString();
                                    olResult.Add(oCampos);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return olResult;
        }

        public void EliminarPlanColaborador(Ent_PLAN_COLABORADOR oCEntidad)
        {
            oCEntidad.OUTPUTPARAM = "";

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_COLABORADOR_Eliminar", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        string output = (string)cmd.Parameters["OUTPUTPARAM"].Value;

                        switch (output)
                        {
                            case "1": throw new Exception("El registro no puede ser modificado ya que cuenta con la conformidad");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }
        #endregion

        #region "PLAN_UNIVERSO"
        public List<Dictionary<string, string>> ListarPlanUniverso(Ent_PLAN_UNIVERSO oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_UNIVERSO_Listar", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Dictionary<string, string> sFila;
                                string sColumn = "";

                                while (dr.Read())
                                {
                                    sFila = new Dictionary<string, string>();
                                    for (int i = 0; i < dr.FieldCount; i++)
                                    {
                                        sColumn = dr.GetName(i);
                                        sFila.Add(sColumn, dr[sColumn].ToString().Trim());
                                    }
                                    lstResult.Add(sFila);
                                }
                            }
                        }
                    }
                }

                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GenerarPlanUniverso(Ent_PLAN_UNIVERSO oCEntidad)
        {
            oCEntidad.OUTPUTPARAM = "";

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_UNIVERSO_Generar", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        string output = (string)cmd.Parameters["OUTPUTPARAM"].Value;

                        switch (output)
                        {
                            case "1": throw new Exception("No se puede generar el universo debido a que el plan ya cuenta con la conformidad");
                            case "2": throw new Exception("El universo ya se encuentra generado");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }

        public void LimpiarPlanUniverso(Ent_PLAN_UNIVERSO oCEntidad)
        {
            oCEntidad.OUTPUTPARAM = "";

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_UNIVERSO_Eliminar", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        string output = (string)cmd.Parameters["OUTPUTPARAM"].Value;

                        switch (output)
                        {
                            case "1": throw new Exception("No se puede eliminar el universo debido a que el plan ya cuenta con la conformidad");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }

        public void ActualizarPlanUniverso(Ent_PLAN_UNIVERSO oCEntidad)
        {
            oCEntidad.OUTPUTPARAM = "";

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_UNIVERSO_Actualizar", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        string output = (string)cmd.Parameters["OUTPUTPARAM"].Value;

                        switch (output)
                        {
                            case "1": throw new Exception("No se puede actualizar los datos del universo debido a que el plan ya cuenta con la conformidad");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }
        #endregion

        #region "PLAN_CRITERIO"
        public Ent_PLAN_CRITERIO ObtenerPlanCriterio(Ent_PLAN_CRITERIO oCEntidad)
        {
            Ent_PLAN_CRITERIO entCriterio = new Ent_PLAN_CRITERIO();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CRITERIO_Obtener", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    entCriterio.COD_PCRITERIO = dr.GetString(dr.GetOrdinal("COD_PCRITERIO"));
                                    entCriterio.COD_PLAN = dr.GetString(dr.GetOrdinal("COD_PLAN"));
                                    entCriterio.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                    entCriterio.PCRITERIO = dr.GetString(dr.GetOrdinal("PCRITERIO"));
                                    entCriterio.COD_TCRITERIO = dr.GetString(dr.GetOrdinal("COD_TCRITERIO"));
                                    entCriterio.COD_TAPLICACION = dr.GetString(dr.GetOrdinal("COD_TAPLICACION"));
                                    entCriterio.COD_PCOLUMNA = dr.GetString(dr.GetOrdinal("COD_PCOLUMNA"));
                                    entCriterio.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                    entCriterio.ACTIVO = dr.GetBoolean(dr.GetOrdinal("ACTIVO"));
                                }
                            }
                        }
                    }
                }

                return entCriterio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GrabarPlanCriterio(Ent_PLAN_CRITERIO oCEntidad)
        {
            oCEntidad.OUTPUTPARAM = "";

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CRITERIO_Grabar", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        oCEntidad.OUTPUTPARAM = (string)cmd.Parameters["OUTPUTPARAM"].Value;

                        switch (oCEntidad.OUTPUTPARAM)
                        {
                            case "1": throw new Exception("El registro no puede ser modificado ya que cuenta con la conformidad");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }

            return oCEntidad.OUTPUTPARAM;
        }

        public List<Ent_PLAN_CRITERIO> ListarPlanCriterio(Ent_PLAN_CRITERIO oCEntidad)
        {
            List<Ent_PLAN_CRITERIO> olResult = new List<Ent_PLAN_CRITERIO>();

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CRITERIO_Listar", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Ent_PLAN_CRITERIO oCampos;
                                while (dr.Read())
                                {
                                    oCampos = new Ent_PLAN_CRITERIO();
                                    oCampos.COD_PCRITERIO = dr["COD_PCRITERIO"].ToString();
                                    oCampos.TCRITERIO = dr.GetString(dr.GetOrdinal("TCRITERIO"));
                                    oCampos.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                    oCampos.PCRITERIO = dr.GetString(dr.GetOrdinal("PCRITERIO"));
                                    oCampos.TAPLICACION = dr.GetString(dr.GetOrdinal("TAPLICACION"));
                                    oCampos.PCOLUMNA = dr.GetString(dr.GetOrdinal("PCOLUMNA"));
                                    olResult.Add(oCampos);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return olResult;
        }

        public void EliminarPlanCriterio(Ent_PLAN_CRITERIO oCEntidad)
        {
            oCEntidad.OUTPUTPARAM = "";

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CRITERIO_Eliminar", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        string output = (string)cmd.Parameters["OUTPUTPARAM"].Value;

                        switch (output)
                        {
                            case "1": throw new Exception("El registro no puede ser modificado ya que cuenta con la conformidad");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }

        public void ReplicarPlanCriterio(Ent_PLAN_CRITERIO oCEntidad)
        {
            oCEntidad.OUTPUTPARAM = "";

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CRITERIO_Replicar", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        string output = (string)cmd.Parameters["OUTPUTPARAM"].Value;

                        switch (output)
                        {
                            case "1": throw new Exception("El registro no puede ser modificado ya que cuenta con la conformidad");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }
        #endregion

        #region "PLAN_COLUMNA"
        public Ent_PLAN_COLUMNA ObtenerPlanColumna(Ent_PLAN_COLUMNA oCEntidad)
        {
            Ent_PLAN_COLUMNA entOpcion = new Ent_PLAN_COLUMNA();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_COLUMNA_Obtener", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    entOpcion.COD_PCOLUMNA = dr.GetString(dr.GetOrdinal("COD_PCOLUMNA"));
                                    entOpcion.TIPO_DATO = dr.GetString(dr.GetOrdinal("TIPO_DATO"));
                                }
                            }
                        }
                    }
                }

                return entOpcion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ent_PLAN_COLUMNA> ListarPlanColumnaOpcion(Ent_PLAN_COLUMNA oCEntidad)
        {
            List<Ent_PLAN_COLUMNA> olResult = new List<Ent_PLAN_COLUMNA>();

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_COLUMNA_ObtenerCombo", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Ent_PLAN_COLUMNA oCampos;
                                while (dr.Read())
                                {
                                    oCampos = new Ent_PLAN_COLUMNA();
                                    oCampos.OPCION = dr["OPCION"].ToString();
                                    olResult.Add(oCampos);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return olResult;
        }
        #endregion

        #region "PLAN_CRITERIO_VALOR"
        public List<Ent_PLAN_CRITERIO_VALOR> ListarPlanCriterioValor(Ent_PLAN_CRITERIO_VALOR oCEntidad)
        {
            List<Ent_PLAN_CRITERIO_VALOR> olResult = new List<Ent_PLAN_CRITERIO_VALOR>();

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CRITERIO_VALOR_Listar", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Ent_PLAN_CRITERIO_VALOR oCampos;
                                while (dr.Read())
                                {
                                    oCampos = new Ent_PLAN_CRITERIO_VALOR();
                                    oCampos.COD_PCRITERIO = dr["COD_PCRITERIO"].ToString();
                                    oCampos.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    oCampos.OPCION_TEXTO_1 = dr["OPCION_TEXTO_1"].ToString();
                                    oCampos.OPCION_NUMERO_1 = decimal.Parse(dr["OPCION_NUMERO_1"].ToString());
                                    oCampos.OPCION_NUMERO_2 = decimal.Parse(dr["OPCION_NUMERO_2"].ToString());
                                    oCampos.OPCION_FECHA_1 = dr.GetString(dr.GetOrdinal("OPCION_FECHA_1"));
                                    oCampos.OPCION_FECHA_2 = dr.GetString(dr.GetOrdinal("OPCION_FECHA_2"));
                                    oCampos.VALOR = decimal.Parse(dr["VALOR"].ToString());
                                    oCampos.RIESGO = decimal.Parse(dr["RIESGO"].ToString());
                                    olResult.Add(oCampos);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return olResult;
        }

        public void GrabarPlanCriterioValor(Ent_PLAN_CRITERIO_VALOR oCEntidad)
        {
            oCEntidad.OUTPUTPARAM = "";

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CRITERIO_VALOR_Grabar", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        string output = (string)cmd.Parameters["OUTPUTPARAM"].Value;

                        switch (output)
                        {
                            case "1": throw new Exception("El registro no puede ser modificado ya que cuenta con la conformidad");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }

        public void EliminarPlanCriterioValor(Ent_PLAN_CRITERIO_VALOR oCEntidad)
        {
            oCEntidad.OUTPUTPARAM = "";

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CRITERIO_VALOR_Eliminar", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        string output = (string)cmd.Parameters["OUTPUTPARAM"].Value;

                        switch (output)
                        {
                            case "1": throw new Exception("El registro no puede ser modificado ya que cuenta con la conformidad");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }

        public Ent_PLAN_CRITERIO_VALOR ObtenerPlanCriterioValor(Ent_PLAN_CRITERIO_VALOR oCEntidad)
        {
            Ent_PLAN_CRITERIO_VALOR entCriterio = new Ent_PLAN_CRITERIO_VALOR();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CRITERIO_VALOR_Obtener", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    entCriterio.COD_PCRITERIO = dr.GetString(dr.GetOrdinal("COD_PCRITERIO"));
                                    entCriterio.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                    entCriterio.OPCION_TEXTO_1 = dr.GetString(dr.GetOrdinal("OPCION_TEXTO_1"));
                                    entCriterio.OPCION_NUMERO_1 = dr.GetDecimal(dr.GetOrdinal("OPCION_NUMERO_1"));
                                    entCriterio.OPCION_NUMERO_2 = dr.GetDecimal(dr.GetOrdinal("OPCION_NUMERO_2"));
                                    entCriterio.OPCION_FECHA_1 = dr.GetString(dr.GetOrdinal("OPCION_FECHA_1"));
                                    entCriterio.OPCION_FECHA_2 = dr.GetString(dr.GetOrdinal("OPCION_FECHA_2"));
                                    entCriterio.VALOR = dr.GetDecimal(dr.GetOrdinal("VALOR"));
                                    entCriterio.RIESGO = dr.GetDecimal(dr.GetOrdinal("RIESGO"));
                                }
                            }
                        }
                    }
                }

                return entCriterio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region "PLAN_CASUISTICA"
        public List<Ent_PLAN_CASUISTICA> ListarPlanCasuistica(Ent_PLAN_CASUISTICA oCEntidad)
        {
            List<Ent_PLAN_CASUISTICA> olResult = new List<Ent_PLAN_CASUISTICA>();

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CASUISTICA_Listar", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Ent_PLAN_CASUISTICA oCampos;
                                while (dr.Read())
                                {
                                    oCampos = new Ent_PLAN_CASUISTICA();
                                    oCampos.COD_PCASUISTICA = dr["COD_PCASUISTICA"].ToString();
                                    oCampos.PCASUISTICA = dr["PCASUISTICA"].ToString();
                                    oCampos.TCRITERIO = dr.GetString(dr.GetOrdinal("TCRITERIO"));
                                    oCampos.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                    oCampos.N_CRITERIO = Int32.Parse(dr["N_CRITERIO"].ToString());
                                    oCampos.N_REGISTRO = Int32.Parse(dr["N_REGISTRO"].ToString());
                                    olResult.Add(oCampos);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return olResult;
        }

        public void GrabarPlanCasuistica(Ent_PLAN_CASUISTICA oCEntidad)
        {
            oCEntidad.OUTPUTPARAM = "";

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CASUISTICA_Grabar", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        string output = (string)cmd.Parameters["OUTPUTPARAM"].Value;

                        switch (output)
                        {
                            case "1": throw new Exception("El registro no puede ser modificado ya que cuenta con la conformidad");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }

        public void EliminarPlanCasuistica(Ent_PLAN_CASUISTICA oCEntidad)
        {
            oCEntidad.OUTPUTPARAM = "";

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CASUISTICA_Eliminar", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        string output = (string)cmd.Parameters["OUTPUTPARAM"].Value;

                        switch (output)
                        {
                            case "1": throw new Exception("El registro no puede ser modificado ya que cuenta con la conformidad");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }

        public Ent_PLAN_CASUISTICA ObtenerPlanCasuistica(Ent_PLAN_CASUISTICA oCEntidad)
        {
            Ent_PLAN_CASUISTICA entCriterio = new Ent_PLAN_CASUISTICA();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CASUISTICA_Obtener", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    entCriterio.COD_PCASUISTICA = dr.GetString(dr.GetOrdinal("COD_PCASUISTICA"));
                                    entCriterio.COD_PLAN = dr.GetString(dr.GetOrdinal("COD_PLAN"));
                                    entCriterio.PCASUISTICA = dr.GetString(dr.GetOrdinal("PCASUISTICA"));
                                    entCriterio.COD_TCRITERIO = dr.GetString(dr.GetOrdinal("COD_TCRITERIO"));
                                    entCriterio.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                    entCriterio.DESCRIPCION_FILTRO = dr.GetString(dr.GetOrdinal("DESCRIPCION_FILTRO"));
                                }
                            }
                        }
                    }
                }

                return entCriterio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region "PLAN_CASUISTICA_CRITERIO"
        public List<Ent_PLAN_CASUISTICA_CRITERIO> ListarPlanCasuisticaCriterio(Ent_PLAN_CASUISTICA_CRITERIO oCEntidad)
        {
            List<Ent_PLAN_CASUISTICA_CRITERIO> olResult = new List<Ent_PLAN_CASUISTICA_CRITERIO>();

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CASUISTICA_CRITERIO_Listar", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Ent_PLAN_CASUISTICA_CRITERIO oCampos;
                                while (dr.Read())
                                {
                                    oCampos = new Ent_PLAN_CASUISTICA_CRITERIO();
                                    oCampos.COD_PCASUISTICA = dr["COD_PCASUISTICA"].ToString();
                                    oCampos.COD_PCRITERIO = dr["COD_PCRITERIO"].ToString();
                                    oCampos.PCRITERIO = dr.GetString(dr.GetOrdinal("PCRITERIO"));
                                    oCampos.TAPLICACION = dr.GetString(dr.GetOrdinal("TAPLICACION"));
                                    oCampos.PCOLUMNA = dr.GetString(dr.GetOrdinal("PCOLUMNA"));
                                    olResult.Add(oCampos);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return olResult;
        }

        public void GrabarPlanCasuisticaCriterio(Ent_PLAN_CASUISTICA_CRITERIO oCEntidad)
        {
            oCEntidad.OUTPUTPARAM = "";

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CASUISTICA_CRITERIO_Grabar", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        string output = (string)cmd.Parameters["OUTPUTPARAM"].Value;

                        switch (output)
                        {
                            case "1": throw new Exception("El registro no puede ser modificado ya que cuenta con la conformidad");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }
        #endregion

        #region "PLAN_CASUISTICA_UNIVERSO"
        public List<Dictionary<string, string>> ListarPlanCasuisticaUniverso(Ent_PLAN_CASUISTICA_UNIVERSO oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CASUISTICA_UNIVERSO_Listar", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Dictionary<string, string> sFila;
                                string sColumn = "";

                                while (dr.Read())
                                {
                                    sFila = new Dictionary<string, string>();
                                    for (int i = 0; i < dr.FieldCount; i++)
                                    {
                                        sColumn = dr.GetName(i);
                                        sFila.Add(sColumn, dr[sColumn].ToString().Trim());
                                    }
                                    lstResult.Add(sFila);
                                }
                            }
                        }
                    }
                }

                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GrabarPlanCasuisticaUniverso(List<Ent_PLAN_CASUISTICA_UNIVERSO> olCEntidad)
        {
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    foreach (var loDatos in olCEntidad)
                    {
                        loDatos.OUTPUTPARAM = "";
                        dBOracle.ManExecute(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CASUISTICA_UNIVERSO_Grabar", loDatos);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }

        public void EliminarPlanCasuisticaUniverso(Ent_PLAN_CASUISTICA_UNIVERSO oCEntidad)
        {
            oCEntidad.OUTPUTPARAM = "";

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CASUISTICA_UNIVERSO_Eliminar", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        string output = (string)cmd.Parameters["OUTPUTPARAM"].Value;

                        switch (output)
                        {
                            case "1": throw new Exception("El registro no puede ser modificado ya que cuenta con la conformidad");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }

        public void CalcularPlanCasuisticaUniverso(Ent_PLAN_CASUISTICA_UNIVERSO oCEntidad)
        {
            oCEntidad.OUTPUTPARAM = "";

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CASUISTICA_UNIVERSO_Calcular", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        string output = (string)cmd.Parameters["OUTPUTPARAM"].Value;

                        switch (output)
                        {
                            case "1": throw new Exception("El registro no puede ser modificado ya que cuenta con la conformidad");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }

        public List<Dictionary<string, string>> ConsolidadoPlanCasuisticaUniverso(Ent_PLAN_CASUISTICA_UNIVERSO oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CASUISTICA_UNIVERSO_Consolidado", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Dictionary<string, string> sFila;
                                string sColumn = "";

                                while (dr.Read())
                                {
                                    sFila = new Dictionary<string, string>();
                                    for (int i = 0; i < dr.FieldCount; i++)
                                    {
                                        sColumn = dr.GetName(i);
                                        sFila.Add(sColumn, dr[sColumn].ToString().Trim());
                                    }
                                    lstResult.Add(sFila);
                                }
                            }
                        }
                    }
                }

                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PriorizarConsolidadoPlanCasuisticaUniverso(List<Ent_PLAN_CASUISTICA_UNIVERSO> olCEntidad)
        {
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    foreach (var loDatos in olCEntidad)
                    {
                        loDatos.OUTPUTPARAM = "";
                        dBOracle.ManExecute(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CASUISTICA_UNIVERSO_Consolidado_Priorizar", loDatos);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }

        public void ObservarConsolidadoPlanCasuisticaUniverso(Ent_PLAN_CASUISTICA_UNIVERSO oCEntidad)
        {
            oCEntidad.OUTPUTPARAM = "";

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CASUISTICA_UNIVERSO_Consolidado_Observar", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        string output = (string)cmd.Parameters["OUTPUTPARAM"].Value;

                        switch (output)
                        {
                            case "1": throw new Exception("El registro no puede ser modificado ya que cuenta con la conformidad");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }

        public void RevisarConsolidadoPlanCasuisticaUniverso(Ent_PLAN_CASUISTICA_UNIVERSO oCEntidad)
        {
            oCEntidad.OUTPUTPARAM = "";

            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                transaction = cn.BeginTransaction();

                try
                {
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, transaction, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CASUISTICA_UNIVERSO_Consolidado_Revisar", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        string output = (string)cmd.Parameters["OUTPUTPARAM"].Value;

                        switch (output)
                        {
                            case "1": throw new Exception("El registro no puede ser modificado ya que cuenta con la conformidad");
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null) transaction.Rollback();
                    throw ex;
                }
                finally { transaction = null; }
            }
        }

        public Ent_PLAN_CASUISTICA_UNIVERSO ObtenerConsolidadoPlanCasuisticaUniverso(Ent_PLAN_CASUISTICA_UNIVERSO oCEntidad)
        {
            Ent_PLAN_CASUISTICA_UNIVERSO entOpcion = new Ent_PLAN_CASUISTICA_UNIVERSO();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_CASUISTICA_UNIVERSO_Consolidado_Obtener", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    entOpcion.COD_PCASUISTICA = dr.GetString(dr.GetOrdinal("COD_PCASUISTICA"));
                                    entOpcion.COD_PLAN = dr.GetString(dr.GetOrdinal("COD_PLAN"));
                                    entOpcion.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                    entOpcion.OBSERVAR = dr.GetBoolean(dr.GetOrdinal("OBSERVAR"));
                                    entOpcion.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                    entOpcion.UCUENTA = dr.GetString(dr.GetOrdinal("USUARIO"));
                                    entOpcion.REVISAR = dr.GetBoolean(dr.GetOrdinal("REVISAR"));
                                    entOpcion.REVISION = dr.GetString(dr.GetOrdinal("REVISION"));
                                }
                            }
                        }
                    }
                }

                return entOpcion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region "PLAN_REPORTE"
        public List<Dictionary<string, string>> ListarReportePlan(Ent_PLAN_REPORTE oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPLAN_Reporte", oCEntidad))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Dictionary<string, string> sFila;
                                string sColumn = "";

                                while (dr.Read())
                                {
                                    sFila = new Dictionary<string, string>();
                                    for (int i = 0; i < dr.FieldCount; i++)
                                    {
                                        sColumn = dr.GetName(i);
                                        sFila.Add(sColumn, dr[sColumn].ToString().Trim());
                                    }
                                    lstResult.Add(sFila);
                                }
                            }
                        }
                    }
                }

                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}