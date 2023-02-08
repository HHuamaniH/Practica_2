using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;
using VModel = CapaEntidad.ViewModel.VM_InformeAutoridadForestal;

namespace SIGOFCv3.Reportes.THabilitante
{
    public class ReporteInformeAutoridadForestal
    {

        public static ListResult DescargaExcel(VModel vModel)
        {
            ListResult result = new ListResult();
            try
            {
                string nomPlantilla = "";

                if (vModel.TVentana == "VOLINJUS")
                    nomPlantilla = "VolInjus_v2.xlsx";

                String RutaReporteSeguimiento = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                string nombreFile = "";

                nombreFile = DateTime.Now.Year.ToString() +
                    DateTime.Now.Month.ToString() +
                    DateTime.Now.Day.ToString() +
                    DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() +
                    DateTime.Now.Second.ToString() +
                    DateTime.Now.Millisecond.ToString() + ".xlsx";


                string rutaExcel = RutaReporteSeguimiento + nombreFile;
                File.Copy(RutaReporteSeguimiento + nomPlantilla, rutaExcel); //pues si es mover 
                                                                             //Creamos la cadena de conexión con el fichero excel
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
                        //Construyendo las Cabeceras
                        RetornaInsert(cmd, nomPlantilla, vModel);
                        //Cerramos la conexión
                        conn.Close();
                    }
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
        private static void RetornaInsert(OleDbCommand cmd, String nomPlantilla, VModel vModel)
        {
            String insertar = "";
            int i = 1;
            switch (nomPlantilla)
            {
                #region PoaVertice.xlsx
                case "VolInjus_v2.xlsx":
                    foreach (var listaInf in vModel.ListVolInjustificado)
                    {

                        insertar = "";
                        if (listaInf.ESPECIES.Trim().Length <= 1)
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            insertar = insertar + "'" + listaInf.ESPECIES.Substring(0, listaInf.ESPECIES.IndexOf('|')).Trim() + "'";
                            insertar = insertar + ",'" + listaInf.ESPECIES.Substring(listaInf.ESPECIES.IndexOf('|') + 1, listaInf.ESPECIES.Length - listaInf.ESPECIES.IndexOf('|') - 1).Trim() + "'";
                        }
                        insertar = insertar + ",'" + listaInf.VOLUMEN_APROBADO.ToString() + "'";
                        insertar = insertar + ",'" + listaInf.VOLUMEN_MOVILIZADO.ToString() + "'";
                        insertar = insertar + ",'" + listaInf.VOLUMEN_INJUSTIFICADO.ToString() + "'";
                        insertar = insertar + ",'" + listaInf.VOLUMEN_JUSTIFICADO.ToString() + "'";
                        insertar = insertar + ",'" + listaInf.OBSERVACION + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (vModel.ListVolInjustificado.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                    #endregion


            }
        }


    }
}