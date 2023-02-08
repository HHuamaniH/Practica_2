using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIGOFCv3.Areas.Notificacion.Models.ManNotificacion
{
    public class ImportarDatos
    {
        public static List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE> MuestraMaderable(string asCodNotificacion, HttpRequestBase _request)
        {
            CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE paramsCN = new CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE();
            CapaLogica.DOC.Log_NOTIFICACION exeCN = new CapaLogica.DOC.Log_NOTIFICACION();
            List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE> lstCenso = new List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE>();

            paramsCN.COD_FISNOTI = asCodNotificacion;
            lstCenso = exeCN.RegMostrarPoaDetMadCensoLista_v3(paramsCN);

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE oCampos;
                    string[] codSistema;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE();
                        codSistema = workSheet.Cells[rowIterator, 18].Value.ToString().Trim().Split('|');

                        for (int i = 0; i < lstCenso.Count; i++)
                        {
                            if (lstCenso[i].NUM_POA == Convert.ToInt32(codSistema[2]) && lstCenso[i].COD_ESPECIES == codSistema[3] && lstCenso[i].COD_SECUENCIAL == Convert.ToInt32(codSistema[4]))
                            {
                                switch (lstCenso[i].NUM_MUESTRA)
                                {
                                    case 1: lstCenso[i].RegEstado = (bool)lstCenso[i].ESTADO_MUESTRA == true ? 0 : 1; lstCenso[i].ESTADO_MUESTRA = true; break;
                                    case 2: lstCenso[i].RegEstado = (bool)lstCenso[i].ESTADO_MUESTRA2 == true ? 0 : 1; lstCenso[i].ESTADO_MUESTRA2 = true; break;
                                    case 3: lstCenso[i].RegEstado = (bool)lstCenso[i].ESTADO_MUESTRA3 == true ? 0 : 1; lstCenso[i].ESTADO_MUESTRA3 = true; break;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            return lstCenso;
        }

        public static List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE> MuestraNoMaderable(string asCodNotificacion, HttpRequestBase _request)
        {
            CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE paramsCN = new CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE();
            CapaLogica.DOC.Log_NOTIFICACION exeCN = new CapaLogica.DOC.Log_NOTIFICACION();
            List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE> lstCenso = new List<CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE>();

            paramsCN.COD_FISNOTI = asCodNotificacion;
            lstCenso = exeCN.RegMostrarPoaDetNoMadCensoLista_v3(paramsCN);

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE oCampos;
                    string[] codSistema;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE();
                        codSistema = workSheet.Cells[rowIterator, 14].Value.ToString().Trim().Split('|');

                        for (int i = 0; i < lstCenso.Count; i++)
                        {
                            if (lstCenso[i].NUM_POA == Convert.ToInt32(codSistema[2]) && lstCenso[i].COD_ESPECIES == codSistema[3] && lstCenso[i].COD_SECUENCIAL == Convert.ToInt32(codSistema[4]))
                            {
                                switch (lstCenso[i].NUM_MUESTRA)
                                {
                                    case 1: lstCenso[i].RegEstado = (bool)lstCenso[i].ESTADO_MUESTRA == true ? 0 : 1; lstCenso[i].ESTADO_MUESTRA = true; break;
                                    case 2: lstCenso[i].RegEstado = (bool)lstCenso[i].ESTADO_MUESTRA2 == true ? 0 : 1; lstCenso[i].ESTADO_MUESTRA2 = true; break;
                                    case 3: lstCenso[i].RegEstado = (bool)lstCenso[i].ESTADO_MUESTRA3 == true ? 0 : 1; lstCenso[i].ESTADO_MUESTRA3 = true; break;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            return lstCenso;
        }
    }
}