using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using OfficeOpenXml;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using SIGOFCv3.Models.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntVM = CapaEntidad.ViewModel.VM_InformeLegal;
using CLogica = CapaLogica.DOC.Log_ILEGAL;

namespace SIGOFCv3.Areas.Fiscalizacion.Controllers
{
    public class InformeLegalController : Controller
    {
        public static CEntVM vmInfLegal = new CEntVM();
        private CLogica logILegal = new CLogica();

        // GET: Fiscalizacion/InformeLegal
        public ActionResult Index()
        {
            CapaLogica.DOC.Log_BUSQUEDA exeBus = new CapaLogica.DOC.Log_BUSQUEDA();

            ViewBag.Formulario = "INFORME_LEGAL";
            ViewBag.TituloFormulario = "Informe Legal";
            ViewBag.Criterio = "TODOS";
            ViewBag.AlertaInicial = "";
            ViewBag.ddlListOpciones = exeBus.RegMostComboIndividual_v3("INFORME_LEGAL", "");
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO FISCALIZACION", "Informe Final de Instrucción");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View();
        }

        [HttpPost]
        public JsonResult ExportarRegistroUsuario()
        {
            ListResult result = new ListResult();
            result = logILegal.RegistroUsuario((ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(result);
        }

        public ActionResult CreateOrEdit(string asCodInfLegal = "", string asCodTipoIL = "")
        {
            try
            {
                vmInfLegal = logILegal.initIlegal(asCodInfLegal, asCodTipoIL);

                //obtenemos el rol sobre el formulario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO FISCALIZACION", "Informe Final de Instrucción");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;
                //Pasamos el Rol del usuario
                vmInfLegal.vmControlCalidad.VALIAS_ROL = mr.VALIAS;
                ViewBag.Usuario = ModelSession.GetSession()?.FirstOrDefault();

                return View(vmInfLegal);
               
            }
            catch (Exception)
            {
                return View("Index");
            }

        }
        [HttpPost]
        public JsonResult AddEdit(CEntVM dto)
        {
            string codCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            CLogica exeBus = new CLogica();
            ListResult result = exeBus.GuardarDatosInfLegal(dto, codCuenta);
            return Json(result);
        }


        #region "SHARED"
        [HttpGet]
        public JsonResult ConsultaModal(DataTableRequest request = null)
        {

            CLogica exeBus = new CLogica();
            Ent_ILEGAL paramsBus = new Ent_ILEGAL();
            Ent_INFORME_CONSULTA_LEGAL lstResult;
            //int rowcount = 0;
            int page = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;

            paramsBus.BusFormulario = request.CustomSearchForm;
            paramsBus.BusCriterio = request.CustomSearchType;//NUM_EXPEDIENTE||NUM_RESOLUCION
            paramsBus.BusValor = request.CustomSearchValue;
            paramsBus.v_pagesize = request.Length;
            paramsBus.v_currentpage = page;

            lstResult = exeBus.RegMostrar_BucarModal(paramsBus);

            var jsonResult = Json(new
            {
                data = lstResult.listBusqueda.ToArray(),
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
            CLogica exeBus = new CLogica();
            vmInfLegal.txtIdArticulo = idArticulo;
            vmInfLegal.txtDescripcionArticulo = descArticulo;
            vmInfLegal.listaIncisos = exeBus.initArticulos("ENCISOS", idArticulo);
            return PartialView("~/Areas/Fiscalizacion/Views/InformeLegal/Shared/_incisos.cshtml", vmInfLegal);
        }

        public ActionResult _inicisosSubsanables(string idArticulo, string descArticulo)
        {
            CLogica exeBus = new CLogica();
            vmInfLegal.ddlArticuloSubsanableId = idArticulo;
            vmInfLegal.txtArticuloSubsanable = descArticulo;
            vmInfLegal.listaIncisosSubsanados = exeBus.initArticulos("ENCISOS", idArticulo);
            return PartialView("~/Areas/Fiscalizacion/Views/InformeLegal/Shared/_incisosSubsanables.cshtml", vmInfLegal);
        }

        /// <summary>
        /// metodo para agregar las infracciones
        /// </summary>
        /// <param name="infracciones"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult agregarInfracciones(String[] infracciones, String[] texto)
        {
            try
            {
                Ent_ILEGAL oCentidad = new Ent_ILEGAL();

                for (int i = 0; i < infracciones.Length; i++)
                {
                    int band = 0;
                    oCentidad = new Ent_ILEGAL();
                    oCentidad.COD_ILEGAL_ENCISOS = infracciones[i].ToString();
                    oCentidad.COD_ILEGAL_ARTICULOS = vmInfLegal.txtIdArticulo;
                    oCentidad.DESCRIPCION_ENCISOS = buscaEnciso(infracciones[i].ToString());
                    oCentidad.DESCRIPCION_ARTICULOS = vmInfLegal.txtDescripcionArticulo;
                    oCentidad.RegEstado = 1; //nuevo registro
                    for (int j = 0; j < vmInfLegal.listaInfracciones.Count; j++)
                    {
                        var infraccion = vmInfLegal.listaInfracciones[j];
                        if (infraccion.COD_ILEGAL_ENCISOS == oCentidad.COD_ILEGAL_ENCISOS && infraccion.COD_ILEGAL_ARTICULOS == oCentidad.COD_ILEGAL_ARTICULOS)
                        {
                            //existe
                            band = 1;
                        }
                    }
                    if (band == 0)
                    {
                        vmInfLegal.listaInfracciones.Add(oCentidad);
                    }
                }
            }
            catch (Exception)
            {

            }
            return PartialView("~/Areas/Fiscalizacion/Views/InformeLegal/Shared/_renderListaEncisos.cshtml", vmInfLegal);
        }

        public string buscaEnciso(string codEnciso)
        {
            string descEnciso = "";
            for (int i = 0; i < vmInfLegal.listaIncisos.Count; i++)
            {
                if (vmInfLegal.listaIncisos[i].Value == codEnciso)
                {
                    descEnciso = vmInfLegal.listaIncisos[i].Text;
                }
            }
            return descEnciso;
        }

        public ActionResult agregarEspeciesMC(string codEspecie, string especie, string volumen, string arboles, string observaciones)
        {
            try
            {
                if (codEspecie != "0000000" || especie != "Seleccionar" || volumen != "" || arboles != "")
                {
                    Ent_ILEGAL oCentidad = new Ent_ILEGAL();
                    oCentidad.COD_ESPECIES = codEspecie;
                    oCentidad.DESCRIPCION_ESPECIE = especie;
                    oCentidad.VOLUMEN = Convert.ToDecimal(volumen == "" ? "0" : volumen);
                    oCentidad.NUMERO_INDIVIDUOS = Convert.ToInt32(arboles == "" ? "0" : arboles);
                    oCentidad.OBSERVACION = observaciones;
                    oCentidad.RegEstado = 1;
                    vmInfLegal.listaEspeciesMC.Add(oCentidad);
                }
            }
            catch (Exception)
            {

            }
            return PartialView("~/Areas/Fiscalizacion/Views/InformeLegal/Shared/_renderListaEspecies.cshtml", vmInfLegal);
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
                            var obj = new Ent_ILEGAL();
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                if (workSheet.Cells[rowIterator, 1].Value.ToString() != "" && workSheet.Cells[rowIterator, 2].Value.ToString() != "")
                                {
                                    obj = new Ent_ILEGAL();
                                    obj.RegEstado = 1;
                                    obj.COD_ESPECIES = " ";
                                    obj.COD_SECUENCIAL = 0;
                                    obj.DESCRIPCION_ESPECIE = (workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString()) + " | " + (workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString());
                                    obj.VOLUMEN = workSheet.Cells[rowIterator, 3].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 3].Value.ToString());
                                    obj.NUMERO_INDIVIDUOS = workSheet.Cells[rowIterator, 4].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 4].Value.ToString());
                                    obj.OBSERVACION = workSheet.Cells[rowIterator, 5].Value == null ? "" : workSheet.Cells[rowIterator, 5].Value.ToString();
                                    vmInfLegal.listaEspeciesMC.Add(obj);

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
                data = vmInfLegal.listaEspeciesMC,
                error = err
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
            //return PartialView("~/Areas/Fiscalizacion/Views/InformeLegal/Shared/_renderListaEspecies.cshtml", vmInfLegal);

        }


        /// <summary>
        /// metodo para infracciones Recurso de reconsideracion
        /// </summary>
        /// <param name="codEspecie"></param>
        /// <param name="especie"></param>
        /// <returns></returns>
        public ActionResult infraccionesRR()
        {
            try
            {
                if (vmInfLegal.tbInforme.Count > 0)
                {
                    vmInfLegal.listaInfraccionesRR = logILegal.busInfraccionesRD(vmInfLegal.tbInforme, "0000011");
                }
            }
            catch (Exception)
            {

            }
            return PartialView("~/Areas/Fiscalizacion/Views/InformeLegal/Shared/_renderInfraccionesRR.cshtml", vmInfLegal);
        }

        public ActionResult busInfraccionesRDInicio(DataTableRequest request = null)
        {
            var result = logILegal.busInfraccionesRD(vmInfLegal.tbInforme, "0000009");

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

        public ActionResult agregarInfraccion(string codIlegalInciso, string txtArticulo, string txtInciso, string codIlegalArticulo)
        {
            try
            {
                Ent_ILEGAL oCentidad = new Ent_ILEGAL();
                oCentidad.COD_ILEGAL_ENCISOS = codIlegalInciso;
                oCentidad.COD_ILEGAL_ARTICULOS = codIlegalArticulo;
                oCentidad.DESCRIPCION_ENCISOS = txtInciso;
                oCentidad.DESCRIPCION_ARTICULOS = txtArticulo;
                oCentidad.RegEstado = 1; //nuevo registro
                int band = 0;
                for (int j = 0; j < vmInfLegal.listaInfracciones.Count; j++)
                {
                    var infraccion = vmInfLegal.listaInfracciones[j];
                    if (infraccion.COD_ILEGAL_ENCISOS == oCentidad.COD_ILEGAL_ENCISOS && infraccion.COD_ILEGAL_ARTICULOS == oCentidad.COD_ILEGAL_ARTICULOS)
                    {
                        //existe
                        band = 1;
                    }
                }
                if (band == 0)
                {
                    vmInfLegal.listaInfracciones.Add(oCentidad);
                }

                //vmInfLegal.listaInfracciones.Add(oCentidad);
            }
            catch (Exception)
            {

            }
            return PartialView("~/Areas/Fiscalizacion/Views/InformeLegal/Shared/_renderListaEncisos.cshtml", vmInfLegal);
        }

        #endregion
    }
}
