using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using GeneralSQL;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting;
using CEntidadC = CapaEntidad.DOC.Ent_RESODIREC;
using SQL = GeneralSQL.Data.SQL;
using Tra_M_Tramite = CapaEntidad.DOC.Tra_M_Tramite;

namespace CapaDatos.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Dat_RESODIREC
    {
        private SQL oGDataSQL = new SQL();
        private DBOracle dBOracle = new DBOracle();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        /// 
        public String RegGrabarResodirec(OracleConnection cn, CEntidadC oCEntidad)
        {
            OracleTransaction tr = null;
            String OUTPUTPARAM01 = "";
            String OUTPUTPARAM02 = "";
            CEntidadC oCamposDet;

            try
            {
                tr = cn.BeginTransaction();

                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "doc_osinfor_erp_migracion.spRESODIREC_Grabar", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM01 = (String)cmd.Parameters["OUTPUTPARAM01"].Value;
                    OUTPUTPARAM02 = (String)cmd.Parameters["OUTPUTPARAM02"].Value;
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
                        throw new Exception("El Número del Resolución ya existe");
                    }
                    else if (OUTPUTPARAM01 == "1")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de Resolución Existe en otro Registro");
                    }
                    else if (OUTPUTPARAM01 == "2")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("No Tiene Permisos para Modificar esta Resolución Directoral");
                    }
                    else if (OUTPUTPARAM01 == "3")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("Está con Control de Calidad, no puede modificar");
                    }
                    else if (OUTPUTPARAM01 == "4")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de Expediente Administrativo no ha sido asignado");
                    }
                    else if (OUTPUTPARAM01 == "5")
                    {
                        tr.Rollback();
                        tr = null;
                        throw new Exception("El Número de Expediente Administrativo ya fue asignado a la " + OUTPUTPARAM02);
                    }
                }
                //Reemplazando El Nuevo Codigo Creado
                //String[] cadena = OUTPUTPARAM02.Split('|');
                if (oCEntidad.RegEstado == 1) //Nuevo
                {
                    oCEntidad.COD_RESODIREC = OUTPUTPARAM01;
                    oCEntidad.COD_RESODIREC_INI_PAU = OUTPUTPARAM02;
                }
                //
                //Eliminando Detalle
                if (oCEntidad.ListEliTABLA != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLA)
                    {
                        oCamposDet = new CEntidadC();
                        oCamposDet.CODIGO = OUTPUTPARAM01;
                        oCamposDet.COD_DETALLE = OUTPUTPARAM02;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        oCamposDet.EliVALOR02 = loDatos.EliVALOR02;
                        oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                        oCamposDet.COD_RESODIREC_INI_PAU = loDatos.COD_RESODIREC_INI_PAU;

                        oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                        oCamposDet.NUMERO_POA = loDatos.NUMERO_POA;
                        oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                        oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;

                        dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spResodirecEliminarDetalle", oCamposDet);
                    }
                }
                //Grabando Detalle Inicio PAU
                if (oCEntidad.ListarIniPAU != null)
                {
                    foreach (var loDatos in oCEntidad.ListarIniPAU)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidadC();
                            oCamposDet.COD_RESODIREC_INI_PAU = OUTPUTPARAM02;
                            oCamposDet.COD_RESODIREC = oCEntidad.COD_RESODIREC;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.COD_ILEGAL_ENCISOS = loDatos.COD_ILEGAL_ENCISOS;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.VOLUMEN = loDatos.VOLUMEN;
                            oCamposDet.AREA = loDatos.AREA;
                            oCamposDet.NUMERO_INDIVIDUOS = loDatos.NUMERO_INDIVIDUOS;
                            oCamposDet.NUM_POA = loDatos.NUM_POA;
                            oCamposDet.TIPOMADERABLE = loDatos.TIPOMADERABLE;
                            oCamposDet.DESCRIPCION_INFRACCIONES = loDatos.DESCRIPCION_INFRACCIONES;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            oCamposDet.PCA = loDatos.PCA;
                            dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spRESODIREC_DET_INI_PAUGrabar", oCamposDet);
                        }
                    }
                }
                //Motivos del Archivo de la RD de Término de PAU
                if (oCEntidad.MotivoArchivo != null)
                {
                    foreach (var loDatos in oCEntidad.MotivoArchivo)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidadC();
                            oCamposDet.COD_RESODIREC_INI_PAU = OUTPUTPARAM02;
                            oCamposDet.COD_RESODIREC = oCEntidad.COD_RESODIREC;
                            oCamposDet.COD_RESODIREC_ARCHIVO_PAU_SUB = loDatos.CODIGO;
                            oCamposDet.DESCRIPCIONMOTIVO = loDatos.DESCRIPCIONMOTIVO;
                            oCamposDet.RegEstado = 1;
                            dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.RESODIREC_DET_ARCHIVO_PAUGrabar", oCamposDet);
                        }
                    }
                }
                // Creando la lista de informes
                if (oCEntidad.ListInformes != null)
                {
                    foreach (var loDatos in oCEntidad.ListInformes)
                    {
                        if (loDatos.RegEstado == 1) //Nuevo
                        {
                            oCamposDet = new CEntidadC();
                            //
                            if (loDatos.COD_RESODIREC != null && loDatos.COD_RESODIREC_INI_PAU != null)
                            {
                                oCamposDet.RESOLUCION_COD_RESODIREC = OUTPUTPARAM01;
                                oCamposDet.COD_RESODIREC_INI_PAU = loDatos.COD_RESODIREC_INI_PAU;
                                oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                                dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spRESODIREC_VS_INI_PAUGrabar", oCamposDet);
                            }
                            else if (loDatos.COD_INFORME != null)
                            {
                                oCamposDet.COD_RESODIREC = oCEntidad.COD_RESODIREC;
                                oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                                dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spRESODIREC_DET_INFORME_Grabar", oCamposDet);
                            }
                        }
                    }

                }
                //Creando la lista de titulares
                if (oCEntidad.ListTitulares != null)
                {
                    foreach (var loDatos in oCEntidad.ListTitulares)
                    {
                        if (loDatos.RegEstado == 1) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidadC();
                            oCamposDet.COD_RESODIREC = OUTPUTPARAM01;
                            oCamposDet.COD_PERSONA = loDatos.CODIGO;
                            dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spRESODIREC_DET_TITULARES", oCamposDet);
                        }
                    }
                }
                //modificando la tabla RESODIREC_DET_INI_PAU
                if (oCEntidad.ListLiterales != null)
                {
                    foreach (var loDatos in oCEntidad.ListLiterales)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidadC();
                            oCamposDet.COD_RESODIREC = OUTPUTPARAM01;

                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.VOLUMEN = loDatos.VOLUMEN;
                            oCamposDet.AREA = loDatos.AREA;
                            oCamposDet.NUMERO_INDIVIDUOS = loDatos.NUMERO_INDIVIDUOS;

                            oCamposDet.DETERMINACION = loDatos.DETERMINACION;
                            oCamposDet.DESCRIPCION_INFRACCIONES = loDatos.DESCRIPCION_INFRACCIONES;
                            dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spRESODIREC_UPDATE_RECONSIDERA", oCamposDet);
                        }
                    }
                }
                // para hacer las actualizaciones de la RD de rectificacion
                if (oCEntidad.ListRD_Rectificar != null)
                {
                    if (oCEntidad.ListRD_Rectificar.Count > 0)
                    {
                        foreach (var loDatos in oCEntidad.ListRD_Rectificar)
                        {
                            CEntidadC oCENtidadTemp = new CEntidadC();
                            if ((Boolean)oCEntidad.NOM_TITULAR == true && oCEntidad.ListTitularRectificar != null)
                            {
                                if (oCEntidad.ListTitularRectificar.Count > 0)
                                {
                                    oCENtidadTemp.BusFormulario = "UPDATE_NOMBRE_TITULAR";
                                    oCENtidadTemp.BusCriterio = OUTPUTPARAM01;
                                    oCENtidadTemp.BusValor = oCEntidad.ListTitularRectificar[0].COD_TITULAR;
                                    oCENtidadTemp.AP_PATERNO = oCEntidad.ListTitularRectificar[0].AP_PATERNO;
                                    oCENtidadTemp.AP_MATERNO = oCEntidad.ListTitularRectificar[0].AP_MATERNO;
                                    oCENtidadTemp.NOMBRES = oCEntidad.ListTitularRectificar[0].NOMBRES;
                                    oCENtidadTemp.RAZON_SOCIAL = oCEntidad.ListTitularRectificar[0].RAZON_SOCIAL;

                                    if (oCEntidad.ListTitularRectificar[0].TIPO_PERSONA == "N")
                                    {
                                        oCENtidadTemp.APELLIDOS_NOMBRES = oCENtidadTemp.AP_PATERNO + " " + oCENtidadTemp.AP_MATERNO + " " + oCENtidadTemp.NOMBRES;
                                    }
                                    else
                                    {
                                        oCENtidadTemp.APELLIDOS_NOMBRES = oCENtidadTemp.RAZON_SOCIAL;
                                    }
                                    dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spRESODIREC_RectificarUpdate", oCENtidadTemp);
                                }
                            }
                            if ((Boolean)oCEntidad.NUM_TITULO == true && oCEntidad.DESC_NUM_TIT != "")
                            {
                                oCENtidadTemp.BusFormulario = "UPDATE_NUMERO_TITULO";
                                oCENtidadTemp.BusCriterio = oCEntidad.DESC_NUM_TIT;
                                oCENtidadTemp.BusValor = loDatos.CODIGO;
                                dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spRESODIREC_RectificarUpdate", oCENtidadTemp);
                            }
                            if ((Boolean)oCEntidad.NUM_EXP == true && oCEntidad.DESC_NUM_EXPE != "")
                            {
                                oCENtidadTemp.BusFormulario = "UPDATE_NUM_EXP";
                                oCENtidadTemp.BusCriterio = oCEntidad.DESC_NUM_EXPE;
                                oCENtidadTemp.BusValor = loDatos.COD_RESODIREC_INI_PAU;
                                dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spRESODIREC_RectificarUpdate", oCENtidadTemp);
                            }
                            if ((Boolean)oCEntidad.FECHA_EMISION1 == true && oCEntidad.DESC_FECHA.ToString() != "")
                            {
                                oCENtidadTemp.BusFormulario = "UPDATE_RESODIREC_FECHA";
                                oCENtidadTemp.BusCriterio = oCEntidad.DESC_FECHA.ToString();
                                oCENtidadTemp.BusValor = loDatos.COD_RESODIREC;
                                dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spRESODIREC_RectificarUpdate", oCENtidadTemp);
                            }
                            if ((Boolean)oCEntidad.ESPECIES == true && oCEntidad.ListEspeciesError.Count > 0)
                            {
                                for (int i = 0; i < oCEntidad.ListEspeciesError.Count; i++)
                                {
                                    oCENtidadTemp = oCEntidad.ListEspeciesError[i];
                                    if (oCENtidadTemp.BusValor != null)
                                    {
                                        oCENtidadTemp.BusFormulario = "UPDATE_RESODIREC_ESPECIE";
                                        oCENtidadTemp.BusCriterio = OUTPUTPARAM01;
                                        oCENtidadTemp.DESCRIPCION = null;
                                        oCENtidadTemp.BTN_LITERALES = null;
                                        oCENtidadTemp.BTN_LITERALES2 = null;
                                        dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spRESODIREC_RectificarUpdate", oCENtidadTemp);

                                    }
                                }
                            }
                        }
                    }
                }
                if (oCEntidad.ListTHabilitanteQuinquenal != null)
                {
                    if (oCEntidad.ListTHabilitanteQuinquenal.Count > 0)
                    {
                        foreach (var loDatos in oCEntidad.ListTHabilitanteQuinquenal)
                        {
                            if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.COD_RESODIREC = OUTPUTPARAM01;
                                oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE; // cod_rd de termino
                                oCamposDet.NUM_POA = loDatos.NUM_POA;
                                oCamposDet.BusFormulario = "RESODIREC_THABILITANTE_GRABAR";
                                dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spRESODIREC_THABILITANTE", oCamposDet);
                            }
                        }
                    }
                }
                if (oCEntidad.ListQuinquenalSupervisor != null)
                {
                    if (oCEntidad.ListQuinquenalSupervisor.Count > 0)
                    {
                        foreach (var loDatos in oCEntidad.ListQuinquenalSupervisor)
                        {
                            if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.COD_RESODIREC = OUTPUTPARAM01;
                                oCamposDet.CODIGO = loDatos.CODIGO; // cod_rd de termino
                                oCamposDet.DESCRIPCION = loDatos.DESCRIPCION_OTROS;
                                oCamposDet.BusFormulario = "RESODIREC_SUPERVISOR_GRABAR";
                                dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spRESODIREC_THABILITANTE", oCamposDet);
                            }
                        }
                    }
                }
                if (oCEntidad.ListQuinquenalMuestra != null)
                {
                    if (oCEntidad.ListQuinquenalMuestra.Count > 0)
                    {
                        foreach (var loDatos in oCEntidad.ListQuinquenalMuestra)
                        {
                            if (loDatos.RegEstado == 1)
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                                oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                                oCamposDet.NUM_POA = loDatos.NUM_POA;
                                oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                                oCamposDet.MUESTRA_QUIN = loDatos.MUESTRA_QUIN;
                                oCamposDet.BusFormulario = "RESODIREC_MUESTRA_GRABAR";
                                dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spRESODIREC_THABILITANTE", oCamposDet);
                            }
                        }
                    }
                }
                //Especies medidas precautorios o cautelares
                if (oCEntidad.ListEspeciesMedidas != null)
                {
                    if (oCEntidad.ListEspeciesMedidas.Count > 0)
                    {
                        foreach (var loDatos in oCEntidad.ListEspeciesMedidas)
                        {
                            if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.COD_RESODIREC = oCEntidad.COD_RESODIREC;
                                oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                                oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                                oCamposDet.NUM_POA = loDatos.NUM_POA;
                                oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                                oCamposDet.RegEstado = loDatos.RegEstado;
                                dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spRESODIREC_MED_ESPECIESGrabar", oCamposDet);
                            }
                        }
                    }
                }
                //Grabar la información adicional por POA
                if (oCEntidad.ListPOAs != null)
                {
                    if (oCEntidad.ListPOAs.Count > 0)
                    {
                        foreach (var loDatos in oCEntidad.ListPOAs)
                        {
                            oCamposDet = new CEntidadC();
                            oCamposDet.COD_RESODIREC = oCEntidad.COD_RESODIREC;
                            oCamposDet.NUM_POA = loDatos.NUM_POA;
                            oCamposDet.PUBLICAR = loDatos.PUBLICAR;
                            oCamposDet.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spRESODIREC_INFO_DOCUMENT_Grabar", oCamposDet);
                        }
                    }
                }
                /*
                 * Grabar especies de la alerta 23/05/2019
                 * 
                 */
                if (oCEntidad.ListBEXT != null)
                {
                    if (oCEntidad.ListBEXT.Count > 0)
                    {
                        foreach (var loDatos in oCEntidad.ListBEXT)
                        {
                            oCamposDet = new CEntidadC();
                            oCamposDet.COD_RESODIREC = oCEntidad.COD_RESODIREC;
                            oCamposDet.COD_INFORME = loDatos.COD_INFORME;
                            oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
                            oCamposDet.NUMERO_POA = loDatos.NUMERO_POA;
                            oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
                            oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
                            oCamposDet.RegEstado = loDatos.RegEstado;
                            dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spBITACORA_BX_GRABAR_RD", oCamposDet);
                        }
                    }
                }
                //MANDATOS
                if (oCEntidad.ListMandatos != null)
                {
                    Ent_RESODIREC_MEDIDA oMandato;

                    foreach (var loDatos in oCEntidad.ListMandatos)
                    {
                        if (loDatos.RegEstado == 1)
                        {
                            oMandato = new Ent_RESODIREC_MEDIDA();
                            oMandato.COD_RESODIREC = OUTPUTPARAM01;
                            oMandato.COD_MEDIDA = loDatos.COD_MEDIDA;
                            oMandato.MEDIDA = loDatos.MEDIDA;
                            oMandato.MAE_TIP_MEDIDA = loDatos.MAE_TIP_MEDIDA;
                            oMandato.PLAZO_IMPL_DIA = loDatos.PLAZO_IMPL_DIA;
                            oMandato.PLAZO_IMPL_MES = loDatos.PLAZO_IMPL_MES;
                            oMandato.PLAZO_INF_DIA = loDatos.PLAZO_INF_DIA;
                            oMandato.PLAZO_INF_MES = loDatos.PLAZO_INF_MES;
                            oMandato.PLAZO_IMPL_ANIO = 0;
                            oMandato.PLAZO_INF_ANIO = 0;
                            oMandato.PLAZO_POST_ANIO = 0;
                            oMandato.PLAZO_POST_DIA = 0;
                            oMandato.PLAZO_POST_MES = 0;
                            oMandato.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                            dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spRESODIREC_DET_MEDIDA_Grabar", oMandato);
                        }
                    }
                }
                //MEDIDAS CORRECTIVAS
                if (oCEntidad.ListMedidasCorrectivas != null)
                {
                    Ent_RESODIREC_MEDIDA oMCorrectiva;

                    foreach (var loDatos in oCEntidad.ListMedidasCorrectivas)
                    {

                        oMCorrectiva = new Ent_RESODIREC_MEDIDA();
                        oMCorrectiva.COD_RESODIREC = OUTPUTPARAM01;
                        oMCorrectiva.COD_MEDIDA = loDatos.COD_MEDIDA;
                        oMCorrectiva.MEDIDA = loDatos.MEDIDA;
                        oMCorrectiva.MAE_TIP_MEDIDA = loDatos.MAE_TIP_MEDIDA;
                        oMCorrectiva.PLAZO_IMPL_ANIO = loDatos.PLAZO_IMPL_ANIO;
                        oMCorrectiva.PLAZO_IMPL_DIA = loDatos.PLAZO_IMPL_DIA;
                        oMCorrectiva.PLAZO_IMPL_MES = loDatos.PLAZO_IMPL_MES;
                        oMCorrectiva.PLAZO_INF_ANIO = loDatos.PLAZO_INF_ANIO;
                        oMCorrectiva.PLAZO_INF_DIA = loDatos.PLAZO_INF_DIA;
                        oMCorrectiva.PLAZO_INF_MES = loDatos.PLAZO_INF_MES;
                        oMCorrectiva.PLAZO_POST_ANIO = loDatos.PLAZO_POST_ANIO;
                        oMCorrectiva.PLAZO_POST_DIA = loDatos.PLAZO_POST_DIA;
                        oMCorrectiva.PLAZO_POST_MES = loDatos.PLAZO_POST_MES;
                        oMCorrectiva.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                        if (loDatos.RegEstado == 1)
                        {

                            using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "doc_osinfor_erp_migracion.spRESODIREC_DET_MEDIDA_Grabar", oMCorrectiva))
                            {
                                cmd.ExecuteNonQuery();
                                oMCorrectiva.COD_MEDIDA = Convert.ToInt32(cmd.Parameters["COD_MEDIDA"].Value);
                            }
                        }
                        //Especies medidas correctivas
                        if (loDatos.ListEspeciesMCorrectiva != null)
                        {
                            if (loDatos.ListEspeciesMCorrectiva.Count > 0)
                            {
                                Ent_RESODIREC_MEDIDA_ESPECIE oEspecie;

                                foreach (var loDatosEspecie in loDatos.ListEspeciesMCorrectiva)
                                {
                                    if (loDatosEspecie.RegEstado == 1 || loDatosEspecie.RegEstado == 2) //Nuevo o Modificado
                                    {
                                        oEspecie = new Ent_RESODIREC_MEDIDA_ESPECIE();
                                        oEspecie.COD_RESODIREC = OUTPUTPARAM01;
                                        oEspecie.COD_MEDIDA = oMCorrectiva.COD_MEDIDA;
                                        oEspecie.COD_SECUENCIAL = loDatosEspecie.COD_SECUENCIAL;
                                        oEspecie.COD_ESPECIES = loDatosEspecie.COD_ESPECIES;
                                        oEspecie.ESPECIES = loDatosEspecie.ESPECIES;
                                        oEspecie.VOLUMEN_MOVILIZADO = loDatosEspecie.VOLUMEN_MOVILIZADO;
                                        oEspecie.NUMERO_INDIVIDUOS = loDatosEspecie.NUMERO_INDIVIDUOS;
                                        oEspecie.OBSERVACION = loDatosEspecie.OBSERVACION;
                                        oEspecie.COD_UCUENTA = oCEntidad.COD_UCUENTA;
                                        oEspecie.RegEstado = loDatosEspecie.RegEstado;
                                        dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spRESODIREC_MEDIDA_ESPECIES_Grabar", oEspecie);
                                    }
                                }
                            }
                        }

                    }
                }

                //agregando los registros de expediente de accion 08.09.2021 CARR
                if (oCEntidad.listSTD01 != null)
                {
                    foreach (var loDatos in oCEntidad.listSTD01)
                    {
                        if (loDatos.RegEstado == 1) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidadC();
                            oCamposDet.COD_RESODIREC = OUTPUTPARAM01;
                            oCamposDet.CODIGO = loDatos.CODIGO;
                            oCamposDet.NUMERO = loDatos.NUMERO;
                            oCamposDet.PDF_DOCUMENTO = loDatos.PDF_DOCUMENTO;
                            oCamposDet.TIPO_DOCUMENTO = loDatos.TIPO_DOCUMENTO;
                            oCamposDet.SUBTIPO = "01";
                            oCamposDet.RegEstado = 1;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.RESODIREC_DET_ACCIONGrabar", oCamposDet);
                        }
                    }
                }
                if (oCEntidad.listSTD02 != null)
                {
                    foreach (var loDatos in oCEntidad.listSTD02)
                    {
                        if (loDatos.RegEstado == 1 || loDatos.RegEstado == 2) //Nuevo o Modificado
                        {
                            oCamposDet = new CEntidadC();
                            oCamposDet.COD_RESODIREC = OUTPUTPARAM01;
                            oCamposDet.CODIGO = loDatos.CODIGO;
                            oCamposDet.NUMERO = loDatos.NUMERO;
                            oCamposDet.PDF_DOCUMENTO = loDatos.PDF_DOCUMENTO;
                            oCamposDet.TIPO_DOCUMENTO = loDatos.TIPO_DOCUMENTO;
                            oCamposDet.SUBTIPO = "02";
                            oCamposDet.RegEstado = 1;
                            dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.RESODIREC_DET_ACCIONGrabar", oCamposDet);
                        }
                    }
                }

                //ELIMINADO EXPEDIENTE
                if (oCEntidad.listEliTSTD01 != null)
                {
                    foreach (var loDatos in oCEntidad.listEliTSTD01)
                    {
                        oCamposDet = new CEntidadC();
                        oCamposDet.CODIGO = OUTPUTPARAM01;
                        oCamposDet.EliTABLA = loDatos.EliTABLA;
                        oCamposDet.EliVALOR01 = loDatos.EliVALOR01;
                        dBOracle.ManExecute(cn, tr, "doc_osinfor_erp_migracion.spResodirecEliminarDetalle", oCamposDet);
                    }
                }

                //Grabando detalle Infracciones Subsanadas
                if (oCEntidad.ListIncisos != null)
                {
                    foreach (var loDatos in oCEntidad.ListIncisos)
                    {
                        oCamposDet = new CEntidadC();
                        oCamposDet.COD_RESODIREC = OUTPUTPARAM01;
                        oCamposDet.COD_ENCISOS = loDatos.COD_ENCISOS;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spRESODIREC_DET_INFRACCION_Grabar", oCamposDet);
                    }
                }

                //Eliminando detalle Infracciones Subsanadas
                if (oCEntidad.ListEliTABLAIncisos != null)
                {
                    foreach (var loDatos in oCEntidad.ListEliTABLAIncisos)
                    {
                        oCamposDet = new CEntidadC();
                        oCamposDet.COD_RESODIREC_DET_INFRACCION = loDatos.COD_RESODIREC_DET_INFRACCION;
                        oCamposDet.COD_RESODIREC = loDatos.COD_RESODIREC;
                        oCamposDet.COD_ENCISOS = loDatos.COD_ENCISOS;
                        oCamposDet.ESTADO = loDatos.ESTADO;
                        oCamposDet.RegEstado = loDatos.RegEstado;
                        dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.spRESODIREC_DET_INFRACCION_Grabar", oCamposDet);
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


        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidadC RegMostrariNFORME_Buscar(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<CEntidadC> lsCEntidad = new List<CEntidadC>();
            CEntidadC busqueda = new CEntidadC();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.spGeneral_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            CEntidadC oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidadC();
                                oCampos.COD_INFORME = dr["COD_INFORME"].ToString();
                                oCampos.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                oCampos.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
                                oCampos.NUMERO = dr["NUMERO"].ToString();
                                oCampos.D_LINEA = dr["D_LINEA"].ToString();
                                oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.COD_MTIPO = dr["COD_MTIPO"].ToString();
                                oCampos.NUMERO_EXPEDIENTE = dr["NUM_EXPSITD"].ToString();
                                //oCampos.NUMERO_SUP = dr["NUMERO_SUP"].ToString();
                                lsCEntidad.Add(oCampos);
                            }
                        }
                    }
                    dr.NextResult();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            busqueda.v_ROW_INDEX = Int32.Parse(dr["TOTALROW"].ToString());
                        }
                    }
                }
                busqueda.ListInformes = lsCEntidad;
                return busqueda;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<CEntidadC> RegMostrariNFORME_Buscar_2(SqlConnection cn, CEntidadC oCEntidad)
        //{
        //    List<CEntidadC> lsCEntidad = new List<CEntidadC>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spGeneral_Listar_2", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    CEntidadC oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidadC();
        //                        oCampos.COD_INFORME = dr["COD_INFORME"].ToString();
        //                        oCampos.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
        //                        oCampos.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
        //                        oCampos.NUMERO = dr["NUMERO"].ToString();
        //                        oCampos.D_LINEA = dr["D_LINEA"].ToString();
        //                        oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
        //                        oCampos.TITULAR = dr["TITULAR"].ToString();
        //                        oCampos.COD_MTIPO = dr["COD_MTIPO"].ToString();
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
        public CEntidadC RegMostrarListaResoDirecItem(OracleConnection cn, CEntidadC oCEntidad)
        {
            CEntidadC lsCEntidad = new CEntidadC();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRESODIRECMostrarItems", oCEntidad))
                {
                    if (dr != null)
                    {
                        lsCEntidad.ListInformes = new List<CEntidadC>();
                        lsCEntidad.ListarIniPAU = new List<CEntidadC>();
                        lsCEntidad.ListPOAs = new List<CEntidadC>();
                        lsCEntidad.MotivoArchivo = new List<CEntidadC>();
                        lsCEntidad.ListTitulares = new List<CEntidadC>();
                        lsCEntidad.ListEliTABLA = new List<CEntidadC>();
                        lsCEntidad.ListLiterales = new List<CEntidadC>();
                        lsCEntidad.ListTHabilitanteQuinquenal = new List<CEntidadC>();
                        lsCEntidad.ListQuinquenalSupervisor = new List<CEntidadC>();
                        //lsCEntidad.ListEspeciesMCorrectiva = new List<CEntidadC>();
                        lsCEntidad.ListEspeciesMedidas = new List<CEntidadC>();
                        lsCEntidad.ListBEXT = new List<CEntidadC>();
                        lsCEntidad.ListMandatos = new List<Ent_RESODIREC_MEDIDA>();
                        lsCEntidad.ListMedidasCorrectivas = new List<Ent_RESODIREC_MEDIDA>();

                        lsCEntidad.listSTD01 = new List<CEntidadC>();
                        lsCEntidad.listSTD02 = new List<CEntidadC>();
                        lsCEntidad.ListIncisos = new List<CEntidadC>();

                        CEntidadC ocampoEnt;

                        if (dr.HasRows)
                        {
                            dr.Read();
                            lsCEntidad.COD_FCTIPO = dr.GetString(dr.GetOrdinal("COD_FCTIPO"));
                            lsCEntidad.TIPO_FISCALIZA = dr.GetString(dr.GetOrdinal("TIPO_FISCALIZA"));
                            if (dr["NUMERO_RESOLUCION"] != DBNull.Value) lsCEntidad.NUMERO_RESOLUCION = dr.GetString(dr.GetOrdinal("NUMERO_RESOLUCION"));
                            lsCEntidad.COD_PERSONA = dr.GetString(dr.GetOrdinal("COD_PERSONA"));
                            lsCEntidad.APELLIDOS_NOMBRES = dr.GetString(dr.GetOrdinal("APELLIDOS_NOMBRES"));
                            lsCEntidad.FECHA_EMISION = dr.GetString(dr.GetOrdinal("FECHA_EMISION"));
                            lsCEntidad.FECHA_ANULACION = dr.GetString(dr.GetOrdinal("FECHA_ANULACION"));
                            lsCEntidad.NUMERO_EXPEDIENTE = dr.GetString(dr.GetOrdinal("NUMERO_EXPEDIENTE"));
                            lsCEntidad.SOLICITUD_ANTECEDENTES = dr.GetBoolean(dr.GetOrdinal("SOLICITUD_ANTECEDENTES"));
                            lsCEntidad.MEDIDAS_CAUTELARES = dr.GetBoolean(dr.GetOrdinal("MEDIDAS_CAUTELARES"));
                            //modificacion de la R.D. 08/01/2016
                            lsCEntidad.MED_CAUT_GTF = dr.GetBoolean(dr.GetOrdinal("MED_CAUT_GTF"));
                            lsCEntidad.MED_CAUT_LIST_TROZA = dr.GetBoolean(dr.GetOrdinal("MED_CAUT_LIST_TROZA"));
                            lsCEntidad.MED_CAUT_PM = dr.GetBoolean(dr.GetOrdinal("MED_CAUT_PM"));
                            lsCEntidad.MED_CAUT_POA = dr.GetBoolean(dr.GetOrdinal("MED_CAUT_POA"));
                            lsCEntidad.SOLICITUD_BALANCE = dr.GetBoolean(dr.GetOrdinal("SOLICITUD_BALANCE"));
                            lsCEntidad.DESCRIPCION_MEDIDAS_PAU = dr.GetString(dr.GetOrdinal("DESCRIPCION_MEDIDAS_PAU"));
                            lsCEntidad.MULTA = dr.GetBoolean(dr.GetOrdinal("MULTA"));
                            lsCEntidad.MONTO = dr.GetDecimal(dr.GetOrdinal("MONTO"));
                            lsCEntidad.CADUCIDAD = dr.GetBoolean(dr.GetOrdinal("CADUCIDAD"));
                            if (lsCEntidad.COD_FCTIPO == "0000014")
                            {
                                lsCEntidad.MEDIDAS_CORRECTIVAS = dr.GetBoolean(dr.GetOrdinal("VARIA_MCORRECTIVAS"));
                                lsCEntidad.DESCRIPCION_MED_CORRECTIVAS = dr.GetString(dr.GetOrdinal("DESCRIPCION_VARIA_MCORRECTIVAS"));
                            }
                            else
                            {
                                lsCEntidad.MEDIDAS_CORRECTIVAS = dr.GetBoolean(dr.GetOrdinal("MEDIDAS_CORRECTIVAS"));
                                //lsCEntidad.DESCRIPCION_MED_CORRECTIVAS = dr.GetString(dr.GetOrdinal("DESCRIPCION_MED_CORRECTIVAS"));
                            }

                            //lsCEntidad.DIA_IMPLEMENT_MCORRECTIVA = dr.GetInt32(dr.GetOrdinal("DIA_IMPLEMENT_MCORRECTIVA"));
                            //lsCEntidad.MES_IMPLEMENT_MCORRECTIVA = dr.GetInt32(dr.GetOrdinal("MES_IMPLEMENT_MCORRECTIVA"));
                            //lsCEntidad.ANIO_IMPLEMENT_MCORRECTIVA = dr.GetInt32(dr.GetOrdinal("ANIO_IMPLEMENT_MCORRECTIVA"));
                            //lsCEntidad.DIA_INFORME_MCORRECTIVA = dr.GetInt32(dr.GetOrdinal("DIA_INFORME_MCORRECTIVA"));
                            //lsCEntidad.MES_INFORME_MCORRECTIVA = dr.GetInt32(dr.GetOrdinal("MES_INFORME_MCORRECTIVA"));
                            //lsCEntidad.ANIO_INFORME_MCORRECTIVA = dr.GetInt32(dr.GetOrdinal("ANIO_INFORME_MCORRECTIVA"));

                            lsCEntidad.COD_RESODIREC_GRAVEDAD = dr.GetString(dr.GetOrdinal("COD_RESODIREC_GRAVEDAD"));
                            lsCEntidad.CAUSALES_CADUCIDAD = dr.GetBoolean(dr.GetOrdinal("CAUSALES_CADUCIDAD"));
                            lsCEntidad.DGFFS = dr.GetBoolean(dr.GetOrdinal("DGFFS"));
                            lsCEntidad.PROGRAMA_REGIONAL = dr.GetBoolean(dr.GetOrdinal("PROGRAMA_REGIONAL"));
                            lsCEntidad.MINISTERIO_PUBLICO = dr.GetBoolean(dr.GetOrdinal("MINISTERIO_PUBLICO"));
                            lsCEntidad.COLEGIO_INGENIEROS = dr.GetBoolean(dr.GetOrdinal("COLEGIO_INGENIEROS"));
                            lsCEntidad.ATFFS = dr.GetBoolean(dr.GetOrdinal("ATFFS"));
                            lsCEntidad.OCI = dr.GetBoolean(dr.GetOrdinal("OCI"));
                            lsCEntidad.OEFA = dr.GetBoolean(dr.GetOrdinal("OEFA"));
                            lsCEntidad.SUNAT = dr.GetBoolean(dr.GetOrdinal("SUNAT"));
                            lsCEntidad.SERFOR = dr.GetBoolean(dr.GetOrdinal("SERFOR"));
                            lsCEntidad.OTROS = dr.GetBoolean(dr.GetOrdinal("OTROS"));
                            //lsCEntidad.TIPO = dr.GetString(dr.GetOrdinal("TIPO"));
                            //cambios de la RD agregando Ministerio de Enenrgi y Minas
                            lsCEntidad.MIN_ENERGIA_MINAS = dr.GetBoolean(dr.GetOrdinal("MIN_ENERGIA_MINAS"));
                            lsCEntidad.DETALLE_MINENMIN = dr.GetString(dr.GetOrdinal("DETALLE_MINENMIN"));
                            lsCEntidad.DETALLE_ATFFS = dr.GetString(dr.GetOrdinal("DETALLE_ATFFS"));
                            lsCEntidad.DETALLE_COLING = dr.GetString(dr.GetOrdinal("DETALLE_COLING"));
                            lsCEntidad.DETALLE_DGFFS = dr.GetString(dr.GetOrdinal("DETALLE_DGFFS"));
                            lsCEntidad.DETALLE_MINPUB = dr.GetString(dr.GetOrdinal("DETALLE_MINPUB"));
                            lsCEntidad.DETALLE_OCI = dr.GetString(dr.GetOrdinal("DETALLE_OCI"));
                            lsCEntidad.DETALLE_OEFA = dr.GetString(dr.GetOrdinal("DETALLE_OEFA"));
                            lsCEntidad.DETALLE_OTROS = dr.GetString(dr.GetOrdinal("DETALLE_OTROS"));
                            lsCEntidad.DETALLE_PROREG = dr.GetString(dr.GetOrdinal("DETALLE_PROREG"));
                            lsCEntidad.DETALLE_SERFOR = dr.GetString(dr.GetOrdinal("DETALLE_SERFOR"));
                            lsCEntidad.DETALLE_SUNAT = dr.GetString(dr.GetOrdinal("DETALLE_SUNAT"));
                            lsCEntidad.DESCRIPCION = dr.GetString(dr.GetOrdinal("DESCRIPCION"));
                            lsCEntidad.COD_RESUDIREC_PAU_FIN_TIPO = dr.GetString(dr.GetOrdinal("COD_RESUDIREC_PAU_FIN_TIPO"));

                            lsCEntidad.EXPEDIENTE_ADMINISTRATIVO_ASIGNADO = dr.GetString(dr.GetOrdinal("EXPEDIENTE_ADMINISTRATIVO_ASIGNADO"));
                            lsCEntidad.EVIDENCIA_IRREGULARIDAD = dr.GetBoolean(dr.GetOrdinal("EVIDENCIA_IRREGULARIDAD"));
                            lsCEntidad.BUEN_MANEJO = dr.GetBoolean(dr.GetOrdinal("BUEN_MANEJO"));
                            lsCEntidad.SIN_INFRACCION = dr.GetBoolean(dr.GetOrdinal("SIN_INFRACCION"));
                            lsCEntidad.DEFICIENTE_NOTIFICACION = dr.GetBoolean(dr.GetOrdinal("DEFICIENTE_NOTIFICACION"));
                            lsCEntidad.DEFICIENCIA_TECNICA = dr.GetBoolean(dr.GetOrdinal("DEFICIENCIA_TECNICA"));
                            lsCEntidad.OTROS_arch = dr.GetString(dr.GetOrdinal("OTROS_arch"));

                            lsCEntidad.ERROR_MATERIAL = dr.GetBoolean(dr.GetOrdinal("ERROR_MATERIAL"));
                            lsCEntidad.OTROS_RECTIFICACION = dr.GetBoolean(dr.GetOrdinal("OTROS_RECTIFICACION"));
                            lsCEntidad.TEXTO_RECTIFICACION = dr.GetString(dr.GetOrdinal("TEXTO_RECTIFICACION"));

                            //CAMBIOS DE LA RD PARA LA RECTIFICACION 
                            lsCEntidad.NOM_TITULAR = dr.GetBoolean(dr.GetOrdinal("NOM_TITULAR"));
                            lsCEntidad.DESC_NOM_TIT = dr.GetString(dr.GetOrdinal("DESC_NOM_TIT"));
                            lsCEntidad.NUM_TITULO = dr.GetBoolean(dr.GetOrdinal("NUM_TITULO"));
                            lsCEntidad.DESC_NUM_TIT = dr.GetString(dr.GetOrdinal("DESC_NUM_TIT"));
                            lsCEntidad.NUM_EXP = dr.GetBoolean(dr.GetOrdinal("NUM_EXP"));
                            lsCEntidad.DESC_NUM_EXPE = dr.GetString(dr.GetOrdinal("DESC_NUM_EXPE"));
                            lsCEntidad.FECHA_EMISION1 = dr.GetBoolean(dr.GetOrdinal("CAMBIO_FECHA"));
                            lsCEntidad.DESC_FECHA = dr.GetString(dr.GetOrdinal("DESC_FECHA"));
                            lsCEntidad.ESPECIES = dr.GetBoolean(dr.GetOrdinal("ESPECIES"));
                            lsCEntidad.DESCRIPCION_ACUMULACION = dr.GetString(dr.GetOrdinal("DESCRIPCION_ACUMULACION"));

                            lsCEntidad.IMPROCEDENTE = dr.GetBoolean(dr.GetOrdinal("IMPROCEDENTE"));
                            lsCEntidad.FUNDADA = dr.GetBoolean(dr.GetOrdinal("FUNDADA"));
                            lsCEntidad.FUNDADA_PARTE = dr.GetBoolean(dr.GetOrdinal("FUNDADA_PARTE"));
                            lsCEntidad.INFUNDADA = dr.GetBoolean(dr.GetOrdinal("INFUNDADA"));
                            lsCEntidad.INADMISIBLE = dr.GetBoolean(dr.GetOrdinal("INADMISIBLE"));
                            lsCEntidad.LEVANTAR_CADUCIDAD = dr.GetBoolean(dr.GetOrdinal("LEVANTAR_CADUCIDAD"));

                            lsCEntidad.IMPROCEDENTE_MED = dr.GetBoolean(dr.GetOrdinal("IMPROCEDENTE_MED"));
                            lsCEntidad.FUNDADA_MED = dr.GetBoolean(dr.GetOrdinal("FUNDADA_MED"));
                            lsCEntidad.FUNDADA_PARTE_MED = dr.GetBoolean(dr.GetOrdinal("FUNDADA_PARTE_MED"));
                            lsCEntidad.INFUNDADA_MED = dr.GetBoolean(dr.GetOrdinal("INFUNDADA_MED"));
                            lsCEntidad.LEV_MED_CAUTELAR = dr.GetBoolean(dr.GetOrdinal("LEV_MED_CAUTELAR"));
                            lsCEntidad.MOD_MED_CAUTELAR = dr.GetBoolean(dr.GetOrdinal("MOD_MED_CAUTELAR"));
                            lsCEntidad.DESCRIPCION_MED_CAUTELAR = dr.GetString(dr.GetOrdinal("DESCRIPCION_MED_CAUTELAR"));
                            lsCEntidad.LEV_PARTE_MED_CAUTELAR = dr.GetBoolean(dr.GetOrdinal("LEV_PARTE_MED_CAUTELAR"));
                            lsCEntidad.NO_LEV_MED_CAUTELAR = dr.GetBoolean(dr.GetOrdinal("NO_LEV_MED_CAUTELAR"));
                            lsCEntidad.DESCRIPCION_OTROS = dr.GetString(dr.GetOrdinal("DESCRIPCION_OTROS"));

                            //lsCEntidad.DESCRIPCION_MEDIDAS_CAUTELARES = dr.GetString(dr.GetOrdinal("DESCRIPCION_MEDIDAS_CAUTELARES"));
                            //lsCEntidad.MOTIVO_AMPLIACION = dr.GetString(dr.GetOrdinal("MOTIVO_AMPLIACION"));
                            lsCEntidad.MOTAMP_AMPIMP = dr.GetBoolean(dr.GetOrdinal("MOTAMP_AMPIMP"));
                            lsCEntidad.MOTAMP_AMPOTRINF = dr.GetBoolean(dr.GetOrdinal("MOTAMP_AMPOTRINF"));
                            lsCEntidad.MOTAMP_AMPPORPLA = dr.GetBoolean(dr.GetOrdinal("MOTAMP_AMPPORPLA"));
                            lsCEntidad.MOTAMP_OTROS = dr.GetString(dr.GetOrdinal("MOTAMP_OTROS"));

                            //lsCEntidad.INFORMACION_FALSA = dr.GetBoolean(dr.GetOrdinal("INFORMACION_FALSA"));
                            lsCEntidad.INFORMACION_FALSA_INEX = dr.GetBoolean(dr.GetOrdinal("INFORMACION_FALSA_INEX"));
                            lsCEntidad.INFORMACION_FALSA_DIF = dr.GetBoolean(dr.GetOrdinal("INFORMACION_FALSA_DIF"));
                            lsCEntidad.INFORMACION_FALSA_DAS = dr.GetBoolean(dr.GetOrdinal("INFORMACION_FALSA_DAS"));
                            lsCEntidad.DESCRIPCION_INFORMACION_FALSA = dr.GetString(dr.GetOrdinal("DESCRIPCION_INFORMACION_FALSA"));
                            lsCEntidad.COD_OD_REGISTRO = dr.GetString(dr.GetOrdinal("COD_OD_REGISTRO"));

                            lsCEntidad.RECTIF_CAMBIO_MULTA = dr.GetBoolean(dr.GetOrdinal("RECTIF_CAMBIO_MULTA"));
                            lsCEntidad.RECONS_CAMBIO_MULTA = dr.GetBoolean(dr.GetOrdinal("RECONS_CAMBIO_MULTA"));
                            lsCEntidad.RECTIF_MONTO = dr.GetDecimal(dr.GetOrdinal("RECTIF_MONTO"));
                            lsCEntidad.RECONS_MONTO = dr.GetDecimal(dr.GetOrdinal("RECONS_MONTO"));
                            lsCEntidad.SANCION_EXTITULAR = dr.GetBoolean(dr.GetOrdinal("SANCION_EXTITULAR"));
                            lsCEntidad.SIN_INDICIOS_APROV = dr.GetBoolean(dr.GetOrdinal("SIN_INDICIOS_APROV"));

                            lsCEntidad.PUBLICAR = dr.GetBoolean(dr.GetOrdinal("PUBLICAR"));

                            lsCEntidad.COD_TITULAR = dr.GetString(dr.GetOrdinal("COD_TITULAR"));
                            lsCEntidad.TITULAR = dr.GetString(dr.GetOrdinal("TITULAR"));
                            lsCEntidad.AMONESTACION = dr.GetBoolean(dr.GetOrdinal("AMONESTACION"));
                            lsCEntidad.FECHA_CAMPO = dr.GetString(dr.GetOrdinal("FECHA_CAMPO"));
                            lsCEntidad.PRIM_QUINQUENIO = dr.GetBoolean(dr.GetOrdinal("PRIM_QUINQUENIO"));
                            lsCEntidad.SEG_QUINQUENIO = dr.GetBoolean(dr.GetOrdinal("SEG_QUINQUENIO"));
                            lsCEntidad.TERC_QUINQUENIO = dr.GetBoolean(dr.GetOrdinal("TERC_QUINQUENIO"));
                            lsCEntidad.CUART_QUINQUENIO = dr.GetBoolean(dr.GetOrdinal("CUART_QUINQUENIO"));
                            lsCEntidad.BLOQ_QUINQUENIO = dr.GetInt32(dr.GetOrdinal("BLOQ_QUINQUENIO"));

                            lsCEntidad.RESDIR = dr.GetBoolean(dr.GetOrdinal("RESDIR"));
                            lsCEntidad.RESSUBDIR = dr.GetBoolean(dr.GetOrdinal("RESSUBDIR"));

                            lsCEntidad.BEXTRACCION_FEMISION = dr.GetString(dr.GetOrdinal("BEXTRACCION_FEMISION"));
                            lsCEntidad.USUARIO_REGISTRO = dr.GetString(dr.GetOrdinal("USUARIO_REGISTRO"));
                            lsCEntidad.RECTIFICACION = dr.GetBoolean(dr.GetOrdinal("RECTIFICACION"));
                            lsCEntidad.DESC_RECTIFICACION = dr.GetString(dr.GetOrdinal("DESC_RECTIFICACION"));

                            lsCEntidad.MED_CAUT_XESPECIE = dr.GetBoolean(dr.GetOrdinal("MED_CAUT_XESPECIE"));
                            //lsCEntidad.ESMANDATO = Convert.ToInt32(dr.GetBoolean(dr.GetOrdinal("ESMANDATO")));
                            //lsCEntidad.MANDATO = dr.GetString(dr.GetOrdinal("MANDATO"));
                            //lsCEntidad.CANTMESES = dr.GetInt32(dr.GetOrdinal("CANT_MESES"));
                            //lsCEntidad.CANTDIAS = dr.GetInt32(dr.GetOrdinal("CANT_DIAS"));
                            lsCEntidad.MANDATOS = dr.GetBoolean(dr.GetOrdinal("MANDATOS"));
                            lsCEntidad.DESCUENTO = dr.GetBoolean(dr.GetOrdinal("DESCUENTO"));

                            lsCEntidad.CHK_ACCION = dr.GetBoolean(dr.GetOrdinal("ACCION"));
                            lsCEntidad.CHK_ALLANAMIENTO = dr.GetBoolean(dr.GetOrdinal("ALLANAMIENTO"));
                            lsCEntidad.CHK_SUBSANACION = dr.GetBoolean(dr.GetOrdinal("SUBSANACION"));
                            lsCEntidad.CHK_MEDCOMPLE = dr.GetBoolean(dr.GetOrdinal("MEDIDA_COMPLEMENTARIA"));
                            lsCEntidad.CHK_DECOMISO = dr.GetBoolean(dr.GetOrdinal("DECOMISO"));
                            lsCEntidad.CHK_PLANCIERRE = dr.GetBoolean(dr.GetOrdinal("PLAN_CIERRE"));
                            lsCEntidad.CHK_DIPOSICIONFAUNA = dr.GetBoolean(dr.GetOrdinal("DISPOSICION_FAUNA"));

                            //21.09.2022 TGS
                            lsCEntidad.COD_TERCERO_SOLIDARIO = dr.GetString(dr.GetOrdinal("COD_TERCERO_SOLIDARIO"));
                            lsCEntidad.TERCERO_SOLIDARIO = dr.GetString(dr.GetOrdinal("TERCERO_SOLIDARIO"));
                            lsCEntidad.SUBSANACION_VOLUNTARIA = dr.GetBoolean(dr.GetOrdinal("SUBSANACION_VOLUNTARIA"));

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
                        //Lista de INFORMES O EXPEDIENTES
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.COD_INFORME = dr["COD_INFORME"].ToString();
                                ocampoEnt.NUMERO = dr["NUMERO"].ToString();
                                ocampoEnt.D_LINEA = dr["D_LINEA"].ToString();
                                ocampoEnt.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                ocampoEnt.TITULAR = dr["TITULAR"].ToString();
                                ocampoEnt.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                ocampoEnt.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
                                ocampoEnt.COD_MTIPO = dr["COD_MTIPO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListInformes.Add(ocampoEnt);
                            }
                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.COD_ILEGAL_ARTICULOS = dr["COD_ILEGAL_ARTICULOS"].ToString();
                                ocampoEnt.COD_ILEGAL_ENCISOS = dr["COD_ILEGAL_ENCISOS"].ToString();
                                ocampoEnt.DESCRIPCION_ARTICULOS = dr["DESCRIPCION_ARTICULOS"].ToString();
                                ocampoEnt.DESCRIPCION_ENCISOS = dr["DESCRIPCION_ENCISOS"].ToString();
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.DESCRIPCION_ESPECIE = dr["DESCRIPCION_ESPECIE"].ToString();
                                ocampoEnt.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                ocampoEnt.AREA = Decimal.Parse(dr["AREA"].ToString());
                                ocampoEnt.NUMERO_INDIVIDUOS = Int32.Parse(dr["NUMERO_INDIVIDUOS"].ToString());
                                ocampoEnt.DESCRIPCION_INFRACCIONES = dr["DESCRIPCION_INFRACCIONES"].ToString();
                                ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                ocampoEnt.NUM_POA = dr["NUM_POA"].ToString();
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.TIPOMADERABLE = dr["TIPOMADERABLE"].ToString();
                                ocampoEnt.RegEstado = 0;
                                ocampoEnt.PCA = dr["PCA"].ToString();
                                lsCEntidad.ListarIniPAU.Add(ocampoEnt);
                            }

                        }
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.MOTIVO = dr["MOTIVO"].ToString();
                                ocampoEnt.DETALLE_MOTIVO = dr["DETALLE_MOTIVO"].ToString();
                                ocampoEnt.DESCRIPCIONMOTIVO = dr["DESCRIPCIONMOTIVO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.MotivoArchivo.Add(ocampoEnt);
                            }
                        }
                        //Listado de titulares
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.CODIGO = dr["COD_PERSONA"].ToString();
                                ocampoEnt.DESCRIPCION = dr["APELLIDOS_NOMBRES"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListTitulares.Add(ocampoEnt);
                            }
                        }
                        //lista de literales de la RD Reconsideracion
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CEntidadC oCampos;
                            while (dr.Read())
                            {
                                oCampos = new CEntidadC();
                                oCampos.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                oCampos.COD_RESODIREC_INI_PAU = dr["COD_RESODIREC_INI_PAU"].ToString();
                                oCampos.DESCRIPCION_ARTICULOS = dr["ARTICULO"].ToString();
                                oCampos.DESCRIPCION_ENCISOS = dr["ENCISO"].ToString();
                                oCampos.DESCRIPCION_ESPECIE = dr["ESPECIE"].ToString();
                                oCampos.COD_SECUENCIAL = int.Parse(dr["COD_SECUENCIAL"].ToString());
                                oCampos.VOLUMEN = decimal.Parse(dr["VOLUMEN_RECONS"].ToString());
                                oCampos.AREA = decimal.Parse(dr["AREA_RECONS"].ToString());
                                oCampos.NUMERO_INDIVIDUOS = int.Parse(dr["NUMERO_INDIVIDUOS_RECONS"].ToString());
                                oCampos.TIPOMADERABLE = dr["TIPOMADERABLE"].ToString();
                                oCampos.POA = dr["POA"].ToString();
                                oCampos.DETERMINACION = dr["REFERENCIA"].ToString();
                                oCampos.DESCRIPCION_INFRACCIONES = dr["OBSERVACIONES_REF"].ToString();

                                oCampos.RegEstado = 0;
                                oCampos.BTN_LITERALES = false;
                                oCampos.BTN_LITERALES2 = true;


                                lsCEntidad.ListLiterales.Add(oCampos);
                            }
                        }
                        /*
                        //Especies medidas correctivas
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.COD_SECUENCIAL= dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                ocampoEnt.DESCRIPCION_ESPECIE= dr.GetString(dr.GetOrdinal("DESCRIPCION_ESPECIE"));
                                ocampoEnt.VOLUMEN = dr.GetDecimal(dr.GetOrdinal("VOLUMEN"));
                                ocampoEnt.NUMERO_INDIVIDUOS = dr.GetInt32(dr.GetOrdinal("NUMERO_INDIVIDUOS"));
                                ocampoEnt.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListEspeciesMCorrectiva.Add(ocampoEnt);
                            }
                        }
                        */
                        //Especies medidas cautelares o precautorias
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                ocampoEnt.DESCRIPCION_ESPECIE = dr.GetString(dr.GetOrdinal("DESCRIPCION_ESPECIE"));
                                ocampoEnt.NUM_POA = dr.GetString(dr.GetOrdinal("NUM_POA"));
                                ocampoEnt.POA = dr.GetString(dr.GetOrdinal("POA"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListEspeciesMedidas.Add(ocampoEnt);
                            }
                        }
                        //ESPECIES ALERTA 23/05/2019
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.COD_THABILITANTE = dr.GetString(dr.GetOrdinal("COD_THABILITANTE"));
                                ocampoEnt.NUMERO_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA"));
                                ocampoEnt.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                ocampoEnt.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                ocampoEnt.ESPECIES = dr.GetString(dr.GetOrdinal("ESPECIE"));
                                ocampoEnt.FECHA_BALANCE = dr.GetString(dr.GetOrdinal("FECHA_EMISION_BX"));
                                ocampoEnt.TOTAL_ARBOLES = dr.GetInt32(dr.GetOrdinal("TOTAL_ARBOLES"));
                                ocampoEnt.VOLUMEN_AUTORIZADO = dr.GetDecimal(dr.GetOrdinal("VOLUMEN_AUTORIZADO"));
                                ocampoEnt.VOLUMEN_MOVILIZADO = dr.GetDecimal(dr.GetOrdinal("VOLUMEN_MOVILIZADO"));
                                ocampoEnt.SALDO = dr.GetDecimal(dr.GetOrdinal("SALDO"));
                                ocampoEnt.NOMBRE_POA = dr.GetString(dr.GetOrdinal("NUM_POA_DETALLE"));
                                ocampoEnt.COD_INFORME = dr.GetString(dr.GetOrdinal("COD_INFORME"));
                                ocampoEnt.COD_RESODIREC = dr.GetString(dr.GetOrdinal("COD_RESODIREC"));
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListBEXT.Add(ocampoEnt);
                            }
                        }
                        //MEDIDAS CORRECTIVAS y/o MANDATOS
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Ent_RESODIREC_MEDIDA oMedida;

                            while (dr.Read())
                            {
                                oMedida = new Ent_RESODIREC_MEDIDA();
                                oMedida.COD_RESODIREC = dr.GetString(dr.GetOrdinal("COD_RESODIREC"));
                                oMedida.COD_MEDIDA = dr.GetInt32(dr.GetOrdinal("COD_MEDIDA"));
                                oMedida.MEDIDA = dr.GetString(dr.GetOrdinal("MEDIDA"));
                                oMedida.MAE_TIP_MEDIDA = dr.GetString(dr.GetOrdinal("MAE_TIP_MEDIDA"));
                                oMedida.PLAZO_POST_MES = dr.GetInt32(dr.GetOrdinal("PLAZO_POST_MES"));
                                oMedida.PLAZO_POST_DIA = dr.GetInt32(dr.GetOrdinal("PLAZO_POST_DIA"));
                                oMedida.PLAZO_POST_ANIO = dr.GetInt32(dr.GetOrdinal("PLAZO_POST_ANIO"));
                                oMedida.PLAZO_INF_MES = dr.GetInt32(dr.GetOrdinal("PLAZO_INF_MES"));
                                oMedida.PLAZO_INF_DIA = dr.GetInt32(dr.GetOrdinal("PLAZO_INF_DIA"));
                                oMedida.PLAZO_INF_ANIO = dr.GetInt32(dr.GetOrdinal("PLAZO_INF_ANIO"));
                                oMedida.PLAZO_IMPL_MES = dr.GetInt32(dr.GetOrdinal("PLAZO_IMPL_MES"));
                                oMedida.PLAZO_IMPL_DIA = dr.GetInt32(dr.GetOrdinal("PLAZO_IMPL_DIA"));
                                oMedida.PLAZO_IMPL_ANIO = dr.GetInt32(dr.GetOrdinal("PLAZO_IMPL_ANIO"));
                                oMedida.ListEspeciesMCorrectiva = new List<Ent_RESODIREC_MEDIDA_ESPECIE>();
                                oMedida.RegEstado = 0;
                                if (oMedida.MAE_TIP_MEDIDA == "0000009") lsCEntidad.ListMandatos.Add(oMedida);
                                else lsCEntidad.ListMedidasCorrectivas.Add(oMedida);
                            }
                        }
                        //ESPECIES MEDIDAS CORRECTIVAS
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            Ent_RESODIREC_MEDIDA_ESPECIE oEspecie;
                            Ent_RESODIREC_MEDIDA oMCorrectiva;

                            while (dr.Read())
                            {
                                oEspecie = new Ent_RESODIREC_MEDIDA_ESPECIE();

                                oEspecie.COD_RESODIREC = dr.GetString(dr.GetOrdinal("COD_RESODIREC"));
                                oEspecie.COD_MEDIDA = dr.GetInt32(dr.GetOrdinal("COD_MEDIDA"));
                                oEspecie.COD_SECUENCIAL = dr.GetInt32(dr.GetOrdinal("COD_SECUENCIAL"));
                                oEspecie.COD_ESPECIES = dr.GetString(dr.GetOrdinal("COD_ESPECIES"));
                                oEspecie.ESPECIES = dr.GetString(dr.GetOrdinal("ESPECIES"));
                                oEspecie.VOLUMEN_MOVILIZADO = dr.GetDecimal(dr.GetOrdinal("VOLUMEN_MOVILIZADO"));
                                oEspecie.NUMERO_INDIVIDUOS = dr.GetInt32(dr.GetOrdinal("NUMERO_INDIVIDUOS"));
                                oEspecie.OBSERVACION = dr.GetString(dr.GetOrdinal("OBSERVACION"));
                                oEspecie.RegEstado = 0;

                                oMCorrectiva = lsCEntidad.ListMedidasCorrectivas.Where(m => m.COD_RESODIREC == oEspecie.COD_RESODIREC && m.COD_MEDIDA == oEspecie.COD_MEDIDA).FirstOrDefault();

                                if (oMCorrectiva != null)
                                {
                                    oMCorrectiva.ListEspeciesMCorrectiva.Add(oEspecie);
                                }
                            }
                        }
                        // LISTA DE POA PUBLICADO
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CEntidadC oCEntidadPOA = new CEntidadC();

                            while (dr.Read())
                            {
                                oCEntidadPOA = new CEntidadC();
                                oCEntidadPOA.COD_RESODIREC = dr.GetString(dr.GetOrdinal("COD_RESODIREC"));
                                oCEntidadPOA.NUM_POA = dr.GetInt32(dr.GetOrdinal("NUM_POA")).ToString();
                                oCEntidadPOA.POA = dr.GetString(dr.GetOrdinal("NOMBRE_POA"));
                                oCEntidadPOA.PUBLICAR = dr.GetBoolean(dr.GetOrdinal("PUBLICAR"));
                                lsCEntidad.ListPOAs.Add(oCEntidadPOA);
                            }
                        }

                        //lista de expedientes de allanamiento
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CEntidadC oCEntidadSTD = new CEntidadC();

                            while (dr.Read())
                            {
                                oCEntidadSTD = new CEntidadC();
                                oCEntidadSTD.COD_RDACCION = dr.GetString(dr.GetOrdinal("COD_RDACCION"));
                                oCEntidadSTD.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO")).ToString();
                                oCEntidadSTD.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO")).ToString();
                                oCEntidadSTD.TIPO_DOCUMENTO = dr.GetString(dr.GetOrdinal("TIPO"));
                                oCEntidadSTD.PDF_DOCUMENTO = dr.GetString(dr.GetOrdinal("DESCARGA"));
                                oCEntidadSTD.RegEstado = 0;
                                lsCEntidad.listSTD01.Add(oCEntidadSTD);
                            }
                        }
                        //lista de expedientes de subsanacion
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            CEntidadC oCEntidadSTD = new CEntidadC();

                            while (dr.Read())
                            {
                                oCEntidadSTD = new CEntidadC();
                                oCEntidadSTD.COD_RDACCION = dr.GetString(dr.GetOrdinal("COD_RDACCION"));
                                oCEntidadSTD.CODIGO = dr.GetString(dr.GetOrdinal("CODIGO")).ToString();
                                oCEntidadSTD.NUMERO = dr.GetString(dr.GetOrdinal("NUMERO")).ToString();
                                oCEntidadSTD.TIPO_DOCUMENTO = dr.GetString(dr.GetOrdinal("TIPO"));
                                oCEntidadSTD.PDF_DOCUMENTO = dr.GetString(dr.GetOrdinal("DESCARGA"));
                                oCEntidadSTD.RegEstado = 0;
                                lsCEntidad.listSTD02.Add(oCEntidadSTD);
                            }
                        }

                        //Infracciones Subsanadas
                        dr.NextResult();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.COD_RESODIREC_DET_INFRACCION = dr["COD_RESODIREC_DET_INFRACCION"].ToString();
                                ocampoEnt.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                ocampoEnt.COD_ENCISOS = dr["COD_ENCISOS"].ToString();
                                ocampoEnt.INCISO = dr["INCISO"].ToString();
                                ocampoEnt.ARTICULO = dr["ARTICULO"].ToString();
                                ocampoEnt.RegEstado = 0;
                                lsCEntidad.ListIncisos.Add(ocampoEnt);
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
        public CEntidadC RegMostListPOAs(OracleConnection cn, CEntidadC oCEntidad)
        {
            CEntidadC oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidadC();
                        List<CEntidadC> lsDetDetalle;
                        CEntidadC oCamposDet;
                        //
                        //Lista de POAS
                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.NUM_POA = dr["NUM_POA"].ToString();
                                oCamposDet.POA = dr["POA"].ToString();
                                oCamposDet.PUBLICAR = dr["PUBLICAR"].ToString();
                                oCamposDet.RegEstado = 0;
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListPOAs = lsDetDetalle;
                    }
                }
                return oCampos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidadC RegNumExpediente(OracleConnection cn, CEntidadC oCEntidad)
        {
            CEntidadC oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGenerarNumeracion", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidadC();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new CEntidadC();
                                oCampos.NUMERO_EXPEDIENTE = dr["NUMERACION"].ToString();

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
        public CEntidadC RegMostCombo(OracleConnection cn, CEntidadC oCEntidad)
        {
            CEntidadC oCampos = null;
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new CEntidadC();
                        List<CEntidadC> lsDetDetalle;
                        CEntidadC oCamposDet;
                        //
                        //Especies Maderable
                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                //
                                oCamposDet = new CEntidadC();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListEspeciesForestal = lsDetDetalle;
                        //Especies Fauna
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListEspeciesFauna = lsDetDetalle;
                        //Articulos PAU
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListArticulosPAU = lsDetDetalle;
                        //Tipos Determinación
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListTipoDeter = lsDetDetalle;
                        //tipo archivo
                        dr.NextResult();
                        lsDetDetalle = new List<CEntidadC>();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCamposDet = new CEntidadC();
                                oCamposDet.CODIGO = dr["CODIGO"].ToString();
                                oCamposDet.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                lsDetDetalle.Add(oCamposDet);
                            }
                        }
                        oCampos.ListTipoArchivo = lsDetDetalle;
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
        public List<CEntidadC> RegImportarIncisos(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<CEntidadC> lsCEntidad = new List<CEntidadC>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spRESODIREC_INCISOS", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidadC ocampoEnt;
                        if (dr.HasRows)
                        {

                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.COD_ILEGAL_ENCISOS = dr["COD_ILEGAL_ENCISOS"].ToString();
                                ocampoEnt.DESCRIPCION_ARTICULOS = dr["DESCRIPCION_ARTICULOS"].ToString();
                                ocampoEnt.DESCRIPCION_ENCISOS = dr["DESCRIPCION_ENCISOS"].ToString();
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                ocampoEnt.DESCRIPCION_ESPECIE = dr["DESCRIPCION_ESPECIE"].ToString();
                                ocampoEnt.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
                                ocampoEnt.AREA = Decimal.Parse(dr["AREA"].ToString());
                                ocampoEnt.NUMERO_INDIVIDUOS = Int32.Parse(dr["NUMERO_INDIVIDUOS"].ToString());
                                ocampoEnt.DESCRIPCION_INFRACCIONES = dr["DESCRIPCION_INFRACCIONES"].ToString();
                                ocampoEnt.NUM_POA = dr["NUM_POA"].ToString();
                                ocampoEnt.POA = dr["POA"].ToString();
                                ocampoEnt.TIPOMADERABLE = dr["TIPOMADERABLE"].ToString();
                                ocampoEnt.COD_ILEGAL_ARTICULOS = dr["cod_ilegal_articulos"].ToString();
                                ocampoEnt.DETERMINACION = "";
                                if (oCEntidad.BusValor == "INICIO_PAU")
                                {
                                    ocampoEnt.COD_SECUENCIAL = 0;
                                }
                                else if (oCEntidad.BusValor == "TERMINO_PAU" || oCEntidad.BusValor == "TERMINO_PAU_TFFS")
                                {
                                    ocampoEnt.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
                                    ocampoEnt.DETERMINACION = "No Evaluado";
                                    ocampoEnt.DESCRIPCION_INFRACCIONES = "";
                                    ocampoEnt.RegEstado = 1;
                                    ocampoEnt.BTN_LITERALES = false;
                                    ocampoEnt.BTN_LITERALES2 = true;

                                    if (oCEntidad.BusValor == "TERMINO_PAU_TFFS")
                                    {
                                        ocampoEnt.COD_FCTIPO = dr["COD_FCTIPO"].ToString();
                                        ocampoEnt.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
                                        ocampoEnt.MAE_ESTDETERMINA_ART363I = "0000000";
                                        ocampoEnt.ESTDETERMINA_ART363I = "No Evaluado";
                                    }
                                }
                                //ocampoEnt.RegEstado = 1;
                                lsCEntidad.Add(ocampoEnt);
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
        public Int32 RegPreProcesarObservatorio(OracleConnection cn, CEntidadC oCEntidad)
        {
            OracleTransaction tr = null;
            Int32 OUTPUTPARAM03 = 0;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "HERR_OSINFOR_ERP_MIGRACION.spPROCESAMIENTO_OBSERVATORIO_v3", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM03 = Int32.Parse(cmd.Parameters["OUTPUTPARAM03"].Value.ToString());
                }
                tr.Commit();
                return OUTPUTPARAM03;
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
        public Int32 RegPublicarObservatorio(OracleConnection cn, CEntidadC oCEntidad)
        {
            OracleTransaction tr = null;
            Int32 OUTPUTPARAM03 = 0;
            try
            {
                tr = cn.BeginTransaction();
                //Grabando Cabecera
                using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "HERR_OSINFOR_ERP_MIGRACION.spPUBLI_INMEDIATO_OBSERVATORIO", oCEntidad))
                {
                    cmd.ExecuteNonQuery();
                    OUTPUTPARAM03 = (Int32)cmd.Parameters["@OUTPUTPARAM01"].Value;
                }
                tr.Commit();
                return OUTPUTPARAM03;
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
        /// ////////// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns>iCodMandato</returns>66666
        /*
        public Int32 INSERTAUPDATE_MANDATOS(SqlConnection cn, CEntidadC oCEntidad)
        {
            try
            {
                using (SqlCommand cm = new SqlCommand("DOC.INSERTAUPDATE_MANDATOS", cn))
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@iCodMandato", oCEntidad.ICODMANDATO);
                    cm.Parameters.AddWithValue("@iTipo", oCEntidad.ITIPO);
                    cm.Parameters.AddWithValue("@vEnlace", oCEntidad.vEnlace);
                    cm.Parameters.AddWithValue("@vMandato", oCEntidad.MANDATO);
                    cm.Parameters.AddWithValue("@iCant_meses", oCEntidad.CANTMESES);
                    cm.Parameters.AddWithValue("@iCant_dias", oCEntidad.CANTDIAS);
                    cm.Parameters.AddWithValue("@iCodUsuario", oCEntidad.USUARIO_REGISTRO);
                    cm.Parameters.AddWithValue("@ESMANDATO", oCEntidad.ESMANDATO);
                    using (SqlDataReader dr = cm.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    oCEntidad.ICODMANDATO = Convert.ToInt32(dr.GetValue(dr.GetOrdinal("iCodMandato")));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e) { throw (e); };
            return oCEntidad.ICODMANDATO;
            //SqlTransaction tr = null;
            //Int32 OUTPUTPARAM03 = 0;
            //try
            //{
            //    tr = cn.BeginTransaction();
            //    //Grabando Cabecera
            //    using (SqlCommand cmd = oGDataSQL.ManExecuteOutput(cn, tr, "DOC.INSERTAUPDATE_MANDATOS", oCEntidad))
            //    {
            //        cmd.ExecuteNonQuery();
            //        OUTPUTPARAM03 = (Int32)cmd.Parameters["@OUTPUTPARAM03"].Value;
            //    }
            //    tr.Commit();
            //    return OUTPUTPARAM03;
            //}
            //catch (Exception ex)
            //{
            //    if (tr != null)
            //    {
            //        tr.Rollback();
            //    }
            //    throw ex;
            //}
        }
        */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidadC> RegTitularBuscar(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<CEntidadC> lsCEntidad = new List<CEntidadC>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "DOC_OSINFOR_ERP_MIGRACION.spGeneral_Combo_Listar", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidadC ocampoEnt;
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();
                                ocampoEnt.CODIGO = dr["CODIGO"].ToString();
                                ocampoEnt.DESCRIPCION = dr["DESCRIPCION"].ToString();
                                //ocampoEnt.RegEstado = 1;
                                lsCEntidad.Add(ocampoEnt);
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
        /// metodo para obtener las especies del balance de extracion de POA
        /// 02/09/2016
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidadC> RegEspecieBExt(SqlConnection cn, CEntidadC oCEntidad)
        //{
        //    List<CEntidadC> lsCEntidad = new List<CEntidadC>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spRESODIREC_BALANCE_EXTRA", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidadC ocampoEnt;
        //                if (dr.HasRows)
        //                {
        //                    int pt0 = dr.GetOrdinal("VOLUMEN_MOVILIZADO");
        //                    int pt1 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt2 = dr.GetOrdinal("DESCRIPCION");
        //                    int pt3 = dr.GetOrdinal("NUM_POA");
        //                    int pt4 = dr.GetOrdinal("NUM_POA_DETALLE");

        //                    while (dr.Read())
        //                    {
        //                        ocampoEnt = new CEntidadC();

        //                        ocampoEnt.VOLUMEN = dr.GetDecimal(pt0);
        //                        ocampoEnt.COD_ESPECIES = dr.GetString(pt1);
        //                        ocampoEnt.DESCRIPCION = dr.GetString(pt2);
        //                        ocampoEnt.POA = dr.GetInt32(pt3).ToString();
        //                        ocampoEnt.NUM_POA = dr.GetString(pt4);

        //                        //ocampoEnt.RegEstado = 1;
        //                        lsCEntidad.Add(ocampoEnt);
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
        /// metodo para obtener los incisos de acuerdo a los articulos seleccionados
        /// 05/09/2016
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidadC> RegEncisosList(SqlConnection cn, CEntidadC oCEntidad)
        //{
        //    List<CEntidadC> lsCEntidad = new List<CEntidadC>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spRESODIREC_ILEGAL_ENCISOS_LIST", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidadC ocampoEnt;
        //                if (dr.HasRows)
        //                {
        //                    int pt0 = dr.GetOrdinal("COD_ILEGAL_ENCISOS");
        //                    int pt1 = dr.GetOrdinal("DESCRIPCION");

        //                    while (dr.Read())
        //                    {
        //                        ocampoEnt = new CEntidadC();

        //                        ocampoEnt.COD_ILEGAL_ENCISOS = dr.GetString(pt0);
        //                        ocampoEnt.DESCRIPCION = dr.GetString(pt1);

        //                        //ocampoEnt.RegEstado = 1;
        //                        lsCEntidad.Add(ocampoEnt);
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
        /// metodo para obtener la gravedad de daño de la RD de termino 
        /// 15/09/2016
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidadC> dat_ComboListarGravedad(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<CEntidadC> lsCEntidad = new List<CEntidadC>();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdResult(cn, null, "doc_osinfor_erp_migracion.spRESODIREC_GravedadListar", oCEntidad))
                {
                    if (dr != null)
                    {
                        CEntidadC ocampoEnt;
                        if (dr.HasRows)
                        {
                            int pt0 = dr.GetOrdinal("COD_RESODIREC_GRAVEDAD");
                            int pt1 = dr.GetOrdinal("DESCRIPCION");
                            while (dr.Read())
                            {
                                ocampoEnt = new CEntidadC();

                                ocampoEnt.CODIGO = dr.GetString(pt0);
                                ocampoEnt.DESCRIPCION = dr.GetString(pt1);
                                //ocampoEnt.RegEstado = 1;
                                lsCEntidad.Add(ocampoEnt);
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
        /// metodo para lista las RD asociadas al expediente administrativo para su rectificacion 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidadC> dat_ListRD_Rectificacion(SqlConnection cn, CEntidadC oCEntidad)
        //{
        //    List<CEntidadC> lsCEntidad = new List<CEntidadC>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spRESODIREC_Rectificacion", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidadC ocampoEnt;
        //                if (dr.HasRows)
        //                {
        //                    int pt5 = dr.GetOrdinal("COD_RESODIREC_INI_PAU");
        //                    int pt0 = dr.GetOrdinal("COD_RESODIREC");
        //                    int pt1 = dr.GetOrdinal("NUMERO_RESOLUCION");
        //                    int pt2 = dr.GetOrdinal("Fiscalizacion_Categoria_Tipo");
        //                    int pt3 = dr.GetOrdinal("COD_THABILITANTE");
        //                    int pt4 = dr.GetOrdinal("COD_TITULAR");
        //                    int pt6 = dr.GetOrdinal("TIPO_PERSONA");

        //                    while (dr.Read())
        //                    {
        //                        ocampoEnt = new CEntidadC();

        //                        ocampoEnt.COD_RESODIREC = dr.GetString(pt0);
        //                        ocampoEnt.NUMERO = dr.GetString(pt1);
        //                        ocampoEnt.TIPO = dr.GetString(pt2);
        //                        ocampoEnt.CODIGO = dr.GetString(pt3); // codigo del titulo habilitante 
        //                        ocampoEnt.COD_TITULAR = dr.GetString(pt4);
        //                        ocampoEnt.COD_RESODIREC_INI_PAU = dr.GetString(pt5);
        //                        ocampoEnt.TIPO = dr.GetString(pt6); // tipo de persona si es N: natural o J: juridica
        //                        //ocampoEnt.RegEstado = 1;
        //                        lsCEntidad.Add(ocampoEnt);
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
        /// metodo para listar las medidas cautelares registradas en la rd de inicio
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidadC> datmedcautelar(SqlConnection cn, CEntidadC oCEntidad)
        //{
        //    List<CEntidadC> lsCEntidad = new List<CEntidadC>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spRESODIREC_GravedadListar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidadC ocampoEnt;
        //                if (dr.HasRows)
        //                {
        //                    int pt0 = dr.GetOrdinal("COD_RESODIREC_GRAVEDAD");
        //                    int pt1 = dr.GetOrdinal("DESCRIPCION");
        //                    while (dr.Read())
        //                    {
        //                        ocampoEnt = new CEntidadC();

        //                        ocampoEnt.CODIGO = dr.GetString(pt0);
        //                        ocampoEnt.DESCRIPCION = dr.GetString(pt1);
        //                        //ocampoEnt.RegEstado = 1;
        //                        lsCEntidad.Add(ocampoEnt);
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
        /// metodo para obtener las especies a rectificar
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidadC> dat_ListEspecies_Recitificar(SqlConnection cn, CEntidadC oCEntidad)
        //{
        //    List<CEntidadC> lsCEntidad = new List<CEntidadC>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spRESODIREC_RectificacionEspecies", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidadC ocampoEnt;
        //                if (dr.HasRows)
        //                {
        //                    int pt0 = dr.GetOrdinal("COD_RESODIREC_INI_PAU");
        //                    int pt1 = dr.GetOrdinal("COD_RESODIREC");
        //                    int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt3 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt4 = dr.GetOrdinal("DESCRIPCION");
        //                    int pt5 = dr.GetOrdinal("VOLUMEN");

        //                    while (dr.Read())
        //                    {
        //                        ocampoEnt = new CEntidadC();

        //                        ocampoEnt.COD_RESODIREC_INI_PAU = dr.GetString(pt0);
        //                        ocampoEnt.COD_RESODIREC = dr.GetString(pt1);
        //                        ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt2);
        //                        ocampoEnt.COD_ESPECIES = dr.GetString(pt3);
        //                        ocampoEnt.DESCRIPCION = dr.GetString(pt4);
        //                        ocampoEnt.VOLUMEN = dr.GetDecimal(pt5);
        //                        ocampoEnt.BTN_LITERALES = false;
        //                        ocampoEnt.BTN_LITERALES2 = true;
        //                        //ocampoEnt.RegEstado = 1;
        //                        lsCEntidad.Add(ocampoEnt);
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
        /// metodo para obtener la lista de titulares registrados en la adenda
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidadC> dat_ListTitulares_Recitificar(SqlConnection cn, CEntidadC oCEntidad)
        //{
        //    List<CEntidadC> lsCEntidad = new List<CEntidadC>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spRESODIREC_TitularesRectificar", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidadC ocampoEnt;
        //                if (dr.HasRows)
        //                {
        //                    int pt0 = dr.GetOrdinal("COD_PERSONA");
        //                    int pt1 = dr.GetOrdinal("PATERNO");
        //                    int pt2 = dr.GetOrdinal("MATERNO");
        //                    int pt3 = dr.GetOrdinal("NOMBRES");
        //                    int pt4 = dr.GetOrdinal("RAZON_SOCIAL");
        //                    int pt5 = dr.GetOrdinal("TIPO_PERSONA");

        //                    while (dr.Read())
        //                    {
        //                        ocampoEnt = new CEntidadC();

        //                        ocampoEnt.COD_TITULAR = dr.GetString(pt0);
        //                        ocampoEnt.AP_PATERNO = dr.GetString(pt1);
        //                        ocampoEnt.AP_MATERNO = dr.GetString(pt2);
        //                        ocampoEnt.NOMBRES = dr.GetString(pt3);
        //                        ocampoEnt.DESCRIPCION = dr.GetString(pt4);//RAZON SOCIAL
        //                        ocampoEnt.TIPO_PERSONA = dr.GetString(pt5);
        //                        if (ocampoEnt.TIPO_PERSONA == "N")
        //                        {
        //                            ocampoEnt.APELLIDOS_NOMBRES = ocampoEnt.AP_PATERNO + " " + ocampoEnt.AP_MATERNO + " " + ocampoEnt.NOMBRES;
        //                        }
        //                        if (ocampoEnt.TIPO_PERSONA == "J")
        //                        {
        //                            ocampoEnt.APELLIDOS_NOMBRES = ocampoEnt.RAZON_SOCIAL;
        //                        }
        //                        //ocampoEnt.RegEstado = 1;
        //                        lsCEntidad.Add(ocampoEnt);
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
        /// metodo para la busqueda de los literales 
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidadC> RegMostrarTHabilitante_Buscar(SqlConnection cn, CEntidadC oCEntidad)
        //{
        //    List<CEntidadC> lsCEntidad = new List<CEntidadC>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spRESODIREC_THABILITANTE", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    CEntidadC oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidadC();
        //                        oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
        //                        oCampos.TITULO = dr["TITULO"].ToString();
        //                        oCampos.NUM_POA = dr["NUM_POA"].ToString();
        //                        oCampos.POA = dr["NUM_POA_STRING"].ToString(); // NUM_POA_STRING
        //                        oCampos.COD_MTIPO = dr["COD_MTIPO"].ToString();
        //                        oCampos.DESCRIPCION = dr["MODALIDAD"].ToString();
        //                        oCampos.TITULAR = dr["TITULAR"].ToString();
        //                        oCampos.D_LINEA = dr["D_LINEA"].ToString();
        //                        oCampos.RegEstado = 0;
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

        //public List<CEntidadC> RegMostrarItemTHSupQuinquenal(SqlConnection cn, CEntidadC oCEntidad)
        //{
        //    List<CEntidadC> lsCEntidad = new List<CEntidadC>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spRESODIREC_THABILITANTE", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    CEntidadC oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidadC();
        //                        oCampos.CODIGO = dr["COD_SUPERVISOR"].ToString();
        //                        oCampos.DESCRIPCION = dr["APELLIDOS_NOMBRES"].ToString();
        //                        oCampos.DESCRIPCION_OTROS = dr["DESCRIPCION"].ToString();
        //                        oCampos.RegEstado = 0;
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

        //public List<CEntidadC> RegMostrarItemTHMuestraQuinquenal(SqlConnection cn, CEntidadC oCEntidad)
        //{
        //    List<CEntidadC> lsCEntidad = new List<CEntidadC>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spRESODIREC_THABILITANTE", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                if (dr.HasRows)
        //                {
        //                    CEntidadC oCampos;
        //                    while (dr.Read())
        //                    {
        //                        oCampos = new CEntidadC();
        //                        oCampos.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
        //                        oCampos.NUM_POA = dr["NUM_POA"].ToString();
        //                        oCampos.POA = dr["NUM_POA_STRING"].ToString();
        //                        oCampos.COD_SECUENCIAL = Int32.Parse(dr["COD_SECUENCIAL"].ToString());
        //                        oCampos.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
        //                        oCampos.DESCRIPCION_ESPECIE = dr["ESPECIES"].ToString();
        //                        oCampos.VOLUMEN = Decimal.Parse(dr["VOLUMEN"].ToString());
        //                        oCampos.DAP = Decimal.Parse(dr["DAP"].ToString());
        //                        oCampos.AC = Decimal.Parse(dr["AC"].ToString());
        //                        oCampos.DMC = Int32.Parse(dr["DMC"].ToString());
        //                        oCampos.CONDICION_ESPECIE = dr["CONDICION"].ToString();
        //                        oCampos.COD_ESTADO_DOC = dr["ESTADO"].ToString();
        //                        oCampos.COORDENADA_ESTE = dr["COORDENADA_ESTE"].ToString();
        //                        oCampos.COORDENADA_NORTE = dr["COORDENADA_NORTE"].ToString();
        //                        oCampos.MUESTRA_QUIN = Boolean.Parse(dr["MUESTRA_QUIN"].ToString());
        //                        oCampos.RegEstado = 0;
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

        //public void grabarMuestraQuinquenal(SqlConnection cn, List<CEntidadC> listMuestraQuinquenal)
        //{
        //    try
        //    {
        //        SqlTransaction tr = null;
        //        tr = cn.BeginTransaction();
        //        if (listMuestraQuinquenal.Count > 0)
        //        {
        //            foreach (var loDatos in listMuestraQuinquenal)
        //            {
        //                if (loDatos.RegEstado == 1)
        //                {
        //                    CEntidadC oCamposDet = new CEntidadC();
        //                    oCamposDet.COD_THABILITANTE = loDatos.COD_THABILITANTE;
        //                    oCamposDet.COD_ESPECIES = loDatos.COD_ESPECIES;
        //                    oCamposDet.NUM_POA = loDatos.NUM_POA;
        //                    oCamposDet.COD_SECUENCIAL = loDatos.COD_SECUENCIAL;
        //                    oCamposDet.MUESTRA_QUIN = loDatos.MUESTRA_QUIN;
        //                    oCamposDet.BusFormulario = "RESODIREC_MUESTRA_GRABAR";
        //                    oGDataSQL.ManExecute(cn, tr, "DOC.spRESODIREC_THABILITANTE", oCamposDet);
        //                }
        //            }
        //            tr.Commit();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// metodo para obtener las especies del balance de extracion de POA
        /// 16/05/2019
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        //public List<CEntidadC> RegEspecieBExt_ALERTA(SqlConnection cn, CEntidadC oCEntidad)
        //{
        //    List<CEntidadC> lsCEntidad = new List<CEntidadC>();
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdResult(cn, null, "DOC.spRESODIREC_BALANCE_MEDCAU", oCEntidad))
        //        {
        //            if (dr != null)
        //            {
        //                CEntidadC ocampoEnt;
        //                if (dr.HasRows)
        //                {
        //                    int pt0 = dr.GetOrdinal("COD_THABILITANTE");
        //                    int pt1 = dr.GetOrdinal("NUM_POA");
        //                    int pt2 = dr.GetOrdinal("COD_SECUENCIAL");
        //                    int pt3 = dr.GetOrdinal("COD_ESPECIES");
        //                    int pt4 = dr.GetOrdinal("ESPECIE");
        //                    int pt5 = dr.GetOrdinal("FECHA_EMISION_BX");
        //                    int pt6 = dr.GetOrdinal("TOTAL_ARBOLES");
        //                    int pt7 = dr.GetOrdinal("VOLUMEN_AUTORIZADO");
        //                    int pt8 = dr.GetOrdinal("VOLUMEN_MOVILIZADO");
        //                    int pt9 = dr.GetOrdinal("SALDO");
        //                    int pt10 = dr.GetOrdinal("NUM_POA_DETALLE");
        //                    int pt11 = dr.GetOrdinal("COD_INFORME");


        //                    while (dr.Read())
        //                    {
        //                        ocampoEnt = new CEntidadC();

        //                        ocampoEnt.COD_THABILITANTE = dr.GetString(pt0);
        //                        ocampoEnt.NUMERO_POA = dr.GetInt32(pt1);
        //                        ocampoEnt.COD_SECUENCIAL = dr.GetInt32(pt2);
        //                        ocampoEnt.COD_ESPECIES = dr.GetString(pt3);
        //                        ocampoEnt.ESPECIES = dr.GetString(pt4);
        //                        ocampoEnt.FECHA_BALANCE = dr.GetString(pt5);
        //                        ocampoEnt.TOTAL_ARBOLES = dr.GetInt32(pt6);
        //                        ocampoEnt.VOLUMEN_AUTORIZADO = dr.GetDecimal(pt7);
        //                        ocampoEnt.VOLUMEN_MOVILIZADO = dr.GetDecimal(pt8);
        //                        ocampoEnt.SALDO = dr.GetDecimal(pt9);
        //                        ocampoEnt.NOMBRE_POA = dr.GetString(pt10);
        //                        ocampoEnt.COD_INFORME = dr.GetString(pt11);

        //                        ocampoEnt.RegEstado = 1;
        //                        lsCEntidad.Add(ocampoEnt);
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

        //public List<Tra_M_Tramite> selectExpedienteMC(SqlConnection cn, Tra_M_Tramite tramite)
        //{
        //    List<Tra_M_Tramite> list = new List<Tra_M_Tramite>();
        //    Tra_M_Tramite data;
        //    try
        //    {
        //        using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.SP_SELECT_EXPEDIENTE_MC", tramite))
        //        {
        //            if (dr == null) return list;
        //            if (!dr.HasRows) return list;
        //            while (dr.Read())
        //            {
        //                data = new Tra_M_Tramite();
        //                data.iCodTramite = oGDataSQL.ValidateNullDB<int>(dr.GetValue(dr.GetOrdinal("iCodTramite")));
        //                data.cNomTupa = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("cNomTupa")));
        //                data.cNomTupaClase = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("cNomTupaClase")));
        //                data.cCodificacion = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("cCodificacion")));
        //                data.fFecDocumento = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("fFecDocumento")));
        //                data.vTrabajador = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("vTrabajador")));
        //                data.cDescTipoDoc = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("cDescTipoDoc")));
        //                data.cNroDocumento = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("cNroDocumento")));
        //                data.cNombre = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("cNombre")));
        //                data.cAsunto = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("cAsunto")));
        //                data.cNombreNuevo = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("cNombreNuevo")));
        //                data.sDescarga = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("DESCARGA")));
        //                data.DESCARGA = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("URLDESCARGA")));
        //                data.COD_RESODIREC = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("ARCHIVO_EXTENSION")));
        //                data.iEstado = oGDataSQL.ValidateNullDB<int>(dr.GetValue(dr.GetOrdinal("iEstado")));
        //                data.iTipo = oGDataSQL.ValidateNullDB<int>(dr.GetValue(dr.GetOrdinal("iTipo")));
        //                data.PLAZO_DIA = oGDataSQL.ValidateNullDB<int>(dr.GetValue(dr.GetOrdinal("PLAZO_DIA")));
        //                data.PLAZO_MES = oGDataSQL.ValidateNullDB<int>(dr.GetValue(dr.GetOrdinal("PLAZO_MES")));
        //                data.nomEstado = oGDataSQL.ValidateNullDB<string>(dr.GetValue(dr.GetOrdinal("nomEstado")));
        //                data.COD_EXPEDIENTE = oGDataSQL.ValidateNullDB<int>(dr.GetValue(dr.GetOrdinal("COD_EXPEDIENTE")));
        //                list.Add(data);
        //            }
        //        }
        //    }
        //    catch (Exception e) { throw (e); };
        //    return list;
        //}

        #region "Seguimiento Medidas - SIGOsfc Beta"
        //public Ent_RESODIREC_MEDIDA_SEGUIMIENTO RegMostrarItemSeguimientoMedida(Ent_RESODIREC_MEDIDA_SEGUIMIENTO oCEntidad)
        //{
        //    Ent_RESODIREC_MEDIDA_SEGUIMIENTO oCampos = new Ent_RESODIREC_MEDIDA_SEGUIMIENTO();

        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, null, "DOC.spRESODIREC_SeguimientoMedida", oCEntidad))
        //            {
        //                oCampos.ListMedidaCorrectiva = new List<Ent_RESODIREC_MEDIDA>();
        //                oCampos.ListMandato = new List<Ent_RESODIREC_MEDIDA>();
        //                Ent_RESODIREC_MEDIDA oCampoMed;

        //                if (dr != null)
        //                {
        //                    if (dr.HasRows)
        //                    {
        //                        if (dr.Read())
        //                        {
        //                            oCampos.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
        //                            oCampos.NUM_EXPEDIENTE = dr["NUM_EXPEDIENTE"].ToString();
        //                            oCampos.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
        //                            oCampos.TITULAR = dr["TITULAR"].ToString();
        //                            oCampos.MODALIDAD = dr["MODALIDAD"].ToString();
        //                        }

        //                        dr.NextResult();
        //                        if (dr.HasRows)
        //                        {
        //                            while (dr.Read())
        //                            {
        //                                oCampoMed = new Ent_RESODIREC_MEDIDA();
        //                                oCampoMed.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
        //                                oCampoMed.COD_RESODIREC_MEDIDA = dr["COD_RESODIREC_MEDIDA"].ToString();
        //                                oCampoMed.NUM_RESOLUCION_MEDIDA = dr["NUM_RESOLUCION_MEDIDA"].ToString();
        //                                oCampoMed.COD_MEDIDA = Convert.ToInt32(dr["COD_MEDIDA"].ToString());
        //                                oCampoMed.MEDIDA = dr["MEDIDA"].ToString();
        //                                oCampoMed.FECHA_NOTIFICACION = dr["FECHA_NOTIFICACION"].ToString();
        //                                oCampoMed.PLAZO_IMPLEMENTACION = dr["PLAZO_IMPLEMENTACION"].ToString();
        //                                oCampos.ListMedidaCorrectiva.Add(oCampoMed);
        //                            }
        //                        }

        //                        dr.NextResult();
        //                        if (dr.HasRows)
        //                        {
        //                            while (dr.Read())
        //                            {
        //                                oCampoMed = new Ent_RESODIREC_MEDIDA();
        //                                oCampoMed.COD_RESODIREC = dr["COD_RESODIREC"].ToString();
        //                                oCampoMed.COD_RESODIREC_MEDIDA = dr["COD_RESODIREC_MEDIDA"].ToString();
        //                                oCampoMed.NUM_RESOLUCION_MEDIDA = dr["NUM_RESOLUCION_MEDIDA"].ToString();
        //                                oCampoMed.COD_MEDIDA = Convert.ToInt32(dr["COD_MEDIDA"].ToString());
        //                                oCampoMed.MEDIDA = dr["MEDIDA"].ToString();
        //                                oCampoMed.FECHA_NOTIFICACION = dr["FECHA_NOTIFICACION"].ToString();
        //                                oCampoMed.PLAZO_IMPLEMENTACION = dr["PLAZO_IMPLEMENTACION"].ToString();
        //                                oCampos.ListMandato.Add(oCampoMed);
        //                            }
        //                        }
        //                    }
        //                }
        //            }

        //            return oCampos;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// para descargar los registros de la pagina inicial 27/08/2020
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> RegistroUsuarios(OracleConnection cn, CEntidadC oCEntidad)
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


        #endregion
        /// <summary>
        /// metodo para la inicializacion de los combos individuales
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<Ent_SBusqueda> RegMostCombo_V3(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<Ent_SBusqueda> comboRecomendaciones = new List<Ent_SBusqueda>();
            Ent_SBusqueda oCampos = new Ent_SBusqueda();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.CR_FISCA_GENERAL_LISTAR", oCEntidad))
                {
                    if (dr != null)
                    {
                        oCampos = new Ent_SBusqueda();
                        if (oCEntidad.BusCriterio != "ENCISOS")
                        {
                            oCampos.Value = "0000000";
                            oCampos.Text = "Seleccionar";
                            comboRecomendaciones.Add(oCampos);
                        }
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new Ent_SBusqueda();
                                oCampos.Value = dr["CODIGO"].ToString();
                                oCampos.Text = dr["DESCRIPCION"].ToString();
                                comboRecomendaciones.Add(oCampos);
                            }
                        }
                    }
                    cn.Close();
                }
                return comboRecomendaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ent_RESODIREC_REPORTEMEDIDAD> RegReporteDetalle(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<Ent_RESODIREC_REPORTEMEDIDAD> report = new List<Ent_RESODIREC_REPORTEMEDIDAD>();
            Ent_RESODIREC_REPORTEMEDIDAD oCampos = new Ent_RESODIREC_REPORTEMEDIDAD();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.CR_FISCA_GENERAL_LISTAR", oCEntidad))
                {
                    if (dr != null)
                    {

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new Ent_RESODIREC_REPORTEMEDIDAD();
                                oCampos.FECHA_EMSION = dr["FECHA_EMISION"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.TITULO = dr["TITULO"].ToString();
                                oCampos.RESOLUCION = dr["NUMERO_RESOLUCION"].ToString();
                                oCampos.NUMERO_EXPEDIENTE = dr["NUMERO_EXPEDIENTE"].ToString();
                                oCampos.NUM_INFORME = dr["INFORME"].ToString();
                                oCampos.SANCION = dr["SANCION"].ToString();
                                oCampos.AMONESTACION = dr["AMONESTAR"].ToString();
                                oCampos.ARCHIVO = dr["ARCHIVO"].ToString();
                                oCampos.ALLANAMIENTO = dr["ALLANAMIENTO"].ToString();
                                oCampos.SUBSANACION = dr["SUBSANACION"].ToString();
                                oCampos.IMPL_MEDIDAS = dr["MEDIDA_COMPLEMENTARIA"].ToString();
                                oCampos.DECOMISO = dr["DECOMISO"].ToString();
                                oCampos.PLAN_CIERRE = dr["PLAN_CIERRE"].ToString();
                                oCampos.DISP_FAUNA = dr["DISP_FAUNA"].ToString();
                                oCampos.MED_CORRECTIVA = dr["MEDIDA_CORRECTIVA"].ToString();
                                oCampos.OBSERVACIONES = dr["DESCRIPCION"].ToString();
                                report.Add(oCampos);
                            }
                        }
                    }
                    cn.Close();
                }
                return report;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ent_RESODIREC_REPORTEMEDIDAD> RegReporteDetalle2(OracleConnection cn, CEntidadC oCEntidad)
        {
            List<Ent_RESODIREC_REPORTEMEDIDAD> report = new List<Ent_RESODIREC_REPORTEMEDIDAD>();
            Ent_RESODIREC_REPORTEMEDIDAD oCampos = new Ent_RESODIREC_REPORTEMEDIDAD();
            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, null, "doc_osinfor_erp_migracion.CR_FISCA_GENERAL_LISTAR", oCEntidad))
                {
                    if (dr != null)
                    {

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                oCampos = new Ent_RESODIREC_REPORTEMEDIDAD();
                                oCampos.FECHA_EMSION = dr["FECHA_EMISION"].ToString();
                                oCampos.TITULAR = dr["TITULAR"].ToString();
                                oCampos.TITULO = dr["TITULO"].ToString();
                                oCampos.RESOLUCION = dr["NUMERO_RESOLUCION"].ToString();
                                oCampos.NUMERO_EXPEDIENTE = dr["NUMERO_EXPEDIENTE"].ToString();
                                oCampos.NUM_INFORME = dr["INFORME"].ToString();
                                oCampos.MED_CAUTELAR = dr["MEDIDAS_CAUTELARES"].ToString();
                                oCampos.GUIA_TF = dr["MED_CAUT_GTF"].ToString();
                                oCampos.LISTA_TROZAS = dr["MED_CAUT_LIST_TROZA"].ToString();
                                oCampos.PLAN_MANEJO = dr["MED_CAUT_PM"].ToString();
                                oCampos.POA = dr["MED_CAUT_POA"].ToString();
                                oCampos.OBSERVACIONES = dr["DESCRIPCION"].ToString();
                                report.Add(oCampos);
                            }
                        }
                    }
                    cn.Close();
                }
                return report;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VM_RSD_Resumen RSD_Resumen(OracleConnection cn, string COD_RESDIR, string asCodTipoIL)
        {
            VM_RSD_Resumen result = null;

            try
            {
                using (OracleDataReader dr = dBOracle.SelDrdDefaultTR(cn, null, "doc_osinfor_erp_migracion.SPFISCALIZACION_RSD_RESUMEN", COD_RESDIR))
                {
                    if (dr != null)
                    {

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                result = new VM_RSD_Resumen();
                                result.COD_THABILITANTE = dr["COD_THABILITANTE"] != DBNull.Value ? dr["COD_THABILITANTE"].ToString() : null;
                                result.COD_TITULAR = dr["COD_TITULAR"] != DBNull.Value ? dr["COD_TITULAR"].ToString() : null;
                                result.NUM_THABILITANTE = dr["NUM_THABILITANTE"] != DBNull.Value ? dr["NUM_THABILITANTE"].ToString() : null;
                                result.TITULAR = dr["TITULAR"] != DBNull.Value ? dr["TITULAR"].ToString() : null;
                                result.TITULAR_DOCUMENTO = dr["TITULAR_DOCUMENTO"] != DBNull.Value ? dr["TITULAR_DOCUMENTO"].ToString() : null;
                                result.TITULAR_RUC = dr["TITULAR_RUC"] != DBNull.Value ? dr["TITULAR_RUC"].ToString() : null;
                                result.COD_RLEGAL = dr["COD_RLEGAL"] != DBNull.Value ? dr["COD_RLEGAL"].ToString() : null;
                                result.R_LEGAL = dr["R_LEGAL"] != DBNull.Value ? dr["R_LEGAL"].ToString() : null;
                                result.R_LEGAL_DOCUMENTO = dr["R_LEGAL_DOCUMENTO"] != DBNull.Value ? dr["R_LEGAL_DOCUMENTO"].ToString() : null;
                                result.UBIGEO_DEPARTAMENTO = dr["UBIGEO_DEPARTAMENTO"] != DBNull.Value ? dr["UBIGEO_DEPARTAMENTO"].ToString() : null;
                                result.UBIGEO_PROVINCIA = dr["UBIGEO_PROVINCIA"] != DBNull.Value ? dr["UBIGEO_PROVINCIA"].ToString() : null;
                                result.UBIGEO_DISTRITO = dr["UBIGEO_DISTRITO"] != DBNull.Value ? dr["UBIGEO_DISTRITO"].ToString() : null;
                            }
                        }

                        dr.NextResult();

                        if (result != null && dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                var ocampoEnt = new VM_RSD_INFRACCIONES();
                                ocampoEnt.COD_ILEGAL_ENCISOS = dr["COD_ILEGAL_ENCISOS"].ToString();
                                ocampoEnt.DESCRIPCION_ARTICULOS = dr["DESCRIPCION_ARTICULOS"] != DBNull.Value ? dr["DESCRIPCION_ARTICULOS"].ToString() : null;
                                ocampoEnt.DESCRIPCION_ENCISOS = dr["DESCRIPCION_ENCISOS"] != DBNull.Value ? dr["DESCRIPCION_ENCISOS"].ToString() : null;
                                ocampoEnt.TEXTO_ENCISO = dr["TEXTO_ENCISO"] != DBNull.Value ? dr["TEXTO_ENCISO"].ToString() : null;
                                ocampoEnt.GRAVEDAD = dr["GRAVEDAD"] != DBNull.Value ? dr["GRAVEDAD"].ToString() : null;
                                ocampoEnt.TIPO_INFRACCION = dr["TIPO_INFRACCION"] != DBNull.Value ? Int32.Parse(dr["TIPO_INFRACCION"].ToString()) : default(int?);
                                ocampoEnt.RANGO_SANCION = dr["RANGO_SANCION"] != DBNull.Value ? dr["RANGO_SANCION"].ToString() : null;
                                ocampoEnt.COD_ESPECIES = dr["COD_ESPECIES"] != DBNull.Value ? dr["COD_ESPECIES"].ToString() : null;
                                ocampoEnt.DESCRIPCION_ESPECIE = dr["DESCRIPCION_ESPECIE"] != DBNull.Value ? dr["DESCRIPCION_ESPECIE"].ToString() : null;
                                ocampoEnt.VOLUMEN = dr["VOLUMEN"] != DBNull.Value ? Decimal.Parse(dr["VOLUMEN"].ToString()) : default(decimal);
                                ocampoEnt.AREA = dr["AREA"] != DBNull.Value ? Decimal.Parse(dr["AREA"].ToString()) : default(decimal);
                                ocampoEnt.NUMERO_INDIVIDUOS = dr["NUMERO_INDIVIDUOS"] != DBNull.Value ? Int32.Parse(dr["NUMERO_INDIVIDUOS"].ToString()) : default(int);
                                ocampoEnt.DESCRIPCION_INFRACCIONES = dr["DESCRIPCION_INFRACCIONES"] != DBNull.Value ? dr["DESCRIPCION_INFRACCIONES"].ToString() : null;
                                ocampoEnt.NUM_POA = dr["NUM_POA"] != DBNull.Value ? dr["NUM_POA"].ToString() : null;
                                ocampoEnt.TIPOMADERABLE = dr["TIPOMADERABLE"] != DBNull.Value ? dr["TIPOMADERABLE"].ToString() : null;

                                result.LIST_INFRACCIONES.Add(ocampoEnt);
                            }
                        }
                    }
                    cn.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}