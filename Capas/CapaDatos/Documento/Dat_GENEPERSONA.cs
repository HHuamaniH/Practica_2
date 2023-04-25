using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_GENEPERSONA;
using SQL = GeneralSQL.Data.SQL;

/// <summary>
/// </summary>
namespace CapaDatos.DOC
{
    public class Dat_GENEPERSONA
    {
        private SQL oGDataSQL = new SQL();

        private DBOracle dBOracle = new DBOracle();
        //PopupBuscador
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegPersonaBuscar(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Persona_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidad oCampos;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.CODIGO = dr["CODIGO"].ToString();
                                oCampos.COD_PERSONA = dr["COD_PERSONA"].ToString();
                                oCampos.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                oCampos.PERSONA = dr["PERSONA"].ToString();
                                oCampos.COD_DIDENTIDAD = dr["COD_DIDENTIDAD"].ToString();
                                oCampos.APE_PATERNO = dr["APE_PATERNO"].ToString();
                                oCampos.APE_MATERNO = dr["APE_MATERNO"].ToString();
                                oCampos.NOMBRES = dr["NOMBRES"].ToString();
                                // oCampos.DOCUMENTO = dr["DOCUMENTO"].ToString();
                                oCampos.N_DOCUMENTO = dr["N_DOCUMENTO"].ToString();
                                oCampos.N_RUC = dr["N_RUC"].ToString();
                                oCampos.SEXO = dr["SEXO"].ToString();
                                oCampos.TIPO_PERSONA = dr["TIPO_PERSONA"].ToString();
                                oCampos.CARGO = dr["CARGO"].ToString();
                                oCampos.COLEGIATURA_NUM = dr["COLEGIATURA_NUM"].ToString();
                                oCampos.COD_DPESPECIALIDAD = dr["COD_DPESPECIALIDAD"].ToString();
                                oCampos.DESC_DPESPECIALIDAD = dr["DESC_DPESPECIALIDAD"].ToString();
                                oCampos.COD_NACADEMICO = dr["COD_NACADEMICO"].ToString();
                                oCampos.DESC_NACADEMICO = dr["DESC_NACADEMICO"].ToString();
                                oCampos.DIRECCION = dr["DIRECCION"].ToString();
                                oCampos.CORREO = dr["CORREO"].ToString();
                                oCampos.TELEFONO = dr["TELEFONO"].ToString();
                                oCampos.COD_UBIGEO = dr["COD_UBIGEO"].ToString();
                                oCampos.UBIGEO = dr["UBIGEO"].ToString();
                                oCampos.NUM_REGISTRO_FFS = dr["NUM_REGISTRO_FFS"].ToString();
                                oCampos.NUM_REGISTRO_PROFESIONAL = dr["NUM_REGISTRO_PROFESIONAL"].ToString();
                                oCampos.COD_PTIPO = dr["TIPO"].ToString();
                                lsCEntidad.Add(oCampos);
                            }
                        }
                        else
                        {
                            throw new Exception("( 0 ) Registros Encontrados");
                        }
                    }
                }
                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String RegPersonaGrabar(OracleConnection cn, CEntidad oCEntidad)
        {
            String OUTPUTPARAM01 = "";
            try
            {
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Persona_Grabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "0")
                    {
                        throw new Exception("El Registro ya Existe");
                    }
                }
                return OUTPUTPARAM01;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostCombo(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidad();
                        List<CEntidad> lsDetDetalle;
                        CEntidad oCamposDet;
                        //
                        //Documento de Identidad
                        lsDetDetalle = new List<CEntidad>();
                        if (dr.HasRows)
                        {
                            int pt1 = dr.GetOrdinal("CODIGO");
                            int pt2 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(pt1);
                                oCamposDet.DESCRIPCION = dr.GetString(pt2);
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListMComboDIdentidad = lsDetDetalle;
                        //Tipo Persona
                        dr.NextResult();
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
                        oCampos.ListCTipoPersona = lsDetDetalle;

                        //                       
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region "SIGO V3"
        //public List<CEntidad> RegPersonaBuscarV3(OracleConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    try
        //    {
        //        using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Persona_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidad oCampos;
        //                if (dr.HasRows)
        //                {
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.CODIGO = dr["CODIGO"].ToString();
        //                        oCampos.COD_PERSONA = dr["COD_PERSONA"].ToString();
        //                        oCampos.DESCRIPCION = dr["DESCRIPCION"].ToString();
        //                        oCampos.PERSONA = dr["PERSONA"].ToString();
        //                        oCampos.COD_DIDENTIDAD = dr["COD_DIDENTIDAD"].ToString();
        //                        oCampos.APE_PATERNO = dr["APE_PATERNO"].ToString();
        //                        oCampos.APE_MATERNO = dr["APE_MATERNO"].ToString();
        //                        oCampos.NOMBRES = dr["NOMBRES"].ToString();
        //                        // oCampos.DOCUMENTO = dr["DOCUMENTO"].ToString();
        //                        oCampos.N_DOCUMENTO = dr["N_DOCUMENTO"].ToString();
        //                        oCampos.N_RUC = dr["N_RUC"].ToString();
        //                        oCampos.SEXO = dr["SEXO"].ToString();
        //                        oCampos.TIPO_PERSONA = dr["TIPO_PERSONA"].ToString();
        //                        oCampos.CARGO = dr["CARGO"].ToString();
        //                        oCampos.COLEGIATURA_NUM = dr["COLEGIATURA_NUM"].ToString();
        //                        oCampos.COD_DPESPECIALIDAD = dr["COD_DPESPECIALIDAD"].ToString();
        //                        oCampos.DESC_DPESPECIALIDAD = dr["DESC_DPESPECIALIDAD"].ToString();
        //                        oCampos.COD_NACADEMICO = dr["COD_NACADEMICO"].ToString();
        //                        oCampos.DESC_NACADEMICO = dr["DESC_NACADEMICO"].ToString();
        //                        oCampos.DIRECCION = dr["DIRECCION"].ToString();
        //                        oCampos.CORREO = dr["CORREO"].ToString();
        //                        oCampos.TELEFONO = dr["TELEFONO"].ToString();
        //                        oCampos.COD_UBIGEO = dr["COD_UBIGEO"].ToString();
        //                        oCampos.UBIGEO = dr["UBIGEO"].ToString();
        //                        oCampos.NUM_REGISTRO_FFS = dr["NUM_REGISTRO_FFS"].ToString();
        //                        oCampos.NUM_REGISTRO_PROFESIONAL = dr["NUM_REGISTRO_PROFESIONAL"].ToString();
        //                        oCampos.COD_PTIPO = dr["TIPO"].ToString();
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

        public String RegPersonaGrabarSimple_v3(CEntidad oCEntidad)
        {
            String OUTPUTPARAM01 = "";
            OracleTransaction tr = null;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPERSONA_GrabarSimple_v3", oCEntidad))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM01 = Convert.ToString(cmd.Parameters["OUTPUTPARAM01"].Value);

                        switch (OUTPUTPARAM01)
                        {
                            case "0": throw new Exception("La persona (natural o jurídica) ya existe)");
                            case "1": throw new Exception("El tipo de persona no existe");
                            case "2": throw new Exception("El tipo de documento no existe");
                            case "3": throw new Exception("El número de documento de identidad no corresponde al tipo de documento");
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
        }
        public List<CEntidad> RegPersonaBuscarSimple_v3(CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.USP_GENERAL_PERSONA_LISTAR_V3", oCEntidad.BusGrupo, oCEntidad.BusCriterio, oCEntidad.BusValor, oCEntidad.COD_PTIPO))
                    {
                        if (dr != null)
                        {
                            CEntidad oCampos;
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCampos = new CEntidad();
                                    oCampos.COD_PERSONA = dr["COD_PERSONA"].ToString();
                                    oCampos.PERSONA = dr["PERSONA"].ToString();
                                    oCampos.TIPO_PERSONA_TEXT = dr["TIPO_PERSONA_TEXT"].ToString();
                                    oCampos.COD_DIDENTIDAD = dr["COD_DIDENTIDAD"].ToString();
                                    oCampos.DIDENTIDAD = dr["DIDENTIDAD"].ToString();
                                    oCampos.N_DOCUMENTO = dr["N_DOCUMENTO"].ToString();
                                    oCampos.FICHA_REGISTRAL = dr["FICHA_REGISTRAL"].ToString();
                                    oCampos.PTIPO = dr["PTIPO"].ToString();
                                    oCampos.NUM_REGISTRO_PROFESIONAL = dr["DPROFESIONAL"].ToString();
                                    //TRAE UBIGEO | DIRECCION
                                    string[] ubi_dir = dr["UBIGEO_DIRECCION"].ToString().Split('|');
                                    if (ubi_dir.Length > 1)
                                    {
                                        oCampos.UBIGEO= ubi_dir[0];
                                        oCampos.DIRECCION = ubi_dir[1];
                                        oCampos.COD_UBIGEO = ubi_dir[2];
                                    }
                                    oCampos.NOMBRES = dr["NOMBRES"].ToString();
                                    oCampos.APE_PATERNO = dr["APE_PATERNO"].ToString();
                                    oCampos.APE_MATERNO = dr["APE_MATERNO"].ToString();
                                    oCampos.N_RUC = dr["N_RUC"].ToString();
                                    lsCEntidad.Add(oCampos);
                                }
                            }
                        }
                    }
                    return lsCEntidad;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
