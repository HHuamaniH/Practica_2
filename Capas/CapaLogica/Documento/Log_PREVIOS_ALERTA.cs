using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using CDatos = CapaDatos.DOC.Dat_PREVIOS_ALERTA;
using CEntidad = CapaEntidad.DOC.Ent_PREVIOS_ALERTA;
using VModel = CapaEntidad.ViewModel.VM_PreviosAlerta;

namespace CapaLogica.DOC
{
    /// <summary>
    /// 
    /// </summary>
    public class Log_PREVIOS_ALERTA
    {
        private CDatos oCDatos = new CDatos();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
        /* public CEntidad RegMostrarListaItems(CEntidad oCEntidad)
         {
             try
             {
                 using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
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

      

         /// <summary>
         /// 
         /// </summary>
         /// <param name="oCampoEntrada"></param>
         /// <returns></returns>
         public String RegGrabar(CEntidad oCampoEntrada)
         {
             try
             {
                 using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
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

         /// <summary>
         /// 
         /// </summary>
         /// <param name="oCampoEntrada"></param>
         public void RegEliminar(CEntidad oCampoEntrada)
         {
             try
             {
                 using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
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
         /// <summary>
         /// 
         /// </summary>
         /// <param name="oCEntidad"></param>
         /// <returns></returns>
         public List<CEntidad> RegMostPoa_Thabilitante_Lista_x_Numero(CEntidad oCEntidad)
         {
             try
             {
                 using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                 {
                     cn.Open();
                     return oCDatos.RegMostPoa_Thabilitante_Lista_x_Numero(cn, oCEntidad);
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
         public CEntidad RegMostCombo(CEntidad oCEntidad)
         {
             try
             {
                 using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
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
         /// <summary>
         /// 
         /// </summary>
         /// <param name="oCEntidad"></param>
         /// <returns></returns>
         public List<CEntPersona> MostPInformeitem(CEntidad oCEntidad)
         {
             try
             {
                 using (SqlConnection cn = new SqlConnection(BDConexion.Conexion_Cadena()))
                 {
                     cn.Open();
                     return oCDatos.MostPInformeitem(cn, oCEntidad);
                 }
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }*/

