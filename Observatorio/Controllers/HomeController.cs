using Herramienta;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_OBSERVATORIO;
using CLogica = CapaLogica.DOC.Log_Reporte_OBSERVATORIO;
using oCLogicaFooter = CapaLogica.PDFFooter;

namespace Observatorio.Controllers
{
    public class HomeController : Controller
    {
        CLogica oCLogica = new CLogica();
        Utilitarios HerUtil = new Utilitarios();
        iTextSharp.text.Document doc;

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Menu()
        {
            return View("Menu");
        }


        [HttpGet]
        //[OutputCache(Duration = 14400, VaryByParam = "searchString")]
        public ActionResult listaRoja(string sortOrder, string currentFilter, string searchString, int? page)
        {
            CEntidad oCampos = new CEntidad();
            List<CEntidad> Lista_ROJO = new List<CEntidad>();
            List<CEntidad> Lista_ROJO_Busqueda = new List<CEntidad>();    
            try
            {
                ViewBag.CurrentSort = sortOrder;

                ViewBag.TitularSort = sortOrder == "Titular" ? "Titular_desc" : "Titular";
                ViewBag.THabilitanteSort = sortOrder == "NumTHabilitante" ? "NumTHabilitante_desc" : "NumTHabilitante";
                ViewBag.ModalidadSort = sortOrder == "Modalidad" ? "Modalidad_desc" : "Modalidad";
                ViewBag.DepartamentoSort = sortOrder == "Departamento" ? "Departamento_desc" : "Departamento";
                ViewBag.NumPOASort = sortOrder == "NumPOA" ? "NumPOA_desc" : "NumPOA";
                ViewBag.VigenciaSort = sortOrder == "VigenciaPOA" ? "VigenciaPOA_desc" : "VigenciaPOA";
                ViewBag.ZafraSort = sortOrder == "Zafra" ? "Zafra_desc" : "Zafra";
                ViewBag.AlertaSort = sortOrder == "Alerta" ? "Alerta_desc" : "Alerta";


                if (searchString != null) { page = 1; } else { searchString = currentFilter; }
                ViewBag.CurrentFilter = searchString;

                ViewBag.fechaProcess = (oCLogica.RegMostrarFechaObserv(new CEntidad())).FECHA;

                if ((List<CEntidad>)Session["Lista_ROJO"] == null)
                {
                    oCampos = getLista("11");
                    Lista_ROJO = oCampos.List_Resumen_ROJO;
                    Session["Lista_ROJO"] = Lista_ROJO;
                }
                else { Lista_ROJO = (List<CEntidad>)Session["Lista_ROJO"]; }

                if (!String.IsNullOrEmpty(searchString))
                {
                    searchString = HerUtil.RemoveAccentsWithRegEx(searchString.ToUpper());                   
                    foreach (var cadena in searchString.Split(' '))
                    {

                        Lista_ROJO = Lista_ROJO.Where(s => s.TITULAR_BUSQUEDA.ToUpper().Contains(cadena)
                                                                   || s.NUM_THABILITANTE.ToUpper().Contains(cadena)
                                                                   || s.MODALIDAD.ToUpper().Contains(cadena)
                                                                   || s.REGION.ToUpper().Contains(cadena)).ToList();           
                    }
                    Lista_ROJO_Busqueda = Lista_ROJO;
                    Lista_ROJO_Busqueda = Lista_ROJO_Busqueda.OrderBy(s => s.TITULAR).Distinct().ToList();
                }
                else { Lista_ROJO_Busqueda = Lista_ROJO; }

                switch (sortOrder)
                {
                    case "Titular":
                        Lista_ROJO_Busqueda = Lista_ROJO_Busqueda.OrderBy(s => s.TITULAR).ToList();
                        break;
                    case "NumTHabilitante":
                        Lista_ROJO_Busqueda = Lista_ROJO_Busqueda.OrderBy(s => s.NUM_THABILITANTE).ToList();
                        break;
                    case "Modalidad":
                        Lista_ROJO_Busqueda = Lista_ROJO_Busqueda.OrderBy(s => s.MODALIDAD).ToList();
                        break;
                    case "Departamento":
                        Lista_ROJO_Busqueda = Lista_ROJO_Busqueda.OrderBy(s => s.REGION).ToList();
                        break;
                    case "NumPOA":
                        Lista_ROJO_Busqueda = Lista_ROJO_Busqueda.OrderBy(s => s.NUM_POA).ToList();
                        break;
                    case "VigenciaPOA":
                        Lista_ROJO_Busqueda = Lista_ROJO_Busqueda.OrderBy(s => s.VIGENCIA).ToList();
                        break;
                    case "Zafra":
                        Lista_ROJO_Busqueda = Lista_ROJO_Busqueda.OrderBy(s => s.ZAFRA).ToList();
                        break;
                    case "Titular_desc":
                        Lista_ROJO_Busqueda = Lista_ROJO_Busqueda.OrderByDescending(s => s.TITULAR).ToList();
                        break;
                    case "NumTHabilitante_desc":
                        Lista_ROJO_Busqueda = Lista_ROJO_Busqueda.OrderByDescending(s => s.NUM_THABILITANTE).ToList();
                        break;
                    case "Modalidad_desc":
                        Lista_ROJO_Busqueda = Lista_ROJO_Busqueda.OrderByDescending(s => s.MODALIDAD).ToList();
                        break;
                    case "Departamento_desc":
                        Lista_ROJO_Busqueda = Lista_ROJO_Busqueda.OrderByDescending(s => s.REGION).ToList();
                        break;
                    case "NumPOA_desc":
                        Lista_ROJO_Busqueda = Lista_ROJO_Busqueda.OrderByDescending(s => s.NUM_POA).ToList();
                        break;
                    case "VigenciaPOA_desc":
                        Lista_ROJO_Busqueda = Lista_ROJO_Busqueda.OrderByDescending(s => s.VIGENCIA).ToList();
                        break;
                    case "Zafra_desc":
                        Lista_ROJO_Busqueda = Lista_ROJO_Busqueda.OrderByDescending(s => s.ZAFRA).ToList();
                        break;
                    case "Alerta":
                        Lista_ROJO_Busqueda = Lista_ROJO_Busqueda.OrderByDescending(s => s.ALERTA).ToList();
                        break;
                }

                //Session["Lista_ROJO"] = Lista_ROJO;
                int pageSize = 20;
                int pageNumber = (page ?? 1);
                return View("viewListaRoja", Lista_ROJO_Busqueda.ToPagedList(pageNumber, pageSize));
                //return View("viewListaRoja", Lista_ROJO);
            }
            catch (Exception)
            {
                return View("viewListaRoja", (new List<CEntidad>()).ToPagedList(1, 1));
            }
        }

