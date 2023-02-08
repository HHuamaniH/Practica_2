using CapaEntidad.ViewModel;
using Newtonsoft.Json;
using SIGOFCv3.Models;
using System.Web.Mvc;
using CLogica = CapaLogica.DOC.Log_PREVIOS_ALERTA;
using VModel = CapaEntidad.ViewModel.VM_PreviosAlerta;
using CEntidad = CapaEntidad.DOC.Ent_PREVIOS_ALERTA;
using System.Web;
using System;
using System.IO;
using System.Web.Script.Serialization;
using CapaEntidad.ViewModel.General;
using SIGOFCv3.Helper;
//using VModelDestinatario = CapaEntidad.ViewModel.VM_Destinatario;

namespace SIGOFCv3.Areas.THabilitante.Controllers
{
    public class ManPreviosAlertaController : Controller
    {
        // GET: THabilitante/ManPreviosAlerta
        public ActionResult AddEdit()
        {
            CLogica objLog = new CLogica();
            VModel objVM = new VModel();
            string codUCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;            
            objVM = objLog.IniDatos(codUCuenta);
            objVM.TipoFormulario = "PREVIOS_ALERTA";
            ViewBag.Perfil = objVM.ListPERFILCOADMINISTRADOR[0].COADMIN;
            //obtenemos el rol sobre el formulario
            VM_Menu_Rol mr = HelperSigo.GetRol("MODULO SUPERVISION", "Mantenimiento Previos Alertas OSINFOR");
            ViewBag.CodRol = mr.NCODROL;
            ViewBag.VAliasRol = mr.VALIAS;
            return View(objVM);
        }
        #region Destinatario
        [HttpGet]
        public ActionResult _ItemDestinatario()
        {
            CLogica objLog = new CLogica();
            VModel objVM = new VModel();            
            string codUCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            objVM = objLog.IniDatos(codUCuenta);
            ViewBag.ListSUPUESTO = objVM.ListSUPUESTO;       
            ViewBag.ListEntidad = objVM.ListENTIDAD;
            ViewBag.Perfil = objVM.ListPERFILCOADMINISTRADOR[0].COADMIN;
            return PartialView();
        }
        [HttpPost]
        public JsonResult saveDestinatario(VModel dto)
        {
            ListResult resultado = new ListResult();
            CLogica objLog = new CLogica();
            string codUCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            resultado = objLog.GuardarDatosDestinatario(dto, codUCuenta);
            return Json(resultado);
        }
        [HttpGet]
        public JsonResult GetAllDestinatario()
        {
            CLogica objLog = new CLogica();
            VModel objVM = new VModel();
            string codUCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            objVM = objLog.IniDatos(codUCuenta);


            var jsonResult = Json(new { data = objVM.ListDESTINATARIO }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        #endregion
        #region Ruta
        [HttpGet]
        public ActionResult _ItemRuta()
        {
            VModel objVM;
            CLogica objLog = new CLogica();
            objVM = objLog.IniDatosRuta();
            return PartialView(objVM);
        }
        [HttpPost]
        public JsonResult saveRuta(VModel dto)
        {
            ListResult resultado = new ListResult();
            CLogica objLog = new CLogica();
            string codUCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            resultado = objLog.GuardarDatosRuta(dto, codUCuenta);
            return Json(resultado);
        }
        [HttpGet]
        public JsonResult GetAllRuta()
        {
            CLogica objLog = new CLogica();
            VModel objVM = new VModel();
            string codUCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            objVM = objLog.IniDatos(codUCuenta);

            var jsonResult = Json(new { data = objVM.ListRUTA }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        #endregion
        #region DestinatarioRuta
        [HttpGet]
        public ActionResult _ItemDestinatarioRuta(string RegEstado, string CodRuta)
        {
            VModel objVM;
            CLogica objLog = new CLogica();
            objVM = objLog.IniDatosDestinatarioRuta(RegEstado, CodRuta);
            return PartialView(objVM);

        }
        [HttpPost]
        public JsonResult saveDestinatarioRuta(VModel dto)
        {
            ListResult resultado = new ListResult();
            CLogica objLog = new CLogica();
            string codUCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            resultado = objLog.GuardarDatosDestinatarioRuta(dto, codUCuenta);
            return Json(resultado);
        }
        [HttpGet]
        public JsonResult GetAllDestinatarioRuta()
        {
            CLogica objLog = new CLogica();
            VModel objVM = new VModel();
            string codUCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            objVM = objLog.IniDatos(codUCuenta);

            var jsonResult = Json(new { data = objVM.ListDESTINATARIO_RUTA }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        #endregion
        #region Supuesto
        [HttpGet]
        public ActionResult _ItemSupuesto()
        {

            return PartialView();
        }
        [HttpPost]
        public JsonResult GrabarDocumentoAdjunto()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    CEntidad oCampos = JsonConvert.DeserializeObject<CEntidad>(Request.Form["data"]);
                    HttpPostedFileBase file = Request.Files[0];//  Get all files from Request object 
                    CLogica objLog = new CLogica();
                    string nomArch = "", extArch = "";
                    string nameArch = file.FileName;
                    nomArch = nameArch.Substring(0, nameArch.LastIndexOf("."));
                    nomArch = (nomArch.Length >= 200 ? nomArch.Substring(0, 200) : nomArch);
                    extArch = nameArch.Substring(nameArch.LastIndexOf(".") + 1).ToLower();
                    string fname = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "." + extArch;

                    file.SaveAs(Path.Combine(Server.MapPath("~/Archivos/Temporales/"), fname));

                    oCampos.NOMBRE_ARCHIVO = nomArch + "." + extArch;
                    oCampos.NOMBRE_TEMPORAL_ARCHIVO = fname;
                    oCampos.EXTENSION_ARCHIVO = extArch;
                    oCampos.ESTADO_ARCHIVO = "1";

                    return Json(new { success = true, msj = "Se subio correctamente el archivo", data = oCampos });
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
        public void DescargarDocumentoAdjunto(string nombreArchivo, string nombreOriginal)
        {
            string FilePath = "";

            FilePath = Path.Combine(HttpContext.Server.MapPath("~/Archivos/Temporales/"), nombreArchivo);

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
        [HttpPost]
        public JsonResult saveSupuesto(VModel dto)
        {   
            ListResult resultado = new ListResult();
            try
            {
                string filePath = "";
                string datos = Request.Form["data"];
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();             
                VModel data = datos != null ? jsonSerializer.Deserialize<VModel>(datos): dto;

                HttpPostedFileBase file;

                string[] extension = (data.ListSUPUESTO[0].NOMBRE_ARCHIVO ?? "").Split('.');
                string nombreFile = DateTime.Now.Year.ToString() +
                DateTime.Now.Month.ToString() +
                DateTime.Now.Day.ToString() +
                DateTime.Now.Hour.ToString() +
                DateTime.Now.Minute.ToString() +
                DateTime.Now.Second.ToString() +
                DateTime.Now.Millisecond.ToString();                
                switch (data.RegEstado)
                {
                    case "1":
                        nombreFile += "." + extension[1];
                         file = Request.Files[0];
                        file.SaveAs(Path.Combine(Server.MapPath("~/Archivos/Plantilla/"), nombreFile));
                        data.ListSUPUESTO[0].NOMBRE_ARCHIVO_REAL = nombreFile;
                        break;
                    case "2":
                        if (Request.Files.Count > 0)
                        {
                            nombreFile += "." + extension[1];
                            file = Request.Files[0];
                            filePath = Server.MapPath("~/Archivos/Plantilla/" + data.ListSUPUESTO[0].NOMBRE_ARCHIVO_REAL);
                            if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
                            file.SaveAs(Path.Combine(Server.MapPath("~/Archivos/Plantilla/"), nombreFile));
                            data.ListSUPUESTO[0].NOMBRE_ARCHIVO_REAL = nombreFile;
                        }
                        break;
                    case "3":
                        filePath = Server.MapPath("~/Archivos/Plantilla/" + data.ListSUPUESTO[0].NOMBRE_ARCHIVO_REAL);
                        if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
                        break;
                }
                
                                               
                CLogica objLog = new CLogica();
                string codUCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
                resultado = objLog.GuardarDatosSupuesto(data, codUCuenta);
               
            }
            catch (Exception)
            {
                resultado.AddResultado("Ocurrio un problema al subir el archivo", false);
                throw;
            }           
            return Json(resultado);
        }
        [HttpGet]
        public JsonResult GetAllSupuesto()
        {
            CLogica objLog = new CLogica();
            VModel objVM = new VModel();
            string codUCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            objVM = objLog.IniDatos(codUCuenta);


            var jsonResult = Json(new { data = objVM.ListSUPUESTO }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public JsonResult deleteSupuesto(VModel dto)
        {
            ListResult resultado = new ListResult();
            CLogica objLog = new CLogica();
            string codUCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            resultado = objLog.GuardarDatosSupuesto(dto, codUCuenta);
            return Json(resultado);
        }

        #endregion
        #region DestinatarioCC
        [HttpGet]
        public ActionResult _ItemDestinatarioCC()
        {
            VModel objVM;
            CLogica objLog = new CLogica();
            objVM = objLog.IniDatosDestinatarioCC();
            return PartialView(objVM);
        }
        [HttpPost]
        public JsonResult saveDestinatarioCC(VModel dto)
        {
            ListResult resultado = new ListResult();
            CLogica objLog = new CLogica();
            string codUCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            resultado = objLog.GuardarDatosDestinatarioCC(dto, codUCuenta);
            return Json(resultado);
        }
        [HttpGet]
        public JsonResult GetAllDestinatarioCC()
        {
            CLogica objLog = new CLogica();
            VModel objVM = new VModel();
            string codUCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            objVM = objLog.IniDatos(codUCuenta);

            var jsonResult = Json(new { data = objVM.ListDESTINATARIOCC }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        #endregion

        #region COAdministrador
        
        public ActionResult _ItemCOAdministrador()
        {

            return PartialView();
        }

        [HttpPost]    

        public JsonResult SaveCOAdministrador(VModel dto)
        {
            ListResult resultado = new ListResult();
            CLogica objLog = new CLogica();
            string codUCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            
            resultado = objLog.GuardarCOAdministrador(dto, codUCuenta);

            return Json(resultado);
            
        }

        [HttpGet]
        public JsonResult GetAllCOAdministrador()
        {
            CLogica objLog = new CLogica();
            VModel objVM = new VModel();
            string codUCuenta = (ModelSession.GetSession())[0].COD_UCUENTA;
            objVM = objLog.IniDatos(codUCuenta);

            var jsonResult = Json(new { data = objVM.ListCOADMINISTRADOR }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        #endregion
    }
}