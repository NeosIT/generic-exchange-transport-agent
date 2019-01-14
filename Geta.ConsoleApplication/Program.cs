using System;
using NeosIT.Exchange.GenericExchangeTransportAgent.Impl;

namespace NeosIT.Exchange.GenericExchangeTransportAgent.ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var fac = new PluginHost())
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