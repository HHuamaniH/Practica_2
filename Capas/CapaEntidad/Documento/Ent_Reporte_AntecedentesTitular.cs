using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Reporte_AntecedentesTitular
    {
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }

        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("INFRACCION")]
        public String INFRACCION { get; set; }
        [Description("SANCION")]
        public String SANCION { get; set; }
        [Description("MULTA")]
        public Decimal MULTA { get; set; }
        [Description("RESOLUCION")]
        public String RESOLUCION { get; set; }
        [Description("ESTADO_PAU")]
        public String ESTADO_PAU { get; set; }
        [Description("NUMRESOLUCIONFORESTAL")]
        public String NUMRESOLUCIONFORESTAL { get; set; }
        [Category("FECHA"), Description("FECHA_NOTIFICACION")]
        public Object FECHA_NOTIFICACION { get; set; }
        [Category("FECHA"), Description("FECRESOLUCIONFORESTAL")]
        public Object FECRESOLUCIONFORESTAL { get; set; }

        [Category("LIST"), Description("ListAntecedentes")]
        public List<Ent_Reporte_AntecedentesTitular> ListAntecedentes { get; set; }

        [Description("v_COD_PERSONA")]
        public String v_COD_PERSONA { get; set; }

        public Ent_Reporte_AntecedentesTitular()
        {
            MULTA = -1;
        }
    }
}
