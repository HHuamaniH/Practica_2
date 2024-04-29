using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
namespace CapaEntidad.ViewModel
{
    public class VM_THabilitante
    {
        public string hdCodigo_Thabilitante { get; set; }
        public string ItemTitulo { get; set; }
        public string hdfManRegEstado { get; set; }
        public bool chkManConsolidado { get; set; }
        public string cod_Modalidad { get; set; }
        //Datos Generales
        public IEnumerable<VM_Cbo> ddlODRegistro { get; set; }
        public string ddlODRegistroId { get; set; }
        public string txtItemModalidad { get; set; }
        public string txtItemModalidadId { get; set; }
        public string lblTitularTipoTitulo { get; set; }
        public string txtTitularTipo { get; set; }
        public string hdtxtTitularTipo { get; set; }
        public IEnumerable<VM_Cbo> ddTipo { get; set; }
        public string ddTipoId { get; set; }
        public IEnumerable<VM_Cbo> ddNivelApro { get; set; }
        public string ddNivelAproId { get; set; }
        public IEnumerable<VM_Cbo> ddClaseZoologico { get; set; }
        public string ddClaseZoologicoId { get; set; }
        public string ddClaseZoologicoRECId { get; set; }
        public bool chkItemPlanManejo { get; set; }
        public string hdfItemTitularCodigo { get; set; }
        public string hdfItemTitularTipo { get; set; }
        public string hdfItemTitularJuridico { get; set; }
        public string hdfItemRLegalCodigo { get; set; }
        public string fItemRLegalCodigo { get; set; }
        public bool mostrarDivRLegal { get; set; }
        public string txtItemNumero { get; set; }
        public string lblItemNumeroTitulo { get; set; }
        public string txtCodigoNumero { get; set; }
        public string lblCodigoNumero { get; set; }
        public string hdfItemTipo { get; set; } //C-Consolidado N-No Consolidado
        //Ubicacion
        public string hdfItemEstUbigeoCodigo { get; set; }
        public string fItemEstUbigeoCodigo { get; set; }
        public string lblItemEstUbigeo { get; set; }
        public string txtItemEstSector { get; set; }
        //Vertices
        public string ddplZonaZooId { get; set; }
        public string txtCEsteZoo { get; set; }
        public string txtCNorteZoo { get; set; }
        //Datos Adicionales
        public string txtItemAOtorgada { get; set; }
        public string txtItemABosque { get; set; }
        public bool chkItemContCuenta { get; set; }
        public string txtItemContFInicio { get; set; }
        public string txtItemContFFin { get; set; }
        //Resolución que aprueba el proyecto
        public string txtItemRAPNumero { get; set; }
        public string txtItemRAPFecha { get; set; }
        public string fItemRAPFuncionarioCodigo { get; set; }
        public string hdfItemRAPFuncionarioCodigo { get; set; }
        //Resolución que autoriza el funcionamiento
        public string txtItemRAFNumero { get; set; }
        public string txtItemRAFFecha { get; set; }
        public string fItemRAFFuncionarioCodigo { get; set; }
        public string hdfItemRAFFuncionarioCodigo { get; set; }
        //obligaciones contractuales
        public string lblObligacionContTitulo { get; set; }
        public string txtcaracter_ambiental { get; set; }
        public string txtcaracter_social { get; set; }
        public string txtcaracter_eresponsable { get; set; }
        public string txtConcesionario { get; set; }
        //Registro de Adendas
        public string txtEstadoAdenda { get; set; }
        public string hdfItemAdendaMod_ListIndex { get; set; }
        public string hdfItemAdendaMod_RegEstado { get; set; }
        public IEnumerable<VM_Cbo> ddlItemAdeMotivo { get; set; }
        public string ddlItemAdeMotivoId { get; set; }
        public string txtItemAdeFInicio { get; set; }
        public string txtItemAdeFecTer { get; set; }
        public string txtItemAdeNumTH { get; set; }
        public string txtArea { get; set; }
        public string txtItemAdeNumResol { get; set; }
        public string fItemCamTitularCodigo { get; set; }
        public string hdfItemCamTitularCodigo { get; set; }
        public string lblAdendaTitulo { get; set; }
        // public string hdfItemCamTitularTipo { get; set; }
        public string hdvalorjuridico { get; set; }
        //Vértices de la Adenda - es una tabla
        public string txtItemAdeObservacion { get; set; }
        //Listado de Adendas (Historial) - es tabla
        //Recategorización
        public IEnumerable<VM_Cbo> ddComoboMotivoRec { get; set; }
        public string ddComoboMotivoRecId { get; set; }
        public string txtFechaRecat { get; set; }
        public string txtNumRDRect { get; set; }
        public IEnumerable<VM_Cbo> ddModalidadTH { get; set; }
        public string ddModalidadTHId { get; set; }

