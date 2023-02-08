using CapaEntidad.GENE;
using CapaLogica.GENE;
using DocumentFormat.OpenXml.Drawing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SIGOFCv3.Models;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Paragraph = iTextSharp.text.Paragraph;
using Rectangle = iTextSharp.text.Rectangle;

namespace SIGOFCv3.Areas.General.Controllers
{
    public class ManCalculoMultaController : Controller
    {
        // GET: General/ManCalMulFactAA
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult GuardarFactorAA(CapaEntidad.GENE.Ent_MANCALCULOMULTA factorAA)
        {

            try
            {
                CapaLogica.GENE.Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
                factorAA.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                log_MANCALCULOMULTA.RegGrabarFactorAA(factorAA);
                return Json(new { success = true, msj = "Transacción realizada." });
            }
            catch (Exception)
            {
                string msj = "Sucedió un error en el servidor";
                return Json(new { success = false, msj = msj });
            }
        }


        public ActionResult RegenEsp()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GuardarRegenEsp(CapaEntidad.GENE.Ent_MANCALCULOMULTA regenEsp)
        {

            try
            {
                CapaLogica.GENE.Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
                regenEsp.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                log_MANCALCULOMULTA.RegGrabarRegenEsp(regenEsp);
                return Json(new { success = true, msj = "Transacción realizada." });
            }
            catch (Exception)
            {
                string msj = "Sucedió un error en el servidor";
                return Json(new { success = false, msj = msj });
            }
        }
        public ActionResult CostoAdm()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GuardarCostoAdm(CapaEntidad.GENE.Ent_MANCALCULOMULTA regenEsp)
        {

            try
            {
                CapaLogica.GENE.Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
                regenEsp.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                log_MANCALCULOMULTA.RegGrabarCostoAdm(regenEsp);
                return Json(new { success = true, msj = "Transacción realizada." });
            }
            catch (Exception)
            {
                string msj = "Sucedió un error en el servidor";
                return Json(new { success = false, msj = msj });
            }
        }

        public ActionResult BenEcoInf()
        {
            Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
            ViewBag.ddlLiteral = log_MANCALCULOMULTA.RegMostComboIndividual_v3("LITERAL", "");
            return View();
        }

        [HttpPost]
        public JsonResult GuardarBenEcoInf(CapaEntidad.GENE.Ent_MANCALCULOMULTA regenEsp)
        {

            try
            {
                CapaLogica.GENE.Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
                regenEsp.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                log_MANCALCULOMULTA.RegGrabarBenEcoInf(regenEsp);
                return Json(new { success = true, msj = "Transacción realizada." });
            }
            catch (Exception)
            {
                string msj = "Sucedió un error en el servidor";
                return Json(new { success = false, msj = msj });
            }
        }


        public ActionResult ManIndPreCon()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GuardarIndPreCon(CapaEntidad.GENE.Ent_MANCALCULOMULTA regenEsp)
        {

            try
            {
                CapaLogica.GENE.Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
                regenEsp.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                log_MANCALCULOMULTA.RegGrabarIndPreCon(regenEsp);
                return Json(new { success = true, msj = "Transacción realizada." });
            }
            catch (Exception)
            {
                string msj = "Sucedió un error en el servidor";
                return Json(new { success = false, msj = msj });
            }
        }
        public ActionResult ManInfProDet()
        {
            Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
            ViewBag.ddlLiteral = log_MANCALCULOMULTA.RegMostComboIndividual_v3("LITERAL", "");
            return View();
        }
        [HttpPost]
        public JsonResult GuardarInfProDet(CapaEntidad.GENE.Ent_MANCALCULOMULTA regenEsp)
        {
            try
            {
                CapaLogica.GENE.Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
                regenEsp.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                log_MANCALCULOMULTA.RegGrabarInfProDet(regenEsp);
                return Json(new { success = true, msj = "Transacción realizada." });
            }
            catch (Exception)
            {
                string msj = "Sucedió un error en el servidor";
                return Json(new { success = false, msj = msj });
            }
        }

