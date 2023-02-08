using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class IDENUNCIA : Base
    {
        #region "Entidades y Propiedades"
        [Description("TIPO")]
        public string TIPO { get; set; }
        [Description("COD_IDENUNCIA")]
        public string COD_IDENUNCIA { get; set; }
        [Description("ICOMPETENCIA")]
        public int ICOMPETENCIA { get; set; }
        [Description("NOMBRE_DEPENDENCIA")]
        public string NOMBRE_DEPENDENCIA { get; set; }
        public string DEPENDENCIA { get; set; }
        [Description("CONCLUSION")]
        public string CONCLUSION { get; set; }
        [Description("RECOMENDACION")]
        public string RECOMENDACION { get; set; }
        [Description("IATENDIDO")]
        public int IATENDIDO { get; set; }
        public Tra_M_Tramite tra_M_Tramite { get; set; }
        public Tra_M_Tramite DocsSITD { get; set; }
        public List<IDENUNCIA_ITECNICO> IDENUNCIA_ITECNICOS { get; set; }
        public List<IDENUNCIA_AUDITORIA_ARCHIVO> iDENUNCIA_AUDITORIA_ARCHIVO { get; set; }
        public List<IDENUNCIA_THABILITANTE> iDENUNCIA_THABILITANTEs { get; set; }
        public List<IDenunciaDetInformeSupervision> IDenunciaDetInformeSupervision { get; set; }
        public List<IDenunciaDetDocumentosSITD> IDenunciaDetDocumentosSITD { get; set; }
        public bool B_FLAG_AUDITORIA { get; set; }
        public Ent_INFORME ENT_INFORME { get; set; }
        public int iAnio { get; set; }
        public string Informes { get; set; }
        public string Auditoria { get; set; }
        public string THabilitante { get; set; }
        public List<IDENUNCIA_ITECNICO> IDENUNCIA_CARTA_OFICIO { get; set; }
        [Description("FLAG_THABILITANTE")]
        public int FLAG_THABILITANTE { get; set; }
        [Description("TIPO_REQUERIMIENTO")]
        public string TIPO_REQUERIMIENTO { get; set; }
        [Description("TIPO_REQUERIMIENTO_OTRO")]
        public string TIPO_REQUERIMIENTO_OTRO { get; set; }
        [Description("TIPO_TRASLADO")]
        public string TIPO_TRASLADO { get; set; }
        public IDENUNCIA()
        {
            FLAG_THABILITANTE = -1;
        }
        #endregion
    }
    public class IDENUNCIA_ITECNICO : Base
    {
        [Description("COD_IDENUNCIA_ITECNICO")]
        public string COD_IDENUNCIA_ITECNICO { get; set; }
        [Description("COD_IDENUNCIA")]
        public string COD_IDENUNCIA { get; set; }
        [Description("NOMBRE_INFORME")]
        public string NOMBRE_INFORME { get; set; }
        public bool B_FLAG { get; set; }
        public List<IDENUNCIA_ITECNICO_ARCHIVOS> IDENUNCIA_ITECNICO_ARCHIVOS { get; set; }
        public IDENUNCIA_ITECNICO()
        {
        }
    }
    public class IDENUNCIA_ITECNICO_ARCHIVOS : Base
    {
        [Description("COD_IDENUNCIA_ITECNICO_ARCHIVOS")]
        public string COD_IDENUNCIA_ITECNICO_ARCHIVOS { get; set; }
        [Description("COD_COD_IDENUNCIA_ITECNICO")]
        public string COD_COD_IDENUNCIA_ITECNICO { get; set; }
        [Description("URL_TECNICO")]
        public string URL_TECNICO { get; set; }
        [Description("NOMBRE_ARCHIVO")]
        public string NOMBRE_ARCHIVO { get; set; }
        [Description("ARCHIVO_EXTENSION")]
        public string ARCHIVO_EXTENSION { get; set; }
    }
    public class IDENUNCIA_AUDITORIA_ARCHIVO : Base
    {
        [Description("COD_IDENUNCIA_AUDITORIA_ARCHIVO")]
        public string COD_IDENUNCIA_AUDITORIA_ARCHIVO { get; set; }
        [Description("COD_IDENUNCIA")]
        public string COD_IDENUNCIA { get; set; }
        [Description("URL_TECNICO")]
        public string URL_TECNICO { get; set; }
        [Description("NOMBRE_ARCHIVO")]
        public string NOMBRE_ARCHIVO { get; set; }
        [Description("ARCHIVO_EXTENSION")]
        public string ARCHIVO_EXTENSION { get; set; }
    }
    public class IDENUNCIA_THABILITANTE : Base
    {
        [Description("COD_IDENUNCIA_THABILITANTE")]
        public int COD_IDENUNCIA_THABILITANTE { get; set; }
        [Description("COD_IDENUNCIA")]
        public string COD_IDENUNCIA { get; set; }
        [Description("COD_THABILITANTE")]
        public string COD_THABILITANTE { get; set; }
        public Ent_THABILITANTE ent_THABILITANTE { get; set; }
        public IDENUNCIA_THABILITANTE()
        {
            COD_IDENUNCIA_THABILITANTE = -1;
        }
    }
    public class IDenunciaDetInformeSupervision : Base
    {
        [Description("PK_IDenunciaDetInformeSupervision")]
        public int PK_IDENUNCIADETINFORMESUPERVISION { get; set; }
        [Description("VCodIDenuncia")]
        public string VCODIDENUNCIA { get; set; }
        [Description("VCodInforme")]
        public string VCODINFORME { get; set; }
        public Ent_INFORME ent_INFORME { get; set; }
        public IDenunciaDetInformeSupervision()
        {
            PK_IDENUNCIADETINFORMESUPERVISION = -1;
        }
    }
    public class IDenunciaDetDocumentosSITD : Base
    {
        [Description("PK_IDenunciaDetDocumentosSITD")]
        public int PK_IDENUNCIADETDOCUMENTOSSITD { get; set; }
        [Description("VCodIDenuncia")]
        public string VCODIDENUNCIA { get; set; }
        [Description("VCodTramite")]
        public string VCODTRAMITE { get; set; }
        [Description("VCodificacion")]
        public string VCODIFICACION { get; set; }
        [Description("VNroDocumento")]
        public string VNRODOCUMENTO { get; set; }
        [Description("VFecDocumento")]
        public string VFECDOCUMENTO { get; set; }
        [Description("VDescTipoDoc")]
        public string VDESCTIPODOC { get; set; }
        [Description("VAsunto")]
        public string VASUNTO { get; set; }
        [Description("VPDF_TRAMITE_SITD")]
        public string VPDF_TRAMITE_SITD { get; set; }

        public IDenunciaDetDocumentosSITD()
        {
            PK_IDENUNCIADETDOCUMENTOSSITD = -1;
        }
    }
    public class IDenunciaDetInformesPAO : Base
    {
        [Description("PK_IDenunciaDetInformesPAO")]
        public int PK_IDENUNCIADETINFORMESPAO { get; set; }
        [Description("VCodIDenuncia")]
        public string VCODIDENUNCIA { get; set; }
        [Description("VCodInforme")]
        public string VCODINFORME { get; set; }
        
        public Ent_INFORME ent_INFORME { get; set; }
        public IDenunciaDetInformesPAO()
        {
            PK_IDENUNCIADETINFORMESPAO = -1;
        }
    }
    public class Tra_M_Tramite
    {
        [Description("iCodTramite")]
        public int iCodTramite { get; set; }
        [Description("cNomTupa")]
        public string cNomTupa { get; set; }
        [Description("cNomTupaClase")]
        public string cNomTupaClase { get; set; }
        [Description("cCodificacion")]
        public string cCodificacion { get; set; }
        [Description("fFecDocumento")]
        public string fFecDocumento { get; set; }
        [Description("vTrabajador")]
        public string vTrabajador { get; set; }
        [Description("cDescTipoDoc")]
        public string cDescTipoDoc { get; set; }
        [Description("cNroDocumento")]
        public string cNroDocumento { get; set; }
        [Description("cNombre")]
        public string cNombre { get; set; }
        [Description("cAsunto")]
        public string cAsunto { get; set; }
        [Description("iCodTupa")]
        public int iCodTupa { get; set; }
        [Description("iCodTupaClase")]
        public int iCodTupaClase { get; set; }
        [Description("cNombreNuevo")]
        public string cNombreNuevo { get; set; }
        [Description("DESCARGA")]
        public string DESCARGA { get; set; }
        [Description("COD_EXPEDIENTE")]
        public int COD_EXPEDIENTE { get; set; }
        [Description("COD_RESODIREC")]
        public string COD_RESODIREC { get; set; }
        [Description("USUARIO")]
        public int USUARIO { get; set; }
        [Description("tipo")]
        public int tipo { get; set; }
        [Description("sDescarga")]
        public string sDescarga { get; set; }
        [Description("iEstado")]
        public int iEstado { get; set; }
        [Description("PLAZO_DIA")]
        public int PLAZO_DIA { get; set; }
        [Description("PLAZO_MES")]
        public int PLAZO_MES { get; set; }
        [Description("iTipo")]
        public int iTipo { get; set; }
        [Description("nomEstado")]
        public string nomEstado { get; set; }
        [Description("iCodMandato")]
        public int iCodMandato { get; set; }
        public IMANDATO_SUPERVISION_ARCHIVOS ADJMANDATO { get; set; }
        [Description("Destino")]
        public string Destino { get; set; }
        [Description("PDF_TRAMITE_SITD")]
        public string PDF_TRAMITE_SITD { get; set; }

        public Tra_M_Tramite()
        {
            this.iCodTupa = -1;
            this.iCodTupaClase = -1;
            this.iCodMandato = -1;
            this.iCodTramite = -1;
            this.iCodTupa = -1;
            this.iCodTupaClase = -1;
            this.COD_EXPEDIENTE = -1;
            this.USUARIO = -1;
            this.tipo = -1;
            this.iEstado = -1;
            this.PLAZO_DIA = -1;
            this.PLAZO_MES = -1;
            this.iTipo = -1;
        }
    }

    public class IMANDATO_SUPERVISION_ARCHIVOS
    {

        [Description("URLDIGITAL")]
        public string URLDIGITAL { get; set; }
        [Description("URLNOMBRE")]
        public string URLNOMBRE { get; set; }
        [Description("ARCHIVO_EXTENSION")]
        public string ARCHIVO_EXTENSION { get; set; }
    }

    public class ArchivoMandato
    {
        public byte[] file { get; set; }
        public string path { get; set; }
        public string mineType { get; set; }
        public string mensaje { get; set; }
        public string[] fileExtensiones { get; set; }
        public bool validation { get; set; }
        public List<string> fileNames { get; set; }
        public int ID { get; set; }
        public string encode64 { get; set; }
        public List<IMANDATO_SUPERVISION_ARCHIVOS> Archivos { get; set; }
    }
    public class Archivo
    {
        public byte[] file { get; set; }
        public string path { get; set; }
        public string mineType { get; set; }
        public string mensaje { get; set; }
        public string[] fileExtensiones { get; set; }
        public bool validation { get; set; }
        public List<string> fileNames { get; set; }
        public int ID { get; set; }
        public string encode64 { get; set; }
        public List<IDENUNCIA_ITECNICO_ARCHIVOS> Archivos { get; set; }
    }
    public class IINCIDENCIA : Base
    {
        public int ITipo { get; set; }
        [Description("COD_IINCIDENCIA")]
        public string COD_IINCIDENCIA { get; set; }
        [Description("COD_INFORME")]
        public string COD_INFORME { get; set; }
        [Description("FECHA_SUCESO")]
        public string FECHA_SUCESO { get; set; }
        [Description("HORA_SUCESO")]
        public string HORA_SUCESO { get; set; }
        [Description("COD_IINCIDENCIA_PROTOCOLOS_RIESGO")]
        public string COD_IINCIDENCIA_PROTOCOLOS_RIESGO { get; set; }
        public IINCIDENCIA_PROTOCOLOS OBJCOD_IINCIDENCIA_PROTOCOLOS_RIESGO { get; set; }
        [Description("COD_IINCIDENCIA_PROTOCOLOS_PROCESO")]
        public string COD_IINCIDENCIA_PROTOCOLOS_PROCESO { get; set; }
        public IINCIDENCIA_PROTOCOLOS OBJCOD_IINCIDENCIA_PROTOCOLOS_PROCESO { get; set; }
        [Description("COD_IINCIDENCIA_PROTOCOLOS_CIRCUNSTANCIA")]
        public string COD_IINCIDENCIA_PROTOCOLOS_CIRCUNSTANCIA { get; set; }
        public IINCIDENCIA_PROTOCOLOS OBJCOD_IINCIDENCIA_PROTOCOLOS_CIRCUNSTANCIA { get; set; }
        [Description("UBICACION")]
        public string UBICACION { get; set; }
        [Description("COD_IINCIDENCIA_PROTOCOLOS_EFECTO")]
        public string COD_IINCIDENCIA_PROTOCOLOS_EFECTO { get; set; }
        public IINCIDENCIA_PROTOCOLOS OBJCOD_IINCIDENCIA_PROTOCOLOS_EFECTO { get; set; }
        [Description("COD_IINCIDENCIA_PROTOCOLOS_NIVEL_1")]
        public string COD_IINCIDENCIA_PROTOCOLOS_NIVEL_1 { get; set; }
        public IINCIDENCIA_PROTOCOLOS OBJCOD_IINCIDENCIA_PROTOCOLOS_NIVEL_1 { get; set; }
        [Description("COD_IINCIDENCIA_PROTOCOLOS_NIVEL_2")]
        public string COD_IINCIDENCIA_PROTOCOLOS_NIVEL_2 { get; set; }
        public IINCIDENCIA_PROTOCOLOS OBJCOD_IINCIDENCIA_PROTOCOLOS_NIVEL_2 { get; set; }
        [Description("DSCRPINCIDENCIA")]
        public string DSCRP_INCIDENCIA { get; set; }
        [Description("OBSERVACIONES")]
        public string OBSERVACIONES { get; set; }
        public IINCIDENCIA()
        {
            ITipo = -1;
        }
    }
    public class IINCIDENCIA_TIPO_PROTOCOLO : Base
    {
        [Description("COD_IINCIDENCIA_TIPO_PROTOCOLO")]
        public string COD_IINCIDENCIA_TIPO_PROTOCOLO { get; set; }
        [Description("NOMBRE_TIPO_PROTOCOLO")]
        public string NOMBRE_TIPO_PROTOCOLO { get; set; }
    }
    public class IINCIDENCIA_PROTOCOLOS : Base
    {
        [Description("COD_IINCIDENCIA_PROTOCOLOS")]
        public string COD_IINCIDENCIA_PROTOCOLOS { get; set; }
        [Description("NOMBRE_PROTOCOLO")]
        public string NOMBRE_PROTOCOLO { get; set; }
        [Description("TIPO_PROTOCOLO")]
        public string TIPO_PROTOCOLO { get; set; }
        [Description("SECCION")]
        public string SECCION { get; set; }
        [Description("PROTOCOLO_PADRE")]
        public string PROTOCOLO_PADRE { get; set; }
        public IINCIDENCIA_TIPO_PROTOCOLO iINCIDENCIA_TIPO_PROTOCOLO { get; set; }
        public IINCIDENCIA_PROTOCOLOS OBJPROTOCOLO_PADRE { get; set; }
    }
    public abstract class Base
    {
        [Description("FECHA_CREACION")]
        public string FECHA_CREACION { get; set; }
        [Description("FECHA_MODIFICAR")]
        public string FECHA_MODIFICAR { get; set; }
        [Description("FECHA_ELIMINACION")]
        public string FECHA_ELIMINACION { get; set; }
        [Description("ESTADO")]
        public string ESTADO { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("COD_UCUENTA_MODIFICA")]
        public string COD_UCUENTA_MODIFICA { get; set; }
        [Description("COD_UCUENTA_ELIMINA")]
        public string COD_UCUENTA_ELIMINA { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int rowCount { get; set; }

        protected Base()
        {
            PageSize = -1;
            CurrentPage = -1;
            rowCount = -1;
        }
    }
}