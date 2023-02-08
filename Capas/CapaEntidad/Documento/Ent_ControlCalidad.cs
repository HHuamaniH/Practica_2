using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_ControlCalidad
    {
        [Description("COD_OD")]
        public String COD_OD { get; set; }
        [Description("OD")]
        public String OD { get; set; }
        [Description("TD")]
        public Int32 TD { get; set; }
        [Description("PR")]
        public Int32 PR { get; set; }
        [Description("RC")]
        public Int32 RC { get; set; }
        [Description("PCC")]
        public Int32 PCC { get; set; }
        [Description("CCO")]
        public Int32 CCO { get; set; }
        [Description("CCO_SUBSANADO")]
        public Int32 CCO_SUBSANADO { get; set; }
        [Description("CCO_PENDIENTE")]
        public Int32 CCO_PENDIENTE { get; set; }
        [Description("CCC")]
        public Int32 CCC { get; set; }

        [Description("DOCUMENTO")]
        public String DOCUMENTO { get; set; }
        [Description("FECHA_REGISTRO")]
        public object FECHA_REGISTRO { get; set; }
        [Description("RESPONSABLE_REGISTRO")]
        public String RESPONSABLE_REGISTRO { get; set; }
        [Description("FECHA_CONTROL")]
        public object FECHA_CONTROL { get; set; }
        [Description("RESPONSABLE_CONTROL")]
        public String RESPONSABLE_CONTROL { get; set; }
        [Description("ESTADO_DOCUMENTO")]
        public String ESTADO_DOCUMENTO { get; set; }
        [Description("ESTADO_OBSERVACION")]
        public String ESTADO_OBSERVACION { get; set; }
        [Description("TIPO_DOCUMENTO")]
        public String TIPO_DOCUMENTO { get; set; }

        [Category("LIST"), Description("ListCCResumenGeneral")]
        public List<Ent_ControlCalidad> ListCCResumenGeneral { get; set; }
        [Category("LIST"), Description("ListCCResumenOD")]
        public List<Ent_ControlCalidad> ListCCResumenOD { get; set; }

        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Category("LIST"), Description("ListMComboTipoDocumento")]
        public List<Ent_ControlCalidad> ListMComboTipoDocumento { get; set; }
        public List<Ent_ControlCalidad> ListDireccionLinea { get; set; }
        public List<Ent_ControlCalidad> ListDepartamento { get; set; }
        [Description("ANIO")]
        public Int32 ANIO { get; set; }
        [Description("TIPO_REPORTE")]
        public String TIPO_REPORTE { get; set; }
        [Description("NOM_FORMULARIO")]
        public String NOM_FORMULARIO { get; set; }
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }

        public Ent_ControlCalidad()
        {
            ANIO = -1;
            TD = -1;
            PR = -1;
            RC = -1;
            PCC = -1;
            CCO = -1;
            CCO_PENDIENTE = -1;
            CCO_SUBSANADO = -1;
            CCC = -1;
        }
    }
}