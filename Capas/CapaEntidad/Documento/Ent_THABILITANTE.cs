using System;
using System.Collections.Generic;
using System.ComponentModel;

/// <summary>
/// 2014-08-18 EPB  Se incluye las entidades y propiedades para la tabla de modificacion de areas de la adenda (tabla DOC.THABILITANTE_DGENERAL_ADENDA_AREA ).
/// 2014-08-14 EPB  Se a�ade VERT_COD_SECUENCIAL.
/// </summary>
namespace CapaEntidad.DOC
{
    public class Ent_THABILITANTE
    {
        #region "Entidades y Propiedades"
        [Description("COD_ESTADO_DOC")]
        public String COD_ESTADO_DOC { get; set; }
        [Description("OBSERVACIONES_CONTROL")]
        public Object OBSERVACIONES_CONTROL { get; set; }
        [Description("CUENTA_PLAN_MANEJO")]
        public Object CUENTA_PLAN_MANEJO { get; set; }
        [Description("OBSERV_SUBSANAR")]
        public Object OBSERV_SUBSANAR { get; set; }
        [Description("COD_MTIPO")]
        public String COD_MTIPO { get; set; }
        [Category("FK"), Description("COD_RLEGAL")]
        public String COD_RLEGAL { get; set; }

        [Description("COD_THABILITANTE")]
        public String COD_THABILITANTE { get; set; }


        [Description("COD_TITULAR")]
        public String COD_TITULAR { get; set; }
        [Description("COD_UCUENTA")]
        public String COD_UCUENTA { get; set; }
        [Description("ESTAB_COD_UBIGEO")]
        public String ESTAB_COD_UBIGEO { get; set; }
        [Description("NUMERO")]
        public String NUMERO { get; set; }
        [Description("ESTAB_SECTOR")]
        public String ESTAB_SECTOR { get; set; }
        [Description("OBSERVACION")]
        public Object OBSERVACION { get; set; }
        [Description("CARACTER_AMBIENTAL")]
        public Object CARACTER_AMBIENTAL { get; set; }
        [Description("CARACTER_SOCIAL")]
        public Object CARACTER_SOCIAL { get; set; }
        [Description("CARACTER_ERESPONSABLE")]
        public Object CARACTER_ERESPONSABLE { get; set; }
        [Description("TIPO")]
        public String TIPO { get; set; }
        [Description("MODALIDAD")]
        public String MODALIDAD { get; set; }
        [Description("PERSONA")]
        public String PERSONA { get; set; }
        [Description("UBIGEO")]
        public String UBIGEO { get; set; }
        [Description("UCUENTA")]
        public String UCUENTA { get; set; }
        [Description("PERSONA_TITULAR")]
        public String PERSONA_TITULAR { get; set; }
        [Description("PERSONA_RLEGAL")]
        public String PERSONA_RLEGAL { get; set; }
        [Category("FECHA"), Description("FECHA")]
        public Object FECHA { get; set; }
        [Description("CODIGO")]
        public String CODIGO { get; set; }
        [Description("DESCRIPCION")]
        public String DESCRIPCION { get; set; }
        [Description("ESTAB_UBIGEO")]
        public String ESTAB_UBIGEO { get; set; }
        [Description("TIPO_PERSONA")]
        public String TIPO_PERSONA { get; set; }
        [Description("MODALIDAD_EJURIDICO")]
        public String MODALIDAD_EJURIDICO { get; set; }
        //
        [Description("ADENDA_CONDICIONAL")]
        public Object ADENDA_CONDICIONAL { get; set; }
        [Category("FECHA"), Description("ADENDA_FECHA_INICIO")]
        public Object ADENDA_FECHA_INICIO { get; set; }
        [Category("FECHA"), Description("ADENDA_FECHA_TERMINO")]
        public Object ADENDA_FECHA_TERMINO { get; set; }
        [Description("COD_MADENDA")]
        public String COD_MADENDA { get; set; }
        [Description("AREA_OTORGADA")]
        public Decimal AREA_OTORGADA { get; set; }
        [Description("AREA_BOSQUE")]
        public Decimal AREA_BOSQUE { get; set; }
        [Description("CONTRADO_CONDICIONAL")]
        public Object CONTRADO_CONDICIONAL { get; set; }
        [Category("FECHA"), Description("CONTRATO_FECHA_FIN")]
        public Object CONTRATO_FECHA_FIN { get; set; }
        [Category("FECHA"), Description("CONTRATO_FECHA_INICIO")]
        public Object CONTRATO_FECHA_INICIO { get; set; }
        [Description("VERTICE")]
        public String VERTICE { get; set; }
        [Description("ZONA")]
        public String ZONA { get; set; }
        [Description("COORDENADA_ESTE")]
        public Int32 COORDENADA_ESTE { get; set; }
        [Description("COORDENADA_NORTE")]
        public Int32 COORDENADA_NORTE { get; set; }
        [Description("APROYECTO_NUM_RESOL")]
        public String APROYECTO_NUM_RESOL { get; set; }
        [Category("FECHA"), Description("APROYECTO_FECHA")]
        public Object APROYECTO_FECHA { get; set; }
        [Category("FK"), Description("APROYECTO_COD_FUNCIONARIO")]
        public String APROYECTO_COD_FUNCIONARIO { get; set; }
        [Description("AFUNCIONAMIENTO_NUM_RESOL")]
        public String AFUNCIONAMIENTO_NUM_RESOL { get; set; }
        [Category("FECHA"), Description("AFUNCIONAMIENTO_FECHA")]
        public Object AFUNCIONAMIENTO_FECHA { get; set; }
        [Category("FK"), Description("AFUNCIONAMIENTO_COD_FUNCIONARIO")]
        public String AFUNCIONAMIENTO_COD_FUNCIONARIO { get; set; }

