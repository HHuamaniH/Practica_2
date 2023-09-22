using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DOC
{
    public class Ent_ALERTA

    {
        [Description("BUSFORMULARIO")]
        public String BUSFORMULARIO { get; set; }
        [Description("BUSCRITERIO")]
        public String BUSCRITERIO { get; set; }
        [Description("BUSVALOR")]
        public String BUSVALOR { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        [Description("FECHA")]
        public String FECHA { get; set; }
        [Description("COD_BITACORA")]
        public String COD_BITACORA { get; set; }
        [Description("OD")]
        public String OD { get; set; }
        [Description("SUPERVISOR")]
        public String SUPERVISOR { get; set; }
        [Description("CARTA_NOTIFICACION")]
        public String CARTA_NOTIFICACION { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("SUPERVISADO")]
        public Object SUPERVISADO { get; set; }
        [Description("TIPO_INFORME")]
        public String TIPO_INFORME { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("ENVIAR_ALERTA_TEXT")]
        public String ENVIAR_ALERTA_TEXT { get; set; }
        [Description("FECHA_SALIDA")]
        public String FECHA_SALIDA { get; set; }
        [Description("FECHA_LLEGADA")]
        public String FECHA_LLEGADA { get; set; }
        [Description("USUARIO")]
        public String USUARIO { get; set; }

        //DOC_OSINFOR_ERP_MIGRACION.spBITACORA_SUPERVISION_MensajeAlerta
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("NUM_CNOTIFICACION")]
        public String NUM_CNOTIFICACION { get; set; }
        [Description("UBICACION")]
        public String UBICACION { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("POA")]
        public String POA { get; set; }
        [Description("DESTINO_ENVIO_TEXT")]
        public String DESTINO_ENVIO_TEXT { get; set; }
        [Description("ARCHIVO_OFICIO")]
        public String ARCHIVO_OFICIO { get; set; }
        [Description("ARCHIVO_OFICIO_TEXT")]
        public String ARCHIVO_OFICIO_TEXT { get; set; }
        [Description("COD_CNOTIFICACION")]
        public String COD_CNOTIFICACION { get; set; }
        [Description("VERTICE")]
        public String VERTICE { get; set; }
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("OBSERVACIONES")]
        public String OBSERVACIONES { get; set; }
        [Description("ACTA_ARCHIVO")]
        public String ACTA_ARCHIVO { get; set; }
        [Description("ACTA_ARCHIVO_TEXT")]
        public String ACTA_ARCHIVO_TEXT { get; set; }
        [Description("ENVIAR_ALERTA")]
        public Object ENVIAR_ALERTA { get; set; }
        [Description("FECHA_ENVIO_ALERTA")]
        public String FECHA_ENVIO_ALERTA { get; set; }
        [Description("ASUNTO_ENVIO_ALERTA")]
        public String ASUNTO_ENVIO_ALERTA { get; set; }
        [Description("DESTINO_ENVIO_ALERTA")]
        public String DESTINO_ENVIO_ALERTA { get; set; }
        [Description("CONCOPIA_ENVIO_ALERTA")]
        public String CONCOPIA_ENVIO_ALERTA { get; set; }
        [Description("MENSAJE_ENVIO_ALERTA")]
        public String MENSAJE_ENVIO_ALERTA { get; set; }
        [Description("USUARIO_ENVIA")]
        public String USUARIO_ENVIA { get; set; }
        [Description("COD_SECUENCIAL_ACTA")]
        public Int32 COD_SECUENCIAL_ACTA { get; set; }
        [Description("NOMBRE_ARCH")]
        public String NOMBRE_ARCH { get; set; }
        [Description("EXTENSION_ARCH")]
        public String EXTENSION_ARCH { get; set; }
        [Description("NOMBRE_ARCH_ANTIGUO")]
        public String NOMBRE_ARCH_ANTIGUO { get; set; }
        [Description("COD_GUID")]
        public String COD_GUID { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("ESPECIES")]
        public String ESPECIES { get; set; }
        [Description("FECHA_EMISION_BX")]
        public String FECHA_EMISION_BX { get; set; }
        [Description("TOTAL_ARBOLES")]
        public Int32 TOTAL_ARBOLES { get; set; }
        [Description("VOLUMEN_AUTORIZADO")]
        public Decimal VOLUMEN_AUTORIZADO { get; set; }
        [Description("VOLUMEN_MOVILIZADO")]
        public Decimal VOLUMEN_MOVILIZADO { get; set; }
        [Description("SALDO")]
        public Decimal SALDO { get; set; }
        [Description("FECHA_BALANCE")]
        public Object FECHA_BALANCE { get; set; }
        [Description("NUM_POA_DETALLE")]
        public String NUM_POA_DETALLE { get; set; }
        [Description("NOMBRE_POA")]
        public String NOMBRE_POA { get; set; }
        [Description("COD_DOCRECIBIDO")]
        public Int32 COD_DOCRECIBIDO { get; set; }
        [Description("EXPEDIENTE")]
        public String EXPEDIENTE { get; set; }
        [Description("OUTPUTPARAM01")]
        public String OUTPUTPARAM01 { get; set; }
        [Description("FECHA_EXPEDIENTE")]
        public object FECHA_EXPEDIENTE { get; set; }
        [Description("DOCUMENTO")]
        public String DOCUMENTO { get; set; }
        [Description("OFICINA")]
        public String OFICINA { get; set; }
        [Description("COD_RPTAENLACE")]
        public Int32 COD_RPTAENLACE { get; set; }
        [Description("PROCEDIMIENTO")]
        public String PROCEDIMIENTO { get; set; }

        [Description("FECHA_RESPUESTA")]
        public object FECHA_RESPUESTA { get; set; }
        [Description("LUGAR")]
        public String LUGAR { get; set; }
        [Description("RECOMENDACION")]
        public String RECOMENDACION { get; set; }
        
        //agregados
        [Description("ARCHIVOS")]
        public String ARCHIVOS { get; set; }
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("COD_SUPERVISOR")]
        public String COD_SUPERVISOR { get; set; }
        [Description("COD_INFOGEO")]
        public Int32 COD_INFOGEO { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("SUPERVISADO_TEXT")]
        public String SUPERVISADO_TEXT { get; set; }
        [Description("COD_ITIPO")]
        public String COD_ITIPO { get; set; }
        [Description("COD_REQUE")]
        public Int32 COD_REQUE { get; set; }
        [Description("ALERTA_ILEGAL_TEXT")]
        public String ALERTA_ILEGAL_TEXT { get; set; }
        [Description("ALERTA_ILEGAL")]
        public Object ALERTA_ILEGAL { get; set; }
        [Description("DES_ALERTA_ILEGAL")]
        public String DES_ALERTA_ILEGAL { get; set; }
        [Description("VOLUMEN_INJUSTIFICADO")]
        public Decimal VOLUMEN_INJUSTIFICADO { get; set; }
        [Description("OTROS_HECHO")]
        public String OTROS_HECHO { get; set; }
        [Description("NOTIFICAR_ARCHIVO")]
        public Object NOTIFICAR_ARCHIVO { get; set; }
        [Description("ARCHIVOS_NTF")]
        public String ARCHIVOS_NTF { get; set; }
        [Category("FECHA"), Description("FECHA_INICIO_SUPERVISION")]
        public Object FECHA_INICIO_SUPERVISION { get; set; }
        [Category("FECHA"), Description("FECHA_FIN_SUPERVISION")]
        public Object FECHA_FIN_SUPERVISION { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAMDET01")]
        public Object OUTPUTPARAMDET01 { get; set; }
        [Description("RUTA_ARCH")]
        public String RUTA_ARCH { get; set; }
        [Description("COD_OD")]
        public String COD_OD { get; set; }
        [Description("POAS")]
        public String POAS { get; set; }
        [Description("FILE")]
        public Object FILE { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("COD_UCUENTA_ENVIA")]
        public String COD_UCUENTA_ENVIA { get; set; }
        [Description("ESTADO_ARCHIVO_OFICIO")]
        public string ESTADO_ARCHIVO_OFICIO { get; set; }
        [Description("DESTINATARIO")]
        public string DESTINATARIO { get; set; }
        [Description("ACTIVO")]
        public Int32 ACTIVO { get; set; }
        [Description("DESTINATARIO_CC")]
        public string DESTINATARIO_CC { get; set; }
        [Description("SUPUESTO")]
        public string SUPUESTO { get; set; }

        [Description("COD_SUPUESTO")]
        public int? COD_SUPUESTO { get; set; }

        [Description("TOKEN")]
        public string TOKEN { get; set; }


        //Lista Objetos
        [Category("LIST"), Description("ListALERTA")]
        public List<Ent_ALERTA> ListALERTA { get; set; }
        [Category("LIST"), Description("ListVertices")]
        public List<Ent_ALERTA> ListVertices { get; set; }
        [Category("LIST"), Description("ListBitacoras")]
        public List<Ent_ALERTA> ListBitacoras { get; set; }
        [Category("LIST"), Description("ListBEXT")]
        public List<Ent_ALERTA> ListBEXT { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_ALERTA> ListEliTABLA { get; set; }
        [Category("LIST"), Description("ListInformeDetSupervisor")]
        public List<Ent_GENEPERSONA> ListInformeDetSupervisor { get; set; }
        [Category("LIST"), Description("ListInfoGeo")]
        public List<Ent_ALERTA> ListInfoGeo { get; set; }
        [Category("LIST"), Description("ListDetActa")]
        public List<Ent_ALERTA> ListDetActa { get; set; }
        [Category("LIST"), Description("ListOD")]
        public List<Ent_ALERTA> ListOD { get; set; }
        [Category("LIST"), Description("ListInformeTipo")]
        public List<Ent_ALERTA> ListInformeTipo { get; set; }
        [Category("LIST"), Description("ListDepartamentos")]
        public List<Ent_ALERTA> ListDepartamentos { get; set; }
        [Category("LIST"), Description("ListSupuestos")]
        public List<Ent_ALERTA> ListSupuestos { get; set; }
        [Category("LIST"), Description("ListDestinatario")]
        public List<Ent_ALERTA> ListDestinatario { get; set; }
        [Category("LIST"), Description("ListDestinatarioCC")]
        public List<Ent_ALERTA> ListDestinatarioCC { get; set; }
        [Category("LIST"), Description("ListDocRecibido")]
        public List<Ent_ALERTA> ListDocRecibido { get; set; }
        [Category("LIST"), Description("ListRptaEnlace")]
        public List<Ent_ALERTA> ListRptaEnlace { get; set; }
        
        [Description("LOG_ENVIO_ALERTA")]
        public String LOG_ENVIO_ALERTA { get; set; }


        public Ent_ALERTA()
        {
            RegEstado = -1;
            COD_SECUENCIAL_ACTA = -1;
            COD_SECUENCIAL = -1;
            COD_REQUE = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            COD_INFOGEO = -1;
            VOLUMEN_INJUSTIFICADO = -1;
            NUM_POA = -1;
            TOTAL_ARBOLES = -1;
            VOLUMEN_AUTORIZADO = -1;
            VOLUMEN_INJUSTIFICADO = -1;
            VOLUMEN_MOVILIZADO = -1;
            SALDO = -1;
            COD_DOCRECIBIDO = -1;
            COD_RPTAENLACE = -1;
            ACTIVO = -1;

        }
    }
}
