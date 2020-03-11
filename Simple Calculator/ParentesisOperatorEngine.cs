using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Calculator
{
    class CalculatorEngineWithParenthesis
    {
        private enum ExpectedInput
        {
            num1_or_OpenParenthesis,
            num2_or_OpenParenthesis,
            operator_and_CloseParenthesis
        }



        static int currentlyOpenParenthesis = 0;
        static string currentInput = string.Empty;

        private double firstOperand { get; set; }
        private double secondOperand { get; set; }

        private string operation { get; set; }
     
        /// <summary>
        /// Close parenthesis are automatically set if number of open parenthesis is > 0
        /// If number of openParenthesis is 0 then returns result
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public double GetUserInput()
        {
            string input = string.Empty;
            Console.WriteLine("NOTE: parenthesis will close automatically!");
            Console.WriteLine($"Current Input: {currentInput}");
            Console.WriteLine("Insert 1st Number or '(':");
            input = Console.ReadLine();
            currentInput += $"{input} ";
            if (IsOpenParenthesis(input))
            {
                currentlyOpenParenthesis++;
                CalculatorEngineWithParenthesis poe = new CalculatorEngineWithParenthesis();
                this.firstOperand = poe.GetUserInput();
            }
            else
            {
                this.firstOperand = getAllDigits.ConvertToDouble(input);
            }

            Console.WriteLine($"Current Input: {currentInput}");
            Console.WriteLine("Insert operator:");
            input = Console.ReadLine();
            currentInput += $"{input} ";
            this.operation = ParseOperator(input);


            Console.WriteLine($"Current Input: {currentInput}");
            Console.WriteLine("Insert 2st Number or '(':");
            input = Console.ReadLine();
            currentInput += $"{input} ";
           
            if (IsOpenParenthesis(input))
            {
                currentlyOpenParenthesis++;
                CalculatorEngineWithParenthesis poe = new CalculatorEngineWithParenthesis();
                this.secondOperand = poe.GetUserInput();
            }
            else
            {
                this.secondOperand = getAllDigits.ConvertToDouble(input);
            }

            double result = CalculatorEngine.operate(this.firstOperand, this.secondOperand, this.operation);

            if (currentlyOpenParenthesis > 0)
            {
                currentInput += $") ";
                currentlyOpenParenthesis--;
            }
            else
            {
                currentInput += $" = {result}";
                Console.WriteLine($"Current Input: {currentInput}");
            }
            return result;
        }

        private string ParseOperator(string input)
        {
            string simplifiedOperator = string.Empty;
            switch (input.ToLower())
            {
                case "add":
                case "+":
                    simplifiedOperator = "+";
                    break;
                case "subtract":
                case "-":
                    simplifiedOperator = "-";
                    break;
                case "multiply":
                case "*":
                    simplifiedOperator = "*";
                    break;
                case "divide":
                case "/":
                    simplifiedOperator = "/";
                    break;
                default:
                    throw new InvalidOperationException("operation not recognized");
            }
            return simplifiedOperator;
        }

        private bool IsOpenParenthesis(string input)
        {
            return input == "(";
        }
    }
}
