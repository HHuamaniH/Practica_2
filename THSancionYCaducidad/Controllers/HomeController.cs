using Herramienta;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
//importaciones para la descarga de archivo
using System.Data.OleDb;
using System.IO;
using System.Web.Configuration;
using System.Web.Mvc;
using THSAncionYCaducidad.Models;

using CEntidad = CapaEntidad.DOC.Ent_Reporte_Historial_TH;
//importaciones de las capas de datos y entidad
using CLogica = CapaLogica.DOC.Log_RHistorial_TH;

namespace THSancionYCaducidad.Controllers
{
    public class HomeController : Controller
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        CLogica oCLogica = new CLogica();
        List<CEntidad> listCEntidad = new List<CEntidad>();
        List<CEntidad> listFiltros = new List<CEntidad>();
        CEntidad oCEntidad = new CEntidad();
        InfractoresModel model = new InfractoresModel();
        Utilitarios HerUtil = new Utilitarios();

        //
        // GET: /SIGO/

        public ActionResult Index()
        {
            filtrosListas();
            return View("ListInfractores", model);
        }

        /// <summary>
        /// metodo para el llenado de los filtros de region y modalidades
        /// </summary>
        public void filtrosListas()
        {
            oCEntidad = new CEntidad();
            oCEntidad.BusFormulario = "REPORTE_INFRACTORES";
            oCEntidad = oCLogica.logFiltros(oCEntidad);
            model = (InfractoresModel)Session["model"];
            if (model == null)
            {
                model = new InfractoresModel();
            }
            model.ListRegion = oCEntidad.ListRegion;
            model.ListModalidad = oCEntidad.ListModalidad;
            Session["model"] = model; // guardamos el modelo para ser utilizado nuevamente
        }

        /// <summary>
        /// metodo para obtner los valores del arreglo de los checklist departamentos y modalidades
        /// </summary>
        /// <param name="array"></param>
        public String ObtenerCadenaArray(String[] array)
        {
            String cadena;
            try
            {
                cadena = "";
                for (int i = 0; i < array.Length; i++)
                {
                    cadena = cadena + "'" + array[i].ToString() + "'" + ",";
                }
                return cadena.TrimEnd(',');
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                // modelFauna.mensajeError = "A ocurrido un error ponerse en contacto con el administrador";// ex.Message.ToString();
                cadena = "";
                return cadena;
            }
        }