        [Category("FK"), Description("COD_TITULAR_ADENDA")]
        public String COD_TITULAR_ADENDA { get; set; }

        [Description("PERSONA_APROYECTO")]
        public String PERSONA_APROYECTO { get; set; }
        [Description("PERSONA_AFUNCIONAMIENTO")]
        public String PERSONA_AFUNCIONAMIENTO { get; set; }

        [Description("TITULAR_ADENDA")]
        public String TITULAR_ADENDA { get; set; }

        //
        [Description("ANO")]
        public Int32 ANO { get; set; }
        [Description("COD_PERSONA")]
        public String COD_PERSONA { get; set; }
        [Description("COD_AREA_SECUENCIAL")]
        public Int32 COD_AREA_SECUENCIAL { get; set; }
        [Description("COD_SECUENCIAL")]
        public Int32 COD_SECUENCIAL { get; set; }
        [Description("APELLIDOS_NOMBRES")]
        public String APELLIDOS_NOMBRES { get; set; }
        [Description("N_DOCUMENTO")]
        public String N_DOCUMENTO { get; set; }
        [Description("N_RUC")]
        public String N_RUC { get; set; }
        [Description("COD_UBIGEO")]
        public String COD_UBIGEO { get; set; }
        [Description("MOTIVO")]
        public String MOTIVO { get; set; }
        [Description("CLASE_ZOOLOGICO")]
        public String CLASE_ZOOLOGICO { get; set; }
        [Description("CODIGO_NUMERO")]
        public String CODIGO_NUMERO { get; set; }


        //
        [Category("OUTPUT"), Description("OUTPUTPARAM01")]
        public Object OUTPUTPARAM01 { get; set; }
        [Category("OUTPUT"), Description("OUTPUTPARAM02")]
        public Object OUTPUTPARAM02 { get; set; }
        [Description("BusFormulario")]
        public String BusFormulario { get; set; }
        [Description("BusCriterio")]
        public String BusCriterio { get; set; }
        [Description("BusValor")]
        public String BusValor { get; set; }
        [Description("RegEstado")]
        public Int32 RegEstado { get; set; }
        [Description("COD_OD_REGISTRO")]
        public String COD_OD_REGISTRO { get; set; }

