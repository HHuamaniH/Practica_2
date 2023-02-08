using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_MiBosque_Obligacion_Observacion
    {
		#region "Entidades y Propiedades"
		[Description("COD_MIBOSQUE_OBLIGACION_OBSERVACION")]
		public Int64 COD_MIBOSQUE_OBLIGACION_OBSERVACION { get; set; }

		[Description("COD_MIBOSQUE_OBLIGACION")]
		public Int64 COD_MIBOSQUE_OBLIGACION { get; set; }

		[Description("ESTADO")]
		public String ESTADO { get; set; }

		[Description("OBSERVACION")]
		public String OBSERVACION { get; set; }

		[Category("FECHA"), Description("FECHA_CREACION")]
		public DateTime FECHA_CREACION { get; set; }

		[Category("FECHA"), Description("FECHA_MODIFICACION")]
		public DateTime FECHA_MODIFICACION { get; set; }

		[Description("ACTIVO")]
		public String ACTIVO { get; set; }

		#endregion
	}
}
