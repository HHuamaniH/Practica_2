using CapaEntidad.ViewModel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SIGOFCv3.Areas.Supervision.Models.ManInforme
{
    public class ImportarDatos
    {
        public static List<CapaEntidad.DOC.Ent_INFORME> VerticeTHabilitanteCampo(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME> lstVertice = new List<CapaEntidad.DOC.Ent_INFORME>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        CapaEntidad.DOC.Ent_INFORME oCampos;
                        string ceste, cnorte, vertice;

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
                                    vertice = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim();
                                    if (vertice != "")
                                    {
                                        oCampos.VERTICE_CAMPO = vertice;
                                    }
                                    else { throw new Exception("Vertice Supervisado incorrecto"); }
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
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
            }

            return lstVertice;
        }

        public static List<CapaEntidad.DOC.Ent_INFORME> CoberturaBoscosa(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME> lstCobBoscosa = new List<CapaEntidad.DOC.Ent_INFORME>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
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
                            oCampos.ACTIVIDAD = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                            if (!string.IsNullOrEmpty(oCampos.ACTIVIDAD))
                            {
                                oCampos.AREA = Decimal.Parse((workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim());
                                oCampos.ZONA = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim();
                                if (oCampos.ZONA == "17S" || oCampos.ZONA == "18S" || oCampos.ZONA == "19S")
                                {
                                    oCampos.AUTORIZADO = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                                    if (!string.IsNullOrEmpty(oCampos.AUTORIZADO))
                                    {
                                        ceste = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                                        cnorte = (workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim();
                                        if (ceste != "" && cnorte != "")
                                        {
                                            oCampos.COD_SECUENCIAL = 0;
                                            if (!Regex.IsMatch(ceste, @"^\d+$")) { throw new Exception("Coordenada Este incorrecta debe ser numérico"); }
                                            else
                                            {
                                                int coord_esteInt = Convert.ToInt32(ceste);
                                                if (coord_esteInt > 999999) { throw new Exception("Coordenada Este incorrecta no debe ser mayor a 6 dígitos"); }
                                                else
                                                {
                                                    oCampos.COORDENADA_ESTE = Convert.ToInt32((workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim());
                                                    if (!Regex.IsMatch(cnorte, @"^\d+$")) { throw new Exception("Coordenada Norte incorrecta debe ser numérico"); }
                                                    else
                                                    {
                                                        int coord_norteInt = Convert.ToInt32(cnorte);
                                                        oCampos.COORDENADA_NORTE = Convert.ToInt32((workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim());
                                                        if (coord_norteInt > 9999999) { throw new Exception("Coordenada Norte incorrecta no debe ser mayor a 7 dígitos"); }
                                                    }
                                                }
                                            }
                                            oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim();
                                            oCampos.RegEstado = 1;
                                            lstCobBoscosa.Add(oCampos);
                                        }
                                        else { throw new Exception("Coordenada incorrecta"); }
                                    }
                                    else { throw new Exception("Autoridad incorrecta"); }
                                }
                                else { throw new Exception("Zona UTM incorrecta"); }
                            }
                            else { throw new Exception("Actividad incorrecta"); }

                        }
                    }
                }
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
            }
            return lstCobBoscosa;
        }

        public static List<CapaEntidad.DOC.Ent_INFORME_ESPECIE_FOREST> EspecieForestalEstablecida(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME_ESPECIE_FOREST> lstEspecieForEst = new List<CapaEntidad.DOC.Ent_INFORME_ESPECIE_FOREST>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        CapaEntidad.DOC.Ent_INFORME_ESPECIE_FOREST oCampos;
                        string ceste, cnorte, ncomun, ncientifico, msg, dap, ac;

                        for (int rowIterator = 3; rowIterator <= noOfRow; rowIterator++)
                        {
                            oCampos = new CapaEntidad.DOC.Ent_INFORME_ESPECIE_FOREST();
                            ncomun = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                            ncientifico = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim();
                            if (!string.IsNullOrEmpty(ncomun) && !string.IsNullOrEmpty(ncientifico))
                            {
                                oCampos.DESC_ESPECIES_REPLA = ncomun + " | " + ncientifico;
                                ncomun = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim() ;
                                ncientifico = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                                if (!string.IsNullOrEmpty(ncomun) && !string.IsNullOrEmpty(ncientifico))
                                {
                                    oCampos.DESC_ESPECIES_RESUP = ncomun + " | " + ncientifico;
                                    ceste = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                                    cnorte = (workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim();
                                    msg = ValidarCoordenadas(ceste, cnorte, "Registro de Plantación");
                                    if (msg == "")
                                    {
                                        oCampos.COORDENADA_ESTE_REPLA = Convert.ToInt32(ceste);
                                        oCampos.COORDENADA_NORTE_REPLA = Convert.ToInt32(cnorte);
                                        oCampos.COD_SECUENCIAL = 0;
                                        ceste = (workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim();
                                        cnorte = (workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim();
                                        msg = ValidarCoordenadas(ceste, cnorte, "Registro de Supervisión");

                                        if (msg == "")
                                        {
                                            oCampos.COORDENADA_ESTE_RESUP = Convert.ToInt32(ceste);
                                            oCampos.COORDENADA_NORTE_RESUP = Convert.ToInt32(cnorte);
                                            dap = (workSheet.Cells[rowIterator, 9].Value ?? "").ToString().Trim();
                                            msg = ValidarSevenDigitoThreeDecimal("DAP", dap, "Medidas Dasométricas");

                                            if (msg == "")
                                            {
                                                if (!string.IsNullOrEmpty(dap))
                                                {
                                                    oCampos.DAP = dap;
                                                }
                                                ac = (workSheet.Cells[rowIterator, 10].Value ?? "").ToString().Trim();
                                                msg = ValidarSevenDigitoThreeDecimal("AC", ac, "Medidas Dasométricas");
                                                if (msg == "")
                                                {
                                                    if (!string.IsNullOrEmpty(ac))
                                                    {
                                                        oCampos.AC = ac;
                                                    }
                                                }
                                                else { throw new Exception(msg); }
                                            }
                                            else { throw new Exception(msg); }
                                        }
                                        else { throw new Exception(msg); }
                                        oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 11].Value ?? "").ToString().Trim();
                                        if (!string.IsNullOrEmpty(oCampos.OBSERVACION))
                                        {
                                            if (!Regex.IsMatch(oCampos.OBSERVACION, @"^[ ÁÉÍÓÚA-Záéíóúa-z0-9\-\/\.\,]+$")) { throw new Exception("El campo observación no debe tener caracteres especiales."); }
                                            if (oCampos.OBSERVACION.Length > 200) { throw new Exception("El campo observación no debe exceder los 200 caracteres"); }
                                        }                                       
                                        oCampos.RegEstado = 1;
                                        lstEspecieForEst.Add(oCampos);
                                    }
                                    else { throw new Exception(msg); }
                                }
                                else { throw new Exception("Debe seleccionar Especie de Registro de Supervisión"); }
                            }
                            else { throw new Exception("Debe seleccionar Especie de Registro de Plantación"); }

                        }
                    }
                }
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
            }
            return lstEspecieForEst;
        }
        public static List<CapaEntidad.DOC.Ent_INFORME_COBERTURA_BOSNAT> CoberturaBosquesNaturales(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME_COBERTURA_BOSNAT> lstCoberturaBosNat = new List<CapaEntidad.DOC.Ent_INFORME_COBERTURA_BOSNAT>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        CapaEntidad.DOC.Ent_INFORME_COBERTURA_BOSNAT oCampos;
                        string ceste, cnorte, msg, tempDecimal, tempString;

                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            oCampos = new CapaEntidad.DOC.Ent_INFORME_COBERTURA_BOSNAT();
                            tempString = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                            if (!string.IsNullOrEmpty(tempString))
                            {
                                oCampos.AREA_COBERTURA = tempString;
                                tempDecimal = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim();
                                if (!string.IsNullOrEmpty(tempDecimal))
                                {
                                    msg = ValidarSevenDigitoThreeDecimal("Área", tempDecimal, "Cobertura de Bosques Naturales");
                                    if (msg == "")
                                    {
                                        oCampos.AREA = Convert.ToDecimal(tempDecimal);
                                        oCampos.COD_SECUENCIAL = 0;
                                        ceste = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim();
                                        cnorte = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                                        msg = ValidarCoordenadas(ceste, cnorte, "Cobertura de Bosques Naturales");

                                        if (msg == "")
                                        {
                                            oCampos.COORDENADA_ESTE = Convert.ToInt32(ceste);
                                            oCampos.COORDENADA_NORTE = Convert.ToInt32(cnorte);
                                            tempDecimal = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                                            msg = ValidarAltitud(tempDecimal, "Cobertura de Bosques Naturales");

                                            if (msg == "")
                                            {
                                                oCampos.ALTITUD = Convert.ToInt32(tempDecimal);
                                                oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim();
                                                if (!string.IsNullOrEmpty(oCampos.OBSERVACION))
                                                {
                                                    if (!Regex.IsMatch(oCampos.OBSERVACION, @"^[ ÁÉÍÓÚA-Záéíóúa-z0-9\-\/\.\,]+$")) { throw new Exception("El campo observación no debe tener caracteres especiales."); }
                                                    else if (oCampos.OBSERVACION.Length > 200) { throw new Exception("El campo Observación no debe exceder los 200 caracteres"); }
                                                }                                                    
                                            }
                                            else { throw new Exception(msg); }
                                        }
                                        else { throw new Exception(msg); }

                                        oCampos.RegEstado = 1;
                                        lstCoberturaBosNat.Add(oCampos);
                                    }
                                    else { throw new Exception(msg); }
                                }
                                else { throw new Exception("Debe ingresar el área (has)"); }
                            }
                            else { throw new Exception("Debe seleccionar Cobertura de Bosques Naturales"); }

                        }
                    }
                }
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
            }
            return lstCoberturaBosNat;
        }

        public static List<CapaEntidad.DOC.Ent_INFORME_DIVISION_PREDIO> DivisionPredio(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME_DIVISION_PREDIO> lstDivisionPredio = new List<CapaEntidad.DOC.Ent_INFORME_DIVISION_PREDIO>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        CapaEntidad.DOC.Ent_INFORME_DIVISION_PREDIO oCampos;
                        string ceste, cnorte, msg, tempDecimal, tempString;

                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            oCampos = new CapaEntidad.DOC.Ent_INFORME_DIVISION_PREDIO();
                            tempString = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim();
                            if (!string.IsNullOrEmpty(tempString))
                            {
                                if (tempString.Length > 200) { throw new Exception("La división interna no debe exceder los 200 caracteres"); }
                                else
                                {
                                    if (!Regex.IsMatch(tempString, @"^[ ÁÉÍÓÚA-Záéíóúa-z0-9\-\/\.\,]+$")) { throw new Exception("El campo división interna no debe contener caractere especiales."); }
                                    else
                                    {
                                        oCampos.DIVISION_INTERNA = tempString;
                                        oCampos.COD_SECUENCIAL = 0;
                                        ceste = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim();
                                        cnorte = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim();
                                        msg = ValidarCoordenadas(ceste, cnorte, "División de Predio");

                                        if (msg == "")
                                        {
                                            oCampos.COORDENADA_ESTE = (ceste);
                                            oCampos.COORDENADA_NORTE = (cnorte);
                                            tempDecimal = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                                            msg = ValidarAltitud(tempDecimal, "División de Predio");

                                            if (msg == "")
                                            {
                                                oCampos.ALTITUD = tempDecimal;
                                                oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                                                if (!string.IsNullOrEmpty(oCampos.OBSERVACION))
                                                {
                                                    if (!Regex.IsMatch(oCampos.OBSERVACION, @"^[ ÁÉÍÓÚA-Záéíóúa-z0-9\-\/\.\,]+$")) { throw new Exception("El campo observación no debe tener caracteres especiales."); }
                                                    else if (oCampos.OBSERVACION.Length > 400) { throw new Exception("El campo Observación no debe exceder los 400 caracteres"); }
                                                }
                                                oCampos.RegEstado = 1;
                                                lstDivisionPredio.Add(oCampos);
                                            }
                                            else { throw new Exception(msg); }
                                        }
                                        else { throw new Exception(msg); }
                                    }
                                }
                            }
                            else { throw new Exception("La división interna no debe ser vacía"); }

                        }
                    }
                }
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
            }
            return lstDivisionPredio;
        }
        public static List<CapaEntidad.DOC.Ent_INFORME> AvistamientoFauna(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME> lstAvistamiento = new List<CapaEntidad.DOC.Ent_INFORME>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
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
                            oCampos.DESC_ESPECIES = workSheet.Cells[rowIterator, 1].Value.ToString().Trim(); //+ " | " + workSheet.Cells[rowIterator, 2].Value.ToString().Trim();
                            oCampos.NOMBRE_COMUN = workSheet.Cells[rowIterator, 2].Value.ToString().Trim();
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
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
            }

            return lstAvistamiento;
        }
        public static List<CapaEntidad.DOC.Ent_INFORME> VerticeArea(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME> lstVertice = new List<CapaEntidad.DOC.Ent_INFORME>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
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
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
            }
            return lstVertice;
        }
        public static List<CapaEntidad.DOC.Ent_INFORME_EVAL_ARBOL> EvaluacionArbol(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME_EVAL_ARBOL> lstEvalArbol = new List<CapaEntidad.DOC.Ent_INFORME_EVAL_ARBOL>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
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
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
            }
            return lstEvalArbol;
        }
        public static List<CapaEntidad.DOC.Ent_INFORME_HUAYRONA> Huayrona(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME_HUAYRONA> lstHuayrona = new List<CapaEntidad.DOC.Ent_INFORME_HUAYRONA>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
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
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
            }
            return lstHuayrona;
        }
        public static List<CapaEntidad.DOC.Ent_INFORME_ACT_SILVICULTURAL> ActividadSilvicultural(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME_ACT_SILVICULTURAL> lstActividad = new List<CapaEntidad.DOC.Ent_INFORME_ACT_SILVICULTURAL>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
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
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
            }
            return lstActividad;
        }
        public static List<CapaEntidad.DOC.Ent_INFORME_EVAL_OTRO> EvaluacionOtro(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME_EVAL_OTRO> lstEval = new List<CapaEntidad.DOC.Ent_INFORME_EVAL_OTRO>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
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
                                    if (!Regex.IsMatch(ceste, @"^\d+$")) { throw new Exception("Coordenada Este incorrecta debe ser numérico"); }
                                    else
                                    {
                                        int coord_esteInt = Convert.ToInt32(ceste);
                                        if (coord_esteInt > 999999) { throw new Exception("Coordenada Este incorrecta no debe ser mayor a 6 dígitos"); }
                                        else
                                        {
                                            oCampos.COORDENADA_ESTE = Convert.ToInt32(workSheet.Cells[rowIterator, 3].Value.ToString().Trim());
                                            if (!Regex.IsMatch(cnorte, @"^\d+$")) { throw new Exception("Coordenada Norte incorrecta debe ser numérico"); }
                                            else
                                            {
                                                int coord_norteInt = Convert.ToInt32(cnorte);
                                                oCampos.COORDENADA_NORTE = Convert.ToInt32(workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                                if (coord_norteInt > 9999999) { throw new Exception("Coordenada Norte incorrecta no debe ser mayor a 7 dígitos"); }
                                            }
                                        }
                                    }
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
            }
            else { throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga."); }
            return lstEval;
        }
        public static List<CapaEntidad.DOC.Ent_INFORME_VOL_ANALIZADO> VolumenAnalizado(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME_VOL_ANALIZADO> lstVolAnaliza = new List<CapaEntidad.DOC.Ent_INFORME_VOL_ANALIZADO>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
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
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
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
                if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
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
                }
                else
                {
                    throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
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
                if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
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
                }
                else
                {
                    throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
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
                if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
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
                }
                else
                {
                    throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
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
                if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
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
                }
                else
                {
                    throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
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
                if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
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
                }
                else
                {
                    throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
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
                if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
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
                }
                else
                {
                    throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
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
                if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
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
                }
                else
                {
                    throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
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
                if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
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
                }
                else
                {
                    throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
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
                if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
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
                }
                else
                {
                    throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
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
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
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
                            oCampos.COORDENADA_ESTE = Convert.ToDecimal(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                            oCampos.COORDENADA_NORTE = Convert.ToDecimal(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                            oCampos.COD_SECUENCIAL = 0;
                            oCampos.RegEstado = 1;

                            CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA oCampoDet;
                            for (int i = 8; i <= 23; i++)
                            {
                                if ((workSheet.Cells[rowIterator, i].Value ?? "").ToString().Trim() != "")
                                {
                                    oCampoDet = new CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA();
                                    oCampoDet.COD_TDESCRIPTIVA = "";
                                    oCampoDet.COD_AREA = asCodArea;
                                    oCampoDet.DESCRIPCION = (workSheet.Cells[rowIterator, i].Value ?? "").ToString().Trim();
                                    //IM/IC/IE  
                                    if (i >= 8 && i <= 12) { oCampoDet.TIPO = "IM"; }
                                    if (i >= 13 && i <= 15) { oCampoDet.TIPO = "IC"; }
                                    if (i >= 16 && i <= 23) { oCampoDet.TIPO = "IE"; }
                                    oCampoDet.COD_SECUENCIAL = 0;
                                    oCampoDet.RegEstado = 1;
                                    oCampos.ListISupervision_exsitu_recinto_equipo.Add(oCampoDet);
                                }
                            }
                            lstArea.Add(oCampos);
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
            }
            return lstArea;
        }
        public static List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> NacimientoEspecie(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> lstNacimiento = new List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
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
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
            }
            return lstNacimiento;
        }
        public static List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> EgresoEspecie(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> lstEgreso = new List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
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
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
            }
            return lstEgreso;
        }
        public static List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> EspecieVertebrado(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> lstVert = new List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
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
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
            }
            return lstVert;
        }
        public static List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> EspecieInvertebrado(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> lstInvert = new List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
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
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
            }
            return lstInvert;
        }
        public static List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> BalanceIngEgr(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA> lstBalance = new List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
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
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
            }
            return lstBalance;
        }

        public static List<CapaEntidad.DOC.Ent_INFORME_TCENSO> CensoTara(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME_TCENSO> lstCenso = new List<CapaEntidad.DOC.Ent_INFORME_TCENSO>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
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
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
            }
            return lstCenso;
        }
        public static List<CapaEntidad.DOC.Ent_INFORME> KardexTara(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME> lstKardex = new List<CapaEntidad.DOC.Ent_INFORME>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
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
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
            }
            return lstKardex;
        }

        public static List<CapaEntidad.DOC.Ent_INFORME> DesplazamientoSupervision(HttpRequestBase _request)
        {
            List<CapaEntidad.DOC.Ent_INFORME> lstDesplaza = new List<CapaEntidad.DOC.Ent_INFORME>();

            HttpPostedFileBase file = _request.Files[0];
            if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
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
            }
            else
            {
                throw new Exception("Archivo cargado no válido, utilizar la plantilla desde la opción de descarga.");
            }
            return lstDesplaza;
        }

        public static string ValidarCoordenadas(string ceste, string cnorte, string descripción)
        {
            string returns = string.Empty;
            if (ceste != "")
            {
                if (cnorte != "")
                {
                    if (ceste.Length > 6) { returns = "Coordenada Este de " + descripción + " incorrecta no debe ser mayor a 6 dígitos"; }
                    else
                    {
                        if (!Regex.IsMatch(ceste, @"^\d+$")) { returns = "Coordenada Este de " + descripción + " incorrecta debe ser numérico sin decimales"; }
                        else
                        {
                            if (cnorte.Length > 7) { returns = "Coordenada Norte de " + descripción + " incorrecta no debe ser mayor a 7 dígitos"; }
                            else
                            {
                                int coord_esteInt = Convert.ToInt32(ceste);
                                if (!Regex.IsMatch(cnorte, @"^\d+$")) { returns = "Coordenada Norte de " + descripción + " incorrecta debe ser numérico sin decimales"; }
                                else
                                {
                                    int coord_norteInt = Convert.ToInt32(cnorte);
                                }

                            }
                        }
                    }
                }
                else { returns = "Coordenada Norte vacía de " + descripción; }
            }else { returns = "Coordenada Este vacía de " + descripción; }

            return returns;
        }
        public static string ValidarAltitud(string altidud, string descripción)
        {
            string returns = string.Empty;
            if (altidud != "")
            {
                if (altidud.Length > 4) { returns = "Altitud Este de " + descripción + " incorrecta no debe ser mayor a 4 dígitos"; }
                {
                    if (!Regex.IsMatch(altidud, @"^\d+$")) { returns = "Altitud de " + descripción + " incorrecta debe ser numérico"; }                    
                }
            }
            else { returns = "Altitud vacía de " + descripción; }

            return returns;
        }
        public static string ValidarSevenDigitoThreeDecimal(string campo, string valor, string descripción)
        {
            string returns = string.Empty;
            if (!string.IsNullOrEmpty(valor))
            {
                decimal resultado;
                if (decimal.TryParse(valor, out resultado))
                {
                    if (valor.Contains('.'))
                    {
                        if (valor.Length > 8) { returns = "Valor de la columna " + campo + " no puede ser mayor a 7 dígitos sin el punto decimal en " + descripción; }
                        else
                        {
                            if (!Regex.IsMatch(valor, @"^\d+(\.\d{1,3})?$")) { returns = "Valor de la columna " + campo + " no puede tener más de 3 decimales en " + descripción; }                            
                        }
                    }
                    else
                    {
                        if (valor.Length > 7) { returns = "Valor de la columna " + campo + " no puede ser mayor a 7 dígitos sin el punto decimal en " + descripción; }
                        else
                        {
                            if (!Regex.IsMatch(valor, @"^\d+(\.\d{1,3})?$")) { returns = "Valor de la columna " + campo + " no puede tener más de 3 decimales en " + descripción; }                            
                        }
                    }
                    
                }
                else { returns = "Valor no permitido (debe ser un número decimal) de la columna: " + campo + " en " + descripción; }
            }

            return returns;
        }
    }
}