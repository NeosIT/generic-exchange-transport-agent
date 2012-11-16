using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Config.Agents
{
    [DataContract(Name = "SmtpReceiveAgent", Namespace = "")]
    public class SmtpReceiveAgentConfig : IAgentConfig
    {
        private IList<IAgentEventHandler> _onAuthCommand = new List<IAgentEventHandler>();
        private IList<IAgentEventHandler> _onConnect = new List<IAgentEventHandler>();
        private IList<IAgentEventHandler> _onDataCommand = new List<IAgentEventHandler>();
        private IList<IAgentEventHandler> _onDisconnect = new List<IAgentEventHandler>();
        private IList<IAgentEventHandler> _onEhloCommand = new List<IAgentEventHandler>();
        private IList<IAgentEventHandler> _onEndOfAuthentication = new List<IAgentEventHandler>();
        private IList<IAgentEventHandler> _onEndOfData = new List<IAgentEventHandler>(); 
        private IList<IAgentEventHandler> _onEndOfHeaders = new List<IAgentEventHandler>();
        private IList<IAgentEventHandler> _onHeloCommand = new List<IAgentEventHandler>();
        private IList<IAgentEventHandler> _onHelpCommand = new List<IAgentEventHandler>();
        private IList<IAgentEventHandler> _onMailCommand = new List<IAgentEventHandler>();
        private IList<IAgentEventHandler> _onNoopCommand = new List<IAgentEventHandler>();
        private IList<IAgentEventHandler> _onRcptCommand = new List<IAgentEventHandler>();
        private IList<IAgentEventHandler> _onReject = new List<IAgentEventHandler>();
        private IList<IAgentEventHandler> _onRsetCommand = new List<IAgentEventHandler>();

        [DataMember(Name = "OnAuthCommand")]
        public IList<IAgentEventHandler> OnAuthCommand
        {
            get { return _onAuthCommand; }
            set { _onAuthCommand = value; }
        }

        [DataMember(Name = "OnConnect")]
        public IList<IAgentEventHandler> OnConnect
        {
            get { return _onConnect; }
            set { _onConnect = value; }
        }

        [DataMember(Name = "OnDataCommand")]
        public IList<IAgentEventHandler> OnDataCommand
        {
            get { return _onDataCommand; }
            set { _onDataCommand = value; }
        }

        [DataMember(Name = "OnDisconnect")]
        public IList<IAgentEventHandler> OnDisconnect
        {
            get { return _onDisconnect; }
            set { _onDisconnect = value; }
        }

        [DataMember(Name = "OnEhloCommand")]
        public IList<IAgentEventHandler> OnEhloCommand
        {
            get { return _onEhloCommand; }
            set { _onEhloCommand = value; }
        }

        [DataMember(Name = "OnEndOfAuthentication")]
        public IList<IAgentEventHandler> OnEndOfAuthentication
        {
            get { return _onEndOfAuthentication; }
            set { _onEndOfAuthentication = value; }
        }

        [DataMember(Name = "OnEndOfData")]
        public IList<IAgentEventHandler> OnEndOfData
        {
            get { return _onEndOfData; }
            set { _onEndOfData = value; }
        }

        [DataMember(Name = "OnEndOfHeaders")]
        public IList<IAgentEventHandler> OnEndOfHeaders
        {
            get { return _onEndOfHeaders; }
            set { _onEndOfHeaders = value; }
        }

        [DataMember(Name = "OnHeloCommand")]
        public IList<IAgentEventHandler> OnHeloCommand
        {
            get { return _onHeloCommand; }
            set { _onHeloCommand = value; }
        }

        [DataMember(Name = "OnHelpCommand")]
        public IList<IAgentEventHandler> OnHelpCommand
        {
            get { return _onHelpCommand; }
            set { _onHelpCommand = value; }
        }

        [DataMember(Name = "OnMailCommand")]
        public IList<IAgentEventHandler> OnMailCommand
        {
            get { return _onMailCommand; }
            set { _onMailCommand = value; }
        }

        [DataMember(Name = "OnNoopCommand")]
        public IList<IAgentEventHandler> OnNoopCommand
        {
            get { return _onNoopCommand; }
            set { _onNoopCommand = value; }
        }

        [DataMember(Name = "OnRcptCommand")]
        public IList<IAgentEventHandler> OnRcptCommand
        {
            get { return _onRcptCommand; }
            set { _onRcptCommand = value; }
        }

        [DataMember(Name = "OnReject")]
        public IList<IAgentEventHandler> OnReject
        {
            get { return _onReject; }
            set { _onReject = value; }
        }

        [DataMember(Name = "OnRsetCommand")]
        public IList<IAgentEventHandler> OnRsetCommand
        {
            get { return _onRsetCommand; }
            set { _onRsetCommand = value; }
        }
    }
}