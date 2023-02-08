using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_REPORTE_SUPERVISION_GENERAL
    {
        [Description("FIC_SIADO")]
        public String FIC_SIADO { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("DOCUMENTO_TITULAR")]
        public String DOCUMENTO_TITULAR { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("MOTIVO")]
        public String MOTIVO { get; set; }
        [Description("NUMERO_DOCUMENTO")]
        public String NUMERO_DOCUMENTO { get; set; }

        [Description("CANT_ZOOL")]
        public Decimal CANT_ZOOL { get; set; }
        [Description("CANT_ZOOC")]
        public Decimal CANT_ZOOC { get; set; }
        [Description("CANT_CRES")]
        public Decimal CANT_CRES { get; set; }
        [Description("CANT_CCT")]
        public Decimal CANT_CCT { get; set; }
        [Description("CANT_NMCAST")]
        public Decimal CANT_NMCAST { get; set; }
        [Description("CANT_NMSHIR")]
        public Decimal CANT_NMSHIR { get; set; }
        [Description("CANT_NMAGU")]
        public Decimal CANT_NMAGU { get; set; }
        [Description("CANT_ECO")]
        public Decimal CANT_ECO { get; set; }
        [Description("CANT_CONS")]
        public Decimal CANT_CONS { get; set; }
        [Description("CANT_CFAUNA")]
        public Decimal CANT_CFAUNA { get; set; }
        [Description("CANT_PFAUNA")]
        public Decimal CANT_PFAUNA { get; set; }
        [Description("CANT_SISAG")]
        public Decimal CANT_SISAG { get; set; }
        [Description("CANT_CARRIZO")]
        public Decimal CANT_CARRIZO { get; set; }
        [Description("CANT_PMEDICI")]
        public Decimal CANT_PMEDICI { get; set; }
        [Description("CANT_CCCC_CCNN")]
        public Decimal CANT_CCCC_CCNN { get; set; }
        [Description("CANT_PNM")]
        public Decimal CANT_PNM { get; set; }
        [Description("CANT_BS")]
        public Decimal CANT_BS { get; set; }
        [Description("CANT_CCNN")]
        public Decimal CANT_CCNN { get; set; }
        [Description("CANT_PP")]
        public Decimal CANT_PP { get; set; }
        [Description("CANT_CCCC")]
        public Decimal CANT_CCCC { get; set; }
        [Description("CANT_TARA")]
        public Decimal CANT_TARA { get; set; }
        [Description("CANT_BL")]
        public Decimal CANT_BL { get; set; }
        [Description("CANT_CMADE")]
        public Decimal CANT_CMADE { get; set; }
        [Description("CANT_NM")]
        public Decimal CANT_NM { get; set; }
        [Description("CANT_FYR")]
        public Decimal CANT_FYR { get; set; }

        //
        [Description("AÑO")]
        public Int32 ANIO { get; set; }
        [Description("CONCESIONES")]
        public Int32 CONCESIONES { get; set; }
        [Description("PERMISO")]
        public Int32 PERMISO { get; set; }
        [Description("TOTALDOUBLE")]
        public Double TOTALDOUBLE { get; set; }
        [Description("ArbolesSupervisados")]
        public Int32 ArbolesSupervisados { get; set; }
        [Description("TOTAL")]
        public Int32 TOTAL { get; set; }
        [Description("TOTALCONCESION")]
        public Int32 TOTALCONCESION { get; set; }
        [Description("MENU")]
        public String MENU { get; set; }
        [Description("CATEGORIA")]
        public Int32 CATEGORIA { get; set; }

        //Opciones de Busqueda

        [Description("BusModalidad")]
        public String BusModalidad { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusRegion")]
        public String BusRegion { get; set; }
        [Description("BusAnio")]
        public String BusAnio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("ZAFRA_PCA")]
        public String ZAFRA_PCA { get; set; }

        [Description("DOSMILCINCO")]
        public Int32 DOSMILCINCO { get; set; }
        [Description("DOSMILSEIS")]
        public Int32 DOSMILSEIS { get; set; }
        [Description("DOSMILSIETE")]
        public Int32 DOSMILSIETE { get; set; }
        [Description("DOSMILOCHO")]
        public Int32 DOSMILOCHO { get; set; }
        [Description("DOSMILNUEVE")]
        public Int32 DOSMILNUEVE { get; set; }
        [Description("DOSMILDIEZ")]
        public Int32 DOSMILDIEZ { get; set; }
        [Description("DOSMILONCE")]
        public Int32 DOSMILONCE { get; set; }
        [Description("DOSMILDOCE")]
        public Int32 DOSMILDOCE { get; set; }
        [Description("DOSMILTRECE")]
        public Int32 DOSMILTRECE { get; set; }
        [Description("DOSMILCATORCE")]
        public Int32 DOSMILCATORCE { get; set; }
        [Description("DOSMILQUINCE")]
        public Int32 DOSMILQUINCE { get; set; }
        [Description("DOSMILDIECISEIS")]
        public Int32 DOSMILDIECISEIS { get; set; }

        //supervision      
        [Description("APELLIDOS_NOMBRES")]
        public String APELLIDOS_NOMBRES { get; set; }

        //15/06/2017
        [Description("POAS")]
        public String POAS { get; set; }
        [Description("POAS_RD")]
        public String POAS_RD { get; set; }

        [Description("FECHA")]
        public String FECHA { get; set; }
        [Description("FECHA_INFORME")]
        public String FECHA_INFORME { get; set; }

        //Manejo de Listas
        [Category("LIST"), Description("ListISupervision_Region_Modalidad")]
        public List<Ent_REPORTE_SUPERVISION_GENERAL> ListISupervision_Region_Modalidad { get; set; }
        [Category("LIST"), Description("ListISupervision_Modalidad_Anio")]
        public List<Ent_REPORTE_SUPERVISION_GENERAL> ListISupervision_Modalidad_Anio { get; set; }

        ///////////////////////////////////////////
        [Category("LIST"), Description("ListISupervision_General")]
        public List<Ent_REPORTE_SUPERVISION_GENERAL> ListISupervision_General { get; set; }
        [Category("LIST"), Description("ListISupervision_Modalidades")]
        public List<Ent_REPORTE_SUPERVISION_GENERAL> ListISupervision_Modalidades { get; set; }
        [Category("LIST"), Description("ListRegiones")]
        public List<Ent_REPORTE_SUPERVISION_GENERAL> ListRegiones { get; set; }
        [Category("LIST"), Description("ListTiempoModalidad")]
        public List<Ent_REPORTE_SUPERVISION_GENERAL> ListTiempoModalidad { get; set; }
        [Category("LIST"), Description("ListDetalleSupervisor")]
        //[Category("LIST"), Description("ListDetalleSupervisor")]
        public List<Ent_REPORTE_SUPERVISION_GENERAL> ListDetalleSupervisor { get; set; }

        //Categoria Diametrica
        [Description("RANGO")]
        public String RANGO { get; set; }
        [Description("DAP")]
        public Int32 DAP { get; set; }
        [Category("LIST"), Description("ListNombresCientificos")]
        public List<Ent_REPORTE_SUPERVISION_GENERAL> ListNombresCientificos { get; set; }
        [Category("LIST"), Description("ListAnios")]
        public List<Ent_REPORTE_SUPERVISION_GENERAL> ListAnios { get; set; }
        [Category("LIST"), Description("ListCategoriaDiametrica")]
        public List<Ent_REPORTE_SUPERVISION_GENERAL> ListCategoriaDiametrica { get; set; }
        //Categoria Diametrica

        //Titulares Mas Supervisiones
        [Description("COD_UBIGEO")]
        public String COD_UBIGEO { get; set; }
        [Description("DEPARTAMENTO")]
        public String DEPARTAMENTO { get; set; }
        [Description("PROVINCIA")]
        public String PROVINCIA { get; set; }
        [Description("DISTRITO")]
        public String DISTRITO { get; set; }

        [Description("CANTIDAD DE_POAs")]
        public String CANT_POA { get; set; }
        [Description("CADUCIDAD")]
        public String CADUCIDAD { get; set; }
        [Description("FECHA CADUCO")]
        public String FECHA_CADUCO { get; set; }
        [Description("POAs")]
        public String POAs { get; set; }
        [Description("SUPERVISADO")]
        public object SUPERVISADO { get; set; }
        [Description("INFORME")]
        public String INFORME { get; set; }
        [Description("Lista titulares con mas supervisiones")]
        public List<Ent_REPORTE_SUPERVISION_GENERAL> ListTitularSup { get; set; }
        [Description("Lista POAs titulo habilitante")]
        public List<Ent_REPORTE_SUPERVISION_GENERAL> ListPoasTHabilitante { get; set; }
        //Titulares Mas Supervisiones

        //Arboles Adicionales
        [Description("BusEstado")]
        public String BusEstado { get; set; }
        [Description("BusEspecie")]
        public String BusEspecie { get; set; }
        [Description("ISUPERVISION")]
        public String ISUPERVISION { get; set; }
        [Description("NUM ARBOL")]
        public Int32 NUM_ARBOL { get; set; }
        [Description("COD_EESTADO")]
        public String COD_EESTADO { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        //Arboles Adicionales
        #region supervicion total
        [Description("BusDireccion")]
        public String BusDireccion { get; set; }

        [Description("Anios")]
        public Int32 Anios { get; set; }

        [Description("N_Supervisiones")]
        public Int32 N_Supervisiones { get; set; }

        [Description("AREA_POA")]
        public Decimal AREA_POA { get; set; }

        [Description("AREA_TH")]
        public Decimal AREA_TH { get; set; }
        #endregion
        // thabilitante resumen

        [Description("RUC_TITULAR")]
        public String RUC_TITULAR { get; set; }
        [Description("TIPO_PERSONA_TITULAR")]
        public String TIPO_PERSONA_TITULAR { get; set; }
        [Description("DIRECCION_TITULAR")]
        public String DIRECCION_TITULAR { get; set; }
        [Description("COD_LINEA")]
        public String COD_LINEA { get; set; }
        [Description("D_LINEA")]
        public String D_LINEA { get; set; }
        [Description("R_LEGAL")]
        public String R_LEGAL { get; set; }
        [Description("DOCUMENTO_RLEGAL")]
        public String DOCUMENTO_RLEGAL { get; set; }
        [Description("SECTOR")]
        public String SECTOR { get; set; }
        [Description("UBICACION")]
        public String UBICACION { get; set; }
        [Description("N_POA")]
        public String N_POA { get; set; }
        [Description("ARCHIVO_PRELIMINAR")]
        public String ARCHIVO_PRELIMINAR { get; set; }
        [Description("RD_INICIO")]
        public String RD_INICIO { get; set; }
        [Description("RD_TERMINO")]
        public String RD_TERMINO { get; set; }
        [Description("FECHA_RD_TERMINO")]
        public String FECHA_RD_TERMINO { get; set; }
        [Description("DETER_RD_TERMINO")]
        public String DETER_RD_TERMINO { get; set; }
        [Description("AMONESTACION")]
        public String AMONESTACION { get; set; }
        [Description("MULTA_RDTERMINO")]
        public Decimal MULTA_RDTERMINO { get; set; }
        [Description("INFRACCIONES")]
        public String INFRACCIONES { get; set; }
        [Description("FECHA_NOTIF_RD_TERMINO")]
        public String FECHA_NOTIF_RD_TERMINO { get; set; }
        [Description("Recurso_Reconsideracion")]
        public String Recurso_Reconsideracion { get; set; }
        [Description("Fecha_Recurso_Reconsideracion")]
        public String Fecha_Recurso_Reconsideracion { get; set; }
        [Description("RD_Reconsideracion")]
        public String RD_Reconsideracion { get; set; }
        [Description("Fecha_RD_Reconsideracion")]
        public String Fecha_RD_Reconsideracion { get; set; }
        [Description("DETER_RD_RECON")]
        public String DETER_RD_RECON { get; set; }

        [Description("MULTA_RDRECON")]
        public Decimal MULTA_RDRECON { get; set; }
        [Description("Fecha_NotificaRDR")]
        public String Fecha_NotificaRDR { get; set; }

        [Description("Doc_inf")]
        public String Doc_inf { get; set; }
        [Description("Const")]
        public String Const { get; set; }
        [Description("Fecha_emision_const")]
        public String Fecha_emision_const { get; set; }

        [Description("RD_Rectificacion")]
        public String RD_Rectificacion { get; set; }
        [Description("Fecha_RD_Rectificacion")]
        public String Fecha_RD_Rectificacion { get; set; }

        [Description("RECURSO_APELA")]
        public String RECURSO_APELA { get; set; }
        [Description("FECHA_RECURSO_APELA")]
        public String FECHA_RECURSO_APELA { get; set; }
        [Description("MULTA_RDRECTIF")]
        public Decimal MULTA_RDRECTIF { get; set; }
        [Description("Fecha_NotificaRDRectificacion")]
        public String Fecha_NotificaRDRectificacion { get; set; }

        [Description("BusMulta")]
        public String BusMulta { get; set; }


        [Description("CAMBIO_MULTA_RDRECON")]
        public String CAMBIO_MULTA_RDRECON { get; set; }
        [Description("CAMBIO_MULTA_RDRECTIF")]
        public String CAMBIO_MULTA_RDRECTIF { get; set; }

        [Description("PROVEIDO")]
        public String PROVEIDO { get; set; }
        [Description("FECHA_FIRME")]
        public String FECHA_FIRME { get; set; }

        [Description("NUM_RESOLUCION_TFFS")]
        public String NUM_RESOLUCION_TFFS { get; set; }
        [Description("FECHA_TFFS")]
        public String FECHA_TFFS { get; set; }
        [Description("NOM_RECAPE")]
        public String NOM_RECAPE { get; set; }
        [Description("NOM_TIPDET")]
        public String NOM_TIPDET { get; set; }
        [Description("NOM_MOTDET")]
        public String NOM_MOTDET { get; set; }
        [Description("CAMBIO_MULTA_TFFS")]
        public String CAMBIO_MULTA_TFFS { get; set; }
        [Description("MULTA_TFFS")]
        public Decimal MULTA_TFFS { get; set; }

        //Nuevas Columnas, para el reporte de supervisiones por supervisor
        [Category("LIST"), Description("ListSupervisionSupervisorXmodalidad")]
        public List<Ent_REPORTE_SUPERVISION_GENERAL> ListSupervisionSupervisorXmodalidad { get; set; }
        [Category("LIST"), Description("ListSupervisionXsupervisor")]
        public List<Ent_REPORTE_SUPERVISION_GENERAL> ListSupervisionXsupervisor { get; set; }
        [Category("LIST"), Description("ListSupervisionXmodalidad")]
        public List<Ent_REPORTE_SUPERVISION_GENERAL> ListSupervisionXmodalidad { get; set; }
        [Description("COD_MTIPO")]
        public String COD_MTIPO { get; set; }
        [Description("COD_SUPERVISOR")]
        public String COD_SUPERVISOR { get; set; }
        [Description("SUPERVISOR")]
        public String SUPERVISOR { get; set; }
        [Description("FECHA_INICIO")]
        public String FECHA_INICIO { get; set; }
        [Description("FECHA_FIN")]
        public String FECHA_FIN { get; set; }
        [Description("TIPO_REPORTE")]
        public String TIPO_REPORTE { get; set; }

        [Description("PUBLICAR_TEXT")]
        public String PUBLICAR_TEXT { get; set; }


        [Description("MUESTRA")]
        public Int32 MUESTRA { get; set; }
        [Description("ADICIONAL")]
        public Int32 ADICIONAL { get; set; }
        [Description("NO_AUTORIZADO")]
        public Int32 NO_AUTORIZADO { get; set; }

        ////////////////////////////////
        [Description("RD_TERMINO_2")]
        public String RD_TERMINO_2 { get; set; }
        [Description("FECHA_RD_TERMINO_2")]
        public String FECHA_RD_TERMINO_2 { get; set; }
        [Description("DETER_RD_TERMINO_2")]
        public String DETER_RD_TERMINO_2 { get; set; }
        [Description("AMONESTACION_2")]
        public String AMONESTACION_2 { get; set; }
        [Description("MULTA_RDTERMINO_2")]
        public Decimal MULTA_RDTERMINO_2 { get; set; }
        [Description("INFRACCIONES_2")]
        public String INFRACCIONES_2 { get; set; }
        [Description("FECHA_NOTIF_RD_TERMINO_2")]
        public String FECHA_NOTIF_RD_TERMINO_2 { get; set; }
        [Description("Recurso_Reconsideracion_2")]
        public String Recurso_Reconsideracion_2 { get; set; }
        [Description("Fecha_Recurso_Reconsideracion_2")]
        public String Fecha_Recurso_Reconsideracion_2 { get; set; }
        [Description("RD_Reconsideracion_2")]
        public String RD_Reconsideracion_2 { get; set; }
        [Description("Fecha_RD_Reconsideracion_2")]
        public String Fecha_RD_Reconsideracion_2 { get; set; }
        [Description("DETER_RD_RECON_2")]
        public String DETER_RD_RECON_2 { get; set; }

        [Description("MULTA_RDRECON_2")]
        public Decimal MULTA_RDRECON_2 { get; set; }
        [Description("Fecha_NotificaRDR_2")]
        public String Fecha_NotificaRDR_2 { get; set; }

        [Description("CAMBIO_MULTA_RDRECON_2")]
        public String CAMBIO_MULTA_RDRECON_2 { get; set; }
        [Description("CAMBIO_MULTA_RDRECTIF_2")]
        public String CAMBIO_MULTA_RDRECTIF_2 { get; set; }
        [Description("NUM_RESOLUCION_TFFS_2")]
        public String NUM_RESOLUCION_TFFS_2 { get; set; }
        [Description("FECHA_TFFS_2")]
        public String FECHA_TFFS_2 { get; set; }
        [Description("NOM_RECAPE_2")]
        public String NOM_RECAPE_2 { get; set; }
        [Description("NOM_TIPDET_2")]
        public String NOM_TIPDET_2 { get; set; }
        [Description("NOM_MOTDET_2")]
        public String NOM_MOTDET_2 { get; set; }
        [Description("CAMBIO_MULTA_TFFS_2")]
        public String CAMBIO_MULTA_TFFS_2 { get; set; }
        [Description("MULTA_TFFS_2")]
        public Decimal MULTA_TFFS_2 { get; set; }

        [Description("RD_Rectificacion_2")]
        public String RD_Rectificacion_2 { get; set; }
        [Description("Fecha_RD_Rectificacion_2")]
        public String Fecha_RD_Rectificacion_2 { get; set; }

        [Description("RECURSO_APELA_2")]
        public String RECURSO_APELA_2 { get; set; }
        [Description("FECHA_RECURSO_APELA_2")]
        public String FECHA_RECURSO_APELA_2 { get; set; }

        [Description("MULTA_RDRECTIF_2")]
        public Decimal MULTA_RDRECTIF_2 { get; set; }
        [Description("Fecha_NotificaRDRectificacion_2")]
        public String Fecha_NotificaRDRectificacion_2 { get; set; }

        #region Obligaciones Maderables


        //1
        [Description("OBLI_PRESENTOPLANMANEJO")]
        public String OBLI_PRESENTOPLANMANEJO { get; set; }
        //2
        [Description("OBLI_PRESENTOPLANMANEJOCONFORMIDAD")]
        public String OBLI_PRESENTOPLANMANEJOCONFORMIDAD { get; set; }
        //3
        [Description("OBLI_PAGOAPROVECHAMIENTO")]
        public String OBLI_PAGOAPROVECHAMIENTO { get; set; }
        //4
        [Description("OBLI_MANTIENELIBROOPERACIONES")]
        public String OBLI_MANTIENELIBROOPERACIONES { get; set; }
        //5
        [Description("OBLI_COMUNICOARFFSOSINFORSUSCRIPCION")]
        public String OBLI_COMUNICOARFFSOSINFORSUSCRIPCION { get; set; }
        //6
        [Description("OBLI_REPORTOARFFSMINISTERIOAVISTAMIENTOS")]
        public String OBLI_REPORTOARFFSMINISTERIOAVISTAMIENTOS { get; set; }
        //7
        [Description("OBLI_REALIZOACCIONESCUSTODIO")]
        public String OBLI_REALIZOACCIONESCUSTODIO { get; set; }
        //8
        [Description("OBLI_FACILITODESARROLLO")]
        public String OBLI_FACILITODESARROLLO { get; set; }
        //9
        [Description("OBLI_ASUMIOCOSTOSUPERVISIONES")]
        public String OBLI_ASUMIOCOSTOSUPERVISIONES { get; set; }
        //10
        [Description("OBLI_IMPLEMENTAMECANISMOTRAZA")]
        public String OBLI_IMPLEMENTAMECANISMOTRAZA { get; set; }
        //11
        [Description("OBLI_RESPETASERVIDUMBRE")]
        public String OBLI_RESPETASERVIDUMBRE { get; set; }
        //12
        [Description("OBLI_CUENTAREGENTE")]
        public String OBLI_CUENTAREGENTE { get; set; }
        //13
        [Description("OBLI_ADOPTAMEDIDASEXTENSION")]
        public String OBLI_ADOPTAMEDIDASEXTENSION { get; set; }
        //14
        [Description("OBLI_RESPETAVALORES")]
        public String OBLI_RESPETAVALORES { get; set; }
        //15
        [Description("OBLI_CUMPLEMEDIDAS")]
        public String OBLI_CUMPLEMEDIDAS { get; set; }
        //16
        [Description("OBLI_CUMPLENORMAS")]
        public String OBLI_CUMPLENORMAS { get; set; }
        //17
        [Description("OBLI_MOVILIZAFRUTOPRODUCTOS")]
        public String OBLI_MOVILIZAFRUTOPRODUCTOS { get; set; }
        //18
        [Description("OBLI_CUMPLEMARCADOTROZAS")]
        public String OBLI_CUMPLEMARCADOTROZAS { get; set; }
        //19
        [Description("OBLI_ESTABLECELINDEROS")]
        public String OBLI_ESTABLECELINDEROS { get; set; }
        //20
        [Description("OBLI_IMPLEMENTACIONMEDIDASCORRECTIVAS")]
        public String OBLI_IMPLEMENTACIONMEDIDASCORRECTIVAS { get; set; }
        //21
        [Description("OBLI_PROMUEVENBUENASPRACTICAS")]
        public String OBLI_PROMUEVENBUENASPRACTICAS { get; set; }
        //22
        [Description("OBLI_PROMUEVEEQUIDAD")]
        public String OBLI_PROMUEVEEQUIDAD { get; set; }
        //23
        [Description("OBLI_MANTIENEVIGENTEGARANTIA")]
        public String OBLI_MANTIENEVIGENTEGARANTIA { get; set; }
        //24
        [Description("OBLI_CUMPLECOMPROMISOINVERSION")]
        public String OBLI_CUMPLECOMPROMISOINVERSION { get; set; }
        #endregion


        #region 14/08/2018 Obligacion Titulares TH No Maderable
        //1
        [Description("OBLI_NM_PRESENTOPMF")]
        public String OBLI_NM_PRESENTOPMF { get; set; }
        [Description("OBLI_NM_PRESENTOPMF_DESCRIPCION")]
        public String OBLI_NM_PRESENTOPMF_DESCRIPCION { get; set; }
        //2
        [Description("OBLI_NM_PRESENTOINFORMEEJECUCION")]
        public String OBLI_NM_PRESENTOINFORMEEJECUCION { get; set; }
        [Description("OBLI_NM_PRESENTOINFORMEEJECUCION_DESCRIPCION")]
        public String OBLI_NM_PRESENTOINFORMEEJECUCION_DESCRIPCION { get; set; }
        //3
        [Description("OBLI_NM_PAGOAPROVECHAMIENTO")]
        public String OBLI_NM_PAGOAPROVECHAMIENTO { get; set; }
        [Description("OBLI_NM_PAGOAPROVECHAMIENTO_DESCRIPCION")]
        public String OBLI_NM_PAGOAPROVECHAMIENTO_DESCRIPCION { get; set; }
        //4
        [Description("OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION")]
        public String OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION { get; set; }
        [Description("OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION_DESCRIPCION")]
        public String OBLI_NM_COMUNICOARFFSOSINFORSUSCRIPCION_DESCRIPCION { get; set; }
        //5
        [Description("OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS")]
        public String OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS { get; set; }
        [Description("OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS_DESCRIPCION")]
        public String OBLI_NM_REPORTOARFFSMINISTERIOAVISTAMIENTOS_DESCRIPCION { get; set; }
        //6
        [Description("OBLI_NM_REALIZOACCIONESCUSTODIO")]
        public String OBLI_NM_REALIZOACCIONESCUSTODIO { get; set; }
        [Description("OBLI_NM_REALIZOACCIONESCUSTODIO_DESCRIPCION")]
        public String OBLI_NM_REALIZOACCIONESCUSTODIO_DESCRIPCION { get; set; }
        //7
        [Description("OBLI_NM_FACILITODESARROLLO")]
        public String OBLI_NM_FACILITODESARROLLO { get; set; }
        [Description("OBLI_NM_FACILITODESARROLLO_DESCRIPCION")]
        public String OBLI_NM_FACILITODESARROLLO_DESCRIPCION { get; set; }
        //8
        [Description("OBLI_NM_ASUMIOCOSTOSUPERVISIONES")]
        public String OBLI_NM_ASUMIOCOSTOSUPERVISIONES { get; set; }
        [Description("OBLI_NM_ASUMIOCOSTOSUPERVISIONES_DESCRIPCION")]
        public String OBLI_NM_ASUMIOCOSTOSUPERVISIONES_DESCRIPCION { get; set; }
        //9
        [Description("OBLI_NM_IMPLEMENTAMECANISMOTRAZA")]
        public String OBLI_NM_IMPLEMENTAMECANISMOTRAZA { get; set; }
        [Description("OBLI_NM_IMPLEMENTAMECANISMOTRAZA_DESCRIPCION")]
        public String OBLI_NM_IMPLEMENTAMECANISMOTRAZA_DESCRIPCION { get; set; }
        //10
        [Description("OBLI_NM_RESPETASERVIDUMBRE")]
        public String OBLI_NM_RESPETASERVIDUMBRE { get; set; }
        [Description("OBLI_NM_RESPETASERVIDUMBRE_DESCRIPCION")]
        public String OBLI_NM_RESPETASERVIDUMBRE_DESCRIPCION { get; set; }
        //11
        [Description("OBLI_NM_ADOPTAMEDIDASEXTENSION")]
        public String OBLI_NM_ADOPTAMEDIDASEXTENSION { get; set; }
        [Description("OBLI_NM_ADOPTAMEDIDASEXTENSION_DESCRIPCION")]
        public String OBLI_NM_ADOPTAMEDIDASEXTENSION_DESCRIPCION { get; set; }
        //12
        [Description("OBLI_NM_RESPETAVALORES")]
        public String OBLI_NM_RESPETAVALORES { get; set; }
        [Description("OBLI_NM_RESPETAVALORES_DESCRIPCION")]
        public String OBLI_NM_RESPETAVALORES_DESCRIPCION { get; set; }
        //13
        [Description("OBLI_NM_CUMPLEMEDIDAS")]
        public String OBLI_NM_CUMPLEMEDIDAS { get; set; }
        [Description("OBLI_NM_CUMPLEMEDIDAS_DESCRIPCION")]
        public String OBLI_NM_CUMPLEMEDIDAS_DESCRIPCION { get; set; }
        //14
        [Description("OBLI_NM_CUMPLENORMAS")]
        public String OBLI_NM_CUMPLENORMAS { get; set; }
        [Description("OBLI_NM_CUMPLENORMAS_DESCRIPCION")]
        public String OBLI_NM_CUMPLENORMAS_DESCRIPCION { get; set; }
        //15
        [Description("OBLI_NM_MOVILIZAFRUTOPRODUCTOS")]
        public String OBLI_NM_MOVILIZAFRUTOPRODUCTOS { get; set; }
        [Description("OBLI_NM_MOVILIZAFRUTOPRODUCTOS_DESCRIPCION")]
        public String OBLI_NM_MOVILIZAFRUTOPRODUCTOS_DESCRIPCION { get; set; }
        //16
        [Description("OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS")]
        public String OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS { get; set; }
        [Description("OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS_DESCRIPCION")]
        public String OBLI_NM_IMPLEMENTACIONMEDIDASCORRECTIVAS_DESCRIPCION { get; set; }
        //17
        [Description("OBLI_NM_IMPMEDCORRECRESULTADOACCIONES")]
        public String OBLI_NM_IMPMEDCORRECRESULTADOACCIONES { get; set; }
        [Description("OBLI_NM_IMPMEDCORRECRESULTADOACCIONES_DESCRIPCION")]
        public String OBLI_NM_IMPMEDCORRECRESULTADOACCIONES_DESCRIPCION { get; set; }
        //18
        [Description("OBLI_NM_PROMUEVENBUENASPRACTICAS")]
        public String OBLI_NM_PROMUEVENBUENASPRACTICAS { get; set; }
        [Description("OBLI_NM_PROMUEVENBUENASPRACTICAS_DESCRIPCION")]
        public String OBLI_NM_PROMUEVENBUENASPRACTICAS_DESCRIPCION { get; set; }
        //19
        [Description("OBLI_NM_PROMUEVEEQUIDAD")]
        public String OBLI_NM_PROMUEVEEQUIDAD { get; set; }
        [Description("OBLI_NM_PROMUEVEEQUIDAD_DESCRIPCION")]
        public String OBLI_NM_PROMUEVEEQUIDAD_DESCRIPCION { get; set; }
        //
        [Description("OD_AMBITO")]
        public String OD_AMBITO { get; set; }
        [Description("TIPO_INFORME")]
        public String TIPO_INFORME { get; set; }
        [Description("OPORTUNIDAD")]
        public String OPORTUNIDAD { get; set; }
        [Description("VOLUMEN_JUSTIFICADO")]
        public Decimal VOLUMEN_JUSTIFICADO { get; set; }
        [Description("VOLUMEN_INJUSTIFICADO")]
        public Decimal VOLUMEN_INJUSTIFICADO { get; set; }
        [Description("TOTAL_INEXISTENTE")]
        public Int32 TOTAL_INEXISTENTE { get; set; }
        #endregion
        [Category("LIST"), Description("ListObligacionMaderable")]
        public List<Ent_REPORTE_SUPERVISION_GENERAL> ListObligacionMaderable { get; set; }
        [Category("LIST"), Description("ListObligacionNoMaderable")]
        public List<Ent_REPORTE_SUPERVISION_GENERAL> ListObligacionNoMaderable { get; set; }

        public Ent_REPORTE_SUPERVISION_GENERAL()
        {
            MUESTRA = -1;
            ADICIONAL = -1;
            NO_AUTORIZADO = -1;

            Anios = -1;
            AREA_POA = -1;
            AREA_TH = -1;
            N_Supervisiones = -1;

            CANT_BS = -1;
            CANT_CCNN = -1;
            CANT_PP = -1;
            CANT_CCCC = -1;
            CANT_TARA = -1;
            CANT_BL = -1;
            CANT_CMADE = -1;
            CANT_NM = -1;
            CANT_FYR = -1;
            TOTAL = -1;

            CANT_ZOOL = -1;
            CANT_ZOOC = -1;
            CANT_CRES = -1;
            CANT_CCT = -1;
            CANT_NMCAST = -1;
            CANT_NMSHIR = -1;
            CANT_NMAGU = -1;
            CANT_ECO = -1;
            CANT_CONS = -1;
            CANT_CFAUNA = -1;
            CANT_PFAUNA = -1;
            CANT_SISAG = -1;
            CANT_CARRIZO = -1;
            CANT_PMEDICI = -1;
            CANT_CCCC_CCNN = -1;
            CANT_PNM = -1;


            ArbolesSupervisados = -1;

            ANIO = -1;
            CATEGORIA = -1;
            CONCESIONES = -1;
            PERMISO = -1;
            TOTAL = -1;
            TOTALDOUBLE = -1;
            TOTALCONCESION = -1;
            DOSMILCINCO = -1;
            DOSMILSEIS = -1;
            DOSMILSIETE = -1;
            DOSMILOCHO = -1;
            DOSMILNUEVE = -1;
            DOSMILDIEZ = -1;
            DOSMILONCE = -1;
            DOSMILDOCE = -1;
            DOSMILTRECE = -1;
            DOSMILCATORCE = -1;
            DOSMILQUINCE = -1;
            DOSMILDIECISEIS = -1;
            DAP = -1;
            //AREA = -1;
            //AREA_OTORGADA = -1;
            //SistemasAgroforestales = -1;
            NUM_ARBOL = -1;

            //N_POA = -1;
            MULTA_RDTERMINO = -1;
            MULTA_RDRECON = -1;
            MULTA_RDRECTIF = -1;

            //carrizo_bambu_totora = -1;
            //plantas_medicinales = -1;
            MULTA_TFFS = -1;

            MULTA_RDTERMINO_2 = -1;
            MULTA_RDRECTIF_2 = -1;
            MULTA_RDRECON_2 = -1;
            MULTA_TFFS_2 = -1;
            //
            VOLUMEN_INJUSTIFICADO = -1;
            VOLUMEN_JUSTIFICADO = -1;
            TOTAL_INEXISTENTE = -1;
        }

    }
}