        public ActionResult ManVENMaderable()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GuardarVENMaderable(CapaEntidad.GENE.Ent_MANCALCULOMULTA regenEsp)
        {

            try
            {
                CapaLogica.GENE.Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
                regenEsp.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                log_MANCALCULOMULTA.RegGrabarVENMaderable(regenEsp);
                return Json(new { success = true, msj = "Transacción realizada." });
            }
            catch (Exception)
            {
                string msj = "Sucedió un error en el servidor";
                return Json(new { success = false, msj = msj });
            }
        }

        public ActionResult ManCatEspMad()
        {
            CapaLogica.GENE.Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
            ViewBag.ddlCategorias = log_MANCALCULOMULTA.RegMostComboIndividual_v3("CATEGORIA", "");

            return View();
        }
        [HttpPost]
        public JsonResult GuardarCatEspMad(CapaEntidad.GENE.Ent_MANCALCULOMULTA regenEsp)
        {

            try
            {
                CapaLogica.GENE.Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
                regenEsp.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                String Result = log_MANCALCULOMULTA.RegGrabarCatEspMad(regenEsp);
                return Json(new { success = true, msj = Result });
            }
            catch (Exception)
            {
                string msj = "Sucedió un error en el servidor";
                return Json(new { success = false, msj = msj });
            }
        }

        public ActionResult ManValComFau()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GuardarValComFau(CapaEntidad.GENE.Ent_MANCALCULOMULTA regenEsp)
        {
            try
            {
                CapaLogica.GENE.Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
                regenEsp.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                String Result = log_MANCALCULOMULTA.RegGrabarValComFau(regenEsp);
                return Json(new { success = true, msj = Result });
            }
            catch (Exception)
            {
                string msj = "Sucedió un error en el servidor";
                return Json(new { success = false, msj = msj });
            }
        }

        public ActionResult ManClaEspAme()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GuardarClaEspAme(CapaEntidad.GENE.Ent_MANCALCULOMULTA regenEsp)
        {
            try
            {
                CapaLogica.GENE.Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
                regenEsp.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                String Result = log_MANCALCULOMULTA.RegGrabarClaEspAme(regenEsp);
                return Json(new { success = true, msj = Result });
            }
            catch (Exception)
            {
                string msj = "Sucedió un error en el servidor";
                return Json(new { success = false, msj = msj });
            }
        }

