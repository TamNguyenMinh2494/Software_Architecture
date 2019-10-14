using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Net;
using System.Net.Sockets;

namespace AppServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelServices.RegisterChannel(new TcpChannel(1234), false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(NoteBUS), "xxx", WellKnownObjectMode.Singleton);
            RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
            Console.WriteLine("Server is running " +GetLocalIPAddress()+"...");
            Console.Read();
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
