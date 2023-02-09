using CapaEntidad.DOC;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CapaEntidad.ViewModel
{
    public class VM_Persona
    {
        public string tipo { get; set; }
        public string codigoPersona { get; set; }
        public string ddlItemPN_DITipoId { get; set; }
        public string txtItemPN_APaterno { get; set; }
        public string txtItemPN_AMaterno { get; set; }
        public string txtItemPN_Nombres { get; set; }
        public string txtItemPN_DINumero { get; set; }
        public string txtItemPN_DIRUC { get; set; }
        public string txtItemPN_NRConsultor { get; set; }
        public string txtItemPN_NRCProfesional { get; set; }
        //ejemplo: 0000001-TITULAR,0000002-REPRESENTANTE LEGAL,0000006-FUNCIONARIO TB:PERSONA_TIPO
        public string COD_PTIPO { get; set; }
        public string tVentana { get; set; }
        public string COD_UBIGEO { get; set; }
        public string hdCOD_UBIGEO { get; set; }
        public string hdfUbigeo { get; set; }
        public string txtItemPN_DLDireccion { get; set; }
        public string regEstado { get; set; }
        //para persona juridica
        public string txtItemPJ_RSocial { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        public string txtItemPJ_RUC { get; set; }
        public string txtItemPJ_FichaRegistral { get; set; }

        //
        public string formOrigen { get; set; }
        public string controlOrigen { get; set; }
        public IEnumerable<VM_Cbo> ddlItemPN_DITipo { get; set; }
        public string txtItemBNuevo_Cargo { get; set; }
        //N:Natural J:Juridica T=Todos
        public string tipoPersona { get; set; }
        public string txtItemPJ_DLDireccion { get; set; }
        public string lblItemPJ_DLUbigeo { get; set; }
        public string hdfItemPJ_DLUbigeo { get; set; }

        public string lblItemPN_DLUbigeo { get; set; }
        public string hdfItemPN_DLUbigeo { get; set; }
        public string hdlblItemPN_DLUbigeo { get; set; }
        public string hdlblItemPJ_DLUbigeo { get; set; }

        //09/11/2020 -- Atributos de Mantenimiento de Personas
        public string lblTituloCabecera { get; set; }
        public string lblTituloEstado { get; set; }
        public IEnumerable<VM_Cbo> ddlTipo { get; set; }
        public IEnumerable<VM_Cbo> ddlISexo { get; set; }
        public string ddlISexoId { get; set; }
        public IEnumerable<VM_Cbo> ddlITipoCargo { get; set; }
        public string ddlITipoCargoId { get; set; }
        public string hdfITipoCargo { get; set; }
        public IEnumerable<VM_Cbo> ddlINivelAcademico { get; set; }
        public string ddlINivelAcademicoId { get; set; }
        public IEnumerable<VM_Cbo> ddlIEspecialidad { get; set; }
        public string ddlIEspecialidadId { get; set; }
        public string codigoPersonaAlerta { get; set; }
        public string txtIRazonSocial { get; set; }
        public string txtINumRegFfs { get; set; }
        public string txtINumRegProf { get; set; }
        public string txtICargo { get; set; }
        public string txtINumColegiatura { get; set; }
        public int rb_internet { get; set; }
        public int NACTIVO { get; set; }
        public string NACTIVO_NOM { get; set; }
        public int RegEstadoPersona { get; set; }


        public List<Ent_Persona> tbTipoCargo { get; set; }
        public List<Ent_Persona> tbDomicilio { get; set; }
        public List<Ent_Persona> tbTelefono { get; set; }
        public List<Ent_Persona> tbCorreo { get; set; }
        public List<Ent_Persona> tbEliTABLA { get; set; }
        public VM_Persona()
        {

            rb_internet = -1;
            NACTIVO = -1;
        }
    }
}
