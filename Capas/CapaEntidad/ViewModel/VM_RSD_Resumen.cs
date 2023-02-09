using System.Collections.Generic;

namespace CapaEntidad.ViewModel
{
    public class VM_RSD_Resumen
    {
        public VM_RSD_Resumen()
        {
            this.LIST_INFRACCIONES = new List<VM_RSD_INFRACCIONES>();
        }

        public string COD_THABILITANTE { get; set; }        
        public string NUM_THABILITANTE { get; set; }
        public string COD_TITULAR { get; set; }
        public string TITULAR { get; set; }
        public string TITULAR_DOCUMENTO { get; set; }
        public string TITULAR_RUC { get; set; }
        public string COD_RLEGAL { get; set; }
        public string R_LEGAL { get; set; }
        public string R_LEGAL_DOCUMENTO { get; set; }
        public string R_LEGAL_RUC { get; set; }
        public string UBIGEO_DEPARTAMENTO { get; set; }
        public string UBIGEO_PROVINCIA { get; set; }
        public string UBIGEO_DISTRITO { get; set; }

        public virtual List<VM_RSD_INFRACCIONES> LIST_INFRACCIONES { get; set; }
    }

    public class VM_RSD_INFRACCIONES
    {
        public string COD_ILEGAL_ENCISOS { get; set; }
        public string DESCRIPCION_ARTICULOS { get; set; }
        public string DESCRIPCION_ENCISOS { get; set; }
        public string TEXTO_ENCISO { get; set; }
        public string COD_ESPECIES { get; set; }
        public string DESCRIPCION_ESPECIE { get; set; }
        public decimal VOLUMEN { get; set; }
        public decimal AREA { get; set; }
        public int NUMERO_INDIVIDUOS { get; set; }
        public string DESCRIPCION_INFRACCIONES { get; set; }
        public int COD_SECUENCIAL { get; set; }
        public string TIPOMADERABLE { get; set; }
        public string NUM_POA { get; set; }
        public string POA { get; set; }

    }
}
