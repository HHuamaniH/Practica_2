using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace CapaEntidad.DOC
{
    public class Ent_IntSIADO
    {
        #region "Entidades y Propiedades"

        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("CODCABINV")]
        public String CODCABINV { get; set; }
        [Description("SER_TITDOCSIADO")]
        public String SER_TITDOCSIADO { get; set; }
        [Description("SUBSER_TITDOCSIADO")]
        public String SUBSER_TITDOCSIADO { get; set; }
        [Description("TIP_TITDOCSIGO")]
        public String TIP_TITDOCSIGO { get; set; }
        [Description("SUBTIP_TITDOCSIGO")]
        public String SUBTIP_TITDOCSIGO { get; set; }
        [Description("TIPO_TITULO")]
        public String TIPO_TITULO { get; set; }
        [Description("SUBTIPO_TITULO")]
        public String SUBTIPO_TITULO { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        //TRA_INT
        [Description("DESCRIPGENERAL")]
        public String DESCRIPGENERAL { get; set; }
        [Description("TRAINT_OBSERVACION")]
        public String TRAINT_OBSERVACION { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("CODTRANSFERENCIA")]
        public String CODTRANSFERENCIA { get; set; }

        //DET_INV
        [Description("DETINV_CODDOC")]
        public String DETINV_CODDOC { get; set; }
        [Description("DETINV_DESCRIPCION")]
        public String DETINV_DESCRIPCION { get; set; }
        [Description("ORIGEN")]
        public String ORIGEN { get; set; }
        [Category("FECHA"), Description("DETINV_FECHA")]
        public String DETINV_FECHA { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public String OUTPUTPARAM01 { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM02")]
        public String OUTPUTPARAM02 { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM03")]
        public String OUTPUTPARAM03 { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM04")]
        public String OUTPUTPARAM04 { get; set; }

        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("Parametro")]
        public String Parametro { get; set; }

        [Category("LIST"), Description("ListFiles")]
        public List<Ent_IntSIADO> ListFiles { get; set; }
        [Category("LIST"), Description("ListEliFiles")]
        public List<Ent_IntSIADO> ListEliFiles { get; set; }
        [Category("LIST"), Description("ListExpedientes")]
        public List<Ent_IntSIADO> ListExpedientes { get; set; }

        //TemEliiminar
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public String EliVALOR02 { get; set; }


        #endregion

        #region "Constructor"
        public Ent_IntSIADO()
        {

        }
        #endregion
    }
    public class Ent_IntSIADO_V3
    {
        //DET_INV
        [Description("DETINV_CODDOC")]
        public String DETINV_CODDOC { get; set; }
        [Description("DETINV_DESCRIPCION")]
        public String DETINV_DESCRIPCION { get; set; }
        [Description("ORIGEN")]
        public String ORIGEN { get; set; }
    }
}
