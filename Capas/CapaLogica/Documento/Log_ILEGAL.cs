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
using CDatos = CapaDatos.DOC.Dat_ILEGAL;
using CEntidad = CapaEntidad.DOC.Ent_ILEGAL;
namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Log_ILEGAL
    {
        private CDatos oCDatos = new CDatos();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public String RegILEGAL_Grabar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegILEGAL_Grabar(cn, oCampoEntrada);
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
        //public CEntidad RegMostrarListaILEGALItem(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarListaILEGALItem(cn, oCampoEntrada);
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
        //public List<CEntidad> RegMostrarINFORME_Bucar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarINFORME_Bucar(cn, oCampoEntrada);
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
        public Int32 RegPreProcesarObservatorio(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegPreProcesarObservatorio(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public Int32 RegPublicarObservatorio(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegPublicarObservatorio(cn, oCampoEntrada);
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
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public CEntidad RegMostListPOAs(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostListPOAs(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<CEntidad> List_EncisosIL(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.List_EncisosIL(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public CEntidad RegMostCombo(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region v3 oracle
        public VM_InformeLegal initIlegal(string asCodILegal, string asCodTipo)
        {
            VM_InformeLegal vm = new VM_InformeLegal();
            try
            {
                Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
                vm.lblTituloCabecera = "Informe Legal";
                if (String.IsNullOrEmpty(asCodILegal))
                {
                    vm.lblTituloEstado = "Nuevo Registro";
                    //inicializando control de calidad
                    vm.vmControlCalidad = new VM_ControlCalidad_2();
                    vm.vmControlCalidad.ddlIndicadorId = "0000000";
                    vm.hdfCodTipoIlegal = asCodTipo;
                    this.initBusquedaModal(asCodTipo, vm);
                    vm.sRecomendaciones = this.comboRecomendacionesV3();
                    vm.listaArticulos = initArticulos("ARTICULOS", "");
                    vm.listaEspeciesCombo = initArticulos("ESPECIES", "");
                    //listas iniciales
                    vm.tbInforme = new List<Ent_INFORME_CONSULTA_LEGAL>();
                    vm.listaInfracciones = new List<CEntidad>();
                    vm.listaEspeciesAP = new List<CEntidad>();
                    vm.listaEspeciesMC = new List<CEntidad>();
                    vm.listaInfraccionesRR = new List<CEntidad>();
                    vm.tbEliTABLA = new List<CEntidad>();
                    vm.tbEliTABLAEnciso = new List<CEntidad>();
                    vm.tbEliTABLAEspecie = new List<CEntidad>();
                    vm.tbEliTABLAEspecieAP = new List<CEntidad>();
                    vm.RegEstado = 1;//nuevo

                    //20/09/2022 TGS
                    vm.ListSTD01 = new List<CEntidad>();
                    vm.ListSTD02 = new List<CEntidad>();
                    vm.listaArticulosSubsanables = initArticulos("ARTICULOS_SUBSANADOS", "");
                    vm.listaInfraccionesSubsanadas = new List<CEntidad>();

                    switch (asCodTipo)
                    {
                        case "0000001"://Evaluación del Informe de Supervision  
                            vm.txtTipoInfLegal = "Evaluación del Informe de Supervision";
                            break;

                        case "0000002"://Evaluación de la Etapa Instructiva  
                            vm.txtTipoInfLegal = "Evaluación de la Etapa Instructiva";
                            break;
                        case "0000107": //Final de Instrucción
                            vm.txtTipoInfLegal = "Final de Instrucción";
                            break;
                        case "0000108":
                            vm.txtTipoInfLegal = "De fase decisora";
                            break;
                        case "0000003"://De Conformidad
                            vm.txtTipoInfLegal = "De Conformidad";
                            break;

                        case "0000004"://Evaluación del Recurso de Reconsideración     
                            vm.txtTipoInfLegal = "Evaluación del Recurso de Reconsideración";
                            break;
                        case "0000005"://Otros  
                            vm.txtTipoInfLegal = "Otros";
                            break;
                        case "0000129"://Aplicación de Medidas Cautelares (Antes del PAU)  
                            vm.txtTipoInfLegal = "Aplicación de Medidas Cautelares (Antes del PAU)";
                            break;
                    }
                }
                else
                {
                    CEntidad datInfLegal = oCDatos.RegMostrarItem_v3(new CEntidad() { v_COD_ILEGAL = asCodILegal });

                    vm.lblTituloCabecera = "Modificando Registro";
                    vm.hdfCodInfLegal = asCodILegal;
                    vm.hdfCodTipoIlegal = datInfLegal.COD_FCTIPO;
                    vm.txtTipoInfLegal = datInfLegal.TIPO_FISCALIZA;
                    vm.txtNumIlegal = datInfLegal.ILEGAL_NUMERO;
                    vm.txtProfesional = datInfLegal.APELLIDOS_NOMBRES;
                    vm.hdfCodProfesional = datInfLegal.COD_PROFESIONAL;
                    vm.txtFechaLegal = datInfLegal.ILEGAL_FECHA_EMISION.ToString();
                    vm.txtPresentoProyecto = (bool)datInfLegal.PRESENTO_PROYECTO_RD;
                    vm.txtInfDirectoral = (bool)datInfLegal.INFDIR;
                    vm.txtInfSubDirectoral = (bool)datInfLegal.INFSUBDIR;
                    vm.txtObservaciones = datInfLegal.OBSERVACION;

                    //control de calidad
                    vm.vmControlCalidad = new VM_ControlCalidad_2();
                    vm.vmControlCalidad.ddlIndicadorId = datInfLegal.COD_ESTADO_DOC;
                    vm.vmControlCalidad.txtUsuarioRegistro = datInfLegal.USUARIO_REGISTRO;
                    vm.vmControlCalidad.txtUsuarioControl = datInfLegal.USUARIO_CONTROL;
                    vm.vmControlCalidad.chkObsSubsanada = (bool)datInfLegal.OBSERV_SUBSANAR;
                    vm.vmControlCalidad.txtControlCalidadObservaciones = datInfLegal.OBSERVACIONES_CONTROL.ToString();

                    //recomendadiones
                    vm.txtIdRecomendacion = datInfLegal.COD_ILEGAL_INF_SUP_TIPO;

                    //lista de expedientes
                    vm.tbInforme = datInfLegal.ListInformesTemp;
                    this.initBusquedaModal(datInfLegal.COD_FCTIPO, vm);
                    //combos iniciales
                    vm.sRecomendaciones = this.comboRecomendacionesV3();
                    vm.listaArticulos = initArticulos("ARTICULOS", "");
                    //lista de las especies en el combo
                    vm.listaEspeciesCombo = initArticulos("ESPECIES", "");
                    vm.listaIncisos = new List<Ent_SBusqueda>();
                    //lista de infracciones 
                    vm.listaInfracciones = datInfLegal.ListIncisos;
                    vm.listaEspeciesMC = datInfLegal.ListEspeciesMCorrectiva;

                    //archivo
                    vm.chkNuevaSupervision = (bool)datInfLegal.NSUPERV_RECOM;
                    vm.chkEvidencia = (bool)datInfLegal.EVIDENCIA_IRREGULARIDAD;
                    vm.chkSinIndicios = (bool)datInfLegal.BUEN_MANEJO;
                    vm.chkDeficienciaNot = (bool)datInfLegal.DEFICIENCIA_NOTIFICACION;
                    vm.chkDeficienciaTec = (bool)datInfLegal.DEFICIENCIA_TECNICA;
                    vm.chkFallecimientoTitular = (bool)datInfLegal.MUERTE_TITULAR;
                    vm.txtOtros = datInfLegal.ARCHIVOS_OTROS;
                    vm.chkMedidasCorrectivas = (bool)datInfLegal.MCORRECTIVA;
                    vm.txtDescMedidadCorrectivas = datInfLegal.DESCRIPCION_MCORRECTIVA;
                    vm.chkMandato = (bool)datInfLegal.MANDATO;
                    vm.txtDescMandato = datInfLegal.DESCRIPCION_MANDATO;

                    //dias de implementacion e informe de mandatos correctivas
                    vm.txtImplMCDias = datInfLegal.DIA_IMPLEMENT_MCORRECTIVA.ToString();
                    vm.txtImplMCMeses = datInfLegal.MES_IMPLEMENT_MCORRECTIVA.ToString();
                    vm.txtImplMCAnio = datInfLegal.ANIO_IMPLEMENT_MCORRECTIVA.ToString();
                    vm.txtInfMCDia = datInfLegal.DIA_INFORME_MCORRECTIVA.ToString();
                    vm.txtInfMCMeses = datInfLegal.MES_INFORME_MCORRECTIVA.ToString();
                    vm.txtInfMCAnio = datInfLegal.ANIO_INFORME_MCORRECTIVA.ToString();

                    // para tipo de informe legal otros
                    vm.txtMotivoOtros = datInfLegal.MOTIVO;
                    vm.txtRecomendacionOtros = datInfLegal.RECOMENDACION;

                    //para el tipo Aplicacion de medidas cautelares antes del PAU
                    vm.chkGTF = (bool)datInfLegal.GTF;
                    vm.chkLTrozas = (bool)datInfLegal.LIST_TROZAS;
                    vm.chkPlanManejo = (bool)datInfLegal.PLAN_MANEJO;
                    vm.chkPOA = (bool)datInfLegal.POA2;
                    vm.chkPorEspecie = (bool)datInfLegal.ESPECIES;
                    vm.txtDescMedidasCautelaresAP = datInfLegal.DESCRIPCION;
                    vm.txtRecomendacionesAP = datInfLegal.RECOMENDACION_IA;
                    vm.cod_IAlerta = datInfLegal.COD_ILEGAL_IALERTA_DETALLE;
                    vm.listaEspeciesAP = datInfLegal.ListEspecies;

                    //Evaluacion del recurso de reconsideracion 
                    vm.chkMedCautelarRR = (bool)datInfLegal.MEDIDA_CAUTELAR;
                    vm.chkFinPauRR = (bool)datInfLegal.FIN_PAU;
                    vm.chkImprocedenteRR = (bool)datInfLegal.IMPROCEDENTE;
                    vm.chkFueraPlazoRR = (bool)datInfLegal.FUERA_PLAZO;
                    vm.chkFaltaPruebasRR = (bool)datInfLegal.FALTA_PRUEBAS;
                    vm.chkProcedenteRR = (bool)datInfLegal.PROCEDENTE;
                    vm.chkFundadoRR = (bool)datInfLegal.FUNDADA;
                    vm.chkFundadoParteRR = (bool)datInfLegal.FUNDADA_PARTE;
                    vm.chkInfundadoRR = (bool)datInfLegal.INFUNDADA;
                    vm.txtInfundadoObsRR = (string)datInfLegal.INFUNDADO_OBS;
                    vm.txtPruebasPresentadasRR = datInfLegal.PRUEBAS_PRESENTADAS;
                    if (vm.chkInfundadoRR == true)
                    {
                        if (vm.tbInforme.Count > 0)
                        {
                            vm.listaInfraccionesRR = busInfraccionesRD(vm.tbInforme, "0000011");

                        }
                    }

                    //final de instruccion
                    vm.chkInspeccionOcularFI = (bool)datInfLegal.INSPECCION_OCULAR;
                    vm.chkEmitirRDFI = (bool)datInfLegal.EMITIR_RD_FINAL;
                    vm.chkSancionFI = (bool)datInfLegal.SANCION;
                    vm.chkMedidaCorrectivaRDFI = (bool)datInfLegal.MEDIDAS_CORRECTIVAS;
                    vm.chkAmonestacionesFI = (bool)datInfLegal.AMONESTACIONES;
                    vm.chkArchivoFI = (bool)datInfLegal.ARCHIVO;
                    vm.chkCaducidadRDFI = (bool)datInfLegal.CADUCIDAD;
                    vm.chkMedidasProvisoriasFI = (bool)datInfLegal.MEDIDA_PREVISORIA;
                    vm.txtMedidasProvisoriasFI = datInfLegal.MEDIDA_PREVISORIA_OBS;
                    vm.chkAmpliacionFI = (bool)datInfLegal.AMPLIACION_PAU;
                    vm.chkAcumulacionFI = (bool)datInfLegal.ACUMULACION_PAU;
                    vm.chkNuevaSupervisionFI = (bool)datInfLegal.NUEVA_SUPERVISION;
                    vm.chkNuevaNotificacionFI = (bool)datInfLegal.NUEVA_NOTIFICACION;
                    vm.chkRectificacionFI = (bool)datInfLegal.RECTIFICACION_EMATERIAL;
                    vm.txtVariarMedCaut = datInfLegal.VARIAR_MED_CAUT;
                    vm.txtOtrosFI = datInfLegal.OTROS_EVA_INSTRUCTIVA;

                    vm.RegEstado = 0; //editar
                    vm.chkPublicar = (bool)datInfLegal.PUBLICAR;
                    vm.chkConforme = (bool)datInfLegal.CONFORME;
                    //vm.txtobservaciones = datInfLegal.OBESERVACIONES;
                    vm.tbEliTABLA = new List<CEntidad>();
                    vm.tbEliTABLAEnciso = new List<CEntidad>();
                    vm.tbEliTABLAEspecie = new List<CEntidad>();
                    vm.tbEliTABLAEspecieAP = new List<CEntidad>();

                    vm.chkInexEspecie = (bool)datInfLegal.IF_INEXESP;
                    vm.chkDifEspecie = (bool)datInfLegal.IF_DIFESP;
                    vm.chkSobreEstimacion = (bool)datInfLegal.IF_SOBREVOL;

                    vm.hdfCodigoIlegalAlerta = datInfLegal.COD_ILEGAL_IALERTA_DETALLE;

                    //20/09/2022 TGS
                    vm.ListSTD01 = datInfLegal.listSTD01;
                    vm.ListSTD02 = datInfLegal.listSTD02;
                    vm.chkTerceroSolidario = (datInfLegal.COD_TERCERO_SOLIDARIO.Trim() == "") ? false : true;
                    vm.hdfCodTerceroSolidario = datInfLegal.COD_TERCERO_SOLIDARIO;
                    vm.txtTerceroSolidario = datInfLegal.TERCERO_SOLIDARIO;
                    vm.listaArticulosSubsanables = initArticulos("ARTICULOS_SUBSANADOS", "");
                    vm.listaInfraccionesSubsanadas = datInfLegal.ListIncisosSubsanados;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vm;
        }

        private void ValidarDatos(VM_InformeLegal _dto)
        {
            if (_dto.vmControlCalidad.ddlIndicadorId == "0000000") throw new Exception("Seleccione el estado actual del registro");
            //if (string.IsNullOrEmpty(_dto.txtNumIlegal)) throw new Exception("Ingrese el número de informe legal");
            if (string.IsNullOrEmpty(_dto.txtFechaLegal)) throw new Exception("Seleccione la fecha de emisión");
            if (_dto.tbInforme == null) throw new Exception("Seleccione un informe, expediente");
            if (_dto.hdfCodProfesional == null) throw new Exception("Seleccione Responsable del Informe");
            if (_dto.hdfCodTipoIlegal == "0000001" && _dto.txtIdRecomendacion == "0000000") throw new Exception("Seleccione una recomendación");
        }

        //metodo para guardar los registros
        public ListResult GuardarDatosInfLegal(VM_InformeLegal _dto, string asCodUCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                this.ValidarDatos(_dto);
                CEntidad paramIL = new CEntidad();
                paramIL.COD_FCTIPO = _dto.hdfCodTipoIlegal;
                paramIL.COD_ILEGAL = _dto.hdfCodInfLegal;
                paramIL.RegEstado = _dto.RegEstado;
                paramIL.PUBLICAR = _dto.chkPublicar;

                paramIL.ILEGAL_NUMERO = _dto.txtNumIlegal;
                paramIL.ILEGAL_FECHA_EMISION = Convert.ToDateTime(_dto.txtFechaLegal);

                paramIL.PRESENTO_PROYECTO_RD = _dto.txtPresentoProyecto;
                paramIL.INFDIR = _dto.txtInfDirectoral;
                paramIL.INFSUBDIR = _dto.txtInfSubDirectoral;

                paramIL.COD_PROFESIONAL = _dto.hdfCodProfesional;
                paramIL.COD_UCUENTA = asCodUCuenta;
                paramIL.OBSERVACION = _dto.txtObservaciones;
                paramIL.COD_OD_REGISTRO = "0000001";

                //control de calidad
                paramIL.COD_ESTADO_DOC = _dto.vmControlCalidad.ddlIndicadorId;
                paramIL.OBSERVACIONES_CONTROL = _dto.vmControlCalidad.txtControlCalidadObservaciones;
                paramIL.OBSERV_SUBSANAR = _dto.vmControlCalidad.chkObsSubsanada;

                paramIL.OUTPUTPARAM01 = "";
                if (_dto.tbEliTABLA != null)
                {
                    paramIL.ListEliTABLA = _dto.tbEliTABLA;
                }

                if (paramIL.COD_FCTIPO == "0000001")
                {
                    //inicio pau
                    paramIL.IF_INEXESP = _dto.chkInexEspecie;
                    paramIL.IF_DIFESP = _dto.chkDifEspecie;
                    paramIL.IF_SOBREVOL = _dto.chkSobreEstimacion;
                    //archivo 
                    paramIL.COD_ILEGAL_ENCISOS = "";
                    paramIL.COD_ILEGAL_INF_SUP_TIPO = _dto.txtIdRecomendacion;
                    paramIL.EVIDENCIA_IRREGULARIDAD = _dto.chkEvidencia;
                    paramIL.BUEN_MANEJO = _dto.chkSinIndicios;
                    paramIL.DEFICIENCIA_NOTIFICACION = _dto.chkDeficienciaNot;
                    paramIL.DEFICIENCIA_TECNICA = _dto.chkDeficienciaTec;
                    paramIL.ARCHIVOS_OTROS = _dto.txtOtros;
                    paramIL.DESCRIPCION = _dto.txtDescMedidasCautelaresAP;
                    paramIL.MUERTE_TITULAR = _dto.chkFallecimientoTitular;
                    paramIL.NSUPERV_RECOM = _dto.chkNuevaSupervision;
                    paramIL.MCORRECTIVA = _dto.chkMedidasCorrectivas;
                    if ((Boolean)paramIL.MCORRECTIVA)
                    {
                        paramIL.DESCRIPCION_MCORRECTIVA = _dto.txtDescMedidadCorrectivas;
                        paramIL.DIA_IMPLEMENT_MCORRECTIVA = Convert.ToInt32(_dto.txtImplMCDias);
                        paramIL.MES_IMPLEMENT_MCORRECTIVA = Convert.ToInt32(_dto.txtImplMCMeses);
                        paramIL.ANIO_IMPLEMENT_MCORRECTIVA = Convert.ToInt32(_dto.txtImplMCAnio);
                        paramIL.DIA_INFORME_MCORRECTIVA = Convert.ToInt32(_dto.txtInfMCDia);
                        paramIL.MES_INFORME_MCORRECTIVA = Convert.ToInt32(_dto.txtInfMCMeses);
                        paramIL.ANIO_INFORME_MCORRECTIVA = Convert.ToInt32(_dto.txtInfMCAnio);
                    }
                    else
                    {
                        paramIL.ListEspeciesMCorrectiva = new List<CEntidad>();
                    }

                    paramIL.MANDATO = _dto.chkMandato;
                    if ((Boolean)paramIL.MANDATO)
                    {
                        paramIL.DESCRIPCION_MANDATO = _dto.txtDescMandato;
                    }

                    //agregamos eliminar de las sublistas
                    if (_dto.tbEliTABLAEnciso != null)
                    {
                        if (_dto.tbEliTABLAEnciso.Count > 0)
                        {
                            if (paramIL.ListEliTABLA == null)
                            {
                                paramIL.ListEliTABLA = new List<CEntidad>();
                            }
                            for (int i = 0; i < _dto.tbEliTABLAEnciso.Count; i++)
                            {
                                CEntidad temp = new CEntidad();
                                temp = _dto.tbEliTABLAEnciso[i];
                                paramIL.ListEliTABLA.Add(temp);
                            }
                        }
                    }

                    if (_dto.tbEliTABLAEspecie != null)
                    {
                        if (_dto.tbEliTABLAEspecie.Count > 0)
                        {
                            if (paramIL.ListEliTABLA == null)
                            {
                                paramIL.ListEliTABLA = new List<CEntidad>();
                            }
                            for (int i = 0; i < _dto.tbEliTABLAEspecie.Count; i++)
                            {
                                CEntidad temp = new CEntidad();
                                temp = _dto.tbEliTABLAEspecie[i];
                                paramIL.ListEliTABLA.Add(temp);
                            }
                        }
                    }
                }
                if (paramIL.COD_FCTIPO == "0000002" || paramIL.COD_FCTIPO == "0000107" || paramIL.COD_FCTIPO == "0000108")
                {
                    paramIL.COD_ILEGAL_ENCISOS = "";
                    paramIL.CADUCIDAD = _dto.chkCaducidadRDFI;
                    paramIL.MEDIDAS_CORRECTIVAS = _dto.chkMedidaCorrectivaRDFI;
                    paramIL.SANCION = _dto.chkSancionFI;
                    paramIL.AMONESTACIONES = _dto.chkAmonestacionesFI;
                    paramIL.ARCHIVO = _dto.chkArchivoFI;
                    paramIL.MEDIDA_PREVISORIA = _dto.chkMedidasProvisoriasFI;
                    paramIL.MEDIDA_PREVISORIA_OBS = _dto.txtMedidasProvisoriasFI;
                    paramIL.INSPECCION_OCULAR = _dto.chkInspeccionOcularFI;
                    paramIL.EMITIR_RD_FINAL = _dto.chkEmitirRDFI;
                    paramIL.AMPLIACION_PAU = _dto.chkAmpliacionFI;
                    paramIL.ACUMULACION_PAU = _dto.chkAcumulacionFI;
                    paramIL.NUEVA_SUPERVISION = _dto.chkNuevaSupervisionFI;
                    paramIL.OTROS_EVA_INSTRUCTIVA = _dto.txtOtrosFI;
                    paramIL.NUEVA_NOTIFICACION = _dto.chkNuevaNotificacionFI;
                    paramIL.VARIAR_MED_CAUT = _dto.txtVariarMedCaut;
                    paramIL.RECTIFICACION_EMATERIAL = _dto.chkRectificacionFI;
                    if (_dto.tbEliTABLAEnciso != null)
                    {
                        if (_dto.tbEliTABLAEnciso.Count > 0)
                        {
                            if (paramIL.ListEliTABLA == null)
                            {
                                paramIL.ListEliTABLA = new List<CEntidad>();
                            }
                            for (int i = 0; i < _dto.tbEliTABLAEnciso.Count; i++)
                            {
                                CEntidad temp = new CEntidad();
                                temp = _dto.tbEliTABLAEnciso[i];
                                paramIL.ListEliTABLA.Add(temp);
                            }
                        }
                    }

                    //lista de expedientes de tramite documentario 20/09/2022 TGS
                    paramIL.listSTD01 = _dto.ListSTD01;
                    paramIL.listSTD02 = _dto.ListSTD02;
                    paramIL.listEliTSTD01 = _dto.ListEliTSTD01;
                    paramIL.COD_TERCERO_SOLIDARIO = _dto.hdfCodTerceroSolidario == " " ? null : _dto.hdfCodTerceroSolidario;
                    paramIL.ListIncisosSubsanados = _dto.listaInfraccionesSubsanadas;
                    paramIL.ListEliTABLAIncisosSubsanados = _dto.tbEliTABLAEncisoSubsanado;
                }

                if (paramIL.COD_FCTIPO == "0000003")
                {
                    paramIL.CONFORME = _dto.chkConforme;
                    //paramIL.OBESERVACIONES = _dto.txtobservaciones;
                }
                if (paramIL.COD_FCTIPO == "0000004")
                {
                    paramIL.MEDIDA_CAUTELAR = _dto.chkMedCautelarRR;
                    paramIL.FIN_PAU = _dto.chkFinPauRR;
                    paramIL.IMPROCEDENTE = _dto.chkImprocedenteRR;
                    paramIL.FUNDADA = _dto.chkFundadoRR;
                    paramIL.FUNDADA_PARTE = _dto.chkFundadoParteRR;
                    paramIL.INFUNDADA = _dto.chkInfundadoRR;
                    paramIL.PRUEBAS_PRESENTADAS = _dto.txtPruebasPresentadasRR;
                    paramIL.PROCEDENTE = _dto.chkProcedenteRR;
                    paramIL.INFUNDADO_OBS = _dto.txtInfundadoObsRR;
                    paramIL.FUERA_PLAZO = _dto.chkFueraPlazoRR;
                    paramIL.FALTA_PRUEBAS = _dto.chkFaltaPruebasRR;
                }
                if (paramIL.COD_FCTIPO == "0000005")
                {
                    paramIL.MOTIVO = _dto.txtMotivoOtros;
                    paramIL.RECOMENDACION = _dto.txtRecomendacionOtros;

                }
                if (paramIL.COD_FCTIPO == "0000129")
                {
                    CEntidad oCampos = new CEntidad();
                    paramIL.ListMedCautAPAU = new List<CEntidad>();
                    oCampos.COD_ILEGAL_IALERTA_DETALLE = _dto.hdfCodigoIlegalAlerta;
                    oCampos.GTF = _dto.chkGTF;
                    oCampos.LIST_TROZAS = _dto.chkLTrozas;
                    oCampos.PLAN_MANEJO = _dto.chkPlanManejo;
                    oCampos.POA2 = _dto.chkPOA;
                    oCampos.ESPECIES = _dto.chkPorEspecie;
                    oCampos.DESCRIPCION = _dto.txtDescMedidasCautelaresAP;
                    oCampos.RECOMENDACION_IA = _dto.txtRecomendacionesAP;
                    paramIL.ListMedCautAPAU.Add(oCampos);
                    paramIL.TIPO = "IA";
                    if (_dto.tbEliTABLAEspecieAP != null)
                    {
                        if (_dto.tbEliTABLAEspecieAP.Count > 0)
                        {
                            if (paramIL.ListEliTABLA == null)
                            {
                                paramIL.ListEliTABLA = new List<CEntidad>();
                            }
                            for (int i = 0; i < _dto.tbEliTABLAEspecieAP.Count; i++)
                            {
                                CEntidad temp = new CEntidad();
                                temp = _dto.tbEliTABLAEspecieAP[i];
                                paramIL.ListEliTABLA.Add(temp);
                            }
                        }
                    }


                }
                //pasando las listas
                //paramIL.ListEliTABLA = _dto_pendiente
                paramIL.ListInformesTemp = _dto.tbInforme;
                paramIL.ListIncisos = _dto.listaInfracciones;
                paramIL.ListEspeciesMCorrectiva = _dto.listaEspeciesMC;
                paramIL.ListEspecies = _dto.listaEspeciesAP;

                var OUTPUTPARAM1 = this.RegILEGAL_Grabar(paramIL);

                result.AddResultado("La Muestra se Guardo Correctamente", true, new List<string>() { OUTPUTPARAM1 });
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        public void initBusquedaModal(string codTipoLegal, VM_InformeLegal vm)
        {
            List<Ent_SBusqueda> listCombo = new List<Ent_SBusqueda>();
            Ent_SBusqueda Combo = new Ent_SBusqueda();
            vm.sBusqueda = new List<Ent_SBusqueda>();

            switch (codTipoLegal)
            {
                case "0000001"://Evaluación del Informe de Supervision  
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_QUINQ";
                    Combo.Text = "Inf. Audi. Quinquenal";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "REN_NUMERO";
                    Combo.Text = "Solicitud de Renuncia a la Concesión";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "IAF_NUMERO";
                    Combo.Text = "Informe Autoridad Forestal";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_NUMERO";
                    Combo.Text = "Informes OSINFOR";
                    listCombo.Add(Combo);

                    vm.txtTituloModal = "Lista de Informes de Supervisión, Suspensión, Cancelación y/o Técnicos, Informes quinquenales";
                    break;

                case "0000002"://Evaluación de la Etapa Instructiva  
                case "0000107":
                case "0000108":
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "REN_NUMERO";
                    Combo.Text = "Solicitud de Renuncia a la Concesión";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);

                    vm.txtTituloModal = "Lista de Expedientes Administrativos";
                    break;
                case "0000003"://De Conformidad
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "IAF_NUMERO";
                    Combo.Text = "Informe de la Autoridad Forestal";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_NUMERO";
                    Combo.Text = "Informes OSINFOR";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);

                    vm.txtTituloModal = "Lista de Informes de Supervisión, Suspensión, Cancelación, Técnicos y/o Expedientes Administrativos";
                    break;

                case "0000004"://Evaluación del Recurso de Reconsideración     
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);

                    vm.txtTituloModal = "Lista de Expedientes Administrativos";
                    break;
                case "0000005"://Otros  
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "IAF_NUMERO";
                    Combo.Text = "Informe de la Autoridad Forestal";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_NUMERO";
                    Combo.Text = "Informes OSINFOR";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);

                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_QUINQ";
                    Combo.Text = "Inf. Audi. Quinquenal";
                    listCombo.Add(Combo);

                    vm.txtTituloModal = "Lista de Informes de Supervisión, Suspensión, Cancelación, Técnicos y/o Expedientes Administrativos";
                    break;
                case "0000129"://Aplicación de Medidas Cautelares (Antes del PAU)  
                    listCombo = new List<Ent_SBusqueda>();
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_ALERTA";
                    Combo.Text = "Alerta";
                    listCombo.Add(Combo);

                    vm.txtTituloModal = "Lista de Informes de Supervisión, Suspensión, Cancelación, Técnicos y/o Alertas";
                    break;
            }
            vm.sBusqueda = listCombo;
        }

        public Ent_INFORME_CONSULTA_LEGAL RegMostrar_BucarModal(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarINFORME_Bucar_v3(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ent_SBusqueda> comboRecomendacionesV3()
        {
            try
            {
                CEntidad oCampoEntrada = new CEntidad();
                oCampoEntrada.BusFormulario = "COMBO_INDIVIDUAL";
                oCampoEntrada.BusCriterio = "ILEGAL_RECOMENDACIONES";
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo_V3(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ent_SBusqueda> initArticulos(string criterio, string valor)
        {
            try
            {
                CEntidad oCampoEntrada = new CEntidad();
                oCampoEntrada.BusFormulario = "COMBO_INDIVIDUAL";
                oCampoEntrada.BusCriterio = criterio; //"ARTICULOS";
                oCampoEntrada.BusValor = valor;
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo_V3(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// metodo para importar los encisos
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> InfraccionesRD(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.InfraccionesRD(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> busInfraccionesRD(List<Ent_INFORME_CONSULTA_LEGAL> listaExpedientes, string tipo)
        {
            List<CEntidad> ListainfraccionesTemp = new List<CEntidad>();
            List<CEntidad> ListainfraccionesRD = new List<CEntidad>();

            CEntidad param = new CEntidad();
            for (int i = 0; i < listaExpedientes.Count; i++)
            {
                ListainfraccionesTemp = new List<CEntidad>();
                param = new CEntidad();
                param.BusValor = listaExpedientes[i].COD_RESODIREC_INI_PAU;
                param.BusCriterio = tipo;
                ListainfraccionesTemp = InfraccionesRD(param);
                if (ListainfraccionesTemp.Count > 0)
                {
                    for (int j = 0; j < ListainfraccionesTemp.Count; j++)
                    {
                        ListainfraccionesRD.Add(ListainfraccionesTemp[j]);
                    }
                }
            }
            return ListainfraccionesRD;
        }

        public List<Dictionary<string, string>> registroUsuarioIL(CEntidad oCEntidad)
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

        public ListResult RegistroUsuario(string asCodUsuario)
        {
            ListResult result = new ListResult();

            try
            {
                CEntidad paramCap = new CEntidad();
                //CLogica exeCap = new CLogica();
                paramCap.BusFormulario = "REGISTRO_USUARIO";
                paramCap.BusCriterio = "INFORME_LEGAL";
                paramCap.COD_UCUENTA = asCodUsuario;

                List<Dictionary<string, string>> olResult = registroUsuarioIL(paramCap);

                if (olResult.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/Reg_Usu/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "ILEGAL_REG.xlsx";

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
                                insertar = insertar + ",'" + (itemPart["ILEGAL_NUMERO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["TIPO_FISCALIZA"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["NUMERO_INFORME"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["NUMERO_RESOLUCION"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["NUMERO_EXPEDIENTE"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["USUARIO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["ESTADO_CALIDAD"] ?? "") + "'";
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

        #endregion
    }
}
