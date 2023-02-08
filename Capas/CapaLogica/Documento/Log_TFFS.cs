using CapaEntidad.DOC;
using CapaEntidad.ViewModel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Linq;
//using System.IO;
//using System.Web;
using System.Collections.Generic;
using CDatos = CapaDatos.DOC.Dat_TFFS;
using CLogica = CapaLogica.DOC.Log_TFFS;
using CEntidad = CapaEntidad.DOC.Ent_TFFS;
//using Tra_M_Tramite = CapaEntidad.DOC.Tra_M_Tramite;
//using CEntidadC = CapaEntidad.DOC.Ent_TFFS;


namespace CapaLogica.DOC
{
    public class Log_TFFS
    {
        private CDatos oCDatos = new CDatos();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCEntidad"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public CEntidad RegMostrariNFORME_Buscar(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrariNFORME_Buscar(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Ent_SBusqueda> initArticulos(string criterio, string valor)
        {
            try
            {
                CEntidad oCampoEntrada = new CEntidad();
                oCampoEntrada.BusFormulario = "COMBO_INDIVIDUAL";
                oCampoEntrada.BusCriterio = criterio; //"ARTICULOS";
                oCampoEntrada.BusValor = valor;
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostCombo_V3(cn, oCampoEntrada);
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
        public CEntidad RegMostrarListaTFFSItem(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostrarListaTFFSItem(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VM_ResolucionTFFS initRD(string asCodTFFS, string asCodTipo)
        {
            CLogica oCLogicaTFFS = new CLogica();
            CEntidad oCEntTFFS = new CEntidad();
            VM_ResolucionTFFS vm = new VM_ResolucionTFFS();
            vm.vmControlCalidad = new VM_ControlCalidad_2();
            initBusquedaModalApeladas(vm);
            initBusquedaModalPersonas(vm);
            initCombosRD2(vm);
            initListaTFFSApeladas(vm);
            try
            {
                vm.lblTituloCabecera = "Resolución TFFS";
                if (String.IsNullOrEmpty(asCodTFFS))
                {
                    //nuevo;
                    vm.lblTituloCabecera = "Nuevo Registro";
                    vm.vmControlCalidad = new VM_ControlCalidad_2();
                    vm.vmControlCalidad.ddlIndicadorId = "0000000";
                    vm.hdfCodFCTipo = asCodTipo;

                    // initPoas(vm);
                    vm.ListInformes = new List<CEntidad>();
                    vm.ListPersonaFirma = new List<CEntidad>();
                    vm.ListLiteralRD = new List<CEntidad>();
                    vm.ListEliTABLA = new List<CEntidad>();
                    vm.ListARFFS = new List<CEntidad>();
                    vm.ListInfraccionRD = new List<Ent_RESODIREC>();
                    //vm.ListEspecieMedCorrectiva = new List<Ent_RESODIREC_MEDIDA_ESPECIE>();
                    vm.tbApeladas = new List<CEntidad>();
                    vm.tbBuscarTFFS = new List<CEntidad>();
                    vm.tbPersonas = new List<CEntidad>();
                    vm.tbNoti = new List<CEntidad>();
                    vm.tbARFFS = new List<CEntidad>();
                    vm.tbInfracciones = new List<Ent_RESODIREC>();

                    //vm.ListarIniPAU = new List<CEntidad>();
                    vm.ListEspeciesMC = new List<CEntidad>();

                    vm.RegEstado = 1;
                }
                else
                {
                    //---    modif 20-12-2020---------------------------
                    //editando
                    //Verificando Estado Session             
                    CEntidad oCampos = new CEntidad();
                    oCampos.COD_RESOLUCION_TFFS = asCodTFFS;
                    vm.hdfCodTFFS = asCodTFFS;
                    vm.ddlEstadoPAUId = "1";
                    vm.lblTituloCabecera = "Modificando Registro";
                    oCEntTFFS = oCLogicaTFFS.RegMostrarListaTFFSItem(oCampos); //oCampos
                    vm.RegEstado = 0;

                    vm.txtNTitularAd = oCEntTFFS.N_TITULAR_AD;
                    vm.txtItemNumero2 = oCEntTFFS.NUM_RESOLUCION_TFFS;
                    vm.txtNumeroTHabilitante = oCEntTFFS.NT_HABILITANTE;
                    vm.txtItemObservacion = oCEntTFFS.OBSERVACIONES;
                    vm.txtFechaEmision = oCEntTFFS.FECHA_DOCUMENTO.ToString();

                    vm.tbApeladas = oCEntTFFS.ListInformes;
                    vm.tbPersonas = oCEntTFFS.ListPersonaFirma;
                    vm.tbInfracciones = oCEntTFFS.ListInfraccionRD;
                    vm.tbARFFS = oCEntTFFS.ListARFFS;
                    vm.tbNoti = oCEntTFFS.ListNoti;
                    vm.tbBuscarTFFS = oCEntTFFS.ListTFFSApel;
                    vm.ListPOAOBSERVATORIO = oCEntTFFS.ListPOAs;

                    vm.ListPOA = oCEntTFFS.ListPOAs;


                    //Observaciones de control de calidad
                    vm.chkPublicar = (Boolean)oCEntTFFS.PUBLICAR;
                    vm.txtControlCalidadObservaciones = oCEntTFFS.OBSERVACIONES_CONTROL.ToString();
                    vm.vmControlCalidad.ddlIndicadorId = oCEntTFFS.COD_ESTADO_DOC;
                    vm.vmControlCalidad.txtUsuarioRegistro = oCEntTFFS.USUARIO_REGISTRO;
                    vm.vmControlCalidad.txtUsuarioControl = oCEntTFFS.USUARIO_CONTROL;
                    vm.vmControlCalidad.chkObsSubsanada = (bool)oCEntTFFS.OBSERV_SUBSANAR;
                    vm.vmControlCalidad.txtControlCalidadObservaciones = oCEntTFFS.OBSERVACIONES_CONTROL.ToString();

                    vm.lblUsuarioRegistro = oCEntTFFS.USUARIO_REGISTRO;
                    vm.lblUsuarioControl = oCEntTFFS.USUARIO_CONTROL;

                    vm.ddlTipoResolucion = vm.ListTipoResolucion.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlTipoResolucionId = oCEntTFFS.TIP_RES;
                    vm.ddlResApelacion = vm.ListApelacion.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlResApelacionId = oCEntTFFS.RES_APE;
                    vm.txtQueja = oCEntTFFS.QUEJA_OBS;
                    vm.ddlResOtros = vm.ListOtros.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlResOtrosId = oCEntTFFS.RES_OTROS;
                    vm.txtDescripcion = oCEntTFFS.DESCRIP_TEXT;
                    vm.ddlResTFFSDFFS = vm.ListNulidadOficio.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlResTFFSDFFSId = oCEntTFFS.OTROS_NULI;
                    vm.ddlUbigeoDepartamento = vm.ListaUbigeoDepartamento.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlUbigeoDepartamentoId = oCEntTFFS.UBIGEO_DEPA;
                    vm.txtFechaPresentacion = oCEntTFFS.FECHA_PRESENTACION;
                    vm.inptExpediente = oCEntTFFS.N_TRAMITE;

                    vm.ddlSentidoRes = vm.ListCboSentidoRes.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlSentidoResId = oCEntTFFS.SENTIDO_RES;
                    vm.ddlImprocedente = vm.ListImpro.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlImprocedenteId = oCEntTFFS.RESOL_IMPRO;
                    vm.txtDetermina = oCEntTFFS.RESOL_DET;
                    vm.ddlInadmisible = vm.ListInadm.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlInadmisibleId = oCEntTFFS.RESOL_INAD;
                    vm.txtDetermina2 = oCEntTFFS.RESOL_DET2;
                    vm.txtDetermina3 = oCEntTFFS.RESOL_DET3;
                    vm.chkConfirmar = oCEntTFFS.CHKCONFIRMAR == 1 ? true : false;
                    vm.chkRevocar = oCEntTFFS.CHKREVOCAR == 1 ? true : false; ;
                    vm.radGrupoRevocar = oCEntTFFS.RADREVOCAR ;
                    vm.radNulidad = oCEntTFFS.RADNULIDAD;
                    vm.radGrupoRevocar2 = oCEntTFFS.RADREVOCAR2;
                    vm.radNulidad2 = oCEntTFFS.RADNULIDAD2;
                    vm.radGrupoRevocarParte = oCEntTFFS.RADREVOCARPARTE;
                    vm.radGrupoRevocarParte2 = oCEntTFFS.RADREVOCARPARTE2;

                    vm.chkRevocarParte = oCEntTFFS.CHKREVOCARPARTE == 1 ? true : false; ;
                    vm.chkRetrotraer = oCEntTFFS.CHKRETROTRAER == 1 ? true : false; ;
                    vm.radRetrotraer = oCEntTFFS.RADRETROTRAER;
                    vm.radRetrotraer2 = oCEntTFFS.RADRETROTRAER2;
                    vm.chkPrescribir = oCEntTFFS.CHKPRESCRIBIR == 1 ? true : false; ;
                    vm.chkArchivar = oCEntTFFS.CHKARCHIVAR == 1 ? true : false; ;
                    vm.chkNulidad = oCEntTFFS.CHKNULIDAD == 1 ? true : false; ;
                    vm.chkLevantar = oCEntTFFS.CHKLEVANTAR == 1 ? true : false; ;
                    vm.chkCarece = oCEntTFFS.CHKCARECE == 1 ? true : false; ;
                    vm.chkOtro = oCEntTFFS.CHKOTRO == 1 ? true : false; ;
                    vm.ddlNulidad = vm.ListNulidad.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlNulidadId = oCEntTFFS.CMB_NULIDAD;
                    vm.ddlNulidad = vm.ListNulidad.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlNulidad_Id = oCEntTFFS.CMB_NULIDAD2;
                    vm.ddlDeterminaRetrotraer = vm.ListDetermina_DocRetrotrae.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlDeterminaRetrotraerId = oCEntTFFS.DETERMINA_RETROTRAER;
                    vm.ddlRetrotraer = vm.ListCboRetrotraer.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlRetrotraerId = oCEntTFFS.RETRO_VALOR1;
                    vm.ddlDeterminaRetrotraer2 = vm.ListDetermina_DocRetrotrae.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlDeterminaRetrotraerId2 = oCEntTFFS.DETERMINA_RETROTRAER2;
                    vm.ddlRetrotraer2 = vm.ListCboRetrotraer.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlRetrotraerId2 = oCEntTFFS.RETRO_VALOR2;
                    vm.txtDescripcionOtros2 = oCEntTFFS.DESCRIP_TEXT_OTROS2;
                    vm.txtDescripcionRetrotraer2 = oCEntTFFS.DESCRIP_TEXT_RETROTRAER2;
                    vm.chkConfirmar2 = oCEntTFFS.CHKCONFIRMAR2 == 1 ? true : false; ;
                    vm.chkRevocar2 = oCEntTFFS.CHKREVOCAR2 == 1 ? true : false; ;
                    vm.chkRevocarParte2 = oCEntTFFS.CHKREVOCARPARTE2 == 1 ? true : false; ;
                    vm.chkRetrotraer2 = oCEntTFFS.CHKRETROTRAER2 == 1 ? true : false; ;
                    vm.chkPrescribir2 = oCEntTFFS.CHKPRESCRIBIR2 == 1 ? true : false; ;
                    vm.chkArchivar2 = oCEntTFFS.CHKARCHIVAR2 == 1 ? true : false; ;
                    vm.chkNulidad2 = oCEntTFFS.CHKNULIDAD2 == 1 ? true : false; ;
                    vm.chkLevantar2 = oCEntTFFS.CHKLEVANTAR2 == 1 ? true : false; ;
                    vm.chkCarece2 = oCEntTFFS.CHKCARECE2 == 1 ? true : false; ;
                    vm.chkOtro2 = oCEntTFFS.CHKOTRO2 == 1 ? true : false; ;

                    vm.ddlConfirmaResol = vm.ListaConfirmaResol.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlConfirmaResolId = oCEntTFFS.CONFIRM_RESOL;
                    vm.ddlLevantamiento = vm.ListMedCorrect.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlLevantamientoId = oCEntTFFS.LEVANTAMIENTO;
                    vm.ddlMedCorrect = vm.ListMedCorrect.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlMedCorrectId = oCEntTFFS.MEDIDAS_CORRECTIVAS2;
                    vm.txtDetermina_MedidaCorrectiva = oCEntTFFS.DESCRIPCION_MED_CORRECTIVAS;
                    vm.ddlCMulta = vm.ListMedCorrect.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlCMultaId = oCEntTFFS.CAMBIO_MULTA2;
                    vm.ddlAmonestacion = vm.ListMedCorrect.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlAmonestacionId = oCEntTFFS.AMONESTACION2;
                    vm.txtDescripcionImprocedente = oCEntTFFS.DESCRIP_TEXT_IMPRO;
                    vm.txtDescripcionInadmisible = oCEntTFFS.DESCRIP_TEXT_INAD;
                    vm.txtDescripcionInfundado = oCEntTFFS.DESCRIP_TEXT_INFU;
                    vm.txtDescripcionFundado = oCEntTFFS.DESCRIP_TEXT_FUND;
                    vm.txtDescripcionFParte = oCEntTFFS.DESCRIP_TEXT_FPARTE;
                    vm.txtDescripcionRetrotraer = oCEntTFFS.DESCRIP_TEXT_RETROTRAER;
                    vm.txtDescripcionOtro = oCEntTFFS.DESCRIP_TEXT_OTRO;
                    vm.txtDescripcionOtros = oCEntTFFS.DESCRIP_TEXT_OTROS;
                    vm.txtDescripcionSentido = oCEntTFFS.DESCRIP_TEXT_SENTIDO;

                    vm.ddlConfirmaResol_EstDeterminaCaducidad = vm.ListConfirmaResol_EstDeterminaCaducidad.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlConfirmaResol_EstDeterminaCaducidadId = oCEntTFFS.MAE_ESTDETERMINA_CADUCIDAD;
                    vm.ddlConfirmaResol_EstDeterminaMulta = vm.ListConfirmaResol_EstDeterminaMulta.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlConfirmaResol_EstDeterminaMultaId = oCEntTFFS.MAE_ESTDETERMINA_MULTA;
                    vm.ddlConfirmaResol_EstDeterminaMCorrectiva = vm.ListConfirmaResol_EstDeterminaMCorrectiva.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlConfirmaResol_EstDeterminaMCorrectivaId = oCEntTFFS.MAE_ESTDETERMINA_MCORRECTIVA;

                    CEntidad oParams = new CEntidad();
                    oParams.TAB_MAESTRO = oCEntTFFS.MAE_TIP_DETERMI;
                    List<CEntidad> oListaTFFS = new List<CEntidad>();
                    //oCEntTFFS.ListComboDeterminaRes = oCLogicaTFFS.ListarMaestroTFFS(oParams);
                    //vm.ddlDetermina_Motivo = oCEntTFFS.ListComboDeterminaRes.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    //vm.ddlDetermina_MotivoId = oCEntTFFS.MAE_TIP_MOT_DETERMI;

                    vm.txtDescripcionSuspension = oCEntTFFS.DESCRIP_TEXT_SUSPENSION;
                    vm.txtDescripcionCumplimiento = oCEntTFFS.DESCRIP_TEXT_CUMPLIMIENTO;
                    vm.txtDescripcionDesestimiento = oCEntTFFS.DESCRIP_TEXT_DESESTIMIENTO;
                    vm.txtDetermina_Multa = oCEntTFFS.MULTA2;
                    //------infracciones-------
                    vm.ddlTipoAprovechamientoId = oCEntTFFS.TIPO_APROVECHAMIENTO;
                    vm.ddlEspeciesFlora = vm.listaEspeciesFloraCombo.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlEspeciesFloraId = oCEntTFFS.ESPECIES_FLORA;
                    vm.ddlEspeciesFauna = vm.listaEspeciesFaunaCombo.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlEspeciesFaunaId = oCEntTFFS.ESPECIES_FAUNA;
                    vm.txtNumeroIndividuos = oCEntTFFS.NUMERO_INDIVIDUOS.ToString();
                    //------------------------
                    vm.ddlDetermina_DocRetrotrae = oCEntTFFS.MAE_TIP_DOC_RETRO;
                    vm.txtDetermina_DesDocRetrotrae = oCEntTFFS.DOC_RETRO;

                    vm.ddlEstadoPAU = vm.ListEstadoPAU.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlEstadoPAUId = oCEntTFFS.ESTADO_PAU;

                    vm.txtArchivoAdjunto = oCEntTFFS.ARCHIVO_ADJUNTO;

                    vm.txtTitular = oCEntTFFS.TITULAR_INT;
                    vm.txtResponsable = oCEntTFFS.RESPONSABLE_SOL;
                    vm.txtRegente = oCEntTFFS.REGENTE;
                    vm.txtARFFS2 = oCEntTFFS.ARFFS2;
                    vm.txtATFFS = oCEntTFFS.ATFFS;
                    vm.txtMinPublico = oCEntTFFS.MINPUBLICO;
                    vm.txtMinEnergia = oCEntTFFS.MINENERGIA;
                    vm.txtColeInge = oCEntTFFS.COLEINGE;
                    vm.txtOCI = oCEntTFFS.OCI;
                    vm.txtOEFA = oCEntTFFS.OEFA;
                    vm.txtSUNAT = oCEntTFFS.SUNAT;
                    vm.txtSERFOR = oCEntTFFS.SERFOR;
                    vm.txtOtros = oCEntTFFS.OTROS;
                    vm.txtDFFFS = oCEntTFFS.DFFFS;
                    vm.txtDSFFS = oCEntTFFS.DSFFS;
                    vm.txtURH = oCEntTFFS.URH;
                    vm.txtOCI2 = oCEntTFFS.OCI2;
                    vm.txtOtros2 = oCEntTFFS.OTROS2;
                    vm.txtnomArchOriginal = vm.txtArchivoAdjunto;

                    vm.chkTitular = oCEntTFFS.CHKTITULAR == 1 ? true : false; ;
                    vm.chkResponsable = oCEntTFFS.CHKRESPONSABLE == 1 ? true : false; ;
                    vm.chkRegente = oCEntTFFS.CHKREGENTE == 1 ? true : false; ;
                    vm.chkARFFS = oCEntTFFS.CHKARFFS2 == 1 ? true : false; ;
                    vm.chkATFFS = oCEntTFFS.CHKATFFS == 1 ? true : false; ;
                    vm.chkMinPublico = oCEntTFFS.CHKMINPUBLICO == 1 ? true : false; ;
                    vm.chkMinEnergia = oCEntTFFS.CHKMINENERGIA == 1 ? true : false; ;
                    vm.chkColeInge = oCEntTFFS.CHKCOLEINGE == 1 ? true : false; ;
                    vm.chkOCI = oCEntTFFS.CHKOCI == 1 ? true : false; ;
                    vm.chkOEFA = oCEntTFFS.CHKOEFA == 1 ? true : false; ;
                    vm.chkSUNAT = oCEntTFFS.CHKSUNAT == 1 ? true : false; ;
                    vm.chkSERFOR = oCEntTFFS.CHKSERFOR == 1 ? true : false; ;
                    vm.chkOtros = oCEntTFFS.CHKOTROS == 1 ? true : false; ;
                    vm.chkDFFFS = oCEntTFFS.CHKDFFFS == 1 ? true : false; ;
                    vm.chkDSFFS = oCEntTFFS.CHKDSFFS == 1 ? true : false; ;
                    vm.chkURH = oCEntTFFS.CHKURH == 1 ? true : false; ;
                    vm.chkOCI2 = oCEntTFFS.CHKOCI2 == 1 ? true : false; ;
                    vm.chkOtros2 = oCEntTFFS.CHKOTROS2 == 1 ? true : false; ;

                    //vm.txtnomArchOriginal = (oCEntTFFS.NOMBRE_ARCHIVO == null) ? "" : oCEntTFFS.NOMBRE_ARCHIVO;
                    vm.txtnomArchTemporal = (oCEntTFFS.NOMBRE_TEMPORAL_ARCHIVO == null) ? "" : oCEntTFFS.NOMBRE_TEMPORAL_ARCHIVO;
                    //vm.txtextArch = (oCEntTFFS.EXTENSION_ARCHIVO == null) ? "" : oCEntTFFS.EXTENSION_ARCHIVO;
                    //vm.txtestadoArch = "0";
                    //vm.txtcCodificacionSiTD = (oCEntTFFS.cCodificacion_SiTD == null) ? "" : oCEntTFFS.cCodificacion_SiTD;

                    //vm.txtFEmisionBExtraccion = oCEntTFFS.FEMISION_BEXTRACION.ToString();
                    vm.ddlArticulos = vm.ListArticulo.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlArticulosId = oCEntTFFS.ARTICULO;
                    vm.txtDescInfrac = oCEntTFFS.DESCRIP_TEXT_INFRACCION;
                    vm.ddlPOA = vm.ListPOA.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlPOAId = oCEntTFFS.POA;
                    //vm.ddlTipoAprovechamiento = vm.ListTipoAprovechamiento.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlTipoAprovechamientoId = oCEntTFFS.TIPO_APROVECHAMIENTO;
                    vm.ddlEspeciesFlora = vm.listaEspeciesFloraCombo.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlEspeciesFloraId = oCEntTFFS.ESPECIES_FAUNA;
                    vm.ddlEspeciesFauna = vm.listaEspeciesFaunaCombo.Select(i => new VM_Cbo { Value = i.CODIGO, Text = i.DESCRIPCION });
                    vm.ddlEspeciesFaunaId = oCEntTFFS.ESPECIES_FLORA;


                    vm.txtProfesional = oCEntTFFS.PROFESIONAL;
                    vm.txtCargo = oCEntTFFS.CARGO;

                    if (oCEntTFFS.ListPOAs.Count == 0)
                    {
                        CEntidad oCEntPOAs = new CEntidad();
                        oCEntPOAs.BusFormulario = "TFFS";
                        oCEntPOAs.BusCriterio = "LISTA_POAS";
                        oCEntPOAs.TIPO = "TFFS";
                        oCEntPOAs.BusValor = vm.hdfCodTFFS;
                        oCEntPOAs = oCLogicaTFFS.RegMostListPOAs(oCEntPOAs);
                        oCEntTFFS.ListPOAs = oCEntPOAs.ListPOAs;
                    }
                    vm.ListPOA = oCEntTFFS.ListPOAs;
                    vm.ListPOAOBSERVATORIO = oCEntTFFS.ListPOAs;
                    //HerUtil.GrillaLlenar(grvItemISupMaderable, oCEntTFFS.ListEMaderable, 0);
                    //HerUtil.GrillaLlenar(grvSemillero, oCEntTFFS.ListEMaderableSemillero, 0);
                    vm.chkCambiaEstEspecieISuperv = (Boolean)oCEntTFFS.CAMBIA_ESTADO_ESPECIES;
                    //Maderable
                    vm.lbtnMaderable = String.Format("Ir Datos Campo Maderable (Datos Campo: {0})", oCEntTFFS.ListEMaderable.Count.ToString());
                    //Maderable Semillero
                    vm.lbtnSemilleroMaderable = String.Format("Ir Datos Semillero Maderable (Datos Campo: {0})", oCEntTFFS.ListEMaderableSemillero.Count.ToString());
                }
            }
            catch (Exception)
            {
                //Activando Tabs
                //HerUtil.MensajeBox(this, ex.Message.ToString(), eMensajeTipo.Msgerror);
            }
            return vm;
        }
        public void initCombosRD2(VM_ResolucionTFFS vmRD)
        {
            CEntidad oCEntidad = new CEntidad();
            oCEntidad.BusFormulario = "TFFS";
            oCEntidad.BusCriterio = "LISTA_POAS";
            oCEntidad = this.RegMostCombo(oCEntidad);

            vmRD.ListApelacion = oCEntidad.ListComboRecursoApelacion;
            //vmRD.ListIndicador = oCEntidad.ListIndicadorTFFS;
            vmRD.ListTipoResolucion = oCEntidad.ListTipoTFFS;
            vmRD.ListCboSentidoRes = oCEntidad.ListComboSentidoRes;
            vmRD.ListCboRetrotraer = oCEntidad.ListComboRetrotraer;
            vmRD.ListDetermina_DocRetrotrae = oCEntidad.ListComboDocRetrotrae;
            if (oCEntidad.ListComboTipoProveido.Count() > 0)
            { vmRD.lstChkProveidoGenerar = true; }
            else
            { vmRD.lstChkProveidoGenerar = false; }
            vmRD.ListConfirmaResol_EstDeterminaCaducidad = oCEntidad.ListComboEstadoDetermina;  //ListComboEstadoDetermina
            vmRD.ListConfirmaResol_EstDeterminaMulta = oCEntidad.ListComboEstadoDetermina;  //ListComboEstadoDetermina
            vmRD.ListConfirmaResol_EstDeterminaMCorrectiva = oCEntidad.ListComboEstadoDetermina;  //ListComboEstadoDetermina
            vmRD.ListaConfirmaResol = oCEntidad.ListConfirmResol;
            vmRD.ListOtros = oCEntidad.ListOtros;
            vmRD.ListEstadoPAU = oCEntidad.ListEstadoPAU;
            vmRD.ListImpro = oCEntidad.ListImprocedente;
            vmRD.ListInadm = oCEntidad.ListInadmisible;
            vmRD.ListNulidad = oCEntidad.ListNulidad;
            vmRD.ListDetermina_DocRetrotrae = oCEntidad.ListComboTipoProveido;
            vmRD.ListNulidadOficio = oCEntidad.ListNulidadOficio;
            vmRD.ListaUbigeoDepartamento = oCEntidad.ListUbigeo;
            vmRD.ListEstadoPAU = oCEntidad.ListEstadoPAU;
            vmRD.ListMedCorrect = oCEntidad.ListMedCorrectivas;
            //------------infracciones-------------------------------------
            vmRD.ListTipoAprovechamiento = oCEntidad.ListTipoAprovechamiento;
            vmRD.ListArticulo = oCEntidad.ListArticulo;
            vmRD.ListPOA = oCEntidad.ListPOA;
            vmRD.listaEspeciesFloraCombo = oCEntidad.ListFlora;
            vmRD.listaEspeciesFaunaCombo = oCEntidad.ListFauna;



        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        public String RegGrabaResolucion_TFFS(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegGrabaResolucion_TFFS(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al grabar, comuníquese con el administrador.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oCampoEntrada"></param>
        /// <returns></returns>
        /// 

        //añadido 19-10-2020
        public List<CEntidad> ListarOtrosTFFS(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ListarOtrosTFFS(cn, oCampoEntrada);
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

        public List<CEntidad> ListarMaestroTFFS(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ListarMaestroTFFS(cn, oCampoEntrada);
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
        /// 
        public List<CEntidad> ListarArticuloIncisoTFFS(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ListarArticuloIncisoTFFS(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public Int32 RegPreProcesarObservatorio(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegPreProcesarObservatorio(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        


        public void initBusquedaModalApeladas(VM_ResolucionTFFS vm)
        {
            List<Ent_SBusqueda> listCombo = new List<Ent_SBusqueda>();
            Ent_SBusqueda Combo = new Ent_SBusqueda();
            vm.sBusquedaApelada = new List<Ent_SBusqueda>();
            //vm.txtTituloInfraccion = "Infracciones presuntamente incurridas";

            listCombo = new List<Ent_SBusqueda>();
            Combo = new Ent_SBusqueda();
            Combo.Value = "RD_NUMERO";
            Combo.Text = "Resoluciones";
            listCombo.Add(Combo);

            vm.txtTituloModal = "Lista de Resoluciones";

            vm.hdfTipoDocumento = "RESOLUCIONES TFFS";

            vm.sBusquedaApelada = listCombo;
        }
        public void initListaTFFSApeladas(VM_ResolucionTFFS vm)
        {
            List<Ent_SBusqueda> listCombo = new List<Ent_SBusqueda>();
            Ent_SBusqueda Combo = new Ent_SBusqueda();
            vm.sBusquedaTFFSApel = new List<Ent_SBusqueda>();
            //vm.txtTituloInfraccion = "Infracciones presuntamente incurridas";

            listCombo = new List<Ent_SBusqueda>();
            Combo = new Ent_SBusqueda();
            Combo.Value = "TFFS_NUMERO";
            Combo.Text = "Resoluciones_TFFS";
            listCombo.Add(Combo);

            vm.txtTituloModal = "Lista de Resoluciones";

            vm.hdfTipoDocumento = "RESOLUCIONES TFFS";

            vm.sBusquedaTFFSApel = listCombo;
        }
        public void initBusquedaModalPersonas(VM_ResolucionTFFS vm)
        {
            List<Ent_SBusqueda> listCombo = new List<Ent_SBusqueda>();
            Ent_SBusqueda Combo = new Ent_SBusqueda();
            vm.sBusquedaPersona = new List<Ent_SBusqueda>();

            listCombo = new List<Ent_SBusqueda>();
            Combo = new Ent_SBusqueda();
            Combo.Value = "NOMBRES";
            Combo.Text = "Nombres";
            listCombo.Add(Combo);

            Combo = new Ent_SBusqueda();
            Combo.Value = "DNI";
            Combo.Text = "DNI";
            listCombo.Add(Combo);

            vm.sBusquedaPersona = listCombo;
        }
        public CEntidad RegMostListPOAs(CEntidad oCEntidad)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegMostListPOAs(cn, oCEntidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CEntidad> RegImportarIncisos(CEntidad oCampoEntrada)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.RegImportarIncisos(cn, oCampoEntrada);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Tra_M_Tramite_tffs ConsultarTramite(string tramite)
        {
            try
            {
                using (OracleConnection cn = new OracleConnection(CapaDatos.BDConexion.Conexion_Cadena_SIGO()))
                {
                    cn.Open();
                    return oCDatos.ConsultarTramite(cn, tramite);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
