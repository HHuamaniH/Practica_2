using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
//using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CDatos = CapaDatos.DOC.Dat_CAPACITACION;
using CEntidad = CapaEntidad.DOC.Ent_CAPACITACION;
using CEntidadPDC = CapaEntidad.DOC.Ent_ReportePDC;


namespace CapaLogica.DOC
{
    public class Log_CAPACITACION
    {
        private CDatos oCDatos = new CDatos();
        /*public List<CEntidad> RegMostrarLista(CEntidad oCEntidad)
		{
			try
			{
				using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
				{
					cn.Open();
					return oCDatos.RegMostrarLista(cn, oCEntidad);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}*/
        public List<CEntidad> ReporteGraficoGenero(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteGraficoGenero(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoGeneroMemoria(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteGraficoGenero(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoCCNN(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteGraficoCCNN(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoCCNNMemoria(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteGraficoCCNN(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoETNIA(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteGraficoETNIA(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoETNIAMemoria(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteGraficoETNIA(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoTHAB(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteGraficoTHAB(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoTHABMemoria(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteGraficoTHAB(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoCORREO(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteGraficoCORREO(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoCORREOMemoria(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteGraficoCORREO(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoNOTA(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteGraficoNOTA(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoNOTAMemoria(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteGraficoNOTAMemoria(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoENCUESTA(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteGraficoENCUESTA(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoENCUESTA_EI(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteGraficoENCUESTA_EI(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteGraficoENCUESTA_EF(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteGraficoENCUESTA_EF(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteNOTACONCEPTUAL(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteNOTACONCEPTUAL(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteMEMORIA(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteMEMORIA(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteMEMORIAPN(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteMEMORIAPN(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteMEMORIAPA(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteMEMORIAPA(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteMEMORIAPP(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteMEMORIAPP(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteMEMORIAProgramacion(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteMEMORIAProgramacion(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> ReporteMEMORIACronograma(string asCodCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteMEMORIACronograma(cn, asCodCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
        public String RegGrabarDetalle(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarDetalle(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
        public CEntidad RegMostCombo(CEntidad oCEntidad)
        {
            try
            {
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

        /*########################## SIGOsfc v3 ##############################*/
        #region SIGOsfc v3
        public VM_Capacitacion IniDatosCapacitacion(string asCodCapacitacion, string asFormulario, string asCodUCuenta)
        {
            VM_Capacitacion VM_CAP = new VM_Capacitacion();

            try
            {
                VM_CAP.lblTituloCabecera = asFormulario == "CAPACITACION" ? "Capacitaciones" : "Otros Eventos";

                CEntidad entCap = new CEntidad();
                entCap.BusFormulario = asFormulario;
                entCap.COD_UCUENTA = asCodUCuenta;
                entCap = RegMostCombo(entCap);
                VM_CAP.ddlTipCapacitacion = entCap.ListMComboTipoCapacitacion.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                VM_CAP.ddlOd = entCap.ListMComboOD.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                VM_CAP.ddlConvenio = entCap.ListMComboConvenios.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION, Group = i.GRUPO });
                VM_CAP.ddlMetodologia = entCap.ListMComboMetodologia.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                VM_CAP.ddlOrganizador = entCap.ListMComboOrganizador.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                VM_CAP.ddlApoyoCoorganizador = entCap.ListApoyoCoorg.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                VM_CAP.ddlModalidad = entCap.ListMComboModalidad.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });

                var listMChkListTematica = entCap.ListMChkListTematica;
                VM_CAP.lstChkTema = listMChkListTematica
                        .Where(t => "1".Equals(t.NUEVO_2021))
                        .Select(i => new VM_Chk { Value = i.CODIGO, Text = i.DESCRIPCION });

                VM_CAP.ddlPublicoObjetivo = entCap.ListPublicoObjetivo.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION, Group = i.GRUPO });
                VM_CAP.ddlTipoAdjunto = entCap.ListMComboTipoAdjunto.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });

                if (String.IsNullOrEmpty(asCodCapacitacion))
                {
                    VM_CAP.lblTituloEstado = "Nuevo Registro";

                }
                else
                {
                    entCap = new CEntidad();
                    entCap.COD_CAPACITACION = asCodCapacitacion;
                    entCap = RegMostrarListaItems(entCap);

                    if (entCap.FECHA_CREACION != null
                        && DateTime.Parse(entCap.FECHA_CREACION.ToString()).Year <= 2020)
                    {
                        VM_CAP.lstChkTema = listMChkListTematica
                        .Where(t => "0".Equals(t.NUEVO_2021))
                        .Select(i => new VM_Chk { Value = i.CODIGO, Text = i.DESCRIPCION });
                    }

                    VM_CAP.lblTituloEstado = "Modificando Registro";
                    VM_CAP.hdfCodCapacitacion = entCap.COD_CAPACITACION;
                    VM_CAP.hdfRegEstado = 0;

                    VM_CAP.vmControlCalidad.ddlIndicadorId = entCap.COD_ESTADO_DOC;
                    VM_CAP.vmControlCalidad.txtUsuarioRegistro = entCap.USUARIO_REGISTRO;
                    VM_CAP.vmControlCalidad.txtUsuarioControl = entCap.USUARIO_CONTROL;
                    VM_CAP.vmControlCalidad.chkObsSubsanada = (bool)entCap.OBSERV_SUBSANAR;
                    VM_CAP.vmControlCalidad.txtControlCalidadObservaciones = entCap.OBSERVACIONES_CONTROL;

                    VM_CAP.ddlOdId = entCap.COD_OD;
                    VM_CAP.hdfDLinea = entCap.COD_DLINEA;
                    VM_CAP.ddlCapacitacionEjecutarId = entCap.COD_CAPACITACION;
                    VM_CAP.ddlCapacitacionEjecutar = new List<VM_Cbo>() { new VM_Cbo() { Value = entCap.COD_CAPACITACION, Text = entCap.COD_CAPACITACION + " - " + entCap.NOMBRE } };
                    VM_CAP.txtNomCapacitacion = entCap.NOMBRE;
                    VM_CAP.ddlTipCapacitacionId = entCap.COD_CAPATIPO;
                    VM_CAP.ddlSumMetPoiId = (bool)entCap.SUMA_POI == true ? "1" : "0";
                    VM_CAP.txtObjetivo = entCap.OBJETIVO;
                    VM_CAP.ddlMetodologiaId = entCap.MAE_COD_METODO;
                    VM_CAP.txtObsMetodologia = entCap.OBSERVACION_METODO;
                    VM_CAP.chkMarConvenio = (bool)entCap.MARCO_CONVENIO;
                    VM_CAP.txtFecInicio = entCap.FECHA_INICIO.ToString();
                    VM_CAP.txtFecTermino = entCap.FECHA_TERMINO.ToString();
                    VM_CAP.txtDuracion = entCap.DURACION;
                    VM_CAP.ddlOrganizadorId = entCap.MAE_COD_ORGANIZADOR;
                    VM_CAP.txtDetOrganizador = entCap.ORGANIZADOR;

                    List<string> lstApoyo = new List<string>();
                    if ((bool)entCap.APOYO_COORGANIZ_LOGISTICO) lstApoyo.Add("0000033");
                    if ((bool)entCap.APOYO_COORGANIZ_DIFUSION) lstApoyo.Add("0000034");
                    if ((bool)entCap.APOYO_COORGANIZ_FIRMA) lstApoyo.Add("0000035");
                    VM_CAP.ddlApoyoCoorganizadorId = string.Join(",", lstApoyo.ToArray());

                    VM_CAP.txtTotalParticipante = entCap.N_PARTICIPANTES;
                    VM_CAP.hdfUbigeo = entCap.COD_UBIGEO;
                    VM_CAP.lblUbigeo = entCap.UBIGEO_DESCRIPCION;
                    VM_CAP.txtLugar = entCap.LUGAR;
                    VM_CAP.txtSector = entCap.SECTOR;
                    VM_CAP.ddlZonaUtmId = entCap.ZONA_UTM == "00S" ? "0000000" : entCap.ZONA_UTM;//C�digo por defecto anterior versi�n SIGOsfc
                    VM_CAP.txtCEste = entCap.COORD_ESTE;
                    VM_CAP.txtCNorte = entCap.COORD_NORTE;
                    VM_CAP.txtConclusion = entCap.CONCLUSION;
                    VM_CAP.txtObservacion = entCap.OBSERVACION.ToString();
                    VM_CAP.ddlConvenioId = string.Join(",", entCap.ListCapacitacionConvenios.Select(i => i.COD_MARCO_CONVENIO).ToArray());
                    VM_CAP.txtAntecedentes = entCap.ANTECEDENTES;
                    VM_CAP.txtJustificacion = entCap.JUSTIFICACION;
                    VM_CAP.txtResultadosEsperados = entCap.RESULTADOS_ESPERADOS;
                    VM_CAP.ddlModalidadId = entCap.COD_MODALIDAD;
                    VM_CAP.txtMaterialesEquipo = entCap.MATERIALES_EQUIPO;
                    VM_CAP.txtPublicoObjetivo = entCap.PUBLICO_OBJETIVO;
                    VM_CAP.txtCronograma = entCap.CRONOGRAMA;
                    VM_CAP.txtPrograma = entCap.PROGRAMA;

                    VM_CAP.txtPresentacion = entCap.PRESENTACION;
                    VM_CAP.txtDescripcionEjecutiva = entCap.DESCRIPCION_EJECUTIVA;
                    VM_CAP.txtResumenIntervenciones = entCap.RESUMEN_INTERVENCIONES;
                    VM_CAP.txtDescripcionTrabajos = entCap.DESCRIPCION_TRABAJO;

                    VM_CAP.txtRecomendaciones = entCap.RECOMENDACIONES;

                    VM_CAP.lstChkTemaId = string.Join(",", entCap.ListTematica.Select(i => i.MAE_COD_TEMA).ToArray());
                    if (VM_CAP.lstChkTemaId != "")
                    {
                        List<VM_Chk> lstTema = VM_CAP.lstChkTema.ToList();
                        for (int i = 0; i < lstTema.Count; i++)
                        {
                            if (VM_CAP.lstChkTemaId.Contains(lstTema[i].Value))
                            {
                                lstTema[i].Checked = true;
                            }
                        }
                        VM_CAP.lstChkTema = lstTema.ToList();
                    }
                    VM_CAP.txtDescTema = entCap.DESCRIPCION_TEMAS;

                    VM_CAP.ddlPublicoObjetivoId = string.Join(",", entCap.ListPublicoObjetivo.Select(i => i.COD_PUBLICO_OBJETIVO).ToArray());
                    VM_CAP.txtDescPObjRepresentante = entCap.ListPublicoObjetivo.Where(m => m.COD_PUBLICO_OBJETIVO == "0000032").Select(m => m.DESCRIPCION_PUBLICO).FirstOrDefault();
                    VM_CAP.txtDescPObjOtroActor = entCap.ListPublicoObjetivo.Where(m => m.COD_PUBLICO_OBJETIVO == "0000039").Select(m => m.DESCRIPCION_PUBLICO).FirstOrDefault();

                    VM_CAP.tbParticipante_Asistentes = entCap.ListParticipantes;
                    VM_CAP.tbParticipante_EquipoApoyo = entCap.ListParticipantesOsi;
                    VM_CAP.tbParticipante_Ponentes = entCap.ListParticipantesPonente;
                    VM_CAP.tbEvaluacion_Aportes = entCap.ListAportes;
                    VM_CAP.tbEvaluacion_Encuestas = entCap.ListEncuestas;
                    VM_CAP.tbEvaluacion_Examenes = entCap.ListEvaluaciones;
                    VM_CAP.tbEvaluacion_EvalInicial = entCap.ListEvaInicial;
                    VM_CAP.tbEvaluacion_EvalFinal = entCap.ListEvaFinal;
                    VM_CAP.tbDocumentoAdjunto = entCap.ListTDCapacitacion;
                    VM_CAP.tbProgramacion = entCap.ListProgramacion;
                    VM_CAP.tbCronograma = entCap.ListCronograma;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return VM_CAP;
        }

        public ListResult GuardarDatosCapacitacion(VM_Capacitacion _dto, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {
                ValidarDatosCapacitacion(_dto);

                CEntidad paramsCap = new CEntidad();
                paramsCap.COD_CAPACITACION = _dto.hdfRegEstado == 1 ? _dto.ddlCapacitacionEjecutarId : (_dto.hdfCodCapacitacion ?? "");
                paramsCap.COD_OD = _dto.ddlOdId;
                paramsCap.COD_DLINEA = _dto.hdfDLinea;
                paramsCap.NOMBRE = _dto.txtNomCapacitacion;
                paramsCap.COD_CAPATIPO = _dto.ddlTipCapacitacionId;
                paramsCap.SUMA_POI = _dto.ddlSumMetPoiId == "1" ? true : false;
                paramsCap.FECHA_INICIO = _dto.txtFecInicio;
                paramsCap.FECHA_TERMINO = _dto.txtFecTermino;
                paramsCap.DURACION = _dto.txtDuracion;
                paramsCap.OBJETIVO = _dto.txtObjetivo;
                paramsCap.MAE_COD_METODO = _dto.ddlMetodologiaId;
                paramsCap.OBSERVACION_METODO = _dto.txtObsMetodologia ?? "";
                paramsCap.N_PARTICIPANTES = _dto.txtTotalParticipante;
                paramsCap.MAE_COD_ORGANIZADOR = _dto.ddlOrganizadorId;
                paramsCap.ORGANIZADOR = paramsCap.MAE_COD_ORGANIZADOR == "0000013" ? _dto.txtDetOrganizador : "";
                _dto.ddlApoyoCoorganizadorId = _dto.ddlApoyoCoorganizadorId ?? "";
                paramsCap.APOYO_COORGANIZ_LOGISTICO = _dto.ddlApoyoCoorganizadorId.Contains("0000033");
                paramsCap.APOYO_COORGANIZ_DIFUSION = _dto.ddlApoyoCoorganizadorId.Contains("0000034");
                paramsCap.APOYO_COORGANIZ_FIRMA = _dto.ddlApoyoCoorganizadorId.Contains("0000035");
                paramsCap.MARCO_CONVENIO = _dto.chkMarConvenio;
                paramsCap.ListCapacitacionConvenios = new List<CEntidad>();
                if ((bool)paramsCap.MARCO_CONVENIO && (_dto.ddlConvenioId ?? "") != "")
                {
                    string[] lstConvenio = _dto.ddlConvenioId.Split(',');
                    for (int i = 0; i < lstConvenio.Length; i++)
                    {
                        paramsCap.ListCapacitacionConvenios.Add(new CEntidad() { COD_MARCO_CONVENIO = lstConvenio[i].ToString() });
                    }
                }
                paramsCap.COD_UBIGEO = _dto.hdfUbigeo;
                paramsCap.LUGAR = _dto.txtLugar;
                paramsCap.SECTOR = _dto.txtSector ?? "";
                paramsCap.ZONA_UTM = _dto.ddlZonaUtmId == "0000000" ? null : _dto.ddlZonaUtmId;
                paramsCap.COORD_ESTE = _dto.txtCEste == 0 ? paramsCap.COORD_ESTE : _dto.txtCEste;
                paramsCap.COORD_NORTE = _dto.txtCNorte == 0 ? paramsCap.COORD_NORTE : _dto.txtCNorte;
                paramsCap.CONCLUSION = _dto.txtConclusion;
                paramsCap.OBSERVACION = _dto.txtObservacion ?? "";

                paramsCap.ANTECEDENTES = _dto.txtAntecedentes ?? "";
                paramsCap.JUSTIFICACION = _dto.txtJustificacion ?? "";
                paramsCap.RESULTADOS_ESPERADOS = _dto.txtResultadosEsperados ?? "";
                paramsCap.MATERIALES_EQUIPO = _dto.txtMaterialesEquipo ?? "";
                paramsCap.COD_MODALIDAD = _dto.ddlModalidadId ?? "";
                paramsCap.PUBLICO_OBJETIVO = _dto.txtPublicoObjetivo ?? "";
                paramsCap.CRONOGRAMA = _dto.txtCronograma ?? "";
                paramsCap.PROGRAMA = _dto.txtPrograma ?? "";
                paramsCap.PRESENTACION = _dto.txtPresentacion ?? "";
                paramsCap.DESCRIPCION_EJECUTIVA = _dto.txtDescripcionEjecutiva ?? "";
                paramsCap.RESUMEN_INTERVENCIONES = _dto.txtResumenIntervenciones ?? "";
                paramsCap.DESCRIPCION_TRABAJO = _dto.txtDescripcionTrabajos ?? "";
                paramsCap.RECOMENDACIONES = _dto.txtRecomendaciones ?? "";

                paramsCap.ListTematica = new List<CEntidad>();
                if ((_dto.lstChkTemaId ?? "") != "")
                {
                    string[] lstTema = _dto.lstChkTemaId.Split(',');
                    for (int i = 0; i < lstTema.Length; i++)
                    {
                        if (lstTema[i].ToString() == "0000032")
                            paramsCap.ListTematica.Add(new CEntidad() { MAE_COD_TEMA = lstTema[i].ToString(), DESCRIPCION = (_dto.txtDescTema ?? "") });
                        else
                            paramsCap.ListTematica.Add(new CEntidad() { MAE_COD_TEMA = lstTema[i].ToString() });
                    }
                    paramsCap.DESCRIPCION_TEMAS = _dto.lstChkTemaId.Contains("0000032") ? (_dto.txtDescTema ?? "") : null;
                }

                paramsCap.ListPublicoObjetivo = new List<CEntidad>();
                if ((_dto.ddlPublicoObjetivoId ?? "") != "")
                {
                    string[] lstPObjetivo = _dto.ddlPublicoObjetivoId.Split(',');
                    for (int i = 0; i < lstPObjetivo.Length; i++)
                    {
                        switch (lstPObjetivo[i].ToString())
                        {
                            case "0000032":
                                paramsCap.ListPublicoObjetivo.Add(new CEntidad() { COD_PUBLICO_OBJETIVO = lstPObjetivo[i].ToString(), DESCRIPCION_PUBLICO = _dto.txtDescPObjRepresentante });
                                break;
                            case "0000039":
                                paramsCap.ListPublicoObjetivo.Add(new CEntidad() { COD_PUBLICO_OBJETIVO = lstPObjetivo[i].ToString(), DESCRIPCION_PUBLICO = _dto.txtDescPObjOtroActor });
                                break;
                            default:
                                paramsCap.ListPublicoObjetivo.Add(new CEntidad() { COD_PUBLICO_OBJETIVO = lstPObjetivo[i].ToString() });
                                break;
                        }
                    }
                }

                paramsCap.ListParticipantes = _dto.tbParticipante_Asistentes;
                paramsCap.ListParticipantesOsi = _dto.tbParticipante_EquipoApoyo;
                paramsCap.ListParticipantesPonente = _dto.tbParticipante_Ponentes;

                switch (paramsCap.COD_CAPATIPO)
                {
                    case "0000001":
                    case "0000006":
                        paramsCap.ListEncuestas = _dto.tbEvaluacion_Encuestas;
                        paramsCap.ListEvaluaciones = _dto.tbEvaluacion_Examenes;
                        break;
                    case "0000002":
                        paramsCap.ListAportes = _dto.tbEvaluacion_Aportes;
                        break;
                    case "0000003":
                        paramsCap.ListEvaInicial = _dto.tbEvaluacion_EvalInicial;
                        paramsCap.ListEvaFinal = _dto.tbEvaluacion_EvalFinal;
                        break;
                    case "0000004":
                    case "0000005":
                        paramsCap.ListEvaInicial = _dto.tbEvaluacion_EvalInicial;
                        paramsCap.ListEvaFinal = _dto.tbEvaluacion_EvalFinal;
                        paramsCap.ListEvaluaciones = _dto.tbEvaluacion_Examenes;
                        paramsCap.ListEncuestas = _dto.tbEvaluacion_Encuestas;
                        break;
                    case "0000007":
                        paramsCap.ListEvaluaciones = _dto.tbEvaluacion_Examenes;
                        break;
                }

                paramsCap.ListEliTABLA = _dto.tbEliTABLA;
                paramsCap.COD_ESTADO_DOC = _dto.vmControlCalidad.ddlIndicadorId;
                paramsCap.OBSERVACIONES_CONTROL = _dto.vmControlCalidad.txtControlCalidadObservaciones;
                paramsCap.OBSERV_SUBSANAR = _dto.vmControlCalidad.chkObsSubsanada;
                paramsCap.RegEstado = _dto.hdfRegEstado;
                paramsCap.COD_UCUENTA = asCodUCuenta;
                paramsCap.OUTPUTPARAM01 = "";

                paramsCap.ListProgramacion = _dto.tbProgramacion;
                paramsCap.ListCronograma = _dto.tbCronograma;

                //RegGrabar(paramsCap);
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    oCDatos.RegGrabar_v3(cn, paramsCap);
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
        private void ValidarDatosCapacitacion(VM_Capacitacion _dto)
        {
            if (_dto.vmControlCalidad.ddlIndicadorId == "0000000") throw new Exception("Seleccione el estado actual del registro");
            if (_dto.ddlOdId == "0000000") throw new Exception("Seleccione la oficina desconcentrada");
            if (_dto.ddlCapacitacionEjecutarId == "0000000") throw new Exception("Seleccione la capacitaci�n ejecutada'");
            if (string.IsNullOrEmpty(_dto.txtNomCapacitacion)) throw new Exception("Ingrese el nombre de la capacitaci�n programada");
            if (_dto.ddlTipCapacitacionId == "0000000") throw new Exception("Seleccione el tipo de capacitaci�n");
            if (_dto.ddlSumMetPoiId == "0000000") throw new Exception("Seleccione una opci�n del campo 'Suma la Meta POI'");
            if (string.IsNullOrEmpty(_dto.txtFecInicio)) throw new Exception("Seleccione la fecha de inicio de la capacitaci�n");
            if (string.IsNullOrEmpty(_dto.txtFecTermino)) throw new Exception("Seleccione la fecha de inicio de la capacitaci�n");
            if (string.IsNullOrEmpty(_dto.txtObjetivo)) throw new Exception("Ingrese el objetivo de la capacitaci�n");
            if (_dto.ddlOrganizadorId == "0000000") throw new Exception("Seleccione el organizador de la capacitaci�n'");
            if (_dto.ddlMetodologiaId == "0000000") throw new Exception("Seleccione la metodolog�a de la capacitaci�n'");
            //if (_dto.ddlModalidadId == "0000000") throw new Exception("Seleccione la modalidad de la capacitaci�n'");
            if (string.IsNullOrEmpty(_dto.hdfUbigeo)) throw new Exception("Seleccione el ubigeo donde se llev� a cabo la capacitaci�n");
            if (string.IsNullOrEmpty(_dto.txtLugar)) throw new Exception("Ingrese el lugar donde se llev� a cabo la capacitaci�n");
        }

        public List<Dictionary<string, string>> ReportesCapacitacion(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReportesCapacitacion(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VM_Capacitacion_Reporte IniCapacitacionReporte(string asTipoReporte, string asCodUCuenta)
        {
            VM_Capacitacion_Reporte VM_CR = new VM_Capacitacion_Reporte();
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            List<VM_Cbo> lstCboItem;
            List<VM_Chk> lstChkItem;

            switch (asTipoReporte)
            {
                #region "CONSULTA_PARTICIPANTE"
                case "CONSULTA_PARTICIPANTE":
                    VM_CR.lblTituloCabecera = "Consulta Capacitaci�n Participante";
                    VM_CR.hdfTipoReporte = "CONSULTA_PARTICIPANTE";
                    lstCboItem = new List<VM_Cbo>() {
                        new VM_Cbo() { Value = "0000000", Text = "Seleccionar" },
                        new VM_Cbo() { Value = "PERSONA", Text = "Persona" },
                        new VM_Cbo() { Value = "THABILITANTE", Text = "T�tulo Habilitante" },
                        new VM_Cbo() { Value = "CCNN", Text = "Comunidad Nativa" },
                        new VM_Cbo() { Value = "ETNIA", Text = "Etnia" },
                        new VM_Cbo() { Value = "INSTITUCION", Text = "Instituci�n" }
                    };
                    VM_CR.ddlTipoFiltro = lstCboItem;
                    VM_CR.ddlComunidadNativa = exeBus.RegMostComboIndividual("COMUNIDAD_NATIVA", "");
                    VM_CR.ddlEtnia = exeBus.RegMostComboIndividual("ETNIA", "");
                    lstChkItem = new List<VM_Chk>();
                    foreach (var item in exeBus.RegMostComboIndividual("INSTITUCION", "").Where(M => M.Value != "0000000"))
                    {
                        lstChkItem.Add(new VM_Chk() { Value = item.Value, Text = item.Text });
                    }
                    VM_CR.lstChkInstitucion = lstChkItem;
                    break;
                #endregion
                #region "PROGRAMA_VS_EJECUCION"
                case "PROGRAMA_VS_EJECUCION":
                    VM_CR.lblTituloCabecera = "Programaci�n y Ejecuci�n de Capacitaciones";
                    VM_CR.hdfTipoReporte = "PROGRAMA_VS_EJECUCION";
                    lstChkItem = new List<VM_Chk>();
                    for (int i = DateTime.Now.Year; i >= 2017; i--)
                    {
                        lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });
                    }
                    VM_CR.lstChkAnio = lstChkItem;
                    lstChkItem = new List<VM_Chk>() {
                        new VM_Chk() { Value="1",Text="Enero" },new VM_Chk() { Value="2",Text="Febrero" },new VM_Chk() { Value="3",Text="Marzo" },
                        new VM_Chk() { Value="4",Text="Abril" },new VM_Chk() { Value="5",Text="Mayo" },new VM_Chk() { Value="6",Text="Junio" },
                        new VM_Chk() { Value="7",Text="Julio" },new VM_Chk() { Value="8",Text="Agosto" },new VM_Chk() { Value="9",Text="Septiembre" },
                        new VM_Chk() { Value="10",Text="Octubre" },new VM_Chk() { Value="11",Text="Noviembre" },new VM_Chk() { Value="12",Text="Diciembre" }
                    };
                    VM_CR.lstChkMes = lstChkItem;
                    break;
                #endregion
                #region "TOTAL_CAPACITACION"
                case "TOTAL_CAPACITACION":
                    VM_CR.lblTituloCabecera = "Total de Capacitaciones";
                    VM_CR.hdfTipoReporte = "TOTAL_CAPACITACION";

                    VM_CR.lstChkOd = exeBus.RegMostComboIndividual("OD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    VM_CR.lstChkTipCapacitacion = exeBus.RegMostComboIndividual("TIPO_CAPACITACION", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });

                    lstCboItem = exeBus.RegMostComboIndividual("ENTIDAD_CAPACITACION", "");
                    for (int i = 0; i < lstCboItem.Count; i++)
                    {
                        if (lstCboItem[i].Value == "0000000") lstCboItem[i].Text = "Todos";
                    }
                    VM_CR.ddlEntFinancia = lstCboItem;
                    break;
                #endregion
                #region "CAPACITACION_MENSUAL"
                case "CAPACITACION_MENSUAL":
                    VM_CR.lblTituloCabecera = "Capacitaciones Mensuales";
                    VM_CR.hdfTipoReporte = "CAPACITACION_MENSUAL";
                    lstChkItem = new List<VM_Chk>();
                    for (int i = DateTime.Now.Year; i >= 2005; i--)
                    {
                        lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });
                    }
                    VM_CR.lstChkAnio = lstChkItem;

                    VM_CR.lstChkOd = exeBus.RegMostComboIndividual("OD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    VM_CR.lstChkTipCapacitacion = exeBus.RegMostComboIndividual("TIPO_CAPACITACION", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });

                    lstCboItem = exeBus.RegMostComboIndividual("ENTIDAD_CAPACITACION", "");
                    for (int i = 0; i < lstCboItem.Count; i++)
                    {
                        if (lstCboItem[i].Value == "0000000") lstCboItem[i].Text = "Todos";
                    }
                    VM_CR.ddlEntFinancia = lstCboItem;
                    break;
                #endregion
                #region "RELACION_CAPACITACION"
                case "RELACION_CAPACITACION":
                    VM_CR.lblTituloCabecera = "Relaci�n de Capacitaciones/Otros Eventos";
                    VM_CR.hdfTipoReporte = "RELACION_CAPACITACION";
                    lstChkItem = new List<VM_Chk>();
                    for (int i = DateTime.Now.Year; i >= 2005; i--)
                    {
                        lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });
                    }
                    VM_CR.lstChkAnio = lstChkItem;

                    VM_CR.lstChkOd = exeBus.RegMostComboIndividual("OD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    break;
                #endregion
                #region "GRUPO_PUBLICO_OBJETIVO"
                case "GRUPO_PUBLICO_OBJETIVO":
                    VM_CR.lblTituloCabecera = "Capacitaciones por P�blico Objetivo";
                    VM_CR.hdfTipoReporte = "GRUPO_PUBLICO_OBJETIVO";

                    VM_CR.lstChkOd = exeBus.RegMostComboIndividual("OD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });

                    var lstPObjetivo = RegMostCombo(new CEntidad() { BusFormulario = "CAPACITACION", COD_UCUENTA = asCodUCuenta });
                    VM_CR.lstChkPublicoObjetivo = lstPObjetivo.ListPublicoObjetivo.Select(i => new VM_Chk { Value = i.CODIGO, Text = i.DESCRIPCION, Group = i.GRUPO });
                    break;
                #endregion
                #region "CAPACITACION_DEPARTAMENTO_ANIO"
                case "CAPACITACION_DEPARTAMENTO_ANIO":
                    VM_CR.lblTituloCabecera = "Capacitaciones Efectuadas por el OSINFOR a los Actores Forestales y de Fauna Silvestre";
                    VM_CR.hdfTipoReporte = "CAPACITACION_DEPARTAMENTO_ANIO";
                    break;
                #endregion
                #region "CAPACITACION_THABILITANTE"
                case "CAPACITACION_THABILITANTE":
                    VM_CR.lblTituloCabecera = "Capacitaci�n T�tulo Habilitante";
                    VM_CR.hdfTipoReporte = "CAPACITACION_THABILITANTE";

                    lstChkItem = new List<VM_Chk>();
                    for (int i = DateTime.Now.Year; i >= 2012; i--)
                    {
                        lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });
                    }
                    VM_CR.lstChkAnio = lstChkItem;
                    VM_CR.lstChkOd = exeBus.RegMostComboIndividual("OD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    VM_CR.lstChkDepartamento = exeBus.RegMostComboIndividual("DEPARTAMENTO", "").Where(m => m.Value != "00").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    lstCboItem = exeBus.RegMostComboIndividual("ENTIDAD_CAPACITACION", "");
                    for (int i = 0; i < lstCboItem.Count; i++)
                    {
                        if (lstCboItem[i].Value == "0000000") lstCboItem[i].Text = "Todos";
                    }
                    VM_CR.ddlEntFinancia = lstCboItem;
                    break;
                #endregion
                #region "GRUPO_PUBLICO_PARTICIPANTE"
                case "GRUPO_PUBLICO_PARTICIPANTE":
                    VM_CR.lblTituloCabecera = "Capacitaciones por P�blico Participante";
                    VM_CR.hdfTipoReporte = "GRUPO_PUBLICO_PARTICIPANTE";

                    VM_CR.lstChkOd = exeBus.RegMostComboIndividual("OD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    VM_CR.lstChkTipCapacitacion = exeBus.RegMostComboIndividual("TIPO_CAPACITACION", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });

                    var lstPParticipante = RegMostCombo(new CEntidad() { BusFormulario = "CAPACITACION", COD_UCUENTA = asCodUCuenta });
                    VM_CR.lstChkPublicoObjetivo = lstPParticipante.ListPublicoParticipante.Select(i => new VM_Chk { Value = i.CODIGO, Text = i.DESCRIPCION, Group = i.GRUPO });
                    break;
                    #endregion
            }

            return VM_CR;
        }
        #endregion

        /// universo capacitable
        public List<CEntidadPDC> RepUniversoPDC(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RepUniversoPDC(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // con paginacion 
        public VM_ReporteGeneral RepUniversoPDC_pag(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RepUniversoPDC_pag(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ent_ReportConsolidadoPDC> RepconsolidadoPDC(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RepconsolidadoPDC(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #region para la importacion del PASPEQ
        //para la importacion masiva
        public List<Ent_PDCImportPASPEQ> ImportPDC_PASPEQ(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ImportPDC_PASPEQ(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //TOTAL DE REGISTROS
        public Ent_PDCImportPASPEQ ImportPDC_PASPEQ_COUNT(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ImportPDC_PASPEQ_COUNT(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// cambia el estado del listado de la tabla import paspeq
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public Ent_PDCImportPASPEQ ImportPDC_PASPEQ_CAMBIAR_ESTADO(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ImportPDC_PASPEQ_CAMBIAR_ESTADO(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //guardar datos de la importacion
        public ListResult GuardarDatosPasPEQ(Ent_PDCImportPASPEQ _dto, string asCodUCuenta)
        {
            ListResult result = new ListResult();

            try
            {

                Ent_PDCImportPASPEQ paramsExport = new Ent_PDCImportPASPEQ();
                paramsExport.ID_REGISTRO = 0;
                paramsExport.COD_THABILITANTE = "";
                paramsExport.TITULO = _dto.TITULO;
                paramsExport.ENFOQUE = _dto.ENFOQUE;
                paramsExport.MES = _dto.MES;
                paramsExport.MES_FOCALIZACION = _dto.MES_FOCALIZACION;
                paramsExport.ESTADO = 1;

                //RegGrabar(paramsCap);
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    string registro = oCDatos.GuardarDatosPasPEQ(cn, paramsExport);
                    //oCDatos.RegGrabar_v3(cn, paramsExport);
                }

                string msjRespuesta = "Se importo el registro: " + paramsExport.TITULO;
                result.AddResultado(msjRespuesta, true);
            }
            catch (Exception ex)
            {
                result.AddResultado(ex.Message, false);
            }

            return result;
        }

        //metodo para exporta el archivo excel
        public ListResult ExportPASPEQ(List<Ent_PDCImportPASPEQ> list)
        {
            ListResult result = new ListResult();
            try
            {
                if (list.Count > 0)
                {
                    string rutaBase = HttpContext.Current.Server.MapPath("~/Archivos/Plantilla/");
                    string nombreFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".xlsx";
                    string rutaExcel = rutaBase + nombreFile;
                    string rutaExcelBase = rutaBase + "import_paspeq_plantilla.xlsx";

                    try
                    {
                        File.Delete(@rutaExcel);
                        File.Copy(@rutaExcelBase, @rutaExcel);
                    }
                    catch (IOException ix)
                    {
                        throw new Exception(ix.Message);
                    }
                    //Creamos la cadena de conexi�n con el fichero excel
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
                        int i = 1, ind = 1;
                        //Abrimos la conexi�n
                        conn.Open();
                        //Creamos la ficha
                        using (OleDbCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //Construyendo las Cabeceras
                            foreach (var itemPart in list)
                            {
                                insertar = "";
                                //insertar = "'" + (ind++).ToString() + "'";
                                insertar = insertar + "'" + (itemPart.COD_THABILITANTE ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.TITULO ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.ENFOQUE.ToString() ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.MES.ToString() ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.MES_FOCALIZACION ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.ANIO.ToString() ?? "") + "'";
                                insertar = insertar + ",'" + (itemPart.ESTADO.ToString() ?? "") + "'";

                                cmd.CommandText = "INSERT INTO [import_paspeq$A" + i.ToString().Trim() + ":G" + (list.Count + 1).ToString() + "] VALUES (" + insertar + ")";
                                cmd.ExecuteNonQuery();
                            }

                            //Cerramos la conexi�n
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

        public Ent_PDCImportPASPEQ REPORTPDC_CAMBIAR_ESTADO_TALLER(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.REPORTPDC_CAMBIAR_ESTADO_TALLER(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidadPDC> PDC_TALLERES(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.PDC_TALLERES(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// metodo para asignar los talleres
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public String asignar_taller(CEntidadPDC oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.asignar_taller(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region "Gesti�n de constancias"
        public CEntidad ObtenerPorId(string COD_CAPACITACION)
        {
            try
            {
                CEntidad entCap = new CEntidad();
                entCap.COD_CAPACITACION = COD_CAPACITACION;
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ObtenerPorId(cn, entCap);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ObtenerUltimoCorrelativoPorAnio(string cod_capacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ObtenerUltimoCorrelativoPorAnio(cn, cod_capacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ObtenerAbreviatura(string codTipoCapacitacion)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ObtenerAbreviatura(cn, codTipoCapacitacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Ent_CAPACITACION_CONSTANCIA> ConstanciaListar(string codCapacitacion, int flagActivo = 0)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ConstanciaListar(cn, codCapacitacion, flagActivo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ConstanciaInsertarMasivo(List<Ent_CAPACITACION_CONSTANCIA> constancias)
        {
            return oCDatos.ConstanciaInsertarMasivo(constancias);
        }
        public Ent_CAPACITACION_CONSTANCIA ConstanciaObtener(string codConstancia)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ConstanciaObtener(cn, codConstancia);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Ent_CAPACITACION_CONSTANCIA ConstanciaObtenerPorNroConstancia(string nroConstancia)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ConstanciaObtenerPorNroConstancia(cn, nroConstancia);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ConstanciaEliminar(string codConstancia, string codUsuario)
        {
            return oCDatos.ConstanciaEliminar(codConstancia, codUsuario);
        }
        public List<CEntidad> ParticipanteListar(string codCapacitacion, string codTipoParticipante, string persona)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ParticipanteListar(cn, codCapacitacion, codTipoParticipante, persona);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CEntidad ParticipanteObtener(string codCapacitacion, string codTipoParticipante, string codPersona)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ParticipanteObtener(cn, codCapacitacion, codTipoParticipante, codPersona);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CEntidad ParticipanteObtenerPorConstancia(string codCapacitacion, string codConstancia)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ParticipanteObtenerPorConstancia(cn, codCapacitacion,codConstancia);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ParticipanteAsignarConstancia(string codCapacitacion, string codTipoParticipante, string codPersona, string codConstancia, string archivoCod, string usuarioMoficiacion, DateTime fechaModificar)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ParticipanteAsignarConstancia(codCapacitacion, codTipoParticipante, codPersona, codConstancia, archivoCod, usuarioMoficiacion, fechaModificar);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
