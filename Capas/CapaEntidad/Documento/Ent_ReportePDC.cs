using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.DOC
{
    public class Ent_ReportePDC
    {
        [Description("ID_REGISTRO")]
        public String ID_REGISTRO { get; set; }

        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("OFICINA_DESCONCENTRADA")]
        public String OFICINA_DESCONCENTRADA { get; set; }
        [Description("TITULO")]
        public String TITULO { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("REP_LEGAL")]
        public String REP_LEGAL { get; set; }
        [Description("DEPARTAMENTO")]
        public String DEPARTAMENTO { get; set; }
        [Description("PROVINCIA")]
        public String PROVINCIA { get; set; }
        [Description("DISTRITO")]
        public String DISTRITO { get; set; }
        [Description("FECHA_VIGENCIA")]
        public String FECHA_VIGENCIA { get; set; }
        [Description("FECHA_CORTE")]
        public String FECHA_CORTE { get; set; }
        [Description("AREA")]
        public Decimal AREA { get; set; }
        [Description("ULTIMO_PLAN")]
        public String ULTIMO_PLAN { get; set; }

        [Description("ROJO")]
        public String ROJO { get; set; }
        [Description("VERDE")]
        public String VERDE { get; set; }
        [Description("ALERTA")]
        public String ALERTA { get; set; }
        [Description("PASPEQ")]
        public String PASPEQ { get; set; }
        [Description("PASPEQ_ENFOQUE")]
        public String PASPEQ_ENFOQUE { get; set; }
        [Description("FECHA_SUPERVISION")]
        public String FECHA_SUPERVISION { get; set; }
        [Description("S_VOL_APROB")]
        public Decimal S_VOL_APROB { get; set; }
        [Description("S_VOL_MOV")]
        public Decimal S_VOL_MOV { get; set; }
        [Description("S_VOL_INJUST")]
        public Decimal S_VOL_INJUST { get; set; }
        [Description("INFRACCIONES")]
        public String INFRACCIONES { get; set; }
        [Description("MULTAS")]
        public String MULTAS { get; set; }
        [Description("ESTADO_PAU")]
        public String ESTADO_PAU { get; set; }
        [Description("ESTADO_PAGO")]
        public String ESTADO_PAGO { get; set; }

        [Description("MODALIDAD_PAGO")]
        public String MODALIDAD_PAGO { get; set; }
        [Description("MEC_COMP")]
        public String MEC_COMP { get; set; }
        [Description("N_CAPACITACION")]
        public Decimal N_CAPACITACION { get; set; }
        [Description("FECHA_ULT_CAP")]
        public String FECHA_ULT_CAP { get; set; }
        [Description("TEMA_ULT_CAP")]
        public String TEMA_ULT_CAP { get; set; }

        [Description("TEMA_MOCHILA_CAP")]
        public String TEMA_MOCHILA_CAP { get; set; }
        [Description("TEMA_MOCHILA_ENT")]
        public String TEMA_MOCHILA_ENT { get; set; }
        [Description("PRIORIDAD")]
        public Decimal PRIORIDAD { get; set; }

        [Description("CAPACITABLE")]
        public String CAPACITABLE { get; set; }
        [Description("TALLER")]
        public Decimal TALLER { get; set; }

        [Description("IDREGISTRO")]
        public Decimal IDREGISTRO { get; set; }

        [Description("COD_MODALIDAD")]
        public String COD_MODALIDAD { get; set; }

        [Description("SUM_AREA")]
        public Decimal SUM_AREA { get; set; }

        public Ent_ReportePDC()
        {
            AREA = -1;
            S_VOL_APROB = -1;
            S_VOL_MOV = -1;
            S_VOL_INJUST = -1;
            N_CAPACITACION = -1;
            PRIORIDAD = -1;
            IDREGISTRO = -1;
            TALLER = -1;
            SUM_AREA = -1;
        }


    }
}