        public IEnumerable<VM_Cbo> ddModalidadFRTH { get; set; }
        public string ddModalidadFRTHId { get; set; }

        public string txtObsRecat { get; set; }
        //Listado de Recategorización (Historial) - es tabla
        public string txtItemObservacion { get; set; }
        public string hdfItemModalidadCodigo { get; set; }
        public List<Ent_THABILITANTE> ListTDTTITULARES { get; set; }
        public List<Ent_THABILITANTE> ListAdendas { get; set; }
        public List<Ent_THABILITANTE> ListTDDVVERTICE { get; set; }
        public List<Ent_THABILITANTE> ListTDDVADEAREA { get; set; }
        public List<Ent_THABILITANTE> ListModalidadesTH { get; set; }
        public List<Ent_THABILITANTE> ListTHEstadoEsta { get; set; }
        public List<Ent_THABILITANTE> ListEliTABLA { get; set; }
        public string ltrItemEtiContratoTitulo { get; set; }
        //Dependencia Ubigeo
        public IEnumerable<VM_Cbo> ddlDependencia { get; set; }
        public string ddlDependenciaId { get; set; }
        public string appClient { get; set; }
        public string appData { get; set; }
        public Int16 opRegresar { get; set; }
        public Int32 hdfCodSecuencialAdenda { get; set; }

        public VM_ControlCalidad_2 vmControlCalidad { get; set; }

        // INI Establecimiento
        public IEnumerable<VM_Cbo> ddEstablecimientoTH { get; set; }
        public string ddEstablecimientoTHId { get; set; }
        public string txtFechaRDEstab { get; set; }
        public string txtNumRDEstab { get; set; }
        public string txtAFFSRDEstab { get; set; }

        public string txtFechaEstab { get; set; }
        public string txtDocumentoEstab { get; set; }
        public string txtAFFSEstab { get; set; }
        public string txtObsEstab { get; set; }
        // FIN Establecimiento

        //20.04.2020
        public string txtResolucionTitular { get; set; }
        public string txtNuevaResTitular { get; set; }
        public string txtNuevoContrato { get; set; }

        //23.06.2021
        public string txtCodCat { get; set; }

        //Error Material
        public List<Ent_ERRORMATERIAL> tbErrorMaterial_DGeneral { get; set; }
        public List<Ent_ERRORMATERIAL> tbErrorMaterial_DAdicional { get; set; }       
        
        //División Interna del Predio
        public List<Ent_DIVISIONINTERNA> tbDivisionInterna { get; set; }
        public List<Ent_TITULAR_RLEGAL> tbTitular_RLegal { get; set; }

        public IEnumerable<VM_Cbo> ddTHExtincion { get; set; }
        public string ddTHExtincionId { get; set; }
        public IEnumerable<Ent_THABILITANTE> ListTHExtincion { get; set; }
        public List<Ent_THABILITANTE> ListEliTABLAExt { get; set; }
        public string txtResolucionExt { get; set; }
        public string txtfechaExt { get; set; }
        public string txtObservacionExt { get; set; }
        public string txtEstado_TH { get; set; }
        //Datos del titular
        public string txtUbigeo { get; set; }
        public string txtDirecion { get; set; }
        public VM_THabilitante()
        {
            vmControlCalidad = new VM_ControlCalidad_2();
            tbDivisionInterna = new List<Ent_DIVISIONINTERNA>();
            tbTitular_RLegal = new List<Ent_TITULAR_RLEGAL>();
        }
    }

    public class VM_THA_Vertice
    {
        public string VERTICE { get; set; }
        public string ZONA { get; set; }
        public decimal COORDENADA_ESTE { get; set; }
        public decimal COORDENADA_NORTE { get; set; }
        public string OBSERVACION { get; set; }
        public int COD_SECUENCIAL { get; set; }
        public int RegEstado { get; set; }
        public string COD_MADENDA { get; set; }
        public int COD_AREA_SECUENCIAL { get; set; }
        public int COD_SECUENCIAL_ADENDA { get; set; }

   
    }
}
