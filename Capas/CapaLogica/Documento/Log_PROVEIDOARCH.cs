using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
//using System.Data.SqlClient;
using System.IO;
using System.Web;
using CDatos = CapaDatos.DOC.Dat_PROVEIDOARCH;
using CEntidad = CapaEntidad.DOC.Ent_PROVEIDOARCHIVO;

namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Log_PROVEIDOARCH
    {
        private CDatos oCDatos = new CDatos();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CEntidad RegMostCombo(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntidad> RegMostrarProveidoArch_Buscar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarPROVEIDOARCH_Buscar(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public String RegProveidoArchivo_Grabar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabaProveidoArchivo(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public CEntidad RegMostrarListaProveidoArchItem(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaSolExtItem(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public String GetData_ISUPERVISIONMedidas(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.GetData_ISUPERVISIONMedidas(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// metodo para exportar los registros
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> registroUsuarioProv(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegistroUsuarios(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //metodo de llamado con el controlador para exportar los registros 
        /// <summary>
        /// metodo para la descarga de informacion de usuario
        /// </summary>
        /// <param name="asCodUsuario"></param>
        /// <returns></returns>
        public ListResult RegistroUsuario(string asCodUsuario, string tipo)
        {
            ListResult result = new ListResult();

            try
            {
                CEntidad paramCap = new CEntidad();
                //CLogica exeCap = new CLogica();
                paramCap.BusFormulario = "REGISTRO_USUARIO";
                paramCap.BusCriterio = "PROVEIDO_ARCHIVO";
                if (tipo == "0000006")
                {
                    paramCap.BusCriterio = "PROVEIDO_ARCHIVO_SUP";
                }
                paramCap.COD_UCUENTA = asCodUsuario;

                List<Dictionary<string, string>> olResult = registroUsuarioProv(paramCap);

                if (olResult.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/Reg_Usu/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "PROVEIDOARCH_REG.xlsx";

                    try
                    {
                        File.Delete(@rutaExcel);
                        File.Copy(@rutaExcelBase, @rutaExcel);
                    }
                    catch (IOException ix)
                    {
                        throw new Exception(ix.Message);
                    }

                    //Creamos la cadena de conexión con el fichero excel
                    OleDbConnectionStringBuilder cb = new OleDbConnectionStringBuilder();
                    cb.DataSource = rutaExcel;
                    if (Path.GetExtension(rutaExcel).ToUpper() == ".XLS")
                    {
                        cb.Provider = "Microsoft.Jet.OLEDB.4.0";
                        cb.Add("Extended Properties", "Excel 8.0;HDR=YES;IMEX=0;");
                    }
                    else if (Path.GetExtension(rutaExcel).ToUpper() == ".XLSX")
                    {
                        cb.Provider = "Microsoft.ACE.OLEDB.12.0";
                        cb.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES;IMEX=0;");
                    }

                    using (OleDbConnection conn = new OleDbConnection(cb.ConnectionString))
                    {
                        string insertar = "";
                        int i = 1, ind = 1;
                        //Abrimos la conexión
                        conn.Open();
                        //Creamos la ficha
                        using (OleDbCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //Construyendo las Cabeceras
                            foreach (var itemPart in olResult)
                            {
                                insertar = "'" + (ind++).ToString() + "'";
                                insertar = insertar + ",'" + (itemPart["FECHA_CREACION"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["CODIGO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["NUMERO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["TIPO_FISCALIZA"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["NUM_THABILITANTE"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["TITULAR"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["NUMERO_INFORME"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["NUMERO_EXPEDIENTE"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["MODALIDAD"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["USUARIO"] ?? "") + "'";

                                cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":AZ" + (olResult.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                cmd.ExecuteNonQuery();
                            }

                            //Cerramos la conexión
                            conn.Close();
                        }
                    }

                    result.success = true;
                    result.msj = nombreFile;
                }
                else { throw new Exception("No se encontraron registros"); }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }


        public VM_Proveido init(string asCodResodirec, string asCodTipo, string tipo)
        {
            VM_Proveido vm = new VM_Proveido();
            try
            {
                vm.lblTituloCabecera = "Informe Legal";
                if (String.IsNullOrEmpty(asCodResodirec))
                {
                    //nuevo;
                    vm.lblTituloCabecera = "Nuevo Registro";
                    vm.vmControlCalidad = new VM_ControlCalidad_2();
                    vm.hdfTipoProveido = tipo;
                    vm.vmControlCalidad.ddlIndicadorId = "0000000";
                    vm.hdfCodTipoProve = asCodTipo;
                    vm.ListInfOrExp = new List<CEntidad>();
                    vm.sBusqueda = new List<Ent_SBusqueda>();
                    vm.ListMandatos = new List<CEntidad>();
                    vm.ListFuncionario = new List<CEntidad>();
                    initBusquedaModal(asCodTipo, vm);
                    vm.RegEstado = 1;
                    //PARA EL TIPO CUANDO SE CREA EL REGISTRO
                    switch (asCodTipo)
                    {
                        case "0000175"://Mandatos
                            vm.txtTipoProveido = "Proveído consentido el proceso - Proveído Mandatos";
                            break;

                        case "0000061": // Archivo Informe Supervisión
                            vm.txtTipoProveido = "Proveído consentido el proceso - Proveído Archivo Informe Supervisión";
                            break;
                        case "0000122": // Proveído Cierre Informes (Caso Especial)
                            vm.txtTipoProveido = "Proveído consentido el proceso - roveído Cierre Informes (Caso Especial)";
                            break;

                        case "0000062": // Firme acto administrativo
                            vm.txtTipoProveido = "Proveído consentido el proceso - Proveído Firme Acto Administrativo";
                            break;
                        case "0000185": // Memorándum Firme Acto Administrativo
                            vm.txtTipoProveido = "Memorándum - Memorándum Firme Acto Administrativo";
                            break;
                        case "0000064": // Fallecimiento titular
                            vm.txtTipoProveido = "Proveído consentido el proceso - Proveído Archivo PAU - Fallecimiento del Titular";
                            break;
                        case "0000067": // Agotada la via administrativa
                            vm.txtTipoProveido = "Proveído consentido el proceso - Proveido Agotada la vía Administrativa";
                            break;
                        case "0000184": // Memorándum Agotada la Vía Administrativa
                            vm.txtTipoProveido = "Memorándum - Memorándum Agotada la Vía Administrativa";
                            break;
                        case "0000076": // Dispocision judicial
                            vm.txtTipoProveido = "Proveído consentido el proceso - Proveído Archivo PAU - Disposición Judicial";
                            break;
                        case "0000077": // Nueva notificacion
                            vm.txtTipoProveido = "Proveído consentido el proceso - Proveído Dispone Nueva Notificación";
                            break;
                        case "0000078": // Proveído Admisibilidad y Procedencia del Recurso de Apelación
                            vm.txtTipoProveido = "Proveído consentido el proceso - Proveído Admisibilidad y Procedencia del Recurso de Apelación";
                            break;
                        case "0000079": // Proveído Dejar Sin Efecto Proveído de Firmeza
                            vm.txtTipoProveido = "Proveído consentido el proceso - Proveído Dejar Sin Efecto Proveído de Firmeza";
                            break;
                        case "0000087": // Proveído Otros
                            vm.txtTipoProveido = "Proveído consentido el proceso - Proveído Otros";
                            break;
                        case "0000113": // Proveído Continuación de PAU
                            vm.txtTipoProveido = "Proveído consentido el proceso - Proveído Continuación de PAU";
                            break;
                        case "0000123": // Proveído Declarar Cumplimiento Medida Correctiva
                            vm.txtTipoProveido = "Proveído consentido el proceso - Proveído Declarar Cumplimiento Medida Correctiva";
                            break;
                        case "0000127": // Proveído de Cumplimiento de Mandato Judicial
                            vm.txtTipoProveido = "Proveído consentido el proceso - Proveído de Cumplimiento de Mandato Judicial";
                            break;
                        case "0000106": // Proveído Archivo Informe Quinquenal
                            vm.txtTipoProveido = "Proveído consentido el proceso - Proveído Archivo Informe Quinquenal";
                            break;

                    }
                }
                else
                {

                    CEntidad CEntProveidoArchItems = new CEntidad();
                    CEntProveidoArchItems.COD_PROVEIDOARCH = asCodResodirec;
                    vm.hdfCodProvedio = asCodResodirec;
                    vm.RegEstado = 0;
                    vm.lblTituloCabecera = "Modificando Registro";
                    CEntProveidoArchItems = this.RegMostrarListaProveidoArchItem(CEntProveidoArchItems);
                    vm.hdfTipoProveido = tipo;
                    //    //
                    vm.hdfCodTipoProve = CEntProveidoArchItems.COD_FCTIPO;
                    vm.txtTipoProveido = CEntProveidoArchItems.TIPO_FISCALIZA;
                    vm.txtFechaEmision = CEntProveidoArchItems.FECHA.ToString();
                    vm.txtResolucionDirectoral = CEntProveidoArchItems.RESOLDIRECTORAL;
                    vm.txtResolucionTribunal = CEntProveidoArchItems.RESOLTRIBUNAL;
                    vm.chkResFundado = (Boolean)CEntProveidoArchItems.RESUEL_FUNDADO;
                    vm.chkResInfundado = (Boolean)CEntProveidoArchItems.RESUEL_INFUNDADO;
                    vm.chkResImprocedente = (Boolean)CEntProveidoArchItems.RESUEL_IMPROCEDENTE;
                    vm.txtRecomienda = CEntProveidoArchItems.RECOMENDACION.ToString();
                    vm.txtReferencia = CEntProveidoArchItems.REFERENCIA.ToString();
                    vm.txtObservaciones = CEntProveidoArchItems.OBSERVACION;
                    vm.txtResuelve =  CEntProveidoArchItems.RESUELVE == " " ? string.Empty : CEntProveidoArchItems.RESUELVE;
                    vm.txtIdODs = CEntProveidoArchItems.COD_OD_REGISTRO;
                    vm.ListInfOrExp = new List<CEntidad>();
                    vm.ListInfOrExp = CEntProveidoArchItems.ListInformes;
                    vm.ListFuncionario = CEntProveidoArchItems.ListadoFuncionario;
                    vm.ListMandatos = CEntProveidoArchItems.ListMandatos;
                    initBusquedaModal(CEntProveidoArchItems.COD_FCTIPO, vm);

                    //cambios 26/10/2016
                    vm.chkNuevSuperv = (Boolean)CEntProveidoArchItems.NSUPERV_RECOM;
                    vm.chkEvidIrregular = (Boolean)CEntProveidoArchItems.EVIDENCIA_IRREG;
                    vm.chkSinIndicios = (Boolean)CEntProveidoArchItems.SIN_INDICIOS;
                    vm.chkDefNot = (Boolean)CEntProveidoArchItems.DEFICIENCIA_NOTIFICACION;
                    vm.chkDefTec = (Boolean)CEntProveidoArchItems.DEFICIENCIA_TECNICA;
                    vm.chkFallTit = (Boolean)CEntProveidoArchItems.MUERTE_TITULAR;
                    vm.chkArchTemp = (Boolean)CEntProveidoArchItems.ARCHIVO_TEMPORAL;
                    vm.chkSubsVoluntaria = (Boolean)CEntProveidoArchItems.SUBSANACION_VOLUNTARIA;
                    vm.txtSubsVoluntaria = CEntProveidoArchItems.DESCRIPCION_SUBSANACION_VOLUNTARIA;
                    vm.txtOtros = CEntProveidoArchItems.OTROS_TIPOS;
                    //cambios para la notificacion

                    vm.chkTitular = (Boolean)CEntProveidoArchItems.TITULAR_NOT;
                    vm.txtTitular = CEntProveidoArchItems.DETALLE_TITULAR_NOT;
                    vm.chkDGFFS = (Boolean)CEntProveidoArchItems.DGFFS;
                    vm.txtDescDGFFS = CEntProveidoArchItems.DETALLE_DGFFS;
                    vm.chkProgramaRegional = (Boolean)CEntProveidoArchItems.PROGRAMA_REGIONAL;
                    vm.txtDescProgramaRegional = CEntProveidoArchItems.DETALLE_PROREG;
                    vm.chkMinPublico = (Boolean)CEntProveidoArchItems.MINISTERIO_PUBLICO;
                    vm.txtDescMinPublico = CEntProveidoArchItems.DETALLE_MINPUB;
                    vm.chkMINEMMIN = (Boolean)CEntProveidoArchItems.MIN_ENERGIA_MINAS;
                    vm.txtDescMINEMMIN = CEntProveidoArchItems.DETALLE_MINENMIN;
                    vm.chkColegioIng = (Boolean)CEntProveidoArchItems.COLEGIO_INGENIEROS;
                    vm.txtDescColegioIng = CEntProveidoArchItems.DETALLE_COLING;
                    vm.chkATFFS = (Boolean)CEntProveidoArchItems.ATFFS;
                    vm.txtDescATFFS = CEntProveidoArchItems.DETALLE_ATFFS;
                    vm.chkOCI = (Boolean)CEntProveidoArchItems.OCI;
                    vm.txtDescOCI = CEntProveidoArchItems.DETALLE_OCI;
                    vm.chkOEFA = (Boolean)CEntProveidoArchItems.OEFA;
                    vm.txtDescOEFA = CEntProveidoArchItems.DETALLE_OEFA;
                    vm.chkSUNAT = (Boolean)CEntProveidoArchItems.SUNAT;
                    vm.txtDescSUNAT = CEntProveidoArchItems.DETALLE_SUNAT;
                    vm.chkSERFOR = (Boolean)CEntProveidoArchItems.SERFOR;
                    vm.txtDescSERFOR = CEntProveidoArchItems.DETALLE_SERFOR;
                    vm.chkConta = (Boolean)CEntProveidoArchItems.CONTABILIDAD;
                    vm.txtContaDetalle = CEntProveidoArchItems.DETALLE_CONTA;
                    vm.chktesoreria = (Boolean)CEntProveidoArchItems.TESORERIA;
                    vm.txtTesoreriaOsinfor = CEntProveidoArchItems.DETALLE_TESO;
                    vm.chkOTROS = (Boolean)CEntProveidoArchItems.OTROS;
                    vm.txtDescOTROS = CEntProveidoArchItems.DETALLE_OTROS;
                    // ddlSispone.SelectedValue = CEntProveidoArchItems.DISPONE;

                    vm.txtCodDocumentoSITD = CEntProveidoArchItems.CODTRAMITEENVIO;
                    vm.txtDocumentoSITD = CEntProveidoArchItems.DESTRAMENVIO;
                    vm.txtNroDocumentoSITD = CEntProveidoArchItems.CNRODOCUMENTOE;
                    vm.txtFechaDocumentoSITD = CEntProveidoArchItems.FFECDOCUMENTOE;
                    vm.txtAsuntoSITD = CEntProveidoArchItems.CASUNTOE;
                    vm.pdf_id_tram_envioSITD = CEntProveidoArchItems.PDF_ID_TRAM_ENVIO;

                    //Observaciones de control de calidad
                    //control de calidad
                    vm.vmControlCalidad = new VM_ControlCalidad_2();
                    vm.vmControlCalidad.ddlIndicadorId = CEntProveidoArchItems.COD_ESTADO_DOC;
                    vm.vmControlCalidad.txtUsuarioRegistro = CEntProveidoArchItems.USUARIO_REGISTRO;
                    vm.vmControlCalidad.txtUsuarioControl = CEntProveidoArchItems.USUARIO_CONTROL;
                    vm.vmControlCalidad.chkObsSubsanada = (bool)CEntProveidoArchItems.OBSERV_SUBSANAR;
                    vm.vmControlCalidad.txtControlCalidadObservaciones = CEntProveidoArchItems.OBSERVACIONES_CONTROL.ToString();

                    //21/09/2017
                    vm.txtIdTipoFirmeza = CEntProveidoArchItems.MAE_TIP_PROVFIRMEZA;
                    vm.txtIdTipoAgotada = CEntProveidoArchItems.MAE_TIP_AGOTAVIAADM;
                    if (CEntProveidoArchItems.CADUCIDAD_FIRME != null)
                        vm.txtIdCaducidaF = Convert.ToBoolean(CEntProveidoArchItems.CADUCIDAD_FIRME) == true ? "SI" : "NO";
                    if (CEntProveidoArchItems.ART363I_FIRME != null)
                        vm.txtIdArt363IF = Convert.ToBoolean(CEntProveidoArchItems.ART363I_FIRME) == true ? "SI" : "NO";
                    if (CEntProveidoArchItems.MULTA_FIRME != null)
                        vm.txtIdMultaF = Convert.ToBoolean(CEntProveidoArchItems.MULTA_FIRME) == true ? "SI" : "NO";
                    if (CEntProveidoArchItems.MCORRECTIVA_FIRME != null)
                        vm.txtIdMedcorrectivaF = Convert.ToBoolean(CEntProveidoArchItems.MCORRECTIVA_FIRME) == true ? "SI" : "NO";
                    vm.txtIdConfirRD = CEntProveidoArchItems.CONFIRM_RESOL;



                    if (CEntProveidoArchItems.COD_FCTIPO == "0000061")
                    {
                        //  MTVPrincipal.ActiveViewIndex = 1;
                        vm.txtIdSobArchivo = CEntProveidoArchItems.MAE_TIP_PROVARCHIVO;
                        vm.txtIdMedida = CEntProveidoArchItems.MAE_TIP_MEDIDAS;
                        vm.txtSobreArchivo = CEntProveidoArchItems.DESCRIPCION_PROVARCHIVO;
                        vm.txtDictaMedida = CEntProveidoArchItems.DESCRIPCION_MEDIDAS;
                        vm.txtIdEmiteConst = CEntProveidoArchItems.MAE_TIP_CONSTANCIA;
                        if (CEntProveidoArchItems.MAE_TIP_MEDIDAS == "0000008" || CEntProveidoArchItems.MAE_TIP_MEDIDAS == "0000009")//Medidas correctivas || Mandatos
                        {
                            //txtIdMedida = CEntProveidoArchItems.MAE_TIP_MEDIDAS == "0000008" ? "Medidas Correctivas" : "Mandatos";
                        }
                        if (vm.hdfTipoProveido == "0000006")
                        {
                            vm.chkNuevSuperv = (Boolean)CEntProveidoArchItems.RECOMIENDA_NUEVA_SUPERV;
                            vm.chkIncumpleDirectiva = (Boolean)CEntProveidoArchItems.INCUMPLE_DIRECTIVA_SUPERV;
                        }
                    }
                    else if (CEntProveidoArchItems.COD_FCTIPO == "0000062" || CEntProveidoArchItems.COD_FCTIPO == "0000063" || CEntProveidoArchItems.COD_FCTIPO == "0000064" || CEntProveidoArchItems.COD_FCTIPO == "0000067"
                        || CEntProveidoArchItems.COD_FCTIPO == "0000077" || CEntProveidoArchItems.COD_FCTIPO == "0000079")
                    {
                        //18/09/2017: Rq mejoras para observatorio
                        if (CEntProveidoArchItems.COD_FCTIPO == "0000062")
                        {
                            vm.txtFechaFirmezaF = CEntProveidoArchItems.FECHA_FIRMEZA.ToString();
                        }
                        if (CEntProveidoArchItems.COD_FCTIPO == "0000067")
                        {
                            //pnlViaAdmAgotadaMotivo.Visible = true;
                        }
                    }
                    else if (CEntProveidoArchItems.COD_FCTIPO == "0000078")
                    {

                        funcMostOpcionResuelve(vm, CEntProveidoArchItems.COD_RESUELVE);
                        vm.chkTFFS = (Boolean)CEntProveidoArchItems.TRIBUNAL_FFS;
                        vm.txtDesTFFS = CEntProveidoArchItems.DETALLE_TRIBUNAL_FFS;
                    }
                    else if (CEntProveidoArchItems.COD_FCTIPO == "0000087")
                    {
                        vm.txtResuelve = CEntProveidoArchItems.RESUELVE;
                    }
                    else if (CEntProveidoArchItems.COD_FCTIPO == "0000065" || CEntProveidoArchItems.COD_FCTIPO == "0000066")
                    {
                    }
                    else if (CEntProveidoArchItems.COD_FCTIPO == "0000123")
                    {
                        vm.txtFechaCumpleMCorrectiva = CEntProveidoArchItems.FECHA_CUMPLE_MCORRECTIVA.ToString();
                        vm.chkCumpleMCorrectiva = CEntProveidoArchItems.CUMPLE_MCORRECTIVA == null ? false : (Boolean)CEntProveidoArchItems.CUMPLE_MCORRECTIVA;
                        vm.CumpleMCorrectivaDetalle = CEntProveidoArchItems.DISPONE_CUMPLE_MCORRECTIVA;
                    }
                    else if (CEntProveidoArchItems.COD_FCTIPO == "0000127")
                    {
                        vm.chkMedCaut = (Boolean)CEntProveidoArchItems.MED_CAUTELAR;
                        vm.chckCaducidad = (Boolean)CEntProveidoArchItems.CADUCIDAD;
                        vm.chkInfraccion = (Boolean)CEntProveidoArchItems.INFRACCIONES;
                        vm.chkPM = (Boolean)CEntProveidoArchItems.PJ_PM;
                        vm.chkGTF = (Boolean)CEntProveidoArchItems.PJ_GTF;
                        vm.chkTrozas = (Boolean)CEntProveidoArchItems.PJ_TROZAS;
                        vm.chkCaducidadParte = (Boolean)CEntProveidoArchItems.CADUCIDADPARCIAL;


                        //04/06/2018 CR
                        vm.txtExpedientePJ = CEntProveidoArchItems.NUM_EXPPJ;
                        vm.txtJuzagdo = CEntProveidoArchItems.NUM_JUZGADO;
                        vm.txtFechaJud = CEntProveidoArchItems.FECHA_PJ.ToString();
                        vm.txtPlazoJud = CEntProveidoArchItems.PLAZO_PJ;
                        vm.txtMandatoJudicial = CEntProveidoArchItems.RESUM_PJ;

                        vm.txtObservacionesTSC = CEntProveidoArchItems.OBSERVACIONES_TSC;
                        vm.txtIdNotPJ = CEntProveidoArchItems.NOTIFICA_AUTOR;

                    }

                    //cambiacbtipo(hdfItemCategoriaCodigo.Value); 

                }
            }
            catch (Exception)
            {

            }
            return vm;
        }

        private void funcMostOpcionResuelve(VM_Proveido vm, String valor)
        {
            if (valor == "0000001")//Conceder
            {
                vm.chkConceder = true;
                vm.chkImprocedente = false;
                vm.chkInadmisible = false;
            }
            else if (valor == "0000002")//Improcedente
            {
                vm.chkConceder = false;
                vm.chkImprocedente = true;
                vm.chkInadmisible = false;
            }
            else if (valor == "0000003")//Inadmisible
            {
                vm.chkConceder = false;
                vm.chkImprocedente = false;
                vm.chkInadmisible = true;
            }
            else
            {
                vm.chkConceder = false;
                vm.chkImprocedente = false;
                vm.chkInadmisible = false;
            }
        }
        private void initBusquedaModal(string asCodTipo, VM_Proveido vm)
        {
            List<Ent_SBusqueda> listCombo = new List<Ent_SBusqueda>();
            Ent_SBusqueda Combo = new Ent_SBusqueda();
            vm.sBusqueda = new List<Ent_SBusqueda>();

            switch (asCodTipo)
            {
                case "0000175"://Mandatos
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_NUMERO";
                    Combo.Text = "Informes OSINFOR";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "IAF_NUMERO";
                    Combo.Text = "Informe Autoridad Forestal";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);

                    vm.txtTituloModal = "Lista de Informes o Expedientes Administrativos";
                    break;

                case "0000061": // Archivo
                case "0000122": // Proveído Cierre Informes (Caso Especial)
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_NUMERO";
                    Combo.Text = "Informes OSINFOR";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "IAF_NUMERO";
                    Combo.Text = "Informe Autoridad Forestal";
                    listCombo.Add(Combo);

                    vm.txtTituloModal = "Lista de Informes de Supervisión, Suspensión, Cancelación y/o Técnicos";
                    break;
                case "0000062": // Firme acto administrativo
                case "0000185": // Memorándum Firme Acto Administrativo
                case "0000064": // Fallecimiento titular
                case "0000067": // Agotada la via administrativa
                case "0000184": // Memorándum Agotada la Vía Administrativa
                case "0000076": // Dispocision judicial
                case "0000077": // Nueva notificacion
                case "0000078": // Proveído Admisibilidad y Procedencia del Recurso de Apelación
                case "0000079": // Proveído Dejar Sin Efecto Proveído de Firmeza
                case "0000087": // Proveído Otros
                case "0000113": // Proveído Continuación de PAU
                case "0000123": // Proveído Declarar Cumplimiento Medida Correctiva
                case "0000127": // Proveído de Cumplimiento de Mandato Judicial
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_NUMERO_EXP";
                    Combo.Text = "Nro. Informe Sup.";
                    listCombo.Add(Combo);

                    vm.txtTituloModal = "Lista de Expedientes Administrativos";
                    break;
                case "0000106": // Proveído Archivo Informe Quinquenal
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_QUINQ";
                    Combo.Text = "Nro Informe Quinquenal";
                    listCombo.Add(Combo);

                    vm.txtTituloModal = "Lista de Expedientes Administrativos";
                    break;

            }

            vm.sBusqueda = listCombo;
            CEntidad oCampos2 = new CEntidad();
            oCampos2.BusFormulario = "PROVEIDOARCH";
            oCampos2 = RegMostCombo(oCampos2);
            vm.ListOD = oCampos2.ListODs;
            vm.ListMComboTipoFirmeza = oCampos2.ListMComboTipoFirmeza;
            vm.ListMComboTipoAgotadaVia = oCampos2.ListMComboTipoAgotadaVia;
            vm.ListMComboTipoMedidas = oCampos2.ListMComboTipoMedidas;
            vm.ListMComboTipoArchivo = oCampos2.ListMComboTipoArchivo;
            vm.ListMComboEmiteConst = oCampos2.ListMComboEmiteConst;
            ///para el combo de firmeza
            listCombo = new List<Ent_SBusqueda>();
            Combo = new Ent_SBusqueda();
            Combo.Value = "0000000";
            Combo.Text = "Seleccionar";
            listCombo.Add(Combo);
            Combo = new Ent_SBusqueda();
            Combo.Value = "SI";
            Combo.Text = "Firme administrativamente";
            listCombo.Add(Combo);
            Combo = new Ent_SBusqueda();
            Combo.Value = "NO";
            Combo.Text = "No firme";
            listCombo.Add(Combo);
            vm.ListComboFirmeza = listCombo;
            ///para el combo de de sub tipo agotada 
            listCombo = new List<Ent_SBusqueda>();
            Combo = new Ent_SBusqueda();
            Combo.Value = "SN";
            Combo.Text = "Seleccionar";
            listCombo.Add(Combo);
            Combo = new Ent_SBusqueda();
            Combo.Value = "S";
            Combo.Text = "Si";
            listCombo.Add(Combo);
            Combo = new Ent_SBusqueda();
            Combo.Value = "N";
            Combo.Text = "No";
            listCombo.Add(Combo);
            Combo = new Ent_SBusqueda();
            Combo.Value = "EP";
            Combo.Text = "En Parte";
            listCombo.Add(Combo);
            vm.ListComboSubAgotada = listCombo;
            listCombo = new List<Ent_SBusqueda>();
            Combo = new Ent_SBusqueda();
            Combo.Value = "0000000";
            Combo.Text = "Seleccionar";
            listCombo.Add(Combo);
            Combo = new Ent_SBusqueda();
            Combo.Value = "GORE";
            Combo.Text = "Gobierno Regional";
            listCombo.Add(Combo);
            Combo = new Ent_SBusqueda();
            Combo.Value = "PJ";
            Combo.Text = "Poder Judicial";
            listCombo.Add(Combo);
            vm.ListComboNotPJ = listCombo;
        }

        private void ValidarDatos(VM_Proveido _dto)
        {
            if (_dto.vmControlCalidad.ddlIndicadorId == "0000000") throw new Exception("Seleccione el estado actual del registro");
            if (string.IsNullOrEmpty(_dto.txtFechaEmision)) throw new Exception("Seleccione la fecha de emisión");
            if (_dto.ListInfOrExp == null) throw new Exception("Seleccione un informe, expediente");
            if (_dto.txtResolucionDirectoral == null) throw new Exception("Ingrese Resolución Directoral");
            if (_dto.txtResolucionTribunal == null && _dto.hdfCodTipoProve == "0000184") throw new Exception("Ingrese Resolución Tribunal");
            if (_dto.chkResFundado == false && 
                _dto.chkResInfundado == false &&
                _dto.chkResImprocedente == false &&
                _dto.txtResuelve == null &&
                _dto.hdfCodTipoProve == "0000184") throw new Exception("Ingrese texto resuelve o seleccione alguna opción");
            //if (_dto.hdfCodTipoIlegal == "0000001" && _dto.txtIdRecomendacion == "0000000") throw new Exception("Seleccione una recomendación");
        }

        private String funcOpcionResuelve(bool ch1, bool ch2, bool ch3)
        {
            String resul = "";
            if (ch1) resul = "0000001";//Conceder
            else if (ch2) resul = "0000002";//Improcedente
            else if (ch3) resul = "0000003";//Inadmisible
            else resul = "0000000";
            return resul;
        }

        public ListResult GuardarDatos(VM_Proveido _dto, string codCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                this.ValidarDatos(_dto);
                CEntidad oCEntidadProv = new CEntidad();

                oCEntidadProv.COD_FCTIPO = _dto.hdfCodTipoProve;
                oCEntidadProv.COD_UCUENTA = codCuenta;
                oCEntidadProv.COD_PROVEIDOARCH = _dto.hdfCodProvedio;
                //string tipo = "";

                oCEntidadProv.FECHA = Convert.ToDateTime(_dto.txtFechaEmision);
                oCEntidadProv.RESOLDIRECTORAL = _dto.txtResolucionDirectoral;
                oCEntidadProv.RESOLTRIBUNAL = _dto.txtResolucionTribunal;
                oCEntidadProv.RESUEL_FUNDADO = _dto.chkResFundado;
                oCEntidadProv.RESUEL_INFUNDADO = _dto.chkResInfundado;
                oCEntidadProv.RESUEL_IMPROCEDENTE = _dto.chkResImprocedente;

                oCEntidadProv.REFERENCIA = _dto.txtReferencia;
                oCEntidadProv.RECOMENDACION = _dto.txtRecomienda;
                oCEntidadProv.OBSERVACION = _dto.txtObservaciones;
                oCEntidadProv.COD_OD_REGISTRO = _dto.txtIdODs;
                oCEntidadProv.OUTPUTPARAM01 = "";
                oCEntidadProv.RESUELVE = _dto.txtResuelve;

                oCEntidadProv.COD_ESTADO_DOC = _dto.vmControlCalidad.ddlIndicadorId;
                oCEntidadProv.OBSERVACIONES_CONTROL = _dto.vmControlCalidad.txtControlCalidadObservaciones;
                oCEntidadProv.OBSERV_SUBSANAR = _dto.vmControlCalidad.chkObsSubsanada;



                //cambios 26/10/2016
                oCEntidadProv.NSUPERV_RECOM = _dto.chkNuevSuperv;
                oCEntidadProv.EVIDENCIA_IRREG = _dto.chkEvidIrregular;
                oCEntidadProv.SIN_INDICIOS = _dto.chkSinIndicios;
                oCEntidadProv.DEFICIENCIA_NOTIFICACION = _dto.chkDefNot;
                oCEntidadProv.DEFICIENCIA_TECNICA = _dto.chkDefTec;
                oCEntidadProv.MUERTE_TITULAR = _dto.chkFallTit;
                oCEntidadProv.ARCHIVO_TEMPORAL = _dto.chkArchTemp;
                oCEntidadProv.SUBSANACION_VOLUNTARIA = _dto.chkSubsVoluntaria;
                oCEntidadProv.DESCRIPCION_SUBSANACION_VOLUNTARIA = _dto.txtSubsVoluntaria;
                oCEntidadProv.OTROS_TIPOS = _dto.txtOtros;
                //cambios para la notificacion
                oCEntidadProv.TITULAR_NOT = _dto.chkTitular;
                oCEntidadProv.DETALLE_TITULAR_NOT = _dto.txtTitular;
                oCEntidadProv.DGFFS = _dto.chkDGFFS;
                oCEntidadProv.DETALLE_DGFFS = _dto.txtDescDGFFS;
                oCEntidadProv.PROGRAMA_REGIONAL = _dto.chkProgramaRegional;
                oCEntidadProv.DETALLE_PROREG = _dto.txtDescProgramaRegional;
                oCEntidadProv.MINISTERIO_PUBLICO = _dto.chkMinPublico;
                oCEntidadProv.DETALLE_MINPUB = _dto.txtDescMinPublico;
                oCEntidadProv.MIN_ENERGIA_MINAS = _dto.chkMINEMMIN;
                oCEntidadProv.DETALLE_MINENMIN = _dto.txtDescMINEMMIN;
                oCEntidadProv.COLEGIO_INGENIEROS = _dto.chkColegioIng;
                oCEntidadProv.DETALLE_COLING = _dto.txtDescColegioIng;
                oCEntidadProv.ATFFS = _dto.chkATFFS;
                oCEntidadProv.DETALLE_ATFFS = _dto.txtDescATFFS;
                oCEntidadProv.OCI = _dto.chkOCI;
                oCEntidadProv.DETALLE_OCI = _dto.txtDescOCI;
                oCEntidadProv.OEFA = _dto.chkOEFA;
                oCEntidadProv.DETALLE_OEFA = _dto.txtDescOEFA;
                oCEntidadProv.SUNAT = _dto.chkSUNAT;
                oCEntidadProv.DETALLE_SUNAT = _dto.txtDescSUNAT;
                oCEntidadProv.SERFOR = _dto.chkSERFOR;
                oCEntidadProv.DETALLE_SERFOR = _dto.txtDescSERFOR;
                oCEntidadProv.CONTABILIDAD = _dto.chkConta;
                oCEntidadProv.DETALLE_CONTA = _dto.txtContaDetalle;
                oCEntidadProv.TESORERIA = _dto.chktesoreria;
                oCEntidadProv.DETALLE_TESO = _dto.txtTesoreriaOsinfor;
                oCEntidadProv.OTROS = _dto.chkOTROS;
                oCEntidadProv.DETALLE_OTROS = _dto.txtDescOTROS;
                oCEntidadProv.COD_TRAMITE_ENVIO = string.IsNullOrEmpty(_dto.txtCodDocumentoSITD) ? -1 : Convert.ToInt32(_dto.txtCodDocumentoSITD);

                switch (oCEntidadProv.COD_FCTIPO)
                {
                    case "0000061":
                        oCEntidadProv.MAE_TIP_PROVARCHIVO = _dto.txtIdSobArchivo;
                        oCEntidadProv.DESCRIPCION_PROVARCHIVO = _dto.txtIdSobArchivo == "0000006" ? _dto.txtSobreArchivo : null;
                        oCEntidadProv.MAE_TIP_MEDIDAS = _dto.txtIdMedida;
                        oCEntidadProv.DESCRIPCION_MEDIDAS = _dto.txtIdMedida == "0000008" || _dto.txtIdMedida == "0000009" ? _dto.txtDictaMedida : null;
                        oCEntidadProv.MAE_TIP_CONSTANCIA = _dto.txtIdEmiteConst;
                        oCEntidadProv.COD_DLINEA = _dto.hdfTipoProveido;
                        if (_dto.hdfTipoProveido == "0000006")
                        {
                            oCEntidadProv.RECOMIENDA_NUEVA_SUPERV = _dto.chkNuevSuperv;
                            oCEntidadProv.INCUMPLE_DIRECTIVA_SUPERV = _dto.chkIncumpleDirectiva;
                        }
                        break;
                    case "0000078":
                        oCEntidadProv.COD_RESUELVE = funcOpcionResuelve(_dto.chkConceder, _dto.chkImprocedente, _dto.chkInadmisible);
                        if (_dto.chkConceder)
                        {
                            oCEntidadProv.TRIBUNAL_FFS = _dto.chkTFFS;
                            oCEntidadProv.DETALLE_TRIBUNAL_FFS = _dto.txtDesTFFS;
                        }
                        else
                        {
                            oCEntidadProv.TRIBUNAL_FFS = false;
                            oCEntidadProv.DETALLE_TRIBUNAL_FFS = "";
                        }
                        break;
                    case "0000087":
                        oCEntidadProv.RESUELVE = _dto.txtResuelve;
                        break;
                    case "0000123":
                        if (_dto.txtFechaCumpleMCorrectiva != null)
                        {
                            if (_dto.txtFechaCumpleMCorrectiva.Trim() != "")
                            {
                                oCEntidadProv.FECHA_CUMPLE_MCORRECTIVA = Convert.ToDateTime(_dto.txtFechaCumpleMCorrectiva);
                            }
                        }
                        oCEntidadProv.CUMPLE_MCORRECTIVA = _dto.chkCumpleMCorrectiva;
                        oCEntidadProv.DISPONE_CUMPLE_MCORRECTIVA = _dto.CumpleMCorrectivaDetalle;
                        break;
                    case "0000062":
                    case "0000185":
                        if (_dto.txtFechaFirmezaF != null)
                        {
                            if (_dto.txtFechaFirmezaF.Trim() != "")
                            {
                                oCEntidadProv.FECHA_FIRMEZA = Convert.ToDateTime(_dto.txtFechaFirmezaF);
                            }
                        }

                        break;
                    case "0000127":
                        oCEntidadProv.MED_CAUTELAR = _dto.chkMedCaut;
                        oCEntidadProv.CADUCIDAD = _dto.chckCaducidad;
                        oCEntidadProv.INFRACCIONES = _dto.chkInfraccion;
                        oCEntidadProv.PJ_PM = _dto.chkPM;
                        oCEntidadProv.PJ_GTF = _dto.chkGTF;
                        oCEntidadProv.PJ_TROZAS = _dto.chkTrozas;
                        oCEntidadProv.NUM_EXPPJ = _dto.txtExpedientePJ;
                        oCEntidadProv.NUM_JUZGADO = _dto.txtJuzagdo;
                        if (_dto.txtFechaJud != null)
                        {
                            if (_dto.txtFechaJud.Trim() != "")
                            {
                                oCEntidadProv.FECHA_PJ = Convert.ToDateTime(_dto.txtFechaJud);
                            }
                        }
                        oCEntidadProv.PLAZO_PJ = _dto.txtPlazoJud.ToString();
                        oCEntidadProv.RESUM_PJ = _dto.txtMandatoJudicial;
                        oCEntidadProv.CADUCIDADPARCIAL = _dto.chkCaducidadParte;
                        oCEntidadProv.NOTIFICA_AUTOR = _dto.txtIdNotPJ;
                        oCEntidadProv.OBSERVACIONES_TSC = _dto.txtObservacionesTSC;
                        break;
                }

                //21/09/2017
                oCEntidadProv.MAE_TIP_PROVFIRMEZA = _dto.txtIdTipoFirmeza;
                if (oCEntidadProv.MAE_TIP_PROVFIRMEZA == "0000002")
                {
                    if (_dto.txtIdCaducidaF != "0000000")
                        oCEntidadProv.CADUCIDAD_FIRME = _dto.txtIdCaducidaF == "SI" ? true : false;
                    if (_dto.txtIdArt363IF != "0000000")
                        oCEntidadProv.ART363I_FIRME = _dto.txtIdArt363IF == "SI" ? true : false;
                    if (_dto.txtIdMultaF != "0000000")
                        oCEntidadProv.MULTA_FIRME = _dto.txtIdMultaF == "SI" ? true : false;
                    if (_dto.txtIdMedcorrectivaF != "0000000")
                        oCEntidadProv.MCORRECTIVA_FIRME = _dto.txtIdMedcorrectivaF == "SI" ? true : false;
                }
                oCEntidadProv.MAE_TIP_AGOTAVIAADM = _dto.txtIdTipoAgotada;
                if (oCEntidadProv.MAE_TIP_AGOTAVIAADM == "0000004")
                {
                    oCEntidadProv.CONFIRM_RESOL = _dto.txtIdConfirRD;
                }

                //fin de cambios
                oCEntidadProv.RegEstado = _dto.RegEstado;
                oCEntidadProv.ListInformes = _dto.ListInfOrExp;
                oCEntidadProv.ListadoFuncionario = _dto.ListFuncionario;
                oCEntidadProv.ListEliTABLA = _dto.listEliTabla;
                if (_dto.listEliTablaProf != null)
                {
                    foreach (Ent_PROVEIDOARCHIVO eli in _dto.listEliTablaProf)
                    {
                        oCEntidadProv.ListEliTABLA.Add(eli);
                    }
                }
                //oCEntidadProv.RESUELVE = _dto.txtSeDispone;

                var estado_final = this.RegProveidoArchivo_Grabar(oCEntidadProv);
                result.AddResultado("Proveido se Guardo Correctamente", true);

            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }
    }
}
