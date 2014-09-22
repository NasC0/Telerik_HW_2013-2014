﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="ICheckStrings")]
public interface ICheckStrings
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICheckStrings/GetContainingCount", ReplyAction="http://tempuri.org/ICheckStrings/GetContainingCountResponse")]
    int GetContainingCount(string substring, string fulltext);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICheckStrings/GetContainingCount", ReplyAction="http://tempuri.org/ICheckStrings/GetContainingCountResponse")]
    System.Threading.Tasks.Task<int> GetContainingCountAsync(string substring, string fulltext);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface ICheckStringsChannel : ICheckStrings, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class CheckStringsClient : System.ServiceModel.ClientBase<ICheckStrings>, ICheckStrings
{
    
    public CheckStringsClient()
    {
    }
    
    public CheckStringsClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public CheckStringsClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public CheckStringsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public CheckStringsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public int GetContainingCount(string substring, string fulltext)
    {
        return base.Channel.GetContainingCount(substring, fulltext);
    }
    
    public System.Threading.Tasks.Task<int> GetContainingCountAsync(string substring, string fulltext)
    {
        return base.Channel.GetContainingCountAsync(substring, fulltext);
    }
}