        [Description("RegNum_Orden")]
        public Int32 RegNum_Orden { get; set; }
        //Adendas
        [Description("NUM_THABILITANTE_ADENDA")]
        public String NUM_THABILITANTE_ADENDA { get; set; }
        [Description("NUM_RESOLUCION_ADENDA")]
        public String NUM_RESOLUCION_ADENDA { get; set; }
        [Description("COD_FUNCIONARIO_ADENDA")]
        public String COD_FUNCIONARIO_ADENDA { get; set; }
        [Description("FUNCIONARIO")]
        public String FUNCIONARIO { get; set; }
        [Description("CANT_VERTICES")]
        public Int32 CANT_VERTICES { get; set; }

        [Description("OBLIGACIONES_CONCESIONARIOS")]
        public Object OBLIGACIONES_CONCESIONARIOS { get; set; }
        // para el nivel de aprovechamiento  segun las capacitaciones realizadas
        [Description("NIVEL_APROV")]
        public String NIVEL_APROV { get; set; }
        [Description("TIPO_NM")]
        public String TIPO_NM { get; set; }

        [Description("CATEGORIA")]
        public String CATEGORIA { get; set; }

        //Lista Objetos
        [Category("LIST"), Description("ListTDTTITULARES")]
        public List<Ent_THABILITANTE> ListTDTTITULARES { get; set; }
        [Category("LIST"), Description("ListAdendas")]
        public List<Ent_THABILITANTE> ListAdendas { get; set; }
        [Category("LIST"), Description("ListTDDVVERTICE")]
        public List<Ent_THABILITANTE> ListTDDVVERTICE { get; set; }
        [Category("LIST"), Description("ListTDDVADEAREA")]
        public List<Ent_THABILITANTE> ListTDDVADEAREA { get; set; }
        [Category("LIST"), Description("ListMComboModalidad")]
        public List<Ent_THABILITANTE> ListMComboModalidad { get; set; }
        [Category("LIST"), Description("ListMComboMAdenda")]
        public List<Ent_THABILITANTE> ListMComboMAdenda { get; set; }
        [Category("LIST"), Description("ListMComboDIdentidad")]
        public List<Ent_THABILITANTE> ListMComboDIdentidad { get; set; }
        [Category("LIST"), Description("ListIndicador")]
        public List<Ent_THABILITANTE> ListIndicador { get; set; }
        [Category("LIST"), Description("ListODs")]
        public List<Ent_THABILITANTE> ListODs { get; set; }
        [Category("LIST"), Description("ListComboRecategoriza")]
        public List<Ent_THABILITANTE> ListComboRecategoriza { get; set; }
        [Category("LIST"), Description("ListModalidadesTH")]
        public List<Ent_THABILITANTE> ListModalidadesTH { get; set; }

        [Category("LIST"), Description("ListTHVertice")]
        public List<Ent_INFORME> ListTHVertice { get; set; }
        [Category("LIST"), Description("ListTHMotivoEstado")]
        public List<Ent_THABILITANTE> ListTHMotivoEstado { get; set; }
        [Category("LIST"), Description("ListDependencia")]
        public List<Ent_THABILITANTE> ListDependencia { get; set; }
        //29.04.2021 se agrega para las modalidades de forestacion y reforestacion
        [Category("LIST"), Description("ListComboRecategoriza")]
        public List<Ent_THABILITANTE> ListComboFR { get; set; }
        [Category("LIST"), Description("ListClaseZoologico")]
        public List<Ent_THABILITANTE> ListClaseZoologico { get; set; }
        /*
        //29.04.2021 se agrega para las modalidades de forestacion y reforestacion
        [Category("LIST"), Description("ListComboRecategoriza")]
        public List<Ent_THABILITANTE> ListComboFR { get; set; }
        */
        //TemEliiminar
        [Description("EliTABLA")]
        public String EliTABLA { get; set; }
        [Description("EliVALOR01")]
        public String EliVALOR01 { get; set; }
        [Description("EliVALOR02")]
        public Int32 EliVALOR02 { get; set; }
        [Description("EliVALOR03")]
        public String EliVALOR03 { get; set; }
        [Description("EliVALOR04")]
        public Int32 EliVALOR04 { get; set; }
        [Category("LIST"), Description("ListEliTABLA")]
        public List<Ent_THABILITANTE> ListEliTABLA { get; set; }

