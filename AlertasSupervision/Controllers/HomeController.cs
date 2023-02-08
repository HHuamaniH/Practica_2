using CapaEntidad.DOC;
using CapaLogica.DOC;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace AlertasSupervision.Controllers
{
    public class HomeController : Controller
    {
        private Log_RHistorial_TH logAuditoria = new Log_RHistorial_TH();
        public ActionResult Index()
        {
            Log_REPORTE_GENERAL log = new Log_REPORTE_GENERAL();
            var model = log.AlertaSupervision();
            ViewBag.fecha = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy");
            auditoriaReporte("Buscar", "0000052");
            return View(model);
        }
        [HttpGet]
        public ActionResult DownloadAlerta()
        {
            string nombreFile = "";
            String RutaReporteSeguimiento = Server.MapPath("~/Archivos/");
            Log_REPORTE_GENERAL log = new Log_REPORTE_GENERAL();
            var model = log.AlertaSupervision();
            if (model != null)
            {
                if (model.Count() > 0)
                {
                    int i = 1;
                    String insertar = "";


                    nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = RutaReporteSeguimiento + nombreFile;
                    System.IO.File.Copy(RutaReporteSeguimiento + "AlertaSupervision.xlsx", rutaExcel);
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
                            foreach (var listaInf in model)
                            {
                                insertar = "";
                                insertar = "'" + listaInf.TITULAR.Replace("'", "’") + "'";
                                insertar = insertar + ",'" + listaInf.TITULO + "'";
                                insertar = insertar + ",'" + listaInf.MODALIDAD + "'";
                                insertar = insertar + ",'" + listaInf.DEPARTAMENTO + "'";
                                insertar = insertar + ",'" + listaInf.PROVINCIA + "'";
                                insertar = insertar + ",'" + listaInf.DISTRITO + "'";
                                // insertar = insertar + ",'" + listaInf.NUM_POA + "'";
                                insertar = insertar + ",'" + listaInf.POA_RESOLUCION + "'";
                                insertar = insertar + ",'" + listaInf.FECHA_ENVIO_ALERTA + "'";
                                insertar = insertar + ",'" + Convert.ToDecimal(listaInf.VOLINJUS) + "'";
                                insertar = insertar + ",'" + listaInf.RES_MC_ANT_PAU + "'";
                                // lblMensaje.Text = insertar;
                                cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":J" + (model.Count() + 1).ToString() + "] VALUES (" + insertar + ")";
                                cmd.ExecuteNonQuery();
                            }
                            //Cerramos la conexión
                            conn.Close();
                        }

                    }
                }
            }
            // auditoriaReporte("Descargar Excel", "0000045");
            // return View("Index", model);
            string FilePath = Server.MapPath("~/Archivos/") + nombreFile;
            auditoriaReporte("Descargar Excel", "0000052");
            return new BinaryContentResult
            {
                FileName = "Alerta.xlsx",
                ContentType = "application/octet-stream",
                FilePath = FilePath,
                Content = System.IO.File.ReadAllBytes(FilePath)
            };

        }

        public ActionResult DescargarIntegracionSIADO(string fileName, string origen)
        {
            string pathRepo = "";
            switch (origen)
            {
                case "SIADO-REGION":
                    pathRepo = Server.MapPath("~/Ruta_SIADO_Region/");
                    break;
                case "SIADO":
                    pathRepo = Server.MapPath("~/Ruta_SIADO/");
                    break;
                case "SITD":
                    pathRepo = Server.MapPath("~/Ruta_SITD/");
                    break;
                case "SIGO":
                    pathRepo = Server.MapPath("~/Ruta_REPO_SIGO/");
                    break;
            }

            string FilePath = pathRepo + fileName + ".pdf";
            if (System.IO.File.Exists(FilePath))
            {
                auditoriaReporte("Descargar Doc Siado", "0000052");
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
        public void auditoriaReporte(String action, String cod_formulario)
        {
            Ent_Reporte_Historial_TH oCEntidadTemp = new Ent_Reporte_Historial_TH();
            oCEntidadTemp.COD_ACCION = "";
            oCEntidadTemp.ACCION = action;
            oCEntidadTemp.COD_FORMULARIO = cod_formulario;
            oCEntidadTemp.OUTPUTPARAM01 = "";
            oCEntidadTemp.IP = Request.UserHostAddress;
            oCEntidadTemp.HOSTNAME = Request.UserHostName;
            String OUTPUTPARAM = logAuditoria.LogAuditoria(oCEntidadTemp);
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