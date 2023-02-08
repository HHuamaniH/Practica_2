using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_AEXPEDIENTE_INTEROP
    {
        [Description("SIS_REFERENCIA")]
        public String SIS_REFERENCIA { get; set; }
        [Description("COD_AEXPEDIENTE_INTEROP")]
        public String COD_AEXPEDIENTE_INTEROP { get; set; }
        [Description("ESTADO_AEXPEDIENTE")]
        public String ESTADO_AEXPEDIENTE { get; set; }
        [Category("FECHA"), Description("FECHA_REGISTRO")]
        public Object FECHA_REGISTRO { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("RLEGAL")]
        public String RLEGAL { get; set; }
        [Description("RUC")]
        public String RUC { get; set; }
        [Description("DNI")]
        public String DNI { get; set; }
        [Description("COD_UBIGEO")]
        public String COD_UBIGEO { get; set; }
        [Category("FECHA"), Description("FECHA_INICIO")]
        public Object FECHA_INICIO { get; set; }
        [Category("FECHA"), Description("FECHA_TERMINO")]
        public Object FECHA_TERMINO { get; set; }
        [Description("AREA")]
        public Decimal AREA { get; set; }

        //Parcela de corta
        [Description("NUM_POA")]
        public Int32 NUM_POA { get; set; }
        [Description("RESOLUCION_POA")]
        public String RESOLUCION_POA { get; set; }

        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("OBSERVACION_TRANSFERIR")]
        public String OBSERVACION_TRANSFERIR { get; set; }

        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }

        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }

        public Ent_AEXPEDIENTE_INTEROP()
        {
            NUM_POA = -1;
            AREA = -1;
        }
    }
}
