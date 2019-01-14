using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Config.Agents
{
    [DataContract(Name = "SmtpReceiveAgent", Namespace = "")]
    public class SmtpReceiveAgentConfig : IAgentConfig
    {
        [DataMember(Name = "OnAuthCommand")]
        public IList<IAgentEventHandler> OnAuthCommand { get; set; } = new List<IAgentEventHandler>();

        [DataMember(Name = "OnConnect")]
        public IList<IAgentEventHandler> OnConnect { get; set; } = new List<IAgentEventHandler>();

        [DataMember(Name = "OnDataCommand")]
        public IList<IAgentEventHandler> OnDataCommand { get; set; } = new List<IAgentEventHandler>();

        [DataMember(Name = "OnDisconnect")]
        public IList<IAgentEventHandler> OnDisconnect { get; set; } = new List<IAgentEventHandler>();

        [DataMember(Name = "OnEhloCommand")]
        public IList<IAgentEventHandler> OnEhloCommand { get; set; } = new List<IAgentEventHandler>();

        [DataMember(Name = "OnEndOfAuthentication")]
        public IList<IAgentEventHandler> OnEndOfAuthentication { get; set; } = new List<IAgentEventHandler>();

        [DataMember(Name = "OnEndOfData")]
        public IList<IAgentEventHandler> OnEndOfData { get; set; } = new List<IAgentEventHandler>();

        [DataMember(Name = "OnEndOfHeaders")]
        public IList<IAgentEventHandler> OnEndOfHeaders { get; set; } = new List<IAgentEventHandler>();

        [DataMember(Name = "OnHeloCommand")]
        public IList<IAgentEventHandler> OnHeloCommand { get; set; } = new List<IAgentEventHandler>();

        [DataMember(Name = "OnHelpCommand")]
        public IList<IAgentEventHandler> OnHelpCommand { get; set; } = new List<IAgentEventHandler>();

        [DataMember(Name = "OnMailCommand")]
        public IList<IAgentEventHandler> OnMailCommand { get; set; } = new List<IAgentEventHandler>();

        [DataMember(Name = "OnNoopCommand")]
        public IList<IAgentEventHandler> OnNoopCommand { get; set; } = new List<IAgentEventHandler>();

        [DataMember(Name = "OnRcptCommand")]
        public IList<IAgentEventHandler> OnRcptCommand { get; set; } = new List<IAgentEventHandler>();

        [DataMember(Name = "OnReject")]
        public IList<IAgentEventHandler> OnReject { get; set; } = new List<IAgentEventHandler>();

        [DataMember(Name = "OnRsetCommand")]
        public IList<IAgentEventHandler> OnRsetCommand { get; set; } = new List<IAgentEventHandler>();
    }
}