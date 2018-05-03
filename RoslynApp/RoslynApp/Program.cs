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
                Console.WriteLine("Expression (for example X+Y+Z):");
                string expession = Console.ReadLine();
                Console.Write("X:");
                string x = Console.ReadLine();
                Console.Write("Y:");
                string y = Console.ReadLine();
                Console.Write("Z:");
                string z = Console.ReadLine();

                Calculator c = new Calculator(expession);
                c.Calculate(new Variables {
                    X = Convert.ToDouble(x),
                    Y = Convert.ToDouble(y),
                    Z = Convert.ToDouble(z)
                });
            }
        }
    }

    class Calculator : System.MarshalByRefObject
    {
        string Expression;
        public Calculator(string expression)
        {
            Expression = expression;
        }
        public Calculator()
        {

        }
        async public void Calculate(Variables var)
        {
            var result = await CSharpScript.EvaluateAsync<double>(Expression, ScriptOptions.Default.WithImports("System.Math"), globals: var);
            WriteResult(result.ToString());
        }
        private void WriteResult(string result)
        {
            Console.WriteLine(result);
        }
    }

    [Serializable]
    public class Variables
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

    }

}
