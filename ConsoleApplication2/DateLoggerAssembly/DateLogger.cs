using ConsoleApplication2;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[Export(typeof(ILogger))]
public class DateLogger : ILogger
{
    public void Log(string message)
    {
        string filePath = @"C:\Users\Алексей\Desktop\test.log";
        File.AppendAllText(filePath,message);
      
    }
}