        #region "Migracion - SIGO v3"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
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
        public CEntidad MostrarListaDestinatarioRuta(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.MostrarListaDestinatarioRuta(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CEntidad MostrarListaDestinatarioRutaxCodRuta(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.MostrarListaDestinatarioRutaXCodRuta(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VModel IniDatos(string codUCuenta)
        {
            VModel viewModel;
            try
            {
                viewModel = new VModel();
                CEntidad CEntDEVOLItems = new CEntidad();
                CEntidad oCampos = new CEntidad();
                oCampos.COD_PERSONA = codUCuenta;
                CEntDEVOLItems = RegMostrarListaItems(oCampos);
                viewModel.ListDESTINATARIO = CEntDEVOLItems.ListDESTINATARIO;
                viewModel.ListRUTA = CEntDEVOLItems.ListRUTA;
                viewModel.ListDESTINATARIO_RUTA = CEntDEVOLItems.ListDESTINATARIO_RUTA;
                viewModel.ListSUPUESTO = CEntDEVOLItems.ListSUPUESTO;
                viewModel.ListDESTINATARIOCC = CEntDEVOLItems.ListDESTINATARIOCC;
                viewModel.ListCOADMINISTRADOR = CEntDEVOLItems.ListCOADMINISTRADOR;
                viewModel.ListPERFILCOADMINISTRADOR = CEntDEVOLItems.ListPERFILCOADMINISTRADOR;
                viewModel.ListENTIDAD = CEntDEVOLItems.ListENTIDAD;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return viewModel;
        }
        public CEntidad RegMostComboRuta(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostComboRuta(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LlenarCombosRuta(ref VModel VM)
        {
            List<CEntidad> ListCombo = new List<CEntidad>();
            CEntidad oCampos = new CEntidad();
            oCampos.BusFormulario = "UBIGEO";
            oCampos.BusCriterio = "DEPARTAMENTO";

            oCampos = RegMostComboRuta(oCampos);

            var listCondicion = (from p in oCampos.ListDEPARTAMENTO
                                 select new VM_Cbo
                                 {
                                     Value = p.COD_UBIDEPARTAMENTO,
                                     Text = p.DEPARTAMENTO
                                 }
                          ).ToList();

            VM.ddlRutaCodUbiDepartamento = listCondicion;


        }
        public void LlenarCombosDestinatarioRuta(ref VModel viewModel)
        {
            CEntidad oCampos = new CEntidad();
            CEntidad CEntItems = new CEntidad();
            CEntItems = MostrarListaDestinatarioRuta(oCampos);
            viewModel.ListDESTINATARIO = CEntItems.ListDESTINATARIO;
            viewModel.ddlDestinatarioRutaRuta = from p in CEntItems.ListRUTA
                                                select new VM_Cbo
                                                {
                                                    Value = p.COD_RUTA.ToString(),
                                                    Text = p.COD_RUTA.ToString() + "|          " + p.DEPARTAMENTO + "|          " + p.TRAMO
                                                };
            viewModel.ListDESTINATARIO_RUTA = new List<CEntidad>();

        }

        public VModel IniDatosRuta()
        {
            VModel viewModel;
            try
            {
                viewModel = new VModel();
                LlenarCombosRuta(ref viewModel);
                return viewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public VModel IniDatosDestinatarioRuta(string RegEstado, string codRuta)
        {
            VModel viewModel;
            try
            {
                viewModel = new VModel();
                if (RegEstado == "1")
                {

                    LlenarCombosDestinatarioRuta(ref viewModel);

                }
                else
                if (RegEstado == "2")
                {
                    LlenarCombosDestinatarioRuta(ref viewModel);
                    CEntidad oCampos = new CEntidad();
                    oCampos.COD_RUTA = Convert.ToInt32(codRuta);
                    CEntidad CEntItems = new CEntidad();
                    CEntItems = MostrarListaDestinatarioRutaxCodRuta(oCampos);
                    viewModel.ddlDestinatarioRutaRutaId = oCampos.COD_RUTA.ToString();
                    viewModel.ListDESTINATARIO_RUTA = CEntItems.ListDESTINATARIO_RUTA;

                }



                // LlenarCombosRuta(ref viewModel);
                return viewModel;




            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public String RegGrabarDestinatario(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarDestinatario(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public String RegGrabarDestinatarioRuta(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarDestinatarioRuta(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListResult GuardarDatosDestinatario(VModel dto, string codCuenta)
        {
            ListResult resultado = new ListResult();
            CEntidad oCampos = new CEntidad();
            String OUTPUTPARAM = "";
            string msjRespuesta = "El Registro se Guardo Correctamente";

            try
            {

                oCampos.ListDESTINATARIO = dto.ListDESTINATARIO;
                oCampos.COD_UCUENTA = codCuenta;
                oCampos.RegEstado = dto.RegEstado;
                oCampos.OUTPUTPARAM01 = "";
                oCampos.OUTPUTPARAM02 = "";

                //Grabando Base Datos
                OUTPUTPARAM = RegGrabarDestinatario(oCampos);
                resultado.AddResultado(msjRespuesta, true);

            }
            catch (Exception)
            {
                resultado.AddResultado("Ocurrió un problema comuníquese con el Administrador", false);
            }
            return resultado;
        }

        public ListResult GuardarDatosDestinatarioRuta(VModel dto, string codCuenta)
        {
            ListResult resultado = new ListResult();
            CEntidad oCampos = new CEntidad();
            String OUTPUTPARAM = "";
            string msjRespuesta = "El Registro se Guardo Correctamente";

            try
            {
                oCampos.ListDESTINATARIO_RUTA = dto.ListDESTINATARIO_RUTA;
                oCampos.COD_UCUENTA = codCuenta;
                oCampos.RegEstado = dto.RegEstado;
                //  oCampos.COD_RUTA =Convert.ToInt32( dto.ddlDestinatarioRutaRutaId) ;
                oCampos.ListEliTABLA = dto.ListEliTABLA;
                oCampos.OUTPUTPARAM01 = "";
                oCampos.OUTPUTPARAM02 = "";

                //Grabando Base Datos
                OUTPUTPARAM = RegGrabarDestinatarioRuta(oCampos);
                resultado.AddResultado(msjRespuesta, true);

            }
            catch (Exception)
            {
                resultado.AddResultado("Ocurrió un problema comuníquese con el Administrador", false);
            }
            return resultado;
        }
        public String RegGrabarRuta(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarRuta(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListResult GuardarDatosRuta(VModel dto, string codCuenta)
        {
            ListResult resultado = new ListResult();
            CEntidad oCampos = new CEntidad();
            String OUTPUTPARAM = "";
            string msjRespuesta = "El Registro se Guardo Correctamente";

            try
            {

                oCampos.ListRUTA = dto.ListRUTA;
                oCampos.COD_UCUENTA = codCuenta;
                oCampos.RegEstado = dto.RegEstado;
                oCampos.OUTPUTPARAM01 = "";
                oCampos.OUTPUTPARAM02 = "";

                //Grabando Base Datos
                OUTPUTPARAM = RegGrabarRuta(oCampos);
                resultado.AddResultado(msjRespuesta, true);

            }
            catch (Exception)
            {
                resultado.AddResultado("Ocurrió un problema comuníquese con el Administrador", false);
            }
            return resultado;
        }

        public ListResult GuardarDatosSupuesto(VModel dto, string codCuenta)
        {
            ListResult resultado = new ListResult();
            CEntidad oCampos = new CEntidad();
            String OUTPUTPARAM = "";
            string msjRespuesta = "El Registro se Guardo Correctamente";

            try
            {
                oCampos.ListSUPUESTO = dto.ListSUPUESTO;
                oCampos.COD_UCUENTA = codCuenta;
                oCampos.RegEstado = dto.RegEstado;
                oCampos.ListEliTABLA = dto.ListEliTABLA;
                oCampos.OUTPUTPARAM01 = "";
                oCampos.OUTPUTPARAM02 = "";

                //Grabando Base Datos
                OUTPUTPARAM = RegGrabarSupuesto(oCampos);
                resultado.AddResultado(msjRespuesta, true);
            }
            catch (Exception)
            {
                resultado.AddResultado("Ocurrió un problema comuníquese con el Administrador", false);
            }
            return resultado;
        }

        public String RegGrabarSupuesto(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarSupuesto(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VModel IniDatosDestinatarioCC()
        {
            VModel viewModel;
            try
            {
                viewModel = new VModel();
                CEntidad oCampos = new CEntidad();
                CEntidad CEntItems = new CEntidad();
                CEntItems = MostrarListaDestinatarioCC(oCampos);
                viewModel.ListDESTINATARIO = CEntItems.ListDESTINATARIO;
                viewModel.ListDESTINATARIOCC = CEntItems.ListDESTINATARIOCC;
                return viewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CEntidad MostrarListaDestinatarioCC(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.MostrarListaDestinatarioCC(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ListResult GuardarDatosDestinatarioCC(VModel dto, string codCuenta)
        {
            ListResult resultado = new ListResult();
            CEntidad oCampos = new CEntidad();
            String OUTPUTPARAM = "";
            string msjRespuesta = "El Registro se Guardo Correctamente";

            try
            {
                oCampos.ListDESTINATARIOCC = dto.ListDESTINATARIOCC;
                oCampos.ListEliTABLA = dto.ListEliTABLA;

                oCampos.COD_UCUENTA = codCuenta;
                oCampos.OUTPUTPARAM01 = " ";
                oCampos.OUTPUTPARAM02 = " ";

                //Grabando Base Datos
                OUTPUTPARAM = RegGrabarDestinatarioCC(oCampos);
                resultado.AddResultado(msjRespuesta, true);

            }
            catch (Exception)
            {
                resultado.AddResultado("Ocurrió un problema comuníquese con el Administrador", false);
            }
            return resultado;
        }

        public String RegGrabarDestinatarioCC(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarDestinatarioCC(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListResult GuardarCOAdministrador(VModel dto, string codCuenta)
        {
            ListResult resultado = new ListResult();
            CEntidad oCampos = new CEntidad();
            String OUTPUTPARAM = "";
            string msjRespuesta = "El Registro se Guardo Correctamente";
            bool success = true;

            try
            {

                oCampos.ListCOADMINISTRADOR = dto.ListCOADMINISTRADOR;
                oCampos.COD_UCUENTA_CREACION = codCuenta;
                oCampos.RegEstado = dto.RegEstado;
                oCampos.OUTPUTPARAM01 = "";
                oCampos.OUTPUTPARAM02 = "";

                //Grabando Base Datos                
                OUTPUTPARAM = RegGrabarCOAdministrador(oCampos);
                success = OUTPUTPARAM == "EXITO" ? true : false;
                msjRespuesta = OUTPUTPARAM == "EXITO" ? msjRespuesta : OUTPUTPARAM;

                resultado.AddResultado(msjRespuesta, success);

            }
            catch (Exception)
            {
                resultado.AddResultado("Ocurrió un problema comuníquese con el Administrador", false);
            }
            return resultado;
        }

        public String RegGrabarCOAdministrador(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabarCOAdministrador(cn, oCampoEntrada);
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
