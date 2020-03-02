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
            InputConverter ic = new InputConverter();
            CalculatorEngine ce = new CalculatorEngine();
            double first_number  = ic.convertToDouble(Console.ReadLine());
            double second_number = ic.convertToDouble(Console.ReadLine());
            string opertaion = Console.ReadLine();
            double result = ce.operate(first_number, second_number, opertaion);
            Console.WriteLine(result);
            }
            catch(Exception ex)//
            {
                //log exceptions
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
