using CapaDatos.DOC;
using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using CDatos = CapaDatos.DOC.Dat_CertificadoPlanta;
using CEntidad = CapaEntidad.DOC.Ent_CertificadoPlanta;
namespace CapaLogica.DOC
{
    public class Log_CertificadoPlanta
    {
        private CDatos oCDatos = new CDatos();

        public VM_CertificadoPlanta IniDatosCertificadoPlanta(string codCertificacionPlanta, string codigoThabilitante, string descripcion, string cod_cuenta, int codigoNuevo)
        {
            VM_CertificadoPlanta CP_VM;
            bool esConsolidado = false;
            try
            {
                CP_VM = new VM_CertificadoPlanta();

               
                if (String.IsNullOrEmpty(codCertificacionPlanta)) //iniciar nuevo item
                {                  
                    CP_VM.hdCodigo_CertificadoPlanta = "";
                    CP_VM.hdCodigo_Thabilitante = codigoThabilitante;
                    CP_VM.ItemTitulo = "Nuevo Registro";                    
                    CP_VM.hdfManRegEstado = "1";

                    CP_VM.txtItemNumero = descripcion.Split('|')[0];
                    CP_VM.txtItemModalidad = descripcion.Split('|')[1];
                    CP_VM.txtItemTitular = descripcion.Split('|')[2];
                    CP_VM.txtItemUbicacion = descripcion.Split('|')[5];

                    CP_VM.txtItemNumeroInscripcion = string.Empty;
                    CP_VM.txtItemFechaInscripcion = string.Empty;

                    CP_VM.txtItemAreaTotal = string.Empty;
                    CP_VM.txtItemFechaEstablecimiento = string.Empty;

                    CP_VM.ddlZonaUTMId = string.Empty;
                    CP_VM.txtCoorEste = string.Empty;
                    CP_VM.txtCoorNorte = string.Empty;

                    CP_VM.txtItemObservacion = string.Empty;

                }
                else //iniciar modificar item
                {
                    CEntidad datModificar = new CEntidad();
                    datModificar.COD_CERTIFPLANTA = codCertificacionPlanta;
                    datModificar = RegMostrarListaItems(datModificar);
                    
                    CP_VM.ItemTitulo = "Modificando Registro";
                    CP_VM.hdCodigo_CertificadoPlanta = codCertificacionPlanta;
                    CP_VM.hdCodigo_Thabilitante = datModificar.COD_THABILITANTE;
                    
                    CP_VM.hdfManRegEstado = "0";
                    CP_VM.txtItemNumero = datModificar.NUMERO;
                    CP_VM.txtItemModalidad = datModificar.MODALIDAD;
                    CP_VM.txtItemTitular = datModificar.TITULAR;
                    CP_VM.txtItemUbicacion = datModificar.UBIGEO;
                    CP_VM.txtItemNumeroInscripcion = datModificar.NUMERO_INSCRIPCION;
                    CP_VM.txtItemFechaInscripcion = datModificar.FECHA_INSCRIPCION.ToString();
                    CP_VM.txtItemAreaTotal = datModificar.AREATOTAL==0 ? string.Empty : datModificar.AREATOTAL.ToString();
                    CP_VM.txtItemFechaEstablecimiento = datModificar.FECHA_ESTABLECIMIENTO.ToString();
                    CP_VM.ddlZonaUTMId = datModificar.ZONA_UTM;
                    CP_VM.txtCoorEste = datModificar.COORD_ESTE == 0 ? string.Empty : datModificar.COORD_ESTE.ToString();
                    CP_VM.txtCoorNorte = datModificar.COORD_NORTE == 0 ? string.Empty : datModificar.COORD_NORTE.ToString();
                    CP_VM.txtItemFechaEstablecimiento = datModificar.FECHA_ESTABLECIMIENTO.ToString();
                    CP_VM.txtItemFechaEstablecimiento = datModificar.FECHA_ESTABLECIMIENTO.ToString();
                    CP_VM.txtItemObservacion = datModificar.OBSERVACIONES;

                    CP_VM.tbEspeciesEstablecidas = datModificar.ListEspeciesEstablecidas;
                    //variables de control de calidad
                    CP_VM.vmControlCalidad.ddlIndicadorId = datModificar.COD_ESTADO_DOC;
                    CP_VM.vmControlCalidad.txtUsuarioRegistro = datModificar.USUARIO_REGISTRO;
                    CP_VM.vmControlCalidad.txtUsuarioControl = datModificar.USUARIO_CONTROL;                    
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return CP_VM;
        }

        public ListResult GuardarDatosCertificadoPlanta(VM_CertificadoPlanta dto, string codCuenta)
        {
            ListResult resultado = new ListResult();
            Ent_CertificadoPlanta oCampos = new CEntidad();
            String[] OUTPUTPARAM = null;
            string appServer = "";
            string msjRespuesta = "El Registro se Guardo Correctamente";
            //string oResultTransferir = "";//Cuando se transfiere un TH del Antecedente Expediente del SITD
            try
            {
                //THabilitante
                oCampos.COD_THABILITANTE = dto.hdCodigo_Thabilitante;
                oCampos.COD_CERTIFPLANTA = dto.hdCodigo_CertificadoPlanta;
                oCampos.NUMERO_INSCRIPCION = dto.txtItemNumeroInscripcion;
                oCampos.FECHA_INSCRIPCION = dto.txtItemFechaInscripcion;
                oCampos.AREATOTAL = string.IsNullOrEmpty(dto.txtItemAreaTotal) ? -1 : decimal.Parse(dto.txtItemAreaTotal);
                oCampos.FECHA_ESTABLECIMIENTO = dto.txtItemFechaEstablecimiento;
                oCampos.ZONA_UTM = dto.ddlZonaUTMId;
                oCampos.COORD_ESTE = string.IsNullOrEmpty(dto.txtCoorEste) ? -1 : Int32.Parse(dto.txtCoorEste);
                oCampos.COORD_NORTE = string.IsNullOrEmpty(dto.txtCoorNorte) ? -1 : Int32.Parse(dto.txtCoorNorte);
                oCampos.OBSERVACIONES = dto.txtItemObservacion;
                oCampos.COD_UCUENTA = codCuenta;

                //Validando Estado
                oCampos.OUTPUTPARAM01 = "";
                oCampos.OUTPUTPARAM02 = "";
                oCampos.RegEstado = Int32.Parse(dto.hdfManRegEstado);
                
                if (dto.hdfManRegEstado == "0") //Modificar
                {
                    oCampos.COD_CERTIFPLANTA = dto.hdCodigo_CertificadoPlanta;
                    msjRespuesta = "El Registro se Modifico Correctamente";
                }

                oCampos.ListEliTABLA = dto.tbEliTABLA; //cuando se elimina datos
                oCampos.ListEspeciesEstablecidas = dto.tbEspeciesEstablecidas;

                //Variables de control de calidad
                oCampos.COD_ESTADO_DOC = dto.vmControlCalidad.ddlIndicadorId;

                using (OracleConnection cn = new OracleConnection(BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    OracleTransaction tr = cn.BeginTransaction();
                    try
                    {
                        //Grabando Base Datos.
                        OUTPUTPARAM = oCDatos.RegGrabarV3(cn, oCampos, tr).Split('|');
                        
                        tr.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (tr != null)
                        {
                            tr.Rollback();
                            tr.Dispose();
                        }

                        throw ex;
                    }
                }

                resultado.appServer = appServer;
                resultado.AddResultado(msjRespuesta, true);
            }
            catch (Exception ex)
            {
                if (dto.appClient == null)
                {
                    dto.appClient = "";
                    dto.appData = "";
                }
                if (dto.appClient != "" && dto.appClient.Split('|')[1] == "TRANSFERIR")
                {
                    appServer = "1|" + ex.Message;
                }
                else if (dto.appClient != "" && dto.appClient.Split('|')[1] == "VISUALIZAR")
                {
                    appServer = "1|" + ex.Message;
                }
                resultado.appServer = appServer;
                // resultado.AddResultado(ex.Message , false);
                resultado.AddResultado("Ocurri� un error en el registro, por favor de verificar los datos e intente de nuevo", false);
            }
            return resultado;
        }

        public CEntidad RegMostrarListaItems(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaItems(cn, oCEntidad);
                    //cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

    }
}
