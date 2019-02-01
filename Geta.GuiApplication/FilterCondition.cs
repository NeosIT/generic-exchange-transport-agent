using NeosIT.Exchange.GenericExchangeTransportAgent.Enums;
using NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Controls;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication
{
    public class FilterCondition : IPayload
    {
        public string DisplayText => Text;
        public string Text { get; }
        public FilterKeyEnum FilterOn { get; }
        public FilterOperatorEnum Operation { get; }

        public FilterCondition(string text)
        {
            Text = text;
        }
    }
}
