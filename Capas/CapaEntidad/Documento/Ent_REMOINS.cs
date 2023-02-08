using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_REMOINS
    {
        #region "Entidades y Propiedades"

        [Description("COD_REMOINS")]
        public String COD_REMOINS { get; set; }
        [Description("COD_FCTIPO")]
        public String COD_FCTIPO { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("NUMERO_REMOINS")]
        public String NUMERO_REMOINS { get; set; }
        [Description("COD_FREMITE")]
        public String COD_FREMITE { get; set; }
        [Description("DOCUMENTOS_ADJUNTOS")]
        public String DOCUMENTOS_ADJUNTOS { get; set; }
        [Description("RegEstado")]
        public int RegEstado { get; set; }
        [Description("COD_OD_REGISTRO")]
        public String COD_OD_REGISTRO { get; set; }
        //
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public Object OBSERVACIONES_CONTROL { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }

        [Description("D_LINEA")]
        public String D_LINEA { get; set; }
        [Description("NUM_THABILITANTE")]
        public String NUM_THABILITANTE { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        //
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("TIPO")]
        public String TIPO { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUM_POA")]
        public int NUM_POA { get; set; }
        [Description("FREMITE")]
        public String FREMITE { get; set; }

        [Description("NUMERO")]
        public String NUMERO { get; set; }
        [Description("TIPO_FISCALIZA")]
        public String TIPO_FISCALIZA { get; set; }
        [Description("COD_SECUENCIAL")]
        public int COD_SECUENCIAL { get; set; }

        [Description("COD_TIPO_DOCUMENTO")]
        public String COD_TIPO_DOCUMENTO { get; set; }
        [Description("DESCRIPCION_DOCUMENTO")]
        public String DESCRIPCION_DOCUMENTO { get; set; }
        [Description("VOLUMEN_AUTORIZADO")]
        public decimal VOLUMEN_AUTORIZADO { get; set; }
        [Description("VOLUMEN_MOVILIZADO")]
        public decimal VOLUMEN_MOVILIZADO { get; set; }
        [Description("SALDO")]
        public decimal SALDO { get; set; }

        [Category("FK"), Description("COD_FENTIDAD")]
        public String COD_FENTIDAD { get; set; }
        [Category("FK"), Description("COD_ILEGAL_ENCISOS")]
        public String COD_ILEGAL_ENCISOS { get; set; }
        [Description("INFRACCION")]
        public String INFRACCION { get; set; }
        [Category("FK"), Description("COD_SANCION")]
        public String COD_SANCION { get; set; }
        [Description("SANCION")]
        public String SANCION { get; set; }
        [Description("OBSERVACIONES_TITULAR")]
        public String OBSERVACIONES_TITULAR { get; set; }

        [Description("ENTIDAD")]
        public String ENTIDAD { get; set; }
        [Description("OBSERVACIONES_ENTIDAD")]
        public String OBSERVACIONES_ENTIDAD { get; set; }
        [Category("FK"), Description("COD_TIPO_NULIDAD")]
        public String COD_TIPO_NULIDAD { get; set; }
        [Description("NULIDAD")]
        public String NULIDAD { get; set; }
        [Description("OBSERVACIONES_RESOLUCIONES")]
        public String OBSERVACIONES_RESOLUCIONES { get; set; }

        [Category("FECHA"), Description("FECHA_EMISION")]
        public Object FECHA_EMISION { get; set; }
        [Category("FECHA"), Description("FECHA_EMIBAL")]
        public Object FECHA_EMIBAL { get; set; }

        [Description("DESCRIPCION_ENTIDAD")]
        public string DESCRIPCION_ENTIDAD { get; set; }
        [Description("DESCRIPCION")]
        public string DESCRIPCION { get; set; }
        [Description("COD_ESPECIES")]
        public string COD_ESPECIES { get; set; }
        [Description("DESCRIPCION_ESPECIES")]
        public string DESCRIPCION_ESPECIES { get; set; }
        [Description("OUTPUTPARAM01")]
        public string OUTPUTPARAM01 { get; set; }
        [Description("EliTABLA")]
        public string EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public string EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public int EliVALOR02 { get; set; }

        [Description("SIN_INFRACCION")]
        public Object SIN_INFRACCION { get; set; }

        [Description("NUM_RESOLUCION")]
        public Object NUM_RESOLUCION { get; set; }
        [Description("INSTITUCION")]
        public Object INSTITUCION { get; set; }
        [Category("FECHA"), Description("FECHA_RECEPCION")]
        public Object FECHA_RECEPCION { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        [Category("LIST"), Description("ListTipoDocumento")]
        public List<Ent_REMOINS> ListTipoDocumento { get; set; }
        [Category("LIST"), Description("ListEntidad")]
        public List<Ent_REMOINS> ListEntidad { get; set; }
        [Category("LIST"), Description("ListInformes")]
        public List<Ent_REMOINS> ListInformes { get; set; }
        [Category("LIST"), Description("ListarInfracciones")]
        public List<Ent_REMOINS> ListarInfracciones { get; set; }
        [Category("LIST"), Description("ListarNulidad")]
        public List<Ent_REMOINS> ListarNulidad { get; set; }
        [Category("LIST"), Description("ListarSancion")]
        public List<Ent_REMOINS> ListarSancion { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_REMOINS> ListEliTABLA { get; set; }

        [Category("LIST"), Description("ListEspecies")]
        public List<Ent_REMOINS> ListEspecies { get; set; }
        [Category("LIST"), Description("Listardetbalance")]
        public List<Ent_REMOINS> Listardetbalance { get; set; }
        [Category("LIST"), Description("Listardettitular")]
        public List<Ent_REMOINS> Listardettitular { get; set; }
        [Category("LIST"), Description("Listardetresoluciones")]
        public List<Ent_REMOINS> Listardetresoluciones { get; set; }

        #endregion

        #region "Constructor"
        public Ent_REMOINS()
        {
            //
            RegEstado = -1;
            VOLUMEN_AUTORIZADO = -1;
            VOLUMEN_MOVILIZADO = -1;
            SALDO = -1;
            NUM_POA = -1;
            COD_SECUENCIAL = -1;
            EliVALOR02 = -1;
        }
        #endregion

    }
}
