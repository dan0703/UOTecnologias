using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Service;
using DataAccess;


namespace Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Implementations)))
            {
                host.Open();

                Console.WriteLine("Host is starting");
                using (FEIDBEntities context = new FEIDBEntities())
                {
                    var foundUser = context.GetStudentInfoes.Where(x => x.IdStudent == "zs20015706").FirstOrDefault();
                    Console.WriteLine(foundUser.FullName);
                }
                Console.ReadLine();
            }
        }
    }
}
