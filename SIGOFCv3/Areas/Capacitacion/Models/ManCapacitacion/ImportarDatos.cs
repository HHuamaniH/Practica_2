using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CEntidad = CapaEntidad.DOC.Ent_CAPACITACION;

namespace SIGOFCv3.Areas.Capacitacion.Models.ManCapacitacion
{
    public class ImportarDatos
    {
        public static List<CEntidad> Participante_Asistentes(HttpRequestBase _request)
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

                    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                    {
                        oCampos = new CEntidad();
                        oCampos.COD_PERSONA = "COD_EXCEL";
                        oCampos.APE_PATERNO = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim().ToUpper();
                        oCampos.APE_MATERNO = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim().ToUpper();
                        oCampos.NOMBRES = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim().ToUpper();
                        oCampos.APELLIDOS_NOMBRES = oCampos.APE_PATERNO + " " + oCampos.APE_MATERNO + " " + oCampos.NOMBRES;
                        oCampos.N_DOCUMENTO = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                        oCampos.COD_INSTITUCION = "";
                        oCampos.NOM_INSTITUCION = "";
                        oCampos.MAE_COD_GRUPOPUBLICOPARTICIPANTE = "";
                        oCampos.GRUPOPUBLICOPARTICIPANTE = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                        oCampos.MAE_COD_PUBLICOPARTICIPANTE = "";
                        oCampos.PUBLICOPARTICIPANTE = (workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim();
                        oCampos.CARGO = (workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim();
                        oCampos.GENERO = (workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim();
                        oCampos.EDAD = Int32.Parse((workSheet.Cells[rowIterator, 9].Value ?? "0").ToString().Trim());
                        oCampos.CCNN = (workSheet.Cells[rowIterator, 10].Value ?? "").ToString().Trim();
                        oCampos.ETNIA = (workSheet.Cells[rowIterator, 11].Value ?? "").ToString().Trim();
                        oCampos.TELEFONO = (workSheet.Cells[rowIterator, 12].Value ?? "").ToString().Trim();
                        oCampos.CORREO = (workSheet.Cells[rowIterator, 13].Value ?? "").ToString().Trim();
                        oCampos.COD_CONSTANCIA = (workSheet.Cells[rowIterator, 14].Value ?? "").ToString().Trim();
                        oCampos.MOCHILAFORESTAL = (workSheet.Cells[rowIterator, 15].Value ?? "").ToString().Trim();
                        oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 16].Value ?? "").ToString().Trim();
                        oCampos.NUM_THABILITANTE = (workSheet.Cells[rowIterator, 17].Value ?? "").ToString().Trim();
                        oCampos.RegEstado = 1;

                        if (oCampos.N_DOCUMENTO == "" || oCampos.N_DOCUMENTO.Length < 8 || oCampos.N_DOCUMENTO.Length > 8)
                        {
                            msjError = "El número de documento (DNI) de " + oCampos.APELLIDOS_NOMBRES + " es inválido";
                            throw new Exception(msjError);
                        }

                        olResult.Add(oCampos);
                    }
                }
            }

