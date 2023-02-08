using HistorialTH.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_Historial_TH;
using CLogica = CapaLogica.DOC.Log_RHistorial_TH;

namespace HistorialTH.Controllers
{
    public class HomeController : Controller
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        public static int index;
        public HistorialModel model = new HistorialModel();
        private CLogica oCLogica = new CLogica();
        public ActionResult Index()
        {
            model = new HistorialModel();
            Session["model"] = model;
            return View("Index", model);
        }
        [HttpPost]
        public ActionResult detalle(string hfTHabilitanteCod, string txtNumContrato)
        {
            try
            {
                model = (HistorialModel)Session["model"];
                if (model != null)
                {
                    model = new HistorialModel();
                }
                CEntidad oCEntidadTem = new CEntidad();
                if (hfTHabilitanteCod != "")
                {
                    //realizamos la busqueda del titulo
                    oCEntidadTem.BusCriterio = "THABILITANTE_CODIGO_EXTERNO";
                    oCEntidadTem.BusValor = hfTHabilitanteCod;
                }
                else if (txtNumContrato != "")
                {
                    oCEntidadTem.BusCriterio = "THABILITANTE_NUMERO_EXTERNO";
                    oCEntidadTem.BusValor = txtNumContrato;
                }
                oCEntidadTem.NUM_POA = 0;
                oCEntidadTem = oCLogica.log_THExterno(oCEntidadTem);
                model.oCEntidad = oCEntidadTem;
                if (oCEntidadTem.COD_THABILITANTE != null)
                {
                    //listado de POA
                    oCEntidadTem = new CEntidad();
                    List<CEntidad> ListPOA = new List<CEntidad>();
                    oCEntidadTem.BusValor = model.oCEntidad.COD_THABILITANTE;
                    oCEntidadTem.BusCriterio = "THABILITANTE_EXTERNO_2"; //THABILITANTE_EXTERNO_2 HISTORIAL_DETALLE
                    oCEntidadTem.NUM_POA = 0;
                    ListPOA = oCLogica.log_THPOAExterno(oCEntidadTem);
                    if (ListPOA.Count > 0)
                    {
                        model.Descripcion = "POA APROBADOS";
                        model.Tipo = "MADERABLE";
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
                        model.Tipo = "NOMADERABLE";
                    }
                    model.listPOA = ListPOA;

                    Session["model"] = model;
                    auditoriaReporte("Historial Titulo Habilitante", "0000044");
                    return View("Reporte_Historial_TH", model);
                }
                else
                {
                    return View("Index", model);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                model.mensajeError = "A ocurrido un error ponerse en contacto con el administrador";  //ex.Message.ToString();
                //model.mensajeError = ex.Message.ToString();
                return View("Close", model);
            }
        }

        /// <summary>
        /// Metodo para autocompletar la caja de texto con los parametros name: nombre a buscar, opciones si es por titular
        /// o numero de contrato
        /// </summary>
        /// <param name="name"></param>
        /// <param name="opcion"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetTHName(string name, string opcion)
        {
            List<string> empResult = new List<string>();
            //SIGO_Reporte_Historial_TH_Externo Externo = new SIGO_Reporte_Historial_TH_Externo();
            empResult = buscarTHabilitante(name, opcion);
            return Json(empResult);
            //return View();
        }

        /// <summary>
        /// metodo para la busqueda autocompletado 16/08/2017
        /// </summary>
        /// <param name="BusValor"></param>
        /// <param name="rbopcion"></param>
        /// <returns></returns>
        public static List<String> buscarTHabilitante(String BusValor, String rbopcion)
        {
            List<string> Busqueda = new List<string>();
            CEntidad oCEntidad = new CEntidad();
            CLogica oCLogica = new CLogica();
            String BusCriterio = "";

            if (rbopcion == "titular")
            {
                BusCriterio = "TH_TITULAR";
                oCEntidad.BusCriterio = BusCriterio;
                oCEntidad.BusValor = BusValor;
                oCEntidad.NUM_POA = 0;
                List<CEntidad> listNum = new List<CEntidad>();
                listNum = oCLogica.log_Numero_TH(oCEntidad);
                if (listNum.Count > 0)
                {
                    Busqueda = new List<string>();

                    for (int i = 0; i < listNum.Count; i++)
                    {
                        Busqueda.Add(string.Format("{0}|{1}", listNum[i].COD_THABILITANTE.ToString(), listNum[i].TITULAR.ToString()));
                    }
                }
            }
            if (rbopcion == "titulo")
            {
                BusCriterio = "TH_NUMERO";
                oCEntidad.BusCriterio = BusCriterio;
                oCEntidad.BusValor = BusValor;
                oCEntidad.NUM_POA = 0;
                List<CEntidad> listNum = new List<CEntidad>();
                listNum = oCLogica.log_Numero_TH(oCEntidad);
                if (listNum.Count > 0)
                {
                    Busqueda = new List<string>();

                    for (int i = 0; i < listNum.Count; i++)
                    {
                        Busqueda.Add(string.Format("{0}|{1}", listNum[i].COD_THABILITANTE.ToString(), listNum[i].TITULO.ToString()));
                    }
                }
            }

            return Busqueda;
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
                model = (HistorialModel)Session["model"];
                if (model == null)
                {
                    model = new HistorialModel();
                }
                CEntidad oCEntidadTemp = new CEntidad();
                oCEntidadTemp.BusValor = COD_THABILITANTE;
                oCEntidadTemp.BusCriterio = "ESPECIE_DETALLE";
                oCEntidadTemp.NUM_POA = Int32.Parse(NUM_POA);
                List<CEntidad> listEspecie = new List<CEntidad>();
                listEspecie = oCLogica.log_Especies_Detalle(oCEntidadTemp);
                model.listEspecies = listEspecie;
                Session["model"] = model;
                auditoriaReporte("Buscar Especies Historial Thabilitante", "0000044");
                return View("TableEspecies", model);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                model.mensajeError = "A ocurrido un error ponerse en contacto con el administrador";  //ex.Message.ToString();
                //model.mensajeError = ex.Message.ToString();
                return View("Close", model);
            }
        }

        [HttpGet]
        public ActionResult verPDF(String CODIGO)
        {
            try
            {
                model = (HistorialModel)Session["model"];
                if (model == null)
                {
                    model = new HistorialModel();
                }
                int ID_REGISTRO = Int32.Parse(CODIGO);
                generarPDF(ID_REGISTRO);
                Session["model"] = model;
                auditoriaReporte("Descargar PDF", "0000044");
                return View("DetalleInfractores", model);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                model.mensajeError = "A ocurrido un error ponerse en contacto con el administrador";  //ex.Message.ToString();
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
                wsObservatorio.WSObservatorioSoapClient ws = new wsObservatorio.WSObservatorioSoapClient();
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
                model.mensajeError = "A ocurrido un error ponerse en contacto con el administrador";  //ex.Message.ToString();
                throw ex;
            }

        }

    }
}