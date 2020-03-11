using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                //UseSimpleCalculator();
                UseParentesisCalculatorEngine();
                Console.WriteLine("Type any Key to exit...");
                Console.ReadLine();

            }
            catch (Exception ex)//
            {
                //log exceptions
                Console.WriteLine(ex.Message);
            }
            
        }

        static void UseSimpleCalculator()
        {
            Console.WriteLine($"Simple Calculator{System.Environment.NewLine}" +
                              $"-----------------");
            Console.WriteLine("Type first number:");
            double first_number = getAllDigits.ConvertToDouble(Console.ReadLine());
            Console.WriteLine("Type second number:");
            double second_number = getAllDigits.ConvertToDouble(Console.ReadLine());
            Console.WriteLine("Type operator:");
            string operation = Console.ReadLine();
            Console.WriteLine("Result:");
            double result = CalculatorEngine.operate(first_number, second_number, operation);
            Console.WriteLine(result);
        }

        static void UseParentesisCalculatorEngine()
        {
            CalculatorEngineWithParenthesis calculator = new CalculatorEngineWithParenthesis();
            double result = calculator.GetUserInput();
            Console.WriteLine($"Result: {result}");
        }
    }
}
