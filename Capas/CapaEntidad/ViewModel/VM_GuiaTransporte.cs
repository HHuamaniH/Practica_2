using System.Collections.Generic;
using CEntidad = CapaEntidad.DOC.Ent_GUIA_TRANSPORTE;
//using CEntidadPersona = CapaEntidad.DOC.Ent_GENEPERSONA;
namespace CapaEntidad.ViewModel
{
    public class VM_GuiaTransporte
    {


        public string Titulo { get; set; }
        public string SubTitulo { get; set; }

        public string TipoFormulario { get; set; }

        public string hdfManRegEstado { get; set; }
        public string txtNumGuia { get; set; }
        public string txtNomGuia { get; set; }
        public string txtSede { get; set; }
        public string txtItemFechaExp { get; set; }
        public bool chkOrigenConc { get; set; }
        public bool chkOrigenPerm { get; set; }
        public bool chkOrigenAut { get; set; }
        public bool chkOrigenBL { get; set; }
        public bool chkOrigenDesbloque { get; set; }
        public bool chkOrigenCambUso { get; set; }
        public bool chkOrigenPlant { get; set; }
        public bool chkOrigenPMConsolidado { get; set; }
        public bool chkOrigenOtros { get; set; }
        public bool chkPlanAmazonas { get; set; }
        public string txtItemFechaVen { get; set; }
        public string ddlPlanAmazonasId { get; set; }
        public string txtItemTituloHabilitante { get; set; }
        public string hdfItemCodTHabilitante { get; set; }
        public string rdbListTH { get; set; }
        public string txtItemNombreTitularh { get; set; }
        public string hdfCodTitularHab { get; set; }
        public string txtItemNombreRLegalh { get; set; }
        public string hdfCodRLegalHab { get; set; }
        public string txtNumPOA { get; set; }
        public string txtNumResPOA { get; set; }
        public string txtTipoPM { get; set; }
        public string lblItemEstUbigeo { get; set; }
        public string hdfItemEstUbigeoCodigo { get; set; }
        public string txtDireccionHabilitante { get; set; }
        public string txtDNIHab { get; set; }
        public string txtRucHab { get; set; }
        public string txtNomProp { get; set; }
        public string hdfCodPropietario { get; set; }
        public string txtDNIProp { get; set; }
        public string txtRucProp { get; set; }
        public string txtDireccProp { get; set; }
        public string txtTipoComprobante { get; set; }
        public string txtNumComprobante { get; set; }
        public string txtNomDest { get; set; }
        public string hdfCodDestinatario { get; set; }
        public string txtDirecDest { get; set; }
        public string txtDNIDest { get; set; }
        public string txtRucDest { get; set; }
        public string lblItemEstUbigeo1 { get; set; }
        public string hdfItemEstUbigeoCodigo1 { get; set; }
        public string txtReciboProd { get; set; }
        public string txtMontoProduct { get; set; }
        public string txtReciboCanon { get; set; }
        public string txtMontoCanon { get; set; }
        public string txtTipoTransp { get; set; }
        public string txtPlacaTransp { get; set; }
        public string txtNomCondTransp { get; set; }
        public string hdfCodConductor { get; set; }
        public string txtLicTransp { get; set; }
        public string txtZafra { get; set; }
        public string txtObservacion { get; set; }
        public string txtAutorizado { get; set; }
        public string hdfCodAutorizante { get; set; }
        public string txtObserGuia { get; set; }
        public string txtOrigenOtros { get; set; }
        public string txtTipoProducto { get; set; }
        public string txtPeso { get; set; }
        public string txtDespachado { get; set; }
        public string hdfCodDespachante { get; set; }
        public string lblArchivoSeleccionado { get; set; }
        public string codUGrupo { get; set; }
        public string codSPerfils { get; set; }

        public List<CEntidad> ListProducto { get; set; }
        public List<CEntidad> ListEliTABLA { get; set; }
        public string COD_GUIA_TRANS { get; set; }


        public string GTF_ARCHIVO { get; set; }
        public string GTF_ARCHIVO_TEXT { get; set; }
        //0= no subido   1=si subido
        public string archivoSubido { get; set; }
    }



}