        //Datos generales T�tulo Habilitante
        [Description("COD_CNOTIFICACION")]
        public String COD_CNOTIFICACION { get; set; }
        [Description("ESTADO_DOC")]
        public String ESTADO_DOC { get; set; }
        [Description("DIRECCION")]
        public String DIRECCION { get; set; }
        [Description("TELEFONO")]
        public String TELEFONO { get; set; }
        [Description("REGENTE_PGMF")]
        public String REGENTE_PGMF { get; set; }
        [Description("NUMREG_REGENTE_PGMF")]
        public String NUMREG_REGENTE_PGMF { get; set; }
        [Description("TELEFONO_REGENTE_PGMF")]
        public String TELEFONO_REGENTE_PGMF { get; set; }
        [Description("NUMRES_APROB_PGMF")]
        public String NUMRES_APROB_PGMF { get; set; }
        [Description("POA")]
        public String POA { get; set; }
        [Description("POA_AREA")]
        public string POA_AREA { get; set; }
        [Description("POA_COMPLEMENTARIO")]
        public string POA_COMPLEMENTARIO { get; set; }
        [Description("ANIO_OPERATIVO")]
        public Int32 ANIO_OPERATIVO { get; set; }
        [Description("REGENTE_ELAB_POA")]
        public String REGENTE_ELAB_POA { get; set; }
        [Description("PROF_INSP_POA")]
        public String PROF_INSP_POA { get; set; }
        [Description("PROF_RECOM_APROB_POA")]
        public String PROF_RECOM_APROB_POA { get; set; }
        [Description("NUMRES_APROB_POA")]
        public String NUMRES_APROB_POA { get; set; }
        [Description("FUNCIONARIO_APROB_POA")]
        public String FUNCIONARIO_APROB_POA { get; set; }

        [Description("ESTADO_TH")]
        public String ESTADO_TH { get; set; }

        [Description("USUARIO_REGISTRO")]
        public String USUARIO_REGISTRO { get; set; }
        [Description("USUARIO_CONTROL")]
        public String USUARIO_CONTROL { get; set; }

        [Description("COD_AEXPEDIENTE_SITD")]
        public Int32 COD_AEXPEDIENTE_SITD { get; set; }
        [Description("COD_TRAMITE_SITD")]
        public Int32 COD_TRAMITE_SITD { get; set; }
        [Description("UBIGEO_DIRECCION")]
        public String UBIGEO_DIRECCION { get; set; }

        //20.04.2021
        [Description("RES_TITULAR")]
        public String RES_TITULAR { get; set; }

        [Description("CODMTIPO_ANTERIOR")]
        public String CODMTIPO_ANTERIOR { get; set; }

        [Description("MTIPO_ANTERIOR")]
        public String MTIPO_ANTERIOR { get; set; }

        //PARA FAUNA EVALUACION DEL ESTABLECIMIENTO
        [Description("COD_THABILITANTE_EVALUACION_FAUNA")]
        public String COD_THABILITANTE_EVALUACION_FAUNA { get; set; }
        [Description("COD_MOTIVO_EV")]
        public String COD_MOTIVO_EV { get; set; }
        [Description("FECHA_AFFS")]
        public Object FECHA_AFFS { get; set; }
        [Description("NOMBRE_FIRMA_RES")]
        public String NOMBRE_FIRMA_RES { get; set; }
        [Description("FECHA_DOC")]
        public Object FECHA_DOC { get; set; }
        [Description("NOMBRE_AFFS")]
        public String NOMBRE_AFFS { get; set; }
        [Description("COD_DEPENDENCIA")]
        public String COD_DEPENDENCIA { get; set; }
        //
        [Description("COD_SECUENCIAL_ADENDA")]
        public Int32 COD_SECUENCIAL_ADENDA { get; set; }

