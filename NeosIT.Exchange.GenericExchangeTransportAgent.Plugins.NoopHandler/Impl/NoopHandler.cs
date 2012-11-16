using System;
using System.ComponentModel.Composition;
using System.Runtime.Serialization;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.Common.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.NoopHandler.Impl.Forms;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.NoopHandler.Impl
{
    [Export(typeof(IHandler))]
    [DataContract(Name = "NoopHandler", Namespace = "")]
    public class NoopHandler : FilterableHandlerBase, INoopHandler
    {
        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void ShowConfigDialog()
        {
            var configForm = new ConfigForm();
            configForm.ShowDialog();
        }

        public override void Execute(IEmailItem emailItem = null, int? lastExitCode = null)
        {
            if (null != emailItem)
            {
                if (null != Handlers && Handlers.Count > 0)
                {
                    foreach (var handler in Handlers)
                    {
                        handler.Execute(emailItem, lastExitCode);
                    }
                }
            }
        }

        public override string Name
        {
            get { return "NoopHandler"; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
