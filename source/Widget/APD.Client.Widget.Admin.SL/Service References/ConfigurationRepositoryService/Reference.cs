﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 3.0.40818.0
// 
namespace APD.Client.Widget.Admin.SL.ConfigurationRepositoryService {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SpecificationOfConfigurationsNSnGPiV", Namespace="http://schemas.datacontract.org/2004/07/APD.DomainModel.Framework")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.AllSpecificationOfConfigurationsNSnGPiV))]
    public partial class SpecificationOfConfigurationsNSnGPiV : object, System.ComponentModel.INotifyPropertyChanged {
        
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
    [System.Runtime.Serialization.DataContractAttribute(Name="AllSpecificationOfConfigurationsNSnGPiV", Namespace="http://schemas.datacontract.org/2004/07/APD.DomainModel.Framework")]
    public partial class AllSpecificationOfConfigurationsNSnGPiV : APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.SpecificationOfConfigurationsNSnGPiV {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Configuration", Namespace="http://schemas.datacontract.org/2004/07/APD.DomainModel.Config", IsReference=true)]
    public partial class Configuration : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string NameField;
        
        private System.Collections.Generic.List<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.SettingsEntry> SettingsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.SettingsEntry> Settings {
            get {
                return this.SettingsField;
            }
            set {
                if ((object.ReferenceEquals(this.SettingsField, value) != true)) {
                    this.SettingsField = value;
                    this.RaisePropertyChanged("Settings");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="SettingsEntry", Namespace="http://schemas.datacontract.org/2004/07/APD.DomainModel.Config")]
    public partial class SettingsEntry : object, System.ComponentModel.INotifyPropertyChanged {
        
        private APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.Configuration ConfigurationField;
        
        private string NameField;
        
        private System.Collections.Generic.List<string> ValsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.Configuration Configuration {
            get {
                return this.ConfigurationField;
            }
            set {
                if ((object.ReferenceEquals(this.ConfigurationField, value) != true)) {
                    this.ConfigurationField = value;
                    this.RaisePropertyChanged("Configuration");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<string> Vals {
            get {
                return this.ValsField;
            }
            set {
                if ((object.ReferenceEquals(this.ValsField, value) != true)) {
                    this.ValsField = value;
                    this.RaisePropertyChanged("Vals");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="ConfigurationRepositoryService.ConfigurationRepositoryService")]
    public interface ConfigurationRepositoryService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:ConfigurationRepositoryService/Get", ReplyAction="urn:ConfigurationRepositoryService/GetResponse")]
        System.IAsyncResult BeginGet(APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.SpecificationOfConfigurationsNSnGPiV specification, System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.List<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.Configuration> EndGet(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:ConfigurationRepositoryService/Save", ReplyAction="urn:ConfigurationRepositoryService/SaveResponse")]
        System.IAsyncResult BeginSave(System.Collections.Generic.List<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.Configuration> configurations, System.AsyncCallback callback, object asyncState);
        
        void EndSave(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ConfigurationRepositoryServiceChannel : APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.ConfigurationRepositoryService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.Generic.List<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.Configuration> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.Generic.List<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.Configuration>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ConfigurationRepositoryServiceClient : System.ServiceModel.ClientBase<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.ConfigurationRepositoryService>, APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.ConfigurationRepositoryService {
        
        private BeginOperationDelegate onBeginGetDelegate;
        
        private EndOperationDelegate onEndGetDelegate;
        
        private System.Threading.SendOrPostCallback onGetCompletedDelegate;
        
        private BeginOperationDelegate onBeginSaveDelegate;
        
        private EndOperationDelegate onEndSaveDelegate;
        
        private System.Threading.SendOrPostCallback onSaveCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public ConfigurationRepositoryServiceClient() {
        }
        
        public ConfigurationRepositoryServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ConfigurationRepositoryServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConfigurationRepositoryServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConfigurationRepositoryServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<GetCompletedEventArgs> GetCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> SaveCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.ConfigurationRepositoryService.BeginGet(APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.SpecificationOfConfigurationsNSnGPiV specification, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGet(specification, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.Generic.List<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.Configuration> APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.ConfigurationRepositoryService.EndGet(System.IAsyncResult result) {
            return base.Channel.EndGet(result);
        }
        
        private System.IAsyncResult OnBeginGet(object[] inValues, System.AsyncCallback callback, object asyncState) {
            APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.SpecificationOfConfigurationsNSnGPiV specification = ((APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.SpecificationOfConfigurationsNSnGPiV)(inValues[0]));
            return ((APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.ConfigurationRepositoryService)(this)).BeginGet(specification, callback, asyncState);
        }
        
        private object[] OnEndGet(System.IAsyncResult result) {
            System.Collections.Generic.List<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.Configuration> retVal = ((APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.ConfigurationRepositoryService)(this)).EndGet(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetCompleted(object state) {
            if ((this.GetCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetCompleted(this, new GetCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetAsync(APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.SpecificationOfConfigurationsNSnGPiV specification) {
            this.GetAsync(specification, null);
        }
        
        public void GetAsync(APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.SpecificationOfConfigurationsNSnGPiV specification, object userState) {
            if ((this.onBeginGetDelegate == null)) {
                this.onBeginGetDelegate = new BeginOperationDelegate(this.OnBeginGet);
            }
            if ((this.onEndGetDelegate == null)) {
                this.onEndGetDelegate = new EndOperationDelegate(this.OnEndGet);
            }
            if ((this.onGetCompletedDelegate == null)) {
                this.onGetCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetCompleted);
            }
            base.InvokeAsync(this.onBeginGetDelegate, new object[] {
                        specification}, this.onEndGetDelegate, this.onGetCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.ConfigurationRepositoryService.BeginSave(System.Collections.Generic.List<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.Configuration> configurations, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSave(configurations, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.ConfigurationRepositoryService.EndSave(System.IAsyncResult result) {
            base.Channel.EndSave(result);
        }
        
        private System.IAsyncResult OnBeginSave(object[] inValues, System.AsyncCallback callback, object asyncState) {
            System.Collections.Generic.List<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.Configuration> configurations = ((System.Collections.Generic.List<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.Configuration>)(inValues[0]));
            return ((APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.ConfigurationRepositoryService)(this)).BeginSave(configurations, callback, asyncState);
        }
        
        private object[] OnEndSave(System.IAsyncResult result) {
            ((APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.ConfigurationRepositoryService)(this)).EndSave(result);
            return null;
        }
        
        private void OnSaveCompleted(object state) {
            if ((this.SaveCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SaveCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SaveAsync(System.Collections.Generic.List<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.Configuration> configurations) {
            this.SaveAsync(configurations, null);
        }
        
        public void SaveAsync(System.Collections.Generic.List<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.Configuration> configurations, object userState) {
            if ((this.onBeginSaveDelegate == null)) {
                this.onBeginSaveDelegate = new BeginOperationDelegate(this.OnBeginSave);
            }
            if ((this.onEndSaveDelegate == null)) {
                this.onEndSaveDelegate = new EndOperationDelegate(this.OnEndSave);
            }
            if ((this.onSaveCompletedDelegate == null)) {
                this.onSaveCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSaveCompleted);
            }
            base.InvokeAsync(this.onBeginSaveDelegate, new object[] {
                        configurations}, this.onEndSaveDelegate, this.onSaveCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.ConfigurationRepositoryService CreateChannel() {
            return new ConfigurationRepositoryServiceClientChannel(this);
        }
        
        private class ConfigurationRepositoryServiceClientChannel : ChannelBase<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.ConfigurationRepositoryService>, APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.ConfigurationRepositoryService {
            
            public ConfigurationRepositoryServiceClientChannel(System.ServiceModel.ClientBase<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.ConfigurationRepositoryService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginGet(APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.SpecificationOfConfigurationsNSnGPiV specification, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = specification;
                System.IAsyncResult _result = base.BeginInvoke("Get", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.Generic.List<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.Configuration> EndGet(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.Generic.List<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.Configuration> _result = ((System.Collections.Generic.List<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.Configuration>)(base.EndInvoke("Get", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginSave(System.Collections.Generic.List<APD.Client.Widget.Admin.SL.ConfigurationRepositoryService.Configuration> configurations, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = configurations;
                System.IAsyncResult _result = base.BeginInvoke("Save", _args, callback, asyncState);
                return _result;
            }
            
            public void EndSave(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("Save", _args, result);
            }
        }
    }
}
