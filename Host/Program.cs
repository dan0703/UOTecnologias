using System;
using System.ServiceModel;
using Service;

namespace Host
{
    public static class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Implementations)))
            {
                host.Open();

                Console.WriteLine("Host is starting");
                Console.ReadLine();
            }
        }
    }
}
