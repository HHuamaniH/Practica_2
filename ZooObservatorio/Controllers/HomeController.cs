using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
//using PagedList;
using System.IO;
using System.Web.Mvc;
using ZooObservatorio.Models;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_Historial_TH;
using CEntidadINF = CapaEntidad.DOC.Ent_INFORME;
using CLogica = CapaLogica.DOC.Log_RHistorial_TH;
using CLogicaINF = CapaLogica.DOC.Log_INFORME;

namespace ZooObservatorio.Controllers
{
    public class HomeController : Controller
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        CLogica oCLogica = new CLogica();
        List<CEntidad> listCEntidad = new List<CEntidad>();
        List<CEntidad> listFiltros = new List<CEntidad>();
        CEntidad oCEntidad = new CEntidad();
        ReporteFauna modelFauna = new ReporteFauna();
        LogFileError encript = new LogFileError();

        // para la lista de fotos
        List<CEntidadINF> listFotosINF = new List<CEntidadINF>();
        CLogicaINF oCLogicaINF = new CLogicaINF();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListFauna()
        {
            this.filtrosListas();
            return View("ListFauna", modelFauna);
            // return RedirectToAction("ListaFauna", "SIGO");

        }

        public void filtrosListas()
        {
            oCEntidad = new CEntidad();
            oCEntidad.BusFormulario = "REPORTE_ZOOBSERBATORIO";
            oCEntidad = oCLogica.logFiltros(oCEntidad);
            modelFauna = (ReporteFauna)Session["modelFauna"];
            if (modelFauna == null)
            {
                modelFauna = new ReporteFauna();
            }
            modelFauna.ListRegion = oCEntidad.ListRegion;
            modelFauna.ListModalidad = oCEntidad.ListModalidad;
            modelFauna.ListReporteFauna = new List<CEntidad>();
            modelFauna.descZoocriadero = "";
            modelFauna.descZoologico = "";
            Session["modelFauna"] = modelFauna; // guardamos el modelo para ser utilizado nuevamente
        }

        public void infoListFauna(String BusCriterio, ReporteFauna modelFauna)
        {
            if (oCEntidad.BusCriterio == "'0000001','0000002'")
            {
                modelFauna.descZoologico = "Los zoológicos son establecimientos para el manejo en cautiverio de fauna silvestre con ambientes especialmente acondicionados para su mantenimiento y exhibición con fines de esparcimiento, educación, difusión cultural, reproducción y conservación o de investigación.(*)";
                modelFauna.descZoocriadero = "Los zoocriaderos son establecimientos que cuentan con ambientes adecuados para el mantenimiento y reproducción de especímenes de fauna silvestre con fines comerciales. Los especímenes reproducidos son de propiedad del titular desde la primera generación, pudiendo ser comercializados por los mismos. (*)";
            }
            if (oCEntidad.BusCriterio == "'0000001'")
            {
                modelFauna.descZoologico = "Los zoológicos son establecimientos para el manejo en cautiverio de fauna silvestre con ambientes especialmente acondicionados para su mantenimiento y exhibición con fines de esparcimiento, educación, difusión cultural, reproducción y conservación o de investigación.(*)";
                modelFauna.descZoocriadero = "";
            }
            if (oCEntidad.BusCriterio == "'0000002'")
            {
                modelFauna.descZoologico = "";
                modelFauna.descZoocriadero = "Los zoocriaderos son establecimientos que cuentan con ambientes adecuados para el mantenimiento y reproducción de especímenes de fauna silvestre con fines comerciales. Los especímenes reproducidos son de propiedad del titular desde la primera generación, pudiendo ser comercializados por los mismos. (*)";
            }
        }

