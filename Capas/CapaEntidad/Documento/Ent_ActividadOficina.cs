using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.Documento
{
    class Ent_ActividadOficina
    {
        #region Entidades
        #region variables para busque
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }

        [Description("BusValor")]
        public String BusValor { get; set; }

        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        #endregion
        #region variables
        [Description("COD_ACTIVIDAD_OF")]
        public String COD_ACTIVIDAD_OF { get; set; }

        [Description("NOMBRE")]
        public String NOMBRE { get; set; }

        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }

        [Description("FECHA_INICIO")]
        public Object FECHA_INICIO { get; set; }

        [Description("FECHA_FIN")]
        public Object FECHA_FIN { get; set; }

        [Description("PRIORIDAD")]
        public String PRIORIDAD { get; set; }

        [Description("COD_OFICINA")]
        public String COD_OFICINA { get; set; }

        [Description("ESTADO")]
        public Object ESTADO { get; set; }

        [Description("DOCUMENTO")]
        public String DOCUMENTO { get; set; }

        [Description("COD_ACTIVIDAD_REF")]
        public String COD_ACTIVIDAD_REF { get; set; }

        [Description("TPendientes")]
        public Int32 TPendientes { get; set; }

        [Description("TProceso")]
        public Int32 TProceso { get; set; }

        [Description("TTerminado")]
        public Int32 TTerminado { get; set; }

        [Description("TAtraso")]
        public Int32 TAtraso { get; set; }

        [Description("Avance")]
        public Decimal Avance { get; set; }

        //Personas
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }

        [Description("APELLIDOS_NOMBRES")]
        public String APELLIDOS_NOMBRES { get; set; }

        [Description("DNI")]
        public String DNI { get; set; }

        [Description("DIRECCION")]
        public String DIRECCION { get; set; }

        [Description("TELEFONO")]
        public String TELEFONO { get; set; }
        #endregion
        #region listas
        [Category("LIST"), Description("ListPersonas")]
        public List<Ent_ActividadOficina> ListPersonas { get; set; }

        [Category("LIST"), Description("ListPersonas")]
        public List<Ent_ActividadOficina> ListPersonasElim { get; set; }


        [Category("LIST"), Description("ListOficinasElim")]
        public List<Ent_ActividadOficina> ListOficinasElim { get; set; }
        #endregion
        #endregion
        #region constructores
        public Ent_ActividadOficina()
        {
            TPendientes = 0;
            TProceso = 0;
            TTerminado = 0;
            TAtraso = 0;
        }
        #endregion
    }
}
