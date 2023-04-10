using Herramienta;
using iTextSharp.text;
//librerias para exportar a pdf
using iTextSharp.text.pdf;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
//using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Services;
using CDatos = CapaDatos.DOC.Dat_Reporte_OBSERVATORIO;
//using CDatos = CapaDatos.DOC.Dat_Reporte_OBSERVATORIO_SIMULACION;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_OBSERVATORIO;
using oCLogicaFooter = CapaLogica.PDFFooter;
//using oCLogicaFooter = CapaLogica.PDFFooterSimulacion;
/// <summary>
/// 20/02/2020  EPB Se cambia la etiqueta del estado "PAU_SANCION_ARCHIVADO" de Pau Concluido a PAU Concluido - Firme y se modifica el bloque de calculo de las caducidad y medidas cautelares y precautorias para hacerlas genericas
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WSObservatorio : System.Web.Services.WebService
{

    List<CEntidad> ListadoIncisos = new List<CEntidad>();
    List<CEntidad> ListadoDesIncisos = new List<CEntidad>();
    Utilitarios HerUtil = new Utilitarios();
    private CDatos oCDatos = new CDatos();
    Document doc;
    float[] medCols;
    PdfPTable tableTituloBloque;
    int anioReferencia = 2020;
    public WSObservatorio()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="oCampoEntrada"></param>
    /// <returns></returns>
    private List<CEntidad> RegMostrarListadoInexistentes(CEntidad oCampoEntrada)
    {
        try
        {
            using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                return oCDatos.RegMostrarListadoInexistentes(cn, oCampoEntrada);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="oCampoEntrada"></param>
    /// <returns></returns>
    private List<CEntidad> RegMostrarListadoIncisos(CEntidad oCampoEntrada)
    {
        try
        {
            using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                return oCDatos.RegMostrarListadoIncisos(cn, oCampoEntrada);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="oCampoEntrada"></param>
    /// <returns></returns>
    private List<CEntidad> RegMostrarDesListadoIncisos(CEntidad oCampoEntrada)
    {
        try
        {
            using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                return oCDatos.RegMostrarDesListadoIncisos(cn, oCampoEntrada);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="oCampoEntrada"></param>
    /// <returns></returns>
    private List<CEntidad> RegMostrarListadoJustNoJust(CEntidad oCampoEntrada)
    {
        try
        {
            using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                return oCDatos.RegMostrarListadoJustNoJust(cn, oCampoEntrada);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="oCampoEntrada"></param>
    /// <returns></returns>
    private CEntidad RegMostrarListadoResoluciones(CEntidad oCampoEntrada)
    {
        try
        {
            using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                return oCDatos.RegMostrarListadoResoluciones(cn, oCampoEntrada);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="oCampoEntrada"></param>
    /// <returns></returns>
    private CEntidad RegMostrarElement(CEntidad oCampoEntrada)
    {
        try
        {
            using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                return oCDatos.RegMostrarElement(cn, oCampoEntrada);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    [WebMethod]
    public String escribirDetallePDFIndex(Int32 idRegistro, String mapPath, String varSession)
    {
        //pdf
        mapPath = Server.MapPath(mapPath);
        CEntidad elementoObs = new CEntidad();
        String Color = "";
        elementoObs.ID_REGISTRO = idRegistro;
        elementoObs.TIPO_REPORTE = "6";
        elementoObs = RegMostrarElement(elementoObs);
        switch (elementoObs.COLOR)
        {
            case "R": Color = "ROJO"; break;
            case "A": Color = "AMBAR"; break;
            case "V": Color = "VERDE"; break;
            case "N": Color = "NINGUNO"; break;
            case "NR": Color = "NINGUNO_ROJO"; break;
            case "NV": Color = "NINGUNO_VERDE"; break;
        }
        return escribirDetallePDF(elementoObs, Color, mapPath, varSession);
    }

    /// <summary>
    /// Procedimiento para crear el PDF resultado reporte de consulta al Observatorio
    /// </summary>
    /// <param name="elementListado">Objeto que contiene el reporte a generar</param>
    /// <param name="Color">Color de acuerdo al riesgo del caso</param>
    /// <param name="mapPath">ruta donde se almacenará el reporte</param>
    /// <param name="varSession">variable de sesión que identifica si se esta consultando desde el SIGO SFC o desde el Observatorio</param>
    /// <returns></returns>
    [WebMethod]
    public String escribirDetallePDF(CEntidad elementListado, String Color, String mapPath, String varSession)
    {
        String nombreArchivo;
        String colorHeader = "";
        //int tieneRDTer = 0;     
        String[] infracciones;

        PdfPTable tableTitulo;
        PdfPTable tableDatos;
        PdfPTable tableResol;
        PdfPTable tableIncisos;
        CEntidad EntResol;
        //float[] widths2;
        string fuenteResol = "";

        //int i = 0;
        try
        {
            switch (Color)
            {
                case "ROJO": colorHeader = "pink"; break;
                case "AMBAR": colorHeader = "yellow"; break;
                case "VERDE": colorHeader = "lightgreen"; break;
                case "NINGUNO": colorHeader = "lightgray"; break;
                case "NINGUNO_ROJO": colorHeader = "pink"; break;
                case "NINGUNO_VERDE": colorHeader = "lightgreen"; break;
            }
            doc = new Document(iTextSharp.text.PageSize.LETTER);
            CEntidad oCEntidad = new CEntidad();
            doc.AddAuthor("OSINFOR");
            doc.AddKeywords("pdf, PdfWriter; Documento; iTextSharp");
            doc.SetMargins(36.0f, 36.0f, 90.0f, 60.0f);
            if (elementListado.NUM_THABILITANTE.ToString().Length > 50) { nombreArchivo = ((((elementListado.NUM_THABILITANTE.ToString().Substring(0, 50) + "_" + elementListado.NUM_POA_INT.ToString() + "_" + DateTime.Now.ToString()).Replace('.', 'x')).Replace(' ', '_')).Replace('/', '_')).Replace(':', '-').Replace('|', '-').Replace(';', '-').Replace(',', 'x'); }
            else { nombreArchivo = ((((elementListado.NUM_THABILITANTE.ToString() + "_" + elementListado.NUM_POA_INT.ToString() + "_" + DateTime.Now.ToString()).Replace('.', 'x')).Replace(' ', '_')).Replace('/', '_')).Replace(':', '-').Replace('|', '-').Replace(';', '-').Replace(',', 'x'); }
            string rut = mapPath + "Descargas\\" + nombreArchivo + "_" + ".pdf";// @"C:\doc.pdf";
            //Procedemos a crear el documento en la ruta antes establecida
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(rut, FileMode.Create));
            wri.PageEvent = new oCLogicaFooter();
            doc.Open();
            iTextSharp.text.Rectangle page = doc.PageSize; //Obtenemos el tamaño total de la pagina

            medCols = new float[] { .35f, .01f, .64f };
            tableTitulo = HerUtil.constructorTabla(3, page, medCols, page.Width - 290);

            //doc.Add(new Paragraph("\n"));

            /*****Bloque para indicar si es lista roja o lista verde*****/

            medCols = new float[] { .30f };
            tableTituloBloque = HerUtil.constructorTabla(1, page, medCols, page.Width - 90);
            if (Color == "ROJO") { tableTituloBloque.AddCell(HerUtil.celda("CON RIESGO: LISTA ROJA", 1, 1, 20, Element.ALIGN_CENTER, 0, BaseColor.BLACK, "transparent", "Negrita")); }
            else if (Color == "VERDE") { tableTituloBloque.AddCell(HerUtil.celda("SIN RIESGO: LISTA VERDE", 1, 1, 20, Element.ALIGN_CENTER, 0, BaseColor.BLACK, "transparent", "Negrita")); }
            tableTituloBloque.AddCell(HerUtil.celda("", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
            doc.Add(tableTituloBloque);
            doc.Add(new Paragraph("\n"));
            /************************************************************/

            medCols = new float[] { .30f };
            tableTituloBloque = HerUtil.constructorTabla(1, page, medCols, page.Width - 90);

            tableTituloBloque.AddCell(HerUtil.celda("Datos Generales", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "lightgray", "Negrita"));
            tableTituloBloque.AddCell(HerUtil.celda("", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
            doc.Add(tableTituloBloque);

            medCols = new float[] { .35f, .01f, .64f };
            tableDatos = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);

            tableDatos.AddCell(HerUtil.celda("Titular(es): ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
            tableDatos.AddCell(HerUtil.celda(elementListado.TITULAR.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));


            string num_thabilitante = Regex.Replace(elementListado.NUM_THABILITANTE, @"\s", "");
            string[] lista = num_thabilitante.Split('|');
            int cantidadTH = lista.Length;

            if (cantidadTH < 3)
            {
                tableDatos.AddCell(HerUtil.celda("Título Habilitante: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.NUM_THABILITANTE.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
            }
            else
            {
                tableDatos.AddCell(HerUtil.celda("Título Habilitante: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(lista[0] + " | " + lista[1], 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                for (int i = 2; i < cantidadTH; i++)
                {
                    if (i + 1 == cantidadTH)
                    {
                        tableDatos.AddCell(HerUtil.celda(string.Empty, 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        tableDatos.AddCell(HerUtil.celda(lista[i], 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                    }
                    else
                    {
                        tableDatos.AddCell(HerUtil.celda(string.Empty, 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        tableDatos.AddCell(HerUtil.celda(lista[i] + " | " + lista[i + 1], 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                    }
                }
            }
            if ((elementListado.ANIO_REFERENCIA >= anioReferencia) && (elementListado.RUC.ToString().Trim() != ""))
            {
                tableDatos.AddCell(HerUtil.celda("RUC: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.RUC.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
            }
            else if (varSession != "3")
            {
                tableDatos.AddCell(HerUtil.celda("RUC: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.RUC.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Normal"));
            }
            tableDatos.AddCell(HerUtil.celda("Modalidad de Aprovechamiento: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
            tableDatos.AddCell(HerUtil.celda(elementListado.MODALIDAD.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
            tableDatos.AddCell(HerUtil.celda("Ubicación: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
            tableDatos.AddCell(HerUtil.celda(elementListado.UBICACION.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));

            tableDatos.AddCell(HerUtil.celda("Plan de Manejo Forestal: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
            tableDatos.AddCell(HerUtil.celda(elementListado.NUM_POA.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
            if (elementListado.RES_APROBACION_POA.ToString().Trim() != "" && elementListado.RES_APROBACION_POA.ToString().Trim() != "NO CONSIGNA")
            {
                tableDatos.AddCell(HerUtil.celda("Res. de Aprobación del Plan: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.RES_APROBACION_POA.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
            }
            else if (varSession != "3")
            {
                tableDatos.AddCell(HerUtil.celda("Res. de Aprobación del Plan: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.RES_APROBACION_POA.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Normal"));
            }
            if (elementListado.RES_REFORMULA_POA.ToString().Trim() != "" && elementListado.RES_REFORMULA_POA.ToString().Trim() != "NO CONSIGNA")
            {
                tableDatos.AddCell(HerUtil.celda("Res. de Reformulación del Plan: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.RES_REFORMULA_POA.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
            }
            if (elementListado.ANIO_REFERENCIA >= anioReferencia)
            {
                tableDatos.AddCell(HerUtil.celda("Inicio y fin de vigencia del Plan: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.VIGENCIA.ToString() + " - " + elementListado.FIN_VIGENCIA.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
            }
            else
            {
                tableDatos.AddCell(HerUtil.celda("Inicio de vigencia del Plan: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.VIGENCIA.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
            }
            tableDatos.AddCell(HerUtil.celda("Zafra:", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
            tableDatos.AddCell(HerUtil.celda(elementListado.ZAFRA.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
            tableDatos.AddCell(HerUtil.celda("Volumen del Plan(m3): ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
            tableDatos.AddCell(HerUtil.celda(elementListado.VOLUMEN.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
            if (elementListado.CONSULTOR.ToString() != "")
            {
                tableDatos.AddCell(HerUtil.celda("Consultor/Regente que suscribió el plan: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda((elementListado.CONSULTOR.ToString() == "" ? " - " : elementListado.CONSULTOR.ToString()), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
            }
            else if (varSession != "3")
            {
                tableDatos.AddCell(HerUtil.celda("Consultor/Regente que suscribió el plan: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                tableDatos.AddCell(HerUtil.celda((elementListado.CONSULTOR.ToString() == "" ? " - " : elementListado.CONSULTOR.ToString()), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Normal"));
            }
            /*if (elementListado.ANIO_REFERENCIA >= anioReferencia)*/
            /*{*/
            if (elementListado.REGENTE_IMPLEMENTA.ToString() != "")
            {
                tableDatos.AddCell(HerUtil.celda("Consultor/Regente que implementa el plan de manejo: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda((elementListado.REGENTE_IMPLEMENTA.ToString() == "" ? " - " : elementListado.REGENTE_IMPLEMENTA.ToString()), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
            }
            else if (varSession != "3")
            {
                tableDatos.AddCell(HerUtil.celda("Consultor/Regente que implementa el plan de manejo: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                tableDatos.AddCell(HerUtil.celda((elementListado.REGENTE_IMPLEMENTA.ToString() == "" ? " - " : elementListado.REGENTE_IMPLEMENTA.ToString()), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Normal"));
            }
            /*}*/
            if (Color == "ROJO" || Color == "NINGUNO_ROJO")
            {
                if (elementListado.ARBOLES_INEX.ToString() == "SI" && elementListado.NUM_ARBOLES_INEX > 0)
                {
                    tableDatos.AddCell(HerUtil.celda("Árboles Inexistentes: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                    tableDatos.AddCell(HerUtil.celda(elementListado.ARBOLES_INEX.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                    tableDatos.AddCell(HerUtil.celda("Nro Árboles Inexistentes: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                    tableDatos.AddCell(HerUtil.celda(elementListado.NUM_ARBOLES_INEX.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                }
            }
            doc.Add(tableDatos);
            doc.Add(new Paragraph("\n"));
            /*ALERTAS*/
            if (elementListado.ALERTA == "Si")
            {
                medCols = new float[] { .30f };
                tableTituloBloque = HerUtil.constructorTabla(1, page, medCols, page.Width - 90);
                tableTituloBloque.AddCell(HerUtil.celda("Alertas", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "lightgray", "Negrita"));
                tableTituloBloque.AddCell(HerUtil.celda("", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                doc.Add(tableTituloBloque);

                //alertas 30/05/2019
                medCols = new float[] { .35f, .01f, .64f };
                tableDatos = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                tableDatos.AddCell(HerUtil.celda("Fecha de Alerta: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.FECHA_ENVIO_ALERTA.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                tableDatos.AddCell(HerUtil.celda("Aplicación de Medidas Cautelares (Antes del PAU): ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.NUM_RESOLUCION_ANT_PAU.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                tableDatos.AddCell(HerUtil.celda("Volumen de la Alerta: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableDatos.AddCell(HerUtil.celda(elementListado.VOLUMEN_ALERTA.ToString(), 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                doc.Add(tableDatos);
            }
            medCols = new float[] { .30f };
            tableTituloBloque = HerUtil.constructorTabla(1, page, medCols, page.Width - 90);

            CEntidad oCEntReso = new CEntidad();
            oCEntReso.TIPO_REPORTE = "2";
            oCEntReso.ID_REGISTRO = elementListado.ID_REGISTRO;
            oCEntReso = RegMostrarListadoResoluciones(oCEntReso);

            tableTituloBloque.AddCell(HerUtil.celda("Estado actual del título habilitante", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "lightgray", "Negrita"));
            tableTituloBloque.AddCell(HerUtil.celda("", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
            doc.Add(new Paragraph("\n"));

            if (elementListado.TEXTO_CADUCA.Trim() != "") { tableTituloBloque.AddCell(HerUtil.celda(elementListado.TEXTO_CADUCA, 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita")); }
            if (elementListado.CADUCADO == "SI") { tableTituloBloque.AddCell(HerUtil.celda("Caducado: Si", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal")); }
            else { tableTituloBloque.AddCell(HerUtil.celda("Caducado: No", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal")); }
            if (elementListado.MEDIDA_CAUTELAR.ToString() == "SI")
            { tableTituloBloque.AddCell(HerUtil.celda("Medidas Cautelares: Si", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal")); }
            else if (elementListado.MEDIDA_PRECAUTORIA.ToString() == "SI")
            { tableTituloBloque.AddCell(HerUtil.celda("Medidas Precautorias: Si", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal")); }
            else
            { tableTituloBloque.AddCell(HerUtil.celda("Medidas Cautelares: No", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal")); }

            doc.Add(tableTituloBloque);

            medCols = new float[] { .30f };
            tableTituloBloque = HerUtil.constructorTabla(1, page, medCols, page.Width - 90);

            tableTituloBloque.AddCell(HerUtil.celda("Supervisión y Fiscalización del OSINFOR", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "lightgray", "Negrita"));
            tableTituloBloque.AddCell(HerUtil.celda("", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
            doc.Add(new Paragraph("\n"));
            doc.Add(tableTituloBloque);

            //26/11/2018
            medCols = new float[] { .35f, .01f, .64f };
            //tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
            //tableResol.AddCell(HerUtil.celda("Es alerta osinfor:  ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
            //tableResol.AddCell(HerUtil.celda(elementListado.ES_ALERTA_OSINFOR.ToString(), 2, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
            //.Add(tableResol);       

            medCols = new float[] { .35f, .01f, .64f };
            tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
            if (elementListado.TIPO_SUPERVISION.Trim() != "")
            {
                tableResol.AddCell(HerUtil.celda("Oportunidad de supervisión:  ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableResol.AddCell(HerUtil.celda(elementListado.TIPO_SUPERVISION.ToString(), 2, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
            }
            else if (varSession != "3")
            {
                tableResol.AddCell(HerUtil.celda("Oportunidad de supervisión:  ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                tableResol.AddCell(HerUtil.celda(elementListado.TIPO_SUPERVISION.ToString(), 2, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Normal"));
            }
            if (elementListado.ANIO_REFERENCIA >= anioReferencia)
            {
                if (elementListado.NUM_INFORME.Trim() != "")
                {
                    tableResol.AddCell(HerUtil.celda("Nro Informe de Supervisión:  ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                    tableResol.AddCell(HerUtil.celda(elementListado.NUM_INFORME.ToString(), 2, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                }
                else if (varSession != "3")
                {
                    tableResol.AddCell(HerUtil.celda("Nro Informe de Supervisión:  ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableResol.AddCell(HerUtil.celda(elementListado.NUM_INFORME.ToString(), 2, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Normal"));
                }
            }
            doc.Add(tableResol);

            medCols = new float[] { .30f };
            tableDatos = HerUtil.constructorTabla(1, page, medCols, page.Width - 90);
            if (elementListado.FECHA_SUPERVISION_INICIO.Trim() != "" && elementListado.FECHA_SUPERVISION_TERMINO.Trim() != "")
            {
                tableDatos.AddCell(HerUtil.celda("Fecha de Supervisión Inicio: " + elementListado.FECHA_SUPERVISION_INICIO.ToString() + ", Término: " + elementListado.FECHA_SUPERVISION_TERMINO.ToString(), 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
            }
            doc.Add(tableDatos);
            String Multa = "";
            Int32 literal = 0;
            foreach (CEntidad Resoles in oCEntReso.List_Resoluciones)
            {
                switch (Resoles.TIPO_RESOLUCION)
                {
                    //case "Medida Cautelar":
                    //    medCols = new float[] { .35f, .01f, .64f };
                    //    tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                    //    tableResol.AddCell(HerUtil.celda("Nro Res. Medida Cautelar: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                    //    tableResol.AddCell(HerUtil.celda(Resoles.NUM_RESOLUCION, 2, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                    //    doc.Add(tableResol);
                    //    break;
                    case "Aplicación de Medidas Cautelares (Antes del PAU)":
                        medCols = new float[] { .35f, .01f, .64f };
                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                        tableResol.AddCell(HerUtil.celda("Nro Res. Medidas Cautelares antes del PAU:: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        tableResol.AddCell(HerUtil.celda(Resoles.NUM_RESOLUCION, 2, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                        doc.Add(tableResol);
                        break;
                    case "Inicio PAU":
                        medCols = new float[] { .35f, .01f, .64f };
                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                        tableResol.AddCell(HerUtil.celda("Nro Res. Inicio PAU: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        tableResol.AddCell(HerUtil.celda(Resoles.NUM_RESOLUCION, 2, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                        doc.Add(tableResol);
                        break;

                    case "Ampliación PAU":
                        medCols = new float[] { .35f, .01f, .64f };
                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                        tableResol.AddCell(HerUtil.celda("Nro Res. Amplicación PAU: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        tableResol.AddCell(HerUtil.celda(Resoles.NUM_RESOLUCION, 2, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                        doc.Add(tableResol);
                        break;
                    case "Rectificación":
                        medCols = new float[] { .35f, .01f, .64f };
                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                        tableResol.AddCell(HerUtil.celda("Nro Res. Rectificación: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        tableResol.AddCell(HerUtil.celda(Resoles.NUM_RESOLUCION, 2, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                        doc.Add(tableResol);
                        break;
                    case "Variación de Imputación de Cargos":
                        medCols = new float[] { .35f, .01f, .64f };
                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                        tableResol.AddCell(HerUtil.celda("Nro Res. Variación de Imputación de Cargos: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        tableResol.AddCell(HerUtil.celda(Resoles.NUM_RESOLUCION, 2, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                        doc.Add(tableResol);
                        break;
                    case "Término PAU":
                        medCols = new float[] { .35f, .01f, .64f };
                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                        tableResol.AddCell(HerUtil.celda("Nro Res. Término PAU: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        tableResol.AddCell(HerUtil.celda(Resoles.NUM_RESOLUCION, 2, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                        doc.Add(tableResol);
                        break;
                    case "Adecuación de Multa":
                        medCols = new float[] { .35f, .01f, .64f };
                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                        tableResol.AddCell(HerUtil.celda("Nro Res. Adecuación de Multa: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        tableResol.AddCell(HerUtil.celda(Resoles.NUM_RESOLUCION, 2, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                        doc.Add(tableResol);
                        break;
                    case "Recurso de Reconsideración":
                        medCols = new float[] { .35f, .01f, .64f };
                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                        tableResol.AddCell(HerUtil.celda("Nro Res. Reconsideración PAU: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        tableResol.AddCell(HerUtil.celda(Resoles.NUM_RESOLUCION, 2, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                        doc.Add(tableResol);
                        break;
                    case "Resolución TFFS":
                        if (Resoles.URL_RESOLUCION.Trim() == "")
                        {
                            medCols = new float[] { .35f, .01f, .64f };
                            tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                            tableResol.AddCell(HerUtil.celda("Nro Resolución TFFS: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                            tableResol.AddCell(HerUtil.celda(Resoles.NUM_RESOLUCION, 2, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                            doc.Add(tableResol);
                        }
                        else
                        {
                            //tableResol.AddCell(HerUtil.celda("Nro Resolución TFFS: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));                         
                            Font link = FontFactory.GetFont("Calibri", 11, Font.UNDERLINE, BaseColor.BLUE);
                            Anchor anchor = new Anchor(Resoles.NUM_RESOLUCION, link);
                            anchor.Reference = Resoles.URL_RESOLUCION;
                            doc.Add(new Chunk("    Nro Resolución TFFS:                      ", FontFactory.GetFont("Calibri", 11, Font.BOLD, BaseColor.BLACK)));
                            doc.Add(anchor);
                            doc.Add(new Paragraph("\n", FontFactory.GetFont("Calibri", 2, Font.NORMAL, BaseColor.BLACK)));
                        }
                        break;
                }

                if ((Int32)Resoles.RD_MOSTRAR_INCISOS == 1)
                //if ((Int32)Resoles.RD_MOSTRAR_INCISOS == 1 && Resoles.NUM_RESOLUCION == oCEntReso.List_Resoluciones[oCEntReso.List_Resoluciones.Count-1].NUM_RESOLUCION)
                {
                    fuenteResol = (fuenteResol == "" ? fuenteResol + "Resolución N° " + Resoles.NUM_RESOLUCION : fuenteResol + " y Resolución N° " + Resoles.NUM_RESOLUCION);
                }

                medCols = new float[] { .35f, .01f, .64f };
                tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);

                String resuelve = "";
                String determina = "";
                String descripcion = "";

                switch (Resoles.TIPO_RESOLUCION)
                {
                    case "Término PAU":
                        if (Resoles.NUM_RESOLUCION == oCEntReso.List_Resoluciones[oCEntReso.List_Resoluciones.Count - 1].NUM_RESOLUCION)
                        {
                            tableResol.AddCell(HerUtil.celda("   Se resuelve: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                            tableResol.AddCell(HerUtil.celda(Resoles.DETERMINACION, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                            doc.Add(tableResol);

                            if (Resoles.MONTO > 0)
                            {
                                medCols = new float[] { .35f, .01f, .64f };
                                tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                tableResol.AddCell(HerUtil.celda("   Multa Determinada:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                tableResol.AddCell(HerUtil.celda(Resoles.MONTO.ToString() + " U.I.T.", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                doc.Add(tableResol);
                            }
                        }
                        if (Resoles.MONTO > 0)
                            Multa = Resoles.MONTO.ToString() + " U.I.T.";
                        break;
                    case "Resolución TFFS":
                        if (!string.IsNullOrEmpty(Resoles.LITERAL))
                        {
                            literal = 1;
                            string[] nombreliteral = Resoles.LITERAL.Split(';');
                            //medCols = new float[] { .35f, .01f, .64f };
                            //tableResol = HerUtil.constructorTabla(1, page, medCols, page.Width - 90);
                            //tableResol.AddCell(HerUtil.celda("   ", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                            //tableResol.AddCell(HerUtil.celda(Resoles.LITERAL, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                            //doc.Add(tableResol);


                            medCols = new float[] { .30f };
                            tableTituloBloque = HerUtil.constructorTabla(1, page, medCols, page.Width - 90);
                            infracciones = elementListado.INFRACCIONES.Split(';');

                            foreach (String lit in nombreliteral)
                            {
                                if (lit != "")
                                {
                                    tableTituloBloque.AddCell(HerUtil.celda("   " + lit.Trim(), 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                }
                            }
                            doc.Add(tableTituloBloque);

                        }
                        if (!string.IsNullOrEmpty(Resoles.SENTIDO_RES))
                        {
                            switch (Resoles.SENTIDO_RES)
                            {
                                case "00000118":
                                    medCols = new float[] { .35f, .01f, .64f };
                                    tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                    tableResol.AddCell(HerUtil.celda("Sentido:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    tableResol.AddCell(HerUtil.celda("Suspensión-Judicializado", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                    doc.Add(tableResol);
                                    break;
                                case "00000119":
                                    medCols = new float[] { .35f, .01f, .64f };
                                    tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                    tableResol.AddCell(HerUtil.celda("Sentido:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    tableResol.AddCell(HerUtil.celda("Cumplimiento de mandato judicial", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                    doc.Add(tableResol);
                                    break;
                                case "00000120":
                                    medCols = new float[] { .35f, .01f, .64f };
                                    tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                    tableResol.AddCell(HerUtil.celda("Sentido:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    tableResol.AddCell(HerUtil.celda("Desestimiento", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                    doc.Add(tableResol);
                                    break;
                                case "0000053":
                                    medCols = new float[] { .35f, .01f, .64f };
                                    tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                    tableResol.AddCell(HerUtil.celda("Sentido:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    tableResol.AddCell(HerUtil.celda("Improcedente", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                    doc.Add(tableResol);
                                    if (Resoles.RESOL_DET != "0")
                                    {
                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda("Determina:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        tableResol.AddCell(HerUtil.celda(Resoles.RESOL_DET, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        doc.Add(tableResol);
                                    }
                                    break;
                                case "0000054":
                                    medCols = new float[] { .35f, .01f, .64f };
                                    tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                    tableResol.AddCell(HerUtil.celda("Sentido:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    tableResol.AddCell(HerUtil.celda("Inadmisible", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                    doc.Add(tableResol);
                                    if (Resoles.RESOL_DET != "0")
                                    {
                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda("Determina:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        tableResol.AddCell(HerUtil.celda(Resoles.RESOL_DET2, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        doc.Add(tableResol);
                                    }
                                    break;

                                case "0000057":
                                    medCols = new float[] { .35f, .01f, .64f };
                                    tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                    tableResol.AddCell(HerUtil.celda("Sentido:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    tableResol.AddCell(HerUtil.celda("Infundado", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                    doc.Add(tableResol);
                                    if (Resoles.RESOL_DET != "0")
                                    {
                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda("Determina:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        tableResol.AddCell(HerUtil.celda(Resoles.RESOL_DET3, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        doc.Add(tableResol);
                                    }
                                    break;
                                case "0000055":
                                    medCols = new float[] { .35f, .01f, .64f };
                                    tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                    tableResol.AddCell(HerUtil.celda("Sentido:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    tableResol.AddCell(HerUtil.celda("Fundado", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                    doc.Add(tableResol);
                                    determina = "Determina:";


                                    if (Resoles.CHKREVOCAR == 1)
                                    {

                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        descripcion = "Revocar ";
                                        switch (Resoles.RADREVOCAR)
                                        {
                                            case "1":
                                                descripcion += "sanción";
                                                break;
                                            case "2":
                                                descripcion += "caducidad";
                                                break;
                                            case "3":
                                                descripcion += "sanción y caducidad";
                                                break;
                                        }
                                        tableResol.AddCell(HerUtil.celda(descripcion, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        doc.Add(tableResol);
                                        determina = "";
                                        descripcion = "";
                                    }


                                    if (Resoles.CHKREVOCARPARTE == 1)
                                    {
                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        descripcion = "Revocar en Parte ";
                                        switch (Resoles.RADREVOCAR)
                                        {
                                            case "1":
                                                descripcion += "sanción";
                                                break;
                                            case "2":
                                                descripcion += "caducidad";
                                                break;
                                            case "3":
                                                descripcion += "sanción y caducidad";
                                                break;
                                        }
                                        tableResol.AddCell(HerUtil.celda(descripcion, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        doc.Add(tableResol);
                                        determina = "";
                                        descripcion = "";
                                    }

                                    if (Resoles.CHKRETROTRAER == 1)
                                    {
                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        descripcion = "Retrotraer";
                                        switch (Resoles.RADRETROTRAER)
                                        {
                                            case "1":
                                                descripcion += " hasta notificación supervisión";
                                                break;
                                            case "2":
                                                descripcion += " hasta supervisión";
                                                break;
                                            case "3":
                                                descripcion += " hasta notificación de la RSD de inicio de PA";
                                                break;
                                            case "4":
                                                descripcion += " hasta presentación de descargos RSD";
                                                break;
                                            case "5":
                                                descripcion += " hasta informe final de instrucción";
                                                break;
                                            case "6":
                                                descripcion += " hasta presentación de descargos IFI";
                                                break;
                                            case "7":
                                                descripcion += " hasta RD de término de PAU";
                                                break;
                                            case "8":
                                                descripcion += " hasta notificación de la RD de término de PAU";
                                                break;
                                            case "9":
                                                descripcion += " hasta notificación del informe final de instrucción";
                                                break;
                                            case "10":
                                                descripcion += "-Otros";
                                                break;
                                        }
                                        tableResol.AddCell(HerUtil.celda(descripcion, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        doc.Add(tableResol);
                                        determina = "";
                                        descripcion = "";
                                    }

                                    if (Resoles.CHKPRESCRIBIR == 1)
                                    {
                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        tableResol.AddCell(HerUtil.celda("Prescribir ", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        determina = "";
                                        doc.Add(tableResol);
                                    }

                                    if (Resoles.CHKARCHIVAR == 1)
                                    {
                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        tableResol.AddCell(HerUtil.celda("Archivar ", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        determina = "";
                                        doc.Add(tableResol);
                                    }


                                    if (Resoles.CHKNULIDAD == 1)
                                    {
                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        descripcion = "Nulidad/Nulidad de Oficio ";
                                        switch (Resoles.RADNULIDAD)
                                        {
                                            case "1":
                                                descripcion += "RSD inicio";
                                                break;
                                            case "2":
                                                descripcion += "RD final";
                                                break;
                                            case "3":
                                                descripcion += "RD reconsideración";
                                                break;
                                            case "4":
                                                descripcion += "IFI";
                                                break;
                                            case "5":
                                                descripcion += "Otros";
                                                break;
                                        }
                                        tableResol.AddCell(HerUtil.celda(descripcion, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        doc.Add(tableResol);
                                        determina = "";
                                        descripcion = "";
                                    }

                                    if (Resoles.CHKLEVANTAR == 1)
                                    {
                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        tableResol.AddCell(HerUtil.celda("Levantar suspensión ", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        determina = "";
                                        doc.Add(tableResol);
                                    }

                                    if (Resoles.CHKCARECE == 1)
                                    {
                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        tableResol.AddCell(HerUtil.celda("Carece de objeto ", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        determina = "";
                                        doc.Add(tableResol);
                                    }

                                    if (Resoles.CHKOTRO == 1)
                                    {
                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        tableResol.AddCell(HerUtil.celda("Otro ", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        determina = "";
                                        doc.Add(tableResol);
                                    }

                                    break;

                                case "0000056":
                                    medCols = new float[] { .35f, .01f, .64f };
                                    tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                    tableResol.AddCell(HerUtil.celda("Sentido:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    tableResol.AddCell(HerUtil.celda("Fundado en parte", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                    doc.Add(tableResol);
                                    determina = "";//"Fundado en Parte";
                                    if (Resoles.CHKREVOCAR2 == 1)
                                    {

                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        descripcion = "Revocar ";
                                        switch (Resoles.RADREVOCAR2)
                                        {
                                            case "1":
                                                descripcion += "sanción";
                                                break;
                                            case "2":
                                                descripcion += "caducidad";
                                                break;
                                            case "3":
                                                descripcion += "sanción y caducidad";
                                                break;
                                        }
                                        tableResol.AddCell(HerUtil.celda(descripcion, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        doc.Add(tableResol);
                                        determina = "";
                                        descripcion = "";
                                    }

                                    if (Resoles.CHKREVOCARPARTE2 == 1)
                                    {
                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        descripcion = "Revocar en Parte ";
                                        switch (Resoles.RADREVOCARPARTE2)
                                        {
                                            case "1":
                                                descripcion += "sanción";
                                                break;
                                            case "2":
                                                descripcion += "caducidad";
                                                break;
                                            case "3":
                                                descripcion += "sanción y caducidad";
                                                break;
                                        }
                                        tableResol.AddCell(HerUtil.celda(descripcion, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        doc.Add(tableResol);
                                        determina = "";
                                        descripcion = "";
                                    }

                                    if (Resoles.CHKRETROTRAER2 == 1)
                                    {
                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        descripcion = "Retrotraer";
                                        switch (Resoles.RADRETROTRAER2)
                                        {
                                            case "1":
                                                descripcion += " hasta notificación supervisión";
                                                break;
                                            case "2":
                                                descripcion += " hasta supervisión";
                                                break;
                                            case "3":
                                                descripcion += " hasta notificación de la RSD de inicio de PA";
                                                break;
                                            case "4":
                                                descripcion += " hasta presentación de descargos RSD";
                                                break;
                                            case "5":
                                                descripcion += " hasta informe final de instrucción";
                                                break;
                                            case "6":
                                                descripcion += " hasta presentación de descargos IFI";
                                                break;
                                            case "7":
                                                descripcion += " hasta RD de término de PAU";
                                                break;
                                            case "8":
                                                descripcion += " hasta notificación de la RD de término de PAU";
                                                break;
                                            case "9":
                                                descripcion += " hasta notificación del informe final de instrucción";
                                                break;
                                            case "10":
                                                descripcion += "-Otros";
                                                break;
                                        }
                                        tableResol.AddCell(HerUtil.celda(descripcion, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        doc.Add(tableResol);
                                        determina = "";
                                        descripcion = "";
                                    }

                                    if (Resoles.CHKPRESCRIBIR2 == 1)
                                    {
                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        tableResol.AddCell(HerUtil.celda("Prescribir ", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        determina = "";
                                        doc.Add(tableResol);
                                    }

                                    if (Resoles.CHKARCHIVAR2 == 1)
                                    {
                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        tableResol.AddCell(HerUtil.celda("Archivar ", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        determina = "";
                                        doc.Add(tableResol);
                                    }


                                    if (Resoles.CHKNULIDAD2 == 1)
                                    {
                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        descripcion = "Nulidad/Nulidad de Oficio ";
                                        switch (Resoles.RADNULIDAD2)
                                        {
                                            case "1":
                                                descripcion += "RSD inicio";
                                                break;
                                            case "2":
                                                descripcion += "RD final";
                                                break;
                                            case "3":
                                                descripcion += "RD reconsideración";
                                                break;
                                            case "4":
                                                descripcion += "IFI";
                                                break;
                                            case "5":
                                                descripcion += "Otros";
                                                break;
                                        }
                                        tableResol.AddCell(HerUtil.celda(descripcion, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        doc.Add(tableResol);
                                        determina = "";
                                        descripcion = "";
                                    }

                                    if (Resoles.CHKLEVANTAR2 == 1)
                                    {
                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        tableResol.AddCell(HerUtil.celda("Levantar suspensión ", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        determina = "";
                                        doc.Add(tableResol);
                                    }

                                    if (Resoles.CHKCARECE2 == 1)
                                    {
                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        tableResol.AddCell(HerUtil.celda("Carece de objeto ", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        determina = "";
                                        doc.Add(tableResol);
                                    }

                                    if (Resoles.CHKOTRO2 == 1)
                                    {
                                        medCols = new float[] { .35f, .01f, .64f };
                                        tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                        tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                        tableResol.AddCell(HerUtil.celda("Otro ", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                        determina = "";
                                        doc.Add(tableResol);
                                    }

                                    break;

                                case "0000058":
                                    medCols = new float[] { .35f, .01f, .64f };
                                    tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                    tableResol.AddCell(HerUtil.celda("Sentido:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    tableResol.AddCell(HerUtil.celda("Nulidad", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                    doc.Add(tableResol);
                                    determina = "";//"Nulidad";

                                    determina += Resoles.DETERMINA_RETROTRAER == "0000084" ? "Retrotraer " : "";
                                    determina += Resoles.DETERMINA_RETROTRAER == "0000085" ? "Archivar " : "";
                                    determina += Resoles.RETRO_VALOR1 == "0000065" ? "notificacion supervision " : "";
                                    determina += Resoles.RETRO_VALOR1 == "0000066" ? "supervision " : "";
                                    determina += Resoles.RETRO_VALOR1 == "0000067" ? "notificacion de la RSD de inicio de PA " : "";
                                    determina += Resoles.RETRO_VALOR1 == "0000068" ? "presentacion de descargos RSD " : "";
                                    determina += Resoles.RETRO_VALOR1 == "0000069" ? "informe final de instruccion " : "";
                                    determina += Resoles.RETRO_VALOR1 == "0000070" ? "presentacion de descargos IFI " : "";
                                    determina += Resoles.RETRO_VALOR1 == "0000071" ? "RD de termino de PAU " : "";
                                    determina += Resoles.RETRO_VALOR1 == "0000072" ? "notificacion de la RD de termino de PAU " : "";
                                    determina += Resoles.RETRO_VALOR1 == "0000073" ? "notificacion del informe final de fnstruccion " : "";
                                    determina += Resoles.RETRO_VALOR1 == "0000074" ? "otros " : "";

                                    medCols = new float[] { .35f, .01f, .64f };
                                    tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                    tableResol.AddCell(HerUtil.celda("Determina:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                    doc.Add(tableResol);
                                    break;

                                case "0000059":
                                    medCols = new float[] { .35f, .01f, .64f };
                                    tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                    tableResol.AddCell(HerUtil.celda("Sentido:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    tableResol.AddCell(HerUtil.celda("Nulidad parcial", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                    doc.Add(tableResol);
                                    determina = "";//"Nulidad determina";

                                    determina += Resoles.DETERMINA_RETROTRAER2 == "0000084" ? "Retrotraer " : "";
                                    determina += Resoles.DETERMINA_RETROTRAER2 == "0000085" ? "Archivar " : "";
                                    determina += Resoles.RETRO_VALOR2 == "0000065" ? "notificacion supervision " : "";
                                    determina += Resoles.RETRO_VALOR2 == "0000066" ? "supervision " : "";
                                    determina += Resoles.RETRO_VALOR2 == "0000067" ? "notificacion de la RSD de inicio de PA " : "";
                                    determina += Resoles.RETRO_VALOR2 == "0000068" ? "presentacion de descargos RSD " : "";
                                    determina += Resoles.RETRO_VALOR2 == "0000069" ? "informe final de instruccion " : "";
                                    determina += Resoles.RETRO_VALOR2 == "0000070" ? "presentacion de descargos IFI " : "";
                                    determina += Resoles.RETRO_VALOR2 == "0000071" ? "RD de termino de PAU " : "";
                                    determina += Resoles.RETRO_VALOR2 == "0000072" ? "notificacion de la RD de termino de PAU " : "";
                                    determina += Resoles.RETRO_VALOR2 == "0000073" ? "notificacion del informe final de instruccion " : "";
                                    determina += Resoles.RETRO_VALOR2 == "0000074" ? "otros " : "";

                                    medCols = new float[] { .35f, .01f, .64f };
                                    tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                    tableResol.AddCell(HerUtil.celda("   Determina:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    tableResol.AddCell(HerUtil.celda(determina, 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                    doc.Add(tableResol);
                                    break;
                                case "00000591":
                                    medCols = new float[] { .35f, .01f, .64f };
                                    tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                    tableResol.AddCell(HerUtil.celda("Sentido:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    tableResol.AddCell(HerUtil.celda("Adecuación de Multa", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                    doc.Add(tableResol);
                                    break;
                                case "00000592":
                                    medCols = new float[] { .35f, .01f, .64f };
                                    tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                    tableResol.AddCell(HerUtil.celda("Sentido:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    tableResol.AddCell(HerUtil.celda("Rectificación de Error Material", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                    doc.Add(tableResol);
                                    break;
                                case "00000593":
                                    medCols = new float[] { .35f, .01f, .64f };
                                    tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                                    tableResol.AddCell(HerUtil.celda("Sentido:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                                    tableResol.AddCell(HerUtil.celda("Sustracción de la Materia", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                                    doc.Add(tableResol);
                                    break;
                            }
                        }
                        
                        if (Resoles.MULTA > 0)
                        {
                            medCols = new float[] { .35f, .01f, .64f };
                            tableResol = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
                            tableResol.AddCell(HerUtil.celda("Multa Determinada:", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                            tableResol.AddCell(HerUtil.celda(Resoles.MULTA.ToString() + " U.I.T.", 2, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                            doc.Add(tableResol);
                        }
                        break;
                    case "Recurso de Reconsideración":
                        tableResol.AddCell(HerUtil.celda("   Se resuelve: ", 1, 1, 11, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                        if (Int32.Parse(Resoles.INADMISIBLE.ToString()) == 1) { resuelve = "Inadmisible"; }
                        else if (Int32.Parse(Resoles.IMPROCEDENTE.ToString()) == 1) { resuelve = "Improcedente"; }
                        else if (Int32.Parse(Resoles.INFUNDADA.ToString()) == 1) { resuelve = "Infundado"; }
                        else if (Int32.Parse(Resoles.FUNDADA.ToString()) == 1) { resuelve = "Fundado"; }
                        else if (Int32.Parse(Resoles.FUNDADA_PARTE.ToString()) == 1)
                        {
                            if (Int32.Parse(Resoles.LEVANTAR_CADUCIDAD.ToString()) == 1 && Int32.Parse(Resoles.CAMBIO_MULTA.ToString()) == 1) { resuelve = "Fundado en parte (Levantar la caducidad del Título Habilitante y Cambio de Monto de Multa)"; }
                            else if (Int32.Parse(Resoles.LEVANTAR_CADUCIDAD.ToString()) == 1) { resuelve = "Fundado en parte (Levantar la caducidad del Título Habilitante)"; }
                            else if (Int32.Parse(Resoles.CAMBIO_MULTA.ToString()) == 1) { resuelve = "Fundado en parte (Cambio de Monto de Multa)"; }
                            else { resuelve = "Fundado en parte"; }

                        }
                        else if (Int32.Parse(Resoles.INADMISIBLE.ToString()) == 1) { resuelve = "Inadmisible"; }
                        tableResol.AddCell(HerUtil.celda(resuelve, 2, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                        doc.Add(tableResol);
                        break;
                }
            }
            if (elementListado.INFRACCIONES.Trim() != "" && literal == 0)
            {
                medCols = new float[] { .30f };
                tableTituloBloque = HerUtil.constructorTabla(1, page, medCols, page.Width - 90);
                infracciones = elementListado.INFRACCIONES.Split(';');

                foreach (String infraccion in infracciones)
                {
                    if (infraccion != "")
                    {
                        tableTituloBloque.AddCell(HerUtil.celda("   " + infraccion.Trim(), 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
                    }
                }
                doc.Add(tableTituloBloque);
            }

            medCols = new float[] { .30f };
            tableTituloBloque = HerUtil.constructorTabla(1, page, medCols, page.Width - 90);

            tableTituloBloque.AddCell(HerUtil.celda("Estado Actual del Proceso", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "lightgray", "Negrita"));
            tableTituloBloque.AddCell(HerUtil.celda("", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
            if (elementListado.ARCH_EVI_IRREG.ToString() == "SI")
            {
                tableTituloBloque.AddCell(HerUtil.celda("Informe de Supervisión Archivado (Evidencia de irregularidades cuya sanción no es competencia de OSINFOR)", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
            }
            else
            {
                tableTituloBloque.AddCell(HerUtil.celda(elementListado.DESCRIPCION_ESTADO, 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
            }
            doc.Add(new Paragraph("\n"));
            doc.Add(tableTituloBloque);

            if (Color == "VERDE" || Color == "NINGUNO_VERDE")// para el color verde el cuadro de especies que justifican se imprime primero, para el rojo se imprime al ultimo
            {
                imprimeTablaJustificados(elementListado, page, colorHeader);
            }

            medCols = new float[] { .30f };
            tableTituloBloque = HerUtil.constructorTabla(1, page, medCols, page.Width - 90);

            imprimeTablaInjustificados(elementListado, page, colorHeader, Color, fuenteResol);

            if (Color == "ROJO" || Color == "NINGUNO_ROJO")
            {
                imprimeTablaInexistentes(elementListado, page, colorHeader);
                imprimeTablaJustificados(elementListado, page, colorHeader);
            }

            //doc.Add(new Paragraph("\n"));
            medCols = new float[] { .35f, .01f, .64f };
            tableTitulo = HerUtil.constructorTabla(3, page, medCols, page.Width - 90);
            doc.Add(new Paragraph("\n"));
            if (varSession == "3")
            {
                tableTitulo.AddCell(HerUtil.celda("Fecha de Ingreso al Observatorio: ", 1, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                tableTitulo.AddCell(HerUtil.celda(elementListado.FECHA_INGRESO.ToString(), 2, 1, 10, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
            }
            else
            {
                if (Color != "NINGUNO" && Color != "NINGUNO_ROJO" && Color != "NINGUNO_VERDE")
                {
                    tableTitulo.AddCell(HerUtil.celda("Reporte Generado por el SIGO-SFC: ", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda("No fue generado desde el Observatorio OSINFOR (La siguiente información resaltada en amarillo solo sera visualizada desde el SIGOsfc, no se mostrará al publico en general)", 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Normal"));
                    tableTitulo.AddCell(HerUtil.celda("------------------------------", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda("------------------------------", 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));

                    tableTitulo.AddCell(HerUtil.celda("Porcentaje (%) de árboles inexistentes (V1): ", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda(elementListado.PORCENT_INEX.ToString(), 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));

                    tableTitulo.AddCell(HerUtil.celda("Cantidad de especies forestales maderables supervisadas: ", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda(elementListado.CANT_ESP_SUPER.ToString(), 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda("Cantidad de especies forestales maderables que presentan volumen injustificado en relación a las especies supervisadas: ", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda(elementListado.CANT_ESP_VOL_INJUS.ToString(), 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda("Porcentaje (%) de especies forestales maderables que presentan volumen injustificado en relación a las especies supervisadas (V2): ", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda((elementListado.CANT_ESP_SUPER == 0 ? 0 : ((decimal)elementListado.CANT_ESP_VOL_INJUS / (decimal)elementListado.CANT_ESP_SUPER) * 100).ToString(), 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda("Volumen injustificado en m3 de las especies supervisadas (Impacto): ", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda(elementListado.VOL_INJUS, 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda("Porcentaje (%) de volumen injustificado sobre el total movilizado de las especies supervisadas (V3): ", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda(elementListado.PORCENT_INJUS_VOL, 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));


                    if (elementListado.ANIO_REFERENCIA >= anioReferencia)
                    {
                        tableTitulo.AddCell(HerUtil.celda("Porcentaje del area afectada del aprovechamiento maderable no autorizado: ", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                        tableTitulo.AddCell(HerUtil.celda(elementListado.PERDIDA_COBERTURA.ToString(), 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                        tableTitulo.AddCell(HerUtil.celda("Porcentaje (%) del volumen de aprovechamiento maderable no autorizado: ", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                        tableTitulo.AddCell(HerUtil.celda(elementListado.APROV_NO_AUTORIZADO.ToString(), 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                        tableTitulo.AddCell(HerUtil.celda("Valor normalizado de la Significancia: ", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                        tableTitulo.AddCell(HerUtil.celda(elementListado.SIGNIFICANCIA.ToString(), 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                        tableTitulo.AddCell(HerUtil.celda("Valor normalizado de la Irreparabilidad: ", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                        tableTitulo.AddCell(HerUtil.celda(elementListado.IRREPARABILIDAD.ToString(), 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    }

                    tableTitulo.AddCell(HerUtil.celda("Observaciones encontradas en el Procesamiento de los datos: ", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda(elementListado.OBSERVACION, 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));

                    tableTitulo.AddCell(HerUtil.celda("------------------------------", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda("------------------------------", 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda("Formula:", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda("RESULTADO=REDONDEAR((V1+V2+V3)/3)*IMPACTO", 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda("------------------------------", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda("------------------------------", 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));

                    tableTitulo.AddCell(HerUtil.celda("Variable V1: ", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda(elementListado.VALOR_PROBABILIDAD_1.ToString(), 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda("Variable V2: ", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda(elementListado.VALOR_PROBABILIDAD_2.ToString(), 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda("Variable V3: ", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda(elementListado.VALOR_PROBABILIDAD_3.ToString(), 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda("Impacto: ", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda(elementListado.VALOR_IMPACTO.ToString(), 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda("Resultado: ", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda(elementListado.RESULTADO.ToString(), 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));

                }
                else
                {
                    tableTitulo.AddCell(HerUtil.celda("Reporte Generado por el SIGO-SFC: ", 1, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Negrita"));
                    tableTitulo.AddCell(HerUtil.celda("Este reporte no se mostrará en el Observatorio OSINFOR", 2, 1, 9, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "yellow", "Normal"));
                }
            }
            doc.Add(tableTitulo);

            medCols = new float[] { .30f };
            tableTituloBloque = HerUtil.constructorTabla(1, page, medCols, page.Width - 90);
            tableTituloBloque.AddCell(HerUtil.celda("Fecha y hora de Consulta: " + DateTime.Now.ToString(), 1, 1, 10, Element.ALIGN_RIGHT, 0, BaseColor.BLACK, "transparent", "Normal"));
            doc.Add(tableTituloBloque);

            EntResol = new CEntidad();
            EntResol.ID_REGISTRO = elementListado.ID_REGISTRO;
            EntResol.TIPO_REPORTE = "7";
            ListadoDesIncisos = RegMostrarDesListadoIncisos(EntResol);

            medCols = new float[] { .25f, .75f };
            tableIncisos = HerUtil.constructorTabla(2, page, medCols, page.Width - 90);

            if (ListadoDesIncisos.Count > 0)
            {
                tableIncisos.AddCell(HerUtil.celda("Inciso", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
                tableIncisos.AddCell(HerUtil.celda("Descripción", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));

                foreach (CEntidad Incisos in ListadoDesIncisos)
                {
                    tableIncisos.AddCell(HerUtil.celda(Incisos.INFRACCIONES + " Inciso " + Incisos.INCISO, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                    tableIncisos.AddCell(HerUtil.celda(Incisos.TEXTO, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                }

                doc.Add(new Paragraph("\n"));
                doc.Add(tableIncisos);
            }

            doc.Close();
            switch (Color)
            {
                case "ROJO":
                case "NINGUNO_ROJO":
                    HerUtil.agregarMarcaAguaImagen(mapPath + "Descargas\\" + nombreArchivo + "_" + ".pdf", mapPath + "Descargas\\" + nombreArchivo + ".pdf", Server.MapPath("~/Imagenes/Observatorio/huella_osinfor_rojo_vertical.jpg"));
                    break;
                case "AMBAR":
                    HerUtil.agregarMarcaAguaImagen(mapPath + "Descargas\\" + nombreArchivo + "_" + ".pdf", mapPath + "Descargas\\" + nombreArchivo + ".pdf", Server.MapPath("~/Imagenes/Observatorio/huella_osinfor_ambar.jpg"));
                    break;
                case "VERDE":
                case "NINGUNO_VERDE":
                    HerUtil.agregarMarcaAguaImagen(mapPath + "Descargas\\" + nombreArchivo + "_" + ".pdf", mapPath + "Descargas\\" + nombreArchivo + ".pdf", Server.MapPath("~/Imagenes/Observatorio/huella_osinfor_verde_vertical.jpg"));
                    break;
                case "NINGUNO":
                    HerUtil.agregarMarcaAguaImagen(mapPath + "Descargas\\" + nombreArchivo + "_" + ".pdf", mapPath + "Descargas\\" + nombreArchivo + ".pdf", Server.MapPath("~/Imagenes/Observatorio/huella_osinfor_gris_vertical.jpg"));
                    break;
            }
            return nombreArchivo;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (doc != null)
            {
                doc.Close();
            }
        }
    }
    private void imprimeTablaJustificados(CEntidad elemento, iTextSharp.text.Rectangle pagina, String colorHeader)
    {
        CEntidad EntConsulta = new CEntidad();
        PdfPTable tablaIncisos;
        //float[] widths2;
        int i = 0;
        ListadoIncisos = new List<CEntidad>();
        EntConsulta.ID_REGISTRO = elemento.ID_REGISTRO;
        EntConsulta.TIPO_REPORTE = "5";
        ListadoIncisos = RegMostrarListadoJustNoJust(EntConsulta);

        if (elemento.ANIO_REFERENCIA >= anioReferencia)
        {
            if (ListadoIncisos.Count > 0)
            {
                medCols = new float[] { .30f };
                tableTituloBloque = HerUtil.constructorTabla(1, pagina, medCols, pagina.Width - 90);

                tableTituloBloque.AddCell(HerUtil.celda("Observaciones: especies forestales que justifican su extracción", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                doc.Add(new Paragraph("\n"));
                doc.Add(tableTituloBloque);
                tableTituloBloque = new PdfPTable(1);
                ////////////////////////////////////////
                tablaIncisos = new PdfPTable(6); //Declaramos el objeto PdfPTable y especificamos el ancho de las columas a utilizar
                tablaIncisos.WidthPercentage = 80;//Le damos un tamaño a la tabla, esta tomara en porcierto el ancho que ucupara
                tablaIncisos.TotalWidth = pagina.Width - 90; //Le damos el tamaño de la tabla
                tablaIncisos.LockedWidth = true;//Decimos que se bloque el tamaño de la tabla, esto para que no creesca dependiendo de la información
                float[] widths4 = new float[] { .08f, .43f, .10f, .18f, .18f, .25f }; //Declaramos un array con los tamaños de nuestras columnas deben de coincidir con el tamaño de columnas
                tablaIncisos.SetWidths(widths4); //Agregamos los anchos a nuestra tabla

                tablaIncisos.AddCell(HerUtil.celda("N°", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
                tablaIncisos.AddCell(HerUtil.celda("Especie", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
                tablaIncisos.AddCell(HerUtil.celda("Parcela de corta", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
                tablaIncisos.AddCell(HerUtil.celda("Volumen aprobado (m3)", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
                tablaIncisos.AddCell(HerUtil.celda("Volumen movilizado según reporte de extracción (m3)", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
                tablaIncisos.AddCell(HerUtil.celda("Volumen movilizado verificado en la supervisión (m3)", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
                i = 0;
                foreach (CEntidad Incisos in ListadoIncisos)
                {
                    i = i + 1;
                    tablaIncisos.AddCell(HerUtil.celda(i.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                    tablaIncisos.AddCell(HerUtil.celda(Incisos.DESC_ESPECIES, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Cursiva"));
                    tablaIncisos.AddCell(HerUtil.celda(Incisos.PC.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                    tablaIncisos.AddCell(HerUtil.celda(Incisos.VOLUMEN_AUT.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                    tablaIncisos.AddCell(HerUtil.celda(Incisos.VOLUMEN_BEXT.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                    tablaIncisos.AddCell(HerUtil.celda(Incisos.VOLUMEN_VERIFICADO.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                }
                doc.Add(tablaIncisos);
                doc.Add(new Paragraph("\n"));
            }
        }
        else
        {
            if ((elemento.COD_MTIPO.ToString() != "0000017") || (
                elemento.ESTADO != "INICIO_PAU" && elemento.ESTADO != "INICIO_PAU_TFFS" && elemento.ESTADO != "PAU_ARCHIVADO" && elemento.ESTADO != "PAU_ARCHIVADO_CASO_ESPECIAL" &&
                elemento.ESTADO != "PAU_ARCHIVADO_MUERTE" && elemento.ESTADO != "PAU_ARCHIVADO_TFFS" && elemento.ESTADO != "PAU_ARCHIVADO_TFFS_MUERTE" && elemento.ESTADO != "PAU_SANCION_ARCHIVADO" &&
                elemento.ESTADO != "SANCION" && elemento.ESTADO != "SANCION_APELA" && elemento.ESTADO != "SANCION_FIRME" && elemento.ESTADO != "SANCION_JUDICIAL" &&
                elemento.ESTADO != "SANCION_TFFS_AGOTADA" && elemento.ESTADO != "SANCION_TFFS_FIRME"))
            {
                if (ListadoIncisos.Count > 0)
                {
                    medCols = new float[] { .30f };
                    tableTituloBloque = HerUtil.constructorTabla(1, pagina, medCols, pagina.Width - 90);

                    tableTituloBloque.AddCell(HerUtil.celda("Observaciones: especies forestales que justifican su extracción", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Negrita"));
                    doc.Add(new Paragraph("\n"));
                    doc.Add(tableTituloBloque);
                    tableTituloBloque = new PdfPTable(1);
                    ////////////////////////////////////////
                    tablaIncisos = new PdfPTable(5); //Declaramos el objeto PdfPTable y especificamos el ancho de las columas a utilizar
                    tablaIncisos.WidthPercentage = 80;//Le damos un tamaño a la tabla, esta tomara en porcierto el ancho que ucupara
                    tablaIncisos.TotalWidth = pagina.Width - 90; //Le damos el tamaño de la tabla
                    tablaIncisos.LockedWidth = true;//Decimos que se bloque el tamaño de la tabla, esto para que no creesca dependiendo de la información
                    float[] widths4 = new float[] { .08f, .47f, .10f, .25f, .25f }; //Declaramos un array con los tamaños de nuestras columnas deben de coincidir con el tamaño de columnas
                    tablaIncisos.SetWidths(widths4); //Agregamos los anchos a nuestra tabla

                    tablaIncisos.AddCell(HerUtil.celda("N°", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
                    tablaIncisos.AddCell(HerUtil.celda("Especie", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
                    tablaIncisos.AddCell(HerUtil.celda("Parcela de corta", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
                    tablaIncisos.AddCell(HerUtil.celda("Volumen aprobado (m3)", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
                    tablaIncisos.AddCell(HerUtil.celda("Volumen movilizado (m3)", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
                    i = 0;
                    foreach (CEntidad Incisos in ListadoIncisos)
                    {
                        i = i + 1;
                        tablaIncisos.AddCell(HerUtil.celda(i.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                        tablaIncisos.AddCell(HerUtil.celda(Incisos.DESC_ESPECIES, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Cursiva"));
                        tablaIncisos.AddCell(HerUtil.celda(Incisos.PC, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Cursiva"));
                        tablaIncisos.AddCell(HerUtil.celda(Incisos.VOLUMEN_AUT.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                        tablaIncisos.AddCell(HerUtil.celda(Incisos.VOLUMEN_BEXT.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                    }
                    doc.Add(tablaIncisos);
                    doc.Add(new Paragraph("\n"));
                }
            }
        }
    }
    private void imprimeTablaInjustificados(CEntidad elemento, iTextSharp.text.Rectangle pagina, String colorHeader, String Color, String fuente)
    {
        CEntidad EntConsulta = new CEntidad();
        PdfPTable tablaIncisos;
        float[] widths2;
        int i;
        EntConsulta = new CEntidad();
        EntConsulta.ID_REGISTRO = elemento.ID_REGISTRO;
        //EntResol.COD_RESODIREC = Resoles.COD_RESODIREC;
        EntConsulta.TIPO_REPORTE = "3";
        if (Color != "NINGUNO") { ListadoIncisos = RegMostrarListadoIncisos(EntConsulta); }
        else { ListadoIncisos = new List<CEntidad>(); }

        ///Se muestra la tabla de incisos solo para RD de Inicio y Término de PAU y que tengan por lo menos una infracción
        if (ListadoIncisos.Count > 0)
        {
            medCols = new float[] { .30f };
            tableTituloBloque = HerUtil.constructorTabla(1, pagina, medCols, pagina.Width - 90);

            if (Color == "VERDE" || Color == "NINGUNO_VERDE")
            {
                tableTituloBloque.AddCell(HerUtil.celda("Observaciones: especies forestales incursos en PAU", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "lightgray", "Negrita"));
            }
            else if (Color == "ROJO" || Color == "NINGUNO_ROJO")
            {
                tableTituloBloque.AddCell(HerUtil.celda("Detalle sobre el aprovechamiento forestal: especies forestales con movilización no autorizada", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "lightgray", "Negrita"));
            }

            doc.Add(new Paragraph("\n"));
            doc.Add(tableTituloBloque);

            //tableIncisos = new PdfPTable(8); //Declaramos el objeto PdfPTable y especificamos el ancho de las columas a utilizar
            tablaIncisos = new PdfPTable(8); //Declaramos el objeto PdfPTable y especificamos el ancho de las columas a utilizar
            tablaIncisos.WidthPercentage = 80;//Le damos un tamaño a la tabla, esta tomara en porcierto el ancho que ucupara
            tablaIncisos.TotalWidth = pagina.Width - 90; //Le damos el tamaño de la tabla
            tablaIncisos.LockedWidth = true;//Decimos que se bloque el tamaño de la tabla, esto para que no creesca dependiendo de la información
                                            //float[] widths2 = new float[] { .2f, .4f, .5f, .3f, .3f, .3f, .3f, .3f }; //Declaramos un array con los tamaños de nuestras columnas deben de coincidir con el tamaño de columnas
            widths2 = new float[] { .08f, .32f, .11f, .10f, .11f, .16f, .16f, .16f }; //Declaramos un array con los tamaños de nuestras columnas deben de coincidir con el tamaño de columnas
            tablaIncisos.SetWidths(widths2); //Agregamos los anchos a nuestra tabla

            tablaIncisos.AddCell(HerUtil.celda("N°", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
            //tableIncisos.AddCell(celda("Inciso", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
            tablaIncisos.AddCell(HerUtil.celda("Especies", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
            tablaIncisos.AddCell(HerUtil.celda("Parcela de corta", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
            tablaIncisos.AddCell(HerUtil.celda("Volumen aprobado (m3)", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
            tablaIncisos.AddCell(HerUtil.celda("Volumen movilizado segun reporte de extracción (m3)", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
            tablaIncisos.AddCell(HerUtil.celda("Volumen movilizado sin autorización (m3)", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
            tablaIncisos.AddCell(HerUtil.celda("% del volumen movilizado sin autorización con relación al total del volumen movilizado", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
            tablaIncisos.AddCell(HerUtil.celda("% del volumen movilizado sin autorización con relación al total del volumen aprobado", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));

            i = 0;
            foreach (CEntidad Incisos in ListadoIncisos)
            {
                i = i + 1;
                tablaIncisos.AddCell(HerUtil.celda(i.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                //tableIncisos.AddCell(celda(Incisos.INCISO, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Normal"));
                tablaIncisos.AddCell(HerUtil.celda(Incisos.DESC_ESPECIES, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Cursiva"));
                tablaIncisos.AddCell(HerUtil.celda(Incisos.PC, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Cursiva"));
                tablaIncisos.AddCell(HerUtil.celda(Incisos.VOLUMEN_AUT.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                tablaIncisos.AddCell(HerUtil.celda(Incisos.VOLUMEN_BEXT.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                tablaIncisos.AddCell(HerUtil.celda(Incisos.VOLUMEN.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                tablaIncisos.AddCell(HerUtil.celda(Incisos.PORCENT_BEXT, 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                tablaIncisos.AddCell(HerUtil.celda(Incisos.PORCENT_AUT, 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
            }
            doc.Add(tablaIncisos);
            tablaIncisos = new PdfPTable(7);

            medCols = new float[] { .30f };
            tableTituloBloque = HerUtil.constructorTabla(1, pagina, medCols, pagina.Width - 90);
            tableTituloBloque.AddCell(HerUtil.celda("Fuente: " + fuente, 1, 1, 8, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));

            if (elemento.FECHA_BEXT != "")
            {
                tableTituloBloque.AddCell(HerUtil.celda("*Balance de extracción de fecha: " + elemento.FECHA_BEXT, 1, 1, 8, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
            }
            doc.Add(tableTituloBloque);
        }
    }
    private void imprimeTablaInexistentes(CEntidad elemento, iTextSharp.text.Rectangle pagina, String colorHeader)
    {
        CEntidad EntConsulta = new CEntidad();
        PdfPTable tablaIncisos;
        //float[] widths2;
        int i;

        EntConsulta = new CEntidad();
        EntConsulta.ID_REGISTRO = elemento.ID_REGISTRO;
        EntConsulta.TIPO_REPORTE = "4";
        ListadoIncisos = RegMostrarListadoInexistentes(EntConsulta);

        if (ListadoIncisos.Count > 0)
        {

            medCols = new float[] { .30f };
            tableTituloBloque = HerUtil.constructorTabla(1, pagina, medCols, pagina.Width - 90);

            tableTituloBloque.AddCell(HerUtil.celda("Detalle sobre la inexistencia de árboles", 1, 1, 12, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "lightgray", "Negrita"));
            doc.Add(new Paragraph("\n"));
            doc.Add(tableTituloBloque);

            //////////////////////////////////
            if (elemento.ANIO_REFERENCIA >= anioReferencia)
            {
                tablaIncisos = new PdfPTable(7);
                medCols = new float[] { .03f, .37f, .12f, .12f, .12f, .12f, .12f };
                tablaIncisos = HerUtil.constructorTabla(7, pagina, medCols, pagina.Width - 90);
            }
            else
            {
                tablaIncisos = new PdfPTable(5);
                medCols = new float[] { .03f, .32f, .22f, .22f, .21f };
                tablaIncisos = HerUtil.constructorTabla(5, pagina, medCols, pagina.Width - 90);
            }

            tablaIncisos.AddCell(HerUtil.celda("N°", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
            tablaIncisos.AddCell(HerUtil.celda("Especie", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
            tablaIncisos.AddCell(HerUtil.celda("Nro árboles supervisados", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
            if (elemento.ANIO_REFERENCIA >= anioReferencia)
            {
                tablaIncisos.AddCell(HerUtil.celda("Nro de árboles existentes", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
            }
            tablaIncisos.AddCell(HerUtil.celda("Nro de árboles inexistentes", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
            if (elemento.ANIO_REFERENCIA >= anioReferencia)
            {
                tablaIncisos.AddCell(HerUtil.celda("Volumen declarado de los árboles inexistentes", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));
            }
            tablaIncisos.AddCell(HerUtil.celda("% árboles inexistentes", 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, colorHeader, "Negrita"));

            i = 0;
            foreach (CEntidad Incisos in ListadoIncisos)
            {
                i = i + 1;
                tablaIncisos.AddCell(HerUtil.celda(i.ToString(), 1, 1, 8, Element.ALIGN_RIGHT, 5, BaseColor.BLACK, "transparent", "Normal"));
                tablaIncisos.AddCell(HerUtil.celda(Incisos.DESC_ESPECIES, 1, 1, 8, Element.ALIGN_LEFT, 5, BaseColor.BLACK, "transparent", "Cursiva"));
                tablaIncisos.AddCell(HerUtil.celda(Incisos.NUM_ARB_MUESTRA.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                if (elemento.ANIO_REFERENCIA >= anioReferencia)
                {
                    tablaIncisos.AddCell(HerUtil.celda(Incisos.NUM_ARB_EXIST.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                }
                tablaIncisos.AddCell(HerUtil.celda(Incisos.NUM_ARB_INEX.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                if (elemento.ANIO_REFERENCIA >= anioReferencia)
                {
                    tablaIncisos.AddCell(HerUtil.celda(Incisos.VOLUMEN_DECLARADO.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
                }
                tablaIncisos.AddCell(HerUtil.celda(Incisos.PORCENT_INEX.ToString(), 1, 1, 8, Element.ALIGN_CENTER, 5, BaseColor.BLACK, "transparent", "Normal"));
            }
            doc.Add(tablaIncisos);
            doc.Add(new Paragraph("\n"));

        }
        medCols = new float[] { .30f };
        tableTituloBloque = HerUtil.constructorTabla(1, pagina, medCols, pagina.Width - 90);
        tableTituloBloque.AddCell(HerUtil.celda("Fuente: Informe de Supervisión ", 1, 1, 8, Element.ALIGN_LEFT, 0, BaseColor.BLACK, "transparent", "Normal"));
    }
}