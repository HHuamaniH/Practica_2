using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VM_Proveido
    {
        public string lblTituloCabecera { get; set; }
        public VM_ControlCalidad_2 vmControlCalidad { get; set; }
        public string hdfCodProvedio { get; set; }
        public string hdfCodTipoProve { get; set; }
        public string txtTipoProveido { get; set; }
        public Int32 RegEstado { get; set; }
        public string txtFechaEmision { get; set; }
        public string txtResolucionDirectoral { get; set; }
        public string txtResolucionTribunal { get; set; }
        public bool chkResFundado { get; set; }
        public bool chkResInfundado { get; set; }
        public bool chkResImprocedente { get; set; }
        public string txtNroDocumentoSITD { get; set; }
        public string txtDocumentoSITD { get; set; }
        public string txtCodDocumentoSITD { get; set; }
        public string txtFechaDocumentoSITD { get; set; }
        public string txtAsuntoSITD { get; set; }
        public string pdf_id_tram_envioSITD { get; set; }

        public string txtObservaciones { get; set; }

        public bool chkConceder { get; set; }
        public bool chkImprocedente { get; set; }
        public bool chkInadmisible { get; set; }
        //para la busqueda de expedientes
        public string txtTituloModal { get; set; }
        public string txtIdODs { get; set; }
        public string txtReferencia { get; set; }
        /// <summary>
        /// variables para el registro de profesionales
        /// </summary>
        public string txtProfesional { get; set; }
        public string hdfCodProfesional { get; set; }
        public string txtCargo { get; set; }

        public bool chkMandato { get; set; }
        public string txtDescripcionMandato { get; set; }
        public Int32 txtDiasImpl { get; set; }
        public Int32 txtMesesImpl { get; set; }
        public List<Ent_PROVEIDOARCHIVO> ListMandatos { get; set; }

        public string txtSeDispone { get; set; }
        public string txtIdSobArchivo { get; set; }
        public string txtSobreArchivo { get; set; }
        public string txtIdMedida { get; set; }
        public string txtDictaMedida { get; set; }
        public string txtIdEmiteConst { get; set; }
        public bool chkNuevSuperv { get; set; }
        public bool chkEvidIrregular { get; set; }
        public bool chkSinIndicios { get; set; }
        public bool chkDefNot { get; set; }
        public bool chkDefTec { get; set; }
        public bool chkFallTit { get; set; }
        public bool chkArchTemp { get; set; }
        public bool chkSubsVoluntaria { get; set; }
        public string txtSubsVoluntaria { get; set; }
        public string txtOtros { get; set; }

        /// <summary>
        /// notificaciones
        /// </summary>
        public bool chkTitular { get; set; }
        public string txtTitular { get; set; }
        public bool chkDGFFS { get; set; }
        public string txtDescDGFFS { get; set; }
        public bool chkProgramaRegional { get; set; }
        public string txtDescProgramaRegional { get; set; }
        public bool chkMinPublico { get; set; }
        public string txtDescMinPublico { get; set; }
        public bool chkMINEMMIN { get; set; }
        public string txtDescMINEMMIN { get; set; }
        public bool chkColegioIng { get; set; }
        public string txtDescColegioIng { get; set; }
        public bool chkATFFS { get; set; }
        public string txtDescATFFS { get; set; }
        public bool chkOCI { get; set; }
        public string txtDescOCI { get; set; }
        public bool chkOEFA { get; set; }
        public string txtDescOEFA { get; set; }
        public bool chkSUNAT { get; set; }
        public string txtDescSUNAT { get; set; }
        public bool chkSERFOR { get; set; }
        public string txtDescSERFOR { get; set; }
        public bool chkConta { get; set; }
        public string txtContaDetalle { get; set; }
        public bool chktesoreria { get; set; }
        public string txtTesoreriaOsinfor { get; set; }
        public bool chkOTROS { get; set; }
        public string txtDescOTROS { get; set; }
        public bool chkTFFS { get; set; }
        public string txtDesTFFS { get; set; }
        public string txtIdFirmeza { get; set; }

        public string txtIdCaducidaF { get; set; }
        public string txtIdArt363IF { get; set; }
        public string txtIdMultaF { get; set; }
        public string txtIdMedcorrectivaF { get; set; }
        public string txtFechaFirmezaF { get; set; }
        public string txtResuelve { get; set; }
        public string txtIdTipoFirmeza { get; set; }
        public string txtIdTipoAgotada { get; set; }
        public string txtIdConfirRD { get; set; }
        public string txtRecomienda { get; set; }
        public string txtFechaCumpleMCorrectiva { get; set; }
        public bool chkCumpleMCorrectiva { get; set; }
        public string CumpleMCorrectivaDetalle { get; set; }
        public bool chkMedCaut { get; set; }

        public bool chckCaducidad { get; set; }
        public bool chkInfraccion { get; set; }
        public bool chkPM { get; set; }
        public bool chkGTF { get; set; }
        public bool chkTrozas { get; set; }
        public string txtExpedientePJ { get; set; }
        public string txtJuzagdo { get; set; }
        public string txtFechaJud { get; set; }
        public string txtIdNotPJ { get; set; }
        public string txtPlazoJud { get; set; }
        public string txtMandatoJudicial { get; set; }
        public string txtObservacionesTSC { get; set; }
        public bool chkCaducidadParte { get; set; }



        //listas 
        public List<Ent_PROVEIDOARCHIVO> ListOD { get; set; }
        /// <summary>
        /// lista de informes, expedientes
        /// </summary>
        public List<Ent_PROVEIDOARCHIVO> ListInfOrExp { get; set; }
        /// <summary>
        /// lista de funcionarios que firman el documento
        /// </summary>
        public List<Ent_PROVEIDOARCHIVO> ListFuncionario { get; set; }
        /// <summary>
        /// variable para la busqueda de expedientes
        /// </summary>
        public List<Ent_SBusqueda> sBusqueda { get; set; }
        public List<Ent_SBusqueda> ListComboFirmeza { get; set; }
        public List<Ent_SBusqueda> ListComboSubAgotada { get; set; }
        public List<Ent_SBusqueda> ListComboNotPJ { get; set; }


        public List<Ent_PROVEIDOARCHIVO> ListMComboTipoArchivo { get; set; }
        public List<Ent_PROVEIDOARCHIVO> ListMComboTipoMedidas { get; set; }
        public List<Ent_PROVEIDOARCHIVO> ListMComboEmiteConst { get; set; }
        public List<Ent_PROVEIDOARCHIVO> ListMComboTipoAgotadaVia { get; set; }
        public List<Ent_PROVEIDOARCHIVO> ListMComboTipoFirmeza { get; set; }
        public List<Ent_PROVEIDOARCHIVO> listEliTabla { get; set; }
        public List<Ent_PROVEIDOARCHIVO> listEliTablaProf { get; set; }
        public string hdfTipoProveido { get; set; }
        public bool cklCumpleDirectiva { get; set; }
        public bool chkIncumpleDirectiva { get; set; }       
    }
}
