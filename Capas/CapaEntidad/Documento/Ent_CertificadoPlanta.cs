using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_CertificadoPlanta
    {
        #region "Entidades y Propiedades"
        [Description("COD_CERTIFPLANTA")]
        public String COD_CERTIFPLANTA { get; set; }
        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }
        [Description("NUMERO_INSCRIPCION")]
        public String NUMERO_INSCRIPCION { get; set; }
        [Category("FECHA"), Description("FECHA_INSCRIPCION")]
        public Object FECHA_INSCRIPCION { get; set; }
        [Description("AREATOTAL")]
        public Decimal AREATOTAL { get; set; }
        [Category("FECHA"), Description("FECHA_ESTABLECIMIENTO")]       
        public Object FECHA_ESTABLECIMIENTO { get; set; }
        [Description("ZONA_UTM")]
        public String ZONA_UTM { get; set; }
        [Description("COORD_ESTE")]
        public Int32 COORD_ESTE { get; set; }
        [Description("COORD_NORTE")]
        public Int32 COORD_NORTE { get; set; }
        [Description("OBSERVACIONES")]
        public String OBSERVACIONES { get; set; }  
        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }        
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Category("FECHA"), Description("FECHA_CREACION")]
        public Object FECHA_CREACION { get; set; }
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("OUTPUTPARAM01")]
        public String OUTPUTPARAM01 { get; set; }
        [Description("OUTPUTPARAM02")]
        public String OUTPUTPARAM02 { get; set; }
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Description("NUMERO")]
        public String NUMERO { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("TITULAR")]
        public String TITULAR { get; set; }
        [Description("UBIGEO")]
        public String UBIGEO { get; set; }
        public List<Ent_EspeciesEstablecidas> ListEspeciesEstablecidas { get; set; }
        public List<Ent_EliTabla> ListEliTABLA { get; set; }
        #endregion
        #region "Constructor"
        public Ent_CertificadoPlanta()
        {
            AREATOTAL = -1;
            RegEstado = -1;
            COORD_ESTE = -1;
            COORD_NORTE = -1;
            ListEspeciesEstablecidas = new List<Ent_EspeciesEstablecidas>();
        }
        #endregion
    }

    public class Ent_EspeciesEstablecidas
    {
        #region "Entidades y Propiedades"
        [Description("COD_CERTIFPLANTA")]
        public String COD_CERTIFPLANTA { get; set; }
        [Description("COD_ESPECIES")]
        public String COD_ESPECIES { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("DESC_ESPECIES")]
        public String DESC_ESPECIES { get; set; }
        [Description("SIS_PLANTA")]
        public String SIS_PLANTA { get; set; }
        [Description("UNI_MEDIDA")]
        public String UNI_MEDIDA { get; set; }
        [Description("CANTIDAD")]
        public Decimal CANTIDAD { get; set; }      
        [Description("FINES")]
        public String FINES { get; set; }       
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; } 
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }  
        [Description("RegEstado")]
        public Int16 RegEstado { get; set; }    
        #endregion
        #region "Constructor"
        public Ent_EspeciesEstablecidas()
        {
            CANTIDAD = -1;
            COD_SECUENCIAL = -1;
            RegEstado = -1;
        }
        #endregion
    }

    public class Ent_EliTabla
    {
        #region "Entidades y Propiedades"        
        [Description("COD_CERTIFPLANTA")]
        public String COD_CERTIFPLANTA { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }        
        #endregion
        #region "Constructor"
        public Ent_EliTabla()
        {
            COD_SECUENCIAL = -1;
            RegEstado = -1;
        }
        #endregion
    }
}
