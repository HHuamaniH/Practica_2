using System;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_MiBosque_Obligacion
    {
        #region "Entidades y Propiedades"
        [Description("COD_MIBOSQUE_OBLIGACION")]
		public Int64 COD_MIBOSQUE_OBLIGACION { get; set; }

		[Description("COD_OBLIGACION")]
		public Int64 COD_OBLIGACION { get; set; }

		[Description("COD_THABILITANTE")]
		public String COD_THABILITANTE { get; set; }

		[Description("COD_PMANEJO")]
		public String COD_PMANEJO { get; set; }

		[Description("DESC_TIPO")]
		public String DESC_TIPO { get; set; }

		[Category("FECHA"), Description("FECHA_PRESENTACION")]
		public Object FECHA_PRESENTACION { get; set; }

		[Description("ESTADO")]
		public String ESTADO { get; set; }

		[Description("DESC_DETALLE")]
		public String DESC_DETALLE { get; set; }

		[Category("FECHA"), Description("FECHA_CREACION")]
		public Object FECHA_CREACION { get; set; }

		[Category("FECHA"), Description("FECHA_MODIFICACION")]
		public Object FECHA_MODIFICACION { get; set; }

		[Description("ACTIVO")]
		public String ACTIVO { get; set; }

		#endregion
		public Ent_MiBosque_Obligacion()
		{
			COD_MIBOSQUE_OBLIGACION = -1;
			COD_OBLIGACION = -1;
		}
	}
}
