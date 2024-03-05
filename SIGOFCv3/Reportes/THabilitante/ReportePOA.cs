using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaLogica.DOC;
using OfficeOpenXml;
using SIGOFCv3.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
//using CEntidad = CapaEntidad.DOC.Ent_POA;
using VModel = CapaEntidad.ViewModel.VM_POA;
namespace SIGOFCv3.Reportes.THabilitante
{
    public class ReportePOA
    {
        //REVISAR
        public static ListResult GenerarReporteVerticeTH(string COD_THABILITANTE, int NumPoa)
        {
            ListResult result = new ListResult();
            try
            {


                Log_POA logPOA = new Log_POA();

                List<Ent_POA> listadoVertice = logPOA.ListarVertice(COD_THABILITANTE, NumPoa);

                int i = 1;
                String insertar = "";
                String RutaReporteSeguimiento = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                string nombreFile = "";
                nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                    DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                    DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                string rutaExcel = RutaReporteSeguimiento + nombreFile;
                //File.Delete(rutaExcel);
                File.Copy(RutaReporteSeguimiento + "POAVertice.xlsx", rutaExcel); //pues si es mover 
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
                        foreach (var listaInf in listadoVertice)
                        {
                            insertar = "";
                            insertar = insertar + "'" + listaInf.VERTICE.Trim() + "'";
                            insertar = insertar + ",'" + listaInf.ZONA.Trim() + "'";
                            insertar = insertar + ",'" + listaInf.COORDENADA_ESTE.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.COORDENADA_NORTE.ToString() + "'";
                            insertar = insertar + ",'" + listaInf.OBSERVACION + "'";
                            cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listadoVertice.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                            cmd.ExecuteNonQuery();
                        }
                        //Cerramos la conexión
                        conn.Close();
                    }
                }
                //File.Delete(rutaExcel);  
                List<string> lstResult = new List<string> { nombreFile };
                result.AddResultado("Ok", true, lstResult);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }


