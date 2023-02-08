using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_SOLINT
    {
        #region "Entidades y Propiedades"

        [Description("COD_FISNOTI")]
        public String COD_FISNOTI { get; set; }
        [Description("COD_FCTIPO")]
        public String COD_FCTIPO { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("NUMERO_SOLINT")]
        public String NUMERO_SOLINT { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }
        [Description("COD_OD_REGISTRO")]
        public String COD_OD_REGISTRO { get; set; }

        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }

        [Description("D_LINEA")]
        public String D_LINEA { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        //
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public Object OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }
        //
        [Description("NUMERO")]
        public String NUMERO { get; set; }
        [Description("TIPO_FISCALIZA")]
        public String TIPO_FISCALIZA { get; set; }

        [Description("COD_TIPO_DOCUMENTO")]
        public String COD_TIPO_DOCUMENTO { get; set; }
        [Description("DESCRIPCION_DOCUMENTO")]
        public String DESCRIPCION_DOCUMENTO { get; set; }
        [Description("COD_RESODIREC")]
        public String COD_RESODIREC { get; set; }
        [Description("COD_RESODIREC_INI_PAU")]
        public String COD_RESODIREC_INI_PAU { get; set; }

        [Description("COD_PTIPO")]
        public String COD_PTIPO { get; set; }
        [Description("COD_PSOLICITA")]
        public String COD_PSOLICITA { get; set; }
        [Description("COD_PDIRIGE")]
        public String COD_PDIRIGE { get; set; }
        [Description("COD_SOLINT")]
        public String COD_SOLINT { get; set; }
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("PSOLICITA")]
        public String PSOLICITA { get; set; }
        [Description("PDIRIGE")]
        public String PDIRIGE { get; set; }

        [Description("TIPO")]
        public String TIPO { get; set; }
        [Description("OUTPUTPARAM01")]
        public string OUTPUTPARAM01 { get; set; }
        [Description("EliTABLA")]
        public string EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public string EliVALOR01 { get; set; }
        [Description("DESCRIPCION")]
        public string DESCRIPCION { get; set; }

        [Category("FECHA"), Description("FECHA_EMISION")]
        public Object FECHA_EMISION { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        [Category("LIST"), Description("ListTipoDocumento")]
        public List<Ent_SOLINT> ListTipoDocumento { get; set; }
        [Category("LIST"), Description("ListInformes")]
        public List<Ent_SOLINT> ListInformes { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_SOLINT> ListEliTABLA { get; set; }

        #region "Constructor"
        public Ent_SOLINT()
        {
            RegEstado = -1;
        }
        #endregion

        #endregion
    }
}
