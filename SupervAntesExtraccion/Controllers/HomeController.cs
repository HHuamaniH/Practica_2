using Herramienta;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NLog;
using SupervAntesExtraccion.Models;
using System;
using System.Collections.Generic;
using System.Data;
//importaciones para la descarga de archivo
using System.Data.OleDb;
using System.IO;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_Historial_TH;
//importaciones de las capas de datos y entidad
using CLogica = CapaLogica.DOC.Log_RHistorial_TH;
using oCLogicaFooter = CapaLogica.PDFFooter;

namespace SupervAntesExtraccion.Controllers
{
    public class HomeController : Controller
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        EncriptModel encriptModel = new EncriptModel();

        CLogica oCLogica = new CLogica();
        List<CEntidad> listCEntidad = new List<CEntidad>();
        List<CEntidad> listFiltros = new List<CEntidad>();
        CEntidad oCEntidad = new CEntidad();
        InformeModel model = new InformeModel();
        Utilitarios HerUtil = new Utilitarios();

        Document doc;
        //
        // GET: /SIGO/

        public ActionResult Index()
        {
            //listSup();
            return View("mensaje", model);
        }

        public ActionResult Home()
        {
            listSup();
            return View("Index", model);
        }

        public void listSup()
        {
            oCEntidad = new CEntidad();
            oCEntidad.BusCriterio = "INF_SUP_ANTES";
            oCEntidad.BusValor = "";
            oCEntidad.NUM_POA = 0;
            listCEntidad = oCLogica.logListInfASuperv(oCEntidad);
            if (listCEntidad == null)
            {
                listCEntidad = new List<CEntidad>();
            }
            /* if (listCEntidad.Count > 0)
             {
                 for (int i = 0; i < listCEntidad.Count; i++)
                 {
                     listCEntidad[i].COD_THABILITANTE = encriptModel.Encriptar(listCEntidad[i].COD_THABILITANTE);
                     listCEntidad[i].COD_INFORME = encriptModel.Encriptar(listCEntidad[i].COD_INFORME);
                 }
             }*/
            model.fecha = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy");
            model.ListInformSup = listCEntidad;
            Session["model"] = model;
            auditoriaReporte("Buscar", "0000046");
        }

