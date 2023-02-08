using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.DOC;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
using CDatos = CapaDatos.DOC.Dat_ANTECEDENTE_EXPEDIENTE;
using CEntidad = CapaEntidad.DOC.Ent_ANTECEDENTE_EXPEDIENTE;

namespace CapaLogica.DOC
{
    public class Log_ANTECEDENTE_EXPEDIENTE
    {
        private CDatos oCDatos = new CDatos();

        public CEntidad RegMostCombo(CEntidad oCEntidad)
        {
            try
            {
                oCEntidad.BusFormulario = "ANTECEDENTE_EXPEDIENTE";

                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<CEntidad> RegMostrarGeneral(CEntidad oCEntidad)
        //{
        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegMostrarGeneral(cn, oCEntidad);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public CEntidad RegMostrarListaItems(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaItems(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String RegGrabar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabar(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String RegGrabarSITD(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarSITD(cn, oCampoEntrada);
                    //cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> ReporteAntecedenteExpediente(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteAntecedenteExpediente(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListResult SincronizarSITD_TH(int COD_AEXPEDIENTE_SITD, int COD_TRAMITE_SITD, string COD_THABILITANTE, string NUM_THABILITANTE, string codCuenta, string codReferencia)
        {
            ListResult result = new ListResult();
            try
            {
                CEntidad oParamsAExpedienteSitd = new CEntidad();
                oParamsAExpedienteSitd.COD_AEXPEDIENTE_SITD = COD_AEXPEDIENTE_SITD;
                oParamsAExpedienteSitd.COD_TRAMITE_SITD = COD_TRAMITE_SITD;
                oParamsAExpedienteSitd.TIPO = "TRANSFERIR"; oParamsAExpedienteSitd.SUBTIPO = "THABILITANTE";
                oParamsAExpedienteSitd.COD_THABILITANTE = COD_THABILITANTE;
                oParamsAExpedienteSitd.NUM_THABILITANTE = NUM_THABILITANTE;
                oParamsAExpedienteSitd.ESTADO_AEXPEDIENTE = codReferencia == "0101" ? "Transferido" : "Pendiente";//0101: Código documento autoridad (TH) SITD
                oParamsAExpedienteSitd.OBSERVACION = "";
                oParamsAExpedienteSitd.COD_UCUENTA = codCuenta;
                oParamsAExpedienteSitd.ORIGEN_REGISTRO = 2;//sincronizacion
                oParamsAExpedienteSitd.OUTPUTPARAM01 = "";
                CDatos datAntecedentes = new CDatos();
                this.RegGrabar(oParamsAExpedienteSitd);
                result.AddResultado("Se sincronizarón correctamente los datos", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }
        //POA,PGMF,PGMFI,PMANEJO
        public ListResult SincronizarSITD_PLAN_MANEJO(int COD_AEXPEDIENTE_SITD, int COD_TRAMITE_SITD, string COD_DREFERENCIA, string CODIGO, string codCuenta, int numPoa)
        {
            ListResult result = new ListResult();
            try
            {
                CEntidad oParamsAExpedienteSitd = new CEntidad();
                string SUBTIPO = "";
                switch (COD_DREFERENCIA)
                {

                    case "0102"://Adenda
                        SUBTIPO = "ADENDA";
                        throw new Exception("Tipo de documento no permitido para la sincronización");
                    //break;
                    case "0301"://B.Extracción
                        SUBTIPO = "BEXTRACCION";
                        throw new Exception("Tipo de documento no permitido para la sincronización");
                    //break;
                    case "0401"://PGMF
                    case "0404"://PMFI
                        SUBTIPO = "PGMF";
                        oParamsAExpedienteSitd.COD_PGMF = CODIGO;
                        oParamsAExpedienteSitd.ESTADO_AEXPEDIENTE = "Transferido";
                        break;
                    case "0403"://PM (Fauna)
                        SUBTIPO = "PMANEJO";
                        oParamsAExpedienteSitd.COD_PMANEJO = CODIGO;
                        oParamsAExpedienteSitd.ESTADO_AEXPEDIENTE = "Transferido";
                        break;
                    case "0245"://PCM
                    case "0244"://PCNM
                    case "0202"://MS
                    case "0203"://REING
                    case "0246"://REFOR
                    case "0247"://REAJUS
                        //SUBTIPO = "POA";
                        throw new Exception("Tipo de documento no permitido para la sincronización");
                    //break;
                    case "0204"://POA/PO
                    case "0402"://DEMA   
                        oParamsAExpedienteSitd.COD_THABILITANTE = CODIGO;
                        oParamsAExpedienteSitd.NUM_POA = numPoa;
                        SUBTIPO = "POA";
                        oParamsAExpedienteSitd.ESTADO_AEXPEDIENTE = "Transferido";//0101: Código documento autoridad (TH) SITD
                        if (oParamsAExpedienteSitd.NUM_POA <= 0)
                            throw new Exception("No se puede continuar. EL valor Número de POA debe ser mayor a 0");
                        break;
                    default:
                        throw new Exception("Tipo de documento no permitido para la sincronización");
                        //break;
                }
                oParamsAExpedienteSitd.ORIGEN_REGISTRO = 2;//sincronizacion
                oParamsAExpedienteSitd.COD_AEXPEDIENTE_SITD = COD_AEXPEDIENTE_SITD;
                oParamsAExpedienteSitd.COD_TRAMITE_SITD = COD_TRAMITE_SITD;
                oParamsAExpedienteSitd.TIPO = "TRANSFERIR";
                oParamsAExpedienteSitd.SUBTIPO = SUBTIPO;
                oParamsAExpedienteSitd.RESOLUCION_POA = "";//los valores se obtienen internamente               
                oParamsAExpedienteSitd.OBSERVACION = "";
                oParamsAExpedienteSitd.COD_UCUENTA = codCuenta;
                oParamsAExpedienteSitd.OUTPUTPARAM01 = "";
                CDatos datAntecedentes = new CDatos();
                this.RegGrabar(oParamsAExpedienteSitd);
                result.AddResultado("Se sincronizarón correctamente los datos", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        public ListResult UpdateDatosSITD(CEntidad oCampoEntrada)
        {
            ListResult result = new ListResult();
            try
            {
                oCampoEntrada.OUTPUTPARAM01 = "";
                this.RegGrabarSITD(oCampoEntrada);
                result.AddResultado("Se actualizo correctamente los datos", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }
        public ListResult BExtraccionTransferir(string COD_THABILITANTE, string COD_DREFERENCIA, string COD_AEXPEDIENTE_SITD, string COD_TRAMITE_SITD, string itemPoaPadre, string ItemFecEmiBExtraccion, string ItemObservacionTransferir, string COD_UCUENTA)
        {
            ListResult result = new ListResult();
            try
            {
                if (COD_THABILITANTE != "")
                {
                    if (itemPoaPadre == "-" || itemPoaPadre == "0")
                        throw new Exception("Seleccione el Plan de Manejo Padre");

                    if (COD_DREFERENCIA == "0301")//BExt
                    {
                        if (ItemFecEmiBExtraccion != "")
                        {
                            //Grabar dato de la transferencia
                            CEntidad oParamsAExpedienteSitd = new CEntidad();
                            oParamsAExpedienteSitd.TIPO = "TRANSFERIR"; oParamsAExpedienteSitd.SUBTIPO = "BEXTRACCION";
                            oParamsAExpedienteSitd.COD_AEXPEDIENTE_SITD = Convert.ToInt32(COD_AEXPEDIENTE_SITD);
                            oParamsAExpedienteSitd.COD_TRAMITE_SITD = Convert.ToInt32(COD_TRAMITE_SITD);
                            oParamsAExpedienteSitd.OBSERVACION = ItemObservacionTransferir;
                            oParamsAExpedienteSitd.COD_THABILITANTE = COD_THABILITANTE;
                            oParamsAExpedienteSitd.NUM_POA = Convert.ToInt32(itemPoaPadre);
                            oParamsAExpedienteSitd.FECHA = ItemFecEmiBExtraccion;
                            oParamsAExpedienteSitd.ESTADO_AEXPEDIENTE = "Transferido";
                            oParamsAExpedienteSitd.COD_UCUENTA = COD_UCUENTA;
                            oParamsAExpedienteSitd.OUTPUTPARAM01 = "";
                            string oResultTransferir = this.RegGrabar(oParamsAExpedienteSitd);
                            if (oResultTransferir == "")
                            {
                                throw new Exception("Error al transferir el Balance de Extracción");
                            }
                            else
                            {
                                result.AddResultado("Transferencia realizada correctamente", true);
                            }
                        }
                        else throw new Exception("Seleccione la fecha de emisión del Balance de Extracción");
                    }
                    else
                    {
                        throw new Exception("Documento no permitido para el proceso");
                    }
                }
                else throw new Exception("Primero debe transferir los datos del Título Habilitante");

            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        public VM_Transferir InitTransferir(string tipo, string COD_DREFERENCIA, string DOC_REFERENCIA, string COD_AEXPEDIENTE_SITD, string COD_TRAMITE_SITD, string SUBTIPO)
        {
            VM_Transferir vm = new VM_Transferir();
            /*Log_BUSQUEDA oCLogica = new Log_BUSQUEDA();
            vm.cboModalidadTrans = oCLogica.RegMostComboIndividualV3("ANTECEDENTE_EXPEDIENTE", "MODALIDAD", "", true);*/
            CEntidad oParamsDatSigo = new CEntidad();
            oParamsDatSigo = this.RegMostCombo(oParamsDatSigo);
            List<VM_Cbo> cboModalidadTemp = new List<VM_Cbo>() { new VM_Cbo { Text = "(Seleccionar)", Value = "-" } };
            if (oParamsDatSigo.ListMComboModalidad != null)
            {
                foreach (var item in oParamsDatSigo.ListMComboModalidad)
                {
                    cboModalidadTemp.Add(new VM_Cbo { Text = item.DESCRIPCION, Value = item.CODIGO });
                }
            }
            vm.cboModalidadTrans = cboModalidadTemp;
            //vm.cboModalidadTrans = new List<VM_Cbo>(oParamsDatSigo.ListMComboModalidad.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }));
            vm.ItemCodAnteExpSitd = COD_TRAMITE_SITD + "|" + COD_AEXPEDIENTE_SITD;
            vm.ItemDocReferencia = DOC_REFERENCIA;

            //Datos SIGOsfc
            oParamsDatSigo = new CEntidad() { SINCRO_PGMF = null, COD_AEXPEDIENTE_SITD = Convert.ToInt32(COD_AEXPEDIENTE_SITD), COD_TRAMITE_SITD = Convert.ToInt32(COD_TRAMITE_SITD) };
            oParamsDatSigo = this.RegMostrarListaItems(oParamsDatSigo);
            vm.ItemCodTHabilitante = oParamsDatSigo.COD_THABILITANTE;
            if (oParamsDatSigo.COD_MTIPO != "-")
                vm.cboModalidadTransId = oParamsDatSigo.COD_MTIPO;
            vm.ItemNumPoa = oParamsDatSigo.NUM_POA == 0 ? "" : oParamsDatSigo.NUM_POA.ToString();
            vm.ItemNombrePoa = oParamsDatSigo.NOMBRE_POA;
            vm.COD_AEXPEDIENTE_SITD = COD_AEXPEDIENTE_SITD;
            vm.COD_TRAMITE_SITD = COD_TRAMITE_SITD;
            List<VM_Cbo> cboPadre = new List<VM_Cbo>() { new VM_Cbo { Text = "(Seleccionar)", Value = "-" } };
            if (oParamsDatSigo.ListMComboPOA != null)
            {
                foreach (var item in oParamsDatSigo.ListMComboPOA)
                {
                    cboPadre.Add(new VM_Cbo { Text = item.DESCRIPCION, Value = item.CODIGO });
                }
            }
            vm.COD_DREFERENCIA = COD_DREFERENCIA;
            vm.ddlItemPoaPadre = cboPadre;
            vm.pnlItemPlanManejoPadreEnabled = false;
            vm.ItemActoAdmin = oParamsDatSigo.NOMBRE_ACTO;
            vm.tipo = tipo;
            vm.subtipo = SUBTIPO;
            if (tipo == "ANULAR")
            {//Códigos obtenidos del cuadro documento autoridad del SITD: Tra_M_Tipo_Documento_Antecedentes(cCodigo)
                switch (COD_DREFERENCIA)
                {
                    case "0101"://TH
                    case "0102"://Adenda
                        break;
                    case "0301"://B.Extracción
                        vm.pnlItemPlanManejo = true;
                        vm.pnlItemPlanManejoPadre = true;
                        vm.pnlItemBExtraccion = true;
                        break;
                    case "0245"://PCM
                    case "0244"://PCNM
                    case "0202"://MS
                    case "0203"://REING
                    case "0246"://REFOR
                    case "0247"://REAJUS
                        vm.pnlItemPlanManejo = true;
                        vm.pnlItemPlanManejoPadre = true;
                        vm.pnlItemActoAdministrativo = true;
                        break;
                    default:
                        vm.pnlItemPlanManejo = true;
                        vm.pnlItemPlanManejoDetalle = true;
                        break;
                }
            }
            else
            {
                if (COD_DREFERENCIA == "0302" || COD_DREFERENCIA == "0609")//Forma 20, otros, documento no soportado
                {
                    throw new Exception("Documento no soportado por el SIGOsfc");
                }
                else
                {

                    vm.pnlItemTHabilitanteTransferir = oParamsDatSigo.COD_THABILITANTE == "" ? true : false;
                    vm.pnlItemMsjTHTransferir = oParamsDatSigo.COD_THABILITANTE == "" ? false : true;
                    vm.pnlItemPlanManejo = true;
                    vm.EXISTE_TH = oParamsDatSigo.SINCRO_TH.Value;

                    switch (COD_DREFERENCIA)
                    {
                        case "0101"://TH
                            vm.pnlItemPlanManejo = false;
                            break;
                        case "0102"://Adenda
                            vm.pnlItemPlanManejo = false;
                            vm.pnlItemAdendaTransferir = true;
                            break;
                        case "0301"://B.Extracción
                            vm.pnlItemPlanManejoPadre = true;
                            vm.pnlItemBExtraccion = true;
                            vm.pnlItemPlanManejoTransferir = oParamsDatSigo.NUM_POA == 0 ? true : false;
                            vm.pnlItemMsjPoaTransferir = oParamsDatSigo.NUM_POA == 0 ? false : true;
                            vm.pnlItemBExtraccionTransferir = true;
                            vm.pnlItemPlanManejoPadreEnabled = true;

                            break;
                        case "0401"://PGMF
                        case "0404"://PMFI
                            vm.pnlItemPlanManejoDetalle = true;
                            vm.pnlItemPlanManejoTransferir = oParamsDatSigo.COD_PGMF == "" ? true : false;
                            vm.pnlItemMsjPoaTransferir = oParamsDatSigo.COD_PGMF == "" ? false : true;
                            vm.COD_PGMF = oParamsDatSigo.COD_PGMF;
                            vm.EXISTE_PGMF = oParamsDatSigo.SINCRO_PGMF.Value;
                            break;
                        case "0403"://PM (Fauna)
                            vm.pnlItemPlanManejoDetalle = true;
                            vm.pnlItemPlanManejoTransferir = oParamsDatSigo.COD_PMANEJO == "" ? true : false;
                            vm.pnlItemMsjPoaTransferir = oParamsDatSigo.COD_PMANEJO == "" ? false : true;
                            vm.COD_PMANEJO = oParamsDatSigo.COD_PMANEJO;
                            vm.EXISTE_PM = oParamsDatSigo.SINCRO_PM.Value;
                            break;
                        case "0245"://PCM
                        case "0244"://PCNM
                        case "0202"://MS
                        case "0203"://REING
                        case "0246"://REFOR
                        case "0247"://REAJUS
                            vm.pnlItemPlanManejoPadre = true;
                            vm.pnlItemPlanManejoTransferir = oParamsDatSigo.NUM_POA == 0 ? true : false;
                            vm.pnlItemMsjPoaTransferir = oParamsDatSigo.NUM_POA == 0 ? false : true;
                            vm.pnlItemActoAdministrativo = true;
                            vm.pnlItemActoAdminTransferir = oParamsDatSigo.NUM_ACTO == 0 ? true : false;
                            vm.pnlItemMsjActoAdminTransferir = oParamsDatSigo.NUM_ACTO == 0 ? false : true;
                            vm.pnlItemPlanManejoPadreEnabled = true;
                            break;
                        default:
                            vm.pnlItemPlanManejoDetalle = true;
                            vm.pnlItemPlanManejoTransferir = oParamsDatSigo.NUM_POA == 0 ? true : false;
                            vm.pnlItemMsjPoaTransferir = oParamsDatSigo.NUM_POA == 0 ? false : true;
                            vm.EXISTE_POA = oParamsDatSigo.SINCRO_POA.Value;
                            break;
                    }
                }
            }
            return vm;
        }
        public ListResult AnularDocumentoTramite(string COD_AEXPEDIENTE_SITD, string COD_TRAMITE_SITD, string obs, string codUCuenta, string codRef = "")
        {
            ListResult result = new ListResult();
            try
            {
                if (COD_AEXPEDIENTE_SITD == "" || COD_TRAMITE_SITD == "") throw new Exception("Los datos enviados no son correctos. No se puede continuar con la anulación");
                CEntidad oParams = new CEntidad();
                oParams.TIPO = "ANULAR";
                oParams.COD_AEXPEDIENTE_SITD = Convert.ToInt32(COD_AEXPEDIENTE_SITD);
                oParams.COD_TRAMITE_SITD = Convert.ToInt32(COD_TRAMITE_SITD);
                oParams.OBSERVACION = obs;
                oParams.COD_UCUENTA = codUCuenta;
                oParams.OUTPUTPARAM01 = "";
                this.RegGrabar(oParams);
                result.AddResultado("El registro fue anulado", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }

        public ListResult sincronizar(CEntidad _dto, string codUCuenta)
        {
            ListResult result = new ListResult();
            try
            {
                CEntidad oParamsAExpedienteSitd = new CEntidad();
                oParamsAExpedienteSitd.COD_AEXPEDIENTE_SITD = _dto.COD_AEXPEDIENTE_SITD;
                oParamsAExpedienteSitd.COD_TRAMITE_SITD = _dto.COD_TRAMITE_SITD;
                oParamsAExpedienteSitd.TIPO = "SINCRONIZAR";
                oParamsAExpedienteSitd.COD_THABILITANTE = _dto.COD_THABILITANTE;
                oParamsAExpedienteSitd.NUM_POA = _dto.NUM_POA;
                //oParamsAExpedienteSitd.NUM_THABILITANTE = _dto.NUM_THABILITANTE;
                //oParamsAExpedienteSitd.ESTADO_AEXPEDIENTE = codReferencia == "0101" ? "Transferido" : "Pendiente";//0101: Código documento autoridad (TH) SITD
                //oParamsAExpedienteSitd.OBSERVACION = "";
                oParamsAExpedienteSitd.COD_UCUENTA = codUCuenta;
                //oParamsAExpedienteSitd.ORIGEN_REGISTRO = 2;//sincronizacion
                oParamsAExpedienteSitd.OUTPUTPARAM01 = "";
                oParamsAExpedienteSitd.COD_PGMF = _dto.COD_PGMF;
                oParamsAExpedienteSitd.COD_PMANEJO = _dto.COD_PMANEJO;
                CDatos datAntecedentes = new CDatos();
                this.RegGrabar(oParamsAExpedienteSitd);
                result.AddResultado("Se sincronizarón correctamente los datos", true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<Dictionary<string, string>> ReporteExcel(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteExcel(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
