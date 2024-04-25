using CapaLogica.DOC;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CEntidad = CapaEntidad.DOC.Ent_PLAN_MANEJO;


namespace SIGOFCv3.Areas.THabilitante.Models.ManPlanManejoForestal
{
    public class ImportarDatos
    {
        public static List<CEntidad> Especies_Aprobadas(HttpRequestBase _request, string esPMFI, int numBloque)
        {
            List<CEntidad> olResult = new List<CEntidad>();
            string msjError = "";

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CEntidad oCampos;
                    Log_PLAN_MANEJO objLog;
                    string codEspecie;
                    bool isAdd;
                    int itemBloque;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CEntidad();
                        objLog = new Log_PLAN_MANEJO();
                        isAdd = true;

                        codEspecie = objLog.GetCodEspecie((workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim(), (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim());

                        if (codEspecie != null && codEspecie.Trim() != "")
                        {
                            oCampos.COD_ESPECIES = codEspecie;
                            oCampos.DESCRIPCION = String.Format("{0} | {1}", (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim(), (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim());

                            if (esPMFI.Equals("0"))
                            {
                                oCampos.DESC_BLOQUE = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim();

                                if (oCampos.DESC_BLOQUE != "Bloque N° 1" && oCampos.DESC_BLOQUE != "Bloque N° 2" && oCampos.DESC_BLOQUE != "Bloque N° 3" && oCampos.DESC_BLOQUE != "Bloque N° 4" &&
                                    oCampos.DESC_BLOQUE != "Bloque N° 5" && oCampos.DESC_BLOQUE != "Bloque N° 6" && oCampos.DESC_BLOQUE != "Bloque N° 7" && oCampos.DESC_BLOQUE != "Bloque N° 8")
                                {
                                    msjError = "Bloque incorrecto";
                                    isAdd = false;
                                }
                                else
                                {
                                    itemBloque = Int32.Parse(oCampos.DESC_BLOQUE.Substring(10, oCampos.DESC_BLOQUE.Length - 10));

                                    if (itemBloque <= numBloque) oCampos.NUM_BLOQUES = itemBloque;
                                    else
                                    {
                                        msjError = "Bloque incorrecto";
                                        isAdd = false;
                                    }
                                }
                            }

                            oCampos.NUM_ARBOLES = Int32.Parse((workSheet.Cells[rowIterator, 4].Value ?? "0").ToString().Trim());
                            oCampos.VOLUMEN = Decimal.Parse((workSheet.Cells[rowIterator, 5].Value ?? "0").ToString().Trim());
                            oCampos.COD_SECUENCIAL = 0;
                            oCampos.RegEstado = 1;
                            oCampos.TIPOMADERABLE = (workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim();
                            oCampos.UNIDAD_MEDIDA = (workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim();

                            if (isAdd) olResult.Add(oCampos);
                            //else throw new Exception(msjError);
                        }
                        /*else
                        {
                            msjError = "Especie no encontrada";
                            throw new Exception(msjError);
                        }*/
                    }
                }
            }

            return olResult;
        }

        public static List<CEntidad> Coordenada(HttpRequestBase _request)
        {
            List<CEntidad> olResult = new List<CEntidad>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CEntidad oCampos;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CEntidad();
                        oCampos.COD_SECUENCIAL = 0;
                        oCampos.VERTICE = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                        oCampos.COORDENADA_ESTE = Int32.Parse((workSheet.Cells[rowIterator, 2].Value ?? "0").ToString().Trim());
                        oCampos.COORDENADA_NORTE = Int32.Parse((workSheet.Cells[rowIterator, 3].Value ?? "0").ToString().Trim());
                        oCampos.OBSERVACIONES = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                        oCampos.RegEstado = 1;

                        olResult.Add(oCampos);
                    }
                }
            }

            return olResult;
        }

        public static List<CEntidad> EspecieFS(HttpRequestBase _request)
        {
            List<CEntidad> olResult = new List<CEntidad>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CEntidad oCampos;
                    Log_PLAN_MANEJO objLog;
                    string codEspecie;
                    string codAmenaza;
                    bool isAdd;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CEntidad();
                        objLog = new Log_PLAN_MANEJO();
                        isAdd = true;

                        codEspecie = objLog.GetCodEspecie((workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim(), (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim());

                        if (codEspecie != null && codEspecie.Trim() != "")
                        {
                            oCampos.COD_ESPECIES = codEspecie;
                            oCampos.DESCRIPCION = String.Format("{0} | {1}", (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim(), (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim());

                            codAmenaza = objLog.GetCodAmenaza((workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim(), (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim());

                            if (codAmenaza != null && codAmenaza != "")
                            {
                                oCampos.COD_AMENAZA = codAmenaza;
                                oCampos.DESC_AMENAZA = String.Format("{0} | {1}", (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim(), (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim());
                            }
                            else isAdd = false;

                            oCampos.OBSERVACIONES = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                            oCampos.COD_SECUENCIAL = 0;
                            oCampos.RegEstado = 1;

                            if (isAdd) olResult.Add(oCampos);
                        }
                    }
                }
            }

            return olResult;
        }
    }
}