using CapaEntidad.DOC;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIGOFCv3.Areas.Supervision.Models.ManInformeMedidaCorrectiva
{
    public class ImportarDatos
    {
        public static List<Ent_IMEDIDA_ESPECIE> Especies_Reforestadas(HttpRequestBase _request)
        {
            List<Ent_IMEDIDA_ESPECIE> olResult = new List<Ent_IMEDIDA_ESPECIE>();
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
                    Ent_IMEDIDA_ESPECIE oCampos;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new Ent_IMEDIDA_ESPECIE();
                        oCampos.COD_SECUENCIAL = 0;
                        oCampos.DESCRIPCION_ESPECIE = String.Format("{0} | {1}", (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim(), (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim());
                        oCampos.DIAMETRO = Decimal.Parse((workSheet.Cells[rowIterator, 3].Value ?? "0").ToString().Trim());
                        oCampos.ALTURA = Decimal.Parse((workSheet.Cells[rowIterator, 4].Value ?? "0").ToString().Trim());
                        oCampos.ZONA = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();

                        if (oCampos.ZONA != "17S" && oCampos.ZONA != "18S" && oCampos.ZONA != "19S")
                        {
                            msjError = "Zona UTM incorrecta";
                            throw new Exception(msjError);
                        }

                        oCampos.COORDENADA_ESTE = Int32.Parse((workSheet.Cells[rowIterator, 6].Value ?? "0").ToString().Trim());
                        oCampos.COORDENADA_NORTE = Int32.Parse((workSheet.Cells[rowIterator, 7].Value ?? "0").ToString().Trim());
                        oCampos.ESTADO_ESPECIE = (workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim();

                        if (oCampos.ESTADO_ESPECIE != "BUENO" && oCampos.ESTADO_ESPECIE != "REGULAR" & oCampos.ESTADO_ESPECIE != "MALO")
                        {
                            msjError = "Estado especie incorrecta";
                            throw new Exception(msjError);
                        }

                        oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 9].Value ?? "").ToString().Trim();
                        oCampos.RegEstado = 1;

                        olResult.Add(oCampos);
                    }
                }
            }

            return olResult;
        }

        public static List<Ent_IMEDIDA_VERTICE> Vertices_Reforestadas(HttpRequestBase _request)
        {
            List<Ent_IMEDIDA_VERTICE> olResult = new List<Ent_IMEDIDA_VERTICE>();
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
                    Ent_IMEDIDA_VERTICE oCampos;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new Ent_IMEDIDA_VERTICE();
                        oCampos.COD_SECUENCIAL = 0;
                        oCampos.VERTICE = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                        oCampos.ZONA = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim();

                        if (oCampos.ZONA != "17S" && oCampos.ZONA != "18S" && oCampos.ZONA != "19S")
                        {
                            msjError = "Zona UTM incorrecta";
                            throw new Exception(msjError);
                        }

                        oCampos.COORDENADA_ESTE = Int32.Parse((workSheet.Cells[rowIterator, 3].Value ?? "0").ToString().Trim());
                        oCampos.COORDENADA_NORTE = Int32.Parse((workSheet.Cells[rowIterator, 4].Value ?? "0").ToString().Trim());
                        oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim().ToUpper();
                        oCampos.RegEstado = 1;

                        olResult.Add(oCampos);
                    }
                }
            }

            return olResult;
        }
    }
}