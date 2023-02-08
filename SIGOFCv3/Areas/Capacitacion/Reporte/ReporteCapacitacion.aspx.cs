using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.IO;
using CEntidad = CapaEntidad.DOC.Ent_CAPACITACION;
using CLogica = CapaLogica.DOC.Log_CAPACITACION;

namespace SIGOFCv3.Areas.Capacitacion.Reporte
{
    public partial class ReporteCapacitacion : System.Web.UI.Page
    {
        string Reporte = string.Empty;
        string Archivo = string.Empty;
        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);

            if (!IsPostBack)
                LoadDatos();

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadDatos()
        {
            if (Request.QueryString["Reporte"] != null)
            {
                Reporte = Request.QueryString["reporte"].ToString();
                List<CEntidad> cm1 = new List<CEntidad>();
                List<CEntidad> cm2 = new List<CEntidad>();
                List<CEntidad> cm3 = new List<CEntidad>();
                List<CEntidad> cm4 = new List<CEntidad>();
                List<CEntidad> cm5 = new List<CEntidad>();
                List<CEntidad> cm6 = new List<CEntidad>();
                List<CEntidad> cm7 = new List<CEntidad>();
                List<CEntidad> cm8 = new List<CEntidad>();
                List<CEntidad> cm9 = new List<CEntidad>();
                List<CEntidad> cm10 = new List<CEntidad>();
                List<CEntidad> cm11 = new List<CEntidad>();
                List<CEntidad> cm12 = new List<CEntidad>();
                List<CEntidad> cm13 = new List<CEntidad>();
                List<CEntidad> cm14 = new List<CEntidad>();
                List<CEntidad> cm15 = new List<CEntidad>();
                List<CEntidad> cm16 = new List<CEntidad>();
                List<CEntidad> cm17 = new List<CEntidad>();
                List<CEntidad> cm18 = new List<CEntidad>();
                List<CEntidad> cm19 = new List<CEntidad>();
                List<CEntidad> cm20 = new List<CEntidad>();
                CLogica exeCap = new CLogica();
                string CodCapacitacion = System.Web.HttpContext.Current.Session["CodCapacitacion"] as String;
                switch (Reporte)
                {

                    case "1":
                        cm1 = exeCap.ReporteGraficoGenero(CodCapacitacion);
                        cm2 = exeCap.ReporteGraficoCCNN(CodCapacitacion);
                        cm3 = exeCap.ReporteGraficoETNIA(CodCapacitacion);
                        cm4 = exeCap.ReporteGraficoTHAB(CodCapacitacion);
                        cm5 = exeCap.ReporteGraficoCORREO(CodCapacitacion);

                        rv_capacitacion.Reset();
                        rv_capacitacion.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                        rv_capacitacion.LocalReport.ReportPath = Server.MapPath("~/Areas/Capacitacion/Reporte/ReporteGraficoParticipante.rdlc");
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", cm1));
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", cm2));
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet3", cm3));
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet4", cm4));
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet5", cm5));
                        rv_capacitacion.LocalReport.Refresh();

                        break;

                    case "2":
                        cm6 = exeCap.ReporteGraficoNOTA(CodCapacitacion);
                        //cm3 = exeCap.ReporteGraficoPersonaCCNN(CodCapacitacion);
                        rv_capacitacion.Reset();
                        rv_capacitacion.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                        rv_capacitacion.LocalReport.ReportPath = Server.MapPath("~/Areas/Capacitacion/Reporte/ReporteGraficoEvaluacion.rdlc");
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", cm6));
                        //rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetrRGPCCNN", cm3));

                        rv_capacitacion.LocalReport.Refresh();
                        break;

                    case "3":
                        cm7 = exeCap.ReporteGraficoENCUESTA(CodCapacitacion);
                        //cm3 = exeCap.ReporteGraficoPersonaCCNN(CodCapacitacion);
                        rv_capacitacion.Reset();
                        rv_capacitacion.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                        rv_capacitacion.LocalReport.ReportPath = Server.MapPath("~/Areas/Capacitacion/Reporte/ReporteGraficoEvaluacionEncuesta.rdlc");
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", cm7));
                        //rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetrRGPCCNN", cm3));

                        rv_capacitacion.LocalReport.Refresh();
                        break;

                    case "4":
                        cm8 = exeCap.ReporteMEMORIA(CodCapacitacion);
                        cm9 = exeCap.ReporteMEMORIAPN(CodCapacitacion);
                        cm10 = exeCap.ReporteGraficoGeneroMemoria(CodCapacitacion);
                        cm11 = exeCap.ReporteGraficoCCNNMemoria(CodCapacitacion);
                        cm12 = exeCap.ReporteGraficoETNIAMemoria(CodCapacitacion);
                        cm13 = exeCap.ReporteGraficoTHABMemoria(CodCapacitacion);
                        cm14 = exeCap.ReporteGraficoCORREOMemoria(CodCapacitacion);
                        cm15 = exeCap.ReporteMEMORIAPA(CodCapacitacion);
                        cm16 = exeCap.ReporteMEMORIAPP(CodCapacitacion);
                        cm17 = exeCap.ReporteGraficoENCUESTA_EI(CodCapacitacion);
                        cm18 = exeCap.ReporteGraficoENCUESTA_EF(CodCapacitacion);
                        cm19 = exeCap.ReporteGraficoNOTAMemoria(CodCapacitacion);
                        cm20 = exeCap.ReporteMEMORIAProgramacion(CodCapacitacion);
                        //cm3 = exeCap.ReporteGraficoPersonaCCNN(CodCapacitacion);
                        LocalReport lr = new LocalReport();
                        rv_capacitacion.Reset();
                        rv_capacitacion.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                        rv_capacitacion.LocalReport.ReportPath = Server.MapPath("~/Areas/Capacitacion/Reporte/ReporteMemoria.rdlc");
                        //rv_capacitacion.LocalReport.EnableExternalImages = true;

                        //this.reportViewer1.LocalReport.SetParameters(reportParameter);
                        //ReportParameter paramImagen3 = new ReportParameter();
                        //paramImagen3.Name = "DirectorioLocal";
                        //paramImagen3.Values.Add("file:///" + Directory.GetCurrentDirectory() + @"\");
                        //ReportViewer1.LocalReport.SetParameters(paramImagen3);
                        rv_capacitacion.LocalReport.EnableExternalImages =true;


                        //string DirectorioLocal = new Uri(Server.MapPath("~/Archivos/Archivo_Capacitacion/0001202000000121.png")).AbsoluteUri;
                        string DirectorioLocal = new Uri(Server.MapPath("~/Archivos/Archivo_Capacitacion/")).AbsoluteUri;
                        ReportParameter parameter = new ReportParameter("DirectorioLocal", DirectorioLocal);
                        rv_capacitacion.LocalReport.SetParameters(parameter);



                   //     ReportParameter paramImagen = new ReportParameter();
                  //      paramImagen.Name = "DirectorioLocal";
                        //paramImagen.Values.Add(@"file:///C:\Users\Juan\AppData\Local\Temp\ImagenElegida.png");
                       // paramImagen.Values.Add("file:///" + Directory.GetCurrentDirectory() + @"\");
                  //      paramImagen.Values.Add(Server.MapPath("~/Archivos/Archivo_Capacitacion/0001202000000121.png"));
                  //      rv_capacitacion.LocalReport.SetParameters(paramImagen);
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", cm8));
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet2", cm9));
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet3", cm10));
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet4", cm11));
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet5", cm12));
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet6", cm13));
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet7", cm14));
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet8", cm15));
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet9", cm16));
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet10", cm17));
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet11", cm18));
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet12", cm19));
                        rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet13", cm20));
                        rv_capacitacion.LocalReport.Refresh();
                        //rv_capacitacion.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetrRGPCCNN", cm3));

                        //Warning[] warnings;
                        //string[] streamids;
                        //string mimeType;
                        //string encoding;
                        //string extension;
                        //string filename;

                        //byte[] bytes = rv_capacitacion.LocalReport.Render(
                        //   "Word", null, out mimeType, out encoding,
                        //    out extension,
                        //   out streamids, out warnings);

                        //Random r = new Random();
                        //int aleat = r.Next(1, 9999);
                        ///////////////////////////////////////////////////////////////////
                        //ReportDataSource rd = new ReportDataSource("DataSet1", cm8);
                        //lr.DataSources.Add(rd);
                        //string reportType = "Word";
                        //string mimeType;
                        //string encoding;
                        //string fileNameExtension;

                        //string deviceInfo =

                        //"<DeviceInfo>" +
                        //"  <OutputFormat>" + "Word" + "</OutputFormat>" +
                        //"  <PageWidth>8.5in</PageWidth>" +
                        //"  <PageHeight>11in</PageHeight>" +
                        //"  <MarginTop>0.5in</MarginTop>" +
                        //"  <MarginLeft>1in</MarginLeft>" +
                        //"  <MarginRight>1in</MarginRight>" +
                        //"  <MarginBottom>0.5in</MarginBottom>" +
                        //"</DeviceInfo>";

                        //Warning[] warnings;
                        //string[] streams;
                        //byte[] renderedBytes;


                        //renderedBytes = lr.Render(
                        //    reportType,
                        //    deviceInfo,
                        //    out mimeType,
                        //    out encoding,
                        //    out fileNameExtension,
                        //    out streams,
                        //    out warnings);


                        Warning[] warnings;
                        string[] streamids;
                        string mimeType;
                        string encoding;
                        string extension;
                        string filename;

                        byte[] bytes = rv_capacitacion.LocalReport.Render(
                           "Word", null, out mimeType, out encoding,
                            out extension,
                           out streamids, out warnings);

                        Random r = new Random();
                        int aleat = r.Next(1, 9999);

                        filename = "reporte" + aleat.ToString() + ".doc";
                        Response.ClearHeaders();
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
                        Response.ContentType = mimeType;
                        Response.BinaryWrite(bytes);
                        Response.Flush();
                        Response.End();

                        //rv_capacitacion.LocalReport.Refresh();
                        break;
                }
            }
        }

