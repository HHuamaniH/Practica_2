using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_ExSitu
    {
        public string thM { get; set; } //thModalidad
        public string thN { get; set; } //thNumero
        public string thT { get; set; } //thTitular
        public string thInd { get; set; } //thIndicador
        public string thMT { get; set; } //thCodMtipos
        public string codPm { get; set; } //codigo plan de manejo
        public List<Dictionary<string, string>> LtEsituAnual { get; set; }
        public List<Dictionary<string, string>> LtGen_Epecie { get; set; }
        public List<Dictionary<string, string>> LtBaIngreso { get; set; }
        public List<Dictionary<string, string>> LtBaEgreso { get; set; }
    }
    public class VM_ExSituItem
    {
        public string lblTitulo { get; set; }
        public string COD_PMANEJO { get; set; }
        public int COD_SECUENCIAL { get; set; }
        public string hdEstado { get; set; }
        public string txtItemESituIAnual_Ano { get; set; }
        public string txtItemESituIAnual_FEmision { get; set; }
        public string txtItemESituIAnual_FRecepcion { get; set; }
        public string hdtxtProfesional { get; set; }
        public string txtItemESituIAnual_PNR { get; set; }
        public bool chkItemAcorde_Tdr_Vigente { get; set; }
        public string txtItemESituIAnual_Observacion { get; set; }
        public string txtProfesional { get; set; }
        public string lblItemESituIAnual_PNC { get; set; }
        public string txtDni { get; set; }
    }
    public class VM_BalanceItem
    {
        public string lblTitulo { get; set; }
        public string COD_PMANEJO { get; set; }
        public int COD_SECUENCIAL { get; set; }
        public string hdEstado { get; set; }
        public string ddlbfs_especieId { get; set; }
        public List<VM_Cbo> ddlbfs_especie { get; set; }
        public string txtbfs_numero { get; set; }
        public string ddlbfs_motivo_Id { get; set; }
        public List<VM_Cbo> ddlbfs_motivo { get; set; }
        public string ddlbfs_documentoId { get; set; }
        public List<VM_Cbo> ddlbfs_documento { get; set; }
        public string txtbfs_num_documento { get; set; }
        public string txtbfs_femision { get; set; }
        public string txtbfs_frecepcion { get; set; }
        public string txtbfs_observacion { get; set; }
        public string hdTipo { get; set; }
        public List<Dictionary<string, string>> demo { get; set; }
    }
    public class VM_PGeneticoItem
    {
        public string lblTitulo { get; set; }
        public string COD_PMANEJO { get; set; }
        public int COD_SECUENCIAL { get; set; }
        public string hdEstado { get; set; }
        public string txtnum_resolucion { get; set; }
        public string txtfecha_emision_resolucion { get; set; }
        public string lblItemPGenetico_Observacion { get; set; }
        public string lblItemPGenetico_PNombre { get; set; }
        public string lblItemPGenetico_PDNI { get; set; }
        public string lblItemPGenetico_PCargo { get; set; }
        public string hdfItemPGenetico_PCodigo { get; set; }
    }
}
