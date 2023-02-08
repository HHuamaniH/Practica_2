using System;
using System.Collections.Generic;
using System.ComponentModel;
using CapaEntidad.DOC;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidad.DOC
{
    public class Ent_TFFS
    {
        [Description("COD_RESOLUCION_TFFS")]
        public String COD_RESOLUCION_TFFS { get; set; }
        [Description("COD_RESOLUCION_TFFS_RECTIFICA")]
        public String COD_RESOLUCION_TFFS_RECTIFICA { get; set; }
        [Description("NOMBRE_ARCHIVO")]
        public String NOMBRE_ARCHIVO { get; set; }
        [Description("NOMBRE_TEMPORAL_ARCHIVO")]
        public String NOMBRE_TEMPORAL_ARCHIVO { get; set; }
        [Description("EXTENSION_ARCHIVO")]
        public String EXTENSION_ARCHIVO { get; set; }
        [Description("ESTADO_ARCHIVO")]
        public String ESTADO_ARCHIVO { get; set; }
        [Description("cCodificacion_SiTD")]
        public String cCodificacion_SiTD { get; set; }
        [Description("NUM_RESOLUCION_TFFS")]
        public String NUM_RESOLUCION_TFFS { get; set; }
        [Description("RESOLUCION_TFFS")] //*
        public String MODALIDAD { get; set; }
        [Description("MODALIDAD")] //*
        public String RESOLUCION_TFFS { get; set; } //*
        [Description("NUMERO_INFORME")] //*
        public String NUMERO_INFORME { get; set; } //*
        [Description("FECHA")] //*
        public String FECHA { get; set; } //*
        [Description("FECHA_CREACION")] //*
        public String FECHA_CREACION { get; set; } //*
        [Description("DESTINATARIO")] //*
        public String DESTINATARIO { get; set; } //*
        [Description("DIRECCION")] //*
        public String DIRECCION { get; set; } //*
        [Description("RUTA")] //*
        public String RUTA { get; set; } //*
        [Description("FECHA_NOTIFICACION")] //*
        public String FECHA_NOTIFICACION { get; set; } //*
        [Description("COD_TIPO")]
        public String COD_TIPO { get; set; }
        [Description("DES_TIPO")]
        public String DES_TIPO { get; set; }
        [Description("COD_REFERENCIA")]
        public String COD_REFERENCIA { get; set; }
        [Description("DES_REFERENCIA")]
        public String DES_REFERENCIA { get; set; }
        [Category("FECHA"), Description("FECHA_DOCUMENTO")]
        public String FECHA_DOCUMENTO { get; set; }
        [Description("COD_RESUELVE")]
        public String COD_RESUELVE { get; set; }
        [Description("DES_RESUELVE")]
        public String DES_RESUELVE { get; set; }
        [Description("COD_DECLARA")]
        public String COD_DECLARA { get; set; }
        [Description("DES_DECLARA")]
        public String DES_DECLARA { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("OBSERVACIONES")]
        public String OBSERVACIONES { get; set; }
        // 7/8/2020
        //[Description("TIP_RESOTROS")]
        //public String TIP_RESOTROS { get; set; }


        //ESTADO SITUACIONAL DEL DOCUMENTO
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public Object OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }
        [Description("PUBLICAR")]
        public Object PUBLICAR { get; set; }
        [Description("COD_FENTIDAD")]
        public String COD_FENTIDAD { get; set; }
        [Description("ESTADO")]
        public String ESTADO { get; set; }

        //ATRIBUTOS DE BUSQUEDA
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public Int32 EliVALOR02 { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_TFFS> ListEliTABLA { get; set; }

        //COLUMNAS ENLACE
        [Description("COD_RESODIREC")]
        public String COD_RESODIREC { get; set; }
        [Description("COD_RESODIREC_INI_PAU")]
        public String COD_RESODIREC_INI_PAU { get; set; }
        [Description("D_LINEA")]
        public String D_LINEA { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("NT_HABILITANTE")]
        public String NT_HABILITANTE { get; set; }
        [Description("N_TITULAR_AD")]
        public String N_TITULAR_AD { get; set; }
        [Description("NUMERO")]
        public String NUMERO { get; set; }
        [Category("FK"), Description("COD_INFORME")]
        public String COD_INFORME { get; set; }

        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }

        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        [Description("OUTPUTPARAM01")]
        public String OUTPUTPARAM01 { get; set; }
        [Description("OUTPUTPARAM02")]
        public String OUTPUTPARAM02 { get; set; }

        [Category("LIST"), Description("ListTipoTFFS")]
        public List<Ent_TFFS> ListTipoTFFS { get; set; }
        [Category("LIST"), Description("ListIndicadorTFFS")]
        public List<Ent_TFFS> ListIndicadorTFFS { get; set; }
        //------agregado 19-10-2020  ---------sentido de resolucion-----------------------------------------------------
        [Category("LIST"), Description("ListComboSentidoRes")]
        public List<Ent_TFFS> ListComboSentidoRes { get; set; }
        //--------- determina resolucion
        [Category("LIST"), Description("ListComboDeterminaRes")]
        public List<Ent_TFFS> ListComboDeterminaRes { get; set; }
        //-------combo retrotraer
        [Category("LIST"), Description("ListComboRetrotraer")]
        public List<Ent_TFFS> ListComboRetrotraer { get; set; }
        [Category("LIST"), Description("ListMComboDIdentidad")]
        public List<Ent_TFFS> ListMComboDIdentidad { get; set; }
        [Category("LIST"), Description("ListODs")]
        public List<Ent_TFFS> ListODs { get; set; }
        [Category("LIST"), Description("ListParentesco")]
        public List<Ent_TFFS> ListParentesco { get; set; }
        [Category("LIST"), Description("ListEntidades")]
        public List<Ent_TFFS> ListEntidades { get; set; }
        [Category("LIST"), Description("ListImprocedente")]
        public List<Ent_TFFS> ListImprocedente { get; set; }
        [Category("LIST"), Description("ListInadmisible")]
        public List<Ent_TFFS> ListInadmisible { get; set; }
        [Category("LIST"), Description("ListNulidad")]
        public List<Ent_TFFS> ListNulidad { get; set; }
        [Category("LIST"), Description("ListNulidadOficio")]
        public List<Ent_TFFS> ListNulidadOficio { get; set; }
        [Category("LIST"), Description("ListConfirmResol")]
        public List<Ent_TFFS> ListConfirmResol { get; set; }
        [Category("LIST"), Description("ListOtros")]
        public List<Ent_TFFS> ListOtros { get; set; }
        [Category("LIST"), Description("ListEstadoPAU")]
        public List<Ent_TFFS> ListEstadoPAU { get; set; }
        [Category("LIST"), Description("ListUbigeo")]
        public List<Ent_TFFS> ListUbigeo { get; set; }
        [Category("LIST"), Description("ListMedCorrectivas")]
        public List<Ent_TFFS> ListMedCorrectivas { get; set; }
        [Category("LIST"), Description("ListTFFSApel")]
        public List<Ent_TFFS> ListTFFSApel { get; set; }
        [Category("LIST"), Description("ListPOAObservatorio")]
        public List<Ent_RESODIREC> ListPOAObservatorio { get; set; }
        [Category("LIST"), Description("ListTipoAprovechamiento")]
        public List<Ent_SBusqueda> ListTipoAprovechamiento { get; set; }
        [Category("LIST"), Description("ListArticulo")]
        public List<Ent_TFFS> ListArticulo { get; set; }
        [Category("LIST"), Description("ListPOA")]
        public List<Ent_TFFS> ListPOA { get; set; }
        //------------listar tipo documento--------------------

        [Category("LIST"), Description("ListFlora")]
        public List<Ent_TFFS> ListFlora { get; set; }
        [Category("LIST"), Description("ListFauna")]
        public List<Ent_TFFS> ListFauna { get; set; }
        [Description("ESPECIES_FLORA")]
        public String ESPECIES_FLORA { get; set; }
        [Description("ESPECIES_FAUNA")]
        public String ESPECIES_FAUNA { get; set; }
        // ---------------LISTA FLORA

        // ---------------LISTA FLORA

        [Category("LIST"), Description("ListTipoDocumento")]
        public List<Ent_TFFS> ListTipoDocumento { get; set; }
        //-----------variable @TIP_RES --------------
        [Description("TIP_RES")]
        public String TIP_RES { get; set; }
        //-----------variable RES_APE --------------
        [Description("RES_APE")]
        public String RES_APE { get; set; }
        //-----------variable QUEJA_OBS --------------
        [Description("QUEJA_OBS")]
        public String QUEJA_OBS { get; set; }
        //-----------variable RES_OTROS --------------
        [Description("RES_OTROS")]
        public String RES_OTROS { get; set; }
        //-----------variable OTROS_CUMPLI --------------
        [Description("OTROS_CUMPLI")]
        public String OTROS_CUMPLI { get; set; }
        //-----------variable OTROS_NULI --------------
        [Description("OTROS_NULI")]
        public String OTROS_NULI { get; set; }
        //-----------variable UBIGEO_DEPA --------------
        [Description("UBIGEO_DEPA")]
        public String UBIGEO_DEPA { get; set; }
        //-----------variable SENTIDO_RES --------------
        [Description("SENTIDO_RES")]
        public String SENTIDO_RES { get; set; }
        //-----------variable RESOL_DET --------------
        [Description("RESOL_DET")]
        public String RESOL_DET { get; set; }
        //-----------variable RESOL_IMPRO --------------
        [Description("RESOL_IMPRO")]
        public String RESOL_IMPRO { get; set; }
        //-----------variable RESOL_DET2 --------------
        [Description("RESOL_DET2")]
        public String RESOL_DET2 { get; set; }
        //-----------variable RESOL_DET3 --------------
        [Description("RESOL_DET3")]
        public String RESOL_DET3 { get; set; }
        //-----------variable RESOL_INAD --------------
        [Description("RESOL_INAD")]
        public String RESOL_INAD { get; set; }

        //-----------variable CHKCONFIRMAR --------------
        [Description("CHKCONFIRMAR")]
        public int CHKCONFIRMAR { get; set; }
        [Description("CHKCONFIRMAR2")]
        public int CHKCONFIRMAR2 { get; set; }
        //-----------variable CHKREVOCAR --------------
        [Description("CHKREVOCAR")]
        public int CHKREVOCAR { get; set; }
        [Description("RADREVOCAR")]
        public String RADREVOCAR { get; set; }
        [Description("RADREVOCARPARTE")]
        public String RADREVOCARPARTE { get; set; }
        [Description("RADREVOCARPARTE2")]
        public String RADREVOCARPARTE2 { get; set; }        
        [Description("RADNULIDAD")]
        public String RADNULIDAD { get; set; }
        [Description("CHKREVOCAR2")]
        public int CHKREVOCAR2 { get; set; }
        [Description("RADREVOCAR2")]
        public String RADREVOCAR2 { get; set; }
        [Description("RADNULIDAD2")]
        public String RADNULIDAD2 { get; set; }
        //-----------variable CHKREVOCARPARTE --------------
        [Description("CHKREVOCARPARTE")]
        public int CHKREVOCARPARTE { get; set; }
        [Description("CHKREVOCARPARTE2")]
        public int CHKREVOCARPARTE2 { get; set; }
        //-----------variable CHKRETROTRAER --------------
        [Description("CHKRETROTRAER")]
        public int CHKRETROTRAER { get; set; }
        [Description("RADRETROTRAER")]
        public String RADRETROTRAER { get; set; }
        [Description("RADRETROTRAER2")]
        public String RADRETROTRAER2 { get; set; }
        [Description("CHKRETROTRAER2")]
        public int CHKRETROTRAER2 { get; set; }
        //-----------variable CHKPRESCRIBIR --------------
        [Description("CHKPRESCRIBIR")]
        public int CHKPRESCRIBIR { get; set; }
        [Description("CHKPRESCRIBIR2")]
        public int CHKPRESCRIBIR2 { get; set; }
        //-----------variable CHKARCHIVAR --------------
        [Description("CHKARCHIVAR")]
        public int CHKARCHIVAR { get; set; }
        [Description("CHKARCHIVAR2")]
        public int CHKARCHIVAR2 { get; set; }
        //-----------variable CHKNULIDAD --------------
        [Description("CHKNULIDAD")]
        public int CHKNULIDAD { get; set; }
        [Description("CHKNULIDAD2")]
        public int CHKNULIDAD2 { get; set; }
        //-----------variable CHKLEVANTAR --------------
        [Description("CHKLEVANTAR")]
        public int CHKLEVANTAR { get; set; }
        [Description("CHKLEVANTAR2")]
        public int CHKLEVANTAR2 { get; set; }
        //-----------variable CHKCARECE --------------
        [Description("CHKCARECE")]
        public int CHKCARECE { get; set; }
        [Description("CHKCARECE2")]
        public int CHKCARECE2 { get; set; }
        //-----------variable CHKOTRO --------------
        [Description("CHKOTRO")]
        public int CHKOTRO { get; set; }
        [Description("CHKOTRO2")]
        public int CHKOTRO2 { get; set; }
        //-----------variable DET_FUNDADO1 --------------
        [Description("DET_FUNDADO1")]
        public String DET_FUNDADO1 { get; set; }
        //-----------variable DET_FUNDADO2 --------------
        [Description("DET_FUNDADO2")]
        public String DET_FUNDADO2 { get; set; }
        //-----------variable INFUND_CONF --------------
        [Description("INFUND_CONF")]
        public String INFUND_CONF { get; set; }
        //-----------variable TXT_CONFIRMAR --------------
        [Description("TXT_CONFIRMAR")]
        public String TXT_CONFIRMAR { get; set; }
        //-----------variable CMB_NULIDAD --------------
        [Description("CMB_NULIDAD")]
        public String CMB_NULIDAD { get; set; }
        //-----------variable CMB_NULIDAD2 --------------
        [Description("CMB_NULIDAD2")]
        public String CMB_NULIDAD2 { get; set; }
        //-----------variable TXT_RETROTRAER --------------
        [Description("TXT_RETROTRAER")]
        public String TXT_RETROTRAER { get; set; }
        //-----------variable TXT_CAJARETRO --------------
        [Description("TXT_CAJARETRO")]
        public String TXT_CAJARETRO { get; set; }
        //-----------variable RETRO_VALOR1 --------------
        [Description("RETRO_VALOR1")]
        public String RETRO_VALOR1 { get; set; }
        //-----------variable CMB_NULIDAD2 --------------
        //[Description("CMB_NULIDAD2")]
        //public String CMB_NULIDAD2 { get; set; }
        //-----------variable TXT_RETROTRAER2 --------------
        [Description("TXT_RETROTRAER2")]
        public String TXT_RETROTRAER2 { get; set; }
        //-----------variable DETER_RETROTRAER --------------
        [Description("DETERMINA_RETROTRAER")]
        public String DETERMINA_RETROTRAER { get; set; }
        //-----------variable DETER_RETROTRAER2 --------------
        [Description("DETERMINA_RETROTRAER2")]
        public String DETERMINA_RETROTRAER2 { get; set; }
        //-----------variable RETRO_VALOR2 --------------
        [Description("RETRO_VALOR2")]
        public String RETRO_VALOR2 { get; set; }
        //-----------variable TXT_CAJARETRO2 --------------
        [Description("TXT_CAJARETRO2")]
        public String TXT_CAJARETRO2 { get; set; }
        //-----------variable CMB_NULOTRO --------------
        [Description("CMB_NULOTRO")]
        public String CMB_NULOTRO { get; set; }
        //-----------variable TXT_RETROOTRO --------------
        [Description("TXT_RETROOTRO")]
        public String TXT_RETROOTRO { get; set; }
        //-----------variable RETRO_VALOR3 --------------
        [Description("RETRO_VALOR3")]
        public String RETRO_VALOR3 { get; set; }
        //-----------variable TXT_CAJARETRO3 --------------
        [Description("TXT_CAJARETRO3")]
        public String TXT_CAJARETRO3 { get; set; }
        //-----------variable DESCRIP_TEXT --------------
        [Description("DESCRIP_TEXT")]
        public String DESCRIP_TEXT { get; set; }
        [Description("DESCRIP_TEXT_IMPRO")]
        public String DESCRIP_TEXT_IMPRO { get; set; }
        [Description("DESCRIP_TEXT_INFU")]
        public String DESCRIP_TEXT_INFU { get; set; }
        [Description("DESCRIP_TEXT_INAD")]
        public String DESCRIP_TEXT_INAD { get; set; }
        [Description("DESCRIP_TEXT_FUND")]
        public String DESCRIP_TEXT_FUND { get; set; }
        [Description("DESCRIP_TEXT_FPARTE")]
        public String DESCRIP_TEXT_FPARTE { get; set; }
        [Description("DESCRIP_TEXT_RETROTRAER")]
        public String DESCRIP_TEXT_RETROTRAER { get; set; }
        [Description("DESCRIP_TEXT_RETROTRAER2")]
        public String DESCRIP_TEXT_RETROTRAER2 { get; set; }
        [Description("DESCRIP_TEXT_OTROS")]
        public String DESCRIP_TEXT_OTROS { get; set; }
        [Description("DESCRIP_TEXT_OTROS2")]
        public String DESCRIP_TEXT_OTROS2 { get; set; }
        [Description("DESCRIP_TEXT_OTRO")]
        public String DESCRIP_TEXT_OTRO { get; set; }
        [Description("DESCRIP_TEXT_SENTIDO")]
        public String DESCRIP_TEXT_SENTIDO { get; set; }
        [Description("DESCRIP_TEXT_INFRACCION")]
        public String DESCRIP_TEXT_INFRACCION { get; set; }
        [Description("DESCRIP_TEXT_SUSPENSION")]
        public String DESCRIP_TEXT_SUSPENSION { get; set; }
        [Description("DESCRIP_TEXT_CUMPLIMIENTO")]
        public String DESCRIP_TEXT_CUMPLIMIENTO { get; set; }
        [Description("DESCRIP_TEXT_DESESTIMIENTO")]
        public String DESCRIP_TEXT_DESESTIMIENTO { get; set; }
        //---------- variable TIPO_APROVECHAMIENTO ---------
        [Description("TIPO_APROVECHAMIENTO")]
        public String TIPO_APROVECHAMIENTO { get; set; }
        //---------- variable N_TRAMITE ---------
        [Description("N_TRAMITE")]
        public String N_TRAMITE { get; set; }
        //---------- variable ARCHIVO_ADJUNTO ---------
        [Description("ARCHIVO_ADJUNTO")]
        public String ARCHIVO_ADJUNTO { get; set; }
        //-----------variable TITULAR_INT --------------
        [Description("TITULAR_INT")]
        public String TITULAR_INT { get; set; }
        [Description("CHKTITULAR")]
        public int CHKTITULAR { get; set; }
        //-----------variable lstChkProveidoGenerar --------------
        //[Description("PROVEIDO_GENERAR")]
        //public String PROVEIDO_GENERAR { get; set; }
        //-----------variable RESPONSABLE_SOL --------------
        [Description("RESPONSABLE_SOL")]
        public String RESPONSABLE_SOL { get; set; }
        [Description("CHKRESPONSABLE")]
        public int CHKRESPONSABLE { get; set; }
        //-----------variable REGENTE --------------
        [Description("REGENTE")]
        public String REGENTE { get; set; }
        [Description("CHKREGENTE")]
        public int CHKREGENTE { get; set; }
        //-----------variable ARFFS2 --------------
        [Description("ARFFS2")]
        public String ARFFS2 { get; set; }
        [Description("CHKARFFS2")]
        public int CHKARFFS2 { get; set; }
        //-----------variable ATFFS --------------
        [Description("ATFFS")]
        public String ATFFS { get; set; }
        [Description("CHKATFFS")]
        public int CHKATFFS { get; set; }
        //-----------variable MINPUBLICO --------------
        [Description("MINPUBLICO")]
        public String MINPUBLICO { get; set; }
        [Description("CHKMINPUBLICO")]
        public int CHKMINPUBLICO { get; set; }
        //-----------variable MINENERGIA --------------
        [Description("MINENERGIA")]
        public String MINENERGIA { get; set; }
        [Description("CHKMINENERGIA")]
        public int CHKMINENERGIA { get; set; }
        //-----------variable COLEINGE --------------
        [Description("COLEINGE")]
        public String COLEINGE { get; set; }
        [Description("CHKCOLEINGE")]
        public int CHKCOLEINGE { get; set; }
        //-----------variable OCI --------------
        [Description("OCI")]
        public String OCI { get; set; }
        [Description("CHKOCI")]
        public int CHKOCI { get; set; }
        //-----------variable OEFA --------------
        [Description("OEFA")]
        public String OEFA { get; set; }
        [Description("CHKOEFA")]
        public int CHKOEFA { get; set; }
        //-----------variable SUNAT --------------
        [Description("SUNAT")]
        public String SUNAT { get; set; }
        [Description("CHKSUNAT")]
        public int CHKSUNAT { get; set; }
        //-----------variable SERFOR --------------
        [Description("SERFOR")]
        public String SERFOR { get; set; }
        [Description("CHKSERFOR")]
        public int CHKSERFOR { get; set; }
        //-----------variable OTROS --------------
        [Description("OTROS")]
        public String OTROS { get; set; }
        [Description("CHKOTROS")]
        public int CHKOTROS { get; set; }
        //-----------variable DFFFS --------------
        [Description("DFFFS")]
        public String DFFFS { get; set; }
        [Description("CHKDFFFS")]
        public int CHKDFFFS { get; set; }
        //-----------variable DSFFS --------------
        [Description("DSFFS")]
        public String DSFFS { get; set; }
        [Description("CHKDSFFS")]
        public int CHKDSFFS { get; set; }
        //-----------variable URH --------------
        [Description("URH")]
        public String URH { get; set; }
        [Description("CHKURH")]
        public int CHKURH { get; set; }
        //-----------variable OCI2 --------------
        [Description("OCI2")]
        public String OCI2 { get; set; }
        [Description("CHKOCI2")]
        public int CHKOCI2 { get; set; }
        //-----------variable OTROS2 --------------
        [Description("OTROS2")]
        public String OTROS2 { get; set; }
        [Description("CHKOTROS2")]
        public int CHKOTROS2 { get; set; }

        // 5/01/2020
        [Description("NUMERO_RESOLUCION")]
        public String NUMERO_RESOLUCION { get; set; }
        [Description("NUM_RESOLUCION")]
        public String NUM_RESOLUCION { get; set; }
        [Description("TIPO_FISCALIZA")]
        public String TIPO_FISCALIZA { get; set; }
        [Category("FECHA"), Description("FECHA_EMISION")]
        public Object FECHA_EMISION { get; set; }
        [Description("RESDIR")]
        public object RESDIR { get; set; }
        [Description("RESSUBDIR")]
        public object RESSUBDIR { get; set; }
        [Description("NUMERO_EXPEDIENTE")]
        public String NUMERO_EXPEDIENTE { get; set; }
        [Description("SOLICITUD_ANTECEDENTES")]
        public object SOLICITUD_ANTECEDENTES { get; set; }
        [Description("SANCION_EXTITULAR")]
        public object SANCION_EXTITULAR { get; set; }
        [Description("COD_TITULAR")]
        public String COD_TITULAR { get; set; }
        [Description("DGFFS")]
        public object DGFFS { get; set; }
        [Description("DETALLE_DGFFS")]
        public String DETALLE_DGFFS { get; set; }
        [Description("PROGRAMA_REGIONAL")]
        public object PROGRAMA_REGIONAL { get; set; }
        [Description("DETALLE_PROREG")]
        public String DETALLE_PROREG { get; set; }
        [Description("MINISTERIO_PUBLICO")]
        public object MINISTERIO_PUBLICO { get; set; }
        [Description("DETALLE_MINPUB")]
        public String DETALLE_MINPUB { get; set; }
        [Description("COLEGIO_INGENIEROS")]
        public object COLEGIO_INGENIEROS { get; set; }
        [Description("DETALLE_COLING")]
        public String DETALLE_COLING { get; set; }
        [Description("DETALLE_ATFFS")]
        public String DETALLE_ATFFS { get; set; }
        [Description("DETALLE_OCI")]
        public String DETALLE_OCI { get; set; }
        [Description("DETALLE_OEFA")]
        public String DETALLE_OEFA { get; set; }
        [Description("DETALLE_SUNAT")]
        public String DETALLE_SUNAT { get; set; }
        [Description("DETALLE_SERFOR")]
        public String DETALLE_SERFOR { get; set; }
        [Description("DETALLE_OTROS")]
        public String DETALLE_OTROS { get; set; }
        [Description("MIN_ENERGIA_MINAS")]
        public object MIN_ENERGIA_MINAS { get; set; }
        [Description("DETALLE_MINENMIN")]
        public String DETALLE_MINENMIN { get; set; }
        [Description("MEDIDAS_CAUTELARES")]
        public object MEDIDAS_CAUTELARES { get; set; }
        [Description("MED_CAUT_GTF")]
        public Object MED_CAUT_GTF { get; set; }
        [Description("MED_CAUT_LIST_TROZA")]
        public Object MED_CAUT_LIST_TROZA { get; set; }
        [Description("MED_CAUT_PM")]
        public Object MED_CAUT_PM { get; set; }
        [Description("MED_CAUT_POA")]
        public Object MED_CAUT_POA { get; set; }
        [Description("MED_CAUT_XESPECIE")]
        public Object MED_CAUT_XESPECIE { get; set; }
        [Description("DESCRIPCION_MEDIDAS_PAU")]
        public String DESCRIPCION_MEDIDAS_PAU { get; set; }
        [Description("SOLICITUD_BALANCE")]
        public object SOLICITUD_BALANCE { get; set; }
        [Description("CAUSALES_CADUCIDAD")]
        public object CAUSALES_CADUCIDAD { get; set; }
        [Description("INFORMACION_FALSA_INEX")]
        public object INFORMACION_FALSA_INEX { get; set; }
        [Description("INFORMACION_FALSA_DIF")]
        public object INFORMACION_FALSA_DIF { get; set; }
        [Description("INFORMACION_FALSA_DAS")]
        public object INFORMACION_FALSA_DAS { get; set; }
        [Description("DESCRIPCION_INFORMACION_FALSA")]
        public string DESCRIPCION_INFORMACION_FALSA { get; set; }
        [Description("SIN_INDICIOS_APROV")]
        public object SIN_INDICIOS_APROV { get; set; }
        [Description("MANDATOS")]
        public Object MANDATOS { get; set; }
        [Category("FECHA"), Description("BEXTRACCION_FEMISION")]
        public Object BEXTRACCION_FEMISION { get; set; }
        [Category("FECHA"), Description("FEMISION_BEXTRACION")]
        public string FEMISION_BEXTRACION { get; set; }
        [Description("DESCRIPCION_INFRACCIONES")]
        public string DESCRIPCION_INFRACCIONES { get; set; }
        [Category("FK"), Description("COD_RESUDIREC_PAU_FIN_TIPO")]
        public String COD_RESUDIREC_PAU_FIN_TIPO { get; set; }
        [Description("AMONESTACION")]
        public String AMONESTACION { get; set; }
        [Description("MONTO")]
        public String MONTO { get; set; }
        [Description("DESCUENTO")]
        public Object DESCUENTO { get; set; }
        [Description("COD_RESODIREC_GRAVEDAD")]
        public String COD_RESODIREC_GRAVEDAD { get; set; }
        [Description("RECTIFICACION")]
        public Object RECTIFICACION { get; set; }
        [Description("DESC_RECTIFICACION")]
        public String DESC_RECTIFICACION { get; set; }
        [Description("IMPROCEDENTE")]
        public object IMPROCEDENTE { get; set; }
        [Description("FUNDADA")]
        public object FUNDADA { get; set; }
        [Description("FUNDADA_PARTE")]
        public object FUNDADA_PARTE { get; set; }
        [Description("INFUNDADA")]
        public object INFUNDADA { get; set; }
        [Description("INADMISIBLE")]
        public object INADMISIBLE { get; set; }
        [Description("LEVANTAR_CADUCIDAD")]
        public object LEVANTAR_CADUCIDAD { get; set; }
        [Description("RECONS_CAMBIO_MULTA")]
        public object RECONS_CAMBIO_MULTA { get; set; }
        [Description("RECONS_MONTO")]
        public String RECONS_MONTO { get; set; }
        [Description("ARTICULO")]
        public String ARTICULO { get; set; }
        [Category("LIST"), Description("MotivoArchivo")]
        public List<Ent_TFFS> MotivoArchivo { get; set; }
        [Description("DESCRIPCION_OTROS")]
        public String DESCRIPCION_OTROS { get; set; }
        [Description("EXPEDIENTE_ADMINISTRATIVO_ASIGNADO")]
        public String EXPEDIENTE_ADMINISTRATIVO_ASIGNADO { get; set; }
        [Description("EVIDENCIA_IRREGULARIDAD")]
        public object EVIDENCIA_IRREGULARIDAD { get; set; }
        [Description("BUEN_MANEJO")]
        public object BUEN_MANEJO { get; set; }
        [Description("SIN_INFRACCION")]
        public object SIN_INFRACCION { get; set; }
        [Description("DEFICIENTE_NOTIFICACION")]
        public object DEFICIENTE_NOTIFICACION { get; set; }
        [Description("DEFICIENCIA_TECNICA")]
        public object DEFICIENCIA_TECNICA { get; set; }
        [Description("OTROS_arch")]
        public string OTROS_arch { get; set; }
        [Description("MOTAMP_AMPIMP")]
        public object MOTAMP_AMPIMP { get; set; }
        [Description("MOTAMP_AMPOTRINF")]
        public object MOTAMP_AMPOTRINF { get; set; }
        [Description("MOTAMP_AMPPORPLA")]
        public object MOTAMP_AMPPORPLA { get; set; }
        [Description("MOTAMP_OTROS")]
        public String MOTAMP_OTROS { get; set; }
        [Description("DESCRIPCION_ACUMULACION")]
        public String DESCRIPCION_ACUMULACION { get; set; }
        [Description("LEV_PARTE_MED_CAUTELAR")]
        public object LEV_PARTE_MED_CAUTELAR { get; set; }
        [Description("NO_LEV_MED_CAUTELAR")]
        public object NO_LEV_MED_CAUTELAR { get; set; }
        [Description("LEV_MED_CAUTELAR")]
        public object LEV_MED_CAUTELAR { get; set; }
        [Description("MOD_MED_CAUTELAR")]
        public object MOD_MED_CAUTELAR { get; set; }
        [Description("DESCRIPCION_MED_CAUTELAR")]
        public String DESCRIPCION_MED_CAUTELAR { get; set; }
        [Description("ERROR_MATERIAL")]
        public object ERROR_MATERIAL { get; set; }
        [Description("OTROS_RECTIFICACION")]
        public object OTROS_RECTIFICACION { get; set; }
        [Description("NOM_TITULAR")]
        public object NOM_TITULAR { get; set; }
        [Description("NUM_TITULO")]
        public object NUM_TITULO { get; set; }
        [Description("DESC_NUM_TIT")]
        public String DESC_NUM_TIT { get; set; }
        [Description("NUM_EXP")]
        public object NUM_EXP { get; set; }
        [Description("DESC_NUM_EXPE")]
        public String DESC_NUM_EXPE { get; set; }
        [Description("FECHA_EMISION1")]
        public object FECHA_EMISION1 { get; set; }
        [Description("DESC_FECHA")]
        public object DESC_FECHA { get; set; }
        [Description("ESPECIES")]
        public object ESPECIES { get; set; }
        [Description("RECTIF_CAMBIO_MULTA")]
        public object RECTIF_CAMBIO_MULTA { get; set; }
        [Description("RECTIF_MONTO")]
        public String RECTIF_MONTO { get; set; }
        [Description("TEXTO_RECTIFICACION")]
        public String TEXTO_RECTIFICACION { get; set; }
        [Category("LIST"), Description("ListMedidasCorrectivas")]
        public List<Ent_TFFS_MEDIDA> ListMedidasCorrectivas { get; set; }
        [Category("LIST"), Description("ListMandatos")]
        public List<Ent_TFFS_MEDIDA> ListMandatos { get; set; }
        [Category("LIST"), Description("ListarIniPAU")]
        public List<Ent_TFFS> ListarIniPAU { get; set; }
        [Category("LIST"), Description("ListEspeciesMedidas")]
        public List<Ent_TFFS> ListEspeciesMedidas { get; set; }
        [Description("v_pagesize")]
        public Int32 v_pagesize { get; set; }
        [Description("v_ROW_INDEX")]
        public Int32 v_ROW_INDEX { get; set; }

        [Description("v_currentpage")]
        public Int32 v_currentpage { get; set; }
        [Description("MOTIVO")]
        public String MOTIVO { get; set; }
        [Description("DETALLE_MOTIVO")]
        public String DETALLE_MOTIVO { get; set; }
        [Description("DESCRIPCIONMOTIVO")]
        public String DESCRIPCIONMOTIVO { get; set; }
        [Description("DESCRIPCION_ESPECIE")]
        public string DESCRIPCION_ESPECIE { get; set; }
        [Description("VOLUMEN")]
        public String VOLUMEN { get; set; }
        [Description("AREA")]
        public String AREA { get; set; }
        [Description("NUMERO_INDIVIDUOS")]
        public Int32 NUMERO_INDIVIDUOS { get; set; }
        [Description("TIPOMADERABLE")]
        public String TIPOMADERABLE { get; set; }
        [Description("COD_OD_REGISTRO")]
        public String COD_OD_REGISTRO { get; set; }
        [Category("FECHA"), Description("FECHA_ACUMULACION")]
        public Object FECHA_ACUMULACION { get; set; }
        [Description("PROFESIONAL")]
        public String PROFESIONAL { get; set; }


        // ---------------------------------------------------------------

        [Category("LIST"), Description("ListReferenciaTFFS")]

        public List<Ent_TFFS> ListReferenciaTFFS { get; set; }
        [Category("LIST"), Description("ListResuelveTFFS")]
        public List<Ent_TFFS> ListResuelveTFFS { get; set; }
        [Category("LIST"), Description("ListDeclaraTFFS")]
        public List<Ent_TFFS> ListDeclaraTFFS { get; set; }
        [Category("LIST"), Description("ListInformes")]
        public List<Ent_TFFS> ListInformes { get; set; }
        //Nuevas variables: 29/03/2017
        [Description("MAE_TIP_RECAPEL")]
        public String MAE_TIP_RECAPEL { get; set; }
        [Description("MAE_TIP_DETERMI")]
        public String MAE_TIP_DETERMI { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("APELLIDOS_NOMBRES")]
        public String APELLIDOS_NOMBRES { get; set; }
        [Description("CARGO")]
        public String CARGO { get; set; }
        [Description("TAB_MAESTRO")]
        public String TAB_MAESTRO { get; set; }
        [Description("TAB_DETALLE")]
        public String TAB_DETALLE { get; set; }
        [Description("MAE_TIP_MOT_DETERMI")]
        public String MAE_TIP_MOT_DETERMI { get; set; }
        [Description("MOT_DETERMI")]
        public String MOT_DETERMI { get; set; }
        [Description("CAMBIO_MULTA")]
        public decimal CAMBIO_MULTA { get; set; }
        [Description("CADUCIDAD")]
        public decimal CADUCIDAD { get; set; }
        [Description("MULTA")]
        public decimal MULTA { get; set; }
        [Description("MAE_TIP_DOC_RETRO")]
        public String MAE_TIP_DOC_RETRO { get; set; }
        [Description("DOC_RETRO")]
        public String DOC_RETRO { get; set; }
        [Description("CONFIRM_RESOL")]
        public String CONFIRM_RESOL { get; set; }
        [Description("CONFIRM_CMULTA")]
        public decimal CONFIRM_CMULTA { get; set; }
        [Description("ESTADO_PAU")]
        public string ESTADO_PAU { get; set; }
        [Description("COD_FCTIPO")]
        public string COD_FCTIPO { get; set; }
        [Description("COD_ILEGAL_ARTICULOS")]
        public string COD_ILEGAL_ARTICULOS { get; set; }
        [Description("COD_ILEGAL_ENCISOS")]
        public string COD_ILEGAL_ENCISOS { get; set; }
        [Description("DESCRIPCION_ARTICULOS")]
        public string DESCRIPCION_ARTICULOS { get; set; }
        [Description("DESCRIPCION_ENCISOS")]
        public string DESCRIPCION_ENCISOS { get; set; }
        [Description("DESCRIPCION_MED_CORRECTIVAS")]
        public string DESCRIPCION_MED_CORRECTIVAS { get; set; }
        [Description("MEDIDAS_CORRECTIVAS")]
        public int MEDIDAS_CORRECTIVAS { get; set; }
        [Description("CAMBIO_ESTADO_ESPECIE")]
        public int CAMBIO_ESTADO_ESPECIE { get; set; }
        [Category("FECHA"), Description("FECHA_PRESENTACION")]
        public string FECHA_PRESENTACION { get; set; }
        [Description("LEVANTAMIENTO")]
        public string LEVANTAMIENTO { get; set; }
        [Description("MEDIDAS_CORRECTIVAS2")]
        public string MEDIDAS_CORRECTIVAS2 { get; set; }
        [Description("CAMBIO_MULTA2")]
        public string CAMBIO_MULTA2 { get; set; }
        [Description("MULTA2")]
        public string MULTA2 { get; set; }
        [Description("AMONESTACION2")]
        public string AMONESTACION2 { get; set; }
        //Para lista de POAS
        [Description("NUM_POA")]
        public String NUM_POA { get; set; }
        [Description("POA")]
        public String POA { get; set; }

        [Description("TIPO_DOCUMENTO_REPORT")]
        public String TIPO_DOCUMENTO_REPORT { get; set; }
        [Description("COD_DOCUMENTO_REPORT")]
        public String COD_DOCUMENTO_REPORT { get; set; }
        [Description("NUM_POA_REPORT")]
        public Int32 NUM_POA_REPORT { get; set; }
        [Description("TIPO")]
        public String TIPO { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        [Category("LIST"), Description("ListPOAs")]
        public List<Ent_TFFS> ListPOAs { get; set; }
        [Category("LIST"), Description("ListPersonaFirma")]
        public List<Ent_TFFS> ListPersonaFirma { get; set; }
        [Category("LIST"), Description("ListProveidoGenerar")]
        public List<Ent_TFFS> ListProveidoGenerar { get; set; }
        [Category("LIST"), Description("ListInfraccionRD")]
        public List<Ent_RESODIREC> ListInfraccionRD { get; set; }
        [Category("LIST"), Description("ListLiteralRD")]
        public List<Ent_TFFS> ListLiteralRD { get; set; }
        [Category("LIST"), Description("ListARFFS")]
        public List<Ent_TFFS> ListARFFS { get; set; }
        [Category("LIST"), Description("ListNoti")]
        public List<Ent_TFFS> ListNoti { get; set; }
        //agregado 19-10-2020

        [Category("LIST"), Description("ListComboRecursoApelacion")]
        public List<Ent_TFFS> ListComboRecursoApelacion { get; set; }

        [Category("LIST"), Description("ListComboDetermina")]
        public List<Ent_TFFS> ListComboDetermina { get; set; }
        [Category("LIST"), Description("ListComboDocRetrotrae")]
        public List<Ent_TFFS> ListComboDocRetrotrae { get; set; }
        [Category("LIST"), Description("ListComboTipoProveido")]
        public List<Ent_TFFS> ListComboTipoProveido { get; set; }

        //03/10/2017
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("COD_EESTADO")]
        public String COD_EESTADO { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("CAMBIA_ESTADO_ESPECIES")]
        public Object CAMBIA_ESTADO_ESPECIES { get; set; }
        [Description("MAE_ESTDETERMINA_CADUCIDAD")]
        public String MAE_ESTDETERMINA_CADUCIDAD { get; set; }
        [Description("MAE_ESTDETERMINA_MULTA")]
        public String MAE_ESTDETERMINA_MULTA { get; set; }
        [Description("MAE_ESTDETERMINA_MCORRECTIVA")]
        public String MAE_ESTDETERMINA_MCORRECTIVA { get; set; }
        [Description("MAE_ESTDETERMINA_ART363I")]
        public String MAE_ESTDETERMINA_ART363I { get; set; }
        [Description("ESTDETERMINA_ART363I")]
        public String ESTDETERMINA_ART363I { get; set; }

        [Category("LIST"), Description("ListEMaderable")]
        public List<CapaEntidad.DOC.Ent_INFORME> ListEMaderable { get; set; }
        [Category("LIST"), Description("ListEMaderableSemillero")]
        public List<CapaEntidad.DOC.Ent_INFORME> ListEMaderableSemillero { get; set; }
        [Category("LIST"), Description("ListComboEstadoDetermina")]
        public List<Ent_TFFS> ListComboEstadoDetermina { get; set; }
        public List<Ent_TFFS> ListResApeTFFS { get; set; }
        [Category("LIST"), Description("ListResApeTFFS")]

        public Ent_TFFS()
        {
            RegEstado = -1;
            EliVALOR02 = -1;
            MULTA = -1;
            NUM_POA_REPORT = -1;
            COD_SECUENCIAL = -1;
            v_currentpage = -1;
            v_pagesize = -1;
            v_ROW_INDEX = -1;
            NUMERO_INDIVIDUOS = -1;
            CHKCONFIRMAR = -1;
            CHKCONFIRMAR2 = -1;
            CHKREVOCAR = -1;
            CHKREVOCAR2 = -1;
            CHKREVOCARPARTE = -1;
            CHKREVOCARPARTE2 = -1;
            CHKRETROTRAER = -1;
            CHKRETROTRAER2 = -1;
            CHKPRESCRIBIR = -1;
            CHKPRESCRIBIR2 = -1;
            CHKARCHIVAR = -1;
            CHKARCHIVAR2 = -1;
            CHKNULIDAD = -1;
            CHKNULIDAD2 = -1;
            CHKLEVANTAR = -1;
            CHKLEVANTAR2 = -1;
            CHKCARECE = -1;
            CHKCARECE2 = -1;
            CHKOTRO = -1;
            CHKOTRO2 = -1;
            CAMBIO_ESTADO_ESPECIE = -1;
            MEDIDAS_CORRECTIVAS = -1;
            CAMBIO_MULTA = -1;
            CADUCIDAD = -1;
            CONFIRM_CMULTA = -1;
            CHKTITULAR = -1;
            CHKRESPONSABLE = -1;
            CHKREGENTE = -1;
            CHKARFFS2 = -1;
            CHKATFFS = -1;
            CHKMINPUBLICO = -1;
            CHKMINENERGIA = -1;
            CHKCOLEINGE = -1;
            CHKOCI = -1;
            CHKOEFA = -1;
            CHKSUNAT = -1;
            CHKSERFOR = -1;
            CHKOTROS = -1;
            CHKDFFFS = -1;
            CHKDSFFS = -1;
            CHKURH = -1;
            CHKOCI2 = -1;
            CHKOTROS2 = -1;
        }


    }
    public class TipoDocumentos
    {
        public String Remitente { get; set; }
        public String Documento { get; set; }
        public String Resolucion { get; set; }
        public String Direccion { get; set; }

    }
    public class Ent_TFFS_MEDIDA
    {
        [Description("COD_RESODIREC")]
        public string COD_RESODIREC { get; set; }
        [Description("COD_MEDIDA")]
        public int COD_MEDIDA { get; set; }
        [Description("MEDIDA")]
        public string MEDIDA { get; set; }
        [Description("MAE_TIP_MEDIDA")]
        public string MAE_TIP_MEDIDA { get; set; }
        [Description("PLAZO_IMPL_DIA")]
        public int PLAZO_IMPL_DIA { get; set; }
        [Description("PLAZO_IMPL_MES")]
        public int PLAZO_IMPL_MES { get; set; }
        [Description("PLAZO_IMPL_ANIO")]
        public int PLAZO_IMPL_ANIO { get; set; }
        [Description("PLAZO_POST_DIA")]
        public int PLAZO_POST_DIA { get; set; }
        [Description("PLAZO_POST_MES")]
        public int PLAZO_POST_MES { get; set; }
        [Description("PLAZO_POST_ANIO")]
        public int PLAZO_POST_ANIO { get; set; }
        [Description("PLAZO_INF_DIA")]
        public int PLAZO_INF_DIA { get; set; }
        [Description("PLAZO_INF_MES")]
        public int PLAZO_INF_MES { get; set; }
        [Description("PLAZO_INF_ANIO")]
        public int PLAZO_INF_ANIO { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }

        [Category("LIST"), Description("ListEspeciesMCorrectiva")]
        public List<Ent_TFFS_MEDIDA_ESPECIE> ListEspeciesMCorrectiva { get; set; }

        //Columnas para el saeguimiento de medidas
        [Description("COD_RESODIREC_MEDIDA")]
        public string COD_RESODIREC_MEDIDA { get; set; }
        [Description("NUM_RESOLUCION_MEDIDA")]
        public string NUM_RESOLUCION_MEDIDA { get; set; }
        [Description("FECHA_NOTIFICACION")]
        public object FECHA_NOTIFICACION { get; set; }
        [Description("PLAZO_IMPLEMENTACION")]
        public object PLAZO_IMPLEMENTACION { get; set; }
        public int RegEstado { get; set; }
        public Ent_TFFS_MEDIDA()
        {
            COD_MEDIDA = -1;
            PLAZO_IMPL_ANIO = -1;
            PLAZO_IMPL_DIA = -1;
            PLAZO_IMPL_MES = -1;
            PLAZO_INF_ANIO = -1;
            PLAZO_INF_DIA = -1;
            PLAZO_INF_MES = -1;
            PLAZO_POST_ANIO = -1;
            PLAZO_POST_DIA = -1;
            PLAZO_POST_MES = -1;
            RegEstado = -1;
        }
    }

    public class Ent_TFFS_MEDIDA_ESPECIE
    {
        [Description("COD_RESODIREC")]
        public string COD_RESODIREC { get; set; }
        [Description("COD_MEDIDA")]
        public int COD_MEDIDA { get; set; }
        [Description("COD_SECUENCIAL")]
        public int COD_SECUENCIAL { get; set; }
        [Description("COD_ESPECIES")]
        public string COD_ESPECIES { get; set; }
        [Description("ESPECIES")]
        public string ESPECIES { get; set; }
        [Description("VOLUMEN_MOVILIZADO")]
        public Object VOLUMEN_MOVILIZADO { get; set; }
        [Description("NUMERO_INDIVIDUOS")]
        public int NUMERO_INDIVIDUOS { get; set; }
        [Description("OBSERVACION")]
        public string OBSERVACION { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }

        public Ent_TFFS_MEDIDA_ESPECIE()
        {
            COD_MEDIDA = -1;
            COD_SECUENCIAL = -1;
            //VOLUMEN_MOVILIZADO = ;
            NUMERO_INDIVIDUOS = -1;
            RegEstado = -1;
        }
    }

    public class Ent_TFFS_MEDIDA_SEGUIMIENTO
    {
        [Description("COD_RESODIREC")]
        public string COD_RESODIREC { get; set; }
        [Description("NUM_EXPEDIENTE")]
        public string NUM_EXPEDIENTE { get; set; }
        [Description("NUM_THABILITANTE")]
        public string NUM_THABILITANTE { get; set; }
        [Description("TITULAR")]
        public string TITULAR { get; set; }
        [Description("MODALIDAD")]
        public string MODALIDAD { get; set; }
        [Category("LIST"), Description("ListMedidaCorrectiva")]
        public List<Ent_TFFS_MEDIDA> ListMedidaCorrectiva { get; set; }
        [Category("LIST"), Description("ListMandato")]
        public List<Ent_TFFS_MEDIDA> ListMandato { get; set; }

    }
    public class Tra_M_Tramite_tffs
    {
        [Description("iCodTramite")]
        public String iCodTramite { get; set; }
        [Description("cNomTupa")]
        public string cNomTupa { get; set; }

        [Description("cNroDocumento")]
        public string cNroDocumento { get; set; }

        [Description("cAsunto")]
        public string cAsunto { get; set; }
        [Description("cCodificacion")]
        public string cCodificacion { get; set; }
        [Description("fFecDocumento")]
        public string fFecDocumento { get; set; }

    }
}
