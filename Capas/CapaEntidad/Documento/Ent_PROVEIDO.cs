using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_PROVEIDO
    {
        #region "Entidades y Propiedades"
        [Description("COD_PROVEIDO")]
        public String COD_PROVEIDO { get; set; }
        [Description("COD_FCTIPO")]
        public String COD_FCTIPO { get; set; }
        [Description("FCTIPO")]
        public string FCTIPO { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("NUMERO_PROVEIDO")]
        public String NUMERO_PROVEIDO { get; set; }
        [Category("FK"), Description("COD_FDERIVA")]
        public String COD_FDERIVA { get; set; }
        [Category("FK"), Description("COD_PDERIVA")]
        public String COD_PDERIVA { get; set; }
        [Category("FK"), Description("COD_DLINEA")]
        public String COD_DLINEA { get; set; }
        [Category("FECHA"), Description("FECHA_DERIVACION")]
        public Object FECHA_DERIVACION { get; set; }

        [Description("D_LINEA")]
        public String D_LINEA { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        //
        //
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public Object OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }
        //
        [Description("OBSERVACIONES")]
        public String OBSERVACIONES { get; set; }
        [Description("OUTPUTPARAM01")]
        public String OUTPUTPARAM01 { get; set; }

        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }

        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }

        [Description("NUMERO")]
        public String NUMERO { get; set; }

        [Description("RegEstado")]
        public int RegEstado { get; set; }
        [Description("COD_OD_REGISTRO")]
        public String COD_OD_REGISTRO { get; set; }

        [Description("EliTABLA")]
        public string EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public string EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public int EliVALOR02 { get; set; }

        [Description("COD_SECUENCIAL")]
        public int COD_SECUENCIAL { get; set; }
        [Description("COD_RESODIREC")]
        public string COD_RESODIREC { get; set; }
        [Description("COD_RESODIREC_INI_PAU")]
        public string COD_RESODIREC_INI_PAU { get; set; }
        [Description("COD_INFORME")]
        public string COD_INFORME { get; set; }

        [Description("FUNCIONARIO")]
        public string FUNCIONARIO { get; set; }
        [Description("PROFESIONAL")]
        public string PROFESIONAL { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        [Category("LIST"), Description("ListDirecionLinea")]
        public List<Ent_PROVEIDO> ListDirecionLinea { get; set; }
        [Category("LIST"), Description("ListInformes")]
        public List<Ent_PROVEIDO> ListInformes { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_PROVEIDO> ListEliTABLA { get; set; }
        [Category("LIST"), Description("ListDerivadopara")]
        public List<Ent_PROVEIDO> ListDerivadopara { get; set; }

        public List<Ent_PROVEIDO> ListODs { get; set; }


        public Ent_PROVEIDO()
        {
            RegEstado = -1;
            EliVALOR02 = -1;
            COD_SECUENCIAL = -1;
        }
        #endregion
    }
}
