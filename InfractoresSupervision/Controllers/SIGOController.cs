using Herramienta;
using InfractoresSupervision.Models;
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

namespace InfractoresSupervision.Controllers
{
    public class SIGOController : Controller
    {
        CLogica oCLogica = new CLogica();
        List<CEntidad> listCEntidad = new List<CEntidad>();
        List<CEntidad> listFiltros = new List<CEntidad>();
        CEntidad oCEntidad = new CEntidad();
        InformeModel model = new InformeModel();
        Utilitarios HerUtil = new Utilitarios();

        //
        // GET: /SIGO/

        public ActionResult Index()
        {
            filtrosListas();
            return View("Index", model);
        }

        /// <summary>
        /// metodo para el llenado de los filtros de region y modalidades
        /// </summary>
        public void filtrosListas()
        {
            oCEntidad = new CEntidad();
            oCEntidad.BusFormulario = "REPORTE_INFRACTORES";
            oCEntidad = oCLogica.logFiltros(oCEntidad);
            model = (InformeModel)Session["model"];
            if (model == null)
            {
                model = new InformeModel();
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
            catch
            {
                cadena = "";
                return cadena;
            }
        }

        /// <summary>
        /// metodo que realiza la busqueda de los informes de supervision con proceso concluido
        /// </summary>
        /// <param name="modalidades"></param>
        /// <param name="departamentos"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ListInformes(String[] modalidades, String[] departamentos)
        {
            try
            {
                model = (InformeModel)Session["model"];
                if (model == null)
                {
                    model = new InformeModel();
                }
                oCEntidad = new CEntidad();
                oCEntidad.BusValor = ObtenerCadenaArray(departamentos);
                oCEntidad.BusCriterio = ObtenerCadenaArray(modalidades);
                listCEntidad = new List<CEntidad>();
                listCEntidad = oCLogica.log_TH_InfraccionesSup(oCEntidad);
                //infoListFauna(oCEntidad.BusCriterio, modelFauna);
                if (listCEntidad == null)
                {
                    listCEntidad = new List<CEntidad>();
                }
                model.fecha = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy");
                model.ListInfractores = listCEntidad;
                Session["model"] = model;
                auditoriaReporte("Buscar", "0000045");
                return View("TableSupervisiones", model);
            }
            catch (Exception ex)
            {
                model.mensajeError = ex.Message.ToString();
                return View("Close", model);
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
                model = (InformeModel)Session["model"];
                if (model == null)
                {
                    model = new InformeModel();
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
                        System.IO.File.Copy(RutaReporteSeguimiento + "ListaInfractoresSup.xlsx", rutaExcel);
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
                                    insertar = insertar + ",'" + listaInf.consultor + "'";
                                    insertar = insertar + ",'" + listaInf.TITULO + "'";
                                    insertar = insertar + ",'" + listaInf.MODALIDAD + "'";
                                    insertar = insertar + ",'" + listaInf.DEPARTAMENTO + "'";
                                    insertar = insertar + ",'" + listaInf.PROVINCIA + "'";
                                    insertar = insertar + ",'" + listaInf.DISTRITO + "'";

                                    insertar = insertar + ",'" + listaInf.NUMERO.Replace("'", "") + "'";
                                    // lblMensaje.Text = insertar;
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
                model.mensajeError = ex.Message.ToString();
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
                model = (InformeModel)Session["model"];
                if (model == null)
                {
                    model = new InformeModel();
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
                        auditoriaReporte("Descargar PDF", "0000045");
                        return View("Index", model);

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
                    model.mensajeError = "documento no encontrado";
                    return View("Close", model);// en caso de existir un error cerrar la pestaña
                }
            }
            catch (Exception ex)
            {
                model.mensajeError = ex.Message.ToString();
                return View("Close", model);// en caso de existir un error cerrar la pestaña
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
