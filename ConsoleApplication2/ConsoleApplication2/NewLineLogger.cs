using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class NewLineLogger:ILogger
    {
        public void Log(string message)
        {
            var words = message.Split(' ');
            foreach (var item in words)
                Console.WriteLine(item);
        }
    }
}
