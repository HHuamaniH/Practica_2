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
        
        public bool DGFFS { get; set; }
        public bool PROGRAMA_REGIONAL { get; set; }
        public bool MINISTERIO_PUBLICO { get; set; }
        public bool MIN_ENERGIA_MINAS { get; set; }
        public bool COLEGIO_INGENIEROS { get; set; }
        public bool ATFFS { get; set; }
        public bool OCI { get; set; }
        public bool OEFA { get; set; }
        public bool SUNAT { get; set; }
        public bool SERFOR { get; set; }
        public bool OTROS { get; set; }
        public string DETALLE_DGFFS { get; set; }
        public string DETALLE_PROREG { get; set; }
        public string DETALLE_MINPUB { get; set; }
        public string DETALLE_MINENMIN { get; set; }
        public string DETALLE_COLING { get; set; }
        public string DETALLE_ATFFS { get; set; }
        public string DETALLE_OCI { get; set; }
        public string DETALLE_OEFA { get; set; }
        public string DETALLE_SUNAT { get; set; }
        public string DETALLE_SERFOR { get; set; }
        public string DETALLE_OTROS { get; set; }

        public virtual List<VM_RSD_INFRACCIONES> LIST_INFRACCIONES { get; set; }
    }

    public class VM_RSD_INFRACCIONES
    {
        public string COD_ILEGAL_ENCISOS { get; set; }
        public string DESCRIPCION_ARTICULOS { get; set; }
        public string DESCRIPCION_ENCISOS { get; set; }
        public string TEXTO_ENCISO { get; set; }
        public string GRAVEDAD { get; set; }
        public int? TIPO_INFRACCION { get; set; }
        public string RANGO_SANCION { get; set; }
        public string COD_ESPECIES { get; set; }
        public string DESCRIPCION_ESPECIE { get; set; }
        public decimal VOLUMEN { get; set; }
        public decimal AREA { get; set; }
        public int NUMERO_INDIVIDUOS { get; set; }
        public string DESCRIPCION_INFRACCIONES { get; set; }
        public int COD_SECUENCIAL { get; set; }
        public string TIPOMADERABLE { get; set; }
        public string NUM_POA { get; set; }
        //public string POA { get; set; }

    }
}
