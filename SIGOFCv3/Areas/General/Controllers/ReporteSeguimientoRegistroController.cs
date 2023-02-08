using CapaEntidad.ViewModel;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_REPORTE_FISCALIZACION;
using CLogica = CapaLogica.DOC.Log_REPORTE_FISCALIZACION;

namespace SIGOFCv3.Areas.General.Controllers
{
    public class ReporteSeguimientoRegistroController : Controller
    {
        public ActionResult Index(string lstManMenu)
        {
            string tipoReporte = "";
            CLogica exeCap = new CLogica();

            switch (lstManMenu)
            {
                case "1": tipoReporte = "INFSUPERVISION"; break;
                case "2": tipoReporte = "INFSUSPENSION"; break;
                case "3": tipoReporte = "INFQUINQUENAL"; break;
                case "4": tipoReporte = "VMC"; break;
                case "5": tipoReporte = "TH"; break;
                case "6": tipoReporte = "POA"; break;
                case "7": tipoReporte = "RD"; break;
                case "8": tipoReporte = "ILEGAL"; break;
                case "9": tipoReporte = "INSTRUCCION_FINAL"; break;
                case "10": tipoReporte = "INF_TECNICO"; break;
                case "11": tipoReporte = "NOTIFICACIONES"; break;
                case "12": tipoReporte = "INFTIT"; break;
                case "13": tipoReporte = "CAPACITACION"; break;
            }

            VM_ReporteSeguimientoRegistro _dto = exeCap.IniDatosReporte(tipoReporte, (ModelSession.GetSession())[0].COD_UCUENTA);

            return View(_dto);
        }

        [HttpPost]
        public JsonResult Reporte(VM_ReporteSeguimientoRegistro dto)
        {
            List<CEntidad> olResult = new List<CEntidad>();
            CEntidad paramCap = new CEntidad();
            CLogica exeCap = new CLogica();

            try
            {
                paramCap.BusCriterio = dto.hdfTipoReporte;
                //paramCap.BusAnio = (dto.lstChkAnioId ?? "").Replace("'", "");
                paramCap.BusAnio = (dto.lstChkAnioId ?? "").Replace(',', '|');

                olResult = exeCap.log_ReporteSeguimiento(paramCap);

                var jsonResult = Json(new { success = true, msj = "", data = olResult.ToArray() }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DetalleReporte(VM_ReporteSeguimientoRegistro dto)
        {
            List<CEntidad> olResult = new List<CEntidad>();
            CEntidad paramCap = new CEntidad();
            CLogica exeCap = new CLogica();

            try
            {
                paramCap.BusValor = dto.lstChkMesId;
                //paramCap.BusAnio = (dto.lstChkAnioId ?? "").Replace("'", "");
                paramCap.BusAnio = (dto.lstChkAnioId ?? "").Replace(',', '|');
                paramCap.BusCriterio = dto.hdfTipoReporte;

                switch (dto.hdfTipoReporte)
                {
                    case "INFSUPERVISION_DETALLE":
                        olResult = exeCap.log_ReporteSeguimientoSupervisionDetalle(paramCap);
                        break;
                    case "INFSUSPENSION_DETALLE":
                        olResult = exeCap.log_ReporteSeguimientoSuspencionDetalle(paramCap);
                        break;
                    case "INFQUINQUENAL_DETALLE":
                        olResult = exeCap.log_ReporteSeguimientoQuinquenalDetalle(paramCap);
                        break;
                    case "VMC_DETALLE":
                    case "TH_DETALLE":
                    case "POA_DETALLE":
                    case "RD_DETALLE":
                    case "ILEGAL_DETALLE":
                    case "INSTRUCCION_FINAL_DETALLE":
                    case "INF_TECNICO_DETALLE":
                    case "NOTIFICACIONES_DETALLE":
                    case "INFTIT_DETALLE":
                    case "CAPACITACION_DETALLE":
                        olResult = exeCap.log_ReporteSeguimientoDetalle(paramCap);
                        break;
                }

                var jsonResult = Json(new { success = true, msj = "", data = olResult.ToArray() }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult ValidaDocSIADO(string codigo)
        {
            ListResult result = new ListResult();
            string RutaSIADO = Server.MapPath("~/Ruta_SIADO/");

            try
            {
                string nomarchivo = "";

                if (Directory.Exists(RutaSIADO))
                {
                    string[] archivos = Directory.GetFiles(RutaSIADO, codigo + ".*");
                    if (archivos.Length == 1)
                    {
                        FileInfo fi = new FileInfo(archivos[0]);
                        nomarchivo = fi.Name;
                    }
                    else if (archivos.Length > 1)
                    {
                        result.AddResultado("Existe más de un archivo con el mismo nombre", false);
                    }
                    else if (archivos.Length == 0)
                    {
                        result.AddResultado("No existe el archivo seleccionado", false);
                    }
                }

                if (nomarchivo != "")
                {
                    result.AddResultado(nomarchivo, true);
                }
                else
                {
                    result.AddResultado("No existe la ruta de descarga", false);
                }

                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public void DescargarDocSIADO(string nomarchivo)
        {
            string RutaSIADO = Server.MapPath("~/Ruta_SIADO/");

            HttpContext.Response.ClearContent();
            HttpContext.Response.Clear();
            HttpContext.Response.ContentType = "application/octet-stream";
            HttpContext.Response.ContentEncoding = System.Text.Encoding.Default;
            HttpContext.Response.Charset = "";
            string FilePath = RutaSIADO + nomarchivo;
            HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=" + nomarchivo);
            HttpContext.Response.TransmitFile(FilePath);
            HttpContext.Response.Flush();
            HttpContext.Response.Close();
            HttpContext.Response.End();
        }
    }
}