        [Category("LIST"), Description("ListTHEstadoEsta")]
        public List<Ent_THABILITANTE> ListTHEstadoEsta { get; set; }

        //23.06.2021
        [Description("COD_CAT")]
        public String COD_CAT { get; set; }

        //Error Material
        [Category("LIST"), Description("ListErrorMaterialGeneral")]
        public List<Ent_ERRORMATERIAL> ListErrorMaterialGeneral { get; set; }
        [Category("LIST"), Description("ListErrorMaterialAdicional")]
        public List<Ent_ERRORMATERIAL> ListErrorMaterialAdicional { get; set; }
        [Category("LIST"), Description("ListDivisionInterna")]
        public List<Ent_DIVISIONINTERNA> ListDivisionInterna { get; set; }
        [Category("LIST"), Description("ListTitularRLegal")]
        public List<Ent_TITULAR_RLEGAL> ListTitularRLegal { get; set; }

        [Category("LIST"), Description("ListTHMotivoExtincion")]
        public List<Ent_THABILITANTE> ListTHMotivoExtincion { get; set; }

        [Category("LIST"), Description("ListTHExtincion")]
        public List<Ent_THABILITANTE> ListTHExtincion { get; set; }

        [Category("LIST"), Description("ListEliTABLAExt")]
        public List<Ent_THABILITANTE> ListEliTABLAExt { get; set; }
        #endregion

        [Description("COD_MOTIVO")]
        public String COD_MOTIVO { get; set; }

        [Description("NUM_RESOLUCION")]
        public String NUM_RESOLUCION { get; set; }


        [Description("COD_EXTINCION")]
        public String COD_EXTINCION { get; set; }
        

        #region MIGRA_ORACLE
        [Description("iv_CONTRADO_CONDICIONAL")]
        public Int32 iv_CONTRADO_CONDICIONAL { get; set; }

        [Description("iv_OBSERV_SUBSANAR")]
        public Int32 iv_OBSERV_SUBSANAR { get; set; }

        [Description("iv_CUENTA_PLAN_MANEJO")]
        public Int32 iv_CUENTA_PLAN_MANEJO { get; set; }
        #endregion


        //TGS 30.09.2022: Se añade atributo de conservacion de numero anterior de TH
        [Description("NUMERO_OLD")]
        public String NUMERO_OLD { get; set; }

        #region "Constructor"
        public Ent_THABILITANTE()
        {
            AREA_OTORGADA = -1;
            AREA_BOSQUE = -1;
            COORDENADA_ESTE = -1;
            COORDENADA_NORTE = -1;
            //
            ANO = -1;
            COD_SECUENCIAL = -1;
            COD_AREA_SECUENCIAL = -1;
            EliVALOR02 = -1;
            EliVALOR04 = -1;
            //
            RegEstado = -1;
            RegNum_Orden = -1;
            CANT_VERTICES = -1;
            ANIO_OPERATIVO = -1;

            COD_AEXPEDIENTE_SITD = -1;
            COD_TRAMITE_SITD = -1;

            COD_SECUENCIAL_ADENDA = -1;

            iv_CONTRADO_CONDICIONAL = -1;
            iv_OBSERV_SUBSANAR = -1;
            iv_CUENTA_PLAN_MANEJO = -1;
            ListDivisionInterna = new List<Ent_DIVISIONINTERNA>();
            ListTitularRLegal = new List<Ent_TITULAR_RLEGAL>();
        }
        #endregion
    }
}
