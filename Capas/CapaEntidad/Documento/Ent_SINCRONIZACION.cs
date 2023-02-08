using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_SINCRONIZACION
    {
        #region "Entidades y Propiedades"

        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("PARAMETRO")]
        public String PARAMETRO { get; set; }

        [Description("COD_SINCRONIZACION")]
        public String COD_SINCRONIZACION { get; set; }
        [Description("COD_OD_SINCRO_ORIGEN")]
        public String COD_OD_SINCRO_ORIGEN { get; set; }
        [Description("OD_ORIGEN")]
        public String OD_ORIGEN { get; set; }
        [Description("COD_OD_SINCRO_DESTINO")]
        public String COD_OD_SINCRO_DESTINO { get; set; }
        [Description("OD_DESTINO")]
        public String OD_DESTINO { get; set; }
        [Description("DESCRIPCION_SINCRO")]
        public String DESCRIPCION_SINCRO { get; set; }
        [Description("TIPO_SINCRO")]
        public String TIPO_SINCRO { get; set; }
        [Category("FECHA"), Description("FECHA_SINCRO")]
        public Object FECHA_SINCRO { get; set; }
        [Description("CAD_IMPORT_SQL")]
        public String CAD_IMPORT_SQL { get; set; }
        [Description("LINEA")]
        public String LINEA { get; set; }
        //
        [Description("NAME_CREATE")]
        public String NAME_CREATE { get; set; }
        [Category("FECHA"), Description("FECHA_CREATE")]
        public Object FECHA_CREATE { get; set; }
        [Description("NAME_ALTER")]
        public String NAME_ALTER { get; set; }
        [Category("FECHA"), Description("FECHA_ALTER")]
        public Object FECHA_ALTER { get; set; }
        //
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }

        [Category("LIST"), Description("ListSincronizaciones")]
        public List<Ent_SINCRONIZACION> ListSincronizaciones { get; set; }
        [Category("LIST"), Description("ListOD_Origen")]
        public List<Ent_SINCRONIZACION> ListOD_Origen { get; set; }
        [Category("LIST"), Description("ListOD_Destino")]
        public List<Ent_SINCRONIZACION> ListOD_Destino { get; set; }
        [Category("LIST"), Description("ListTablas")]
        public List<Ent_SINCRONIZACION> ListTablas { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_SINCRONIZACION> ListEliTABLA { get; set; }
        [Category("LIST"), Description("ListConfCreated")]
        public List<Ent_SINCRONIZACION> ListConfCreated { get; set; }
        [Category("LIST"), Description("ListConfAlter")]
        public List<Ent_SINCRONIZACION> ListConfAlter { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM02")]
        public Object OUTPUTPARAM02 { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM03")]
        public String OUTPUTPARAM03 { get; set; }
        #endregion
    }
}
