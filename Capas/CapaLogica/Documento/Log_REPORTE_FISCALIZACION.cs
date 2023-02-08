using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_REPORTE_FISCALIZACION;
using CEntidad = CapaEntidad.DOC.Ent_REPORTE_FISCALIZACION;
using CEntPAU = CapaEntidad.DOC.Ent_Reporte_PAU_CONCLUIDO;
using Oracle.ManagedDataAccess.Client;
using CapaEntidad.ViewModel;
using CapaEntidad.DOC;
using System.Linq;
//using CEntidadTitular = CapaEntidad.DOC.Ent_REPORTE_SUPERVISION_GENERAL;
//using CEntidadDetalleTH= CapaEntidad.DOC.Ent_Reporte_ThabilitanteInformacion;
//using CEntidadMedida = CapaEntidad.DOC.Ent_Reporte_Departamentos;
//using CEntidadFrecuencia = CapaEntidad.DOC.Ent_Reporte_InfraccionesFrecuentes;

namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Log_REPORTE_FISCALIZACION
    {

        private CDatos oCDatos = new CDatos();
        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public CEntidad RegMostMenu(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.MostrarMenu(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        */
        /*
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CEntidad RegMostCombo()
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo(cn);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         * */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public List<CEntidad> MostrarInfraccion_PAU(CEntidad oCampoEntrada)
        {
            try
            {
                return oCDatos.MostrarInfraccion_PAU(oCampoEntrada);
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
        //public CEntidad LogInfraccionesFrecuentes(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.DatInfraccionesFrecuentes(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public List<CEntidad> RegMostrarEncisos(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.MostrarEncisos(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public CEntidad LogMedidasCautelares(CEntidad oCampoEntrada)
        {
            try
            {
                return oCDatos.DatMedidasCautelares(oCampoEntrada);
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
        public List<CEntidad> LogDetMedidasCautelares(CEntidad oCampoEntrada)
        {
            try { return oCDatos.DatDetMedidasCautelares(oCampoEntrada); }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public List<CEntidad> LogInformexEspecialista(CEntidad oCampoEntrada)
        {
            try { return oCDatos.DatInformexEspecialista(oCampoEntrada); }
            catch (Exception ex) { throw ex; }
        }
        ///

        //public List<CEntidad> LogInformexEspecialistaDetalle(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.DatInformeTecnicoLegalXEspecialistaDetalle(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //para la lista de informes legales cpor años y linea de codigo
        public List<CEntidad> LogInformeLegalLinea(CEntidad oCampoEntrada)
        {
            try { return oCDatos.DatInformeTecnicoLegalLinea(oCampoEntrada); }
            catch (Exception ex) { throw ex; }
        }
        /// DatInformeTecnicoLegalLinea
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public List<CEntidad> LogInformeTecnicoxEspecialista(CEntidad oCampoEntrada)
        {
            try { return oCDatos.DatInformeTecnicoxEspecialista(oCampoEntrada); }
            catch (Exception ex) { throw ex; }
        }

        /**
         * funcion para traer datos de informe técnico a detalle por usuario seleccionado
         * */
        public List<CEntidad> LogInformeTecnicoEspecialistaDetalle(CEntidad oCampoEntrada)
        {
            try
            {
                return oCDatos.DatInformeTecnicoEspecialistaDetalle(oCampoEntrada);
            }
            catch (Exception ex) { throw ex; }
        }
        public List<CEntidad> LogInformeTecnicoEspecialistaLinea(CEntidad oCampoEntrada)
        {
            try
            {
                return oCDatos.DatInformeTecnicoEspecialistaLinea(oCampoEntrada);
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public List<CEntidad> LogFaltaInformeLegal(CEntidad oCampoEntrada)
        {
            try
            {
                return oCDatos.DatFaltaInformeLegal(oCampoEntrada);
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
        //public List<CEntidad> LogDetEmisionResolucion(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.DatDetEmisionResolucion(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public List<CEntidad> LogResolucionesEmitidas(CEntidad oCampoEntrada)
        {
            try { return oCDatos.DatResolucionesEmitidas(oCampoEntrada); }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        //public CEntidad LogInformeSupervisionEvaluados(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.RegInformeSupervisionEvaluados(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //buscar profesional
        public CEntidad LogProfesional(CEntidad oCampoEntrada)
        {
            try
            { return oCDatos.RegProfesionalSelecionado(oCampoEntrada); }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public List<CEntidad> LogRecursoImpugatorio(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatRecursoImpugatorio(cn, oCampoEntrada);
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
        //public List<CEntidad> LogEstado_Informe(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            return oCDatos.DatEstadoInforme(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public List<CEntidad> LogArchivos(CEntidad oCampoEntrada)
        {
            try
            {
                oCampoEntrada.TIPO_REPORTE = "RESUMEN";

                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatArchivos(cn, oCampoEntrada);
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
        public List<CEntidad> LogArchivosDetalle(CEntidad oCampoEntrada)
        {
            try
            {
                oCampoEntrada.TIPO_REPORTE = "DETALLE";

                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatArchivosDetalle(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> ReporteNotificaciones(CEntidad oCampoEntrada)
        {
            try
            {
                oCampoEntrada.TIPO_REPORTE = "REPORTE_NOTIFICACIONES";

                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatReporteNotificaciones(cn, oCampoEntrada);
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
        public CEntidad Log_Caducidad(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.Dat_Caducidad(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> Log_CaducidadDetalle(CEntidad oCampoEntrada)
        {
            List<CEntidad> olDatos = new List<CEntidad>();

            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.Dat_CaducidadDetalle(cn, oCampoEntrada);
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
        public List<CEntPAU> Log_ExpedientesAdministrativos(CEntPAU oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    // return oCDatos.Dat_Expedientes_Administrativos(cn, oCampoEntrada);
                    return oCDatos.Dat_Expedientes_NumeroPAU_concluidos(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntPAU> Log_ExpedientesAdministrativosResumen(CEntPAU oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.Dat_Expedientes_NumeroPAU_concluidos_resumen(cn, oCampoEntrada);
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
        //public CEntidad Log_ExpedientesAdministrativosInf(CEntidad oCampoEntrada)
        //{
        //    try
        //    {
        //        using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena()))
        //        {
        //            cn.Open();
        //            // return oCDatos.Dat_Expedientes_Administrativos(cn, oCampoEntrada);
        //            return oCDatos.Dat_Expedientes_NumeroPAU_concluidosInf(cn, oCampoEntrada);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public List<CEntidad> LogResolucionesEmitidasRRE(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatResolucionesEmitidasRRE(cn, oCampoEntrada);
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
        public List<CEntidad> LogDetEmisionResolucionRRE(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.DatDetEmisionResolucionRRE2(cn, oCampoEntrada);
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
        public List<CEntidad> Log_InicioPauVsDescargo(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.Dat_InicioPauVsDescargo(cn, oCampoEntrada);
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
        public List<CEntidad> Log_DetDescargo(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.Dat_DetDescargo(cn, oCampoEntrada);
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
        public List<CEntidad> Dat_RelDocTitular(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.Dat_RelDocTitular(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad RegMostrarFechaObserv(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarFechaObserv(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CEntidad> log_InfSupSinLegal(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.Dat_InfSupSinLegal(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// metodo que devuelve la lista de documentos presentados por el titular
        /// 29/08/2017
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> logListDocumentosTH(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.datListDocumentTH(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        public List<CEntidad> logListNotificaciones(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.datListNotificaciones(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// metodo que devuelve la lista de detalle de los documentos presentados por el titular
        /// 31/08/2017
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> logListDocumentosTHDetalle(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.datListDocumentTHDetalle(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// metodo que obtiene la lista de recursos impugnatorios
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> logListRecursosImpugnatorios(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.datListImpugnatorio(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// metodo que devuelve la lista de detalles de los recursos impugnatorios
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> logListRecursosImpugDetalle(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.datListImpugnatorioDetalle(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> log_ReporteSeguimientoSupervision(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.datReporteSeguimientoSupervision(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<CEntidad> log_ReporteSeguimientoSupervisionDetalle(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.dat_ReporteSeguimientoDetalle(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> log_ReporteSeguimientoSuspencionDetalle(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.dat_ReporteSegSuspensionDetalle(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> log_ReporteSeguimientoQuinquenalDetalle(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.datReporteSegQuinquenalDetalle(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> log_ReporteSeguimiento(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.datReporteSeguimiento(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> log_ReporteSeguimientoDetalle(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.dat_ReporteSeguimiento_Detalle(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> log_ReporteListInfQuinquenal(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.dat_ReporteListInfQuinquenal(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Datos ingresados 26/11/2020
        public VM_ReporteSeguimientoRegistro IniDatosReporte(string asTipoReporte, string asCodUCuenta)
        {
            VM_ReporteSeguimientoRegistro vm = new VM_ReporteSeguimientoRegistro();
            Log_BUSQUEDA exeBus = new Log_BUSQUEDA();
            List<VM_Chk> lstChkItem;

            vm.hdfTipoReporte = asTipoReporte;
            lstChkItem = new List<VM_Chk>();
            for (int i = DateTime.Now.Year; i >= 2005; i--)
            {
                lstChkItem.Add(new VM_Chk() { Value = i.ToString(), Text = i.ToString() });
            }
            vm.lstChkAnio = lstChkItem;

            switch (asTipoReporte)
            {
                case "INFSUPERVISION":
                    vm.lblTituloCabecera = "Reporte Seguimiento de Informes de Supervisión";               
                    break;
                case "INFSUSPENSION":
                    vm.lblTituloCabecera = "Reporte Seguimiento de Informes de suspensión";
                    break;
                case "INFQUINQUENAL":
                    vm.lblTituloCabecera = "Reporte Seguimiento de Informes quinquenales";
                    break;
                case "VMC":
                    vm.lblTituloCabecera = "Reporte Seguimiento de Informes de verificación de medidas correctivas";
                    break;
                case "TH":
                    vm.lblTituloCabecera = "Reporte Seguimiento de Títulos Habilitantes";
                    break;
                case "POA":
                    vm.lblTituloCabecera = "Reporte Seguimiento de Planes de Manejo";
                    break;
                case "RD":
                    vm.lblTituloCabecera = "Reporte Seguimiento de Resoluciones Directorales";
                    break;
                case "ILEGAL":
                    vm.lblTituloCabecera = "Reporte Seguimiento de Informes Legales";
                    break;
                case "INSTRUCCION_FINAL":
                    vm.lblTituloCabecera = "Reporte Seguimiento de Informes de Instruccion Final";
                    break;
                case "INF_TECNICO":
                    vm.lblTituloCabecera = "Reporte Seguimiento de Informes Técnicos";
                    break;
                case "NOTIFICACIONES":
                    vm.lblTituloCabecera = "Reporte Seguimiento de Notificaciones";
                    break;
                case "INFTIT":
                    vm.lblTituloCabecera = "Reporte Seguimiento de Notificaciones Fiscalización";
                    break;
                case "CAPACITACION":
                    vm.lblTituloCabecera = "Reporte Seguimiento de Registros de Capacitaciones";
                    break;
            }

            return vm;
        }

        //Datos ingresados 21/12/2020
        public VM_ReporteFiscalizacion IniDatosReporteFiscalizacion(string asTipoReporte, string asCodUCuenta)
        {
            VM_ReporteFiscalizacion vm = new VM_ReporteFiscalizacion();
            

            vm.hdfTipoReporte = asTipoReporte;

            switch (asTipoReporte)
            {
                case "ARCHIVADOS":
                    vm.lblTituloCabecera = "Reporte de Casos Archivados";

                    Ent_MasterFiltro oCampos = new Ent_MasterFiltro();
                    Log_MasterFiltro exeBus = new Log_MasterFiltro();
                    oCampos.BusValor = "0|1|1|0|0|0|0|0|0|0|0";
                    oCampos = exeBus.RegMostFiltro(oCampos);
                    vm.lstChkModalidad = oCampos.ListModalidad.Select(i => new VM_Chk { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.lstChkRegion = oCampos.ListRegion.Select(i => new VM_Chk { Value = i.CODIGO, Text = i.DESCRIPCION });

                    break;
            }

            return vm;
        }
    }
}
