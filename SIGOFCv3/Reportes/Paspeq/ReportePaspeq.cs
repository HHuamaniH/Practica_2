using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;

namespace SIGOFCv3.Reportes.Paspeq
{
    public class ReportePaspeq
    {
        //public static ListResult GenerarReportePaspeq(int num_paspeq, string periodo)
        //{
        //    ListResult result = new ListResult();
        //    try
        //    {
        //        Log_Paspeq logPaspeq = new Log_Paspeq();
        //        List<Ent_Paspeq_Detalle> listadoPaspeq = logPaspeq.ReportePaspeq(num_paspeq, periodo);
        //        int i = 1;
        //        String insertar = "";
        //        String RutaReporteSeguimiento = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
        //        string nombreFile = "";
        //        nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
        //        string rutaExcel = RutaReporteSeguimiento + nombreFile;
        //        try
        //        {
        //            File.Copy(RutaReporteSeguimiento + "plantilla_paspeq.xlsx", rutaExcel);
        //        }
        //        catch (IOException ix)
        //        {
        //            throw new Exception(ix.Message);
        //        }

        //        OleDbConnectionStringBuilder cb = new OleDbConnectionStringBuilder();
        //        cb.DataSource = rutaExcel;

        //        if (Path.GetExtension(rutaExcel).ToUpper() == ".XLS")
        //        {
        //            cb.Provider = "Microsoft.Jet.OLEDB.4.0";
        //            cb.Add("Extended Properties", "Excel 8.0;HDR=YES;IMEX=0;");
        //        }
        //        else if (Path.GetExtension(rutaExcel).ToUpper() == ".XLSX")
        //        {
        //            cb.Provider = "Microsoft.ACE.OLEDB.12.0";
        //            cb.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES;IMEX=0;");
        //        }
        //        using (OleDbConnection conn = new OleDbConnection(cb.ConnectionString))
        //        {
        //            //Abrimos la conexión
        //            conn.Open();
        //            //Creamos la ficha
        //            using (OleDbCommand cmd = conn.CreateCommand())
        //            {
        //                cmd.CommandType = CommandType.Text;
        //                int num_fila = 1;
        //                //Construyendo las Cabeceras

        //                foreach (var listaInf in listadoPaspeq)
        //                {
        //                    insertar = "";
        //                    insertar = insertar + "'" + num_fila + "'";
        //                    insertar = insertar + ",'" + listaInf.COD_THABILITANTE.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.NUM_POA.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.COD_PMANEJO.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.TABLA_ORIGEN.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.NUM_THABILITANTE.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.TITULAR_ACTUAL.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.R_LEGAL.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.DEPARTAMENTO.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.PROVINCIA.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.DISTRITO.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.MODALIDAD.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.CADUCADO.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.MED_CAU.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.MED_PRECAU.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.SUPERVISIONES_TH_EFECTUADAS.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.OD_AMBITO.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.NOMBRE_POA.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.RESOLUCION_POA.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.FECHA_APROB.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.FUENTE.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.NUM_DREFERENCIA.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.FECHA_RECEPCION.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.ESTADO_CALIDAD.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.NUM_CENSO_MADERABLE.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.NUM_CENSO_NOMADERABLE.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.NUM_ESPECIE_APROBADO.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.NUM_ESPECIE_BEXTRACCION.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.AREA_TH.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.AREA_POA.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.FECHA_INICIO_TH.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.FECHA_FIN_TH.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.FECHA_INICIO_POA.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.FECHA_FIN_POA.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.CONSULTOR.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.SUPERVISIONES_POA_REALIZADAS.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.ZONA_UTM.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.COORD_ESTE.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.COORD_NORTE.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.ESPECIE_AMENAZADA.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.REQ_ENTIDAD.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.DENUNCIA.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.ESTADO_SUPERVISION_RESOLUCION.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.ESTADO_SUPERVISION_PLAN.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.SUPERVISION_ANTES_EXTRACCION.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.CANT_C1.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.FRECUENCIA_SUPERVISION_TH.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.RIESGO_FRECUENCIA.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.RESULTADO_FRECUENCIA.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.CANT_C2.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.INCIDENCIA_INFRAC_TH.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.RIESGO_INCIDENCIA.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.RESULTADO_INCIDENCIA.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.CANT_C3.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.INDICE_NOAUTH.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.RIESGO_NOAUTH.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.RESULTADO_NOAUTH.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.CANT_C4.Trim() + "'";
        //                    insertar = insertar + ",'" + listaInf.INDICE_INFRAC.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.RIESGO_INFRAC.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.RESULTADO_INFRAC.ToString() + "'";
        //                    insertar = insertar + ",'" + listaInf.TOTAL.ToString() + "'";

        //                    String cadena = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":BJ" + (listadoPaspeq.Count + 1).ToString() + "] VALUES (" + insertar + ")";
        //                    System.Diagnostics.Debug.WriteLine(cadena);
        //                    num_fila++;
        //                    cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":BJ" + (listadoPaspeq.Count + 1).ToString() + "] VALUES (" + insertar + ")";
        //                    cmd.ExecuteNonQuery();
        //                }

        //            }
        //            //Cerramos la conexión
        //            conn.Close();
        //        }
        //        List<string> lstResult = new List<string> { nombreFile };
        //        result.AddResultado("Ok", true, lstResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        result.AddResultado(ex.Message, false);
        //    }
        //    return result;
        //}
    }
}