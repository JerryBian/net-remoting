using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using NetRemoting.Shared;

namespace NetRemoting.Server
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Server side ....");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Press S for stopping service, others for start ...");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.S)
                {
                    var channel = ChannelServices.GetChannel("x");
                    ChannelServices.UnregisterChannel(channel);

                    Console.WriteLine("TCP Channel stopped!!!");
                }
                else
                {
                    var provider = new BinaryServerFormatterSinkProvider
                    {
                        TypeFilterLevel = TypeFilterLevel.Full
                    };
                    var props = new Hashtable
                    {
                        {"port", 25253},
                        {"name", "x"}
                    };
                    var channel = new TcpServerChannel(props, provider);
                    ChannelServices.RegisterChannel(channel, false);
                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(People), "p",
                        WellKnownObjectMode.Singleton);

                    Console.WriteLine("TCP Channel started!!!");
                }
            }
        }
    }
}