            return olResult;
        }

        public static List<CEntidad> Participante_EquipoApoyo(HttpRequestBase _request)
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
                        oCampos.COD_PERSONA = "COD_EXCEL";
                        oCampos.APE_PATERNO = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim().ToUpper();
                        oCampos.APE_MATERNO = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim().ToUpper();
                        oCampos.NOMBRES = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim().ToUpper();
                        oCampos.APELLIDOS_NOMBRES = oCampos.APE_PATERNO + " " + oCampos.APE_MATERNO + " " + oCampos.NOMBRES;
                        oCampos.N_DOCUMENTO = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                        oCampos.COD_INSTITUCION = "";
                        oCampos.NOM_INSTITUCION = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                        oCampos.CARGO = (workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim();
                        oCampos.FUNCION = (workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim();
                        oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim();
                        oCampos.RegEstado = 1;
                        olResult.Add(oCampos);
                    }
                }
            }

            return olResult;
        }

        public static List<CEntidad> Participante_Ponentes(HttpRequestBase _request)
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
                        oCampos.COD_PERSONA = "COD_EXCEL";
                        oCampos.APE_PATERNO = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim().ToUpper();
                        oCampos.APE_MATERNO = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim().ToUpper();
                        oCampos.NOMBRES = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim().ToUpper();
                        oCampos.APELLIDOS_NOMBRES = oCampos.APE_PATERNO + " " + oCampos.APE_MATERNO + " " + oCampos.NOMBRES;
                        oCampos.N_DOCUMENTO = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                        oCampos.COD_INSTITUCION = "";
                        oCampos.NOM_INSTITUCION = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                        oCampos.CARGO = (workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim();
                        oCampos.FUNCION = (workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim();
                        oCampos.COD_CONSTANCIA = (workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim();
                        oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 9].Value ?? "").ToString().Trim();
                        oCampos.RegEstado = 1;
                        olResult.Add(oCampos);
                    }
                }
            }

            return olResult;
        }

        //Importar encuestas, evaluación inicial y final
        public static List<CEntidad> Evaluacion_Encuestas(HttpRequestBase _request)
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
                        oCampos.DES_PREGUNTA = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim().ToUpper();
                        oCampos.N_CHECK_BUENO = Int32.Parse((workSheet.Cells[rowIterator, 2].Value ?? "0").ToString().Trim());
                        oCampos.N_CHECK_REGULAR = Int32.Parse((workSheet.Cells[rowIterator, 3].Value ?? "0").ToString().Trim());
                        oCampos.N_CHECK_MALO = Int32.Parse((workSheet.Cells[rowIterator, 4].Value ?? "0").ToString().Trim());
                        oCampos.N_NO_CHECK = Int32.Parse((workSheet.Cells[rowIterator, 5].Value ?? "0").ToString().Trim());

                        oCampos.N_PARTICIPANTES = oCampos.N_CHECK_BUENO + oCampos.N_CHECK_REGULAR + oCampos.N_CHECK_MALO + oCampos.N_NO_CHECK;
                        oCampos.P_CHECK_BUENO = (decimal)(oCampos.N_CHECK_BUENO * 100) / (oCampos.N_PARTICIPANTES == 0 ? 1 : oCampos.N_PARTICIPANTES);
                        oCampos.P_CHECK_REGULAR = (decimal)(oCampos.N_CHECK_REGULAR * 100) / (oCampos.N_PARTICIPANTES == 0 ? 1 : oCampos.N_PARTICIPANTES);
                        oCampos.P_CHECK_MALO = (decimal)(oCampos.N_CHECK_MALO * 100) / (oCampos.N_PARTICIPANTES == 0 ? 1 : oCampos.N_PARTICIPANTES);
                        oCampos.P_NO_CHECK = (decimal)(oCampos.N_NO_CHECK * 100) / (oCampos.N_PARTICIPANTES == 0 ? 1 : oCampos.N_PARTICIPANTES);

                        oCampos.P_CHECK_BUENO = Math.Round(oCampos.P_CHECK_BUENO, 2);
                        oCampos.P_CHECK_REGULAR = Math.Round(oCampos.P_CHECK_REGULAR, 2);
                        oCampos.P_CHECK_MALO = Math.Round(oCampos.P_CHECK_MALO, 2);
                        oCampos.P_NO_CHECK = Math.Round(oCampos.P_NO_CHECK, 2);

                        olResult.Add(oCampos);
                    }
                }
            }

            return olResult;
        }

        public static List<CEntidad> Evaluacion_Examenes(HttpRequestBase _request)
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
                        oCampos.APE_PATERNO = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim().ToUpper();
                        oCampos.APE_MATERNO = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim().ToUpper();
                        oCampos.NOMBRES = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim().ToUpper();
                        oCampos.APELLIDOS_NOMBRES = oCampos.APE_PATERNO + " " + oCampos.APE_MATERNO + " " + oCampos.NOMBRES;
                        oCampos.N_DOCUMENTO = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                        oCampos.NOTA_EXA_INICIO = Decimal.Parse((workSheet.Cells[rowIterator, 5].Value ?? "0").ToString().Trim());
                        oCampos.NOTA_EXA_FIN = Decimal.Parse((workSheet.Cells[rowIterator, 6].Value ?? "0").ToString().Trim());

                        olResult.Add(oCampos);
                    }
                }
            }

            return olResult;
        }
        public static List<CEntidad> Programacion(HttpRequestBase _request)
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
                        oCampos.FECHA_PROGRAMA = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim().ToUpper().Substring(0, 10);
                        oCampos.HORA = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim().ToUpper();
                        oCampos.TEMA = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim().ToUpper();
                        oCampos.RESPONSABLE = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                        oCampos.RegEstado = 1;
                        oCampos.COD_SECUENCIAL = 0;
                        olResult.Add(oCampos);
                    }
                }
            }

            return olResult;
        }
        public static List<CEntidad> Cronograma(HttpRequestBase _request)
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
                        oCampos.ACTIVIDAD = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim().ToUpper();
                        oCampos.FECHA_INICIO_CRONOGRAMA = (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim().ToUpper().Substring(0, 10);
                        oCampos.FECHA_FIN_CRONOGRAMA = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim().ToUpper().Substring(0, 10);
                        oCampos.RESPONSABLE = (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();
                        oCampos.RegEstado = 1;
                        oCampos.COD_SECUENCIAL = 0;
                        olResult.Add(oCampos);
                    }
                }
            }

            return olResult;
        }
    }
}