using CapaEntidad.ViewModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIGOFCv3.Areas.Supervision.Models.ManInforme
{
    public class ImportarDatos
    {
        public static List<CapaEntidad.DOC.Ent_INFORME> VerticeTHabilitanteCampo(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME> lstVertice = new List<CapaEntidad.DOC.Ent_INFORME>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_INFORME oCampos;
                    string ceste, cnorte;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CapaEntidad.DOC.Ent_INFORME();
                        oCampos.COD_SISTEMA = workSheet.Cells[rowIterator, 1].Value.ToString().Trim();
                        oCampos.ZONA_CAMPO = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                        if (oCampos.ZONA_CAMPO == "17S" || oCampos.ZONA_CAMPO == "18S" || oCampos.ZONA_CAMPO == "19S")
                        {
                            ceste = (workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim();
                            cnorte = (workSheet.Cells[rowIterator, 9].Value ?? "").ToString().Trim();
                            if (ceste != "" && cnorte != "")
                            {
                                oCampos.VERTICE = workSheet.Cells[rowIterator, 2].Value.ToString().Trim();
                                oCampos.VERTICE_CAMPO = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim();
                                oCampos.ZONA = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                                oCampos.COORDENADA_ESTE = Convert.ToInt32(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                oCampos.COORDENADA_ESTE_CAMPO = Convert.ToInt32(ceste);
                                oCampos.COORDENADA_NORTE = Convert.ToInt32(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                                oCampos.COORDENADA_NORTE_CAMPO = Convert.ToInt32(ceste);
                                oCampos.OBSERVACION_CAMPO = (workSheet.Cells[rowIterator, 10].Value ?? "").ToString().Trim();
                                oCampos.RegEstado = 1;
                                lstVertice.Add(oCampos);
                            }
                            else { throw new Exception("Coordenada incorrecta"); }
                        }
                        else { throw new Exception("Zona UTM incorrecta"); }
                    }
                }
            }

            return lstVertice;
        }
        public static List<CapaEntidad.DOC.Ent_INFORME> AvistamientoFauna(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME> lstAvistamiento = new List<CapaEntidad.DOC.Ent_INFORME>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_INFORME oCampos;
                    string ceste, cnorte;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CapaEntidad.DOC.Ent_INFORME();
                        oCampos.COD_SECUENCIAL = 0;
                        oCampos.COD_ESPECIES = "";
                        oCampos.DESC_ESPECIES = workSheet.Cells[rowIterator, 1].Value.ToString().Trim() + " | " + workSheet.Cells[rowIterator, 2].Value.ToString().Trim();
                        oCampos.ZONA = (workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim();
                        if (oCampos.ZONA == "17S" || oCampos.ZONA == "18S" || oCampos.ZONA == "19S")
                        {
                            ceste = (workSheet.Cells[rowIterator, 9].Value ?? "").ToString().Trim();
                            cnorte = (workSheet.Cells[rowIterator, 10].Value ?? "").ToString().Trim();
                            if (ceste != "" && cnorte != "")
                            {
                                oCampos.NUM_INDIVIDUOS = Convert.ToInt32(workSheet.Cells[rowIterator, 3].Value.ToString().Trim());
                                oCampos.COD_TIPO_REGISTRO = "";
                                oCampos.DESC_TIPO_REGISTRO = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                                oCampos.COD_ESTRATO = "";
                                oCampos.DESC_ESTRATO = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                                oCampos.FECHA_AVISTAMIENTO = (workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim();
                                oCampos.HORA_AVISTAMIENTO = (workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim();
                                oCampos.COORDENADA_ESTE = Convert.ToInt32(ceste);
                                oCampos.COORDENADA_NORTE = Convert.ToInt32(cnorte);
                                oCampos.ALTITUD = Convert.ToInt32(workSheet.Cells[rowIterator, 11].Value.ToString().Trim());
                                oCampos.DESCRIPCION = (workSheet.Cells[rowIterator, 12].Value ?? "").ToString().Trim();
                                oCampos.RegEstado = 1;
                                lstAvistamiento.Add(oCampos);
                            }
                            else { throw new Exception("Coordenada incorrecta"); }
                        }
                        else { throw new Exception("Zona UTM incorrecta"); }
                    }
                }
            }

            return lstAvistamiento;
        }
        public static List<CapaEntidad.DOC.Ent_INFORME> VerticeArea(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME> lstVertice = new List<CapaEntidad.DOC.Ent_INFORME>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_INFORME oCampos;
                    string ceste, cnorte;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CapaEntidad.DOC.Ent_INFORME();

                        oCampos.COD_SISTEMA = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                        oCampos.VERTICE = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim();
                        oCampos.VERTICE_CAMPO = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim();
                        oCampos.ZONA = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                        oCampos.ZONA_CAMPO = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                        if (oCampos.ZONA_CAMPO == "17S" || oCampos.ZONA_CAMPO == "18S" || oCampos.ZONA_CAMPO == "19S")
                        {
                            ceste = (workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim();
                            cnorte = (workSheet.Cells[rowIterator, 9].Value ?? "").ToString().Trim();
                            if (ceste != "" && cnorte != "")
                            {
                                oCampos.COORDENADA_ESTE = Convert.ToInt32((workSheet.Cells[rowIterator, 6].Value ?? "0").ToString().Trim());
                                oCampos.COORDENADA_ESTE_CAMPO = Convert.ToInt32(ceste);
                                oCampos.COORDENADA_NORTE = Convert.ToInt32((workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim());
                                oCampos.COORDENADA_NORTE_CAMPO = Convert.ToInt32(cnorte);
                                oCampos.PCA = (workSheet.Cells[rowIterator, 10].Value ?? "").ToString().Trim();
                                oCampos.PCA_CAMPO = (workSheet.Cells[rowIterator, 11].Value ?? "").ToString().Trim();
                                oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 12].Value ?? "").ToString().Trim();

                                if (!string.IsNullOrEmpty(oCampos.COD_SISTEMA) && oCampos.COD_SISTEMA.Split('|').Length > 2)
                                {
                                    if (oCampos.COD_SISTEMA.Split('|')[2] == "0") oCampos.RegEstado = 1;
                                    else
                                    {
                                        oCampos.COD_SECUENCIAL = Convert.ToInt32(oCampos.COD_SISTEMA.Split('|')[2]);
                                        oCampos.RegEstado = 0;
                                    }
                                }
                                else { throw new Exception("Código de vértice incorrecto"); }

                                lstVertice.Add(oCampos);
                            }
                            else { throw new Exception("Coordenada incorrecta"); }
                        }
                        else { throw new Exception("Zona UTM incorrecta"); }
                    }
                }
            }
            return lstVertice;
        }
        public static List<CapaEntidad.DOC.Ent_INFORME_EVAL_ARBOL> EvaluacionArbol(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME_EVAL_ARBOL> lstEvalArbol = new List<CapaEntidad.DOC.Ent_INFORME_EVAL_ARBOL>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_INFORME_EVAL_ARBOL oCampos;
                    string ceste, cnorte;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CapaEntidad.DOC.Ent_INFORME_EVAL_ARBOL();

                        oCampos.ZONA = (workSheet.Cells[rowIterator, 11].Value ?? "").ToString().Trim();
                        if (oCampos.ZONA == "17S" || oCampos.ZONA == "18S" || oCampos.ZONA == "19S")
                        {
                            ceste = (workSheet.Cells[rowIterator, 12].Value ?? "").ToString().Trim();
                            cnorte = (workSheet.Cells[rowIterator, 13].Value ?? "").ToString().Trim();
                            if (ceste != "" && cnorte != "")
                            {
                                oCampos.DESC_EESTADO = (workSheet.Cells[rowIterator, 14].Value ?? "").ToString().Trim();
                                if (oCampos.DESC_EESTADO != "")
                                {
                                    oCampos.COD_SECUENCIAL = 0;
                                    oCampos.DESC_ESPECIES = String.Format("{0} | {1}", (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim(), (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim());
                                    oCampos.BLOQUE = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim();
                                    oCampos.FAJA = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                                    oCampos.CODIGO = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                                    oCampos.DAP = Convert.ToDecimal((workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim());
                                    oCampos.DAP1 = Convert.ToDecimal((workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim());
                                    oCampos.DAP2 = Convert.ToDecimal((workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim());
                                    oCampos.MMEDIR_DAP = (workSheet.Cells[rowIterator, 9].Value ?? "").ToString().Trim();
                                    oCampos.AC = Convert.ToDecimal((workSheet.Cells[rowIterator, 10].Value ?? "").ToString().Trim());
                                    oCampos.COORDENADA_ESTE = Convert.ToInt32(ceste);
                                    oCampos.COORDENADA_NORTE = Convert.ToInt32(cnorte);
                                    oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 15].Value ?? "").ToString().Trim();
                                    oCampos.RegEstado = 1;
                                    lstEvalArbol.Add(oCampos);
                                }
                                else { throw new Exception("El estado de la especie es obligatorio"); }
                            }
                            else { throw new Exception("Coordenada incorrecta"); }
                        }
                        else { throw new Exception("Zona UTM incorrecta"); }
                    }
                }
            }
            return lstEvalArbol;
        }
        public static List<CapaEntidad.DOC.Ent_INFORME_HUAYRONA> Huayrona(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME_HUAYRONA> lstHuayrona = new List<CapaEntidad.DOC.Ent_INFORME_HUAYRONA>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_INFORME_HUAYRONA oCampos;
                    string ceste, cnorte;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CapaEntidad.DOC.Ent_INFORME_HUAYRONA();

                        oCampos.ZONA = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim();
                        if (oCampos.ZONA == "17S" || oCampos.ZONA == "18S" || oCampos.ZONA == "19S")
                        {
                            ceste = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim();
                            cnorte = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                            if (ceste != "" && cnorte != "")
                            {
                                oCampos.NUMERO = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                                oCampos.COORDENADA_ESTE = Convert.ToInt32(ceste);
                                oCampos.COORDENADA_NORTE = Convert.ToInt32(cnorte);
                                oCampos.VOLUMEN = Convert.ToDecimal((workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim());
                                oCampos.RegEstado = 1;
                                lstHuayrona.Add(oCampos);
                            }
                            else { throw new Exception("Coordenada incorrecta"); }
                        }
                        else { throw new Exception("Zona UTM incorrecta"); }
                    }
                }
            }
            return lstHuayrona;
        }
        public static List<CapaEntidad.DOC.Ent_INFORME_ACT_SILVICULTURAL> ActividadSilvicultural(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME_ACT_SILVICULTURAL> lstActividad = new List<CapaEntidad.DOC.Ent_INFORME_ACT_SILVICULTURAL>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_INFORME_ACT_SILVICULTURAL oCampos;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CapaEntidad.DOC.Ent_INFORME_ACT_SILVICULTURAL();
                        oCampos.COD_SECUENCIAL = 0;
                        oCampos.DESC_SILVICULTURALES = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                        oCampos.COD_ESPECIES = "";
                        oCampos.DESC_ESPECIES = workSheet.Cells[rowIterator, 2].Value.ToString().Trim() + " | " + workSheet.Cells[rowIterator, 3].Value.ToString().Trim();
                        oCampos.FAJA = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                        oCampos.NUM_PLANTULAS = Convert.ToInt32((workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim());
                        oCampos.UBICACION = (workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim();
                        oCampos.TIEMPO = Convert.ToInt32((workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim());
                        oCampos.CUMPLIMIENTO_ACTIVIDADES = (workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim().ToUpper() == "SI" ? true : false;
                        oCampos.DESC_CUMPLIMIENTO = (bool)oCampos.CUMPLIMIENTO_ACTIVIDADES == true ? "SI" : "";
                        oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 9].Value ?? "").ToString().Trim();
                        oCampos.RegEstado = 1;
                        lstActividad.Add(oCampos);
                    }
                }
            }
            return lstActividad;
        }
        public static List<CapaEntidad.DOC.Ent_INFORME_EVAL_OTRO> EvaluacionOtro(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME_EVAL_OTRO> lstEval = new List<CapaEntidad.DOC.Ent_INFORME_EVAL_OTRO>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_INFORME_EVAL_OTRO oCampos;
                    string ceste, cnorte;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CapaEntidad.DOC.Ent_INFORME_EVAL_OTRO();
                        oCampos.ZONA = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim();
                        if (oCampos.ZONA == "17S" || oCampos.ZONA == "18S" || oCampos.ZONA == "19S")
                        {
                            ceste = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim();
                            cnorte = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                            if (ceste != "" && cnorte != "")
                            {
                                oCampos.COD_SECUENCIAL = 0;
                                oCampos.EVALUACION = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                                oCampos.COORDENADA_ESTE = Convert.ToInt32(ceste);
                                oCampos.COORDENADA_NORTE = Convert.ToInt32(cnorte);
                                oCampos.DESCRIPCION = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                                oCampos.RegEstado = 1;
                                lstEval.Add(oCampos);
                            }
                            else { throw new Exception("Coordenada incorrecta"); }
                        }
                        else { throw new Exception("Zona UTM incorrecta"); }
                    }
                }
            }
            return lstEval;
        }
        public static List<CapaEntidad.DOC.Ent_INFORME_VOL_ANALIZADO> VolumenAnalizado(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME_VOL_ANALIZADO> lstVolAnaliza = new List<CapaEntidad.DOC.Ent_INFORME_VOL_ANALIZADO>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_INFORME_VOL_ANALIZADO oCampos;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CapaEntidad.DOC.Ent_INFORME_VOL_ANALIZADO();
                        oCampos.COD_SECUENCIAL = 0;
                        oCampos.COD_ESPECIES = "";
                        oCampos.ESPECIES = workSheet.Cells[rowIterator, 1].Value.ToString().Trim() + " | " + workSheet.Cells[rowIterator, 2].Value.ToString().Trim();
                        oCampos.VOLUMEN_APROBADO = Convert.ToDecimal(workSheet.Cells[rowIterator, 3].Value.ToString().Trim());
                        oCampos.VOLUMEN_MOVILIZADO = Convert.ToDecimal(workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                        oCampos.VOLUMEN_INJUSTIFICADO = Convert.ToDecimal(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                        oCampos.VOLUMEN_JUSTIFICADO = Convert.ToDecimal(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                        oCampos.PCA = (workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim();
                        oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim();
                        oCampos.RegEstado = 1;
                        lstVolAnaliza.Add(oCampos);
                    }
                }
            }
            return lstVolAnaliza;
        }

        public static ListResult DatosCampoMaderable(HttpRequestBase _request, string asCodInforme)
        {
            ListResult result = new ListResult();
            try
            {
                List<CapaEntidad.DOC.Ent_INFORME> lstEspecie = new List<CapaEntidad.DOC.Ent_INFORME>();

                HttpPostedFileBase file = _request.Files[0];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        CapaEntidad.DOC.Ent_INFORME oCampos;

                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            oCampos = new CapaEntidad.DOC.Ent_INFORME();
                            oCampos.COD_INFORME = asCodInforme;
                            oCampos.COD_SECUENCIAL = 0;
                            oCampos.BLOQUE_CAMPO = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                            oCampos.FAJA_CAMPO = (workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim();
                            oCampos.CODIGO_CAMPO = (workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim();
                            oCampos.DAP_CAMPO = Convert.ToDecimal(workSheet.Cells[rowIterator, 20].Value.ToString().Trim());
                            oCampos.DAP_CAMPO1 = Convert.ToDecimal(workSheet.Cells[rowIterator, 21].Value.ToString().Trim());
                            oCampos.DAP_CAMPO2 = Convert.ToDecimal(workSheet.Cells[rowIterator, 22].Value.ToString().Trim());
                            oCampos.MMEDIR_DAP = (workSheet.Cells[rowIterator, 23].Value ?? "").ToString().Trim();
                            oCampos.AC_CAMPO = Convert.ToDecimal(workSheet.Cells[rowIterator, 25].Value.ToString().Trim());
                            oCampos.ESTADO_CAMPO = (workSheet.Cells[rowIterator, 27].Value ?? "").ToString().Trim();
                            oCampos.ZONA_CAMPO = (workSheet.Cells[rowIterator, 14].Value ?? "").ToString().Trim();
                            oCampos.COORDENADA_ESTE_CAMPO = Convert.ToInt32(workSheet.Cells[rowIterator, 16].Value.ToString().Trim());
                            oCampos.COORDENADA_NORTE_CAMPO = Convert.ToInt32(workSheet.Cells[rowIterator, 18].Value.ToString().Trim());
                            oCampos.DESC_ECONDICION = (workSheet.Cells[rowIterator, 29].Value ?? "").ToString().Trim();
                            oCampos.CANT_SOBRE_ESTIMA_DIAMETRO = Convert.ToInt32((workSheet.Cells[rowIterator, 30].Value ?? "").ToString().Trim());
                            oCampos.PORC_SOBRE_ESTIMA_DIAMETRO = Convert.ToDecimal((workSheet.Cells[rowIterator, 31].Value ?? "").ToString().Trim());
                            oCampos.CANT_SUB_ESTIMA_DIAMETRO = Convert.ToInt32((workSheet.Cells[rowIterator, 32].Value ?? "").ToString().Trim());
                            oCampos.PORC_SUB_ESTIMA_DIAMETRO = Convert.ToDecimal((workSheet.Cells[rowIterator, 33].Value ?? "").ToString().Trim());
                            oCampos.PCA = (workSheet.Cells[rowIterator, 35].Value ?? "").ToString().Trim();
                            oCampos.OBSERVACION_CAMPO = (workSheet.Cells[rowIterator, 36].Value ?? "").ToString().Trim();
                            oCampos.COD_SISTEMA = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                            oCampos.ESPECIES = String.Format("{0} | {1}", (workSheet.Cells[rowIterator, 10].Value ?? "").ToString().Trim(), (workSheet.Cells[rowIterator, 11].Value ?? "").ToString().Trim());
                            oCampos.DESC_COINCIDE_ESPECIES = (workSheet.Cells[rowIterator, 12].Value ?? "").ToString().Trim();
                            if (oCampos.DESC_COINCIDE_ESPECIES != "")
                                oCampos.COINCIDE_ESPECIES = oCampos.DESC_COINCIDE_ESPECIES == "Ninguno" ? "NN" : oCampos.DESC_COINCIDE_ESPECIES;
                            oCampos.RegEstado = 0;

                            lstEspecie.Add(oCampos);
                        }
                    }
                }

                //Grabar en la BD
                CapaLogica.DOC.Log_INFORME exeInf = new CapaLogica.DOC.Log_INFORME();
                exeInf.RegModificarFormato(new CapaEntidad.DOC.Ent_INFORME() { ListINFORMEItemsDetalle = lstEspecie });

                result.AddResultado("Ok", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }
        public static ListResult DatosCampoBosqueSeco(HttpRequestBase _request, string asCodInforme)
        {
            ListResult result = new ListResult();
            try
            {
                List<CapaEntidad.DOC.Ent_INFORME> lstEspecie = new List<CapaEntidad.DOC.Ent_INFORME>();

                HttpPostedFileBase file = _request.Files[0];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        CapaEntidad.DOC.Ent_INFORME oCampos;

                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            oCampos = new CapaEntidad.DOC.Ent_INFORME();
                            oCampos.COD_INFORME = asCodInforme;
                            oCampos.COD_SECUENCIAL = 0;
                            oCampos.COD_SISTEMA = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                            oCampos.ESPECIES = String.Format("{0} | {1}", (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim(), (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim());
                            oCampos.BLOQUE_CAMPO = (workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim();
                            oCampos.FAJA_CAMPO = (workSheet.Cells[rowIterator, 9].Value ?? "").ToString().Trim();
                            oCampos.CODIGO_CAMPO = (workSheet.Cells[rowIterator, 11].Value ?? "").ToString().Trim();
                            oCampos.DAP_CAMPO = Convert.ToDecimal(workSheet.Cells[rowIterator, 13].Value.ToString().Trim());
                            oCampos.AC_CAMPO = Convert.ToDecimal(workSheet.Cells[rowIterator, 15].Value.ToString().Trim());
                            oCampos.ESTADO_CAMPO = (workSheet.Cells[rowIterator, 19].Value ?? "").ToString().Trim();
                            oCampos.ZONA_CAMPO = (workSheet.Cells[rowIterator, 22].Value ?? "").ToString().Trim();
                            oCampos.COORDENADA_ESTE_CAMPO = Convert.ToInt32(workSheet.Cells[rowIterator, 24].Value.ToString().Trim());
                            oCampos.COORDENADA_NORTE_CAMPO = Convert.ToInt32(workSheet.Cells[rowIterator, 26].Value.ToString().Trim());
                            oCampos.BS_ALTURA_TOTAL = Convert.ToDecimal(workSheet.Cells[rowIterator, 29].Value.ToString().Trim());
                            oCampos.BS_DIAMETRO_RAMA_1 = Convert.ToDecimal(workSheet.Cells[rowIterator, 30].Value.ToString().Trim());
                            oCampos.BS_DIAMETRO_RAMA_2 = Convert.ToDecimal(workSheet.Cells[rowIterator, 31].Value.ToString().Trim());
                            oCampos.BS_DIAMETRO_RAMA_3 = Convert.ToDecimal(workSheet.Cells[rowIterator, 32].Value.ToString().Trim());
                            oCampos.BS_DIAMETRO_RAMA_4 = Convert.ToDecimal(workSheet.Cells[rowIterator, 33].Value.ToString().Trim());
                            oCampos.BS_DIAMETRO_RAMA_5 = Convert.ToDecimal(workSheet.Cells[rowIterator, 34].Value.ToString().Trim());
                            oCampos.BS_DIAMETRO_RAMA_6 = Convert.ToDecimal(workSheet.Cells[rowIterator, 35].Value.ToString().Trim());
                            oCampos.BS_DIAMETRO_RAMA_7 = Convert.ToDecimal(workSheet.Cells[rowIterator, 36].Value.ToString().Trim());
                            oCampos.BS_LONGITUD_RAMA_1 = Convert.ToDecimal(workSheet.Cells[rowIterator, 37].Value.ToString().Trim());
                            oCampos.BS_LONGITUD_RAMA_2 = Convert.ToDecimal(workSheet.Cells[rowIterator, 38].Value.ToString().Trim());
                            oCampos.BS_LONGITUD_RAMA_3 = Convert.ToDecimal(workSheet.Cells[rowIterator, 39].Value.ToString().Trim());
                            oCampos.BS_LONGITUD_RAMA_4 = Convert.ToDecimal(workSheet.Cells[rowIterator, 40].Value.ToString().Trim());
                            oCampos.BS_LONGITUD_RAMA_5 = Convert.ToDecimal(workSheet.Cells[rowIterator, 41].Value.ToString().Trim());
                            oCampos.BS_LONGITUD_RAMA_6 = Convert.ToDecimal(workSheet.Cells[rowIterator, 42].Value.ToString().Trim());
                            oCampos.BS_LONGITUD_RAMA_7 = Convert.ToDecimal(workSheet.Cells[rowIterator, 43].Value.ToString().Trim());
                            oCampos.OBSERVACION_CAMPO = (workSheet.Cells[rowIterator, 44].Value ?? "").ToString().Trim();
                            oCampos.RegEstado = 0;
                            lstEspecie.Add(oCampos);
                        }
                    }
                }

                //Grabar en la BD
                CapaLogica.DOC.Log_INFORME exeInf = new CapaLogica.DOC.Log_INFORME();
                exeInf.RegModificarFormatoBosqueSeco(new CapaEntidad.DOC.Ent_INFORME() { ListINFORMEItemsDetalle = lstEspecie });

                result.AddResultado("Ok", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }
        public static ListResult DatosCampoSemillero(HttpRequestBase _request, string asCodInforme)
        {
            ListResult result = new ListResult();
            try
            {
                List<CapaEntidad.DOC.Ent_INFORME> lstEspecie = new List<CapaEntidad.DOC.Ent_INFORME>();

                HttpPostedFileBase file = _request.Files[0];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        CapaEntidad.DOC.Ent_INFORME oCampos;

                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            oCampos = new CapaEntidad.DOC.Ent_INFORME();
                            oCampos.COD_INFORME = asCodInforme;
                            oCampos.COD_SECUENCIAL = 0;
                            oCampos.BLOQUE_CAMPO = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                            oCampos.FAJA_CAMPO = (workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim();
                            oCampos.CODIGO_CAMPO = (workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim();
                            oCampos.ESPECIES = String.Format("{0} | {1}", (workSheet.Cells[rowIterator, 10].Value ?? "").ToString().Trim(), (workSheet.Cells[rowIterator, 11].Value ?? "").ToString().Trim());
                            oCampos.DESC_COINCIDE_ESPECIES = (workSheet.Cells[rowIterator, 12].Value ?? "").ToString().Trim();
                            if (oCampos.DESC_COINCIDE_ESPECIES != "")
                                oCampos.COINCIDE_ESPECIES = oCampos.DESC_COINCIDE_ESPECIES == "Ninguno" ? "NN" : oCampos.DESC_COINCIDE_ESPECIES;
                            oCampos.ZONA_CAMPO = (workSheet.Cells[rowIterator, 14].Value ?? "").ToString().Trim();
                            oCampos.COORDENADA_ESTE_CAMPO = Convert.ToInt32(workSheet.Cells[rowIterator, 16].Value.ToString().Trim());
                            oCampos.COORDENADA_NORTE_CAMPO = Convert.ToInt32(workSheet.Cells[rowIterator, 18].Value.ToString().Trim());
                            oCampos.DAP_CAMPO = Convert.ToDecimal(workSheet.Cells[rowIterator, 20].Value.ToString().Trim());
                            oCampos.DAP_CAMPO1 = Convert.ToDecimal(workSheet.Cells[rowIterator, 21].Value.ToString().Trim());
                            oCampos.DAP_CAMPO2 = Convert.ToDecimal(workSheet.Cells[rowIterator, 22].Value.ToString().Trim());
                            oCampos.MMEDIR_DAP = (workSheet.Cells[rowIterator, 23].Value ?? "").ToString().Trim();
                            oCampos.AC_CAMPO = Convert.ToDecimal(workSheet.Cells[rowIterator, 25].Value.ToString().Trim());
                            oCampos.ESTADO_CAMPO = (workSheet.Cells[rowIterator, 27].Value ?? "").ToString().Trim();
                            /*parcelas de corta*/
                            oCampos.PCA = (workSheet.Cells[rowIterator, 29].Value ?? "").ToString().Trim();

                            oCampos.DESC_EFENOLOGICO = (workSheet.Cells[rowIterator, 30].Value ?? "").ToString().Trim();
                            oCampos.DESC_CFUSTE = (workSheet.Cells[rowIterator, 31].Value ?? "").ToString().Trim();
                            oCampos.DESC_FCOPA = (workSheet.Cells[rowIterator, 32].Value ?? "").ToString().Trim();
                            oCampos.DESC_PCOPA = (workSheet.Cells[rowIterator, 33].Value ?? "").ToString().Trim();
                            oCampos.DESC_ESANITARIO = (workSheet.Cells[rowIterator, 34].Value ?? "").ToString().Trim();
                            oCampos.DESC_ILIANAS = (workSheet.Cells[rowIterator, 35].Value ?? "").ToString().Trim();
                            oCampos.CANT_SOBRE_ESTIMA_DIAMETRO = Convert.ToInt32((workSheet.Cells[rowIterator, 36].Value ?? "").ToString().Trim());
                            oCampos.PORC_SOBRE_ESTIMA_DIAMETRO = Convert.ToDecimal((workSheet.Cells[rowIterator, 37].Value ?? "").ToString().Trim());
                            oCampos.CANT_SUB_ESTIMA_DIAMETRO = Convert.ToInt32((workSheet.Cells[rowIterator, 38].Value ?? "").ToString().Trim());
                            oCampos.PORC_SUB_ESTIMA_DIAMETRO = Convert.ToDecimal((workSheet.Cells[rowIterator, 39].Value ?? "").ToString().Trim());
                            oCampos.OBSERVACION_CAMPO = (workSheet.Cells[rowIterator, 40].Value ?? "").ToString().Trim();
                            oCampos.COD_SISTEMA = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                            oCampos.RegEstado = 0;
                            lstEspecie.Add(oCampos);
                        }
                    }
                }

                //Grabar en la BD
                CapaLogica.DOC.Log_INFORME exeInf = new CapaLogica.DOC.Log_INFORME();
                exeInf.RegModificarFormato(new CapaEntidad.DOC.Ent_INFORME() { ListINFORMEItemsDetalle = lstEspecie });

                result.AddResultado("Ok", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }
        public static ListResult DatosCampoNoMaderable(HttpRequestBase _request, string asCodInforme)
        {
            ListResult result = new ListResult();
            try
            {
                List<CapaEntidad.DOC.Ent_INFORME> lstEspecie = new List<CapaEntidad.DOC.Ent_INFORME>();

                HttpPostedFileBase file = _request.Files[0];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        CapaEntidad.DOC.Ent_INFORME oCampos;

                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            oCampos = new CapaEntidad.DOC.Ent_INFORME();
                            oCampos.COD_INFORME = asCodInforme;
                            oCampos.COD_SECUENCIAL = 0;
                            oCampos.COD_SISTEMA = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                            oCampos.ESPECIES = String.Format("{0} | {1}", (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim(), (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim());
                            oCampos.NUM_ESTRADA = (workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim();
                            oCampos.CODIGO_CAMPO = (workSheet.Cells[rowIterator, 9].Value ?? "").ToString().Trim();
                            //oCampos.DIAMETRO_CAMPO = Convert.ToDecimal((workSheet.Cells[rowIterator, 11].Value ?? "").ToString().Trim());
                            //oCampos.ALTURA_CAMPO = Convert.ToDecimal((workSheet.Cells[rowIterator, 13].Value ?? "").ToString().Trim());
                            //oCampos.PRODUCCION_LATAS_CAMPO = Convert.ToDecimal((workSheet.Cells[rowIterator, 15].Value ?? "").ToString().Trim());
                            //oCampos.CONDICION_CAMPO = (workSheet.Cells[rowIterator, 11].Value ?? "").ToString().Trim();
                            oCampos.ESTADO_CAMPO = (workSheet.Cells[rowIterator, 18].Value ?? "").ToString().Trim();
                            oCampos.ZONA_CAMPO = (workSheet.Cells[rowIterator, 13].Value ?? "").ToString().Trim();
                            oCampos.COORDENADA_ESTE_CAMPO = Convert.ToInt32(workSheet.Cells[rowIterator, 15].Value.ToString().Trim());
                            oCampos.COORDENADA_NORTE_CAMPO = Convert.ToInt32(workSheet.Cells[rowIterator, 17].Value.ToString().Trim());
                            //oCampos.NUM_COCOS_ABIERTOS = Convert.ToInt32((workSheet.Cells[rowIterator, 26].Value ?? "").ToString().Trim());
                            //oCampos.NUM_COCOS_CERRADOS = Convert.ToInt32((workSheet.Cells[rowIterator, 27].Value ?? "").ToString().Trim());
                            //oCampos.DESC_CFUSTE = (workSheet.Cells[rowIterator, 28].Value ?? "").ToString().Trim();
                            //oCampos.DESC_PCOPA = (workSheet.Cells[rowIterator, 29].Value ?? "").ToString().Trim();
                            //oCampos.DESC_FCOPA = (workSheet.Cells[rowIterator, 30].Value ?? "").ToString().Trim();
                            //oCampos.DESC_EFENOLOGICO = (workSheet.Cells[rowIterator, 31].Value ?? "").ToString().Trim();
                            oCampos.DESC_ESANITARIO = (workSheet.Cells[rowIterator, 19].Value ?? "").ToString().Trim();
                            oCampos.DESC_ILIANAS = (workSheet.Cells[rowIterator, 20].Value ?? "").ToString().Trim();
                            oCampos.DESC_ECONDICION_CAMPO = (workSheet.Cells[rowIterator, 21].Value ?? "").ToString().Trim();
                            oCampos.OBSERVACION_CAMPO = (workSheet.Cells[rowIterator, 22].Value ?? "").ToString().Trim();
                            oCampos.RegEstado = 0;
                            lstEspecie.Add(oCampos);
                        }
                    }
                }

                //Grabar en la BD
                CapaLogica.DOC.Log_INFORME exeInf = new CapaLogica.DOC.Log_INFORME();
                exeInf.RegModificarFormatoNoMaderable(new CapaEntidad.DOC.Ent_INFORME() { ListINFORMEItemsDetalle = lstEspecie });

                result.AddResultado("Ok", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }
        public static ListResult DatosTrozaCampo(HttpRequestBase _request, string asCodInforme, Int32 aiNumPoa, string asCodUCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                List<CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO> lstEspecie = new List<CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO>();

                HttpPostedFileBase file = _request.Files[0];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO oCampos;

                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            oCampos = new CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO();
                            oCampos.COD_INFORME = asCodInforme;
                            oCampos.NUM_POA = aiNumPoa;
                            oCampos.COD_SECUENCIAL = 0;
                            oCampos.CODIGO = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                            oCampos.COD_ESPECIES = "";
                            oCampos.ESPECIES = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim() + " | " + (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim();
                            oCampos.ZONA = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                            if (oCampos.ZONA != "17S" && oCampos.ZONA != "18S" && oCampos.ZONA != "19S")
                            {
                                oCampos.ZONA = "";
                            }
                            oCampos.COORDENADA_ESTE = Convert.ToInt32(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                            oCampos.COORDENADA_NORTE = Convert.ToInt32(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                            oCampos.DAP1 = Convert.ToDecimal(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                            oCampos.DAP2 = Convert.ToDecimal(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                            oCampos.LC = Convert.ToDecimal(workSheet.Cells[rowIterator, 9].Value.ToString().Trim());
                            oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 10].Value ?? "").ToString().Trim();
                            oCampos.RegEstado = 1;
                            lstEspecie.Add(oCampos);
                        }
                    }
                }

                //Grabar en la BD
                CapaLogica.DOC.Log_INFORME exeInf = new CapaLogica.DOC.Log_INFORME();
                result = exeInf.RegInsertarDatosTrozaCampo(lstEspecie, asCodUCuenta);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }
        public static ListResult DatosMaderaAserrada(HttpRequestBase _request, string asCodInforme, Int32 aiNumPoa, string asCodUCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                List<CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA> lstEspecie = new List<CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA>();

                HttpPostedFileBase file = _request.Files[0];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA oCampos;

                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            oCampos = new CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA();
                            oCampos.COD_INFORME = asCodInforme;
                            oCampos.NUM_POA = aiNumPoa;
                            oCampos.COD_SECUENCIAL = 0;
                            oCampos.CODIGO = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                            oCampos.COD_ESPECIES = "";
                            oCampos.ESPECIES = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim() + " | " + (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim();
                            oCampos.PIEZAS = Convert.ToInt32(workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                            oCampos.ZONA = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                            if (oCampos.ZONA != "17S" && oCampos.ZONA != "18S" && oCampos.ZONA != "19S")
                            {
                                oCampos.ZONA = "";
                            }
                            oCampos.COORDENADA_ESTE = Convert.ToInt32(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                            oCampos.COORDENADA_NORTE = Convert.ToInt32(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                            oCampos.ESPESOR = Convert.ToDecimal(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                            oCampos.ANCHO = Convert.ToDecimal(workSheet.Cells[rowIterator, 9].Value.ToString().Trim());
                            oCampos.LARGO = Convert.ToDecimal(workSheet.Cells[rowIterator, 10].Value.ToString().Trim());
                            oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 11].Value ?? "").ToString().Trim();
                            oCampos.RegEstado = 1;
                            lstEspecie.Add(oCampos);
                        }
                    }
                }

                //Grabar en la BD
                CapaLogica.DOC.Log_INFORME exeInf = new CapaLogica.DOC.Log_INFORME();
                result = exeInf.RegInsertarDatosMaderaAserrada(lstEspecie, asCodUCuenta);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }
        public static ListResult DatosCarrizoCampo(HttpRequestBase _request, string asCodInforme, Int32 aiNumPoa, string asCodUCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                List<CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO> lstEspecie = new List<CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO>();

                HttpPostedFileBase file = _request.Files[0];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO oCampos;

                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            oCampos = new CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO();
                            oCampos.COD_INFORME = asCodInforme;
                            oCampos.NUM_POA = aiNumPoa;
                            //oCampos.COD_MUESTRA_SUPERVISION = "";
                            oCampos.COD_ESPECIES = "";
                            oCampos.ESPECIES = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim() + " | " + (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim();
                            oCampos.TOTAL_UNIDAD_MUEST = Convert.ToInt32(workSheet.Cells[rowIterator, 3].Value.ToString().Trim());
                            oCampos.TOTAL_UNIDADES_APROV = Convert.ToInt32(workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                            oCampos.ZONA = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                            if (oCampos.ZONA != "17S" && oCampos.ZONA != "18S" && oCampos.ZONA != "19S")
                            {
                                oCampos.ZONA = "";
                            }
                            oCampos.COORDENADA_ESTE = Convert.ToInt32(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                            oCampos.COORDENADA_NORTE = Convert.ToInt32(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                            oCampos.PRODUCTO_EXTRAER = (workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim();
                            if (oCampos.PRODUCTO_EXTRAER != "hojas" && oCampos.PRODUCTO_EXTRAER != "cañas" && oCampos.PRODUCTO_EXTRAER != "tallos" && oCampos.PRODUCTO_EXTRAER != "corteza" && oCampos.PRODUCTO_EXTRAER != "raiz" && oCampos.PRODUCTO_EXTRAER != "musgos" && oCampos.PRODUCTO_EXTRAER != "otros")
                            {
                                oCampos.PRODUCTO_EXTRAER = "";
                            }
                            //oCampos.ALTURA_PROMEDIO = Convert.ToDecimal(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                            oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 9].Value ?? "").ToString().Trim();
                            oCampos.RegEstado = 1;
                            lstEspecie.Add(oCampos);
                        }
                    }
                }

                //Grabar en la BD
                CapaLogica.DOC.Log_INFORME exeInf = new CapaLogica.DOC.Log_INFORME();
                result = exeInf.RegInsertarDatosCarrizoCampo(lstEspecie, asCodUCuenta);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }
        public static ListResult DatosPlantaMedicinal(HttpRequestBase _request, string asCodInforme, Int32 aiNumPoa, string asCodUCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                List<CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO> lstEspecie = new List<CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO>();

                HttpPostedFileBase file = _request.Files[0];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO oCampos;

                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            oCampos = new CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO();
                            oCampos.COD_INFORME = asCodInforme;
                            oCampos.NUM_POA = aiNumPoa;
                            //oCampos.COD_MUESTRA_SUPERVISION = "";
                            oCampos.COD_ESPECIES = "";
                            oCampos.ESPECIES = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim() + " | " + (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                            oCampos.UNIDAD_MEDIDA = workSheet.Cells[rowIterator, 5].Value.ToString().Trim();
                            oCampos.NUM_INDIVIDUOS = Convert.ToInt32(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                            oCampos.ZONA = (workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim();
                            if (oCampos.ZONA != "17S" && oCampos.ZONA != "18S" && oCampos.ZONA != "19S")
                            {
                                oCampos.ZONA = "";
                            }
                            oCampos.COORDENADA_ESTE = Convert.ToInt32(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                            oCampos.COORDENADA_NORTE = Convert.ToInt32(workSheet.Cells[rowIterator, 9].Value.ToString().Trim());
                            oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 10].Value ?? "").ToString().Trim();
                            oCampos.RegEstado = 1;
                            lstEspecie.Add(oCampos);
                        }
                    }
                }

                //Grabar en la BD
                CapaLogica.DOC.Log_INFORME exeInf = new CapaLogica.DOC.Log_INFORME();
                result = exeInf.RegInsertarDatosCarrizoCampo(lstEspecie, asCodUCuenta);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }
        public static ListResult DatosVerticeVerificado(HttpRequestBase _request, string asCodInforme, Int32 aiNumPoa, string asCodUCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                List<CapaEntidad.DOC.Ent_INFORME_VERTICE_VERIFICADO> lstVertice = new List<CapaEntidad.DOC.Ent_INFORME_VERTICE_VERIFICADO>();

                HttpPostedFileBase file = _request.Files[0];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        CapaEntidad.DOC.Ent_INFORME_VERTICE_VERIFICADO oCampos;

                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            oCampos = new CapaEntidad.DOC.Ent_INFORME_VERTICE_VERIFICADO();
                            oCampos.COD_INFORME = asCodInforme;
                            oCampos.NUM_POA = aiNumPoa;
                            oCampos.COD_INFORME_VERTICE = "";
                            oCampos.VERTICE = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                            oCampos.VERTICE_CAMPO = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim();
                            oCampos.ZONA = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim();
                            if (oCampos.ZONA != "17S" && oCampos.ZONA != "18S" && oCampos.ZONA != "19S")
                            {
                                oCampos.ZONA = "";
                            }
                            oCampos.ZONA_CAMPO = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                            if (oCampos.ZONA_CAMPO != "17S" && oCampos.ZONA_CAMPO != "18S" && oCampos.ZONA_CAMPO != "19S")
                            {
                                oCampos.ZONA_CAMPO = "";
                            }
                            oCampos.COORDENADA_ESTE = Convert.ToInt32(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                            oCampos.COORDENADA_ESTE_CAMPO = Convert.ToInt32(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                            oCampos.COORDENADA_NORTE = Convert.ToInt32(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                            oCampos.COORDENADA_NORTE_CAMPO = Convert.ToInt32(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                            oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 9].Value ?? "").ToString().Trim();
                            oCampos.RegEstado = 1;
                            lstVertice.Add(oCampos);
                        }
                    }
                }

                //Grabar en la BD
                CapaLogica.DOC.Log_INFORME exeInf = new CapaLogica.DOC.Log_INFORME();
                result = exeInf.RegInsertarDatosVerticeVerificado(lstVertice, asCodUCuenta);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        public static List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> AreaExSitu(HttpRequestBase _request, string asCodArea)
        {
            List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> lstArea = new List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA oCampos;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA();
                        oCampos.ListISupervision_exsitu_recinto_equipo = new List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA>();
                        oCampos.COD_AREA = asCodArea;
                        oCampos.NUMERO = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                        oCampos.LARGO = Convert.ToDecimal(workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                        oCampos.ANCHO = Convert.ToDecimal(workSheet.Cells[rowIterator, 3].Value.ToString().Trim());
                        oCampos.ALTURA = Convert.ToDecimal(workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                        oCampos.AREA = Convert.ToDecimal(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                        oCampos.COD_SECUENCIAL = 0;
                        oCampos.RegEstado = 1;

                        CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA oCampoDet;
                        for (int i = 6; i <= 21; i++)
                        {
                            if ((workSheet.Cells[rowIterator, i].Value ?? "").ToString().Trim() != "")
                            {
                                oCampoDet = new CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA();
                                oCampoDet.COD_TDESCRIPTIVA = "";
                                oCampoDet.COD_AREA = asCodArea;
                                oCampoDet.DESCRIPCION = (workSheet.Cells[rowIterator, i].Value ?? "").ToString().Trim();
                                //IM/IC/IE  
                                if (i >= 6 && i <= 10) { oCampoDet.TIPO = "IM"; }
                                if (i >= 11 && i <= 13) { oCampoDet.TIPO = "IC"; }
                                if (i >= 14 && i <= 21) { oCampoDet.TIPO = "IE"; }
                                oCampoDet.COD_SECUENCIAL = 0;
                                oCampoDet.RegEstado = 1;
                                oCampos.ListISupervision_exsitu_recinto_equipo.Add(oCampoDet);
                            }
                        }
                        lstArea.Add(oCampos);
                    }
                }
            }
            return lstArea;
        }
        public static List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> NacimientoEspecie(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> lstNacimiento = new List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA oCampos;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        if ((workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim() == "NACIMIENTO")
                        {
                            oCampos = new CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA();
                            oCampos.COD_SECUENCIAL = 0;
                            oCampos.COD_ESPECIES = "";
                            oCampos.NOMBRE_COMUN = String.Format("{0} | {1}", (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim(), (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim());
                            oCampos.COD_SEXO = "";
                            oCampos.SEXO = (workSheet.Cells[rowIterator, 15].Value ?? "").ToString().Trim();
                            oCampos.NUMERO = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                            oCampos.FECHA_PUBLICACION = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                            oCampos.DESCRIPCION = (workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim();
                            oCampos.OBJETIVO = (workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim();
                            oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 9].Value ?? "").ToString().Trim();
                            oCampos.RegEstado = 1;
                            lstNacimiento.Add(oCampos);
                        }
                    }
                }
            }
            return lstNacimiento;
        }
        public static List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> EgresoEspecie(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> lstEgreso = new List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA oCampos;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        if (Convert.ToInt32((workSheet.Cells[rowIterator, 10].Value ?? "0").ToString().Trim()) > 0)
                        {
                            oCampos = new CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA();
                            oCampos.COD_SECUENCIAL = 0;
                            oCampos.COD_ESPECIES = "";
                            oCampos.NOMBRE_COMUN = String.Format("{0} | {1}", (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim(), (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim());
                            oCampos.COD_SEXO = "";
                            oCampos.SEXO = (workSheet.Cells[rowIterator, 15].Value ?? "").ToString().Trim();


                            oCampos.NUMERO = (workSheet.Cells[rowIterator, 10].Value ?? "").ToString().Trim();
                            oCampos.FECHA_PUBLICACION = (workSheet.Cells[rowIterator, 11].Value ?? "").ToString().Trim();
                            oCampos.DOCUMENTO = (workSheet.Cells[rowIterator, 12].Value ?? "").ToString().Trim();
                            oCampos.COD_MOTIVO = "";
                            oCampos.MOTIVO = (workSheet.Cells[rowIterator, 13].Value ?? "").ToString().Trim();
                            if (oCampos.MOTIVO == "MUERTE")
                            {
                                oCampos.NECROPSIA = (workSheet.Cells[rowIterator, 17].Value ?? "").ToString().Trim();
                                oCampos.DIAGNOSTICO = (workSheet.Cells[rowIterator, 18].Value ?? "").ToString().Trim();
                            }
                            else
                            {
                                oCampos.NECROPSIA = "";
                                oCampos.DIAGNOSTICO = "";
                            }
                            oCampos.EDAD = (workSheet.Cells[rowIterator, 14].Value ?? "").ToString().Trim();
                            oCampos.CODIGO_NOMBRE = (workSheet.Cells[rowIterator, 16].Value ?? "").ToString().Trim();
                            oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 19].Value ?? "").ToString().Trim();
                            oCampos.RegEstado = 1;
                            lstEgreso.Add(oCampos);
                        }
                    }
                }
            }
            return lstEgreso;
        }
        public static List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> EspecieVertebrado(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> lstVert = new List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA oCampos;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA();
                        oCampos.COD_SECUENCIAL = 0;
                        oCampos.TIPO_VERTEBRADO = "MA";
                        oCampos.COD_ESPECIES = "";
                        oCampos.DESCRIPCION = String.Format("{0} | {1}", (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim(), (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim());
                        oCampos.PROCEDENCIA_COD_TDESCRIPTIVA = "";
                        oCampos.DESC_PROCEDENCIA = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim();
                        oCampos.PROCEDENCIA_NUM_INDIVIDUOS = Convert.ToInt32((workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim());
                        oCampos.TIDENTI_COD_TDESCRIPTIVA = "";
                        oCampos.DESC_TIDENTIFICACION = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                        oCampos.CODIGO_NOMBRE = (workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim();
                        oCampos.COD_SEXO = "";
                        oCampos.SEXO = (workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim();
                        oCampos.COD_ACATEGORIA = "";
                        oCampos.DESC_ACATEGORIA = (workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim();
                        oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 9].Value ?? "").ToString().Trim();
                        oCampos.RegEstado = 1;
                        lstVert.Add(oCampos);
                    }
                }
            }
            return lstVert;
        }
        public static List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> EspecieInvertebrado(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> lstInvert = new List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA oCampos;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA();
                        oCampos.COD_SECUENCIAL = 0;
                        oCampos.TIPO_VERTEBRADO = "MI";
                        oCampos.COD_ESPECIES = "";
                        oCampos.DESCRIPCION = String.Format("{0} | {1}", (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim(), (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim());
                        oCampos.PROCEDENCIA_COD_TDESCRIPTIVA = "";
                        oCampos.DESC_PROCEDENCIA = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim();
                        oCampos.PROCEDENCIA_NUM_INDIVIDUOS = Convert.ToInt32((workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim());
                        oCampos.COD_ACATEGORIA = "";
                        oCampos.DESC_ACATEGORIA = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                        oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim();
                        oCampos.RegEstado = 1;
                        lstInvert.Add(oCampos);
                    }
                }
            }
            return lstInvert;
        }
        public static List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> BalanceIngEgr(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> lstBalance = new List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA oCampos;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        if ((workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim() != "")
                        {
                            oCampos = new CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA();
                            oCampos.COD_BALANCE = "";
                            oCampos.COD_ESPECIES = "";
                            oCampos.NOMBRE_COMUN = String.Format("{0} | {1}", (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim(), (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim());
                            oCampos.CENSO_INICIAL = Convert.ToInt32((workSheet.Cells[rowIterator, 3].Value ?? "0").ToString().Trim());
                            oCampos.CANT_INGRESO = Convert.ToInt32((workSheet.Cells[rowIterator, 4].Value ?? "0").ToString().Trim());
                            oCampos.FECHA_INGRESO = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                            oCampos.DOCUMENTO_INGRESO = (workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim();
                            oCampos.MOTIVO_INGRESO = (workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim();
                            oCampos.OBSERV_INGRESO = (workSheet.Cells[rowIterator, 9].Value ?? "").ToString().Trim();
                            oCampos.CANT_EGRESO = Convert.ToInt32((workSheet.Cells[rowIterator, 10].Value ?? "0").ToString().Trim());
                            oCampos.FECHA_EGRESO = (workSheet.Cells[rowIterator, 11].Value ?? "").ToString().Trim();
                            oCampos.DOCUMENTO_EGRESO = (workSheet.Cells[rowIterator, 12].Value ?? "").ToString().Trim();
                            oCampos.MOTIVO_EGRESO = (workSheet.Cells[rowIterator, 13].Value ?? "").ToString().Trim();
                            oCampos.OBSERV_EGRESO = (workSheet.Cells[rowIterator, 19].Value ?? "").ToString().Trim();
                            oCampos.BALANCE_PREVIO = Convert.ToInt32((workSheet.Cells[rowIterator, 20].Value ?? "0").ToString().Trim());
                            oCampos.CENSO_FINAL = Convert.ToInt32((workSheet.Cells[rowIterator, 21].Value ?? "0").ToString().Trim());
                            oCampos.RegEstado = 1;
                            lstBalance.Add(oCampos);
                        }
                    }
                }
            }
            return lstBalance;
        }

        public static List<CapaEntidad.DOC.Ent_INFORME_TCENSO> CensoTara(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME_TCENSO> lstCenso = new List<CapaEntidad.DOC.Ent_INFORME_TCENSO>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_INFORME_TCENSO oCampos;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CapaEntidad.DOC.Ent_INFORME_TCENSO();
                        oCampos.COD_SECUENCIAL = 0;
                        oCampos.PREDIO_AREA = Decimal.Parse((workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim());
                        oCampos.CODIGO_ARBOL = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim();
                        oCampos.DESCRIPCION = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim();
                        switch (oCampos.DESCRIPCION.ToUpper())
                        {
                            case "VAINAS VERDES": oCampos.VAINAS_COD_PRESENCIA = 1; break;
                            case "VAINAS MADUROS": oCampos.VAINAS_COD_PRESENCIA = 2; break;
                            case "VAINAS VERDES Y MADURAS": oCampos.VAINAS_COD_PRESENCIA = 3; break;
                            case "SIN PRESENCIA DE VAINAS": oCampos.VAINAS_COD_PRESENCIA = 4; break;
                        }
                        oCampos.PRES_FLORES_TEXT = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                        oCampos.PRES_FLORES = oCampos.PRES_FLORES_TEXT == "SI" ? true : false;
                        oCampos.PRES_PLAGA_ENFERMEDA = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                        oCampos.PRES_PLANTA_PARASITARIA = (workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim();
                        oCampos.ZONA = (workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim();
                        oCampos.COORDENADA_ESTE = Convert.ToInt32((workSheet.Cells[rowIterator, 9].Value ?? "").ToString().Trim());
                        oCampos.COORDENADA_NORTE = Convert.ToInt32((workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim());
                        oCampos.ALTURA_TOTAL = Convert.ToDecimal((workSheet.Cells[rowIterator, 10].Value ?? "").ToString().Trim());
                        oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 11].Value ?? "").ToString().Trim();
                        oCampos.RegEstado = 1;
                        lstCenso.Add(oCampos);
                    }
                }
            }
            return lstCenso;
        }
        public static List<CapaEntidad.DOC.Ent_INFORME> KardexTara(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME> lstKardex = new List<CapaEntidad.DOC.Ent_INFORME>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_INFORME oCampos;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CapaEntidad.DOC.Ent_INFORME();
                        oCampos.COD_SECUENCIAL = 0;
                        oCampos.N_GUIA_TRANSPORTE = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                        oCampos.FECHA_EMISION = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim();
                        oCampos.ZAFRA = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim();
                        oCampos.CANTIDAD_AQUINTAL = Convert.ToInt32((workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim());
                        oCampos.TOTAL_SQUINTAL = Convert.ToInt32((workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim());
                        oCampos.SALDO_QUINTAL = Convert.ToInt32((workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim());
                        oCampos.SALDO_MTRES = Convert.ToInt32((workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim());
                        oCampos.DESTINO_COD_UBIGEO = "";
                        oCampos.UBIGEO = String.Format("{0} - {1} - {2}", (workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim(), (workSheet.Cells[rowIterator, 9].Value ?? "").ToString().Trim().Replace("_", "").Trim(), (workSheet.Cells[rowIterator, 10].Value ?? "").ToString().Trim().Replace("_", "").Trim());
                        oCampos.RegEstado = 1;
                        lstKardex.Add(oCampos);
                    }
                }
            }
            return lstKardex;
        }

        public static List<CapaEntidad.DOC.Ent_INFORME> DesplazamientoSupervision(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME> lstDesplaza = new List<CapaEntidad.DOC.Ent_INFORME>();

            HttpPostedFileBase file = _request.Files[0];
            if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
            {
                using (var package = new ExcelPackage(file.InputStream))
                {
                    var currentSheet = package.Workbook.Worksheets;
                    var workSheet = currentSheet.First();
                    var noOfCol = workSheet.Dimension.End.Column;
                    var noOfRow = workSheet.Dimension.End.Row;
                    CapaEntidad.DOC.Ent_INFORME oCampos;
                    string ceste, cnorte;

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CapaEntidad.DOC.Ent_INFORME();
                        oCampos.COD_SECUENCIAL = 0;
                        oCampos.COD_DESPLAZAMIENTO = "0";
                        oCampos.ZONA = workSheet.Cells[rowIterator, 1].Value.ToString().Trim();
                        if (oCampos.ZONA == "17S" || oCampos.ZONA == "18S" || oCampos.ZONA == "19S")
                        {
                            ceste = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim();
                            cnorte = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim();
                            if (ceste != "" && cnorte != "")
                            {
                                oCampos.COORDENADA_ESTE = Convert.ToInt32(ceste);
                                oCampos.COORDENADA_NORTE = Convert.ToInt32(cnorte);
                                oCampos.ZONA_CAMPO = workSheet.Cells[rowIterator, 4].Value.ToString().Trim();
                                if (oCampos.ZONA_CAMPO == "17S" || oCampos.ZONA_CAMPO == "18S" || oCampos.ZONA_CAMPO == "19S")
                                {
                                    ceste = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                                    cnorte = (workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim();
                                    if (ceste != "" && cnorte != "")
                                    {
                                        oCampos.COORDENADA_ESTE_CAMPO = Convert.ToInt32(ceste);
                                        oCampos.COORDENADA_NORTE_CAMPO = Convert.ToInt32(cnorte);
                                        oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim();
                                        oCampos.TipoVia = (workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim();
                                        oCampos.RegEstado = 1;
                                        lstDesplaza.Add(oCampos);
                                    }
                                    else { throw new Exception("Coordenada Punto Final incorrecta"); }
                                }
                                else { throw new Exception("Zona UTM Punto Final Incorrecta"); }
                            }
                            else { throw new Exception("Coordenada Punto Inicial incorrecta"); }
                        }
                        else { throw new Exception("Zona UTM Punto Inicial Incorrecta"); }
                    }
                }
            }

            return lstDesplaza;
        }
    }
}