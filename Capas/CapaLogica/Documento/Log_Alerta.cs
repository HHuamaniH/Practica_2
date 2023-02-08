using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using CEntidad = CapaEntidad.DOC.Ent_ALERTA;
using CDatos = CapaDatos.DOC.Dat_ALERTA;
using VModel = CapaEntidad.ViewModel.VM_Alerta;
using CapaEntidad.ViewModel;

namespace CapaLogica.DOC
{
    public class Log_Alerta
    {
        private CDatos oCDatos = new CDatos();
        public List<CEntidad> AlertaListaItems(string criterio, string valorBusqueda, int currentPage, int pageSize, string sort, ref int rowCount)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.AlertaListaItems(cn, criterio, valorBusqueda, currentPage, pageSize, sort, ref rowCount);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public CEntidad EditItemsAlerta(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.EditItemsAlerta(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad SeguimientoItemsAlerta(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.SeguimientoItemsAlerta(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String RegGrabarSeguimiento(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarSeguimiento(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String RegGrabarRptaEnlace(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarRptaEnlace(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public List<CEntidad> RegEspecieBExt(string COD_CNOTIFICACION)
        {
            return oCDatos.RegEspecieBExt(COD_CNOTIFICACION);
        }
        public CEntidad GetDestinatarios_CC(string supuesto)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.GetDestinatarios_CC(cn, supuesto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public CEntidad GetRegRespuesta(string token)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.GetRegRespuesta(cn, token);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public VModel IniDatosEdit(CEntidad oCampos, String codigoCuentaU)
        {
            VModel viewModel;
            try
            {
                viewModel = new VModel();
                CEntidad CEntDEVOLItems = new CEntidad();
                CEntidad _oCampos = new CEntidad();
                _oCampos.COD_BITACORA = oCampos.COD_BITACORA;
                _oCampos.COD_THABILITANTE = oCampos.COD_THABILITANTE.Split('|')[0].ToString();
                _oCampos.COD_SECUENCIAL = Int32.Parse(oCampos.COD_THABILITANTE.Split('|')[1].ToString());

                CEntDEVOLItems = EditItemsAlerta(_oCampos);
                //viewModel.ListOD = oCDatos.RegMostComboOficinaDesconcentrada(codigoCuentaU, "BITACORA_SUPER");
                CEntidad toCampos = new CEntidad();
                toCampos.COD_UCUENTA = codigoCuentaU;
                toCampos.BUSFORMULARIO = "BITACORA_SUPER";
                toCampos = RegMostCombo(toCampos);
                viewModel.ListDepartamentos = toCampos.ListDepartamentos;
                viewModel.ListSupuestos = toCampos.ListSupuestos;

                CEntDEVOLItems.COD_BITACORA = oCampos.COD_BITACORA;
                CEntDEVOLItems.COD_THABILITANTE = oCampos.COD_THABILITANTE.Split('|')[0].ToString();
                CEntDEVOLItems.COD_SECUENCIAL = Int32.Parse(oCampos.COD_THABILITANTE.Split('|')[1].ToString());
                viewModel.entidad = CEntDEVOLItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return viewModel;
        }

        public VModel IniDatosSeguimiento(CEntidad oCampos, String codigoCuentaU)
        {
            VModel viewModel;
            try
            {
                viewModel = new VModel();
                CEntidad CEntDEVOLItems = new CEntidad();
                CEntidad _oCampos = new CEntidad();
                _oCampos.COD_BITACORA = oCampos.COD_BITACORA;
                _oCampos.COD_THABILITANTE = oCampos.COD_THABILITANTE.Split('|')[0].ToString();
                _oCampos.COD_SECUENCIAL = Int32.Parse(oCampos.COD_THABILITANTE.Split('|')[1].ToString());

                CEntDEVOLItems = SeguimientoItemsAlerta(_oCampos);
                
                CEntidad toCampos = new CEntidad();
                toCampos.COD_UCUENTA = codigoCuentaU;
                toCampos.BUSFORMULARIO = "BITACORA_SUPER";                
                
                CEntDEVOLItems.COD_BITACORA = oCampos.COD_BITACORA;
                CEntDEVOLItems.COD_THABILITANTE = oCampos.COD_THABILITANTE.Split('|')[0].ToString();
                CEntDEVOLItems.COD_SECUENCIAL = Int32.Parse(oCampos.COD_THABILITANTE.Split('|')[1].ToString());
                viewModel.entidad = CEntDEVOLItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return viewModel;
        }

        public ListResult GuardarSeguimiento(VModel dto, string codCuenta)
        {
            ListResult resultado = new ListResult();
            CEntidad CEntDEVOLItems = new CEntidad();
            CEntidad _oCampos = new CEntidad();
            String OUTPUTPARAM = "";
            string msjRespuesta = "El Registro se Guardo Correctamente";

            try
            {

                _oCampos.ListDocRecibido = dto.ListDocRecibido;
                _oCampos.COD_BITACORA = dto.codigoDato;
                _oCampos.COD_THABILITANTE = dto.codigoComplementario.Split('|')[0].ToString();
                _oCampos.COD_SECUENCIAL = Int32.Parse(dto.codigoComplementario.Split('|')[1].ToString());
                _oCampos.COD_UCUENTA = codCuenta;                
                _oCampos.RegEstado = Int32.Parse(dto.RegEstado);                

                //Grabando Base Datos
                OUTPUTPARAM = RegGrabarSeguimiento(_oCampos);
                resultado.AddResultado(msjRespuesta, true);

            }
            catch (Exception ex)
            {
                resultado.AddResultado(ex.Message, false);
            }
            return resultado;
        }
        public ListResult GuardarRptaEnlace(VModel dto, string codCuenta)
        {
            ListResult resultado = new ListResult();
            CEntidad CEntDEVOLItems = new CEntidad();
            CEntidad _oCampos = new CEntidad();
            String OUTPUTPARAM = "";
            string msjRespuesta = "El Registro se Guardo Correctamente";

            try
            {

                _oCampos.ListRptaEnlace = dto.ListRptaEnlace;
                _oCampos.COD_UCUENTA = codCuenta;
                _oCampos.RegEstado = Int32.Parse(dto.RegEstado);

                //Grabando Base Datos
                OUTPUTPARAM = RegGrabarRptaEnlace(_oCampos);
                resultado.AddResultado(msjRespuesta, true);

            }
            catch (Exception ex)
            {
                resultado.AddResultado(ex.Message, false);
            }
            return resultado;
        }
        

        public String RegGrabarBitacoraBXConfirmacion(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarBitacoraBXConfirmacion(cn, oCampoEntrada); //RegGrabar
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String RegEnviarAlerta(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegEnviarAlerta(cn, oCampoEntrada);
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

        public List<Dictionary<string, string>> GetAllRutaDestino(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.GetAllRutaDestino(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
