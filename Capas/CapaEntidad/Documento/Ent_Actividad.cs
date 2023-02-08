using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Actividad
    {
        #region entidades y propiedades
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }

        [Description("BusValor")]
        public String BusValor { get; set; }


        [Description("BusFormulario")]
        public String BusFormulario { get; set; }

        [Description("CODIGO")]
        public String CODIGO { get; set; }

        [Description("COD_ACTIVIDAD")]
        public String COD_ACTIVIDAD { get; set; }

        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }

        [Description("NOMBRE")]
        public String NOMBRE { get; set; }

        [Description("DescripcionAct")]
        public String DescripcionAct { get; set; }

        [Description("TIEMPO_ESTIMADO")]
        public Int32 TIEMPO_ESTIMADO { get; set; }

        [Description("FECHA_INICIO")]
        public Object FECHA_INICIO { get; set; }

        [Description("FECHA_FIN")]
        public Object FECHA_FIN { get; set; }

        [Description("FECHA_REUNION")]
        public Object FECHA_REUNION { get; set; }

        [Description("COD_PRIORIDAD")]
        public String COD_PRIORIDAD { get; set; }

        [Description("PRIORIDAD")]
        public String PRIORIDAD { get; set; }

        [Description("ESTADO")]
        public String ESTADO { get; set; }

        [Description("AVANCE")]
        public Decimal AVANCE { get; set; }

        [Description("COD_JEFE")]
        public String COD_JEFE { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }

        [Category("OUTPUT"), Description("OUTPUTPARAM02")]
        public Object OUTPUTPARAM02 { get; set; }

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


        //para responsable actividad
        [Description("COD_ACTV_RESP")]
        public String COD_ACTV_RESP { get; set; }

        [Description("COD_ACT_EST")]
        public String COD_ACT_EST { get; set; }

        [Description("COD_ESTADO")]
        public String COD_ESTADO { get; set; }

        [Description("OBSERV")]
        public String OBSERV { get; set; }

        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }

        //para los reportes

        [Description("NMes")]
        public String NMes { get; set; }

        [Description("cInicio")]
        public Int32 cInicio { get; set; }

        [Description("cProceso")]
        public Int32 cProceso { get; set; }

        [Description("cTermino")]
        public Int32 cTermino { get; set; }


        [Description("Anio")]
        public Int32 Anio { get; set; }

        [Description("Trimestre")]
        public String Trimestre { get; set; }

        [Description("COD_OFICINA")]
        public String COD_OFICINA { get; set; }

        [Description("NOMBRE_OFICINA")]
        public String NOMBRE_OFICINA { get; set; }

        [Description("ABREV_OFICINA")]
        public String ABREV_OFICINA { get; set; }

        [Description("OBSERV_ACTV")]
        public String OBSERV_ACTV { get; set; }

        [Description("ENTREGABLE")]
        public String ENTREGABLE { get; set; }

        [Description("PRIORIZACION")]
        public String PRIORIZACION { get; set; }

        [Description("COD_ACTIVIDAD_OFICINA")]
        public String COD_ACTIVIDAD_OFICINA { get; set; }

        [Description("N_OFICINA")]
        public String N_OFICINA { get; set; }
        /// <summary>
        /// variables para los reportes
        /// </summary>

        [Description("BusAnio")]
        public String BusAnio { get; set; }

        [Description("Tiempo_Restante")]
        public Int32 Tiempo_Restante { get; set; }

        [Description("Tiempo_Vencimiento")]
        public Int32 Tiempo_Vencimiento { get; set; }

        [Description("ESTADOA")]
        public object ESTADOA { get; set; }

        // MODIFICACIONES 16/05/2016
        [Description("REFERENCIA")]
        public String REFERENCIA { get; set; }

        [Description("COD_SUBACTIVIDAD")]
        public String COD_SUBACTIVIDAD { get; set; }

        [Description("COD_ACT_COLAB")]
        public String COD_ACT_COLAB { get; set; }

        [Description("AVANCE_EDIT")]
        public Object AVANCE_EDIT { get; set; }

        [Description("AVANCE_SUB")]
        public Object AVANCE_SUB { get; set; }

        [Description("TIPO")]
        public String TIPO { get; set; }
        [Description("TIPO_SUB")]
        public String TIPO_SUB { get; set; }
        [Description("FECHA_PRESENTACION")]
        public Object FECHA_PRESENTACION { get; set; }

        #endregion

        #region listas
        [Category("LIST"), Description("ListPersonas")]
        public List<Ent_Actividad> ListPersonas { get; set; }

        [Category("LIST"), Description("ListPersonas")]
        public List<Ent_Actividad> ListPersonasElim { get; set; }

        [Category("LIST"), Description("ListOficinas")]
        public List<Ent_Actividad> ListOficinas { get; set; }

        [Category("LIST"), Description("ListOficinasElim")]
        public List<Ent_Actividad> ListOficinasElim { get; set; }

        [Category("LIST"), Description("ListPersonaSA")]
        public List<Ent_Actividad> ListPersonaSA { get; set; }

        [Category("LIST"), Description("ListPersonaSAElim")]
        public List<Ent_Actividad> ListPersonaSAElim { get; set; }

        [Category("LIST"), Description("ListSubActividades")]
        public List<Ent_Actividad> ListSubActividades { get; set; }

        [Category("LIST"), Description("ListSubActividadesElim")]
        public List<Ent_Actividad> ListSubActividadesElim { get; set; }
        #endregion

        #region contructores
        public Ent_Actividad()
        {
            RegEstado = -1;
            TIEMPO_ESTIMADO = -1;
            AVANCE = -1;
            cInicio = -1;
            cProceso = -1;
            cTermino = -1;
            Anio = -1;
            Tiempo_Restante = -1;
            Tiempo_Vencimiento = -1;
        }
        #endregion
    }
}
