using System;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl.Config;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var fac = Configuration.PluginHost)
            {
                if (null != fac.Handlers)
                {
                    foreach (var handler in fac.Handlers)
                    {
                        Console.WriteLine(handler.Name);
                    }
                }

                Console.ReadLine();
            }
        }
    }
}