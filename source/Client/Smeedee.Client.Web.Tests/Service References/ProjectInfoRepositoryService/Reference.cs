﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Smeedee.Client.Web.Tests.ProjectInfoRepositoryService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://smeedee.org", ConfigurationName="ProjectInfoRepositoryService.ProjectInfoRepositoryService")]
    public interface ProjectInfoRepositoryService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://smeedee.org/ProjectInfoRepositoryService/Get", ReplyAction="http://smeedee.org/ProjectInfoRepositoryService/GetResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Smeedee.DomainModel.Framework.AllSpecification<Smeedee.DomainModel.ProjectInfo.ProjectInfoServer>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Smeedee.DomainModel.ProjectInfo.ProjectInfoServerByUrl))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Smeedee.DomainModel.ProjectInfo.ProjectInfoServerByName))]
        System.Collections.Generic.List<Smeedee.DomainModel.ProjectInfo.ProjectInfoServer> Get(Smeedee.DomainModel.Framework.Specification<Smeedee.DomainModel.ProjectInfo.ProjectInfoServer> specification);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ProjectInfoRepositoryServiceChannel : Smeedee.Client.Web.Tests.ProjectInfoRepositoryService.ProjectInfoRepositoryService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProjectInfoRepositoryServiceClient : System.ServiceModel.ClientBase<Smeedee.Client.Web.Tests.ProjectInfoRepositoryService.ProjectInfoRepositoryService>, Smeedee.Client.Web.Tests.ProjectInfoRepositoryService.ProjectInfoRepositoryService {
        
        public ProjectInfoRepositoryServiceClient() {
        }
        
        public ProjectInfoRepositoryServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProjectInfoRepositoryServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProjectInfoRepositoryServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProjectInfoRepositoryServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<Smeedee.DomainModel.ProjectInfo.ProjectInfoServer> Get(Smeedee.DomainModel.Framework.Specification<Smeedee.DomainModel.ProjectInfo.ProjectInfoServer> specification) {
            return base.Channel.Get(specification);
        }
    }
}