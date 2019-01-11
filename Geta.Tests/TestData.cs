using System.IO;
using System.Reflection;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.Tests
{
    public static class TestData
    {
        public static string RootPath { get; } = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\";
    }
}