        public static ListResult DescargaExcel(string COD_THABILITANTE, int NumPoa, string HdfItemCod_MTipo, string TipoGrilla,
            string Estado_origen)
        {
            ListResult result = new ListResult();
            try
            {
                string nomPlantilla = "";
                List<Ent_POA> listParam = new List<Ent_POA>();

                if (TipoGrilla == "RAPoa")
                {
                    if (HdfItemCod_MTipo == "0000021")
                    {
                        nomPlantilla = "PoaMaderableRAprobPMed_v2.xlsx";
                    }
                    else if (HdfItemCod_MTipo == "0000020")
                    {
                        nomPlantilla = "PoaMaderableRAprobPCarr_v2.xlsx";
                    }
                    else
                    {
                        nomPlantilla = "PoaMaderableRAprob_v2.xlsx";
                    }

                    Ent_POA oCamposMod = new Ent_POA();
                    oCamposMod.COD_THABILITANTE = COD_THABILITANTE;
                    oCamposMod.NUM_POA = NumPoa;
                    Ent_POA datModificar = new Ent_POA();
                    Log_POA log = new Log_POA();
                    if (Estado_origen == "R")//REINGRESO                    
                        datModificar = log.RegMostrarListaHijoItems(oCamposMod);
                    else
                        datModificar = log.RegMostrarListaItems(oCamposMod);

                    listParam = datModificar.ListRAprueba;
                }


                String RutaReporteSeguimiento = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                string nombreFile = "";

                nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +
                    DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() +
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
                        RetornaInsert(cmd, nomPlantilla, listParam);
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
        public static ListResult DescargaExceles(string nomPlantillaExcel, List<Ent_POA> listParam)
        {
            ListResult result = new ListResult();
            try
            {

                String RutaReporteSeguimiento = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                string nombreFile = "";

                nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +
                    DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() +
                    DateTime.Now.Millisecond.ToString() + ".xlsx";




                string rutaExcel = RutaReporteSeguimiento + nombreFile;
                File.Copy(RutaReporteSeguimiento + nomPlantillaExcel, rutaExcel); //pues si es mover 
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
                        RetornaInsert(cmd, nomPlantillaExcel, listParam);
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
        private static void RetornaInsert(OleDbCommand cmd, String nomPlantilla, List<Ent_POA> listaParam)
        {
            String insertar = "";
            int i = 1;
            switch (nomPlantilla)
            {

                #region PoaVertice.xlsx
                case "PoaVertice.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        insertar = insertar + "'" + (string.IsNullOrEmpty(listaInf.VERTICE) ? "" : listaInf.VERTICE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.ZONA) ? "" : listaInf.ZONA.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.COORDENADA_ESTE.ToString()) ? "" : listaInf.COORDENADA_ESTE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.COORDENADA_NORTE.ToString()) ? "" : listaInf.COORDENADA_NORTE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.PCA.ToString()) ? "" : listaInf.PCA.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.OBSERVACION.ToString()) ? "" : listaInf.OBSERVACION.ToString()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                #region PoaNoMaderable_Censo_v2.xlsx
                case "PoaNoMaderable_Censo_v2.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        if (string.IsNullOrEmpty(listaInf.ESPECIES))
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
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
                        }


                        if (listaInf.ESPECIES_ARESOLUCION.Trim().Length <= 1)
                        {
                            insertar = insertar + ",'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            if (listaInf.ESPECIES_ARESOLUCION.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + listaInf.ESPECIES_ARESOLUCION.Substring(0, listaInf.ESPECIES_ARESOLUCION.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES_ARESOLUCION.Substring(listaInf.ESPECIES_ARESOLUCION.IndexOf('|') + 1, listaInf.ESPECIES_ARESOLUCION.Length - listaInf.ESPECIES_ARESOLUCION.IndexOf('|') - 1).Trim() + "'";
                            }
                        }
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.NUM_ESTRADA) ? "" : listaInf.NUM_ESTRADA.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.CODIGO) ? "" : listaInf.CODIGO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.DIAMETRO.ToString()) ? "" : listaInf.DIAMETRO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.ALTURA.ToString()) ? "" : listaInf.ALTURA.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.PRODUCCION_LATAS.ToString()) ? "" : listaInf.PRODUCCION_LATAS.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.CONDICION) ? "" : listaInf.CONDICION.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.ZONA) ? "" : listaInf.ZONA.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.COORDENADA_ESTE.ToString()) ? "" : listaInf.COORDENADA_ESTE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.COORDENADA_NORTE.ToString()) ? "" : listaInf.COORDENADA_NORTE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.OBSERVACION.ToString()) ? "" : listaInf.OBSERVACION.ToString()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion

                #region PoaMaderable_Censo_v2.xlsx

                case "PoaMaderable_Censo_v2.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        if (string.IsNullOrEmpty(listaInf.ESPECIES))
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
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
                        }
                        if (string.IsNullOrEmpty(listaInf.ESPECIES_ARESOLUCION))
                        {
                            insertar = insertar + ",'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            if (listaInf.ESPECIES_ARESOLUCION.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + listaInf.ESPECIES_ARESOLUCION.Substring(0, listaInf.ESPECIES_ARESOLUCION.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES_ARESOLUCION.Substring(listaInf.ESPECIES_ARESOLUCION.IndexOf('|') + 1, listaInf.ESPECIES_ARESOLUCION.Length - listaInf.ESPECIES_ARESOLUCION.IndexOf('|') - 1).Trim() + "'";
                            }

                        }
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.BLOQUE) ? "" : listaInf.BLOQUE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.FAJA) ? "" : listaInf.FAJA.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.CODIGO) ? "" : listaInf.CODIGO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.VOLUMEN.ToString()) ? "" : listaInf.VOLUMEN.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.DAP.ToString()) ? "" : listaInf.DAP.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.AC.ToString()) ? "" : listaInf.AC.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.DMC.ToString()) ? "" : listaInf.DMC.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.CONDICION) ? "" : listaInf.CONDICION.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.ESTADO) ? "" : listaInf.ESTADO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.ZONA) ? "" : listaInf.ZONA.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.COORDENADA_ESTE.ToString()) ? "" : listaInf.COORDENADA_ESTE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.COORDENADA_NORTE.ToString()) ? "" : listaInf.COORDENADA_NORTE.ToString()) + "'";

                        if (listaInf.OBSERVACION == null)
                            insertar = insertar + ",''";
                        else
                            insertar = insertar + ",'" + (listaInf.OBSERVACION.ToString().Trim().Length > 255 ? listaInf.OBSERVACION.ToString().Trim().Substring(0, 252) + "..." : listaInf.OBSERVACION.ToString().Trim()) + "'";

                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                #region PoaMaderableBExtraccion_v2.xlsx
                case "PoaMaderableBExtraccion_v2.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        if (string.IsNullOrEmpty(listaInf.ESPECIES))
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
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
                        }

                        if (string.IsNullOrEmpty(listaInf.ESPECIES_SERFOR))
                        {
                            insertar = insertar + ",'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            if (listaInf.ESPECIES_SERFOR.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(0, listaInf.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(listaInf.ESPECIES_SERFOR.IndexOf('|') + 1, listaInf.ESPECIES_SERFOR.Length - listaInf.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                            }
                        }
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.DMC.ToString()) ? "" : listaInf.DMC.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.TOTAL_ARBOLES.ToString()) ? "" : listaInf.TOTAL_ARBOLES.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.VOLUMEN_AUTORIZADO.ToString()) ? "" : listaInf.VOLUMEN_AUTORIZADO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.VOLUMEN_MOVILIZADO.ToString()) ? "" : listaInf.VOLUMEN_MOVILIZADO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.SALDO.ToString()) ? "" : listaInf.SALDO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.TIPOMADERABLE) ? "" : listaInf.TIPOMADERABLE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.PCA) ? "" : listaInf.PCA.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.OBSERVACION.ToString()) ? "" : listaInf.OBSERVACION.ToString()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                #region PoaMaderableRAprob_v3.xlsx
                case "PoaMaderableRAprob_v3.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        if (string.IsNullOrEmpty(listaInf.ESPECIES))
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
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
                        }
                        if (string.IsNullOrEmpty(listaInf.ESPECIES_SERFOR))
                        {
                            insertar = insertar + ",'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            if (listaInf.ESPECIES_SERFOR.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(0, listaInf.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(listaInf.ESPECIES_SERFOR.IndexOf('|') + 1, listaInf.ESPECIES_SERFOR.Length - listaInf.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                            }
                        }
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.NUM_ARBOLES.ToString()) ? "" : listaInf.NUM_ARBOLES.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.VOLUMEN_KILOGRAMOS.ToString()) ? "" : listaInf.VOLUMEN_KILOGRAMOS.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.TIPOMADERABLE.ToString()) ? "" : listaInf.TIPOMADERABLE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.UNIDAD_MEDIDA.ToString()) ? "" : listaInf.UNIDAD_MEDIDA.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.PCA.ToString()) ? "" : listaInf.PCA.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.OBSERVACION.ToString()) ? "" : listaInf.OBSERVACION.ToString()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                #region PoaInSituRAprob_v2.xlsx
                case "PoaInSituRAprob_v2.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        if (string.IsNullOrEmpty(listaInf.ESPECIES))
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
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
                        }

                        if (string.IsNullOrEmpty(listaInf.ESPECIES_SERFOR))
                        {
                            insertar = insertar + ",'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            if (listaInf.ESPECIES_SERFOR.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(0, listaInf.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(listaInf.ESPECIES_SERFOR.IndexOf('|') + 1, listaInf.ESPECIES_SERFOR.Length - listaInf.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                            }
                        }
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.PERIODO) ? "" : listaInf.PERIODO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.CUOTA_SACA.ToString()) ? "" : listaInf.CUOTA_SACA.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.METODO_CAZA) ? "" : listaInf.METODO_CAZA.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.SISTEMA_MARCAJE) ? "" : listaInf.SISTEMA_MARCAJE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.DENSIDAD.ToString()) ? "" : listaInf.DENSIDAD.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.PCA.ToString()) ? "" : listaInf.PCA.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.OBSERVACION.ToString()) ? "" : listaInf.OBSERVACION.ToString()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                #region PoaMaderableRAprobPMed_v3.xlsx
                case "PoaMaderableRAprobPMed_v3.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        if (string.IsNullOrEmpty(listaInf.ESPECIES))
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
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
                        }


                        if (string.IsNullOrEmpty(listaInf.ESPECIES_SERFOR))
                        {
                            insertar = insertar + ",'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            if (listaInf.ESPECIES_SERFOR.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(0, listaInf.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(listaInf.ESPECIES_SERFOR.IndexOf('|') + 1, listaInf.ESPECIES_SERFOR.Length - listaInf.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                            }
                        }
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.ABUNDANCIA.ToString()) ? "" : listaInf.ABUNDANCIA.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.NUMINDIVIDUOS.ToString()) ? "" : listaInf.NUMINDIVIDUOS.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.PESO.ToString()) ? "" : listaInf.PESO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.RENDIMIENTO.ToString()) ? "" : listaInf.RENDIMIENTO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.UNIDAD_MEDIDA) ? "" : listaInf.UNIDAD_MEDIDA.ToString().ToUpper()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.TIPOMADERABLE) ? "" : listaInf.TIPOMADERABLE.ToString().ToUpper()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.PCA ?? "") ? "" : listaInf.PCA.ToString().ToUpper()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.OBSERVACION.ToString()) ? "" : listaInf.OBSERVACION.ToString()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                #region PoaMaderableRAprobPCarr_v3.xlsx
                case "PoaMaderableRAprobPCarr_v3.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        if (string.IsNullOrEmpty(listaInf.ESPECIES))
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
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
                        }


                        if (string.IsNullOrEmpty(listaInf.ESPECIES_SERFOR))
                        {
                            insertar = insertar + ",'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            if (listaInf.ESPECIES_SERFOR.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(0, listaInf.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(listaInf.ESPECIES_SERFOR.IndexOf('|') + 1, listaInf.ESPECIES_SERFOR.Length - listaInf.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                            }
                        }
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.SuperficieHa.ToString()) ? "" : listaInf.SuperficieHa.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.CANTIDAD.ToString()) ? "" : listaInf.CANTIDAD.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.TIPOMADERABLE) ? "" : listaInf.TIPOMADERABLE.ToString().ToUpper()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.PCA ?? "".ToString()) ? "" : listaInf.PCA.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.OBSERVACION.ToString()) ? "" : listaInf.OBSERVACION.ToString()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                #region PoaNoMaderableBExtraccion_v2.xlsx
                case "PoaNoMaderableBExtraccion_v2.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        if (string.IsNullOrEmpty(listaInf.ESPECIES))
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
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
                        }
                        if (string.IsNullOrEmpty(listaInf.ESPECIES_SERFOR))
                        {
                            insertar = insertar + ",'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            if (listaInf.ESPECIES_SERFOR.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(0, listaInf.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(listaInf.ESPECIES_SERFOR.IndexOf('|') + 1, listaInf.ESPECIES_SERFOR.Length - listaInf.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                            }
                        }
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.KILOGRAMO_AUTORIZADO.ToString()) ? "" : listaInf.KILOGRAMO_AUTORIZADO.ToString().ToUpper()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.KILOGRAMO_MOVILIZADO.ToString()) ? "" : listaInf.KILOGRAMO_MOVILIZADO.ToString().ToUpper()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.SALDO.ToString()) ? "" : listaInf.SALDO.ToString().ToUpper()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.OBSERVACION.ToString()) ? "" : listaInf.OBSERVACION.ToString().ToUpper()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                #region PoaNoMaderablePMedBExtraccion_v2.xlsx
                case "PoaNoMaderablePMedBExtraccion_v2.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        if (string.IsNullOrEmpty(listaInf.ESPECIES))
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
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
                        }
                        if (string.IsNullOrEmpty(listaInf.ESPECIES_SERFOR))
                        {
                            insertar = insertar + ",'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            if (listaInf.ESPECIES_SERFOR.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(0, listaInf.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(listaInf.ESPECIES_SERFOR.IndexOf('|') + 1, listaInf.ESPECIES_SERFOR.Length - listaInf.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                            }
                        }

                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.AUTORIZADO.ToString()) ? "" : listaInf.AUTORIZADO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.EXTRAIDO.ToString()) ? "" : listaInf.EXTRAIDO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.SALDO.ToString()) ? "" : listaInf.SALDO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.UNIDAD_MEDIDA) ? "" : listaInf.UNIDAD_MEDIDA.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.OBSERVACION.ToString()) ? "" : listaInf.OBSERVACION.ToString()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                #region PoaNoMaderableCarrBExtraccion_v2.xlsx
                case "PoaNoMaderableCarrBExtraccion_v2.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        if (string.IsNullOrEmpty(listaInf.ESPECIES))
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
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
                        }

                        if (string.IsNullOrEmpty(listaInf.ESPECIES_SERFOR))
                        {
                            insertar = insertar + ",'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            if (listaInf.ESPECIES_SERFOR.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(0, listaInf.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(listaInf.ESPECIES_SERFOR.IndexOf('|') + 1, listaInf.ESPECIES_SERFOR.Length - listaInf.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                            }
                        }
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.FECHA1.ToString()) ? "" : listaInf.FECHA1.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.GUIA_TRANSPORTE) ? "" : listaInf.GUIA_TRANSPORTE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.FECHA2.ToString()) ? "" : listaInf.FECHA2.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.RECIBO) ? "" : listaInf.RECIBO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.SALDO.ToString()) ? "" : listaInf.SALDO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.CANTIDAD.ToString()) ? "" : listaInf.CANTIDAD.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.OBSERVACION.ToString()) ? "" : listaInf.OBSERVACION.ToString()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                #region PoaNoMaderableCarrBExtraccion_v2.xlsx
                case "PoaMaderableRAprobPCarr_v2.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        if (string.IsNullOrEmpty(listaInf.ESPECIES))
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
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
                        }

                        if (string.IsNullOrEmpty(listaInf.ESPECIES_SERFOR))
                        {
                            insertar = insertar + ",'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            if (listaInf.ESPECIES_SERFOR.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {

                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(0, listaInf.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(listaInf.ESPECIES_SERFOR.IndexOf('|') + 1, listaInf.ESPECIES_SERFOR.Length - listaInf.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                            }
                        }
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.SuperficieHa.ToString()) ? "" : listaInf.SuperficieHa.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.CANTIDAD.ToString()) ? "" : listaInf.CANTIDAD.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.TIPOMADERABLE) ? "" : listaInf.TIPOMADERABLE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.OBSERVACION.ToString()) ? "" : listaInf.OBSERVACION.ToString()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                #region PoaInSituBExtraccion_v2.xlsx
                case "PoaInSituBExtraccion_v2.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        if (string.IsNullOrEmpty(listaInf.ESPECIES))
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
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
                        }
                        if (string.IsNullOrEmpty(listaInf.ESPECIES_SERFOR))
                        {
                            insertar = insertar + ",'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            if (listaInf.ESPECIES_SERFOR.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(0, listaInf.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(listaInf.ESPECIES_SERFOR.IndexOf('|') + 1, listaInf.ESPECIES_SERFOR.Length - listaInf.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                            }
                        }
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.CANTIDAD_AUTORIZADO.ToString()) ? "" : listaInf.CANTIDAD_AUTORIZADO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.CANTIDAD_MOVILIZADO.ToString()) ? "" : listaInf.CANTIDAD_MOVILIZADO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.SALDO.ToString()) ? "" : listaInf.SALDO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.OBSERVACION.ToString()) ? "" : listaInf.OBSERVACION.ToString()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion

                //Maderable-No Maderable
                #region PoaMaderableBExtraccion_v3.xlsx
                case "PoaMaderableBExtraccion_v3.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        if (string.IsNullOrEmpty(listaInf.ESPECIES))
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
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
                        }

                        if (string.IsNullOrEmpty(listaInf.ESPECIES_SERFOR))
                        {
                            insertar = insertar + ",'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            if (listaInf.ESPECIES_SERFOR.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(0, listaInf.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(listaInf.ESPECIES_SERFOR.IndexOf('|') + 1, listaInf.ESPECIES_SERFOR.Length - listaInf.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                            }
                        }
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.DMC.ToString()) ? "" : listaInf.DMC.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.TOTAL_ARBOLES.ToString()) ? "" : listaInf.TOTAL_ARBOLES.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.VOLUMEN_AUTORIZADO.ToString()) ? "" : listaInf.VOLUMEN_AUTORIZADO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.VOLUMEN_MOVILIZADO.ToString()) ? "" : listaInf.VOLUMEN_MOVILIZADO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.SALDO.ToString()) ? "" : listaInf.SALDO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.TIPOMADERABLE) ? "" : listaInf.TIPOMADERABLE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.OBSERVACION.ToString()) ? "" : listaInf.OBSERVACION.ToString()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                #region PoaNoMaderablePMedBExtraccion_v3.xlsx
                case "PoaNoMaderablePMedBExtraccion_v3.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        if (string.IsNullOrEmpty(listaInf.ESPECIES))
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
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
                        }
                        if (string.IsNullOrEmpty(listaInf.ESPECIES_SERFOR))
                        {
                            insertar = insertar + ",'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            if (listaInf.ESPECIES_SERFOR.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(0, listaInf.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(listaInf.ESPECIES_SERFOR.IndexOf('|') + 1, listaInf.ESPECIES_SERFOR.Length - listaInf.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                            }
                        }

                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.AUTORIZADO.ToString()) ? "" : listaInf.AUTORIZADO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.EXTRAIDO.ToString()) ? "" : listaInf.EXTRAIDO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.SALDO.ToString()) ? "" : listaInf.SALDO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.OBSERVACION.ToString()) ? "" : listaInf.OBSERVACION.ToString()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                #region PoaNoMaderableCarrBExtraccion_v3.xlsx
                case "PoaNoMaderableCarrBExtraccion_v3.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        if (string.IsNullOrEmpty(listaInf.ESPECIES))
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
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
                        }

                        if (string.IsNullOrEmpty(listaInf.ESPECIES_SERFOR))
                        {
                            insertar = insertar + ",'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            if (listaInf.ESPECIES_SERFOR.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(0, listaInf.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(listaInf.ESPECIES_SERFOR.IndexOf('|') + 1, listaInf.ESPECIES_SERFOR.Length - listaInf.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                            }
                        }
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.FECHA1.ToString()) ? "" : listaInf.FECHA1.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.GUIA_TRANSPORTE) ? "" : listaInf.GUIA_TRANSPORTE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.FECHA2.ToString()) ? "" : listaInf.FECHA2.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.RECIBO) ? "" : listaInf.RECIBO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.SALDO.ToString()) ? "" : listaInf.SALDO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.CANTIDAD.ToString()) ? "" : listaInf.CANTIDAD.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.OBSERVACION.ToString()) ? "" : listaInf.OBSERVACION.ToString()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                #region PoaNoMaderableBExtraccion_v3.xlsx
                case "PoaNoMaderableBExtraccion_v3.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        if (string.IsNullOrEmpty(listaInf.ESPECIES))
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
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
                        }
                        if (string.IsNullOrEmpty(listaInf.ESPECIES_SERFOR))
                        {
                            insertar = insertar + ",'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            if (listaInf.ESPECIES_SERFOR.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(0, listaInf.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(listaInf.ESPECIES_SERFOR.IndexOf('|') + 1, listaInf.ESPECIES_SERFOR.Length - listaInf.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                            }
                        }
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.VOLUMEN_AUTORIZADO.ToString()) ? "" : listaInf.VOLUMEN_AUTORIZADO.ToString().ToUpper()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.VOLUMEN_MOVILIZADO.ToString()) ? "" : listaInf.VOLUMEN_MOVILIZADO.ToString().ToUpper()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.SALDO.ToString()) ? "" : listaInf.SALDO.ToString().ToUpper()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.OBSERVACION.ToString()) ? "" : listaInf.OBSERVACION.ToString().ToUpper()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                #region PoaMadNoMadPMedBExtraccion_v3.xlsx
                case "PoaMadNoMadPMedBExtraccion_v3.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        if (string.IsNullOrEmpty(listaInf.ESPECIES))
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
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
                        }

                        if (string.IsNullOrEmpty(listaInf.ESPECIES_SERFOR))
                        {
                            insertar = insertar + ",'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            if (listaInf.ESPECIES_SERFOR.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(0, listaInf.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(listaInf.ESPECIES_SERFOR.IndexOf('|') + 1, listaInf.ESPECIES_SERFOR.Length - listaInf.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                            }
                        }
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.TIPOMADERABLE) ? "" : listaInf.TIPOMADERABLE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.DMC.ToString()) ? "" : listaInf.DMC.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.TOTAL_ARBOLES.ToString()) ? "" : listaInf.TOTAL_ARBOLES.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.VOLUMEN_AUTORIZADO.ToString()) ? "" : listaInf.VOLUMEN_AUTORIZADO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.VOLUMEN_MOVILIZADO.ToString()) ? "" : listaInf.VOLUMEN_MOVILIZADO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.AUTORIZADO.ToString()) ? "" : listaInf.AUTORIZADO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.EXTRAIDO.ToString()) ? "" : listaInf.EXTRAIDO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.SALDO.ToString()) ? "" : listaInf.SALDO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.OBSERVACION.ToString()) ? "" : listaInf.OBSERVACION.ToString()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                #region PoaMadNoMadCarrBExtraccion_v3.xlsx
                case "PoaMadNoMadCarrBExtraccion_v3.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        if (string.IsNullOrEmpty(listaInf.ESPECIES))
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
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
                        }

                        if (string.IsNullOrEmpty(listaInf.ESPECIES_SERFOR))
                        {
                            insertar = insertar + ",'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            if (listaInf.ESPECIES_SERFOR.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(0, listaInf.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(listaInf.ESPECIES_SERFOR.IndexOf('|') + 1, listaInf.ESPECIES_SERFOR.Length - listaInf.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                            }
                        }
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.TIPOMADERABLE) ? "" : listaInf.TIPOMADERABLE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.DMC.ToString()) ? "" : listaInf.DMC.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.TOTAL_ARBOLES.ToString()) ? "" : listaInf.TOTAL_ARBOLES.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.VOLUMEN_AUTORIZADO.ToString()) ? "" : listaInf.VOLUMEN_AUTORIZADO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.VOLUMEN_MOVILIZADO.ToString()) ? "" : listaInf.VOLUMEN_MOVILIZADO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.FECHA1.ToString()) ? "" : listaInf.FECHA1.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.GUIA_TRANSPORTE) ? "" : listaInf.GUIA_TRANSPORTE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.FECHA2.ToString()) ? "" : listaInf.FECHA2.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.RECIBO) ? "" : listaInf.RECIBO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.SALDO.ToString()) ? "" : listaInf.SALDO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.CANTIDAD.ToString()) ? "" : listaInf.CANTIDAD.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.OBSERVACION.ToString()) ? "" : listaInf.OBSERVACION.ToString()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                #endregion
                #region PoaMadNoMadBExtraccion_v3.xlsx
                case "PoaMadNoMadBExtraccion_v3.xlsx":
                    foreach (var listaInf in listaParam)
                    {
                        insertar = "";
                        if (string.IsNullOrEmpty(listaInf.ESPECIES))
                        {
                            insertar = insertar + "'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
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
                        }

                        if (string.IsNullOrEmpty(listaInf.ESPECIES_SERFOR))
                        {
                            insertar = insertar + ",'" + "" + "'";
                            insertar = insertar + ",'" + "" + "'";
                        }
                        else
                        {
                            if (listaInf.ESPECIES_SERFOR.Trim().Length <= 1)
                            {
                                insertar = insertar + ",'" + "" + "'";
                                insertar = insertar + ",'" + "" + "'";
                            }
                            else
                            {
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(0, listaInf.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                insertar = insertar + ",'" + listaInf.ESPECIES_SERFOR.Substring(listaInf.ESPECIES_SERFOR.IndexOf('|') + 1, listaInf.ESPECIES_SERFOR.Length - listaInf.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                            }
                        }
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.TIPOMADERABLE) ? "" : listaInf.TIPOMADERABLE.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.DMC.ToString()) ? "" : listaInf.DMC.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.TOTAL_ARBOLES.ToString()) ? "" : listaInf.TOTAL_ARBOLES.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.VOLUMEN_AUTORIZADO.ToString()) ? "" : listaInf.VOLUMEN_AUTORIZADO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.VOLUMEN_MOVILIZADO.ToString()) ? "" : listaInf.VOLUMEN_MOVILIZADO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.SALDO.ToString()) ? "" : listaInf.SALDO.ToString()) + "'";
                        insertar = insertar + ",'" + (string.IsNullOrEmpty(listaInf.OBSERVACION.ToString()) ? "" : listaInf.OBSERVACION.ToString()) + "'";
                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (listaParam.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                        cmd.ExecuteNonQuery();
                    }
                    break;
                    #endregion
            }
        }


        //nuevo
        public static ListResult DescargaExcel(VModel vModel)
        {
            string nombreFile = "";
            string directorio = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");

            nombreFile = DateTime.Now.Year.ToString() +
                DateTime.Now.Month.ToString() +
                DateTime.Now.Day.ToString() +
                DateTime.Now.Hour.ToString() +
                DateTime.Now.Minute.ToString() +
                DateTime.Now.Second.ToString() +
                DateTime.Now.Millisecond.ToString() + ".xlsx";

            ListResult result = new ListResult();
            try
            {
                string nomPlantilla = "";

                if (vModel.TVentana == "CMADE")
                    nomPlantilla = "PoaMaderable_Censo_v2.xlsx";
                if (vModel.TVentana == "CNOMADE")
                    nomPlantilla = "PoaNoMaderable_Censo_v2.xlsx";

                FileInfo template = new FileInfo(directorio + nomPlantilla);
                int rowStart = 2;
                using (var package = new ExcelPackage(template))
                {
                    var workbook = package.Workbook;
                    ExcelWorksheet worksheet = workbook.Worksheets.First();

                    if (vModel != null)
                    {
                        int column = 0;
                        switch (nomPlantilla)
                        {
                            case "PoaMaderable_Censo_v2.xlsx":
                                foreach (var item in vModel.ListMadeCENSO)
                                {
                                    column = 0;

                                    string[] especies = (item.ESPECIES ?? "").Split('|');
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = especies.Length > 0 ? especies[0] : "";
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = especies.Length > 1 ? especies[1] : "";
                                    string[] especies_areresolucion = (item.ESPECIES_ARESOLUCION ?? "").Split('|');
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = especies_areresolucion.Length > 0 ? especies_areresolucion[0] : "";
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = especies_areresolucion.Length > 1 ? especies_areresolucion[1] : "";
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.BLOQUE;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.FAJA;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.CODIGO;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.VOLUMEN.ToString();
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.DAP.ToString();
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.AC.ToString();
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.DMC.ToString();
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.CONDICION;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.ESTADO;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.ZONA;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.COORDENADA_ESTE.ToString();
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.COORDENADA_NORTE.ToString();
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PCA.ToString();
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.OBSERVACION;
                                    rowStart++;
                                }
                                break;
                            case "PoaNoMaderable_Censo_v2.xlsx":
                                foreach (var item in vModel.ListNoMadeCENSO)
                                {
                                    column = 0;

                                    string[] especies = (item.ESPECIES ?? "").Split('|');
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = especies.Length > 0 ? especies[0] : "";
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = especies.Length > 1 ? especies[1] : "";
                                    string[] especies_areresolucion = (item.ESPECIES_ARESOLUCION ?? "").Split('|');
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = especies_areresolucion.Length > 0 ? especies_areresolucion[0] : "";
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = especies_areresolucion.Length > 1 ? especies_areresolucion[1] : "";
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.NUM_ESTRADA;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.CODIGO;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.DIAMETRO.ToString();
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.ALTURA.ToString();
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PRODUCCION_LATAS.ToString();
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.CONDICION;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.ZONA;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.COORDENADA_ESTE.ToString();
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.COORDENADA_NORTE.ToString();
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.OBSERVACION;
                                    rowStart++;
                                }
                                break;
                        }

                        package.SaveAs(new FileInfo(directorio + nombreFile));

                    }

                    List<string> lstResult = new List<string> { nombreFile };
                    result.AddResultado("Ok", true, lstResult);

                }
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);

            }
            return result;
        }
        //nuevo
        public static ListResult DescargaExcelCENSO(List<Ent_BUSQUEDA> vModel)
        {
            string nombreFile = "";
            string directorio = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");

            nombreFile = DateTime.Now.Year.ToString() +
                DateTime.Now.Month.ToString() +
                DateTime.Now.Day.ToString() +
                DateTime.Now.Hour.ToString() +
                DateTime.Now.Minute.ToString() +
                DateTime.Now.Second.ToString() +
                DateTime.Now.Millisecond.ToString() + ".xlsx";

            ListResult result = new ListResult();
            try
            {
                string nomPlantilla = "";

                //if (vModel.TVentana == "CMADE")
                //    nomPlantilla = "PoaMaderable_Censo_v2.xlsx";
                //if (vModel.TVentana == "CNOMADE")
                nomPlantilla = "PoaMaderable_Censo_v2.xlsx";

                FileInfo template = new FileInfo(directorio + nomPlantilla);
                int rowStart = 2;
                using (var package = new ExcelPackage(template))
                {
                    var workbook = package.Workbook;
                    ExcelWorksheet worksheet = workbook.Worksheets.First();

                    if (vModel.Count > 0)
                    {
                        int column = 0;
                        switch (nomPlantilla)
                        {
                            case "PoaMaderable_Censo_v2.xlsx":
                                foreach (var item in vModel)
                                {
                                    column = 0;

                                    //string[] especies = (item.ESPECIES ?? "").Split('|');
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PARAMETRO06;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PARAMETRO05;
                                    //string[] especies_areresolucion = (item.ESPECIES_ARESOLUCION ?? "").Split('|');
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = "";
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = "";
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PARAMETRO02;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PARAMETRO03;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PARAMETRO04;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PARAMETRO12;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PARAMETRO07;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PARAMETRO08;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PARAMETRO09;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PARAMETRO13;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = "";
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = "";
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PARAMETRO10;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PARAMETRO11;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PARAMETRO15;
                                    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = "";
                                    rowStart++;
                                }
                                break;
                            case "PoaNoMaderable_Censo_v2.xlsx":
                                //foreach (var item in vModel.ListNoMadeCENSO)
                                //{
                                //    column = 0;

                                //    string[] especies = (item.ESPECIES ?? "").Split('|');
                                //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = especies.Length > 0 ? especies[0] : "";
                                //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = especies.Length > 1 ? especies[1] : "";
                                //    string[] especies_areresolucion = (item.ESPECIES_ARESOLUCION ?? "").Split('|');
                                //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = especies_areresolucion.Length > 0 ? especies_areresolucion[0] : "";
                                //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = especies_areresolucion.Length > 1 ? especies_areresolucion[1] : "";
                                //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.NUM_ESTRADA;
                                //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.CODIGO;
                                //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.DIAMETRO.ToString();
                                //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.ALTURA.ToString();
                                //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.PRODUCCION_LATAS.ToString();
                                //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.CONDICION;
                                //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.ZONA;
                                //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.COORDENADA_ESTE.ToString();
                                //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.COORDENADA_NORTE.ToString();
                                //    worksheet.Cells[HelperSigo.GetColum(++column) + rowStart.ToString()].Value = item.OBSERVACION;
                                //    rowStart++;
                                //}
                                break;
                        }

                        package.SaveAs(new FileInfo(directorio + nombreFile));

                    }

                    List<string> lstResult = new List<string> { nombreFile };
                    result.AddResultado("Ok", true, lstResult);

                }
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);

            }
            return result;
        }
    }
}