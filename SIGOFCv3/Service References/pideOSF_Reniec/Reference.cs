﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIGOFCv3.pideOSF_Reniec {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PersonaRequest", Namespace="http://schemas.datacontract.org/2004/07/Osinfor.Pide.Request")]
    [System.SerializableAttribute()]
    public partial class PersonaRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApeMaternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApePaternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DocumentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Nombre01Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Nombre02Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Nombre03Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RazonSocialField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RucField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private char TipoPersonaField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApeMaterno {
            get {
                return this.ApeMaternoField;
            }
            set {
                if ((object.ReferenceEquals(this.ApeMaternoField, value) != true)) {
                    this.ApeMaternoField = value;
                    this.RaisePropertyChanged("ApeMaterno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApePaterno {
            get {
                return this.ApePaternoField;
            }
            set {
                if ((object.ReferenceEquals(this.ApePaternoField, value) != true)) {
                    this.ApePaternoField = value;
                    this.RaisePropertyChanged("ApePaterno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Documento {
            get {
                return this.DocumentoField;
            }
            set {
                if ((object.ReferenceEquals(this.DocumentoField, value) != true)) {
                    this.DocumentoField = value;
                    this.RaisePropertyChanged("Documento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre01 {
            get {
                return this.Nombre01Field;
            }
            set {
                if ((object.ReferenceEquals(this.Nombre01Field, value) != true)) {
                    this.Nombre01Field = value;
                    this.RaisePropertyChanged("Nombre01");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre02 {
            get {
                return this.Nombre02Field;
            }
            set {
                if ((object.ReferenceEquals(this.Nombre02Field, value) != true)) {
                    this.Nombre02Field = value;
                    this.RaisePropertyChanged("Nombre02");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre03 {
            get {
                return this.Nombre03Field;
            }
            set {
                if ((object.ReferenceEquals(this.Nombre03Field, value) != true)) {
                    this.Nombre03Field = value;
                    this.RaisePropertyChanged("Nombre03");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RazonSocial {
            get {
                return this.RazonSocialField;
            }
            set {
                if ((object.ReferenceEquals(this.RazonSocialField, value) != true)) {
                    this.RazonSocialField = value;
                    this.RaisePropertyChanged("RazonSocial");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Ruc {
            get {
                return this.RucField;
            }
            set {
                if ((object.ReferenceEquals(this.RucField, value) != true)) {
                    this.RucField = value;
                    this.RaisePropertyChanged("Ruc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public char TipoPersona {
            get {
                return this.TipoPersonaField;
            }
            set {
                if ((this.TipoPersonaField.Equals(value) != true)) {
                    this.TipoPersonaField = value;
                    this.RaisePropertyChanged("TipoPersona");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ConsultaInfoRequest", Namespace="http://schemas.datacontract.org/2004/07/Osinfor.Pide.Request")]
    [System.SerializableAttribute()]
    public partial class ConsultaInfoRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AppField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IPTerminalField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string App {
            get {
                return this.AppField;
            }
            set {
                if ((object.ReferenceEquals(this.AppField, value) != true)) {
                    this.AppField = value;
                    this.RaisePropertyChanged("App");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IPTerminal {
            get {
                return this.IPTerminalField;
            }
            set {
                if ((object.ReferenceEquals(this.IPTerminalField, value) != true)) {
                    this.IPTerminalField = value;
                    this.RaisePropertyChanged("IPTerminal");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PersonaResponse", Namespace="http://schemas.datacontract.org/2004/07/Osinfor.Pide.Response")]
    [System.SerializableAttribute()]
    public partial class PersonaResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool AntecedenteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApeMaternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApePaternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DireccionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DocumentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EstCivilField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FecNacimientoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] FotoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SIGOFCv3.pideOSF_Reniec.GradoAcademicoResponse[] GradoAcademicoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombresField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RestriccionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private char SexoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UbigeoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Antecedente {
            get {
                return this.AntecedenteField;
            }
            set {
                if ((this.AntecedenteField.Equals(value) != true)) {
                    this.AntecedenteField = value;
                    this.RaisePropertyChanged("Antecedente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApeMaterno {
            get {
                return this.ApeMaternoField;
            }
            set {
                if ((object.ReferenceEquals(this.ApeMaternoField, value) != true)) {
                    this.ApeMaternoField = value;
                    this.RaisePropertyChanged("ApeMaterno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApePaterno {
            get {
                return this.ApePaternoField;
            }
            set {
                if ((object.ReferenceEquals(this.ApePaternoField, value) != true)) {
                    this.ApePaternoField = value;
                    this.RaisePropertyChanged("ApePaterno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Direccion {
            get {
                return this.DireccionField;
            }
            set {
                if ((object.ReferenceEquals(this.DireccionField, value) != true)) {
                    this.DireccionField = value;
                    this.RaisePropertyChanged("Direccion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Documento {
            get {
                return this.DocumentoField;
            }
            set {
                if ((object.ReferenceEquals(this.DocumentoField, value) != true)) {
                    this.DocumentoField = value;
                    this.RaisePropertyChanged("Documento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string EstCivil {
            get {
                return this.EstCivilField;
            }
            set {
                if ((object.ReferenceEquals(this.EstCivilField, value) != true)) {
                    this.EstCivilField = value;
                    this.RaisePropertyChanged("EstCivil");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FecNacimiento {
            get {
                return this.FecNacimientoField;
            }
            set {
                if ((this.FecNacimientoField.Equals(value) != true)) {
                    this.FecNacimientoField = value;
                    this.RaisePropertyChanged("FecNacimiento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Foto {
            get {
                return this.FotoField;
            }
            set {
                if ((object.ReferenceEquals(this.FotoField, value) != true)) {
                    this.FotoField = value;
                    this.RaisePropertyChanged("Foto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SIGOFCv3.pideOSF_Reniec.GradoAcademicoResponse[] GradoAcademico {
            get {
                return this.GradoAcademicoField;
            }
            set {
                if ((object.ReferenceEquals(this.GradoAcademicoField, value) != true)) {
                    this.GradoAcademicoField = value;
                    this.RaisePropertyChanged("GradoAcademico");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombres {
            get {
                return this.NombresField;
            }
            set {
                if ((object.ReferenceEquals(this.NombresField, value) != true)) {
                    this.NombresField = value;
                    this.RaisePropertyChanged("Nombres");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Restriccion {
            get {
                return this.RestriccionField;
            }
            set {
                if ((object.ReferenceEquals(this.RestriccionField, value) != true)) {
                    this.RestriccionField = value;
                    this.RaisePropertyChanged("Restriccion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public char Sexo {
            get {
                return this.SexoField;
            }
            set {
                if ((this.SexoField.Equals(value) != true)) {
                    this.SexoField = value;
                    this.RaisePropertyChanged("Sexo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Ubigeo {
            get {
                return this.UbigeoField;
            }
            set {
                if ((object.ReferenceEquals(this.UbigeoField, value) != true)) {
                    this.UbigeoField = value;
                    this.RaisePropertyChanged("Ubigeo");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GradoAcademicoResponse", Namespace="http://schemas.datacontract.org/2004/07/Osinfor.Pide.Response")]
    [System.SerializableAttribute()]
    public partial class GradoAcademicoResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private char AbreviaturaTituloField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EspecialidadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FechaEmisionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FechaResolucionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PaisField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ResolucionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private char TipoGestionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private char TipoInstitucionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TituloProfesionalField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UniversidadField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public char AbreviaturaTitulo {
            get {
                return this.AbreviaturaTituloField;
            }
            set {
                if ((this.AbreviaturaTituloField.Equals(value) != true)) {
                    this.AbreviaturaTituloField = value;
                    this.RaisePropertyChanged("AbreviaturaTitulo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Especialidad {
            get {
                return this.EspecialidadField;
            }
            set {
                if ((object.ReferenceEquals(this.EspecialidadField, value) != true)) {
                    this.EspecialidadField = value;
                    this.RaisePropertyChanged("Especialidad");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FechaEmision {
            get {
                return this.FechaEmisionField;
            }
            set {
                if ((object.ReferenceEquals(this.FechaEmisionField, value) != true)) {
                    this.FechaEmisionField = value;
                    this.RaisePropertyChanged("FechaEmision");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FechaResolucion {
            get {
                return this.FechaResolucionField;
            }
            set {
                if ((object.ReferenceEquals(this.FechaResolucionField, value) != true)) {
                    this.FechaResolucionField = value;
                    this.RaisePropertyChanged("FechaResolucion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pais {
            get {
                return this.PaisField;
            }
            set {
                if ((object.ReferenceEquals(this.PaisField, value) != true)) {
                    this.PaisField = value;
                    this.RaisePropertyChanged("Pais");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Resolucion {
            get {
                return this.ResolucionField;
            }
            set {
                if ((object.ReferenceEquals(this.ResolucionField, value) != true)) {
                    this.ResolucionField = value;
                    this.RaisePropertyChanged("Resolucion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public char TipoGestion {
            get {
                return this.TipoGestionField;
            }
            set {
                if ((this.TipoGestionField.Equals(value) != true)) {
                    this.TipoGestionField = value;
                    this.RaisePropertyChanged("TipoGestion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public char TipoInstitucion {
            get {
                return this.TipoInstitucionField;
            }
            set {
                if ((this.TipoInstitucionField.Equals(value) != true)) {
                    this.TipoInstitucionField = value;
                    this.RaisePropertyChanged("TipoInstitucion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TituloProfesional {
            get {
                return this.TituloProfesionalField;
            }
            set {
                if ((object.ReferenceEquals(this.TituloProfesionalField, value) != true)) {
                    this.TituloProfesionalField = value;
                    this.RaisePropertyChanged("TituloProfesional");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Universidad {
            get {
                return this.UniversidadField;
            }
            set {
                if ((object.ReferenceEquals(this.UniversidadField, value) != true)) {
                    this.UniversidadField = value;
                    this.RaisePropertyChanged("Universidad");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="pideOSF_Reniec.IReniecService")]
    public interface IReniecService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReniecService/ConsultaDatosPersonaPorDNI", ReplyAction="http://tempuri.org/IReniecService/ConsultaDatosPersonaPorDNIResponse")]
        SIGOFCv3.pideOSF_Reniec.PersonaResponse ConsultaDatosPersonaPorDNI(SIGOFCv3.pideOSF_Reniec.PersonaRequest personaRequest, SIGOFCv3.pideOSF_Reniec.ConsultaInfoRequest consultaRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReniecService/ConsultaDatosPersonaPorDNI", ReplyAction="http://tempuri.org/IReniecService/ConsultaDatosPersonaPorDNIResponse")]
        System.Threading.Tasks.Task<SIGOFCv3.pideOSF_Reniec.PersonaResponse> ConsultaDatosPersonaPorDNIAsync(SIGOFCv3.pideOSF_Reniec.PersonaRequest personaRequest, SIGOFCv3.pideOSF_Reniec.ConsultaInfoRequest consultaRequest);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IReniecServiceChannel : SIGOFCv3.pideOSF_Reniec.IReniecService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReniecServiceClient : System.ServiceModel.ClientBase<SIGOFCv3.pideOSF_Reniec.IReniecService>, SIGOFCv3.pideOSF_Reniec.IReniecService {
        
        public ReniecServiceClient() {
        }
        
        public ReniecServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ReniecServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReniecServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReniecServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SIGOFCv3.pideOSF_Reniec.PersonaResponse ConsultaDatosPersonaPorDNI(SIGOFCv3.pideOSF_Reniec.PersonaRequest personaRequest, SIGOFCv3.pideOSF_Reniec.ConsultaInfoRequest consultaRequest) {
            return base.Channel.ConsultaDatosPersonaPorDNI(personaRequest, consultaRequest);
        }
        
        public System.Threading.Tasks.Task<SIGOFCv3.pideOSF_Reniec.PersonaResponse> ConsultaDatosPersonaPorDNIAsync(SIGOFCv3.pideOSF_Reniec.PersonaRequest personaRequest, SIGOFCv3.pideOSF_Reniec.ConsultaInfoRequest consultaRequest) {
            return base.Channel.ConsultaDatosPersonaPorDNIAsync(personaRequest, consultaRequest);
        }
    }
}