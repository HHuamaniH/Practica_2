using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_REPORTE_FISCALIZACION;
using CLogica = CapaLogica.DOC.Log_REPORTE_FISCALIZACION;

namespace Medidas.Controllers
{
    public class HomeController : Controller
    {
        CLogica oCLogica = new CLogica();
        // GET: Home 
        public ActionResult Index()
        {
            try
            {

                CEntidad oCampos = new CEntidad();
                oCampos = oCLogica.LogMedidasCautelares(oCampos);
                Session["ListMedidaCautelar_Avance"] = oCampos.ListGeneral;
                ViewBag.fechaProcess = (oCLogica.RegMostrarFechaObserv(new CEntidad())).FECHA;
                return View(oCampos.ListGeneral);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public JsonResult listaMedidas(String depart, String tipoMedida)
        {
            try
            {
                CEntidad oCampos = new CEntidad();
                List<String[]> retorno = new List<String[]>();
                oCampos.BusRegion = depart;
                oCampos.BusCriterio = tipoMedida;
                oCampos.ListDetalle = oCLogica.LogDetMedidasCautelares(oCampos);
                Session["ListMedidaCautelar_Detalle"] = oCampos.ListDetalle;

                foreach (var item in oCampos.ListDetalle)
                {
                    retorno.Add(new String[] {
                    item.TITULAR
                    ,item.THABILITANTE
                    ,item.MODALIDAD
                    ,item.RDMEDIDAS
                    ,item.FECHA_EMISION
                    ,""
                    ,item.COD_DOC_SIADO
                   });
                }

                return Json(retorno);
            }
            catch (Exception ex)
            {
                return Json("");
            }
        }
        public ActionResult DescargarIntegracionSIADO(string fileName)
        {
            string pathRepo = "";
            pathRepo = Server.MapPath("~/Ruta_SIADO/");
            string FilePath = pathRepo + fileName + ".pdf";
            if (System.IO.File.Exists(FilePath))
            {
                return new BinaryContentResult
                {
                    FileName = fileName + ".pdf",
                    ContentType = "application/octet-stream",
                    Content = System.IO.File.ReadAllBytes(FilePath)
                };
            }
            else
            {
                return new HttpStatusCodeResult(0);
            }

        }

    }
    public class BinaryContentResult : ActionResult
    {
        public BinaryContentResult()
        { }

        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public byte[] Content { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (System.IO.File.Exists(FilePath)) System.IO.File.Delete(FilePath);
            context.HttpContext.Response.ClearContent();
            context.HttpContext.Response.ContentType = ContentType;

            context.HttpContext.Response.AddHeader("content-disposition",

                                                   "attachment; filename=" + FileName);

            context.HttpContext.Response.BinaryWrite(Content);
            context.HttpContext.Response.End();
        }
    }
}