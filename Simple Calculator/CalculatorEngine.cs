using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Calculator
{
    class CalculatorEngine
    {

        public static double operate(double first_number, double second_number, string operation)
        {
            double result = 0;
            switch (operation.ToLower())
            {
                case "add":
                case "+":
                    result = first_number + second_number;
                    // return result;
                    break;

                case "subtract":
                case "-":
                    result = first_number - second_number;
                    //return result;
                    break;
                case "multiply":
                case "*":
                    result = first_number * second_number;
                    //return result;
                    break;
                case "divide":
                case "/":
                    result = first_number / second_number;
                    // return result;
                    break;
                default:
                    throw new InvalidOperationException("operation not recognized");

            }
            return result;
        }
    }
}
