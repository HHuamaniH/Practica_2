using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_ISUSPENSION
    {
        #region "Entidades y Propiedades"
        [Description("COD_INFORME")]
        public String COD_INFORME { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("CNOTIFICACION")]
        public String CNOTIFICACION { get; set; }
        [Description("COD_TITULAR")]
        public String COD_TITULAR { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("NUMERO")]
        public String NUMERO { get; set; }
        [Description("COD_ITIPO")]
        public String COD_ITIPO { get; set; }
        [Category("FK"), Description("COD_IMOTIVO")]
        public String COD_IMOTIVO { get; set; }
        [Category("FECHA"), Description("FECHA_EMISION_DIRECCION")]
        public Object FECHA_EMISION_DIRECCION { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }

        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public Object OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }
        [Description("PUBLICAR")]
        public Object PUBLICAR { get; set; }

        [Description("MODALIDAD_TIPO")]
        public String MODALIDAD_TIPO { get; set; }
        [Description("COD_MTIPO")]
        public String COD_MTIPO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("COD_CNOTIFICACION")]
        public String COD_CNOTIFICACION { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Description("COD_OD_REGISTRO")]
        public String COD_OD_REGISTRO { get; set; }


        [Description("COD_REQUE")]
        public Int32 COD_REQUE { get; set; }
        //
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        //07/12/2017
        [Category("FECHA"), Description("FECHA_ACTA")]
        public Object FECHA_ACTA { get; set; }

        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_ISUSPENSION> ListEliTABLA { get; set; }

        [Category("LIST"), Description("ListInformeDetSupervisor")]
        public List<Ent_GENEPERSONA> ListInformeDetSupervisor { get; set; }

        [Category("LIST"), Description("ListMComboDIdentidad")]
        public List<Ent_ISUSPENSION> ListMComboDIdentidad { get; set; }
        [Category("LIST"), Description("ListISupervision_Motivo")]
        public List<Ent_ISUSPENSION> ListISupervision_Motivo { get; set; }
        [Category("LIST"), Description("ListNivelAcademico")]
        public List<Ent_ISUSPENSION> ListNivelAcademico { get; set; }
        [Category("LIST"), Description("ListPersEspecialidad")]
        public List<Ent_ISUSPENSION> ListPersEspecialidad { get; set; }
        [Category("LIST"), Description("ListODs")]
        public List<Ent_ISUSPENSION> ListODs { get; set; }
        [Category("LIST"), Description("ListIndicador")]
        public List<Ent_ISUSPENSION> ListIndicador { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }
        #endregion
        #region "Constructor"
        public Ent_ISUSPENSION()
        {
            COD_SECUENCIAL = -1;
            RegEstado = -1;
            NUM_POA = -1;
            COD_REQUE = -1;
        }
        #endregion
    }
}
