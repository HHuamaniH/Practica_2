using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_InformeAutoridadForestal;
using CEntPersona = CapaEntidad.DOC.Ent_GENEPERSONA;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    public class Dat_InformeAutoridadForestal
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
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
                        oCampos.ListMComboEspecie = new List<CEntidad>();

                        List<CEntidad> lsDetDetalle;
                        CEntidad oCamposDet;
                        //Documento Identidad
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
                        oCampos.ListIndicador = lsDetDetalle;
                        //Oficinas Desconcentradas
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
                        oCampos.ListODs = lsDetDetalle;
                        //Oficinas Desconcentradas
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
                        oCampos.ListEntidad = lsDetDetalle;
                        //Documento Identidad
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
                        oCampos.ListMComboDIdentidad = lsDetDetalle;
                        //Especialidad
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
                        oCampos.ListPersEspecialidad = lsDetDetalle;
                        //NIVEL ACADEMICO
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
                        oCampos.ListNivelAcademico = lsDetDetalle;
                        //Tipo Informes
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
                        oCampos.ListTipoInformes = lsDetDetalle;
                        ////Especies Cientifico
                        //dr.NextResult();
                        //lsDetDetalle = new List<CEntidad>();
                        //if (dr.HasRows)
                        //{                            
                        //	while (dr.Read())
                        //	{
                        //		oCamposDet = new CEntidad();
                        //		oCamposDet.CODIGO = dr["CODIGO"].ToString();
                        //		oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                        //		lsDetDetalle.Add(oCamposDet);
                        //	}
                        //}
                        //oCampos.ListEspeciesCientifico = lsDetDetalle;
                        //Especies Cientifico
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                oCampos.ListMComboEspecie.Add(oCamposDet);
                            }
                        }
                    }
                }
                return oCampos;
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
        public List<CEntidad> RegNuevoBuscar(OracleConnection cn, CEntidad oCEntidad)
        {
            List<CEntidad> lsCEntidad = new List<CEntidad>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            int p1 = dr.GetOrdinal("COD_THABILITANTE");
                            int p2 = dr.GetOrdinal("MODALIDAD");
                            int p3 = dr.GetOrdinal("NUM_THABILITANTE");
                            int p4 = dr.GetOrdinal("PERSONA");
                            CEntidad oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_THABILITANTE = dr.GetString(p1);
                                oCampos.MODALIDAD = dr.GetString(p2);
                                oCampos.NUM_THABILITANTE = dr.GetString(p3);
                                oCampos.TITULAR = dr.GetString(p4);
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
        public CEntidad RegMostrarListaItem(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                object[] param = { oCEntidad.COD_INFORME };
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_AUT_FORESTALMostItem", param))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListProfesionales = new List<CEntPersona>();
                        lsCEntidad.ListVolInjustificado = new List<CEntidad>();
                        lsCEntidad.ListEliTABLA = new List<CEntidad>();
                        //CEntPresupSuper ocampodet;
                        //CEntidad ocampoEnt;
                        CEntPersona ocampoPersona;
                        CEntidad ocampoVol;
                        if (dr.HasRows)
                        {
                            dr.Read();
                            //lsCEntidad.COD_ITIPO = dr.GetString(dr.GetOrdinal("COD_ITIPO"));

                            lsCEntidad.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                            lsCEntidad.NUM_THABILITANTE = dr.GetString(dr.GetOrdinal("NUM_THABILITANTE"));
                            lsCEntidad.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                            lsCEntidad.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                            lsCEntidad.COD_ENTIDAD = dr.GetString(dr.GetOrdinal("COD_ENTIDAD"));
                            lsCEntidad.COD_INFORME = dr.GetString(dr.GetOrdinal("COD_INFORME"));
                            lsCEntidad.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO"));
                            lsCEntidad.FECHA_EMISION = dr.GetString(dr.GetOrdinal("FECHA_EMISION"));
                            lsCEntidad.FECHA_RECEPCION = dr.GetString(dr.GetOrdinal("FECHA_RECEPCION"));
                            lsCEntidad.CONCLUSIONES = dr.GetString(dr.GetOrdinal("CONCLUSIONES"));
                            lsCEntidad.DOCUMENTOS_ADJUNTOS = dr.GetString(dr.GetOrdinal("DOCUMENTOS_ADJUNTOS"));
                            lsCEntidad.OBSERVACIONES = dr.GetString(dr.GetOrdinal("OBSERVACIONES"));
                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            lsCEntidad.COD_ITIPO = dr.GetString(dr.GetOrdinal("COD_ITIPO"));

                            lsCEntidad.MOTIVO_RENUNCIA = dr.GetString(dr.GetOrdinal("MOTIVO_RENUNCIA"));
                            lsCEntidad.NUM_DOCUMENTO_AUTORIDAD = dr.GetString(dr.GetOrdinal("NUM_DOCUMENTO_AUTORIDAD"));
                            lsCEntidad.FECHA_DOCUMENTO_AUTORIDAD = dr.GetString(dr.GetOrdinal("FECHA_DOCUMENTO_AUTORIDAD"));

                            lsCEntidad.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            lsCEntidad.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            lsCEntidad.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            //NIVEL DE RIESGO
                            //lsCEntidad.NIVEL_RIESGO = dr.GetString(dr.GetOrdinal("NIVEL_RIESGO"));
                            //lsCEntidad.TIPO_RIESGO = dr.GetString(dr.GetOrdinal("TIPO_RIESGO"));
                            //lsCEntidad.OBSERVACION_RIESGO = dr.GetString(dr.GetOrdinal("OBSERVACION_RIESGO"));

                            lsCEntidad.PUBLICAR = dr.GetBoolean(dr.GetOrdinal("PUBLICAR"));
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            lsCEntidad.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));
                        }
                        //Lista de Profesionales
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_PROFESIONAL");
                            int pt1 = dr.GetOrdinal("APE_PATERNO");
                            int pt2 = dr.GetOrdinal("APE_MATERNO");
                            int pt3 = dr.GetOrdinal("NOMBRES");
                            int pt4 = dr.GetOrdinal("NOM_PROFESIONAL");
                            int pt5 = dr.GetOrdinal("N_DOCUMENTO");
                            int pt6 = dr.GetOrdinal("COD_DIDENTIDAD");
                            int pt7 = dr.GetOrdinal("COD_NACADEMICO");
                            int pt8 = dr.GetOrdinal("COD_DPESPECIALIDAD");
                            int pt9 = dr.GetOrdinal("COLEGIATURA_NUM");
                            int pt10 = dr.GetOrdinal("CARGO");
                            while (dr.Read())
                            {
                                ocampoPersona = new CEntPersona();
                                ocampoPersona.COD_PERSONA = dr.GetString(pt0);
                                ocampoPersona.APE_PATERNO = dr.GetString(pt1);
                                ocampoPersona.APE_MATERNO = dr.GetString(pt2);
                                ocampoPersona.NOMBRES = dr.GetString(pt3);
                                ocampoPersona.PERSONA = dr.GetString(pt4);
                                ocampoPersona.N_DOCUMENTO = dr.GetString(pt5);
                                ocampoPersona.COD_DIDENTIDAD = dr.GetString(pt6);
                                ocampoPersona.COD_NACADEMICO = dr.GetString(pt7);
                                ocampoPersona.COD_DPESPECIALIDAD = dr.GetString(pt8);
                                ocampoPersona.COLEGIATURA_NUM = dr.GetString(pt9);
                                ocampoPersona.CARGO = dr.GetString(pt10);
                                ocampoPersona.COD_PTIPO = "0000007";
                                ocampoPersona.RegEstado = 0;
                                lsCEntidad.ListProfesionales.Add(ocampoPersona);
                            }
                        }
                        // VOLUMEN INJUSTIFICADO
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoVol = new CEntidad();
                                ocampoVol.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoVol.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                ocampoVol.ESPECIES = dr.GetString(dr.GetOrdinal("ESPECIES"));
                                ocampoVol.VOLUMEN_APROBADO = dr.GetDecimal(dr.GetOrdinal("VOLUMEN_APROBADO"));
                                ocampoVol.VOLUMEN_MOVILIZADO = dr.GetDecimal(dr.GetOrdinal("VOLUMEN_MOVILIZADO"));
                                ocampoVol.VOLUMEN_INJUSTIFICADO = dr.GetDecimal(dr.GetOrdinal("VOLUMEN_INJUSTIFICADO"));
                                ocampoVol.VOLUMEN_JUSTIFICADO = dr.GetDecimal(dr.GetOrdinal("VOLUMEN_JUSTIFICADO"));
                                ocampoVol.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                ocampoVol.RegEstado = 0;
                                lsCEntidad.ListVolInjustificado.Add(ocampoVol);
                            }
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
        public String RegInsertar(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad ocampoSuper;
            CEntPersona ocampoPersona;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_AUTORIDAD_FORESTAL_Grabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["@OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "100")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El registro se encuentra con Control de Calidad Conforme, No se puede modificar el registro");
                    }
                    else if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                    if (OUTPUTPARAM01 == "0")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de Informe ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número del Informe de la Autoridad Forestal Existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Informe");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                }
                //
                //Eliminando Detalle Informe
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        ocampoSuper = new CEntidad();
                        ocampoSuper.COD_INFORME = OUTPUTPARAM01;
                        ocampoSuper.EliTABLA = loDatos.EliTABLA;
                        ocampoSuper.COD_PERSONA = loDatos.COD_PERSONA;
                        ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                        ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_Eliminar", ocampoSuper);
                    }
                }
                //
                if (oCEntidad.ListProfesionales != null)
                {
                    foreach (var loDatos in oCEntidad.ListProfesionales)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoPersona = new CEntPersona();
                            ocampoPersona.COD_PERSONA = loDatos.COD_PERSONA;
                            ocampoPersona.CODIGO = OUTPUTPARAM01;
                            ocampoPersona.COD_DIDENTIDAD = loDatos.COD_DIDENTIDAD;
                            ocampoPersona.APE_PATERNO = loDatos.APE_PATERNO;
                            ocampoPersona.APE_MATERNO = loDatos.APE_MATERNO;
                            ocampoPersona.NOMBRES = loDatos.NOMBRES;
                            ocampoPersona.N_DOCUMENTO = loDatos.N_DOCUMENTO;
                            ocampoPersona.COD_PTIPO = loDatos.COD_PTIPO;
                            ocampoPersona.COLEGIATURA_NUM = loDatos.COLEGIATURA_NUM;
                            ocampoPersona.COD_DPESPECIALIDAD = loDatos.COD_DPESPECIALIDAD;
                            ocampoPersona.COD_NACADEMICO = loDatos.COD_NACADEMICO;
                            ocampoPersona.CARGO = loDatos.CARGO;
                            ocampoPersona.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_DET_SUPERVISOR_Grabar", ocampoPersona);
                        }
                    }
                }
                if (oCEntidad.ListVolInjustificado != null)
                {

                    foreach (var loDatos in oCEntidad.ListVolInjustificado)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            ocampoSuper = new CEntidad();
                            ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                            ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                            ocampoSuper.ESPECIES = loDatos.ESPECIES;
                            ocampoSuper.VOLUMEN_APROBADO = loDatos.VOLUMEN_APROBADO;
                            ocampoSuper.VOLUMEN_MOVILIZADO = loDatos.VOLUMEN_MOVILIZADO;
                            ocampoSuper.VOLUMEN_INJUSTIFICADO = loDatos.VOLUMEN_INJUSTIFICADO;
                            ocampoSuper.VOLUMEN_JUSTIFICADO = loDatos.VOLUMEN_JUSTIFICADO;
                            ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                            ocampoSuper.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            ocampoSuper.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_VOLUMENGrabar", ocampoSuper);
                        }
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String RegInsertarV3(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            CEntidad ocampoSuper;
            CEntPersona ocampoPersona;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_AUTORIDAD_FORESTAL_GrabarV3", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    if (OUTPUTPARAM01 == "99")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Ud. no tiene permiso para realizar esta acción");
                    }
                    if (OUTPUTPARAM01 == "0")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de Informe ya Existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número del Informe de la Autoridad Forestal Existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar este Informe");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                }
                //
                //Eliminando Detalle Informe
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        ocampoSuper = new CEntidad();
                        ocampoSuper.COD_INFORME = OUTPUTPARAM01;
                        ocampoSuper.EliTABLA = loDatos.EliTABLA;
                        ocampoSuper.COD_PERSONA = loDatos.COD_PERSONA;
                        ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                        ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spINFORME_EliminarV3", ocampoSuper);
                    }
                }
                //
                if (oCEntidad.ListProfesionales != null)
                {
                    foreach (var loDatos in oCEntidad.ListProfesionales)
                    {

                        ocampoPersona = new CEntPersona();
                        ocampoPersona.COD_PERSONA = loDatos.COD_PERSONA;
                        ocampoPersona.CODIGO = OUTPUTPARAM01;
                        ocampoPersona.COD_DIDENTIDAD = loDatos.COD_DIDENTIDAD;
                        ocampoPersona.APE_PATERNO = loDatos.APE_PATERNO;
                        ocampoPersona.APE_MATERNO = loDatos.APE_MATERNO;
                        ocampoPersona.NOMBRES = loDatos.NOMBRES;
                        ocampoPersona.N_DOCUMENTO = loDatos.N_DOCUMENTO;
                        ocampoPersona.COD_PTIPO = loDatos.COD_PTIPO;
                        ocampoPersona.COLEGIATURA_NUM = loDatos.COLEGIATURA_NUM;
                        ocampoPersona.COD_DPESPECIALIDAD = loDatos.COD_DPESPECIALIDAD;
                        ocampoPersona.COD_NACADEMICO = loDatos.COD_NACADEMICO;
                        ocampoPersona.CARGO = loDatos.CARGO;
                        ocampoPersona.RegEstado = loDatos.RegEstado;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INFORME_DET_SUPERVISOR_GrabarV3", ocampoPersona);

                    }
                }
                if (oCEntidad.ListVolInjustificado != null)
                {

                    foreach (var loDatos in oCEntidad.ListVolInjustificado)
                    {

                        ocampoSuper = new CEntidad();
                        ocampoSuper.COD_INFORME = OUTPUTPARAM01.Split('|')[0];
                        ocampoSuper.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                        ocampoSuper.COD_ESPECIES = loDatos.COD_ESPECIES;
                        ocampoSuper.ESPECIES = loDatos.ESPECIES;
                        ocampoSuper.VOLUMEN_APROBADO = loDatos.VOLUMEN_APROBADO;
                        ocampoSuper.VOLUMEN_MOVILIZADO = loDatos.VOLUMEN_MOVILIZADO;
                        ocampoSuper.VOLUMEN_INJUSTIFICADO = loDatos.VOLUMEN_INJUSTIFICADO;
                        ocampoSuper.VOLUMEN_JUSTIFICADO = loDatos.VOLUMEN_JUSTIFICADO;
                        ocampoSuper.OBSERVACION = loDatos.OBSERVACION;
                        ocampoSuper.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        ocampoSuper.RegEstado = loDatos.RegEstado;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spISUPERVISION_DET_VOLUMENGrabarV3", ocampoSuper);

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
}
