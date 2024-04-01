using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using CapaEntidad.ViewModel.DOC;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Linq;
using CDatos = CapaDatos.DOC.Dat_REPORTE_GENERAL;
using CEntidad = CapaEntidad.DOC.Ent_REPORTE_GENERAL;
using Oracle.ManagedDataAccess.Client;
namespace CapaLogica.DOC
{
    public class Log_REPORTE_GENERAL
    {
        private CDatos oCDatos = new CDatos();

        public List<Dictionary<string, string>> ReporteGeneral(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ReporteGeneral(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Ent_PreVisualizarv1> Reporte_EstadodeGuiaTransporte(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            return oCDatos.Reporte_EstadodeGuiaTransporte(criterio, valorBusqueda, currentPage, pageSize, sort, ref rowCount);
        }
        public List<VM_ALERTA_SUPERVISION> AlertaSupervision()
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.AlertaSupervision(cn);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VM_ReporteGeneral InitReporteGeneral(string asTipoReporte)
        {
            VM_ReporteGeneral vmRpt = new VM_ReporteGeneral();
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            List<VM_Chk> lstChkItem;
            DateTime today = DateTime.Today;

            switch (asTipoReporte)
            {
                case "SABANA_INFORME":
                    vmRpt.lblTituloCabecera = "Reporte Total";
                    vmRpt.hdfTipoReporte = "SABANA_INFORME";
                    lstChkItem = new List<VM_Chk>();
                    for (int i = DateTime.Now.Year; i >= 2004; i--)
                        lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                    vmRpt.lstChkAnio = lstChkItem;
                    vmRpt.lstChkTipoInforme = exeBus.RegMostComboIndividual("COD_ITIPO", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkOd = exeBus.RegMostComboIndividual("OD_AMBITO_GEO", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkModalidad = exeBus.RegMostComboIndividual("MODALIDAD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkDepartamento = exeBus.RegMostComboIndividual("DEPARTAMENTO", "").Where(m => m.Value != "00").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkDLinea = exeBus.RegMostComboIndividual("SUBDIRECCION", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    break;
                case "SABANA_PLAN_MANEJO":
                    vmRpt.lblTituloCabecera = "Reporte Total";
                    vmRpt.hdfTipoReporte = "SABANA_PLAN_MANEJO";
                    lstChkItem = new List<VM_Chk>();
                    for (int i = DateTime.Now.Year; i >= 2004; i--)
                        lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                    vmRpt.lstChkAnio = lstChkItem;
                    vmRpt.lstChkTipoInforme = exeBus.RegMostComboIndividual("COD_ITIPO", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkOd = exeBus.RegMostComboIndividual("OD_AMBITO_GEO", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkModalidad = exeBus.RegMostComboIndividual("MODALIDAD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkDepartamento = exeBus.RegMostComboIndividual("DEPARTAMENTO", "").Where(m => m.Value != "00").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkDLinea = exeBus.RegMostComboIndividual("SUBDIRECCION", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    break;
                case "SABANA_SEGUIMIENTO_ALERTA":
                    vmRpt.lblTituloCabecera = "Seguimiento de Alerta";
                    vmRpt.hdfTipoReporte = "SABANA_SEGUIMIENTO_ALERTA";
                    vmRpt.lstChkOd = exeBus.RegMostComboIndividual("OD_AMBITO_GEO", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkModalidad = exeBus.RegMostComboIndividual("MODALIDAD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkDepartamento = exeBus.RegMostComboIndividual("DEPARTAMENTO", "").Where(m => m.Value != "00").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    break;
                case "SABANA_ACERVO_DOCUMENTARIO":
                    vmRpt.lblTituloCabecera = "Acervo Documentario";
                    vmRpt.hdfTipoReporte = "SABANA_ACERVO_DOCUMENTARIO";
                    vmRpt.lstChkOd = exeBus.RegMostComboIndividual("OD_AMBITO_GEO", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkModalidad = exeBus.RegMostComboIndividual("MODALIDAD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkDepartamento = exeBus.RegMostComboIndividual("DEPARTAMENTO", "").Where(m => m.Value != "00").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    break;
                //case "CUADRO_5_PASPEQ":
                //    vmRpt.lblTituloCabecera = "Cuadro N° 5 - Consolidado del universo de administrados";
                //    vmRpt.hdfTipoReporte = "CUADRO_5_PASPEQ";
                //    vmRpt.lstChkOd = null;
                //    vmRpt.lstChkModalidad = null;
                //    vmRpt.lstChkDepartamento = null;
                //    vmRpt.txtFechaCorte = today.ToString("dd/MM/yyyy");
                //    break;
                //case "CUADRO_6_PASPEQ":
                //    vmRpt.lblTituloCabecera = "Cuadro N° 6 - Cantidad de títulos habilitantes por modalidades de aprovechamiento";
                //    vmRpt.hdfTipoReporte = "CUADRO_6_PASPEQ";
                //    vmRpt.lstChkOd = null;
                //    vmRpt.lstChkModalidad = null;
                //    vmRpt.lstChkDepartamento = null;
                //    vmRpt.txtFechaCorte = today.ToString("dd/MM/yyyy");
                //    break;
                //case "CUADRO_7_PASPEQ":
                //    vmRpt.lblTituloCabecera = "Cuadro N° 7 - Número de títulos habilitantes y planes de manejo por modalidades de aprovechamiento";
                //    vmRpt.hdfTipoReporte = "CUADRO_7_PASPEQ";
                //    vmRpt.lstChkOd = null;
                //    vmRpt.lstChkModalidad = null;
                //    vmRpt.lstChkDepartamento = null;
                //    vmRpt.txtFechaCorte = today.ToString("dd/MM/yyyy");
                //    break;
                //case "CUADRO_8_PASPEQ":
                //    vmRpt.lblTituloCabecera = "Cuadro N° 8 - Consolidado de títulos habilitantes y planes de manejo según modalidad de aprovechamiento";
                //    vmRpt.hdfTipoReporte = "CUADRO_8_PASPEQ";
                //    vmRpt.lstChkOd = null;
                //    vmRpt.lstChkModalidad = null;
                //    vmRpt.lstChkDepartamento = null;
                //    vmRpt.txtFechaCorte = today.ToString("dd/MM/yyyy");
                //    break;
                case "SEGUIMIENTO_MED_CORRECTIVAS":
                    vmRpt.lblTituloCabecera = "Reporte de Seguimiento de Medidas Correctivas";
                    vmRpt.hdfTipoReporte = "SEGUIMIENTO_MED_CORRECTIVAS";
                    vmRpt.lstChkOd = null;
                    vmRpt.lstChkModalidad = exeBus.RegMostComboIndividual("MODALIDAD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkDepartamento = exeBus.RegMostComboIndividual("DEPARTAMENTO", "").Where(m => m.Value != "00").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    break;
                case "OBLIGACIONES_TIT_MADERABLE":
                    vmRpt.lblTituloCabecera = "Reporte Obligaciones de los Titulares - Supervisiones Maderables";
                    vmRpt.hdfTipoReporte = "OBLIGACIONES_TIT_MADERABLE";
                    vmRpt.lstChkOd = null;
                    vmRpt.lstChkModalidad = exeBus.RegMostComboIndividual("MODALIDAD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                   List<VM_Cbo> lista = exeBus.RegMostComboIndividual("FECHA_DE_CORTE", "");
                    vmRpt.txtFechaCorte = lista.Count > 0 ? lista[0].Text:null;
                    vmRpt.lstChkDepartamento = null;
                    break;
                case "OBLIGACIONES_TIT_NO_MADERABLE":
                    vmRpt.lblTituloCabecera = "Reporte Obligaciones de los Titulares - Supervisiones No Maderables";
                    vmRpt.hdfTipoReporte = "OBLIGACIONES_TIT_NO_MADERABLE";
                    vmRpt.lstChkOd = null;
                    vmRpt.lstChkModalidad = exeBus.RegMostComboIndividual("MODALIDAD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkDepartamento = null;
                    break;
                case "REPORTE_CONTROL_CALIDAD":
                    vmRpt.lblTituloCabecera = "Reporte de Control de Calidad de los Documentos";
                    vmRpt.hdfTipoReporte = "REPORTE_CONTROL_CALIDAD";
                    lstChkItem = new List<VM_Chk>();
                    for (int i = DateTime.Now.Year; i >= 2004; i--)
                        lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                    vmRpt.lstChkAnio = lstChkItem;
                    vmRpt.lstChkTipoInforme = null;
                    vmRpt.lstChkOd = exeBus.RegMostComboIndividual("OD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkTipoDocumentoSigo = exeBus.RegMostComboIndividual("TIPO_DOCUMENTO_SIGO", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkEstadoDocumento = exeBus.RegMostComboIndividual("ESTADO_DOCUMENTO", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkModalidad = null;
                    vmRpt.lstChkDepartamento = null;
                    vmRpt.lstChkDLinea = null;
                    break;
                case "RELACION_INFORMES_LEGALES":
                    vmRpt.lblTituloCabecera = "Reporte de Relación de Informes Legales";
                    vmRpt.hdfTipoReporte = "RELACION_INFORMES_LEGALES";
                    lstChkItem = new List<VM_Chk>();
                    for (int i = DateTime.Now.Year; i >= 2004; i--)
                        lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                    vmRpt.lstChkAnio = lstChkItem;
                    vmRpt.lstChkMes = exeBus.RegMostComboIndividual("MES", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkTipoInforme = null;
                    vmRpt.lstChkOd = null;
                    vmRpt.lstChkTipoDocumentoSigo = null;
                    vmRpt.lstChkEstadoDocumento = null;
                    vmRpt.lstChkModalidad = null;
                    vmRpt.lstChkDepartamento = null;
                    vmRpt.lstChkDLinea = exeBus.RegMostComboIndividual("SUBDIRECCION", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    break;
                case "RELACION_INFORMES_TECNICOS":
                    vmRpt.lblTituloCabecera = "Reporte de Relación de Informes Técnicos";
                    vmRpt.hdfTipoReporte = "RELACION_INFORMES_TECNICOS";
                    lstChkItem = new List<VM_Chk>();
                    for (int i = DateTime.Now.Year; i >= 2004; i--)
                        lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                    vmRpt.lstChkAnio = lstChkItem;
                    vmRpt.lstChkMes = exeBus.RegMostComboIndividual("MES", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkTipoInforme = null;
                    vmRpt.lstChkOd = null;
                    vmRpt.lstChkTipoDocumentoSigo = null;
                    vmRpt.lstChkEstadoDocumento = null;
                    vmRpt.lstChkModalidad = exeBus.RegMostComboIndividual("MODALIDAD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkDepartamento = null;
                    vmRpt.lstChkDLinea = exeBus.RegMostComboIndividual("SUBDIRECCION", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    break;
                case "RELACION_RESOLUCIONES_FISCALIZACION":
                    vmRpt.lblTituloCabecera = "Reporte de Relación de Resoluciones Emitidas";
                    vmRpt.hdfTipoReporte = "RELACION_RESOLUCIONES_FISCALIZACION";
                    lstChkItem = new List<VM_Chk>();
                    for (int i = DateTime.Now.Year; i >= 2004; i--)
                        lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                    vmRpt.lstChkAnio = lstChkItem;
                    vmRpt.lstChkMes = exeBus.RegMostComboIndividual("MES", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkTipoInforme = null;
                    vmRpt.lstChkOd = null;
                    vmRpt.lstChkTipoDocumentoSigo = null;
                    vmRpt.lstChkEstadoDocumento = null;
                    vmRpt.lstChkModalidad = exeBus.RegMostComboIndividual("MODALIDAD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkDepartamento = exeBus.RegMostComboIndividual("DEPARTAMENTO", "").Where(m => m.Value != "00").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkDLinea = exeBus.RegMostComboIndividual("DIRECCION", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkTipoResolucionFiscalizacion = exeBus.RegMostComboIndividual("TIPO_RESOLUCION_FISCALIZACION", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    break;
                case "RELACION_INFORMES_SUSPENSION":
                    vmRpt.lblTituloCabecera = "Reporte de Relación de Informes de Suspensión";
                    vmRpt.hdfTipoReporte = "RELACION_INFORMES_SUSPENSION";
                    lstChkItem = new List<VM_Chk>();
                    for (int i = DateTime.Now.Year; i >= 2004; i--)
                        lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                    vmRpt.lstChkAnio = lstChkItem;
                    vmRpt.lstChkMes = null;
                    vmRpt.lstChkTipoInforme = null;
                    vmRpt.lstChkOd = null;
                    vmRpt.lstChkTipoDocumentoSigo = null;
                    vmRpt.lstChkEstadoDocumento = null;
                    vmRpt.lstChkModalidad = null;
                    vmRpt.lstChkDepartamento = null;
                    vmRpt.lstChkDLinea = exeBus.RegMostComboIndividual("DIRECCION", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkTipoResolucionFiscalizacion = null;
                    break;
                case "RELACION_INFORMES_SUPERVISION":
                    vmRpt.lblTituloCabecera = "Reporte de Relación de Informes de Supervisión";
                    vmRpt.hdfTipoReporte = "RELACION_INFORMES_SUPERVISION";
                    lstChkItem = new List<VM_Chk>();
                    for (int i = DateTime.Now.Year; i >= 2004; i--)
                        lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                    vmRpt.lstChkAnio = lstChkItem;
                    vmRpt.lstChkMes = exeBus.RegMostComboIndividual("MES", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkTipoInforme = null;
                    vmRpt.lstChkOd = exeBus.RegMostComboIndividual("OD_AMBITO_GEO", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkTipoDocumentoSigo = null;
                    vmRpt.lstChkEstadoDocumento = null;
                    vmRpt.lstChkModalidad = exeBus.RegMostComboIndividual("MODALIDAD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkDepartamento = exeBus.RegMostComboIndividual("DEPARTAMENTO", "").Where(m => m.Value != "00").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkDLinea = exeBus.RegMostComboIndividual("DIRECCION", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkTipoResolucionFiscalizacion = null;
                    break;
                case "REPORTE_ITINERARIO_SUPERVISION":
                    vmRpt.lblTituloCabecera = "Reporte de Relación de Informes de Supervisión";
                    vmRpt.hdfTipoReporte = "REPORTE_ITINERARIO_SUPERVISION";
                    lstChkItem = new List<VM_Chk>();
                    for (int i = DateTime.Now.Year; i >= 2004; i--)
                        lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                    vmRpt.lstChkAnio = lstChkItem;
                    vmRpt.lstChkMes = null;
                    vmRpt.lstChkTipoInforme = null;
                    vmRpt.lstChkOd = null;
                    vmRpt.lstChkTipoDocumentoSigo = null;
                    vmRpt.lstChkEstadoDocumento = null;
                    vmRpt.lstChkModalidad = null;
                    vmRpt.lstChkDepartamento = null;
                    vmRpt.lstChkDLinea = exeBus.RegMostComboIndividual("DIRECCION", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkTipoResolucionFiscalizacion = null;
                    break;
                case "PAU_CONCLUIDOS_1RA_2DA":
                    break;
                case "PAU_CONCLUIDOS_RESUMEN_1RA":
                    break;
                case "PAU_CONCLUIDOS_RESUMEN_1RA_2DAPAU_CONCLUIDOS_RESUMEN_1RA_2DA":
                    break;
                case "REPORTE_ANTECEDENTE_EXPEDIENTE":
                    vmRpt.lblTituloCabecera = "Reporte de Antecedentes de Expedientes Remitidos por la AFFS";
                    vmRpt.hdfTipoReporte = "REPORTE_ANTECEDENTE_EXPEDIENTE";           
                    vmRpt.lstChkAnio = null;
                    vmRpt.lstChkMes = null;
                    vmRpt.lstChkTipoInforme = null;
                    vmRpt.lstChkOd = null;
                    vmRpt.lstChkTipoDocumentoSigo = null;
                    vmRpt.lstChkEstadoDocumento = null;
                    vmRpt.lstChkModalidad = null;
                    vmRpt.lstChkDepartamento = null;
                    vmRpt.lstChkDLinea = null;
                    vmRpt.lstChkTipoResolucionFiscalizacion = null;
                    break;
                case "REPORTE_DIRECCION_FISCALIZACION":
                    vmRpt.lblTituloCabecera = "Reporte de la Dirección de Fiscalización";
                    vmRpt.hdfTipoReporte = "REPORTE_DIRECCION_FISCALIZACION";
                    lstChkItem = new List<VM_Chk>();
                    for (int i = DateTime.Now.Year; i >= 2004; i--)
                        lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                    vmRpt.lstChkAnio = lstChkItem;
                    vmRpt.lstChkTipoInforme = exeBus.RegMostComboIndividual("COD_ITIPO", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkOd = exeBus.RegMostComboIndividual("OD_AMBITO_GEO", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkModalidad = exeBus.RegMostComboIndividual("MODALIDAD", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkDepartamento = exeBus.RegMostComboIndividual("DEPARTAMENTO", "").Where(m => m.Value != "00").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkDLinea = exeBus.RegMostComboIndividual("SUBDIRECCION", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    break;
                case "REPORTE_AUTORIZACIONES_FAUNASILVESTRE":
                    vmRpt.lblTituloCabecera = "Acervo Documentario";
                    vmRpt.hdfTipoReporte = "REPORTE_AUTORIZACIONES_FAUNASILVESTRE";
                    vmRpt.lstChkOd = exeBus.RegMostComboIndividual("OD_AMBITO_GEO", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkModalidad = exeBus.RegMostComboIndividual("MODALIDAD_EXSITU", "0000002").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    vmRpt.lstChkDepartamento = exeBus.RegMostComboIndividual("DEPARTAMENTO", "").Where(m => m.Value != "00").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });
                    break;

                case "REPORTE_SOLICITUD_FEMA":
                    vmRpt.lblTituloCabecera = "Reporte de Solicitudes FEMA";
                    vmRpt.hdfTipoReporte = "REPORTE_SOLICITUD_FEMA";
                    lstChkItem = new List<VM_Chk>();
                    for (int i = DateTime.Now.Year; i >= 2004; i--)
                        lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });

                    vmRpt.lstChkAnio = lstChkItem;
                    vmRpt.lstChkMes = exeBus.RegMostComboIndividual("MES", "").Where(m => m.Value != "0000000").Select(i => new VM_Chk { Value = i.Value, Text = i.Text });

                    break;
            }

            return vmRpt;
        }

        public List<Dictionary<string, string>> ReporteTitularResumen(VM_ReporteTitularResumen vm)
        {
            try
            {
                Ent_REPORTE_TITULAR_RESUMEN oCEntidad = new Ent_REPORTE_TITULAR_RESUMEN()
                {
                    UBICACION = vm.lstChkUbicacionId ?? "",
                    DEPARTAMENTO = vm.lstChkDepartamentoId ?? "",
                    ANIO_FIRMEZA = vm.lstChkAnioFirmezaId ?? "",
                    ANIO_PROVEIDO = vm.lstChkAnioProveidoId ?? "",
                    ANIO_RDTERMINO = vm.lstChkAnioRDTerminoId ?? "",
                    ANIO_SUPERVISION = vm.lstChkAnioSupervId ?? "",
                    DLINEA = vm.lstChkDLineaId ?? "",
                    MES_RDTERMINO = vm.lstChkMesRDTerminoId ?? "",
                    MTIPO = vm.lstChkModalidadId ?? "",
                    MULTA = vm.chkMulta,
                    TIPO_FILTRO = vm.ddlFiltroAdiconalId,
                    VALOR_FILTRO = vm.txtValorFiltro ?? ""
                };

                return oCDatos.ReporteTitularResumen(oCEntidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
