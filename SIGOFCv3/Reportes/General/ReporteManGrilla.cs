using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using Herramienta;
using OfficeOpenXml;
using SIGOFCv3.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;
using CEntidad = CapaEntidad.DOC.Ent_BUSQUEDA;
using CLogica = CapaLogica.DOC.Log_BUSQUEDA;
namespace SIGOFCv3.Reportes.General
{
    public class ReporteManGrilla
    {
        public static ListResult GenerarReporteManGrilla(string busFormulario, string cod_UCUENTA, string moduloConsulta = "")
        {
            ListResult result = new ListResult();
            try
            {
                Utilitarios HerUtil = new Utilitarios();
                String filePlantilla = "", codigoTemp = "";
                CLogica oCLogica = new CLogica();
                List<CEntidad> listaRegistros = new List<CEntidad>();
                CEntidad oCampos = new CEntidad();
                oCampos.BusFormulario = busFormulario;
                oCampos.BusCriterio = "REGISTROS_USUARIO";

                if (busFormulario == "PROVEIDO_ARCHIVO" || busFormulario == "RESOLUCION_DIRECTORAL")
                {
                    if (moduloConsulta == "SUPERVISION")
                    {
                        oCampos.BusCriterio = "REGISTROS_USUARIO_SUPERVISION";
                    }
                }
                oCampos.BusValor = cod_UCUENTA;
                listaRegistros = oCLogica.mostrarRegistrosUsuario(oCampos);

                switch (busFormulario)
                {
                    case "GUIA_TRANSPORTE":
                        filePlantilla = "GTF_Reg_Usu.xlsx";
                        break;
                    case "INFORME_TECNICO":
                        filePlantilla = "INFTECNICO_Reg_Usu.xlsx";
                        break;
                    case "FIS_NOTIFICACION":
                        filePlantilla = "FISNOTI_Reg_Usu.xlsx";
                        break;
                    case "PROVEIDO":
                        filePlantilla = "PROVEIDO_Reg_Usu.xlsx";
                        break;
                    case "PROVEIDO_ARCHIVO":
                        filePlantilla = "PROVEIDOARCH_Reg_Usu.xlsx";
                        break;
                    case "TFFS":
                        filePlantilla = "TFFS_Reg_Usu.xlsx";
                        break;
                    case "TITULO_HABILITANTE":
                        filePlantilla = "THABILITANTE_Reg_Usu.xlsx";
                        break;
                    case "PLAN_GENERAL_MANEJO_FORESTAL":
                    case "PLAN_MANEJO_FORESTAL_INTERMEDIO":
                        throw new Exception("Falta Implementar");
                    //break;
                    case "DEMA":
                        filePlantilla = "DEMA_Reg_Usu.xlsx";
                        break;
                    case "POA":
                        filePlantilla = "POA_Reg_Usu.xlsx";
                        break;
                    case "PMFI":
                        filePlantilla = "PMFI_Reg_Usu.xlsx";
                        break;
                    case "DEVOLUCION_MADERA":
                        filePlantilla = "DEVOLUCIONMAD_Reg_Usu.xlsx";
                        break;
                    case "INFORME_AUT_FORESTAL":
                        filePlantilla = "INFAUTFORESTAL_Reg_Usu.xlsx";
                        break;
                    case "RENUNCIA_CONCESION":
                        filePlantilla = "RENUNCIACONCESION_Reg_Usu.xlsx";
                        break;
                    case "ALERTA_OSINFOR":
                        filePlantilla = "ALERTAOSINFOR_Reg_Usu.xlsx";
                        break;
                    case "BITACORA_SUPER":
                        filePlantilla = "BITACORASUPER_Reg_Usu.xlsx";
                        break;
                    case "CARTA_NOTIFICACION":
                        filePlantilla = "CNOTIFICACION_Reg_Usu.xlsx";
                        break;
                    case "INFORME_SUPERVISION":
                        filePlantilla = "ISUPERVISION_Reg_Usu.xlsx";
                        break;
                    case "INFORME_SUSPENSION":
                        filePlantilla = "ISUSPENSION_Reg_Usu.xlsx";
                        break;
                    case "OTROS_INFORMES":
                        filePlantilla = "OTROSINFORMES_Reg_Usu.xlsx";
                        break;
                    case "CRONOGRAMA_SUPERVISION":
                        filePlantilla = "CSUPERVISION_Reg_Usu.xlsx";
                        break;
                    case "INFORME_LEGAL":
                        filePlantilla = "ILEGAL_Reg_Usu.xlsx";
                        break;
                    case "RESOLUCION_DIRECTORAL":
                        filePlantilla = "RD_Reg_Usu.xlsx";
                        break;
                    case "INFORME_FUNDAMENTADO":
                        filePlantilla = "IFUNDAMENTADO_Reg_Usu.xlsx";
                        break;
                    case "INFORMACION_TITULAR":
                        filePlantilla = "INFTITULAR_Reg_Usu.xlsx";
                        break;
                    case "DOC_REM_OTRA_INST":
                        filePlantilla = "DOCREMOTRAINST_Reg_Usu.xlsx";
                        break;
                    case "SOL_INTERNA":
                        filePlantilla = "SOLINTERNA_Reg_Usu.xlsx";
                        break;
                    case "SOL_EXTERNA":
                        filePlantilla = "SOLEXTERNA_Reg_Usu.xlsx";
                        break;
                    case "CAPACITACION":
                    case "OTROS_EVENTOS":
                        filePlantilla = "CAPACITACION_Reg_Usu.xlsx";
                        break;
                    case "ACTIVIDAD":
                        filePlantilla = "plantillareporteactividades.xlsx";
                        break;
                    case "ACTIVIDADOCI":
                        filePlantilla = "plantillareporteactividades.xlsx";
                        break;
                    case "PROVEIDO_ARCHIVO_SUP":
                        filePlantilla = "PROVEIDOARCH_REG.xlsx";
                        break;
                }
                int contador = 0;
                String RutaReporteRegistro = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/Reg_Usu/");
                string nombreFile = "";
                nombreFile = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xlsx"; //DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                string rutaExcel = RutaReporteRegistro + nombreFile;

                //****************  

                int rowStart = 2;

                using (var package = new ExcelPackage(new FileInfo(RutaReporteRegistro + filePlantilla)))
                {
                    var workbook = package.Workbook;
                    ExcelWorksheet worksheet = workbook.Worksheets[1];

                    int column = 0;

                    switch (busFormulario)
                    {
                        #region GUIA_TRANSPORTE
                        case "GUIA_TRANSPORTE":
                            foreach (var listaInf in listaRegistros)
                            {
                                column = 0;

                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06.Trim();
                                //worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO07.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO08.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO09.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO14.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO15.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO16.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO17.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO18.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO19.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO20.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO21.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO22.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO23.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO24.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO25.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO26.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO27.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO28.Trim();

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO40.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO41.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO42.Trim();
                                //worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO43.Trim();
                                //worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO44.Trim();
                                //worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO45.Trim();
                                //worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO46.Trim();
                                //worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO47.Trim();
                                //worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO48.Trim();
                                //worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO49.Trim();
                                //worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO50.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO51.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO52.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO53.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO54.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO57.Trim();

                                rowStart++;
                            }

                            break;
                        #endregion

                        #region INFORME_TECNICO
                        case "INFORME_TECNICO":
                            foreach (var listaInf in listaRegistros)
                            {
                                column = 0;

                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO07.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO08.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }

                            break;
                        #endregion

                        #region FIS_NOTIFICACION
                        case "FIS_NOTIFICACION":
                            foreach (var listaInf in listaRegistros)
                            {
                                column = 0;

                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO07.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO08.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO09.Trim();
                                rowStart++;
                            }

                            break;
                        #endregion

                        #region PROVEIDO_ARCHIVO
                        case "PROVEIDO_ARCHIVO":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }
                                column = 0;

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO07.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO14.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region TFFS
                        case "TFFS":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }
                                column = 0;

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO08.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO09.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO07.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();

                                rowStart++;
                            }
                            break;
                        #endregion

                        #region TITULO_HABILITANTE
                        case "TITULO_HABILITANTE":
                            foreach (var listaInf in listaRegistros)
                            {
                                /*
                                PintarFila(ref worksheet, rowStart,
                                    new List<object> {
                                        ++contador,
                                        listaInf.PARAMETRO10.Trim(),
                                        listaInf.PARAMETRO11.Trim(),
                                        listaInf.PARAMETRO12.Trim(),
                                        listaInf.PARAMETRO01.Trim(),
                                        listaInf.NUMERO.Trim(),
                                        listaInf.PARAMETRO02.Trim(),
                                        listaInf.PARAMETRO03.Trim(),
                                        listaInf.PARAMETRO07.Trim(),
                                        listaInf.PARAMETRO08.Trim(),
                                        listaInf.PARAMETRO04.Trim(),
                                        listaInf.PARAMETRO05.Trim(),
                                        listaInf.PARAMETRO06.Trim(),
                                        listaInf.PARAMETRO13.Trim(),
                                        listaInf.PARAMETRO16.Trim(),
                                        listaInf.PARAMETRO14.Trim(),
                                        listaInf.PARAMETRO15.Trim(),
                                        listaInf.PARAMETRO17.Trim(),
                                        listaInf.PARAMETRO18.Trim(),
                                        listaInf.PARAMETRO19.Trim(),
                                    }
                                );

                                rowStart++;
                                */

                                column = 0;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = ++contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();

                                var param02 = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = (param02.Length > 255 ? param02.Substring(0, 255) : param02);
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO07.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO08.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO16.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO14.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO15.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO17.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO18.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO19.Trim();
                                rowStart++;
                            }

                            break;
                        #endregion

                        #region DEMA
                        case "DEMA":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }
                                column = 0;

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO09 is null ? string.Empty : listaInf.PARAMETRO09.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11 is null ? string.Empty : listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12 is null ? string.Empty : listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02 is null ? string.Empty : listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05 is null ? string.Empty : listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06 is null ? string.Empty : listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO07 is null ? string.Empty : listaInf.PARAMETRO07.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13 is null ? string.Empty : listaInf.PARAMETRO13.Trim();

