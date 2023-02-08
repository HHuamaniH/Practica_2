using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Linq;
using CDatos = CapaDatos.DOC.Dat_Reporte_ControlTiemposFiscalizacion;
using CEntidad = CapaEntidad.DOC.Ent_Reporte_ControlTiemposFiscalizacion;
using Oracle.ManagedDataAccess.Client;
namespace CapaLogica.DOC
{
    public class Log_Reporte_ControlTiemposFiscalizacion
    {
        private CDatos oCDatos = new CDatos();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostrarControlTiemposResumen(CEntidad oCEntidad)
        {
            try
            {
                oCEntidad.TIPO_REPORTE = "RESUMEN";

                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    List<CEntidad> lstResumen = oCDatos.RegMostrarControlTiemposResumen(cn, oCEntidad);
                    bool bExiste;
                    CEntidad oCampos;

                    //Añadir los procesos que no cuentan con registros y no se listan en el resultado anterior
                    switch (oCEntidad.REPORTE)
                    {
                        case "SUBDIRECCION":
                            bExiste = lstResumen.Exists(r => r.COD_TPROCESO == "0000001");
                            if (!bExiste)
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_TPROCESO = "0000001"; oCampos.TIPO_PROCESO = "Casos para evaluación legal";
                                oCampos.VERDE = 0; oCampos.AMARILLO = 0; oCampos.ROJO = 0; oCampos.TOTAL = 0;
                                oCampos.ORDEN = 1;
                                lstResumen.Add(oCampos);
                            }
                            bExiste = lstResumen.Exists(r => r.COD_TPROCESO == "0000002");
                            if (!bExiste)
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_TPROCESO = "0000002"; oCampos.TIPO_PROCESO = "Casos para iniciar el PAU, en caso se hayan dictado en forma previa medidas cautelares";
                                oCampos.VERDE = 0; oCampos.AMARILLO = 0; oCampos.ROJO = 0; oCampos.TOTAL = 0;
                                oCampos.ORDEN = 2;
                                lstResumen.Add(oCampos);
                            }
                            bExiste = lstResumen.Exists(r => r.COD_TPROCESO == "0000003");
                            if (!bExiste)
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_TPROCESO = "0000003"; oCampos.TIPO_PROCESO = "Casos para recepción descargos resolución Inicio PAU";
                                oCampos.VERDE = 0; oCampos.AMARILLO = 0; oCampos.ROJO = 0; oCampos.TOTAL = 0;
                                oCampos.ORDEN = 3;
                                lstResumen.Add(oCampos);
                            }
                            bExiste = lstResumen.Exists(r => r.COD_TPROCESO == "0000004");
                            if (!bExiste)
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_TPROCESO = "0000004"; oCampos.TIPO_PROCESO = "Casos para emisión de informe final de instrucción (Fase Instructiva)";
                                oCampos.VERDE = 0; oCampos.AMARILLO = 0; oCampos.ROJO = 0; oCampos.TOTAL = 0;
                                oCampos.ORDEN = 5;
                                lstResumen.Add(oCampos);
                            }
                            bExiste = lstResumen.Exists(r => r.COD_TPROCESO == "0000005");
                            if (!bExiste)
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_TPROCESO = "0000005"; oCampos.TIPO_PROCESO = "Casos con ampliación o variación de imputaciones en fase instructiva, pendientes de emisión de informe final de instrucción";
                                oCampos.VERDE = 0; oCampos.AMARILLO = 0; oCampos.ROJO = 0; oCampos.TOTAL = 0;
                                oCampos.ORDEN = 4;
                                lstResumen.Add(oCampos);
                            }
                            bExiste = lstResumen.Exists(r => r.COD_TPROCESO == "0000006");
                            if (!bExiste)
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_TPROCESO = "0000006"; oCampos.TIPO_PROCESO = "Casos para elevar informe final de instrucción a la autoridad decisora";
                                oCampos.VERDE = 0; oCampos.AMARILLO = 0; oCampos.ROJO = 0; oCampos.TOTAL = 0;
                                oCampos.ORDEN = 6;
                                lstResumen.Add(oCampos);
                            }
                            break;
                        case "DIRECCION":
                            bExiste = lstResumen.Exists(r => r.COD_TPROCESO == "0000007");
                            if (!bExiste)
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_TPROCESO = "0000007"; oCampos.TIPO_PROCESO = "Casos para notificar el informe final de instrucción";
                                oCampos.VERDE = 0; oCampos.AMARILLO = 0; oCampos.ROJO = 0; oCampos.TOTAL = 0;
                                oCampos.ORDEN = 1;
                                lstResumen.Add(oCampos);
                            }
                            bExiste = lstResumen.Exists(r => r.COD_TPROCESO == "0000008");
                            if (!bExiste)
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_TPROCESO = "0000008"; oCampos.TIPO_PROCESO = "Casos para recepcionar descargos al informe final de instrucción";
                                oCampos.VERDE = 0; oCampos.AMARILLO = 0; oCampos.ROJO = 0; oCampos.TOTAL = 0;
                                oCampos.ORDEN = 2;
                                lstResumen.Add(oCampos);
                            }
                            bExiste = lstResumen.Exists(r => r.COD_TPROCESO == "0000009");
                            if (!bExiste)
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_TPROCESO = "0000009"; oCampos.TIPO_PROCESO = "Casos en fase decisora para emitir resolución directoral final";
                                oCampos.VERDE = 0; oCampos.AMARILLO = 0; oCampos.ROJO = 0; oCampos.TOTAL = 0;
                                oCampos.ORDEN = 3;
                                lstResumen.Add(oCampos);
                            }
                            bExiste = lstResumen.Exists(r => r.COD_TPROCESO == "0000010");
                            if (!bExiste)
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_TPROCESO = "0000010"; oCampos.TIPO_PROCESO = "Casos para recepcionar recurso impugnatorio a la RD Final";
                                oCampos.VERDE = 0; oCampos.AMARILLO = 0; oCampos.ROJO = 0; oCampos.TOTAL = 0;
                                oCampos.ORDEN = 4;
                                lstResumen.Add(oCampos);
                            }
                            bExiste = lstResumen.Exists(r => r.COD_TPROCESO == "0000011");
                            if (!bExiste)
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_TPROCESO = "0000011"; oCampos.TIPO_PROCESO = "Casos para resolver con recurso de reconsideración";
                                oCampos.VERDE = 0; oCampos.AMARILLO = 0; oCampos.ROJO = 0; oCampos.TOTAL = 0;
                                oCampos.ORDEN = 5;
                                lstResumen.Add(oCampos);
                            }
                            break;
                        case "DL1272":
                            bExiste = lstResumen.Exists(r => r.COD_TPROCESO == "0000013");
                            if (!bExiste)
                            {
                                oCampos = new CEntidad();
                                oCampos.COD_TPROCESO = "0000013"; oCampos.TIPO_PROCESO = "PAU sin resolver";
                                oCampos.VERDE = 0; oCampos.AMARILLO = 0; oCampos.ROJO = 0; oCampos.TOTAL = 0;
                                oCampos.ORDEN = 1;
                                lstResumen.Add(oCampos);
                            }
                            break;
                    }

                    return lstResumen.OrderBy(r => r.ORDEN).ToList();
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
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        public List<CEntidad> RegMostrarControlTiemposDetalle(CEntidad oCEntidad)
        {
            try
            {
                oCEntidad.TIPO_REPORTE = "DETALLE";

                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarControlTiemposDetalle(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
