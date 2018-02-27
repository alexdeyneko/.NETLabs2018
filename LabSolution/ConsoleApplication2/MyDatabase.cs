using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class MyDatabase : IDatabase
    {

        ILogger logger;
        public MyDatabase(ILogger logger)
        {
            this.logger = logger;
        }
        public void Execute(string query)
        {
            logger.Log(query);
        }
    }

}
