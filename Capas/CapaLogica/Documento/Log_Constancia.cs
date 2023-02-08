using CapaDatos;
using CapaEntidad.ViewModel.DOC;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDatos = CapaDatos.DOC.Dat_Constancia;
using CEntidad = CapaEntidad.DOC.Ent_Constancia;

namespace CapaLogica.DOC
{
    public class Log_Constancia
    {
        private CDatos oCDatos = new CDatos();

        public List<Dictionary<string, string>> ListarConstancia(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ListarConstancia(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public VM_CONSTANCIA ObtenerPorIdentificador(string identificador)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ObtenerPorIdentificador(cn, identificador);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public bool ActualizarDatosIntegración(string identificador, string numero,
                          DateTime fechaEmision,string codUsuario, string estadoDocumento, DateTime fechaModificar, int tramiteId,string archivo)
        {
            return oCDatos.ActualizarDatosIntegración(identificador, numero, fechaEmision, codUsuario, estadoDocumento, fechaModificar, tramiteId, archivo);
        }
        public bool ActualizarArchivoConstancia(string identificador, string archivo)
        {
            return oCDatos.ActualizarArchivoConstancia(identificador, archivo);
        }
        public bool ActualizarEstado(string identificador, string estadoDocumento, DateTime fechaModificar, string usuarioModificacion)
        {
            return oCDatos.ActualizarEstado(identificador, estadoDocumento, fechaModificar, usuarioModificacion);
        }
        #region "SQL SERVER"
        public int TramiteGuardar(VM_CONSTANCIA_TRAMITE tramite)
        {
            return oCDatos.TramiteGuardar(tramite);
        }
        public int TramiteGuardarConstancia(VM_CONSTANCIA_TRAMITE tramite)
        {
            return oCDatos.TramiteGuardarConstancia(tramite);
        }
        public bool TramiteDigitalGuardar(int tramiteId, string nombreOriginal, string nombreNuevo, DateTime fechaOperacion)
        {
            return oCDatos.TramiteDigitalGuardar(tramiteId, nombreOriginal, nombreNuevo, fechaOperacion);
        }
        public VM_CONSTANCIA_TRAMITE TramiteObtenerById(int tramiteId)
        {
            return oCDatos.TramiteObtenerById(tramiteId);
        }
        public VM_CONSTANCIA_REMITENTE RemitenteObtenerByNroDocumento(string tipoPersona, string tipoDocumento, string nroDocumento)
        {
            return oCDatos.RemitenteObtenerByNroDocumento(tipoPersona, tipoDocumento, nroDocumento);
        }
        public VM_CONSTANCIA_REMITENTE RemitenteObtenerById(int remitenteId)
        {
            return oCDatos.RemitenteObtenerById(remitenteId);
        }
        public int RemitenteCrear(VM_CONSTANCIA_REMITENTE remitente)
        {
            return oCDatos.RemitenteCrear(remitente);
        }
        public void ObtenerJefeByOficina(int oficinaId, out int trabajadorId, out string nroDocumento,
                                         out string nombres, out string apellidos, out string oficina)
        {
            oCDatos.ObtenerJefeByOficina(oficinaId, out trabajadorId, out nroDocumento, out nombres, out apellidos, out oficina);
        }
        #endregion
    }
}
