using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_InformeAutoridadForestal
    {
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }

        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("NUMERO")]
        public String NUMERO { get; set; }
        [Description("COD_ENTIDAD")]
        public String COD_ENTIDAD { get; set; }
        [Description("ENTIDAD")]
        public String ENTIDAD { get; set; }
        [Category("FECHA"), Description("FECHA_EMISION")]
        public Object FECHA_EMISION { get; set; }
        [Category("FECHA"), Description("FECHA_RECEPCION")]
        public Object FECHA_RECEPCION { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }

        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        //
        [Description("COD_ITIPO")]
        public String COD_ITIPO { get; set; }
        //
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("CONCLUSIONES")]
        public String CONCLUSIONES { get; set; }
        [Description("DOCUMENTOS_ADJUNTOS")]
        public String DOCUMENTOS_ADJUNTOS { get; set; }
        [Description("OBSERVACIONES")]
        public String OBSERVACIONES { get; set; }

        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }

        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("PERSONA")]
        public String PERSONA { get; set; }
        [Description("COD_OD_REGISTRO")]
        public String COD_OD_REGISTRO { get; set; }

        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public Object OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }
        [Description("PUBLICAR")]
        public Object PUBLICAR { get; set; }

        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("OUTPUTPARAM01")]
        public String OUTPUTPARAM01 { get; set; }

        //Variables de Riesgo para el Observatorio
        //[Description("NIVEL_RIESGO")]
        //public String NIVEL_RIESGO { get; set; }
        //[Description("TIPO_RIESGO")]
        //public String TIPO_RIESGO { get; set; }
        //[Description("OBSERVACION_RIESGO")]
        //public String OBSERVACION_RIESGO { get; set; }

        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Category("FK"), Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Category("FK"), Description("COD_ENCIENTIFICO")]
        public String COD_ENCIENTIFICO { get; set; }
        [Description("VOLUMEN")]
        public Decimal VOLUMEN { get; set; }
        [Description("NOMBRE_CIENTIFICO")]
        public String NOMBRE_CIENTIFICO { get; set; }
        [Description("NOMBRE_COMUN")]
        public String NOMBRE_COMUN { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }

        [Description("MOTIVO_RENUNCIA")]
        public String MOTIVO_RENUNCIA { get; set; }
        [Description("NUM_DOCUMENTO_AUTORIDAD")]
        public String NUM_DOCUMENTO_AUTORIDAD { get; set; }
        [Category("FECHA"), Description("FECHA_DOCUMENTO_AUTORIDAD")]
        public Object FECHA_DOCUMENTO_AUTORIDAD { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        [Category("LIST"), Description("ListVolInjustificado")]
        public List<Ent_InformeAutoridadForestal> ListVolInjustificado { get; set; }
        [Category("LIST"), Description("ListMComboDIdentidad")]
        public List<Ent_InformeAutoridadForestal> ListMComboDIdentidad { get; set; }
        [Category("LIST"), Description("ListTipoInformes")]
        public List<Ent_InformeAutoridadForestal> ListTipoInformes { get; set; }
        [Category("LIST"), Description("ListPersEspecialidad")]
        public List<Ent_InformeAutoridadForestal> ListPersEspecialidad { get; set; }
        [Category("LIST"), Description("ListNivelAcademico")]
        public List<Ent_InformeAutoridadForestal> ListNivelAcademico { get; set; }
        [Category("LIST"), Description("ListProfesionales")]
        public List<Ent_GENEPERSONA> ListProfesionales { get; set; }
        [Category("LIST"), Description("ListEntidad")]
        public List<Ent_InformeAutoridadForestal> ListEntidad { get; set; }
        [Category("LIST"), Description("ListIndicador")]
        public List<Ent_InformeAutoridadForestal> ListIndicador { get; set; }
        [Category("LIST"), Description("ListODs")]
        public List<Ent_InformeAutoridadForestal> ListODs { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_InformeAutoridadForestal> ListEliTABLA { get; set; }
        [Category("LIST"), Description("ListEspeciesCientifico")]
        public List<Ent_InformeAutoridadForestal> ListEspeciesCientifico { get; set; }

        //25/09/2017
        [Description("ESPECIES")]
        public String ESPECIES { get; set; }
        [Description("VOLUMEN_APROBADO")]
        public Decimal VOLUMEN_APROBADO { get; set; }
        [Description("VOLUMEN_MOVILIZADO")]
        public Decimal VOLUMEN_MOVILIZADO { get; set; }
        [Description("VOLUMEN_JUSTIFICADO")]
        public Decimal VOLUMEN_JUSTIFICADO { get; set; }
        [Description("VOLUMEN_INJUSTIFICADO")]
        public Decimal VOLUMEN_INJUSTIFICADO { get; set; }
        [Category("LIST"), Description("ListMComboEspecie")]
        public List<Ent_InformeAutoridadForestal> ListMComboEspecie { get; set; }

        public Ent_InformeAutoridadForestal()
        {
            NUM_POA = -1;
            RegEstado = -1;
            COD_SECUENCIAL = -1;
            VOLUMEN = -1;
            VOLUMEN_APROBADO = -1;
            VOLUMEN_INJUSTIFICADO = -1;
            VOLUMEN_JUSTIFICADO = -1;
            VOLUMEN_MOVILIZADO = -1;
        }
    }
}
