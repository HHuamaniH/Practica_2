using System.Collections.Generic;
using CEntidad = CapaEntidad.DOC.Ent_DEVOLUCION_MADERA;

namespace CapaEntidad.ViewModel
{
    public class VM_DevolucionMadera
    {
        public string ItemTitulo { get; set; }
        public string TipoFormulario { get; set; }
        public string hdfManRegEstado { get; set; }


        public IEnumerable<VM_Cbo> ddlItemIndicador { get; set; }
        public string ddlItemIndicadorId { get; set; }
        public bool chkItemObsSubsanada { get; set; }

        public string txtControlCalidadObservaciones { get; set; }
        public string txtUsuarioRegistro { get; set; }
        public string txtUsuarioControl { get; set; }

        //Datos de Titulo Habilitante

        public string lblItemTHModalidad { get; set; }
        public string hdfItemCod_Devolucion { get; set; }
        public string hdfItemCod_THabilitante { get; set; }
        public string lblItemTHNumero { get; set; }
        public string lblItemTHTitular { get; set; }
        //Datos Generales
        public string ddlODRegistroId { get; set; }
        public IEnumerable<VM_Cbo> ddlODRegistro { get; set; }
        public string txtItemNumResolucion { get; set; }
        public string txtItemFechaResol { get; set; }
        public string hdfItemFunFirmaCodigo { get; set; }
        public string txtItemZafra_Ejec { get; set; }
        public string txtItemEjecucionInicio { get; set; }
        public string txtItemEjecucionFin { get; set; }
        public string txtItemItecnico_Raprobacion_Num { get; set; }
        public string txtItemItecnico_Raprobacion_Fecha { get; set; }
        public string txtItemFEmisionBExtracion { get; set; }
        public string lbtMaderableItemCensoTrozaSelec { get; set; }
        public string lbtMaderableItemCensoToconSelec { get; set; }
        public string lbtMaderableItemCensoArbolSelec { get; set; }
        public string lblItemFunFirma { get; set; }
        public string Rol { get; set; }

        public IEnumerable<VM_Cbo> ListMComboEspecies { get; set; }
        public IEnumerable<VM_Cbo> ddlItemCArbolCod_Eestado { get; set; }
        public IEnumerable<VM_Cbo> ddlItemCMaderableCod_Econdicion { get; set; }
        public IEnumerable<VM_Cbo> ddlItemCArbolCod_Econdicion { get; set; }

        public List<CEntidad> ListNUM_POA { get; set; }
        public List<CEntidad> ListPINFTEC { get; set; }
        public List<CEntidad> ListESPDEVUELTAS { get; set; }
        public List<CEntidad> ListVERTICE { get; set; }
        public List<CEntidad> ListESPHALLADAS { get; set; }
        public List<CEntidad> ListBEXTRACCION { get; set; }
        public List<CEntidad> ListDEVOLCENSOTROZA { get; set; }
        public List<CEntidad> ListDEVOLCENSOTOCON { get; set; }
        public List<CEntidad> ListDEVOLCENSOARBOL { get; set; }
        public List<CEntidad> ListDEVOLItemsDetalle { get; set; }
        public List<CEntidad> ListEliTABLA { get; set; }
        public bool TIENE_POA { get; set; }
    }

}
