using System;
using System.Reflection;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace RoslynApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain domain = AppDomain.CreateDomain("test");
            domain.Load(Assembly.GetExecutingAssembly().GetName());
            var calculator = (Calculator)domain.CreateInstanceAndUnwrap(
                Assembly.GetExecutingAssembly().FullName, "RoslynApp.Calculator");
            for (;;)
            {
                string expession = Console.ReadLine();
                calculator.Calculate(expession);
            }
        }
    }

    class Calculator : System.MarshalByRefObject
    {
        async public void Calculate(string expression)
        {
            var result =  await CSharpScript.EvaluateAsync(expression, ScriptOptions.Default.WithImports("System.Math"));
            WriteResult(result.ToString());
        }
        private void WriteResult(string result)
        {
            Console.WriteLine(result);
        }
    }
    
}
