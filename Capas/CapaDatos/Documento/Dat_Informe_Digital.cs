using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using GeneralSQL;
using GeneralSQL.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.DOC
{
    public class Dat_Informe_Digital
    {
        private DBOracle dBOracle = new DBOracle();
        public bool Eliminar(string COD_INFORME, string COD_USUARIO_OPERACION, DateTime FECHA_OPERACION)
        {
            bool success = false;
            OracleTransaction tr = null;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    object[] param = { COD_INFORME, COD_USUARIO_OPERACION, FECHA_OPERACION };
                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_SUPERVISIONTABINFORMEDIGITAL_ELIMINAR", param);
                    tr.Commit();
                    success = true;
                }
                catch (Exception ex)
                {
                    success = false;
                    if (tr != null)
                    {
                        tr.Rollback();
                        tr.Dispose();
                        tr = null;
                    }
                    throw ex;
                }
            }
            return success;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fechaOperacion"></param>
        /// <param name="estado">--1. Creado 2. Cerrado 3. Archivo cargado al sistema 4: Transferido documento al trámite</param>
        /// <returns></returns>
        public bool CambiarEstado(string codInformeDigital, DateTime fechaOperacion, int estado, string codUsuarioOperacion)
        {

            bool success = false;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();

                try
                {
                    object[] param = { codInformeDigital, fechaOperacion, estado, codUsuarioOperacion };
                    dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_SUPERVISIONTABINFORMEDIGITAL_ESTADO_ACTUALIZAR", param);
                    success = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return success;
        }
        public bool ActualizarDatosSITD(string codInforme,string numInforme,int tramiteId,DateTime fechaRegistroTramite, DateTime fechaOperacion, string codUsuarioOperacion)
        {

            bool success = false;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();

                try
                {
                    object[] param = { codInforme, numInforme, tramiteId, fechaRegistroTramite, codUsuarioOperacion, fechaOperacion };
                    dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_SUPERVISIONTABINFORMEDIGITAL_ACTUALIZAR_SITD", param);
                    success = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return success;
        }
        public bool NotificarControlCalidad(string codInforme,string numTH,string correo,string persona)
        {

            bool success = false;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();

                try
                {
                    object[] param = { codInforme, numTH, correo, persona };
                    dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_INFORME_NOTIFICAR_REVISION", param);
                    success = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return success;
        }
        public void ImportarInformeDigital(Ent_SupervisionTabInformeDigital informeDigital, String opcion = "INSERT")
        {
            String codInformeDigital = informeDigital.pVCodInformeDigital;
            OracleTransaction tr = null;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                try
                {
                    object[] param = { informeDigital.pVCodInformeDigital, informeDigital.pVInformeDigital, opcion };
                    dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_SUPERVISIONTABINFORMEDIGITAL_IMPORTARINFORME", param);
                    
                }
                catch (Exception ex)
                {
                    if (tr != null)
                    {
                        tr.Rollback();
                        tr.Dispose();
                        tr = null;
                    }
                    throw ex;
                }
            }
        }
        public string RegGrabar(Ent_SupervisionTabInformeDigital informeDigital, VM_INFORME_DIGITAL otros)
        {
            String OUTPUTPARAM01 = "", codInformeDigital = informeDigital.pVCodInformeDigital;

            OracleTransaction tr = null;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    /* object[] param1 = { informeDigital.pVCodInformeDigital, informeDigital.pVCodInforme, informeDigital.pVNumInformeSITD, informeDigital.pVCodDestinatario,Convert.ToDateTime(informeDigital.pDFechaRegistro),
                                        informeDigital.pVRucTitularEstado,informeDigital.pVRucTitularCondicion,informeDigital.pVRucTitularDireccion,informeDigital.pVNumTelefonoTitular,informeDigital.pVAntecedentes,
                                       informeDigital.pVTipoBosque,informeDigital.pVDiligenciaCronograma,informeDigital.pVMetodologia,informeDigital.pVAnalisis,informeDigital.pVResultados,
                                       informeDigital.pVConclusiones,informeDigital.pVRecomendaciones,informeDigital.pVCodUsuarioCreacion,informeDigital.pVCodUsuarioModificacion,Convert.ToDateTime(informeDigital.pDFechaCreacion),Convert.ToDateTime(informeDigital.pDFechaModificacion),informeDigital.pNRegEstado};
                    */
                    //dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_SUPERVISIONTABINFORMEDIGITAL_GRABAR", param1);
                    using (OracleCommand cmd = dBOracle.ManExecuteOutput(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_SUPERVISIONTABINFORMEDIGITAL_GRABAR", informeDigital))
                    {
                        cmd.ExecuteNonQuery();
                        OUTPUTPARAM01 = (String)cmd.Parameters["pVOUTPUTPARAM01"].Value;
                        codInformeDigital = OUTPUTPARAM01;

                        if (otros.OBJETIVOS != null)
                        {
                            foreach (var item in otros.OBJETIVOS)
                            {
                                object[] param = { codInformeDigital, item.item, item.detalle, item.estado, item.orden };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_SUPERVISIONTABINFORMEDIGITALOBJETIVO_GRABAR", param);
                            }
                        }
                        if (otros.RECURSOS != null)
                        {
                            foreach (var item in otros.RECURSOS)
                            {
                                object[] param = { codInformeDigital, item.item, item.tipo, item.detalle, item.estado };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_SUPERVISIONTABINFORMEDIGITALRECURSO_GRABAR", param);
                            }
                        }
                        if (otros.PARTICIPANTES != null)
                        {
                            foreach (var item in otros.PARTICIPANTES)
                            {
                                object[] param = { codInformeDigital, item.item, item.codParticipante, item.funcion, item.observacion, item.estado };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_SUPERVISIONTABINFORMEDIGITALPARTICIPANTE_GRABAR", param);
                            }
                        }
                        if (otros.ANEXOS != null)
                        {
                            foreach (var item in otros.ANEXOS)
                            {
                                object[] param = { codInformeDigital, item.item, item.titulo, item.detalle, item.estado, item.orden };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_SUPERVISIONTABINFORMEDIGITALANEXO_GRABAR", param);
                            }
                        }
                        if (otros.ACCESO_AREAS_TH != null)
                        {
                            foreach (var item in otros.ACCESO_AREAS_TH)
                            {
                                object[] param = { codInformeDigital, item.item, item.tramo, item.distancia, item.tiempo, item.transporte, item.tipoVehiculo, item.observaciones, item.estado };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_SUPERVISIONTABINFORMEDIGITALACCESOAREATH_GRABAR", param);
                            }
                        }
                        if (otros.ELIMINAR != null)
                        {
                            foreach (var item in otros.ELIMINAR)
                            {
                                object[] param = { item.codInformeDigital, item.item, item.origen };
                                dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_SUPERVISIONTABINFORMEDIGITAL_DET_ELIMINAR", param);
                            }
                        }
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    if (tr != null)
                    {
                        tr.Rollback();
                        tr.Dispose();
                        tr = null;
                    }
                    throw ex;
                }

            }
            return codInformeDigital;
        }
        public List<VM_INFORME_DIGITAL> ObtenerCabeceraMaderable(string COD_INFORME)
        {
            VM_INFORME_DIGITAL vm = null;
            List<VM_INFORME_DIGITAL> result = new List<VM_INFORME_DIGITAL>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spSupervision_InformeDigitalCabecera_Obtener", COD_INFORME))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_INFORME_DIGITAL();
                                    vm.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    vm.COD_MTIPO = dr["COD_MTIPO"].ToString();
                                    vm.MODALIDAD_TIPO = dr["MODALIDAD_TIPO"].ToString();
                                    vm.CONTRATO_TH_FECHA_INICIO = dr["CONTRATO_TH_FECHA_INICIO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_INICIO"]);
                                    vm.CONTRATO_TH_FECHA_FIN = dr["CONTRATO_TH_FECHA_FIN"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_FIN"]);
                                    vm.TITULAR_SUPERVISADO = dr["TITULAR_SUPERVISADO"].ToString();
                                    vm.TITULAR_TIPO_DOC = dr["TITULAR_TIPO_DOC"].ToString();
                                    vm.DOCUMENTO_TITULAR = dr["DOCUMENTO_TITULAR"].ToString();
                                    vm.REPRESENTANTE_LEGAL = dr["REPRESENTANTE_LEGAL"].ToString();
                                    vm.RLEGAL_TIPO_DOC = dr["RLEGAL_TIPO_DOC"].ToString();
                                    vm.DOCUMENTO_RLEGAL = dr["DOCUMENTO_RLEGAL"].ToString();
                                    vm.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    vm.UBIGEO_THABILITANTE = dr["UBIGEO_THABILITANTE"].ToString();
                                    vm.RUC_TITULAR = dr["RUC_TITULAR"].ToString();
                                    vm.DIRECCION_LEGAL = dr["DIRECCION_LEGAL"].ToString();
                                    vm.TELEFONO_TITULAR = dr["TELEFONO_TITULAR"].ToString();
                                    vm.AREA_THABILITANTE = Convert.ToDecimal(dr["AREA_THABILITANTE"]);


                                    //Informe Técnico de Inspección Ocular
                                    vm.PROFESIONAL_IOCULAR_POA = dr["PROFESIONAL_IOCULAR_POA"].ToString();
                                    vm.ITECNICO_IOCULAR_NUM = dr["ITECNICO_IOCULAR_NUM"].ToString();
                                    vm.ITECNICO_RAPROBACION_FECHA = dr["ITECNICO_RAPROBACION_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_RAPROBACION_FECHA"]);
                                    //INFORME QUE RECOMIENDA LA APROBACION DEL PLAN DE MANEJO
                                    vm.ITECNICO_RAPROBACION_PROFESIONAL = dr["ITECNICO_RAPROBACION_PROFESIONAL"].ToString();
                                    vm.ITECNICO_RAPROBACION_NUM = dr["ITECNICO_RAPROBACION_NUM"].ToString();
                                    vm.ITECNICO_IOCULAR_FECHA = dr["ITECNICO_IOCULAR_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_IOCULAR_FECHA"]);
                                    //RESOLUCION DE APROBACION DEL PLAN DE MANEJO   --POA / PO PMFI DEMA
                                    vm.OPORTUNIDAD_POA = dr["OPORTUNIDAD_POA"].ToString();
                                    vm.TIPO_POA = dr["TIPO_POA"].ToString();
                                    vm.COD_TIPO_POA = dr["COD_TIPO_POA"].ToString();
                                    vm.NOMBRE_POA = dr["NOMBRE_POA"].ToString();
                                    vm.NOMBRE_POA_PRINCIPAL = dr["NOMBRE_POA_PRINCIPAL"].ToString();
                                    vm.NUM_POA_PRINCIPAL = Convert.ToInt32(dr["NUM_POA_PRINCIPAL"]);
                                    vm.AREA_POA = Convert.ToDecimal(dr["AREA_POA"]);
                                    vm.PCA_POA = dr["PCA_POA"].ToString();
                                    vm.RESOLUCION_POA = dr["RESOLUCION_POA"].ToString();
                                    vm.FECHA_INICIO_VIGENCIA_POA = dr["FECHA_INICIO_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_INICIO_VIGENCIA_POA"]);
                                    vm.FECHA_FIN_VIGENCIA_POA = dr["FECHA_FIN_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_FIN_VIGENCIA_POA"]);
                                    vm.RESOLUCION_POA_FECHA = dr["RESOLUCION_POA_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["RESOLUCION_POA_FECHA"]);
                                    vm.REGENTE_POA = dr["REGENTE_POA"].ToString();
                                    vm.LICENCIA_REGENCIA_POA = dr["LICENCIA_REGENCIA_POA"].ToString();
                                    vm.TELEFONO_REGENTE_POA = dr["TELEFONO_REGENTE_POA"].ToString();
                                    vm.CORREO_REGENTE_POA = dr["CORREO_REGENTE_POA"].ToString();
                                    vm.FUNCIONARIO_APROBACION_POA = dr["FUNCIONARIO_APROBACION_POA"].ToString();
                                    // INFORME QUE RECOMIENDA LA APROBACION DEL PGMF
                                    vm.NUMERO_RECOMIENDA_PGMF = dr["NUMERO_RECOMIENDA_PGMF"].ToString();
                                    vm.FECHA_RECOMIENDA_PGMF = dr["FECHA_RECOMIENDA_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_RECOMIENDA_PGMF"]);
                                    vm.COD_CONSULTOR_PGMF = dr["COD_CONSULTOR_PGMF"].ToString();
                                    vm.CONSULTOR_PGMF = dr["CONSULTOR_PGMF"].ToString();

                                    //RESOLUCION DE APROBACION DEL PGMF
                                    vm.NUMERO_PGMF = dr["NUMERO_PGMF"].ToString();
                                    vm.FECHA_RESOLUCION_PGMF = dr["FECHA_RESOLUCION_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_RESOLUCION_PGMF"]);
                                    vm.FECHA_INICIO_PGMF = dr["FECHA_INICIO_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_INICIO_PGMF"]);
                                    vm.FECHA_FIN_PGMF = dr["FECHA_FIN_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_FIN_PGMF"]);
                                    vm.AREA_PGMF = Convert.ToDecimal(dr["AREA_PGMF"]);

                                    result.Add(vm);
                                }

                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void IDigitalEspecialistaCalidadObtener(string codInforme, out string codEspecialista,out string especialista,out string correo)
        {
            codEspecialista = ""; especialista = ""; correo = "";
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_INFORME_ESPECIALISTACALIDAD_OBTENER", codInforme))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                codEspecialista = dr["COD_SUP_CALIDAD"].ToString().Trim();
                                especialista = dr["PERSONA_SUP_CALIDAD"].ToString().Trim();
                                correo = dr["CORREO"].ToString().Trim();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VM_INFORME_DIGITAL ObtenerInformeDigitalShort(string COD_INFORME)
        {
            VM_INFORME_DIGITAL vm = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_SUPERVISIONTABINFORMEDIGITAL_OBTENER_SHORT", COD_INFORME))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_INFORME_DIGITAL();
                                    vm.COD_INFORME_DIGITAL = dr["VCodInformeDigital"].ToString();
                                    vm.COD_INFORME = dr["VCodInforme"].ToString();
                                    vm.NUM_INFORME_SITD = dr["VNumInformeSITD"].ToString();
                                    vm.TRAMITE_ID = dr["NTramiteId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NTramiteId"]);
                                    vm.COD_DESTINATARIO = dr["VCodDestinatario"].ToString();
                                    //vm.FECHA_REGISTRO = Convert.ToDateTime(dr["DFechaRegistro"]);
                                    vm.RUC_TITULAR_ESTADO = dr["VRucTitularEstado"].ToString();
                                    vm.RUC_TITULAR_CONDICION = dr["VRucTitularCondicion"].ToString();
                                    vm.RUC_TITULAR_DIRECCION = dr["VRucTitularDireccion"].ToString();
                                    vm.TELEFONO_TITULAR = dr["VNumTelefonoTitular"].ToString();
                                    vm.ANTECEDENTES = dr["VAntecedentes"].ToString();
                                    vm.TIPO_BOSQUE = dr["VTipoBosque"].ToString();
                                    vm.CRONOGRAMA = dr["VDiligenciaCronograma"].ToString();
                                    vm.METODOLOGIA = dr["VMetodologia"].ToString();
                                    vm.ANALISIS = dr["VAnalisis"].ToString();
                                    vm.RESULTADOS = dr["VResultados"].ToString();
                                    vm.CONCLUSIONES = dr["VConclusiones"].ToString();
                                    vm.RECOMENDACIONES = dr["VRecomendaciones"].ToString();
                                    vm.ESTADO = dr["NEstado"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NEstado"]);
                                    vm.ARCHIVO = dr["Archivo"].ToString();
                                }
                            }
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return vm;
        }
        public VM_INFORME_DIGITAL ObtenerInformeDigital(/*string COD_INFORME_DIGITAL,*/string COD_INFORME)
        {
            VM_INFORME_DIGITAL vm = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_SUPERVISIONTABINFORMEDIGITAL_OBTENER", COD_INFORME))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                vm = new VM_INFORME_DIGITAL();
                                vm.OBJETIVOS = new List<VM_INFORME_DIGITAL_OBJETIVO>();
                                vm.RECURSOS = new List<VM_INFORME_DIGITAL_RECURSO>();
                                vm.PARTICIPANTES = new List<VM_INFORME_DIGITAL_PARTICIPANTE>();
                                vm.ANEXOS = new List<VM_INFORME_DIGITAL_ANEXO>();
                                vm.ACCESO_AREAS_TH = new List<VM_INFORME_DIGITAL_ACCESO_AREA_TH>();
                                while (dr.Read())
                                {

                                    vm.COD_INFORME_DIGITAL = dr["VCodInformeDigital"].ToString();
                                    vm.COD_INFORME = dr["VCodInforme"].ToString();
                                    vm.NUM_INFORME_SITD = dr["VNumInformeSITD"].ToString();
                                    vm.TRAMITE_ID = dr["NTramiteId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NTramiteId"]);
                                    vm.COD_DESTINATARIO = dr["VCodDestinatario"].ToString();
                                    vm.FECHA_REGISTRO_SITD = dr["DFechaRegistro"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["DFechaRegistro"]);  
                                    vm.FECHA_REGISTRO = Convert.ToDateTime(dr["DFechaCreacion"]);
                                    vm.RUC_TITULAR_ESTADO = dr["VRucTitularEstado"].ToString();
                                    vm.RUC_TITULAR_CONDICION = dr["VRucTitularCondicion"].ToString();
                                    vm.RUC_TITULAR_DIRECCION = dr["VRucTitularDireccion"].ToString();
                                    vm.TELEFONO_TITULAR = dr["VNumTelefonoTitular"].ToString();
                                    vm.ANTECEDENTES = dr["VAntecedentes"].ToString();
                                    vm.TIPO_BOSQUE = dr["VTipoBosque"].ToString();
                                    vm.CRONOGRAMA = dr["VDiligenciaCronograma"].ToString();
                                    vm.METODOLOGIA = dr["VMetodologia"].ToString();
                                    vm.ANALISIS = dr["VAnalisis"].ToString();
                                    vm.RESULTADOS = dr["VResultados"].ToString();
                                    vm.CONCLUSIONES = dr["VConclusiones"].ToString();
                                    vm.RECOMENDACIONES = dr["VRecomendaciones"].ToString();
                                    vm.ESTADO = dr["NEstado"] == DBNull.Value ? 0 : Convert.ToInt32(dr["NEstado"]);
                                    vm.ARCHIVO = dr["Archivo"].ToString();
                                }
                                //OBJETIVOS
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    VM_INFORME_DIGITAL_OBJETIVO objetivo = null;
                                    while (dr.Read())
                                    {
                                        objetivo = new VM_INFORME_DIGITAL_OBJETIVO();
                                        objetivo.codInformeDigital = dr["VCodInformeDigital"].ToString();
                                        objetivo.item = Convert.ToInt32(dr["NItem"]);
                                        objetivo.detalle = dr["Detalle"].ToString();
                                        objetivo.estado = Convert.ToInt32(dr["NEstado"]);
                                        objetivo.orden = Convert.ToInt32(dr["NOrden"]);
                                        vm.OBJETIVOS.Add(objetivo);
                                    }
                                }
                                //RECURSOS
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    VM_INFORME_DIGITAL_RECURSO recurso = null;
                                    while (dr.Read())
                                    {
                                        recurso = new VM_INFORME_DIGITAL_RECURSO();
                                        recurso.codInformeDigital = dr["VCodInformeDigital"].ToString();
                                        recurso.item = Convert.ToInt32(dr["NItem"]);
                                        recurso.tipo = dr["VTipo"].ToString();
                                        recurso.detalle = dr["Detalle"].ToString();
                                        recurso.estado = Convert.ToInt32(dr["NEstado"]);
                                        vm.RECURSOS.Add(recurso);
                                    }
                                }
                                //PARTICIPANTES
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    VM_INFORME_DIGITAL_PARTICIPANTE participante = null;
                                    while (dr.Read())
                                    {
                                        participante = new VM_INFORME_DIGITAL_PARTICIPANTE();
                                        participante.codInformeDigital = dr["VCodInformeDigital"].ToString();
                                        participante.item = Convert.ToInt32(dr["NItem"]);
                                        participante.codParticipante = dr["VCodParticipante"].ToString();
                                        participante.apellidosNombres = dr["VApellidosNombres"].ToString();
                                        participante.numeroDocumento = dr["VNDocumento"].ToString();
                                        participante.funcion = dr["VFuncion"].ToString();
                                        participante.observacion = dr["VObservacion"].ToString();
                                        participante.estado = Convert.ToInt32(dr["NEstado"]);
                                        vm.PARTICIPANTES.Add(participante);
                                    }
                                }
                                //ANEXOS
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    VM_INFORME_DIGITAL_ANEXO anexo = null;
                                    while (dr.Read())
                                    {
                                        anexo = new VM_INFORME_DIGITAL_ANEXO();
                                        anexo.codInformeDigital = dr["VCodInformeDigital"].ToString();
                                        anexo.item = Convert.ToInt32(dr["NItem"]);
                                        anexo.titulo = dr["VTitulo"].ToString();
                                        anexo.detalle = dr["VDetalle"].ToString();
                                        anexo.estado = Convert.ToInt32(dr["NEstado"]);
                                        anexo.orden = Convert.ToInt32(dr["NOrden"]);
                                        vm.ANEXOS.Add(anexo);
                                    }
                                }
                                //ACCESO_AREA_TH
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    VM_INFORME_DIGITAL_ACCESO_AREA_TH accesoAreaTH = null;
                                    while (dr.Read())
                                    {
                                        accesoAreaTH = new VM_INFORME_DIGITAL_ACCESO_AREA_TH();
                                        accesoAreaTH.codInformeDigital = dr["VCodInformeDigital"].ToString();
                                        accesoAreaTH.item = Convert.ToInt32(dr["NItem"]);
                                        accesoAreaTH.tramo = dr["VTramo"].ToString();
                                        accesoAreaTH.distancia = Convert.ToDecimal(dr["NDistancia"]);
                                        accesoAreaTH.tiempo = Convert.ToDecimal(dr["NTiempo"]);
                                        accesoAreaTH.transporte = dr["VTransporte"].ToString();
                                        accesoAreaTH.tipoVehiculo = dr["VTipoVehiculo"].ToString();
                                        accesoAreaTH.observaciones = dr["VObservaciones"].ToString();
                                        accesoAreaTH.estado = Convert.ToInt32(dr["NEstado"]);
                                        vm.ACCESO_AREAS_TH.Add(accesoAreaTH);
                                    }
                                }
                            }
                        }
                    }
                }
                return vm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VM_INFORME_DIGITAL_VERTICE> ObtenerVerticeTH_PLANMaderable(string COD_THABILITANTE, int NUM_POA)
        {
            VM_INFORME_DIGITAL_VERTICE vm = null;
            List<VM_INFORME_DIGITAL_VERTICE> result = new List<VM_INFORME_DIGITAL_VERTICE>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_INFORMEDIGITALVERTICETHPLAN_OBTENER", COD_THABILITANTE, NUM_POA))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_INFORME_DIGITAL_VERTICE();
                                    vm.GRUPO = dr["GRUPO"].ToString();
                                    vm.VERTICE = dr["VERTICE"].ToString();
                                    vm.ZONA = dr["ZONA"].ToString();
                                    vm.COORDENADA_ESTE = Convert.ToInt32(dr["COORDENADA_ESTE"]);
                                    vm.COORDENADA_NORTE = Convert.ToInt32(dr["COORDENADA_NORTE"]);
                                    result.Add(vm);
                                }
                                
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {

                                while (dr.Read())
                                {
                                    vm = new VM_INFORME_DIGITAL_VERTICE();
                                    vm.GRUPO = dr["GRUPO"].ToString();
                                    vm.VERTICE = dr["VERTICE"].ToString();
                                    vm.ZONA = dr["ZONA"].ToString();
                                    vm.COORDENADA_ESTE = Convert.ToInt32(dr["COORDENADA_ESTE"]);
                                    vm.COORDENADA_NORTE = Convert.ToInt32(dr["COORDENADA_NORTE"]);
                                    result.Add(vm);
                                }
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VM_EVALUACION_VERTICE> ObtenerEvaluacionVertice(string codInforme)
        {
            VM_EVALUACION_VERTICE ocampoEnt = null;
            List<VM_EVALUACION_VERTICE> result = new List<VM_EVALUACION_VERTICE>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_INFORMEDIGITAL_EVALUACION_VERTICE", codInforme))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ocampoEnt = new VM_EVALUACION_VERTICE();                                  
                                    ocampoEnt.VERTICE_TH = dr["VERTICE"].ToString();
                                    ocampoEnt.VERTICE_SUP = dr["VERTICE_CAMPO"].ToString();
                                    ocampoEnt.ZONA_TH = dr["ZONA"].ToString();
                                    ocampoEnt.ZONA_SUP= dr["ZONA_CAMPO"].ToString();
                                    ocampoEnt.COORDENADA_ESTE_TH = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    ocampoEnt.COORDENADA_ESTE_SUP = Int32.Parse(dr["COORDENADA_ESTE_CAMPO"].ToString());
                                    ocampoEnt.COORDENADA_NORTE_TH = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    ocampoEnt.COORDENADA_NORTE_SUP = Int32.Parse(dr["COORDENADA_NORTE_CAMPO"].ToString());
                                    ocampoEnt.OBSERVACION = dr["OBSERVACION_CAMPO"].ToString();
                                    
                                    result.Add(ocampoEnt);
                                }
                               
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VM_INFORME_DIGITAL> ObtenerAntecedentesMaderable(string COD_INFORME,string COD_THABILITANTE, ref List<VM_CARTA_NOTIFICACION_ANTECEDENTE> NOTIFICACIONES_SITD, ref List<VM_DOCUMENTO_ANTECEDENTE> DOCUMENTOS_SITD,ref List<VM_INFORME_SUSPENSION> LIST_INFORME_SUSPENSION)
        {
            VM_INFORME_DIGITAL vm = null;
            VM_CARTA_NOTIFICACION_ANTECEDENTE notificacionSITD = null;
            VM_DOCUMENTO_ANTECEDENTE documentoSITD = null;
            VM_INFORME_SUSPENSION informeSuspension = null;
            OracleTransaction tr = null;
            List<VM_INFORME_DIGITAL> result = new List<VM_INFORME_DIGITAL>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (OracleDataReader dr = dBOracle.SelDrdDefaultTR(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_INFORMEDIGITALANTECEDENTE_OBTENER", COD_INFORME, COD_THABILITANTE))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_INFORME_DIGITAL();
                                    vm.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    vm.COD_MTIPO = dr["COD_MTIPO"].ToString();
                                    vm.MODALIDAD_TIPO = dr["MODALIDAD_TIPO"].ToString();
                                    vm.CONTRATO_TH_FECHA_INICIO = dr["CONTRATO_TH_FECHA_INICIO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_INICIO"]);
                                    vm.CONTRATO_TH_FECHA_FIN = dr["CONTRATO_TH_FECHA_FIN"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_FIN"]);
                                    vm.TITULAR_SUPERVISADO = dr["TITULAR_SUPERVISADO"].ToString();
                                    vm.TITULAR_TIPO_DOC = dr["TITULAR_TIPO_DOC"].ToString();
                                    vm.DOCUMENTO_TITULAR = dr["DOCUMENTO_TITULAR"].ToString();
                                    vm.REPRESENTANTE_LEGAL = dr["REPRESENTANTE_LEGAL"].ToString();
                                    vm.RLEGAL_TIPO_DOC = dr["RLEGAL_TIPO_DOC"].ToString();
                                    vm.DOCUMENTO_RLEGAL = dr["DOCUMENTO_RLEGAL"].ToString();
                                    vm.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    vm.UBIGEO_THABILITANTE = dr["UBIGEO_THABILITANTE"].ToString();
                                    vm.RUC_TITULAR = dr["RUC_TITULAR"].ToString();
                                    vm.DIRECCION_LEGAL = dr["DIRECCION_LEGAL"].ToString();
                                    vm.TELEFONO_TITULAR = dr["TELEFONO_TITULAR"].ToString();
                                    vm.AREA_THABILITANTE = Convert.ToDecimal(dr["AREA_THABILITANTE"]);


                                    //Informe Técnico de Inspección Ocular
                                    vm.PROFESIONAL_IOCULAR_POA = dr["PROFESIONAL_IOCULAR_POA"].ToString();
                                    vm.ITECNICO_IOCULAR_NUM = dr["ITECNICO_IOCULAR_NUM"].ToString();
                                    vm.ITECNICO_RAPROBACION_FECHA = dr["ITECNICO_RAPROBACION_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_RAPROBACION_FECHA"]);
                                    //INFORME QUE RECOMIENDA LA APROBACION DEL PLAN DE MANEJO
                                    vm.ITECNICO_RAPROBACION_PROFESIONAL = dr["ITECNICO_RAPROBACION_PROFESIONAL"].ToString();
                                    vm.ITECNICO_RAPROBACION_NUM = dr["ITECNICO_RAPROBACION_NUM"].ToString();
                                    vm.ITECNICO_IOCULAR_FECHA = dr["ITECNICO_IOCULAR_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_IOCULAR_FECHA"]);
                                    //RESOLUCION DE APROBACION DEL PLAN DE MANEJO   --POA / PO PMFI DEMA
                                    vm.OPORTUNIDAD_POA = dr["OPORTUNIDAD_POA"].ToString();
                                    vm.TIPO_POA = dr["TIPO_POA"].ToString();
                                    vm.COD_TIPO_POA = dr["COD_TIPO_POA"].ToString();
                                    vm.NOMBRE_POA = dr["NOMBRE_POA"].ToString();
                                    vm.NOMBRE_POA_PRINCIPAL = dr["NOMBRE_POA_PRINCIPAL"].ToString();
                                    vm.NUM_POA_PRINCIPAL = Convert.ToInt32(dr["NUM_POA_PRINCIPAL"]);
                                    vm.AREA_POA = Convert.ToDecimal(dr["AREA_POA"]);
                                    vm.NUM_POA = Convert.ToInt32(dr["NUM_POA"]);
                                    vm.PCA_POA = dr["PCA_POA"].ToString();
                                    vm.RESOLUCION_POA = dr["RESOLUCION_POA"].ToString();
                                    vm.FECHA_INICIO_VIGENCIA_POA = dr["FECHA_INICIO_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_INICIO_VIGENCIA_POA"]);
                                    vm.FECHA_FIN_VIGENCIA_POA = dr["FECHA_FIN_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_FIN_VIGENCIA_POA"]);
                                    vm.RESOLUCION_POA_FECHA = dr["RESOLUCION_POA_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["RESOLUCION_POA_FECHA"]);
                                    vm.REGENTE_POA = dr["REGENTE_POA"].ToString();
                                    vm.LICENCIA_REGENCIA_POA = dr["LICENCIA_REGENCIA_POA"].ToString();
                                    vm.TELEFONO_REGENTE_POA = dr["TELEFONO_REGENTE_POA"].ToString();
                                    vm.CORREO_REGENTE_POA = dr["CORREO_REGENTE_POA"].ToString();
                                    vm.FUNCIONARIO_APROBACION_POA = dr["FUNCIONARIO_APROBACION_POA"].ToString();
                                    // INFORME QUE RECOMIENDA LA APROBACION DEL PGMF
                                    vm.NUMERO_RECOMIENDA_PGMF = dr["NUMERO_RECOMIENDA_PGMF"].ToString();
                                    vm.FECHA_RECOMIENDA_PGMF = dr["FECHA_RECOMIENDA_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_RECOMIENDA_PGMF"]);
                                    vm.COD_CONSULTOR_PGMF = dr["COD_CONSULTOR_PGMF"].ToString();
                                    vm.CONSULTOR_PGMF = dr["CONSULTOR_PGMF"].ToString();

                                    //RESOLUCION DE APROBACION DEL PGMF
                                    vm.NUMERO_PGMF = dr["NUMERO_PGMF"].ToString();
                                    vm.FECHA_RESOLUCION_PGMF = dr["FECHA_RESOLUCION_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_RESOLUCION_PGMF"]);
                                    vm.FECHA_INICIO_PGMF = dr["FECHA_INICIO_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_INICIO_PGMF"]);
                                    vm.FECHA_FIN_PGMF = dr["FECHA_FIN_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_FIN_PGMF"]);
                                    vm.AREA_PGMF = Convert.ToDecimal(dr["AREA_PGMF"]);

                                    vm.ACTA_IOCULAR_NUM = dr["ACTA_IOCULAR_NUM"].ToString();
                                    vm.ACTA_SIN_INS_OCULAR = Convert.ToInt32(dr["ACTA_SIN_INS_OCULAR"]);
                                    vm.ACTA_IOCULAR_FECHA = dr["ACTA_IOCULAR_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ACTA_IOCULAR_FECHA"]);
                                    vm.ACTA_PROFESIONAL_IOCULAR_POA = dr["ACTA_PROFESIONAL_IOCULAR_POA"].ToString();

                                    vm.DEPENDENCIA = dr["DEPENDENCIA"].ToString();
                                    result.Add(vm);
                                }
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        notificacionSITD = new VM_CARTA_NOTIFICACION_ANTECEDENTE();
                                        notificacionSITD.tabDetalle = dr["TAB_DETALLE"].ToString();
                                        notificacionSITD.tipoCarta = dr["TIPO_CARTA"].ToString();
                                        notificacionSITD.nroCartaNotificacion = dr["NRO_CARTA_NOTIFICACION"].ToString();
                                        notificacionSITD.fechaEmision = dr["FECHA_EMISION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_EMISION"]);
                                        notificacionSITD.nombreRegente = dr["NOMBRE_REGENTE"].ToString();
                                        notificacionSITD.nombrePlanManejo = dr["NOMBRE_POA"].ToString();
                                        notificacionSITD.resolucionPlanManejo = dr["ARESOLUCION_NUM"].ToString();
                                        notificacionSITD.fechaNotificacion = dr["FECHA_NOTIFICACION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_NOTIFICACION"]);
                                        notificacionSITD.personaNotificacion = dr["PERSONA_NOTIFICADA"].ToString();
                                        notificacionSITD.parentescoPerNotificacion = dr["PARENTESCO_NOTIFICADO"].ToString();
                                        //NOTIFICACIONES_SITD.Add(notificacionSITD);
                                    }

                                }
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        documentoSITD = new VM_DOCUMENTO_ANTECEDENTE();
                                        documentoSITD.tipoDocumento = dr["TIPO_DE_DOCUMENTO"].ToString();
                                        documentoSITD.nroDocumento = dr["cNroDocumento"].ToString();
                                        documentoSITD.fechaRecepcion = dr["FECHA_RECEPCION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_RECEPCION"]);
                                        documentoSITD.remitente = dr["REMITENTE"].ToString();
                                        documentoSITD.tipoDocumentoRemitido = dr["TIPO_DOCUMENTO_REMITIDO"].ToString();
                                        documentoSITD.nroResolucionAprobacion = dr["NRO_RESOLUCION_APROBACION"].ToString();
                                        //DOCUMENTOS_SITD.Add(documentoSITD);
                                    }
                                }
                                //  Mostrando informe de suspensión en el caso que existiera
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        informeSuspension = new VM_INFORME_SUSPENSION();
                                        informeSuspension.nroInforme = dr["NUMERO"].ToString();
                                        informeSuspension.fechaCreacionInforme = dr["FECHA_CREACION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_CREACION"]);
                                        informeSuspension.nroCartaNotificacion = dr["CNOTIFICACION"].ToString();
                                        informeSuspension.fechaCartaNotificacion = dr["FECHA_CARTA_NOTIFICACION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_CARTA_NOTIFICACION"]);
                                        informeSuspension.motivoSuspension = dr["MOTIVO"].ToString();
                                        LIST_INFORME_SUSPENSION.Add(informeSuspension);
                                    }
                                }
                            }
                        }
                    }
                    tr.Commit();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<THabilitantePOA> getPlanManejoTHabilitanteObservatorio(string COD_THABILITANTE)
        {
            Busqueda busqueda = new Busqueda()
            {
                BUSCRITERIO = "TITULO_RESUMEN_INFORME_DIGITAL",
                BUSVALOR = COD_THABILITANTE,
                v_currentpage = 1,
                v_pagesize = 100,
                v_NUM_POA = 1,
                v_estado = 1
            };

            var habilitantePOAList = new List<THabilitantePOA>();

            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_OBSERVATORIO()))
                {
                    cn.Open();
                    OracleTransaction tr = null;
                    tr = cn.BeginTransaction();
                    //object[] param = { busqueda.BUSCRITERIO, busqueda.BUSVALOR, busqueda.v_currentpage, busqueda.v_pagesize, null, busqueda.v_COD_THABILITANTE, busqueda.v_NUM_POA, busqueda.v_COD_INFORME, busqueda.v_estado };
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, tr, "doc_BD_OBSERVATORIO_migracion.sp_ReporteTrazabilidad_OSINFOR_General", busqueda))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    THabilitantePOA poaResumen = new THabilitantePOA();
                                    poaResumen.cod_thabilitante = dr["COD_THABILITANTE"].ToString();
                                    poaResumen.num_poa = Int32.Parse(dr["NUM_POA"].ToString());
                                    poaResumen.cod_informe = dr["COD_INFORME"].ToString();
                                    poaResumen.documento = dr["DOCUMENTO"].ToString();
                                    poaResumen.resolucion_poa = dr["RESOLUCION_POA"].ToString();
                                    poaResumen.cant_especie = Int32.Parse(dr["CANT_ESPECIE"].ToString());
                                    poaResumen.volumen = Decimal.Parse(dr["VOLUMEN"].ToString());
                                    poaResumen.kilogramos = Int32.Parse(dr["KILOGRAMOS"].ToString());
                                    poaResumen.consultor = dr["CONSULTOR"].ToString();
                                    poaResumen.supervision = dr["SUPERVISION"].ToString();
                                    poaResumen.numero_informe = dr["NUMERO_INFORME"].ToString();
                                    poaResumen.informe_digital = dr["INFORME_DIGITAL"].ToString();
                                    poaResumen.anio_informe = dr["ANIO_INFORME"].ToString();
                                    poaResumen.estado_pau = dr["ESTADO_PAU"].ToString();
                                    poaResumen.estado_conta = dr["ESTADO_CONTA"].ToString();
                                    poaResumen.id_registro = Int32.Parse(dr["ID_REGISTRO"].ToString());
                                    poaResumen.color = dr["COLOR"].ToString();
                                    poaResumen.modalidad_conta = dr["MODALIDAD_CONTA"].ToString();
                                    poaResumen.estado = Int32.Parse(dr["ESTADO"].ToString());
                                    //poaResumen.rdList = new List<DetRDPOA>();
                                    //if (poaResumen.cod_informe != null && poaResumen.cod_informe != "")
                                    //{
                                    //    Busqueda busTemp = new Busqueda();
                                    //    busTemp.BUSCRITERIO = "RESOLUCIONES_RESUMEN";
                                    //    busTemp.v_COD_INFORME = poaResumen.cod_informe;

                                    //    using (OracleDataReader drPOA = dBOracle.SelDrdDefault(cn, tr, "doc_BD_OBSERVATORIO_migracion.sp_ReporteTrazabilidad_OSINFOR_General", busTemp))
                                    //    {
                                    //        if (drPOA != null)
                                    //        {
                                    //            if (drPOA.HasRows)
                                    //            {
                                    //                while (drPOA.Read())
                                    //                {
                                    //                    DetRDPOA resolucion = new DetRDPOA();
                                    //                    resolucion.numero_rd = drPOA["NUM_RD"].ToString();
                                    //                    resolucion.digital_rd = drPOA["RD_DIGITAL"].ToString();
                                    //                    poaResumen.rdList.Add(resolucion);
                                    //                }
                                    //            }
                                    //        }

                                    //    }
                                    //}
                                    habilitantePOAList.Add(poaResumen);
                                }

                            }
                        }
                    }
                    cn.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return habilitantePOAList;
        }
        public List<Dictionary<string, string>> GeneralListar(string busCriterio, string busValor)
        {
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spSupervision_InformeDigitalGeneral_Listar", busCriterio, busValor))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Dictionary<string, string> sFila;
                                string sColumn = "";

                                while (dr.Read())
                                {
                                    sFila = new Dictionary<string, string>();
                                    for (int i = 0; i < dr.FieldCount; i++)
                                    {
                                        sColumn = dr.GetName(i);
                                        sFila.Add(sColumn, dr[sColumn].ToString().Trim());
                                    }
                                    lstResult.Add(sFila);
                                }
                            }
                        }
                    }
                }
                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Permite obtener los vertices del título habilitante y los vertices cuando van a supervidar a campo
        /// </summary>
        /// <param name="codInforme"></param>
        /// <returns></returns>
        public List<VM_EVALUACION_VERTICE> ObtenerVerticeTHSupervisado(string codInforme)
        {
            VM_EVALUACION_VERTICE ocampoEnt = null;
            List<VM_EVALUACION_VERTICE> result = new List<VM_EVALUACION_VERTICE>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_INFORMEDIGITAL_VERTICE_TH_SUPERVISADO", codInforme))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ocampoEnt = new VM_EVALUACION_VERTICE();
                                    ocampoEnt.VERTICE_TH = dr["VERTICE"].ToString();
                                    ocampoEnt.VERTICE_SUP = dr["VERTICE_CAMPO"].ToString();
                                    ocampoEnt.ZONA_TH = dr["ZONA"].ToString();
                                    ocampoEnt.ZONA_SUP = dr["ZONA_CAMPO"].ToString();
                                    ocampoEnt.COORDENADA_ESTE_TH = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    ocampoEnt.COORDENADA_ESTE_SUP = Int32.Parse(dr["COORDENADA_ESTE_CAMPO"].ToString());
                                    ocampoEnt.COORDENADA_NORTE_TH = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    ocampoEnt.COORDENADA_NORTE_SUP = Int32.Parse(dr["COORDENADA_NORTE_CAMPO"].ToString());
                                    ocampoEnt.OBSERVACION = dr["OBSERVACION_CAMPO"].ToString();                                   
                                    result.Add(ocampoEnt);
                                }

                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Permite obtener los vertices de un plan de manejo y los vertices cuando van a supervidar a campo
        /// </summary>
        /// <param name="codTH"></param>
        /// <param name="numPoa"></param>
        /// <returns></returns>
        public List<VM_EVALUACION_VERTICE> ObtenerVerticePlanManejoSupervisado(string codTH,string codInforme,int numPoa)
        {
            VM_EVALUACION_VERTICE ocampoEnt = null;
            List<VM_EVALUACION_VERTICE> result = new List<VM_EVALUACION_VERTICE>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_INFORMEDIGITAL_VERTICE_POA_SUPERVISADO", codTH, codInforme, numPoa))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    ocampoEnt = new VM_EVALUACION_VERTICE();
                                    ocampoEnt.VERTICE_TH = dr["VERTICE"].ToString();
                                    ocampoEnt.VERTICE_SUP = dr["VERTICE_CAMPO"].ToString();
                                    ocampoEnt.ZONA_TH = dr["ZONA"].ToString();
                                    ocampoEnt.ZONA_SUP = dr["ZONA_CAMPO"].ToString();
                                    ocampoEnt.COORDENADA_ESTE_TH = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    ocampoEnt.COORDENADA_ESTE_SUP = Int32.Parse(dr["COORDENADA_ESTE_CAMPO"].ToString());
                                    ocampoEnt.COORDENADA_NORTE_TH = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    ocampoEnt.COORDENADA_NORTE_SUP = Int32.Parse(dr["COORDENADA_NORTE_CAMPO"].ToString());
                                    ocampoEnt.OBSERVACION = dr["OBSERVACION_CAMPO"].ToString();
                                    ocampoEnt.DIFERENCIA_ESTE = ocampoEnt.COORDENADA_ESTE_SUP- ocampoEnt.COORDENADA_ESTE_TH;
                                    ocampoEnt.DIFERENCIA_NORTE =ocampoEnt.COORDENADA_NORTE_SUP - ocampoEnt.COORDENADA_NORTE_TH;
                                    result.Add(ocampoEnt);
                                }

                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region "planes de manejo"
        public List<VM_INFORME_DIGITAL_PM> PlanManejoListar(String codInforme)
        {
            List<VM_INFORME_DIGITAL_PM> lsCEntidad = new List<VM_INFORME_DIGITAL_PM>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_INFORMEDIGITAL_PM_LISTAR", codInforme))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                VM_INFORME_DIGITAL_PM ocampoEnt;
                                while (dr.Read())
                                {
                                    ocampoEnt = new VM_INFORME_DIGITAL_PM();
                                    ocampoEnt.COD_INFORME = dr["COD_INFORME"].ToString();
                                    ocampoEnt.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    ocampoEnt.NUM_POA = Int32.Parse(dr["NUM_POA"].ToString());
                                    ocampoEnt.POA = dr["POA"].ToString();
                                    ocampoEnt.PUBLICAR = Convert.ToBoolean(dr["PUBLICAR"]);
                                    ocampoEnt.SUPERVISADO = Convert.ToBoolean(dr["SUPERVISADO"]);
                                    ocampoEnt.B_POA = Convert.ToInt32(dr["B_POA"]);
                                    ocampoEnt.CODIGO_SEC_NOPOA = dr["CODIGO_SEC_NOPOA"].ToString();
                                    lsCEntidad.Add(ocampoEnt);
                                }
                            }

                        }
                    }
                }

                return lsCEntidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VM_INFORME_DIGITAL_PM_DATOS PlanManejoListarDatos(string codTH, string codInforme, int numPoa)
        {
            VM_INFORME_DIGITAL_PM_DATOS vmdatos = new VM_INFORME_DIGITAL_PM_DATOS();
            vmdatos.ListAnalisis = new List<Ent_INFORME_ANALISIS>();
            vmdatos.ListMaderable = new List<Ent_INFORME_MADERABLE_A>();
            vmdatos.ListConsolidado = new List<Ent_INFORME_CONSOLIDADO>();
            vmdatos.ConsolidadoTotal = new Ent_INFORME_CONSOLIDADO();
            vmdatos.ListVerticePM = new List<VM_INFORME_DIGITAL_VERTICE>();
            vmdatos.ListEspecieApro = new List<VM_ESPECIES>();
            vmdatos.ListOtroPuntoEvaluacion = new List<OtroPuntoEvaluacion>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_INFORMEDIGITAL_PM_DATOS_LISTAR", codTH, codInforme, numPoa))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {   //Analisis maderable
                                Ent_INFORME_ANALISIS oanalisis;
                                while (dr.Read())
                                {
                                    oanalisis = new Ent_INFORME_ANALISIS();
                                    oanalisis.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oanalisis.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
                                    oanalisis.NUM_PIEZAS = Int32.Parse(dr["NUM_PIEZAS"].ToString());
                                    oanalisis.VOLUMEN_AUTORIZADO = decimal.Parse(dr["VOLUMEN_AUTORIZADO"].ToString());
                                    oanalisis.VOLUMEN = decimal.Parse(dr["VOLUMEN"].ToString());
                                    oanalisis.PORC = decimal.Parse(dr["PORC"].ToString());
                                    oanalisis.SALDO = decimal.Parse(dr["SALDO"].ToString());
                                    oanalisis.NUM_ARBOLES = Int32.Parse(dr["NUM_ARBOLES"].ToString());
                                    oanalisis.VOLUMEN_MOVILIZADO = decimal.Parse(dr["VOLUMEN_MOVILIZADO"].ToString());
                                    oanalisis.DIFERENCIA = decimal.Parse(dr["DIFERENCIA"].ToString());
                                    oanalisis.BEXTRACCION_FEMISION = dr["BEXTRACCION_FEMISION"].ToString();
                                    vmdatos.ListAnalisis.Add(oanalisis);
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                Ent_INFORME_MADERABLE_A omaderable;
                                while (dr.Read())
                                {
                                    omaderable = new Ent_INFORME_MADERABLE_A();
                                    omaderable.CODIGO = dr["CODIGO"].ToString();
                                    omaderable.CODIGO_CAMPO = dr["CODIGO_CAMPO"].ToString();
                                    omaderable.DESC_ESPECIES = dr["NOMBRE_PMF"].ToString();
                                    omaderable.DESC_ESPECIES_COMUN = dr["NOMBRE_COMUN_PMF"].ToString();
                                    omaderable.DESC_ESPECIES_CAMPO = dr["NOMBRE_SUP"].ToString();
                                    omaderable.DESC_ESPECIES_COMUN_CAMPO = dr["NOMBRE_COMUN_SUP"].ToString();
                                    omaderable.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE_PMF"].ToString());
                                    omaderable.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE_PMF"].ToString());
                                    omaderable.COORDENADA_ESTE_CAMPO = Int32.Parse(dr["COORDENADA_ESTE_SUP"].ToString());
                                    omaderable.COORDENADA_NORTE_CAMPO = Int32.Parse(dr["COORDENADA_NORTE_SUP"].ToString());
                                    omaderable.DAP = decimal.Parse(dr["DAP_PMF"].ToString());
                                    omaderable.DAP_CAMPO = decimal.Parse(dr["DAP_SUP"].ToString());
                                    omaderable.DAP_CAMPO1 = decimal.Parse(dr["DAP1_SUP"].ToString());
                                    omaderable.DAP_CAMPO2 = decimal.Parse(dr["DAP2_SUP"].ToString());
                                    omaderable.MMEDIR_DAP = dr["METOD_MEDIR_DAP"].ToString();
                                    omaderable.AC = decimal.Parse(dr["AC_PMF"].ToString());
                                    omaderable.AC_CAMPO = decimal.Parse(dr["AC_SUP"].ToString());
                                    omaderable.VOLUMEN = decimal.Parse(dr["VOL_PMF"].ToString());
                                    omaderable.VOLUMEN_CAMPO = decimal.Parse(dr["VOL_SUP"].ToString());
                                    omaderable.COINCIDE_CODIGO = dr["COINCIDE_CODIGO"].ToString();
                                    omaderable.COINCIDE_ESPECIES = dr["COINCIDE_ESPECIES"].ToString();
                                    omaderable.DAP_RP = decimal.Parse(dr["DAP_RP"].ToString());
                                    omaderable.AC_RP = decimal.Parse(dr["AC_RP"].ToString());
                                    omaderable.COO_RP = decimal.Parse(dr["COO_RP"].ToString());
                                    omaderable.DESC_EESTADO_CAMPO = dr["ESTADO"].ToString();
                                    omaderable.DESC_ECONDICION_CAMPO = dr["CONDICION"].ToString();
                                    vmdatos.ListMaderable.Add(omaderable);
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                Ent_INFORME_CONSOLIDADO oconsolidado;
                                while (dr.Read())
                                {
                                    oconsolidado = new Ent_INFORME_CONSOLIDADO();
                                    oconsolidado.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    oconsolidado.NOMBRE_CIENTIFICO = dr["NOMBRE_CIENTIFICO"].ToString();
                                    oconsolidado.NUM_PIEZAS = Int32.Parse(dr["NUM_PIEZAS"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_PIEZAS += oconsolidado.NUM_PIEZAS;
                                    oconsolidado.VOLUMEN_AUTORIZADO = decimal.Parse(dr["VOLUMEN_AUTORIZADO"].ToString());
                                    vmdatos.ConsolidadoTotal.VOLUMEN_AUTORIZADO += oconsolidado.VOLUMEN_AUTORIZADO;
                                    oconsolidado.NUM_ARBOLES = Int32.Parse(dr["NUM_ARBOLES"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARBOLES += oconsolidado.NUM_ARBOLES;
                                    oconsolidado.VOLUMEN_CENSO = decimal.Parse(dr["VOLUMEN_CENSO"].ToString());
                                    vmdatos.ConsolidadoTotal.VOLUMEN_CENSO += oconsolidado.VOLUMEN_CENSO;
                                    oconsolidado.NUM_ARB_SEM = Int32.Parse(dr["NUM_ARB_SEM"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARB_SEM += oconsolidado.NUM_ARB_SEM;
                                    oconsolidado.NUM_ARB_TOT = Int32.Parse(dr["NUM_ARB_TOT"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARB_TOT += oconsolidado.NUM_ARB_TOT;
                                    oconsolidado.NUM_ARB_AEP = Int32.Parse(dr["NUM_ARB_AEP"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARB_AEP += oconsolidado.NUM_ARB_AEP;
                                    oconsolidado.VOLUMEN_AEP = decimal.Parse(dr["VOLUMEN_AEP"].ToString());
                                    vmdatos.ConsolidadoTotal.VOLUMEN_AEP += oconsolidado.VOLUMEN_AEP;
                                    oconsolidado.NUM_ARB_ATU = Int32.Parse(dr["NUM_ARB_ATU"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARB_ATU += oconsolidado.NUM_ARB_ATU;
                                    oconsolidado.VOLUMEN_ATU = decimal.Parse(dr["VOLUMEN_ATU"].ToString());
                                    vmdatos.ConsolidadoTotal.VOLUMEN_ATU += oconsolidado.VOLUMEN_ATU;
                                    oconsolidado.NUM_ARB_ATF = Int32.Parse(dr["NUM_ARB_ATF"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARB_ATF += oconsolidado.NUM_ARB_ATF;
                                    oconsolidado.VOLUMEN_ATF = decimal.Parse(dr["VOLUMEN_ATF"].ToString());
                                    vmdatos.ConsolidadoTotal.VOLUMEN_ATF += oconsolidado.VOLUMEN_ATF;
                                    oconsolidado.NUM_ARB_AMO = Int32.Parse(dr["NUM_ARB_AMO"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARB_AMO += oconsolidado.NUM_ARB_AMO;
                                    oconsolidado.VOLUMEN_AMO = decimal.Parse(dr["VOLUMEN_AMO"].ToString());
                                    vmdatos.ConsolidadoTotal.VOLUMEN_AMO += oconsolidado.VOLUMEN_AMO;
                                    oconsolidado.NUM_ARB_AMF = Int32.Parse(dr["NUM_ARB_AMF"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARB_AMF += oconsolidado.NUM_ARB_AMF;
                                    oconsolidado.VOLUMEN_AMF = decimal.Parse(dr["VOLUMEN_AMF"].ToString());
                                    vmdatos.ConsolidadoTotal.VOLUMEN_AMF += oconsolidado.VOLUMEN_AMF;
                                    oconsolidado.NUM_ARB_ACN = Int32.Parse(dr["NUM_ARB_ACN"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARB_ACN += oconsolidado.NUM_ARB_ACN;
                                    oconsolidado.VOLUMEN_ACN = decimal.Parse(dr["VOLUMEN_ACN"].ToString());
                                    vmdatos.ConsolidadoTotal.VOLUMEN_ACN += oconsolidado.VOLUMEN_ACN;
                                    oconsolidado.NUM_ARB_ANE = Int32.Parse(dr["NUM_ARB_ANE"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARB_ANE += oconsolidado.NUM_ARB_ANE;
                                    oconsolidado.NUM_ARB_NEP = Int32.Parse(dr["NUM_ARB_NEP"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARB_NEP += oconsolidado.NUM_ARB_NEP;
                                    oconsolidado.VOLUMEN_NEP = decimal.Parse(dr["VOLUMEN_NEP"].ToString());
                                    vmdatos.ConsolidadoTotal.VOLUMEN_NEP += oconsolidado.VOLUMEN_NEP;
                                    oconsolidado.NUM_ARB_NTU = Int32.Parse(dr["NUM_ARB_NTU"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARB_NTU += oconsolidado.NUM_ARB_NTU;
                                    oconsolidado.VOLUMEN_NTU = decimal.Parse(dr["VOLUMEN_NTU"].ToString());
                                    vmdatos.ConsolidadoTotal.VOLUMEN_NTU += oconsolidado.VOLUMEN_NTU;
                                    oconsolidado.NUM_ARB_NCN = Int32.Parse(dr["NUM_ARB_NCN"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARB_NCN += oconsolidado.NUM_ARB_NCN;
                                    oconsolidado.VOLUMEN_NCN = decimal.Parse(dr["VOLUMEN_NCN"].ToString());
                                    vmdatos.ConsolidadoTotal.VOLUMEN_NCN += oconsolidado.VOLUMEN_NCN;
                                    oconsolidado.NUM_ARB_SEP = Int32.Parse(dr["NUM_ARB_SEP"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARB_SEP += oconsolidado.NUM_ARB_SEP;
                                    oconsolidado.NUM_ARB_STU = Int32.Parse(dr["NUM_ARB_STU"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARB_STU += oconsolidado.NUM_ARB_STU;
                                    oconsolidado.VOLUMEN_STU = decimal.Parse(dr["VOLUMEN_STU"].ToString());
                                    vmdatos.ConsolidadoTotal.VOLUMEN_STU += oconsolidado.VOLUMEN_STU;
                                    oconsolidado.NUM_ARB_SMO = Int32.Parse(dr["NUM_ARB_SMO"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARB_SMO += oconsolidado.NUM_ARB_SMO;
                                    oconsolidado.VOLUMEN_SMO = decimal.Parse(dr["VOLUMEN_SMO"].ToString());
                                    vmdatos.ConsolidadoTotal.VOLUMEN_SMO += oconsolidado.VOLUMEN_SMO;
                                    oconsolidado.NUM_ARB_SCN = Int32.Parse(dr["NUM_ARB_SCN"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARB_SCN += oconsolidado.NUM_ARB_SCN;
                                    oconsolidado.NUM_ARB_SNE = Int32.Parse(dr["NUM_ARB_SNE"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARB_SNE += oconsolidado.NUM_ARB_SNE;

                                    oconsolidado.NUM_ARB_NEA = Int32.Parse(dr["NUM_ARB_NEA"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARB_NEA += oconsolidado.NUM_ARB_NEA;
                                    oconsolidado.NUM_ARB_NES = Int32.Parse(dr["NUM_ARB_NES"].ToString());
                                    vmdatos.ConsolidadoTotal.NUM_ARB_NES += oconsolidado.NUM_ARB_NES;
                                    oconsolidado.TOTAL_SUP = Int32.Parse(dr["TOTAL_SUP"].ToString());
                                    vmdatos.ConsolidadoTotal.TOTAL_SUP += oconsolidado.TOTAL_SUP;

                                    vmdatos.ListConsolidado.Add(oconsolidado);
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                VM_INFORME_DIGITAL_VERTICE vertice = null;
                                while (dr.Read())
                                {
                                    vertice = new VM_INFORME_DIGITAL_VERTICE();
                                    vertice.VERTICE = dr["VERTICE"].ToString();
                                    vertice.ZONA = dr["ZONA"].ToString();
                                    vertice.COORDENADA_ESTE = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    vertice.COORDENADA_NORTE = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    vertice.area = Convert.ToDecimal(dr["AREA"]);
                                    vmdatos.ListVerticePM.Add(vertice);
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                VM_ESPECIES especie = null;
                                while (dr.Read())
                                {
                                    especie = new VM_ESPECIES();
                                    especie.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    especie.ESPECIE = dr["ESPECIE"].ToString();
                                    especie.NUM_ARBOLES = Convert.ToInt32(dr["NUM_ARBOLES"]);
                                    especie.VOLUMEN = Convert.ToDecimal(dr["VOLUMEN_KILOGRAMOS"]);
                                    vmdatos.ListEspecieApro.Add(especie);
                                }
                            }
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                OtroPuntoEvaluacion oevalotro = null;
                                while (dr.Read())
                                {
                                    oevalotro = new OtroPuntoEvaluacion();
                                   
                                    oevalotro.evaluacion = dr["EVALUACION"].ToString();
                                    oevalotro.zona = dr["ZONA"].ToString();
                                    oevalotro.coordenadaEste = Int32.Parse(dr["COORDENADA_ESTE"].ToString());
                                    oevalotro.coordenadaNorte = Int32.Parse(dr["COORDENADA_NORTE"].ToString());
                                    oevalotro.descripcion = dr["DESCRIPCION"].ToString();
                                    vmdatos.ListOtroPuntoEvaluacion.Add(oevalotro);
                                }
                            }
                        }
                    }
                }

                return vmdatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Dictionary<string, string>> TramiteGeneralListar_Dictionary(string busCriterio, string busValor)
        {
            SQL oGDataSQL = new SQL();
            List<Dictionary<string, string>> lstResult = new List<Dictionary<string, string>>();
            try
            {
                using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena_SITD()))
                {
                    cn.Open();
                    using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, "USP_SIGO_SUPERVISION_GENERAL_LISTAR", busCriterio, busValor))
                    {
                        if (dr != null)
                        {
                            if (dr.HasRows)
                            {
                                Dictionary<string, string> sFila;
                                string sColumn = "";

                                while (dr.Read())
                                {
                                    sFila = new Dictionary<string, string>();
                                    for (int i = 0; i < dr.FieldCount; i++)
                                    {
                                        sColumn = dr.GetName(i);
                                        sFila.Add(sColumn, dr[sColumn].ToString().Trim());
                                    }
                                    lstResult.Add(sFila);
                                }
                            }
                        }
                    }
                }
                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VM_Cbo> TramiteGeneralListar(string busCriterio, string busValor)
        {
            VM_Cbo vm = null;
            List<VM_Cbo> result = new List<VM_Cbo>();
            SQL oGDataSQL = new SQL();

            object[] param = { busCriterio, busValor };
            using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena_SITD()))
            {
                cn.Open();
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, "USP_SIGO_SUPERVISION_GENERAL_LISTAR", param))
                {
                    if (dr != null)
                    {

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                vm = new VM_Cbo();
                                vm.Value = dr["VALUE"].ToString();
                                vm.Text = dr["TEXT"].ToString();
                                result.Add(vm);
                            }
                        }
                    }
                }
            }
            return result;
        }
        public VM_TRAMITE TramiteGetById(int tramiteId, string cod_THabilitante, string cod_Informe)
        {
            VM_TRAMITE vm = null;
            SQL oGDataSQL = new SQL();

            object[] param = { tramiteId, cod_THabilitante, cod_Informe };
            using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena_SITD()))
            {
                cn.Open();
                using (SqlDataReader dr = oGDataSQL.SelDrdDefault(cn, "USP_SIGO_SUPERVISION_TRA_M_TRAMITE_GETBYID", param))
                {
                    if (dr != null)
                    {

                        if (dr.HasRows)
                        {
                            dr.Read();
                            vm = new VM_TRAMITE();
                            vm.iCodTramite = Convert.ToInt32(dr["iCodTramite"]);
                            vm.cCodificacion = dr["cCodificacion"].ToString();
                            vm.password = dr["cPassword"].ToString();
                            vm.fechaRegistro = Convert.ToDateTime(dr["fFecDocumento"]);
                            vm.cCodTipoDoc = Convert.ToInt32(dr["cCodTipoDoc"]);
                            vm.cDescTipoDoc = dr["cDescTipoDoc"].ToString();
                            vm.iCodOficina = Convert.ToInt32(dr["iCodOficinaRegistro"]);
                            vm.cAsunto = dr["cAsunto"] == null ? string.Empty : dr["cAsunto"].ToString().Trim();
                            vm.cObservaciones = dr["cObservaciones"] == null ? string.Empty : dr["cObservaciones"].ToString().Trim();
                            vm.cnNumFolio = dr["nNumFolio"].ToString();
                            vm.cod_THabilitante = dr["cAdm_sigo"].ToString();
                            vm.cod_Informe = dr["i_CodInformeSigo"].ToString();
                            vm.nFlgEstado = Convert.ToInt32(dr["nFlgEstado"]);

                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                dr.Read();
                                vm.trabajadorId = Convert.ToInt32(dr["iCodTrabajadorDerivar"]);
                                vm.trabajador = dr["trabajador"].ToString();
                                vm.indicacionId = Convert.ToInt32(dr["iCodIndicacionDerivar"]);
                                vm.prioridad = dr["cPrioridadDerivar"].ToString();
                            }

                            //Referencias
                            dr.NextResult();
                            if (dr.HasRows)
                            {
                                vm.lstReferencias = new List<VM_TRAMITE_REFERENCIA>();
                                VM_TRAMITE_REFERENCIA objRef;

                                while (dr.Read())
                                {
                                    objRef = new VM_TRAMITE_REFERENCIA();
                                    objRef.iCodTramite = Convert.ToInt32(dr["iCodTramite"]);
                                    objRef.iCodTramiteRef = dr["iCodTramiteRef"] != DBNull.Value ? Convert.ToInt32(dr["iCodTramiteRef"]) : default(int?);
                                    objRef.cReferencia = dr["cReferencia"] != DBNull.Value ? dr["cReferencia"].ToString() : null;
                                    objRef.cCodSession = dr["cCodSession"] != DBNull.Value ? dr["cCodSession"].ToString() : null;
                                    objRef.cDesEstado = dr["cDesEstado"] != DBNull.Value ? dr["cDesEstado"].ToString() : null;
                                    objRef.iCodTipo = dr["iCodTipo"] != DBNull.Value ? Convert.ToInt32(dr["iCodTipo"]) : default(int?);

                                    vm.lstReferencias.Add(objRef);
                                }
                            }
                        }
                    }
                }
            }
            return vm;
        }
        public void TramiteModificar(VM_TRAMITE tramite)
        {

            SQL oGDataSQL = new SQL();

            object[] param = { tramite.cAsunto, tramite.cObservaciones, tramite.cnNumFolio, tramite.cod_THabilitante, tramite.cod_Informe, tramite.iCodTramite };
            using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena_SITD()))
            {
                cn.Open();
                oGDataSQL.ManExecute(cn, null, "USP_SIGO_SUPERVISION_TRA_M_TRAMITE_MODIFICAR", param);
            }
        }
        public int TramiteGrabar(VM_TRAMITE tramite, VM_TRAMITE_MOVIMIENTO dt)
        {
            SQL oGDataSQL = new SQL();
            SqlTransaction tr = null;
            using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena_SITD()))
            {
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "USP_SIGO_SUPERVISION_TRA_M_TRAMITE_GRABAR";
                        cmd.Parameters.AddWithValue("@pIcCodTipoDoc", tramite.cCodTipoDoc);
                        cmd.Parameters.AddWithValue("@pIiCodOficina", tramite.iCodOficina);
                        cmd.Parameters.AddWithValue("@pTcAsunto", tramite.cAsunto);
                        cmd.Parameters.AddWithValue("@pVcObservaciones", tramite.cObservaciones);
                        cmd.Parameters.AddWithValue("@pCnNumFolio", tramite.cnNumFolio);
                        //cmd.Parameters.AddWithValue("@pIiCodTrabajadorLogin", tramite.iCodTrabajadorLogin);
                        cmd.Parameters.AddWithValue("@pVCod_THabilitante", tramite.cod_THabilitante);
                        cmd.Parameters.AddWithValue("@pVCod_INFORME", tramite.cod_Informe);
                        cmd.Parameters.AddWithValue("@pIiCodTramite", tramite.iCodTramite);
                        cmd.Parameters.AddWithValue("@cUsuario", tramite.cUsuario);
                        cmd.Parameters["@pIiCodTramite"].Direction = ParameterDirection.Output;

                        cmd.Transaction = tr;
                        cmd.ExecuteNonQuery();
                        tramite.iCodTramite = Convert.ToInt32(cmd.Parameters["@pIiCodTramite"].Value);
                    }

                    //registrando detalle
                    dt.iCodTramite = tramite.iCodTramite;
                    object[] param = { dt.iCodTramite,dt.iCodTrabajadorRegistro ,dt.nFlgTipoDoc,dt.iCodOficinaOrigen,
                                        dt.iCodOficinaDerivar,dt.iCodTrabajadorDerivar,dt.iCodIndicacionDerivar,dt.cPrioridadDerivar,
                                        dt.cAsuntoDerivar,dt.cObservacionesDerivar,dt.fFecDerivar,dt.fFecMovimiento,
                                         dt.nEstadoMovimiento,dt.cFlgTipoMovimiento,dt.cFlgOficina,dt.nflgtra,dt.nflgpri,dt.cCodTipoDocDerivar,dt.nFlgEnvio,dt.iCodTrabajadorPerfil};
                    oGDataSQL.ManExecute(cn, tr, "USP_SIGO_SUPERVISION_TRA_M_TRAMITE_MOVIMIENTOS_GRABAR", param);

                    //Referencias
                    if (tramite.lstReferencias != null)
                    {
                        foreach (var item in tramite.lstReferencias)
                        {
                            object[] referencia = { tramite.iCodTramite, item.iCodTramiteRef, item.cReferencia, item.cCodSession, item.cDesEstado, item.iCodTipo };
                            oGDataSQL.ManExecute(cn, tr, "USP_SIGO_SUPERVISION_TRA_M_TRAMITE_REFERENCIA_GRABAR", referencia);
                        }
                    }

                    tr.Commit();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    if (tr != null)
                    {
                        tr.Rollback();
                    }
                    throw ex;
                }
            }
            return tramite.iCodTramite;
        }

        public void TramiteDigitalGrabar(int tramiteId, string nombreDocumento, string nombreDocumentoNuevo, DateTime fechaOperacion)
        {
            SQL oGDataSQL = new SQL();
            SqlTransaction tr = null;
            using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena_SITD()))
            {
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    object[] param = { tramiteId, nombreDocumento, nombreDocumentoNuevo, fechaOperacion };
                    oGDataSQL.ManExecute(cn, tr, "USP_SIGO_SUPERVISION_TRA_M_TRAMITE_DIGITALES_GRABAR", param);
                    tr.Commit();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    if (tr != null)
                    {
                        tr.Rollback();
                    }
                    throw ex;
                }
            }
        }
        #endregion

        #region "Firma digital"
        public List<VM_SUPERVISOR> SupervisorObtenerPorInformeAll(string codInforme)
        {
            List<VM_SUPERVISOR> supervisores = new List<VM_SUPERVISOR>();
            VM_SUPERVISOR supervisor = null;
            object[] param = { codInforme, "OBTENER_POR_INFORME", "" };
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_SUPERVISOR_OPERACION", param))
                {
                    if (dr != null)
                    {

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                supervisor = new VM_SUPERVISOR();
                                supervisor.COD_PERSONA = dr["COD_PERSONA"].ToString();
                                supervisor.APELLIDOS_NOMBRES = dr["APELLIDOS_NOMBRES"].ToString();
                                supervisor.FLAG_FIRMA = Convert.ToInt32(dr["FLAG_FIRMA"]);
                                supervisores.Add(supervisor);
                            }

                        }
                    }
                }
            }
            return supervisores;
        }
        public VM_SUPERVISOR SupervisorObtenerPorInforme(string codInforme, string codSupervisor)
        {
            VM_SUPERVISOR supervisor = null;
            object[] param = { codInforme, "OBTENER_POR_INFORME_SUPERVISOR", codSupervisor };
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_SUPERVISOR_OPERACION", param))
                {
                    if (dr != null)
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            supervisor = new VM_SUPERVISOR();
                            supervisor.COD_PERSONA = dr["COD_PERSONA"].ToString();
                            supervisor.APELLIDOS_NOMBRES = dr["APELLIDOS_NOMBRES"].ToString();
                            supervisor.FLAG_FIRMA = Convert.ToInt32(dr["FLAG_FIRMA"]);
                        }
                    }
                }
            }
            return supervisor;
        }
        public bool ActualizarFirmaPorInformeSupervisor(string codInforme, string codSupervisor)
        {

            bool success = false;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();

                try
                {
                    object[] param = { codInforme, "ACTUALIZAR_FIRMA_POR_INFORME_SUPERVISOR", codSupervisor };
                    dBOracle.ManExecute(cn, null, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_SUPERVISOR_OPERACION", param);
                    success = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return success;
        }
        public bool AnularFirmaPorInforme(string codInforme)
        {

            bool success = false;
            OracleTransaction tr = null;
            using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    object[] param = { codInforme, "ANULAR_FIRMA_POR_INFORME", "" };
                    dBOracle.ManExecute(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_SUPERVISOR_OPERACION", param);
                    tr.Commit();
                    success = true;
                }
                catch (Exception ex)
                {
                    if (tr != null)
                    {
                        tr.Rollback();
                        tr.Dispose();
                        tr = null;
                    }
                    throw ex;
                }
            }
            return success;
        }
        #endregion
        #region "No maderable (No Maderables Aguaje,No Maderables Castaña, No Maderables Shiringa)"
        /*
             No Maderables Aguaje  - 0000018
             No Maderables Castaña - 0000008
             No Maderables Shiringa - 0000009
         * */
        public List<VM_INFORME_DIGITAL> ObtenerCabeceraNoMaderable(string COD_INFORME)
        {
            VM_INFORME_DIGITAL vm = null;
            List<VM_INFORME_DIGITAL> result = new List<VM_INFORME_DIGITAL>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.spSupervision_InformeDigitalCabeceraNoMaderable_Obtener", COD_INFORME))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_INFORME_DIGITAL();
                                    vm.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    vm.COD_MTIPO = dr["COD_MTIPO"].ToString();
                                    vm.MODALIDAD_TIPO = dr["MODALIDAD_TIPO"].ToString();
                                    vm.CONTRATO_TH_FECHA_INICIO = dr["CONTRATO_TH_FECHA_INICIO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_INICIO"]);
                                    vm.CONTRATO_TH_FECHA_FIN = dr["CONTRATO_TH_FECHA_FIN"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_FIN"]);
                                    vm.TITULAR_SUPERVISADO = dr["TITULAR_SUPERVISADO"].ToString();
                                    vm.TITULAR_TIPO_DOC = dr["TITULAR_TIPO_DOC"].ToString();
                                    vm.DOCUMENTO_TITULAR = dr["DOCUMENTO_TITULAR"].ToString();
                                    vm.REPRESENTANTE_LEGAL = dr["REPRESENTANTE_LEGAL"].ToString();
                                    vm.RLEGAL_TIPO_DOC = dr["RLEGAL_TIPO_DOC"].ToString();
                                    vm.DOCUMENTO_RLEGAL = dr["DOCUMENTO_RLEGAL"].ToString();
                                    vm.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    vm.UBIGEO_THABILITANTE = dr["UBIGEO_THABILITANTE"].ToString();
                                    vm.RUC_TITULAR = dr["RUC_TITULAR"].ToString();
                                    vm.DIRECCION_LEGAL = dr["DIRECCION_LEGAL"].ToString();
                                    vm.TELEFONO_TITULAR = dr["TELEFONO_TITULAR"].ToString();
                                    vm.AREA_THABILITANTE = Convert.ToDecimal(dr["AREA_THABILITANTE"]);


                                    //Informe Técnico de Inspección Ocular
                                    vm.PROFESIONAL_IOCULAR_POA = dr["PROFESIONAL_IOCULAR_POA"].ToString();
                                    vm.ITECNICO_IOCULAR_NUM = dr["ITECNICO_IOCULAR_NUM"].ToString();
                                    vm.ITECNICO_RAPROBACION_FECHA = dr["ITECNICO_RAPROBACION_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_RAPROBACION_FECHA"]);
                                    //INFORME QUE RECOMIENDA LA APROBACION DEL PLAN DE MANEJO
                                    vm.ITECNICO_RAPROBACION_PROFESIONAL = dr["ITECNICO_RAPROBACION_PROFESIONAL"].ToString();
                                    vm.ITECNICO_RAPROBACION_NUM = dr["ITECNICO_RAPROBACION_NUM"].ToString();
                                    vm.ITECNICO_IOCULAR_FECHA = dr["ITECNICO_IOCULAR_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_IOCULAR_FECHA"]);
                                    //RESOLUCION DE APROBACION DEL PLAN DE MANEJO   --POA / PO PMFI DEMA
                                    vm.OPORTUNIDAD_POA = dr["OPORTUNIDAD_POA"].ToString();
                                    vm.TIPO_POA = dr["TIPO_POA"].ToString();
                                    vm.COD_TIPO_POA = dr["COD_TIPO_POA"].ToString();
                                    vm.NOMBRE_POA = dr["NOMBRE_POA"].ToString();
                                    vm.NOMBRE_POA_PRINCIPAL = dr["NOMBRE_POA_PRINCIPAL"].ToString();
                                    vm.NUM_POA_PRINCIPAL = Convert.ToInt32(dr["NUM_POA_PRINCIPAL"]);
                                    vm.AREA_POA = Convert.ToDecimal(dr["AREA_POA"]);
                                    vm.PCA_POA = dr["PCA_POA"].ToString();
                                    vm.RESOLUCION_POA = dr["RESOLUCION_POA"].ToString();
                                    vm.FECHA_INICIO_VIGENCIA_POA = dr["FECHA_INICIO_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_INICIO_VIGENCIA_POA"]);
                                    vm.FECHA_FIN_VIGENCIA_POA = dr["FECHA_FIN_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_FIN_VIGENCIA_POA"]);
                                    vm.RESOLUCION_POA_FECHA = dr["RESOLUCION_POA_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["RESOLUCION_POA_FECHA"]);
                                    vm.REGENTE_POA = dr["REGENTE_POA"].ToString();
                                    vm.LICENCIA_REGENCIA_POA = dr["LICENCIA_REGENCIA_POA"].ToString();
                                    vm.TELEFONO_REGENTE_POA = dr["TELEFONO_REGENTE_POA"].ToString();
                                    vm.CORREO_REGENTE_POA = dr["CORREO_REGENTE_POA"].ToString();
                                    vm.FUNCIONARIO_APROBACION_POA = dr["FUNCIONARIO_APROBACION_POA"].ToString();
                                    // INFORME QUE RECOMIENDA LA APROBACION DEL PGMF
                                    vm.NUMERO_RECOMIENDA_PGMF = dr["NUMERO_RECOMIENDA_PGMF"].ToString();
                                    vm.FECHA_RECOMIENDA_PGMF = dr["FECHA_RECOMIENDA_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_RECOMIENDA_PGMF"]);
                                    vm.COD_CONSULTOR_PGMF = dr["COD_CONSULTOR_PGMF"].ToString();
                                    vm.CONSULTOR_PGMF = dr["CONSULTOR_PGMF"].ToString();

                                    //RESOLUCION DE APROBACION DEL PGMF
                                    vm.NUMERO_PGMF = dr["NUMERO_PGMF"].ToString();
                                    vm.FECHA_RESOLUCION_PGMF = dr["FECHA_RESOLUCION_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_RESOLUCION_PGMF"]);
                                    vm.FECHA_INICIO_PGMF = dr["FECHA_INICIO_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_INICIO_PGMF"]);
                                    vm.FECHA_FIN_PGMF = dr["FECHA_FIN_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_FIN_PGMF"]);
                                    vm.AREA_PGMF = Convert.ToDecimal(dr["AREA_PGMF"]);

                                    result.Add(vm);
                                }

                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VM_INFORME_DIGITAL> ObtenerAntecedentesNoMaderable(string COD_INFORME, string COD_THABILITANTE, ref List<VM_CARTA_NOTIFICACION_ANTECEDENTE> NOTIFICACIONES_SITD, ref List<VM_DOCUMENTO_ANTECEDENTE> DOCUMENTOS_SITD, ref List<VM_INFORME_SUSPENSION> LIST_INFORME_SUSPENSION)
        {
            VM_INFORME_DIGITAL vm = null;
            VM_CARTA_NOTIFICACION_ANTECEDENTE notificacionSITD = null;
            VM_DOCUMENTO_ANTECEDENTE documentoSITD = null;
            VM_INFORME_SUSPENSION informeSuspension = null;
            OracleTransaction tr = null;
            List<VM_INFORME_DIGITAL> result = new List<VM_INFORME_DIGITAL>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (OracleDataReader dr = dBOracle.SelDrdDefaultTR(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_INFORMEDIGITALANTECEDENTENOMADERABLE_OBTENER", COD_INFORME, COD_THABILITANTE))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_INFORME_DIGITAL();
                                    vm.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    vm.COD_MTIPO = dr["COD_MTIPO"].ToString();
                                    vm.MODALIDAD_TIPO = dr["MODALIDAD_TIPO"].ToString();
                                    vm.CONTRATO_TH_FECHA_INICIO = dr["CONTRATO_TH_FECHA_INICIO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_INICIO"]);
                                    vm.CONTRATO_TH_FECHA_FIN = dr["CONTRATO_TH_FECHA_FIN"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_FIN"]);
                                    vm.TITULAR_SUPERVISADO = dr["TITULAR_SUPERVISADO"].ToString();
                                    vm.TITULAR_TIPO_DOC = dr["TITULAR_TIPO_DOC"].ToString();
                                    vm.DOCUMENTO_TITULAR = dr["DOCUMENTO_TITULAR"].ToString();
                                    vm.REPRESENTANTE_LEGAL = dr["REPRESENTANTE_LEGAL"].ToString();
                                    vm.RLEGAL_TIPO_DOC = dr["RLEGAL_TIPO_DOC"].ToString();
                                    vm.DOCUMENTO_RLEGAL = dr["DOCUMENTO_RLEGAL"].ToString();
                                    vm.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    vm.UBIGEO_THABILITANTE = dr["UBIGEO_THABILITANTE"].ToString();
                                    vm.RUC_TITULAR = dr["RUC_TITULAR"].ToString();
                                    vm.DIRECCION_LEGAL = dr["DIRECCION_LEGAL"].ToString();
                                    vm.TELEFONO_TITULAR = dr["TELEFONO_TITULAR"].ToString();
                                    vm.AREA_THABILITANTE = Convert.ToDecimal(dr["AREA_THABILITANTE"]);


                                    //Informe Técnico de Inspección Ocular
                                    vm.PROFESIONAL_IOCULAR_POA = dr["PROFESIONAL_IOCULAR_POA"].ToString();
                                    vm.ITECNICO_IOCULAR_NUM = dr["ITECNICO_IOCULAR_NUM"].ToString();
                                    vm.ITECNICO_RAPROBACION_FECHA = dr["ITECNICO_RAPROBACION_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_RAPROBACION_FECHA"]);
                                    //INFORME QUE RECOMIENDA LA APROBACION DEL PLAN DE MANEJO
                                    vm.ITECNICO_RAPROBACION_PROFESIONAL = dr["ITECNICO_RAPROBACION_PROFESIONAL"].ToString();
                                    vm.ITECNICO_RAPROBACION_NUM = dr["ITECNICO_RAPROBACION_NUM"].ToString();
                                    vm.ITECNICO_IOCULAR_FECHA = dr["ITECNICO_IOCULAR_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_IOCULAR_FECHA"]);
                                    //RESOLUCION DE APROBACION DEL PLAN DE MANEJO   --POA / PO PMFI DEMA
                                    vm.OPORTUNIDAD_POA = dr["OPORTUNIDAD_POA"].ToString();
                                    vm.TIPO_POA = dr["TIPO_POA"].ToString();
                                    vm.COD_TIPO_POA = dr["COD_TIPO_POA"].ToString();
                                    vm.NOMBRE_POA = dr["NOMBRE_POA"].ToString();
                                    vm.NOMBRE_POA_PRINCIPAL = dr["NOMBRE_POA_PRINCIPAL"].ToString();
                                    vm.NUM_POA_PRINCIPAL = Convert.ToInt32(dr["NUM_POA_PRINCIPAL"]);
                                    vm.AREA_POA = Convert.ToDecimal(dr["AREA_POA"]);
                                    vm.NUM_POA = Convert.ToInt32(dr["NUM_POA"]);
                                    vm.PCA_POA = dr["PCA_POA"].ToString();
                                    vm.RESOLUCION_POA = dr["RESOLUCION_POA"].ToString();
                                    vm.FECHA_INICIO_VIGENCIA_POA = dr["FECHA_INICIO_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_INICIO_VIGENCIA_POA"]);
                                    vm.FECHA_FIN_VIGENCIA_POA = dr["FECHA_FIN_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_FIN_VIGENCIA_POA"]);
                                    vm.RESOLUCION_POA_FECHA = dr["RESOLUCION_POA_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["RESOLUCION_POA_FECHA"]);
                                    vm.REGENTE_POA = dr["REGENTE_POA"].ToString();
                                    vm.LICENCIA_REGENCIA_POA = dr["LICENCIA_REGENCIA_POA"].ToString();
                                    vm.TELEFONO_REGENTE_POA = dr["TELEFONO_REGENTE_POA"].ToString();
                                    vm.CORREO_REGENTE_POA = dr["CORREO_REGENTE_POA"].ToString();
                                    vm.FUNCIONARIO_APROBACION_POA = dr["FUNCIONARIO_APROBACION_POA"].ToString();
                                    // INFORME QUE RECOMIENDA LA APROBACION DEL PGMF
                                    vm.NUMERO_RECOMIENDA_PGMF = dr["NUMERO_RECOMIENDA_PGMF"].ToString();
                                    vm.FECHA_RECOMIENDA_PGMF = dr["FECHA_RECOMIENDA_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_RECOMIENDA_PGMF"]);
                                    vm.COD_CONSULTOR_PGMF = dr["COD_CONSULTOR_PGMF"].ToString();
                                    vm.CONSULTOR_PGMF = dr["CONSULTOR_PGMF"].ToString();

                                    //RESOLUCION DE APROBACION DEL PGMF
                                    vm.NUMERO_PGMF = dr["NUMERO_PGMF"].ToString();
                                    vm.FECHA_RESOLUCION_PGMF = dr["FECHA_RESOLUCION_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_RESOLUCION_PGMF"]);
                                    vm.FECHA_INICIO_PGMF = dr["FECHA_INICIO_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_INICIO_PGMF"]);
                                    vm.FECHA_FIN_PGMF = dr["FECHA_FIN_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_FIN_PGMF"]);
                                    vm.AREA_PGMF = Convert.ToDecimal(dr["AREA_PGMF"]);

                                    vm.ACTA_IOCULAR_NUM = dr["ACTA_IOCULAR_NUM"].ToString();
                                    vm.ACTA_SIN_INS_OCULAR = Convert.ToInt32(dr["ACTA_SIN_INS_OCULAR"]);
                                    vm.ACTA_IOCULAR_FECHA = dr["ACTA_IOCULAR_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ACTA_IOCULAR_FECHA"]);
                                    vm.ACTA_PROFESIONAL_IOCULAR_POA = dr["ACTA_PROFESIONAL_IOCULAR_POA"].ToString();

                                    vm.DEPENDENCIA= dr["DEPENDENCIA"].ToString();
                                    result.Add(vm);
                                }
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        notificacionSITD = new VM_CARTA_NOTIFICACION_ANTECEDENTE();
                                        notificacionSITD.tabDetalle = dr["TAB_DETALLE"].ToString();
                                        notificacionSITD.tipoCarta = dr["TIPO_CARTA"].ToString();
                                        notificacionSITD.nroCartaNotificacion = dr["NRO_CARTA_NOTIFICACION"].ToString();
                                        notificacionSITD.fechaEmision = dr["FECHA_EMISION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_EMISION"]);
                                        notificacionSITD.nombreRegente = dr["NOMBRE_REGENTE"].ToString();
                                        notificacionSITD.nombrePlanManejo = dr["NOMBRE_POA"].ToString();
                                        notificacionSITD.resolucionPlanManejo = dr["ARESOLUCION_NUM"].ToString();
                                        notificacionSITD.fechaNotificacion = dr["FECHA_NOTIFICACION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_NOTIFICACION"]);
                                        notificacionSITD.personaNotificacion = dr["PERSONA_NOTIFICADA"].ToString();
                                        notificacionSITD.parentescoPerNotificacion = dr["PARENTESCO_NOTIFICADO"].ToString();
                                        //NOTIFICACIONES_SITD.Add(notificacionSITD);
                                    }

                                }
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        documentoSITD = new VM_DOCUMENTO_ANTECEDENTE();
                                        documentoSITD.tipoDocumento = dr["TIPO_DE_DOCUMENTO"].ToString();
                                        documentoSITD.nroDocumento = dr["cNroDocumento"].ToString();
                                        documentoSITD.fechaRecepcion = dr["FECHA_RECEPCION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_RECEPCION"]);
                                        documentoSITD.remitente = dr["REMITENTE"].ToString();
                                        documentoSITD.tipoDocumentoRemitido = dr["TIPO_DOCUMENTO_REMITIDO"].ToString();
                                        documentoSITD.nroResolucionAprobacion = dr["NRO_RESOLUCION_APROBACION"].ToString();
                                        //DOCUMENTOS_SITD.Add(documentoSITD);
                                    }
                                }
                                //  Mostrando informe de suspensión en el caso que existiera
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        informeSuspension = new VM_INFORME_SUSPENSION();
                                        informeSuspension.nroInforme = dr["NUMERO"].ToString();
                                        informeSuspension.fechaCreacionInforme = dr["FECHA_CREACION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_CREACION"]);
                                        informeSuspension.nroCartaNotificacion = dr["CNOTIFICACION"].ToString();
                                        informeSuspension.fechaCartaNotificacion = dr["FECHA_CARTA_NOTIFICACION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_CARTA_NOTIFICACION"]);
                                        informeSuspension.motivoSuspension = dr["MOTIVO"].ToString();
                                        LIST_INFORME_SUSPENSION.Add(informeSuspension);
                                    }
                                }
                            }
                        }
                    }
                    tr.Commit();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region "No maderable (Ecoturismo, Conservación)"
        public List<VM_INFORME_DIGITAL> ObtenerCabeceraNoMaderableEC(string COD_INFORME)
        {
            VM_INFORME_DIGITAL vm = null;
            List<VM_INFORME_DIGITAL> result = new List<VM_INFORME_DIGITAL>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_INFORMEDIGITALCABECERANOMADERABLE_EC_OBTENER", COD_INFORME))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_INFORME_DIGITAL();
                                    vm.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    vm.COD_MTIPO = dr["COD_MTIPO"].ToString();
                                    vm.MODALIDAD_TIPO = dr["MODALIDAD_TIPO"].ToString();
                                    vm.CONTRATO_TH_FECHA_INICIO = dr["CONTRATO_TH_FECHA_INICIO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_INICIO"]);
                                    vm.CONTRATO_TH_FECHA_FIN = dr["CONTRATO_TH_FECHA_FIN"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_FIN"]);
                                    vm.TITULAR_SUPERVISADO = dr["TITULAR_SUPERVISADO"].ToString();
                                    vm.TITULAR_TIPO_DOC = dr["TITULAR_TIPO_DOC"].ToString();
                                    vm.RUC_TITULAR = dr["RUC_TITULAR"].ToString();
                                    vm.DOCUMENTO_TITULAR = dr["DOCUMENTO_TITULAR"].ToString();
                                    vm.REPRESENTANTE_LEGAL = dr["REPRESENTANTE_LEGAL"].ToString();
                                    vm.RLEGAL_TIPO_DOC = dr["RLEGAL_TIPO_DOC"].ToString();
                                    vm.DOCUMENTO_RLEGAL = dr["DOCUMENTO_RLEGAL"].ToString();
                                    vm.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    vm.UBIGEO_THABILITANTE = dr["UBIGEO_THABILITANTE"].ToString();

                                    vm.DIRECCION_LEGAL = dr["DIRECCION_LEGAL"].ToString();
                                    vm.TELEFONO_TITULAR = dr["TELEFONO_TITULAR"].ToString();
                                    vm.AREA_THABILITANTE = Convert.ToDecimal(dr["AREA_THABILITANTE"]);

                                    vm.TIPO_POA = dr["TIPO_POA"].ToString();

                                    vm.FECHA_INICIO_VIGENCIA_POA = dr["FECHA_INICIO_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_INICIO_VIGENCIA_POA"]);
                                    vm.FECHA_FIN_VIGENCIA_POA = dr["FECHA_FIN_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_FIN_VIGENCIA_POA"]);

                                    vm.FECHA_PRESENTACION_POA = dr["FECHA_PRESENTACION_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_PRESENTACION_POA"]);

                                    vm.FECHA_SUPERVISION_INICIO = dr["FECHA_SUPERVISION_INICIO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_SUPERVISION_INICIO"]);
                                    vm.FECHA_SUPERVISION_FIN = dr["FECHA_SUPERVISION_FIN"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_SUPERVISION_FIN"]);

                                    vm.CONSULTOR_PGMF = dr["CONSULTOR_PGMF"].ToString();

                                    //Informe Técnico de Inspección Ocular
                                    vm.ITECNICO_IOCULAR_NUM = dr["ITECNICO_IOCULAR_NUM"].ToString();
                                    vm.ITECNICO_IOCULAR_FECHA = dr["ITECNICO_IOCULAR_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_IOCULAR_FECHA"]);
                                    vm.PROFESIONAL_IOCULAR_POA = dr["PROFESIONAL_IOCULAR_POA"].ToString();


                                    //INFORME QUE RECOMIENDA LA APROBACION DEL PLAN DE MANEJO
                                    vm.ITECNICO_RAPROBACION_NUM = dr["ITECNICO_RAPROBACION_NUM"].ToString();
                                    vm.ITECNICO_RAPROBACION_FECHA = dr["ITECNICO_RAPROBACION_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_RAPROBACION_FECHA"]);
                                    vm.ITECNICO_RAPROBACION_PROFESIONAL = dr["ITECNICO_RAPROBACION_PROFESIONAL"].ToString();

                                    //RESOLUCION DE APROBACION DEL PLAN DE MANEJO   
                                    vm.RESOLUCION_POA = dr["RESOLUCION_POA"].ToString();
                                    vm.RESOLUCION_POA_FECHA = dr["RESOLUCION_POA_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["RESOLUCION_POA_FECHA"]);
                                    vm.FUNCIONARIO_APROBACION_POA = dr["FUNCIONARIO_APROBACION_POA"].ToString();
                                    vm.AREA_POA = 0;
                                    result.Add(vm);
                                }

                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VM_INFORME_DIGITAL> ObtenerAntecedentesNoMaderableEC(string COD_INFORME, string COD_THABILITANTE, ref List<VM_CARTA_NOTIFICACION_ANTECEDENTE> NOTIFICACIONES_SITD, ref List<VM_DOCUMENTO_ANTECEDENTE> DOCUMENTOS_SITD, ref List<VM_INFORME_SUSPENSION> LIST_INFORME_SUSPENSION)
        {
            VM_INFORME_DIGITAL vm = null;
            VM_CARTA_NOTIFICACION_ANTECEDENTE notificacionSITD = null;
            VM_DOCUMENTO_ANTECEDENTE documentoSITD = null;
            VM_INFORME_SUSPENSION informeSuspension = null;
            OracleTransaction tr = null;
            List<VM_INFORME_DIGITAL> result = new List<VM_INFORME_DIGITAL>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (OracleDataReader dr = dBOracle.SelDrdDefaultTR(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_INFORMEDIGITALANTECEDENTENOMADERABLE_EC_OBTENER", COD_INFORME, COD_THABILITANTE))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_INFORME_DIGITAL();
                                    vm.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    vm.COD_MTIPO = dr["COD_MTIPO"].ToString();
                                    vm.MODALIDAD_TIPO = dr["MODALIDAD_TIPO"].ToString();
                                    vm.CONTRATO_TH_FECHA_INICIO = dr["CONTRATO_TH_FECHA_INICIO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_INICIO"]);
                                    vm.CONTRATO_TH_FECHA_FIN = dr["CONTRATO_TH_FECHA_FIN"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_FIN"]);
                                    vm.TITULAR_SUPERVISADO = dr["TITULAR_SUPERVISADO"].ToString();
                                    vm.TITULAR_TIPO_DOC = dr["TITULAR_TIPO_DOC"].ToString();
                                    vm.RUC_TITULAR = dr["RUC_TITULAR"].ToString();
                                    vm.DOCUMENTO_TITULAR = dr["DOCUMENTO_TITULAR"].ToString();
                                    vm.REPRESENTANTE_LEGAL = dr["REPRESENTANTE_LEGAL"].ToString();
                                    vm.RLEGAL_TIPO_DOC = dr["RLEGAL_TIPO_DOC"].ToString();
                                    vm.DOCUMENTO_RLEGAL = dr["DOCUMENTO_RLEGAL"].ToString();
                                    vm.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    vm.UBIGEO_THABILITANTE = dr["UBIGEO_THABILITANTE"].ToString();

                                    vm.DIRECCION_LEGAL = dr["DIRECCION_LEGAL"].ToString();
                                    vm.TELEFONO_TITULAR = dr["TELEFONO_TITULAR"].ToString();
                                    vm.AREA_THABILITANTE = Convert.ToDecimal(dr["AREA_THABILITANTE"]);

                                    vm.TIPO_POA = dr["TIPO_POA"].ToString();

                                    vm.FECHA_INICIO_VIGENCIA_POA = dr["FECHA_INICIO_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_INICIO_VIGENCIA_POA"]);
                                    vm.FECHA_FIN_VIGENCIA_POA = dr["FECHA_FIN_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_FIN_VIGENCIA_POA"]);

                                    vm.FECHA_PRESENTACION_POA = dr["FECHA_PRESENTACION_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_PRESENTACION_POA"]);

                                    vm.FECHA_SUPERVISION_INICIO = dr["FECHA_SUPERVISION_INICIO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_SUPERVISION_INICIO"]);
                                    vm.FECHA_SUPERVISION_FIN = dr["FECHA_SUPERVISION_FIN"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_SUPERVISION_FIN"]);

                                    vm.CONSULTOR_PGMF = dr["CONSULTOR_PGMF"].ToString();

                                    //Informe Técnico de Inspección Ocular
                                    vm.ITECNICO_IOCULAR_NUM = dr["ITECNICO_IOCULAR_NUM"].ToString();
                                    vm.ITECNICO_IOCULAR_FECHA = dr["ITECNICO_IOCULAR_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_IOCULAR_FECHA"]);
                                    vm.PROFESIONAL_IOCULAR_POA = dr["PROFESIONAL_IOCULAR_POA"].ToString();


                                    //INFORME QUE RECOMIENDA LA APROBACION DEL PLAN DE MANEJO
                                    vm.ITECNICO_RAPROBACION_NUM = dr["ITECNICO_RAPROBACION_NUM"].ToString();
                                    vm.ITECNICO_RAPROBACION_FECHA = dr["ITECNICO_RAPROBACION_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_RAPROBACION_FECHA"]);
                                    vm.ITECNICO_RAPROBACION_PROFESIONAL = dr["ITECNICO_RAPROBACION_PROFESIONAL"].ToString();

                                    //RESOLUCION DE APROBACION DEL PLAN DE MANEJO   
                                    vm.RESOLUCION_POA = dr["RESOLUCION_POA"].ToString();
                                    vm.RESOLUCION_POA_FECHA = dr["RESOLUCION_POA_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["RESOLUCION_POA_FECHA"]);
                                    vm.FUNCIONARIO_APROBACION_POA = dr["FUNCIONARIO_APROBACION_POA"].ToString();
                                    vm.AREA_POA = 0;

                                    result.Add(vm);
                                }
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        notificacionSITD = new VM_CARTA_NOTIFICACION_ANTECEDENTE();
                                        notificacionSITD.tabDetalle = dr["TAB_DETALLE"].ToString();
                                        notificacionSITD.tipoCarta = dr["TIPO_CARTA"].ToString();
                                        notificacionSITD.nroCartaNotificacion = dr["NRO_CARTA_NOTIFICACION"].ToString();
                                        notificacionSITD.fechaEmision = dr["FECHA_EMISION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_EMISION"]);
                                        notificacionSITD.nombreRegente = dr["NOMBRE_REGENTE"].ToString();
                                        notificacionSITD.nombrePlanManejo = dr["NOMBRE_POA"].ToString();
                                        notificacionSITD.resolucionPlanManejo = dr["ARESOLUCION_NUM"].ToString();
                                        notificacionSITD.fechaNotificacion = dr["FECHA_NOTIFICACION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_NOTIFICACION"]);
                                        notificacionSITD.personaNotificacion = dr["PERSONA_NOTIFICADA"].ToString();
                                        notificacionSITD.parentescoPerNotificacion = dr["PARENTESCO_NOTIFICADO"].ToString();
                                        //NOTIFICACIONES_SITD.Add(notificacionSITD);
                                    }

                                }
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        documentoSITD = new VM_DOCUMENTO_ANTECEDENTE();
                                        documentoSITD.tipoDocumento = dr["TIPO_DE_DOCUMENTO"].ToString();
                                        documentoSITD.nroDocumento = dr["cNroDocumento"].ToString();
                                        documentoSITD.fechaRecepcion = dr["FECHA_RECEPCION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_RECEPCION"]);
                                        documentoSITD.remitente = dr["REMITENTE"].ToString();
                                        documentoSITD.tipoDocumentoRemitido = dr["TIPO_DOCUMENTO_REMITIDO"].ToString();
                                        documentoSITD.nroResolucionAprobacion = dr["NRO_RESOLUCION_APROBACION"].ToString();
                                        //DOCUMENTOS_SITD.Add(documentoSITD);
                                    }
                                }
                                //  Mostrando informe de suspensión en el caso que existiera
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        informeSuspension = new VM_INFORME_SUSPENSION();
                                        informeSuspension.nroInforme = dr["NUMERO"].ToString();
                                        informeSuspension.fechaCreacionInforme = dr["FECHA_CREACION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_CREACION"]);
                                        informeSuspension.nroCartaNotificacion = dr["CNOTIFICACION"].ToString();
                                        informeSuspension.fechaCartaNotificacion = dr["FECHA_CARTA_NOTIFICACION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_CARTA_NOTIFICACION"]);
                                        informeSuspension.motivoSuspension = dr["MOTIVO"].ToString();
                                        LIST_INFORME_SUSPENSION.Add(informeSuspension);
                                    }
                                }
                            }
                        }
                    }
                    tr.Commit();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region "Fauna"
        public List<VM_INFORME_DIGITAL> ObtenerCabeceraFauna(string COD_INFORME)
        {
            VM_INFORME_DIGITAL vm = null;
            List<VM_INFORME_DIGITAL> result = new List<VM_INFORME_DIGITAL>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_INFORMEDIGITALCABECERA_FAUNA_OBTENER", COD_INFORME))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_INFORME_DIGITAL();
                                    vm.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    vm.COD_MTIPO = dr["COD_MTIPO"].ToString();
                                    vm.MODALIDAD_TIPO = dr["MODALIDAD_TIPO"].ToString();
                                    vm.CONTRATO_TH_FECHA_INICIO = dr["CONTRATO_TH_FECHA_INICIO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_INICIO"]);
                                    vm.CONTRATO_TH_FECHA_FIN = dr["CONTRATO_TH_FECHA_FIN"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_FIN"]);
                                    vm.TITULAR_SUPERVISADO = dr["TITULAR_SUPERVISADO"].ToString();
                                    vm.TITULAR_TIPO_DOC = dr["TITULAR_TIPO_DOC"].ToString();
                                    vm.RUC_TITULAR = dr["RUC_TITULAR"].ToString();
                                    vm.DOCUMENTO_TITULAR = dr["DOCUMENTO_TITULAR"].ToString();
                                    vm.REPRESENTANTE_LEGAL = dr["REPRESENTANTE_LEGAL"].ToString();
                                    vm.RLEGAL_TIPO_DOC = dr["RLEGAL_TIPO_DOC"].ToString();
                                    vm.DOCUMENTO_RLEGAL = dr["DOCUMENTO_RLEGAL"].ToString();
                                    vm.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    vm.UBIGEO_THABILITANTE = dr["UBIGEO_THABILITANTE"].ToString();

                                    vm.DIRECCION_LEGAL = dr["DIRECCION_LEGAL"].ToString();
                                    vm.SECTOR = dr["ESTAB_SECTOR"].ToString();
                                    vm.TELEFONO_TITULAR = dr["TELEFONO_TITULAR"].ToString();
                                    vm.AREA_THABILITANTE = Convert.ToDecimal(dr["AREA_THABILITANTE"]);

                                    vm.TIPO_POA = dr["TIPO_POA"].ToString();

                                    vm.FECHA_INICIO_VIGENCIA_POA = dr["FECHA_INICIO_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_INICIO_VIGENCIA_POA"]);
                                    vm.FECHA_FIN_VIGENCIA_POA = dr["FECHA_FIN_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_FIN_VIGENCIA_POA"]);

                                  //  vm.FECHA_PRESENTACION_POA = dr["FECHA_PRESENTACION_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_PRESENTACION_POA"]);

                                    vm.FECHA_SUPERVISION_INICIO = dr["FECHA_SUPERVISION_INICIO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_SUPERVISION_INICIO"]);
                                    vm.FECHA_SUPERVISION_FIN = dr["FECHA_SUPERVISION_FIN"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_SUPERVISION_FIN"]);

                                    vm.REGENTE_POA = dr["REGENTE_POA"].ToString();
                                    vm.REGENTE_REGISTRO_PROFESIONAL = dr["REGENTE_REGISTRO_PROFESIONAL"].ToString();
                                    vm.REGENTE_REGISTRO = dr["REGENTE_REGISTRO"].ToString();

                                    vm.R_PROYECTO_AUTORIZA_FECHA = dr["R_PROYECTO_AUTORIZA_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["R_PROYECTO_AUTORIZA_FECHA"]);
                                    vm.R_PROYECTO_AUTORIZA = dr["R_PROYECTO_AUTORIZA"].ToString();
                                    vm.R_PROYECTO_AUTORIZA_PERSONA = dr["R_PROYECTO_AUTORIZA_PERSONA"].ToString();
                                    vm.R_PROYECTO_APRUEBA_FECHA = dr["R_PROYECTO_APRUEBA_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["R_PROYECTO_APRUEBA_FECHA"]);
                                    vm.R_PROYECTO_APRUEBA = dr["R_PROYECTO_APRUEBA"].ToString();
                                    vm.R_PROYECTO_APRUEBA_PERSONA = dr["R_PROYECTO_APRUEBA_PERSONA"].ToString();
                                    //Informe Técnico de Inspección Ocular
                                    vm.ITECNICO_IOCULAR_NUM = dr["ITECNICO_IOCULAR_NUM"].ToString();
                                    vm.ITECNICO_IOCULAR_FECHA = dr["ITECNICO_IOCULAR_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_IOCULAR_FECHA"]);
                                    vm.PROFESIONAL_IOCULAR_POA = dr["PROFESIONAL_IOCULAR_POA"].ToString();


                                    //INFORME QUE RECOMIENDA LA APROBACION DEL PLAN DE MANEJO
                                    vm.ITECNICO_RAPROBACION_NUM = dr["ITECNICO_RAPROBACION_NUM"].ToString();
                                    vm.ITECNICO_RAPROBACION_FECHA = dr["ITECNICO_RAPROBACION_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_RAPROBACION_FECHA"]);
                                    vm.ITECNICO_RAPROBACION_PROFESIONAL = dr["ITECNICO_RAPROBACION_PROFESIONAL"].ToString();

                                    //RESOLUCION DE APROBACION DEL PLAN DE MANEJO   
                                    vm.RESOLUCION_POA = dr["RESOLUCION_POA"].ToString();
                                    vm.RESOLUCION_POA_FECHA = dr["RESOLUCION_POA_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["RESOLUCION_POA_FECHA"]);
                                    vm.FUNCIONARIO_APROBACION_POA = dr["FUNCIONARIO_APROBACION_POA"].ToString();
                                    vm.AREA_POA = 0;
                                    result.Add(vm);
                                }

                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VM_INFORME_DIGITAL> ObtenerAntecedentesFauna(string COD_INFORME, string COD_THABILITANTE, ref List<VM_CARTA_NOTIFICACION_ANTECEDENTE> NOTIFICACIONES_SITD, ref List<VM_DOCUMENTO_ANTECEDENTE> DOCUMENTOS_SITD, ref List<VM_INFORME_SUSPENSION> LIST_INFORME_SUSPENSION)
        {
            VM_INFORME_DIGITAL vm = null;
            VM_CARTA_NOTIFICACION_ANTECEDENTE notificacionSITD = null;
            VM_DOCUMENTO_ANTECEDENTE documentoSITD = null;
            VM_INFORME_SUSPENSION informeSuspension = null;
            OracleTransaction tr = null;
            List<VM_INFORME_DIGITAL> result = new List<VM_INFORME_DIGITAL>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (OracleDataReader dr = dBOracle.SelDrdDefaultTR(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_INFORMEDIGITALANTECEDENTE_FAUNA_OBTENER", COD_INFORME, COD_THABILITANTE))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_INFORME_DIGITAL();
                                    vm.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    vm.COD_MTIPO = dr["COD_MTIPO"].ToString();
                                    vm.MODALIDAD_TIPO = dr["MODALIDAD_TIPO"].ToString();
                                    vm.CONTRATO_TH_FECHA_INICIO = dr["CONTRATO_TH_FECHA_INICIO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_INICIO"]);
                                    vm.CONTRATO_TH_FECHA_FIN = dr["CONTRATO_TH_FECHA_FIN"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_FIN"]);
                                    vm.TITULAR_SUPERVISADO = dr["TITULAR_SUPERVISADO"].ToString();
                                    vm.TITULAR_TIPO_DOC = dr["TITULAR_TIPO_DOC"].ToString();
                                    vm.RUC_TITULAR = dr["RUC_TITULAR"].ToString();
                                    vm.DOCUMENTO_TITULAR = dr["DOCUMENTO_TITULAR"].ToString();
                                    vm.REPRESENTANTE_LEGAL = dr["REPRESENTANTE_LEGAL"].ToString();
                                    vm.RLEGAL_TIPO_DOC = dr["RLEGAL_TIPO_DOC"].ToString();
                                    vm.DOCUMENTO_RLEGAL = dr["DOCUMENTO_RLEGAL"].ToString();
                                    vm.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    vm.UBIGEO_THABILITANTE = dr["UBIGEO_THABILITANTE"].ToString();
                                    vm.SECTOR = dr["ESTAB_SECTOR"].ToString();
                                    vm.DIRECCION_LEGAL = dr["DIRECCION_LEGAL"].ToString();
                                    vm.TELEFONO_TITULAR = dr["TELEFONO_TITULAR"].ToString();
                                    vm.AREA_THABILITANTE = Convert.ToDecimal(dr["AREA_THABILITANTE"]);

                                    vm.TIPO_POA = dr["TIPO_POA"].ToString();

                                    vm.FECHA_INICIO_VIGENCIA_POA = dr["FECHA_INICIO_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_INICIO_VIGENCIA_POA"]);
                                    vm.FECHA_FIN_VIGENCIA_POA = dr["FECHA_FIN_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_FIN_VIGENCIA_POA"]);

                                   // vm.FECHA_PRESENTACION_POA = dr["FECHA_PRESENTACION_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_PRESENTACION_POA"]);

                                    vm.FECHA_SUPERVISION_INICIO = dr["FECHA_SUPERVISION_INICIO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_SUPERVISION_INICIO"]);
                                    vm.FECHA_SUPERVISION_FIN = dr["FECHA_SUPERVISION_FIN"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_SUPERVISION_FIN"]);

                                    vm.REGENTE_POA = dr["REGENTE_POA"].ToString();
                                    vm.REGENTE_REGISTRO_PROFESIONAL = dr["REGENTE_REGISTRO_PROFESIONAL"].ToString();
                                    vm.REGENTE_REGISTRO = dr["REGENTE_REGISTRO"].ToString();

                                    vm.R_PROYECTO_AUTORIZA_FECHA = dr["R_PROYECTO_AUTORIZA_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["R_PROYECTO_AUTORIZA_FECHA"]);
                                    vm.R_PROYECTO_AUTORIZA = dr["R_PROYECTO_AUTORIZA"].ToString();
                                    vm.R_PROYECTO_AUTORIZA_PERSONA = dr["R_PROYECTO_AUTORIZA_PERSONA"].ToString();
                                    vm.R_PROYECTO_APRUEBA_FECHA = dr["R_PROYECTO_APRUEBA_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["R_PROYECTO_APRUEBA_FECHA"]);
                                    vm.R_PROYECTO_APRUEBA = dr["R_PROYECTO_APRUEBA"].ToString();
                                    vm.R_PROYECTO_APRUEBA_PERSONA = dr["R_PROYECTO_APRUEBA_PERSONA"].ToString();
                                    //Informe Técnico de Inspección Ocular
                                    vm.ITECNICO_IOCULAR_NUM = dr["ITECNICO_IOCULAR_NUM"].ToString();
                                    vm.ITECNICO_IOCULAR_FECHA = dr["ITECNICO_IOCULAR_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_IOCULAR_FECHA"]);
                                    vm.PROFESIONAL_IOCULAR_POA = dr["PROFESIONAL_IOCULAR_POA"].ToString();


                                    //INFORME QUE RECOMIENDA LA APROBACION DEL PLAN DE MANEJO
                                    vm.ITECNICO_RAPROBACION_NUM = dr["ITECNICO_RAPROBACION_NUM"].ToString();
                                    vm.ITECNICO_RAPROBACION_FECHA = dr["ITECNICO_RAPROBACION_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_RAPROBACION_FECHA"]);
                                    vm.ITECNICO_RAPROBACION_PROFESIONAL = dr["ITECNICO_RAPROBACION_PROFESIONAL"].ToString();

                                    //RESOLUCION DE APROBACION DEL PLAN DE MANEJO   
                                    vm.RESOLUCION_POA = dr["RESOLUCION_POA"].ToString();
                                    vm.RESOLUCION_POA_FECHA = dr["RESOLUCION_POA_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["RESOLUCION_POA_FECHA"]);
                                    vm.FUNCIONARIO_APROBACION_POA = dr["FUNCIONARIO_APROBACION_POA"].ToString();
                                    vm.AREA_POA = 0;

                                    result.Add(vm);
                                }
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        notificacionSITD = new VM_CARTA_NOTIFICACION_ANTECEDENTE();
                                        notificacionSITD.tabDetalle = dr["TAB_DETALLE"].ToString();
                                        notificacionSITD.tipoCarta = dr["TIPO_CARTA"].ToString();
                                        notificacionSITD.nroCartaNotificacion = dr["NRO_CARTA_NOTIFICACION"].ToString();
                                        notificacionSITD.fechaEmision = dr["FECHA_EMISION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_EMISION"]);
                                        notificacionSITD.nombreRegente = dr["NOMBRE_REGENTE"].ToString();
                                        notificacionSITD.nombrePlanManejo = dr["NOMBRE_POA"].ToString();
                                        notificacionSITD.resolucionPlanManejo = dr["ARESOLUCION_NUM"].ToString();
                                        notificacionSITD.fechaNotificacion = dr["FECHA_NOTIFICACION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_NOTIFICACION"]);
                                        notificacionSITD.personaNotificacion = dr["PERSONA_NOTIFICADA"].ToString();
                                        notificacionSITD.parentescoPerNotificacion = dr["PARENTESCO_NOTIFICADO"].ToString();
                                        //NOTIFICACIONES_SITD.Add(notificacionSITD);
                                    }

                                }
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        documentoSITD = new VM_DOCUMENTO_ANTECEDENTE();
                                        documentoSITD.tipoDocumento = dr["TIPO_DE_DOCUMENTO"].ToString();
                                        documentoSITD.nroDocumento = dr["cNroDocumento"].ToString();
                                        documentoSITD.fechaRecepcion = dr["FECHA_RECEPCION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_RECEPCION"]);
                                        documentoSITD.remitente = dr["REMITENTE"].ToString();
                                        documentoSITD.tipoDocumentoRemitido = dr["TIPO_DOCUMENTO_REMITIDO"].ToString();
                                        documentoSITD.nroResolucionAprobacion = dr["NRO_RESOLUCION_APROBACION"].ToString();
                                        //DOCUMENTOS_SITD.Add(documentoSITD);
                                    }
                                }
                                //  Mostrando informe de suspensión en el caso que existiera
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        informeSuspension = new VM_INFORME_SUSPENSION();
                                        informeSuspension.nroInforme = dr["NUMERO"].ToString();
                                        informeSuspension.fechaCreacionInforme = dr["FECHA_CREACION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_CREACION"]);
                                        informeSuspension.nroCartaNotificacion = dr["CNOTIFICACION"].ToString();
                                        informeSuspension.fechaCartaNotificacion = dr["FECHA_CARTA_NOTIFICACION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_CARTA_NOTIFICACION"]);
                                        informeSuspension.motivoSuspension = dr["MOTIVO"].ToString();
                                        LIST_INFORME_SUSPENSION.Add(informeSuspension);
                                    }
                                }
                            }
                        }
                    }
                    tr.Commit();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VM_INFORME_DIGITAL_VERTICE> ObtenerVerticeTH_Fauna(string COD_THABILITANTE)
        {
            VM_INFORME_DIGITAL_VERTICE vm = null;
            List<VM_INFORME_DIGITAL_VERTICE> result = new List<VM_INFORME_DIGITAL_VERTICE>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_INFORMEDIGITALVERTICETH_FAUNA", COD_THABILITANTE))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_INFORME_DIGITAL_VERTICE();
                                    vm.GRUPO = dr["GRUPO"].ToString();
                                    vm.VERTICE = dr["VERTICE"].ToString();
                                    vm.ZONA = dr["ZONA"].ToString();
                                    vm.COORDENADA_ESTE = Convert.ToInt32(dr["COORDENADA_ESTE"]);
                                    vm.COORDENADA_NORTE = Convert.ToInt32(dr["COORDENADA_NORTE"]);
                                    result.Add(vm);
                                }                               
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region "Concesiones Forestales - Fauna Silvestre"
        public List<VM_INFORME_DIGITAL> ObtenerCabeceraFaunaConcesiones(string COD_INFORME)
        {
            VM_INFORME_DIGITAL vm = null;
            List<VM_INFORME_DIGITAL> result = new List<VM_INFORME_DIGITAL>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_INFORMEDIGITALCABECERA_FAUNA_CONCESIONES_OBTENER", COD_INFORME))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_INFORME_DIGITAL();
                                    vm.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    vm.COD_MTIPO = dr["COD_MTIPO"].ToString();
                                    vm.MODALIDAD_TIPO = dr["MODALIDAD_TIPO"].ToString();
                                    vm.CONTRATO_TH_FECHA_INICIO = dr["CONTRATO_TH_FECHA_INICIO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_INICIO"]);
                                    vm.CONTRATO_TH_FECHA_FIN = dr["CONTRATO_TH_FECHA_FIN"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_FIN"]);
                                    vm.TITULAR_SUPERVISADO = dr["TITULAR_SUPERVISADO"].ToString();
                                    vm.TITULAR_TIPO_DOC = dr["TITULAR_TIPO_DOC"].ToString();
                                    vm.DOCUMENTO_TITULAR = dr["DOCUMENTO_TITULAR"].ToString();
                                    vm.REPRESENTANTE_LEGAL = dr["REPRESENTANTE_LEGAL"].ToString();
                                    vm.RLEGAL_TIPO_DOC = dr["RLEGAL_TIPO_DOC"].ToString();
                                    vm.DOCUMENTO_RLEGAL = dr["DOCUMENTO_RLEGAL"].ToString();
                                    vm.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    vm.UBIGEO_THABILITANTE = dr["UBIGEO_THABILITANTE"].ToString();
                                    vm.RUC_TITULAR = dr["RUC_TITULAR"].ToString();
                                    vm.DIRECCION_LEGAL = dr["DIRECCION_LEGAL"].ToString();
                                    vm.TELEFONO_TITULAR = dr["TELEFONO_TITULAR"].ToString();
                                    vm.AREA_THABILITANTE = Convert.ToDecimal(dr["AREA_THABILITANTE"]);


                                    //Informe Técnico de Inspección Ocular
                                    vm.PROFESIONAL_IOCULAR_POA = dr["PROFESIONAL_IOCULAR_POA"].ToString();
                                    vm.ITECNICO_IOCULAR_NUM = dr["ITECNICO_IOCULAR_NUM"].ToString();
                                    vm.ITECNICO_RAPROBACION_FECHA = dr["ITECNICO_RAPROBACION_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_RAPROBACION_FECHA"]);
                                    //INFORME QUE RECOMIENDA LA APROBACION DEL PLAN DE MANEJO
                                    vm.ITECNICO_RAPROBACION_PROFESIONAL = dr["ITECNICO_RAPROBACION_PROFESIONAL"].ToString();
                                    vm.ITECNICO_RAPROBACION_NUM = dr["ITECNICO_RAPROBACION_NUM"].ToString();
                                    vm.ITECNICO_IOCULAR_FECHA = dr["ITECNICO_IOCULAR_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_IOCULAR_FECHA"]);
                                    //RESOLUCION DE APROBACION DEL PLAN DE MANEJO   --POA / PO PMFI DEMA
                                    vm.OPORTUNIDAD_POA = dr["OPORTUNIDAD_POA"].ToString();
                                    vm.TIPO_POA = dr["TIPO_POA"].ToString();
                                    vm.COD_TIPO_POA = dr["COD_TIPO_POA"].ToString();
                                    vm.NOMBRE_POA = dr["NOMBRE_POA"].ToString();
                                    vm.NOMBRE_POA_PRINCIPAL = dr["NOMBRE_POA_PRINCIPAL"].ToString();
                                    vm.NUM_POA_PRINCIPAL = Convert.ToInt32(dr["NUM_POA_PRINCIPAL"]);
                                    vm.AREA_POA = Convert.ToDecimal(dr["AREA_POA"]);
                                    vm.PCA_POA = dr["PCA_POA"].ToString();
                                    vm.RESOLUCION_POA = dr["RESOLUCION_POA"].ToString();
                                    vm.FECHA_INICIO_VIGENCIA_POA = dr["FECHA_INICIO_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_INICIO_VIGENCIA_POA"]);
                                    vm.FECHA_FIN_VIGENCIA_POA = dr["FECHA_FIN_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_FIN_VIGENCIA_POA"]);
                                    vm.RESOLUCION_POA_FECHA = dr["RESOLUCION_POA_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["RESOLUCION_POA_FECHA"]);
                                    vm.REGENTE_POA = dr["REGENTE_POA"].ToString();
                                    vm.LICENCIA_REGENCIA_POA = dr["LICENCIA_REGENCIA_POA"].ToString();
                                    vm.TELEFONO_REGENTE_POA = dr["TELEFONO_REGENTE_POA"].ToString();
                                    vm.CORREO_REGENTE_POA = dr["CORREO_REGENTE_POA"].ToString();
                                    vm.FUNCIONARIO_APROBACION_POA = dr["FUNCIONARIO_APROBACION_POA"].ToString();
                                    // INFORME QUE RECOMIENDA LA APROBACION DEL PGMF
                                    vm.NUMERO_RECOMIENDA_PGMF = dr["NUMERO_RECOMIENDA_PGMF"].ToString();
                                    vm.FECHA_RECOMIENDA_PGMF = dr["FECHA_RECOMIENDA_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_RECOMIENDA_PGMF"]);
                                    vm.COD_CONSULTOR_PGMF = dr["COD_CONSULTOR_PGMF"].ToString();
                                    vm.CONSULTOR_PGMF = dr["CONSULTOR_PGMF"].ToString();

                                    //RESOLUCION DE APROBACION DEL PGMF
                                    vm.NUMERO_PGMF = dr["NUMERO_PGMF"].ToString();
                                    vm.FECHA_RESOLUCION_PGMF = dr["FECHA_RESOLUCION_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_RESOLUCION_PGMF"]);
                                    vm.FECHA_INICIO_PGMF = dr["FECHA_INICIO_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_INICIO_PGMF"]);
                                    vm.FECHA_FIN_PGMF = dr["FECHA_FIN_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_FIN_PGMF"]);
                                    vm.AREA_PGMF = Convert.ToDecimal(dr["AREA_PGMF"]);
                                    result.Add(vm);
                                }

                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VM_INFORME_DIGITAL> ObtenerAntecedentesFaunaConcesiones(string COD_INFORME, string COD_THABILITANTE, ref List<VM_CARTA_NOTIFICACION_ANTECEDENTE> NOTIFICACIONES_SITD, ref List<VM_DOCUMENTO_ANTECEDENTE> DOCUMENTOS_SITD, ref List<VM_INFORME_SUSPENSION> LIST_INFORME_SUSPENSION)
        {
            VM_INFORME_DIGITAL vm = null;
            VM_CARTA_NOTIFICACION_ANTECEDENTE notificacionSITD = null;
            VM_DOCUMENTO_ANTECEDENTE documentoSITD = null;
            VM_INFORME_SUSPENSION informeSuspension = null;
            OracleTransaction tr = null;
            List<VM_INFORME_DIGITAL> result = new List<VM_INFORME_DIGITAL>();
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    using (OracleDataReader dr = dBOracle.SelDrdDefaultTR(cn, tr, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_INFORMEDIGITALANTECEDENTE_FAUNA_CONCESIONES_OBTENER", COD_INFORME, COD_THABILITANTE))
                    {
                        if (dr != null)
                        {

                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    vm = new VM_INFORME_DIGITAL();
                                    vm.COD_THABILITANTE = dr["COD_THABILITANTE"].ToString();
                                    vm.COD_MTIPO = dr["COD_MTIPO"].ToString();
                                    vm.MODALIDAD_TIPO = dr["MODALIDAD_TIPO"].ToString();
                                    vm.CONTRATO_TH_FECHA_INICIO = dr["CONTRATO_TH_FECHA_INICIO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_INICIO"]);
                                    vm.CONTRATO_TH_FECHA_FIN = dr["CONTRATO_TH_FECHA_FIN"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["CONTRATO_TH_FECHA_FIN"]);
                                    vm.TITULAR_SUPERVISADO = dr["TITULAR_SUPERVISADO"].ToString();
                                    vm.TITULAR_TIPO_DOC = dr["TITULAR_TIPO_DOC"].ToString();
                                    vm.DOCUMENTO_TITULAR = dr["DOCUMENTO_TITULAR"].ToString();
                                    vm.REPRESENTANTE_LEGAL = dr["REPRESENTANTE_LEGAL"].ToString();
                                    vm.RLEGAL_TIPO_DOC = dr["RLEGAL_TIPO_DOC"].ToString();
                                    vm.DOCUMENTO_RLEGAL = dr["DOCUMENTO_RLEGAL"].ToString();
                                    vm.NUM_THABILITANTE = dr["NUM_THABILITANTE"].ToString();
                                    vm.UBIGEO_THABILITANTE = dr["UBIGEO_THABILITANTE"].ToString();
                                    vm.RUC_TITULAR = dr["RUC_TITULAR"].ToString();
                                    vm.DIRECCION_LEGAL = dr["DIRECCION_LEGAL"].ToString();
                                    vm.TELEFONO_TITULAR = dr["TELEFONO_TITULAR"].ToString();
                                    vm.AREA_THABILITANTE = Convert.ToDecimal(dr["AREA_THABILITANTE"]);


                                    //Informe Técnico de Inspección Ocular
                                    vm.PROFESIONAL_IOCULAR_POA = dr["PROFESIONAL_IOCULAR_POA"].ToString();
                                    vm.ITECNICO_IOCULAR_NUM = dr["ITECNICO_IOCULAR_NUM"].ToString();
                                    vm.ITECNICO_RAPROBACION_FECHA = dr["ITECNICO_RAPROBACION_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_RAPROBACION_FECHA"]);
                                    //INFORME QUE RECOMIENDA LA APROBACION DEL PLAN DE MANEJO
                                    vm.ITECNICO_RAPROBACION_PROFESIONAL = dr["ITECNICO_RAPROBACION_PROFESIONAL"].ToString();
                                    vm.ITECNICO_RAPROBACION_NUM = dr["ITECNICO_RAPROBACION_NUM"].ToString();
                                    vm.ITECNICO_IOCULAR_FECHA = dr["ITECNICO_IOCULAR_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ITECNICO_IOCULAR_FECHA"]);
                                    //RESOLUCION DE APROBACION DEL PLAN DE MANEJO   --POA / PO PMFI DEMA
                                    vm.OPORTUNIDAD_POA = dr["OPORTUNIDAD_POA"].ToString();
                                    vm.TIPO_POA = dr["TIPO_POA"].ToString();
                                    vm.COD_TIPO_POA = dr["COD_TIPO_POA"].ToString();
                                    vm.NOMBRE_POA = dr["NOMBRE_POA"].ToString();
                                    vm.NOMBRE_POA_PRINCIPAL = dr["NOMBRE_POA_PRINCIPAL"].ToString();
                                    vm.NUM_POA_PRINCIPAL = Convert.ToInt32(dr["NUM_POA_PRINCIPAL"]);
                                    vm.AREA_POA = Convert.ToDecimal(dr["AREA_POA"]);
                                    vm.NUM_POA = Convert.ToInt32(dr["NUM_POA"]);
                                    vm.PCA_POA = dr["PCA_POA"].ToString();
                                    vm.RESOLUCION_POA = dr["RESOLUCION_POA"].ToString();
                                    vm.FECHA_INICIO_VIGENCIA_POA = dr["FECHA_INICIO_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_INICIO_VIGENCIA_POA"]);
                                    vm.FECHA_FIN_VIGENCIA_POA = dr["FECHA_FIN_VIGENCIA_POA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_FIN_VIGENCIA_POA"]);
                                    vm.RESOLUCION_POA_FECHA = dr["RESOLUCION_POA_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["RESOLUCION_POA_FECHA"]);
                                    vm.REGENTE_POA = dr["REGENTE_POA"].ToString();
                                    vm.LICENCIA_REGENCIA_POA = dr["LICENCIA_REGENCIA_POA"].ToString();
                                    vm.TELEFONO_REGENTE_POA = dr["TELEFONO_REGENTE_POA"].ToString();
                                    vm.CORREO_REGENTE_POA = dr["CORREO_REGENTE_POA"].ToString();
                                    vm.FUNCIONARIO_APROBACION_POA = dr["FUNCIONARIO_APROBACION_POA"].ToString();
                                    // INFORME QUE RECOMIENDA LA APROBACION DEL PGMF
                                    vm.NUMERO_RECOMIENDA_PGMF = dr["NUMERO_RECOMIENDA_PGMF"].ToString();
                                    vm.FECHA_RECOMIENDA_PGMF = dr["FECHA_RECOMIENDA_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_RECOMIENDA_PGMF"]);
                                    vm.COD_CONSULTOR_PGMF = dr["COD_CONSULTOR_PGMF"].ToString();
                                    vm.CONSULTOR_PGMF = dr["CONSULTOR_PGMF"].ToString();

                                    //RESOLUCION DE APROBACION DEL PGMF
                                    vm.NUMERO_PGMF = dr["NUMERO_PGMF"].ToString();
                                    vm.FECHA_RESOLUCION_PGMF = dr["FECHA_RESOLUCION_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_RESOLUCION_PGMF"]);
                                    vm.FECHA_INICIO_PGMF = dr["FECHA_INICIO_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_INICIO_PGMF"]);
                                    vm.FECHA_FIN_PGMF = dr["FECHA_FIN_PGMF"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_FIN_PGMF"]);
                                    vm.AREA_PGMF = Convert.ToDecimal(dr["AREA_PGMF"]);

                                    vm.ACTA_IOCULAR_NUM = dr["ACTA_IOCULAR_NUM"].ToString();
                                    vm.ACTA_SIN_INS_OCULAR = Convert.ToInt32(dr["ACTA_SIN_INS_OCULAR"]);
                                    vm.ACTA_IOCULAR_FECHA = dr["ACTA_IOCULAR_FECHA"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["ACTA_IOCULAR_FECHA"]);
                                    vm.ACTA_PROFESIONAL_IOCULAR_POA = dr["ACTA_PROFESIONAL_IOCULAR_POA"].ToString();

                                    vm.DEPENDENCIA = dr["DEPENDENCIA"].ToString();
                                    result.Add(vm);
                                }
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        notificacionSITD = new VM_CARTA_NOTIFICACION_ANTECEDENTE();
                                        notificacionSITD.tabDetalle = dr["TAB_DETALLE"].ToString();
                                        notificacionSITD.tipoCarta = dr["TIPO_CARTA"].ToString();
                                        notificacionSITD.nroCartaNotificacion = dr["NRO_CARTA_NOTIFICACION"].ToString();
                                        notificacionSITD.fechaEmision = dr["FECHA_EMISION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_EMISION"]);
                                        notificacionSITD.nombreRegente = dr["NOMBRE_REGENTE"].ToString();
                                        notificacionSITD.nombrePlanManejo = dr["NOMBRE_POA"].ToString();
                                        notificacionSITD.resolucionPlanManejo = dr["ARESOLUCION_NUM"].ToString();
                                        notificacionSITD.fechaNotificacion = dr["FECHA_NOTIFICACION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_NOTIFICACION"]);
                                        notificacionSITD.personaNotificacion = dr["PERSONA_NOTIFICADA"].ToString();
                                        notificacionSITD.parentescoPerNotificacion = dr["PARENTESCO_NOTIFICADO"].ToString();
                                        //NOTIFICACIONES_SITD.Add(notificacionSITD);
                                    }

                                }
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        documentoSITD = new VM_DOCUMENTO_ANTECEDENTE();
                                        documentoSITD.tipoDocumento = dr["TIPO_DE_DOCUMENTO"].ToString();
                                        documentoSITD.nroDocumento = dr["cNroDocumento"].ToString();
                                        documentoSITD.fechaRecepcion = dr["FECHA_RECEPCION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_RECEPCION"]);
                                        documentoSITD.remitente = dr["REMITENTE"].ToString();
                                        documentoSITD.tipoDocumentoRemitido = dr["TIPO_DOCUMENTO_REMITIDO"].ToString();
                                        documentoSITD.nroResolucionAprobacion = dr["NRO_RESOLUCION_APROBACION"].ToString();
                                        //DOCUMENTOS_SITD.Add(documentoSITD);
                                    }
                                }
                                //  Mostrando informe de suspensión en el caso que existiera
                                dr.NextResult();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        informeSuspension = new VM_INFORME_SUSPENSION();
                                        informeSuspension.nroInforme = dr["NUMERO"].ToString();
                                        informeSuspension.fechaCreacionInforme = dr["FECHA_CREACION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_CREACION"]);
                                        informeSuspension.nroCartaNotificacion = dr["CNOTIFICACION"].ToString();
                                        informeSuspension.fechaCartaNotificacion = dr["FECHA_CARTA_NOTIFICACION"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["FECHA_CARTA_NOTIFICACION"]);
                                        informeSuspension.motivoSuspension = dr["MOTIVO"].ToString();
                                        LIST_INFORME_SUSPENSION.Add(informeSuspension);
                                    }
                                }
                            }
                        }
                    }
                    tr.Commit();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VM_ESPECIES> ObtenerEspeciesPlanManejoFaunaConcesiones(string codTH, int numPoa)
        {
            List<VM_ESPECIES>  ListEspecieApro = new List<VM_ESPECIES>();            
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    using (OracleDataReader dr = dBOracle.SelDrdDefault(cn, "DOC_OSINFOR_ERP_MIGRACION.SPSUPERVISION_INFORMEDIGITAL_ESPECIES_FS_LISTAR", codTH, numPoa))
                    {
                        if (dr != null)
                        {                            
                            if (dr.HasRows)
                            {
                                VM_ESPECIES especie = null;
                                while (dr.Read())
                                {
                                    especie = new VM_ESPECIES();
                                    especie.COD_ESPECIES = dr["COD_ESPECIES"].ToString();
                                    especie.ESPECIE = dr["ESPECIE"].ToString();                                    
                                    ListEspecieApro.Add(especie);
                                }
                            }                            
                        }
                    }
                }

                return ListEspecieApro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
