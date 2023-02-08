using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CEntidad = CapaEntidad.DOC.Ent_PROVEIDOARCHIVO;
using SQL = GeneralSQL.Data.SQL;

namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_PROVEIDOARCH
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
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
                        oCampos.ListMComboTipoFirmeza = new List<CEntidad>();
                        oCampos.ListMComboTipoAgotadaVia = new List<CEntidad>();
                        oCampos.ListMComboTipoArchivo = new List<CEntidad>();
                        oCampos.ListMComboTipoMedidas = new List<CEntidad>();
                        oCampos.ListMComboEmiteConst = new List<CEntidad>();
                        oCampos.ListODs = new List<CEntidad>();
                        CEntidad oCamposDet;

                        //Tipo Firmeza
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO"));
                                oCamposDet.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                                oCampos.ListMComboTipoFirmeza.Add(oCamposDet);
                            }
                        }
                        //Tipo Agotada Vía Administrativa
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                oCampos.ListMComboTipoAgotadaVia.Add(oCamposDet);
                            }
                        }
                        //Tipo Archivo
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                oCampos.ListMComboTipoArchivo.Add(oCamposDet);
                            }
                        }
                        //Tipo Medidas Dictadas
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                oCampos.ListMComboTipoMedidas.Add(oCamposDet);
                            }
                        }
                        //Emite Contancia de Obligacion
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                oCampos.ListMComboEmiteConst.Add(oCamposDet);
                            }
                        }
                        //lista de OD
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidad();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                oCampos.ListODs.Add(oCamposDet);
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
        //public List<CEntidad> RegMostrarPROVEIDOARCH_Buscar(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    List<CEntidad> lsCEntidad = new List<CEntidad>();
        //    try
        //    {

        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spGeneral_Listar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    CEntidad oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidad();
        //                        oCampos.COD_INFORME = dr["COD_INFORME"].ToString();
        //                        oCampos.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
        //                        oCampos.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
        //                        oCampos.NUMERO = dr["NUMERO"].ToString();
        //                        oCampos.D_LINEA = dr["D_LINEA"].ToString();
        //                        oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
        //                        oCampos.TITULAR = dr["TITULAR"].ToString();
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String RegGrabaProveidoArchivo(OracleConnection cn, CEntidad oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            String OUTPUTPARAM02 = "";
            CEntidad oCamposDet;

            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPROVEIDOARCHGrabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    //     OUTPUTPARAM02 = (String)cmd.Parameters["@OUTPUTPARAM02"].Value;
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
                        throw new Exception("El Número Solicitud de Información Externa  ya existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número Solicitud de Información Externa existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar el proveido");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                }
                //Reemplazando El Nuevo Codigo Creado
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_PROVEIDOARCH = OUTPUTPARAM01;

                }
                //  Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.COD_PROVEIDOARCH = OUTPUTPARAM01;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                        oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                        oCamposDet.COD_RESODIREC_INI_PAU = loDatos.COD_RESODIREC_INI_PAU;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPROVEIDOARCHSEliminarDetalle", oCamposDet);
                    }
                }
                //Grabando Detalle Inicio PAU                 
                if (oCEntidad.ListInformes != null)
                {
                    foreach (var loDatos in oCEntidad.ListInformes)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();

                            oCamposDet.COD_PROVEIDOARCH = OUTPUTPARAM01;
                            if (loDatos.COD_RESODIREC != null && loDatos.COD_RESODIREC_INI_PAU != null)
                            {
                                oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                                oCamposDet.COD_RESODIREC_INI_PAU = loDatos.COD_RESODIREC_INI_PAU;
                                oCamposDet.RegEstado = 1;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.PROVEIDOARCH_VS_EXP_Grabar", oCamposDet);
                            }
                            else if (loDatos.COD_INFORME != null)
                            {
                                oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                                oCamposDet.RegEstado = 1;
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spPROVEIDOARCH_VS_INFORME_Grabar", oCamposDet);
                            }
                        }
                    }
                }
                if (oCEntidad.ListadoFuncionario != null)
                {
                    foreach (var loDatos in oCEntidad.ListadoFuncionario)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidad();
                            //    oCamposDet.COD_SECUENCIAL = 0;
                            oCamposDet.CARGO = loDatos.CARGO;
                            oCamposDet.COD_FUNCIONARIO = loDatos.COD_FUNCIONARIO;
                            oCamposDet.COD_PROVEIDOARCH = OUTPUTPARAM01;
                            oCamposDet.RegEstado = 1;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.PROVEIDOARCH_FUNCIONARIO_Grabar", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.ListMandatos != null)
                {
                    foreach (var loDatos in oCEntidad.ListMandatos)
                    {
                        oCamposDet = new CEntidad();
                        oCamposDet.ICODMANDATO = 0;
                        oCamposDet.ITIPO = 1;
                        oCamposDet.vEnlace = OUTPUTPARAM01;
                        oCamposDet.MANDATO = loDatos.MANDATO;
                        oCamposDet.CANTMESES = loDatos.CANTMESES;
                        oCamposDet.CANTDIAS = loDatos.CANTDIAS;
                        oCamposDet.USUARIO_REGISTRO = "0";
                        oCamposDet.ESMANDATO = 0;
                       // oGDataSQL.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.INSERTAUPDATE_MANDATOS", oCamposDet);
                    }
                }

                tr.Commit();
                return OUTPUTPARAM01 + '|' + OUTPUTPARAM02;
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
        public CEntidad RegMostrarListaSolExtItem(OracleConnection cn, CEntidad oCEntidad)
        {
            CEntidad lsCEntidad = new CEntidad();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spPROVEIDOARCHMostrarItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListInformes = new List<CEntidad>();
                        lsCEntidad.ListadoFuncionario = new List<CEntidad>();
                        lsCEntidad.ListMandatos = new List<CEntidad>();
                        CEntidad ocampoEnt2;

                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_PROVEIDOARCH = dr.GetString(dr.GetOrdinal("COD_PROVEIDOARCH"));
                            lsCEntidad.TIPO_FISCALIZA = dr.GetString(dr.GetOrdinal("TIPO_FISCALIZA"));
                            //lsCEntidad.TIPO = dr.GetString(dr.GetOrdinal("TIPO"));
                            lsCEntidad.FECHA = dr.GetString(dr.GetOrdinal("FECHA"));
                            lsCEntidad.RESOLDIRECTORAL = dr.GetString(dr.GetOrdinal("RESOLDIRECTORAL"));
                            lsCEntidad.RESOLTRIBUNAL = dr.GetString(dr.GetOrdinal("RESOLTRIBUNAL"));
                            lsCEntidad.RESUEL_FUNDADO = dr.GetBoolean(dr.GetOrdinal("RESUEL_FUNDADO"));
                            lsCEntidad.RESUEL_INFUNDADO = dr.GetBoolean(dr.GetOrdinal("RESUEL_INFUNDADO"));
                            lsCEntidad.RESUEL_IMPROCEDENTE = dr.GetBoolean(dr.GetOrdinal("RESUEL_IMPROCEDENTE"));
                            lsCEntidad.REFERENCIA = dr.GetString(dr.GetOrdinal("REFERENCIA"));
                            lsCEntidad.RECOMENDACION = dr.GetString(dr.GetOrdinal("RECOMENDACION"));
                            lsCEntidad.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));
                            lsCEntidad.RESUELVE = dr.GetString(dr.GetOrdinal("RESUELVE"));
                            lsCEntidad.COD_FCTIPO = dr.GetString(dr.GetOrdinal("COD_FCTIPO"));
                            lsCEntidad.NSUPERV_RECOM = dr.GetBoolean(dr.GetOrdinal("NSUPERV_RECOM"));
                            lsCEntidad.SIN_INDICIOS = dr.GetBoolean(dr.GetOrdinal("SIN_INDICIOS"));
                            lsCEntidad.EVIDENCIA_IRREG = dr.GetBoolean(dr.GetOrdinal("EVIDENCIA_IRREG"));
                            lsCEntidad.DEFICIENCIA_NOTIFICACION = dr.GetBoolean(dr.GetOrdinal("DEFICIENCIA_NOTIFICACION"));
                            lsCEntidad.DEFICIENCIA_TECNICA = dr.GetBoolean(dr.GetOrdinal("DEFICIENCIA_TECNICA"));
                            lsCEntidad.MUERTE_TITULAR = dr.GetBoolean(dr.GetOrdinal("MUERTE_TITULAR"));
                            lsCEntidad.ARCHIVO_TEMPORAL = dr.GetBoolean(dr.GetOrdinal("ARCHIVO_TEMPORAL"));
                            lsCEntidad.OTROS_TIPOS = dr.GetString(dr.GetOrdinal("OTROS_TIPOS"));
                            lsCEntidad.DGFFS = dr.GetBoolean(dr.GetOrdinal("DGFFS"));
                            lsCEntidad.DETALLE_DGFFS = dr.GetString(dr.GetOrdinal("DETALLE_DGFFS"));
                            lsCEntidad.PROGRAMA_REGIONAL = dr.GetBoolean(dr.GetOrdinal("PROGRAMA_REGIONAL"));
                            lsCEntidad.DETALLE_PROREG = dr.GetString(dr.GetOrdinal("DETALLE_PROREG"));
                            lsCEntidad.MIN_ENERGIA_MINAS = dr.GetBoolean(dr.GetOrdinal("MIN_ENERGIA_MINAS"));
                            lsCEntidad.DETALLE_MINENMIN = dr.GetString(dr.GetOrdinal("DETALLE_MINENMIN"));
                            lsCEntidad.COLEGIO_INGENIEROS = dr.GetBoolean(dr.GetOrdinal("COLEGIO_INGENIEROS"));
                            lsCEntidad.DETALLE_COLING = dr.GetString(dr.GetOrdinal("DETALLE_COLING"));
                            lsCEntidad.ATFFS = dr.GetBoolean(dr.GetOrdinal("ATFFS"));
                            lsCEntidad.DETALLE_ATFFS = dr.GetString(dr.GetOrdinal("DETALLE_ATFFS"));
                            lsCEntidad.OCI = dr.GetBoolean(dr.GetOrdinal("OCI"));
                            lsCEntidad.DETALLE_OCI = dr.GetString(dr.GetOrdinal("DETALLE_OCI"));
                            lsCEntidad.OEFA = dr.GetBoolean(dr.GetOrdinal("OEFA"));
                            lsCEntidad.DETALLE_OEFA = dr.GetString(dr.GetOrdinal("DETALLE_OEFA"));
                            lsCEntidad.SUNAT = dr.GetBoolean(dr.GetOrdinal("SUNAT"));
                            lsCEntidad.DETALLE_SUNAT = dr.GetString(dr.GetOrdinal("DETALLE_SUNAT"));
                            lsCEntidad.SERFOR = dr.GetBoolean(dr.GetOrdinal("SERFOR"));
                            lsCEntidad.DETALLE_SERFOR = dr.GetString(dr.GetOrdinal("DETALLE_SERFOR"));
                            lsCEntidad.CONTABILIDAD = dr.GetBoolean(dr.GetOrdinal("CONTABILIDAD"));
                            lsCEntidad.DETALLE_CONTA = dr.GetString(dr.GetOrdinal("DETALLE_CONTA"));
                            lsCEntidad.TESORERIA = dr.GetBoolean(dr.GetOrdinal("TESORERIA"));
                            lsCEntidad.DETALLE_TESO = dr.GetString(dr.GetOrdinal("DETALLE_TESO"));
                            lsCEntidad.OTROS = dr.GetBoolean(dr.GetOrdinal("OTROS"));
                            lsCEntidad.DETALLE_OTROS = dr.GetString(dr.GetOrdinal("DETALLE_OTROS"));
                            lsCEntidad.TITULAR_NOT = dr.GetBoolean(dr.GetOrdinal("TITULAR_NOT"));
                            lsCEntidad.DETALLE_TITULAR_NOT = dr.GetString(dr.GetOrdinal("DETALLE_TITULAR_NOT"));
                            lsCEntidad.MINISTERIO_PUBLICO = dr.GetBoolean(dr.GetOrdinal("MINISTERIO_PUBLICO"));
                            lsCEntidad.DETALLE_MINPUB = dr.GetString(dr.GetOrdinal("DETALLE_MINPUB"));
                            lsCEntidad.DISPONE = dr.GetString(dr.GetOrdinal("DISPONE"));
                            lsCEntidad.COD_RESUELVE = dr.GetString(dr.GetOrdinal("COD_RESUELVE"));
                            lsCEntidad.TRIBUNAL_FFS = dr.GetBoolean(dr.GetOrdinal("TRIBUNAL_FFS"));
                            lsCEntidad.DETALLE_TRIBUNAL_FFS = dr.GetString(dr.GetOrdinal("DETALLE_TRIBUNAL_FFS"));
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            //21/09/2017
                            lsCEntidad.MAE_TIP_PROVFIRMEZA = dr.GetString(dr.GetOrdinal("MAE_TIP_PROVFIRMEZA"));
                            lsCEntidad.MAE_TIP_AGOTAVIAADM = dr.GetString(dr.GetOrdinal("MAE_TIP_AGOTAVIAADM"));
                            lsCEntidad.CONFIRM_RESOL = dr.GetString(dr.GetOrdinal("CONFIRM_RESOL"));
                            var fCaducidad = dr["CADUCIDAD_FIRME"];
                            lsCEntidad.CADUCIDAD_FIRME = DBNull.Value.Equals(fCaducidad) == true ? lsCEntidad.CADUCIDAD_FIRME : Convert.ToBoolean(fCaducidad);
                            var fArt363 = dr["ART363I_FIRME"];
                            lsCEntidad.ART363I_FIRME = DBNull.Value.Equals(fArt363) == true ? lsCEntidad.ART363I_FIRME : Convert.ToBoolean(fArt363);
                            var fMulta = dr["MULTA_FIRME"];
                            lsCEntidad.MULTA_FIRME = DBNull.Value.Equals(fMulta) == true ? lsCEntidad.MULTA_FIRME : Convert.ToBoolean(fMulta);
                            var fMCorrectiva = dr["MCORRECTIVA_FIRME"];
                            lsCEntidad.MCORRECTIVA_FIRME = DBNull.Value.Equals(fMCorrectiva) == true ? lsCEntidad.MCORRECTIVA_FIRME : Convert.ToBoolean(fMCorrectiva);
                            //03/10/2017
                            lsCEntidad.MAE_TIP_PROVARCHIVO = dr.GetString(dr.GetOrdinal("MAE_TIP_PROVARCHIVO"));
                            lsCEntidad.DESCRIPCION_PROVARCHIVO = dr.GetString(dr.GetOrdinal("DESCRIPCION_PROVARCHIVO"));
                            lsCEntidad.MAE_TIP_MEDIDAS = dr.GetString(dr.GetOrdinal("MAE_TIP_MEDIDAS"));
                            lsCEntidad.DESCRIPCION_MEDIDAS = dr.GetString(dr.GetOrdinal("DESCRIPCION_MEDIDAS"));
                            //11/05/2022
                            lsCEntidad.MAE_TIP_CONSTANCIA = dr.GetString(dr.GetOrdinal("MAE_TIP_CONSTANCIA"));

                            //30/10/2017
                            var cMCorrectiva = dr["CUMPLE_MCORRECTIVA"];
                            lsCEntidad.CUMPLE_MCORRECTIVA = DBNull.Value.Equals(cMCorrectiva) == true ? lsCEntidad.CUMPLE_MCORRECTIVA : Convert.ToBoolean(cMCorrectiva);
                            lsCEntidad.FECHA_CUMPLE_MCORRECTIVA = dr.GetString(dr.GetOrdinal("FECHA_CUMPLE_MCORRECTIVA"));
                            lsCEntidad.DISPONE_CUMPLE_MCORRECTIVA = dr.GetString(dr.GetOrdinal("DISPONE_CUMPLE_MCORRECTIVA"));
                            lsCEntidad.FECHA_FIRMEZA = dr.GetString(dr.GetOrdinal("FECHA_FIRMEZA"));
                            //11/12/2017
                            lsCEntidad.COD_DLINEA = dr.GetString(dr.GetOrdinal("COD_DLINEA"));
                            lsCEntidad.RECOMIENDA_NUEVA_SUPERV = dr.GetBoolean(dr.GetOrdinal("RECOMIENDA_NUEVA_SUPERV"));
                            lsCEntidad.INCUMPLE_DIRECTIVA_SUPERV = dr.GetBoolean(dr.GetOrdinal("INCUMPLE_DIRECTIVA_SUPERV"));
                            //11/04/2018
                            lsCEntidad.MED_CAUTELAR = dr.GetBoolean(dr.GetOrdinal("MED_CAUTELAR"));
                            lsCEntidad.CADUCIDAD = dr.GetBoolean(dr.GetOrdinal("CADUCIDAD"));
                            lsCEntidad.INFRACCIONES = dr.GetBoolean(dr.GetOrdinal("INFRACCIONES"));
                            //04/06/2018
                            lsCEntidad.NUM_EXPPJ = dr.GetString(dr.GetOrdinal("NUM_EXPPJ"));
                            lsCEntidad.NUM_JUZGADO = dr.GetString(dr.GetOrdinal("NUM_JUZGADO"));
                            lsCEntidad.FECHA_PJ = dr.GetString(dr.GetOrdinal("FECHA_PJ"));
                            lsCEntidad.PLAZO_PJ = dr.GetString(dr.GetOrdinal("PLAZO_PJ"));
                            lsCEntidad.RESUM_PJ = dr.GetString(dr.GetOrdinal("MANDATO_PJ"));
                            //05/06/2018
                            lsCEntidad.PJ_PM = dr.GetBoolean(dr.GetOrdinal("PLAN_MANEJO"));
                            lsCEntidad.PJ_GTF = dr.GetBoolean(dr.GetOrdinal("GTF"));
                            lsCEntidad.PJ_TROZAS = dr.GetBoolean(dr.GetOrdinal("TROZAS"));

                            lsCEntidad.CADUCIDADPARCIAL = dr.GetBoolean(dr.GetOrdinal("CADUCIDADPARCIAL"));
                            lsCEntidad.OBSERVACIONES_TSC = dr.GetString(dr.GetOrdinal("OBSERVACIONES_TSC"));
                            lsCEntidad.NOTIFICA_AUTOR = dr.GetString(dr.GetOrdinal("NOTIFICA_AUTOR"));

                            //tramite SITD
                            lsCEntidad.DESTRAMENVIO = dr["cCodificacion"].ToString();
                            lsCEntidad.CODTRAMITEENVIO = dr["iCodTramite"].ToString();
                            lsCEntidad.CNRODOCUMENTOE = dr["cNroDocumento"].ToString();
                            lsCEntidad.FFECDOCUMENTOE = dr["fFecDocumento"].ToString();
                            lsCEntidad.CASUNTOE = dr["cAsunto"].ToString();
                            lsCEntidad.PDF_ID_TRAM_ENVIO = dr["PDF_TRAMITE_SITD_ENVIO"].ToString();

                            //lsCEntidad.ESMANDATO = Convert.ToInt32(dr.GetBoolean(dr.GetOrdinal("ESMANDATO")));
                            //lsCEntidad.MANDATO = dr.GetString(dr.GetOrdinal("MANDATO"));
                            //lsCEntidad.CANTMESES = dr.GetInt32(dr.GetOrdinal("CANT_MESES"));
                            //lsCEntidad.CANTDIAS = dr.GetInt32(dr.GetOrdinal("CANT_DIAS"));

                            //TGS 07.10.2022: Subsanación voluntaria
                            lsCEntidad.SUBSANACION_VOLUNTARIA = dr.GetBoolean(dr.GetOrdinal("SUBSANACION_VOLUNTARIA"));
                            lsCEntidad.DESCRIPCION_SUBSANACION_VOLUNTARIA = dr.GetString(dr.GetOrdinal("DESCRIPCION_SUBSANACION_VOLUNTARIA"));
                        }
                        //Estado (Calidad)
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_ESTADO_DOC = dr.GetString(dr.GetOrdinal("COD_ESTADO_DOC"));
                            lsCEntidad.OBSERVACIONES_CONTROL = dr.GetString(dr.GetOrdinal("OBSERVACIONES_CONTROL"));
                            lsCEntidad.OBSERV_SUBSANAR = dr.GetBoolean(dr.GetOrdinal("OBSERV_SUBSANAR"));
                            lsCEntidad.USUARIO_CONTROL = dr.GetString(dr.GetOrdinal("USUARIO_CONTROL"));
                        }
                        else
                        {
                            lsCEntidad.COD_ESTADO_DOC = "";
                            lsCEntidad.OBSERVACIONES_CONTROL = "";
                            lsCEntidad.OBSERV_SUBSANAR = false;
                            lsCEntidad.USUARIO_CONTROL = "";
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt2 = new CEntidad();
                                ocampoEnt2.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampoEnt2.NUMERO = dr["NUMERO"].ToString();
                                ocampoEnt2.D_LINEA = dr["D_LINEA"].ToString();
                                ocampoEnt2.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                ocampoEnt2.TITULAR = dr["TITULAR"].ToString();
                                ocampoEnt2.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                ocampoEnt2.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
                                ocampoEnt2.RegEstado = 0;
                                lsCEntidad.ListInformes.Add(ocampoEnt2);
                            }
                        }
                        dr.NextResult();

                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_FUNCIONARIO");
                            int pt1 = dr.GetOrdinal("NOMBRE_FUNCIONARIO");
                            int pt2 = dr.GetOrdinal("COD_PROVEIDOARCH");
                            int pt3 = dr.GetOrdinal("CARGO");

                            while (dr.Read())
                            {
                                ocampoEnt2 = new CEntidad();
                                ocampoEnt2.COD_FUNCIONARIO = dr.GetString(pt0);
                                ocampoEnt2.NOMBRE_FUNCIONARIO = dr.GetString(pt1);
                                ocampoEnt2.COD_PROVEIDOARCH = dr.GetString(pt2);
                                ocampoEnt2.CARGO = dr.GetString(pt3);
                                ocampoEnt2.RegEstado = 0;
                                lsCEntidad.ListadoFuncionario.Add(ocampoEnt2);
                            }
                        }

                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt2 = new CEntidad();
                                ocampoEnt2.MANDATO = dr.GetString(dr.GetOrdinal("vMandato"));
                                ocampoEnt2.CANTMESES = dr.GetInt32(dr.GetOrdinal("CANTMESES"));
                                ocampoEnt2.CANTDIAS = dr.GetInt32(dr.GetOrdinal("CANTDIAS"));
                                ocampoEnt2.ICODMANDATO = dr.GetInt32(dr.GetOrdinal("iCodMandato"));
                                ocampoEnt2.RegEstado = 0;
                                lsCEntidad.ListMandatos.Add(ocampoEnt2);
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

        //public String GetData_ISUPERVISIONMedidas(SqlConnection cn, CEntidad oCEntidad)
        //{
        //    string sMedidas = "";

        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spGetData_ISUPERVISIONMedidas", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    dr.Read();
        //                    sMedidas = dr.GetString(dr.GetOrdinal("MEDIDAS"));
        //                }

        //            }
        //        }
        //        return sMedidas;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// metodo para la descarga de registros 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> RegistroUsuarios(OracleConnection cn, CEntidad oCEntidad)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.CR_FISCA_GENERAL_LISTAR", oCEntidad))
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
                                    sFila.Add(sColumn, dr[sColumn].ToString());
                                }
                                lstResult.Add(sFila);
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
    }
}
