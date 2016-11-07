using NorthWind;
using System;
using System.Linq;

namespace EntityConcurrency
{
    public class Startup
    {
        static void Main()
        {
            for (int i = 0; i < 5; i++)
            {
                var firstConection = new NWEntities();
                var secondConection = new NWEntities();

                Console.WriteLine($"Now i = {i}");
                var firstCustomer = firstConection.Customers
                                                .Where(x => x.ContactName == "Maria Anders")
                                                .FirstOrDefault();
                var secondCustomer = secondConection.Customers
                                                .Where(x => x.ContactName == "Maria Anders")
                                                .FirstOrDefault();

                Console.WriteLine("First connection name: " + firstCustomer.CompanyName);
                Console.WriteLine("Second connection name: " + secondCustomer.CompanyName);

                firstCustomer.CompanyName = "Telerik 1";
                secondCustomer.CompanyName = "Telerik 2";

                secondConection.SaveChanges();
                firstConection.SaveChanges();

                var result = new NWEntities()
                                    .Customers.Where(x => x.ContactName == "Maria Anders")
                                    .FirstOrDefault();
                Console.WriteLine("Final company name {0}", result.CompanyName);
                Console.WriteLine();
            }
        }
    }
}
