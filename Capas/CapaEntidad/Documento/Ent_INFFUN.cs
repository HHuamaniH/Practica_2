using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace CapaEntidad.DOC
{
    public class Ent_INFFUN
    {
        public Ent_INFFUN()
        {
            RegEstado = -1;
            COD_SECUENCIAL = -1;
            v_currentpage = -1;
            v_pagesize = -1;
            v_row_index = -1;
        }

        #region "Entidades y Propiedades"
        [Description("COD_INFFUN")]
        public String COD_INFFUN { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("NUMERO_INFORME")]
        public String NUMERO_INFORME { get; set; }
        [Description("COD_FCTIPO")]
        public String COD_FCTIPO { get; set; }
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("TIPO")]
        public string TIPO { get; set; }
        [Description("COD_SENTIDAD")]
        public string COD_SENTIDAD { get; set; }
        [Description("DESCRIPCION_ENTIDAD")]
        public string DESCRIPCION_ENTIDAD { get; set; }
        [Description("DESCRIPCION_SUBENTIDAD")]
        public string DESCRIPCION_SUBENTIDAD { get; set; }

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
        [Description("NUMERO")]
        public string NUMERO { get; set; }
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
        [Description("v_currentpage")]
        public Int32 v_currentpage { get; set; }
        [Description("v_pagesize")]
        public Int32 v_pagesize { get; set; }
        [Description("v_row_index")]
        public Int32 v_row_index { get; set; }

        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("GRUPO")]
        public String GRUPO { get; set; }
        [Description("COD_RESODIREC")]
        public String COD_RESODIREC { get; set; }
        [Description("COD_RESODIREC_INI_PAU")]
        public String COD_RESODIREC_INI_PAU { get; set; }

        [Description("COD_SECUENCIAL")]
        public int COD_SECUENCIAL { get; set; }
        [Description("TIPO_FISCALIZA")]
        public string TIPO_FISCALIZA { get; set; }
        [Description("CONCLUSIONES")]
        public string CONCLUSIONES { get; set; }
        [Description("APELLIDOS_NOMBRES")]
        public string APELLIDOS_NOMBRES { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        [Description("OUTPUTPARAM01")]
        public String OUTPUTPARAM01 { get; set; }
        [Description("TIPO_REPORTE")]
        public string TIPO_REPORTE { get; set; }
        [Description("COD_INFFUN_ENTIDADES")]
        public String COD_INFFUN_ENTIDADES { get; set; }

        [Description("DESCRIPCION_DEPARTAMENTO")]
        public String DESCRIPCION_DEPARTAMENTO { get; set; }

        [Category("LIST"), Description("ListInformes")]
        public List<Ent_INFFUN> ListInformes { get; set; }
        [Category("LIST"), Description("ListarEntidades")]
        public List<Ent_INFFUN> ListarEntidades { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_INFFUN> ListEliTABLA { get; set; }
        [Category("LIST"), Description("ListBusqueda")]
        public List<Ent_INFFUN> ListBusqueda { get; set; }
        [Category("LIST"), Description("ListMComboCategoria")]
        public List<Ent_INFFUN> ListMComboCategoria { get; set; }
        [Category("LIST"), Description("ListMComboDIdentidad")]
        public List<Ent_INFFUN> ListMComboDIdentidad { get; set; }
        [Category("LIST"), Description("ListIndicador")]
        public List<Ent_INFFUN> ListIndicador { get; set; }
        [Category("LIST"), Description("ListMComboOD")]
        public List<Ent_INFFUN> ListMComboOD { get; set; }
        [Category("LIST"), Description("ListTipoCNotificacion")]
        public List<Ent_INFFUN> ListTipoCNotificacion { get; set; }

        //lista de profesionales 07/06/2017
        [Category("LIST"), Description("ListProfesionales")]
        public List<Ent_INFFUN> ListProfesionales { get; set; }

        //lista de entidad 23/10/2023
        [Category("LIST"), Description("ListEntidades")]
        public List<Ent_INFFUN> ListEntidades { get; set; }


        [Category("FECHA"), Description("FECHA_EMISION")]
        public Object FECHA_EMISION { get; set; }
        //[Category("FECHA"), Description("FECHA_DERIVACION")]
        //public Object FECHA_DERIVACION { get; set; }
        [Category("FECHA"), Description("FECHA_CREACION")]
        public Object FECHA_CREACION { get; set; }

        [Description("EliTABLA")]
        public string EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public string EliVALOR01 { get; set; }


        // 24/10/2023
        [Category("LIST"), Description("ListTipoSolicitud")]
        public List<Ent_INFFUN> ListTipoSolicitud { get; set; }

        [Category("LIST"), Description("ListVencimientoPlazoLegal")]
        public List<Ent_INFFUN> ListVencimientoPlazoLegal { get; set; }

        [Category("LIST"), Description("ListEstadoSolicitudFema")]
        public List<Ent_INFFUN> ListEstadoSolicitudFema { get; set; }

        #endregion

        #region ENTIDADES NUEVAS
        [Description("COD_ESTADO_SOLICITUD")]
        public string COD_ESTADO_SOLICITUD { get; set; }

        [Description("NUMERO_TRAMITE")]
        public string NUMERO_TRAMITE { get; set; }

        [Description("FECHA_TRAMITE")]
        public object FECHA_TRAMITE { get; set; }

        [Description("GLOSA")]
        public string GLOSA { get; set; }

        [Description("NUMERO_SOLICITUD")]
        public string NUMERO_SOLICITUD { get; set; }

        [Description("COD_TIPO_SOLICITUD")]
        public string COD_TIPO_SOLICITUD { get; set; }

        [Description("COD_VEN_LEGAL")]
        public string COD_VEN_LEGAL { get; set; }

        [Description("COD_UBIGEO")]
        public string COD_UBIGEO { get; set; }

        [Description("COD_PERSONA_ASIGNADO")]
        public string COD_PERSONA_ASIGNADO { get; set; }

        [Description("PERSONA_TITULAR")]
        public string PERSONA_TITULAR { get; set; }

        [Description("FLAG_INFFUN_EMITIDO")]
        public int? FLAG_INFFUN_EMITIDO { get; set; }

        [Description("FECHA_FIRMEZA")]
        public object FECHA_FIRMEZA { get; set; }

        [Description("NUMERO_OFICIO1")]
        public string NUMERO_OFICIO1 { get; set; }

        [Description("FECHA_OFICIO1")]
        public object FECHA_OFICIO1 { get; set; }

        [Description("FLAG_NO_INFUN_EMITIDO")]
        public int? FLAG_NO_INFUN_EMITIDO { get; set; }

        [Description("NUMERO_OFICIO2")]
        public string NUMERO_OFICIO2 { get; set; }

        [Description("FECHA_OFICIO2")]
        public object FECHA_OFICIO2 { get; set; }

        [Description("NOTA_NO_INFFUN")]
        public string NOTA_NO_INFFUN { get; set; }

        [Description("FLAG_COPIA_PAU_EMITIDO")]
        public int? FLAG_COPIA_PAU_EMITIDO { get; set; }

        [Description("NOTA_COPIA_PAU")]
        public string NOTA_COPIA_PAU { get; set; }

        [Description("FLAG_NOTIFICACION")]
        public int? FLAG_NOTIFICACION { get; set; }

        [Description("FECHA_NOTIFICACION")]
        public object FECHA_NOTIFICACION { get; set; }

        [Description("NOTA_NOTIFICACION")]
        public string NOTA_NOTIFICACION { get; set; }

        [Description("DIAS_HABILES_TRANS_NO_INFFUN")]
        public int? DIAS_HABILES_TRANS_NO_INFFUN { get; set; }

        [Description("DIAS_HAB_TRANSCURIDOS")]
        public int? DIAS_HAB_TRANSCURIDOS { get; set; }

        [Description("ESTAB_UBIGEO")]
        public String ESTAB_UBIGEO { get; set; }
        #endregion
    }
}
