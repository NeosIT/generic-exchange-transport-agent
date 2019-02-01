using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Controls;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication
{
    public class FilterCondition : IPayload
    {
        private string _text;

        public string DisplayText => _text;

        public FilterCondition(string text)
        {
            _text = text;
        }
    }
}
