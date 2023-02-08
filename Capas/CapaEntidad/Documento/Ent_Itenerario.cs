using CapaEntidad.DOC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Documento
{
   public class Ent_Itenerario
    {
        
        [Description("COD_BITACORA")]
        public String COD_BITACORA { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("COD_OD")]
        public String COD_OD { get; set; }
        [Category("FECHA"), Description("FECHA_OPERACION")]
        public Object FECHA_OPERACION { get; set; }
        [Category("FECHA"), Description("FECHA_HORA_SALIDA")]
        public Object FECHA_HORA_SALIDA { get; set; }
        [Category("FECHA"), Description("FECHA_HORA_LLEGADA")]
        public Object FECHA_HORA_LLEGADA { get; set; }

        [Category("FECHA"), Description("FECHA_RETORNO_CAMPO")]
        public Object FECHA_RETORNO_CAMPO { get; set; }
        [Description("CAPACITACION_PAUXILIOS")]
        public Object CAPACITACION_PAUXILIOS { get; set; }
        [Description("CAPACITACION_INCIDENTES")]
        public Object CAPACITACION_INCIDENTES { get; set; }
        [Description("OBSERVACIONES")]
        public String OBSERVACIONES { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Category("FECHA"), Description("FECHA_RECEPCION_CHEQUE")]
        public Object FECHA_RECEPCION_CHEQUE { get; set; }
        [Category("FECHA"), Description("FECHA_COBRO_CHEQUE")]
        public Object FECHA_COBRO_CHEQUE { get; set; }
        [Category("LIST"), Description("ListInformeDetSupervisor")]
        public List<Ent_GENEPERSONA> ListInformeDetSupervisor { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_BITACORA_SUPER> ListEliTABLA { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }
        public Ent_Itenerario()
        {
            this.RegEstado = -1;
        }
    }
}