        /// <summary>
        /// metodo para descargar los registros en excel
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult dowloanEcxel()
        {
            try
            {
                model = (InformeModel)Session["model"];
                if (model == null)
                {
                    model = new InformeModel();
                }
                if (model.ListInformSup != null)
                {
                    listCEntidad = (List<CEntidad>)model.ListInformSup;
                    if (listCEntidad.Count > 0)
                    {
                        int i = 1;
                        String insertar = "";
                        String RutaReporteSeguimiento = Server.MapPath("~/Archivos/");
                        string nombreFile = "";
                        nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                        string rutaExcel = RutaReporteSeguimiento + nombreFile;
                        System.IO.File.Copy(RutaReporteSeguimiento + "ListaInformeASuperv.xlsx", rutaExcel);
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
                                foreach (var listaInf in listCEntidad)
                                {
                                    insertar = "";
                                    insertar = "'" + listaInf.TITULAR.Replace("'", "’") + "'";
                                    insertar = insertar + ",'" + listaInf.TITULO + "'";
                                    insertar = insertar + ",'" + listaInf.MODALIDAD + "'";
                                    insertar = insertar + ",'" + listaInf.DEPARTAMENTO + "'";
                                    insertar = insertar + ",'" + listaInf.NUM_POA_STRING + "'";
                                    insertar = insertar + ",'" + listaInf.NUMERO_RESOLUCION + "'";
                                    // lblMensaje.Text = insertar;
                                    cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":F" + (listCEntidad.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                    cmd.ExecuteNonQuery();
                                }
                                //Cerramos la conexión
                                conn.Close();
                            }

                        }
                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.AddHeader("content-disposition", "attachment;filename=InformeSupConcluidos.xlsx");
                        Response.ContentType = "application/xlsx";
                        Response.TransmitFile(Server.MapPath("~/Archivos/" + nombreFile));
                        Response.End();
                    }
                }
                auditoriaReporte("Descargar Excel", "0000045");
                return View("Index", model);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                model.mensajeError = "A ocurrido un error ponerse en contacto con el administrador";  //ex.Message.ToString();
                return View("Close", model);

            }
        }



        /// <summary>
        /// metodo para validar la informacion del usuario final
        /// </summary>
        /// <param name="action"></param>
        /// <param name="cod_formulario"></param>
        public void auditoriaReporte(String action, String cod_formulario)
        {
            CEntidad oCEntidadTemp = new CEntidad();
            oCEntidadTemp.COD_ACCION = "";
            oCEntidadTemp.ACCION = action;
            oCEntidadTemp.COD_FORMULARIO = cod_formulario;
            oCEntidadTemp.OUTPUTPARAM01 = "";
            oCEntidadTemp.IP = Request.UserHostAddress;
            oCEntidadTemp.HOSTNAME = Request.UserHostName;
            String OUTPUTPARAM = oCLogica.LogAuditoria(oCEntidadTemp);
        }

        /// <summary>
        /// metodo para descargar en PDF el detalle de los informe de supervision antes de la supervision
        /// </summary>
        /// <param name="hfTHabilitanteCod"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult detalle(String hfCodInforme)
        {
            try
            {
                model = (InformeModel)Session["model"];
                if (model == null)
                {
                    model = new InformeModel();
                }
                CEntidad oCEntidadTem = new CEntidad();
                oCEntidadTem.BusCriterio = "INF_SUP_ANTES_DETALLE";
                oCEntidadTem.BusValor = hfCodInforme;
                oCEntidadTem.NUM_POA = 0;
                oCEntidadTem = oCLogica.logInformeASupervDet(oCEntidadTem);
                model.oCEntidad = oCEntidadTem;
                //listado de POA
                Session["model"] = model;
                auditoriaReporte("Buscar Detalle", "0000042");
                escribirDetallePDF(model.oCEntidad);
                return View("Index", model);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                model.mensajeError = "A ocurrido un error ponerse en contacto con el administrador";  //ex.Message.ToString();
                //model.mensajeError = ex.Message.ToString();
                return View("Close", model);
            }

        }


        public void escribirDetallePDF(CEntidad elementListado)
        {
            String nombreArchivo;
            String colorHeader = "";
            PdfPTable tableTitulo;
            PdfPTable tableDatos;
            PdfPTable tableTituloBloque;
            PdfPTable tableIncisos;
            float[] medCols;
            String mapPath = Server.MapPath("~/Archivos/");
            int i = 0;
            try
            {
                colorHeader = "lightgray";

                doc = new Document(iTextSharp.text.PageSize.LETTER);
                CEntidad oCEntidad = new CEntidad();
                doc.AddAuthor("OSINFOR");
                doc.AddKeywords("pdf, PdfWriter; Documento; iTextSharp");
                doc.SetMargins(36.0f, 36.0f, 90.0f, 60.0f);
                nombreArchivo = ((((elementListado.TITULO.ToString() + "_" + elementListado.NUM_POA.ToString() + "_" + DateTime.Now.ToString()).Replace('.', 'x')).Replace(' ', '_')).Replace('/', '_')).Replace(':', '-').Replace('|', '-').Replace(';', '-').Replace(',', 'x');
                string rut = mapPath + "Descargas\\" + nombreArchivo + "_" + ".pdf";// @"C:\doc.pdf";
                                                                                    //Procedemos a crear el documento en la ruta antes establecida
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(rut, FileMode.Create));
                wri.PageEvent = new oCLogicaFooter();
                doc.Open();
                iTextSharp.text.Rectangle page = doc.PageSize; //Obtenemos el tamaño total de la pagina

                medCols = new float[] { .35f, .01f, .64f };
                tableTitulo = HerUtil.constructorTabla(3, page, medCols, page.Width - 290);

                //doc.Add(new Paragraph("\n"));

                medCols = new float[] { .30f };
                tableTituloBloque = HerUtil.constructorTabla(1, page, medCols, page.Width - 90);

                tableTituloBloque.AddCell(HerUtil.celda("Datos Generales", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "lightgray", "Negrita"));
                tableTituloBloque.AddCell(HerUtil.celda("", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                doc.Add(tableTituloBloque);

                medCols = new float[] { .35f, .01f, .64f };
                tableDatos = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);

                tableDatos.AddCell(HerUtil.celda("Titular(es): ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.TITULAR.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                tableDatos.AddCell(HerUtil.celda("Título Habilitante: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.TITULO.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                tableDatos.AddCell(HerUtil.celda("Modalidad de Aprovechamiento: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.MODALIDAD.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                tableDatos.AddCell(HerUtil.celda("Ubicación: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.UBICACION.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                tableDatos.AddCell(HerUtil.celda("Tipo de Plan de Manejo: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.Tipo_Inicio.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                tableDatos.AddCell(HerUtil.celda("N° Plan de Manejo: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.NUM_POA_STRING.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                tableDatos.AddCell(HerUtil.celda("Resolución Aprob. del Plan de Manejo: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.OTROS_NUM_RESOLUCION.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                tableDatos.AddCell(HerUtil.celda("Fecha Emisión: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.FECHA_TFFS.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                tableDatos.AddCell(HerUtil.celda("Parcela de Corta: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.PCA.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                tableDatos.AddCell(HerUtil.celda("Vigencia del Plan de Manejo: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda("Inicio : " + elementListado.FECHA_INICIO.ToString() + " Fin : " + elementListado.FECHA_FIN.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                tableDatos.AddCell(HerUtil.celda("Regente: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.consultor.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));

                doc.Add(tableDatos);
                doc.Add(new Paragraph("\n"));

                medCols = new float[] { .30f };
                tableTituloBloque = HerUtil.constructorTabla(1, page, medCols, page.Width - 90);

                tableTituloBloque.AddCell(HerUtil.celda("Supervisión OSINFOR", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "lightgray", "Negrita"));
                tableTituloBloque.AddCell(HerUtil.celda("", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                doc.Add(tableTituloBloque);

                medCols = new float[] { .35f, .01f, .64f };
                tableDatos = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);

                tableDatos.AddCell(HerUtil.celda("Fecha Supervisión: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.Fecha_Sup.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                doc.Add(tableDatos);


                medCols = new float[] { .35f, .01f, .64f };
                tableDatos = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);

                tableDatos.AddCell(HerUtil.celda("Tipo: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.MOTIVO.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                doc.Add(tableDatos);

                medCols = new float[] { .35f, .01f, .64f };
                tableDatos = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);

                tableDatos.AddCell(HerUtil.celda("Oportunidad: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda("Antes de la Extracción", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                doc.Add(tableDatos);

                doc.Add(new Paragraph("\n"));

                medCols = new float[] { .30f };
                tableTituloBloque = HerUtil.constructorTabla(1, page, medCols, page.Width - 90);

                tableTituloBloque.AddCell(HerUtil.celda("Resultados", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableTituloBloque.AddCell(HerUtil.celda("", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                doc.Add(tableTituloBloque);
                doc.Add(new Paragraph("\n"));

                if (elementListado.ListSupervision.Count > 0)
                {
                    tableIncisos = new PdfPTable(7); //Declaramos el objeto PdfPTable y especificamos el ancho de las columas a utilizar
                    tableIncisos.WidthPercentage = 80;//Le damos un tamaño a la tabla, esta tomara en porcierto el ancho que ucupara
                    tableIncisos.TotalWidth = page.Width - 90; //Le damos el tamaño de la tabla
                    tableIncisos.LockedWidth = true;//Decimos que se bloque el tamaño de la tabla, esto para que no creesca dependiendo de la información
                                                    //float[] widths2 = new float[] { .2f, .4f, .5f, .3f, .3f, .3f, .3f, .3f }; //Declaramos un array con los tamaños de nuestras columnas deben de coincidir con el tamaño de columnas
                    float[] widths = new float[] { .03f, .42f, .11f, .11f, .11f, .11f, .11f }; //Declaramos un array con los tamaños de nuestras columnas deben de coincidir con el tamaño de columnas

                    tableIncisos.SetWidths(widths);
                    tableIncisos.AddCell(HerUtil.celda("N°", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
                    tableIncisos.AddCell(HerUtil.celda("Especies", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
                    tableIncisos.AddCell(HerUtil.celda("N° árboles supervisados", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
                    tableIncisos.AddCell(HerUtil.celda("N° árboles inexistentes", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
                    tableIncisos.AddCell(HerUtil.celda("% árboles inexistentes", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
                    tableIncisos.AddCell(HerUtil.celda("N° que difieren de la especie consignada en el plan de manejo", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
                    tableIncisos.AddCell(HerUtil.celda("% que difieren de la especie consignada en el plan de manejo", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
                    foreach (CEntidad var in elementListado.ListSupervision)
                    {
                        i = i + 1;
                        tableIncisos.AddCell(HerUtil.celda(i.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                        tableIncisos.AddCell(HerUtil.celda(var.DESCRIPCION, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Cursiva"));
                        tableIncisos.AddCell(HerUtil.celda(var.NUMERO_ARBOLES.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                        tableIncisos.AddCell(HerUtil.celda(var.INEX.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                        tableIncisos.AddCell(HerUtil.celda(var.PORCENTAJE_INEX.ToString() + " %", 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                        tableIncisos.AddCell(HerUtil.celda(var.COINC.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                        tableIncisos.AddCell(HerUtil.celda(var.PORCENT_INJUST_MOVIL.ToString() + " %", 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                    }
                    doc.Add(tableIncisos);
                    medCols = new float[] { .30f };
                    tableTituloBloque = HerUtil.constructorTabla(1, page, medCols, page.Width - 90);

                    tableTituloBloque.AddCell(HerUtil.celda("Fuente: Informe de Supervisión N° " + elementListado.NUM_INFORME, 1, 1, 8, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                    doc.Add(tableTituloBloque);
                }
                else
                {
                    doc.Add(new Paragraph("\n"));
                }
                doc.Add(new Paragraph("\n"));

                /*medCols = new float[] { .30f };
                tableTituloBloque = HerUtil.constructorTabla(1, page, medCols, page.Width - 90);

                tableTituloBloque.AddCell(HerUtil.celda("Conclusiones", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableTituloBloque.AddCell(HerUtil.celda("", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                doc.Add(tableTituloBloque);
                doc.Add(new Paragraph("\n"));

                tableIncisos = new PdfPTable(1); //Declaramos el objeto PdfPTable y especificamos el ancho de las columas a utilizar
                tableIncisos.WidthPercentage = 80;//Le damos un tamaño a la tabla, esta tomara en porcierto el ancho que ucupara
                tableIncisos.TotalWidth = page.Width - 90; //Le damos el tamaño de la tabla
                tableIncisos.LockedWidth = true;//Decimos que se bloque el tamaño de la tabla, esto para que no creesca dependiendo de la información
                                                //float[] widths2 = new float[] { .2f, .4f, .5f, .3f, .3f, .3f, .3f, .3f }; //Declaramos un array con los tamaños de nuestras columnas deben de coincidir con el tamaño de columnas
                float[] widths2 = new float[] { .100f }; //Declaramos un array con los tamaños de nuestras columnas deben de coincidir con el tamaño de columnas

                tableIncisos.SetWidths(widths2);*/
                //Para convertir el html almacenado en texto plano
                //  string CONCLUCION = System.Text.RegularExpressions.Regex.Replace(elementListado.DESCRIPCION, @"</?\w+(\s*([a-zA-Z ]+="".+"")*)*\s*/?>", "",
                /*  System.Text.RegularExpressions.RegexOptions.IgnoreCase).Replace("&nbsp;", "").Replace("&aacute;", "á").Replace("&eacute;", "é").Replace("&iacute;","í").Replace("&oacute;", "ó").Replace("&uacute;", "ú").Replace("&deg;","°");

                tableIncisos.AddCell(HerUtil.celda(CONCLUCION, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Cursiva"));
                doc.Add(tableIncisos);

              */


                medCols = new float[] { .30f };
                tableTituloBloque = HerUtil.constructorTabla(1, page, medCols, page.Width - 90);
                tableTituloBloque.AddCell(HerUtil.celda("Fecha y hora de Consulta: " + DateTime.Now.ToString(), 1, 1, 10, Element.ALIGN_RIGHT, 0, BaseColor.BLACK, "transparent", "Normal"));
                doc.Add(tableTituloBloque);
                doc.Add(new Paragraph("\n"));

                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph("\n"));

                String texto = "Las supervisiones realizadas antes de la extracción, se realizan previa a la corta del árbol, luego de aprobado el plan de manejo; para ello se debe contar con "
                + "la información documentaria proporcionada por la autoridad competente o por el titular del título habilitante.Estas supervisiones tienen como propósito verificar "
                + "la existencia del recurso forestal maderable aprobado; no hace referencia a las acciones de aprovechamiento ejecutadas por el titular posteriormente.Un plan de "
                + "manejo supervisado antes de la extracción, puede ser objeto de una nueva supervisión durante o después del aprovechamiento; los resultados se mostraran en el "
                + "Observatorio OSINFOR. "
                + " Numeral 11.1 del artículo 11° del Reglamento N° 003 - 2017 - OSINFOR, Reglamento para la supervisión de los recursos forestales y de fauna silvestre.";

                medCols = new float[] { .30f };
                tableTituloBloque = HerUtil.constructorTabla(1, page, medCols, page.Width - 90);
                tableTituloBloque.AddCell(HerUtil.celda(texto, 1, 1, 8, Element.ALIGN_JUSTIFIED_ALL, 0, BaseColor.BLACK, "transparent", "Normal"));
                doc.Add(tableTituloBloque);
                doc.Add(new Paragraph("\n"));
                doc.Close();
                HerUtil.agregarMarcaAguaImagen(mapPath + "Descargas\\" + nombreArchivo + "_" + ".pdf", mapPath + "Descargas\\" + nombreArchivo + ".pdf", Server.MapPath("~/Images/Fondos/huella_osinfor_normal.jpg"));

                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("content-disposition", "attachment;filename=" + nombreArchivo + ".pdf");
                Response.ContentType = "application/pdf";
                string rut1 = Server.MapPath("~/Archivos/Descargas/" + nombreArchivo + ".pdf");// @"C:\doc.pdf";
                Response.TransmitFile(rut1);
                Response.End();

            }
            catch (Exception ex)
            {
                //throw ex;
                logger.Error(ex);
                model.mensajeError = "A ocurrido un error ponerse en contacto con el administrador";  //ex.Message.ToString();
                //throw model.mensajeError;
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close();
                }
            }
        }
    }
}