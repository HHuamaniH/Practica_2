using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_BITACORA_SUPER
    {

        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public String EliVALOR02 { get; set; }

        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }

        [Description("COD_REQUE")]
        public Int32 COD_REQUE { get; set; }

        [Description("COD_BITACORA")]
        public String COD_BITACORA { get; set; }
        [Description("COD_CNOTIFICACION")]
        public String COD_CNOTIFICACION { get; set; }
        [Description("NUM_CNOTIFICACION")]
        public String NUM_CNOTIFICACION { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }

        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("POA")]
        public String POA { get; set; }

        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("COD_OD")]
        public String COD_OD { get; set; }

        [Category("FECHA"), Description("FECHA_SALIDA")]
        public Object FECHA_SALIDA { get; set; }
        [Category("FECHA"), Description("FECHA_RECEPCION_CHEQUE")]
        public Object FECHA_RECEPCION_CHEQUE { get; set; }
        [Category("FECHA"), Description("FECHA_COBRO_CHEQUE")]
        public Object FECHA_COBRO_CHEQUE { get; set; }

        [Category("FECHA"), Description("FECHA_LLEGADA")]
        public Object FECHA_LLEGADA { get; set; }

        [Category("FECHA"), Description("FECHA_HORA_SALIDA")]
        public Object FECHA_HORA_SALIDA { get; set; }
        [Category("FECHA"), Description("FECHA_HORA_PROGRA_RETORNO")]
        public Object FECHA_HORA_PROGRA_RETORNO { get; set; }
        [Category("FECHA"), Description("FECHA_HORA_LLEGADA")]
        public Object FECHA_HORA_LLEGADA { get; set; }
        [Description("SUPERVISADO")]
        public object SUPERVISADO { get; set; }
        [Description("SUPERVISADO_TEXT")]
        public String SUPERVISADO_TEXT { get; set; }
        [Description("COD_ITIPO")]
        public String COD_ITIPO { get; set; }
        [Description("COD_SUPERVISOR")]
        public String COD_SUPERVISOR { get; set; }
        [Description("SUPERVISOR")]
        public String SUPERVISOR { get; set; }

        [Description("TIPO_INFORME")]
        public String TIPO_INFORME { get; set; }

        [Description("OBSERVACIONES")]
        public String OBSERVACIONES { get; set; }

        [Description("ALERTA_ILEGAL")]
        public Object ALERTA_ILEGAL { get; set; }
        [Description("ALERTA_ILEGAL_TEXT")]
        public String ALERTA_ILEGAL_TEXT { get; set; }
        [Description("DES_ALERTA_ILEGAL")]
        public String DES_ALERTA_ILEGAL { get; set; }

        [Description("ACTA_ARCHIVO")]
        public String ACTA_ARCHIVO { get; set; }
        [Description("ACTA_ARCHIVO_TEXT")]
        public String ACTA_ARCHIVO_TEXT { get; set; }
        [Description("OTROS_HECHO")]
        public String OTROS_HECHO { get; set; }

        [Description("ENVIAR_ALERTA")]
        public Object ENVIAR_ALERTA { get; set; }
        [Description("FECHA_ENVIO_ALERTA")]
        public String FECHA_ENVIO_ALERTA { get; set; }
        [Description("COD_UCUENTA_ENVIA")]
        public String COD_UCUENTA_ENVIA { get; set; }
        [Description("USUARIO_ENVIA")]
        public String USUARIO_ENVIA { get; set; }
        [Description("DESTINO_ENVIO_ALERTA")]
        public String DESTINO_ENVIO_ALERTA { get; set; }
        [Description("DESTINO_ENVIO_TEXT")]
        public String DESTINO_ENVIO_TEXT { get; set; }
        [Description("CONCOPIA_ENVIO_ALERTA")]
        public String CONCOPIA_ENVIO_ALERTA { get; set; }
        [Description("ASUNTO_ENVIO_ALERTA")]
        public String ASUNTO_ENVIO_ALERTA { get; set; }
        [Description("MENSAJE_ENVIO_ALERTA")]
        public String MENSAJE_ENVIO_ALERTA { get; set; }
        [Description("LOG_ENVIO_ALERTA")]
        public String LOG_ENVIO_ALERTA { get; set; }
        [Description("UBICACION")]
        public String UBICACION { get; set; }

        [Description("VERTICE")]
        public String VERTICE { get; set; }
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }

        [Description("COD_INFOGEO")]
        public Int32 COD_INFOGEO { get; set; }
        [Description("NOMBRE_ARCH")]
        public String NOMBRE_ARCH { get; set; }
        [Description("EXTENSION_ARCH")]
        public String EXTENSION_ARCH { get; set; }
        [Description("NOMBRE_ARCH_ANTIGUO")]
        public String NOMBRE_ARCH_ANTIGUO { get; set; }
        [Description("RUTA_ARCH")]
        public String RUTA_ARCH { get; set; }
        [Description("NOM_ARCH_TEMP")]
        public String NOM_ARCH_TEMP { get; set; }
        [Description("POAS")]
        public String POAS { get; set; }
        [Description("ARCHIVOS")]
        public String ARCHIVOS { get; set; }
        [Description("FILE")]
        public Object FILE { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAMDET01")]
        public Object OUTPUTPARAMDET01 { get; set; }
        
        [Description("NOTIFICAR_ARCHIVO")]
        public Object NOTIFICAR_ARCHIVO { get; set; }
        [Description("ARCHIVOS_NTF")]
        public String ARCHIVOS_NTF { get; set; }

        [Category("FECHA"), Description("FECHA_INICIO_SUPERVISION")]
        public Object FECHA_INICIO_SUPERVISION { get; set; }

        [Category("FECHA"), Description("FECHA_FIN_SUPERVISION")]
        public Object FECHA_FIN_SUPERVISION { get; set; }

        [Category("LIST"), Description("ListOD")]
        public List<Ent_BITACORA_SUPER> ListOD { get; set; }
        [Category("LIST"), Description("ListDepartamentos")]
        public List<Ent_BITACORA_SUPER> ListDepartamentos { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_BITACORA_SUPER> ListEliTABLA { get; set; }
        [Category("LIST"), Description("ListVertices")]
        public List<Ent_BITACORA_SUPER> ListVertices { get; set; }
        [Category("LIST"), Description("ListBitacoras")]
        public List<Ent_BITACORA_SUPER> ListBitacoras { get; set; }
        [Category("LIST"), Description("ListInformeTipo")]
        public List<Ent_BITACORA_SUPER> ListInformeTipo { get; set; }
        [Category("LIST"), Description("ListInformeDetSupervisor")]
        public List<Ent_GENEPERSONA> ListInformeDetSupervisor { get; set; }
        [Category("LIST"), Description("ListInfoGeo")]
        public List<Ent_BITACORA_SUPER> ListInfoGeo { get; set; }
        [Category("LIST"), Description("ListDetActa")]
        public List<Ent_BITACORA_SUPER> ListDetActa { get; set; }
        [Category("LIST"), Description("ListEncryp")]
        public List<Ent_BITACORA_SUPER> ListEncryp { get; set; }
        [Category("LIST"), Description("ListBEXT")]
        public List<Ent_BITACORA_SUPER> ListBEXT { get; set; }
        [Description("COD_SECUENCIAL_ACTA")]
        public int COD_SECUENCIAL_ACTA { get; set; }
        [Description("COD_SECUENCIAL_ENCRYP")]
        public int COD_SECUENCIAL_ENCRYP { get; set; }

        //09/10/2017
        [Category("FECHA"), Description("FECHA_RETORNO_CAMPO")]
        public Object FECHA_RETORNO_CAMPO { get; set; }
        [Description("CAPACITACION_PAUXILIOS")]
        public Object CAPACITACION_PAUXILIOS { get; set; }
        [Description("CAPACITACION_INCIDENTES")]
        public Object CAPACITACION_INCIDENTES { get; set; }

        //23/07/2018
        [Description("ARCHIVO_OFICIO")]
        public string ARCHIVO_OFICIO { get; set; }
        [Description("ARCHIVO_OFICIO_TEXT")]
        public string ARCHIVO_OFICIO_TEXT { get; set; }
        [Description("ESTADO_ARCHIVO_OFICIO")]
        public string ESTADO_ARCHIVO_OFICIO { get; set; }

        //13/09/2018
        [Description("VOLUMEN_INJUSTIFICADO")]
        public Decimal VOLUMEN_INJUSTIFICADO { get; set; }

        //16/05/2019 parametros para el balance 
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("NOMBRE_POA")]
        public String NOMBRE_POA { get; set; }
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
        //[Description("ESTADO")]
        //public Boolean ESTADO { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("ESPECIES")]
        public String ESPECIES { get; set; }      
        public Ent_BITACORA_SUPER()
        {
            RegEstado = -1;
            COD_SECUENCIAL_ACTA = -1;
            COD_SECUENCIAL = -1;
            COD_SECUENCIAL_ENCRYP = -1;
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
           
        }
    }
}
