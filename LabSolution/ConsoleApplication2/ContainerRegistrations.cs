using DryIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public static class ContainerRegistrations
    {
        public static Container container = new Container();

        static ContainerRegistrations()
        {
            LoadRegistrations();
        }
        public static void LoadRegistrations()
        {
            container.Register<ILogger, SimpleLogger>(Reuse.Transient);
            container.Register<IDatabase>(
                made: Made.Of(()=>new MyDatabase(Arg.Of<ILogger>()))
                );
            

        }
    }
}
