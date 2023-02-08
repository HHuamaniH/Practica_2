using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using System.Diagnostics;
using OfficeOpenXml;
using SIGOFCv3.Models;
using SIGOFCv3.Models.DataTables;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_ResolucionTFFS;
//using CEntVM = CapaEntidad.ViewModel.VM_InformeLegal;
using CLogica = CapaLogica.DOC.Log_TFFS;
using CEntidad = CapaEntidad.DOC.Ent_TFFS;
using CLogResodirec = CapaLogica.DOC.Log_RESODIREC;
using CEntResodirec = CapaEntidad.DOC.Ent_RESODIREC;
using Newtonsoft.Json;
using CapaEntidad.ViewModel.General;
using SIGOFCv3.Helper;

namespace SIGOFCv3.Areas.Tribunal.Controllers
{
    public class ManTribunalController : Controller
    {
        private CLogica logRD = new CLogica();
        public static CEntVM vmRD = new CEntVM();

        // GET: Fiscalizacion/ManResolucion
        public ActionResult Index()
        {
            // return View();
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.Formulario = "TFFS";
            ViewBag.TituloFormulario = "Resolución TFFS";
            ViewBag.Criterio = "TODOS";
            ViewBag.AlertaInicial = "";
            ViewBag.ddlListOpciones = exeBus.RegMostComboIndividual_v3("TFFS", "");
            //ViewBag.ddlListOpciones = exeBus.mostrarRegistrosUsuario("TFFS", "");
            
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MÓDULO DE TRIBUNAL", "Resoluciones TFFS");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }
        /// <summary>
        /// metodo para exportar los registros del usuario logeado
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ExportarRegistroUsuario()
        {
            ListResult result = new ListResult();
            //result = logRD.RegistroUsuario((ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }


        #region "SHARED"
        [HttpGet]
        public JsonResult ConsultaResolucionPaging(DataTableRequest request = null)
        {
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            Ent_BUSQUEDA paramsBus = new Ent_BUSQUEDA();
            List<Dictionary<string, string>> lstResult;
            int rowcount = 0;
            int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

            paramsBus.BusFormulario = request.CustomSearchForm;//EXPEDIENTE_CONSULTA||RESOLUCION_CONSULTA
            paramsBus.BusCriterio = request.CustomSearchType;//NUM_EXPEDIENTE||NUM_RESOLUCION
            paramsBus.BusValor = request.CustomSearchValue;
            paramsBus.pagesize = request.Length;
            paramsBus.currentpage = page;

            if (request.Order.Length != 0)
            {
                paramsBus.sort = request.Order[0].Column_Name + " " + request.Order[0].Dir;
            }

            lstResult = exeBus.RegMostrarListaPaging(paramsBus, ref rowcount);

            var jsonResult = Json(new
            {
                data = lstResult.ToArray(),
                draw = request.Draw,
                recordsTotal = rowcount,
                recordsFiltered = rowcount,
                error = ""
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        #endregion


        #region migracion CARR 01/09/2020

        public ActionResult CreateOrEdit(string asCodRD = "", string asCodTipoIL = "")
        {
            try
            {
                Debug.Write("asCodRD====>" + asCodRD);
                vmRD = logRD.initRD(asCodRD, asCodTipoIL);
                
                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MÓDULO DE TRIBUNAL", "Resoluciones TFFS");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;
                //Pasamos el Rol del usuario
                vmRD.vmControlCalidad.VALIAS_ROL = mr.VALIAS;

                return View(vmRD);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorC", "Index");
            }

        }
        /// <summary>
        /// metodo para consultar la lista de expedientes  de la resolucion
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        //public JsonResult ConsultaModal(DataTableRequest request = null)
        //{

        //    CLogica exeBus = new CLogica();
        //    Ent_TFFS paramsBus = new Ent_TFFS();
        //    Ent_TFFS lstResult;
        //    int rowcount = 0;
        //    int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

        //    paramsBus.BusFormulario = request.CustomSearchForm;
        //    paramsBus.BusCriterio = request.CustomSearchType;//NUM_EXPEDIENTE||NUM_RESOLUCION
        //    paramsBus.BusValor = request.CustomSearchValue;

        //    paramsBus.v_pagesize = request.Length;
        //    paramsBus.v_currentpage = page;

        //    lstResult = exeBus.RegMostrariNFORME_Buscar(paramsBus);

        //    var jsonResult = Json(new
        //    {
        //        data = lstResult.ListInformes.ToArray(),
        //        draw = request.Draw,
        //        recordsTotal = lstResult.v_ROW_INDEX,
        //        recordsFiltered = lstResult.v_ROW_INDEX,
        //        error = ""
        //    }, JsonRequestBehavior.AllowGet);
        //    jsonResult.MaxJsonLength = int.MaxValue;
        //    return jsonResult;
        //}

        public ActionResult inicisos(string idArticulo, string descArticulo, string codEncisoSelect)
        {
            CLogica exeBus = new CLogica();
            vmRD.ddlArticulosId = idArticulo;
            vmRD.txtDescripcionArticulo = descArticulo;
            vmRD.ListIncisos = exeBus.initArticulos("ENCISOS", idArticulo);
            vmRD.hdfCodEnciso = codEncisoSelect;
            return PartialView("~/Areas/Tribunal/Views/ManTribunal/_Shared/generic/_renderEncisos.cshtml", vmRD);
        }

        public ActionResult subTipoArchivo(string idMotivo, string descMotivo)
        {
            CLogica exeBus = new CLogica();
            vmRD.txtIdTipoMotivoArch = idMotivo;
            vmRD.txtDescTipoMotivoArch = descMotivo;
            vmRD.ListSubTipoArchivo = exeBus.initArticulos("TIPO_ARCHIVO", idMotivo);
            return PartialView("~/Areas/Tribunal/Views/ManTribunal/_Shared/_generic/_renderMotivoArchivo.cshtml", vmRD);
        }

        [HttpPost]
        public ActionResult agregarMotivoArchivo(string codigoSub, string motivo, string detalleMotivo, string descmMtivo)
        {
            try
            {
                Ent_TFFS ocampoEnt = new Ent_TFFS();
                ocampoEnt.CODIGO = codigoSub;
                ocampoEnt.MOTIVO = motivo;
                ocampoEnt.DETALLE_MOTIVO = detalleMotivo.Replace("\n", "");
                ocampoEnt.DESCRIPCIONMOTIVO = descmMtivo.Replace("\n", "");
                ocampoEnt.RegEstado = 1;
                vmRD.ListMotivoArchivo.Add(ocampoEnt);
            }
            catch (Exception)
            {

            }
            return PartialView("~/Areas/Tribunal/Views/ManTribunal/_Shared/_generic/_renderListaMotiva.cshtml", vmRD);
        }

        public JsonResult listaPoa(List<Ent_TFFS> dto)
        {
            if (dto.Count > 0)
            {
                List<Ent_TFFS> listPoa = new List<Ent_TFFS>();
                CLogica exeBus = new CLogica();
                Ent_TFFS oCEntidad = new Ent_TFFS();
                oCEntidad.BusFormulario = "TFFS";
                oCEntidad.BusCriterio = "LISTA_POAS";
                oCEntidad.BusValor = "";
                foreach (var fila in dto)
                {

                    if ((fila.COD_RESODIREC != " ") && (fila.COD_RESODIREC_INI_PAU != " ") && (fila.COD_RESODIREC != null) && (fila.COD_RESODIREC_INI_PAU != null))
                    {
                        oCEntidad.TIPO = "EX";
                        if (oCEntidad.BusValor == "") { oCEntidad.BusValor = fila.COD_RESODIREC; }
                        else { oCEntidad.BusValor = oCEntidad.BusValor + "," + fila.COD_RESODIREC; }

                    }
                    else if (fila.COD_RESODIREC != " " && fila.COD_RESODIREC != null)
                    {
                        oCEntidad.TIPO = "RD";
                        if (oCEntidad.BusValor == "") { oCEntidad.BusValor = fila.COD_RESODIREC; }
                        else { oCEntidad.BusValor = oCEntidad.BusValor + "," + fila.COD_RESODIREC; }
                    }
                    else if (fila.COD_INFORME != " " && fila.COD_INFORME != null)
                    {
                        oCEntidad.TIPO = "IN";
                        if (oCEntidad.BusValor == "") { oCEntidad.BusValor = fila.COD_INFORME; }
                        else { oCEntidad.BusValor = oCEntidad.BusValor + "," + fila.COD_INFORME; }
                    }
                }
                oCEntidad = exeBus.RegMostListPOAs(oCEntidad);
                vmRD.ListPOA = oCEntidad.ListPOAs;
            }
            var jsonResult = Json(new
            {
                data = "",
                draw = "",
                error = "",
                success = true
            }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        /// <summary>
        /// metodo para agregar las infracciones
        /// </summary>
        /// <param name="infracciones"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult agregarInfracciones(string idEnciso, string descEnciso, string idPoa, string desPoa, string area, string descripcion, string volumen, string tipo, string idEspecie, string desEspecie, string numInd, string idEspecieFauna, string desEspecieFauna)
        {
            try
            {
                Ent_TFFS ocampoEnt = new Ent_TFFS();
                ocampoEnt.COD_ILEGAL_ARTICULOS = vmRD.txtIdArticulo;
                ocampoEnt.COD_ILEGAL_ENCISOS = idEnciso;
                ocampoEnt.DESCRIPCION_ARTICULOS = vmRD.txtDescripcionArticulo;
                ocampoEnt.DESCRIPCION_ENCISOS = descEnciso;
                if (idEspecie != "0002226")
                {
                    ocampoEnt.COD_ESPECIES = idEspecie == "0002226" ? null : idEspecie;
                    if (idEspecie != "0002226")
                    {
                        ocampoEnt.DESCRIPCION_ESPECIE = desEspecie;
                    }
                }
                if (idEspecieFauna != "0002226")
                {
                    ocampoEnt.COD_ESPECIES = idEspecieFauna == "0002226" ? null : idEspecieFauna;
                    if (idEspecieFauna != "0002226")
                    {
                        ocampoEnt.DESCRIPCION_ESPECIE = desEspecieFauna;
                    }
                }
                //MATIAS ocampoEnt.VOLUMEN = volumen == "" ? 0 : Decimal.Parse(volumen);
                //MATIAS ocampoEnt.AREA = area == "" ? 0 : Decimal.Parse(area);
                ocampoEnt.NUMERO_INDIVIDUOS = 0;
                ocampoEnt.DESCRIPCION_INFRACCIONES = descripcion;
                ocampoEnt.COD_SECUENCIAL = 0;
                ocampoEnt.NUM_POA = idPoa;
                ocampoEnt.POA = desPoa;
                ocampoEnt.TIPOMADERABLE = tipo;
                ocampoEnt.NUMERO_INDIVIDUOS = numInd == "" ? 0 : int.Parse(numInd);
                ocampoEnt.RegEstado = 1;
                //vmRD.ListarIniPAU.Add(ocampoEnt);
            }
            catch (Exception)
            {

            }
            return PartialView("~/Areas/Tribunal/Views/ManTribunal/_Shared/_generic/_renderListaEncisos.cshtml", vmRD);
        }

        [HttpPost]
        public JsonResult AddEditRD(CEntVM dto)
        {
            string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            CLogica exeBus = new CLogica();
            dto.ListPOA = vmRD.ListPOA;
            ListResult result = GuardarDatosRD(dto, codCuenta);
            return Json(result);
        }

        public JsonResult simularObservatorio(String[] listPoa, string codigo, string tipo)
        {
            ListResult result = new ListResult();
            CLogica exeBus = new CLogica();
            Int32 idRegistro = 0;
            string fileName = "";
            string ruta = "";
            string num_poa;
            string mensaje_err = "";
            try
            {

                num_poa = listPoa[0].ToString();
                string[] array = num_poa.Split(',');
                num_poa = array[0];
                Ent_TFFS oCEntObservatorio = new Ent_TFFS();
                oCEntObservatorio.COD_DOCUMENTO_REPORT = codigo;
                oCEntObservatorio.TIPO_DOCUMENTO_REPORT = tipo;
                oCEntObservatorio.NUM_POA_REPORT = Int32.Parse(num_poa);
                idRegistro = exeBus.RegPreProcesarObservatorio(oCEntObservatorio); // 3608

                if (idRegistro > 0)
                {
                    sigoWSObservatorio.WSObservatorioSoapClient ws = new sigoWSObservatorio.WSObservatorioSoapClient();
                    fileName = ws.escribirDetallePDFIndex(idRegistro, "~/PlantillaPDF/", "1") + ".pdf";
                }
                else
                {
                    mensaje_err = "Este Plan no esta contemplado para el procesamiento del Observatorio OSINFOR";
                }
                //result.AddResultado(fileName, true);
            }
            catch (Exception)
            {
                mensaje_err = "Este Plan no esta contemplado para el procesamiento del Observatorio OSINFOR";
            }


            return Json(new { fileName = fileName, errorMessage = mensaje_err }); //File(oBytes, "application/pdf");
        }

        public ActionResult agregarEspeciesMC(string codEspecie, string especie, string volumen, string arboles, string observaciones)
        {
            try
            {
                if (codEspecie != "0002226" || especie != "|" || volumen != "" || arboles != "")
                {
                    Ent_TFFS_MEDIDA_ESPECIE oCentidad = new Ent_TFFS_MEDIDA_ESPECIE();
                    oCentidad.COD_ESPECIES = codEspecie;
                    oCentidad.ESPECIES = especie;
                    oCentidad.VOLUMEN_MOVILIZADO = Convert.ToDecimal(volumen == "" ? "0" : volumen);
                    oCentidad.NUMERO_INDIVIDUOS = Convert.ToInt32(arboles == "" ? "0" : arboles);
                    oCentidad.OBSERVACION = observaciones;
                    oCentidad.RegEstado = 1;
                    //vmRD.ListEspecieMedCorrectiva.Add(oCentidad);
                }
            }
            catch (Exception)
            {

            }
            return PartialView("~/Areas/Tribunal/Views/ManTribunal/_Shared/_generic/_renderEspecieMC.cshtml", vmRD);
        }

        public JsonResult ImportarEspecieMC()
        {
            int band = 0;
            string mensaje = "Existe un error en: ";
            string err = "";
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                    {
                        string fileName = file.FileName;
                        string fileContentType = file.ContentType;
                        byte[] fileBytes = new byte[file.ContentLength];
                        var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));


                        using (var package = new ExcelPackage(file.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            var obj = new Ent_TFFS_MEDIDA_ESPECIE();
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                if (workSheet.Cells[rowIterator, 1].Value.ToString() != "" && workSheet.Cells[rowIterator, 2].Value.ToString() != "")
                                {
                                    obj = new Ent_TFFS_MEDIDA_ESPECIE();
                                    obj.RegEstado = 1;
                                    obj.COD_ESPECIES = " ";
                                    obj.COD_SECUENCIAL = 0;
                                    obj.ESPECIES = (workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString()) + " | " + (workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString());
                                    obj.VOLUMEN_MOVILIZADO = workSheet.Cells[rowIterator, 3].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 3].Value.ToString());
                                    obj.NUMERO_INDIVIDUOS = workSheet.Cells[rowIterator, 4].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 4].Value.ToString());
                                    obj.OBSERVACION = workSheet.Cells[rowIterator, 5].Value == null ? "" : workSheet.Cells[rowIterator, 5].Value.ToString();
                                    //vmRD.ListEspecieMedCorrectiva.Add(obj);

                                }
                                else
                                {
                                    band = 1;
                                    mensaje = mensaje + " " + workSheet.Cells[rowIterator, 1].Value.ToString() + "|" + workSheet.Cells[rowIterator, 2].Value.ToString() + " ,";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            if (band == 1)
            {
                err = mensaje;
            }
            var jsonResult = Json(new
            {
                //data = vmRD.ListEspecieMedCorrectiva,
                error = err
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
            //return PartialView("~/Areas/Fiscalizacion/Views/InformeLegal/Shared/_renderListaEspecies.cshtml", vmInfLegal);

        }

        #endregion
        public JsonResult ConsultaModal(DataTableRequest request = null)
        {

            CLogica exeBus = new CLogica();
            Ent_TFFS paramsBus = new Ent_TFFS();
            Ent_TFFS lstResult;
            //int rowcount = 0;
            int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

            paramsBus.BusFormulario = request.CustomSearchForm;
            paramsBus.BusCriterio = request.CustomSearchType;//NUM_EXPEDIENTE||NUM_RESOLUCION
            paramsBus.BusValor = request.CustomSearchValue;
            paramsBus.v_pagesize = request.Length;
            paramsBus.v_currentpage = page;

            lstResult = exeBus.RegMostrariNFORME_Buscar(paramsBus);

            var jsonResult = Json(new
            {
                data = lstResult.ListInformes.ToArray(),
                draw = request.Draw,
                recordsTotal = lstResult.v_ROW_INDEX,
                recordsFiltered = lstResult.v_ROW_INDEX,
                error = ""
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public void DescargarDocumentoAdjunto(string nombreArchivo, string nombreOriginal, string hdfCodTFFS)
        {
            string FilePath = "";

            if (String.IsNullOrEmpty(hdfCodTFFS))
            {
                FilePath = Path.Combine(HttpContext.Server.MapPath("~/Archivos/Temporales/"), nombreArchivo);
            }
            else
            {
                if (nombreArchivo == "")
                {
                    FilePath = Path.Combine(HttpContext.Server.MapPath("~/Ruta_SITD_Anexos/"), nombreOriginal);
                }
                else
                {
                    if (nombreArchivo != nombreOriginal)
                    {
                        FilePath = Path.Combine(HttpContext.Server.MapPath("~/Archivos/Temporales/"), nombreArchivo);
                    }
                    else
                    {
                        FilePath = Path.Combine(HttpContext.Server.MapPath("~/Ruta_SITD_Anexos/"), nombreOriginal);
                    }
                }
            }

            if (FilePath != "")
            {
                HttpContext.Response.Clear();
                HttpContext.Response.Charset = "";
                HttpContext.Response.ContentType = "application/download";
                HttpContext.Response.ContentEncoding = System.Text.Encoding.Default;
                HttpContext.Response.Charset = "";
                HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=" + nombreOriginal);
                HttpContext.Response.TransmitFile(FilePath);
                HttpContext.Response.Flush();
            }
        }

        [HttpGet]
        //[DeleteFileAttribute] //Action Filter, it will auto delete the file after download, 
        //I will explain it later
        public ActionResult Download(string file)
        {
            string fullPath = Path.Combine(Server.MapPath("~/PlantillaPDF/Descargas/"), file);
            return File(fullPath, "application/pdf", file);
        }
        public JsonResult importarInfracciones(string pcod_resodirec, string pcod_resodirec_ini_pau)
        {
            CEntResodirec importar = new CEntResodirec();
            importar.COD_RESODIREC = pcod_resodirec;
            importar.COD_RESODIREC_INI_PAU = pcod_resodirec_ini_pau;
            importar.BusValor = "TERMINO_PAU_TFFS";
            CLogResodirec oResodirec = new CLogResodirec();

            List<CEntResodirec> listLiteralesRD = new List<CEntResodirec>();
            try
            {
                listLiteralesRD = oResodirec.RegImportarIncisos(importar);
            }
            catch (Exception)
            {
                //HerUtil.MensajeBox(this, ex.Message, eMensajeTipo.Msgerror);
            }
            vmRD.tbInfracciones = listLiteralesRD;
            var jsonResult = Json(new
            {
                data = listLiteralesRD.ToArray(),
                error = ""
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public JsonResult ConsultarExpediente(string cCodificacion)
        {
            CLogica exeInf = new CLogica();
            Tra_M_Tramite_tffs result = exeInf.ConsultarTramite(cCodificacion);
            return Json(result);
        }
        private void RegistroLimpiar()
        {
            CEntidad entN = new CEntidad();
            VM_ResolucionTFFS vm = new VM_ResolucionTFFS();
            vm.hdfItemPersonaFirma = "";
            vm.lblItemPersonaFirma = "";
            vm.txtItemfecemi = "";
            vm.txtItemNumero1 = "";
            vm.txtItemNumero2 = "";
            vm.txtItemObservacion = "";
            vm.ddlItemIndicador = "0000000";
            vm.chkItemObsSubsanada = false;
            vm.chkItemObsSubsanada = false;
            vm.txtControlCalidadObservaciones = "";
            vm.chkPublicar = false;
            vm.txtControlCalidadObservaciones = "";
            vm.chkPublicar = false;
            vm.ddlTipoResolucionId = "0000000";
            vm.ddlResApelacionId = "0000000";
            vm.TextTramite = "";
            vm.txtFechaPresentacion = "";
            vm.txtQueja = "";
            vm.ddlResOtrosId = "0000000";
            vm.txtDescripcion = "";
            vm.ddlResTFFSDFFSId = "0000000";
            vm.ddlSentidoResId = "0000000";
            vm.txtDetermina = "";
            vm.txtDescripcionImprocedente = "";
            vm.txtDescripcionInadmisible = "";
            vm.txtDetermina2 = "";
            vm.txtDescripcionFundado = "";
            vm.txtDetermina_Multa = "0";
            vm.ddlConfirmaResolId = "0000000";
            vm.ddlEstadoPAUId = "0";
            vm.txtDetermina_MedidaCorrectiva = "";
            vm.ddlNulidadId = "0000000";
            vm.ddlInadmisibleId = "0000000";
            vm.ddlImprocedenteId = "0000000";
            vm.tbApeladas = new List<CEntidad>();
            vm.tbPersonas = new List<CEntidad>();
            vm.tbInfracciones = new List<Ent_RESODIREC>();
            vm.tbARFFS = new List<CEntidad>();
            vm.tbNoti = new List<CEntidad>();
            vm.lblUsuarioRegistro = "";
            vm.lblUsuarioControl = "";
            vm.chkConfirmar = false;
            vm.chkRevocar = false;
            vm.chkRevocarParte = false;
            vm.chkRetrotraer = false;
            vm.chkPrescribir = false;
            vm.chkArchivar = false;
            vm.chkNulidad = false;
            vm.chkLevantar = false;
            vm.chkCarece = false;
            vm.chkOtro = false;
            vm.chkConfirmar2 = false;
            vm.chkRevocar2 = false;
            vm.chkRevocarParte2 = false;
            vm.chkRetrotraer2 = false;
            vm.chkPrescribir2 = false;
            vm.chkArchivar2 = false;
            vm.chkNulidad2 = false;
            vm.chkLevantar2 = false;
            vm.chkCarece2 = false;
            vm.chkOtro2 = false;
            vm.txtDescripcionFParte = "";
            vm.txtDetermina3 = "";
            vm.txtDescripcionInfundado = "";
            vm.txtDescripcionOtro = "";
            vm.ddlDeterminaRetrotraerId = "0000000";
            vm.ddlRetrotraerId = "0000000";
            vm.txtDescripcionOtros = "";
            vm.txtDescripcionRetrotraer = "";
            vm.txtDescripcionSuspension = "";
            vm.txtDescripcionCumplimiento = "";
            vm.txtDescripcionDesestimiento = "";
            vm.ddlLevantamientoId = "0000000";
            vm.ddlMedCorrectId = "0000000";
            vm.ddlCMultaId = "0000000";
            vm.ddlAmonestacionId = "0000000";
            vm.txtArchivoAdjunto = "";
            vm.txtTitular = "";
            vm.txtResponsable = "";
            vm.txtRegente = "";
            vm.txtARFFS2 = "";
            vm.txtATFFS = "";
            vm.txtMinPublico = "";
            vm.txtMinEnergia = "";
            vm.txtColeInge = "";
            vm.txtOCI = "";
            vm.txtOEFA = "";
            vm.txtSUNAT = "";
            vm.txtSERFOR = "";
            vm.txtOtros = "";
            vm.txtDFFFS = "";
            vm.txtDSFFS = "";
            vm.txtURH = "";
            vm.txtOCI2 = "";
            vm.txtOtros2 = "";
            vm.hdfManRegEstado = "";
            vm.txtProfesional = "";
            vm.txtCargo = "";
            vm.txtnomArchOriginal = "";
            vm.txtnomArchTemporal = "";
            vm.txtextArch = "";
            vm.txtestadoArch = "";
            vm.txtcCodificacionSiTD = "";
            vm.chkCambiaEstEspecieISuperv = false;
            vm.lbtnMaderable = "Ir Datos Campo Maderable (0)";
            vm.lbtnSemilleroMaderable = "Ir Datos Semillero Maderable (0)";
        }
        private void ValidarDatos(VM_ResolucionTFFS _dto)
        {
            if (_dto.vmControlCalidad.ddlIndicadorId == "0000000") throw new Exception("Seleccione el estado actual del registro");
            if (string.IsNullOrEmpty(_dto.txtItemNumero2)) throw new Exception("Ingrese el número de Resolución TFFS");
            if (string.IsNullOrEmpty(_dto.txtFechaEmision)) throw new Exception("Seleccione la fecha de emisión");
            if (_dto.ListInformes == null && (_dto.COD_RESOLUCION_TFFS_RECTIFICA == null || _dto.COD_RESOLUCION_TFFS_RECTIFICA == " ")) throw new Exception("Seleccione por lo menos una resolución");
            if (_dto.ListInformes == null && _dto.ddlResApelacionId != "0000000" && (_dto.ddlResApelacionId != "0000037" || _dto.ddlResApelacionId != "0000038")) throw new Exception("Seleccione por lo menos una resolución");
            if (_dto.ddlTipoResolucionId == "0000000") throw new Exception("Seleccione un tipo de Resolución");
            if (_dto.ddlTipoResolucionId == "0000001" && _dto.ddlResApelacionId == "0000000") throw new Exception("Seleccione un tipo de Apelación");
            if (_dto.ddlTipoResolucionId == "0000003" && _dto.ddlResOtrosId == "0000000") throw new Exception("Seleccione un valor para Otros");
            if (_dto.ddlTipoResolucionId == "0000003" && _dto.ddlResOtrosId == "0000040" && _dto.ddlResTFFSDFFSId == "0000000") throw new Exception("Seleccione un tipo de Nulidad de Oficio");
            if (_dto.ddlSentidoResId == "0000053" && _dto.ddlImprocedenteId == "0000000") throw new Exception("Seleccione un valor para Improcedente");
            if (_dto.ddlSentidoResId == "0000054" && _dto.ddlInadmisibleId == "0000000") throw new Exception("Seleccione un valor para Inadmisible");
            if (_dto.ddlSentidoResId == "0000055" && _dto.chkConfirmar == false && _dto.chkRevocar == false && _dto.chkRevocarParte == false && _dto.chkRetrotraer == false && _dto.chkPrescribir == false && _dto.chkArchivar == false && _dto.chkNulidad == false && _dto.chkLevantar == false && _dto.chkCarece == false && _dto.chkOtro == false) throw new Exception("Seleccione un valor para Fundado");
            if (_dto.ddlSentidoResId == "0000055" && _dto.chkRevocar == true && _dto.radGrupoRevocar is null) throw new Exception("Seleccione un valor para Revocar");
            if (_dto.ddlSentidoResId == "0000055" && _dto.chkNulidad == true && _dto.radNulidad is null) throw new Exception("Seleccione un valor para Nulidad");
            if (_dto.ddlSentidoResId == "0000055" && _dto.chkRetrotraer == true && _dto.radRetrotraer is null) throw new Exception("Seleccione un valor para Retrotraer");
            if (_dto.ddlSentidoResId == "0000056" && _dto.chkConfirmar2 == false && _dto.chkRevocar2 == false && _dto.chkRevocarParte2 == false && _dto.chkRetrotraer2 == false && _dto.chkPrescribir2 == false && _dto.chkArchivar2 == false && _dto.chkNulidad2 == false && _dto.chkLevantar2 == false && _dto.chkCarece2 == false && _dto.chkOtro2 == false) throw new Exception("Seleccione un valor para Fundado en Parte");
            if (_dto.ddlSentidoResId == "0000056" && _dto.chkRevocar2 == true && _dto.radGrupoRevocar2 is null) throw new Exception("Seleccione un valor para Revocar");
            if (_dto.ddlSentidoResId == "0000056" && _dto.chkNulidad2 == true && _dto.radNulidad2 is null) throw new Exception("Seleccione un valor para Nulidad");
            if (_dto.ddlSentidoResId == "0000056" && _dto.chkRetrotraer2 == true && _dto.radRetrotraer2 is null) throw new Exception("Seleccione un valor para Retrotraer");
            if (_dto.ddlSentidoResId == "0000058" && _dto.ddlNulidadId == "0000000") throw new Exception("Seleccione un valor para Nulidad");
            if (_dto.ddlSentidoResId == "0000058" && _dto.ddlDeterminaRetrotraerId == "0000000" && _dto.ddlRetrotraerId == "0000000") throw new Exception("Seleccione ambos valores para Determina");
            if (_dto.ddlSentidoResId == "0000058" && (_dto.ddlDeterminaRetrotraerId == "0000084" || _dto.ddlDeterminaRetrotraerId == "0000085") && _dto.ddlRetrotraerId == "0000000") throw new Exception("Seleccione ambos valores para Determina");
            if (_dto.ddlSentidoResId == "0000058" && _dto.ddlDeterminaRetrotraerId == "0000000" && _dto.ddlRetrotraerId != "0000000") throw new Exception("Seleccione ambos valores para Determina");
            if (_dto.ddlSentidoResId == "0000059" && _dto.ddlNulidad_Id == "0000000") throw new Exception("Seleccione un valor para Nulidad Parcial");
            if (_dto.ddlSentidoResId == "0000059" && _dto.ddlDeterminaRetrotraerId2 == "0000000" && _dto.ddlRetrotraerId2 == "0000000") throw new Exception("Seleccione ambos valores para Determina");
            if (_dto.ddlSentidoResId == "0000059" && (_dto.ddlDeterminaRetrotraerId2 == "0000084" || _dto.ddlDeterminaRetrotraerId2 == "0000085") && _dto.ddlRetrotraerId2 == "0000000") throw new Exception("Seleccione ambos valores para Determina");
            if (_dto.ddlSentidoResId == "0000059" && _dto.ddlDeterminaRetrotraerId2 == "0000000" && _dto.ddlRetrotraerId2 != "0000000") throw new Exception("Seleccione ambos valores para Determina");
            if (_dto.ddlConfirmaResolId == "00000112" && _dto.ddlMedCorrectId == "00000115" && string.IsNullOrEmpty(_dto.txtDetermina_MedidaCorrectiva)) throw new Exception("Ingrese la descripción de Medidas Correctivas");
            if (_dto.ddlConfirmaResolId == "00000113" && _dto.ddlMedCorrectId == "00000115" && string.IsNullOrEmpty(_dto.txtDetermina_MedidaCorrectiva)) throw new Exception("Ingrese la descripción de Medidas Correctivas");
            if (_dto.ddlConfirmaResolId == "00000114" && _dto.ddlMedCorrectId == "00000115" && string.IsNullOrEmpty(_dto.txtDetermina_MedidaCorrectiva)) throw new Exception("Ingrese la descripción de Medidas Correctivas");
            if (_dto.ddlConfirmaResolId == "00000112" && _dto.ddlCMultaId == "00000115" && string.IsNullOrEmpty(_dto.txtDetermina_Multa)) throw new Exception("Ingrese el monto de multa UIT");
            if (_dto.ddlConfirmaResolId == "00000113" && _dto.ddlCMultaId == "00000115" && string.IsNullOrEmpty(_dto.txtDetermina_Multa)) throw new Exception("Ingrese el monto de multa UIT");
            if (_dto.ddlConfirmaResolId == "00000114" && _dto.ddlCMultaId == "00000115" && string.IsNullOrEmpty(_dto.txtDetermina_Multa)) throw new Exception("Ingrese el monto de multa UIT");
            //if (_dto.hdfCodTipoIlegal == "0000001" && _dto.txtIdRecomendacion == "0000000") throw new Exception("Seleccione una recomendación");
        }
        public ListResult GuardarDatosRD(VM_ResolucionTFFS _dto, string asCodUCuenta)
        {
            ListResult result = new ListResult();
            CEntidad oCEntTFFS = new CEntidad();
            CLogica oCLogicaTFFS = new CLogica();
            try
            {
                this.ValidarDatos(_dto);
                CEntidad oParams = new CEntidad();
                oParams.COD_RESOLUCION_TFFS = _dto.hdfCodTFFS;
                if (_dto.RegEstado == 1)
                {
                    oParams.COD_RESOLUCION_TFFS = "0";
                }

                oParams.COD_UCUENTA = asCodUCuenta;
                oParams.NUM_RESOLUCION_TFFS = _dto.txtItemNumero2.Trim();
                oParams.FECHA_DOCUMENTO = _dto.txtFechaEmision;
                //------------      18-11-2020-------------------------------

                oParams.OBSERVACIONES = _dto.txtItemObservacion;
                oParams.COD_ESTADO_DOC = _dto.vmControlCalidad.ddlIndicadorId;
                oParams.OBSERVACIONES_CONTROL = _dto.txtControlCalidadObservaciones;
                oParams.PUBLICAR = _dto.chkPublicar;
                oParams.TIP_RES = _dto.ddlTipoResolucionId;
                oParams.RES_APE = _dto.ddlResApelacionId;
                oParams.N_TRAMITE = _dto.inptExpediente;
                oParams.FECHA_PRESENTACION = _dto.txtFechaPresentacion;
                oParams.QUEJA_OBS = _dto.txtQueja;
                oParams.RES_OTROS = _dto.ddlResOtrosId;
                oParams.DESCRIP_TEXT = _dto.txtDescripcion;
                oParams.OTROS_NULI = _dto.ddlResTFFSDFFSId;
                oParams.SENTIDO_RES = _dto.ddlSentidoResId;
                oParams.RESOL_IMPRO = _dto.ddlImprocedenteId;
                oParams.RESOL_DET = _dto.txtDetermina;
                oParams.DESCRIP_TEXT_IMPRO = _dto.txtDescripcionImprocedente;
                oParams.RESOL_DET2 = _dto.txtDetermina2;
                oParams.RESOL_INAD = _dto.ddlInadmisibleId;
                oParams.DESCRIP_TEXT_INAD = _dto.txtDescripcionInadmisible;
                oParams.DESCRIP_TEXT_FUND = _dto.txtDescripcionFundado;
                oParams.DESCRIP_TEXT_SENTIDO = _dto.txtDescripcionSentido;
                oParams.CHKCONFIRMAR = _dto.chkConfirmar == true ? 1 : 0;
                oParams.CHKREVOCAR = _dto.chkRevocar == true ? 1 : 0;
                oParams.RADREVOCAR = _dto.radGrupoRevocar;
                oParams.RADNULIDAD = _dto.radNulidad;
                oParams.CHKREVOCARPARTE = _dto.chkRevocarParte == true ? 1 : 0;
                oParams.RADREVOCARPARTE = _dto.radGrupoRevocarParte;
                oParams.CHKRETROTRAER = _dto.chkRetrotraer == true ? 1 : 0;
                oParams.CHKPRESCRIBIR = _dto.chkPrescribir == true ? 1 : 0; ;
                oParams.CHKARCHIVAR = _dto.chkArchivar == true ? 1 : 0;
                oParams.CHKNULIDAD = _dto.chkNulidad == true ? 1 : 0;
                oParams.CHKLEVANTAR = _dto.chkLevantar == true ? 1 : 0;
                oParams.CHKCARECE = _dto.chkCarece == true ? 1 : 0;
                oParams.CHKOTRO = _dto.chkOtro == true ? 1 : 0;
                oParams.DESCRIP_TEXT_FPARTE = _dto.txtDescripcionFParte;
                oParams.CHKCONFIRMAR2 = _dto.chkConfirmar2 == true ? 1 : 0;
                oParams.CHKREVOCAR2 = _dto.chkRevocar2 == true ? 1 : 0;
                oParams.RADREVOCAR2 = _dto.radGrupoRevocar2;
                oParams.RADNULIDAD2 = _dto.radNulidad2;
                oParams.RADRETROTRAER = _dto.radRetrotraer;
                oParams.RADRETROTRAER2 = _dto.radRetrotraer2;
                oParams.CHKREVOCARPARTE2 = _dto.chkRevocarParte2 == true ? 1 : 0;
                oParams.RADREVOCARPARTE2 = _dto.radGrupoRevocarParte2;
                oParams.CHKRETROTRAER2 = _dto.chkRetrotraer2 == true ? 1 : 0;
                oParams.CHKPRESCRIBIR2 = _dto.chkPrescribir2 == true ? 1 : 0;
                oParams.CHKARCHIVAR2 = _dto.chkArchivar2 == true ? 1 : 0;
                oParams.CHKNULIDAD2 = _dto.chkNulidad2 == true ? 1 : 0;
                oParams.CHKLEVANTAR2 = _dto.chkLevantar2 == true ? 1 : 0;
                oParams.CHKCARECE2 = _dto.chkCarece2 == true ? 1 : 0;
                oParams.CHKOTRO2 = _dto.chkOtro2 == true ? 1 : 0;
                oParams.RESOL_DET3 = _dto.txtDetermina3;
                oParams.DESCRIP_TEXT_INFU = _dto.txtDescripcionInfundado;
                oParams.CMB_NULIDAD = _dto.ddlNulidadId;
                oParams.CMB_NULIDAD2 = _dto.ddlNulidad_Id;
                oParams.DESCRIP_TEXT_OTRO = _dto.txtDescripcionOtro;
                oParams.DETERMINA_RETROTRAER = _dto.ddlDeterminaRetrotraerId;
                oParams.RETRO_VALOR1 = _dto.ddlRetrotraerId;
                oParams.DESCRIP_TEXT_OTROS = _dto.txtDescripcionOtros;
                oParams.DESCRIP_TEXT_RETROTRAER = _dto.txtDescripcionRetrotraer;
                oParams.DESCRIP_TEXT_SUSPENSION = _dto.txtDescripcionSuspension;
                oParams.DESCRIP_TEXT_CUMPLIMIENTO = _dto.txtDescripcionCumplimiento;
                oParams.DESCRIP_TEXT_DESESTIMIENTO = _dto.txtDescripcionDesestimiento;
                oParams.CONFIRM_RESOL = _dto.ddlConfirmaResolId;
                oParams.LEVANTAMIENTO = _dto.ddlLevantamientoId;
                oParams.MEDIDAS_CORRECTIVAS2 = _dto.ddlMedCorrectId;
                oParams.DESCRIPCION_MED_CORRECTIVAS = _dto.txtDetermina_MedidaCorrectiva;
                oParams.CAMBIO_MULTA2 = _dto.ddlCMultaId;
                oParams.MULTA2 = _dto.txtDetermina_Multa;
                oParams.AMONESTACION2 = _dto.ddlAmonestacionId;
                oParams.ESTADO_PAU = _dto.ddlEstadoPAUId;
                oParams.ARCHIVO_ADJUNTO = _dto.txtArchivoAdjunto;
                oParams.TITULAR_INT = _dto.txtTitular;
                oParams.RESPONSABLE_SOL = _dto.txtResponsable;
                oParams.REGENTE = _dto.txtRegente;
                oParams.ARFFS2 = _dto.txtARFFS2;
                oParams.ATFFS = _dto.txtATFFS;
                oParams.MINPUBLICO = _dto.txtMinPublico;
                oParams.MINENERGIA = _dto.txtMinEnergia;
                oParams.COLEINGE = _dto.txtColeInge;
                oParams.OCI = _dto.txtOCI;
                oParams.OEFA = _dto.txtOEFA;
                oParams.SUNAT = _dto.txtSUNAT;
                oParams.SERFOR = _dto.txtSERFOR;
                oParams.OTROS = _dto.txtOtros;
                oParams.DFFFS = _dto.txtDFFFS;
                oParams.DSFFS = _dto.txtDSFFS;
                oParams.URH = _dto.txtURH;
                oParams.OCI2 = _dto.txtOCI2;
                oParams.OTROS2 = _dto.txtOtros2;
                oParams.PROFESIONAL = _dto.txtProfesional;
                oParams.CARGO = _dto.txtCargo;
                oParams.DETERMINA_RETROTRAER2 = _dto.ddlDeterminaRetrotraerId2;
                oParams.RETRO_VALOR2 = _dto.ddlRetrotraerId2;
                oParams.DESCRIP_TEXT_OTROS2 = _dto.txtDescripcionOtros2;
                oParams.DESCRIP_TEXT_RETROTRAER2 = _dto.txtDescripcionRetrotraer2;
                oParams.COD_RESOLUCION_TFFS_RECTIFICA = _dto.COD_RESOLUCION_TFFS_RECTIFICA;
                oParams.NOMBRE_ARCHIVO = _dto.txtnomArchOriginal;
                oParams.NOMBRE_TEMPORAL_ARCHIVO = _dto.txtnomArchTemporal;
                oParams.EXTENSION_ARCHIVO = _dto.txtextArch;
                oParams.ESTADO_ARCHIVO = _dto.txtestadoArch;
                oParams.cCodificacion_SiTD = _dto.txtcCodificacionSiTD;
                oParams.OUTPUTPARAM01 = "";
                oParams.RegEstado = _dto.RegEstado;
                if (oParams.ESTADO_ARCHIVO == "1" || oParams.ESTADO_ARCHIVO == "2")
                {
                    string nombreArchivoReg = oParams.NUM_RESOLUCION_TFFS.Trim() + "_" + DateTime.Now.Ticks + "." + oParams.EXTENSION_ARCHIVO;
                    string nombreArchivoRegTemp = oParams.NUM_RESOLUCION_TFFS.Trim() + DateTime.Now.ToShortDateString() + "." + oParams.EXTENSION_ARCHIVO;
                    nombreArchivoReg = nombreArchivoReg.Trim().Replace('/', '-').Replace(" ", "").Replace("|", "-").Replace('"', '.').Replace('\\', '-');
                    nombreArchivoRegTemp = nombreArchivoRegTemp.Trim().Replace('/', '-').Replace(" ", "").Replace("|", "-").Replace('"', '.').Replace('\\', '-');
                    if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/Archivos/Temporales/"), oParams.NOMBRE_TEMPORAL_ARCHIVO)))
                    {
                        //verificando si existe archivo en el repositorio. si existe lo trasladamos a la carpeta Ruta_SITD_Anexos/eliminados como temporal
                        if (System.IO.File.Exists(Path.Combine(Server.MapPath("~/Ruta_SITD_Anexos/"), nombreArchivoReg)))
                        {
                            System.IO.File.Copy(Path.Combine(Server.MapPath("~/Ruta_SITD_Anexos/"), nombreArchivoReg), Path.Combine(Server.MapPath("~/Ruta_SITD_Anexos/Eliminados"), nombreArchivoRegTemp), true);
                        }
                        //moviendo archivos a la carpeta 
                        System.IO.File.Copy(Path.Combine(Server.MapPath("~/Archivos/Temporales/"), oParams.NOMBRE_TEMPORAL_ARCHIVO), Path.Combine(Server.MapPath("~/Ruta_SITD_Anexos/"), nombreArchivoReg), true);

                        System.IO.File.Delete(Path.Combine(Server.MapPath("~/Archivos/Temporales/"), oParams.NOMBRE_TEMPORAL_ARCHIVO));
                    }
                    //oParams.ARCHIVO_ADJUNTO = oParams.NOMBRE_ARCHIVO + "." + oParams.EXTENSION_ARCHIVO;
                    oParams.EXTENSION_ARCHIVO = null;
                    oParams.ARCHIVO_ADJUNTO = nombreArchivoReg;
                }
                else
                {
                    oParams.NOMBRE_ARCHIVO = null;
                    oParams.EXTENSION_ARCHIVO = null;
                    oParams.NOMBRE_TEMPORAL_ARCHIVO = null;
                    oParams.ESTADO_ARCHIVO = null;
                }

                oParams.cCodificacion_SiTD = null;
                oParams.CHKTITULAR = _dto.chkTitular == true ? 1 : 0;
                oParams.CHKRESPONSABLE = _dto.chkResponsable == true ? 1 : 0;
                oParams.CHKREGENTE = _dto.chkRegente == true ? 1 : 0;
                oParams.CHKARFFS2 = _dto.chkARFFS == true ? 1 : 0;
                oParams.CHKATFFS = _dto.chkATFFS == true ? 1 : 0;
                oParams.CHKMINPUBLICO = _dto.chkMinPublico == true ? 1 : 0;
                oParams.CHKMINENERGIA = _dto.chkMinEnergia == true ? 1 : 0;
                oParams.CHKCOLEINGE = _dto.chkColeInge == true ? 1 : 0;
                oParams.CHKOCI = _dto.chkOCI == true ? 1 : 0;
                oParams.CHKOEFA = _dto.chkOEFA == true ? 1 : 0;
                oParams.CHKSUNAT = _dto.chkSUNAT == true ? 1 : 0;
                oParams.CHKSERFOR = _dto.chkSERFOR == true ? 1 : 0;
                oParams.CHKOTROS = _dto.chkOtros == true ? 1 : 0;
                oParams.CHKDFFFS = _dto.chkDFFFS == true ? 1 : 0;
                oParams.CHKDSFFS = _dto.chkDSFFS == true ? 1 : 0;
                oParams.CHKURH = _dto.chkURH == true ? 1 : 0;
                oParams.CHKOCI2 = _dto.chkOCI2 == true ? 1 : 0;
                oParams.CHKOTROS2 = _dto.chkOtros2 == true ? 1 : 0;
                //------------- grillas ---------------------------
                oParams.ListInformes = _dto.ListInformes;
                oParams.ListPersonaFirma = _dto.ListPersonaFirma;
                oParams.ListInfraccionRD = _dto.ListInfraccionRD;
                //oParams.ListARFFS = _dto.ListARFFS;
                //oParams.ListNoti = _dto.ListNoti;
                //oParams.ListResApeTFFS = _dto.ListResApeTFFS;                   


                if (_dto.listEliInformes != null)
                {
                    if (_dto.listEliInformes.Count > 0)
                    {
                        if (oParams.ListEliTABLA == null)
                        {
                            oParams.ListEliTABLA = new List<CEntidad>();
                        }
                        for (int i = 0; i < _dto.listEliInformes.Count; i++)
                        {
                            CEntidad temp = new CEntidad();
                            temp = _dto.listEliInformes[i];
                            oParams.ListEliTABLA.Add(temp);
                        }
                    }
                }
                if (_dto.listELiPersonaFirma != null)
                {
                    if (_dto.listELiPersonaFirma.Count > 0)
                    {
                        if (oParams.ListEliTABLA == null)
                        {
                            oParams.ListEliTABLA = new List<CEntidad>();
                        }
                        for (int i = 0; i < _dto.listELiPersonaFirma.Count; i++)
                        {
                            CEntidad temp = new CEntidad();
                            temp = _dto.listELiPersonaFirma[i];
                            oParams.ListEliTABLA.Add(temp);
                        }
                    }
                }
                if (_dto.listEliInfracciones != null)
                {
                    if (_dto.listEliInfracciones.Count > 0)
                    {
                        if (oParams.ListEliTABLA == null)
                        {
                            oParams.ListEliTABLA = new List<CEntidad>();
                        }
                        for (int i = 0; i < _dto.listEliInfracciones.Count; i++)
                        {
                            CEntidad temp = new CEntidad();
                            temp = _dto.listEliInfracciones[i];
                            oParams.ListEliTABLA.Add(temp);
                        }
                    }
                }

                oParams.ListPOAs = new List<CEntidad>();
                if (_dto.ListPOA != null)
                {
                    foreach (Ent_TFFS poa in _dto.ListPOA)
                    {
                        Ent_TFFS item = new Ent_TFFS();
                        item.COD_RESOLUCION_TFFS = poa.COD_RESOLUCION_TFFS;
                        item.NUM_POA = poa.NUM_POA;
                        item.COD_UCUENTA = asCodUCuenta;
                        if (_dto.ListPOAChecked != null)
                        {
                            foreach (string poacheck in _dto.ListPOAChecked)
                            {
                                Ent_RESODIREC item2 = new Ent_RESODIREC();
                                item2.NUM_POA = poacheck;
                                if (item.NUM_POA == item2.NUM_POA)
                                {
                                    item.PUBLICAR = true;
                                }
                            }
                        }
                        //item.PUBLICAR = _dto.chkPublicar;
                        oParams.ListPOAs.Add(item);
                    }
                }

                String estado_final = oCLogicaTFFS.RegGrabaResolucion_TFFS(oParams);
                if (estado_final != "0" && estado_final != "1")
                {
                    RegistroLimpiar();
                }
                result.AddResultado("Guardo Correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        [HttpPost]
        public JsonResult GrabarDocumentoAdjunto()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    CEntidad entN = JsonConvert.DeserializeObject<CEntidad>(Request.Form["data"]);
                    HttpPostedFileBase file = Request.Files[0];//  Get all files from Request object 
                    CLogica exeBus = new CLogica();
                    string nomArch = "", extArch = "";
                    string nameArch = "";

                    nameArch = file.FileName;
                    nomArch = nameArch.Substring(0, nameArch.LastIndexOf("."));
                    nomArch = (nomArch.Length >= 200 ? nomArch.Substring(0, 200) : nomArch);
                    extArch = nameArch.Substring(nameArch.LastIndexOf(".") + 1).ToLower();
                    string fname = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "." + extArch;

                    file.SaveAs(Path.Combine(Server.MapPath("~/Archivos/Temporales/"), fname));

                    entN.NOMBRE_ARCHIVO = nomArch + "." + extArch;
                    entN.NOMBRE_TEMPORAL_ARCHIVO = fname;
                    entN.EXTENSION_ARCHIVO = extArch;
                    entN.ESTADO_ARCHIVO = "1";

                    return Json(new { success = true, msj = "Se subio correctamente el archivo", data = entN });
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                return Json(new { success = false, msj = "No se encontró el documento a subir" });
            }
        }

    }


}




