using NorthWind;

namespace NWCopy
{
    class Startup
    {
        static void Main()
        {
            // Task 6            
            var dbContext = new NWEntities();
            dbContext.Database.CreateIfNotExists();
        }
    }
}