        [HttpPost]
        public JsonResult GuardarCalculoMulta(CapaEntidad.GENE.Ent_CALCULOMULTA regenEsp)
        {
            try
            {
                CapaLogica.GENE.Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
                regenEsp.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;
                String Result = log_MANCALCULOMULTA.RegGrabarCalculoMulta(regenEsp);
                return Json(new { success = true, msj = Result });
            }
            catch (Exception)
            {
                string msj = "Sucedió un error en el servidor";
                return Json(new { success = false, msj = msj });
            }
        }
        [HttpGet]
        public JsonResult GetCalculoMulta(string codCalculoMulta)
        {
            try
            {
                CapaLogica.GENE.Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
                var Result = log_MANCALCULOMULTA.GetCalculoMulta(codCalculoMulta);
                return Json(new { success = true, result = Result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                string msj = "Sucedió un error en el servidor";
                return Json(new { success = false, msj = msj });
            }
        }        

        public ActionResult ExportPDF(string codCalculoMulta)
        {
            try
            {
                MemoryStream workStream = new MemoryStream();
                Document document = new Document();
                Image imagen;
                float percentage;
                PdfWriter.GetInstance(document, workStream).CloseStream = false;

                document.Open();

                document.AddTitle("CALCULO DE MULTA");
                document.AddCreator("Analista");

                Font fontHeader = new Font(Font.FontFamily.HELVETICA, 14F, Font.BOLD | Font.UNDERLINE);
                Font fontSubTittle = new Font(Font.FontFamily.HELVETICA, 10F, Font.BOLD);
                Font font = new Font(Font.FontFamily.HELVETICA, 8F);
                Font fontBold = new Font(Font.FontFamily.HELVETICA, 8F, Font.BOLD);

                CapaLogica.GENE.Log_MANCALCULOMULTA log_MANCALCULOMULTA = new Log_MANCALCULOMULTA();
                var calculoMulta = log_MANCALCULOMULTA.GetCalculoMulta(codCalculoMulta);

                var fileuploadPathContent = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["PathLogoCM"];
                Paragraph paragraph;

                float[] columnInfoWidths = { 1.5F, 2 };
                PdfPTable tableInfo;
                PdfPCell cellInfo;
                if (!string.IsNullOrEmpty(fileuploadPathContent))
                {
                    var titulo = new Paragraph("CÁLCULO DE MULTA", fontHeader);
                    titulo.SpacingBefore = 200;
                    titulo.SpacingAfter = 0;
                    titulo.Alignment = 1; //0-Left, 1 middle,2 Right                
                    document.Add(titulo);
                    document.Add(Chunk.NEWLINE);

                    paragraph = new Paragraph("DETERMINACIÓN DE MULTA POR INFRACCIÓN PREVISTA EN LA LEGISLACIÓN FORESTAL Y DE FAUNA SILVESTRE", fontSubTittle);
                    paragraph.Alignment = Element.ALIGN_CENTER;
                    paragraph.SpacingAfter = 2;
                    document.Add(paragraph);

                    paragraph = new Paragraph(" METODOLOGÍA N° 001-2018-OSINFOR, APROBADA MEDIANTE RESOLUCIÓN PRESIDENCIAL N° 021-2018-OSINFOR", fontBold);
                    paragraph.Alignment = Element.ALIGN_CENTER;
                    paragraph.SpacingAfter = 2;
                    document.Add(paragraph);

                    string path = fileuploadPathContent;

                    imagen = Image.GetInstance(path);
                    imagen.BorderWidth = 0;
                    percentage = 80F / imagen.Height;
                    imagen.ScalePercent(percentage * 100);
                    imagen.ScaleToFit(125f, 60F);
                    imagen.SetAbsolutePosition(25, 670);
                    document.Add(imagen);

                    tableInfo = new PdfPTable(columnInfoWidths);
                    tableInfo.WidthPercentage = 100F;
                    tableInfo.SpacingAfter = 2;

                    cellInfo = new PdfPCell(new Phrase("EXPEDIENTE N°:", fontBold));
                    cellInfo.Border = Rectangle.NO_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 1;
                    tableInfo.AddCell(cellInfo);
                    cellInfo = new PdfPCell(new Phrase(calculoMulta.Expediente, font));
                    cellInfo.Border = Rectangle.NO_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_LEFT;
                    cellInfo.PaddingBottom = 1;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("ADMINISTRADO:", fontBold));
                    cellInfo.Border = Rectangle.NO_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 1;
                    tableInfo.AddCell(cellInfo);
                    cellInfo = new PdfPCell(new Phrase(calculoMulta.Administrado, font));
                    cellInfo.Border = Rectangle.NO_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_LEFT;
                    cellInfo.PaddingBottom = 1;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("RUC Nº/D.N.I.  Nº:", fontBold));
                    cellInfo.Border = Rectangle.NO_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 1;
                    tableInfo.AddCell(cellInfo);
                    cellInfo = new PdfPCell(new Phrase(calculoMulta.NroDocumento, font));
                    cellInfo.Border = Rectangle.NO_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_LEFT;
                    cellInfo.PaddingBottom = 1;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("TITULO HABILITANTE:", fontBold));
                    cellInfo.Border = Rectangle.NO_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 1;
                    tableInfo.AddCell(cellInfo);
                    cellInfo = new PdfPCell(new Phrase(calculoMulta.TituloHabilitante, font));
                    cellInfo.Border = Rectangle.NO_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_LEFT;
                    cellInfo.PaddingBottom = 1;
                    tableInfo.AddCell(cellInfo);

                    document.Add(tableInfo);
                }
                else
                {
                    paragraph = new Paragraph("Calculo de Multa", new Font(Font.FontFamily.HELVETICA, 12F, Font.BOLD));
                    paragraph.Alignment = Element.ALIGN_CENTER;
                    paragraph.SpacingAfter = 5;
                    document.Add(paragraph);
                }
                string infraccion = string.Empty;
                string literalPrincipal = calculoMulta.DetalleCalculoMulta.Count >= 2 ? "1. Cálculo de la multa por infracciones a los literales " : "1. Cálculo de la multa por infracciones al literal ";
                string literal = string.Empty;
                // bool condicion = calculoMulta.DetalleCalculoMulta.Count >= 2 ? true : false;
                for (int i = 0; i < calculoMulta.DetalleCalculoMulta.Count; i++)
                {
                    var item = calculoMulta.DetalleCalculoMulta[i];
                    int diferencia = calculoMulta.DetalleCalculoMulta.Count - 1 - i;
                    switch (diferencia)
                    {
                        case 0:
                            literalPrincipal = literalPrincipal + item.literal.Substring(1, item.literal.Length-1).ToLower() + ").";
                            literal = literal + item.literal.Substring(1, item.literal.Length - 1).ToLower() + ").";
                            break;
                        case 1:
                            literalPrincipal = literalPrincipal + item.literal.Substring(1, item.literal.Length - 1).ToLower() + ") y ";
                            literal = literal + item.literal.Substring(1, item.literal.Length - 1).ToLower() + ") y ";
                            break;
                        default:
                            literalPrincipal = literalPrincipal + item.literal.Substring(1, item.literal.Length - 1).ToLower() + "), ";
                            literal = literal + item.literal.Substring(1, item.literal.Length - 1).ToLower() + "), ";
                            break;
                    }
                }

                paragraph = new Paragraph(literalPrincipal, font);
                paragraph.Alignment = Element.ALIGN_LEFT;
                document.Add(paragraph);

                fileuploadPathContent = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["PathFormulaCM"];

                imagen = Image.GetInstance(fileuploadPathContent);
                imagen.BorderWidth = 0;
                percentage = 100F / imagen.Height;
                imagen.ScalePercent(percentage * 100);
                imagen.ScaleToFit(240f, 80F);
                imagen.SetAbsolutePosition(30, 610);
                document.Add(imagen);

                document.Add(Chunk.NEWLINE);
                document.Add(Chunk.NEWLINE);
                document.Add(Chunk.NEWLINE);
                document.Add(Chunk.NEWLINE);

                paragraph = new Paragraph("        Donde:", fontBold);
                paragraph.Alignment = Element.ALIGN_LEFT;
                document.Add(paragraph);

                paragraph = new Paragraph("        M:        Multa", font);
                paragraph.Alignment = Element.ALIGN_LEFT;
                document.Add(paragraph);

                paragraph = new Paragraph("        K:        Los costos administrativos para la imposición de la sanción", font);
                paragraph.Alignment = Element.ALIGN_LEFT;
                document.Add(paragraph);

                paragraph = new Paragraph("        B:        Los beneficios económicos obtenidos por el infractor", font);
                paragraph.Alignment = Element.ALIGN_LEFT;
                document.Add(paragraph);

                paragraph = new Paragraph("       CE:       Los costos evitados por el infractor", font);
                paragraph.Alignment = Element.ALIGN_LEFT;
                document.Add(paragraph);

                paragraph = new Paragraph("       Pd:       La probabilidad de detección de la infracción", font);
                paragraph.Alignment = Element.ALIGN_LEFT;
                document.Add(paragraph);

                paragraph = new Paragraph("       VEN:     Valor al estado natural", font);
                paragraph.Alignment = Element.ALIGN_LEFT;
                document.Add(paragraph);

                paragraph = new Paragraph("        G:        Gravedad de los daños generados", font);
                paragraph.Alignment = Element.ALIGN_LEFT;
                document.Add(paragraph);

                paragraph = new Paragraph("        A:        La afectación y categoría de amenaza de la especie", font);
                paragraph.Alignment = Element.ALIGN_LEFT;
                document.Add(paragraph);

                paragraph = new Paragraph("        R:        La función que cumple en la regeneración de la especie", font);
                paragraph.Alignment = Element.ALIGN_LEFT;
                document.Add(paragraph);

                paragraph = new Paragraph("        F:        Factores atenuantes y agravantes", font);
                paragraph.Alignment = Element.ALIGN_LEFT;
                document.Add(paragraph);

                document.Add(Chunk.NEWLINE);

                foreach (var item in calculoMulta.DetalleCalculoMulta)
                {
                    tableInfo = new PdfPTable(12);
                    tableInfo.WidthPercentage = 100F;
                    tableInfo.SpacingAfter = 10;
                    float[] widths = new float[] { 20f, 90f, 110f, 40f, 40f, 40f, 40f, 40f, 30f, 20f, 20f, 50f };
                    tableInfo.SetWidths(widths);

                    cellInfo = new PdfPCell(new Phrase("N°", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    if (item.literal == "LE" || item.literal == "LL")
                    {
                        cellInfo = new PdfPCell(new Phrase("Infracción al artículo 207° (207.3) del D.S. N° 018-2015-MINAGRI", fontBold));
                        cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                        cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellInfo.PaddingBottom = 2;
                        tableInfo.AddCell(cellInfo);
                    }
                    else
                    {
                        cellInfo = new PdfPCell(new Phrase("Infracción tipificada en el Anexo 1 del D.S. N° 007-2021-MIDAGRI", fontBold));
                        cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                        cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellInfo.PaddingBottom = 2;
                        tableInfo.AddCell(cellInfo);
                    }


                    cellInfo = new PdfPCell(new Phrase("Especie", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("Margen unitario (S/ por m3)", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("Volumen(m3)", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("IPC Fecha de infracción", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("B", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("VEN (S/ por m3)", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("G", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("A", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("R", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("VEN (G+A+R)", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    int pos = 1;
                    decimal beneficio = 0;
                    decimal vengar = 0;
                    foreach (var itemEspecie in item.especies)
                    {
                        cellInfo = new PdfPCell(new Phrase(pos.ToString(), font));
                        cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                        cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                        cellInfo.PaddingBottom = 2;
                        tableInfo.AddCell(cellInfo);

                        cellInfo = new PdfPCell(new Phrase("Literal " + item.literal.Substring(1, item.literal.Length - 1).ToLower() + ")", font));
                        cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                        cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                        cellInfo.PaddingBottom = 2;
                        tableInfo.AddCell(cellInfo);

                        cellInfo = new PdfPCell(new Phrase(itemEspecie.especie, font));
                        cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                        cellInfo.HorizontalAlignment = Element.ALIGN_LEFT;
                        cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                        cellInfo.PaddingBottom = 2;
                        tableInfo.AddCell(cellInfo);

                        cellInfo = new PdfPCell(new Phrase(itemEspecie.margen.ToString(), font));
                        cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                        cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                        cellInfo.PaddingBottom = 2;
                        tableInfo.AddCell(cellInfo);

                        cellInfo = new PdfPCell(new Phrase(itemEspecie.volumen.ToString(), font));
                        cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                        cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                        cellInfo.PaddingBottom = 2;
                        tableInfo.AddCell(cellInfo);

                        cellInfo = new PdfPCell(new Phrase(itemEspecie.fechaipc.ToString(), font));
                        cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                        cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                        cellInfo.PaddingBottom = 2;
                        tableInfo.AddCell(cellInfo);

                        cellInfo = new PdfPCell(new Phrase(itemEspecie.beneficio.ToString(), font));
                        cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                        cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                        cellInfo.PaddingBottom = 2;
                        tableInfo.AddCell(cellInfo);

                        cellInfo = new PdfPCell(new Phrase(itemEspecie.ven.ToString(), font));
                        cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                        cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                        cellInfo.PaddingBottom = 2;
                        tableInfo.AddCell(cellInfo);

                        cellInfo = new PdfPCell(new Phrase(itemEspecie.gravedad.ToString(), font));
                        cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                        cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                        cellInfo.PaddingBottom = 2;
                        tableInfo.AddCell(cellInfo);

                        cellInfo = new PdfPCell(new Phrase(itemEspecie.afectacion.ToString(), font));
                        cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                        cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                        cellInfo.PaddingBottom = 2;
                        tableInfo.AddCell(cellInfo);

                        cellInfo = new PdfPCell(new Phrase(itemEspecie.regeneracion.ToString(), font));
                        cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                        cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                        cellInfo.PaddingBottom = 2;
                        tableInfo.AddCell(cellInfo);

                        cellInfo = new PdfPCell(new Phrase(itemEspecie.vengar.ToString(), font));
                        cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                        cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                        cellInfo.PaddingBottom = 2;
                        tableInfo.AddCell(cellInfo);
                        pos++;
                        beneficio += itemEspecie.beneficio;
                        vengar += itemEspecie.vengar;
                    }

                    cellInfo = new PdfPCell(new Phrase(string.Empty, font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase(string.Empty, font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("SUMATORIA", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase(string.Empty, font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase(string.Empty, font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase(string.Empty, font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase(beneficio.ToString(), font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase(string.Empty, font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase(string.Empty, font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase(string.Empty, font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase(string.Empty, font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase(vengar.ToString(), font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfo.AddCell(cellInfo);

                    PdfPTable tableInfoTotales = new PdfPTable(9);
                    tableInfoTotales.WidthPercentage = 100F;
                    tableInfoTotales.SpacingAfter = 10;
                    float[] widthsTotales = new float[] { 90f, 30f, 120f, 50f, 40f, 40f, 20f, 60f, 90f };
                    tableInfo.SetWidths(widths);

                    cellInfo = new PdfPCell(new Phrase(string.Empty, fontBold));
                    cellInfo.Border = Rectangle.NO_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("K", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("SumB", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("CE", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("Pd", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("SumVEN(G+A+R)", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("F", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("SUB TOTAL (S/)", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("SUB TOTAL (U.I.T.)", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase(string.Empty, font));
                    cellInfo.Border = Rectangle.NO_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase(item.SumatoriaK.ToString(), font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase(item.SumatoriaB.ToString(), font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase(item.SumatoriaCE.ToString(), font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase(item.SumatoriaPD.ToString(), font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase(item.SumatoriaVEN.ToString(), font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase(item.SumatoriaF.ToString(), font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase(item.SubTotal.ToString(), font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase(item.Total.ToString(), font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    #region sumatoria de sumatoria
                    cellInfo = new PdfPCell(new Phrase(string.Empty, fontBold));
                    cellInfo.Border = Rectangle.NO_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    cellInfo = new PdfPCell(new Phrase("Multa  Literal (" + item.literal.Substring(1, item.literal.Length - 1).ToLower() + ") U.I.T.", fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.Colspan = 7;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);

                    decimal uit = item.Total * 1000 <= 100 ? Convert.ToDecimal(0.1) : item.Total;

                    //cellInfo = new PdfPCell(new Phrase(item.Total.ToString(), fontBold));
                    cellInfo = new PdfPCell(new Phrase(uit.ToString(), fontBold));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    cellInfo.PaddingBottom = 2;
                    tableInfoTotales.AddCell(cellInfo);
                    #endregion

                    document.Add(tableInfo);
                    document.Add(tableInfoTotales);

                    document.Add(Chunk.NEWLINE);
                }

                document.Add(Chunk.NEWLINE);
                paragraph = new Paragraph("                    RESUMEN", fontBold);
                paragraph.Alignment = Element.ALIGN_CENTER;
                document.Add(paragraph);


                PdfPTable tableInfoResumen = new PdfPTable(3);
                tableInfoResumen.WidthPercentage = 100F;
                tableInfoResumen.SpacingAfter = 10;
                float[] widthsResumen = new float[] { 240f, 210f, 90f };
                tableInfoResumen.SetWidths(widthsResumen);

                cellInfo = new PdfPCell(new Phrase(" ", fontBold));
                cellInfo.Border = Rectangle.NO_BORDER;
                cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                cellInfo.PaddingBottom = 2;
                cellInfo.PaddingTop = 2;
                tableInfoResumen.AddCell(cellInfo);

                cellInfo = new PdfPCell(new Phrase("Infracción", fontBold));
                cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                cellInfo.PaddingBottom = 2;
                cellInfo.PaddingTop = 2;
                tableInfoResumen.AddCell(cellInfo);

                cellInfo = new PdfPCell(new Phrase("Multa (U.I.T.)", fontBold));
                cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                cellInfo.PaddingBottom = 2;
                cellInfo.PaddingTop = 2;
                tableInfoResumen.AddCell(cellInfo);
                decimal sum = 0;
                foreach (var item in calculoMulta.DetalleCalculoMulta)
                {
                    cellInfo = new PdfPCell(new Phrase(" ", font));
                    cellInfo.Border = Rectangle.NO_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    tableInfoResumen.AddCell(cellInfo);

                    decimal uit = item.Total * 1000 <= 100 ? Convert.ToDecimal(0.1) : item.Total;

                    if (item.literal == "LE" || item.literal == "LL")
                    {
                        cellInfo = new PdfPCell(new Phrase("ART. 207° (207.3) del D.S. N° 018-2015-MINAGRI, Literal " + item.literal.Substring(1, item.literal.Length - 1).ToLower() + ")", font));
                        cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                        cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                        tableInfoResumen.AddCell(cellInfo);
                    }
                    else
                    {
                        cellInfo = new PdfPCell(new Phrase("Anexo 1 del D.S. N° 007-2021-MIDAGRI, numeral " + item.literal.Substring(1, item.literal.Length - 1).ToLower(), font));
                        cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                        cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                        cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                        tableInfoResumen.AddCell(cellInfo);
                    }


                    cellInfo = new PdfPCell(new Phrase(uit.ToString(), font));
                    cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                    tableInfoResumen.AddCell(cellInfo);

                    sum += uit;
                }

                cellInfo = new PdfPCell(new Phrase(" ", fontBold));
                cellInfo.Border = Rectangle.NO_BORDER;
                cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                tableInfoResumen.AddCell(cellInfo);

                cellInfo = new PdfPCell(new Phrase("Multa Total  " + literal, fontBold));
                cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                cellInfo.VerticalAlignment = Element.ALIGN_CENTER;
                tableInfoResumen.AddCell(cellInfo);

                cellInfo = new PdfPCell(new Phrase(sum.ToString(), fontBold));
                cellInfo.Border = Rectangle.TOP_BORDER | Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER;
                cellInfo.HorizontalAlignment = Element.ALIGN_CENTER;
                cellInfo.VerticalAlignment = Element.ALIGN_MIDDLE;
                tableInfoResumen.AddCell(cellInfo);

                if (Math.Round(sum*1000)<=100)
                {
                    cellInfo = new PdfPCell(new Phrase("(*) Art. 8° D.S. N° 007-2021-MIDAGRI. La sanción de multa constituye una sanción pecuniaria no menor de 0.10 ni mayor de 5,000 Unidades Impositivas Tributarias (UIT)", font));
                    cellInfo.Border = Rectangle.NO_BORDER;
                    cellInfo.HorizontalAlignment = Element.ALIGN_LEFT;
                    cellInfo.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cellInfo.Colspan = 3;
                    tableInfoResumen.AddCell(cellInfo);
                }                

                document.Add(tableInfoResumen);

                document.Close();

                byte[] byteInfo = workStream.ToArray();
                workStream.Write(byteInfo, 0, byteInfo.Length);
                workStream.Position = 0;

                return new FileStreamResult(workStream, "application/pdf");
            }
            catch (Exception ex)
            {

                return Json( new { error = ex.Message, trace = ex.StackTrace }, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}
