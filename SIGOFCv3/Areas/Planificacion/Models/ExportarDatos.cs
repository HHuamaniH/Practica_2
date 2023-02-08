using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SIGOFCv3.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SIGOFCv3.Areas.Planificacion.Models
{
    public class ExportarDatos
    {
        public static ListResult PlanUniverso(string asCodPlan)
        {
            ListResult result = new ListResult();

            try
            {
                Log_PLANIFICACION _logPlan = new Log_PLANIFICACION();
                List<Dictionary<string, string>> olResult = _logPlan.ListarPlanUniverso(asCodPlan);

                if (olResult.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                    string rutaExcelBase = rutaBase + "PlantillaUniveroTHyPM.xlsx";
                    FileInfo template = new FileInfo(rutaExcelBase);
                    int rowStart = 3;
                    int contador = 0;
                    using (var package = new ExcelPackage(template))
                    {
                        var workbook = package.Workbook;
                        ExcelWorksheet worksheet = workbook.Worksheets.First();

                        foreach (var item in olResult)
                        {
                            worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = ++contador;
                            worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item["CODIGO"];
                            worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item["NUM_THABILITANTE"];
                            worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item["TITULAR_ACTUAL"];
                            worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item["RLEGAL"];
                            worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item["MODALIDAD"];
                            worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item["DEPARTAMENTO"];
                            worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = item["PROVINCIA"];
                            worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = item["DISTRITO"];
                            worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = item["SECTOR"];
                            worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = item["OD_AMBITO"];
                            worksheet.Cells[HelperSigo.GetColum(12) + rowStart.ToString()].Value = item["AREA"];
                            worksheet.Cells[HelperSigo.GetColum(13) + rowStart.ToString()].Value = item["FECHA_INICIO"];
                            worksheet.Cells[HelperSigo.GetColum(14) + rowStart.ToString()].Value = item["ANIO_INICIO"];
                            worksheet.Cells[HelperSigo.GetColum(15) + rowStart.ToString()].Value = item["FECHA_FIN"];
                            worksheet.Cells[HelperSigo.GetColum(16) + rowStart.ToString()].Value = item["ANIO_FIN"];
                            worksheet.Cells[HelperSigo.GetColum(17) + rowStart.ToString()].Value = item["CADUCIDAD"];
                            worksheet.Cells[HelperSigo.GetColum(18) + rowStart.ToString()].Value = item["MEDIDA_CAUTELAR"];
                            worksheet.Cells[HelperSigo.GetColum(19) + rowStart.ToString()].Value = item["MEDIDA_PRECAUTORIA"];
                            worksheet.Cells[HelperSigo.GetColum(20) + rowStart.ToString()].Value = item["N_SUPERVISION"];
                            worksheet.Cells[HelperSigo.GetColum(21) + rowStart.ToString()].Value = item["N_SUPERVISION_INFRAC"];
                            worksheet.Cells[HelperSigo.GetColum(22) + rowStart.ToString()].Value = item["PORC_INFRACCION"];
                            worksheet.Cells[HelperSigo.GetColum(23) + rowStart.ToString()].Value = item["REQ_ENTIDAD"];
                            worksheet.Cells[HelperSigo.GetColum(24) + rowStart.ToString()].Value = item["DENUNCIA"];
                            worksheet.Cells[HelperSigo.GetColum(25) + rowStart.ToString()].Value = item["ESTADO_ESTABLECIMIENTO"];
                            worksheet.Cells[HelperSigo.GetColum(26) + rowStart.ToString()].Value = item["ANIO_ULTIMA_SUPERV"];
                            worksheet.Cells[HelperSigo.GetColum(27) + rowStart.ToString()].Value = item["INACTIVO"];
                            worksheet.Cells[HelperSigo.GetColum(28) + rowStart.ToString()].Value = item["N_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(29) + rowStart.ToString()].Value = item["ESTADO_CALIDAD"];
                            worksheet.Cells[HelperSigo.GetColum(30) + rowStart.ToString()].Value = item["FECHA_REGISTRO"];
                            worksheet.Cells[HelperSigo.GetColum(31) + rowStart.ToString()].Value = item["ANIO_REGISTRO"];

                            worksheet.Cells[HelperSigo.GetColum(32) + rowStart.ToString()].Value = item["TIPO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(33) + rowStart.ToString()].Value = item["NOMBRE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(34) + rowStart.ToString()].Value = item["RESOLUCION_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(35) + rowStart.ToString()].Value = item["CONSULTOR_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(36) + rowStart.ToString()].Value = item["FEC_APRUEBA_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(37) + rowStart.ToString()].Value = item["ANIO_APRUEBA_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(38) + rowStart.ToString()].Value = item["FEC_INICIO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(39) + rowStart.ToString()].Value = item["ANIO_INICIO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(40) + rowStart.ToString()].Value = item["FEC_FIN_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(41) + rowStart.ToString()].Value = item["ANIO_FIN_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(42) + rowStart.ToString()].Value = item["AREA_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(43) + rowStart.ToString()].Value = item["ZONA_UTM_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(44) + rowStart.ToString()].Value = item["CESTE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(45) + rowStart.ToString()].Value = item["CNORTE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(46) + rowStart.ToString()].Value = item["N_CENSO_MADE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(47) + rowStart.ToString()].Value = item["N_CENSO_NOMADE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(48) + rowStart.ToString()].Value = item["N_ESPECIE_APROBADO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(49) + rowStart.ToString()].Value = item["N_ESPECIE_BEXTRACCION_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(50) + rowStart.ToString()].Value = item["VOL_APROBADO_PMANEJO"];

                            worksheet.Cells[HelperSigo.GetColum(51) + rowStart.ToString()].Value = item["VOL_MOVILIZADO"];
                            worksheet.Cells[HelperSigo.GetColum(52) + rowStart.ToString()].Value = item["VOL_INJUSTIFICADO"];
                            worksheet.Cells[HelperSigo.GetColum(53) + rowStart.ToString()].Value = item["VERDE"];
                            worksheet.Cells[HelperSigo.GetColum(54) + rowStart.ToString()].Value = item["ROJO"];

                            worksheet.Cells[HelperSigo.GetColum(55) + rowStart.ToString()].Value = item["N_SUPERVISION_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(56) + rowStart.ToString()].Value = item["ACTO_SUPERVISADO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(57) + rowStart.ToString()].Value = item["SUPERVISADO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(58) + rowStart.ToString()].Value = item["SUPERVISADO_ANTES_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(59) + rowStart.ToString()].Value = item["SUPERVISADO_DURANTE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(60) + rowStart.ToString()].Value = item["SUPERVISADO_DESPUES_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(61) + rowStart.ToString()].Value = item["AMENAZA_CITE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(62) + rowStart.ToString()].Value = item["AMENAZA_DS_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(63) + rowStart.ToString()].Value = item["ESPECIE_AMENAZADA_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(64) + rowStart.ToString()].Value = item["N_ACERVODOC_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(65) + rowStart.ToString()].Value = item["PROGRAMADO"];
                            worksheet.Cells[HelperSigo.GetColum(66) + rowStart.ToString()].Value = item["ESTADO_CALIDAD_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(67) + rowStart.ToString()].Value = item["FECREG_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(68) + rowStart.ToString()].Value = item["ANIOREG_PMANEJO"];
                            rowStart = rowStart + 1;
                        }

                        string modelRange = "A3:BL" + (rowStart - 1).ToString();
                        var modelTable = worksheet.Cells[modelRange];
                        modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                        using (var memoryStream = new MemoryStream())
                        {
                            package.SaveAs(memoryStream);

                            result.success = true;
                            result.byteFile = memoryStream.ToArray();
                        }
                    }
                }
                else { throw new Exception("No se encontraron registros"); }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }

        public static ListResult PlanCasuisticaUniverso(string asCodPlan, string asCodPCasuistica)
        {
            ListResult result = new ListResult();

            try
            {
                Log_PLANIFICACION _logPlan = new Log_PLANIFICACION();
                List<Dictionary<string, string>> olResult = _logPlan.ListarPlanCasuisticaUniverso(asCodPlan, asCodPCasuistica);

                if (olResult.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                    string rutaExcelBase = rutaBase;
                    int n_criterio = 0;
                    int col = 0;

                    for (int j = 1; j <= 5; j++)
                    {
                        if (olResult[0]["CRITERIO_" + j.ToString()] != "")
                        {
                            n_criterio++;
                        }
                    }

                    switch (n_criterio)
                    {
                        case 0: rutaExcelBase += "PlantillaUniveroTHyPM_Criterio_0.xlsx"; break;
                        case 1: rutaExcelBase += "PlantillaUniveroTHyPM_Criterio_1.xlsx"; break;
                        case 2: rutaExcelBase += "PlantillaUniveroTHyPM_Criterio_2.xlsx"; break;
                        case 3: rutaExcelBase += "PlantillaUniveroTHyPM_Criterio_3.xlsx"; break;
                        case 4: rutaExcelBase += "PlantillaUniveroTHyPM_Criterio_4.xlsx"; break;
                        case 5: rutaExcelBase += "PlantillaUniveroTHyPM_Criterio_5.xlsx"; break;
                    }

                    FileInfo template = new FileInfo(rutaExcelBase);
                    int rowStart = 3;
                    int contador = 0;
                    using (var package = new ExcelPackage(template))
                    {
                        var workbook = package.Workbook;
                        ExcelWorksheet worksheet = workbook.Worksheets.First();

                        foreach (var item in olResult)
                        {
                            worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = ++contador;
                            worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item["CODIGO"];
                            worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item["NUM_THABILITANTE"];
                            worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = item["TITULAR_ACTUAL"];
                            worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item["RLEGAL"];
                            worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item["MODALIDAD"];
                            worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item["DEPARTAMENTO"];
                            worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = item["PROVINCIA"];
                            worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = item["DISTRITO"];
                            worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = item["SECTOR"];
                            worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = item["OD_AMBITO"];
                            worksheet.Cells[HelperSigo.GetColum(12) + rowStart.ToString()].Value = item["AREA"];
                            worksheet.Cells[HelperSigo.GetColum(13) + rowStart.ToString()].Value = item["FECHA_INICIO"];
                            worksheet.Cells[HelperSigo.GetColum(14) + rowStart.ToString()].Value = item["ANIO_INICIO"];
                            worksheet.Cells[HelperSigo.GetColum(15) + rowStart.ToString()].Value = item["FECHA_FIN"];
                            worksheet.Cells[HelperSigo.GetColum(16) + rowStart.ToString()].Value = item["ANIO_FIN"];
                            worksheet.Cells[HelperSigo.GetColum(17) + rowStart.ToString()].Value = item["CADUCIDAD"];
                            worksheet.Cells[HelperSigo.GetColum(18) + rowStart.ToString()].Value = item["MEDIDA_CAUTELAR"];
                            worksheet.Cells[HelperSigo.GetColum(19) + rowStart.ToString()].Value = item["MEDIDA_PRECAUTORIA"];
                            worksheet.Cells[HelperSigo.GetColum(20) + rowStart.ToString()].Value = item["N_SUPERVISION"];
                            worksheet.Cells[HelperSigo.GetColum(21) + rowStart.ToString()].Value = item["N_SUPERVISION_INFRAC"];
                            worksheet.Cells[HelperSigo.GetColum(22) + rowStart.ToString()].Value = item["PORC_INFRACCION"];
                            worksheet.Cells[HelperSigo.GetColum(23) + rowStart.ToString()].Value = item["REQ_ENTIDAD"];
                            worksheet.Cells[HelperSigo.GetColum(24) + rowStart.ToString()].Value = item["DENUNCIA"];
                            worksheet.Cells[HelperSigo.GetColum(25) + rowStart.ToString()].Value = item["ESTADO_ESTABLECIMIENTO"];
                            worksheet.Cells[HelperSigo.GetColum(26) + rowStart.ToString()].Value = item["ANIO_ULTIMA_SUPERV"];
                            worksheet.Cells[HelperSigo.GetColum(27) + rowStart.ToString()].Value = item["INACTIVO"];
                            worksheet.Cells[HelperSigo.GetColum(28) + rowStart.ToString()].Value = item["N_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(29) + rowStart.ToString()].Value = item["ESTADO_CALIDAD"];
                            worksheet.Cells[HelperSigo.GetColum(30) + rowStart.ToString()].Value = item["FECHA_REGISTRO"];
                            worksheet.Cells[HelperSigo.GetColum(31) + rowStart.ToString()].Value = item["ANIO_REGISTRO"];

                            worksheet.Cells[HelperSigo.GetColum(32) + rowStart.ToString()].Value = item["TIPO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(33) + rowStart.ToString()].Value = item["NOMBRE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(34) + rowStart.ToString()].Value = item["RESOLUCION_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(35) + rowStart.ToString()].Value = item["CONSULTOR_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(36) + rowStart.ToString()].Value = item["FEC_APRUEBA_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(37) + rowStart.ToString()].Value = item["ANIO_APRUEBA_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(38) + rowStart.ToString()].Value = item["FEC_INICIO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(39) + rowStart.ToString()].Value = item["ANIO_INICIO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(40) + rowStart.ToString()].Value = item["FEC_FIN_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(41) + rowStart.ToString()].Value = item["ANIO_FIN_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(42) + rowStart.ToString()].Value = item["AREA_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(43) + rowStart.ToString()].Value = item["ZONA_UTM_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(44) + rowStart.ToString()].Value = item["CESTE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(45) + rowStart.ToString()].Value = item["CNORTE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(46) + rowStart.ToString()].Value = item["N_CENSO_MADE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(47) + rowStart.ToString()].Value = item["N_CENSO_NOMADE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(48) + rowStart.ToString()].Value = item["N_ESPECIE_APROBADO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(49) + rowStart.ToString()].Value = item["N_ESPECIE_BEXTRACCION_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(50) + rowStart.ToString()].Value = item["VOL_APROBADO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(51) + rowStart.ToString()].Value = item["N_SUPERVISION_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(52) + rowStart.ToString()].Value = item["ACTO_SUPERVISADO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(53) + rowStart.ToString()].Value = item["SUPERVISADO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(54) + rowStart.ToString()].Value = item["SUPERVISADO_ANTES_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(55) + rowStart.ToString()].Value = item["SUPERVISADO_DURANTE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(56) + rowStart.ToString()].Value = item["SUPERVISADO_DESPUES_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(57) + rowStart.ToString()].Value = item["AMENAZA_CITE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(58) + rowStart.ToString()].Value = item["AMENAZA_DS_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(59) + rowStart.ToString()].Value = item["ESPECIE_AMENAZADA_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(60) + rowStart.ToString()].Value = item["N_ACERVODOC_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(61) + rowStart.ToString()].Value = item["PROGRAMADO"];
                            worksheet.Cells[HelperSigo.GetColum(62) + rowStart.ToString()].Value = item["ESTADO_CALIDAD_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(63) + rowStart.ToString()].Value = item["FECREG_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(64) + rowStart.ToString()].Value = item["ANIOREG_PMANEJO"];

                            col = 65;
                            for (int j = 1; j <= 5; j++)
                            {
                                if (item["CRITERIO_" + j.ToString()] != "")
                                {
                                    worksheet.Cells[HelperSigo.GetColum(col++) + rowStart.ToString()].Value = item["CRITERIO_" + j.ToString()];
                                    worksheet.Cells[HelperSigo.GetColum(col++) + rowStart.ToString()].Value = item["VALOR_" + j.ToString()];
                                    worksheet.Cells[HelperSigo.GetColum(col++) + rowStart.ToString()].Value = item["RIESGO_" + j.ToString()];
                                    worksheet.Cells[HelperSigo.GetColum(col++) + rowStart.ToString()].Value = item["RESULTADO_" + j.ToString()];
                                }
                            }
                            worksheet.Cells[HelperSigo.GetColum(col) + rowStart.ToString()].Value = item["RESULTADO_TOTAL"];

                            rowStart = rowStart + 1;
                        }

                        string modelRange = "A3:" + (HelperSigo.GetColum(col)) + (rowStart - 1).ToString();
                        var modelTable = worksheet.Cells[modelRange];
                        modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                        using (var memoryStream = new MemoryStream())
                        {
                            package.SaveAs(memoryStream);

                            result.success = true;
                            result.byteFile = memoryStream.ToArray();
                        }
                    }
                }
                else { throw new Exception("No se encontraron registros"); }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }

        public static ListResult ConsolidadoPlanCasuisticaUniverso(string asCodPlan)
        {
            ListResult result = new ListResult();

            try
            {
                Log_PLANIFICACION _logPlan = new Log_PLANIFICACION();
                List<Dictionary<string, string>> olResult = _logPlan.ConsolidadoPlanCasuisticaUniverso(asCodPlan);

                if (olResult.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                    string rutaExcelBase = rutaBase + "PlantillaUniveroTHyPM_Consolidado.xlsx";
                    FileInfo template = new FileInfo(rutaExcelBase);
                    int rowStart = 3;
                    int contador = 0;
                    using (var package = new ExcelPackage(template))
                    {
                        var workbook = package.Workbook;
                        ExcelWorksheet worksheet = workbook.Worksheets.First();

                        foreach (var item in olResult)
                        {
                            worksheet.Cells[HelperSigo.GetColum(1) + rowStart.ToString()].Value = ++contador;
                            worksheet.Cells[HelperSigo.GetColum(2) + rowStart.ToString()].Value = item["CODIGO"];
                            worksheet.Cells[HelperSigo.GetColum(3) + rowStart.ToString()].Value = item["PCASUISTICA"];
                            worksheet.Cells[HelperSigo.GetColum(4) + rowStart.ToString()].Value = Int32.Parse(item["PRIORIZAR"])==1 ? "SI" : "NO";
                            worksheet.Cells[HelperSigo.GetColum(5) + rowStart.ToString()].Value = item["NUM_THABILITANTE"];
                            worksheet.Cells[HelperSigo.GetColum(6) + rowStart.ToString()].Value = item["TITULAR_ACTUAL"];
                            worksheet.Cells[HelperSigo.GetColum(7) + rowStart.ToString()].Value = item["RLEGAL"];
                            worksheet.Cells[HelperSigo.GetColum(8) + rowStart.ToString()].Value = item["MODALIDAD"];
                            worksheet.Cells[HelperSigo.GetColum(9) + rowStart.ToString()].Value = item["DEPARTAMENTO"];
                            worksheet.Cells[HelperSigo.GetColum(10) + rowStart.ToString()].Value = item["PROVINCIA"];
                            worksheet.Cells[HelperSigo.GetColum(11) + rowStart.ToString()].Value = item["DISTRITO"];
                            worksheet.Cells[HelperSigo.GetColum(12) + rowStart.ToString()].Value = item["SECTOR"];
                            worksheet.Cells[HelperSigo.GetColum(13) + rowStart.ToString()].Value = item["OD_AMBITO"];
                            worksheet.Cells[HelperSigo.GetColum(14) + rowStart.ToString()].Value = item["AREA"];
                            worksheet.Cells[HelperSigo.GetColum(15) + rowStart.ToString()].Value = item["FECHA_INICIO"];
                            worksheet.Cells[HelperSigo.GetColum(16) + rowStart.ToString()].Value = item["ANIO_INICIO"];
                            worksheet.Cells[HelperSigo.GetColum(17) + rowStart.ToString()].Value = item["FECHA_FIN"];
                            worksheet.Cells[HelperSigo.GetColum(18) + rowStart.ToString()].Value = item["ANIO_FIN"];
                            worksheet.Cells[HelperSigo.GetColum(19) + rowStart.ToString()].Value = item["CADUCIDAD"];
                            worksheet.Cells[HelperSigo.GetColum(20) + rowStart.ToString()].Value = item["MEDIDA_CAUTELAR"];
                            worksheet.Cells[HelperSigo.GetColum(21) + rowStart.ToString()].Value = item["MEDIDA_PRECAUTORIA"];
                            worksheet.Cells[HelperSigo.GetColum(22) + rowStart.ToString()].Value = item["N_SUPERVISION"];
                            worksheet.Cells[HelperSigo.GetColum(23) + rowStart.ToString()].Value = item["N_SUPERVISION_INFRAC"];
                            worksheet.Cells[HelperSigo.GetColum(24) + rowStart.ToString()].Value = item["PORC_INFRACCION"];
                            worksheet.Cells[HelperSigo.GetColum(25) + rowStart.ToString()].Value = item["REQ_ENTIDAD"];
                            worksheet.Cells[HelperSigo.GetColum(26) + rowStart.ToString()].Value = item["DENUNCIA"];
                            worksheet.Cells[HelperSigo.GetColum(27) + rowStart.ToString()].Value = item["ESTADO_ESTABLECIMIENTO"];
                            worksheet.Cells[HelperSigo.GetColum(28) + rowStart.ToString()].Value = item["ANIO_ULTIMA_SUPERV"];
                            worksheet.Cells[HelperSigo.GetColum(29) + rowStart.ToString()].Value = item["INACTIVO"];
                            worksheet.Cells[HelperSigo.GetColum(30) + rowStart.ToString()].Value = item["N_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(31) + rowStart.ToString()].Value = item["ESTADO_CALIDAD"];
                            worksheet.Cells[HelperSigo.GetColum(32) + rowStart.ToString()].Value = item["FECHA_REGISTRO"];
                            worksheet.Cells[HelperSigo.GetColum(33) + rowStart.ToString()].Value = item["ANIO_REGISTRO"];

                            worksheet.Cells[HelperSigo.GetColum(34) + rowStart.ToString()].Value = item["TIPO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(35) + rowStart.ToString()].Value = item["NOMBRE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(36) + rowStart.ToString()].Value = item["RESOLUCION_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(37) + rowStart.ToString()].Value = item["CONSULTOR_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(38) + rowStart.ToString()].Value = item["FEC_APRUEBA_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(39) + rowStart.ToString()].Value = item["ANIO_APRUEBA_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(40) + rowStart.ToString()].Value = item["FEC_INICIO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(41) + rowStart.ToString()].Value = item["ANIO_INICIO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(42) + rowStart.ToString()].Value = item["FEC_FIN_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(43) + rowStart.ToString()].Value = item["ANIO_FIN_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(44) + rowStart.ToString()].Value = item["AREA_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(45) + rowStart.ToString()].Value = item["ZONA_UTM_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(46) + rowStart.ToString()].Value = item["CESTE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(47) + rowStart.ToString()].Value = item["CNORTE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(48) + rowStart.ToString()].Value = item["N_CENSO_MADE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(49) + rowStart.ToString()].Value = item["N_CENSO_NOMADE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(50) + rowStart.ToString()].Value = item["N_ESPECIE_APROBADO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(51) + rowStart.ToString()].Value = item["N_ESPECIE_BEXTRACCION_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(52) + rowStart.ToString()].Value = item["VOL_APROBADO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(53) + rowStart.ToString()].Value = item["N_SUPERVISION_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(54) + rowStart.ToString()].Value = item["ACTO_SUPERVISADO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(55) + rowStart.ToString()].Value = item["SUPERVISADO_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(56) + rowStart.ToString()].Value = item["SUPERVISADO_ANTES_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(57) + rowStart.ToString()].Value = item["SUPERVISADO_DURANTE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(58) + rowStart.ToString()].Value = item["SUPERVISADO_DESPUES_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(59) + rowStart.ToString()].Value = item["AMENAZA_CITE_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(60) + rowStart.ToString()].Value = item["AMENAZA_DS_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(61) + rowStart.ToString()].Value = item["ESPECIE_AMENAZADA_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(62) + rowStart.ToString()].Value = item["N_ACERVODOC_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(63) + rowStart.ToString()].Value = item["PROGRAMADO"];
                            worksheet.Cells[HelperSigo.GetColum(64) + rowStart.ToString()].Value = item["ESTADO_CALIDAD_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(65) + rowStart.ToString()].Value = item["FECREG_PMANEJO"];
                            worksheet.Cells[HelperSigo.GetColum(66) + rowStart.ToString()].Value = item["ANIOREG_PMANEJO"];
                            rowStart = rowStart + 1;
                        }

                        string modelRange = "A3:BN" + (rowStart - 1).ToString();
                        var modelTable = worksheet.Cells[modelRange];
                        modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                        using (var memoryStream = new MemoryStream())
                        {
                            package.SaveAs(memoryStream);

                            result.success = true;
                            result.byteFile = memoryStream.ToArray();
                        }
                    }
                }
                else { throw new Exception("No se encontraron registros"); }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }
    }
}