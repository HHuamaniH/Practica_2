using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_AntecedentesTitular;
using CLogica = CapaLogica.DOC.Log_Reporte_AntecedentesTitular;

namespace SIGOFCv3.Areas.General.Controllers
{
    public class ReporteAntecedentesTitularController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Formulario = "PERSONA";
            ViewBag.TituloFormulario = "Reporte de Antecedentes del Titular";

            ViewBag.ddlTipoBusquedaTitular = new List<SelectListItem>()
            {
                new SelectListItem { Value = "APELLIDOS_NOMBRES", Text = "Titular" },
                new SelectListItem { Value = "N_DOCUMENTO", Text = "Nro. Documento" }
            };

            return View();
        }

        [HttpPost]
        public JsonResult MostrarReporte(string codpersona)
        {
            CLogica exeCap = new CLogica();
            CEntidad paramCap = new CEntidad();
            CEntidad result;
            try
            {
                paramCap.v_COD_PERSONA = codpersona;
                result = exeCap.RegMostrarReporte(paramCap);
                var jsonResult = Json(new
                {
                    success = true,
                    msj = "",
                    data = result.ListAntecedentes.ToArray(),
                    texto = (result.ListAntecedentes.Count > 0)?result.DESCRIPCION: "No se encontraron resultados...",
                    codpersona = paramCap.v_COD_PERSONA
                }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }
        }

        public void GeneraReportePDF(string codpersona)
        {
            CLogica exeCap = new CLogica();
            CEntidad paramCap = new CEntidad();
            paramCap.v_COD_PERSONA = codpersona;

            paramCap = exeCap.RegMostrarReporte(paramCap);

            Document doc = new Document(iTextSharp.text.PageSize.LETTER);
            doc.AddAuthor("OSINFOR");
            doc.AddKeywords("pdf, PdfWriter; Documento; iTextSharp");
            doc.SetMargins(36.0f, 36.0f, 96.0f, 50.0f);
            string rut = Server.MapPath("~/PlantillaPDF/PlantillaOsinfor.pdf");
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(rut, FileMode.Create));
            doc.Open();
            //saltos de linea 
            Rectangle page = doc.PageSize;

            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 80;
            table.TotalWidth = page.Width - 90;
            string altura = table.TotalHeight.ToString();
            table.LockedWidth = true;
            float[] widths = new float[] { .99f };
            table.SetWidths(widths);
            table.AddCell(exeCap.celda("Organismo de Supervisión de los Recursos Forestales y de Fauna Silvestre - OSINFOR", 1, 1, 12, Element.ALIGN_CENTER, 0, BaseColor.BLACK, "transparent", "Negrita"));
            doc.Add(table);
            doc.Add(new Paragraph("\n"));

            table = new PdfPTable(3);
            table.WidthPercentage = 80;
            table.TotalWidth = page.Width - 90;
            table.LockedWidth = true;
            widths = new float[] { .35f, .01f, .64f };
            table.SetWidths(widths);
            doc.Add(table);

            doc.Add(new Paragraph("\n"));
            table = new PdfPTable(1); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
            widths = new float[] { .99f }; table.SetWidths(widths);
            table.AddCell(exeCap.celda("REPORTE DE SANCIÓN Y/O CADUCIDAD", 1, 1, 12, Element.ALIGN_CENTER, 0, BaseColor.BLACK, "transparent", "Negrita"));
            doc.Add(table);

            table = new PdfPTable(1); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
            table.AddCell(exeCap.celda(paramCap.DESCRIPCION, 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
            doc.Add(table);
            doc.Add(new Paragraph("\n"));

            table = new PdfPTable(11); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
            widths = new float[] { .05f, .25f, .15f, .30f, .15f, .10f, .20f, .15f, .10f, .15f, .10f }; table.SetWidths(widths);

            table.AddCell(exeCap.celda("N°", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
            table.AddCell(exeCap.celda("Título Habilitante", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
            table.AddCell(exeCap.celda("Modalidad de Aprovechamiento", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
            table.AddCell(exeCap.celda("Infracciones Cometidas", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
            table.AddCell(exeCap.celda("Sanción Impuesta", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
            table.AddCell(exeCap.celda("Multa en UIT", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
            table.AddCell(exeCap.celda("N° RD Término PAU", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
            table.AddCell(exeCap.celda("Estado del Proceso Administrativo", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
            table.AddCell(exeCap.celda("Fecha Notificación RD Término", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
            table.AddCell(exeCap.celda("N° Resol. Tribunal", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
            table.AddCell(exeCap.celda("Fecha Emisión Resol. Tribunal", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));

            int contador = 1;
            foreach (var fila in paramCap.ListAntecedentes)
            {
                table.AddCell(exeCap.celda((contador++).ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(exeCap.celda(fila.NUM_THABILITANTE, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Cursiva"));
                table.AddCell(exeCap.celda(fila.MODALIDAD, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(exeCap.celda(fila.INFRACCION, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(exeCap.celda(fila.SANCION, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(exeCap.celda(fila.MULTA.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(exeCap.celda(fila.RESOLUCION, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(exeCap.celda(fila.ESTADO_PAU, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(exeCap.celda(fila.FECHA_NOTIFICACION.ToString(), 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(exeCap.celda(fila.NUMRESOLUCIONFORESTAL.ToString(), 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(exeCap.celda(fila.FECRESOLUCIONFORESTAL.ToString(), 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
            }
            doc.Add(table);

            doc.Close();

            HttpContext.Response.Clear();
            HttpContext.Response.ClearContent();
            HttpContext.Response.ClearHeaders();
            string nombrePDF = "_ANTECEDENTES_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00");
            HttpContext.Response.AddHeader("content-disposition", "attachment;filename=ReporteOSINFOR" + nombrePDF + ".pdf");
            HttpContext.Response.ContentType = "application/pdf";
            HttpContext.Response.TransmitFile(rut);
            HttpContext.Response.End();
        }
    }
}