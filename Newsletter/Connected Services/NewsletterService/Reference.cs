﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Newsletter.NewsletterService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SubscriptionRequest", Namespace="http://schemas.datacontract.org/2004/07/Newsletter.Service.Messages")]
    [System.SerializableAttribute()]
    public partial class SubscriptionRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Newsletter.NewsletterService.Subscription SubscriptionField;
        
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
        public Newsletter.NewsletterService.Subscription Subscription {
            get {
                return this.SubscriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.SubscriptionField, value) != true)) {
                    this.SubscriptionField = value;
                    this.RaisePropertyChanged("Subscription");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Subscription", Namespace="http://schemas.datacontract.org/2004/07/Newsletter.Service.Entities")]
    [System.SerializableAttribute()]
    public partial class Subscription : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Newsletter.NewsletterService.MarketingSource MarketingSourceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OtherField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ReasonField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime SubscriptionDateField;
        
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
        public string EmailAddress {
            get {
                return this.EmailAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailAddressField, value) != true)) {
                    this.EmailAddressField = value;
                    this.RaisePropertyChanged("EmailAddress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Newsletter.NewsletterService.MarketingSource MarketingSource {
            get {
                return this.MarketingSourceField;
            }
            set {
                if ((this.MarketingSourceField.Equals(value) != true)) {
                    this.MarketingSourceField = value;
                    this.RaisePropertyChanged("MarketingSource");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Other {
            get {
                return this.OtherField;
            }
            set {
                if ((object.ReferenceEquals(this.OtherField, value) != true)) {
                    this.OtherField = value;
                    this.RaisePropertyChanged("Other");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Reason {
            get {
                return this.ReasonField;
            }
            set {
                if ((object.ReferenceEquals(this.ReasonField, value) != true)) {
                    this.ReasonField = value;
                    this.RaisePropertyChanged("Reason");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime SubscriptionDate {
            get {
                return this.SubscriptionDateField;
            }
            set {
                if ((this.SubscriptionDateField.Equals(value) != true)) {
                    this.SubscriptionDateField = value;
                    this.RaisePropertyChanged("SubscriptionDate");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MarketingSource", Namespace="http://schemas.datacontract.org/2004/07/Newsletter.Service.Entities")]
    public enum MarketingSource : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Advert = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        WordOfMouth = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Other = 2,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SubscriptionResponse", Namespace="http://schemas.datacontract.org/2004/07/Newsletter.Service.Messages")]
    [System.SerializableAttribute()]
    public partial class SubscriptionResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ResultField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Newsletter.NewsletterService.Subscription SubscriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Newsletter.NewsletterService.Subscription[] SubscriptionsField;
        
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
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Result {
            get {
                return this.ResultField;
            }
            set {
                if ((this.ResultField.Equals(value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Newsletter.NewsletterService.Subscription Subscription {
            get {
                return this.SubscriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.SubscriptionField, value) != true)) {
                    this.SubscriptionField = value;
                    this.RaisePropertyChanged("Subscription");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Newsletter.NewsletterService.Subscription[] Subscriptions {
            get {
                return this.SubscriptionsField;
            }
            set {
                if ((object.ReferenceEquals(this.SubscriptionsField, value) != true)) {
                    this.SubscriptionsField = value;
                    this.RaisePropertyChanged("Subscriptions");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="NewsletterService.INewsletterService")]
    public interface INewsletterService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsletterService/Subscribe", ReplyAction="http://tempuri.org/INewsletterService/SubscribeResponse")]
        Newsletter.NewsletterService.SubscriptionResponse Subscribe(Newsletter.NewsletterService.SubscriptionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsletterService/Subscribe", ReplyAction="http://tempuri.org/INewsletterService/SubscribeResponse")]
        System.Threading.Tasks.Task<Newsletter.NewsletterService.SubscriptionResponse> SubscribeAsync(Newsletter.NewsletterService.SubscriptionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsletterService/Unsubscribe", ReplyAction="http://tempuri.org/INewsletterService/UnsubscribeResponse")]
        Newsletter.NewsletterService.SubscriptionResponse Unsubscribe(Newsletter.NewsletterService.SubscriptionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsletterService/Unsubscribe", ReplyAction="http://tempuri.org/INewsletterService/UnsubscribeResponse")]
        System.Threading.Tasks.Task<Newsletter.NewsletterService.SubscriptionResponse> UnsubscribeAsync(Newsletter.NewsletterService.SubscriptionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsletterService/GetSubscription", ReplyAction="http://tempuri.org/INewsletterService/GetSubscriptionResponse")]
        Newsletter.NewsletterService.SubscriptionResponse GetSubscription(Newsletter.NewsletterService.SubscriptionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INewsletterService/GetSubscription", ReplyAction="http://tempuri.org/INewsletterService/GetSubscriptionResponse")]
        System.Threading.Tasks.Task<Newsletter.NewsletterService.SubscriptionResponse> GetSubscriptionAsync(Newsletter.NewsletterService.SubscriptionRequest request);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INewsletterServiceChannel : Newsletter.NewsletterService.INewsletterService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NewsletterServiceClient : System.ServiceModel.ClientBase<Newsletter.NewsletterService.INewsletterService>, Newsletter.NewsletterService.INewsletterService {
        
        public NewsletterServiceClient() {
        }
        
        public NewsletterServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NewsletterServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NewsletterServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NewsletterServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Newsletter.NewsletterService.SubscriptionResponse Subscribe(Newsletter.NewsletterService.SubscriptionRequest request) {
            return base.Channel.Subscribe(request);
        }
        
        public System.Threading.Tasks.Task<Newsletter.NewsletterService.SubscriptionResponse> SubscribeAsync(Newsletter.NewsletterService.SubscriptionRequest request) {
            return base.Channel.SubscribeAsync(request);
        }
        
        public Newsletter.NewsletterService.SubscriptionResponse Unsubscribe(Newsletter.NewsletterService.SubscriptionRequest request) {
            return base.Channel.Unsubscribe(request);
        }
        
        public System.Threading.Tasks.Task<Newsletter.NewsletterService.SubscriptionResponse> UnsubscribeAsync(Newsletter.NewsletterService.SubscriptionRequest request) {
            return base.Channel.UnsubscribeAsync(request);
        }
        
        public Newsletter.NewsletterService.SubscriptionResponse GetSubscription(Newsletter.NewsletterService.SubscriptionRequest request) {
            return base.Channel.GetSubscription(request);
        }
        
        public System.Threading.Tasks.Task<Newsletter.NewsletterService.SubscriptionResponse> GetSubscriptionAsync(Newsletter.NewsletterService.SubscriptionRequest request) {
            return base.Channel.GetSubscriptionAsync(request);
        }
    }
}