        private void ViewReportExport(string id)
        {
            LocalReport localReport = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Areas/Capacitacion/Reporte"), "ReporteMemoria.rdlc");
            
            //List<CEntidad> cm8 = new List<CEntidad>();
            //CLogica exeCap = new CLogica();
            //string CodCapacitacion = System.Web.HttpContext.Current.Session["CodCapacitacion"] as String;
            //CEntVM VM_CAP = new CEntVM();
            //CLogica exeCap2 = new CLogica();
            //cm8 = exeCap.ReporteMEMORIA(CodCapacitacion);
           

            ///ReportDataSource rd = new ReportDataSource("DataSet1", cm8);

            //localReport.ReportPath = File;
            //ReportParameter par = new ReportParameter("Usuario", HttpContext.Current.User.Identity.Name);
            //localReport.SetParameters(par);
            //localReport.DataSources.Add(new ReportDataSource("DataSet1", dt));

            //localReport.DataSources.Add(rd);

            string reportType = id;
            //string mimeType;
            //string encoding;
            //string fileNameExtension;

            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            //Warning[] warnings;
            //string[] streams;
            //byte[] renderedBytes;

            //renderedBytes = localReport.Render(
            //    reportType,
            //    deviceInfo,
            //    out mimeType,
            //    out encoding,
            //    out fileNameExtension,
            //    out streams,
            //    out warnings);


           // return File(renderedBytes, mimeType);

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            string filename;

            byte[] bytes = localReport.Render(
               "Word", null, out mimeType, out encoding,
                out extension,
               out streamids, out warnings);

            Random r = new Random();
            int aleat = r.Next(1, 9999);

            filename = "reporte" + aleat.ToString() + ".doc";
            Response.ClearHeaders();
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            Response.ContentType = mimeType;
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}