using System.Linq;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication.Impl.Extensions
{
    public static class Net35Extensions
    {
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrEmpty(str.Trim());
        } 
    }
}