        /// <summary>
        ///  metodo que muestra el detalle de la supervision de TH
        /// </summary>
        /// <param name="hfTHabilitanteCod"></param>
        /// <param name="hfCodInforme"></param>
        /// <param name="hfAnioSup"></param>
        /// <returns>retorna la vista de detalle de la supervision al TH</returns>
        [HttpPost]
        public ActionResult detalle(String hfTHabilitanteCod, String hfCodInforme, String hfAnioSup)
        {
            try
            {
                modelFauna = (ReporteFauna)Session["modelFauna"];
                if (modelFauna == null)
                {
                    modelFauna = new ReporteFauna();
                }
                CEntidad oCEntidadTem = new CEntidad();
                oCEntidadTem.BusCriterio = "THABILITANTE_CODIGO_FAUNA"; //THABILITANTE_CODIGO_EXTERNO
                oCEntidadTem.BusValor = encript.DesEncriptar(hfTHabilitanteCod);
                oCEntidadTem.NUM_POA = 0;
                oCEntidadTem = oCLogica.log_THExternoF(oCEntidadTem);
                DateTime anio = Convert.ToDateTime(encript.DesEncriptar(hfAnioSup));
                oCEntidadTem.ANIO_SUP = anio.Year.ToString();
                /*if (oCEntidadTem.COD_MTIPO == "0000001")
                {*/
                oCEntidadTem.DESCRIPCION = "Especies Mantenidas en cautiverio";
                /* }
                 if (oCEntidadTem.COD_MTIPO == "0000002")
                 {
                     oCEntidadTem.DESCRIPCION = "Especies Reproducidas";
                 }*/
                modelFauna.oCEntidad = oCEntidadTem;
                CEntidad oCEntidadTemp = new CEntidad();
                oCEntidadTemp.BusValor = encript.DesEncriptar(hfCodInforme);// OCEntidadD.COD_THABILITANTE;
                oCEntidadTemp.BusCriterio = oCEntidadTem.COD_MTIPO;
                listCEntidad = new List<CEntidad>();
                listCEntidad = oCLogica.logTHFaunaListEspecie(oCEntidadTemp);
                modelFauna.ListEspecies = listCEntidad;
                CEntidadINF oCEntidadTemp1 = new CEntidadINF();
                oCEntidadTemp1.BusValor = encript.DesEncriptar(hfCodInforme);
                oCEntidadTemp1.BusFormulario = "FOTOS";
                oCEntidadTemp1.BusCriterio = "TODOS";
                listFotosINF = new List<CEntidadINF>();
                listFotosINF = oCLogicaINF.RegMostrar_Informe_fotos_Obs(oCEntidadTemp1);
                modelFauna.ListEspeciesFotos = listFotosINF;
                //para el calculo del ranking
                //
                modelFauna.ranking = rankign(Double.Parse(oCEntidadTem.PORCENTAJE_INEX.ToString()));
                modelFauna.fecha_observ = oCEntidadTem.FECHA_TFFS.ToString();
                Session["modelFauna"] = modelFauna;
                return View("DetalleFauna", modelFauna);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                modelFauna.mensajeError = "A ocurrido un error ponerse en contacto con el administrador";// ex.Message.ToString();
                return View("Error", modelFauna);
            }
        }

        public int rankign(Double puntaje)
        {
            int rank = 0;
            if (puntaje == 10)
            {
                rank = 5;
            }
            if (puntaje >= 8 && puntaje <= 9.5)
            {
                rank = 4;
            }
            if (puntaje >= 6 && puntaje <= 7.5)
            {
                rank = 3;
            }
            if (puntaje >= 4 && puntaje <= 5.5)
            {
                rank = 2;
            }
            if (puntaje >= 2 && puntaje <= 3.5)
            {
                rank = 1;
            }
            if (puntaje >= 0 && puntaje <= 1.5)
            {
                rank = 0;
            }
            return rank;
        }
        /// <summary>
        /// muestra el detalle de titulo habilitande de fauna
        /// </summary>
        /// <param name="COD_THABILITANTE"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult detalleFauna(String CODIGO, String INFORME, String ANIO)
        {
            try
            {
                modelFauna = (ReporteFauna)Session["modelFauna"];
                if (modelFauna == null)
                {
                    modelFauna = new ReporteFauna();
                }
                CEntidad oCEntidadTem = new CEntidad();
                oCEntidadTem.BusCriterio = "THABILITANTE_CODIGO_FAUNA"; //THABILITANTE_CODIGO_EXTERNO
                oCEntidadTem.BusValor = CODIGO;
                oCEntidadTem.NUM_POA = 0;
                oCEntidadTem = oCLogica.log_THExterno(oCEntidadTem);
                DateTime anio = Convert.ToDateTime(ANIO);
                oCEntidadTem.ANIO_SUP = anio.Year.ToString();
                if (oCEntidadTem.COD_MTIPO == "0000001")
                {
                    oCEntidadTem.DESCRIPCION = "Especies Mantenidas en cautiverio";
                }
                if (oCEntidadTem.COD_MTIPO == "0000002")
                {
                    oCEntidadTem.DESCRIPCION = "Especies Reproducidas";
                }
                modelFauna.oCEntidad = oCEntidadTem;
                CEntidad oCEntidadTemp = new CEntidad();
                oCEntidadTemp.BusValor = INFORME;// OCEntidadD.COD_THABILITANTE;
                oCEntidadTemp.BusCriterio = oCEntidadTem.COD_MTIPO;
                listCEntidad = new List<CEntidad>();
                listCEntidad = oCLogica.logTHFaunaListEspecie(oCEntidadTemp);
                modelFauna.ListEspecies = listCEntidad;
                CEntidadINF oCEntidadTemp1 = new CEntidadINF();
                oCEntidadTemp1.BusValor = INFORME;
                oCEntidadTemp1.BusFormulario = "FOTOS";
                oCEntidadTemp1.BusCriterio = "TODOS";
                listFotosINF = new List<CEntidadINF>();
                listFotosINF = oCLogicaINF.RegMostrar_Informe_fotos(oCEntidadTemp1);
                modelFauna.ListEspeciesFotos = listFotosINF;
                Session["modelFauna"] = modelFauna;
                return View("DetalleFauna", modelFauna);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                modelFauna.mensajeError = "A ocurrido un error ponerse en contacto con el administrador";
                //modelFauna.mensajeError = ex.Message.ToString();
                return View("Error", modelFauna);
            }
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
            catch
            {
                cadena = "";
                return cadena;
            }
        }
        /// <summary>
        /// metodo que permite obtener la lista de titulos en la modalidad fauna que seran publicados en el view listFauna
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ListarReporteFauna(String[] modalidades, String[] departamentos)
        {
            try
            {
                modelFauna = (ReporteFauna)Session["modelFauna"];
                if (modelFauna == null)
                {
                    modelFauna = new ReporteFauna();
                }
                oCEntidad = new CEntidad();
                oCEntidad.BusValor = ObtenerCadenaArray(departamentos);
                oCEntidad.BusCriterio = ObtenerCadenaArray(modalidades);
                List<CEntidad> listReporteFauna = new List<CEntidad>();
                listReporteFauna = oCLogica.logTHFaunaList(oCEntidad);
                infoListFauna(oCEntidad.BusCriterio, modelFauna);
                if (listReporteFauna == null)
                {
                    listReporteFauna = new List<CEntidad>();
                }
                if (listReporteFauna.Count > 0)
                {
                    String COD_THABILITANTE = "";
                    for (int i = 0; i < listReporteFauna.Count; i++)
                    {
                        COD_THABILITANTE = COD_THABILITANTE + "," + listReporteFauna[i].COD_THABILITANTE;
                        listReporteFauna[i].NO_EVALUADO = rankign(Double.Parse(listReporteFauna[i].PORCENTAJE_INEX.ToString()));
                        listReporteFauna[i].COD_THABILITANTE = encript.Encriptar(listReporteFauna[i].COD_THABILITANTE);
                        listReporteFauna[i].COD_INFORME = encript.Encriptar(listReporteFauna[i].COD_INFORME);
                        listReporteFauna[i].ANIO_SUP = encript.Encriptar(listReporteFauna[i].ANIO_SUP);

                    }
                    modelFauna.urlGeneral = "https://sisfor.osinfor.gob.pe/visor/geoTHFaunaFilter/" + oCEntidad.BusValor.ToString().Replace("'", "") + "/" + oCEntidad.BusCriterio.Replace("'", "");
                }
                modelFauna.ListReporteFauna = listReporteFauna;
                Session["modelFauna"] = modelFauna;
                return View("TableFauna", modelFauna);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                //modelFauna.mensajeError = "A ocurrido un error ponerse en contacto con el administrador";
                return View("TableFauna", modelFauna);
                // return View("ListFauna", modelFauna);
            }
        }

