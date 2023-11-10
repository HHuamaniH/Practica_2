using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_BUSQUEDA
    {
        #region "Entidades y Propiedades"
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusCriterio1")]
        public String BusCriterio1 { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        /*24/04/2018: Nuevos parámetros para aplicar paginación a nivel de BD*/

        [Description("currentpage")]
        public Int32 currentpage { get; set; }

        [Description("v_currentpage")]
        public Int32 v_currentpage { get; set; }

        [Description("pagesize")]
        public Int32 pagesize { get; set; }
        [Description("v_pagesize")]
        public Int32 v_pagesize { get; set; }

        [Description("sort")]
        public String sort { get; set; }
        [Description("v_sort")]
        public String v_sort { get; set; }

        [Description("ROW_INDEX")]
        public Int32 ROW_INDEX { get; set; }

        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("NUMERO")]
        public String NUMERO { get; set; }
        [Description("PARAMETRO01")]
        public String PARAMETRO01 { get; set; }
        [Description("PARAMETRO02")]
        public String PARAMETRO02 { get; set; }
        [Description("PARAMETRO03")]
        public String PARAMETRO03 { get; set; }
        [Description("PARAMETRO04")]
        public String PARAMETRO04 { get; set; }
        [Description("PARAMETRO05")]
        public String PARAMETRO05 { get; set; }
        [Description("PARAMETRO06")]
        public String PARAMETRO06 { get; set; }
        [Description("PARAMETRO07")]
        public String PARAMETRO07 { get; set; }
        [Description("PARAMETRO08")]
        public String PARAMETRO08 { get; set; }
        [Description("PARAMETRO09")]
        public String PARAMETRO09 { get; set; }
        [Description("PARAMETRO10")]
        public String PARAMETRO10 { get; set; }
        [Description("PARAMETRO11")]
        public String PARAMETRO11 { get; set; }
        [Description("PARAMETRO12")]
        public String PARAMETRO12 { get; set; }
        [Description("PARAMETRO13")]
        public String PARAMETRO13 { get; set; }
        [Description("PARAMETRO14")]
        public String PARAMETRO14 { get; set; }
        [Description("PARAMETRO15")]
        public String PARAMETRO15 { get; set; }
        [Description("PARAMETRO16")]
        public String PARAMETRO16 { get; set; }
        [Description("PARAMETRO17")]
        public String PARAMETRO17 { get; set; }
        [Description("PARAMETRO18")]
        public String PARAMETRO18 { get; set; }
        [Description("PARAMETRO19")]
        public String PARAMETRO19 { get; set; }
        [Description("PARAMETRO20")]
        public String PARAMETRO20 { get; set; }
        [Description("PARAMETRO21")]
        public String PARAMETRO21 { get; set; }
        [Description("PARAMETRO22")]
        public String PARAMETRO22 { get; set; }
        [Description("PARAMETRO23")]
        public String PARAMETRO23 { get; set; }
        [Description("PARAMETRO24")]
        public String PARAMETRO24 { get; set; }
        [Description("PARAMETRO25")]
        public String PARAMETRO25 { get; set; }
        [Description("PARAMETRO26")]
        public String PARAMETRO26 { get; set; }
        [Description("PARAMETRO27")]
        public String PARAMETRO27 { get; set; }
        [Description("PARAMETRO28")]
        public String PARAMETRO28 { get; set; }
        [Description("PARAMETRO29")]
        public String PARAMETRO29 { get; set; }
        [Description("PARAMETRO22")]
        public String PARAMETRO30 { get; set; }
        [Description("PARAMETRO31")]
        public String PARAMETRO31 { get; set; }
        [Description("PARAMETRO32")]
        public String PARAMETRO32 { get; set; }
        [Description("PARAMETRO33")]
        public String PARAMETRO33 { get; set; }
        [Description("PARAMETRO34")]
        public String PARAMETRO34 { get; set; }
        [Description("PARAMETRO35")]
        public String PARAMETRO35 { get; set; }
        [Description("PARAMETRO36")]
        public String PARAMETRO36 { get; set; }
        [Description("PARAMETRO37")]
        public String PARAMETRO37 { get; set; }
        [Description("PARAMETRO38")]
        public String PARAMETRO38 { get; set; }
        [Description("PARAMETRO39")]
        public String PARAMETRO39 { get; set; }
        [Description("PARAMETRO40")]
        public String PARAMETRO40 { get; set; }
        [Description("PARAMETRO41")]
        public String PARAMETRO41 { get; set; }
        [Description("PARAMETRO42")]
        public String PARAMETRO42 { get; set; }
        [Description("PARAMETRO43")]
        public String PARAMETRO43 { get; set; }
        [Description("PARAMETRO44")]
        public String PARAMETRO44 { get; set; }
        [Description("PARAMETRO45")]
        public String PARAMETRO45 { get; set; }
        [Description("PARAMETRO46")]
        public String PARAMETRO46 { get; set; }
        [Description("PARAMETRO47")]
        public String PARAMETRO47 { get; set; }
        [Description("PARAMETRO48")]
        public String PARAMETRO48 { get; set; }
        [Description("PARAMETRO49")]
        public String PARAMETRO49 { get; set; }
        [Description("PARAMETRO50")]
        public String PARAMETRO50 { get; set; }
        [Description("PARAMETRO51")]
        public String PARAMETRO51 { get; set; }
        [Description("PARAMETRO52")]
        public String PARAMETRO52 { get; set; }
        [Description("PARAMETRO53")]
        public String PARAMETRO53 { get; set; }
        [Description("PARAMETRO54")]
        public String PARAMETRO54 { get; set; }
        [Description("PARAMETRO55")]
        public String PARAMETRO55 { get; set; }
        [Description("PARAMETRO56")]
        public String PARAMETRO56 { get; set; }
        [Description("PARAMETRO57")]
        public String PARAMETRO57 { get; set; }
        [Description("FIC_SIADO")]
        public String FIC_SIADO { get; set; }

        [Description("MANDATO")]
        public String MANDATO { get; set; }
        [Description("DESDE")]
        public String DESDE { get; set; }
        [Description("HASTA")]
        public String HASTA { get; set; }
        [Description("TIPO_DOC")]
        public String TIPO_DOC { get; set; }

        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("COD_FISCALIZACION_CATEGORIA")]
        public String COD_FISCALIZACION_CATEGORIA { get; set; }
        [Description("DESCRIPCION_CATEGORIA")]
        public String DESCRIPCION_CATEGORIA { get; set; }
        [Description("Orden_Categoria")]
        public Int32 Orden_Categoria { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }

        [Description("TIPO")]
        public String TIPO { get; set; }
        [Description("NOMBRE_CIENTIFICO")]
        public String NOMBRE_CIENTIFICO { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }

        [Description("COD_FORMULARIO")]
        public String COD_FORMULARIO { get; set; }
        [Description("DIRECCION_IP")]
        public String DIRECCION_IP { get; set; }
        [Description("ACCION")]
        public String ACCION { get; set; }
        [Description("CAMPOS_AFECTADOS")]
        public String CAMPOS_AFECTADOS { get; set; }
        [Description("COD_REFERENCIA")]
        public String COD_REFERENCIA { get; set; }
        [Description("COD_REFERENCIA_AUX")]
        public String COD_REFERENCIA_AUX { get; set; }
        [Description("EXPEDIENTE")]
        public String EXPEDIENTE { get; set; }
        [Description("ADMINISTRADO")]
        public String ADMINISTRADO { get; set; }
        [Description("THABILITANTE")]
        public String THABILITANTE { get; set; }

        [Category("LIST"), Description("ListMComboCategoria")]
        public List<Ent_BUSQUEDA> ListMComboCategoria { get; set; }
        [Category("LIST"), Description("ListMComboDIdentidad")]
        public List<Ent_BUSQUEDA> ListMComboDIdentidad { get; set; }
        [Category("LIST"), Description("ListIndicador")]
        public List<Ent_BUSQUEDA> ListIndicador { get; set; }
        [Category("LIST"), Description("ListODs")]
        public List<Ent_BUSQUEDA> ListODs { get; set; }
        [Category("LIST"), Description("ListEspecies")]
        public List<Ent_BUSQUEDA> ListEspecies { get; set; }
        [Category("LIST"), Description("ListTH")]
        public List<Ent_BUSQUEDA> ListTH { get; set; }
        [Category("LIST"), Description("ListEspNCientifico")]
        public List<Ent_BUSQUEDA> ListEspNCientifico { get; set; }

        [Category("LIST"), Description("ListCondicionMad")]
        public List<Ent_BUSQUEDA> ListCondicionMad { get; set; }
        [Category("LIST"), Description("ListCondicionNoMad")]
        public List<Ent_BUSQUEDA> ListCondicionNoMad { get; set; }
        [Category("LIST"), Description("ListEstadoMad")]
        public List<Ent_BUSQUEDA> ListEstadoMad { get; set; }
        [Category("LIST"), Description("ListEstadoNoMad")]
        public List<Ent_BUSQUEDA> ListEstadoNoMad { get; set; }
        [Category("LIST"), Description("ListInstitucionesCapac")]
        public List<Ent_BUSQUEDA> ListInstitucionesCapac { get; set; }

        [Category("LIST"), Description("ListTipoCNotificacion")]
        public List<Ent_BUSQUEDA> ListTipoCNotificacion { get; set; }
        [Category("LIST"), Description("ListEstadoNotificacion")]
        public List<Ent_BUSQUEDA> ListEstadoNotificacion { get; set; }

        #endregion

        #region "Constructor"
        public Ent_BUSQUEDA()
        {
            Orden_Categoria = -1;
            currentpage = -1;
            v_currentpage = -1;
            pagesize = -1;
            v_pagesize = -1;
            ROW_INDEX = -1;
            v_currentpage = -1;
        }
        #endregion

    }
}
