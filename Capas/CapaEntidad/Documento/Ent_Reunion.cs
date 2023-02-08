using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad.DOC
{
    public class Ent_Reunion
    {
        #region "Entidades y Propiedades"
        //Reunión
        [Description("COD_REUNION")]
        public string COD_REUNION { get; set; }
        [Description("REF_CONVOCATORIA")]
        public string REF_CONVOCATORIA { get; set; }
        [Category("FECHA"), Description("FECHA_INICIO")]
        public object FECHA_INICIO { get; set; }
        [Category("FECHA"), Description("FECHA_FIN")]
        public object FECHA_FIN { get; set; }
        [Category("FECHA"), Description("FECHA_REUNION")]
        public object FECHA_REUNION { get; set; }
        [Description("DURACION_MIN")]
        public int DURACION_MIN { get; set; }
        [Description("DURACION_DIA")]
        public int DURACION_DIA { get; set; }
        [Description("HORA_INICIO")]
        public string HORA_INICIO { get; set; }
        [Description("HORA_FIN")]
        public string HORA_FIN { get; set; }
        [Description("LUGAR")]
        public string LUGAR { get; set; }
        [Description("NOMBRE_ARCH_PART")]
        public string NOMBRE_ARCH_PART { get; set; }
        [Description("EXTENSION_ARCH_PART")]
        public string EXTENSION_ARCH_PART { get; set; }
        [Description("COD_UCUENTA")]
        public string COD_UCUENTA { get; set; }
        [Description("ACUERDO")]
        public string ACUERDO { get; set; }
        [Description("DESA_AGENDA")]
        public string DESA_AGENDA { get; set; }
        //Agenda
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("ORDEN_AGENDA")]
        public int ORDEN_AGENDA { get; set; }
        [Description("DESCRIP_AGENDA")]
        public string DESCRIP_AGENDA { get; set; }
        [Description("COMENTARIO")]
        public string COMENTARIO { get; set; }
        //Participantes
        [Description("COD_PERSONA")]
        public string COD_PERSONA { get; set; }
        [Description("APELLIDOS_NOMBRES")]
        public string APELLIDOS_NOMBRES { get; set; }
        [Description("N_DOCUMENTO")]
        public string N_DOCUMENTO { get; set; }
        [Description("COD_INSTITUCION")]
        public string COD_INSTITUCION { get; set; }
        [Description("NOM_INSTITUCION")]
        public string NOM_INSTITUCION { get; set; }
        [Description("CARGO")]
        public string CARGO { get; set; }
        #endregion
        #region Flags y Objetos
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        //[Description("DURACION")]
        //public Int32 DURACION { get; set; }
        [Description("OUTPUTPARAM01")]
        public string OUTPUTPARAM01 { get; set; }
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        //Variables para eliminar registros
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public Int32 EliVALOR02 { get; set; }
        #endregion
        #region Listas
        [Category("LIST"), Description("ListAgendaReunion")]
        public List<Ent_Reunion> ListAgendaReunion { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_Reunion> ListEliTABLA { get; set; }
        [Category("LIST"), Description("ListInstituciones")]
        public List<Ent_Reunion> ListInstituciones { get; set; }
        [Category("LIST"), Description("ListFiltroBusqueda")]
        public List<Ent_Reunion> ListFiltroBusqueda { get; set; }
        [Category("LIST"), Description("ListParticipantes")]
        public List<Ent_Reunion> ListParticipantes { get; set; }
        [Category("LIST"), Description("ListParticipantesOtros")]
        public List<Ent_Reunion> ListParticipantesOtros { get; set; }
        #endregion
        #region "Constructor"
        public Ent_Reunion()
        {
            RegEstado = -1;
            ORDEN_AGENDA = -1;
            DURACION_MIN = -1;
            DURACION_DIA = -1;
            EliVALOR02 = -1;
            COD_SECUENCIAL = -1;
            //DURACION = -1;
        }
        #endregion
    }
}
