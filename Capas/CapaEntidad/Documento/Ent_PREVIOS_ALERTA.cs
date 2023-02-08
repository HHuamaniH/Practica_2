using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_PREVIOS_ALERTA
    {
        //Destinatario
        [Description("COD_DESTINATARIO")]
        public Int32? COD_DESTINATARIO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("USUARIO")]
        public String USUARIO { get; set; }        
        [Description("CORREO")]
        public String CORREO { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("CARGO")]
        public String CARGO { get; set; }
        [Description("DOCUMENTO")]
        public String DOCUMENTO { get; set; }
        [Description("TIPO_CC")]
        public Int32? TIPO_CC { get; set; }


        [Category("FECHA"), Description("FECHA_DOCUMENTO")]
        public Object FECHA_DOCUMENTO { get; set; }
        [Category("FECHA"), Description("FECHA_REGISTRO")]
        public Object FECHA_REGISTRO { get; set; }


        [Description("OFICINA")]
        public String OFICINA { get; set; }
        [Description("SUPUESTOS_DESTINATARIO")]
        public String SUPUESTOS_DESTINATARIO { get; set; }
        [Description("DESTINATAIOCC")]
        public String DESTINATAIOCC { get; set; }
        [Description("TIPO_FUNCIONARIO")]
        public Int32? TIPO_FUNCIONARIO { get; set; }

        [Description("ACTIVO")]
        public Int32? ACTIVO { get; set; }
        [Description("ACTIVO_DESC")]
        public string ACTIVO_DESC { get; set; }
        [Description("BusFormulario")]
        public string BusFormulario { get; set; }
        [Description("BusCriterio")]
        public string BusCriterio { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("OBSERVACION")]
        public String OBSERVACION { get; set; }




        [Description("COD_RUTA")]
        public Int32? COD_RUTA { get; set; }

        [Description("COD_UBIDEPARTAMENTO")]
        public String COD_UBIDEPARTAMENTO { get; set; }
        [Description("DEPARTAMENTO")]
        public String DEPARTAMENTO { get; set; }
        [Description("DEPARTAMENTO")]
        public List<Ent_PREVIOS_ALERTA> ListDEPARTAMENTO { get; set; }

        [Description("TRAMO")]
        public String TRAMO { get; set; }

        [Description("ORIGEN_DESTINO")]
        public String ORIGEN_DESTINO { get; set; }

        [Description("RegEstado")]
        public String RegEstado { get; set; }

        [Description("COD_DESTINATARIO_RUTA")]
        public Int32? COD_DESTINATARIO_RUTA { get; set; }



        [Description("COD_SUPUESTO")]
        public Int32? COD_SUPUESTO { get; set; }
        [Description("ABREV_SUPUESTO")]
        public String ABREV_SUPUESTO { get; set; }
        [Description("DES_SUPUESTO")]
        public String DES_SUPUESTO { get; set; }      

        [Description("NOMBRE_ARCHIVO")]
        public String NOMBRE_ARCHIVO { get; set; }

        [Description("NOMBRE_ARCHIVO_REAL")]
        public String NOMBRE_ARCHIVO_REAL { get; set; }


        [Description("SUPUESTO")]
        public String SUPUESTO { get; set; }
        [Description("COD_UCUENTA_CREACION")]
        public String COD_UCUENTA_CREACION { get; set; }
        [Description("USUARIO_LOGIN")]
        public String USUARIO_LOGIN { get; set; }
        [Description("ESTADO_ACTIVO")]
        public Int32? ESTADO_ACTIVO { get; set; }
        [Description("NOTIFICADO")]
        public Int32? NOTIFICADO { get; set; }
        [Description("esPublico")]
        public Int32? esPublico { get; set; }
        [Description("modPassword")]
        public Int32? modPassword { get; set; }
        [Description("password")]
        public String password { get; set; }
        [Description("passwordR")]
        public String passwordR { get; set; }
        [Description("USUARIO_CONTRASENA")]
        public String USUARIO_CONTRASENA { get; set; }
        [Description("COADMIN")]
        public Int32? COADMIN { get; set; }
        [Description("COD_ENTIDAD")]
        public String COD_ENTIDAD { get; set; }
        



        //archivos

        [Description("EXTENSION_ARCHIVO")]
        public String EXTENSION_ARCHIVO { get; set; }
        [Description("NOMBRE_TEMPORAL_ARCHIVO")]
        public String NOMBRE_TEMPORAL_ARCHIVO { get; set; }
        [Description("ESTADO_ARCHIVO")]
        public String ESTADO_ARCHIVO { get; set; }
        [Description("cCodificacion_SiTD")]
        public String cCodificacion_SiTD { get; set; }


        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM02")]
        public Object OUTPUTPARAM02 { get; set; }

        //Lista Objetos
        [Category("LIST"), Description("ListDESTINATARIO")]
        public List<Ent_PREVIOS_ALERTA> ListDESTINATARIO { get; set; }
        //[Category("LIST"), Description("ListDESTINATARIOSELECT")]
        //public List<Ent_PREVIOS_ALERTA> ListDESTINATARIOSELECT { get; set; }

        [Category("LIST"), Description("ListRUTA")]
        public List<Ent_PREVIOS_ALERTA> ListRUTA { get; set; }

        [Category("LIST"), Description("ListDESTINATARIO_RUTA")]
        public List<Ent_PREVIOS_ALERTA> ListDESTINATARIO_RUTA { get; set; }

        [Category("LIST"), Description("ListSUPUESTO")]
        public List<Ent_PREVIOS_ALERTA> ListSUPUESTO { get; set; }

        [Category("LIST"), Description("ListDESTINATARIOCC")]
        public List<Ent_PREVIOS_ALERTA> ListDESTINATARIOCC { get; set; }
        [Category("LIST"), Description("ListCOADMINISTRADOR")]
        public List<Ent_PREVIOS_ALERTA> ListCOADMINISTRADOR { get; set; }
        [Category("LIST"), Description("ListPERFILCOADMINISTRADOR")]
        public List<Ent_PREVIOS_ALERTA> ListPERFILCOADMINISTRADOR { get; set; }
        [Category("LIST"), Description("ListENTIDAD")]
        public List<Ent_PREVIOS_ALERTA> ListENTIDAD { get; set; }
        

        //TemEliiminar
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public String EliVALOR02 { get; set; }
        [Description("EliVALOR03")]
        public String EliVALOR03 { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_PREVIOS_ALERTA> ListEliTABLA { get; set; }


        #region "Constructor"
        public Ent_PREVIOS_ALERTA()
        {



        }
        #endregion
    }
}
