using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.General;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using CLogica = CapaLogica.DOC.Log_GuiaTransporte;
using VModel = CapaEntidad.ViewModel.VM_GuiaTransporte;
using VModelProducto = CapaEntidad.ViewModel.VM_GuiaTransporte_Producto;


namespace SIGOFCv3.Areas.THabilitante.Controllers
{
    public class ManGuiaTransporteForestalController : Controller
    {
        //String RutaGTFs = "~/Archivos/Archivo_GTF/";
        String RutaGTFsTemp = "~/Archivos/Archivo_GTF/Temp/";
        public ActionResult Index()
        {

            ViewBag.Formulario = "GUIA_TRANSPORTE";
            ViewBag.TituloFormulario = "Guia de Transporte Forestal";

            //invocamos el rol del usuario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "Guía de Transporte Forestal");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;

            return View();

        }
        [HttpGet]
        public ActionResult AddEdit(string codigoDato, string codigoComplementario, int nuevo, string tipoFrmulario)
        {
            try
            {
                VModel objVM;
                CLogica objLog = new CLogica();
                string codUGrupo = (ModelSession.GetSession())[0].COD_UGRUPO;
                String COD_SPERFILS = (ModelSession.GetSession())[0].COD_SPERFILS;

                objVM = objLog.IniDatos(
                    codigoDato,
                    codigoComplementario,
                    (ModelSession.GetSession())[0].COD_UCUENTA,
                    codUGrupo,
                    nuevo,
                    tipoFrmulario
                 );
                objVM.codSPerfils = COD_SPERFILS;

                //invocamos el rol del usuario
                VM_Menu_Rol mr = HelperSigo.GetRol("MODULO TITULO HABILITANTE", "Guía de Transporte Forestal");
                ViewBag.CodRol = mr.NCODROL;
                ViewBag.VAliasRol = mr.VALIAS;

                return View(objVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorC", "Login", new { Area = ex.Message });
            }
        }
        [HttpGet]
        public ActionResult _ItemProducto()
        {
            VModelProducto objV;
            CLogica objLog = new CLogica();
            string codUGrupo = (ModelSession.GetSession())[0].COD_UGRUPO;
            objV = objLog.IniDatosProducto(codUGrupo);
            return PartialView(objV);
        }
        [HttpPost]
        public JsonResult UploadFiles()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    string fname = "";

                    HttpPostedFileBase file = Request.Files[0];
                    string fileName = file.FileName;
                    int indexPunto = fileName.LastIndexOf('.');
                    string name = fileName.Substring(0, indexPunto);
                    string extension = fileName.Substring(indexPunto, fileName.Length - indexPunto);
                    fname = name + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString("00") + DateTime.Now.Millisecond + extension;
                    file.SaveAs(Path.Combine(Server.MapPath(RutaGTFsTemp), "GTF" + fname));


                    return Json(new { success = true, msj = "Archivo subido correctamente", data = new[] { new { GTF_ARCHIVO = "GTF" + fname, GTF_ARCHIVO_TEXT = fileName } } });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, msj = ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, msj = "No se encontraron archivos" });
            }
        }

        [HttpPost]
        public JsonResult Registrar(VModel dto)
        {

            CLogica objLog = new CLogica();
            ListResult resultado;
            resultado = objLog.GuardarDatos(dto, (ModelSession.GetSession())[0].COD_UCUENTA);
            return Json(resultado);
        }
    }
}