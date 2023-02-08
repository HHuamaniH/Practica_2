using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_InformeQuinquenal;
using CEntidad = CapaEntidad.DOC.Ent_InfQuinquenal;

namespace CapaLogica.DOC
{
    public class Log_InformeQuinquenal
    {
        private CDatos oCDatos = new CDatos();
        public List<Dictionary<string, string>> GetAll(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {            
            return oCDatos.GetAll(criterio, valorBusqueda, currentPage, pageSize, sort, ref rowCount);
        }
        public List<CEntidad> GetAllCartaNotificacion(string BusFormulario, string BusCriterio, string BusValor, string BusCriterio1 = "")
        {
            return oCDatos.GetAllCartaNotificacion(BusFormulario, BusCriterio, BusValor, BusCriterio1);
        }
        //public List<CEntidad> RegMostrarRDQ_Buscar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.dat_ListRDQuinquenal(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<CEntidad> Log_ComboListar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.dat_LogComboListar(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// metodo para guardar el informe quinquenal
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public String RegGrabarInfQuin(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarInfQuin(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String RegGrabarInfQuinv1(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarInfQuinv1(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String RegGrabarQuinquenio(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarQuinquenio(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Ent_InfQuinquenal_QUINQUENIO RegMostrarItemsQuinquenio(string asCodInforme, int QUINQUENIO)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarItemsQuinquenio(cn, asCodInforme, QUINQUENIO);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CEntidad RegMostrarListaItems(CEntidad oCampo)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarItems(cn, oCampo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public CEntidad RegMostrarListPOA(CEntidad oCampo)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostListPOAs(cn, oCampo);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public List<int> ObtenerQuinquenios(CEntidad oCampo)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ObtenerQuinquenios(cn, oCampo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //v3
        public VM_InformeQuinquenal iniDatosInformeQ(string asCodInforme, string asCodUCuenta)
        {
            VM_InformeQuinquenal vmInf = new VM_InformeQuinquenal();
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            Log_INFORME cLogInf = new Log_INFORME();
            try
            {
                vmInf.lblTituloCabecera = "Informe Quinquenal";
                if (String.IsNullOrEmpty(asCodInforme))
                {
                    vmInf.lblTituloEstado = "Nuevo Registro";
                    /*vmInf.txtDerechoAprovechamiento = "";
                    vmInf.txtDisposicionDO = "";
                    vmInf.txtOrdenamientoForestal = "";
                    vmInf.txtSistemaMarcado = "";
                    vmInf.txtArbolesVolumenes = "";
                    vmInf.txtProteccionConcesion = "";
                    vmInf.txtRelacionPueblos = "";
                    vmInf.txtOtrasDispocisiones = "";
                    vmInf.txtRequerimientoConsecionario = "";
                    vmInf.txtCategoriaOrdenamiento = "";
                    vmInf.txtProteccionConcesion2 = "";
                    vmInf.txtPlanificacionAprovechamiento = "";
                    vmInf.txtAprovechamientoForestal = "";
                    vmInf.txtAplicacionSilvi = "";*/
                }
                else
                {
                    vmInf.lblTituloEstado = "Modificando Registro";
                    CEntidad comInf = new CEntidad();
                    comInf.COD_INFORME = asCodInforme;
                    comInf = RegMostrarListaItems(comInf);

                    //----datos generales 
                    vmInf.hdfManCodTInforme = comInf.COD_INFORME;
                    vmInf.hdfRegEstado = 0;
                    //---control de calidad
                    vmInf.vmControlCalidad.ddlIndicadorId = comInf.COD_ESTADO_DOC;
                    vmInf.vmControlCalidad.chkObsSubsanada = (bool)comInf.OBSERV_SUBSANAR;
                    vmInf.vmControlCalidad.txtControlCalidadObservaciones = comInf.OBSERVACIONES_CONTROL.ToString();
                    vmInf.vmControlCalidad.txtUsuarioControl = comInf.USUARIO_CONTROL;
                    vmInf.vmControlCalidad.txtUsuarioRegistro = comInf.USUARIO_REGISTRO;

                    vmInf.hdfManCodFCTipo = comInf.COD_FCTIPO;                   
                    vmInf.hdfcod_thabilitante = comInf.COD_THABILITANTE;
                    vmInf.ddlTipoInformeId = comInf.COD_ITIPO;
                    vmInf.lblTipoInforme = comInf.TIPO_FISCALIZA;
                    vmInf.txtNumInform = comInf.NUM_INFORME;
                    vmInf.txtFechaEmision = comInf.FECHA_EMISION.ToString();
                    vmInf.hdfCodDirector = comInf.COD_DIRECTOR;
                    vmInf.lblDirector = comInf.APELLIDOS_NOMBRE;
                    vmInf.txtConclusiones = comInf.CONCLUSIONES;
                    vmInf.txtHallazgos = comInf.HALLAZGO;

                    vmInf.txtDocumentacionRevisada = comInf.DOCUMENTACION;
                    vmInf.txtRecomendaciones = comInf.OBSERVACION;
                    vmInf.txtAsunto = comInf.ASUNTO;
                    vmInf.txtFechaInicioAuditoria = (comInf.FECHA_INICIO_AUDITORIA.ToString().Trim() == "") ? null : comInf.FECHA_INICIO_AUDITORIA.ToString();
                    vmInf.txtFechaFinAuditoria = (comInf.FECHA_FIN_AUDITORIA.ToString().Trim() == "") ? null : comInf.FECHA_FIN_AUDITORIA.ToString();
                    /*vmInf.pnlQuinquenal = false;//"0000104"
                    vmInf.pnlEvaluacionHallazgo = false;
                    vmInf.pnlEvaluacionCampo = false;//"0000103"
                    vmInf.pnlEvaluacionDocumentaria = false;//"0000102"*/

                    /* vmInf.ddlAuditoriaOkId = (Boolean)comInf.AUDITORIA_OK == true ? "SI" : "NO";
                     vmInf.ddlAmpliarContratoId = (Boolean)comInf.AMPLIAR_CONTRATO == true ? "SI" : "NO";


                     vmInf.txtFechaEmision = comInf.FECHA_EMISION.ToString();*/
                    if (comInf.ListRDQuinquenal != null)
                    {
                        vmInf.tbListRDQuinquenal = comInf.ListRDQuinquenal;
                    }
                    else
                    {
                        vmInf.tbListRDQuinquenal = new List<CEntidad>();
                    }

                    if (comInf.ListHallazgos != null)
                    {
                        vmInf.tbListHallazgos = comInf.ListHallazgos;
                    }
                    else
                    {
                        vmInf.tbListHallazgos = new List<CEntidad>();
                    }

                    if (comInf.ListProfesionales != null)
                    {
                        List<Ent_GENEPERSONA> ListProfesionalesTemp = new List<Ent_GENEPERSONA>();
                        for (int i = 0; i < comInf.ListProfesionales.Count; i++)
                        {

                            Ent_GENEPERSONA infProf = new Ent_GENEPERSONA();
                            infProf.COD_PERSONA = comInf.ListProfesionales[i].COD_PERSONA;
                            infProf.NOMBRES = comInf.ListProfesionales[i].APELLIDOS_NOMBRE;
                            infProf.RegEstado = 0;
                            ListProfesionalesTemp.Add(infProf);
                        }
                        vmInf.tbListProfesionales = ListProfesionalesTemp; ;
                    }


                    vmInf.pnlQuinquenal = false;
                    /*if (comInf.COD_FCTIPO == "0000104")
                    {
                        vmInf.pnlQuinquenal = true;
                        vmInf.txtDerechoAprovechamiento = comInf.DERECHO_APROVECHAMIENTO;
                        vmInf.txtDisposicionDO = comInf.DISPOCISION_DE_DO;
                        vmInf.txtOrdenamientoForestal = comInf.ORDENAMIENTO_MF;
                        vmInf.txtSistemaMarcado = comInf.SISTEMA_MARCADO;
                        vmInf.txtArbolesVolumenes = comInf.ARBOLES_VOLUMENES;
                        vmInf.txtProteccionConcesion = comInf.PROTECCION_CONCESION;
                        vmInf.txtRelacionPueblos = comInf.RELACION_PUEBLOS;
                        vmInf.txtOtrasDispocisiones = comInf.OTRAS_DISPOCISIONES;
                        vmInf.txtRequerimientoConsecionario = comInf.REQUERIMIENTOS_CONCESIONARIO;
                        vmInf.txtCategoriaOrdenamiento = comInf.CATEGORIA_ORDENAMIENTO;
                        vmInf.txtProteccionConcesion2 = comInf.PROTECCION_CONCESION2;
                        vmInf.txtPlanificacionAprovechamiento = comInf.PLANIFICACION_APROVECHAMIENTO;
                        vmInf.txtAprovechamientoForestal = comInf.APROVECHAMIENTO_FORESTAL;
                        vmInf.txtAplicacionSilvi = comInf.APLICACION_SILVICULTURAL;

                    }*/
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vmInf;
        }
        /*
         *
       try
        {
            //Verificando Estado Session
            if (HerUtil.SesionLUsuarioActivaMensaje(this) == true) { return; }
            //
            //Activando Tabs
            TabsSelect01(1);
            ItemRegistroLimpiar();
            //
            //Cargando datos
            CEntidad oCampos = new CEntidad();
            oCampos.COD_INFORME = ListIndex;
            oCENtidad = oCLogica.RegMostrarListaItems(oCampos);
            Session["oCENtidad"] = oCENtidad;
            //
            hdfManCodTInforme.Value = oCENtidad.COD_FCTIPO;
            pnlEvaluacionHallazgo.Visible = true;
            //ocultando adendas
            if (oCENtidad.COD_FCTIPO == "0000102")
            {
                pnlEvaluacionDocumentaria.Visible = true;
            }
            if (oCENtidad.COD_FCTIPO == "0000103")
            {
                pnlEvaluacionCampo.Visible = true;
                lisPOARD(oCENtidad);
                calculaBotonesPOAs();
            }
            if (oCENtidad.COD_FCTIPO == "0000104")
            {
                pnlQuinquenal.Visible = true;
                pnlEvaluacionHallazgo.Visible = false;
            }
            // cargando estado del documento
            hdfcod_thabilitante.Value = oCENtidad.COD_THABILITANTE;
            hdfManListIndex.Value = oCENtidad.COD_INFORME;
            lblItemCategoria.Text = oCENtidad.TIPO_FISCALIZA;
            hdfItemCategoriaCodigo.Value = oCENtidad.COD_FCTIPO;
            txtNumInform.Text = oCENtidad.NUM_INFORME;
            txtFechaEmision.Text = oCENtidad.FECHA_EMISION.ToString();
            hdfItemDirectorCodigo.Value = oCENtidad.COD_DIRECTOR;
            lblDirector.Text = oCENtidad.APELLIDOS_NOMBRE;
            txtConclusiones.Text = oCENtidad.CONCLUSIONES;
            txtHallazgos.Text = oCENtidad.HALLAZGO;
            ddlAuditoriaOk.SelectedValue = (Boolean)oCENtidad.AUDITORIA_OK == true ? "SI" : "NO";
            ddlAmpliarContrato.SelectedValue = (Boolean)oCENtidad.AMPLIAR_CONTRATO == true ? "SI" : "NO";

            if (oCENtidad.ListProfesionales != null)
            {
                if (oCENtidad.ListProfesionales.Count > 0)
                {
                    HerUtil.GrillaLlenar(grvProfesional, oCENtidad.ListProfesionales, 0);
                    lisProfesionales = oCENtidad.ListProfesionales;
                }
                else
                {
                    HerUtil.GrillaLimpiar(grvProfesional);
                    lisProfesionales = new List<CEntidad>();
                }
            }
            Session["lisProfesionales"] = lisProfesionales;
            if (oCENtidad.ListRDQuinquenal != null)
            {
                if (oCENtidad.ListRDQuinquenal.Count > 0)
                {
                    HerUtil.GrillaLlenar(grvRDQuinquenalList, oCENtidad.ListRDQuinquenal, 0);
                    ListRDQuinquenal = oCENtidad.ListRDQuinquenal;

                }
                else
                {
                    HerUtil.GrillaLimpiar(grvRDQuinquenalList);
                    ListRDQuinquenal = new List<CEntidad>();
                }
            }
            Session["ListRDQuinquenal"] = ListRDQuinquenal;
            if (oCENtidad.ListParticipantes != null)
            {
                if (oCENtidad.ListParticipantes.Count > 0)
                {
                    HerUtil.GrillaLlenar(grvParticipantes, oCENtidad.ListParticipantes, 0);
                    ListParticipantes = oCENtidad.ListParticipantes;
                }
                else
                {
                    HerUtil.GrillaLimpiar(grvParticipantes);
                    ListParticipantes = new List<CEntidad>();
                }
            }
            Session["ListParticipantes"] = ListParticipantes;
            if (oCENtidad.ListInfraestructura != null)
            {
                if (oCENtidad.ListInfraestructura.Count > 0)
                {
                    HerUtil.GrillaLlenar(grvInfraestructura, oCENtidad.ListInfraestructura, 0);
                    ListInfraestructura = oCENtidad.ListInfraestructura;
                }
                else
                {
                    HerUtil.GrillaLimpiar(grvInfraestructura);
                    ListInfraestructura = new List<CEntidad>();
                }
            }
            Session["ListInfraestructura"] = ListInfraestructura;

            //Observaciones de control de calidad
            txtControlCalidadObservaciones.Text = oCENtidad.OBSERVACIONES_CONTROL.ToString();
            chkItemObsSubsanada.Checked = (Boolean)oCENtidad.OBSERV_SUBSANAR;
            ddlItemIndicador.SelectedValue = oCENtidad.COD_ESTADO_DOC;
            lblUsuarioRegistro.Text = oCENtidad.USUARIO_REGISTRO;
            lblUsuarioControl.Text = oCENtidad.USUARIO_CONTROL;
            //HerUtil.controla_estado_calidad(oCENtidad.COD_ESTADO_DOC, ddlItemIndicador, txtControlCalidadObservaciones, chkItemObsSubsanada);


            hdfManRegEstado.Value = "0";
            lblItemTitulo.Text = "Modificando Registro";
            //
            if (oCENtidad.COD_FCTIPO == "0000104")
            {
                txtDA.Text = oCENtidad.DERECHO_APROVECHAMIENTO;
                txtDDO.Text = oCENtidad.DISPOCISION_DE_DO;
                txtOrdenamientoForestal.Text = oCENtidad.ORDENAMIENTO_MF;
                txtSistemaMarcado.Text = oCENtidad.SISTEMA_MARCADO;
                txtarbolesyvolumenes.Text = oCENtidad.ARBOLES_VOLUMENES;
                txtproteccionconcesion.Text = oCENtidad.PROTECCION_CONCESION;
                txtComunidadNativa.Text = oCENtidad.RELACION_PUEBLOS;
                txtOtrasDispocisiones.Text = oCENtidad.OTRAS_DISPOCISIONES;
                txtReqCons.Text = oCENtidad.REQUERIMIENTOS_CONCESIONARIO;
                txtCatOrdenamiento.Text = oCENtidad.CATEGORIA_ORDENAMIENTO;
                txtproteccion2.Text = oCENtidad.PROTECCION_CONCESION2;
                txtPlanificacionAprovechamiento.Text = oCENtidad.PLANIFICACION_APROVECHAMIENTO;
                txtAprovechamientoForestal.Text = oCENtidad.APROVECHAMIENTO_FORESTAL;
                txtAplicacionSilvi.Text = oCENtidad.APLICACION_SILVICULTURAL;
            }
            if (oCENtidad.ListISupervInfoDocument != null)
            {
                oCEntidadInforme = new CEntidad();
                oCEntidadInforme.ListISupervInfoDocument = oCENtidad.ListISupervInfoDocument;
                Session["EntInforme"] = oCEntidadInforme;
            }
            if (oCENtidad.ListISupervLindAreaVertice != null)
            {
                oCEntidadInforme = (CEntidad)Session["EntInforme"];
                oCEntidadInforme.ListISupervLindAreaVertice = oCENtidad.ListISupervLindAreaVertice;
                Session["EntInforme"] = oCEntidadInforme;
                HerUtil.GrillaLlenar(grvLindAreaVertice, oCEntidadInforme.ListISupervLindAreaVertice, 0);
            }
            if (oCENtidad.ListISupervMaderableAdicional != null)
            {
                oCEntidadInforme = (CEntidad)Session["EntInforme"];
                oCEntidadInforme.ListISupervMaderableAdicional = oCENtidad.ListISupervMaderableAdicional;
                Session["EntInforme"] = oCEntidadInforme;
                HerUtil.GrillaLlenar(gvIndAdicional, oCEntidadInforme.ListISupervMaderableAdicional, 0);
            }

            if (oCENtidad.ListISupervMaderableNoAutorizado != null)
            {
                oCEntidadInforme = (CEntidad)Session["EntInforme"];
                oCEntidadInforme.ListISupervMaderableNoAutorizado = oCENtidad.ListISupervMaderableNoAutorizado;
                Session["EntInforme"] = oCEntidadInforme;
                HerUtil.GrillaLlenar(grvIndNoAutorizado, oCEntidadInforme.ListISupervMaderableNoAutorizado, 0);
            }

            if (oCENtidad.ListISDSilvicultutal != null)
            {
                oCEntidadInforme = (CEntidad)Session["EntInforme"];
                oCEntidadInforme.ListISDSilvicultutal = oCENtidad.ListISDSilvicultutal;
                Session["EntInforme"] = oCEntidadInforme;
                HerUtil.GrillaLlenar(gvISDSilviculturales, oCEntidadInforme.ListISDSilvicultutal, 0);
            }

            if (oCENtidad.ListISupervCambioUso != null)
            {
                oCEntidadInforme = (CEntidad)Session["EntInforme"];
                oCEntidadInforme.ListISupervCambioUso = oCENtidad.ListISupervCambioUso;
                Session["EntInforme"] = oCEntidadInforme;
                HerUtil.GrillaLlenar(grvCambioUso, oCEntidadInforme.ListISupervCambioUso, 0);
            }
            if (oCENtidad.ListVolInjustificado != null)
            {
                oCEntidadInforme = (CEntidad)Session["EntInforme"];
                oCEntidadInforme.ListVolInjustificado = oCENtidad.ListVolInjustificado;
                Session["EntInforme"] = oCEntidadInforme;
                HerUtil.GrillaLlenar(grvVolInjustificado, oCEntidadInforme.ListVolInjustificado, 0);
            }
        }
        catch (Exception ex)
        {
            //Activando Tabs
            TabsSelect01(0);
            HerUtil.MensajeBox(this, ex.Message.ToString(), eMensajeTipo.Msgerror);
        }
        public VM_ InitDatosInforme(string asCodInforme, string asCodNotificacion, string asCodMTipo, string asCodUCuenta)
          {
              VM_Informe vmInf = new VM_Informe();
              Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
          }*/
        //    try
        //    {
        //        vmInf.lblTituloCabecera = "Informe de Supervisión";

        //        CEntidad comInf = new CEntidad();
        //        comInf.BusFormulario = "INFORME_SUPERVISION";
        //        comInf.BusCriterio = "ISUPERVISION_GENERAL";
        //        comInf.COD_UCUENTA = asCodUCuenta;
        //        comInf = RegMostCombo(comInf);

        //        vmInf.ddlOd = comInf.ListODs.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
        //        vmInf.vmDatoSupervision.ddlMotivoSupervision = comInf.ListISupervision_Motivo.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
        //        vmInf.vmDatoSupervision.ddlTipoPeticionMotivada = comInf.ListMComboMotMotivada.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });

        //        if (String.IsNullOrEmpty(asCodInforme))
        //        {
        //            CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA entCN = new CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA();
        //            Log_NOTIFICACION exeCN = new Log_NOTIFICACION();
        //            entCN = exeCN.RegListarNotificacionConsulta_v3(
        //                new CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA()
        //                {
        //                    BusFormulario = "MODAL_NOTIFICACION",
        //                    BusCriterio = "FN_CODIGO",
        //                    BusValor = asCodNotificacion
        //                }).FirstOrDefault();

        //            vmInf.lblTituloEstado = "Nuevo Registro";
        //            vmInf.vmInfCNotificacion.hdfCodCNotificacion = entCN.COD_FISNOTI;
        //            vmInf.vmInfCNotificacion.txtCNotificacion = entCN.NUM_NOTIFICACION;
        //            vmInf.vmInfCNotificacion.txtTHabilitante = entCN.NUM_THABILITANTE;
        //            vmInf.hdfCodUbigeo = entCN.COD_UBIGEO;
        //            vmInf.txtUbigeo = entCN.UBIGEO;
        //            vmInf.txtSector = entCN.SECTOR;
        //            vmInf.hdfRegEstado = 1;

        //            CEntidad entInfPoa = new CEntidad();
        //            entInfPoa.BusFormulario = "INFORME_SUPERVISION";
        //            entInfPoa.BusCriterio = "LISTA_POAS";
        //            entInfPoa.TIPO = "FN";
        //            entInfPoa.BusValor = "'" + asCodNotificacion + "'";
        //            vmInf.vmInfCNotificacion.tbPoa = RegMostListPOAs(entInfPoa).ListPOAs;
        //            foreach (var itemPoa in vmInf.vmInfCNotificacion.tbPoa)
        //            {
        //                itemPoa.RegEstado = 1;
        //            }

        //            //Cargar las obligaciones del titular del TH
        //            string tipoObligTitular = "OBLIGTITU_NOMADE";
        //            if (("0000007|0000010|0000014|0000015|0000016|0000017").Contains(asCodMTipo))
        //            {
        //                tipoObligTitular = "OBLIGTITU_MADE";
        //            }
        //            var lstObligTitular = exeBus.RegMostComboIndividual("OBLIGACION_TITULAR", tipoObligTitular);
        //            foreach (var item in lstObligTitular)
        //            {
        //                vmInf.tbObligTitular.Add(new CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR()
        //                {
        //                    COD_OBLIGTITULAR = item.Value,
        //                    OBLIGTITULAR = item.Text,
        //                    EVAL_OBLIGTITULAR = "",
        //                    OBSERVACION = ""
        //                });
        //            }
        //        }
        //        else
        //        {
        //            //Obtener datos del informe
        //            CEntidad entInf = RegMostrarListaItem_v3(asCodInforme);

        //            vmInf.lblTituloEstado = "Modificando Registro";
        //            vmInf.vmControlCalidad.ddlIndicadorId = entInf.COD_ESTADO_DOC;
        //            vmInf.vmControlCalidad.chkObsSubsanada = (bool)entInf.OBSERV_SUBSANAR;
        //            vmInf.vmControlCalidad.txtControlCalidadObservaciones = entInf.OBSERVACIONES_CONTROL.ToString();
        //            vmInf.vmControlCalidad.txtUsuarioControl = entInf.USUARIO_CONTROL;
        //            vmInf.vmControlCalidad.txtUsuarioRegistro = entInf.USUARIO_REGISTRO;

        //            vmInf.vmInfCNotificacion.hdfCodCNotificacion = entInf.COD_FISNOTI;
        //            vmInf.vmInfCNotificacion.txtCNotificacion = entInf.NUM_NOTIFICACION;
        //            vmInf.vmInfCNotificacion.txtTHabilitante = entInf.NUM_THABILITANTE;
        //            vmInf.vmInfCNotificacion.tbCNotificacion = entInf.ListCNotificaciones;

        //            vmInf.hdfCodInforme = entInf.COD_INFORME;
        //            vmInf.hdfRegEstado = 0;
        //            vmInf.chkPublicar = (bool)entInf.PUBLICAR;
        //            vmInf.vmInfCNotificacion.tbPoa = entInf.ListPOAs;
        //            vmInf.txtNumInforme = entInf.NUMERO;
        //            vmInf.ddlOdId = entInf.COD_OD_REGISTRO;
        //            vmInf.chkPlanAmazonas = (bool)entInf.PLAN_AMAZONAS;
        //            vmInf.chkPlanAmazonas2014 = entInf.ANIO_PLAN_AMAZONAS.Contains("2014") ? true : false;
        //            vmInf.chkPlanAmazonas2015 = entInf.ANIO_PLAN_AMAZONAS.Contains("2015") ? true : false;
        //            vmInf.chkPlanAmazonas2016 = entInf.ANIO_PLAN_AMAZONAS.Contains("2016") ? true : false;
        //            vmInf.txtFechaEntrega = entInf.FECHA_ENTREGA.ToString();
        //            vmInf.hdfCodDirector = entInf.COD_DIRECTOR;
        //            vmInf.txtDirector = entInf.NOMBRE_DIRECTOR;
        //            vmInf.vmDatoSupervision.txtFechaInicio = entInf.FECHA_SUPERVISION_INICIO.ToString();
        //            vmInf.vmDatoSupervision.txtFechaFin = entInf.FECHA_SUPERVISION_FIN.ToString();
        //            vmInf.vmDatoSupervision.ddlMotivoSupervisionId = entInf.COD_IMOTIVO;
        //            vmInf.vmDatoSupervision.txtMotivoSupervision = entInf.IMOTIVO;
        //            vmInf.vmDatoSupervision.ddlTipoPeticionMotivadaId = entInf.MAE_TIP_MOTMOTIVADA;
        //            vmInf.vmDatoSupervision.hdfCodDocDenunciaSITD = entInf.COD_TRAMITE_SITD.ToString();
        //            vmInf.vmDatoSupervision.txtDocDenunciaSITD = entInf.NUM_DREFERENCIA;
        //            vmInf.vmDatoSupervision.chkGeoTecDron = (bool)entInf.GEOTEC_DRON;
        //            vmInf.vmDatoSupervision.chkGeoTecGeoSupervisor = (bool)entInf.GEOTEC_GEOSUPERVISOR;
        //            vmInf.vmDatoSupervision.chkGeoTecOtro = (bool)entInf.GEOTEC_OTROS;
        //            vmInf.vmDatoSupervision.chkGeoTecNinguno = (bool)entInf.GEOTEC_NINGUNO;
        //            vmInf.vmDatoSupervision.txtGeoTecOtro = entInf.GEOTEC_DESCRIPCION;
        //            vmInf.txtAsunto = entInf.ASUNTO;
        //            vmInf.txtContenido = entInf.CONTENIDO.ToString();
        //            vmInf.ddlRealizadoVeedorId = (bool)entInf.REALIZADO_VEEDORFORESTAL ? "SI" : "NO";
        //            vmInf.hdfCodUbigeo = entInf.THABILITANTE_COD_UBIGEO;
        //            vmInf.txtUbigeo = entInf.UBIGEO;
        //            vmInf.txtSector = entInf.THABILITANTE_SECTOR;
        //            vmInf.txtObservacion = entInf.OBSERVACION;
        //            vmInf.txtConclusion = entInf.CONCLUSION;
        //            vmInf.hdfCodDLinea = entInf.COD_DLINEA;
        //            vmInf.hdfEstadoOrigen = entInf.ESTADO_ORIGEN;
        //            vmInf.tbSupervisor = entInf.ListInformeDetSupervisor;
        //            vmInf.tbVerticeTHCampo = entInf.ListTHVerticeCampo;
        //            vmInf.tbAvistamientoFauna = entInf.ListAvistamientoFauna;
        //            vmInf.tbFotoSupervision = entInf.ListFotos;
        //            vmInf.tbObligTitular = ("0000007|0000010|0000014|0000015|0000016|0000017").Contains(asCodMTipo) ?
        //                entInf.ListObligacionTitular.Where(m => m.COD_GRUPO == "OBLIGTITU_MADE").ToList() : entInf.ListObligacionTitular.Where(m => m.COD_GRUPO == "OBLIGTITU_NOMADE").ToList();
        //            vmInf.tbObligacion = entInf.ListISUPERVISION_OCARACTE_AMB01;
        //            vmInf.tbDesplazamiento = entInf.ListDesplazamientoInforme;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return vmInf;
        //}

    }
}
