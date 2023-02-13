using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.DOC;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
//using CEntSDetMarable = CapaEntidad.DOC.Ent_ISUPERVISION_DET_EMADERABLE;
using System.Linq;
using CDatos = CapaDatos.DOC.Dat_INFORME;
//using CEntidadUbi = CapaEntidad.GENE.Ent_UBIGEO;
//using CLogicaUbi = CapaLogica.GENE.Log_UBIGEO;
using CEntidad = CapaEntidad.DOC.Ent_INFORME;
using CEntISExsitu = CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_INFRA_AREA;

namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Log_INFORME
    {
        private CDatos oCDatos = new CDatos();       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostrarCNotif_vs_THabilit_Bucar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarCNotif_vs_THabilit_Bucar(cn, oCampoEntrada);
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
        /// <returns></returns>
        public CEntidad RegMostListPOAs(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostListPOAs(cn, oCEntidad);
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
        public CEntidad RegMostCombo(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo(cn, oCampoEntrada);
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
        /// <returns></returns>
        public CEntidad RegMostComboResultado(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostComboResultado(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        /// <summary>
        /// LISTADO MUESTRA
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntSDetMarable> RegMostrarPoaDetMadListaMuestra(CEntSDetMarable oCampoEntrada)
        public List<CEntidad> RegMostrarPoaDetMadListaMuestra(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarPoaDetMaderableListaMuestra(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> RegMostrarPoaDetMadSemilleroListaMuestra(CEntidad oCampoEntrada)
        //public List<CEntSDetMarable> RegMostrarPoaDetMadSemilleroListaMuestra(CEntSDetMarable oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarPoaDetMaderableSemilleroListaMuestra(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // 
        /// <summary>
        /// LISTADO MUESTRA NO MADERABLE
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntSDetMarable> RegMostrarPoaDetNoMadListaMuestra(CEntSDetMarable oCampoEntrada)
        public List<CEntidad> RegMostrarPoaDetNoMadListaMuestra(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarPoaDetNoMadListaMuestra(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<CEntSDetMarable> RegMostrarPoaDetNoMadSemilleroListaMuestra(CEntSDetMarable oCampoEntrada)
        public List<CEntidad> RegMostrarPoaDetNoMadSemilleroListaMuestra(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarPoaDetNoMadSemilleroListaMuestra(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //LISTADO MUESTRA MADE NO MADE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public CEntidad RegMostrarPoaDetMade_NoMade_ListaMuestra(CEntSDetMarable oCampoEntrada)
        public CEntidad RegMostrarPoaDetMade_NoMade_ListaMuestra(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarPoaDetMade_NoMade_ListaMuestra(cn, oCampoEntrada);
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
        //public CEntidad RegMostrarDevolMad_ListaMuestra(CEntSDetMarable oCampoEntrada)
        public CEntidad RegMostrarDevolMad_ListaMuestra(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarDevolMad_ListaMuestra(cn, oCampoEntrada);
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
        public CEntidad RegMostrarListaItem(String codInforme)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaItem(cn, codInforme);
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
        public String ReglInsertarInforme(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegInsertar(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region "PRESUPUESTO CARTA NOTIFICACION"
        /*public String RegINFORME_VS_PSUPERVISION_Insertar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegINFORME_VS_PSUPERVISION_Insertar(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CEntidad RegMostComboExsitu(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostComboExsitu(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        // Guardar Informe de Exsitu
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public String ReglInsertarInforme_Exsitu(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegInsertar_ExSitu(cn, oCampoEntrada);
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
        public CEntidad INFORME_ISUPERVISION_EXSITU_MostItem(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.INFORME_ISUPERVISION_EXSITU_MostItem(cn, oCampoEntrada);
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
        public String TEMP_CAMBIAR_CENSO(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.TEMP_CAMBIAR_CENSO(cn, oCampoEntrada);
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
        public String RegITaraInsertar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegITaraInsertar(cn, oCampoEntrada);
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
        public CEntidad RegITaraMostrarListaItem(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegITaraMostrarListaItem(cn, oCampoEntrada);
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
        public void RegModificarFormato(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegModificarFormato(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string RegCargaMaderableWS(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegCargaMaderableWS(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string RegCargaNoMaderableWS(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegCargaNoMaderableWS(cn, oCampoEntrada);
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
        public void RegModificarFormatoNoMaderable(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegModificarFormatoNoMaderable(cn, oCampoEntrada);
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
        public void RegModificarFormatoBosqueSeco(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegModificarFormatoBosqueSeco(cn, oCampoEntrada);
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
        public String RegIConservacionInsertar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegIConservacionInsertar(cn, oCampoEntrada);
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
        /// <returns></returns>
        public CEntidad RegConservacionMostCombo(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegConservacionMostCombo(cn, oCampoEntrada);
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
        public CEntidad RegIECOTURISMOMostrarListaItem(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegIECOTURISMOMostrarListaItem(cn, oCampoEntrada);
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
        public String RegISProyectoGenerar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegISProyectoGenerar(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> Reg_Requere(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrar_Requerimiento(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> RegMostrar_Informe(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrar_Informe(cn, oCampoEntrada);
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
        public List<CEntidad> RegMostrar_Informe_fotos(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrar_Informe_fotos(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> RegMostrar_Informe_fotos_Obs(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrar_Informe_fotos_Obs(cn, oCampoEntrada);
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
        public Int32 RegPreProcesarObservatorio(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegPreProcesarObservatorio(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String RegAjustarMuestra(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegAjustarMuestra(cn, oCampoEntrada);
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
        public CEntidad RegIFaunaMostrarListaItem(String codInforme)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegIFaunaMostrarListaItem(cn, codInforme);
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
        public String RegIFaunaInsertar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegIFaunaInsertar(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad RegMostrarDatosCampoISupervision(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarDatosCampoISupervision(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// metododo para descargar las listas del informe de supervision
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public CEntidad RegListDescargaExcel(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegListaItemDescarga(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntISExsitu> RegMostrar_ObligTHFauna(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegObligacionesListFauna(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*########################## SIGOsfc v3 ##############################*/
        #region SIGOsfc v3
        public CEntidad RegMostrarListaItem_v3(String codInforme)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaItem_v3(cn, codInforme);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String ReglInsertarInforme_v3(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegInsertar_v3(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CEntidad RegMostrarDatosCabecera(String codInforme)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarDatosCabecera(cn, codInforme);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VM_Informe InitDatosInforme(string asCodInforme, string asCodCNotificacion, string asCodMTipo, string asCodUCuenta)
        {
            VM_Informe vmInf = new VM_Informe();
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();



            try
            {
                vmInf.lblTituloCabecera = "Informe de Supervisión";

                CEntidad comInf = new CEntidad();
                comInf.BusFormulario = "INFORME_SUPERVISION";
                comInf.BusCriterio = "ISUPERVISION_GENERAL";
                comInf.COD_UCUENTA = asCodUCuenta;
                comInf = RegMostCombo(comInf);
                vmInf.vmDatoSupervision.ddlTipoSupervision = exeBus.RegMostComboIndividual("TIPO_SUPERVISION", "");
                vmInf.ent_INFORME = comInf;
                vmInf.chkDenuncia = comInf.B_DENUNCIA.Equals(1);
                vmInf.ddlOd = comInf.ListODs.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                vmInf.vmDatoSupervision.ddlMotivoSupervision = comInf.ListISupervision_Motivo.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                vmInf.vmDatoSupervision.ddlTipoPeticionMotivada = comInf.ListMComboMotMotivada.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });

                vmInf.vmDatoSupervision.ddlTipoInforme = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "0000000", Text = "Seleccionar" },
                    new VM_Cbo { Value = "GABINETE", Text = "GABINETE" },
                    new VM_Cbo { Value = "CAMPO", Text = "CAMPO" }
                };

                vmInf.ddlBuenDesempenio = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "Seleccionar", Text = "Seleccionar" },
                    new VM_Cbo { Value = "1", Text = "SI" },
                    new VM_Cbo { Value = "0", Text = "NO" }
                };

                vmInf.ddlArchivaInforme = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "Seleccionar", Text = "Seleccionar" },
                    new VM_Cbo { Value = "1", Text = "SI" },
                    new VM_Cbo { Value = "0", Text = "NO" }
                };

                #region DENUNCIAS
                //List<TipoDenuncia> tipoDenuncia = new List<TipoDenuncia>();
                //tipoDenuncia.Add(new TipoDenuncia("00", "--Seleccionar--"));
                //tipoDenuncia.Add(new TipoDenuncia("01", "Ordinario"));
                //tipoDenuncia.Add(new TipoDenuncia("02", "Extraordinario"));
                //vmInf.tipoDenuncia = tipoDenuncia;
                //CLogicaDenuncia exeCap = new CLogicaDenuncia();
                //Ent_Denuncias denun = new Ent_Denuncias();
                //denun.IDENUNCIA = new IDENUNCIA();
                //denun.IDENUNCIA.COD_INFORME = asCodInforme;
                //vmInf.ent_Denuncias = exeCap.obtenerDenuncias(denun);
                #endregion
                if (String.IsNullOrEmpty(asCodInforme))
                {
                    CapaEntidad.DOC.Ent_CNOTIFICACION entCN = new CapaEntidad.DOC.Ent_CNOTIFICACION();
                    Log_CNOTIFICACION exeCN = new Log_CNOTIFICACION();
                    entCN = exeCN.RegMostCNotificacion_Consulta(
                        new CapaEntidad.DOC.Ent_CNOTIFICACION()
                        {
                            BusFormulario = "DATA_CNOTIFICACION",
                            BusCriterio = "CN_CODCN_ISUPERVISION",
                            BusValor = asCodCNotificacion
                        }).FirstOrDefault();

                    vmInf.lblTituloEstado = "Nuevo Registro";
                    vmInf.vmInfCNotificacion.hdfCodCNotificacion = entCN.COD_CNOTIFICACION;
                    vmInf.vmInfCNotificacion.txtCNotificacion = entCN.NUMERO;
                    vmInf.vmInfCNotificacion.txtTHabilitante = entCN.NUM_THABILITANTE;
                    vmInf.hdfCodUbigeo = entCN.COD_UBIGEO;
                    vmInf.txtUbigeo = entCN.UBIGEO;
                    vmInf.txtSector = entCN.SECTOR;
                    vmInf.hdfRegEstado = 1;

                    CEntidad entInfPoa = new CEntidad();
                    entInfPoa.BusFormulario = "INFORME_SUPERVISION";
                    entInfPoa.BusCriterio = "LISTA_POAS";
                    entInfPoa.TIPO = "CN";
                    entInfPoa.BusValor = "'" + asCodCNotificacion + "'";
                    vmInf.vmInfCNotificacion.tbPoa = RegMostListPOAs(entInfPoa).ListPOAs;
                    foreach (var itemPoa in vmInf.vmInfCNotificacion.tbPoa)
                    {
                        itemPoa.RegEstado = 1;
                    }

                    //Cargar las obligaciones del titular del TH
                    string tipoObligTitular = "OBLIGTITU_NOMADE";
                    if (("0000007|0000010|0000014|0000015|0000016|0000017").Contains(asCodMTipo))
                    {
                        tipoObligTitular = "OBLIGTITU_MADE";
                    }
                    var lstObligTitular = exeBus.RegMostComboIndividual("OBLIGACION_TITULAR", tipoObligTitular);
                    foreach (var item in lstObligTitular)
                    {
                        vmInf.tbObligTitular.Add(new CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR()
                        {
                            COD_OBLIGTITULAR = item.Value,
                            OBLIGTITULAR = item.Text,
                            EVAL_OBLIGTITULAR = "",
                            OBSERVACION = ""
                        });
                    }
                }
                else
                {
                    //Obtener datos del informe
                    CEntidad entInf = RegMostrarListaItem_v3(asCodInforme);

                    vmInf.lblTituloEstado = "Modificando Registro";
                    vmInf.vmControlCalidad.ddlIndicadorId = entInf.COD_ESTADO_DOC;
                    vmInf.vmControlCalidad.chkObsSubsanada = (bool)entInf.OBSERV_SUBSANAR;
                    vmInf.vmControlCalidad.txtControlCalidadObservaciones = entInf.OBSERVACIONES_CONTROL.ToString();
                    vmInf.vmControlCalidad.txtUsuarioControl = entInf.USUARIO_CONTROL;
                    vmInf.vmControlCalidad.txtUsuarioRegistro = entInf.USUARIO_REGISTRO;

                    vmInf.vmInfCNotificacion.hdfCodCNotificacion = entInf.COD_CNOTIFICACION;
                    vmInf.vmInfCNotificacion.txtCNotificacion = entInf.NUM_CNOTIFICACION;
                    /*vmInf.vmInfCNotificacion.hdfCodCNotificacion = entInf.COD_FISNOTI;
                    vmInf.vmInfCNotificacion.txtCNotificacion = entInf.NUM_NOTIFICACION;*/
                    vmInf.vmInfCNotificacion.txtTHabilitante = entInf.NUM_THABILITANTE;
                    vmInf.vmInfCNotificacion.tbCNotificacion = entInf.ListCNotificaciones;

                    vmInf.hdfCodInforme = entInf.COD_INFORME;
                    vmInf.hdfRegEstado = 0;
                    vmInf.chkPublicar = (bool)entInf.PUBLICAR;
                    vmInf.vmInfCNotificacion.tbPoa = entInf.ListPOAs;
                    vmInf.txtNumInforme = entInf.NUMERO;
                    vmInf.ddlOdId = entInf.COD_OD_REGISTRO;
                    vmInf.chkPlanAmazonas = (bool)entInf.PLAN_AMAZONAS;
                    vmInf.chkPlanAmazonas2014 = entInf.ANIO_PLAN_AMAZONAS.Contains("2014") ? true : false;
                    vmInf.chkPlanAmazonas2015 = entInf.ANIO_PLAN_AMAZONAS.Contains("2015") ? true : false;
                    vmInf.chkPlanAmazonas2016 = entInf.ANIO_PLAN_AMAZONAS.Contains("2016") ? true : false;
                    vmInf.txtFechaEntrega = entInf.FECHA_ENTREGA.ToString();
                    vmInf.hdfCodDirector = entInf.COD_DIRECTOR;
                    vmInf.txtDirector = entInf.NOMBRE_DIRECTOR;
                    vmInf.vmDatoSupervision.txtFechaInicio = entInf.FECHA_SUPERVISION_INICIO.ToString();
                    vmInf.vmDatoSupervision.txtFechaFin = entInf.FECHA_SUPERVISION_FIN.ToString();
                    vmInf.vmDatoSupervision.ddlMotivoSupervisionId = entInf.COD_IMOTIVO;
                    vmInf.vmDatoSupervision.ddlTipoSupervisionId = entInf.COD_TIPO_SUPER;
                    vmInf.vmDatoSupervision.ddlTipoInformeId = entInf.TIPO_INFORME;
                    vmInf.vmDatoSupervision.txtMotivoSupervision = entInf.IMOTIVO;
                    vmInf.vmDatoSupervision.ddlTipoPeticionMotivadaId = entInf.MAE_TIP_MOTMOTIVADA;
                    vmInf.vmDatoSupervision.hdfCodDocDenunciaSITD = entInf.COD_TRAMITE_SITD.ToString();
                    vmInf.vmDatoSupervision.txtDocDenunciaSITD = entInf.NUM_DREFERENCIA;
                    vmInf.vmDatoSupervision.chkGeoTecDron = (bool)entInf.GEOTEC_DRON;
                    vmInf.vmDatoSupervision.chkGeoTecGeoSupervisor = (bool)entInf.GEOTEC_GEOSUPERVISOR;
                    vmInf.vmDatoSupervision.chkGeoTecOtro = (bool)entInf.GEOTEC_OTROS;
                    vmInf.vmDatoSupervision.chkGeoTecNinguno = (bool)entInf.GEOTEC_NINGUNO;
                    vmInf.vmDatoSupervision.txtGeoTecOtro = entInf.GEOTEC_DESCRIPCION;
                    vmInf.txtAsunto = entInf.ASUNTO;
                    vmInf.txtContenido = entInf.CONTENIDO.ToString();
                    vmInf.ddlRealizadoVeedorId = (bool)entInf.REALIZADO_VEEDORFORESTAL ? "SI" : "NO";
                    vmInf.hdfCodUbigeo = entInf.THABILITANTE_COD_UBIGEO;
                    vmInf.txtUbigeo = entInf.UBIGEO;
                    vmInf.txtSector = entInf.THABILITANTE_SECTOR;
                    vmInf.txtObservacion = entInf.OBSERVACION;
                    vmInf.txtConclusion = entInf.CONCLUSION;
                    vmInf.hdfCodDLinea = entInf.COD_DLINEA;
                    vmInf.hdfEstadoOrigen = entInf.ESTADO_ORIGEN;
                    vmInf.tbSupervisor = entInf.ListInformeDetSupervisor;
                    vmInf.tbVerticeTHCampo = entInf.ListTHVerticeCampo;
                    vmInf.tbAvistamientoFauna = entInf.ListAvistamientoFauna;
                    vmInf.tbFotoSupervision = entInf.ListFotos;
                    vmInf.tbObligTitular = ("0000007|0000010|0000014|0000015|0000016|0000017").Contains(asCodMTipo) ?
                        entInf.ListObligacionTitular.Where(m => m.COD_GRUPO == "OBLIGTITU_MADE").ToList() : entInf.ListObligacionTitular.Where(m => m.COD_GRUPO == "OBLIGTITU_NOMADE").ToList();
                    vmInf.tbObligacion = entInf.ListISUPERVISION_OCARACTE_AMB01;
                    vmInf.tbDesplazamiento = entInf.ListDesplazamientoInforme;
                    vmInf.hdSupervisor_Calidad = entInf.COD_SUP_CALIDAD;
                    vmInf.Nombre_Supervisor_Calidad = entInf.NOMBRE_SUP_CALIDAD;
                    vmInf.ddlBuenDesempenioId = entInf.BUEN_DESEMPENIO.ToString();
                    vmInf.ddlArchivaInformeId = (entInf.ARCHIVA_INFORME == -1) ? "Seleccionar" : entInf.ARCHIVA_INFORME.ToString();
                    vmInf.tbMandatos = entInf.ListMandatos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vmInf;
        }
        public ListResult GuardarDatosInforme(VM_Informe _dto, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                ValidarDatosInforme(_dto);

                CEntidad paramsInf = new CEntidad();
                //Datos obligatorios
                paramsInf.COD_INFORME = _dto.hdfCodInforme ?? "";
                paramsInf.NUMERO = _dto.txtNumInforme;
                paramsInf.COD_ITIPO = "0000001";
                paramsInf.COD_CNOTIFICACION = _dto.vmInfCNotificacion.hdfCodCNotificacion;
                //paramsInf.COD_FISNOTI = _dto.vmInfCNotificacion.hdfCodCNotificacion;
                paramsInf.COD_OD_REGISTRO = _dto.ddlOdId;
                paramsInf.THABILITANTE_COD_UBIGEO = _dto.hdfCodUbigeo;
                paramsInf.THABILITANTE_SECTOR = _dto.txtSector;
                paramsInf.COD_TIPO_SUPER = _dto.vmDatoSupervision.ddlTipoSupervisionId;
                paramsInf.TIPO_INFORME = _dto.vmDatoSupervision.ddlTipoInformeId;
                paramsInf.ESTADO_ORIGEN = "P";
                paramsInf.PUBLICAR = _dto.chkPublicar;
                paramsInf.FECHA_SUPERVISION_INICIO = _dto.vmDatoSupervision.txtFechaInicio;
                paramsInf.FECHA_SUPERVISION_FIN = _dto.vmDatoSupervision.txtFechaFin;
                //Datos adicionales
                paramsInf.COD_DIRECTOR = _dto.hdfCodDirector;
                paramsInf.COD_IMOTIVO = _dto.vmDatoSupervision.ddlMotivoSupervisionId;
                paramsInf.FECHA_ENTREGA = _dto.txtFechaEntrega;
                paramsInf.ASUNTO = _dto.txtAsunto;
                paramsInf.CONTENIDO = _dto.txtContenido;
                paramsInf.PLAN_AMAZONAS = _dto.chkPlanAmazonas;
                string aniosPAmazonas = _dto.chkPlanAmazonas2014 ? "2014" : "";
                aniosPAmazonas += _dto.chkPlanAmazonas2015 ? (aniosPAmazonas == "" ? "" : ",") + "2015" : "";
                aniosPAmazonas += _dto.chkPlanAmazonas2016 ? (aniosPAmazonas == "" ? "" : ",") + "2016" : "";
                paramsInf.ANIO_PLAN_AMAZONAS = aniosPAmazonas;
                paramsInf.OBSERVACION = _dto.txtObservacion;
                paramsInf.CONCLUSION = _dto.txtConclusion;

                if (_dto.hdfCodMTipo == "0000015")//Caso CCNN
                {
                    paramsInf.REALIZADO_VEEDORFORESTAL = _dto.ddlRealizadoVeedorId == "SI" ? true : false;
                }
                paramsInf.GEOTEC_DRON = _dto.vmDatoSupervision.chkGeoTecDron;
                paramsInf.GEOTEC_GEOSUPERVISOR = _dto.vmDatoSupervision.chkGeoTecGeoSupervisor;
                paramsInf.GEOTEC_NINGUNO = _dto.vmDatoSupervision.chkGeoTecNinguno;
                paramsInf.GEOTEC_OTROS = _dto.vmDatoSupervision.chkGeoTecOtro;
                if ((bool)paramsInf.GEOTEC_OTROS)
                {
                    paramsInf.GEOTEC_DESCRIPCION = _dto.vmDatoSupervision.txtGeoTecOtro;
                }
                paramsInf.COD_DLINEA = _dto.hdfCodDLinea;
                if (paramsInf.COD_IMOTIVO == "0000011")//Petición motivada
                {
                    paramsInf.MAE_TIP_MOTMOTIVADA = _dto.vmDatoSupervision.ddlTipoPeticionMotivadaId;
                    paramsInf.COD_TRAMITE_SITD = Convert.ToInt32(_dto.vmDatoSupervision.hdfCodDocDenunciaSITD ?? "0");
                }

                paramsInf.COD_ESTADO_DOC = _dto.vmControlCalidad.ddlIndicadorId;
                paramsInf.OBSERVACIONES_CONTROL = _dto.vmControlCalidad.txtControlCalidadObservaciones;
                paramsInf.OBSERV_SUBSANAR = _dto.vmControlCalidad.chkObsSubsanada;
                paramsInf.BUEN_DESEMPENIO = Int32.Parse(_dto.ddlBuenDesempenioId);
                paramsInf.ARCHIVA_INFORME = Int32.Parse(_dto.ddlArchivaInformeId);

                paramsInf.ListEliTABLA = _dto.tbEliTABLA;
                paramsInf.ListCNotificaciones = _dto.vmInfCNotificacion.tbCNotificacion;
                paramsInf.ListPOAs = _dto.vmInfCNotificacion.tbPoa;
                paramsInf.ListInformeDetSupervisor = _dto.tbSupervisor;
                paramsInf.ListTHVerticeCampo = _dto.tbVerticeTHCampo;
                paramsInf.ListAvistamientoFauna = _dto.tbAvistamientoFauna;
                paramsInf.ListFotos = _dto.tbFotoSupervision;
                paramsInf.ListObligacionTitular = _dto.tbObligTitular;
                paramsInf.ListISUPERVISION_OCARACTE_AMB01 = _dto.tbObligacion;
                paramsInf.ListDesplazamientoInforme = _dto.tbDesplazamiento;

                paramsInf.RegEstado = _dto.hdfRegEstado;
                paramsInf.COD_UCUENTA = asCodUCuenta;
                paramsInf.OUTPUTPARAM01 = "";
                paramsInf.COD_SUP_CALIDAD = _dto.hdSupervisor_Calidad;
                paramsInf.ListMandatos = _dto.tbMandatos;
                ReglInsertarInforme_v3(paramsInf);

                string msjRespuesta = _dto.hdfRegEstado == 1 ? "El Registro se Guardo Correctamente" : "El Registro se Modifico Correctamente";
                result.AddResultado(msjRespuesta, true);
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }
        public void ModificarNumeroInforme(string codInforme, string numeroInforme,string asunto, DateTime fechaOperacion)
        {
            oCDatos.ModificarNumeroInforme(codInforme,numeroInforme,asunto,fechaOperacion);
        }
        private void ValidarDatosInforme(VM_Informe _dto)
        {
            if (_dto.vmControlCalidad.ddlIndicadorId == "0000000") throw new Exception("Seleccione el estado actual del registro");
            if (_dto.ddlOdId == "0000000") throw new Exception("Seleccione la oficina desconcentrada");

            if (string.IsNullOrEmpty(_dto.txtNumInforme)) throw new Exception("Ingrese el número del informe de supervisión");
            if (string.IsNullOrEmpty(_dto.vmDatoSupervision.txtFechaInicio)) throw new Exception("Seleccione la fecha de inicio de la supervisión");
            if (string.IsNullOrEmpty(_dto.vmDatoSupervision.txtFechaFin)) throw new Exception("Seleccione la fecha de término de la supervisión");
            if (string.IsNullOrEmpty(_dto.hdfCodUbigeo)) throw new Exception("Seleccione el ubigeo del área supervisada");
            if (string.IsNullOrEmpty(_dto.txtSector)) throw new Exception("Ingrese el sector del área supervisada");
            if (string.IsNullOrEmpty(_dto.vmInfCNotificacion.hdfCodCNotificacion)) throw new Exception("No se encuentra la Carta de Notificación asociada");
        }

        public VM_Informe_Foto RegInsertarFotoSupervision(VM_Informe_Foto _dto, string asCodUCuenta)
        {
            try
            {
                CEntidad oParams = new CEntidad();
                oParams.COD_INFORME = _dto.hdfCodInforme;
                oParams.COD_UCUENTA = asCodUCuenta;
                oParams.URL_FOTO = _dto.txtUrlFoto;
                oParams.FUENTE_FOTO = _dto.txtFuente;
                oParams.DISP_FOTO = _dto.txtDispositivo;
                oParams.DESC_FOTO = _dto.txtDescripcion;
                oParams.OUTPUTPARAM01 = "";

                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    _dto.hdfCodInformeFoto = oCDatos.RegInsertarFotoSupervision(cn, oParams);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _dto;
        }

        public VM_Informe_POASupervisado InitDatosPOASupervisado(string asCodInforme, Int32 aiNumPoa, int B_POA, string CODIGO_SEC_NOPOA, string hdfCodMTipo = "")
        {
            VM_Informe_POASupervisado vm = new VM_Informe_POASupervisado();
            try
            {
                CEntidad entidad = new CEntidad();
                if (B_POA == 1)
                {
                    entidad = new CEntidad() { COD_INFORME = asCodInforme, NUM_POA = aiNumPoa, B_POA = B_POA, CODIGO_SEC_NOPOA = null };
                }
                else
                {
                    entidad = new CEntidad() { COD_INFORME = asCodInforme, CODIGO_SEC_NOPOA = CODIGO_SEC_NOPOA, B_POA = B_POA };
                }
                CEntidad oCampo = oCDatos.RegMostrarInfoDocumentPOASupervisado(entidad);
                if (oCampo.NUM_POA != -1) //Registro existente
                {
                    Log_BUSQUEDA exeBus = new Log_BUSQUEDA();

                    vm.lblTituloEstado = "Registro de Datos " + oCampo.POA;
                    vm.hdfCodInforme = oCampo.COD_INFORME;
                    vm.hdfNumPoa = oCampo.NUM_POA;
                    vm.hdfCodMTipo = oCampo.COD_MTIPO;
                    vm.hdfLinderamientoArea = oCampo.LINDERAMIENTO_AREA;
                    vm.hdfAreaDemarcacion = oCampo.AREA_DEMARCACION;
                    vm.hdfAreaLinderamiento = oCampo.AREA_LINDERAMIENTO;
                    vm.ddlIndicioAprovechaId = (bool)oCampo.INDICIO_APROV == true ? "SI" : "NO";
                    vm.txtObsAprovecha = oCampo.OBSERV_APROV;
                    vm.hdfTipoSisAprovecha = oCampo.TIPO_SAPROVECHAMIENTO;
                    vm.hdfPresenciaHuayrona = oCampo.PHUAYRONA_ESTADO;
                    vm.ddlCumpleVialId = (bool)oCampo.CUMPLE_VIAL_PLANMAN == true ? "SI" : "NO";
                    vm.hdfAreaReposicion = oCampo.CUENTA_AREPOSICION;
                    vm.txtFecPresentaPlan = oCampo.FEC_PRESENT_PM.ToString();
                    vm.txtFecApruebaPlan = oCampo.FEC_APROB_PM.ToString();
                    vm.txtFecEntregaAcervo = oCampo.FEC_ENTREGA_ACERVO.ToString();
                    vm.ddlPlanConcuerdaPgmfId = (bool)oCampo.CUMPLE_PM_PGMF == true ? "SI" : "NO";
                    vm.txtObsPlanConcuerdaPgmf = oCampo.OBSERV_PM_PGMF;
                    vm.ddlPlanApruebaNormaId = (bool)oCampo.APROB_NORMAVIGENTE_PM == true ? "SI" : "NO";
                    vm.txtObsPlanApruebaNorma = oCampo.OBSERV_NORMAVIGENTE_PM;
                    vm.ddlInformeEjecutaPlanId = oCampo.CUENTA_INFOEJECPO;
                    vm.ddlTipoInformeEjecuta = exeBus.RegMostComboIndividual("INFORME_EJECUCION_FORESTAL", "");
                    vm.ddlTipoInformeEjecutaId = oCampo.MAE_TIP_IEJECFOREST;
                    vm.txtFecPresentaAutoridad = oCampo.FEC_PRESENT_INFOEJECPO.ToString();
                    vm.txtFecComunicaOsinfor = oCampo.FEC_COMUNIC_INFOEJECPO.ToString();
                    vm.ddlCumpleLineamientoId = (bool)oCampo.CUMPLE_LINEA_INFOEJECPO == true ? "SI" : "NO";
                    vm.txtObsCumpleLineamiento = oCampo.OBSERV_LINEA_INFOEJECPO;
                    vm.ddlCumplePagoAprovId = (bool)oCampo.CUMPLE_PAGO_APROV == true ? "SI" : "NO";
                    vm.txtObsCumplePagoAprov = oCampo.OBSERV_PAGO_APROV;
                    vm.ddlImpactoDanio = exeBus.RegMostComboIndividual("GRAVEDAD_DANIO", "");
                    vm.ddlImpactoDanioId = oCampo.COD_RESODIREC_GRAVEDAD;
                    vm.ddlOportunidadAprov = exeBus.RegMostComboIndividual("OPORTUNIDAD_APROVECHAMIENTO", "");
                    vm.ddlOportunidadAprovId = oCampo.MAE_EST_APROVECHA;
                    vm.chkRecReformulaPlan = (bool)oCampo.RECOMEND_REFORMULA;
                    vm.txtDescOtraRec = oCampo.RECOMEND_DESCRIPCION;
                    vm.hdfCodTitularEjecuta = oCampo.COD_TITULAR_EJECUTA;
                    vm.txtTitularEjecuta = oCampo.TITULAR_EJECUTA;
                    vm.hdfCodRegenteImplementa = oCampo.COD_REGENTE_IMPLEMENTA;
                    vm.txtRegenteImplementa = oCampo.REGENTE_IMPLEMENTA;
                    vm.hdfMaderable = (bool)oCampo.MADERABLE;
                    vm.hdfNoMaderable = (bool)oCampo.NO_MADERABLE;
                    vm.hdfCodTerceroSolidario = oCampo.COD_TERCERO_SOLIDARIO;
                    vm.txtTerceroSolidario = oCampo.TERCERO_SOLIDARIO;
                    //DIRECCION Y UBIGEO REGENTE
                    vm.txtCodUbigeo = oCampo.COD_UBIGEO_REGENTE;
                    vm.txtUbigeo = oCampo.UBIGEO_REGENTE;
                    vm.txtDirecion = oCampo.DIRECCION_REGENTE;

                    vm.tbCondicionArea = oCampo.ListCondicionArea;
                    vm.tbVerticeArea = oCampo.ListVerticeArea;
                    vm.tbEvalArbolAdicional = oCampo.ListEvalArbolAdicional;
                    vm.tbEvalArbolNoAutorizado = oCampo.ListEvalArbolNoAutorizado;
                    vm.tbHuayrona = oCampo.ListHuayrona_v3;
                    vm.tbActividadSilvicultural = oCampo.ListActividadSilvicultural;
                    vm.tbCambioUso = oCampo.ListCambioUso;
                    vm.tbEvalOtro = oCampo.ListEvaluacionOtro_v3;
                    vm.tbVolumenAnalizado = oCampo.ListVolumenAnalizado;
                    //llanos
                    vm.tbAnalisis = oCampo.ListAnalisis;
                    vm.tbConsolidado = oCampo.ListConsolidado;
                    vm.tbConsolidadoNN = oCampo.ListConsolidadoNN;
                    vm.tbMaderable = oCampo.ListMaderable;

                    //Parcelas de corta
                    List<VM_Chk> lstChkItem = new List<VM_Chk>();
                    string cod = "";
                    foreach(var item in oCampo.ListButtonParcelaCorta)
                    {
                        lstChkItem.Add(new VM_Chk() { Value = item.Value, Text = item.Text, Checked = item.IsCheck });
                        cod += cod == "" ? "" : "|";
                        cod += item.Value;
                    }

                    if (lstChkItem.Count> 0)
                    {
                        if (lstChkItem.Count > 1) lstChkItem.Add(new VM_Chk() { Value = "", Text = "Total", Checked = true });
                        else lstChkItem[0].Checked = true;
                    }

                    vm.lstChkParcelaCorta = lstChkItem;
                }
                else
                {
                    if (B_POA == 0)
                    {

                        vm.lblTituloEstado = "Registro de Datos ";
                        vm.hdfCodInforme = asCodInforme;
                        vm.hdfNumPoa = 0;
                        vm.hdfCodNoPoa = CODIGO_SEC_NOPOA;
                        vm.hdfCodMTipo = hdfCodMTipo;
                        //vm.hdfLinderamientoArea = oCampo.LINDERAMIENTO_AREA;
                        //vm.hdfAreaDemarcacion = oCampo.AREA_DEMARCACION;
                        //vm.hdfAreaLinderamiento = oCampo.AREA_LINDERAMIENTO;
                        //vm.ddlIndicioAprovechaId = (bool)oCampo.INDICIO_APROV == true ? "SI" : "NO";
                        //vm.txtObsAprovecha = oCampo.OBSERV_APROV;
                        //vm.hdfTipoSisAprovecha = oCampo.TIPO_SAPROVECHAMIENTO;
                        //vm.hdfPresenciaHuayrona = oCampo.PHUAYRONA_ESTADO;
                        //vm.ddlCumpleVialId = (bool)oCampo.CUMPLE_VIAL_PLANMAN == true ? "SI" : "NO";
                        //vm.hdfAreaReposicion = oCampo.CUENTA_AREPOSICION;
                        //vm.txtFecPresentaPlan = oCampo.FEC_PRESENT_PM.ToString();
                        //vm.txtFecApruebaPlan = oCampo.FEC_APROB_PM.ToString();
                        //vm.txtFecEntregaAcervo = oCampo.FEC_ENTREGA_ACERVO.ToString();
                        //vm.ddlPlanConcuerdaPgmfId = (bool)oCampo.CUMPLE_PM_PGMF == true ? "SI" : "NO";
                        //vm.txtObsPlanConcuerdaPgmf = oCampo.OBSERV_PM_PGMF;
                        //vm.ddlPlanApruebaNormaId = (bool)oCampo.APROB_NORMAVIGENTE_PM == true ? "SI" : "NO";
                        //vm.txtObsPlanApruebaNorma = oCampo.OBSERV_NORMAVIGENTE_PM;
                        //vm.ddlInformeEjecutaPlanId = oCampo.CUENTA_INFOEJECPO;
                        //vm.ddlTipoInformeEjecuta = exeBus.RegMostComboIndividual("INFORME_EJECUCION_FORESTAL", "");
                        //vm.ddlTipoInformeEjecutaId = oCampo.MAE_TIP_IEJECFOREST;
                        //vm.txtFecPresentaAutoridad = oCampo.FEC_PRESENT_INFOEJECPO.ToString();
                        //vm.txtFecComunicaOsinfor = oCampo.FEC_COMUNIC_INFOEJECPO.ToString();
                        //vm.ddlCumpleLineamientoId = (bool)oCampo.CUMPLE_LINEA_INFOEJECPO == true ? "SI" : "NO";
                        //vm.txtObsCumpleLineamiento = oCampo.OBSERV_LINEA_INFOEJECPO;
                        //vm.ddlCumplePagoAprovId = (bool)oCampo.CUMPLE_PAGO_APROV == true ? "SI" : "NO";
                        //vm.txtObsCumplePagoAprov = oCampo.OBSERV_PAGO_APROV;
                        //vm.ddlImpactoDanio = exeBus.RegMostComboIndividual("GRAVEDAD_DANIO", "");
                        //vm.ddlImpactoDanioId = oCampo.COD_RESODIREC_GRAVEDAD;
                        //vm.ddlOportunidadAprov = exeBus.RegMostComboIndividual("OPORTUNIDAD_APROVECHAMIENTO", "");
                        //vm.ddlOportunidadAprovId = oCampo.MAE_EST_APROVECHA;
                        //vm.chkRecReformulaPlan = (bool)oCampo.RECOMEND_REFORMULA;
                        //vm.txtDescOtraRec = oCampo.RECOMEND_DESCRIPCION;
                        //vm.hdfCodTitularEjecuta = oCampo.COD_TITULAR_EJECUTA;
                        //vm.txtTitularEjecuta = oCampo.TITULAR_EJECUTA;
                        //vm.hdfCodRegenteImplementa = oCampo.COD_REGENTE_IMPLEMENTA;
                        //vm.txtRegenteImplementa = oCampo.REGENTE_IMPLEMENTA;

                        //vm.tbCondicionArea = oCampo.ListCondicionArea;
                        //vm.tbVerticeArea = oCampo.ListVerticeArea;
                        vm.tbEvalArbolAdicional = oCampo.ListEvalArbolAdicional;
                        vm.tbEvalArbolNoAutorizado = oCampo.ListEvalArbolNoAutorizado;
                        //vm.tbHuayrona = oCampo.ListHuayrona_v3;
                        //vm.tbActividadSilvicultural = oCampo.ListActividadSilvicultural;
                        //vm.tbCambioUso = oCampo.ListCambioUso;
                        //vm.tbEvalOtro = oCampo.ListEvaluacionOtro_v3;
                        //vm.tbVolumenAnalizado = oCampo.ListVolumenAnalizado;
                    }
                    else
                    {
                        throw new Exception("No se encontró el plan de manejo");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vm;
        }

        public VM_Informe_POASupervisado InitDatosResumenSupervisado(string asCodInforme)
        {
            VM_Informe_POASupervisado vm = new VM_Informe_POASupervisado();
            try
            {
                CEntidad entidad = new CEntidad() { COD_INFORME = asCodInforme };
                CEntidad oCampo = oCDatos.RegMostrarInfoDocumentResumenSupervisado(entidad);

                vm.tbVolumenAnalizado = oCampo.ListVolumenAnalizado;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vm;
        }



        public VM_Informe_POASupervisado RegMostParcelaCorta(VM_Informe_POASupervisado dto)
        {
            VM_Informe_POASupervisado vm = new VM_Informe_POASupervisado();
            try
            {
                CEntidad entidad = new CEntidad();
                entidad.COD_INFORME = dto.hdfCodInforme;
                entidad.NUM_POA = dto.hdfNumPoa;
                entidad.COD_PARCELA = (dto.lstChkParcelaCortaId=="") ? null : dto.lstChkParcelaCortaId;
                //entidad.B_POA = 1;
                //entidad.CODIGO_SEC_NOPOA = null;
                CEntidad oCampo = oCDatos.RegMostrarInfoParcelaCorta(entidad);

                vm.tbAnalisis = oCampo.ListAnalisis;
                vm.tbConsolidado = oCampo.ListConsolidado;
                vm.tbConsolidadoNN = oCampo.ListConsolidadoNN;
                vm.tbMaderable = oCampo.ListMaderable;             
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vm;
        }

        public ListResult GuardarDatosPOASupervisado(VM_Informe_POASupervisado _dto, string asCodUCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                string cod_mtipo_concesiones = "0000007,0000008,0000009,0000010,0000011,0000012,0000013,0000017,0000018";
                string cod_mtipo_sobreplan = "0000006,0000007,0000008,0000009,0000010,0000011,0000012,0000013,0000014,0000015,0000016,0000017,0000018";
                string cod_mtipo_titularejecuta = "0000007,0000008,0000009,0000010,0000011,0000012,0000013";

                CEntidad oParams = new CEntidad();
                oParams.COD_INFORME = _dto.hdfCodInforme;
                oParams.NUM_POA = _dto.hdfNumPoa;

                if (cod_mtipo_concesiones.Contains(_dto.hdfCodMTipo))
                {
                    oParams.LINDERAMIENTO_AREA = _dto.hdfLinderamientoArea;
                    oParams.CUMPLE_PAGO_APROV = _dto.ddlCumplePagoAprovId == "SI" ? true : false;
                    oParams.OBSERV_PAGO_APROV = _dto.txtObsCumplePagoAprov;
                }
                else if (_dto.hdfCodMTipo == "0000015")
                {
                    oParams.LINDERAMIENTO_AREA = _dto.hdfLinderamientoArea;
                }
                else if (_dto.hdfCodMTipo == "0000006")
                {
                    oParams.PHUAYRONA_ESTADO = _dto.hdfPresenciaHuayrona ?? "NA";
                    if (oParams.PHUAYRONA_ESTADO == "S")
                        oParams.ListHuayrona_v3 = _dto.tbHuayrona;
                }

                oParams.AREA_DEMARCACION = _dto.hdfAreaDemarcacion;
                oParams.AREA_LINDERAMIENTO = _dto.hdfAreaLinderamiento;
                oParams.INDICIO_APROV = _dto.ddlIndicioAprovechaId == "SI" ? true : false;
                oParams.OBSERV_APROV = _dto.txtObsAprovecha;
                oParams.TIPO_SAPROVECHAMIENTO = _dto.hdfTipoSisAprovecha;
                oParams.CUMPLE_VIAL_PLANMAN = _dto.ddlCumpleVialId == "SI" ? true : false;
                oParams.CUENTA_AREPOSICION = _dto.hdfAreaReposicion;
                oParams.FEC_PRESENT_PM = _dto.txtFecPresentaPlan;
                oParams.FEC_APROB_PM = _dto.txtFecApruebaPlan;
                oParams.FEC_ENTREGA_ACERVO = _dto.txtFecEntregaAcervo;
                oParams.CUMPLE_PM_PGMF = _dto.ddlPlanConcuerdaPgmfId == "SI" ? true : false;
                oParams.OBSERV_PM_PGMF = _dto.txtObsPlanConcuerdaPgmf;
                oParams.APROB_NORMAVIGENTE_PM = _dto.ddlPlanApruebaNormaId == "SI" ? true : false;
                oParams.OBSERV_NORMAVIGENTE_PM = _dto.txtObsPlanApruebaNorma;
                oParams.CUENTA_INFOEJECPO = _dto.ddlInformeEjecutaPlanId;
                if (oParams.CUENTA_INFOEJECPO == "SI")
                {
                    oParams.MAE_TIP_IEJECFOREST = _dto.ddlTipoInformeEjecutaId;
                    oParams.FEC_PRESENT_INFOEJECPO = _dto.txtFecPresentaAutoridad;
                    oParams.FEC_COMUNIC_INFOEJECPO = _dto.txtFecComunicaOsinfor;
                    oParams.CUMPLE_LINEA_INFOEJECPO = _dto.ddlCumpleLineamientoId == "SI" ? true : false;
                    oParams.OBSERV_LINEA_INFOEJECPO = _dto.txtObsCumpleLineamiento;
                }
                oParams.COD_RESODIREC_GRAVEDAD = _dto.ddlImpactoDanioId;
                oParams.MAE_EST_APROVECHA = _dto.ddlOportunidadAprovId;
                if (oParams.MAE_EST_APROVECHA == "0000019")//Oportunidad supervisión: antes del aprovechamiento
                {
                    oParams.RECOMEND_REFORMULA = _dto.chkRecReformulaPlan;
                    oParams.RECOMEND_DESCRIPCION = _dto.txtDescOtraRec;
                }
                if (cod_mtipo_sobreplan.Contains(_dto.hdfCodMTipo))
                {
                    oParams.COD_REGENTE_IMPLEMENTA = _dto.hdfCodRegenteImplementa;
                    oParams.COD_UBIGEO_REGENTE = _dto.txtCodUbigeo;
                    oParams.DIRECCION_REGENTE = _dto.txtDirecion;
                    oParams.COD_TERCERO_SOLIDARIO = _dto.hdfCodTerceroSolidario;

                    if (cod_mtipo_titularejecuta.Contains(_dto.hdfCodMTipo))
                    {
                        oParams.COD_TITULAR_EJECUTA = _dto.hdfCodTitularEjecuta;
                    }
                }

                oParams.ListEliTABLA = _dto.tbEliTABLA;
                oParams.ListCondicionArea = _dto.tbCondicionArea;
                oParams.ListVerticeArea = _dto.tbVerticeArea;
                oParams.ListEvalArbolAdicional = _dto.tbEvalArbolAdicional;
                oParams.ListEvalArbolNoAutorizado = _dto.tbEvalArbolNoAutorizado;
                oParams.ListActividadSilvicultural = _dto.tbActividadSilvicultural;
                oParams.ListCambioUso = _dto.tbCambioUso;
                oParams.ListEvaluacionOtro_v3 = _dto.tbEvalOtro;
                oParams.ListVolumenAnalizado = _dto.tbVolumenAnalizado;

                oParams.COD_UCUENTA = asCodUCuenta;
                oParams.OUTPUTPARAM01 = "";

                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegInsertarInfoDocumentPOASupervisado(cn, oParams);
                }

                result.AddResultado("Los datos del plan de manejo se guardaron correctamente", true);
            }
            catch (Exception ex)
            {
                result.success = false; result.msj = ex.Message;
            }
            return result;
        }


        public ListResult GrabarPOArboles(VM_Informe_POASupervisado _dto, string asCodUCuenta)
        {

            ListResult result = new ListResult();
            try
            {
                CEntidad oParams = new CEntidad();
                oParams.COD_INFORME = _dto.hdfCodInforme;
                oParams.NUM_POA = _dto.hdfNumPoa;
                oParams.CODIGO_SEC_NOPOA = _dto.hdfCodNoPoa;


                oParams.ListEliTABLA = _dto.tbEliTABLA;
                oParams.ListEvalArbolAdicional = _dto.tbEvalArbolAdicional;
                oParams.ListEvalArbolNoAutorizado = _dto.tbEvalArbolNoAutorizado;

                oParams.COD_UCUENTA = asCodUCuenta;
                oParams.OUTPUTPARAM01 = "";
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegInsertarInfoDocumentPOAArboles(cn, oParams);
                }

                result.AddResultado("Los datos del plan de manejo se guardaron correctamente", true);
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;
            }
            return result;
        }
        /// <summary>
        /// Eliminar un registro de la BD sin necesidad de grabar todo el formulario
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        ///
        public void RegEliminar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegEliminar(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListResult RegEliminarList(List<CEntidad> olCEntidad)
        {
            ListResult result = new ListResult();
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegEliminarList(cn, olCEntidad);
                }
                result.AddResultado("Registro(s) eliminado(s) correctamente", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        public CEntidad RegMostrarCantidadMuestraDatosCampo(string asTipo, string asCodInforme, Int32 aiNumPoa)
        {
            try
            {
                return oCDatos.RegMostrarCantidadMuestraDatosCampo(new CEntidad() { TIPO = asTipo, COD_INFORME = asCodInforme, NUM_POA = aiNumPoa });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CapaEntidad.DOC.Ent_INFORME_MADERABLE> RegMostrarMuestraDatosCampoMade(string asCodInforme)
        {
            try
            {
                return oCDatos.RegMostrarMuestraDatosCampoMade(asCodInforme);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListResult RegInsertarMuestraDatosCampoMade(CapaEntidad.DOC.Ent_INFORME_MADERABLE aoEntidad)
        {
            ListResult result = new ListResult();
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegInsertarMuestraDatosCampoMade(cn, aoEntidad);
                }
                result.AddResultado("Ok", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        public List<CapaEntidad.DOC.Ent_INFORME_BOSQUE_SECO> RegMostrarMuestraDatosCampoBosqueSeco(string asCodInforme)
        {
            try
            {
                return oCDatos.RegMostrarMuestraDatosCampoBosqueSeco(asCodInforme);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListResult RegInsertarMuestraDatosCampoBosqueSeco(CapaEntidad.DOC.Ent_INFORME_BOSQUE_SECO aoEntidad)
        {
            ListResult result = new ListResult();
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegInsertarMuestraDatosCampoBosqueSeco(cn, aoEntidad);
                }
                result.AddResultado("Ok", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        public List<CapaEntidad.DOC.Ent_INFORME_SEMILLERO> RegMostrarMuestraDatosCampoSemi(string asCodInforme)
        {
            try
            {
                return oCDatos.RegMostrarMuestraDatosCampoSemi(asCodInforme);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListResult RegInsertarMuestraDatosCampoSemi(CapaEntidad.DOC.Ent_INFORME_SEMILLERO aoEntidad)
        {
            ListResult result = new ListResult();
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegInsertarMuestraDatosCampoSemi(cn, aoEntidad);
                }
                result.AddResultado("Ok", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        public List<CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE> RegMostrarMuestraDatosCampoNoMade(string asCodInforme)
        {
            try
            {
                return oCDatos.RegMostrarMuestraDatosCampoNoMade(asCodInforme);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListResult RegInsertarMuestraDatosCampoNoMade(CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE aoEntidad)
        {
            ListResult result = new ListResult();
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegInsertarMuestraDatosCampoNoMade(cn, aoEntidad);
                }
                result.AddResultado("Ok", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        public List<CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO> RegMostrarDatosTrozaCampo(string asCodInforme, Int32 aiNumPoa)
        {
            try
            {
                return oCDatos.RegMostrarDatosTrozaCampo(asCodInforme, aiNumPoa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListResult RegInsertarDatosTrozaCampo(List<CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO> alEntidad, string asCodUCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegInsertarDatosTrozaCampo(cn, alEntidad, asCodUCuenta);
                }
                result.AddResultado("Ok", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        public List<CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA> RegMostrarDatosMaderaAserrada(string asCodInforme, Int32 aiNumPoa)
        {
            try
            {
                return oCDatos.RegMostrarDatosMaderaAserrada(asCodInforme, aiNumPoa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListResult RegInsertarDatosMaderaAserrada(List<CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA> alEntidad, string asCodUCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegInsertarDatosMaderaAserrada(cn, alEntidad, asCodUCuenta);
                }
                result.AddResultado("Ok", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        public List<CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO> RegMostrarDatosCarrizoCampo(string asCodInforme, Int32 aiNumPoa)
        {
            try
            {
                return oCDatos.RegMostrarDatosCarrizoCampo(asCodInforme, aiNumPoa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListResult RegInsertarDatosCarrizoCampo(List<CapaEntidad.DOC.Ent_INFORME_CARRIZO_CAMPO> alEntidad, string asCodUCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegInsertarDatosCarrizoCampo(cn, alEntidad, asCodUCuenta);
                }
                result.AddResultado("Ok", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        public List<CapaEntidad.DOC.Ent_INFORME_VERTICE_VERIFICADO> RegMostrarDatosVerticeVerificado(string asCodInforme, Int32 aiNumPoa)
        {
            try
            {
                return oCDatos.RegMostrarDatosVerticeVerificado(asCodInforme, aiNumPoa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListResult RegInsertarDatosVerticeVerificado(List<CapaEntidad.DOC.Ent_INFORME_VERTICE_VERIFICADO> alEntidad, string asCodUCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegInsertarDatosVerticeVerificado(cn, alEntidad, asCodUCuenta);
                }
                result.AddResultado("Ok", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        public VM_Informe_ExSitu InitDatosInformeExSitu(string asCodInforme, string asCodCNotificacion)
        {
            VM_Informe_ExSitu vmInf = new VM_Informe_ExSitu();
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();

            try
            {
                vmInf.lblTituloCabecera = "Informe de Supervisión";

                vmInf.ddlOd = exeBus.RegMostComboIndividual("OD", "");
                vmInf.vmDatoSupervision.ddlMotivoSupervision = exeBus.RegMostComboIndividual("MOTIVO_SUPERVISION", "");
                vmInf.vmDatoSupervision.ddlTipoPeticionMotivada = exeBus.RegMostComboIndividual("TIPO_PETICION_MOTIVADA", "");
                vmInf.vmDatoSupervision.ddlTipoSupervision = exeBus.RegMostComboIndividual("TIPO_SUPERVISION", "");
                vmInf.ddlFrecFecha = exeBus.RegMostComboIndividual("FRECUENCIA_EXSITU", "");
                vmInf.ddlDispResiduoOrg = exeBus.RegMostComboIndividual("DISPONE_RESIDUO_ORG", "");
                vmInf.ddlDispResiduoInorg = exeBus.RegMostComboIndividual("DISPONE_RESIDUO_INORG", "");
                vmInf.ddlDispResiduoCadaver = exeBus.RegMostComboIndividual("DISPONE_RESIDUO_CADAVER", "");
                vmInf.ddlProtAccion = exeBus.RegMostComboIndividual("IS_CAUTIVERIO_PROT_ACCION", "");
                vmInf.ddlCuentaVetMed = exeBus.RegMostComboIndividual("CUENTA_MEDVET", "");
                vmInf.ddlTipoVisMed = exeBus.RegMostComboIndividual("TIPO_VISITAMEDVET", "");

                vmInf.vmDatoSupervision.ddlTipoInforme = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "0000000", Text = "Seleccionar" },
                    new VM_Cbo { Value = "GABINETE", Text = "GABINETE" },
                    new VM_Cbo { Value = "CAMPO", Text = "CAMPO" }
                };

                vmInf.ddlBuenDesempenio = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "Seleccionar", Text = "Seleccionar" },
                    new VM_Cbo { Value = "1", Text = "SI" },
                    new VM_Cbo { Value = "0", Text = "NO" }
                };

                vmInf.ddlArchivaInforme = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "Seleccionar", Text = "Seleccionar" },
                    new VM_Cbo { Value = "1", Text = "SI" },
                    new VM_Cbo { Value = "0", Text = "NO" }
                };

                vmInf.tbEvalZoObservatorio = new List<CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_CAUTI_EVALZOO>();
                foreach (var critZoo in exeBus.RegMostComboIndividual("CRITERIO_EVAL_ZOOBSERVATORIO", ""))
                {
                    vmInf.tbEvalZoObservatorio.Add(new CapaEntidad.DOC.Ent_ISUPERVISION_EXSITU_CAUTI_EVALZOO()
                    {
                        MAE_CRITERIO_EVALZOO = critZoo.Value,
                        CRITERIO_EVALZOO = critZoo.Text,
                        CALIFICACION = "0",
                        OBSERVACION = "",
                        RegEstado = 1
                    });
                }

                //Cargar las obligaciones del titular del TH
                var lstObligTitular = exeBus.RegMostComboIndividual("OBLIGACION_TITULAR", "OBLIGTITU_FAUNA");
                foreach (var item in lstObligTitular)
                {
                    vmInf.tbObligacionTitular.Add(new CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR()
                    {
                        COD_OBLIGTITULAR = item.Value,
                        OBLIGTITULAR = item.Text,
                        EVAL_OBLIGTITULAR = "",
                        OBSERVACION = ""
                    });
                }

                if (String.IsNullOrEmpty(asCodInforme))
                {
                    CapaEntidad.DOC.Ent_CNOTIFICACION entCN = new CapaEntidad.DOC.Ent_CNOTIFICACION();
                    Log_CNOTIFICACION exeCN = new Log_CNOTIFICACION();
                    entCN = exeCN.RegMostCNotificacion_Consulta(
                        new CapaEntidad.DOC.Ent_CNOTIFICACION()
                        {
                            BusFormulario = "DATA_CNOTIFICACION",
                            BusCriterio = "CN_CODCN_ISUPERVISION",
                            BusValor = asCodCNotificacion
                        }).FirstOrDefault();

                    vmInf.lblTituloEstado = "Nuevo Registro";
                    vmInf.vmInfCNotificacion.hdfCodCNotificacion = entCN.COD_CNOTIFICACION;
                    vmInf.vmInfCNotificacion.txtCNotificacion = entCN.NUMERO;
                    vmInf.vmInfCNotificacion.txtTHabilitante = entCN.NUM_THABILITANTE;
                    vmInf.tbPersonalTecProf = new List<Ent_GENEPERSONA>();
                    vmInf.hdfRegEstado = 1;
                }
                else
                {
                    //Obtener datos del informe
                    CEntidad entInf = INFORME_ISUPERVISION_EXSITU_MostItem(new CEntidad() { COD_INFORME = asCodInforme });

                    vmInf.lblTituloEstado = "Modificando Registro";
                    vmInf.vmControlCalidad.ddlIndicadorId = entInf.COD_ESTADO_DOC;
                    vmInf.vmControlCalidad.chkObsSubsanada = (bool)entInf.OBSERV_SUBSANAR;
                    vmInf.vmControlCalidad.txtControlCalidadObservaciones = entInf.OBSERVACIONES_CONTROL.ToString();
                    vmInf.vmControlCalidad.txtUsuarioControl = entInf.USUARIO_CONTROL;
                    vmInf.vmControlCalidad.txtUsuarioRegistro = entInf.USUARIO_REGISTRO;

                    vmInf.hdfCodInforme = asCodInforme;
                    vmInf.hdfRegEstado = 0;
                    vmInf.chkPublicar = (bool)entInf.PUBLICAR;
                    vmInf.txtObsPublicar = entInf.OBSERVACION_PUBLICAR;

                    vmInf.chkRecomendar = (bool)entInf.RECOMENDARC;
                    vmInf.txtMandatos = entInf.MANDATOC;
                    vmInf.txtConclusion = entInf.CONCLUSIONC;
                    vmInf.txtRecomendacion = entInf.RECOMENDACIONC;

                    CEntidad entGenInf = RegMostrarDatosCabecera(asCodInforme);
                    vmInf.vmInfCNotificacion.hdfCodCNotificacion = entGenInf.COD_CNOTIFICACION;
                    vmInf.vmInfCNotificacion.txtCNotificacion = entGenInf.NUM_CNOTIFICACION;
                    vmInf.vmInfCNotificacion.txtTHabilitante = entGenInf.NUM_THABILITANTE;

                    vmInf.ddlOdId = entInf.COD_OD_REGISTRO;
                    vmInf.chkTodos = (bool)entInf.TODOSINDICADORES;
                    vmInf.chkHechos = (bool)entInf.HECHOSDENUNCIADOS;
                    vmInf.chkMandatos = (bool)entInf.MANDATOS;
                    vmInf.chkMedidas = (bool)entInf.MEDIDASCORRECTIVAS;
                    vmInf.ddlCuentaVetMedId = entInf.CUENTAMEDVET;
                    vmInf.ddlTipoVisMedId = entInf.TIPOVISMED;
                    vmInf.txtVisitaporMes = entInf.VISITAMES;
                    vmInf.txtObsMedVet = entInf.OBSMEDVET;
                    vmInf.chkFFPropia = (bool)entInf.FFPROPIAS;
                    vmInf.chkFFDonaciones = (bool)entInf.FFDONACIONES;
                    vmInf.chkFFCredito = (bool)entInf.FFCREDITO;
                    vmInf.chkFFInversionista = (bool)entInf.FFINVERSIONISTA;
                    vmInf.chkFFApoyo = (bool)entInf.FFAPOYO;
                    vmInf.chkFFVoluntario = (bool)entInf.FFVOLUNTARIO;
                    vmInf.txtFFOtro = entInf.FFOTRO == " " ? "" : entInf.FFOTRO;

                    vmInf.txtNumInforme = entInf.NUMERO;
                    vmInf.txtFechaEntrega = entInf.FECHA_ENTREGA.ToString();

                    vmInf.vmDatoSupervision.txtFechaInicio = entInf.FECHA_SUPERVISION_INICIO.ToString();
                    vmInf.vmDatoSupervision.txtFechaFin = entInf.FECHA_SUPERVISION_FIN.ToString();
                    vmInf.vmDatoSupervision.ddlMotivoSupervisionId = entInf.COD_IMOTIVO;
                    vmInf.vmDatoSupervision.txtMotivoSupervision = entInf.IMOTIVO;
                    vmInf.vmDatoSupervision.ddlTipoSupervisionId = entInf.COD_TIPO_SUPER;
                    vmInf.vmDatoSupervision.ddlTipoInformeId = entInf.TIPO_INFORME;
                    vmInf.vmDatoSupervision.ddlTipoPeticionMotivadaId = entInf.MAE_TIP_MOTMOTIVADA;
                    vmInf.vmDatoSupervision.hdfCodDocDenunciaSITD = entInf.COD_TRAMITE_SITD.ToString();
                    vmInf.vmDatoSupervision.txtDocDenunciaSITD = entInf.NUM_DREFERENCIA;
                    vmInf.vmDatoSupervision.chkGeoTecDron = (bool)entInf.GEOTEC_DRON;
                    vmInf.vmDatoSupervision.chkGeoTecGeoSupervisor = (bool)entInf.GEOTEC_GEOSUPERVISOR;
                    vmInf.vmDatoSupervision.chkGeoTecNinguno = (bool)entInf.GEOTEC_NINGUNO;
                    vmInf.vmDatoSupervision.chkGeoTecOtro = (bool)entInf.GEOTEC_OTROS;
                    vmInf.vmDatoSupervision.txtGeoTecOtro = entInf.GEOTEC_DESCRIPCION;

                    vmInf.chkLicFuncionamiento = (bool)entInf.LICENCIA_ESTADO;
                    vmInf.txtLicFuncionamiento = entInf.LICENCIA_NUMERO;
                    vmInf.hdfCodUbigeo = entInf.THABILITANTE_COD_UBIGEO;
                    vmInf.txtUbigeo = entInf.UBIGEO;
                    vmInf.txtSector = entInf.THABILITANTE_SECTOR;
                    vmInf.chkRegente = (bool)entInf.CUENTA_REGENTE;
                    vmInf.txtRegente = entInf.NOMBRE_REGENTE;
                    vmInf.hdfCodRegente = entInf.CODIGO;
                    vmInf.txtCodigoRegente = entInf.CODIGO_REGENTE;
                    vmInf.txtFecIniRegencia = entInf.FECHA_REGENTE.ToString();
                    vmInf.txtObjetivoActual = entInf.OBJ_ACTUAL;
                    vmInf.txtObjetivoPrincipal = entInf.OBJ_PRINCIP;
                    vmInf.chkRecibeVisita = (bool)entInf.VISITA;
                    vmInf.chkReproduceEspCautiverio = (bool)entInf.REPRODUCE;
                    vmInf.tbSupervisor = entInf.ListInformeDetSupervisor;
                    vmInf.txtObservacion = entInf.OBSERVACION;//No se esta obteniendo ni guardando este campo
                    //Infraestructura
                    vmInf.chkCroquis = (bool)entInf.CUENTA_CROQUIS;
                    vmInf.chkViaSenalizada = (bool)entInf.TIENE_VIAS;
                    vmInf.chkCartelAreaAdmin = (bool)entInf.AREA_ADMINISTRATIVA_TCARTEL;
                    vmInf.chkCartelSSHH = (bool)entInf.AREA_SHIGIENICO_TCARTEL;
                    vmInf.txtDescOtroAmbiente = entInf.AREA_OTROS_OBSERVACION;
                    vmInf.tbAreaExSitu = entInf.ListAreaExsitu;
                    //Cautiverio
                    vmInf.hdfCodResponsable = entInf.RESPONSABLE_COD_PERSONA;
                    vmInf.txtResponsable = entInf.RESPONSABLE_NOMBRE;
                    vmInf.chkProgAlimentacion = (bool)entInf.PROGRAMA_ALIMENTACION;
                    vmInf.chkProtAlimentacion = (bool)entInf.PICIENTIFICA_IREALIZADA;
                    vmInf.ddlProgContencionId = entInf.REALIZA_PCONTENCION;
                    vmInf.ddlProgBioseguridadId = entInf.REALIZA_PBIOSEGURIDAD;
                    vmInf.chkProtLimpieza = (bool)entInf.PROTOCOLO_LIMPIEZA;
                    vmInf.ddlFrecLimpiezaId = entInf.FLIMPIEZA_COD_TDESCRIPTIVA;
                    vmInf.txtFrecLimpieza = entInf.BIOSEGURIDADOTROS;
                    vmInf.chkPediluvio = (bool)entInf.PEDILUVIOS;
                    vmInf.chkManejoResiduo = (bool)entInf.MANEJO_RESIDUOS_SOLIDOS;
                    vmInf.ddlDispResiduoOrgId = entInf.DRORGANICO_COD_TDESCRIPTIVA;
                    vmInf.ddlDispResiduoInorgId = entInf.DRINORGANICO_COD_TDESCRIPTIVA;
                    vmInf.ddlDispResiduoCadaverId = entInf.DCADAVERES_COD_TDESCRIPTIVA;
                    vmInf.ddlFrecDesinfeccionId = entInf.FDESINFECCION_COD_TDESCRIPTIVA;
                    vmInf.txtFrecDesinfeccion = entInf.OBSERVACION_FRECUENCIA;
                    vmInf.ddlProgEnriquecimientoId = entInf.REALIZA_PENRIQUECIMIENTO;
                    vmInf.ddlProgGeneticoId = entInf.REALIZA_PMANEJOGEN;
                    vmInf.ddlProgEducacionId = entInf.REALIZA_PEDUCAMB;
                    vmInf.ddlProgInvetigacionId = entInf.REALIZA_PINVCIENT;
                    vmInf.ddlProgCapturaId = entInf.REALIZA_PCOLECTA;
                    vmInf.ddlProgCapacitacionId = entInf.REALIZA_CAPCITAC;
                    vmInf.tbGrupoTaxonomico = entInf.ListGrupoToxonomico;
                    vmInf.tbEquipoContFisico = entInf.ListProgManejoSanitarioFisico;
                    vmInf.tbEquipoContQuimico = entInf.ListProgManejoSanitarioQuimico;
                    vmInf.tbEquipoLimpieza = entInf.ListProgBioFrecuenciaLimpieza;
                    vmInf.tbMaterialDesinfeccion = entInf.ListMaterialDesinfeccion;
                    vmInf.tbEquipoDesinfeccion = entInf.ListEquipoDesinfeccion;
                    vmInf.tbControlPlaga = entInf.ListCautiverioControlPlaga;
                    vmInf.tbManejoRegistro = entInf.LisCautiveriotManejoRegistro;
                    vmInf.tbEnriquecimientoAmb = entInf.LisCautiverioEnriquecAmbiental;
                    vmInf.tbEspecieReproducida = entInf.LisCautiverioEspecieReproducida;
                    vmInf.tbEspecieCapturada = entInf.LisCautiverioECapturado;
                    vmInf.tbCapacitacion = entInf.LisCapacitacionFauna;
                    vmInf.tbEspecieNacimiento = entInf.ListNacimientosEspecies;
                    vmInf.tbEspecieEgreso = entInf.ListEgresosEspecies;
                    vmInf.tbEspecieCenso = entInf.LisCautiverioCensoVertebrado;
                    vmInf.tbRelPelCentroCria = entInf.ListRelPelCentroCria;
                    vmInf.tbActividadEducacion = entInf.LisCautiverioActividadRealizada;
                    vmInf.tbActividadInvestigacion = entInf.LisCautiverioCensoICientifica;
                    vmInf.tbMandatos = entInf.ListMandatos;

                    vmInf.tbFotoSupervision = entInf.ListFotos;
                    vmInf.txtCalificacionZoo = entInf.CALIFICACION_EVALZOO;
                    if (entInf.ListEvalZoObservatorio.Count > 0)
                    {
                        vmInf.tbEvalZoObservatorio = entInf.ListEvalZoObservatorio;
                    }
                    vmInf.tbDesplazamiento = entInf.ListDesplazamientoInforme;
                    vmInf.tbBalanceIngEgr = entInf.ListISuperExsituBalance;
                    vmInf.tbPersonalTecProf = entInf.ListPersonalTecProf;

                    //Cargar las obligaciones del titular del TH
                    if (entInf.ListISuperExsituOBLIGF.Count > 0)
                    {
                        vmInf.tbObligacionTitular = new List<Ent_INFORME_OBLIGTITULAR>();

                        foreach (var item in entInf.ListISuperExsituOBLIGF)
                        {
                            vmInf.tbObligacionTitular.Add(new Ent_INFORME_OBLIGTITULAR()
                            {
                                COD_OBLIGTITULAR = item.MAE_OBLIGTITULAR,
                                OBLIGTITULAR = item.CODIGO_NOMBRE,
                                EVAL_OBLIGTITULAR = item.EVAL_OBLIGTITULAR,
                                OBSERVACION = item.OBSERVACION_OBLIG
                            });
                        }
                    }

                    vmInf.txtHoraRepAlimento = entInf.HORARIO_RALIMENTO;
                    vmInf.txtDiaAbastecimiento = entInf.DIAS_ABASTECIMIENTO;
                    vmInf.ddlProtContingenciaId = entInf.PROTOCOL_CONTINGENCIA;
                    vmInf.ddlProtAccionId = entInf.PROTOCOL_ACCION;
                    vmInf.txtObsProtAccion = entInf.OBSERVACION_CONTENCION;
                    vmInf.ddlPresentInfEjecPMId = entInf.INFORME_EJECUCIONPM;
                    vmInf.txtAnioPresentInfEjec = entInf.ANIOS_EJECUCIONPM;
                    vmInf.ddlBuenDesempenioId = entInf.BUEN_DESEMPENIO.ToString();
                    vmInf.ddlArchivaInformeId = (entInf.ARCHIVA_INFORME == -1) ? "Seleccionar" : entInf.ARCHIVA_INFORME.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vmInf;
        }
        public ListResult GuardarDatosInformeExSitu(VM_Informe_ExSitu _dto, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                ValidarDatosInformeExSitu(_dto);

                CEntidad paramsInf = new CEntidad();
                paramsInf.COD_ESTADO_DOC = _dto.vmControlCalidad.ddlIndicadorId;
                paramsInf.OBSERVACIONES_CONTROL = _dto.vmControlCalidad.txtControlCalidadObservaciones ?? "";
                paramsInf.OBSERV_SUBSANAR = _dto.vmControlCalidad.chkObsSubsanada == true ? 1 : 0;
                paramsInf.PUBLICAR = _dto.chkPublicar == true ? 1 : 0;

                paramsInf.RECOMENDARC = _dto.chkRecomendar == true ? 1 : 0;
                paramsInf.MANDATOC = _dto.txtMandatos;
                paramsInf.RECOMENDACIONC = _dto.txtRecomendacion;
                paramsInf.CONCLUSIONC = _dto.txtConclusion;

                paramsInf.TODOSINDICADORES = _dto.chkTodos == true ? 1 : 0;
                paramsInf.HECHOSDENUNCIADOS = _dto.chkHechos == true ? 1 : 0;
                paramsInf.MANDATOS = _dto.chkMandatos == true ? 1 : 0;
                paramsInf.MEDIDASCORRECTIVAS = _dto.chkMedidas == true ? 1 : 0;
                paramsInf.FFPROPIAS = _dto.chkFFPropia == true ? 1 : 0;
                paramsInf.FFDONACIONES = _dto.chkFFDonaciones == true ? 1 : 0;
                paramsInf.FFCREDITO = _dto.chkFFCredito == true ? 1 : 0;
                paramsInf.FFINVERSIONISTA = _dto.chkFFInversionista == true ? 1 : 0;
                paramsInf.FFAPOYO = _dto.chkFFApoyo == true ? 1 : 0;
                paramsInf.FFVOLUNTARIO = _dto.chkFFVoluntario == true ? 1 : 0;
                paramsInf.FFOTRO = _dto.txtFFOtro;
                paramsInf.CUENTAMEDVET = _dto.ddlCuentaVetMedId;
                paramsInf.TIPOVISMED = _dto.ddlTipoVisMedId;
                paramsInf.VISITAMES = _dto.txtVisitaporMes ?? "";
                paramsInf.OBSMEDVET = _dto.txtObsMedVet ?? "";

                paramsInf.OBSERVACION_PUBLICAR = _dto.txtObsPublicar ?? "";
                paramsInf.COD_CNOTIFICACION = _dto.vmInfCNotificacion.hdfCodCNotificacion;
                paramsInf.COD_OD_REGISTRO = _dto.ddlOdId;
                paramsInf.COD_INFORME = _dto.hdfCodInforme ?? "";
                paramsInf.NUMERO = _dto.txtNumInforme;
                paramsInf.COD_ITIPO = "0000001";
                paramsInf.ESTADO_ORIGEN = "TH";
                paramsInf.FECHA_SUPERVISION_INICIO = _dto.vmDatoSupervision.txtFechaInicio;
                paramsInf.FECHA_SUPERVISION_FIN = _dto.vmDatoSupervision.txtFechaFin;
                paramsInf.FECHA_ENTREGA = _dto.txtFechaEntrega;
                paramsInf.COD_IMOTIVO = _dto.vmDatoSupervision.ddlMotivoSupervisionId;
                paramsInf.COD_TIPO_SUPER = _dto.vmDatoSupervision.ddlTipoSupervisionId;
                if (paramsInf.COD_IMOTIVO == "0000011")//Petición motivada
                {
                    paramsInf.MAE_TIP_MOTMOTIVADA = _dto.vmDatoSupervision.ddlTipoPeticionMotivadaId;
                    paramsInf.COD_TRAMITE_SITD = Convert.ToInt32(_dto.vmDatoSupervision.hdfCodDocDenunciaSITD ?? "0");
                }
                paramsInf.LICENCIA_ESTADO = _dto.chkLicFuncionamiento;
                paramsInf.LICENCIA_NUMERO = _dto.txtLicFuncionamiento ?? "";
                paramsInf.THABILITANTE_COD_UBIGEO = _dto.hdfCodUbigeo ?? "";
                paramsInf.THABILITANTE_SECTOR = _dto.txtSector ?? "";
                paramsInf.CUENTA_REGENTE = _dto.chkRegente;
                if ((bool)paramsInf.CUENTA_REGENTE)
                {
                    paramsInf.NOMBRE_REGENTE = _dto.hdfCodRegente;
                    paramsInf.CODIGO_REGENTE = _dto.txtCodigoRegente ?? "";
                    paramsInf.FECHA_REGENTE = _dto.txtFecIniRegencia ?? "";
                }
                paramsInf.OBJ_ACTUAL = _dto.txtObjetivoActual ?? "";
                paramsInf.OBJ_PRINCIP = _dto.txtObjetivoPrincipal ?? "";
                paramsInf.VISITA = _dto.chkRecibeVisita;
                paramsInf.REPRODUCE = _dto.chkReproduceEspCautiverio;
                paramsInf.GEOTEC_DRON = _dto.vmDatoSupervision.chkGeoTecDron;
                paramsInf.GEOTEC_GEOSUPERVISOR = _dto.vmDatoSupervision.chkGeoTecGeoSupervisor;
                paramsInf.GEOTEC_NINGUNO = _dto.vmDatoSupervision.chkGeoTecNinguno;
                paramsInf.GEOTEC_OTROS = _dto.vmDatoSupervision.chkGeoTecOtro;
                if ((bool)paramsInf.GEOTEC_OTROS)
                {
                    paramsInf.GEOTEC_DESCRIPCION = _dto.vmDatoSupervision.txtGeoTecOtro;
                }
                paramsInf.OBSERVACION = _dto.txtObservacion ?? "";
                paramsInf.ListInformeDetSupervisor = _dto.tbSupervisor;
                //Infraestructura
                paramsInf.CUENTA_CROQUIS = _dto.chkCroquis;
                paramsInf.TIENE_VIAS = _dto.chkViaSenalizada;
                paramsInf.AREA_ADMINISTRATIVA_TCARTEL = _dto.chkCartelAreaAdmin;
                paramsInf.AREA_SHIGIENICO_TCARTEL = _dto.chkCartelSSHH;
                paramsInf.AREA_OTROS_OBSERVACION = _dto.txtDescOtroAmbiente;
                paramsInf.ListAreaExsitu = _dto.tbAreaExSitu;
                //Cautiverio
                paramsInf.RESPONSABLE_COD_PERSONA = _dto.hdfCodResponsable;
                paramsInf.PROGRAMA_ALIMENTACION = _dto.chkProgAlimentacion;
                paramsInf.PICIENTIFICA_IREALIZADA = _dto.chkProtAlimentacion;
                paramsInf.REALIZA_PCONTENCION = _dto.ddlProgContencionId;
                paramsInf.REALIZA_PBIOSEGURIDAD = _dto.ddlProgBioseguridadId;
                paramsInf.PROTOCOLO_LIMPIEZA = _dto.chkProtLimpieza;
                paramsInf.FLIMPIEZA_COD_TDESCRIPTIVA = _dto.ddlFrecLimpiezaId;
                paramsInf.BIOSEGURIDADOTROS = _dto.txtFrecLimpieza;
                paramsInf.PEDILUVIOS = _dto.chkPediluvio;
                paramsInf.MANEJO_RESIDUOS_SOLIDOS = _dto.chkManejoResiduo;
                paramsInf.DRORGANICO_COD_TDESCRIPTIVA = _dto.ddlDispResiduoOrgId;
                paramsInf.DRINORGANICO_COD_TDESCRIPTIVA = _dto.ddlDispResiduoInorgId;
                paramsInf.DCADAVERES_COD_TDESCRIPTIVA = _dto.ddlDispResiduoCadaverId;
                paramsInf.FDESINFECCION_COD_TDESCRIPTIVA = _dto.ddlFrecDesinfeccionId;
                paramsInf.OBSERVACION_FRECUENCIA = _dto.txtFrecDesinfeccion;
                paramsInf.REALIZA_PENRIQUECIMIENTO = _dto.ddlProgEnriquecimientoId;
                paramsInf.REALIZA_PMANEJOGEN = _dto.ddlProgGeneticoId;
                paramsInf.REALIZA_PEDUCAMB = _dto.ddlProgEducacionId;
                paramsInf.REALIZA_PINVCIENT = _dto.ddlProgInvetigacionId;
                paramsInf.REALIZA_PCOLECTA = _dto.ddlProgCapturaId;
                paramsInf.REALIZA_CAPCITAC = _dto.ddlProgCapacitacionId;
                paramsInf.ListGrupoToxonomico = _dto.tbGrupoTaxonomico;
                paramsInf.ListProgManejoSanitarioFisico = _dto.tbEquipoContFisico;
                paramsInf.ListProgManejoSanitarioQuimico = _dto.tbEquipoContQuimico;
                paramsInf.ListProgBioFrecuenciaLimpieza = _dto.tbEquipoLimpieza;
                paramsInf.ListMaterialDesinfeccion = _dto.tbMaterialDesinfeccion;
                paramsInf.ListEquipoDesinfeccion = _dto.tbEquipoDesinfeccion;
                paramsInf.ListCautiverioControlPlaga = _dto.tbControlPlaga;
                paramsInf.LisCautiveriotManejoRegistro = _dto.tbManejoRegistro;
                paramsInf.LisCautiverioEnriquecAmbiental = _dto.tbEnriquecimientoAmb;
                paramsInf.LisCautiverioEspecieReproducida = _dto.tbEspecieReproducida;
                paramsInf.LisCautiverioECapturado = _dto.tbEspecieCapturada;
                paramsInf.LisCapacitacionFauna = _dto.tbCapacitacion;
                paramsInf.ListNacimientosEspecies = _dto.tbEspecieNacimiento;
                paramsInf.ListEgresosEspecies = _dto.tbEspecieEgreso;
                paramsInf.LisCautiverioCensoVertebrado = _dto.tbEspecieCenso;
                paramsInf.LisCautiverioActividadRealizada = _dto.tbActividadEducacion;
                paramsInf.LisCautiverioCensoICientifica = _dto.tbActividadInvestigacion;
                paramsInf.ListEvalZoObservatorio = _dto.tbEvalZoObservatorio;
                paramsInf.ListISuperExsituBalance = _dto.tbBalanceIngEgr;
                paramsInf.ListRelPelCentroCria = _dto.tbRelPelCentroCria;
                paramsInf.ListMandatos = _dto.tbMandatos;

                double puntuacion = 0;
                foreach (var item in paramsInf.ListEvalZoObservatorio)
                {
                    puntuacion += Convert.ToDouble(item.CALIFICACION);
                }
                double calificacion = puntuacion == 0 ? 0 : (puntuacion / 2);
                paramsInf.CALIFICACION_EVALZOO = calificacion;
                paramsInf.ListEliTABLA = _dto.tbEliTABLA;
                paramsInf.ListDesplazamientoInforme = _dto.tbDesplazamiento;
                paramsInf.ListPersonalTecProf = _dto.tbPersonalTecProf;
                paramsInf.ListISuperExsituOBLIGF = new List<CEntISExsitu>();

                foreach (var item in _dto.tbObligacionTitular)
                {
                    paramsInf.ListISuperExsituOBLIGF.Add(new CEntISExsitu()
                    {
                        MAE_OBLIGTITULAR = item.COD_OBLIGTITULAR,
                        EVAL_OBLIGTITULAR = item.EVAL_OBLIGTITULAR,
                        OBSERVACION_OBLIG = item.OBSERVACION ?? ""
                    });
                }

                paramsInf.DIAS_ABASTECIMIENTO = _dto.txtDiaAbastecimiento ?? "";
                paramsInf.HORARIO_RALIMENTO = _dto.txtHoraRepAlimento ?? "";
                paramsInf.PROTOCOL_ACCION = _dto.ddlProtAccionId == "0000000" ? null : _dto.ddlProtAccionId;
                paramsInf.PROTOCOL_CONTINGENCIA = _dto.ddlProtContingenciaId == "0000000" ? null : _dto.ddlProtContingenciaId;
                paramsInf.OBSERVACION_CONTENCION = _dto.txtObsProtAccion ?? "";
                paramsInf.INFORME_EJECUCIONPM = _dto.ddlPresentInfEjecPMId == "0000000" ? null : _dto.ddlPresentInfEjecPMId;
                paramsInf.ANIOS_EJECUCIONPM = _dto.txtAnioPresentInfEjec ?? "";

                paramsInf.COD_UCUENTA = asCodUCuenta;
                paramsInf.RegEstado = _dto.hdfRegEstado;
                paramsInf.OUTPUTPARAM01 = "";
                paramsInf.COD_SUP_CALIDAD = _dto.hdSupervisor_Calidad;
                paramsInf.TIPO_INFORME = _dto.vmDatoSupervision.ddlTipoInformeId;
                ReglInsertarInforme_Exsitu(paramsInf);

                string msjRespuesta = _dto.hdfRegEstado == 1 ? "El Registro se Guardo Correctamente" : "El Registro se Modifico Correctamente";
                result.AddResultado(msjRespuesta, true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }
        private void ValidarDatosInformeExSitu(VM_Informe_ExSitu _dto)
        {
            if (_dto.vmControlCalidad.ddlIndicadorId == "0000000") throw new Exception("Seleccione el estado actual del registro");
            if (_dto.ddlOdId == "0000000") throw new Exception("Seleccione la oficina desconcentrada");

            if (string.IsNullOrEmpty(_dto.txtNumInforme)) throw new Exception("Ingrese el número del informe de supervisión");
            if (string.IsNullOrEmpty(_dto.vmDatoSupervision.txtFechaInicio)) throw new Exception("Seleccione la fecha de inicio de la supervisión");
            if (string.IsNullOrEmpty(_dto.vmDatoSupervision.txtFechaFin)) throw new Exception("Seleccione la fecha de término de la supervisión");
            if (string.IsNullOrEmpty(_dto.txtFechaEntrega)) throw new Exception("Seleccione la fecha de entrega del informe");
            if (string.IsNullOrEmpty(_dto.vmInfCNotificacion.hdfCodCNotificacion)) throw new Exception("No se encuentra la Carta de Notificación asociada");
        }

        public CEntidad RegIECOTURISMOMostrarListaItem_v3(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegIECOTURISMOMostrarListaItem_v3(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VM_Informe_Conservacion InitDatosInformeConservacion(string asCodInforme, string asCodCNotificacion)
        {
            VM_Informe_Conservacion vmInf = new VM_Informe_Conservacion();
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            CapaLogica.DOC.Log_BUSQUEDA exeBusqueda = new CapaLogica.DOC.Log_BUSQUEDA();

            try
            {
                vmInf.lblTituloCabecera = "Informe de Supervisión";
                vmInf.ddlOd = exeBus.RegMostComboIndividual("OD", "");
                vmInf.vmDatoSupervision.ddlMotivoSupervision = exeBus.RegMostComboIndividual("MOTIVO_SUPERVISION", "");
                vmInf.vmDatoSupervision.ddlTipoPeticionMotivada = exeBus.RegMostComboIndividual("TIPO_PETICION_MOTIVADA", "");
                vmInf.vmDatoSupervision.ddlTipoSupervision = exeBus.RegMostComboIndividual("TIPO_SUPERVISION", "");

                vmInf.vmDatoSupervision.ddlTipoInforme = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "0000000", Text = "Seleccionar" },
                    new VM_Cbo { Value = "GABINETE", Text = "GABINETE" },
                    new VM_Cbo { Value = "CAMPO", Text = "CAMPO" }
                };

                vmInf.ddlBuenDesempenio = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "Seleccionar", Text = "Seleccionar" },
                    new VM_Cbo { Value = "1", Text = "SI" },
                    new VM_Cbo { Value = "0", Text = "NO" }
                };

                vmInf.ddlArchivaInforme = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "Seleccionar", Text = "Seleccionar" },
                    new VM_Cbo { Value = "1", Text = "SI" },
                    new VM_Cbo { Value = "0", Text = "NO" }
                };

                if (String.IsNullOrEmpty(asCodInforme))
                {
                    CapaEntidad.DOC.Ent_CNOTIFICACION entCN = new CapaEntidad.DOC.Ent_CNOTIFICACION();
                    Log_CNOTIFICACION exeCN = new Log_CNOTIFICACION();
                    entCN = exeCN.RegMostCNotificacion_Consulta(
                        new CapaEntidad.DOC.Ent_CNOTIFICACION()
                        {
                            BusFormulario = "DATA_CNOTIFICACION",
                            BusCriterio = "CN_CODCN_ISUPERVISION",
                            BusValor = asCodCNotificacion
                        }).FirstOrDefault();

                    vmInf.lblTituloEstado = "Nuevo Registro";
                    vmInf.vmInfCNotificacion.hdfCodCNotificacion = entCN.COD_CNOTIFICACION;
                    vmInf.vmInfCNotificacion.txtCNotificacion = entCN.NUMERO;
                    /*CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA entCN = new CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA();
                    Log_NOTIFICACION exeCN = new Log_NOTIFICACION();
                    entCN = exeCN.RegListarNotificacionConsulta_v3(
                        new CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA()
                        {
                            BusFormulario = "MODAL_NOTIFICACION",
                            BusCriterio = "FN_CODIGO",
                            BusValor = asCodNotificacion
                        }).FirstOrDefault();

                    vmInf.lblTituloEstado = "Nuevo Registro";
                    vmInf.vmInfCNotificacion.hdfCodCNotificacion = entCN.COD_FISNOTI;
                    vmInf.vmInfCNotificacion.txtCNotificacion = entCN.NUM_NOTIFICACION;*/
                    vmInf.vmInfCNotificacion.txtTHabilitante = entCN.NUM_THABILITANTE;
                    vmInf.hdfRegEstado = 1;

                    //Cargar las obligaciones del titular del TH
                    var lstObligTitular = exeBus.RegMostComboIndividual("OBLIGACION_TITULAR", "OBLIGTITU_NOMADE");
                    foreach (var item in lstObligTitular)
                    {
                        vmInf.tbObligTitular.Add(new CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR()
                        {
                            COD_OBLIGTITULAR = item.Value,
                            OBLIGTITULAR = item.Text,
                            EVAL_OBLIGTITULAR = "",
                            OBSERVACION = ""
                        });
                    }
                    vmInf.ddlZona = exeBusqueda.RegMostComboIndividual("ZONA_UTM", "");
                }
                else
                {
                    //Obtener datos del informe
                    CEntidad entInf = RegIECOTURISMOMostrarListaItem_v3(new CEntidad() { COD_INFORME = asCodInforme });

                    vmInf.lblTituloEstado = "Modificando Registro";
                    vmInf.vmControlCalidad.ddlIndicadorId = entInf.COD_ESTADO_DOC;
                    vmInf.vmControlCalidad.chkObsSubsanada = (bool)entInf.OBSERV_SUBSANAR;
                    vmInf.vmControlCalidad.txtControlCalidadObservaciones = entInf.OBSERVACIONES_CONTROL.ToString();
                    vmInf.vmControlCalidad.txtUsuarioControl = entInf.USUARIO_CONTROL;
                    vmInf.vmControlCalidad.txtUsuarioRegistro = entInf.USUARIO_REGISTRO;

                    vmInf.hdfCodInforme = asCodInforme;
                    vmInf.hdfRegEstado = 0;

                    CEntidad entGenInf = RegMostrarDatosCabecera(asCodInforme);
                    vmInf.vmInfCNotificacion.hdfCodCNotificacion = entGenInf.COD_CNOTIFICACION;
                    vmInf.vmInfCNotificacion.txtCNotificacion = entGenInf.NUM_CNOTIFICACION;
                    /*CEntidad entGenInf = oCDatos.RegMostrarDatosCabecera_v3(asCodInforme);
                    vmInf.vmInfCNotificacion.hdfCodCNotificacion = entGenInf.COD_FISNOTI;
                    vmInf.vmInfCNotificacion.txtCNotificacion = entGenInf.NUM_NOTIFICACION;*/
                    vmInf.vmInfCNotificacion.txtTHabilitante = entGenInf.NUM_THABILITANTE;

                    vmInf.ddlOdId = entInf.COD_OD_REGISTRO;
                    vmInf.txtNumInforme = entInf.NUMERO;
                    vmInf.txtFechaEntrega = entInf.FECHA_ENTREGA.ToString();
                    vmInf.tbSupervisor = entInf.ListInformeDetSupervisor;

                    vmInf.vmDatoSupervision.txtFechaInicio = entInf.FECHA_SUPERVISION_INICIO.ToString();
                    vmInf.vmDatoSupervision.txtFechaFin = entInf.FECHA_SUPERVISION_FIN.ToString();
                    vmInf.vmDatoSupervision.ddlMotivoSupervisionId = entInf.COD_IMOTIVO;
                    vmInf.vmDatoSupervision.txtMotivoSupervision = entInf.IMOTIVO;
                    vmInf.vmDatoSupervision.ddlTipoPeticionMotivadaId = entInf.MAE_TIP_MOTMOTIVADA;
                    vmInf.vmDatoSupervision.ddlTipoSupervisionId = entInf.COD_TIPO_SUPER;
                    vmInf.vmDatoSupervision.ddlTipoInformeId = entInf.TIPO_INFORME;
                    vmInf.vmDatoSupervision.hdfCodDocDenunciaSITD = entInf.COD_TRAMITE_SITD.ToString();
                    vmInf.vmDatoSupervision.txtDocDenunciaSITD = entInf.NUM_DREFERENCIA;
                    vmInf.vmDatoSupervision.chkGeoTecDron = (bool)entInf.GEOTEC_DRON;
                    vmInf.vmDatoSupervision.chkGeoTecGeoSupervisor = (bool)entInf.GEOTEC_GEOSUPERVISOR;
                    vmInf.vmDatoSupervision.chkGeoTecNinguno = (bool)entInf.GEOTEC_NINGUNO;
                    vmInf.vmDatoSupervision.chkGeoTecOtro = (bool)entInf.GEOTEC_OTROS;
                    vmInf.vmDatoSupervision.txtGeoTecOtro = entInf.GEOTEC_DESCRIPCION;

                    vmInf.txtObservacion = entInf.OBSERVACION;
                    vmInf.txtConclusion = entInf.CONCLUSION;
                    vmInf.txtAsunto = entInf.ASUNTO;
                    vmInf.txtContenido = entInf.CONTENIDO.ToString();

                    vmInf.hdfCodUbigeo = entInf.THABILITANTE_COD_UBIGEO;
                    vmInf.txtUbigeo = entInf.UBIGEO;
                    vmInf.txtSector = entInf.THABILITANTE_SECTOR;
                    vmInf.hdfCodTitularEjecutaPgmf = entInf.COD_TITULAR_EJECUTA;
                    vmInf.txtTitularEjecutaPgmf = entInf.TITULAR_EJECUTA;
                    vmInf.hdfCodRegenteImplPgmf = entInf.COD_REGENTE_IMPLEMENTA;
                    vmInf.txtRegenteImplPgmf = entInf.REGENTE_IMPLEMENTA;
                    vmInf.tbCoordenadaUTM = entInf.ListVertice;
                    vmInf.tbPrograma = entInf.ListPrograma;
                    vmInf.ddlCuentaCroquisId = (bool)entInf.CUENTA_CROQUIS == true ? "SI" : "NO";
                    vmInf.ddlCuentaSenderoId = (bool)entInf.CUENTA_SENDERO_RUTA == true ? "SI" : "NO";
                    vmInf.ddlSenalizacionSenderoId = (bool)entInf.TIENE_VIAS == true ? "SI" : "NO";
                    vmInf.tbInfraestructura = entInf.ListISUPERVISION_INFRAESTRUCTURA;
                    vmInf.tbActividadPrograma = entInf.ListISUPERVISION_DET_CAPACITACION_LOCAL;
                    vmInf.tbManejoImpacto = entInf.ListISUPERVISION_IDENTMANEJOIMPACTO;
                    vmInf.tbRegFauna = entInf.ListAvistamientoFauna;
                    vmInf.tbRegFlora = entInf.ListRegistroFlora;
                    vmInf.tbRegPaisaje = entInf.ListRegistroPaisaje;
                    vmInf.tbZonificacion = entInf.ListISUPERVISION_DET_ZONIFICACION;
                    vmInf.tbEquipamiento = entInf.ListISUPERVISION_DET_EQUIPACONSECION;
                    vmInf.tbObligacion = entInf.ListISUPERVISION_OCARACTE_AMB01;
                    vmInf.tbObligTitular = entInf.ListObligacionTitular.Where(m => m.COD_GRUPO == "OBLIGTITU_NOMADE").ToList();
                    vmInf.tbDesplazamiento = entInf.ListDesplazamientoInforme;
                    vmInf.tbActTuristica = entInf.ListISDetConservActTuristica;
                    vmInf.tbImpacto = entInf.ListImpacto;
                    vmInf.tbAfectacion = entInf.ListAfectacion;
                    vmInf.ddlZona = exeBusqueda.RegMostComboIndividual("ZONA_UTM", "");
                    vmInf.tbActIntAmbiental = entInf.ListISDetConservActIntAmbiental;
                    vmInf.tbActInvestigacion = entInf.ListISDetConservActInvestigacion;
                    vmInf.tbActVisitas = entInf.ListISDetConservActVisitas;
                    vmInf.tbActOtroPrograma = entInf.ListISDetConservActOtroPrograma;
                    vmInf.ddlBuenDesempenioId = entInf.BUEN_DESEMPENIO.ToString();
                    vmInf.ddlArchivaInformeId = (entInf.ARCHIVA_INFORME == -1) ? "Seleccionar" : entInf.ARCHIVA_INFORME.ToString();
                    vmInf.tbMandatos = entInf.ListMandatos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vmInf;
        }
        public ListResult GuardarDatosInformeConservacion(VM_Informe_Conservacion _dto, string asCodUCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                ValidarDatosInformeConservacion(_dto);

                CEntidad paramsInf = new CEntidad();
                paramsInf.COD_INFORME = _dto.hdfCodInforme ?? "";
                paramsInf.NUMERO = _dto.txtNumInforme;
                paramsInf.COD_CNOTIFICACION = _dto.vmInfCNotificacion.hdfCodCNotificacion;
                //paramsInf.COD_FISNOTI = _dto.vmInfCNotificacion.hdfCodCNotificacion;
                paramsInf.FECHA_ENTREGA = _dto.txtFechaEntrega;
                paramsInf.ListInformeDetSupervisor = _dto.tbSupervisor;
                paramsInf.FECHA_SUPERVISION_INICIO = _dto.vmDatoSupervision.txtFechaInicio;
                paramsInf.FECHA_SUPERVISION_FIN = _dto.vmDatoSupervision.txtFechaFin;
                paramsInf.THABILITANTE_SECTOR = _dto.txtSector;
                paramsInf.COD_UCUENTA = asCodUCuenta;
                paramsInf.RegEstado = _dto.hdfRegEstado;
                paramsInf.COD_OD_REGISTRO = _dto.ddlOdId;
                paramsInf.THABILITANTE_COD_UBIGEO = _dto.hdfCodUbigeo;
                paramsInf.COD_ESTADO_DOC = _dto.vmControlCalidad.ddlIndicadorId;
                paramsInf.COD_TIPO_SUPER = _dto.vmDatoSupervision.ddlTipoSupervisionId;
                paramsInf.OBSERVACIONES_CONTROL = _dto.vmControlCalidad.txtControlCalidadObservaciones;
                paramsInf.OBSERV_SUBSANAR = _dto.vmControlCalidad.chkObsSubsanada;
                paramsInf.OUTPUTPARAM01 = "";
                paramsInf.COD_TITULAR_EJECUTA = _dto.hdfCodTitularEjecutaPgmf;
                paramsInf.COD_REGENTE_IMPLEMENTA = _dto.hdfCodRegenteImplPgmf;
                paramsInf.GEOTEC_DRON = _dto.vmDatoSupervision.chkGeoTecDron;
                paramsInf.GEOTEC_GEOSUPERVISOR = _dto.vmDatoSupervision.chkGeoTecGeoSupervisor;
                paramsInf.GEOTEC_NINGUNO = _dto.vmDatoSupervision.chkGeoTecNinguno;
                paramsInf.GEOTEC_OTROS = _dto.vmDatoSupervision.chkGeoTecOtro;
                paramsInf.ListISDetConservActTuristica = _dto.tbActTuristica;
                paramsInf.ListISDetConservActIntAmbiental = _dto.tbActIntAmbiental;
                paramsInf.ListISDetConservActInvestigacion = _dto.tbActInvestigacion;
                paramsInf.ListISDetConservActVisitas = _dto.tbActVisitas;
                paramsInf.ListISDetConservActOtroPrograma = _dto.tbActOtroPrograma;
                if ((bool)paramsInf.GEOTEC_OTROS)
                {
                    paramsInf.GEOTEC_DESCRIPCION = _dto.vmDatoSupervision.txtGeoTecOtro;
                }
                paramsInf.COD_IMOTIVO = _dto.vmDatoSupervision.ddlMotivoSupervisionId;
                if (paramsInf.COD_IMOTIVO == "0000011")//Petición motivada
                {
                    paramsInf.MAE_TIP_MOTMOTIVADA = _dto.vmDatoSupervision.ddlTipoPeticionMotivadaId;
                    paramsInf.COD_TRAMITE_SITD = Convert.ToInt32(_dto.vmDatoSupervision.hdfCodDocDenunciaSITD ?? "0");
                }
                paramsInf.CUENTA_CROQUIS = _dto.ddlCuentaCroquisId == "SI" ? true : false;
                paramsInf.CUENTA_SENDERO_RUTA = _dto.ddlCuentaSenderoId == "SI" ? true : false;
                paramsInf.TIENE_VIAS = _dto.ddlSenalizacionSenderoId == "SI" ? true : false;
                paramsInf.ListVertice = _dto.tbCoordenadaUTM;
                paramsInf.ListPrograma = _dto.tbPrograma;
                paramsInf.ListISUPERVISION_INFRAESTRUCTURA = _dto.tbInfraestructura;
                paramsInf.ListISUPERVISION_DET_CAPACITACION_LOCAL = _dto.tbActividadPrograma;
                paramsInf.ListISUPERVISION_IDENTMANEJOIMPACTO = _dto.tbManejoImpacto;
                paramsInf.ListAvistamientoFauna = _dto.tbRegFauna;
                paramsInf.ListRegistroFlora = _dto.tbRegFlora;
                paramsInf.ListRegistroPaisaje = _dto.tbRegPaisaje;
                paramsInf.ListISUPERVISION_DET_ZONIFICACION = _dto.tbZonificacion;
                paramsInf.ListISUPERVISION_DET_EQUIPACONSECION = _dto.tbEquipamiento;
                paramsInf.ListISUPERVISION_OCARACTE_AMB01 = _dto.tbObligacion;
                paramsInf.ListEliTABLA = _dto.tbEliTABLA;
                paramsInf.ListObligacionTitular = _dto.tbObligTitular;
                paramsInf.ListDesplazamientoInforme = _dto.tbDesplazamiento;
                paramsInf.OBSERVACION = _dto.txtObservacion;
                paramsInf.CONCLUSION = _dto.txtConclusion;
                paramsInf.CONTENIDO = _dto.txtContenido;
                paramsInf.ASUNTO = _dto.txtAsunto;
                paramsInf.ListISDetConservActTuristica = _dto.tbActTuristica;
                paramsInf.ListImpacto = _dto.tbImpacto;
                paramsInf.ListAfectacion = _dto.tbAfectacion;
                paramsInf.ListEliTABLAImpacto = _dto.tbEliTABLAImpacto;
                paramsInf.COD_SUP_CALIDAD = _dto.hdSupervisor_Calidad;
                paramsInf.TIPO_INFORME = _dto.vmDatoSupervision.ddlTipoInformeId;
                paramsInf.ListMandatos = _dto.tbMandatos;
                //Grabar en la base de datos
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegIConservacionInsertar_v3(cn, paramsInf);
                }

                string msjRespuesta = _dto.hdfRegEstado == 1 ? "El Registro se Guardo Correctamente" : "El Registro se Modifico Correctamente";
                result.AddResultado(msjRespuesta, true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }
        private void ValidarDatosInformeConservacion(VM_Informe_Conservacion _dto)
        {
            if (_dto.vmControlCalidad.ddlIndicadorId == "0000000") throw new Exception("Seleccione el estado actual del registro");
            if (_dto.ddlOdId == "0000000") throw new Exception("Seleccione la oficina desconcentrada");

            if (string.IsNullOrEmpty(_dto.txtNumInforme)) throw new Exception("Ingrese el número del informe de supervisión");
            if (string.IsNullOrEmpty(_dto.vmDatoSupervision.txtFechaInicio)) throw new Exception("Seleccione la fecha de inicio de la supervisión");
            if (string.IsNullOrEmpty(_dto.vmDatoSupervision.txtFechaFin)) throw new Exception("Seleccione la fecha de término de la supervisión");
            if (string.IsNullOrEmpty(_dto.vmInfCNotificacion.hdfCodCNotificacion)) throw new Exception("No se encuentra la Carta de Notificación asociada");
        }

        public VM_Informe_Fauna InitDatosInformeFauna(string asCodInforme, string asCodCNotificacion)
        {
            VM_Informe_Fauna vmInf = new VM_Informe_Fauna();
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();

            try
            {
                vmInf.lblTituloCabecera = "Informe de Supervisión";
                vmInf.ddlOd = exeBus.RegMostComboIndividual("OD", "");
                vmInf.vmDatoSupervision.ddlTipoSupervision = exeBus.RegMostComboIndividual("TIPO_SUPERVISION", "");
                vmInf.vmDatoSupervision.ddlMotivoSupervision = exeBus.RegMostComboIndividual("MOTIVO_SUPERVISION", "");
                vmInf.vmDatoSupervision.ddlTipoPeticionMotivada = exeBus.RegMostComboIndividual("TIPO_PETICION_MOTIVADA", "");

                vmInf.vmDatoSupervision.ddlTipoInforme = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "0000000", Text = "Seleccionar" },
                    new VM_Cbo { Value = "GABINETE", Text = "GABINETE" },
                    new VM_Cbo { Value = "CAMPO", Text = "CAMPO" }
                };

                vmInf.ddlBuenDesempenio = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "Seleccionar", Text = "Seleccionar" },
                    new VM_Cbo { Value = "1", Text = "SI" },
                    new VM_Cbo { Value = "0", Text = "NO" }
                };

                vmInf.ddlArchivaInforme = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "Seleccionar", Text = "Seleccionar" },
                    new VM_Cbo { Value = "1", Text = "SI" },
                    new VM_Cbo { Value = "0", Text = "NO" }
                };

                if (String.IsNullOrEmpty(asCodInforme))
                {
                    CapaEntidad.DOC.Ent_CNOTIFICACION entCN = new CapaEntidad.DOC.Ent_CNOTIFICACION();
                    Log_CNOTIFICACION exeCN = new Log_CNOTIFICACION();
                    entCN = exeCN.RegMostCNotificacion_Consulta(
                        new CapaEntidad.DOC.Ent_CNOTIFICACION()
                        {
                            BusFormulario = "DATA_CNOTIFICACION",
                            BusCriterio = "CN_CODCN_ISUPERVISION",
                            BusValor = asCodCNotificacion
                        }).FirstOrDefault();

                    vmInf.lblTituloEstado = "Nuevo Registro";
                    vmInf.vmInfCNotificacion.hdfCodCNotificacion = entCN.COD_CNOTIFICACION;
                    vmInf.vmInfCNotificacion.txtCNotificacion = entCN.NUMERO;
                    /*CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA entCN = new CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA();
                    Log_NOTIFICACION exeCN = new Log_NOTIFICACION();
                    entCN = exeCN.RegListarNotificacionConsulta_v3(
                        new CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA()
                        {
                            BusFormulario = "MODAL_NOTIFICACION",
                            BusCriterio = "FN_CODIGO",
                            BusValor = asCodNotificacion
                        }).FirstOrDefault();

                    vmInf.lblTituloEstado = "Nuevo Registro";
                    vmInf.vmInfCNotificacion.hdfCodCNotificacion = entCN.COD_FISNOTI;
                    vmInf.vmInfCNotificacion.txtCNotificacion = entCN.NUM_NOTIFICACION;*/
                    vmInf.vmInfCNotificacion.txtTHabilitante = entCN.NUM_THABILITANTE;
                    vmInf.hdfRegEstado = 1;

                    CEntidad entInfPoa = new CEntidad();
                    entInfPoa.BusFormulario = "INFORME_SUPERVISION";
                    entInfPoa.BusCriterio = "LISTA_POAS";
                    entInfPoa.TIPO = "CN";
                    entInfPoa.BusValor = "'" + asCodCNotificacion + "'";
                    /*entInfPoa.TIPO = "FN";
                    entInfPoa.BusValor = "'" + asCodNotificacion + "'";*/
                    vmInf.vmInfCNotificacion.tbPoa = RegMostListPOAs(entInfPoa).ListPOAs;
                    foreach (var itemPoa in vmInf.vmInfCNotificacion.tbPoa)
                    {
                        itemPoa.RegEstado = 1;
                    }
                    var lstPrograma = exeBus.RegMostComboIndividual("FAUNA_PROGRAMA", "");
                    foreach (var item in lstPrograma)
                    {
                        vmInf.tbPrograma.Add(new CapaEntidad.DOC.Ent_INFORME_PROGRAMA()
                        {
                            COD_PROGRAMA = Convert.ToInt32(item.Value.Split('|')[0]),
                            TIPO_PROGRAMA = item.Value.Split('|')[1],
                            DESCRIPCION = item.Text,
                            TIPO = "",
                            ESTADO_PROGRAMA = false,
                            OBSERVACION = "",
                            FRECUENCIA = ""
                        });
                    }
                }
                else
                {
                    //Obtener datos del informe
                    CEntidad entInf;
                    using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                    {
                        cn.Open();
                        entInf = oCDatos.RegIFaunaMostrarListaItem_v3(cn, asCodInforme);
                    }

                    vmInf.lblTituloEstado = "Modificando Registro";
                    vmInf.vmControlCalidad.ddlIndicadorId = entInf.COD_ESTADO_DOC;
                    vmInf.vmControlCalidad.chkObsSubsanada = (bool)entInf.OBSERV_SUBSANAR;
                    vmInf.vmControlCalidad.txtControlCalidadObservaciones = entInf.OBSERVACIONES_CONTROL.ToString();
                    vmInf.vmControlCalidad.txtUsuarioControl = entInf.USUARIO_CONTROL;
                    vmInf.vmControlCalidad.txtUsuarioRegistro = entInf.USUARIO_REGISTRO;

                    vmInf.hdfCodInforme = asCodInforme;
                    vmInf.hdfRegEstado = 0;
                    vmInf.chkPublicar = (bool)entInf.PUBLICAR;

                    CEntidad entGenInf = RegMostrarDatosCabecera(asCodInforme);
                    vmInf.vmInfCNotificacion.hdfCodCNotificacion = entGenInf.COD_CNOTIFICACION;
                    vmInf.vmInfCNotificacion.txtCNotificacion = entGenInf.NUM_CNOTIFICACION;
                    /*CEntidad entGenInf = oCDatos.RegMostrarDatosCabecera_v3(asCodInforme);
                    vmInf.vmInfCNotificacion.hdfCodCNotificacion = entGenInf.COD_FISNOTI;
                    vmInf.vmInfCNotificacion.txtCNotificacion = entGenInf.NUM_NOTIFICACION;*/
                    vmInf.vmInfCNotificacion.txtTHabilitante = entGenInf.NUM_THABILITANTE;
                    vmInf.vmInfCNotificacion.tbCNotificacion = entInf.ListCNotificaciones;
                    vmInf.vmInfCNotificacion.tbPoa = entInf.ListPOAs;

                    vmInf.ddlOdId = entInf.COD_OD_REGISTRO;
                    vmInf.txtNumInforme = entInf.NUMERO;
                    vmInf.txtFechaEntrega = entInf.FECHA_ENTREGA.ToString();
                    vmInf.hdfCodDirector = entInf.COD_DIRECTOR;
                    vmInf.txtDirector = entInf.NOMBRE_DIRECTOR;
                    vmInf.tbSupervisor = entInf.ListInformeDetSupervisor;
                    vmInf.txtAsunto = entInf.ASUNTO;
                    vmInf.txtContenido = entInf.CONTENIDO.ToString();
                    vmInf.ddlRealizadoVeedorId = (bool)entInf.REALIZADO_VEEDORFORESTAL ? "SI" : "NO";
                    vmInf.hdfCodResponsable = entInf.COD_TECNICO;
                    vmInf.txtResponsable = entInf.NOMBRE_TECNICO;
                    vmInf.hdfCodTitularEjecutaPgmf = entInf.COD_TITULAR_EJECUTA;
                    vmInf.txtTitularEjecutaPgmf = entInf.TITULAR_EJECUTA;
                    vmInf.hdfCodRegenteImplPgmf = entInf.COD_REGENTE_IMPLEMENTA;
                    vmInf.txtRegenteImplPgmf = entInf.REGENTE_IMPLEMENTA;
                    vmInf.hdfCodUbigeo = entInf.THABILITANTE_COD_UBIGEO;
                    vmInf.txtUbigeo = entInf.UBIGEO;
                    vmInf.txtSector = entInf.THABILITANTE_SECTOR;
                    vmInf.txtObservacion = entInf.OBSERVACION;
                    vmInf.txtConclusion = entInf.CONCLUSION;

                    vmInf.vmDatoSupervision.txtFechaInicio = entInf.FECHA_SUPERVISION_INICIO.ToString();
                    vmInf.vmDatoSupervision.txtFechaFin = entInf.FECHA_SUPERVISION_FIN.ToString();
                    vmInf.vmDatoSupervision.ddlMotivoSupervisionId = entInf.COD_IMOTIVO;
                    vmInf.vmDatoSupervision.ddlTipoSupervisionId = entInf.COD_TIPO_SUPER;
                    vmInf.vmDatoSupervision.ddlTipoInformeId = entInf.TIPO_INFORME;
                    vmInf.vmDatoSupervision.txtMotivoSupervision = entInf.IMOTIVO;
                    vmInf.vmDatoSupervision.ddlTipoPeticionMotivadaId = entInf.MAE_TIP_MOTMOTIVADA;
                    vmInf.vmDatoSupervision.hdfCodDocDenunciaSITD = entInf.COD_TRAMITE_SITD.ToString();
                    vmInf.vmDatoSupervision.txtDocDenunciaSITD = entInf.NUM_DREFERENCIA;
                    vmInf.vmDatoSupervision.chkGeoTecDron = (bool)entInf.GEOTEC_DRON;
                    vmInf.vmDatoSupervision.chkGeoTecGeoSupervisor = (bool)entInf.GEOTEC_GEOSUPERVISOR;
                    vmInf.vmDatoSupervision.chkGeoTecOtro = (bool)entInf.GEOTEC_OTROS;
                    vmInf.vmDatoSupervision.chkGeoTecNinguno = (bool)entInf.GEOTEC_NINGUNO;
                    vmInf.vmDatoSupervision.txtGeoTecOtro = entInf.GEOTEC_DESCRIPCION;

                    vmInf.tbFotoSupervision = entInf.ListFotos;
                    vmInf.tbPrograma = entInf.ListPrograma;
                    vmInf.tbManejoImpacto = entInf.ListISUPERVISION_IDENTMANEJOIMPACTO;
                    vmInf.tbResponsabilidadSocial = entInf.ListISUPERVISION_DET_CAPACITACION_ACTDES;
                    vmInf.tbObligacionContrac = entInf.ListOCActosTercero;
                    vmInf.tbDesplazamiento = entInf.ListDesplazamientoInforme;
                    vmInf.ddlBuenDesempenioId = entInf.BUEN_DESEMPENIO.ToString();
                    vmInf.ddlArchivaInformeId = (entInf.ARCHIVA_INFORME == -1) ? "Seleccionar" : entInf.ARCHIVA_INFORME.ToString();
                    vmInf.tbMandatos = entInf.ListMandatos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vmInf;
        }
        public ListResult GuardarDatosInformeFauna(VM_Informe_Fauna _dto, string asCodUCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                ValidarDatosInformeFauna(_dto);

                CEntidad paramsInf = new CEntidad();
                paramsInf.COD_ESTADO_DOC = _dto.vmControlCalidad.ddlIndicadorId;
                paramsInf.OBSERVACIONES_CONTROL = _dto.vmControlCalidad.txtControlCalidadObservaciones;
                paramsInf.OBSERV_SUBSANAR = _dto.vmControlCalidad.chkObsSubsanada;
                paramsInf.COD_TIPO_SUPER = _dto.vmDatoSupervision.ddlTipoSupervisionId;
                paramsInf.PUBLICAR = _dto.chkPublicar;
                paramsInf.COD_CNOTIFICACION = _dto.vmInfCNotificacion.hdfCodCNotificacion;
                //paramsInf.COD_FISNOTI = _dto.vmInfCNotificacion.hdfCodCNotificacion;
                paramsInf.ListCNotificaciones = _dto.vmInfCNotificacion.tbCNotificacion;
                paramsInf.ListPOAs = _dto.vmInfCNotificacion.tbPoa;

                paramsInf.COD_INFORME = _dto.hdfCodInforme ?? "";
                paramsInf.COD_OD_REGISTRO = _dto.ddlOdId;
                paramsInf.NUMERO = _dto.txtNumInforme;
                paramsInf.FECHA_ENTREGA = _dto.txtFechaEntrega;
                paramsInf.COD_DIRECTOR = _dto.hdfCodDirector;
                paramsInf.ListInformeDetSupervisor = _dto.tbSupervisor;
                paramsInf.ASUNTO = _dto.txtAsunto;
                paramsInf.CONTENIDO = _dto.txtContenido;

                paramsInf.FECHA_SUPERVISION_INICIO = _dto.vmDatoSupervision.txtFechaInicio;
                paramsInf.FECHA_SUPERVISION_FIN = _dto.vmDatoSupervision.txtFechaFin;
                paramsInf.COD_IMOTIVO = _dto.vmDatoSupervision.ddlMotivoSupervisionId;
                if (paramsInf.COD_IMOTIVO == "0000011")//Petición motivada
                {
                    paramsInf.MAE_TIP_MOTMOTIVADA = _dto.vmDatoSupervision.ddlTipoPeticionMotivadaId;
                    paramsInf.COD_TRAMITE_SITD = Convert.ToInt32(_dto.vmDatoSupervision.hdfCodDocDenunciaSITD ?? "0");
                }
                paramsInf.GEOTEC_DRON = _dto.vmDatoSupervision.chkGeoTecDron;
                paramsInf.GEOTEC_GEOSUPERVISOR = _dto.vmDatoSupervision.chkGeoTecGeoSupervisor;
                paramsInf.GEOTEC_NINGUNO = _dto.vmDatoSupervision.chkGeoTecNinguno;
                paramsInf.GEOTEC_OTROS = _dto.vmDatoSupervision.chkGeoTecOtro;
                if ((bool)paramsInf.GEOTEC_OTROS)
                {
                    paramsInf.GEOTEC_DESCRIPCION = _dto.vmDatoSupervision.txtGeoTecOtro;
                }
                paramsInf.COD_TECNICO = _dto.hdfCodResponsable;
                paramsInf.REALIZADO_VEEDORFORESTAL = _dto.ddlRealizadoVeedorId == "SI" ? true : false;
                paramsInf.COD_TITULAR_EJECUTA = _dto.hdfCodTitularEjecutaPgmf;
                paramsInf.COD_REGENTE_IMPLEMENTA = _dto.hdfCodRegenteImplPgmf;
                paramsInf.THABILITANTE_COD_UBIGEO = _dto.hdfCodUbigeo;
                paramsInf.THABILITANTE_SECTOR = _dto.txtSector;
                paramsInf.OBSERVACION = _dto.txtObservacion ?? "";
                paramsInf.CONCLUSION = _dto.txtConclusion ?? "";

                paramsInf.ListPrograma = _dto.tbPrograma;
                paramsInf.ListISUPERVISION_IDENTMANEJOIMPACTO = _dto.tbManejoImpacto;
                paramsInf.ListISUPERVISION_DET_CAPACITACION_ACTDES = _dto.tbResponsabilidadSocial;
                paramsInf.ListOCActosTercero = _dto.tbObligacionContrac;
                paramsInf.ListEliTABLA = _dto.tbEliTABLA;
                paramsInf.ListDesplazamientoInforme = _dto.tbDesplazamiento;

                paramsInf.COD_UCUENTA = asCodUCuenta;
                paramsInf.RegEstado = _dto.hdfRegEstado;
                paramsInf.OUTPUTPARAM01 = "";
                paramsInf.COD_SUP_CALIDAD = _dto.hdSupervisor_Calidad;
                paramsInf.TIPO_INFORME = _dto.ddlTipoInformeId; 
                paramsInf.ListMandatos = _dto.tbMandatos; 
                //Grabar en la base de datos
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegIFaunaInsertar_v3(cn, paramsInf);
                }

                string msjRespuesta = _dto.hdfRegEstado == 1 ? "El Registro se Guardo Correctamente" : "El Registro se Modifico Correctamente";
                result.AddResultado(msjRespuesta, true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }
        public void ValidarDatosInformeFauna(VM_Informe_Fauna _dto)
        {
            if (_dto.vmControlCalidad.ddlIndicadorId == "0000000") throw new Exception("Seleccione el estado actual del registro");
            if (_dto.ddlOdId == "0000000") throw new Exception("Seleccione la oficina desconcentrada");

            if (string.IsNullOrEmpty(_dto.txtNumInforme)) throw new Exception("Ingrese el número del informe de supervisión");
            if (string.IsNullOrEmpty(_dto.vmDatoSupervision.txtFechaInicio)) throw new Exception("Seleccione la fecha de inicio de la supervisión");
            if (string.IsNullOrEmpty(_dto.vmDatoSupervision.txtFechaFin)) throw new Exception("Seleccione la fecha de término de la supervisión");
            if (string.IsNullOrEmpty(_dto.hdfCodUbigeo)) throw new Exception("Seleccione el ubigeo del área supervisada");
            if (string.IsNullOrEmpty(_dto.txtSector)) throw new Exception("Ingrese el sector del área supervisada");
            if (string.IsNullOrEmpty(_dto.vmInfCNotificacion.hdfCodCNotificacion)) throw new Exception("No se encuentra la Carta de Notificación asociada");
        }

        public VM_Informe_POAFaunaSupervisado InitDatosPOAFaunaSupervisado(string asCodInforme, Int32 aiNumPoa)
        {
            VM_Informe_POAFaunaSupervisado vm = new VM_Informe_POAFaunaSupervisado();
            try
            {
                CEntidad oCampo = oCDatos.RegMostrarPOAFaunaSupervisado(new CEntidad() { COD_INFORME = asCodInforme, NUM_POA = aiNumPoa });
                if (oCampo.NUM_POA != -1) //Registro existente
                {
                    Log_BUSQUEDA exeBus = new Log_BUSQUEDA();

                    vm.lblTituloEstado = "Registro de Datos " + oCampo.POA;
                    vm.hdfCodInforme = oCampo.COD_INFORME;
                    vm.hdfNumPoa = oCampo.NUM_POA;

                    vm.tbAvistamientoFauna = oCampo.ListAvistamientoFauna;
                    vm.tbAprovSostenible = oCampo.ListISupervFaunaAprov;
                    vm.tbCoordenadaUTM = oCampo.ListVertice;
                    vm.tbInfraestructuraImpl = oCampo.ListISUPERVISION_INFRAESTRUCTURA;
                    vm.tbZonificacion = oCampo.ListISUPERVISION_DET_ZONIFICACION;
                }
                else
                {
                    throw new Exception("No se encontró el plan de manejo");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vm;
        }
        public ListResult GuardarDatosPOAFaunaSupervisado(VM_Informe_POAFaunaSupervisado _dto, string asCodUCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                CEntidad oParams = new CEntidad();
                oParams.COD_INFORME = _dto.hdfCodInforme;
                oParams.NUM_POA = _dto.hdfNumPoa;

                oParams.ListAvistamientoFauna = _dto.tbAvistamientoFauna;
                oParams.ListISupervFaunaAprov = _dto.tbAprovSostenible;
                oParams.ListVertice = _dto.tbCoordenadaUTM;
                oParams.ListISUPERVISION_INFRAESTRUCTURA = _dto.tbInfraestructuraImpl;
                oParams.ListISUPERVISION_DET_ZONIFICACION = _dto.tbZonificacion;
                oParams.ListEliTABLA = _dto.tbEliTABLA;

                oParams.COD_UCUENTA = asCodUCuenta;
                oParams.OUTPUTPARAM01 = "";

                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegInsertarPOAFaunaSupervisado(cn, oParams);
                }

                result.AddResultado("Los datos del plan de manejo se guardaron correctamente", true);
            }
            catch (Exception ex)
            {
                result.success = false; result.msj = ex.Message;
            }
            return result;
        }

        public VM_Informe_Tara InitDatosInformeTara(string asCodInforme, string asCodCNotificacion)
        {
            VM_Informe_Tara vmInf = new VM_Informe_Tara();
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();

            try
            {
                vmInf.lblTituloCabecera = "Informe de Supervisión";
                vmInf.ddlOd = exeBus.RegMostComboIndividual("OD", "");
                vmInf.vmDatoSupervision.ddlTipoSupervision = exeBus.RegMostComboIndividual("TIPO_SUPERVISION", "");
                vmInf.vmDatoSupervision.ddlMotivoSupervision = exeBus.RegMostComboIndividual("MOTIVO_SUPERVISION", "");
                vmInf.vmDatoSupervision.ddlTipoPeticionMotivada = exeBus.RegMostComboIndividual("TIPO_PETICION_MOTIVADA", "");
                vmInf.ddlPlanton = exeBus.RegMostComboIndividual("PRODUCCION_PLANTON", "");

                vmInf.vmDatoSupervision.ddlTipoInforme = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "0000000", Text = "Seleccionar" },
                    new VM_Cbo { Value = "GABINETE", Text = "GABINETE" },
                    new VM_Cbo { Value = "CAMPO", Text = "CAMPO" }
                };

                vmInf.ddlBuenDesempenio = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "Seleccionar", Text = "Seleccionar" },
                    new VM_Cbo { Value = "1", Text = "SI" },
                    new VM_Cbo { Value = "0", Text = "NO" }
                };

                vmInf.ddlArchivaInforme = new List<VM_Cbo>
                {
                    new VM_Cbo { Value = "Seleccionar", Text = "Seleccionar" },
                    new VM_Cbo { Value = "1", Text = "SI" },
                    new VM_Cbo { Value = "0", Text = "NO" }
                };

                if (String.IsNullOrEmpty(asCodInforme))
                {
                    CapaEntidad.DOC.Ent_CNOTIFICACION entCN = new CapaEntidad.DOC.Ent_CNOTIFICACION();
                    Log_CNOTIFICACION exeCN = new Log_CNOTIFICACION();
                    entCN = exeCN.RegMostCNotificacion_Consulta(
                        new CapaEntidad.DOC.Ent_CNOTIFICACION()
                        {
                            BusFormulario = "DATA_CNOTIFICACION",
                            BusCriterio = "CN_CODCN_ISUPERVISION",
                            BusValor = asCodCNotificacion
                        }).FirstOrDefault();

                    vmInf.lblTituloEstado = "Nuevo Registro";
                    vmInf.vmInfCNotificacion.hdfCodCNotificacion = entCN.COD_CNOTIFICACION;
                    vmInf.vmInfCNotificacion.txtCNotificacion = entCN.NUMERO;
                    /*CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA entCN = new CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA();
                    Log_NOTIFICACION exeCN = new Log_NOTIFICACION();
                    entCN = exeCN.RegListarNotificacionConsulta_v3(
                        new CapaEntidad.DOC.Ent_NOTIFICACION_CONSULTA()
                        {
                            BusFormulario = "MODAL_NOTIFICACION",
                            BusCriterio = "FN_CODIGO",
                            BusValor = asCodNotificacion
                        }).FirstOrDefault();

                    vmInf.lblTituloEstado = "Nuevo Registro";
                    vmInf.vmInfCNotificacion.hdfCodCNotificacion = entCN.COD_FISNOTI;
                    vmInf.vmInfCNotificacion.txtCNotificacion = entCN.NUM_NOTIFICACION;*/
                    vmInf.vmInfCNotificacion.txtTHabilitante = entCN.NUM_THABILITANTE;
                    vmInf.hdfRegEstado = 1;

                    //Cargar las obligaciones del titular del TH
                    var lstObligTitular = exeBus.RegMostComboIndividual("OBLIGACION_TITULAR", "OBLIGTITU_NOMADE");
                    foreach (var item in lstObligTitular)
                    {
                        vmInf.tbObligTitular.Add(new CapaEntidad.DOC.Ent_INFORME_OBLIGTITULAR()
                        {
                            COD_OBLIGTITULAR = item.Value,
                            OBLIGTITULAR = item.Text,
                            EVAL_OBLIGTITULAR = "",
                            OBSERVACION = ""
                        });
                    }
                }
                else
                {
                    //Obtener datos del informe
                    CEntidad entInf;
                    using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                    {
                        cn.Open();
                        entInf = oCDatos.RegITaraMostrarListaItem_v3(cn, asCodInforme);
                    }

                    vmInf.lblTituloEstado = "Modificando Registro";
                    vmInf.vmControlCalidad.ddlIndicadorId = entInf.COD_ESTADO_DOC;
                    vmInf.vmControlCalidad.chkObsSubsanada = (bool)entInf.OBSERV_SUBSANAR;
                    vmInf.vmControlCalidad.txtControlCalidadObservaciones = entInf.OBSERVACIONES_CONTROL.ToString();
                    vmInf.vmControlCalidad.txtUsuarioControl = entInf.USUARIO_CONTROL;
                    vmInf.vmControlCalidad.txtUsuarioRegistro = entInf.USUARIO_REGISTRO;

                    vmInf.hdfCodInforme = asCodInforme;
                    vmInf.hdfRegEstado = 0;

                    CEntidad entGenInf = RegMostrarDatosCabecera(asCodInforme);
                    vmInf.vmInfCNotificacion.hdfCodCNotificacion = entGenInf.COD_CNOTIFICACION;
                    vmInf.vmInfCNotificacion.txtCNotificacion = entGenInf.NUM_CNOTIFICACION;
                    /*CEntidad entGenInf = oCDatos.RegMostrarDatosCabecera_v3(asCodInforme);
                    vmInf.vmInfCNotificacion.hdfCodCNotificacion = entGenInf.COD_FISNOTI;
                    vmInf.vmInfCNotificacion.txtCNotificacion = entGenInf.NUM_NOTIFICACION;*/
                    vmInf.vmInfCNotificacion.txtTHabilitante = entGenInf.NUM_THABILITANTE;

                    vmInf.ddlOdId = entInf.COD_OD_REGISTRO;
                    vmInf.txtNumInforme = entInf.NUMERO;
                    vmInf.txtFechaEntrega = entInf.FECHA_ENTREGA.ToString();
                    vmInf.hdfCodDirector = entInf.COD_DIRECTOR;
                    vmInf.txtDirector = entInf.NOMBRE_DIRECTOR;
                    vmInf.txtFechaEmision = entInf.FECHA_EMISION.ToString();
                    vmInf.tbSupervisor = entInf.ListInformeDetSupervisor;

                    vmInf.vmDatoSupervision.txtFechaInicio = entInf.FECHA_SUPERVISION_INICIO.ToString();
                    vmInf.vmDatoSupervision.txtFechaFin = entInf.FECHA_SUPERVISION_FIN.ToString();
                    vmInf.vmDatoSupervision.ddlMotivoSupervisionId = entInf.COD_IMOTIVO;
                    vmInf.vmDatoSupervision.txtMotivoSupervision = entInf.IMOTIVO;
                    vmInf.vmDatoSupervision.ddlTipoSupervisionId = entInf.COD_TIPO_SUPER;
                    vmInf.vmDatoSupervision.ddlTipoInformeId = entInf.TIPO_INFORME;
                    vmInf.vmDatoSupervision.ddlTipoPeticionMotivadaId = entInf.MAE_TIP_MOTMOTIVADA;
                    vmInf.vmDatoSupervision.hdfCodDocDenunciaSITD = entInf.COD_TRAMITE_SITD.ToString();
                    vmInf.vmDatoSupervision.txtDocDenunciaSITD = entInf.NUM_DREFERENCIA;
                    vmInf.vmDatoSupervision.chkGeoTecDron = (bool)entInf.GEOTEC_DRON;
                    vmInf.vmDatoSupervision.chkGeoTecGeoSupervisor = (bool)entInf.GEOTEC_GEOSUPERVISOR;
                    vmInf.vmDatoSupervision.chkGeoTecNinguno = (bool)entInf.GEOTEC_NINGUNO;
                    vmInf.vmDatoSupervision.chkGeoTecOtro = (bool)entInf.GEOTEC_OTROS;
                    vmInf.vmDatoSupervision.txtGeoTecOtro = entInf.GEOTEC_DESCRIPCION;

                    vmInf.hdfCodUbigeo = entInf.THABILITANTE_COD_UBIGEO;
                    vmInf.txtUbigeo = entInf.UBIGEO;
                    vmInf.txtSector = entInf.THABILITANTE_SECTOR;

                    vmInf.chkLineamientoMapa = (bool)entInf.ESTADO_MAPAS_CINFORMACION;
                    vmInf.txtLineamientoMapa = entInf.MAPAS_CINFORMACION;
                    vmInf.txtAreaManejo = entInf.ESTAB_AREA_MANEJO;
                    vmInf.txtPlantacion = entInf.ESTAB_PLANTACION;
                    vmInf.chkForestacion = (bool)entInf.EXISTEN_FOREST_REFOREST;
                    vmInf.txtForestacion = entInf.OBSERV_FOREST_REFOREST;
                    vmInf.ddlPlantonId = entInf.COD_PPLANTON.ToString();
                    vmInf.txtPlanton = entInf.OBSERV_PROD_PLANTONES;
                    vmInf.txtComercializacion = entInf.COMERCIALIZACION;
                    vmInf.txtRevAcervo = entInf.ANALISIS_RACERVO;
                    vmInf.tbTaraConcepto = entInf.ListTaraConcepto;
                    vmInf.tbManPlantacion = entInf.ListTaraManPlantacion;
                    vmInf.tbAprovechamiento = entInf.ListISUPERVISION_DET_TARA_APROV;
                    vmInf.tbCapacitacion = entInf.ListISUPERVISION_DET_TARA_CAPACITACION;
                    vmInf.tbProduccionFruto = entInf.ListISUPERVISION_DET_TARA_PFRUTOS;
                    vmInf.tbAprovechaForestal = entInf.ListISUPERVISION_DET_TARA_APFORESTAL;
                    vmInf.tbCenso = entInf.ListTaraCenso;
                    vmInf.tbKardex = entInf.ListISUPERVISION_DET_TARA_KARDEX;
                    vmInf.tbObligTitular = entInf.ListObligacionTitular.Where(m => m.COD_GRUPO == "OBLIGTITU_NOMADE").ToList();
                    vmInf.tbDesplazamiento = entInf.ListDesplazamientoInforme;
                    //Adicionales 08/08/2019 CLHC
                    vmInf.txtObservacion = entInf.OBSERVACION;
                    vmInf.txtConclusion = entInf.CONCLUSION;
                    vmInf.ddlBuenDesempenioId = entInf.BUEN_DESEMPENIO.ToString();
                    vmInf.ddlArchivaInformeId = (entInf.ARCHIVA_INFORME == -1) ? "Seleccionar" : entInf.ARCHIVA_INFORME.ToString();
                    vmInf.tbMandatos = entInf.ListMandatos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vmInf;
        }
        public ListResult GuardarDatosInformeTara(VM_Informe_Tara _dto, string asCodUCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                ValidarDatosInformeTara(_dto);

                CEntidad paramsInf = new CEntidad();
                paramsInf.COD_ESTADO_DOC = _dto.vmControlCalidad.ddlIndicadorId;
                paramsInf.OBSERVACIONES_CONTROL = _dto.vmControlCalidad.txtControlCalidadObservaciones;
                paramsInf.OBSERV_SUBSANAR = _dto.vmControlCalidad.chkObsSubsanada;
                paramsInf.COD_CNOTIFICACION = _dto.vmInfCNotificacion.hdfCodCNotificacion;
                //paramsInf.COD_FISNOTI = _dto.vmInfCNotificacion.hdfCodCNotificacion;
                paramsInf.COD_OD_REGISTRO = _dto.ddlOdId;
                paramsInf.COD_INFORME = _dto.hdfCodInforme ?? "";
                paramsInf.NUMERO = _dto.txtNumInforme;
                paramsInf.FECHA_ENTREGA = _dto.txtFechaEntrega;
                paramsInf.COD_DIRECTOR = _dto.hdfCodDirector;
                paramsInf.FECHA_EMISION = _dto.txtFechaEmision;
                paramsInf.ListInformeDetSupervisor = _dto.tbSupervisor;
                paramsInf.FECHA_SUPERVISION_INICIO = _dto.vmDatoSupervision.txtFechaInicio;
                paramsInf.FECHA_SUPERVISION_FIN = _dto.vmDatoSupervision.txtFechaFin;
                paramsInf.COD_IMOTIVO = _dto.vmDatoSupervision.ddlMotivoSupervisionId;
                paramsInf.COD_TIPO_SUPER = _dto.vmDatoSupervision.ddlTipoSupervisionId;
                if (paramsInf.COD_IMOTIVO == "0000011")//Petición motivada
                {
                    paramsInf.MAE_TIP_MOTMOTIVADA = _dto.vmDatoSupervision.ddlTipoPeticionMotivadaId;
                    paramsInf.COD_TRAMITE_SITD = Convert.ToInt32(_dto.vmDatoSupervision.hdfCodDocDenunciaSITD ?? "0");
                }
                paramsInf.GEOTEC_DRON = _dto.vmDatoSupervision.chkGeoTecDron;
                paramsInf.GEOTEC_GEOSUPERVISOR = _dto.vmDatoSupervision.chkGeoTecGeoSupervisor;
                paramsInf.GEOTEC_NINGUNO = _dto.vmDatoSupervision.chkGeoTecNinguno;
                paramsInf.GEOTEC_OTROS = _dto.vmDatoSupervision.chkGeoTecOtro;
                if ((bool)paramsInf.GEOTEC_OTROS)
                {
                    paramsInf.GEOTEC_DESCRIPCION = _dto.vmDatoSupervision.txtGeoTecOtro;
                }
                paramsInf.THABILITANTE_COD_UBIGEO = _dto.hdfCodUbigeo;
                paramsInf.THABILITANTE_SECTOR = _dto.txtSector;

                paramsInf.ESTADO_MAPAS_CINFORMACION = _dto.chkLineamientoMapa;
                paramsInf.MAPAS_CINFORMACION = _dto.txtLineamientoMapa;
                paramsInf.ESTAB_AREA_MANEJO = _dto.txtAreaManejo;
                paramsInf.ESTAB_PLANTACION = _dto.txtPlantacion;
                paramsInf.EXISTEN_FOREST_REFOREST = _dto.chkForestacion;
                paramsInf.OBSERV_FOREST_REFOREST = _dto.txtForestacion;
                paramsInf.COD_PPLANTON = Convert.ToInt32(_dto.ddlPlantonId);
                paramsInf.OBSERV_PROD_PLANTONES = _dto.txtPlanton;
                paramsInf.COMERCIALIZACION = _dto.txtComercializacion;
                paramsInf.ANALISIS_RACERVO = _dto.txtRevAcervo;
                paramsInf.ListTaraConcepto = _dto.tbTaraConcepto;
                paramsInf.ListISUPERVISION_DET_TARA_APROV = _dto.tbAprovechamiento;
                paramsInf.ListISUPERVISION_DET_TARA_CAPACITACION = _dto.tbCapacitacion;
                paramsInf.ListISUPERVISION_DET_TARA_PFRUTOS = _dto.tbProduccionFruto;
                paramsInf.ListISUPERVISION_DET_TARA_APFORESTAL = _dto.tbAprovechaForestal;
                paramsInf.ListTaraCenso = _dto.tbCenso;
                paramsInf.ListISUPERVISION_DET_TARA_KARDEX = _dto.tbKardex;
                paramsInf.ListEliTABLA = _dto.tbEliTABLA;
                paramsInf.ListObligacionTitular = _dto.tbObligTitular;
                paramsInf.ListDesplazamientoInforme = _dto.tbDesplazamiento;
                paramsInf.ListMandatos = _dto.tbMandatos;

                paramsInf.COD_UCUENTA = asCodUCuenta;
                paramsInf.RegEstado = _dto.hdfRegEstado;
                paramsInf.OUTPUTPARAM01 = "";
                //Valores por defecto
                paramsInf.COD_ITIPO = "0000001";
                paramsInf.ESTADO_ORIGEN = "TH";
                //Actualizado 08/08/2019 CLHC
                paramsInf.OBSERVACION = _dto.txtObservacion;
                paramsInf.CONCLUSION = _dto.txtConclusion;
                paramsInf.COD_SUP_CALIDAD= _dto.hdSupervisor_Calidad;
                //Grabar en la base de datos
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegITaraInsertar_v3(cn, paramsInf);
                }

                string msjRespuesta = _dto.hdfRegEstado == 1 ? "El Registro se Guardo Correctamente" : "El Registro se Modifico Correctamente";
                result.AddResultado(msjRespuesta, true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }
        public void ValidarDatosInformeTara(VM_Informe_Tara _dto)
        {
            if (_dto.vmControlCalidad.ddlIndicadorId == "0000000") throw new Exception("Seleccione el estado actual del registro");
            if (_dto.ddlOdId == "0000000") throw new Exception("Seleccione la oficina desconcentrada");

            if (string.IsNullOrEmpty(_dto.txtNumInforme)) throw new Exception("Ingrese el número del informe de supervisión");
            if (string.IsNullOrEmpty(_dto.vmDatoSupervision.txtFechaInicio)) throw new Exception("Seleccione la fecha de inicio de la supervisión");
            if (string.IsNullOrEmpty(_dto.vmDatoSupervision.txtFechaFin)) throw new Exception("Seleccione la fecha de término de la supervisión");
            if (string.IsNullOrEmpty(_dto.vmInfCNotificacion.hdfCodCNotificacion)) throw new Exception("No se encuentra la Carta de Notificación asociada");
        }

        public List<Dictionary<string, string>> ReportesInforme(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReportesInforme(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VM_FControlCalidadSupervision obtenerFControlCalidad(string COD_INFORME)
        {
            return oCDatos.obtenerFControlCalidad(COD_INFORME);
        }
        public ListResult registrarFControlCalidad(VM_FControlCalidadSupervision mv, string usuarioId)
        {
            ListResult result = new ListResult();
            try
            {
                oCDatos.registrarFControlCalidad(mv, usuarioId);
                result.success = true;
                result.msj = "Se registraron correctamente los datos";
            }
            catch (Exception ex)
            {
                result.success = false;
                result.msj = ex.Message;// "Sucedio un error al registrar";
            }
            return result;
        }

        //llanos
        public List<CapaEntidad.DOC.Ent_INFORME_MADERABLE> DatosMaderable(CEntidad oCampoEntrada)
        {            
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatosMaderable(cn, oCampoEntrada);
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CapaEntidad.DOC.Ent_INFORME_SEMILLERO> DatosSemillero(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatosSemillero(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CapaEntidad.DOC.Ent_INFORME_NO_MADERABLE> DatosNoMaderable(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatosNoMaderable(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CapaEntidad.DOC.Ent_INFORME_TROZA_CAMPO> DatosTrozaCampo(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatosTrozaCampo(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CapaEntidad.DOC.Ent_INFORME_MADERA_ASERRADA> DatosMaderaAserrada(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatosMaderaAserrada(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad AnalisisSupervision(string asCodInforme, string asCodTHabilitante, Int32 asNumPoa)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.AnalisisSupervision(asCodInforme, asCodTHabilitante, asNumPoa);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Dictionary<string, string>> Consolidado(string asCodInf, int iNumPoa, string idPC)
        {
            return oCDatos.ListarConsolidado(new Ent_INFORME() { COD_INFORME = asCodInf, NUM_POA = iNumPoa, COD_PARCELA = (idPC == "") ? null : idPC });
        }

        public List<Dictionary<string, string>> Maderable(string asCodInf, int iNumPoa, string idPC)
        {
            return oCDatos.ListarMaderable(new Ent_INFORME() { COD_INFORME = asCodInf, NUM_POA = iNumPoa, COD_PARCELA = (idPC == "") ? null : idPC });
        }

        #endregion
    }
}
