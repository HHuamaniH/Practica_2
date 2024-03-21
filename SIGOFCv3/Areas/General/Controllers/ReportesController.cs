using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using Herramienta;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SIGOFCv3.Helper;
using SIGOFCv3.Models;
using SIGOFCv3.Models.DataTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CEntidad = CapaEntidad.DOC.Ent_REPORTE_GENERAL;
using CEntidadTH = CapaEntidad.DOC.Ent_TH_Comportamiento;
using CLogica = CapaLogica.DOC.Log_REPORTE_GENERAL;
using VM = CapaEntidad.ViewModel.VM_ReporteGeneral;
using VMTHComportamiento = CapaEntidad.ViewModel.VM_THComportamiento;

namespace SIGOFCv3.Areas.General.Controllers
{
    public class ReportesController : Controller
    {
        Document doc;
        iTextSharp.text.Rectangle page;
        PdfPTable table;
        //string altura;
        float[] widths;
        Utilitarios HerUtil = new Utilitarios();
        Log_GuiaTransporte oCLogica = new Log_GuiaTransporte();
        public static VM vmReport = new VM();
        public static VMTHComportamiento vmTHComportamiento = new VMTHComportamiento();

        [HttpGet]
        public ActionResult Reporte(string _idTipoReporte)
        {
            string tipoReporte = "";
            CLogica exeRpt = new CLogica();

            switch (_idTipoReporte)
            {
                case "0": tipoReporte = "SABANA_INFORME"; break;
                case "1": tipoReporte = "SABANA_PLAN_MANEJO"; break;
                case "2": tipoReporte = "SABANA_SEGUIMIENTO_ALERTA"; break;
                case "3": tipoReporte = "SABANA_ACERVO_DOCUMENTARIO"; break;
                case "4": tipoReporte = "CUADRO_5_PASPEQ"; break;
                case "5": tipoReporte = "CUADRO_6_PASPEQ"; break;
                case "6": tipoReporte = "CUADRO_7_PASPEQ"; break;
                case "7": tipoReporte = "CUADRO_8_PASPEQ"; break;
                case "8": tipoReporte = "SEGUIMIENTO_MED_CORRECTIVAS"; break;
                case "9": tipoReporte = "OBLIGACIONES_TIT_MADERABLE"; break;
                case "10": tipoReporte = "OBLIGACIONES_TIT_NO_MADERABLE"; break;
                case "11": tipoReporte = "REPORTE_CONTROL_CALIDAD"; break;
                case "12": tipoReporte = "RELACION_INFORMES_LEGALES"; break;
                case "13": tipoReporte = "RELACION_INFORMES_TECNICOS"; break;
                case "14": tipoReporte = "RELACION_RESOLUCIONES_FISCALIZACION"; break;
                case "15": tipoReporte = "RELACION_INFORMES_SUSPENSION"; break;
                case "16": tipoReporte = "RELACION_INFORMES_SUPERVISION"; break;
                case "17": tipoReporte = "REPORTE_ITINERARIO_SUPERVISION"; break;
                case "18": tipoReporte = "PAU_CONCLUIDOS_1RA_2DA"; break;
                case "19": tipoReporte = "PAU_CONCLUIDOS_RESUMEN_1RA"; break;
                case "20": tipoReporte = "PAU_CONCLUIDOS_RESUMEN_1RA_2DA"; break;
                case "21": tipoReporte = "REPORTE_ANTECEDENTE_EXPEDIENTE"; break;
                case "22": tipoReporte = "REPORTE_AUTORIZACIONES_FAUNASILVESTRE"; break;
                case "23": tipoReporte = "REPORTE_DIRECCION_FISCALIZACION"; break;
                case "24": tipoReporte = "REPORTE_SOLICITUD_FEMA"; break;
            }

            if (int.TryParse(_idTipoReporte, out int num) && num >= 0 && num <= 24)
            {
                VM _dto = exeRpt.InitReporteGeneral(tipoReporte);
                return View(_dto);
            }
            else
            {
                return View("NoReporte");
            }
        }


        [HttpPost]
        public JsonResult Reporte(VM dto)
        {
            List<Dictionary<string, string>> olResult = new List<Dictionary<string, string>>();
            CEntidad paramRpt = new CEntidad();
            CLogica exeRpt = new CLogica();

            try
            {
                paramRpt.TIPO_REPORTE = dto.hdfTipoReporte;
                paramRpt.FECHA_CORTE = (dto.txtFechaCorte ?? "");
                paramRpt.ANIO = (dto.lstChkAnioId ?? "").Replace(',', '|');
                paramRpt.MES = (dto.lstChkMesId ?? "").Replace(',', '|');
                paramRpt.COD_ITIPO = (dto.lstChkTipoInformeId ?? "").Replace(';', '|');
                paramRpt.COD_OD = (dto.lstChkOdId ?? "").Replace(';', '|');
                paramRpt.COD_MTIPO = (dto.lstChkModalidadId ?? "").Replace(',', '|');
                paramRpt.COD_DPTO = (dto.lstChkDepartamentoId ?? "").Replace(',', '|');
                paramRpt.COD_DLINEA = (dto.lstChkDLineaId ?? "").Replace(',', '|');
                paramRpt.TIPO_DOCUMENTO_SIGO = (dto.lstChkTipoDocumentoSigoId ?? "").Replace(',', '|');
                paramRpt.ESTADO_DOCUMENTO = (dto.lstChkEstadoDocumentoId ?? "").Replace(',', '|');
                paramRpt.TIPO_RESOLUCION_FISCALIZACION = (dto.lstChkTipoResolucionFiscalizacionId ?? "").Replace(',', '|');

                olResult = exeRpt.ReporteGeneral(paramRpt);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message });
            }

            var jsonResult = Json(new { success = true, msj = "", data = olResult.ToArray() }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }


