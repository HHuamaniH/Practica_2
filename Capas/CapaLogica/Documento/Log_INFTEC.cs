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
using CDatos = CapaDatos.DOC.Dat_INFTEC;
using CEntidad = CapaEntidad.DOC.Ent_INFTEC;

namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Log_INFTEC
    {
        private CDatos oCDatos = new CDatos();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntidad> RegMostrarINFTEC_Buscar(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarINFTEC_Buscar(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public String RegGrabaInfTecnico(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabaInfTecnico(cn, oCampoEntrada);
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
        public CEntidad RegMostrarINFTECItem(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaInfTecItem(cn, oCampoEntrada);
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
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
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

        //public String RegGrabaInfTecnicoDenuncia(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegGrabaInfTecnicoDenuncia(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public VM_InformeTecnico init(string asCodigo, string asCodTipo)
        {
            VM_InformeTecnico vm = new VM_InformeTecnico();
            try
            {
                if (String.IsNullOrEmpty(asCodigo))
                {
                    //nuevo;

                    vm.hdfCodFCTipo = asCodTipo;
                    vm.RegEstado = 1;
                    vm.lblTituloCabecera = "Nuevo Registro";
                    vm.vmControlCalidad = new VM_ControlCalidad_2();
                    vm.vmControlCalidad.ddlIndicadorId = "0000000";
                    vm.Listardetdescargo = new List<CEntidad>();
                    vm.Listarlffs = new List<CEntidad>();
                    vm.ListInformes = new List<CEntidad>();
                    vm.ListVolumen = new List<CEntidad>();
                    vm.Listarmulta = new List<CEntidad>();
                    vm.Listarmultaantiguo = new List<CEntidad>();

                    this.initCombos(vm);
                    switch (vm.hdfCodFCTipo)
                    {
                        case "0000038":// Evaluación de Descargo
                            vm.txtTipoFisca = "Informes Técnicos - Evaluación de Descargo";
                            break;
                        case "0000039"://  Informe Determinación Multa
                            vm.txtTipoFisca = "Informes Técnicos - Informe Determinación Multa";
                            break;

                        case "0000040":// Formato Determinación Multa
                            vm.txtTipoFisca = "Informes Técnicos - Formato Determinación Multa";
                            break;
                        case "0000043":// Inspección Ocular
                            vm.txtTipoFisca = "Informes Técnicos - Inspección Ocular";
                            break;
                        case "0000120"://  Evaluación Recurso Reconsideración
                            vm.txtTipoFisca = "Informes Técnicos - Evaluación Recurso Reconsideración";
                            break;
                        case "0000041"://Informe Complementario
                            vm.txtTipoFisca = "Informes Técnicos - Informe Complementario";
                            break;
                        case "0000044":// Otros
                            vm.txtTipoFisca = "Informes Técnicos - Otros";
                            break;
                        case "0000042":// Informe de Aclaración
                            vm.txtTipoFisca = "Informes Técnicos - Informe de Aclaración";
                            break;
                    }


                }
                else
                {

                    CEntidad oCampos = new CEntidad();
                    oCampos.COD_INFTEC = asCodigo;
                    oCampos = this.RegMostrarINFTECItem(oCampos);

                    vm.vmControlCalidad = new VM_ControlCalidad_2();
                    vm.vmControlCalidad.ddlIndicadorId = oCampos.COD_ESTADO_DOC;
                    vm.vmControlCalidad.txtUsuarioRegistro = oCampos.USUARIO_REGISTRO;
                    vm.vmControlCalidad.txtUsuarioControl = oCampos.USUARIO_CONTROL;
                    vm.vmControlCalidad.chkObsSubsanada = (bool)oCampos.OBSERV_SUBSANAR;
                    vm.vmControlCalidad.txtControlCalidadObservaciones = oCampos.OBSERVACIONES_CONTROL.ToString();

                    vm.ListODS = new List<CEntidad>();

                    vm.hdfCodigoInfTec = asCodigo;
                    vm.RegEstado = 0;
                    vm.lblTituloCabecera = "Modificando Registro";
                    vm.hdfCodFCTipo = oCampos.COD_FCTIPO;

                    if (vm.hdfCodFCTipo != "0000039" && vm.hdfCodFCTipo != "0000040")
                    {
                        vm.chkCambiaEstado = (bool)oCampos.CAMBIA_ESTADO_ESPECIES;
                        vm.chkCambiaVol = (bool)oCampos.CAMBIA_VOL_ISUPERVISION;
                    }
                    vm.txtTipoFisca = oCampos.TIPO_FISCALIZA;
                    vm.hdfCodPersona = oCampos.COD_PERSONA;
                    vm.txtPersona = oCampos.APELLIDOS_NOMBRES;
                    vm.txtNumInforme = oCampos.NUMERO_INFORME;
                    vm.txtFechaEmision = oCampos.FECHA_EMISION.ToString();

                    vm.txtDescripMulta = oCampos.DESCRIPCION_MULTA;
                    vm.txtDescripMultaAnt = oCampos.DESCRIPCION_MULTA_ANTIGUO;
                    vm.txtDescripInforme = oCampos.DESCRIPCION_INFORME;
                    vm.txtIdCodOD = oCampos.COD_OD_REGISTRO;

                    vm.txtMultaRecomendSol = oCampos.MULTA_RECOMENDADA_SOLES;
                    vm.txtMultaRecomendUIt = oCampos.MULTA_RECOMENDADA_UIT;
                    vm.txtMotivMulta = oCampos.MOTIVO_MULTA;

                    vm.txtInfAclaracion = oCampos.INFORMACION_ACLARO;
                    vm.txtDocumentosAdj = oCampos.DOCUMENTOS_ADJUNTOS;

                    vm.txtReferencia = oCampos.REFERENCIA;
                    vm.txtInfComplemento = oCampos.INFORMACION_COMPLEMENTO;
                    vm.txtConclusion = oCampos.CONCLUSION;
                    vm.txtConclusionR = oCampos.CONCLUCION;
                    vm.txtRecomendacion = oCampos.RECOMENDACION;

                    vm.txtFechaInicio = oCampos.FECHA_INICIO_INSPECCION.ToString();
                    vm.txtFechaFin = oCampos.FECHA_FIN_INSPECCION.ToString();
                    vm.txtPrincipalesResultados = oCampos.PRINCIPALES_RESULTADOS;
                    vm.txtComentarios = oCampos.COMENTARIOS;

                    vm.txtObservacion = oCampos.DESCRIPCION;

                    vm.ListInformes = oCampos.ListInformes;
                    vm.ListVolumen = oCampos.ListVolumen;

                    vm.sBusqueda = new List<CapaEntidad.DOC.Ent_SBusqueda>();
                    vm.Listarmultaantiguo = oCampos.Listarmultaantiguo;
                    vm.Listarmulta = oCampos.Listarmulta;
                    vm.Listardetdescargo = oCampos.Listardetdescargo;
                    vm.Listarlffs = oCampos.Listarlffs;

                    this.initCombos(vm);

                }
            }
            catch (Exception)
            {

            }
            return vm;
        }

        private void ValidarDatos(VM_InformeTecnico _dto)
        {
            if (_dto.vmControlCalidad.ddlIndicadorId == "0000000") throw new Exception("Seleccione el estado actual del registro");
            if (string.IsNullOrEmpty(_dto.txtNumInforme)) throw new Exception("Ingrese el número de Informe Tecnico");
            if (string.IsNullOrEmpty(_dto.txtFechaEmision)) throw new Exception("Seleccione la fecha de emisión");
            if (_dto.ListInformes == null) throw new Exception("Seleccione un informe, expediente");
            if (string.IsNullOrEmpty(_dto.hdfCodPersona)) throw new Exception("Seleccione profesional responsable");
            if (_dto.txtIdCodOD == "0000000") throw new Exception("Seleccione OD de registro");

            //if (_dto.hdfCodTipoIlegal == "0000001" && _dto.txtIdRecomendacion == "0000000") throw new Exception("Seleccione una recomendación");
        }

        public ListResult GuardarDatos(VM_InformeTecnico _dto, string codCuenta)
        {

            ListResult result = new ListResult();
            try
            {
                this.ValidarDatos(_dto);
                CEntidad oCEntInfTec = new CEntidad();

                oCEntInfTec.COD_FCTIPO = _dto.hdfCodFCTipo;
                oCEntInfTec.COD_UCUENTA = codCuenta;
                oCEntInfTec.COD_PERSONA = _dto.hdfCodPersona;
                oCEntInfTec.COD_INFTEC = _dto.hdfCodigoInfTec;
                oCEntInfTec.DESCRIPCION = _dto.txtDescripInforme;
                oCEntInfTec.NUMERO_INFORME = _dto.txtNumInforme;
                if (_dto.txtFechaEmision != null)
                {
                    if (_dto.txtFechaEmision.Trim() != "")
                    {
                        oCEntInfTec.FECHA_EMISION = Convert.ToDateTime(_dto.txtFechaEmision);
                    }
                }
                oCEntInfTec.RegEstado = _dto.RegEstado;
                oCEntInfTec.ListInformes = _dto.ListInformes;
                oCEntInfTec.ListEliTABLA = _dto.listEliTabla;

                //Variables de control de calidad
                //Variables de control de calidad
                oCEntInfTec.COD_ESTADO_DOC = _dto.vmControlCalidad.ddlIndicadorId;
                oCEntInfTec.OBSERVACIONES_CONTROL = _dto.vmControlCalidad.txtControlCalidadObservaciones;
                oCEntInfTec.OBSERV_SUBSANAR = Convert.ToInt32( _dto.vmControlCalidad.chkObsSubsanada);

                oCEntInfTec.COD_OD_REGISTRO = _dto.txtIdCodOD;
                oCEntInfTec.OUTPUTPARAM01 = "";
                oCEntInfTec.CAMBIA_VOL_ISUPERVISION = Convert.ToInt32(_dto.chkCambiaVol);
                oCEntInfTec.CAMBIA_ESTADO_ESPECIES = Convert.ToInt32(_dto.chkCambiaEstado);

                // oCEntInfTec.ListVolumen = olListVolumen;
                //CEntidadIT oEMadeSemi = (CEntidadIT)Session["ListE_Maderable_Semillero"];
                //oCEntInfTec.ListEMaderable = oEMadeSemi.ListEMaderable;
                //oCEntInfTec.ListEMaderableSemillero = oEMadeSemi.ListEMaderableSemillero;
                if (oCEntInfTec.ListEliTABLA == null)
                {
                    oCEntInfTec.ListEliTABLA = new List<CEntidad>();
                }
                switch (_dto.hdfCodFCTipo)
                {
                    case "0000038":
                        oCEntInfTec.Listarlffs = _dto.Listarlffs;
                        oCEntInfTec.Listardetdescargo = _dto.Listardetdescargo;
                        if (_dto.listEliTablaED != null)
                        {
                            foreach (Ent_INFTEC eli in _dto.listEliTablaED)
                            {
                                oCEntInfTec.ListEliTABLA.Add(eli);
                            }
                        }
                        oCEntInfTec.ListVolumen = _dto.ListVolumen;
                        if (_dto.listEliTablaVolumen != null)
                        {
                            foreach (Ent_INFTEC eli in _dto.listEliTablaVolumen)
                            {
                                oCEntInfTec.ListEliTABLA.Add(eli);
                            }
                        }
                        break;
                    case "0000039":
                        oCEntInfTec.MULTA_RECOMENDADA_UIT = _dto.txtMultaRecomendUIt;
                        oCEntInfTec.MULTA_RECOMENDADA_SOLES = _dto.txtMultaRecomendSol;
                        oCEntInfTec.MOTIVO_MULTA = _dto.txtMotivMulta;
                        oCEntInfTec.ListVolumen = _dto.ListVolumen;
                        if (_dto.listEliTablaVolumen != null)
                        {
                            foreach (Ent_INFTEC eli in _dto.listEliTablaVolumen)
                            {
                                oCEntInfTec.ListEliTABLA.Add(eli);
                            }
                        }
                        break;
                    case "0000040":
                        oCEntInfTec.DESCRIPCION_MULTA = _dto.txtDescripMulta;
                        oCEntInfTec.DESCRIPCION_MULTA_ANTIGUO = _dto.txtDescripMultaAnt;
                        oCEntInfTec.Listarmulta = _dto.Listarmulta;
                        oCEntInfTec.Listarmultaantiguo = _dto.Listarmultaantiguo;
                        if (_dto.listEliTablaMulta != null)
                        {
                            foreach (Ent_INFTEC eli in _dto.listEliTablaMulta)
                            {
                                oCEntInfTec.ListEliTABLA.Add(eli);
                            }
                        }
                        break;
                    case "0000041":
                        oCEntInfTec.INFORMACION_COMPLEMENTO = _dto.txtInfComplemento;
                        oCEntInfTec.REFERENCIA = _dto.txtReferencia;
                        oCEntInfTec.CONCLUSION = _dto.txtConclusion;

                        oCEntInfTec.ListVolumen = _dto.ListVolumen;
                        if (_dto.listEliTablaVolumen != null)
                        {
                            foreach (Ent_INFTEC eli in _dto.listEliTablaVolumen)
                            {
                                oCEntInfTec.ListEliTABLA.Add(eli);
                            }
                        }
                        break;
                    case "0000042":
                        oCEntInfTec.INFORMACION_ACLARO = _dto.txtInfAclaracion;
                        oCEntInfTec.DOCUMENTOS_ADJUNTOS = _dto.txtDocumentosAdj;

                        oCEntInfTec.ListVolumen = _dto.ListVolumen;
                        if (_dto.listEliTablaVolumen != null)
                        {
                            foreach (Ent_INFTEC eli in _dto.listEliTablaVolumen)
                            {
                                oCEntInfTec.ListEliTABLA.Add(eli);
                            }
                        }
                        break;
                    case "0000043":
                        if (_dto.txtFechaInicio != null)
                        {
                            if (_dto.txtFechaInicio.Trim() != "")
                            {
                                oCEntInfTec.FECHA_INICIO_INSPECCION = Convert.ToDateTime(_dto.txtFechaInicio);
                            }
                        }
                        if (_dto.txtFechaFin != null)
                        {
                            if (_dto.txtFechaFin.Trim() != "")
                            {
                                oCEntInfTec.FECHA_FIN_INSPECCION = Convert.ToDateTime(_dto.txtFechaFin);
                            }
                        }
                        oCEntInfTec.PRINCIPALES_RESULTADOS = _dto.txtPrincipalesResultados;
                        oCEntInfTec.ListVolumen = _dto.ListVolumen;
                        if (_dto.listEliTablaVolumen != null)
                        {
                            foreach (Ent_INFTEC eli in _dto.listEliTablaVolumen)
                            {
                                oCEntInfTec.ListEliTABLA.Add(eli);
                            }
                        }
                        break;
                    case "0000044":

                        oCEntInfTec.COMENTARIOS = _dto.txtComentarios;

                        oCEntInfTec.ListVolumen = _dto.ListVolumen;
                        if (_dto.listEliTablaVolumen != null)
                        {
                            foreach (Ent_INFTEC eli in _dto.listEliTablaVolumen)
                            {
                                oCEntInfTec.ListEliTABLA.Add(eli);
                            }
                        }
                        break;
                    case "0000120":

                        oCEntInfTec.CONCLUCION = _dto.txtConclusionR;
                        oCEntInfTec.RECOMENDACION = _dto.txtRecomendacion;

                        oCEntInfTec.ListVolumen = _dto.ListVolumen;
                        if (_dto.listEliTablaVolumen != null)
                        {
                            foreach (Ent_INFTEC eli in _dto.listEliTablaVolumen)
                            {
                                oCEntInfTec.ListEliTABLA.Add(eli);
                            }
                        }
                        break;
                        /*
                         * case 3:
                            GrabarComplementario();
                            //estado_final = oCLogicaInfTec.RegComplementario_Grabar(oCEntInfTec);
                            break;
                        case 4:
                            GrabarInspeccionOcular();
                            //estado_final = oCLogicaInfTec.RegInspeccionOcular_Grabar(oCEntInfTec);
                            break;
                        case 5:
                            GrabarInformeAclaracion();
                            //estado_final = oCLogicaInfTec.RegAclaracion_Grabar(oCEntInfTec);
                            break;
                        case 7:
                            Grabarotros();
                            //estado_final = oCLogicaInfTec.RegOTROS_Grabar(oCEntInfTec);
                            break;
                        case 8:
                            GrabarFormatoMulta();
                            //estado_final = oCLogicaInfTec.RegFormatoMulta_Grabar(oCEntInfTec);
                            break;*/
                }

                var estado_final = this.RegGrabaInfTecnico(oCEntInfTec);
                result.AddResultado("Guardo Correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        private void initCombos(VM_InformeTecnico vm)
        {

            CEntidad oCampos2 = new CEntidad();
            oCampos2.BusFormulario = "INFORME_TECNICO";
            oCampos2 = this.RegMostCombo(oCampos2);
            vm.ListODS = oCampos2.ListODs;
            vm.ListComboEspecies = oCampos2.ListComboEspecies;
            vm.ListComboInciso = oCampos2.ListComboInciso;

            List<Ent_SBusqueda> listCombo = new List<Ent_SBusqueda>();
            Ent_SBusqueda Combo = new Ent_SBusqueda();
            vm.sBusqueda = new List<Ent_SBusqueda>();
            listCombo = new List<Ent_SBusqueda>();
            switch (vm.hdfCodFCTipo)
            {
                case "0000038":// Evaluación de Descargo
                case "0000039"://  Informe Determinación Multa
                case "0000040":// Formato Determinación Multa
                case "0000043":// Inspección Ocular
                case "0000120"://  Evaluación Recurso Reconsideración
                    vm.txtTituloModal = "Lista de Expedientes Administrativos";
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);
                    break;
               
                case "0000044":// Otros
                    vm.txtTituloModal = "Lista de Informes de Supervisión y Expedientes Administrativo";
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_NUMERO";
                    Combo.Text = "Informe Supervision";
                    listCombo.Add(Combo);

                    break;
                case "0000041"://Informe Complementario
                case "0000042":// Informe de Aclaración
                    vm.txtTituloModal = "Lista de Informes de Supervisión y Expedientes Administrativo";
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "EXPADM_NUMERO";
                    Combo.Text = "Nro. Expediente";
                    listCombo.Add(Combo);
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_NUMERO";
                    Combo.Text = "Informe Supervision";
                    listCombo.Add(Combo);
                    Combo = new Ent_SBusqueda();
                    Combo.Value = "INF_QUINQ";
                    Combo.Text = "Inf. Audi. Quinquenal";
                    listCombo.Add(Combo);

                    break;

            }
            vm.sBusqueda = listCombo;
        }

        public List<Dictionary<string, string>> registroUsuarioIT(CEntidad oCEntidad)
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
                paramCap.BusCriterio = "INFORME_TECNICO";
                paramCap.COD_UCUENTA = asCodUsuario;

                List<Dictionary<string, string>> olResult = registroUsuarioIT(paramCap);

                if (olResult.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/Reg_Usu/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "INFTECNICO_REG.xlsx";

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
                                insertar = insertar + ",'" + (itemPart["NUMERO"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["TIPO_FISCALIZA"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["NUMERO_EXPEDIENTE"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["NUMERO_INFORME"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["NUM_THABILITANTE"] ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart["TITULAR"] ?? "") + "'";
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

    }
}
