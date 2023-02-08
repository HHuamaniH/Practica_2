using Herramienta;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using CDatos = CapaDatos.DOC.Dat_THComportamiento;
using CEntidad = CapaEntidad.DOC.Ent_TH_Comportamiento;
using CEntidadCal = CapaEntidad.DOC.Ent_TH_Calificacion;
using CEntidadTHabilitante = CapaEntidad.DOC.Ent_THabilitanteC;
using CEntidadTHCalififacionAnual = CapaEntidad.DOC.Ent_TH_CalificacionAnual;
using VMTHComportamiento = CapaEntidad.ViewModel.VM_THComportamiento;
using Oracle.ManagedDataAccess.Client;
using System.Linq;

namespace CapaLogica.DOC
{
    public class Log_THComportamiento
    {
        private CDatos oCDatos = new CDatos();
        Utilitarios HerUtil = new Utilitarios();
        List<CEntidad> ListadoIncisos = new List<CEntidad>();


        public VMTHComportamiento RegMostrarTHComportamiento(CEntidad oCampoEntrada)
        {
            VMTHComportamiento vmTHComportamiento = new VMTHComportamiento();
            try
            {
                vmTHComportamiento.THComportamiento = RegMostrarTHComportamientoDetalle(oCampoEntrada);
                vmTHComportamiento.ListTHCalificacion = RegMostrarTHCalificacion(new CEntidad
                {
                    TX_DATO_BUSQUEDA = vmTHComportamiento.THComportamiento.NV_COD_TITULO_HABILITANTE
                });
                
                vmTHComportamiento.ListTHabilitante = RegMostrarTHabilitantes(new CEntidad
                {
                    NU_OPCION_BUSQUEDA=0,
                    TX_DATO_BUSQUEDA = vmTHComportamiento.THComportamiento.NV_COD_TITULO_HABILITANTE
                });
                
                vmTHComportamiento.ListTHCalificacionAnual = RegMostrarTHCalificacionAnual(new CEntidad
                {                    
                    TX_DATO_BUSQUEDA = vmTHComportamiento.THComportamiento.NV_COD_TITULO_HABILITANTE
                });

                return vmTHComportamiento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CEntidad RegMostrarTHComportamientoDetalle(CEntidad oCampoEntrada)
        {            
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_OBSERVATORIO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarTHComportamiento(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidadCal> RegMostrarTHCalificacion(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_OBSERVATORIO()))
                {
                    cn.Open();
                    var resultado = oCDatos.RegMostrarTHCalificacion(cn, oCampoEntrada);

                    for (int i = 1; i < resultado.Count; i++)
                    {
                        if (resultado[i].NU_PUNTAJE == 0)
                        {
                            resultado[i].NU_PUNTAJE = resultado[i - 1].NU_PUNTAJE;
                        }
                    }

                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<CEntidadTHabilitante> RegMostrarTHabilitantes(CEntidad oCampoEntrada)
        {
            try
            {
                List<CEntidadTHabilitante> response = new List<CEntidadTHabilitante>();
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_OBSERVATORIO()))
                {
                    cn.Open();
                    response = oCDatos.RegMostrarTHabilitantes(cn, oCampoEntrada);

                    if (response.Count()>1)
                    {
                        response[response.Count - 1].ADENDA_FECHA_TERMINO = response[0].ADENDA_FECHA_TERMINO;
                        for (int i = response.Count - 2; i >= 0; i--)
                        {
                            response[i].ADENDA_FECHA_TERMINO = response[i + 1].ADENDA_FECHA_INICIO;

                        }
                    }

                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidadTHCalififacionAnual> RegMostrarTHCalificacionAnual(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_OBSERVATORIO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarTHCalificacionAnual(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> RegMostrarListTHComportamiento(string request)
        {
            try
            {
                var listRequest = request.Split('|');
                CEntidad oCampoEntrada = new CEntidad() {
                    NU_OPCION=1,
                    NU_ENTIDAD = 0,
                    NU_OPCION_BUSQUEDA = 0,
                    NU_CODIGO_BUSQUEDA = 0,
                    NV_CODIGO_BUSQUEDA= listRequest[0],
                    TX_DATO_BUSQUEDA = listRequest[1]
                };
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_OBSERVATORIO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListTHComportamiento(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
