﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Smeedee.Client.Web.Tests.TaskConfigurationRepositoryService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://smeedee.org", ConfigurationName="TaskConfigurationRepositoryService.TaskConfigurationRepositoryWebservice")]
    public interface TaskConfigurationRepositoryWebservice {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://smeedee.org/TaskConfigurationRepositoryWebservice/Get", ReplyAction="http://smeedee.org/TaskConfigurationRepositoryWebservice/GetResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Smeedee.DomainModel.Framework.AllSpecification<Smeedee.DomainModel.TaskInstanceConfiguration.TaskConfiguration>))]
        System.Collections.Generic.List<Smeedee.DomainModel.TaskInstanceConfiguration.TaskConfiguration> Get(Smeedee.DomainModel.Framework.Specification<Smeedee.DomainModel.TaskInstanceConfiguration.TaskConfiguration> specification);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://smeedee.org/TaskConfigurationRepositoryWebservice/Save", ReplyAction="http://smeedee.org/TaskConfigurationRepositoryWebservice/SaveResponse")]
        void Save(System.Collections.Generic.List<Smeedee.DomainModel.TaskInstanceConfiguration.TaskConfiguration> taskConfigs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://smeedee.org/TaskConfigurationRepositoryWebservice/Delete", ReplyAction="http://smeedee.org/TaskConfigurationRepositoryWebservice/DeleteResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Smeedee.DomainModel.Framework.AllSpecification<Smeedee.DomainModel.TaskInstanceConfiguration.TaskConfiguration>))]
        void Delete(Smeedee.DomainModel.Framework.Specification<Smeedee.DomainModel.TaskInstanceConfiguration.TaskConfiguration> specification);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TaskConfigurationRepositoryWebserviceChannel : Smeedee.Client.Web.Tests.TaskConfigurationRepositoryService.TaskConfigurationRepositoryWebservice, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TaskConfigurationRepositoryWebserviceClient : System.ServiceModel.ClientBase<Smeedee.Client.Web.Tests.TaskConfigurationRepositoryService.TaskConfigurationRepositoryWebservice>, Smeedee.Client.Web.Tests.TaskConfigurationRepositoryService.TaskConfigurationRepositoryWebservice {
        
        public TaskConfigurationRepositoryWebserviceClient() {
        }
        
        public TaskConfigurationRepositoryWebserviceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TaskConfigurationRepositoryWebserviceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TaskConfigurationRepositoryWebserviceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TaskConfigurationRepositoryWebserviceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<Smeedee.DomainModel.TaskInstanceConfiguration.TaskConfiguration> Get(Smeedee.DomainModel.Framework.Specification<Smeedee.DomainModel.TaskInstanceConfiguration.TaskConfiguration> specification) {
            return base.Channel.Get(specification);
        }
        
        public void Save(System.Collections.Generic.List<Smeedee.DomainModel.TaskInstanceConfiguration.TaskConfiguration> taskConfigs) {
            base.Channel.Save(taskConfigs);
        }
        
        public void Delete(Smeedee.DomainModel.Framework.Specification<Smeedee.DomainModel.TaskInstanceConfiguration.TaskConfiguration> specification) {
            base.Channel.Delete(specification);
        }
    }
}
