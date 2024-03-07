using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;

namespace SIGOFCv3.Areas.THabilitante.Models.ManBalanceExtraccion
{
    public class ExportarDatos
    {
        public static ListResult BExtraccionMaderable(List<Ent_BEXTRACCION_MADE> olMaderable, string asCodMTipo, string asEstadoOrigen, string asIndicador)
        {
            ListResult result = new ListResult();

            try
            {
                if (olMaderable.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = "";
                    string nomPlantilla = "";

                    //string[] lst_estado_origen_1 = { "ADECU", "REFOR", "REAJU", "PMFI", "PN", "DEMA" };
                    string[] lst_estado_origen_2 = { "R", "MS", "PC" };

                    /*if (
                        (asEstadoOrigen == "PN" && asIndicador == "M") ||
                        lst_estado_origen_2.Any(x => x == asEstadoOrigen)
                        )
                    {
                        nomPlantilla = "PoaMaderableBExtraccion_v3.xlsx";
                    }
                    else if (
                        (asEstadoOrigen == "PN" && asIndicador == "NM") ||
                        asEstadoOrigen == "PCN" ||
                        (asEstadoOrigen == "DEMA" && asIndicador != "M")                        
                        )
                    {
                        if (asCodMTipo == "0000021")
                        {//Planta medicinal
                            nomPlantilla = "PoaNoMaderablePMedBExtraccion_v3.xlsx";
                        }
                        else if (asCodMTipo == "0000020")
                        {//Carrizo
                            nomPlantilla = "PoaNoMaderableCarrBExtraccion_v3.xlsx";
                        }
                        else
                        {//Normal
                            nomPlantilla = "PoaNoMaderableBExtraccion_v3.xlsx";
                        }
                    }
                    else
                    {*/
                        if (asCodMTipo == "0000021")
                        {
                            nomPlantilla = "PoaMadNoMadPMedBExtraccion_v3.xlsx";
                        }
                        else if (asCodMTipo == "0000020")
                        {
                            nomPlantilla = "PoaMadNoMadCarrBExtraccion_v3.xlsx";
                        }
                        else
                        {
                            nomPlantilla = "PoaMadNoMadBExtraccion_v3.xlsx";
                        }
                    //}

                    rutaExcelBase = rutaBase + nomPlantilla;

                    try
                    {
                        File.Delete(@rutaExcel);
                        File.Copy(@rutaExcelBase, @rutaExcel);
                    }
                    catch (IOException ix)
                    {
                        throw new Exception(ix.Message);
                    }

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
                            string insertar = "";
                            int i = 1;

                            switch (nomPlantilla)
                            {
                                #region PoaMaderableBExtraccion_v3.xlsx
                                case "PoaMaderableBExtraccion_v3.xlsx":
                                    foreach (var item in olMaderable)
                                    {
                                        insertar = "";
                                        if (string.IsNullOrEmpty(item.ESPECIES))
                                        {
                                            insertar = insertar + "'" + "" + "'";
                                            insertar = insertar + ",'" + "" + "'";
                                        }
                                        else
                                        {
                                            if (item.ESPECIES.Trim().Length <= 1)
                                            {
                                                insertar = insertar + "'" + "" + "'";
                                                insertar = insertar + ",'" + "" + "'";
                                            }
                                            else
                                            {
                                                insertar = insertar + "'" + item.ESPECIES.Substring(0, item.ESPECIES.IndexOf('|')).Trim() + "'";
                                                insertar = insertar + ",'" + item.ESPECIES.Substring(item.ESPECIES.IndexOf('|') + 1, item.ESPECIES.Length - item.ESPECIES.IndexOf('|') - 1).Trim() + "'";
                                            }
                                        }

                                        if (string.IsNullOrEmpty(item.ESPECIES_SERFOR))
                                        {
                                            insertar = insertar + ",'" + "" + "'";
                                            insertar = insertar + ",'" + "" + "'";
                                        }
                                        else
                                        {
                                            if (item.ESPECIES_SERFOR.Trim().Length <= 1)
                                            {
                                                insertar = insertar + ",'" + "" + "'";
                                                insertar = insertar + ",'" + "" + "'";
                                            }
                                            else
                                            {
                                                insertar = insertar + ",'" + item.ESPECIES_SERFOR.Substring(0, item.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                                insertar = insertar + ",'" + item.ESPECIES_SERFOR.Substring(item.ESPECIES_SERFOR.IndexOf('|') + 1, item.ESPECIES_SERFOR.Length - item.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                                            }
                                        }
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.DMC.ToString()) ? "" : item.DMC.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.TOTAL_ARBOLES.ToString()) ? "" : item.TOTAL_ARBOLES.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.VOLUMEN_AUTORIZADO.ToString()) ? "" : item.VOLUMEN_AUTORIZADO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.VOLUMEN_MOVILIZADO.ToString()) ? "" : item.VOLUMEN_MOVILIZADO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.SALDO.ToString()) ? "" : item.SALDO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.TIPOMADERABLE) ? "" : item.TIPOMADERABLE.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.OBSERVACION.ToString()) ? "" : item.OBSERVACION.ToString()) + "'";
                                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (olMaderable.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                        cmd.ExecuteNonQuery();
                                    }
                                    break;
                                #endregion
                                #region PoaNoMaderablePMedBExtraccion_v3.xlsx
                                case "PoaNoMaderablePMedBExtraccion_v3.xlsx":
                                    foreach (var item in olMaderable)
                                    {
                                        insertar = "";
                                        if (string.IsNullOrEmpty(item.ESPECIES))
                                        {
                                            insertar = insertar + "'" + "" + "'";
                                            insertar = insertar + ",'" + "" + "'";
                                        }
                                        else
                                        {
                                            if (item.ESPECIES.Trim().Length <= 1)
                                            {
                                                insertar = insertar + "'" + "" + "'";
                                                insertar = insertar + ",'" + "" + "'";
                                            }
                                            else
                                            {
                                                insertar = insertar + "'" + item.ESPECIES.Substring(0, item.ESPECIES.IndexOf('|')).Trim() + "'";
                                                insertar = insertar + ",'" + item.ESPECIES.Substring(item.ESPECIES.IndexOf('|') + 1, item.ESPECIES.Length - item.ESPECIES.IndexOf('|') - 1).Trim() + "'";
                                            }
                                        }
                                        if (string.IsNullOrEmpty(item.ESPECIES_SERFOR))
                                        {
                                            insertar = insertar + ",'" + "" + "'";
                                            insertar = insertar + ",'" + "" + "'";
                                        }
                                        else
                                        {
                                            if (item.ESPECIES_SERFOR.Trim().Length <= 1)
                                            {
                                                insertar = insertar + ",'" + "" + "'";
                                                insertar = insertar + ",'" + "" + "'";
                                            }
                                            else
                                            {
                                                insertar = insertar + ",'" + item.ESPECIES_SERFOR.Substring(0, item.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                                insertar = insertar + ",'" + item.ESPECIES_SERFOR.Substring(item.ESPECIES_SERFOR.IndexOf('|') + 1, item.ESPECIES_SERFOR.Length - item.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                                            }
                                        }

                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.AUTORIZADO.ToString()) ? "" : item.AUTORIZADO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.EXTRAIDO.ToString()) ? "" : item.EXTRAIDO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.SALDO.ToString()) ? "" : item.SALDO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.OBSERVACION.ToString()) ? "" : item.OBSERVACION.ToString()) + "'";
                                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (olMaderable.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                        cmd.ExecuteNonQuery();
                                    }
                                    break;
                                #endregion
                                #region PoaNoMaderableCarrBExtraccion_v3.xlsx
                                case "PoaNoMaderableCarrBExtraccion_v3.xlsx":
                                    foreach (var item in olMaderable)
                                    {
                                        insertar = "";
                                        if (string.IsNullOrEmpty(item.ESPECIES))
                                        {
                                            insertar = insertar + "'" + "" + "'";
                                            insertar = insertar + ",'" + "" + "'";
                                        }
                                        else
                                        {
                                            if (item.ESPECIES.Trim().Length <= 1)
                                            {
                                                insertar = insertar + "'" + "" + "'";
                                                insertar = insertar + ",'" + "" + "'";
                                            }
                                            else
                                            {
                                                insertar = insertar + "'" + item.ESPECIES.Substring(0, item.ESPECIES.IndexOf('|')).Trim() + "'";
                                                insertar = insertar + ",'" + item.ESPECIES.Substring(item.ESPECIES.IndexOf('|') + 1, item.ESPECIES.Length - item.ESPECIES.IndexOf('|') - 1).Trim() + "'";

                                            }
                                        }

                                        if (string.IsNullOrEmpty(item.ESPECIES_SERFOR))
                                        {
                                            insertar = insertar + ",'" + "" + "'";
                                            insertar = insertar + ",'" + "" + "'";
                                        }
                                        else
                                        {
                                            if (item.ESPECIES_SERFOR.Trim().Length <= 1)
                                            {
                                                insertar = insertar + ",'" + "" + "'";
                                                insertar = insertar + ",'" + "" + "'";
                                            }
                                            else
                                            {
                                                insertar = insertar + ",'" + item.ESPECIES_SERFOR.Substring(0, item.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                                insertar = insertar + ",'" + item.ESPECIES_SERFOR.Substring(item.ESPECIES_SERFOR.IndexOf('|') + 1, item.ESPECIES_SERFOR.Length - item.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                                            }
                                        }
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.FECHA1.ToString()) ? "" : item.FECHA1.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.GUIA_TRANSPORTE) ? "" : item.GUIA_TRANSPORTE.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.FECHA2.ToString()) ? "" : item.FECHA2.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.RECIBO) ? "" : item.RECIBO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.SALDO.ToString()) ? "" : item.SALDO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.CANTIDAD.ToString()) ? "" : item.CANTIDAD.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.OBSERVACION.ToString()) ? "" : item.OBSERVACION.ToString()) + "'";
                                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (olMaderable.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                        cmd.ExecuteNonQuery();
                                    }
                                    break;
                                #endregion
                                #region PoaNoMaderableBExtraccion_v3.xlsx
                                case "PoaNoMaderableBExtraccion_v3.xlsx":
                                    foreach (var item in olMaderable)
                                    {
                                        insertar = "";
                                        if (string.IsNullOrEmpty(item.ESPECIES))
                                        {
                                            insertar = insertar + "'" + "" + "'";
                                            insertar = insertar + ",'" + "" + "'";
                                        }
                                        else
                                        {
                                            if (item.ESPECIES.Trim().Length <= 1)
                                            {
                                                insertar = insertar + "'" + "" + "'";
                                                insertar = insertar + ",'" + "" + "'";
                                            }
                                            else
                                            {
                                                insertar = insertar + "'" + item.ESPECIES.Substring(0, item.ESPECIES.IndexOf('|')).Trim() + "'";
                                                insertar = insertar + ",'" + item.ESPECIES.Substring(item.ESPECIES.IndexOf('|') + 1, item.ESPECIES.Length - item.ESPECIES.IndexOf('|') - 1).Trim() + "'";
                                            }
                                        }
                                        if (string.IsNullOrEmpty(item.ESPECIES_SERFOR))
                                        {
                                            insertar = insertar + ",'" + "" + "'";
                                            insertar = insertar + ",'" + "" + "'";
                                        }
                                        else
                                        {
                                            if (item.ESPECIES_SERFOR.Trim().Length <= 1)
                                            {
                                                insertar = insertar + ",'" + "" + "'";
                                                insertar = insertar + ",'" + "" + "'";
                                            }
                                            else
                                            {
                                                insertar = insertar + ",'" + item.ESPECIES_SERFOR.Substring(0, item.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                                insertar = insertar + ",'" + item.ESPECIES_SERFOR.Substring(item.ESPECIES_SERFOR.IndexOf('|') + 1, item.ESPECIES_SERFOR.Length - item.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                                            }
                                        }
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.TOTAL_ARBOLES.ToString()) ? "" : item.TOTAL_ARBOLES.ToString().ToUpper()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.VOLUMEN_AUTORIZADO.ToString()) ? "" : item.VOLUMEN_AUTORIZADO.ToString().ToUpper()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.VOLUMEN_MOVILIZADO.ToString()) ? "" : item.VOLUMEN_MOVILIZADO.ToString().ToUpper()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.SALDO.ToString()) ? "" : item.SALDO.ToString().ToUpper()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.OBSERVACION.ToString()) ? "" : item.OBSERVACION.ToString().ToUpper()) + "'";
                                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (olMaderable.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                        cmd.ExecuteNonQuery();
                                    }
                                    break;
                                #endregion
                                #region PoaMadNoMadPMedBExtraccion_v3.xlsx
                                case "PoaMadNoMadPMedBExtraccion_v3.xlsx":
                                    foreach (var item in olMaderable)
                                    {
                                        insertar = "";
                                        if (string.IsNullOrEmpty(item.ESPECIES))
                                        {
                                            insertar = insertar + "'" + "" + "'";
                                            insertar = insertar + ",'" + "" + "'";
                                        }
                                        else
                                        {
                                            if (item.ESPECIES.Trim().Length <= 1)
                                            {
                                                insertar = insertar + "'" + "" + "'";
                                                insertar = insertar + ",'" + "" + "'";
                                            }
                                            else
                                            {
                                                insertar = insertar + "'" + item.ESPECIES.Substring(0, item.ESPECIES.IndexOf('|')).Trim() + "'";
                                                insertar = insertar + ",'" + item.ESPECIES.Substring(item.ESPECIES.IndexOf('|') + 1, item.ESPECIES.Length - item.ESPECIES.IndexOf('|') - 1).Trim() + "'";
                                            }
                                        }

                                        if (string.IsNullOrEmpty(item.ESPECIES_SERFOR))
                                        {
                                            insertar = insertar + ",'" + "" + "'";
                                            insertar = insertar + ",'" + "" + "'";
                                        }
                                        else
                                        {
                                            if (item.ESPECIES_SERFOR.Trim().Length <= 1)
                                            {
                                                insertar = insertar + ",'" + "" + "'";
                                                insertar = insertar + ",'" + "" + "'";
                                            }
                                            else
                                            {
                                                insertar = insertar + ",'" + item.ESPECIES_SERFOR.Substring(0, item.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                                insertar = insertar + ",'" + item.ESPECIES_SERFOR.Substring(item.ESPECIES_SERFOR.IndexOf('|') + 1, item.ESPECIES_SERFOR.Length - item.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                                            }
                                        }
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.TIPOMADERABLE) ? "" : item.TIPOMADERABLE.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.DMC.ToString()) ? "" : item.DMC.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.TOTAL_ARBOLES.ToString()) ? "" : item.TOTAL_ARBOLES.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.VOLUMEN_AUTORIZADO.ToString()) ? "" : item.VOLUMEN_AUTORIZADO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.VOLUMEN_MOVILIZADO.ToString()) ? "" : item.VOLUMEN_MOVILIZADO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.AUTORIZADO.ToString()) ? "" : item.AUTORIZADO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.EXTRAIDO.ToString()) ? "" : item.EXTRAIDO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.SALDO.ToString()) ? "" : item.SALDO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.OBSERVACION.ToString()) ? "" : item.OBSERVACION.ToString()) + "'";
                                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (olMaderable.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                        cmd.ExecuteNonQuery();
                                    }
                                    break;
                                #endregion
                                #region PoaMadNoMadCarrBExtraccion_v3.xlsx
                                case "PoaMadNoMadCarrBExtraccion_v3.xlsx":
                                    foreach (var item in olMaderable)
                                    {
                                        insertar = "";
                                        if (string.IsNullOrEmpty(item.ESPECIES))
                                        {
                                            insertar = insertar + "'" + "" + "'";
                                            insertar = insertar + ",'" + "" + "'";
                                        }
                                        else
                                        {
                                            if (item.ESPECIES.Trim().Length <= 1)
                                            {
                                                insertar = insertar + "'" + "" + "'";
                                                insertar = insertar + ",'" + "" + "'";
                                            }
                                            else
                                            {
                                                insertar = insertar + "'" + item.ESPECIES.Substring(0, item.ESPECIES.IndexOf('|')).Trim() + "'";
                                                insertar = insertar + ",'" + item.ESPECIES.Substring(item.ESPECIES.IndexOf('|') + 1, item.ESPECIES.Length - item.ESPECIES.IndexOf('|') - 1).Trim() + "'";
                                            }
                                        }

                                        if (string.IsNullOrEmpty(item.ESPECIES_SERFOR))
                                        {
                                            insertar = insertar + ",'" + "" + "'";
                                            insertar = insertar + ",'" + "" + "'";
                                        }
                                        else
                                        {
                                            if (item.ESPECIES_SERFOR.Trim().Length <= 1)
                                            {
                                                insertar = insertar + ",'" + "" + "'";
                                                insertar = insertar + ",'" + "" + "'";
                                            }
                                            else
                                            {
                                                insertar = insertar + ",'" + item.ESPECIES_SERFOR.Substring(0, item.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                                insertar = insertar + ",'" + item.ESPECIES_SERFOR.Substring(item.ESPECIES_SERFOR.IndexOf('|') + 1, item.ESPECIES_SERFOR.Length - item.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                                            }
                                        }
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.TIPOMADERABLE) ? "" : item.TIPOMADERABLE.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.DMC.ToString()) ? "" : item.DMC.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.TOTAL_ARBOLES.ToString()) ? "" : item.TOTAL_ARBOLES.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.VOLUMEN_AUTORIZADO.ToString()) ? "" : item.VOLUMEN_AUTORIZADO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.VOLUMEN_MOVILIZADO.ToString()) ? "" : item.VOLUMEN_MOVILIZADO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.FECHA1.ToString()) ? "" : item.FECHA1.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.GUIA_TRANSPORTE) ? "" : item.GUIA_TRANSPORTE.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.FECHA2.ToString()) ? "" : item.FECHA2.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.RECIBO) ? "" : item.RECIBO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.SALDO.ToString()) ? "" : item.SALDO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.CANTIDAD.ToString()) ? "" : item.CANTIDAD.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.OBSERVACION.ToString()) ? "" : item.OBSERVACION.ToString()) + "'";
                                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (olMaderable.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                        cmd.ExecuteNonQuery();
                                    }
                                    break;
                                #endregion
                                #region PoaMadNoMadBExtraccion_v3.xlsx
                                case "PoaMadNoMadBExtraccion_v3.xlsx":
                                    foreach (var item in olMaderable)
                                    {
                                        insertar = "";
                                        if (string.IsNullOrEmpty(item.ESPECIES))
                                        {
                                            insertar = insertar + "'" + "" + "'";
                                            insertar = insertar + ",'" + "" + "'";
                                        }
                                        else
                                        {
                                            if (item.ESPECIES.Trim().Length <= 1)
                                            {
                                                insertar = insertar + "'" + "" + "'";
                                                insertar = insertar + ",'" + "" + "'";
                                            }
                                            else
                                            {
                                                insertar = insertar + "'" + item.ESPECIES.Substring(0, item.ESPECIES.IndexOf('|')).Trim() + "'";
                                                insertar = insertar + ",'" + item.ESPECIES.Substring(item.ESPECIES.IndexOf('|') + 1, item.ESPECIES.Length - item.ESPECIES.IndexOf('|') - 1).Trim() + "'";
                                            }
                                        }

                                        if (string.IsNullOrEmpty(item.ESPECIES_SERFOR))
                                        {
                                            insertar = insertar + ",'" + "" + "'";
                                            insertar = insertar + ",'" + "" + "'";
                                        }
                                        else
                                        {
                                            if (item.ESPECIES_SERFOR.Trim().Length <= 1)
                                            {
                                                insertar = insertar + ",'" + "" + "'";
                                                insertar = insertar + ",'" + "" + "'";
                                            }
                                            else
                                            {
                                                insertar = insertar + ",'" + item.ESPECIES_SERFOR.Substring(0, item.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                                insertar = insertar + ",'" + item.ESPECIES_SERFOR.Substring(item.ESPECIES_SERFOR.IndexOf('|') + 1, item.ESPECIES_SERFOR.Length - item.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                                            }
                                        }
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.TIPOMADERABLE) ? "" : item.TIPOMADERABLE.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.DMC.ToString()) ? "" : item.DMC.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.TOTAL_ARBOLES.ToString()) ? "" : item.TOTAL_ARBOLES.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.VOLUMEN_AUTORIZADO.ToString()) ? "" : item.VOLUMEN_AUTORIZADO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.VOLUMEN_MOVILIZADO.ToString()) ? "" : item.VOLUMEN_MOVILIZADO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.SALDO.ToString()) ? "" : item.SALDO.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.UNIDAD_MEDIDA.ToString()) ? "" : item.UNIDAD_MEDIDA.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.PC.ToString()) ? "" : item.PC.ToString()) + "'";
                                        insertar = insertar + ",'" + (string.IsNullOrEmpty(item.OBSERVACION.ToString()) ? "" : item.OBSERVACION.ToString()) + "'";
                                        cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (olMaderable.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                        cmd.ExecuteNonQuery();
                                    }
                                    break;
                                #endregion
                            }
                            
                            //Cerramos la conexión
                            conn.Close();
                        }
                    }

                    result.success = true;
                    result.msj = nombreFile;
                }
                else { throw new Exception("No se encontraron registros"); }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }

        public static ListResult BExtraccionNoMaderable(List<Ent_BEXTRACCION_NOMADE> olNoMaderable, string asCodMTipo)
        {
            ListResult result = new ListResult();

            try
            {
                if (olNoMaderable.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = "";

                    if (asCodMTipo == "0000021")
                    { //Planta medicinal
                        rutaExcelBase = rutaBase + "PoaNoMaderablePMedBExtraccion_v2.xlsx";
                    }
                    else if (asCodMTipo == "0000020")
                    { //Carrizo
                        rutaExcelBase = rutaBase + "PoaNoMaderableCarrBExtraccion_v2.xlsx";
                    }
                    else
                    { //Normal
                        rutaExcelBase = rutaBase + "PoaNoMaderableBExtraccion_v2.xlsx";
                    }

                    try
                    {
                        File.Delete(@rutaExcel);
                        File.Copy(@rutaExcelBase, @rutaExcel);
                    }
                    catch (IOException ix)
                    {
                        throw new Exception(ix.Message);
                    }

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
                        string insertar = "";
                        int i = 1;
                        //Abrimos la conexión
                        conn.Open();
                        //Creamos la ficha
                        using (OleDbCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //Construyendo las Cabeceras
                            foreach (var item in olNoMaderable)
                            {
                                insertar = "";
                                if (string.IsNullOrEmpty(item.ESPECIES))
                                {
                                    insertar = insertar + "'" + "" + "'";
                                    insertar = insertar + ",'" + "" + "'";
                                }
                                else
                                {
                                    if (item.ESPECIES.Trim().Length <= 1)
                                    {
                                        insertar = insertar + "'" + "" + "'";
                                        insertar = insertar + ",'" + "" + "'";
                                    }
                                    else
                                    {
                                        insertar = insertar + "'" + item.ESPECIES.Substring(0, item.ESPECIES.IndexOf('|')).Trim() + "'";
                                        insertar = insertar + ",'" + item.ESPECIES.Substring(item.ESPECIES.IndexOf('|') + 1, item.ESPECIES.Length - item.ESPECIES.IndexOf('|') - 1).Trim() + "'";
                                    }
                                }

                                if (string.IsNullOrEmpty(item.ESPECIES_SERFOR))
                                {
                                    insertar = insertar + ",'" + "" + "'";
                                    insertar = insertar + ",'" + "" + "'";
                                }
                                else
                                {
                                    if (item.ESPECIES_SERFOR.Trim().Length <= 1)
                                    {
                                        insertar = insertar + ",'" + "" + "'";
                                        insertar = insertar + ",'" + "" + "'";
                                    }
                                    else
                                    {
                                        insertar = insertar + ",'" + item.ESPECIES_SERFOR.Substring(0, item.ESPECIES_SERFOR.IndexOf('|')).Trim() + "'";
                                        insertar = insertar + ",'" + item.ESPECIES_SERFOR.Substring(item.ESPECIES_SERFOR.IndexOf('|') + 1, item.ESPECIES_SERFOR.Length - item.ESPECIES_SERFOR.IndexOf('|') - 1).Trim() + "'";
                                    }
                                }

                                if (asCodMTipo == "0000021")
                                { //Planta medicinal
                                    insertar = insertar + ",'" + (string.IsNullOrEmpty(item.AUTORIZADO.ToString()) ? "" : item.AUTORIZADO.ToString()) + "'";
                                    insertar = insertar + ",'" + (string.IsNullOrEmpty(item.EXTRAIDO.ToString()) ? "" : item.EXTRAIDO.ToString()) + "'";
                                    insertar = insertar + ",'" + (string.IsNullOrEmpty(item.SALDO.ToString()) ? "" : item.SALDO.ToString()) + "'";
                                    insertar = insertar + ",'" + (string.IsNullOrEmpty(item.UNIDAD_MEDIDA.ToString()) ? "" : item.UNIDAD_MEDIDA.ToString()) + "'";
                                }
                                else if (asCodMTipo == "0000020")
                                { //Carrizo
                                    insertar = insertar + ",'" + (string.IsNullOrEmpty(item.FECHA1.ToString()) ? "" : item.FECHA1.ToString()) + "'";
                                    insertar = insertar + ",'" + (string.IsNullOrEmpty(item.GUIA_TRANSPORTE.ToString()) ? "" : item.GUIA_TRANSPORTE.ToString()) + "'";
                                    insertar = insertar + ",'" + (string.IsNullOrEmpty(item.FECHA2.ToString()) ? "" : item.FECHA2.ToString()) + "'";
                                    insertar = insertar + ",'" + (string.IsNullOrEmpty(item.RECIBO.ToString()) ? "" : item.RECIBO.ToString()) + "'";
                                    insertar = insertar + ",'" + (string.IsNullOrEmpty(item.SALDO.ToString()) ? "" : item.SALDO.ToString()) + "'";
                                    insertar = insertar + ",'" + (string.IsNullOrEmpty(item.CANTIDAD.ToString()) ? "" : item.CANTIDAD.ToString()) + "'";
                                }
                                else
                                { //Normal
                                    insertar = insertar + ",'" + (string.IsNullOrEmpty(item.KILOGRAMO_AUTORIZADO.ToString()) ? "" : item.KILOGRAMO_AUTORIZADO.ToString()) + "'";
                                    insertar = insertar + ",'" + (string.IsNullOrEmpty(item.KILOGRAMO_MOVILIZADO.ToString()) ? "" : item.KILOGRAMO_MOVILIZADO.ToString()) + "'";
                                    insertar = insertar + ",'" + (string.IsNullOrEmpty(item.SALDO.ToString()) ? "" : item.SALDO.ToString()) + "'";
                                }

                                insertar = insertar + ",'" + (string.IsNullOrEmpty(item.OBSERVACION.ToString()) ? "" : item.OBSERVACION.ToString()) + "'";

                                cmd.CommandText = "INSERT INTO [Datos$A" + i.ToString().Trim() + ":Z" + (olNoMaderable.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                cmd.ExecuteNonQuery();
                            }

                            //Cerramos la conexión
                            conn.Close();
                        }
                    }

                    result.success = true;
                    result.msj = nombreFile;
                }
                else { throw new Exception("No se encontraron registros"); }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }
    }
}