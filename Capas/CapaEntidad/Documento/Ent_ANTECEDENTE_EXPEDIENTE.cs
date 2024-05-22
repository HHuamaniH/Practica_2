using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_ANTECEDENTE_EXPEDIENTE
    {
        [Description("COD_AEXPEDIENTE_SITD")]
        public Int32 COD_AEXPEDIENTE_SITD { get; set; }
        [Description("COD_TRAMITE_SITD")]
        public Int32 COD_TRAMITE_SITD { get; set; }
        [Description("COD_DREFERENCIA")]
        public String COD_DREFERENCIA { get; set; }
        [Description("DOC_REFERENCIA")]
        public String DOC_REFERENCIA { get; set; }
        [Category("FECHA"), Description("FECHA_SITD")]
        public Object FECHA_SITD { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("RESOLUCION_POA")]
        public String RESOLUCION_POA { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("OBSERVACION_TRANSFERENCIA")]
        public String OBSERVACION_TRANSFERENCIA { get; set; }
        [Description("ESTADO_AEXPEDIENTE")]
        public String ESTADO_AEXPEDIENTE { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("COD_MTIPO")]
        public String COD_MTIPO { get; set; }
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("NOMBRE_POA")]
        public String NOMBRE_POA { get; set; }
        [Description("COD_PGMF")]
        public String COD_PGMF { get; set; }
        [Description("COD_PMANEJO")]
        public String COD_PMANEJO { get; set; }
        [Description("NUM_ACTO")]
        public Int32 NUM_ACTO { get; set; }
        [Description("NOMBRE_ACTO")]
        public String NOMBRE_ACTO { get; set; }
        [Category("FECHA"), Description("FECHA")]
        public Object FECHA { get; set; }
        [Description("ADICIONAL")]
        public string ADICIONAL { get; set; }
        [Description("FUENTE")]
        public String FUENTE { get; set; }
        [Description("ESTADO_SIGO")]
        public String ESTADO_SIGO { get; set; }
        [Description("CENSO")]
        public Int32 CENSO { get; set; }
        [Description("SUPERVISADO")]
        public String SUPERVISADO { get; set; }
        [Description("PDF_TRAMITE_SITD")]
        public String PDF_TRAMITE_SITD { get; set; }
        [Description("NUM_DOCUMENTO")]
        public String NUM_DOCUMENTO { get; set; }
        [Description("NUM_TRAMITE")]
        public String NUM_TRAMITE { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusEstado")]
        public String BusEstado { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("TIPO")]
        public String TIPO { get; set; }
        [Description("SUBTIPO")]
        public String SUBTIPO { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Description("SINCRO_PGMF")]
        public Boolean? SINCRO_PGMF { get; set; }
        [Description("SINCRO_PM")]
        public Boolean? SINCRO_PM { get; set; }
        [Description("SINCRO_POA")]
        public Boolean? SINCRO_POA { get; set; }
        [Description("SINCRO_TH")]
        public Boolean? SINCRO_TH { get; set; }
        [Description("ORIGEN_REGISTRO")]
        public int? ORIGEN_REGISTRO { get; set; }
        [Category("LIST"), Description("ListMComboModalidad")]
        public List<Ent_ANTECEDENTE_EXPEDIENTE> ListMComboModalidad { get; set; }
        [Category("LIST"), Description("ListMComboPOA")]
        public List<Ent_ANTECEDENTE_EXPEDIENTE> ListMComboPOA { get; set; }
        [Category("LIST"), Description("ListMComboDocReferencia")]
        public List<Ent_ANTECEDENTE_EXPEDIENTE> ListMComboDocReferencia { get; set; }

        [Description("OD")]
        public String OD { get; set; }
        [Description("ESTADO_ORIGEN_PADRE")]
        public String ESTADO_ORIGEN_PADRE { get; set; }

        [Description("COD_SIADO")]
        public String COD_SIADO { get; set; }

        [Description("COD_GORE")]
        public String COD_GORE { get; set; }

        [Description("FECHA_SIADO")]
        public Object FECHA_SIADO { get; set; }
        [Description("TIPO_SIADO")]
        public String TIPO_SIADO { get; set; }
        [Description("SUB_TIPO_SIADO")]
        public String SUB_TIPO_SIADO { get; set; }


        [Description("DIAS_DD")]
        public String DIAS_DD { get; set; }
        [Description("SUBTIPODETALLE")]
        public String SUBTIPODETALLE { get; set; }
        [Description("PARAMETRO01")]
        public String PARAMETRO01 { get; set; }

        public Ent_ANTECEDENTE_EXPEDIENTE()
        {
            COD_AEXPEDIENTE_SITD = -1;
            COD_TRAMITE_SITD = -1;
            NUM_POA = -1;
            NUM_ACTO = -1;
            RegEstado = -1;
            CENSO = -1;
        }
    }
}
