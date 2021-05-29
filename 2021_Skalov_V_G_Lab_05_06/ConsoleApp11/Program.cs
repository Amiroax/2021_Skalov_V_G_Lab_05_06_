
using System;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Mssc.Services.ConnectionManagement
{

    class TestIPAddress
    {

        private static void IPAddresses(string server)
        {
            try
            {
                System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();

          
                IPHostEntry heserver = Dns.GetHostEntry(server);

              
                foreach (IPAddress curAdd in heserver.AddressList)
                {


                   
                    Console.WriteLine("AddressFamily: " + curAdd.AddressFamily.ToString());

                    
                    if (curAdd.AddressFamily.ToString() == ProtocolFamily.InterNetworkV6.ToString())
                        Console.WriteLine("Scope Id: " + curAdd.ScopeId.ToString());


                   
                    Console.WriteLine("Address: " + curAdd.ToString());

                   
                    Console.Write("AddressBytes: ");

                    Byte[] bytes = curAdd.GetAddressBytes();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        Console.Write(bytes[i]);
                    }

                    Console.WriteLine("\r\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[DoResolve] Exception: " + e.ToString());
            }
        }

       
        private static void IPAddressAdditionalInfo()
        {
            try
            {
                
                Console.WriteLine("\r\nSupportsIPv4: " + Socket.SupportsIPv4);
                Console.WriteLine("SupportsIPv6: " + Socket.SupportsIPv6);

                if (Socket.SupportsIPv6)
                {
                   
                    Console.WriteLine("\r\nIPv6Any: " + IPAddress.IPv6Any.ToString());

                    
                    Console.WriteLine("IPv6Loopback: " + IPAddress.IPv6Loopback.ToString());

                   
                    Console.WriteLine("IPv6None: " + IPAddress.IPv6None.ToString());

                    Console.WriteLine("IsLoopback(IPv6Loopback): " + IPAddress.IsLoopback(IPAddress.IPv6Loopback));
                }
                Console.WriteLine("IsLoopback(Loopback): " + IPAddress.IsLoopback(IPAddress.Loopback));
            }
            catch (Exception e)
            {
                Console.WriteLine("[IPAddresses] Exception: " + e.ToString());
            }
        }

        public static void Main(string[] args)
        {
            string server = null;

            Regex rex = new Regex(@"^[a-zA-Z]\w{1,39}$");

            if (args.Length < 1)
            {
                
                server = Dns.GetHostName();
                Console.WriteLine("Using current host: " + server);
            }
            else
            {
                server = args[0];
                if (!(rex.Match(server)).Success)
                {
                    Console.WriteLine("Input string format not allowed.");
                    return;
                }
            }

           
            IPAddresses(server);

            
            IPAddressAdditionalInfo();
        }
    }
}