using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using CapaLogica.DOC;
using OfficeOpenXml;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using SIGOFCv3.Models.DataTables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_Resodirec;
//using CEntVM = CapaEntidad.ViewModel.VM_InformeLegal;
using CLogica = CapaLogica.DOC.Log_RESODIREC;


namespace SIGOFCv3.Areas.Fiscalizacion.Controllers
{
    public class ManResolucionController : Controller
    {
        private CLogica logRD = new CLogica();
        //public static CEntVM vmRD = new CEntVM();

        // GET: Fiscalizacion/ManResolucion
        public ActionResult Index(string doc)
        {
            // return View();
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            //ViewBag.Usuario = logRD.RegistroUsuario((ModelSession.GetSession())[0].COD_UCUENTA);

            string form = "", formTitle = "";
            switch (doc)
            {
                case "rsd":
                    form = "RESOLUCION_SUBDIRECTORAL";
                    formTitle = "Resolución Sub Directoral";
                    break;
                //case "ifi":
                //    form = "INFORME_FINAL_INSTRUCCION";
                //    formTitle = "Informe Final de Instrucción";
                //    break;
                case "rd":
                    form = "RESOLUCION_DIRECTORAL";
                    formTitle = "Resolución Directoral";
                    break;
                default: throw new Exception("No se ha especificado el tipo de documento");
            }

            ViewBag.Formulario = form;
            ViewBag.TituloFormulario = formTitle;

            ViewBag.Criterio = "TODOS";
            ViewBag.AlertaInicial = "";
            ViewBag.ddlListOpciones = exeBus.RegMostComboIndividual_v3("RESOLUCION_DIRECTORAL", "");
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO FISCALIZACION", "Resolución Sub Directoral");
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
            result = logRD.RegistroUsuario((ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }

        public JsonResult ExportarInfracciones(CEntVM dto)


        {
            ListResult result = new ListResult();
            result = logRD.InfraccionesRD(dto);
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
                if(!string.IsNullOrEmpty(asCodRD) && !asCodRD.All(char.IsDigit))
                {
                    throw new Exception("Código de resolución incorrecto");
                }
                
                ViewBag.Usuario = ModelSession.GetSession()?.FirstOrDefault();

                CEntVM vmRD = new CEntVM();
                vmRD = logRD.initRD(asCodRD, asCodTipoIL);
                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO FISCALIZACION", "Resolución Sub Directoral");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;
                //Pasamos el Rol del usuario
                vmRD.vmControlCalidad.VALIAS_ROL = mr.VALIAS;

                return View(vmRD);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("ErrorC", "Index");
            }
        }

        [HttpGet]
        public JsonResult ObtenerResolucion(string asCodRD = "", string asCodTipoIL = "")
        {
            var result = logRD.RSD_Resumen(asCodRD, asCodTipoIL);
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// metodo para consultar la lista de expedientes  de la resolucion
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult ConsultaModal(DataTableRequest request = null)
        {

            CLogica exeBus = new CLogica();
            Ent_RESODIREC paramsBus = new Ent_RESODIREC();
            Ent_RESODIREC lstResult;
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

        public ActionResult _inicisos(string idArticulo, string descArticulo)
        {
            CEntVM vmRD = new CEntVM();
            CLogica exeBus = new CLogica();
            vmRD.ddlArticuloId = idArticulo;
            vmRD.txtArticulo = descArticulo;
            vmRD.listaIncisos = exeBus.initCombos("ENCISOS", idArticulo);
            return PartialView("~/Areas/Fiscalizacion/Views/ManResolucion/_Shared/_incisos.cshtml", vmRD);
        }

        public ActionResult importarInfraccionesRD(DataTableRequest request = null)
        {
            CLogica exeBus = new CLogica();
            Ent_RESODIREC paramsBus = new Ent_RESODIREC();
            //paramsBus.COD_RESODIREC = vmRD.listInformes[0].COD_RESODIREC;
            //paramsBus.COD_RESODIREC_INI_PAU = vmRD.hdfCodResodirec;
            paramsBus.BusValor = "INICIO_PAU";

            var result = exeBus.RegImportarIncisos(paramsBus);

            var jsonResult = Json(new
            {
                data = result.ToArray(),
                draw = request.Draw,
                recordsTotal = result.Count,
                recordsFiltered = result.Count,
                error = ""
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

        }

        public ActionResult importarInfraccionesRDT(DataTableRequest request = null)
        {
            CLogica exeBus = new CLogica();
            Ent_RESODIREC paramsBus = new Ent_RESODIREC();
            //paramsBus.COD_RESODIREC = vmRD.listInformes[0].COD_RESODIREC;
            //paramsBus.COD_RESODIREC_INI_PAU = vmRD.listInformes[0].COD_RESODIREC_INI_PAU;
            paramsBus.BusValor = "TERMINO_PAU";

            var result = exeBus.RegImportarIncisos(paramsBus);

            var jsonResult = Json(new
            {
                data = result.ToArray(),
                draw = request.Draw,
                recordsTotal = result.Count,
                recordsFiltered = result.Count,
                error = ""
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

        }

        public ActionResult inicisos(string idArticulo, string descArticulo, string codEncisoSelect)
        {
            CEntVM vmRD = new CEntVM();
            CLogica exeBus = new CLogica();
            vmRD.txtIdArticulo = idArticulo;
            vmRD.txtDescripcionArticulo = descArticulo;
            vmRD.ListIncisos = exeBus.initArticulos("ENCISOS", idArticulo);
            vmRD.hdfCodEnciso = codEncisoSelect;
            return PartialView("~/Areas/Fiscalizacion/Views/ManResolucion/_Shared/_generic/_renderEncisos.cshtml", vmRD);
        }

        public ActionResult subTipoArchivo(string idMotivo, string descMotivo)
        {
            CEntVM vmRD = new CEntVM();
            CLogica exeBus = new CLogica();
            vmRD.txtIdTipoMotivoArch = idMotivo;
            vmRD.txtDescTipoMotivoArch = descMotivo;
            vmRD.ListSubTipoArchivo = exeBus.initArticulos("TIPO_ARCHIVO", idMotivo);
            return PartialView("~/Areas/Fiscalizacion/Views/ManResolucion/_Shared/_generic/_renderMotivoArchivo.cshtml", vmRD);
        }

        [HttpPost]
        public ActionResult agregarMotivoArchivo(string codigoSub, string motivo, string detalleMotivo, string descmMtivo)
        {
            CEntVM vmRD = new CEntVM();

            try
            {
                Ent_RESODIREC ocampoEnt = new Ent_RESODIREC();
                ocampoEnt.CODIGO = codigoSub;
                ocampoEnt.MOTIVO = motivo;
                ocampoEnt.DETALLE_MOTIVO = detalleMotivo.Replace("\n", "").Replace("\t", "");
                ocampoEnt.DESCRIPCIONMOTIVO = descmMtivo.Replace("\n", "").Replace("\t", "");
                ocampoEnt.RegEstado = 1;
                vmRD.ListMotivoArchivo.Add(ocampoEnt);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            return PartialView("~/Areas/Fiscalizacion/Views/ManResolucion/_Shared/_generic/_renderListaMotiva.cshtml", vmRD);
        }

        public ActionResult busInfraccionesRDInicio(DataTableRequest request = null)
        {
            CLogica exeBus = new CLogica();

            Ent_RESODIREC importar = new Ent_RESODIREC();
            //importar.COD_RESODIREC = vmRD.listInformes[0].COD_RESODIREC; //oCEntResodirec.ListInformes[0].COD_RESODIREC;
            //importar.COD_RESODIREC_INI_PAU = vmRD.listInformes[0].COD_RESODIREC_INI_PAU;
            importar.BusValor = "INICIO_PAU";

            var result = exeBus.RegImportarIncisos(importar);

            var jsonResult = Json(new
            {
                data = result.ToArray(),
                draw = request.Draw,
                recordsTotal = result.Count,
                recordsFiltered = result.Count,
                error = ""
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult listaPoa(List<Ent_RESODIREC> dto)
        {
            CEntVM vmRD = new CEntVM();

            if (dto.Count > 0)
            {
                List<Ent_RESODIREC> listPoa = new List<Ent_RESODIREC>();
                CLogica exeBus = new CLogica();
                Ent_RESODIREC oCEntidad = new Ent_RESODIREC();
                oCEntidad.BusFormulario = "RESOLUCION_DIRECTORAL";
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

            // return PartialView("~/Areas/Fiscalizacion/Views/ManResolucion/_Shared/_generic/_renderListPOA.cshtml", vmRD);
            var jsonResult = Json(new
            {
                data = vmRD.ListPOA,
                draw = "",
                error = "",
                success = true
            }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public JsonResult listaParcela(String CodResodirec, int NumPoa)
        {
            CEntVM vmRD = new CEntVM();
            List<Ent_RESODIREC> listParcela = new List<Ent_RESODIREC>();
            CLogica exeBus = new CLogica();
            Ent_RESODIREC oCEntidad = new Ent_RESODIREC();
            oCEntidad.BusFormulario = "RESOLUCION_DIRECTORAL";
            oCEntidad.BusCriterio = "PARCELAS";
            oCEntidad.BusValor = CodResodirec;
            oCEntidad.BusValor2 = NumPoa;
            listParcela = exeBus.RegTitularBuscar(oCEntidad);
            vmRD.ListParcela = listParcela;

            // return PartialView("~/Areas/Fiscalizacion/Views/ManResolucion/_Shared/_generic/_renderListPOA.cshtml", vmRD);
            var jsonResult = Json(new
            {
                data = vmRD.ListParcela,
                draw = "",
                error = "",
                success = true
            }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        /*public PartialViewResult getListPOA(int id)
        {
            CEntVM vmRD = new CEntVM();
            return PartialView("~/Areas/Fiscalizacion/Views/ManResolucion/_Shared/_generic/_renderListPOA.cshtml", vmRD);
        }*/

        /// <summary>
        /// metodo para agregar las infracciones
        /// </summary>
        /// <param name="infracciones"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult agregarInfracciones(string idEnciso, string descEnciso, string idPoa, string desPoa, string area, string descripcion, string volumen, string tipo, string idEspecie, string desEspecie, string numInd, string idEspecieFauna, string desEspecieFauna)
        {
            CEntVM vmRD = new CEntVM();

            try
            {
                Ent_RESODIREC ocampoEnt = new Ent_RESODIREC();
                //ocampoEnt.COD_ILEGAL_ARTICULOS = vmRD.txtIdArticulo;
                ocampoEnt.COD_ILEGAL_ENCISOS = idEnciso;
                //ocampoEnt.DESCRIPCION_ARTICULOS = vmRD.txtDescripcionArticulo;
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
                ocampoEnt.VOLUMEN = volumen == "" ? 0 : Decimal.Parse(volumen);
                ocampoEnt.AREA = area == "" ? 0 : Decimal.Parse(area);
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
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            return PartialView("~/Areas/Fiscalizacion/Views/ManResolucion/_Shared/_generic/_renderListaEncisos.cshtml", vmRD);
        }

        [HttpPost]
        public JsonResult AddEditRD(CEntVM dto)
        {
            string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            CLogica exeBus = new CLogica();
            //dto.ListPOA = vmRD.ListPOA;
            ListResult result = exeBus.GuardarDatosRD(dto, codCuenta);
            return Json(result);
        }

        public FileResult simularObservatorio_old(String[] listPoa, string codigo, string tipo)
        {
            ListResult result = new ListResult();
            CLogica exeBus = new CLogica();
            Int32 idRegistro = 0;
            string fileName = "";
            string ruta = "";
            string num_poa;
            try
            {

                num_poa = listPoa[0].ToString();
                string[] array = num_poa.Split(',');
                num_poa = array[0];
                Ent_RESODIREC oCEntObservatorio = new Ent_RESODIREC();
                oCEntObservatorio.COD_DOCUMENTO_REPORT = codigo;
                oCEntObservatorio.TIPO_DOCUMENTO_REPORT = tipo;
                oCEntObservatorio.NUM_POA_REPORT = Int32.Parse(num_poa);
                idRegistro = exeBus.RegPreProcesarObservatorio(oCEntObservatorio); // 3608

                if (idRegistro > 0)
                {
                    sigoWSObservatorio.WSObservatorioSoapClient ws = new sigoWSObservatorio.WSObservatorioSoapClient();
                    fileName = ws.escribirDetallePDFIndex(idRegistro, "~/PlantillaPDF/", "1");
                }
                else
                {
                    throw new Exception("Este Plan no esta contemplado para el procesamiento del Observatorio OSINFOR");
                }
                result.AddResultado(fileName, true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            if (result.success)
            {
                ruta = Server.MapPath("~/PlantillaPDF/Descargas/" + result.msj + ".pdf");
            }
            byte[] oBytes = System.IO.File.ReadAllBytes(ruta);

            return File(oBytes, "application/pdf");
        }

        public JsonResult generarNumeracion(List<Ent_RESODIREC> listInforme)
        {
            ListResult result = new ListResult();
            CLogica exeBus = new CLogica();

            string fileName = "";
            //string ruta = "";
           // string informe;
            string mensaje_err = "";
            bool success;
            try
            {
                Ent_RESODIREC ent = new Ent_RESODIREC();
                ent.CODIGO = listInforme[0].COD_INFORME;
                ent = exeBus.RegNumExpediente(ent); // 3608
                fileName = ent.NUMERO_EXPEDIENTE;
                success = true;
                result.AddResultado(fileName, true);
            }
            catch (Exception)
            {
                mensaje_err = "Error al generar la numeracion";
                success = false;
            }

            return Json(new { fileName = fileName, errorMessage = "error", success = success });
        }
        public JsonResult simularObservatorio(String[] listPoa, string codigo, string tipo)
        {
            ListResult result = new ListResult();
            CLogica exeBus = new CLogica();
            Int32 idRegistro = 0;
            string fileName = "";
            //string ruta = "";
            string num_poa;
            string mensaje_err = "";
            try
            {

                num_poa = listPoa[0].ToString();
                string[] array = num_poa.Split(',');
                num_poa = array[0];
                Ent_RESODIREC oCEntObservatorio = new Ent_RESODIREC();
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

        [HttpGet]
        //[DeleteFileAttribute] //Action Filter, it will auto delete the file after download, 
        //I will explain it later
        public ActionResult Download(string file)
        {
            string fullPath = Path.Combine(Server.MapPath("~/PlantillaPDF/Descargas/"), file);
            return File(fullPath, "application/pdf", file);
        }

        public ActionResult agregarEspeciesMC(string codEspecie, string especie, string volumen, string arboles, string observaciones)
        {
            CEntVM vmRD = new CEntVM();
            vmRD.ListEspecieMedCorrectiva = new List<Ent_RESODIREC_MEDIDA_ESPECIE>();

            try
            {
                if (codEspecie != "0002226" || especie != "|" || volumen != "" || arboles != "")
                {
                    Ent_RESODIREC_MEDIDA_ESPECIE oCentidad = new Ent_RESODIREC_MEDIDA_ESPECIE();
                    oCentidad.COD_ESPECIES = codEspecie;
                    oCentidad.ESPECIES = especie;
                    oCentidad.VOLUMEN_MOVILIZADO = Convert.ToDecimal(volumen == "" ? "0" : volumen);
                    oCentidad.NUMERO_INDIVIDUOS = Convert.ToInt32(arboles == "" ? "0" : arboles);
                    oCentidad.OBSERVACION = observaciones.Replace("\n", " ").Replace("\t", " ").Replace("\"", " ");
                    oCentidad.RegEstado = 1;
                    vmRD.ListEspecieMedCorrectiva.Add(oCentidad);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            return PartialView("~/Areas/Fiscalizacion/Views/ManResolucion/_Shared/_generic/_renderEspecieMC.cshtml", vmRD);
        }

        public JsonResult ImportarEspecieMC()
        {
            CEntVM vmRD = new CEntVM();
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
                            var obj = new Ent_RESODIREC_MEDIDA_ESPECIE();
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                if (workSheet.Cells[rowIterator, 1].Value.ToString() != "" && workSheet.Cells[rowIterator, 2].Value.ToString() != "")
                                {
                                    obj = new Ent_RESODIREC_MEDIDA_ESPECIE();
                                    obj.RegEstado = 1;
                                    obj.COD_ESPECIES = " ";
                                    obj.COD_SECUENCIAL = 0;
                                    obj.ESPECIES = (workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString()) + " | " + (workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString());
                                    obj.VOLUMEN_MOVILIZADO = workSheet.Cells[rowIterator, 3].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 3].Value.ToString());
                                    obj.NUMERO_INDIVIDUOS = workSheet.Cells[rowIterator, 4].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 4].Value.ToString());
                                    obj.OBSERVACION = workSheet.Cells[rowIterator, 5].Value == null ? "" : workSheet.Cells[rowIterator, 5].Value.ToString();
                                    vmRD.ListEspecieMedCorrectiva.Add(obj);

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
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            if (band == 1)
            {
                err = mensaje;
            }
            var jsonResult = Json(new
            {
                data = vmRD.ListEspecieMedCorrectiva,
                error = err
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
            //return PartialView("~/Areas/Fiscalizacion/Views/InformeLegal/Shared/_renderListaEspecies.cshtml", vmInfLegal);

        }

        #endregion
    }
}