using DryIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string query = "Привет лунатикам";
            

            ILogger logger = ContainerRegistrations
                .container.Resolve<ILogger>();

            var getMyClass = ContainerRegistrations
                .container.Resolve<Func<ILogger, IDatabase>>();

            IDatabase database = getMyClass(logger);

            database.Execute(query);

        }
    }
}
