using CapaEntidad.DOC;
using CapaLogica.DOC;
using OfficeOpenXml;
using SIGOFCv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIGOFCv3.Areas.Planificacion.Models
{
    public class ImportarDatos
    {
        public static List<Ent_PLAN_CASUISTICA_UNIVERSO> PlanCasuisticaUniverso(HttpRequestBase _request, string asCodPlan, string asCodPCasuistica)
        {
            List<Ent_PLAN_CASUISTICA_UNIVERSO> lstUniverso = new List<Ent_PLAN_CASUISTICA_UNIVERSO>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.Where(x => x.Name == "Casuistica").First(); //currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    Ent_PLAN_CASUISTICA_UNIVERSO oCampos;

                    for (int rowIterator = 3; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new Ent_PLAN_CASUISTICA_UNIVERSO();
                        oCampos.COD_PCASUISTICA = asCodPCasuistica;
                        oCampos.COD_UCUENTA = (ModelSession.GetSession())[0].COD_UCUENTA;

                        var codigo = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim();
                        if (codigo == "") throw new Exception("Alguno de los registros del universo no cuentan con un código");
                        if (codigo.Split('|').Length != 2) throw new Exception("El código de alguno de los registros del universo no es válido");

                        oCampos.COD_PLAN = codigo.Split('|')[0];
                        oCampos.COD_SECUENCIAL = Convert.ToInt32(codigo.Split('|')[1]);

                        if (oCampos.COD_PLAN != asCodPlan) throw new Exception("Los registros del universo no correcponden al plan de la casuística");

                        lstUniverso.Add(oCampos);
                    }
                }
            }

            return lstUniverso;
        }

        public static List<Ent_PLAN_CASUISTICA_UNIVERSO> PriorizarPlanCasuisticaUniverso(HttpRequestBase _request, string asCodPlan)
        {
            Log_PLANIFICACION _logPlan = new Log_PLANIFICACION();
            List<Ent_PLAN_CASUISTICA_UNIVERSO> lstPriorizar = new List<Ent_PLAN_CASUISTICA_UNIVERSO>();

            var lstConsolidado = _logPlan.ConsolidadoPlanCasuisticaUniverso(asCodPlan);
            if (lstConsolidado.Count == 0)
            {
                throw new Exception("No se encoentraron registros en el consolidado");
            }

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.Where(x => x.Name == "Universo").First(); //currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    Ent_PLAN_CASUISTICA_UNIVERSO entRegistro;

                    for (int rowIterator = 3; rowIterator <= noOfRow; rowIterator++)
                    {
                        var codigo = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim();
                        var priorizar = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                        if (codigo == "") throw new Exception("Alguno de los registros del universo no cuentan con un código");
                        if (codigo.Split('|').Length != 2) throw new Exception("El código de alguno de los registros del universo no es válido");
                        if (priorizar.ToUpper() != "SI" && priorizar.ToUpper() != "NO") throw new Exception("La opción de la columna PRIORIZAR no es válido (opciones válidas: SI/NO)");

                        foreach (var item in lstConsolidado)
                        {
                            if (item["CODIGO"] == codigo)
                            {
                                entRegistro = new Ent_PLAN_CASUISTICA_UNIVERSO();
                                entRegistro.COD_PLAN = asCodPlan;
                                entRegistro.COD_SECUENCIAL = Convert.ToInt32(item["COD_SECUENCIAL"]);
                                entRegistro.COD_PCASUISTICA = item["COD_PCASUISTICA"];
                                entRegistro.PRIORIZAR = priorizar.ToUpper() == "SI" ? true : false;
                                lstPriorizar.Add(entRegistro);
                                break;
                            }
                        }
                    }
                }
            }

            return lstPriorizar;
        }
    }
}