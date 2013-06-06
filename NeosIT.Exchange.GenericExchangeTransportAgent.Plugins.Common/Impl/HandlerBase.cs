namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    
    using Ninject.Extensions.Logging;
    
    [DataContract(Namespace = "")]
    public abstract class HandlerBase : LoggingBase, IHandler, ILogger
    {
        protected HandlerBase()
        {
            _logPrefix = string.Format(" [GenericExchangeTransportAgent] [{0}] ", Name);
        }

        private string _logPrefix = string.Empty;

        private IList<IHandler> _handlers = new List<IHandler>();

        [DataMember]
        public IList<IHandler> Handlers
        {
            get { return _handlers; }
            set { _handlers = value; }
        }

        public abstract string Name { get; }

        public abstract void Execute(IEmailItem emailItem = null, int? lastExitCode = null);

        [OnDeserialized]
        private void OnDeserialized(StreamingContext c)
        {
            _logPrefix = string.Format(" [GenericExchangeTransportAgent] [{0}] ", Name);
        }

        public void Debug(string message)
        {

            Logger.Debug(_logPrefix + message);
        }

        public void Debug(string format, params object[] args)
        {
            Logger.Debug(_logPrefix + format, args);
        }

        public void Debug(Exception exception, string format, params object[] args)
        {
            Logger.Debug(exception, _logPrefix + format, args);
        }

        public void Info(string message)
        {
            Logger.Info(_logPrefix + message);
        }

        public void Info(string format, params object[] args)
        {
            Logger.Info(_logPrefix + format, args);
        }

        public void Info(Exception exception, string format, params object[] args)
        {
            Logger.Info(exception, _logPrefix + format, args);
        }

        public void Trace(string message)
        {
            Logger.Trace(_logPrefix + message);
        }

        public void Trace(string format, params object[] args)
        {
            Logger.Trace(_logPrefix + format, args);
        }

        public void Trace(Exception exception, string format, params object[] args)
        {
            Logger.Trace(exception, _logPrefix + format, args);
        }

        public void Warn(string message)
        {
            Logger.Warn(_logPrefix + message);
        }

        public void Warn(string format, params object[] args)
        {
            Logger.Warn(_logPrefix + format, args);
        }

        public void Warn(Exception exception, string format, params object[] args)
        {
            Logger.Warn(exception, _logPrefix + format, args);
        }

        public void Error(string message)
        {
            Logger.Error(_logPrefix + message);
        }

        public void Error(string format, params object[] args)
        {
            Logger.Error(_logPrefix + format, args);
        }

        public void Error(Exception exception, string format, params object[] args)
        {
            Logger.Error(exception, _logPrefix + format, args);
        }

        public void Fatal(string message)
        {
            Logger.Fatal(_logPrefix + message);
        }

        public void Fatal(string format, params object[] args)
        {
            Logger.Fatal(_logPrefix + format, args);
        }

        public void Fatal(Exception exception, string format, params object[] args)
        {
            Logger.Fatal(exception, _logPrefix + format, args);
        }

        public Type Type { get { return Logger.Type; } }
        public bool IsDebugEnabled { get { return Logger.IsDebugEnabled; } }
        public bool IsInfoEnabled { get { return Logger.IsInfoEnabled; } }
        public bool IsTraceEnabled { get { return Logger.IsTraceEnabled; } }
        public bool IsWarnEnabled { get { return Logger.IsWarnEnabled; } }
        public bool IsErrorEnabled { get { return Logger.IsErrorEnabled; } }
        public bool IsFatalEnabled { get { return Logger.IsFatalEnabled; } }
    }
}
