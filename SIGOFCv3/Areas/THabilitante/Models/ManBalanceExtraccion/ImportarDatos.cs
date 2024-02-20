using CapaEntidad.DOC;
using CapaLogica.DOC;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SIGOFCv3.Areas.THabilitante.Models.ManBalanceExtraccion
{
    public class ImportarDatos
    {
        public static List<Ent_BEXTRACCION_MADE> BExtraccionMaderable(HttpRequestBase _request, string asCodTHabilitante, int aiNumPoa, int aiCodSecuencialBExt,
            string asCodMTipo, string asEstadoOrigen, string asIndicador)
        {
            List<Ent_BEXTRACCION_MADE> lstMaderable = new List<Ent_BEXTRACCION_MADE>();

            try
            {
                HttpPostedFileBase file = _request.Files[0];

                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    if (file.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        using (var package = new ExcelPackage(file.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            Ent_BEXTRACCION_MADE oCampos;
                            Log_PLAN_MANEJO objLog;
                            bool isAdd;
                            string codEspecie;
                            string codEspecieSerfor;
                            //string error = "";

                            //string[] lst_estado_origen_1 = { "ADECU", "REFOR", "REAJU", "PMFI", "PN", "DEMA" };
                            string[] lst_estado_origen_2 = { "R", "MS", "PC" };

                            if (asCodMTipo == "0000021")
                            {
                                for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                {
                                    oCampos = new Ent_BEXTRACCION_MADE();
                                    objLog = new Log_PLAN_MANEJO();
                                    isAdd = true;

                                    codEspecie = objLog.GetCodEspecie(
                                        workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(),
                                        workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim()
                                    );

                                    if (codEspecie != null && codEspecie.Trim() != "")
                                    {
                                        oCampos.COD_THABILITANTE = asCodTHabilitante;
                                        oCampos.NUM_POA = aiNumPoa;
                                        oCampos.COD_SECUENCIAL_BEXT = aiCodSecuencialBExt;
                                        oCampos.COD_SECUENCIAL = 0;
                                        oCampos.COD_ESPECIES = codEspecie;
                                        oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                        oCampos.TIPOMADERABLE = workSheet.Cells[rowIterator, 5].Value == null ? "" : workSheet.Cells[rowIterator, 5].Value.ToString().Trim();
                                        oCampos.SALDO = workSheet.Cells[rowIterator, 12].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 12].Value.ToString().Trim());
                                        oCampos.OBSERVACION = workSheet.Cells[rowIterator, 13].Value == null ? "" : workSheet.Cells[rowIterator, 13].Value.ToString().Trim();
                                        oCampos.RegEstado = 1;

                                        if (oCampos.TIPOMADERABLE.Equals("MADERABLES") || oCampos.TIPOMADERABLE.Equals("CARBON"))
                                        {
                                            oCampos.DMC = workSheet.Cells[rowIterator, 6].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                            oCampos.TOTAL_ARBOLES = workSheet.Cells[rowIterator, 7].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                                            oCampos.VOLUMEN_AUTORIZADO = workSheet.Cells[rowIterator, 8].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                                            oCampos.VOLUMEN_MOVILIZADO = workSheet.Cells[rowIterator, 9].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 9].Value.ToString().Trim());

                                            if (oCampos.TIPOMADERABLE.Equals("MADERABLES")) oCampos.UNIDAD_MEDIDA = "M3";
                                            else oCampos.UNIDAD_MEDIDA = "KG";

                                            //Para que valores numéricos no vayan con -1
                                            oCampos.AUTORIZADO = 0;
                                            oCampos.EXTRAIDO = 0;
                                        }
                                        else if (oCampos.TIPOMADERABLE.Equals("NO MADERABLES"))
                                        {
                                            oCampos.AUTORIZADO = workSheet.Cells[rowIterator, 10].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 10].Value.ToString().Trim());
                                            oCampos.EXTRAIDO = workSheet.Cells[rowIterator, 11].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 11].Value.ToString().Trim());
                                            oCampos.UNIDAD_MEDIDA = "KG";
                                            //Para que valores numéricos no vayan con -1
                                            oCampos.DMC = 0;
                                            oCampos.TOTAL_ARBOLES = 0;
                                            oCampos.VOLUMEN_AUTORIZADO = 0;
                                            oCampos.VOLUMEN_MOVILIZADO = 0;
                                        }

                                        if (!(workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim()).Equals(""))
                                        {
                                            codEspecieSerfor = objLog.GetCodEspecie(
                                                workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(),
                                                workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim()
                                            );

                                            if (codEspecieSerfor != null && codEspecieSerfor != "")
                                            {
                                                oCampos.COD_ESPECIES_SERFOR = codEspecieSerfor;
                                                oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                            }
                                            else isAdd = false;
                                        }

                                        if (isAdd) lstMaderable.Add(oCampos);
                                    }
                                }
                            }
                            else if (asCodMTipo == "0000020")
                            {
                                for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                {
                                    oCampos = new Ent_BEXTRACCION_MADE();
                                    objLog = new Log_PLAN_MANEJO();
                                    isAdd = true;

                                    codEspecie = objLog.GetCodEspecie(
                                        workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(),
                                        workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim()
                                    );

                                    if (codEspecie != null && codEspecie.Trim() != "")
                                    {
                                        oCampos.COD_THABILITANTE = asCodTHabilitante;
                                        oCampos.NUM_POA = aiNumPoa;
                                        oCampos.COD_SECUENCIAL_BEXT = aiCodSecuencialBExt;
                                        oCampos.COD_SECUENCIAL = 0;
                                        oCampos.COD_ESPECIES = codEspecie;
                                        oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                        oCampos.TIPOMADERABLE = workSheet.Cells[rowIterator, 5].Value == null ? "" : workSheet.Cells[rowIterator, 5].Value.ToString().Trim();
                                        oCampos.SALDO = workSheet.Cells[rowIterator, 14].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 14].Value.ToString().Trim());
                                        oCampos.OBSERVACION = workSheet.Cells[rowIterator, 16].Value == null ? "" : workSheet.Cells[rowIterator, 16].Value.ToString().Trim();
                                        oCampos.RegEstado = 1;

                                        if (oCampos.TIPOMADERABLE.Equals("MADERABLES") || oCampos.TIPOMADERABLE.Equals("CARBON"))
                                        {
                                            oCampos.DMC = workSheet.Cells[rowIterator, 6].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                            oCampos.TOTAL_ARBOLES = workSheet.Cells[rowIterator, 7].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());
                                            oCampos.VOLUMEN_AUTORIZADO = workSheet.Cells[rowIterator, 8].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                                            oCampos.VOLUMEN_MOVILIZADO = workSheet.Cells[rowIterator, 9].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 9].Value.ToString().Trim());

                                            if (oCampos.TIPOMADERABLE.Equals("MADERABLES")) oCampos.UNIDAD_MEDIDA = "M3";
                                            else oCampos.UNIDAD_MEDIDA = "KG";

                                            //Para que valores numéricos no vayan con -1
                                            oCampos.CANTIDAD = 0;

                                        }
                                        else if (oCampos.TIPOMADERABLE.Equals("NO MADERABLES"))
                                        {
                                            oCampos.FECHA1 = workSheet.Cells[rowIterator, 10].Value == null ? "" : workSheet.Cells[rowIterator, 10].Value.ToString().Trim();
                                            oCampos.GUIA_TRANSPORTE = workSheet.Cells[rowIterator, 11].Value == null ? "" : workSheet.Cells[rowIterator, 11].Value.ToString().Trim();
                                            oCampos.FECHA2 = workSheet.Cells[rowIterator, 12].Value == null ? "" : workSheet.Cells[rowIterator, 12].Value.ToString().Trim();
                                            oCampos.RECIBO = workSheet.Cells[rowIterator, 13].Value == null ? "" : workSheet.Cells[rowIterator, 13].Value.ToString().Trim();
                                            oCampos.CANTIDAD = workSheet.Cells[rowIterator, 15].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 15].Value.ToString().Trim());
                                            oCampos.UNIDAD_MEDIDA = "KG";

                                            //Para que valores numéricos no vayan con -1
                                            oCampos.DMC = 0;
                                            oCampos.TOTAL_ARBOLES = 0;
                                            oCampos.VOLUMEN_AUTORIZADO = 0;
                                            oCampos.VOLUMEN_MOVILIZADO = 0;
                                        }

                                        if (!(workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim()).Equals(""))
                                        {
                                            codEspecieSerfor = objLog.GetCodEspecie(
                                                workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(),
                                                workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim()
                                            );

                                            if (codEspecieSerfor != null && codEspecieSerfor != "")
                                            {
                                                oCampos.COD_ESPECIES_SERFOR = codEspecieSerfor;
                                                oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                            }
                                            else isAdd = false;
                                        }

                                        if (isAdd) lstMaderable.Add(oCampos);
                                    }
                                }
                            }
                            else
                            {
                                decimal volumen_kilogramos = decimal.Parse("9999999.999");
                                string valor = "";
                                int numero = 0;
                                for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                {
                                    oCampos = new Ent_BEXTRACCION_MADE();
                                    objLog = new Log_PLAN_MANEJO();
                                    isAdd = true;

                                    codEspecie = objLog.GetCodEspecie(
                                        workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(),
                                        workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim()
                                    );

                                    if (codEspecie != null && codEspecie.Trim() != "")
                                    {
                                        oCampos.COD_THABILITANTE = asCodTHabilitante;
                                        oCampos.NUM_POA = aiNumPoa;
                                        oCampos.COD_SECUENCIAL_BEXT = aiCodSecuencialBExt;
                                        oCampos.COD_SECUENCIAL = 0;
                                        oCampos.COD_ESPECIES = codEspecie;
                                        oCampos.ESPECIES = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 1].Value == null ? "" : workSheet.Cells[rowIterator, 1].Value.ToString().Trim(), workSheet.Cells[rowIterator, 2].Value == null ? "" : workSheet.Cells[rowIterator, 2].Value.ToString().Trim());
                                        
                                        oCampos.TIPOMADERABLE = workSheet.Cells[rowIterator, 5].Value == null ? "" : workSheet.Cells[rowIterator, 5].Value.ToString().Trim();
                                        if (string.IsNullOrEmpty(oCampos.TIPOMADERABLE)) throw new Exception("Debe ingresar el Tipo de aprovechamiento.");

                                        if (workSheet.Cells[rowIterator, 6].Value != null)
                                        {
                                            valor = workSheet.Cells[rowIterator, 6].Value.ToString().Trim();
                                            if (valor.Length > 6) throw new Exception("El DMC no puede exceder los 6 caracteres.");
                                            if (!int.TryParse(valor, out numero)) throw new Exception("El DMC debe ser un valor numérico.");
                                        }
                                        oCampos.DMC = workSheet.Cells[rowIterator, 6].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());

                                        if (workSheet.Cells[rowIterator, 7].Value != null)
                                        {
                                            valor = workSheet.Cells[rowIterator, 7].Value.ToString().Trim();
                                            if (valor.Length > 6) throw new Exception("El número total no puede exceder los 6 caracteres.");
                                            if (!int.TryParse(valor, out numero)) throw new Exception("El número total debe ser un valor numérico.");
                                        }
                                        oCampos.TOTAL_ARBOLES = workSheet.Cells[rowIterator, 7].Value == null ? 0 : Int32.Parse(workSheet.Cells[rowIterator, 7].Value.ToString().Trim());

                                        if (workSheet.Cells[rowIterator, 8].Value != null)
                                        {
                                            valor = workSheet.Cells[rowIterator, 8].Value.ToString().Trim();
                                            if (!Regex.IsMatch(valor, @"^\d+(\.\d{1,3})?$")) throw new Exception("La cantidad autorizada debe ser un valor numérico y no puede exceder los 3 decimales.");
                                        }
                                        oCampos.VOLUMEN_AUTORIZADO = workSheet.Cells[rowIterator, 8].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 8].Value.ToString().Trim());
                                        if (oCampos.VOLUMEN_AUTORIZADO > volumen_kilogramos) throw new Exception("La cantidad autorizada no puede exceder los 7 dígitos.");

                                        if (workSheet.Cells[rowIterator, 9].Value != null)
                                        {
                                            valor = workSheet.Cells[rowIterator, 9].Value.ToString().Trim();
                                            if (!Regex.IsMatch(valor, @"^\d+(\.\d{1,3})?$")) throw new Exception("La cantidad movilizada debe ser un valor numérico y no puede exceder los 3 decimales.");
                                        }
                                        oCampos.VOLUMEN_MOVILIZADO = workSheet.Cells[rowIterator, 9].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 9].Value.ToString().Trim());
                                        if (oCampos.VOLUMEN_MOVILIZADO > volumen_kilogramos) throw new Exception("La cantidad movilizada no puede exceder los 7 dígitos.");

                                        if (workSheet.Cells[rowIterator, 10].Value != null)
                                        {
                                            valor = workSheet.Cells[rowIterator, 10].Value.ToString().Trim();
                                            if (!Regex.IsMatch(valor, @"^\d+(\.\d{1,3})?$")) throw new Exception("La cantidad movilizada debe ser un valor numérico y no puede exceder los 3 decimales.");
                                        }
                                        oCampos.SALDO = workSheet.Cells[rowIterator, 10].Value == null ? 0 : Decimal.Parse(workSheet.Cells[rowIterator, 10].Value.ToString().Trim());
                                        if (oCampos.SALDO > volumen_kilogramos) throw new Exception("La cantidad movilizada no puede exceder los 7 dígitos.");

                                        oCampos.UNIDAD_MEDIDA = workSheet.Cells[rowIterator, 11].Value == null ? "" : workSheet.Cells[rowIterator, 11].Value.ToString().Trim();
                                        if (string.IsNullOrEmpty(oCampos.UNIDAD_MEDIDA)) throw new Exception("Debe ingresar la Unidad de Medida.");

                                        oCampos.PC = workSheet.Cells[rowIterator, 12].Value == null ? "" : workSheet.Cells[rowIterator, 12].Value.ToString().Trim();
                                        if (string.IsNullOrEmpty(oCampos.PC)) throw new Exception("Debe ingresar la PC.");
                                        
                                        switch (oCampos.TIPOMADERABLE)
                                        {
                                            case "CARBON":
                                                if (oCampos.UNIDAD_MEDIDA != "KG") throw new Exception("Para el Tipo CARBON solo se permite el ingreso de Unidad de Medida KG.");
                                                break;
                                            case "NO MADERABLES":
                                                if (oCampos.UNIDAD_MEDIDA == "M3") throw new Exception("Para el Tipo NO MADERABLES solo se permite el ingreso de Unidad de Medida KG y LT.");
                                                break;
                                            case "MADERABLES":
                                                if (oCampos.UNIDAD_MEDIDA == "LT") throw new Exception("Para el Tipo MADERABLES solo se permite el ingreso de Unidad de Medida M3 y KG.");
                                                break;
                                        }

                                        oCampos.OBSERVACION = workSheet.Cells[rowIterator, 13].Value == null ? "" : workSheet.Cells[rowIterator, 13].Value.ToString().Trim();
                                        if (oCampos.OBSERVACION.Length > 100) throw new Exception("El campo Observación no debe exceder los 100 caracteres.");
                                        else if (!Regex.IsMatch(oCampos.OBSERVACION, @"^[ ÁÉÍÓÚA-Záéíóúa-z0-9\-\/\.\,]+$") && oCampos.OBSERVACION != "") throw new Exception("El campo Observación no debe contener caracteres especiales.");

                                        oCampos.RegEstado = 1;


                                        if (!(workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim()).Equals(""))
                                        {
                                            codEspecieSerfor = objLog.GetCodEspecie(
                                                workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(),
                                                workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim()
                                            );

                                            if (codEspecieSerfor != null && codEspecieSerfor != "")
                                            {
                                                oCampos.COD_ESPECIES_SERFOR = codEspecieSerfor;
                                                oCampos.ESPECIES_SERFOR = String.Format("{0} | {1}", workSheet.Cells[rowIterator, 3].Value == null ? "" : workSheet.Cells[rowIterator, 3].Value.ToString().Trim(), workSheet.Cells[rowIterator, 4].Value == null ? "" : workSheet.Cells[rowIterator, 4].Value.ToString().Trim());
                                            }
                                            else
                                            {
                                                throw new Exception("Ingresar una Especie Serfor válida y/o validar el registro en la opción Gestión de Especies.");
                                            }
                                        }
                                        lstMaderable.Add(oCampos);
                                    }
                                    else
                                    {
                                        throw new Exception("Ingresar una Especie válida y/o validar el registro en la opción Gestión de Especies.");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Archivo ingresado no valido, utilizar la plantilla desde la opción de descarga.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstMaderable;
        }

        public static List<Ent_BEXTRACCION_NOMADE> BExtraccionNoMaderable(HttpRequestBase _request, string asCodTHabilitante, int aiNumPoa, int aiCodSecuencialBExt, string asCodMTipo)
        {
            List<Ent_BEXTRACCION_NOMADE> lstNoMaderable = new List<Ent_BEXTRACCION_NOMADE>();

            try
            {
                HttpPostedFileBase file = _request.Files[0];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        Ent_BEXTRACCION_NOMADE oCampos;
                        string error = "";

                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            oCampos = new Ent_BEXTRACCION_NOMADE();
                            oCampos.COD_THABILITANTE = asCodTHabilitante;
                            oCampos.NUM_POA = aiNumPoa;
                            oCampos.COD_SECUENCIAL_BEXT = aiCodSecuencialBExt;
                            oCampos.COD_SECUENCIAL = 0;
                            oCampos.RegEstado = 1;

                            oCampos.COD_ESPECIES = "";
                            oCampos.ESPECIES = (workSheet.Cells[rowIterator, 1].Value ?? "").ToString().Trim() + " | " + (workSheet.Cells[rowIterator, 2].Value ?? "").ToString().Trim();
                            error += oCampos.ESPECIES.Trim() == "|" ? " Fila (" + (rowIterator - 1) + "): [NOMBRE_CIENTIFICO, NOMBRE_COMUN] Seleccione la especie" : "";
                            oCampos.COD_ESPECIES_SERFOR = "";
                            oCampos.ESPECIES_SERFOR = (workSheet.Cells[rowIterator, 3].Value ?? "").ToString().Trim() + " | " + (workSheet.Cells[rowIterator, 4].Value ?? "").ToString().Trim();

                            if (asCodMTipo == "0000021")
                            { //Planta medicinal
                                oCampos.AUTORIZADO = Convert.ToInt32((workSheet.Cells[rowIterator, 5].Value ?? "0").ToString().Trim());
                                error += oCampos.AUTORIZADO < 0 ? " Fila (" + (rowIterator - 1) + "): [CANT_AUTORIZADA] Ingrese un valor mayor igual a cero" : "";
                                oCampos.EXTRAIDO = Convert.ToInt32((workSheet.Cells[rowIterator, 6].Value ?? "0").ToString().Trim());
                                error += oCampos.EXTRAIDO < 0 ? " Fila (" + (rowIterator - 1) + "): [CANT_MOVILIZADA] Ingrese un valor mayor igual a cero" : "";
                                oCampos.SALDO = Convert.ToDecimal((workSheet.Cells[rowIterator, 7].Value ?? "0").ToString().Trim());
                                //error += oCampos.SALDO < 0 ? " Fila (" + (rowIterator - 1) + "): [SALDO] Ingrese un valor mayor igual a cero" : "";
                                oCampos.UNIDAD_MEDIDA = (workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim();
                                oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 9].Value ?? "").ToString().Trim();
                            }
                            else if (asCodMTipo == "0000020")
                            { //Carrizo
                                oCampos.FECHA1 = (workSheet.Cells[rowIterator, 5].Value ?? "").ToString().Trim();
                                oCampos.GUIA_TRANSPORTE = (workSheet.Cells[rowIterator, 6].Value ?? "").ToString().Trim();
                                oCampos.FECHA2 = (workSheet.Cells[rowIterator, 7].Value ?? "").ToString().Trim();
                                oCampos.RECIBO = (workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim();
                                oCampos.SALDO = Convert.ToDecimal((workSheet.Cells[rowIterator, 9].Value ?? "0").ToString().Trim());
                                //error += oCampos.SALDO < 0 ? " Fila (" + (rowIterator - 1) + "): [SALDO] Ingrese un valor mayor igual a cero" : "";
                                oCampos.CANTIDAD = Convert.ToInt32((workSheet.Cells[rowIterator, 10].Value ?? "0").ToString().Trim());
                                error += oCampos.CANTIDAD < 0 ? " Fila (" + (rowIterator - 1) + "): [CANTIDAD] Ingrese un valor mayor igual a cero" : "";
                                oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 11].Value ?? "").ToString().Trim();
                            }
                            else
                            { //Normal
                                oCampos.KILOGRAMO_AUTORIZADO = Convert.ToDecimal((workSheet.Cells[rowIterator, 5].Value ?? "0").ToString().Trim());
                                error += oCampos.KILOGRAMO_AUTORIZADO < 0 ? " Fila (" + (rowIterator - 1) + "): [KILOGRAMO_AUTORIZADO] Ingrese un valor mayor igual a cero" : "";
                                oCampos.KILOGRAMO_MOVILIZADO = Convert.ToDecimal((workSheet.Cells[rowIterator, 6].Value ?? "0").ToString().Trim());
                                error += oCampos.KILOGRAMO_MOVILIZADO < 0 ? " Fila (" + (rowIterator - 1) + "): [KILOGRAMO_MOVILIZADO] Ingrese un valor mayor igual a cero" : "";
                                oCampos.SALDO = Convert.ToDecimal((workSheet.Cells[rowIterator, 7].Value ?? "0").ToString().Trim());
                                //error += oCampos.SALDO < 0 ? " Fila (" + (rowIterator - 1) + "): [SALDO] Ingrese un valor mayor igual a cero" : "";
                                oCampos.OBSERVACION = (workSheet.Cells[rowIterator, 8].Value ?? "").ToString().Trim();
                            }

                            lstNoMaderable.Add(oCampos);
                        }

                        if (error != "") throw new Exception(error);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstNoMaderable;
        }
    }
}