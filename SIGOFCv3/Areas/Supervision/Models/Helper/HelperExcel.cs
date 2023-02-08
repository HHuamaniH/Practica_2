using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SIGOFCv3.Areas.Supervision.Models.Helper
{
    public class HelperExcel
    {
        public void _texto_sin_borde(ExcelWorksheet _sheet, String _range, String _text, System.Drawing.Color _Backcolor, System.Drawing.Color _fontColor, string fontName = "Arial")
        {
            _sheet.Cells[_range].Value = _text;
            _sheet.Cells[_range].Style.Fill.PatternType = ExcelFillStyle.Solid;
            _sheet.Cells[_range].Style.Fill.BackgroundColor.SetColor(_Backcolor);
            _sheet.Cells[_range].Style.Font.Color.SetColor(_fontColor);
            _sheet.Cells[_range].Style.Font.Bold = true;
            _sheet.Cells[_range].Merge = true;
            _sheet.Cells[_range].Style.Font.Name = fontName;
            _sheet.Cells[_range].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            _sheet.Cells[_range].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        }

        public int pintarcabeceras(List<string> _cabecera, ExcelWorksheet _Sheet, string header)
        {
            int finish = -1;
            foreach (var x in _cabecera)
            {
                finish++;
                string letra = convertNumberToLetter(finish);
                setHeader(_Sheet, letra + "3:" + letra + "3", x, false);
            }
            _texto_sin_borde_Titulo(_Sheet, convertNumberToLetter(0) + "1:" + convertNumberToLetter(finish) + "1", header, Color.White, Color.Black, "Calibri");
            return finish;
        }

        public void _texto_sin_borde_Titulo(ExcelWorksheet _sheet, String _range, String _text, System.Drawing.Color _Backcolor, System.Drawing.Color _fontColor, string fontName = "Calibri")
        {
            _sheet.Cells[_range].Value = _text;
            _sheet.Cells[_range].Style.Fill.PatternType = ExcelFillStyle.Solid;
            _sheet.Cells[_range].Style.Fill.BackgroundColor.SetColor(_Backcolor);
            _sheet.Cells[_range].Style.Font.Color.SetColor(_fontColor);
            _sheet.Cells[_range].Style.Font.Bold = true;
            _sheet.Cells[_range].Merge = true;
            _sheet.Cells[_range].Style.WrapText = true;
            _sheet.Cells[_range].Style.Font.Size = 14;
            _sheet.Cells[_range].Style.Font.Name = fontName;
            _sheet.Cells[_range].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            _sheet.Cells[_range].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        }

        public void _texto_con_borde(ExcelWorksheet _sheet, string _range, string _text, string fontName = "Calibri")
        {
            _sheet.Cells[_range].Value = _text;
            _sheet.Cells[_range].Merge = true;
            _sheet.Cells[_range].Style.Font.Name = fontName;
            _sheet.Cells[_range].Style.Font.Size = 12;
            _sheet.Cells[_range].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            _sheet.Cells[_range].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[_range].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[_range].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[_range].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        }

        public void _texto_row(ExcelWorksheet _sheet, int rowIndex, int col, object _text, string fontName = "Calibri")
        {
            _sheet.Cells[rowIndex, col].Value = _text;
            _sheet.Cells[rowIndex, col].Merge = true;
            _sheet.Cells[rowIndex, col].Style.Font.Name = fontName;
            _sheet.Cells[rowIndex, col].Style.Font.Size = 12;
            _sheet.Cells[rowIndex, col].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            _sheet.Cells[rowIndex, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[rowIndex, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[rowIndex, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[rowIndex, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        }

        public void _texto_row_center(ExcelWorksheet _sheet, int rowIndex, int col, object _text, string fontName = "Calibri")
        {
            _sheet.Cells[rowIndex, col].Value = _text;
            _sheet.Cells[rowIndex, col].Merge = true;
            _sheet.Cells[rowIndex, col].Style.Font.Name = fontName;
            _sheet.Cells[rowIndex, col].Style.Font.Size = 12;
            _sheet.Cells[rowIndex, col].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            _sheet.Cells[rowIndex, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            _sheet.Cells[rowIndex, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[rowIndex, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[rowIndex, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[rowIndex, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        }

        public void _texto_row_Left(ExcelWorksheet _sheet, int rowIndex, int col, object _text, string fontName = "Calibri")
        {
            _sheet.Cells[rowIndex, col].Value = _text;
            _sheet.Cells[rowIndex, col].Merge = true;
            _sheet.Cells[rowIndex, col].Style.Font.Name = fontName;
            _sheet.Cells[rowIndex, col].Style.Font.Size = 12;
            _sheet.Cells[rowIndex, col].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            _sheet.Cells[rowIndex, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[rowIndex, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[rowIndex, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[rowIndex, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        }

        public void _texto_row_Money(ExcelWorksheet _sheet, int rowIndex, int col, object _text, string fontName = "Calibri")
        {
            _sheet.Cells[rowIndex, col].Value = _text;
            _sheet.Cells[rowIndex, col].Merge = true;
            _sheet.Cells[rowIndex, col].Style.Font.Name = fontName;
            _sheet.Cells[rowIndex, col].Style.Font.Size = 12;
            _sheet.Cells[rowIndex, col].Style.Numberformat.Format = "_ * #,##0_ ;_ * -#,##0_ ;_ * \" - \"??_ ;_ @_ ";
            _sheet.Cells[rowIndex, col].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            _sheet.Cells[rowIndex, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            _sheet.Cells[rowIndex, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[rowIndex, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[rowIndex, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[rowIndex, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        }

        public void _texto_row_Percentage(ExcelWorksheet _sheet, int rowIndex, int col, object _text, string fontName = "Calibri")
        {
            _sheet.Cells[rowIndex, col].Value = Convert.ToDecimal(_text) / 100;
            _sheet.Cells[rowIndex, col].Merge = true;
            _sheet.Cells[rowIndex, col].Style.Font.Name = fontName;
            _sheet.Cells[rowIndex, col].Style.Font.Size = 12;
            _sheet.Cells[rowIndex, col].Style.Numberformat.Format = "0.00%";
            _sheet.Cells[rowIndex, col].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            _sheet.Cells[rowIndex, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            _sheet.Cells[rowIndex, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[rowIndex, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[rowIndex, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[rowIndex, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        }

        public void setHeader(ExcelWorksheet _sheet, string celda, string texto, Boolean mergue)
        {
            _sheet.Cells[celda].Value = texto;
            _sheet.Cells[celda].Style.Font.Name = "Calibri";
            _sheet.Cells[celda].Style.Font.Size = 12;
            _sheet.Cells[celda].Style.Font.Bold = true;
            _sheet.Cells[celda].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            _sheet.Cells[celda].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            _sheet.Cells[celda].Merge = mergue;
            _sheet.Cells[celda].Style.WrapText = true;
            _sheet.Cells[celda].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[celda].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[celda].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[celda].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[celda].Style.Fill.PatternType = ExcelFillStyle.Solid;
            _sheet.Cells[celda].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 192, 0));
        }

        public string convertNumberToLetter(int index)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var value = "";
            if (index >= letters.Length)
                value += letters[index / letters.Length - 1];
            value += letters[index % letters.Length];
            return value;
        }

        public int ValidateNumber(int num1, int num2)
        {
            if (num2 < num1) return num1;
            if (num2 >= num1) return num2;
            return 0;
        }

        public void _texto_row_coloreado(ExcelWorksheet _sheet, int rowIndex, int col, object _text, string fontName = "Calibri")
        {
            _sheet.Cells[rowIndex, col].Value = _text;
            _sheet.Cells[rowIndex, col].Merge = true;
            _sheet.Cells[rowIndex, col].Style.Font.Name = fontName;
            _sheet.Cells[rowIndex, col].Style.Font.Size = 12;
            _sheet.Cells[rowIndex, col].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            _sheet.Cells[rowIndex, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            _sheet.Cells[rowIndex, col].Style.WrapText = true;
            _sheet.Cells[rowIndex, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[rowIndex, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[rowIndex, col].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            _sheet.Cells[rowIndex, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            _sheet.Row(rowIndex).Height = 40;
            _sheet.Cells[rowIndex, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
            _sheet.Cells[rowIndex, col].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(228, 135, 123));

        }

    }
}