        [HttpPost]
        public ActionResult ListInfractores(String[] modalidades, String[] departamentos)
        {
            try
            {
                model = (InfractoresModel)Session["model"];
                if (model == null)
                {
                    model = new InfractoresModel();
                }
                oCEntidad = new CEntidad();
                oCEntidad.BusValor = ObtenerCadenaArray(departamentos);
                oCEntidad.BusCriterio = ObtenerCadenaArray(modalidades);
                oCEntidad.V_MESES =  int.Parse(WebConfigurationManager.AppSettings["MesesTH"]);
                listCEntidad = new List<CEntidad>();
                listCEntidad = oCLogica.log_TH_Infracciones(oCEntidad);
                //infoListFauna(oCEntidad.BusCriterio, modelFauna);
                if (listCEntidad == null)
                {
                    listCEntidad = new List<CEntidad>();
                }
                model.fecha = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy");
                model.ListInfractores = listCEntidad;
                Session["model"] = model;
                ViewBag.urlObservatorio = WebConfigurationManager.AppSettings["urlObservatorio"];
                auditoriaReporte("Buscar", "0000042");
                return View("TableInfractores", model);
            }
            catch (Exception)
            {
                //logger.Error(ex);
                model.mensajeError = "A ocurrido un error ponerse en contacto con el administrador";// ex.Message.ToString();
                return View("TableInfractores", model);
                // return View("ListFauna", modelFauna);
            }
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
                model = (InfractoresModel)Session["model"];
                if (model == null)
                {
                    model = new InfractoresModel();
                }
                if (model.ListInfractores != null)
                {
                    listCEntidad = (List<CEntidad>)model.ListInfractores;
                    if (listCEntidad.Count > 0)
                    {
                        int i = 1;
                        String insertar = "";
                        String RutaReporteSeguimiento = Server.MapPath("~/Archivos/");
                        string nombreFile = "";
                        nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                        string rutaExcel = RutaReporteSeguimiento + nombreFile;
                        System.IO.File.Copy(RutaReporteSeguimiento + "ListaInfractores.xlsx", rutaExcel);
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
                                    insertar = "'" + listaInf.ANIO_SUP + "'";
                                    insertar = insertar + ",'" + listaInf.TITULAR.Replace("'", "’") + "'";
                                    insertar = insertar + ",'" + listaInf.consultor + "'";
                                    insertar = insertar + ",'" + listaInf.TITULO + "'";
                                    insertar = insertar + ",'" + listaInf.MODALIDAD + "'";
                                    insertar = insertar + ",'" + listaInf.DEPARTAMENTO + "'";
                                    insertar = insertar + ",'" + listaInf.PROVINCIA + "'";
                                    insertar = insertar + ",'" + listaInf.DISTRITO + "'";
                                    insertar = insertar + ",'" + listaInf.INFRACCIONES_TER + "'";
                                    insertar = insertar + ",'" + listaInf.RD_termino + "'";
                                    insertar = insertar + ",'" + listaInf.CADUCIDAD_RDTERMINO + "'";
                                    insertar = insertar + ",'" + listaInf.SANCION + "'";
                                    insertar = insertar + ",'" + listaInf.MULTA_MONTO + "'";
                                    insertar = insertar + ",'" + listaInf.AREA_O.ToString() + "'";
                                    insertar = insertar + ",'" + listaInf.OBSERVACIONES.ToString() + "'";
                                    cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":O" + (listCEntidad.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                    cmd.ExecuteNonQuery();
                                }

                                //Cerramos la conexión
                                conn.Close();
                            }

                        }

                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.AddHeader("content-disposition", "attachment;filename=ListaInfractores.xlsx");
                        Response.ContentType = "application/xlsx";
                        Response.TransmitFile(Server.MapPath("~/Archivos/" + nombreFile));
                        Response.End();
                    }
                }
                auditoriaReporte("Descargar Excel", "0000042");
                return View("ListInfractores", model);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                model.mensajeError = "A ocurrido un error ponerse en contacto con el administrador";// ex.Message.ToString();
                return View("Close", model);

            }
        }

        /// <summary>
        /// Metodo para descargar los PDF de las resoluciones directorales
        /// </summary>
        /// <param name="COD_DOC"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult dowloandPDF(String COD_DOC)
        {
            try
            {
                String RutaRepositorio = "";
                String RutaSIADO = "~/Ruta_SIADO/";
                //COD_DOC = "121101007450001";
                model = (InfractoresModel)Session["model"];
                if (model == null)
                {
                    model = new InfractoresModel();
                }
                if (COD_DOC != "")
                {
                    RutaRepositorio = Server.MapPath(RutaSIADO);
                    String strFileName = HerUtil.revisaArchivos(RutaRepositorio, COD_DOC.Trim() + ".*");
                    if (strFileName.Trim() != "")
                    {
                        Response.Clear();
                        Response.ContentType = "application/octet-stream";
                        Response.ContentEncoding = System.Text.Encoding.Default;
                        Response.Charset = "";
                        string FilePath = RutaRepositorio + strFileName;
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + strFileName);
                        Response.TransmitFile(FilePath);
                        Response.Flush();
                        Response.End();
                        Response.Close();
                        auditoriaReporte("Descargar PDF", "0000042");
                        return View("ListInfractores", model);

                    }
                    else
                    {
                        return View("Close", model);// en caso de existir un error cerrar la pestaña
                        throw new Exception("No existe la ruta de descarga");
                    }
                    //String strFileName = HerUtil.revisaArchivos(RutaSIADO, Lista[ListIndex].FIC_SIADO.ToString().Trim() + ".*");

                }
                else
                {
                    return View("Close", model);// en caso de existir un error cerrar la pestaña
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                model.mensajeError = ex.Message.ToString(); //"A ocurrido un error ponerse en contacto con el administrador";// ex.Message.ToString();
                return View("Close", model);// en caso de existir un error cerrar la pestaña
            }

        }

        /// <summary>
        /// metodo para visualizar el detalle de infractores
        /// </summary>
        /// <param name="hfTHabilitanteCod"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult detalle(String hfTHabilitanteCod)
        {
            try
            {
                model = (InfractoresModel)Session["model"];
                if (model == null)
                {
                    model = new InfractoresModel();
                }
                CEntidad oCEntidadTem = new CEntidad();
                oCEntidadTem.BusCriterio = "THABILITANTE_CODIGO_EXTERNO";
                oCEntidadTem.BusValor = hfTHabilitanteCod;
                oCEntidadTem.NUM_POA = 0;
                oCEntidadTem = oCLogica.log_THExterno(oCEntidadTem);
                model.oCEntidad = oCEntidadTem;
                //listado de POA
                oCEntidadTem = new CEntidad();
                List<CEntidad> ListPOA = new List<CEntidad>();
                oCEntidadTem.BusValor = hfTHabilitanteCod;
                oCEntidadTem.BusCriterio = "THABILITANTE_EXTERNO_2";
                oCEntidadTem.NUM_POA = 0;
                ListPOA = oCLogica.log_THPOAExterno(oCEntidadTem);
                if (ListPOA.Count > 0)
                {
                    model.Descripcion = "POA APROBADOS";
                    model.tipo = "MADERABLE";
                    for (int i = 0; i < ListPOA.Count; i++)
                    {
                        if (ListPOA[i].descripFin == "R")
                        {
                            ListPOA[i].BTN_STYLE_CLASS = "btn btn-block btn-danger";
                            ListPOA[i].BTN_NAME = "Rojo";
                            ListPOA[i].BTN_VISIBLE = "visible";
                        }
                        if (ListPOA[i].descripFin == "V")
                        {
                            ListPOA[i].BTN_STYLE_CLASS = "btn btn-block btn-success";
                            ListPOA[i].BTN_NAME = "Verde";
                            ListPOA[i].BTN_VISIBLE = "visible";
                        }
                        else if (ListPOA[i].descripFin == "NV" || ListPOA[i].descripFin == "NR" || ListPOA[i].descripFin == "N")
                        {
                            ListPOA[i].BTN_STYLE_CLASS = "btn btn-block btn-primary";
                            ListPOA[i].BTN_NAME = "";
                            ListPOA[i].BTN_VISIBLE = "hidden";
                        }
                    }
                }
                else
                {
                    oCEntidadTem = new CEntidad();
                    oCEntidadTem.BusValor = hfTHabilitanteCod;
                    oCEntidadTem.BusCriterio = "THABILITANTE_NO_MADERABLE";
                    oCEntidadTem.NUM_POA = 0;
                    //ListPOA = oCLogica.log_TH_No_Maderables(oCEntidadTem);
                    model.Descripcion = "SUPERVISIONES";
                    model.tipo = "NOMADERABLE";
                }
                model.ListPOA = ListPOA;
                Session["model"] = model;
                auditoriaReporte("Buscar Detalle", "0000042");
                return View("DetalleInfractores", model);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                model.mensajeError = "A ocurrido un error ponerse en contacto con el administrador";// ex.Message.ToString();
                //model.mensajeError = ex.Message.ToString();
                return View("Close", model);
            }

        }


        /// <summary>
        /// metodo para descargar el archivo PDF
        /// </summary>
        /// <param name="CODIGO"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult verPDF(String CODIGO)
        {
            try
            {
                model = (InfractoresModel)Session["model"];
                if (model == null)
                {
                    model = new InfractoresModel();
                }
                int ID_REGISTRO = Int32.Parse(CODIGO);
                generarPDF(ID_REGISTRO);
                Session["model"] = model;
                auditoriaReporte("Descargar PDF", "0000042");
                return View("DetalleInfractores", model);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                model.mensajeError = "A ocurrido un error ponerse en contacto con el administrador";// ex.Message.ToString();
                //model.mensajeError = ex.Message.ToString();
                return View("Close");
            }
        }

        /// <summary>
        /// metodo para generar la descarga
        /// </summary>
        /// <param name="idRegistro"></param>
        protected void generarPDF(int idRegistro)
        {
            try
            {
                string valCadena = "";
                WSObservatorio.WSObservatorioSoapClient ws = new WSObservatorio.WSObservatorioSoapClient();
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
                logger.Error(ex);
                //model.mensajeError = "A ocurrido un error ponerse en contacto con el administrador";// ex.Message.ToString();
                throw ex;
            }

        }
        /// <summary>
        /// metodo para vizualizar especies
        /// </summary>
        /// <param name="NUM_POA"></param>
        /// <param name="COD_THABILITANTE"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult verEspecies(string NUM_POA, string COD_THABILITANTE)
        {
            try
            {
                model = (InfractoresModel)Session["model"];
                if (model == null)
                {
                    model = new InfractoresModel();
                }
                CEntidad oCEntidadTemp = new CEntidad();
                oCEntidadTemp.BusValor = COD_THABILITANTE;
                oCEntidadTemp.BusCriterio = "ESPECIE_DETALLE";
                oCEntidadTemp.NUM_POA = Int32.Parse(NUM_POA);
                List<CEntidad> listEspecie = new List<CEntidad>();
                listEspecie = oCLogica.log_Especies_Detalle(oCEntidadTemp);
                model.ListEspecie = listEspecie;
                auditoriaReporte("Buscar Especie", "0000042");
                return View("TableEspecies", model);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                model.mensajeError = "A ocurrido un error ponerse en contacto con el administrador";// ex.Message.ToString();
                //model.mensajeError = ex.Message.ToString();
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
    }
}