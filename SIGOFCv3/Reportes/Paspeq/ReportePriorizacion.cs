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
    public class ReportePriorizacion
    {
        public static ListResult GenerarReportePriorizacion(string cod_od, string periodo)
        {
            ListResult result = new ListResult();
            try
            {
                Log_Priorizacion logPriorizacion = new Log_Priorizacion();
                List<Ent_Priorizacion_Detalle> listadoPriorizacion = logPriorizacion.ReportePriorizacion(cod_od, periodo);
                int i = 1;
                String insertar = "";
                String RutaPlantilla = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                string nombreFile = "";
                nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                string rutaExcel = RutaPlantilla + nombreFile;
                try
                {
                    File.Copy(RutaPlantilla + "plantilla_priorizacion.xlsx", rutaExcel);
                }
                catch (IOException ix)
                {
                    throw new Exception(ix.Message);
                }

                OleDbConnectionStringBuilder cb = new OleDbConnectionStringBuilder();
                cb.DataSource = rutaExcel;

                if (Path.GetExtension(rutaExcel).ToUpper() == ".XLS")
                {
                    cb.Provider = "Microsoft.Jet.OLEDB.4.0";
                    cb.Add("Extended Properties", "Excel 8.0;HDR=YES;IMEX=0;");
                }
                else if (Path.GetExtension(rutaExcel).ToUpper() == ".XLSX")
                {
                    cb.Provider = "Microsoft.ACE.OLEDB.12.0";
                    cb.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES;IMEX=0;");
                }
                using (OleDbConnection conn = new OleDbConnection(cb.ConnectionString))
                {
                    //Abrimos la conexión
                    conn.Open();
                    //Creamos la ficha
                    using (OleDbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        int num_fila = 1;
                        //Construyendo las Cabeceras

                        foreach (var lista in listadoPriorizacion)
                        {
                            insertar = "";
                            insertar = insertar + "'" + num_fila + "'";
                            insertar = insertar + ",'" + lista.COD_PASPEQ_DETALLE.ToString() + "'";
                            insertar = insertar + ",'" + lista.NUM_THABILITANTE.Trim() + "'";
                            insertar = insertar + ",'" + lista.NOMBRE_POA.Trim() + "'";
                            insertar = insertar + ",'" + ((lista.A1 == 0) ? "" : "X") + "'";
                            insertar = insertar + ",'" + ((lista.A2 == 0) ? "" : "X") + "'";
                            insertar = insertar + ",'" + ((lista.A3 == 0) ? "" : "X") + "'";
                            insertar = insertar + ",'" + ((lista.A4 == 0) ? "" : "X") + "'";
                            insertar = insertar + ",'" + ((lista.A5 == 0) ? "" : "X") + "'";
                            insertar = insertar + ",'" + ((lista.A6 == 0) ? "" : "X") + "'";
                            insertar = insertar + ",'" + ((lista.A7 == 0) ? "" : "X") + "'";
                            insertar = insertar + ",'" + ((lista.A8 == 0) ? "" : "X") + "'";
                            insertar = insertar + ",'" + ((lista.B1 == 0) ? "" : "X") + "'";
                            insertar = insertar + ",'" + ((lista.B2 == 0) ? "" : "X") + "'";
                            insertar = insertar + ",'" + ((lista.B3 == 0) ? "" : "X") + "'";
                            insertar = insertar + ",'" + ((lista.B4 == 0) ? "" : "X") + "'";
                            insertar = insertar + ",'" + ((lista.B5 == 0) ? "" : "X") + "'";
                            insertar = insertar + ",'" + ((lista.B6 == 0) ? "" : "X") + "'";

                            String cadena = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":R" + (listadoPriorizacion.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                            System.Diagnostics.Debug.WriteLine(cadena);
                            num_fila++;
                            cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":R" + (listadoPriorizacion.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                            cmd.ExecuteNonQuery();
                        }

                    }
                    //Cerramos la conexión
                    conn.Close();
                }
                List<string> lstResult = new List<string> { nombreFile };
                result.AddResultado("Ok", true, lstResult);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }
    }
}