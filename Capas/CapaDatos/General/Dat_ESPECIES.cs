using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.GENE.Ent_ESPECIES;
using SQL = GeneralSQL.Data.SQL;
namespace CapaDatos.GENE
{
    public class Dat_ESPECIES
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        //public List<CEntidad> TEMP_ESPECIES_Listar(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        List<CEntidad> lsCEntidad = new List<CEntidad>();
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.TEMP_ESPECIES_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("COD_ENCIENTIFICO");
        //                    int p2 = dr.GetOrdinal("COD_ESPECIES");
        //                    int p3 = dr.GetOrdinal("DESCRIPCION");
        //                    int p4 = dr.GetOrdinal("MODALIDAD");
        //                    int p5 = dr.GetOrdinal("COD_MTIPO");
        //                    CEntidad oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.COD_ENCIENTIFICO = dr.GetString(p1);
        //                        oCampos.COD_ESPECIES = dr.GetString(p2);
        //                        oCampos.DESCRIPCION = dr.GetString(p3);
        //                        oCampos.MODALIDAD = dr.GetString(p4);
        //                        oCampos.COD_MTIPO = dr.GetString(p5);
        //                        lsCEntidad.Add(oCampos);
        //                    }
        //                }
        //            }
        //        }
        //        return lsCEntidad;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<CEntidad> TEMP_MODALIDAD_Listar(SqlConnection cn)
        //{
        //    try
        //    {
        //        List<CEntidad> lsCEntidad = new List<CEntidad>();
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.TEMP_MODALIDAD_Listar", null))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    int p1 = dr.GetOrdinal("COD_MTIPO");
        //                    int p2 = dr.GetOrdinal("MODALIDAD_TIPO");
        //                    CEntidad oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.COD_MTIPO = dr.GetString(p1);
        //                        oCampos.MODALIDAD_TIPO = dr.GetString(p2);
        //                        lsCEntidad.Add(oCampos);
        //                    }
        //                }
        //            }
        //        }
        //        return lsCEntidad;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public Int32 TEMP_NCIENTIFICO_Grabar(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        Int32 RegNum = oGDataSQL.ManExecute(cn, null, "DOC.TEMP_NCIENTIFICO_Grabar", oCEntidad);
        //        if (RegNum == -1)
        //        {
        //            throw new Exception("No se logró realizar la operación");
        //        }
        //        return RegNum;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostCombo(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsDetDetalle = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCamposDet;
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                    }
                }
                return lsDetDetalle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<CEntidad> RegMostrarListaReino(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsDetDetalle = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spGeneral_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCamposDet;

        //                lsDetDetalle = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_REINO = dr["COD_REINO"].ToString();
        //                        oCamposDet.NOMBRE_REINO = dr["NOMBRE_REINO"].ToString();
        //                        oCamposDet.FUENTE = dr["FUENTE"].ToString();
        //                        oCamposDet.FECHA_CREACION = dr["FECHA_CREACION"].ToString();
        //                        oCamposDet.FECHA_MODIFICAR = dr["FECHA_MODIFICAR"].ToString();
        //                        lsDetDetalle.Add(oCamposDet);
        //                    }
        //                }
        //            }
        //        }
        //        return lsDetDetalle;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntidad> RegMostrarListaFilo(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsDetDetalle = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spGeneral_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCamposDet;
        //                lsDetDetalle = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_FILO = dr["COD_FILO"].ToString();
        //                        oCamposDet.NOMBRE_FILO = dr["NOMBRE_FILO"].ToString();
        //                        oCamposDet.FUENTE = dr["FUENTE"].ToString();
        //                        oCamposDet.COD_REINO = dr["COD_REINO"].ToString();
        //                        oCamposDet.NOMBRE_REINO = dr["NOMBRE_REINO"].ToString();
        //                        oCamposDet.FECHA_CREACION = dr["FECHA_CREACION"].ToString();
        //                        oCamposDet.FECHA_MODIFICAR = dr["FECHA_MODIFICAR"].ToString();
        //                        lsDetDetalle.Add(oCamposDet);
        //                    }
        //                }
        //            }
        //        }
        //        return lsDetDetalle;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntidad> RegMostrarListaClase(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsDetDetalle = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spGeneral_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCamposDet;
        //                lsDetDetalle = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_CLASE = dr["COD_CLASE"].ToString();
        //                        oCamposDet.NOMBRE_CLASE = dr["NOMBRE_CLASE"].ToString();
        //                        oCamposDet.FUENTE = dr["FUENTE"].ToString();
        //                        oCamposDet.COD_FILO = dr["COD_FILO"].ToString();
        //                        oCamposDet.NOMBRE_FILO = dr["NOMBRE_FILO"].ToString();
        //                        oCamposDet.FECHA_CREACION = dr["FECHA_CREACION"].ToString();
        //                        oCamposDet.FECHA_MODIFICAR = dr["FECHA_MODIFICAR"].ToString();
        //                        lsDetDetalle.Add(oCamposDet);
        //                    }
        //                }
        //            }
        //        }
        //        return lsDetDetalle;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntidad> RegMostrarListaOrden(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsDetDetalle = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spGeneral_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCamposDet;
        //                lsDetDetalle = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_ORDEN = dr["COD_ORDEN"].ToString();
        //                        oCamposDet.NOMBRE_ORDEN = dr["NOMBRE_ORDEN"].ToString();
        //                        oCamposDet.FUENTE = dr["FUENTE"].ToString();
        //                        oCamposDet.COD_CLASE = dr["COD_CLASE"].ToString();
        //                        oCamposDet.NOMBRE_CLASE = dr["NOMBRE_CLASE"].ToString();
        //                        oCamposDet.FECHA_CREACION = dr["FECHA_CREACION"].ToString();
        //                        oCamposDet.FECHA_MODIFICAR = dr["FECHA_MODIFICAR"].ToString();
        //                        lsDetDetalle.Add(oCamposDet);
        //                    }
        //                }
        //            }
        //        }
        //        return lsDetDetalle;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntidad> RegMostrarListaFamilia(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsDetDetalle = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spGeneral_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCamposDet;
        //                lsDetDetalle = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_FAMILIA = dr["COD_FAMILIA"].ToString();
        //                        oCamposDet.NOMBRE_FAMILIA = dr["NOMBRE_FAMILIA"].ToString();
        //                        oCamposDet.FUENTE = dr["FUENTE"].ToString();
        //                        oCamposDet.COD_ORDEN = dr["COD_ORDEN"].ToString();
        //                        oCamposDet.NOMBRE_ORDEN = dr["NOMBRE_ORDEN"].ToString();
        //                        oCamposDet.FECHA_CREACION = dr["FECHA_CREACION"].ToString();
        //                        oCamposDet.FECHA_MODIFICAR = dr["FECHA_MODIFICAR"].ToString();
        //                        lsDetDetalle.Add(oCamposDet);
        //                    }
        //                }
        //            }
        //        }
        //        return lsDetDetalle;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntidad> RegMostrarListaGenero(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsDetDetalle = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spGeneral_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCamposDet;
        //                lsDetDetalle = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.COD_GENERO = dr["COD_GENERO"].ToString();
        //                        oCamposDet.NOMBRE_GENERO = dr["NOMBRE_GENERO"].ToString();
        //                        oCamposDet.FUENTE = dr["FUENTE"].ToString();
        //                        oCamposDet.COD_FAMILIA = dr["COD_FAMILIA"].ToString();
        //                        oCamposDet.NOMBRE_FAMILIA = dr["NOMBRE_FAMILIA"].ToString();
        //                        oCamposDet.FECHA_CREACION = dr["FECHA_CREACION"].ToString();
        //                        oCamposDet.FECHA_MODIFICAR = dr["FECHA_MODIFICAR"].ToString();
        //                        lsDetDetalle.Add(oCamposDet);
        //                    }
        //                }
        //            }
        //        }
        //        return lsDetDetalle;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntidad> RegMostrarListaEspecie(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsDetDetalle = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spGeneral_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCamposDet;
        //                lsDetDetalle = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
        //                        oCamposDet.NOMBRE_COMUN = dr["NOMBRE_COMUN"].ToString();
        //                        oCamposDet.COD_ENCIENTIFICO = dr["COD_ENCIENTIFICO"].ToString();
        //                        oCamposDet.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
        //                        oCamposDet.TIPO = dr["TIPO"].ToString();
        //                        oCamposDet.FUENTE = dr["FUENTE"].ToString();
        //                        oCamposDet.COD_GENERO = dr["COD_GENERO"].ToString();
        //                        oCamposDet.NOMBRE_GENERO = dr["NOMBRE_GENERO"].ToString();
        //                        oCamposDet.COD_AGRADO_CITE = dr["COD_AGRADO_CITE"].ToString();
        //                        oCamposDet.DES_AGRADO_CITE = dr["DES_AGRADO_CITE"].ToString();
        //                        oCamposDet.COD_AGRADO_DS = dr["COD_AGRADO_DS"].ToString();
        //                        oCamposDet.DES_AGRADO_DS = dr["DES_AGRADO_DS"].ToString();
        //                        oCamposDet.COD_IMPORTANCIA = dr["COD_IMPORTANCIA"].ToString();
        //                        oCamposDet.DES_IMPORTANCIA = dr["DES_IMPORTANCIA"].ToString();
        //                        oCamposDet.FECHA_CREACION = dr["FECHA_CREACION"].ToString();
        //                        oCamposDet.FECHA_MODIFICAR = dr["FECHA_MODIFICAR"].ToString();
        //                        lsDetDetalle.Add(oCamposDet);
        //                    }
        //                }
        //            }
        //        }
        //        return lsDetDetalle;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public List<CEntidad> RegMostrarListaEspNCientifico(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsDetDetalle = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spGeneral_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCamposDet;
        //                lsDetDetalle = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
        //                        oCamposDet.COD_ENCIENTIFICO = dr["COD_ENCIENTIFICO"].ToString();
        //                        oCamposDet.TIPO = dr["TIPO"].ToString();
        //                        oCamposDet.COD_GENERO = dr["COD_GENERO"].ToString();
        //                        oCamposDet.COD_AGRADO_CITE = dr["COD_AGRADO_CITE"].ToString();
        //                        oCamposDet.COD_AGRADO_DS = dr["COD_AGRADO_DS"].ToString();
        //                        oCamposDet.FECHA_CREACION = dr["FECHA_CREACION"].ToString();
        //                        oCamposDet.FECHA_MODIFICAR = dr["FECHA_MODIFICAR"].ToString();
        //                        lsDetDetalle.Add(oCamposDet);
        //                    }
        //                }
        //            }
        //        }
        //        return lsDetDetalle;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<CEntidad> RegMostrarListaEspNComun(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsDetDetalle = new List<CEntidad>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spGeneral_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCamposDet;
        //                lsDetDetalle = new List<CEntidad>();
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCamposDet = new CEntidad();
        //                        oCamposDet.NOMBRE_COMUN = dr["NOMBRE_COMUN"].ToString();
        //                        oCamposDet.COD_ENCIENTIFICO = dr["COD_ENCIENTIFICO"].ToString();
        //                        oCamposDet.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
        //                        oCamposDet.FUENTE = dr["FUENTE"].ToString();
        //                        oCamposDet.FECHA_CREACION = dr["FECHA_CREACION"].ToString();
        //                        oCamposDet.FECHA_MODIFICAR = dr["FECHA_MODIFICAR"].ToString();
        //                        lsDetDetalle.Add(oCamposDet);
        //                    }
        //                }
        //            }
        //        }
        //        return lsDetDetalle;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public Int32 RegGrabarEspecie(OracleConnection cn, CEntidad oCEntidad)
        {
            try
            {
                Int32 RegNum = dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spESPECIESVerficaCreaNuevo", oCEntidad);
               /* if (RegNum == -1)
                {
                    throw new Exception("No se logró realizar la operación");
                }*/
                return RegNum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
        //public bool ActualizarEspecie(string COD_ENCIENTIFICO,string COD_ESPECIES,string COD_AGRADO_DS,string COD_IMPORTANCIA, string COD_UCUENTA)
        //{             
        //    using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //    {
        //        SqlTransaction tr = null;
        //        try
        //        {
        //            cn.Open();
        //            tr = cn.BeginTransaction();
        //            using (SqlCommand cmd = oGDataSQL.ManExecuteOutputV1(cn, tr, "DOC.Usp_Especie_Update"))
        //            {
        //                SqlCommandBuilder.DeriveParameters(cmd);
        //                cmd.Parameters["@COD_ENCIENTIFICO"].Value = COD_ENCIENTIFICO;
        //                cmd.Parameters["@COD_ESPECIES"].Value = COD_ESPECIES;
        //                cmd.Parameters["@COD_AGRADO_DS"].Value = COD_AGRADO_DS;
        //                cmd.Parameters["@COD_IMPORTANCIA"].Value = COD_IMPORTANCIA;
        //                cmd.Parameters["@COD_UCUENTA"].Value = COD_UCUENTA;
        //                cmd.ExecuteNonQuery();
        //            }
        //            tr.Commit();
        //        }
        //        catch (Exception ex)
        //        {
        //            tr.Rollback();
        //            tr.Dispose();
        //            tr = null;
        //            throw ex;
        //        }
        //    }
        //    return true;
        //}

        //public List<CEntidad> ListadoEspeciesExcel(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> listEspCientifico = new List<CEntidad>();
        //    CEntidad oCampos;

        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spLISTADO_ESPECIES_EXCEL", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                //Especies Nombre Cientifico
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.COD_ENCIENTIFICO = dr.GetString(dr.GetOrdinal("COD_ENCIENTIFICO"));
        //                        oCampos.NOMBRE_CIENTIFICO = dr.GetString(dr.GetOrdinal("NOMBRE_CIENTIFICO"));
        //                        oCampos.ListEspeciesComun = new List<CEntidad>();

        //                        listEspCientifico.Add(oCampos);
        //                    }
        //                }
        //                //Especies Nombre Común x Nombre Cientifico
        //                dr.NextResult();
        //                if (dr.HasRows)
        //                {
        //                    int indexEspCientifico;
        //                    while (dr.Read())
        //                    {
        //                        indexEspCientifico = -1;
        //                        oCampos = new CEntidad();
        //                        oCampos.COD_ENCIENTIFICO = dr.GetString(dr.GetOrdinal("COD_ENCIENTIFICO"));
        //                        oCampos.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
        //                        oCampos.NOMBRE_COMUN = dr.GetString(dr.GetOrdinal("NOMBRE_COMUN"));

        //                        indexEspCientifico = listEspCientifico.FindIndex(e => e.COD_ENCIENTIFICO == oCampos.COD_ENCIENTIFICO);

        //                        listEspCientifico[indexEspCientifico].ListEspeciesComun.Add(oCampos);
        //                    }
        //                }
        //            }
        //        }
        //        return listEspCientifico;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}