using CapaEntidad.ViewModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SIGOFCv3.Areas.THabilitante.Models.ManCertificadoPlanta
{
    public class ImportarDatos
    {
        public static List<CapaEntidad.DOC.Ent_EspeciesEstablecidas> EspeciesEstablecidas(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_EspeciesEstablecidas> lstVertice = new List<CapaEntidad.DOC.Ent_EspeciesEstablecidas>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_EspeciesEstablecidas oCampos;
                    string especie1, especie2;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CapaEntidad.DOC.Ent_EspeciesEstablecidas();
                        especie1 = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString();
                        especie2 = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString();
                        if (string.IsNullOrEmpty(especie1) || string.IsNullOrEmpty(especie2)) throw new Exception("Descripción de Especie Incompleta: " + especie1 + " | " + especie2);
                        else
                        {
                            oCampos.DESC_ESPECIES = especie1 + " | " + especie2;
                            oCampos.SIS_PLANTA = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString();
                            if (string.IsNullOrEmpty(oCampos.SIS_PLANTA)) throw new Exception("Sistema de Plantación vacía o nula");
                            else if (oCampos.SIS_PLANTA.Length > 100) throw new Exception("Sistema de Plantación no debe exceder los 100 caracteres");
                            else if (!Regex.IsMatch(oCampos.SIS_PLANTA, @"^[ ÁÉÍÓÚA-Záéíóúa-z0-9\-\/]+$")) throw new Exception("Sistema de Plantación no puede tener caracteres especiales");
                            else
                            {
                                oCampos.UNI_MEDIDA = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString();
                                if (string.IsNullOrEmpty(oCampos.UNI_MEDIDA)) throw new Exception("Unidad de Medida vacía o nula");
                                else
                                {
                                    string cantidad;
                                    cantidad = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString();
                                    if (string.IsNullOrEmpty(cantidad)) throw new Exception("Cantidad vacía o nula");
                                    else if (!Regex.IsMatch(cantidad, @"^\d+(?:\.\d{1,2})?$")) throw new Exception("Cantidad ingresada no válida, sólo permite hasta 2 decimales");
                                    else if (Decimal.Parse(cantidad) > 99999) throw new Exception("Cantidad ingresada debe ser menor a los 6 digitos");
                                    {
                                        oCampos.CANTIDAD = decimal.Parse(cantidad);
                                        oCampos.FINES = (workSheet.Cells[rowIterator, 6].Value ?? "").ToString();
                                        if (!Regex.IsMatch(oCampos.FINES, @"^[ ÁÉÍÓÚA-Záéíóúa-z0-9\-\/]+$") && !string.IsNullOrEmpty(oCampos.FINES)) throw new Exception("Fines no puede tener caracteres especiales");
                                        else if (oCampos.FINES.Length > 100) throw new Exception("Fines no debe exceder los 100 caracteres");
                                        {
                                            oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 7].Value ?? "").ToString();
                                            if (!Regex.IsMatch(oCampos.OBSERVACION, @"^[ ÁÉÍÓÚA-Záéíóúa-z0-9\-\/]+$") && !string.IsNullOrEmpty(oCampos.OBSERVACION)) throw new Exception("Observación no puede tener caracteres especiales");
                                            else if (oCampos.FINES.Length > 200) throw new Exception("Observación no debe exceder los 200 caracteres");
                                            {
                                                oCampos.RegEstado = 1;
                                                lstVertice.Add(oCampos);
                                            }
                                        }
                                    }
                                }
                            }
                        }                        
                    }
                }
            }
            return lstVertice;
        }
    }
}