                                rowStart++;
                            }
                            break;
                        #endregion

                        #region POA
                        case "POA":
                            foreach (var listaInf in listaRegistros)
                            {
                                column = 0;

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = ++contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO09 is null ? string.Empty : listaInf.PARAMETRO09.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01 is null ? string.Empty : listaInf.PARAMETRO01.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02 is null ? string.Empty : listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03 is null ? string.Empty : listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05 is null ? string.Empty : listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06 is null ? string.Empty : listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO07 is null ? string.Empty : listaInf.PARAMETRO07.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region PMFI
                        case "PMFI":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                column = 0;

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO09 is null ? string.Empty : listaInf.PARAMETRO09.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11 is null ? string.Empty : listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12 is null ? string.Empty : listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02 is null ? string.Empty : listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05 is null ? string.Empty : listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06 is null ? string.Empty : listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO07 is null ? string.Empty : listaInf.PARAMETRO07.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13 is null ? string.Empty : listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region DEVOLUCION_MADERA
                        case "DEVOLUCION_MADERA":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO07.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region INFORME_AUT_FORESTAL
                        case "INFORME_AUT_FORESTAL":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region RENUNCIA_CONCESION
                        case "RENUNCIA_CONCESION":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region ALERTA_OSINFOR
                        case "ALERTA_OSINFOR":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO14.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO15.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO07.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region BITACORA_SUPER
                        case "BITACORA_SUPER":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region CARTA_NOTIFICACION
                        case "CARTA_NOTIFICACION":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO14.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO15.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region INFORME_SUPERVISION
                        case "INFORME_SUPERVISION":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO14.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO15.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO09.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region INFORME_SUSPENSION
                        case "INFORME_SUSPENSION":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO07.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region OTROS_INFORMES
                        case "OTROS_INFORMES":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region CRONOGRAMA_SUPERVISION
                        case "CRONOGRAMA_SUPERVISION":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO07.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO08.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region INFORME_LEGAL
                        case "INFORME_LEGAL":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region RESOLUCION_DIRECTORAL
                        case "RESOLUCION_DIRECTORAL":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region INFORME_FUNDAMENTADO
                        case "INFORME_FUNDAMENTADO":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region INFORMACION_TITULAR
                        case "INFORMACION_TITULAR":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO07.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region DOC_REM_OTRA_INST
                        case "DOC_REM_OTRA_INST":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region SOL_INTERNA
                        case "SOL_INTERNA":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region SOL_EXTERNA
                        case "SOL_EXTERNA":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region PROVEIDO
                        case "PROVEIDO":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO07.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO09.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO08.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region CAPACITACION
                        case "CAPACITACION":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim().Length > 255 ? listaInf.NUMERO.Trim().Substring(0, 255) : listaInf.NUMERO.Trim();

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region OTROS_EVENTOS
                        case "OTROS_EVENTOS":
                            foreach (var listaInf in listaRegistros)
                            {
                                if (codigoTemp != listaInf.CODIGO)
                                {
                                    contador++;
                                    codigoTemp = listaInf.CODIGO;
                                }

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO10.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO11.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO12.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim().Length > 255 ? listaInf.NUMERO.Trim().Substring(0, 255) : listaInf.NUMERO.Trim();

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO13.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region ACTIVIDAD
                        case "ACTIVIDAD":
                            foreach (var listaInf in listaRegistros)
                            {
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO09.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO07.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO08.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region ACTIVIDADOCI
                        case "ACTIVIDADOCI":
                            foreach (var listaInf in listaRegistros)
                            {

                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO02.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO09.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO07.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05.Trim();
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO08.Trim();
                                rowStart++;
                            }
                            break;
                        #endregion

                        #region PROVEIDO_ARCHIVO_SUP
                        case "PROVEIDO_ARCHIVO_SUP":
                            foreach (var listaInf in listaRegistros)
                            {
                                column = 0;
                                contador++;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = contador;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO03 ?? string.Empty;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.CODIGO ?? string.Empty;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.NUMERO ?? string.Empty;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO01 ?? string.Empty;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO04 ?? string.Empty;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO05 ?? string.Empty;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO06 ?? string.Empty;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO07 ?? string.Empty;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO08 ?? string.Empty;
                                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PARAMETRO09 ?? string.Empty;
                                rowStart++;
                            }
                            break;
                            #endregion
                    }

                    package.SaveAs(new FileInfo(RutaReporteRegistro + nombreFile));
                }


                List<string> lstResult = new List<string> { nombreFile };
                result.AddResultado("Ok", true, lstResult);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        private static void PintarFila(ref ExcelWorksheet worksheet, int rowStart, List<object> listaInf)
        {
            int column = 0;

            foreach (var item in listaInf)
            {
                worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item;
            }

        }



        //se agrega para la descarga
        public static ListResult ExportUniversoPDC(List<Ent_ReportePDC> list)
        {
            ListResult result = new ListResult();
            try
            {
                int contador = 0;
                String RutaReporteRegistro = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                string nombreFile = "";
                nombreFile = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xlsx"; //DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                string rutaExcel = RutaReporteRegistro + nombreFile;

                string nombreExcelBase = "DescUniversoPDC.xlsx";
                int rowStart = 2;

                using (var package = new ExcelPackage(new FileInfo(RutaReporteRegistro + nombreExcelBase)))
                {
                    var workbook = package.Workbook;
                    ExcelWorksheet worksheet = workbook.Worksheets[1];

                    int column = 0;
                    foreach (var listaInf in list)
                    {

                        column = 0;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = ++contador;
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.OFICINA_DESCONCENTRADA.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.TITULO.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.MODALIDAD.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.TITULAR.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.REP_LEGAL.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.DEPARTAMENTO.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PROVINCIA.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.DISTRITO.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.FECHA_VIGENCIA.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.FECHA_CORTE.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.AREA.ToString().Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.ULTIMO_PLAN.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.ROJO.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.VERDE.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.ALERTA.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PASPEQ.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PASPEQ_ENFOQUE.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.FECHA_SUPERVISION.Trim();

                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.S_VOL_APROB.ToString().Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.S_VOL_MOV.ToString().Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.S_VOL_INJUST.ToString().Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.INFRACCIONES.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.MULTAS.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.ESTADO_PAU.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.ESTADO_PAGO.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.MODALIDAD_PAGO.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.MEC_COMP.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.N_CAPACITACION.ToString().Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.FECHA_ULT_CAP.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.TEMA_ULT_CAP.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.TEMA_MOCHILA_CAP.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.TEMA_MOCHILA_ENT.Trim();
                        worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = listaInf.PRIORIDAD.ToString().Trim();

                        rowStart++;
                    }
                    package.SaveAs(new FileInfo(RutaReporteRegistro + nombreFile));

                    result.success = true;
                    result.msj = nombreFile;

                   /*List<string> lstResult = new List<string> { nombreFile };
                    result.AddResultado("Ok", true, lstResult);*/
                }
            }
            catch (Exception ex)
            {
                //result.AddResultado(ex.Message, false);
                result.success = false;
                result.msj = ex.Message;
            }
            return result;



        }
    }
}