        [HttpGet]
        public ActionResult dowloanEcxel()
        {
            try
            {
                modelFauna = (ReporteFauna)Session["modelFauna"];
                if (modelFauna == null)
                {
                    modelFauna = new ReporteFauna();
                }
                if (modelFauna.ListReporteFauna != null)
                {
                    listCEntidad = (List<CEntidad>)modelFauna.ListReporteFauna;
                    if (listCEntidad.Count > 0)
                    {
                        int i = 1;
                        String insertar = "";
                        String RutaReporteSeguimiento = Server.MapPath("~/Archivos/");
                        string nombreFile = "";
                        nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                        string rutaExcel = RutaReporteSeguimiento + nombreFile;
                        System.IO.File.Copy(RutaReporteSeguimiento + "ListaTHFauna.xlsx", rutaExcel); //pues si es mover 
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
                                    insertar = insertar + ",'" + listaInf.NUMERO + "'";
                                    insertar = insertar + ",'" + listaInf.TITULO + "'";
                                    insertar = insertar + ",'" + listaInf.MODALIDAD + "'";
                                    insertar = insertar + ",'" + listaInf.DEPARTAMENTO + "'";
                                    insertar = insertar + ",'" + listaInf.DIRECCION + "'";
                                    insertar = insertar + ",'" + listaInf.NO_EVALUADO.ToString() + "'";
                                    String cadena1 = "";
                                    for (int j = 0; j < listaInf.NO_EVALUADO; j++)
                                    {
                                        cadena1 = cadena1 + "ê";
                                    }
                                    insertar = insertar + ",'" + cadena1 + "'";
                                    cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":H" + (listCEntidad.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                    cmd.ExecuteNonQuery();
                                }

                                //Cerramos la conexión
                                conn.Close();
                            }

                        }

                        Response.Clear();
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.AddHeader("content-disposition", "attachment;filename=ListaEspecies.xlsx");
                        Response.ContentType = "application/xlsx";
                        Response.TransmitFile(Server.MapPath("~/Archivos/" + nombreFile));
                        Response.End();
                    }
                }
                return View("ListFauna", modelFauna);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                modelFauna.mensajeError = "A ocurrido un error ponerse en contacto con el administrador";
                //modelFauna.mensajeError = ex.Message.ToString();
                return View("Error", modelFauna);

            }
        }
    }
}