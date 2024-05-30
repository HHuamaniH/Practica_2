using CapaEntidad.ViewModel;
using OfficeOpenXml;
using SIGOFCv3.Helper;
using SIGOFCv3.Models.DataTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using CEntidad = CapaEntidad.DOC.Ent_ANTECEDENTE_EXPEDIENTE;
using CLogica = CapaLogica.DOC.Log_ANTECEDENTE_EXPEDIENTE;

namespace SIGOFCv3.Areas.THabilitante.Models.ManVentanillaAntecedentesExpedientes
{
    public class ExportarDatos
    {
        public static ListResult RegistroUsuario(CEntidad request)
        {
            ListResult result = new ListResult();

            try
            {
                
                CLogica exeCap = new CLogica();

                List<Dictionary<string, string>> olResult = exeCap.ReporteExcel(request);

                if (olResult.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "PlantillaAntecedentes.xlsx";

                    int rowStart = 2;
                    using (var package = new ExcelPackage(new FileInfo(rutaExcelBase)))
                    {
                        var workbook = package.Workbook;
                        ExcelWorksheet worksheet = workbook.Worksheets.First();

                        int column = 0;

                        foreach (var item in olResult)
                        {
                            column = 0;
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = (rowStart - 1).ToString();
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = (item["DOC_REFERENCIA"].Trim() ?? "");
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = (item["OBSERVACION"].Trim() ?? "");
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = (item["RESOLUCION_POA"].Trim() ?? "");
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = (item["FFECDOCUMENTO"].Trim() ?? "");
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = (item["NUM_THABILITANTE"].Trim() ?? "");
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = (item["DESCRIPCION"].Trim() ?? "");
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = (item["CCODIFICACION"].Trim() ?? "");
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = (item["FECHA_SITD"].Trim() ?? "");
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = (item["CNOMOFICINA"].Trim() ?? "");
                            worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = (item["ESTADO_AEXPEDIENTE"].Trim() ?? "");                            
                            rowStart++;
                        }

                        package.SaveAs(new FileInfo(rutaExcel));
                    }

                    result.success = true;
                    result.msj = nombreFile;
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