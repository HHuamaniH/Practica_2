using CapaEntidad.ViewModel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using CDatos = CapaDatos.DOC.Dat_InformeAutoridadForestal;
using CEntidad = CapaEntidad.DOC.Ent_InformeAutoridadForestal;
using CEntPersona = CapaEntidad.DOC.Ent_GENEPERSONA;
using VModel = CapaEntidad.ViewModel.VM_InformeAutoridadForestal;

namespace CapaLogica.DOC
{
    public class Log_InformeAutoridadForestal
    {
        private CDatos oCDatos = new CDatos();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public CEntidad RegMostCombo(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo(cn, oCampoEntrada);
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
        public List<CEntidad> RegNuevoBuscar(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegNuevoBuscar(cn, oCEntidad);
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
        public CEntidad RegMostrarListaItem(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaItem(cn, oCampoEntrada);
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
        public String ReglInsertarInforme(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegInsertar(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region "Migracion - SIGO v3"
        public VModel IniDatos(string codigo, string codigoComplementario, string cod_cuenta, string cod_ugrupo, int nuevo, string tipoFrmulario, string rol="")
        {
            VModel viewModel;
           
            try
            {
                viewModel = new VModel();
                viewModel.rol = rol;

                if (nuevo == 1) //iniciar nuevo item
                {   //cargando datos                 


                    LlenarCombos(ref viewModel, cod_cuenta, tipoFrmulario);
                    viewModel.ListProfesionales = new List<CEntPersona>();
                    viewModel.ListEliTABLA = new List<CEntidad>();
                    viewModel.ListVolInjustificado = new List<CEntidad>();

                    viewModel.SubTitulo = "Nuevo Registro";
                    viewModel.hdfManRegEstado = "1";

                    if (cod_ugrupo != "0000011" && cod_ugrupo != "0000001")
                        viewModel.chkPublicar = false;

                }
                if (nuevo == 0) //editar
                {
                    //Cargando datos


                    LlenarCombos(ref viewModel, cod_cuenta, tipoFrmulario);

                    CEntidad oCampos = new CEntidad();
                    oCampos.COD_INFORME = codigo;

                    CEntidad oCEntidadInforme = RegMostrarListaItem(oCampos);

                    if (tipoFrmulario == "RENUNCIA_CONCESION")
                        viewModel.lblTituloObs = "Observación del Documento";
                    else
                        viewModel.lblTituloObs = "Observación del Informe";

                    viewModel.TipoFormulario = tipoFrmulario;
                    viewModel.hdfItemCod_THabilitante = oCEntidadInforme.COD_THABILITANTE;
                    viewModel.lblnum_Thabilitante = oCEntidadInforme.NUM_THABILITANTE;
                    viewModel.lblnom_Titular = oCEntidadInforme.TITULAR;
                    viewModel.txtnum_poa = oCEntidadInforme.NUM_POA.ToString();

                    viewModel.ddlEntidadId = oCEntidadInforme.COD_ENTIDAD;
                    viewModel.ddlTipoInformeId = oCEntidadInforme.COD_ITIPO;
                    viewModel.ddlODRegistroId = oCEntidadInforme.COD_OD_REGISTRO;

                    viewModel.hdfcod_informe = oCEntidadInforme.COD_INFORME;
                    viewModel.txtnum_informe = oCEntidadInforme.NUMERO;
                    viewModel.txtfecha_emision = oCEntidadInforme.FECHA_EMISION.ToString();
                    viewModel.txtfecha_recepcion = oCEntidadInforme.FECHA_RECEPCION.ToString();
                    viewModel.txtconclusiones = oCEntidadInforme.CONCLUSIONES;
                    viewModel.txtdocAdjuntos = oCEntidadInforme.DOCUMENTOS_ADJUNTOS;
                    viewModel.txtObservacion = oCEntidadInforme.OBSERVACIONES;
                    viewModel.txtMotivo_Renuncia = oCEntidadInforme.MOTIVO_RENUNCIA;
                    viewModel.txtNumDocumento_AutSolRenuncia = oCEntidadInforme.NUM_DOCUMENTO_AUTORIDAD;
                    viewModel.txtFecha_DocAutRenuncia = oCEntidadInforme.FECHA_DOCUMENTO_AUTORIDAD.ToString();


                    //Observaciones de control de calidad
                    viewModel.chkPublicar = (Boolean)oCEntidadInforme.PUBLICAR;
                    viewModel.txtControlCalidadObservaciones = oCEntidadInforme.OBSERVACIONES_CONTROL.ToString();
                    viewModel.chkItemObsSubsanada = (Boolean)oCEntidadInforme.OBSERV_SUBSANAR;

                    viewModel.ddlItemIndicador = Log_Helper.controla_estado_calidad(oCEntidadInforme.COD_ESTADO_DOC, viewModel.ddlItemIndicador);
                    viewModel.ddlItemIndicadorId = viewModel.ddlItemIndicador.SelectedValue;


                    viewModel.txtUsuarioRegistro = oCEntidadInforme.USUARIO_REGISTRO;
                    viewModel.txtUsuarioControl = oCEntidadInforme.USUARIO_CONTROL;


                    viewModel.chkPublicar = (Boolean)oCEntidadInforme.PUBLICAR;
                    if (cod_ugrupo != "0000011" && cod_ugrupo != "0000001")
                        viewModel.chkPublicar = false;


                    viewModel.ListProfesionales = oCEntidadInforme.ListProfesionales;
                    viewModel.ListVolInjustificado = oCEntidadInforme.ListVolInjustificado;
                    viewModel.hdfManRegEstado = "0";
                    viewModel.SubTitulo = "Modificando Registro";



                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return viewModel;
        }

        public void LlenarCombos(ref VModel VM, string cod_cuenta, string tipoFrmulario)
        {
            CEntidad oCampos = new CEntidad();
            oCampos.COD_UCUENTA = cod_cuenta;
            oCampos.BusFormulario = tipoFrmulario;
            oCampos.BusValor = VM.rol;
            oCampos = RegMostCombo(oCampos);

            //  VM.ddlItemIndicador = new VM_Cbo_Propiedad();
            VM.ddlItemIndicador = new VM_Cbo_Propiedad();
            VM.ddlItemIndicador.VM_Cbo = oCampos.ListIndicador.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION }).ToList();

            VM.ddlEntidad = oCampos.ListEntidad.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            VM.ddlODRegistro = oCampos.ListODs.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            VM.ddlItemPN_DITipo = oCampos.ListMComboDIdentidad.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            VM.ddlespecialidad = oCampos.ListPersEspecialidad.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            VM.ddlprofesional = oCampos.ListNivelAcademico.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            VM.ddlTipoInforme = oCampos.ListTipoInformes.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
            var listMComboEspecies = oCampos.ListMComboEspecie.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION.ToString() }).ToList();
            listMComboEspecies.Insert(0, new VM_Cbo { Value = "-", Text = "Seleccionar" });
            VM.ddlInjustEspecies = listMComboEspecies;

            if (tipoFrmulario == "INFORME_AUT_FORESTAL")
            {
                VM.Titulo = "Informe de la Autoridad Forestal";
                VM.TipoFormularioId = "1";
                VM.lblcampo_numero = "N° Informe de la Autoridad Forestal";
                VM.lblfecha_recepcion = "Fecha Recepción por OSINFOR";
                VM.lblTituloObs = "Observación del Informe";
            }
            else if (tipoFrmulario == "OTROS_INFORMES")
            {
                VM.Titulo = "Otros Informes OSINFOR";
                VM.TipoFormularioId = "2";
                VM.lblcampo_numero = "N° Informe";
                VM.lblfecha_recepcion = "Fecha Recepción";
                VM.lblTituloObs = "Observación del Informe";
            }
            else if (tipoFrmulario == "RENUNCIA_CONCESION")
            {
                VM.Titulo = "Formato de Solicitud de Renuncia a la Concesión";
                VM.TipoFormularioId = "3";
                VM.lblcampo_numero = "N° de documento de renuncia";
                VM.lblfecha_recepcion = "Fecha de presentación";

                VM.lblTituloObs = "Observación del Documento";


            }





        }


        public ListResult GuardarDatos(VModel dto, string codCuenta)
        {
            ListResult resultado = new ListResult();
            CEntidad oCampos = new CEntidad();
            string msjRespuesta = "El Registro se Guardo Correctamente";

            try
            {

                if (dto.hdfItemCod_THabilitante != "")
                {

                    CEntidad oCEntidadInforme = new CEntidad();
                    oCEntidadInforme.COD_INFORME = dto.hdfcod_informe;

                    oCEntidadInforme.COD_UCUENTA = codCuenta;
                    oCEntidadInforme.COD_THABILITANTE = dto.hdfItemCod_THabilitante;
                    oCEntidadInforme.NUM_THABILITANTE = null;
                    oCEntidadInforme.TITULAR = null;

                    if (dto.TipoFormularioId == "3")
                        oCEntidadInforme.NUM_POA = 0;
                    else { oCEntidadInforme.NUM_POA = Int32.Parse(dto.txtnum_poa.Trim()); }

                    oCEntidadInforme.COD_ENTIDAD = string.IsNullOrEmpty(dto.ddlEntidadId) ? "0000000" : dto.ddlEntidadId;
                    oCEntidadInforme.NUMERO = dto.txtnum_informe;
                    oCEntidadInforme.FECHA_EMISION = Convert.ToDateTime(dto.txtfecha_emision);
                    oCEntidadInforme.FECHA_RECEPCION =Convert.ToDateTime(dto.txtfecha_recepcion);
                    oCEntidadInforme.CONCLUSIONES = dto.txtconclusiones;
                    oCEntidadInforme.DOCUMENTOS_ADJUNTOS = dto.txtdocAdjuntos;
                    oCEntidadInforme.OBSERVACIONES = dto.txtObservacion;
                    oCEntidadInforme.COD_OD_REGISTRO = dto.ddlODRegistroId;
                    oCEntidadInforme.COD_ITIPO = dto.ddlTipoInformeId;

                    oCEntidadInforme.MOTIVO_RENUNCIA = dto.txtMotivo_Renuncia;
                    oCEntidadInforme.NUM_DOCUMENTO_AUTORIDAD = dto.txtNumDocumento_AutSolRenuncia;
                    oCEntidadInforme.FECHA_DOCUMENTO_AUTORIDAD = dto.txtFecha_DocAutRenuncia;

                    //Variables de control de calidad
                    oCEntidadInforme.COD_ESTADO_DOC = dto.ddlItemIndicadorId;
                    oCEntidadInforme.OBSERVACIONES_CONTROL = dto.txtControlCalidadObservaciones;
                    oCEntidadInforme.OBSERV_SUBSANAR = dto.chkItemObsSubsanada;
                    oCEntidadInforme.PUBLICAR = dto.chkPublicar;
                    oCEntidadInforme.USUARIO_CONTROL = null;
                    oCEntidadInforme.USUARIO_REGISTRO = null;

                    oCEntidadInforme.RegEstado = Int32.Parse(dto.hdfManRegEstado);
                    oCEntidadInforme.OUTPUTPARAM01 = "";

                    oCEntidadInforme.ListEliTABLA = dto.ListEliTABLA;
                    oCEntidadInforme.ListProfesionales = dto.ListProfesionales;
                    oCEntidadInforme.ListVolInjustificado = dto.ListVolInjustificado;

                    ReglInsertarInformeV3(oCEntidadInforme);

                    resultado.AddResultado(msjRespuesta, true);
                }
                else
                {

                    resultado.AddResultado("Debe seleccionar un título habilitante", false);
                }


            }
            catch (Exception ex)
            {
                resultado.AddResultado(ex.Message, false);
            }
            return resultado;
        }
        public String ReglInsertarInformeV3(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegInsertarV3(cn, oCampoEntrada);
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
