using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_INFTIT
    {
        #region "Entidades y Propiedades"
        [Description("COD_INFTIT")]
        public String COD_INFTIT { get; set; }
        [Description("COD_FCTIPO")]
        public String COD_FCTIPO { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("COD_UBIGEO")]
        public String COD_UBIGEO { get; set; }
        [Description("TIPO")]
        public String TIPO { get; set; }
        [Description("NUMERO_INFTIT")]
        public String NUMERO_INFTIT { get; set; }
        //
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public Object OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }

        [Description("D_LINEA")]
        public String D_LINEA { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        //
        [Description("COD_INFTIT_AUXILIAR")]
        public String COD_INFTIT_AUXILIAR { get; set; }
        [Description("FUNDAMENTOS_PRESENTADOS")]
        public String FUNDAMENTOS_PRESENTADOS { get; set; }

        [Description("UBIGEO_DESCARGO")]
        public String UBIGEO_DESCARGO { get; set; }
        [Description("TELEFONO")]
        public String TELEFONO { get; set; }
        [Description("DIRECCION")]
        public String DIRECCION { get; set; }
        [Description("CORREO_ELECTRONICO")]
        public String CORREO_ELECTRONICO { get; set; }
        [Description("COD_INFTIT_DESCARGO_TIPO")]
        public String COD_INFTIT_DESCARGO_TIPO { get; set; }

        [Description("COD_RESODIREC")]
        public String COD_RESODIREC { get; set; }
        [Description("COD_RESODIREC_INI_PAU")]
        public String COD_RESODIREC_INI_PAU { get; set; }
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_ILEGAL")]
        public String COD_ILEGAL { get; set; }

        [Description("COD_PMANEJO")]
        public String COD_PMANEJO { get; set; }
        [Description("NUM_POA")]
        public int NUM_POA { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }

        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("v_currentpage")]
        public Int32 v_currentpage { get; set; }
        [Description("v_pagesize")]
        public Int32 v_pagesize { get; set; }
        [Description("v_row_index")]
        public Int32 v_row_index { get; set; }


        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("COD_PARENTESCO")]
        public String COD_PARENTESCO { get; set; }
        [Description("FIRMA_LEGALIZADA")]
        public Object FIRMA_LEGALIZADA { get; set; }

        [Description("PERSONAFIRMA")]
        public String PERSONAFIRMA { get; set; }
        [Description("PERSONATIPO")]
        public String PERSONATIPO { get; set; }
        [Description("COD_PTIPO")]
        public String COD_PTIPO { get; set; }
        [Description("NUMERO")]
        public String NUMERO { get; set; }
        [Description("COD_SECUENCIAL")]
        public int COD_SECUENCIAL { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }
        [Description("COD_OD_REGISTRO")]
        public String COD_OD_REGISTRO { get; set; }

        [Description("TIPO_FISCALIZA")]
        public String TIPO_FISCALIZA { get; set; }
        [Description("COD_UBIGEO_DESCARGO")]
        public String COD_UBIGEO_DESCARGO { get; set; }

        [Description("APELLIDOS_NOMBRES")]
        public String APELLIDOS_NOMBRES { get; set; }
        [Description("UBIGEO")]
        public String UBIGEO { get; set; }

        [Description("MONTO_CUOTA")]
        public Decimal MONTO_CUOTA { get; set; }
        [Description("NUMERO_CUOTAS")]
        public int NUMERO_CUOTAS { get; set; }

        [Description("EliTABLA")]
        public string EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public string EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public int EliVALOR02 { get; set; }

        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("OUTPUTPARAM01")]
        public String OUTPUTPARAM01 { get; set; }

        [Category("FECHA"), Description("FECHA_PRESENTACION")]
        public Object FECHA_PRESENTACION { get; set; }
        [Category("FECHA"), Description("FECHA_EMISION")]
        public Object FECHA_EMISION { get; set; }

        [Category("FECHA"), Description("FECHA_INICIO")]
        public Object FECHA_INICIO { get; set; }
        [Category("FECHA"), Description("FECHA_FIN")]
        public Object FECHA_FIN { get; set; }


        //cambios en el formulario
        [Description("DOMICILIO_PROCESAL")]
        public String DOMICILIO_PROCESAL { get; set; }
        [Description("AUDIENCIA_ORAL")]
        public Object AUDIENCIA_ORAL { get; set; }
        [Description("APELAR_MEDCAUT")]
        public Object APELAR_MEDCAUT { get; set; }
        [Description("MEDIDAS_CAUTELARES")]
        public Object MEDIDAS_CAUTELARES { get; set; }

        [Category("LIST"), Description("ListInformes")]
        public List<Ent_INFTIT> ListInformes { get; set; }
        [Category("LIST"), Description("ListProfesionalFirma")]
        public List<Ent_INFTIT> ListProfesionalFirma { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_INFTIT> ListEliTABLA { get; set; }
        [Category("LIST"), Description("ListMComboOD")]
        public List<Ent_INFTIT> ListMComboOD { get; set; }
        [Category("LIST"), Description("ListMComboCategoria")]
        public List<Ent_INFTIT> ListMComboCategoria { get; set; }
        [Category("LIST"), Description("ListMComboDIdentidad")]
        public List<Ent_INFTIT> ListMComboDIdentidad { get; set; }
        [Category("LIST"), Description("ListIndicador")]
        public List<Ent_INFTIT> ListIndicador { get; set; }
        [Category("LIST"), Description("ListTipoCNotificacion")]
        public List<Ent_INFTIT> ListTipoCNotificacion { get; set; }
        [Category("LIST"), Description("ListTipoProfesional")]
        public List<Ent_INFTIT> ListTipoProfesional { get; set; }
        [Category("LIST"), Description("ListBusqueda")]
        public List<Ent_INFTIT> ListBusqueda { get; set; }
        [Category("LIST"), Description("ListTipoDescargo")]
        public List<Ent_INFTIT> ListTipoDescargo { get; set; }


        //Nuevas columnas: 29/11/2016
        [Description("NULIDAD")]
        public Object NULIDAD { get; set; }
        [Description("OBSERV_NULIDAD")]
        public String OBSERV_NULIDAD { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }

        [Description("IMPROCEDENCIA")]
        public Object IMPROCEDENCIA { get; set; }
        [Description("DOCUMENTO_IMPROCEDENCIA")]
        public String DOCUMENTO_IMPROCEDENCIA { get; set; }
        [Category("FECHA"), Description("FECHA_IMPROCEDENCIA")]
        public Object FECHA_IMPROCEDENCIA { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        public Ent_INFTIT()
        {
            RegEstado = -1;
            COD_SECUENCIAL = -1;
            MONTO_CUOTA = -1;
            EliVALOR02 = -1;
            NUMERO_CUOTAS = -1;
            NUM_POA = -1;
            v_currentpage = -1;
            v_pagesize = -1;
            v_row_index = -1;
        }


        #endregion
    }
}
