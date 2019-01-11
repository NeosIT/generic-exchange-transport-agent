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

        private void OnAuthCommandHandler(ReceiveCommandEventSource source, AuthCommandEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] SmtpReceiveAgent - OnAuthCommand fired...");
            foreach (var x in _config.SmtpReceiveAgentConfig.OnAuthCommand)
            {
                try
                {
                    x.Execute();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error executing ""OnAuthCommand""");
                }
            }
        }

        private void OnConnectHandler(ConnectEventSource source, ConnectEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] SmtpReceiveAgent - OnConnect fired...");
            foreach (var x in _config.SmtpReceiveAgentConfig.OnConnect)
            {
                try
                {
                    x.Execute();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error executing ""OnConnect""");
                }
            }
        }

        private void OnDataCommandHandler(ReceiveCommandEventSource source, DataCommandEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] SmtpReceiveAgent - OnDataCommand fired...");
            foreach (var x in _config.SmtpReceiveAgentConfig.OnDataCommand)
            {
                try
                {
                    x.Execute(new EmailItem(e.MailItem));
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error executing ""OnDataCommand""");
                }
            }
        }

        private void OnDisconnectHandler(DisconnectEventSource source, DisconnectEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] SmtpReceiveAgent - OnDisconnect fired...");
            foreach (var x in _config.SmtpReceiveAgentConfig.OnDisconnect)
            {
                try
                {
                    x.Execute();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error executing ""OnDisconnect""");
                }
            }
        }

        private void OnEhloCommandHandler(ReceiveCommandEventSource source, EhloCommandEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] SmtpReceiveAgent - OnEhloCommand fired...");
            foreach (var x in _config.SmtpReceiveAgentConfig.OnEhloCommand)
            {
                try
                {
                    x.Execute();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error executing ""OnEhloCommand""");
                }
            }
        }

        private void OnEndOfAuthenticationHandler(EndOfAuthenticationEventSource source, EndOfAuthenticationEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] SmtpReceiveAgent - OnEndOfAuthentication fired...");
            foreach (var x in _config.SmtpReceiveAgentConfig.OnEndOfAuthentication)
            {
                try
                {
                    x.Execute();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error executing ""OnEndOfAuthentication""");
                }
            }
        }

        private void OnEndOfDataHandler(ReceiveMessageEventSource source, EndOfDataEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] SmtpReceiveAgent - OnEndOfData fired...");
            foreach (var x in _config.SmtpReceiveAgentConfig.OnEndOfData)
            {
                try
                {
                    x.Execute(new EmailItem(e.MailItem));
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error executing ""OnEndOfData""");
                }
            }
        }

        private void OnEndOfHeadersHandler(ReceiveMessageEventSource source, EndOfHeadersEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] SmtpReceiveAgent - OnEndOfHeaders fired...");
            foreach (var x in _config.SmtpReceiveAgentConfig.OnEndOfHeaders)
            {
                try
                {
                    x.Execute(new EmailItem(e.MailItem));
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error executing ""OnEndOfHeaders""");
                }
            }
        }

        private void OnHeloCommandHandler(ReceiveCommandEventSource source, HeloCommandEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] SmtpReceiveAgent - OnHeloCommand fired...");
            foreach (var x in _config.SmtpReceiveAgentConfig.OnHeloCommand)
            {
                try
                {
                    x.Execute();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error executing ""OnHeloCommand""");
                }
            }
        }

        private void OnHelpCommandHandler(ReceiveCommandEventSource source, HelpCommandEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] SmtpReceiveAgent - OnHelpCommand fired...");
            foreach (var x in _config.SmtpReceiveAgentConfig.OnHelpCommand)
            {
                try
                {
                    x.Execute();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error executing ""OnHelpCommand""");
                }
            }
        }

        private void OnMailCommandHandler(ReceiveCommandEventSource source, MailCommandEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] SmtpReceiveAgent - OnMailCommand fired...");
            foreach (var x in _config.SmtpReceiveAgentConfig.OnMailCommand)
            {
                try
                {
                    x.Execute();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error executing ""OnMailCommand""");
                }
            }
        }

        private void OnNoopCommandHandler(ReceiveCommandEventSource source, NoopCommandEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] SmtpReceiveAgent - OnNoopCommand fired...");
            foreach (var x in _config.SmtpReceiveAgentConfig.OnNoopCommand)
            {
                try
                {
                    x.Execute();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error executing ""OnNoopCommand""");
                }
            }
        }

        private void OnRcptCommandHandler(ReceiveCommandEventSource source, RcptCommandEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] SmtpReceiveAgent - OnRcptCommand fired...");
            foreach (var x in _config.SmtpReceiveAgentConfig.OnRcptCommand)
            {
                try
                {
                    x.Execute(new EmailItem(e.MailItem));
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error executing ""OnRcptCommand""");
                }
            }
        }

        private void OnRejectHandler(RejectEventSource source, RejectEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] SmtpReceiveAgent - OnReject fired...");
            foreach (var x in _config.SmtpReceiveAgentConfig.OnReject)
            {
                try
                {
                    x.Execute();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error executing ""OnReject""");
                }
            }
        }

        private void OnRsetCommandHandler(ReceiveCommandEventSource source, RsetCommandEventArgs e)
        {
            Logger.Debug("[GenericTransportAgent] SmtpReceiveAgent - OnRsetCommand fired...");
            foreach (var x in _config.SmtpReceiveAgentConfig.OnRsetCommand)
            {
                try
                {
                    x.Execute();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, @"Error executing ""OnRsetCommand""");
                }
            }
        }
    }
}