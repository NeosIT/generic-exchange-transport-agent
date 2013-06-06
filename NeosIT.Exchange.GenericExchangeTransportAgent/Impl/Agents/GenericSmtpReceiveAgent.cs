using System;
using System.Linq;
using Microsoft.Exchange.Data.Transport.Smtp;
using NeosIT.Exchange.GenericExchangeTransportAgent.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl.Config;
using Ninject;
using Ninject.Extensions.Logging;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Agents
{
    public class GenericSmtpReceiveAgent : SmtpReceiveAgent
    {
        public IKernel Kernel { get; internal set; }
        public ILogger Logger { get; internal set; }

        private readonly TransportAgentConfig _config;

        public GenericSmtpReceiveAgent()
        {
            Kernel = NInjectHelper.GetKernel();
            Logger = Kernel.Get<ILoggerFactory>().GetCurrentClassLogger();

            _config = ConfigFactory.GetConfig();

            OnAuthCommand += OnAuthCommandHandler;
            OnConnect += OnConnectHandler;
            OnDataCommand += OnDataCommandHandler;
            OnDisconnect += OnDisconnectHandler;
            OnEhloCommand += OnEhloCommandHandler;
            OnEndOfAuthentication += OnEndOfAuthenticationHandler;
            OnEndOfData += OnEndOfDataHandler;
            OnEndOfHeaders += OnEndOfHeadersHandler;
            OnHeloCommand += OnHeloCommandHandler;
            OnHelpCommand += OnHelpCommandHandler;
            OnMailCommand += OnMailCommandHandler;
            OnNoopCommand += OnNoopCommandHandler;
            OnRcptCommand += OnRcptCommandHandler;
            OnReject += OnRejectHandler;
            OnRsetCommand += OnRsetCommandHandler;
        }

        void OnAuthCommandHandler(ReceiveCommandEventSource source, AuthCommandEventArgs e)
        {
            Logger.Debug("[GenericExchangeTransportagent] [SmtpReceiveAgent] OnAuthCommand fired...");
            _config.SmtpReceiveAgentConfig.OnAuthCommand.ToList().ForEach(x => { try { x.Execute(); } catch (Exception ex) { Logger.Error(ex, @"Error executing ""OnAuthCommand"""); } });
        }

        void OnConnectHandler(ConnectEventSource source, ConnectEventArgs e)
        {
            Logger.Debug("[GenericExchangeTransportagent] [SmtpReceiveAgent] OnConnect fired...");
            _config.SmtpReceiveAgentConfig.OnConnect.ToList().ForEach(x => { try { x.Execute(); } catch (Exception ex) { Logger.Error(ex, @"Error executing ""OnConnect"""); } });
        }

        void OnDataCommandHandler(ReceiveCommandEventSource source, DataCommandEventArgs e)
        {
            Logger.Debug("[GenericExchangeTransportagent] [SmtpReceiveAgent] OnDataCommand fired...");
            _config.SmtpReceiveAgentConfig.OnDataCommand.ToList().ForEach(x => { try { x.Execute(new EmailItem(e.MailItem)); } catch (Exception ex) { Logger.Error(ex, @"Error executing ""OnDataCommand"""); } });
        }

        void OnDisconnectHandler(DisconnectEventSource source, DisconnectEventArgs e)
        {
            Logger.Debug("[GenericExchangeTransportagent] [SmtpReceiveAgent] OnDisconnect fired...");
            _config.SmtpReceiveAgentConfig.OnDisconnect.ToList().ForEach(x => { try { x.Execute(); } catch (Exception ex) { Logger.Error(ex, @"Error executing ""OnDisconnect"""); } });
        }

        void OnEhloCommandHandler(ReceiveCommandEventSource source, EhloCommandEventArgs e)
        {
            Logger.Debug("[GenericExchangeTransportagent] [SmtpReceiveAgent] OnEhloCommand fired...");
            _config.SmtpReceiveAgentConfig.OnEhloCommand.ToList().ForEach(x => { try { x.Execute(); } catch (Exception ex) { Logger.Error(ex, @"Error executing ""OnEhloCommand"""); } });
        }

        void OnEndOfAuthenticationHandler(EndOfAuthenticationEventSource source, EndOfAuthenticationEventArgs e)
        {
            Logger.Debug("[GenericExchangeTransportagent] [SmtpReceiveAgent] OnEndOfAuthentication fired...");
            _config.SmtpReceiveAgentConfig.OnEndOfAuthentication.ToList().ForEach(x => { try { x.Execute(); } catch (Exception ex) { Logger.Error(ex, @"Error executing ""OnEndOfAuthentication"""); } });
        }

        void OnEndOfDataHandler(ReceiveMessageEventSource source, EndOfDataEventArgs e)
        {
            Logger.Debug("[GenericExchangeTransportagent] [SmtpReceiveAgent] OnEndOfData fired...");
            _config.SmtpReceiveAgentConfig.OnEndOfData.ToList().ForEach(x => { try { x.Execute(new EmailItem(e.MailItem)); } catch (Exception ex) { Logger.Error(ex, @"Error executing ""OnEndOfData"""); } });
        }

        void OnEndOfHeadersHandler(ReceiveMessageEventSource source, EndOfHeadersEventArgs e)
        {
            Logger.Debug("[GenericExchangeTransportagent] [SmtpReceiveAgent] OnEndOfHeaders fired...");
            _config.SmtpReceiveAgentConfig.OnEndOfHeaders.ToList().ForEach(x => { try { x.Execute(new EmailItem(e.MailItem)); } catch (Exception ex) { Logger.Error(ex, @"Error executing ""OnEndOfHeaders"""); } });
        }

        void OnHeloCommandHandler(ReceiveCommandEventSource source, HeloCommandEventArgs e)
        {
            Logger.Debug("[GenericExchangeTransportagent] [SmtpReceiveAgent] OnHeloCommand fired...");
            _config.SmtpReceiveAgentConfig.OnHeloCommand.ToList().ForEach(x => { try { x.Execute(); } catch (Exception ex) { Logger.Error(ex, @"Error executing ""OnHeloCommand"""); } });
        }

        void OnHelpCommandHandler(ReceiveCommandEventSource source, HelpCommandEventArgs e)
        {
            Logger.Debug("[GenericExchangeTransportagent] [SmtpReceiveAgent] OnHelpCommand fired...");
            _config.SmtpReceiveAgentConfig.OnHelpCommand.ToList().ForEach(x => { try { x.Execute(); } catch (Exception ex) { Logger.Error(ex, @"Error executing ""OnHelpCommand"""); } });
        }

        void OnMailCommandHandler(ReceiveCommandEventSource source, MailCommandEventArgs e)
        {
            Logger.Debug("[GenericExchangeTransportagent] [SmtpReceiveAgent] OnMailCommand fired...");
            _config.SmtpReceiveAgentConfig.OnMailCommand.ToList().ForEach(x => { try { x.Execute(); } catch (Exception ex) { Logger.Error(ex, @"Error executing ""OnMailCommand"""); } });
        }

        void OnNoopCommandHandler(ReceiveCommandEventSource source, NoopCommandEventArgs e)
        {
            Logger.Debug("[GenericExchangeTransportagent] [SmtpReceiveAgent] OnNoopCommand fired...");
            _config.SmtpReceiveAgentConfig.OnNoopCommand.ToList().ForEach(x => { try { x.Execute(); } catch (Exception ex) { Logger.Error(ex, @"Error executing ""OnNoopCommand"""); } });
        }

        void OnRcptCommandHandler(ReceiveCommandEventSource source, RcptCommandEventArgs e)
        {
            Logger.Debug("[GenericExchangeTransportagent] [SmtpReceiveAgent] OnRcptCommand fired...");
            _config.SmtpReceiveAgentConfig.OnRcptCommand.ToList().ForEach(x => { try { x.Execute(new EmailItem(e.MailItem)); } catch (Exception ex) { Logger.Error(ex, @"Error executing ""OnRcptCommand"""); } });
        }

        void OnRejectHandler(RejectEventSource source, RejectEventArgs e)
        {
            Logger.Debug("[GenericExchangeTransportagent] [SmtpReceiveAgent] OnReject fired...");
            _config.SmtpReceiveAgentConfig.OnReject.ToList().ForEach(x => { try { x.Execute(); } catch (Exception ex) { Logger.Error(ex, @"Error executing ""OnReject"""); } });
        }

        void OnRsetCommandHandler(ReceiveCommandEventSource source, RsetCommandEventArgs e)
        {
            Logger.Debug("[GenericExchangeTransportagent] [SmtpReceiveAgent] OnRsetCommand fired...");
            _config.SmtpReceiveAgentConfig.OnRsetCommand.ToList().ForEach(x => { try { x.Execute(); } catch (Exception ex) { Logger.Error(ex, @"Error executing ""OnRsetCommand"""); } });
        }
    }
}