        [HttpGet]
        //[OutputCache(Duration = 14400, VaryByParam = "searchString")]
        public ActionResult listaVerde(string sortOrder, string currentFilter, string searchString, int? page)
        {
            CEntidad oCampos = new CEntidad();
            List<CEntidad> Lista_VERDE = new List<CEntidad>();
            List<CEntidad> Lista_VERDE_Busqueda = new List<CEntidad>();

            try
            {
                ViewBag.CurrentSort = sortOrder;

                ViewBag.TitularSort = sortOrder == "Titular" ? "Titular_desc" : "Titular";
                ViewBag.THabilitanteSort = sortOrder == "NumTHabilitante" ? "NumTHabilitante_desc" : "NumTHabilitante";
                ViewBag.ModalidadSort = sortOrder == "Modalidad" ? "Modalidad_desc" : "Modalidad";
                ViewBag.DepartamentoSort = sortOrder == "Departamento" ? "Departamento_desc" : "Departamento";
                ViewBag.NumPOASort = sortOrder == "NumPOA" ? "NumPOA_desc" : "NumPOA";
                ViewBag.VigenciaSort = sortOrder == "VigenciaPOA" ? "VigenciaPOA_desc" : "VigenciaPOA";
                ViewBag.ZafraSort = sortOrder == "Zafra" ? "Zafra_desc" : "Zafra";

                if (searchString != null) { page = 1; } else { searchString = currentFilter; }
                ViewBag.CurrentFilter = searchString;

                ViewBag.fechaProcess = (oCLogica.RegMostrarFechaObserv(new CEntidad())).FECHA;

                if ((List<CEntidad>)Session["Lista_VERDE"] == null)
                {
                    oCampos = getLista("13");
                    Lista_VERDE = oCampos.List_Resumen_VERDE;
                    Session["Lista_VERDE"] = Lista_VERDE;
                }
                else { Lista_VERDE = (List<CEntidad>)Session["Lista_VERDE"]; }

                if (!String.IsNullOrEmpty(searchString))
                {
                    searchString = HerUtil.RemoveAccentsWithRegEx(searchString.ToUpper());
                    foreach (var cadena in searchString.Split(' '))
                    {

                        Lista_VERDE = Lista_VERDE.Where(s => s.TITULAR_BUSQUEDA.ToUpper().Contains(cadena)
                                                                   || s.NUM_THABILITANTE.ToUpper().Contains(cadena)
                                                                   || s.MODALIDAD.ToUpper().Contains(cadena)
                                                                   || s.REGION.ToUpper().Contains(cadena)).ToList();
                    }
                    Lista_VERDE_Busqueda = Lista_VERDE;
                    Lista_VERDE_Busqueda = Lista_VERDE_Busqueda.OrderBy(s => s.TITULAR).Distinct().ToList();
                }
                else { Lista_VERDE_Busqueda = Lista_VERDE; }

                switch (sortOrder)
                {
                    case "Titular":
                        Lista_VERDE_Busqueda = Lista_VERDE_Busqueda.OrderBy(s => s.TITULAR).ToList();
                        break;
                    case "NumTHabilitante":
                        Lista_VERDE_Busqueda = Lista_VERDE_Busqueda.OrderBy(s => s.NUM_THABILITANTE).ToList();
                        break;
                    case "Modalidad":
                        Lista_VERDE_Busqueda = Lista_VERDE_Busqueda.OrderBy(s => s.MODALIDAD).ToList();
                        break;
                    case "Departamento":
                        Lista_VERDE_Busqueda = Lista_VERDE_Busqueda.OrderBy(s => s.REGION).ToList();
                        break;
                    case "NumPOA":
                        Lista_VERDE_Busqueda = Lista_VERDE_Busqueda.OrderBy(s => s.NUM_POA).ToList();
                        break;
                    case "VigenciaPOA":
                        Lista_VERDE_Busqueda = Lista_VERDE_Busqueda.OrderBy(s => s.VIGENCIA).ToList();
                        break;
                    case "Zafra":
                        Lista_VERDE_Busqueda = Lista_VERDE_Busqueda.OrderBy(s => s.ZAFRA).ToList();
                        break;
                    case "Titular_desc":
                        Lista_VERDE_Busqueda = Lista_VERDE_Busqueda.OrderByDescending(s => s.TITULAR).ToList();
                        break;
                    case "NumTHabilitante_desc":
                        Lista_VERDE_Busqueda = Lista_VERDE_Busqueda.OrderByDescending(s => s.NUM_THABILITANTE).ToList();
                        break;
                    case "Modalidad_desc":
                        Lista_VERDE_Busqueda = Lista_VERDE_Busqueda.OrderByDescending(s => s.MODALIDAD).ToList();
                        break;
                    case "Departamento_desc":
                        Lista_VERDE_Busqueda = Lista_VERDE_Busqueda.OrderByDescending(s => s.REGION).ToList();
                        break;
                    case "NumPOA_desc":
                        Lista_VERDE_Busqueda = Lista_VERDE_Busqueda.OrderByDescending(s => s.NUM_POA).ToList();
                        break;
                    case "VigenciaPOA_desc":
                        Lista_VERDE_Busqueda = Lista_VERDE_Busqueda.OrderByDescending(s => s.VIGENCIA).ToList();
                        break;
                    case "Zafra_desc":
                        Lista_VERDE_Busqueda = Lista_VERDE_Busqueda.OrderByDescending(s => s.ZAFRA).ToList();
                        break;
                }

                //Session["Lista_VERDE"] = Lista_VERDE;

                int pageSize = 20;
                int pageNumber = (page ?? 1);
                return View("viewListaVerde", Lista_VERDE_Busqueda.ToPagedList(pageNumber, pageSize));

            }
            catch (Exception)
            {
                return View("viewListaVerde", (new List<CEntidad>()).ToPagedList(1, 1));
            }
        }
        private CEntidad getLista(String tipoReporte)
        {
            try
            {
                CEntidad oCampos = new CEntidad();
                oCampos.TIPO_REPORTE = tipoReporte;
                return oCLogica.RegMostrarListadoResumen(oCampos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public ActionResult descargaPDFverde(Int32 idRegistro)
        {
            List<CEntidad> Lista_VERDE = new List<CEntidad>();
            try
            {
                CEntidad oCampos = new CEntidad();
                if ((List<CEntidad>)Session["Lista_VERDE"] == null)
                {
                    oCampos = getLista("13"); Lista_VERDE = oCampos.List_Resumen_VERDE; Session["Lista_VERDE"] = Lista_VERDE;
                }
                else { Lista_VERDE = (List<CEntidad>)Session["Lista_VERDE"]; }

                descargaPDF(idRegistro);
                return View("viewListaVerde", Lista_VERDE.ToPagedList(1, 1));
            }
            catch (Exception)
            {
                return View("viewListaVerde", (new List<CEntidad>()).ToPagedList(1, 1));
            }
        }
        [HttpGet]
        public ActionResult descargaPDFrojo(Int32 idRegistro)
        {
            List<CEntidad> Lista_ROJO = new List<CEntidad>();
            try
            {
                CEntidad oCampos = new CEntidad();
                if ((List<CEntidad>)Session["Lista_ROJO"] == null)
                {
                    oCampos = getLista("11"); Lista_ROJO = oCampos.List_Resumen_ROJO; Session["Lista_ROJO"] = Lista_ROJO;
                }
                else { Lista_ROJO = (List<CEntidad>)Session["Lista_ROJO"]; }

                descargaPDF(idRegistro);
                return View("viewListaRoja", Lista_ROJO.ToPagedList(1, 1));
            }
            catch (Exception)
            {
                return View("viewListaRoja", (new List<CEntidad>()).ToPagedList(1, 1));
            }
        }
        private void descargaPDF(Int32 idRegistro)
        {
            try
            {
                string valCadena = "";
                obsWSObservatorio.WSObservatorioSoapClient ws = new obsWSObservatorio.WSObservatorioSoapClient();
                valCadena = ws.escribirDetallePDFIndex(idRegistro, "~/PlantillaPDF/", "3");

                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                //string nombrePDF = lblTituloHabilitanteView.Text.Replace("-", "_");        
                Response.AddHeader("content-disposition", "attachment;filename=" + valCadena + ".pdf");
                Response.ContentType = "application/pdf";
                string rut1 = Server.MapPath("~/PlantillaPDF/Descargas/" + valCadena + ".pdf");// @"C:\doc.pdf";
                Response.TransmitFile(rut1);
                Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public ActionResult descargaResumenPDF(String Color)
        {
            List<CEntidad> Lista_ROJO = new List<CEntidad>();
            List<CEntidad> Lista_AMBAR = new List<CEntidad>();
            List<CEntidad> Lista_VERDE = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            String vistaRetorno = "";
            float[] widths = null;
            try
            {
                doc = new Document(new iTextSharp.text.Rectangle(824, 595));
                CEntidad oCEntidad = new CEntidad();
                doc.AddAuthor("OSINFOR");
                doc.AddKeywords("pdf, PdfWriter; Documento; iTextSharp");
                doc.SetMargins(36.0f, 36.0f, 110.0f, 80.0f);
                string rut = Server.MapPath("~/PlantillaPDF/ObservatorioSIGO.pdf");

                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(rut, FileMode.Create));
                wri.PageEvent = new oCLogicaFooter();
                doc.Open();

                Rectangle page = doc.PageSize;

                PdfPTable tableTitulo = new PdfPTable(12);
                tableTitulo.WidthPercentage = 40;
                tableTitulo.TotalWidth = page.Width - 290;
                string alturaTh = tableTitulo.TotalHeight.ToString();
                tableTitulo.LockedWidth = true;
                float[] widths0 = new float[] { .1f, .8f, .8f, .4f, .4f, .4f, .2f, .3f, .3f, .7f, .3f, .1f };
                tableTitulo.SetWidths(widths0);

                tableTitulo.AddCell(HerUtil.celda("   ", 12, 1, 10, Element.ALIGN_CENTER, 0, BaseColor.BLACK, "transparent", "Normal"));
                switch (Color)
                {
                    case "ROJO":
                        tableTitulo.AddCell(HerUtil.celda("Lista de Titulares con Riesgo para comercio legal de la madera", 12, 1, 14, Element.ALIGN_CENTER, 0, BaseColor.RED, "transparent", "Negrita"));
                        if ((List<CEntidad>)Session["Lista_ROJO"] == null)
                        {
                            oCampos = getLista("11"); Lista_ROJO = oCampos.List_Resumen_ROJO; Session["Lista_ROJO"] = Lista_ROJO;
                        }
                        else { Lista_ROJO = (List<CEntidad>)Session["Lista_ROJO"]; }
                        widths = new float[] { .1f, .8f, .7f, .4f, .4f, .4f, .2f, .3f, .7f, .3f, .3f, .2f };
                        vistaRetorno = "viewListaRoja";
                        break;
                    case "AMBAR":
                        tableTitulo.AddCell(HerUtil.celda("Lista de Titulares de Mediano Riesgo para comercio legal de la madera", 12, 1, 14, Element.ALIGN_CENTER, 0, BaseColor.YELLOW, "transparent", "Negrita"));
                        widths = new float[] { .1f, .8f, .7f, .4f, .4f, .4f, .2f, .3f, .7f, .3f, .3f, .2f };
                        vistaRetorno = "";
                        break;
                    case "VERDE":
                        if ((List<CEntidad>)Session["Lista_VERDE"] == null)
                        {
                            oCampos = getLista("13"); Lista_VERDE = oCampos.List_Resumen_VERDE; Session["Lista_VERDE"] = Lista_VERDE;
                        }
                        else { Lista_VERDE = (List<CEntidad>)Session["Lista_VERDE"]; }
                        tableTitulo.AddCell(HerUtil.celda("Lista de Titulares sin Riesgo para comercio legal de la madera", 12, 1, 14, Element.ALIGN_CENTER, 0, BaseColor.GREEN, "transparent", "Negrita"));
                        widths = new float[] { .1f, .8f, .8f, .4f, .4f, .4f, .2f, .3f, .7f, .3f, .3f, .2f };
                        vistaRetorno = "viewListaVerde";
                        break;
                }
                doc.Add(tableTitulo);
                doc.Add(new Paragraph("\n"));


                PdfPTable table = new PdfPTable(12);
                table.WidthPercentage = 80;
                table.TotalWidth = page.Width - 90;
                string altura = table.TotalHeight.ToString();
                table.LockedWidth = true;
                table.SetWidths(widths);

                switch (Color)
                {
                    case "ROJO":
                        if (Lista_ROJO.Count > 0)
                        {
                            PdfPTable table2 = new PdfPTable(8);
                            table2.WidthPercentage = 80;
                            table2.TotalWidth = page.Width - 90;
                            table2.LockedWidth = true;
                            float[] widths2 = new float[] { .2f, .7f, .7f, .8f, .7f, .2f, .3f, .3f };
                            table2.SetWidths(widths2);

                            table2.AddCell(HerUtil.celda("N°", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "pink", "Normal"));
                            table2.AddCell(HerUtil.celda("Titular", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "pink", "Normal"));
                            table2.AddCell(HerUtil.celda("Título Habilitante", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "pink", "Normal"));
                            table2.AddCell(HerUtil.celda("Modalidad de Aprovechamiento", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "pink", "Normal"));
                            table2.AddCell(HerUtil.celda("Ubicación", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "pink", "Normal"));
                            table2.AddCell(HerUtil.celda("N° POA", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "pink", "Normal"));
                            table2.AddCell(HerUtil.celda("Vigencia", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "pink", "Normal"));
                            table2.AddCell(HerUtil.celda("Zafra", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "pink", "Normal"));

                            for (int i = 0; i < Lista_ROJO.Count; i++)
                            {
                                table2.AddCell(HerUtil.celda((i + 1).ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_ROJO[i].TITULAR, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_ROJO[i].NUM_THABILITANTE, 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_ROJO[i].MODALIDAD, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_ROJO[i].UBICACION.ToString(), 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_ROJO[i].NUM_POA.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_ROJO[i].VIGENCIA.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_ROJO[i].ZAFRA.ToString(), 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                            }
                            table2.AddCell(HerUtil.celda(" ", 6, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                            doc.Add(table2);
                        }
                        break;
                    case "AMBAR":
                        if (Lista_AMBAR.Count > 0)
                        {
                            PdfPTable table2 = new PdfPTable(9);
                            table2.WidthPercentage = 80;
                            table2.TotalWidth = page.Width - 90;
                            table2.LockedWidth = true;
                            float[] widths2 = new float[] { .2f, .8f, .8f, .8f, .7f, .2f, .3f };
                            table2.SetWidths(widths2);
                            table2.AddCell(HerUtil.celda("N°", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "yellow", "Normal"));
                            table2.AddCell(HerUtil.celda("Titular", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "yellow", "Normal"));
                            table2.AddCell(HerUtil.celda("Título Habilitante", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "yellow", "Normal"));
                            table2.AddCell(HerUtil.celda("Modalidad de Aprovechamiento", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "yellow", "Normal"));
                            table2.AddCell(HerUtil.celda("Ubicación", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "yellow", "Normal"));
                            table2.AddCell(HerUtil.celda("N° POA", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "yellow", "Normal"));
                            table2.AddCell(HerUtil.celda("Vigencia", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "yellow", "Normal"));
                            table2.AddCell(HerUtil.celda("Zafra", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "yellow", "Normal"));
                            table2.AddCell(HerUtil.celda("Medidas Cautelares", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "pink", "Normal"));
                            for (int i = 0; i < Lista_AMBAR.Count; i++)
                            {
                                table2.AddCell(HerUtil.celda((i + 1).ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_AMBAR[i].TITULAR, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_AMBAR[i].NUM_THABILITANTE, 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_AMBAR[i].MODALIDAD, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_AMBAR[i].UBICACION.ToString(), 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_AMBAR[i].NUM_POA.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_AMBAR[i].VIGENCIA.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_AMBAR[i].ZAFRA.ToString(), 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_AMBAR[i].MEDIDA_CAUTELAR.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                            }
                            table2.AddCell(HerUtil.celda(" ", 6, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                            doc.Add(table2);
                        }
                        break;
                    case "VERDE":
                        if (Lista_VERDE.Count > 0)
                        {
                            PdfPTable table2 = new PdfPTable(8);
                            table2.WidthPercentage = 80;
                            table2.TotalWidth = page.Width - 90;
                            table2.LockedWidth = true;
                            float[] widths2 = new float[] { .2f, .8f, .8f, .9f, .9f, .2f, .3f, .3f };
                            table2.SetWidths(widths2);

                            table2.AddCell(HerUtil.celda("N°", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgreen", "Normal"));
                            table2.AddCell(HerUtil.celda("Titular", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgreen", "Normal"));
                            table2.AddCell(HerUtil.celda("Título Habilitante", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgreen", "Normal"));
                            table2.AddCell(HerUtil.celda("Modalidad de Aprovechamiento", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgreen", "Normal"));
                            table2.AddCell(HerUtil.celda("Ubicación", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgreen", "Normal"));
                            table2.AddCell(HerUtil.celda("N° POA", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgreen", "Normal"));
                            table2.AddCell(HerUtil.celda("Vigencia", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgreen", "Normal"));
                            table2.AddCell(HerUtil.celda("Zafra", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgreen", "Normal"));

                            for (int i = 0; i < Lista_VERDE.Count; i++)
                            {
                                table2.AddCell(HerUtil.celda((i + 1).ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_VERDE[i].TITULAR, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_VERDE[i].NUM_THABILITANTE, 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_VERDE[i].MODALIDAD, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_VERDE[i].UBICACION.ToString(), 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_VERDE[i].NUM_POA.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_VERDE[i].VIGENCIA.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                                table2.AddCell(HerUtil.celda(Lista_VERDE[i].ZAFRA.ToString(), 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                            }
                            table2.AddCell(HerUtil.celda(" ", 6, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                            doc.Add(table2);
                        }
                        break;
                }

                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));

                doc.Close();
                switch (Color)
                {
                    case "ROJO":
                        HerUtil.agregarMarcaAguaImagen(Server.MapPath("~/PlantillaPDF/ObservatorioSIGO.pdf"), Server.MapPath("~/PlantillaPDF/ObservatorioSIGOMarca.pdf"), Server.MapPath("~/Imagenes/Observatorio/huella_osinfor_rojo_horizontal.jpg"));
                        break;
                    case "AMBAR":
                        HerUtil.agregarMarcaAguaImagen(Server.MapPath("~/PlantillaPDF/ObservatorioSIGO.pdf"), Server.MapPath("~/PlantillaPDF/ObservatorioSIGOMarca.pdf"), Server.MapPath("~/Imagenes/Observatorio/huella_osinfor_ambar_horizontal.jpg"));
                        break;
                    case "VERDE":
                        HerUtil.agregarMarcaAguaImagen(Server.MapPath("~/PlantillaPDF/ObservatorioSIGO.pdf"), Server.MapPath("~/PlantillaPDF/ObservatorioSIGOMarca.pdf"), Server.MapPath("~/Imagenes/Observatorio/huella_osinfor_verde_horizontal.jpg"));
                        break;
                }

                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("content-disposition", "attachment;filename=ObservatorioSIGOMarca.pdf");
                Response.ContentType = "application/pdf";
                Response.TransmitFile(Server.MapPath("~/PlantillaPDF/ObservatorioSIGOMarca.pdf"));
                Response.End();

                if (Color == "ROJO") { return View(vistaRetorno, Lista_ROJO); }
                else if (Color == "VERDE") { return View(vistaRetorno, Lista_VERDE); }
                else { return View(vistaRetorno); }


            }
            catch (Exception ex)
            {
                //return View("Menu");
                return View(ex.Message);
            }           
        }

        [HttpGet]
        public ActionResult dowloadEcxel(String Color)
        {
            try
            {
                List<CEntidad> ListEspecies = new List<CEntidad>();
                CEntidad oCampos = new CEntidad();
                if (Color == "ROJO")
                {
                    oCampos.BusValor = "R";
                }
                else if (Color == "VERDE")
                {
                    oCampos.BusValor = "V";
                }
                ListEspecies = oCLogica.RegMostrarListEspecies(oCampos);

                if (ListEspecies != null)
                {
                    if (ListEspecies.Count > 0)
                    {
                        int i = 1;

                        String insertar = "";
                        String RutaReporteSeguimiento = Server.MapPath("~/PlantillaPDF/");
                        string nombreFile = "";
                        nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                        string rutaExcel = RutaReporteSeguimiento + nombreFile;
                        System.IO.File.Copy(RutaReporteSeguimiento + "plantilla_especies.xlsx", rutaExcel); //pues si es mover 
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
                            //Abrimos la conexión
                            conn.Open();
                            //Creamos la ficha
                            using (OleDbCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.Text;
                                //Construyendo las Cabeceras
                                foreach (var listaInf in ListEspecies)
                                {
                                    insertar = "";
                                    insertar = "'" + listaInf.TITULAR.Replace("'", "’") + "'";
                                    insertar = insertar + ",'" + listaInf.NUM_THABILITANTE + "'";
                                    insertar = insertar + ",'" + listaInf.MODALIDAD + "'";
                                    insertar = insertar + ",'" + listaInf.REGION + "'";
                                    insertar = insertar + ",'" + listaInf.NUM_POA + "'";
                                    insertar = insertar + ",'" + listaInf.RES_APROBACION_POA + "'";
                                    insertar = insertar + ",'" + listaInf.RES_REFORMULA_POA + "'";
                                    insertar = insertar + ",'" + listaInf.VIGENCIA + "'";
                                    insertar = insertar + ",'" + listaInf.ZAFRA + "'";
                                    insertar = insertar + ",'" + listaInf.COLOR + "'";
                                    insertar = insertar + ",'" + listaInf.ESTADO_TH + "'";
                                    insertar = insertar + ",'" + listaInf.NUM_RDINICIO + "'";
                                    insertar = insertar + ",'" + listaInf.NUM_RDTERMINO + "'";
                                    insertar = insertar + ",'" + listaInf.ESTADO + "'";
                                    insertar = insertar + ",'" + listaInf.TIPO_REPORTE + "'";
                                    insertar = insertar + ",'" + listaInf.NOM_CIENTIFICO + "'";
                                    insertar = insertar + ",'" + listaInf.NOMBRE_COMUN + "'";
                                    insertar = insertar + ",'" + listaInf.VOLUMEN_AUT + "'";
                                    insertar = insertar + ",'" + listaInf.VOLUMEN_BEXT + "'";
                                    insertar = insertar + ",'" + listaInf.VOLUMEN + "'";
                                    insertar = insertar + ",'" + listaInf.PORCENT_AUT + "'";
                                    insertar = insertar + ",'" + listaInf.PORCENT_INJUS_VOL + "'";
                                    insertar = insertar + ",'" + listaInf.NUM_ARB_MUESTRA + "'";
                                    insertar = insertar + ",'" + listaInf.NUM_ARBOLES_INEX + "'";
                                    insertar = insertar + ",'" + listaInf.PORCENT_INEX + "'";
                                    cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Y" + (ListEspecies.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                    cmd.ExecuteNonQuery();
                                }

                                //Cerramos la conexión
                                conn.Close();
                            }

                        }

                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.AddHeader("content-disposition", "attachment;filename=ListaEspeciesObservatorio.xlsx");
                        Response.ContentType = "application/octet-stream";
                        //Response.ContentType = "application/xlsx";
                        Response.TransmitFile(Server.MapPath("~/PlantillaPDF/" + nombreFile));
                        Response.End();
                    }
                }
                return View("Menu");
            }
            catch (Exception)
            {

                //modelFauna.mensajeError = ex.Message.ToString();
                return View("Menu");

            }
        }
    }
}