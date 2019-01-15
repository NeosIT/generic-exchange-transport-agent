using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Config.Agents
{
    [DataContract(Name = "SmtpReceiveAgent", Namespace = "")]
    public class SmtpReceiveAgentConfig : IAgentConfig
    {
        [DataMember(Name = "OnAuthCommand")]
        public IList<IHandler> OnAuthCommand { get; set; } = new List<IHandler>();

        [DataMember(Name = "OnConnect")]
        public IList<IHandler> OnConnect { get; set; } = new List<IHandler>();

        [DataMember(Name = "OnDataCommand")]
        public IList<IHandler> OnDataCommand { get; set; } = new List<IHandler>();

        [DataMember(Name = "OnDisconnect")]
        public IList<IHandler> OnDisconnect { get; set; } = new List<IHandler>();

        [DataMember(Name = "OnEhloCommand")]
        public IList<IHandler> OnEhloCommand { get; set; } = new List<IHandler>();

        [DataMember(Name = "OnEndOfAuthentication")]
        public IList<IHandler> OnEndOfAuthentication { get; set; } = new List<IHandler>();

        [DataMember(Name = "OnEndOfData")]
        public IList<IHandler> OnEndOfData { get; set; } = new List<IHandler>();

        [DataMember(Name = "OnEndOfHeaders")]
        public IList<IHandler> OnEndOfHeaders { get; set; } = new List<IHandler>();

        [DataMember(Name = "OnHeloCommand")]
        public IList<IHandler> OnHeloCommand { get; set; } = new List<IHandler>();

        [DataMember(Name = "OnHelpCommand")]
        public IList<IHandler> OnHelpCommand { get; set; } = new List<IHandler>();

        [DataMember(Name = "OnMailCommand")]
        public IList<IHandler> OnMailCommand { get; set; } = new List<IHandler>();

        [DataMember(Name = "OnNoopCommand")]
        public IList<IHandler> OnNoopCommand { get; set; } = new List<IHandler>();

        [DataMember(Name = "OnRcptCommand")]
        public IList<IHandler> OnRcptCommand { get; set; } = new List<IHandler>();

        [DataMember(Name = "OnReject")]
        public IList<IHandler> OnReject { get; set; } = new List<IHandler>();

        [DataMember(Name = "OnRsetCommand")]
        public IList<IHandler> OnRsetCommand { get; set; } = new List<IHandler>();
    }
}