        #region "Reporte Estado Guia Transporte"
        [HttpGet]
        public ActionResult RptEstadodeGuiaTransporte()
        {
            return View();
        }
        [HttpGet]
        public ActionResult RptEstadodeGuiaTransporteGetAll(DataTableRequest_1 request, string criterio, string valorBusqueda, string sort = "")
        {
            List<Ent_PreVisualizarv1> lstResult;
            int rowcount = 0;
            int currentpage = request.Start == 0 ? 1 : (request.Start / request.Length) + 1;
            int pagesize = request.Length;
            valorBusqueda = valorBusqueda ?? "";
            sort = sort ?? "";
            CLogica exeRpt = new CLogica();
            lstResult = exeRpt.Reporte_EstadodeGuiaTransporte(criterio, valorBusqueda, currentpage, pagesize, sort, ref rowcount);

            var jsonResult = Json(new
            {
                data = lstResult.ToArray(),
                draw = request.Draw,
                recordsTotal = rowcount,
                recordsFiltered = rowcount,
                error = ""
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        private String pintaTablaVolinjus(Ent_PreVisualizarv1 entMaestro, Ent_PreVisualizar entPAUs)
        {
            Int32 contador = 0;
            String tablaVolInjus = "";
            List<Ent_PreVisualizar> listInfracciones = new List<Ent_PreVisualizar>();
            Ent_PreVisualizar CEntInfrac;
            try
            {
                tablaVolInjus += "<h3>Volumen Injustificado</h3>";
                tablaVolInjus += "<div class='GrillaDivMarco GrillaDivReporte'>";
                tablaVolInjus += "<table id='tbVolInjus' class='Grilla'><thead><tr><th>N°</th><th>Especies</th><th>Volumen aprobado (m³)</ th>" +
                    "<th>Volumen movilizado (m³)</th><th>Volumen movilizado sin autorización (m³)</th>" +
                    "<th>% del volumen movilizado sin autorización con relación al total del volumen movilizado</th>" +
                    "<th>% del volumen movilizado sin autorización con relación al total del volumen aprobado </th>" +
                    "</tr></thead>";
                tablaVolInjus += "<tbody>";

                if (entPAUs == null)
                {
                    if (entMaestro.INF_NUMERO != "")
                    {

                        CEntInfrac = new Ent_PreVisualizar();
                        CEntInfrac.COD_THABILITANTE = entMaestro.COD_THABILITANTE;
                        CEntInfrac.NUM_POA = entMaestro.NUM_POA;
                        CEntInfrac.BusCriterio = "CONSULTA_INFRACCIONES";
                        CEntInfrac.TIPO_DOCUMENTO = "INF_SUPERVISION";
                        CEntInfrac.COD_INFORME = entMaestro.COD_INFORME;
                        listInfracciones = oCLogica.RegMostrarItemsSansion(CEntInfrac);
                        Session["listInfracciones"] = listInfracciones;
                    }
                }
                else
                {
                    if (entPAUs.RD_INICIO_PAU.Trim() != "" || entPAUs.RD_TERMINO_PAU.Trim() != "")
                    {
                        /*agregar fecha de informe*/
                        CEntInfrac = new Ent_PreVisualizar();
                        CEntInfrac.COD_THABILITANTE = entMaestro.COD_THABILITANTE;
                        CEntInfrac.NUM_POA = entMaestro.NUM_POA;
                        CEntInfrac.FECHA_INFORME = entMaestro.FECHA_INFORME; //FECHA INFORME
                        CEntInfrac.BusCriterio = "CONSULTA_INFRACCIONES";
                        if (entPAUs.RD_TERMINO_PAU.Trim() != "")
                        {
                            CEntInfrac.COD_RDTERMINO = entPAUs.COD_RDTERMINO;
                            CEntInfrac.TIPO_DOCUMENTO = "RD_TERMINO";
                        }
                        else if (entPAUs.RD_INICIO_PAU.Trim() != "")
                        {
                            CEntInfrac.COD_RDINICIO = entPAUs.COD_RDINICIO;
                            CEntInfrac.TIPO_DOCUMENTO = "RD_INICIO";

                        }
                        listInfracciones = oCLogica.RegMostrarItemsSansion(CEntInfrac);
                        Session["listInfracciones"] = listInfracciones;
                    }
                }

                contador = 1;
                foreach (var infrac in listInfracciones)
                {
                    tablaVolInjus += "<tr><td>" + (contador++).ToString() + "</td><td><i>" + infrac.NOMBRE_CIENTIFICO + "</i> | " + infrac.NOMBRE_COMUN + "</td>" +
                        "<td>" + infrac.VOLUMEN_APROBADO_RESOLUCION + "</td><td>" + infrac.VOLUMEN_EXTRAIDO + "</td><td>" + infrac.VOLUMEN + "</td>" +
                        "<td>" + (infrac.VOLUMEN_EXTRAIDO == 0 ? "-" : Math.Round((infrac.VOLUMEN / infrac.VOLUMEN_EXTRAIDO) * 100, 1).ToString()) + "%" + "</td>" +
                        "<td>" + (infrac.VOLUMEN_APROBADO_RESOLUCION == 0 ? "-" : Math.Round((infrac.VOLUMEN / infrac.VOLUMEN_APROBADO_RESOLUCION) * 100, 1).ToString()) + "%" + "</td></tr>";
                }
                tablaVolInjus += "</tbody></table>";
                tablaVolInjus += "</div>";

                return tablaVolInjus;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private String pintaTablaInexistencias(Ent_PreVisualizarv1 entMaestro)
        {
            Int32 contador = 0;
            String tablaInexistencias = "";
            List<Ent_PreVisualizar> listInexistentes = new List<Ent_PreVisualizar>();
            Ent_PreVisualizar CEntInfrac;
            try
            {
                if (entMaestro.INF_NUMERO != "")
                {
                    CEntInfrac = new Ent_PreVisualizar();
                    CEntInfrac.COD_THABILITANTE = entMaestro.COD_THABILITANTE;
                    CEntInfrac.NUM_POA = entMaestro.NUM_POA;
                    CEntInfrac.BusCriterio = "CONSULTA_INEXISTENTES";
                    CEntInfrac.TIPO_DOCUMENTO = "INF_SUPERVISION";
                    CEntInfrac.COD_INFORME = entMaestro.COD_INFORME;
                    listInexistentes = oCLogica.RegBuscarInexistencias(CEntInfrac);
                    Session["listInexistentes"] = listInexistentes;
                    if (listInexistentes.Count > 0)
                    {
                        tablaInexistencias += "<h3>Árboles Inexistentes</h3>";
                        tablaInexistencias += "<div class='GrillaDivMarco GrillaDivReporte'>";
                        tablaInexistencias += "<table id='tbInexistentes' class='Grilla'><thead><tr><th>N°</th><th>Especies</th><th>Nro árboles supervisados</ th>" +
                            "<th>Nro de árboles inexistentes</th><th>% árboles inexistentes</th>" +
                            "</tr></thead>";
                        tablaInexistencias += "<tbody>";

                        contador = 1;
                        foreach (var infrac in listInexistentes)
                        {
                            tablaInexistencias += "<tr><td>" + (contador++).ToString() + "</td><td><i>" + infrac.NOMBRE_CIENTIFICO + "</i> | " + infrac.NOMBRE_COMUN + "</td>" +
                                "<td>" + infrac.MUESTRA + "</td><td>" + infrac.INEX + "</td>" +
                                "<td>" + (infrac.MUESTRA == 0 ? "-" : Math.Round(((Decimal)infrac.INEX / (Decimal)infrac.MUESTRA) * 100, 1).ToString()) + "%</td></tr>";
                        }
                        tablaInexistencias += "</tbody></table>";
                        tablaInexistencias += "</div>";
                    }
                }

                return tablaInexistencias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public ActionResult RptGenerarReporte(Ent_PreVisualizarv1 oCamposView)
        {
            Int32 contador = 0, cuentaSanciones = 0;
            String cadReporte = "", cadMedCau = "", cadInfFalsa = "";
            try
            {
                string COD_UGRUPO = (ModelSession.GetSession())[0].COD_UGRUPO;


                List<Ent_PreVisualizar> listNotifArchivo = new List<Ent_PreVisualizar>();
                List<Ent_PreVisualizar> listNotifRDIni = new List<Ent_PreVisualizar>();
                List<Ent_PreVisualizar> listNotifRDTer = new List<Ent_PreVisualizar>();
                List<Ent_PreVisualizar> listBExtraccion = new List<Ent_PreVisualizar>();
                List<Ent_PreVisualizar> listInfracciones = new List<Ent_PreVisualizar>();
                List<Ent_PreVisualizar> listInexistentes = new List<Ent_PreVisualizar>();
                List<Ent_PreVisualizar> listPAus = new List<Ent_PreVisualizar>();
                Ent_PreVisualizar CEntConsulta;
                Ent_PreVisualizar CEntNotif;
                Ent_PreVisualizar CEntInfrac = new Ent_PreVisualizar();


                oCamposView.ARESOLUCION_NUM = oCamposView.ARESOLUCION_NUM ?? "";
                oCamposView.ARESOLUCION_NUM = oCamposView.ARESOLUCION_NUM ?? "";
                oCamposView.INF_NUMERO = oCamposView.INF_NUMERO ?? "";
                oCamposView.ANIO_SUPER = oCamposView.ANIO_SUPER ?? "";
                oCamposView.DOC_SIADO_INFORME = oCamposView.DOC_SIADO_INFORME ?? "";
                oCamposView.BEXTRACCION_FEMISION = oCamposView.BEXTRACCION_FEMISION ?? "";
                oCamposView.INICIO_VIGENCIA = oCamposView.INICIO_VIGENCIA ?? "";
                oCamposView.BEXTRACCION_FEMISION = oCamposView.BEXTRACCION_FEMISION ?? "";

                if (oCamposView.COD_THABILITANTE != null)
                {
                    oCamposView.DOC_SIADO_ARESOL = oCamposView.DOC_SIADO_ARESOL ?? "";
                    oCamposView.ARESOLUCION_NUM = oCamposView.ARESOLUCION_NUM ?? "";
                    oCamposView.REFORMULA_NUM = oCamposView.REFORMULA_NUM ?? "";

                    cadReporte = "<div><h3>Organismo de Supervisión de los Recursos Forestales y de Fauna Silvestre - OSINFOR</h3></div>";
                    cadReporte += "<div class='datosGral'>";
                    cadReporte += "<div><div>Título Habilitante:</div><div>" + oCamposView.PERMISO_AUTORIZACION + "</div></div>";
                    cadReporte += "<div><div>Modalidad:</div><div>" + oCamposView.MODALIDAD + "</div></div>";
                    cadReporte += "<div><div>Titular:</div><div>" + oCamposView.TITULAR + "</div></div>";
                    cadReporte += "<div class='sepBloque'>Ubicación</div>";
                    cadReporte += "<div><div>Departamento:</div><div>" + oCamposView.DEPARTAMENTO + "</div></div>";
                    cadReporte += "<div><div>Provincia:</div><div>" + oCamposView.PROVINCIA + "</div></div>";
                    cadReporte += "<div><div>Distrito:</div><div>" + oCamposView.DISTRITO + "</div></div>";
                    cadReporte += "<div><div>Sector:</div><div>" + oCamposView.SECTOR + "</div></div>";
                    cadReporte += "<div><div>Plan de Manejo:</div><div>" + oCamposView.POA + "</div></div>";
                    cadReporte += "<div><div>Resolución de Aprobación:</div><div>" + (oCamposView.ARESOLUCION_NUM.Trim() == "" || oCamposView.ARESOLUCION_NUM.Trim() == "NO CONSIGNA" ? " - " : "<a href='#' onclick=\"descargaPDF('" + oCamposView.DOC_SIADO_ARESOL + "','" + oCamposView.DOC_ORIGEN_ARESOL + "')\">" + oCamposView.ARESOLUCION_NUM + "</a>") + "</div></div>";
                    cadReporte += "<div><div>Resolución que Reformula:</div><div>" + (oCamposView.REFORMULA_NUM.Trim() == "" || oCamposView.REFORMULA_NUM.Trim() == "NO CONSIGNA" ? " - " : "<a href='#' onclick=\"descargaPDF('" + oCamposView.DOC_SIADO_ARESOL + "','" + oCamposView.DOC_ORIGEN_REFOR + "')\">" + oCamposView.REFORMULA_NUM + "</a>") + "</div></div>";
                    cadReporte += "<div><div>Zafra:</div><div>" + oCamposView.ZAFRA + "</div></div>";
                    cadReporte += "<div><div>Inicio de Vigencia:</div><div>" + oCamposView.INICIO_VIGENCIA.ToString() + "</div></div>";


                    CEntConsulta = new Ent_PreVisualizar();
                    CEntConsulta.BusCriterio = "CONSULTA_BEXTRACCION";
                    CEntConsulta.COD_THABILITANTE = oCamposView.COD_THABILITANTE;
                    CEntConsulta.NUM_POA = oCamposView.NUM_POA;
                    listBExtraccion = oCLogica.RegMostrarBExtraccion(CEntConsulta);
                    Session["listBExtraccion"] = listBExtraccion;

                    cadReporte += "<h3>Balance de Extracción del " + oCamposView.POA + "</h3>";
                    cadReporte += "<div><div>Fecha de Emisión B. Extracción</div><div>" + (oCamposView.BEXTRACCION_FEMISION.ToString().Trim() == "" ? " - " : oCamposView.BEXTRACCION_FEMISION.ToString().Trim()) + "</div></div>";
                    cadReporte += "<div class='GrillaDivMarco GrillaDivReporte'>";
                    cadReporte += "<table id='tbBExtraccion' class='Grilla'><thead><tr><th>N°</th><th>Especie</th><th>Total Árboles</th>" +
                                    "<th>Volumen Autorizado (m³)</th><th>Volumen Movilizado (m³)</th><th>Saldo</th></thead><tbody>";

                    contador = 1;
                    foreach (var fila in listBExtraccion)
                    {
                        cadReporte += "<tr><td>" + (contador++).ToString() + "</td><td><i>" + fila.NOMBRE_CIENTIFICO + "</i> | " + fila.NOMBRE_COMUN + "</td><td>" + fila.NUMERO_INDIVIDUOS.ToString() + "</td>" +
                            "<td>" + fila.VOLUMEN_APROBADO_RESOLUCION + "</td><td>" + fila.VOLUMEN_EXTRAIDO + "</td><td>" + fila.SALDO + "</td></tr>";
                    }

                    cadReporte += "</tbody></table>";
                    cadReporte += "</div>";
                    cadReporte += "<h2>Supervisión del OSINFOR</h2>";

                    if (oCamposView.INF_NUMERO.Trim() == "" || oCamposView.ANIO_SUPER.Trim() == "-")
                    {
                        if (oCamposView.INF_NUMERO.Trim() == "" && oCamposView.ANIO_SUPER.Trim() == "-")
                        {
                            cadReporte += "<div><div>Supervisión:</div><div> NO </div></div>";
                        }
                        else
                        {
                            cadReporte += "<div><div>Supervisión:</div><div> NO </div></div>";
                            cadReporte += "<div><div>Nro Informe de Supervisión:</div><div>" + (oCamposView.INF_NUMERO.Trim() == "" ? " - " : "<a href='#' onclick=\"descargaPDF('" + oCamposView.DOC_SIADO_INFORME.Trim() + "')\">" + oCamposView.INF_NUMERO + "</a>") + "</div></div>";
                        }
                        cadReporte += "<h2>Fiscalización del OSINFOR</h2>";
                        cadReporte += "<div><div>Archivo Preliminar:</div><div> - </div></div>";
                    }
                    else
                    {
                        if (oCamposView.COD_ITIPO != "0000003")
                        {
                            cadReporte += "<div><div>Supervisión:</div><div> SI </div></div>";
                            cadReporte += "<div><div>Nro Informe de Supervisión:</div><div>" + (oCamposView.INF_NUMERO.Trim() == "" ? " - " : "<a href='#' onclick=\"descargaPDF('" + oCamposView.DOC_SIADO_INFORME.Trim() + "')\">" + oCamposView.INF_NUMERO + "</a>") + "</div></div>";
                        }
                        else
                        {
                            cadReporte += "<div><div>Supervisión:</div><div> NO </div></div>";
                            cadReporte += "<div><div>Nro Informe:</div><div>" + (oCamposView.INF_NUMERO.Trim() == "" ? " - " : oCamposView.INF_NUMERO + " (" + oCamposView.TIPO_DOCUMENTO + ")") + "</div></div>";
                        }

                        cadReporte += "<div><div>Fecha de inicio de la supervisión en campo:</div><div>" + oCamposView.FECHA_INI + "</div></div>";
                        cadReporte += "<div><div>Fecha de término de la supervisión en campo:</div><div>" + oCamposView.FECHA_TERMINO + "</div></div>";
                        cadReporte += "<h2>Fiscalización del OSINFOR</h2>";

                        if (oCamposView.DETER_INF_LEGAL == "Archivo" || oCamposView.DETER_INF_LEGAL == "Archivo y nueva supervisión")
                        {

                            cadReporte += "<div><div>Archivo Preliminar:</div><div> SI </div></div>";
                            cadReporte += "<div><div>Motivo del Archivo:</div><div>" + oCamposView.MOTIVO_ARCHIVO + "</div></div>";

                            if (COD_UGRUPO == "0000001"
                            || COD_UGRUPO == "0000002"
                            || COD_UGRUPO == "0000003"
                            || COD_UGRUPO == "0000004"
                            || COD_UGRUPO == "0000005"
                            || COD_UGRUPO == "0000006"
                            || COD_UGRUPO == "0000007"
                            || COD_UGRUPO == "0000008"
                            || COD_UGRUPO == "0000009"
                            || COD_UGRUPO == "0000010"
                            || COD_UGRUPO == "0000011"
                            || COD_UGRUPO == "0000012"
                            || COD_UGRUPO == "0000014")
                            {
                                CEntNotif = new Ent_PreVisualizar();
                                CEntInfrac.COD_INFORME = oCamposView.COD_INFORME;
                                CEntInfrac.BusCriterio = "CONSULTA_NOTIFICACIONES";
                                CEntInfrac.TIPO_DOCUMENTO = "INF_SUPERVISION";
                                listNotifArchivo = oCLogica.RegMostrarNotificaciones(CEntInfrac);
                                Session["listNotifArchivo"] = listNotifArchivo;

                                cadReporte += "<h3>Notificaciones del Archivo Preliminar </h3>";
                                cadReporte += "<div class='GrillaDivMarco GrillaDivReporte'>";
                                cadReporte += "<table id='tbNotifIni' class='Grilla'><thead><tr><th>N°</th><th>Nro Notificación</th><th>Fecha de Notificación</ th>" +
                                    "<th>Tipo Notificación</th></thead><tbody>";

                                contador = 1;
                                foreach (var notif in listNotifArchivo)
                                {
                                    cadReporte += "<tr><td>" + (contador++).ToString() + "</td><td>" + notif.NUMERO_NOTIFICACION + "</td><td>" + notif.FECHA_NOTIFICACION + "</td><td>" + notif.TIPO_NOTIFICACION + "</td></tr>";
                                }
                                cadReporte += "</tbody></table>";
                                cadReporte += "</div>";
                            }




                            if (oCamposView.MOTIVO_ARCHIVO == "No competencia del OSINFOR" || oCamposView.MOTIVO_ARCHIVO == "Muerte del Titular")
                            {
                                cadReporte += this.pintaTablaVolinjus(oCamposView, null);
                                cadReporte += this.pintaTablaInexistencias(oCamposView);
                            }

                            cadReporte += "<div><div><strong>Estado Actual del Proceso:</strong></div><div><strong>Archivo Preliminar</strong></div></div>";
                        }
                        else
                        {
                            cadReporte += "<div><div>Archivo Preliminar:</div><div> NO </div></div>";

                            cadReporte += "</div>";
                            cadReporte += "<div class='datosBloque'>";

                            CEntConsulta = new Ent_PreVisualizar();
                            CEntConsulta.COD_THABILITANTE = oCamposView.COD_THABILITANTE;
                            CEntConsulta.NUM_POA = oCamposView.NUM_POA;
                            CEntConsulta.COD_INFORME = oCamposView.COD_INFORME;
                            CEntConsulta.BusCriterio = "CONSULTA_REGISTRO";
                            listPAus = oCLogica.RegMostrarTHPOA(CEntConsulta);
                            Session["listPAus"] = listPAus;

                            if (listPAus.Count > 0)
                            {
                                foreach (var filaPAU in listPAus)
                                {
                                    filaPAU.RD_INICIO_PAU = filaPAU.RD_INICIO_PAU ?? "";
                                    filaPAU.DOC_SIADO_INI = filaPAU.DOC_SIADO_INI ?? "";
                                    filaPAU.DOC_SIADO_REC = filaPAU.DOC_SIADO_REC ?? "";
                                    filaPAU.RES_TFFS = filaPAU.RES_TFFS ?? "";
                                    filaPAU.RD_ADECUACION = filaPAU.RD_ADECUACION ?? "";
                                    if (filaPAU.RD_INICIO_PAU.Trim() == "")
                                    {
                                        cadReporte += "<div><div>Resolución Directoral Inicio PAU:</div><div> - </div></div>";
                                        cadReporte += "<div><div>Con Medidas Cautelares:</div><div> - </div></div>";
                                        cadReporte += "<div><div>Con Información Falsa:</div><div> - </div></div>";
                                    }
                                    else
                                    {
                                        cadReporte += "<div><div>Resolución Directoral Inicio PAU:</div><div><a href='#' onclick=\"descargaPDF('" + filaPAU.DOC_SIADO_INI.Trim() + "')\">" + filaPAU.RD_INICIO_PAU + "</a></div></div>";
                                        if ((Boolean)filaPAU.MEDIDAS_CAUTELARES) { cadMedCau = "SI"; } else { cadMedCau = "NO"; }
                                        if ((Boolean)filaPAU.RD_INICIO_INF_FALSA) { cadInfFalsa = "SI"; } else { cadInfFalsa = "NO"; }
                                        cadReporte += "<div><div>Con Medidas Cautelares:</div><div> " + cadMedCau + " </div></div>";
                                        cadReporte += "<div><div>Con Información Falsa:</div><div> " + cadInfFalsa + " </div></div>";


                                        if (COD_UGRUPO == "0000001"
                            || COD_UGRUPO == "0000002"
                            || COD_UGRUPO == "0000003"
                            || COD_UGRUPO == "0000004"
                            || COD_UGRUPO == "0000005"
                            || COD_UGRUPO == "0000006"
                            || COD_UGRUPO == "0000007"
                            || COD_UGRUPO == "0000008"
                            || COD_UGRUPO == "0000009"
                            || COD_UGRUPO == "0000010"
                            || COD_UGRUPO == "0000011"
                            || COD_UGRUPO == "0000012"
                            || COD_UGRUPO == "0000014")
                                        {
                                            CEntNotif = new Ent_PreVisualizar();
                                            CEntInfrac.COD_RDINICIO = filaPAU.COD_RDINICIO;
                                            CEntInfrac.BusCriterio = "CONSULTA_NOTIFICACIONES";
                                            CEntInfrac.TIPO_DOCUMENTO = "RD_INICIO";
                                            listNotifRDIni = oCLogica.RegMostrarNotificaciones(CEntInfrac);
                                            Session["listNotifRDIni"] = listNotifRDIni;

                                            cadReporte += "<h3>Notificaciones de la Resolución Directoral de Inicio de PAU</h3>";
                                            cadReporte += "<div class='GrillaDivMarco GrillaDivReporte'>";
                                            cadReporte += "<table id='tbNotifIni' class='Grilla'><thead><tr><th>N°</th><th>Nro Notificación</th><th>Fecha de Notificación</ th>" +
                                                "<th>Tipo Notificación</th></thead><tbody>";

                                            contador = 1;
                                            foreach (var notif in listNotifRDIni)
                                            {
                                                cadReporte += "<tr><td>" + (contador++).ToString() + "</td><td>" + notif.NUMERO_NOTIFICACION + "</td><td>" + notif.FECHA_NOTIFICACION + "</td><td>" + notif.TIPO_NOTIFICACION + "</td></tr>";
                                            }
                                            cadReporte += "</tbody></table>";
                                            cadReporte += "</div>";
                                        }



                                        if (filaPAU.RD_TERMINO_PAU.Trim() == "")
                                        {


                                            cadReporte += "<div><div>Resolución Directoral Término PAU:</div><div> - </div></div>";
                                            cadReporte += "<div><div>Archivo:</div><div> - </div></div>";
                                            cadReporte += "<div><div>Caducidad:</div><div> - </div></div>";
                                            cadReporte += "<div><div>Sanción:</div><div> - </div></div>";
                                            cadReporte += "<div><div>Infracciones de la RD de Término:</div><div> - </div></div>";

                                            cadReporte += pintaTablaVolinjus(oCamposView, filaPAU);
                                            cadReporte += "<div><div><strong>Estado Actual del Proceso:</strong></div><div><strong>PAU en Trámite</strong></div></div>";
                                        }
                                        else
                                        {
                                            filaPAU.DOC_SIADO_TER = filaPAU.DOC_SIADO_TER ?? "";
                                            cadReporte += "<div><div>Resolución Directoral Término PAU:</div><div><a href='#' onclick=\"descargaPDF('" + filaPAU.DOC_SIADO_TER.Trim() + "')\">" + filaPAU.RD_TERMINO_PAU + "</a></div></div>";
                                            if (filaPAU.PAU_FIN_TIPO == "Archivo") { cadReporte += "<div><div>Archivo</div><div> SI </div></div>"; }
                                            else { cadReporte += "<div><div>Archivo:</div><div> NO </div></div>"; }
                                            if ((Boolean)filaPAU.CADUCIDAD && filaPAU.DETER_RECONSIDERACION != "Fundado" && filaPAU.NOM_MOTDET_TFFS != "Imputaciones desvirtuadas (fundado)" && !(Boolean)filaPAU.LEV_CADUC_RD_REC)
                                            {
                                                cadReporte += "<div><div>Caducidad:</div><div><strong style=\"color:red;\">SI</strong></div></div>"; cuentaSanciones++;
                                            }
                                            else
                                            {
                                                cadReporte += "<div><div>Caducidad:</div><div> NO </div></div>";
                                            }
                                            if (filaPAU.PAU_FIN_TIPO == "Sanción")
                                            {
                                                cadReporte += "<div><div>Sanción:</div><div> SI </div></div>";
                                            }
                                            else
                                            {
                                                cadReporte += "<div><div>Sanción:</div><div> NO </div></div>";
                                            }
                                            cadReporte += "<div><div>Infracciones de la RD de Término:</div><div>" + filaPAU.INFRACCIONES + "</div></div>";

                                            //ESTADO DEL PROCESO JUDICIALIZADO
                                            Ent_Reporte_Historial_TH oEstado = new Ent_Reporte_Historial_TH();
                                            oEstado.RD_TERMINO = filaPAU.RD_TERMINO_PAU.Trim();
                                            List<Ent_Reporte_Historial_TH> oEstadoProcesoJud = new Log_RHistorial_TH().log_EstadoProcesoJudicializado_S(oEstado);
                                            Ent_Reporte_Historial_TH oResult = new Log_RHistorial_TH().log_ObtenerIdTitularPagos(oEstado);
                                            cadReporte += "<br/><div class=bloqueFormTitulo ><b>Información del Estado del Proceso Judicializado</b></div>";
                                            cadReporte += "<div><div>Judicializado:</div><div>" + (oEstadoProcesoJud.Count > 0 ? "Si" : "-") + " </div></div>";
                                            if (oEstadoProcesoJud.Count > 0)
                                            {
                                                cadReporte += " <table class='table Grilla  table-bordered '><thead>	<tr><th>Tipo Expediente</th><th>Fecha Notificación</th><th>Nro Expediente</th><th>Estado</th></tr></thead><tbody>";
                                                foreach (var item in oEstadoProcesoJud)
                                                {
                                                    cadReporte += string.Format(" <tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", item.TIPO_EXPEDIENTE_RD, item.FECHA_NOTIFICACION_RDTERMINO, item.NUM_EXP, item.ESTADO_PROCESOJUDICIALIZADO);
                                                }
                                                cadReporte += "</tbody> </table>";
                                            }
                                            //cadReporte += "<br/><div class=bloqueFormTitulo ><b>Información del Estado del Proceso Judicializado</b></div>";
                                            //cadReporte += "<div><div>Judicializado:</div><div>" + (oEstadoProcesoJud.NUMERO_RESOLUCION != null ? "Si" : "-") + " </div></div>";
                                            //cadReporte += "<div><div>Fecha de notificación a OSINFOR:</div><div> " + (oEstadoProcesoJud.FECHA_NOTIFICACION_RDTERMINO ?? "-") + " </div></div>";
                                            //cadReporte += "<div><div>Nro de Expediente:</div><div> " + (oEstadoProcesoJud.NUM_EXP ?? "-") + " </div></div>";
                                            //cadReporte += "<div><div>Estado:</div><div>" + (oEstadoProcesoJud.ESTADO_PROCESOJUDICIALIZADO ?? "-") + "</div></div>";

                                            cadReporte += "<br/><div class=bloqueFormTitulo ><b>Información del Pago de la Multa</b></div>";
                                            cadReporte += "<div><div>Estado:</div><div> " + (oResult.ESTADO_RESOLUCION ?? "-") + " </div></div>";
                                            cadReporte += "<div><div>Modalidad:</div><div> " + (oResult.MODALIDAD ?? "-") + " </div></div>";
                                            cadReporte += "<div><div>Resumen de movimientos:</div><div><a href='javascript: void(0);' onclick='_RptETH.fnResumenRecaudacionesC(" + oResult.ID_REGISTRO.ToString() + ")'><i class='fa fa-search fa-fw'></i> Ver Resumen </a></div></div><br/>";
                                            if (COD_UGRUPO == "0000001"
                            || COD_UGRUPO == "0000002"
                            || COD_UGRUPO == "0000003"
                            || COD_UGRUPO == "0000004"
                            || COD_UGRUPO == "0000005"
                            || COD_UGRUPO == "0000006"
                            || COD_UGRUPO == "0000007"
                            || COD_UGRUPO == "0000008"
                            || COD_UGRUPO == "0000009"
                            || COD_UGRUPO == "0000010"
                            || COD_UGRUPO == "0000011"
                            || COD_UGRUPO == "0000012"
                            || COD_UGRUPO == "0000014")
                                            {
                                                CEntNotif = new Ent_PreVisualizar();
                                                CEntInfrac.COD_RDTERMINO = filaPAU.COD_RDTERMINO;
                                                CEntInfrac.BusCriterio = "CONSULTA_NOTIFICACIONES";
                                                CEntInfrac.TIPO_DOCUMENTO = "RD_TERMINO";
                                                listNotifRDTer = oCLogica.RegMostrarNotificaciones(CEntInfrac);
                                                Session["listNotifRDTer"] = listNotifRDTer;

                                                cadReporte += "<h3>Notificaciones de la Resolución Directoral de Término de PAU</h3>";
                                                cadReporte += "<div class='GrillaDivMarco GrillaDivReporte'>";
                                                cadReporte += "<table id='tbNotifTer' class='Grilla'><thead><tr><th>N°</th><th>Nro Notificación</th><th>Fecha de Notificación</ th>" +
                                                    "<th>Tipo Notificación</th></thead><tbody>";

                                                contador = 1;
                                                foreach (var notif in listNotifRDTer)
                                                {
                                                    cadReporte += "<tr><td>" + (contador++).ToString() + "</td><td>" + notif.NUMERO_NOTIFICACION + "</td><td>" + notif.FECHA_NOTIFICACION + "</td><td>" + notif.TIPO_NOTIFICACION + "</td></tr>";
                                                }
                                                cadReporte += "</tbody></table>";
                                                cadReporte += "</div>";
                                            }

                                            if (filaPAU.RD_RECONSIDERACION != "")
                                            {
                                                filaPAU.RD_RECONSIDERACION = filaPAU.RD_RECONSIDERACION ?? "";
                                                cadReporte += "<div><div>Resolución Directoral de Reconsideración:</div><div>" + (filaPAU.RD_RECONSIDERACION.Trim() == "" ? " - " : "<a href='#' onclick=\"descargaPDF('" + filaPAU.DOC_SIADO_REC.Trim() + "')\">" + filaPAU.RD_RECONSIDERACION + "</a>") + "</div></div>";
                                                cadReporte += "<div><div>Determinación de la RD de Reconsideración:</div><div>" + (filaPAU.RD_RECONSIDERACION.Trim() == "" ? " - " : filaPAU.DETER_RECONSIDERACION) + "</div></div>";
                                            }
                                            if (filaPAU.RD_ADECUACION != "")
                                            {
                                                cadReporte += "<div><div>Resolución Directoral de Adecuación de Multa:</div><div>" + (filaPAU.RD_ADECUACION.Trim() == "" ? " - " : "<a href='#' onclick=\"descargaPDF('" + filaPAU.DOC_SIADO_REC.Trim() + "')\">" + filaPAU.RD_RECONSIDERACION + "</a>") + "</div></div>";
                                                cadReporte += "<div><div>Fecha de emisión:</div><div>" + (filaPAU.FECHA_ADECUACION.ToString() == "" ? " - " : filaPAU.FECHA_ADECUACION) + "</div></div>";

                                            }
                                            if (filaPAU.RES_TFFS != "")
                                            {
                                                cadReporte += "<div><div>Resolución del Tribunal Forestal y de Fauna Silvestre:</div><div>" + (filaPAU.RES_TFFS.Trim() == "" ? " - " : filaPAU.RES_TFFS) + "</div></div>";
                                                cadReporte += "<div><div>Recurso de Apelación:</div><div>" + (filaPAU.RES_TFFS.Trim() == "" ? " - " : filaPAU.NOM_RECAPE_TFFS) + "</div></div>";
                                                cadReporte += "<div><div>Determina:</div><div>" + (filaPAU.RES_TFFS.Trim() == "" ? " - " : filaPAU.NOM_TIPDET_TFFS) + "</div></div>";
                                                cadReporte += "<div><div>Motivo:</div><div>" + (filaPAU.RES_TFFS.Trim() == "" ? " - " : filaPAU.NOM_MOTDET_TFFS) + "</div></div>";
                                            }
                                            cadReporte += "<div><div>Multa Final PAU:</div><div>" + (filaPAU.MULTA_PAU > 0 ? filaPAU.MULTA_PAU : 0) + "</div></div>";


                                            if (filaPAU.PAU_FIN_TIPO == "Archivo" || filaPAU.DETER_RECONSIDERACION == "Fundado")
                                            {
                                                //cadReporte += pintaTablaVolinjus(oCamposView, filaPAU);
                                                cuentaSanciones = 0;
                                                cadReporte += "<div><div><strong>Estado Actual del Proceso:</strong></div><div><strong>PAU Concluido - Archivo</strong></div></div>";
                                            }
                                            else
                                            {

                                                if (filaPAU.PROVEIDO == "Proveído Firme Acto Administrativo")
                                                {
                                                    cadReporte += pintaTablaVolinjus(oCamposView, filaPAU);
                                                    cadReporte += "<div><div><strong>Estado Actual del Proceso:</strong></div><div><strong>PAU Concluido - Firme</strong></div></div>";
                                                }
                                                else if (filaPAU.PROVEIDO == "Proveído Archivo PAU - Fallecimiento del Titular")
                                                {
                                                    cadReporte += pintaTablaVolinjus(oCamposView, filaPAU);
                                                    cadReporte += "<div><div><strong>Estado Actual del Proceso:</strong></div><div><strong>PAU Concluido - Archivo (Titular fallecido)</strong></div></div>";
                                                }
                                                else if (filaPAU.PROVEIDO == "Proveido Agotada la vía Administrativa" && filaPAU.NOM_MOTDET_TFFS == "Imputaciones desvirtuadas (fundado)")
                                                {
                                                    cadReporte += "<div><div><strong>Estado Actual del Proceso:</strong></div><div><strong>PAU Concluido - Agotada via administrativa</strong></div></div>";
                                                }
                                                else if (filaPAU.PROVEIDO == "Proveido Agotada la vía Administrativa" && filaPAU.NOM_MOTDET_TFFS != "Imputaciones desvirtuadas (fundado)")
                                                {
                                                    cuentaSanciones++;
                                                    cadReporte += pintaTablaVolinjus(oCamposView, filaPAU);
                                                    cadReporte += "<div><div><strong>Estado Actual del Proceso:</strong></div><div><strong>PAU Concluido - Agotada via administrativa</strong></div></div>";
                                                }
                                                else
                                                {
                                                    cuentaSanciones++;
                                                    cadReporte += pintaTablaVolinjus(oCamposView, filaPAU);
                                                    if (filaPAU.APELA.Trim() != "")
                                                    {
                                                        cadReporte += "<div><div><strong>Estado Actual del Proceso:</strong></div><div><strong>PAU Concluido - Apelación</strong></div></div>";
                                                    }
                                                    else
                                                    {
                                                        cadReporte += "<div><div><strong>Estado Actual del Proceso:</strong></div><div><strong>PAU Concluido</strong></div></div>";
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (cuentaSanciones > 0)
                                {
                                    cadReporte += pintaTablaInexistencias(oCamposView);
                                }
                            }
                            else
                            {
                                cadReporte += pintaTablaInexistencias(oCamposView);
                                cadReporte += "<div><div><strong>Estado Actual del Proceso:</strong></div><div><strong>Evaluación Legal</strong></div></div>";
                            }
                        }
                    }
                    oCamposView.FECHA_HORA_CONSULTA = DateTime.Now.ToString();
                    cadReporte += "<div><div>Fecha y Hora de Consulta:</div><div>" + oCamposView.FECHA_HORA_CONSULTA + "</div></div>";
                    cadReporte += "</div>";



                    Session["CEntReporteGTF"] = oCamposView;

                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            return Json(new { success = true, msj = "", data = cadReporte });
        }
        private String revisaArchivos(String ruta, String busqueda)
        {
            String retorno = "";
            if (Directory.Exists(ruta))
            {
                string[] archivos = Directory.GetFiles(ruta, busqueda);
                //string[] archivos = Directory.GetFiles("Z:/", ListFiles[ListIndex].DETINV_CODDOC.ToString().Trim() + ".*");
                if (archivos.Length == 1)
                {
                    FileInfo fi = new FileInfo(archivos[0]);
                    retorno = fi.Name;
                }
                else if (archivos.Length > 1)
                {
                    throw new Exception("Existe más de un archivo con el mismo nombre");
                }
                else if (archivos.Length == 0)
                {
                    throw new Exception("No existe el archivo seleccionado");
                }
            }
            else
            {
                return retorno;
            }
            return retorno;
        }
        [HttpGet]
        public ActionResult generaReportePDF()
        {


            Int32 contador = 0, cuentaSanciones = 0;

            List<Ent_PreVisualizar> listPAus = new List<Ent_PreVisualizar>();
            String cadReporte = "", cadMedCau = "", cadInfFalsa = "";

            Ent_PreVisualizarv1 oCamposView = (Ent_PreVisualizarv1)Session["CEntReporteGTF"];
            listPAus = (List<Ent_PreVisualizar>)Session["listPAus"];
            List<Ent_PreVisualizar> listNotifArchivo = (List<Ent_PreVisualizar>)Session["listNotifArchivo"];
            if (listNotifArchivo == null) { listNotifArchivo = new List<Ent_PreVisualizar>(); }
            List<Ent_PreVisualizar> listNotifRDIni = (List<Ent_PreVisualizar>)Session["listNotifRDIni"];
            List<Ent_PreVisualizar> listNotifRDTer = (List<Ent_PreVisualizar>)Session["listNotifRDTer"];
            List<Ent_PreVisualizar> listBExtraccion = (List<Ent_PreVisualizar>)Session["listBExtraccion"];

            try
            {
                doc = new Document(iTextSharp.text.PageSize.LETTER);
                doc.AddAuthor("OSINFOR");
                doc.AddKeywords("pdf, PdfWriter; Documento; iTextSharp");
                doc.SetMargins(36.0f, 36.0f, 96.0f, 50.0f);
                string rut = Server.MapPath("~/PlantillaPDF/PlantillaOsinfor.pdf");
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(rut, FileMode.Create));
                doc.Open();
                //saltos de linea 
                page = doc.PageSize;

                PdfPTable table = new PdfPTable(1);
                table.WidthPercentage = 80;
                table.TotalWidth = page.Width - 90;
                string altura = table.TotalHeight.ToString();
                table.LockedWidth = true;
                float[] widths = new float[] { .99f };
                table.SetWidths(widths);
                table.AddCell(HerUtil.celda("Organismo de Supervisión de los Recursos Forestales y de Fauna Silvestre - OSINFOR", 1, 1, 12, Element.ALIGN_CENTER, 0, BaseColor.BLACK, "transparent", "Negrita"));
                doc.Add(table);
                doc.Add(new Paragraph("\n"));

                table = new PdfPTable(3);
                table.WidthPercentage = 80;
                table.TotalWidth = page.Width - 90;
                table.LockedWidth = true;
                widths = new float[] { .35f, .01f, .64f };
                table.SetWidths(widths);

                table.AddCell(HerUtil.celda("Título Habilitante:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                table.AddCell(HerUtil.celda(oCamposView.PERMISO_AUTORIZACION, 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(HerUtil.celda("Modalidad:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                table.AddCell(HerUtil.celda(oCamposView.MODALIDAD, 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(HerUtil.celda("Titular:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                table.AddCell(HerUtil.celda(oCamposView.TITULAR, 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(HerUtil.celda("Ubicación", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                table.AddCell(HerUtil.celda("", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(HerUtil.celda("Departamento:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                table.AddCell(HerUtil.celda(oCamposView.DEPARTAMENTO, 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(HerUtil.celda("Provincia:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                table.AddCell(HerUtil.celda(oCamposView.PROVINCIA, 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(HerUtil.celda("Distrito:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                table.AddCell(HerUtil.celda(oCamposView.DISTRITO, 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(HerUtil.celda("Sector:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                table.AddCell(HerUtil.celda(oCamposView.SECTOR, 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(HerUtil.celda("Plan de Manejo:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                table.AddCell(HerUtil.celda(oCamposView.POA, 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(HerUtil.celda("Resolución de Aprobación:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                table.AddCell(HerUtil.celda((oCamposView.ARESOLUCION_NUM.Trim() == "" || oCamposView.ARESOLUCION_NUM.Trim() == "NO CONSIGNA" ? " - " : oCamposView.ARESOLUCION_NUM.Trim()), 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(HerUtil.celda("Resolución que Reformula:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                table.AddCell(HerUtil.celda((oCamposView.REFORMULA_NUM.Trim() == "" || oCamposView.REFORMULA_NUM.Trim() == "NO CONSIGNA" ? " - " : oCamposView.REFORMULA_NUM), 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(HerUtil.celda("Zafra:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                table.AddCell(HerUtil.celda(oCamposView.ZAFRA, 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                table.AddCell(HerUtil.celda("Inicio de Vigencia:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                table.AddCell(HerUtil.celda(oCamposView.INICIO_VIGENCIA.ToString(), 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));

                cadReporte += "<div class='datosGral'>";

                doc.Add(table);
                table = new PdfPTable(1); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                widths = new float[] { .99f }; table.SetWidths(widths);
                table.AddCell(HerUtil.celda("Balance de Extracción del " + oCamposView.POA, 1, 1, 12, Element.ALIGN_CENTER, 0, BaseColor.BLACK, "transparent", "Negrita"));
                doc.Add(new Paragraph("\n")); doc.Add(table); doc.Add(new Paragraph("\n"));

                table = new PdfPTable(3); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                widths = new float[] { .35f, .01f, .64f }; table.SetWidths(widths);

                table.AddCell(HerUtil.celda("Fecha de Emisión B. Extracción:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                table.AddCell(HerUtil.celda((oCamposView.BEXTRACCION_FEMISION.ToString().Trim() == "" ? " - " : oCamposView.BEXTRACCION_FEMISION.ToString().Trim()), 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));

                doc.Add(table);

                if (listBExtraccion.Count > 0)
                {
                    table = new PdfPTable(6); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                    widths = new float[] { .10f, .34f, .14f, .14f, .14f, .14f }; table.SetWidths(widths);

                    table.AddCell(HerUtil.celda("N°", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                    table.AddCell(HerUtil.celda("Especie", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                    table.AddCell(HerUtil.celda("Total Árboles", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                    table.AddCell(HerUtil.celda("Volumen Autorizado (m³)", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                    table.AddCell(HerUtil.celda("Volumen Movilizado (m³)", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                    table.AddCell(HerUtil.celda("Saldo", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));

                    contador = 1;
                    foreach (var fila in listBExtraccion)
                    {
                        table.AddCell(HerUtil.celda((contador++).ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                        table.AddCell(HerUtil.celda((fila.NOMBRE_CIENTIFICO + " | " + fila.NOMBRE_COMUN), 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Cursiva"));
                        table.AddCell(HerUtil.celda(fila.NUMERO_INDIVIDUOS.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                        table.AddCell(HerUtil.celda(fila.VOLUMEN_APROBADO_RESOLUCION.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                        table.AddCell(HerUtil.celda(fila.VOLUMEN_EXTRAIDO.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                        table.AddCell(HerUtil.celda(fila.SALDO.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                    }
                    doc.Add(table);
                }
                table = new PdfPTable(1); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                widths = new float[] { .99f }; table.SetWidths(widths);
                table.AddCell(HerUtil.celda("Supervisión del OSINFOR", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "lightgray", "Negrita"));
                doc.Add(new Paragraph("\n")); doc.Add(table); doc.Add(new Paragraph("\n"));

                table = new PdfPTable(3); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                widths = new float[] { .35f, .01f, .64f }; table.SetWidths(widths);

                if (oCamposView.INF_NUMERO.Trim() == "" || oCamposView.ANIO_SUPER.Trim() == "-")
                {
                    if (oCamposView.INF_NUMERO.Trim() == "" && oCamposView.ANIO_SUPER.Trim() == "-")
                    {
                        table.AddCell(HerUtil.celda("Supervisión:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        table.AddCell(HerUtil.celda("NO", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                    }
                    else
                    {
                        table.AddCell(HerUtil.celda("Supervisión:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        table.AddCell(HerUtil.celda("NO", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                        table.AddCell(HerUtil.celda("Nro Informe:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        table.AddCell(HerUtil.celda((oCamposView.INF_NUMERO.Trim() == "" ? " - " : oCamposView.INF_NUMERO), 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                    }


                    doc.Add(table);
                    table = new PdfPTable(1); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                    widths = new float[] { .99f }; table.SetWidths(widths);
                    table.AddCell(HerUtil.celda("Fiscalización del OSINFOR", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "lightgray", "Negrita"));
                    doc.Add(new Paragraph("\n")); doc.Add(table); doc.Add(new Paragraph("\n"));

                    table = new PdfPTable(3); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                    widths = new float[] { .35f, .01f, .64f }; table.SetWidths(widths);

                    table.AddCell(HerUtil.celda("Archivo Preliminar:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                    table.AddCell(HerUtil.celda(" - ", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));

                }
                else
                {
                    table.AddCell(HerUtil.celda("Supervisión:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                    table.AddCell(HerUtil.celda("SI", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                    table.AddCell(HerUtil.celda("Nro Informe de Supervisión:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                    table.AddCell(HerUtil.celda((oCamposView.INF_NUMERO.Trim() == "" ? " - " : oCamposView.INF_NUMERO), 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                    table.AddCell(HerUtil.celda("Fecha de inicio de la supervisión en campo:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                    table.AddCell(HerUtil.celda(oCamposView.FECHA_INI.ToString(), 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                    table.AddCell(HerUtil.celda("Fecha de término de la supervisión en campo:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                    table.AddCell(HerUtil.celda(oCamposView.FECHA_TERMINO.ToString(), 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));

                    doc.Add(table);
                    table = new PdfPTable(1); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                    widths = new float[] { .99f }; table.SetWidths(widths);
                    table.AddCell(HerUtil.celda("Fiscalización del OSINFOR", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "lightgray", "Negrita"));
                    doc.Add(new Paragraph("\n")); doc.Add(table); doc.Add(new Paragraph("\n"));

                    table = new PdfPTable(3); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                    widths = new float[] { .35f, .01f, .64f }; table.SetWidths(widths);

                    if (oCamposView.DETER_INF_LEGAL == "Archivo" || oCamposView.DETER_INF_LEGAL == "Archivo y nueva supervisión")
                    {
                        table.AddCell(HerUtil.celda("Archivo Preliminar:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        table.AddCell(HerUtil.celda("SI", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                        table.AddCell(HerUtil.celda("Motivo del Archivo:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        table.AddCell(HerUtil.celda(oCamposView.MOTIVO_ARCHIVO, 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));

                        doc.Add(table);

                        if ((ModelSession.GetSession())[0].COD_UGRUPO == "0000001"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000002"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000003"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000004"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000005"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000006"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000007"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000008"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000009"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000010"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000011"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000012"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000014")
                        {
                            if (listNotifArchivo.Count > 0)
                            {
                                table = new PdfPTable(1); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                                widths = new float[] { .99f }; table.SetWidths(widths);
                                table.AddCell(HerUtil.celda("Notificaciones del Archivo Preliminar", 1, 1, 12, Element.ALIGN_CENTER, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                doc.Add(new Paragraph("\n")); doc.Add(table); doc.Add(new Paragraph("\n"));

                                table = new PdfPTable(3); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                                widths = new float[] { .35f, .01f, .64f }; table.SetWidths(widths);

                                doc.Add(table);
                                table = new PdfPTable(4); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                                widths = new float[] { .10f, .35f, .20f, .35f }; table.SetWidths(widths);

                                table.AddCell(HerUtil.celda("N°", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                                table.AddCell(HerUtil.celda("Nro Notificación", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                                table.AddCell(HerUtil.celda("Fecha de Notificación", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                                table.AddCell(HerUtil.celda("Tipo Notificación", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));

                                contador = 1;
                                foreach (var notif in listNotifArchivo)
                                {
                                    table.AddCell(HerUtil.celda((contador++).ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                                    table.AddCell(HerUtil.celda(notif.NUMERO_NOTIFICACION, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                                    table.AddCell(HerUtil.celda(notif.FECHA_NOTIFICACION.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                                    table.AddCell(HerUtil.celda(notif.TIPO_NOTIFICACION, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                                }
                                doc.Add(table); doc.Add(new Paragraph("\n"));
                            }
                        }

                        table = new PdfPTable(3); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                        widths = new float[] { .35f, .01f, .64f }; table.SetWidths(widths);

                        if (oCamposView.MOTIVO_ARCHIVO == "No competencia del OSINFOR" || oCamposView.MOTIVO_ARCHIVO == "Muerte del Titular")
                        {
                            pintaTablaVolinjusPDF(oCamposView, null);
                            pintaTablaInexistenciasPDF(oCamposView);
                        }
                        table.AddCell(HerUtil.celda("Estado Actual del Proceso:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        table.AddCell(HerUtil.celda("Archivo Preliminar", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                    }
                    else
                    {
                        table.AddCell(HerUtil.celda("Archivo Preliminar:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        table.AddCell(HerUtil.celda("NO", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));


                        if (listPAus.Count > 0)
                        {
                            foreach (var filaPAU in listPAus)
                            {
                                if (filaPAU.RD_INICIO_PAU.Trim() == "")
                                {
                                    table.AddCell(HerUtil.celda("Resolución Directoral Inicio PAU:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    table.AddCell(HerUtil.celda(" - ", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                    table.AddCell(HerUtil.celda("Con Medidas Cautelares:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    table.AddCell(HerUtil.celda(" - ", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                    table.AddCell(HerUtil.celda("Con Información Falsa:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    table.AddCell(HerUtil.celda(" - ", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));

                                }
                                else
                                {
                                    table.AddCell(HerUtil.celda("Resolución Directoral Inicio PAU:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    table.AddCell(HerUtil.celda(filaPAU.RD_INICIO_PAU, 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));

                                    if ((Boolean)filaPAU.MEDIDAS_CAUTELARES) { cadMedCau = "SI"; } else { cadMedCau = "NO"; }
                                    if ((Boolean)filaPAU.RD_INICIO_INF_FALSA) { cadInfFalsa = "SI"; } else { cadInfFalsa = "NO"; }

                                    table.AddCell(HerUtil.celda("Con Medidas Cautelares:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    table.AddCell(HerUtil.celda(cadMedCau, 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                    table.AddCell(HerUtil.celda("Con Información Falsa:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    table.AddCell(HerUtil.celda(cadInfFalsa, 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));

                                    doc.Add(table);

                                    if ((ModelSession.GetSession())[0].COD_UGRUPO == "0000001"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000002"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000003"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000004"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000005"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000006"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000007"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000008"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000009"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000010"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000011"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000012"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000014")
                                    {
                                        if (listNotifRDIni.Count > 0)
                                        {
                                            table = new PdfPTable(1); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                                            widths = new float[] { .99f }; table.SetWidths(widths);
                                            table.AddCell(HerUtil.celda("Notificaciones de la Resolución Directoral de Inicio de PAU", 1, 1, 12, Element.ALIGN_CENTER, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            doc.Add(new Paragraph("\n")); doc.Add(table); doc.Add(new Paragraph("\n"));

                                            table = new PdfPTable(4); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                                            widths = new float[] { .10f, .35f, .20f, .35f }; table.SetWidths(widths);

                                            table.AddCell(HerUtil.celda("N°", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                                            table.AddCell(HerUtil.celda("Nro Notificación", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                                            table.AddCell(HerUtil.celda("Fecha de Notificación", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                                            table.AddCell(HerUtil.celda("Tipo Notificación", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));

                                            contador = 1;
                                            foreach (var notif in listNotifRDIni)
                                            {
                                                table.AddCell(HerUtil.celda((contador++).ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                                                table.AddCell(HerUtil.celda(notif.NUMERO_NOTIFICACION, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                                                table.AddCell(HerUtil.celda(notif.FECHA_NOTIFICACION.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                                                table.AddCell(HerUtil.celda(notif.TIPO_NOTIFICACION, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                                            }
                                            doc.Add(table); doc.Add(new Paragraph("\n"));
                                        }
                                    }

                                    table = new PdfPTable(3); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                                    widths = new float[] { .35f, .01f, .64f }; table.SetWidths(widths);

                                    if (filaPAU.RD_TERMINO_PAU.Trim() == "")
                                    {
                                        /*table.AddCell(HerUtil.celda("Resolución Directoral Término PAU:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        table.AddCell(HerUtil.celda(" - ", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        table.AddCell(HerUtil.celda("Archivo:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        table.AddCell(HerUtil.celda(" - ", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        table.AddCell(HerUtil.celda("Caducidad:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        table.AddCell(HerUtil.celda(" - ", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        table.AddCell(HerUtil.celda("Sanción:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        table.AddCell(HerUtil.celda(" - ", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        table.AddCell(HerUtil.celda("Infracciones de la RD de Término:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        table.AddCell(HerUtil.celda(" - ", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));

                                        pintaTablaVolinjusPDF(oCamposView, filaPAU);
                                        */
                                        table.AddCell(HerUtil.celda("Estado Actual del Proceso:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        table.AddCell(HerUtil.celda("PAU en Trámite", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));

                                    }
                                    else
                                    {
                                        table.AddCell(HerUtil.celda("Resolución Directoral Término PAU:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        table.AddCell(HerUtil.celda(filaPAU.RD_TERMINO_PAU, 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));

                                        if (filaPAU.PAU_FIN_TIPO == "Archivo")
                                        {
                                            table.AddCell(HerUtil.celda("Archivo:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            table.AddCell(HerUtil.celda("SI", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        }
                                        else
                                        {
                                            table.AddCell(HerUtil.celda("Archivo:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            table.AddCell(HerUtil.celda("NO", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        }
                                        if ((Boolean)filaPAU.CADUCIDAD && filaPAU.DETER_RECONSIDERACION != "Fundado" && filaPAU.NOM_MOTDET_TFFS != "Imputaciones desvirtuadas (fundado)" && !(Boolean)filaPAU.LEV_CADUC_RD_REC)
                                        {
                                            table.AddCell(HerUtil.celda("Caducidad:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            table.AddCell(HerUtil.celda("SI", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                            cuentaSanciones++;
                                        }
                                        else
                                        {
                                            table.AddCell(HerUtil.celda("Caducidad:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            table.AddCell(HerUtil.celda("NO", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        }
                                        if (filaPAU.PAU_FIN_TIPO == "Sanción")
                                        {
                                            table.AddCell(HerUtil.celda("Sanción:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            table.AddCell(HerUtil.celda("SI", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        }
                                        else
                                        {
                                            table.AddCell(HerUtil.celda("Sanción:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            table.AddCell(HerUtil.celda("NO", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        }
                                        table.AddCell(HerUtil.celda("Infracciones de la RD de Término:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        table.AddCell(HerUtil.celda(filaPAU.INFRACCIONES, 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));

                                        //CEntNotif = new CEntidad();
                                        //CEntInfrac.COD_RDTERMINO = filaPAU.COD_RDTERMINO;
                                        //CEntInfrac.BusCriterio = "CONSULTA_NOTIFICACIONES";
                                        //CEntInfrac.TIPO_DOCUMENTO = "RD_TERMINO";
                                        //listNotificaciones = oCLogica.RegMostrarNotificaciones(CEntInfrac);

                                        doc.Add(table);

                                        if ((ModelSession.GetSession())[0].COD_UGRUPO == "0000001"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000002"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000003"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000004"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000005"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000006"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000007"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000008"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000009"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000010"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000011"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000012"
                        || (ModelSession.GetSession())[0].COD_UGRUPO == "0000014")
                                        {
                                            if (listNotifRDTer.Count > 0)
                                            {
                                                table = new PdfPTable(1); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                                                widths = new float[] { .99f }; table.SetWidths(widths);
                                                table.AddCell(HerUtil.celda("Notificaciones de la Resolución Directoral de Término de PAU", 1, 1, 12, Element.ALIGN_CENTER, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                                doc.Add(new Paragraph("\n")); doc.Add(table); doc.Add(new Paragraph("\n"));

                                                table = new PdfPTable(4); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                                                widths = new float[] { .10f, .35f, .20f, .35f }; table.SetWidths(widths);

                                                table.AddCell(HerUtil.celda("N°", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                                                table.AddCell(HerUtil.celda("Nro Notificación", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                                                table.AddCell(HerUtil.celda("Fecha de Notificación", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                                                table.AddCell(HerUtil.celda("Tipo Notificación", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));

                                                contador = 1;
                                                foreach (var notif in listNotifRDTer)
                                                {
                                                    table.AddCell(HerUtil.celda((contador++).ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                                                    table.AddCell(HerUtil.celda(notif.NUMERO_NOTIFICACION, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                                                    table.AddCell(HerUtil.celda(notif.FECHA_NOTIFICACION.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                                                    table.AddCell(HerUtil.celda(notif.TIPO_NOTIFICACION, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                                                }
                                                doc.Add(table); doc.Add(new Paragraph("\n"));
                                            }
                                        }

                                        table = new PdfPTable(3); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                                        widths = new float[] { .35f, .01f, .64f }; table.SetWidths(widths);
                                        if (filaPAU.RD_RECONSIDERACION.Trim() != "")
                                        {
                                            table.AddCell(HerUtil.celda("Resolución Directoral de Reconsideración:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            table.AddCell(HerUtil.celda((filaPAU.RD_RECONSIDERACION.Trim() == "" ? " - " : filaPAU.RD_RECONSIDERACION), 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                            table.AddCell(HerUtil.celda("Determinación de la RD de Reconsideración:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            table.AddCell(HerUtil.celda((filaPAU.RD_RECONSIDERACION.Trim() == "" ? " - " : filaPAU.DETER_RECONSIDERACION), 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        }
                                        /*
                                                if (filaPAU.RD_ADECUACION != "")
                                        {
                                            cadReporte += "<div><div>Resolución Directoral de Adecuación de Multa:</div><div>" + (filaPAU.RD_ADECUACION.Trim() == "" ? " - " : "<a href='#' onclick=\"descargaPDF('" + filaPAU.DOC_SIADO_REC.Trim() + "')\">" + filaPAU.RD_RECONSIDERACION + "</a>") + "</div></div>";
                                            cadReporte += "<div><div>Fecha de emisión:</div><div>" + (filaPAU.FECHA_ADECUACION.ToString() == "" ? " - " : filaPAU.FECHA_ADECUACION) + "</div></div>";

                                        }
                                        */
                                        if (filaPAU.RD_ADECUACION != "")
                                        {
                                            table.AddCell(HerUtil.celda("Resolución Directoral de Adecuación:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            table.AddCell(HerUtil.celda((filaPAU.RD_ADECUACION.Trim() == "" ? " - " : filaPAU.RD_ADECUACION), 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                            table.AddCell(HerUtil.celda("Fecha de emisión::", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            table.AddCell(HerUtil.celda((filaPAU.FECHA_ADECUACION.ToString() == "" ? " - " : filaPAU.FECHA_ADECUACION.ToString()), 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));

                                        }
                                        if (filaPAU.RES_TFFS.Trim() != "")
                                        {
                                            table.AddCell(HerUtil.celda("Resolución del Tribunal Forestal y de Fauna Silvestre:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            table.AddCell(HerUtil.celda((filaPAU.RES_TFFS.Trim() == "" ? " - " : filaPAU.RES_TFFS), 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                            table.AddCell(HerUtil.celda("Recurso de Apelación:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            table.AddCell(HerUtil.celda((filaPAU.RES_TFFS.Trim() == "" ? " - " : filaPAU.NOM_RECAPE_TFFS), 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                            table.AddCell(HerUtil.celda("Determina:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            table.AddCell(HerUtil.celda((filaPAU.RES_TFFS.Trim() == "" ? " - " : filaPAU.NOM_TIPDET_TFFS), 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                            table.AddCell(HerUtil.celda("Motivo:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            table.AddCell(HerUtil.celda((filaPAU.RES_TFFS.Trim() == "" ? " - " : filaPAU.NOM_MOTDET_TFFS), 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        }

                                        if (filaPAU.PAU_FIN_TIPO == "Archivo" || filaPAU.DETER_RECONSIDERACION == "Fundado")
                                        {
                                            //cadReporte += pintaTablaVolinjus(oCamposView, filaPAU);
                                            cuentaSanciones = 0;
                                            table.AddCell(HerUtil.celda("Estado Actual del Proceso:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            table.AddCell(HerUtil.celda("PAU Concluido - Archivo", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        }
                                        else
                                        {

                                            if (filaPAU.PROVEIDO == "Proveído Firme Acto Administrativo")
                                            {
                                                pintaTablaVolinjusPDF(oCamposView, filaPAU);

                                                table.AddCell(HerUtil.celda("Estado Actual del Proceso:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                                table.AddCell(HerUtil.celda("PAU Concluido - Firme", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            }
                                            else if (filaPAU.PROVEIDO == "Proveído Archivo PAU - Fallecimiento del Titular")
                                            {
                                                pintaTablaVolinjusPDF(oCamposView, filaPAU);

                                                table.AddCell(HerUtil.celda("Estado Actual del Proceso:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                                table.AddCell(HerUtil.celda("PAU Concluido - Archivo (Titular fallecido)", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            }
                                            else if (filaPAU.PROVEIDO == "Proveido Agotada la vía Administrativa" && filaPAU.NOM_MOTDET_TFFS == "Imputaciones desvirtuadas (fundado)")
                                            {
                                                table.AddCell(HerUtil.celda("Estado Actual del Proceso:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                                table.AddCell(HerUtil.celda("PAU Concluido - Agotada via administrativa", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            }
                                            else if (filaPAU.PROVEIDO == "Proveido Agotada la vía Administrativa" && filaPAU.NOM_MOTDET_TFFS != "Imputaciones desvirtuadas (fundado)")
                                            {
                                                cuentaSanciones++;
                                                pintaTablaVolinjusPDF(oCamposView, filaPAU);

                                                table.AddCell(HerUtil.celda("Estado Actual del Proceso:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                                table.AddCell(HerUtil.celda("PAU Concluido - Agotada via administrativa", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                            }
                                            else
                                            {
                                                cuentaSanciones++;
                                                pintaTablaVolinjusPDF(oCamposView, filaPAU);
                                                if (filaPAU.APELA.Trim() != "")
                                                {
                                                    table.AddCell(HerUtil.celda("Estado Actual del Proceso:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                                    table.AddCell(HerUtil.celda("PAU Concluido - Apelación", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                                }
                                                else
                                                {
                                                    table.AddCell(HerUtil.celda("Estado Actual del Proceso:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                                    table.AddCell(HerUtil.celda("PAU Concluido", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (cuentaSanciones > 0)
                            {
                                pintaTablaInexistenciasPDF(oCamposView);
                            }
                        }
                        else
                        {
                            pintaTablaInexistenciasPDF(oCamposView);

                            table.AddCell(HerUtil.celda("Estado Actual del Proceso:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                            table.AddCell(HerUtil.celda("Evaluación Legal", 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        }
                    }
                }
                table.AddCell(HerUtil.celda("Fecha y Hora de Consulta:", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                table.AddCell(HerUtil.celda(oCamposView.FECHA_HORA_CONSULTA, 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));

                //DivReporte.InnerHtml = cadReporte;
                //TabsSelect01(0);
                doc.Add(table);
                doc.Close();

                //if (lblCaducidadView.Text == "SI")
                //{
                //    agregarMarcaAguaImagen(Server.MapPath("~/PlantillaPDF/PlantillaOsinfor.pdf"), Server.MapPath("~/PlantillaPDF/PlantillaOsinforMarca.pdf"), Server.MapPath("~/PlantillaPDF/huella_osinfor_rojo.png"));
                //}
                //else
                //{
                string nombrePDF = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "_" + oCamposView.PERMISO_AUTORIZACION.Replace('.', 'x').Replace(' ', '_').Replace('/', '_').Replace(':', '-').Replace('|', '-').Replace(';', '-').Replace(',', 'x');
                HerUtil.agregarMarcaAguaImagen(Server.MapPath("~/PlantillaPDF/PlantillaOsinfor.pdf"), Server.MapPath("~/PlantillaPDF/" + nombrePDF + ".pdf"), Server.MapPath("~/PlantillaPDF/huella_osinfor_normal.png"));
                //}


                string rut1 = Server.MapPath("~/PlantillaPDF/" + nombrePDF + ".pdf");// @"C:\doc.pdf";

                var mimeType = MimeMapping.GetMimeMapping(rut1);
                return File(rut1, mimeType, nombrePDF + ".pdf");
                /*
                                Response.Clear();
                                Response.ClearContent();
                                Response.ClearHeaders();

                                Response.AddHeader("content-disposition", "attachment;filename=" + nombrePDF + ".pdf");
                                Response.ContentType = "application/pdf";
                                Response.TransmitFile(rut1);
                                Response.End();*/
            }
            catch (Exception)
            {
                return Json("Sucedió un error al construir el documento", JsonRequestBehavior.AllowGet);
            }
        }
        private void pintaTablaVolinjusPDF(Ent_PreVisualizarv1 entMaestro, Ent_PreVisualizar entPAUs)
        {
            Int32 contador = 0;
            List<Ent_PreVisualizar> listInfracciones = new List<Ent_PreVisualizar>();
            try
            {
                if (entPAUs == null)
                {
                    if (entMaestro.INF_NUMERO != "")
                    {
                        listInfracciones = (List<Ent_PreVisualizar>)Session["listInfracciones"];
                    }
                }
                else
                {
                    if (entPAUs.RD_INICIO_PAU.Trim() != "" || entPAUs.RD_TERMINO_PAU.Trim() != "")
                    {
                        listInfracciones = (List<Ent_PreVisualizar>)Session["listInfracciones"];
                    }
                }
                if (listInfracciones.Count > 0)
                {
                    table = new PdfPTable(1); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                    widths = new float[] { .99f }; table.SetWidths(widths);
                    table.AddCell(HerUtil.celda("Volumen Injustificado", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                    doc.Add(table); doc.Add(new Paragraph("\n"));

                    table = new PdfPTable(7); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                    widths = new float[] { .05f, .30f, .11f, .11f, .11f, .16f, .16f }; table.SetWidths(widths);

                    table.AddCell(HerUtil.celda("N°", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                    table.AddCell(HerUtil.celda("Especies", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                    table.AddCell(HerUtil.celda("Volumen aprobado (m³)", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                    table.AddCell(HerUtil.celda("Volumen movilizado (m³)", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                    table.AddCell(HerUtil.celda("Volumen movilizado sin autorización (m³)", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                    table.AddCell(HerUtil.celda("% del volumen movilizado sin autorización con relación al total del volumen movilizado", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                    table.AddCell(HerUtil.celda("% del volumen movilizado sin autorización con relación al total del volumen aprobado ", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));



                    contador = 1;
                    foreach (var infrac in listInfracciones)
                    {
                        table.AddCell(HerUtil.celda((contador++).ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                        table.AddCell(HerUtil.celda((infrac.NOMBRE_CIENTIFICO + " | " + infrac.NOMBRE_COMUN), 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Cursiva"));
                        table.AddCell(HerUtil.celda(infrac.VOLUMEN_APROBADO_RESOLUCION.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                        table.AddCell(HerUtil.celda(infrac.VOLUMEN_EXTRAIDO.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                        table.AddCell(HerUtil.celda(infrac.VOLUMEN.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                        table.AddCell(HerUtil.celda((infrac.VOLUMEN_EXTRAIDO == 0 ? "-" : Math.Round((infrac.VOLUMEN / infrac.VOLUMEN_EXTRAIDO) * 100, 1).ToString()) + "%", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                        table.AddCell(HerUtil.celda((infrac.VOLUMEN_APROBADO_RESOLUCION == 0 ? "-" : Math.Round((infrac.VOLUMEN / infrac.VOLUMEN_APROBADO_RESOLUCION) * 100, 1).ToString()) + "%", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                    }
                    doc.Add(table); doc.Add(new Paragraph("\n"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void pintaTablaInexistenciasPDF(Ent_PreVisualizarv1 entMaestro)
        {
            Int32 contador = 0;
            List<Ent_PreVisualizar> listInexistentes = new List<Ent_PreVisualizar>();
            try
            {
                if (entMaestro.INF_NUMERO != "")
                {
                    listInexistentes = (List<Ent_PreVisualizar>)Session["listInexistentes"];
                    if (listInexistentes.Count > 0)
                    {
                        table = new PdfPTable(1); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                        widths = new float[] { .99f }; table.SetWidths(widths);
                        table.AddCell(HerUtil.celda("Árboles Inexistentes", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        doc.Add(table); doc.Add(new Paragraph("\n"));

                        table = new PdfPTable(5); table.WidthPercentage = 80; table.TotalWidth = page.Width - 90; table.LockedWidth = true;
                        widths = new float[] { .05f, .44f, .17f, .17f, .17f }; table.SetWidths(widths);

                        table.AddCell(HerUtil.celda("N°", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                        table.AddCell(HerUtil.celda("Especies", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                        table.AddCell(HerUtil.celda("Nro árboles supervisados", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                        table.AddCell(HerUtil.celda("Nro de árboles inexistentes", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));
                        table.AddCell(HerUtil.celda("% árboles inexistentes", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "lightgray", "Negrita"));




                        contador = 1;
                        foreach (var infrac in listInexistentes)
                        {
                            table.AddCell(HerUtil.celda((contador++).ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                            table.AddCell(HerUtil.celda((infrac.NOMBRE_CIENTIFICO + " | " + infrac.NOMBRE_COMUN), 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Cursiva"));
                            table.AddCell(HerUtil.celda(infrac.MUESTRA.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                            table.AddCell(HerUtil.celda(infrac.INEX.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                            table.AddCell(HerUtil.celda((infrac.INEX == 0 ? "-" : Math.Round(((Decimal)infrac.MUESTRA / (Decimal)infrac.INEX) * 100, 1).ToString()) + "%", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                        }

                        doc.Add(table); doc.Add(new Paragraph("\n"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public ActionResult DescargarEstadoGuiaTransporte(string hdfFileDescarga, string hdfFileOrigen = "SIADO")
        {
            hdfFileDescarga = hdfFileDescarga ?? "";
            try
            {
                Int32 coincideDoc = 0;
                Ent_PreVisualizarv1 oCamposView = (Ent_PreVisualizarv1)Session["CEntReporteGTF"];
                oCamposView.DOC_SIADO_ARESOL = oCamposView.DOC_SIADO_ARESOL ?? "";
                oCamposView.DOC_SIADO_REFOR = oCamposView.DOC_SIADO_REFOR ?? "";
                oCamposView.DOC_SIADO_INFORME = oCamposView.DOC_SIADO_INFORME ?? "";
                oCamposView.DOC_SIADO_ILEGAL = oCamposView.DOC_SIADO_ILEGAL ?? "";

                List<Ent_PreVisualizar> listPAus = (List<Ent_PreVisualizar>)Session["listPAus"];
                if (listPAus == null) { listPAus = new List<Ent_PreVisualizar>(); }

                String RutaSIADO = Server.MapPath("~/Ruta_SIADO/");

                if (hdfFileOrigen == "SIADO-REGION")
                {
                    RutaSIADO = Server.MapPath("~/Ruta_SIADO_Region/");
                }

                if (hdfFileDescarga == "0" || hdfFileDescarga == "")
                {

                    return Json("No se ha cargado el documento", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    foreach (var itemPAU in listPAus)
                    {
                        if (itemPAU.DOC_SIADO_INI.Trim() == hdfFileDescarga.Trim() || itemPAU.DOC_SIADO_TER.Trim() == hdfFileDescarga.Trim()
                            || itemPAU.DOC_SIADO_REC.Trim() == hdfFileDescarga.Trim())
                        {
                            coincideDoc++;
                        }
                    }

                    String strFileName = this.revisaArchivos(RutaSIADO, hdfFileDescarga + ".*");
                    if (strFileName.Trim() != ""
                        && (hdfFileDescarga.Trim() == oCamposView.DOC_SIADO_ARESOL.Trim()
                        || hdfFileDescarga.Trim() == oCamposView.DOC_SIADO_REFOR.Trim()
                        || hdfFileDescarga.Trim() == oCamposView.DOC_SIADO_INFORME.Trim()
                        || hdfFileDescarga.Trim() == oCamposView.DOC_SIADO_ILEGAL.Trim()
                        || coincideDoc > 0))
                    {

                        //regAccionReporteGTF("DOWNLOAD", "COD_THABILITANTE=" + oCamposView.COD_THABILITANTE + "; NUM_POA=" + oCamposView.NUM_POA.ToString() + "; CODDOC=" + strFileName.Trim(), oCamposView.COD_THABILITANTE, oCamposView.NUM_POA.ToString());
                        string FilePath = RutaSIADO + strFileName;

                        var mimeType = MimeMapping.GetMimeMapping(FilePath);
                        return File(FilePath, mimeType, strFileName);
                    }
                    else
                    {
                        return Json("No existe la ruta de descarga", JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region "Historial de titulo habilitante"
        public ActionResult Rpt_Historial_Titulo_Habilitante()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RptHistorialTHGetAll(string criterio, string valor)
        {
            Ent_Reporte_Historial_TH oCampos = new Ent_Reporte_Historial_TH();
            List<Ent_Reporte_Historial_TH> list;

            try
            {
                oCampos.BusCriterio = criterio;
                oCampos.BusValor = valor;
                oCampos.NUM_POA = 0;
                Log_RHistorial_TH log = new Log_RHistorial_TH();
                list = log.Log_listarTH(oCampos);
                Session["listTH"] = null;
                Session["listTH"] = list;
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = "",
                    success = false,
                    msj = ex.Message
                });
            }
            var jsonResult = Json(new
            {
                data = list.ToArray(),
                success = true,
                msj = ""
            });
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult _Rpt_HistorialTHDetalle(string COD_THABILITANTE)
        {
            Ent_Reporte_Historial_TH oCEntidadTemp = new Ent_Reporte_Historial_TH();
            Ent_Reporte_Historial_TH oCEntidad1 = new Ent_Reporte_Historial_TH();
            Log_RHistorial_TH oCLogica = new Log_RHistorial_TH();
            oCEntidadTemp.BusValor = COD_THABILITANTE;
            oCEntidadTemp.BusCriterio = "COD_THABILITANTE";
            oCEntidadTemp.NUM_POA = 0;
            oCEntidad1 = oCLogica.log_TH_Titulo_Habilitante(oCEntidadTemp);
            if (oCEntidad1 == null)
            {
                oCEntidad1 = new Ent_Reporte_Historial_TH();
            }
            if (oCEntidad1.ListPOATH == null) oCEntidad1.ListPOATH = new List<Ent_Reporte_Historial_TH>();

            if (oCEntidad1.ListINFTIT != null)
            {
                if (oCEntidad1.ListINFTIT.Count > 0)
                {
                    oCEntidadTemp = new Ent_Reporte_Historial_TH();
                    oCEntidadTemp.BusCriterio = "ADENDAS_TH";
                    oCEntidadTemp.BusValor = oCEntidad1.COD_THABILITANTE;
                    oCEntidadTemp.NUM_POA = 0;
                    List<Ent_Reporte_Historial_TH> listAdenda = new List<Ent_Reporte_Historial_TH>();
                    listAdenda = oCLogica.log_Adenda_Titular(oCEntidadTemp);
                    oCEntidad1.ListAdendas = listAdenda;

                    //domicilio
                    oCEntidadTemp = new Ent_Reporte_Historial_TH();
                    oCEntidadTemp.BusCriterio = "DOMICILIO_TH";
                    oCEntidadTemp.BusValor = oCEntidad1.COD_THABILITANTE;
                    oCEntidadTemp.NUM_POA = 0;
                    List<Ent_Reporte_Historial_TH> listDomicilio = new List<Ent_Reporte_Historial_TH>();
                    listDomicilio = oCLogica.log_Domicilio_Titular(oCEntidadTemp);
                    oCEntidad1.ListDomicilio = listDomicilio;
                }
            }

            Session["oCEntidad1"] = oCEntidad1;
            Session["COD_THABILITANTE"] = oCEntidad1.COD_THABILITANTE;
            return PartialView(oCEntidad1);
        }
        // ResumenRecaudacionCobranza
        public ActionResult ResumenRecaudacionCobranza(int id)
        {
            Ent_Reporte_Historial_TH oCEntidadTemp = new Ent_Reporte_Historial_TH();
            Ent_Reporte_Historial_TH vm = new Ent_Reporte_Historial_TH();
            Log_RHistorial_TH oCLogica = new Log_RHistorial_TH();
            oCEntidadTemp.RESIDENTITY = id;

            vm.ListDEUDAS = oCLogica.log_ResumenDeuda(oCEntidadTemp);
            vm.ListPAGOS = oCLogica.log_ResumenPagos(oCEntidadTemp);
            vm.ListCRONOGRAMA = oCLogica.log_ResumenCronograma(oCEntidadTemp);
            vm.ListCOMPENSACION = oCLogica.log_ResumenCompensacion(oCEntidadTemp);
            vm.ListCRONOCOMPENSACION = oCLogica.log_ResumenCronoCompensacion(oCEntidadTemp);
            //            return PartialView("~/Areas/General/Views/ReporteFiscalizacion/_sharedRptFiscalizacionPau/_renderDetalle.cshtml", lstvm);
            return PartialView("~/Areas/General/Views/Reportes/_sharedResumenMultas/_renderResumenMultas.cshtml", vm);
        }


        [HttpGet]
        public ActionResult _Rpt_HistorialTHDetalle_Especie(int numPoa)
        {
            Log_RHistorial_TH oCLogica = new Log_RHistorial_TH();
            Ent_Reporte_Historial_TH oCEntidadTemp = new Ent_Reporte_Historial_TH();
            string htmlText = "";
            string msj = "";
            bool success = false;
            try
            {
                oCEntidadTemp.BusValor = (String)Session["COD_THABILITANTE"];
                oCEntidadTemp.BusCriterio = "ESPECIE_DETALLE";
                oCEntidadTemp.NUM_POA = numPoa;
                List<Ent_Reporte_Historial_TH> listEspecie = new List<Ent_Reporte_Historial_TH>();
                listEspecie = oCLogica.log_Especies_Detalle(oCEntidadTemp);
                htmlText = this.Especies(listEspecie);
                success = true;
            }
            catch (Exception ex)
            {
                msj = ex.Message;
            }
            return Json(new { success, msj, data = htmlText }, JsonRequestBehavior.AllowGet);
        }
        private String Especies(List<Ent_Reporte_Historial_TH> listEspecie)
        {
            StringBuilder cadena;
            cadena = new StringBuilder();
            String stilo = "width: 99% ; font-size:12; border: 1px solid #ddd; border-collapse: collapse;";
            cadena.Append("<h3>Especies Aprobadas en el POA</h3><br/>");
            if (listEspecie.Count > 0)
            {
                cadena.Append("<table class=Grilla style='" + stilo + "' cellspacin=0 >");
                cadena.Append("<tr>");
                cadena.Append("<th class=tdcenter style=width:" + 5 + "% >");
                cadena.Append("N°");
                cadena.Append("</th>");
                cadena.Append("<th class=tdcenter style=width:" + 20 + "% >");
                cadena.Append("Especies");
                cadena.Append("</th>");
                cadena.Append("<th class=tdcenter style=width:" + 15 + "% >");
                cadena.Append("N° de Arboles");
                cadena.Append("</th>");
                cadena.Append("<th class=tdcenter style=width:" + 15 + "% >");
                cadena.Append("Volumen (m3)");
                cadena.Append("</th>");
                cadena.Append("</tr>");
                for (int i = 0; i < listEspecie.Count; i++)
                {
                    cadena.Append("<tr>");
                    cadena.Append("<td class=tdcenterAli style=width:" + 5 + "% >");
                    cadena.Append(i + 1);
                    cadena.Append("</td>");
                    cadena.Append("<td class=tdleftAli style=width:" + 5 + "% >");
                    cadena.Append(listEspecie[i].NOMBRE_COMUN);
                    cadena.Append("</td>");
                    cadena.Append("<td class=tdcenterAli style=width:" + 20 + "% >");
                    cadena.Append(listEspecie[i].NUMERO_ARBOLES);
                    cadena.Append("</td>");
                    cadena.Append("<td class=tdcenterAli style=width:" + 15 + "% >");
                    cadena.Append(listEspecie[i].VOLUMEN_AUTORIZADO);
                    cadena.Append("</td>");
                    cadena.Append("</tr>");
                }
                cadena.Append("</table>");
                cadena.Append("<br/>");
            }
            else
            {
                cadena.Append("No se encontraron Especies para el presente POA <br/><br/>");
            }
            return cadena.ToString();
        }
        /// <summary>
        /// Detalle del listado POA, en relacion a N° INFORME
        /// </summary>
        /// <param name="COD_INFORME"></param>
        /// <param name="titular"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult _Rpt_HistorialTHDetalle_SelectInf(string COD_INFORME, string titular)
        {
            Log_RHistorial_TH oCLogica = new Log_RHistorial_TH();
            Ent_Reporte_Historial_TH oCEntidadTemp = new Ent_Reporte_Historial_TH();
            string htmlText = "";
            string msj = "";
            bool success = false;
            titular = titular ?? "";
            try
            {
                oCEntidadTemp.BusValor = COD_INFORME;
                oCEntidadTemp.BusCriterio = "INF_TITULAR_V2";
                oCEntidadTemp.NUM_POA = 0;
                List<Ent_Reporte_Historial_TH> ListInfSupTh = new List<Ent_Reporte_Historial_TH>();
                ListInfSupTh = oCLogica.Log_List_THDetalle(oCEntidadTemp);
                htmlText = this.Inf_Sup_TH_v2(ListInfSupTh, titular);
                success = true;
            }
            catch (Exception ex)
            {
                msj = ex.Message;
            }
            return Json(new { success, msj, data = htmlText }, JsonRequestBehavior.AllowGet);
        }
        public String Inf_Sup_TH_v2(List<Ent_Reporte_Historial_TH> oCEntidad_List, string titular)
        {
            Log_RHistorial_TH oCLogica = new Log_RHistorial_TH();
            List<Ent_Reporte_Historial_TH> ListInfArboles;
            StringBuilder cadena = new StringBuilder();
            String list_inf = "";
            String Estado_proceso = "Pendiente";
            if (oCEntidad_List != null)
            {
                if (oCEntidad_List.Count > 0)
                {

                    cadena.Append("<h3>SUPERVISIÓN</h3><br/>");
                    cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                    cadena.Append("<div>Supervisado</div><div>:</div>");
                    cadena.Append("</div>");
                    cadena.Append("<div class=bloqueFormContent2Right > <div> Si </div> </div>");
                    cadena.Append(" </div>");

                    for (int i = 0; i < oCEntidad_List.Count; i++)
                    {
                        String titlePOA = "";
                        oCEntidad_List[i].NUM_POA_STRING = oCEntidad_List[i].NUM_POA_STRING ?? "";
                        if (oCEntidad_List[i].NUM_POA_STRING.Trim() != "")
                        {
                            titlePOA = " " + oCEntidad_List[i].NUM_POA_STRING;
                        }
                        cadena.Append("<br/><hr><div class=bloqueFormTitulo ><div>Supervisión " + titlePOA + "</div></div>");
                        cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                        cadena.Append("<div>N° Informe Supervisión</div><div>:</div>");
                        cadena.Append("</div>");
                        cadena.Append("<div class=bloqueFormContent2Right > <div> ");
                        //cadena.Append(oCEntidad_List[i].NUMERO);
                        /* LinkButton linkInforme = new LinkButton();
                         linkInforme.ID = "lkDocInforme_" + i;
                         linkInforme.CommandArgument = oCEntidad_List[i].COD_DOCINFORME.ToString();
                         linkInforme.Text = oCEntidad_List[i].NUMERO;
                         linkInforme.Click += new System.EventHandler(btn_DESCARGASIADO); //+= btn_DESCARGASIADO;
                         linkInforme.Attributes.Add("runat", "server");*/
                        // linkInforme.runat
                        //linkInforme.ToolTip = "Descargar Informe";
                        // linkInforme.OnClientClick = btn_DESCARGASIADO;
                        /* using (StringWriter sw = new StringWriter(cadena))
                         {
                             using (HtmlTextWriter tw = new HtmlTextWriter(sw))
                             {
                                 linkInforme.RenderControl(tw);
                             }
                         }*/
                        //this.Form.Controls.Add(linkInforme);
                        //lblInformeTH.Controls.Add(linkInforme);
                        cadena.Append(oCEntidad_List[i].NUMERO);
                        cadena.Append("</div></div>");
                        cadena.Append(" </div>");
                        cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                        cadena.Append("<div>Supervisor</div><div>:</div>");
                        cadena.Append("</div>");
                        cadena.Append("<div class=bloqueFormContent2Right > <div> " + oCEntidad_List[i].Supervisor + " </div> </div>");
                        cadena.Append(" </div>");
                        cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                        cadena.Append("<div>Entidad que Superviso</div><div>:</div>");
                        cadena.Append("</div>");
                        cadena.Append("<div class=bloqueFormContent2Right > <div> " + oCEntidad_List[i].ESTADO_ORIGEN_TIPO + " </div> </div>");
                        cadena.Append(" </div>");
                        cadena.Append("<div class=bloqueFormTitulo ><div> Detalle de árboles supervisados</div></div>");

                        Ent_Reporte_Historial_TH oCEntidadTem = new Ent_Reporte_Historial_TH();
                        oCEntidadTem.BusValor = oCEntidad_List[i].COD_INFORME;
                        oCEntidadTem.BusCriterio = "ARBOLES_SUPERV";
                        oCEntidadTem.NUM_POA = 0;
                        ListInfArboles = new List<Ent_Reporte_Historial_TH>();
                        ListInfArboles = oCLogica.Log_listarArboles(oCEntidadTem);
                        String styleSupTable = "width: 95% ; font-size:12; border: 1px solid #ddd; border-collapse: collapse;";

                        if (ListInfArboles.Count > 0)
                        {
                            /**
                             * aqui creamos la tabla para los arboles supervisados
                             */
                            cadena.Append("<table class=Grilla cellspacin=0 style='" + styleSupTable + "' >");
                            cadena.Append("<tr>");
                            cadena.Append("<th class=tdcenter style=width:" + 5 + "% >");
                            cadena.Append("N°");
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenter style=width:" + 15 + "% >");
                            cadena.Append("Especie");
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                            cadena.Append("N° árboles supervisados");
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                            cadena.Append("N° árboles inexistentes");
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                            cadena.Append("% de inexistencia");
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                            cadena.Append("N° árboles en pie");
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                            cadena.Append("N° árboles tumbados");
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                            cadena.Append("N° árboles en tocón");
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                            cadena.Append("N° árboles no evaluados");
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                            cadena.Append("N° árboles sin datos");
                            cadena.Append("</th>");
                            cadena.Append("</tr>");
                            int total_especie = 0;
                            int total_inex = 0;
                            int total_pie = 0;
                            int total_tumbado = 0;
                            int total_tocon = 0;
                            int total_noeva = 0;
                            int total_sindat = 0;

                            for (int y = 0; y < ListInfArboles.Count; y++)
                            {
                                int num = y + 1;
                                cadena.Append("<tr>");
                                cadena.Append("<td class=tdcenterAli style=width:" + 5 + "% >");
                                cadena.Append(num);
                                cadena.Append("</td>");
                                cadena.Append("<td class=tdleftAli style=width:" + 15 + "% >");
                                cadena.Append(ListInfArboles[y].NOMBRE_COMUN);
                                cadena.Append("</td>");
                                cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                cadena.Append(ListInfArboles[y].ESPECIES);
                                cadena.Append("</td>");
                                cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                cadena.Append(ListInfArboles[y].INXISTENCIA);
                                cadena.Append("</td>");
                                cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                cadena.Append(ListInfArboles[y].PORCENTAJE_INEX);
                                cadena.Append("</td>");
                                cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                cadena.Append(ListInfArboles[y].EN_PIE);
                                cadena.Append("</td>");
                                cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                cadena.Append(ListInfArboles[y].TUMBADO);
                                cadena.Append("</td>");
                                cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                cadena.Append(ListInfArboles[y].TOCON);
                                cadena.Append("</td>");
                                cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                cadena.Append(ListInfArboles[y].NO_EVALUADO);
                                cadena.Append("</td>");
                                cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                cadena.Append(ListInfArboles[y].SIN_DATOS);
                                cadena.Append("</td>");
                                cadena.Append("</tr>");
                                total_especie = total_especie + ListInfArboles[y].ESPECIES;
                                total_inex = total_inex + ListInfArboles[y].INXISTENCIA;
                                total_pie = total_pie + ListInfArboles[y].EN_PIE;
                                total_tumbado = total_tumbado + ListInfArboles[y].TUMBADO;
                                total_tocon = total_tocon + ListInfArboles[y].TOCON;
                                total_sindat = total_sindat + ListInfArboles[y].SIN_DATOS;

                            }
                            cadena.Append("<tr>");
                            cadena.Append("<th class=tdcenterAli style=width:" + 5 + "% >");
                            cadena.Append("");
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdleftAli style=width:" + 15 + "% >");
                            cadena.Append("TOTAL :");
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenterAli style=width:" + 10 + "% >");
                            cadena.Append(total_especie);
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenterAli style=width:" + 10 + "% >");
                            cadena.Append(total_inex);
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenterAli style=width:" + 10 + "% >");
                            cadena.Append("");
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenterAli style=width:" + 10 + "% >");
                            cadena.Append(total_pie);
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenterAli style=width:" + 10 + "% >");
                            cadena.Append(total_tumbado);
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenterAli style=width:" + 10 + "% >");
                            cadena.Append(total_tocon);
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenterAli style=width:" + 10 + "% >");
                            cadena.Append(total_noeva);
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenterAli style=width:" + 10 + "% >");
                            cadena.Append(total_sindat);
                            cadena.Append("</th>");
                            cadena.Append("</tr>");
                            cadena.Append("</table>");
                        }
                        else
                        {
                            cadena.Append("<div>No se encontraron arboles supervisados para el informe de supervision</div>");
                        }
                        cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                        cadena.Append("<div>Observaciones</div><div>:</div>");
                        cadena.Append("</div>");
                        cadena.Append("<div class=bloqueFormContent2Right > <div> " + oCEntidad_List[i].OBSERVACIONES + " </div> </div>");
                        cadena.Append(" </div>");
                        cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                        cadena.Append("<div>Con indicios de aprovechamiento</div><div>:</div>");
                        cadena.Append("</div>");
                        cadena.Append("<div class=bloqueFormContent2Right > <div> - </div> </div>");
                        cadena.Append(" </div>");
                        cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                        cadena.Append("<div>Con presencia de cambio de uso</div><div>:</div>");
                        cadena.Append("</div>");
                        cadena.Append("<div class=bloqueFormContent2Right > <div> - </div> </div>");

                        oCEntidadTem = new Ent_Reporte_Historial_TH();
                        oCEntidadTem.BusValor = oCEntidad_List[i].COD_INFORME;
                        oCEntidadTem.BusCriterio = "INFORME_VOL_INJUSTIFICADO";
                        oCEntidadTem.NUM_POA = 0;
                        oCEntidadTem = oCLogica.log_vol_injust(oCEntidadTem);

                        if (oCEntidadTem.ListInexistencia.Count > 0)
                        {
                            oCEntidadTem.ListInexistencia[0].INEX_AGUAJAL = oCEntidadTem.ListInexistencia[0].INEX_AGUAJAL ?? "";
                            oCEntidadTem.ListInexistencia[0].INEX_PASTIZAL = oCEntidadTem.ListInexistencia[0].INEX_PASTIZAL ?? "";
                            oCEntidadTem.ListInexistencia[0].INEX_INACCESIBLE = oCEntidadTem.ListInexistencia[0].INEX_INACCESIBLE ?? "";
                            oCEntidadTem.ListInexistencia[0].INEX_OTROS = oCEntidadTem.ListInexistencia[0].INEX_OTROS ?? "";
                            if (oCEntidadTem.ListInexistencia[0].INEX_AGUAJAL.Trim() != "" || oCEntidadTem.ListInexistencia[0].INEX_PASTIZAL.Trim() != "" || oCEntidadTem.ListInexistencia[0].INEX_INACCESIBLE.Trim() != "" || oCEntidadTem.ListInexistencia[0].INEX_OTROS.Trim() != "")
                            {
                                cadena.Append("<div class=bloqueFormTitulo ><div>Inexistencia de individuos</div></div>");
                                cadena.Append("<table class=Grilla cellspacin=0 style='" + styleSupTable + "' >");
                                cadena.Append("<tr>");
                                cadena.Append("<th class=tdcenter style=width:" + 30 + "% >");
                                cadena.Append("Condiciones de área");
                                cadena.Append("</th>");
                                cadena.Append("<th class=tdcenter style=width:" + 20 + "% >");
                                cadena.Append("%");
                                cadena.Append("</th>");
                                cadena.Append("<th class=tdcenter style=width:" + 20 + "% >");
                                cadena.Append("N° árboles no ubicados");
                                cadena.Append("</th>");
                                cadena.Append("<th class=tdcenter style=width:" + 20 + "% >");
                                cadena.Append("Observaciones");
                                cadena.Append("</th>");
                                cadena.Append("</tr>");

                                if (oCEntidadTem.ListInexistencia[0].INEX_AGUAJAL.Trim() != "")
                                {
                                    cadena.Append("<tr>");
                                    cadena.Append("<td class=tdleftAli style=width:" + 30 + "% >");
                                    cadena.Append(oCEntidadTem.ListInexistencia[0].INEX_AGUAJAL);
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 20 + "% >");
                                    cadena.Append(oCEntidadTem.ListInexistencia[0].PORC_AGUAJAL);
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 20 + "% >");
                                    cadena.Append(oCEntidadTem.ListInexistencia[0].NUM_ARBNOU_AGUAJAL);
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 20 + "% >");
                                    cadena.Append(oCEntidadTem.ListInexistencia[0].AGUAJAL_OBSERV);
                                    cadena.Append("</td>");
                                    cadena.Append("</tr>");
                                }

                                if (oCEntidadTem.ListInexistencia[0].INEX_PASTIZAL.Trim() != "")
                                {
                                    cadena.Append("<tr>");
                                    cadena.Append("<td class=tdleftAli style=width:" + 30 + "% >");
                                    cadena.Append(oCEntidadTem.ListInexistencia[0].INEX_PASTIZAL);
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 20 + "% >");
                                    cadena.Append(oCEntidadTem.ListInexistencia[0].PORC_PASTIZAL);
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 20 + "% >");
                                    cadena.Append(oCEntidadTem.ListInexistencia[0].NUM_ARBNOU_PASTIZAL);
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 20 + "% >");
                                    cadena.Append(oCEntidadTem.ListInexistencia[0].PASTIZAL_OBSERV);
                                    cadena.Append("</td>");
                                    cadena.Append("</tr>");
                                }

                                if (oCEntidadTem.ListInexistencia[0].INEX_INACCESIBLE.Trim() != "")
                                {
                                    cadena.Append("<tr>");
                                    cadena.Append("<td class=tdleftAli style=width:" + 30 + "% >");
                                    cadena.Append(oCEntidadTem.ListInexistencia[0].INEX_INACCESIBLE);
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 20 + "% >");
                                    cadena.Append(oCEntidadTem.ListInexistencia[0].PORC_INACCESIBLE);
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 20 + "% >");
                                    cadena.Append(oCEntidadTem.ListInexistencia[0].NUM_ARBNOU_INACCESIBLE);
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 20 + "% >");
                                    cadena.Append(oCEntidadTem.ListInexistencia[0].INACCESIBLE_OBSERV);
                                    cadena.Append("</td>");
                                    cadena.Append("</tr>");
                                }

                                if (oCEntidadTem.ListInexistencia[0].INEX_OTROS.Trim() != "")
                                {
                                    cadena.Append("<tr>");
                                    cadena.Append("<td class=tdleftAli style=width:" + 30 + "% >");
                                    cadena.Append(oCEntidadTem.ListInexistencia[0].INEX_OTROS);
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 20 + "% >");
                                    cadena.Append(oCEntidadTem.ListInexistencia[0].PORC_OTROS);
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 20 + "% >");
                                    cadena.Append(oCEntidadTem.ListInexistencia[0].NUM_ARBNOU_OTROS);
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 20 + "% >");
                                    cadena.Append(oCEntidadTem.ListInexistencia[0].OTROS_OBSERV);
                                    cadena.Append("</td>");
                                    cadena.Append("</tr>");
                                }
                                cadena.Append("</table>");
                            }
                        }
                        if (oCEntidadTem.ListVolumenInexistencia.Count > 0)
                        {
                            cadena.Append("<div class=bloqueFormTitulo ><div>Volumen injustificado</div></div>");
                            cadena.Append("<table class=Grilla cellspacin=0 style='" + styleSupTable + "' >");
                            cadena.Append("<tr>");
                            cadena.Append("<th class=tdcenter style=width:" + 5 + "% >");
                            cadena.Append("N°");
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenter style=width:" + 20 + "% >");
                            cadena.Append("Nombre Cientifico Especie");
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenter style=width:" + 20 + "% >");
                            cadena.Append("Nombre Común Especie");
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                            cadena.Append("Volumen (m³)");
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                            cadena.Append("POA");
                            cadena.Append("</th>");
                            cadena.Append("<th class=tdcenter style=width:" + 30 + "% >");
                            cadena.Append("Observaciones");
                            cadena.Append("</th>");
                            cadena.Append("</tr>");
                            for (int y = 0; y < oCEntidadTem.ListVolumenInexistencia.Count; y++)
                            {
                                int num = y + 1;
                                cadena.Append("<tr>");
                                cadena.Append("<td class=tdcenterAli style=width:" + 5 + "% >");
                                cadena.Append(num);
                                cadena.Append("</td>");
                                cadena.Append("<td class=tdleftAli style=width:" + 20 + "% >");
                                cadena.Append(oCEntidadTem.ListVolumenInexistencia[y].Nombre_Cienti);
                                cadena.Append("</td>");
                                cadena.Append("<td class=tdcenterAli style=width:" + 20 + "% >");
                                cadena.Append(oCEntidadTem.ListVolumenInexistencia[y].Nombre_Comun);
                                cadena.Append("</td>");
                                cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                cadena.Append(oCEntidadTem.ListVolumenInexistencia[y].VOLUMEN_ARBOLES);
                                cadena.Append("</td>");
                                cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                cadena.Append(oCEntidadTem.ListVolumenInexistencia[y].NUM_POA_STRING);
                                cadena.Append("</td>");
                                cadena.Append("<td class=tdcenterAli style=width:" + 30 + "% >");
                                cadena.Append(oCEntidadTem.ListVolumenInexistencia[y].OBSERVACIONES);
                                cadena.Append("</td>");
                                cadena.Append("</tr>");
                            }
                            cadena.Append("</table>");
                            cadena.Append("<br/>");

                        }
                        //fiscalización
                        cadena.Append(" </div>");
                        oCEntidad_List[i].ARCH_COD_FCTIPO = oCEntidad_List[i].ARCH_COD_FCTIPO ?? "";
                        if (oCEntidad_List[i].ARCH_COD_FCTIPO.Trim() != "" && oCEntidad_List[i].ARCH_COD_FCTIPO.Trim() != null)
                        {
                            cadena.Append("<div class=bloqueFormTitulo ><div>R.D. Archivo del Informe de Supervision</div></div>");

                            cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                            cadena.Append("<div>Número de Resolución Directoral</div><div>:</div>");
                            cadena.Append("</div>");
                            cadena.Append("<div class=bloqueFormContent2Right > <div>" + oCEntidad_List[i].ARCH_NUM_RESOLUCION + "</div> </div>");
                            cadena.Append(" </div>");

                            cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                            cadena.Append("<div>Fecha Emisión</div><div>:</div>");
                            cadena.Append("</div>");
                            cadena.Append("<div class=bloqueFormContent2Right > <div>" + oCEntidad_List[i].ARCH_FECHA_RD + "</div> </div>");
                            cadena.Append(" </div>");

                            cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                            cadena.Append("<div>Evidencia de irregularidad cuya sanción no es competencia de OSINFOR</div><div>:</div>");
                            cadena.Append("</div>");
                            cadena.Append("<div class=bloqueFormContent2Right > <div>" + oCEntidad_List[i].ARCH_EVIDENCIA_IRRE + "</div> </div>");
                            cadena.Append(" </div>");

                            cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                            cadena.Append("<div>Sin indicios de infracción</div><div>:</div>");
                            cadena.Append("</div>");
                            cadena.Append("<div class=bloqueFormContent2Right > <div>" + oCEntidad_List[i].ARCH_SIN_INFRACCION + "</div> </div>");
                            cadena.Append(" </div>");

                            cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                            cadena.Append("<div>Buen manejo</div><div>:</div>");
                            cadena.Append("</div>");
                            cadena.Append("<div class=bloqueFormContent2Right > <div>" + oCEntidad_List[i].ARCH_BUEN_MANEJO + "</div> </div>");
                            cadena.Append(" </div>");

                            cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                            cadena.Append("<div>Deficiente notificación</div><div>:</div>");
                            cadena.Append("</div>");
                            cadena.Append("<div class=bloqueFormContent2Right > <div>" + oCEntidad_List[i].ARCH_DEFICIENTE_NOT + "</div> </div>");
                            cadena.Append(" </div>");

                            cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                            cadena.Append("<div>Deficiencia técnica</div><div>:</div>");
                            cadena.Append("</div>");
                            cadena.Append("<div class=bloqueFormContent2Right > <div>" + oCEntidad_List[i].ARCH_DEFICIENCIA_TEC + "</div> </div>");
                            cadena.Append(" </div>");

                            cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                            cadena.Append("<div>Otros</div><div>:</div>");
                            cadena.Append("</div>");
                            cadena.Append("<div class=bloqueFormContent2Right > <div>" + oCEntidad_List[i].OTROS + "</div> </div>");
                            cadena.Append(" </div>");
                        }
                        else
                        {
                            oCEntidad_List[i].RD_INICIO = oCEntidad_List[i].RD_INICIO ?? "";
                            if (oCEntidad_List[i].RD_INICIO.Trim() != "")
                            {
                                cadena.Append("<div class=bloqueFormTitulo ><div>R.D. de Inicio</div></div>");
                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Número de Resolución Directoral</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right > <div><p>" + oCEntidad_List[i].RD_INICIO + "</p></div> </div>");
                                cadena.Append(" </div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Fecha Emisión</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right > <div>" + oCEntidad_List[i].FECHA_RDINICIO + "</div> </div>");
                                cadena.Append(" </div>");

                                //Para las notificaciones de las R.D. inicio PAU
                                oCEntidadTem = new Ent_Reporte_Historial_TH();
                                oCEntidadTem.BusValor = oCEntidad_List[i].COD_RESODIREC_Inicio;
                                oCEntidadTem.BusCriterio = "NOTIFICACION_TITULAR";
                                oCEntidadTem.NUM_POA = 0;
                                oCEntidadTem = oCLogica.Log_Notificaciones(oCEntidadTem);

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Fecha de Notificación</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right > <div>");
                                if (oCEntidadTem.FECHA_NOT != null)
                                {
                                    cadena.Append(oCEntidadTem.FECHA_NOT);
                                }
                                else
                                {
                                    cadena.Append("-");
                                }
                                cadena.Append("</div> </div>");
                                cadena.Append(" </div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Persona Notificada</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right > <div>");
                                if (oCEntidadTem.PERSONA_NOT != null)
                                {
                                    cadena.Append(oCEntidadTem.PERSONA_NOT);
                                }
                                else
                                {
                                    cadena.Append("-");
                                }
                                cadena.Append("</div> </div>");
                                cadena.Append(" </div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Relación con el titular de la persona notificada</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right > <div>");
                                if (oCEntidadTem.PARENTESCO != null)
                                {
                                    cadena.Append(oCEntidadTem.PARENTESCO);
                                }
                                else
                                {
                                    cadena.Append("-");
                                }
                                cadena.Append("</div> </div>");
                                cadena.Append(" </div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Infracciones por las que se inicia PAU</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].INFRACCIONES + "</div> </div>");
                                cadena.Append(" </div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Con Medidas Cautelares</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].MEDIDAS_CAUTELARES + "</div> </div>");
                                cadena.Append(" </div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Con Causal de Caducidad</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].CAUSAL_CADUCIDAD + "</div> </div>");
                                cadena.Append(" </div>");

                                cadena.Append("<div class=bloqueFormTitulo ><div>Especies con volumen injustificado</div></div>");
                                cadena.Append("<table class=Grilla cellspain=0 style='" + styleSupTable + "' >");
                                cadena.Append("<tr>");
                                cadena.Append("<th class=tdcenter style=width:" + 5 + "% >");
                                cadena.Append("N°");
                                cadena.Append("</th>");
                                cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                                cadena.Append("Artículo");
                                cadena.Append("</th>");
                                cadena.Append("<th class=tdcenter style=width:" + 5 + "% >");
                                cadena.Append("Incisos)");
                                cadena.Append("</th>");
                                cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                                cadena.Append("Volumen (m3)");
                                cadena.Append("</th>");
                                cadena.Append("<th class=tdcenter style=width:" + 20 + "% >");
                                cadena.Append("Especie");
                                cadena.Append("</th>");
                                cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                                cadena.Append("Área (ha)");
                                cadena.Append("</th>");
                                cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                                cadena.Append("Num. Individuos");
                                cadena.Append("</th>");
                                cadena.Append("<th class=tdcenter style=width:" + 15 + "% >");
                                cadena.Append("Desc. Infracciones");
                                cadena.Append("</th>");
                                cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                                cadena.Append("POA");
                                cadena.Append("</th>");
                                cadena.Append("</tr>");
                                // para el volumen de las especies
                                oCEntidadTem = new Ent_Reporte_Historial_TH();
                                oCEntidadTem.BusValor = oCEntidad_List[i].COD_RESODIREC_Inicio;
                                oCEntidadTem.BusCriterio = "RESOLUCION_DIRECTORAL_TH";
                                oCEntidadTem.NUM_POA = 1; // (Int32)Session["ID_REGISTRO"];
                                List<Ent_Reporte_Historial_TH> listEspecie = new List<Ent_Reporte_Historial_TH>();
                                listEspecie = oCLogica.log_Especies_MovTH(oCEntidadTem);

                                // implementar el bucle para el recorrido de la informacion 
                                if (listEspecie.Count > 0)
                                {
                                    for (int zy = 0; zy < listEspecie.Count; zy++)
                                    {
                                        cadena.Append("<tr>");
                                        cadena.Append("<td class=tdcenterAli style=width:" + 5 + "% >");
                                        cadena.Append(zy + 1);
                                        cadena.Append("</td>");
                                        cadena.Append("<td class=tdleftAli style=width:" + 10 + "% >");
                                        cadena.Append(listEspecie[zy].Articulos);
                                        cadena.Append("</td>");
                                        cadena.Append("<td class=tdcenterAli style=width:" + 5 + "% >");
                                        cadena.Append(listEspecie[zy].Encisos);
                                        cadena.Append("</td>");
                                        cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                        cadena.Append(listEspecie[zy].VOLUMEN_INEXISTENTE);
                                        cadena.Append("</td>");
                                        cadena.Append("<td class=tdleftAli style=width:" + 20 + "% >");
                                        cadena.Append(listEspecie[zy].NOMBRE_COMUN);
                                        cadena.Append("</td>");
                                        cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                        cadena.Append(listEspecie[zy].AREA_O);
                                        cadena.Append("</td>");
                                        cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                        cadena.Append(listEspecie[zy].NUMERO_ARBOLES);
                                        cadena.Append("</td>");
                                        cadena.Append("<td class=tdcenterAli style=width:" + 15 + "% >");
                                        cadena.Append(listEspecie[zy].descripFin);
                                        cadena.Append("</td>");
                                        cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                        cadena.Append(listEspecie[zy].NUM_EXP);
                                        cadena.Append("</td>");
                                        cadena.Append("</tr>");
                                    }
                                }
                                else
                                {
                                    cadena.Append("<tr>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 5 + "% >");
                                    cadena.Append("-");
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 25 + "% >");
                                    cadena.Append("-");
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                    cadena.Append("-");
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                    cadena.Append("-");
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                    cadena.Append("-");
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                    cadena.Append("-");
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                    cadena.Append("-");
                                    cadena.Append("</td>");
                                    cadena.Append("</tr>");
                                }
                                cadena.Append("</table><br/>");
                                oCEntidad_List[i].NUM_TFFSINI = oCEntidad_List[i].NUM_TFFSINI ?? "";
                                if (oCEntidad_List[i].NUM_TFFSINI.Trim() != "" && oCEntidad_List[i].NUM_TFFSINI != null)
                                {
                                    //R.D. tribunal inicio
                                    cadena.Append("<br/>");
                                    cadena.Append("<div class=bloqueFormTitulo ><div>R.D. TFFS (R.D. Inicio)</div></div>");
                                    cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                    cadena.Append("<div>Número de Resolución TFFS</div><div>:</div>");
                                    cadena.Append("</div>");
                                    cadena.Append("<div class=bloqueFormContent2Right ><div><p>" + oCEntidad_List[i].NUM_TFFSINI + "</p></div> </div>");
                                    cadena.Append(" </div>");

                                    cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                    cadena.Append("<div>Determina</div><div>:</div>");
                                    cadena.Append("</div>");
                                    cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].DETERMINA + "</div> </div>");
                                    cadena.Append(" </div>");

                                    cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                    cadena.Append("<div>Motivo</div><div>:</div>");
                                    cadena.Append("</div>");
                                    cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].MOTIVO + "</div> </div>");
                                    cadena.Append(" </div>");

                                    cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                    cadena.Append("<div>Documento hasta donde se retrotrae el proceso</div><div>:</div>");
                                    cadena.Append("</div>");
                                    cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].DOC_RETRO + " </div> </div>");
                                    cadena.Append(" </div>");

                                    cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                    cadena.Append("<div>Estado</div><div>:</div>");
                                    cadena.Append("</div>");
                                    cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].ESTADO_TFFS + " </div> </div>");
                                    cadena.Append(" </div>");
                                }
                            }

                            // RD Termino
                            oCEntidad_List[i].RD_TERMINO = oCEntidad_List[i].RD_TERMINO ?? "";
                            Ent_Reporte_Historial_TH oEstado = new Ent_Reporte_Historial_TH();
                            oEstado.RD_TERMINO = oCEntidad_List[i].RD_TERMINO;
                            List<Ent_Reporte_Historial_TH> oEstadoProcesoJud = oCLogica.log_EstadoProcesoJudicializado_S(oEstado);
                            Ent_Reporte_Historial_TH oResult = oCLogica.log_ObtenerIdTitularPagos(oEstado);

                            if (oCEntidad_List[i].RD_TERMINO.Trim() != "")
                            {
                                cadena.Append("<br/>");
                                cadena.Append("<div class=bloqueFormTitulo ><div>R.D. de Término</div></div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Número de Resolución Directoral</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].RD_TERMINO + "</div> </div>");
                                cadena.Append(" </div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Fecha Emisión</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].FECHA_RDTERMINO + "</div> </div>");
                                cadena.Append(" </div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Determinación</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].DETERMINACION_RDTERMINO + "</div> </div>");
                                cadena.Append(" </div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Monto de la multa</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].MULTA_MONTO + " (UIT) </div> </div>");
                                cadena.Append(" </div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Persona sancionada</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>");
                                oCEntidad_List[i].TITULAR = oCEntidad_List[i].TITULAR ?? "";
                                if (oCEntidad_List[i].TITULAR.Trim() == "")
                                {
                                    cadena.Append(titular);
                                }
                                else
                                {
                                    cadena.Append(oCEntidad_List[i].TITULAR);
                                }
                                cadena.Append(" </div> </div>");
                                cadena.Append(" </div>");

                                //Para las notificaciones de las R.D. Termino PAU
                                oCEntidadTem = new Ent_Reporte_Historial_TH();
                                oCEntidadTem.BusValor = oCEntidad_List[i].COD_RESODIREC_Termino;
                                oCEntidadTem.BusCriterio = "NOTIFICACION_TITULAR";
                                oCEntidadTem.NUM_POA = 0;
                                oCEntidadTem = oCLogica.Log_Notificaciones(oCEntidadTem);
                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Fecha notificación</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>");
                                if (oCEntidadTem.FECHA_NOT != null)
                                {
                                    cadena.Append(oCEntidadTem.FECHA_NOT);
                                }
                                else
                                {
                                    cadena.Append("-");
                                }
                                cadena.Append(" </div> </div>");
                                cadena.Append(" </div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Persona Notificada</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>");
                                if (oCEntidadTem.PERSONA_NOT != null)
                                {
                                    cadena.Append(oCEntidadTem.PERSONA_NOT);
                                }
                                else
                                {
                                    cadena.Append("-");
                                }
                                cadena.Append(" </div> </div>");
                                cadena.Append(" </div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Relación con el titular de la persona notificada</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>");
                                if (oCEntidadTem.PARENTESCO != null)
                                {
                                    cadena.Append(oCEntidadTem.PARENTESCO);
                                }
                                else
                                {
                                    cadena.Append("-");
                                }
                                cadena.Append(" </div> </div>");
                                cadena.Append(" </div>");

                                //Infracciones 
                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Infracciones por las que se sanciona</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].INFRACCIONES_TER + "</div> </div>");
                                cadena.Append(" </div>");

                                //estado del proceso judicializado  
                                cadena.Append("<br/>");
                                cadena.Append("<div class=bloqueFormTitulo ><div>Información del Estado del Proceso Judicializado</div></div>");
                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Judicializado</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + (oEstadoProcesoJud.Count > 0 ? "Si" : "-") + "</div> </div>");
                                cadena.Append(" </div>");
                                if (oEstadoProcesoJud.Count > 0)
                                {

                                    cadena.Append("<table class='table Grilla  table-bordered '><thead>	<tr><th>Tipo Expediente</th><th>Fecha Notificación</th><th>Nro Expediente</th><th>Estado</th></tr></thead><tbody>");
                                    foreach (var item in oEstadoProcesoJud)
                                    {
                                        cadena.Append(string.Format("<tr><td><b>{0}</b></td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", item.TIPO_EXPEDIENTE_RD, item.FECHA_NOTIFICACION_RDTERMINO, item.NUM_EXP, item.ESTADO_PROCESOJUDICIALIZADO));
                                    }
                                    cadena.Append("</tbody></table>");
                                }

                                //cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                // cadena.Append("<div>Fecha de notificación a OSINFOR</div><div>:</div>");
                                // cadena.Append("</div>");
                                // cadena.Append("<div class=bloqueFormContent2Right ><div>" + (oEstadoProcesoJud.FECHA_NOTIFICACION_RDTERMINO ?? "-") + "</div> </div>");
                                // cadena.Append(" </div>");

                                // cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                // cadena.Append("<div>Nro de Expediente</div><div>:</div>");
                                // cadena.Append("</div>");
                                // cadena.Append("<div class=bloqueFormContent2Right ><div>" + (oEstadoProcesoJud.NUM_EXP ?? "-") + "</div> </div>");
                                // cadena.Append(" </div>");

                                // cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                // cadena.Append("<div>Estado</div><div>:</div>");
                                // cadena.Append("</div>");
                                // cadena.Append("<div class=bloqueFormContent2Right ><div>" + (oEstadoProcesoJud.ESTADO_PROCESOJUDICIALIZADO ?? "-") + "</div> </div>");
                                // cadena.Append(" </div>");

                                cadena.Append("<br/>");
                                cadena.Append("<div class=bloqueFormTitulo ><div>Información del Pago de la Multa</div></div>");
                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Estado</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oResult.ESTADO_RESOLUCION + "</div> </div>");
                                cadena.Append(" </div>");
                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Modalidad</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oResult.MODALIDAD + "</div> </div>");
                                cadena.Append(" </div>");
                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Resumen de movimiento</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div> <a href='javascript: void(0);' onclick='_RtpTHDet.fnResumenRecaudacionesC(" + oResult.ID_REGISTRO.ToString() + ")'><i class='fa fa-search fa-fw'></i> Ver Resumen </a></div> </div>");
                                cadena.Append(" </div>");
                                cadena.Append("<br/>");


                                //  cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                //  cadena.Append("<div>Con medidas provisorias</div><div>:</div>");
                                //  cadena.Append("</div>");
                                //  cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].MEDIDAS_CAUTELARES_RT + "</div> </div>");
                                //  cadena.Append(" </div>");
                                cadena.Append("<div class=bloqueFormTitulo ><div>Especies con aprovechamiento Injustificados</div></div>");
                                cadena.Append("<table class=Grilla cellspacin=0 style='" + styleSupTable + "%' >");
                                cadena.Append("<tr>");
                                cadena.Append("<th class=tdcenter style=width:" + 5 + "% >");
                                cadena.Append("N°");
                                cadena.Append("</th>");
                                cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                                cadena.Append("Artículo");
                                cadena.Append("</th>");
                                cadena.Append("<th class=tdcenter style=width:" + 5 + "% >");
                                cadena.Append("Incisos");
                                cadena.Append("</th>");
                                cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                                cadena.Append("Volumen (m3)");
                                cadena.Append("</th>");
                                cadena.Append("<th class=tdcenter style=width:" + 20 + "% >");
                                cadena.Append("Especies");
                                cadena.Append("</th>");
                                cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                                cadena.Append("Área (ha)");
                                cadena.Append("</th>");
                                cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                                cadena.Append("Num. Individuos");
                                cadena.Append("</th>");
                                cadena.Append("<th class=tdcenter style=width:" + 15 + "% >");
                                cadena.Append("Desc. Infracciones");
                                cadena.Append("</th>");
                                cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                                cadena.Append("POA");
                                cadena.Append("</th>");
                                cadena.Append("</tr>");
                                // implementar el bucle para el recorrido de la informacion 
                                oCEntidadTem = new Ent_Reporte_Historial_TH();
                                oCEntidadTem.BusValor = oCEntidad_List[i].COD_RESODIREC_Termino;
                                oCEntidadTem.BusCriterio = "RESOLUCION_DIRECTORAL_TH";
                                oCEntidadTem.NUM_POA = 1;// (Int32)Session["ID_REGISTRO"];
                                List<Ent_Reporte_Historial_TH> listEspecie = new List<Ent_Reporte_Historial_TH>();
                                listEspecie = oCLogica.log_Especies_MovTH(oCEntidadTem);
                                if (listEspecie.Count > 0)
                                {
                                    for (int yz = 0; yz < listEspecie.Count; yz++)
                                    {
                                        cadena.Append("<tr>");
                                        cadena.Append("<td class=tdcenterAli style=width:" + 5 + "% >");
                                        cadena.Append(yz + 1);
                                        cadena.Append("</td>");
                                        cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                        cadena.Append(listEspecie[yz].Articulos);
                                        cadena.Append("</td>");
                                        cadena.Append("<td class=tdcenterAli style=width:" + 5 + "% >");
                                        cadena.Append(listEspecie[yz].Encisos);
                                        cadena.Append("</td>");
                                        cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                        cadena.Append(listEspecie[yz].VOLUMEN_INEXISTENTE);
                                        cadena.Append("</td>");
                                        cadena.Append("<td class=tdcenterAli style=width:" + 20 + "% >");
                                        cadena.Append(listEspecie[yz].NOMBRE_COMUN);
                                        cadena.Append("</td>");
                                        cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                        cadena.Append(listEspecie[yz].AREA_O);
                                        cadena.Append("</td>");
                                        cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                        cadena.Append(listEspecie[yz].NUMERO_ARBOLES);
                                        cadena.Append("</td>");
                                        cadena.Append("<td class=tdcenterAli style=width:" + 15 + "% >");
                                        cadena.Append(listEspecie[yz].descripFin);
                                        cadena.Append("</td>");
                                        cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                        cadena.Append(listEspecie[yz].NUM_EXP);
                                        cadena.Append("</td>");
                                        cadena.Append("</tr>");
                                        Estado_proceso = listEspecie[yz].ESTADO_ORIGEN;
                                    }
                                }
                                else
                                {
                                    cadena.Append("<tr>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 5 + "% >");
                                    cadena.Append("-");
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 25 + "% >");
                                    cadena.Append("-");
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                    cadena.Append("-");
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                    cadena.Append("-");
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                    cadena.Append("-");
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                    cadena.Append("-");
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdcenterAli style=width:" + 10 + "% >");
                                    cadena.Append("-");
                                    cadena.Append("</td>");
                                    cadena.Append("</tr>");
                                }
                                cadena.Append("</table><br/>");
                                oCEntidad_List[i].NUM_TFFSTER = oCEntidad_List[i].NUM_TFFSTER ?? "";
                                if (oCEntidad_List[i].NUM_TFFSTER.Trim() != "")
                                {
                                    //R.D. tribunal termino
                                    cadena.Append("<br/>");
                                    cadena.Append("<div class=bloqueFormTitulo ><div>R.D. TFFS (R.D. Término)</div></div>");
                                    cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                    cadena.Append("<div>Número de Resolución TFFS</div><div>:</div>");
                                    cadena.Append("</div>");
                                    cadena.Append("<div class=bloqueFormContent2Right ><div><p>" + oCEntidad_List[i].NUM_TFFSTER + "</p></div> </div>");
                                    cadena.Append(" </div>");

                                    cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                    cadena.Append("<div>Determina</div><div>:</div>");
                                    cadena.Append("</div>");
                                    cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].DETERMINA_TFFSTER + "</div> </div>");
                                    cadena.Append(" </div>");

                                    cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                    cadena.Append("<div>Motivo</div><div>:</div>");
                                    cadena.Append("</div>");
                                    cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].MOTIVO_TFFSTER + "</div> </div>");
                                    cadena.Append(" </div>");

                                    cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                    cadena.Append("<div>Documento hasta donde se retrotrae el proceso</div><div>:</div>");
                                    cadena.Append("</div>");
                                    cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].DOC_RETRO_TFFSTER + " </div> </div>");
                                    cadena.Append(" </div>");

                                    cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                    cadena.Append("<div>Estado</div><div>:</div>");
                                    cadena.Append("</div>");
                                    cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].ESTADO_TFFSTER + " </div> </div>");
                                    cadena.Append(" </div>");
                                }
                            }
                            oCEntidad_List[i].RECONS_COD_RESODIREC = oCEntidad_List[i].RECONS_COD_RESODIREC ?? "";
                            if (oCEntidad_List[i].RECONS_COD_RESODIREC.Trim() != "")
                            {
                                cadena.Append("<br/>");
                                cadena.Append("<div class=bloqueFormTitulo ><div>R.D. de Reconsideración</div></div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Número de Resolución Directoral</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].RECONS_NUM_RESOLUCION + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Fecha emisión</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].RECONS_RD_FECHA + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormTitulo ><div>Determinación</div></div>");
                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Improcedente</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].RECONS_IMPROCEDENTE + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Fundada</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].RECONS_FUNDADA + "</div> </div>");
                                cadena.Append(" </div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Fundada en parte</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].RECONS_FUNDADA_PARTE + "</div> </div>");
                                cadena.Append(" </div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Infundada</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].RECONS_INFUNDADA + "</div> </div>");
                                cadena.Append(" </div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Levantar la caducidad del Título Habilitante</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].RECONS_LEVANTAR_CADUCIDAD + "</div> </div>");
                                cadena.Append(" </div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Cambio de monto de multa</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].RECONS_CAMBIO_MULTA + "</div><div>" + oCEntidad_List[i].RECONS_MONTO + "</div></div>");
                                cadena.Append(" </div>");
                                oCEntidad_List[i].NUM_TFFSREC = oCEntidad_List[i].NUM_TFFSREC ?? "";
                                if (oCEntidad_List[i].NUM_TFFSREC.Trim() != "")
                                {
                                    //  //R.D. tribunal reconsideracion
                                    cadena.Append("<br/>");
                                    cadena.Append("<div class=bloqueFormTitulo ><div>R.D. TFFS (R.D. Reconsideración)</div></div>");
                                    cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                    cadena.Append("<div>Número de Resolución TFFS</div><div>:</div>");
                                    cadena.Append("</div>");
                                    cadena.Append("<div class=bloqueFormContent2Right ><div><p>" + oCEntidad_List[i].NUM_TFFSREC + "</p></div> </div>");
                                    cadena.Append(" </div>");

                                    cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                    cadena.Append("<div>Determina</div><div>:</div>");
                                    cadena.Append("</div>");
                                    cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].DETERMINA_TFFSREC + "</div> </div>");
                                    cadena.Append(" </div>");

                                    cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                    cadena.Append("<div>Motivo</div><div>:</div>");
                                    cadena.Append("</div>");
                                    cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].MOTIVO_TFFSREC + "</div> </div>");
                                    cadena.Append(" </div>");

                                    cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                    cadena.Append("<div>Documento hasta donde se retrotrae el proceso</div><div>:</div>");
                                    cadena.Append("</div>");
                                    cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].DOC_RETRO_TFFSREC + " </div> </div>");
                                    cadena.Append(" </div>");

                                    cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                    cadena.Append("<div>Estado</div><div>:</div>");
                                    cadena.Append("</div>");
                                    cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].ESTADO_TFFSREC + " </div> </div>");
                                    cadena.Append(" </div>");
                                }
                            }
                            oCEntidad_List[i].RECT_COD_RESODIREC = oCEntidad_List[i].RECT_COD_RESODIREC ?? "";
                            if (oCEntidad_List[i].RECT_COD_RESODIREC.Trim() != "")
                            {
                                cadena.Append("<br/>");
                                cadena.Append("<div class=bloqueFormTitulo ><div>R.D. de Rectificación</div></div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Número de Resolución Directoral</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].RECT_NUM_RESOLUCION + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Fecha emisión</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].RECT_RD_FECHA + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormTitulo ><div>Motivo</div></div>");
                                cadena.Append("<div class=bloqueFormContent2> <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Error material</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].RECT_ERRORMATERIAL + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Cambio de multa</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].RECT_CAMBIO_MULTA + "</div><div>" + oCEntidad_List[i].RECT_MONTO + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Otros</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].RECT_OTROS + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div></div><div></div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].RECT_DESC_OTROS + "</div> </div>");
                                cadena.Append("</div>");
                            }
                            oCEntidad_List[i].AMP_COD_RESODIREC = oCEntidad_List[i].AMP_COD_RESODIREC ?? "";
                            if (oCEntidad_List[i].AMP_COD_RESODIREC.Trim() != "")
                            {
                                cadena.Append("<br/>");
                                cadena.Append("<div class=bloqueFormTitulo ><div>R.D. Ampliación PAU</div></div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Número de Resolución Directoral</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].AMP_NUM_RESOLUCION + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Fecha emisión</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].RD_FECHA_EMISION_AMP + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormTitulo ><div>Motivo de ampliación</div></div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Ampliar imputación</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].AMP_IMPUTACION + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Ampliar por otras instituciones</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].AMP_OTRAS_INFRACCIONES + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Ampliar por plazos</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].AMP_POR_PLAZOS + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Otros</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].AMP_OTROS + "</div> </div>");
                                cadena.Append("</div>");
                            }
                            oCEntidad_List[i].OTROS_COD_RESODIREC = oCEntidad_List[i].OTROS_COD_RESODIREC ?? "";
                            if (oCEntidad_List[i].OTROS_COD_RESODIREC.Trim() != "")
                            {
                                cadena.Append("<div class=bloqueFormTitulo ><div>R.D. Otros</div></div>");
                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Número de Resolución Directoral</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].OTROS_NUM_RESOLUCION + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Fecha de emisión</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].OTROS_RD_FECHA + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Determinación</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].OTROS_DETERMINACION + "</div> </div>");
                                cadena.Append("</div>");

                            }
                            oCEntidad_List[i].ACUM_COD_RESODIREC = oCEntidad_List[i].ACUM_COD_RESODIREC ?? "";
                            if (oCEntidad_List[i].ACUM_COD_RESODIREC.Trim() != "")
                            {
                                cadena.Append("<div class=bloqueFormTitulo ><div>R.D. Acumulación de expedientes con PAU</div></div>");
                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Número de Resolución Directoral</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].ACUM_NUM_RESOLUCION + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Fecha de emisión</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].ACUM_FECHA_EMISION + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Motivo</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].ACUM_DESCRIPCION + "</div> </div>");
                                cadena.Append("</div>");
                            }
                            oCEntidad_List[i].VARI_COD_RESODIREC = oCEntidad_List[i].VARI_COD_RESODIREC ?? "";
                            if (oCEntidad_List[i].VARI_COD_RESODIREC.Trim() != "")
                            {
                                cadena.Append("<div class=bloqueFormTitulo ><div>R.D. Variación de Medidas Cautelares</div></div>");
                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Número de Resolución Directoral</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].VARI_NUM_RESOLUCION + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Fecha de emisión</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].VARI_RD_FECHA + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormTitulo ><div>Acción</div></div>");
                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Levantamiento de medidas cautelares</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].VARI_LEVANTAR + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Levantar en parte medidas cautelares</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].VARI_LEVANTAR_PARTE + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>No levantar medidas cautelares</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].VARI_NO_LEVANTAR + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Modificación de medidas cautelares</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].VARI_MODIFICAR + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div></div><div></div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].VARI_DETERMINACION + "</div> </div>");
                                cadena.Append("</div>");
                            }
                            oCEntidad_List[i].CAD_COD_RESODIREC = oCEntidad_List[i].CAD_COD_RESODIREC ?? "";
                            if (oCEntidad_List[i].CAD_COD_RESODIREC.Trim() != "")
                            {
                                cadena.Append("<div class=bloqueFormTitulo ><div>R.D.  Caducidad por Renuncia del Titular</div></div>");
                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Número de Resolución Directoral</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].CAD_NUM_RESOLUCION + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Fecha de emisión</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].CAD_RD_FECHA + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Número de expediente</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].CAD_NUM_EXP + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Caducidad</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].CAD_CADUCIDAD + "</div> </div>");
                                cadena.Append("</div>");
                            }
                            oCEntidad_List[i].PROVEIDO = oCEntidad_List[i].PROVEIDO ?? "";
                            if (oCEntidad_List[i].PROVEIDO.Trim() != "")
                            {
                                cadena.Append("<div class=bloqueFormTitulo ><div>Proveído</div></div>");
                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Fecha Proveído</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].FECHA_PROVEIDO + "</div> </div>");
                                cadena.Append("</div>");

                                cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                                cadena.Append("<div>Tipo proveído</div><div>:</div>");
                                cadena.Append("</div>");
                                cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].PROVEIDO + "</div> </div>");
                                cadena.Append("</div>");

                            }
                        }
                        cadena.Append("<br/><div class=bloqueFormTitulo ><div>Documentos presentados por el titular</div></div>");
                        cadena.Append("<table class=Grilla cellspacin=0 style='" + styleSupTable + "%' >");
                        cadena.Append("<tr>");
                        cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                        cadena.Append("Tipo");
                        cadena.Append("</th>");
                        cadena.Append("<th class=tdcenter style=width:" + 20 + "% >");
                        cadena.Append("N° de Trámite");
                        cadena.Append("</th>");
                        cadena.Append("<th class=tdcenter style=width:" + 10 + "% >");
                        cadena.Append("Fecha de presentación");
                        cadena.Append("</th>");
                        cadena.Append("<th class=tdcenter style=width:" + 20 + "% >");
                        cadena.Append("Referencia");
                        cadena.Append("</th>");
                        cadena.Append("</tr>");

                        if (oCEntidad_List[i].NUM_EXP != null)
                        {
                            oCEntidadTem = new Ent_Reporte_Historial_TH();
                            oCEntidadTem.BusCriterio = "INFTIT";
                            oCEntidadTem.BusValor = oCEntidad_List[i].COD_INFORME;
                            oCEntidadTem.NUM_POA = 0;
                            List<Ent_Reporte_Historial_TH> listInformacionTitular = new List<Ent_Reporte_Historial_TH>();
                            listInformacionTitular = oCLogica.log_informacionTitular(oCEntidadTem);
                            if (listInformacionTitular.Count > 0)
                            {
                                for (int ij = 0; ij < listInformacionTitular.Count; ij++)
                                {
                                    cadena.Append("<tr>");
                                    cadena.Append("<td class=tdleftAli style=width:" + 10 + "% >");
                                    cadena.Append(listInformacionTitular[ij].Tipo_Inicio);
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdleftAli style=width:" + 20 + "% >");
                                    cadena.Append(listInformacionTitular[ij].NUMERO);
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdleftAli style=width:" + 10 + "% >");
                                    cadena.Append(listInformacionTitular[ij].fecha_aprobacion);
                                    cadena.Append("</td>");
                                    cadena.Append("<td class=tdleftAli style=width:" + 20 + "% >");
                                    cadena.Append(listInformacionTitular[ij].NUM_CNOTIFICACION);
                                    cadena.Append("</td>");
                                    cadena.Append("</tr>");
                                }

                            }
                            else
                            {
                                cadena.Append("<tr>");
                                cadena.Append("<td class=tdleftAli style=width:" + 10 + "% >");
                                cadena.Append("-");
                                cadena.Append("</td>");
                                cadena.Append("<td class=tdleftAli style=width:" + 20 + "% >");
                                cadena.Append("-");
                                cadena.Append("</td>");
                                cadena.Append("<td class=tdleftAli style=width:" + 10 + "% >");
                                cadena.Append("-");
                                cadena.Append("</td>");
                                cadena.Append("<td class=tdleftAli style=width:" + 20 + "% >");
                                cadena.Append("-");
                                cadena.Append("</td>");
                                cadena.Append("</tr>");
                            }
                        }
                        cadena.Append("</table><br/>");

                        cadena.Append("<br/><div class=bloqueFormTitulo ><div>Estado del proceso de fiscalización</div></div>");

                        cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                        cadena.Append("<div>Estado del Proceso</div><div>:</div>");
                        cadena.Append("</div>");
                        cadena.Append("<div class=bloqueFormContent2Right ><div>" + oCEntidad_List[i].ESTADO_ORIGEN + "</div> </div>");
                        cadena.Append(" </div>");
                        list_inf = cadena.ToString();
                    }

                }
                else
                {
                    cadena.Append("<div class=bloqueFormContent2 > <div class=bloqueFormContent2LeftDoble >");
                    cadena.Append("<div>Supervisado</div><div>:</div>");
                    cadena.Append("</div>");
                    cadena.Append("<div class=bloqueFormContent2Right > <div> No </div> </div>");
                    cadena.Append(" </div>");
                    list_inf = cadena.ToString();
                }
            }
            else
            {
                list_inf = "No se encontraron Supervisiones";
            }
            return list_inf;
        }


        public ActionResult Rpt_Control_Calidad()
        {
            VM_ReporteGeneral vmRpt = new VM_ReporteGeneral();
            List<VM_Chk> lstChkItem;
            CapaLogica.DOC.Log_ControlCalidad exeBus = new CapaLogica.DOC.Log_ControlCalidad();
            Ent_ControlCalidad OCEntidad = new Ent_ControlCalidad();
            try
            {
                OCEntidad = exeBus.RegMostCombo(OCEntidad);

                lstChkItem = new List<VM_Chk>();
                for (int i = DateTime.Now.Year; i >= 2004; i--)
                    lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                vmRpt.lstChkAnio = lstChkItem;
                vmRpt.listTipoDocumento = OCEntidad.ListMComboTipoDocumento;

            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }


            return View(vmRpt);
        }
        #endregion

        #region Reporte produccion usuarios
        public ActionResult Rpt_Produccion_Usuarios()
        {
            VM_ReporteGeneral vmRpt = new VM_ReporteGeneral();
            List<VM_Chk> lstChkItem;
            CapaLogica.DOC.Log_ControlCalidad exeBus = new CapaLogica.DOC.Log_ControlCalidad();
            Ent_ControlCalidad OCEntidad = new Ent_ControlCalidad();
            try
            {
                OCEntidad = exeBus.RegMostCombo(OCEntidad);

                lstChkItem = new List<VM_Chk>();
                for (int i = DateTime.Now.Year; i >= 2004; i--)
                    lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                vmRpt.lstChkAnio = lstChkItem;
                vmRpt.listDireccionLinea = OCEntidad.ListDireccionLinea;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            return View(vmRpt);
        }

        public ActionResult ReporteProduccion(String[] direccion, string anio, string codUsuario)
        {
            vmReport = new VM_ReporteGeneral();
            Ent_Reporte_ProduccionXDigitadores oCEntidad = new Ent_Reporte_ProduccionXDigitadores();
            CapaLogica.DOC.Log_Reporte_ProduccionXDigitadores exeBus = new CapaLogica.DOC.Log_Reporte_ProduccionXDigitadores();
            oCEntidad.BusAnio = anio;
            oCEntidad.BusCriterio = ObtenerCadenaArray(direccion);
            oCEntidad.BusValor = codUsuario;
            vmReport.listProduccionU = new List<Ent_Reporte_ProduccionXDigitadores>();
            vmReport.listProduccionU = exeBus.RegProdXDigitador(oCEntidad);
            return PartialView("~/Areas/General/Views/Reportes/_sharedRptProdU/_renderRPUResumen.cshtml", vmReport);
        }

        public ActionResult ReporteProduccionDetalle(String[] direccion, string anio, string codUsuario, string tipoReporte, string mesReporte, string mesNombre)
        {
            vmReport = new VM_ReporteGeneral();
            Ent_Reporte_ProduccionXDigitadores oCEntidad = new Ent_Reporte_ProduccionXDigitadores();
            CapaLogica.DOC.Log_Reporte_ProduccionXDigitadores exeBus = new CapaLogica.DOC.Log_Reporte_ProduccionXDigitadores();
            oCEntidad.BusAnio = anio;
            oCEntidad.BusMes = mesReporte;
            oCEntidad.CodUsuario = codUsuario;
            oCEntidad.BusDLinea = ObtenerCadenaArray(direccion);
            oCEntidad.BusCriterio = tipoReporte;
            vmReport.listProduccionUDetalle = new List<Ent_Reporte_ProduccionXDigitadores>();
            vmReport.listProduccionUDetalle = exeBus.RegProdXDigitadorDetalleRegistros(oCEntidad);
            vmReport.tipoReporte = tipoReporte;

            switch (tipoReporte)
            {
                case "TITULO_HABILITANTE":
                    vmReport.tituloReporteDetalle = anio + " - " + mesNombre + " - TÍTULO HABILITANTE";
                    break;
                case "POA":
                    vmReport.tituloReporteDetalle = anio + " - " + mesNombre + " - POA";
                    break;
                case "PLAN_MANEJO":
                    vmReport.tituloReporteDetalle = anio + " - " + mesNombre + " - Plan de Manejo";
                    break;
                case "CAPACITACION":
                    vmReport.tituloReporteDetalle = anio + " - " + mesNombre + " - Capacitación";
                    break;
                case "CARTA_NOTIFICACION":
                    vmReport.tituloReporteDetalle = anio + " - " + mesNombre + " - Carta de Notificación Registrado";
                    break;
                case "CARTA_NOTIFICACION_NTF":
                    vmReport.tituloReporteDetalle = anio + " - " + mesNombre + " - Carta de Notificación Notificado";
                    break;
                case "NOTIFICACION_FISCALIZACION":
                    vmReport.tituloReporteDetalle = anio + " - " + mesNombre + " - Carta de Notificación Fiscalización Registrado";
                    break;
                case "NOTIFICACION_FISCALIZACION_NTF":
                    vmReport.tituloReporteDetalle = anio + " - " + mesNombre + " - Carta de Notificación Fiscalización Notificado";
                    break;
                case "INFORME_SUPERVISION":
                    vmReport.tituloReporteDetalle = anio + " - " + mesNombre + " - Informe de Supervisión";
                    break;
                case "GUIA_TRANSPORTE":
                    vmReport.tituloReporteDetalle = anio + " - " + mesNombre + " - Guía de Transporte";
                    break;
                case "INFORME_LEGAL":
                    vmReport.tituloReporteDetalle = anio + " - " + mesNombre + " - Informe Legal";
                    break;
                case "RESOLUCION_DIRECTORAL":
                    vmReport.tituloReporteDetalle = anio + " - " + mesNombre + " - Resolución Directoral";
                    break;
                case "INFORME_FUNDAMENTADO":
                    vmReport.tituloReporteDetalle = anio + " - " + mesNombre + " - Informe Fundamentado";
                    break;
                case "INFORMACION_TITULAR":
                    vmReport.tituloReporteDetalle = anio + " - " + mesNombre + " - Información Titular";
                    break;
            }
            return PartialView("~/Areas/General/Views/Reportes/_sharedRptProdU/_renderRPUDetalle.cshtml", vmReport);
        }
        public String ObtenerCadenaArray(String[] array)
        {
            String cadena;
            try
            {
                cadena = "";
                for (int i = 0; i < array.Length; i++)
                {
                    cadena = cadena + "" + array[i].ToString() + "" + ",";
                }
                return cadena.TrimEnd(',');
            }
            catch
            {
                cadena = "";
                return cadena;
            }
        }

        public JsonResult graficarResultado()
        {
            var jsonResult = Json(new
            {
                data = vmReport.listProduccionU.ToArray(),
                succes = true,
            }, JsonRequestBehavior.AllowGet);

            return jsonResult;
        }
        #endregion

        #region Reporte supervisiones efectuadas
        public ActionResult Rpt_Prod_supervisores()
        {
            VM_ReporteGeneral vmRpt = new VM_ReporteGeneral();
            List<VM_Chk> lstChkItem;
            CapaLogica.DOC.Log_ControlCalidad exeBus = new CapaLogica.DOC.Log_ControlCalidad();
            Ent_ControlCalidad OCEntidad = new Ent_ControlCalidad();
            try
            {
                OCEntidad = exeBus.RegMostCombo(OCEntidad);

                lstChkItem = new List<VM_Chk>();
                for (int i = DateTime.Now.Year; i >= 2004; i--)
                    lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                vmRpt.lstChkAnio = lstChkItem;
                vmRpt.listDireccionLinea = OCEntidad.ListDireccionLinea;
                vmRpt.listDepartamento = OCEntidad.ListDepartamento;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            return View(vmRpt);
        }
        ///metodo para el resumen del reporte de supervisiones efectuadas
        public ActionResult ReporteResumenSupervision(String[] direccion, string anio, String[] departamento)
        {
            vmReport = new VM_ReporteGeneral();
            Ent_REPORTE_SUPERVISION_GENERAL oCEntidad = new Ent_REPORTE_SUPERVISION_GENERAL();
            Log_SUPERVISION_GENERAL exeBus = new Log_SUPERVISION_GENERAL();
            oCEntidad.BusAnio = anio;
            oCEntidad.BusDireccion = ObtenerCadenaArray(direccion);
            oCEntidad.BusRegion = ObtenerCadenaArray(departamento);
            oCEntidad = exeBus.RegMostrarListSupervisionXsupervisorResumen(oCEntidad);
            vmReport.listSupModResumen = oCEntidad.ListSupervisionSupervisorXmodalidad;
            vmReport.listSupModDetalle = new List<Ent_REPORTE_SUPERVISION_GENERAL>();
            return PartialView("~/Areas/General/Views/Reportes/_sharedRptProdU/_renderRSResumen.cshtml", vmReport);
        }

        public ActionResult ReporteDetalleSupervision(String[] direccion, string anio, string[] departamento, string codModalidad, string modalidad, string codSupervisor, string Supervisor)
        {
            //vmReport = new VM_ReporteGeneral();
            Ent_REPORTE_SUPERVISION_GENERAL oCEntidad = new Ent_REPORTE_SUPERVISION_GENERAL();
            Log_SUPERVISION_GENERAL exeBus = new Log_SUPERVISION_GENERAL();
            oCEntidad.BusAnio = anio;
            oCEntidad.BusDireccion = ObtenerCadenaArray(direccion);
            oCEntidad.BusRegion = ObtenerCadenaArray(departamento);
            oCEntidad.COD_MTIPO = codModalidad;
            oCEntidad.COD_SUPERVISOR = codSupervisor;
            vmReport.listSupModDetalle = exeBus.RegMostrarListSupervisionXsupervisorDetalle(oCEntidad);
            vmReport.tituloReporteDetalle = "Reporte detalle de las supervisiones realizadas por el supervisor [" + Supervisor + "] de la modalidad [" + modalidad + "]";
            return PartialView("~/Areas/General/Views/Reportes/_sharedRptProdU/_renderRSDetalle.cshtml", vmReport);
        }

        public JsonResult DescargarResumenSupervision()
        {
            ListResult result = new ListResult();
            Log_SUPERVISION_GENERAL exeBus = new Log_SUPERVISION_GENERAL();
            result = exeBus.DescargaResumen(vmReport.listSupModResumen);
            return Json(result);
        }

        public JsonResult DescargarDetalleSupervision()
        {
            ListResult result = new ListResult();
            Log_SUPERVISION_GENERAL exeBus = new Log_SUPERVISION_GENERAL();
            result = exeBus.DescargaDetalle(vmReport.listSupModDetalle);
            return Json(result);
        }

        public ActionResult Rpt_Produccion_ItinerarioSupervision()
        {
            VM_ReporteGeneral vmRpt = new VM_ReporteGeneral();
            Log_ControlCalidad exeBus = new Log_ControlCalidad();
            Ent_ControlCalidad OCEntidad = new Ent_ControlCalidad();
            try
            {
                OCEntidad = exeBus.RegMostCombo(OCEntidad);
                vmRpt.listDireccionLinea = OCEntidad.ListDireccionLinea;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            return View(vmRpt);
        }

        [HttpPost]
        public ActionResult Rpt_Produccion_ItinerarioSupervision_Resumen(Ent_Reporte_ProduccionItinerarioSupervision OCEntidad)
        {
            var exeBus = new Log_Reporte_ProduccionItinerarioSupervision();
            var result = exeBus.MostReporteResumen(OCEntidad);
            return PartialView("~/Areas/General/Views/Reportes/_sharedRptProdItinerario/_renderResumen.cshtml", result);
        }

        [HttpPost]
        public ActionResult Rpt_Produccion_ItinerarioSupervision_Detalle(Ent_Reporte_ProduccionItinerarioSupervision OCEntidad)
        {
            var exeBus = new Log_Reporte_ProduccionItinerarioSupervision();
            ViewBag.Titulo = OCEntidad.OD ?? "TOTAL";
            OCEntidad.OD = null;
            ViewBag.INFO_GEO = OCEntidad.INFO_GEO;
            var result = exeBus.MostReporteDetalle(OCEntidad);
            return PartialView("~/Areas/General/Views/Reportes/_sharedRptProdItinerario/_renderDetalle.cshtml", result);
        }

        public ActionResult Rpt_Produccion_ItinerarioSupervision_Descargar(string path, string name)
        {
            string filePath = Server.MapPath(string.Format("~{0}", path));

            if (System.IO.File.Exists(filePath))
            {
                return File(filePath, "application/octet-stream", name);
            }
            else
            {
                return new HttpStatusCodeResult(404);
            }
        }

        [HttpPost]
        public ActionResult Rpt_Produccion_ItinerarioSupervision_Excel(Dictionary<string, string> cabecera, List<Ent_Reporte_ProduccionItinerarioSupervision> detalle)
        {
            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/ExportarISupervisionBase.xlsx"));
            int rowStart = 3;
            int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();

                //if (cabecera != null)
                //{
                //    string Mes = "Todos";
                //    int iMes = int.Parse(cabecera["Mes"]);
                //    if (iMes != 0) Mes = HelperSigo.MesNombre(iMes);

                //    worksheet.Cells["C3"].Value = cabecera["Periodo"];
                //    worksheet.Cells["C4"].Value = Mes;
                //}

                if (detalle != null)
                {
                    int column = 0;

                    foreach (var item in detalle)
                    {
                        column = 0;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = ++contador;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.OD;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.NUM_CNOTIFICACION;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.SUPERVISOR;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.TITULAR;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.NUM_THABILITANTE;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.POAS;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.DEPARTAMENTO;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.MODALIDAD;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.FECHA_SALIDA;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.FECHA_LLEGADA;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.SUPERVISADO_TEXT;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.TIPO_INFORME;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.ALERTA;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.NUM_INFORME;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.ABREVIADO_SUBPER;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.OBSERVACION;
                        rowStart++;
                    }

                    //string modelRange = string.Format("A1:Q{0}", rowStart - 1);
                    //var modelTable = worksheet.Cells[modelRange];
                    //modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    //modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    //modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    //modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                string excelName = "ReporteItinerarioSupervision";
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);
                    return new BinaryContentResultDowload
                    {
                        FileName = excelName + ".xlsx",
                        ContentType = "application/octet-stream",
                        Content = memoryStream.ToArray()
                    };
                }
            }
        }

        #endregion

        #region "Reportes Información"
        public ActionResult ReporteRegistroInformacion01()
        {
            VM_ReporteInformacion model = new VM_ReporteInformacion();

            String Parametros = "2|0|0|0|0|0|0|2|0";
            if (Parametros.Split('|').Length == 10) { Parametros += "|0"; }
            else if (Parametros.Split('|').Length == 9) { Parametros += "|0|0"; }
            else if (Parametros.Split('|').Length == 8) { Parametros += "|0|0|0"; }

            Ent_MasterFiltro oCampos = new Ent_MasterFiltro();
            Log_MasterFiltro oCLogica = new Log_MasterFiltro();
            oCampos.BusValor = Parametros;
            oCampos = oCLogica.RegMostFiltro(oCampos);

            model.lstChkAnio = oCampos.ListAnios.Select(i => new VM_Chk { Value = i.CODIGO, Text = i.DESCRIPCION });
            model.lstChkOd = oCampos.ListOD.Select(i => new VM_Chk { Value = i.CODIGO, Text = i.DESCRIPCION });

            return View(model);
        }

        public ActionResult _ResumenRegistroInformacion01(string anio, string od)
        {
            Ent_Reporte_ProduccionXDigitadores oCENtidad = new Ent_Reporte_ProduccionXDigitadores();
            Log_Reporte_ProduccionXDigitadores oCLogica = new Log_Reporte_ProduccionXDigitadores();
            List<Ent_Reporte_ProduccionXDigitadores> listCEntidad = new List<Ent_Reporte_ProduccionXDigitadores>();
            oCENtidad.BusValor = anio.Replace("'", "");
            oCENtidad.BusCriterio = od.Replace("'", "");

            listCEntidad = oCLogica.logRegistroInformacionList(oCENtidad);

            Session["listCEntidad"] = listCEntidad;

            return PartialView(listCEntidad);
        }
        public ActionResult ReporteRegistroInformacion02()
        {
            VM_ReporteInformacion model = new VM_ReporteInformacion();

            String Parametros = "2|0|0|0|0|0|0|2|0";
            if (Parametros.Split('|').Length == 10) { Parametros += "|0"; }
            else if (Parametros.Split('|').Length == 9) { Parametros += "|0|0"; }
            else if (Parametros.Split('|').Length == 8) { Parametros += "|0|0|0"; }

            Ent_MasterFiltro oCampos = new Ent_MasterFiltro();
            Log_MasterFiltro oCLogica = new Log_MasterFiltro();
            oCampos.BusValor = Parametros;
            oCampos = oCLogica.RegMostFiltro(oCampos);

            model.lstChkAnio = oCampos.ListAnios.Select(i => new VM_Chk { Value = i.CODIGO, Text = i.DESCRIPCION });
            model.lstChkOd = oCampos.ListOD.Select(i => new VM_Chk { Value = i.CODIGO, Text = i.DESCRIPCION });

            return View(model);
        }
        public ActionResult _ResumenRegistroInformacion02(string anio, string od)
        {
            Ent_Reporte_ProduccionXDigitadores oCENtidad = new Ent_Reporte_ProduccionXDigitadores();
            Log_Reporte_ProduccionXDigitadores oCLogica = new Log_Reporte_ProduccionXDigitadores();
            List<Ent_Reporte_ProduccionXDigitadores> listCEntidadDetalle = new List<Ent_Reporte_ProduccionXDigitadores>();
            List<Ent_Reporte_ProduccionXDigitadores> listCEntidadDetalle2 = new List<Ent_Reporte_ProduccionXDigitadores>();
            oCENtidad.BusValor = anio.Replace("'", "");
            oCENtidad.BusCriterio = od.Replace("'", "");

            listCEntidadDetalle = oCLogica.logRegistroInformacionDetalle(oCENtidad);
            Session["listCEntidadDetalle"] = listCEntidadDetalle;
            listCEntidadDetalle2 = oCLogica.logRegistroInformacionDetalle2(oCENtidad);
            Session["listCEntidadDetalle2"] = listCEntidadDetalle2;

            return PartialView(listCEntidadDetalle);
        }
        public JsonResult NotificacionTList()
        {
            try
            {
                List<Ent_Reporte_ProduccionXDigitadores> listCEntidadDetalle2 = new List<Ent_Reporte_ProduccionXDigitadores>();
                listCEntidadDetalle2 = (List<Ent_Reporte_ProduccionXDigitadores>)Session["listCEntidadDetalle2"];
                var jsonResult = Json(new { success = true, msj = "", data = listCEntidadDetalle2 }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

                return Json(new { success = false, msj = ex.Message, data = "" }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult ReporteRegistroInformacion03()
        {
            VM_ReporteInformacion model = new VM_ReporteInformacion();

            String Parametros = "2|0|0|0|0|0|0|2|0";
            if (Parametros.Split('|').Length == 10) { Parametros += "|0"; }
            else if (Parametros.Split('|').Length == 9) { Parametros += "|0|0"; }
            else if (Parametros.Split('|').Length == 8) { Parametros += "|0|0|0"; }

            Ent_MasterFiltro oCampos = new Ent_MasterFiltro();
            Log_MasterFiltro oCLogica = new Log_MasterFiltro();
            oCampos.BusValor = Parametros;
            oCampos = oCLogica.RegMostFiltro(oCampos);

            model.lstChkAnio = oCampos.ListAnios.Select(i => new VM_Chk { Value = i.CODIGO, Text = i.DESCRIPCION });
            model.lstChkOd = oCampos.ListOD.Select(i => new VM_Chk { Value = i.CODIGO, Text = i.DESCRIPCION });

            return View(model);
        }
        public ActionResult _ResumenRegistroInformacion03(string anio, string od)
        {
            Ent_Reporte_ProduccionXDigitadores oCENtidad = new Ent_Reporte_ProduccionXDigitadores();
            Log_Reporte_ProduccionXDigitadores oCLogica = new Log_Reporte_ProduccionXDigitadores();
            List<Ent_Reporte_ProduccionXDigitadores> listCEntidadExpediente = new List<Ent_Reporte_ProduccionXDigitadores>();
            List<Ent_Reporte_ProduccionXDigitadores> listCEntidadExpedienteDetalle = new List<Ent_Reporte_ProduccionXDigitadores>();
            oCENtidad.BusValor = anio.Replace("'", "");
            oCENtidad.BusCriterio = od.Replace("'", "");

            listCEntidadExpediente = oCLogica.logRegistroInformacionExpediente(oCENtidad);
            Session["listCEntidadExpediente"] = listCEntidadExpediente;
            listCEntidadExpedienteDetalle = oCLogica.logRegistroInformacionExpediente2(oCENtidad);
            Session["listCEntidadExpedienteDetalle"] = listCEntidadExpedienteDetalle;

            return PartialView(listCEntidadExpediente);
        }
        public JsonResult DocumentacionFList()
        {
            try
            {
                List<Ent_Reporte_ProduccionXDigitadores> listCEntidadExpedienteDetalle = new List<Ent_Reporte_ProduccionXDigitadores>();
                listCEntidadExpedienteDetalle = (List<Ent_Reporte_ProduccionXDigitadores>)Session["listCEntidadExpedienteDetalle"];
                var jsonResult = Json(new { success = true, msj = "", data = listCEntidadExpedienteDetalle }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

                return Json(new { success = false, msj = ex.Message, data = "" }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult ReporteRegistroInformacion04()
        {
            VM_ReporteInformacion model = new VM_ReporteInformacion();

            String Parametros = "2|0|0|0|0|0|0|2|0";
            if (Parametros.Split('|').Length == 10) { Parametros += "|0"; }
            else if (Parametros.Split('|').Length == 9) { Parametros += "|0|0"; }
            else if (Parametros.Split('|').Length == 8) { Parametros += "|0|0|0"; }

            Ent_MasterFiltro oCampos = new Ent_MasterFiltro();
            Log_MasterFiltro oCLogica = new Log_MasterFiltro();
            oCampos.BusValor = Parametros;
            oCampos = oCLogica.RegMostFiltro(oCampos);

            model.lstChkAnio = oCampos.ListAnios.Select(i => new VM_Chk { Value = i.CODIGO, Text = i.DESCRIPCION });
            model.lstChkOd = oCampos.ListOD.Select(i => new VM_Chk { Value = i.CODIGO, Text = i.DESCRIPCION });

            return View(model);
        }
        public JsonResult EjecucionPAList(string anio, string od)
        {
            try
            {
                Ent_Reporte_ProduccionXDigitadores oCENtidad = new Ent_Reporte_ProduccionXDigitadores();
                Log_Reporte_ProduccionXDigitadores oCLogica = new Log_Reporte_ProduccionXDigitadores();
                List<Ent_Reporte_ProduccionXDigitadores> listCEntidadTalleres = new List<Ent_Reporte_ProduccionXDigitadores>();
                oCENtidad.BusValor = anio.Replace("'", "");
                oCENtidad.BusCriterio = od.Replace("'", "");
                listCEntidadTalleres = oCLogica.logRegistroTalleres(oCENtidad);
                var jsonResult = Json(new { success = true, msj = "", data = listCEntidadTalleres }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

                return Json(new { success = false, msj = ex.Message, data = "" }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult ReporteTalleres(string anio, string od)
        {
            Ent_Reporte_ProduccionXDigitadores oCENtidad = new Ent_Reporte_ProduccionXDigitadores();
            Log_Reporte_ProduccionXDigitadores oCLogica = new Log_Reporte_ProduccionXDigitadores();
            List<Ent_Reporte_ProduccionXDigitadores> lstResult = new List<Ent_Reporte_ProduccionXDigitadores>();
            oCENtidad.BusValor = anio.Replace("'", "");
            oCENtidad.BusCriterio = od.Replace("'", "");
            lstResult = oCLogica.logRegistroTalleres(oCENtidad);

            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/ReporteInformacionRegistradaTaller.xlsx"));
            int rowStart = 2;
            int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();
                if (lstResult.Count > 0)
                {
                    foreach (var item in lstResult)
                    {
                        worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = ++contador;
                        //  worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Style.Numberformat.Format = "dd/mm/yyyy";
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item.TIPO;
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item.NOMBRES;
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item.DEPARTAMENTO;
                        worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Style.Numberformat.Format = "dd/mm/yyyy";
                        worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item.FECHA.Trim() == "" ? (DateTime?)null : Convert.ToDateTime(item.FECHA);
                        worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item.ORGANIZADOR;
                        worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item.PUBLICO_OBJECTIVO;
                        worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = item.N_PARTICIPANTES;
                        worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = item.MARCO_CONVENIO;
                        rowStart = rowStart + 1;
                    }
                    string modelRange = "A2:I" + (rowStart - 1).ToString();
                    var modelTable = worksheet.Cells[modelRange];
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                string excelName = "ReporteRegTaller";
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);
                    return new BinaryContentResultDowload
                    {
                        FileName = excelName + ".xlsx",
                        ContentType = "application/octet-stream",
                        Content = memoryStream.ToArray()
                    };
                }
            }
        }
        public ActionResult RptRegistroInformacion()
        {

            List<Ent_Reporte_ProduccionXDigitadores> lstResult = new List<Ent_Reporte_ProduccionXDigitadores>();
            lstResult = (List<Ent_Reporte_ProduccionXDigitadores>)Session["listCEntidad"];

            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/RegistroInformacionSIGO.xlsx"));
            int rowStart = 2;
            //int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();
                if (lstResult.Count > 0)
                {
                    foreach (var item in lstResult)
                    {
                        worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = item.DESCRIPCION;
                        //  worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Style.Numberformat.Format = "dd/mm/yyyy";
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item.enero;
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item.febrero;
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item.marzo;

                        worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item.abril;
                        worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item.mayo;
                        worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item.junio;
                        worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = item.julio;
                        worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = item.agosto;
                        worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = item.septiembre;
                        worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = item.octubre;
                        worksheet.Cells[HelperSigo.GetColum(12) + rowStart.ToString()].Value = item.noviembre;
                        worksheet.Cells[HelperSigo.GetColum(13) + rowStart.ToString()].Value = item.diciembre;
                        worksheet.Cells[HelperSigo.GetColum(14) + rowStart.ToString()].Value = item.TOTAL;
                        rowStart = rowStart + 1;
                    }
                    string modelRange = "A2:N" + (rowStart - 1).ToString();
                    var modelTable = worksheet.Cells[modelRange];
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                string excelName = "ReporteRegSigo";
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);
                    return new BinaryContentResultDowload
                    {
                        FileName = excelName + ".xlsx",
                        ContentType = "application/octet-stream",
                        Content = memoryStream.ToArray()
                    };
                }
            }
        }
        public ActionResult RptRegistroInformacionDL()
        {

            List<Ent_Reporte_ProduccionXDigitadores> lstResult = new List<Ent_Reporte_ProduccionXDigitadores>();
            lstResult = (List<Ent_Reporte_ProduccionXDigitadores>)Session["listCEntidadDetalle"];

            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/ReporteInformacionRegistradaDL.xlsx"));
            int rowStart = 2;
            //int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();
                if (lstResult.Count > 0)
                {
                    foreach (var item in lstResult)
                    {
                        worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = item.DESCRIPCION;
                        //  worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Style.Numberformat.Format = "dd/mm/yyyy";
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item.enero;
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item.febrero;
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item.marzo;

                        worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item.abril;
                        worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item.mayo;
                        worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item.junio;
                        worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = item.julio;
                        worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = item.agosto;
                        worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = item.septiembre;
                        worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = item.octubre;
                        worksheet.Cells[HelperSigo.GetColum(12) + rowStart.ToString()].Value = item.noviembre;
                        worksheet.Cells[HelperSigo.GetColum(13) + rowStart.ToString()].Value = item.diciembre;
                        worksheet.Cells[HelperSigo.GetColum(14) + rowStart.ToString()].Value = item.TOTAL;
                        rowStart = rowStart + 1;
                    }
                    string modelRange = "A2:N" + (rowStart - 1).ToString();
                    var modelTable = worksheet.Cells[modelRange];
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                string excelName = "ReporteRegDL";
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);
                    return new BinaryContentResultDowload
                    {
                        FileName = excelName + ".xlsx",
                        ContentType = "application/octet-stream",
                        Content = memoryStream.ToArray()
                    };
                }
            }
        }
        public ActionResult RptRegistroInformacionDL2()
        {

            List<Ent_Reporte_ProduccionXDigitadores> lstResult = new List<Ent_Reporte_ProduccionXDigitadores>();
            lstResult = (List<Ent_Reporte_ProduccionXDigitadores>)Session["listCEntidadDetalle2"];

            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/ReporteInformacionRegistra2.xlsx"));
            int rowStart = 2;
            int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();
                if (lstResult.Count > 0)
                {
                    foreach (var item in lstResult)
                    {
                        worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = ++contador;
                        //  worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Style.Numberformat.Format = "dd/mm/yyyy";
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item.TIPO;
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item.MODALIDAD;
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item.TITULO;

                        worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item.CARTA;
                        worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item.NUM_RD;
                        worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Style.Numberformat.Format = "dd/mm/yyyy";
                        worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item.FECHA_EMISION.Trim() == "" ? (DateTime?)null : Convert.ToDateTime(item.FECHA_EMISION);
                        worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Style.Numberformat.Format = "dd/mm/yyyy";
                        worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = item.FECHA_NOTIFICACION_TITULAR.Trim() == "" ? (DateTime?)null : Convert.ToDateTime(item.FECHA_NOTIFICACION_TITULAR);
                        worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = item.DEPARTAMENTO;
                        worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = item.PROVINCIA;
                        rowStart = rowStart + 1;
                    }
                    string modelRange = "A2:J" + (rowStart - 1).ToString();
                    var modelTable = worksheet.Cells[modelRange];
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                string excelName = "ReporteRegNotificación";
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);
                    return new BinaryContentResultDowload
                    {
                        FileName = excelName + ".xlsx",
                        ContentType = "application/octet-stream",
                        Content = memoryStream.ToArray()
                    };
                }
            }
        }
        public ActionResult RptRegistroExpediente()
        {

            List<Ent_Reporte_ProduccionXDigitadores> lstResult = new List<Ent_Reporte_ProduccionXDigitadores>();
            lstResult = (List<Ent_Reporte_ProduccionXDigitadores>)Session["listCEntidadExpediente"];

            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/ReporteInformacionRegistradaExpediente.xlsx"));
            int rowStart = 2;
            int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();
                if (lstResult.Count > 0)
                {
                    foreach (var item in lstResult)
                    {
                        worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = ++contador;
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item.MODALIDAD;
                        //  worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Style.Numberformat.Format = "dd/mm/yyyy";
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item.enero;
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item.febrero;
                        worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item.marzo;

                        worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item.abril;
                        worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item.mayo;
                        worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = item.junio;
                        worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = item.julio;
                        worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = item.agosto;
                        worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = item.septiembre;
                        worksheet.Cells[HelperSigo.GetColum(12) + rowStart.ToString()].Value = item.octubre;
                        worksheet.Cells[HelperSigo.GetColum(13) + rowStart.ToString()].Value = item.noviembre;
                        worksheet.Cells[HelperSigo.GetColum(14) + rowStart.ToString()].Value = item.diciembre;
                        worksheet.Cells[HelperSigo.GetColum(15) + rowStart.ToString()].Value = item.TOTAL;
                        rowStart = rowStart + 1;
                    }
                    string modelRange = "A2:O" + (rowStart - 1).ToString();
                    var modelTable = worksheet.Cells[modelRange];
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                string excelName = "ReporteExpediente";
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);
                    return new BinaryContentResultDowload
                    {
                        FileName = excelName + ".xlsx",
                        ContentType = "application/octet-stream",
                        Content = memoryStream.ToArray()
                    };
                }
            }
        }
        public ActionResult RptRegistroExpedienteDetalle()
        {

            List<Ent_Reporte_ProduccionXDigitadores> lstResult = new List<Ent_Reporte_ProduccionXDigitadores>();
            lstResult = (List<Ent_Reporte_ProduccionXDigitadores>)Session["listCEntidadExpedienteDetalle"];

            FileInfo template = new FileInfo(Server.MapPath("~/Archivos/Plantilla/ReporteInformacionRegistradaExpedienteD.xlsx"));
            int rowStart = 2;
            int contador = 0;
            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();
                if (lstResult.Count > 0)
                {
                    foreach (var item in lstResult)
                    {
                        worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = ++contador;
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Style.Numberformat.Format = "dd/mm/yyyy";
                        worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item.FECHA.Trim() == "" ? (DateTime?)null : Convert.ToDateTime(item.FECHA);
                        worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item.MODALIDAD;
                        worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item.TITULO;

                        worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item.TIPO;
                        worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item.DEPARTAMENTO;
                        worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item.PROVINCIA;
                        rowStart = rowStart + 1;
                    }
                    string modelRange = "A2:G" + (rowStart - 1).ToString();
                    var modelTable = worksheet.Cells[modelRange];
                    modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                string excelName = "ReporteExpedienteDetalle";
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);
                    return new BinaryContentResultDowload
                    {
                        FileName = excelName + ".xlsx",
                        ContentType = "application/octet-stream",
                        Content = memoryStream.ToArray()
                    };
                }
            }
        }
        #endregion

        #region "Informes legales por especialista"
        public ActionResult Rpt_Prod_EspLegal()
        {
            VM_ReporteGeneral vmRpt = new VM_ReporteGeneral();
            List<VM_Chk> lstChkItem;
            CapaLogica.DOC.Log_ControlCalidad exeBus = new CapaLogica.DOC.Log_ControlCalidad();
            Ent_ControlCalidad OCEntidad = new Ent_ControlCalidad();
            try
            {
                OCEntidad = exeBus.RegMostCombo(OCEntidad);
                lstChkItem = new List<VM_Chk>();
                for (int i = DateTime.Now.Year; i >= 2004; i--)
                    lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                vmRpt.lstChkAnio = lstChkItem;
                vmRpt.listDireccionLinea = OCEntidad.ListDireccionLinea;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            return View(vmRpt);
        }

        public ActionResult ReporteProdEL(string[] direccion, string[] anio, string codUsuario, bool chkProfesional)
        {
            try
            {
                vmReport = new VM_ReporteGeneral();
                Ent_REPORTE_FISCALIZACION oCEntidad = new Ent_REPORTE_FISCALIZACION();
                Log_REPORTE_FISCALIZACION exeBus = new Log_REPORTE_FISCALIZACION();
                oCEntidad.BusAnio = ObtenerCadenaArray(anio);
                oCEntidad.BusDireccion = ObtenerCadenaArray(direccion);
                oCEntidad.BusCriterio = "1";
                if (chkProfesional == true)
                {
                    oCEntidad.COD_PROFESIONAL = codUsuario;
                }
                vmReport.listResumenEL = new List<Ent_REPORTE_FISCALIZACION>();
                vmReport.listResumenEL = exeBus.LogInformexEspecialista(oCEntidad);
                vmReport.tituloReporte = "Informes Legales por Especialista" + oCEntidad.BusAnio;
                int total1 = 0;
                int total2 = 0;
                int total3 = 0;
                int total4 = 0;
                int total5 = 0;
                if (vmReport.listResumenEL.Count > 0)
                {
                    for (int i = 0; i < vmReport.listResumenEL.Count; i++)
                    {
                        total1 = total1 + vmReport.listResumenEL[i].IL_EVA_INF_SUP;
                        total2 = total2 + vmReport.listResumenEL[i].IL_ETAPA_INSTRU;
                        total3 = total3 + vmReport.listResumenEL[i].IL_EVA_REC_RECONS;
                        total4 = total4 + vmReport.listResumenEL[i].IL_OTROS;
                        total5 = total5 + vmReport.listResumenEL[i].IL_FINAL;

                    }
                }
                vmReport.subTEvaluacion = total1.ToString();
                vmReport.subTInstructiva = total2.ToString();
                vmReport.subTReconsideracion = total3.ToString();
                vmReport.subTOtros = total4.ToString();
                vmReport.subTFinal = total5.ToString();
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            return PartialView("~/Areas/General/Views/Reportes/_sharedRptProdU/_renderRELResumen.cshtml", vmReport);
        }

        public ActionResult ReporteProdELDetalle(string[] direccion, string[] anio, string codFCTipo, string codigo)
        {
            try
            {
                // vmReport = new VM_ReporteGeneral();
                Ent_REPORTE_FISCALIZACION oCEntidad = new Ent_REPORTE_FISCALIZACION();
                Log_REPORTE_FISCALIZACION exeBus = new Log_REPORTE_FISCALIZACION();
                oCEntidad.BusAnio = ObtenerCadenaArray(anio);
                oCEntidad.BusDireccion = ObtenerCadenaArray(direccion);
                oCEntidad.BusCriterio = "3";
                oCEntidad.COD_FCTIPO = codFCTipo;
                oCEntidad.COD_PROFESIONAL = codigo;
                vmReport.listDetalleEL1 = new List<Ent_REPORTE_FISCALIZACION>();
                vmReport.listDetalleEL1 = exeBus.LogInformexEspecialista(oCEntidad);
                vmReport.tituloReporteDetalle = "Listado de informes legales [" + vmReport.listDetalleEL1[0].Tipo_Informe + "] del especialista [" + vmReport.listDetalleEL1[0].APELLIDOS_NOMBRES + "]";
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            return PartialView("~/Areas/General/Views/Reportes/_sharedRptProdU/_renderRELDetalle1.cshtml", vmReport);
        }

        public ActionResult ReporteProdELDetalle2(string[] direccion, string[] anio, string codFCTipo, string codUsuario, bool chkProfesional)
        {
            try
            {
                // vmReport = new VM_ReporteGeneral();
                Ent_REPORTE_FISCALIZACION oCEntidad = new Ent_REPORTE_FISCALIZACION();
                Log_REPORTE_FISCALIZACION exeBus = new Log_REPORTE_FISCALIZACION();
                oCEntidad.BusDireccion = ObtenerCadenaArray(direccion);
                oCEntidad.BusAnio = ObtenerCadenaArray(anio);
                oCEntidad.BusCriterio = "2";
                oCEntidad.COD_FCTIPO = codFCTipo;
                if (chkProfesional == true)
                {
                    oCEntidad.COD_PROFESIONAL = codUsuario;
                }
                vmReport.listDetalleEL1 = new List<Ent_REPORTE_FISCALIZACION>();
                vmReport.listDetalleEL1 = exeBus.LogInformexEspecialista(oCEntidad);
                vmReport.tituloReporteDetalle = "Informes legales [" + vmReport.listDetalleEL1[0].Tipo_Informe + "] por modalidad";
                decimal total1 = 0;
                decimal total2 = 0;
                decimal total3 = 0;
                decimal total4 = 0;
                decimal total5 = 0;
                decimal total6 = 0;
                decimal total7 = 0;
                decimal total8 = 0;
                decimal total9 = 0;
                decimal total10 = 0;
                decimal total11 = 0;
                decimal total12 = 0;
                int total13 = 0;

                if (vmReport.listDetalleEL1.Count > 0)
                {
                    for (int i = 0; i < vmReport.listDetalleEL1.Count; i++)
                    {
                        total1 = total1 + vmReport.listDetalleEL1[i].CANT_CCCC_CCNN;
                        total2 = total2 + vmReport.listDetalleEL1[i].CANT_PP;
                        total3 = total3 + vmReport.listDetalleEL1[i].CANT_BS;
                        total4 = total4 + vmReport.listDetalleEL1[i].CANT_BL;
                        total5 = total5 + vmReport.listDetalleEL1[i].CANT_PFAUNA;
                        total6 = total6 + vmReport.listDetalleEL1[i].CANT_CMADE;
                        total7 = total7 + vmReport.listDetalleEL1[i].CANT_NM;
                        total8 = total8 + vmReport.listDetalleEL1[i].CANT_FYR;
                        total9 = total9 + vmReport.listDetalleEL1[i].CANT_ECO;
                        total10 = total10 + vmReport.listDetalleEL1[i].CANT_CONS;
                        total11 = total11 + vmReport.listDetalleEL1[i].CANT_CFAUNA;
                        total12 = total12 + vmReport.listDetalleEL1[i].CANT_PNM;
                        total13 = total13 + vmReport.listDetalleEL1[i].TOTAL;
                    }
                }
                vmReport.subT01 = total1.ToString();
                vmReport.subT02 = total2.ToString();
                vmReport.subT03 = total3.ToString();
                vmReport.subT04 = total4.ToString();
                vmReport.subT05 = total5.ToString();
                vmReport.subT06 = total6.ToString();
                vmReport.subT07 = total7.ToString();
                vmReport.subT08 = total8.ToString();
                vmReport.subT09 = total9.ToString();
                vmReport.subT10 = total10.ToString();
                vmReport.subT11 = total11.ToString();
                vmReport.subT12 = total12.ToString();
                vmReport.subT13 = total13.ToString();

            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            return PartialView("~/Areas/General/Views/Reportes/_sharedRptProdU/_renderRELDetalle2.cshtml", vmReport);
        }
        #endregion

        #region Reporte Informes tecnicos
        public ActionResult Rpt_Tecnico_EspLegal()
        {
            VM_ReporteGeneral vmRpt = new VM_ReporteGeneral();
            List<VM_Chk> lstChkItem;
            CapaLogica.DOC.Log_ControlCalidad exeBus = new CapaLogica.DOC.Log_ControlCalidad();
            Ent_ControlCalidad OCEntidad = new Ent_ControlCalidad();
            try
            {
                OCEntidad = exeBus.RegMostCombo(OCEntidad);
                lstChkItem = new List<VM_Chk>();
                for (int i = DateTime.Now.Year; i >= 2004; i--)
                    lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                vmRpt.lstChkAnio = lstChkItem;
                vmRpt.listDireccionLinea = OCEntidad.ListDireccionLinea;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            return View(vmRpt);
        }

        public ActionResult ReporteInfTecResumen(string[] direccion, string[] anio, string codUsuario, bool chkProfesional)
        {
            try
            {
                vmReport = new VM_ReporteGeneral();
                Ent_REPORTE_FISCALIZACION oCEntidad = new Ent_REPORTE_FISCALIZACION();
                Log_REPORTE_FISCALIZACION exeBus = new Log_REPORTE_FISCALIZACION();
                oCEntidad.BusAnio = ObtenerCadenaArray(anio);
                oCEntidad.BusDireccion = ObtenerCadenaArray(direccion);
                oCEntidad.BusCriterio = "1";
                if (chkProfesional == true)
                {
                    oCEntidad.COD_PROFESIONAL = codUsuario;
                }
                vmReport.listResumenEL = new List<Ent_REPORTE_FISCALIZACION>();
                vmReport.listResumenEL = exeBus.LogInformeTecnicoxEspecialista(oCEntidad);
                vmReport.tituloReporte = "Informes Técnicos por Especialista en los años: " + oCEntidad.BusAnio;
                int total1 = 0;
                int total2 = 0;
                int total3 = 0;
                int total4 = 0;
                int total5 = 0;
                int total6 = 0;

                if (vmReport.listResumenEL.Count > 0)
                {
                    for (int i = 0; i < vmReport.listResumenEL.Count; i++)
                    {

                        total1 = total1 + vmReport.listResumenEL[i].IL_EVA_INF_SUP;
                        total2 = total2 + vmReport.listResumenEL[i].IL_ETAPA_INSTRU;
                        total3 = total3 + vmReport.listResumenEL[i].IL_CONFORMIDAD;
                        total4 = total4 + vmReport.listResumenEL[i].TOTAL_PRIMERO;
                        total5 = total5 + vmReport.listResumenEL[i].OTROS;
                        total6 = total5 + vmReport.listResumenEL[i].TOTAL;

                    }
                }

                vmReport.subTEvaluacion = total1.ToString();
                vmReport.subTInstructiva = total2.ToString();
                vmReport.subTReconsideracion = total3.ToString();
                vmReport.subTOtros = total4.ToString();
                vmReport.subTFinal = total5.ToString();

            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            return PartialView("~/Areas/General/Views/Reportes/_sharedRptInformeTecnico/_renderRptaResumen.cshtml", vmReport);
        }

        public ActionResult ReporteProdInfTecDetalle(string[] direccion, string[] anio, string modalidad, string codigo)
        {
            try
            {
                // vmReport = new VM_ReporteGeneral();
                Ent_REPORTE_FISCALIZACION oCEntidad = new Ent_REPORTE_FISCALIZACION();
                Log_REPORTE_FISCALIZACION exeBus = new Log_REPORTE_FISCALIZACION();
                oCEntidad.BusAnio = ObtenerCadenaArray(anio);
                oCEntidad.BusDireccion = ObtenerCadenaArray(direccion);
                oCEntidad.BusCriterio = "2";
                oCEntidad.MODALIDAD = modalidad;
                oCEntidad.COD_PROFESIONAL = codigo;
                vmReport.listDetalleEL1 = new List<Ent_REPORTE_FISCALIZACION>();
                vmReport.listDetalleEL1 = exeBus.LogInformeTecnicoEspecialistaDetalle(oCEntidad);
                vmReport.tituloReporteDetalle = "Listado de informes técnicos [" + vmReport.listDetalleEL1[0].Tipo_Informe + "] del especialista [" + vmReport.listDetalleEL1[0].APELLIDOS_NOMBRES + "]";
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            return PartialView("~/Areas/General/Views/Reportes/_sharedRptInformeTecnico/_renderRpteDetalle01.cshtml", vmReport);
        }

        public ActionResult ReporteProdInfTecDetalle2(string[] direccion, string[] anio, string modalidad, string codUsuario, bool chkProfesional)
        {
            try
            {
                // vmReport = new VM_ReporteGeneral();
                Ent_REPORTE_FISCALIZACION oCEntidad = new Ent_REPORTE_FISCALIZACION();
                Log_REPORTE_FISCALIZACION exeBus = new Log_REPORTE_FISCALIZACION();
                oCEntidad.BusDireccion = ObtenerCadenaArray(direccion);
                oCEntidad.BusAnio = ObtenerCadenaArray(anio);
                oCEntidad.BusCriterio = "2";
                oCEntidad.MODALIDAD = modalidad;
                if (chkProfesional == true)
                {
                    oCEntidad.COD_PROFESIONAL = codUsuario;
                }
                vmReport.listDetalleEL1 = new List<Ent_REPORTE_FISCALIZACION>();
                vmReport.listDetalleEL1 = exeBus.LogInformeTecnicoxEspecialista(oCEntidad);
                vmReport.tituloReporteDetalle = "Informes técnicos [" + vmReport.listDetalleEL1[0].Tipo_Informe + "] por modalidad";
                decimal total1 = 0;
                decimal total2 = 0;
                decimal total3 = 0;
                decimal total4 = 0;
                decimal total5 = 0;
                decimal total6 = 0;
                decimal total7 = 0;
                decimal total8 = 0;
                decimal total9 = 0;
                decimal total10 = 0;
                decimal total11 = 0;
                decimal total12 = 0;

                if (vmReport.listDetalleEL1.Count > 0)
                {
                    for (int i = 0; i < vmReport.listDetalleEL1.Count; i++)
                    {
                        total1 = total1 + vmReport.listDetalleEL1[i].CANT_CCCC_CCNN;
                        total2 = total2 + vmReport.listDetalleEL1[i].CANT_PP;
                        total3 = total3 + vmReport.listDetalleEL1[i].CANT_BS;
                        total4 = total4 + vmReport.listDetalleEL1[i].CANT_BL;
                        total5 = total5 + vmReport.listDetalleEL1[i].CANT_PFAUNA;
                        total6 = total6 + vmReport.listDetalleEL1[i].CANT_CMADE;
                        total7 = total7 + vmReport.listDetalleEL1[i].CANT_NM;
                        total8 = total8 + vmReport.listDetalleEL1[i].CANT_FYR;
                        total9 = total9 + vmReport.listDetalleEL1[i].CANT_ECO;
                        total10 = total10 + vmReport.listDetalleEL1[i].CANT_CONS;
                        total11 = total11 + vmReport.listDetalleEL1[i].CANT_CFAUNA;
                        total12 = total12 + vmReport.listDetalleEL1[i].TOTAL;

                    }
                }
                vmReport.subT01 = total1.ToString();
                vmReport.subT02 = total2.ToString();
                vmReport.subT03 = total3.ToString();
                vmReport.subT04 = total4.ToString();
                vmReport.subT05 = total5.ToString();
                vmReport.subT06 = total6.ToString();
                vmReport.subT07 = total7.ToString();
                vmReport.subT08 = total8.ToString();
                vmReport.subT09 = total9.ToString();
                vmReport.subT10 = total10.ToString();
                vmReport.subT11 = total11.ToString();
                vmReport.subT12 = total12.ToString();

            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            return PartialView("~/Areas/General/Views/Reportes/_sharedRptInformeTecnico/_renderRpteDetalle02.cshtml", vmReport);
        }

        public JsonResult graficarITPermiso()
        {
            Double Total = Double.Parse(vmReport.subT01) + Double.Parse(vmReport.subT02) + Double.Parse(vmReport.subT03) + Double.Parse(vmReport.subT04) + Double.Parse(vmReport.subT05);
            double T01 = Double.Parse(vmReport.subT01);
            double T02 = Double.Parse(vmReport.subT02);
            double T03 = Double.Parse(vmReport.subT03);
            double T04 = Double.Parse(vmReport.subT04) + Double.Parse(vmReport.subT05);

            double[] itemPermiso = { T01, T02, T03, T04 };

            var jsonResult = Json(new
            {
                data = itemPermiso.ToArray(),
                succes = true,
            }, JsonRequestBehavior.AllowGet);

            return jsonResult;
        }

        public JsonResult graficarITConseciones()
        {
            Double Total = Double.Parse(vmReport.subT06) + Double.Parse(vmReport.subT07) + Double.Parse(vmReport.subT08) + Double.Parse(vmReport.subT09) + Double.Parse(vmReport.subT10) + Double.Parse(vmReport.subT11);
            double T01 = Double.Parse(vmReport.subT06);
            double T02 = Double.Parse(vmReport.subT07);
            double T03 = Double.Parse(vmReport.subT08);
            double T04 = Double.Parse(vmReport.subT09) + Double.Parse(vmReport.subT10);

            double[] itemConsecion = { T01, T02, T03, T04 };

            var jsonResult = Json(new
            {
                data = itemConsecion.ToArray(),
                succes = true,
            }, JsonRequestBehavior.AllowGet);

            return jsonResult;
        }

        #endregion

        #region reporte producion por especialista legal
        public ActionResult Rpt_ProduccionEL()
        {
            VM_ReporteGeneral vmRpt = new VM_ReporteGeneral();
            List<VM_Chk> lstChkItem;
            CapaLogica.DOC.Log_ControlCalidad exeBus = new CapaLogica.DOC.Log_ControlCalidad();
            Ent_ControlCalidad OCEntidad = new Ent_ControlCalidad();
            try
            {
                OCEntidad = exeBus.RegMostCombo(OCEntidad);
                lstChkItem = new List<VM_Chk>();
                for (int i = DateTime.Now.Year; i >= 2004; i--)
                    lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                vmRpt.lstChkAnio = lstChkItem;
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            return View(vmRpt);
        }

        public ActionResult ReporteProduccionEL(string anio)
        {
            try
            {
                vmReport = new VM_ReporteGeneral();
                Ent_Reporte_ProduccionXDigitadores oCEntidad = new Ent_Reporte_ProduccionXDigitadores();
                Log_Reporte_ProduccionXDigitadores exeBus = new Log_Reporte_ProduccionXDigitadores();
                oCEntidad.BusValor = anio;
                vmReport.listProduccionEL = new List<Ent_Reporte_ProduccionXDigitadores>();
                vmReport.listProduccionEL = exeBus.logProduccionEspecialista(oCEntidad);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msj = ex.Message, data = "" });
            }
            return PartialView("~/Areas/General/Views/Reportes/_sharedRptProdEL/_renderRptProdEL.cshtml", vmReport);
        }
        #endregion

        #region Reporte de Obligaciones Titulares
        [HttpPost]
        public ActionResult RptObligacionesTitulares(Dictionary<string, string> cabecera, List<Dictionary<string, string>> resumen, string opcion = null)
        {
            string dir = string.Format("~/Archivos/Plantilla/Report_SupervisionesDispObligaciones{0}.xlsx", opcion == "NM" ? opcion : (opcion == "NM_new" ? opcion : (opcion != "_new" ? "" : opcion)));
            FileInfo template = new FileInfo(Server.MapPath(dir));
            int rowStart = 3;

            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();

                if (resumen != null)
                {
                    int column = 0;

                    foreach (var item in resumen)
                    {

                        column = 0;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = rowStart - 2;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["DEPARTAMENTO"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["MODALIDAD_TIPO"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["NUM_THABILITANTE"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["TITULAR"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["INFORME"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["FECHA_SUPERVISION_INICIO"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OPORTUNIDAD_SUPERVISION"];
                        //M
                        if (opcion != "NM" && opcion != "NM_new")
                        {
                            //if (opcion != "_new")
                            //{
                            //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_PRESENTOPLANMANEJO"];
                            //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_PRESENTOPLANMANEJOCONFORMIDAD"];
                            //}
                            //else
                            //{
                            //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_PRESENTOPLANMANEJO_01"];
                            //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_PRESENTOPLANMANEJO_02"];
                            //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_PRESENTOPLANMANEJOCONFORMIDAD_01"];
                            //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_PRESENTOPLANMANEJOCONFORMIDAD_02"];
                            //}


                            //worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_PAGOAPROVECHAMIENTO"];
                            //if (opcion != "_new")
                            //{
                            //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_MANTIENELIBROOPERACIONES"];
                            //}
                            //else
                            //{

                            //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_MANTIENELIBROOPERACIONES_01"];
                            //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_MANTIENELIBROOPERACIONES_02"];
                            //}
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_PRESENTOPLANMANEJO_01"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_PRESENTOPLANMANEJO_02"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_PRESENTOPLANMANEJOCONFORMIDAD_01"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_PRESENTOPLANMANEJOCONFORMIDAD_02"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_PAGOAPROVECHAMIENTO"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_MANTIENELIBROOPERACIONES_01"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_MANTIENELIBROOPERACIONES_02"];


                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_COMUNICOARFFSOSINFORSUSCRIPCION"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_COMUNICOARFFSOSINFORSUSCRIPCION_2"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_REPORTOARFFSMINISTERIOAVISTAMIENTOS"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_REALIZOACCIONESCUSTODIO"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_FACILITODESARROLLO"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_ASUMIOCOSTOSUPERVISIONES"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_IMPLEMENTAMECANISMOTRAZA"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_RESPETASERVIDUMBRE"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_CUENTAREGENTE"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_CUENTAREGENTE_2"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_ADOPTAMEDIDASEXTENSION"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_RESPETAVALORES"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_CUMPLEMEDIDAS"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_CUMPLENORMAS"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_MOVILIZAFRUTOPRODUCTOS"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_CUMPLEMARCADOTROZAS"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_ESTABLECELINDEROS"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_IMPLEMENTACIONMEDIDASCORRECTIVAS"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_PROMUEVENBUENASPRACTICAS"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_PROMUEVEEQUIDAD"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_MANTIENEVIGENTEGARANTIA"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_CUMPLECOMPROMISOINVERSION"];
                        }
                        else
                        {
                            //NM
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_PRESENTOPMF"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_PRESENTOPMF_2"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_PRESENTOINFORMEEJECUCION"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_PRESENTOINFORMEEJECUCION_2"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_PAGOAPROVECHAMIENTO"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_SERFOR_1"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_SERFOR_2"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION_2"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_REALIZOACCIONESCUSTODIO"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_FACILITODESARROLLO"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_ASUMIOCOSTOSUPERVISIONES"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_IMPLEMENTAMECANISMOTRAZA"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_RESPETASERVIDUMBRE"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_IMPLEMENTAPLAN"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_REGENTE"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_ADOPTAMEDIDASEXTENSION"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_RESPETAVALORES"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_CUMPLEMEDIDAS"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_CUMPLENORMAS"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_MOVILIZAFRUTOPRODUCTOS"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_MARCADOTROZA"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_MANTIENELINDERO"];
                            //worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_IMPMEDCORRECRESULTADOACCIONES"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_PROMUEVENBUENASPRACTICAS"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_PROMUEVEEQUIDAD"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_MANTIENEACTGRTIA"];
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_COMPROMISOINVERSION"];

                            //if (opcion != "NM")
                            //{
                            //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLI_NM_MANTIENEACTGRTIA"];
                            //}

                        }


                        //RESULTADO
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Formula = "SUMIF(" + "I" + rowStart.ToString() + ":" + (opcion == "NM" ? "AA" : (opcion == "NM_new" ? "AK" : (opcion == "_new" ? "AK" : "AF"))) + rowStart.ToString() + (opcion == "NM" ? ",AK1,I1:AA1)" : (opcion == "NM_new" ? ",AL1,I1:AK1)" : (opcion == "_new" ? ",AL1,I1:AK1)" : ",AG1,I1:AF1)")));

                        //DENOMINADOR
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Formula = "SUMIF(" + "I" + rowStart.ToString() + ":" + (opcion == "NM" ? "AA" : (opcion == "NM_new" ? "AK" : (opcion == "_new" ? "AK" : "AF"))) + rowStart.ToString() + (opcion == "NM" ? ",AK1,I1:AA1)" : (opcion == "NM_new" ? ",AL1,I1:AK1)" : (opcion == "_new" ? ",AL1,I1:AK1)" : ",AG1,I1:AF1)"))) + "+SUMIF(" + "I" + rowStart.ToString() + ":" + (opcion == "NM" ? "AA" : (opcion == "NM_new" ? "AK" : (opcion == "_new" ? "AK" : "AF"))) + rowStart.ToString() + (opcion == "NM" ? ",AL1,I1:AA1)" : (opcion == "NM_new" ? ",AM1,I1:AK1)" : (opcion == "_new" ? ",AM1,I1:AK1)" : ",AH1,I1:AF1)")));

                        //INDICE
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Formula = (opcion == "NM" ? "IF(AL" : (opcion == "NM_new" ? "IF(AM" : (opcion == "_new" ? "IF(AM" : "IF(AH"))) + rowStart.ToString() + "=0, 0," + (opcion == "NM" ? "AB" : (opcion == "NM_new" ? "AL" : (opcion == "_new" ? "AL" : "AG"))) + rowStart.ToString() + "/" + (opcion == "NM" ? "AL" : (opcion == "NM_new" ? "AM" : (opcion == "_new" ? "AM" : "AH"))) + rowStart.ToString() + ")*100"; ;
                        worksheet.Cells[HelperSigo.GetColum(column) + rowStart.ToString()].Style.Numberformat.Format = "#0\\.00%";

                        //TGS: CERTIFICADO 02/10/2021
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["CERTIFICADO"];
                        rowStart++;
                    }


                }
                string excelName = cabecera["Titulo"] != null ? cabecera["Titulo"].ToString() : "rptObligacionesTitulares" + (opcion != null ? "M" : "NM");
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);
                    return new BinaryContentResultDowload
                    {
                        FileName = excelName + ".xlsx",
                        ContentType = "application/octet-stream",
                        Content = memoryStream.ToArray()
                    };
                }
            }
        }

        [HttpPost]
        public ActionResult RptObligacionesTitularesFauna(Dictionary<string, string> cabecera, List<Dictionary<string, string>> resumen, string opcion = null)
        {
            string dir = string.Format("~/Archivos/Plantilla/Report_SupervisionesDispObligacionesFauna{0}.xlsx", (opcion != "_new" ? "" : "_new"));
            FileInfo template = new FileInfo(Server.MapPath(dir));
            int rowStart = 3;

            using (var package = new ExcelPackage(template))
            {
                var workbook = package.Workbook;
                ExcelWorksheet worksheet = workbook.Worksheets.First();

                if (resumen != null)
                {
                    int column = 0;

                    foreach (var item in resumen)
                    {

                        column = 0;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = rowStart - 2;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["DEPARTAMENTO"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["MODALIDAD_TIPO"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["NUM_THABILITANTE"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["TITULAR"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["INFORME"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["FECHA_SUPERVISION_INICIO"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OPORTUNIDAD_SUPERVISION"];
                        //Fauna
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_01"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_001"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_02"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_002"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_03"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_04"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_004"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_05"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_06"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_07"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_08"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_09"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_10"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_11"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_12"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_13"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_013"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_14"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_15"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_16"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_17"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_18"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_19"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_20"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_21"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_22"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_23"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_24"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_25"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_26"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_27"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_28"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_29"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_30"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_31"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_32"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_33"];
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_34"];

                        //if (opcion=="_new")
                        //{
                        //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_31"];
                        //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_32"];
                        //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_33"];
                        //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["OBLIG_34"];
                        //}



                        //RESULTADO
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Formula = "SUMIF(" + "I" + rowStart.ToString() + ":" + (opcion == "_new" ? "AT" : "AL") + rowStart.ToString() + (opcion == "_new" ? ",AU1,I1:AT1)" : ",AM1,I1:AL1)");

                        //DENOMINADOR
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Formula = "SUMIF(" + "I" + rowStart.ToString() + ":" + (opcion == "_new" ? "AT" : "AL") + rowStart.ToString() + (opcion == "_new" ? ",AU1,I1:AT1)" : ",AM1,I1:AL1)") + "+SUMIF(" + "I" + rowStart.ToString() + ":" + (opcion == "_new" ? "AT" : "AL") + rowStart.ToString() + (opcion == "_new" ? ",AV1,I1:AT1)" : ",AN1,I1:AL1)");

                        //INDICE
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Formula = (opcion == "_new" ? "IF(AV" : "IF(AN") + rowStart.ToString() + "=0, 0," + (opcion == "_new" ? "AU" : "AM") + rowStart.ToString() + "/" + (opcion == "_new" ? "AV" : "AN") + rowStart.ToString() + ")*100"; ;
                        worksheet.Cells[HelperSigo.GetColum(column) + rowStart.ToString()].Style.Numberformat.Format = "#0\\.00%";

                        //TGS: CERTIFICADO 02/10/2021
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item["CERTIFICADO"];
                        rowStart++;
                    }


                }
                string excelName = cabecera["Titulo"] != null ? cabecera["Titulo"].ToString() : "rptObligacionesTitularesFauna";
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);
                    return new BinaryContentResultDowload
                    {
                        FileName = excelName + ".xlsx",
                        ContentType = "application/octet-stream",
                        Content = memoryStream.ToArray()
                    };
                }
            }
        }

        #endregion

        [HttpGet]
        public ActionResult IndicadoresOSINFOR(string ind)
        {
            string view = "";

            switch (ind)
            {
                case "1": view = "IndicadoresOSINFOR_1"; break;
                case "2": view = "IndicadoresOSINFOR_2"; break;
                case "3": view = "IndicadoresOSINFOR_3"; break;
                case "4": view = "IndicadoresOSINFOR_4"; break;
            }

            return View(view);
        }

        #region Rpt_TH_Comportamiento

        #region View
        [HttpGet]
        public ActionResult Rpt_TH_Comportamiento()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ViewTHComportamiento(int asNU_Entidad)
        {
            vmTHComportamiento = new VMTHComportamiento();
            CEntidadTH oTHEntidad = new CEntidadTH();
            CapaLogica.DOC.Log_THComportamiento exeBus = new CapaLogica.DOC.Log_THComportamiento();
            oTHEntidad.NU_ENTIDAD = asNU_Entidad;
            vmTHComportamiento = exeBus.RegMostrarTHComportamiento(oTHEntidad);
            ViewBag.txtAnio = string.Join("|", vmTHComportamiento.ListTHCalificacion.Select(c => c.NU_ANIO.ToString()));
            ViewBag.txtPuntaje = string.Join("|", vmTHComportamiento.ListTHCalificacion.Select(c => c.NU_PUNTAJE.ToString()));

            return View(vmTHComportamiento);
        }
        #endregion

        #region Action
        [HttpPost]

        public JsonResult ExportTHComportamiento(string cboTipo)
        {
            ListResult result = new ListResult();
            CapaLogica.DOC.Log_THComportamiento exeBus = new CapaLogica.DOC.Log_THComportamiento();
            var listComportamiento = exeBus.RegMostrarListTHComportamiento(cboTipo);

            try
            {
                if (listComportamiento != null)
                {
                    if (listComportamiento.Count() > 0)
                    {
                        int i = 1;
                        String insertar = "";
                        String RutaReporteComportamiento = Server.MapPath("~/Archivos/Plantilla/ReporteComportamiento/");
                        string nombreFile = "";
                        nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                        string rutaExcel = RutaReporteComportamiento + nombreFile;
                        try
                        {
                            System.IO.File.Delete(RutaReporteComportamiento + nombreFile);
                            System.IO.File.Copy(RutaReporteComportamiento + "THComportamiento.xlsx", rutaExcel);
                        }
                        catch (IOException ix)
                        {
                            throw new Exception(ix.Message);
                        }

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
                                foreach (var listaInf in listComportamiento)
                                {
                                    insertar = "";
                                    insertar = "'" + listaInf.NV_MODALIDAD_TIPO + "'";
                                    insertar = insertar + ",'" + listaInf.NV_TITULO_HABILITANTE + "'";
                                    insertar = insertar + ",'" + listaInf.NV_REGION + "'";
                                    insertar = insertar + ",'" + listaInf.NV_PROVINCIA + "'";
                                    insertar = insertar + ",'" + listaInf.NV_DISTRITO + "'";
                                    insertar = insertar + ",'" + listaInf.NV_TITULAR + "'";
                                    insertar = insertar + ",'" + listaInf.NV_DOCUMENTO + "'";
                                    insertar = insertar + ",'" + listaInf.DA_FECHA_VIGENCIA + "'";
                                    insertar = insertar + ",'" + listaInf.NV_AREA + "'";
                                    string calificacion = int.Parse(listaInf.NU_CALIFICACION) <= 3 ? "DEFICIENTE" : (int.Parse(listaInf.NU_CALIFICACION) <= 5 ? "REGULAR" : (int.Parse(listaInf.NU_CALIFICACION) <= 8 ? "BUENO" : "MUY BUENO"));
                                    insertar = insertar + ",'" + calificacion + "'";
                                    cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Y" + (listComportamiento.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                    cmd.ExecuteNonQuery();
                                }

                                //Cerramos la conexión
                                conn.Close();
                            }

                        }
                        result.success = true;
                        result.msj = nombreFile;
                    }
                }
                else
                {
                    throw new Exception("No contiene información la consulta");
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
                return Json(new { success = false, msj = ex.Message });
            }

            return Json(result);
        }

        #endregion

        #endregion
    }
}