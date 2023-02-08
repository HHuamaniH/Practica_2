using iTextSharp.text;
using iTextSharp.text.pdf;
using Oracle.ManagedDataAccess.Client;
using System;
//using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_Reporte_AntecedentesTitular;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_AntecedentesTitular;

namespace CapaLogica.DOC
{
    public class Log_Reporte_AntecedentesTitular
    {
        private CDatos oCDatos = new CDatos();

        public CEntidad RegMostrarReporte(CEntidad oCEntidad)
        {
            try
            {
                //CEntidad oReporte = new CEntidad();

                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    //oReporte = oCDatos.RegMostrarReporte(cn, oCEntidad);
                    return oCDatos.RegMostrarReporte(cn, oCEntidad);
                }

                ////Solo mostrar los PAU Concluido - Firme o Agotado Vía Administrativa
                //List<CEntidad> olTh = new List<CEntidad>();
                //CEntidad oTh;
                //string codigo = "";
                //foreach (CEntidad item in oReporte.ListAntecedentes)
                //{
                //    codigo = item.ESTADO_PAU.Substring(0, 3);
                //    if (codigo=="001" || codigo=="002")
                //    {
                //        oTh = new CEntidad();
                //        oTh.COD_THABILITANTE = item.COD_THABILITANTE;
                //        oTh.NUM_THABILITANTE = item.NUM_THABILITANTE;
                //        oTh.MODALIDAD = item.MODALIDAD;
                //        oTh.INFRACCION = item.INFRACCION;
                //        oTh.SANCION = item.SANCION;
                //        oTh.MULTA = item.MULTA;
                //        oTh.RESOLUCION = item.RESOLUCION;
                //        oTh.ESTADO_PAU = item.ESTADO_PAU.Substring(4, item.ESTADO_PAU.Length - 4);
                //        oTh.FECHA_NOTIFICACION = item.FECHA_NOTIFICACION;
                //        oTh.NUMRESOLUCIONFORESTAL = item.NUMRESOLUCIONFORESTAL;
                //        oTh.FECRESOLUCIONFORESTAL = item.FECRESOLUCIONFORESTAL;

                //        olTh.Add(oTh);
                //    }
                //}

                ////Retorno
                //CEntidad oRetReporte = new CEntidad();
                //oRetReporte.DESCRIPCION = oReporte.DESCRIPCION;
                //oRetReporte.ListAntecedentes = olTh;

                //return oRetReporte;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PdfPCell celda(string Texto, int collspan, int rowspan, float tamaño, int alignment, int borde, BaseColor colorTexto, string colorCelda, string estilo)
        {
            PdfPCell CeldaPDF = null;
            //Creamos un Objeto de tipo PdfPCell
            if (estilo == "Normal")
            {
                CeldaPDF = new PdfPCell(new Paragraph(Texto, FontFactory.GetFont("Calibri", tamaño, Font.NORMAL, colorTexto)));
            }
            else if (estilo == "Negrita")
            {
                CeldaPDF = new PdfPCell(new Paragraph(Texto, FontFactory.GetFont("Calibri", tamaño, Font.BOLD, colorTexto)));
            }
            else if (estilo == "Cursiva")
            {
                CeldaPDF = new PdfPCell(new Paragraph(Texto, FontFactory.GetFont("Calibri", tamaño, Font.ITALIC, colorTexto)));
            }
            else
            {
                CeldaPDF = new PdfPCell(new Paragraph(Texto, FontFactory.GetFont("Calibri", tamaño, Font.NORMAL, colorTexto)));
            }

            //Este codigo es referente a las combinaciones de bordes deseados
            #region "borde"
            if (borde == 0)
            {
                CeldaPDF.Border = 0;
            }
            else
            {
                if (borde == 1) { CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER; }
                else
                {
                    if (borde == 2) { CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER; }
                    else
                    {
                        if (borde == 3) { CeldaPDF.Border = iTextSharp.text.Rectangle.LEFT_BORDER; }
                        else
                        {
                            if (borde == 4) { CeldaPDF.Border = iTextSharp.text.Rectangle.RIGHT_BORDER; }
                            else
                            {
                                if (borde == 5) { CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER; }
                                else
                                {
                                    if (borde == 6) { CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER; }
                                    else
                                    {
                                        if (borde == 7) { CeldaPDF.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER; }
                                        else
                                        {
                                            if (borde == 8) { CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.LEFT_BORDER; }
                                            else
                                            {
                                                if (borde == 9) { CeldaPDF.Border = iTextSharp.text.Rectangle.TOP_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER; }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            //Indicamos que queremos un color de fondo, el parametro enviado es un strign donde vendra nuestro color por default si no lo indican es blanco
            switch (colorCelda)
            {
                case "pink":
                    CeldaPDF.BackgroundColor = new BaseColor(255, 192, 203);
                    break;
                case "yellow":
                    CeldaPDF.BackgroundColor = new BaseColor(255, 255, 0);
                    break;
                case "lightgreen":
                    CeldaPDF.BackgroundColor = new BaseColor(144, 238, 144);
                    break;
                case "lightgray":
                    CeldaPDF.BackgroundColor = new BaseColor(211, 211, 211);
                    break;
                case "transparent":
                    break;
            }

            if (colorCelda != "transparent")
            {


            }
            //En caso de querer poner un collspan indicamos el numero de columnas que abarcara
            CeldaPDF.Colspan = collspan;
            //Lo mismo si es un rowspan, indicaremos el numero de filar que abarcara
            CeldaPDF.Rowspan = rowspan;
            //Indicamos la alineacion horizontal
            CeldaPDF.HorizontalAlignment = alignment;
            //Indicamos la alineacion vertical
            CeldaPDF.VerticalAlignment = alignment;
            //Regresamos nuestra celda ya formateada
            return CeldaPDF;
        }
    }
}
